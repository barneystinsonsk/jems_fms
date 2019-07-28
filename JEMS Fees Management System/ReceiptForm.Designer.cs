namespace JEMS_Fees_Management_System
{
    partial class ReceiptForm
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
            this.receiptID = new System.Windows.Forms.TextBox();
            this.receiptDisplay = new System.Windows.Forms.RichTextBox();
            this.print = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
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
            // receiptID
            // 
            this.receiptID.Location = new System.Drawing.Point(76, 12);
            this.receiptID.MaxLength = 10;
            this.receiptID.Name = "receiptID";
            this.receiptID.Size = new System.Drawing.Size(100, 20);
            this.receiptID.TabIndex = 1;
            this.receiptID.TextChanged += new System.EventHandler(this.receiptID_TextChanged);
            // 
            // receiptDisplay
            // 
            this.receiptDisplay.BackColor = System.Drawing.Color.White;
            this.receiptDisplay.Enabled = false;
            this.receiptDisplay.Location = new System.Drawing.Point(15, 39);
            this.receiptDisplay.Name = "receiptDisplay";
            this.receiptDisplay.ReadOnly = true;
            this.receiptDisplay.Size = new System.Drawing.Size(400, 600);
            this.receiptDisplay.TabIndex = 2;
            this.receiptDisplay.Text = "";
            // 
            // print
            // 
            this.print.Enabled = false;
            this.print.Location = new System.Drawing.Point(197, 10);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(75, 23);
            this.print.TabIndex = 3;
            this.print.Text = "Print";
            this.print.UseVisualStyleBackColor = true;
            this.print.Click += new System.EventHandler(this.print_Click);
            // 
            // delete
            // 
            this.delete.Enabled = false;
            this.delete.Location = new System.Drawing.Point(278, 10);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 23);
            this.delete.TabIndex = 4;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // ReceiptForm
            // 
            this.AcceptButton = this.print;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 741);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.print);
            this.Controls.Add(this.receiptDisplay);
            this.Controls.Add(this.receiptID);
            this.Controls.Add(this.label1);
            this.Name = "ReceiptForm";
            this.Text = "Receipt Form";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReceiptForm_FormClosed);
            this.Load += new System.EventHandler(this.ReceiptForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox receiptID;
        private System.Windows.Forms.RichTextBox receiptDisplay;
        private System.Windows.Forms.Button print;
        private System.Windows.Forms.Button delete;
    }
}