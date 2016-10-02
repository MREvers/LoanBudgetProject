namespace BudgetProjectionProject.Forms
{
    partial class frmNewSLA
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
            this.LblID = new System.Windows.Forms.Label();
            this.BtnGetStrategy = new System.Windows.Forms.Button();
            this.LblStrategy = new System.Windows.Forms.Label();
            this.TBStrategy = new System.Windows.Forms.TextBox();
            this.BtnSelectFund = new System.Windows.Forms.Button();
            this.LblFund = new System.Windows.Forms.Label();
            this.TBFund = new System.Windows.Forms.TextBox();
            this.LBLoans = new System.Windows.Forms.ListBox();
            this.BtnIncludeLoan = new System.Windows.Forms.Button();
            this.BtnExcludeLoan = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TBID
            // 
            this.TBID.Location = new System.Drawing.Point(61, 12);
            this.TBID.Name = "TBID";
            this.TBID.Size = new System.Drawing.Size(211, 20);
            this.TBID.TabIndex = 15;
            // 
            // LblID
            // 
            this.LblID.AutoSize = true;
            this.LblID.Location = new System.Drawing.Point(12, 15);
            this.LblID.Name = "LblID";
            this.LblID.Size = new System.Drawing.Size(21, 13);
            this.LblID.TabIndex = 14;
            this.LblID.Text = "ID:";
            // 
            // BtnGetStrategy
            // 
            this.BtnGetStrategy.Location = new System.Drawing.Point(184, 64);
            this.BtnGetStrategy.Name = "BtnGetStrategy";
            this.BtnGetStrategy.Size = new System.Drawing.Size(88, 23);
            this.BtnGetStrategy.TabIndex = 13;
            this.BtnGetStrategy.Text = "Select Strategy";
            this.BtnGetStrategy.UseVisualStyleBackColor = true;
            this.BtnGetStrategy.Click += new System.EventHandler(this.BtnGetStrategy_Click);
            // 
            // LblStrategy
            // 
            this.LblStrategy.AutoSize = true;
            this.LblStrategy.Location = new System.Drawing.Point(6, 41);
            this.LblStrategy.Name = "LblStrategy";
            this.LblStrategy.Size = new System.Drawing.Size(49, 13);
            this.LblStrategy.TabIndex = 12;
            this.LblStrategy.Text = "Strategy:";
            // 
            // TBStrategy
            // 
            this.TBStrategy.Location = new System.Drawing.Point(61, 38);
            this.TBStrategy.Name = "TBStrategy";
            this.TBStrategy.ReadOnly = true;
            this.TBStrategy.Size = new System.Drawing.Size(211, 20);
            this.TBStrategy.TabIndex = 11;
            // 
            // BtnSelectFund
            // 
            this.BtnSelectFund.Location = new System.Drawing.Point(197, 119);
            this.BtnSelectFund.Name = "BtnSelectFund";
            this.BtnSelectFund.Size = new System.Drawing.Size(75, 23);
            this.BtnSelectFund.TabIndex = 27;
            this.BtnSelectFund.Text = "Select Fund";
            this.BtnSelectFund.UseVisualStyleBackColor = true;
            this.BtnSelectFund.Click += new System.EventHandler(this.BtnSelectFund_Click);
            // 
            // LblFund
            // 
            this.LblFund.AutoSize = true;
            this.LblFund.Location = new System.Drawing.Point(6, 96);
            this.LblFund.Name = "LblFund";
            this.LblFund.Size = new System.Drawing.Size(71, 13);
            this.LblFund.TabIndex = 26;
            this.LblFund.Text = "Source Fund:";
            // 
            // TBFund
            // 
            this.TBFund.Location = new System.Drawing.Point(83, 93);
            this.TBFund.Name = "TBFund";
            this.TBFund.ReadOnly = true;
            this.TBFund.Size = new System.Drawing.Size(189, 20);
            this.TBFund.TabIndex = 25;
            // 
            // LBLoans
            // 
            this.LBLoans.FormattingEnabled = true;
            this.LBLoans.Location = new System.Drawing.Point(152, 148);
            this.LBLoans.Name = "LBLoans";
            this.LBLoans.Size = new System.Drawing.Size(120, 108);
            this.LBLoans.TabIndex = 28;
            // 
            // BtnIncludeLoan
            // 
            this.BtnIncludeLoan.Location = new System.Drawing.Point(12, 148);
            this.BtnIncludeLoan.Name = "BtnIncludeLoan";
            this.BtnIncludeLoan.Size = new System.Drawing.Size(85, 23);
            this.BtnIncludeLoan.TabIndex = 29;
            this.BtnIncludeLoan.Text = "Include Loan";
            this.BtnIncludeLoan.UseVisualStyleBackColor = true;
            this.BtnIncludeLoan.Click += new System.EventHandler(this.BtnIncludeLoan_Click);
            // 
            // BtnExcludeLoan
            // 
            this.BtnExcludeLoan.Location = new System.Drawing.Point(12, 177);
            this.BtnExcludeLoan.Name = "BtnExcludeLoan";
            this.BtnExcludeLoan.Size = new System.Drawing.Size(85, 23);
            this.BtnExcludeLoan.TabIndex = 30;
            this.BtnExcludeLoan.Text = "Exclude Loan";
            this.BtnExcludeLoan.UseVisualStyleBackColor = true;
            this.BtnExcludeLoan.Click += new System.EventHandler(this.BtnExcludeLoan_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(197, 282);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 31;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(116, 282);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 32;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // frmNewSLA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 317);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnExcludeLoan);
            this.Controls.Add(this.BtnIncludeLoan);
            this.Controls.Add(this.LBLoans);
            this.Controls.Add(this.BtnSelectFund);
            this.Controls.Add(this.LblFund);
            this.Controls.Add(this.TBFund);
            this.Controls.Add(this.TBID);
            this.Controls.Add(this.LblID);
            this.Controls.Add(this.BtnGetStrategy);
            this.Controls.Add(this.LblStrategy);
            this.Controls.Add(this.TBStrategy);
            this.Name = "frmNewSLA";
            this.Text = "frmNewSLA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TBID;
        private System.Windows.Forms.Label LblID;
        private System.Windows.Forms.Button BtnGetStrategy;
        private System.Windows.Forms.Label LblStrategy;
        private System.Windows.Forms.TextBox TBStrategy;
        private System.Windows.Forms.Button BtnSelectFund;
        private System.Windows.Forms.Label LblFund;
        private System.Windows.Forms.TextBox TBFund;
        private System.Windows.Forms.ListBox LBLoans;
        private System.Windows.Forms.Button BtnIncludeLoan;
        private System.Windows.Forms.Button BtnExcludeLoan;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOK;
    }
}