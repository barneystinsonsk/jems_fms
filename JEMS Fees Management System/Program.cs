using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JEMS_Fees_Management_System
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static MainForm mForm;
        public static Boolean kill = false;        
        static Mutex mutex = new Mutex(true,  "{4a454d53-5f41-5050-4c49-434154494f4e}");
        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                mForm = new MainForm();
                Application.Run(mForm);
            }
            else
            {
                MessageBox.Show("Application is already running", "Cannot open Application");
                
            }
        }
    }
}
