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
    public partial class TCReportForm : Form
    {
        public TCReportForm()
        {
            InitializeComponent();
        }

        private void TCReportForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'TCReportDataSet.student_details' table. You can move, or remove it, as needed.
            //this.student_detailsTableAdapter.Fill(this.TCReportDataSet.student_details);
            List<String> classes = Classes.classBranchNameArray.ToList();
            classes.RemoveRange(13, 6);
            classes.Add("Class 11 Com");
            classes.Add("Class 11 Sci");
            classes.Add("Class 12 Com");
            classes.Add("Class 12 Sci");
            selectedClass.DataSource = classes;
            go.Enabled = false;

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

            ReportParameterCollection reportParameters = new ReportParameterCollection();
            DateTime dateFrom = new DateTime(from.Value.Year, from.Value.Month, from.Value.Day);
            DateTime dateTo = new DateTime(to.Value.Year, to.Value.Month, to.Value.Day);
            Debugger.Message(from.Value.ToString());
            if (section.SelectedIndex == 0)
            {
                this.student_detailsTableAdapter.Fill(this.TCReportDataSet.student_details, dateFrom, dateTo
                    , class1, class2, "A", "B", "C", "D", "E");
                //this.student_detailsTableAdapter.Fill(this.ClearanceReportDataSet.student_details, class1, class2,
                //    "A", "B", "C", "D", "E", GlobalVariables.currentSession, );
                reportParameters.Add(new ReportParameter("classParameter", "Class - " + theClass));

            }
            else if (section.SelectedIndex > 0)
            {
                int val = section.SelectedIndex;
                String[] s = { "", "A", "B", "C", "D", "E" };
                this.student_detailsTableAdapter.Fill(this.TCReportDataSet.student_details, dateFrom, dateTo
                    , class1, class2, s[val], s[val], s[val], s[val], s[val]);
                reportParameters.Add(new ReportParameter("classParameter", "Class - " + theClass + " " + s[val]));
            }

            reportParameters.Add(new ReportParameter("reportDate", "Date: " + DateTime.Now.ToString("d/M/yyyy")));
            reportParameters.Add(new ReportParameter("ReportNameParameter", "TC Report" + " Session: " + GlobalVariables.currentSession + "-" + (GlobalVariables.currentSession + 1)
                + "\n\r" + from.Value.ToShortDateString() + " - " + to.Value.ToShortDateString()));
            this.reportViewer1.LocalReport.SetParameters(reportParameters);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);


        }

        private void TCReportForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.trForm = null;
        }

        private void section_SelectedIndexChanged(object sender, EventArgs e)
        {
            go.Enabled = true;
        }
    }
}
