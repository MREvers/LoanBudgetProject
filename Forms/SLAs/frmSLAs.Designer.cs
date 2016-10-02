namespace BudgetProjectionProject.Forms
{
    partial class frmSLAs
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
            this.BtnNewSLA = new System.Windows.Forms.Button();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.LBLoans = new System.Windows.Forms.ListBox();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.TBDetails = new System.Windows.Forms.TextBox();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnNewSLA
            // 
            this.BtnNewSLA.Location = new System.Drawing.Point(172, 237);
            this.BtnNewSLA.Name = "BtnNewSLA";
            this.BtnNewSLA.Size = new System.Drawing.Size(53, 23);
            this.BtnNewSLA.TabIndex = 24;
            this.BtnNewSLA.Text = "New";
            this.BtnNewSLA.UseVisualStyleBackColor = true;
            this.BtnNewSLA.Click += new System.EventHandler(this.BtnNewSLA_Click);
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(479, 238);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(54, 23);
            this.BtnOK.TabIndex = 23;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(539, 238);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(57, 23);
            this.BtnCancel.TabIndex = 22;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // LBLoans
            // 
            this.LBLoans.FormattingEnabled = true;
            this.LBLoans.Location = new System.Drawing.Point(12, 12);
            this.LBLoans.Name = "LBLoans";
            this.LBLoans.Size = new System.Drawing.Size(154, 212);
            this.LBLoans.TabIndex = 21;
            this.LBLoans.SelectedIndexChanged += new System.EventHandler(this.LBLoans_SelectedIndexChanged);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(115, 237);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(51, 23);
            this.BtnDelete.TabIndex = 25;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // TBDetails
            // 
            this.TBDetails.Location = new System.Drawing.Point(172, 12);
            this.TBDetails.Multiline = true;
            this.TBDetails.Name = "TBDetails";
            this.TBDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TBDetails.Size = new System.Drawing.Size(424, 214);
            this.TBDetails.TabIndex = 26;
            // 
            // BtnEdit
            // 
            this.BtnEdit.Location = new System.Drawing.Point(12, 238);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(51, 23);
            this.BtnEdit.TabIndex = 27;
            this.BtnEdit.Text = "Edit";
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // frmSLAs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 272);
            this.Controls.Add(this.BtnEdit);
            this.Controls.Add(this.TBDetails);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnNewSLA);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.LBLoans);
            this.Name = "frmSLAs";
            this.Text = "frmSLAs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnNewSLA;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.ListBox LBLoans;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.TextBox TBDetails;
        private System.Windows.Forms.Button BtnEdit;
    }
}