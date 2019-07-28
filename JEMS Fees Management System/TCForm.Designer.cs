namespace JEMS_Fees_Management_System
{
    partial class TCForm
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
            this.studID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.currClass = new System.Windows.Forms.TextBox();
            this.section = new System.Windows.Forms.TextBox();
            this.currSession = new System.Windows.Forms.TextBox();
            this.adClass = new System.Windows.Forms.TextBox();
            this.adSession = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.confirm = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.studCat = new System.Windows.Forms.TextBox();
            this.feesStatus = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.reason = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tcNo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student ID";
            // 
            // studID
            // 
            this.studID.Location = new System.Drawing.Point(100, 12);
            this.studID.MaxLength = 8;
            this.studID.Name = "studID";
            this.studID.Size = new System.Drawing.Size(100, 20);
            this.studID.TabIndex = 1;
            this.studID.TextChanged += new System.EventHandler(this.studentID_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(100, 38);
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Size = new System.Drawing.Size(150, 20);
            this.name.TabIndex = 3;
            this.name.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Father\'s Name";
            // 
            // fName
            // 
            this.fName.Location = new System.Drawing.Point(100, 64);
            this.fName.Name = "fName";
            this.fName.ReadOnly = true;
            this.fName.Size = new System.Drawing.Size(150, 20);
            this.fName.TabIndex = 5;
            this.fName.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(256, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mother\'s Name";
            // 
            // mName
            // 
            this.mName.Location = new System.Drawing.Point(340, 64);
            this.mName.Name = "mName";
            this.mName.ReadOnly = true;
            this.mName.Size = new System.Drawing.Size(150, 20);
            this.mName.TabIndex = 7;
            this.mName.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(496, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Guardian\'s Name";
            // 
            // gName
            // 
            this.gName.Location = new System.Drawing.Point(590, 64);
            this.gName.Name = "gName";
            this.gName.ReadOnly = true;
            this.gName.Size = new System.Drawing.Size(150, 20);
            this.gName.TabIndex = 9;
            this.gName.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Class";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(218, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Section";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(315, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Current Session";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Admission Class";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(302, 119);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Admission Session";
            // 
            // currClass
            // 
            this.currClass.Location = new System.Drawing.Point(100, 90);
            this.currClass.Name = "currClass";
            this.currClass.ReadOnly = true;
            this.currClass.Size = new System.Drawing.Size(100, 20);
            this.currClass.TabIndex = 15;
            this.currClass.TabStop = false;
            // 
            // section
            // 
            this.section.Location = new System.Drawing.Point(267, 90);
            this.section.Name = "section";
            this.section.ReadOnly = true;
            this.section.Size = new System.Drawing.Size(29, 20);
            this.section.TabIndex = 16;
            this.section.TabStop = false;
            // 
            // currSession
            // 
            this.currSession.Location = new System.Drawing.Point(402, 90);
            this.currSession.Name = "currSession";
            this.currSession.ReadOnly = true;
            this.currSession.Size = new System.Drawing.Size(100, 20);
            this.currSession.TabIndex = 17;
            this.currSession.TabStop = false;
            // 
            // adClass
            // 
            this.adClass.Location = new System.Drawing.Point(100, 116);
            this.adClass.Name = "adClass";
            this.adClass.ReadOnly = true;
            this.adClass.Size = new System.Drawing.Size(100, 20);
            this.adClass.TabIndex = 18;
            this.adClass.TabStop = false;
            // 
            // adSession
            // 
            this.adSession.Location = new System.Drawing.Point(402, 116);
            this.adSession.Name = "adSession";
            this.adSession.ReadOnly = true;
            this.adSession.Size = new System.Drawing.Size(100, 20);
            this.adSession.TabIndex = 19;
            this.adSession.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 145);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Fees Status";
            // 
            // confirm
            // 
            this.confirm.BackColor = System.Drawing.SystemColors.Highlight;
            this.confirm.Location = new System.Drawing.Point(348, 258);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(100, 23);
            this.confirm.TabIndex = 22;
            this.confirm.Text = "Generate TC";
            this.confirm.UseVisualStyleBackColor = false;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(267, 258);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 23;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(517, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Student Category";
            // 
            // studCat
            // 
            this.studCat.Location = new System.Drawing.Point(612, 90);
            this.studCat.Name = "studCat";
            this.studCat.ReadOnly = true;
            this.studCat.Size = new System.Drawing.Size(100, 20);
            this.studCat.TabIndex = 25;
            this.studCat.TabStop = false;
            // 
            // feesStatus
            // 
            this.feesStatus.AutoSize = true;
            this.feesStatus.Location = new System.Drawing.Point(103, 145);
            this.feesStatus.Name = "feesStatus";
            this.feesStatus.Size = new System.Drawing.Size(0, 13);
            this.feesStatus.TabIndex = 26;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(100, 142);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(170, 20);
            this.textBox1.TabIndex = 27;
            this.textBox1.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 172);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "Reason for TC";
            // 
            // reason
            // 
            this.reason.Enabled = false;
            this.reason.Location = new System.Drawing.Point(100, 169);
            this.reason.MaxLength = 30;
            this.reason.Name = "reason";
            this.reason.Size = new System.Drawing.Size(200, 20);
            this.reason.TabIndex = 29;
            this.reason.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 199);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 13);
            this.label14.TabIndex = 30;
            this.label14.Text = "TC Number";
            // 
            // tcNo
            // 
            this.tcNo.Location = new System.Drawing.Point(100, 196);
            this.tcNo.MaxLength = 10;
            this.tcNo.Name = "tcNo";
            this.tcNo.Size = new System.Drawing.Size(100, 20);
            this.tcNo.TabIndex = 31;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 229);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 13);
            this.label15.TabIndex = 32;
            this.label15.Text = "Date";
            // 
            // date
            // 
            this.date.Location = new System.Drawing.Point(100, 223);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(200, 20);
            this.date.TabIndex = 33;
            // 
            // TCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 321);
            this.Controls.Add(this.date);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tcNo);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.reason);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.feesStatus);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.studCat);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.adSession);
            this.Controls.Add(this.adClass);
            this.Controls.Add(this.currSession);
            this.Controls.Add(this.section);
            this.Controls.Add(this.currClass);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.gName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.studID);
            this.Controls.Add(this.label1);
            this.Name = "TCForm";
            this.Text = "TC Form";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TCForm_FormClosed);
            this.Load += new System.EventHandler(this.TCForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox studID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox fName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox gName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox currClass;
        private System.Windows.Forms.TextBox section;
        private System.Windows.Forms.TextBox currSession;
        private System.Windows.Forms.TextBox adClass;
        private System.Windows.Forms.TextBox adSession;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox studCat;
        private System.Windows.Forms.Label feesStatus;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox reason;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tcNo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker date;
    }
}