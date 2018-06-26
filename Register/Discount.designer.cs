// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 02-01-2016
// ***********************************************************************
// <copyright file="Discount.designer.cs" company="Beauty4u">
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
    /// Class Discount.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class Discount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Discount));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLine5 = new System.Windows.Forms.Button();
            this.btnLine30 = new System.Windows.Forms.Button();
            this.btnLine20 = new System.Windows.Forms.Button();
            this.btnLine10 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTotal5 = new System.Windows.Forms.Button();
            this.btnTotal30 = new System.Windows.Forms.Button();
            this.btnTotal10 = new System.Windows.Forms.Button();
            this.btnTotal20 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMoneyOff = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtMoneyOff = new System.Windows.Forms.TextBox();
            this.lblDiscountPrice = new System.Windows.Forms.Label();
            this.lblBasicPrice = new System.Windows.Forms.Label();
            this.lblTitleDiscountedPrice = new System.Windows.Forms.Label();
            this.lblTitleMoneyOff = new System.Windows.Forms.Label();
            this.lblTitleRegularPrice = new System.Windows.Forms.Label();
            this.btnclose = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnTotalOK = new System.Windows.Forms.Button();
            this.btnLineOK = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtLine = new System.Windows.Forms.TextBox();
            this.radioBtnTotal = new System.Windows.Forms.RadioButton();
            this.radioBtnLine = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btn25OFF = new System.Windows.Forms.Button();
            this.btnSocialMediaDiscount = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PaleGreen;
            this.groupBox1.Controls.Add(this.btnLine5);
            this.groupBox1.Controls.Add(this.btnLine30);
            this.groupBox1.Controls.Add(this.btnLine20);
            this.groupBox1.Controls.Add(this.btnLine10);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(29, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 231);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LINE % DISCOUNT";
            // 
            // btnLine5
            // 
            this.btnLine5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLine5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLine5.ForeColor = System.Drawing.Color.Black;
            this.btnLine5.Location = new System.Drawing.Point(16, 21);
            this.btnLine5.Name = "btnLine5";
            this.btnLine5.Size = new System.Drawing.Size(155, 100);
            this.btnLine5.TabIndex = 3;
            this.btnLine5.Text = "5 %";
            this.btnLine5.UseVisualStyleBackColor = false;
            this.btnLine5.Click += new System.EventHandler(this.btnLine5_Click);
            // 
            // btnLine30
            // 
            this.btnLine30.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLine30.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLine30.ForeColor = System.Drawing.Color.Black;
            this.btnLine30.Location = new System.Drawing.Point(178, 127);
            this.btnLine30.Name = "btnLine30";
            this.btnLine30.Size = new System.Drawing.Size(155, 100);
            this.btnLine30.TabIndex = 2;
            this.btnLine30.Text = "30 %";
            this.btnLine30.UseVisualStyleBackColor = false;
            this.btnLine30.Click += new System.EventHandler(this.btnLine30_Click);
            // 
            // btnLine20
            // 
            this.btnLine20.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLine20.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLine20.ForeColor = System.Drawing.Color.Black;
            this.btnLine20.Location = new System.Drawing.Point(16, 127);
            this.btnLine20.Name = "btnLine20";
            this.btnLine20.Size = new System.Drawing.Size(155, 100);
            this.btnLine20.TabIndex = 1;
            this.btnLine20.Text = "20 %";
            this.btnLine20.UseVisualStyleBackColor = false;
            this.btnLine20.Click += new System.EventHandler(this.btnLine20_Click);
            // 
            // btnLine10
            // 
            this.btnLine10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLine10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLine10.ForeColor = System.Drawing.Color.Black;
            this.btnLine10.Location = new System.Drawing.Point(178, 21);
            this.btnLine10.Name = "btnLine10";
            this.btnLine10.Size = new System.Drawing.Size(155, 100);
            this.btnLine10.TabIndex = 0;
            this.btnLine10.Text = "10 %";
            this.btnLine10.UseVisualStyleBackColor = false;
            this.btnLine10.Click += new System.EventHandler(this.btnLine10_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.PaleGreen;
            this.groupBox2.Controls.Add(this.btnTotal5);
            this.groupBox2.Controls.Add(this.btnTotal30);
            this.groupBox2.Controls.Add(this.btnTotal10);
            this.groupBox2.Controls.Add(this.btnTotal20);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(29, 259);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(347, 231);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "TOTAL % DISCOUNT";
            // 
            // btnTotal5
            // 
            this.btnTotal5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTotal5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTotal5.ForeColor = System.Drawing.Color.Black;
            this.btnTotal5.Location = new System.Drawing.Point(16, 19);
            this.btnTotal5.Name = "btnTotal5";
            this.btnTotal5.Size = new System.Drawing.Size(155, 100);
            this.btnTotal5.TabIndex = 4;
            this.btnTotal5.Text = "5 %";
            this.btnTotal5.UseVisualStyleBackColor = false;
            this.btnTotal5.Click += new System.EventHandler(this.btnTotal5_Click);
            // 
            // btnTotal30
            // 
            this.btnTotal30.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTotal30.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTotal30.ForeColor = System.Drawing.Color.Black;
            this.btnTotal30.Location = new System.Drawing.Point(178, 125);
            this.btnTotal30.Name = "btnTotal30";
            this.btnTotal30.Size = new System.Drawing.Size(155, 100);
            this.btnTotal30.TabIndex = 6;
            this.btnTotal30.Text = "30 %";
            this.btnTotal30.UseVisualStyleBackColor = false;
            this.btnTotal30.Click += new System.EventHandler(this.btnTotal30_Click);
            // 
            // btnTotal10
            // 
            this.btnTotal10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTotal10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTotal10.ForeColor = System.Drawing.Color.Black;
            this.btnTotal10.Location = new System.Drawing.Point(178, 19);
            this.btnTotal10.Name = "btnTotal10";
            this.btnTotal10.Size = new System.Drawing.Size(155, 100);
            this.btnTotal10.TabIndex = 4;
            this.btnTotal10.Text = "10 %";
            this.btnTotal10.UseVisualStyleBackColor = false;
            this.btnTotal10.Click += new System.EventHandler(this.btnTotal10_Click);
            // 
            // btnTotal20
            // 
            this.btnTotal20.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTotal20.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTotal20.ForeColor = System.Drawing.Color.Black;
            this.btnTotal20.Location = new System.Drawing.Point(16, 125);
            this.btnTotal20.Name = "btnTotal20";
            this.btnTotal20.Size = new System.Drawing.Size(155, 100);
            this.btnTotal20.TabIndex = 5;
            this.btnTotal20.Text = "20 %";
            this.btnTotal20.UseVisualStyleBackColor = false;
            this.btnTotal20.Click += new System.EventHandler(this.btnTotal20_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.PaleGreen;
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.lblMoneyOff);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.lblQty);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btnOK);
            this.groupBox3.Controls.Add(this.txtMoneyOff);
            this.groupBox3.Controls.Add(this.lblDiscountPrice);
            this.groupBox3.Controls.Add(this.lblBasicPrice);
            this.groupBox3.Controls.Add(this.lblTitleDiscountedPrice);
            this.groupBox3.Controls.Add(this.lblTitleMoneyOff);
            this.groupBox3.Controls.Add(this.lblTitleRegularPrice);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(405, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(347, 231);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "LINE MONEY OFF";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(273, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "(EA)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "(TOTAL)";
            // 
            // lblMoneyOff
            // 
            this.lblMoneyOff.BackColor = System.Drawing.Color.Ivory;
            this.lblMoneyOff.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMoneyOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMoneyOff.Location = new System.Drawing.Point(246, 67);
            this.lblMoneyOff.Name = "lblMoneyOff";
            this.lblMoneyOff.Size = new System.Drawing.Size(94, 38);
            this.lblMoneyOff.TabIndex = 11;
            this.lblMoneyOff.Text = "0.00";
            this.lblMoneyOff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(230, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 38);
            this.label3.TabIndex = 10;
            this.label3.Text = "=";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblQty
            // 
            this.lblQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblQty.Location = new System.Drawing.Point(190, 67);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(37, 38);
            this.lblQty.TabIndex = 8;
            this.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(173, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 38);
            this.label1.TabIndex = 7;
            this.label1.Text = "÷";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.MediumBlue;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(171, 179);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(169, 45);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtMoneyOff
            // 
            this.txtMoneyOff.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMoneyOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMoneyOff.Location = new System.Drawing.Point(78, 68);
            this.txtMoneyOff.Name = "txtMoneyOff";
            this.txtMoneyOff.Size = new System.Drawing.Size(93, 38);
            this.txtMoneyOff.TabIndex = 5;
            this.txtMoneyOff.Text = "0.00";
            this.txtMoneyOff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMoneyOff.TextChanged += new System.EventHandler(this.txtMoneyOff_TextChanged);
            this.txtMoneyOff.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtMoneyOff_MouseClick);
            // 
            // lblDiscountPrice
            // 
            this.lblDiscountPrice.BackColor = System.Drawing.Color.Maroon;
            this.lblDiscountPrice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDiscountPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDiscountPrice.ForeColor = System.Drawing.Color.White;
            this.lblDiscountPrice.Location = new System.Drawing.Point(171, 129);
            this.lblDiscountPrice.Name = "lblDiscountPrice";
            this.lblDiscountPrice.Size = new System.Drawing.Size(169, 45);
            this.lblDiscountPrice.TabIndex = 4;
            this.lblDiscountPrice.Text = "$0.00";
            this.lblDiscountPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBasicPrice
            // 
            this.lblBasicPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblBasicPrice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBasicPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBasicPrice.ForeColor = System.Drawing.Color.Black;
            this.lblBasicPrice.Location = new System.Drawing.Point(171, 18);
            this.lblBasicPrice.Name = "lblBasicPrice";
            this.lblBasicPrice.Size = new System.Drawing.Size(169, 45);
            this.lblBasicPrice.TabIndex = 3;
            this.lblBasicPrice.Text = "$0.00";
            this.lblBasicPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitleDiscountedPrice
            // 
            this.lblTitleDiscountedPrice.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitleDiscountedPrice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleDiscountedPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleDiscountedPrice.ForeColor = System.Drawing.Color.Black;
            this.lblTitleDiscountedPrice.Location = new System.Drawing.Point(11, 129);
            this.lblTitleDiscountedPrice.Name = "lblTitleDiscountedPrice";
            this.lblTitleDiscountedPrice.Size = new System.Drawing.Size(160, 45);
            this.lblTitleDiscountedPrice.TabIndex = 2;
            this.lblTitleDiscountedPrice.Text = "DISCOUNTED PRICE (EA)";
            this.lblTitleDiscountedPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitleMoneyOff
            // 
            this.lblTitleMoneyOff.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitleMoneyOff.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleMoneyOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleMoneyOff.ForeColor = System.Drawing.Color.Black;
            this.lblTitleMoneyOff.Location = new System.Drawing.Point(11, 68);
            this.lblTitleMoneyOff.Name = "lblTitleMoneyOff";
            this.lblTitleMoneyOff.Size = new System.Drawing.Size(66, 37);
            this.lblTitleMoneyOff.TabIndex = 1;
            this.lblTitleMoneyOff.Text = "MONEY OFF";
            this.lblTitleMoneyOff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitleRegularPrice
            // 
            this.lblTitleRegularPrice.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitleRegularPrice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleRegularPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleRegularPrice.ForeColor = System.Drawing.Color.Black;
            this.lblTitleRegularPrice.Location = new System.Drawing.Point(11, 18);
            this.lblTitleRegularPrice.Name = "lblTitleRegularPrice";
            this.lblTitleRegularPrice.Size = new System.Drawing.Size(160, 45);
            this.lblTitleRegularPrice.TabIndex = 0;
            this.lblTitleRegularPrice.Text = "REGULAR PRICE (EA) ";
            this.lblTitleRegularPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.Red;
            this.btnclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnclose.Location = new System.Drawing.Point(405, 496);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(347, 60);
            this.btnclose.TabIndex = 8;
            this.btnclose.Text = "CLOSE";
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.PaleGreen;
            this.groupBox4.Controls.Add(this.btnTotalOK);
            this.groupBox4.Controls.Add(this.btnLineOK);
            this.groupBox4.Controls.Add(this.txtTotal);
            this.groupBox4.Controls.Add(this.txtLine);
            this.groupBox4.Controls.Add(this.radioBtnTotal);
            this.groupBox4.Controls.Add(this.radioBtnLine);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox4.ForeColor = System.Drawing.Color.Black;
            this.groupBox4.Location = new System.Drawing.Point(405, 259);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(347, 119);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "MANUAL DISCOUNT OPTIONS";
            // 
            // btnTotalOK
            // 
            this.btnTotalOK.BackColor = System.Drawing.Color.MediumBlue;
            this.btnTotalOK.ForeColor = System.Drawing.Color.White;
            this.btnTotalOK.Location = new System.Drawing.Point(244, 70);
            this.btnTotalOK.Name = "btnTotalOK";
            this.btnTotalOK.Size = new System.Drawing.Size(93, 39);
            this.btnTotalOK.TabIndex = 5;
            this.btnTotalOK.Text = "OK";
            this.btnTotalOK.UseVisualStyleBackColor = false;
            this.btnTotalOK.Click += new System.EventHandler(this.btnTotalOK_Click);
            // 
            // btnLineOK
            // 
            this.btnLineOK.BackColor = System.Drawing.Color.MediumBlue;
            this.btnLineOK.ForeColor = System.Drawing.Color.White;
            this.btnLineOK.Location = new System.Drawing.Point(244, 20);
            this.btnLineOK.Name = "btnLineOK";
            this.btnLineOK.Size = new System.Drawing.Size(93, 38);
            this.btnLineOK.TabIndex = 4;
            this.btnLineOK.Text = "OK";
            this.btnLineOK.UseVisualStyleBackColor = false;
            this.btnLineOK.Click += new System.EventHandler(this.btnLineOK_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtTotal.Location = new System.Drawing.Point(145, 71);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(97, 38);
            this.txtTotal.TabIndex = 3;
            this.txtTotal.Click += new System.EventHandler(this.txtTotal_Click);
            // 
            // txtLine
            // 
            this.txtLine.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLine.Location = new System.Drawing.Point(145, 20);
            this.txtLine.Name = "txtLine";
            this.txtLine.Size = new System.Drawing.Size(97, 38);
            this.txtLine.TabIndex = 2;
            this.txtLine.Click += new System.EventHandler(this.txtLine_Click);
            // 
            // radioBtnTotal
            // 
            this.radioBtnTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.radioBtnTotal.Location = new System.Drawing.Point(14, 73);
            this.radioBtnTotal.Name = "radioBtnTotal";
            this.radioBtnTotal.Size = new System.Drawing.Size(127, 29);
            this.radioBtnTotal.TabIndex = 1;
            this.radioBtnTotal.Text = "TOTAL %";
            this.radioBtnTotal.UseVisualStyleBackColor = true;
            this.radioBtnTotal.CheckedChanged += new System.EventHandler(this.radioBtnTotal_CheckedChanged);
            // 
            // radioBtnLine
            // 
            this.radioBtnLine.Checked = true;
            this.radioBtnLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.radioBtnLine.Location = new System.Drawing.Point(14, 23);
            this.radioBtnLine.Name = "radioBtnLine";
            this.radioBtnLine.Size = new System.Drawing.Size(102, 29);
            this.radioBtnLine.TabIndex = 0;
            this.radioBtnLine.TabStop = true;
            this.radioBtnLine.Text = "LINE %";
            this.radioBtnLine.UseVisualStyleBackColor = true;
            this.radioBtnLine.CheckedChanged += new System.EventHandler(this.radioBtnLine_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.PaleGreen;
            this.groupBox5.Controls.Add(this.btn25OFF);
            this.groupBox5.Controls.Add(this.btnSocialMediaDiscount);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox5.ForeColor = System.Drawing.Color.Black;
            this.groupBox5.Location = new System.Drawing.Point(405, 384);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(347, 106);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "OTHER DISCOUNT OPTIONS";
            this.groupBox5.Visible = false;
            // 
            // btn25OFF
            // 
            this.btn25OFF.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn25OFF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn25OFF.ForeColor = System.Drawing.Color.Black;
            this.btn25OFF.Location = new System.Drawing.Point(182, 25);
            this.btn25OFF.Name = "btn25OFF";
            this.btn25OFF.Size = new System.Drawing.Size(155, 75);
            this.btn25OFF.TabIndex = 5;
            this.btn25OFF.Text = "25% OFF FOR $50 OR MORE";
            this.btn25OFF.UseVisualStyleBackColor = false;
            this.btn25OFF.Click += new System.EventHandler(this.btn25OFF_Click);
            // 
            // btnSocialMediaDiscount
            // 
            this.btnSocialMediaDiscount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSocialMediaDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSocialMediaDiscount.ForeColor = System.Drawing.Color.Black;
            this.btnSocialMediaDiscount.Location = new System.Drawing.Point(16, 25);
            this.btnSocialMediaDiscount.Name = "btnSocialMediaDiscount";
            this.btnSocialMediaDiscount.Size = new System.Drawing.Size(155, 75);
            this.btnSocialMediaDiscount.TabIndex = 4;
            this.btnSocialMediaDiscount.Text = "SOCIAL MEDIA DISCOUNT";
            this.btnSocialMediaDiscount.UseVisualStyleBackColor = false;
            this.btnSocialMediaDiscount.Click += new System.EventHandler(this.btnSocialMediaDiscount_Click);
            // 
            // Discount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(780, 560);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Discount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REGULAR DISCOUNT OPTIONS";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Discount_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The group box1
        /// </summary>
        private System.Windows.Forms.GroupBox groupBox1;
        /// <summary>
        /// The BTN line30
        /// </summary>
        private System.Windows.Forms.Button btnLine30;
        /// <summary>
        /// The BTN line20
        /// </summary>
        private System.Windows.Forms.Button btnLine20;
        /// <summary>
        /// The BTN line10
        /// </summary>
        private System.Windows.Forms.Button btnLine10;
        /// <summary>
        /// The group box2
        /// </summary>
        private System.Windows.Forms.GroupBox groupBox2;
        /// <summary>
        /// The BTN total30
        /// </summary>
        private System.Windows.Forms.Button btnTotal30;
        /// <summary>
        /// The BTN total10
        /// </summary>
        private System.Windows.Forms.Button btnTotal10;
        /// <summary>
        /// The BTN total20
        /// </summary>
        private System.Windows.Forms.Button btnTotal20;
        /// <summary>
        /// The group box3
        /// </summary>
        private System.Windows.Forms.GroupBox groupBox3;
        /// <summary>
        /// The label title regular price
        /// </summary>
        private System.Windows.Forms.Label lblTitleRegularPrice;
        /// <summary>
        /// The label discount price
        /// </summary>
        private System.Windows.Forms.Label lblDiscountPrice;
        /// <summary>
        /// The label basic price
        /// </summary>
        private System.Windows.Forms.Label lblBasicPrice;
        /// <summary>
        /// The label title discounted price
        /// </summary>
        private System.Windows.Forms.Label lblTitleDiscountedPrice;
        /// <summary>
        /// The label title money off
        /// </summary>
        private System.Windows.Forms.Label lblTitleMoneyOff;
        /// <summary>
        /// The text money off
        /// </summary>
        private System.Windows.Forms.TextBox txtMoneyOff;
        /// <summary>
        /// The BTN ok
        /// </summary>
        private System.Windows.Forms.Button btnOK;
        /// <summary>
        /// The btnclose
        /// </summary>
        private System.Windows.Forms.Button btnclose;
        /// <summary>
        /// The group box4
        /// </summary>
        private System.Windows.Forms.GroupBox groupBox4;
        /// <summary>
        /// The BTN total ok
        /// </summary>
        private System.Windows.Forms.Button btnTotalOK;
        /// <summary>
        /// The BTN line ok
        /// </summary>
        private System.Windows.Forms.Button btnLineOK;
        /// <summary>
        /// The text total
        /// </summary>
        private System.Windows.Forms.TextBox txtTotal;
        /// <summary>
        /// The text line
        /// </summary>
        private System.Windows.Forms.TextBox txtLine;
        /// <summary>
        /// The radio BTN total
        /// </summary>
        private System.Windows.Forms.RadioButton radioBtnTotal;
        /// <summary>
        /// The radio BTN line
        /// </summary>
        private System.Windows.Forms.RadioButton radioBtnLine;
        /// <summary>
        /// The BTN line5
        /// </summary>
        private System.Windows.Forms.Button btnLine5;
        /// <summary>
        /// The BTN total5
        /// </summary>
        private System.Windows.Forms.Button btnTotal5;
        /// <summary>
        /// The label1
        /// </summary>
        private System.Windows.Forms.Label label1;
        /// <summary>
        /// The label3
        /// </summary>
        private System.Windows.Forms.Label label3;
        /// <summary>
        /// The label qty
        /// </summary>
        private System.Windows.Forms.Label lblQty;
        /// <summary>
        /// The label money off
        /// </summary>
        private System.Windows.Forms.Label lblMoneyOff;
        /// <summary>
        /// The label4
        /// </summary>
        private System.Windows.Forms.Label label4;
        /// <summary>
        /// The label2
        /// </summary>
        private System.Windows.Forms.Label label2;
        /// <summary>
        /// The group box5
        /// </summary>
        private System.Windows.Forms.GroupBox groupBox5;
        /// <summary>
        /// The BTN social media discount
        /// </summary>
        private System.Windows.Forms.Button btnSocialMediaDiscount;
        /// <summary>
        /// The BTN25 off
        /// </summary>
        private System.Windows.Forms.Button btn25OFF;
    }
}