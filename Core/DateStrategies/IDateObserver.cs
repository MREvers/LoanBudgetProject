using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetProjectionProject.DateStrategies
{
    /// <summary>
    /// Required interface to observe a datestrategy.
    /// </summary>
    public interface IDateObserver : IObserving
    {
        /// <summary>
        /// Id is unique to the strategy assigned by the observer.
        /// </summary>
        /// <param name="id">ID of the calling date strategy</param>
        string Notify(string id);
    }
}
