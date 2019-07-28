namespace JEMS_Fees_Management_System
{
    partial class RunSqlForm
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
            this.queryBox = new System.Windows.Forms.RichTextBox();
            this.button = new System.Windows.Forms.Button();
            this.display = new System.Windows.Forms.DataGridView();
            this.password = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.display)).BeginInit();
            this.SuspendLayout();
            // 
            // queryBox
            // 
            this.queryBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.queryBox.Location = new System.Drawing.Point(12, 12);
            this.queryBox.Name = "queryBox";
            this.queryBox.Size = new System.Drawing.Size(534, 100);
            this.queryBox.TabIndex = 0;
            this.queryBox.Text = "";
            this.queryBox.TextChanged += new System.EventHandler(this.queryBox_TextChanged);
            // 
            // button
            // 
            this.button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button.Location = new System.Drawing.Point(471, 118);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(75, 23);
            this.button.TabIndex = 1;
            this.button.Text = "Run";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // display
            // 
            this.display.AllowUserToAddRows = false;
            this.display.AllowUserToDeleteRows = false;
            this.display.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.display.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.display.Location = new System.Drawing.Point(12, 147);
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(534, 213);
            this.display.TabIndex = 2;
            // 
            // password
            // 
            this.password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.password.Location = new System.Drawing.Point(265, 120);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(200, 20);
            this.password.TabIndex = 3;
            this.password.UseSystemPasswordChar = true;
            // 
            // RunSqlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 372);
            this.Controls.Add(this.password);
            this.Controls.Add(this.display);
            this.Controls.Add(this.button);
            this.Controls.Add(this.queryBox);
            this.Name = "RunSqlForm";
            this.Text = "RunSqlForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RunSqlForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.display)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox queryBox;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.DataGridView display;
        private System.Windows.Forms.TextBox password;
    }
}