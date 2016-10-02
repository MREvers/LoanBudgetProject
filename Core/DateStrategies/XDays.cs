using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Threading.Tasks;

namespace BudgetProjectionProject.DateStrategies
{
    class XDays : DateStrategy
    {
        private int m_Days;

        /// <summary>
        /// Stores the number of days to wait between notifying observers.
        /// </summary>
        /// <param name="days">Days to wait</param>
        /// <param name="ID">Used to notify observers</param>
        public XDays(int days, string ID) : base(ID)
        {
            m_Days = days;
        }

        /// <summary>
        /// Checks whether the day is a day that observers should be notified.
        /// </summary>
        /// <param name="day">Day to check.</param>
        /// <returns>Whether or not to notify observers</returns>
        override public bool IsNow(int day)
        {
            return (day >= StartDate && (day % m_Days == 0)); ;
        }

        /// <summary>
        /// String for debug
        /// </summary>
        /// <returns></returns>
        override public string Debug()
        {
            return base.Debug() + "Occurs every " + (m_Days).ToString() + " day(s).";
        }

        public override string GetReadable()
        {
            string readable = "";

            readable += "This strategy will notify its observers ";
            readable += "every " + (m_Days).ToString() + " day(s).";
            readable += "\n";
            readable += "Starting after day " + this.StartDate;
            return readable;
        }

        /// <summary>
        /// Used in APY calculation.
        /// </summary>
        /// <returns></returns>
        public override float PerYear()
        {
            return 365 / m_Days;
        }

        /// <summary>
        /// See IXMLSaveable
        /// </summary>
        /// <returns></returns>
        public override string GetXMLSave()
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

        /// <summary>
        /// See IXMLSaveable
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="xw"></param>
        /// <returns></returns>
        public override void GetXMLSave(XmlWriter xw)
        {
            xw.WriteStartElement("Strategy");
            xw.WriteAttributeString("Type", "XDays");
            xw.WriteStartElement("ID");
            xw.WriteString(this.m_ID);
            xw.WriteEndElement();
            xw.WriteStartElement("DayCount");
            xw.WriteString(this.m_Days.ToString());
            xw.WriteEndElement();
            xw.WriteEndElement();
            xw.Flush();
        }
    }
}
