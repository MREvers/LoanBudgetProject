using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Threading.Tasks;

namespace BudgetProjectionProject.DateStrategies
{
    /// <summary>
    /// DateStrategy provides a default functionality and interface for date strategies.
    /// A datestrategy, when given a day, will determine if that day is the day that some
    ///  action should be taken. The action is taken by the observers.
    /// </summary>
    public abstract class DateStrategy : Observed<IDateObserver>, IDateStrategy, IXmlSaveable
    {
        public int StartDate;
        public int EndDate;

        /// <summary>
        /// Initialize start and end date. Store the ID for the Observed class.
        /// </summary>
        /// <param name="ID">String used to notify observers.</param>
        public DateStrategy(string ID) : base(ID)
        {
            StartDate = 0;
            EndDate = -1;
        }

        /// <summary>
        /// Returns a string containing some info about the DateStrategy.
        /// </summary>
        /// <returns>Information</returns>
        virtual public string Debug()
        {
            return "<ID=" + m_ID + "> After Day " + StartDate + "; ";
        }

        /// <summary>
        /// If IsNow is not implemented, returns false. Checks if the day is a day
        ///  that observers should be notified.
        /// </summary>
        /// <param name="day">Day to check</param>
        /// <returns>Whether or not to notify observers.</returns>
        virtual public bool IsNow(int day)
        {
            return false;
        }

        /// <summary>
        /// Used in Loan APY calculation. Currently Not used anywhere else.
        /// </summary>
        /// <returns></returns>
        virtual public float PerYear()
        {
            return 0;
        }

        public virtual string GetReadable()
        {
            return "";
        }

        /// <summary>
        /// Typical observer pattern.
        /// </summary>
        /// <returns></returns>
        public override string NotifyObservers()
        {
            string szRetVal = "";
            foreach(IDateObserver observer in m_Observers)
            {
                szRetVal += observer.Notify(m_ID);
            }
            return szRetVal;
        }

        /// <summary>
        /// Sets the start and the end date of this instance.
        /// MODIFIES STATE.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void SetStartEndDate(int start, int end = -1)
        {
            StartDate = start;
            EndDate = end;
        }

        /// <summary>
        /// Required by IXMLSaveable.
        /// </summary>
        /// <returns></returns>
        public abstract string GetXMLSave();
        public abstract void GetXMLSave(XmlWriter xw);
    }
}
