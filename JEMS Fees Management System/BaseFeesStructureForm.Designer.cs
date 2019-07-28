namespace JEMS_Fees_Management_System
{
    partial class BaseFeesStructureForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            this.adFeesPanel = new System.Windows.Forms.Panel();
            this.baseAdFeesDone = new System.Windows.Forms.Button();
            this.admissionTable = new System.Windows.Forms.DataGridView();
            this.ad_fees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.school_dev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.furniture_fund = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lab_dev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.belt_tie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.adClassSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.anFeesPanel = new System.Windows.Forms.Panel();
            this.baseAnnualPrev = new System.Windows.Forms.Button();
            this.baseAnnualDone = new System.Windows.Forms.Button();
            this.annualTable = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.anClassSelect = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mtFeesPanel = new System.Windows.Forms.Panel();
            this.monthlyPrev = new System.Windows.Forms.Button();
            this.baseMonthlyDone = new System.Windows.Forms.Button();
            this.monthlyTable = new System.Windows.Forms.DataGridView();
            this.month = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tuition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.management = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.smart_class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.report_diary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sports = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.science = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.red_cross = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guide = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insurance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.school_activities = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.computer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.local_exam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.mtClassSelect = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.sessionPanel = new System.Windows.Forms.Panel();
            this.endSessionLabel = new System.Windows.Forms.Label();
            this.currentSession = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.sessionDone = new System.Windows.Forms.Button();
            this.adFeesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.admissionTable)).BeginInit();
            this.anFeesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.annualTable)).BeginInit();
            this.mtFeesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monthlyTable)).BeginInit();
            this.sessionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // adFeesPanel
            // 
            this.adFeesPanel.Controls.Add(this.baseAdFeesDone);
            this.adFeesPanel.Controls.Add(this.admissionTable);
            this.adFeesPanel.Controls.Add(this.label2);
            this.adFeesPanel.Controls.Add(this.adClassSelect);
            this.adFeesPanel.Controls.Add(this.label1);
            this.adFeesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adFeesPanel.Location = new System.Drawing.Point(0, 0);
            this.adFeesPanel.Name = "adFeesPanel";
            this.adFeesPanel.Size = new System.Drawing.Size(434, 161);
            this.adFeesPanel.TabIndex = 0;
            // 
            // baseAdFeesDone
            // 
            this.baseAdFeesDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.baseAdFeesDone.BackColor = System.Drawing.SystemColors.Highlight;
            this.baseAdFeesDone.Location = new System.Drawing.Point(336, 121);
            this.baseAdFeesDone.Name = "baseAdFeesDone";
            this.baseAdFeesDone.Size = new System.Drawing.Size(75, 23);
            this.baseAdFeesDone.TabIndex = 6;
            this.baseAdFeesDone.Text = "Done";
            this.baseAdFeesDone.UseVisualStyleBackColor = false;
            this.baseAdFeesDone.Click += new System.EventHandler(this.baseAdFeesDone_Click);
            // 
            // admissionTable
            // 
            this.admissionTable.AllowUserToAddRows = false;
            this.admissionTable.AllowUserToDeleteRows = false;
            this.admissionTable.AllowUserToResizeColumns = false;
            this.admissionTable.AllowUserToResizeRows = false;
            this.admissionTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.admissionTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.admissionTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ad_fees,
            this.school_dev,
            this.furniture_fund,
            this.lab_dev,
            this.caution,
            this.belt_tie,
            this.total});
            this.admissionTable.Location = new System.Drawing.Point(16, 99);
            this.admissionTable.Name = "admissionTable";
            this.admissionTable.RowHeadersVisible = false;
            this.admissionTable.Size = new System.Drawing.Size(406, 1);
            this.admissionTable.TabIndex = 5;
            this.admissionTable.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.admissionTable_CellLeave);
            this.admissionTable.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.admissionTable_CellValueChanged);
            // 
            // ad_fees
            // 
            this.ad_fees.HeaderText = "Admission Fees";
            this.ad_fees.MaxInputLength = 5;
            this.ad_fees.Name = "ad_fees";
            this.ad_fees.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ad_fees.Width = 70;
            // 
            // school_dev
            // 
            this.school_dev.HeaderText = "School Development";
            this.school_dev.MaxInputLength = 5;
            this.school_dev.Name = "school_dev";
            this.school_dev.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.school_dev.Width = 80;
            // 
            // furniture_fund
            // 
            this.furniture_fund.HeaderText = "Furniture Fund";
            this.furniture_fund.MaxInputLength = 5;
            this.furniture_fund.Name = "furniture_fund";
            this.furniture_fund.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.furniture_fund.Width = 70;
            // 
            // lab_dev
            // 
            this.lab_dev.HeaderText = "Lab Development";
            this.lab_dev.MaxInputLength = 5;
            this.lab_dev.Name = "lab_dev";
            this.lab_dev.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.lab_dev.Width = 80;
            // 
            // caution
            // 
            this.caution.HeaderText = "Caution Money";
            this.caution.MaxInputLength = 5;
            this.caution.Name = "caution";
            this.caution.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.caution.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.caution.Width = 70;
            // 
            // belt_tie
            // 
            this.belt_tie.HeaderText = "Belt & Tie";
            this.belt_tie.MaxInputLength = 5;
            this.belt_tie.Name = "belt_tie";
            this.belt_tie.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.belt_tie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.belt_tie.Width = 70;
            // 
            // total
            // 
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total.DefaultCellStyle = dataGridViewCellStyle19;
            this.total.HeaderText = "Total";
            this.total.MaxInputLength = 5;
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.total.Width = 70;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Class";
            // 
            // adClassSelect
            // 
            this.adClassSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.adClassSelect.FormattingEnabled = true;
            this.adClassSelect.Location = new System.Drawing.Point(53, 49);
            this.adClassSelect.Name = "adClassSelect";
            this.adClassSelect.Size = new System.Drawing.Size(120, 21);
            this.adClassSelect.TabIndex = 1;
            this.adClassSelect.SelectedIndexChanged += new System.EventHandler(this.adClassSelect_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Base Admission Fees Structure";
            // 
            // anFeesPanel
            // 
            this.anFeesPanel.Controls.Add(this.baseAnnualPrev);
            this.anFeesPanel.Controls.Add(this.baseAnnualDone);
            this.anFeesPanel.Controls.Add(this.annualTable);
            this.anFeesPanel.Controls.Add(this.label3);
            this.anFeesPanel.Controls.Add(this.anClassSelect);
            this.anFeesPanel.Controls.Add(this.label4);
            this.anFeesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.anFeesPanel.Location = new System.Drawing.Point(0, 0);
            this.anFeesPanel.Name = "anFeesPanel";
            this.anFeesPanel.Size = new System.Drawing.Size(434, 161);
            this.anFeesPanel.TabIndex = 1;
            // 
            // baseAnnualPrev
            // 
            this.baseAnnualPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.baseAnnualPrev.Location = new System.Drawing.Point(234, 121);
            this.baseAnnualPrev.Name = "baseAnnualPrev";
            this.baseAnnualPrev.Size = new System.Drawing.Size(75, 23);
            this.baseAnnualPrev.TabIndex = 12;
            this.baseAnnualPrev.Text = "Previous";
            this.baseAnnualPrev.UseVisualStyleBackColor = true;
            this.baseAnnualPrev.Click += new System.EventHandler(this.baseAnnualPrev_Click);
            // 
            // baseAnnualDone
            // 
            this.baseAnnualDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.baseAnnualDone.BackColor = System.Drawing.SystemColors.Highlight;
            this.baseAnnualDone.Location = new System.Drawing.Point(324, 121);
            this.baseAnnualDone.Name = "baseAnnualDone";
            this.baseAnnualDone.Size = new System.Drawing.Size(75, 23);
            this.baseAnnualDone.TabIndex = 11;
            this.baseAnnualDone.Text = "Done";
            this.baseAnnualDone.UseVisualStyleBackColor = false;
            this.baseAnnualDone.Click += new System.EventHandler(this.baseAnnualDone_Click);
            // 
            // annualTable
            // 
            this.annualTable.AllowUserToAddRows = false;
            this.annualTable.AllowUserToDeleteRows = false;
            this.annualTable.AllowUserToResizeColumns = false;
            this.annualTable.AllowUserToResizeRows = false;
            this.annualTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.annualTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.annualTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn7});
            this.annualTable.Location = new System.Drawing.Point(16, 99);
            this.annualTable.Name = "annualTable";
            this.annualTable.RowHeadersVisible = false;
            this.annualTable.Size = new System.Drawing.Size(395, 1);
            this.annualTable.TabIndex = 10;
            this.annualTable.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.annualTable_CellLeave);
            this.annualTable.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.annualTable_CellValueChanged);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "School Development";
            this.dataGridViewTextBoxColumn2.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Lab Development";
            this.dataGridViewTextBoxColumn4.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 110;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Caution Money";
            this.dataGridViewTextBoxColumn5.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewTextBoxColumn7.HeaderText = "Total";
            this.dataGridViewTextBoxColumn7.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn7.Width = 70;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Class";
            // 
            // anClassSelect
            // 
            this.anClassSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.anClassSelect.FormattingEnabled = true;
            this.anClassSelect.Location = new System.Drawing.Point(53, 49);
            this.anClassSelect.Name = "anClassSelect";
            this.anClassSelect.Size = new System.Drawing.Size(120, 21);
            this.anClassSelect.TabIndex = 8;
            this.anClassSelect.SelectedIndexChanged += new System.EventHandler(this.anClassSelect_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Base Annual Fees Structure";
            // 
            // mtFeesPanel
            // 
            this.mtFeesPanel.AutoScroll = true;
            this.mtFeesPanel.Controls.Add(this.monthlyPrev);
            this.mtFeesPanel.Controls.Add(this.baseMonthlyDone);
            this.mtFeesPanel.Controls.Add(this.monthlyTable);
            this.mtFeesPanel.Controls.Add(this.label5);
            this.mtFeesPanel.Controls.Add(this.mtClassSelect);
            this.mtFeesPanel.Controls.Add(this.label6);
            this.mtFeesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtFeesPanel.Location = new System.Drawing.Point(0, 0);
            this.mtFeesPanel.Name = "mtFeesPanel";
            this.mtFeesPanel.Size = new System.Drawing.Size(434, 161);
            this.mtFeesPanel.TabIndex = 2;
            // 
            // monthlyPrev
            // 
            this.monthlyPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.monthlyPrev.Location = new System.Drawing.Point(255, 121);
            this.monthlyPrev.Name = "monthlyPrev";
            this.monthlyPrev.Size = new System.Drawing.Size(75, 23);
            this.monthlyPrev.TabIndex = 16;
            this.monthlyPrev.Text = "Previous";
            this.monthlyPrev.UseVisualStyleBackColor = true;
            this.monthlyPrev.Click += new System.EventHandler(this.monthlyPrev_Click);
            // 
            // baseMonthlyDone
            // 
            this.baseMonthlyDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.baseMonthlyDone.BackColor = System.Drawing.SystemColors.Highlight;
            this.baseMonthlyDone.Location = new System.Drawing.Point(336, 121);
            this.baseMonthlyDone.Name = "baseMonthlyDone";
            this.baseMonthlyDone.Size = new System.Drawing.Size(75, 23);
            this.baseMonthlyDone.TabIndex = 15;
            this.baseMonthlyDone.Text = "Done";
            this.baseMonthlyDone.UseVisualStyleBackColor = false;
            this.baseMonthlyDone.Click += new System.EventHandler(this.baseMonthlyDone_Click);
            // 
            // monthlyTable
            // 
            this.monthlyTable.AllowUserToAddRows = false;
            this.monthlyTable.AllowUserToDeleteRows = false;
            this.monthlyTable.AllowUserToResizeColumns = false;
            this.monthlyTable.AllowUserToResizeRows = false;
            this.monthlyTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.monthlyTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.monthlyTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.month,
            this.tuition,
            this.management,
            this.smart_class,
            this.report_diary,
            this.sports,
            this.science,
            this.red_cross,
            this.guide,
            this.insurance,
            this.school_activities,
            this.computer,
            this.local_exam,
            this.dataGridViewTextBoxColumn8});
            this.monthlyTable.Location = new System.Drawing.Point(16, 99);
            this.monthlyTable.Name = "monthlyTable";
            this.monthlyTable.RowHeadersVisible = false;
            this.monthlyTable.Size = new System.Drawing.Size(406, 1);
            this.monthlyTable.TabIndex = 14;
            this.monthlyTable.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.monthlyTable_CellLeave);
            this.monthlyTable.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.monthlyTable_CellValueChanged);
            // 
            // month
            // 
            this.month.Frozen = true;
            this.month.HeaderText = "Month";
            this.month.Name = "month";
            this.month.ReadOnly = true;
            this.month.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.month.Width = 60;
            // 
            // tuition
            // 
            this.tuition.HeaderText = "Tuition";
            this.tuition.MaxInputLength = 5;
            this.tuition.Name = "tuition";
            this.tuition.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tuition.Width = 60;
            // 
            // management
            // 
            this.management.HeaderText = "Management";
            this.management.MaxInputLength = 5;
            this.management.Name = "management";
            this.management.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.management.Width = 80;
            // 
            // smart_class
            // 
            this.smart_class.HeaderText = "Smart Class";
            this.smart_class.MaxInputLength = 5;
            this.smart_class.Name = "smart_class";
            this.smart_class.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.smart_class.Width = 60;
            // 
            // report_diary
            // 
            this.report_diary.HeaderText = "Report Card/Diary";
            this.report_diary.MaxInputLength = 5;
            this.report_diary.Name = "report_diary";
            this.report_diary.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.report_diary.Width = 80;
            // 
            // sports
            // 
            this.sports.HeaderText = "Sports";
            this.sports.MaxInputLength = 5;
            this.sports.Name = "sports";
            this.sports.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sports.Width = 60;
            // 
            // science
            // 
            this.science.HeaderText = "Science";
            this.science.MaxInputLength = 5;
            this.science.Name = "science";
            this.science.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.science.Width = 60;
            // 
            // red_cross
            // 
            this.red_cross.HeaderText = "Red Cross";
            this.red_cross.MaxInputLength = 5;
            this.red_cross.Name = "red_cross";
            this.red_cross.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.red_cross.Width = 60;
            // 
            // guide
            // 
            this.guide.HeaderText = "Guide";
            this.guide.MaxInputLength = 5;
            this.guide.Name = "guide";
            this.guide.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.guide.Width = 60;
            // 
            // insurance
            // 
            this.insurance.HeaderText = "Insurance";
            this.insurance.MaxInputLength = 5;
            this.insurance.Name = "insurance";
            this.insurance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.insurance.Width = 60;
            // 
            // school_activities
            // 
            this.school_activities.HeaderText = "School Activities";
            this.school_activities.MaxInputLength = 5;
            this.school_activities.Name = "school_activities";
            this.school_activities.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.school_activities.Width = 80;
            // 
            // computer
            // 
            this.computer.HeaderText = "Computer Fees";
            this.computer.MaxInputLength = 5;
            this.computer.Name = "computer";
            this.computer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.computer.Width = 80;
            // 
            // local_exam
            // 
            this.local_exam.HeaderText = "Local Examination";
            this.local_exam.MaxInputLength = 5;
            this.local_exam.Name = "local_exam";
            this.local_exam.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.local_exam.Width = 80;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridViewTextBoxColumn8.HeaderText = "Total";
            this.dataGridViewTextBoxColumn8.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn8.Width = 70;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Class";
            // 
            // mtClassSelect
            // 
            this.mtClassSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mtClassSelect.FormattingEnabled = true;
            this.mtClassSelect.Location = new System.Drawing.Point(53, 49);
            this.mtClassSelect.Name = "mtClassSelect";
            this.mtClassSelect.Size = new System.Drawing.Size(120, 21);
            this.mtClassSelect.TabIndex = 12;
            this.mtClassSelect.SelectedIndexChanged += new System.EventHandler(this.mtClassSelect_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Base Monthly Fees Structure";
            // 
            // sessionPanel
            // 
            this.sessionPanel.Controls.Add(this.sessionDone);
            this.sessionPanel.Controls.Add(this.endSessionLabel);
            this.sessionPanel.Controls.Add(this.currentSession);
            this.sessionPanel.Controls.Add(this.label7);
            this.sessionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sessionPanel.Location = new System.Drawing.Point(0, 0);
            this.sessionPanel.Name = "sessionPanel";
            this.sessionPanel.Size = new System.Drawing.Size(434, 161);
            this.sessionPanel.TabIndex = 3;
            // 
            // endSessionLabel
            // 
            this.endSessionLabel.AutoSize = true;
            this.endSessionLabel.Location = new System.Drawing.Point(171, 19);
            this.endSessionLabel.Name = "endSessionLabel";
            this.endSessionLabel.Size = new System.Drawing.Size(36, 13);
            this.endSessionLabel.TabIndex = 5;
            this.endSessionLabel.Text = "-20XX";
            // 
            // currentSession
            // 
            this.currentSession.Location = new System.Drawing.Point(130, 16);
            this.currentSession.MaxLength = 4;
            this.currentSession.Name = "currentSession";
            this.currentSession.Size = new System.Drawing.Size(35, 20);
            this.currentSession.TabIndex = 4;
            this.currentSession.TextChanged += new System.EventHandler(this.currentSession_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Current Session";
            // 
            // sessionDone
            // 
            this.sessionDone.BackColor = System.Drawing.SystemColors.Highlight;
            this.sessionDone.Enabled = false;
            this.sessionDone.Location = new System.Drawing.Point(130, 42);
            this.sessionDone.Name = "sessionDone";
            this.sessionDone.Size = new System.Drawing.Size(75, 23);
            this.sessionDone.TabIndex = 6;
            this.sessionDone.Text = "Done";
            this.sessionDone.UseVisualStyleBackColor = false;
            this.sessionDone.Click += new System.EventHandler(this.sessionDone_Click);
            // 
            // BaseFeesStructureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 161);
            this.Controls.Add(this.sessionPanel);
            this.Controls.Add(this.mtFeesPanel);
            this.Controls.Add(this.adFeesPanel);
            this.Controls.Add(this.anFeesPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 200);
            this.Name = "BaseFeesStructureForm";
            this.Text = "Base Fees Structure";
            this.adFeesPanel.ResumeLayout(false);
            this.adFeesPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.admissionTable)).EndInit();
            this.anFeesPanel.ResumeLayout(false);
            this.anFeesPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.annualTable)).EndInit();
            this.mtFeesPanel.ResumeLayout(false);
            this.mtFeesPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monthlyTable)).EndInit();
            this.sessionPanel.ResumeLayout(false);
            this.sessionPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel adFeesPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView admissionTable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox adClassSelect;
        private System.Windows.Forms.Button baseAdFeesDone;
        private System.Windows.Forms.Panel anFeesPanel;
        private System.Windows.Forms.Button baseAnnualDone;
        private System.Windows.Forms.DataGridView annualTable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox anClassSelect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button baseAnnualPrev;
        private System.Windows.Forms.Panel mtFeesPanel;
        private System.Windows.Forms.DataGridView monthlyTable;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox mtClassSelect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button monthlyPrev;
        private System.Windows.Forms.Button baseMonthlyDone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ad_fees;
        private System.Windows.Forms.DataGridViewTextBoxColumn school_dev;
        private System.Windows.Forms.DataGridViewTextBoxColumn furniture_fund;
        private System.Windows.Forms.DataGridViewTextBoxColumn lab_dev;
        private System.Windows.Forms.DataGridViewTextBoxColumn caution;
        private System.Windows.Forms.DataGridViewTextBoxColumn belt_tie;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn month;
        private System.Windows.Forms.DataGridViewTextBoxColumn tuition;
        private System.Windows.Forms.DataGridViewTextBoxColumn management;
        private System.Windows.Forms.DataGridViewTextBoxColumn smart_class;
        private System.Windows.Forms.DataGridViewTextBoxColumn report_diary;
        private System.Windows.Forms.DataGridViewTextBoxColumn sports;
        private System.Windows.Forms.DataGridViewTextBoxColumn science;
        private System.Windows.Forms.DataGridViewTextBoxColumn red_cross;
        private System.Windows.Forms.DataGridViewTextBoxColumn guide;
        private System.Windows.Forms.DataGridViewTextBoxColumn insurance;
        private System.Windows.Forms.DataGridViewTextBoxColumn school_activities;
        private System.Windows.Forms.DataGridViewTextBoxColumn computer;
        private System.Windows.Forms.DataGridViewTextBoxColumn local_exam;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Panel sessionPanel;
        private System.Windows.Forms.Button sessionDone;
        private System.Windows.Forms.Label endSessionLabel;
        public System.Windows.Forms.TextBox currentSession;
        private System.Windows.Forms.Label label7;
    }
}