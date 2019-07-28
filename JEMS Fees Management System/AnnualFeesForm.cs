using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JEMS_Fees_Management_System
{
    public partial class AnnualFeesForm : Form
    {

        Boolean allowIDChange;
        Boolean allowCellChange;
        Boolean feesExceeds;
        Boolean allowChequeChange;
        Boolean currentAdm;
        String fatherName;
        String section;
        String receiptID;
        int[] orgFees;
        Boolean ERROR = false;
        int baseFeesTotal;
        //int[] feesToPrint;
        int session;
        String theClass;
        public AnnualFeesForm()
        {
            allowIDChange = true;
            allowCellChange = false;
            InitializeComponent();
            init();
        }

        private void AnnualFeesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.aForm = null;
        }

        private void init()
        {
            //studentExists = false;
            //feeStructExists = false;
            print.Enabled = false;
            //feesToPrint = new int[3] {0, 0 ,0 };
            receiptID = "";
            section = "";
            orgFees = new int[3];
            baseFeesTotal = 0;
            session = 0;
            AnFeesStructure.Rows.Clear();
            AnFeesStructure.Rows.Add("", "", "", "", "", "");
            studentName.Text = "";
            studentClass.Text = "";
            studentSession.Text = "";
            fatherName = "";
            AnFeesStructure.Enabled = false;
            allowCellChange = false;
            feesExceeds = false;
            currentAdm = false;
            allowChequeChange = true;
            cheque.ReadOnly = true;
            theClass = "";
        }

        private void calculateTotal()
        {
            if (!allowCellChange) return;
            allowCellChange = false;
            int t2 = 0;
            for (int i = 0; i < 3; i++)
            {
                t2 += CommonMethods.amountToInt("" + AnFeesStructure[i, 0].Value);
            }
            AnFeesStructure[3, 0].Value = CommonMethods.formatAmount("" + t2);
            feesExceeds = false;
            if (baseFeesTotal != t2)
            {
                if (baseFeesTotal < t2) feesExceeds = true;
                concession.Text = CommonMethods.formatAmount("" + (baseFeesTotal - t2));
            }
            else
            {
                concession.Text = "0.00";
            }
            allowCellChange = true;
            totalPayment.Text = "" + AnFeesStructure[3, 0].Value;
            cheque_TextChanged(null, null);
        }

        private void studentID_TextChanged(object sender, EventArgs e)
        {
            if (!allowIDChange) return;
            allowIDChange = false;

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


                        #region Student Details

                        String studentQuery = "Select * from " + Table.student_details.tableName + " where " +
                                                Table.student_details.student_id + " = '" + studentID.Text + "'";

                        using (SqlCommand command = new SqlCommand(studentQuery, connection))
                        {
                            SqlDataReader dr = command.ExecuteReader();
                            if (dr.Read())
                            {
                                fatherName = dr[Table.student_details.father_name].ToString();

                                if (dr[Table.student_details.student_category].ToString() == GlobalVariables.oldStud ||
                                    dr[Table.student_details.student_category].ToString() == GlobalVariables.manStud)
                                {
                                    currentAdm = false;
                                    AnFeesStructure.Enabled = print.Enabled = true;
                                    dateTimePicker.Enabled = true;
                                }
                                else
                                {
                                    currentAdm = true;
                                    AnFeesStructure.Enabled = false;
                                    print.Enabled = false;
                                    dateTimePicker.Enabled = false;
                                }

                                //studentExists = true;
                                String middleName = dr[Table.student_details.middle_name].ToString();
                                section = dr[Table.student_details.section].ToString();
                                if (middleName == null || middleName.Length == 0) middleName = "";
                                else middleName += " ";
                                studentName.Text = dr[Table.student_details.first_name].ToString() + " " + middleName + dr[Table.student_details.last_name].ToString();

                                if (dr[Table.student_details.student_category].ToString() == GlobalVariables.exStud)
                                {
                                    MessageBox.Show("The student is an Ex-Student");
                                    dateTimePicker.Enabled = false;
                                    allowIDChange = true;
                                    return;
                                }
                                studentClass.Text = Classes.getClassBranch(dr[Table.student_details.class_n].ToString());
                                theClass = dr[Table.student_details.class_n].ToString();

                            }
                            else
                            {
                                // #TODO
                                MessageBox.Show("Student ID does not exist");
                                dateTimePicker.Enabled = false;
                                allowIDChange = true;
                                allowCellChange = true;
                                return;
                            }
                            dr.Close();
                        }

                        #endregion

                        #region Student Annual Fees

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

                                studentSession.Text = "" + session + " - " +
                                                     (session + 1);

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
                                    print.Enabled = false;
                                    MessageBox.Show("The fees is already paid");
                                    dateTimePicker.Enabled = false;
                                    totalPayment.Text = "";
                                    cheque.ReadOnly = true;
                                }
                                else
                                {
                                    totalPayment.Text = "" + AnFeesStructure[3, 0].Value;
                                    dateTimePicker.Enabled = true;
                                    AnFeesStructure.Enabled = true;
                                    AnFeesStructure.ReadOnly = false;
                                    AnFeesStructure.Rows[0].ReadOnly = false;
                                    cheque.ReadOnly = false;
                                }
                            }
                            else
                            {
                                //#TODO Handle this
                            }
                            dr.Close();
                        }

                        #endregion

                        #region Base Fees

                        String baseFeesQuery = "Select top 1 * from " + Table.annual_base_struct.tableName + " where " +
                            Table.annual_base_struct.session + " = " + session + " and " +
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

                        #endregion
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                calculateTotal();

            }
            allowIDChange = true;
        }

        private void AnFeesStructure_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!allowCellChange) return;
            allowCellChange = false;
            for (int i = 0; i < 3; i++)
            {
                if (AnFeesStructure[i, 0].Value == null) AnFeesStructure[i, 0].Value = 0;
                AnFeesStructure[i, 0].Value = CommonMethods.formatAmount("" + AnFeesStructure[i, 0].Value);
            }
            allowCellChange = true;

            calculateTotal();
        }

        void PrintAnnualReceipt()
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.DefaultPageSettings.PaperSize = Printing.annualReceipt;
            if (GlobalVariables.preview)
            {
                PrintPreviewDialog printPrevDialog = new PrintPreviewDialog();
                printDoc.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);
                printPrevDialog.Document = printDoc;
                printDoc.PrintPage += PrintDoc_PrintPage;
                printPrevDialog.ShowDialog();
            }
            else
            {
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDoc;
                printDoc.PrintPage += PrintDoc_PrintPage;
                DialogResult result = printDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    printDoc.Print();
                }
            }
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphic = e.Graphics;

            String date = dateTimePicker.Value.ToString("dd-MM-yyyy");
            String stID = studentID.Text;
            String stName = studentName.Text;
            String fName = fatherName;
            String stClass = studentClass.Text;

            if (stName.Length > 25)
                stName = stName.Substring(0, 25) + ".";
            if (fName.Length > 23)
                fName = fName.Substring(0, 23) + ".";

            int startx = 10;
            int starty = 10;
            int yoffset = 30;
            int rectHeight = (Int32)Printing.fontHeight * 6;

            graphic.DrawString("JOHNSON ENGLISH MEDIUM H.S. SCHOOL", Printing.heading, Printing.brush, startx + 5, starty);
            graphic.DrawString("NARMADA ROAD, JABALPUR-482001", Printing.subhead, Printing.brush, startx + 40 + 10, starty + 1 * Printing.fontHeight);
            graphic.DrawString("Ph: 0761-4034114", Printing.subhead, Printing.brush, startx + 85 + 15, starty + 2 * Printing.fontHeight);
            graphic.DrawString("-----------------------------------", Printing.heading, Printing.brush, startx, starty + 3 * Printing.fontHeight - 5);
            graphic.DrawString("ANNUAL FEES RECEIPT", Printing.boldSubHead, Printing.brush, startx + 70 + 20, starty + 4 * Printing.fontHeight - 5);

            graphic.DrawString("Student ID: " + stID, Printing.other, Printing.brush, startx + 5, starty + 5 * Printing.fontHeight);
            graphic.DrawString("Receipt No: " + receiptID, Printing.other, Printing.brush, startx + 155 + 25, starty + 5 * Printing.fontHeight);
            graphic.DrawString("Date: " + date, Printing.other, Printing.brush, startx + 5, starty + 6 * Printing.fontHeight);
            graphic.DrawString("Student Name: " + stName.ToUpper(), Printing.other, Printing.brush, startx + 5, starty + 7 * Printing.fontHeight);
            starty += (int)Printing.fontHeight;

            graphic.DrawString("Father's Name: " + fName.ToUpper(), Printing.other, Printing.brush, startx + 5, starty + 7 * Printing.fontHeight);

            graphic.DrawString(stClass, Printing.other, Printing.brush, startx + 5, starty + 8 * Printing.fontHeight);
            graphic.DrawString("Section: " + section, Printing.other, Printing.brush, startx + 210 + 50, starty + 8 * Printing.fontHeight);

            graphic.DrawString("Session: " + studentSession.Text, Printing.other, Printing.brush, startx + 5, starty + 9 * Printing.fontHeight);
            yoffset += 10;
            graphic.DrawString("Details ", Printing.subhead, Printing.brush, startx + 120 + 30, starty + 8 * Printing.fontHeight + yoffset - 5);


            //graphic.FillRectangle(Printing.fillBrush, startx + 5, starty + 9 * Printing.fontHeight + yoffset, 300 - 30 + 70, Printing.fontHeight + 2);
            graphic.DrawRectangle(Printing.pen, startx + 5, starty + 9 * Printing.fontHeight + yoffset, 300 - 30 + 70, rectHeight);

            graphic.DrawString("PARTICULARS", Printing.other, Printing.brush, startx + 70, starty + 9 * Printing.fontHeight + 1 + yoffset);
            graphic.DrawString("RS.", Printing.other, Printing.brush, startx + 230 + 60, starty + 9 * Printing.fontHeight + 1 + yoffset);
            graphic.DrawLine(Printing.pen, startx + 5, starty + 10 * Printing.fontHeight + yoffset + 2, startx + 300 - 25 + 70, starty + 10 * Printing.fontHeight + yoffset + 2);

            graphic.DrawLine(Printing.pen, startx + 200 + 60, starty + 9 * Printing.fontHeight + yoffset, startx + 200 + 60, starty + 9 * Printing.fontHeight + rectHeight + yoffset);

            graphic.DrawString("1. School Development", Printing.other, Printing.brush, startx + 10, starty + 10 * Printing.fontHeight + 5 + yoffset);
            graphic.DrawString("2. Lab Development", Printing.other, Printing.brush, startx + 10, starty + 11 * Printing.fontHeight + 5 + yoffset);
            graphic.DrawString("3. Caution Money", Printing.other, Printing.brush, startx + 10, starty + 12 * Printing.fontHeight + 5 + yoffset);
            graphic.DrawLine(Printing.pen, startx + 5, starty + 13 * Printing.fontHeight + yoffset + 7, startx + 300 - 25 + 70, starty + 13 * Printing.fontHeight + yoffset + 7);
            graphic.DrawString("Total", Printing.bold, Printing.brush, startx + 30, starty + 13 * Printing.fontHeight + 10 + yoffset + 1);

            int total = 0;
            for (int i = 0; i < 3; i++)
            {
                graphic.DrawString(CommonMethods.formatAmount("" + AnFeesStructure[i, 0].Value), Printing.other, Printing.brush, startx + 220 + 60 - (AnFeesStructure[i, 0].Value.ToString().Length * Printing.fontWidth) + 45, starty + (10 + i) * Printing.fontHeight + 5 + yoffset);
                total += CommonMethods.amountToInt("" + AnFeesStructure[i, 0].Value);
            }

            graphic.DrawString(CommonMethods.formatAmount("" + total), Printing.bold, Printing.brush, startx + 215 + 60, starty + 13 * Printing.fontHeight + 10 + yoffset + 1);

            String[] words = CommonMethods.inWords(total);

            yoffset += 5;

            if (words.Length == 2)
            {
                graphic.DrawString("IN WORDS: Rs. " + words[0], Printing.other, Printing.brush, startx + 5, starty + 15 * Printing.fontHeight + yoffset);
                graphic.DrawString(" " + words[1], Printing.other, Printing.brush, startx + 5, starty + 16 * Printing.fontHeight + yoffset);
            }
            else if (words.Length == 1)
            {
                graphic.DrawString("IN WORDS: Rs. " + words[0], Printing.other, Printing.brush, startx + 5, starty + 15 * Printing.fontHeight + yoffset);
            }

            graphic.DrawString("Seal and sign.:", Printing.other, Printing.brush, startx + 5, starty + 18 * Printing.fontHeight + yoffset);
            if (CommonMethods.amountToInt("" + AnFeesStructure[2, 0].Value) != 0)
            {
                graphic.DrawString("NOTE: PLEASE PRESERVE THIS RECEIPT TO", Printing.bold, Printing.brush, startx + 5, starty + 20 * Printing.fontHeight + yoffset);
                graphic.DrawString("      CLAIM CAUTION MONEY", Printing.bold, Printing.brush, startx + 5, starty + 21 * Printing.fontHeight + yoffset);
            }
        }

        private void cheque_TextChanged(object sender, EventArgs e)
        {
            if (!allowChequeChange) return;
            allowChequeChange = false;
            cheque.Text = CommonMethods.onlyNumeric(cheque.Text);
            if (totalPayment.TextLength == 0) return;
            if (CommonMethods.amountToInt(cheque.Text) > CommonMethods.amountToInt(totalPayment.Text))
                cheque.Text = totalPayment.Text;
            allowChequeChange = true;
        }

        private String getNSetAnnualReceiptID()
        {
            String getQuery = "select " + Table.session_info.annual_rec_start + " from " +
                Table.session_info.tableName + " where " + Table.session_info.active_session + " = 1;";

            String recID = "";
            SqlDataReader dr;
            using (SqlConnection myConnection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    myConnection.Open();
                    using (SqlCommand myCommand = new SqlCommand(getQuery, myConnection))
                    {
                        dr = myCommand.ExecuteReader();
                        //#TODO check for multiple active sessions

                        if (dr.Read())
                        {
                            recID = dr[Table.session_info.annual_rec_start].ToString();
                        }

                        dr.Close();
                    }

                    //#TODO Check Limit
                    int x = Int32.Parse(recID.Substring(2)) + 1;

                    String setQuery = "update " + Table.session_info.tableName + " set " +
                        Table.session_info.annual_rec_start + "='" + recID.Substring(0, 2) + x + "' where " +
                        Table.session_info.active_session + " = 1;";
                    using (SqlCommand myCommand = new SqlCommand(setQuery, myConnection))
                    {

                        myCommand.ExecuteNonQuery();
                    }


                }
                catch
                {
                    return "";
                }
                finally
                {
                    myConnection.Close();
                }
            }

            return recID;

        }

        private void print_Click(object sender, EventArgs e)
        {
            if (feesExceeds)
            {
                DialogResult dgR = MessageBox.Show("Fees exceeds base structure, continue? ", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dgR != DialogResult.Yes)
                    return;
            }

            receiptID = getNSetAnnualReceiptID();
            if (receiptID == "" || receiptID.Equals(""))
            {
                MessageBox.Show("Unable to generate receipt ID, Please try again");
                Close();
            }
            else
            {
                String todayString = dateTimePicker.Value.ToString("yyyy-MM-dd");

                if (cheque.TextLength == 0) cheque.Text = "0";
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
                            Table.student_annual_fees.caution + " = " +
                            CommonMethods.amountToInt("" + AnFeesStructure[2, 0].Value) + ", " +
                            Table.student_annual_fees.receipt_id + " = '" + receiptID + "', " +
                            Table.student_annual_fees.date + " = '" + todayString + "', " +
                            Table.student_annual_fees.concession + " = " +
                            (concession.Text == "0.00" ? "0" : "1") + ", " +
                            Table.student_annual_fees.terminal + " = " + GlobalVariables.thisTerminal + ", " +
                            Table.student_annual_fees.cheque + " = " + cheque.Text + " where " +
                            Table.student_annual_fees.student_id + " = '" + studentID.Text + "' and " +
                            Table.student_annual_fees.session + " = " + session + ";";

                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            command.ExecuteNonQuery();

                        }
                        PrintAnnualReceipt();

                        List<String> vals = Program.mForm.receiptBox.Items.Cast<String>().ToList();
                        vals.Reverse();
                        vals.Add(receiptID + " " + DateTime.Now.ToShortTimeString());
                        vals.Reverse();
                        Program.mForm.receiptBox.Items.Clear();
                        foreach (String id in vals)
                            Program.mForm.receiptBox.Items.Add(id);
                        Program.mForm.receiptBox.SelectedIndex = 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    studentID.Text = "";
                    this.ActiveControl = studentID;
                }
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
