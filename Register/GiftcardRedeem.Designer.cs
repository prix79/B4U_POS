// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 09-19-2015
// ***********************************************************************
// <copyright file="GiftcardRedeem.Designer.cs" company="Beauty4u">
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
    /// Class GiftcardRedeem.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class GiftcardRedeem
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
            this.txtGiftCardCode = new System.Windows.Forms.TextBox();
            this.lblCurrentBalance = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInput = new System.Windows.Forms.Button();
            this.lblTitlePay = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.radioBtnAllAmount = new System.Windows.Forms.RadioButton();
            this.radioBtnInputAmount = new System.Windows.Forms.RadioButton();
            this.btnRedeem = new System.Windows.Forms.Button();
            this.txtInputAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbStoreCode = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtGiftCardCode
            // 
            this.txtGiftCardCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtGiftCardCode.Location = new System.Drawing.Point(12, 67);
            this.txtGiftCardCode.Name = "txtGiftCardCode";
            this.txtGiftCardCode.Size = new System.Drawing.Size(315, 56);
            this.txtGiftCardCode.TabIndex = 176;
            // 
            // lblCurrentBalance
            // 
            this.lblCurrentBalance.BackColor = System.Drawing.Color.White;
            this.lblCurrentBalance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCurrentBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCurrentBalance.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentBalance.Location = new System.Drawing.Point(12, 267);
            this.lblCurrentBalance.Name = "lblCurrentBalance";
            this.lblCurrentBalance.Size = new System.Drawing.Size(315, 67);
            this.lblCurrentBalance.TabIndex = 179;
            this.lblCurrentBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCurrentBalance.TextChanged += new System.EventHandler(this.lblCurrentBalance_TextChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 67);
            this.label1.TabIndex = 178;
            this.label1.Text = "CURRENT BALANCE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnInput
            // 
            this.btnInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnInput.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnInput.FlatAppearance.BorderSize = 0;
            this.btnInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnInput.ForeColor = System.Drawing.Color.White;
            this.btnInput.Location = new System.Drawing.Point(12, 134);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(315, 57);
            this.btnInput.TabIndex = 177;
            this.btnInput.Text = "INPUT";
            this.btnInput.UseVisualStyleBackColor = false;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // lblTitlePay
            // 
            this.lblTitlePay.BackColor = System.Drawing.Color.White;
            this.lblTitlePay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitlePay.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitlePay.ForeColor = System.Drawing.Color.Black;
            this.lblTitlePay.Location = new System.Drawing.Point(12, 9);
            this.lblTitlePay.Name = "lblTitlePay";
            this.lblTitlePay.Size = new System.Drawing.Size(315, 57);
            this.lblTitlePay.TabIndex = 175;
            this.lblTitlePay.Text = "GIFT CARD CODE";
            this.lblTitlePay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.PaleGreen;
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.radioBtnAllAmount);
            this.groupBox2.Controls.Add(this.radioBtnInputAmount);
            this.groupBox2.Controls.Add(this.btnRedeem);
            this.groupBox2.Controls.Add(this.txtInputAmount);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(344, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(391, 215);
            this.groupBox2.TabIndex = 180;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "REDEEM OPTIONS";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(202, 148);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(180, 60);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // radioBtnAllAmount
            // 
            this.radioBtnAllAmount.AutoSize = true;
            this.radioBtnAllAmount.BackColor = System.Drawing.Color.PaleGreen;
            this.radioBtnAllAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.radioBtnAllAmount.Location = new System.Drawing.Point(9, 95);
            this.radioBtnAllAmount.Name = "radioBtnAllAmount";
            this.radioBtnAllAmount.Size = new System.Drawing.Size(193, 33);
            this.radioBtnAllAmount.TabIndex = 0;
            this.radioBtnAllAmount.Text = "ALL AMOUNT";
            this.radioBtnAllAmount.UseVisualStyleBackColor = false;
            // 
            // radioBtnInputAmount
            // 
            this.radioBtnInputAmount.AutoSize = true;
            this.radioBtnInputAmount.BackColor = System.Drawing.Color.PaleGreen;
            this.radioBtnInputAmount.Checked = true;
            this.radioBtnInputAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.radioBtnInputAmount.Location = new System.Drawing.Point(9, 41);
            this.radioBtnInputAmount.Name = "radioBtnInputAmount";
            this.radioBtnInputAmount.Size = new System.Drawing.Size(227, 33);
            this.radioBtnInputAmount.TabIndex = 1;
            this.radioBtnInputAmount.TabStop = true;
            this.radioBtnInputAmount.Text = "INPUT AMOUNT";
            this.radioBtnInputAmount.UseVisualStyleBackColor = false;
            // 
            // btnRedeem
            // 
            this.btnRedeem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnRedeem.Enabled = false;
            this.btnRedeem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRedeem.ForeColor = System.Drawing.Color.Black;
            this.btnRedeem.Location = new System.Drawing.Point(9, 148);
            this.btnRedeem.Name = "btnRedeem";
            this.btnRedeem.Size = new System.Drawing.Size(180, 60);
            this.btnRedeem.TabIndex = 3;
            this.btnRedeem.Text = "REDEEM";
            this.btnRedeem.UseVisualStyleBackColor = false;
            this.btnRedeem.Click += new System.EventHandler(this.btnRedeem_Click);
            // 
            // txtInputAmount
            // 
            this.txtInputAmount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtInputAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtInputAmount.Location = new System.Drawing.Point(251, 41);
            this.txtInputAmount.Name = "txtInputAmount";
            this.txtInputAmount.Size = new System.Drawing.Size(131, 35);
            this.txtInputAmount.TabIndex = 2;
            this.txtInputAmount.Text = "0.00";
            this.txtInputAmount.Click += new System.EventHandler(this.txtInputAmount_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(344, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(391, 57);
            this.label2.TabIndex = 181;
            this.label2.Text = "STORE CODE";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbStoreCode
            // 
            this.cmbStoreCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStoreCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbStoreCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbStoreCode.FormattingEnabled = true;
            this.cmbStoreCode.Items.AddRange(new object[] {
            "TH",
            "OH",
            "UM",
            "CH",
            "WM",
            "CV",
            "WB",
            "WD",
            "PW",
            "GB",
            "BW"});
            this.cmbStoreCode.Location = new System.Drawing.Point(345, 68);
            this.cmbStoreCode.Name = "cmbStoreCode";
            this.cmbStoreCode.Size = new System.Drawing.Size(390, 45);
            this.cmbStoreCode.TabIndex = 182;
            // 
            // GiftcardRedeem
            // 
            this.AcceptButton = this.btnInput;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(748, 346);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbStoreCode);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtGiftCardCode);
            this.Controls.Add(this.lblCurrentBalance);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.lblTitlePay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GiftcardRedeem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GIFTCARD REDEEM";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.GiftcardRedeem_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /// <summary>
        /// The text gift card code
        /// </summary>
        private System.Windows.Forms.TextBox txtGiftCardCode;
        /// <summary>
        /// The label current balance
        /// </summary>
        private System.Windows.Forms.Label lblCurrentBalance;
        /// <summary>
        /// The label1
        /// </summary>
        private System.Windows.Forms.Label label1;
        /// <summary>
        /// The BTN input
        /// </summary>
        private System.Windows.Forms.Button btnInput;
        /// <summary>
        /// The label title pay
        /// </summary>
        private System.Windows.Forms.Label lblTitlePay;
        /// <summary>
        /// The group box2
        /// </summary>
        private System.Windows.Forms.GroupBox groupBox2;
        /// <summary>
        /// The BTN cancel
        /// </summary>
        private System.Windows.Forms.Button btnCancel;
        /// <summary>
        /// The radio BTN all amount
        /// </summary>
        private System.Windows.Forms.RadioButton radioBtnAllAmount;
        /// <summary>
        /// The radio BTN input amount
        /// </summary>
        private System.Windows.Forms.RadioButton radioBtnInputAmount;
        /// <summary>
        /// The BTN redeem
        /// </summary>
        private System.Windows.Forms.Button btnRedeem;
        /// <summary>
        /// The text input amount
        /// </summary>
        private System.Windows.Forms.TextBox txtInputAmount;
        /// <summary>
        /// The label2
        /// </summary>
        private System.Windows.Forms.Label label2;
        /// <summary>
        /// The CMB store code
        /// </summary>
        public System.Windows.Forms.ComboBox cmbStoreCode;

    }
}