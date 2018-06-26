namespace Management
{
    partial class MembershipMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MembershipMain));
            this.btnLoadingAllCustomer = new System.Windows.Forms.Button();
            this.btnDeleteCustomer = new System.Windows.Forms.Button();
            this.lblNumberOfMembers = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMerge = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.rdoBtnMemberCode = new System.Windows.Forms.RadioButton();
            this.txtSearchKeyword = new System.Windows.Forms.TextBox();
            this.rdoBtnCellPhone = new System.Windows.Forms.RadioButton();
            this.rdoBtnHomePhone = new System.Windows.Forms.RadioButton();
            this.rdoBtnLastName = new System.Windows.Forms.RadioButton();
            this.rdoBtnFirstName = new System.Windows.Forms.RadioButton();
            this.btnUpdateCustomer = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRegisterNewCustomer = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnViewCustomerInfo = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadingAllCustomer
            // 
            this.btnLoadingAllCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadingAllCustomer.BackColor = System.Drawing.SystemColors.Control;
            this.btnLoadingAllCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadingAllCustomer.ForeColor = System.Drawing.Color.Black;
            this.btnLoadingAllCustomer.Location = new System.Drawing.Point(580, 12);
            this.btnLoadingAllCustomer.Name = "btnLoadingAllCustomer";
            this.btnLoadingAllCustomer.Size = new System.Drawing.Size(85, 50);
            this.btnLoadingAllCustomer.TabIndex = 22;
            this.btnLoadingAllCustomer.Text = "LOADING ALL MEMBER";
            this.btnLoadingAllCustomer.UseVisualStyleBackColor = false;
            this.btnLoadingAllCustomer.Click += new System.EventHandler(this.btnLoadingAllCustomer_Click);
            // 
            // btnDeleteCustomer
            // 
            this.btnDeleteCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteCustomer.BackColor = System.Drawing.SystemColors.Control;
            this.btnDeleteCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCustomer.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteCustomer.Location = new System.Drawing.Point(841, 12);
            this.btnDeleteCustomer.Name = "btnDeleteCustomer";
            this.btnDeleteCustomer.Size = new System.Drawing.Size(85, 50);
            this.btnDeleteCustomer.TabIndex = 29;
            this.btnDeleteCustomer.Text = "DELETE MEMBER";
            this.btnDeleteCustomer.UseVisualStyleBackColor = false;
            this.btnDeleteCustomer.Click += new System.EventHandler(this.btnDeleteCustomer_Click);
            // 
            // lblNumberOfMembers
            // 
            this.lblNumberOfMembers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumberOfMembers.BackColor = System.Drawing.SystemColors.Control;
            this.lblNumberOfMembers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumberOfMembers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNumberOfMembers.ForeColor = System.Drawing.Color.Black;
            this.lblNumberOfMembers.Location = new System.Drawing.Point(929, 66);
            this.lblNumberOfMembers.Name = "lblNumberOfMembers";
            this.lblNumberOfMembers.Size = new System.Drawing.Size(86, 50);
            this.lblNumberOfMembers.TabIndex = 27;
            this.lblNumberOfMembers.Text = "0";
            this.lblNumberOfMembers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(929, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 53);
            this.label1.TabIndex = 26;
            this.label1.Text = "NUMBER OF MEMBERS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMerge);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.rdoBtnMemberCode);
            this.groupBox1.Controls.Add(this.txtSearchKeyword);
            this.groupBox1.Controls.Add(this.rdoBtnCellPhone);
            this.groupBox1.Controls.Add(this.rdoBtnHomePhone);
            this.groupBox1.Controls.Add(this.rdoBtnLastName);
            this.groupBox1.Controls.Add(this.rdoBtnFirstName);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(571, 111);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SEARCH OPTIONS";
            // 
            // btnMerge
            // 
            this.btnMerge.BackColor = System.Drawing.SystemColors.Control;
            this.btnMerge.Enabled = false;
            this.btnMerge.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnMerge.ForeColor = System.Drawing.Color.Black;
            this.btnMerge.Location = new System.Drawing.Point(482, 17);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(83, 40);
            this.btnMerge.TabIndex = 16;
            this.btnMerge.Text = "MERGE";
            this.btnMerge.UseVisualStyleBackColor = false;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(397, 17);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(83, 40);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rdoBtnMemberCode
            // 
            this.rdoBtnMemberCode.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoBtnMemberCode.BackColor = System.Drawing.SystemColors.Control;
            this.rdoBtnMemberCode.Checked = true;
            this.rdoBtnMemberCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnMemberCode.ForeColor = System.Drawing.Color.Black;
            this.rdoBtnMemberCode.Location = new System.Drawing.Point(266, 17);
            this.rdoBtnMemberCode.Name = "rdoBtnMemberCode";
            this.rdoBtnMemberCode.Size = new System.Drawing.Size(129, 40);
            this.rdoBtnMemberCode.TabIndex = 4;
            this.rdoBtnMemberCode.TabStop = true;
            this.rdoBtnMemberCode.Text = "MEMBER CODE";
            this.rdoBtnMemberCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoBtnMemberCode.UseVisualStyleBackColor = false;
            this.rdoBtnMemberCode.CheckedChanged += new System.EventHandler(this.rdoBtnMemberCode_CheckedChanged);
            // 
            // txtSearchKeyword
            // 
            this.txtSearchKeyword.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtSearchKeyword.Location = new System.Drawing.Point(266, 61);
            this.txtSearchKeyword.Name = "txtSearchKeyword";
            this.txtSearchKeyword.Size = new System.Drawing.Size(299, 38);
            this.txtSearchKeyword.TabIndex = 13;
            // 
            // rdoBtnCellPhone
            // 
            this.rdoBtnCellPhone.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoBtnCellPhone.BackColor = System.Drawing.SystemColors.Control;
            this.rdoBtnCellPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnCellPhone.ForeColor = System.Drawing.Color.Black;
            this.rdoBtnCellPhone.Location = new System.Drawing.Point(135, 17);
            this.rdoBtnCellPhone.Name = "rdoBtnCellPhone";
            this.rdoBtnCellPhone.Size = new System.Drawing.Size(129, 40);
            this.rdoBtnCellPhone.TabIndex = 3;
            this.rdoBtnCellPhone.Text = "CELL PHONE";
            this.rdoBtnCellPhone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoBtnCellPhone.UseVisualStyleBackColor = false;
            this.rdoBtnCellPhone.CheckedChanged += new System.EventHandler(this.rdoBtnCellPhone_CheckedChanged);
            // 
            // rdoBtnHomePhone
            // 
            this.rdoBtnHomePhone.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoBtnHomePhone.BackColor = System.Drawing.SystemColors.Control;
            this.rdoBtnHomePhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnHomePhone.ForeColor = System.Drawing.Color.Black;
            this.rdoBtnHomePhone.Location = new System.Drawing.Point(4, 17);
            this.rdoBtnHomePhone.Name = "rdoBtnHomePhone";
            this.rdoBtnHomePhone.Size = new System.Drawing.Size(129, 40);
            this.rdoBtnHomePhone.TabIndex = 2;
            this.rdoBtnHomePhone.Text = "HOME PHONE";
            this.rdoBtnHomePhone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoBtnHomePhone.UseVisualStyleBackColor = false;
            this.rdoBtnHomePhone.CheckedChanged += new System.EventHandler(this.rdoBtnHomePhone_CheckedChanged);
            // 
            // rdoBtnLastName
            // 
            this.rdoBtnLastName.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoBtnLastName.BackColor = System.Drawing.SystemColors.Control;
            this.rdoBtnLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnLastName.ForeColor = System.Drawing.Color.Black;
            this.rdoBtnLastName.Location = new System.Drawing.Point(135, 61);
            this.rdoBtnLastName.Name = "rdoBtnLastName";
            this.rdoBtnLastName.Size = new System.Drawing.Size(129, 40);
            this.rdoBtnLastName.TabIndex = 1;
            this.rdoBtnLastName.Text = "LAST NAME";
            this.rdoBtnLastName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoBtnLastName.UseVisualStyleBackColor = false;
            this.rdoBtnLastName.CheckedChanged += new System.EventHandler(this.rdoBtnLastName_CheckedChanged);
            // 
            // rdoBtnFirstName
            // 
            this.rdoBtnFirstName.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoBtnFirstName.BackColor = System.Drawing.SystemColors.Control;
            this.rdoBtnFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnFirstName.ForeColor = System.Drawing.Color.Black;
            this.rdoBtnFirstName.Location = new System.Drawing.Point(4, 61);
            this.rdoBtnFirstName.Name = "rdoBtnFirstName";
            this.rdoBtnFirstName.Size = new System.Drawing.Size(129, 40);
            this.rdoBtnFirstName.TabIndex = 0;
            this.rdoBtnFirstName.Text = "FIRST NAME";
            this.rdoBtnFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoBtnFirstName.UseVisualStyleBackColor = false;
            this.rdoBtnFirstName.CheckedChanged += new System.EventHandler(this.rdoBtnFirstName_CheckedChanged);
            // 
            // btnUpdateCustomer
            // 
            this.btnUpdateCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateCustomer.BackColor = System.Drawing.SystemColors.Control;
            this.btnUpdateCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateCustomer.ForeColor = System.Drawing.Color.Black;
            this.btnUpdateCustomer.Location = new System.Drawing.Point(754, 12);
            this.btnUpdateCustomer.Name = "btnUpdateCustomer";
            this.btnUpdateCustomer.Size = new System.Drawing.Size(85, 50);
            this.btnUpdateCustomer.TabIndex = 24;
            this.btnUpdateCustomer.Text = "UPDATE MEMBER";
            this.btnUpdateCustomer.UseVisualStyleBackColor = false;
            this.btnUpdateCustomer.Click += new System.EventHandler(this.btnUpdateCustomer_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(841, 66);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 50);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRegisterNewCustomer
            // 
            this.btnRegisterNewCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegisterNewCustomer.BackColor = System.Drawing.SystemColors.Control;
            this.btnRegisterNewCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegisterNewCustomer.ForeColor = System.Drawing.Color.Black;
            this.btnRegisterNewCustomer.Location = new System.Drawing.Point(667, 12);
            this.btnRegisterNewCustomer.Name = "btnRegisterNewCustomer";
            this.btnRegisterNewCustomer.Size = new System.Drawing.Size(85, 50);
            this.btnRegisterNewCustomer.TabIndex = 30;
            this.btnRegisterNewCustomer.Text = "REGISTER NEW MEMBER";
            this.btnRegisterNewCustomer.UseVisualStyleBackColor = false;
            this.btnRegisterNewCustomer.Click += new System.EventHandler(this.btnRegisterNewCustomer_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 40;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Location = new System.Drawing.Point(5, 122);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1010, 615);
            this.dataGridView1.TabIndex = 31;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // btnViewCustomerInfo
            // 
            this.btnViewCustomerInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewCustomerInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnViewCustomerInfo.Location = new System.Drawing.Point(580, 66);
            this.btnViewCustomerInfo.Name = "btnViewCustomerInfo";
            this.btnViewCustomerInfo.Size = new System.Drawing.Size(85, 50);
            this.btnViewCustomerInfo.TabIndex = 32;
            this.btnViewCustomerInfo.Text = "VIEW CUSTOMER INFO";
            this.btnViewCustomerInfo.UseVisualStyleBackColor = true;
            this.btnViewCustomerInfo.Click += new System.EventHandler(this.btnViewCustomerInfo_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExcel.Location = new System.Drawing.Point(667, 66);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(85, 50);
            this.btnExcel.TabIndex = 33;
            this.btnExcel.Text = "EXCEL";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Visible = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // MembershipMain
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1018, 743);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnViewCustomerInfo);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnLoadingAllCustomer);
            this.Controls.Add(this.btnDeleteCustomer);
            this.Controls.Add(this.lblNumberOfMembers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnUpdateCustomer);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRegisterNewCustomer);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MembershipMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MEMBERSHIP";
            this.Load += new System.EventHandler(this.MembershipMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadingAllCustomer;
        private System.Windows.Forms.Button btnDeleteCustomer;
        private System.Windows.Forms.Label lblNumberOfMembers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.RadioButton rdoBtnMemberCode;
        public System.Windows.Forms.TextBox txtSearchKeyword;
        public System.Windows.Forms.RadioButton rdoBtnCellPhone;
        public System.Windows.Forms.RadioButton rdoBtnHomePhone;
        public System.Windows.Forms.RadioButton rdoBtnLastName;
        public System.Windows.Forms.RadioButton rdoBtnFirstName;
        private System.Windows.Forms.Button btnUpdateCustomer;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRegisterNewCustomer;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.Button btnViewCustomerInfo;
        private System.Windows.Forms.Button btnExcel;
    }
}