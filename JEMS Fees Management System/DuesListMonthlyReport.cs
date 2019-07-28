using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JEMS_Fees_Management_System
{
    public partial class DuesListMonthlyReport : Form
    {
        List<String> sessionArray;
        List<String> sessionIndex;

        public DuesListMonthlyReport()
        {
            InitializeComponent();

        }

        private void DuesListMonthlyReport_Load(object sender, EventArgs e)
        {
            List<String> classes = Classes.classBranchNameArray.ToList();
            classes.RemoveRange(13, 6);
            classes.Add("Class 11 Com");
            classes.Add("Class 11 Sci");
            classes.Add("Class 12 Com");
            classes.Add("Class 12 Sci");

            selectedClass.DataSource = classes;
            sessionSetup();
            
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

        private void DuesListMonthlyReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.dLMForm = null;
        }

        private void selectedClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void go_Click(object sender, EventArgs e)
        {
            String class1 = "", class2 = "";
            String theClass = selectedClass.SelectedValue.ToString();
            if (selectedClass.SelectedIndex < 13)
            {
                class1 = class2 = Classes.classArray[selectedClass.SelectedIndex];

            }
            else
            {
                int s = selectedClass.SelectedIndex;
                if (s == 13)
                {
                    class1 = Classes.classArray[13];
                    class2 = Classes.classArray[14];
                }
                else if (s == 14)
                {
                    class1 = class2 = Classes.classArray[15];
                }
                else if (s == 15)
                {
                    class1 = Classes.classArray[16];
                    class2 = Classes.classArray[17];
                }
                else
                {
                    class1 = class2 = Classes.classArray[18];
                }
            }

                        
            //int thisMonth = (DateTime.Now.Month + 8) % 12 + 1;
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            DateTime today;
            today = DateTime.Now;
            //int thisMonth = CommonMethods.actualMonthToSessionMonth(today.Month);
            int thisMonth = today.Month;

            //MessageBox.Show("es" + " mt" + thisMonth);

            int effective_session = (thisMonth <= 3) ? (today.Year - 1) : (today.Year);

            thisMonth = CommonMethods.actualMonthToSessionMonth(thisMonth);

            if (today.Date.Day > GlobalVariables.warnDate) thisMonth++;

            if (effective_session > GlobalVariables.currentSession) thisMonth = 13;

            //MessageBox.Show("es" + effective_session + " mt" + thisMonth);

            if (section.SelectedIndex == 0)
            {
                this.DataTable1TableAdapter.Fill(this.DuesListMonthly.DataTable1, sessionIndex[sessionBox.SelectedIndex], thisMonth, effective_session, class1, class2, "A", "B", "C", "D", "E");
                reportParameters.Add(new ReportParameter("classParameter", theClass + " Session: " + sessionArray[sessionBox.SelectedIndex]));
            }
            else if(section.SelectedIndex >0)
            {
                int val = section.SelectedIndex;
                String[] s = { "", "A", "B", "C", "D", "E"};
                this.DataTable1TableAdapter.Fill(this.DuesListMonthly.DataTable1, sessionIndex[sessionBox.SelectedIndex], thisMonth, effective_session, class1, class2, s[val], s[val], s[val], s[val], s[val]);
                reportParameters.Add(new ReportParameter("classParameter", theClass + " - " + s[val] + " Session: " + sessionArray[sessionBox.SelectedIndex]));
            }

            reportParameters.Add(new ReportParameter("monthParameter", "Dues List Monthly Fees [" +
                CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month) + " " +
                DateTime.Now.Year +
                "]"));
            reportParameters.Add(new ReportParameter("reportDate", "Date: " + DateTime.Now.ToString("d/M/yyyy")));
            try
            {
                this.reportViewer1.LocalReport.SetParameters(reportParameters);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.reportViewer1.RefreshReport();
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
        }

        private void section_SelectedIndexChanged(object sender, EventArgs e)
        {
            go.Enabled = true;
        }
    }
}
