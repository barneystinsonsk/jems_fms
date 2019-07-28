namespace JEMS_Fees_Management_System
{
    partial class TCReportForm
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
            this.TCReportDataSet = new JEMS_Fees_Management_System.TCReportDataSet();
            this.section = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Class = new System.Windows.Forms.Label();
            this.selectedClass = new System.Windows.Forms.ComboBox();
            this.go = new System.Windows.Forms.Button();
            this.to = new System.Windows.Forms.DateTimePicker();
            this.from = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.student_detailsTableAdapter = new JEMS_Fees_Management_System.TCReportDataSetTableAdapters.student_detailsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.student_detailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TCReportDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // student_detailsBindingSource
            // 
            this.student_detailsBindingSource.DataMember = "student_details";
            this.student_detailsBindingSource.DataSource = this.TCReportDataSet;
            // 
            // TCReportDataSet
            // 
            this.TCReportDataSet.DataSetName = "TCReportDataSet";
            this.TCReportDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.section.Location = new System.Drawing.Point(233, 38);
            this.section.Name = "section";
            this.section.Size = new System.Drawing.Size(57, 21);
            this.section.TabIndex = 20;
            this.section.SelectedIndexChanged += new System.EventHandler(this.section_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(184, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Section";
            // 
            // Class
            // 
            this.Class.AutoSize = true;
            this.Class.Location = new System.Drawing.Point(12, 41);
            this.Class.Name = "Class";
            this.Class.Size = new System.Drawing.Size(32, 13);
            this.Class.TabIndex = 18;
            this.Class.Text = "Class";
            // 
            // selectedClass
            // 
            this.selectedClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectedClass.FormattingEnabled = true;
            this.selectedClass.Location = new System.Drawing.Point(48, 38);
            this.selectedClass.Name = "selectedClass";
            this.selectedClass.Size = new System.Drawing.Size(121, 21);
            this.selectedClass.TabIndex = 17;
            // 
            // go
            // 
            this.go.Location = new System.Drawing.Point(305, 36);
            this.go.Name = "go";
            this.go.Size = new System.Drawing.Size(75, 23);
            this.go.TabIndex = 16;
            this.go.Text = "Go";
            this.go.UseVisualStyleBackColor = true;
            this.go.Click += new System.EventHandler(this.go_Click);
            // 
            // to
            // 
            this.to.Location = new System.Drawing.Point(293, 12);
            this.to.Name = "to";
            this.to.Size = new System.Drawing.Size(200, 20);
            this.to.TabIndex = 15;
            // 
            // from
            // 
            this.from.Location = new System.Drawing.Point(48, 12);
            this.from.Name = "from";
            this.from.Size = new System.Drawing.Size(200, 20);
            this.from.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "From";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "TCReportDataSet";
            reportDataSource1.Value = this.student_detailsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "JEMS_Fees_Management_System.TCReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(15, 65);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(691, 184);
            this.reportViewer1.TabIndex = 21;
            // 
            // student_detailsTableAdapter
            // 
            this.student_detailsTableAdapter.ClearBeforeFill = true;
            // 
            // TCReportForm
            // 
            this.AcceptButton = this.go;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 261);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.section);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Class);
            this.Controls.Add(this.selectedClass);
            this.Controls.Add(this.go);
            this.Controls.Add(this.to);
            this.Controls.Add(this.from);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TCReportForm";
            this.Text = "TC Report";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TCReportForm_FormClosed);
            this.Load += new System.EventHandler(this.TCReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.student_detailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TCReportDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox section;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Class;
        private System.Windows.Forms.ComboBox selectedClass;
        private System.Windows.Forms.Button go;
        private System.Windows.Forms.DateTimePicker to;
        private System.Windows.Forms.DateTimePicker from;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource student_detailsBindingSource;
        private TCReportDataSet TCReportDataSet;
        private TCReportDataSetTableAdapters.student_detailsTableAdapter student_detailsTableAdapter;
    }
}