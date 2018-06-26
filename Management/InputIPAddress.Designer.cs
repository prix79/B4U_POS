namespace Management
{
    partial class InputIPAddress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputIPAddress));
            this.rdoBtnIPAddress = new System.Windows.Forms.RadioButton();
            this.rdoBtnNamedPipe = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCustom = new System.Windows.Forms.TextBox();
            this.rdoBtnCustom = new System.Windows.Forms.RadioButton();
            this.txtNamedPipe = new System.Windows.Forms.TextBox();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoBtnIPAddress
            // 
            this.rdoBtnIPAddress.AutoSize = true;
            this.rdoBtnIPAddress.Checked = true;
            this.rdoBtnIPAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnIPAddress.Location = new System.Drawing.Point(6, 19);
            this.rdoBtnIPAddress.Name = "rdoBtnIPAddress";
            this.rdoBtnIPAddress.Size = new System.Drawing.Size(159, 29);
            this.rdoBtnIPAddress.TabIndex = 1;
            this.rdoBtnIPAddress.TabStop = true;
            this.rdoBtnIPAddress.Text = "IP ADDRESS";
            this.rdoBtnIPAddress.UseVisualStyleBackColor = true;
            // 
            // rdoBtnNamedPipe
            // 
            this.rdoBtnNamedPipe.AutoSize = true;
            this.rdoBtnNamedPipe.Enabled = false;
            this.rdoBtnNamedPipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnNamedPipe.Location = new System.Drawing.Point(6, 64);
            this.rdoBtnNamedPipe.Name = "rdoBtnNamedPipe";
            this.rdoBtnNamedPipe.Size = new System.Drawing.Size(161, 29);
            this.rdoBtnNamedPipe.TabIndex = 2;
            this.rdoBtnNamedPipe.Text = "NAMED PIPE";
            this.rdoBtnNamedPipe.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCustom);
            this.groupBox1.Controls.Add(this.rdoBtnCustom);
            this.groupBox1.Controls.Add(this.txtNamedPipe);
            this.groupBox1.Controls.Add(this.txtIPAddress);
            this.groupBox1.Controls.Add(this.rdoBtnIPAddress);
            this.groupBox1.Controls.Add(this.rdoBtnNamedPipe);
            this.groupBox1.Location = new System.Drawing.Point(11, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(561, 157);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // txtCustom
            // 
            this.txtCustom.Enabled = false;
            this.txtCustom.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtCustom.Location = new System.Drawing.Point(171, 109);
            this.txtCustom.Name = "txtCustom";
            this.txtCustom.Size = new System.Drawing.Size(382, 32);
            this.txtCustom.TabIndex = 6;
            // 
            // rdoBtnCustom
            // 
            this.rdoBtnCustom.AutoSize = true;
            this.rdoBtnCustom.Enabled = false;
            this.rdoBtnCustom.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnCustom.Location = new System.Drawing.Point(6, 109);
            this.rdoBtnCustom.Name = "rdoBtnCustom";
            this.rdoBtnCustom.Size = new System.Drawing.Size(125, 29);
            this.rdoBtnCustom.TabIndex = 5;
            this.rdoBtnCustom.Text = "CUSTOM";
            this.rdoBtnCustom.UseVisualStyleBackColor = true;
            // 
            // txtNamedPipe
            // 
            this.txtNamedPipe.Enabled = false;
            this.txtNamedPipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtNamedPipe.Location = new System.Drawing.Point(171, 63);
            this.txtNamedPipe.Name = "txtNamedPipe";
            this.txtNamedPipe.Size = new System.Drawing.Size(382, 32);
            this.txtNamedPipe.TabIndex = 4;
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtIPAddress.Location = new System.Drawing.Point(171, 19);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(382, 32);
            this.txtIPAddress.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOK.Location = new System.Drawing.Point(182, 174);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(193, 48);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(379, 174);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(193, 48);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // InputIPAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 228);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InputIPAddress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InputIPAddress";
            this.Load += new System.EventHandler(this.InputIPAddress_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoBtnIPAddress;
        private System.Windows.Forms.RadioButton rdoBtnNamedPipe;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.TextBox txtNamedPipe;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtCustom;
        private System.Windows.Forms.RadioButton rdoBtnCustom;

    }
}