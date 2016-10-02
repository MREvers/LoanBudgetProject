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

namespace BudgetProjectionProject.Forms
{
    public partial class frmLoans : Form
    {
        public Projection ActiveProjection;
        public Loan SelectedLoan;

        public frmLoans(Projection ap)
        {
            InitializeComponent();
            ActiveProjection = ap;
            ReList();
        }

        public void RefreshLoanList_S()
        {
            this.LBLoans.Items.Clear();
            foreach(Loan loan in ActiveProjection.Loans)
            {
                this.LBLoans.Items.Add(loan.Name);
            }
        }

        public void ToggleOK(bool to = false)
        {
            this.BtnOK.Enabled = to;
        }

        private void BtnNewLoan_Click(object sender, EventArgs e)
        {
            frmNewLoan newLoan = new frmNewLoan(ActiveProjection);
            newLoan.ShowDialog();
            if (newLoan.DialogResult == DialogResult.OK)
            {
                ActiveProjection.Loans.Add(newLoan.CreatedLoan);
                ReList();
            }
        }

        private void ReList()
        {
            this.LBLoans.Items.Clear();
            foreach (Loan loan in ActiveProjection.Loans)
            {
                this.LBLoans.Items.Add(loan.Name);
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (this.LBLoans.SelectedItem != null)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (this.LBLoans.SelectedItem != null)
            {
                
                frmNewLoan newLoan = new frmNewLoan(ActiveProjection, SelectedLoan);
                newLoan.ShowDialog();
                if (newLoan.DialogResult == DialogResult.OK)
                {
                    ActiveProjection.ReplaceLoan(SelectedLoan, newLoan.CreatedLoan);
                    this.SelectedLoan = null;
                    ReList();
                }
            }
            
        }

        private void LBLoans_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.SelectedLoan = ActiveProjection.Loans[this.LBLoans.SelectedIndices[0]];
                this.TBDetails.Text = this.SelectedLoan.GetReadable().Replace("\n", Environment.NewLine);
            }
            catch
            {
                this.SelectedLoan = null;
                this.TBDetails.Text = "";
            }
            
        }

        private void BtnDeleteLoan_Click(object sender, EventArgs e)
        {
            
            if (SelectedLoan != null)
            {
                string warning = "Are you sure you want to delete " + SelectedLoan.Name + "?";
                ConfirmationForm cform = new ConfirmationForm(warning);
                cform.ShowDialog();
                if (cform.DialogResult == DialogResult.OK)
                {
                    ActiveProjection.DeleteLoan(this.SelectedLoan);
                }
                
            }
                

            RefreshLoanList_S();
        }
    }
}
