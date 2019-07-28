namespace JEMS_Fees_Management_System
{
    partial class SessionConfig
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
            this.currentSession = new System.Windows.Forms.TextBox();
            this.endSessionLabel = new System.Windows.Forms.Label();
            this.warnFees = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lateFees = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.warnDate = new System.Windows.Forms.NumericUpDown();
            this.sessionDone = new System.Windows.Forms.Button();
            this.warn_fees_invalid = new System.Windows.Forms.Label();
            this.late_fees_invalid = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.warnDate)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Session";
            // 
            // currentSession
            // 
            this.currentSession.Location = new System.Drawing.Point(130, 13);
            this.currentSession.MaxLength = 4;
            this.currentSession.Name = "currentSession";
            this.currentSession.Size = new System.Drawing.Size(35, 20);
            this.currentSession.TabIndex = 1;
            this.currentSession.TextChanged += new System.EventHandler(this.currentSession_TextChanged);
            // 
            // endSessionLabel
            // 
            this.endSessionLabel.AutoSize = true;
            this.endSessionLabel.Location = new System.Drawing.Point(171, 16);
            this.endSessionLabel.Name = "endSessionLabel";
            this.endSessionLabel.Size = new System.Drawing.Size(36, 13);
            this.endSessionLabel.TabIndex = 2;
            this.endSessionLabel.Text = "-20XX";
            // 
            // warnFees
            // 
            this.warnFees.Location = new System.Drawing.Point(130, 40);
            this.warnFees.MaxLength = 4;
            this.warnFees.Name = "warnFees";
            this.warnFees.Size = new System.Drawing.Size(35, 20);
            this.warnFees.TabIndex = 2;
            this.warnFees.TextChanged += new System.EventHandler(this.warnFees_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Warning Fees";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Warn Date";
            // 
            // lateFees
            // 
            this.lateFees.Location = new System.Drawing.Point(130, 92);
            this.lateFees.MaxLength = 4;
            this.lateFees.Name = "lateFees";
            this.lateFees.Size = new System.Drawing.Size(35, 20);
            this.lateFees.TabIndex = 4;
            this.lateFees.TextChanged += new System.EventHandler(this.lateFees_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Late Fees";
            // 
            // warnDate
            // 
            this.warnDate.Location = new System.Drawing.Point(130, 66);
            this.warnDate.Maximum = new decimal(new int[] {
            27,
            0,
            0,
            0});
            this.warnDate.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.warnDate.Name = "warnDate";
            this.warnDate.Size = new System.Drawing.Size(40, 20);
            this.warnDate.TabIndex = 3;
            this.warnDate.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // sessionDone
            // 
            this.sessionDone.BackColor = System.Drawing.SystemColors.Highlight;
            this.sessionDone.Location = new System.Drawing.Point(130, 130);
            this.sessionDone.Name = "sessionDone";
            this.sessionDone.Size = new System.Drawing.Size(75, 23);
            this.sessionDone.TabIndex = 10;
            this.sessionDone.Text = "Done";
            this.sessionDone.UseVisualStyleBackColor = false;
            this.sessionDone.Click += new System.EventHandler(this.sessionDone_Click);
            // 
            // warn_fees_invalid
            // 
            this.warn_fees_invalid.AutoSize = true;
            this.warn_fees_invalid.ForeColor = System.Drawing.Color.Red;
            this.warn_fees_invalid.Location = new System.Drawing.Point(171, 43);
            this.warn_fees_invalid.Name = "warn_fees_invalid";
            this.warn_fees_invalid.Size = new System.Drawing.Size(38, 13);
            this.warn_fees_invalid.TabIndex = 20;
            this.warn_fees_invalid.Text = "Invalid";
            this.warn_fees_invalid.Visible = false;
            // 
            // late_fees_invalid
            // 
            this.late_fees_invalid.AutoSize = true;
            this.late_fees_invalid.ForeColor = System.Drawing.Color.Red;
            this.late_fees_invalid.Location = new System.Drawing.Point(171, 94);
            this.late_fees_invalid.Name = "late_fees_invalid";
            this.late_fees_invalid.Size = new System.Drawing.Size(38, 13);
            this.late_fees_invalid.TabIndex = 22;
            this.late_fees_invalid.Text = "Invalid";
            this.late_fees_invalid.Visible = false;
            // 
            // SessionConfig
            // 
            this.AcceptButton = this.sessionDone;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 165);
            this.Controls.Add(this.late_fees_invalid);
            this.Controls.Add(this.warn_fees_invalid);
            this.Controls.Add(this.sessionDone);
            this.Controls.Add(this.warnDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lateFees);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.warnFees);
            this.Controls.Add(this.endSessionLabel);
            this.Controls.Add(this.currentSession);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SessionConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Session Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SessionConfig_FormClosed);
            this.Load += new System.EventHandler(this.SessionConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.warnDate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox currentSession;
        private System.Windows.Forms.Label endSessionLabel;
        private System.Windows.Forms.TextBox warnFees;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lateFees;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown warnDate;
        private System.Windows.Forms.Button sessionDone;
        private System.Windows.Forms.Label warn_fees_invalid;
        private System.Windows.Forms.Label late_fees_invalid;
    }
}