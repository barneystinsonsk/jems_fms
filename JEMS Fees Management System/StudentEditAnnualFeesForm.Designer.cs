namespace JEMS_Fees_Management_System
{
    partial class StudentEditAnnualFeesForm
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
            this.studentSession = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.studentClass = new System.Windows.Forms.TextBox();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.Rdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cancel = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.concession = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnFeesStructure)).BeginInit();
            this.SuspendLayout();
            // 
            // studentSession
            // 
            this.studentSession.Location = new System.Drawing.Point(266, 36);
            this.studentSession.Name = "studentSession";
            this.studentSession.ReadOnly = true;
            this.studentSession.Size = new System.Drawing.Size(80, 20);
            this.studentSession.TabIndex = 28;
            this.studentSession.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(216, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Session";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Class/Section";
            // 
            // studentClass
            // 
            this.studentClass.Location = new System.Drawing.Point(91, 36);
            this.studentClass.Name = "studentClass";
            this.studentClass.ReadOnly = true;
            this.studentClass.Size = new System.Drawing.Size(100, 20);
            this.studentClass.TabIndex = 25;
            this.studentClass.TabStop = false;
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(589, 6);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(150, 20);
            this.searchBox.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(499, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Search by name";
            // 
            // studentName
            // 
            this.studentName.Location = new System.Drawing.Point(266, 6);
            this.studentName.Name = "studentName";
            this.studentName.ReadOnly = true;
            this.studentName.Size = new System.Drawing.Size(200, 20);
            this.studentName.TabIndex = 22;
            this.studentName.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Name";
            // 
            // studentID
            // 
            this.studentID.Location = new System.Drawing.Point(91, 6);
            this.studentID.MaxLength = 8;
            this.studentID.Name = "studentID";
            this.studentID.Size = new System.Drawing.Size(100, 20);
            this.studentID.TabIndex = 19;
            this.studentID.TextChanged += new System.EventHandler(this.studentID_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Student ID";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AnFeesStructure);
            this.groupBox1.Location = new System.Drawing.Point(15, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(850, 165);
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
            this.Rdate});
            this.AnFeesStructure.Location = new System.Drawing.Point(19, 20);
            this.AnFeesStructure.Name = "AnFeesStructure";
            this.AnFeesStructure.RowHeadersVisible = false;
            this.AnFeesStructure.Size = new System.Drawing.Size(815, 129);
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
            this.receipt.HeaderText = "Receipt ID";
            this.receipt.Name = "receipt";
            this.receipt.ReadOnly = true;
            // 
            // Rdate
            // 
            this.Rdate.HeaderText = "Date";
            this.Rdate.Name = "Rdate";
            this.Rdate.ReadOnly = true;
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(669, 242);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 35;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // save
            // 
            this.save.BackColor = System.Drawing.SystemColors.Highlight;
            this.save.Location = new System.Drawing.Point(750, 242);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(90, 23);
            this.save.TabIndex = 34;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = false;
            this.save.Click += new System.EventHandler(this.print_Click);
            // 
            // concession
            // 
            this.concession.AutoSize = true;
            this.concession.Location = new System.Drawing.Point(502, 39);
            this.concession.Name = "concession";
            this.concession.Size = new System.Drawing.Size(81, 17);
            this.concession.TabIndex = 36;
            this.concession.Text = "Concession";
            this.concession.UseVisualStyleBackColor = true;
            // 
            // StudentEditAnnualFeesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(868, 293);
            this.Controls.Add(this.concession);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.save);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.studentSession);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.studentClass);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.studentName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.studentID);
            this.Controls.Add(this.label1);
            this.Name = "StudentEditAnnualFeesForm";
            this.Text = "Edit Annual Fees";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StudentEditAnnualFeesForm_FormClosed);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AnFeesStructure)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox studentSession;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox studentClass;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox studentName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox studentID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.DataGridView AnFeesStructure;
        private System.Windows.Forms.DataGridViewTextBoxColumn school_dev;
        private System.Windows.Forms.DataGridViewTextBoxColumn lab;
        private System.Windows.Forms.DataGridViewTextBoxColumn caution;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn receipt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rdate;
        private System.Windows.Forms.CheckBox concession;
    }
}
