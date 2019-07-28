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
    public partial class ClearanceSlipForm : Form
    {
        int index = 0;

        int topMargin = 25;

        int pageHeight = (int)(1170 * 0.9);  //1169;   DO NOT CHANGE PAGE HEIGHT
        int pageWidth = 827;

        int rows = 3;

        Boolean allowChange = false;

        private List<StudentDetails> gridViewSD;
        private List<StudentDetails> toPrint;
        private List<StudentDetails> sd;



        public ClearanceSlipForm()      //Constructor
        {
            InitializeComponent();
        }

        public String subStringer(String str, int length)   //Formats name to specified length
        {
            if (str == null || str.Length == 0) return "";

            if (length >= str.Length) return str;

            return str.Substring(0, length) + ".";
        }

        private void ReminderForm_Load(object sender, EventArgs e)  //Initiallize form element values
        {
            List<String> classes = Classes.classBranchNameArray.ToList();
            classes.RemoveRange(13, 6);
            classes.Add("Class 11 Com");
            classes.Add("Class 11 Sci");
            classes.Add("Class 12 Com");
            classes.Add("Class 12 Sci");
            classes.Insert(0, "All");
            selectedClass.DataSource = classes;
            section.SelectedIndex = 0;
            rowCount.Text = "";
            displayCount.Text = "";
        }

        private void draw(Graphics graphics, StudentDetails sd, int num)
        {

            int startx = 20;
            int starty = 15 + topMargin;
            int xoffset = (num % 2 == 0) ? 0 : 827 / 2; // if 0 or 2 first column else second
            int yoffset = 0;
            for (int i = 1; i < rows; i++)
            {
                if (num % (rows * 2) >= (i * 2)) yoffset = (pageHeight / rows) * i;
            }

            float lineNum = 0;

            //(num % (rows * 2)) < 2 ? 0 : (num % (rows * 2)) < 4 ? (1169 / 4) : (num % (rows * 2)) < 6 ? 2 * (1169 / 4) : 3 * (1169 / 4);  // if 0 or 1 first row, 2 or 3 second row, 4 or 5 3rd row
            String date = DateTime.Now.ToString("dd-MM-yyy");

            graphics.DrawString("JOHNSON ENGLISH MEDIUM H.S. SCHOOL", Printing.heading, Printing.brush, startx + 5 + xoffset, starty + (lineNum++) * Printing.fontHeight + yoffset);
            starty += 5;
            graphics.DrawString("Clearance cum Promotion Slip", Printing.heading, Printing.brush, startx + 50 + xoffset, starty + (lineNum++) * Printing.fontHeight + yoffset);
            starty += 20;
            lineNum--;
            graphics.DrawString("Session " + "[" + GlobalVariables.currentSession + "-" + (GlobalVariables.currentSession + 1) + "]", Printing.heading, Printing.brush, startx + 75 + xoffset, starty + (lineNum++) * Printing.fontHeight + yoffset);
            starty += 15;            
            graphics.DrawString("Student ID: " + sd.studentID + "   Date: " + date, Printing.other, Printing.brush, startx + 5 + xoffset, starty + (lineNum++) * Printing.fontHeight + yoffset);
            lineNum += 0.5f;
            graphics.DrawString("Name: " + sd.name, Printing.other, Printing.brush, startx + 5 + xoffset, starty + (lineNum++) * Printing.fontHeight + yoffset);
            graphics.DrawString("Class: " + sd.theClass + "   Section: " + sd.section, Printing.other, Printing.brush, startx + 5 + xoffset, starty + (lineNum++) * Printing.fontHeight + yoffset);
            graphics.DrawString("Father's Name: " + sd.fName, Printing.other, Printing.brush, startx + 5 + xoffset, starty + (lineNum++) * Printing.fontHeight + yoffset);
            //starty += 10;
            lineNum += 0.5f;
            graphics.DrawString("The student has paid all dues upto ", Printing.other, Printing.brush, startx + 5 + xoffset, starty + (lineNum++) * Printing.fontHeight + yoffset);
            graphics.DrawString("March " + (GlobalVariables.currentSession + 1), Printing.other, Printing.brush, startx + 5 + xoffset, starty + (lineNum++) * Printing.fontHeight + yoffset);     // 7
            lineNum++;
            graphics.DrawString("Promoted/Detained Class:______________", Printing.other, Printing.brush, startx + 5 + xoffset, starty + (lineNum++) * Printing.fontHeight + yoffset);            
            //graphics.DrawString("Class Teacher Remark: ________________", Printing.other, Printing.brush, startx + 5 + xoffset, starty + (lineNum++) * Printing.fontHeight + yoffset);
            lineNum++;
            graphics.DrawString("CT Sign: _____________________________", Printing.other, Printing.brush, startx + 5 + xoffset, starty + (lineNum++) * Printing.fontHeight + yoffset);
            lineNum++;
            graphics.DrawString("            COMPUTER GENERATED", Printing.other, Printing.brush, startx + 5 + xoffset, starty + (lineNum++) * Printing.fontHeight + yoffset);
            
            //starty += 10;
            graphics.DrawString("                    " + (num + 1), Printing.other, Printing.brush, startx + 5 + xoffset, starty + (lineNum++ + 0.5f) * Printing.fontHeight + yoffset);


        }

        private void drawLine(Graphics g)
        {
            g.DrawLine(Printing.pen, 827 / 2, 0, 827 / 2, 1170);
            for (int i = 1; i <= rows; i++)
            {
                g.DrawLine(Printing.pen, 0, i * (pageHeight / rows) + 10, 827, i * (pageHeight / rows) + 10);
            }            
        }

        class StudentDetails
        {
            public String studentID, name, fName, theClass, clss, section;
            public Boolean selected;
            public StudentDetails(Object studentID, Object name, Object fName, Object theClass, Object clss, Object section)
            {
                this.studentID = studentID.ToString();
                this.name = name.ToString();
                this.fName = fName.ToString();
                this.theClass = theClass.ToString();
                this.clss = clss.ToString();
                this.section = section.ToString();
                selected = true;
            }
        }

        private void section_SelectedIndexChanged(object sender, EventArgs e)
        {
            print.Enabled = true;
            refillGridView();
        }

        private void selectedClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            refillGridView();
        }

        private void refillGridView()
        {
            displayCount.Text = "";
            
            if (!allowChange) return;
            allowChange = false;
            #region Filtering
            List<int> selections = new List<int>();
            int classIndex = selectedClass.SelectedIndex - 1;
            int sectionIndex = section.SelectedIndex - 1;
            
            String[] sectionSelected = { "A", "B", "C", "D", "E" };
            String class1, class2;
            class1 = class2 = "";
            for (int i = 0; i < sd.Count; i++)
            {
                selections.Add(i);
            }

            if (classIndex >= 0)            //if 'All classes' not selected
            {
                if (classIndex < 13)
                {
                    class1 = class2 = Classes.classArray[classIndex];  //Classes at or below 10

                }
                else
                {
                    int s = classIndex;
                    if (s == 13)
                    {
                        class1 = Classes.classArray[13];            // 11 Commerece
                        class2 = Classes.classArray[14];
                    }
                    else if (s == 14)
                    {
                        class1 = class2 = Classes.classArray[15];   // 11 Science 
                    }
                    else if (s == 15)
                    {
                        class1 = Classes.classArray[16];            //12 Commerece
                        class2 = Classes.classArray[17];
                    }
                    else
                    {
                        class1 = class2 = Classes.classArray[18];   // 12 Science
                    }
                }
            }



            for (int i = 0; i < sd.Count; i++)
            {
                if (classIndex >= 0)
                {
                    if (sd.ElementAt(i).clss != class1 && sd.ElementAt(i).clss != class2)
                    {
                        selections.Remove(i);
                    }
                }
                if (sectionIndex >= 0)
                {
                    if (sd.ElementAt(i).section != sectionSelected[sectionIndex])
                    {
                        selections.Remove(i);
                    }
                }
            }

            #endregion

            #region Fill

            gridViewSD = new List<StudentDetails>();
            dataGridView.Rows.Clear();


            int count = 0;
            for (int i = 0; i < sd.Count; i++)
            {
                if (selections.Contains(i))
                {
                    count++;
                    gridViewSD.Add(sd.ElementAt(i));
                    gridViewSD.Last().selected = true;

                    dataGridView.Rows.Add(gridViewSD.Last().selected, gridViewSD.Last().studentID, gridViewSD.Last().name);
                }

            }

            displayCount.Text = "Displayed records: " + count;
            allowChange = true;
            #endregion


        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            allowChange = false;
            if (dataGridView.CurrentCell.OwningColumn is DataGridViewCheckBoxColumn &&
                dataGridView.IsCurrentCellDirty)
            {
                int x = dataGridView.CurrentCell.RowIndex;
                gridViewSD.ElementAt(x).selected = !gridViewSD.ElementAt(x).selected;
                dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
                dataGridView.EndEdit();

            }
            allowChange = true;
        }

        private void print_Click(object sender, EventArgs e)
        {
            if (gridViewSD == null) return;

            index = 0;
            
            toPrint = new List<StudentDetails>();
            for (int i = 0; i < gridViewSD.Count; i++)
            {
                if (gridViewSD.ElementAt(i).selected)
                    toPrint.Add(gridViewSD.ElementAt(i));
            }

            PrintDocument printDoc = new PrintDocument();
            printDoc.DefaultPageSettings.PaperSize = Printing.A4;
            if (GlobalVariables.preview)
            {
                PrintPreviewDialog printPrevDialog = new PrintPreviewDialog();
                printDoc.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
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
            e.HasMorePages = false;
            while (index < toPrint.Count)
            {
                do
                {
                    draw(e.Graphics, toPrint.ElementAt(index), index);
                    index++;
                } while (index % (rows * 2) != 0 && index < toPrint.Count);
                drawLine(e.Graphics);
                if (index < toPrint.Count) e.HasMorePages = true;
                return;
            }
            //e.HasMorePages = false;

        }

        private void go_Click(object sender, EventArgs e)
        {

            rowCount.Text = "";
            displayCount.Text = "";

            #region Query
            String query = @"select student_monthly_fees.student_id, student_details.first_name,
student_details.middle_name, student_details.last_name,
student_details.father_name, 
case 
when student_details.class in ('NUR') then 'NUR'
	when student_details.class in ('KG1') then 'KG 1'
	when student_details.class in ('KG2') then 'KG 2'
	when student_details.class in ('001') then 'I'
	when student_details.class in ('002') then 'II'
	when student_details.class in ('003') then 'III'
	when student_details.class in ('004') then 'IV'
	when student_details.class in ('005') then 'V'
	when student_details.class in ('006') then 'VI'
	when student_details.class in ('007') then 'VII'
	when student_details.class in ('008') then 'VIII'
	when student_details.class in ('009') then 'IX'
	when student_details.class in ('010') then 'X'
	when student_details.class in ('C1P') then 'XI COM'	
	when student_details.class in ('C1I') then 'XI IP'
	when student_details.class in ('S11') then 'XI SC'
	when student_details.class in ('C2P') then 'XII COM'	
	when student_details.class in ('C2I') then 'XII IP'
	when student_details.class in ('S12') then 'XII SC'
end as the_class,
student_details.class, student_details.section
from student_monthly_fees join student_details 
on student_monthly_fees.student_id = student_details.student_id 
and student_monthly_fees.session = student_details.current_session
join student_annual_fees 
on student_annual_fees.student_id = student_details.student_id 
and student_annual_fees.session = student_details.current_session
where dbo.sort_by_month(month) = 12 
and student_monthly_fees.receipt_id is not null
and student_annual_fees.receipt_id is not null
and student_details.current_session = " + GlobalVariables.currentSession +
                " and " + Table.student_details.student_category + " <> '" + GlobalVariables.exStud + "' " +
                " and ((student_monthly_fees.date >= '" + from.Value.ToString(GlobalVariables.dateFormat) + "' " +
                " and student_monthly_fees.date <= '" + to.Value.ToString(GlobalVariables.dateFormat) + "') " +

                " or (student_annual_fees.date >= '" + from.Value.ToString(GlobalVariables.dateFormat) + "' " +
                " and student_annual_fees.date <= '" + to.Value.ToString(GlobalVariables.dateFormat) + "')) " +
                ";";
            #endregion

            sd = new List<StudentDetails>();

            int count = 0;

            using (SqlConnection sqlConnection = new SqlConnection(GlobalVariables.dbConnectString))
            {

                try
                {
                    sqlConnection.Open();
                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        SqlDataReader dr = command.ExecuteReader();
                        while (dr.Read())
                        {
                            count++;
                            String tempName = subStringer(dr["first_name"].ToString(), 9);
                            //Substring(0, 9) + //first 9 letters of first name   
                            //(dr["first_name"].ToString().Length > 9 ? "." : "");

                            tempName += (dr["middle_name"].ToString().Length == 0 ? "" :    //if has middle name selects only first letter
                                (" " + dr["middle_name"].ToString().Substring(0, 1) + "."));

                            tempName += " " + subStringer(dr["last_name"].ToString(), 9);
                            //dr["last_name"].ToString().Substring(0, 9) +        //first 9 letters of first name   
                            //    (dr["last_name"].ToString().Length > 9 ? "." : "");

                            sd.Add(new StudentDetails(dr["student_id"], tempName, subStringer(dr["father_name"].ToString(), 20), dr["the_class"], dr["class"],
                                dr["section"]));
                        }
                        dr.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                rowCount.Text = "Records found: " + count;
                

            }

            allowChange = true;
            refillGridView();

        }

        private void ClearanceSlipForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.csForm = null;
        }
    }

}
