// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 05-31-2017
// ***********************************************************************
// <copyright file="Return.designer.cs" company="Beauty4u">
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
    /// Class Return.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class Return
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Return));
            this.txtReceiptID = new System.Windows.Forms.TextBox();
            this.lblTitleReceiptID = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoBtnWithNoTax = new System.Windows.Forms.RadioButton();
            this.rdoBtnWithTax = new System.Windows.Forms.RadioButton();
            this.btnSameCopy = new System.Windows.Forms.Button();
            this.btnInput = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnTransferRefund = new System.Windows.Forms.Button();
            this.lblPayBy = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStoreCredit = new System.Windows.Forms.Button();
            this.lblNewGrandTotal = new System.Windows.Forms.Label();
            this.lblNewTax = new System.Windows.Forms.Label();
            this.lblNewSubTotal = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblMemberName = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.lblReceiptID = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnQtyMinus = new System.Windows.Forms.Button();
            this.btnQtyPlus = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRefund = new System.Windows.Forms.Button();
            this.grpBoxRefundOptions = new System.Windows.Forms.GroupBox();
            this.radioBtnCreditTerminal = new System.Windows.Forms.RadioButton();
            this.radioBtnCredit = new System.Windows.Forms.RadioButton();
            this.radioBtnCash = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtRefundAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.UIStateButtonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnResetDevice = new System.Windows.Forms.Button();
            this.gBoxCardEntryMethods = new System.Windows.Forms.GroupBox();
            this.ManualEntryCheckbox = new System.Windows.Forms.CheckBox();
            this.ContactlessCheckbox = new System.Windows.Forms.CheckBox();
            this.ChipCheckbox = new System.Windows.Forms.CheckBox();
            this.MagStripeCheckbox = new System.Windows.Forms.CheckBox();
            this.DeviceCurrentStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ConnectStatusLabel = new System.Windows.Forms.Label();
            this.btnVoid = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.grpBoxRefundOptions.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gBoxCardEntryMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtReceiptID
            // 
            this.txtReceiptID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtReceiptID.Location = new System.Drawing.Point(107, 16);
            this.txtReceiptID.Name = "txtReceiptID";
            this.txtReceiptID.ReadOnly = true;
            this.txtReceiptID.Size = new System.Drawing.Size(244, 30);
            this.txtReceiptID.TabIndex = 0;
            this.txtReceiptID.Text = "HIT INPUT BUTTON >> ";
            // 
            // lblTitleReceiptID
            // 
            this.lblTitleReceiptID.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.lblTitleReceiptID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleReceiptID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleReceiptID.ForeColor = System.Drawing.Color.Black;
            this.lblTitleReceiptID.Location = new System.Drawing.Point(12, 16);
            this.lblTitleReceiptID.Name = "lblTitleReceiptID";
            this.lblTitleReceiptID.Size = new System.Drawing.Size(95, 30);
            this.lblTitleReceiptID.TabIndex = 1;
            this.lblTitleReceiptID.Text = "RECEIPT ID";
            this.lblTitleReceiptID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(422, 288);
            this.dataGridView1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.groupBox1.Controls.Add(this.rdoBtnWithNoTax);
            this.groupBox1.Controls.Add(this.rdoBtnWithTax);
            this.groupBox1.Controls.Add(this.btnSameCopy);
            this.groupBox1.Controls.Add(this.btnInput);
            this.groupBox1.Controls.Add(this.btnSelectAll);
            this.groupBox1.Controls.Add(this.btnTransferRefund);
            this.groupBox1.Controls.Add(this.lblPayBy);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnStoreCredit);
            this.groupBox1.Controls.Add(this.lblNewGrandTotal);
            this.groupBox1.Controls.Add(this.lblNewTax);
            this.groupBox1.Controls.Add(this.lblNewSubTotal);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.lblGrandTotal);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.lblTax);
            this.groupBox1.Controls.Add(this.lblMemberName);
            this.groupBox1.Controls.Add(this.lblSubTotal);
            this.groupBox1.Controls.Add(this.lblReceiptID);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnQtyMinus);
            this.groupBox1.Controls.Add(this.btnQtyPlus);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.btnReturn);
            this.groupBox1.Controls.Add(this.txtReceiptID);
            this.groupBox1.Controls.Add(this.dataGridView2);
            this.groupBox1.Controls.Add(this.lblTitleReceiptID);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Location = new System.Drawing.Point(12, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(925, 441);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // rdoBtnWithNoTax
            // 
            this.rdoBtnWithNoTax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoBtnWithNoTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnWithNoTax.ForeColor = System.Drawing.Color.Red;
            this.rdoBtnWithNoTax.Location = new System.Drawing.Point(594, 403);
            this.rdoBtnWithNoTax.Name = "rdoBtnWithNoTax";
            this.rdoBtnWithNoTax.Size = new System.Drawing.Size(101, 30);
            this.rdoBtnWithNoTax.TabIndex = 179;
            this.rdoBtnWithNoTax.Text = "With No Tax";
            this.rdoBtnWithNoTax.UseVisualStyleBackColor = true;
            this.rdoBtnWithNoTax.CheckedChanged += new System.EventHandler(this.rdoBtnWithNoTax_CheckedChanged);
            // 
            // rdoBtnWithTax
            // 
            this.rdoBtnWithTax.BackColor = System.Drawing.Color.ForestGreen;
            this.rdoBtnWithTax.Checked = true;
            this.rdoBtnWithTax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoBtnWithTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnWithTax.ForeColor = System.Drawing.Color.Black;
            this.rdoBtnWithTax.Location = new System.Drawing.Point(497, 403);
            this.rdoBtnWithTax.Name = "rdoBtnWithTax";
            this.rdoBtnWithTax.Size = new System.Drawing.Size(95, 30);
            this.rdoBtnWithTax.TabIndex = 178;
            this.rdoBtnWithTax.TabStop = true;
            this.rdoBtnWithTax.Text = "With Tax";
            this.rdoBtnWithTax.UseVisualStyleBackColor = false;
            this.rdoBtnWithTax.CheckedChanged += new System.EventHandler(this.rdoBtnWithTax_CheckedChanged);
            // 
            // btnSameCopy
            // 
            this.btnSameCopy.BackColor = System.Drawing.Color.Silver;
            this.btnSameCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSameCopy.ForeColor = System.Drawing.Color.Black;
            this.btnSameCopy.Location = new System.Drawing.Point(436, 202);
            this.btnSameCopy.Name = "btnSameCopy";
            this.btnSameCopy.Size = new System.Drawing.Size(59, 50);
            this.btnSameCopy.TabIndex = 177;
            this.btnSameCopy.Text = "Exact Same";
            this.btnSameCopy.UseVisualStyleBackColor = false;
            this.btnSameCopy.Click += new System.EventHandler(this.btnSameCopy_Click);
            // 
            // btnInput
            // 
            this.btnInput.BackColor = System.Drawing.Color.Silver;
            this.btnInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnInput.ForeColor = System.Drawing.Color.Black;
            this.btnInput.Location = new System.Drawing.Point(353, 16);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(81, 30);
            this.btnInput.TabIndex = 174;
            this.btnInput.Text = "INPUT";
            this.btnInput.UseVisualStyleBackColor = false;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.BackColor = System.Drawing.Color.Silver;
            this.btnSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSelectAll.ForeColor = System.Drawing.Color.Black;
            this.btnSelectAll.Location = new System.Drawing.Point(436, 64);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(59, 50);
            this.btnSelectAll.TabIndex = 173;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = false;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnTransferRefund
            // 
            this.btnTransferRefund.BackColor = System.Drawing.Color.Silver;
            this.btnTransferRefund.Enabled = false;
            this.btnTransferRefund.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTransferRefund.ForeColor = System.Drawing.Color.Black;
            this.btnTransferRefund.Location = new System.Drawing.Point(698, 342);
            this.btnTransferRefund.Name = "btnTransferRefund";
            this.btnTransferRefund.Size = new System.Drawing.Size(221, 30);
            this.btnTransferRefund.TabIndex = 172;
            this.btnTransferRefund.Text = "TRANSFER TO REFUND";
            this.btnTransferRefund.UseVisualStyleBackColor = false;
            this.btnTransferRefund.Click += new System.EventHandler(this.btnTransferRefund_Click);
            // 
            // lblPayBy
            // 
            this.lblPayBy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblPayBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPayBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPayBy.Location = new System.Drawing.Point(294, 403);
            this.lblPayBy.Name = "lblPayBy";
            this.lblPayBy.Size = new System.Drawing.Size(140, 30);
            this.lblPayBy.TabIndex = 171;
            this.lblPayBy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(213, 403);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 30);
            this.label3.TabIndex = 170;
            this.label3.Text = "Payment Method";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStoreCredit
            // 
            this.btnStoreCredit.BackColor = System.Drawing.Color.Silver;
            this.btnStoreCredit.Enabled = false;
            this.btnStoreCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStoreCredit.ForeColor = System.Drawing.Color.Black;
            this.btnStoreCredit.Location = new System.Drawing.Point(698, 16);
            this.btnStoreCredit.Name = "btnStoreCredit";
            this.btnStoreCredit.Size = new System.Drawing.Size(221, 30);
            this.btnStoreCredit.TabIndex = 169;
            this.btnStoreCredit.Text = "MAKE NEW STORE CREDIT";
            this.btnStoreCredit.UseVisualStyleBackColor = false;
            this.btnStoreCredit.Click += new System.EventHandler(this.btnStoreCredit_Click);
            // 
            // lblNewGrandTotal
            // 
            this.lblNewGrandTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblNewGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNewGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewGrandTotal.ForeColor = System.Drawing.Color.Red;
            this.lblNewGrandTotal.Location = new System.Drawing.Point(758, 403);
            this.lblNewGrandTotal.Name = "lblNewGrandTotal";
            this.lblNewGrandTotal.Size = new System.Drawing.Size(161, 30);
            this.lblNewGrandTotal.TabIndex = 168;
            this.lblNewGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNewTax
            // 
            this.lblNewTax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblNewTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNewTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewTax.ForeColor = System.Drawing.Color.Red;
            this.lblNewTax.Location = new System.Drawing.Point(758, 373);
            this.lblNewTax.Name = "lblNewTax";
            this.lblNewTax.Size = new System.Drawing.Size(161, 30);
            this.lblNewTax.TabIndex = 167;
            this.lblNewTax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNewSubTotal
            // 
            this.lblNewSubTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblNewSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNewSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewSubTotal.ForeColor = System.Drawing.Color.Red;
            this.lblNewSubTotal.Location = new System.Drawing.Point(557, 373);
            this.lblNewSubTotal.Name = "lblNewSubTotal";
            this.lblNewSubTotal.Size = new System.Drawing.Size(140, 30);
            this.lblNewSubTotal.TabIndex = 166;
            this.lblNewSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.FloralWhite;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.Location = new System.Drawing.Point(497, 373);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 30);
            this.label14.TabIndex = 165;
            this.label14.Text = "Sub Total";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.FloralWhite;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.Location = new System.Drawing.Point(697, 373);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 30);
            this.label15.TabIndex = 164;
            this.label15.Text = "Tax";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.FloralWhite;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label16.Location = new System.Drawing.Point(697, 403);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(61, 30);
            this.label16.TabIndex = 163;
            this.label16.Text = "Grand Total";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrandTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGrandTotal.Location = new System.Drawing.Point(354, 373);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(80, 30);
            this.lblGrandTotal.TabIndex = 162;
            this.lblGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDate.Location = new System.Drawing.Point(354, 343);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(80, 30);
            this.lblDate.TabIndex = 161;
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTax
            // 
            this.lblTax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTax.Location = new System.Drawing.Point(213, 373);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(81, 30);
            this.lblTax.TabIndex = 160;
            this.lblTax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMemberName
            // 
            this.lblMemberName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblMemberName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMemberName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMemberName.Location = new System.Drawing.Point(213, 343);
            this.lblMemberName.Name = "lblMemberName";
            this.lblMemberName.Size = new System.Drawing.Size(81, 30);
            this.lblMemberName.TabIndex = 159;
            this.lblMemberName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSubTotal.Location = new System.Drawing.Point(72, 373);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(80, 30);
            this.lblSubTotal.TabIndex = 158;
            this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReceiptID
            // 
            this.lblReceiptID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblReceiptID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReceiptID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiptID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblReceiptID.Location = new System.Drawing.Point(72, 343);
            this.lblReceiptID.Name = "lblReceiptID";
            this.lblReceiptID.Size = new System.Drawing.Size(80, 30);
            this.lblReceiptID.TabIndex = 149;
            this.lblReceiptID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(294, 343);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 30);
            this.label10.TabIndex = 157;
            this.label10.Text = "Date Time";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(152, 343);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 30);
            this.label9.TabIndex = 156;
            this.label9.Text = "Member Name";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(12, 343);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 30);
            this.label8.TabIndex = 155;
            this.label8.Text = "Receipt ID";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FloralWhite;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(12, 373);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 30);
            this.label7.TabIndex = 154;
            this.label7.Text = "Sub Total";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FloralWhite;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(152, 373);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 30);
            this.label6.TabIndex = 153;
            this.label6.Text = "Tax";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FloralWhite;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(294, 373);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 30);
            this.label5.TabIndex = 152;
            this.label5.Text = "Grand Total";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnQtyMinus
            // 
            this.btnQtyMinus.BackColor = System.Drawing.Color.Silver;
            this.btnQtyMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnQtyMinus.ForeColor = System.Drawing.Color.Black;
            this.btnQtyMinus.Location = new System.Drawing.Point(559, 343);
            this.btnQtyMinus.Name = "btnQtyMinus";
            this.btnQtyMinus.Size = new System.Drawing.Size(60, 30);
            this.btnQtyMinus.TabIndex = 149;
            this.btnQtyMinus.Text = "QTY-";
            this.btnQtyMinus.UseVisualStyleBackColor = false;
            this.btnQtyMinus.Click += new System.EventHandler(this.btnQtyMinus_Click);
            // 
            // btnQtyPlus
            // 
            this.btnQtyPlus.BackColor = System.Drawing.Color.Silver;
            this.btnQtyPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnQtyPlus.ForeColor = System.Drawing.Color.Black;
            this.btnQtyPlus.Location = new System.Drawing.Point(497, 343);
            this.btnQtyPlus.Name = "btnQtyPlus";
            this.btnQtyPlus.Size = new System.Drawing.Size(60, 30);
            this.btnQtyPlus.TabIndex = 148;
            this.btnQtyPlus.Text = "QTY+";
            this.btnQtyPlus.UseVisualStyleBackColor = false;
            this.btnQtyPlus.Click += new System.EventHandler(this.btnQtyPlus_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Silver;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReset.ForeColor = System.Drawing.Color.Black;
            this.btnReset.Location = new System.Drawing.Point(436, 272);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(59, 50);
            this.btnReset.TabIndex = 147;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Silver;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(353, 51);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(81, 30);
            this.btnSearch.TabIndex = 146;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Visible = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.Silver;
            this.btnReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReturn.ForeColor = System.Drawing.Color.Black;
            this.btnReturn.Location = new System.Drawing.Point(497, 16);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(200, 30);
            this.btnReturn.TabIndex = 145;
            this.btnReturn.Text = "Generate Return Transaction";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(497, 51);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(422, 288);
            this.dataGridView2.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Silver;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Location = new System.Drawing.Point(436, 133);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(59, 50);
            this.btnAdd.TabIndex = 142;
            this.btnAdd.Text = ">>";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.MediumBlue;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(733, 176);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(185, 60);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRefund
            // 
            this.btnRefund.BackColor = System.Drawing.Color.MediumBlue;
            this.btnRefund.Enabled = false;
            this.btnRefund.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRefund.ForeColor = System.Drawing.Color.White;
            this.btnRefund.Location = new System.Drawing.Point(440, 176);
            this.btnRefund.Name = "btnRefund";
            this.btnRefund.Size = new System.Drawing.Size(125, 60);
            this.btnRefund.TabIndex = 139;
            this.btnRefund.Text = "REFUND";
            this.btnRefund.UseVisualStyleBackColor = false;
            this.btnRefund.Click += new System.EventHandler(this.btnRefund_Click);
            // 
            // grpBoxRefundOptions
            // 
            this.grpBoxRefundOptions.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.grpBoxRefundOptions.Controls.Add(this.radioBtnCreditTerminal);
            this.grpBoxRefundOptions.Controls.Add(this.radioBtnCredit);
            this.grpBoxRefundOptions.Controls.Add(this.radioBtnCash);
            this.grpBoxRefundOptions.Enabled = false;
            this.grpBoxRefundOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grpBoxRefundOptions.ForeColor = System.Drawing.Color.Black;
            this.grpBoxRefundOptions.Location = new System.Drawing.Point(11, 16);
            this.grpBoxRefundOptions.Name = "grpBoxRefundOptions";
            this.grpBoxRefundOptions.Size = new System.Drawing.Size(293, 220);
            this.grpBoxRefundOptions.TabIndex = 140;
            this.grpBoxRefundOptions.TabStop = false;
            this.grpBoxRefundOptions.Text = "REFUND OPTIONS";
            // 
            // radioBtnCreditTerminal
            // 
            this.radioBtnCreditTerminal.BackColor = System.Drawing.Color.PaleGreen;
            this.radioBtnCreditTerminal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioBtnCreditTerminal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.radioBtnCreditTerminal.ForeColor = System.Drawing.Color.Black;
            this.radioBtnCreditTerminal.Location = new System.Drawing.Point(6, 154);
            this.radioBtnCreditTerminal.Name = "radioBtnCreditTerminal";
            this.radioBtnCreditTerminal.Size = new System.Drawing.Size(277, 50);
            this.radioBtnCreditTerminal.TabIndex = 3;
            this.radioBtnCreditTerminal.Text = "CREDIT (TERMINAL)";
            this.radioBtnCreditTerminal.UseVisualStyleBackColor = false;
            this.radioBtnCreditTerminal.CheckedChanged += new System.EventHandler(this.radioBtnCreditTerminal_CheckedChanged);
            this.radioBtnCreditTerminal.Click += new System.EventHandler(this.radioBtnCreditTerminal_Click);
            // 
            // radioBtnCredit
            // 
            this.radioBtnCredit.BackColor = System.Drawing.Color.PaleGreen;
            this.radioBtnCredit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioBtnCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.radioBtnCredit.ForeColor = System.Drawing.Color.Black;
            this.radioBtnCredit.Location = new System.Drawing.Point(6, 92);
            this.radioBtnCredit.Name = "radioBtnCredit";
            this.radioBtnCredit.Size = new System.Drawing.Size(277, 50);
            this.radioBtnCredit.TabIndex = 2;
            this.radioBtnCredit.Text = "CREDIT (CLOVER)";
            this.radioBtnCredit.UseVisualStyleBackColor = false;
            this.radioBtnCredit.CheckedChanged += new System.EventHandler(this.radioBtnCredit_CheckedChanged);
            this.radioBtnCredit.Click += new System.EventHandler(this.radioBtnCredit_Click);
            // 
            // radioBtnCash
            // 
            this.radioBtnCash.BackColor = System.Drawing.Color.PaleGreen;
            this.radioBtnCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioBtnCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.radioBtnCash.ForeColor = System.Drawing.Color.Black;
            this.radioBtnCash.Location = new System.Drawing.Point(6, 30);
            this.radioBtnCash.Name = "radioBtnCash";
            this.radioBtnCash.Size = new System.Drawing.Size(277, 50);
            this.radioBtnCash.TabIndex = 0;
            this.radioBtnCash.Text = "CASH";
            this.radioBtnCash.UseVisualStyleBackColor = false;
            this.radioBtnCash.CheckedChanged += new System.EventHandler(this.radioBtnCash_CheckedChanged);
            this.radioBtnCash.Click += new System.EventHandler(this.radioBtnCash_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.groupBox4.Controls.Add(this.txtRefundAmount);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.ForeColor = System.Drawing.Color.Black;
            this.groupBox4.Location = new System.Drawing.Point(310, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(255, 104);
            this.groupBox4.TabIndex = 141;
            this.groupBox4.TabStop = false;
            // 
            // txtRefundAmount
            // 
            this.txtRefundAmount.BackColor = System.Drawing.Color.White;
            this.txtRefundAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtRefundAmount.Location = new System.Drawing.Point(4, 60);
            this.txtRefundAmount.Name = "txtRefundAmount";
            this.txtRefundAmount.ReadOnly = true;
            this.txtRefundAmount.Size = new System.Drawing.Size(245, 38);
            this.txtRefundAmount.TabIndex = 1;
            this.txtRefundAmount.Text = "0.00";
            this.txtRefundAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(5, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "REFUND AMOUNT";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.btnResetDevice);
            this.groupBox2.Controls.Add(this.gBoxCardEntryMethods);
            this.groupBox2.Controls.Add(this.DeviceCurrentStatus);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.ConnectStatusLabel);
            this.groupBox2.Controls.Add(this.btnVoid);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.btnRefund);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.grpBoxRefundOptions);
            this.groupBox2.Location = new System.Drawing.Point(13, 444);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(924, 248);
            this.groupBox2.TabIndex = 142;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.UIStateButtonPanel);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox3.Location = new System.Drawing.Point(571, 73);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(345, 50);
            this.groupBox3.TabIndex = 224;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Clover Response Controls";
            // 
            // UIStateButtonPanel
            // 
            this.UIStateButtonPanel.AutoSize = true;
            this.UIStateButtonPanel.Location = new System.Drawing.Point(9, 19);
            this.UIStateButtonPanel.MinimumSize = new System.Drawing.Size(10, 0);
            this.UIStateButtonPanel.Name = "UIStateButtonPanel";
            this.UIStateButtonPanel.Size = new System.Drawing.Size(10, 0);
            this.UIStateButtonPanel.TabIndex = 224;
            this.UIStateButtonPanel.WrapContents = false;
            // 
            // btnResetDevice
            // 
            this.btnResetDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnResetDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnResetDevice.ForeColor = System.Drawing.Color.Black;
            this.btnResetDevice.Location = new System.Drawing.Point(636, 192);
            this.btnResetDevice.Name = "btnResetDevice";
            this.btnResetDevice.Size = new System.Drawing.Size(91, 44);
            this.btnResetDevice.TabIndex = 223;
            this.btnResetDevice.Text = "RESET DEVICE";
            this.btnResetDevice.UseVisualStyleBackColor = false;
            this.btnResetDevice.Visible = false;
            this.btnResetDevice.Click += new System.EventHandler(this.btnResetDevice_Click);
            // 
            // gBoxCardEntryMethods
            // 
            this.gBoxCardEntryMethods.Controls.Add(this.ManualEntryCheckbox);
            this.gBoxCardEntryMethods.Controls.Add(this.ContactlessCheckbox);
            this.gBoxCardEntryMethods.Controls.Add(this.ChipCheckbox);
            this.gBoxCardEntryMethods.Controls.Add(this.MagStripeCheckbox);
            this.gBoxCardEntryMethods.Enabled = false;
            this.gBoxCardEntryMethods.Location = new System.Drawing.Point(571, 129);
            this.gBoxCardEntryMethods.Name = "gBoxCardEntryMethods";
            this.gBoxCardEntryMethods.Size = new System.Drawing.Size(345, 41);
            this.gBoxCardEntryMethods.TabIndex = 222;
            this.gBoxCardEntryMethods.TabStop = false;
            this.gBoxCardEntryMethods.Text = "Card Entry Methods (Sale): ";
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
            // DeviceCurrentStatus
            // 
            this.DeviceCurrentStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DeviceCurrentStatus.AutoSize = true;
            this.DeviceCurrentStatus.BackColor = System.Drawing.Color.Black;
            this.DeviceCurrentStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DeviceCurrentStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.DeviceCurrentStatus.ForeColor = System.Drawing.Color.White;
            this.DeviceCurrentStatus.Location = new System.Drawing.Point(571, 31);
            this.DeviceCurrentStatus.Name = "DeviceCurrentStatus";
            this.DeviceCurrentStatus.Size = new System.Drawing.Size(26, 22);
            this.DeviceCurrentStatus.TabIndex = 221;
            this.DeviceCurrentStatus.Text = "...";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(682, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 23);
            this.label2.TabIndex = 220;
            this.label2.Text = "DEVICE STATUS: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ConnectStatusLabel
            // 
            this.ConnectStatusLabel.Location = new System.Drawing.Point(827, 8);
            this.ConnectStatusLabel.Name = "ConnectStatusLabel";
            this.ConnectStatusLabel.Size = new System.Drawing.Size(91, 23);
            this.ConnectStatusLabel.TabIndex = 219;
            this.ConnectStatusLabel.Text = "Not Connected";
            this.ConnectStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnVoid
            // 
            this.btnVoid.BackColor = System.Drawing.Color.MediumBlue;
            this.btnVoid.Enabled = false;
            this.btnVoid.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnVoid.ForeColor = System.Drawing.Color.White;
            this.btnVoid.Location = new System.Drawing.Point(310, 176);
            this.btnVoid.Name = "btnVoid";
            this.btnVoid.Size = new System.Drawing.Size(125, 60);
            this.btnVoid.TabIndex = 142;
            this.btnVoid.Text = "VOID";
            this.btnVoid.UseVisualStyleBackColor = false;
            this.btnVoid.Click += new System.EventHandler(this.btnVoid_Click);
            // 
            // Return
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(949, 694);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Return";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RETURN MENU";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Return_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.grpBoxRefundOptions.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gBoxCardEntryMethods.ResumeLayout(false);
            this.gBoxCardEntryMethods.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The text receipt identifier
        /// </summary>
        public System.Windows.Forms.TextBox txtReceiptID;
        /// <summary>
        /// The label title receipt identifier
        /// </summary>
        private System.Windows.Forms.Label lblTitleReceiptID;
        /// <summary>
        /// The data grid view1
        /// </summary>
        private System.Windows.Forms.DataGridView dataGridView1;
        /// <summary>
        /// The group box1
        /// </summary>
        private System.Windows.Forms.GroupBox groupBox1;
        /// <summary>
        /// The BTN close
        /// </summary>
        public System.Windows.Forms.Button btnClose;
        /// <summary>
        /// The GRP box refund options
        /// </summary>
        private System.Windows.Forms.GroupBox grpBoxRefundOptions;
        /// <summary>
        /// The radio BTN credit
        /// </summary>
        private System.Windows.Forms.RadioButton radioBtnCredit;
        /// <summary>
        /// The radio BTN cash
        /// </summary>
        private System.Windows.Forms.RadioButton radioBtnCash;
        /// <summary>
        /// The group box4
        /// </summary>
        private System.Windows.Forms.GroupBox groupBox4;
        /// <summary>
        /// The text refund amount
        /// </summary>
        private System.Windows.Forms.TextBox txtRefundAmount;
        /// <summary>
        /// The label1
        /// </summary>
        private System.Windows.Forms.Label label1;
        /// <summary>
        /// The data grid view2
        /// </summary>
        private System.Windows.Forms.DataGridView dataGridView2;
        /// <summary>
        /// The BTN add
        /// </summary>
        private System.Windows.Forms.Button btnAdd;
        /// <summary>
        /// The group box2
        /// </summary>
        private System.Windows.Forms.GroupBox groupBox2;
        /// <summary>
        /// The BTN return
        /// </summary>
        private System.Windows.Forms.Button btnReturn;
        /// <summary>
        /// The BTN search
        /// </summary>
        private System.Windows.Forms.Button btnSearch;
        /// <summary>
        /// The BTN reset
        /// </summary>
        private System.Windows.Forms.Button btnReset;
        /// <summary>
        /// The BTN qty minus
        /// </summary>
        private System.Windows.Forms.Button btnQtyMinus;
        /// <summary>
        /// The BTN qty plus
        /// </summary>
        private System.Windows.Forms.Button btnQtyPlus;
        /// <summary>
        /// The label7
        /// </summary>
        private System.Windows.Forms.Label label7;
        /// <summary>
        /// The label6
        /// </summary>
        private System.Windows.Forms.Label label6;
        /// <summary>
        /// The label5
        /// </summary>
        private System.Windows.Forms.Label label5;
        /// <summary>
        /// The label8
        /// </summary>
        private System.Windows.Forms.Label label8;
        /// <summary>
        /// The label10
        /// </summary>
        private System.Windows.Forms.Label label10;
        /// <summary>
        /// The label9
        /// </summary>
        private System.Windows.Forms.Label label9;
        /// <summary>
        /// The label grand total
        /// </summary>
        private System.Windows.Forms.Label lblGrandTotal;
        /// <summary>
        /// The label date
        /// </summary>
        private System.Windows.Forms.Label lblDate;
        /// <summary>
        /// The label tax
        /// </summary>
        private System.Windows.Forms.Label lblTax;
        /// <summary>
        /// The label member name
        /// </summary>
        private System.Windows.Forms.Label lblMemberName;
        /// <summary>
        /// The label sub total
        /// </summary>
        private System.Windows.Forms.Label lblSubTotal;
        /// <summary>
        /// The label receipt identifier
        /// </summary>
        private System.Windows.Forms.Label lblReceiptID;
        /// <summary>
        /// The label new grand total
        /// </summary>
        private System.Windows.Forms.Label lblNewGrandTotal;
        /// <summary>
        /// The label new tax
        /// </summary>
        private System.Windows.Forms.Label lblNewTax;
        /// <summary>
        /// The label new sub total
        /// </summary>
        private System.Windows.Forms.Label lblNewSubTotal;
        /// <summary>
        /// The label14
        /// </summary>
        private System.Windows.Forms.Label label14;
        /// <summary>
        /// The label15
        /// </summary>
        private System.Windows.Forms.Label label15;
        /// <summary>
        /// The label16
        /// </summary>
        private System.Windows.Forms.Label label16;
        /// <summary>
        /// The BTN store credit
        /// </summary>
        private System.Windows.Forms.Button btnStoreCredit;
        /// <summary>
        /// The label pay by
        /// </summary>
        private System.Windows.Forms.Label lblPayBy;
        /// <summary>
        /// The label3
        /// </summary>
        private System.Windows.Forms.Label label3;
        /// <summary>
        /// The BTN transfer refund
        /// </summary>
        private System.Windows.Forms.Button btnTransferRefund;
        /// <summary>
        /// The BTN select all
        /// </summary>
        private System.Windows.Forms.Button btnSelectAll;
        /// <summary>
        /// The radio BTN credit terminal
        /// </summary>
        private System.Windows.Forms.RadioButton radioBtnCreditTerminal;
        /// <summary>
        /// The BTN input
        /// </summary>
        private System.Windows.Forms.Button btnInput;
        /// <summary>
        /// The BTN same copy
        /// </summary>
        private System.Windows.Forms.Button btnSameCopy;
        /// <summary>
        /// The rdo BTN with no tax
        /// </summary>
        private System.Windows.Forms.RadioButton rdoBtnWithNoTax;
        /// <summary>
        /// The rdo BTN with tax
        /// </summary>
        private System.Windows.Forms.RadioButton rdoBtnWithTax;
        /// <summary>
        /// The label2
        /// </summary>
        public System.Windows.Forms.Label label2;
        /// <summary>
        /// The connect status label
        /// </summary>
        public System.Windows.Forms.Label ConnectStatusLabel;
        /// <summary>
        /// The device current status
        /// </summary>
        public System.Windows.Forms.Label DeviceCurrentStatus;
        /// <summary>
        /// The g box card entry methods
        /// </summary>
        public System.Windows.Forms.GroupBox gBoxCardEntryMethods;
        /// <summary>
        /// The manual entry checkbox
        /// </summary>
        public System.Windows.Forms.CheckBox ManualEntryCheckbox;
        /// <summary>
        /// The contactless checkbox
        /// </summary>
        public System.Windows.Forms.CheckBox ContactlessCheckbox;
        /// <summary>
        /// The chip checkbox
        /// </summary>
        public System.Windows.Forms.CheckBox ChipCheckbox;
        /// <summary>
        /// The mag stripe checkbox
        /// </summary>
        public System.Windows.Forms.CheckBox MagStripeCheckbox;
        /// <summary>
        /// The BTN reset device
        /// </summary>
        public System.Windows.Forms.Button btnResetDevice;
        /// <summary>
        /// The BTN refund
        /// </summary>
        public System.Windows.Forms.Button btnRefund;
        /// <summary>
        /// The BTN void
        /// </summary>
        public System.Windows.Forms.Button btnVoid;
        /// <summary>
        /// The group box3
        /// </summary>
        public System.Windows.Forms.GroupBox groupBox3;
        /// <summary>
        /// The UI state button panel
        /// </summary>
        public System.Windows.Forms.FlowLayoutPanel UIStateButtonPanel;
    }
}