namespace BudgetProjectionProject.Forms
{
    partial class frmNewLoan
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
            this.TBID = new System.Windows.Forms.TextBox();
            this.LblName = new System.Windows.Forms.Label();
            this.NUDPrincipal = new System.Windows.Forms.NumericUpDown();
            this.LblPrincipal = new System.Windows.Forms.Label();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.GBMinPayPlan = new System.Windows.Forms.GroupBox();
            this.BtnSelectFund = new System.Windows.Forms.Button();
            this.LblFund = new System.Windows.Forms.Label();
            this.TBFund = new System.Windows.Forms.TextBox();
            this.LblMinPayStrat = new System.Windows.Forms.Label();
            this.TBMinPayStrat = new System.Windows.Forms.TextBox();
            this.LblPayment = new System.Windows.Forms.Label();
            this.TBMinPayAmount = new System.Windows.Forms.TextBox();
            this.BtnSetMinPayPlan = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TBIPlanStrat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TBAPR = new System.Windows.Forms.TextBox();
            this.BtnCreateInterestPlan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NUDPrincipal)).BeginInit();
            this.GBMinPayPlan.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TBID
            // 
            this.TBID.Location = new System.Drawing.Point(60, 12);
            this.TBID.Name = "TBID";
            this.TBID.Size = new System.Drawing.Size(253, 20);
            this.TBID.TabIndex = 12;
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Location = new System.Drawing.Point(11, 15);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(38, 13);
            this.LblName.TabIndex = 11;
            this.LblName.Text = "Name:";
            // 
            // NUDPrincipal
            // 
            this.NUDPrincipal.DecimalPlaces = 2;
            this.NUDPrincipal.Location = new System.Drawing.Point(60, 38);
            this.NUDPrincipal.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.NUDPrincipal.Name = "NUDPrincipal";
            this.NUDPrincipal.Size = new System.Drawing.Size(253, 20);
            this.NUDPrincipal.TabIndex = 14;
            this.NUDPrincipal.ThousandsSeparator = true;
            // 
            // LblPrincipal
            // 
            this.LblPrincipal.AutoSize = true;
            this.LblPrincipal.Location = new System.Drawing.Point(11, 41);
            this.LblPrincipal.Name = "LblPrincipal";
            this.LblPrincipal.Size = new System.Drawing.Size(50, 13);
            this.LblPrincipal.TabIndex = 13;
            this.LblPrincipal.Text = "Principal:";
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(157, 302);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 16;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(238, 302);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 15;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // GBMinPayPlan
            // 
            this.GBMinPayPlan.Controls.Add(this.BtnSelectFund);
            this.GBMinPayPlan.Controls.Add(this.LblFund);
            this.GBMinPayPlan.Controls.Add(this.TBFund);
            this.GBMinPayPlan.Controls.Add(this.LblMinPayStrat);
            this.GBMinPayPlan.Controls.Add(this.TBMinPayStrat);
            this.GBMinPayPlan.Controls.Add(this.LblPayment);
            this.GBMinPayPlan.Controls.Add(this.TBMinPayAmount);
            this.GBMinPayPlan.Controls.Add(this.BtnSetMinPayPlan);
            this.GBMinPayPlan.Location = new System.Drawing.Point(12, 64);
            this.GBMinPayPlan.Name = "GBMinPayPlan";
            this.GBMinPayPlan.Size = new System.Drawing.Size(301, 126);
            this.GBMinPayPlan.TabIndex = 17;
            this.GBMinPayPlan.TabStop = false;
            this.GBMinPayPlan.Text = "Minimum Payment Plan";
            // 
            // BtnSelectFund
            // 
            this.BtnSelectFund.Location = new System.Drawing.Point(139, 97);
            this.BtnSelectFund.Name = "BtnSelectFund";
            this.BtnSelectFund.Size = new System.Drawing.Size(75, 23);
            this.BtnSelectFund.TabIndex = 24;
            this.BtnSelectFund.Text = "Select Fund";
            this.BtnSelectFund.UseVisualStyleBackColor = true;
            this.BtnSelectFund.Click += new System.EventHandler(this.BtnSelectFund_Click);
            // 
            // LblFund
            // 
            this.LblFund.AutoSize = true;
            this.LblFund.Location = new System.Drawing.Point(6, 74);
            this.LblFund.Name = "LblFund";
            this.LblFund.Size = new System.Drawing.Size(71, 13);
            this.LblFund.TabIndex = 23;
            this.LblFund.Text = "Source Fund:";
            this.LblFund.Click += new System.EventHandler(this.LblFund_Click);
            // 
            // TBFund
            // 
            this.TBFund.Location = new System.Drawing.Point(83, 71);
            this.TBFund.Name = "TBFund";
            this.TBFund.ReadOnly = true;
            this.TBFund.Size = new System.Drawing.Size(212, 20);
            this.TBFund.TabIndex = 22;
            this.TBFund.TextChanged += new System.EventHandler(this.TBFund_TextChanged);
            // 
            // LblMinPayStrat
            // 
            this.LblMinPayStrat.AutoSize = true;
            this.LblMinPayStrat.Location = new System.Drawing.Point(10, 48);
            this.LblMinPayStrat.Name = "LblMinPayStrat";
            this.LblMinPayStrat.Size = new System.Drawing.Size(49, 13);
            this.LblMinPayStrat.TabIndex = 21;
            this.LblMinPayStrat.Text = "Strategy:";
            // 
            // TBMinPayStrat
            // 
            this.TBMinPayStrat.Location = new System.Drawing.Point(65, 45);
            this.TBMinPayStrat.Name = "TBMinPayStrat";
            this.TBMinPayStrat.ReadOnly = true;
            this.TBMinPayStrat.Size = new System.Drawing.Size(230, 20);
            this.TBMinPayStrat.TabIndex = 20;
            // 
            // LblPayment
            // 
            this.LblPayment.AutoSize = true;
            this.LblPayment.Location = new System.Drawing.Point(8, 22);
            this.LblPayment.Name = "LblPayment";
            this.LblPayment.Size = new System.Drawing.Size(51, 13);
            this.LblPayment.TabIndex = 19;
            this.LblPayment.Text = "Payment:";
            // 
            // TBMinPayAmount
            // 
            this.TBMinPayAmount.Location = new System.Drawing.Point(65, 19);
            this.TBMinPayAmount.Name = "TBMinPayAmount";
            this.TBMinPayAmount.ReadOnly = true;
            this.TBMinPayAmount.Size = new System.Drawing.Size(230, 20);
            this.TBMinPayAmount.TabIndex = 18;
            // 
            // BtnSetMinPayPlan
            // 
            this.BtnSetMinPayPlan.Location = new System.Drawing.Point(220, 97);
            this.BtnSetMinPayPlan.Name = "BtnSetMinPayPlan";
            this.BtnSetMinPayPlan.Size = new System.Drawing.Size(75, 23);
            this.BtnSetMinPayPlan.TabIndex = 17;
            this.BtnSetMinPayPlan.Text = "Create Plan";
            this.BtnSetMinPayPlan.UseVisualStyleBackColor = true;
            this.BtnSetMinPayPlan.Click += new System.EventHandler(this.BtnSetPlan_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TBIPlanStrat);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TBAPR);
            this.groupBox1.Controls.Add(this.BtnCreateInterestPlan);
            this.groupBox1.Location = new System.Drawing.Point(12, 196);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 100);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Interest Plan";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Strategy:";
            // 
            // TBIPlanStrat
            // 
            this.TBIPlanStrat.Location = new System.Drawing.Point(65, 45);
            this.TBIPlanStrat.Name = "TBIPlanStrat";
            this.TBIPlanStrat.ReadOnly = true;
            this.TBIPlanStrat.Size = new System.Drawing.Size(230, 20);
            this.TBIPlanStrat.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "APR:";
            // 
            // TBAPR
            // 
            this.TBAPR.Location = new System.Drawing.Point(65, 19);
            this.TBAPR.Name = "TBAPR";
            this.TBAPR.ReadOnly = true;
            this.TBAPR.Size = new System.Drawing.Size(230, 20);
            this.TBAPR.TabIndex = 18;
            // 
            // BtnCreateInterestPlan
            // 
            this.BtnCreateInterestPlan.Location = new System.Drawing.Point(220, 71);
            this.BtnCreateInterestPlan.Name = "BtnCreateInterestPlan";
            this.BtnCreateInterestPlan.Size = new System.Drawing.Size(75, 23);
            this.BtnCreateInterestPlan.TabIndex = 17;
            this.BtnCreateInterestPlan.Text = "Create Plan";
            this.BtnCreateInterestPlan.UseVisualStyleBackColor = true;
            this.BtnCreateInterestPlan.Click += new System.EventHandler(this.BtnCreateInterestPlan_Click);
            // 
            // frmNewLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 334);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GBMinPayPlan);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.NUDPrincipal);
            this.Controls.Add(this.LblPrincipal);
            this.Controls.Add(this.TBID);
            this.Controls.Add(this.LblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmNewLoan";
            this.Text = "frmNewLoan";
            this.Load += new System.EventHandler(this.frmNewLoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NUDPrincipal)).EndInit();
            this.GBMinPayPlan.ResumeLayout(false);
            this.GBMinPayPlan.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TBID;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.NumericUpDown NUDPrincipal;
        private System.Windows.Forms.Label LblPrincipal;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox GBMinPayPlan;
        private System.Windows.Forms.Button BtnSetMinPayPlan;
        private System.Windows.Forms.Label LblMinPayStrat;
        private System.Windows.Forms.TextBox TBMinPayStrat;
        private System.Windows.Forms.Label LblPayment;
        private System.Windows.Forms.TextBox TBMinPayAmount;
        private System.Windows.Forms.Label LblFund;
        private System.Windows.Forms.TextBox TBFund;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBIPlanStrat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBAPR;
        private System.Windows.Forms.Button BtnCreateInterestPlan;
        private System.Windows.Forms.Button BtnSelectFund;
    }
}