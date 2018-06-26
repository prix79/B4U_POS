// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 02-08-2017
// ***********************************************************************
// <copyright file="CreditOption.designer.cs" company="Beauty4u">
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
    /// Class CreditOption.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class CreditOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreditOption));
            this.lblTitlePay = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCardNumConfirm = new System.Windows.Forms.Label();
            this.txtInputCardNum = new System.Windows.Forms.TextBox();
            this.lblLast4Digit = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtZipCode = new System.Windows.Forms.TextBox();
            this.lblCardNum = new System.Windows.Forms.Label();
            this.txtCardNum = new System.Windows.Forms.TextBox();
            this.lblAuthNum = new System.Windows.Forms.Label();
            this.lblTitleAuthNum = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblExpDate = new System.Windows.Forms.Label();
            this.lblTitleExpDate = new System.Windows.Forms.Label();
            this.lblTitleName = new System.Windows.Forms.Label();
            this.lblTitleCardNum = new System.Windows.Forms.Label();
            this.cmbCardType = new System.Windows.Forms.ComboBox();
            this.lblTitleCardType = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.lblTitleGrandTotal = new System.Windows.Forms.Label();
            this.lblPay = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnClearCardNum = new System.Windows.Forms.Button();
            this.btnGetCardInfo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitlePay
            // 
            this.lblTitlePay.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitlePay.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitlePay.ForeColor = System.Drawing.Color.Black;
            this.lblTitlePay.Location = new System.Drawing.Point(415, 133);
            this.lblTitlePay.Name = "lblTitlePay";
            this.lblTitlePay.Size = new System.Drawing.Size(313, 57);
            this.lblTitlePay.TabIndex = 138;
            this.lblTitlePay.Text = "PAY AMOUNT";
            this.lblTitlePay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PaleGreen;
            this.groupBox1.Controls.Add(this.lblCardNumConfirm);
            this.groupBox1.Controls.Add(this.txtInputCardNum);
            this.groupBox1.Controls.Add(this.lblLast4Digit);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtZipCode);
            this.groupBox1.Controls.Add(this.lblCardNum);
            this.groupBox1.Controls.Add(this.txtCardNum);
            this.groupBox1.Controls.Add(this.lblAuthNum);
            this.groupBox1.Controls.Add(this.lblTitleAuthNum);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.lblExpDate);
            this.groupBox1.Controls.Add(this.lblTitleExpDate);
            this.groupBox1.Controls.Add(this.lblTitleName);
            this.groupBox1.Controls.Add(this.lblTitleCardNum);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(18, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 551);
            this.groupBox1.TabIndex = 137;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CREDIT (PC-CHARGE)";
            // 
            // lblCardNumConfirm
            // 
            this.lblCardNumConfirm.BackColor = System.Drawing.Color.PaleGreen;
            this.lblCardNumConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCardNumConfirm.ForeColor = System.Drawing.Color.Black;
            this.lblCardNumConfirm.Location = new System.Drawing.Point(7, 140);
            this.lblCardNumConfirm.Name = "lblCardNumConfirm";
            this.lblCardNumConfirm.Size = new System.Drawing.Size(272, 38);
            this.lblCardNumConfirm.TabIndex = 209;
            this.lblCardNumConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInputCardNum
            // 
            this.txtInputCardNum.BackColor = System.Drawing.Color.PaleGreen;
            this.txtInputCardNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtInputCardNum.Location = new System.Drawing.Point(279, 140);
            this.txtInputCardNum.Name = "txtInputCardNum";
            this.txtInputCardNum.Size = new System.Drawing.Size(88, 38);
            this.txtInputCardNum.TabIndex = 208;
            // 
            // lblLast4Digit
            // 
            this.lblLast4Digit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLast4Digit.Location = new System.Drawing.Point(8, 179);
            this.lblLast4Digit.Name = "lblLast4Digit";
            this.lblLast4Digit.Size = new System.Drawing.Size(359, 29);
            this.lblLast4Digit.TabIndex = 206;
            this.lblLast4Digit.Text = "* INPUT LAST 4 DIGIT";
            this.lblLast4Digit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(7, 387);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 35);
            this.label1.TabIndex = 202;
            this.label1.Text = "ZIP CODE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtZipCode
            // 
            this.txtZipCode.Location = new System.Drawing.Point(145, 387);
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(222, 35);
            this.txtZipCode.TabIndex = 201;
            // 
            // lblCardNum
            // 
            this.lblCardNum.BackColor = System.Drawing.Color.White;
            this.lblCardNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCardNum.ForeColor = System.Drawing.Color.Black;
            this.lblCardNum.Location = new System.Drawing.Point(7, 94);
            this.lblCardNum.Name = "lblCardNum";
            this.lblCardNum.Size = new System.Drawing.Size(360, 46);
            this.lblCardNum.TabIndex = 151;
            this.lblCardNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCardNum.Visible = false;
            this.lblCardNum.VisibleChanged += new System.EventHandler(this.lblCardNum_VisibleChanged);
            // 
            // txtCardNum
            // 
            this.txtCardNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCardNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtCardNum.Location = new System.Drawing.Point(7, 94);
            this.txtCardNum.Name = "txtCardNum";
            this.txtCardNum.Size = new System.Drawing.Size(360, 46);
            this.txtCardNum.TabIndex = 141;
            this.txtCardNum.TextChanged += new System.EventHandler(this.txtCardNum_TextChanged);
            // 
            // lblAuthNum
            // 
            this.lblAuthNum.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblAuthNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAuthNum.ForeColor = System.Drawing.Color.Blue;
            this.lblAuthNum.Location = new System.Drawing.Point(7, 502);
            this.lblAuthNum.Name = "lblAuthNum";
            this.lblAuthNum.Size = new System.Drawing.Size(360, 35);
            this.lblAuthNum.TabIndex = 150;
            this.lblAuthNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitleAuthNum
            // 
            this.lblTitleAuthNum.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitleAuthNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleAuthNum.ForeColor = System.Drawing.Color.Blue;
            this.lblTitleAuthNum.Location = new System.Drawing.Point(7, 467);
            this.lblTitleAuthNum.Name = "lblTitleAuthNum";
            this.lblTitleAuthNum.Size = new System.Drawing.Size(360, 35);
            this.lblTitleAuthNum.TabIndex = 149;
            this.lblTitleAuthNum.Text = "AUTHORIZATION NUMBER";
            this.lblTitleAuthNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblName.ForeColor = System.Drawing.Color.Blue;
            this.lblName.Location = new System.Drawing.Point(7, 262);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(360, 40);
            this.lblName.TabIndex = 147;
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblExpDate
            // 
            this.lblExpDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblExpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblExpDate.ForeColor = System.Drawing.Color.Blue;
            this.lblExpDate.Location = new System.Drawing.Point(7, 341);
            this.lblExpDate.Name = "lblExpDate";
            this.lblExpDate.Size = new System.Drawing.Size(360, 40);
            this.lblExpDate.TabIndex = 144;
            this.lblExpDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitleExpDate
            // 
            this.lblTitleExpDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitleExpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleExpDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitleExpDate.Location = new System.Drawing.Point(7, 308);
            this.lblTitleExpDate.Name = "lblTitleExpDate";
            this.lblTitleExpDate.Size = new System.Drawing.Size(360, 33);
            this.lblTitleExpDate.TabIndex = 142;
            this.lblTitleExpDate.Text = "EXPIRATION DATE";
            this.lblTitleExpDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitleName
            // 
            this.lblTitleName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitleName.Location = new System.Drawing.Point(7, 217);
            this.lblTitleName.Name = "lblTitleName";
            this.lblTitleName.Size = new System.Drawing.Size(360, 45);
            this.lblTitleName.TabIndex = 140;
            this.lblTitleName.Text = "NAME";
            this.lblTitleName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitleCardNum
            // 
            this.lblTitleCardNum.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitleCardNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleCardNum.ForeColor = System.Drawing.Color.Black;
            this.lblTitleCardNum.Location = new System.Drawing.Point(7, 39);
            this.lblTitleCardNum.Name = "lblTitleCardNum";
            this.lblTitleCardNum.Size = new System.Drawing.Size(360, 55);
            this.lblTitleCardNum.TabIndex = 139;
            this.lblTitleCardNum.Text = "CARD NUMBER";
            this.lblTitleCardNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbCardType
            // 
            this.cmbCardType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCardType.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbCardType.FormattingEnabled = true;
            this.cmbCardType.Items.AddRange(new object[] {
            "VISA",
            "MASTER CARD",
            "AMEX",
            "DISCOVER"});
            this.cmbCardType.Location = new System.Drawing.Point(415, 393);
            this.cmbCardType.Name = "cmbCardType";
            this.cmbCardType.Size = new System.Drawing.Size(312, 46);
            this.cmbCardType.TabIndex = 148;
            this.cmbCardType.Visible = false;
            this.cmbCardType.SelectedIndexChanged += new System.EventHandler(this.cmbCardType_SelectedIndexChanged);
            this.cmbCardType.TextChanged += new System.EventHandler(this.cmbCardType_TextChanged);
            // 
            // lblTitleCardType
            // 
            this.lblTitleCardType.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitleCardType.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleCardType.ForeColor = System.Drawing.Color.Black;
            this.lblTitleCardType.Location = new System.Drawing.Point(415, 338);
            this.lblTitleCardType.Name = "lblTitleCardType";
            this.lblTitleCardType.Size = new System.Drawing.Size(312, 55);
            this.lblTitleCardType.TabIndex = 146;
            this.lblTitleCardType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitleCardType.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(578, 482);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 67);
            this.btnCancel.TabIndex = 136;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnCheckOut.Enabled = false;
            this.btnCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCheckOut.ForeColor = System.Drawing.Color.Black;
            this.btnCheckOut.Location = new System.Drawing.Point(415, 482);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(150, 67);
            this.btnCheckOut.TabIndex = 135;
            this.btnCheckOut.Text = "Check Out";
            this.btnCheckOut.UseVisualStyleBackColor = false;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.BackColor = System.Drawing.Color.Maroon;
            this.lblGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGrandTotal.ForeColor = System.Drawing.Color.White;
            this.lblGrandTotal.Location = new System.Drawing.Point(415, 69);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(313, 57);
            this.lblGrandTotal.TabIndex = 133;
            this.lblGrandTotal.Text = "$0.00";
            this.lblGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitleGrandTotal
            // 
            this.lblTitleGrandTotal.BackColor = System.Drawing.Color.Maroon;
            this.lblTitleGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleGrandTotal.ForeColor = System.Drawing.Color.White;
            this.lblTitleGrandTotal.Location = new System.Drawing.Point(415, 12);
            this.lblTitleGrandTotal.Name = "lblTitleGrandTotal";
            this.lblTitleGrandTotal.Size = new System.Drawing.Size(313, 57);
            this.lblTitleGrandTotal.TabIndex = 132;
            this.lblTitleGrandTotal.Text = "GRAND TOTAL";
            this.lblTitleGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPay
            // 
            this.lblPay.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblPay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPay.ForeColor = System.Drawing.Color.Black;
            this.lblPay.Location = new System.Drawing.Point(415, 191);
            this.lblPay.Name = "lblPay";
            this.lblPay.Size = new System.Drawing.Size(313, 57);
            this.lblPay.TabIndex = 139;
            this.lblPay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(415, 482);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(312, 67);
            this.btnClose.TabIndex = 140;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(415, 307);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 141;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClearCardNum
            // 
            this.btnClearCardNum.BackColor = System.Drawing.Color.MediumBlue;
            this.btnClearCardNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClearCardNum.ForeColor = System.Drawing.Color.White;
            this.btnClearCardNum.Location = new System.Drawing.Point(415, 256);
            this.btnClearCardNum.Name = "btnClearCardNum";
            this.btnClearCardNum.Size = new System.Drawing.Size(312, 45);
            this.btnClearCardNum.TabIndex = 200;
            this.btnClearCardNum.Text = "CLEAR CARD NUMBER";
            this.btnClearCardNum.UseVisualStyleBackColor = false;
            this.btnClearCardNum.Click += new System.EventHandler(this.btnClearCardNum_Click);
            // 
            // btnGetCardInfo
            // 
            this.btnGetCardInfo.Location = new System.Drawing.Point(653, 307);
            this.btnGetCardInfo.Name = "btnGetCardInfo";
            this.btnGetCardInfo.Size = new System.Drawing.Size(75, 23);
            this.btnGetCardInfo.TabIndex = 143;
            this.btnGetCardInfo.Text = "GetCardInfo";
            this.btnGetCardInfo.UseVisualStyleBackColor = true;
            this.btnGetCardInfo.Visible = false;
            this.btnGetCardInfo.Click += new System.EventHandler(this.btnGetCardInfo_Click);
            // 
            // CreditOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(747, 578);
            this.ControlBox = false;
            this.Controls.Add(this.btnGetCardInfo);
            this.Controls.Add(this.btnClearCardNum);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbCardType);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblPay);
            this.Controls.Add(this.lblTitlePay);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.lblTitleCardType);
            this.Controls.Add(this.lblGrandTotal);
            this.Controls.Add(this.lblTitleGrandTotal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreditOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PAY BY CREDIT (PC-CHARGE)";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CreditOption_FormClosed);
            this.Load += new System.EventHandler(this.CreditOption_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The label title pay
        /// </summary>
        private System.Windows.Forms.Label lblTitlePay;
        /// <summary>
        /// The group box1
        /// </summary>
        private System.Windows.Forms.GroupBox groupBox1;
        /// <summary>
        /// The BTN cancel
        /// </summary>
        private System.Windows.Forms.Button btnCancel;
        /// <summary>
        /// The BTN check out
        /// </summary>
        private System.Windows.Forms.Button btnCheckOut;
        /// <summary>
        /// The label grand total
        /// </summary>
        private System.Windows.Forms.Label lblGrandTotal;
        /// <summary>
        /// The label title grand total
        /// </summary>
        private System.Windows.Forms.Label lblTitleGrandTotal;
        /// <summary>
        /// The label title name
        /// </summary>
        private System.Windows.Forms.Label lblTitleName;
        /// <summary>
        /// The label title card number
        /// </summary>
        private System.Windows.Forms.Label lblTitleCardNum;
        /// <summary>
        /// The label exp date
        /// </summary>
        private System.Windows.Forms.Label lblExpDate;
        /// <summary>
        /// The label title exp date
        /// </summary>
        private System.Windows.Forms.Label lblTitleExpDate;
        /// <summary>
        /// The label name
        /// </summary>
        private System.Windows.Forms.Label lblName;
        /// <summary>
        /// The label title card type
        /// </summary>
        private System.Windows.Forms.Label lblTitleCardType;
        /// <summary>
        /// The CMB card type
        /// </summary>
        private System.Windows.Forms.ComboBox cmbCardType;
        /// <summary>
        /// The label authentication number
        /// </summary>
        private System.Windows.Forms.Label lblAuthNum;
        /// <summary>
        /// The label title authentication number
        /// </summary>
        private System.Windows.Forms.Label lblTitleAuthNum;
        /// <summary>
        /// The label pay
        /// </summary>
        private System.Windows.Forms.Label lblPay;
        /// <summary>
        /// The BTN close
        /// </summary>
        private System.Windows.Forms.Button btnClose;
        /// <summary>
        /// The text card number
        /// </summary>
        private System.Windows.Forms.TextBox txtCardNum;
        /// <summary>
        /// The label card number
        /// </summary>
        private System.Windows.Forms.Label lblCardNum;
        /// <summary>
        /// The button1
        /// </summary>
        private System.Windows.Forms.Button button1;
        /// <summary>
        /// The BTN clear card number
        /// </summary>
        private System.Windows.Forms.Button btnClearCardNum;
        /// <summary>
        /// The BTN get card information
        /// </summary>
        private System.Windows.Forms.Button btnGetCardInfo;
        /// <summary>
        /// The text zip code
        /// </summary>
        private System.Windows.Forms.TextBox txtZipCode;
        /// <summary>
        /// The label1
        /// </summary>
        private System.Windows.Forms.Label label1;
        /// <summary>
        /// The label last4 digit
        /// </summary>
        private System.Windows.Forms.Label lblLast4Digit;
        /// <summary>
        /// The text input card number
        /// </summary>
        private System.Windows.Forms.TextBox txtInputCardNum;
        /// <summary>
        /// The label card number confirm
        /// </summary>
        private System.Windows.Forms.Label lblCardNumConfirm;
    }
}