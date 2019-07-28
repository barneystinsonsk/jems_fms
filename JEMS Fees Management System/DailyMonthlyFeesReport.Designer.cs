namespace JEMS_Fees_Management_System
{
    partial class DailyMonthlyFeesReport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.DataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DailyMonthlyFeesDataSet = new JEMS_Fees_Management_System.DailyMonthlyFeesDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataTable1TableAdapter = new JEMS_Fees_Management_System.DailyMonthlyFeesDataSetTableAdapters.DataTable1TableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.sessionBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.studentTypeBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DailyMonthlyFeesDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // DataTable1BindingSource
            // 
            this.DataTable1BindingSource.DataMember = "DataTable1";
            this.DataTable1BindingSource.DataSource = this.DailyMonthlyFeesDataSet;
            // 
            // DailyMonthlyFeesDataSet
            // 
            this.DailyMonthlyFeesDataSet.DataSetName = "DailyMonthlyFeesDataSet";
            this.DailyMonthlyFeesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(64, 15);
            this.datePicker.Margin = new System.Windows.Forms.Padding(4);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(265, 22);
            this.datePicker.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(796, 13);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource2.Name = "DMFRDataSet";
            reportDataSource2.Value = this.DataTable1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "JEMS_Fees_Management_System.DailyMonthlyFeesReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(16, 47);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1059, 290);
            this.reportViewer1.TabIndex = 3;
            // 
            // DataTable1TableAdapter
            // 
            this.DataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(339, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Session";
            // 
            // sessionBox
            // 
            this.sessionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sessionBox.FormattingEnabled = true;
            this.sessionBox.Location = new System.Drawing.Point(405, 13);
            this.sessionBox.Margin = new System.Windows.Forms.Padding(4);
            this.sessionBox.Name = "sessionBox";
            this.sessionBox.Size = new System.Drawing.Size(123, 24);
            this.sessionBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(555, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Student Type";
            // 
            // studentTypeBox
            // 
            this.studentTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.studentTypeBox.FormattingEnabled = true;
            this.studentTypeBox.Location = new System.Drawing.Point(654, 13);
            this.studentTypeBox.Name = "studentTypeBox";
            this.studentTypeBox.Size = new System.Drawing.Size(121, 24);
            this.studentTypeBox.TabIndex = 7;
            // 
            // DailyMonthlyFeesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1092, 352);
            this.Controls.Add(this.studentTypeBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sessionBox);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DailyMonthlyFeesReport";
            this.Text = "Daily Monthly Fees Report";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DailyMonthlyFeesReport_FormClosed);
            this.Load += new System.EventHandler(this.DailyMonthlyFeesReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DailyMonthlyFeesDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Button button1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DataTable1BindingSource;
        private DailyMonthlyFeesDataSet DailyMonthlyFeesDataSet;
        private DailyMonthlyFeesDataSetTableAdapters.DataTable1TableAdapter DataTable1TableAdapter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox sessionBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox studentTypeBox;
    }
}