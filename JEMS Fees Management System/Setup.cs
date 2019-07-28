using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Resources;
using System.Configuration;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using System.Xml;

namespace JEMS_Fees_Management_System
{
    public partial class SetUp : Form
    {
        Boolean terminal_complete;                           //All session Fields Complete
        String[] terminals;
        int selectedTerminal;

        String connectionString;

        public SetUp()
        {

            terminal_complete = false;                           //All session Fields Complete
            terminals = new String[5] { "", "", "", "", "" };
            selectedTerminal = 0;
            InitializeComponent();
            terminalDone.Enabled = terminal_complete;
            dbconnect_next.Enabled = false;
            terminalPanel.Visible = false;
            dbConnectPanel.Visible = true;

            for (int i = 1; i <= 5; i++)
                dataGridView1.Rows.Add("" + i, "");
            dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.TerminalCellModified);



            setDatabaseFields();
            setTerminalFields();
        }

        void setDatabaseFields()
        {
            connectionString = GlobalVariables.dbConnectString;

            db_id.Text = "";
            db_password.Text = "";
            db_server.Text = "";
            db_name.Text = "";
            db_timeout.Value = 5;

            String name = "";
            String val = "";
            Boolean nameVal = true;
            foreach (char c in connectionString)
            {
                if (c != ';' && c != '=' && c != ' ' && c != '"')
                {
                    if (nameVal) name += c;
                    else val += c;
                }
                if (c == '=')
                {
                    if (nameVal)
                    {
                        nameVal = false;
                        val = "";
                    }
                    else
                    {
                        db_id.Text = "";
                        db_password.Text = "";
                        db_server.Text = "";
                        db_name.Text = "";
                        db_timeout.Value = 5;
                        return;
                    }
                }
                if (c == ';')
                {
                    if (!nameVal)
                    {
                        name = name.ToLower();
                        switch (name)
                        {
                            case "userid":
                                db_id.Text = val;
                                break;
                            case "password":
                                db_password.Text = val;
                                break;
                            case "server":
                                db_server.Text = val;
                                break;
                            case "database":
                                db_name.Text = val;
                                break;
                            case "connectiontimeout":
                                db_timeout.Value = Convert.ToInt32(val);
                                break;
                            default:
                                break;
                        }
                        nameVal = true;
                        name = "";
                        val = "";
                    }
                }
            }

        }

        void setTerminalFields()
        {
            String query = "select * from " + Table.terminal_names.tableName + ";";
            SqlDataReader dr;
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                try
                {
                    myConnection.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                    {
                        dr = myCommand.ExecuteReader();
                        while (dr.Read())
                        {

                            terminals[Convert.ToInt32(dr["id"]) - 1] = dr["name"].ToString();
                            dataGridView1[1, Convert.ToInt32(dr["id"]) - 1].Value = dr["name"].ToString();
                        }

                        dr.Close();
                    }
                }
                catch
                {
                    for (int i = 0; i <= 4; i++)
                    {
                        dataGridView1[1, i].Value = "";
                    }
                }
                finally
                {
                    myConnection.Close();
                }
            }


        }

        //Database Connection 

        private void dbconnect_test_Click(object sender, EventArgs e)
        {
            bool check = true;
            if (db_server.Text == null || db_server.Text.Length <= 1 ||
                db_server.Text.Contains(" ") || db_server.Text.Contains(","))
            {
                db_server_invalid.Visible = true;
                check = false;
            }
            else db_server_invalid.Visible = false;

            if (db_id.Text == null || db_id.Text.Length <= 1 ||
                            db_id.Text.Contains(" ") || db_id.Text.Contains(","))
            {
                db_id_invalid.Visible = true;
                check = false;
            }
            else db_id_invalid.Visible = false;

            if (db_password.Text == null || db_password.Text.Length <= 1)
            {
                db_password_invalid.Visible = true;
                check = false;
            }
            else db_password_invalid.Visible = false;

            if (db_name.Text == null || db_name.Text.Length <= 1 ||
                db_name.Text.Contains(" ") || db_name.Text.Contains(","))
            {
                db_name_invalid.Visible = true;
                check = false;
            }
            else db_name_invalid.Visible = false;

            connectionString = "user id=" + db_id.Text + ";" +
                "password=" + db_password.Text + ";" +
                "server=" + db_server.Text + ";" +
                "Trusted_Connection=no;" +
                "database=" + db_name.Text + ";" +
                "connection timeout=" + db_timeout.Value.ToString() + ";";
            if (check)
                if (checkConnectivity())
                {
                    MessageBox.Show("Connection Successful!", "Database Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dbconnect_next.Enabled = true;
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Unable to establish Connection, check if server is ON", "Database Connection failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dbconnect_next.Enabled = false;
                    check = false;

                }
        }

        bool checkConnectivity()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    db_server.Enabled = false;
                    db_id.Enabled = false;
                    db_password.Enabled = false;
                    db_name.Enabled = false;
                    db_timeout.Enabled = false;
                    dbconnect_test.Enabled = false;
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                        return true;
                    else
                        return false;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    db_server.Enabled = true;
                    db_id.Enabled = true;
                    db_password.Enabled = true;
                    db_name.Enabled = true;
                    db_timeout.Enabled = true;
                    dbconnect_test.Enabled = true;
                    connection.Close();
                }
            }

        }

        private void dbConnectMod(object sender, EventArgs e)
        {
            db_server_invalid.Visible = false;
            db_id_invalid.Visible = false;
            db_password_invalid.Visible = false;
            db_name_invalid.Visible = false;
            dbconnect_next.Enabled = false;
        }

        private void dbconnect_next_Click(object sender, EventArgs e)
        {
            dbConnectPanel.Visible = false;
            terminalPanel.Visible = true;
            setTerminalFields();
        }


        //Database Connection End


        // Terminal Panel


        private void DataModified()
        {
            if (dataGridView1.Rows.Count != 5) return;
            currentTerminal.Items.Clear();
            bool empty = true;
            for (int i = 0; i <= 4; i++)
            {
                if (dataGridView1[1, i].Value != null && dataGridView1[1, i].Value.ToString().Length != 0)
                {
                    empty = false;
                }
            }
            if (empty)
            {
                terminal_complete = false;
                currentTerminal.Enabled = false;
                return;
            }
            terminals = new String[5] { "", "", "", "", "" };
            for (int i = 0; i <= 4; i++)
            {
                if (dataGridView1[1, i].Value != null && dataGridView1[1, i].Value.ToString().Length != 0)
                {
                    String text = dataGridView1[1, i].Value.ToString();
                    if (terminals.Contains(text))
                    {
                        terminal_complete = false;
                        currentTerminal.Enabled = false;
                        return;
                    }
                    else
                    {
                        terminals[i] = text;
                        currentTerminal.Items.Add(text);
                    }
                }
            }
            terminal_complete = true;
            currentTerminal.Enabled = terminal_complete;
        }

        private void terminalPrevious_Click(object sender, EventArgs e)
        {
            dbConnectPanel.Visible = true;
            terminalPanel.Visible = false;

        }

        private void TerminalCellModification(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            DataModified();
        }

        private void terminalDone_Click(object sender, EventArgs e)
        {
            if (currentTerminal.Enabled == false)
            {
                terminalDone.Enabled = false;
                return;
            }
            //Save to configuration File and Database terminal table

            int dualCheck = 0;
            string configPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\setting.config";
            using (FileStream fileStream = new FileStream(configPath, FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fileStream))
            using (XmlTextWriter writer = new XmlTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 4;
                writer.WriteStartDocument();
                writer.WriteStartElement("settings");
                writer.WriteElementString("connectionString", connectionString);
                writer.WriteElementString("terminal", selectedTerminal.ToString());
                writer.WriteElementString("limitMenuItems", (GlobalVariables.limitMenuItems) ? "true" : "false");
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
            dualCheck++;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    String query = "truncate table " + Table.terminal_names.tableName + ";";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {                        
                        for (int i = 0; i <= 4; i++)
                        {
                            if (terminals[i] != null && terminals[i].Length != 0)
                            {
                                query += "insert into " + Table.terminal_names.tableName + " (id,name)" +
                                                       " values(" + (i + 1) + "," + "'" + terminals[i] + "');";
                            }
                        }
                        command.CommandText = query;
                        command.ExecuteNonQuery();
                    }
                    dualCheck++;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            if (dualCheck == 2)
            {
                AllSet = true;
                GlobalVariables.dbConnectString = connectionString;
                GlobalVariables.thisTerminal = Int32.Parse(selectedTerminal.ToString());

                if (GlobalVariables.thisTerminal != 1)
                    Program.mForm.backupSettingsToolStripMenuItem.Enabled = false;
                if (GlobalVariables.thisTerminal == 1 && !Directory.Exists(GlobalVariables.backupFolder))
                {
                    Program.mForm.backupSettingsToolStripMenuItem.Enabled = true;
                    DialogResult dr = MessageBox.Show("Setup backup folder now?", "Backup Folder not setup", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                    if (dr == DialogResult.Yes)
                    {
                        BackupSettings bckStg = new BackupSettings();
                        bckStg.ShowDialog();
                    }
                }
            }


            this.Close();
        }

        private void TerminalCellModified(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            DataModified();
            terminalDone.Enabled = false;
        }

        private void currentTerminal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentTerminal.SelectedItem == null || currentTerminal.SelectedItem.ToString() == "" ||
                !terminals.Contains(currentTerminal.SelectedItem.ToString()))
            {
                MessageBox.Show("nothing selected  " + currentTerminal.SelectedIndex);
                terminalDone.Enabled = false;
            }
            else
            {
                // gets current selected
                for (int i = 0; i < 5; i++)
                {
                    if (terminals[i].Equals(currentTerminal.SelectedItem.ToString(), StringComparison.Ordinal))
                    {
                        selectedTerminal = i + 1;
                        break;
                    }
                }
                if (selectedTerminal != 0)
                {
                    terminalDone.Enabled = true;
                }
                else terminalDone.Enabled = false;
            }
        }

        //Session Panel End

    }
}
