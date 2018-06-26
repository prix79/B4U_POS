// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 04-05-2017
// ***********************************************************************
// <copyright file="MultiplePayment.Designer.cs" company="Beauty4u">
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
    /// Class MultiplePayment.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class MultiplePayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiplePayment));
            this.btnCredit = new System.Windows.Forms.Button();
            this.btnTerminal = new System.Windows.Forms.Button();
            this.btnCash = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCLS = new System.Windows.Forms.Button();
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
            this.richtxtPay = new System.Windows.Forms.RichTextBox();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.lblTitleGrandTotal = new System.Windows.Forms.Label();
            this.lblRemainingAmount = new System.Windows.Forms.Label();
            this.lblTitleRA = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnStoreCredit = new System.Windows.Forms.Button();
            this.lblTimer = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblGiftCard2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblGiftCard1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblStoreCredit2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTerminalCredit2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTerminalCredit1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTerminalDebit2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCredit2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblStoreCredit1 = new System.Windows.Forms.Label();
            this.lblTerminalDebit1 = new System.Windows.Forms.Label();
            this.lblCredit1 = new System.Windows.Forms.Label();
            this.lblCash = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCredit
            // 
            this.btnCredit.BackColor = System.Drawing.Color.MediumBlue;
            this.btnCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCredit.ForeColor = System.Drawing.Color.White;
            this.btnCredit.Location = new System.Drawing.Point(741, 85);
            this.btnCredit.Name = "btnCredit";
            this.btnCredit.Size = new System.Drawing.Size(180, 70);
            this.btnCredit.TabIndex = 6;
            this.btnCredit.Text = "CREDIT / DEBIT (CLOVER)";
            this.btnCredit.UseVisualStyleBackColor = false;
            this.btnCredit.Click += new System.EventHandler(this.btnCredit_Click);
            // 
            // btnTerminal
            // 
            this.btnTerminal.BackColor = System.Drawing.Color.MediumBlue;
            this.btnTerminal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTerminal.ForeColor = System.Drawing.Color.White;
            this.btnTerminal.Location = new System.Drawing.Point(741, 159);
            this.btnTerminal.Name = "btnTerminal";
            this.btnTerminal.Size = new System.Drawing.Size(180, 70);
            this.btnTerminal.TabIndex = 5;
            this.btnTerminal.Text = "CREDIT / DEBIT (TERMINAL)";
            this.btnTerminal.UseVisualStyleBackColor = false;
            this.btnTerminal.Click += new System.EventHandler(this.btnTerminal_Click);
            // 
            // btnCash
            // 
            this.btnCash.BackColor = System.Drawing.Color.MediumBlue;
            this.btnCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCash.ForeColor = System.Drawing.Color.White;
            this.btnCash.Location = new System.Drawing.Point(741, 9);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(180, 70);
            this.btnCash.TabIndex = 4;
            this.btnCash.Text = "CASH";
            this.btnCash.UseVisualStyleBackColor = false;
            this.btnCash.Click += new System.EventHandler(this.btnCash_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PaleGreen;
            this.groupBox1.Controls.Add(this.btnCLS);
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
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(394, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 433);
            this.groupBox1.TabIndex = 128;
            this.groupBox1.TabStop = false;
            // 
            // btnCLS
            // 
            this.btnCLS.BackColor = System.Drawing.Color.White;
            this.btnCLS.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCLS.ForeColor = System.Drawing.Color.Red;
            this.btnCLS.Location = new System.Drawing.Point(229, 327);
            this.btnCLS.Name = "btnCLS";
            this.btnCLS.Size = new System.Drawing.Size(108, 100);
            this.btnCLS.TabIndex = 13;
            this.btnCLS.Text = "CLEAR";
            this.btnCLS.UseVisualStyleBackColor = false;
            this.btnCLS.Click += new System.EventHandler(this.btnCLS_Click);
            // 
            // button0
            // 
            this.button0.BackColor = System.Drawing.Color.White;
            this.button0.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button0.ForeColor = System.Drawing.Color.Black;
            this.button0.Location = new System.Drawing.Point(117, 327);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(108, 100);
            this.button0.TabIndex = 11;
            this.button0.Text = "0";
            this.button0.UseVisualStyleBackColor = false;
            this.button0.Click += new System.EventHandler(this.button0_Click);
            // 
            // button00
            // 
            this.button00.BackColor = System.Drawing.Color.White;
            this.button00.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button00.ForeColor = System.Drawing.Color.Black;
            this.button00.Location = new System.Drawing.Point(5, 327);
            this.button00.Name = "button00";
            this.button00.Size = new System.Drawing.Size(108, 100);
            this.button00.TabIndex = 10;
            this.button00.Text = "00";
            this.button00.UseVisualStyleBackColor = false;
            this.button00.Click += new System.EventHandler(this.button00_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.White;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button9.ForeColor = System.Drawing.Color.Black;
            this.button9.Location = new System.Drawing.Point(229, 18);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(108, 100);
            this.button9.TabIndex = 9;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.White;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button6.ForeColor = System.Drawing.Color.Black;
            this.button6.Location = new System.Drawing.Point(229, 122);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(108, 100);
            this.button6.TabIndex = 6;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(117, 121);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(108, 100);
            this.button5.TabIndex = 5;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.White;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button8.ForeColor = System.Drawing.Color.Black;
            this.button8.Location = new System.Drawing.Point(117, 18);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(108, 100);
            this.button8.TabIndex = 8;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.White;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button7.ForeColor = System.Drawing.Color.Black;
            this.button7.Location = new System.Drawing.Point(5, 18);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(108, 100);
            this.button7.TabIndex = 7;
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(5, 121);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(108, 100);
            this.button4.TabIndex = 4;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(229, 224);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 100);
            this.button3.TabIndex = 3;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(117, 224);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 100);
            this.button2.TabIndex = 2;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(5, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 100);
            this.button1.TabIndex = 1;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblTitlePay
            // 
            this.lblTitlePay.BackColor = System.Drawing.Color.White;
            this.lblTitlePay.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitlePay.ForeColor = System.Drawing.Color.Black;
            this.lblTitlePay.Location = new System.Drawing.Point(394, 11);
            this.lblTitlePay.Name = "lblTitlePay";
            this.lblTitlePay.Size = new System.Drawing.Size(341, 57);
            this.lblTitlePay.TabIndex = 130;
            this.lblTitlePay.Text = "PAY AMOUNT";
            this.lblTitlePay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // richtxtPay
            // 
            this.richtxtPay.BackColor = System.Drawing.Color.White;
            this.richtxtPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.richtxtPay.ForeColor = System.Drawing.Color.Black;
            this.richtxtPay.Location = new System.Drawing.Point(394, 68);
            this.richtxtPay.Multiline = false;
            this.richtxtPay.Name = "richtxtPay";
            this.richtxtPay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.richtxtPay.Size = new System.Drawing.Size(341, 57);
            this.richtxtPay.TabIndex = 129;
            this.richtxtPay.Text = "0.00";
            this.richtxtPay.Click += new System.EventHandler(this.richtxtPay_Click);
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.BackColor = System.Drawing.Color.Maroon;
            this.lblGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGrandTotal.ForeColor = System.Drawing.Color.White;
            this.lblGrandTotal.Location = new System.Drawing.Point(5, 68);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(384, 59);
            this.lblGrandTotal.TabIndex = 132;
            this.lblGrandTotal.Text = "$0.00";
            this.lblGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitleGrandTotal
            // 
            this.lblTitleGrandTotal.BackColor = System.Drawing.Color.Maroon;
            this.lblTitleGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleGrandTotal.ForeColor = System.Drawing.Color.White;
            this.lblTitleGrandTotal.Location = new System.Drawing.Point(5, 11);
            this.lblTitleGrandTotal.Name = "lblTitleGrandTotal";
            this.lblTitleGrandTotal.Size = new System.Drawing.Size(384, 57);
            this.lblTitleGrandTotal.TabIndex = 131;
            this.lblTitleGrandTotal.Text = "GRAND TOTAL";
            this.lblTitleGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRemainingAmount
            // 
            this.lblRemainingAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblRemainingAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRemainingAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRemainingAmount.ForeColor = System.Drawing.Color.Black;
            this.lblRemainingAmount.Location = new System.Drawing.Point(163, 457);
            this.lblRemainingAmount.Name = "lblRemainingAmount";
            this.lblRemainingAmount.Size = new System.Drawing.Size(226, 109);
            this.lblRemainingAmount.TabIndex = 134;
            this.lblRemainingAmount.Text = "$0.00";
            this.lblRemainingAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitleRA
            // 
            this.lblTitleRA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblTitleRA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleRA.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleRA.ForeColor = System.Drawing.Color.Black;
            this.lblTitleRA.Location = new System.Drawing.Point(4, 457);
            this.lblTitleRA.Name = "lblTitleRA";
            this.lblTitleRA.Size = new System.Drawing.Size(158, 109);
            this.lblTitleRA.TabIndex = 133;
            this.lblTitleRA.Text = "REMAINING AMOUNT";
            this.lblTitleRA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Navy;
            this.btnOK.Enabled = false;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(741, 420);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(180, 70);
            this.btnOK.TabIndex = 135;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.EnabledChanged += new System.EventHandler(this.btnOK_EnabledChanged);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Navy;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(741, 496);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(180, 70);
            this.btnCancel.TabIndex = 144;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnStoreCredit
            // 
            this.btnStoreCredit.BackColor = System.Drawing.Color.MediumBlue;
            this.btnStoreCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStoreCredit.ForeColor = System.Drawing.Color.White;
            this.btnStoreCredit.Location = new System.Drawing.Point(741, 235);
            this.btnStoreCredit.Name = "btnStoreCredit";
            this.btnStoreCredit.Size = new System.Drawing.Size(180, 70);
            this.btnStoreCredit.TabIndex = 145;
            this.btnStoreCredit.Text = "STORE CREDIT";
            this.btnStoreCredit.UseVisualStyleBackColor = false;
            this.btnStoreCredit.Click += new System.EventHandler(this.btnStoreCredit_Click);
            // 
            // lblTimer
            // 
            this.lblTimer.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTimer.ForeColor = System.Drawing.Color.Black;
            this.lblTimer.Location = new System.Drawing.Point(741, 496);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(180, 70);
            this.lblTimer.TabIndex = 146;
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTimer.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(741, 420);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(180, 70);
            this.btnClose.TabIndex = 147;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 45;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Location = new System.Drawing.Point(5, 130);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(384, 324);
            this.dataGridView1.TabIndex = 163;
            // 
            // lblGiftCard2
            // 
            this.lblGiftCard2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblGiftCard2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGiftCard2.ForeColor = System.Drawing.Color.Red;
            this.lblGiftCard2.Location = new System.Drawing.Point(204, 331);
            this.lblGiftCard2.Name = "lblGiftCard2";
            this.lblGiftCard2.Size = new System.Drawing.Size(192, 30);
            this.lblGiftCard2.TabIndex = 185;
            this.lblGiftCard2.Text = "$0.00";
            this.lblGiftCard2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblGiftCard2.Visible = false;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(12, 331);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(192, 30);
            this.label11.TabIndex = 184;
            this.label11.Text = "GIFT CARD 2";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.Visible = false;
            // 
            // lblGiftCard1
            // 
            this.lblGiftCard1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblGiftCard1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGiftCard1.ForeColor = System.Drawing.Color.Red;
            this.lblGiftCard1.Location = new System.Drawing.Point(204, 301);
            this.lblGiftCard1.Name = "lblGiftCard1";
            this.lblGiftCard1.Size = new System.Drawing.Size(192, 30);
            this.lblGiftCard1.TabIndex = 183;
            this.lblGiftCard1.Text = "$0.00";
            this.lblGiftCard1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblGiftCard1.Visible = false;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(12, 301);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(192, 30);
            this.label12.TabIndex = 182;
            this.label12.Text = "GIFT CARD 1";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label12.Visible = false;
            // 
            // lblStoreCredit2
            // 
            this.lblStoreCredit2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblStoreCredit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStoreCredit2.ForeColor = System.Drawing.Color.Red;
            this.lblStoreCredit2.Location = new System.Drawing.Point(204, 391);
            this.lblStoreCredit2.Name = "lblStoreCredit2";
            this.lblStoreCredit2.Size = new System.Drawing.Size(192, 30);
            this.lblStoreCredit2.TabIndex = 181;
            this.lblStoreCredit2.Text = "$0.00";
            this.lblStoreCredit2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblStoreCredit2.Visible = false;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(12, 391);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(192, 30);
            this.label9.TabIndex = 180;
            this.label9.Text = "STORE CREDIT 2";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Visible = false;
            // 
            // lblTerminalCredit2
            // 
            this.lblTerminalCredit2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTerminalCredit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTerminalCredit2.Location = new System.Drawing.Point(204, 271);
            this.lblTerminalCredit2.Name = "lblTerminalCredit2";
            this.lblTerminalCredit2.Size = new System.Drawing.Size(192, 30);
            this.lblTerminalCredit2.TabIndex = 179;
            this.lblTerminalCredit2.Text = "$0.00";
            this.lblTerminalCredit2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTerminalCredit2.Visible = false;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(12, 271);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(192, 30);
            this.label10.TabIndex = 178;
            this.label10.Text = "TERMINAL CREDIT 2";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Visible = false;
            // 
            // lblTerminalCredit1
            // 
            this.lblTerminalCredit1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTerminalCredit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTerminalCredit1.Location = new System.Drawing.Point(204, 241);
            this.lblTerminalCredit1.Name = "lblTerminalCredit1";
            this.lblTerminalCredit1.Size = new System.Drawing.Size(192, 30);
            this.lblTerminalCredit1.TabIndex = 177;
            this.lblTerminalCredit1.Text = "$0.00";
            this.lblTerminalCredit1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTerminalCredit1.Visible = false;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(12, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(192, 30);
            this.label7.TabIndex = 176;
            this.label7.Text = "TERMINAL CREDIT 1";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Visible = false;
            // 
            // lblTerminalDebit2
            // 
            this.lblTerminalDebit2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTerminalDebit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTerminalDebit2.Location = new System.Drawing.Point(204, 271);
            this.lblTerminalDebit2.Name = "lblTerminalDebit2";
            this.lblTerminalDebit2.Size = new System.Drawing.Size(192, 30);
            this.lblTerminalDebit2.TabIndex = 175;
            this.lblTerminalDebit2.Text = "$0.00";
            this.lblTerminalDebit2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTerminalDebit2.Visible = false;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(12, 271);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(192, 30);
            this.label8.TabIndex = 174;
            this.label8.Text = "TERMINAL DEBIT 2";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Visible = false;
            // 
            // lblCredit2
            // 
            this.lblCredit2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblCredit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCredit2.Location = new System.Drawing.Point(204, 211);
            this.lblCredit2.Name = "lblCredit2";
            this.lblCredit2.Size = new System.Drawing.Size(192, 30);
            this.lblCredit2.TabIndex = 173;
            this.lblCredit2.Text = "$0.00";
            this.lblCredit2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCredit2.Visible = false;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(12, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(192, 30);
            this.label6.TabIndex = 172;
            this.label6.Text = "CREDIT 2";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Visible = false;
            // 
            // lblStoreCredit1
            // 
            this.lblStoreCredit1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblStoreCredit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStoreCredit1.ForeColor = System.Drawing.Color.Red;
            this.lblStoreCredit1.Location = new System.Drawing.Point(204, 361);
            this.lblStoreCredit1.Name = "lblStoreCredit1";
            this.lblStoreCredit1.Size = new System.Drawing.Size(192, 30);
            this.lblStoreCredit1.TabIndex = 171;
            this.lblStoreCredit1.Text = "$0.00";
            this.lblStoreCredit1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblStoreCredit1.Visible = false;
            // 
            // lblTerminalDebit1
            // 
            this.lblTerminalDebit1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTerminalDebit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTerminalDebit1.Location = new System.Drawing.Point(204, 241);
            this.lblTerminalDebit1.Name = "lblTerminalDebit1";
            this.lblTerminalDebit1.Size = new System.Drawing.Size(192, 30);
            this.lblTerminalDebit1.TabIndex = 170;
            this.lblTerminalDebit1.Text = "$0.00";
            this.lblTerminalDebit1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTerminalDebit1.Visible = false;
            // 
            // lblCredit1
            // 
            this.lblCredit1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblCredit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCredit1.Location = new System.Drawing.Point(204, 181);
            this.lblCredit1.Name = "lblCredit1";
            this.lblCredit1.Size = new System.Drawing.Size(192, 30);
            this.lblCredit1.TabIndex = 169;
            this.lblCredit1.Text = "$0.00";
            this.lblCredit1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCredit1.Visible = false;
            // 
            // lblCash
            // 
            this.lblCash.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCash.Location = new System.Drawing.Point(204, 151);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(192, 30);
            this.lblCash.TabIndex = 168;
            this.lblCash.Text = "$0.00";
            this.lblCash.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCash.Visible = false;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(12, 361);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 30);
            this.label5.TabIndex = 167;
            this.label5.Text = "STORE CREDIT 1";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 30);
            this.label4.TabIndex = 166;
            this.label4.Text = "TERMINAL DEBIT 1";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 30);
            this.label3.TabIndex = 165;
            this.label3.Text = "CREDIT 1";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Visible = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 30);
            this.label1.TabIndex = 164;
            this.label1.Text = "CASH";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Visible = false;
            // 
            // MultiplePayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(929, 575);
            this.ControlBox = false;
            this.Controls.Add(this.lblGiftCard2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblGiftCard1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblStoreCredit2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblTerminalCredit2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblTerminalCredit1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblTerminalDebit2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblCredit2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblStoreCredit1);
            this.Controls.Add(this.lblTerminalDebit1);
            this.Controls.Add(this.lblCredit1);
            this.Controls.Add(this.lblCash);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.btnStoreCredit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblRemainingAmount);
            this.Controls.Add(this.lblTitleRA);
            this.Controls.Add(this.lblGrandTotal);
            this.Controls.Add(this.lblTitleGrandTotal);
            this.Controls.Add(this.lblTitlePay);
            this.Controls.Add(this.richtxtPay);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCredit);
            this.Controls.Add(this.btnTerminal);
            this.Controls.Add(this.btnCash);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MultiplePayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PAY BY MULTIPLE PAYMENT";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MultiplePayment_FormClosed);
            this.Load += new System.EventHandler(this.MultiplePayment_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The BTN credit
        /// </summary>
        private System.Windows.Forms.Button btnCredit;
        /// <summary>
        /// The BTN terminal
        /// </summary>
        private System.Windows.Forms.Button btnTerminal;
        /// <summary>
        /// The BTN cash
        /// </summary>
        private System.Windows.Forms.Button btnCash;
        /// <summary>
        /// The group box1
        /// </summary>
        private System.Windows.Forms.GroupBox groupBox1;
        /// <summary>
        /// The BTN CLS
        /// </summary>
        private System.Windows.Forms.Button btnCLS;
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
        /// The button6
        /// </summary>
        private System.Windows.Forms.Button button6;
        /// <summary>
        /// The button5
        /// </summary>
        private System.Windows.Forms.Button button5;
        /// <summary>
        /// The button8
        /// </summary>
        private System.Windows.Forms.Button button8;
        /// <summary>
        /// The button7
        /// </summary>
        private System.Windows.Forms.Button button7;
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
        /// The richtxt pay
        /// </summary>
        public System.Windows.Forms.RichTextBox richtxtPay;
        /// <summary>
        /// The label grand total
        /// </summary>
        private System.Windows.Forms.Label lblGrandTotal;
        /// <summary>
        /// The label title grand total
        /// </summary>
        private System.Windows.Forms.Label lblTitleGrandTotal;
        /// <summary>
        /// The label remaining amount
        /// </summary>
        public System.Windows.Forms.Label lblRemainingAmount;
        /// <summary>
        /// The label title ra
        /// </summary>
        public System.Windows.Forms.Label lblTitleRA;
        /// <summary>
        /// The BTN ok
        /// </summary>
        private System.Windows.Forms.Button btnOK;
        /// <summary>
        /// The BTN cancel
        /// </summary>
        private System.Windows.Forms.Button btnCancel;
        /// <summary>
        /// The BTN store credit
        /// </summary>
        private System.Windows.Forms.Button btnStoreCredit;
        /// <summary>
        /// The label timer
        /// </summary>
        private System.Windows.Forms.Label lblTimer;
        /// <summary>
        /// The BTN close
        /// </summary>
        private System.Windows.Forms.Button btnClose;
        /// <summary>
        /// The data grid view1
        /// </summary>
        public System.Windows.Forms.DataGridView dataGridView1;
        /// <summary>
        /// The label gift card2
        /// </summary>
        public System.Windows.Forms.Label lblGiftCard2;
        /// <summary>
        /// The label11
        /// </summary>
        private System.Windows.Forms.Label label11;
        /// <summary>
        /// The label gift card1
        /// </summary>
        public System.Windows.Forms.Label lblGiftCard1;
        /// <summary>
        /// The label12
        /// </summary>
        private System.Windows.Forms.Label label12;
        /// <summary>
        /// The label store credit2
        /// </summary>
        public System.Windows.Forms.Label lblStoreCredit2;
        /// <summary>
        /// The label9
        /// </summary>
        private System.Windows.Forms.Label label9;
        /// <summary>
        /// The label terminal credit2
        /// </summary>
        public System.Windows.Forms.Label lblTerminalCredit2;
        /// <summary>
        /// The label10
        /// </summary>
        private System.Windows.Forms.Label label10;
        /// <summary>
        /// The label terminal credit1
        /// </summary>
        public System.Windows.Forms.Label lblTerminalCredit1;
        /// <summary>
        /// The label7
        /// </summary>
        private System.Windows.Forms.Label label7;
        /// <summary>
        /// The label terminal debit2
        /// </summary>
        public System.Windows.Forms.Label lblTerminalDebit2;
        /// <summary>
        /// The label8
        /// </summary>
        private System.Windows.Forms.Label label8;
        /// <summary>
        /// The label credit2
        /// </summary>
        public System.Windows.Forms.Label lblCredit2;
        /// <summary>
        /// The label6
        /// </summary>
        private System.Windows.Forms.Label label6;
        /// <summary>
        /// The label store credit1
        /// </summary>
        public System.Windows.Forms.Label lblStoreCredit1;
        /// <summary>
        /// The label terminal debit1
        /// </summary>
        public System.Windows.Forms.Label lblTerminalDebit1;
        /// <summary>
        /// The label credit1
        /// </summary>
        public System.Windows.Forms.Label lblCredit1;
        /// <summary>
        /// The label cash
        /// </summary>
        public System.Windows.Forms.Label lblCash;
        /// <summary>
        /// The label5
        /// </summary>
        private System.Windows.Forms.Label label5;
        /// <summary>
        /// The label4
        /// </summary>
        private System.Windows.Forms.Label label4;
        /// <summary>
        /// The label3
        /// </summary>
        private System.Windows.Forms.Label label3;
        /// <summary>
        /// The label1
        /// </summary>
        private System.Windows.Forms.Label label1;
    }
}