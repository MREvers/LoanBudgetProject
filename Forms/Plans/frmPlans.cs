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
    public partial class frmPlans : Form
    {
        public Projection ActiveProjection;
        public Plan CreatedPlan;

        public frmPlans(Projection ap)
        {
            InitializeComponent();
            ActiveProjection = ap;
        }

        public void ToggleOK(bool to = false)
        {
            this.BtnOK.Enabled = to;
        }

        private void BtnNewPlan_Click(object sender, EventArgs e)
        {

        }

        
    }
}
