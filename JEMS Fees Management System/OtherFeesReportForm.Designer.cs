namespace JEMS_Fees_Management_System
{
    partial class OtherFeesReportForm
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
            this.other_fees_registerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OtherFeesDataSet = new JEMS_Fees_Management_System.OtherFeesDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.entryDate = new System.Windows.Forms.DateTimePicker();
            this.go = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.other_fees_registerTableAdapter = new JEMS_Fees_Management_System.OtherFeesDataSetTableAdapters.other_fees_registerTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.other_fees_registerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OtherFeesDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // other_fees_registerBindingSource
            // 
            this.other_fees_registerBindingSource.DataMember = "other_fees_register";
            this.other_fees_registerBindingSource.DataSource = this.OtherFeesDataSet;
            // 
            // OtherFeesDataSet
            // 
            this.OtherFeesDataSet.DataSetName = "OtherFeesDataSet";
            this.OtherFeesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Entry Date";
            // 
            // entryDate
            // 
            this.entryDate.Location = new System.Drawing.Point(75, 12);
            this.entryDate.Name = "entryDate";
            this.entryDate.Size = new System.Drawing.Size(200, 20);
            this.entryDate.TabIndex = 1;
            // 
            // go
            // 
            this.go.Location = new System.Drawing.Point(281, 9);
            this.go.Name = "go";
            this.go.Size = new System.Drawing.Size(75, 23);
            this.go.TabIndex = 3;
            this.go.Text = "Go";
            this.go.UseVisualStyleBackColor = true;
            this.go.Click += new System.EventHandler(this.go_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "OtherFeesDataSet";
            reportDataSource1.Value = this.other_fees_registerBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "JEMS_Fees_Management_System.OtherFeesReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 38);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(642, 241);
            this.reportViewer1.TabIndex = 4;
            // 
            // other_fees_registerTableAdapter
            // 
            this.other_fees_registerTableAdapter.ClearBeforeFill = true;
            // 
            // OtherFeesReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 291);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.go);
            this.Controls.Add(this.entryDate);
            this.Controls.Add(this.label1);
            this.Name = "OtherFeesReportForm";
            this.Text = "Other Fees Report";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OtherFeesReportForm_FormClosed);
            this.Load += new System.EventHandler(this.OtherFeesReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.other_fees_registerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OtherFeesDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker entryDate;
        private System.Windows.Forms.Button go;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource other_fees_registerBindingSource;
        private OtherFeesDataSet OtherFeesDataSet;
        private OtherFeesDataSetTableAdapters.other_fees_registerTableAdapter other_fees_registerTableAdapter;
    }
}