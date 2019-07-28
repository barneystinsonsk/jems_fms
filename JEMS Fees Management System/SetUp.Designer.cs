namespace JEMS_Fees_Management_System
{
    partial class SetUp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public bool AllSet = false;

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
            this.dbConnectPanel = new System.Windows.Forms.Panel();
            this.db_server_invalid = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.db_server = new System.Windows.Forms.TextBox();
            this.db_name_invalid = new System.Windows.Forms.Label();
            this.db_password_invalid = new System.Windows.Forms.Label();
            this.db_id_invalid = new System.Windows.Forms.Label();
            this.dbconnect_test = new System.Windows.Forms.Button();
            this.dbconnect_next = new System.Windows.Forms.Button();
            this.db_timeout = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.db_name = new System.Windows.Forms.TextBox();
            this.db_password = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.db_id = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.terminalPanel = new System.Windows.Forms.Panel();
            this.terminalPrevious = new System.Windows.Forms.Button();
            this.terminalDone = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.t_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentTerminal = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dbConnectPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.db_timeout)).BeginInit();
            this.terminalPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dbConnectPanel
            // 
            this.dbConnectPanel.Controls.Add(this.db_server_invalid);
            this.dbConnectPanel.Controls.Add(this.label8);
            this.dbConnectPanel.Controls.Add(this.db_server);
            this.dbConnectPanel.Controls.Add(this.db_name_invalid);
            this.dbConnectPanel.Controls.Add(this.db_password_invalid);
            this.dbConnectPanel.Controls.Add(this.db_id_invalid);
            this.dbConnectPanel.Controls.Add(this.dbconnect_test);
            this.dbConnectPanel.Controls.Add(this.dbconnect_next);
            this.dbConnectPanel.Controls.Add(this.db_timeout);
            this.dbConnectPanel.Controls.Add(this.label7);
            this.dbConnectPanel.Controls.Add(this.label6);
            this.dbConnectPanel.Controls.Add(this.db_name);
            this.dbConnectPanel.Controls.Add(this.db_password);
            this.dbConnectPanel.Controls.Add(this.label5);
            this.dbConnectPanel.Controls.Add(this.label4);
            this.dbConnectPanel.Controls.Add(this.db_id);
            this.dbConnectPanel.Controls.Add(this.label3);
            this.dbConnectPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbConnectPanel.Location = new System.Drawing.Point(0, 0);
            this.dbConnectPanel.Name = "dbConnectPanel";
            this.dbConnectPanel.Size = new System.Drawing.Size(283, 261);
            this.dbConnectPanel.TabIndex = 1;
            // 
            // db_server_invalid
            // 
            this.db_server_invalid.AutoSize = true;
            this.db_server_invalid.ForeColor = System.Drawing.Color.Red;
            this.db_server_invalid.Location = new System.Drawing.Point(218, 37);
            this.db_server_invalid.Name = "db_server_invalid";
            this.db_server_invalid.Size = new System.Drawing.Size(38, 13);
            this.db_server_invalid.TabIndex = 17;
            this.db_server_invalid.Text = "Invalid";
            this.db_server_invalid.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Server Name";
            // 
            // db_server
            // 
            this.db_server.Location = new System.Drawing.Point(112, 34);
            this.db_server.Name = "db_server";
            this.db_server.Size = new System.Drawing.Size(100, 20);
            this.db_server.TabIndex = 1;
            this.db_server.TextChanged += new System.EventHandler(this.dbConnectMod);
            // 
            // db_name_invalid
            // 
            this.db_name_invalid.AutoSize = true;
            this.db_name_invalid.ForeColor = System.Drawing.Color.Red;
            this.db_name_invalid.Location = new System.Drawing.Point(218, 117);
            this.db_name_invalid.Name = "db_name_invalid";
            this.db_name_invalid.Size = new System.Drawing.Size(38, 13);
            this.db_name_invalid.TabIndex = 14;
            this.db_name_invalid.Text = "Invalid";
            this.db_name_invalid.Visible = false;
            // 
            // db_password_invalid
            // 
            this.db_password_invalid.AutoSize = true;
            this.db_password_invalid.ForeColor = System.Drawing.Color.Red;
            this.db_password_invalid.Location = new System.Drawing.Point(218, 90);
            this.db_password_invalid.Name = "db_password_invalid";
            this.db_password_invalid.Size = new System.Drawing.Size(38, 13);
            this.db_password_invalid.TabIndex = 13;
            this.db_password_invalid.Text = "Invalid";
            this.db_password_invalid.Visible = false;
            // 
            // db_id_invalid
            // 
            this.db_id_invalid.AutoSize = true;
            this.db_id_invalid.ForeColor = System.Drawing.Color.Red;
            this.db_id_invalid.Location = new System.Drawing.Point(218, 63);
            this.db_id_invalid.Name = "db_id_invalid";
            this.db_id_invalid.Size = new System.Drawing.Size(38, 13);
            this.db_id_invalid.TabIndex = 12;
            this.db_id_invalid.Text = "Invalid";
            this.db_id_invalid.Visible = false;
            // 
            // dbconnect_test
            // 
            this.dbconnect_test.Location = new System.Drawing.Point(83, 221);
            this.dbconnect_test.Name = "dbconnect_test";
            this.dbconnect_test.Size = new System.Drawing.Size(108, 23);
            this.dbconnect_test.TabIndex = 6;
            this.dbconnect_test.Text = "Test Connection";
            this.dbconnect_test.UseVisualStyleBackColor = true;
            this.dbconnect_test.Click += new System.EventHandler(this.dbconnect_test_Click);
            // 
            // dbconnect_next
            // 
            this.dbconnect_next.BackColor = System.Drawing.SystemColors.Highlight;
            this.dbconnect_next.Location = new System.Drawing.Point(197, 221);
            this.dbconnect_next.Name = "dbconnect_next";
            this.dbconnect_next.Size = new System.Drawing.Size(75, 23);
            this.dbconnect_next.TabIndex = 7;
            this.dbconnect_next.Text = "Next";
            this.dbconnect_next.UseVisualStyleBackColor = false;
            this.dbconnect_next.Click += new System.EventHandler(this.dbconnect_next_Click);
            // 
            // db_timeout
            // 
            this.db_timeout.Location = new System.Drawing.Point(112, 142);
            this.db_timeout.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.db_timeout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.db_timeout.Name = "db_timeout";
            this.db_timeout.Size = new System.Drawing.Size(40, 20);
            this.db_timeout.TabIndex = 5;
            this.db_timeout.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.db_timeout.ValueChanged += new System.EventHandler(this.dbConnectMod);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Database Timeout";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Database Name";
            // 
            // db_name
            // 
            this.db_name.Location = new System.Drawing.Point(112, 114);
            this.db_name.Name = "db_name";
            this.db_name.Size = new System.Drawing.Size(100, 20);
            this.db_name.TabIndex = 4;
            this.db_name.TextChanged += new System.EventHandler(this.dbConnectMod);
            // 
            // db_password
            // 
            this.db_password.Location = new System.Drawing.Point(112, 87);
            this.db_password.Name = "db_password";
            this.db_password.Size = new System.Drawing.Size(100, 20);
            this.db_password.TabIndex = 3;
            this.db_password.TextChanged += new System.EventHandler(this.dbConnectMod);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "User ID";
            // 
            // db_id
            // 
            this.db_id.Location = new System.Drawing.Point(112, 60);
            this.db_id.Name = "db_id";
            this.db_id.Size = new System.Drawing.Size(100, 20);
            this.db_id.TabIndex = 2;
            this.db_id.TextChanged += new System.EventHandler(this.dbConnectMod);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Database Connection";
            // 
            // terminalPanel
            // 
            this.terminalPanel.Controls.Add(this.label1);
            this.terminalPanel.Controls.Add(this.currentTerminal);
            this.terminalPanel.Controls.Add(this.terminalPrevious);
            this.terminalPanel.Controls.Add(this.terminalDone);
            this.terminalPanel.Controls.Add(this.dataGridView1);
            this.terminalPanel.Controls.Add(this.label2);
            this.terminalPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.terminalPanel.Location = new System.Drawing.Point(0, 0);
            this.terminalPanel.Name = "terminalPanel";
            this.terminalPanel.Size = new System.Drawing.Size(283, 261);
            this.terminalPanel.TabIndex = 2;
            // 
            // terminalPrevious
            // 
            this.terminalPrevious.Location = new System.Drawing.Point(116, 221);
            this.terminalPrevious.Name = "terminalPrevious";
            this.terminalPrevious.Size = new System.Drawing.Size(75, 23);
            this.terminalPrevious.TabIndex = 11;
            this.terminalPrevious.Text = "Previous";
            this.terminalPrevious.UseVisualStyleBackColor = true;
            this.terminalPrevious.Click += new System.EventHandler(this.terminalPrevious_Click);
            // 
            // terminalDone
            // 
            this.terminalDone.BackColor = System.Drawing.SystemColors.Highlight;
            this.terminalDone.Location = new System.Drawing.Point(197, 221);
            this.terminalDone.Name = "terminalDone";
            this.terminalDone.Size = new System.Drawing.Size(75, 23);
            this.terminalDone.TabIndex = 10;
            this.terminalDone.Text = "Done";
            this.terminalDone.UseVisualStyleBackColor = false;
            this.terminalDone.Click += new System.EventHandler(this.terminalDone_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.t_id,
            this.t_name});
            this.dataGridView1.Location = new System.Drawing.Point(16, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 25;
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.TerminalCellModified);
            this.dataGridView1.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.TerminalCellModification);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Terminals";
            // 
            // t_id
            // 
            this.t_id.HeaderText = "Terminal ID";
            this.t_id.Name = "t_id";
            this.t_id.ReadOnly = true;
            this.t_id.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.t_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // t_name
            // 
            this.t_name.HeaderText = "Terminal Name";
            this.t_name.MaxInputLength = 15;
            this.t_name.Name = "t_name";
            this.t_name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.t_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.t_name.Width = 110;
            // 
            // currentTerminal
            // 
            this.currentTerminal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.currentTerminal.FormattingEnabled = true;
            this.currentTerminal.Location = new System.Drawing.Point(110, 193);
            this.currentTerminal.Name = "currentTerminal";
            this.currentTerminal.Size = new System.Drawing.Size(121, 21);
            this.currentTerminal.TabIndex = 12;
            this.currentTerminal.SelectedIndexChanged += new System.EventHandler(this.currentTerminal_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Current Terminal";
            // 
            // SetUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 261);
            this.Controls.Add(this.terminalPanel);
            this.Controls.Add(this.dbConnectPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetUp";
            this.dbConnectPanel.ResumeLayout(false);
            this.dbConnectPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.db_timeout)).EndInit();
            this.terminalPanel.ResumeLayout(false);
            this.terminalPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        
        #endregion

        private System.Windows.Forms.Panel dbConnectPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox db_id;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox db_password;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox db_name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown db_timeout;
        private System.Windows.Forms.Button dbconnect_test;
        private System.Windows.Forms.Button dbconnect_next;
        private System.Windows.Forms.Label db_name_invalid;
        private System.Windows.Forms.Label db_password_invalid;
        private System.Windows.Forms.Label db_id_invalid;
        private System.Windows.Forms.Label db_server_invalid;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox db_server;
        private System.Windows.Forms.Panel terminalPanel;
        private System.Windows.Forms.Button terminalPrevious;
        private System.Windows.Forms.Button terminalDone;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox currentTerminal;
        private System.Windows.Forms.DataGridViewTextBoxColumn t_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn t_name;

    }
}