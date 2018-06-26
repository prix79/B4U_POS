namespace WindowsFormsApplication1
{
    partial class CloverConnection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CloverConnection));
            this.btnUSBConnect = new System.Windows.Forms.Button();
            this.btnStartRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUSBConnect
            // 
            this.btnUSBConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUSBConnect.Location = new System.Drawing.Point(12, 12);
            this.btnUSBConnect.Name = "btnUSBConnect";
            this.btnUSBConnect.Size = new System.Drawing.Size(285, 58);
            this.btnUSBConnect.TabIndex = 0;
            this.btnUSBConnect.Text = "USB CONNECT";
            this.btnUSBConnect.UseVisualStyleBackColor = true;
            this.btnUSBConnect.Click += new System.EventHandler(this.btnUSBConnect_Click);
            // 
            // btnStartRegister
            // 
            this.btnStartRegister.Enabled = false;
            this.btnStartRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStartRegister.Location = new System.Drawing.Point(12, 76);
            this.btnStartRegister.Name = "btnStartRegister";
            this.btnStartRegister.Size = new System.Drawing.Size(285, 58);
            this.btnStartRegister.TabIndex = 1;
            this.btnStartRegister.Text = "START REGISTER";
            this.btnStartRegister.UseVisualStyleBackColor = true;
            this.btnStartRegister.Click += new System.EventHandler(this.btnStartRegister_Click);
            // 
            // CloverConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 144);
            this.Controls.Add(this.btnStartRegister);
            this.Controls.Add(this.btnUSBConnect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CloverConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clover Connection";
            this.Load += new System.EventHandler(this.CloverConnection_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUSBConnect;
        private System.Windows.Forms.Button btnStartRegister;
    }
}

