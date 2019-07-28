namespace JEMS_Fees_Management_System
{
    partial class StudentReport2Form
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.student_detailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.StudentReport2DataSet = new JEMS_Fees_Management_System.StudentReport2DataSet();
            this.stud_cat = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.go = new System.Windows.Forms.Button();
            this.section = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Class = new System.Windows.Forms.Label();
            this.selectedClass = new System.Windows.Forms.ComboBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.student_detailsTableAdapter = new JEMS_Fees_Management_System.StudentReport2DataSetTableAdapters.student_detailsTableAdapter();
            this.label3 = new System.Windows.Forms.Label();
            this.sessionBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.student_detailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentReport2DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // student_detailsBindingSource
            // 
            this.student_detailsBindingSource.DataMember = "student_details";
            this.student_detailsBindingSource.DataSource = this.StudentReport2DataSet;
            // 
            // StudentReport2DataSet
            // 
            this.StudentReport2DataSet.DataSetName = "StudentReport2DataSet";
            this.StudentReport2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stud_cat
            // 
            this.stud_cat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stud_cat.FormattingEnabled = true;
            this.stud_cat.Items.AddRange(new object[] {
            "All",
            "New",
            "Old"});
            this.stud_cat.Location = new System.Drawing.Point(408, 12);
            this.stud_cat.Name = "stud_cat";
            this.stud_cat.Size = new System.Drawing.Size(73, 21);
            this.stud_cat.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(313, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Student Category";
            // 
            // go
            // 
            this.go.Enabled = false;
            this.go.Location = new System.Drawing.Point(636, 10);
            this.go.Name = "go";
            this.go.Size = new System.Drawing.Size(75, 23);
            this.go.TabIndex = 15;
            this.go.Text = "Go";
            this.go.UseVisualStyleBackColor = true;
            this.go.Click += new System.EventHandler(this.go_Click);
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
            this.section.Location = new System.Drawing.Point(235, 12);
            this.section.Name = "section";
            this.section.Size = new System.Drawing.Size(57, 21);
            this.section.TabIndex = 14;
            this.section.SelectedIndexChanged += new System.EventHandler(this.section_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Section";
            // 
            // Class
            // 
            this.Class.AutoSize = true;
            this.Class.Location = new System.Drawing.Point(12, 15);
            this.Class.Name = "Class";
            this.Class.Size = new System.Drawing.Size(32, 13);
            this.Class.TabIndex = 12;
            this.Class.Text = "Class";
            // 
            // selectedClass
            // 
            this.selectedClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectedClass.FormattingEnabled = true;
            this.selectedClass.Location = new System.Drawing.Point(50, 12);
            this.selectedClass.Name = "selectedClass";
            this.selectedClass.Size = new System.Drawing.Size(121, 21);
            this.selectedClass.TabIndex = 11;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "StudentReport2DataSet";
            reportDataSource1.Value = this.student_detailsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "JEMS_Fees_Management_System.StudentReport2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(15, 39);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(719, 280);
            this.reportViewer1.TabIndex = 18;
            // 
            // student_detailsTableAdapter
            // 
            this.student_detailsTableAdapter.ClearBeforeFill = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(487, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Session";
            // 
            // sessionBox
            // 
            this.sessionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sessionBox.FormattingEnabled = true;
            this.sessionBox.Location = new System.Drawing.Point(537, 12);
            this.sessionBox.Name = "sessionBox";
            this.sessionBox.Size = new System.Drawing.Size(93, 21);
            this.sessionBox.TabIndex = 19;
            // 
            // StudentReport2Form
            // 
            this.AcceptButton = this.go;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 331);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sessionBox);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.stud_cat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.go);
            this.Controls.Add(this.section);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Class);
            this.Controls.Add(this.selectedClass);
            this.Name = "StudentReport2Form";
            this.Text = "Student Report 2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StudentReport2Form_FormClosed);
            this.Load += new System.EventHandler(this.StudentReport2Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.student_detailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentReport2DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox stud_cat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button go;
        private System.Windows.Forms.ComboBox section;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Class;
        private System.Windows.Forms.ComboBox selectedClass;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource student_detailsBindingSource;
        private StudentReport2DataSet StudentReport2DataSet;
        private StudentReport2DataSetTableAdapters.student_detailsTableAdapter student_detailsTableAdapter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox sessionBox;
    }
}