namespace JEMS_Fees_Management_System
{
    partial class DeleteStudent
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
            this.studentID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.Button();
            this.confirm = new System.Windows.Forms.Button();
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
            // studentID
            // 
            this.studentID.Location = new System.Drawing.Point(76, 12);
            this.studentID.MaxLength = 8;
            this.studentID.Name = "studentID";
            this.studentID.Size = new System.Drawing.Size(100, 20);
            this.studentID.TabIndex = 1;
            this.studentID.TextChanged += new System.EventHandler(this.studentID_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(290, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Warning: Once deleted student record cannot be recreated.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "              All fees record will also be deleted";
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(141, 84);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 4;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // confirm
            // 
            this.confirm.Location = new System.Drawing.Point(222, 84);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(75, 23);
            this.confirm.TabIndex = 5;
            this.confirm.Text = "Confirm";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // DeleteStudent
            // 
            this.AcceptButton = this.cancel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 119);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.studentID);
            this.Controls.Add(this.label1);
            this.Name = "DeleteStudent";
            this.Text = "Delete Student Record";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox studentID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Label label1;
    }
}