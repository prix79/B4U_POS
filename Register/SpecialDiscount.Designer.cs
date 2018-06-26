// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 02-11-2011
// ***********************************************************************
// <copyright file="SpecialDiscount.Designer.cs" company="Beauty4u">
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
    /// Class SpecialDiscount.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class SpecialDiscount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpecialDiscount));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnTotalOK = new System.Windows.Forms.Button();
            this.btnLineOK = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtLine = new System.Windows.Forms.TextBox();
            this.radioBtnTotal = new System.Windows.Forms.RadioButton();
            this.radioBtnLine = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtMoneyOff = new System.Windows.Forms.TextBox();
            this.lblFinalPrice = new System.Windows.Forms.Label();
            this.lblDiscountPrice = new System.Windows.Forms.Label();
            this.lblTitleFinalPrice = new System.Windows.Forms.Label();
            this.lblTitleMoneyOff = new System.Windows.Forms.Label();
            this.lblTitleDiscountPrice = new System.Windows.Forms.Label();
            this.btnclose = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
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
            this.groupBox4.Location = new System.Drawing.Point(12, 257);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(347, 133);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "MANUAL DISCOUNT OPTIONS";
            // 
            // btnTotalOK
            // 
            this.btnTotalOK.BackColor = System.Drawing.Color.MediumBlue;
            this.btnTotalOK.Enabled = false;
            this.btnTotalOK.ForeColor = System.Drawing.Color.White;
            this.btnTotalOK.Location = new System.Drawing.Point(244, 79);
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
            this.btnLineOK.Location = new System.Drawing.Point(244, 29);
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
            this.txtTotal.Location = new System.Drawing.Point(145, 80);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(95, 38);
            this.txtTotal.TabIndex = 3;
            // 
            // txtLine
            // 
            this.txtLine.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLine.Location = new System.Drawing.Point(145, 29);
            this.txtLine.Name = "txtLine";
            this.txtLine.Size = new System.Drawing.Size(95, 38);
            this.txtLine.TabIndex = 2;
            // 
            // radioBtnTotal
            // 
            this.radioBtnTotal.AutoSize = true;
            this.radioBtnTotal.Enabled = false;
            this.radioBtnTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.radioBtnTotal.Location = new System.Drawing.Point(14, 82);
            this.radioBtnTotal.Name = "radioBtnTotal";
            this.radioBtnTotal.Size = new System.Drawing.Size(127, 29);
            this.radioBtnTotal.TabIndex = 1;
            this.radioBtnTotal.Text = "TOTAL %";
            this.radioBtnTotal.UseVisualStyleBackColor = true;
            // 
            // radioBtnLine
            // 
            this.radioBtnLine.AutoSize = true;
            this.radioBtnLine.Checked = true;
            this.radioBtnLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.radioBtnLine.Location = new System.Drawing.Point(14, 32);
            this.radioBtnLine.Name = "radioBtnLine";
            this.radioBtnLine.Size = new System.Drawing.Size(102, 29);
            this.radioBtnLine.TabIndex = 0;
            this.radioBtnLine.TabStop = true;
            this.radioBtnLine.Text = "LINE %";
            this.radioBtnLine.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.PaleGreen;
            this.groupBox3.Controls.Add(this.btnOK);
            this.groupBox3.Controls.Add(this.txtMoneyOff);
            this.groupBox3.Controls.Add(this.lblFinalPrice);
            this.groupBox3.Controls.Add(this.lblDiscountPrice);
            this.groupBox3.Controls.Add(this.lblTitleFinalPrice);
            this.groupBox3.Controls.Add(this.lblTitleMoneyOff);
            this.groupBox3.Controls.Add(this.lblTitleDiscountPrice);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(347, 231);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "LINE MONEY OFF";
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.MediumBlue;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(172, 174);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(165, 45);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtMoneyOff
            // 
            this.txtMoneyOff.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMoneyOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMoneyOff.Location = new System.Drawing.Point(172, 70);
            this.txtMoneyOff.Name = "txtMoneyOff";
            this.txtMoneyOff.Size = new System.Drawing.Size(165, 45);
            this.txtMoneyOff.TabIndex = 5;
            this.txtMoneyOff.Text = "0.00";
            this.txtMoneyOff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMoneyOff.TextChanged += new System.EventHandler(this.txtMoneyOff_TextChanged);
            // 
            // lblFinalPrice
            // 
            this.lblFinalPrice.BackColor = System.Drawing.Color.Maroon;
            this.lblFinalPrice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFinalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblFinalPrice.ForeColor = System.Drawing.Color.White;
            this.lblFinalPrice.Location = new System.Drawing.Point(172, 122);
            this.lblFinalPrice.Name = "lblFinalPrice";
            this.lblFinalPrice.Size = new System.Drawing.Size(165, 45);
            this.lblFinalPrice.TabIndex = 4;
            this.lblFinalPrice.Text = "$0.00";
            this.lblFinalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDiscountPrice
            // 
            this.lblDiscountPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblDiscountPrice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDiscountPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDiscountPrice.ForeColor = System.Drawing.Color.Black;
            this.lblDiscountPrice.Location = new System.Drawing.Point(172, 18);
            this.lblDiscountPrice.Name = "lblDiscountPrice";
            this.lblDiscountPrice.Size = new System.Drawing.Size(165, 45);
            this.lblDiscountPrice.TabIndex = 3;
            this.lblDiscountPrice.Text = "$0.00";
            this.lblDiscountPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitleFinalPrice
            // 
            this.lblTitleFinalPrice.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitleFinalPrice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleFinalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleFinalPrice.ForeColor = System.Drawing.Color.Black;
            this.lblTitleFinalPrice.Location = new System.Drawing.Point(11, 122);
            this.lblTitleFinalPrice.Name = "lblTitleFinalPrice";
            this.lblTitleFinalPrice.Size = new System.Drawing.Size(155, 45);
            this.lblTitleFinalPrice.TabIndex = 2;
            this.lblTitleFinalPrice.Text = "FINAL PRICE (EA)";
            this.lblTitleFinalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitleMoneyOff
            // 
            this.lblTitleMoneyOff.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitleMoneyOff.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleMoneyOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleMoneyOff.ForeColor = System.Drawing.Color.Black;
            this.lblTitleMoneyOff.Location = new System.Drawing.Point(11, 70);
            this.lblTitleMoneyOff.Name = "lblTitleMoneyOff";
            this.lblTitleMoneyOff.Size = new System.Drawing.Size(155, 45);
            this.lblTitleMoneyOff.TabIndex = 1;
            this.lblTitleMoneyOff.Text = "MONEY OFF (EA)";
            this.lblTitleMoneyOff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitleDiscountPrice
            // 
            this.lblTitleDiscountPrice.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitleDiscountPrice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleDiscountPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleDiscountPrice.ForeColor = System.Drawing.Color.Black;
            this.lblTitleDiscountPrice.Location = new System.Drawing.Point(11, 18);
            this.lblTitleDiscountPrice.Name = "lblTitleDiscountPrice";
            this.lblTitleDiscountPrice.Size = new System.Drawing.Size(155, 45);
            this.lblTitleDiscountPrice.TabIndex = 0;
            this.lblTitleDiscountPrice.Text = "DISCOUNT PRICE (EA)";
            this.lblTitleDiscountPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.Red;
            this.btnclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnclose.Location = new System.Drawing.Point(12, 404);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(347, 60);
            this.btnclose.TabIndex = 12;
            this.btnclose.Text = "CLOSE";
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // SpecialDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(369, 476);
            this.ControlBox = false;
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SpecialDiscount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SPECIAL DISCOUNT";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SpecialDiscount_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

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
        /// The group box3
        /// </summary>
        private System.Windows.Forms.GroupBox groupBox3;
        /// <summary>
        /// The BTN ok
        /// </summary>
        private System.Windows.Forms.Button btnOK;
        /// <summary>
        /// The text money off
        /// </summary>
        private System.Windows.Forms.TextBox txtMoneyOff;
        /// <summary>
        /// The label final price
        /// </summary>
        private System.Windows.Forms.Label lblFinalPrice;
        /// <summary>
        /// The label discount price
        /// </summary>
        private System.Windows.Forms.Label lblDiscountPrice;
        /// <summary>
        /// The label title final price
        /// </summary>
        private System.Windows.Forms.Label lblTitleFinalPrice;
        /// <summary>
        /// The label title money off
        /// </summary>
        private System.Windows.Forms.Label lblTitleMoneyOff;
        /// <summary>
        /// The label title discount price
        /// </summary>
        private System.Windows.Forms.Label lblTitleDiscountPrice;
        /// <summary>
        /// The btnclose
        /// </summary>
        private System.Windows.Forms.Button btnclose;
    }
}