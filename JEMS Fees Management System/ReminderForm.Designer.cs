namespace JEMS_Fees_Management_System
{
    partial class ReminderForm
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.selection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.student_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.late_fees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.annualFees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.section = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Class = new System.Windows.Forms.Label();
            this.selectedClass = new System.Windows.Forms.ComboBox();
            this.print = new System.Windows.Forms.Button();
            this.rowCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selection,
            this.student_id,
            this.name,
            this.fees,
            this.late_fees,
            this.annualFees});
            this.dataGridView.Location = new System.Drawing.Point(13, 41);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.Size = new System.Drawing.Size(680, 208);
            this.dataGridView.TabIndex = 6;
            this.dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellValueChanged);
            this.dataGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridView_CurrentCellDirtyStateChanged);
            // 
            // selection
            // 
            this.selection.HeaderText = "Selection";
            this.selection.Name = "selection";
            this.selection.Width = 50;
            // 
            // student_id
            // 
            this.student_id.HeaderText = "Student ID";
            this.student_id.Name = "student_id";
            this.student_id.ReadOnly = true;
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.name.Width = 200;
            // 
            // fees
            // 
            this.fees.HeaderText = "Fees";
            this.fees.Name = "fees";
            this.fees.ReadOnly = true;
            this.fees.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.fees.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // late_fees
            // 
            this.late_fees.HeaderText = "Late Fees";
            this.late_fees.Name = "late_fees";
            this.late_fees.ReadOnly = true;
            // 
            // annualFees
            // 
            this.annualFees.HeaderText = "Annual Fees";
            this.annualFees.Name = "annualFees";
            this.annualFees.ReadOnly = true;
            // 
            // section
            // 
            this.section.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.section.FormattingEnabled = true;
            this.section.Items.AddRange(new object[] {
            "All",
            "A",
            "B",
            "C",
            "D",
            "E"});
            this.section.Location = new System.Drawing.Point(235, 14);
            this.section.Name = "section";
            this.section.Size = new System.Drawing.Size(57, 21);
            this.section.TabIndex = 11;
            this.section.SelectedIndexChanged += new System.EventHandler(this.section_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Section";
            // 
            // Class
            // 
            this.Class.AutoSize = true;
            this.Class.Location = new System.Drawing.Point(12, 17);
            this.Class.Name = "Class";
            this.Class.Size = new System.Drawing.Size(32, 13);
            this.Class.TabIndex = 9;
            this.Class.Text = "Class";
            // 
            // selectedClass
            // 
            this.selectedClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectedClass.FormattingEnabled = true;
            this.selectedClass.Location = new System.Drawing.Point(50, 14);
            this.selectedClass.Name = "selectedClass";
            this.selectedClass.Size = new System.Drawing.Size(121, 21);
            this.selectedClass.TabIndex = 8;
            this.selectedClass.SelectedIndexChanged += new System.EventHandler(this.selectedClass_SelectedIndexChanged);
            // 
            // print
            // 
            this.print.Location = new System.Drawing.Point(298, 12);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(75, 23);
            this.print.TabIndex = 12;
            this.print.Text = "Print";
            this.print.UseVisualStyleBackColor = true;
            this.print.Click += new System.EventHandler(this.print_Click);
            // 
            // rowCount
            // 
            this.rowCount.AutoSize = true;
            this.rowCount.Location = new System.Drawing.Point(379, 17);
            this.rowCount.Name = "rowCount";
            this.rowCount.Size = new System.Drawing.Size(0, 13);
            this.rowCount.TabIndex = 13;
            // 
            // ReminderForm
            // 
            this.AcceptButton = this.print;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 261);
            this.Controls.Add(this.rowCount);
            this.Controls.Add(this.print);
            this.Controls.Add(this.section);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Class);
            this.Controls.Add(this.selectedClass);
            this.Controls.Add(this.dataGridView);
            this.Name = "ReminderForm";
            this.Text = "Fees Reminder";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReminderForm_FormClosed);
            this.Load += new System.EventHandler(this.ReminderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ComboBox section;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Class;
        private System.Windows.Forms.ComboBox selectedClass;
        private System.Windows.Forms.Button print;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selection;
        private System.Windows.Forms.DataGridViewTextBoxColumn student_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fees;
        private System.Windows.Forms.DataGridViewTextBoxColumn late_fees;
        private System.Windows.Forms.DataGridViewTextBoxColumn annualFees;
        private System.Windows.Forms.Label rowCount;
    }
}