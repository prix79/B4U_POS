// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 05-06-2016
// ***********************************************************************
// <copyright file="CouponRedeem.Designer.cs" company="Beauty4u">
//     Copyright © Beauty4u 2009
// </copyright>
// <summary></summary>
// ***********************************************************************
/// <summary>
/// The Register namespace.
/// </summary>
namespace Register
{
    partial class CouponRedeem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CouponRedeem));
            this.txtCouponNum = new System.Windows.Forms.TextBox();
            this.lblTitlePay = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRedeem = new System.Windows.Forms.Button();
            this.btnSMCouponRedeem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCouponNum
            // 
            this.txtCouponNum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCouponNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtCouponNum.Location = new System.Drawing.Point(12, 67);
            this.txtCouponNum.Name = "txtCouponNum";
            this.txtCouponNum.Size = new System.Drawing.Size(366, 56);
            this.txtCouponNum.TabIndex = 179;
            // 
            // lblTitlePay
            // 
            this.lblTitlePay.BackColor = System.Drawing.Color.White;
            this.lblTitlePay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitlePay.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitlePay.ForeColor = System.Drawing.Color.Black;
            this.lblTitlePay.Location = new System.Drawing.Point(12, 9);
            this.lblTitlePay.Name = "lblTitlePay";
            this.lblTitlePay.Size = new System.Drawing.Size(366, 57);
            this.lblTitlePay.TabIndex = 178;
            this.lblTitlePay.Text = "INPUT COUPON NUMBER";
            this.lblTitlePay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(198, 129);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(180, 60);
            this.btnCancel.TabIndex = 182;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRedeem
            // 
            this.btnRedeem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnRedeem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRedeem.ForeColor = System.Drawing.Color.Black;
            this.btnRedeem.Location = new System.Drawing.Point(12, 129);
            this.btnRedeem.Name = "btnRedeem";
            this.btnRedeem.Size = new System.Drawing.Size(180, 60);
            this.btnRedeem.TabIndex = 181;
            this.btnRedeem.Text = "REDEEM";
            this.btnRedeem.UseVisualStyleBackColor = false;
            this.btnRedeem.Visible = false;
            this.btnRedeem.Click += new System.EventHandler(this.btnRedeem_Click);
            // 
            // btnSMCouponRedeem
            // 
            this.btnSMCouponRedeem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSMCouponRedeem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSMCouponRedeem.ForeColor = System.Drawing.Color.Black;
            this.btnSMCouponRedeem.Location = new System.Drawing.Point(12, 129);
            this.btnSMCouponRedeem.Name = "btnSMCouponRedeem";
            this.btnSMCouponRedeem.Size = new System.Drawing.Size(180, 60);
            this.btnSMCouponRedeem.TabIndex = 183;
            this.btnSMCouponRedeem.Text = "REDEEM";
            this.btnSMCouponRedeem.UseVisualStyleBackColor = false;
            this.btnSMCouponRedeem.Click += new System.EventHandler(this.btnSMCouponRedeem_Click);
            // 
            // CouponRedeem
            // 
            this.AcceptButton = this.btnRedeem;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(389, 200);
            this.ControlBox = false;
            this.Controls.Add(this.btnSMCouponRedeem);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRedeem);
            this.Controls.Add(this.txtCouponNum);
            this.Controls.Add(this.lblTitlePay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CouponRedeem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "COUPON REDEEM";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.CouponRedeem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /// <summary>
        /// The text coupon number
        /// </summary>
        private System.Windows.Forms.TextBox txtCouponNum;
        /// <summary>
        /// The label title pay
        /// </summary>
        private System.Windows.Forms.Label lblTitlePay;
        /// <summary>
        /// The BTN cancel
        /// </summary>
        private System.Windows.Forms.Button btnCancel;
        /// <summary>
        /// The BTN redeem
        /// </summary>
        private System.Windows.Forms.Button btnRedeem;
        /// <summary>
        /// The BTN sm coupon redeem
        /// </summary>
        private System.Windows.Forms.Button btnSMCouponRedeem;
        /// <summary>
        /// Class CouponRedeem.
        /// </summary>
        /// <seealso cref="System.Windows.Forms.Form" />
    }
}