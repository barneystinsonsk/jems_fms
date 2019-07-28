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
    public partial class SessionConfig : Form
    {
        public Boolean cancellable;
        public Boolean killParent;
        public Boolean forceClose;
        public Boolean done;
        bool[] complete;
        public Boolean fixedSession;
        
        public SessionConfig()
        {
            cancellable = true;
            killParent = false;
            forceClose = false;
            done = false;
            fixedSession = false;
            complete = new bool[3] { false, false, false };

            InitializeComponent();

            setUPPanel();
            ButtonReset();
        }

        private void setUPPanel()
        {
            String getQuery = "Select top 1 * from " + Table.session_info.tableName + " order by " +
                        Table.session_info.session + " desc ";
            using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(getQuery, connection))
                    {
                        SqlDataReader dr = command.ExecuteReader();
                        if (dr.Read())
                        {
                            currentSession.Text = "" + Convert.ToInt32(dr[Table.session_info.session]);
                            warnFees.Text = "" + Convert.ToInt32(dr[Table.session_info.warn_fees]);
                            warnDate.Value = Convert.ToInt32(dr[Table.session_info.warn_fees_date]);
                            lateFees.Text = "" + Convert.ToInt32(dr[Table.session_info.late_fees]);
                            
                        }
                        dr.Close();
                    }
                    connection.Close();
                }
                catch (Exception)
                { }
            }

        }

        private void formClosing(object sender, FormClosingEventArgs e)
        {
            if (cancellable || done)
            {
                e.Cancel = false;
            }
            else
            {
                if (!forceClose)
                {
                    DialogResult dr = MessageBox.Show("Are you sure you want to cancel session setup?", "Cancel Session Setup", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        killParent = true;
                        e.Cancel = false;
                    }
                    else
                        e.Cancel = true;
                }
                else
                {
                    killParent = true;
                    e.Cancel = false;
                }

            }
        }

        void ButtonReset()
        {
            bool check = true;
            for (int i = 0; i < 3; i++)
            {
                check = check && complete[i];
                //if (!complete[i]) check = false;
            }
            if (check) sessionDone.Enabled = true;
            else sessionDone.Enabled = false;
        }

        private void currentSession_TextChanged(object sender, EventArgs e)
        {
            if (currentSession.Text.Length == 0)
            {
                endSessionLabel.ForeColor = Color.Black;
                endSessionLabel.Text = "-20XX";
                complete[0] = false;
            }
            else
                if (!CommonMethods.isNumeric(currentSession.Text, 4))
            {
                endSessionLabel.ForeColor = Color.Red;
                endSessionLabel.Text = "-20XX";
                complete[0] = false;
            }
            else
            {
                int val = Int32.Parse(currentSession.Text);
                if (val < 2014 || val > 2050)
                {
                    endSessionLabel.ForeColor = Color.Red;
                    endSessionLabel.Text = "-20XX";
                    complete[0] = false;
                }
                else
                {
                    endSessionLabel.ForeColor = Color.Black;
                    complete[0] = true;
                    endSessionLabel.Text = "-" + (val + 1);
                }
            }
            ButtonReset();
        }

        private void warnFees_TextChanged(object sender, EventArgs e)
        {
            if (warnFees.Text.Length == 0)
            {
                complete[1] = false;
                warn_fees_invalid.Visible = false;
            }
            else
            {
                complete[1] = CommonMethods.valueBetween(warnFees.Text, 0, 1000);
                warn_fees_invalid.Visible = !complete[1];
            }

            ButtonReset();

        }

        private void lateFees_TextChanged(object sender, EventArgs e)
        {
            if (lateFees.Text.Length == 0)
            {
                complete[2] = false;
                late_fees_invalid.Visible = false;
            }
            else
            {
                complete[2] = CommonMethods.valueBetween(lateFees.Text, 0, 1000);
                late_fees_invalid.Visible = !complete[2];
            }

            ButtonReset();
        }
        
        private void sessionDone_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(lateFees.Text) < Int32.Parse(warnFees.Text))
            {
                late_fees_invalid.Visible = true;
                complete[2] = false;
                ButtonReset();
                return;
            }

            String adrs, pvrs, anrs, mtrs, stid, prid;
            adrs = pvrs = anrs = mtrs = stid = prid = "";
            bool sessionExists = false;
            using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    connection.Open();
                    String query = "Select * from " + Table.session_info.tableName + " where " + Table.session_info.session + " = " + currentSession.Text;
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader dr = command.ExecuteReader();
                        while (dr.Read())
                        {
                            sessionExists = true;
                            adrs = dr[Table.session_info.admission_rec_start].ToString();
                            pvrs = dr[Table.session_info.prov_rec_start].ToString();
                            anrs = dr[Table.session_info.annual_rec_start].ToString();
                            mtrs = dr[Table.session_info.monthly_rec_start].ToString();
                            stid = dr[Table.session_info.st_id_start].ToString();
                            prid = dr[Table.session_info.prov_id_start].ToString();

                        }
                        dr.Close();
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

            if (!sessionExists)
            {
                String ssn = currentSession.Text.Substring(2, 2);
                adrs = Receipt.admission + ssn + "0001";
                pvrs = Receipt.provisional + ssn + "0001";
                anrs = Receipt.annual + ssn + "0001";
                mtrs = Receipt.monthly + ssn + "000001";
                stid = "ST" + ssn + "0001";
                prid = "PV" + ssn + "0001";
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
                {
                    try
                    {
                        connection.Open();
                        String dumpQuery = "delete from " + Table.session_info.tableName + " where " +
                            Table.session_info.session + " = " + currentSession.Text;
                        using (SqlCommand dumpCommand = new SqlCommand(dumpQuery, connection))
                        {
                            dumpCommand.ExecuteNonQuery();
                        }
                    }
                    catch (Exception)
                    {
                        DialogResult dr = MessageBox.Show("Some Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (dr == System.Windows.Forms.DialogResult.OK)
                        {
                            forceClose = true;
                            Close();
                        }
                    }
                    finally
                    {
                        connection.Close();
                    }
                }

            }

            String insertQuery = "update " + Table.session_info.tableName +
                            " set " + Table.session_info.active_session + " = 0;";
            insertQuery += "insert into " + Table.session_info.tableName + " (" +
            Table.session_info.session + ", " +
            Table.session_info.admission_rec_start + ", " +
            Table.session_info.prov_rec_start + ", " +
            Table.session_info.annual_rec_start + ", " +
            Table.session_info.monthly_rec_start + ", " +
            Table.session_info.st_id_start + ", " +
            Table.session_info.prov_id_start + ", " +
            Table.session_info.warn_fees_date + ", " +
            Table.session_info.default_warn_fees_date + ", " +
            Table.session_info.warn_fees + ", " +
            Table.session_info.late_fees + ", " +
            Table.session_info.active_session + ") " + " values ( " +
            currentSession.Text + ", " +
            "'" + adrs + "', " +
            "'" + pvrs + "', " +
            "'" + anrs + "', " +
            "'" + mtrs + "', " +
            "'" + stid + "', " +
            "'" + prid + "', " +
            warnDate.Value.ToString() + ", " +
            warnDate.Value.ToString() + ", " +
            warnFees.Text + ", " +
            lateFees.Text + ", " +
            "1" + ");";

            using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                    {
                        insertCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    DialogResult dr = MessageBox.Show("Some Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (dr == System.Windows.Forms.DialogResult.OK)
                    {
                        forceClose = true;
                        Close();
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
            done = true;
            GlobalVariables.currentSession = Int32.Parse(currentSession.Text);
            Close();
        }

        private void SessionConfig_Load(object sender, EventArgs e)
        {
            currentSession.Enabled = !fixedSession;
        }

        private void SessionConfig_FormClosed(object sender, FormClosedEventArgs e)
        { 
        }
    }
}
