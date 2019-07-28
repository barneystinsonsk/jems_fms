namespace JEMS_Fees_Management_System
{
    partial class ReceiptDateChange
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
            this.label3 = new System.Windows.Forms.Label();
            this.receiptID = new System.Windows.Forms.TextBox();
            this.oldDate = new System.Windows.Forms.TextBox();
            this.newDate = new System.Windows.Forms.DateTimePicker();
            this.save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Receipt ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Old Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "New Date";
            // 
            // receiptID
            // 
            this.receiptID.Location = new System.Drawing.Point(76, 12);
            this.receiptID.MaxLength = 10;
            this.receiptID.Name = "receiptID";
            this.receiptID.Size = new System.Drawing.Size(100, 20);
            this.receiptID.TabIndex = 3;
            this.receiptID.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // oldDate
            // 
            this.oldDate.Location = new System.Drawing.Point(76, 38);
            this.oldDate.Name = "oldDate";
            this.oldDate.ReadOnly = true;
            this.oldDate.Size = new System.Drawing.Size(100, 20);
            this.oldDate.TabIndex = 4;
            // 
            // newDate
            // 
            this.newDate.Location = new System.Drawing.Point(76, 64);
            this.newDate.Name = "newDate";
            this.newDate.Size = new System.Drawing.Size(200, 20);
            this.newDate.TabIndex = 5;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(76, 91);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 6;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // ReceiptDateChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.save);
            this.Controls.Add(this.newDate);
            this.Controls.Add(this.oldDate);
            this.Controls.Add(this.receiptID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ReceiptDateChange";
            this.Text = "Receipt Date Change";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReceiptDateChange_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox receiptID;
        private System.Windows.Forms.TextBox oldDate;
        private System.Windows.Forms.DateTimePicker newDate;
        private System.Windows.Forms.Button save;
    }
}