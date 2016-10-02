using System;
using System.Numerics;
using System.Windows;
using System.Windows.Media.Media3D;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BudgetProjectionProject.Loans;
using BudgetProjectionProject.Budgets;
using BudgetProjectionProject.DateStrategies;

namespace BudgetProjectionProject.Core
{
    public class InfoTracker
    {
        private class MonthData
        {
            public List<string> Days;

            // Loans
            // 1: Before
            // 2: After
            // 3: Interest
            // 4: Payment amounts
            public Dictionary<string, List<float>> Loans;

            // Budget + Fund
            public Dictionary<string, Vector> Funds;
            public Vector Savings;

            public int Month;

            public MonthData(int month)
            {
                Days = new List<string>();
                Loans = new Dictionary<string, List<float>>();
                Funds = new Dictionary<string, Vector>();
                Month = month;
                Savings = new Vector();
            }

            public override string ToString()
            {
                string details = "";
                //  XDayOfMonth.MONTH_NAMES[Month%12]
                details += "Month Number" + "(" + Month + ")" + ":";
                details += Environment.NewLine;
                details += "Savings: ";
                details += Math.Round(Savings.X, 2) + " ---> " + Math.Round(Savings.Y, 2);
                details += " (" + (Savings.X > Savings.Y ? "-" : "+") + Math.Abs(Savings.Y - Savings.X) + ")";
                details += Environment.NewLine;
                details += Environment.NewLine;
                details += "Funds:";
                details += Environment.NewLine;
                foreach (string key in Funds.Keys)
                {
                    Vector fund = Funds[key];
                    details += "|--" + key + ": " + Math.Round(fund.X, 2) + " ---> " + Math.Round(fund.Y, 2);
                    details += " (" + (fund.X > fund.Y ? "-" : "+") + Math.Abs(fund.Y - fund.X) + ")";
                    details += Environment.NewLine;
                }
                details += Environment.NewLine;
                details += "Loans:";
                details += Environment.NewLine;
                foreach (string key in Loans.Keys)
                {
                    List<float> loan = Loans[key];
                    details += "|--" + key;
                    details += Environment.NewLine;
                    details += "   |--" + "Balance: " + Math.Round(loan[0], 2) + " ---> " + Math.Round(loan[1], 2);
                    details += Environment.NewLine;
                    details += "   |--" + "Interest Gained: " + Math.Round(loan[2], 2);
                    details += Environment.NewLine;
                    details += "   |--" + "Amount Paid: " + Math.Round(loan[3], 2);
                    details += Environment.NewLine;
                }
                details += Environment.NewLine;
                details += "Debug:";
                details += Environment.NewLine;
                foreach(string day in Days)
                {
                    foreach (string line in day.Split('\n'))
                    {
                        if (line != "")
                        {
                            details += "|-" + line;
                            details += Environment.NewLine;
                        }
                    }
                    details += Environment.NewLine;
                }

                return details;
            }
        }

        public Projection ActiveProjection;
        public int NumMonths { get { return Months.Count; } }
        private List<MonthData> Months;
        private string m_ID;
        private MonthData m_CurrentMonth;

        public InfoTracker(string id, Projection proj)
        {
            m_CurrentMonth = null;
            Months = new List<MonthData>();
            ActiveProjection = proj;
            m_ID = id;
        }

        // Check loan balances before/after
        // --> Check for paid off loans (calculated)
        // --> Check interest gained on the loans (checked)
        // --> TODO Check for which loans had more than just minimum payments (calculated)
        // Check Savings balance before/after
        // --> Check funds balances before/after
        // Record the debug
        public void Open_Track(int day)
        {
            if (XDayOfMonth.GetDayOfMonth(day) == 0)
            {
                if (m_CurrentMonth == null)
                {
                    m_CurrentMonth = new MonthData(Months.Count);
                }

                // Check loan balances before
                // Begin tracking interest
                foreach (Loan loan in ActiveProjection.Loans)
                {
                    if (!m_CurrentMonth.Loans.ContainsKey(loan.Name))
                    {
                        m_CurrentMonth.Loans.Add(loan.Name, new List<float>() { loan.Principal });
                        loan.TrackInterest(m_ID);
                    }
                }

                // Check savings before
                m_CurrentMonth.Savings = new Vector(ActiveProjection.Budget.Balance, 0);

                // Check funds before
                foreach (Fund fund in ActiveProjection.Funds)
                {
                    if (!m_CurrentMonth.Funds.ContainsKey(fund.Name))
                    {
                        m_CurrentMonth.Funds.Add(fund.Name, new Vector(fund.Balance, 0));
                    }
                }
            }
        }

        public void Track(int day, string debug)
        {
           
            m_CurrentMonth.Days.Add(debug);

        }

        public void Close_Track(int day, bool close = false)
        {
            if (XDayOfMonth.GetDayOfMonth(day+1) == 0 || close)
            {
                // Check loan balances after
                // Check interest gained
                foreach (Loan loan in ActiveProjection.Loans)
                {

                    m_CurrentMonth.Loans[loan.Name] = new List<float>()
                    {
                        m_CurrentMonth.Loans[loan.Name][0],
                        loan.Principal,
                        loan.TrackInterest(m_ID, false),
                        m_CurrentMonth.Loans[loan.Name][0] - (loan.Principal - loan.TrackInterest(m_ID, true))
                    };

                }

                // Check savings after
                m_CurrentMonth.Savings.Y = ActiveProjection.Budget.Balance;

                // Check funds after
                foreach (Fund fund in ActiveProjection.Funds)
                {
                    m_CurrentMonth.Funds[fund.Name] =
                        new Vector(m_CurrentMonth.Funds[fund.Name].X, fund.Balance);
                }

                Months.Add(m_CurrentMonth);
                m_CurrentMonth = null;
            }
        }

        public void ResetIC()
        {
            Months.Clear();
        }

        public string GetMonth(int i)
        {
            return Months[i].ToString();
        }
    }
}
