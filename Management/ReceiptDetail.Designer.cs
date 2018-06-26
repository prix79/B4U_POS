namespace Management
{
    partial class ReceiptDetail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiptDetail));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTotalSold = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotalDiscount = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPayMethod = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblStoreCode = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblReceiptID = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblRegNum = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblCashierID = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblMemberCode = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblMemberName = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lblReceiptType = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.lblReceiptStatus = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.lblPay = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.Location = new System.Drawing.Point(7, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(765, 335);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(521, 622);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(251, 60);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTotalSold
            // 
            this.lblTotalSold.BackColor = System.Drawing.SystemColors.Control;
            this.lblTotalSold.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalSold.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTotalSold.Location = new System.Drawing.Point(350, 482);
            this.lblTotalSold.Name = "lblTotalSold";
            this.lblTotalSold.Size = new System.Drawing.Size(165, 45);
            this.lblTotalSold.TabIndex = 135;
            this.lblTotalSold.Text = "0";
            this.lblTotalSold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(264, 482);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 45);
            this.label5.TabIndex = 134;
            this.label5.Text = "TOTAL SOLD QTY";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalDiscount
            // 
            this.lblTotalDiscount.BackColor = System.Drawing.SystemColors.Control;
            this.lblTotalDiscount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTotalDiscount.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotalDiscount.Location = new System.Drawing.Point(350, 572);
            this.lblTotalDiscount.Name = "lblTotalDiscount";
            this.lblTotalDiscount.Size = new System.Drawing.Size(165, 45);
            this.lblTotalDiscount.TabIndex = 133;
            this.lblTotalDiscount.Text = "0.00";
            this.lblTotalDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.DarkBlue;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(264, 572);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 45);
            this.label13.TabIndex = 132;
            this.label13.Text = "TOTAL DISC";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.BackColor = System.Drawing.SystemColors.Control;
            this.lblSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSubTotal.ForeColor = System.Drawing.Color.Maroon;
            this.lblSubTotal.Location = new System.Drawing.Point(93, 527);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(165, 45);
            this.lblSubTotal.TabIndex = 131;
            this.lblSubTotal.Text = "0.00";
            this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.DarkBlue;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(7, 527);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(84, 45);
            this.label17.TabIndex = 130;
            this.label17.Text = "SUB TOTAL";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.SystemColors.Control;
            this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDate.Location = new System.Drawing.Point(93, 437);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(165, 45);
            this.lblDate.TabIndex = 137;
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(7, 437);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 45);
            this.label2.TabIndex = 136;
            this.label2.Text = "DATE";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPayMethod
            // 
            this.lblPayMethod.BackColor = System.Drawing.SystemColors.Control;
            this.lblPayMethod.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPayMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPayMethod.Location = new System.Drawing.Point(350, 437);
            this.lblPayMethod.Name = "lblPayMethod";
            this.lblPayMethod.Size = new System.Drawing.Size(165, 45);
            this.lblPayMethod.TabIndex = 139;
            this.lblPayMethod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPayMethod.DoubleClick += new System.EventHandler(this.lblPayMethod_DoubleClick);
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(264, 437);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 45);
            this.label4.TabIndex = 138;
            this.label4.Text = "PAY METHOD";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTax
            // 
            this.lblTax.BackColor = System.Drawing.SystemColors.Control;
            this.lblTax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTax.ForeColor = System.Drawing.Color.Maroon;
            this.lblTax.Location = new System.Drawing.Point(93, 572);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(165, 45);
            this.lblTax.TabIndex = 141;
            this.lblTax.Text = "0.00";
            this.lblTax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.DarkBlue;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(7, 572);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 45);
            this.label7.TabIndex = 140;
            this.label7.Text = "TAX";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.BackColor = System.Drawing.SystemColors.Control;
            this.lblGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGrandTotal.ForeColor = System.Drawing.Color.Maroon;
            this.lblGrandTotal.Location = new System.Drawing.Point(350, 527);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(165, 45);
            this.lblGrandTotal.TabIndex = 143;
            this.lblGrandTotal.Text = "0.00";
            this.lblGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.DarkBlue;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(264, 527);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 45);
            this.label9.TabIndex = 142;
            this.label9.Text = "GRAND TOTAL";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.SystemColors.Control;
            this.lblTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTime.Location = new System.Drawing.Point(93, 482);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(165, 45);
            this.lblTime.TabIndex = 145;
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(7, 482);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 45);
            this.label11.TabIndex = 144;
            this.label11.Text = "TIME";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStoreCode
            // 
            this.lblStoreCode.BackColor = System.Drawing.SystemColors.Control;
            this.lblStoreCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStoreCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStoreCode.Location = new System.Drawing.Point(93, 392);
            this.lblStoreCode.Name = "lblStoreCode";
            this.lblStoreCode.Size = new System.Drawing.Size(165, 45);
            this.lblStoreCode.TabIndex = 147;
            this.lblStoreCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.Location = new System.Drawing.Point(7, 392);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 45);
            this.label14.TabIndex = 146;
            this.label14.Text = "STORE CODE";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReceiptID
            // 
            this.lblReceiptID.BackColor = System.Drawing.SystemColors.Control;
            this.lblReceiptID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblReceiptID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblReceiptID.Location = new System.Drawing.Point(93, 347);
            this.lblReceiptID.Name = "lblReceiptID";
            this.lblReceiptID.Size = new System.Drawing.Size(165, 45);
            this.lblReceiptID.TabIndex = 149;
            this.lblReceiptID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label16.Location = new System.Drawing.Point(7, 347);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(84, 45);
            this.label16.TabIndex = 148;
            this.label16.Text = "RECEIPT ID";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRegNum
            // 
            this.lblRegNum.BackColor = System.Drawing.SystemColors.Control;
            this.lblRegNum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRegNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRegNum.Location = new System.Drawing.Point(350, 347);
            this.lblRegNum.Name = "lblRegNum";
            this.lblRegNum.Size = new System.Drawing.Size(165, 45);
            this.lblRegNum.TabIndex = 153;
            this.lblRegNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label19.Location = new System.Drawing.Point(264, 347);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(84, 45);
            this.label19.TabIndex = 152;
            this.label19.Text = "REG #";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCashierID
            // 
            this.lblCashierID.BackColor = System.Drawing.SystemColors.Control;
            this.lblCashierID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCashierID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCashierID.Location = new System.Drawing.Point(350, 392);
            this.lblCashierID.Name = "lblCashierID";
            this.lblCashierID.Size = new System.Drawing.Size(165, 45);
            this.lblCashierID.TabIndex = 151;
            this.lblCashierID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label21.Location = new System.Drawing.Point(264, 392);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(84, 45);
            this.label21.TabIndex = 150;
            this.label21.Text = "CASHIER ID";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMemberCode
            // 
            this.lblMemberCode.BackColor = System.Drawing.SystemColors.Control;
            this.lblMemberCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMemberCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMemberCode.Location = new System.Drawing.Point(607, 347);
            this.lblMemberCode.Name = "lblMemberCode";
            this.lblMemberCode.Size = new System.Drawing.Size(165, 45);
            this.lblMemberCode.TabIndex = 157;
            this.lblMemberCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label23.Location = new System.Drawing.Point(521, 347);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(84, 45);
            this.label23.TabIndex = 156;
            this.label23.Text = "MEMBER CODE";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMemberName
            // 
            this.lblMemberName.BackColor = System.Drawing.SystemColors.Control;
            this.lblMemberName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMemberName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMemberName.Location = new System.Drawing.Point(607, 392);
            this.lblMemberName.Name = "lblMemberName";
            this.lblMemberName.Size = new System.Drawing.Size(165, 45);
            this.lblMemberName.TabIndex = 155;
            this.lblMemberName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            this.label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label25.Location = new System.Drawing.Point(521, 392);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(84, 45);
            this.label25.TabIndex = 154;
            this.label25.Text = "MEMBER NAME";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReceiptType
            // 
            this.lblReceiptType.BackColor = System.Drawing.SystemColors.Control;
            this.lblReceiptType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblReceiptType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblReceiptType.Location = new System.Drawing.Point(607, 437);
            this.lblReceiptType.Name = "lblReceiptType";
            this.lblReceiptType.Size = new System.Drawing.Size(165, 45);
            this.lblReceiptType.TabIndex = 161;
            this.lblReceiptType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label27.Location = new System.Drawing.Point(521, 437);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(84, 45);
            this.label27.TabIndex = 160;
            this.label27.Text = "RECEIPT TYPE";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReceiptStatus
            // 
            this.lblReceiptStatus.BackColor = System.Drawing.SystemColors.Control;
            this.lblReceiptStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblReceiptStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblReceiptStatus.Location = new System.Drawing.Point(607, 482);
            this.lblReceiptStatus.Name = "lblReceiptStatus";
            this.lblReceiptStatus.Size = new System.Drawing.Size(165, 45);
            this.lblReceiptStatus.TabIndex = 159;
            this.lblReceiptStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            this.label29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label29.Location = new System.Drawing.Point(521, 482);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(84, 45);
            this.label29.TabIndex = 158;
            this.label29.Text = "RECEIPT STATUS";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPay
            // 
            this.lblPay.BackColor = System.Drawing.SystemColors.Control;
            this.lblPay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPay.Location = new System.Drawing.Point(607, 527);
            this.lblPay.Name = "lblPay";
            this.lblPay.Size = new System.Drawing.Size(165, 45);
            this.lblPay.TabIndex = 165;
            this.lblPay.Text = "0.00";
            this.lblPay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label31
            // 
            this.label31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label31.Location = new System.Drawing.Point(521, 527);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(84, 45);
            this.label31.TabIndex = 164;
            this.label31.Text = "PAY";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblChange
            // 
            this.lblChange.BackColor = System.Drawing.SystemColors.Control;
            this.lblChange.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblChange.Location = new System.Drawing.Point(607, 572);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(165, 45);
            this.lblChange.TabIndex = 163;
            this.lblChange.Text = "0.00";
            this.lblChange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label33
            // 
            this.label33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label33.Location = new System.Drawing.Point(521, 572);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(84, 45);
            this.label33.TabIndex = 162;
            this.label33.Text = "CHANGE";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ReceiptDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 686);
            this.ControlBox = false;
            this.Controls.Add(this.lblPay);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.lblChange);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.lblReceiptType);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.lblReceiptStatus);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.lblMemberCode);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.lblMemberName);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.lblRegNum);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lblCashierID);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.lblReceiptID);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblStoreCode);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblGrandTotal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblTax);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblPayMethod);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTotalSold);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTotalDiscount);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReceiptDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RECEIPT IN DETAIL";
            this.Load += new System.EventHandler(this.ReceiptDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTotalSold;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotalDiscount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPayMethod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label lblStoreCode;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblReceiptID;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblRegNum;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblCashierID;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblMemberCode;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblMemberName;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lblReceiptType;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label lblReceiptStatus;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label lblPay;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Label label33;
    }
}