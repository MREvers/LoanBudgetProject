namespace BudgetProjectionProject.Forms
{
    partial class frmNewDelta
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
            this.LblAmount = new System.Windows.Forms.Label();
            this.LblStrategy = new System.Windows.Forms.Label();
            this.TBStrategy = new System.Windows.Forms.TextBox();
            this.BtnGetStrategy = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOK = new System.Windows.Forms.Button();
            this.LblID = new System.Windows.Forms.Label();
            this.NUDAmount = new System.Windows.Forms.NumericUpDown();
            this.TBID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.NUDAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // LblAmount
            // 
            this.LblAmount.AutoSize = true;
            this.LblAmount.Location = new System.Drawing.Point(12, 48);
            this.LblAmount.Name = "LblAmount";
            this.LblAmount.Size = new System.Drawing.Size(46, 13);
            this.LblAmount.TabIndex = 1;
            this.LblAmount.Text = "Amount:";
            // 
            // LblStrategy
            // 
            this.LblStrategy.AutoSize = true;
            this.LblStrategy.Location = new System.Drawing.Point(12, 74);
            this.LblStrategy.Name = "LblStrategy";
            this.LblStrategy.Size = new System.Drawing.Size(49, 13);
            this.LblStrategy.TabIndex = 3;
            this.LblStrategy.Text = "Strategy:";
            // 
            // TBStrategy
            // 
            this.TBStrategy.Location = new System.Drawing.Point(61, 71);
            this.TBStrategy.Name = "TBStrategy";
            this.TBStrategy.ReadOnly = true;
            this.TBStrategy.Size = new System.Drawing.Size(211, 20);
            this.TBStrategy.TabIndex = 2;
            // 
            // BtnGetStrategy
            // 
            this.BtnGetStrategy.Location = new System.Drawing.Point(184, 97);
            this.BtnGetStrategy.Name = "BtnGetStrategy";
            this.BtnGetStrategy.Size = new System.Drawing.Size(88, 23);
            this.BtnGetStrategy.TabIndex = 4;
            this.BtnGetStrategy.Text = "Select Strategy";
            this.BtnGetStrategy.UseVisualStyleBackColor = true;
            this.BtnGetStrategy.Click += new System.EventHandler(this.BtnGetStrategy_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(197, 126);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 5;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(116, 126);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 6;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // LblID
            // 
            this.LblID.AutoSize = true;
            this.LblID.Location = new System.Drawing.Point(12, 22);
            this.LblID.Name = "LblID";
            this.LblID.Size = new System.Drawing.Size(21, 13);
            this.LblID.TabIndex = 8;
            this.LblID.Text = "ID:";
            // 
            // NUDAmount
            // 
            this.NUDAmount.DecimalPlaces = 2;
            this.NUDAmount.Location = new System.Drawing.Point(61, 45);
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
            this.NUDAmount.Size = new System.Drawing.Size(211, 20);
            this.NUDAmount.TabIndex = 9;
            this.NUDAmount.ThousandsSeparator = true;
            // 
            // TBID
            // 
            this.TBID.Location = new System.Drawing.Point(61, 19);
            this.TBID.Name = "TBID";
            this.TBID.Size = new System.Drawing.Size(211, 20);
            this.TBID.TabIndex = 10;
            // 
            // frmNewDelta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.TBID);
            this.Controls.Add(this.NUDAmount);
            this.Controls.Add(this.LblID);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnGetStrategy);
            this.Controls.Add(this.LblStrategy);
            this.Controls.Add(this.TBStrategy);
            this.Controls.Add(this.LblAmount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmNewDelta";
            this.Text = "frmDelta";
            ((System.ComponentModel.ISupportInitialize)(this.NUDAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblAmount;
        private System.Windows.Forms.Label LblStrategy;
        private System.Windows.Forms.TextBox TBStrategy;
        private System.Windows.Forms.Button BtnGetStrategy;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Label LblID;
        private System.Windows.Forms.NumericUpDown NUDAmount;
        private System.Windows.Forms.TextBox TBID;
    }
}