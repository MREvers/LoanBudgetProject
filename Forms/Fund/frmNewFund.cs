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
using BudgetProjectionProject.Loans;

namespace BudgetProjectionProject.Forms
{
    public partial class frmNewFund : Form
    {
        public Projection ActiveProjection;
        public Fund CreatedFund;

        private Fund m_SelectedParent;

        public frmNewFund(Projection ap)
        {
            InitializeComponent();
            ActiveProjection = ap;
            m_SelectedParent = null;
        }

        public frmNewFund(Projection ap, Fund fund) : this(ap)
        {
            m_SelectedParent = fund;
            UpdateFields();
            this.CBRigid.SelectedIndex = fund.Rigid ? 0 : 1;
            this.NUDAmount.Value = (decimal)fund.Balance;
            this.TBID.Text = fund.Name;
        }

        private void UpdateFields()
        {
            this.TBParent.Text = m_SelectedParent.Name;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (this.TBID.Text != "" &&
                (this.CBRigid.SelectedIndex == 0 || this.CBRigid.SelectedIndex == 1) &&
                m_SelectedParent != null)
            {
                bool rigid = this.CBRigid.SelectedIndex == 0;
                this.DialogResult = DialogResult.OK;
                this.CreatedFund = new Fund(this.TBID.Text, m_SelectedParent, (float)this.NUDAmount.Value, rigid);

            }
        }

        private void BtnGetParent_Click(object sender, EventArgs e)
        {
            frmFunds fundForm = new frmFunds(this.ActiveProjection);
            fundForm.ShowDialog();
            if (fundForm.DialogResult == DialogResult.OK)
            {
                this.m_SelectedParent = fundForm.SelectedFund;
            }
            UpdateFields();
        }

        private void CBRigid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.CBRigid.SelectedIndex == 1)
            {
                this.NUDAmount.Enabled = false;
            }
            else
            {
                this.NUDAmount.Enabled = true;
            }
        }
    }
}
