using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace JEMS_Fees_Management_System
{
    public static class GlobalVariables
    {
        public static String dbConnectString = "Data Source=DESKTOP-JHNU9A9\\SQLEXPRESS;Initial Catalog=jems_database_1;User ID=sa;Password=8349066713";
        public static String backupFolder = "";
        public static int thisTerminal = 0;
        public static int currentSession = 0;
        public static String[] db_months = new String[12] {"APR","MAY","JUN","JUL",
                        "AUG","SEP","OCT","NOV","DEC","JAN","FEB","MAR"};

        public static String[] months = new String[12] {"April","May","June","July",
                        "August","September","October","November","December","January","February","March"};

        public static String[] categoryCast = new String[4] { "GEN", "ST", "SC", "OBC" };
        public static String[] categoryCastNames = new String[4] { "General", "ST", "SC", "OBC" };

        public static String newStud = "NEW";
        public static String oldStud = "OLD";
        public static String exStud = "EXX";
        public static String provStud = "PRV";
        public static String manStud = "MAN";
        public static String dateFormat = "yyyy-MM-dd";
        public static Boolean preview = false;
        public static String version = "2.2.1";
        public static String title = "JEMS Fees Management System v" + version;
        public static String sort_by_month = "dbo.sort_by_month";
        public static Char nextLineCharacter = '^';
        public static Boolean limitMenuItems = false;
        public static int warnDate = -1;
        public static String[] changeLog = {
            "v2.1.4: Increased sidebar receipt font size",
            "v2.1.5: Suspended Marker added",
            "v2.1.6: Monthly Fees Page to show late fees separately",
            "v2.1.7: Bifurcate all fees reports by new and old students except Paid reports",
            "v2.1.8: Correction on v2.1.7 new/old student are now defined by current session. Issue with Paid List Report",
            "v2.1.9: Paid list report correction",
            "v2.2.0: Manangemnt Report name changed to Annual Fees Report",
            "v2.2.1: Late fees exempted for May and June"
        };
    }
    

    public static class Debugger
    {
        private static Boolean Release = true;
        
        public static void Message(String message)
        {
            if(!Release)
                System.Windows.Forms.MessageBox.Show(message);
        }

    }

    public static class Classes
    {

        public static String nur = "NUR";           //                  0
        public static String kg_1 = "KG1";          //                  1
        public static String kg_2 = "KG2";          //                  2
        public static String cl_1 = "001";          //                  3
        public static String cl_2 = "002";          //                  4
        public static String cl_3 = "003";          //                  5 
        public static String cl_4 = "004";          //                  6
        public static String cl_5 = "005";          //                  7
        public static String cl_6 = "006";          //                  8
        public static String cl_7 = "007";          //                  9
        public static String cl_8 = "008";          //                  10
        public static String cl_9 = "009";          //                  11
        public static String cl_10 = "010";         //                  12
        public static String cl_11_CM_P = "C1P";    //11 Commerce plain 13
        public static String cl_11_CM_I = "C1I";    //11 Commerce IP    14
        public static String cl_11_SC = "S11";      //11 Science        15
        public static String cl_12_CM_P = "C2P";    //12 Commerce plain 16
        public static String cl_12_CM_I = "C2I";    //12 Commerce IP    17
        public static String cl_12_SC = "S12";      //12 Science        18

        public static String[] classArray = {nur,kg_1,kg_2,cl_1,cl_2,cl_3,cl_4,cl_5,
            cl_6,cl_7,cl_8,cl_9,cl_10,cl_11_CM_P,cl_11_CM_I,cl_11_SC,cl_12_CM_P,cl_12_CM_I,cl_12_SC};
        /*
        public static String[] classBranchNameArray = {"Nursery","KG-1","KG-2","Class 1","Class 2","Class 3"
                                ,"Class 4","Class 5","Class 6","Class 7","Class 8","Class 9","Class 10"
                                ,"Class 11 Com (Plain)","Class 11 Com (IP)","Class 11 Science"
                                ,"Class 12 Com (Plain)","Class 12 Com (IP)","Class 12 Science"};
        */
        public static String[] classBranchNameArray = {"Nursery","KG-1","KG-2","I","II","III"
                                ,"IV","V","VI","VII","VIII","IX","X"
                                ,"XI Com (Plain)","XI Com (IP)","XI Science"
                                ,"XII Com (Plain)","XII Com (IP)","XII Science"};

        public static String getClassBranch(String cl)
        {
            if (cl == nur) return classBranchNameArray[0];
            if (cl == kg_1) return classBranchNameArray[1];
            if (cl == kg_2) return classBranchNameArray[2];
            if (cl == cl_1) return classBranchNameArray[3];
            if (cl == cl_2) return classBranchNameArray[4];
            if (cl == cl_3) return classBranchNameArray[5];
            if (cl == cl_4) return classBranchNameArray[6];
            if (cl == cl_5) return classBranchNameArray[7];
            if (cl == cl_6) return classBranchNameArray[8];
            if (cl == cl_7) return classBranchNameArray[9];
            if (cl == cl_8) return classBranchNameArray[10];
            if (cl == cl_9) return classBranchNameArray[11];
            if (cl == cl_10) return classBranchNameArray[12];
            if (cl == cl_11_CM_P) return classBranchNameArray[13];
            if (cl == cl_11_CM_I) return classBranchNameArray[14];
            if (cl == cl_11_SC) return classBranchNameArray[15];
            if (cl == cl_12_CM_P) return classBranchNameArray[16];
            if (cl == cl_12_CM_I) return classBranchNameArray[17];
            if (cl == cl_12_SC) return classBranchNameArray[18];
            return null;
        }

        public static String getClass(String cl)
        {
            if (cl == nur) return "Nursery";
            if (cl == kg_1) return "KG-1";
            if (cl == kg_2) return "KG-2";
            if (cl == cl_1) return "I";
            if (cl == cl_2) return "II";
            if (cl == cl_3) return "III";
            if (cl == cl_4) return "IV";
            if (cl == cl_5) return "V";
            if (cl == cl_6) return "VI";
            if (cl == cl_7) return "VII";
            if (cl == cl_8) return "VIII";
            if (cl == cl_9) return "IX";
            if (cl == cl_10) return "X";
            if (cl == cl_11_CM_I || cl == cl_11_CM_P || cl == cl_11_SC) return "XI";
            if (cl == cl_12_CM_I || cl == cl_12_CM_P || cl == cl_12_SC) return "XII";
            return null;
        }


    }

    public static class Receipt
    {
        public static String admission = "AD";
        public static String provisional = "PR";
        public static String adForm = "AF";
        public static String annual = "AN";
        public static String monthly = "MT";
        public static String other = "OT";

        public static Boolean isReceiptID(String rcID)
        {
            rcID = rcID.ToUpper();
            if (rcID.Length == 8) //return false;
            {
                String st = rcID.Substring(0, 2);
                if (st != admission && st != provisional && st != adForm &&
                    st != annual && st != other)
                    return false;
                if (!CommonMethods.isNumeric(rcID.Substring(2), 6)) return false;
            }
            else if(rcID.Length == 10)
            {
                String st = rcID.Substring(0, 2);
                if (st != monthly)
                    return false;
                if (!CommonMethods.isNumeric(rcID.Substring(2), 8)) return false;
            }
            
            return true;
        }

    }

    public static class Printing
    {

        public static PaperSize annualReceipt = new PaperSize("annualReceipt", 400, 600);
        public static PaperSize admissionReceipt = new PaperSize("admissionReceipt", 400, 600);
        public static PaperSize monthlyReceipt = new PaperSize("monthlyReceipt", 400, 600);
        public static PaperSize provisionalReceipt = new PaperSize("provisionalReceipt", 400, 600);
        public static PaperSize A4 = new PaperSize("A4", 827, 1169);
        public static Font heading = new Font("Courier New", 10 + 2);
        public static Font subhead = new Font("Courier New", 9 + 2);
        public static Font other = new Font("Courier New", 8 + 2);
        public static Font bold = new Font("Courier New", 8 + 2, FontStyle.Bold);
        public static Font boldSubHead = new Font("Courier New", 9 + 2, FontStyle.Bold);
        public static SolidBrush brush = new SolidBrush(Color.Black);
        public static SolidBrush fillBrush = new SolidBrush(Color.LightGray);
        public static float fontWidth = 8.6F;
        public static float boldFontWidth = 9F;
        public static float fontHeight = subhead.GetHeight();
        public static Pen pen = new Pen(Color.Black);
        
    }

    public static class Table
    {
        public static class session_info
        {

            public static String tableName = "session_info";
            public static String session = "session";
            public static String admission_rec_start = "admission_receipt_start";
            public static String prov_rec_start = "provisional_receipt_start";
            public static String annual_rec_start = "annual_receipt_start";
            public static String monthly_rec_start = "monthly_receipt_start";
            public static String warn_fees_date = "warn_fees_date";
            public static String default_warn_fees_date = "default_warn_fees_date";
            public static String warn_fees = "warn_fees";
            public static String late_fees = "late_fees";
            public static String st_id_start = "student_id_start";
            public static String prov_id_start = "prov_id_start";
            public static String active_session = "active_session";
            public static String last_late_cal = "last_late_cal";
        }

        public static class terminal_names
        {
            public static String tableName = "terminal_names";
        }

        public static class admission_base_struct
        {
            public static String tableName = "admission_base_struct";
            public static String clss = "class";
            public static String session = "session";
            public static String ad_fees = "admission_fees";
            public static String school_dev = "school_dev";
            public static String furn_fund = "furniture_fund";
            public static String lab_dev = "lab_dev";
            public static String caution = "caution";
            public static String belt_tie = "belt_tie";
        }

        public static class annual_base_struct
        {
            public static String tableName = "annual_base_struct";
            public static String session = "session";
            public static String clss = "class";
            public static String school_dev = "school_dev";
            public static String lab_dev = "lab_dev";
            public static String caution = "caution";
        }

        public static class monthly_base_struct
        {
            public static String tableName = "monthly_base_struct";
            public static String session = "session";
            public static String clss = "class";
            public static String mnth = "month";
            public static String tuition = "tuition";
            public static String management = "management";
            public static String smart = "smart_class";
            public static String report = "report_diary";
            public static String sports = "sports";
            public static String science = "science";
            public static String red_cross = "red_cross";
            public static String guide = "guide";
            public static String insurance = "insurance";
            public static String school_activities = "school_activities";
            public static String computer = "computer";
            public static String local_exam = "local_exam";

        }

        public static class student_details
        {
            public static String tableName = "student_details";
            public static String student_id = "student_id";
            public static String first_name = "first_name";
            public static String middle_name = "middle_name";
            public static String last_name = "last_name";
            public static String father_name = "father_name";
            public static String mother_name = "mother_name";
            public static String gender = "gender";
            public static String dob = "dob";
            public static String category = "category";
            public static String address = "address";
            //public static String house_no = "house_no";
            //public static String locality = "locality";
            //public static String ward = "ward";
            public static String city = "city";
            public static String state = "state";
            public static String pincode = "pincode";
            public static String mobile = "mobile";
            public static String phone = "phone";
            public static String guardian_name = "guardian_name";
            public static String g_address = "g_address";
            //public static String g_house_no = "g_house_no";
            //public static String g_locality = "g_locality";
            //public static String g_ward = "g_ward";
            public static String g_city = "g_city";
            public static String g_state = "g_state";
            public static String g_pincode = "g_pincode";
            public static String g_mobile = "g_mobile";
            public static String g_phone = "g_phone";
            public static String samagra_id = "samagra_id";
            public static String bank_name = "bank_name";
            public static String bank_ac_no = "bank_ac_no";
            public static String bank_ifsc_code = "bank_ifsc_code";
            public static String adhar_card = "adhar_card";
            public static String admission_date = "admission_date";
            public static String admission_fees = "admission_fees";
            public static String furniture_fund = "furniture_fund";
            public static String caution = "caution";
            public static String belt_tie = "belt_tie";
            public static String admission_class = "admission_class";
            public static String admission_session = "admission_session";
            public static String tc_date = "tc_date";
            public static String current_session = "current_session";
            public static String receipt_id = "receipt_id";
            public static String student_category = "student_category";
            public static String section = "section";
            public static String class_n = "class";
            public static String concession = "concession";
            public static String block_payment = "block_payment";
            public static String reason = "reason";
            public static String tc_no = "tc_no";
            public static String suspended = "suspended";
            public static String suspension_month = "suspension_month";
            public static String suspension_remark = "suspension_remark";

        }

        public static class student_monthly_fees
        {
            public static String tableName = "student_monthly_fees";
            public static String student_id = "student_id";
            public static String session = "session";
            public static String month = "month";
            public static String tuition = "tuition";
            public static String management = "management";
            public static String smart_class = "smart_class";
            public static String report_diary = "report_diary";
            public static String sports = "sports";
            public static String science = "science";
            public static String red_cross = "red_cross";
            public static String guide = "guide";
            public static String insurance = "insurance";
            public static String school_activities = "school_activities";
            public static String computer = "computer";
            public static String local_exam = "local_exam";
            public static String late_fees = "late_fees";
            public static String receipt_id = "receipt_id";
            public static String class_n = "class";
            public static String date = "date";
            public static String concession = "concession";
            public static String terminal = "terminal";
            public static String cheque = "cheque";

        }

        public static class student_annual_fees
        {
            public static String tableName = "student_annual_fees";
            public static String student_id = "student_id";
            public static String session = "session";
            public static String school_dev = "school_dev";
            public static String lab_dev = "lab_dev";
            public static String caution = "caution";
            public static String receipt_id = "receipt_id";
            public static String date = "date";
            public static String class_n = "class";
            public static String concession = "concession";
            public static String terminal = "terminal";
            public static String cheque = "cheque";

        }

        public static class provisional_map
        {
            public static String tableName = "provisional_map";
            public static String prov_id = "prov_id";
            public static String student_id = "student_id";
            public static String prov_date = "prov_date";
            public static String prov_rec_id = "prov_rec_id";
        }

        public static class other_fees_receipt
        {
            public static String tableName = "other_fees_receipt";
            public static String receipt_id = "receipt_id";
            public static String name = "name";
            public static String fee_head = "fee_head";
            public static String amount = "amount";
            public static String date = "date";
            public static String terminal = "terminal";
            public static String cheque = "cheque";

        }

        public static class other_fees_register
        {
            public static String tableName = "other_fees_register";
            public static String date = "date";
            public static String rec_ref = "rec_ref";
            public static String from_date = "from_date";
            public static String to_date = "to_date";
            public static String ad_form = "ad_form";
            public static String belt_tie = "belt_tie";
            public static String dup_mark = "dup_mark";
            public static String dup_tc = "dup_tc";
            public static String dup_fc = "dup_fc";
            public static String mag = "mag";
            public static String msc = "msc";
        }


    }

    class CommonMethods
    {
        static public Boolean studentIDCheck(String id)
        {
            if (id == null || id.Length != 8) return false;
            id = id.ToUpper();
            String st = id.Substring(0, 2);
            if (!st.Equals("ST") && !st.Equals("PV") && !st.Equals("OL")) return false;
            if (isNumeric(id.Substring(2, 6), 6)) return true;
            else return false;
        }

        static public Boolean studentIDSTCheck(String id)
        {
            if (id == null || id.Length != 8) return false;
            String st = id.Substring(0, 2);
            if (!st.Equals("ST") && !st.Equals("OL")) return false;
            if (isNumeric(id.Substring(2, 6), 6)) return true;
            else return false;
        }

        static public Boolean studentIDPVCheck(String id)
        {
            if (id == null || id.Length != 8) return false;
            String st = id.Substring(0, 2);
            if (!st.Equals("PV")) return false;
            if (isNumeric(id.Substring(2, 6), 6)) return true;
            else return false;
        }

        static public Boolean isNumeric(String str, int size)
        {
            if (str == null || str.Length == 0) return false;
            if (size != 0 && str.Length != size) return false;
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }

        static public Boolean valueBetween(String str, int min, int max)
        {
            if (!isNumeric(str, 0)) return false;
            else
            {

                int val = Int32.Parse(str);
                if (val < min || val > max)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        static public String formatAmount(String str)
        {
            return "" + amountToInt(str) + ".00";
        }

        static public int amountToInt(String str)
        {
            if (str == null || str.Length == 0) return 0;
            int i = 0;
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    break;
                i++;
            }
            str = str.Substring(0, i);
            if (str.Length > 0) return Int32.Parse(str);
            return 0;
        }

        static public String onlyNumeric(String str)
        {
            if (str == null || str.Length == 0)
                return "";
            String ret = "";
            foreach (char c in str)
            {
                if (c >= '0' && c <= '9')
                    ret += c;
            }
            return ret;
        }

        static public String nameFormat(String name)
        {
            if (name == null || name.Length == 0) return "";
            String tempName = "";
            bool first = true;
            foreach (char c in name)
            {
                if (c < '0' || c > '9')
                {
                    if (first)
                        tempName += c.ToString().ToUpper();
                    else tempName += c.ToString().ToLower();
                    if (c == ' ') first = true;
                    else first = false;
                }
            }
            tempName = tempName.Trim();
            if (tempName.Length == 0) return "";
            return tempName;
        }

        static public String getStudentCategory(String code)
        {
            if (code == GlobalVariables.newStud) return "New Admission";
            if (code == GlobalVariables.oldStud) return "Old Admission";
            if (code == GlobalVariables.exStud) return "Ex Student";
            if (code == GlobalVariables.provStud) return "Provisional Admission";
            if (code == GlobalVariables.manStud) return "Manual Admission";
            return "";
        }

        static public int actualMonthToSessionMonth(int mt)
        {
            return (mt + 8) % 12 + 1;
        }

        static public String[] inWords(int val)
        {
            String[] temp = new String[1] { "" };
            String w = (NumberToWords(val) + " only").ToUpper();
            if (w.Length > 27)
            {
                temp = new String[2] { "", "" };
            }
            String tempword = "";
            List<String> words = new List<string>();
            int l = 0;
            foreach (char c in w)
            {
                tempword += c;
                if (l == w.Length - 1 || c == ' ')
                {
                    words.Add(tempword);
                    tempword = "";
                }
                l++;
            }
            l = 0;

            for (int i = 0; i < words.Count; i++)
            {
                if (temp[l].Length + words[i].Length <= 27)
                    temp[l] += words[i];
                else
                {
                    l++;
                    temp[l] += words[i];
                }
            }
            return temp;
        }

        static public String NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

    }
}
