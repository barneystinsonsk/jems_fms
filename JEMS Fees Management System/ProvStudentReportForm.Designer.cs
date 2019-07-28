namespace JEMS_Fees_Management_System
{
    partial class ProvStudentReportForm
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
            this.ProvisionalReportDataSet = new JEMS_Fees_Management_System.ProvisionalReportDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.student_detailsTableAdapter = new JEMS_Fees_Management_System.ProvisionalReportDataSetTableAdapters.student_detailsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.student_detailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProvisionalReportDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // student_detailsBindingSource
            // 
            this.student_detailsBindingSource.DataMember = "student_details";
            this.student_detailsBindingSource.DataSource = this.ProvisionalReportDataSet;
            // 
            // ProvisionalReportDataSet
            // 
            this.ProvisionalReportDataSet.DataSetName = "ProvisionalReportDataSet";
            this.ProvisionalReportDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.student_detailsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "JEMS_Fees_Management_System.ProvStudentReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(284, 261);
            this.reportViewer1.TabIndex = 0;
            // 
            // student_detailsTableAdapter
            // 
            this.student_detailsTableAdapter.ClearBeforeFill = true;
            // 
            // ProvStudentReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ProvStudentReportForm";
            this.Text = "Provisional Student Report";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProvStudentReportForm_FormClosed);
            this.Load += new System.EventHandler(this.ProvStudentReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.student_detailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProvisionalReportDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource student_detailsBindingSource;
        private ProvisionalReportDataSet ProvisionalReportDataSet;
        private ProvisionalReportDataSetTableAdapters.student_detailsTableAdapter student_detailsTableAdapter;
    }
}