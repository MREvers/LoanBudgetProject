using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BudgetProjectionProject.DateStrategies;

namespace BudgetProjectionProject.Forms
{
    public partial class frmStrategies : Form
    {
        // This is the model that this view displays.
        public Projection ActiveProjection;
        public DateStrategy SelectedStrategy;

        public frmStrategies(Projection ap)
        {
            InitializeComponent();
            ActiveProjection = ap;
            ReList();
        }

        public void ToggleOK()
        {
            this.BtnOK.Enabled = !this.BtnOK.Enabled;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnNewStrategy_Click(object sender, EventArgs e)
        {
            frmNewStrategy newStrat = new frmNewStrategy(ActiveProjection);
            newStrat.ShowDialog();
            if (newStrat.DialogResult == DialogResult.OK)
            {
                ActiveProjection.Strategies.Add(newStrat.CreatedStrategy);
                ReList();
            }
        }

        private void ReList()
        {
            this.LBStrategies.Items.Clear();
            foreach(DateStrategy strat in ActiveProjection.Strategies)
            {
                this.LBStrategies.Items.Add(strat.Debug());
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (this.LBStrategies.SelectedItem != null)
            {
                this.DialogResult = DialogResult.OK;
                this.SelectedStrategy = ActiveProjection.Strategies[this.LBStrategies.SelectedIndices[0]];
            }
        }

        private void BtnDeleteLoan_Click(object sender, EventArgs e)
        {
            if (SelectedStrategy != null)
                ActiveProjection.DeleteStrategy(this.SelectedStrategy);

            ReList();
        }

        private void LBStrategies_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.SelectedStrategy = ActiveProjection.Strategies[this.LBStrategies.SelectedIndices[0]];
                this.TBDetails.Text = this.SelectedStrategy.GetReadable().Replace("\n", Environment.NewLine);
            }
            catch
            {
                this.SelectedStrategy = null;
                this.TBDetails.Text = "";
            }
        }
    }
}
