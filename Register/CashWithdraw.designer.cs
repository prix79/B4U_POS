// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 11-25-2014
// ***********************************************************************
// <copyright file="CashWithdraw.designer.cs" company="Beauty4u">
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
    /// Class CashWithdraw.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class CashWithdraw
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashWithdraw));
            this.txtWithdraw = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPsw = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.txtManagerID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtWithdraw
            // 
            this.txtWithdraw.BackColor = System.Drawing.Color.MediumBlue;
            this.txtWithdraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtWithdraw.ForeColor = System.Drawing.Color.White;
            this.txtWithdraw.Location = new System.Drawing.Point(221, 188);
            this.txtWithdraw.Name = "txtWithdraw";
            this.txtWithdraw.Size = new System.Drawing.Size(150, 90);
            this.txtWithdraw.TabIndex = 0;
            this.txtWithdraw.Text = "WITHDRAW";
            this.txtWithdraw.UseVisualStyleBackColor = false;
            this.txtWithdraw.Click += new System.EventHandler(this.txtWithdraw_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtAmount.Location = new System.Drawing.Point(221, 11);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(305, 56);
            this.txtAmount.TabIndex = 1;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Click += new System.EventHandler(this.txtAmount_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(5, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 56);
            this.label1.TabIndex = 2;
            this.label1.Text = "AMOUNT";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Maroon;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(5, 124);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(216, 50);
            this.label14.TabIndex = 59;
            this.label14.Text = "PASSWORD";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPsw
            // 
            this.txtPsw.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPsw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPsw.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPsw.Location = new System.Drawing.Point(221, 124);
            this.txtPsw.Name = "txtPsw";
            this.txtPsw.PasswordChar = '*';
            this.txtPsw.Size = new System.Drawing.Size(305, 50);
            this.txtPsw.TabIndex = 58;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Maroon;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(5, 71);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(216, 50);
            this.label13.TabIndex = 56;
            this.label13.Text = "MANAGER ID";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.MediumBlue;
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmdCancel.ForeColor = System.Drawing.Color.Red;
            this.cmdCancel.Location = new System.Drawing.Point(376, 188);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(150, 90);
            this.cmdCancel.TabIndex = 60;
            this.cmdCancel.Text = "CANCEL";
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // txtManagerID
            // 
            this.txtManagerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtManagerID.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtManagerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtManagerID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtManagerID.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtManagerID.Location = new System.Drawing.Point(221, 71);
            this.txtManagerID.Name = "txtManagerID";
            this.txtManagerID.Size = new System.Drawing.Size(305, 50);
            this.txtManagerID.TabIndex = 57;
            // 
            // CashWithdraw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(530, 293);
            this.ControlBox = false;
            this.Controls.Add(this.txtManagerID);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtPsw);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtWithdraw);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CashWithdraw";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CASH WITHDRAWAL";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.CashWithdraw_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /// <summary>
        /// The text withdraw
        /// </summary>
        private System.Windows.Forms.Button txtWithdraw;
        /// <summary>
        /// The text amount
        /// </summary>
        private System.Windows.Forms.TextBox txtAmount;
        /// <summary>
        /// The label1
        /// </summary>
        private System.Windows.Forms.Label label1;
        /// <summary>
        /// The label14
        /// </summary>
        private System.Windows.Forms.Label label14;
        /// <summary>
        /// The text PSW
        /// </summary>
        private System.Windows.Forms.TextBox txtPsw;
        /// <summary>
        /// The label13
        /// </summary>
        private System.Windows.Forms.Label label13;
        /// <summary>
        /// The command cancel
        /// </summary>
        private System.Windows.Forms.Button cmdCancel;
        /// <summary>
        /// The text manager identifier
        /// </summary>
        private System.Windows.Forms.TextBox txtManagerID;
    }
}