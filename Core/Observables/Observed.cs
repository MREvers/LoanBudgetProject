using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetProjectionProject.DateStrategies;

namespace BudgetProjectionProject
{
    public abstract class Observed<T> where T : IObserving
    {
        protected string m_ID;
        protected List<T> m_Observers;

        public string ID
        {
            get { return m_ID; }
            set { }
        }

        public Observed()
        {
            m_ID = "0";
            m_Observers = new List<T>();
        }

        public Observed(string id) : this()
        {
            m_ID = id;
        }

        abstract public string NotifyObservers();

        public void RegisterObserver(T DO)
        {
            m_Observers.Add(DO);
        }

        public void UnRegisterObserver(T DO)
        {
            m_Observers.Remove(DO);
        }

        public int ObserverCount()
        {
            return m_Observers.Count;
        }
    }
}
