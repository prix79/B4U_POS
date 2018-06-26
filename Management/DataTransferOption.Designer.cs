namespace Management
{
    partial class DataTransferOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataTransferOption));
            this.rdoBtnTransNewItems = new System.Windows.Forms.RadioButton();
            this.rdoBtnTransSelectedFields = new System.Windows.Forms.RadioButton();
            this.rdoBtnTransAll = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkBoxRetailPrice = new System.Windows.Forms.CheckBox();
            this.chkBoxStylistPrice = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.grpDestinationServer = new System.Windows.Forms.GroupBox();
            this.rdoBtnBW = new System.Windows.Forms.RadioButton();
            this.rdoBtnGB = new System.Windows.Forms.RadioButton();
            this.rdoBtnPW = new System.Windows.Forms.RadioButton();
            this.rdoBtnWD = new System.Windows.Forms.RadioButton();
            this.rdoBtnB4UWH = new System.Windows.Forms.RadioButton();
            this.rdoBtnBeautyCare = new System.Windows.Forms.RadioButton();
            this.rdoBtnTH = new System.Windows.Forms.RadioButton();
            this.rdoBtnTest = new System.Windows.Forms.RadioButton();
            this.rdoBtnWM = new System.Windows.Forms.RadioButton();
            this.rdoBtnUM = new System.Windows.Forms.RadioButton();
            this.rdoBtnCV = new System.Windows.Forms.RadioButton();
            this.rdoBtnWB = new System.Windows.Forms.RadioButton();
            this.rdoBtnCH = new System.Windows.Forms.RadioButton();
            this.rdoBtnOH = new System.Windows.Forms.RadioButton();
            this.rdoBtnTransScannedItems = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.chkBoxCostPrice = new System.Windows.Forms.CheckBox();
            this.rdoBtnSyncBrand = new System.Windows.Forms.RadioButton();
            this.rdoBtnSyncSize = new System.Windows.Forms.RadioButton();
            this.rdoBtnSyncColor = new System.Windows.Forms.RadioButton();
            this.rdoBtnSyncVendor = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.grpDestinationServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // rdoBtnTransNewItems
            // 
            this.rdoBtnTransNewItems.AutoSize = true;
            this.rdoBtnTransNewItems.Checked = true;
            this.rdoBtnTransNewItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnTransNewItems.Location = new System.Drawing.Point(20, 19);
            this.rdoBtnTransNewItems.Name = "rdoBtnTransNewItems";
            this.rdoBtnTransNewItems.Size = new System.Drawing.Size(273, 29);
            this.rdoBtnTransNewItems.TabIndex = 0;
            this.rdoBtnTransNewItems.TabStop = true;
            this.rdoBtnTransNewItems.Text = "TRANSFER NEW ITEMS";
            this.rdoBtnTransNewItems.UseVisualStyleBackColor = true;
            this.rdoBtnTransNewItems.CheckedChanged += new System.EventHandler(this.rdoBtnTransNewItems_CheckedChanged);
            // 
            // rdoBtnTransSelectedFields
            // 
            this.rdoBtnTransSelectedFields.AutoSize = true;
            this.rdoBtnTransSelectedFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnTransSelectedFields.Location = new System.Drawing.Point(20, 89);
            this.rdoBtnTransSelectedFields.Name = "rdoBtnTransSelectedFields";
            this.rdoBtnTransSelectedFields.Size = new System.Drawing.Size(345, 29);
            this.rdoBtnTransSelectedFields.TabIndex = 1;
            this.rdoBtnTransSelectedFields.Text = "TRANSFER SELECTED FIELDS";
            this.rdoBtnTransSelectedFields.UseVisualStyleBackColor = true;
            this.rdoBtnTransSelectedFields.CheckedChanged += new System.EventHandler(this.rdoBtnTransSelectedFields_CheckedChanged);
            // 
            // rdoBtnTransAll
            // 
            this.rdoBtnTransAll.AutoSize = true;
            this.rdoBtnTransAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnTransAll.Location = new System.Drawing.Point(20, 211);
            this.rdoBtnTransAll.Name = "rdoBtnTransAll";
            this.rdoBtnTransAll.Size = new System.Drawing.Size(189, 29);
            this.rdoBtnTransAll.TabIndex = 2;
            this.rdoBtnTransAll.Text = "TRANSFER ALL";
            this.rdoBtnTransAll.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOK.Location = new System.Drawing.Point(12, 465);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(180, 50);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(198, 465);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(180, 50);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkBoxRetailPrice
            // 
            this.chkBoxRetailPrice.AutoSize = true;
            this.chkBoxRetailPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkBoxRetailPrice.Location = new System.Drawing.Point(42, 123);
            this.chkBoxRetailPrice.Name = "chkBoxRetailPrice";
            this.chkBoxRetailPrice.Size = new System.Drawing.Size(150, 24);
            this.chkBoxRetailPrice.TabIndex = 6;
            this.chkBoxRetailPrice.Text = "RETAIL PRICE";
            this.chkBoxRetailPrice.UseVisualStyleBackColor = true;
            // 
            // chkBoxStylistPrice
            // 
            this.chkBoxStylistPrice.AutoSize = true;
            this.chkBoxStylistPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkBoxStylistPrice.Location = new System.Drawing.Point(42, 183);
            this.chkBoxStylistPrice.Name = "chkBoxStylistPrice";
            this.chkBoxStylistPrice.Size = new System.Drawing.Size(159, 24);
            this.chkBoxStylistPrice.TabIndex = 7;
            this.chkBoxStylistPrice.Text = "STYLIST PRICE";
            this.chkBoxStylistPrice.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(386, 465);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(265, 50);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 8;
            // 
            // grpDestinationServer
            // 
            this.grpDestinationServer.Controls.Add(this.rdoBtnBW);
            this.grpDestinationServer.Controls.Add(this.rdoBtnGB);
            this.grpDestinationServer.Controls.Add(this.rdoBtnPW);
            this.grpDestinationServer.Controls.Add(this.rdoBtnWD);
            this.grpDestinationServer.Controls.Add(this.rdoBtnB4UWH);
            this.grpDestinationServer.Controls.Add(this.rdoBtnBeautyCare);
            this.grpDestinationServer.Controls.Add(this.rdoBtnTH);
            this.grpDestinationServer.Controls.Add(this.rdoBtnTest);
            this.grpDestinationServer.Controls.Add(this.rdoBtnWM);
            this.grpDestinationServer.Controls.Add(this.rdoBtnUM);
            this.grpDestinationServer.Controls.Add(this.rdoBtnCV);
            this.grpDestinationServer.Controls.Add(this.rdoBtnWB);
            this.grpDestinationServer.Controls.Add(this.rdoBtnCH);
            this.grpDestinationServer.Controls.Add(this.rdoBtnOH);
            this.grpDestinationServer.Enabled = false;
            this.grpDestinationServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grpDestinationServer.Location = new System.Drawing.Point(386, 12);
            this.grpDestinationServer.Name = "grpDestinationServer";
            this.grpDestinationServer.Size = new System.Drawing.Size(265, 449);
            this.grpDestinationServer.TabIndex = 9;
            this.grpDestinationServer.TabStop = false;
            this.grpDestinationServer.Text = "DESTINATION SERVER";
            // 
            // rdoBtnBW
            // 
            this.rdoBtnBW.AutoSize = true;
            this.rdoBtnBW.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnBW.Location = new System.Drawing.Point(13, 354);
            this.rdoBtnBW.Name = "rdoBtnBW";
            this.rdoBtnBW.Size = new System.Drawing.Size(86, 24);
            this.rdoBtnBW.TabIndex = 14;
            this.rdoBtnBW.TabStop = true;
            this.rdoBtnBW.Text = "BOWIE";
            this.rdoBtnBW.UseVisualStyleBackColor = true;
            // 
            // rdoBtnGB
            // 
            this.rdoBtnGB.AutoSize = true;
            this.rdoBtnGB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnGB.Location = new System.Drawing.Point(13, 324);
            this.rdoBtnGB.Name = "rdoBtnGB";
            this.rdoBtnGB.Size = new System.Drawing.Size(171, 24);
            this.rdoBtnGB.TabIndex = 13;
            this.rdoBtnGB.TabStop = true;
            this.rdoBtnGB.Text = "GAITHERSBURG";
            this.rdoBtnGB.UseVisualStyleBackColor = true;
            // 
            // rdoBtnPW
            // 
            this.rdoBtnPW.AutoSize = true;
            this.rdoBtnPW.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnPW.Location = new System.Drawing.Point(13, 234);
            this.rdoBtnPW.Name = "rdoBtnPW";
            this.rdoBtnPW.Size = new System.Drawing.Size(172, 24);
            this.rdoBtnPW.TabIndex = 12;
            this.rdoBtnPW.TabStop = true;
            this.rdoBtnPW.Text = "PRINCE WILLIAM";
            this.rdoBtnPW.UseVisualStyleBackColor = true;
            // 
            // rdoBtnWD
            // 
            this.rdoBtnWD.AutoSize = true;
            this.rdoBtnWD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnWD.Location = new System.Drawing.Point(13, 294);
            this.rdoBtnWD.Name = "rdoBtnWD";
            this.rdoBtnWD.Size = new System.Drawing.Size(115, 24);
            this.rdoBtnWD.TabIndex = 11;
            this.rdoBtnWD.TabStop = true;
            this.rdoBtnWD.Text = "WALDORF";
            this.rdoBtnWD.UseVisualStyleBackColor = true;
            // 
            // rdoBtnB4UWH
            // 
            this.rdoBtnB4UWH.AutoSize = true;
            this.rdoBtnB4UWH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnB4UWH.Location = new System.Drawing.Point(13, 24);
            this.rdoBtnB4UWH.Name = "rdoBtnB4UWH";
            this.rdoBtnB4UWH.Size = new System.Drawing.Size(247, 24);
            this.rdoBtnB4UWH.TabIndex = 9;
            this.rdoBtnB4UWH.TabStop = true;
            this.rdoBtnB4UWH.Text = "BEAUTY 4U WAREHOUSE";
            this.rdoBtnB4UWH.UseVisualStyleBackColor = true;
            // 
            // rdoBtnBeautyCare
            // 
            this.rdoBtnBeautyCare.AutoSize = true;
            this.rdoBtnBeautyCare.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnBeautyCare.Location = new System.Drawing.Point(13, 414);
            this.rdoBtnBeautyCare.Name = "rdoBtnBeautyCare";
            this.rdoBtnBeautyCare.Size = new System.Drawing.Size(152, 24);
            this.rdoBtnBeautyCare.TabIndex = 8;
            this.rdoBtnBeautyCare.TabStop = true;
            this.rdoBtnBeautyCare.Text = "BEAUTY CARE";
            this.rdoBtnBeautyCare.UseVisualStyleBackColor = true;
            this.rdoBtnBeautyCare.Visible = false;
            // 
            // rdoBtnTH
            // 
            this.rdoBtnTH.AutoSize = true;
            this.rdoBtnTH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnTH.Location = new System.Drawing.Point(13, 54);
            this.rdoBtnTH.Name = "rdoBtnTH";
            this.rdoBtnTH.Size = new System.Drawing.Size(152, 24);
            this.rdoBtnTH.TabIndex = 7;
            this.rdoBtnTH.TabStop = true;
            this.rdoBtnTH.Text = "TEMPLE HILLS";
            this.rdoBtnTH.UseVisualStyleBackColor = true;
            // 
            // rdoBtnTest
            // 
            this.rdoBtnTest.AutoSize = true;
            this.rdoBtnTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnTest.Location = new System.Drawing.Point(13, 384);
            this.rdoBtnTest.Name = "rdoBtnTest";
            this.rdoBtnTest.Size = new System.Drawing.Size(71, 24);
            this.rdoBtnTest.TabIndex = 6;
            this.rdoBtnTest.TabStop = true;
            this.rdoBtnTest.Text = "TEST";
            this.rdoBtnTest.UseVisualStyleBackColor = true;
            this.rdoBtnTest.Visible = false;
            // 
            // rdoBtnWM
            // 
            this.rdoBtnWM.AutoSize = true;
            this.rdoBtnWM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnWM.Location = new System.Drawing.Point(13, 174);
            this.rdoBtnWM.Name = "rdoBtnWM";
            this.rdoBtnWM.Size = new System.Drawing.Size(157, 24);
            this.rdoBtnWM.TabIndex = 5;
            this.rdoBtnWM.TabStop = true;
            this.rdoBtnWM.Text = "WINDSOR MILL";
            this.rdoBtnWM.UseVisualStyleBackColor = true;
            // 
            // rdoBtnUM
            // 
            this.rdoBtnUM.AutoSize = true;
            this.rdoBtnUM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnUM.Location = new System.Drawing.Point(13, 114);
            this.rdoBtnUM.Name = "rdoBtnUM";
            this.rdoBtnUM.Size = new System.Drawing.Size(192, 24);
            this.rdoBtnUM.TabIndex = 4;
            this.rdoBtnUM.TabStop = true;
            this.rdoBtnUM.Text = "UPPER MARLBORO";
            this.rdoBtnUM.UseVisualStyleBackColor = true;
            // 
            // rdoBtnCV
            // 
            this.rdoBtnCV.AutoSize = true;
            this.rdoBtnCV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnCV.Location = new System.Drawing.Point(13, 204);
            this.rdoBtnCV.Name = "rdoBtnCV";
            this.rdoBtnCV.Size = new System.Drawing.Size(148, 24);
            this.rdoBtnCV.TabIndex = 3;
            this.rdoBtnCV.TabStop = true;
            this.rdoBtnCV.Text = "CATONSVILLE";
            this.rdoBtnCV.UseVisualStyleBackColor = true;
            // 
            // rdoBtnWB
            // 
            this.rdoBtnWB.AutoSize = true;
            this.rdoBtnWB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnWB.Location = new System.Drawing.Point(13, 264);
            this.rdoBtnWB.Name = "rdoBtnWB";
            this.rdoBtnWB.Size = new System.Drawing.Size(152, 24);
            this.rdoBtnWB.TabIndex = 2;
            this.rdoBtnWB.TabStop = true;
            this.rdoBtnWB.Text = "WOODBRIDGE";
            this.rdoBtnWB.UseVisualStyleBackColor = true;
            // 
            // rdoBtnCH
            // 
            this.rdoBtnCH.AutoSize = true;
            this.rdoBtnCH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnCH.Location = new System.Drawing.Point(13, 144);
            this.rdoBtnCH.Name = "rdoBtnCH";
            this.rdoBtnCH.Size = new System.Drawing.Size(186, 24);
            this.rdoBtnCH.TabIndex = 1;
            this.rdoBtnCH.TabStop = true;
            this.rdoBtnCH.Text = "CAPITOL HEIGHTS";
            this.rdoBtnCH.UseVisualStyleBackColor = true;
            // 
            // rdoBtnOH
            // 
            this.rdoBtnOH.AutoSize = true;
            this.rdoBtnOH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnOH.Location = new System.Drawing.Point(13, 84);
            this.rdoBtnOH.Name = "rdoBtnOH";
            this.rdoBtnOH.Size = new System.Drawing.Size(121, 24);
            this.rdoBtnOH.TabIndex = 0;
            this.rdoBtnOH.TabStop = true;
            this.rdoBtnOH.Text = "OXON HILL";
            this.rdoBtnOH.UseVisualStyleBackColor = true;
            // 
            // rdoBtnTransScannedItems
            // 
            this.rdoBtnTransScannedItems.AutoSize = true;
            this.rdoBtnTransScannedItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnTransScannedItems.Location = new System.Drawing.Point(20, 54);
            this.rdoBtnTransScannedItems.Name = "rdoBtnTransScannedItems";
            this.rdoBtnTransScannedItems.Size = new System.Drawing.Size(328, 29);
            this.rdoBtnTransScannedItems.TabIndex = 10;
            this.rdoBtnTransScannedItems.Text = "TRANSFER SCANNED ITEMS";
            this.rdoBtnTransScannedItems.UseVisualStyleBackColor = true;
            this.rdoBtnTransScannedItems.CheckedChanged += new System.EventHandler(this.rdoBtnTransScannedItems_CheckedChanged);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.WorkerSupportsCancellation = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // chkBoxCostPrice
            // 
            this.chkBoxCostPrice.AutoSize = true;
            this.chkBoxCostPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkBoxCostPrice.Location = new System.Drawing.Point(42, 153);
            this.chkBoxCostPrice.Name = "chkBoxCostPrice";
            this.chkBoxCostPrice.Size = new System.Drawing.Size(134, 24);
            this.chkBoxCostPrice.TabIndex = 11;
            this.chkBoxCostPrice.Text = "COST PRICE";
            this.chkBoxCostPrice.UseVisualStyleBackColor = true;
            // 
            // rdoBtnSyncBrand
            // 
            this.rdoBtnSyncBrand.AutoSize = true;
            this.rdoBtnSyncBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnSyncBrand.Location = new System.Drawing.Point(20, 281);
            this.rdoBtnSyncBrand.Name = "rdoBtnSyncBrand";
            this.rdoBtnSyncBrand.Size = new System.Drawing.Size(169, 29);
            this.rdoBtnSyncBrand.TabIndex = 12;
            this.rdoBtnSyncBrand.Text = "SYNC BRAND";
            this.rdoBtnSyncBrand.UseVisualStyleBackColor = true;
            this.rdoBtnSyncBrand.Visible = false;
            // 
            // rdoBtnSyncSize
            // 
            this.rdoBtnSyncSize.AutoSize = true;
            this.rdoBtnSyncSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnSyncSize.Location = new System.Drawing.Point(20, 316);
            this.rdoBtnSyncSize.Name = "rdoBtnSyncSize";
            this.rdoBtnSyncSize.Size = new System.Drawing.Size(144, 29);
            this.rdoBtnSyncSize.TabIndex = 13;
            this.rdoBtnSyncSize.Text = "SYNC SIZE";
            this.rdoBtnSyncSize.UseVisualStyleBackColor = true;
            this.rdoBtnSyncSize.Visible = false;
            // 
            // rdoBtnSyncColor
            // 
            this.rdoBtnSyncColor.AutoSize = true;
            this.rdoBtnSyncColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnSyncColor.Location = new System.Drawing.Point(20, 351);
            this.rdoBtnSyncColor.Name = "rdoBtnSyncColor";
            this.rdoBtnSyncColor.Size = new System.Drawing.Size(172, 29);
            this.rdoBtnSyncColor.TabIndex = 14;
            this.rdoBtnSyncColor.Text = "SYNC COLOR";
            this.rdoBtnSyncColor.UseVisualStyleBackColor = true;
            this.rdoBtnSyncColor.Visible = false;
            // 
            // rdoBtnSyncVendor
            // 
            this.rdoBtnSyncVendor.AutoSize = true;
            this.rdoBtnSyncVendor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnSyncVendor.Location = new System.Drawing.Point(20, 386);
            this.rdoBtnSyncVendor.Name = "rdoBtnSyncVendor";
            this.rdoBtnSyncVendor.Size = new System.Drawing.Size(186, 29);
            this.rdoBtnSyncVendor.TabIndex = 15;
            this.rdoBtnSyncVendor.Text = "SYNC VENDOR";
            this.rdoBtnSyncVendor.UseVisualStyleBackColor = true;
            this.rdoBtnSyncVendor.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(205, 120);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(173, 339);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.Visible = false;
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.WorkerReportsProgress = true;
            this.backgroundWorker3.WorkerSupportsCancellation = true;
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            this.backgroundWorker3.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker3_ProgressChanged);
            this.backgroundWorker3.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker3_RunWorkerCompleted);
            // 
            // DataTransferOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 522);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.rdoBtnSyncVendor);
            this.Controls.Add(this.rdoBtnSyncColor);
            this.Controls.Add(this.rdoBtnSyncSize);
            this.Controls.Add(this.rdoBtnSyncBrand);
            this.Controls.Add(this.chkBoxCostPrice);
            this.Controls.Add(this.rdoBtnTransScannedItems);
            this.Controls.Add(this.grpDestinationServer);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.chkBoxStylistPrice);
            this.Controls.Add(this.chkBoxRetailPrice);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.rdoBtnTransAll);
            this.Controls.Add(this.rdoBtnTransSelectedFields);
            this.Controls.Add(this.rdoBtnTransNewItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DataTransferOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DATA TRANSFER";
            this.Load += new System.EventHandler(this.DataTransferOption_Load);
            this.grpDestinationServer.ResumeLayout(false);
            this.grpDestinationServer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoBtnTransNewItems;
        private System.Windows.Forms.RadioButton rdoBtnTransSelectedFields;
        private System.Windows.Forms.RadioButton rdoBtnTransAll;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkBoxRetailPrice;
        private System.Windows.Forms.CheckBox chkBoxStylistPrice;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox grpDestinationServer;
        private System.Windows.Forms.RadioButton rdoBtnWM;
        private System.Windows.Forms.RadioButton rdoBtnUM;
        private System.Windows.Forms.RadioButton rdoBtnCV;
        private System.Windows.Forms.RadioButton rdoBtnWB;
        private System.Windows.Forms.RadioButton rdoBtnCH;
        private System.Windows.Forms.RadioButton rdoBtnOH;
        private System.Windows.Forms.RadioButton rdoBtnTest;
        private System.Windows.Forms.RadioButton rdoBtnTransScannedItems;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.RadioButton rdoBtnTH;
        private System.Windows.Forms.RadioButton rdoBtnBeautyCare;
        private System.Windows.Forms.RadioButton rdoBtnB4UWH;
        private System.Windows.Forms.RadioButton rdoBtnWD;
        private System.Windows.Forms.CheckBox chkBoxCostPrice;
        private System.Windows.Forms.RadioButton rdoBtnPW;
        private System.Windows.Forms.RadioButton rdoBtnGB;
        private System.Windows.Forms.RadioButton rdoBtnBW;
        private System.Windows.Forms.RadioButton rdoBtnSyncBrand;
        private System.Windows.Forms.RadioButton rdoBtnSyncSize;
        private System.Windows.Forms.RadioButton rdoBtnSyncColor;
        private System.Windows.Forms.RadioButton rdoBtnSyncVendor;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
    }
}