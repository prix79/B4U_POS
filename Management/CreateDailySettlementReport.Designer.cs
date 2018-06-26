namespace Management
{
    partial class CreateDailySettlementReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateDailySettlementReport));
            this.label1 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCashDeposit = new System.Windows.Forms.TextBox();
            this.txtCashDepositDate = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.richTxtNote = new System.Windows.Forms.RichTextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtPOSCardSettlement = new System.Windows.Forms.TextBox();
            this.lblPOSCardPayment = new System.Windows.Forms.Label();
            this.lblCardPaymentDiff = new System.Windows.Forms.Label();
            this.lblPOSCashPayment = new System.Windows.Forms.Label();
            this.lblPOSCashSettlement = new System.Windows.Forms.Label();
            this.lblCashPaymentDiff = new System.Windows.Forms.Label();
            this.lblCashwithdrawal = new System.Windows.Forms.Label();
            this.lblCashInSafe = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.lblNewCashBalanceInSafe = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.monthCalendar2 = new System.Windows.Forms.MonthCalendar();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(51, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "DATE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDate
            // 
            this.txtDate.BackColor = System.Drawing.Color.LightGray;
            this.txtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDate.Location = new System.Drawing.Point(139, 13);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(138, 22);
            this.txtDate.TabIndex = 1;
            this.txtDate.TextChanged += new System.EventHandler(this.txtDate_TextChanged);
            this.txtDate.DoubleClick += new System.EventHandler(this.txtDate_DoubleClick);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(278, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "DAY";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(51, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(225, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "POS CARD PAYMENT";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(51, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(225, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "POS CARD SETTLEMENT";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(51, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(225, 24);
            this.label5.TabIndex = 5;
            this.label5.Text = "CARD PAYMENT DIFFERENCE";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(51, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(225, 24);
            this.label6.TabIndex = 6;
            this.label6.Text = "POS CASH PAYMENT";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(51, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(225, 24);
            this.label7.TabIndex = 7;
            this.label7.Text = "POS CASH SETTLEMENT";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(51, 224);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(225, 24);
            this.label8.TabIndex = 8;
            this.label8.Text = "CASH PAYMENT DIFFERNECE";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(51, 261);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(225, 24);
            this.label9.TabIndex = 9;
            this.label9.Text = "CASH WITHDRAWL";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(440, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(225, 24);
            this.label10.TabIndex = 10;
            this.label10.Text = "CASH DEPOSIT";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(440, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(225, 24);
            this.label11.TabIndex = 11;
            this.label11.Text = "CASH DEPOSIT DATE";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(440, 79);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(225, 24);
            this.label12.TabIndex = 12;
            this.label12.Text = "CASH IN SAFE";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCashDeposit
            // 
            this.txtCashDeposit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCashDeposit.Location = new System.Drawing.Point(667, 13);
            this.txtCashDeposit.Name = "txtCashDeposit";
            this.txtCashDeposit.Size = new System.Drawing.Size(147, 22);
            this.txtCashDeposit.TabIndex = 21;
            this.txtCashDeposit.Text = "0.00";
            this.txtCashDeposit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCashDeposit.TextChanged += new System.EventHandler(this.txtCashDeposit_TextChanged);
            // 
            // txtCashDepositDate
            // 
            this.txtCashDepositDate.BackColor = System.Drawing.Color.LightGray;
            this.txtCashDepositDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCashDepositDate.Location = new System.Drawing.Point(667, 46);
            this.txtCashDepositDate.Name = "txtCashDepositDate";
            this.txtCashDepositDate.ReadOnly = true;
            this.txtCashDepositDate.Size = new System.Drawing.Size(147, 22);
            this.txtCashDepositDate.TabIndex = 22;
            this.txtCashDepositDate.DoubleClick += new System.EventHandler(this.txtCashDepositDate_DoubleClick);
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.Location = new System.Drawing.Point(440, 149);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(165, 98);
            this.label13.TabIndex = 24;
            this.label13.Text = "NOTE";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // richTxtNote
            // 
            this.richTxtNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTxtNote.Location = new System.Drawing.Point(608, 149);
            this.richTxtNote.Name = "richTxtNote";
            this.richTxtNote.Size = new System.Drawing.Size(206, 98);
            this.richTxtNote.TabIndex = 25;
            this.richTxtNote.Text = "";
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOK.Location = new System.Drawing.Point(503, 255);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 38);
            this.btnOK.TabIndex = 26;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(714, 255);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 38);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtPOSCardSettlement
            // 
            this.txtPOSCardSettlement.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPOSCardSettlement.Location = new System.Drawing.Point(278, 81);
            this.txtPOSCardSettlement.Name = "txtPOSCardSettlement";
            this.txtPOSCardSettlement.Size = new System.Drawing.Size(147, 22);
            this.txtPOSCardSettlement.TabIndex = 15;
            this.txtPOSCardSettlement.Text = "0.00";
            this.txtPOSCardSettlement.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPOSCardSettlement.TextChanged += new System.EventHandler(this.txtPOSCardSettlement_TextChanged);
            // 
            // lblPOSCardPayment
            // 
            this.lblPOSCardPayment.BackColor = System.Drawing.Color.White;
            this.lblPOSCardPayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPOSCardPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPOSCardPayment.Location = new System.Drawing.Point(278, 46);
            this.lblPOSCardPayment.Name = "lblPOSCardPayment";
            this.lblPOSCardPayment.Size = new System.Drawing.Size(147, 24);
            this.lblPOSCardPayment.TabIndex = 30;
            this.lblPOSCardPayment.Text = "$0.00";
            this.lblPOSCardPayment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCardPaymentDiff
            // 
            this.lblCardPaymentDiff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCardPaymentDiff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardPaymentDiff.Location = new System.Drawing.Point(278, 113);
            this.lblCardPaymentDiff.Name = "lblCardPaymentDiff";
            this.lblCardPaymentDiff.Size = new System.Drawing.Size(147, 24);
            this.lblCardPaymentDiff.TabIndex = 31;
            this.lblCardPaymentDiff.Text = "$0.00";
            this.lblCardPaymentDiff.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPOSCashPayment
            // 
            this.lblPOSCashPayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPOSCashPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPOSCashPayment.Location = new System.Drawing.Point(278, 149);
            this.lblPOSCashPayment.Name = "lblPOSCashPayment";
            this.lblPOSCashPayment.Size = new System.Drawing.Size(147, 24);
            this.lblPOSCashPayment.TabIndex = 32;
            this.lblPOSCashPayment.Text = "$0.00";
            this.lblPOSCashPayment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPOSCashSettlement
            // 
            this.lblPOSCashSettlement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPOSCashSettlement.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPOSCashSettlement.Location = new System.Drawing.Point(278, 187);
            this.lblPOSCashSettlement.Name = "lblPOSCashSettlement";
            this.lblPOSCashSettlement.Size = new System.Drawing.Size(147, 24);
            this.lblPOSCashSettlement.TabIndex = 33;
            this.lblPOSCashSettlement.Text = "$0.00";
            this.lblPOSCashSettlement.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCashPaymentDiff
            // 
            this.lblCashPaymentDiff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCashPaymentDiff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashPaymentDiff.Location = new System.Drawing.Point(278, 224);
            this.lblCashPaymentDiff.Name = "lblCashPaymentDiff";
            this.lblCashPaymentDiff.Size = new System.Drawing.Size(147, 24);
            this.lblCashPaymentDiff.TabIndex = 34;
            this.lblCashPaymentDiff.Text = "$0.00";
            this.lblCashPaymentDiff.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCashwithdrawal
            // 
            this.lblCashwithdrawal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCashwithdrawal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashwithdrawal.Location = new System.Drawing.Point(278, 261);
            this.lblCashwithdrawal.Name = "lblCashwithdrawal";
            this.lblCashwithdrawal.Size = new System.Drawing.Size(147, 24);
            this.lblCashwithdrawal.TabIndex = 35;
            this.lblCashwithdrawal.Text = "$0.00";
            this.lblCashwithdrawal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCashInSafe
            // 
            this.lblCashInSafe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCashInSafe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashInSafe.Location = new System.Drawing.Point(667, 79);
            this.lblCashInSafe.Name = "lblCashInSafe";
            this.lblCashInSafe.Size = new System.Drawing.Size(147, 24);
            this.lblCashInSafe.TabIndex = 36;
            this.lblCashInSafe.Text = "$0.00";
            this.lblCashInSafe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDay
            // 
            this.lblDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDay.Location = new System.Drawing.Point(332, 13);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(93, 24);
            this.lblDay.TabIndex = 37;
            this.lblDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(97, 35);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 39;
            this.monthCalendar1.Visible = false;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // lblNewCashBalanceInSafe
            // 
            this.lblNewCashBalanceInSafe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNewCashBalanceInSafe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewCashBalanceInSafe.Location = new System.Drawing.Point(667, 112);
            this.lblNewCashBalanceInSafe.Name = "lblNewCashBalanceInSafe";
            this.lblNewCashBalanceInSafe.Size = new System.Drawing.Size(147, 24);
            this.lblNewCashBalanceInSafe.TabIndex = 41;
            this.lblNewCashBalanceInSafe.Text = "$0.00";
            this.lblNewCashBalanceInSafe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.Location = new System.Drawing.Point(440, 112);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(225, 24);
            this.label15.TabIndex = 40;
            this.label15.Text = "NEW CASH BALANCE";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // monthCalendar2
            // 
            this.monthCalendar2.Location = new System.Drawing.Point(617, 69);
            this.monthCalendar2.Name = "monthCalendar2";
            this.monthCalendar2.TabIndex = 42;
            this.monthCalendar2.Visible = false;
            this.monthCalendar2.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar2_DateSelected);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReset.Location = new System.Drawing.Point(608, 255);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 38);
            this.btnReset.TabIndex = 43;
            this.btnReset.Text = "RESET";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // CreateDailySettlementReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 306);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.monthCalendar2);
            this.Controls.Add(this.lblNewCashBalanceInSafe);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.lblDay);
            this.Controls.Add(this.lblCashInSafe);
            this.Controls.Add(this.lblCashwithdrawal);
            this.Controls.Add(this.lblCashPaymentDiff);
            this.Controls.Add(this.lblPOSCashSettlement);
            this.Controls.Add(this.lblPOSCashPayment);
            this.Controls.Add(this.lblCardPaymentDiff);
            this.Controls.Add(this.lblPOSCardPayment);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.richTxtNote);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtCashDepositDate);
            this.Controls.Add(this.txtCashDeposit);
            this.Controls.Add(this.txtPOSCardSettlement);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CreateDailySettlementReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CREATE DAILY SETTLEMENT REPORT";
            this.Load += new System.EventHandler(this.CreateDailySalesReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCashDeposit;
        private System.Windows.Forms.TextBox txtCashDepositDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RichTextBox richTxtNote;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtPOSCardSettlement;
        private System.Windows.Forms.Label lblPOSCardPayment;
        private System.Windows.Forms.Label lblCardPaymentDiff;
        private System.Windows.Forms.Label lblPOSCashPayment;
        private System.Windows.Forms.Label lblPOSCashSettlement;
        private System.Windows.Forms.Label lblCashPaymentDiff;
        private System.Windows.Forms.Label lblCashwithdrawal;
        private System.Windows.Forms.Label lblCashInSafe;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label lblNewCashBalanceInSafe;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.MonthCalendar monthCalendar2;
        private System.Windows.Forms.Button btnReset;
    }
}