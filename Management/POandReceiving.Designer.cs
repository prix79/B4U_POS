namespace Management
{
    partial class POandReceiving
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POandReceiving));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSearchPOList = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCreateNewPO = new System.Windows.Forms.Button();
            this.btnReceiving = new System.Windows.Forms.Button();
            this.btnLoadPO = new System.Windows.Forms.Button();
            this.btnItemSoldList = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblStoreName = new System.Windows.Forms.Label();
            this.lblStoreCode = new System.Windows.Forms.Label();
            this.lblEmployeeID = new System.Windows.Forms.Label();
            this.btnDeletePO = new System.Windows.Forms.Button();
            this.btnEditCostPrice = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNumOfPO = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalOrderAmount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotalReceivingAmount = new System.Windows.Forms.Label();
            this.btnCreateWarehousePO = new System.Windows.Forms.Button();
            this.btnInvoiceSummary = new System.Windows.Forms.Button();
            this.btnCreateReturnReport = new System.Windows.Forms.Button();
            this.btnSearchReturnList = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnLoadReturnReport = new System.Windows.Forms.Button();
            this.btnSearchAllReturnList = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnLoadReturnReportHQ = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeight = 45;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Location = new System.Drawing.Point(1, 46);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(884, 557);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseDoubleClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            // 
            // btnSearchPOList
            // 
            this.btnSearchPOList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchPOList.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearchPOList.Location = new System.Drawing.Point(888, 46);
            this.btnSearchPOList.Name = "btnSearchPOList";
            this.btnSearchPOList.Size = new System.Drawing.Size(95, 55);
            this.btnSearchPOList.TabIndex = 1;
            this.btnSearchPOList.Text = "SEARCH P/O LIST";
            this.btnSearchPOList.UseVisualStyleBackColor = true;
            this.btnSearchPOList.Click += new System.EventHandler(this.btnSearchPOList_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(888, 639);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 55);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCreateNewPO
            // 
            this.btnCreateNewPO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateNewPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCreateNewPO.Location = new System.Drawing.Point(579, 498);
            this.btnCreateNewPO.Name = "btnCreateNewPO";
            this.btnCreateNewPO.Size = new System.Drawing.Size(95, 55);
            this.btnCreateNewPO.TabIndex = 3;
            this.btnCreateNewPO.Text = "CREATE NEW P/O";
            this.btnCreateNewPO.UseVisualStyleBackColor = true;
            this.btnCreateNewPO.Visible = false;
            this.btnCreateNewPO.Click += new System.EventHandler(this.btnCreateNewPO_Click);
            // 
            // btnReceiving
            // 
            this.btnReceiving.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReceiving.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReceiving.Location = new System.Drawing.Point(888, 223);
            this.btnReceiving.Name = "btnReceiving";
            this.btnReceiving.Size = new System.Drawing.Size(95, 55);
            this.btnReceiving.TabIndex = 157;
            this.btnReceiving.Text = "RECEIVING P/O";
            this.btnReceiving.UseVisualStyleBackColor = true;
            this.btnReceiving.Click += new System.EventHandler(this.btnReceiving_Click);
            // 
            // btnLoadPO
            // 
            this.btnLoadPO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLoadPO.Location = new System.Drawing.Point(790, 498);
            this.btnLoadPO.Name = "btnLoadPO";
            this.btnLoadPO.Size = new System.Drawing.Size(95, 55);
            this.btnLoadPO.TabIndex = 158;
            this.btnLoadPO.Text = "LOAD P/O";
            this.btnLoadPO.UseVisualStyleBackColor = true;
            this.btnLoadPO.Visible = false;
            this.btnLoadPO.Click += new System.EventHandler(this.btnLoadPO_Click);
            // 
            // btnItemSoldList
            // 
            this.btnItemSoldList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnItemSoldList.BackColor = System.Drawing.SystemColors.Control;
            this.btnItemSoldList.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnItemSoldList.Location = new System.Drawing.Point(888, 105);
            this.btnItemSoldList.Name = "btnItemSoldList";
            this.btnItemSoldList.Size = new System.Drawing.Size(95, 55);
            this.btnItemSoldList.TabIndex = 159;
            this.btnItemSoldList.Text = "CREATE P/O";
            this.btnItemSoldList.UseVisualStyleBackColor = false;
            this.btnItemSoldList.Click += new System.EventHandler(this.btnItemSoldList_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(1, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 38);
            this.label1.TabIndex = 160;
            this.label1.Text = "STORE NAME";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(381, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 38);
            this.label2.TabIndex = 161;
            this.label2.Text = "STORE CODE";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(665, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 38);
            this.label3.TabIndex = 162;
            this.label3.Text = "EMPLOYEE ID";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStoreName
            // 
            this.lblStoreName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStoreName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStoreName.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblStoreName.Location = new System.Drawing.Point(149, 4);
            this.lblStoreName.Name = "lblStoreName";
            this.lblStoreName.Size = new System.Drawing.Size(231, 38);
            this.lblStoreName.TabIndex = 163;
            this.lblStoreName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStoreCode
            // 
            this.lblStoreCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStoreCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStoreCode.ForeColor = System.Drawing.Color.Red;
            this.lblStoreCode.Location = new System.Drawing.Point(531, 4);
            this.lblStoreCode.Name = "lblStoreCode";
            this.lblStoreCode.Size = new System.Drawing.Size(133, 38);
            this.lblStoreCode.TabIndex = 164;
            this.lblStoreCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEmployeeID
            // 
            this.lblEmployeeID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmployeeID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEmployeeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblEmployeeID.ForeColor = System.Drawing.Color.Maroon;
            this.lblEmployeeID.Location = new System.Drawing.Point(815, 4);
            this.lblEmployeeID.Name = "lblEmployeeID";
            this.lblEmployeeID.Size = new System.Drawing.Size(168, 38);
            this.lblEmployeeID.TabIndex = 165;
            this.lblEmployeeID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDeletePO
            // 
            this.btnDeletePO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeletePO.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDeletePO.Location = new System.Drawing.Point(888, 577);
            this.btnDeletePO.Name = "btnDeletePO";
            this.btnDeletePO.Size = new System.Drawing.Size(95, 55);
            this.btnDeletePO.TabIndex = 166;
            this.btnDeletePO.Text = "DELETE P/O OR RETURN REPORT";
            this.btnDeletePO.UseVisualStyleBackColor = true;
            this.btnDeletePO.Click += new System.EventHandler(this.btnDeletePO_Click);
            // 
            // btnEditCostPrice
            // 
            this.btnEditCostPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditCostPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnEditCostPrice.Location = new System.Drawing.Point(478, 498);
            this.btnEditCostPrice.Name = "btnEditCostPrice";
            this.btnEditCostPrice.Size = new System.Drawing.Size(95, 55);
            this.btnEditCostPrice.TabIndex = 167;
            this.btnEditCostPrice.Text = "EDIT COST PRICE";
            this.btnEditCostPrice.UseVisualStyleBackColor = true;
            this.btnEditCostPrice.Visible = false;
            this.btnEditCostPrice.Click += new System.EventHandler(this.btnEditCostPrice_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.BackColor = System.Drawing.SystemColors.Control;
            this.btnExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExcel.Location = new System.Drawing.Point(888, 459);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(95, 55);
            this.btnExcel.TabIndex = 168;
            this.btnExcel.Text = "EXCEL";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(1, 639);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 55);
            this.label4.TabIndex = 169;
            this.label4.Text = "NUMBER OF P/O";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNumOfPO
            // 
            this.lblNumOfPO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNumOfPO.BackColor = System.Drawing.Color.White;
            this.lblNumOfPO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumOfPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNumOfPO.Location = new System.Drawing.Point(135, 639);
            this.lblNumOfPO.Name = "lblNumOfPO";
            this.lblNumOfPO.Size = new System.Drawing.Size(102, 55);
            this.lblNumOfPO.TabIndex = 170;
            this.lblNumOfPO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(242, 639);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 55);
            this.label6.TabIndex = 171;
            this.label6.Text = "TOTAL ORDER AMOUNT";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalOrderAmount
            // 
            this.lblTotalOrderAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalOrderAmount.BackColor = System.Drawing.Color.White;
            this.lblTotalOrderAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalOrderAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTotalOrderAmount.Location = new System.Drawing.Point(391, 639);
            this.lblTotalOrderAmount.Name = "lblTotalOrderAmount";
            this.lblTotalOrderAmount.Size = new System.Drawing.Size(170, 55);
            this.lblTotalOrderAmount.TabIndex = 172;
            this.lblTotalOrderAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(566, 639);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 55);
            this.label8.TabIndex = 173;
            this.label8.Text = "TOTAL RECEIVING AMOUNT";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalReceivingAmount
            // 
            this.lblTotalReceivingAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalReceivingAmount.BackColor = System.Drawing.Color.White;
            this.lblTotalReceivingAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalReceivingAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTotalReceivingAmount.Location = new System.Drawing.Point(715, 639);
            this.lblTotalReceivingAmount.Name = "lblTotalReceivingAmount";
            this.lblTotalReceivingAmount.Size = new System.Drawing.Size(170, 55);
            this.lblTotalReceivingAmount.TabIndex = 174;
            this.lblTotalReceivingAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCreateWarehousePO
            // 
            this.btnCreateWarehousePO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateWarehousePO.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCreateWarehousePO.Location = new System.Drawing.Point(888, 164);
            this.btnCreateWarehousePO.Name = "btnCreateWarehousePO";
            this.btnCreateWarehousePO.Size = new System.Drawing.Size(95, 55);
            this.btnCreateWarehousePO.TabIndex = 175;
            this.btnCreateWarehousePO.Text = "CREATE WAREHOUSE P/O";
            this.btnCreateWarehousePO.UseVisualStyleBackColor = true;
            this.btnCreateWarehousePO.Click += new System.EventHandler(this.btnCreateWarehousePO_Click);
            // 
            // btnInvoiceSummary
            // 
            this.btnInvoiceSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInvoiceSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnInvoiceSummary.Location = new System.Drawing.Point(888, 400);
            this.btnInvoiceSummary.Name = "btnInvoiceSummary";
            this.btnInvoiceSummary.Size = new System.Drawing.Size(95, 55);
            this.btnInvoiceSummary.TabIndex = 176;
            this.btnInvoiceSummary.Text = "INVOICE SUMMARY";
            this.btnInvoiceSummary.UseVisualStyleBackColor = true;
            this.btnInvoiceSummary.Click += new System.EventHandler(this.btnInvoiceSummary_Click);
            // 
            // btnCreateReturnReport
            // 
            this.btnCreateReturnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateReturnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCreateReturnReport.Location = new System.Drawing.Point(888, 340);
            this.btnCreateReturnReport.Name = "btnCreateReturnReport";
            this.btnCreateReturnReport.Size = new System.Drawing.Size(95, 55);
            this.btnCreateReturnReport.TabIndex = 177;
            this.btnCreateReturnReport.Text = "CREATE RETURN REPORT";
            this.btnCreateReturnReport.UseVisualStyleBackColor = true;
            this.btnCreateReturnReport.Click += new System.EventHandler(this.btnCreateReturnReport_Click);
            // 
            // btnSearchReturnList
            // 
            this.btnSearchReturnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchReturnList.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearchReturnList.Location = new System.Drawing.Point(888, 281);
            this.btnSearchReturnList.Name = "btnSearchReturnList";
            this.btnSearchReturnList.Size = new System.Drawing.Size(95, 55);
            this.btnSearchReturnList.TabIndex = 178;
            this.btnSearchReturnList.Text = "SEARCH RETURN LIST";
            this.btnSearchReturnList.UseVisualStyleBackColor = true;
            this.btnSearchReturnList.Click += new System.EventHandler(this.btnSearchReturnList_Click);
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTest.Location = new System.Drawing.Point(377, 498);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(95, 55);
            this.btnTest.TabIndex = 180;
            this.btnTest.Text = "TEST";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Visible = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnLoadReturnReport
            // 
            this.btnLoadReturnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadReturnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLoadReturnReport.Location = new System.Drawing.Point(689, 498);
            this.btnLoadReturnReport.Name = "btnLoadReturnReport";
            this.btnLoadReturnReport.Size = new System.Drawing.Size(95, 55);
            this.btnLoadReturnReport.TabIndex = 181;
            this.btnLoadReturnReport.Text = "LOAD RETURN REPORT";
            this.btnLoadReturnReport.UseVisualStyleBackColor = true;
            this.btnLoadReturnReport.Visible = false;
            this.btnLoadReturnReport.Click += new System.EventHandler(this.btnLoadReturnReport_Click);
            // 
            // btnSearchAllReturnList
            // 
            this.btnSearchAllReturnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchAllReturnList.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearchAllReturnList.Location = new System.Drawing.Point(888, 518);
            this.btnSearchAllReturnList.Name = "btnSearchAllReturnList";
            this.btnSearchAllReturnList.Size = new System.Drawing.Size(95, 55);
            this.btnSearchAllReturnList.TabIndex = 182;
            this.btnSearchAllReturnList.Text = "SEARCH ALL RETURN LIST";
            this.btnSearchAllReturnList.UseVisualStyleBackColor = true;
            this.btnSearchAllReturnList.Click += new System.EventHandler(this.btnSearchAllReturnList_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(1, 603);
            this.progressBar1.Maximum = 11;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(884, 29);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 198;
            // 
            // btnLoadReturnReportHQ
            // 
            this.btnLoadReturnReportHQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadReturnReportHQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLoadReturnReportHQ.Location = new System.Drawing.Point(689, 437);
            this.btnLoadReturnReportHQ.Name = "btnLoadReturnReportHQ";
            this.btnLoadReturnReportHQ.Size = new System.Drawing.Size(95, 55);
            this.btnLoadReturnReportHQ.TabIndex = 199;
            this.btnLoadReturnReportHQ.Text = "LOAD RETURN REPORT HQ\r\nHQ\r\n";
            this.btnLoadReturnReportHQ.UseVisualStyleBackColor = true;
            this.btnLoadReturnReportHQ.Visible = false;
            this.btnLoadReturnReportHQ.Click += new System.EventHandler(this.btnLoadReturnReportHQ_Click);
            // 
            // POandReceiving
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 700);
            this.Controls.Add(this.btnLoadReturnReportHQ);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnSearchAllReturnList);
            this.Controls.Add(this.btnLoadReturnReport);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnSearchReturnList);
            this.Controls.Add(this.btnCreateReturnReport);
            this.Controls.Add(this.btnInvoiceSummary);
            this.Controls.Add(this.btnCreateWarehousePO);
            this.Controls.Add(this.lblTotalReceivingAmount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblTotalOrderAmount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblNumOfPO);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnEditCostPrice);
            this.Controls.Add(this.btnDeletePO);
            this.Controls.Add(this.lblEmployeeID);
            this.Controls.Add(this.lblStoreCode);
            this.Controls.Add(this.lblStoreName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnItemSoldList);
            this.Controls.Add(this.btnLoadPO);
            this.Controls.Add(this.btnReceiving);
            this.Controls.Add(this.btnCreateNewPO);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSearchPOList);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "POandReceiving";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "P/O AND RECEIVING";
            this.Load += new System.EventHandler(this.POReceiving_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSearchPOList;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCreateNewPO;
        private System.Windows.Forms.Button btnReceiving;
        private System.Windows.Forms.Button btnLoadPO;
        private System.Windows.Forms.Button btnItemSoldList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblStoreName;
        private System.Windows.Forms.Label lblStoreCode;
        private System.Windows.Forms.Label lblEmployeeID;
        private System.Windows.Forms.Button btnDeletePO;
        private System.Windows.Forms.Button btnEditCostPrice;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNumOfPO;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotalOrderAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotalReceivingAmount;
        private System.Windows.Forms.Button btnCreateWarehousePO;
        private System.Windows.Forms.Button btnInvoiceSummary;
        private System.Windows.Forms.Button btnCreateReturnReport;
        private System.Windows.Forms.Button btnSearchReturnList;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnLoadReturnReport;
        private System.Windows.Forms.Button btnSearchAllReturnList;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnLoadReturnReportHQ;
    }
}