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
    public partial class StudentEditMonthlyFeesForm : Form
    {
        private Boolean allowIDChange, allowCellChange;

        private Boolean studentExists, feeStructExists;

        private Boolean kill = true;

        private int[,] originalFees;
        private int[] baseFeesTotal;
        private String[] classes;
        //private Boolean[] conc;
        Boolean feesExceeds;

        //        private Boolean[] concs;

        public StudentEditMonthlyFeesForm()
        {
            InitializeComponent();
            allowIDChange = false;
            allowCellChange = false;

            init();
            allowIDChange = true;
            allowCellChange = true;
        }

        private void init()
        {
            studentExists = false;
            feeStructExists = false;
            save.Enabled = false;
            concession.Checked = false;
            originalFees = new int[12, 9];
            //conc = new Boolean[12] { false, false, false, false, false, false,
            //                          false, false, false, false, false, false};
            feesExceeds = false;
            feesStructure.Rows.Clear();
            for (int i = 0; i < 12; i++)
            {
                feesStructure.Rows.Add(false, GlobalVariables.months[i], "", "", "", "", "", "", "", "", "", "");
                feesStructure.Rows[i].DefaultCellStyle.BackColor = SystemColors.ControlLightLight;

            }
            studentName.Text = "";
            studentClass.Text = "";
            studentSection.Text = "";
            studentSession.Text = "";
            feesStructure.Enabled = false;

            baseFeesTotal = new int[12];
            classes = new String[12];
            feesStructure.Enabled = false;

        }

        private void studentID_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("alsdjflajsdlfk");


            if (!allowIDChange) return;
            allowIDChange = false;
            allowCellChange = false;

            Boolean prePay = false;

            // Init table and fields

            init();

            // Check student ID validity

            if (studentID.Text.Length < 8)
            {
                allowIDChange = true;
                allowCellChange = true;
                return;
            }

            studentID.Text = studentID.Text.ToUpper();

            if (studentID.Text.Substring(0, 2).Equals("PV"))
            {
                MessageBox.Show("Provisional Students cannot pay monthly fees");
                studentID.Text = "";
                allowIDChange = true;
                allowCellChange = true;
                return;
            }
            else if (!(studentID.Text.Substring(0, 2).Equals("ST") || (studentID.Text.Substring(0, 2).Equals("OL")))
                    || CommonMethods.isNumeric(studentID.Text.Substring(2, 6), 4))
            {
                MessageBox.Show("Invalid student ID");
                studentID.Text = "";
                allowIDChange = true;
                allowCellChange = true;
                return;
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
                {
                    try
                    {
                        connection.Open();
                        studentExists = feeStructExists = false;
                        // Getting Student details
                        String studentQuery = "Select * from " + Table.student_details.tableName + " where " +
                                                Table.student_details.student_id + " = '" + studentID.Text + "'";

                        using (SqlCommand command = new SqlCommand(studentQuery, connection))
                        {
                            SqlDataReader dr = command.ExecuteReader();
                            if (dr.Read())
                            {
                                if (dr[Table.student_details.current_session].ToString().Length == 0)
                                {
                                    //#TODO Make it DialogBox
                                    prePay = true;
                                    //allowIDChange = true;
                                    //return;
                                }
                                studentExists = true;
                                String middleName = dr[Table.student_details.middle_name].ToString();

                                if (middleName == null || middleName.Length == 0) middleName = "";
                                else middleName += " ";
                                studentName.Text = dr[Table.student_details.first_name].ToString() + " " + middleName + dr[Table.student_details.last_name].ToString();
                                studentClass.Text = Classes.getClassBranch(dr[Table.student_details.class_n].ToString());
                                studentSection.Text = dr[Table.student_details.section].ToString();

                                if (!prePay)
                                    studentSession.Text = dr[Table.student_details.current_session].ToString() + " - " +
                                                         (Convert.ToInt32(dr[Table.student_details.current_session]) + 1);
                                else
                                    studentSession.Text = dr[Table.student_details.admission_session].ToString() + " - " +
                                                         (Convert.ToInt32(dr[Table.student_details.admission_session]) + 1);

                                if (dr[Table.student_details.student_category].ToString() == GlobalVariables.exStud)
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

                        // Getting Fees structure
                        String feesQuery = "Select top 12 * from " + Table.student_monthly_fees.tableName + " where " +
                            Table.student_monthly_fees.student_id + " = '" + studentID.Text +
                            "' order by " + Table.student_monthly_fees.session + " desc;";

                        using (SqlCommand command = new SqlCommand(feesQuery, connection))
                        {
                            SqlDataReader dr = command.ExecuteReader();
                            while (dr.Read())
                            {
                                feeStructExists = true;
                                int mt = -1;
                                // ordering rows and months
                                for (int i = 0; i < 12; i++)
                                {
                                    if (GlobalVariables.db_months[i].Equals(dr[Table.student_monthly_fees.month]))
                                    {
                                        mt = i;
                                        break;
                                    }
                                }
                                if (mt == -1)    // month does not exist
                                {
                                    save.Enabled = false;
                                    MessageBox.Show("Database Inconsistent");
                                    for (int i = 0; i < 12; i++)
                                    {
                                        feesStructure[0, i].Value = false;
                                        for (int j = 2; j <= 12; j++)
                                        {
                                            if (j < 9)
                                                originalFees[i, j - 2] = 0;
                                            feesStructure[j, i].Value = "";
                                        }
                                    }

                                    studentName.Text = "";
                                    studentClass.Text = "";
                                    studentSession.Text = "";
                                    allowIDChange = true;
                                    allowCellChange = true;
                                    return;
                                }
                                save.Enabled = true;
                                // if rcid exists fees is paid

                                String rcid = null;
                                rcid = dr[Table.student_monthly_fees.receipt_id].ToString();

                                if (rcid.Length != 0)
                                {

                                    feesStructure.Rows[mt].Cells[0].Value = true;
                                    feesStructure.Rows[mt].ReadOnly = true;
                                    feesStructure.Rows[mt].DefaultCellStyle.BackColor = SystemColors.ControlLight;
                                }
                                classes[mt] = dr[Table.student_monthly_fees.class_n].ToString();
                                if (dr.GetBoolean(dr.GetOrdinal(Table.student_monthly_fees.concession)))
                                    concession.Checked = true;
                                originalFees[mt, 0] = Convert.ToInt32(dr[Table.student_monthly_fees.tuition]);
                                originalFees[mt, 1] = Convert.ToInt32(dr[Table.student_monthly_fees.management]);
                                originalFees[mt, 2] = Convert.ToInt32(dr[Table.student_monthly_fees.smart_class]);
                                originalFees[mt, 3] = Convert.ToInt32(dr[Table.student_monthly_fees.report_diary]);
                                originalFees[mt, 4] = Convert.ToInt32(dr[Table.student_monthly_fees.insurance]) +
                                                      Convert.ToInt32(dr[Table.student_monthly_fees.sports]) +
                                                      Convert.ToInt32(dr[Table.student_monthly_fees.red_cross]) +
                                                      Convert.ToInt32(dr[Table.student_monthly_fees.science]) +
                                                      Convert.ToInt32(dr[Table.student_monthly_fees.guide]);
                                originalFees[mt, 5] = Convert.ToInt32(dr[Table.student_monthly_fees.school_activities]);
                                originalFees[mt, 6] = Convert.ToInt32(dr[Table.student_monthly_fees.computer]);
                                originalFees[mt, 7] = Convert.ToInt32(dr[Table.student_monthly_fees.local_exam]);
                                originalFees[mt, 8] = 0;// #TODO calculate late fees
                                if (dr[Table.student_monthly_fees.receipt_id] != DBNull.Value)
                                    feesStructure[12, mt].Value = dr[Table.student_monthly_fees.receipt_id].ToString();
                                else feesStructure[12, mt].Value = "";

                                if (dr[Table.student_monthly_fees.date] != DBNull.Value)
                                {
                                    DateTime date;
                                    DateTime.TryParse(dr[Table.student_monthly_fees.date].ToString(), out date);
                                    feesStructure[13, mt].Value = date.ToString("dd-MM-yyyy");
                                }
                                else feesStructure[13, mt].Value = "";
                                for (int i = 0; i < 9; i++)
                                    feesStructure.Rows[mt].Cells[i + 2].Value = CommonMethods.formatAmount("" + originalFees[mt, i]);


                                feesStructure.Rows[mt].Cells[11].Value = 0;

                            }

                            dr.Close();


                        }
                        String baseFeesQuery = "Select top 1 * from " + Table.monthly_base_struct.tableName + " where " +
                            Table.monthly_base_struct.session + " = " + GlobalVariables.currentSession + " and " +
                            Table.monthly_base_struct.clss + " = '" + classes[0] + "' and " +
                            Table.monthly_base_struct.mnth + " = '" + GlobalVariables.db_months[0] + "';";

                        using (SqlCommand command = new SqlCommand(baseFeesQuery, connection))
                        {
                            for (int i = 0; i < 12; i++)
                            {
                                baseFeesQuery = "Select top 1 * from " + Table.monthly_base_struct.tableName + " where " +
                                                Table.monthly_base_struct.session + " = " + GlobalVariables.currentSession + " and " +
                                                Table.monthly_base_struct.clss + " = '" + classes[i] + "' and " +
                                                Table.monthly_base_struct.mnth + " = '" + GlobalVariables.db_months[i] + "';";
                                command.CommandText = baseFeesQuery;
                                SqlDataReader dr = command.ExecuteReader();
                                if (dr.Read())
                                {
                                    baseFeesTotal[i] = 0;
                                    baseFeesTotal[i] += Convert.ToInt32(dr[Table.monthly_base_struct.tuition]) +
                                        Convert.ToInt32(dr[Table.monthly_base_struct.management]) +
                                        Convert.ToInt32(dr[Table.monthly_base_struct.smart]) +
                                        Convert.ToInt32(dr[Table.monthly_base_struct.report]) +
                                        Convert.ToInt32(dr[Table.monthly_base_struct.sports]) +
                                        Convert.ToInt32(dr[Table.monthly_base_struct.red_cross]) +
                                        Convert.ToInt32(dr[Table.monthly_base_struct.insurance]) +
                                        Convert.ToInt32(dr[Table.monthly_base_struct.science]) +
                                        Convert.ToInt32(dr[Table.monthly_base_struct.school_activities]) +
                                        Convert.ToInt32(dr[Table.monthly_base_struct.computer]) +
                                        Convert.ToInt32(dr[Table.monthly_base_struct.local_exam]);
                                }
                                else
                                {
                                    MessageBox.Show("Monthly Base Structure Missing!");
                                    initBaseTotal();
                                    allowIDChange = true;
                                    allowCellChange = true;
                                    return;
                                }
                                dr.Close();
                            }
                        }
                        calculateTotal();
                        feesStructure.Enabled = true;
                        if (!feeStructExists)
                        {
                            // #TODO
                        }
                    }
                    catch (Exception)
                    {
                    }
                    finally
                    {
                        connection.Close();
                    }
                }

            }
            //studentClass.Text = studentID.Text.Substring(0, 2);
            allowIDChange = true;
            allowCellChange = true;
        }

        private void initBaseTotal()
        {

            for (int i = 0; i < 12; i++)
            {
                baseFeesTotal[i] = 0;
                for (int j = 0; j < 8; j++)
                {
                    baseFeesTotal[i] += originalFees[i, j];
                }
            }
        }

        private void feesStructure_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!allowCellChange) return;
            allowCellChange = false;
            calculateTotal();
            allowCellChange = true;
        }

        private void calculateTotal()
        {
            int grandTotal = 0;
            feesExceeds = false;
            for (int i = 0; i < 12; i++)
            {
                int total = 0;
                for (int j = 0; j < 9; j++)
                {
                    if (feesStructure[j + 2, i].Value == null) feesStructure[j + 2, i].Value = 0;
                    int v = CommonMethods.amountToInt(feesStructure[j + 2, i].Value.ToString());
                    //if (v > originalFees[i, j])
                    //{
                    //    v = originalFees[i, j];
                    //}

                    feesStructure[j + 2, i].Value = CommonMethods.formatAmount("" + v);
                    total += v;
                    if (j == 7)
                    {

                        if (total != baseFeesTotal[i])
                        {   //conc[i] = true;
                            if (baseFeesTotal[i] < total) feesExceeds = true;
                        }
                        //else
                        //conc[i] = false;
                    }
                    //orgTotal += originalFees[i, j];

                }
                feesStructure[11, i].Value = CommonMethods.formatAmount("" + total);
                if (//feesStructure[0, i].Value.Equals(true) && 
                    feesStructure.Rows[i].ReadOnly == false)
                {
                    grandTotal += total;
                }
            }


        }

        private void print_Click_1(object sender, EventArgs e)
        {
            //StudentFeesCardForm stfc = new StudentFeesCardForm();
            Program.mForm.printMonthlyFeeStructureToolStripMenuItem_Click(null, null);
            kill = false;
            if (save.Enabled)
            {
                save_Click(sender, e);
                MainForm.stfc.studentID.Text = studentID.Text;
            }
            this.ActiveControl = studentID;
            studentID.Text = "";
            //stfc.WindowState = FormWindowState.Maximized;
            //stfc.ShowDialog();
            //stfc.BringToFront();

        }

        /*
                private void feesStructure_CurrentCellDirtyStateChanged(object sender, EventArgs e)
                {

                    if (!allowCellChange) return;
                    allowCellChange = false;
                    if (feesStructure.CurrentCell.OwningColumn is DataGridViewCheckBoxColumn &&
                        feesStructure.IsCurrentCellDirty)
                    {
                        int x = feesStructure.CurrentCell.RowIndex;
                        for (int i = 0; i < 12; i++)
                        {
                            if (i < x)
                                feesStructure[0, i].Value = true;
                            else
                                feesStructure[0, i].Value = false;
                        }
                        feesStructure.CommitEdit(DataGridViewDataErrorContexts.Commit);
                        feesStructure.EndEdit();
                        feesStructure.CurrentCell = feesStructure[1, x];  // Minor glitch
                        feesStructure.CurrentCell = feesStructure[0, x];  // cell needs to leave and enter

                        print.Enabled = false;
                        for (int i = 0; i < 12; i++)
                        {
                            if (feesStructure[0, i].Value.Equals(true) && feesStructure.Rows[i].ReadOnly != true)
                            {
                                print.Enabled = true;
                                break;
                            }
                        }

                        calculateTotal();

                    }
                    allowCellChange = true;

                }
        */

        private void save_Click(object sender, EventArgs e)
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
                    String updateQuery = "";

                    for (int i = 0; i < 12; i++)
                    {
                        if (!feesStructure.Rows[i].ReadOnly)
                        {
                            updateQuery += "Update " + Table.student_monthly_fees.tableName + " set " +
                            Table.student_monthly_fees.tuition + " = " +
                            CommonMethods.amountToInt(feesStructure[2, i].Value.ToString()) + ", " +
                            Table.student_monthly_fees.management + " = " +
                            CommonMethods.amountToInt(feesStructure[3, i].Value.ToString()) + ", " +

                            Table.student_monthly_fees.smart_class + " = " +
                            CommonMethods.amountToInt(feesStructure[4, i].Value.ToString()) + ", " +
                            Table.student_monthly_fees.report_diary + " = " +
                            CommonMethods.amountToInt(feesStructure[5, i].Value.ToString()) + ", " +
                            Table.student_monthly_fees.school_activities + " = " +
                            CommonMethods.amountToInt(feesStructure[7, i].Value.ToString()) + ", " +
                            Table.student_monthly_fees.computer + " = " +
                            CommonMethods.amountToInt(feesStructure[8, i].Value.ToString()) + ", " +
                            Table.student_monthly_fees.local_exam + " = " +
                            CommonMethods.amountToInt(feesStructure[9, i].Value.ToString()) + ", " +
                            Table.student_monthly_fees.concession + " = " +
                            ((concession.Checked) ? "1" : "0") + " " +
                            " where " +
                            Table.student_monthly_fees.month + " = '" + GlobalVariables.db_months[i] + "' and " +
                            Table.student_monthly_fees.student_id + " = '" + studentID.Text + "';";
                            //MessageBox.Show(updateQuery);
                        }
                    }
                    if(updateQuery != "" && !updateQuery.Equals(""))
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }


                    MessageBox.Show("Changes saved");
                }
                catch
                {
                    MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 

                }
            }
            if(kill)
            Close();
        }

        private void StudentEditMonthlyFeesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.smForm = null;
        }

    }
}
