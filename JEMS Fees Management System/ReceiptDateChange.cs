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
    public partial class ReceiptDateChange : Form
    {
        Boolean allowChange;
        Boolean isAnnual;
        public ReceiptDateChange()
        {
            InitializeComponent();
            clearAll();
            allowChange = true;
        }

        private void clearAll()
        {
            oldDate.Text = "";
            save.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            allowChange = false;
            clearAll();
            if (receiptID.TextLength == 8)
            {
                if (receiptID.Text.Substring(0, 2).ToUpper() == Receipt.monthly)
                {
                    allowChange = true;
                    return;
                }

                if (Receipt.isReceiptID(receiptID.Text))
                {
                    receiptID.Text = receiptID.Text.ToUpper();
                    if(receiptID.Text.Substring(0,2) != Receipt.annual)
                    {
                        MessageBox.Show("Receipt is not annual or monthly");
                    }
                    using(SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
                    {
                        try
                        {
                            connection.Open();
                            String search = "select * from " + Table.student_annual_fees.tableName + " where " + 
                                Table.student_annual_fees.receipt_id + "= '" + receiptID.Text + "';";
                            using (SqlCommand command = new SqlCommand(search, connection))
                            {
                                SqlDataReader dr = command.ExecuteReader();
                                Boolean found = false;
                                if(found = dr.Read())
                                {
                                    DateTime date;
                                    DateTime.TryParse(dr[Table.student_annual_fees.date].ToString(), out date);
                                    oldDate.Text = date.Date.Day + "-" + date.Date.Month + "-" + date.Date.Year;
                                    save.Enabled = true;
                                    isAnnual = true;
                                }
                                else
                                {
                                    MessageBox.Show("Receipt not found");
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Unable to connect " + ex.Message);
                        }
                    }    

                }
                else MessageBox.Show("Invalid Receipt ID");
            }
            else if (receiptID.TextLength == 10 && Receipt.isReceiptID(receiptID.Text))// && !Receipt.isReceiptID(receiptID.Text))
            {
                receiptID.Text = receiptID.Text.ToUpper();

                if (Receipt.isReceiptID(receiptID.Text))
                {
                    using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
                    {
                        try
                        {
                            connection.Open();
                            String search = "select * from " + Table.student_monthly_fees.tableName + " where " + 
                                Table.student_monthly_fees.receipt_id + "= '" + receiptID.Text + "';";
                            using (SqlCommand command = new SqlCommand(search, connection))
                            {
                                SqlDataReader dr = command.ExecuteReader();
                                Boolean found = false;
                                if (found = dr.Read())
                                {
                                    DateTime date;
                                    DateTime.TryParse(dr[Table.student_monthly_fees.date].ToString(), out date);
                                    oldDate.Text = date.Date.Day + "-" + date.Date.Month + "-" + date.Date.Year;
                                    save.Enabled = true;
                                    isAnnual = false;
                                }
                                else
                                {
                                    MessageBox.Show("Receipt not found");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Unable to connect " + ex.Message);
                        }
                    }
                }
                else MessageBox.Show("Invalid Receipt ID");
            }
            allowChange = true;
        }

        private void ReceiptDateChange_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.rdForm = null;
        }

        private void save_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    connection.Open();
                    String update = "update " +
                        ((isAnnual) ? Table.student_annual_fees.tableName : Table.student_monthly_fees.tableName) + " set " +
                        ((isAnnual) ? Table.student_annual_fees.date : Table.student_monthly_fees.date) + "='" +
                        newDate.Value.Date.ToString(GlobalVariables.dateFormat) + "' where " +
                        ((isAnnual) ? Table.student_annual_fees.receipt_id : Table.student_monthly_fees.receipt_id) + "='" +
                        receiptID.Text + "';";
                    using (SqlCommand command = new SqlCommand(update, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to connect " + ex.Message);
                }
            }
            textBox1_TextChanged(null, null);
        }
    }
}
