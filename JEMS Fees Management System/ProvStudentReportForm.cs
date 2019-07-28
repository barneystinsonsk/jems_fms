using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JEMS_Fees_Management_System
{
    public partial class ProvStudentReportForm : Form
    {
        public ProvStudentReportForm()
        {
            InitializeComponent();
        }

        private void ProvStudentReportForm_Load(object sender, EventArgs e)
        {
            this.student_detailsTableAdapter.Fill(this.ProvisionalReportDataSet.student_details);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("reportDate", "Date: " + DateTime.Now.ToString("d/M/yyyy")));
            this.reportViewer1.LocalReport.SetParameters(reportParameters);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
        }

        private void ProvStudentReportForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.psForm = null;
        }
    }
}
