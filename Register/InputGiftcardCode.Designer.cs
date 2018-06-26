// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 12-12-2014
// ***********************************************************************
// <copyright file="InputGiftcardCode.Designer.cs" company="Beauty4u">
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
    /// Class InputGiftcardCode.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class InputGiftcardCode
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
            this.richtxtGiftcardCode = new System.Windows.Forms.RichTextBox();
            this.lblGiftcardCode = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnInput = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richtxtGiftcardCode
            // 
            this.richtxtGiftcardCode.BackColor = System.Drawing.Color.White;
            this.richtxtGiftcardCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.richtxtGiftcardCode.ForeColor = System.Drawing.Color.Black;
            this.richtxtGiftcardCode.Location = new System.Drawing.Point(9, 67);
            this.richtxtGiftcardCode.Multiline = false;
            this.richtxtGiftcardCode.Name = "richtxtGiftcardCode";
            this.richtxtGiftcardCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.richtxtGiftcardCode.Size = new System.Drawing.Size(315, 57);
            this.richtxtGiftcardCode.TabIndex = 155;
            this.richtxtGiftcardCode.Text = "";
            // 
            // lblGiftcardCode
            // 
            this.lblGiftcardCode.BackColor = System.Drawing.Color.White;
            this.lblGiftcardCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblGiftcardCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGiftcardCode.ForeColor = System.Drawing.Color.Black;
            this.lblGiftcardCode.Location = new System.Drawing.Point(9, 9);
            this.lblGiftcardCode.Name = "lblGiftcardCode";
            this.lblGiftcardCode.Size = new System.Drawing.Size(315, 57);
            this.lblGiftcardCode.TabIndex = 154;
            this.lblGiftcardCode.Text = "GIFTCARD CODE";
            this.lblGiftcardCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.Location = new System.Drawing.Point(174, 130);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 67);
            this.btnCancel.TabIndex = 158;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnInput
            // 
            this.btnInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnInput.Location = new System.Drawing.Point(9, 130);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(150, 67);
            this.btnInput.TabIndex = 157;
            this.btnInput.Text = "INPUT";
            this.btnInput.UseVisualStyleBackColor = false;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // InputGiftcardCode
            // 
            this.AcceptButton = this.btnInput;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(334, 204);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.richtxtGiftcardCode);
            this.Controls.Add(this.lblGiftcardCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputGiftcardCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INPUT GIFTCARDCODE";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.InputGiftcardCode_Load);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The richtxt giftcard code
        /// </summary>
        private System.Windows.Forms.RichTextBox richtxtGiftcardCode;
        /// <summary>
        /// The label giftcard code
        /// </summary>
        private System.Windows.Forms.Label lblGiftcardCode;
        /// <summary>
        /// The BTN cancel
        /// </summary>
        private System.Windows.Forms.Button btnCancel;
        /// <summary>
        /// The BTN input
        /// </summary>
        private System.Windows.Forms.Button btnInput;
    }
}