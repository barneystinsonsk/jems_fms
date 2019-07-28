namespace JEMS_Fees_Management_System
{
    partial class StudentEditMonthlyFeesForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.studentID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.studentName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.studentClass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.feesStructure = new System.Windows.Forms.DataGridView();
            this.selections = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.months = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tuition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.management = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.smart_class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.report_diary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sports = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.science = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.red_cross = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guide = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.late_fees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receiptID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.save = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.studentSession = new System.Windows.Forms.TextBox();
            this.print = new System.Windows.Forms.Button();
            this.studentSection = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.concession = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.feesStructure)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student ID";
            // 
            // studentID
            // 
            this.studentID.Location = new System.Drawing.Point(91, 12);
            this.studentID.MaxLength = 8;
            this.studentID.Name = "studentID";
            this.studentID.Size = new System.Drawing.Size(100, 20);
            this.studentID.TabIndex = 0;
            this.studentID.TextChanged += new System.EventHandler(this.studentID_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // studentName
            // 
            this.studentName.Location = new System.Drawing.Point(266, 12);
            this.studentName.Name = "studentName";
            this.studentName.ReadOnly = true;
            this.studentName.Size = new System.Drawing.Size(200, 20);
            this.studentName.TabIndex = 3;
            this.studentName.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(499, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Search by name";
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(589, 12);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(150, 20);
            this.searchBox.TabIndex = 5;
            // 
            // studentClass
            // 
            this.studentClass.Location = new System.Drawing.Point(91, 42);
            this.studentClass.Name = "studentClass";
            this.studentClass.ReadOnly = true;
            this.studentClass.Size = new System.Drawing.Size(100, 20);
            this.studentClass.TabIndex = 6;
            this.studentClass.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Class";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.feesStructure);
            this.groupBox1.Location = new System.Drawing.Point(12, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1037, 353);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fees Details";
            // 
            // feesStructure
            // 
            this.feesStructure.AllowUserToAddRows = false;
            this.feesStructure.AllowUserToDeleteRows = false;
            this.feesStructure.AllowUserToResizeColumns = false;
            this.feesStructure.AllowUserToResizeRows = false;
            this.feesStructure.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.feesStructure.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.feesStructure.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selections,
            this.months,
            this.tuition,
            this.management,
            this.smart_class,
            this.report_diary,
            this.sports,
            this.science,
            this.red_cross,
            this.guide,
            this.late_fees,
            this.total,
            this.receiptID,
            this.date});
            this.feesStructure.Location = new System.Drawing.Point(15, 28);
            this.feesStructure.Name = "feesStructure";
            this.feesStructure.RowHeadersVisible = false;
            this.feesStructure.Size = new System.Drawing.Size(1004, 308);
            this.feesStructure.TabIndex = 0;
            this.feesStructure.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.feesStructure_CellValueChanged);
            // 
            // selections
            // 
            this.selections.Frozen = true;
            this.selections.HeaderText = "Selections";
            this.selections.Name = "selections";
            this.selections.Visible = false;
            this.selections.Width = 60;
            // 
            // months
            // 
            this.months.Frozen = true;
            this.months.HeaderText = "Month";
            this.months.Name = "months";
            this.months.ReadOnly = true;
            this.months.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.months.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.months.Width = 75;
            // 
            // tuition
            // 
            this.tuition.Frozen = true;
            this.tuition.HeaderText = "Tuition";
            this.tuition.Name = "tuition";
            this.tuition.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.tuition.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tuition.Width = 75;
            // 
            // management
            // 
            this.management.Frozen = true;
            this.management.HeaderText = "Management";
            this.management.Name = "management";
            this.management.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.management.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.management.Width = 75;
            // 
            // smart_class
            // 
            this.smart_class.Frozen = true;
            this.smart_class.HeaderText = "Smart Class";
            this.smart_class.Name = "smart_class";
            this.smart_class.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.smart_class.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.smart_class.Width = 75;
            // 
            // report_diary
            // 
            this.report_diary.Frozen = true;
            this.report_diary.HeaderText = "Report Card/Diary";
            this.report_diary.Name = "report_diary";
            this.report_diary.ReadOnly = true;
            this.report_diary.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.report_diary.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.report_diary.Width = 75;
            // 
            // sports
            // 
            this.sports.Frozen = true;
            this.sports.HeaderText = "Insurance/Other Funds";
            this.sports.Name = "sports";
            this.sports.ReadOnly = true;
            this.sports.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.sports.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // science
            // 
            this.science.Frozen = true;
            this.science.HeaderText = "School Activites";
            this.science.Name = "science";
            this.science.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.science.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.science.Width = 75;
            // 
            // red_cross
            // 
            this.red_cross.Frozen = true;
            this.red_cross.HeaderText = "Computer Fees/I.P.";
            this.red_cross.Name = "red_cross";
            this.red_cross.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.red_cross.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.red_cross.Width = 75;
            // 
            // guide
            // 
            this.guide.Frozen = true;
            this.guide.HeaderText = "Local Examination";
            this.guide.Name = "guide";
            this.guide.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.guide.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.guide.Width = 75;
            // 
            // late_fees
            // 
            this.late_fees.Frozen = true;
            this.late_fees.HeaderText = "Late Fees";
            this.late_fees.Name = "late_fees";
            this.late_fees.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.late_fees.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.late_fees.Visible = false;
            this.late_fees.Width = 75;
            // 
            // total
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total.DefaultCellStyle = dataGridViewCellStyle1;
            this.total.Frozen = true;
            this.total.HeaderText = "Total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // receiptID
            // 
            this.receiptID.HeaderText = "Receipt ID";
            this.receiptID.Name = "receiptID";
            this.receiptID.ReadOnly = true;
            // 
            // date
            // 
            this.date.HeaderText = "Date";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            // 
            // save
            // 
            this.save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.save.BackColor = System.Drawing.SystemColors.Highlight;
            this.save.Location = new System.Drawing.Point(959, 461);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(90, 23);
            this.save.TabIndex = 9;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = false;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.Location = new System.Drawing.Point(783, 461);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 10;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(327, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Session";
            // 
            // studentSession
            // 
            this.studentSession.Location = new System.Drawing.Point(377, 42);
            this.studentSession.Name = "studentSession";
            this.studentSession.ReadOnly = true;
            this.studentSession.Size = new System.Drawing.Size(80, 20);
            this.studentSession.TabIndex = 14;
            this.studentSession.TabStop = false;
            // 
            // print
            // 
            this.print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.print.Location = new System.Drawing.Point(864, 461);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(89, 23);
            this.print.TabIndex = 16;
            this.print.Text = "Print Fees Card";
            this.print.UseVisualStyleBackColor = true;
            this.print.Click += new System.EventHandler(this.print_Click_1);
            // 
            // studentSection
            // 
            this.studentSection.Location = new System.Drawing.Point(266, 42);
            this.studentSection.Name = "studentSection";
            this.studentSection.ReadOnly = true;
            this.studentSection.Size = new System.Drawing.Size(44, 20);
            this.studentSection.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(216, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Section";
            // 
            // concession
            // 
            this.concession.AutoSize = true;
            this.concession.Location = new System.Drawing.Point(502, 45);
            this.concession.Name = "concession";
            this.concession.Size = new System.Drawing.Size(81, 17);
            this.concession.TabIndex = 23;
            this.concession.Text = "Concession";
            this.concession.UseVisualStyleBackColor = true;
            // 
            // StudentEditMonthlyFeesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1061, 496);
            this.Controls.Add(this.concession);
            this.Controls.Add(this.studentSection);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.print);
            this.Controls.Add(this.studentSession);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.save);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.studentClass);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.studentName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.studentID);
            this.Controls.Add(this.label1);
            this.Name = "StudentEditMonthlyFeesForm";
            this.Text = "Edit Monthly Fees";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StudentEditMonthlyFeesForm_FormClosed);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.feesStructure)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox studentID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox studentName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.TextBox studentClass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView feesStructure;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox studentSession;
        private System.Windows.Forms.Button print;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selections;
        private System.Windows.Forms.DataGridViewTextBoxColumn months;
        private System.Windows.Forms.DataGridViewTextBoxColumn tuition;
        private System.Windows.Forms.DataGridViewTextBoxColumn management;
        private System.Windows.Forms.DataGridViewTextBoxColumn smart_class;
        private System.Windows.Forms.DataGridViewTextBoxColumn report_diary;
        private System.Windows.Forms.DataGridViewTextBoxColumn sports;
        private System.Windows.Forms.DataGridViewTextBoxColumn science;
        private System.Windows.Forms.DataGridViewTextBoxColumn red_cross;
        private System.Windows.Forms.DataGridViewTextBoxColumn guide;
        private System.Windows.Forms.DataGridViewTextBoxColumn late_fees;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiptID;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.TextBox studentSection;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox concession;
    }
}
