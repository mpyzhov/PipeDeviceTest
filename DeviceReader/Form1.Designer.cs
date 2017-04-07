namespace DeviceReader
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
            this.lbDevices = new System.Windows.Forms.ListBox();
            this.btnReadDevices = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbDevices
            // 
            this.lbDevices.FormattingEnabled = true;
            this.lbDevices.Location = new System.Drawing.Point(12, 38);
            this.lbDevices.Name = "lbDevices";
            this.lbDevices.Size = new System.Drawing.Size(237, 394);
            this.lbDevices.TabIndex = 0;
            // 
            // btnReadDevices
            // 
            this.btnReadDevices.Location = new System.Drawing.Point(12, 9);
            this.btnReadDevices.Name = "btnReadDevices";
            this.btnReadDevices.Size = new System.Drawing.Size(75, 23);
            this.btnReadDevices.TabIndex = 1;
            this.btnReadDevices.Text = "Read devices";
            this.btnReadDevices.UseVisualStyleBackColor = true;
            this.btnReadDevices.Click += new System.EventHandler(this.btnReadDevices_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 441);
            this.Controls.Add(this.btnReadDevices);
            this.Controls.Add(this.lbDevices);
            this.Name = "Form1";
            this.Text = "Device reader";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbDevices;
        private System.Windows.Forms.Button btnReadDevices;
    }
}

