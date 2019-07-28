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
    public partial class StudentEditAnnualFeesForm : Form
    {

        Boolean allowIDChange;
        Boolean allowCellChange;
        Boolean feesChanged;
        Boolean currentAdm;

        int[] orgFees;
        int session;

        Boolean feesExceeds;
        int baseFeesTotal;
        public StudentEditAnnualFeesForm()
        {
            allowIDChange = true;
            allowCellChange = false;
            InitializeComponent();
            init();
        }

        private void StudentEditAnnualFeesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.saForm = null;
        }

        private void init()
        {
            //studentExists = false;
            //feeStructExists = false;
            save.Enabled = false;
            baseFeesTotal = 0;
            orgFees = new int[3];
            session = 0;
            AnFeesStructure.Rows.Clear();
            AnFeesStructure.Rows.Add("", "", "", "");
            studentName.Text = "";
            studentClass.Text = "";
            studentSession.Text = "";
            AnFeesStructure.Enabled = false;
            allowCellChange = false;
            currentAdm = false;
            concession.Checked = false;
            feesExceeds = false;
            feesChanged = false;
            
        }

        private void calculateTotal()
        {
            if (!allowCellChange) return;
            allowCellChange = false;
            int t2 = 0;
            for (int i = 0; i < 3; i++)
            {
                if (AnFeesStructure[i, 0].Value == null) AnFeesStructure[i, 0].Value = 0;
                t2 += CommonMethods.amountToInt("" + AnFeesStructure[i, 0].Value);
            }
            AnFeesStructure[3, 0].Value = CommonMethods.formatAmount("" + t2);
            feesExceeds = false;
            if (baseFeesTotal != t2)
            {
                if (baseFeesTotal < t2) feesExceeds = true;
                //concession.Text = CommonMethods.formatAmount("" + (baseFeesTotal - t2));
            }
            /*
            else
            {
                concession.Text = "0.00";
            }
            */
            allowCellChange = true;
        }

        private void studentID_TextChanged(object sender, EventArgs e)
        {
            if (!allowIDChange) return;
            allowIDChange = false;
            String theClass = "";
            init();

            if (studentID.Text.Length < 8)
            {
                allowIDChange = true;
                allowCellChange = true;
                return;
            }

            studentID.Text = studentID.Text.ToUpper();

            if (!(studentID.Text.Substring(0, 2).Equals("ST") || (studentID.Text.Substring(0, 2).Equals("OL")))
                    || CommonMethods.isNumeric(studentID.Text.Substring(2, 6), 4))
            {
                MessageBox.Show("Invalid student ID");
                studentID.Text = "";
                allowIDChange = true;
                allowCellChange = true;
                AnFeesStructure.Enabled = false;
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
                                if (dr[Table.student_details.student_category].ToString() != GlobalVariables.oldStud && 
                                    dr[Table.student_details.student_category].ToString() != GlobalVariables.manStud)
                                {
                                    currentAdm = true;
                                    AnFeesStructure.Enabled = false;
                                    save.Enabled = false;
                                }
                                else
                                {
                                    currentAdm = false;
                                    AnFeesStructure.Enabled = save.Enabled = true;
                                    
                                }
                                //studentExists = true;
                                String middleName = dr[Table.student_details.middle_name].ToString();

                                if (middleName == null || middleName.Length == 0) middleName = "";
                                else middleName += " ";
                                studentName.Text = dr[Table.student_details.first_name].ToString() + " " + middleName + dr[Table.student_details.last_name].ToString();
                                studentClass.Text = Classes.getClassBranch(dr[Table.student_details.class_n].ToString());
                                if (!currentAdm)
                                    studentSession.Text = dr[Table.student_details.current_session].ToString() + " - " +
                                                         (Convert.ToInt32(dr[Table.student_details.current_session]) + 1);
                                else studentSession.Text = "";
                                theClass = dr[Table.student_details.class_n].ToString();

                                if(dr[Table.student_details.student_category].ToString() == GlobalVariables.exStud)
                                {
                                    allowIDChange = true;
                                    allowCellChange = true;
                                    MessageBox.Show("The student is an Ex-Student");
                                    return;
                                }

                            }
                            else
                            {
                                // #TODO
                                MessageBox.Show("Student ID does not exist");
                                allowIDChange = true;
                                allowCellChange = true;
                                return;
                            }
                            dr.Close();
                        }

                        //Fees Query
                        String anFeesQuery = "Select top 1 * from " + Table.student_annual_fees.tableName + " where " +
                            Table.student_annual_fees.student_id + " = '" + studentID.Text + "' order by " +
                            Table.student_annual_fees.session + " desc ;";
                        using (SqlCommand command = new SqlCommand(anFeesQuery, connection))
                        {
                            SqlDataReader dr = command.ExecuteReader();
                            if (dr.Read())
                            {
                                orgFees[0] = Convert.ToInt32(dr[Table.student_annual_fees.school_dev]);
                                orgFees[1] = Convert.ToInt32(dr[Table.student_annual_fees.lab_dev]);
                                orgFees[2] = Convert.ToInt32(dr[Table.student_annual_fees.caution]);
                                session = Convert.ToInt32(dr[Table.student_annual_fees.session]);
                                concession.Checked = dr.GetBoolean(dr.GetOrdinal(Table.student_annual_fees.concession));
                                for (int i = 0; i < 3; i++)
                                    AnFeesStructure[i, 0].Value = CommonMethods.formatAmount("" + orgFees[i]);


                                if (dr[Table.student_annual_fees.receipt_id] != DBNull.Value)
                                    AnFeesStructure[4, 0].Value = dr[Table.student_annual_fees.receipt_id].ToString();
                                else AnFeesStructure[4, 0].Value = "";

                                if (dr[Table.student_annual_fees.date] != DBNull.Value)
                                {
                                    DateTime date;
                                    DateTime.TryParse(dr[Table.student_annual_fees.date].ToString(), out date);
                                    AnFeesStructure[5, 0].Value = date.ToString("dd-MM-yyyy");
                                }
                                else AnFeesStructure[5, 0].Value = "";
                                allowCellChange = true;
                                if (dr[Table.student_annual_fees.receipt_id].ToString().Length != 0)
                                {
                                    AnFeesStructure.Enabled = false;
                                    save.Enabled = false;
                                    MessageBox.Show("The fees is already paid");
                                    save.Enabled = false;
                                }
                                else
                                {
                                    AnFeesStructure.Enabled = true;
                                    AnFeesStructure.ReadOnly = false;
                                    AnFeesStructure.Rows[0].ReadOnly = false;
                                    save.Enabled = true;
                                }
                            }
                            else
                            {
                                //#TODO Handle this'
                                save.Enabled = false;
                            }
                            dr.Close();
                        }
                        String baseFeesQuery = "Select top 1 * from " + Table.annual_base_struct.tableName + " where " +
                            Table.annual_base_struct.session + " = " + GlobalVariables.currentSession + " and " +
                            Table.annual_base_struct.clss + " = '" + theClass + "'; ";
                        using (SqlCommand command = new SqlCommand(baseFeesQuery, connection))
                        {
                            SqlDataReader dr = command.ExecuteReader();
                            if (dr.Read())
                            {
                                baseFeesTotal = Convert.ToInt32(dr[Table.annual_base_struct.school_dev])
                                + Convert.ToInt32(dr[Table.annual_base_struct.lab_dev])
                                + Convert.ToInt32(dr[Table.annual_base_struct.caution]);
                            }
                            else
                            {
                                MessageBox.Show("Annual Base Structure Missing!");
                                baseFeesTotal = orgFees[0] + orgFees[1] + orgFees[2];
                            }
                            dr.Close();
                        }
                        calculateTotal();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            allowIDChange = true;
            allowCellChange = true;
        }

        private void AnFeesStructure_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!allowCellChange) return;
            allowCellChange = false;
            for (int i = 0; i < 3; i++)
                AnFeesStructure[i, 0].Value = CommonMethods.formatAmount("" + AnFeesStructure[i, 0].Value);
            allowCellChange = true;

            calculateTotal();
        }



        private void print_Click(object sender, EventArgs e)
        {
            if (feesExceeds)
            {
                DialogResult dgR = MessageBox.Show("Fees exceeds base structure, continue? ", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dgR != DialogResult.Yes)
                    return;
            }


            using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    connection.Open();
                    String updateQuery = "update " + Table.student_annual_fees.tableName + " set " +
                        Table.student_annual_fees.school_dev + " = " +
                        CommonMethods.amountToInt("" + AnFeesStructure[0, 0].Value) + ", " +
                        Table.student_annual_fees.lab_dev + " = " +
                        CommonMethods.amountToInt("" + AnFeesStructure[1, 0].Value) + ", " +
                        Table.student_annual_fees.concession + " = " +
                        (concession.Checked ? "1" : "0") + ", " +
                        Table.student_annual_fees.caution + " = " +
                        CommonMethods.amountToInt("" + AnFeesStructure[2, 0].Value) + " " +
                        " where " +
                        Table.student_annual_fees.student_id + " = '" + studentID.Text + "' and " +
                        Table.student_annual_fees.session + " = " + session + ";" ; 
                    
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.ExecuteNonQuery();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Close();
            }
            MessageBox.Show("Changes saved");
        }
    }
}
