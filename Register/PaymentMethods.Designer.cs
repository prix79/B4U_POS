// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 02-22-2017
// ***********************************************************************
// <copyright file="PaymentMethods.Designer.cs" company="Beauty4u">
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
    /// Class PaymentMethods.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class PaymentMethods
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentMethods));
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.btnCash = new System.Windows.Forms.Button();
            this.btnTerminal = new System.Windows.Forms.Button();
            this.btnCredit = new System.Windows.Forms.Button();
            this.btnStoreCredit = new System.Windows.Forms.Button();
            this.btnMultiple = new System.Windows.Forms.Button();
            this.btnGiftCard = new System.Windows.Forms.Button();
            this.lblTimer = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.BackColor = System.Drawing.Color.PowderBlue;
            this.lblGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 80F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGrandTotal.ForeColor = System.Drawing.Color.Black;
            this.lblGrandTotal.Location = new System.Drawing.Point(7, 4);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(664, 201);
            this.lblGrandTotal.TabIndex = 0;
            this.lblGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCash
            // 
            this.btnCash.BackColor = System.Drawing.Color.MediumBlue;
            this.btnCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCash.ForeColor = System.Drawing.Color.White;
            this.btnCash.Location = new System.Drawing.Point(7, 209);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(220, 90);
            this.btnCash.TabIndex = 1;
            this.btnCash.Text = "CASH";
            this.btnCash.UseVisualStyleBackColor = false;
            this.btnCash.Click += new System.EventHandler(this.btnCash_Click);
            // 
            // btnTerminal
            // 
            this.btnTerminal.BackColor = System.Drawing.Color.MediumBlue;
            this.btnTerminal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTerminal.ForeColor = System.Drawing.Color.White;
            this.btnTerminal.Location = new System.Drawing.Point(451, 209);
            this.btnTerminal.Name = "btnTerminal";
            this.btnTerminal.Size = new System.Drawing.Size(220, 90);
            this.btnTerminal.TabIndex = 2;
            this.btnTerminal.Text = "CREDIT / DEBIT (TERMINAL)";
            this.btnTerminal.UseVisualStyleBackColor = false;
            this.btnTerminal.Click += new System.EventHandler(this.btnTerminal_Click);
            // 
            // btnCredit
            // 
            this.btnCredit.BackColor = System.Drawing.Color.MediumBlue;
            this.btnCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCredit.ForeColor = System.Drawing.Color.White;
            this.btnCredit.Location = new System.Drawing.Point(229, 209);
            this.btnCredit.Name = "btnCredit";
            this.btnCredit.Size = new System.Drawing.Size(220, 90);
            this.btnCredit.TabIndex = 3;
            this.btnCredit.Text = "CREDIT / DEBIT (CLOVER)";
            this.btnCredit.UseVisualStyleBackColor = false;
            this.btnCredit.Click += new System.EventHandler(this.btnCredit_Click);
            // 
            // btnStoreCredit
            // 
            this.btnStoreCredit.BackColor = System.Drawing.Color.MediumBlue;
            this.btnStoreCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStoreCredit.ForeColor = System.Drawing.Color.White;
            this.btnStoreCredit.Location = new System.Drawing.Point(229, 302);
            this.btnStoreCredit.Name = "btnStoreCredit";
            this.btnStoreCredit.Size = new System.Drawing.Size(220, 90);
            this.btnStoreCredit.TabIndex = 4;
            this.btnStoreCredit.Text = "STORE CREDIT";
            this.btnStoreCredit.UseVisualStyleBackColor = false;
            this.btnStoreCredit.Click += new System.EventHandler(this.btnStoreCredit_Click);
            // 
            // btnMultiple
            // 
            this.btnMultiple.BackColor = System.Drawing.Color.MediumBlue;
            this.btnMultiple.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMultiple.ForeColor = System.Drawing.Color.White;
            this.btnMultiple.Location = new System.Drawing.Point(7, 302);
            this.btnMultiple.Name = "btnMultiple";
            this.btnMultiple.Size = new System.Drawing.Size(220, 90);
            this.btnMultiple.TabIndex = 5;
            this.btnMultiple.Text = "MULTIPLE PAYMENT";
            this.btnMultiple.UseVisualStyleBackColor = false;
            this.btnMultiple.Click += new System.EventHandler(this.btnMultiple_Click);
            // 
            // btnGiftCard
            // 
            this.btnGiftCard.BackColor = System.Drawing.Color.MediumBlue;
            this.btnGiftCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnGiftCard.ForeColor = System.Drawing.Color.White;
            this.btnGiftCard.Location = new System.Drawing.Point(451, 302);
            this.btnGiftCard.Name = "btnGiftCard";
            this.btnGiftCard.Size = new System.Drawing.Size(220, 90);
            this.btnGiftCard.TabIndex = 6;
            this.btnGiftCard.Text = "GIFT CARD";
            this.btnGiftCard.UseVisualStyleBackColor = false;
            this.btnGiftCard.Visible = false;
            this.btnGiftCard.Click += new System.EventHandler(this.btnGiftCard_Click);
            // 
            // lblTimer
            // 
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTimer.Location = new System.Drawing.Point(311, 395);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(360, 90);
            this.lblTimer.TabIndex = 14;
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.MediumBlue;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(7, 395);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(220, 90);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // PaymentMethods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(677, 489);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.btnGiftCard);
            this.Controls.Add(this.btnMultiple);
            this.Controls.Add(this.btnStoreCredit);
            this.Controls.Add(this.btnCredit);
            this.Controls.Add(this.btnTerminal);
            this.Controls.Add(this.btnCash);
            this.Controls.Add(this.lblGrandTotal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaymentMethods";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SELECT PAYMENT METHOD";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PaymentMethods_FormClosed);
            this.Load += new System.EventHandler(this.PaymentMethods_Load);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The label grand total
        /// </summary>
        private System.Windows.Forms.Label lblGrandTotal;
        /// <summary>
        /// The BTN cash
        /// </summary>
        private System.Windows.Forms.Button btnCash;
        /// <summary>
        /// The BTN terminal
        /// </summary>
        private System.Windows.Forms.Button btnTerminal;
        /// <summary>
        /// The BTN credit
        /// </summary>
        private System.Windows.Forms.Button btnCredit;
        /// <summary>
        /// The BTN store credit
        /// </summary>
        private System.Windows.Forms.Button btnStoreCredit;
        /// <summary>
        /// The BTN multiple
        /// </summary>
        private System.Windows.Forms.Button btnMultiple;
        /// <summary>
        /// The BTN gift card
        /// </summary>
        private System.Windows.Forms.Button btnGiftCard;
        /// <summary>
        /// The label timer
        /// </summary>
        private System.Windows.Forms.Label lblTimer;
        /// <summary>
        /// The BTN cancel
        /// </summary>
        private System.Windows.Forms.Button btnCancel;
    }
}