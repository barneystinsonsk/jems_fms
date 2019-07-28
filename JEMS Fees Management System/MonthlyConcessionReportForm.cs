using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JEMS_Fees_Management_System
{
    public partial class MonthlyConcessionReportForm : Form
    {
        List<String> sessionArray;
        List<String> sessionIndex;

        public MonthlyConcessionReportForm()
        {
            InitializeComponent();
        }


        private void sessionSetup()
        {
            sessionArray = new List<String>();
            sessionIndex = new List<String>();
            sessionArray.Add("All sessions");
            sessionIndex.Add("%");

            using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    connection.Open();
                    String getQuery = "Select * from " + Table.session_info.tableName + " order by " +
                        Table.session_info.session + " desc;";
                    int index = 0, i = 1;
                    using (SqlCommand myCommand = new SqlCommand(getQuery, connection))
                    {
                        SqlDataReader dr = myCommand.ExecuteReader();
                        while (dr.Read())
                        {

                            int session = Convert.ToInt32(dr[Table.session_info.session]);
                            sessionArray.Add("" + session + "-" + (session + 1));
                            sessionIndex.Add("" + session);
                            if (session == GlobalVariables.currentSession) index = i;
                            i++;
                        }
                        dr.Close();
                    }

                    sessionBox.DataSource = sessionArray;
                    if (index < sessionBox.Items.Count && index >= 0)
                        sessionBox.SelectedIndex = index;

                }
                catch
                {

                }
            }
        }


        private void ConcessionReportForm_Load(object sender, EventArgs e)
        {
            sessionSetup();
        }

        private void MonthlyConcessionReportForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.mcForm = null;
        }

        private void report_go_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ConcessionReportDataSet.DataTable1' table. You can move, or remove it, as needed.
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            this.DataTable1TableAdapter.Fill(this.MonthlyConcessionReportDataSet.DataTable1, sessionIndex[sessionBox.SelectedIndex]);
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportParameters.Add(new ReportParameter("reportDate", "Date: " + DateTime.Now.ToString("d/M/yyyy")));
            reportParameters.Add(new ReportParameter("titleParameter", "Monthly Concession Report " + sessionArray[sessionBox.SelectedIndex]));
            this.reportViewer1.LocalReport.SetParameters(reportParameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
