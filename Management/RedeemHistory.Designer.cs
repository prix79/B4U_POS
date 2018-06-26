namespace Management
{
    partial class RedeemHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RedeemHistory));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoBtnCoupon = new System.Windows.Forms.RadioButton();
            this.rdoBtnGiftCard = new System.Windows.Forms.RadioButton();
            this.rdoBtnStoreCredit = new System.Windows.Forms.RadioButton();
            this.rdoBtnCustomerPoints = new System.Windows.Forms.RadioButton();
            this.rdoBtnAll = new System.Windows.Forms.RadioButton();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.cmdManageGiftcard = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 40;
            this.dataGridView1.Location = new System.Drawing.Point(4, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(884, 692);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoBtnCoupon);
            this.groupBox1.Controls.Add(this.rdoBtnGiftCard);
            this.groupBox1.Controls.Add(this.rdoBtnStoreCredit);
            this.groupBox1.Controls.Add(this.rdoBtnCustomerPoints);
            this.groupBox1.Controls.Add(this.rdoBtnAll);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(892, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(92, 211);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "OPTION";
            // 
            // rdoBtnCoupon
            // 
            this.rdoBtnCoupon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnCoupon.Location = new System.Drawing.Point(4, 181);
            this.rdoBtnCoupon.Name = "rdoBtnCoupon";
            this.rdoBtnCoupon.Size = new System.Drawing.Size(82, 17);
            this.rdoBtnCoupon.TabIndex = 4;
            this.rdoBtnCoupon.Text = "COUPON";
            this.rdoBtnCoupon.UseVisualStyleBackColor = true;
            // 
            // rdoBtnGiftCard
            // 
            this.rdoBtnGiftCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnGiftCard.Location = new System.Drawing.Point(4, 136);
            this.rdoBtnGiftCard.Name = "rdoBtnGiftCard";
            this.rdoBtnGiftCard.Size = new System.Drawing.Size(82, 32);
            this.rdoBtnGiftCard.TabIndex = 3;
            this.rdoBtnGiftCard.Text = "GIFT CARD";
            this.rdoBtnGiftCard.UseVisualStyleBackColor = true;
            // 
            // rdoBtnStoreCredit
            // 
            this.rdoBtnStoreCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnStoreCredit.Location = new System.Drawing.Point(4, 92);
            this.rdoBtnStoreCredit.Name = "rdoBtnStoreCredit";
            this.rdoBtnStoreCredit.Size = new System.Drawing.Size(86, 41);
            this.rdoBtnStoreCredit.TabIndex = 2;
            this.rdoBtnStoreCredit.Text = "STORE CREDIT";
            this.rdoBtnStoreCredit.UseVisualStyleBackColor = true;
            // 
            // rdoBtnCustomerPoints
            // 
            this.rdoBtnCustomerPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnCustomerPoints.Location = new System.Drawing.Point(4, 50);
            this.rdoBtnCustomerPoints.Name = "rdoBtnCustomerPoints";
            this.rdoBtnCustomerPoints.Size = new System.Drawing.Size(86, 41);
            this.rdoBtnCustomerPoints.TabIndex = 1;
            this.rdoBtnCustomerPoints.Text = "CUSTOMER POINTS";
            this.rdoBtnCustomerPoints.UseVisualStyleBackColor = true;
            // 
            // rdoBtnAll
            // 
            this.rdoBtnAll.Checked = true;
            this.rdoBtnAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnAll.Location = new System.Drawing.Point(4, 22);
            this.rdoBtnAll.Name = "rdoBtnAll";
            this.rdoBtnAll.Size = new System.Drawing.Size(86, 22);
            this.rdoBtnAll.TabIndex = 0;
            this.rdoBtnAll.TabStop = true;
            this.rdoBtnAll.Text = "ALL";
            this.rdoBtnAll.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLoad.ForeColor = System.Drawing.Color.Black;
            this.btnLoad.Location = new System.Drawing.Point(892, 217);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(92, 45);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "LOAD";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(892, 653);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 45);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnFind
            // 
            this.btnFind.Enabled = false;
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFind.ForeColor = System.Drawing.Color.Black;
            this.btnFind.Location = new System.Drawing.Point(892, 269);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(92, 45);
            this.btnFind.TabIndex = 4;
            this.btnFind.Text = "FIND";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Enabled = false;
            this.btnExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExcel.ForeColor = System.Drawing.Color.Black;
            this.btnExcel.Location = new System.Drawing.Point(892, 321);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(92, 45);
            this.btnExcel.TabIndex = 5;
            this.btnExcel.Text = "EXCEL";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // cmdManageGiftcard
            // 
            this.cmdManageGiftcard.Enabled = false;
            this.cmdManageGiftcard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmdManageGiftcard.ForeColor = System.Drawing.Color.Black;
            this.cmdManageGiftcard.Location = new System.Drawing.Point(892, 602);
            this.cmdManageGiftcard.Name = "cmdManageGiftcard";
            this.cmdManageGiftcard.Size = new System.Drawing.Size(92, 45);
            this.cmdManageGiftcard.TabIndex = 6;
            this.cmdManageGiftcard.Text = "MANAGE GIFTCARD";
            this.cmdManageGiftcard.UseVisualStyleBackColor = true;
            this.cmdManageGiftcard.Click += new System.EventHandler(this.cmdManageGiftcard_Click);
            // 
            // RedeemHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 704);
            this.Controls.Add(this.cmdManageGiftcard);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RedeemHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REDEEM HISTORY";
            this.Load += new System.EventHandler(this.RedeemHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoBtnStoreCredit;
        private System.Windows.Forms.RadioButton rdoBtnCustomerPoints;
        private System.Windows.Forms.RadioButton rdoBtnAll;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RadioButton rdoBtnGiftCard;
        private System.Windows.Forms.RadioButton rdoBtnCoupon;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button cmdManageGiftcard;
    }
}