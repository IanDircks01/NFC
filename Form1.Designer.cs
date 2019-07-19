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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.WriteButton = new System.Windows.Forms.Button();
            this.WriteInputField = new System.Windows.Forms.TextBox();
            this.StatusText = new System.Windows.Forms.Label();
            this.ReadButton = new System.Windows.Forms.Button();
            this.ReadDataBox = new System.Windows.Forms.TextBox();
            this.ClearReadButton = new System.Windows.Forms.Button();
            this.ComTextBox = new System.Windows.Forms.TextBox();
            this.ComChoiseText = new System.Windows.Forms.Label();
            this.ListComs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WriteButton
            // 
            resources.ApplyResources(this.WriteButton, "WriteButton");
            this.WriteButton.Name = "WriteButton";
            this.WriteButton.UseVisualStyleBackColor = true;
            this.WriteButton.Click += new System.EventHandler(this.Button1_Click);
            // 
            // WriteInputField
            // 
            resources.ApplyResources(this.WriteInputField, "WriteInputField");
            this.WriteInputField.Name = "WriteInputField";
            // 
            // StatusText
            // 
            resources.ApplyResources(this.StatusText, "StatusText");
            this.StatusText.Name = "StatusText";
            this.StatusText.Click += new System.EventHandler(this.Label1_Click);
            // 
            // ReadButton
            // 
            resources.ApplyResources(this.ReadButton, "ReadButton");
            this.ReadButton.Name = "ReadButton";
            this.ReadButton.UseVisualStyleBackColor = true;
            this.ReadButton.Click += new System.EventHandler(this.ReadButton_Click);
            // 
            // ReadDataBox
            // 
            this.ReadDataBox.BackColor = System.Drawing.SystemColors.InactiveBorder;
            resources.ApplyResources(this.ReadDataBox, "ReadDataBox");
            this.ReadDataBox.Name = "ReadDataBox";
            this.ReadDataBox.ReadOnly = true;
            this.ReadDataBox.TextChanged += new System.EventHandler(this.ReadDataBox_TextChanged);
            // 
            // ClearReadButton
            // 
            resources.ApplyResources(this.ClearReadButton, "ClearReadButton");
            this.ClearReadButton.Name = "ClearReadButton";
            this.ClearReadButton.UseVisualStyleBackColor = true;
            this.ClearReadButton.Click += new System.EventHandler(this.ClearReadButton_Click);
            // 
            // ComTextBox
            // 
            resources.ApplyResources(this.ComTextBox, "ComTextBox");
            this.ComTextBox.Name = "ComTextBox";
            // 
            // ComChoiseText
            // 
            resources.ApplyResources(this.ComChoiseText, "ComChoiseText");
            this.ComChoiseText.Name = "ComChoiseText";
            this.ComChoiseText.Click += new System.EventHandler(this.Label1_Click_1);
            // 
            // ListComs
            // 
            resources.ApplyResources(this.ListComs, "ListComs");
            this.ListComs.Name = "ListComs";
            this.ListComs.UseVisualStyleBackColor = true;
            this.ListComs.Click += new System.EventHandler(this.ListComs_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ListComs);
            this.Controls.Add(this.ComChoiseText);
            this.Controls.Add(this.ComTextBox);
            this.Controls.Add(this.ClearReadButton);
            this.Controls.Add(this.ReadDataBox);
            this.Controls.Add(this.ReadButton);
            this.Controls.Add(this.StatusText);
            this.Controls.Add(this.WriteInputField);
            this.Controls.Add(this.WriteButton);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button WriteButton;
        private System.Windows.Forms.TextBox WriteInputField;
        private System.Windows.Forms.Label StatusText;
        private System.Windows.Forms.Button ReadButton;
        private System.Windows.Forms.TextBox ReadDataBox;
        private System.Windows.Forms.Button ClearReadButton;
        private System.Windows.Forms.TextBox ComTextBox;
        private System.Windows.Forms.Label ComChoiseText;
        private System.Windows.Forms.Button ListComs;
    }
}

