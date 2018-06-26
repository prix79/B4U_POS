// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 01-06-2010
// ***********************************************************************
// <copyright file="StartRegister.Designer.cs" company="Beauty4u">
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
    /// Class StartRegister.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class StartRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartRegister));
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTitleCashDrawer = new System.Windows.Forms.Label();
            this.lblCashDrawer = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblStartCash = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPsw = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblCashierID = new System.Windows.Forms.Label();
            this.lbl100Dollar = new System.Windows.Forms.Label();
            this.lbl50Dollar = new System.Windows.Forms.Label();
            this.lbl20Dollar = new System.Windows.Forms.Label();
            this.lbl10Dollar = new System.Windows.Forms.Label();
            this.lblNickel = new System.Windows.Forms.Label();
            this.lblDime = new System.Windows.Forms.Label();
            this.lblQuarter = new System.Windows.Forms.Label();
            this.lbl1Dollar = new System.Windows.Forms.Label();
            this.lbl2Dollar = new System.Windows.Forms.Label();
            this.lbl5Dollar = new System.Windows.Forms.Label();
            this.lblPenny = new System.Windows.Forms.Label();
            this.txt100Dollar = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt50Dollar = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt20Dollar = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt10Dollar = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt5Dollar = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt2Dollar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt1Dollar = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtQuarter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNickel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPenny = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtManagerID = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.MediumBlue;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(500, 308);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 81);
            this.btnCancel.TabIndex = 138;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTitleCashDrawer
            // 
            this.lblTitleCashDrawer.BackColor = System.Drawing.Color.Maroon;
            this.lblTitleCashDrawer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTitleCashDrawer.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleCashDrawer.ForeColor = System.Drawing.Color.White;
            this.lblTitleCashDrawer.Location = new System.Drawing.Point(350, 7);
            this.lblTitleCashDrawer.Name = "lblTitleCashDrawer";
            this.lblTitleCashDrawer.Size = new System.Drawing.Size(290, 40);
            this.lblTitleCashDrawer.TabIndex = 136;
            this.lblTitleCashDrawer.Text = "CASH IN DRAWER";
            this.lblTitleCashDrawer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCashDrawer
            // 
            this.lblCashDrawer.BackColor = System.Drawing.Color.Maroon;
            this.lblCashDrawer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCashDrawer.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCashDrawer.ForeColor = System.Drawing.Color.White;
            this.lblCashDrawer.Location = new System.Drawing.Point(350, 46);
            this.lblCashDrawer.Name = "lblCashDrawer";
            this.lblCashDrawer.Size = new System.Drawing.Size(290, 85);
            this.lblCashDrawer.TabIndex = 135;
            this.lblCashDrawer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCashDrawer.TextChanged += new System.EventHandler(this.lblCashDrawer_TextChanged);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.MediumBlue;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(350, 308);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(140, 81);
            this.btnStart.TabIndex = 137;
            this.btnStart.Text = "START REGISTER";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblStartCash);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Location = new System.Drawing.Point(350, 394);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(290, 81);
            this.groupBox3.TabIndex = 134;
            this.groupBox3.TabStop = false;
            // 
            // lblStartCash
            // 
            this.lblStartCash.BackColor = System.Drawing.Color.White;
            this.lblStartCash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStartCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStartCash.ForeColor = System.Drawing.Color.Navy;
            this.lblStartCash.Location = new System.Drawing.Point(9, 43);
            this.lblStartCash.Name = "lblStartCash";
            this.lblStartCash.Size = new System.Drawing.Size(271, 32);
            this.lblStartCash.TabIndex = 55;
            this.lblStartCash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.DarkBlue;
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(9, 11);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(271, 32);
            this.label19.TabIndex = 55;
            this.label19.Text = "START CASH";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtManagerID);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtPsw);
            this.groupBox2.Location = new System.Drawing.Point(500, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(140, 165);
            this.groupBox2.TabIndex = 133;
            this.groupBox2.TabStop = false;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.PaleGreen;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(6, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(124, 32);
            this.label13.TabIndex = 51;
            this.label13.Text = "MANAGER ID";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.PaleGreen;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(6, 89);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(124, 32);
            this.label14.TabIndex = 55;
            this.label14.Text = "PASSWORD";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPsw
            // 
            this.txtPsw.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPsw.Location = new System.Drawing.Point(6, 121);
            this.txtPsw.Name = "txtPsw";
            this.txtPsw.PasswordChar = '*';
            this.txtPsw.Size = new System.Drawing.Size(124, 32);
            this.txtPsw.TabIndex = 54;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lblCashierID);
            this.groupBox1.Location = new System.Drawing.Point(350, 138);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(140, 165);
            this.groupBox1.TabIndex = 132;
            this.groupBox1.TabStop = false;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.PaleGreen;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(9, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(124, 32);
            this.label15.TabIndex = 53;
            this.label15.Text = "DATE";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.White;
            this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDate.Location = new System.Drawing.Point(9, 48);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(124, 32);
            this.lblDate.TabIndex = 54;
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.PaleGreen;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(9, 89);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(124, 32);
            this.label12.TabIndex = 50;
            this.label12.Text = "CASHIER ID";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCashierID
            // 
            this.lblCashierID.BackColor = System.Drawing.Color.White;
            this.lblCashierID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCashierID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCashierID.Location = new System.Drawing.Point(9, 121);
            this.lblCashierID.Name = "lblCashierID";
            this.lblCashierID.Size = new System.Drawing.Size(124, 32);
            this.lblCashierID.TabIndex = 52;
            this.lblCashierID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl100Dollar
            // 
            this.lbl100Dollar.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lbl100Dollar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl100Dollar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl100Dollar.Location = new System.Drawing.Point(225, 7);
            this.lbl100Dollar.Name = "lbl100Dollar";
            this.lbl100Dollar.Size = new System.Drawing.Size(119, 38);
            this.lbl100Dollar.TabIndex = 131;
            this.lbl100Dollar.Text = "$0.00";
            this.lbl100Dollar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl50Dollar
            // 
            this.lbl50Dollar.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lbl50Dollar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl50Dollar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl50Dollar.Location = new System.Drawing.Point(225, 50);
            this.lbl50Dollar.Name = "lbl50Dollar";
            this.lbl50Dollar.Size = new System.Drawing.Size(119, 38);
            this.lbl50Dollar.TabIndex = 130;
            this.lbl50Dollar.Text = "$0.00";
            this.lbl50Dollar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl20Dollar
            // 
            this.lbl20Dollar.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lbl20Dollar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl20Dollar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl20Dollar.Location = new System.Drawing.Point(225, 93);
            this.lbl20Dollar.Name = "lbl20Dollar";
            this.lbl20Dollar.Size = new System.Drawing.Size(119, 38);
            this.lbl20Dollar.TabIndex = 129;
            this.lbl20Dollar.Text = "$0.00";
            this.lbl20Dollar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl10Dollar
            // 
            this.lbl10Dollar.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lbl10Dollar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl10Dollar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl10Dollar.Location = new System.Drawing.Point(225, 136);
            this.lbl10Dollar.Name = "lbl10Dollar";
            this.lbl10Dollar.Size = new System.Drawing.Size(119, 38);
            this.lbl10Dollar.TabIndex = 128;
            this.lbl10Dollar.Text = "$0.00";
            this.lbl10Dollar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNickel
            // 
            this.lblNickel.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lblNickel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNickel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNickel.Location = new System.Drawing.Point(225, 394);
            this.lblNickel.Name = "lblNickel";
            this.lblNickel.Size = new System.Drawing.Size(119, 38);
            this.lblNickel.TabIndex = 127;
            this.lblNickel.Text = "$0.00";
            this.lblNickel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDime
            // 
            this.lblDime.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lblDime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDime.Location = new System.Drawing.Point(225, 351);
            this.lblDime.Name = "lblDime";
            this.lblDime.Size = new System.Drawing.Size(119, 38);
            this.lblDime.TabIndex = 126;
            this.lblDime.Text = "$0.00";
            this.lblDime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblQuarter
            // 
            this.lblQuarter.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lblQuarter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblQuarter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblQuarter.Location = new System.Drawing.Point(225, 308);
            this.lblQuarter.Name = "lblQuarter";
            this.lblQuarter.Size = new System.Drawing.Size(119, 38);
            this.lblQuarter.TabIndex = 125;
            this.lblQuarter.Text = "$0.00";
            this.lblQuarter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl1Dollar
            // 
            this.lbl1Dollar.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lbl1Dollar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl1Dollar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl1Dollar.Location = new System.Drawing.Point(225, 265);
            this.lbl1Dollar.Name = "lbl1Dollar";
            this.lbl1Dollar.Size = new System.Drawing.Size(119, 38);
            this.lbl1Dollar.TabIndex = 124;
            this.lbl1Dollar.Text = "$0.00";
            this.lbl1Dollar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl2Dollar
            // 
            this.lbl2Dollar.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lbl2Dollar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl2Dollar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl2Dollar.Location = new System.Drawing.Point(225, 222);
            this.lbl2Dollar.Name = "lbl2Dollar";
            this.lbl2Dollar.Size = new System.Drawing.Size(119, 38);
            this.lbl2Dollar.TabIndex = 123;
            this.lbl2Dollar.Text = "$0.00";
            this.lbl2Dollar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl5Dollar
            // 
            this.lbl5Dollar.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lbl5Dollar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl5Dollar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl5Dollar.Location = new System.Drawing.Point(225, 179);
            this.lbl5Dollar.Name = "lbl5Dollar";
            this.lbl5Dollar.Size = new System.Drawing.Size(119, 38);
            this.lbl5Dollar.TabIndex = 122;
            this.lbl5Dollar.Text = "$0.00";
            this.lbl5Dollar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPenny
            // 
            this.lblPenny.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lblPenny.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPenny.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPenny.Location = new System.Drawing.Point(225, 437);
            this.lblPenny.Name = "lblPenny";
            this.lblPenny.Size = new System.Drawing.Size(119, 38);
            this.lblPenny.TabIndex = 121;
            this.lblPenny.Text = "$0.00";
            this.lblPenny.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt100Dollar
            // 
            this.txt100Dollar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt100Dollar.Location = new System.Drawing.Point(158, 7);
            this.txt100Dollar.Name = "txt100Dollar";
            this.txt100Dollar.Size = new System.Drawing.Size(65, 38);
            this.txt100Dollar.TabIndex = 99;
            this.txt100Dollar.Text = "0";
            this.txt100Dollar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt100Dollar.TextChanged += new System.EventHandler(this.txt100Dollar_TextChanged);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(6, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(150, 38);
            this.label11.TabIndex = 120;
            this.label11.Text = "100  DOLLARS";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt50Dollar
            // 
            this.txt50Dollar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt50Dollar.Location = new System.Drawing.Point(158, 50);
            this.txt50Dollar.Name = "txt50Dollar";
            this.txt50Dollar.Size = new System.Drawing.Size(65, 38);
            this.txt50Dollar.TabIndex = 100;
            this.txt50Dollar.Text = "0";
            this.txt50Dollar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt50Dollar.TextChanged += new System.EventHandler(this.txt50Dollar_TextChanged);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(6, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(150, 38);
            this.label10.TabIndex = 119;
            this.label10.Text = "50  DOLLARS";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt20Dollar
            // 
            this.txt20Dollar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt20Dollar.Location = new System.Drawing.Point(158, 93);
            this.txt20Dollar.Name = "txt20Dollar";
            this.txt20Dollar.Size = new System.Drawing.Size(65, 38);
            this.txt20Dollar.TabIndex = 101;
            this.txt20Dollar.Text = "0";
            this.txt20Dollar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt20Dollar.TextChanged += new System.EventHandler(this.txt20Dollar_TextChanged);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(6, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 38);
            this.label9.TabIndex = 118;
            this.label9.Text = "20  DOLLARS";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt10Dollar
            // 
            this.txt10Dollar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt10Dollar.Location = new System.Drawing.Point(158, 136);
            this.txt10Dollar.Name = "txt10Dollar";
            this.txt10Dollar.Size = new System.Drawing.Size(65, 38);
            this.txt10Dollar.TabIndex = 102;
            this.txt10Dollar.Text = "0";
            this.txt10Dollar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt10Dollar.TextChanged += new System.EventHandler(this.txt10Dollar_TextChanged);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(6, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 38);
            this.label7.TabIndex = 117;
            this.label7.Text = "10  DOLLARS";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt5Dollar
            // 
            this.txt5Dollar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt5Dollar.Location = new System.Drawing.Point(158, 179);
            this.txt5Dollar.Name = "txt5Dollar";
            this.txt5Dollar.Size = new System.Drawing.Size(65, 38);
            this.txt5Dollar.TabIndex = 103;
            this.txt5Dollar.Text = "0";
            this.txt5Dollar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt5Dollar.TextChanged += new System.EventHandler(this.txt5Dollar_TextChanged);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(6, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 38);
            this.label6.TabIndex = 116;
            this.label6.Text = "5  DOLLARS";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt2Dollar
            // 
            this.txt2Dollar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt2Dollar.Location = new System.Drawing.Point(158, 222);
            this.txt2Dollar.Name = "txt2Dollar";
            this.txt2Dollar.Size = new System.Drawing.Size(65, 38);
            this.txt2Dollar.TabIndex = 104;
            this.txt2Dollar.Text = "0";
            this.txt2Dollar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt2Dollar.TextChanged += new System.EventHandler(this.txt2Dollar_TextChanged);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(6, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 38);
            this.label5.TabIndex = 115;
            this.label5.Text = "2  DOLLARS";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt1Dollar
            // 
            this.txt1Dollar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt1Dollar.Location = new System.Drawing.Point(158, 265);
            this.txt1Dollar.Name = "txt1Dollar";
            this.txt1Dollar.Size = new System.Drawing.Size(65, 38);
            this.txt1Dollar.TabIndex = 105;
            this.txt1Dollar.Text = "0";
            this.txt1Dollar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt1Dollar.TextChanged += new System.EventHandler(this.txt1Dollar_TextChanged);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(6, 265);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 38);
            this.label8.TabIndex = 114;
            this.label8.Text = "1 DOLLAR";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtQuarter
            // 
            this.txtQuarter.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtQuarter.Location = new System.Drawing.Point(158, 308);
            this.txtQuarter.Name = "txtQuarter";
            this.txtQuarter.Size = new System.Drawing.Size(65, 38);
            this.txtQuarter.TabIndex = 106;
            this.txtQuarter.Text = "0";
            this.txtQuarter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQuarter.TextChanged += new System.EventHandler(this.txtQuarter_TextChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(6, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 38);
            this.label4.TabIndex = 113;
            this.label4.Text = "QUARTER";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDime
            // 
            this.txtDime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtDime.Location = new System.Drawing.Point(158, 351);
            this.txtDime.Name = "txtDime";
            this.txtDime.Size = new System.Drawing.Size(65, 38);
            this.txtDime.TabIndex = 107;
            this.txtDime.Text = "0";
            this.txtDime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDime.TextChanged += new System.EventHandler(this.txtDime_TextChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(6, 351);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 38);
            this.label3.TabIndex = 112;
            this.label3.Text = "DIME";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNickel
            // 
            this.txtNickel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtNickel.Location = new System.Drawing.Point(158, 394);
            this.txtNickel.Name = "txtNickel";
            this.txtNickel.Size = new System.Drawing.Size(65, 38);
            this.txtNickel.TabIndex = 108;
            this.txtNickel.Text = "0";
            this.txtNickel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNickel.TextChanged += new System.EventHandler(this.txtNickel_TextChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 394);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 38);
            this.label2.TabIndex = 111;
            this.label2.Text = "NICKEL";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPenny
            // 
            this.txtPenny.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPenny.Location = new System.Drawing.Point(158, 437);
            this.txtPenny.Name = "txtPenny";
            this.txtPenny.Size = new System.Drawing.Size(65, 38);
            this.txtPenny.TabIndex = 109;
            this.txtPenny.Text = "0";
            this.txtPenny.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPenny.TextChanged += new System.EventHandler(this.txtPenny_TextChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 437);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 38);
            this.label1.TabIndex = 110;
            this.label1.Text = "PENNY";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtManagerID
            // 
            this.txtManagerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtManagerID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtManagerID.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtManagerID.Location = new System.Drawing.Point(6, 47);
            this.txtManagerID.Name = "txtManagerID";
            this.txtManagerID.Size = new System.Drawing.Size(124, 32);
            this.txtManagerID.TabIndex = 56;
            // 
            // StartRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(646, 485);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblTitleCashDrawer);
            this.Controls.Add(this.lblCashDrawer);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl100Dollar);
            this.Controls.Add(this.lbl50Dollar);
            this.Controls.Add(this.lbl20Dollar);
            this.Controls.Add(this.lbl10Dollar);
            this.Controls.Add(this.lblNickel);
            this.Controls.Add(this.lblDime);
            this.Controls.Add(this.lblQuarter);
            this.Controls.Add(this.lbl1Dollar);
            this.Controls.Add(this.lbl2Dollar);
            this.Controls.Add(this.lbl5Dollar);
            this.Controls.Add(this.lblPenny);
            this.Controls.Add(this.txt100Dollar);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt50Dollar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt20Dollar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt10Dollar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt5Dollar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt2Dollar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt1Dollar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtQuarter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNickel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPenny);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "START REGISTER";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.StartRegister_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /// <summary>
        /// The BTN cancel
        /// </summary>
        private System.Windows.Forms.Button btnCancel;
        /// <summary>
        /// The label title cash drawer
        /// </summary>
        private System.Windows.Forms.Label lblTitleCashDrawer;
        /// <summary>
        /// The label cash drawer
        /// </summary>
        private System.Windows.Forms.Label lblCashDrawer;
        /// <summary>
        /// The BTN start
        /// </summary>
        private System.Windows.Forms.Button btnStart;
        /// <summary>
        /// The group box3
        /// </summary>
        private System.Windows.Forms.GroupBox groupBox3;
        /// <summary>
        /// The label start cash
        /// </summary>
        private System.Windows.Forms.Label lblStartCash;
        /// <summary>
        /// The label19
        /// </summary>
        private System.Windows.Forms.Label label19;
        /// <summary>
        /// The group box2
        /// </summary>
        private System.Windows.Forms.GroupBox groupBox2;
        /// <summary>
        /// The label13
        /// </summary>
        private System.Windows.Forms.Label label13;
        /// <summary>
        /// The label14
        /// </summary>
        private System.Windows.Forms.Label label14;
        /// <summary>
        /// The text PSW
        /// </summary>
        private System.Windows.Forms.TextBox txtPsw;
        /// <summary>
        /// The group box1
        /// </summary>
        private System.Windows.Forms.GroupBox groupBox1;
        /// <summary>
        /// The label15
        /// </summary>
        private System.Windows.Forms.Label label15;
        /// <summary>
        /// The label date
        /// </summary>
        private System.Windows.Forms.Label lblDate;
        /// <summary>
        /// The label12
        /// </summary>
        private System.Windows.Forms.Label label12;
        /// <summary>
        /// The label cashier identifier
        /// </summary>
        private System.Windows.Forms.Label lblCashierID;
        /// <summary>
        /// The LBL100 dollar
        /// </summary>
        private System.Windows.Forms.Label lbl100Dollar;
        /// <summary>
        /// The LBL50 dollar
        /// </summary>
        private System.Windows.Forms.Label lbl50Dollar;
        /// <summary>
        /// The LBL20 dollar
        /// </summary>
        private System.Windows.Forms.Label lbl20Dollar;
        /// <summary>
        /// The LBL10 dollar
        /// </summary>
        private System.Windows.Forms.Label lbl10Dollar;
        /// <summary>
        /// The label nickel
        /// </summary>
        private System.Windows.Forms.Label lblNickel;
        /// <summary>
        /// The label dime
        /// </summary>
        private System.Windows.Forms.Label lblDime;
        /// <summary>
        /// The label quarter
        /// </summary>
        private System.Windows.Forms.Label lblQuarter;
        /// <summary>
        /// The LBL1 dollar
        /// </summary>
        private System.Windows.Forms.Label lbl1Dollar;
        /// <summary>
        /// The LBL2 dollar
        /// </summary>
        private System.Windows.Forms.Label lbl2Dollar;
        /// <summary>
        /// The LBL5 dollar
        /// </summary>
        private System.Windows.Forms.Label lbl5Dollar;
        /// <summary>
        /// The label penny
        /// </summary>
        private System.Windows.Forms.Label lblPenny;
        /// <summary>
        /// The TXT100 dollar
        /// </summary>
        private System.Windows.Forms.TextBox txt100Dollar;
        /// <summary>
        /// The label11
        /// </summary>
        private System.Windows.Forms.Label label11;
        /// <summary>
        /// The TXT50 dollar
        /// </summary>
        private System.Windows.Forms.TextBox txt50Dollar;
        /// <summary>
        /// The label10
        /// </summary>
        private System.Windows.Forms.Label label10;
        /// <summary>
        /// The TXT20 dollar
        /// </summary>
        private System.Windows.Forms.TextBox txt20Dollar;
        /// <summary>
        /// The label9
        /// </summary>
        private System.Windows.Forms.Label label9;
        /// <summary>
        /// The TXT10 dollar
        /// </summary>
        private System.Windows.Forms.TextBox txt10Dollar;
        /// <summary>
        /// The label7
        /// </summary>
        private System.Windows.Forms.Label label7;
        /// <summary>
        /// The TXT5 dollar
        /// </summary>
        private System.Windows.Forms.TextBox txt5Dollar;
        /// <summary>
        /// The label6
        /// </summary>
        private System.Windows.Forms.Label label6;
        /// <summary>
        /// The TXT2 dollar
        /// </summary>
        private System.Windows.Forms.TextBox txt2Dollar;
        /// <summary>
        /// The label5
        /// </summary>
        private System.Windows.Forms.Label label5;
        /// <summary>
        /// The TXT1 dollar
        /// </summary>
        private System.Windows.Forms.TextBox txt1Dollar;
        /// <summary>
        /// The label8
        /// </summary>
        private System.Windows.Forms.Label label8;
        /// <summary>
        /// The text quarter
        /// </summary>
        private System.Windows.Forms.TextBox txtQuarter;
        /// <summary>
        /// The label4
        /// </summary>
        private System.Windows.Forms.Label label4;
        /// <summary>
        /// The text dime
        /// </summary>
        private System.Windows.Forms.TextBox txtDime;
        /// <summary>
        /// The label3
        /// </summary>
        private System.Windows.Forms.Label label3;
        /// <summary>
        /// The text nickel
        /// </summary>
        private System.Windows.Forms.TextBox txtNickel;
        /// <summary>
        /// The label2
        /// </summary>
        private System.Windows.Forms.Label label2;
        /// <summary>
        /// The text penny
        /// </summary>
        private System.Windows.Forms.TextBox txtPenny;
        /// <summary>
        /// The label1
        /// </summary>
        private System.Windows.Forms.Label label1;
        /// <summary>
        /// The text manager identifier
        /// </summary>
        private System.Windows.Forms.TextBox txtManagerID;
    }
}