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
    public partial class MonthlyFeesForm : Form
    {
        private Boolean allowIDChange, allowCellChange;

        private Boolean studentExists, feeStructExists, allowChequeChange;

        private String receiptID;

        Boolean exStudent = false;

        private String fromMonth, toMonth;
        private String section;


        private int[] feesToPrint;
        private int[] baseFeesTotal;
        private String[] classes;
        private Boolean[] conc;
        private int[,] originalFees;
        private int[] sessions;

        public MonthlyFeesForm()
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
            receiptID = "";
            fromMonth = toMonth = "";
            section = "";
            studentExists = false;
            feeStructExists = false;
            print.Enabled = false;
            allowChequeChange = true;
            cheque.ReadOnly = true;
            originalFees = new int[12, 9];
            conc = new Boolean[12] {false, false, false, false, false, false,
                                    false, false, false, false, false, false };
            feesStructure.Rows.Clear();
            for (int i = 0; i < 12; i++)
            {
                feesStructure.Rows.Add(false, GlobalVariables.months[i], "", "", "", "", "", "", "", "", "", "", "", "");
                feesStructure.Rows[i].DefaultCellStyle.BackColor = SystemColors.ControlLightLight;

            }
            totalPayment.Text = "";
            mainFeesTotal.Text = "";
            lateFeesTotal.Text = "";
            studentName.Text = "";
            studentClass.Text = "";
            studentSection.Text = "";
            studentSession.Text = "";
            feesStructure.Enabled = false;
            baseFeesTotal = new int[12];
            classes = new String[12];
            feesToPrint = new int[9];
        }

        private void studentID_TextChanged(object sender, EventArgs e)
        {
            if (!allowIDChange) return;
            allowIDChange = false;
            allowCellChange = false;

            Boolean prePay = false;
            Boolean disableMarch = false;
            exStudent = false;
            sessions = new int[12];

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

                        #region Student Details

                        // Getting Student details
                        String studentQuery = "Select * from " + Table.student_details.tableName + " where " +
                                                Table.student_details.student_id + " = '" + studentID.Text + "'";

                        using (SqlCommand command = new SqlCommand(studentQuery, connection))
                        {
                            SqlDataReader dr = command.ExecuteReader();
                            if (dr.Read())
                            {
                                studentExists = true;
                                String middleName = dr[Table.student_details.middle_name].ToString();

                                section = dr[Table.student_details.section].ToString();

                                if (middleName == null || middleName.Length == 0) middleName = "";
                                else middleName += " ";
                                studentName.Text = dr[Table.student_details.first_name].ToString() + " " + middleName + dr[Table.student_details.last_name].ToString();
                                studentClass.Text = Classes.getClassBranch(dr[Table.student_details.class_n].ToString());
                                studentSection.Text = dr[Table.student_details.section].ToString();

                                if (dr[Table.student_details.student_category].ToString() == GlobalVariables.exStud)
                                {
                                    allowIDChange = true;
                                    allowCellChange = true;
                                    MessageBox.Show("The student is an Ex-Student");
                                    return;

                                }

                                if (dr[Table.student_details.current_session].ToString().Length == 0)
                                {
                                    //#TODO Make it DialogBox
                                    MessageBox.Show("Student admitted to next session. Pay fees early?");
                                    prePay = true;
                                    //allowIDChange = true;
                                    //return;
                                }
                                if (!prePay)
                                    studentSession.Text = dr[Table.student_details.current_session].ToString() + " - " +
                                                         (Convert.ToInt32(dr[Table.student_details.current_session]) + 1);
                                else
                                    studentSession.Text = dr[Table.student_details.admission_session].ToString() + " - " +
                                                         (Convert.ToInt32(dr[Table.student_details.admission_session]) + 1);


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
                        #endregion

                        #region Annual Fees Check
                        String annualQuery = "Select top 1 * from " + Table.student_annual_fees.tableName + " where " +
                            Table.student_annual_fees.student_id + " = '" + studentID.Text +
                            "' order by " + Table.student_annual_fees.session + " desc;";
                        try
                        {
                            using (SqlCommand command = new SqlCommand(annualQuery, connection))
                            {
                                SqlDataReader dr = command.ExecuteReader();
                                if (dr.Read())
                                {
                                    if (dr[Table.student_annual_fees.receipt_id] == null ||
                                        dr[Table.student_annual_fees.receipt_id].ToString().Equals(""))
                                        disableMarch = true;
                                    dr.Close();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error");
                        }
                        finally
                        {

                        }
                        #endregion

                        #region Student Fees Structure
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
                                originalFees[mt, 8] = Convert.ToInt32(dr[Table.student_monthly_fees.late_fees]);
                                sessions[mt] = Convert.ToInt32(dr[Table.student_monthly_fees.session]);
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
                                cheque.ReadOnly = false;
                            }
                            dr.Close();
                        }
                        if (disableMarch && (Boolean)feesStructure.Rows[11].Cells[0].Value == false)
                        {
                            feesStructure.Rows[11].Cells[0].Value = false;
                            feesStructure.Rows[11].ReadOnly = true;
                            feesStructure.Rows[11].DefaultCellStyle.BackColor = SystemColors.GrayText;//SystemColors.ControlLight;
                            MessageBox.Show("Annual Fees not paid", "Cannot pay March Fees");
                        }
                        #endregion

                        #region Base Fees

                        String baseFeesQuery = "";

                        /*  
                            "Select top 1 * from " + Table.monthly_base_struct.tableName + " where " +
                            Table.monthly_base_struct.session + " = " + GlobalVariables.currentSession + " and " +
                            Table.monthly_base_struct.clss + " = '" + classes[0] + "' and " +
                            Table.monthly_base_struct.mnth + " = '" + GlobalVariables.db_months[0] + "';";
                        */

                        using (SqlCommand command = new SqlCommand(baseFeesQuery, connection))
                        {
                            for (int i = 0; i < 12; i++)
                            {
                                baseFeesQuery = "Select top 1 * from " + Table.monthly_base_struct.tableName + " where " +
                                                Table.monthly_base_struct.session + " = " + sessions[i] + " and " +
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

                        #endregion

                        calculateTotal();
                        feesStructure.Enabled = true;
                        if (!feeStructExists)
                        {
                            // #TODO
                            MessageBox.Show("Fees structure missing, contact admin", "Error");
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
            int lateFeesTotalAmount = 0;    //Because we already have the name lateFeesTotal
            for (int i = 0; i < 12; i++)
            {
                int total = 0;
                for (int j = 0; j < 9; j++)
                {
                    if (feesStructure[j + 2, i].Value == null) feesStructure[j + 2, i].Value = 0;
                    int v = CommonMethods.amountToInt(feesStructure[j + 2, i].Value.ToString());
                    if (v > originalFees[i, j])
                    {
                        v = originalFees[i, j];
                    }
                    feesStructure[j + 2, i].Value = CommonMethods.formatAmount("" + v);
                    total += v;
                    if (j == 7)
                    {
                        if (total != baseFeesTotal[i])
                            conc[i] = true;
                        else
                            conc[i] = false;
                    }
                }
                feesStructure[11, i].Value = CommonMethods.formatAmount("" + total);
                if (feesStructure[0, i].Value.Equals(true) && feesStructure.Rows[i].ReadOnly == false)
                {
                    grandTotal += total;
                    lateFeesTotalAmount += CommonMethods.amountToInt(feesStructure[10, i].Value.ToString());
                }
            }

            totalPayment.Text = CommonMethods.formatAmount("" + grandTotal);
            lateFeesTotal.Text = CommonMethods.formatAmount("" + lateFeesTotalAmount);
            mainFeesTotal.Text = CommonMethods.formatAmount("" + (grandTotal - lateFeesTotalAmount));
        }

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

            int st = -1, ed = -1;
            for (int i = 0; i < 12; i++)
            {
                if (feesStructure[0, i].Value.Equals(true) && feesStructure.Rows[i].ReadOnly != true)
                {
                    if (st == -1) st = i;
                    ed = i;
                }
            }
            if (st == -1 || ed == -1)
            {
                toMonth = fromMonth = "";
            }
            else
            {
                fromMonth = GlobalVariables.db_months[st];
                toMonth = GlobalVariables.db_months[ed];
            }

            feesToPrint = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < 12; i++)
            {
                if (feesStructure[0, i].Value.Equals(true) &&
                    feesStructure.Rows[i].ReadOnly != true)
                    for (int j = 0; j < 9; j++)
                    {
                        feesToPrint[j] += CommonMethods.amountToInt("" + feesStructure[j + 2, i].Value);
                    }
            }
        }

        private String getNSetMonthlyReceiptID()
        {
            String getQuery = "select " + Table.session_info.monthly_rec_start + " from " +
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
                            recID = dr[Table.session_info.monthly_rec_start].ToString();
                        }

                        dr.Close();
                    }

                    //#TODO Check Limit
                    int x = Int32.Parse(recID.Substring(2)) + 1;

                    String setQuery = "update " + Table.session_info.tableName + " set " +
                        Table.session_info.monthly_rec_start + "='" + recID.Substring(0, 2) + x + "' where " +
                        Table.session_info.active_session + " = 1;";
                    using (SqlCommand myCommand = new SqlCommand(setQuery, myConnection))
                    {

                        myCommand.ExecuteNonQuery();
                    }

                }
                catch
                {
                    MessageBox.Show("Unable to generate receipt number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
                finally
                {
                    myConnection.Close();
                }
            }

            return recID;

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

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphic = e.Graphics;

            String date = dateTimePicker.Value.ToString("dd-MM-yyyy"); ;//"1-2-2016";
            String stID = studentID.Text;
            String stName = studentName.Text;
            String stClass = studentClass.Text;

            if (stName.Length > 25)
                stName = stName.Substring(0, 25) + ".";
            int startx = 10;
            int starty = 10;
            int yoffset = 30;
            int rectHeight = (Int32)(Printing.fontHeight * 12);

            graphic.DrawString("JOHNSON ENGLISH MEDIUM H.S. SCHOOL", Printing.heading, Printing.brush, startx + 5, starty);
            graphic.DrawString("NARMADA ROAD, JABALPUR-482001", Printing.subhead, Printing.brush, startx + 40 + 10, starty + 1 * Printing.fontHeight);
            graphic.DrawString("Ph: 0761-4034114", Printing.subhead, Printing.brush, startx + 85 + 20, starty + 2 * Printing.fontHeight);
            graphic.DrawString("-----------------------------------", Printing.heading, Printing.brush, startx, starty + 3 * Printing.fontHeight - 5);
            graphic.DrawString("MONTHLY FEES RECEIPT", Printing.subhead, Printing.brush, startx + 70 + 15, starty + 4 * Printing.fontHeight - 5);

            graphic.DrawString("Student ID:" + stID, Printing.other, Printing.brush, startx + 5, starty + 5 * Printing.fontHeight);
            graphic.DrawString("Receipt No:" + receiptID, Printing.other, Printing.brush, startx + 155 + 20, starty + 5 * Printing.fontHeight);
            graphic.DrawString("Date: " + date, Printing.other, Printing.brush, startx + 5, starty + 6 * Printing.fontHeight);
            graphic.DrawString("Student Name: " + stName, Printing.other, Printing.brush, startx + 5, starty + 7 * Printing.fontHeight);

            graphic.DrawString("Class: " + stClass, Printing.other, Printing.brush, startx + 5, starty + 8 * Printing.fontHeight);
            graphic.DrawString("Section: " + section, Printing.other, Printing.brush, startx + 210 + 50, starty + 8 * Printing.fontHeight);

            if (fromMonth == toMonth)
                graphic.DrawString("Fee for month: " + fromMonth, Printing.other, Printing.brush, startx + 5, starty + 9 * Printing.fontHeight);
            else
                graphic.DrawString("Fee Duration: " + fromMonth + " - " + toMonth, Printing.other, Printing.brush, startx + 5, starty + 9 * Printing.fontHeight);

            graphic.DrawString("Session: " + studentSession.Text, Printing.other, Printing.brush, startx + 5, starty + 10 * Printing.fontHeight);
            yoffset += (Int32)Printing.fontHeight;
            yoffset += 10;
            graphic.DrawString("Details ", Printing.subhead, Printing.brush, startx + 120 + 30, starty + 8 * Printing.fontHeight + yoffset - 5);

            //graphic.FillRectangle(Printing.fillBrush, startx + 5, starty + 9 * Printing.fontHeight + yoffset, 300 - 30 + 70, Printing.fontHeight + 2);
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
                graphic.DrawString(CommonMethods.formatAmount("" + feesToPrint[i]), Printing.other, Printing.brush, startx + 220 + 50 - ((feesToPrint[i].ToString().Length - 1) * Printing.fontWidth) + 30, starty + (10 + i) * Printing.fontHeight + 5 + yoffset);
                total += feesToPrint[i];
            }
            graphic.DrawString(CommonMethods.formatAmount("" + total), Printing.bold, Printing.brush, startx + 215 + 50 - ((total.ToString().Length + 1) * Printing.boldFontWidth) + 55, starty + 19 * Printing.fontHeight + 10 + yoffset + 1);

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

            graphic.DrawString("Seal: ", Printing.other, Printing.brush, startx + 5, starty + 25 * Printing.fontHeight + yoffset);
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void print_Click(object sender, EventArgs e)
        {
            try
            {
                if (Int32.Parse(studentSession.Text.Substring(0, 4)) < 2000 ||
                    Int32.Parse(studentSession.Text.Substring(0, 4)) >= 2050)
                    throw new Exception();                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem with student session", "Error");
                return;
            }
            receiptID = getNSetMonthlyReceiptID();
            if (receiptID.Equals("") || receiptID == "") return;

            String todayString = dateTimePicker.Value.ToString(GlobalVariables.dateFormat);
            if (cheque.TextLength == 0) cheque.Text = "0";
            using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    connection.Open();
                    String updateQuery = "";
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {

                        for (int i = 0; i < 12; i++)
                        {
                            if (feesStructure[0, i].Value.Equals(true) && !feesStructure.Rows[i].ReadOnly)
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
                                Table.student_monthly_fees.late_fees + " = " +
                                CommonMethods.amountToInt(feesStructure[10, i].Value.ToString()) + ", " +
                                Table.student_monthly_fees.receipt_id + " = '" + receiptID + "', " +
                                Table.student_monthly_fees.date + " = '" + todayString + "', " +
                                Table.student_monthly_fees.terminal + " = " + GlobalVariables.thisTerminal + ", " +
                                Table.student_monthly_fees.concession + " = " + ((conc[i]) ? ("1") : ("0")) + ", " +
                                Table.student_monthly_fees.cheque + " = " + cheque.Text + " where " +
                                Table.student_monthly_fees.month + " = '" + GlobalVariables.db_months[i] + "' and " +
                                Table.student_monthly_fees.student_id + " = '" + studentID.Text + "' and " +
                                Table.student_monthly_fees.session + " = '" + studentSession.Text.Substring(0, 4) + "';";
                                cheque.Text = "0";
                            }

                        }
                        //Debugger.Message(updateQuery);

                        command.CommandText = updateQuery;
                        command.ExecuteNonQuery();

                    }
                    PrintMonthlyReceipt();

                    List<String> vals = Program.mForm.receiptBox.Items.Cast<String>().ToList();
                    vals.Reverse();
                    vals.Add(receiptID + " " + DateTime.Now.ToShortTimeString());
                    vals.Reverse();
                    Program.mForm.receiptBox.Items.Clear();
                    foreach (String id in vals)
                        Program.mForm.receiptBox.Items.Add(id);
                    Program.mForm.receiptBox.SelectedIndex = 0;
                }
                catch
                {
                }
            }
            studentID.Text = "";
            this.ActiveControl = studentID;
        }

        private void MonthlyFeesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.mtForm = null;
        }

    }
}
