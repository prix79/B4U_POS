// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 02-07-2017
//
// Last Modified By : Seungkeun
// Last Modified On : 12-19-2017
// ***********************************************************************
// <copyright file="CloverPayment.Designer.cs" company="Beauty4u">
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
    /// Class CloverPayment.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class CloverPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CloverPayment));
            this.lblPay = new System.Windows.Forms.Label();
            this.lblTitlePay = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.lblTitleGrandTotal = new System.Windows.Forms.Label();
            this.ConnectStatusLabel = new System.Windows.Forms.Label();
            this.ManualEntryCheckbox = new System.Windows.Forms.CheckBox();
            this.MagStripeCheckbox = new System.Windows.Forms.CheckBox();
            this.ChipCheckbox = new System.Windows.Forms.CheckBox();
            this.ContactlessCheckbox = new System.Windows.Forms.CheckBox();
            this.gBoxResponse = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExternalPaymentID = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtOrderID = new System.Windows.Forms.Label();
            this.txtVerification = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtAID = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMID = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMethod = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCardSaleType = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCardType = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtCardTransactionType = new System.Windows.Forms.Label();
            this.lblCard = new System.Windows.Forms.Label();
            this.txtReferenceID = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtLast4Digit = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtCardHolderName = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtAuthCode = new System.Windows.Forms.Label();
            this.txtPaymentID = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gBoxCardEntryMethods = new System.Windows.Forms.GroupBox();
            this.btnResetDevice = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrintTest = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.DeviceCurrentStatus = new System.Windows.Forms.Label();
            this.UIStateButtonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAppShutDown = new System.Windows.Forms.Button();
            this.btnVoid = new System.Windows.Forms.Button();
            this.lblNotEnoughFund = new System.Windows.Forms.Label();
            this.gBoxResponse.SuspendLayout();
            this.gBoxCardEntryMethods.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPay
            // 
            this.lblPay.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblPay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPay.ForeColor = System.Drawing.Color.Black;
            this.lblPay.Location = new System.Drawing.Point(12, 188);
            this.lblPay.Name = "lblPay";
            this.lblPay.Size = new System.Drawing.Size(313, 57);
            this.lblPay.TabIndex = 206;
            this.lblPay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitlePay
            // 
            this.lblTitlePay.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitlePay.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitlePay.ForeColor = System.Drawing.Color.Black;
            this.lblTitlePay.Location = new System.Drawing.Point(12, 130);
            this.lblTitlePay.Name = "lblTitlePay";
            this.lblTitlePay.Size = new System.Drawing.Size(313, 57);
            this.lblTitlePay.TabIndex = 205;
            this.lblTitlePay.Text = "PAY AMOUNT";
            this.lblTitlePay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(175, 419);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 67);
            this.btnCancel.TabIndex = 204;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.TextChanged += new System.EventHandler(this.btnCancel_TextChanged);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCheckOut.ForeColor = System.Drawing.Color.Black;
            this.btnCheckOut.Location = new System.Drawing.Point(12, 419);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(150, 67);
            this.btnCheckOut.TabIndex = 203;
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
            this.lblGrandTotal.Location = new System.Drawing.Point(12, 66);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(313, 57);
            this.lblGrandTotal.TabIndex = 202;
            this.lblGrandTotal.Text = "$0.00";
            this.lblGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitleGrandTotal
            // 
            this.lblTitleGrandTotal.BackColor = System.Drawing.Color.Maroon;
            this.lblTitleGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleGrandTotal.ForeColor = System.Drawing.Color.White;
            this.lblTitleGrandTotal.Location = new System.Drawing.Point(12, 9);
            this.lblTitleGrandTotal.Name = "lblTitleGrandTotal";
            this.lblTitleGrandTotal.Size = new System.Drawing.Size(313, 57);
            this.lblTitleGrandTotal.TabIndex = 201;
            this.lblTitleGrandTotal.Text = "GRAND TOTAL";
            this.lblTitleGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConnectStatusLabel
            // 
            this.ConnectStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ConnectStatusLabel.Location = new System.Drawing.Point(592, 502);
            this.ConnectStatusLabel.Name = "ConnectStatusLabel";
            this.ConnectStatusLabel.Size = new System.Drawing.Size(120, 23);
            this.ConnectStatusLabel.TabIndex = 208;
            this.ConnectStatusLabel.Text = "Not Connected";
            this.ConnectStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ManualEntryCheckbox
            // 
            this.ManualEntryCheckbox.AutoSize = true;
            this.ManualEntryCheckbox.Location = new System.Drawing.Point(35, 20);
            this.ManualEntryCheckbox.Name = "ManualEntryCheckbox";
            this.ManualEntryCheckbox.Size = new System.Drawing.Size(61, 17);
            this.ManualEntryCheckbox.TabIndex = 209;
            this.ManualEntryCheckbox.Text = "Manual";
            this.ManualEntryCheckbox.UseVisualStyleBackColor = true;
            // 
            // MagStripeCheckbox
            // 
            this.MagStripeCheckbox.AutoSize = true;
            this.MagStripeCheckbox.Checked = true;
            this.MagStripeCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MagStripeCheckbox.Location = new System.Drawing.Point(98, 20);
            this.MagStripeCheckbox.Name = "MagStripeCheckbox";
            this.MagStripeCheckbox.Size = new System.Drawing.Size(77, 17);
            this.MagStripeCheckbox.TabIndex = 210;
            this.MagStripeCheckbox.Text = "Mag Stripe";
            this.MagStripeCheckbox.UseVisualStyleBackColor = true;
            // 
            // ChipCheckbox
            // 
            this.ChipCheckbox.AutoSize = true;
            this.ChipCheckbox.Checked = true;
            this.ChipCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChipCheckbox.Location = new System.Drawing.Point(177, 20);
            this.ChipCheckbox.Name = "ChipCheckbox";
            this.ChipCheckbox.Size = new System.Drawing.Size(47, 17);
            this.ChipCheckbox.TabIndex = 211;
            this.ChipCheckbox.Text = "Chip";
            this.ChipCheckbox.UseVisualStyleBackColor = true;
            // 
            // ContactlessCheckbox
            // 
            this.ContactlessCheckbox.AutoSize = true;
            this.ContactlessCheckbox.Checked = true;
            this.ContactlessCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ContactlessCheckbox.Location = new System.Drawing.Point(225, 20);
            this.ContactlessCheckbox.Name = "ContactlessCheckbox";
            this.ContactlessCheckbox.Size = new System.Drawing.Size(81, 17);
            this.ContactlessCheckbox.TabIndex = 212;
            this.ContactlessCheckbox.Tag = "";
            this.ContactlessCheckbox.Text = "Contactless";
            this.ContactlessCheckbox.UseVisualStyleBackColor = true;
            // 
            // gBoxResponse
            // 
            this.gBoxResponse.Controls.Add(this.label3);
            this.gBoxResponse.Controls.Add(this.txtExternalPaymentID);
            this.gBoxResponse.Controls.Add(this.label24);
            this.gBoxResponse.Controls.Add(this.txtOrderID);
            this.gBoxResponse.Controls.Add(this.txtVerification);
            this.gBoxResponse.Controls.Add(this.label14);
            this.gBoxResponse.Controls.Add(this.txtAID);
            this.gBoxResponse.Controls.Add(this.label13);
            this.gBoxResponse.Controls.Add(this.txtMID);
            this.gBoxResponse.Controls.Add(this.label12);
            this.gBoxResponse.Controls.Add(this.txtMethod);
            this.gBoxResponse.Controls.Add(this.label9);
            this.gBoxResponse.Controls.Add(this.txtCardSaleType);
            this.gBoxResponse.Controls.Add(this.label7);
            this.gBoxResponse.Controls.Add(this.txtCardType);
            this.gBoxResponse.Controls.Add(this.label25);
            this.gBoxResponse.Controls.Add(this.txtCardTransactionType);
            this.gBoxResponse.Controls.Add(this.lblCard);
            this.gBoxResponse.Controls.Add(this.txtReferenceID);
            this.gBoxResponse.Controls.Add(this.label21);
            this.gBoxResponse.Controls.Add(this.txtLast4Digit);
            this.gBoxResponse.Controls.Add(this.label23);
            this.gBoxResponse.Controls.Add(this.txtCardHolderName);
            this.gBoxResponse.Controls.Add(this.label19);
            this.gBoxResponse.Controls.Add(this.txtAuthCode);
            this.gBoxResponse.Controls.Add(this.txtPaymentID);
            this.gBoxResponse.Controls.Add(this.txtAmount);
            this.gBoxResponse.Controls.Add(this.label11);
            this.gBoxResponse.Controls.Add(this.label6);
            this.gBoxResponse.Controls.Add(this.label5);
            this.gBoxResponse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxResponse.Location = new System.Drawing.Point(367, 114);
            this.gBoxResponse.Name = "gBoxResponse";
            this.gBoxResponse.Size = new System.Drawing.Size(345, 339);
            this.gBoxResponse.TabIndex = 214;
            this.gBoxResponse.TabStop = false;
            this.gBoxResponse.Text = "Response";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 20);
            this.label3.TabIndex = 51;
            this.label3.Text = "ExternalPaymentID";
            // 
            // txtExternalPaymentID
            // 
            this.txtExternalPaymentID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtExternalPaymentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExternalPaymentID.Location = new System.Drawing.Point(155, 84);
            this.txtExternalPaymentID.Name = "txtExternalPaymentID";
            this.txtExternalPaymentID.Size = new System.Drawing.Size(165, 20);
            this.txtExternalPaymentID.TabIndex = 52;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(23, 65);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(109, 20);
            this.label24.TabIndex = 49;
            this.label24.Text = "OrderID";
            // 
            // txtOrderID
            // 
            this.txtOrderID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtOrderID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderID.Location = new System.Drawing.Point(155, 64);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.Size = new System.Drawing.Size(165, 20);
            this.txtOrderID.TabIndex = 50;
            // 
            // txtVerification
            // 
            this.txtVerification.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtVerification.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVerification.Location = new System.Drawing.Point(155, 305);
            this.txtVerification.Name = "txtVerification";
            this.txtVerification.Size = new System.Drawing.Size(165, 20);
            this.txtVerification.TabIndex = 48;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(23, 305);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 20);
            this.label14.TabIndex = 47;
            this.label14.Text = "Verification";
            // 
            // txtAID
            // 
            this.txtAID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtAID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAID.Location = new System.Drawing.Point(155, 285);
            this.txtAID.Name = "txtAID";
            this.txtAID.Size = new System.Drawing.Size(165, 20);
            this.txtAID.TabIndex = 46;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(23, 285);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(109, 20);
            this.label13.TabIndex = 45;
            this.label13.Text = "AID";
            // 
            // txtMID
            // 
            this.txtMID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtMID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMID.Location = new System.Drawing.Point(155, 265);
            this.txtMID.Name = "txtMID";
            this.txtMID.Size = new System.Drawing.Size(165, 20);
            this.txtMID.TabIndex = 44;
            this.txtMID.Visible = false;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(23, 265);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(109, 20);
            this.label12.TabIndex = 43;
            this.label12.Text = "MID";
            this.label12.Visible = false;
            // 
            // txtMethod
            // 
            this.txtMethod.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMethod.Location = new System.Drawing.Point(155, 185);
            this.txtMethod.Name = "txtMethod";
            this.txtMethod.Size = new System.Drawing.Size(165, 20);
            this.txtMethod.TabIndex = 42;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(23, 185);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 20);
            this.label9.TabIndex = 41;
            this.label9.Text = "Method";
            // 
            // txtCardSaleType
            // 
            this.txtCardSaleType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCardSaleType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardSaleType.Location = new System.Drawing.Point(155, 125);
            this.txtCardSaleType.Name = "txtCardSaleType";
            this.txtCardSaleType.Size = new System.Drawing.Size(165, 20);
            this.txtCardSaleType.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(23, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 20);
            this.label7.TabIndex = 39;
            this.label7.Text = "CardSaleType";
            // 
            // txtCardType
            // 
            this.txtCardType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCardType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardType.Location = new System.Drawing.Point(155, 145);
            this.txtCardType.Name = "txtCardType";
            this.txtCardType.Size = new System.Drawing.Size(165, 20);
            this.txtCardType.TabIndex = 38;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(23, 145);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(109, 20);
            this.label25.TabIndex = 37;
            this.label25.Text = "CardType";
            // 
            // txtCardTransactionType
            // 
            this.txtCardTransactionType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCardTransactionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardTransactionType.Location = new System.Drawing.Point(155, 24);
            this.txtCardTransactionType.Name = "txtCardTransactionType";
            this.txtCardTransactionType.Size = new System.Drawing.Size(165, 20);
            this.txtCardTransactionType.TabIndex = 36;
            // 
            // lblCard
            // 
            this.lblCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCard.Location = new System.Drawing.Point(23, 24);
            this.lblCard.Name = "lblCard";
            this.lblCard.Size = new System.Drawing.Size(123, 20);
            this.lblCard.TabIndex = 35;
            this.lblCard.Text = "CardTransactionType";
            // 
            // txtReferenceID
            // 
            this.txtReferenceID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtReferenceID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReferenceID.Location = new System.Drawing.Point(155, 225);
            this.txtReferenceID.Name = "txtReferenceID";
            this.txtReferenceID.Size = new System.Drawing.Size(165, 20);
            this.txtReferenceID.TabIndex = 34;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(23, 225);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(109, 20);
            this.label21.TabIndex = 33;
            this.label21.Text = "ReferenceID";
            // 
            // txtLast4Digit
            // 
            this.txtLast4Digit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtLast4Digit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLast4Digit.Location = new System.Drawing.Point(155, 165);
            this.txtLast4Digit.Name = "txtLast4Digit";
            this.txtLast4Digit.Size = new System.Drawing.Size(165, 20);
            this.txtLast4Digit.TabIndex = 32;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(23, 165);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(109, 20);
            this.label23.TabIndex = 31;
            this.label23.Text = "Last4Digit";
            // 
            // txtCardHolderName
            // 
            this.txtCardHolderName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCardHolderName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardHolderName.Location = new System.Drawing.Point(155, 205);
            this.txtCardHolderName.Name = "txtCardHolderName";
            this.txtCardHolderName.Size = new System.Drawing.Size(165, 20);
            this.txtCardHolderName.TabIndex = 30;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(23, 205);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(109, 20);
            this.label19.TabIndex = 29;
            this.label19.Text = "CardHolderName";
            // 
            // txtAuthCode
            // 
            this.txtAuthCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtAuthCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuthCode.Location = new System.Drawing.Point(155, 245);
            this.txtAuthCode.Name = "txtAuthCode";
            this.txtAuthCode.Size = new System.Drawing.Size(165, 20);
            this.txtAuthCode.TabIndex = 28;
            // 
            // txtPaymentID
            // 
            this.txtPaymentID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtPaymentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentID.Location = new System.Drawing.Point(155, 44);
            this.txtPaymentID.Name = "txtPaymentID";
            this.txtPaymentID.Size = new System.Drawing.Size(165, 20);
            this.txtPaymentID.TabIndex = 23;
            // 
            // txtAmount
            // 
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(155, 105);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(165, 20);
            this.txtAmount.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(23, 245);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 20);
            this.label11.TabIndex = 21;
            this.label11.Text = "AuthCode";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "PaymentID";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Amount";
            // 
            // gBoxCardEntryMethods
            // 
            this.gBoxCardEntryMethods.Controls.Add(this.ManualEntryCheckbox);
            this.gBoxCardEntryMethods.Controls.Add(this.ContactlessCheckbox);
            this.gBoxCardEntryMethods.Controls.Add(this.ChipCheckbox);
            this.gBoxCardEntryMethods.Controls.Add(this.MagStripeCheckbox);
            this.gBoxCardEntryMethods.Enabled = false;
            this.gBoxCardEntryMethods.Location = new System.Drawing.Point(367, 13);
            this.gBoxCardEntryMethods.Name = "gBoxCardEntryMethods";
            this.gBoxCardEntryMethods.Size = new System.Drawing.Size(345, 53);
            this.gBoxCardEntryMethods.TabIndex = 215;
            this.gBoxCardEntryMethods.TabStop = false;
            this.gBoxCardEntryMethods.Text = "Card Entry Methods (Sale): ";
            // 
            // btnResetDevice
            // 
            this.btnResetDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnResetDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnResetDevice.ForeColor = System.Drawing.Color.Black;
            this.btnResetDevice.Location = new System.Drawing.Point(524, 457);
            this.btnResetDevice.Name = "btnResetDevice";
            this.btnResetDevice.Size = new System.Drawing.Size(91, 44);
            this.btnResetDevice.TabIndex = 217;
            this.btnResetDevice.Text = "RESET DEVICE";
            this.btnResetDevice.UseVisualStyleBackColor = false;
            this.btnResetDevice.Visible = false;
            this.btnResetDevice.Click += new System.EventHandler(this.btnResetDevice_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(450, 502);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 23);
            this.label1.TabIndex = 218;
            this.label1.Text = "DEVICE STATUS: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPrintTest
            // 
            this.btnPrintTest.Location = new System.Drawing.Point(443, 457);
            this.btnPrintTest.Name = "btnPrintTest";
            this.btnPrintTest.Size = new System.Drawing.Size(75, 44);
            this.btnPrintTest.TabIndex = 219;
            this.btnPrintTest.Text = "PRINT TEST";
            this.btnPrintTest.UseVisualStyleBackColor = true;
            this.btnPrintTest.Click += new System.EventHandler(this.btnPrintTest_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(516, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 21);
            this.button1.TabIndex = 220;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(366, 68);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(147, 20);
            this.textBox1.TabIndex = 221;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(366, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(346, 21);
            this.label2.TabIndex = 222;
            this.label2.Text = "...";
            // 
            // lblTimer
            // 
            this.lblTimer.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTimer.ForeColor = System.Drawing.Color.Black;
            this.lblTimer.Location = new System.Drawing.Point(15, 490);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(313, 35);
            this.lblTimer.TabIndex = 223;
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DeviceCurrentStatus
            // 
            this.DeviceCurrentStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DeviceCurrentStatus.AutoSize = true;
            this.DeviceCurrentStatus.BackColor = System.Drawing.Color.Black;
            this.DeviceCurrentStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DeviceCurrentStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.DeviceCurrentStatus.ForeColor = System.Drawing.Color.White;
            this.DeviceCurrentStatus.Location = new System.Drawing.Point(12, 254);
            this.DeviceCurrentStatus.Name = "DeviceCurrentStatus";
            this.DeviceCurrentStatus.Size = new System.Drawing.Size(26, 22);
            this.DeviceCurrentStatus.TabIndex = 207;
            this.DeviceCurrentStatus.Text = "...";
            this.DeviceCurrentStatus.TextChanged += new System.EventHandler(this.DeviceCurrentStatus_TextChanged);
            // 
            // UIStateButtonPanel
            // 
            this.UIStateButtonPanel.AutoSize = true;
            this.UIStateButtonPanel.Location = new System.Drawing.Point(9, 21);
            this.UIStateButtonPanel.MinimumSize = new System.Drawing.Size(10, 0);
            this.UIStateButtonPanel.Name = "UIStateButtonPanel";
            this.UIStateButtonPanel.Size = new System.Drawing.Size(10, 0);
            this.UIStateButtonPanel.TabIndex = 224;
            this.UIStateButtonPanel.WrapContents = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.UIStateButtonPanel);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(12, 298);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 62);
            this.groupBox1.TabIndex = 216;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Clover Response Controls";
            // 
            // btnAppShutDown
            // 
            this.btnAppShutDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAppShutDown.Enabled = false;
            this.btnAppShutDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAppShutDown.ForeColor = System.Drawing.Color.Black;
            this.btnAppShutDown.Location = new System.Drawing.Point(621, 457);
            this.btnAppShutDown.Name = "btnAppShutDown";
            this.btnAppShutDown.Size = new System.Drawing.Size(91, 44);
            this.btnAppShutDown.TabIndex = 224;
            this.btnAppShutDown.Text = "APP SHUT DOWN";
            this.btnAppShutDown.UseVisualStyleBackColor = false;
            this.btnAppShutDown.Click += new System.EventHandler(this.btnAppShutDown_Click);
            // 
            // btnVoid
            // 
            this.btnVoid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnVoid.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnVoid.ForeColor = System.Drawing.Color.Black;
            this.btnVoid.Location = new System.Drawing.Point(12, 420);
            this.btnVoid.Name = "btnVoid";
            this.btnVoid.Size = new System.Drawing.Size(150, 67);
            this.btnVoid.TabIndex = 225;
            this.btnVoid.Text = "VOID";
            this.btnVoid.UseVisualStyleBackColor = false;
            this.btnVoid.Visible = false;
            this.btnVoid.VisibleChanged += new System.EventHandler(this.btnVoid_VisibleChanged);
            this.btnVoid.Click += new System.EventHandler(this.btnVoid_Click);
            // 
            // lblNotEnoughFund
            // 
            this.lblNotEnoughFund.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNotEnoughFund.AutoSize = true;
            this.lblNotEnoughFund.BackColor = System.Drawing.Color.Black;
            this.lblNotEnoughFund.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNotEnoughFund.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblNotEnoughFund.ForeColor = System.Drawing.Color.White;
            this.lblNotEnoughFund.Location = new System.Drawing.Point(12, 254);
            this.lblNotEnoughFund.Name = "lblNotEnoughFund";
            this.lblNotEnoughFund.Size = new System.Drawing.Size(26, 22);
            this.lblNotEnoughFund.TabIndex = 226;
            this.lblNotEnoughFund.Text = "...";
            this.lblNotEnoughFund.Visible = false;
            // 
            // CloverPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(729, 537);
            this.ControlBox = false;
            this.Controls.Add(this.lblNotEnoughFund);
            this.Controls.Add(this.btnVoid);
            this.Controls.Add(this.btnAppShutDown);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPrintTest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnResetDevice);
            this.Controls.Add(this.gBoxCardEntryMethods);
            this.Controls.Add(this.gBoxResponse);
            this.Controls.Add(this.ConnectStatusLabel);
            this.Controls.Add(this.DeviceCurrentStatus);
            this.Controls.Add(this.lblPay);
            this.Controls.Add(this.lblTitlePay);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.lblGrandTotal);
            this.Controls.Add(this.lblTitleGrandTotal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CloverPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PAY BY CREDIT / DEBIT";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CloverPayment_FormClosed);
            this.Load += new System.EventHandler(this.CloverPayment_Load);
            this.gBoxResponse.ResumeLayout(false);
            this.gBoxCardEntryMethods.ResumeLayout(false);
            this.gBoxCardEntryMethods.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /// <summary>
        /// The label pay
        /// </summary>
        private System.Windows.Forms.Label lblPay;
        /// <summary>
        /// The label title pay
        /// </summary>
        private System.Windows.Forms.Label lblTitlePay;
        /// <summary>
        /// The BTN cancel
        /// </summary>
        public System.Windows.Forms.Button btnCancel;
        /// <summary>
        /// The label grand total
        /// </summary>
        private System.Windows.Forms.Label lblGrandTotal;
        /// <summary>
        /// The label title grand total
        /// </summary>
        private System.Windows.Forms.Label lblTitleGrandTotal;
        /// <summary>
        /// The connect status label
        /// </summary>
        public System.Windows.Forms.Label ConnectStatusLabel;
        /// <summary>
        /// The manual entry checkbox
        /// </summary>
        public System.Windows.Forms.CheckBox ManualEntryCheckbox;
        /// <summary>
        /// The mag stripe checkbox
        /// </summary>
        public System.Windows.Forms.CheckBox MagStripeCheckbox;
        /// <summary>
        /// The chip checkbox
        /// </summary>
        public System.Windows.Forms.CheckBox ChipCheckbox;
        /// <summary>
        /// The contactless checkbox
        /// </summary>
        public System.Windows.Forms.CheckBox ContactlessCheckbox;
        /// <summary>
        /// The g box response
        /// </summary>
        public System.Windows.Forms.GroupBox gBoxResponse;
        /// <summary>
        /// The label24
        /// </summary>
        public System.Windows.Forms.Label label24;
        /// <summary>
        /// The text order identifier
        /// </summary>
        public System.Windows.Forms.Label txtOrderID;
        /// <summary>
        /// The text verification
        /// </summary>
        public System.Windows.Forms.Label txtVerification;
        /// <summary>
        /// The label14
        /// </summary>
        public System.Windows.Forms.Label label14;
        /// <summary>
        /// The text aid
        /// </summary>
        public System.Windows.Forms.Label txtAID;
        /// <summary>
        /// The label13
        /// </summary>
        public System.Windows.Forms.Label label13;
        /// <summary>
        /// The text mid
        /// </summary>
        public System.Windows.Forms.Label txtMID;
        /// <summary>
        /// The label12
        /// </summary>
        public System.Windows.Forms.Label label12;
        /// <summary>
        /// The text method
        /// </summary>
        public System.Windows.Forms.Label txtMethod;
        /// <summary>
        /// The label9
        /// </summary>
        public System.Windows.Forms.Label label9;
        /// <summary>
        /// The text card sale type
        /// </summary>
        public System.Windows.Forms.Label txtCardSaleType;
        /// <summary>
        /// The label7
        /// </summary>
        public System.Windows.Forms.Label label7;
        /// <summary>
        /// The text card type
        /// </summary>
        public System.Windows.Forms.Label txtCardType;
        /// <summary>
        /// The label25
        /// </summary>
        public System.Windows.Forms.Label label25;
        /// <summary>
        /// The text card transaction type
        /// </summary>
        public System.Windows.Forms.Label txtCardTransactionType;
        /// <summary>
        /// The label card
        /// </summary>
        public System.Windows.Forms.Label lblCard;
        /// <summary>
        /// The text reference identifier
        /// </summary>
        public System.Windows.Forms.Label txtReferenceID;
        /// <summary>
        /// The label21
        /// </summary>
        public System.Windows.Forms.Label label21;
        /// <summary>
        /// The text last4 digit
        /// </summary>
        public System.Windows.Forms.Label txtLast4Digit;
        /// <summary>
        /// The label23
        /// </summary>
        public System.Windows.Forms.Label label23;
        /// <summary>
        /// The text card holder name
        /// </summary>
        public System.Windows.Forms.Label txtCardHolderName;
        /// <summary>
        /// The label19
        /// </summary>
        public System.Windows.Forms.Label label19;
        /// <summary>
        /// The text authentication code
        /// </summary>
        public System.Windows.Forms.Label txtAuthCode;
        /// <summary>
        /// The text payment identifier
        /// </summary>
        public System.Windows.Forms.Label txtPaymentID;
        /// <summary>
        /// The text amount
        /// </summary>
        public System.Windows.Forms.Label txtAmount;
        /// <summary>
        /// The label11
        /// </summary>
        public System.Windows.Forms.Label label11;
        /// <summary>
        /// The label6
        /// </summary>
        public System.Windows.Forms.Label label6;
        /// <summary>
        /// The label5
        /// </summary>
        public System.Windows.Forms.Label label5;
        /// <summary>
        /// The g box card entry methods
        /// </summary>
        public System.Windows.Forms.GroupBox gBoxCardEntryMethods;
        /// <summary>
        /// The BTN reset device
        /// </summary>
        public System.Windows.Forms.Button btnResetDevice;
        /// <summary>
        /// The label1
        /// </summary>
        public System.Windows.Forms.Label label1;
        /// <summary>
        /// The BTN print test
        /// </summary>
        public System.Windows.Forms.Button btnPrintTest;
        /// <summary>
        /// The button1
        /// </summary>
        public System.Windows.Forms.Button button1;
        /// <summary>
        /// The text box1
        /// </summary>
        public System.Windows.Forms.TextBox textBox1;
        /// <summary>
        /// The label2
        /// </summary>
        public System.Windows.Forms.Label label2;
        /// <summary>
        /// The label3
        /// </summary>
        public System.Windows.Forms.Label label3;
        /// <summary>
        /// The text external payment identifier
        /// </summary>
        public System.Windows.Forms.Label txtExternalPaymentID;
        /// <summary>
        /// The BTN check out
        /// </summary>
        public System.Windows.Forms.Button btnCheckOut;
        /// <summary>
        /// The label timer
        /// </summary>
        private System.Windows.Forms.Label lblTimer;
        /// <summary>
        /// The device current status
        /// </summary>
        public System.Windows.Forms.Label DeviceCurrentStatus;
        /// <summary>
        /// The UI state button panel
        /// </summary>
        public System.Windows.Forms.FlowLayoutPanel UIStateButtonPanel;
        /// <summary>
        /// The group box1
        /// </summary>
        public System.Windows.Forms.GroupBox groupBox1;
        /// <summary>
        /// The BTN application shut down
        /// </summary>
        public System.Windows.Forms.Button btnAppShutDown;
        /// <summary>
        /// The BTN void
        /// </summary>
        public System.Windows.Forms.Button btnVoid;
        /// <summary>
        /// The label not enough fund
        /// </summary>
        public System.Windows.Forms.Label lblNotEnoughFund;
    }
}