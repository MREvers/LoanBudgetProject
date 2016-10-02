namespace BudgetProjectionProject.Forms
{
    partial class frmFunds
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
            this.LBFunds = new System.Windows.Forms.ListBox();
            this.BtnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LBFunds
            // 
            this.LBFunds.FormattingEnabled = true;
            this.LBFunds.Location = new System.Drawing.Point(12, 12);
            this.LBFunds.Name = "LBFunds";
            this.LBFunds.Size = new System.Drawing.Size(260, 212);
            this.LBFunds.TabIndex = 12;
            this.LBFunds.SelectedIndexChanged += new System.EventHandler(this.LBLoans_SelectedIndexChanged);
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(197, 230);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 13;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // frmFunds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.LBFunds);
            this.Name = "frmFunds";
            this.Text = "frmFunds";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LBFunds;
        private System.Windows.Forms.Button BtnOK;
    }
}