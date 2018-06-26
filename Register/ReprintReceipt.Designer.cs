// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 08-04-2016
// ***********************************************************************
// <copyright file="ReprintReceipt.Designer.cs" company="Beauty4u">
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
    /// Class ReprintReceipt.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class ReprintReceipt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReprintReceipt));
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnLatest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReceiptID = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbPayBy = new System.Windows.Forms.ComboBox();
            this.txtSellDate = new System.Windows.Forms.TextBox();
            this.cmbREG = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.MediumBlue;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(347, 24);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(134, 53);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnLatest
            // 
            this.btnLatest.BackColor = System.Drawing.Color.MediumBlue;
            this.btnLatest.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLatest.ForeColor = System.Drawing.Color.White;
            this.btnLatest.Location = new System.Drawing.Point(2, 100);
            this.btnLatest.Name = "btnLatest";
            this.btnLatest.Size = new System.Drawing.Size(479, 79);
            this.btnLatest.TabIndex = 11;
            this.btnLatest.Text = "PRINT LATEST RECEIPT";
            this.btnLatest.UseVisualStyleBackColor = false;
            this.btnLatest.Click += new System.EventHandler(this.btnLatest_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(2, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 53);
            this.label1.TabIndex = 10;
            this.label1.Text = "RECEIPT ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtReceiptID
            // 
            this.txtReceiptID.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtReceiptID.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtReceiptID.Location = new System.Drawing.Point(186, 24);
            this.txtReceiptID.Name = "txtReceiptID";
            this.txtReceiptID.Size = new System.Drawing.Size(159, 53);
            this.txtReceiptID.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.MediumBlue;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(2, 201);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(479, 79);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(406, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbPayBy
            // 
            this.cmbPayBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPayBy.FormattingEnabled = true;
            this.cmbPayBy.Items.AddRange(new object[] {
            "0",
            "1",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "88",
            "99"});
            this.cmbPayBy.Location = new System.Drawing.Point(2, 2);
            this.cmbPayBy.Name = "cmbPayBy";
            this.cmbPayBy.Size = new System.Drawing.Size(121, 21);
            this.cmbPayBy.TabIndex = 14;
            this.cmbPayBy.Visible = false;
            // 
            // txtSellDate
            // 
            this.txtSellDate.Location = new System.Drawing.Point(276, 2);
            this.txtSellDate.Name = "txtSellDate";
            this.txtSellDate.Size = new System.Drawing.Size(100, 20);
            this.txtSellDate.TabIndex = 15;
            this.txtSellDate.Visible = false;
            // 
            // cmbREG
            // 
            this.cmbREG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbREG.FormattingEnabled = true;
            this.cmbREG.Items.AddRange(new object[] {
            "REG01",
            "REG02",
            "REG03",
            "REG04",
            "ALL"});
            this.cmbREG.Location = new System.Drawing.Point(130, 2);
            this.cmbREG.Name = "cmbREG";
            this.cmbREG.Size = new System.Drawing.Size(121, 21);
            this.cmbREG.TabIndex = 16;
            this.cmbREG.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(406, 71);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(226, 149);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(157, 131);
            this.dataGridView1.TabIndex = 82;
            this.dataGridView1.Visible = false;
            // 
            // ReprintReceipt
            // 
            this.AcceptButton = this.btnPrint;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(486, 295);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cmbREG);
            this.Controls.Add(this.txtSellDate);
            this.Controls.Add(this.cmbPayBy);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtReceiptID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLatest);
            this.Controls.Add(this.btnPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReprintReceipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REPRINT RECEIPT";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ReprintReceipt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /// <summary>
        /// The BTN print
        /// </summary>
        private System.Windows.Forms.Button btnPrint;
        /// <summary>
        /// The BTN latest
        /// </summary>
        private System.Windows.Forms.Button btnLatest;
        /// <summary>
        /// The label1
        /// </summary>
        private System.Windows.Forms.Label label1;
        /// <summary>
        /// The text receipt identifier
        /// </summary>
        private System.Windows.Forms.TextBox txtReceiptID;
        /// <summary>
        /// The BTN close
        /// </summary>
        private System.Windows.Forms.Button btnClose;
        /// <summary>
        /// The button1
        /// </summary>
        private System.Windows.Forms.Button button1;
        /// <summary>
        /// The CMB pay by
        /// </summary>
        private System.Windows.Forms.ComboBox cmbPayBy;
        /// <summary>
        /// The CMB reg
        /// </summary>
        private System.Windows.Forms.ComboBox cmbREG;
        /// <summary>
        /// The text sell date
        /// </summary>
        private System.Windows.Forms.TextBox txtSellDate;
        /// <summary>
        /// The button2
        /// </summary>
        private System.Windows.Forms.Button button2;
        /// <summary>
        /// The data grid view1
        /// </summary>
        public System.Windows.Forms.DataGridView dataGridView1;
    }
}