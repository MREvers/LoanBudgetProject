namespace BudgetProjectionProject.Forms
{
    partial class frmLoans
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
            this.BtnNewLoan = new System.Windows.Forms.Button();
            this.TBDetails = new System.Windows.Forms.TextBox();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.LBLoans = new System.Windows.Forms.ListBox();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnDeleteLoan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnNewLoan
            // 
            this.BtnNewLoan.Location = new System.Drawing.Point(184, 226);
            this.BtnNewLoan.Name = "BtnNewLoan";
            this.BtnNewLoan.Size = new System.Drawing.Size(88, 23);
            this.BtnNewLoan.TabIndex = 15;
            this.BtnNewLoan.Text = "New Loan";
            this.BtnNewLoan.UseVisualStyleBackColor = true;
            this.BtnNewLoan.Click += new System.EventHandler(this.BtnNewLoan_Click);
            // 
            // TBDetails
            // 
            this.TBDetails.Location = new System.Drawing.Point(202, 6);
            this.TBDetails.Multiline = true;
            this.TBDetails.Name = "TBDetails";
            this.TBDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TBDetails.Size = new System.Drawing.Size(336, 214);
            this.TBDetails.TabIndex = 14;
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(365, 226);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 13;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(446, 226);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 12;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // LBLoans
            // 
            this.LBLoans.FormattingEnabled = true;
            this.LBLoans.Location = new System.Drawing.Point(12, 6);
            this.LBLoans.Name = "LBLoans";
            this.LBLoans.Size = new System.Drawing.Size(184, 212);
            this.LBLoans.TabIndex = 11;
            this.LBLoans.SelectedIndexChanged += new System.EventHandler(this.LBLoans_SelectedIndexChanged);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Location = new System.Drawing.Point(12, 226);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(88, 23);
            this.BtnEdit.TabIndex = 16;
            this.BtnEdit.Text = "Edit";
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnDeleteLoan
            // 
            this.BtnDeleteLoan.Location = new System.Drawing.Point(103, 226);
            this.BtnDeleteLoan.Name = "BtnDeleteLoan";
            this.BtnDeleteLoan.Size = new System.Drawing.Size(75, 23);
            this.BtnDeleteLoan.TabIndex = 17;
            this.BtnDeleteLoan.Text = "Delete";
            this.BtnDeleteLoan.UseVisualStyleBackColor = true;
            this.BtnDeleteLoan.Click += new System.EventHandler(this.BtnDeleteLoan_Click);
            // 
            // frmLoans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 261);
            this.Controls.Add(this.BtnDeleteLoan);
            this.Controls.Add(this.BtnEdit);
            this.Controls.Add(this.BtnNewLoan);
            this.Controls.Add(this.TBDetails);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.LBLoans);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmLoans";
            this.Text = "frmLoans";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnNewLoan;
        private System.Windows.Forms.TextBox TBDetails;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.ListBox LBLoans;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnDeleteLoan;
    }
}