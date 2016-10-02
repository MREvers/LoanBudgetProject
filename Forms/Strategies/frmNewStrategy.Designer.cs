namespace BudgetProjectionProject.Forms
{
    partial class frmNewStrategy
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
            this.CBStrategySelector = new System.Windows.Forms.ComboBox();
            this.LblField3 = new System.Windows.Forms.Label();
            this.TBField3 = new System.Windows.Forms.TextBox();
            this.LblField2 = new System.Windows.Forms.Label();
            this.TBField2 = new System.Windows.Forms.TextBox();
            this.LblField1 = new System.Windows.Forms.Label();
            this.TBField1 = new System.Windows.Forms.TextBox();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CBStrategySelector
            // 
            this.CBStrategySelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBStrategySelector.FormattingEnabled = true;
            this.CBStrategySelector.Location = new System.Drawing.Point(12, 12);
            this.CBStrategySelector.Name = "CBStrategySelector";
            this.CBStrategySelector.Size = new System.Drawing.Size(121, 21);
            this.CBStrategySelector.TabIndex = 0;
            this.CBStrategySelector.SelectedIndexChanged += new System.EventHandler(this.CBStrategySelector_SelectedIndexChanged);
            // 
            // LblField3
            // 
            this.LblField3.AutoSize = true;
            this.LblField3.Location = new System.Drawing.Point(12, 94);
            this.LblField3.Name = "LblField3";
            this.LblField3.Size = new System.Drawing.Size(38, 13);
            this.LblField3.TabIndex = 5;
            this.LblField3.Text = "Field3:\r\n";
            // 
            // TBField3
            // 
            this.TBField3.Location = new System.Drawing.Point(61, 91);
            this.TBField3.Name = "TBField3";
            this.TBField3.Size = new System.Drawing.Size(211, 20);
            this.TBField3.TabIndex = 4;
            // 
            // LblField2
            // 
            this.LblField2.AutoSize = true;
            this.LblField2.Location = new System.Drawing.Point(12, 68);
            this.LblField2.Name = "LblField2";
            this.LblField2.Size = new System.Drawing.Size(38, 13);
            this.LblField2.TabIndex = 7;
            this.LblField2.Text = "Field2:\r\n";
            // 
            // TBField2
            // 
            this.TBField2.Location = new System.Drawing.Point(61, 65);
            this.TBField2.Name = "TBField2";
            this.TBField2.Size = new System.Drawing.Size(211, 20);
            this.TBField2.TabIndex = 6;
            // 
            // LblField1
            // 
            this.LblField1.AutoSize = true;
            this.LblField1.Location = new System.Drawing.Point(12, 42);
            this.LblField1.Name = "LblField1";
            this.LblField1.Size = new System.Drawing.Size(38, 13);
            this.LblField1.TabIndex = 9;
            this.LblField1.Text = "Field1:";
            // 
            // TBField1
            // 
            this.TBField1.Location = new System.Drawing.Point(61, 39);
            this.TBField1.Name = "TBField1";
            this.TBField1.Size = new System.Drawing.Size(211, 20);
            this.TBField1.TabIndex = 8;
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(116, 117);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 11;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(197, 117);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 10;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // frmNewStrategy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 148);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.LblField1);
            this.Controls.Add(this.TBField1);
            this.Controls.Add(this.LblField2);
            this.Controls.Add(this.TBField2);
            this.Controls.Add(this.LblField3);
            this.Controls.Add(this.TBField3);
            this.Controls.Add(this.CBStrategySelector);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmNewStrategy";
            this.Text = "frmNewStrategy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBStrategySelector;
        private System.Windows.Forms.Label LblField3;
        private System.Windows.Forms.TextBox TBField3;
        private System.Windows.Forms.Label LblField2;
        private System.Windows.Forms.TextBox TBField2;
        private System.Windows.Forms.Label LblField1;
        private System.Windows.Forms.TextBox TBField1;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnCancel;
    }
}