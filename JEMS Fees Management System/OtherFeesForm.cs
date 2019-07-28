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
    public partial class OtherFeesForm : Form
    {

        Boolean allowChange;
        Boolean dateExist;
        TextBox[] fees;

        public OtherFeesForm()
        {
            InitializeComponent();
            dateExist = false;
            fees = new TextBox[7] { adForm, belt_Tie, dupMark, dupTC, dupFC, mag, misc };
        }

        private void OtherFeesForm_Load(object sender, EventArgs e)
        {
            allowChange = true;

            
        }

        private void OtherFeesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.ofForm = null;
        }

        private void recRef_TextChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            allowChange = false;
            String temp = recRef.Text;
            recRef.Text = "";
            foreach (char c in temp)
            {
                if ((c >= '0' && c <= '9') || c == ' ' || c == '-' || c == '_' || c == ',' || c == '.')
                    recRef.Text += c;
            }
            recRef.SelectionStart = recRef.TextLength;
            checkAll();
            allowChange = true;
        }
        
        private void checkAll()
        {
            Boolean done = true;
            if (recRef.TextLength == 0) done = false;
            foreach (TextBox tb in fees)
            {
                if (tb.TextLength == 0) done = false;
            }
            save.Enabled = done;
        }

        private new void TextChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            allowChange = false;
            int tt = 0;
            foreach (TextBox tb in fees)
            {
                tb.Text = CommonMethods.onlyNumeric(tb.Text);
                if (tb.TextLength != 0) tt += Int32.Parse(tb.Text);
                tb.SelectionStart = tb.TextLength;
            }
            total.Text = "" + tt;
            checkAll();
            allowChange = true;
        }

        private void save_Click(object sender, EventArgs e)
        {
            String checkExist = "select * from " + Table.other_fees_register.tableName + " where " +
                 Table.other_fees_register.date + " = '" + entryDate.Value.ToString(GlobalVariables.dateFormat) + "' ";

            using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand insertCommand = new SqlCommand(checkExist, connection))
                    {
                        SqlDataReader dr = insertCommand.ExecuteReader();
                        if (dr.Read())
                        {
                            MessageBox.Show("Entry already made on this date");
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }



            #region entry
            String insertQuery = "insert into " + Table.other_fees_register.tableName + " (" +
                Table.other_fees_register.date + ", " +
                Table.other_fees_register.rec_ref + ", " +
                Table.other_fees_register.from_date + ", " +
                Table.other_fees_register.to_date + ", " +
                Table.other_fees_register.ad_form + ", " +
                Table.other_fees_register.belt_tie + ", " +
                Table.other_fees_register.dup_mark + ", " +
                Table.other_fees_register.dup_tc + ", " +
                Table.other_fees_register.dup_fc + ", " +
                Table.other_fees_register.mag + ", " +
                Table.other_fees_register.msc + ") values( '" +
                entryDate.Value.ToString(GlobalVariables.dateFormat) + "', '" +
                recRef.Text + "', '" +
                dateTimePicker1.Value.ToString(GlobalVariables.dateFormat) + "', '" +
                dateTimePicker2.Value.ToString(GlobalVariables.dateFormat) + "', " +
                fees[0].Text + ", " +
                fees[1].Text + ", " +
                fees[2].Text + ", " +
                fees[3].Text + ", " +
                fees[4].Text + ", " +
                fees[5].Text + ", " +
                fees[6].Text + ") ";

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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            #endregion
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
