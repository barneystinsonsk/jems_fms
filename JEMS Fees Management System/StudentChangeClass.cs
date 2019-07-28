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
    public partial class StudentChangeClass : Form
    {
        public String studentID;
        public int currentClassIndex;
        int monthIndexCorr;
        int[,] monthFees;
        int mSession;

        public StudentChangeClass()
        {
            InitializeComponent();
            currentClassIndex = 0;
            monthIndexCorr = -1;
            Confirm.Enabled = false;
        }

        private void StudentChangeClass_Load(object sender, EventArgs e)
        {
            classSelect.DataSource = Classes.classBranchNameArray;
            classSelect.SelectedIndex = currentClassIndex;

            String monthQuery = "select * from " + Table.student_monthly_fees.tableName + " where " +
                Table.student_monthly_fees.student_id + " = '" + studentID + "' and " +
                Table.student_monthly_fees.receipt_id + " is null and " +
                Table.student_monthly_fees.session + " = ( select MAX(" + Table.student_monthly_fees.session +
                ") from " + Table.student_monthly_fees.tableName + " where " +
                Table.student_monthly_fees.student_id + " = '" + studentID + "') " +
                "order by dbo.sort_by_month(month);";
            using (SqlConnection myConnection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    myConnection.Open();
                    using (SqlCommand myCommand = new SqlCommand(monthQuery, myConnection))
                    {
                        SqlDataReader dr = myCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            String mt = dr[Table.student_monthly_fees.month].ToString();
                            mSession = Convert.ToInt32(dr[Table.student_monthly_fees.session]);
                            for (int i = 0; i < GlobalVariables.db_months.Length; i++)
                            {
                                if (mt == GlobalVariables.db_months[i])
                                {
                                    if (monthIndexCorr == -1) monthIndexCorr = i;
                                    monthSelect.Items.Add(GlobalVariables.months[i]);
                                }
                            }
                        }
                        dr.Close();
                        if (monthSelect.Items.Count == 0)
                        {
                            noMonth.Visible = true;
                            monthSelect.Enabled = false;
                            Confirm.Enabled = true;
                        }
                    }
                }
                catch
                {
                }
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            String newClass = "";
            //MessageBox.Show("a: " + classSelect.SelectedValue.ToString());
            for (int i = 0; i < Classes.classBranchNameArray.Length; i++)
                if (classSelect.SelectedValue.ToString() == Classes.classBranchNameArray[i])
                    newClass = Classes.classArray[i];

            monthFees = new int[12, 12];
            String baseFeesQuery = "select top 12 * from " + Table.monthly_base_struct.tableName + " where " +
                Table.monthly_base_struct.session + " = " + GlobalVariables.currentSession + " and " +
                Table.monthly_base_struct.clss + " = '" + newClass + "' " +
                " order by dbo.sort_by_month(month);";
            using (SqlConnection myConnection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    myConnection.Open();
                    using (SqlCommand myCommand = new SqlCommand(baseFeesQuery, myConnection))
                    {
                        SqlDataReader dr = myCommand.ExecuteReader();
                        int i = 0;
                        while (dr.Read())
                        {
                            monthFees[i, 0] = Convert.ToInt32(dr[Table.monthly_base_struct.tuition]);
                            monthFees[i, 1] = Convert.ToInt32(dr[Table.monthly_base_struct.management]);
                            monthFees[i, 2] = Convert.ToInt32(dr[Table.monthly_base_struct.smart]);
                            monthFees[i, 3] = Convert.ToInt32(dr[Table.monthly_base_struct.report]);
                            monthFees[i, 4] = Convert.ToInt32(dr[Table.monthly_base_struct.sports]);
                            monthFees[i, 5] = Convert.ToInt32(dr[Table.monthly_base_struct.science]);
                            monthFees[i, 6] = Convert.ToInt32(dr[Table.monthly_base_struct.red_cross]);
                            monthFees[i, 7] = Convert.ToInt32(dr[Table.monthly_base_struct.guide]);
                            monthFees[i, 8] = Convert.ToInt32(dr[Table.monthly_base_struct.insurance]);
                            monthFees[i, 9] = Convert.ToInt32(dr[Table.monthly_base_struct.school_activities]);
                            monthFees[i, 10] = Convert.ToInt32(dr[Table.monthly_base_struct.computer]);
                            monthFees[i, 11] = Convert.ToInt32(dr[Table.monthly_base_struct.local_exam]);
                            i++;
                        }
                        dr.Close();
                    }

                    String updateQuery = "update " + Table.student_details.tableName + " set " +
                        Table.student_details.class_n + " = '" + newClass + "' where " + Table.student_details.student_id +
                        " = '" + studentID + "';";
                    
                    if (!noMonth.Visible)
                    {
                        using (SqlCommand myCommand = new SqlCommand(updateQuery, myConnection))
                        {
                            for (int i = monthSelect.SelectedIndex + monthIndexCorr; i < monthSelect.Items.Count + monthIndexCorr; i++)
                            {
                                String mt = GlobalVariables.db_months[i];
                                updateQuery += "update " + Table.student_monthly_fees.tableName + " set " +
                                    Table.student_monthly_fees.class_n + " = '" + newClass + "', " +
                                    Table.student_monthly_fees.tuition + " = " + monthFees[i, 0] + ", " +
                                    Table.student_monthly_fees.management + " = " + monthFees[i, 1] + ", " +
                                    Table.student_monthly_fees.smart_class + " = " + monthFees[i, 2] + ", " +
                                    Table.student_monthly_fees.report_diary + " = " + monthFees[i, 3] + ", " +
                                    Table.student_monthly_fees.sports + " = " + monthFees[i, 4] + ", " +
                                    Table.student_monthly_fees.science + " = " + monthFees[i, 5] + ", " +
                                    Table.student_monthly_fees.red_cross + " = " + monthFees[i, 6] + ", " +
                                    Table.student_monthly_fees.guide + " = " + monthFees[i, 7] + ", " +
                                    Table.student_monthly_fees.insurance + " = " + monthFees[i, 8] + ", " +
                                    Table.student_monthly_fees.school_activities + " = " + monthFees[i, 9] + ", " +
                                    Table.student_monthly_fees.computer + " = " + monthFees[i, 10] + ", " +
                                    Table.student_monthly_fees.local_exam + " = " + monthFees[i, 11] + " " +
                                    " where " + Table.student_monthly_fees.student_id + " = '" + studentID + "' and " +
                                    Table.student_monthly_fees.session + " = " + mSession + " and " +
                                    Table.student_monthly_fees.month + " = '" + mt + "' and " +
                                    Table.student_monthly_fees.receipt_id + " is null;";
                            }
                        }
                    }
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

            Close();
        }

        private void monthSelect_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Confirm.Enabled = true;
        }
    }
}
