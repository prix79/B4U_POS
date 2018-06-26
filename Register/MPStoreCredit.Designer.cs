﻿// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 03-27-2017
// ***********************************************************************
// <copyright file="MPStoreCredit.Designer.cs" company="Beauty4u">
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
    /// Class MPStoreCredit.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class MPStoreCredit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MPStoreCredit));
            this.lblRemainingBalance = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCurrentBalance = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnInput = new System.Windows.Forms.Button();
            this.richtxtStoreCreditID = new System.Windows.Forms.RichTextBox();
            this.lblTitlePay = new System.Windows.Forms.Label();
            this.lblPay = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbStoreCode = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblRemainingBalance
            // 
            this.lblRemainingBalance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblRemainingBalance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRemainingBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRemainingBalance.ForeColor = System.Drawing.Color.Black;
            this.lblRemainingBalance.Location = new System.Drawing.Point(351, 333);
            this.lblRemainingBalance.Name = "lblRemainingBalance";
            this.lblRemainingBalance.Size = new System.Drawing.Size(315, 57);
            this.lblRemainingBalance.TabIndex = 172;
            this.lblRemainingBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRemainingBalance.Visible = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(351, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(315, 57);
            this.label3.TabIndex = 171;
            this.label3.Text = "REMAINING BALANCE";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Visible = false;
            // 
            // lblCurrentBalance
            // 
            this.lblCurrentBalance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblCurrentBalance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCurrentBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCurrentBalance.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentBalance.Location = new System.Drawing.Point(21, 425);
            this.lblCurrentBalance.Name = "lblCurrentBalance";
            this.lblCurrentBalance.Size = new System.Drawing.Size(315, 57);
            this.lblCurrentBalance.TabIndex = 170;
            this.lblCurrentBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(21, 368);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 57);
            this.label1.TabIndex = 169;
            this.label1.Text = "CURRENT BALANCE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.Location = new System.Drawing.Point(516, 415);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 67);
            this.btnCancel.TabIndex = 168;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnCheckOut.Enabled = false;
            this.btnCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCheckOut.Location = new System.Drawing.Point(353, 415);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(150, 67);
            this.btnCheckOut.TabIndex = 167;
            this.btnCheckOut.Text = "CHECK OUT";
            this.btnCheckOut.UseVisualStyleBackColor = false;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // btnInput
            // 
            this.btnInput.BackColor = System.Drawing.Color.MediumBlue;
            this.btnInput.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnInput.FlatAppearance.BorderSize = 0;
            this.btnInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnInput.ForeColor = System.Drawing.Color.White;
            this.btnInput.Location = new System.Drawing.Point(21, 244);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(315, 57);
            this.btnInput.TabIndex = 166;
            this.btnInput.Text = "INPUT";
            this.btnInput.UseVisualStyleBackColor = false;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // richtxtStoreCreditID
            // 
            this.richtxtStoreCreditID.BackColor = System.Drawing.Color.WhiteSmoke;
            this.richtxtStoreCreditID.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.richtxtStoreCreditID.ForeColor = System.Drawing.Color.Black;
            this.richtxtStoreCreditID.Location = new System.Drawing.Point(21, 75);
            this.richtxtStoreCreditID.Multiline = false;
            this.richtxtStoreCreditID.Name = "richtxtStoreCreditID";
            this.richtxtStoreCreditID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.richtxtStoreCreditID.Size = new System.Drawing.Size(313, 57);
            this.richtxtStoreCreditID.TabIndex = 165;
            this.richtxtStoreCreditID.Text = "";
            // 
            // lblTitlePay
            // 
            this.lblTitlePay.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitlePay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitlePay.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitlePay.ForeColor = System.Drawing.Color.Black;
            this.lblTitlePay.Location = new System.Drawing.Point(21, 17);
            this.lblTitlePay.Name = "lblTitlePay";
            this.lblTitlePay.Size = new System.Drawing.Size(313, 57);
            this.lblTitlePay.TabIndex = 164;
            this.lblTitlePay.Text = "STORE CREDIT ID";
            this.lblTitlePay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPay
            // 
            this.lblPay.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblPay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPay.ForeColor = System.Drawing.Color.Black;
            this.lblPay.Location = new System.Drawing.Point(353, 75);
            this.lblPay.Name = "lblPay";
            this.lblPay.Size = new System.Drawing.Size(313, 57);
            this.lblPay.TabIndex = 174;
            this.lblPay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(353, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(313, 57);
            this.label2.TabIndex = 173;
            this.label2.Text = "PAY AMOUNT";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(21, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(313, 57);
            this.label4.TabIndex = 176;
            this.label4.Text = "STORE CODE";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.cmbStoreCode.Location = new System.Drawing.Point(22, 193);
            this.cmbStoreCode.Name = "cmbStoreCode";
            this.cmbStoreCode.Size = new System.Drawing.Size(312, 45);
            this.cmbStoreCode.TabIndex = 175;
            // 
            // MPStoreCredit
            // 
            this.AcceptButton = this.btnInput;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(683, 500);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbStoreCode);
            this.Controls.Add(this.lblPay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblRemainingBalance);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCurrentBalance);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.richtxtStoreCreditID);
            this.Controls.Add(this.lblTitlePay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MPStoreCredit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PAY BY STORE CREDIT";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MPStoreCredit_Load);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The label remaining balance
        /// </summary>
        private System.Windows.Forms.Label lblRemainingBalance;
        /// <summary>
        /// The label3
        /// </summary>
        private System.Windows.Forms.Label label3;
        /// <summary>
        /// The label current balance
        /// </summary>
        private System.Windows.Forms.Label lblCurrentBalance;
        /// <summary>
        /// The label1
        /// </summary>
        private System.Windows.Forms.Label label1;
        /// <summary>
        /// The BTN cancel
        /// </summary>
        private System.Windows.Forms.Button btnCancel;
        /// <summary>
        /// The BTN check out
        /// </summary>
        private System.Windows.Forms.Button btnCheckOut;
        /// <summary>
        /// The BTN input
        /// </summary>
        private System.Windows.Forms.Button btnInput;
        /// <summary>
        /// The richtxt store credit identifier
        /// </summary>
        private System.Windows.Forms.RichTextBox richtxtStoreCreditID;
        /// <summary>
        /// The label title pay
        /// </summary>
        private System.Windows.Forms.Label lblTitlePay;
        /// <summary>
        /// The label pay
        /// </summary>
        private System.Windows.Forms.Label lblPay;
        /// <summary>
        /// The label2
        /// </summary>
        private System.Windows.Forms.Label label2;
        /// <summary>
        /// The label4
        /// </summary>
        private System.Windows.Forms.Label label4;
        /// <summary>
        /// The CMB store code
        /// </summary>
        private System.Windows.Forms.ComboBox cmbStoreCode;
    }
}