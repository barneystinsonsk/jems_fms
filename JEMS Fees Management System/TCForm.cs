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
    public partial class TCForm : Form
    {
        Boolean idChangeActive;
        Boolean studExists;

        public TCForm()
        {
            InitializeComponent();

            idChangeActive = true;
            confirm.Enabled = false;
        }

        private void TCForm_Load(object sender, EventArgs e)
        {

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void studentID_TextChanged(object sender, EventArgs e)
        {
            if (!idChangeActive) return;

            idChangeActive = false;

            confirm.Enabled = false;

            studExists = false;

            Boolean anFeesPaid = true, mtFeesPaid = true;

            Boolean exStud = false;

            resetFields();
            if (studID.TextLength == 8 && !CommonMethods.studentIDCheck(studID.Text))
                MessageBox.Show("Invalid Student ID");

            if (studID.TextLength == 8 && CommonMethods.studentIDCheck(studID.Text))
            {
                studID.Text = studID.Text.ToUpper();

                String detailQuery = "select * from " + Table.student_details.tableName + " where " +
                            Table.student_details.student_id + " = '" + studID.Text + "';";
                SqlDataReader dr;
                using (SqlConnection myConnection = new SqlConnection(GlobalVariables.dbConnectString))
                {
                    try
                    {
                        myConnection.Open();
                        using (SqlCommand myCommand = new SqlCommand(detailQuery, myConnection))
                        {
                            dr = myCommand.ExecuteReader();

                            if (dr.Read())
                            {
                                studExists = true;

                                name.Text = dr[Table.student_details.first_name].ToString() + " " +
                                    dr[Table.student_details.middle_name].ToString() + " " +
                                    dr[Table.student_details.last_name].ToString();
                                fName.Text = dr[Table.student_details.father_name].ToString();
                                mName.Text = dr[Table.student_details.mother_name].ToString();

                                gName.Text = dr[Table.student_details.guardian_name].ToString();

                                studCat.Text = dr[Table.student_details.student_category].ToString();

                                exStud = studCat.Text == GlobalVariables.exStud;

                                if (!exStud)
                                {
                                    currClass.Text = Classes.getClassBranch(dr[Table.student_details.class_n].ToString());
                                    section.Text = dr[Table.student_details.section].ToString();
                                    currSession.Text = dr[Table.student_details.current_session].ToString();
                                }

                                adClass.Text = Classes.getClassBranch(dr[Table.student_details.admission_class].ToString());
                                adSession.Text = dr[Table.student_details.admission_session].ToString();
                            }
                            dr.Close();
                        }

                        if (studExists)
                        {
                            if (exStud)
                                MessageBox.Show("Student already given TC");
                            else

                            {
                                String annualQuery = "Select Top 1 * from " + Table.student_annual_fees.tableName + " where " +
                                              Table.student_annual_fees.student_id + " = '" + studID.Text + "' order by " +
                                              Table.student_annual_fees.session + " desc;";
                                using (SqlCommand myCommand = new SqlCommand(annualQuery, myConnection))
                                {
                                    dr = myCommand.ExecuteReader();

                                    if (dr.Read())
                                    {
                                        if (dr[Table.student_annual_fees.receipt_id].ToString().Length != 8)
                                            anFeesPaid = false;
                                    }
                                    dr.Close();
                                }


                                String monthlyQuery = "Select Top 12 * from " + Table.student_monthly_fees.tableName + " where " +
                                                Table.student_monthly_fees.student_id + " = '" + studID.Text + "' order by " +
                                                Table.student_monthly_fees.session + " desc;";
                                using (SqlCommand myCommand = new SqlCommand(monthlyQuery, myConnection))
                                {
                                    dr = myCommand.ExecuteReader();

                                    while (dr.Read())
                                    {
                                        if (dr[Table.student_monthly_fees.receipt_id].ToString().Length != 8)
                                        {
                                            mtFeesPaid = false;
                                        }
                                    }
                                    dr.Close();

                                }

                                if (anFeesPaid && mtFeesPaid)
                                {
                                    feesStatus.Text = "Fees Paid";
                                    feesStatus.ForeColor = Color.Green;
                                }
                                else
                                {
                                    feesStatus.ForeColor = Color.Red;

                                    if (!(anFeesPaid || mtFeesPaid))
                                        feesStatus.Text = "Annual and monthly fees not paid";
                                    else if (anFeesPaid)
                                        feesStatus.Text = "Monthly fees not paid";
                                    else
                                        feesStatus.Text = "Annual fees not paid";
                                }
                                reason.Enabled = true;
                                tcNo.Enabled = true;
                                confirm.Enabled = true;
                            }
                        }
                        else
                        {
                            resetFields();
                            MessageBox.Show("Student ID does not exist");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        myConnection.Close();
                    }
                }
            }

            idChangeActive = true;
        }

        private void resetFields()
        {
            foreach (Control cs in this.Controls)
            {
                if (cs is TextBox && ((TextBox)cs) != studID)
                {
                    cs.Text = "";
                }
            }
            feesStatus.Text = "";
            reason.Enabled = false;
            confirm.Enabled = false;
            tcNo.Enabled = false;
        }

        private void TCForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.tcForm = null;
        }

        private void cleanTCNO()
        {
            String text = tcNo.Text;
            tcNo.Text = "";
            foreach(char c in text)
            {
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9'))
                    tcNo.Text += c;
            }
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            cleanTCNO(); 

            DialogResult dr = MessageBox.Show("Are you sure?", "Generate TC", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);

            String tcDate = date.Value.ToString(GlobalVariables.dateFormat);

            String updateQuery = "Update " + Table.student_details.tableName + " set " + 
                            Table.student_details.student_category + " = '" + GlobalVariables.exStud + "', " +
                            Table.student_details.current_session + " = NULL ," +
                            Table.student_details.tc_date + " = '" + tcDate + "', " + 
                            Table.student_details.tc_no + " = '" + tcNo.Text + "', " +
                            Table.student_details.reason + " = '" + reason.Text + "' where " +
                            Table.student_details.student_id + " = '" + studID.Text + "';";

            updateQuery += "Update " + Table.student_annual_fees.tableName + " set " +
                            Table.student_annual_fees.school_dev + " = 0, " +
                            Table.student_annual_fees.lab_dev + " = 0, " +
                            Table.student_annual_fees.caution + " = 0 " + " where " +
                            Table.student_annual_fees.student_id + " = '" + studID.Text + "' and " +
                            Table.student_annual_fees.receipt_id + " is NULL;";

            updateQuery += "Update " + Table.student_monthly_fees.tableName + " set " +
                            Table.student_monthly_fees.computer + " = 0, " +
                            Table.student_monthly_fees.guide + " = 0, " +
                            Table.student_monthly_fees.insurance + " = 0, " +
                            Table.student_monthly_fees.late_fees + " = 0, " +
                            Table.student_monthly_fees.local_exam + " = 0, " +
                            Table.student_monthly_fees.management + " = 0, " +
                            Table.student_monthly_fees.red_cross + " = 0, " +
                            Table.student_monthly_fees.report_diary + " = 0, " +
                            Table.student_monthly_fees.school_activities + " = 0, " +
                            Table.student_monthly_fees.science + " = 0, " +
                            Table.student_monthly_fees.smart_class + " = 0, " +
                            Table.student_monthly_fees.sports + " = 0, " +
                            Table.student_monthly_fees.tuition + " = 0 " + " where " +
                            Table.student_monthly_fees.student_id + " = '" + studID.Text + "' and " +
                            Table.student_monthly_fees.receipt_id + " is NULL;";


            if (dr == DialogResult.Yes)
            {
                using (SqlConnection myConnection = new SqlConnection(GlobalVariables.dbConnectString))
                {
                    try
                    {
                        myConnection.Open();
                        using (SqlCommand myCommand = new SqlCommand(updateQuery, myConnection))
                        {
                            myCommand.ExecuteNonQuery();
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            Close();
        }
        
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            String temp = reason.Text;
            String temp2 = "";

            foreach(char c in temp.ToLower())
            {
                if ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9') || c == '.' || c == ',' || c == ' ')
                    temp2 += c;
            }
            if (temp.ToLower() != temp2.ToLower())
            {
                reason.Text = temp2;
                reason.SelectionStart = temp2.Length;
            }
        }

        

        /*
        public bool isValidField(string tableName, string columnName)
        {
            var tblQuery = "SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS"
                           + " WHERE TABLE_NAME = @tableName AND"
                           + " COLUMN_NAME = @columnName";

            SqlCeCommand cmd = objCon.CreateCommand();
            cmd.CommandText = tblQuery;
            var tblNameParam = new SqlCeParameter(
                "@tableName",
                SqlDbType.NVarChar,
                128);

            tblNameParam.Value = tableName
    cmd.Parameters.Add(tblNameParam);
            var colNameParam = new SqlCeParameter(
                "@columnName",
                SqlDbType.NVarChar,
                128);

            colNameParam.Value = columnName
    cmd.Parameters.Add(colNameParam);
            object objvalid = cmd.ExecuteScalar(); // will return 1 or null
            return objvalid != null;
        }
        */


    }
}
