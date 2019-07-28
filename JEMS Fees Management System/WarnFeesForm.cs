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
    public partial class WarnFeesForm : Form
    {
        public WarnFeesForm()
        {
            InitializeComponent();
        }

        private void WarnFeesDialog_Load(object sender, EventArgs e)
        {
            String getDateQuery = "select * from " +
                        Table.session_info.tableName + " where " + Table.session_info.active_session + " = 1 ";
            using (SqlConnection myConnection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    myConnection.Open();
                    using (SqlCommand myCommand = new SqlCommand(getDateQuery, myConnection))
                    {
                        SqlDataReader dr;
                        dr = myCommand.ExecuteReader();
                        if (dr.Read())
                        {
                            warnDate.Value = Convert.ToInt32(dr[Table.session_info.warn_fees_date]);

                        }
                        else
                        {
                            warnDate.Value = 20;
                        }
                        dr.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            String updateQuery = "update " + Table.session_info.tableName + " set " +
                Table.session_info.warn_fees_date + " = " + warnDate.Value + ", " +
                Table.session_info.last_late_cal + " = NULL " +
                " where " + Table.session_info.active_session + " = 1 ";
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
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
