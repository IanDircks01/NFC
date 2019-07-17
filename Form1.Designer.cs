namespace NFC
{
    partial class Form1
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
            this.WriteButton = new System.Windows.Forms.Button();
            this.WriteInputField = new System.Windows.Forms.TextBox();
            this.StatusText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // WriteButton
            // 
            this.WriteButton.Location = new System.Drawing.Point(241, 247);
            this.WriteButton.Name = "WriteButton";
            this.WriteButton.Size = new System.Drawing.Size(262, 23);
            this.WriteButton.TabIndex = 0;
            this.WriteButton.Text = "Write To NFC Tag";
            this.WriteButton.UseVisualStyleBackColor = true;
            this.WriteButton.Click += new System.EventHandler(this.Button1_Click);
            // 
            // WriteInputField
            // 
            this.WriteInputField.Location = new System.Drawing.Point(241, 221);
            this.WriteInputField.Name = "WriteInputField";
            this.WriteInputField.Size = new System.Drawing.Size(262, 20);
            this.WriteInputField.TabIndex = 1;
            // 
            // StatusText
            // 
            this.StatusText.AutoSize = true;
            this.StatusText.Location = new System.Drawing.Point(13, 13);
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(89, 13);
            this.StatusText.TabIndex = 2;
            this.StatusText.Text = "Status: --loading--";
            this.StatusText.Click += new System.EventHandler(this.Label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.StatusText);
            this.Controls.Add(this.WriteInputField);
            this.Controls.Add(this.WriteButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button WriteButton;
        private System.Windows.Forms.TextBox WriteInputField;
        private System.Windows.Forms.Label StatusText;
    }
}

