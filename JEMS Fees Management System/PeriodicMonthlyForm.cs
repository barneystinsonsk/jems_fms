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
    public partial class PeriodicMonthlyForm : Form
    {
        List<String> sessionArray;
        List<String> sessionIndex;

        List<String> studentTypeArray;
        List<String> studentTypeIndex;


        public PeriodicMonthlyForm()
        {
            InitializeComponent();
        }
        
        private void PeriodicMonthlyForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DailyMonthlyFeesDataSet.DataTable1' table. You can move, or remove it, as needed.
            //this.DataTable1TableAdapter.Fill(this.DailyMonthlyFeesDataSet.DataTable1);
            sessionSetup();

            studentTypeArray = new List<String>();
            studentTypeIndex = new List<String>();
            studentTypeArray.Add("All Students");
            studentTypeIndex.Add("ALL");
            studentTypeArray.Add("New Students");
            studentTypeIndex.Add("NEW");
            studentTypeArray.Add("Old Students");
            studentTypeIndex.Add("OLD");

            studentTypeBox.DataSource = studentTypeArray;

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


        private void button1_Click(object sender, EventArgs e)
        {
            this.DataTable1TableAdapter.Fill(this.DailyMonthlyFeesDataSet.DataTable1, from.Value.Date, to.Value.Date, sessionIndex[sessionBox.SelectedIndex], studentTypeIndex[studentTypeBox.SelectedIndex], GlobalVariables.currentSession); 

            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("sessionParameter", "Session: " + sessionBox.SelectedValue + "    "
                    + studentTypeBox.SelectedValue));
            reportParameters.Add(new ReportParameter("reportDate", DateTime.Now.ToShortDateString()));
            reportParameters.Add(new ReportParameter("reportDate", "Date: " + DateTime.Now.ToString("d/M/yyyy")));
            reportParameters.Add(new ReportParameter("dateParameter", "Date: " + from.Value.ToShortDateString() + " - " + to.Value.ToShortDateString()));
            this.reportViewer1.LocalReport.SetParameters(reportParameters);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
        }

        private void PeriodicMonthlyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.pmtForm = null;
        }
    }
}
