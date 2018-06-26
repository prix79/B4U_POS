// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 04-20-2010
// ***********************************************************************
// <copyright file="CashOption.designer.cs" company="Beauty4u">
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
    /// Class CashOption.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class CashOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashOption));
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.lblTitleGrandTotal = new System.Windows.Forms.Label();
            this.richtxtPay = new System.Windows.Forms.RichTextBox();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCLS = new System.Windows.Forms.Button();
            this.btnExactTender = new System.Windows.Forms.Button();
            this.button0 = new System.Windows.Forms.Button();
            this.button00 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblTitlePay = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTimer = new System.Windows.Forms.Label();
            this.btnFiveDollar = new System.Windows.Forms.Button();
            this.btnTenDollar = new System.Windows.Forms.Button();
            this.btnTwentyDollar = new System.Windows.Forms.Button();
            this.btnFiftyDollar = new System.Windows.Forms.Button();
            this.btnOneHundred = new System.Windows.Forms.Button();
            this.btnOneDollar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.BackColor = System.Drawing.Color.Maroon;
            this.lblGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGrandTotal.ForeColor = System.Drawing.Color.White;
            this.lblGrandTotal.Location = new System.Drawing.Point(557, 69);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(313, 57);
            this.lblGrandTotal.TabIndex = 123;
            this.lblGrandTotal.Text = "$0.00";
            this.lblGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitleGrandTotal
            // 
            this.lblTitleGrandTotal.BackColor = System.Drawing.Color.Maroon;
            this.lblTitleGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleGrandTotal.ForeColor = System.Drawing.Color.White;
            this.lblTitleGrandTotal.Location = new System.Drawing.Point(557, 12);
            this.lblTitleGrandTotal.Name = "lblTitleGrandTotal";
            this.lblTitleGrandTotal.Size = new System.Drawing.Size(313, 57);
            this.lblTitleGrandTotal.TabIndex = 122;
            this.lblTitleGrandTotal.Text = "GRAND TOTAL";
            this.lblTitleGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // richtxtPay
            // 
            this.richtxtPay.BackColor = System.Drawing.Color.WhiteSmoke;
            this.richtxtPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.richtxtPay.ForeColor = System.Drawing.Color.Black;
            this.richtxtPay.Location = new System.Drawing.Point(557, 187);
            this.richtxtPay.Multiline = false;
            this.richtxtPay.Name = "richtxtPay";
            this.richtxtPay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.richtxtPay.Size = new System.Drawing.Size(313, 57);
            this.richtxtPay.TabIndex = 124;
            this.richtxtPay.Text = "0.00";
            this.richtxtPay.TextChanged += new System.EventHandler(this.richtxtPay_TextChanged);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnCheckOut.Enabled = false;
            this.btnCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCheckOut.Location = new System.Drawing.Point(557, 383);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(150, 73);
            this.btnCheckOut.TabIndex = 125;
            this.btnCheckOut.Text = "CHECK OUT";
            this.btnCheckOut.UseVisualStyleBackColor = false;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.Location = new System.Drawing.Point(720, 383);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 73);
            this.btnCancel.TabIndex = 126;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PaleGreen;
            this.groupBox1.Controls.Add(this.btnCLS);
            this.groupBox1.Controls.Add(this.btnExactTender);
            this.groupBox1.Controls.Add(this.button0);
            this.groupBox1.Controls.Add(this.button00);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(18, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 546);
            this.groupBox1.TabIndex = 127;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CASH PAYMENT";
            // 
            // btnCLS
            // 
            this.btnCLS.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCLS.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCLS.ForeColor = System.Drawing.Color.Red;
            this.btnCLS.Location = new System.Drawing.Point(247, 352);
            this.btnCLS.Name = "btnCLS";
            this.btnCLS.Size = new System.Drawing.Size(115, 100);
            this.btnCLS.TabIndex = 13;
            this.btnCLS.Text = "CLEAR";
            this.btnCLS.UseVisualStyleBackColor = false;
            this.btnCLS.Click += new System.EventHandler(this.btnCLS_Click);
            // 
            // btnExactTender
            // 
            this.btnExactTender.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnExactTender.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExactTender.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnExactTender.Location = new System.Drawing.Point(12, 457);
            this.btnExactTender.Name = "btnExactTender";
            this.btnExactTender.Size = new System.Drawing.Size(350, 81);
            this.btnExactTender.TabIndex = 12;
            this.btnExactTender.Text = "EXACT TENDER";
            this.btnExactTender.UseVisualStyleBackColor = false;
            this.btnExactTender.Click += new System.EventHandler(this.btnExactTender_Click);
            // 
            // button0
            // 
            this.button0.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button0.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button0.ForeColor = System.Drawing.Color.Black;
            this.button0.Location = new System.Drawing.Point(129, 352);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(115, 100);
            this.button0.TabIndex = 11;
            this.button0.Text = "0";
            this.button0.UseVisualStyleBackColor = false;
            this.button0.Click += new System.EventHandler(this.button0_Click);
            // 
            // button00
            // 
            this.button00.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button00.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button00.ForeColor = System.Drawing.Color.Black;
            this.button00.Location = new System.Drawing.Point(12, 352);
            this.button00.Name = "button00";
            this.button00.Size = new System.Drawing.Size(115, 100);
            this.button00.TabIndex = 10;
            this.button00.Text = "00";
            this.button00.UseVisualStyleBackColor = false;
            this.button00.Click += new System.EventHandler(this.button00_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button9.ForeColor = System.Drawing.Color.Black;
            this.button9.Location = new System.Drawing.Point(247, 40);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(115, 100);
            this.button9.TabIndex = 9;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button6.ForeColor = System.Drawing.Color.Black;
            this.button6.Location = new System.Drawing.Point(247, 144);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(115, 100);
            this.button6.TabIndex = 6;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(129, 144);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(115, 100);
            this.button5.TabIndex = 5;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button8.ForeColor = System.Drawing.Color.Black;
            this.button8.Location = new System.Drawing.Point(129, 40);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(115, 100);
            this.button8.TabIndex = 8;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button7.ForeColor = System.Drawing.Color.Black;
            this.button7.Location = new System.Drawing.Point(11, 40);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(115, 100);
            this.button7.TabIndex = 7;
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(11, 144);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(115, 100);
            this.button4.TabIndex = 4;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(247, 248);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 100);
            this.button3.TabIndex = 3;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(129, 248);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 100);
            this.button2.TabIndex = 2;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(11, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 100);
            this.button1.TabIndex = 1;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblTitlePay
            // 
            this.lblTitlePay.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitlePay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitlePay.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitlePay.ForeColor = System.Drawing.Color.Black;
            this.lblTitlePay.Location = new System.Drawing.Point(557, 130);
            this.lblTitlePay.Name = "lblTitlePay";
            this.lblTitlePay.Size = new System.Drawing.Size(313, 57);
            this.lblTitlePay.TabIndex = 128;
            this.lblTitlePay.Text = "PAY AMOUNT";
            this.lblTitlePay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblChange
            // 
            this.lblChange.BackColor = System.Drawing.Color.MediumBlue;
            this.lblChange.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblChange.Location = new System.Drawing.Point(557, 305);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(313, 68);
            this.lblChange.TabIndex = 130;
            this.lblChange.Text = "$0.00";
            this.lblChange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblChange.TextChanged += new System.EventHandler(this.lblChange_TextChanged);
            // 
            // btnChange
            // 
            this.btnChange.BackColor = System.Drawing.Color.MediumBlue;
            this.btnChange.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnChange.FlatAppearance.BorderSize = 0;
            this.btnChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnChange.Location = new System.Drawing.Point(557, 248);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(313, 57);
            this.btnChange.TabIndex = 131;
            this.btnChange.Text = "CALCULATE CHANGE";
            this.btnChange.UseVisualStyleBackColor = false;
            this.btnChange.Visible = false;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(557, 383);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(313, 73);
            this.btnClose.TabIndex = 132;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTimer
            // 
            this.lblTimer.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTimer.ForeColor = System.Drawing.Color.Black;
            this.lblTimer.Location = new System.Drawing.Point(557, 469);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(313, 89);
            this.lblTimer.TabIndex = 13;
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFiveDollar
            // 
            this.btnFiveDollar.BackColor = System.Drawing.Color.LightGray;
            this.btnFiveDollar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFiveDollar.ForeColor = System.Drawing.Color.Black;
            this.btnFiveDollar.Location = new System.Drawing.Point(408, 104);
            this.btnFiveDollar.Name = "btnFiveDollar";
            this.btnFiveDollar.Size = new System.Drawing.Size(132, 73);
            this.btnFiveDollar.TabIndex = 133;
            this.btnFiveDollar.Text = "$5.00";
            this.btnFiveDollar.UseVisualStyleBackColor = false;
            this.btnFiveDollar.Click += new System.EventHandler(this.btnFiveDollar_Click);
            // 
            // btnTenDollar
            // 
            this.btnTenDollar.BackColor = System.Drawing.Color.LightGray;
            this.btnTenDollar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTenDollar.ForeColor = System.Drawing.Color.Black;
            this.btnTenDollar.Location = new System.Drawing.Point(408, 198);
            this.btnTenDollar.Name = "btnTenDollar";
            this.btnTenDollar.Size = new System.Drawing.Size(132, 73);
            this.btnTenDollar.TabIndex = 134;
            this.btnTenDollar.Text = "$10.00";
            this.btnTenDollar.UseVisualStyleBackColor = false;
            this.btnTenDollar.Click += new System.EventHandler(this.btnTenDollar_Click);
            // 
            // btnTwentyDollar
            // 
            this.btnTwentyDollar.BackColor = System.Drawing.Color.LightGray;
            this.btnTwentyDollar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTwentyDollar.ForeColor = System.Drawing.Color.Black;
            this.btnTwentyDollar.Location = new System.Drawing.Point(408, 292);
            this.btnTwentyDollar.Name = "btnTwentyDollar";
            this.btnTwentyDollar.Size = new System.Drawing.Size(132, 73);
            this.btnTwentyDollar.TabIndex = 135;
            this.btnTwentyDollar.Text = "$20.00";
            this.btnTwentyDollar.UseVisualStyleBackColor = false;
            this.btnTwentyDollar.Click += new System.EventHandler(this.btnTwentyDollar_Click);
            // 
            // btnFiftyDollar
            // 
            this.btnFiftyDollar.BackColor = System.Drawing.Color.LightGray;
            this.btnFiftyDollar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFiftyDollar.ForeColor = System.Drawing.Color.Black;
            this.btnFiftyDollar.Location = new System.Drawing.Point(408, 383);
            this.btnFiftyDollar.Name = "btnFiftyDollar";
            this.btnFiftyDollar.Size = new System.Drawing.Size(132, 73);
            this.btnFiftyDollar.TabIndex = 136;
            this.btnFiftyDollar.Text = "$50.00";
            this.btnFiftyDollar.UseVisualStyleBackColor = false;
            this.btnFiftyDollar.Click += new System.EventHandler(this.btnFiftyDollar_Click);
            // 
            // btnOneHundred
            // 
            this.btnOneHundred.BackColor = System.Drawing.Color.LightGray;
            this.btnOneHundred.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOneHundred.ForeColor = System.Drawing.Color.Black;
            this.btnOneHundred.Location = new System.Drawing.Point(408, 477);
            this.btnOneHundred.Name = "btnOneHundred";
            this.btnOneHundred.Size = new System.Drawing.Size(132, 73);
            this.btnOneHundred.TabIndex = 137;
            this.btnOneHundred.Text = "$100.00";
            this.btnOneHundred.UseVisualStyleBackColor = false;
            this.btnOneHundred.Click += new System.EventHandler(this.btnOneHundred_Click);
            // 
            // btnOneDollar
            // 
            this.btnOneDollar.BackColor = System.Drawing.Color.LightGray;
            this.btnOneDollar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOneDollar.ForeColor = System.Drawing.Color.Black;
            this.btnOneDollar.Location = new System.Drawing.Point(408, 12);
            this.btnOneDollar.Name = "btnOneDollar";
            this.btnOneDollar.Size = new System.Drawing.Size(132, 73);
            this.btnOneDollar.TabIndex = 138;
            this.btnOneDollar.Text = "$1.00";
            this.btnOneDollar.UseVisualStyleBackColor = false;
            this.btnOneDollar.Click += new System.EventHandler(this.btnOneDollar_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.MediumBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(557, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 57);
            this.label1.TabIndex = 139;
            this.label1.Text = "CHANGE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CashOption
            // 
            this.AcceptButton = this.btnChange;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(889, 575);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOneDollar);
            this.Controls.Add(this.btnOneHundred);
            this.Controls.Add(this.btnFiftyDollar);
            this.Controls.Add(this.btnTwentyDollar);
            this.Controls.Add(this.btnTenDollar);
            this.Controls.Add(this.btnFiveDollar);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.lblChange);
            this.Controls.Add(this.lblTitlePay);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.richtxtPay);
            this.Controls.Add(this.lblGrandTotal);
            this.Controls.Add(this.lblTitleGrandTotal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CashOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PAY BY CASH";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.CashOption_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CashOption_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The label grand total
        /// </summary>
        private System.Windows.Forms.Label lblGrandTotal;
        /// <summary>
        /// The label title grand total
        /// </summary>
        private System.Windows.Forms.Label lblTitleGrandTotal;
        /// <summary>
        /// The richtxt pay
        /// </summary>
        private System.Windows.Forms.RichTextBox richtxtPay;
        /// <summary>
        /// The BTN check out
        /// </summary>
        private System.Windows.Forms.Button btnCheckOut;
        /// <summary>
        /// The BTN cancel
        /// </summary>
        private System.Windows.Forms.Button btnCancel;
        /// <summary>
        /// The group box1
        /// </summary>
        private System.Windows.Forms.GroupBox groupBox1;
        /// <summary>
        /// The BTN exact tender
        /// </summary>
        private System.Windows.Forms.Button btnExactTender;
        /// <summary>
        /// The button0
        /// </summary>
        private System.Windows.Forms.Button button0;
        /// <summary>
        /// The button00
        /// </summary>
        private System.Windows.Forms.Button button00;
        /// <summary>
        /// The button9
        /// </summary>
        private System.Windows.Forms.Button button9;
        /// <summary>
        /// The button8
        /// </summary>
        private System.Windows.Forms.Button button8;
        /// <summary>
        /// The button7
        /// </summary>
        private System.Windows.Forms.Button button7;
        /// <summary>
        /// The button6
        /// </summary>
        private System.Windows.Forms.Button button6;
        /// <summary>
        /// The button5
        /// </summary>
        private System.Windows.Forms.Button button5;
        /// <summary>
        /// The button4
        /// </summary>
        private System.Windows.Forms.Button button4;
        /// <summary>
        /// The button3
        /// </summary>
        private System.Windows.Forms.Button button3;
        /// <summary>
        /// The button2
        /// </summary>
        private System.Windows.Forms.Button button2;
        /// <summary>
        /// The button1
        /// </summary>
        private System.Windows.Forms.Button button1;
        /// <summary>
        /// The label title pay
        /// </summary>
        private System.Windows.Forms.Label lblTitlePay;
        /// <summary>
        /// The label change
        /// </summary>
        private System.Windows.Forms.Label lblChange;
        /// <summary>
        /// The BTN change
        /// </summary>
        private System.Windows.Forms.Button btnChange;
        /// <summary>
        /// The BTN close
        /// </summary>
        private System.Windows.Forms.Button btnClose;
        /// <summary>
        /// The label timer
        /// </summary>
        private System.Windows.Forms.Label lblTimer;
        /// <summary>
        /// The BTN CLS
        /// </summary>
        private System.Windows.Forms.Button btnCLS;
        /// <summary>
        /// The BTN five dollar
        /// </summary>
        private System.Windows.Forms.Button btnFiveDollar;
        /// <summary>
        /// The BTN ten dollar
        /// </summary>
        private System.Windows.Forms.Button btnTenDollar;
        /// <summary>
        /// The BTN twenty dollar
        /// </summary>
        private System.Windows.Forms.Button btnTwentyDollar;
        /// <summary>
        /// The BTN fifty dollar
        /// </summary>
        private System.Windows.Forms.Button btnFiftyDollar;
        /// <summary>
        /// The BTN one hundred
        /// </summary>
        private System.Windows.Forms.Button btnOneHundred;
        /// <summary>
        /// The BTN one dollar
        /// </summary>
        private System.Windows.Forms.Button btnOneDollar;
        /// <summary>
        /// The label1
        /// </summary>
        private System.Windows.Forms.Label label1;
    }
}