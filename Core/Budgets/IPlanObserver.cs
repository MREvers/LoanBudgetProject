using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetProjectionProject.Budgets
{
    public interface IPlanObserver : IObserving
    {
        /// <summary>
        /// Id is unique to the strategy assigned by the observer.
        /// </summary>
        /// <param name="id">ID of the calling date strategy</param>
        string Notify(string id, float amt);
    }
}
