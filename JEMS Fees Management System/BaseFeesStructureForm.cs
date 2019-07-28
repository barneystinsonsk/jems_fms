using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace JEMS_Fees_Management_System
{
    public partial class BaseFeesStructureForm : Form
    {
        public Boolean complete;
        static public Boolean copyReady;
        public int session;
        
        struct ADFees
        {
            public int ad_fees, school_dev, furn_fund, lab_dev, caution, belt_tie, total;
        }

        struct ANFees
        {
            public int school_dev, lab_dev, caution, total;
        }

        struct MTFees
        {
            public int tuition, management, smart_class, report, sports, science, red_cross, guide, insurance,
                school_actv, computer, local_exam, total;
        }


        ADFees[] adClasses = new ADFees[19];

        ANFees[] anClasses = new ANFees[19];

        MTFees[][] mtClasses = new MTFees[19][]
                {   new MTFees[13],new MTFees[13],new MTFees[13],new MTFees[13],new MTFees[13],
                    new MTFees[13],new MTFees[13],new MTFees[13],new MTFees[13],new MTFees[13],
                    new MTFees[13],new MTFees[13],new MTFees[13],new MTFees[13],new MTFees[13],
                    new MTFees[13],new MTFees[13],new MTFees[13],new MTFees[13]
                };


        public BaseFeesStructureForm()
        {
            Cursor.Current = Cursors.WaitCursor;
            complete = false;
            copyReady = false;
            session = GlobalVariables.currentSession;

            InitializeComponent();

            //Admission Panel
            setUPAdmissionPanel();

            //Annual Panel
            setUPAnnualPanel();

            //Monthly Panel
            setUPMonthlyPanel();

            copyReady = true;

            bringUp(ref sessionPanel);

            Cursor.Current = Cursors.Default;
        }

        public void setupTitle()
        {
            this.Text = "Base Fees Structure: " + session + "-" + (session + 1);
        }

        public void skipSessionSelection()
        {
            bringUp(ref adFeesPanel);
        }

        void bringUp(ref Panel panel)
        {
            sessionPanel.Visible = false;
            adFeesPanel.Visible = false;
            anFeesPanel.Visible = false;
            mtFeesPanel.Visible = false;
            this.AcceptButton = null;
            panel.Visible = true;

            if (panel.Equals(adFeesPanel))
            {
                this.Size = new Size(570, 280);
                this.MinimumSize = new Size(450, 270);
                this.AcceptButton = baseAdFeesDone;
            }

            if (panel.Equals(anFeesPanel))
            {
                this.Size = new Size(470, 270);
                this.MinimumSize = new Size(450, 270);
                this.AcceptButton = baseAnnualDone;
            }

            if (panel.Equals(mtFeesPanel))
            {
                this.Size = new Size(1000, 530);
                this.MinimumSize = new Size(450, 350);
                this.AcceptButton = baseMonthlyDone;
            }

            if(panel.Equals(sessionPanel))
            {
                this.MinimumSize = new Size(270, 125);
                this.Size = new Size(270, 125);
                this.AcceptButton = sessionDone;
            }

        }

        // Admission Panel

        void setUPAdmissionPanel()
        {
            admissionTable.Rows.Add("", "", "", "", "", "", "");

            for (int i = 0; i < 19; i++)
            {
                String getQuery = "Select * from " + Table.admission_base_struct.tableName +
                            " where " + Table.admission_base_struct.session + "= " +
                            "(select MAX(" + Table.admission_base_struct.session + ") from "
                            + Table.admission_base_struct.tableName + " where " +
                            Table.admission_base_struct.clss + "= '" + Classes.classArray[i] + "')" +
                            " and " + Table.admission_base_struct.clss + "= '" + Classes.classArray[i] + "'";

                adClasses[i].ad_fees = 0;
                adClasses[i].school_dev = 0;
                adClasses[i].furn_fund = 0;
                adClasses[i].lab_dev = 0;
                adClasses[i].caution = 0;
                adClasses[i].belt_tie = 0;
                adClasses[i].total = 0;

                using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(getQuery, connection))
                        {
                            SqlDataReader dr = command.ExecuteReader();
                            if (dr.Read())
                            {
                                adClasses[i].total = 0;
                                adClasses[i].total += adClasses[i].ad_fees = Convert.ToInt32(dr[Table.admission_base_struct.ad_fees]);
                                adClasses[i].total += adClasses[i].school_dev = Convert.ToInt32(dr[Table.admission_base_struct.school_dev]);
                                adClasses[i].total += adClasses[i].furn_fund = Convert.ToInt32(dr[Table.admission_base_struct.furn_fund]);
                                adClasses[i].total += adClasses[i].lab_dev = Convert.ToInt32(dr[Table.admission_base_struct.lab_dev]);
                                adClasses[i].total += adClasses[i].caution = Convert.ToInt32(dr[Table.admission_base_struct.caution]);
                                adClasses[i].total += adClasses[i].belt_tie = Convert.ToInt32(dr[Table.admission_base_struct.belt_tie]);

                            }
                            dr.Close();
                        }
                        connection.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Unable to get details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }

                //ComboBoxItem cls = new ComboBoxItem();
                //cls.Value = Classes.classArray[i];
                //cls.Text = Classes.getClassBranch(cls.Value);
                //adClassSelect.Items.Add(cls);
            }
            adClassSelect.DataSource = Classes.classBranchNameArray;
            adClassSelect.SelectedIndex = 0;
            baseAdFeesDone.Enabled = false;
            admissionTableCopy();
            resetadDoneButton();
        }

        private void adClassSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            copyReady = false;

            admissionTable[0, 0].Value = adClasses[adClassSelect.SelectedIndex].ad_fees.ToString();
            admissionTable[1, 0].Value = adClasses[adClassSelect.SelectedIndex].school_dev.ToString();
            admissionTable[2, 0].Value = adClasses[adClassSelect.SelectedIndex].furn_fund.ToString();
            admissionTable[3, 0].Value = adClasses[adClassSelect.SelectedIndex].lab_dev.ToString();
            admissionTable[4, 0].Value = adClasses[adClassSelect.SelectedIndex].caution.ToString();
            admissionTable[5, 0].Value = adClasses[adClassSelect.SelectedIndex].belt_tie.ToString();
            admissionTable[6, 0].Value = adClasses[adClassSelect.SelectedIndex].total.ToString();

            copyReady = true;
        }

        void resetadDoneButton()
        {
            bool ok = true;
            for (int i = 0; i < 19; i++)
            {
                if (adClasses[i].total == 0)
                {
                    ok = false;
                }
            }
            if (ok)
                baseAdFeesDone.Enabled = true;
            else baseAdFeesDone.Enabled = false;
        }

        private void admissionTableCopy()
        {
            for (int i = 0; i < 7; i++)
            {
                if (admissionTable[i, 0].Value == null) admissionTable[i, 0].Value = 0;
                if (!CommonMethods.valueBetween(admissionTable[i, 0].Value.ToString(), 0, 20000))
                {
                    admissionTable[i, 0].Value = 0;
                }
            }

            copyReady = false;
            adClasses[adClassSelect.SelectedIndex].ad_fees = Int32.Parse(admissionTable[0, 0].Value.ToString());
            adClasses[adClassSelect.SelectedIndex].school_dev = Int32.Parse(admissionTable[1, 0].Value.ToString());
            adClasses[adClassSelect.SelectedIndex].furn_fund = Int32.Parse(admissionTable[2, 0].Value.ToString());
            adClasses[adClassSelect.SelectedIndex].lab_dev = Int32.Parse(admissionTable[3, 0].Value.ToString());
            adClasses[adClassSelect.SelectedIndex].caution = Int32.Parse(admissionTable[4, 0].Value.ToString());
            adClasses[adClassSelect.SelectedIndex].belt_tie = Int32.Parse(admissionTable[5, 0].Value.ToString());
            adClasses[adClassSelect.SelectedIndex].total = 0;
            for (int i = 0; i < 6; i++)
                adClasses[adClassSelect.SelectedIndex].total += Int32.Parse(admissionTable[i, 0].Value.ToString());
            admissionTable[6, 0].Value = adClasses[adClassSelect.SelectedIndex].total.ToString();
            copyReady = true;
        }

        private void admissionTable_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (copyReady)
                admissionTableCopy();
            resetadDoneButton();
        }

        private void admissionTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (copyReady)
                admissionTableCopy();
            resetadDoneButton();
        }

        private void baseAdFeesDone_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    String deleteQuery = "";
                    String saveQuery = "";
                    connection.Open();
                    for (int i = 0; i < 19; i++)
                    {
                        deleteQuery += "delete from " + Table.admission_base_struct.tableName + " where " +
                            Table.admission_base_struct.session + "=" + session +//GlobalVariables.currentSession +
                            " and " + Table.admission_base_struct.clss + " ='" + Classes.classArray[i] + "';";

                        saveQuery += "insert into " + Table.admission_base_struct.tableName + " (" +
                            Table.admission_base_struct.session + ", " +
                            Table.admission_base_struct.clss + ", " +
                            Table.admission_base_struct.ad_fees + ", " +
                            Table.admission_base_struct.school_dev + ", " +
                            Table.admission_base_struct.furn_fund + ", " +
                            Table.admission_base_struct.lab_dev + ", " +
                            Table.admission_base_struct.caution + ", " +
                            Table.admission_base_struct.belt_tie + ") " + " values (" +
                            //GlobalVariables.currentSession + ", '" +
                            session + ", '" +
                            Classes.classArray[i] + "', " +
                            adClasses[i].ad_fees + ", " +
                            adClasses[i].school_dev + ", " +
                            adClasses[i].furn_fund + ", " +
                            adClasses[i].lab_dev + ", " +
                            adClasses[i].caution + ", " +
                            adClasses[i].belt_tie + ");";

                    }
                    String query = deleteQuery + saveQuery;
                    using (SqlCommand delCommand = new SqlCommand(query, connection))
                    {
                        delCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    DialogResult dr = MessageBox.Show("Some Error Occurred" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (dr == System.Windows.Forms.DialogResult.OK)
                    {
                        Close();
                    }
                }
            }

            bringUp(ref anFeesPanel);


        }

        // End of Admission Panel

        // Annual Panel

        void setUPAnnualPanel()
        {
            annualTable.Rows.Add("", "", "", "");

            for (int i = 0; i < 19; i++)
            {
                String getQuery = "Select * from " + Table.annual_base_struct.tableName +
                            " where " + Table.annual_base_struct.session + "=" +
                            "(select MAX(" + Table.annual_base_struct.session + ") from "
                            + Table.annual_base_struct.tableName + " where " +
                            Table.annual_base_struct.clss + "= '" + Classes.classArray[i] + "')" +
                            " and " + Table.annual_base_struct.clss + "= '" + Classes.classArray[i] + "'";
                anClasses[i].school_dev = 0;
                anClasses[i].lab_dev = 0;
                anClasses[i].caution = 0;
                anClasses[i].total = 0;

                using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(getQuery, connection))
                        {
                            SqlDataReader dr = command.ExecuteReader();
                            if (dr.Read())
                            {
                                anClasses[i].total = 0;
                                anClasses[i].total += anClasses[i].school_dev = Convert.ToInt32(dr[Table.annual_base_struct.school_dev]);
                                anClasses[i].total += anClasses[i].lab_dev = Convert.ToInt32(dr[Table.annual_base_struct.lab_dev]);
                                anClasses[i].total += anClasses[i].caution = Convert.ToInt32(dr[Table.annual_base_struct.caution]);

                            }
                            dr.Close();
                        }
                        connection.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Unable to get details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }

                //ComboBoxItem cls = new ComboBoxItem();
                //cls.Value = Classes.classArray[i];
                //cls.Text = Classes.getClassBranch(cls.Value);
                //anClassSelect.Items.Add(cls);
            }
            anClassSelect.DataSource = Classes.classBranchNameArray;
            anClassSelect.SelectedIndex = 0;
            baseAnnualDone.Enabled = false;
            annualTableCopy();
            resetanDoneButton();
        }

        void resetanDoneButton()
        {
            bool ok = true;
            for (int i = 0; i < 19; i++)
            {
                if (anClasses[i].total == 0)
                {
                    ok = false;
                }
            }
            if (ok)
                baseAnnualDone.Enabled = true;
            else baseAnnualDone.Enabled = false;

        }

        private void anClassSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            copyReady = false;

            annualTable[0, 0].Value = anClasses[anClassSelect.SelectedIndex].school_dev.ToString();
            annualTable[1, 0].Value = anClasses[anClassSelect.SelectedIndex].lab_dev.ToString();
            annualTable[2, 0].Value = anClasses[anClassSelect.SelectedIndex].caution.ToString();
            annualTable[3, 0].Value = anClasses[anClassSelect.SelectedIndex].total.ToString();

            copyReady = true;
        }

        private void annualTableCopy()
        {
            for (int i = 0; i < 4; i++)
            {
                if (annualTable[i, 0] == null) annualTable[i, 0].Value = 0;
                if (!CommonMethods.valueBetween(annualTable[i, 0].Value.ToString(), 0, 20000))
                {
                    annualTable[i, 0].Value = 0;
                }
            }

            copyReady = false;
            anClasses[anClassSelect.SelectedIndex].school_dev = Int32.Parse(annualTable[0, 0].Value.ToString());
            anClasses[anClassSelect.SelectedIndex].lab_dev = Int32.Parse(annualTable[1, 0].Value.ToString());
            anClasses[anClassSelect.SelectedIndex].caution = Int32.Parse(annualTable[2, 0].Value.ToString());
            anClasses[anClassSelect.SelectedIndex].total = 0;
            for (int i = 0; i < 3; i++)
                anClasses[anClassSelect.SelectedIndex].total += Int32.Parse(annualTable[i, 0].Value.ToString());
            annualTable[3, 0].Value = anClasses[anClassSelect.SelectedIndex].total.ToString();
            copyReady = true;
        }

        private void annualTable_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (copyReady)
                annualTableCopy();
            resetanDoneButton();
        }

        private void annualTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (copyReady)
                annualTableCopy();
            resetanDoneButton();
        }

        private void baseAnnualPrev_Click(object sender, EventArgs e)
        {
            bringUp(ref adFeesPanel);

        }

        private void baseAnnualDone_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    String deleteQuery = "";
                    String saveQuery = "";
                    connection.Open();
                    for (int i = 0; i < 19; i++)
                    {
                        deleteQuery += "delete from " + Table.annual_base_struct.tableName + " where " +
                            Table.annual_base_struct.session + "=" + session + //GlobalVariables.currentSession +
                            " and " + Table.annual_base_struct.clss + " ='" + Classes.classArray[i] + "';";

                        saveQuery += "insert into " + Table.annual_base_struct.tableName + " (" +
                            Table.annual_base_struct.session + ", " +
                            Table.annual_base_struct.clss + ", " +
                            Table.annual_base_struct.school_dev + ", " +
                            Table.annual_base_struct.lab_dev + ", " +
                            Table.annual_base_struct.caution + ") " + " values (" +
                            //GlobalVariables.currentSession + ", '" +
                            session + ", '" +
                            Classes.classArray[i] + "', " +
                            anClasses[i].school_dev + ", " +
                            anClasses[i].lab_dev + ", " +
                            anClasses[i].caution + ");";

                    }
                    String query = deleteQuery + saveQuery;
                    using (SqlCommand saveCommand = new SqlCommand(query, connection))
                    {
                        saveCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    DialogResult dr = MessageBox.Show("Some Error Occurred" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (dr == System.Windows.Forms.DialogResult.OK)
                    {
                        Close();
                    }
                }
            }

            bringUp(ref mtFeesPanel);

        }

        //End of Annual


        // Monthly Panel

        void setUPMonthlyPanel()
        {


            for (int i = 0; i < 12; i++)
            {
                monthlyTable.Rows.Add(GlobalVariables.months[i], "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            }

            monthlyTable.Rows.Add("Total", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            monthlyTable.Rows[12].ReadOnly = true;
            monthlyTable.Rows[12].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));


            for (int i = 0; i < 19; i++)        //for each class
            {
                for (int j = 0; j < 13; j++)    //for each row init
                {
                    mtClasses[i][j].tuition = 0;
                    mtClasses[i][j].management = 0;
                    mtClasses[i][j].smart_class = 0;
                    mtClasses[i][j].report = 0;
                    mtClasses[i][j].sports = 0;
                    mtClasses[i][j].science = 0;
                    mtClasses[i][j].red_cross = 0;
                    mtClasses[i][j].guide = 0;
                    mtClasses[i][j].insurance = 0;
                    mtClasses[i][j].school_actv = 0;
                    mtClasses[i][j].computer = 0;
                    mtClasses[i][j].local_exam = 0;
                    mtClasses[i][j].total = 0;
                }
                using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
                {
                    try
                    {
                        connection.Open();

                        for (int j = 0; j < 12; j++)    //for each month
                        {

                            String getQuery = "Select * from " + Table.monthly_base_struct.tableName +
                            " where " + Table.monthly_base_struct.session + "=" +
                            //session + " " + 
                            //GlobalVariables.currentSession + " " + 
                            " (select Max(" + Table.monthly_base_struct.session + ") " +
                            " from " + Table.monthly_base_struct.tableName +
                            " where " + Table.monthly_base_struct.clss + "= '" + Classes.classArray[i] + "' and " +
                            Table.monthly_base_struct.mnth + " = '" + GlobalVariables.db_months[j] + "') " +
                            " and " + Table.monthly_base_struct.clss + "= '" + Classes.classArray[i] + "' and " +
                            Table.monthly_base_struct.mnth + " = '" + GlobalVariables.db_months[j] + "'";
                            //MessageBox.Show(getQuery);
                            using (SqlCommand command = new SqlCommand(getQuery, connection))
                            {
                                SqlDataReader dr = command.ExecuteReader();
                                if (dr.Read())
                                {
                                    //mtClasses[i][j].total = 0;
                                    mtClasses[i][j].total += mtClasses[i][j].tuition = Convert.ToInt32(dr[Table.monthly_base_struct.tuition]);
                                    mtClasses[i][j].total += mtClasses[i][j].management = Convert.ToInt32(dr[Table.monthly_base_struct.management]);
                                    mtClasses[i][j].total += mtClasses[i][j].smart_class = Convert.ToInt32(dr[Table.monthly_base_struct.smart]);
                                    mtClasses[i][j].total += mtClasses[i][j].report = Convert.ToInt32(dr[Table.monthly_base_struct.report]);
                                    mtClasses[i][j].total += mtClasses[i][j].sports = Convert.ToInt32(dr[Table.monthly_base_struct.sports]);
                                    mtClasses[i][j].total += mtClasses[i][j].science = Convert.ToInt32(dr[Table.monthly_base_struct.science]);
                                    mtClasses[i][j].total += mtClasses[i][j].red_cross = Convert.ToInt32(dr[Table.monthly_base_struct.red_cross]);
                                    mtClasses[i][j].total += mtClasses[i][j].guide = Convert.ToInt32(dr[Table.monthly_base_struct.guide]);
                                    mtClasses[i][j].total += mtClasses[i][j].insurance = Convert.ToInt32(dr[Table.monthly_base_struct.insurance]);
                                    mtClasses[i][j].total += mtClasses[i][j].school_actv = Convert.ToInt32(dr[Table.monthly_base_struct.school_activities]);
                                    mtClasses[i][j].total += mtClasses[i][j].computer = Convert.ToInt32(dr[Table.monthly_base_struct.computer]);
                                    mtClasses[i][j].total += mtClasses[i][j].local_exam = Convert.ToInt32(dr[Table.monthly_base_struct.local_exam]);

                                }
                                dr.Close();
                            }
                            mtClasses[i][12].tuition += mtClasses[i][j].tuition;
                            mtClasses[i][12].management += mtClasses[i][j].management;
                            mtClasses[i][12].smart_class += mtClasses[i][j].smart_class;
                            mtClasses[i][12].report += mtClasses[i][j].report;
                            mtClasses[i][12].sports += mtClasses[i][j].sports;
                            mtClasses[i][12].science += mtClasses[i][j].science;
                            mtClasses[i][12].red_cross += mtClasses[i][j].red_cross;
                            mtClasses[i][12].guide += mtClasses[i][j].guide;
                            mtClasses[i][12].insurance += mtClasses[i][j].insurance;
                            mtClasses[i][12].school_actv += mtClasses[i][j].school_actv;
                            mtClasses[i][12].computer += mtClasses[i][j].computer;
                            mtClasses[i][12].local_exam += mtClasses[i][j].local_exam;
                            mtClasses[i][12].total += mtClasses[i][j].total;
                        }

                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Unable to get details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //ComboBoxItem cls = new ComboBoxItem();
                //cls.Value = Classes.classArray[i];
                //cls.Text = Classes.getClassBranch(cls.Value);
                //mtClassSelect.Items.Add(cls);
            }

            mtClassSelect.DataSource = Classes.classBranchNameArray;
            mtClassSelect.SelectedIndex = 0;
            baseMonthlyDone.Enabled = false;
            monthlyTableCopy();
            resetmtDoneButton();
        }

        void resetmtDoneButton()
        {
            bool ok = true;
            //Check if no total = 0
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 12; j++)
                    if (mtClasses[i][j].total == 0)
                    {
                        ok = false;
                    }
            }
            if (ok)
                baseMonthlyDone.Enabled = true;
            else baseMonthlyDone.Enabled = false;

        }

        private void monthlyTableCopy()     // Table to local array
        {
            // Check if table values valid and between 0 and 50000

            for (int i = 0; i < 13; i++)
            {
                for (int j = 1; j < 13; j++)
                {
                    if (monthlyTable[j, i].Value == null)
                    {
                        monthlyTable[j, i].Value = 0;
                    }
                    if (!CommonMethods.valueBetween(monthlyTable[j, i].Value.ToString(), 0, 50000))
                    {
                        monthlyTable[j, i].Value = 0;
                    }
                }
            }

            // copy value

            //Row 12 Total initializing 

            mtClasses[mtClassSelect.SelectedIndex][12].tuition = 0;
            mtClasses[mtClassSelect.SelectedIndex][12].management = 0;
            mtClasses[mtClassSelect.SelectedIndex][12].smart_class = 0;
            mtClasses[mtClassSelect.SelectedIndex][12].report = 0;
            mtClasses[mtClassSelect.SelectedIndex][12].sports = 0;
            mtClasses[mtClassSelect.SelectedIndex][12].science = 0;
            mtClasses[mtClassSelect.SelectedIndex][12].red_cross = 0;
            mtClasses[mtClassSelect.SelectedIndex][12].guide = 0;
            mtClasses[mtClassSelect.SelectedIndex][12].insurance = 0;
            mtClasses[mtClassSelect.SelectedIndex][12].school_actv = 0;
            mtClasses[mtClassSelect.SelectedIndex][12].computer = 0;
            mtClasses[mtClassSelect.SelectedIndex][12].local_exam = 0;
            mtClasses[mtClassSelect.SelectedIndex][12].total = 0;

            for (int i = 0; i < 12; i++)        //foreach month
            {
                // head total                                          //each month and head                       
                mtClasses[mtClassSelect.SelectedIndex][12].tuition += mtClasses[mtClassSelect.SelectedIndex][i].tuition = Int32.Parse(monthlyTable[1, i].Value.ToString());
                mtClasses[mtClassSelect.SelectedIndex][12].management += mtClasses[mtClassSelect.SelectedIndex][i].management = Int32.Parse(monthlyTable[2, i].Value.ToString());
                mtClasses[mtClassSelect.SelectedIndex][12].smart_class += mtClasses[mtClassSelect.SelectedIndex][i].smart_class = Int32.Parse(monthlyTable[3, i].Value.ToString());
                mtClasses[mtClassSelect.SelectedIndex][12].report += mtClasses[mtClassSelect.SelectedIndex][i].report = Int32.Parse(monthlyTable[4, i].Value.ToString());
                mtClasses[mtClassSelect.SelectedIndex][12].sports += mtClasses[mtClassSelect.SelectedIndex][i].sports = Int32.Parse(monthlyTable[5, i].Value.ToString());
                mtClasses[mtClassSelect.SelectedIndex][12].science += mtClasses[mtClassSelect.SelectedIndex][i].science = Int32.Parse(monthlyTable[6, i].Value.ToString());
                mtClasses[mtClassSelect.SelectedIndex][12].red_cross += mtClasses[mtClassSelect.SelectedIndex][i].red_cross = Int32.Parse(monthlyTable[7, i].Value.ToString());
                mtClasses[mtClassSelect.SelectedIndex][12].guide += mtClasses[mtClassSelect.SelectedIndex][i].guide = Int32.Parse(monthlyTable[8, i].Value.ToString());
                mtClasses[mtClassSelect.SelectedIndex][12].insurance += mtClasses[mtClassSelect.SelectedIndex][i].insurance = Int32.Parse(monthlyTable[9, i].Value.ToString());
                mtClasses[mtClassSelect.SelectedIndex][12].school_actv += mtClasses[mtClassSelect.SelectedIndex][i].school_actv = Int32.Parse(monthlyTable[10, i].Value.ToString());
                mtClasses[mtClassSelect.SelectedIndex][12].computer += mtClasses[mtClassSelect.SelectedIndex][i].computer = Int32.Parse(monthlyTable[11, i].Value.ToString());
                mtClasses[mtClassSelect.SelectedIndex][12].local_exam += mtClasses[mtClassSelect.SelectedIndex][i].local_exam = Int32.Parse(monthlyTable[12, i].Value.ToString());

                //each month total
                mtClasses[mtClassSelect.SelectedIndex][i].total = 0;
                for (int j = 1; j < 13; j++)
                    mtClasses[mtClassSelect.SelectedIndex][i].total += Int32.Parse(monthlyTable[j, i].Value.ToString());

                //grand total
                mtClasses[mtClassSelect.SelectedIndex][12].total += mtClasses[mtClassSelect.SelectedIndex][i].total;

                copyReady = false;
                //setting each months total
                monthlyTable[13, i].Value = mtClasses[mtClassSelect.SelectedIndex][i].total.ToString();
                copyReady = true;
            }

            copyReady = false;
            monthlyTable[1, 12].Value = mtClasses[mtClassSelect.SelectedIndex][12].tuition;
            monthlyTable[2, 12].Value = mtClasses[mtClassSelect.SelectedIndex][12].management;
            monthlyTable[3, 12].Value = mtClasses[mtClassSelect.SelectedIndex][12].smart_class;
            monthlyTable[4, 12].Value = mtClasses[mtClassSelect.SelectedIndex][12].report;
            monthlyTable[5, 12].Value = mtClasses[mtClassSelect.SelectedIndex][12].sports;
            monthlyTable[6, 12].Value = mtClasses[mtClassSelect.SelectedIndex][12].science;
            monthlyTable[7, 12].Value = mtClasses[mtClassSelect.SelectedIndex][12].red_cross;
            monthlyTable[8, 12].Value = mtClasses[mtClassSelect.SelectedIndex][12].guide;
            monthlyTable[9, 12].Value = mtClasses[mtClassSelect.SelectedIndex][12].insurance;
            monthlyTable[10, 12].Value = mtClasses[mtClassSelect.SelectedIndex][12].school_actv;
            monthlyTable[11, 12].Value = mtClasses[mtClassSelect.SelectedIndex][12].computer;
            monthlyTable[12, 12].Value = mtClasses[mtClassSelect.SelectedIndex][12].local_exam;
            monthlyTable[13, 12].Value = mtClasses[mtClassSelect.SelectedIndex][12].total;
            copyReady = true;

        }

        private void monthlyPrev_Click(object sender, EventArgs e)
        {
            bringUp(ref anFeesPanel);

        }

        private void mtClassSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            copyReady = false;

            for (int i = 0; i < 13; i++)
            {
                monthlyTable[1, i].Value = mtClasses[mtClassSelect.SelectedIndex][i].tuition.ToString();
                monthlyTable[2, i].Value = mtClasses[mtClassSelect.SelectedIndex][i].management.ToString();
                monthlyTable[3, i].Value = mtClasses[mtClassSelect.SelectedIndex][i].smart_class.ToString();
                monthlyTable[4, i].Value = mtClasses[mtClassSelect.SelectedIndex][i].report.ToString();
                monthlyTable[5, i].Value = mtClasses[mtClassSelect.SelectedIndex][i].sports.ToString();
                monthlyTable[6, i].Value = mtClasses[mtClassSelect.SelectedIndex][i].science.ToString();
                monthlyTable[7, i].Value = mtClasses[mtClassSelect.SelectedIndex][i].red_cross.ToString();
                monthlyTable[8, i].Value = mtClasses[mtClassSelect.SelectedIndex][i].guide.ToString();
                monthlyTable[9, i].Value = mtClasses[mtClassSelect.SelectedIndex][i].insurance.ToString();
                monthlyTable[10, i].Value = mtClasses[mtClassSelect.SelectedIndex][i].school_actv.ToString();
                monthlyTable[11, i].Value = mtClasses[mtClassSelect.SelectedIndex][i].computer.ToString();
                monthlyTable[12, i].Value = mtClasses[mtClassSelect.SelectedIndex][i].local_exam.ToString();
                monthlyTable[13, i].Value = mtClasses[mtClassSelect.SelectedIndex][i].total.ToString();
            }
            copyReady = true;
        }

        private void monthlyTable_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (copyReady)
                monthlyTableCopy();
            resetmtDoneButton();
        }

        private void monthlyTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (copyReady)
                monthlyTableCopy();
            resetmtDoneButton();
        }

        private void baseMonthlyDone_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    String deleteQuery = "";
                    String saveQuery = "";
                    connection.Open();
                    for (int i = 0; i < 19; i++)
                    {
                        for (int j = 0; j < 12; j++)
                        {
                            deleteQuery += "delete from " + Table.monthly_base_struct.tableName + " where " +
                                Table.monthly_base_struct.session + "=" + session +//GlobalVariables.currentSession +
                                " and " + Table.monthly_base_struct.clss + " = '" + Classes.classArray[i] + "' and " +
                                Table.monthly_base_struct.mnth + " = '" + GlobalVariables.db_months[j] + "';";

                            saveQuery += "insert into " + Table.monthly_base_struct.tableName + " (" +
                                Table.monthly_base_struct.session + ", " +
                                Table.monthly_base_struct.clss + ", " +
                                Table.monthly_base_struct.mnth + ", " +
                                Table.monthly_base_struct.tuition + ", " +
                                Table.monthly_base_struct.management + ", " +
                                Table.monthly_base_struct.smart + ", " +
                                Table.monthly_base_struct.report + ", " +
                                Table.monthly_base_struct.sports + ", " +
                                Table.monthly_base_struct.science + ", " +
                                Table.monthly_base_struct.red_cross + ", " +
                                Table.monthly_base_struct.guide + ", " +
                                Table.monthly_base_struct.insurance + ", " +
                                Table.monthly_base_struct.school_activities + ", " +
                                Table.monthly_base_struct.computer + ", " +
                                Table.monthly_base_struct.local_exam + ") " + " values (" +
                                //GlobalVariables.currentSession + ", '" +
                                session + ", '" +
                                Classes.classArray[i] + "', '" +
                                GlobalVariables.db_months[j] + "', " +
                                mtClasses[i][j].tuition + ", " +
                                mtClasses[i][j].management + ", " +
                                mtClasses[i][j].smart_class + ", " +
                                mtClasses[i][j].report + ", " +
                                mtClasses[i][j].sports + ", " +
                                mtClasses[i][j].science + ", " +
                                mtClasses[i][j].red_cross + ", " +
                                mtClasses[i][j].guide + ", " +
                                mtClasses[i][j].insurance + ", " +
                                mtClasses[i][j].school_actv + ", " +
                                mtClasses[i][j].computer + ", " +
                                mtClasses[i][j].local_exam + ");";

                        }
                    }
                    String query = deleteQuery + saveQuery;
                    using (SqlCommand saveCommand = new SqlCommand(query, connection))
                    {
                        saveCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    DialogResult dr = MessageBox.Show("Some Error Occurred" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (dr == System.Windows.Forms.DialogResult.OK)
                    {
                        Close();
                    }
                }
            }
            complete = true;
            Close();
        }

        private void sessionDone_Click(object sender, EventArgs e)
        {
            session = GlobalVariables.currentSession;
            Int32.TryParse(currentSession.Text,out session);
            bringUp(ref adFeesPanel);
            setupTitle();
        }

        private void currentSession_TextChanged(object sender, EventArgs e)
        {
            sessionDone.Enabled = false;
            if (currentSession.Text.Length == 0)
            {
                endSessionLabel.ForeColor = Color.Black;
                endSessionLabel.Text = "-20XX";
                sessionDone.Enabled = false;
            }
            else
                if (!CommonMethods.isNumeric(currentSession.Text, 4))
            {
                endSessionLabel.ForeColor = Color.Red;
                endSessionLabel.Text = "-20XX";
                sessionDone.Enabled = false;
            }
            else
            {
                int val = Int32.Parse(currentSession.Text);
                if (val < 2014 || val > 2050)
                {
                    endSessionLabel.ForeColor = Color.Red;
                    endSessionLabel.Text = "-20XX";
                    sessionDone.Enabled = false;
                }
                else
                {
                    endSessionLabel.ForeColor = Color.Black;
                    sessionDone.Enabled = true;
                    endSessionLabel.Text = "-" + (val + 1);
                }
            }
        }
    }

}
