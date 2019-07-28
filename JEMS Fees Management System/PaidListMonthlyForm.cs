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
    public partial class PaidListMonthlyForm : Form
    {
        List<String> sessionArray;
        List<String> sessionIndex;
        public PaidListMonthlyForm()
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

        private void PaidListMonthlyForm_Load(object sender, EventArgs e)
        {
            List<String> classes = Classes.classBranchNameArray.ToList();
            classes.RemoveRange(13, 6);
            classes.Add("Class 11 Com");
            classes.Add("Class 11 Sci");
            classes.Add("Class 12 Com");
            classes.Add("Class 12 Sci");

            selectedClass.DataSource = classes;

            sessionSetup();
            // TODO: This line of code loads data into the 'PaidListMonthlyDataSet.DataTable1' table. You can move, or remove it, as needed.

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

            DateTime dateFrom = new DateTime(from.Value.Year, from.Value.Month, from.Value.Day);
            DateTime dateTo = new DateTime(to.Value.Year, to.Value.Month, to.Value.Day);

            if (section.SelectedIndex == 0)
            {
                //this.DataTable1TableAdapter.Fill(this.PaidListMonthly.DataTable1, thisMonth, effective_session, class1, class2, "A", "B", "C", "D", "E");
                this.DataTable1TableAdapter.Fill(this.PaidListMonthlyDataSet.DataTable1, dateFrom, dateTo, sessionIndex[sessionBox.SelectedIndex], class1, class2, "A", "B", "C", "D", "E");
                
                reportParameters.Add(new ReportParameter("classParameter", theClass));
            }
            else if (section.SelectedIndex > 0)
            {
                int val = section.SelectedIndex;
                String[] s = { "", "A", "B", "C", "D", "E" };
                //this.DataTable1TableAdapter.Fill(this.DuesListMonthly.DataTable1, thisMonth, effective_session, class1, class2, s[val], s[val], s[val], s[val], s[val]);
                this.DataTable1TableAdapter.Fill(this.PaidListMonthlyDataSet.DataTable1, dateFrom, dateTo, sessionIndex[sessionBox.SelectedIndex], class1, class2, s[val], s[val], s[val], s[val], s[val]);
                
                reportParameters.Add(new ReportParameter("classParameter", theClass + " - " + s[val]));
            }
            reportParameters.Add(new ReportParameter("dateParameter", "Date: " + from.Value.ToShortDateString() + " - " + to.Value.ToShortDateString()));
            reportParameters.Add(new ReportParameter("titleParameter", "Paid List - " + sessionArray[sessionBox.SelectedIndex]));
            reportParameters.Add(new ReportParameter("reportDate", "Date: " + DateTime.Now.ToString("d/M/yyyy")));
            this.reportViewer1.LocalReport.SetParameters(reportParameters);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            
        }

        private void PaidListMonthlyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.plForm = null;
        }

        private void section_SelectedIndexChanged(object sender, EventArgs e)
        {
            go.Enabled = true;
        }
    }
}
