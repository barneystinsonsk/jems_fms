namespace JEMS_Fees_Management_System
{
    partial class PaidListMonthlyForm
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
            this.PaidListMonthlyDataSet = new JEMS_Fees_Management_System.PaidListMonthlyDataSet();
            this.go = new System.Windows.Forms.Button();
            this.section = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.selectedClass = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataTable1TableAdapter = new JEMS_Fees_Management_System.PaidListMonthlyDataSetTableAdapters.DataTable1TableAdapter();
            this.to = new System.Windows.Forms.DateTimePicker();
            this.from = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.sessionBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaidListMonthlyDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // DataTable1BindingSource
            // 
            this.DataTable1BindingSource.DataMember = "DataTable1";
            this.DataTable1BindingSource.DataSource = this.PaidListMonthlyDataSet;
            // 
            // PaidListMonthlyDataSet
            // 
            this.PaidListMonthlyDataSet.DataSetName = "PaidListMonthlyDataSet";
            this.PaidListMonthlyDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // go
            // 
            this.go.Enabled = false;
            this.go.Location = new System.Drawing.Point(299, 39);
            this.go.Name = "go";
            this.go.Size = new System.Drawing.Size(75, 23);
            this.go.TabIndex = 10;
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
            this.section.Location = new System.Drawing.Point(224, 41);
            this.section.Name = "section";
            this.section.Size = new System.Drawing.Size(57, 21);
            this.section.TabIndex = 9;
            this.section.SelectedIndexChanged += new System.EventHandler(this.section_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Section";
            // 
            // selectedClass
            // 
            this.selectedClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectedClass.FormattingEnabled = true;
            this.selectedClass.Location = new System.Drawing.Point(62, 12);
            this.selectedClass.Name = "selectedClass";
            this.selectedClass.Size = new System.Drawing.Size(121, 21);
            this.selectedClass.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Class";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "PaidListMonthlyDataSet";
            reportDataSource1.Value = this.DataTable1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "JEMS_Fees_Management_System.PaidListMonthlyReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(13, 68);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(962, 181);
            this.reportViewer1.TabIndex = 11;
            // 
            // DataTable1TableAdapter
            // 
            this.DataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // to
            // 
            this.to.Location = new System.Drawing.Point(473, 12);
            this.to.Name = "to";
            this.to.Size = new System.Drawing.Size(200, 20);
            this.to.TabIndex = 15;
            // 
            // from
            // 
            this.from.Location = new System.Drawing.Point(233, 13);
            this.from.Name = "from";
            this.from.Size = new System.Drawing.Size(200, 20);
            this.from.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(447, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "To";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "From";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Session";
            // 
            // sessionBox
            // 
            this.sessionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sessionBox.FormattingEnabled = true;
            this.sessionBox.Location = new System.Drawing.Point(62, 41);
            this.sessionBox.Name = "sessionBox";
            this.sessionBox.Size = new System.Drawing.Size(93, 21);
            this.sessionBox.TabIndex = 16;
            // 
            // PaidListMonthlyForm
            // 
            this.AcceptButton = this.go;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 261);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.sessionBox);
            this.Controls.Add(this.to);
            this.Controls.Add(this.from);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.go);
            this.Controls.Add(this.section);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selectedClass);
            this.Controls.Add(this.label1);
            this.Name = "PaidListMonthlyForm";
            this.Text = "PaidListMonthlyForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PaidListMonthlyForm_FormClosed);
            this.Load += new System.EventHandler(this.PaidListMonthlyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaidListMonthlyDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button go;
        private System.Windows.Forms.ComboBox section;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox selectedClass;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DataTable1BindingSource;
        private PaidListMonthlyDataSet PaidListMonthlyDataSet;
        private PaidListMonthlyDataSetTableAdapters.DataTable1TableAdapter DataTable1TableAdapter;
        private System.Windows.Forms.DateTimePicker to;
        private System.Windows.Forms.DateTimePicker from;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox sessionBox;
    }
}