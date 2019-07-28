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
    public partial class StudentFeesCardForm : Form
    {

        Boolean allowIDChange;
        Boolean studentExists;
        public int session;

        public StudentFeesCardForm()
        {
            InitializeComponent();
            allowIDChange = true;
            studentExists = false;
        }

        private void StudentFeesCardForm_Load(object sender, EventArgs e)
        {
            
        }

        private void studentID_TextChanged(object sender, EventArgs e)
        {
            if (!allowIDChange)
                return;
            if (studentID.TextLength < 8) return;
            allowIDChange = false;
            studentExists = false;
            studentID.Text = studentID.Text.ToUpper();
            if (studentID.Text.Substring(0, 2).Equals("PV"))
            {
                MessageBox.Show("Provisional Students cannot pay monthly fees");
                studentID.Text = "";
                allowIDChange = true;
                return;
            }
            else if (!(studentID.Text.Substring(0, 2).Equals("ST") || (studentID.Text.Substring(0, 2).Equals("OL")))
                    || CommonMethods.isNumeric(studentID.Text.Substring(2, 6), 4))
            {
                MessageBox.Show("Invalid student ID");
                studentID.Text = "";
                allowIDChange = true;
                return;
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
                {
                    try
                    {
                        connection.Open();
                        String studentQuery = "Select * from " + Table.student_details.tableName + " where " +
                                                Table.student_details.student_id + " = '" + studentID.Text + "'";
                        using (SqlCommand command = new SqlCommand(studentQuery, connection))
                        {
                            SqlDataReader dr = command.ExecuteReader();
                            if (dr.Read())
                            {
                                studentExists = true;
                                if (dr[Table.student_details.current_session] != DBNull.Value)
                                {
                                    session = Convert.ToInt32(dr[Table.student_details.current_session]);
                                }
                                else
                                {
                                    if (dr[Table.student_details.student_category].ToString() == GlobalVariables.newStud)
                                    {
                                        session = Convert.ToInt32(dr[Table.student_details.admission_session]);
                                        
                                    }
                                    else
                                    {
                                        session = -1;
                                        studentExists = false;
                                    }
                                }

                            }
                        }
                    }
                    catch
                    {

                    }
                }
            }
            if (studentExists)
            {
                studentID.Enabled = false;
                this.DataTable1TableAdapter.Fill(this.StudentFeesCard.DataTable1,studentID.Text,session);
                ReportParameterCollection reportParameters = new ReportParameterCollection();
                reportParameters.Add(new ReportParameter("reportDate", "Date: " + DateTime.Now.ToString("d/M/yyyy")));
                this.reportViewer1.LocalReport.SetParameters(reportParameters);
                this.reportViewer1.RefreshReport();
                this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                studentID.Enabled = true;
            }
            else
            {
                MessageBox.Show("Student does not exist or is an Ex-Student");
            }
            allowIDChange = true;
        }

        private void StudentFeesCardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.stfc = null;
        }
    }
}
