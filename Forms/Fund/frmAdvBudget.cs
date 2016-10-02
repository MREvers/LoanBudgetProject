using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BudgetProjectionProject.Budgets;

namespace BudgetProjectionProject.Forms
{
    public partial class frmAdvBudget : Form
    {
        public Projection ActiveProjection;
        public Budget Budget;

        private Fund m_SelectedFund;

        public frmAdvBudget(Projection ap)
        {
            InitializeComponent();
            ActiveProjection = ap;
            Budget = ap.Budget;
            m_SelectedFund = null;
            this.TBName.Text = Budget.Name;
            this.NUDSavings.Value = (decimal) Budget.Balance;

            RefreshAll_S();
        }

        private void RefreshAll_S()
        {
            RefreshAddPlanBtn_S();

            RefreshDeltaButtons_S();
            RefreshDeltasView_S();

            RefreshFundButtons_S();
            RefreshFundsView_S();
        }

        private void RefreshSelectedFundView_S()
        {
            if (this.LBFunds.SelectedIndex < 0 )
                return;
            if (!(this.LBFunds.SelectedIndex >= this.ActiveProjection.Funds.Count))
            {
                this.m_SelectedFund = this.ActiveProjection
                    .Funds[this.LBFunds.SelectedIndex];
            }
            
            
            //this.ActiveProjection.Budget
            //    .Budgets.Where(x => x.Value == m_SelectedFund).First()
            //    .Value.Balance.ToString()
            try
            {
                this.TBAllocationAmt.Text = Budget.BudgetMap[m_SelectedFund].Amount.ToString();
                this.TBStrategy.Text = Budget.BudgetMap[m_SelectedFund].Strategy.Debug();
                this.BtnDeAllocate.Enabled = true;
                
                
            }
            catch
            {
                this.TBAllocationAmt.Text = "";
                this.TBStrategy.Text = "";
                RefreshAddPlanBtn_S();
                this.BtnDeAllocate.Enabled = false;
                this.TBFundName.Text = "";
                this.TBSelectedFundIsRigid.Text = "";
            }

            this.TBFundName.Text = m_SelectedFund.Name;
            this.TBSelectedFundIsRigid.Text = m_SelectedFund.Rigid.ToString();
        }

        private void RefreshAddPlanBtn_S()
        {
            this.BtnCreatePlan.Enabled = this.m_SelectedFund != null;
        }

        private void RefreshFundsView_S()
        {
            this.LBFunds.Items.Clear();
            foreach (Fund fund in ActiveProjection.Funds)
            {
                this.LBFunds.Items.Add(fund.Name);
            }
            
            RefreshFundButtons_S();
            this.Refresh();
        }

        private void RefreshFundButtons_S()
        {
            if (ActiveProjection.Budget.Budgets.Count <= 0)
            {
                this.BtnRemoveFund.Enabled = false;
                this.BtnEditFund.Enabled = false;
            }
            else
            {
                this.BtnRemoveFund.Enabled = true;
                this.BtnEditFund.Enabled = true;
            }
        }

        private void RefreshDeltasView_S()
        {
            this.LBDeltas.Items.Clear();
            foreach (Plan delta in ActiveProjection.Budget.Deltas)
            {
                this.LBDeltas.Items.Add(delta.ID);
            }
            RefreshDeltaButtons_S();
            this.Refresh();
        }


        private void RefreshDeltaButtons_S()
        {
            if (ActiveProjection.Budget.Deltas.Count <= 0)
            {
                this.BtnRemoveDelta.Enabled = false;
                this.BtnEditDelta.Enabled = false;
            }
            else
            {
                this.BtnRemoveDelta.Enabled = true;
                this.BtnEditDelta.Enabled = true;
            }
        }

        private void SelectionChange_S(string caller)
        {
            if (caller == "LBDeltas")
            {
                RefreshDeltaButtons_S();
                try
                {
                    this.TBSelectionDetails.Text =
                    ActiveProjection.Budget.Deltas[
                                       this.LBDeltas.SelectedIndex
                                       ].GetReadable().Replace("\n", Environment.NewLine);
                }
                catch
                {
                    this.TBSelectionDetails.Text = "";
                }
            }
            else if (caller == "LBFunds")
            {
                RefreshSelectedFundView_S();
                RefreshFundButtons_S();
                try
                {
                    this.TBSelectionDetails.Text =
                        this.m_SelectedFund.GetReadable().Replace("\n", Environment.NewLine);
                }
                catch
                {
                    this.TBSelectionDetails.Text = "";
                }
            }
            
        }

        private void TBName_TextChanged(object sender, EventArgs e)
        {
            if (this.TBName.Text != "")
            {
                this.Budget.Name = this.TBName.Text;
            }
        }

        private void BtnAddIncome_Click(object sender, EventArgs e)
        {
            frmNewDelta newDeltaForm = new frmNewDelta(ActiveProjection, "Add Income Form");
            newDeltaForm.ShowDialog();
            if (newDeltaForm.DialogResult == DialogResult.OK)
            {
                ActiveProjection.Budget.AddDelta(newDeltaForm.CreatedDelta);
                RefreshDeltasView_S();
            }
        }

        private void BtnAddExpense_Click(object sender, EventArgs e)
        {
            frmNewDelta newDeltaForm = new frmNewDelta(ActiveProjection, "Add Expense Form");
            newDeltaForm.ShowDialog();
            if (newDeltaForm.DialogResult == DialogResult.OK)
            {
                newDeltaForm.CreatedDelta.Amount = -newDeltaForm.CreatedDelta.Amount;
                ActiveProjection.Budget.AddDelta(newDeltaForm.CreatedDelta);
                RefreshDeltasView_S();
            }
        }

        private void BtnEditDelta_Click(object sender, EventArgs e)
        {
            try
            {
                Plan delta = ActiveProjection.Budget.Deltas[this.LBDeltas.SelectedIndex];
                frmNewDelta newDeltaForm = new frmNewDelta(ActiveProjection, delta, "Add Expense Form");
                newDeltaForm.ShowDialog();
                if (newDeltaForm.DialogResult == DialogResult.OK)
                {
                    ActiveProjection.DeleteDelta(delta);
                    ActiveProjection.Budget.AddDelta(newDeltaForm.CreatedDelta);
                    RefreshDeltasView_S();
                }
            }
            catch
            {
                this.BtnEditDelta.Enabled = false;
            }
            
        }

        private void LBDeltas_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectionChange_S("LBDeltas");
        }


        private void LBFunds_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectionChange_S("LBFunds");
        }

        private void BtnRemoveDelta_Click(object sender, EventArgs e)
        {
            try
            {
                ActiveProjection.DeleteDelta(ActiveProjection.Budget.Deltas[
                                   this.LBDeltas.SelectedIndex
                                   ]);
                RefreshDeltasView_S();
            }
            catch
            {
                this.BtnRemoveDelta.Enabled = false;
            }
            
        }

        private void BtnCreateFund_Click(object sender, EventArgs e)
        {
            frmNewFund fundForm = new frmNewFund(ActiveProjection);
            fundForm.ShowDialog();
            if (fundForm.DialogResult == DialogResult.OK)
            {
                this.ActiveProjection.Funds.Add(fundForm.CreatedFund);
            }
            RefreshFundsView_S();
        }

        private void BtnCreatePlan_Click(object sender, EventArgs e)
        {
            frmNewDelta newDeltaForm = new frmNewDelta(ActiveProjection, "Minimum Payment Plan", "Payment");
            newDeltaForm.ShowDialog();
            if (newDeltaForm.DialogResult == DialogResult.OK)
            {
                if (this.m_SelectedFund != null)
                {
                    this.ActiveProjection.Budget.DeAllocateFund(m_SelectedFund);
                    this.ActiveProjection.Budget
                    .AllocateFunds(m_SelectedFund, newDeltaForm.CreatedDelta);
                    RefreshSelectedFundView_S();
                    RefreshAddPlanBtn_S();
                    if (!m_SelectedFund.Rigid)
                    {
                        m_SelectedFund.Balance = newDeltaForm.CreatedDelta.Amount;
                    }
                    
                }
            }
        }

        private void BtnDeAllocate_Click(object sender, EventArgs e)
        {
            if (this.ActiveProjection.Budget.BudgetMap.ContainsKey(m_SelectedFund))
            {
                this.ActiveProjection.Budget.DeAllocateFund(m_SelectedFund);
                RefreshSelectedFundView_S();

            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NUDSavings_ValueChanged(object sender, EventArgs e)
        {
            Budget.Balance = (float)NUDSavings.Value;
        }

        private void BtnRemoveFund_Click(object sender, EventArgs e)
        {
            if (this.m_SelectedFund != null)
            {
                ActiveProjection.DeleteFund(m_SelectedFund);
                this.RefreshSelectedFundView_S();
                this.RefreshFundsView_S();
                this.RefreshFundButtons_S();
            }
        }

        private void BtnEditFund_Click(object sender, EventArgs e)
        {
            try
            {
                Fund fund = ActiveProjection.Funds[this.LBFunds.SelectedIndex];
                frmNewFund newLoanForm = new frmNewFund(ActiveProjection, fund);
                newLoanForm.ShowDialog();
                if (newLoanForm.DialogResult == DialogResult.OK)
                {
                    ActiveProjection.ReplaceFund(fund, newLoanForm.CreatedFund);
                    //ActiveProjection.Funds.Add(newLoanForm.CreatedFund);
                    
                }
            }
            catch
            {
                this.BtnEditFund.Enabled = false;
            }
            RefreshFundsView_S();
        }
    }
}
