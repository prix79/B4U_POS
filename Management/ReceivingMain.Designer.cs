namespace Management
{
    partial class ReceivingMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceivingMain));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblTotalCount1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReceiving = new System.Windows.Forms.Button();
            this.lblReceivingTotalAmount = new System.Windows.Forms.Label();
            this.lblReceivingTotalQty = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPOStatus = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblOrderTotalAmount = new System.Windows.Forms.Label();
            this.lblOrderTotalQty = new System.Windows.Forms.Label();
            this.lblEmployeeID = new System.Windows.Forms.Label();
            this.lblPOID = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblVendor = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnBarcode = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(930, 613);
            this.dataGridView1.TabIndex = 29;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // lblTotalCount1
            // 
            this.lblTotalCount1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalCount1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTotalCount1.Location = new System.Drawing.Point(935, 619);
            this.lblTotalCount1.Name = "lblTotalCount1";
            this.lblTotalCount1.Size = new System.Drawing.Size(81, 55);
            this.lblTotalCount1.TabIndex = 50;
            this.lblTotalCount1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(935, 561);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 55);
            this.label6.TabIndex = 49;
            this.label6.Text = "TOTAL COUNTS";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(935, 677);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 55);
            this.btnClose.TabIndex = 78;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReceiving
            // 
            this.btnReceiving.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReceiving.Location = new System.Drawing.Point(935, 3);
            this.btnReceiving.Name = "btnReceiving";
            this.btnReceiving.Size = new System.Drawing.Size(82, 56);
            this.btnReceiving.TabIndex = 79;
            this.btnReceiving.Text = "RECEIVING";
            this.btnReceiving.UseVisualStyleBackColor = true;
            this.btnReceiving.Click += new System.EventHandler(this.btnReceiving_Click);
            // 
            // lblReceivingTotalAmount
            // 
            this.lblReceivingTotalAmount.BackColor = System.Drawing.Color.White;
            this.lblReceivingTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblReceivingTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblReceivingTotalAmount.Location = new System.Drawing.Point(823, 677);
            this.lblReceivingTotalAmount.Name = "lblReceivingTotalAmount";
            this.lblReceivingTotalAmount.Size = new System.Drawing.Size(110, 55);
            this.lblReceivingTotalAmount.TabIndex = 83;
            this.lblReceivingTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblReceivingTotalQty
            // 
            this.lblReceivingTotalQty.BackColor = System.Drawing.Color.White;
            this.lblReceivingTotalQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblReceivingTotalQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblReceivingTotalQty.Location = new System.Drawing.Point(612, 677);
            this.lblReceivingTotalQty.Name = "lblReceivingTotalQty";
            this.lblReceivingTotalQty.Size = new System.Drawing.Size(71, 55);
            this.lblReceivingTotalQty.TabIndex = 82;
            this.lblReceivingTotalQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(511, 677);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 55);
            this.label3.TabIndex = 81;
            this.label3.Text = "RECEIVING TOTAL QTY";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(684, 677);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 55);
            this.label4.TabIndex = 80;
            this.label4.Text = "RECEIVING TOTAL AMOUNT";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPOStatus
            // 
            this.lblPOStatus.BackColor = System.Drawing.Color.White;
            this.lblPOStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPOStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPOStatus.Location = new System.Drawing.Point(402, 619);
            this.lblPOStatus.Name = "lblPOStatus";
            this.lblPOStatus.Size = new System.Drawing.Size(108, 55);
            this.lblPOStatus.TabIndex = 93;
            this.lblPOStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(327, 619);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 55);
            this.label9.TabIndex = 92;
            this.label9.Text = "P/O STATUS";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOrderTotalAmount
            // 
            this.lblOrderTotalAmount.BackColor = System.Drawing.Color.White;
            this.lblOrderTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOrderTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderTotalAmount.Location = new System.Drawing.Point(823, 619);
            this.lblOrderTotalAmount.Name = "lblOrderTotalAmount";
            this.lblOrderTotalAmount.Size = new System.Drawing.Size(110, 55);
            this.lblOrderTotalAmount.TabIndex = 91;
            this.lblOrderTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOrderTotalQty
            // 
            this.lblOrderTotalQty.BackColor = System.Drawing.Color.White;
            this.lblOrderTotalQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOrderTotalQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderTotalQty.Location = new System.Drawing.Point(612, 619);
            this.lblOrderTotalQty.Name = "lblOrderTotalQty";
            this.lblOrderTotalQty.Size = new System.Drawing.Size(71, 55);
            this.lblOrderTotalQty.TabIndex = 90;
            this.lblOrderTotalQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEmployeeID
            // 
            this.lblEmployeeID.BackColor = System.Drawing.Color.White;
            this.lblEmployeeID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEmployeeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblEmployeeID.Location = new System.Drawing.Point(223, 619);
            this.lblEmployeeID.Name = "lblEmployeeID";
            this.lblEmployeeID.Size = new System.Drawing.Size(103, 55);
            this.lblEmployeeID.TabIndex = 89;
            this.lblEmployeeID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPOID
            // 
            this.lblPOID.BackColor = System.Drawing.Color.White;
            this.lblPOID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPOID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPOID.Location = new System.Drawing.Point(49, 619);
            this.lblPOID.Name = "lblPOID";
            this.lblPOID.Size = new System.Drawing.Size(72, 55);
            this.lblPOID.TabIndex = 88;
            this.lblPOID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(511, 619);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 55);
            this.label11.TabIndex = 87;
            this.label11.Text = "ORDER TOTAL QTY";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(122, 619);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 55);
            this.label10.TabIndex = 86;
            this.label10.Text = "EMPLOYEE ID";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.Location = new System.Drawing.Point(684, 619);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(138, 55);
            this.label14.TabIndex = 85;
            this.label14.Text = "ORDER TOTAL AMOUNT";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(3, 619);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 55);
            this.label8.TabIndex = 84;
            this.label8.Text = "P/O ID";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVendor
            // 
            this.lblVendor.BackColor = System.Drawing.Color.White;
            this.lblVendor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblVendor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblVendor.Location = new System.Drawing.Point(122, 677);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(204, 55);
            this.lblVendor.TabIndex = 95;
            this.lblVendor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(3, 677);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 55);
            this.label2.TabIndex = 94;
            this.label2.Text = "SELECTED VENDOR";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(327, 678);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(183, 54);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 96;
            // 
            // btnBarcode
            // 
            this.btnBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBarcode.Location = new System.Drawing.Point(935, 65);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Size = new System.Drawing.Size(82, 56);
            this.btnBarcode.TabIndex = 97;
            this.btnBarcode.Text = "BARCODE PRINT";
            this.btnBarcode.UseVisualStyleBackColor = true;
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // ReceivingMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 741);
            this.Controls.Add(this.btnBarcode);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblVendor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPOStatus);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblOrderTotalAmount);
            this.Controls.Add(this.lblOrderTotalQty);
            this.Controls.Add(this.lblEmployeeID);
            this.Controls.Add(this.lblPOID);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblReceivingTotalAmount);
            this.Controls.Add(this.lblReceivingTotalQty);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnReceiving);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTotalCount1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ReceivingMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RECEIVING P/O";
            this.Load += new System.EventHandler(this.ReceivingMain_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReceivingMain_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.Label lblTotalCount1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReceiving;
        public System.Windows.Forms.Label lblReceivingTotalAmount;
        public System.Windows.Forms.Label lblReceivingTotalQty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPOStatus;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label lblOrderTotalAmount;
        public System.Windows.Forms.Label lblOrderTotalQty;
        private System.Windows.Forms.Label lblEmployeeID;
        private System.Windows.Forms.Label lblPOID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnBarcode;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}