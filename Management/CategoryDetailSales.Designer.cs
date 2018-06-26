namespace Management
{
    partial class CategoryDetailSales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryDetailSales));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCategory1 = new System.Windows.Forms.Label();
            this.cmbCategory2 = new System.Windows.Forms.ComboBox();
            this.cmbCategory3 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.lblCDTotalDiscount = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblCDNetSales = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblCDSoldQty = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCDReturnQty = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCDPercentage = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "CATEGORY 1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(234, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 40);
            this.label2.TabIndex = 1;
            this.label2.Text = "CATEGORY 2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(465, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 40);
            this.label3.TabIndex = 2;
            this.label3.Text = "CATEGORY 3";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCategory1
            // 
            this.lblCategory1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCategory1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCategory1.Location = new System.Drawing.Point(3, 50);
            this.lblCategory1.Name = "lblCategory1";
            this.lblCategory1.Size = new System.Drawing.Size(230, 40);
            this.lblCategory1.TabIndex = 3;
            this.lblCategory1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbCategory2
            // 
            this.cmbCategory2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCategory2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCategory2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategory2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbCategory2.FormattingEnabled = true;
            this.cmbCategory2.Location = new System.Drawing.Point(234, 49);
            this.cmbCategory2.Name = "cmbCategory2";
            this.cmbCategory2.Size = new System.Drawing.Size(230, 40);
            this.cmbCategory2.TabIndex = 4;
            this.cmbCategory2.SelectedIndexChanged += new System.EventHandler(this.cmbCategory2_SelectedIndexChanged);
            // 
            // cmbCategory3
            // 
            this.cmbCategory3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCategory3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCategory3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategory3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbCategory3.FormattingEnabled = true;
            this.cmbCategory3.Location = new System.Drawing.Point(465, 49);
            this.cmbCategory3.Name = "cmbCategory3";
            this.cmbCategory3.Size = new System.Drawing.Size(230, 40);
            this.cmbCategory3.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeight = 35;
            this.dataGridView1.Location = new System.Drawing.Point(3, 97);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(890, 483);
            this.dataGridView1.TabIndex = 6;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOK.Location = new System.Drawing.Point(697, 9);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(196, 40);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(697, 50);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(196, 40);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExcel.ForeColor = System.Drawing.Color.Black;
            this.btnExcel.Location = new System.Drawing.Point(697, 644);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(196, 60);
            this.btnExcel.TabIndex = 10;
            this.btnExcel.Text = "EXCEL";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // lblCDTotalDiscount
            // 
            this.lblCDTotalDiscount.BackColor = System.Drawing.SystemColors.Control;
            this.lblCDTotalDiscount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCDTotalDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCDTotalDiscount.Location = new System.Drawing.Point(89, 644);
            this.lblCDTotalDiscount.Name = "lblCDTotalDiscount";
            this.lblCDTotalDiscount.Size = new System.Drawing.Size(165, 60);
            this.lblCDTotalDiscount.TabIndex = 123;
            this.lblCDTotalDiscount.Text = "$0.00";
            this.lblCDTotalDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.Location = new System.Drawing.Point(3, 644);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 60);
            this.label13.TabIndex = 122;
            this.label13.Text = "TOTAL DISC";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCDNetSales
            // 
            this.lblCDNetSales.BackColor = System.Drawing.SystemColors.Control;
            this.lblCDNetSales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCDNetSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCDNetSales.Location = new System.Drawing.Point(89, 584);
            this.lblCDNetSales.Name = "lblCDNetSales";
            this.lblCDNetSales.Size = new System.Drawing.Size(165, 60);
            this.lblCDNetSales.TabIndex = 121;
            this.lblCDNetSales.Text = "$0.00";
            this.lblCDNetSales.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.Location = new System.Drawing.Point(3, 584);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(84, 60);
            this.label17.TabIndex = 120;
            this.label17.Text = "NSALES";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCDSoldQty
            // 
            this.lblCDSoldQty.BackColor = System.Drawing.SystemColors.Control;
            this.lblCDSoldQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCDSoldQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCDSoldQty.Location = new System.Drawing.Point(343, 584);
            this.lblCDSoldQty.Name = "lblCDSoldQty";
            this.lblCDSoldQty.Size = new System.Drawing.Size(96, 60);
            this.lblCDSoldQty.TabIndex = 125;
            this.lblCDSoldQty.Text = "0";
            this.lblCDSoldQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(257, 584);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 60);
            this.label5.TabIndex = 124;
            this.label5.Text = "SOLD QTY";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCDReturnQty
            // 
            this.lblCDReturnQty.BackColor = System.Drawing.SystemColors.Control;
            this.lblCDReturnQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCDReturnQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCDReturnQty.Location = new System.Drawing.Point(343, 644);
            this.lblCDReturnQty.Name = "lblCDReturnQty";
            this.lblCDReturnQty.Size = new System.Drawing.Size(96, 60);
            this.lblCDReturnQty.TabIndex = 127;
            this.lblCDReturnQty.Text = "0";
            this.lblCDReturnQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(257, 644);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 60);
            this.label7.TabIndex = 126;
            this.label7.Text = "RETURN QTY";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCDPercentage
            // 
            this.lblCDPercentage.BackColor = System.Drawing.SystemColors.Control;
            this.lblCDPercentage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCDPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCDPercentage.Location = new System.Drawing.Point(580, 584);
            this.lblCDPercentage.Name = "lblCDPercentage";
            this.lblCDPercentage.Size = new System.Drawing.Size(114, 60);
            this.lblCDPercentage.TabIndex = 129;
            this.lblCDPercentage.Text = "0%";
            this.lblCDPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(442, 584);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 60);
            this.label9.TabIndex = 128;
            this.label9.Text = "PERCENTAGE IN CATEGORY";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CategoryDetailSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 708);
            this.Controls.Add(this.lblCDPercentage);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblCDReturnQty);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblCDSoldQty);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblCDTotalDiscount);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblCDNetSales);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmbCategory3);
            this.Controls.Add(this.cmbCategory2);
            this.Controls.Add(this.lblCategory1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CategoryDetailSales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CATEGORY SALES IN DETAIL";
            this.Load += new System.EventHandler(this.CategoryDetailSales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCategory1;
        private System.Windows.Forms.ComboBox cmbCategory2;
        private System.Windows.Forms.ComboBox cmbCategory3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Label lblCDTotalDiscount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblCDNetSales;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblCDSoldQty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCDReturnQty;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCDPercentage;
        private System.Windows.Forms.Label label9;
    }
}