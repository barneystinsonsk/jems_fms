using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JEMS_Fees_Management_System
{
    public partial class PasswordBox : Form
    {
        public Boolean passwordCorrect;
        private String thePassword = "rocket";

        public PasswordBox()
        {
            InitializeComponent();
            passwordCorrect = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            password.PasswordChar = (checkBox1.Checked ? '\0' : '*');
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (password.Text == thePassword) passwordCorrect = true;
            else
                MessageBox.Show("Cannot Continue", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            passwordCorrect = false;
            this.Close();
        }
    }
}
