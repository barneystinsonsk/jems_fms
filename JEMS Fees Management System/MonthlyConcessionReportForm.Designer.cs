 namespace JEMS_Fees_Management_System
{
    partial class MonthlyConcessionReportForm
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
            this.DataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MonthlyConcessionReportDataSet = new JEMS_Fees_Management_System.MonthlyConcessionReportDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.report_go = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.sessionBox = new System.Windows.Forms.ComboBox();
            this.DataTable1TableAdapter = new JEMS_Fees_Management_System.MonthlyConcessionReportDataSetTableAdapters.DataTable1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthlyConcessionReportDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // DataTable1BindingSource
            // 
            this.DataTable1BindingSource.DataMember = "DataTable1";
            this.DataTable1BindingSource.DataSource = this.MonthlyConcessionReportDataSet;
            // 
            // MonthlyConcessionReportDataSet
            // 
            this.MonthlyConcessionReportDataSet.DataSetName = "MonthlyConcessionReportDataSet";
            this.MonthlyConcessionReportDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "MonthlyConcessionDataSet";
            reportDataSource1.Value = this.DataTable1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "JEMS_Fees_Management_System.MonthlyConcessionReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 39);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(284, 222);
            this.reportViewer1.TabIndex = 0;
            // 
            // report_go
            // 
            this.report_go.Location = new System.Drawing.Point(161, 10);
            this.report_go.Name = "report_go";
            this.report_go.Size = new System.Drawing.Size(75, 23);
            this.report_go.TabIndex = 6;
            this.report_go.Text = "Go";
            this.report_go.UseVisualStyleBackColor = true;
            this.report_go.Click += new System.EventHandler(this.report_go_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Session";
            // 
            // sessionBox
            // 
            this.sessionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sessionBox.FormattingEnabled = true;
            this.sessionBox.Location = new System.Drawing.Point(62, 12);
            this.sessionBox.Name = "sessionBox";
            this.sessionBox.Size = new System.Drawing.Size(93, 21);
            this.sessionBox.TabIndex = 4;
            // 
            // DataTable1TableAdapter
            // 
            this.DataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // MonthlyConcessionReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.report_go);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sessionBox);
            this.Controls.Add(this.reportViewer1);
            this.Name = "MonthlyConcessionReportForm";
            this.Text = "Monthly Concession Report";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MonthlyConcessionReportForm_FormClosed);
            this.Load += new System.EventHandler(this.ConcessionReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthlyConcessionReportDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DataTable1BindingSource;
        private MonthlyConcessionReportDataSet MonthlyConcessionReportDataSet;
        private MonthlyConcessionReportDataSetTableAdapters.DataTable1TableAdapter DataTable1TableAdapter;
        private System.Windows.Forms.Button report_go;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox sessionBox;
    }
}