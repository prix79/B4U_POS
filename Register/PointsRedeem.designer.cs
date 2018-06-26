// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 04-20-2010
// ***********************************************************************
// <copyright file="PointsRedeem.designer.cs" company="Beauty4u">
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
    /// Class PointsRedeem.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class PointsRedeem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PointsRedeem));
            this.lblType = new System.Windows.Forms.Label();
            this.lblTitleType = new System.Windows.Forms.Label();
            this.lblPoints = new System.Windows.Forms.Label();
            this.lblTitlePoints = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblTitleName = new System.Windows.Forms.Label();
            this.lblMemberCode = new System.Windows.Forms.Label();
            this.lblTitleMemberCode = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.radioBtnAllPoints = new System.Windows.Forms.RadioButton();
            this.radioBtnInputPoints = new System.Windows.Forms.RadioButton();
            this.btnRedeem = new System.Windows.Forms.Button();
            this.txtPoints = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblType
            // 
            this.lblType.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblType.ForeColor = System.Drawing.Color.Black;
            this.lblType.Location = new System.Drawing.Point(133, 137);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(249, 50);
            this.lblType.TabIndex = 18;
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitleType
            // 
            this.lblTitleType.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitleType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleType.ForeColor = System.Drawing.Color.Red;
            this.lblTitleType.Location = new System.Drawing.Point(9, 137);
            this.lblTitleType.Name = "lblTitleType";
            this.lblTitleType.Size = new System.Drawing.Size(124, 50);
            this.lblTitleType.TabIndex = 17;
            this.lblTitleType.Text = "MEMBER TYPE";
            this.lblTitleType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPoints
            // 
            this.lblPoints.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblPoints.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPoints.ForeColor = System.Drawing.Color.Black;
            this.lblPoints.Location = new System.Drawing.Point(133, 187);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(249, 50);
            this.lblPoints.TabIndex = 16;
            this.lblPoints.Text = "$0.00";
            this.lblPoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitlePoints
            // 
            this.lblTitlePoints.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitlePoints.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitlePoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitlePoints.ForeColor = System.Drawing.Color.Red;
            this.lblTitlePoints.Location = new System.Drawing.Point(9, 187);
            this.lblTitlePoints.Name = "lblTitlePoints";
            this.lblTitlePoints.Size = new System.Drawing.Size(124, 50);
            this.lblTitlePoints.TabIndex = 15;
            this.lblTitlePoints.Text = "POINTS";
            this.lblTitlePoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(133, 87);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(249, 50);
            this.lblName.TabIndex = 14;
            this.lblName.Text = "WALK IN";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitleName
            // 
            this.lblTitleName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitleName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleName.ForeColor = System.Drawing.Color.Red;
            this.lblTitleName.Location = new System.Drawing.Point(9, 87);
            this.lblTitleName.Name = "lblTitleName";
            this.lblTitleName.Size = new System.Drawing.Size(124, 50);
            this.lblTitleName.TabIndex = 13;
            this.lblTitleName.Text = "NAME";
            this.lblTitleName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMemberCode
            // 
            this.lblMemberCode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblMemberCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMemberCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMemberCode.ForeColor = System.Drawing.Color.Black;
            this.lblMemberCode.Location = new System.Drawing.Point(133, 37);
            this.lblMemberCode.Name = "lblMemberCode";
            this.lblMemberCode.Size = new System.Drawing.Size(249, 50);
            this.lblMemberCode.TabIndex = 12;
            this.lblMemberCode.Text = "101";
            this.lblMemberCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitleMemberCode
            // 
            this.lblTitleMemberCode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitleMemberCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleMemberCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleMemberCode.ForeColor = System.Drawing.Color.Red;
            this.lblTitleMemberCode.Location = new System.Drawing.Point(9, 37);
            this.lblTitleMemberCode.Name = "lblTitleMemberCode";
            this.lblTitleMemberCode.Size = new System.Drawing.Size(124, 50);
            this.lblTitleMemberCode.TabIndex = 11;
            this.lblTitleMemberCode.Text = "MEMBER CODE";
            this.lblTitleMemberCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PaleGreen;
            this.groupBox1.Controls.Add(this.lblType);
            this.groupBox1.Controls.Add(this.lblTitleMemberCode);
            this.groupBox1.Controls.Add(this.lblTitleType);
            this.groupBox1.Controls.Add(this.lblMemberCode);
            this.groupBox1.Controls.Add(this.lblPoints);
            this.groupBox1.Controls.Add(this.lblTitleName);
            this.groupBox1.Controls.Add(this.lblTitlePoints);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(10, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(391, 249);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MEMBER INFORMATION";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.PaleGreen;
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.radioBtnAllPoints);
            this.groupBox2.Controls.Add(this.radioBtnInputPoints);
            this.groupBox2.Controls.Add(this.btnRedeem);
            this.groupBox2.Controls.Add(this.txtPoints);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(10, 262);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(391, 238);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "REDEEM OPTIONS";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(202, 160);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(180, 60);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // radioBtnAllPoints
            // 
            this.radioBtnAllPoints.AutoSize = true;
            this.radioBtnAllPoints.BackColor = System.Drawing.Color.PaleGreen;
            this.radioBtnAllPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.radioBtnAllPoints.Location = new System.Drawing.Point(9, 95);
            this.radioBtnAllPoints.Name = "radioBtnAllPoints";
            this.radioBtnAllPoints.Size = new System.Drawing.Size(199, 35);
            this.radioBtnAllPoints.TabIndex = 0;
            this.radioBtnAllPoints.Text = "ALL POINTS";
            this.radioBtnAllPoints.UseVisualStyleBackColor = false;
            this.radioBtnAllPoints.CheckedChanged += new System.EventHandler(this.radioBtnAllPoints_CheckedChanged);
            // 
            // radioBtnInputPoints
            // 
            this.radioBtnInputPoints.AutoSize = true;
            this.radioBtnInputPoints.BackColor = System.Drawing.Color.PaleGreen;
            this.radioBtnInputPoints.Checked = true;
            this.radioBtnInputPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.radioBtnInputPoints.Location = new System.Drawing.Point(9, 41);
            this.radioBtnInputPoints.Name = "radioBtnInputPoints";
            this.radioBtnInputPoints.Size = new System.Drawing.Size(236, 35);
            this.radioBtnInputPoints.TabIndex = 1;
            this.radioBtnInputPoints.TabStop = true;
            this.radioBtnInputPoints.Text = "INPUT POINTS";
            this.radioBtnInputPoints.UseVisualStyleBackColor = false;
            this.radioBtnInputPoints.CheckedChanged += new System.EventHandler(this.radioBtnInputPoints_CheckedChanged);
            // 
            // btnRedeem
            // 
            this.btnRedeem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnRedeem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRedeem.ForeColor = System.Drawing.Color.Black;
            this.btnRedeem.Location = new System.Drawing.Point(9, 160);
            this.btnRedeem.Name = "btnRedeem";
            this.btnRedeem.Size = new System.Drawing.Size(180, 60);
            this.btnRedeem.TabIndex = 3;
            this.btnRedeem.Text = "REDEEM";
            this.btnRedeem.UseVisualStyleBackColor = false;
            this.btnRedeem.Click += new System.EventHandler(this.btnRedeem_Click);
            // 
            // txtPoints
            // 
            this.txtPoints.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPoints.Location = new System.Drawing.Point(251, 41);
            this.txtPoints.Name = "txtPoints";
            this.txtPoints.Size = new System.Drawing.Size(131, 35);
            this.txtPoints.TabIndex = 2;
            this.txtPoints.Text = "0.00";
            this.txtPoints.Click += new System.EventHandler(this.txtPoints_Click);
            // 
            // PointsRedeem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(410, 507);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PointsRedeem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POINTS REDEEM";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.PointsRedeem_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The label type
        /// </summary>
        public System.Windows.Forms.Label lblType;
        /// <summary>
        /// The label title type
        /// </summary>
        private System.Windows.Forms.Label lblTitleType;
        /// <summary>
        /// The label points
        /// </summary>
        public System.Windows.Forms.Label lblPoints;
        /// <summary>
        /// The label title points
        /// </summary>
        private System.Windows.Forms.Label lblTitlePoints;
        /// <summary>
        /// The label name
        /// </summary>
        public System.Windows.Forms.Label lblName;
        /// <summary>
        /// The label title name
        /// </summary>
        private System.Windows.Forms.Label lblTitleName;
        /// <summary>
        /// The label member code
        /// </summary>
        public System.Windows.Forms.Label lblMemberCode;
        /// <summary>
        /// The label title member code
        /// </summary>
        private System.Windows.Forms.Label lblTitleMemberCode;
        /// <summary>
        /// The group box1
        /// </summary>
        private System.Windows.Forms.GroupBox groupBox1;
        /// <summary>
        /// The group box2
        /// </summary>
        private System.Windows.Forms.GroupBox groupBox2;
        /// <summary>
        /// The radio BTN all points
        /// </summary>
        private System.Windows.Forms.RadioButton radioBtnAllPoints;
        /// <summary>
        /// The radio BTN input points
        /// </summary>
        private System.Windows.Forms.RadioButton radioBtnInputPoints;
        /// <summary>
        /// The text points
        /// </summary>
        private System.Windows.Forms.TextBox txtPoints;
        /// <summary>
        /// The BTN redeem
        /// </summary>
        private System.Windows.Forms.Button btnRedeem;
        /// <summary>
        /// The BTN cancel
        /// </summary>
        private System.Windows.Forms.Button btnCancel;

    }
}