using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetProjectionProject.DateStrategies;
using System.Xml;
using System.IO;

namespace BudgetProjectionProject.Budgets
{
    /// <summary>
    /// This class stores the main balance from which all funds and balances derive.
    /// Loans will ultimately take money from this fund.
    /// </summary>
    public class Budget : Fund, IPlanObserver, IInitialConditions
    {
        // Used to store fixed expenses.
        public List<Plan> Deltas;

        // Used to allocate money to funds.
        public Dictionary<string, Fund> Budgets;

        // Used as a tool to de-allocate funds. (enables garbage collection)
        public Dictionary<Fund, Plan> BudgetMap;

        public Budget(string name, float amount) : base(name, amount)
        {
            Deltas = new List<Plan>();
            Budgets = new Dictionary<string, Fund>();
            BudgetMap = new Dictionary<Fund, Plan>();

            Rigid = true;
        }

        /// <summary>
        /// Add a fixed expense. The number associated with the plan will be
        ///  added to the balance each time the plan is notified (and the plan notifies the budget).
        /// MODIFIES STATE
        /// </summary>
        /// <param name="delta">Plan to implement. (amount and when information)</param>
        public void AddDelta(Plan delta)
        {
            Deltas.Add(delta);
            delta.RegisterObserver(this);
        }

        /// <summary>
        /// Used to schedule regular funds allocation to the target fund
        ///  based on the given plan.
        /// MODIFIES STATE
        /// </summary>
        /// <param name="fund">Fund to put/take money</param>
        /// <param name="plan">Amount and when to allocate funds.</param>
        public void AllocateFunds(Fund fund, Plan plan)
        {
            if (BudgetMap.ContainsKey(fund))
            {
                
            }
            else
            {
                Budgets.Add(plan.ID, fund);
                BudgetMap.Add(fund, plan);
                plan.RegisterObserver(this);
            }
        }

        /// <summary>
        /// Removes references to a fund and stops regular transactions
        ///  with the fund. (Used for garbage collection)
        /// MODIFIES STATE
        /// </summary>
        /// <param name="fund"></param>
        public void DeAllocateFund(Fund fund)
        {
            if (BudgetMap.ContainsKey(fund))
            {
                Budgets.Remove(Budgets.Where(kvp => kvp.Value == fund).First().Key);
                BudgetMap[fund].UnRegisterObserver(this);
                BudgetMap.Remove(fund);
            }
        }

        public void ReplaceAllocatedFund(Fund outFund, Fund inFund)
        {
            if (BudgetMap.ContainsKey(outFund))
            {
                string key = Budgets.Where(kvp => kvp.Value == outFund).First().Key;
                Budgets.Remove(key);
                Budgets.Add(inFund.Name, inFund);
                BudgetMap.Add(inFund, BudgetMap[outFund]);
                BudgetMap.Remove(outFund);
            }
        }

        /// <summary>
        /// All the deltas associated with this budget have an ID.
        /// They will identify themselves and provide their amount.
        /// </summary>
        /// <param name="id">Id of the notifier</param>
        /// <param name="amt">Amount info from the notifier.</param>
        public string Notify(string id, float amt)
        {
            string szRetVal = "";
            if (Budgets.ContainsKey(id))
            {
                szRetVal += "Funds allocation: \n";
                szRetVal += Budgets[id].Transact(this, amt);
            }
            else
            {
                szRetVal += "\n" + id + ": ";
                szRetVal += this.Transact(amt);
            }
            return szRetVal;
        }

        public override string GetXMLSave()
        {
            XmlDocument xmlDoc = new XmlDocument();
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

        public override void GetXMLSave(XmlWriter xw)
        {
            xw.WriteStartElement("Fund");
            xw.WriteAttributeString("Name", this.Name);
            xw.WriteAttributeString("Rigid", this.Rigid.ToString());

            xw.WriteStartElement("Parent");
            xw.WriteString(Parent == null ? "Null" : Parent.Name);
            xw.WriteEndElement(); // Parent

            xw.WriteStartElement("Balance");
            xw.WriteString(Balance.ToString());
            xw.WriteEndElement(); // Balance

            xw.WriteStartElement("Children");
            foreach (Fund child in Children)
            {
                xw.WriteStartElement("Child");
                xw.WriteAttributeString("Name", child.Name);
                xw.WriteEndElement(); // Child
            }
            xw.WriteEndElement(); // Children

            xw.WriteStartElement("Deltas");
            foreach (Plan delta in Deltas)
            {
                delta.GetXMLSave(xw);
            }
            xw.WriteEndElement(); // Deltas

            xw.WriteStartElement("FundAllocations");
            foreach (string key in Budgets.Keys)
            {
                xw.WriteStartElement("Allocation");
                BudgetMap[Budgets[key]].GetXMLSave(xw);
                xw.WriteStartElement("Fund");
                xw.WriteAttributeString("ID", Budgets[key].Name);
                xw.WriteEndElement();
                
                xw.WriteEndElement(); // Allocation
            }
            xw.WriteEndElement(); // Fund Allocations

            xw.WriteEndElement(); // Fund
            xw.Flush();
        }
    }
}
