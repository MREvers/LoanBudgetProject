using System.Windows.Forms;

namespace BudgetProjectionProject.Forms
{
    partial class frmMain
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
            this.FSControl = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSimulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadProjectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.strategiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loansToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GBDetails = new System.Windows.Forms.GroupBox();
            this.BtnSLA = new System.Windows.Forms.Button();
            this.BtnForward = new System.Windows.Forms.Button();
            this.BtnBack = new System.Windows.Forms.Button();
            this.TBCDetails = new System.Windows.Forms.TabControl();
            this.TbPageSimulation = new System.Windows.Forms.TabPage();
            this.TBSimulationDetails = new System.Windows.Forms.TextBox();
            this.TbPageDetails = new System.Windows.Forms.TabPage();
            this.TBSelectionDetails = new System.Windows.Forms.TextBox();
            this.TbPageMonth = new System.Windows.Forms.TabPage();
            this.TBMonthDetails = new System.Windows.Forms.TextBox();
            this.BtnRun = new System.Windows.Forms.Button();
            this.GBLoans = new System.Windows.Forms.GroupBox();
            this.BtnRemoveLoan = new System.Windows.Forms.Button();
            this.BtnAddLoan = new System.Windows.Forms.Button();
            this.LBLoans = new System.Windows.Forms.ListBox();
            this.GBBudget = new System.Windows.Forms.GroupBox();
            this.BtnMoreOptions = new System.Windows.Forms.Button();
            this.BtnRemoveDelta = new System.Windows.Forms.Button();
            this.BtnAddIncome = new System.Windows.Forms.Button();
            this.NUDSavings = new System.Windows.Forms.NumericUpDown();
            this.LBDeltas = new System.Windows.Forms.ListBox();
            this.LBSavings = new System.Windows.Forms.Label();
            this.LblDeltas = new System.Windows.Forms.Label();
            this.BtnAddExpense = new System.Windows.Forms.Button();
            this.FSControl.SuspendLayout();
            this.GBDetails.SuspendLayout();
            this.TBCDetails.SuspendLayout();
            this.TbPageSimulation.SuspendLayout();
            this.TbPageDetails.SuspendLayout();
            this.TbPageMonth.SuspendLayout();
            this.GBLoans.SuspendLayout();
            this.GBBudget.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDSavings)).BeginInit();
            this.SuspendLayout();
            // 
            // FSControl
            // 
            this.FSControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.FSControl.Location = new System.Drawing.Point(0, 0);
            this.FSControl.Name = "FSControl";
            this.FSControl.Size = new System.Drawing.Size(559, 24);
            this.FSControl.TabIndex = 0;
            this.FSControl.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveSimulationToolStripMenuItem,
            this.loadProjectionToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectionToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // projectionToolStripMenuItem
            // 
            this.projectionToolStripMenuItem.Name = "projectionToolStripMenuItem";
            this.projectionToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.projectionToolStripMenuItem.Text = "Projection";
            this.projectionToolStripMenuItem.Click += new System.EventHandler(this.projectionToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.saveToolStripMenuItem.Text = "Save Projection";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveSimulationToolStripMenuItem
            // 
            this.saveSimulationToolStripMenuItem.Name = "saveSimulationToolStripMenuItem";
            this.saveSimulationToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.saveSimulationToolStripMenuItem.Text = "Save Simulation";
            this.saveSimulationToolStripMenuItem.Click += new System.EventHandler(this.saveSimulationToolStripMenuItem_Click);
            // 
            // loadProjectionToolStripMenuItem
            // 
            this.loadProjectionToolStripMenuItem.Name = "loadProjectionToolStripMenuItem";
            this.loadProjectionToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.loadProjectionToolStripMenuItem.Text = "Load Projection";
            this.loadProjectionToolStripMenuItem.Click += new System.EventHandler(this.loadProjectionToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.strategiesToolStripMenuItem,
            this.loansToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // strategiesToolStripMenuItem
            // 
            this.strategiesToolStripMenuItem.Name = "strategiesToolStripMenuItem";
            this.strategiesToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.strategiesToolStripMenuItem.Text = "Strategies";
            this.strategiesToolStripMenuItem.Click += new System.EventHandler(this.strategiesToolStripMenuItem_Click);
            // 
            // loansToolStripMenuItem
            // 
            this.loansToolStripMenuItem.Name = "loansToolStripMenuItem";
            this.loansToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.loansToolStripMenuItem.Text = "Loans";
            this.loansToolStripMenuItem.Click += new System.EventHandler(this.loansToolStripMenuItem_Click);
            // 
            // GBDetails
            // 
            this.GBDetails.Controls.Add(this.BtnSLA);
            this.GBDetails.Controls.Add(this.BtnForward);
            this.GBDetails.Controls.Add(this.BtnBack);
            this.GBDetails.Controls.Add(this.TBCDetails);
            this.GBDetails.Controls.Add(this.BtnRun);
            this.GBDetails.Location = new System.Drawing.Point(12, 240);
            this.GBDetails.Name = "GBDetails";
            this.GBDetails.Size = new System.Drawing.Size(535, 268);
            this.GBDetails.TabIndex = 1;
            this.GBDetails.TabStop = false;
            this.GBDetails.Text = "Details";
            // 
            // BtnSLA
            // 
            this.BtnSLA.Location = new System.Drawing.Point(334, 235);
            this.BtnSLA.Name = "BtnSLA";
            this.BtnSLA.Size = new System.Drawing.Size(106, 23);
            this.BtnSLA.TabIndex = 14;
            this.BtnSLA.Text = "Repayment Plans";
            this.BtnSLA.UseVisualStyleBackColor = true;
            this.BtnSLA.Click += new System.EventHandler(this.BtnSLA_Click);
            // 
            // BtnForward
            // 
            this.BtnForward.Location = new System.Drawing.Point(92, 235);
            this.BtnForward.Name = "BtnForward";
            this.BtnForward.Size = new System.Drawing.Size(75, 23);
            this.BtnForward.TabIndex = 16;
            this.BtnForward.Text = ">>";
            this.BtnForward.UseVisualStyleBackColor = true;
            this.BtnForward.Click += new System.EventHandler(this.BtnForward_Click);
            // 
            // BtnBack
            // 
            this.BtnBack.Location = new System.Drawing.Point(11, 235);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(75, 23);
            this.BtnBack.TabIndex = 15;
            this.BtnBack.Text = "<<";
            this.BtnBack.UseVisualStyleBackColor = true;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // TBCDetails
            // 
            this.TBCDetails.Controls.Add(this.TbPageSimulation);
            this.TBCDetails.Controls.Add(this.TbPageDetails);
            this.TBCDetails.Controls.Add(this.TbPageMonth);
            this.TBCDetails.Location = new System.Drawing.Point(11, 19);
            this.TBCDetails.Name = "TBCDetails";
            this.TBCDetails.SelectedIndex = 0;
            this.TBCDetails.Size = new System.Drawing.Size(518, 214);
            this.TBCDetails.TabIndex = 14;
            this.TBCDetails.SelectedIndexChanged += new System.EventHandler(this.TBCMonth_SelectedIndexChanged);
            // 
            // TbPageSimulation
            // 
            this.TbPageSimulation.Controls.Add(this.TBSimulationDetails);
            this.TbPageSimulation.Location = new System.Drawing.Point(4, 22);
            this.TbPageSimulation.Name = "TbPageSimulation";
            this.TbPageSimulation.Padding = new System.Windows.Forms.Padding(3);
            this.TbPageSimulation.Size = new System.Drawing.Size(510, 188);
            this.TbPageSimulation.TabIndex = 2;
            this.TbPageSimulation.Text = "Simulation";
            this.TbPageSimulation.UseVisualStyleBackColor = true;
            // 
            // TBSimulationDetails
            // 
            this.TBSimulationDetails.BackColor = System.Drawing.SystemColors.Window;
            this.TBSimulationDetails.Location = new System.Drawing.Point(6, 6);
            this.TBSimulationDetails.Multiline = true;
            this.TBSimulationDetails.Name = "TBSimulationDetails";
            this.TBSimulationDetails.ReadOnly = true;
            this.TBSimulationDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TBSimulationDetails.Size = new System.Drawing.Size(498, 176);
            this.TBSimulationDetails.TabIndex = 0;
            // 
            // TbPageDetails
            // 
            this.TbPageDetails.Controls.Add(this.TBSelectionDetails);
            this.TbPageDetails.Location = new System.Drawing.Point(4, 22);
            this.TbPageDetails.Name = "TbPageDetails";
            this.TbPageDetails.Padding = new System.Windows.Forms.Padding(3);
            this.TbPageDetails.Size = new System.Drawing.Size(510, 188);
            this.TbPageDetails.TabIndex = 3;
            this.TbPageDetails.Text = "Selection";
            this.TbPageDetails.UseVisualStyleBackColor = true;
            // 
            // TBSelectionDetails
            // 
            this.TBSelectionDetails.BackColor = System.Drawing.SystemColors.Window;
            this.TBSelectionDetails.Location = new System.Drawing.Point(6, 6);
            this.TBSelectionDetails.Multiline = true;
            this.TBSelectionDetails.Name = "TBSelectionDetails";
            this.TBSelectionDetails.ReadOnly = true;
            this.TBSelectionDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TBSelectionDetails.Size = new System.Drawing.Size(498, 176);
            this.TBSelectionDetails.TabIndex = 0;
            // 
            // TbPageMonth
            // 
            this.TbPageMonth.Controls.Add(this.TBMonthDetails);
            this.TbPageMonth.Location = new System.Drawing.Point(4, 22);
            this.TbPageMonth.Name = "TbPageMonth";
            this.TbPageMonth.Padding = new System.Windows.Forms.Padding(3);
            this.TbPageMonth.Size = new System.Drawing.Size(510, 188);
            this.TbPageMonth.TabIndex = 0;
            this.TbPageMonth.Text = "Month";
            this.TbPageMonth.UseVisualStyleBackColor = true;
            // 
            // TBMonthDetails
            // 
            this.TBMonthDetails.Location = new System.Drawing.Point(6, 6);
            this.TBMonthDetails.Multiline = true;
            this.TBMonthDetails.Name = "TBMonthDetails";
            this.TBMonthDetails.ReadOnly = true;
            this.TBMonthDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TBMonthDetails.Size = new System.Drawing.Size(498, 176);
            this.TBMonthDetails.TabIndex = 0;
            // 
            // BtnRun
            // 
            this.BtnRun.Location = new System.Drawing.Point(444, 235);
            this.BtnRun.Name = "BtnRun";
            this.BtnRun.Size = new System.Drawing.Size(85, 23);
            this.BtnRun.TabIndex = 13;
            this.BtnRun.Text = "Run";
            this.BtnRun.UseVisualStyleBackColor = true;
            this.BtnRun.Click += new System.EventHandler(this.BtnRun_Click);
            // 
            // GBLoans
            // 
            this.GBLoans.Controls.Add(this.BtnRemoveLoan);
            this.GBLoans.Controls.Add(this.BtnAddLoan);
            this.GBLoans.Controls.Add(this.LBLoans);
            this.GBLoans.Location = new System.Drawing.Point(12, 39);
            this.GBLoans.Name = "GBLoans";
            this.GBLoans.Size = new System.Drawing.Size(217, 191);
            this.GBLoans.TabIndex = 2;
            this.GBLoans.TabStop = false;
            this.GBLoans.Text = "Loans";
            // 
            // BtnRemoveLoan
            // 
            this.BtnRemoveLoan.Enabled = false;
            this.BtnRemoveLoan.Location = new System.Drawing.Point(114, 159);
            this.BtnRemoveLoan.Name = "BtnRemoveLoan";
            this.BtnRemoveLoan.Size = new System.Drawing.Size(97, 23);
            this.BtnRemoveLoan.TabIndex = 13;
            this.BtnRemoveLoan.Text = "Remove Loan";
            this.BtnRemoveLoan.UseVisualStyleBackColor = true;
            this.BtnRemoveLoan.Visible = false;
            this.BtnRemoveLoan.Click += new System.EventHandler(this.BtnRemoveLoan_Click);
            // 
            // BtnAddLoan
            // 
            this.BtnAddLoan.Location = new System.Drawing.Point(6, 159);
            this.BtnAddLoan.Name = "BtnAddLoan";
            this.BtnAddLoan.Size = new System.Drawing.Size(102, 23);
            this.BtnAddLoan.TabIndex = 12;
            this.BtnAddLoan.Text = "Manage Loans";
            this.BtnAddLoan.UseVisualStyleBackColor = true;
            this.BtnAddLoan.Click += new System.EventHandler(this.BtnAddLoan_Click);
            // 
            // LBLoans
            // 
            this.LBLoans.FormattingEnabled = true;
            this.LBLoans.Location = new System.Drawing.Point(6, 19);
            this.LBLoans.Name = "LBLoans";
            this.LBLoans.Size = new System.Drawing.Size(205, 134);
            this.LBLoans.TabIndex = 1;
            this.LBLoans.SelectedIndexChanged += new System.EventHandler(this.LBLoans_SelectedIndexChanged);
            // 
            // GBBudget
            // 
            this.GBBudget.Controls.Add(this.BtnMoreOptions);
            this.GBBudget.Controls.Add(this.BtnRemoveDelta);
            this.GBBudget.Controls.Add(this.BtnAddIncome);
            this.GBBudget.Controls.Add(this.NUDSavings);
            this.GBBudget.Controls.Add(this.LBDeltas);
            this.GBBudget.Controls.Add(this.LBSavings);
            this.GBBudget.Controls.Add(this.LblDeltas);
            this.GBBudget.Controls.Add(this.BtnAddExpense);
            this.GBBudget.Location = new System.Drawing.Point(235, 39);
            this.GBBudget.Name = "GBBudget";
            this.GBBudget.Size = new System.Drawing.Size(312, 191);
            this.GBBudget.TabIndex = 3;
            this.GBBudget.TabStop = false;
            this.GBBudget.Text = "Budget";
            // 
            // BtnMoreOptions
            // 
            this.BtnMoreOptions.Location = new System.Drawing.Point(6, 159);
            this.BtnMoreOptions.Name = "BtnMoreOptions";
            this.BtnMoreOptions.Size = new System.Drawing.Size(85, 23);
            this.BtnMoreOptions.TabIndex = 13;
            this.BtnMoreOptions.Text = "More Options";
            this.BtnMoreOptions.UseVisualStyleBackColor = true;
            this.BtnMoreOptions.Click += new System.EventHandler(this.BtnBudgetSettings_Click);
            // 
            // BtnRemoveDelta
            // 
            this.BtnRemoveDelta.Location = new System.Drawing.Point(6, 130);
            this.BtnRemoveDelta.Name = "BtnRemoveDelta";
            this.BtnRemoveDelta.Size = new System.Drawing.Size(85, 23);
            this.BtnRemoveDelta.TabIndex = 12;
            this.BtnRemoveDelta.Text = "Remove";
            this.BtnRemoveDelta.UseVisualStyleBackColor = true;
            this.BtnRemoveDelta.Click += new System.EventHandler(this.BtnRemoveDelta_Click);
            // 
            // BtnAddIncome
            // 
            this.BtnAddIncome.Location = new System.Drawing.Point(6, 72);
            this.BtnAddIncome.Name = "BtnAddIncome";
            this.BtnAddIncome.Size = new System.Drawing.Size(85, 23);
            this.BtnAddIncome.TabIndex = 11;
            this.BtnAddIncome.Text = "Add Income";
            this.BtnAddIncome.UseVisualStyleBackColor = true;
            this.BtnAddIncome.Click += new System.EventHandler(this.BtnAddIncome_Click);
            // 
            // NUDSavings
            // 
            this.NUDSavings.DecimalPlaces = 2;
            this.NUDSavings.Location = new System.Drawing.Point(10, 46);
            this.NUDSavings.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.NUDSavings.Name = "NUDSavings";
            this.NUDSavings.Size = new System.Drawing.Size(114, 20);
            this.NUDSavings.TabIndex = 10;
            this.NUDSavings.ThousandsSeparator = true;
            this.NUDSavings.ValueChanged += new System.EventHandler(this.NUDSavings_ValueChanged);
            // 
            // LBDeltas
            // 
            this.LBDeltas.FormattingEnabled = true;
            this.LBDeltas.Location = new System.Drawing.Point(130, 38);
            this.LBDeltas.Name = "LBDeltas";
            this.LBDeltas.Size = new System.Drawing.Size(176, 147);
            this.LBDeltas.TabIndex = 6;
            this.LBDeltas.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.LBDeltas_DrawItem);
            this.LBDeltas.SelectedIndexChanged += new System.EventHandler(this.LBDeltas_SelectedIndexChanged);
            // 
            // LBSavings
            // 
            this.LBSavings.AutoSize = true;
            this.LBSavings.Location = new System.Drawing.Point(7, 30);
            this.LBSavings.Name = "LBSavings";
            this.LBSavings.Size = new System.Drawing.Size(48, 13);
            this.LBSavings.TabIndex = 5;
            this.LBSavings.Text = "Savings:";
            // 
            // LblDeltas
            // 
            this.LblDeltas.AutoSize = true;
            this.LblDeltas.Location = new System.Drawing.Point(139, 22);
            this.LblDeltas.Name = "LblDeltas";
            this.LblDeltas.Size = new System.Drawing.Size(145, 13);
            this.LblDeltas.TabIndex = 2;
            this.LblDeltas.Text = "Fixed Expenses and Incomes";
            // 
            // BtnAddExpense
            // 
            this.BtnAddExpense.Location = new System.Drawing.Point(6, 101);
            this.BtnAddExpense.Name = "BtnAddExpense";
            this.BtnAddExpense.Size = new System.Drawing.Size(85, 23);
            this.BtnAddExpense.TabIndex = 1;
            this.BtnAddExpense.Text = "Add Expense";
            this.BtnAddExpense.UseVisualStyleBackColor = true;
            this.BtnAddExpense.Click += new System.EventHandler(this.BtnAddExpense_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 520);
            this.Controls.Add(this.GBBudget);
            this.Controls.Add(this.GBLoans);
            this.Controls.Add(this.GBDetails);
            this.Controls.Add(this.FSControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.FSControl;
            this.Name = "frmMain";
            this.Text = "Main";
            this.FSControl.ResumeLayout(false);
            this.FSControl.PerformLayout();
            this.GBDetails.ResumeLayout(false);
            this.TBCDetails.ResumeLayout(false);
            this.TbPageSimulation.ResumeLayout(false);
            this.TbPageSimulation.PerformLayout();
            this.TbPageDetails.ResumeLayout(false);
            this.TbPageDetails.PerformLayout();
            this.TbPageMonth.ResumeLayout(false);
            this.TbPageMonth.PerformLayout();
            this.GBLoans.ResumeLayout(false);
            this.GBBudget.ResumeLayout(false);
            this.GBBudget.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDSavings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip FSControl;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem strategiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loansToolStripMenuItem;
        private System.Windows.Forms.GroupBox GBDetails;
        private System.Windows.Forms.GroupBox GBLoans;
        private System.Windows.Forms.ListBox LBLoans;
        private System.Windows.Forms.GroupBox GBBudget;
        private System.Windows.Forms.Button BtnAddExpense;
        private System.Windows.Forms.Label LBSavings;
        private System.Windows.Forms.Label LblDeltas;
        private System.Windows.Forms.ListBox LBDeltas;
        private NumericUpDown NUDSavings;
        private Button BtnAddIncome;
        private Button BtnAddLoan;
        private ToolStripMenuItem saveToolStripMenuItem;
        private Button BtnRun;
        private ToolStripMenuItem saveSimulationToolStripMenuItem;
        private Button BtnForward;
        private Button BtnBack;
        private Button BtnRemoveDelta;
        private Button BtnMoreOptions;
        private Button BtnRemoveLoan;
        private Button BtnSLA;
        private TabControl TBCDetails;
        private TabPage TbPageSimulation;
        private TextBox TBSimulationDetails;
        private TabPage TbPageDetails;
        private TextBox TBSelectionDetails;
        private TabPage TbPageMonth;
        private TextBox TBMonthDetails;
        private ToolStripMenuItem loadProjectionToolStripMenuItem;
    }
}