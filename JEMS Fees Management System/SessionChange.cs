using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JEMS_Fees_Management_System
{
    /*
        Ordinary students refer to current students
        Other students refer to new student for next session

        OrdinaryStudentGrid refers to (any current student not in class 10) or new student for next session
        ClassTenGrid refers to current student in class 10
    */

    public partial class SessionChange : Form
    {
        List<String> sessionTransitionArray;
        List<int> sessionTransitionIndex;
        List<studentDetails> details, otherStudents, detainStudents;
        Boolean allowClassChange;
        int noOfClasses;
        Boolean debug = false;
        Boolean allowCellChange;
        Color promoteColor = Color.LightGreen;
        Color detainColor = Color.FromArgb(255, 255, 97, 97);

        int oldSession, newSession;

        public SessionChange()
        {
            InitializeComponent();
            disableControls();
            List<String> comboArray = Classes.classBranchNameArray.ToList<String>();
            noOfClasses = comboArray.Count;
            comboArray.Add("Others");
            classComboBox.DataSource = comboArray;
            allowCellChange = false;
            disableGrids();
            DataGridViewComboBoxColumn nextClass = (DataGridViewComboBoxColumn)classTenGrid.Columns[1];
            nextClass.Items.Add(Classes.getClassBranch(Classes.cl_11_CM_P));
            nextClass.Items.Add(Classes.getClassBranch(Classes.cl_11_CM_I));
            nextClass.Items.Add(Classes.getClassBranch(Classes.cl_11_SC));

        }

        private void disableControls()
        {
            allowClassChange = classComboBox.Enabled = prev.Enabled = next.Enabled =
                selectAll.Enabled = deselectAll.Enabled = confirm.Enabled = allowCellChange = false;
        }

        private void enableControls()
        {
            allowClassChange = classComboBox.Enabled =
                selectAll.Enabled = deselectAll.Enabled = confirm.Enabled = allowCellChange = true;
            if (classComboBox.SelectedIndex == 0) prev.Enabled = false;
            else prev.Enabled = true;

            if (classComboBox.SelectedIndex == classComboBox.Items.Count - 1) next.Enabled = false;
            else next.Enabled = true;

        }

        private void SessionChange_Load(object sender, EventArgs e)
        {
            sessionTransitionArray = new List<string>();
            sessionTransitionIndex = new List<int>();

            int thisYear = DateTime.Now.Year;

            //          Get all sessions that can be changed

            using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    connection.Open();
                    String getQuery = "Select * from " + Table.session_info.tableName + " order by " +
                        Table.session_info.session + " desc;";
                    int index = 0, i = 0;
                    using (SqlCommand myCommand = new SqlCommand(getQuery, connection))
                    {
                        SqlDataReader dr = myCommand.ExecuteReader();
                        while (dr.Read())
                        {

                            int session = Convert.ToInt32(dr[Table.session_info.session]);
                            sessionTransitionArray.Add("" + session + "-" + (session + 1) + " --> " +
                                (session + 1) + "-" + (session + 2));
                            sessionTransitionIndex.Add(session);
                            if (session == thisYear - 1)
                                index = i;
                            i++;
                        }
                        dr.Close();
                    }

                    sessionTransition.DataSource = sessionTransitionArray;
                    if (index < sessionTransition.Items.Count && index >= 0)
                        sessionTransition.SelectedIndex = index;

                }
                catch
                {

                }
            }
        }

        private void setupDetainForm()
        {
            allowCellChange = false;
            allowClassChange = false;
            disableControls();
            readDetainStudentDetails();
            List<String> comboArray = Classes.classBranchNameArray.ToList<String>();
            classComboBox.DataSource = comboArray;
            enableControls();
            allowCellChange = true;
            allowClassChange = true;
            classComboBox_SelectionChangeCommitted(null, null);

        }

        private void SessionChange_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.scForm = null;
            Program.mForm.enableMenuStrip();
        }

        private void sessionTransition_SelectionChangeCommitted(object sender, EventArgs e)
        {
            select.Enabled = true;
        }

        private void disableGrids()
        {
            ordinaryStudentGrid.Visible = classTenGrid.Visible = detainGrid.Visible = false;
        }

        private void classComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!allowClassChange) return;
            allowClassChange = false;

            disableControls();

            #region Promotion Students
            if (!detainGrid.Visible)
            {
                #region when class 10 is selected
                if (classComboBox.SelectedValue.ToString() == Classes.getClassBranch(Classes.cl_10))
                {
                    disableGrids();
                    classTenGrid.Visible = true;
                    for (int i = 0; i < classTenGrid.RowCount; i++)
                    {
                        if (Convert.ToBoolean(classTenGrid[0, i].Value))
                            classTenGrid.Rows[i].DefaultCellStyle.BackColor = promoteColor;
                        //else
                        //    classTenGrid.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    }

                }
                #endregion

                #region when ordinaryStudentGrid (but not new students for next session) is selected
                else if (classComboBox.SelectedIndex != classComboBox.Items.Count - 1)
                {
                    disableGrids();
                    ordinaryStudentGrid.Visible = true;

                    ordinaryStudentGrid.Rows.Clear();
                    if (classComboBox.SelectedIndex < noOfClasses)
                    {
                        foreach (studentDetails sd in details)
                        {
                            if (sd.currClass == Classes.classArray[classComboBox.SelectedIndex])
                            {
                                // if non TC deserving students are selected
                                if (sd.currClass != Classes.cl_12_CM_I && sd.currClass != Classes.cl_12_CM_P &&
                                    sd.currClass != Classes.cl_12_SC)
                                    ordinaryStudentGrid.Rows.Add(sd.selected, Classes.getClassBranch(sd.nextClass), sd.studentID, sd.name, sd.fatherName,
                                        CommonMethods.getStudentCategory(sd.studentCategory));
                                //for TC deserving students
                                else
                                    ordinaryStudentGrid.Rows.Add(sd.selected, "TC", sd.studentID, sd.name, sd.fatherName,
                                        CommonMethods.getStudentCategory(sd.studentCategory));
                                if (!sd.allowProm)
                                {
                                    ordinaryStudentGrid.Rows[ordinaryStudentGrid.RowCount - 1].ReadOnly = true;
                                    ordinaryStudentGrid.Rows[ordinaryStudentGrid.RowCount - 1].DefaultCellStyle.BackColor = SystemColors.ControlLight;
                                    ordinaryStudentGrid[6, ordinaryStudentGrid.RowCount - 1].Value = "Fees not paid";
                                }
                                else
                                {
                                    ordinaryStudentGrid[6, ordinaryStudentGrid.RowCount - 1].Value = "Eligible";
                                }

                                if (Convert.ToBoolean(ordinaryStudentGrid[0, ordinaryStudentGrid.RowCount - 1].Value))
                                    ordinaryStudentGrid.Rows[ordinaryStudentGrid.RowCount - 1].DefaultCellStyle.BackColor = promoteColor;
                                //else
                                //    ordinaryStudentGrid.Rows[ordinaryStudentGrid.RowCount - 1].DefaultCellStyle.BackColor = Color.White;


                            }
                        }
                    }
                }
                #endregion

                #region when other students are selected
                else if (classComboBox.SelectedIndex == classComboBox.Items.Count - 1)
                {
                    disableGrids();
                    ordinaryStudentGrid.Visible = true;
                    ordinaryStudentGrid.Rows.Clear();
                    foreach (studentDetails sd in otherStudents)
                    {
                        ordinaryStudentGrid.Rows.Add(true, Classes.getClassBranch(sd.nextClass), sd.studentID, sd.name, sd.fatherName,
                        CommonMethods.getStudentCategory(sd.studentCategory));
                        ordinaryStudentGrid.Rows[ordinaryStudentGrid.RowCount - 1].ReadOnly = true;
                        ordinaryStudentGrid[6, ordinaryStudentGrid.RowCount - 1].Value = "Eligible";
                        if (Convert.ToBoolean(ordinaryStudentGrid[0, ordinaryStudentGrid.RowCount - 1].Value))
                            ordinaryStudentGrid.Rows[ordinaryStudentGrid.RowCount - 1].DefaultCellStyle.BackColor = promoteColor;
                        //else
                        //    ordinaryStudentGrid.Rows[ordinaryStudentGrid.RowCount - 1].DefaultCellStyle.BackColor = Color.White;

                    }


                }
                #endregion
            }
            #endregion

            #region Detain Students
            else
            {
                detainGrid.Rows.Clear();
                foreach (studentDetails sd in detainStudents)
                {
                    if (sd.currClass == Classes.classArray[classComboBox.SelectedIndex])
                    {
                        detainGrid.Rows.Add(sd.selected, Classes.getClassBranch(sd.nextClass), sd.studentID, sd.name, sd.fatherName,
                                        CommonMethods.getStudentCategory(sd.studentCategory));
                        if (!sd.allowProm)
                        {
                            detainGrid.Rows[detainGrid.RowCount - 1].ReadOnly = true;
                            detainGrid.Rows[detainGrid.RowCount - 1].DefaultCellStyle.BackColor = SystemColors.ControlLight;
                            detainGrid[6, detainGrid.RowCount - 1].Value = "Fees not paid";
                        }
                        else
                        {
                            detainGrid[6, detainGrid.RowCount - 1].Value = "Eligible";
                        }
                        if (Convert.ToBoolean(detainGrid[0, detainGrid.RowCount - 1].Value))
                            detainGrid.Rows[detainGrid.RowCount - 1].DefaultCellStyle.BackColor = detainColor;
                        //else
                        //    detainGrid.Rows[detainGrid.RowCount - 1].DefaultCellStyle.BackColor = Color.White;

                    }

                }
            }
            #endregion

            enableControls();
            classComboBox.Select();
            allowClassChange = true;
        }

        private void confirm_Click(object sender, EventArgs e)
        {

            if (!detainGrid.Visible)
            {
                int newSession = sessionTransitionIndex[sessionTransition.SelectedIndex] + 1;
                GlobalVariables.currentSession = newSession;
                String todayDate = DateTime.Now.ToString(GlobalVariables.dateFormat);
                using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
                {
                    try
                    {
                        connection.Open();

                        #region Ordinary students

                        foreach (studentDetails sd in details)
                        {
                            if (sd.selected)
                            {
                                #region promotion
                                if (sd.nextClass != GlobalVariables.exStud)
                                {
                                    int[] orgFees = new int[3];
                                    String studCat;
                                    if (sd.studentCategory == GlobalVariables.newStud) studCat = GlobalVariables.oldStud;
                                    else studCat = sd.studentCategory;

                                    String promoteQuery = "update " + Table.student_details.tableName + " set " +
                                        Table.student_details.current_session + " = " + newSession + ", " +
                                        Table.student_details.student_category + " = '" + studCat + "', " +
                                        Table.student_details.class_n + " = '" + sd.nextClass + "' where " +
                                        Table.student_details.student_id + " = '" + sd.studentID + "'; ";
                                    using (SqlCommand myCommand = new SqlCommand(promoteQuery, connection))
                                    {
                                        myCommand.ExecuteNonQuery();
                                    }

                                    String annualGetQuery = "select * from " + Table.annual_base_struct.tableName + " where " +
                                        Table.annual_base_struct.session + " = " + newSession + " and " +
                                        Table.annual_base_struct.clss + " = '" + sd.nextClass + "';";
                                    using (SqlCommand myCommand = new SqlCommand(annualGetQuery, connection))
                                    {
                                        SqlDataReader dr = myCommand.ExecuteReader();
                                        if (dr.Read())
                                        {

                                            orgFees[0] = Convert.ToInt32(dr[Table.annual_base_struct.school_dev]);
                                            orgFees[1] = Convert.ToInt32(dr[Table.annual_base_struct.lab_dev]);
                                            orgFees[2] = Convert.ToInt32(dr[Table.annual_base_struct.caution]);

                                        }
                                        dr.Close();
                                    }

                                    String insertAnnualFeesQuery = "insert into " + Table.student_annual_fees.tableName + " (" +
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
                                            sd.studentID + "', " +
                                            newSession + ", " +
                                            orgFees[0] + ", " +
                                            orgFees[1] + ", " +
                                            orgFees[2] + ", " +
                                            "NULL, " +
                                            "NULL, '" +
                                            sd.nextClass + "', " +
                                            0 + ", " +
                                            "NULL" + ", " +
                                            0 + ");";
                                    using (SqlCommand myCommand = new SqlCommand(insertAnnualFeesQuery, connection))
                                    {
                                        myCommand.ExecuteNonQuery();
                                    }

                                    String getMQuery = "select * from " + Table.monthly_base_struct.tableName + " where " +
                                            Table.monthly_base_struct.session + " = " + newSession + " and " +
                                            Table.monthly_base_struct.clss + " = '" + sd.nextClass + "';";

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
                                            sd.studentID + "', " +
                                            newSession +
                                            ", '";

                                    String[] monthlyQuery = new String[12]{setMString,setMString,setMString,setMString,setMString,setMString,
                                                    setMString,setMString,setMString,setMString,setMString,setMString};

                                    //try
                                    //{
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
                                                sd.nextClass + "', " +
                                                "NULL, " +
                                                0 + ", " +  //concession
                                                "NULL, " +
                                                "NULL);";

                                            i++;

                                        }
                                        dr.Close();
                                    }
                                    using (SqlCommand setMCommand = new SqlCommand(monthlyQuery[0], connection))
                                    {
                                        for (int i = 0; i < 12; i++)
                                        {
                                            setMCommand.CommandText = monthlyQuery[i];
                                            setMCommand.ExecuteNonQuery();
                                        }
                                    }
                                    //}
                                    /*
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                        DialogResult dr = MessageBox.Show("Error during creation of Monthly Fees Structure, Contact Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    */
                                }
                                #endregion

                                #region Students for tc
                                else
                                {
                                    String TCQuery = "update " + Table.student_details.tableName + " set " +
                                        Table.student_details.current_session + " = " + "NULL" + ", " +
                                        Table.student_details.student_category + " = '" + GlobalVariables.exStud + "', " +
                                        Table.student_details.tc_date + " = '" + todayDate + "' " + " where " +
                                        Table.student_details.student_id + " = '" + sd.studentID + "'; ";
                                    using (SqlCommand myCommand = new SqlCommand(TCQuery, connection))
                                    {
                                        myCommand.ExecuteNonQuery();
                                    }
                                }
                                #endregion
                            }
                        }
                        #endregion

                        #region Other students
                        foreach (studentDetails sd in otherStudents)
                        {
                            String enterSessionQuery = "update " + Table.student_details.tableName + " set " +
                                        Table.student_details.current_session + " = " + newSession +
                                        " where " + Table.student_details.student_id + " = '" + sd.studentID + "'; ";
                            using (SqlCommand myCommand = new SqlCommand(enterSessionQuery, connection))
                            {
                                myCommand.ExecuteNonQuery();
                            }

                        }
                        #endregion

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("FATAL ERROR! Database is inconsitent, Please restore to last stable backup", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //MessageBox.Show(ex.Message);
                    }
                }

                disableGrids();
                detainGrid.Visible = true;
                setupDetainForm();
            }
            else
            {
                int newSession = sessionTransitionIndex[sessionTransition.SelectedIndex] + 1;
                GlobalVariables.currentSession = newSession;
                String todayDate = DateTime.Now.ToString(GlobalVariables.dateFormat);
                using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
                {
                    try
                    {
                        connection.Open();

                        #region Ordinary students

                        foreach (studentDetails sd in detainStudents)
                        {
                            if (sd.selected)
                            {
                                #region Detaining
                                if (sd.nextClass != GlobalVariables.exStud)
                                {
                                    int[] orgFees = new int[3];
                                    String studCat;
                                    if (sd.studentCategory == GlobalVariables.newStud) studCat = GlobalVariables.oldStud;
                                    else studCat = sd.studentCategory;

                                    #region student details query

                                    String promoteQuery = "update " + Table.student_details.tableName + " set " +
                                        Table.student_details.current_session + " = " + newSession + ", " +
                                        Table.student_details.student_category + " = '" + studCat + "', " +
                                        Table.student_details.class_n + " = '" + sd.nextClass + "' where " +
                                        Table.student_details.student_id + " = '" + sd.studentID + "'; ";
                                    using (SqlCommand myCommand = new SqlCommand(promoteQuery, connection))
                                    {
                                        myCommand.ExecuteNonQuery();
                                    }
                                    #endregion

                                    #region annual query 
                                    String annualGetQuery = "select * from " + Table.annual_base_struct.tableName + " where " +
                                        Table.annual_base_struct.session + " = " + newSession + " and " +
                                        Table.annual_base_struct.clss + " = '" + sd.nextClass + "';";
                                    using (SqlCommand myCommand = new SqlCommand(annualGetQuery, connection))
                                    {
                                        SqlDataReader dr = myCommand.ExecuteReader();
                                        if (dr.Read())
                                        {

                                            orgFees[0] = Convert.ToInt32(dr[Table.annual_base_struct.school_dev]);
                                            orgFees[1] = Convert.ToInt32(dr[Table.annual_base_struct.lab_dev]);
                                            orgFees[2] = Convert.ToInt32(dr[Table.annual_base_struct.caution]);

                                        }
                                        dr.Close();
                                    }

                                    String insertAnnualFeesQuery = "insert into " + Table.student_annual_fees.tableName + " (" +
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
                                            sd.studentID + "', " +
                                            newSession + ", " +
                                            orgFees[0] + ", " +
                                            orgFees[1] + ", " +
                                            orgFees[2] + ", " +
                                            "NULL, " +
                                            "NULL, '" +
                                            sd.nextClass + "', " +
                                            0 + ", " +
                                            "NULL" + ", " +
                                            0 + ");";
                                    using (SqlCommand myCommand = new SqlCommand(insertAnnualFeesQuery, connection))
                                    {
                                        myCommand.ExecuteNonQuery();
                                    }
                                    #endregion

                                    #region monthly query
                                    String getMQuery = "select * from " + Table.monthly_base_struct.tableName + " where " +
                                            Table.monthly_base_struct.session + " = " + newSession + " and " +
                                            Table.monthly_base_struct.clss + " = '" + sd.nextClass + "';";

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
                                            sd.studentID + "', " +
                                            newSession +
                                            ", '";

                                    String[] monthlyQuery = new String[12]{setMString,setMString,setMString,setMString,setMString,setMString,
                                                    setMString,setMString,setMString,setMString,setMString,setMString};

                                    //try
                                    //{
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
                                                sd.nextClass + "', " +
                                                "NULL, " +
                                                0 + ", " +  //concession
                                                "NULL, " +
                                                "NULL);";

                                            i++;

                                        }
                                        dr.Close();
                                    }
                                    using (SqlCommand setMCommand = new SqlCommand(monthlyQuery[0], connection))
                                    {
                                        for (int i = 0; i < 12; i++)
                                        {
                                            setMCommand.CommandText = monthlyQuery[i];
                                            setMCommand.ExecuteNonQuery();
                                        }
                                    }
                                    #endregion
                                    //}
                                    /*
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                        DialogResult dr = MessageBox.Show("Error during creation of Monthly Fees Structure, Contact Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    */
                                }
                                #endregion
                            }
                        }
                        #endregion

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("FATAL ERROR! Database is inconsitent, Please restore to last stable backup", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //MessageBox.Show(ex.Message);
                    }
                }

                Program.mForm.updateTitle();
                Program.mForm.executeLateFeesCalculations(true);
                Close();
            }
        }

        public String extractDatabaseName()
        {
            String name = "";
            String val = "";
            String dbName = "";
            Boolean nameVal = true;
            foreach (char c in GlobalVariables.dbConnectString)
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
                }
                if (c == ';')
                {
                    if (!nameVal)
                    {
                        name = name.ToLower();
                        switch (name)
                        {
                            case "database":
                                dbName = val;
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
            return dbName;
        }

        public Boolean createBackup()
        {
            if (GlobalVariables.thisTerminal == 1)       //Will work only for first terminal
            {
                #region missing folder
                if (GlobalVariables.backupFolder.Length == 0 || !Directory.Exists(GlobalVariables.backupFolder))   //no backup folder
                {
                    DialogResult dr = MessageBox.Show("Backup folder missing or invalid. Reset now?", "Backup Settings", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                    if (dr == DialogResult.Cancel) { return false; }
                    if (dr == DialogResult.No) { return false; }
                    if (dr == DialogResult.Yes)
                    {
                        BackupSettings bckStg = new BackupSettings();
                        bckStg.ShowDialog();
                    }
                }
                #endregion

                #region Folder created

                if (GlobalVariables.backupFolder.Trim().Substring(GlobalVariables.backupFolder.Length - 1) != "\\")
                    GlobalVariables.backupFolder += "\\";


                String year = "" + sessionTransitionIndex[sessionTransition.SelectedIndex] + "-" + (sessionTransitionIndex[sessionTransition.SelectedIndex] + 1);
                String saveString = "session_change_" + year + ".bak";

                if (!Directory.Exists(GlobalVariables.backupFolder + year + "\\"))
                {
                    Directory.CreateDirectory(GlobalVariables.backupFolder + year + "\\");
                }
                Boolean exists = false;
                if (File.Exists(GlobalVariables.backupFolder + year + "\\" + saveString))
                {
                    exists = true;
                }
                if (exists)
                {
                    int i = 1;
                    saveString = "session_change_" + year + "_" + i + ".bak";
                    while (File.Exists(GlobalVariables.backupFolder + year + "\\" + saveString))
                    {
                        saveString = "session_change_" + year + "_" + ++i + ".bak";
                    }
                }

                using (SqlConnection myConnection = new SqlConnection(GlobalVariables.dbConnectString))
                {
                    try
                    {
                        myConnection.Open();
                        String backupQuery = "backup database " + extractDatabaseName() + " to disk = '" + GlobalVariables.backupFolder + year + "\\" + saveString + "'";
                        using (SqlCommand myCommand = new SqlCommand(backupQuery, myConnection))
                        {
                            //MessageBox.Show(backupQuery);
                            myCommand.ExecuteNonQuery();
                        }
                        if (File.Exists(GlobalVariables.backupFolder + year + "\\" + saveString))
                        {
                            MessageBox.Show("Backup successful");
                        }
                        else
                        {
                            MessageBox.Show("Backup unsuccessful");
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Unable to create backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            #endregion
            return true;
        }

        private void select_Click(object sender, EventArgs e)
        {

            if (!createBackup())
            {
                MessageBox.Show("Unable to create backup, cannot continue", "Backup not created", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            oldSession = sessionTransitionIndex[sessionTransition.SelectedIndex];
            newSession = oldSession + 1;
            Boolean abort = false;
            int currentSession = GlobalVariables.currentSession;

            if (!debug)
            {
                #region Setup new session
                using (SessionConfig sConfig = new SessionConfig())
                {
                    sConfig.currentSession.Text = "" + (newSession);
                    sConfig.fixedSession = true;
                    sConfig.cancellable = false;
                    sConfig.ShowDialog();

                    if (sConfig.killParent)
                    {
                        abort = true;
                        Close();
                    }

                }
                #endregion

                #region Setup Base Fees Structure
                if (!abort)
                {
                    using (BaseFeesStructureForm bFSForm = new BaseFeesStructureForm())
                    {
                        bFSForm.session = newSession;
                        bFSForm.skipSessionSelection();
                        bFSForm.setupTitle();
                        bFSForm.ShowDialog();
                        if (!bFSForm.complete)
                        {
                            abort = true;
                            Close();
                        }
                    }
                }
                #endregion
            }

            if (abort)
            {
                GlobalVariables.currentSession = currentSession;
                using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
                {
                    try
                    {
                        connection.Open();
                        String resetQuery = "update " + Table.session_info.tableName + " set " + Table.session_info.active_session +
                            " = 'false'; update " + Table.session_info.tableName + " set " + Table.session_info.active_session +
                            " = 'true' where " + Table.session_info.session + " = " + GlobalVariables.currentSession;
                        using (SqlCommand command = new SqlCommand(resetQuery, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Unexpected Error");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }

            }
            if (!abort)
            {
                GlobalVariables.currentSession = newSession;
                Program.mForm.updateTitle();
            }
            if (!abort)
            {
                #region Load students data
                sessionTransition.Enabled = select.Enabled = false;

                readStudentDetails();       // Reads student Data
                enableControls();
                #endregion

                #region populate class 10 grid
                classTenGrid.Rows.Clear();

                foreach (studentDetails sd in details)
                {
                    if (sd.currClass == Classes.cl_10)
                    {
                        classTenGrid.Rows.Add(sd.selected, null, sd.studentID, sd.name, sd.fatherName,
                           CommonMethods.getStudentCategory(sd.studentCategory));
                        if (!sd.allowProm)
                        {
                            classTenGrid.Rows[classTenGrid.RowCount - 1].ReadOnly = true;
                            classTenGrid.Rows[classTenGrid.RowCount - 1].DefaultCellStyle.BackColor = SystemColors.ControlLight;
                            classTenGrid[6, classTenGrid.RowCount - 1].Value = "Fees not paid";
                        }
                        else
                        {
                            classTenGrid[6, classTenGrid.RowCount - 1].Value = "Eligible";
                        }

                    }
                }
                allowClassChange = true;
                classComboBox_SelectionChangeCommitted(null, null);
                #endregion

            }
        }

        private void prev_Click(object sender, EventArgs e)
        {
            if (classComboBox.SelectedIndex != 0)
                classComboBox.SelectedIndex = classComboBox.SelectedIndex - 1;
            classComboBox_SelectionChangeCommitted(null, null);
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (classComboBox.SelectedIndex != classComboBox.Items.Count - 1)
                classComboBox.SelectedIndex = classComboBox.SelectedIndex + 1;
            classComboBox_SelectionChangeCommitted(null, null);
        }

        private void ordinaryStudentGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (!allowCellChange) return;
            allowCellChange = false;
            if (classComboBox.SelectedValue.ToString() != Classes.getClassBranch(Classes.cl_10))
            {
                if (ordinaryStudentGrid.CurrentCell.OwningColumn is DataGridViewCheckBoxColumn &&
                    ordinaryStudentGrid.IsCurrentCellDirty)
                {
                    int x = ordinaryStudentGrid.CurrentCell.RowIndex;
                    ordinaryStudentGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    ordinaryStudentGrid.EndEdit();
                    ordinaryStudentGrid.CurrentCell = ordinaryStudentGrid[1, x];  // Minor glitch
                    ordinaryStudentGrid.CurrentCell = ordinaryStudentGrid[0, x];  // cell needs to leave and enter
                    updateDetails(details, ordinaryStudentGrid[2, x].Value.ToString(), Convert.ToBoolean(ordinaryStudentGrid[0, x].Value));
                    if (Convert.ToBoolean(ordinaryStudentGrid[0, x].Value))
                        ordinaryStudentGrid.Rows[x].DefaultCellStyle.BackColor = promoteColor;
                    else
                        ordinaryStudentGrid.Rows[x].DefaultCellStyle.BackColor = Color.White;

                }
            }
            ordinaryStudentGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            ordinaryStudentGrid.EndEdit();

            allowCellChange = true;
        }

        private void removeAnnual(List<studentDetails> stDetails)
        {
            List<String> toRemove = new List<string>();
            using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    connection.Open();

                    String getQuery = "select * from " + Table.student_annual_fees.tableName + " where " +
                        Table.student_annual_fees.session + " = " + oldSession + " and " +
                        Table.student_annual_fees.receipt_id + " is null " +
                        ";";
                    using (SqlCommand myCommand = new SqlCommand(getQuery, connection))
                    {
                        SqlDataReader dr = myCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            toRemove.Add(dr[Table.student_annual_fees.student_id].ToString());
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
                    connection.Close();
                }
            }

            //foreach(studentDetails stID in stDetails)
            for (int i = stDetails.Count - 1; i >= 0; i--)
            {
                studentDetails stID = stDetails[i];
                if (toRemove.Contains(stID.studentID))
                {
                    //stDetails.RemoveAt(i);

                    if (stID.studentID == "ST160079" && debug)
                        Debugger.Message("Updated in remove Annual");
                    stDetails[i].allowProm = false;
                }
            }
            for (int i = otherStudents.Count - 1; i >= 0; i--)
            {
                studentDetails stID = otherStudents[i];
                if (toRemove.Contains(stID.studentID))
                {
                    if (stID.studentID == "ST160079" && debug)
                        Debugger.Message("Removed in remove Annual");

                    otherStudents.RemoveAt(i);
                }
            }

        }

        private void checkAnnual(List<studentDetails> stDetails)
        {
            using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    connection.Open();

                    #region Ordinary Students
                    for (int i = 0; i < stDetails.Count; i++)
                    {
                        String id = stDetails[i].studentID;
                        String getQuery = "select * from " + Table.student_annual_fees.tableName + " where " +
                            Table.student_annual_fees.session + " = " + oldSession + " and " +
                            Table.student_annual_fees.student_id + " = '" + id + "' and " +
                            Table.student_annual_fees.receipt_id + " is not null " +
                            ";";
                        using (SqlCommand myCommand = new SqlCommand(getQuery, connection))
                        {
                            SqlDataReader dr = myCommand.ExecuteReader();
                            if (!dr.Read())
                            {
                                stDetails[i].allowProm = false;
                            }
                            dr.Close();
                        }
                    }
                    #endregion

                    #region New/Other Students

                    for (int i = otherStudents.Count - 1; i >= 0; i--)
                    {
                        String id = otherStudents[i].studentID;
                        String getQuery = "select * from " + Table.student_annual_fees.tableName + " where " +
                            Table.student_annual_fees.session + " = " + newSession + " and " +
                            Table.student_annual_fees.student_id + " = '" + id + "' and " +
                            Table.student_annual_fees.receipt_id + " is not null " +
                            ";";
                        using (SqlCommand myCommand = new SqlCommand(getQuery, connection))
                        {
                            SqlDataReader dr = myCommand.ExecuteReader();
                            if (!dr.Read())
                            {
                                //otherStudents[i].allowProm = false;
                                otherStudents.RemoveAt(i);
                            }
                            dr.Close();
                        }
                    }
                    #endregion
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

        }

        public void readStudentDetails()
        {
            details = new List<studentDetails>();
            otherStudents = new List<studentDetails>();

            using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    connection.Open();

                    #region Ordinary Students
                    String getQuery = "select * from " + Table.student_details.tableName + " where " +
                        Table.student_details.current_session + " = " + oldSession + " and (" +
                        Table.student_details.student_category + " = '" + GlobalVariables.newStud + "' or " +
                        Table.student_details.student_category + " = '" + GlobalVariables.manStud + "' or " +
                        Table.student_details.student_category + " = '" + GlobalVariables.oldStud + "')" +
                        //Table.student_details.student_category + " = '" + GlobalVariables.stud + "'" +
                        ";";
                    using (SqlCommand myCommand = new SqlCommand(getQuery, connection))
                    {
                        SqlDataReader dr = myCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            String name = dr[Table.student_details.first_name].ToString() + " " +
                                ((dr[Table.student_details.middle_name].ToString().Length > 0) ? (dr[Table.student_details.middle_name].ToString() + " ") : "") +
                                dr[Table.student_details.last_name].ToString();

                            if (dr[Table.student_details.student_id].ToString() == "ST160079" && debug)
                                Debugger.Message("Exists in readStudentDetails");

                            if (dr[Table.student_details.admission_session] == null ||
                                dr[Table.student_details.admission_session].ToString().Equals("")) continue;

                            if (dr[Table.student_details.student_id].ToString() == "ST160079" && debug)
                                Debugger.Message("Passed condition 1 in readStudentDetails");

                            int adSession = Int32.Parse(dr[Table.student_details.admission_session].ToString());
                            int crSession = Int32.Parse(dr[Table.student_details.current_session].ToString());
                            String studCat = dr[Table.student_details.student_category].ToString();


                            if (adSession > crSession) continue;
                            if (dr[Table.student_details.student_id].ToString() == "ST160079" && debug)
                                Debugger.Message("Passed condition 2 in readStudentDetails");
                            //REMOVING THIS CHECK BECAUSE OF PRODUCTION FAILURE
                            /*
                            if (studCat.Equals("NEW") &&
                                adSession != crSession) continue;
                            if (dr[Table.student_details.student_id].ToString() == "ST160079" && debug)
                                Debugger.Message("Passed condition 3 in readStudentDetails");
                            
                            if (studCat.Equals("OLD") &&
                                adSession >= crSession) continue;
                            if (dr[Table.student_details.student_id].ToString() == "ST160079" && debug)
                                Debugger.Message("Passed condition 4 in readStudentDetails");
                                */
                            details.Add(new studentDetails(dr[Table.student_details.student_id].ToString(),
                                name,
                                dr[Table.student_details.father_name].ToString(),
                                dr[Table.student_details.student_category].ToString(),
                                dr[Table.student_details.class_n].ToString()));


                            
                        }
                        dr.Close();
                    }



                    String checkMonthlyQuery = "";
                    /*
                    = "select * from " + Table.student_monthly_fees.tableName + " where " +
                            Table.student_monthly_fees.session + " = " + oldSession +
                            " and " + Table.student_monthly_fees.student_id + " = '" + details[details.Count - 1].studentID +
                            "' and " + Table.student_monthly_fees.receipt_id + " is null;";
                            */


                    using (SqlCommand command = new SqlCommand(checkMonthlyQuery, connection))
                    {

                        for (int i = 0; i < details.Count; i++)
                        {
                            checkMonthlyQuery = "select * from " + Table.student_monthly_fees.tableName + " where " +
                            Table.student_monthly_fees.session + " = " + oldSession +
                            " and " + Table.student_monthly_fees.student_id + " = '" + details[i].studentID +
                            "' and " + Table.student_monthly_fees.receipt_id + " is null;";
                            command.CommandText = checkMonthlyQuery;
                            SqlDataReader dr = command.ExecuteReader();
                            if (dr.Read())
                            {
                                details[i].allowProm = false;
                            }
                            else
                                details[i].allowProm = true;
                            dr.Close();
                        }
                    }
                    #endregion

                    #region Other Students
                    String getOtherQuery = "select * from " + Table.student_details.tableName + " where " +
                        Table.student_details.admission_session + " = " + newSession + " and " +
                        Table.student_details.student_category + " = '" + GlobalVariables.newStud + "' and " +
                        Table.student_details.current_session + " is NULL;";
                    using (SqlCommand command = new SqlCommand(getOtherQuery, connection))
                    {
                        SqlDataReader dr = command.ExecuteReader();
                        while (dr.Read())
                        {
                            String name = dr[Table.student_details.first_name].ToString() + " " +
                                ((dr[Table.student_details.middle_name].ToString().Length > 0) ? (dr[Table.student_details.middle_name].ToString() + " ") : "") +
                                dr[Table.student_details.last_name].ToString();

                            otherStudents.Add(new studentDetails(true, dr[Table.student_details.student_id].ToString(),
                                name,
                                dr[Table.student_details.father_name].ToString(),
                                dr[Table.student_details.student_category].ToString(),
                                dr[Table.student_details.class_n].ToString()));

                        }
                        dr.Close();

                    }
                    #endregion

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

            removeAnnual(details);
            checkAnnual(details);
        }

        public void readDetainStudentDetails()
        {
            detainStudents = new List<studentDetails>();

            using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    connection.Open();

                    #region Ordinary Students
                    String getQuery = "select * from " + Table.student_details.tableName + " where " +
                        Table.student_details.current_session + " = " + oldSession + " and (" +
                        Table.student_details.student_category + " = '" + GlobalVariables.newStud + "' or " +
                        Table.student_details.student_category + " = '" + GlobalVariables.manStud + "' or " +
                        Table.student_details.student_category + " = '" + GlobalVariables.oldStud + "')" +
                        //Table.student_details.student_category + " = '" + GlobalVariables.stud + "'" +
                        ";";
                    using (SqlCommand myCommand = new SqlCommand(getQuery, connection))
                    {
                        SqlDataReader dr = myCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            String name = dr[Table.student_details.first_name].ToString() + " " +
                                ((dr[Table.student_details.middle_name].ToString().Length > 0) ? (dr[Table.student_details.middle_name].ToString() + " ") : "") +
                                dr[Table.student_details.last_name].ToString();

                            if (dr[Table.student_details.admission_session] == null || dr[Table.student_details.admission_session].ToString().Equals("")) continue;

                            int adSession = Int32.Parse(dr[Table.student_details.admission_session].ToString());
                            int crSession = Int32.Parse(dr[Table.student_details.current_session].ToString());
                            String studCat = dr[Table.student_details.student_category].ToString();

                            
                            if (adSession > crSession) continue;
                            //REMOVING THIS CHECK BECAUSE OF PRODUCTION FAILURE
                            /*if (studCat.Equals("NEW") &&
                                adSession != crSession) continue;

                            
                            if (studCat.Equals("OLD") &&
                                adSession >= crSession) continue;
                            */
                            studentDetails temp = new studentDetails(true, dr[Table.student_details.student_id].ToString(),
                                name,
                                dr[Table.student_details.father_name].ToString(),
                                dr[Table.student_details.student_category].ToString(),
                                dr[Table.student_details.class_n].ToString());
                            temp.selected = false;
                            detainStudents.Add(temp);
                        }
                        dr.Close();
                    }



                    String checkMonthlyQuery = "";
                    /*
                    = "select * from " + Table.student_monthly_fees.tableName + " where " +
                            Table.student_monthly_fees.session + " = " + oldSession +
                            " and " + Table.student_monthly_fees.student_id + " = '" + details[details.Count - 1].studentID +
                            "' and " + Table.student_monthly_fees.receipt_id + " is null;";
                            */


                    using (SqlCommand command = new SqlCommand(checkMonthlyQuery, connection))
                    {
                        for (int i = 0; i < detainStudents.Count; i++)
                        {
                            checkMonthlyQuery = "select * from " + Table.student_monthly_fees.tableName + " where " +
                            Table.student_monthly_fees.session + " = " + oldSession +
                            " and " + Table.student_monthly_fees.student_id + " = '" + detainStudents[i].studentID +
                            "' and " + Table.student_monthly_fees.receipt_id + " is null;";
                            command.CommandText = checkMonthlyQuery;
                            SqlDataReader dr = command.ExecuteReader();
                            if (dr.Read())
                            {
                                detainStudents[i].allowProm = false;
                            }
                            else
                                detainStudents[i].allowProm = true;
                            dr.Close();
                        }
                    }
                    #endregion

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

            removeAnnual(detainStudents);
            checkAnnual(detainStudents);
        }

        private void classTenGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (!allowCellChange) return;
            allowCellChange = false;

            if (classComboBox.SelectedValue.ToString() == Classes.getClassBranch(Classes.cl_10))
            {
                if (classTenGrid.CurrentCell.OwningColumn is DataGridViewCheckBoxColumn &&
                    classTenGrid.IsCurrentCellDirty)
                {
                    int x = classTenGrid.CurrentCell.RowIndex;
                    //selected class for class 10 promotion
                    string selectedClass = Convert.ToString((classTenGrid.Rows[x].Cells[1] as DataGridViewComboBoxCell).FormattedValue.ToString());
                    if (selectedClass != "")
                    {
                        classTenGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                        classTenGrid.EndEdit();
                        classTenGrid.CurrentCell = classTenGrid[1, x];  // Minor glitch
                        classTenGrid.CurrentCell = classTenGrid[0, x];  // cell needs to leave and enter
                        updateDetails(classTenGrid[2, x].Value.ToString(), Convert.ToBoolean(classTenGrid[0, x].Value), selectedClass);
                        if (Convert.ToBoolean(classTenGrid[0, x].Value))
                            classTenGrid.Rows[x].DefaultCellStyle.BackColor = promoteColor;
                        else
                            classTenGrid.Rows[x].DefaultCellStyle.BackColor = Color.White;
                    }
                    else
                    {
                        classTenGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                        classTenGrid.EndEdit();
                        classTenGrid[0, x].Value = false;
                        classTenGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                        classTenGrid.EndEdit();
                        MessageBox.Show("Select 'Promote to' first");
                        classTenGrid.CurrentCell = classTenGrid[1, x];  // Minor glitch
                        classTenGrid.CurrentCell = classTenGrid[0, x];  // cell needs to leave and enter
                        classTenGrid.Rows[x].DefaultCellStyle.BackColor = Color.White;

                    }
                }
            }
            classTenGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            classTenGrid.EndEdit();

            allowCellChange = true;
        }

        private void selectAll_Click(object sender, EventArgs e)
        {
            if (detainGrid.Visible)
            {
                for (int i = 0; i < detainGrid.RowCount; i++)
                {
                    if (detainGrid.Rows[i].ReadOnly == false)
                    {
                        detainGrid[0, i].Value = true;
                        detainGrid.Rows[i].DefaultCellStyle.BackColor = detainColor;
                        updateDetails(detainStudents, detainGrid[2, i].Value.ToString(), Convert.ToBoolean(detainGrid[0, i].Value));
                    }
                }
            }
            if (ordinaryStudentGrid.Visible == true && classComboBox.SelectedIndex != classComboBox.Items.Count - 1)
            {
                for (int i = 0; i < ordinaryStudentGrid.RowCount; i++)
                {
                    if (ordinaryStudentGrid.Rows[i].ReadOnly == false)
                    {
                        ordinaryStudentGrid[0, i].Value = true;
                        ordinaryStudentGrid.Rows[i].DefaultCellStyle.BackColor = promoteColor;
                        updateDetails(details, ordinaryStudentGrid[2, i].Value.ToString(), Convert.ToBoolean(ordinaryStudentGrid[0, i].Value));
                    }
                }
            }
            if (classTenGrid.Visible == true)
            {
                Boolean promoteMessageShown = false;
                for (int i = 0; i < classTenGrid.RowCount; i++)
                {
                    string selectedClass = Convert.ToString((classTenGrid.Rows[i].Cells[1] as DataGridViewComboBoxCell).FormattedValue.ToString());
                    if (classTenGrid.Rows[i].ReadOnly == false)
                    {
                        if (selectedClass != "")
                        {
                            classTenGrid[0, i].Value = true;
                            classTenGrid.Rows[i].DefaultCellStyle.BackColor = detainColor;
                            updateDetails(classTenGrid[2, i].Value.ToString(), Convert.ToBoolean(classTenGrid[0, i].Value), selectedClass);
                        }
                        else
                        {
                            if (!promoteMessageShown)
                                MessageBox.Show("Select 'Promote to' first");
                            promoteMessageShown = true;
                        }
                    }
                }
            }

        }

        private void deselectAll_Click(object sender, EventArgs e)
        {
            if (detainGrid.Visible)
            {
                for (int i = 0; i < detainGrid.RowCount; i++)
                {
                    if (detainGrid.Rows[i].ReadOnly == false)
                    {
                        detainGrid[0, i].Value = false;
                        detainGrid.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        updateDetails(detainStudents, detainGrid[2, i].Value.ToString(), Convert.ToBoolean(detainGrid[0, i].Value));
                    }
                }
            }
            if (ordinaryStudentGrid.Visible == true && classComboBox.SelectedIndex != classComboBox.Items.Count - 1)
            {
                for (int i = 0; i < ordinaryStudentGrid.RowCount; i++)
                {
                    if (ordinaryStudentGrid.Rows[i].ReadOnly == false)
                    {
                        ordinaryStudentGrid[0, i].Value = false;
                        ordinaryStudentGrid.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        updateDetails(details, ordinaryStudentGrid[2, i].Value.ToString(), Convert.ToBoolean(ordinaryStudentGrid[0, i].Value));
                    }
                }
            }
            if (classTenGrid.Visible == true)
            {
                for (int i = 0; i < classTenGrid.RowCount; i++)
                {
                    if (classTenGrid.Rows[i].ReadOnly == false)
                    {
                        classTenGrid[0, i].Value = false;
                        classTenGrid.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        updateDetails(details, classTenGrid[2, i].Value.ToString(), Convert.ToBoolean(classTenGrid[0, i].Value));
                    }
                }
            }

        }

        private void detainGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (!allowCellChange) return;
            allowCellChange = false;
            if (detainGrid.CurrentCell.OwningColumn is DataGridViewCheckBoxColumn &&
                    detainGrid.IsCurrentCellDirty)
            {
                int x = detainGrid.CurrentCell.RowIndex;
                detainGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                detainGrid.EndEdit();
                detainGrid.CurrentCell = detainGrid[1, x];  // Minor glitch
                detainGrid.CurrentCell = detainGrid[0, x];  // cell needs to leave and enter
                updateDetails(detainStudents, detainGrid[2, x].Value.ToString(), Convert.ToBoolean(detainGrid[0, x].Value));
                if (Convert.ToBoolean(detainGrid[0, x].Value))   //Selected
                    detainGrid.Rows[x].DefaultCellStyle.BackColor = detainColor;
                else                                            //Deselected
                    detainGrid.Rows[x].DefaultCellStyle.BackColor = Color.White;

            }
            detainGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            detainGrid.EndEdit();

            allowCellChange = true;
        }

        private void detainGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void classTenGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ordinaryStudentGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
               
        }

        private void ordinaryStudentGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void updateDetails(String stID, Boolean selection, String nxtCls)
        {
            String nextClassCode = "";
            for (int i = 13; i < 16; i++)
            {
                if (Classes.classBranchNameArray[i] == nxtCls)
                    nextClassCode = Classes.classArray[i];
            }
            if (nextClassCode.Equals("")) MessageBox.Show("No class is selected", "Error");
            for (int i = 0; i < details.Count; i++)
            {
                if (details[i].studentID == stID && details[i].allowProm)
                {
                    details[i].selected = selection;
                    details[i].nextClass = nextClassCode;
                }

            }
        }

        public void updateDetails(List<studentDetails> details, String stID, Boolean selection)
        {
            for (int i = 0; i < details.Count; i++)
            {
                if (details[i].studentID == stID && details[i].allowProm)
                    details[i].selected = selection;
            }
        }

        public class studentDetails
        {
            public Boolean selected;
            public Boolean allowProm;   //
            public String studentID;
            public String name;
            public String fatherName;
            public String studentCategory;
            public String currClass;
            public String nextClass;    //if EXX then make ex student

            //For ordinary students
            public studentDetails(String studID, String studName, String fName, String cat, String crClass)
            {
                selected = allowProm = false;
                studentID = studID;
                name = studName;
                fatherName = fName;
                studentCategory = cat;
                currClass = crClass;
                nextClass = GlobalVariables.exStud;
                for (int i = 0; i < 16; i++)
                {
                    if (Classes.classArray[i] == crClass)
                    {
                        if (i < 12)                                 //less than 10th class
                            nextClass = Classes.classArray[i + 1];
                        else if (i > 12)
                            nextClass = Classes.classArray[i + 3];
                    }
                }

            }

            //for other students (when selection is fixed and current class = next class)
            public studentDetails(Boolean select, String studID, String studName, String fName, String cat, String crClass)
            {
                selected = allowProm = select;
                studentID = studID;
                name = studName;
                fatherName = fName;
                studentCategory = cat;
                currClass = crClass;
                nextClass = crClass;
            }
        }
    }


}
