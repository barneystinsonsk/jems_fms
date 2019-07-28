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
    public partial class StudentReportForm : Form
    {
        List<String> sessionArray;
        List<String> sessionIndex;
        public StudentReportForm()
        {
            InitializeComponent();

        }

        private void StudentReport_Load(object sender, EventArgs e)
        {
            List<String> classes = Classes.classBranchNameArray.ToList();
            classes.RemoveRange(13, 6);
            classes.Add("Class 11 Com");
            classes.Add("Class 11 Sci");
            classes.Add("Class 12 Com");
            classes.Add("Class 12 Sci");
            selectedClass.DataSource = classes;
            stud_cat.SelectedIndex = 0;
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

        private void selectedClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void StudentReportForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.srForm = null;
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

            String cat1, cat2, cat3, cat4, catString;
            cat1 = GlobalVariables.newStud;
            cat2 = GlobalVariables.oldStud;
            cat3 = GlobalVariables.manStud;
            cat4 = GlobalVariables.provStud;
            catString = "";
            if (stud_cat.SelectedIndex == 1)
            {
                cat1 = GlobalVariables.newStud;
                cat2 = GlobalVariables.newStud;
                cat3 = GlobalVariables.newStud;
                catString = " (New Students)";
            }
            else if (stud_cat.SelectedIndex == 2)
            {
                cat1 = GlobalVariables.oldStud;
                cat2 = GlobalVariables.manStud;
                cat3 = GlobalVariables.oldStud;
                cat4 = GlobalVariables.manStud;
                catString = " (Old Students)";
            }

            ReportParameterCollection reportParameters = new ReportParameterCollection();

            if (section.SelectedIndex == 0)
            {
                this.student_detailsTableAdapter.Fill(this.StudentReportDataSet.student_details, sessionIndex[sessionBox.SelectedIndex], class1, class2, "A", "B", "C", "D", "E", cat1, cat2, cat3, cat4);
                reportParameters.Add(new ReportParameter("classParameter", "Students Report - " + theClass + catString));

            }
            else if (section.SelectedIndex > 0)
            {
                int val = section.SelectedIndex;
                String[] s = { "", "A", "B", "C", "D", "E" };

                this.student_detailsTableAdapter.Fill(this.StudentReportDataSet.student_details, sessionIndex[sessionBox.SelectedIndex], class1, class2, s[val], s[val], s[val], s[val], s[val], cat1, cat2, cat3, cat4);
                reportParameters.Add(new ReportParameter("classParameter", "Students Report - " + theClass + " - " + s[val] + catString));
            }
            reportParameters.Add(new ReportParameter("reportDate", "Date: " + DateTime.Now.ToString("d/M/yyyy")));
            reportParameters.Add(new ReportParameter("titleParameter", "Session : " + sessionArray[sessionBox.SelectedIndex]));

            this.reportViewer1.LocalReport.SetParameters(reportParameters);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
        }

        private void section_SelectedIndexChanged(object sender, EventArgs e)
        {
            go.Enabled = true;
        }
    }
}
