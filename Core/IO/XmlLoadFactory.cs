using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using BudgetProjectionProject.Budgets;
using BudgetProjectionProject.DateStrategies;
using BudgetProjectionProject.Loans;
namespace BudgetProjectionProject.Core
{
    class XmlLoadFactory
    {

        public XmlLoadFactory()
        {

        }

        public bool CreateDayOfMonth(XmlReader xr, out XDayOfMonth strat)
        {
            int dom = 0;
            string id = "";
            while ((xr.NodeType == XmlNodeType.EndElement ? xr.Name != "Strategy" : true))
            {
                if (xr.NodeType == XmlNodeType.Element)
                {
                    while(xr.Name != "ID" && xr.Read()){}
                    xr.Read();
                    id = xr.Value;
                    while (xr.Name != "DayCount" && xr.Read()) { }
                    xr.Read();
                    int.TryParse(xr.Value, out dom);
                }
                xr.Read();
            }
            strat = new XDayOfMonth(dayOfMonth: dom + 1, ID: id);
            return true;
        }

        // Start the reader after the first attribute has been read.
        public bool CreateXDays(XmlReader xr, out XDays strat)
        {
            int dom = 0;
            string id = "";
            while ((xr.NodeType == XmlNodeType.EndElement ? xr.Name != "Strategy" : true))
            {
                if (xr.NodeType == XmlNodeType.Element)
                {
                    while (xr.Name != "ID" && xr.Read()) { }
                    xr.Read();
                    id = xr.Value;
                    while (xr.Name != "DayCount" && xr.Read()) { }
                    xr.Read();
                    int.TryParse(xr.Value, out dom);
                }
                xr.Read();
            }
            strat = new XDays(days: dom, ID: id);
            return true;
        }

        // Start the reader after the "budget" element has been read.
        public bool CreateBudget(XmlReader reader, Projection projection, out Budget budget)
        {
            bool bRetVal = true;

            #region Budget
            // Move from "Budget" to "fund" element
            while (reader.Name != "Fund" && reader.Read()) { }

            // Move to the id attribute
            string name;
            reader.MoveToFirstAttribute();
            name = reader.Value;

            // Move to the balance field
            float balance;
            while (reader.Name != "Balance" && reader.Read()) { }
            reader.Read();
            bRetVal &= float.TryParse(reader.Value, out balance);

            // Create the budget
            Budget createdBudget = new Budget(name, balance);
            #endregion Budget

            // Get the children
            // Create dummy funds.
            while (reader.Name != "Children" && reader.Read()) { }

            reader.Read();
            while (reader.Name != "Children" && reader.Read())
            {
                // Get the allocation
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Child")
                {
                    // Move to the name field
                    reader.MoveToFirstAttribute();

                    // Create dummy funds
                    createdBudget.Children.Add(new Fund(reader.Value, 0));
                }
            }

            #region Deltas
            // Get the plans ---
            // Move to the "Deltas" list
            while (reader.Name != "Deltas" && reader.Read()) { }

            // Continue until we've reached the end of the deltas
            // Move past the start element
            reader.Read();
            while (reader.Name != "Deltas" && reader.Read( ))
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Plan")
                {
                    // Get the id attribute
                    string planId;
                    reader.MoveToFirstAttribute();
                    planId = reader.Value;

                    // Move to the plan amount
                    float amount;
                    while (reader.Name != "Amount" && reader.Read()) { }
                    reader.Read();
                    bRetVal &= float.TryParse(reader.Value, out amount);

                    // Get the strategy name, look it up, then save the reference.
                    DateStrategy strat;
                    while (reader.Name != "ID" && reader.Read()) { }
                    reader.Read();
                    strat = projection.Strategies.Where(x => x.ID == reader.Value).First();
                    bRetVal &= strat != null;

                    // Create the plan and save it off
                    createdBudget.AddDelta(new Plan(planId, amount, strat));
                }
            }
            #endregion deltas

            #region Fund Allocations
            // Get all the fund allocations
            // Store in dummy funds for now. Funds will be generated later.
            while (reader.Name != "FundAllocations" && reader.Read()) { }

            // Continue until we've reached the end of the allocations
            // Move past the start element
            reader.Read();
            while (reader.Name != "FundAllocations" && reader.Read())
            {
               
                // Get the allocation
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Allocation")
                {
                    // Get the plan
                    Plan fundPlan = null;
                    while (reader.Name != "Plan" && reader.Read()) { }

                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Plan")
                    {
                        // Get the id attribute
                        string planId2;
                        reader.MoveToFirstAttribute();
                        planId2 = reader.Value;

                        // Move to the plan amount
                        float amount2;
                        while (reader.Name != "Amount" && reader.Read()) { }
                        reader.Read();
                        bRetVal &= float.TryParse(reader.Value, out amount2);

                        // Get the strategy name, look it up, then save the reference.
                        DateStrategy strat2;
                        while (reader.Name != "ID" && reader.Read()) { }
                        reader.Read();
                        strat2 = projection.Strategies.Where(x => x.ID == reader.Value).First();
                        bRetVal &= strat2 != null;

                        // Create the plan and save it off
                        fundPlan = new Plan(planId2, amount2, strat2);
                    }
                    

                    // Get the 'fund'
                    // Use a dummy fund for now
                    Fund dummyFund = null;
                    while (reader.Name != "Fund" && reader.Read()) { }
                    // Get the fund ID attribute
                    reader.MoveToFirstAttribute();

                    // Parent, rigid, and balance will be determined later.
                    dummyFund = new Fund(reader.Value, 0);
                   

                    bRetVal &= dummyFund != null && fundPlan != null;

                    // add the allocation
                    if (bRetVal)
                    {
                        createdBudget.AllocateFunds(dummyFund, fundPlan);
                    }
                    
                }
            }
            #endregion Fund Allocations

            budget = createdBudget;
            return bRetVal;
        }

        // Parent References have to be added later.
        public bool CreateFund(XmlReader reader, Projection projection, out Fund fund)
        {
            bool bRetVal = true;

            // Move to "fund" element
            while (reader.Name != "Fund" && reader.Read()) { }

            // Move to the id attribute
            string name;
            reader.MoveToFirstAttribute();
            name = reader.Value;

            bool rigid;
            reader.MoveToNextAttribute();
            rigid = reader.Value == "True";

            Fund parent;
            while (reader.Name != "Parent" && reader.Read()) { }
            reader.Read();

            // Get the parent name. Later use it to search for a reference.
            string parentName = reader.Value;

            // Create a dummy parent for now. This will later be replaced.
            parent = new Fund(parentName, 0);

            float balance;
            while (reader.Name != "Balance" && reader.Read()) { }
            reader.Read();
            bRetVal &= float.TryParse(reader.Value, out balance);

            fund = new Fund(name, parent, balance, rigid);
            return bRetVal;
        }

        public bool CreateLoan(XmlReader reader, Projection projection, out Loan loan)
        {
            bool bRetVal = true;

            while (reader.Name != "Loan" && reader.Read()) { }

            // Move to the id attribute
            string name;
            reader.MoveToFirstAttribute();
            name = reader.Value;


            float balance;
            while (reader.Name != "Balance" && reader.Read()) { }
            reader.Read();
            bRetVal &= float.TryParse(reader.Value, out balance);

            // Move to the Interest Plan
            while (reader.Name != "InterestPlan" && reader.Read()) { }

            // Move to the Interest Plan Plan
            while (reader.Name != "Plan" && reader.Read()) { }

            Plan iPlan = null;
            if (reader.NodeType == XmlNodeType.Element && reader.Name == "Plan")
            {
                // Get the id attribute
                string planId;
                reader.MoveToFirstAttribute();
                planId = reader.Value;

                // Move to the plan amount
                float amount;
                while (reader.Name != "Amount" && reader.Read()) { }
                reader.Read();
                bRetVal &= float.TryParse(reader.Value, out amount);

                // Get the strategy name, look it up, then save the reference.
                DateStrategy strat;
                while (reader.Name != "ID" && reader.Read()) { }
                reader.Read();
                strat = projection.Strategies.Where(x => x.ID == reader.Value).First();
                bRetVal &= strat != null;

                // Create the plan and save it off
                iPlan = new Plan(planId, amount, strat);
            }

            // Move to the Payment Plan
            while (reader.Name != "PaymentPlan" && reader.Read()) { }

            // Move to the Payment Plan Plan
            while (reader.Name != "Plan" && reader.Read()) { }

            FundedPlan pPlan = null;
            if (reader.NodeType == XmlNodeType.Element && reader.Name == "Plan")
            {
                // Get the id attribute
                string planId2;
                reader.MoveToFirstAttribute();
                planId2 = reader.Value;

                // Move to the plan amount
                float amount2;
                while (reader.Name != "Amount" && reader.Read()) { }
                reader.Read();
                bRetVal &= float.TryParse(reader.Value, out amount2);

                // Get the strategy name, look it up, then save the reference.
                DateStrategy strat2;
                while (reader.Name != "ID" && reader.Read()) { }
                reader.Read();
                strat2 = projection.Strategies.Where(x => x.ID == reader.Value).First();
                bRetVal &= strat2 != null;

                // This is a funded plan, we still need the fund
                Fund fund2;
                while (reader.Name != "Fund" && reader.Read()) { }

                // Move to the name attribute
                reader.MoveToFirstAttribute();

                // Look it up
                fund2 = projection.Funds.Where(x => x.Name == reader.Value).First();
                bRetVal &= fund2 != null;

                // Create and save the plan
                pPlan = new FundedPlan(planId2 ,amount2, strat2, fund2);
            }

            loan = new Loan(name, balance, iPlan, pPlan);

            return bRetVal;
        }

        // Reader must be before on SLA
        public bool CreateSLA(XmlReader reader, Projection projection, out SelectiveLoanAgreement sla)
        {
            bool bRetVal = true;

            // Move to the start of the SLA
            while (reader.Name != "SLA" && reader.Read()) { }

            // Move to the id attribute
            string name;
            reader.MoveToFirstAttribute();
            name = reader.Value;

            // Move to the loanset
            // Get the plans ---
            // Move to the "Deltas" list
            while (reader.Name != "LoanSet" && reader.Read()) { }

            // Continue until we've reached the end of the loanset
            // Move past the start element
            reader.Read();
            List<Loan> loanSet = new List<Loan>();
            while (reader.Name != "LoanSet" && reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Loan")
                {
                    // Get the id attribute
                    string loanName;
                    reader.MoveToFirstAttribute();
                    loanName = reader.Value;


                    Loan addLoan = projection.Loans.Where(x => x.Name == loanName).First();
                    bRetVal &= addLoan != null;
                    loanSet.Add(
                        addLoan
                        );
                }
            }

            while (reader.Name != "Strategy" && reader.Read()) { }

            // Move to the stategy
            // Get the id attribute
            string stratName;
            reader.MoveToFirstAttribute();
            stratName = reader.Value;

            DateStrategy foundStrat = projection.Strategies.Where(x => x.ID == stratName).First();
            bRetVal &= foundStrat != null;

            while (reader.Name != "Fund" && reader.Read()) { }

            // Move to the stategy
            // Get the id attribute
            string fundName;
            reader.MoveToFirstAttribute();
            fundName = reader.Value;

            Fund foundFund = projection.Funds.Where(x => x.Name == fundName).First();
            bRetVal &= foundFund != null;

            sla = new SelectiveLoanAgreement(name, foundStrat, foundFund);
            foreach (Loan loan in loanSet)
            {
                sla.AddLoanOption(loan);
            }
            
            return bRetVal;
        }
    }
}
