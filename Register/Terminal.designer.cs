// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 09-23-2015
// ***********************************************************************
// <copyright file="Terminal.designer.cs" company="Beauty4u">
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
    /// Class Terminal.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class Terminal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Terminal));
            this.lblTitlePay = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblZipCode = new System.Windows.Forms.Label();
            this.txtZipCode = new System.Windows.Forms.TextBox();
            this.lblLast4Digit = new System.Windows.Forms.Label();
            this.txtCardNum = new System.Windows.Forms.TextBox();
            this.cmbTerminalType = new System.Windows.Forms.ComboBox();
            this.lblTitleCardType = new System.Windows.Forms.Label();
            this.lblTitleCardNum = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.lblTitleGrandTotal = new System.Windows.Forms.Label();
            this.btnMakeSure = new System.Windows.Forms.Button();
            this.lblPay = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitlePay
            // 
            this.lblTitlePay.BackColor = System.Drawing.Color.White;
            this.lblTitlePay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitlePay.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitlePay.ForeColor = System.Drawing.Color.Black;
            this.lblTitlePay.Location = new System.Drawing.Point(415, 130);
            this.lblTitlePay.Name = "lblTitlePay";
            this.lblTitlePay.Size = new System.Drawing.Size(313, 57);
            this.lblTitlePay.TabIndex = 148;
            this.lblTitlePay.Text = "PAY AMOUNT";
            this.lblTitlePay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PaleGreen;
            this.groupBox1.Controls.Add(this.lblZipCode);
            this.groupBox1.Controls.Add(this.txtZipCode);
            this.groupBox1.Controls.Add(this.lblLast4Digit);
            this.groupBox1.Controls.Add(this.txtCardNum);
            this.groupBox1.Controls.Add(this.cmbTerminalType);
            this.groupBox1.Controls.Add(this.lblTitleCardType);
            this.groupBox1.Controls.Add(this.lblTitleCardNum);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(18, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 551);
            this.groupBox1.TabIndex = 147;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TERMINAL (DEBIT/CREDIT)";
            // 
            // lblZipCode
            // 
            this.lblZipCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblZipCode.Location = new System.Drawing.Point(7, 343);
            this.lblZipCode.Name = "lblZipCode";
            this.lblZipCode.Size = new System.Drawing.Size(136, 35);
            this.lblZipCode.TabIndex = 204;
            this.lblZipCode.Text = "ZIP CODE";
            this.lblZipCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblZipCode.Visible = false;
            // 
            // txtZipCode
            // 
            this.txtZipCode.Location = new System.Drawing.Point(145, 343);
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(222, 35);
            this.txtZipCode.TabIndex = 203;
            this.txtZipCode.Visible = false;
            // 
            // lblLast4Digit
            // 
            this.lblLast4Digit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLast4Digit.Location = new System.Drawing.Point(8, 241);
            this.lblLast4Digit.Name = "lblLast4Digit";
            this.lblLast4Digit.Size = new System.Drawing.Size(359, 29);
            this.lblLast4Digit.TabIndex = 160;
            this.lblLast4Digit.Text = "* INPUT LAST 4 DIGIT";
            this.lblLast4Digit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLast4Digit.Visible = false;
            // 
            // txtCardNum
            // 
            this.txtCardNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCardNum.Enabled = false;
            this.txtCardNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtCardNum.Location = new System.Drawing.Point(7, 201);
            this.txtCardNum.Name = "txtCardNum";
            this.txtCardNum.Size = new System.Drawing.Size(360, 31);
            this.txtCardNum.TabIndex = 154;
            // 
            // cmbTerminalType
            // 
            this.cmbTerminalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTerminalType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTerminalType.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbTerminalType.FormattingEnabled = true;
            this.cmbTerminalType.Items.AddRange(new object[] {
            "CREDIT (VISA)",
            "CREDIT (MASTER)",
            "CREDIT (AMEX)",
            "CREDIT (DISCOVER)"});
            this.cmbTerminalType.Location = new System.Drawing.Point(7, 94);
            this.cmbTerminalType.Name = "cmbTerminalType";
            this.cmbTerminalType.Size = new System.Drawing.Size(360, 46);
            this.cmbTerminalType.TabIndex = 159;
            this.cmbTerminalType.SelectedIndexChanged += new System.EventHandler(this.cmbTerminalType_SelectedIndexChanged);
            // 
            // lblTitleCardType
            // 
            this.lblTitleCardType.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitleCardType.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleCardType.ForeColor = System.Drawing.Color.Black;
            this.lblTitleCardType.Location = new System.Drawing.Point(7, 39);
            this.lblTitleCardType.Name = "lblTitleCardType";
            this.lblTitleCardType.Size = new System.Drawing.Size(360, 55);
            this.lblTitleCardType.TabIndex = 157;
            this.lblTitleCardType.Text = "TERMINAL TYPE";
            this.lblTitleCardType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitleCardNum
            // 
            this.lblTitleCardNum.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitleCardNum.Enabled = false;
            this.lblTitleCardNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleCardNum.ForeColor = System.Drawing.Color.Black;
            this.lblTitleCardNum.Location = new System.Drawing.Point(7, 146);
            this.lblTitleCardNum.Name = "lblTitleCardNum";
            this.lblTitleCardNum.Size = new System.Drawing.Size(360, 55);
            this.lblTitleCardNum.TabIndex = 152;
            this.lblTitleCardNum.Text = "CARD NUMBER";
            this.lblTitleCardNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.Location = new System.Drawing.Point(577, 482);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(150, 67);
            this.btnClose.TabIndex = 146;
            this.btnClose.Text = "CANCEL";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnCheckOut.Enabled = false;
            this.btnCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCheckOut.Location = new System.Drawing.Point(415, 482);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(150, 67);
            this.btnCheckOut.TabIndex = 145;
            this.btnCheckOut.Text = "CHECK OUT";
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
            this.lblGrandTotal.TabIndex = 144;
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
            this.lblTitleGrandTotal.TabIndex = 143;
            this.lblTitleGrandTotal.Text = "GRAND TOTAL";
            this.lblTitleGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMakeSure
            // 
            this.btnMakeSure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMakeSure.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMakeSure.Location = new System.Drawing.Point(414, 355);
            this.btnMakeSure.Name = "btnMakeSure";
            this.btnMakeSure.Size = new System.Drawing.Size(313, 73);
            this.btnMakeSure.TabIndex = 150;
            this.btnMakeSure.Text = "TERMINAL TRANSACTION COMPLETES";
            this.btnMakeSure.UseVisualStyleBackColor = false;
            this.btnMakeSure.Click += new System.EventHandler(this.btnMakeSure_Click);
            // 
            // lblPay
            // 
            this.lblPay.BackColor = System.Drawing.Color.White;
            this.lblPay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPay.ForeColor = System.Drawing.Color.Black;
            this.lblPay.Location = new System.Drawing.Point(415, 188);
            this.lblPay.Name = "lblPay";
            this.lblPay.Size = new System.Drawing.Size(313, 57);
            this.lblPay.TabIndex = 151;
            this.lblPay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Terminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(747, 578);
            this.ControlBox = false;
            this.Controls.Add(this.lblPay);
            this.Controls.Add(this.btnMakeSure);
            this.Controls.Add(this.lblTitlePay);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.lblGrandTotal);
            this.Controls.Add(this.lblTitleGrandTotal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Terminal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PAY BY TERMINAL";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Terminal_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Terminal_FormClosed);
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
        /// The BTN close
        /// </summary>
        private System.Windows.Forms.Button btnClose;
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
        /// The BTN make sure
        /// </summary>
        private System.Windows.Forms.Button btnMakeSure;
        /// <summary>
        /// The label pay
        /// </summary>
        private System.Windows.Forms.Label lblPay;
        /// <summary>
        /// The text card number
        /// </summary>
        private System.Windows.Forms.TextBox txtCardNum;
        /// <summary>
        /// The CMB terminal type
        /// </summary>
        private System.Windows.Forms.ComboBox cmbTerminalType;
        /// <summary>
        /// The label title card type
        /// </summary>
        private System.Windows.Forms.Label lblTitleCardType;
        /// <summary>
        /// The label title card number
        /// </summary>
        private System.Windows.Forms.Label lblTitleCardNum;
        /// <summary>
        /// The label last4 digit
        /// </summary>
        private System.Windows.Forms.Label lblLast4Digit;
        /// <summary>
        /// The label zip code
        /// </summary>
        private System.Windows.Forms.Label lblZipCode;
        /// <summary>
        /// The text zip code
        /// </summary>
        private System.Windows.Forms.TextBox txtZipCode;
    }
}