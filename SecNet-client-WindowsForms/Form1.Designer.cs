namespace SecNet
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
            this.comPortField = new System.Windows.Forms.TextBox();
            this.comPortlbl = new System.Windows.Forms.Label();
            this.baudRateLbl = new System.Windows.Forms.Label();
            this.baudRateField = new System.Windows.Forms.TextBox();
            this.conectBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comPortField
            // 
            this.comPortField.Location = new System.Drawing.Point(24, 47);
            this.comPortField.Name = "comPortField";
            this.comPortField.Size = new System.Drawing.Size(90, 20);
            this.comPortField.TabIndex = 0;
            // 
            // comPortlbl
            // 
            this.comPortlbl.AutoSize = true;
            this.comPortlbl.Location = new System.Drawing.Point(24, 28);
            this.comPortlbl.Name = "comPortlbl";
            this.comPortlbl.Size = new System.Drawing.Size(52, 13);
            this.comPortlbl.TabIndex = 1;
            this.comPortlbl.Text = "COM port";
            // 
            // baudRateLbl
            // 
            this.baudRateLbl.AutoSize = true;
            this.baudRateLbl.Location = new System.Drawing.Point(163, 28);
            this.baudRateLbl.Name = "baudRateLbl";
            this.baudRateLbl.Size = new System.Drawing.Size(53, 13);
            this.baudRateLbl.TabIndex = 3;
            this.baudRateLbl.Text = "Baud rate";
            // 
            // baudRateField
            // 
            this.baudRateField.Location = new System.Drawing.Point(163, 47);
            this.baudRateField.Name = "baudRateField";
            this.baudRateField.Size = new System.Drawing.Size(90, 20);
            this.baudRateField.TabIndex = 2;
            // 
            // conectBtn
            // 
            this.conectBtn.Location = new System.Drawing.Point(364, 44);
            this.conectBtn.Name = "conectBtn";
            this.conectBtn.Size = new System.Drawing.Size(75, 23);
            this.conectBtn.TabIndex = 4;
            this.conectBtn.Text = "Connect";
            this.conectBtn.UseVisualStyleBackColor = true;
            this.conectBtn.Click += new System.EventHandler(this.ConectBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 450);
            this.Controls.Add(this.conectBtn);
            this.Controls.Add(this.baudRateLbl);
            this.Controls.Add(this.baudRateField);
            this.Controls.Add(this.comPortlbl);
            this.Controls.Add(this.comPortField);
            this.Name = "Form1";
            this.Text = "SecNet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox comPortField;
        private System.Windows.Forms.Label comPortlbl;
        private System.Windows.Forms.Label baudRateLbl;
        private System.Windows.Forms.TextBox baudRateField;
        private System.Windows.Forms.Button conectBtn;
    }
}

