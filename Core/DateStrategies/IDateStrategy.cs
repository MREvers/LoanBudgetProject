using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetProjectionProject.DateStrategies
{
    /// <summary>
    /// Required interface for datestrategies.
    /// </summary>
    public interface IDateStrategy
    {
        bool IsNow(int day);
        float PerYear();
        string Debug();
    }
}
