namespace JEMS_Fees_Management_System
{
    partial class OtherFeesForm
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
            this.recRef = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.misc = new System.Windows.Forms.TextBox();
            this.mag = new System.Windows.Forms.TextBox();
            this.dupFC = new System.Windows.Forms.TextBox();
            this.dupTC = new System.Windows.Forms.TextBox();
            this.dupMark = new System.Windows.Forms.TextBox();
            this.belt_Tie = new System.Windows.Forms.TextBox();
            this.adForm = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.save = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.entryDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Receipt Reference";
            // 
            // recRef
            // 
            this.recRef.Location = new System.Drawing.Point(116, 38);
            this.recRef.MaxLength = 20;
            this.recRef.Name = "recRef";
            this.recRef.Size = new System.Drawing.Size(104, 20);
            this.recRef.TabIndex = 1;
            this.recRef.TextChanged += new System.EventHandler(this.recRef_TextChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(49, 64);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(49, 90);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "From";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "To";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.total);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.misc);
            this.groupBox1.Controls.Add(this.mag);
            this.groupBox1.Controls.Add(this.dupFC);
            this.groupBox1.Controls.Add(this.dupTC);
            this.groupBox1.Controls.Add(this.dupMark);
            this.groupBox1.Controls.Add(this.belt_Tie);
            this.groupBox1.Controls.Add(this.adForm);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(16, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 253);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fees";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 185);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Miscellaneous";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Magazine";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Dup. Fees Card";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Dup. TC";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Dup. Marksheet";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Belt && Tie && Mono";
            // 
            // misc
            // 
            this.misc.Location = new System.Drawing.Point(112, 182);
            this.misc.MaxLength = 5;
            this.misc.Name = "misc";
            this.misc.Size = new System.Drawing.Size(100, 20);
            this.misc.TabIndex = 7;
            this.misc.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // mag
            // 
            this.mag.Location = new System.Drawing.Point(112, 156);
            this.mag.MaxLength = 5;
            this.mag.Name = "mag";
            this.mag.Size = new System.Drawing.Size(100, 20);
            this.mag.TabIndex = 6;
            this.mag.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // dupFC
            // 
            this.dupFC.Location = new System.Drawing.Point(112, 130);
            this.dupFC.MaxLength = 5;
            this.dupFC.Name = "dupFC";
            this.dupFC.Size = new System.Drawing.Size(100, 20);
            this.dupFC.TabIndex = 5;
            this.dupFC.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // dupTC
            // 
            this.dupTC.Location = new System.Drawing.Point(112, 104);
            this.dupTC.MaxLength = 5;
            this.dupTC.Name = "dupTC";
            this.dupTC.Size = new System.Drawing.Size(100, 20);
            this.dupTC.TabIndex = 4;
            this.dupTC.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // dupMark
            // 
            this.dupMark.Location = new System.Drawing.Point(112, 78);
            this.dupMark.MaxLength = 5;
            this.dupMark.Name = "dupMark";
            this.dupMark.Size = new System.Drawing.Size(100, 20);
            this.dupMark.TabIndex = 3;
            this.dupMark.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // belt_Tie
            // 
            this.belt_Tie.Location = new System.Drawing.Point(112, 52);
            this.belt_Tie.MaxLength = 5;
            this.belt_Tie.Name = "belt_Tie";
            this.belt_Tie.Size = new System.Drawing.Size(100, 20);
            this.belt_Tie.TabIndex = 2;
            this.belt_Tie.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // adForm
            // 
            this.adForm.Location = new System.Drawing.Point(112, 26);
            this.adForm.MaxLength = 5;
            this.adForm.Name = "adForm";
            this.adForm.Size = new System.Drawing.Size(100, 20);
            this.adForm.TabIndex = 1;
            this.adForm.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Admission Form";
            // 
            // save
            // 
            this.save.BackColor = System.Drawing.SystemColors.Highlight;
            this.save.Enabled = false;
            this.save.Location = new System.Drawing.Point(193, 386);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 8;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = false;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(103, 386);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 9;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 211);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Total";
            // 
            // total
            // 
            this.total.Location = new System.Drawing.Point(112, 208);
            this.total.MaxLength = 5;
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Size = new System.Drawing.Size(100, 20);
            this.total.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Entry Date";
            // 
            // entryDate
            // 
            this.entryDate.Location = new System.Drawing.Point(83, 12);
            this.entryDate.Name = "entryDate";
            this.entryDate.Size = new System.Drawing.Size(200, 20);
            this.entryDate.TabIndex = 11;
            // 
            // OtherFeesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 535);
            this.Controls.Add(this.entryDate);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.save);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.recRef);
            this.Controls.Add(this.label1);
            this.Name = "OtherFeesForm";
            this.Text = "Other Fees Register";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OtherFeesForm_FormClosed);
            this.Load += new System.EventHandler(this.OtherFeesForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox recRef;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox misc;
        private System.Windows.Forms.TextBox mag;
        private System.Windows.Forms.TextBox dupFC;
        private System.Windows.Forms.TextBox dupTC;
        private System.Windows.Forms.TextBox dupMark;
        private System.Windows.Forms.TextBox belt_Tie;
        private System.Windows.Forms.TextBox adForm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox total;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker entryDate;
    }
}