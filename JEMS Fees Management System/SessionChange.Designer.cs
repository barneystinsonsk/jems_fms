namespace JEMS_Fees_Management_System
{
    partial class SessionChange
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
            this.label1 = new System.Windows.Forms.Label();
            this.prev = new System.Windows.Forms.Button();
            this.next = new System.Windows.Forms.Button();
            this.classComboBox = new System.Windows.Forms.ComboBox();
            this.confirm = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ordinary = new System.Windows.Forms.Panel();
            this.detainGrid = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classTenGrid = new System.Windows.Forms.DataGridView();
            this.selection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.prom = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.st10ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.f10Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stud10cat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordinaryStudentGrid = new System.Windows.Forms.DataGridView();
            this.checkBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nclass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fatherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectAll = new System.Windows.Forms.Button();
            this.deselectAll = new System.Windows.Forms.Button();
            this.sessionTransition = new System.Windows.Forms.ComboBox();
            this.select = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.ordinary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detainGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classTenGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordinaryStudentGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Session Transition";
            // 
            // prev
            // 
            this.prev.Location = new System.Drawing.Point(212, 55);
            this.prev.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.prev.Name = "prev";
            this.prev.Size = new System.Drawing.Size(53, 28);
            this.prev.TabIndex = 3;
            this.prev.Text = "Prev";
            this.prev.UseVisualStyleBackColor = true;
            this.prev.Click += new System.EventHandler(this.prev_Click);
            // 
            // next
            // 
            this.next.Location = new System.Drawing.Point(273, 55);
            this.next.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(53, 28);
            this.next.TabIndex = 4;
            this.next.Text = "Next";
            this.next.UseVisualStyleBackColor = true;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // classComboBox
            // 
            this.classComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.classComboBox.FormattingEnabled = true;
            this.classComboBox.Location = new System.Drawing.Point(20, 58);
            this.classComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.classComboBox.Name = "classComboBox";
            this.classComboBox.Size = new System.Drawing.Size(183, 24);
            this.classComboBox.TabIndex = 5;
            this.classComboBox.SelectionChangeCommitted += new System.EventHandler(this.classComboBox_SelectionChangeCommitted);
            // 
            // confirm
            // 
            this.confirm.BackColor = System.Drawing.SystemColors.Highlight;
            this.confirm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.confirm.Location = new System.Drawing.Point(591, 55);
            this.confirm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(100, 28);
            this.confirm.TabIndex = 6;
            this.confirm.Text = "Confirm";
            this.confirm.UseVisualStyleBackColor = false;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.ordinary);
            this.groupBox1.Location = new System.Drawing.Point(20, 105);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1076, 270);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // ordinary
            // 
            this.ordinary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ordinary.Controls.Add(this.detainGrid);
            this.ordinary.Controls.Add(this.classTenGrid);
            this.ordinary.Controls.Add(this.ordinaryStudentGrid);
            this.ordinary.Location = new System.Drawing.Point(4, 20);
            this.ordinary.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ordinary.Name = "ordinary";
            this.ordinary.Size = new System.Drawing.Size(1068, 246);
            this.ordinary.TabIndex = 0;
            // 
            // detainGrid
            // 
            this.detainGrid.AllowUserToAddRows = false;
            this.detainGrid.AllowUserToDeleteRows = false;
            this.detainGrid.AllowUserToResizeColumns = false;
            this.detainGrid.AllowUserToResizeRows = false;
            this.detainGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.detainGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewComboBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.detainGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detainGrid.Location = new System.Drawing.Point(0, 0);
            this.detainGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.detainGrid.Name = "detainGrid";
            this.detainGrid.RowHeadersVisible = false;
            this.detainGrid.Size = new System.Drawing.Size(1068, 246);
            this.detainGrid.TabIndex = 2;
            this.detainGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.detainGrid_CellClick);
            this.detainGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.detainGrid_CurrentCellDirtyStateChanged);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "Selection";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn1.Width = 60;
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.HeaderText = "Detain class";
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewComboBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Student ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Father\'s Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Student Category";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Status";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // classTenGrid
            // 
            this.classTenGrid.AllowUserToAddRows = false;
            this.classTenGrid.AllowUserToDeleteRows = false;
            this.classTenGrid.AllowUserToResizeColumns = false;
            this.classTenGrid.AllowUserToResizeRows = false;
            this.classTenGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.classTenGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selection,
            this.prom,
            this.st10ID,
            this.name10,
            this.f10Name,
            this.stud10cat,
            this.status10});
            this.classTenGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.classTenGrid.Location = new System.Drawing.Point(0, 0);
            this.classTenGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.classTenGrid.Name = "classTenGrid";
            this.classTenGrid.RowHeadersVisible = false;
            this.classTenGrid.Size = new System.Drawing.Size(1068, 246);
            this.classTenGrid.TabIndex = 1;
            this.classTenGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.classTenGrid_CellClick);
            this.classTenGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.classTenGrid_CurrentCellDirtyStateChanged);
            // 
            // selection
            // 
            this.selection.HeaderText = "Selection";
            this.selection.Name = "selection";
            this.selection.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.selection.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.selection.Width = 60;
            // 
            // prom
            // 
            this.prom.HeaderText = "Promote to";
            this.prom.Name = "prom";
            this.prom.Width = 125;
            // 
            // st10ID
            // 
            this.st10ID.HeaderText = "Student ID";
            this.st10ID.Name = "st10ID";
            this.st10ID.ReadOnly = true;
            // 
            // name10
            // 
            this.name10.HeaderText = "Name";
            this.name10.Name = "name10";
            this.name10.ReadOnly = true;
            this.name10.Width = 150;
            // 
            // f10Name
            // 
            this.f10Name.HeaderText = "Father\'s Name";
            this.f10Name.Name = "f10Name";
            this.f10Name.ReadOnly = true;
            this.f10Name.Width = 150;
            // 
            // stud10cat
            // 
            this.stud10cat.HeaderText = "Student Category";
            this.stud10cat.Name = "stud10cat";
            this.stud10cat.ReadOnly = true;
            // 
            // status10
            // 
            this.status10.HeaderText = "Status";
            this.status10.Name = "status10";
            this.status10.ReadOnly = true;
            // 
            // ordinaryStudentGrid
            // 
            this.ordinaryStudentGrid.AllowUserToAddRows = false;
            this.ordinaryStudentGrid.AllowUserToDeleteRows = false;
            this.ordinaryStudentGrid.AllowUserToResizeRows = false;
            this.ordinaryStudentGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ordinaryStudentGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkBox,
            this.nclass,
            this.stID,
            this.name,
            this.fatherName,
            this.studentCategory,
            this.status});
            this.ordinaryStudentGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ordinaryStudentGrid.Location = new System.Drawing.Point(0, 0);
            this.ordinaryStudentGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ordinaryStudentGrid.Name = "ordinaryStudentGrid";
            this.ordinaryStudentGrid.RowHeadersVisible = false;
            this.ordinaryStudentGrid.Size = new System.Drawing.Size(1068, 246);
            this.ordinaryStudentGrid.TabIndex = 0;
            this.ordinaryStudentGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ordinaryStudentGrid_CellClick);
            this.ordinaryStudentGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ordinaryStudentGrid_CellContentClick);
            this.ordinaryStudentGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.ordinaryStudentGrid_CurrentCellDirtyStateChanged);
            // 
            // checkBox
            // 
            this.checkBox.HeaderText = "Selection";
            this.checkBox.Name = "checkBox";
            this.checkBox.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.checkBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.checkBox.Width = 60;
            // 
            // nclass
            // 
            this.nclass.HeaderText = "Promote to";
            this.nclass.Name = "nclass";
            this.nclass.ReadOnly = true;
            this.nclass.Width = 125;
            // 
            // stID
            // 
            this.stID.HeaderText = "Student ID";
            this.stID.Name = "stID";
            this.stID.ReadOnly = true;
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 150;
            // 
            // fatherName
            // 
            this.fatherName.HeaderText = "Father\'s Name";
            this.fatherName.Name = "fatherName";
            this.fatherName.ReadOnly = true;
            this.fatherName.Width = 150;
            // 
            // studentCategory
            // 
            this.studentCategory.HeaderText = "Student Category";
            this.studentCategory.Name = "studentCategory";
            this.studentCategory.ReadOnly = true;
            // 
            // status
            // 
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // selectAll
            // 
            this.selectAll.Location = new System.Drawing.Point(349, 55);
            this.selectAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.selectAll.Name = "selectAll";
            this.selectAll.Size = new System.Drawing.Size(100, 28);
            this.selectAll.TabIndex = 8;
            this.selectAll.Text = "Select All";
            this.selectAll.UseVisualStyleBackColor = true;
            this.selectAll.Click += new System.EventHandler(this.selectAll_Click);
            // 
            // deselectAll
            // 
            this.deselectAll.Location = new System.Drawing.Point(457, 55);
            this.deselectAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.deselectAll.Name = "deselectAll";
            this.deselectAll.Size = new System.Drawing.Size(100, 28);
            this.deselectAll.TabIndex = 9;
            this.deselectAll.Text = "Deselect All";
            this.deselectAll.UseVisualStyleBackColor = true;
            this.deselectAll.Click += new System.EventHandler(this.deselectAll_Click);
            // 
            // sessionTransition
            // 
            this.sessionTransition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sessionTransition.FormattingEnabled = true;
            this.sessionTransition.Location = new System.Drawing.Point(148, 15);
            this.sessionTransition.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sessionTransition.Name = "sessionTransition";
            this.sessionTransition.Size = new System.Drawing.Size(241, 24);
            this.sessionTransition.TabIndex = 1;
            this.sessionTransition.SelectionChangeCommitted += new System.EventHandler(this.sessionTransition_SelectionChangeCommitted);
            // 
            // select
            // 
            this.select.Location = new System.Drawing.Point(411, 12);
            this.select.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(100, 28);
            this.select.TabIndex = 10;
            this.select.Text = "Select";
            this.select.UseVisualStyleBackColor = true;
            this.select.Click += new System.EventHandler(this.select_Click);
            // 
            // SessionChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1112, 389);
            this.Controls.Add(this.select);
            this.Controls.Add(this.deselectAll);
            this.Controls.Add(this.selectAll);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.classComboBox);
            this.Controls.Add(this.next);
            this.Controls.Add(this.prev);
            this.Controls.Add(this.sessionTransition);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SessionChange";
            this.Text = "Session Change";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SessionChange_FormClosed);
            this.Load += new System.EventHandler(this.SessionChange_Load);
            this.groupBox1.ResumeLayout(false);
            this.ordinary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.detainGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classTenGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordinaryStudentGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button prev;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.ComboBox classComboBox;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel ordinary;
        private System.Windows.Forms.DataGridView ordinaryStudentGrid;
        private System.Windows.Forms.Button selectAll;
        private System.Windows.Forms.Button deselectAll;
        private System.Windows.Forms.ComboBox sessionTransition;
        private System.Windows.Forms.Button select;
        private System.Windows.Forms.DataGridView classTenGrid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn nclass;
        private System.Windows.Forms.DataGridViewTextBoxColumn stID;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fatherName;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selection;
        private System.Windows.Forms.DataGridViewComboBoxColumn prom;
        private System.Windows.Forms.DataGridViewTextBoxColumn st10ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn name10;
        private System.Windows.Forms.DataGridViewTextBoxColumn f10Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn stud10cat;
        private System.Windows.Forms.DataGridViewTextBoxColumn status10;
        private System.Windows.Forms.DataGridView detainGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
    }
}