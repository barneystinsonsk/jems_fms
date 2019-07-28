namespace JEMS_Fees_Management_System
{
    partial class ClearanceSlipForm
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
            this.section = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Class = new System.Windows.Forms.Label();
            this.selectedClass = new System.Windows.Forms.ComboBox();
            this.print = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.go = new System.Windows.Forms.Button();
            this.from = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.to = new System.Windows.Forms.DateTimePicker();
            this.rowCount = new System.Windows.Forms.Label();
            this.displayCount = new System.Windows.Forms.Label();
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
            this.name});
            this.dataGridView.Location = new System.Drawing.Point(13, 67);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.Size = new System.Drawing.Size(679, 259);
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
            this.section.Location = new System.Drawing.Point(230, 40);
            this.section.Name = "section";
            this.section.Size = new System.Drawing.Size(57, 21);
            this.section.TabIndex = 11;
            this.section.SelectedIndexChanged += new System.EventHandler(this.section_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Section";
            // 
            // Class
            // 
            this.Class.AutoSize = true;
            this.Class.Location = new System.Drawing.Point(7, 43);
            this.Class.Name = "Class";
            this.Class.Size = new System.Drawing.Size(32, 13);
            this.Class.TabIndex = 9;
            this.Class.Text = "Class";
            // 
            // selectedClass
            // 
            this.selectedClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectedClass.FormattingEnabled = true;
            this.selectedClass.Location = new System.Drawing.Point(45, 40);
            this.selectedClass.Name = "selectedClass";
            this.selectedClass.Size = new System.Drawing.Size(121, 21);
            this.selectedClass.TabIndex = 8;
            this.selectedClass.SelectedIndexChanged += new System.EventHandler(this.selectedClass_SelectedIndexChanged);
            // 
            // print
            // 
            this.print.Location = new System.Drawing.Point(293, 38);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(75, 23);
            this.print.TabIndex = 12;
            this.print.Text = "Print";
            this.print.UseVisualStyleBackColor = true;
            this.print.Click += new System.EventHandler(this.print_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Period";
            // 
            // go
            // 
            this.go.Location = new System.Drawing.Point(482, 9);
            this.go.Name = "go";
            this.go.Size = new System.Drawing.Size(75, 23);
            this.go.TabIndex = 14;
            this.go.Text = "Go";
            this.go.UseVisualStyleBackColor = true;
            this.go.Click += new System.EventHandler(this.go_Click);
            // 
            // from
            // 
            this.from.Location = new System.Drawing.Point(55, 12);
            this.from.Name = "from";
            this.from.Size = new System.Drawing.Size(200, 20);
            this.from.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(261, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "-";
            // 
            // to
            // 
            this.to.Location = new System.Drawing.Point(276, 12);
            this.to.Name = "to";
            this.to.Size = new System.Drawing.Size(200, 20);
            this.to.TabIndex = 17;
            // 
            // rowCount
            // 
            this.rowCount.AutoSize = true;
            this.rowCount.Location = new System.Drawing.Point(563, 14);
            this.rowCount.Name = "rowCount";
            this.rowCount.Size = new System.Drawing.Size(0, 13);
            this.rowCount.TabIndex = 18;
            // 
            // displayCount
            // 
            this.displayCount.AutoSize = true;
            this.displayCount.Location = new System.Drawing.Point(374, 43);
            this.displayCount.Name = "displayCount";
            this.displayCount.Size = new System.Drawing.Size(0, 13);
            this.displayCount.TabIndex = 19;
            // 
            // ClearanceSlipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 338);
            this.Controls.Add(this.displayCount);
            this.Controls.Add(this.rowCount);
            this.Controls.Add(this.to);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.from);
            this.Controls.Add(this.go);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.print);
            this.Controls.Add(this.section);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Class);
            this.Controls.Add(this.selectedClass);
            this.Controls.Add(this.dataGridView);
            this.Name = "ClearanceSlipForm";
            this.Text = "Clearance Slip Form";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClearanceSlipForm_FormClosed);
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
        private System.Windows.Forms.DateTimePicker to;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker from;
        private System.Windows.Forms.Button go;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selection;
        private System.Windows.Forms.DataGridViewTextBoxColumn student_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.Label rowCount;
        private System.Windows.Forms.Label displayCount;
    }
}