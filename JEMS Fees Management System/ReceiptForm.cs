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
    public partial class ReceiptForm : Form
    {
        Boolean idChangeActive;

        MonthlyDetails mt;
        AdmissionDetails ad;
        AnnualDetails an;
        ProvAdmissionDetails pa;

        Timer timer;

        public ReceiptForm()
        {
            InitializeComponent();
            idChangeActive = true;
            mt = new MonthlyDetails();
            ad = new AdmissionDetails();
            an = new AnnualDetails();
            pa = new ProvAdmissionDetails();


        }

        private void receiptID_TextChanged(object sender, EventArgs e)
        {
            if (!idChangeActive) return;
            idChangeActive = false;

            Graphics gr = receiptDisplay.CreateGraphics();
            gr.Clear(Color.White);

            print.Enabled = false;
            delete.Enabled = false;

            mt = new MonthlyDetails();
            ad = new AdmissionDetails();
            an = new AnnualDetails();
            pa = new ProvAdmissionDetails();

            if (receiptID.TextLength == 8)
            {
                if (receiptID.Text.Substring(0, 2).ToUpper() == Receipt.monthly)
                {
                    idChangeActive = true;
                    return;
                }

                if (Receipt.isReceiptID(receiptID.Text))
                {
                    receiptID.Text = receiptID.Text.ToUpper();
                  
                    #region Monthly Receipt

                    if (receiptID.Text.Substring(0, 2) == Receipt.monthly)
                    {
                        fillMonthlyReceipt();
                    }

                    #endregion

                    #region Admission Receipt

                    if (receiptID.Text.Substring(0, 2) == Receipt.admission)
                    {
                        fillAdmissionReceipt();
                    }
                    #endregion

                    #region Annual Receipt

                    if (receiptID.Text.Substring(0, 2) == Receipt.annual)
                    {
                        fillAnnualReceipt();
                    }

                    #endregion

                    #region Provisional Receipt

                    if (receiptID.Text.Substring(0, 2) == Receipt.provisional)
                    {
                        fillProvisionalReceipt();
                    }

                    #endregion
                }
                else MessageBox.Show("Invalid Receipt ID");
            }
            else if (receiptID.TextLength == 10 && Receipt.isReceiptID(receiptID.Text))// && !Receipt.isReceiptID(receiptID.Text))
            {
                receiptID.Text = receiptID.Text.ToUpper();

                if (Receipt.isReceiptID(receiptID.Text))
                {
                    #region Monthly Receipt

                    if (receiptID.Text.Substring(0, 2) == Receipt.monthly)
                    {
                        fillMonthlyReceipt();
                    }

                    #endregion
                }
                else MessageBox.Show("Invalid Receipt ID");
            }
            
            idChangeActive = true;
        }

        private void ReceiptForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer.Stop();
            MainForm.rcForm = null;
        }

        #region Annual

        private void fillAnnualReceipt()
        {
            using (SqlConnection myConnection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    myConnection.Open();

                    String annualFeesDetailsQuery = "select * from " + Table.student_annual_fees.tableName + " where " +
                        Table.student_annual_fees.receipt_id + " = '" + receiptID.Text + "';";
                    using (SqlCommand myCommand = new SqlCommand(annualFeesDetailsQuery, myConnection))
                    {
                        SqlDataReader dr = myCommand.ExecuteReader();
                        if (dr.Read())
                        {
                            an.fees[0] = Convert.ToInt32(dr[Table.student_annual_fees.school_dev]);
                            an.fees[1] = Convert.ToInt32(dr[Table.student_annual_fees.lab_dev]);
                            an.fees[2] = Convert.ToInt32(dr[Table.student_annual_fees.caution]);
                            DateTime dte;
                            DateTime.TryParse(dr[Table.student_monthly_fees.date].ToString(), out dte);
                            an.date = dte.ToString("dd-MM-yyyy");
                            an.session = Convert.ToInt32(dr[Table.student_annual_fees.session]);
                            an.theClass = Classes.getClassBranch(dr[Table.student_annual_fees.class_n].ToString());
                            an.studentID = dr[Table.student_annual_fees.student_id].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Receipt not found");
                            return;
                        }

                        dr.Close();
                    }


                    String annualDetailsQuery = "select * from " + Table.student_details.tableName + " where " +
                        Table.student_details.student_id + " = '" + an.studentID + "' ";
                    using (SqlCommand myCommand = new SqlCommand(annualDetailsQuery, myConnection))
                    {
                        SqlDataReader dr = myCommand.ExecuteReader();
                        if (dr.Read())
                        {
                            an.name = dr[Table.student_details.first_name].ToString() + " " +
                                    ((dr[Table.student_details.middle_name].ToString().Length != 0) ?
                                        (dr[Table.student_details.middle_name].ToString() + " ") : "") +
                                        dr[Table.student_details.last_name].ToString();
                            an.fName = dr[Table.student_details.father_name].ToString();

                            if (dr[Table.student_details.current_session] != DBNull.Value &&
                                an.session == Convert.ToInt32(dr[Table.student_details.current_session]))
                                an.deletable = true;
                            else an.deletable = false;
                            an.section = dr[Table.student_details.section].ToString();

                        }
                        else
                        {
                            MessageBox.Show("Receipt not found");
                            return;
                        }
                        dr.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong");
                    MessageBox.Show(ex.Message);
                    return;
                }
                if (an.name.Length > 25)
                    an.name = an.name.Substring(0, 25) + ".";
                if (an.fName.Length > 23)
                    an.fName = an.fName.Substring(0, 23) + ".";
                an.active = true;
                drawAnnual(receiptDisplay.CreateGraphics());
                delete.Enabled = an.deletable;
                print.Enabled = true;
            }
        }

        void PrintAnnualReceipt()
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.DefaultPageSettings.PaperSize = Printing.annualReceipt;
            if (GlobalVariables.preview)
            {
                PrintPreviewDialog printPrevDialog = new PrintPreviewDialog();
                printDoc.DefaultPageSettings.Margins = new Margins(1000, 1000, 1000, 1000);
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

        private void drawAnnual(Graphics graphic)
        {
            if (!an.active) return;

            #region Drawing

            int startx = 10;
            int starty = 10;
            int yoffset = 30;
            int rectHeight = (Int32)Printing.fontHeight * 6;

            graphic.DrawString("JOHNSON ENGLISH MEDIUM H.S. SCHOOL", Printing.heading, Printing.brush, startx + 5, starty);
            graphic.DrawString("NARMADA ROAD, JABALPUR-482001", Printing.subhead, Printing.brush, startx + 50, starty + 1 * Printing.fontHeight);
            graphic.DrawString("Ph: 0761-4034114", Printing.subhead, Printing.brush, startx + 100, starty + 2 * Printing.fontHeight);
            graphic.DrawString("-----------------------------------", Printing.heading, Printing.brush, startx, starty + 3 * Printing.fontHeight - 5);
            graphic.DrawString("ANNUAL FEES RECEIPT", Printing.boldSubHead, Printing.brush, startx + 90, starty + 4 * Printing.fontHeight - 5);

            graphic.DrawString("Student ID: " + an.studentID, Printing.other, Printing.brush, startx + 5, starty + 5 * Printing.fontHeight);
            graphic.DrawString("Receipt No: " + receiptID.Text, Printing.other, Printing.brush, startx + 180, starty + 5 * Printing.fontHeight);
            graphic.DrawString("Date: " + an.date, Printing.other, Printing.brush, startx + 5, starty + 6 * Printing.fontHeight);
            graphic.DrawString("Student Name: " + an.name.ToUpper(), Printing.other, Printing.brush, startx + 5, starty + 7 * Printing.fontHeight);
            starty += (int)Printing.fontHeight;

            graphic.DrawString("Father's Name: " + an.fName.ToUpper(), Printing.other, Printing.brush, startx + 5, starty + 7 * Printing.fontHeight);

            graphic.DrawString("Class: " + an.theClass, Printing.other, Printing.brush, startx + 5, starty + 8 * Printing.fontHeight);
            graphic.DrawString("Section: " + an.section, Printing.other, Printing.brush, startx + 260, starty + 8 * Printing.fontHeight);

            graphic.DrawString("Session: " + an.session + " - " + (an.session + 1), Printing.other, Printing.brush, startx + 5, starty + 9 * Printing.fontHeight);
            yoffset += 10;
            graphic.DrawString("Details ", Printing.subhead, Printing.brush, startx + 150, starty + 8 * Printing.fontHeight + yoffset - 5);


            //graphic.FillRectangle(Printing.fillBrush, startx + 5, starty + 9 * Printing.fontHeight + yoffset, 370 - 30, Printing.fontHeight + 2);
            graphic.DrawRectangle(Printing.pen, startx + 5, starty + 9 * Printing.fontHeight + yoffset, 370 - 30, rectHeight);

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
                graphic.DrawString(CommonMethods.formatAmount("" + an.fees[i]), Printing.other, Printing.brush, startx + 220 + 60 - ((an.fees[i].ToString().Length - 1) * Printing.fontWidth) + 15, starty + (10 + i) * Printing.fontHeight + 5 + yoffset);
                total += CommonMethods.amountToInt("" + an.fees[i]);
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

            graphic.DrawString("Seal and sign.: ", Printing.other, Printing.brush, startx + 5, starty + 17 * Printing.fontHeight + yoffset);
            if (CommonMethods.amountToInt("" + an.fees[2]) != 0)
            {
                graphic.DrawString("NOTE: PLEASE PRESERVE THIS RECEIPT TO", Printing.bold, Printing.brush, startx + 5, starty + 23 * Printing.fontHeight + yoffset);
                graphic.DrawString("      CLAIM CAUTION MONEY", Printing.bold, Printing.brush, startx + 5, starty + 24 * Printing.fontHeight + yoffset);
            }


            #endregion
        }

        #endregion

        #region monthly

        private void fillMonthlyReceipt()
        {
            int fromMonth = 15, toMonth = -1;
            using (SqlConnection myConnection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    myConnection.Open();

                    String monthlyDetailsQuery = "select * from " + Table.student_monthly_fees.tableName + " where " +
                        Table.student_monthly_fees.receipt_id + " = '" + receiptID.Text + "';";

                    using (SqlCommand myCommand = new SqlCommand(monthlyDetailsQuery, myConnection))
                    {
                        SqlDataReader dr = myCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            mt.studentID = dr[Table.student_monthly_fees.student_id].ToString();
                            mt.fees[0] += Convert.ToInt32(dr[Table.student_monthly_fees.tuition]);
                            mt.fees[1] += Convert.ToInt32(dr[Table.student_monthly_fees.management]);
                            mt.fees[2] += Convert.ToInt32(dr[Table.student_monthly_fees.smart_class]);
                            mt.fees[3] += Convert.ToInt32(dr[Table.student_monthly_fees.report_diary]);
                            mt.fees[4] += Convert.ToInt32(dr[Table.student_monthly_fees.insurance]) +
                                       Convert.ToInt32(dr[Table.student_monthly_fees.sports]) +
                                       Convert.ToInt32(dr[Table.student_monthly_fees.red_cross]) +
                                       Convert.ToInt32(dr[Table.student_monthly_fees.science]) +
                                       Convert.ToInt32(dr[Table.student_monthly_fees.guide]);
                            mt.fees[5] += Convert.ToInt32(dr[Table.student_monthly_fees.school_activities]);
                            mt.fees[6] += Convert.ToInt32(dr[Table.student_monthly_fees.computer]);
                            mt.fees[7] += Convert.ToInt32(dr[Table.student_monthly_fees.local_exam]);
                            mt.fees[8] += Convert.ToInt32(dr[Table.student_monthly_fees.late_fees]);
                            DateTime dte;
                            DateTime.TryParse(dr[Table.student_monthly_fees.date].ToString(), out dte);
                            mt.date = dte.ToString("dd-MM-yyyy");
                            mt.session = Convert.ToInt32(dr[Table.student_monthly_fees.session]);
                            mt.theClass = Classes.getClassBranch(dr[Table.student_monthly_fees.class_n].ToString());

                            String month = dr[Table.student_monthly_fees.month].ToString();

                            for (int i = 0; i < 12; i++)
                            {
                                if (GlobalVariables.db_months[i] == month)
                                {
                                    if (i < fromMonth) fromMonth = i;
                                    if (i > toMonth) toMonth = i;
                                }
                            }
                        }
                        dr.Close();
                        if (fromMonth != 15)
                            mt.fMonth = GlobalVariables.months[fromMonth];
                        if (toMonth != -1)
                            mt.tMonth = GlobalVariables.months[toMonth];

                        if (mt.studentID.Length == 0)
                        {
                            MessageBox.Show("Receipt not found");
                            return;
                        }
                    }

                    if (toMonth == 11)
                    {
                        String checkForCompleteSession = "select * from " + Table.student_details.tableName + " where " +
                             Table.student_details.student_id + " = '" + mt.studentID + "';";
                        using (SqlCommand myCommand = new SqlCommand(checkForCompleteSession, myConnection))
                        {
                            SqlDataReader dr = myCommand.ExecuteReader();
                            if (dr.Read())
                            {
                                if (dr[Table.student_details.current_session] != DBNull.Value &&
                                    mt.session == Convert.ToInt32(dr[Table.student_details.current_session]))
                                    mt.deletable = true;
                                else mt.deletable = false;
                            }
                            else mt.deletable = false;
                            dr.Close();
                        }
                    }
                    else
                    {
                        String checkNextMonth = "select * from " + Table.student_monthly_fees.tableName + " where " +
                                Table.student_monthly_fees.student_id + " = '" + mt.studentID + "' and " +
                                Table.student_monthly_fees.session + " = " + mt.session + " and " +
                                Table.student_monthly_fees.month + " = '" + GlobalVariables.db_months[toMonth + 1] + "' and " +
                                Table.student_monthly_fees.receipt_id + " is not null;";
                        using (SqlCommand myCommand = new SqlCommand(checkNextMonth, myConnection))
                        {
                            SqlDataReader dr = myCommand.ExecuteReader();
                            if (dr.Read()) mt.deletable = false;
                            else mt.deletable = true;
                            dr.Close();
                        }
                    }
                    String studentDetailsQuery = "Select * from " + Table.student_details.tableName + " where " +
                        Table.student_details.student_id + " = '" + mt.studentID + "'; ";
                    using (SqlCommand myCommand = new SqlCommand(studentDetailsQuery, myConnection))
                    {
                        SqlDataReader dr = myCommand.ExecuteReader();
                        if (dr.Read())
                        {
                            mt.name = dr[Table.student_details.first_name].ToString() + " " +
                                    ((dr[Table.student_details.middle_name].ToString().Length != 0) ?
                                        (dr[Table.student_details.middle_name].ToString() + " ") : "") +
                                        dr[Table.student_details.last_name].ToString();
                            mt.section = dr[Table.student_details.section].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Something went wrong");
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            if (mt.name.Length > 25)
                mt.name = mt.name.Substring(0, 25) + ".";
            if (mt.fName.Length > 23)
                mt.fName = mt.fName.Substring(0, 23) + ".";
            mt.active = true;
            drawMonthly(receiptDisplay.CreateGraphics());
            print.Enabled = true;
            delete.Enabled = mt.deletable;
        }

        private void drawMonthly(Graphics graphic)
        {
            if (!mt.active) return;

            #region Drawing
            //Graphics graphic = receiptDisplay.CreateGraphics();

            int startx = 10;
            int starty = 10;
            int yoffset = 30;
            int rectHeight = (Int32)(Printing.fontHeight * 12);
            
            graphic.DrawString("JOHNSON ENGLISH MEDIUM H.S. SCHOOL", Printing.heading, Printing.brush, startx + 5, starty);
            graphic.DrawString("NARMADA ROAD, JABALPUR-482001", Printing.subhead, Printing.brush, startx + 40 + 10, starty + 1 * Printing.fontHeight);
            graphic.DrawString("Ph: 0761-4034114", Printing.subhead, Printing.brush, startx + 85 + 20, starty + 2 * Printing.fontHeight);
            graphic.DrawString("-----------------------------------", Printing.heading, Printing.brush, startx, starty + 3 * Printing.fontHeight - 5);
            graphic.DrawString("MONTHLY FEES RECEIPT", Printing.subhead, Printing.brush, startx + 70 + 15, starty + 4 * Printing.fontHeight - 5);

            graphic.DrawString("Student ID:" + mt.studentID, Printing.other, Printing.brush, startx + 5, starty + 5 * Printing.fontHeight);
            graphic.DrawString("Receipt No:" + receiptID.Text, Printing.other, Printing.brush, startx + 155 + 20, starty + 5 * Printing.fontHeight);
            graphic.DrawString("Date: " + mt.date, Printing.other, Printing.brush, startx + 5, starty + 6 * Printing.fontHeight);
            graphic.DrawString("Student Name: " + mt.name.ToUpper(), Printing.other, Printing.brush, startx + 5, starty + 7 * Printing.fontHeight);

            graphic.DrawString("Class: " + mt.theClass, Printing.other, Printing.brush, startx + 5, starty + 8 * Printing.fontHeight);
            graphic.DrawString("Section: " + mt.section, Printing.other, Printing.brush, startx + 210 + 50, starty + 8 * Printing.fontHeight);

            if (mt.fMonth == mt.tMonth)
                graphic.DrawString("Fee for month: " + mt.fMonth, Printing.other, Printing.brush, startx + 5, starty + 9 * Printing.fontHeight);
            else
                graphic.DrawString("Fee Duration: " + mt.fMonth + " - " + mt.tMonth, Printing.other, Printing.brush, startx + 5, starty + 9 * Printing.fontHeight);

            graphic.DrawString("Session: " + mt.session + " - " + (mt.session + 1), Printing.other, Printing.brush, startx + 5, starty + 10 * Printing.fontHeight);
            yoffset += (Int32)Printing.fontHeight;
            yoffset += 10;
            graphic.DrawString("Details ", Printing.subhead, Printing.brush, startx + 120 + 30, starty + 8 * Printing.fontHeight + yoffset - 5);

            graphic.FillRectangle(Printing.fillBrush, startx + 5, starty + 9 * Printing.fontHeight + yoffset, 300 - 30 + 70, Printing.fontHeight + 2);
            graphic.DrawRectangle(Printing.pen, startx + 5, starty + 9 * Printing.fontHeight + yoffset, 300 - 30 + 70, rectHeight);

            graphic.DrawString("PARTICULARS", Printing.other, Printing.brush, startx + 70, starty + 9 * Printing.fontHeight + 1 + yoffset);
            graphic.DrawString("RS.", Printing.other, Printing.brush, startx + 230 + 60, starty + 9 * Printing.fontHeight + 1 + yoffset);
            graphic.DrawLine(Printing.pen, startx + 5, starty + 10 * Printing.fontHeight + yoffset + 2, startx + 300 - 25 + 70, starty + 10 * Printing.fontHeight + yoffset + 2);

            graphic.DrawLine(Printing.pen, startx + 200 + 60, starty + 9 * Printing.fontHeight + yoffset, startx + 200 + 60, starty + 9 * Printing.fontHeight + rectHeight + yoffset);

            graphic.DrawString("1. Tuition Fees", Printing.other, Printing.brush, startx + 10, starty + 10 * Printing.fontHeight + 5 + yoffset);
            graphic.DrawString("2. Management Fees", Printing.other, Printing.brush, startx + 10, starty + 11 * Printing.fontHeight + 5 + yoffset);
            graphic.DrawString("3. Smart Class Fees", Printing.other, Printing.brush, startx + 10, starty + 12 * Printing.fontHeight + 5 + yoffset);
            graphic.DrawString("4. Report Card/Diary", Printing.other, Printing.brush, startx + 10, starty + 13 * Printing.fontHeight + 5 + yoffset);
            graphic.DrawString("5. Other Funds", Printing.other, Printing.brush, startx + 10, starty + 14 * Printing.fontHeight + 5 + yoffset);
            graphic.DrawString("6. School Activities", Printing.other, Printing.brush, startx + 10, starty + 15 * Printing.fontHeight + 5 + yoffset);
            graphic.DrawString("7. Computer Fees/I.P.", Printing.other, Printing.brush, startx + 10, starty + 16 * Printing.fontHeight + 5 + yoffset);
            graphic.DrawString("8. Local Exam", Printing.other, Printing.brush, startx + 10, starty + 17 * Printing.fontHeight + 5 + yoffset);
            graphic.DrawString("9. Late Fees", Printing.other, Printing.brush, startx + 10, starty + 18 * Printing.fontHeight + 5 + yoffset);

            graphic.DrawLine(Printing.pen, startx + 5, starty + 19 * Printing.fontHeight + yoffset + 7, starty + 300 - 25 + 70, starty + 19 * Printing.fontHeight + yoffset + 7);
            graphic.DrawString("Total", Printing.bold, Printing.brush, startx + 30, starty + 19 * Printing.fontHeight + 10 + yoffset + 1);

            int total = 0;
            for (int i = 0; i < 9; i++)
            {
                graphic.DrawString(CommonMethods.formatAmount("" + mt.fees[i]), Printing.other, Printing.brush, startx + 220 + 50 - ((mt.fees[i].ToString().Length - 1) * Printing.fontWidth) + 30, starty + (10 + i) * Printing.fontHeight + 5 + yoffset);
                total += mt.fees[i];
            }
            graphic.DrawString(CommonMethods.formatAmount("" + total), Printing.bold, Printing.brush, startx + 215 + 50 + 10 - ((total.ToString().Length + 1) * Printing.boldFontWidth) + 45, starty + 19 * Printing.fontHeight + 10 + yoffset + 1);

            String[] words = CommonMethods.inWords(total);

            if (words.Length == 2)
            {
                graphic.DrawString("IN WORDS: Rs. " + words[0], Printing.other, Printing.brush, startx + 5, starty + 22 * Printing.fontHeight + yoffset);
                graphic.DrawString(" " + words[1], Printing.other, Printing.brush, startx + 5, starty + 23 * Printing.fontHeight + yoffset);
            }
            else if (words.Length == 1)
            {
                graphic.DrawString("IN WORDS: Rs. " + words[0], Printing.other, Printing.brush, startx + 5, starty + 22 * Printing.fontHeight + yoffset);
            }

            graphic.DrawString("Seal and sign.: ", Printing.other, Printing.brush, startx + 5, starty + 25 * Printing.fontHeight + yoffset);

            #endregion

        }

        void PrintMonthlyReceipt()
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.DefaultPageSettings.PaperSize = Printing.monthlyReceipt;
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

        #endregion

        #region Admission

        private void fillAdmissionReceipt()
        {
            using (SqlConnection myConnection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    myConnection.Open();

                    String admissionDetailsQuery = "select * from " + Table.student_details.tableName + " where " +
                        Table.student_details.receipt_id + " = '" + receiptID.Text + "';";
                    using (SqlCommand myCommand = new SqlCommand(admissionDetailsQuery, myConnection))
                    {
                        SqlDataReader dr = myCommand.ExecuteReader();
                        if (dr.Read())
                        {
                            ad.name = dr[Table.student_details.first_name].ToString() + " " +
                                    ((dr[Table.student_details.middle_name].ToString().Length != 0) ?
                                        (dr[Table.student_details.middle_name].ToString() + " ") : "") +
                                        dr[Table.student_details.last_name].ToString();
                            ad.studentID = dr[Table.student_details.student_id].ToString();
                            ad.fName = dr[Table.student_details.father_name].ToString();
                            ad.fees[0] = Convert.ToInt32(dr[Table.student_details.admission_fees]);
                            ad.fees[2] = Convert.ToInt32(dr[Table.student_details.furniture_fund]);
                            ad.fees[5] = Convert.ToInt32(dr[Table.student_details.belt_tie]);
                            ad.section = dr[Table.student_details.section].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Receipt not found");
                            return;
                        }
                        dr.Close();
                    }
                    String admissionFeesDetailsQuery = "select * from " + Table.student_annual_fees.tableName + " where " +
                        Table.student_annual_fees.receipt_id + " = '" + receiptID.Text + "';";
                    using (SqlCommand myCommand = new SqlCommand(admissionFeesDetailsQuery, myConnection))
                    {
                        SqlDataReader dr = myCommand.ExecuteReader();
                        if (dr.Read())
                        {
                            ad.fees[1] = Convert.ToInt32(dr[Table.student_annual_fees.school_dev]);
                            ad.fees[3] = Convert.ToInt32(dr[Table.student_annual_fees.lab_dev]);
                            ad.fees[4] = Convert.ToInt32(dr[Table.student_annual_fees.caution]);
                            DateTime dte;
                            DateTime.TryParse(dr[Table.student_monthly_fees.date].ToString(), out dte);
                            ad.date = dte.ToString("dd-MM-yyyy");
                            ad.session = Convert.ToInt32(dr[Table.student_annual_fees.session]);
                            ad.theClass = Classes.getClassBranch(dr[Table.student_annual_fees.class_n].ToString());
                        }
                        else
                        {
                            MessageBox.Show("Receipt not found");
                            return;
                        }

                        dr.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong");
                    MessageBox.Show(ex.Message);
                    return;
                }
                if (ad.name.Length > 25)
                    ad.name = ad.name.Substring(0, 25) + ".";
                if (ad.fName.Length > 23)
                    ad.fName = ad.fName.Substring(0, 23) + ".";

                ad.active = true;
                drawAdmission(receiptDisplay.CreateGraphics());
                print.Enabled = true;
            }
        }

        void PrintAdmissionReceipt()
        {

            PrintDocument printDoc = new PrintDocument();
            printDoc.DefaultPageSettings.PaperSize = Printing.admissionReceipt;
            if (GlobalVariables.preview)
            {
                PrintPreviewDialog printPrevDialog = new PrintPreviewDialog();
                printDoc.DefaultPageSettings.Margins = new Margins(1000, 1000, 1000, 1000);
                printPrevDialog.Document = printDoc;
                printDoc.PrintPage += PrintDoc_PrintPage;
                printPrevDialog.ShowDialog();
            }
            else
            {
                PrintDialog printDialog = new PrintDialog();
                printDoc.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);
                printDialog.Document = printDoc;
                printDoc.PrintPage += PrintDoc_PrintPage;
                DialogResult result = printDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    printDoc.Print();
                }
            }
        }

        private void drawAdmission(Graphics graphic)
        {
            if (!ad.active) return;

            #region Drawing


            int startx = 10;
            int starty = 10;
            int yoffset = 30;
            int rectHeight = (Int32)Printing.fontHeight * 9;

            graphic.DrawString("JOHNSON ENGLISH MEDIUM H.S. SCHOOL", Printing.heading, Printing.brush, startx + 5, starty);
            graphic.DrawString("NARMADA ROAD, JABALPUR-482001", Printing.subhead, Printing.brush, startx + 50, starty + 1 * Printing.fontHeight);
            graphic.DrawString("Ph: 0761-4034114", Printing.subhead, Printing.brush, startx + 100, starty + 2 * Printing.fontHeight);
            graphic.DrawString("-----------------------------------", Printing.heading, Printing.brush, startx, starty + 3 * Printing.fontHeight - 5);
            graphic.DrawString("ADMISSION RECEIPT", Printing.boldSubHead, Printing.brush, startx + 80 + 20, starty + 4 * Printing.fontHeight - 5);

            graphic.DrawString("Student ID: " + ad.studentID, Printing.other, Printing.brush, startx + 5, starty + 5 * Printing.fontHeight);
            graphic.DrawString("Receipt No: " + receiptID.Text, Printing.other, Printing.brush, startx + 155 + 35, starty + 5 * Printing.fontHeight);
            graphic.DrawString("Date: " + ad.date, Printing.other, Printing.brush, startx + 5, starty + 6 * Printing.fontHeight);
            graphic.DrawString("Student Name: " + ad.name.ToUpper(), Printing.other, Printing.brush, startx + 5, starty + 7 * Printing.fontHeight);
            starty += (int)Printing.fontHeight;

            graphic.DrawString("Father's Name: " + ad.fName.ToUpper(), Printing.other, Printing.brush, startx + 5, starty + 7 * Printing.fontHeight);

            graphic.DrawString("Class: " + ad.theClass, Printing.other, Printing.brush, startx + 5, starty + 8 * Printing.fontHeight);
            graphic.DrawString("Section: " + ad.section, Printing.other, Printing.brush, startx + 210 + 50, starty + 8 * Printing.fontHeight);

            graphic.DrawString("Session: " + ad.session + "-" + (ad.session + 1), Printing.other, Printing.brush, startx + 5, starty + 9 * Printing.fontHeight);
            yoffset += 10;
            graphic.DrawString("Details ", Printing.subhead, Printing.brush, startx + 120 + 40, starty + 8 * Printing.fontHeight + yoffset - 5);


            graphic.FillRectangle(Printing.fillBrush, startx + 5, starty + 9 * Printing.fontHeight + yoffset, 300 - 30 + 70, Printing.fontHeight + 2);
            graphic.DrawRectangle(Printing.pen, startx + 5, starty + 9 * Printing.fontHeight + yoffset, 300 - 30 + 70, rectHeight);

            graphic.DrawString("PARTICULARS", Printing.other, Printing.brush, startx + 70, starty + 9 * Printing.fontHeight + 1 + yoffset);
            graphic.DrawString("RS.", Printing.other, Printing.brush, startx + 230 + 60, starty + 9 * Printing.fontHeight + 1 + yoffset);
            graphic.DrawLine(Printing.pen, startx + 5, starty + 10 * Printing.fontHeight + yoffset + 2, startx + 300 - 25 + 70, starty + 10 * Printing.fontHeight + yoffset + 2);

            graphic.DrawLine(Printing.pen, startx + 200 + 60, starty + 9 * Printing.fontHeight + yoffset, startx + 200 + 60, starty + 9 * Printing.fontHeight + rectHeight + yoffset);

            graphic.DrawString("1. Admission Fees", Printing.other, Printing.brush, startx + 10, starty + 10 * Printing.fontHeight + 5 + yoffset);
            graphic.DrawString("2. School Development", Printing.other, Printing.brush, startx + 10, starty + 11 * Printing.fontHeight + 5 + yoffset);
            graphic.DrawString("3. Furniture Fund", Printing.other, Printing.brush, startx + 10, starty + 12 * Printing.fontHeight + 5 + yoffset);
            graphic.DrawString("4. Lab Development", Printing.other, Printing.brush, startx + 10, starty + 13 * Printing.fontHeight + 5 + yoffset);
            graphic.DrawString("5. Caution Money", Printing.other, Printing.brush, startx + 10, starty + 14 * Printing.fontHeight + 5 + yoffset);
            graphic.DrawString("6. Belt & Tie", Printing.other, Printing.brush, startx + 10, starty + 15 * Printing.fontHeight + 5 + yoffset);
            yoffset += (int)Printing.fontHeight * 3;
            graphic.DrawLine(Printing.pen, startx + 5, starty + 13 * Printing.fontHeight + yoffset + 7, startx + 300 - 25 + 70, starty + 13 * Printing.fontHeight + yoffset + 7);
            graphic.DrawString("Total", Printing.bold, Printing.brush, startx + 30, starty + 13 * Printing.fontHeight + 10 + yoffset + 1);

            int total = 0;
            for (int i = 0; i < 6; i++)
            {
                graphic.DrawString(CommonMethods.formatAmount("" + ad.fees[i]), Printing.other, Printing.brush, startx + 220 + 60 - ((ad.fees[i].ToString().Length - 1) * Printing.fontWidth) + 20, starty + (7 + i) * Printing.fontHeight + 5 + yoffset);
                total += CommonMethods.amountToInt("" + ad.fees[i]);
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

            graphic.DrawString("Seal and sign.: ", Printing.other, Printing.brush, startx + 5, starty + 18 * Printing.fontHeight + yoffset);
            if (CommonMethods.amountToInt("" + ad.fees[4]) != 0)
            {
                graphic.DrawString("NOTE: PLEASE PRESERVE THIS RECEIPT TO", Printing.bold, Printing.brush, startx + 5, starty + 20 * Printing.fontHeight + yoffset);
                graphic.DrawString("      CLAIM CAUTION MONEY", Printing.bold, Printing.brush, startx + 5, starty + 21 * Printing.fontHeight + yoffset);
            }

            #endregion
        }

        #endregion

        #region Provisional

        private void fillProvisionalReceipt()
        {
            using (SqlConnection myConnection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    myConnection.Open();

                    String pvAdmissionDetailsQuery = "select * from " + Table.student_details.tableName + " where " +
                        Table.student_details.receipt_id + " = '" + receiptID.Text + "';";
                    using (SqlCommand myCommand = new SqlCommand(pvAdmissionDetailsQuery, myConnection))
                    {
                        SqlDataReader dr = myCommand.ExecuteReader();
                        if (dr.Read())
                        {
                            pa.name = dr[Table.student_details.first_name].ToString() + " " +
                                    ((dr[Table.student_details.middle_name].ToString().Length != 0) ?
                                        (dr[Table.student_details.middle_name].ToString() + " ") : "") +
                                        dr[Table.student_details.last_name].ToString();
                            pa.studentID = dr[Table.student_details.student_id].ToString();
                            pa.fName = dr[Table.student_details.father_name].ToString();
                            pa.fees[0] = Convert.ToInt32(dr[Table.student_details.admission_fees]);
                            pa.fees[2] = Convert.ToInt32(dr[Table.student_details.furniture_fund]);
                            pa.fees[5] = Convert.ToInt32(dr[Table.student_details.belt_tie]);
                            pa.section = dr[Table.student_details.section].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Receipt not found");
                            return;
                        }
                        dr.Close();
                    }
                    String pvAdmissionFeesDetailsQuery = "select * from " + Table.student_annual_fees.tableName + " where " +
                        Table.student_annual_fees.receipt_id + " = '" + receiptID.Text + "';";
                    using (SqlCommand myCommand = new SqlCommand(pvAdmissionFeesDetailsQuery, myConnection))
                    {
                        SqlDataReader dr = myCommand.ExecuteReader();
                        if (dr.Read())
                        {
                            pa.fees[1] = Convert.ToInt32(dr[Table.student_annual_fees.school_dev]);
                            pa.fees[3] = Convert.ToInt32(dr[Table.student_annual_fees.lab_dev]);
                            pa.fees[4] = Convert.ToInt32(dr[Table.student_annual_fees.caution]);
                            DateTime dte;
                            DateTime.TryParse(dr[Table.student_monthly_fees.date].ToString(), out dte);
                            pa.date = dte.ToString("dd-MM-yyyy");
                            pa.session = Convert.ToInt32(dr[Table.student_annual_fees.session]);
                            pa.theClass = Classes.getClassBranch(dr[Table.student_annual_fees.class_n].ToString());
                        }
                        else
                        {
                            MessageBox.Show("Receipt not found");
                            return;
                        }

                        dr.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong");
                    MessageBox.Show(ex.Message);
                    return;
                }
                if (pa.name.Length > 25)
                    pa.name = pa.name.Substring(0, 25) + ".";
                if (pa.fName.Length > 23)
                    pa.fName = pa.fName.Substring(0, 23) + ".";
                pa.active = true;
                drawAdmission(receiptDisplay.CreateGraphics());
                print.Enabled = true;
            }

        }

        void PrintProvAdmissionReceipt()
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.DefaultPageSettings.PaperSize = Printing.provisionalReceipt;
            if (GlobalVariables.preview)
            {
                PrintPreviewDialog printPrevDialog = new PrintPreviewDialog();
                printDoc.DefaultPageSettings.Margins = new Margins(1000, 1000, 1000, 1000);
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

        private void drawProvAdmission(Graphics graphic)
        {
            if (!pa.active) return;

            #region Drawing
            int startx = 10;
            int starty = 10;
            int yoffset = 30;
            int rectHeight = (Int32)(Printing.fontHeight * 2.5);

            graphic.DrawString("JOHNSON ENGLISH MEDIUM H.S. SCHOOL", Printing.heading, Printing.brush, startx + 5, starty);
            graphic.DrawString("NARMADA ROAD, JABALPUR-482001", Printing.subhead, Printing.brush, startx + 40 + 10, starty + 1 * Printing.fontHeight);
            graphic.DrawString("Ph: 0761-4034114", Printing.subhead, Printing.brush, startx + 85 + 15, starty + 2 * Printing.fontHeight);
            graphic.DrawString("-----------------------------------", Printing.heading, Printing.brush, startx, starty + 3 * Printing.fontHeight - 5);
            graphic.DrawString("PROVISIONAL ADMISSION RECEIPT", Printing.boldSubHead, Printing.brush, startx + 40 + 10, starty + 4 * Printing.fontHeight - 5);

            graphic.DrawString("Student ID: " + pa.studentID, Printing.other, Printing.brush, startx + 5, starty + 5 * Printing.fontHeight);
            graphic.DrawString("Receipt No: " + receiptID.Text, Printing.other, Printing.brush, startx + 155 + 20, starty + 5 * Printing.fontHeight);
            graphic.DrawString("Date: " + pa.date, Printing.other, Printing.brush, startx + 5, starty + 6 * Printing.fontHeight);
            graphic.DrawString("Student Name: " + pa.name.ToUpper(), Printing.other, Printing.brush, startx + 5, starty + 7 * Printing.fontHeight);
            starty += (int)Printing.fontHeight;

            graphic.DrawString("Father's Name: " + pa.fName.ToUpper(), Printing.other, Printing.brush, startx + 5, starty + 7 * Printing.fontHeight);

            graphic.DrawString("Class: " + pa.theClass, Printing.other, Printing.brush, startx + 5, starty + 8 * Printing.fontHeight);
            graphic.DrawString("Section: " + pa.section, Printing.other, Printing.brush, startx + 210 + 50, starty + 8 * Printing.fontHeight);

            graphic.DrawString("Session: " + pa.session + " - " + (pa.session + 1), Printing.other, Printing.brush, startx + 5, starty + 9 * Printing.fontHeight);
            yoffset += 10;
            graphic.DrawString("Details ", Printing.subhead, Printing.brush, startx + 120 + 40, starty + 8 * Printing.fontHeight + yoffset - 5);


            graphic.FillRectangle(Printing.fillBrush, startx + 5, starty + 9 * Printing.fontHeight + yoffset, 300 - 30 + 70, Printing.fontHeight + 2);
            graphic.DrawRectangle(Printing.pen, startx + 5, starty + 9 * Printing.fontHeight + yoffset, 300 - 30 + 70, rectHeight);

            graphic.DrawString("PARTICULARS", Printing.other, Printing.brush, startx + 70, starty + 9 * Printing.fontHeight + 1 + yoffset);
            graphic.DrawString("RS.", Printing.other, Printing.brush, startx + 230 + 60, starty + 9 * Printing.fontHeight + 1 + yoffset);
            graphic.DrawLine(Printing.pen, startx + 5, starty + 10 * Printing.fontHeight + yoffset + 2, startx + 300 - 25 + 70, starty + 10 * Printing.fontHeight + yoffset + 2);

            graphic.DrawLine(Printing.pen, startx + 200 + 60, starty + 9 * Printing.fontHeight + yoffset, startx + 200 + 60, starty + 9 * Printing.fontHeight + rectHeight + yoffset);
            /*
            graphic.DrawString("1. Admission Fees", Printing.other, Printing.brush, startx + 10, starty + 10 * Printing.fontHeight + 5 + yoffset);
            graphic.DrawString("2. School Development", Printing.other, Printing.brush, startx + 10, starty + 11 * Printing.fontHeight + 5 + yoffset);
            graphic.DrawString("3. Furniture Fund", Printing.other, Printing.brush, startx + 10, starty + 12 * Printing.fontHeight + 5 + yoffset);
            graphic.DrawString("4. Lab Development", Printing.other, Printing.brush, startx + 10, starty + 13 * Printing.fontHeight + 5 + yoffset);
            graphic.DrawString("5. Caution", Printing.other, Printing.brush, startx + 10, starty + 14 * Printing.fontHeight + 5 + yoffset);
            graphic.DrawString("6. Belt & Tie", Printing.other, Printing.brush, startx + 10, starty + 15 * Printing.fontHeight + 5 + yoffset);
            */
            yoffset -= (int)(Printing.fontHeight * 3.5);
            //graphic.DrawLine(Printing.pen, startx + 5, starty + 13 * Printing.fontHeight + yoffset + 7, startx + 300 - 25, starty + 13 * Printing.fontHeight + yoffset + 7);
            graphic.DrawString("Provisional", Printing.bold, Printing.brush, startx + 30, starty + 13 * Printing.fontHeight + 10 + yoffset + 1);

            int total = 0;
            for (int i = 0; i < 6; i++)
            {
                //graphic.DrawString(CommonMethods.formatAmount("" + admissionFeesStruct[i, 0].Value), Printing.other, Printing.brush, startx + 220, starty + (7 + i) * Printing.fontHeight + 5 + yoffset);
                total += CommonMethods.amountToInt("" + pa.fees[i]);
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

            graphic.DrawString("Seal and sign.: ", Printing.other, Printing.brush, startx + 5, starty + 18 * Printing.fontHeight + yoffset);

            #endregion
        }

        #endregion

        #region extras
              
        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (mt.active) drawMonthly(e.Graphics);
            if (ad.active) drawAdmission(e.Graphics);
            if (an.active) drawAnnual(e.Graphics);
            if (pa.active) drawProvAdmission(e.Graphics);
        }
           
        private void ReceiptForm_Load(object sender, EventArgs e)
        {
            Graphics gr = receiptDisplay.CreateGraphics();
            gr.Clear(Color.White);

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(fillReceipt);
            timer.Start();

            gr.Clear(Color.White);
        }

        public void fillReceipt(object sender, EventArgs e)
        {
            timer.Stop();
            Graphics gr = receiptDisplay.CreateGraphics();
            gr.Clear(Color.White);
            if (mt.active) drawMonthly(receiptDisplay.CreateGraphics());
            if (ad.active) drawAdmission(receiptDisplay.CreateGraphics());
            if (an.active) drawAnnual(receiptDisplay.CreateGraphics());
            if (pa.active) drawProvAdmission(receiptDisplay.CreateGraphics());
            timer.Start();
        }

        private void print_Click(object sender, EventArgs e)
        {
            if (mt.active) PrintMonthlyReceipt();
            if (ad.active) PrintAdmissionReceipt();
            if (an.active) PrintAnnualReceipt();
            if (pa.active) PrintProvAdmissionReceipt();
        }

        #endregion

        private void delete_Click(object sender, EventArgs e)
        {
            #region Delete Monthly
            if (mt.active)
            {
                using (SqlConnection myConnection = new SqlConnection(GlobalVariables.dbConnectString))
                {
                    try
                    {
                        myConnection.Open();

                        String deleteMonthlyQuery = "update " + Table.student_monthly_fees.tableName + " set " +
                            Table.student_monthly_fees.receipt_id + " = null, " +
                            Table.student_monthly_fees.date + " = null " + " where " +
                            Table.student_monthly_fees.receipt_id + " = '" + receiptID.Text + "';";
                        using (SqlCommand myCommand = new SqlCommand(deleteMonthlyQuery, myConnection))
                        {
                            myCommand.ExecuteNonQuery();
                            //MessageBox.Show(deleteMonthlyQuery);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                mt = new MonthlyDetails();
                receiptID.Text = "";
                Graphics gr = receiptDisplay.CreateGraphics();
                gr.Clear(Color.White);
            }
            #endregion

            #region Delete Annual
            if (an.active)
            {
                using (SqlConnection myConnection = new SqlConnection(GlobalVariables.dbConnectString))
                {
                    try
                    {
                        myConnection.Open();

                        String deleteAnnualQuery = "update " + Table.student_annual_fees.tableName + " set " +
                            Table.student_annual_fees.receipt_id + " = null, " +
                            Table.student_annual_fees.date + " = null " + " where " +
                            Table.student_annual_fees.receipt_id + " = '" + receiptID.Text + "';";
                        using (SqlCommand myCommand = new SqlCommand(deleteAnnualQuery, myConnection))
                        {
                            myCommand.ExecuteNonQuery();
                            //MessageBox.Show(deleteMonthlyQuery);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                an = new AnnualDetails();
                receiptID.Text = "";
                Graphics gr = receiptDisplay.CreateGraphics();
                gr.Clear(Color.White);
            }
            #endregion
        }
    }

    public class MonthlyDetails
    {
        public Boolean active;
        public int[] fees;
        public String studentID, date, name, fName, theClass, section;
        public String fMonth, tMonth;
        public int session;
        public Boolean deletable;

        public MonthlyDetails()
        {
            active = false;
            deletable = false;
            fees = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            studentID = date = name = fName = theClass = section = "";
            fMonth = tMonth = "";
            session = GlobalVariables.currentSession;
        }

    }

    public class AdmissionDetails
    {
        public Boolean active;
        public String studentID, date, name, fName, theClass;
        public int[] fees;
        public String section;
        public int session;

        public AdmissionDetails()
        {
            active = false;
            studentID = date = name = fName = theClass = "";
            section = "";
            fees = new int[6] { 0, 0, 0, 0, 0, 0 };
            session = GlobalVariables.currentSession;
        }

    }

    public class ProvAdmissionDetails
    {
        public Boolean active;
        public String studentID, date, name, fName, theClass;
        public int[] fees;
        public String section;
        public int session;

        public ProvAdmissionDetails()
        {
            active = false;
            studentID = date = name = fName = theClass = "";
            section = "";
            fees = new int[6] { 0, 0, 0, 0, 0, 0 };
            session = GlobalVariables.currentSession;
        }

    }

    public class AnnualDetails
    {
        public Boolean active;
        public String studentID, date, name, fName, theClass;
        public String section;
        public int[] fees;
        public int session;
        public Boolean deletable;

        public AnnualDetails()
        {
            active = deletable = false;
            studentID = date = name = fName = theClass = "";
            section = "";
            fees = new int[3] { 0, 0, 0 };
            session = GlobalVariables.currentSession;
        }

    }

}
