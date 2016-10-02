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
    public partial class frmFunds : Form
    {
        public Projection ActiveProjection;
        public Fund SelectedFund;

        public frmFunds(Projection ap)
        {
            InitializeComponent();
            ActiveProjection = ap;
            RefreshFundsList_S();
        }

        private void RefreshFundsList_S()
        {
            this.LBFunds.Items.Clear();
            this.LBFunds.Items.Add(
                this.ActiveProjection.Budget.Name);
            foreach (Fund fund in this.ActiveProjection.Funds)
            {
                this.LBFunds.Items.Add(fund.Name);
            }
        }

        private void LBLoans_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (this.LBFunds.SelectedIndex >= 0 &&
                LBFunds.SelectedIndex <= ActiveProjection.Funds.Count)
            {
                if (this.LBFunds.SelectedIndex == 0)
                {
                    SelectedFund = this.ActiveProjection.Budget;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    SelectedFund = this.ActiveProjection.Funds[
                        this.LBFunds.SelectedIndex - 1
                        ];
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
