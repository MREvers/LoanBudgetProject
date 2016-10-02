namespace BudgetProjectionProject.Forms
{
    partial class frmPlans
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
            this.BtnNewPlan = new System.Windows.Forms.Button();
            this.TBDetails = new System.Windows.Forms.TextBox();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.LBLoans = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // BtnNewPlan
            // 
            this.BtnNewPlan.Location = new System.Drawing.Point(184, 94);
            this.BtnNewPlan.Name = "BtnNewPlan";
            this.BtnNewPlan.Size = new System.Drawing.Size(88, 23);
            this.BtnNewPlan.TabIndex = 20;
            this.BtnNewPlan.Text = "New Plan";
            this.BtnNewPlan.UseVisualStyleBackColor = true;
            this.BtnNewPlan.Click += new System.EventHandler(this.BtnNewPlan_Click);
            // 
            // TBDetails
            // 
            this.TBDetails.Location = new System.Drawing.Point(12, 123);
            this.TBDetails.Multiline = true;
            this.TBDetails.Name = "TBDetails";
            this.TBDetails.Size = new System.Drawing.Size(260, 103);
            this.TBDetails.TabIndex = 19;
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(117, 232);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 18;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(198, 232);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 17;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // LBLoans
            // 
            this.LBLoans.FormattingEnabled = true;
            this.LBLoans.Location = new System.Drawing.Point(12, 6);
            this.LBLoans.Name = "LBLoans";
            this.LBLoans.Size = new System.Drawing.Size(260, 82);
            this.LBLoans.TabIndex = 16;
            // 
            // frmPlans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.BtnNewPlan);
            this.Controls.Add(this.TBDetails);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.LBLoans);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmPlans";
            this.Text = "FrmPlans";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnNewPlan;
        private System.Windows.Forms.TextBox TBDetails;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.ListBox LBLoans;
    }
}