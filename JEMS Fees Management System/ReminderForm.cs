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
    public partial class ReminderForm : Form
    {
        int index = 0;

        int topMargin = 40;

        int pageHeight = (int)(1170 * 0.9);  //1169;
        int pageWidth = 827;

        int slipCount = 4;  // No. of slips to be printed in one page HAS TO BE EVEN

        Boolean allowChange = false;

        private List<StudentDetails> gridViewSD;
        private List<StudentDetails> toPrint;

        private List<StudentDetails> sd;

        public ReminderForm()
        {
            InitializeComponent();
            rowCount.Text = "";
        }

        public String subStringer(String str, int length)
        {
            if (str == null || str.Length == 0) return "";

            if (length >= str.Length) return str;

            return str.Substring(0, length) + ".";
        }

        private void ReminderForm_Load(object sender, EventArgs e)
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


            String from_month = "from_month",
                to_month = "to_month",
            monthly_total = "monthly_total",
            late_fees = "late_fees",
            annual_total = "annual_total";

            #region Query

            #region bad query
            /*
            String query = @"with Monthly as

(select student_monthly_fees.student_id,
dbo.monthName(min(dbo.sort_by_month(month))) as " + from_month + @",
 dbo.monthName(max(dbo.sort_by_month(month))) as " + to_month + @",
 sum(tuition + management + smart_class + report_diary + sports + science + red_cross +
 guide + insurance + school_activities + computer + local_exam) as " + monthly_total + @",
 sum(late_fees) as " + late_fees + @"
 from student_monthly_fees join student_details on 
 student_monthly_fees.student_id = student_details.student_id and 
student_monthly_fees.session = student_details.current_session
 where dbo.sort_by_month(month) < 8 and 
student_monthly_fees.receipt_id is null 
and student_details.current_session = 2016
and student_details.student_category <> 'EXX'
group by student_monthly_fees.student_id having count(month) >= 2),
Annual as
(
select student_annual_fees.student_id,
 sum(school_dev + lab_dev + student_annual_fees.caution) as " + annual_total + @"
 from student_annual_fees join student_details on 
 student_annual_fees.student_id = student_details.student_id and 
student_annual_fees.session = student_details.current_session
 where student_annual_fees.receipt_id is null 
and student_details.current_session = 2016
and student_details.student_category <> 'EXX'
group by student_annual_fees.student_id),

Main as
( select Annual.student_id, from_month, to_month, monthly_total, late_fees,
  annual_total
  from Monthly full outer join Annual on Monthly.student_id = Annual.student_id)

select student_details.student_id, from_month, to_month, monthly_total, late_fees,
 annual_total,
student_details.first_name, student_details.middle_name, student_details.last_name,
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
student_details.class,
student_details.section
from Main join student_details on Main.student_id = student_details.student_id 
order by student_details.class, student_id;";
            */

            #endregion

            #region old query (only monthly)
            /*
            String query = @"select student_monthly_fees.student_id,
student_details.first_name, student_details.middle_name, student_details.last_name,
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
student_details.class,
student_details.section,
dbo.monthName(min(dbo.sort_by_month(month))) as 'from',
 dbo.monthName(max(dbo.sort_by_month(month))) as 'to',
 sum(tuition + management + smart_class + report_diary + sports + science + red_cross +
 guide + insurance + school_activities + computer + local_exam) as total, 
 sum(late_fees) as late_fees
 from student_monthly_fees join student_details on 
 student_monthly_fees.student_id = student_details.student_id and 
student_monthly_fees.session = student_details.current_session
 where dbo.sort_by_month(month) < " + CommonMethods.actualMonthToSessionMonth(DateTime.Now.Month) + @" and 
student_monthly_fees.receipt_id is null 
and student_details.current_session = " + GlobalVariables.currentSession +
                " and " + Table.student_details.student_category + " <> '" + GlobalVariables.exStud + "' " +
    @"group by student_monthly_fees.student_id,
student_details.first_name, student_details.father_name, student_details.middle_name, student_details.last_name,
student_details.class, student_details.section
 having count(month) >= 2 order by student_details.class , student_id
";

*/

            #endregion

            String query = @"with Monthly as
(select student_monthly_fees.student_id,
dbo.monthName(min(dbo.sort_by_month(month))) as from_month,
 dbo.monthName(max(dbo.sort_by_month(month))) as to_month,
 sum(tuition + management + smart_class + report_diary + sports + science + red_cross +
 guide + insurance + school_activities + computer + local_exam) as monthly_total,
 sum(late_fees) as late_fees
 from student_monthly_fees join student_details on 
 student_monthly_fees.student_id = student_details.student_id and 
student_monthly_fees.session = student_details.current_session
 where dbo.sort_by_month(month) < " + CommonMethods.actualMonthToSessionMonth(DateTime.Now.Month) + @" and 
student_monthly_fees.receipt_id is null 
and student_details.current_session = " + GlobalVariables.currentSession + @"
and student_details.student_category <> '" + GlobalVariables.exStud + @"'  
group by student_monthly_fees.student_id having count(month) >= 2),
Annual as
(
select student_annual_fees.student_id,
 school_dev + lab_dev + student_annual_fees.caution as annual_total
 from student_annual_fees join student_details on 
 student_annual_fees.student_id = student_details.student_id and 
student_annual_fees.session = student_details.current_session
 where student_annual_fees.receipt_id is null 
and student_details.current_session = " + GlobalVariables.currentSession + @"
and student_details.student_category <> '" + GlobalVariables.exStud + @"'),

Main as
(
select Monthly.student_id, from_month, to_month, monthly_total, late_fees,
  annual_total from Monthly left outer join Annual on Monthly.student_id = Annual.student_id

  union

  select Annual.student_id, from_month, to_month, monthly_total, late_fees,
  annual_total from Monthly right outer join Annual on Monthly.student_id = Annual.student_id
)


select student_details.student_id, from_month, to_month, monthly_total, late_fees,
 annual_total,
student_details.first_name, student_details.middle_name, student_details.last_name,
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
student_details.class,
student_details.section
from Main join student_details on Main.student_id = student_details.student_id 
order by student_details.class, student_id;";

            #endregion
            //Debugger.Message("Repair the above method");

            sd = new List<StudentDetails>();

            Debugger.Message(query);

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
                            String tempName = subStringer(dr["first_name"].ToString(), 9);
                            //Substring(0, 9) + //first 9 letters of first name   
                            //(dr["first_name"].ToString().Length > 9 ? "." : "");

                            tempName += (dr["middle_name"].ToString().Length == 0 ? "" :    //if has middle name selects only first letter
                                (" " + dr["middle_name"].ToString().Substring(0, 1) + "."));

                            tempName += " " + subStringer(dr["last_name"].ToString(), 9);
                            //dr["last_name"].ToString().Substring(0, 9) +        //first 9 letters of first name   
                            //    (dr["last_name"].ToString().Length > 9 ? "." : "");

                            sd.Add(new StudentDetails(dr["student_id"], tempName, subStringer(dr["father_name"].ToString(), 20), dr["the_class"], dr["class"], dr["section"],
                                dr[from_month], dr[to_month],
                                dr[monthly_total], dr[late_fees], dr[annual_total]));
                            //"10", dr[late_fees], "30"));
                        }
                        dr.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }

            allowChange = true;
            refillGridView();
        }

        private void draw(Graphics graphics, StudentDetails sd, int num)
        {

            int startx = 20;
            int starty = 30 + topMargin;
            //int divCount = 2;
            int divHeight = pageHeight / (slipCount / 2);
            int xoffset = (num % 2 == 0) ? 0 : pageWidth / 2; // if 0 or 2 first column else second
            //int yoffset = (num % 6) < 2 ? 0 : (num % 6) < 4 ? (1169 / 3) : 2 * (1169 / 3);  // if 0 or 1 first row, 2 or 3 second row, 4 or 5 3rd row
            int yoffset = divHeight * ((num / 2) % (slipCount / 2));

            String date = DateTime.Now.ToString("dd-MM-yyy");

            graphics.DrawString("JOHNSON ENGLISH MEDIUM H.S. SCHOOL", Printing.heading, Printing.brush, startx + 5 + xoffset, starty + yoffset);
            starty += 5;
            graphics.DrawString("REMINDER (FIRST/SECOND)", Printing.heading, Printing.brush, startx + 60 + xoffset, starty + 1 * Printing.fontHeight + yoffset);
            starty += 25;
            graphics.DrawString("Session " + "[" + GlobalVariables.currentSession + "-" + (GlobalVariables.currentSession + 1) + "]", Printing.heading, Printing.brush, startx + 75 + xoffset, starty + 1 * Printing.fontHeight + yoffset);
            starty += 35;
            graphics.DrawString("Student ID: " + sd.studentID + "   Date: " + date, Printing.other, Printing.brush, startx + 5 + xoffset, starty + 2 * Printing.fontHeight + yoffset);
            graphics.DrawString("Name: " + sd.name, Printing.other, Printing.brush, startx + 5 + xoffset, starty + 3 * Printing.fontHeight + yoffset);
            graphics.DrawString("Class: " + sd.theClass + "   Section: " + sd.section, Printing.other, Printing.brush, startx + 5 + xoffset, starty + 4 * Printing.fontHeight + yoffset);
            graphics.DrawString("Father's Name: " + sd.fName, Printing.other, Printing.brush, startx + 5 + xoffset, starty + 5 * Printing.fontHeight + yoffset);
            starty += 20;
            graphics.DrawString("This is to remind you that you have not", Printing.other, Printing.brush, startx + 5 + xoffset, starty + 6 * Printing.fontHeight + yoffset);
            graphics.DrawString("deposited your ward's fees: ", Printing.other, Printing.brush, startx + 5 + xoffset, starty + 7 * Printing.fontHeight + yoffset);
            yoffset += (int)Printing.fontHeight;
            if(sd.from.Length != 0)
            {
                graphics.DrawString("Monthly " + "(" + sd.from + " - " + sd.to + ")" + ": ", Printing.other, Printing.brush, startx + 5 + xoffset, starty + 7 * Printing.fontHeight + yoffset);
                graphics.DrawString("Rs. " + (sd.monthlyTotal + sd.lateFees) + ".00", Printing.bold, Printing.brush, startx + 220 + 50 - (((sd.monthlyTotal + sd.lateFees).ToString().Length - 1) * Printing.fontWidth) + xoffset, starty + 7 * Printing.fontHeight + yoffset);
            }
            else
            {
                graphics.DrawString("Monthly:" , Printing.other, Printing.brush, startx + 5 + xoffset, starty + 7 * Printing.fontHeight + yoffset);
                graphics.DrawString("Rs. " + (sd.monthlyTotal + sd.lateFees) + ".00", Printing.bold, Printing.brush, startx + 220 + 50 - (((sd.monthlyTotal + sd.lateFees).ToString().Length - 1) * Printing.fontWidth) + xoffset, starty + 7 * Printing.fontHeight + yoffset);
            }
            //graphics.DrawString("Monthly " + duration + ":", Printing.other, Printing.brush, startx + 5 + xoffset, starty + 7 * Printing.fontHeight + yoffset);            
            //graphics.DrawString("        Rs. " + (sd.monthlyTotal + sd.lateFees) + ".00", Printing.bold, Printing.brush, 180 + startx + 5 + xoffset, starty + 7 * Printing.fontHeight + yoffset);

            //graphics.DrawString("amounting to ", Printing.other, Printing.brush, startx + 5 + xoffset, starty + 8 * Printing.fontHeight + yoffset);
            //graphics.DrawString("   Rs. " + (sd.monthlyTotal + sd.lateFees) + ".00", Printing.bold, Printing.brush, 90 + startx + 5 + xoffset, starty + 8 * Printing.fontHeight + yoffset);
            graphics.DrawString("(including late fees)", Printing.other, Printing.brush, startx + 5 + xoffset, starty + 8 * Printing.fontHeight + yoffset);
            //graphics.DrawString("fees).", Printing.other, Printing.brush, startx + 5 + xoffset, starty + 9 * Printing.fontHeight + yoffset);
            yoffset += (int)Printing.fontHeight;
            graphics.DrawString("Annual: ", Printing.other, Printing.brush, startx + 5 + xoffset, starty + 8 * Printing.fontHeight + yoffset);
            graphics.DrawString("Rs. " + sd.annualTotal + ".00", Printing.bold, Printing.brush, startx + 220 + 50 - ((sd.annualTotal.ToString().Length - 1) * Printing.fontWidth) + xoffset, starty + 8 * Printing.fontHeight + yoffset);
            yoffset += (int)Printing.fontHeight;
            graphics.DrawString("Total Rs. " + (sd.annualTotal + sd.monthlyTotal + sd.lateFees) + ".00", Printing.bold, Printing.brush,
                 startx + 220 + 50 - (((sd.annualTotal + sd.monthlyTotal + sd.lateFees).ToString().Length + "Total: ".Length - 1) * Printing.fontWidth) + xoffset, starty + 8 * Printing.fontHeight + yoffset);
            yoffset += (int)Printing.fontHeight;
            graphics.DrawString("Please ignore if already paid", Printing.other, Printing.brush, startx + 5 + xoffset, starty + 9* Printing.fontHeight + yoffset);
            //starty += 10;
            yoffset += (int)Printing.fontHeight * 4;
            graphics.DrawString("COMPUTER GENERATED     Account Office", Printing.other, Printing.brush, startx + 5 + xoffset, starty + 10 * Printing.fontHeight + yoffset);
            starty += 10;
            graphics.DrawString("                  " + (num + 1), Printing.other, Printing.brush, startx + 5 + xoffset, starty + 11 * Printing.fontHeight + yoffset);


        }

        class StudentDetails
        {
            public String studentID, name, fName, theClass, clss, section, from, to;
            public float monthlyTotal, lateFees, annualTotal;
            public Boolean selected;
            public StudentDetails(Object studentID, Object name, Object fName, Object theClass, Object clss, Object section, Object from,
                Object to, Object monthlyTotal, Object lateFees, Object annualTotal)
            {
                this.studentID = studentID.ToString();
                this.name = name.ToString();
                this.fName = fName.ToString();
                this.theClass = theClass.ToString();
                this.clss = clss.ToString();
                this.section = section.ToString();
                this.from = from.ToString();
                this.to = to.ToString();
                try
                {
                    this.monthlyTotal = (monthlyTotal.ToString().Length != 0) ? float.Parse(monthlyTotal.ToString()) : 0;
                    this.lateFees = (lateFees.ToString().Length != 0) ? float.Parse(lateFees.ToString()) : 0;
                    this.annualTotal = (annualTotal.ToString().Length != 0) ? float.Parse(annualTotal.ToString()) : 0;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);

                }
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

            Debugger.Message("ci " + classIndex);

            if (classIndex >= 0)            //if All classes not selected
            {
                if (classIndex < 13)
                {
                    class1 = class2 = Classes.classArray[classIndex];
                    Debugger.Message("classname " + class1);
                }
                else
                {
                    int s = classIndex;
                    if (s == 13)
                    {
                        class1 = Classes.classArray[13];
                        class2 = Classes.classArray[14];
                    }
                    else if (s == 14)
                    {
                        class1 = class2 = Classes.classArray[15];
                    }
                    else if (s == 15)
                    {
                        class1 = Classes.classArray[16];
                        class2 = Classes.classArray[17];
                    }
                    else
                    {
                        class1 = class2 = Classes.classArray[18];
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
            rowCount.Text = "";
            int count = 0;

            for (int i = 0; i < sd.Count; i++)
            {
                if (selections.Contains(i))
                {
                    count++;
                    gridViewSD.Add(sd.ElementAt(i));
                    gridViewSD.Last().selected = true;

                    dataGridView.Rows.Add(gridViewSD.Last().selected, gridViewSD.Last().studentID, gridViewSD.Last().name,
                        gridViewSD.Last().monthlyTotal, gridViewSD.Last().lateFees, gridViewSD.Last().annualTotal);
                }

            }
            rowCount.Text = "Displayed records: " + count;
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

        private void drawLine(Graphics g)
        {
            g.DrawLine(Printing.pen, pageWidth / 2, 0, pageWidth / 2, pageHeight); // vertical
            for (int i = 1; i <= slipCount / 2; i++)
            {
                g.DrawLine(Printing.pen, 0, (pageHeight / slipCount) * 2 * i, pageWidth, (pageHeight / slipCount) * 2 * i);   // horizontal
            }
            //g.DrawLine(Printing.pen, 0, 1169 / 3, 827, 1169 / 3);   // horizontal
            //g.DrawLine(Printing.pen, 0, 2 * (1169 / 3), 827, 2 * (1169 / 3));
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
                } while (index % slipCount != 0 && index < toPrint.Count);
                drawLine(e.Graphics);
                if (index < toPrint.Count) e.HasMorePages = true;
                return;
            }
            //e.HasMorePages = false;

        }

        private void ReminderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.rmForm = null;
        }
    }

}
