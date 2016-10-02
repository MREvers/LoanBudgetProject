using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Threading.Tasks;
using BudgetProjectionProject.DateStrategies;

namespace BudgetProjectionProject.Budgets
{
    /// <summary>
    /// This is a class that wraps a date strategy with an amount.
    /// This class is an Observer and Observed.
    /// </summary>
    public class Plan : Observed<IPlanObserver>, IDateObserver, IXmlSaveable
    {
        public float Amount;

        public DateStrategy Strategy;

        public Plan(float amount, DateStrategy strategy)
        {
            Amount = amount;
            Strategy = strategy;
            strategy.RegisterObserver(this);
        }

        public Plan(string id, float amount, DateStrategy strategy) : this(amount, strategy)
        {
            m_ID = id;
        }

        public string GetReadable()
        {
            string szRetVal = "";

            szRetVal += "Plan Name: " + ID + "\n";
            szRetVal += "Amount: " + Amount + "\n";
            szRetVal += "Strategy:" + Strategy.GetReadable() + "\n";

            return szRetVal;
        }

        public virtual string GetXMLSave()
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

        public virtual void GetXMLSave( XmlWriter xw)
        {
            xw.WriteStartElement("Plan");
            xw.WriteAttributeString("ID", this.ID);

            xw.WriteStartElement("Amount");
            xw.WriteString(this.Amount.ToString());
            xw.WriteEndElement();

            Strategy.GetXMLSave(xw);

            xw.WriteEndElement();
            xw.Flush();
        }

        public string Notify(string id)
        {
            return NotifyObservers();
        }

        public override string NotifyObservers()
        {
            string szRetVal = "";
            foreach(IPlanObserver observer in m_Observers)
            {
                szRetVal += observer.Notify(m_ID, Amount) + "\n";
            }
            return szRetVal;
        }

        public override string ToString()
        {
            return this.Amount + " @ " + this.Strategy.Debug();
        }

        public void Free()
        {
            Strategy.UnRegisterObserver(this);
            Strategy = null;
        }
    }
}
