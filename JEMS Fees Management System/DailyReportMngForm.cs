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
    public partial class DailyReportMngForm : Form
    {
        List<String> sessionArray;
        List<String> sessionIndex;

        List<String> studentTypeArray;
        List<String> studentTypeIndex;


        public DailyReportMngForm()
        {
            InitializeComponent();
        }

        private void DailyReportMngForm_Load(object sender, EventArgs e)
        {
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

        private void DailyReportMngForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.dMForm = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(datePicker.Value.ToLongDateString());

            DateTime dateFrom = new DateTime(datePicker.Value.Year, datePicker.Value.Month, datePicker.Value.Day);
            try
            {
                Debugger.Message(sessionIndex[sessionBox.SelectedIndex]);
                this.DataTable1TableAdapter.Fill(this.DailyMngFeesDataSet.DataTable1, dateFrom, dateFrom, sessionIndex[sessionBox.SelectedIndex], studentTypeIndex[studentTypeBox.SelectedIndex], GlobalVariables.currentSession);
                ReportParameterCollection reportParameters = new ReportParameterCollection();                
                reportParameters.Add(new ReportParameter("sessionParameter", "Session: " + sessionBox.SelectedValue + "    "
                    + studentTypeBox.SelectedValue));
                reportParameters.Add(new ReportParameter("dateParameter", "Date: " + datePicker.Value.ToShortDateString()));
                reportParameters.Add(new ReportParameter("reportDate", "Date: " + DateTime.Now.ToString("d/M/yyyy")));
                this.reportViewer1.LocalReport.SetParameters(reportParameters);
                this.reportViewer1.RefreshReport();
                this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sessionBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
