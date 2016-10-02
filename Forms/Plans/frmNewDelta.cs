using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BudgetProjectionProject;
using BudgetProjectionProject.Budgets;
using BudgetProjectionProject.DateStrategies;

namespace BudgetProjectionProject.Forms
{
    public partial class frmNewDelta : Form
    {
        public Projection ActiveProjection;
        public Plan CreatedDelta;

        private DateStrategy m_SelectedStrategy;

        public frmNewDelta(Projection ap, string title, string amtName = "Amount")
        {
            ActiveProjection = ap;
            m_SelectedStrategy = null;
            InitializeComponent();
            this.Text = title;
            this.LblAmount.Text = amtName + ":";
        }

        public frmNewDelta(Projection ap, Plan delta, string title, string amtName = "Amount")
        {
            ActiveProjection = ap;
            m_SelectedStrategy = null;
            InitializeComponent();
            this.Text = title;
            this.LblAmount.Text = amtName + ":";

            this.CreatedDelta = delta;
            this.TBID.Text = this.CreatedDelta.ID;
            this.NUDAmount.Value = (decimal)this.CreatedDelta.Amount;
            this.m_SelectedStrategy = this.CreatedDelta.Strategy;
            UpdateFields();
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
                UpdateFields();
            }
        }

        private void UpdateFields()
        {
            this.TBStrategy.Text = m_SelectedStrategy.Debug();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (m_SelectedStrategy != null && this.TBID.Text != "")
            {
                this.CreatedDelta = new Plan(
                    this.TBID.Text,
                    (float) this.NUDAmount.Value,
                    this.m_SelectedStrategy);
                this.DialogResult = DialogResult.OK;
            }
        }
        private void NUDID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }
    }
}
