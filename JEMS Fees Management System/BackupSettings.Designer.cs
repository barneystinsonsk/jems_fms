namespace JEMS_Fees_Management_System
{
    partial class BackupSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.backupPath = new System.Windows.Forms.TextBox();
            this.selectFolder = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Backup Folder";
            // 
            // backupPath
            // 
            this.backupPath.Location = new System.Drawing.Point(95, 24);
            this.backupPath.Name = "backupPath";
            this.backupPath.Size = new System.Drawing.Size(254, 20);
            this.backupPath.TabIndex = 1;
            this.backupPath.TextChanged += new System.EventHandler(this.backupPath_TextChanged);
            // 
            // selectFolder
            // 
            this.selectFolder.Location = new System.Drawing.Point(355, 22);
            this.selectFolder.Name = "selectFolder";
            this.selectFolder.Size = new System.Drawing.Size(25, 23);
            this.selectFolder.TabIndex = 2;
            this.selectFolder.Text = "...";
            this.selectFolder.UseVisualStyleBackColor = true;
            this.selectFolder.Click += new System.EventHandler(this.selectFolder_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(305, 81);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 3;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(224, 81);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 4;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // BackupSettings
            // 
            this.AcceptButton = this.save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 116);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.save);
            this.Controls.Add(this.selectFolder);
            this.Controls.Add(this.backupPath);
            this.Controls.Add(this.label1);
            this.Name = "BackupSettings";
            this.Text = "Backup Settings";
            this.Load += new System.EventHandler(this.BackupSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox backupPath;
        private System.Windows.Forms.Button selectFolder;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button cancel;
    }
}