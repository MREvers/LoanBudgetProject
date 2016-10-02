using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetProjectionProject.Loans;
using BudgetProjectionProject.DateStrategies;
using System.Xml;
using System.IO;

namespace BudgetProjectionProject.Budgets
{
    /// <summary>
    /// Chooses what loan to fund depending on the selector
    /// IN list of loans, strategy, fund/budget, selector
    /// ON NOTIFY pay to the loan of greatest selected with whatever remains in the fund.
    /// 
    /// These should really use their own fund. Using one fund across multiple SLAs will
    ///  cause one SLA to intercept the other.
    /// 
    /// MUST BE A FLEXIBLE FUND
    /// 
    /// Observes a fundedplan
    /// </summary>
    public class SelectiveLoanAgreement : IDateObserver, IInitialConditions, IXmlSaveable
    {
        // List of loans to make payments to
        public List<Loan> LoanSet;

        public string ID;

        public DateStrategy Strategy;

        public Fund Source;

        // Derived from the source fund.
        private Budget m_Budget;

        /* m_SourceBalanceCalibration
         * Used to calculate the average (Per 'Strategy' time)ly balance
         *  in the source fund.
         * For example,
         * If funds are deposited once a year, and this SLA takes action
         *  monthly, then this will be 1/12.
         * If funds are deposited daily, and this SLA takes action daily,
         *  then this will be 1.
         */
        private float m_SourceBalanceCalibration;

        // This is only used if nonRigid. If Rigid, uses current balance.
        float m_BaseBalance;

        public SelectiveLoanAgreement(string id, DateStrategy strategy, Fund fund)
        {
            LoanSet = new List<Loan>();
            Strategy = strategy;
            strategy.RegisterObserver(this);
            ID = id;

            Source = fund;
            m_Budget = GetBudgetFromSource();
            m_SourceBalanceCalibration = GetBalanceRatio();
        }

        /// <summary>
        /// REQUIRES 'Source'
        /// 
        /// Searches up from the source fund, to eventually find the
        ///  source budget.
        /// </summary>
        /// <returns>The Active Budget</returns>
        private Budget GetBudgetFromSource()
        {
            Fund currentFund = Source;
            while (currentFund.Parent != null)
            {
                currentFund = currentFund.Parent;
            }
            return (Budget)currentFund;
        }

        /// <summary>
        /// REQUIRES 'm_Budget', 'Source'
        /// 
        /// Gets the per year frequency that funds are deposited in
        ///  the source fund.
        /// </summary>
        /// <returns></returns>
        private float GetBalanceRatio()
        {
            return m_Budget.BudgetMap[Source].Strategy.PerYear() / Strategy.PerYear();
        }

        public void AddLoanOption(Loan loan)
        {
            LoanSet.Add(loan);
        }

        /// <summary>
        /// Orders the list of loans that are targetted by this SLA in order
        ///  of most interest gained since last SLA action.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Loan> GetPrioritizedLoans()
        {
            IEnumerable<Loan> retSet = LoanSet;
            if (LoanSet.Count > 1)
            {
                retSet = retSet.OrderBy(x => -x.TrackInterest(ID));
            }
            return retSet;
        }

        

        /// <summary>
        /// Make payment based on the average balance in the source fund per <SLA action>
        /// Makes a payment to the loan that has the highest principal interest since
        ///  last payment.
        /// </summary>
        /// <param name="id">ID of notifying plan. Not Used here.</param>
        public string Notify(string id)
        {
            string szRetVal = "";

            // Get an ordered list from highest principal interest to lowest.
            var LoanList = GetPrioritizedLoans();
            
            // Find balance after minimums.
            float balanceAfterMinimums = 0;

            // Sum up all the minimum payments.
            foreach (Loan loan in LoanSet)
            {
                if (loan.MinimumPaymentPlan.Source == Source)
                {
                    balanceAfterMinimums += loan.MinimumPayment;
                }
            }

            // Subtract the minimum payments to find how much is left to flex
            //  between the loans. Account for action timing differences with m_Source...
            balanceAfterMinimums = m_BaseBalance * ( m_SourceBalanceCalibration ) - balanceAfterMinimums;

            Loan bestLoan;
            // Get a list of loans in order of highest principal interest.
            var orderedLoanList = LoanList.GetEnumerator();

            // Track how much will be paid in total. Account for payments that
            //  will/have been made to minimum balances by starting at balanceAfterMinimums
            float RemainingBalance = balanceAfterMinimums;

            // Pay loans until the balance is depleted.
            while (RemainingBalance > 0 &&
                (orderedLoanList.MoveNext()))
            {
                // Reference to the current loan.
                bestLoan = orderedLoanList.Current;

                // Account for the fact that the minimum payment of this loan
                //  is already subtracted. (see above)
                RemainingBalance += bestLoan.MinimumPayment;

                // The actual payment may be limited by three things
                // It can never be greater than.
                // 1. The loan principal.
                // 2. The entire flex amount in the balance before payments.
                // 3. The remaining balance
                // The entire flex amount in the balance is the amount of money
                //  left in the fund after minimum payments are accounted for.
                float actualPayment =
                    Math.Max(Math.Min(Math.Min(
                        balanceAfterMinimums + bestLoan.MinimumPayment
                    , bestLoan.Principal),
                    RemainingBalance),0);

                // Produce the debug
                szRetVal += ("Payment of ");
                szRetVal += actualPayment;
                szRetVal += (" paid on " +
                    bestLoan.ToString() +
                    " from " + Source.Name);
                szRetVal += "\n Interest gained since last reset on " +
                    bestLoan.ToString() + " is " + bestLoan.TrackInterest(ID);

                // Produce debug and stage the payment.
                szRetVal += bestLoan.StagePayment(Source, actualPayment);

                // Subtract the actual payment from the remaining balance.
                // Any left over will be spent on the next loan.
                RemainingBalance -= actualPayment;

                // Produce debug and commit the payment.
                szRetVal += bestLoan.CommitPayment();
            }

            // Reset the principal interest tracking so that
            //  the loans may be properly ordered upon next payment.
            foreach (Loan loan in LoanList)
            {
                loan.TrackInterest(ID, reset: true);
            }

            return szRetVal;
        }

        /// <summary>
        /// Clears dependency references (Used to enable garbage collection)
        /// </summary>
        public void Free()
        {
            Strategy.UnRegisterObserver(this);
            Strategy = null;
        }

        /// <summary>
        /// Store the state of the class so that it may be restored after a simulation.
        /// </summary>
        public void LockInitialConditions()
        {
            Source.LockInitialConditions();
            m_Budget = GetBudgetFromSource();
            m_SourceBalanceCalibration = GetBalanceRatio();
            if (!Source.Rigid)
            {
                m_BaseBalance = Source.Balance;
            }
        }

        /// <summary>
        /// Reset the state of this class to pre-simulation conditions
        /// </summary>
        public void ResetIC()
        {
            Source.ResetIC();
        }

        public string GetReadable()
        {
            string readable = "";
            readable += this.ID + "\n";
            readable += "Source Fund: \n" +
                this.Source.GetReadable().Replace("\n", "\n  ") + "\n";
            readable += "Strategy:" + Strategy.GetReadable() + "\n";
            readable += "Loans: \n";
            foreach (Loan loan in LoanSet)
            {
                readable += loan.Name + "\n";
            }
            return readable;
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
            xw.WriteStartElement("SLA");
            xw.WriteAttributeString("Name", this.ID);

            xw.WriteStartElement("LoanSet");
            foreach (Loan loan in LoanSet)
            {
                xw.WriteStartElement("Loan");
                xw.WriteAttributeString("Name", loan.Name);
                xw.WriteEndElement(); // Loan
            }
            xw.WriteEndElement(); // Loanset
            
            xw.WriteStartElement("Strategy");
            xw.WriteAttributeString("ID", Strategy.ID);
            xw.WriteEndElement(); // Strategy
            xw.WriteStartElement("Fund");
            xw.WriteAttributeString("Name", Source.Name);
            xw.WriteEndElement(); // Fund
            xw.WriteEndElement(); // SLA
            xw.Flush();
        }
    }
}
