namespace JEMS_Fees_Management_System
{
    partial class DuesListAnnualReport
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
            this.DuesListAnnualDataSet = new JEMS_Fees_Management_System.DuesListAnnualDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.selectedClass = new System.Windows.Forms.ComboBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.student_detailsTableAdapter = new JEMS_Fees_Management_System.DuesListAnnualDataSetTableAdapters.student_detailsTableAdapter();
            this.go = new System.Windows.Forms.Button();
            this.section = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sessionBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.student_detailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DuesListAnnualDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // student_detailsBindingSource
            // 
            this.student_detailsBindingSource.DataMember = "student_details";
            this.student_detailsBindingSource.DataSource = this.DuesListAnnualDataSet;
            // 
            // DuesListAnnualDataSet
            // 
            this.DuesListAnnualDataSet.DataSetName = "DuesListAnnualDataSet";
            this.DuesListAnnualDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Class";
            // 
            // selectedClass
            // 
            this.selectedClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectedClass.FormattingEnabled = true;
            this.selectedClass.Location = new System.Drawing.Point(50, 12);
            this.selectedClass.Name = "selectedClass";
            this.selectedClass.Size = new System.Drawing.Size(121, 21);
            this.selectedClass.TabIndex = 1;
            this.selectedClass.SelectedIndexChanged += new System.EventHandler(this.selectedClass_SelectedIndexChanged);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DuesListAnnualDataSet";
            reportDataSource1.Value = this.student_detailsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "JEMS_Fees_Management_System.DuesListAnnualReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(15, 39);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(701, 310);
            this.reportViewer1.TabIndex = 2;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // student_detailsTableAdapter
            // 
            this.student_detailsTableAdapter.ClearBeforeFill = true;
            // 
            // go
            // 
            this.go.Enabled = false;
            this.go.Location = new System.Drawing.Point(468, 10);
            this.go.Name = "go";
            this.go.Size = new System.Drawing.Size(75, 23);
            this.go.TabIndex = 8;
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
            this.section.TabIndex = 7;
            this.section.SelectedIndexChanged += new System.EventHandler(this.section_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Section";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(308, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Session";
            // 
            // sessionBox
            // 
            this.sessionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sessionBox.FormattingEnabled = true;
            this.sessionBox.Location = new System.Drawing.Point(358, 12);
            this.sessionBox.Name = "sessionBox";
            this.sessionBox.Size = new System.Drawing.Size(93, 21);
            this.sessionBox.TabIndex = 9;
            // 
            // DuesListAnnualReport
            // 
            this.AcceptButton = this.go;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 361);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sessionBox);
            this.Controls.Add(this.go);
            this.Controls.Add(this.section);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.selectedClass);
            this.Controls.Add(this.label1);
            this.Name = "DuesListAnnualReport";
            this.Text = "Annual Dues List Report";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DuesListAnnualReport_FormClosed);
            this.Load += new System.EventHandler(this.DuesListAnnualReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.student_detailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DuesListAnnualDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox selectedClass;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource student_detailsBindingSource;
        private DuesListAnnualDataSet DuesListAnnualDataSet;
        private DuesListAnnualDataSetTableAdapters.student_detailsTableAdapter student_detailsTableAdapter;
        private System.Windows.Forms.Button go;
        private System.Windows.Forms.ComboBox section;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox sessionBox;
    }
}