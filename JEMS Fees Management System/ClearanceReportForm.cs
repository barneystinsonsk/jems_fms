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
    public partial class ClearanceReportForm : Form
    {
        List<String> sessionArray;
        List<String> sessionIndex;

        public ClearanceReportForm()
        {
            InitializeComponent();

        }

        private void sessionSetup()
        {
            sessionArray = new List<String>();
            sessionIndex = new List<String>();

            using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    connection.Open();
                    String getQuery = "Select * from " + Table.session_info.tableName + " order by " +
                        Table.session_info.session + " desc;";
                    int index = 0, i = 0;
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

        private void ClearanceReportForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ClearanceReportDataSet.student_details' table. You can move, or remove it, as needed.
            //this.student_detailsTableAdapter.Fill(this.ClearanceReportDataSet.student_details);
            List<String> classes = Classes.classBranchNameArray.ToList();
            classes.RemoveRange(13, 6);
            classes.Add("Class 11 Com");
            classes.Add("Class 11 Sci");
            classes.Add("Class 12 Com");
            classes.Add("Class 12 Sci");
            selectedClass.DataSource = classes;
            sessionSetup();
            go.Enabled = false;
        }

        /*
        private void go_Click(object sender, EventArgs e)
        {

        }
        */
        
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
            DateTime dateFrom = new DateTime(from.Value.Year, from.Value.Month, from.Value.Day);
            DateTime dateTo = new DateTime(to.Value.Year, to.Value.Month, to.Value.Day);
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            if (section.SelectedIndex == 0)
            {
                this.student_detailsTableAdapter.Fill(this.ClearanceReportDataSet.student_details, class1, class2,
                    "A", "B", "C", "D", "E", sessionIndex[sessionBox.SelectedIndex], dateFrom, dateTo);
                //"A", "B", "C", "D", "E", GlobalVariables.currentSession, from.Value, to.Value);
                reportParameters.Add(new ReportParameter("classParameter", "Class - " + theClass));
                
            }
            else if (section.SelectedIndex > 0)
            {
                int val = section.SelectedIndex;
                String[] s = { "", "A", "B", "C", "D", "E" };
                this.student_detailsTableAdapter.Fill(this.ClearanceReportDataSet.student_details, class1, class2, 
                    s[val], s[val], s[val], s[val], s[val], sessionIndex[sessionBox.SelectedIndex], dateFrom, dateTo);
                //s[val], s[val], s[val], s[val], s[val], GlobalVariables.currentSession, from.Value, to.Value);
                reportParameters.Add(new ReportParameter("classParameter", "Class - " + theClass + " " + s[val]));
            }

            reportParameters.Add(new ReportParameter("ReportNameParameter", "Clearance Report - [" + sessionArray[sessionBox.SelectedIndex] + "] " + from.Value.ToShortDateString() + " - " + to.Value.ToShortDateString()));
            reportParameters.Add(new ReportParameter("reportDate", "Date: " + DateTime.Now.ToString("d/M/yyyy")));
            this.reportViewer1.LocalReport.SetParameters(reportParameters);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);


            //this.student_detailsTableAdapter.Fill(this.ClearanceReportDataSet.student_details);
        }
        

        private void ClearanceReportForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.crForm = null;
        }

        private void section_SelectedIndexChanged(object sender, EventArgs e)
        {
            go.Enabled = true;
        }
    }
}
