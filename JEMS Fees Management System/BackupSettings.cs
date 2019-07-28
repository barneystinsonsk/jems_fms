using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace JEMS_Fees_Management_System
{
    public partial class BackupSettings : Form
    {
        String backupFolder = "jems_database_backup\\";
        Boolean ready = false;

        public BackupSettings()
        {
            InitializeComponent();
        }

        private void BackupSettings_Load(object sender, EventArgs e)
        {   
            backupPath.Text = GlobalVariables.backupFolder;
            if (!Directory.Exists(backupPath.Text)) save.Enabled = false;
            ready = true;
        }

        private void backupPath_TextChanged(object sender, EventArgs e)
        {
            if (!ready) return;

            ready = false;

            backupPath.Text = backupPath.Text.Trim();
            backupPath.SelectionStart = backupPath.TextLength;
            
            if (!Directory.Exists(backupPath.Text))
            {
                save.Enabled = false;
                ready = true;
                return;
            }
            else save.Enabled = true;

            if (backupPath.Text.Trim().Substring(backupPath.TextLength - 1) != "\\")
                backupPath.Text += "\\";

                int folderLenght = backupFolder.Length;
            if (backupPath.TextLength > folderLenght)
            {
                if(backupPath.Text.Substring(backupPath.TextLength - folderLenght) != backupFolder)
                {
                    DialogResult dr = MessageBox.Show("Create new folder '" + backupFolder + "' at specified location?", "Create new Folder", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        string path = backupPath.Text + backupFolder;
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                            MessageBox.Show("Folder Created");
                        }
                        backupPath.Text += backupFolder;
                    }
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("Create new folder '" + backupFolder + "' at specified location?", "Create new Folder", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    string path = backupPath.Text + backupFolder;
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                        MessageBox.Show("Folder Created");
                    }
                    backupPath.Text += backupFolder;
                }
            }

            ready = true;
        }

        private void selectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            String text = backupPath.Text;
            if (result == DialogResult.OK)
            {
                backupPath.Text = fbd.SelectedPath;
            }
            else
                backupPath_TextChanged(null, null);
        }

        private void save_Click(object sender, EventArgs e)
        {

            GlobalVariables.backupFolder = backupPath.Text.Trim();
                        
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
                writer.WriteElementString("limitMenuItems", (GlobalVariables.limitMenuItems)? "true":"false");
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
