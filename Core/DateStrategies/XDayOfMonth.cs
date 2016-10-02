using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Threading.Tasks;

namespace BudgetProjectionProject.DateStrategies
{
    class XDayOfMonth : DateStrategy
    {
        /// <summary>
        /// Used to calculate what day of the month it is.
        /// </summary>
        public static int[] MONTH_LENGTHS = new int[12]
        {
            31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31
        };

        /// <summary>
        /// Used in display.
        /// </summary>
        public static string[] MONTH_NAMES = new string[12]
        {
            "January", "February", "March", "April", "May", "June", "July",
            "August", "September", "October", "November", "December"
        };

        private int m_DayOfMonth;

        /// <summary>
        /// Limits the latest notification day to the 28th day of the month.
        /// </summary>
        /// <param name="dayOfMonth">Day of each month to notify observers.</param>
        /// <param name="ID">Used to notify observers</param>
        public XDayOfMonth(int dayOfMonth, string ID) : base(ID)
        {
            m_DayOfMonth = (dayOfMonth - 1) % 28;
        }

        /// <summary>
        /// Checks if the current day is after the start date, and then
        ///  checks if the day is the right day of the month.
        /// </summary>
        /// <param name="day">Day to check</param>
        /// <returns>Whether or not to notify observers.</returns>
        override public bool IsNow(int day)
        {
            return (day >= StartDate && (GetDayOfMonth(day) == m_DayOfMonth));
        }

        /// <summary>
        /// String for debug purposes.
        /// </summary>
        /// <returns></returns>
        override public string Debug()
        {
            return base.Debug() + "Occurs on the " + (m_DayOfMonth).ToString() + " day of the month.";
        }

        public override string GetReadable()
        {
            string readable = "";

            readable += "This strategy will notify its observers ";
            readable += "on the " + (m_DayOfMonth).ToString() + " day of the month.";
            readable += "\n";
            readable += "Starting after day " + this.StartDate;
            return readable;
        }

        /// <summary>
        /// See DateStrategy
        /// </summary>
        /// <returns></returns>
        public override float PerYear()
        {
            return 12;
        }

        /// <summary>
        /// Calculates the day of the month given a day.
        /// </summary>
        /// <param name="day">Day to convert</param>
        /// <returns>Integer day of the month</returns>
        public static int GetDayOfMonth(int day)
        {
            int iRetVal = day;
            int i = 0;
            while (iRetVal >= 28)
            {
                iRetVal -= MONTH_LENGTHS[i%12];
                i++;
            }
            return iRetVal;
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
            xw.WriteAttributeString("Type", "XDayOfMonth");
            xw.WriteStartElement("ID");
            xw.WriteString(this.m_ID);
            xw.WriteEndElement();
            xw.WriteStartElement("DayCount");
            xw.WriteString(this.m_DayOfMonth.ToString());
            xw.WriteEndElement();
            xw.WriteEndElement();
            xw.Flush();
        }
    
    }
}
