using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BudgetProjectionProject.DateStrategies;
using BudgetProjectionProject.Budgets;
using BudgetProjectionProject.Loans;

namespace BudgetProjectionProject.Forms
{
    public partial class frmNewSLA : Form
    {
        public Projection ActiveProjection;
        public List<Loan> IncludedLoans;
        public SelectiveLoanAgreement CreatedSLA;

        private DateStrategy m_SelectedStrategy;
        private Fund m_SelectedFund;

        public frmNewSLA(Projection ap)
        {
            InitializeComponent();
            IncludedLoans = new List<Loan>();
            ActiveProjection = ap;
        }

        public frmNewSLA(Projection ap, SelectiveLoanAgreement sla)
        {
            InitializeComponent();
            IncludedLoans = new List<Loan>();
            ActiveProjection = ap;

            this.IncludedLoans = sla.LoanSet;
            this.m_SelectedFund = sla.Source;
            this.m_SelectedStrategy = sla.Strategy;
            this.TBID.Text = sla.ID;
            RefreshFields();
        }

        public void RefreshFields()
        {
            TBStrategy.Text = m_SelectedStrategy == null ? "" : m_SelectedStrategy.Debug();
            TBFund.Text = m_SelectedFund == null ? "" : m_SelectedFund.Name;
            LBLoans.Items.Clear();
            foreach(Loan loan in IncludedLoans)
            {
                LBLoans.Items.Add(loan.Name);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnGetStrategy_Click(object sender, EventArgs e)
        {
            frmStrategies StrategyForm = new frmStrategies(ActiveProjection);
            StrategyForm.ShowDialog();
            if (StrategyForm.DialogResult == DialogResult.OK)
            {
                m_SelectedStrategy = StrategyForm.SelectedStrategy;
                RefreshFields();
            }
        }

        private void BtnSelectFund_Click(object sender, EventArgs e)
        {
            frmFunds fundForm = new frmFunds(this.ActiveProjection);
            fundForm.ShowDialog();
            if (fundForm.DialogResult == DialogResult.OK)
            {
                m_SelectedFund = fundForm.SelectedFund;
                RefreshFields();
            }
        }

        private void BtnIncludeLoan_Click(object sender, EventArgs e)
        {
            frmLoans loanForm = new frmLoans(ActiveProjection);
            loanForm.ShowDialog();
            if (loanForm.DialogResult == DialogResult.OK)
            {
                IncludedLoans.Add(loanForm.SelectedLoan);
                RefreshFields();
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (m_SelectedFund != null &&
                m_SelectedStrategy != null && 
                IncludedLoans.Count > 0 &&
                TBID.Text != "")
            {
                CreatedSLA = new SelectiveLoanAgreement(
                    TBID.Text, m_SelectedStrategy, m_SelectedFund
                    );
                foreach(Loan loan in IncludedLoans)
                {
                    CreatedSLA.LoanSet.Add(loan);
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void BtnExcludeLoan_Click(object sender, EventArgs e)
        {
            if (LBLoans.SelectedIndex >= 0 &&
                LBLoans.SelectedIndex < IncludedLoans.Count)
            {
                IncludedLoans.Remove(IncludedLoans[LBLoans.SelectedIndex]);
                RefreshFields();
            }
           
        }
    }
}
