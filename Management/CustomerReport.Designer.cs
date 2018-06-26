namespace Management
{
    partial class CustomerReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerReport));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnExcel = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar2 = new System.Windows.Forms.MonthCalendar();
            this.rdoBtn20P = new System.Windows.Forms.RadioButton();
            this.label33 = new System.Windows.Forms.Label();
            this.txtBCEndDate = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.txtBCStartDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMemberType = new System.Windows.Forms.ComboBox();
            this.rdoBtnAll = new System.Windows.Forms.RadioButton();
            this.lblTotalPeriodTransactionAmount = new System.Windows.Forms.Label();
            this.label103 = new System.Windows.Forms.Label();
            this.lblTotalNumberOfCustomer = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.rdoBtn10P = new System.Windows.Forms.RadioButton();
            this.rdoBtn5P = new System.Windows.Forms.RadioButton();
            this.lblSBPStoreCode = new System.Windows.Forms.Label();
            this.cmbSBPStoreCode = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnBCClose = new System.Windows.Forms.Button();
            this.btnBCOk = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tabControl1.ItemSize = new System.Drawing.Size(145, 30);
            this.tabControl1.Location = new System.Drawing.Point(5, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1008, 709);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnExcel);
            this.tabPage1.Controls.Add(this.monthCalendar1);
            this.tabPage1.Controls.Add(this.monthCalendar2);
            this.tabPage1.Controls.Add(this.rdoBtn20P);
            this.tabPage1.Controls.Add(this.label33);
            this.tabPage1.Controls.Add(this.txtBCEndDate);
            this.tabPage1.Controls.Add(this.label34);
            this.tabPage1.Controls.Add(this.txtBCStartDate);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cmbMemberType);
            this.tabPage1.Controls.Add(this.rdoBtnAll);
            this.tabPage1.Controls.Add(this.lblTotalPeriodTransactionAmount);
            this.tabPage1.Controls.Add(this.label103);
            this.tabPage1.Controls.Add(this.lblTotalNumberOfCustomer);
            this.tabPage1.Controls.Add(this.label27);
            this.tabPage1.Controls.Add(this.rdoBtn10P);
            this.tabPage1.Controls.Add(this.rdoBtn5P);
            this.tabPage1.Controls.Add(this.lblSBPStoreCode);
            this.tabPage1.Controls.Add(this.cmbSBPStoreCode);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.btnBCClose);
            this.tabPage1.Controls.Add(this.btnBCOk);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1000, 671);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "BEST CUSTOMER";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnExcel
            // 
            this.btnExcel.Enabled = false;
            this.btnExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExcel.Location = new System.Drawing.Point(701, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(68, 55);
            this.btnExcel.TabIndex = 178;
            this.btnExcel.Text = "EXCEL";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.BackColor = System.Drawing.SystemColors.Info;
            this.monthCalendar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.monthCalendar1.Location = new System.Drawing.Point(118, 35);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 177;
            this.monthCalendar1.Visible = false;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // monthCalendar2
            // 
            this.monthCalendar2.BackColor = System.Drawing.SystemColors.Info;
            this.monthCalendar2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.monthCalendar2.Location = new System.Drawing.Point(118, 65);
            this.monthCalendar2.Name = "monthCalendar2";
            this.monthCalendar2.TabIndex = 176;
            this.monthCalendar2.Visible = false;
            this.monthCalendar2.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar2_DateSelected);
            // 
            // rdoBtn20P
            // 
            this.rdoBtn20P.Location = new System.Drawing.Point(505, 42);
            this.rdoBtn20P.Name = "rdoBtn20P";
            this.rdoBtn20P.Size = new System.Drawing.Size(94, 21);
            this.rdoBtn20P.TabIndex = 175;
            this.rdoBtn20P.Text = "TOP 20%";
            this.rdoBtn20P.UseVisualStyleBackColor = true;
            // 
            // label33
            // 
            this.label33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label33.Location = new System.Drawing.Point(6, 37);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(111, 26);
            this.label33.TabIndex = 174;
            this.label33.Text = "END DATE";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBCEndDate
            // 
            this.txtBCEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtBCEndDate.Location = new System.Drawing.Point(118, 37);
            this.txtBCEndDate.Name = "txtBCEndDate";
            this.txtBCEndDate.Size = new System.Drawing.Size(199, 26);
            this.txtBCEndDate.TabIndex = 173;
            this.txtBCEndDate.DoubleClick += new System.EventHandler(this.txtBCEndDate_DoubleClick);
            // 
            // label34
            // 
            this.label34.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label34.Location = new System.Drawing.Point(6, 8);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(111, 26);
            this.label34.TabIndex = 172;
            this.label34.Text = "START DATE";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBCStartDate
            // 
            this.txtBCStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtBCStartDate.Location = new System.Drawing.Point(118, 8);
            this.txtBCStartDate.Name = "txtBCStartDate";
            this.txtBCStartDate.Size = new System.Drawing.Size(199, 26);
            this.txtBCStartDate.TabIndex = 171;
            this.txtBCStartDate.DoubleClick += new System.EventHandler(this.txtBCStartDate_DoubleClick);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(319, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 26);
            this.label1.TabIndex = 170;
            this.label1.Text = "MEMBER TYPE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbMemberType
            // 
            this.cmbMemberType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMemberType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbMemberType.FormattingEnabled = true;
            this.cmbMemberType.Location = new System.Drawing.Point(319, 37);
            this.cmbMemberType.Name = "cmbMemberType";
            this.cmbMemberType.Size = new System.Drawing.Size(180, 26);
            this.cmbMemberType.TabIndex = 169;
            // 
            // rdoBtnAll
            // 
            this.rdoBtnAll.Location = new System.Drawing.Point(604, 42);
            this.rdoBtnAll.Name = "rdoBtnAll";
            this.rdoBtnAll.Size = new System.Drawing.Size(94, 21);
            this.rdoBtnAll.TabIndex = 168;
            this.rdoBtnAll.Text = "All";
            this.rdoBtnAll.UseVisualStyleBackColor = true;
            // 
            // lblTotalPeriodTransactionAmount
            // 
            this.lblTotalPeriodTransactionAmount.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblTotalPeriodTransactionAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTotalPeriodTransactionAmount.ForeColor = System.Drawing.Color.Black;
            this.lblTotalPeriodTransactionAmount.Location = new System.Drawing.Point(526, 617);
            this.lblTotalPeriodTransactionAmount.Name = "lblTotalPeriodTransactionAmount";
            this.lblTotalPeriodTransactionAmount.Size = new System.Drawing.Size(152, 48);
            this.lblTotalPeriodTransactionAmount.TabIndex = 167;
            this.lblTotalPeriodTransactionAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label103
            // 
            this.label103.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label103.ForeColor = System.Drawing.Color.Black;
            this.label103.Location = new System.Drawing.Point(319, 617);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(206, 48);
            this.label103.TabIndex = 166;
            this.label103.Text = "TOTAL PERIOD TRANSACTION AMOUNT";
            this.label103.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalNumberOfCustomer
            // 
            this.lblTotalNumberOfCustomer.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblTotalNumberOfCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTotalNumberOfCustomer.ForeColor = System.Drawing.Color.Black;
            this.lblTotalNumberOfCustomer.Location = new System.Drawing.Point(839, 617);
            this.lblTotalNumberOfCustomer.Name = "lblTotalNumberOfCustomer";
            this.lblTotalNumberOfCustomer.Size = new System.Drawing.Size(155, 48);
            this.lblTotalNumberOfCustomer.TabIndex = 165;
            this.lblTotalNumberOfCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(683, 617);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(155, 48);
            this.label27.TabIndex = 164;
            this.label27.Text = "TOTAL NUMBER OF CUSTOMER";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdoBtn10P
            // 
            this.rdoBtn10P.Location = new System.Drawing.Point(604, 8);
            this.rdoBtn10P.Name = "rdoBtn10P";
            this.rdoBtn10P.Size = new System.Drawing.Size(94, 21);
            this.rdoBtn10P.TabIndex = 163;
            this.rdoBtn10P.Text = "TOP 10%";
            this.rdoBtn10P.UseVisualStyleBackColor = true;
            // 
            // rdoBtn5P
            // 
            this.rdoBtn5P.Checked = true;
            this.rdoBtn5P.Location = new System.Drawing.Point(505, 3);
            this.rdoBtn5P.Name = "rdoBtn5P";
            this.rdoBtn5P.Size = new System.Drawing.Size(94, 28);
            this.rdoBtn5P.TabIndex = 162;
            this.rdoBtn5P.TabStop = true;
            this.rdoBtn5P.Text = "TOP 5%";
            this.rdoBtn5P.UseVisualStyleBackColor = true;
            // 
            // lblSBPStoreCode
            // 
            this.lblSBPStoreCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSBPStoreCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSBPStoreCode.Location = new System.Drawing.Point(773, 10);
            this.lblSBPStoreCode.Name = "lblSBPStoreCode";
            this.lblSBPStoreCode.Size = new System.Drawing.Size(120, 26);
            this.lblSBPStoreCode.TabIndex = 161;
            this.lblSBPStoreCode.Text = "STORE CODE";
            this.lblSBPStoreCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSBPStoreCode.Visible = false;
            // 
            // cmbSBPStoreCode
            // 
            this.cmbSBPStoreCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSBPStoreCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbSBPStoreCode.FormattingEnabled = true;
            this.cmbSBPStoreCode.Items.AddRange(new object[] {
            "OH",
            "CH",
            "WB",
            "CV",
            "UM",
            "WM",
            "TH"});
            this.cmbSBPStoreCode.Location = new System.Drawing.Point(773, 37);
            this.cmbSBPStoreCode.Name = "cmbSBPStoreCode";
            this.cmbSBPStoreCode.Size = new System.Drawing.Size(120, 26);
            this.cmbSBPStoreCode.TabIndex = 160;
            this.cmbSBPStoreCode.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 45;
            this.dataGridView1.Location = new System.Drawing.Point(6, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(988, 547);
            this.dataGridView1.TabIndex = 132;
            // 
            // btnBCClose
            // 
            this.btnBCClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBCClose.ForeColor = System.Drawing.Color.Red;
            this.btnBCClose.Location = new System.Drawing.Point(899, 37);
            this.btnBCClose.Name = "btnBCClose";
            this.btnBCClose.Size = new System.Drawing.Size(95, 26);
            this.btnBCClose.TabIndex = 131;
            this.btnBCClose.Text = "CLOSE";
            this.btnBCClose.UseVisualStyleBackColor = true;
            this.btnBCClose.Click += new System.EventHandler(this.btnBCClose_Click);
            // 
            // btnBCOk
            // 
            this.btnBCOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBCOk.Location = new System.Drawing.Point(899, 8);
            this.btnBCOk.Name = "btnBCOk";
            this.btnBCOk.Size = new System.Drawing.Size(95, 26);
            this.btnBCOk.TabIndex = 130;
            this.btnBCOk.Text = "OK";
            this.btnBCOk.UseVisualStyleBackColor = true;
            this.btnBCOk.Click += new System.EventHandler(this.btnBCOk_Click);
            // 
            // CustomerReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomerReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CUSTOMER REPORT";
            this.Load += new System.EventHandler(this.CustomerReport_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnBCClose;
        private System.Windows.Forms.Button btnBCOk;
        public System.Windows.Forms.Label lblSBPStoreCode;
        private System.Windows.Forms.ComboBox cmbSBPStoreCode;
        private System.Windows.Forms.RadioButton rdoBtn10P;
        private System.Windows.Forms.RadioButton rdoBtn5P;
        private System.Windows.Forms.RadioButton rdoBtnAll;
        private System.Windows.Forms.Label lblTotalPeriodTransactionAmount;
        private System.Windows.Forms.Label label103;
        private System.Windows.Forms.Label lblTotalNumberOfCustomer;
        private System.Windows.Forms.Label label27;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMemberType;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox txtBCEndDate;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox txtBCStartDate;
        private System.Windows.Forms.RadioButton rdoBtn20P;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.MonthCalendar monthCalendar2;
        private System.Windows.Forms.Button btnExcel;
    }
}