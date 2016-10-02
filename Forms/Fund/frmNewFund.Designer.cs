namespace BudgetProjectionProject.Forms
{
    partial class frmNewFund
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
            this.NUDAmount = new System.Windows.Forms.NumericUpDown();
            this.LblName = new System.Windows.Forms.Label();
            this.LblAmount = new System.Windows.Forms.Label();
            this.LblRigid = new System.Windows.Forms.Label();
            this.CBRigid = new System.Windows.Forms.ComboBox();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnGetParent = new System.Windows.Forms.Button();
            this.LblParent = new System.Windows.Forms.Label();
            this.TBParent = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.NUDAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // TBID
            // 
            this.TBID.Location = new System.Drawing.Point(83, 12);
            this.TBID.Name = "TBID";
            this.TBID.Size = new System.Drawing.Size(189, 20);
            this.TBID.TabIndex = 14;
            // 
            // NUDAmount
            // 
            this.NUDAmount.DecimalPlaces = 2;
            this.NUDAmount.Location = new System.Drawing.Point(83, 65);
            this.NUDAmount.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.NUDAmount.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.NUDAmount.Name = "NUDAmount";
            this.NUDAmount.Size = new System.Drawing.Size(189, 20);
            this.NUDAmount.TabIndex = 13;
            this.NUDAmount.ThousandsSeparator = true;
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Location = new System.Drawing.Point(12, 15);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(65, 13);
            this.LblName.TabIndex = 12;
            this.LblName.Text = "Fund Name:";
            // 
            // LblAmount
            // 
            this.LblAmount.AutoSize = true;
            this.LblAmount.Location = new System.Drawing.Point(28, 68);
            this.LblAmount.Name = "LblAmount";
            this.LblAmount.Size = new System.Drawing.Size(49, 13);
            this.LblAmount.TabIndex = 11;
            this.LblAmount.Text = "Balance:";
            // 
            // LblRigid
            // 
            this.LblRigid.AutoSize = true;
            this.LblRigid.Location = new System.Drawing.Point(43, 41);
            this.LblRigid.Name = "LblRigid";
            this.LblRigid.Size = new System.Drawing.Size(34, 13);
            this.LblRigid.TabIndex = 15;
            this.LblRigid.Text = "Rigid:";
            // 
            // CBRigid
            // 
            this.CBRigid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBRigid.FormattingEnabled = true;
            this.CBRigid.Items.AddRange(new object[] {
            "True",
            "False"});
            this.CBRigid.Location = new System.Drawing.Point(151, 38);
            this.CBRigid.Name = "CBRigid";
            this.CBRigid.Size = new System.Drawing.Size(121, 21);
            this.CBRigid.TabIndex = 16;
            this.CBRigid.SelectedIndexChanged += new System.EventHandler(this.CBRigid_SelectedIndexChanged);
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(116, 187);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 18;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(197, 187);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 17;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnGetParent
            // 
            this.BtnGetParent.Location = new System.Drawing.Point(184, 117);
            this.BtnGetParent.Name = "BtnGetParent";
            this.BtnGetParent.Size = new System.Drawing.Size(88, 23);
            this.BtnGetParent.TabIndex = 21;
            this.BtnGetParent.Text = "Select Parent";
            this.BtnGetParent.UseVisualStyleBackColor = true;
            this.BtnGetParent.Click += new System.EventHandler(this.BtnGetParent_Click);
            // 
            // LblParent
            // 
            this.LblParent.AutoSize = true;
            this.LblParent.Location = new System.Drawing.Point(12, 94);
            this.LblParent.Name = "LblParent";
            this.LblParent.Size = new System.Drawing.Size(41, 13);
            this.LblParent.TabIndex = 20;
            this.LblParent.Text = "Parent:";
            // 
            // TBParent
            // 
            this.TBParent.Location = new System.Drawing.Point(61, 91);
            this.TBParent.Name = "TBParent";
            this.TBParent.ReadOnly = true;
            this.TBParent.Size = new System.Drawing.Size(211, 20);
            this.TBParent.TabIndex = 19;
            // 
            // frmNewFund
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 222);
            this.Controls.Add(this.BtnGetParent);
            this.Controls.Add(this.LblParent);
            this.Controls.Add(this.TBParent);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.CBRigid);
            this.Controls.Add(this.LblRigid);
            this.Controls.Add(this.TBID);
            this.Controls.Add(this.NUDAmount);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.LblAmount);
            this.Name = "frmNewFund";
            this.Text = "frmNewFund";
            ((System.ComponentModel.ISupportInitialize)(this.NUDAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TBID;
        private System.Windows.Forms.NumericUpDown NUDAmount;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Label LblAmount;
        private System.Windows.Forms.Label LblRigid;
        private System.Windows.Forms.ComboBox CBRigid;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnGetParent;
        private System.Windows.Forms.Label LblParent;
        private System.Windows.Forms.TextBox TBParent;
    }
}