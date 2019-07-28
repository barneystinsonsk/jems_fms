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

/*              READ ME
 * Minimum protection against cascading failure: When confirmed, multiple tables have to be updated, if one fails
 *          Printing.other are still updated leading to inconsistency. This problem if faced ignore for now, it will be 
 *          solved later.
 * 
 * Fees can be increased and still counts as concession. This will be resolved after consultation of the user.
 * 
 * Many small performance improvements still have to be done.
 * 
 * Gender: 1 will represent Male and 0 Female, in database TRUE is male and FALSE Female
 * 
 * Age : between 25 and 99 cannot get admission
 * 
 * Leave and enter events are for hint control, forget them
 * 
 */


namespace JEMS_Fees_Management_System
{
    public partial class RegularAdmissionForm : Form
    {



        Boolean forceClose;         // if active does not shows closing dialog (during fatal error)

        Boolean firstNameChange, middleNameChange, lastNameChange,      //  Allows formating of respective fields
            fatherNameChange, motherNameChange, guardianNameChange;     //

        Boolean feesCalActive;      // Allows fees calcuation
        Boolean feesExceeds;
        Boolean conc;
        String dateString;

        Boolean allowChange;
        String receiptID;

        int[] orgFees;              //To compare with modified fees

        public RegularAdmissionForm()
        {
            forceClose = false;

            firstNameChange = middleNameChange = lastNameChange =
                fatherNameChange = motherNameChange = guardianNameChange = false;

            feesCalActive = false;

            feesExceeds = conc = false;
            InitializeComponent();

            orgFees = new int[6];

            dateString = "";

            category.DataSource = GlobalVariables.categoryCastNames;       //Cast/Category names

            firstNameChange = middleNameChange = lastNameChange =
                fatherNameChange = motherNameChange = guardianNameChange = true;
            allowChange = true;
        }

        private void RegularAdmissionForm_Load(object sender, EventArgs e)
        {
            panel1Setup();
            panel2Setup();

        }

        private void panel1Setup()
        {
            getStudentID();
            setGaurdian();
            leaveEvents();
            panel1Next.Enabled = false;

        }

        private void panel2Setup()
        {
            section.SelectedIndex = 0;
            currentSession.Checked = true;
            belt_tieCheckbox.Checked = true;
            feesCalActive = false;
            currentSession.Text = "Current (" + GlobalVariables.currentSession + ")";
            nextSession.Text = "Next (" + (GlobalVariables.currentSession + 1) + ")";
            class_n.DataSource = Classes.classBranchNameArray;
            class_n_SelectionChangeCommitted(null, null);
            feesCalActive = true;
        }

        private void leaveEvents()      //To activate leave event
        {
            firstName_Leave(null, null);        //
            middleName_Leave(null, null);       // Leave events add hints to fields
            lastName_Leave(null, null);         //
            fatherName_Leave(null, null);       //
            motherName_Leave(null, null);       //
            guardianName_Leave(null, null);     //
        }

        private void getStudentID()
        {
            String query = "select " + Table.session_info.st_id_start + " from " + Table.session_info.tableName + " where " +
                            Table.session_info.active_session + " = 1;";

            SqlDataReader dr;
            using (SqlConnection myConnection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    myConnection.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                    {
                        dr = myCommand.ExecuteReader();
                        //#TODO check for multiple active sessions

                        if (dr.Read())
                        {
                            String newID = dr[Table.session_info.st_id_start].ToString();
                            if (newID != null && CommonMethods.studentIDSTCheck(newID))
                            {
                                studentID.Text = newID;
                            }
                            else
                            {
                                // #TODO
                            }
                        }

                        dr.Close();
                    }
                }
                catch
                {

                }
                finally
                {
                    myConnection.Close();
                }
            }

        }

        private void setGaurdian()
        {
            guardianName.Enabled = gAddress.Enabled = //gLocality.Enabled = gWard.Enabled = 
                gCity.Enabled = gState.Enabled = gPincode.Enabled =
                gMobile.Enabled = gPhone.Enabled = guardian.Checked;
        }

        void PrintAdmissionReceipt()
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.DefaultPageSettings.PaperSize = Printing.admissionReceipt;
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
            String stName = middleName.Text;
            String fName = fatherName.Text;
            if (stName.Length == 0) stName = firstName.Text + " " + lastName.Text;
            else stName = firstName.Text + " " + stName + " " + lastName.Text;

            String stClass = class_n.Text;
            String studentSession = (currentSession.Checked ? ("" + GlobalVariables.currentSession + " - " +
                (GlobalVariables.currentSession + 1)) :
                ("" + (GlobalVariables.currentSession + 1) + " - " +
                (GlobalVariables.currentSession + 2)));

            if (stName.Length > 25)
                stName = stName.Substring(0, 25) + ".";
            if (fName.Length > 23)
                fName = fName.Substring(0, 23) + ".";

            int startx = 10;
            int starty = 10;
            int yoffset = 30;
            int rectHeight = (Int32)Printing.fontHeight * 9;

            graphic.DrawString("JOHNSON ENGLISH MEDIUM H.S. SCHOOL", Printing.heading, Printing.brush, startx + 5, starty);
            graphic.DrawString("NARMADA ROAD, JABALPUR-482001", Printing.subhead, Printing.brush, startx + 40 + 10, starty + 1 * Printing.fontHeight);
            graphic.DrawString("Ph: 0761-4034114", Printing.subhead, Printing.brush, startx + 85 + 15, starty + 2 * Printing.fontHeight);
            graphic.DrawString("-----------------------------------", Printing.heading, Printing.brush, startx, starty + 3 * Printing.fontHeight - 5);
            graphic.DrawString("ADMISSION RECEIPT", Printing.boldSubHead, Printing.brush, startx + 80 + 20, starty + 4 * Printing.fontHeight - 5);

            graphic.DrawString("Student ID: " + stID, Printing.other, Printing.brush, startx + 5, starty + 5 * Printing.fontHeight);
            graphic.DrawString("Receipt No: " + receiptID, Printing.other, Printing.brush, startx + 155 + 25, starty + 5 * Printing.fontHeight);
            graphic.DrawString("Date: " + date, Printing.other, Printing.brush, startx + 5, starty + 6 * Printing.fontHeight);
            graphic.DrawString("Student Name: " + stName.ToUpper(), Printing.other, Printing.brush, startx + 5, starty + 7 * Printing.fontHeight);
            starty += (int)Printing.fontHeight;

            graphic.DrawString("Father's Name: " + fName.ToUpper(), Printing.other, Printing.brush, startx + 5, starty + 7 * Printing.fontHeight);

            graphic.DrawString("Class: " + stClass, Printing.other, Printing.brush, startx + 5, starty + 8 * Printing.fontHeight);
            graphic.DrawString("Section: " + section.Text, Printing.other, Printing.brush, startx + 210 + 50, starty + 8 * Printing.fontHeight);

            graphic.DrawString("Session: " + studentSession, Printing.other, Printing.brush, startx + 5, starty + 9 * Printing.fontHeight);
            yoffset += 10;
            graphic.DrawString("Details ", Printing.subhead, Printing.brush, startx + 120, starty + 8 * Printing.fontHeight + yoffset - 5);


            //graphic.FillRectangle(Printing.fillBrush, startx + 5, starty + 9 * Printing.fontHeight + yoffset, 300 - 30 + 70, Printing.fontHeight + 2);
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
                graphic.DrawString(CommonMethods.formatAmount("" + admissionFeesStruct[i, 0].Value), Printing.other, Printing.brush, startx + 220 + 60 - ((admissionFeesStruct[i, 0].Value.ToString().Length - 1) * Printing.fontWidth) + 45, starty + (7 + i) * Printing.fontHeight + 5 + yoffset);
                total += CommonMethods.amountToInt("" + admissionFeesStruct[i, 0].Value);
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
            if (CommonMethods.amountToInt("" + admissionFeesStruct[4, 0].Value) != 0)
            {
                graphic.DrawString("NOTE: PLEASE PRESERVE THIS RECEIPT TO", Printing.bold, Printing.brush, startx + 5, starty + 20 * Printing.fontHeight + yoffset); 
                graphic.DrawString("      CLAIM CAUTION MONEY", Printing.bold, Printing.brush, startx + 5, starty + 21 * Printing.fontHeight + yoffset);
            }
        }
                
        private void panel1Next_Click(object sender, EventArgs e)
        {
            panel0.Visible = false;
            panel1.Visible = true;
        }

        private void panel1Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2Prev_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel0.Visible = true;
        }

        private void panel2Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegularAdmissionForm_FormClosing(object sender, FormClosingEventArgs e)    //Throws dialog on during closing
        {
            if (!forceClose)
            {
                DialogResult cancelAdmission = MessageBox.Show("Are you sure you want to cancel Admission?", "Cancel Admission", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (cancelAdmission == System.Windows.Forms.DialogResult.No) e.Cancel = true;
                else e.Cancel = false;
            }
            else
                e.Cancel = false;
        }

        private void RegularAdmissionFormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.rAForm = null;
        }

        private void dobDate_TextChanged(object sender, EventArgs e)
        {
            calculateAge();
            checkAll1();
        }

        private void dobMonth_TextChanged(object sender, EventArgs e)
        {
            calculateAge();
            checkAll1();
        }

        private void dobYear_TextChanged(object sender, EventArgs e)
        {
            calculateAge();
            checkAll1();
        }

        private void calculateAge() //Also checks and corrects input
        {

            dateString = "";

            int maxDays = 31;
            Boolean all = true;
            int y = -1;
            int m = 0, d = 0;

            //year
            if (dobYear.Text.Length != 0 && CommonMethods.valueBetween(dobYear.Text, 0, 99))
            {
                y = Int32.Parse(dobYear.Text);
            }
            else
            {
                dobYear.Text = "";
                all = false;
            }

            //month
            if (dobMonth.Text.Length != 0 && CommonMethods.valueBetween(dobMonth.Text, 1, 12))
            {
                m = Int32.Parse(dobMonth.Text);
                if (m < 8)
                {
                    if (m % 2 == 0)
                    {
                        maxDays = 30;
                    }
                    else maxDays = 31;
                }
                else
                {
                    if (m % 2 == 0)
                    {
                        maxDays = 31;
                    }
                    else maxDays = 30;
                }
                if (m == 2)
                    if (y % 4 == 0 || y == -1) maxDays = 29;
                    else maxDays = 28;


            }
            else
            {
                dobMonth.Text = "";
                maxDays = 31;
                all = false;
            }
            
            //date
            if (dobDate.Text.Length != 0 && CommonMethods.valueBetween(dobDate.Text, 1, 31))
            {
                d = Int32.Parse(dobDate.Text);
                if (d > maxDays)
                {
                    dobDate.Text = "" + maxDays;
                    d = maxDays;
                }

            }
            else
            {
                dobDate.Text = "";
                all = false;
            }

            //Actual age calculation
            if (all)
            {
                int calAge = 0;
                if (y > 50)        //#TODO
                {
                    calAge = DateTime.Now.Year - 1900 - y;
                    dateString = "19" + y + "-";

                }
                else if (y < 50)
                {
                    calAge = DateTime.Now.Year - 2000 - y;
                    if (y >= 10)
                        dateString = "20" + y + "-";
                    else
                        dateString = "200" + y + "-";
                }

                if (m > 9) calAge--; //Age before September 30th's end


                if (calAge < 0)
                {
                    MessageBox.Show("Invalid");
                    dobYear.Text = "";
                    return;
                }

                //making dateString
                if (m >= 10)
                    dateString += m + "-";
                else
                    dateString += "0" + m + "-";

                if (d >= 10)
                    dateString += d;
                else
                    dateString += "0" + d;

                age.Text = "" + calAge;
            }
            else
                age.Text = "";
            
        }

        private void guardian_CheckedChanged(object sender, EventArgs e)
        {
            setGaurdian();
        }

        private void firstName_Leave(object sender, EventArgs e)
        {
            if (firstNameChange)
            {
                firstNameChange = false;
                firstName.Text = CommonMethods.nameFormat(firstName.Text);
                if (firstName.Text.Length == 0)
                {
                    firstName.Text = "First Name";
                    firstName.ForeColor = SystemColors.GrayText;
                }
                firstNameChange = true;
            }
            checkAll1();

        }

        private void firstName_Enter(object sender, EventArgs e)
        {
            if (firstName.Text == "First Name")
            {
                firstName.Text = "";
                firstName.ForeColor = SystemColors.WindowText;
            }
        }

        private void middleName_Leave(object sender, EventArgs e)
        {
            if (middleNameChange)
            {
                middleNameChange = false;
                middleName.Text = CommonMethods.nameFormat(middleName.Text);
                if (middleName.Text.Length == 0)
                {
                    middleName.Text = "Middle Name";
                    middleName.ForeColor = SystemColors.GrayText;
                }
                checkAll1();
                middleNameChange = true;
            }
        }

        private void middleName_Enter(object sender, EventArgs e)
        {
            if (middleName.Text == "Middle Name")
            {
                middleName.Text = "";
                middleName.ForeColor = SystemColors.WindowText;
            }
        }

        private void lastName_Leave(object sender, EventArgs e)
        {
            if (lastNameChange)
            {
                lastNameChange = false;
                lastName.Text = CommonMethods.nameFormat(lastName.Text);
                if (lastName.Text.Length == 0)
                {
                    lastName.Text = "Last Name";
                    lastName.ForeColor = SystemColors.GrayText;
                }
                checkAll1();
                lastNameChange = true;
            }

        }

        private void lastName_Enter(object sender, EventArgs e)
        {
            if (lastName.Text == "Last Name")
            {
                lastName.Text = "";
                lastName.ForeColor = SystemColors.WindowText;
            }
        }

        private void fatherName_Leave(object sender, EventArgs e)
        {
            if (fatherNameChange)
            {
                fatherNameChange = false;
                fatherName.Text = CommonMethods.nameFormat(fatherName.Text);
                if (fatherName.Text.Length == 0)
                {
                    fatherName.Text = "Full Name";
                    fatherName.ForeColor = SystemColors.GrayText;
                }
                checkAll1();
                fatherNameChange = true;
            }

        }

        private void fatherName_Enter(object sender, EventArgs e)
        {
            if (fatherName.Text == "Full Name")
            {
                fatherName.Text = "";
                fatherName.ForeColor = SystemColors.WindowText;
            }

        }

        private void motherName_Leave(object sender, EventArgs e)
        {
            if (motherNameChange)
            {
                motherNameChange = false;
                motherName.Text = CommonMethods.nameFormat(motherName.Text);
                if (motherName.Text.Length == 0)
                {
                    motherName.Text = "Full Name";
                    motherName.ForeColor = SystemColors.GrayText;
                }
                checkAll1();
                motherNameChange = true;
            }

        }

        private void motherName_Enter(object sender, EventArgs e)
        {
            if (motherName.Text == "Full Name")
            {
                motherName.Text = "";
                motherName.ForeColor = SystemColors.WindowText;
            }
        }

        private void guardianName_Leave(object sender, EventArgs e)
        {
            if (guardianNameChange)
            {
                guardianNameChange = false;
                guardianName.Text = CommonMethods.nameFormat(guardianName.Text);
                if (guardianName.Text.Length == 0)
                {
                    guardianName.Text = "Full Name";
                    guardianName.ForeColor = SystemColors.GrayText;
                }
                checkAll1();
                guardianNameChange = true;
            }

        }

        private void guardianName_Enter(object sender, EventArgs e)
        {
            if (guardianName.Text == "Full Name")
            {
                guardianName.Text = "";
                guardianName.ForeColor = SystemColors.WindowText;
            }
        }

        private void checkAll1()      //  Checks for valid necessary entries for next panel activation
        {
            panel1Next.Enabled = true;
            if (firstName.Text.Length <= 2 || middleName.Text.Length + lastName.Text.Length <= 2)
                panel1Next.Enabled = false;
            if (firstName.Text.Equals("First Name") || (middleName.Text.Equals("Middle Name") && lastName.Text.Equals("Last Name")))
                panel1Next.Enabled = false;
            if (gender.SelectedIndex != 0 && gender.SelectedIndex != 1)
                panel1Next.Enabled = false;
            if (age.Text == null || age.Text.Length == 0 || CommonMethods.valueBetween(age.Text, 0, 1) ||
                CommonMethods.valueBetween(age.Text, 25, 99))
                panel1Next.Enabled = false;
        }

        private void gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkAll1();
        }

        private void class_n_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int selected = class_n.SelectedIndex;

            String query = "select * from " + Table.admission_base_struct.tableName + " where " +
                            Table.admission_base_struct.session + " = " + GlobalVariables.currentSession + " and " +
                            Table.admission_base_struct.clss + " = '" + Classes.classArray[selected] + "';";

            SqlDataReader dr;
            using (SqlConnection myConnection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    myConnection.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                    {
                        dr = myCommand.ExecuteReader();
                        //#TODO check for multiple active sessions
                        if (dr.Read())
                        {
                            feesCalActive = false;

                            orgFees[0] = Convert.ToInt32(dr[Table.admission_base_struct.ad_fees]);
                            orgFees[1] = Convert.ToInt32(dr[Table.admission_base_struct.school_dev]);
                            orgFees[2] = Convert.ToInt32(dr[Table.admission_base_struct.furn_fund]);
                            orgFees[3] = Convert.ToInt32(dr[Table.admission_base_struct.lab_dev]);
                            orgFees[4] = Convert.ToInt32(dr[Table.admission_base_struct.caution]);
                            orgFees[5] = Convert.ToInt32(dr[Table.admission_base_struct.belt_tie]);

                            admissionFeesStruct.Rows.Clear();
                            admissionFeesStruct.Rows.Add(orgFees[0], orgFees[1], orgFees[2], orgFees[3],
                                orgFees[4], orgFees[5], 0);
                            
                            feesCalActive = true;
                            calculateTotal();
                        }

                        dr.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    myConnection.Close();
                }
            }

        }

        private void admissionFeesStruct_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            calculateTotal();
        }

        private void calculateTotal()
        {
            if (!feesCalActive) return;
            feesExceeds = false;
            feesCalActive = false;

            int total = 0, orgTotal = 0;
            for (int i = 0; i < 6; i++)
            {
                if (admissionFeesStruct[i, 0].Value == null) admissionFeesStruct[i, 0].Value = 0;
                if ((i == 5 && belt_tieCheckbox.Checked) || i != 5)
                {
                    total += CommonMethods.amountToInt(admissionFeesStruct[i, 0].Value.ToString());
                    orgTotal += orgFees[i];
                }
                admissionFeesStruct[i, 0].Value = CommonMethods.formatAmount((admissionFeesStruct[i, 0].Value.ToString()));
            }
            if (orgTotal != total)
            {
                if (total > orgTotal)
                    feesExceeds = true;
                conc = true;
            }
            else
            {
                conc = false;
            }
            admissionFeesStruct[6, 0].Value = CommonMethods.formatAmount("" + total);
            feesCalActive = true;
        }

        private void belt_tieCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            calculateTotal();
        }
        /*
                private void panel2Confirm_Click(object sender, EventArgs e)
                {
                    MessageBox.Show("" + hNO.TextLength);
                }  
         */

        private String getNSetAdmissionReceiptID()
        {
            String getQuery = "select " + Table.session_info.admission_rec_start + " from " +
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
                            recID = dr[Table.session_info.admission_rec_start].ToString();

                        }

                        dr.Close();
                    }

                    //#TODO Check Limit
                    int x = Int32.Parse(recID.Substring(2)) + 1;

                    String setQuery = "update " + Table.session_info.tableName + " set " +
                        Table.session_info.admission_rec_start + "='" + recID.Substring(0, 2) + x + "' where " +
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
        /*
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

                        }
                        finally
                        {
                            myConnection.Close();
                        }
                    }

                    return recID;

                }
        */

        private void panel2Confirm_Click(object sender, EventArgs e)
        {
            if (feesExceeds)
            {
                DialogResult dgR = MessageBox.Show("Fees exceeds base structure, continue? ", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dgR != DialogResult.Yes)
                    return;
            }


            if (!belt_tieCheckbox.Checked)
                admissionFeesStruct[5, 0].Value = "0.00";

            if (cheque.TextLength == 0) cheque.Text = "0";

            removeHints();

            if (lastName.TextLength == 0)
            {
                lastName.Text = middleName.Text;
                middleName.Text = "";
            }

            receiptID = getNSetAdmissionReceiptID();
            if (receiptID == "" || receiptID.Equals("")) return;

            int genderInt;
            if (gender.SelectedIndex == 0) genderInt = 1;
            else genderInt = 0;

            String todayString = dateTimePicker.Value.ToString("yyyy-MM-dd");

            #region Student Details Query

            String insertQuery = "insert into " + Table.student_details.tableName + " (" +
            Table.student_details.student_id + ", " +
            Table.student_details.first_name + ", " +
            Table.student_details.middle_name + ", " +
            Table.student_details.last_name + ", " +
            Table.student_details.father_name + ", " +
            Table.student_details.mother_name + ", " +
            Table.student_details.gender + ", " +
            Table.student_details.dob + ", " +
            Table.student_details.category + ", " +
            Table.student_details.address + ", " +
            //Table.student_details.house_no + ", " +
            //Table.student_details.locality + ", " +
            //Table.student_details.ward + ", " +
            Table.student_details.city + ", " +
            Table.student_details.state + ", " +
            Table.student_details.pincode + ", " +
            Table.student_details.mobile + ", " +
            Table.student_details.phone + ", " +
            Table.student_details.guardian_name + ", " +
            Table.student_details.g_address + ", " +
            //Table.student_details.g_house_no + ", " +
            //Table.student_details.g_locality + ", " +
            //Table.student_details.g_ward + ", " +
            Table.student_details.g_city + ", " +
            Table.student_details.g_state + ", " +
            Table.student_details.g_pincode + ", " +
            Table.student_details.g_mobile + ", " +
            Table.student_details.g_phone + ", " +
            Table.student_details.samagra_id + ", " +
            Table.student_details.bank_name + ", " +
            Table.student_details.bank_ac_no + ", " +
            Table.student_details.bank_ifsc_code + ", " +
            Table.student_details.adhar_card + ", " +
            Table.student_details.admission_date + ", " +
            Table.student_details.admission_fees + ", " +
            Table.student_details.furniture_fund + ", " +
            Table.student_details.caution + ", " +
            Table.student_details.belt_tie + ", " +
            Table.student_details.admission_class + ", " +
            Table.student_details.admission_session + ", " +
            Table.student_details.tc_date + ", " +
            Table.student_details.current_session + ", " +
            Table.student_details.receipt_id + ", " +
            Table.student_details.student_category + ", " +
            Table.student_details.section + ", " +
            Table.student_details.class_n + ", " +
            Table.student_details.concession + ", " +
            Table.student_details.block_payment + ") " + " values ( '" +
            studentID.Text + "', '" +
            firstName.Text + "', '" +
            middleName.Text + "', '" +
            lastName.Text + "', '" +
            fatherName.Text + "', '" +
            motherName.Text + "', " +
            genderInt + ", '" +
            dateString + "', " +

            ((category.SelectedIndex == -1) ? ("NULL, ") : ("'" + GlobalVariables.categoryCast[category.SelectedIndex] + "', ")) +
            ((address.TextLength == 0) ? ("NULL, ") : ("'" + address.Text + "', ")) +
            //((hNO.TextLength == 0) ? ("NULL, ") : ("'" + hNO.Text + "', ")) +
            //((locality.TextLength == 0) ? ("NULL, ") : ("'" + locality.Text + "', ")) +
            //((ward.TextLength == 0) ? ("NULL, ") : ("'" + ward.Text + "', ")) +
            ((city.TextLength == 0) ? ("NULL, ") : ("'" + city.Text + "', ")) +
            ((state.TextLength == 0) ? ("NULL, ") : ("'" + state.Text + "', ")) +
            ((pincode.TextLength == 0) ? ("NULL, ") : ("'" + pincode.Text + "', ")) +
            ((mobile.TextLength == 0) ? ("NULL, ") : ("'" + mobile.Text + "', ")) +
            ((phone.TextLength == 0) ? ("NULL, ") : ("'" + phone.Text + "', ")) +
            ((guardianName.TextLength == 0) ? ("NULL, ") : ("'" + guardianName.Text + "', ")) +
            ((gAddress.TextLength == 0) ? ("NULL, ") : ("'" + gAddress.Text + "', ")) +
            //((gHNO.TextLength == 0) ? ("NULL, ") : ("'" + gHNO.Text + "', ")) +
            //((gLocality.TextLength == 0) ? ("NULL, ") : ("'" + gLocality.Text + "', ")) +
            //((gWard.TextLength == 0) ? ("NULL, ") : ("'" + gWard.Text + "', ")) +
            ((gCity.TextLength == 0) ? ("NULL, ") : ("'" + gCity.Text + "', ")) +
            ((gState.TextLength == 0) ? ("NULL, ") : ("'" + gState.Text + "', ")) +
            ((gPincode.TextLength == 0) ? ("NULL, ") : ("'" + gPincode.Text + "', ")) +
            ((gMobile.TextLength == 0) ? ("NULL, ") : ("'" + gMobile.Text + "', ")) +
            ((gPhone.TextLength == 0) ? ("NULL, ") : ("'" + gPhone.Text + "', ")) +

            ((samagraID.TextLength == 0) ? ("NULL, ") : ("'" + samagraID.Text + "', ")) +
            ((bank.TextLength == 0) ? ("NULL, ") : ("'" + bank.Text + "', ")) +
            ((bankAC.TextLength == 0) ? ("NULL, ") : ("'" + bankAC.Text + "', ")) +
            ((bankIFSC.TextLength == 0) ? ("NULL, ") : ("'" + bankIFSC.Text + "', ")) +
            ((aadharID.TextLength == 0) ? ("NULL, '") : ("'" + aadharID.Text + "', '")) +

            todayString + "', " +

            CommonMethods.amountToInt(admissionFeesStruct[0, 0].Value.ToString()) + ", " +
            CommonMethods.amountToInt(admissionFeesStruct[2, 0].Value.ToString()) + ", " +
            CommonMethods.amountToInt(admissionFeesStruct[4, 0].Value.ToString()) + ", " +
            (belt_tieCheckbox.Checked? ( "" + CommonMethods.amountToInt(admissionFeesStruct[5, 0].Value.ToString())): "0.00" ) + ", '" +

            Classes.classArray[class_n.SelectedIndex] + "', " +

            ((currentSession.Checked) ? GlobalVariables.currentSession : (GlobalVariables.currentSession + 1)) + ", " +

            "NULL, " + //TC Receipt ID

            ((currentSession.Checked) ? ("" + GlobalVariables.currentSession) : ("NULL")) + ", '" +
            receiptID + "', '" +
            GlobalVariables.newStud + "', '" +
            section.Text + "', '" +
            Classes.classArray[class_n.SelectedIndex] + "', " +
            ((concession.Checked) ? 1 : 0) + ", " +

            0 + ");";


            #endregion

            //MessageBox.Show(insertStudentDetailQuery);

            #region Annual Fees Query

            //#TODO concession check, calculate Cheque amount
            insertQuery += "insert into " + Table.student_annual_fees.tableName + " (" +
            Table.student_annual_fees.student_id + ", " +
            Table.student_annual_fees.session + ", " +
            Table.student_annual_fees.school_dev + ", " +
            Table.student_annual_fees.lab_dev + ", " +
            Table.student_annual_fees.caution + ", " +
            Table.student_annual_fees.receipt_id + ", " +
            Table.student_annual_fees.date + ", " +
            Table.student_annual_fees.class_n + ", " +
            Table.student_annual_fees.concession + ", " +
            Table.student_annual_fees.terminal + ", " +
            Table.student_annual_fees.cheque + ") values('" +
            studentID.Text + "', " +
            ((currentSession.Checked) ? GlobalVariables.currentSession : (GlobalVariables.currentSession + 1)) + ", " +
            CommonMethods.amountToInt(admissionFeesStruct[1, 0].Value.ToString()) + ", " +
            CommonMethods.amountToInt(admissionFeesStruct[3, 0].Value.ToString()) + ", " +
            CommonMethods.amountToInt(admissionFeesStruct[4, 0].Value.ToString()) + ", '" +
            receiptID + "', '" +
            todayString + "', '" +
            Classes.classArray[class_n.SelectedIndex] + "', " +
            ((conc) ? 1 : 0) + ", " +
            GlobalVariables.thisTerminal + ", " +
            cheque.Text + ");";

            #endregion

            String monthlyQuery = getMonthlyQuery();

            if (monthlyQuery == "" || monthlyQuery.Equals(""))
            {
                MessageBox.Show("Unable to generate monthly fees table", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                        
            insertQuery += monthlyQuery;

            

            using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    connection.Open();
                    //Student Details
                    try
                    {
                        incrementStudentID();
                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                        {
                            insertCommand.ExecuteNonQuery();
                        }

                        PrintAdmissionReceipt();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                        DialogResult dr = MessageBox.Show("Error during insertion of Student Details, Contact Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (dr == System.Windows.Forms.DialogResult.OK)
                        {
                            
                        }
                        forceClose = true;
                        Close();
                    }

                    

                }
                catch (Exception)
                {
                    DialogResult dr = MessageBox.Show("Unable to setup connection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            forceClose = true;
            this.Close();
        }


        private String getMonthlyQuery()
        {
            String getMQuery = "select * from " + Table.monthly_base_struct.tableName + " where " +
                        Table.monthly_base_struct.session + " = " + GlobalVariables.currentSession + " and " +
                        Table.monthly_base_struct.clss + " = '" + Classes.classArray[class_n.SelectedIndex] + "';";

            String setMString = "insert into " + Table.student_monthly_fees.tableName + " (" +
                Table.student_monthly_fees.student_id + ", " +
                Table.student_monthly_fees.session + ", " +
                Table.student_monthly_fees.month + ", " +
                Table.student_monthly_fees.tuition + ", " +
                Table.student_monthly_fees.management + ", " +
                Table.student_monthly_fees.smart_class + ", " +
                Table.student_monthly_fees.report_diary + ", " +
                Table.student_monthly_fees.sports + ", " +
                Table.student_monthly_fees.science + ", " +
                Table.student_monthly_fees.red_cross + ", " +
                Table.student_monthly_fees.guide + ", " +
                Table.student_monthly_fees.insurance + ", " +
                Table.student_monthly_fees.school_activities + ", " +
                Table.student_monthly_fees.computer + ", " +
                Table.student_monthly_fees.local_exam + ", " +
                Table.student_monthly_fees.late_fees + ", " +
                Table.student_monthly_fees.receipt_id + ", " +
                Table.student_monthly_fees.class_n + ", " +
                Table.student_monthly_fees.date + ", " +
                Table.student_monthly_fees.concession + ", " +
                Table.student_monthly_fees.terminal + ", " +
                Table.student_monthly_fees.cheque + ") values('" +
                studentID.Text + "', " +
                ((currentSession.Checked) ? GlobalVariables.currentSession : (GlobalVariables.currentSession + 1)) +
                ", '";

            String[] monthlyQuery = new String[12]{setMString,setMString,setMString,setMString,setMString,setMString,
                                                    setMString,setMString,setMString,setMString,setMString,setMString};

            using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                connection.Open();
                try
                {
                    using (SqlCommand getCommand = new SqlCommand(getMQuery, connection))
                    {
                        SqlDataReader dr;
                        dr = getCommand.ExecuteReader();
                        int i = 0;
                        while (dr.Read())
                        {
                            monthlyQuery[i] += dr[Table.monthly_base_struct.mnth].ToString() + "', " +
                                dr[Table.monthly_base_struct.tuition].ToString() + ", " +
                                dr[Table.monthly_base_struct.management].ToString() + ", " +
                                dr[Table.monthly_base_struct.smart].ToString() + ", " +
                                dr[Table.monthly_base_struct.report].ToString() + ", " +
                                dr[Table.monthly_base_struct.sports].ToString() + ", " +
                                dr[Table.monthly_base_struct.science].ToString() + ", " +
                                dr[Table.monthly_base_struct.red_cross].ToString() + ", " +
                                dr[Table.monthly_base_struct.guide].ToString() + ", " +
                                dr[Table.monthly_base_struct.insurance].ToString() + ", " +
                                dr[Table.monthly_base_struct.school_activities].ToString() + ", " +
                                dr[Table.monthly_base_struct.computer].ToString() + ", " +
                                dr[Table.monthly_base_struct.local_exam].ToString() + ", " +
                                0 + ", " +  //late fees
                                "NULL, '" +
                                Classes.classArray[class_n.SelectedIndex] + "', " +
                                "NULL, " +
                                0 + ", " +  //concession
                                "NULL, " +
                                "NULL);";

                            i++;

                        }
                        dr.Close();
                        if (i != 12)
                        {
                            MessageBox.Show("All months not found " + i);
                            return "";
                        }
                    }

                    String completeQuery = "";
                    foreach (String temp in monthlyQuery)
                    {
                        completeQuery += temp;
                    }
                    return completeQuery;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message);
                    return "";
                }
            }
        }


        private void incrementStudentID()
        {
            int x = Int32.Parse(studentID.Text.Substring(2)) + 1;


            String incrementQuery = "update " + Table.session_info.tableName + " set " + Table.session_info.st_id_start +
                " = '" + studentID.Text.Substring(0, 2) + x + "' where " + Table.session_info.active_session + " = 1 ";
            //MessageBox.Show(incrementQuery);
            using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand updateCommand = new SqlCommand(incrementQuery, connection))
                    {
                        updateCommand.ExecuteNonQuery();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void generateAdmissionReceipt()
        {
            MessageBox.Show("Generating Admission Receipt");
        }

        private void pincode_Leave(object sender, EventArgs e)
        {
            pincode.Text = CommonMethods.onlyNumeric(pincode.Text);
        }

        private void mobile_Leave(object sender, EventArgs e)
        {
            mobile.Text = CommonMethods.onlyNumeric(mobile.Text);
        }

        private void phone_Leave(object sender, EventArgs e)
        {
            phone.Text = CommonMethods.onlyNumeric(phone.Text);
        }

        private void gPincode_Leave(object sender, EventArgs e)
        {
            gPincode.Text = CommonMethods.onlyNumeric(gPincode.Text);
        }

        private void gMobile_Leave(object sender, EventArgs e)
        {
            gMobile.Text = CommonMethods.onlyNumeric(gMobile.Text);
        }

        private void gPhone_Leave(object sender, EventArgs e)
        {
            gPhone.Text = CommonMethods.onlyNumeric(gPhone.Text);
        }

        private void samagraID_Leave(object sender, EventArgs e)
        {
            samagraID.Text = CommonMethods.onlyNumeric(samagraID.Text);
        }

        private void cheque_TextChanged(object sender, EventArgs e)
        {
            cheque.Text = "" + CommonMethods.amountToInt(cheque.Text);
            if (CommonMethods.amountToInt(cheque.Text) > CommonMethods.amountToInt("" + admissionFeesStruct[6, 0].Value))
            {
                cheque.Text = "" + admissionFeesStruct[6, 0].Value;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void aadharID_Leave(object sender, EventArgs e)
        {
            aadharID.Text = CommonMethods.onlyNumeric(aadharID.Text);
        }

        private void city_Leave(object sender, EventArgs e)
        {
            city.Text = city.Text.ToUpper();
            if (city.Text.ToLower().Trim() == "jabalpur")
            {
                city.Text = "JABALPUR";
                state.Text = "MADHYA PRADESH";
                pincode.Text = "482001";
            }
        }

        private void gCity_Leave(object sender, EventArgs e)
        {
            gCity.Text = gCity.Text.ToUpper();
            if (gCity.Text.ToLower().Trim() == "jabalpur")
            {
                gCity.Text = "JABALPUR";
                gState.Text = "MADHYA PRADESH";
                gPincode.Text = "482001";
            }
        }

        private void address_TextChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            allowChange = false;
            int pos = ((RichTextBox)sender).SelectionStart;
            String txt = ((RichTextBox)sender).Text;
            int i = 0;
            ((RichTextBox)sender).Text = "";
            foreach(char c in txt)
            {
                if (i == 0) ((RichTextBox)sender).Text = c.ToString().ToUpper();
                else
                {
                    if (txt.Substring(i - 1, 1) == " " || txt.Substring(i - 1, 1) == "," || txt.Substring(i - 1, 1) == ".")
                        ((RichTextBox)sender).Text += c.ToString().ToUpper();
                    else ((RichTextBox)sender).Text += c.ToString().ToLower();
                }
                i++;
            }
            ((RichTextBox)sender).SelectionStart = pos;
            allowChange = true;
        }

        private void gAddress_TextChanged(object sender, EventArgs e)
        {

            if (!allowChange) return;
            allowChange = false;
            int pos = ((RichTextBox)sender).SelectionStart;
            String txt = ((RichTextBox)sender).Text;
            int i = 0;
            ((RichTextBox)sender).Text = "";
            foreach (char c in txt)
            {
                if (i == 0) ((RichTextBox)sender).Text = c.ToString().ToUpper();
                else
                {
                    if (txt.Substring(i - 1, 1) == " " || txt.Substring(i - 1, 1) == "," || txt.Substring(i - 1, 1) == ".")
                        ((RichTextBox)sender).Text += c.ToString().ToUpper();
                    else ((RichTextBox)sender).Text += c.ToString().ToLower();
                }
                i++;
            }
            ((RichTextBox)sender).SelectionStart = pos;
            allowChange = true;
        }

        private void bank_TextChanged(object sender, EventArgs e)
        {
        }

        private void bank_Leave(object sender, EventArgs e)
        {
            if (!allowChange) return;
            allowChange = false;
            bank.Text = bank.Text.ToUpper();
            allowChange = true;
        }

        private void bankAC_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
        }

        private void bankIFSC_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
        }

        private void firstName_TextChanged(object sender, EventArgs e)
        {
            //#TODO on space pressed send to next
            /*
            if(firstName.TextLength>1 && firstName.Text.Substring(firstName.TextLength-1,1).Equals(" "))
            {
                firstName.Text = firstName.Text.Substring(0,firstName.TextLength-1);
            }
             */
        }

        private void removeHints()
        {
            formatTextBox(firstName);
            formatTextBox(middleName);
            formatTextBox(lastName);
            formatTextBox(fatherName);
            formatTextBox(motherName);
            formatRichTextBox(address);
            //formatTextBox(hNO);
            //formatTextBox(locality);
            //formatTextBox(ward);
            formatTextBox(city);
            formatTextBox(state);
            formatTextBox(pincode);
            formatNumTextBox(mobile);
            formatNumTextBox(phone);
            formatRichTextBox(gAddress);
            //formatTextBox(gHNO);
            //formatTextBox(gLocality);
            //formatTextBox(gWard);
            formatTextBox(gCity);
            formatTextBox(gState);
            formatTextBox(gPincode);
            formatNumTextBox(gMobile);
            formatNumTextBox(gPhone);
            formatNumTextBox(samagraID);
            formatNumTextBox(aadharID);
            formatTextBox(bank);
            formatTextBox(bankAC);
            formatTextBox(bankIFSC);


            if (middleName.Text == "Middle Name") middleName.Text = "";
            if (lastName.Text == "Last Name") lastName.Text = "";
            if (fatherName.Text == "Full Name") fatherName.Text = "";
            if (motherName.Text == "Full Name") motherName.Text = "";
            if (guardianName.Text == "Full Name") guardianName.Text = "";
        }

        private void formatTextBox(TextBox tb)
        {
            String text = tb.Text;
            String newText = "";
            foreach (char c in text)
            {
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9') || c == ' ' ||
                    c == '.' || c == ',' || c == '(' || c == ')' || c == '-' || c == '@' || c == '$')
                    newText += c;
            }
            tb.Text = newText;
        }

        private void formatRichTextBox(RichTextBox tb)
        {
            String text = tb.Text;
            String newText = "";
            foreach (char c in text)
            {
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9') || c == ' ' ||
                    c == '.' || c == ',' || c == '(' || c == ')' || c == '-' || c == '@' || c == '$')
                    newText += c;
                if (c == '\n') newText += GlobalVariables.nextLineCharacter; 
            }
            tb.Text = newText;
        }

        private void formatNumTextBox(TextBox tb)
        {
            String text = tb.Text;
            String newText = "";
            foreach (char c in text)
            {
                if (c >= '0' && c <= '9')
                    newText += c;
            }
            tb.Text = newText;
        }

    }
}
