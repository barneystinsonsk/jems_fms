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
    public partial class OtherFeesReportForm : Form
    {
        public OtherFeesReportForm()
        {
            InitializeComponent();
        }

        private void OtherFeesReportForm_Load(object sender, EventArgs e)
        {
            
        }

        private void go_Click(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            this.other_fees_registerTableAdapter.Fill(this.OtherFeesDataSet.other_fees_register,
                entryDate.Value.Date);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("reportNameParameter", "Other Fees: " + entryDate.Value.ToLongDateString() + " Session: " + GlobalVariables.currentSession + "-" + (GlobalVariables.currentSession + 1)));
            reportParameters.Add(new ReportParameter("reportDate", "Date: " + DateTime.Now.ToString("d/M/yyyy")));
            this.reportViewer1.LocalReport.SetParameters(reportParameters);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);

        }

        private void OtherFeesReportForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.orForm = null;
        }
    }
}
