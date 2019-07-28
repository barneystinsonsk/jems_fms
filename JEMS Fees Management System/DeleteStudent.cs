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
    public partial class DeleteStudent : Form
    {
        Boolean allowChange = false;

        public DeleteStudent()
        {
            InitializeComponent();
            allowChange = true;
            confirm.Enabled = false;
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            using (SqlConnection myConnection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    myConnection.Open();
                    String query = "delete from " + Table.student_details.tableName + " where " + Table.student_details.student_id + "= '" +
                                    studentID.Text + "'; " +
                                   "delete from " + Table.student_monthly_fees.tableName + " where " + Table.student_monthly_fees.student_id + "= '" +
                                    studentID.Text + "'; " +
                                   "delete from " + Table.student_annual_fees.tableName + " where " + Table.student_annual_fees.student_id + "= '" +
                                    studentID.Text + "'; " +
                                   "delete from " + Table.provisional_map.tableName + " where " + Table.provisional_map.student_id + "= '" +
                                    studentID.Text + "' or " + Table.provisional_map.prov_id + "= '" + studentID.Text + "';";


                    using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                    {
                        myCommand.ExecuteNonQuery();
                        MessageBox.Show("Record Deleted");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to delete, may have resulted in inconsistency", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Close();
        }

        private void studentID_TextChanged(object sender, EventArgs e)
        {
            confirm.Enabled = false;
            if (!allowChange) return;
            allowChange = false;
            if (studentID.TextLength != 8)
            {
                allowChange = true;
                return;
            }
            Boolean exists = false;
            if(CommonMethods.studentIDCheck(studentID.Text))
            {
                using (SqlConnection myConnection = new SqlConnection(GlobalVariables.dbConnectString))
                {
                    try
                    {
                        myConnection.Open();
                        String query1 = "select * from " + Table.student_details.tableName + " where " + Table.student_details.student_id +
                             " = '" + studentID.Text + "';";
                        String query2 = "select * from " + Table.student_monthly_fees.tableName + " where " + Table.student_monthly_fees.student_id +
                             " = '" + studentID.Text + "';";
                        String query3 = "select * from " + Table.student_annual_fees.tableName + " where " + Table.student_annual_fees.student_id +
                             " = '" + studentID.Text + "';";
                        String query4 = "select * from " + Table.provisional_map.tableName + " where " + Table.provisional_map.student_id +
                             " = '" + studentID.Text + "' or " + Table.provisional_map.prov_id + " = '" + studentID.Text + "';";

                        using (SqlCommand myCommand = new SqlCommand(query1, myConnection))
                        {
                            SqlDataReader dr;

                            dr = myCommand.ExecuteReader();
                            if (dr.Read()) exists = true;
                            dr.Close();

                            myCommand.CommandText = query2;
                            dr = myCommand.ExecuteReader();
                            if (dr.Read()) exists = true;
                            dr.Close();

                            myCommand.CommandText = query3;
                            dr = myCommand.ExecuteReader();
                            if (dr.Read()) exists = true;
                            dr.Close();

                            myCommand.CommandText = query4;
                            dr = myCommand.ExecuteReader();
                            if (dr.Read()) exists = true;
                            dr.Close();
                        }

                        confirm.Enabled = exists;
                        if (!exists) MessageBox.Show("Record not found");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            allowChange = true;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
