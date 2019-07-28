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

/*              READ ME
 * Minimum protection against cascading failure: When confirmed, multiple tables have to be updated, if one fails
 *          other are still updated leading to inconsistency. This problem if faced ignore for now, it will be 
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
    public partial class EditStudentDetails : Form
    {
        
        Boolean forceClose;         // if active does not shows closing dialog (during fatal error)

        Boolean firstNameChange, middleNameChange, lastNameChange,      //  Allows formating of respective fields
            fatherNameChange, motherNameChange, guardianNameChange;     //

        Boolean idChangeActive;

        String dateString;

        Boolean exStudent;

        Boolean allowChange;

        public EditStudentDetails()
        {
            forceClose = false;

            firstNameChange = middleNameChange = lastNameChange =
                fatherNameChange = motherNameChange = guardianNameChange = false;
            
            InitializeComponent();

            category.DataSource = GlobalVariables.categoryCastNames;       //Cast/Category names
            suspension_month.DataSource = GlobalVariables.months;

            firstNameChange = middleNameChange = lastNameChange =
                fatherNameChange = motherNameChange = guardianNameChange = true;
            allowChange = true;
        }

        private void EditStudentDetails_Load(object sender, EventArgs e)
        {
            panel1Setup();
            idChangeActive = true;
            disableAll();
        }

        private void panel1Setup()
        {
            setGuardian();
            setSuspended();
            //leaveEvents();
            changeClass.Enabled = false;
            panel2Confirm.Enabled = false;
            studID.SelectionStart = 2;
            studID.SelectionLength = 0;
        }

        /*
        private void leaveEvents()      //To activate leave event
        {
            firstName_Leave(null, null);         //
            middleName_Leave(null, null);       // Leave events add hints to fields
            lastName_Leave(null, null);         //
            fatherName_Leave(null, null);       //
            motherName_Leave(null, null);       //
            guardianName_Leave(null, null);     //
        }
        */

        private void setGuardian()
        {
            guardianName.Enabled = gAddress.Enabled = //gHNO.Enabled = gLocality.Enabled = gWard.Enabled = 
                gCity.Enabled = gState.Enabled = gPincode.Enabled =
                gMobile.Enabled = gPhone.Enabled = guardian.Checked;
        }

        private void setSuspended()
        {
            suspension_month.Enabled = suspended_remark.Enabled
                = suspended.Checked;
        }

        private void panel1Next_Click(object sender, EventArgs e)
        {
            panel0.Visible = false;
        //    panel1.Visible = true;
        }

        private void panel1Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditStudentDetails_FormClosing(object sender, FormClosingEventArgs e)    //Throws dialog on during closing
        {
            /*
            if (!forceClose)
            {
                DialogResult cancelAdmission = MessageBox.Show("Are you sure you want to cancel Admission?", "Cancel Admission", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (cancelAdmission == System.Windows.Forms.DialogResult.No) e.Cancel = true;
                else e.Cancel = false;
            }
            else
                e.Cancel = false;*/
        }

        private void EditStudentDetailsClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.esForm = null;
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
            setGuardian();
        }
        /*
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
*/

        private void checkAll1()      //  Checks for valid necessary entries for next panel activation
        {
            panel2Confirm.Enabled = true;
            if (firstName.Text.Length <= 2 || middleName.Text.Length + lastName.Text.Length <= 2)
                panel2Confirm.Enabled = false;
            if (firstName.Text.Equals("First Name") || (middleName.Text.Equals("Middle Name") && lastName.Text.Equals("Last Name")))
                panel2Confirm.Enabled = false;
            if (gender.SelectedIndex != 0 && gender.SelectedIndex != 1)
                panel2Confirm.Enabled = false;
            if (age.Text == null || age.Text.Length == 0 || CommonMethods.valueBetween(age.Text, 0, 1) ||
                CommonMethods.valueBetween(age.Text, 25, 99))
                panel2Confirm.Enabled = false;
        }

        private void gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkAll1();
        }

        private void panel2Confirm_Click(object sender, EventArgs e)
        {

            removeHints();

            if (lastName.TextLength == 0)
            {
                lastName.Text = middleName.Text;
                middleName.Text = "";
            }

            int genderInt;
            if (gender.SelectedIndex == 0) genderInt = 1;
            else genderInt = 0;
            

            //>Student Details

            String updateStudentDetailQuery = "update " + Table.student_details.tableName + " set " +
            Table.student_details.first_name + " = '" + firstName.Text + "', " +
            Table.student_details.middle_name + " = '" + middleName.Text + "', " +
            Table.student_details.last_name + " = '" + lastName.Text + "', " +
            Table.student_details.father_name + " = '" + fatherName.Text + "', " +
            Table.student_details.mother_name + " = '" + motherName.Text + "', " +
            Table.student_details.gender + " = " + genderInt + ", " +
            Table.student_details.dob + " = '" + dateString + "', " +
            Table.student_details.category + " = " +
                ((category.SelectedIndex == -1) ? ("NULL, ") : ("'" + GlobalVariables.categoryCast[category.SelectedIndex] + "', ")) +
            Table.student_details.address + " = " +
            ((address.TextLength == 0) ? ("NULL, ") : ("'" + address.Text + "', ")) +
            //Table.student_details.house_no + " = " + ((hNO.TextLength == 0) ? ("NULL, ") : ("'" + hNO.Text + "', ")) +
            //Table.student_details.locality + " = " + ((locality.TextLength == 0) ? ("NULL, ") : ("'" + locality.Text + "', ")) +
            //Table.student_details.ward + " = " + ((ward.TextLength == 0) ? ("NULL, ") : ("'" + ward.Text + "', ")) +
            Table.student_details.city + " = " + ((city.TextLength == 0) ? ("NULL, ") : ("'" + city.Text + "', ")) +
            Table.student_details.state + " = " + ((state.TextLength == 0) ? ("NULL, ") : ("'" + state.Text + "', ")) +
            Table.student_details.pincode + " = " + ((pincode.TextLength == 0) ? ("NULL, ") : ("'" + pincode.Text + "', ")) +
            Table.student_details.mobile + " = " + ((mobile.TextLength == 0) ? ("NULL, ") : ("'" + mobile.Text + "', ")) +
            Table.student_details.phone + " = " + ((phone.TextLength == 0) ? ("NULL, ") : ("'" + phone.Text + "', ")) +
            Table.student_details.guardian_name + " = " + ((guardianName.TextLength == 0) ? ("NULL, ") : ("'" + guardianName.Text + "', ")) +
            Table.student_details.g_address + " = " +
            ((gAddress.TextLength == 0) ? ("NULL, ") : ("'" + gAddress.Text + "', ")) +
            //Table.student_details.g_house_no + " = " + ((gHNO.TextLength == 0) ? ("NULL, ") : ("'" + gHNO.Text + "', ")) +
            //Table.student_details.g_locality + " = " + ((gLocality.TextLength == 0) ? ("NULL, ") : ("'" + gLocality.Text + "', ")) +
            //Table.student_details.g_ward + " = " + ((gWard.TextLength == 0) ? ("NULL, ") : ("'" + gWard.Text + "', ")) +
            Table.student_details.g_city + " = " + ((gCity.TextLength == 0) ? ("NULL, ") : ("'" + gCity.Text + "', ")) +
            Table.student_details.g_state + " = " + ((gState.TextLength == 0) ? ("NULL, ") : ("'" + gState.Text + "', ")) +
            Table.student_details.g_pincode + " = " + ((gPincode.TextLength == 0) ? ("NULL, ") : ("'" + gPincode.Text + "', ")) +
            Table.student_details.g_mobile + " = " + ((gMobile.TextLength == 0) ? ("NULL, ") : ("'" + gMobile.Text + "', ")) +
            Table.student_details.g_phone + " = " + ((gPhone.TextLength == 0) ? ("NULL, ") : ("'" + gPhone.Text + "', ")) +
            Table.student_details.samagra_id + " = " + ((samagraID.TextLength == 0) ? ("NULL, ") : ("'" + samagraID.Text + "', ")) +
            Table.student_details.bank_name + " = " + ((bank.TextLength == 0) ? ("NULL, ") : ("'" + bank.Text + "', ")) +
            Table.student_details.bank_ac_no + " = " + ((bankAC.TextLength == 0) ? ("NULL, ") : ("'" + bankAC.Text + "', ")) +
            Table.student_details.bank_ifsc_code + " = " + ((bankIFSC.TextLength == 0) ? ("NULL, ") : ("'" + bankIFSC.Text + "', ")) +
            Table.student_details.adhar_card + " = " + ((aadharID.TextLength == 0) ? ("NULL, ") : ("'" + aadharID.Text + "', ")) +
            Table.student_details.section + " = '" + section.Text + "', " +
            Table.student_details.concession + " = " + ((adConcession.Checked)? 1 : 0) + ", " +
            Table.student_details.suspended + " = " + ((suspended.Checked)? 1 : 0) + ", " +
            Table.student_details.suspension_month + " = " + ((suspended.Checked)? ("'" + GlobalVariables.db_months[suspension_month.SelectedIndex] + "'") : "NULL") + ", " + 
            Table.student_details.suspension_remark + " = " + ((suspended.Checked) ? ("'" + suspended_remark.Text + "'") : "NULL") +
            " where " + Table.student_details.student_id + " = '" + studID.Text + "';";


            using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                { 
                    connection.Open();
                    //Student Details
                    try
                    {
                        using (SqlCommand insertCommand = new SqlCommand(updateStudentDetailQuery, connection))
                        {
                            insertCommand.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        DialogResult dr = MessageBox.Show("Error during insertion of Student Details, Contact Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (dr == DialogResult.OK)
                        {
                            forceClose = true;
                            Close();
                        }
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
            studID_TextChanged(null, null);
            MessageBox.Show("Changes saved");
            this.ActiveControl = studID;
            studID.SelectionStart = studID.Text.Length;

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

        private void studID_TextChanged(object sender, EventArgs e)
        {
            if (!idChangeActive) return;

            idChangeActive = false;

            panel2Confirm.Enabled = false;

            adConcession.Checked = false;

            disableAll();            

            if (studID.TextLength == 8 && CommonMethods.studentIDCheck(studID.Text))
            {

                enableSome();

                resetFields();

                studID.Text = studID.Text.ToUpper();
                //panel1Next.Enabled = true;
                
                String detailQuery = "select * from " + Table.student_details.tableName + " where " +
                            Table.student_details.student_id + " = '" + studID.Text + "';";

                exStudent = false;

                SqlDataReader dr;
                using (SqlConnection myConnection = new SqlConnection(GlobalVariables.dbConnectString))
                {
                    try
                    {
                        myConnection.Open();
                        using (SqlCommand myCommand = new SqlCommand(detailQuery, myConnection))
                        {
                            dr = myCommand.ExecuteReader();

                            if (dr.Read())
                            {

                                
                                firstName.Text = dr[Table.student_details.first_name].ToString();
                                middleName.Text = dr[Table.student_details.middle_name].ToString();
                                lastName.Text = dr[Table.student_details.last_name].ToString();
                                fatherName.Text = dr[Table.student_details.father_name].ToString();
                                motherName.Text = dr[Table.student_details.mother_name].ToString();
                                gender.SelectedIndex = dr.GetBoolean(dr.GetOrdinal(Table.student_details.gender)) ? 0 : 1;

                                DateTime date;
                                DateTime.TryParse(dr[Table.student_details.dob].ToString(),out date);

                                //MessageBox.Show("" + date + "\n " + date.Day + " " + date.Month + " " + date.Year );
                                dobDate.Text = "" + date.Day;
                                dobMonth.Text = "" + date.Month;
                                dobYear.Text = ("" + date.Year).Substring(2);

                                String cat = dr[Table.student_details.category].ToString();
                                if (cat.Equals(GlobalVariables.categoryCast[0])) category.SelectedIndex = 0;
                                else if(cat.Equals(GlobalVariables.categoryCast[1])) category.SelectedIndex = 1;
                                else if (cat.Equals(GlobalVariables.categoryCast[2])) category.SelectedIndex = 2;
                                else if (cat.Equals(GlobalVariables.categoryCast[3])) category.SelectedIndex = 3;
                                
                                //hNO.Text = dr[Table.student_details.house_no].ToString();
                                //locality.Text = dr[Table.student_details.locality].ToString();
                                //ward.Text = dr[Table.student_details.ward].ToString();
                                address.Text = addNewLine(dr[Table.student_details.address].ToString());
                                city.Text = dr[Table.student_details.city].ToString();
                                state.Text = dr[Table.student_details.state].ToString();
                                pincode.Text = dr[Table.student_details.pincode].ToString();
                                mobile.Text = dr[Table.student_details.mobile].ToString();
                                phone.Text = dr[Table.student_details.phone].ToString();

                                guardianName.Text = dr[Table.student_details.guardian_name].ToString();
                                gAddress.Text = addNewLine(dr[Table.student_details.g_address].ToString());
                                //gHNO.Text = dr[Table.student_details.g_house_no].ToString();
                                //gLocality.Text = dr[Table.student_details.g_locality].ToString();
                                //gWard.Text = dr[Table.student_details.g_ward].ToString();
                                gCity.Text = dr[Table.student_details.g_city].ToString();
                                gState.Text = dr[Table.student_details.g_state].ToString();
                                gPincode.Text = dr[Table.student_details.g_pincode].ToString();
                                gMobile.Text = dr[Table.student_details.g_mobile].ToString();
                                gPhone.Text = dr[Table.student_details.g_phone].ToString();

                                 
                                if (guardianName.TextLength !=0 || gAddress.TextLength != 0 || //gHNO.TextLength != 0 || gLocality.TextLength != 0 || gWard.TextLength != 0 ||
                                   gCity.TextLength != 0 || gState.TextLength != 0 || gPincode.TextLength != 0 ||
                                   gMobile.TextLength != 0 || gPhone.TextLength != 0)
                                    guardian.Checked = true;
                                else guardian.Checked = false;

                                samagraID.Text = dr[Table.student_details.samagra_id].ToString();
                                aadharID.Text = dr[Table.student_details.adhar_card].ToString();
                                bank.Text = dr[Table.student_details.bank_name].ToString();
                                bankAC.Text = dr[Table.student_details.bank_ac_no].ToString();
                                bankIFSC.Text = dr[Table.student_details.bank_ifsc_code].ToString();

                                session.Text = dr[Table.student_details.admission_session].ToString();
                                session.Text += "-" + (Int32.Parse(session.Text) + 1);
                                
                                section.SelectedIndex = Convert.ToChar(dr[Table.student_details.section].ToString()) - 'A';
                                //MessageBox.Show("" + Convert.ToChar(dr[Table.student_details.section].ToString()));


                                classSelected.Text = Classes.getClassBranch(dr[Table.student_details.class_n].ToString());

                                if (dr[Table.student_details.current_session] != DBNull.Value)
                                    currSession.Text = dr[Table.student_details.current_session].ToString() + 
                                        "-" + (Convert.ToInt32(dr[Table.student_details.current_session]) + 1);

                                DateTime.TryParse(dr[Table.student_details.admission_date].ToString(), out date);

                                studCat.Text = dr[Table.student_details.student_category].ToString();
                                if (studCat.Text == GlobalVariables.newStud) studCat.Text = "New Student";
                                else if (studCat.Text == GlobalVariables.oldStud) studCat.Text = "Old Student";
                                else if (studCat.Text == GlobalVariables.manStud) studCat.Text = "Manual Student Entry";
                                else if (studCat.Text == GlobalVariables.exStud)
                                {
                                    studCat.Text = "EX Student";
                                    panel2Confirm.Enabled = false;
                                    exStudent = true;
                                    MessageBox.Show("The student is an Ex-Student");
                                    DateTime date3;
                                    DateTime.TryParse(dr[Table.student_details.tc_date].ToString(), out date3);
                                    tcDate.Text = "" + date3.Day + "-" + date3.Month + "-" + date3.Year;
                                    tcReason.Text = dr[Table.student_details.reason].ToString();

                                }
                                else if (studCat.Text == GlobalVariables.provStud) studCat.Text = "Provisional Student";
                                

                                DateTime date2;
                                DateTime.TryParse(dr[Table.student_details.admission_date].ToString(), out date2);

                                adDate.Text = "" + date2.Day;
                                adDate.Text += "-" + date2.Month;
                                adDate.Text += "-" + date2.Year;

                                adReceipt.Text = dr[Table.student_details.receipt_id].ToString();
                                adClass.Text = Classes.getClassBranch(dr[Table.student_details.admission_class].ToString());
                                changeClass.Enabled = true;
                                section.Enabled = true;
                                
                                if (dr[Table.student_details.suspended] == DBNull.Value) suspended.Checked = false;
                                else
                                {
                                    suspended.Checked = dr.GetBoolean(dr.GetOrdinal(Table.student_details.suspended));
                                }
                                
                                suspension_month.SelectedIndex = 0;
                                suspended_remark.Text = "";
                                if (suspended.Checked)
                                {
                                    int i = 0;
                                    String month = dr[Table.student_details.suspension_month].ToString();
                                    for (; i < GlobalVariables.db_months.Length; i++)
                                    {
                                        if(month.Equals(GlobalVariables.db_months[i]))
                                        {
                                            suspension_month.SelectedIndex = i;
                                            break;
                                        }
                                    }
                                    suspended_remark.Text = dr[Table.student_details.suspension_remark].ToString();
                                }
                                

                            }
                            else
                            {
                                MessageBox.Show("Student does not exist");
                            }
                            dr.Close();
                            
                        }

                    }
                    catch(Exception ex )
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        myConnection.Close();
                    }
                }

            }
            else
            {
                resetFields();
            }
            if (exStudent) disableAll();
            idChangeActive = true;
        }

        private void enableSome()
        {
            adConcession.Enabled = true;
            var controls = groupBox1.Controls;
            foreach (Control ct in controls)
            {
                if (ct.GetType() == studID.GetType() && ct != studID && ct != age)
                {
                    ct.Enabled = true;
                }
                if (ct.GetType() == gender.GetType())
                {
                    ct.Enabled = true;
                }
            }
            address.Enabled = true;
            controls = groupBox2.Controls;
            foreach (Control ct in controls)
            {
                if (ct.GetType() == studID.GetType())
                {
                    ct.Enabled = true;
                }
            }

            guardian.Enabled = true;
            guardian.Checked = false;
            controls = groupBox5.Controls;
            foreach (Control ct in controls)
            {
                if (ct.GetType() == studID.GetType())
                {
                    ct.Enabled = false;
                }
            }
            suspended.Enabled = true;

            controls = groupBox3.Controls;
            foreach (Control ct in controls)
            {
                if (ct.GetType() == studID.GetType())
                {
                    ct.Enabled = true;
                }
            }

        }

        private void disableAll()
        {

            adConcession.Enabled = false;
            var controls = groupBox1.Controls;
            foreach (Control ct in controls)
            {
                if (ct.GetType() == studID.GetType() && ct != studID)
                {
                    ct.Enabled = false;
                }
                if (ct.GetType() == gender.GetType())
                {
                    ct.Enabled = false;
                }
            }

            controls = groupBox2.Controls;
            foreach (Control ct in controls)
            {
                if (ct.GetType() == studID.GetType())
                {
                    ct.Enabled = false;
                }
            }
            address.Enabled = false;
            guardian.Enabled = false;
            controls = groupBox5.Controls;
            foreach (Control ct in controls)
            {
                if (ct.GetType() == studID.GetType())
                {
                    ct.Enabled = false;
                }
            }

            controls = groupBox3.Controls;
            foreach (Control ct in controls)
            {
                if (ct.GetType() == studID.GetType())
                {
                    ct.Enabled = false;
                }
            }

            changeClass.Enabled = false;
            section.Enabled = false;
            suspended.Enabled = false;
            suspension_month.Enabled = false;
            suspended_remark.Enabled = false;
        }

        private void resetFields()
        {
            
            firstName.Text = middleName.Text = lastName.Text = fatherName.Text = motherName.Text =
                dobDate.Text = dobMonth.Text = dobYear.Text = //hNO.Text = locality.Text = ward.Text =
                address.Text = 
                city.Text = state.Text = pincode.Text = mobile.Text = phone.Text = guardianName.Text = //gHNO.Text = gLocality.Text = gWard.Text = 
                gAddress.Text = 
                gCity.Text = gState.Text = gPincode.Text =
                gMobile.Text = gPhone.Text = samagraID.Text = aadharID.Text = bank.Text = bankAC.Text =
                bankIFSC.Text = session.Text = classSelected.Text = age.Text = studCat.Text = adDate.Text = 
                adReceipt.Text = adClass.Text = tcDate.Text = tcReason.Text = currSession.Text = suspended_remark.Text = "";
            guardian.Checked = false;
            suspended.Checked = false; 
            section.Enabled = false;
            section.SelectedIndex = -1;
            changeClass.Enabled = false;
            gender.SelectedIndex = category.SelectedIndex = -1;
            panel2Confirm.Enabled = false;

        }

        private void changeClass_Click(object sender, EventArgs e)
        {
            StudentChangeClass scc = new StudentChangeClass();
            scc.studentID = studID.Text;
            for (int i = 0; i < Classes.classBranchNameArray.Length; i++)
            {
                if (classSelected.Text == Classes.classBranchNameArray[i])
                    scc.currentClassIndex = i;
            }
            scc.ShowDialog();

            studID_TextChanged(null, null);
        }

        private void aadharID_Leave(object sender, EventArgs e)
        {
            aadharID.Text = CommonMethods.onlyNumeric(aadharID.Text);
        }

        private void firstName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void city_Leave(object sender, EventArgs e)
        {
            if(city.Text.ToLower().Trim() == "jabalpur")
            {
                city.Text = "Jabalpur";
                state.Text = "Madhya Pradesh";
                pincode.Text = "482002";
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

        private void guardianName_Leave(object sender, EventArgs e)
        {
            if (fatherNameChange)
            {
                fatherNameChange = false;
                guardianName.Text = CommonMethods.nameFormat(guardianName.Text);
                if (guardianName.Text.Length == 0)
                {
                    guardianName.Text = "Full Name";
                    guardianName.ForeColor = SystemColors.GrayText;
                }
                //checkAll1();
                fatherNameChange = true;
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

        private void bank_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
        }

        private void bankAC_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
        }

        private void bankIFSC_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void suspended_CheckedChanged(object sender, EventArgs e)
        {
            setSuspended();
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

        public String addNewLine(String text)
        {
            if (text == null || text.Length == 0) return "";
            String temp = "";
            foreach(char c in text)
            {
                if (c == GlobalVariables.nextLineCharacter)
                    temp += '\n';
                else temp += c;
            }
            return temp;
        }
    }
}
