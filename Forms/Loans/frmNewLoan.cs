using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BudgetProjectionProject.Loans;
using BudgetProjectionProject.Budgets;

namespace BudgetProjectionProject.Forms
{
    public partial class frmNewLoan : Form
    {
        public Projection ActiveProjection;
        public Loan CreatedLoan;

        private Plan m_CreatedMinimumPaymentPlan;
        private Fund m_SelectedFund;
        private Plan m_CreatedInterestPlan;

        public frmNewLoan(Projection ap)
        {
            InitializeComponent();
            ActiveProjection = ap;
            m_CreatedInterestPlan = null;
            m_SelectedFund = null;
            m_CreatedMinimumPaymentPlan = null;
            
            RefreshMinPayFundDetails_S();
        }

        public frmNewLoan(Projection ap, Loan loan) : this(ap)
        {
            this.CreatedLoan = loan;
            this.TBID.Text = loan.Name;

            this.NUDPrincipal.Value = (decimal)loan.Principal;
            m_CreatedInterestPlan = loan.InterestPlan;
            m_CreatedMinimumPaymentPlan = loan.MinimumPaymentPlan;
            m_SelectedFund = loan.MinimumPaymentPlan.Source;
            RefreshAll_S();
        }

        private void RefreshAll_S()
        {
            RefreshMinimumPaymentDetails_S();
            RefreshInterestPlanDetails_S();
            RefreshMinPayFundDetails_S();
        }

        private void RefreshMinimumPaymentDetails_S()
        {
            this.TBMinPayAmount.Text = m_CreatedMinimumPaymentPlan.Amount.ToString();
            this.TBMinPayStrat.Text = m_CreatedMinimumPaymentPlan.Strategy.Debug();
        }

        private void RefreshMinPayFundDetails_S()
        {
            this.TBFund.Text = m_SelectedFund != null ? m_SelectedFund.Name : "";
        }

        private void RefreshInterestPlanDetails_S()
        {
            this.TBAPR.Text = m_CreatedInterestPlan.Amount.ToString();
            this.TBIPlanStrat.Text = m_CreatedInterestPlan.Strategy.Debug();
        }

        private void frmNewLoan_Load(object sender, EventArgs e)
        {

        }

        private void BtnSetPlan_Click(object sender, EventArgs e)
        {
            frmNewDelta newDeltaForm = new frmNewDelta(ActiveProjection, "Minimum Payment Plan", "Payment");
            newDeltaForm.ShowDialog();
            if (newDeltaForm.DialogResult == DialogResult.OK)
            {
                m_CreatedMinimumPaymentPlan = newDeltaForm.CreatedDelta;
                RefreshMinimumPaymentDetails_S();
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (this.TBID.Text != "" &&
                m_CreatedInterestPlan != null &&
                m_CreatedMinimumPaymentPlan != null &&
                m_SelectedFund != null)
            {
                FundedPlan fullMinPlan =
                    new FundedPlan(m_CreatedMinimumPaymentPlan.ID,
                    m_CreatedMinimumPaymentPlan.Amount,
                    m_CreatedMinimumPaymentPlan.Strategy,
                    m_SelectedFund);

                
                this.DialogResult = DialogResult.OK;
                this.CreatedLoan = new Loan(this.TBID.Text,
                    (float) this.NUDPrincipal.Value,
                    m_CreatedInterestPlan,
                    fullMinPlan);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnCreateInterestPlan_Click(object sender, EventArgs e)
        {
            frmNewDelta newDeltaForm = new frmNewDelta(ActiveProjection, "Interest Plan", "APR");
            newDeltaForm.ShowDialog();
            if (newDeltaForm.DialogResult == DialogResult.OK)
            {
                m_CreatedInterestPlan = newDeltaForm.CreatedDelta;
                RefreshInterestPlanDetails_S();
            }
        }

        private void BtnSelectFund_Click(object sender, EventArgs e)
        {
            frmFunds fundForm = new frmFunds(this.ActiveProjection);
            fundForm.ShowDialog();
            if (fundForm.DialogResult == DialogResult.OK)
            {
                this.m_SelectedFund = fundForm.SelectedFund;
            }
            RefreshMinPayFundDetails_S();
        }

        private void TBFund_TextChanged(object sender, EventArgs e)
        {

        }

        private void LblFund_Click(object sender, EventArgs e)
        {

        }
    }
}
