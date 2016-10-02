using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Threading.Tasks;
using System.Windows.Forms;
using BudgetProjectionProject;
using BudgetProjectionProject.Loans;
using BudgetProjectionProject.Budgets;
using BudgetProjectionProject.DateStrategies;
using BudgetProjectionProject.Core;

namespace BudgetProjectionProject
{
    class BudgetProjectionProgram
    {
        public Projection ActiveProjection;

        public BudgetProjectionProgram()
        {
            NewProjection_S();
        }
        
        public void NewProjection_S()
        {
            ActiveProjection = new Projection();
            /*
            float noycePrePay = 5500;
            ActiveProjection.Budget.Balance = 7000 + 5000 - noycePrePay;
            XDayOfMonth dm = new XDayOfMonth(1,"FirstDay");
            ActiveProjection.Strategies.Add(dm);
            DateStrategy Monthly = new XDayOfMonth(1, "Monthly");
            DateStrategy Monthly2 = new XDayOfMonth(2, "Monthly2");
            DateStrategy Biweekly = new XDays(14, "Biweekly");
            DateStrategy Daily = new XDays(1, "EveryDay");

            ActiveProjection.Strategies.Add(Monthly);
            ActiveProjection.Strategies.Add(Monthly2);
            ActiveProjection.Strategies.Add(Biweekly);
            ActiveProjection.Strategies.Add(Daily);

            Plan income = new Plan("Boeing", 1186, Biweekly);
            Plan rent = new Plan("Rent", -1145, Monthly);

            ActiveProjection.Budget.AddDelta(income);
            ActiveProjection.Budget.AddDelta(rent);

            Fund LoanFund = new Fund("Loan Fund", ActiveProjection.Budget, 1150, false);
            ActiveProjection.Funds.Add(LoanFund);
            Plan LoanPlan = new Plan("LFPlan",1150, Monthly);
            ActiveProjection.Budget.AllocateFunds(LoanFund, LoanPlan);

            Plan interestPlan = new Plan("IPlanNoyce", .05f, Monthly2);
            FundedPlan paymentPlan = new FundedPlan("PayPlan", 450, Monthly2, LoanFund);
            Loan Noyce = new Loan("Noyce", 33398.66f - noycePrePay, interestPlan, paymentPlan);
            ActiveProjection.Loans.Add(Noyce);

            Plan interestPlan2 = new Plan("IPlanSmallUnSub", .068f, Daily);
            FundedPlan paymentPlan2 = new FundedPlan("PayPlanUnSubSmall", 50, Monthly2, LoanFund);
            Loan Other = new Loan("UnSubSmall", 4159.88f, interestPlan2, paymentPlan2);
            ActiveProjection.Loans.Add(Other);

            Plan interestPlan3 = new Plan("IPlanUnSubLarge", .0386f, Daily);
            FundedPlan paymentPlan3 = new FundedPlan("PayPlanUnSubLarge", 50, Monthly2, LoanFund);
            Loan UnSubLarge = new Loan("UnSubLarge", 7207.13f, interestPlan3, paymentPlan3);
            ActiveProjection.Loans.Add(UnSubLarge);

            Plan interestPlan4 = new Plan("IPlanUnSubLarge", .034f, Daily);
            FundedPlan paymentPlan4 = new FundedPlan("PayPlanSubsidized", 50, Monthly2, LoanFund);
            Loan Sub = new Loan("Subsidized", 2218.68f, interestPlan4, paymentPlan4);
            ActiveProjection.Loans.Add(Sub);

            ActiveProjection.SelectedLoans.Add(Other);
            ActiveProjection.SelectedLoans.Add(Noyce);
            ActiveProjection.SelectedLoans.Add(UnSubLarge);
            ActiveProjection.SelectedLoans.Add(Sub);

            SelectiveLoanAgreement SLA = new SelectiveLoanAgreement("SLA", Monthly, LoanFund);
            SLA.AddLoanOption(Noyce);
            SLA.AddLoanOption(Other);
            SLA.AddLoanOption(UnSubLarge);
            SLA.AddLoanOption(Sub);
            ActiveProjection.SLAs.Add(SLA);
            */
        }

        public bool LoadProjection_S(string file)
        {
            bool success = true;
            
            Projection LoadedProjection = new Projection();
            XmlLoadFactory xLoader = new XmlLoadFactory();
            XmlReaderSettings settings = new XmlReaderSettings();
            using (XmlReader reader = XmlReader.Create(file, settings))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        string objectType = reader.Name;
                        
                        if (objectType == "Strategies")
                        {
                            #region Strategies
                            // Move past the start element.
                            reader.Read();
                            while (reader.Name != "Strategies" && reader.Read())
                            {
                                if (reader.Name == "Strategy")
                                {
                                    if (reader.MoveToFirstAttribute())
                                    {
                                        if (reader.Value == "XDayOfMonth")
                                        {
                                            XDayOfMonth xdays;
                                            if (success &= xLoader.CreateDayOfMonth(reader, out xdays)){
                                                LoadedProjection.Strategies.Add(
                                                    xdays
                                                );
                                            }
                                        }
                                        else if (reader.Value == "XDays")
                                        {
                                            XDays xdays;
                                            if (success &= xLoader.CreateXDays(reader, out xdays)){
                                                LoadedProjection.Strategies.Add(
                                                    xdays
                                                );
                                            }
                                            
                                        }

                                    }
                                }
                            }
                            #endregion Strategies
                        }
                        else if (objectType == "Budget")
                        {
                            #region Budget
                            Budget budget;
                            if (xLoader.CreateBudget(reader, LoadedProjection, out budget))
                            {
                                LoadedProjection.Budget = budget;
                            }
                            #endregion Budget;
                        }
                        else if (objectType == "Funds")
                        {
                            // Hard
                            #region Funds
                            // Create the funds and update the budget funds
                            // Associate parent and children here - hard part.
                            reader.Read();
                            while (reader.Name != "Funds" && reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Fund")
                                {
                                    Fund newFund;
                                    if (success &= xLoader.CreateFund(reader, LoadedProjection, out newFund))
                                    {
                                        LoadedProjection.Funds.Add(newFund);
                                    }
                                }
                            }

                            #region Parent Children Pairing
                            // Once all the funds are created, loop through and pair the parents and children.
                            foreach (Fund fund in LoadedProjection.Funds)
                            {
                                // Foreach fund, loop through the budget and the other funds to check
                                if (fund.Parent.Name == LoadedProjection.Budget.Name)
                                {
                                    // Remove the placeholder
                                    LoadedProjection.Budget.Children.Remove(
                                        LoadedProjection.Budget.Children.Where(x => x.Name == fund.Name).First());

                                    // Add the full fund.
                                    fund.SetParent(LoadedProjection.Budget);
                                }
                                else
                                {
                                    foreach (Fund otherFund in LoadedProjection.Funds)
                                    {
                                        if (fund != otherFund)
                                        {
                                            if (fund.Parent.Name == otherFund.Name)
                                            {
                                                otherFund.Children.Remove(
                                                    otherFund.Children.Where(x => x.Name == fund.Name).First()
                                                    );
                                                fund.SetParent(otherFund);
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            #endregion Parent Children

                            #region Fund allocation pairing
                            // Replace the allocation pairings with the real references.
                            Dictionary<Fund, Plan> PlanFundPairs = new Dictionary<Fund, Plan>();
                            foreach (string key in LoadedProjection.Budget.Budgets.Keys)
                            {
                                Plan savePlan = LoadedProjection.Budget.BudgetMap[
                                    LoadedProjection.Budget.Budgets[key]
                                    ];
                                Fund replaceFund = LoadedProjection.Budget.Budgets[key];
                                Fund saveFund = LoadedProjection.Funds.Where(x => x.Name == replaceFund.Name).First();
                                PlanFundPairs.Add(saveFund, savePlan);
                            }

                            foreach (Fund fund in PlanFundPairs.Keys)
                            {
                                
                                LoadedProjection.Budget.DeAllocateFund(
                                    LoadedProjection.Budget.Budgets[PlanFundPairs[fund].ID]
                                    );
                                LoadedProjection.Budget.AllocateFunds(fund, PlanFundPairs[fund]);
                            }
                            #endregion FAP

                            #endregion Funds
                        }
                        else if (objectType == "Loans")
                        {
                            // Easy
                            #region Loans
                            // Use the projection in its current state to look up object references
                            reader.Read();
                            while (reader.Name != "Loans" && reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Loan")
                                {
                                    Loan newLoan;
                                    if (success &= xLoader.CreateLoan(reader, LoadedProjection, out newLoan))
                                    {
                                        LoadedProjection.Loans.Add(newLoan);
                                    }
                                }
                            }
                            #endregion loans
                        }
                        else if (objectType == "SLAs")
                        {
                            // Easy
                            #region slas
                            // Create the SLAs
                            // Use the projection in its current state to look up object references
                            reader.Read();
                            while (reader.Name != "SLAs" && reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Element && reader.Name == "SLA")
                                {
                                    SelectiveLoanAgreement newSLA;
                                    if (success &= xLoader.CreateSLA(reader, LoadedProjection, out newSLA))
                                    {
                                        LoadedProjection.SLAs.Add(newSLA);
                                    }
                                }
                            }
                            #endregion slas
                        }

                    }

                }
            } // end using

            if (success)
            {
                // Make all the loans selected
                foreach(Loan loan in LoadedProjection.Loans)
                {
                    LoadedProjection.SelectedLoans.Add(loan);
                }
                ActiveProjection = LoadedProjection;
            }

            return success;
        }

        public void SaveProjection_S(XmlWriter SaveWriter)
        {
            // Write all the data needed to a stream as best as possible.
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            //XmlWriter SaveWriter = XmlWriter.Create(path, settings);

            SaveWriter.WriteStartDocument();
            SaveWriter.WriteStartElement("Projection");
            SaveWriter.WriteStartElement("Strategies");
            foreach (DateStrategy strat in ActiveProjection.Strategies)
            {
                strat.GetXMLSave(SaveWriter);
            }
            SaveWriter.WriteEndElement();
            SaveWriter.WriteStartElement("Budget");
            ActiveProjection.Budget.GetXMLSave(SaveWriter);
            SaveWriter.WriteEndElement();
            SaveWriter.WriteStartElement("Funds");
            foreach (Fund fund in ActiveProjection.Funds)
            {
                fund.GetXMLSave(SaveWriter);
            }
            SaveWriter.WriteEndElement();
            SaveWriter.WriteStartElement("Loans");
            foreach(Loan loan in ActiveProjection.Loans)
            {
                loan.GetXMLSave(SaveWriter);
            }
            SaveWriter.WriteEndElement();
            SaveWriter.WriteStartElement("SLAs");
            foreach(SelectiveLoanAgreement sla in ActiveProjection.SLAs)
            {
                sla.GetXMLSave(SaveWriter);
            }
            SaveWriter.WriteEndElement();
            SaveWriter.WriteEndElement();
            SaveWriter.WriteEndDocument();
            SaveWriter.Close();
        }

    }
}
