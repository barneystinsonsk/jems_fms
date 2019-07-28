namespace JEMS_Fees_Management_System
{
    partial class StudentChangeClass
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
            this.label2 = new System.Windows.Forms.Label();
            this.monthSelect = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.classSelect = new System.Windows.Forms.ComboBox();
            this.Confirm = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.noMonth = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Class";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Reflect changes ";
            // 
            // monthSelect
            // 
            this.monthSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthSelect.FormattingEnabled = true;
            this.monthSelect.Location = new System.Drawing.Point(110, 65);
            this.monthSelect.Name = "monthSelect";
            this.monthSelect.Size = new System.Drawing.Size(67, 21);
            this.monthSelect.TabIndex = 2;
            this.monthSelect.SelectionChangeCommitted += new System.EventHandler(this.monthSelect_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(183, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "onwards";
            // 
            // classSelect
            // 
            this.classSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.classSelect.FormattingEnabled = true;
            this.classSelect.Location = new System.Drawing.Point(110, 29);
            this.classSelect.Name = "classSelect";
            this.classSelect.Size = new System.Drawing.Size(108, 21);
            this.classSelect.TabIndex = 1;
            // 
            // Confirm
            // 
            this.Confirm.BackColor = System.Drawing.SystemColors.Highlight;
            this.Confirm.Location = new System.Drawing.Point(110, 116);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(75, 23);
            this.Confirm.TabIndex = 5;
            this.Confirm.Text = "Confirm";
            this.Confirm.UseVisualStyleBackColor = false;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(191, 116);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 6;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // noMonth
            // 
            this.noMonth.AutoSize = true;
            this.noMonth.ForeColor = System.Drawing.Color.Red;
            this.noMonth.Location = new System.Drawing.Point(236, 68);
            this.noMonth.Name = "noMonth";
            this.noMonth.Size = new System.Drawing.Size(127, 13);
            this.noMonth.TabIndex = 7;
            this.noMonth.Text = "Monthly fees already paid";
            this.noMonth.Visible = false;
            // 
            // StudentChangeClass
            // 
            this.AcceptButton = this.Confirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(384, 151);
            this.Controls.Add(this.noMonth);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.classSelect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.monthSelect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(400, 190);
            this.MinimumSize = new System.Drawing.Size(400, 190);
            this.Name = "StudentChangeClass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Class";
            this.Load += new System.EventHandler(this.StudentChangeClass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox monthSelect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox classSelect;
        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label noMonth;
    }
}