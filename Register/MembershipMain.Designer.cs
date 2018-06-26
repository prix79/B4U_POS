// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 01-31-2018
// ***********************************************************************
// <copyright file="MembershipMain.Designer.cs" company="Beauty4u">
//     Copyright © Beauty4u 2009
// </copyright>
// <summary></summary>
// ***********************************************************************
/// <summary>
/// The Register namespace.
/// </summary>
namespace Register
{
    /// <summary>
    /// Class MembershipMain.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class MembershipMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        /// <summary>
        /// The components
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /// <summary>
        /// Disposes of the resources (other than memory) used by the <see cref="T:System.Windows.Forms.Form" />.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
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
        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MembershipMain));
            this.btnLoadingAllCustomer = new System.Windows.Forms.Button();
            this.btnDeleteCustomer = new System.Windows.Forms.Button();
            this.btnSelectCustomer = new System.Windows.Forms.Button();
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadingAllCustomer
            // 
            this.btnLoadingAllCustomer.BackColor = System.Drawing.Color.MediumBlue;
            this.btnLoadingAllCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadingAllCustomer.ForeColor = System.Drawing.Color.White;
            this.btnLoadingAllCustomer.Location = new System.Drawing.Point(580, 12);
            this.btnLoadingAllCustomer.Name = "btnLoadingAllCustomer";
            this.btnLoadingAllCustomer.Size = new System.Drawing.Size(96, 50);
            this.btnLoadingAllCustomer.TabIndex = 22;
            this.btnLoadingAllCustomer.Text = "LOADING ALL MEMBER";
            this.btnLoadingAllCustomer.UseVisualStyleBackColor = false;
            this.btnLoadingAllCustomer.Click += new System.EventHandler(this.btnLoadingAllCustomer_Click);
            // 
            // btnDeleteCustomer
            // 
            this.btnDeleteCustomer.BackColor = System.Drawing.Color.MediumBlue;
            this.btnDeleteCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCustomer.ForeColor = System.Drawing.Color.White;
            this.btnDeleteCustomer.Location = new System.Drawing.Point(680, 66);
            this.btnDeleteCustomer.Name = "btnDeleteCustomer";
            this.btnDeleteCustomer.Size = new System.Drawing.Size(96, 50);
            this.btnDeleteCustomer.TabIndex = 29;
            this.btnDeleteCustomer.Text = "DELETE MEMBER";
            this.btnDeleteCustomer.UseVisualStyleBackColor = false;
            this.btnDeleteCustomer.Visible = false;
            this.btnDeleteCustomer.Click += new System.EventHandler(this.btnDeleteCustomer_Click);
            // 
            // btnSelectCustomer
            // 
            this.btnSelectCustomer.BackColor = System.Drawing.Color.MediumBlue;
            this.btnSelectCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectCustomer.ForeColor = System.Drawing.Color.White;
            this.btnSelectCustomer.Location = new System.Drawing.Point(580, 66);
            this.btnSelectCustomer.Name = "btnSelectCustomer";
            this.btnSelectCustomer.Size = new System.Drawing.Size(96, 50);
            this.btnSelectCustomer.TabIndex = 28;
            this.btnSelectCustomer.Text = "SELECT MEMBER";
            this.btnSelectCustomer.UseVisualStyleBackColor = false;
            this.btnSelectCustomer.Click += new System.EventHandler(this.btnSelectCustomer_Click);
            // 
            // lblNumberOfMembers
            // 
            this.lblNumberOfMembers.BackColor = System.Drawing.Color.NavajoWhite;
            this.lblNumberOfMembers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumberOfMembers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNumberOfMembers.ForeColor = System.Drawing.Color.Black;
            this.lblNumberOfMembers.Location = new System.Drawing.Point(880, 66);
            this.lblNumberOfMembers.Name = "lblNumberOfMembers";
            this.lblNumberOfMembers.Size = new System.Drawing.Size(135, 50);
            this.lblNumberOfMembers.TabIndex = 27;
            this.lblNumberOfMembers.Text = "0";
            this.lblNumberOfMembers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(880, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 53);
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
            this.btnMerge.BackColor = System.Drawing.Color.Maroon;
            this.btnMerge.Enabled = false;
            this.btnMerge.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnMerge.ForeColor = System.Drawing.Color.White;
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
            this.btnSearch.BackColor = System.Drawing.Color.MediumBlue;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
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
            this.rdoBtnMemberCode.BackColor = System.Drawing.Color.Green;
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
            this.rdoBtnCellPhone.BackColor = System.Drawing.Color.DarkSeaGreen;
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
            this.rdoBtnHomePhone.BackColor = System.Drawing.Color.DarkSeaGreen;
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
            this.rdoBtnLastName.BackColor = System.Drawing.Color.DarkSeaGreen;
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
            this.rdoBtnFirstName.BackColor = System.Drawing.Color.DarkSeaGreen;
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
            this.btnUpdateCustomer.BackColor = System.Drawing.Color.MediumBlue;
            this.btnUpdateCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateCustomer.ForeColor = System.Drawing.Color.White;
            this.btnUpdateCustomer.Location = new System.Drawing.Point(780, 12);
            this.btnUpdateCustomer.Name = "btnUpdateCustomer";
            this.btnUpdateCustomer.Size = new System.Drawing.Size(96, 50);
            this.btnUpdateCustomer.TabIndex = 24;
            this.btnUpdateCustomer.Text = "UPDATE MEMBER";
            this.btnUpdateCustomer.UseVisualStyleBackColor = false;
            this.btnUpdateCustomer.Click += new System.EventHandler(this.btnUpdateCustomer_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.MediumBlue;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(780, 66);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 50);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRegisterNewCustomer
            // 
            this.btnRegisterNewCustomer.BackColor = System.Drawing.Color.MediumBlue;
            this.btnRegisterNewCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegisterNewCustomer.ForeColor = System.Drawing.Color.White;
            this.btnRegisterNewCustomer.Location = new System.Drawing.Point(680, 12);
            this.btnRegisterNewCustomer.Name = "btnRegisterNewCustomer";
            this.btnRegisterNewCustomer.Size = new System.Drawing.Size(96, 50);
            this.btnRegisterNewCustomer.TabIndex = 30;
            this.btnRegisterNewCustomer.Text = "REGISTER NEW MEMBER";
            this.btnRegisterNewCustomer.UseVisualStyleBackColor = false;
            this.btnRegisterNewCustomer.Click += new System.EventHandler(this.btnRegisterNewCustomer_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Gainsboro;
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
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(940, 714);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 32;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MembershipMain
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(1018, 743);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnLoadingAllCustomer);
            this.Controls.Add(this.btnDeleteCustomer);
            this.Controls.Add(this.btnSelectCustomer);
            this.Controls.Add(this.lblNumberOfMembers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnUpdateCustomer);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRegisterNewCustomer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MembershipMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MEMBERSHIP";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MembershipMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The BTN loading all customer
        /// </summary>
        private System.Windows.Forms.Button btnLoadingAllCustomer;
        /// <summary>
        /// The BTN delete customer
        /// </summary>
        private System.Windows.Forms.Button btnDeleteCustomer;
        /// <summary>
        /// The BTN select customer
        /// </summary>
        private System.Windows.Forms.Button btnSelectCustomer;
        /// <summary>
        /// The label number of members
        /// </summary>
        private System.Windows.Forms.Label lblNumberOfMembers;
        /// <summary>
        /// The label1
        /// </summary>
        private System.Windows.Forms.Label label1;
        /// <summary>
        /// The group box1
        /// </summary>
        private System.Windows.Forms.GroupBox groupBox1;
        /// <summary>
        /// The BTN search
        /// </summary>
        private System.Windows.Forms.Button btnSearch;
        /// <summary>
        /// The rdo BTN member code
        /// </summary>
        public System.Windows.Forms.RadioButton rdoBtnMemberCode;
        /// <summary>
        /// The text search keyword
        /// </summary>
        public System.Windows.Forms.TextBox txtSearchKeyword;
        /// <summary>
        /// The rdo BTN cell phone
        /// </summary>
        public System.Windows.Forms.RadioButton rdoBtnCellPhone;
        /// <summary>
        /// The rdo BTN home phone
        /// </summary>
        public System.Windows.Forms.RadioButton rdoBtnHomePhone;
        /// <summary>
        /// The rdo BTN last name
        /// </summary>
        public System.Windows.Forms.RadioButton rdoBtnLastName;
        /// <summary>
        /// The rdo BTN first name
        /// </summary>
        public System.Windows.Forms.RadioButton rdoBtnFirstName;
        /// <summary>
        /// The BTN update customer
        /// </summary>
        private System.Windows.Forms.Button btnUpdateCustomer;
        /// <summary>
        /// The BTN close
        /// </summary>
        private System.Windows.Forms.Button btnClose;
        /// <summary>
        /// The BTN register new customer
        /// </summary>
        private System.Windows.Forms.Button btnRegisterNewCustomer;
        /// <summary>
        /// The data grid view1
        /// </summary>
        public System.Windows.Forms.DataGridView dataGridView1;
        /// <summary>
        /// The BTN merge
        /// </summary>
        private System.Windows.Forms.Button btnMerge;
        /// <summary>
        /// The button1
        /// </summary>
        private System.Windows.Forms.Button button1;
    }
}