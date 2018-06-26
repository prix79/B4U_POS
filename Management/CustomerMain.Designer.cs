namespace Management
{
    partial class CustomerMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerMain));
            this.btnDeleteCustomer = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRegisterNewCustomer = new System.Windows.Forms.Button();
            this.btnUpdateCustomer = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtSearchKeyword = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.rdoBtnMemberCode = new System.Windows.Forms.RadioButton();
            this.rdoBtnCellPhone = new System.Windows.Forms.RadioButton();
            this.rdoBtnHomePhone = new System.Windows.Forms.RadioButton();
            this.rdoBtnLastName = new System.Windows.Forms.RadioButton();
            this.rdoBtnFirstName = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNumberOfMembers = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnLoadAllCustomer = new System.Windows.Forms.Button();
            this.btnUpdateByAdmin = new System.Windows.Forms.Button();
            this.btnViewCustomerInfo = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDeleteCustomer
            // 
            this.btnDeleteCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDeleteCustomer.Location = new System.Drawing.Point(841, 12);
            this.btnDeleteCustomer.Name = "btnDeleteCustomer";
            this.btnDeleteCustomer.Size = new System.Drawing.Size(85, 50);
            this.btnDeleteCustomer.TabIndex = 5;
            this.btnDeleteCustomer.Text = "DELETE CUSTOMER";
            this.btnDeleteCustomer.UseVisualStyleBackColor = true;
            this.btnDeleteCustomer.Click += new System.EventHandler(this.btnDeleteCustomer_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(841, 66);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 50);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRegisterNewCustomer
            // 
            this.btnRegisterNewCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRegisterNewCustomer.Location = new System.Drawing.Point(667, 12);
            this.btnRegisterNewCustomer.Name = "btnRegisterNewCustomer";
            this.btnRegisterNewCustomer.Size = new System.Drawing.Size(85, 50);
            this.btnRegisterNewCustomer.TabIndex = 3;
            this.btnRegisterNewCustomer.Text = "REGISTER NEW CUSTOMER";
            this.btnRegisterNewCustomer.UseVisualStyleBackColor = true;
            this.btnRegisterNewCustomer.Click += new System.EventHandler(this.btnRegisterNewCustomer_Click);
            // 
            // btnUpdateCustomer
            // 
            this.btnUpdateCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpdateCustomer.Location = new System.Drawing.Point(754, 12);
            this.btnUpdateCustomer.Name = "btnUpdateCustomer";
            this.btnUpdateCustomer.Size = new System.Drawing.Size(85, 50);
            this.btnUpdateCustomer.TabIndex = 6;
            this.btnUpdateCustomer.Text = "UPDATE CUSTOMER";
            this.btnUpdateCustomer.UseVisualStyleBackColor = true;
            this.btnUpdateCustomer.Click += new System.EventHandler(this.btnUpdateCustomer_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeight = 43;
            this.dataGridView1.Location = new System.Drawing.Point(5, 122);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1010, 615);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // txtSearchKeyword
            // 
            this.txtSearchKeyword.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtSearchKeyword.Location = new System.Drawing.Point(309, 63);
            this.txtSearchKeyword.Name = "txtSearchKeyword";
            this.txtSearchKeyword.Size = new System.Drawing.Size(257, 38);
            this.txtSearchKeyword.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.rdoBtnMemberCode);
            this.groupBox1.Controls.Add(this.txtSearchKeyword);
            this.groupBox1.Controls.Add(this.rdoBtnCellPhone);
            this.groupBox1.Controls.Add(this.rdoBtnHomePhone);
            this.groupBox1.Controls.Add(this.rdoBtnLastName);
            this.groupBox1.Controls.Add(this.rdoBtnFirstName);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(571, 111);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SEARCH OPTIONS";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(462, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(104, 40);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rdoBtnMemberCode
            // 
            this.rdoBtnMemberCode.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoBtnMemberCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnMemberCode.Location = new System.Drawing.Point(309, 18);
            this.rdoBtnMemberCode.Name = "rdoBtnMemberCode";
            this.rdoBtnMemberCode.Size = new System.Drawing.Size(150, 40);
            this.rdoBtnMemberCode.TabIndex = 4;
            this.rdoBtnMemberCode.Text = "MEMBER CODE";
            this.rdoBtnMemberCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoBtnMemberCode.UseVisualStyleBackColor = true;
            this.rdoBtnMemberCode.CheckedChanged += new System.EventHandler(this.rdoBtnMemberCode_CheckedChanged);
            // 
            // rdoBtnCellPhone
            // 
            this.rdoBtnCellPhone.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoBtnCellPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnCellPhone.Location = new System.Drawing.Point(157, 63);
            this.rdoBtnCellPhone.Name = "rdoBtnCellPhone";
            this.rdoBtnCellPhone.Size = new System.Drawing.Size(150, 40);
            this.rdoBtnCellPhone.TabIndex = 3;
            this.rdoBtnCellPhone.Text = "CELL PHONE";
            this.rdoBtnCellPhone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoBtnCellPhone.UseVisualStyleBackColor = true;
            this.rdoBtnCellPhone.CheckedChanged += new System.EventHandler(this.rdoBtnCellPhone_CheckedChanged);
            // 
            // rdoBtnHomePhone
            // 
            this.rdoBtnHomePhone.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoBtnHomePhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnHomePhone.Location = new System.Drawing.Point(157, 18);
            this.rdoBtnHomePhone.Name = "rdoBtnHomePhone";
            this.rdoBtnHomePhone.Size = new System.Drawing.Size(150, 40);
            this.rdoBtnHomePhone.TabIndex = 2;
            this.rdoBtnHomePhone.Text = "HOME PHONE";
            this.rdoBtnHomePhone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoBtnHomePhone.UseVisualStyleBackColor = true;
            this.rdoBtnHomePhone.CheckedChanged += new System.EventHandler(this.rdoBtnHomePhone_CheckedChanged);
            // 
            // rdoBtnLastName
            // 
            this.rdoBtnLastName.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoBtnLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnLastName.Location = new System.Drawing.Point(5, 63);
            this.rdoBtnLastName.Name = "rdoBtnLastName";
            this.rdoBtnLastName.Size = new System.Drawing.Size(150, 40);
            this.rdoBtnLastName.TabIndex = 1;
            this.rdoBtnLastName.Text = "LAST NAME";
            this.rdoBtnLastName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoBtnLastName.UseVisualStyleBackColor = true;
            this.rdoBtnLastName.CheckedChanged += new System.EventHandler(this.rdoBtnLastName_CheckedChanged);
            // 
            // rdoBtnFirstName
            // 
            this.rdoBtnFirstName.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoBtnFirstName.Checked = true;
            this.rdoBtnFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnFirstName.Location = new System.Drawing.Point(5, 18);
            this.rdoBtnFirstName.Name = "rdoBtnFirstName";
            this.rdoBtnFirstName.Size = new System.Drawing.Size(150, 40);
            this.rdoBtnFirstName.TabIndex = 0;
            this.rdoBtnFirstName.TabStop = true;
            this.rdoBtnFirstName.Text = "FIRST NAME";
            this.rdoBtnFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoBtnFirstName.UseVisualStyleBackColor = true;
            this.rdoBtnFirstName.CheckedChanged += new System.EventHandler(this.rdoBtnFirstName_CheckedChanged);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(929, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 53);
            this.label1.TabIndex = 15;
            this.label1.Text = "NUMBER OF CUSTOMERS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNumberOfMembers
            // 
            this.lblNumberOfMembers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumberOfMembers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNumberOfMembers.Location = new System.Drawing.Point(929, 66);
            this.lblNumberOfMembers.Name = "lblNumberOfMembers";
            this.lblNumberOfMembers.Size = new System.Drawing.Size(86, 50);
            this.lblNumberOfMembers.TabIndex = 16;
            this.lblNumberOfMembers.Text = "0";
            this.lblNumberOfMembers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExcel
            // 
            this.btnExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExcel.Location = new System.Drawing.Point(667, 66);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(85, 50);
            this.btnExcel.TabIndex = 17;
            this.btnExcel.Text = "EXCEL";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnLoadAllCustomer
            // 
            this.btnLoadAllCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLoadAllCustomer.Location = new System.Drawing.Point(580, 12);
            this.btnLoadAllCustomer.Name = "btnLoadAllCustomer";
            this.btnLoadAllCustomer.Size = new System.Drawing.Size(85, 50);
            this.btnLoadAllCustomer.TabIndex = 18;
            this.btnLoadAllCustomer.Text = "LOAD ALL CUSTOMER";
            this.btnLoadAllCustomer.UseVisualStyleBackColor = true;
            this.btnLoadAllCustomer.Click += new System.EventHandler(this.btnLoadAllCustomer_Click);
            // 
            // btnUpdateByAdmin
            // 
            this.btnUpdateByAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpdateByAdmin.Location = new System.Drawing.Point(754, 66);
            this.btnUpdateByAdmin.Name = "btnUpdateByAdmin";
            this.btnUpdateByAdmin.Size = new System.Drawing.Size(85, 50);
            this.btnUpdateByAdmin.TabIndex = 19;
            this.btnUpdateByAdmin.Text = "UPDATE BY ADMIN";
            this.btnUpdateByAdmin.UseVisualStyleBackColor = true;
            this.btnUpdateByAdmin.Visible = false;
            this.btnUpdateByAdmin.Click += new System.EventHandler(this.btnUpdateByAdmin_Click);
            // 
            // btnViewCustomerInfo
            // 
            this.btnViewCustomerInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnViewCustomerInfo.Location = new System.Drawing.Point(580, 66);
            this.btnViewCustomerInfo.Name = "btnViewCustomerInfo";
            this.btnViewCustomerInfo.Size = new System.Drawing.Size(85, 50);
            this.btnViewCustomerInfo.TabIndex = 20;
            this.btnViewCustomerInfo.Text = "VIEW CUSTOMER INFO";
            this.btnViewCustomerInfo.UseVisualStyleBackColor = true;
            this.btnViewCustomerInfo.Click += new System.EventHandler(this.btnViewCustomerInfo_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(5, 707);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1010, 30);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 21;
            this.progressBar1.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // CustomerMain
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 741);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnViewCustomerInfo);
            this.Controls.Add(this.btnUpdateByAdmin);
            this.Controls.Add(this.btnLoadAllCustomer);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.lblNumberOfMembers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnUpdateCustomer);
            this.Controls.Add(this.btnDeleteCustomer);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRegisterNewCustomer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CustomerMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CUSTOMER";
            this.Load += new System.EventHandler(this.CustomerMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteCustomer;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRegisterNewCustomer;
        private System.Windows.Forms.Button btnUpdateCustomer;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.TextBox txtSearchKeyword;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton rdoBtnMemberCode;
        public System.Windows.Forms.RadioButton rdoBtnCellPhone;
        public System.Windows.Forms.RadioButton rdoBtnHomePhone;
        public System.Windows.Forms.RadioButton rdoBtnLastName;
        public System.Windows.Forms.RadioButton rdoBtnFirstName;
        public System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNumberOfMembers;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnLoadAllCustomer;
        private System.Windows.Forms.Button btnUpdateByAdmin;
        private System.Windows.Forms.Button btnViewCustomerInfo;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}