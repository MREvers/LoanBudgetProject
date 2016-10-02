namespace BudgetProjectionProject.Forms
{
    partial class frmStrategies
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
            this.LBStrategies = new System.Windows.Forms.ListBox();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.TBDetails = new System.Windows.Forms.TextBox();
            this.BtnNewStrategy = new System.Windows.Forms.Button();
            this.BtnDeleteLoan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LBStrategies
            // 
            this.LBStrategies.FormattingEnabled = true;
            this.LBStrategies.Location = new System.Drawing.Point(12, 12);
            this.LBStrategies.Name = "LBStrategies";
            this.LBStrategies.Size = new System.Drawing.Size(260, 82);
            this.LBStrategies.TabIndex = 0;
            this.LBStrategies.SelectedIndexChanged += new System.EventHandler(this.LBStrategies_SelectedIndexChanged);
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(117, 238);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 8;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(198, 238);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // TBDetails
            // 
            this.TBDetails.Location = new System.Drawing.Point(12, 129);
            this.TBDetails.Multiline = true;
            this.TBDetails.Name = "TBDetails";
            this.TBDetails.Size = new System.Drawing.Size(260, 103);
            this.TBDetails.TabIndex = 9;
            // 
            // BtnNewStrategy
            // 
            this.BtnNewStrategy.Location = new System.Drawing.Point(184, 100);
            this.BtnNewStrategy.Name = "BtnNewStrategy";
            this.BtnNewStrategy.Size = new System.Drawing.Size(88, 23);
            this.BtnNewStrategy.TabIndex = 10;
            this.BtnNewStrategy.Text = "New Strategy";
            this.BtnNewStrategy.UseVisualStyleBackColor = true;
            this.BtnNewStrategy.Click += new System.EventHandler(this.BtnNewStrategy_Click);
            // 
            // BtnDeleteLoan
            // 
            this.BtnDeleteLoan.Location = new System.Drawing.Point(103, 100);
            this.BtnDeleteLoan.Name = "BtnDeleteLoan";
            this.BtnDeleteLoan.Size = new System.Drawing.Size(75, 23);
            this.BtnDeleteLoan.TabIndex = 18;
            this.BtnDeleteLoan.Text = "Delete";
            this.BtnDeleteLoan.UseVisualStyleBackColor = true;
            this.BtnDeleteLoan.Click += new System.EventHandler(this.BtnDeleteLoan_Click);
            // 
            // frmStrategies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 273);
            this.Controls.Add(this.BtnDeleteLoan);
            this.Controls.Add(this.BtnNewStrategy);
            this.Controls.Add(this.TBDetails);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.LBStrategies);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmStrategies";
            this.Text = "frmStrategies";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LBStrategies;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.TextBox TBDetails;
        private System.Windows.Forms.Button BtnNewStrategy;
        private System.Windows.Forms.Button BtnDeleteLoan;
    }
}