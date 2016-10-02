using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Xml;
using BudgetProjectionProject;
using BudgetProjectionProject.Budgets;
using BudgetProjectionProject.Loans;
using BudgetProjectionProject.Core;
using BudgetProjectionProject.DateStrategies;

namespace BudgetProjectionProject.Forms
{
    public partial class frmMain : Form
    {
        private BudgetProjectionProgram Program;
        private int m_CurrentMonthView = 0;

        public frmMain()
        {
            InitializeComponent();
            Program = new BudgetProjectionProgram();
            Refresh_All_S();
        }
        
        private void Refresh_All_S()
        {
            RefreshDeltasView_S();
            RefreshLoansView_S();
            NUDSavings.Value = (decimal)Program.ActiveProjection.Budget.Balance;
        }

        private void RefreshDeltasView_S()
        {
            this.LBDeltas.Items.Clear();
            foreach (Plan delta in Program.ActiveProjection.Budget.Deltas)
            {
                this.LBDeltas.Items.Add(delta.ID);
            }
            if (Program.ActiveProjection.Budget.Deltas.Count <= 0)
            {
                this.BtnRemoveDelta.Enabled = false;
            }
            else
            {
                this.BtnRemoveDelta.Enabled = true;
            }
            this.Refresh();
        }

        private void RefreshLoansView_S()
        {
            this.LBLoans.Items.Clear();
            foreach (Loan loan in Program.ActiveProjection.Loans)
            {
                this.LBLoans.Items.Add(loan.Name);
            }
            if (Program.ActiveProjection.Loans.Count <= 0)
            {
                this.BtnRemoveLoan.Enabled = false;
            }
            else
            {
                this.BtnRemoveLoan.Enabled = true;
            }
            this.Refresh();
        }

        private void LBDeltas_DrawItem(object sender, DrawItemEventArgs e)
        {
            /*
            e.DrawBackground();
            e.Graphics.DrawString(
                this.LBDeltas.Items[e.Index].ToString(),
                new Font("Arial", 10, FontStyle.Bold),
                Brushes.Green,
                e.Bounds);
            e.DrawFocusRectangle();
            */
        }

        private void strategiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStrategies StrategyForm = new frmStrategies(Program.ActiveProjection);
            StrategyForm.ToggleOK();
            StrategyForm.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            XmlWriter SaveWriter; 

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "All files (*.*)|*.*| pjx files(*.pjx) | *.pjx";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((SaveWriter = XmlWriter.Create(saveFileDialog1.OpenFile(), settings)) != null)
                {
                    // Code to write the stream goes here.
                    Program.SaveProjection_S(SaveWriter);
                }
            }
            
        }

        private void plansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPlans PlanForm = new frmPlans(Program.ActiveProjection);
            PlanForm.ToggleOK();
            PlanForm.ShowDialog();
            RefreshDeltasView_S();
        }

        private void loansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoans LoanForm = new frmLoans(Program.ActiveProjection);
            LoanForm.ToggleOK();
            LoanForm.ShowDialog();
            RefreshLoansView_S();
        }

        private void NUDSavings_ValueChanged(object sender, EventArgs e)
        {
            Program.ActiveProjection.Budget.Balance = (float) NUDSavings.Value;
        }

        private void BtnAddIncome_Click(object sender, EventArgs e)
        {
            frmNewDelta newDeltaForm = new frmNewDelta(Program.ActiveProjection, "Add Income Form");
            newDeltaForm.ShowDialog();
            if (newDeltaForm.DialogResult == DialogResult.OK)
            {
                Program.ActiveProjection.Budget.AddDelta(newDeltaForm.CreatedDelta);
                RefreshDeltasView_S();
            }
        }

        private void BtnAddExpense_Click(object sender, EventArgs e)
        {
            frmNewDelta newDeltaForm = new frmNewDelta(Program.ActiveProjection, "Add Expense Form");
            newDeltaForm.ShowDialog();
            if (newDeltaForm.DialogResult == DialogResult.OK)
            {
                newDeltaForm.CreatedDelta.Amount = -newDeltaForm.CreatedDelta.Amount;
                Program.ActiveProjection.Budget.AddDelta(newDeltaForm.CreatedDelta);
                RefreshDeltasView_S();
            }
        }

        private void BtnAddLoan_Click(object sender, EventArgs e)
        {
            frmLoans loanForm = new frmLoans(Program.ActiveProjection);
            loanForm.ShowDialog();
            if (loanForm.DialogResult == DialogResult.OK)
            {
                Program.ActiveProjection.SelectedLoans.Add(loanForm.SelectedLoan);
            }
            RefreshLoansView_S();

        }

        private void BtnRun_Click(object sender, EventArgs e)
        {
            Program.ActiveProjection.LockInitialConditions();
            TBSimulationDetails.Text = "";
            InfoTracker IT = new InfoTracker("IT1", Program.ActiveProjection);
            bool bLoanB = false;
            foreach (Loan loan in Program.ActiveProjection.Loans)
            {
                bLoanB |= loan.Principal > .001;
            }
            int i = 0;
            while ((bLoanB || !(XDayOfMonth.GetDayOfMonth(i) == 0)) && i < 2000)
            {
                IT.Open_Track(i);
                string debug = Program.ActiveProjection.Step();
                if (debug.Trim() != "")
                {
                    string output = "Day " +
                    Program.ActiveProjection.DayIndex.ToString() +
                    ": " +
                    debug +
                    "\n";
                    foreach (string line in output.Split('\n'))
                    {
                        if (line != "")
                        {
                            this.TBSimulationDetails.AppendText(line);
                            this.TBSimulationDetails.AppendText(Environment.NewLine);
                        }
                    }
                    this.TBSimulationDetails.AppendText(Environment.NewLine);
                    IT.Track(i, output);
                }
                bLoanB = false;
                foreach (Loan loan in Program.ActiveProjection.Loans)
                {
                    bLoanB |= loan.Principal > .001;
                }
                IT.Close_Track(i++, !bLoanB && (XDayOfMonth.GetDayOfMonth(i) == 0));
            }
            Program.ActiveProjection.StoreLastProjection(IT);
            Program.ActiveProjection.ResetIC();
        }

        private void TBCMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.TBCDetails.SelectedTab.Name == "TbPageMonth")
            {
                this.BtnBack.Enabled = true;
                this.BtnForward.Enabled = true;

                string view = Program.ActiveProjection.GetMonth(m_CurrentMonthView);
                if (view == "")
                {
                    m_CurrentMonthView = 0;
                    view = Program.ActiveProjection.GetMonth(m_CurrentMonthView);
                }
                this.TBMonthDetails.Text = view;

            }
            else
            {
                this.BtnForward.Enabled = false;
                this.BtnBack.Enabled = false;
            }
        }

        private void LBDeltas_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.TBSelectionDetails.Text = "";
            if (this.LBDeltas.SelectedIndex > -1)
            {

                string txtApp = Program.ActiveProjection.Budget.Deltas[
                                        this.LBDeltas.SelectedIndex
                                        ].GetReadable().Replace("\n", Environment.NewLine);
                this.TBSelectionDetails.AppendText(
                                    txtApp
                                   );
            }
            
        }

        private void LBLoans_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.TBSelectionDetails.Text = "";
                /*
                this.TBSelectionDetails.AppendText(
                    Program.ActiveProjection.SelectedLoans[
                        this.LBLoans.SelectedIndex
                        ]
                   .GetXMLSave());
                   */
                //XmlReaderSettings settings = new XmlReaderSettings();
                this.TBSelectionDetails.AppendText(
                    Program.ActiveProjection.Loans[
                        this.LBLoans.SelectedIndex
                        ]
                   .GetReadable().Replace("\n", Environment.NewLine)
                    );

            }
            catch
            {

            }
        }

        private void BtnRemoveLoan_Click(object sender, EventArgs e)
        {
            Program.ActiveProjection.SelectedLoans.Remove(
                Program.ActiveProjection.SelectedLoans[
                    this.LBLoans.SelectedIndex
                    ]
                );
            RefreshLoansView_S();
            
        }

        private void BtnRemoveDelta_Click(object sender, EventArgs e)
        {
            try
            {
                Program.ActiveProjection.DeleteDelta(Program.ActiveProjection.Budget.Deltas[
                                   this.LBDeltas.SelectedIndex
                                   ]);
                RefreshDeltasView_S();
            }
            catch
            {

            }
            
        }

        private void BtnBudgetSettings_Click(object sender, EventArgs e)
        {
            frmAdvBudget budgetForm = new frmAdvBudget(Program.ActiveProjection);
            budgetForm.ShowDialog();
            NUDSavings.Value = (decimal)Program.ActiveProjection.Budget.Balance;
            Refresh_All_S();
        }

        private void BtnSLA_Click(object sender, EventArgs e)
        {
            frmSLAs slaForm = new frmSLAs(Program.ActiveProjection);
            slaForm.ShowDialog();
            Refresh_All_S();
        }

        private void BtnForward_Click(object sender, EventArgs e)
        {
            string view = Program.ActiveProjection.GetMonth(++m_CurrentMonthView);
            if (view == "")
            {
                m_CurrentMonthView--;
                view = Program.ActiveProjection.GetMonth(m_CurrentMonthView);
            }
            this.TBMonthDetails.Text = view;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {

            string view = Program.ActiveProjection.GetMonth(--m_CurrentMonthView);
            if (view == "")
            {
                m_CurrentMonthView = 0;
                view = Program.ActiveProjection.GetMonth(m_CurrentMonthView);
            }
            this.TBMonthDetails.Text = view;
        }

        private void loadProjectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;

                if (file.Length < 4 || (file.Length > 3 && file.Substring(file.Length - 4) != ".pjx"))
                {
                    MessageBox.Show("Invalid File Type.");
                    return;
                }

                if (!Program.LoadProjection_S(file))
                {
                    MessageBox.Show("Could not load file.");
                }
            }
            
            Refresh_All_S();
        }

        private void saveSimulationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "All files (*.*)|*.*|txt files (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter SaveWriter = new StreamWriter(saveFileDialog1.FileName);
                if ((SaveWriter) != null)
                {

                    // Code to write the stream goes here.
                    string view = Program.ActiveProjection.GetMonth(0);
                    string output = "";
                    int i = 0;
                    while (view != "")
                    {
                        SaveWriter.Write(view);
                        SaveWriter.Write("=================================================");
                        SaveWriter.Flush();
                        view = Program.ActiveProjection.GetMonth(++i);
                        output += view;
                    }
                    SaveWriter.Close();
                }
            }
            
        }

        private void projectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Unsaved data will be lost. Are you sure?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Program.ActiveProjection = new Projection();
                Refresh_All_S();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }
    }
}
