// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 02-05-2018
// ***********************************************************************
// <copyright file="ManagerTools.designer.cs" company="Beauty4u">
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
    /// Class ManagerTools.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class ManagerTools
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagerTools));
            this.btnOpenCashDrawer = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClosingRegister = new System.Windows.Forms.Button();
            this.btnCashWithdraw = new System.Windows.Forms.Button();
            this.btnReturnByReceipt = new System.Windows.Forms.Button();
            this.btnLineNoTax = new System.Windows.Forms.Button();
            this.btnAllNoTax = new System.Windows.Forms.Button();
            this.btnReprint = new System.Windows.Forms.Button();
            this.btnDiscount = new System.Windows.Forms.Button();
            this.btnBasicSetup = new System.Windows.Forms.Button();
            this.btnStartRegister = new System.Windows.Forms.Button();
            this.btnReturnByItem = new System.Windows.Forms.Button();
            this.btnSpecialDiscount = new System.Windows.Forms.Button();
            this.btnReprintStoreCredit = new System.Windows.Forms.Button();
            this.btnCouponGenerate = new System.Windows.Forms.Button();
            this.btnReprintClosingRegister = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnCloverSettlement = new System.Windows.Forms.Button();
            this.btnCloverReset = new System.Windows.Forms.Button();
            this.btnCoupon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenCashDrawer
            // 
            this.btnOpenCashDrawer.BackColor = System.Drawing.Color.MediumBlue;
            this.btnOpenCashDrawer.FlatAppearance.BorderSize = 0;
            this.btnOpenCashDrawer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenCashDrawer.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOpenCashDrawer.ForeColor = System.Drawing.Color.White;
            this.btnOpenCashDrawer.Location = new System.Drawing.Point(227, 236);
            this.btnOpenCashDrawer.Name = "btnOpenCashDrawer";
            this.btnOpenCashDrawer.Size = new System.Drawing.Size(220, 110);
            this.btnOpenCashDrawer.TabIndex = 105;
            this.btnOpenCashDrawer.Text = "OPEN CASH DRAWER";
            this.btnOpenCashDrawer.UseVisualStyleBackColor = false;
            this.btnOpenCashDrawer.Click += new System.EventHandler(this.btnOpenCashDrawer_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.MediumBlue;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(673, 468);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(220, 110);
            this.btnClose.TabIndex = 108;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClosingRegister
            // 
            this.btnClosingRegister.BackColor = System.Drawing.Color.MediumBlue;
            this.btnClosingRegister.FlatAppearance.BorderSize = 0;
            this.btnClosingRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClosingRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClosingRegister.ForeColor = System.Drawing.Color.White;
            this.btnClosingRegister.Location = new System.Drawing.Point(227, 120);
            this.btnClosingRegister.Name = "btnClosingRegister";
            this.btnClosingRegister.Size = new System.Drawing.Size(220, 110);
            this.btnClosingRegister.TabIndex = 104;
            this.btnClosingRegister.Text = "CLOSING REGISTER";
            this.btnClosingRegister.UseVisualStyleBackColor = false;
            this.btnClosingRegister.Click += new System.EventHandler(this.btnClosingRegister_Click);
            // 
            // btnCashWithdraw
            // 
            this.btnCashWithdraw.BackColor = System.Drawing.Color.MediumBlue;
            this.btnCashWithdraw.FlatAppearance.BorderSize = 0;
            this.btnCashWithdraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCashWithdraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCashWithdraw.ForeColor = System.Drawing.Color.White;
            this.btnCashWithdraw.Location = new System.Drawing.Point(227, 352);
            this.btnCashWithdraw.Name = "btnCashWithdraw";
            this.btnCashWithdraw.Size = new System.Drawing.Size(220, 110);
            this.btnCashWithdraw.TabIndex = 106;
            this.btnCashWithdraw.Text = "CASH WITHDRAWAL";
            this.btnCashWithdraw.UseVisualStyleBackColor = false;
            this.btnCashWithdraw.Click += new System.EventHandler(this.btnCashWithdraw_Click);
            // 
            // btnReturnByReceipt
            // 
            this.btnReturnByReceipt.BackColor = System.Drawing.Color.MediumBlue;
            this.btnReturnByReceipt.FlatAppearance.BorderSize = 0;
            this.btnReturnByReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnByReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReturnByReceipt.ForeColor = System.Drawing.Color.White;
            this.btnReturnByReceipt.Location = new System.Drawing.Point(450, 4);
            this.btnReturnByReceipt.Name = "btnReturnByReceipt";
            this.btnReturnByReceipt.Size = new System.Drawing.Size(220, 110);
            this.btnReturnByReceipt.TabIndex = 100;
            this.btnReturnByReceipt.Text = "RETURN BY RECEIPT";
            this.btnReturnByReceipt.UseVisualStyleBackColor = false;
            this.btnReturnByReceipt.Click += new System.EventHandler(this.btnReturnByReceipt_Click);
            // 
            // btnLineNoTax
            // 
            this.btnLineNoTax.BackColor = System.Drawing.Color.MediumBlue;
            this.btnLineNoTax.FlatAppearance.BorderSize = 0;
            this.btnLineNoTax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLineNoTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLineNoTax.ForeColor = System.Drawing.Color.White;
            this.btnLineNoTax.Location = new System.Drawing.Point(4, 352);
            this.btnLineNoTax.Name = "btnLineNoTax";
            this.btnLineNoTax.Size = new System.Drawing.Size(220, 110);
            this.btnLineNoTax.TabIndex = 101;
            this.btnLineNoTax.Text = "LINE NO TAX";
            this.btnLineNoTax.UseVisualStyleBackColor = false;
            this.btnLineNoTax.Click += new System.EventHandler(this.btnLineNoTax_Click);
            // 
            // btnAllNoTax
            // 
            this.btnAllNoTax.BackColor = System.Drawing.Color.MediumBlue;
            this.btnAllNoTax.FlatAppearance.BorderSize = 0;
            this.btnAllNoTax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllNoTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAllNoTax.ForeColor = System.Drawing.Color.White;
            this.btnAllNoTax.Location = new System.Drawing.Point(4, 468);
            this.btnAllNoTax.Name = "btnAllNoTax";
            this.btnAllNoTax.Size = new System.Drawing.Size(220, 110);
            this.btnAllNoTax.TabIndex = 102;
            this.btnAllNoTax.Text = "ALL NO TAX";
            this.btnAllNoTax.UseVisualStyleBackColor = false;
            this.btnAllNoTax.Click += new System.EventHandler(this.btnAllNoTax_Click);
            // 
            // btnReprint
            // 
            this.btnReprint.BackColor = System.Drawing.Color.MediumBlue;
            this.btnReprint.FlatAppearance.BorderSize = 0;
            this.btnReprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReprint.ForeColor = System.Drawing.Color.White;
            this.btnReprint.Location = new System.Drawing.Point(4, 4);
            this.btnReprint.Name = "btnReprint";
            this.btnReprint.Size = new System.Drawing.Size(220, 110);
            this.btnReprint.TabIndex = 107;
            this.btnReprint.Text = "REPRINT RECEIPT";
            this.btnReprint.UseVisualStyleBackColor = false;
            this.btnReprint.Click += new System.EventHandler(this.btnReprintReceipt_Click);
            // 
            // btnDiscount
            // 
            this.btnDiscount.BackColor = System.Drawing.Color.MediumBlue;
            this.btnDiscount.FlatAppearance.BorderSize = 0;
            this.btnDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDiscount.ForeColor = System.Drawing.Color.White;
            this.btnDiscount.Location = new System.Drawing.Point(4, 120);
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.Size = new System.Drawing.Size(220, 110);
            this.btnDiscount.TabIndex = 103;
            this.btnDiscount.Text = "DISCOUNT";
            this.btnDiscount.UseVisualStyleBackColor = false;
            this.btnDiscount.Click += new System.EventHandler(this.btnDiscount_Click);
            // 
            // btnBasicSetup
            // 
            this.btnBasicSetup.BackColor = System.Drawing.Color.MediumBlue;
            this.btnBasicSetup.FlatAppearance.BorderSize = 0;
            this.btnBasicSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBasicSetup.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBasicSetup.ForeColor = System.Drawing.Color.White;
            this.btnBasicSetup.Location = new System.Drawing.Point(227, 468);
            this.btnBasicSetup.Name = "btnBasicSetup";
            this.btnBasicSetup.Size = new System.Drawing.Size(220, 110);
            this.btnBasicSetup.TabIndex = 109;
            this.btnBasicSetup.Text = "BASIC SETUP";
            this.btnBasicSetup.UseVisualStyleBackColor = false;
            this.btnBasicSetup.Click += new System.EventHandler(this.btnBasicSetup_Click);
            // 
            // btnStartRegister
            // 
            this.btnStartRegister.BackColor = System.Drawing.Color.MediumBlue;
            this.btnStartRegister.FlatAppearance.BorderSize = 0;
            this.btnStartRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStartRegister.ForeColor = System.Drawing.Color.White;
            this.btnStartRegister.Location = new System.Drawing.Point(227, 4);
            this.btnStartRegister.Name = "btnStartRegister";
            this.btnStartRegister.Size = new System.Drawing.Size(220, 110);
            this.btnStartRegister.TabIndex = 110;
            this.btnStartRegister.Text = "START REGISTER";
            this.btnStartRegister.UseVisualStyleBackColor = false;
            this.btnStartRegister.Click += new System.EventHandler(this.btnStartRegister_Click);
            // 
            // btnReturnByItem
            // 
            this.btnReturnByItem.BackColor = System.Drawing.Color.MediumBlue;
            this.btnReturnByItem.FlatAppearance.BorderSize = 0;
            this.btnReturnByItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnByItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReturnByItem.ForeColor = System.Drawing.Color.White;
            this.btnReturnByItem.Location = new System.Drawing.Point(450, 120);
            this.btnReturnByItem.Name = "btnReturnByItem";
            this.btnReturnByItem.Size = new System.Drawing.Size(220, 110);
            this.btnReturnByItem.TabIndex = 111;
            this.btnReturnByItem.Text = "RETURN BY ITEM";
            this.btnReturnByItem.UseVisualStyleBackColor = false;
            this.btnReturnByItem.Click += new System.EventHandler(this.btnReturnByItem_Click);
            // 
            // btnSpecialDiscount
            // 
            this.btnSpecialDiscount.BackColor = System.Drawing.Color.MediumBlue;
            this.btnSpecialDiscount.FlatAppearance.BorderSize = 0;
            this.btnSpecialDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpecialDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSpecialDiscount.ForeColor = System.Drawing.Color.White;
            this.btnSpecialDiscount.Location = new System.Drawing.Point(4, 236);
            this.btnSpecialDiscount.Name = "btnSpecialDiscount";
            this.btnSpecialDiscount.Size = new System.Drawing.Size(220, 110);
            this.btnSpecialDiscount.TabIndex = 112;
            this.btnSpecialDiscount.Text = "SPECIAL DISCOUNT";
            this.btnSpecialDiscount.UseVisualStyleBackColor = false;
            this.btnSpecialDiscount.Click += new System.EventHandler(this.btnSpecialDiscount_Click);
            // 
            // btnReprintStoreCredit
            // 
            this.btnReprintStoreCredit.BackColor = System.Drawing.Color.MediumBlue;
            this.btnReprintStoreCredit.FlatAppearance.BorderSize = 0;
            this.btnReprintStoreCredit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReprintStoreCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReprintStoreCredit.ForeColor = System.Drawing.Color.White;
            this.btnReprintStoreCredit.Location = new System.Drawing.Point(450, 236);
            this.btnReprintStoreCredit.Name = "btnReprintStoreCredit";
            this.btnReprintStoreCredit.Size = new System.Drawing.Size(220, 110);
            this.btnReprintStoreCredit.TabIndex = 113;
            this.btnReprintStoreCredit.Text = "REPRINT STORE CREDIT";
            this.btnReprintStoreCredit.UseVisualStyleBackColor = false;
            this.btnReprintStoreCredit.Click += new System.EventHandler(this.btnReprintStoreCredit_Click);
            // 
            // btnCouponGenerate
            // 
            this.btnCouponGenerate.BackColor = System.Drawing.Color.MediumBlue;
            this.btnCouponGenerate.FlatAppearance.BorderSize = 0;
            this.btnCouponGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCouponGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCouponGenerate.ForeColor = System.Drawing.Color.White;
            this.btnCouponGenerate.Location = new System.Drawing.Point(673, 236);
            this.btnCouponGenerate.Name = "btnCouponGenerate";
            this.btnCouponGenerate.Size = new System.Drawing.Size(220, 110);
            this.btnCouponGenerate.TabIndex = 116;
            this.btnCouponGenerate.Text = "COUPON GENERATE";
            this.btnCouponGenerate.UseVisualStyleBackColor = false;
            this.btnCouponGenerate.Visible = false;
            this.btnCouponGenerate.Click += new System.EventHandler(this.btnCouponGenerate_Click);
            // 
            // btnReprintClosingRegister
            // 
            this.btnReprintClosingRegister.BackColor = System.Drawing.Color.MediumBlue;
            this.btnReprintClosingRegister.Enabled = false;
            this.btnReprintClosingRegister.FlatAppearance.BorderSize = 0;
            this.btnReprintClosingRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReprintClosingRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReprintClosingRegister.ForeColor = System.Drawing.Color.White;
            this.btnReprintClosingRegister.Location = new System.Drawing.Point(450, 352);
            this.btnReprintClosingRegister.Name = "btnReprintClosingRegister";
            this.btnReprintClosingRegister.Size = new System.Drawing.Size(220, 110);
            this.btnReprintClosingRegister.TabIndex = 117;
            this.btnReprintClosingRegister.Text = "REPRINT REGISTER TRANSACTION";
            this.btnReprintClosingRegister.UseVisualStyleBackColor = false;
            this.btnReprintClosingRegister.Visible = false;
            this.btnReprintClosingRegister.Click += new System.EventHandler(this.btnReprintClosingRegister_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.BackColor = System.Drawing.Color.MediumBlue;
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAbout.ForeColor = System.Drawing.Color.White;
            this.btnAbout.Location = new System.Drawing.Point(673, 352);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(220, 110);
            this.btnAbout.TabIndex = 118;
            this.btnAbout.Text = "ABOUT";
            this.btnAbout.UseVisualStyleBackColor = false;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnCloverSettlement
            // 
            this.btnCloverSettlement.BackColor = System.Drawing.Color.MediumBlue;
            this.btnCloverSettlement.FlatAppearance.BorderSize = 0;
            this.btnCloverSettlement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloverSettlement.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCloverSettlement.ForeColor = System.Drawing.Color.White;
            this.btnCloverSettlement.Location = new System.Drawing.Point(673, 4);
            this.btnCloverSettlement.Name = "btnCloverSettlement";
            this.btnCloverSettlement.Size = new System.Drawing.Size(220, 110);
            this.btnCloverSettlement.TabIndex = 119;
            this.btnCloverSettlement.Text = "CLOVER SETTLEMENT";
            this.btnCloverSettlement.UseVisualStyleBackColor = false;
            this.btnCloverSettlement.Click += new System.EventHandler(this.btnCloverSettlement_Click);
            // 
            // btnCloverReset
            // 
            this.btnCloverReset.BackColor = System.Drawing.Color.MediumBlue;
            this.btnCloverReset.FlatAppearance.BorderSize = 0;
            this.btnCloverReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloverReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCloverReset.ForeColor = System.Drawing.Color.White;
            this.btnCloverReset.Location = new System.Drawing.Point(673, 120);
            this.btnCloverReset.Name = "btnCloverReset";
            this.btnCloverReset.Size = new System.Drawing.Size(220, 110);
            this.btnCloverReset.TabIndex = 120;
            this.btnCloverReset.Text = "CLOVER DEVICE RESET";
            this.btnCloverReset.UseVisualStyleBackColor = false;
            this.btnCloverReset.Click += new System.EventHandler(this.btnCloverReset_Click);
            // 
            // btnCoupon
            // 
            this.btnCoupon.BackColor = System.Drawing.Color.MediumBlue;
            this.btnCoupon.FlatAppearance.BorderSize = 0;
            this.btnCoupon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCoupon.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCoupon.ForeColor = System.Drawing.Color.White;
            this.btnCoupon.Location = new System.Drawing.Point(450, 468);
            this.btnCoupon.Name = "btnCoupon";
            this.btnCoupon.Size = new System.Drawing.Size(220, 110);
            this.btnCoupon.TabIndex = 121;
            this.btnCoupon.Text = "COUPON";
            this.btnCoupon.UseVisualStyleBackColor = false;
            this.btnCoupon.Click += new System.EventHandler(this.btnCoupon_Click);
            // 
            // ManagerTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(896, 585);
            this.ControlBox = false;
            this.Controls.Add(this.btnCoupon);
            this.Controls.Add(this.btnCloverReset);
            this.Controls.Add(this.btnCloverSettlement);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnReprintClosingRegister);
            this.Controls.Add(this.btnCouponGenerate);
            this.Controls.Add(this.btnReprintStoreCredit);
            this.Controls.Add(this.btnSpecialDiscount);
            this.Controls.Add(this.btnReturnByItem);
            this.Controls.Add(this.btnStartRegister);
            this.Controls.Add(this.btnBasicSetup);
            this.Controls.Add(this.btnDiscount);
            this.Controls.Add(this.btnReprint);
            this.Controls.Add(this.btnAllNoTax);
            this.Controls.Add(this.btnLineNoTax);
            this.Controls.Add(this.btnReturnByReceipt);
            this.Controls.Add(this.btnCashWithdraw);
            this.Controls.Add(this.btnClosingRegister);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOpenCashDrawer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManagerTools";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MANAGER TOOLS";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ManagerTools_Load);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The BTN open cash drawer
        /// </summary>
        private System.Windows.Forms.Button btnOpenCashDrawer;
        /// <summary>
        /// The BTN close
        /// </summary>
        private System.Windows.Forms.Button btnClose;
        /// <summary>
        /// The BTN closing register
        /// </summary>
        private System.Windows.Forms.Button btnClosingRegister;
        /// <summary>
        /// The BTN cash withdraw
        /// </summary>
        private System.Windows.Forms.Button btnCashWithdraw;
        /// <summary>
        /// The BTN return by receipt
        /// </summary>
        private System.Windows.Forms.Button btnReturnByReceipt;
        /// <summary>
        /// The BTN line no tax
        /// </summary>
        private System.Windows.Forms.Button btnLineNoTax;
        /// <summary>
        /// The BTN all no tax
        /// </summary>
        private System.Windows.Forms.Button btnAllNoTax;
        /// <summary>
        /// The BTN discount
        /// </summary>
        private System.Windows.Forms.Button btnDiscount;
        /// <summary>
        /// The BTN basic setup
        /// </summary>
        private System.Windows.Forms.Button btnBasicSetup;
        /// <summary>
        /// The BTN start register
        /// </summary>
        private System.Windows.Forms.Button btnStartRegister;
        /// <summary>
        /// The BTN return by item
        /// </summary>
        private System.Windows.Forms.Button btnReturnByItem;
        /// <summary>
        /// The BTN special discount
        /// </summary>
        private System.Windows.Forms.Button btnSpecialDiscount;
        /// <summary>
        /// The BTN reprint store credit
        /// </summary>
        private System.Windows.Forms.Button btnReprintStoreCredit;
        /// <summary>
        /// The BTN coupon generate
        /// </summary>
        private System.Windows.Forms.Button btnCouponGenerate;
        /// <summary>
        /// The BTN reprint closing register
        /// </summary>
        private System.Windows.Forms.Button btnReprintClosingRegister;
        /// <summary>
        /// The BTN about
        /// </summary>
        private System.Windows.Forms.Button btnAbout;
        /// <summary>
        /// The BTN clover settlement
        /// </summary>
        private System.Windows.Forms.Button btnCloverSettlement;
        /// <summary>
        /// The BTN clover reset
        /// </summary>
        private System.Windows.Forms.Button btnCloverReset;
        /// <summary>
        /// The BTN reprint
        /// </summary>
        private System.Windows.Forms.Button btnReprint;
        private System.Windows.Forms.Button btnCoupon;
    }
}