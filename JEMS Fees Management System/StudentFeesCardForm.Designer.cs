namespace JEMS_Fees_Management_System
{
    partial class StudentFeesCardForm
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
            this.StudentFeesCard = new JEMS_Fees_Management_System.StudentFeesCard();
            this.label1 = new System.Windows.Forms.Label();
            this.studentID = new System.Windows.Forms.TextBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataTable1TableAdapter = new JEMS_Fees_Management_System.StudentFeesCardTableAdapters.DataTable1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentFeesCard)).BeginInit();
            this.SuspendLayout();
            // 
            // DataTable1BindingSource
            // 
            this.DataTable1BindingSource.DataMember = "DataTable1";
            this.DataTable1BindingSource.DataSource = this.StudentFeesCard;
            // 
            // StudentFeesCard
            // 
            this.StudentFeesCard.DataSetName = "StudentFeesCard";
            this.StudentFeesCard.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student ID";
            // 
            // studentID
            // 
            this.studentID.Location = new System.Drawing.Point(76, 12);
            this.studentID.MaxLength = 8;
            this.studentID.Name = "studentID";
            this.studentID.Size = new System.Drawing.Size(100, 20);
            this.studentID.TabIndex = 1;
            this.studentID.TextChanged += new System.EventHandler(this.studentID_TextChanged);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "FeesCardDataSet";
            reportDataSource1.Value = this.DataTable1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "JEMS_Fees_Management_System.StudentFeesCardReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 50);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(669, 268);
            this.reportViewer1.TabIndex = 2;
            // 
            // DataTable1TableAdapter
            // 
            this.DataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // StudentFeesCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 330);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.studentID);
            this.Controls.Add(this.label1);
            this.Name = "StudentFeesCardForm";
            this.Text = "Student Fees Card";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StudentFeesCardForm_FormClosed);
            this.Load += new System.EventHandler(this.StudentFeesCardForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentFeesCard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox studentID;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DataTable1BindingSource;
        private StudentFeesCard StudentFeesCard;
        private StudentFeesCardTableAdapters.DataTable1TableAdapter DataTable1TableAdapter;
    }
}