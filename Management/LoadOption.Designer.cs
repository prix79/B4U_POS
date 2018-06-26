namespace Management
{
    partial class LoadOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadOption));
            this.monthCalendar2 = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbCategory1 = new System.Windows.Forms.ComboBox();
            this.txtEmployeeID = new System.Windows.Forms.TextBox();
            this.rdoBtnAll = new System.Windows.Forms.RadioButton();
            this.rdoBtnEmployeeID = new System.Windows.Forms.RadioButton();
            this.rdoBtnCategory = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // monthCalendar2
            // 
            this.monthCalendar2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.monthCalendar2.Location = new System.Drawing.Point(184, 95);
            this.monthCalendar2.Name = "monthCalendar2";
            this.monthCalendar2.TabIndex = 42;
            this.monthCalendar2.Visible = false;
            this.monthCalendar2.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar2_DateSelected);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.monthCalendar1.Location = new System.Drawing.Point(184, 44);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 41;
            this.monthCalendar1.Visible = false;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(305, 226);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 50);
            this.btnCancel.TabIndex = 40;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(184, 226);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(120, 50);
            this.btnOK.TabIndex = 39;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtEndDate
            // 
            this.txtEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtEndDate.Location = new System.Drawing.Point(184, 64);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(241, 30);
            this.txtEndDate.TabIndex = 38;
            this.txtEndDate.DoubleClick += new System.EventHandler(this.txtEndDate_DoubleClick);
            // 
            // txtStartDate
            // 
            this.txtStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtStartDate.Location = new System.Drawing.Point(184, 14);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(241, 30);
            this.txtStartDate.TabIndex = 37;
            this.txtStartDate.DoubleClick += new System.EventHandler(this.txtStartDate_DoubleClick);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 30);
            this.label3.TabIndex = 36;
            this.label3.Text = "END DATE";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 30);
            this.label2.TabIndex = 35;
            this.label2.Text = "START DATE";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbCategory1);
            this.groupBox1.Controls.Add(this.txtEmployeeID);
            this.groupBox1.Controls.Add(this.rdoBtnAll);
            this.groupBox1.Controls.Add(this.rdoBtnEmployeeID);
            this.groupBox1.Controls.Add(this.rdoBtnCategory);
            this.groupBox1.Location = new System.Drawing.Point(20, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 163);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FILTERING OPTIONS";
            this.groupBox1.Visible = false;
            // 
            // cmbCategory1
            // 
            this.cmbCategory1.FormattingEnabled = true;
            this.cmbCategory1.Location = new System.Drawing.Point(7, 46);
            this.cmbCategory1.Name = "cmbCategory1";
            this.cmbCategory1.Size = new System.Drawing.Size(145, 21);
            this.cmbCategory1.TabIndex = 4;
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.Enabled = false;
            this.txtEmployeeID.Location = new System.Drawing.Point(7, 100);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.Size = new System.Drawing.Size(145, 20);
            this.txtEmployeeID.TabIndex = 3;
            // 
            // rdoBtnAll
            // 
            this.rdoBtnAll.AutoSize = true;
            this.rdoBtnAll.Location = new System.Drawing.Point(7, 134);
            this.rdoBtnAll.Name = "rdoBtnAll";
            this.rdoBtnAll.Size = new System.Drawing.Size(44, 17);
            this.rdoBtnAll.TabIndex = 2;
            this.rdoBtnAll.Text = "ALL";
            this.rdoBtnAll.UseVisualStyleBackColor = true;
            this.rdoBtnAll.CheckedChanged += new System.EventHandler(this.rdoBtnAll_CheckedChanged);
            // 
            // rdoBtnEmployeeID
            // 
            this.rdoBtnEmployeeID.AutoSize = true;
            this.rdoBtnEmployeeID.Location = new System.Drawing.Point(7, 80);
            this.rdoBtnEmployeeID.Name = "rdoBtnEmployeeID";
            this.rdoBtnEmployeeID.Size = new System.Drawing.Size(97, 17);
            this.rdoBtnEmployeeID.TabIndex = 1;
            this.rdoBtnEmployeeID.Text = "EMPLOYEE ID";
            this.rdoBtnEmployeeID.UseVisualStyleBackColor = true;
            this.rdoBtnEmployeeID.CheckedChanged += new System.EventHandler(this.rdoBtnEmployeeID_CheckedChanged);
            // 
            // rdoBtnCategory
            // 
            this.rdoBtnCategory.AutoSize = true;
            this.rdoBtnCategory.Checked = true;
            this.rdoBtnCategory.Location = new System.Drawing.Point(7, 27);
            this.rdoBtnCategory.Name = "rdoBtnCategory";
            this.rdoBtnCategory.Size = new System.Drawing.Size(84, 17);
            this.rdoBtnCategory.TabIndex = 0;
            this.rdoBtnCategory.TabStop = true;
            this.rdoBtnCategory.Text = "CATEGORY";
            this.rdoBtnCategory.UseVisualStyleBackColor = true;
            this.rdoBtnCategory.CheckedChanged += new System.EventHandler(this.rdoBtnCategory_CheckedChanged);
            // 
            // LoadOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 295);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.monthCalendar2);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoadOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOAD OPTION";
            this.Load += new System.EventHandler(this.LoadOption_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar2;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoBtnAll;
        private System.Windows.Forms.RadioButton rdoBtnEmployeeID;
        private System.Windows.Forms.RadioButton rdoBtnCategory;
        private System.Windows.Forms.ComboBox cmbCategory1;
        private System.Windows.Forms.TextBox txtEmployeeID;
    }
}