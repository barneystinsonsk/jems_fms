namespace JEMS_Fees_Management_System
{
    partial class WarnFeesForm
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
            this.warnDate = new System.Windows.Forms.NumericUpDown();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.warnDate)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Warn Date";
            // 
            // warnDate
            // 
            this.warnDate.Location = new System.Drawing.Point(77, 12);
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
            this.warnDate.TabIndex = 1;
            this.warnDate.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(118, 48);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 2;
            this.ok.Text = "Ok";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(15, 48);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // WarnFeesDialog
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 89);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.warnDate);
            this.Controls.Add(this.label1);
            this.Name = "WarnFeesDialog";
            this.Text = "Warn Fees Date";
            this.Load += new System.EventHandler(this.WarnFeesDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.warnDate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown warnDate;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
    }
}