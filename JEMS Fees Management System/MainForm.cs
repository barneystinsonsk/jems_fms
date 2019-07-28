using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

// This message is for checking changes

namespace JEMS_Fees_Management_System
{
    public partial class MainForm : Form
    {
        static public RegularAdmissionForm rAForm;
        static public ProvisionalForm pForm;
        static public ManualStudentForm oSForm;
        static public ProvisionConfirmForm pCForm;
        static public MonthlyFeesForm mtForm;
        static public DailyReportMngForm dMForm;
        static public DailyMonthlyFeesReport dMtForm;
        static public AnnualFeesForm aForm;
        static public StudentEditMonthlyFeesForm smForm;
        static public StudentEditAnnualFeesForm saForm;
        static public EditStudentDetails esForm;
        static public SessionChange scForm;
        static public StudentFeesCardForm stfc;
        static public TCForm tcForm;
        static public StudentReportForm srForm;
        static public DuesListMonthlyReport dLMForm;
        static public DuesListAnnualReport dAMForm;
        static public ReceiptForm rcForm;
        static public OtherFeesForm ofForm;
        static public OtherFeesReportForm orForm;
        static public ProvStudentReportForm psForm;
        static public PeriodicManagementForm pmForm;
        static public PeriodicMonthlyForm pmtForm;
        static public MonthlyConcessionReportForm mcForm;
        static public AnnualConcessionReportForm acForm;
        static public ClearanceReportForm crForm;
        static public TCReportForm trForm;
        static public RunSqlForm rsForm;
        static public ReceiptDateChange rdForm;
        static public StudentReport2Form sr2Form;
        static public PaidListMonthlyForm plForm;
        static public ReminderForm rmForm;
        static public ClearanceSlipForm csForm;

        static public Boolean abortSessionTransition;

        List<String> searchStudentIDS;

        List<Object> toBeHidden;

        public Boolean sideBarFull;

        Boolean allowChange = true;

        Timer timer;

        Boolean killMe = false;
        //static public SessionConfig sConfig;

        public MainForm()
        {
            InitializeComponent();

            abortSessionTransition = false;
            sideBarFull = true;
            searchStudentIDS = new List<string>();
            //GlobalVariables.title = this.Text;

            toBeHidden = new List<object>();
            toBeHidden.Add(admissionTCToolStripMenuItem);
            //toBeHidden.Add(reportsToolStripMenuItem);
            toBeHidden.Add(feeStructureToolStripMenuItem);
            toBeHidden.Add(changeMonthlyFeeStructureToolStripMenuItem);
            toBeHidden.Add(printMonthlyFeeStructureToolStripMenuItem);
            toBeHidden.Add(backupSettingsToolStripMenuItem);
            toBeHidden.Add(sessionToolStripMenuItem);
            toBeHidden.Add(periodicReportToolStripMenuItem);
            toBeHidden.Add(periodicReportToolStripMenuItem1);
            toBeHidden.Add(studentsReportToolStripMenuItem);
            toBeHidden.Add(duesLIstMonthlyToolStripMenuItem);
            toBeHidden.Add(otherFeesReportToolStripMenuItem);
            toBeHidden.Add(provisionalStudentsReportToolStripMenuItem);
            toBeHidden.Add(concessionReportToolStripMenuItem);
            toBeHidden.Add(clearanceReportToolStripMenuItem);
            toBeHidden.Add(tCReportToolStripMenuItem);
            toBeHidden.Add(otherToolStripMenuItem);
            toBeHidden.Add(deleteStudentRecordToolStripMenuItem);
            toBeHidden.Add(lateFeesToolStripMenuItem);

            collectionTable.Rows.Add("Estimated", 0, 0);
            collectionTable.Rows.Add("Collected", 0, 0);
            collectionTable.Rows.Add("Remaining", 0, 0);

            currentStudentCount.Rows.Add("New Students", 0, 0);
            currentStudentCount.Rows.Add("Provisional", 0, 0);
            currentStudentCount.Rows.Add("Total", 0, 0);

            allStudentCount.Rows.Add("Old Students", 0, 0);
            allStudentCount.Rows.Add("New Students", 0, 0);
            allStudentCount.Rows.Add("Provisional", 0, 0);
            allStudentCount.Rows.Add("Total", 0, 0);

        }

        private void mainFormLoad(object sender, EventArgs e)
        {
            // Check database Connectivity (config file)
            if (!killMe)
                checkConfigFile();
            // Check for terminal name entry in database

            if (!killMe)
                checkTerminalEntry();
            
            //Check Session info
            if (!killMe)
                checkSessionInfo();

            updateTitle();

            if (!killMe)
                checkBaseFees();
            if (!killMe)
               executeLateFeesCalculations(false);
            
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(reFind);
            timer.Start();

        }

        void reFind(object sender, EventArgs e)
        {
            timer.Stop();
            DateTime today;
            today = DateTime.Now;
            int thisMonth = today.Month;

            int effective_session = (thisMonth <= 3) ? (today.Year - 1) : (today.Year);
            thisMonth = CommonMethods.actualMonthToSessionMonth(today.Month);
            if (effective_session > GlobalVariables.currentSession) thisMonth = 13;


            using (SqlConnection myConnection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    myConnection.Open();
                    String query = @"select sum(tuition) as tt_total, sum(management) as mg_total 
from student_monthly_fees join student_details 
on student_monthly_fees.student_id = student_details.student_id and
student_monthly_fees.session = student_details.current_session
where student_category <> 'EXX' and 
( (current_session = " + effective_session + @" and dbo.sort_by_month(month) <=  " + thisMonth + @") 
  or (current_session < " + effective_session + @")
);";

                    using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                    {
                        SqlDataReader dr = myCommand.ExecuteReader();
                        if (dr.Read())
                        {

                            collectionTable[1, 0].Value = (Int32)Convert.ToDouble(dr["tt_total"].ToString());
                            collectionTable[2, 0].Value = (Int32)Convert.ToDouble(dr["mg_total"].ToString());
                            sync.Enabled = false;
                        }
                        dr.Close();
                    }
                    String query1 = @"select sum(tuition) as tt_total, sum(management) as mg_total 
from student_monthly_fees join student_details 
on student_monthly_fees.student_id = student_details.student_id and
student_monthly_fees.session = student_details.current_session
where student_category <> 'EXX' and 
( (current_session = " + effective_session + @" and dbo.sort_by_month(month) <=  " + thisMonth + @") 
  or (current_session < " + effective_session + @")
)
and student_monthly_fees.receipt_id is null;";
                    using (SqlCommand myCommand = new SqlCommand(query1, myConnection))
                    {
                        SqlDataReader dr = myCommand.ExecuteReader();
                        if (dr.Read())
                        {

                            collectionTable[1, 2].Value = (Int32)Convert.ToDouble(dr["tt_total"].ToString());
                            collectionTable[2, 2].Value = (Int32)Convert.ToDouble(dr["mg_total"].ToString());

                            collectionTable[1, 1].Value = (Int32)collectionTable[1, 0].Value - (Int32)collectionTable[1, 2].Value;
                            collectionTable[2, 1].Value = (Int32)collectionTable[2, 0].Value - (Int32)collectionTable[2, 2].Value;

                            sync.Enabled = false;
                        }
                        dr.Close();
                    }
                    String query2 = "select (select count(*) from " + Table.student_details.tableName + " where " +
                        Table.student_details.current_session + " = " + GlobalVariables.currentSession + " and " +
                        Table.student_details.student_category + " = '" + GlobalVariables.newStud + "'" + " and " +
                        Table.student_details.gender + " = " + 1 + ") as boys, " +
                        "(select count(*) from " + Table.student_details.tableName + " where " +
                        Table.student_details.current_session + " = " + GlobalVariables.currentSession + " and " +
                        Table.student_details.student_category + " = '" + GlobalVariables.newStud + "'" + " and " +
                        Table.student_details.gender + " = " + 0 + ") as girls";

                    String query3 = "select (select count(*) from " + Table.student_details.tableName + " where " +
                        Table.student_details.current_session + " = " + GlobalVariables.currentSession + " and " +
                        Table.student_details.student_category + " = '" + GlobalVariables.provStud + "'" + " and " +
                        Table.student_details.gender + " = " + 1 + ") as boys, " +
                        "(select count(*) from " + Table.student_details.tableName + " where " +
                        Table.student_details.current_session + " = " + GlobalVariables.currentSession + " and " +
                        Table.student_details.student_category + " = '" + GlobalVariables.provStud + "'" + " and " +
                        Table.student_details.gender + " = " + 0 + ") as girls";

                    String query4 = "select (select count(*) from " + Table.student_details.tableName + " where (" +
                        Table.student_details.student_category + " = '" + GlobalVariables.oldStud + "' or " +
                        Table.student_details.student_category + " = '" + GlobalVariables.manStud + "')" + "and " +
                        Table.student_details.gender + " = " + 1 + ") as boys, " +
                        "(select count(*) from " + Table.student_details.tableName + " where (" +
                        Table.student_details.student_category + " = '" + GlobalVariables.oldStud + "' or " +
                        Table.student_details.student_category + " = '" + GlobalVariables.manStud + "')" + "and " +
                        Table.student_details.gender + " = " + 0 + ") as girls";

                    String query5 = "select (select count(*) from " + Table.student_details.tableName + " where " +
                        Table.student_details.student_category + " = '" + GlobalVariables.newStud + "'" + " and " +
                        Table.student_details.gender + " = " + 1 + ") as boys, " +
                        "(select count(*) from " + Table.student_details.tableName + " where " +
                        Table.student_details.student_category + " = '" + GlobalVariables.newStud + "'" + " and " +
                        Table.student_details.gender + " = " + 0 + ") as girls";

                    String query6 = "select (select count(*) from " + Table.student_details.tableName + " where " +
                        Table.student_details.student_category + " = '" + GlobalVariables.provStud + "'" + " and " +
                        Table.student_details.gender + " = " + 1 + ") as boys, " +
                        "(select count(*) from " + Table.student_details.tableName + " where " +
                        Table.student_details.student_category + " = '" + GlobalVariables.provStud + "'" + " and " +
                        Table.student_details.gender + " = " + 0 + ") as girls";

                    int cur_new_b = 0, cur_prov_b = 0, all_old_b = 0, all_new_b = 0, all_prov_b = 0;
                    int cur_new_g = 0, cur_prov_g = 0, all_old_g = 0, all_new_g = 0, all_prov_g = 0;

                    using (SqlCommand myCommand = new SqlCommand(query2, myConnection))
                    {
                        SqlDataReader dr;
                        myCommand.CommandText = query2;
                        dr = myCommand.ExecuteReader();
                        if (dr.Read())
                        {
                            cur_new_b = Convert.ToInt32(dr["boys"].ToString());
                            cur_new_g = Convert.ToInt32(dr["girls"].ToString());
                        }
                        dr.Close();

                        myCommand.CommandText = query3;
                        dr = myCommand.ExecuteReader();
                        if (dr.Read())
                        {
                            cur_prov_b = Convert.ToInt32(dr["boys"].ToString());
                            cur_prov_g = Convert.ToInt32(dr["girls"].ToString());
                        }
                        dr.Close();

                        myCommand.CommandText = query4;
                        dr = myCommand.ExecuteReader();
                        if (dr.Read())
                        {
                            all_old_b = Convert.ToInt32(dr["boys"].ToString());
                            all_old_g = Convert.ToInt32(dr["girls"].ToString());
                        }
                        dr.Close();

                        myCommand.CommandText = query5;
                        dr = myCommand.ExecuteReader();
                        if (dr.Read())
                        {
                            all_new_b = Convert.ToInt32(dr["boys"].ToString());
                            all_new_g = Convert.ToInt32(dr["girls"].ToString());

                        }
                        dr.Close();
                        myCommand.CommandText = query6;
                        dr = myCommand.ExecuteReader();
                        if (dr.Read())
                        {
                            all_prov_b = Convert.ToInt32(dr["boys"].ToString());
                            all_prov_g = Convert.ToInt32(dr["girls"].ToString());
                        }
                        dr.Close();

                    }

                    currentStudentCount[1, 0].Value = cur_new_b;
                    currentStudentCount[2, 0].Value = cur_new_g;
                    currentStudentCount[1, 1].Value = cur_prov_b;
                    currentStudentCount[2, 1].Value = cur_prov_g;
                    currentStudentCount[1, 2].Value = cur_new_b + cur_prov_b;
                    currentStudentCount[2, 2].Value = cur_new_g + cur_prov_g;

                    allStudentCount[1, 0].Value = all_old_b;
                    allStudentCount[2, 0].Value = all_old_g;
                    allStudentCount[1, 1].Value = all_new_b;
                    allStudentCount[2, 1].Value = all_new_g;
                    allStudentCount[1, 2].Value = all_prov_b;
                    allStudentCount[2, 2].Value = all_prov_g;
                    allStudentCount[1, 3].Value = all_old_b + all_new_b + all_prov_b;
                    allStudentCount[2, 3].Value = all_old_g + all_new_g + all_prov_g;

                }
                catch (Exception ex)
                {
                    sync.Enabled = true;
                }
            }
            timer.Start();
        }

        void checkConfigFile()
        {
            GlobalVariables.dbConnectString = "";
            GlobalVariables.thisTerminal = 0;
            GlobalVariables.limitMenuItems = false;
            string configPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\setting.config";
            if (File.Exists(configPath))
                using (XmlReader reader = XmlReader.Create(configPath))
                {
                    while (reader.Read())
                    {
                        if (reader.IsStartElement())
                        {
                            switch (reader.Name)
                            {
                                case "connectionString":
                                    if (reader.Read())
                                    {
                                        GlobalVariables.dbConnectString = reader.Value.Trim();
                                    }
                                    break;
                                case "terminal":
                                    if (reader.Read())
                                    {
                                        int val = 0;
                                        Int32.TryParse(reader.Value.Trim(), out val);
                                        GlobalVariables.thisTerminal = val;
                                    }
                                    break;
                                case "backup":
                                    if (reader.Read())
                                    {
                                        GlobalVariables.backupFolder = reader.Value.Trim();
                                    }
                                    break;
                                case "limitMenuItems":
                                    if (reader.Read())
                                    {
                                        if (reader.Value.Trim().ToLower() == "true")
                                            GlobalVariables.limitMenuItems = true;
                                        else GlobalVariables.limitMenuItems = false;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            else
            {
                if (!killMe)
                {
                    DialogResult dr = MessageBox.Show("Database configuration problem encountered. Press OK to setup database configuration. (Contact Admininstrator)"
                                    , "Database Connection not Configured", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    if (dr == System.Windows.Forms.DialogResult.OK)
                        launchSetup(true);
                    else
                    {
                        killMe = true;
                        Program.kill = true;
                        this.Close();
                    }
                }
            }

            #region Limit

            limitMenuOptionsToolStripMenuItem.Checked = GlobalVariables.limitMenuItems;
            foreach (object obj in toBeHidden)
            {
                if (obj.GetType() == admissionTCToolStripMenuItem.GetType())
                {
                    ((ToolStripMenuItem)(obj)).Visible = !GlobalVariables.limitMenuItems;
                }
            }
            #endregion

            if (!Directory.Exists(GlobalVariables.backupFolder) && GlobalVariables.thisTerminal == 1)
            {
                DialogResult dr = MessageBox.Show("Setup backup folder now?", "Backup Folder not setup", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (dr == DialogResult.Yes)
                {
                    BackupSettings bckStg = new BackupSettings();
                    bckStg.ShowDialog();
                }
            }
            if (GlobalVariables.thisTerminal != 1)
            {
                backupSettingsToolStripMenuItem.Enabled = false;
            }
            if (GlobalVariables.dbConnectString == "" || GlobalVariables.thisTerminal == 0)
            {
                DialogResult dr = MessageBox.Show("Database configuration problem encountered. Press OK to setup database configuration. (Contact Admininstrator)"
                                , "Database Connection not Configured", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (dr == System.Windows.Forms.DialogResult.OK)
                    launchSetup(true);
                else
                {
                    killMe = true;
                    Program.kill = true;
                    this.Close();
                }
            }
        }

        void checkTerminalEntry()
        {
            if (!checkConnectivity())
            {
                if (!killMe)
                {
                    DialogResult dr = MessageBox.Show("Unable to connect to database. Check if database server is ON. Do you want to re-do Setup? Press 'No' to exit."
                                , "Could not connect to Database", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (dr == System.Windows.Forms.DialogResult.Yes)
                        launchSetup(true);
                    else
                    {
                        killMe = true;
                        this.Close();
                    }
                }
            }
            else
            {
                String query = "select count(*) from " + Table.terminal_names.tableName + ";";
                int count = 0;
                using (SqlConnection myConnection = new SqlConnection(GlobalVariables.dbConnectString))
                {
                    try
                    {
                        myConnection.Open();
                        using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                        {
                            count = (int)myCommand.ExecuteScalar();
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
                if (count == 0)
                {
                    if (!killMe)
                    {
                        DialogResult dr = MessageBox.Show("Setup Fees Terminals. (Contact Admininstrator)"
                                , "Fees Terminals Empty", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        if (dr == System.Windows.Forms.DialogResult.OK)
                            launchSetup(true);
                        else
                        {
                            killMe = true;
                            this.Close();
                        }
                    }
                }
            }

        }

        bool checkConnectivity()
        {

            using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {

                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                        return true;
                    else
                        return false;
                }
                catch (Exception e)
                {
                    return false;
                }
                finally
                {

                    connection.Close();
                }
            }

        }

        void checkSessionInfo()
        {

            int count = 0;
            using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    connection.Open();
                    String query = "Select count(*) from " + Table.session_info.tableName;
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        count = (int)command.ExecuteScalar();
                    }
                }
                catch (Exception)
                {
                    DialogResult dr = MessageBox.Show("Some Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (dr == System.Windows.Forms.DialogResult.OK)
                    {
                        killMe = true;
                        Close();
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
            if (count != 0)
            {
                using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
                {
                    try
                    {
                        connection.Open();
                        String query = "Select " + Table.session_info.session + " from " + Table.session_info.tableName + " where "
                                + Table.session_info.active_session + " = 1 order by " + Table.session_info.session + " desc;";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            SqlDataReader dr = command.ExecuteReader();
                            if (dr.Read())
                            {
                                GlobalVariables.currentSession = Convert.ToInt32(dr[Table.session_info.session]);
                            }
                            else
                            {
                                SessionConfig sConfig = new SessionConfig();
                                sConfig.cancellable = false;
                                sConfig.fixedSession = false;
                                sConfig.ShowDialog();
                                if (sConfig.killParent)
                                {
                                    killMe = true;
                                    Close();
                                }
                            }
                            dr.Close();

                            command.CommandText = "update " + Table.session_info.tableName + " set " + Table.session_info.active_session + " = 0 "
                                + " where " + Table.session_info.session + " <> " + GlobalVariables.currentSession;
                            command.ExecuteNonQuery();

                        }
                    }
                    catch (Exception)
                    {
                        if (!killMe)
                        {
                            DialogResult dr = MessageBox.Show("Some Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (dr == System.Windows.Forms.DialogResult.OK)
                            {
                                killMe = true;
                                Close();
                            }
                        }
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                return;
            }
            else
            {
                SessionConfig sConfig = new SessionConfig();
                sConfig.cancellable = false;
                sConfig.fixedSession = false;
                sConfig.ShowDialog();
                if (sConfig.killParent)
                {
                    killMe = true;
                    Close();
                }
            }

        }

        public void checkBaseFees()
        {
            //DialogResult dr = MessageBox.Show("Some Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //if (dr == System.Windows.Forms.DialogResult.OK)
            // {
            //     Close();
            //}

            String query1 = "select count(*) from " + Table.admission_base_struct.tableName + " where "
                + Table.monthly_base_struct.session + " = " + GlobalVariables.currentSession + ";";
            String query2 = "select count(*) from " + Table.annual_base_struct.tableName + " where "
                + Table.monthly_base_struct.session + " = " + GlobalVariables.currentSession + ";";
            String query3 = "select count(*) from " + Table.monthly_base_struct.tableName + " where "
                + Table.monthly_base_struct.session + " = " + GlobalVariables.currentSession + ";";

            int count = 0;
            using (SqlConnection myConnection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    myConnection.Open();
                    using (SqlCommand myCommand = new SqlCommand(query1, myConnection))
                    {
                        count += (int)myCommand.ExecuteScalar();

                        myCommand.CommandText = query2;
                        count += (int)myCommand.ExecuteScalar();

                        myCommand.CommandText = query3;
                        count += (int)myCommand.ExecuteScalar();

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
            if (count != ((19 * 12) + 19 + 19))
            {
                DialogResult dr = MessageBox.Show("Setup Base Fees "
                            , "Base Fees Incomplete", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    launchBaseFeesForm(true);
                }
                else
                {
                    abortSessionTransition = true;
                    killMe = true;
                    this.Close();
                }
            }

        }

        public void executeLateFeesCalculations(Boolean forced)
        {

            using (SqlConnection myConnection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    myConnection.Open();

                    DateTime lastDate, today;
                    int warnFees = -1, warnDate = -1, lateFees = -1;
                    today = DateTime.Now;
                    Boolean execute = false;
                    int thisMonth = CommonMethods.actualMonthToSessionMonth(today.Month);           //APR = 1, MAY = 2,... JAN = 10, FEB = 11, MAR = 12        

                    int effective_session = (today.Month <= 3) ? (today.Year - 1) : (today.Year);

                    if (effective_session > GlobalVariables.currentSession)
                    {
                        thisMonth = 13;
                        //Session not changed on April
                        if(MessageBox.Show("Late fees calculation will be incorrect, continue?", "Session change required", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                        {
                            return;
                        }

                    }

                    //Debugger.Message("Effec " + effective_session + " month " + thisMonth);

                    #region Reset warn fees if date is less than 10
                    String getDates = "select * from " + Table.session_info.tableName + " where " + Table.session_info.active_session +
                        " = 1";
                    String resetWarnDate = "update " + Table.session_info.tableName + " set " + Table.session_info.warn_fees_date + " = " +
                                    "( select " + Table.session_info.default_warn_fees_date + " from " + Table.session_info.tableName + " where " +
                                    Table.session_info.active_session + " = 1) where " + Table.session_info.active_session + " = 1";
                    using (SqlCommand myCommand = new SqlCommand(getDates, myConnection))
                    {
                        Boolean doIt = false;
                        SqlDataReader dr = myCommand.ExecuteReader();
                        if (dr.Read())
                        {
                            warnDate = Convert.ToInt32(dr[Table.session_info.warn_fees_date]);
                            int defaultDate = Convert.ToInt32(dr[Table.session_info.default_warn_fees_date]);
                            if (warnDate != defaultDate) doIt = true;
                        }
                        else
                        {
                            MessageBox.Show("empty");
                        }
                        dr.Close();
                        if (doIt && today.Day < 10)
                        {
                            forced = true;
                            myCommand.CommandText = resetWarnDate;
                            myCommand.ExecuteNonQuery();
                        }

                    }

                    #endregion

                    #region get parameters

                    String getDateQuery = "select * from " +
                        Table.session_info.tableName + " where " + Table.session_info.active_session + " = 1 ";
                    using (SqlCommand myCommand = new SqlCommand(getDateQuery, myConnection))
                    {
                        SqlDataReader dr;
                        dr = myCommand.ExecuteReader();
                        if (dr.Read())
                        {
                            warnDate = Convert.ToInt32(dr[Table.session_info.warn_fees_date]);
                            GlobalVariables.warnDate = warnDate;
                            warnFees = Convert.ToInt32(dr[Table.session_info.warn_fees]);
                            lateFees = Convert.ToInt32(dr[Table.session_info.late_fees]);
                            if (dr[Table.session_info.last_late_cal] != DBNull.Value)
                            {
                                DateTime.TryParse(dr[Table.session_info.last_late_cal].ToString(), out lastDate);
                                if (lastDate.Date != today.Date)
                                {
                                    execute = true;
                                }
                                else
                                {
                                    execute = false;
                                }
                                if (forced)
                                {
                                    execute = true;
                                }
                            }
                            else
                                execute = true;
                        }
                        else
                        {
                            execute = true;
                        }

                        dr.Close();
                    }

                    #endregion

                    #region Calculate Late Fees
                    if (execute)
                    {
                        if (warnDate == -1 || warnFees == -1 || lateFees == -1)
                        {
                            MessageBox.Show("Unable to calculate late fees, check session configuration");
                        }
                        else
                        {

                            /*
                            String calLateFees = "update " + Table.student_monthly_fees.tableName + " set " +
                            Table.session_info.late_fees + " = " + " dbo.lateFeesCal(" +
                            today.Day + ", " + ((today.Month + 8) % 12 + 1) + ", " + Table.student_monthly_fees.month +
                            ", " + warnFees + ", " + lateFees + ", " + warnDate + ") " + "where session = " +
                            GlobalVariables.currentSession + " and " + Table.student_monthly_fees.receipt_id + " is null and " +
                            Table.student_monthly_fees.student_id + " not in (select " + Table.student_details.student_id  + " from " +
                            Table.student_details.tableName + " where " + 
                            Table.student_details.student_category + " = '" + GlobalVariables.exStud + "') ";
                            */

                            #region Queries

                            #region Current Effective Session
                            String currPrevMonthLateFees = "update " + Table.student_monthly_fees.tableName + " set " +
                                Table.student_monthly_fees.late_fees + " = " + lateFees + " where " +
                                Table.student_monthly_fees.session + " = " + effective_session + " and " +
                                Table.student_monthly_fees.receipt_id + " is null and " +
                                GlobalVariables.sort_by_month + "(" + Table.student_monthly_fees.month + ") < " + thisMonth + " and " +
                                //update for v2.2.1 start
                                Table.student_monthly_fees.month + "not in ('MAY', 'JUN') " + 
                                //update for v2.2.1 end
                                Table.student_monthly_fees.student_id + " not in (select " + Table.student_details.student_id + " from " +
                                Table.student_details.tableName + " where " +
                                Table.student_details.student_category + " = '" + GlobalVariables.exStud + "') ";

                            String currthisMonthWarnFees = "update " + Table.student_monthly_fees.tableName + " set " +
                                Table.student_monthly_fees.late_fees + " = " + warnFees + " where " +
                                Table.student_monthly_fees.session + " = " + effective_session + " and " +
                                Table.student_monthly_fees.receipt_id + " is null and " +
                                GlobalVariables.sort_by_month + "(" + Table.student_monthly_fees.month + ") = " + thisMonth + " and " +
                                //update for v2.2.1 start
                                Table.student_monthly_fees.month + "not in ('MAY', 'JUN') " +
                                //update for v2.2.1 end
                                Table.student_monthly_fees.student_id + " not in (select " + Table.student_details.student_id + " from " +
                                Table.student_details.tableName + " where " +
                                Table.student_details.student_category + " = '" + GlobalVariables.exStud + "') ";

                            String currthisMonthNoFees = "update " + Table.student_monthly_fees.tableName + " set " +
                                Table.student_monthly_fees.late_fees + " = " + 0 + " where " +
                                Table.student_monthly_fees.session + " = " + effective_session + " and " +
                                Table.student_monthly_fees.receipt_id + " is null and " +
                                GlobalVariables.sort_by_month + "(" + Table.student_monthly_fees.month + ") = " + thisMonth + " and " +
                                Table.student_monthly_fees.student_id + " not in (select " + Table.student_details.student_id + " from " +
                                Table.student_details.tableName + " where " +
                                Table.student_details.student_category + " = '" + GlobalVariables.exStud + "') ";

                            String currNextMonthNoFees = "update " + Table.student_monthly_fees.tableName + " set " +
                                Table.student_monthly_fees.late_fees + " = " + 0 + " where " +
                                Table.student_monthly_fees.session + " = " + effective_session + " and " +
                                Table.student_monthly_fees.receipt_id + " is null and " +
                                GlobalVariables.sort_by_month + "(" + Table.student_monthly_fees.month + ") > " + thisMonth + " and " +
                                Table.student_monthly_fees.student_id + " not in (select " + Table.student_details.student_id + " from " +
                                Table.student_details.tableName + " where " +
                                Table.student_details.student_category + " = '" + GlobalVariables.exStud + "') ";

                            //RUN THIS QUERY LAST
                            String currBeforeMonth = "update " + Table.student_monthly_fees.tableName + " set " +
                                Table.student_monthly_fees.late_fees + " = " + 0 + " where " +
                                Table.student_monthly_fees.session + " = " + effective_session + " and " +
                                Table.student_monthly_fees.receipt_id + " is null and " + thisMonth + " < " +
                                // CHANGE MONTH HERE
                                GlobalVariables.sort_by_month + "('APR')" + " and " +
                                Table.student_monthly_fees.student_id + " not in (select " + Table.student_details.student_id + " from " +
                                Table.student_details.tableName + " where " +
                                Table.student_details.student_category + " = '" + GlobalVariables.exStud + "') ";

                            #endregion

                            #region Other types
                            String calOldFees = "update " + Table.student_monthly_fees.tableName + " set " +
                                Table.student_monthly_fees.late_fees + " = " + lateFees + " where " +
                                Table.student_monthly_fees.session + " < " + effective_session + " and " +
                                Table.student_monthly_fees.receipt_id + " is null and " +
                                Table.student_monthly_fees.student_id + " not in (select " + Table.student_details.student_id + " from " +
                                Table.student_details.tableName + " where " +
                                Table.student_details.student_category + " = '" + GlobalVariables.exStud + "') ";

                            String calFutureFees = "update " + Table.student_monthly_fees.tableName + " set " +
                                Table.student_monthly_fees.late_fees + " = " + 0 + " where " +
                                Table.student_monthly_fees.session + " > " + effective_session + " and " +
                                Table.student_monthly_fees.receipt_id + " is null and " +
                                Table.student_monthly_fees.student_id + " not in (select " + Table.student_details.student_id + " from " +
                                Table.student_details.tableName + " where " +
                                Table.student_details.student_category + " = '" + GlobalVariables.exStud + "') ";

                            String tuitionFeesZero = "update " + Table.student_monthly_fees.tableName + " set " +
                                Table.student_monthly_fees.late_fees + " = " + 0 + " where " +
                                Table.student_monthly_fees.tuition + " = " + 0 + " and " +
                                Table.student_monthly_fees.receipt_id + " is null and " +
                                Table.student_monthly_fees.student_id + " not in (select " + Table.student_details.student_id + " from " +
                                Table.student_details.tableName + " where " +
                                Table.student_details.student_category + " = '" + GlobalVariables.exStud + "') ";

                            String todayString = DateTime.Now.ToString(GlobalVariables.dateFormat);
                            String updateLastCalDate = "update " + Table.session_info.tableName + " set " +
                                Table.session_info.last_late_cal + " = '" + todayString + "' where " +
                                Table.session_info.active_session + " = 1;";
                            #endregion

                            #endregion

                            using (SqlCommand myCommand = new SqlCommand(currPrevMonthLateFees, myConnection))
                            {
                                myCommand.CommandText = currPrevMonthLateFees;
                                myCommand.ExecuteNonQuery();

                                myCommand.CommandText = currNextMonthNoFees;
                                myCommand.ExecuteNonQuery();

                                if (today.Day > warnDate)
                                    myCommand.CommandText = currthisMonthWarnFees;
                                else myCommand.CommandText = currthisMonthNoFees;

                                myCommand.ExecuteNonQuery();
                            }

                            using (SqlCommand myCommand = new SqlCommand(calOldFees, myConnection))
                            {
                                myCommand.ExecuteNonQuery();

                                myCommand.CommandText = calFutureFees;
                                myCommand.ExecuteNonQuery();
                            }

                            using (SqlCommand myCommand = new SqlCommand(tuitionFeesZero, myConnection))
                            {
                                myCommand.ExecuteNonQuery();
                            }
                            /*
                            using (SqlCommand myCommand = new SqlCommand(calLateFees, myConnection))
                            {
                                myCommand.ExecuteNonQuery();
                            }
                            */
                            using (SqlCommand myCommand = new SqlCommand(currBeforeMonth, myConnection))
                            {
                                //OMITING THE AUGUST QUERY, FEES WILL BE CALCULATED FROM APRIL 
                                myCommand.ExecuteNonQuery();
                            }
                            using (SqlCommand myCommand = new SqlCommand(updateLastCalDate, myConnection))
                            {
                                myCommand.ExecuteNonQuery();
                            }

                            MessageBox.Show("Late Fees Updated");
                        }
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to calculate late fees, Please check connection " + ex.Message);
                }
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

        void launchSetup(bool killParent)
        {
            using (SetUp setUp = new SetUp())
            {
                setUp.ShowDialog();
                if (!setUp.AllSet && killParent)
                {
                    killMe = true;
                    Close();
                }
                checkSessionInfo();
                updateTitle();
                checkBaseFees();
                executeLateFeesCalculations(true);
            }
        }

        public void launchBaseFeesForm(bool killParent)
        {
            using (BaseFeesStructureForm bFSForm = new BaseFeesStructureForm())
            {
                bFSForm.ShowDialog();
                if (!bFSForm.complete && killParent)
                {
                    abortSessionTransition = true;
                    killMe = true;
                    Close();
                }
            }
        }

        private void regularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rAForm == null)
            {
                rAForm = new RegularAdmissionForm();
                rAForm.MdiParent = this;
                rAForm.WindowState = FormWindowState.Maximized;
                rAForm.Show();
            }
            rAForm.BringToFront();
        }

        private void provisionalToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (pForm == null)
            {
                pForm = new ProvisionalForm();
                pForm.MdiParent = this;
                pForm.WindowState = FormWindowState.Maximized;
                pForm.Show();
            }
            pForm.BringToFront();

        }

        public void oldStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (oSForm == null)
            {
                oSForm = new ManualStudentForm();
                oSForm.MdiParent = this;
                oSForm.WindowState = FormWindowState.Maximized;
                oSForm.Show();
            }
            oSForm.BringToFront();

        }

        private void provisionalConfirmToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (pCForm == null)
            {
                pCForm = new ProvisionConfirmForm();
                pCForm.MdiParent = this;
                pCForm.WindowState = FormWindowState.Maximized;
                pCForm.Show();
            }
            pCForm.BringToFront();

        }

        private void monthlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mtForm == null)
            {
                mtForm = new MonthlyFeesForm();
                mtForm.MdiParent = this;
                mtForm.WindowState = FormWindowState.Maximized;
                mtForm.Show();
            }
            mtForm.BringToFront();
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void admissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            launchBaseFeesForm(false);
        }

        private Boolean allFormClosed()
        {
            if (rAForm != null || pForm != null || oSForm != null || pCForm != null ||
                mtForm != null || dMForm != null || dMtForm != null || aForm != null ||
                smForm != null || saForm != null || esForm != null || scForm != null)
                return false;

            /*
            
        static public SessionChange scForm;
            */
            return true;
        }

        private void sessionConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SessionConfig sConfig = new SessionConfig();
            sConfig.cancellable = true;
            sConfig.fixedSession = true;
            sConfig.ShowDialog();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dailyReportManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dailyReportMonthlyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void annualToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (aForm == null)
            {
                aForm = new AnnualFeesForm();
                aForm.MdiParent = this;
                aForm.WindowState = FormWindowState.Maximized;
                aForm.Show();
            }
            aForm.BringToFront();
        }

        private void annualFeeStructureToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void monthlyFeeStructureToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (esForm == null)
            {
                esForm = new EditStudentDetails();
                esForm.MdiParent = this;
                esForm.WindowState = FormWindowState.Maximized;
                esForm.Show();
            }
            esForm.BringToFront();
        }

        private void feeStructureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saForm == null)
            {
                saForm = new StudentEditAnnualFeesForm();
                saForm.MdiParent = this;
                saForm.WindowState = FormWindowState.Maximized;
                saForm.Show();
            }
            saForm.BringToFront();
        }

        private void changeMonthlyFeeStructureToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (smForm == null)
            {
                smForm = new StudentEditMonthlyFeesForm();
                smForm.MdiParent = this;
                smForm.WindowState = FormWindowState.Maximized;
                smForm.Show();
            }
            smForm.BringToFront();
        }

        public void printMonthlyFeeStructureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (stfc == null)
            {
                stfc = new StudentFeesCardForm();
                stfc.WindowState = FormWindowState.Maximized;
                stfc.MdiParent = this;
                stfc.Show();
            }
            stfc.BringToFront();

        }


        private void sessionChaneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!allFormClosed())
                MessageBox.Show("All forms need to be closed before starting session transition", "Form(s) open", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            else
            {



                disableMenuStrip();
                if (scForm == null)
                {
                    scForm = new SessionChange();
                    scForm.MdiParent = this;
                    scForm.WindowState = FormWindowState.Maximized;
                    scForm.Show();
                }
                scForm.BringToFront();
            }
        }

        /*
        private void sessionChaneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!allFormClosed())
                MessageBox.Show("All forms need to be closed before starting session transition", "Form(s) open", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            else
            {
                int session = -1;
                int thisYear = DateTime.Now.Year;
                Boolean multiSessions = false;
                abortSessionTransition = false;
                Boolean createSession = false;
                using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
                {
                    try
                    {
                        connection.Open();
                        String getQuery = "Select top 1 * from " + Table.session_info.tableName + " order by " +
                            Table.session_info.session + " desc;";
                        using (SqlCommand myCommand = new SqlCommand(getQuery, connection))
                        {
                            SqlDataReader dr = myCommand.ExecuteReader();
                            while (dr.Read())
                            {
                                if (session == -1)
                                    session = Convert.ToInt32(dr[Table.session_info.session]);
                                else
                                    multiSessions = true;
                            }
                            dr.Close();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Unkown Error", "Error");
                    }

                    if (session == -1)
                    {
                        MessageBox.Show("Missing Session. Program will now close", "Error");
                        Close();
                    }
                    if (session < thisYear)
                    {
                        DialogResult dgr = MessageBox.Show("Create new Session: " + (session + 1) +
                            "-" + (session + 2),
                            "New Session", MessageBoxButtons.YesNoCancel);
                        if (dgr == DialogResult.Cancel)
                        {

                            abortSessionTransition = true;
                        }
                        else if (dgr == DialogResult.No)
                        {
                            if (!multiSessions)
                            {
                                MessageBox.Show("New session needs to be created to start transition", "No new session");
                                abortSessionTransition = true;
                            }
                        }
                        else if (dgr == DialogResult.Yes)
                        {
                            createSession = true;
                        }
                    }

                    if (createSession)
                    {
                        SessionConfig sConfig = new SessionConfig();
                        sConfig.currentSession.Text = "" + (session + 1);
                        sConfig.fixedSession = true;
                        sConfig.cancellable = false;
                        sConfig.ShowDialog();

                        updateTitle();

                        if (sConfig.killParent)
                        {
                            if (!multiSessions)
                            {
                                MessageBox.Show("New session needs to be created to start transition", "No new session");
                                abortSessionTransition = true;
                            }
                        }
                        else
                        {
                            checkBaseFees();
                        }
                    }

                    if (!abortSessionTransition)
                    {
                        disableMenuStrip();
                        if (scForm == null)
                        {
                            scForm = new SessionChange();
                            scForm.MdiParent = this;
                            scForm.WindowState = FormWindowState.Maximized;
                            scForm.Show();
                        }
                        scForm.BringToFront();
                    }
                    
                }
            }
        }
        */

        public void updateTitle()
        {
            String newTitleAppend = " [Session: " + GlobalVariables.currentSession + "-" + (GlobalVariables.currentSession + 1) + "]";

            if (GlobalVariables.currentSession > 2014 && GlobalVariables.currentSession < 2051)
                this.Text = GlobalVariables.title + newTitleAppend;

        }

        public void enableMenuStrip()
        {
            for (int i = 0; i < menuStrip1.Items.Count; i++)
                menuStrip1.Items[i].Enabled = true;
        }

        public void disableMenuStrip()
        {
            for (int i = 0; i < menuStrip1.Items.Count; i++)
                menuStrip1.Items[i].Enabled = false;
        }

        private void tCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tcForm == null)
            {
                tcForm = new TCForm();
                tcForm.MdiParent = this;
                tcForm.WindowState = FormWindowState.Maximized;
                tcForm.Show();
            }
            tcForm.BringToFront();
        }

        private void studentsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void duesLIstMonthlyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void duesListAnnualToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void receiptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rcForm == null)
            {
                rcForm = new ReceiptForm();
                rcForm.MdiParent = this;
                rcForm.WindowState = FormWindowState.Maximized;
                rcForm.Show();
            }
            rcForm.BringToFront();
        }

        private void otherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofForm == null)
            {
                ofForm = new OtherFeesForm();
                ofForm.MdiParent = this;
                ofForm.WindowState = FormWindowState.Maximized;
                ofForm.Show();
            }
            ofForm.BringToFront();
        }

        private void otherFeesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (orForm == null)
            {
                orForm = new OtherFeesReportForm();
                orForm.MdiParent = this;
                orForm.WindowState = FormWindowState.Maximized;
                orForm.Show();
            }
            orForm.BringToFront();
        }

        private void recalculateLateFeesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            executeLateFeesCalculations(true);
        }

        private void changeWarnDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            if (date.Day < 10)
            {
                MessageBox.Show("Warn Fees Date cannot be changed before 10th");
                return;
            }
            WarnFeesForm wFDialog = new WarnFeesForm();
            wFDialog.ShowDialog();
            executeLateFeesCalculations(true);
        }

        private void setupConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!allFormClosed())
                MessageBox.Show("All forms need to be closed before changing settings", "Form(s) open", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            else
            {
                launchSetup(false);
            }
        }

        private void backupSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackupSettings bckStg = new BackupSettings();
            bckStg.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GlobalVariables.thisTerminal == 1)       //Will work only for first terminal
            {
                #region missing folder
                if (GlobalVariables.backupFolder.Length == 0 || !Directory.Exists(GlobalVariables.backupFolder))   //no backup folder
                {
                    DialogResult dr = MessageBox.Show("Backup folder missing or invalid. Reset now?", "Backup Settings", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                    if (dr == DialogResult.Cancel) { e.Cancel = true; return; }
                    if (dr == DialogResult.No) { return; }
                    if (dr == DialogResult.Yes)
                    {
                        e.Cancel = true;
                        BackupSettings bckStg = new BackupSettings();
                        bckStg.ShowDialog();
                        return;
                    }
                }
                #endregion

                #region Folder created
                else
                {
                    if (GlobalVariables.backupFolder.Trim().Substring(GlobalVariables.backupFolder.Length - 1) != "\\")
                        GlobalVariables.backupFolder += "\\";

                    String year = "" + DateTime.Now.Year;
                    String month = GlobalVariables.months[(DateTime.Now.Month + 8) % 12];
                    String saveString = "" + DateTime.Now.Day + "-" + GlobalVariables.db_months[(DateTime.Now.Month + 8) % 12] +
                                        "-" + DateTime.Now.Year + ".bak";

                    if (!Directory.Exists(GlobalVariables.backupFolder + year + "\\"))
                    {
                        Directory.CreateDirectory(GlobalVariables.backupFolder + year + "\\");
                    }
                    if (!Directory.Exists(GlobalVariables.backupFolder + year + "\\" + month + "\\"))
                    {
                        Directory.CreateDirectory(GlobalVariables.backupFolder + year + "\\" + month + "\\");
                    }
                    if (File.Exists(GlobalVariables.backupFolder + year + "\\" + month + "\\" + saveString))
                    {
                        //DialogResult dr = MessageBox.Show("Backup already made today, overwrite?", "Backup Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        //if (dr == DialogResult.Yes)
                        {
                            try
                            {
                                File.Delete(GlobalVariables.backupFolder + year + "\\" + month + "\\" + saveString);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Unable to overwrite backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        //else
                        //{
                        //    return;
                        //}
                    }

                    using (SqlConnection myConnection = new SqlConnection(GlobalVariables.dbConnectString))
                    {
                        try
                        {
                            myConnection.Open();
                            String backupQuery = "backup database " + extractDatabaseName() + " to disk = '" + GlobalVariables.backupFolder + year + "\\" + month + "\\" + saveString + "'";
                            using (SqlCommand myCommand = new SqlCommand(backupQuery, myConnection))
                            {
                                //MessageBox.Show(backupQuery);
                                myCommand.ExecuteNonQuery();
                            }
                            if (File.Exists(GlobalVariables.backupFolder + year + "\\" + month + "\\" + saveString))
                            {
                                MessageBox.Show("Backup successfull");
                            }
                            else
                            {
                                MessageBox.Show("Backup unsuccessfull");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Unable to create backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                #endregion
            }

        }

        private void sideBarResize_Click(object sender, EventArgs e)
        {
            if (sideBarFull)
            {
                sideBarResize.Text = "<<";
                sideBarResize.Location = new Point(sideBarResize.Location.X + 200 - 45, sideBarResize.Location.Y);
                sideBar.Width = 45;
                sideBarFull = false;
                sideBarPanel.Visible = false;
            }
            else
            {
                sideBarResize.Text = ">>";
                sideBarResize.Location = new Point(sideBarResize.Location.X - 200 + 45, sideBarResize.Location.Y);
                sideBar.Width = 200;
                sideBarFull = true;
                sideBarPanel.Visible = true;
            }
        }

        public List<String> formatedObjects()
        {
            Boolean twice = false;
            String text = "";
            foreach (char c in searchBox.Text.Trim().ToLower())
            {
                if ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9'))
                {
                    text += c;
                    twice = false;
                }
                if (c == ' ' && !twice)
                {
                    text += c;
                    twice = true;
                }
            }
            if (text.Length < 3) return null;

            List<String> objects = new List<string>();
            int i = 0;
            Boolean first = true;
            foreach (char c in text)
            {
                if (c != ' ')
                {
                    if (first)
                    {
                        objects.Add("" + c);
                        first = false;
                    }
                    else
                    {
                        objects[i] += c;
                    }
                }
                else
                {
                    first = true;
                    i++;
                }
            }
            for (int j = 0; j < objects.Count;)
            {
                if (objects[j].Length < 3)
                {
                    objects.RemoveAt(j);
                }
                else j++;
            }
            if (objects.Count < 1) return null;
            else return objects;
        }

        private void searchBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!allowChange) return;
            allowChange = false;

            if (searchBox.SelectedIndex < 0 || 
                searchBox.SelectedIndex > searchStudentIDS.Capacity - 1)        //if selected is more than list size
            {
                allowChange = true;
                return;
            }
            String studentID = "";
            try
            {
                studentID = searchStudentIDS[searchBox.SelectedIndex];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + searchStudentIDS.Capacity + "   " + searchBox.SelectedIndex);
                //MessageBox.Show("" + searchStudentIDS.Capacity + "   " + searchBox.SelectedIndex);
                return;
            }

            if (searchBox.SelectedIndex == 0)
            {
                allowChange = true;
                return;
            }
            if (esForm == null)
            {
                esForm = new EditStudentDetails();
                esForm.MdiParent = this;
                esForm.WindowState = FormWindowState.Maximized;
                esForm.Show();
            }
            esForm.BringToFront();
            esForm.studID.Text = studentID;

            allowChange = true;
        }

        private void receiptBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void sync_Click(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Start();
        }

        private void dailyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dMForm == null)
            {
                dMForm = new DailyReportMngForm();
                dMForm.MdiParent = this;
                dMForm.WindowState = FormWindowState.Maximized;
                dMForm.Show();
            }
            dMForm.BringToFront();
        }

        private void dailyReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dMtForm == null)
            {
                dMtForm = new DailyMonthlyFeesReport();
                dMtForm.MdiParent = this;
                dMtForm.WindowState = FormWindowState.Maximized;
                dMtForm.Show();
            }
            dMtForm.BringToFront();
        }

        private void periodicReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pmForm == null)
            {
                pmForm = new PeriodicManagementForm();
                pmForm.MdiParent = this;
                pmForm.WindowState = FormWindowState.Maximized;
                pmForm.Show();
            }
            pmForm.BringToFront();
        }

        private void provisionalStudentsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (psForm == null)
            {
                psForm = new ProvStudentReportForm();
                psForm.MdiParent = this;
                psForm.WindowState = FormWindowState.Maximized;
                psForm.Show();
            }
            psForm.BringToFront();
        }

        private void periodicReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pmtForm == null)
            {
                pmtForm = new PeriodicMonthlyForm();
                pmtForm.MdiParent = this;
                pmtForm.WindowState = FormWindowState.Maximized;
                pmtForm.Show();
            }
            pmtForm.BringToFront();
        }

        private void concessionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void annualConcessionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (acForm == null)
            {
                acForm = new AnnualConcessionReportForm();
                acForm.MdiParent = this;
                acForm.WindowState = FormWindowState.Maximized;
                acForm.Show();
            }
            acForm.BringToFront();
        }

        private void monthlyConcessionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mcForm == null)
            {
                mcForm = new MonthlyConcessionReportForm();
                mcForm.MdiParent = this;
                mcForm.WindowState = FormWindowState.Maximized;
                mcForm.Show();
            }
            mcForm.BringToFront();
        }

        private void clearanceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (crForm == null)
            {
                crForm = new ClearanceReportForm();
                crForm.MdiParent = this;
                crForm.WindowState = FormWindowState.Maximized;
                crForm.Show();
            }
            crForm.BringToFront();
        }

        private void tCReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trForm == null)
            {
                trForm = new TCReportForm();
                trForm.MdiParent = this;
                trForm.WindowState = FormWindowState.Maximized;
                trForm.Show();
            }
            trForm.BringToFront();
        }

        private void limitMenuOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!limitMenuOptionsToolStripMenuItem.Checked)
            {
                using (PasswordBox pBox = new PasswordBox())
                {
                    pBox.ShowDialog();
                    if (!pBox.passwordCorrect)
                    {
                        limitMenuOptionsToolStripMenuItem.Checked = true;
                        return;
                    }
                }
            }

            foreach (object obj in toBeHidden)
            {
                if (obj.GetType() == admissionTCToolStripMenuItem.GetType())
                {
                    GlobalVariables.limitMenuItems = limitMenuOptionsToolStripMenuItem.Checked;
                    ((ToolStripMenuItem)(obj)).Visible = !GlobalVariables.limitMenuItems;
                }
            }
            string configPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\setting.config";
            using (FileStream fileStream = new FileStream(configPath, FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fileStream))
            using (XmlTextWriter writer = new XmlTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 4;
                writer.WriteStartDocument();
                writer.WriteStartElement("settings");
                writer.WriteElementString("connectionString", GlobalVariables.dbConnectString);
                writer.WriteElementString("terminal", GlobalVariables.thisTerminal.ToString());
                writer.WriteElementString("backup", GlobalVariables.backupFolder);
                writer.WriteElementString("limitMenuItems", (GlobalVariables.limitMenuItems) ? "true" : "false");
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private void deleteStudentRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PasswordBox pBox = new PasswordBox())
            {
                pBox.ShowDialog();
                if (!pBox.passwordCorrect)
                {
                    return;
                }
            }
            DeleteStudent ds = new DeleteStudent();
            ds.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            if (!searchBox.Focused) return;
            searchBox_KeyPressed(sender, null);
        }

        private void searchBox_KeyPressed(object sender, KeyPressEventArgs e)
        {
            if (!searchBox.Focused) return;
            if (!allowChange) return;
            allowChange = false;

            if (searchBox.Text.Length < 3)
            {
                allowChange = true;
                return;
            }

            String text = searchBox.Text;

            List<String> objects = formatedObjects();
            if (objects == null)
            {
                allowChange = true;
                return;
            }
            if (objects.Count == 0)
            {
                allowChange = true;
                return;
            }
            String query = "select * from " + Table.student_details.tableName + " where ";
            Boolean first = true;
            foreach (String obj in objects)
            {
                if (!first)
                {
                    query += " and ";
                }
                first = false;
                query += "(" + Table.student_details.first_name + " like '%" + obj + "%' or " +
                                Table.student_details.middle_name + " like '%" + obj + "%' or " +
                                Table.student_details.last_name + " like '%" + obj + "%') ";
            }
            searchBox.DataSource = null;
            List<String> searchBoxDataSource = new List<string>();
            searchStudentIDS = new List<string>();
            searchStudentIDS.Add("");
            searchBoxDataSource.Add(searchBox.Text);
            try
            {
                using (SqlConnection myConnection = new SqlConnection(GlobalVariables.dbConnectString))
                {
                    myConnection.Open();

                    using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                    {
                        SqlDataReader dr = myCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            searchBoxDataSource.Add(dr[Table.student_details.first_name].ToString() + " " +
                                dr[Table.student_details.middle_name].ToString() + " " +
                                dr[Table.student_details.last_name].ToString() + ", " +
                                Classes.getClassBranch(dr[Table.student_details.class_n].ToString()));
                            searchStudentIDS.Add(dr[Table.student_details.student_id].ToString());

                        }
                        if (searchBoxDataSource.Count > 0)
                        {
                            searchBox.DataSource = searchBoxDataSource;
                            searchBox.DroppedDown = true;
                            Cursor.Current = Cursors.Default;
                            searchBox.Text = text;
                            searchBox.SelectionStart = text.Length;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            allowChange = true;
        }

        private void runSqlQueryAdvancedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rsForm == null)
            {
                rsForm = new RunSqlForm();
                rsForm.MdiParent = this;
                rsForm.WindowState = FormWindowState.Maximized;
                rsForm.Show();
            }
            rsForm.BringToFront();
        }

        private void receiptDateChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rdForm == null)
            {
                rdForm = new ReceiptDateChange();
                rdForm.MdiParent = this;
                rdForm.WindowState = FormWindowState.Maximized;
                rdForm.Show();
            }
            rdForm.BringToFront();
        }

        private void studentReport2ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (sr2Form == null)
            {
                sr2Form = new StudentReport2Form();
                sr2Form.MdiParent = this;
                sr2Form.WindowState = FormWindowState.Maximized;
                sr2Form.Show();
            }
            sr2Form.BringToFront();
        }

        private void studentReport1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (srForm == null)
            {
                srForm = new StudentReportForm();
                srForm.MdiParent = this;
                srForm.WindowState = FormWindowState.Maximized;
                srForm.Show();
            }
            srForm.BringToFront();
        }

        private void paidReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (plForm == null)
            {
                plForm = new PaidListMonthlyForm();
                plForm.MdiParent = this;
                plForm.WindowState = FormWindowState.Maximized;
                plForm.Show();
            }
            plForm.BringToFront();
        }

        private void monthlyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dLMForm == null)
            {
                dLMForm = new DuesListMonthlyReport();
                dLMForm.MdiParent = this;
                dLMForm.WindowState = FormWindowState.Maximized;
                dLMForm.Show();
            }
            dLMForm.BringToFront();
        }

        private void annualToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dAMForm == null)
            {
                dAMForm = new DuesListAnnualReport();
                dAMForm.MdiParent = this;
                dAMForm.WindowState = FormWindowState.Maximized;
                dAMForm.Show();
            }
            dAMForm.BringToFront();
        }

        private void reminderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rmForm == null)
            {
                rmForm = new ReminderForm();
                rmForm.MdiParent = this;
                rmForm.WindowState = FormWindowState.Maximized;
                rmForm.Show();
            }
            rmForm.BringToFront();

        }

        private void clearanceSlipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (csForm == null)
            {
                csForm = new ClearanceSlipForm();
                csForm.MdiParent = this;
                csForm.WindowState = FormWindowState.Maximized;
                csForm.Show();
            }
            csForm.BringToFront();
        }

        private void reminderSMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SMSHandler smsHandler = SMSHandler.getInstance();
            List<String> nums = new List<string>();
            List<String> msgs = new List<string>();
            nums.Add("8349066713");
            msgs.Add("Hi this is a test message from you. :)");
            List<String> reply;
            reply = smsHandler.sendSMS("2hlSs6ED/QI-ZrFSga9ZavdfMTxkUCGJ6XyVZSEn6c", nums, msgs);
            if (reply != null)
            {
                DialogResult dr = MessageBox.Show("No of replies: " + reply.Count + ". Show all?", "Choose", MessageBoxButtons.YesNo);
                if(dr.Equals(DialogResult.Yes))
                {
                    for(int i = 0; i < reply.Count; i++)
                    {
                        MessageBox.Show(reply[i]);
                    }
                }
            }
        }
    }
}
