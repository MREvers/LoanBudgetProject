using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BudgetProjectionProject.Budgets
{
    /// <summary>
    /// Used to store a balance that can be subtracted or added to.
    /// </summary>
    public class Fund : IXmlSaveable, IInitialConditions
    {
        public float Balance;

        /* Rigid
         * Rigid defines the behavior of the fund.
         * IF RIGID == TRUE
         *  If rigid is true, then any funds added to this fund from its parent
         *  is deducted from the parent. More funds will only be taken from the
         *  parent if this fund goes below 0.
         * IF RIGID == FALSE
         *  If rigid is false, then funds added to and subtracted from sources
         *  OTHER THAN the parent will be deducted from the parent ALWAYS. The
         *  balance stored on this fund merely behaves as an offset. This is
         *  used by SLAs.
         */
        public bool Rigid;

        // Used in debug and tracking.
        public string Name;

        // Source of funds.
        public Fund Parent;

        // NOT IN USE. Although it does store child funds.
        public List<Fund> Children;

        // Used in calculation for NON RIGID funds. (The fund EXPECTS this amount)
        float m_InitialBalance;

        /// <summary>
        /// Standard constructor. Subtract initial balance from parent if able.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="amount"></param>
        /// <param name="rigid"></param>
        public Fund(string name, float amount, bool rigid = true)
        {
            Name = name;
            Balance = amount;
            Children = new List<Fund>();
            Rigid = rigid;
            if (rigid && Parent != null)
            {
                Parent.Balance -= amount;
            }
        }

        /// <summary>
        /// This constructor requires a source fund.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parent"></param>
        /// <param name="amount"></param>
        /// <param name="rigid"></param>
        public Fund(string name, Fund parent, float amount, bool rigid = true) : this(name, amount, rigid)
        {
            Parent = parent;
            Parent.Children.Add(this);
        }

        public void SetParent(Fund parent)
        {
            Parent.Children.Remove(this);
            Parent = parent;
            Parent.Children.Add(this);
        }

        /// <summary>
        /// Deducts the amt from the input fund and adds the amt to
        ///  this fund. (Deduct/add is flipped if amt < 0)
        /// MODIFIES STATE; MODFIES 'fund' STATE
        /// </summary>
        /// <param name="fund">Fund to 'subtract' from</param>
        /// <param name="amt">Amount to transact</param>
        /// <returns></returns>
        public virtual string Transact(Fund fund, float amt)
        {
            string szRetVal = "";
            if (!Rigid && fund == Parent)
            {
                if (amt > 0)
                {
                    szRetVal += (Name + " Set (" + Balance + ":" + (amt) + ")" + " <--(" + amt + ")--* ");
                }
                else
                {
                    szRetVal += (Name + " Set (" + Balance + ":" + (amt) + ")" + " --(" + amt + ")-->* ");
                }
                Balance = amt;
            }
            else
            {
                fund.Balance -= amt;
                szRetVal += Transact(amt);
                szRetVal += (fund.Name + "(" + fund.Balance + ")");
                szRetVal += ("\n");
            }
            return szRetVal;
        }

        /// <summary>
        /// See above. MODIFIES STATE
        /// </summary>
        /// <param name="amt"></param>
        /// <returns></returns>
        public virtual string Transact(float amt)
        {
            string szRetVal = "\n";
            if (amt > 0)
            {
                szRetVal += (Name + "(" + Balance + ":" + (Balance + amt) +")" + " <--(" + amt + ")-- ");
            }
            else
            {
                szRetVal += (Name + "(" + Balance + ":" + (Balance + amt) + ")" + " --(" + amt + ")--> ");
            }
            Balance += amt;
            if (Parent != null)
            {
                if (!Rigid)
                {
                    szRetVal += Parent.Transact(amt);
                }
                else if (Balance < 0)
                {
                    szRetVal += Parent.Transact(this, -Balance);
                }
            }

            return szRetVal;
        }

        public string GetReadable()
        {
            string szRetVal = "";

            szRetVal += "Name: " + Name + "\n";
            szRetVal += "Sourced From: " + Parent.Name + "\n";
            szRetVal += "Balance: " + Balance + "\n";

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
            xw.WriteStartElement("Fund");
            xw.WriteAttributeString("Name", this.Name);
            xw.WriteAttributeString("Rigid", this.Rigid.ToString());

            xw.WriteStartElement("Parent");
            xw.WriteString(Parent == null ? "Null" : Parent.Name);
            xw.WriteEndElement(); // Parent
            foreach(Fund child in Children)
            {
                xw.WriteStartElement("Child");
                xw.WriteString(child.Name);
                xw.WriteEndElement(); // Child
            }
            xw.WriteStartElement("Balance");
            xw.WriteString(Balance.ToString());
            xw.WriteEndElement(); // Balance
            xw.WriteEndElement(); // Fund
            xw.Flush();
        }

        /// <summary>
        /// Stores pre-simulation conditions.
        /// MODIFIES STATE
        /// </summary>
        public void LockInitialConditions()
        {
            m_InitialBalance = Balance;
        }

        /// <summary>
        /// Restores pre-simulation conditions.
        /// </summary>
        public void ResetIC()
        {
            Balance = m_InitialBalance;
        }
    }
}
