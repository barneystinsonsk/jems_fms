namespace JEMS_Fees_Management_System
{
    partial class MonthlyFeesForm
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
            this.receipt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.print = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.studentSession = new System.Windows.Forms.TextBox();
            this.totalPayment = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cheque = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.studentSection = new System.Windows.Forms.TextBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.mainFeesTotal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lateFeesTotal = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.feesStructure)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student ID";
            // 
            // studentID
            // 
            this.studentID.Location = new System.Drawing.Point(121, 15);
            this.studentID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.studentID.MaxLength = 8;
            this.studentID.Name = "studentID";
            this.studentID.Size = new System.Drawing.Size(132, 22);
            this.studentID.TabIndex = 0;
            this.studentID.TextChanged += new System.EventHandler(this.studentID_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // studentName
            // 
            this.studentName.Location = new System.Drawing.Point(355, 15);
            this.studentName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.studentName.Name = "studentName";
            this.studentName.ReadOnly = true;
            this.studentName.Size = new System.Drawing.Size(265, 22);
            this.studentName.TabIndex = 3;
            this.studentName.TabStop = false;
            // 
            // studentClass
            // 
            this.studentClass.Location = new System.Drawing.Point(121, 52);
            this.studentClass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.studentClass.Name = "studentClass";
            this.studentClass.ReadOnly = true;
            this.studentClass.Size = new System.Drawing.Size(132, 22);
            this.studentClass.TabIndex = 6;
            this.studentClass.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 55);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Class";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.feesStructure);
            this.groupBox1.Location = new System.Drawing.Point(16, 108);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1383, 485);
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
            this.receipt,
            this.date});
            this.feesStructure.Location = new System.Drawing.Point(20, 34);
            this.feesStructure.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.feesStructure.Name = "feesStructure";
            this.feesStructure.RowHeadersVisible = false;
            this.feesStructure.Size = new System.Drawing.Size(1339, 430);
            this.feesStructure.TabIndex = 0;
            this.feesStructure.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.feesStructure_CellValueChanged);
            this.feesStructure.CurrentCellDirtyStateChanged += new System.EventHandler(this.feesStructure_CurrentCellDirtyStateChanged);
            // 
            // selections
            // 
            this.selections.HeaderText = "Selections";
            this.selections.Name = "selections";
            this.selections.Width = 60;
            // 
            // months
            // 
            this.months.HeaderText = "Month";
            this.months.Name = "months";
            this.months.ReadOnly = true;
            this.months.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.months.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.months.Width = 75;
            // 
            // tuition
            // 
            this.tuition.HeaderText = "Tuition";
            this.tuition.Name = "tuition";
            this.tuition.ReadOnly = true;
            this.tuition.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.tuition.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tuition.Width = 75;
            // 
            // management
            // 
            this.management.HeaderText = "Management";
            this.management.Name = "management";
            this.management.ReadOnly = true;
            this.management.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.management.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.management.Width = 75;
            // 
            // smart_class
            // 
            this.smart_class.HeaderText = "Smart Class";
            this.smart_class.Name = "smart_class";
            this.smart_class.ReadOnly = true;
            this.smart_class.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.smart_class.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.smart_class.Width = 75;
            // 
            // report_diary
            // 
            this.report_diary.HeaderText = "Report Card/Diary";
            this.report_diary.Name = "report_diary";
            this.report_diary.ReadOnly = true;
            this.report_diary.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.report_diary.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.report_diary.Width = 75;
            // 
            // sports
            // 
            this.sports.HeaderText = "Insurance/Other Funds";
            this.sports.Name = "sports";
            this.sports.ReadOnly = true;
            this.sports.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.sports.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // science
            // 
            this.science.HeaderText = "School Activites";
            this.science.Name = "science";
            this.science.ReadOnly = true;
            this.science.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.science.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.science.Width = 75;
            // 
            // red_cross
            // 
            this.red_cross.HeaderText = "Computer Fees/I.P.";
            this.red_cross.Name = "red_cross";
            this.red_cross.ReadOnly = true;
            this.red_cross.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.red_cross.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.red_cross.Width = 75;
            // 
            // guide
            // 
            this.guide.HeaderText = "Local Examination";
            this.guide.Name = "guide";
            this.guide.ReadOnly = true;
            this.guide.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.guide.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.guide.Width = 75;
            // 
            // late_fees
            // 
            this.late_fees.HeaderText = "Late Fees";
            this.late_fees.Name = "late_fees";
            this.late_fees.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.late_fees.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.late_fees.Width = 75;
            // 
            // total
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total.DefaultCellStyle = dataGridViewCellStyle1;
            this.total.HeaderText = "Total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // receipt
            // 
            this.receipt.HeaderText = "Receipt ID";
            this.receipt.Name = "receipt";
            this.receipt.ReadOnly = true;
            // 
            // date
            // 
            this.date.HeaderText = "Date";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            // 
            // print
            // 
            this.print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.print.BackColor = System.Drawing.SystemColors.Highlight;
            this.print.Location = new System.Drawing.Point(1279, 601);
            this.print.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(120, 28);
            this.print.TabIndex = 9;
            this.print.Text = "Print Reciept";
            this.print.UseVisualStyleBackColor = false;
            this.print.Click += new System.EventHandler(this.print_Click);
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.Location = new System.Drawing.Point(1171, 601);
            this.cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(100, 28);
            this.cancel.TabIndex = 10;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(407, 55);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Session";
            // 
            // studentSession
            // 
            this.studentSession.Location = new System.Drawing.Point(473, 52);
            this.studentSession.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.studentSession.Name = "studentSession";
            this.studentSession.ReadOnly = true;
            this.studentSession.Size = new System.Drawing.Size(90, 22);
            this.studentSession.TabIndex = 14;
            this.studentSession.TabStop = false;
            // 
            // totalPayment
            // 
            this.totalPayment.Location = new System.Drawing.Point(1064, 52);
            this.totalPayment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.totalPayment.Name = "totalPayment";
            this.totalPayment.ReadOnly = true;
            this.totalPayment.Size = new System.Drawing.Size(90, 22);
            this.totalPayment.TabIndex = 15;
            this.totalPayment.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(957, 55);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Total Payment";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1168, 55);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Cheque amount";
            // 
            // cheque
            // 
            this.cheque.Location = new System.Drawing.Point(1285, 52);
            this.cheque.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cheque.Name = "cheque";
            this.cheque.Size = new System.Drawing.Size(90, 22);
            this.cheque.TabIndex = 18;
            this.cheque.Text = "0";
            this.cheque.TextChanged += new System.EventHandler(this.cheque_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(288, 55);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "Section";
            // 
            // studentSection
            // 
            this.studentSection.Location = new System.Drawing.Point(355, 52);
            this.studentSection.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.studentSection.Name = "studentSection";
            this.studentSection.ReadOnly = true;
            this.studentSection.Size = new System.Drawing.Size(35, 22);
            this.studentSection.TabIndex = 20;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(629, 15);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(265, 22);
            this.dateTimePicker.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(580, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Main Fees";
            // 
            // mainFeesTotal
            // 
            this.mainFeesTotal.Location = new System.Drawing.Point(659, 52);
            this.mainFeesTotal.Name = "mainFeesTotal";
            this.mainFeesTotal.ReadOnly = true;
            this.mainFeesTotal.Size = new System.Drawing.Size(90, 22);
            this.mainFeesTotal.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(767, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 17);
            this.label9.TabIndex = 24;
            this.label9.Text = "Late Fees";
            // 
            // lateFeesTotal
            // 
            this.lateFeesTotal.Location = new System.Drawing.Point(844, 52);
            this.lateFeesTotal.Name = "lateFeesTotal";
            this.lateFeesTotal.ReadOnly = true;
            this.lateFeesTotal.Size = new System.Drawing.Size(90, 22);
            this.lateFeesTotal.TabIndex = 25;
            // 
            // MonthlyFeesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1415, 644);
            this.Controls.Add(this.lateFeesTotal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.mainFeesTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.studentSection);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cheque);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.totalPayment);
            this.Controls.Add(this.studentSession);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.print);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.studentClass);
            this.Controls.Add(this.studentName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.studentID);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MonthlyFeesForm";
            this.Text = "Monthly Fees Collection";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MonthlyFeesForm_FormClosed);
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
        private System.Windows.Forms.TextBox studentClass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView feesStructure;
        private System.Windows.Forms.Button print;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox studentSession;
        private System.Windows.Forms.TextBox totalPayment;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox cheque;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox studentSection;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn receipt;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox mainFeesTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox lateFeesTotal;
    }
}