namespace BudgetProjectionProject.Forms
{
    partial class frmAdvBudget
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GBDeltas = new System.Windows.Forms.GroupBox();
            this.LBDeltas = new System.Windows.Forms.ListBox();
            this.BtnEditDelta = new System.Windows.Forms.Button();
            this.BtnRemoveDelta = new System.Windows.Forms.Button();
            this.BtnAddIncome = new System.Windows.Forms.Button();
            this.BtnAddExpense = new System.Windows.Forms.Button();
            this.GBSelectionDetails = new System.Windows.Forms.GroupBox();
            this.TBSelectionDetails = new System.Windows.Forms.TextBox();
            this.GBFunds = new System.Windows.Forms.GroupBox();
            this.LBFunds = new System.Windows.Forms.ListBox();
            this.BtnEditFund = new System.Windows.Forms.Button();
            this.BtnRemoveFund = new System.Windows.Forms.Button();
            this.BtnCreateFund = new System.Windows.Forms.Button();
            this.GBSavings = new System.Windows.Forms.GroupBox();
            this.NUDSavings = new System.Windows.Forms.NumericUpDown();
            this.GBName = new System.Windows.Forms.GroupBox();
            this.TBName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnDeAllocate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TBSelectedFundIsRigid = new System.Windows.Forms.TextBox();
            this.BtnCreatePlan = new System.Windows.Forms.Button();
            this.TBAllocationAmt = new System.Windows.Forms.TextBox();
            this.LblStrategy = new System.Windows.Forms.Label();
            this.TBStrategy = new System.Windows.Forms.TextBox();
            this.LblAmount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblFund = new System.Windows.Forms.Label();
            this.TBFundName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOK = new System.Windows.Forms.Button();
            this.GBDeltas.SuspendLayout();
            this.GBSelectionDetails.SuspendLayout();
            this.GBFunds.SuspendLayout();
            this.GBSavings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDSavings)).BeginInit();
            this.GBName.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GBDeltas
            // 
            this.GBDeltas.Controls.Add(this.LBDeltas);
            this.GBDeltas.Controls.Add(this.BtnEditDelta);
            this.GBDeltas.Controls.Add(this.BtnRemoveDelta);
            this.GBDeltas.Controls.Add(this.BtnAddIncome);
            this.GBDeltas.Controls.Add(this.BtnAddExpense);
            this.GBDeltas.Location = new System.Drawing.Point(336, 257);
            this.GBDeltas.Name = "GBDeltas";
            this.GBDeltas.Size = new System.Drawing.Size(322, 226);
            this.GBDeltas.TabIndex = 1;
            this.GBDeltas.TabStop = false;
            this.GBDeltas.Text = "Fixed Incomes and Expenses";
            // 
            // LBDeltas
            // 
            this.LBDeltas.FormattingEnabled = true;
            this.LBDeltas.Location = new System.Drawing.Point(6, 19);
            this.LBDeltas.Name = "LBDeltas";
            this.LBDeltas.Size = new System.Drawing.Size(202, 199);
            this.LBDeltas.TabIndex = 17;
            this.LBDeltas.SelectedIndexChanged += new System.EventHandler(this.LBDeltas_SelectedIndexChanged);
            // 
            // BtnEditDelta
            // 
            this.BtnEditDelta.Location = new System.Drawing.Point(214, 197);
            this.BtnEditDelta.Name = "BtnEditDelta";
            this.BtnEditDelta.Size = new System.Drawing.Size(85, 23);
            this.BtnEditDelta.TabIndex = 16;
            this.BtnEditDelta.Text = "Edit";
            this.BtnEditDelta.UseVisualStyleBackColor = true;
            this.BtnEditDelta.Click += new System.EventHandler(this.BtnEditDelta_Click);
            // 
            // BtnRemoveDelta
            // 
            this.BtnRemoveDelta.Location = new System.Drawing.Point(214, 77);
            this.BtnRemoveDelta.Name = "BtnRemoveDelta";
            this.BtnRemoveDelta.Size = new System.Drawing.Size(85, 23);
            this.BtnRemoveDelta.TabIndex = 15;
            this.BtnRemoveDelta.Text = "Remove";
            this.BtnRemoveDelta.UseVisualStyleBackColor = true;
            this.BtnRemoveDelta.Click += new System.EventHandler(this.BtnRemoveDelta_Click);
            // 
            // BtnAddIncome
            // 
            this.BtnAddIncome.Location = new System.Drawing.Point(214, 19);
            this.BtnAddIncome.Name = "BtnAddIncome";
            this.BtnAddIncome.Size = new System.Drawing.Size(85, 23);
            this.BtnAddIncome.TabIndex = 14;
            this.BtnAddIncome.Text = "Add Income";
            this.BtnAddIncome.UseVisualStyleBackColor = true;
            this.BtnAddIncome.Click += new System.EventHandler(this.BtnAddIncome_Click);
            // 
            // BtnAddExpense
            // 
            this.BtnAddExpense.Location = new System.Drawing.Point(214, 48);
            this.BtnAddExpense.Name = "BtnAddExpense";
            this.BtnAddExpense.Size = new System.Drawing.Size(85, 23);
            this.BtnAddExpense.TabIndex = 13;
            this.BtnAddExpense.Text = "Add Expense";
            this.BtnAddExpense.UseVisualStyleBackColor = true;
            this.BtnAddExpense.Click += new System.EventHandler(this.BtnAddExpense_Click);
            // 
            // GBSelectionDetails
            // 
            this.GBSelectionDetails.Controls.Add(this.TBSelectionDetails);
            this.GBSelectionDetails.Location = new System.Drawing.Point(377, 12);
            this.GBSelectionDetails.Name = "GBSelectionDetails";
            this.GBSelectionDetails.Size = new System.Drawing.Size(281, 239);
            this.GBSelectionDetails.TabIndex = 2;
            this.GBSelectionDetails.TabStop = false;
            this.GBSelectionDetails.Text = "SelectionDetails";
            // 
            // TBSelectionDetails
            // 
            this.TBSelectionDetails.Location = new System.Drawing.Point(6, 19);
            this.TBSelectionDetails.Multiline = true;
            this.TBSelectionDetails.Name = "TBSelectionDetails";
            this.TBSelectionDetails.Size = new System.Drawing.Size(269, 214);
            this.TBSelectionDetails.TabIndex = 0;
            // 
            // GBFunds
            // 
            this.GBFunds.Controls.Add(this.LBFunds);
            this.GBFunds.Controls.Add(this.BtnEditFund);
            this.GBFunds.Controls.Add(this.BtnRemoveFund);
            this.GBFunds.Controls.Add(this.BtnCreateFund);
            this.GBFunds.Location = new System.Drawing.Point(12, 257);
            this.GBFunds.Name = "GBFunds";
            this.GBFunds.Size = new System.Drawing.Size(318, 226);
            this.GBFunds.TabIndex = 2;
            this.GBFunds.TabStop = false;
            this.GBFunds.Text = "Funds";
            // 
            // LBFunds
            // 
            this.LBFunds.FormattingEnabled = true;
            this.LBFunds.Location = new System.Drawing.Point(6, 19);
            this.LBFunds.Name = "LBFunds";
            this.LBFunds.Size = new System.Drawing.Size(202, 199);
            this.LBFunds.TabIndex = 18;
            this.LBFunds.SelectedIndexChanged += new System.EventHandler(this.LBFunds_SelectedIndexChanged);
            // 
            // BtnEditFund
            // 
            this.BtnEditFund.Location = new System.Drawing.Point(214, 197);
            this.BtnEditFund.Name = "BtnEditFund";
            this.BtnEditFund.Size = new System.Drawing.Size(85, 23);
            this.BtnEditFund.TabIndex = 17;
            this.BtnEditFund.Text = "Edit";
            this.BtnEditFund.UseVisualStyleBackColor = true;
            this.BtnEditFund.Click += new System.EventHandler(this.BtnEditFund_Click);
            // 
            // BtnRemoveFund
            // 
            this.BtnRemoveFund.Location = new System.Drawing.Point(214, 48);
            this.BtnRemoveFund.Name = "BtnRemoveFund";
            this.BtnRemoveFund.Size = new System.Drawing.Size(85, 23);
            this.BtnRemoveFund.TabIndex = 15;
            this.BtnRemoveFund.Text = "Remove";
            this.BtnRemoveFund.UseVisualStyleBackColor = true;
            this.BtnRemoveFund.Click += new System.EventHandler(this.BtnRemoveFund_Click);
            // 
            // BtnCreateFund
            // 
            this.BtnCreateFund.Location = new System.Drawing.Point(214, 19);
            this.BtnCreateFund.Name = "BtnCreateFund";
            this.BtnCreateFund.Size = new System.Drawing.Size(85, 23);
            this.BtnCreateFund.TabIndex = 14;
            this.BtnCreateFund.Text = "Create Fund";
            this.BtnCreateFund.UseVisualStyleBackColor = true;
            this.BtnCreateFund.Click += new System.EventHandler(this.BtnCreateFund_Click);
            // 
            // GBSavings
            // 
            this.GBSavings.Controls.Add(this.NUDSavings);
            this.GBSavings.Location = new System.Drawing.Point(200, 12);
            this.GBSavings.Name = "GBSavings";
            this.GBSavings.Size = new System.Drawing.Size(130, 51);
            this.GBSavings.TabIndex = 3;
            this.GBSavings.TabStop = false;
            this.GBSavings.Text = "Savings";
            // 
            // NUDSavings
            // 
            this.NUDSavings.DecimalPlaces = 2;
            this.NUDSavings.Location = new System.Drawing.Point(6, 19);
            this.NUDSavings.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.NUDSavings.Name = "NUDSavings";
            this.NUDSavings.Size = new System.Drawing.Size(114, 20);
            this.NUDSavings.TabIndex = 11;
            this.NUDSavings.ThousandsSeparator = true;
            this.NUDSavings.ValueChanged += new System.EventHandler(this.NUDSavings_ValueChanged);
            // 
            // GBName
            // 
            this.GBName.Controls.Add(this.TBName);
            this.GBName.Location = new System.Drawing.Point(18, 12);
            this.GBName.Name = "GBName";
            this.GBName.Size = new System.Drawing.Size(176, 51);
            this.GBName.TabIndex = 4;
            this.GBName.TabStop = false;
            this.GBName.Text = "Name";
            // 
            // TBName
            // 
            this.TBName.Location = new System.Drawing.Point(6, 19);
            this.TBName.Name = "TBName";
            this.TBName.Size = new System.Drawing.Size(164, 20);
            this.TBName.TabIndex = 0;
            this.TBName.TextChanged += new System.EventHandler(this.TBName_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnDeAllocate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TBSelectedFundIsRigid);
            this.groupBox1.Controls.Add(this.BtnCreatePlan);
            this.groupBox1.Controls.Add(this.TBAllocationAmt);
            this.groupBox1.Controls.Add(this.LblStrategy);
            this.groupBox1.Controls.Add(this.TBStrategy);
            this.groupBox1.Controls.Add(this.LblAmount);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.LblFund);
            this.groupBox1.Controls.Add(this.TBFundName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(18, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 176);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Allocate Funds";
            // 
            // BtnDeAllocate
            // 
            this.BtnDeAllocate.Enabled = false;
            this.BtnDeAllocate.Location = new System.Drawing.Point(6, 147);
            this.BtnDeAllocate.Name = "BtnDeAllocate";
            this.BtnDeAllocate.Size = new System.Drawing.Size(75, 23);
            this.BtnDeAllocate.TabIndex = 29;
            this.BtnDeAllocate.Text = "De-Allocate";
            this.BtnDeAllocate.UseVisualStyleBackColor = true;
            this.BtnDeAllocate.Click += new System.EventHandler(this.BtnDeAllocate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Flexible:";
            // 
            // TBSelectedFundIsRigid
            // 
            this.TBSelectedFundIsRigid.Location = new System.Drawing.Point(212, 45);
            this.TBSelectedFundIsRigid.Name = "TBSelectedFundIsRigid";
            this.TBSelectedFundIsRigid.ReadOnly = true;
            this.TBSelectedFundIsRigid.Size = new System.Drawing.Size(94, 20);
            this.TBSelectedFundIsRigid.TabIndex = 27;
            // 
            // BtnCreatePlan
            // 
            this.BtnCreatePlan.Location = new System.Drawing.Point(231, 147);
            this.BtnCreatePlan.Name = "BtnCreatePlan";
            this.BtnCreatePlan.Size = new System.Drawing.Size(75, 23);
            this.BtnCreatePlan.TabIndex = 26;
            this.BtnCreatePlan.Text = "Create Plan";
            this.BtnCreatePlan.UseVisualStyleBackColor = true;
            this.BtnCreatePlan.Click += new System.EventHandler(this.BtnCreatePlan_Click);
            // 
            // TBAllocationAmt
            // 
            this.TBAllocationAmt.Location = new System.Drawing.Point(58, 97);
            this.TBAllocationAmt.Name = "TBAllocationAmt";
            this.TBAllocationAmt.ReadOnly = true;
            this.TBAllocationAmt.Size = new System.Drawing.Size(248, 20);
            this.TBAllocationAmt.TabIndex = 25;
            // 
            // LblStrategy
            // 
            this.LblStrategy.AutoSize = true;
            this.LblStrategy.Location = new System.Drawing.Point(6, 126);
            this.LblStrategy.Name = "LblStrategy";
            this.LblStrategy.Size = new System.Drawing.Size(49, 13);
            this.LblStrategy.TabIndex = 24;
            this.LblStrategy.Text = "Strategy:";
            // 
            // TBStrategy
            // 
            this.TBStrategy.Location = new System.Drawing.Point(58, 123);
            this.TBStrategy.Name = "TBStrategy";
            this.TBStrategy.ReadOnly = true;
            this.TBStrategy.Size = new System.Drawing.Size(248, 20);
            this.TBStrategy.TabIndex = 23;
            // 
            // LblAmount
            // 
            this.LblAmount.AutoSize = true;
            this.LblAmount.Location = new System.Drawing.Point(6, 100);
            this.LblAmount.Name = "LblAmount";
            this.LblAmount.Size = new System.Drawing.Size(46, 13);
            this.LblAmount.TabIndex = 22;
            this.LblAmount.Text = "Amount:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Allocation Plan";
            // 
            // LblFund
            // 
            this.LblFund.AutoSize = true;
            this.LblFund.Location = new System.Drawing.Point(6, 48);
            this.LblFund.Name = "LblFund";
            this.LblFund.Size = new System.Drawing.Size(34, 13);
            this.LblFund.TabIndex = 20;
            this.LblFund.Text = "Fund:";
            // 
            // TBFundName
            // 
            this.TBFundName.Location = new System.Drawing.Point(46, 45);
            this.TBFundName.Name = "TBFundName";
            this.TBFundName.ReadOnly = true;
            this.TBFundName.Size = new System.Drawing.Size(109, 20);
            this.TBFundName.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select a fund. Then choose when and how much money\r\n should be allocated to that " +
    "found.";
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(583, 489);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 5;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(502, 489);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 6;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // frmAdvBudget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 516);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GBName);
            this.Controls.Add(this.GBSavings);
            this.Controls.Add(this.GBFunds);
            this.Controls.Add(this.GBSelectionDetails);
            this.Controls.Add(this.GBDeltas);
            this.Name = "frmAdvBudget";
            this.Text = "frmAdvBudget";
            this.GBDeltas.ResumeLayout(false);
            this.GBSelectionDetails.ResumeLayout(false);
            this.GBSelectionDetails.PerformLayout();
            this.GBFunds.ResumeLayout(false);
            this.GBSavings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NUDSavings)).EndInit();
            this.GBName.ResumeLayout(false);
            this.GBName.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox GBDeltas;
        private System.Windows.Forms.GroupBox GBSelectionDetails;
        private System.Windows.Forms.TextBox TBSelectionDetails;
        private System.Windows.Forms.GroupBox GBFunds;
        private System.Windows.Forms.Button BtnEditDelta;
        private System.Windows.Forms.Button BtnRemoveDelta;
        private System.Windows.Forms.Button BtnAddIncome;
        private System.Windows.Forms.Button BtnAddExpense;
        private System.Windows.Forms.Button BtnEditFund;
        private System.Windows.Forms.Button BtnRemoveFund;
        private System.Windows.Forms.Button BtnCreateFund;
        private System.Windows.Forms.GroupBox GBSavings;
        private System.Windows.Forms.NumericUpDown NUDSavings;
        private System.Windows.Forms.GroupBox GBName;
        private System.Windows.Forms.TextBox TBName;
        private System.Windows.Forms.ListBox LBDeltas;
        private System.Windows.Forms.ListBox LBFunds;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblFund;
        private System.Windows.Forms.TextBox TBFundName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBSelectedFundIsRigid;
        private System.Windows.Forms.Button BtnCreatePlan;
        private System.Windows.Forms.TextBox TBAllocationAmt;
        private System.Windows.Forms.Label LblStrategy;
        private System.Windows.Forms.TextBox TBStrategy;
        private System.Windows.Forms.Label LblAmount;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button BtnDeAllocate;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOK;
    }
}