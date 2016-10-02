using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using BudgetProjectionProject.Budgets;
using BudgetProjectionProject.DateStrategies;
using BudgetProjectionProject.Forms;
using BudgetProjectionProject.Loans;
using BudgetProjectionProject.Core;

namespace BudgetProjectionProject
{
    public class Projection : IInitialConditions
    {
        public List<Loan> Loans;

        // Depracated
        public List<Loan> SelectedLoans;

        public List<Fund> Funds;

        public List<SelectiveLoanAgreement> SLAs;

        public List<DateStrategy> Strategies;

        public Budget Budget;

        public int DayIndex;
        public List<string> LastProjection;

        public Projection()
        {
            Budget = new Budget("Main", 0);
            SelectedLoans = new List<Loan>();
            Funds = new List<Fund>();
            Loans = new List<Loan>();
            LastProjection = new List<string>();
            SLAs = new List<SelectiveLoanAgreement>();
            Strategies = new List<DateStrategy>();
            DayIndex = 0;
        }

        public void StoreLastProjection(InfoTracker it)
        {
            LastProjection = new List<string>();
            for (int i = 0; i< it.NumMonths; i++)
            {
                LastProjection.Add(it.GetMonth(i));
            }
        }

        public string GetMonth(int month)
        {
            if (LastProjection.Count > 0 && month < LastProjection.Count && month >= 0)
            {
                return LastProjection[month];
            }
            else
            {
                return "";
            }
        }

        public void LockInitialConditions()
        {
            foreach (Loan loan in Loans)
            {
                loan.LockInitialConditions();
            }
            foreach (SelectiveLoanAgreement sla in SLAs)
            {
                sla.LockInitialConditions();
            }
            Budget.LockInitialConditions();
        }

        public void ResetIC()
        {
            DayIndex = 0;
            foreach(Loan loan in Loans)
            {
                loan.ResetIC();
            }
            foreach (SelectiveLoanAgreement sla in SLAs)
            {
                sla.ResetIC();
            }
            foreach(Fund fund in Funds)
            {
                fund.ResetIC();
            }
            Budget.ResetIC();
        }

        public string Step()
        {
            //Console.WriteLine(i);
            string szRetVal = "";
            foreach (DateStrategy date in Strategies)
            {
                if (date.IsNow(DayIndex))
                {
                    szRetVal += date.NotifyObservers();
                }
            }
            foreach(Loan loan in Loans)
            {
                szRetVal += loan.CommitPayment();
            }
            DayIndex++;
            return szRetVal;
        }

        public void DeleteLoan(Loan loan)
        {
            // Free the loan from any references under it
            loan.Free();


            // Free the loan from SLA references
            // Forget the SLA
            foreach(SelectiveLoanAgreement sla in SLAs)
            {
                sla.LoanSet.Remove(loan);
                if (sla.LoanSet.Count <= 0)
                {
                    // TODO delete the SLA
                }
            }

            // Remove Stored references.
            Loans.Remove(loan);
            SelectedLoans.Remove(loan);
        }

        public void ReplaceLoan(Loan oldLoan, Loan newLoan)
        {
            // Free the loan from any references under it

            oldLoan.Free(true);


            // Free the loan from SLA references
            // Forget the SLA
            foreach (SelectiveLoanAgreement sla in SLAs)
            {
                sla.LoanSet.Remove(oldLoan);
                sla.AddLoanOption(newLoan);
            }

            // Remove Stored references.
            
            Loans.Remove(oldLoan);
            SelectedLoans.Remove(oldLoan);
            Loans.Add(newLoan);
        }

        public void DeleteSLA(SelectiveLoanAgreement SLA)
        {
            SLA.Free();
            SLAs.Remove(SLA);
        }

        /// <summary>
        /// Search through loans, and SLAs to find dependencies.
        /// </summary>
        /// <param name="fund"></param>
        public void DeleteFund(Fund fund)
        {
            List<SelectiveLoanAgreement> DependentSLAs = new List<SelectiveLoanAgreement>();
            foreach (SelectiveLoanAgreement sla in SLAs)
            {
                if (fund == sla.Source)
                {
                    DependentSLAs.Add(sla);
                }
            }

            List<Loan> DependentLoans = new List<Loan>();
            foreach(Loan loan in Loans)
            {
                if (fund == loan.MinimumPaymentPlan.Source)
                {
                    DependentLoans.Add(loan);
                }
            }

            List<Fund> AllocatedFunds = new List<Fund>();
            foreach (Fund f in Budget.BudgetMap.Keys)
            {
                if (f == fund)
                {
                    AllocatedFunds.Add(f);
                }
            }
            

            string warning = "WARNING: This action will also delete ";
            if (DependentLoans.Count > 0)
            {
                foreach(Loan loan in DependentLoans)
                {
                    warning +=  loan.Name + ", ";
                }
            }
            if (DependentSLAs.Count > 0)
            {
                foreach(SelectiveLoanAgreement sla in DependentSLAs)
                {
                    warning += sla.ID + ", ";
                }
            }

            warning += "are you sure?";
            ConfirmationForm confirmationForm = new ConfirmationForm(warning);
            confirmationForm.ShowDialog();
            if (confirmationForm.DialogResult == DialogResult.OK)
            {


                // DeAllocate
                foreach (Fund f in AllocatedFunds)
                {
                    Budget.DeAllocateFund(f);
                }

                // Delete the dependent loans
                foreach (Loan loan in DependentLoans)
                {
                    DeleteLoan(loan);
                }

                // Delete dependent slas
                foreach (SelectiveLoanAgreement sla in DependentSLAs)
                {
                    DeleteSLA(sla);
                }

                fund.Parent.Children.Remove(fund);
                Funds.Remove(fund);
            }
        }

        public void ReplaceFund(Fund outFund, Fund inFund)
        {
            List<SelectiveLoanAgreement> DependentSLAs = new List<SelectiveLoanAgreement>();
            foreach (SelectiveLoanAgreement sla in SLAs)
            {
                if (outFund == sla.Source)
                {
                    DependentSLAs.Add(sla);
                }
            }

            List<Loan> DependentLoans = new List<Loan>();
            foreach (Loan loan in Loans)
            {
                if (outFund == loan.MinimumPaymentPlan.Source)
                {
                    DependentLoans.Add(loan);
                }
            }

            List<Fund> AllocatedFunds = new List<Fund>();
            foreach (Fund f in Budget.BudgetMap.Keys)
            {
                if (f == outFund)
                {
                    AllocatedFunds.Add(f);
                }
            }



            // DeAllocate
            foreach (Fund f in AllocatedFunds)
            {
                Budget.ReplaceAllocatedFund(f, inFund);
            }
            

            // Delete the dependent loans
            foreach (Loan loan in DependentLoans)
            {
                loan.MinimumPaymentPlan.Source = inFund;
            }

            // Delete dependent slas
            foreach (SelectiveLoanAgreement sla in DependentSLAs)
            {
                sla.Source = inFund;
            }

            outFund.Parent.Children.Remove(outFund);
            Funds.Remove(outFund);
            Funds.Add(inFund);
            
        }

        /// <summary>
        /// Delete from budget too
        /// </summary>
        /// <param name="plan"></param>
        public void DeleteDelta(Plan plan)
        {
            // Plans should only ever have one observer. So I don't have to worry about much.
            List<Loan> DependentLoans = new List<Loan>();
            foreach (Loan loan in Loans)
            {
                if (loan.MinimumPaymentPlan == plan || loan.InterestPlan == plan)
                {
                    DependentLoans.Add(loan);
                }
            }

            // Find all deltas to remove
            List<Plan> RemoveDeltas = new List<Plan>();
            foreach(Plan delta in Budget.Deltas)
            {
                if (delta == plan)
                {
                    RemoveDeltas.Add(delta);
                }
            }

            // Delete the loans.
            foreach(Loan loan in DependentLoans)
            {
                DeleteLoan(loan);
            }

            // Remove all the deltas
            foreach(Plan delta in RemoveDeltas)
            {
                delta.Free();
                Budget.Deltas.Remove(delta);
            }
        }

        /// <summary>
        /// Search through plans (then their dependencies -> BudgetAlloc, Loans, SLAs)
        /// </summary>
        /// <param name="strat"></param>
        public void DeleteStrategy(DateStrategy strat)
        {
            if (strat.ObserverCount() > 0)
            {
                string warning = "This Strategy has observers. Action cannot be performed.";
                ConfirmationForm confirmationForm = new ConfirmationForm(warning);
                confirmationForm.ShowDialog();
            }
            else
            {
                this.Strategies.Remove(strat);
            }
        }

    }
}
