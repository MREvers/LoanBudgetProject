
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Threading.Tasks;
using BudgetProjectionProject.Budgets;
using BudgetProjectionProject.DateStrategies;

namespace BudgetProjectionProject.Loans
{
    public class Loan : IPlanObserver, IXmlSaveable, IInitialConditions
    {
        public string Name;

        Fund m_LoanBalance;
        public Plan InterestPlan;
        public FundedPlan MinimumPaymentPlan;

        float m_CurrentPayment;

        public float APR;
        public float PaymentsSinceLastMinimumPayment;
        public float MinimumPayment { get { return Math.Min(MinimumPaymentPlan.Amount, Principal); } }
        public float Principal { get { return m_LoanBalance.Balance; } }

        // Used to track interest gained among many object 'watchers'
        private Dictionary<string, float> InterestTrackers;

        public Loan(string name,
            float principal, Plan interestPlan,
            FundedPlan minPaymentPlan)
        {
            Name = name;

            interestPlan.RegisterObserver(this);
            APR = interestPlan.Amount;
            MinimumPaymentPlan = minPaymentPlan;

            minPaymentPlan.RegisterObserver(this);
            InterestPlan = interestPlan;

            m_CurrentPayment = 0;
            m_LoanBalance = new Fund(Name + " loan balance", principal);

            PaymentsSinceLastMinimumPayment = 0;
            InterestTrackers = new Dictionary<string, float>();
        }

        public string GetReadable()
        {
            string szRetVal = "";

            szRetVal += Name + ":" + "\n";
            szRetVal += "Principal:" + Principal + "\n";
            szRetVal += "Interest Plan:" + "\n";
            szRetVal += InterestPlan.GetReadable().Replace("\n", "\n  ");
            szRetVal += "Payment Plan:" + "\n";
            szRetVal += MinimumPaymentPlan.GetReadable().Replace("\n", "\n  ");
            szRetVal += "Source Fund: \n" +
                MinimumPaymentPlan.Source.GetReadable().Replace("\n", "\n  ") + "\n";
            return szRetVal;
        }

        public string GetXMLSave()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            using (var sw = new StringWriter())
            {
                using (var xw = XmlWriter.Create(sw, settings))
                {
                    GetXMLSave(xw);
                    return sw.ToString();
                }
                
            }

        }

        public void GetXMLSave(XmlWriter xw)
        {
            xw.WriteStartElement("Loan");
            xw.WriteAttributeString("Name", this.Name);

            xw.WriteStartElement("Balance");
            xw.WriteString(this.m_LoanBalance.Balance.ToString());
            xw.WriteEndElement();

            xw.WriteStartElement("InterestPlan");
            InterestPlan.GetXMLSave(xw);
            xw.WriteEndElement();

            xw.WriteStartElement("PaymentPlan");
            MinimumPaymentPlan.GetXMLSave(xw);
            xw.WriteEndElement();

            xw.WriteEndElement();
            xw.Flush();
        }

        /// <summary>
        /// Called by the date strategies.
        /// Determines if the payment plan is calling or the interest plan is calling
        ///  then takes action appropriately.
        /// </summary>
        /// <param name="id">ID of notifying plan</param>
        public string Notify(string id, float amt)
        {
            string szRetVal = "";
            if (id == InterestPlan.ID)
            {
                Accrue();
            }
            else if (id == MinimumPaymentPlan.ID)
            {
                float requiredPaymentAmount = Math.Max(
                    MinimumPaymentPlan.Amount - PaymentsSinceLastMinimumPayment, 0
                    );
                if (requiredPaymentAmount > 0)
                {
                    szRetVal += StagePayment(MinimumPaymentPlan.Amount);
                }
                else
                {
                    szRetVal += "\nNo Minimum Payment Required to " + Name;
                }
                
                PaymentsSinceLastMinimumPayment = 0;
            }
            return szRetVal;
        }

        /// <summary>
        /// Adds an amount to the 'current' payment.
        /// The balance of the loan is not affected until the 
        ///  payment is committed.
        /// MODIFIES STATE
        /// </summary>
        /// <param name="amt">Amount to stage</param>
        /// <returns>Debug</returns>
        public string StagePayment(float amt)
        {
            return StagePayment(MinimumPaymentPlan.Source, amt);
        }

        /// <summary>
        /// Deducts funds from the source by the amount and deducts that
        ///  from the balance of the loan.
        /// MODIFIES STATE
        /// </summary>
        /// <param name="source">Source of funds</param>
        /// <param name="amt">Amount to deduct</param>
        /// <returns>Debug</returns>
        public string StagePayment(Fund source, float amt)
        {
            string szRetVal = "";
            float actualPayment = Math.Min(amt, Principal);
            szRetVal += source.Transact(-actualPayment);
            m_CurrentPayment += actualPayment;
            PaymentsSinceLastMinimumPayment += actualPayment;
            return szRetVal;
        }

        /// <summary>
        /// Subtracts the current staged payment from the balance and
        ///  resets it to zero.
        /// MODIFIES STATE
        /// </summary>
        /// <returns>Debug</returns>
        public string CommitPayment()
        {
            string szRetVal = "";
            if (m_CurrentPayment > 0)
            {
                m_LoanBalance.Balance -= m_CurrentPayment;
                szRetVal += "\n";
                szRetVal += "Payment of " + m_CurrentPayment + " made to " + this.Name +
                    ". Principal remaining " + this.Principal;
                m_CurrentPayment = 0;
            }
            return szRetVal;
        }

        public void Free(bool reusePlan = false)
        {
            MinimumPaymentPlan.UnRegisterObserver(this);
            if (!reusePlan)
            {
                MinimumPaymentPlan.Free();
                InterestPlan.Free();
            }
            
            MinimumPaymentPlan = null;
            InterestPlan.UnRegisterObserver(this);
            
            InterestPlan = null;
        }

        private void Accrue()
        {
            float interest = PrincipalInterest();
            m_LoanBalance.Balance += interest;
            var Keys = new List<string> (InterestTrackers.Keys);
            foreach (string obs in Keys)
            {
                InterestTrackers[obs] += interest;
            }
        }

        private float PrincipalInterest()
        {
            return (Principal * (APR / InterestPlan.Strategy.PerYear()));
        }

        /// <summary>
        /// Used by outside objects to check how much interest has been
        ///  accrued since that object last reset;
        /// </summary>
        /// <returns>The amount of interest gained since the caller last reset</returns>
        public float TrackInterest(string name, bool reset = false)
        {
            float fRetVal = 0f;
            if (InterestTrackers.ContainsKey(name))
            {
                fRetVal = InterestTrackers[name];
                if (reset)
                {
                    InterestTrackers[name] = 0f;
                }
            }
            else
            {
                InterestTrackers.Add(name, 0);
            }
            return fRetVal;
        }

        public void LockInitialConditions()
        {
            m_LoanBalance.LockInitialConditions();
            MinimumPaymentPlan.Source.LockInitialConditions();
        }

        public void ResetIC()
        {
            PaymentsSinceLastMinimumPayment = 0;
            m_CurrentPayment = 0;
            InterestTrackers.Clear();

            m_LoanBalance.ResetIC();
            MinimumPaymentPlan.Source.ResetIC();
        }

        public override string ToString()
        {
            return Name + " (" + Principal + ")";
        }
    }
}
