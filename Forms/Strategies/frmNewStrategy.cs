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
    public partial class frmNewStrategy : Form
    {
        public DateStrategy CreatedStrategy;
        public Projection ActiveStrategy;

        public frmNewStrategy(Projection ap)
        {
            InitializeComponent();
            ActiveStrategy = ap;

            // Disable the input boxes
            Reset();

            // Add the options to the list
            CBStrategySelector.Items.AddRange(new object[] {"X Day of Month",
                        "X Days"});
        }

        private void Reset()
        {
            this.LblField1.Text = "Field1";
            this.LblField2.Text = "Field2";
            this.LblField3.Text = "Field3";

            // Disable the input boxes
            this.TBField1.ReadOnly = true;
            this.TBField1.Text = "";
            this.TBField2.ReadOnly = true;
            this.TBField2.Text = "";
            this.TBField3.ReadOnly = true;
            this.TBField3.Text = "";
        }

        private void CBStrategySelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selection = CBStrategySelector.SelectedItem.ToString();
            Reset();
            if (selection == "X Day of Month")
            {
                this.TBField1.ReadOnly = false;
                this.LblField1.Text = "ID";
                this.TBField2.ReadOnly = false;
                this.LblField2.Text = "Day";
                this.TBField3.ReadOnly = false;
                this.LblField3.Text = "Start Day";
                this.TBField3.Text = "0";
            }
            else
            {
                this.TBField1.ReadOnly = false;
                this.LblField1.Text = "ID";
                this.TBField2.ReadOnly = false;
                this.LblField2.Text = "#Days";
                this.TBField3.ReadOnly = false;
                this.LblField3.Text = "Start Day";
                this.TBField3.Text = "0";
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            bool bRetVal = true;
            if (CBStrategySelector.SelectedItem.ToString() == "X Day of Month")
            {
                int F2 = 0;
                int F3 = 0;
                if (this.TBField2.Text != "" &&
                    this.TBField3.Text != "")
                {
                    bRetVal &= int.TryParse(this.TBField2.Text, out F2);
                    bRetVal &= int.TryParse(this.TBField3.Text, out F3);
                }
                else
                {
                    bRetVal &= false;
                }

                if (bRetVal)
                {
                    this.CreatedStrategy = new XDayOfMonth(F2, this.TBField1.Text);
                    this.CreatedStrategy.SetStartEndDate(F3);
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                int F2 = 0;
                int F3 = 0;
                if (this.TBField2.Text != "" &&
                    this.TBField3.Text != "")
                {
                    bRetVal &= int.TryParse(this.TBField2.Text, out F2);
                    bRetVal &= int.TryParse(this.TBField3.Text, out F3);
                }
                else
                {
                    bRetVal &= false;
                }

                if (bRetVal)
                {
                    this.CreatedStrategy = new XDays(F2, this.TBField1.Text);
                    this.CreatedStrategy.SetStartEndDate(F3);
                    this.DialogResult = DialogResult.OK;
                }
            }

            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
