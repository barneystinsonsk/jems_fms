namespace JEMS_Fees_Management_System
{
    partial class AnnualFeesForm
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
            this.cheque = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.totalPayment = new System.Windows.Forms.TextBox();
            this.studentSession = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.studentClass = new System.Windows.Forms.TextBox();
            this.studentName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.studentID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AnFeesStructure = new System.Windows.Forms.DataGridView();
            this.school_dev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receipt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cancel = new System.Windows.Forms.Button();
            this.print = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.concession = new System.Windows.Forms.TextBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnFeesStructure)).BeginInit();
            this.SuspendLayout();
            // 
            // cheque
            // 
            this.cheque.Location = new System.Drawing.Point(646, 42);
            this.cheque.Name = "cheque";
            this.cheque.ReadOnly = true;
            this.cheque.Size = new System.Drawing.Size(70, 20);
            this.cheque.TabIndex = 32;
            this.cheque.Text = "0";
            this.cheque.TextChanged += new System.EventHandler(this.cheque_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(558, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Cheque amount";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(362, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Total Payment";
            // 
            // totalPayment
            // 
            this.totalPayment.Location = new System.Drawing.Point(443, 42);
            this.totalPayment.Name = "totalPayment";
            this.totalPayment.ReadOnly = true;
            this.totalPayment.Size = new System.Drawing.Size(100, 20);
            this.totalPayment.TabIndex = 29;
            this.totalPayment.TabStop = false;
            // 
            // studentSession
            // 
            this.studentSession.Location = new System.Drawing.Point(266, 42);
            this.studentSession.Name = "studentSession";
            this.studentSession.ReadOnly = true;
            this.studentSession.Size = new System.Drawing.Size(80, 20);
            this.studentSession.TabIndex = 28;
            this.studentSession.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(216, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Session";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Class/Section";
            // 
            // studentClass
            // 
            this.studentClass.Location = new System.Drawing.Point(91, 42);
            this.studentClass.Name = "studentClass";
            this.studentClass.ReadOnly = true;
            this.studentClass.Size = new System.Drawing.Size(100, 20);
            this.studentClass.TabIndex = 25;
            this.studentClass.TabStop = false;
            // 
            // studentName
            // 
            this.studentName.Location = new System.Drawing.Point(266, 12);
            this.studentName.Name = "studentName";
            this.studentName.ReadOnly = true;
            this.studentName.Size = new System.Drawing.Size(200, 20);
            this.studentName.TabIndex = 22;
            this.studentName.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Name";
            // 
            // studentID
            // 
            this.studentID.Location = new System.Drawing.Point(91, 12);
            this.studentID.MaxLength = 8;
            this.studentID.Name = "studentID";
            this.studentID.Size = new System.Drawing.Size(100, 20);
            this.studentID.TabIndex = 19;
            this.studentID.TextChanged += new System.EventHandler(this.studentID_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Student ID";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AnFeesStructure);
            this.groupBox1.Location = new System.Drawing.Point(15, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(848, 165);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fees Details";
            // 
            // AnFeesStructure
            // 
            this.AnFeesStructure.AllowUserToAddRows = false;
            this.AnFeesStructure.AllowUserToDeleteRows = false;
            this.AnFeesStructure.AllowUserToResizeColumns = false;
            this.AnFeesStructure.AllowUserToResizeRows = false;
            this.AnFeesStructure.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AnFeesStructure.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AnFeesStructure.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.school_dev,
            this.lab,
            this.caution,
            this.Total,
            this.receipt,
            this.mDate});
            this.AnFeesStructure.Location = new System.Drawing.Point(19, 20);
            this.AnFeesStructure.Name = "AnFeesStructure";
            this.AnFeesStructure.RowHeadersVisible = false;
            this.AnFeesStructure.Size = new System.Drawing.Size(813, 129);
            this.AnFeesStructure.TabIndex = 0;
            this.AnFeesStructure.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.AnFeesStructure_CellValueChanged);
            // 
            // school_dev
            // 
            this.school_dev.HeaderText = "School Development";
            this.school_dev.MaxInputLength = 5;
            this.school_dev.Name = "school_dev";
            this.school_dev.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.school_dev.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.school_dev.Width = 150;
            // 
            // lab
            // 
            this.lab.HeaderText = "Lab Development";
            this.lab.MaxInputLength = 5;
            this.lab.Name = "lab";
            this.lab.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.lab.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.lab.Width = 150;
            // 
            // caution
            // 
            this.caution.HeaderText = "Caution Money";
            this.caution.MaxInputLength = 5;
            this.caution.Name = "caution";
            this.caution.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.caution.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.caution.Width = 150;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Total.Width = 150;
            // 
            // receipt
            // 
            this.receipt.HeaderText = "Reciept ID";
            this.receipt.Name = "receipt";
            this.receipt.ReadOnly = true;
            // 
            // mDate
            // 
            this.mDate.HeaderText = "Date";
            this.mDate.Name = "mDate";
            this.mDate.ReadOnly = true;
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(644, 248);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 35;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // print
            // 
            this.print.BackColor = System.Drawing.SystemColors.Highlight;
            this.print.Location = new System.Drawing.Point(725, 248);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(90, 23);
            this.print.TabIndex = 34;
            this.print.Text = "Print Reciept";
            this.print.UseVisualStyleBackColor = false;
            this.print.Click += new System.EventHandler(this.print_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(722, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Concession";
            // 
            // concession
            // 
            this.concession.Location = new System.Drawing.Point(790, 42);
            this.concession.Name = "concession";
            this.concession.ReadOnly = true;
            this.concession.Size = new System.Drawing.Size(73, 20);
            this.concession.TabIndex = 37;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(472, 12);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 38;
            // 
            // AnnualFeesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(971, 293);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.concession);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.print);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cheque);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.totalPayment);
            this.Controls.Add(this.studentSession);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.studentClass);
            this.Controls.Add(this.studentName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.studentID);
            this.Controls.Add(this.label1);
            this.Name = "AnnualFeesForm";
            this.Text = "Annual Fees Collection";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AnnualFeesForm_FormClosed);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AnFeesStructure)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox cheque;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox totalPayment;
        private System.Windows.Forms.TextBox studentSession;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox studentClass;
        private System.Windows.Forms.TextBox studentName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox studentID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button print;
        private System.Windows.Forms.DataGridView AnFeesStructure;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox concession;
        private System.Windows.Forms.DataGridViewTextBoxColumn school_dev;
        private System.Windows.Forms.DataGridViewTextBoxColumn lab;
        private System.Windows.Forms.DataGridViewTextBoxColumn caution;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn receipt;
        private System.Windows.Forms.DataGridViewTextBoxColumn mDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
    }
}