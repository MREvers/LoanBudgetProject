using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BudgetProjectionProject.Budgets;

namespace BudgetProjectionProject.Forms
{
    public partial class frmSLAs : Form
    {
        public Projection ActiveProjection;

        public SelectiveLoanAgreement SelectedSLA;

        public frmSLAs(Projection ap)
        {
            InitializeComponent();
            ActiveProjection = ap;
            RefreshFields();
        }

        public void RefreshFields()
        {
            LBLoans.Items.Clear();
            foreach (SelectiveLoanAgreement sla in ActiveProjection.SLAs)
            {
                LBLoans.Items.Add(sla.ID);
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (LBLoans.SelectedIndex >= 0 &&
                LBLoans.SelectedIndex < ActiveProjection.SLAs.Count)
            {
                SelectedSLA = ActiveProjection.SLAs[LBLoans.SelectedIndex];
                this.DialogResult = DialogResult.OK;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnNewSLA_Click(object sender, EventArgs e)
        {
            frmNewSLA slaForm = new frmNewSLA(ActiveProjection);
            slaForm.ShowDialog();
            if (slaForm.DialogResult == DialogResult.OK)
            {
                ActiveProjection.SLAs.Add(slaForm.CreatedSLA);
                RefreshFields();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (LBLoans.SelectedIndex >= 0 &&
                LBLoans.SelectedIndex < ActiveProjection.SLAs.Count)
            {
                SelectedSLA = ActiveProjection.SLAs[LBLoans.SelectedIndex];
                string warning = "Are you sure you want to delete " + SelectedSLA.ID + "?";
                ConfirmationForm cform = new ConfirmationForm(warning);
                cform.ShowDialog();
                if (cform.DialogResult == DialogResult.OK)
                {
                    ActiveProjection.DeleteSLA(this.SelectedSLA);
                }
            }
            RefreshFields();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (LBLoans.SelectedIndex >= 0 &&
                LBLoans.SelectedIndex < ActiveProjection.SLAs.Count)
            {
                SelectedSLA = ActiveProjection.SLAs[LBLoans.SelectedIndex];
                frmNewSLA frmnewsla = new frmNewSLA(ActiveProjection, SelectedSLA);
                frmnewsla.ShowDialog();
                if (frmnewsla.DialogResult == DialogResult.OK)
                {
                    this.ActiveProjection.DeleteSLA(SelectedSLA);
                    this.ActiveProjection.SLAs.Add(frmnewsla.CreatedSLA);
                }
            }
        }

        private void LBLoans_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (LBLoans.SelectedIndex >= 0 &&
            LBLoans.SelectedIndex < ActiveProjection.SLAs.Count)
            {
                SelectedSLA = ActiveProjection.SLAs[LBLoans.SelectedIndex];
                this.TBDetails.Text = SelectedSLA.GetReadable().Replace("\n", Environment.NewLine);
            }
        }
    }
}
