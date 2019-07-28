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
    public partial class RunSqlForm : Form
    {
        public RunSqlForm()
        {
            InitializeComponent();
            button.Enabled = false;
        }

        private void button_Click(object sender, EventArgs e)
        {
            if(password.Text != "8109275355" && password.Text != "^")
            {
                MessageBox.Show("Invalid password");
                return;
            }
            display.Rows.Clear();
            display.Columns.Clear();
            using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    connection.Open();
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(queryBox.Text, connection))
                        {
                            SqlDataReader dr = cmd.ExecuteReader();
                            if(dr.Read())
                            {
                                display.Columns.Add("sno", "S. No.");
                                for (int i = 0; i < dr.FieldCount; i++)
                                {
                                    display.Columns.Add("" + i, dr.GetName(i));
                                }
                                display.Rows.Add();
                                display[0, display.RowCount - 1].Value = display.RowCount;
                                for (int i = 0; i < dr.FieldCount; i++)
                                {
                                    display[i + 1, display.RowCount - 1].Value = dr[i].ToString();
                                }
                            }
                            while(dr.Read())
                            {
                                display.Rows.Add();
                                display[0, display.RowCount - 1].Value = display.RowCount;
                                for (int i = 0; i < dr.FieldCount; i++)
                                {                                   
                                    display[i + 1, display.RowCount - 1].Value = dr[i].ToString();
                                }
                            }
                            MessageBox.Show("Query executed");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Unable to execute query " + ex.Message, "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }

                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error with the connection " + ex.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void queryBox_TextChanged(object sender, EventArgs e)
        {
            if (queryBox.TextLength > 3) button.Enabled = true;
            else button.Enabled = false;
        }

        private void RunSqlForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.rsForm = null;
        }
    }
}
