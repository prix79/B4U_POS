namespace Management
{
    partial class TargetField
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TargetField));
            this.rdoBtnOnHand = new System.Windows.Forms.RadioButton();
            this.rdoBtnRetailPrice = new System.Windows.Forms.RadioButton();
            this.rdoBtnBinNumber = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.grpBoxCommon = new System.Windows.Forms.GroupBox();
            this.rdoBtnSubBrand = new System.Windows.Forms.RadioButton();
            this.rdoBtnVendor = new System.Windows.Forms.RadioButton();
            this.rdoBtnActive = new System.Windows.Forms.RadioButton();
            this.rdoBtnModelNum = new System.Windows.Forms.RadioButton();
            this.rdoBtnBrand = new System.Windows.Forms.RadioButton();
            this.rdoBtnItemName = new System.Windows.Forms.RadioButton();
            this.rdoBtnCostPrice = new System.Windows.Forms.RadioButton();
            this.rdoBtnStylistPrice = new System.Windows.Forms.RadioButton();
            this.rdoBtnCategory1 = new System.Windows.Forms.RadioButton();
            this.rdoBtnCategory2 = new System.Windows.Forms.RadioButton();
            this.rdoBtnCategory3 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.grpBoxCommon.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoBtnOnHand
            // 
            this.rdoBtnOnHand.AutoSize = true;
            this.rdoBtnOnHand.Checked = true;
            this.rdoBtnOnHand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnOnHand.Location = new System.Drawing.Point(15, 11);
            this.rdoBtnOnHand.Name = "rdoBtnOnHand";
            this.rdoBtnOnHand.Size = new System.Drawing.Size(107, 24);
            this.rdoBtnOnHand.TabIndex = 0;
            this.rdoBtnOnHand.TabStop = true;
            this.rdoBtnOnHand.Text = "ON HAND";
            this.rdoBtnOnHand.UseVisualStyleBackColor = true;
            this.rdoBtnOnHand.CheckedChanged += new System.EventHandler(this.rdoBtnOnHand_CheckedChanged);
            // 
            // rdoBtnRetailPrice
            // 
            this.rdoBtnRetailPrice.AutoSize = true;
            this.rdoBtnRetailPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnRetailPrice.Location = new System.Drawing.Point(447, 11);
            this.rdoBtnRetailPrice.Name = "rdoBtnRetailPrice";
            this.rdoBtnRetailPrice.Size = new System.Drawing.Size(149, 24);
            this.rdoBtnRetailPrice.TabIndex = 10;
            this.rdoBtnRetailPrice.Text = "RETAIL PRICE";
            this.rdoBtnRetailPrice.UseVisualStyleBackColor = true;
            this.rdoBtnRetailPrice.CheckedChanged += new System.EventHandler(this.rdoBtnOnHand_CheckedChanged);
            // 
            // rdoBtnBinNumber
            // 
            this.rdoBtnBinNumber.AutoSize = true;
            this.rdoBtnBinNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnBinNumber.Location = new System.Drawing.Point(15, 45);
            this.rdoBtnBinNumber.Name = "rdoBtnBinNumber";
            this.rdoBtnBinNumber.Size = new System.Drawing.Size(72, 24);
            this.rdoBtnBinNumber.TabIndex = 1;
            this.rdoBtnBinNumber.Text = "BIN #";
            this.rdoBtnBinNumber.UseVisualStyleBackColor = true;
            this.rdoBtnBinNumber.CheckedChanged += new System.EventHandler(this.rdoBtnOnHand_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOK.Location = new System.Drawing.Point(369, 188);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(130, 30);
            this.btnOK.TabIndex = 15;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(505, 188);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 30);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtValue
            // 
            this.txtValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtValue.Location = new System.Drawing.Point(131, 188);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(232, 30);
            this.txtValue.TabIndex = 14;
            // 
            // grpBoxCommon
            // 
            this.grpBoxCommon.Controls.Add(this.rdoBtnSubBrand);
            this.grpBoxCommon.Controls.Add(this.rdoBtnVendor);
            this.grpBoxCommon.Controls.Add(this.rdoBtnActive);
            this.grpBoxCommon.Controls.Add(this.rdoBtnModelNum);
            this.grpBoxCommon.Controls.Add(this.rdoBtnBrand);
            this.grpBoxCommon.Controls.Add(this.rdoBtnItemName);
            this.grpBoxCommon.Controls.Add(this.rdoBtnCostPrice);
            this.grpBoxCommon.Controls.Add(this.rdoBtnStylistPrice);
            this.grpBoxCommon.Controls.Add(this.rdoBtnCategory1);
            this.grpBoxCommon.Controls.Add(this.rdoBtnCategory2);
            this.grpBoxCommon.Controls.Add(this.rdoBtnCategory3);
            this.grpBoxCommon.Controls.Add(this.rdoBtnOnHand);
            this.grpBoxCommon.Controls.Add(this.rdoBtnRetailPrice);
            this.grpBoxCommon.Controls.Add(this.rdoBtnBinNumber);
            this.grpBoxCommon.Location = new System.Drawing.Point(8, -1);
            this.grpBoxCommon.Name = "grpBoxCommon";
            this.grpBoxCommon.Size = new System.Drawing.Size(627, 176);
            this.grpBoxCommon.TabIndex = 12;
            this.grpBoxCommon.TabStop = false;
            // 
            // rdoBtnSubBrand
            // 
            this.rdoBtnSubBrand.AutoSize = true;
            this.rdoBtnSubBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnSubBrand.Location = new System.Drawing.Point(15, 144);
            this.rdoBtnSubBrand.Name = "rdoBtnSubBrand";
            this.rdoBtnSubBrand.Size = new System.Drawing.Size(131, 24);
            this.rdoBtnSubBrand.TabIndex = 4;
            this.rdoBtnSubBrand.TabStop = true;
            this.rdoBtnSubBrand.Text = "SUB BRAND";
            this.rdoBtnSubBrand.UseVisualStyleBackColor = true;
            // 
            // rdoBtnVendor
            // 
            this.rdoBtnVendor.AutoSize = true;
            this.rdoBtnVendor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnVendor.Location = new System.Drawing.Point(216, 144);
            this.rdoBtnVendor.Name = "rdoBtnVendor";
            this.rdoBtnVendor.Size = new System.Drawing.Size(102, 24);
            this.rdoBtnVendor.TabIndex = 9;
            this.rdoBtnVendor.TabStop = true;
            this.rdoBtnVendor.Text = "VENDOR";
            this.rdoBtnVendor.UseVisualStyleBackColor = true;
            // 
            // rdoBtnActive
            // 
            this.rdoBtnActive.AutoSize = true;
            this.rdoBtnActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnActive.Location = new System.Drawing.Point(447, 113);
            this.rdoBtnActive.Name = "rdoBtnActive";
            this.rdoBtnActive.Size = new System.Drawing.Size(91, 24);
            this.rdoBtnActive.TabIndex = 13;
            this.rdoBtnActive.TabStop = true;
            this.rdoBtnActive.Text = "ACTIVE";
            this.rdoBtnActive.UseVisualStyleBackColor = true;
            this.rdoBtnActive.CheckedChanged += new System.EventHandler(this.rdoBtnOnHand_CheckedChanged);
            // 
            // rdoBtnModelNum
            // 
            this.rdoBtnModelNum.AutoSize = true;
            this.rdoBtnModelNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnModelNum.Location = new System.Drawing.Point(216, 111);
            this.rdoBtnModelNum.Name = "rdoBtnModelNum";
            this.rdoBtnModelNum.Size = new System.Drawing.Size(170, 24);
            this.rdoBtnModelNum.TabIndex = 8;
            this.rdoBtnModelNum.TabStop = true;
            this.rdoBtnModelNum.Text = "MODEL NUMBER";
            this.rdoBtnModelNum.UseVisualStyleBackColor = true;
            this.rdoBtnModelNum.CheckedChanged += new System.EventHandler(this.rdoBtnOnHand_CheckedChanged);
            // 
            // rdoBtnBrand
            // 
            this.rdoBtnBrand.AutoSize = true;
            this.rdoBtnBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnBrand.Location = new System.Drawing.Point(15, 111);
            this.rdoBtnBrand.Name = "rdoBtnBrand";
            this.rdoBtnBrand.Size = new System.Drawing.Size(89, 24);
            this.rdoBtnBrand.TabIndex = 3;
            this.rdoBtnBrand.TabStop = true;
            this.rdoBtnBrand.Text = "BRAND";
            this.rdoBtnBrand.UseVisualStyleBackColor = true;
            this.rdoBtnBrand.CheckedChanged += new System.EventHandler(this.rdoBtnOnHand_CheckedChanged);
            // 
            // rdoBtnItemName
            // 
            this.rdoBtnItemName.AutoSize = true;
            this.rdoBtnItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnItemName.Location = new System.Drawing.Point(15, 78);
            this.rdoBtnItemName.Name = "rdoBtnItemName";
            this.rdoBtnItemName.Size = new System.Drawing.Size(124, 24);
            this.rdoBtnItemName.TabIndex = 2;
            this.rdoBtnItemName.TabStop = true;
            this.rdoBtnItemName.Text = "ITEM NAME";
            this.rdoBtnItemName.UseVisualStyleBackColor = true;
            this.rdoBtnItemName.CheckedChanged += new System.EventHandler(this.rdoBtnOnHand_CheckedChanged);
            // 
            // rdoBtnCostPrice
            // 
            this.rdoBtnCostPrice.AutoSize = true;
            this.rdoBtnCostPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnCostPrice.Location = new System.Drawing.Point(447, 45);
            this.rdoBtnCostPrice.Name = "rdoBtnCostPrice";
            this.rdoBtnCostPrice.Size = new System.Drawing.Size(133, 24);
            this.rdoBtnCostPrice.TabIndex = 11;
            this.rdoBtnCostPrice.TabStop = true;
            this.rdoBtnCostPrice.Text = "COST PRICE";
            this.rdoBtnCostPrice.UseVisualStyleBackColor = true;
            this.rdoBtnCostPrice.CheckedChanged += new System.EventHandler(this.rdoBtnOnHand_CheckedChanged);
            // 
            // rdoBtnStylistPrice
            // 
            this.rdoBtnStylistPrice.AutoSize = true;
            this.rdoBtnStylistPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnStylistPrice.Location = new System.Drawing.Point(447, 78);
            this.rdoBtnStylistPrice.Name = "rdoBtnStylistPrice";
            this.rdoBtnStylistPrice.Size = new System.Drawing.Size(158, 24);
            this.rdoBtnStylistPrice.TabIndex = 12;
            this.rdoBtnStylistPrice.TabStop = true;
            this.rdoBtnStylistPrice.Text = "STYLIST PRICE";
            this.rdoBtnStylistPrice.UseVisualStyleBackColor = true;
            this.rdoBtnStylistPrice.CheckedChanged += new System.EventHandler(this.rdoBtnOnHand_CheckedChanged);
            // 
            // rdoBtnCategory1
            // 
            this.rdoBtnCategory1.AutoSize = true;
            this.rdoBtnCategory1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnCategory1.Location = new System.Drawing.Point(216, 11);
            this.rdoBtnCategory1.Name = "rdoBtnCategory1";
            this.rdoBtnCategory1.Size = new System.Drawing.Size(140, 24);
            this.rdoBtnCategory1.TabIndex = 5;
            this.rdoBtnCategory1.TabStop = true;
            this.rdoBtnCategory1.Text = "CATEGORY 1";
            this.rdoBtnCategory1.UseVisualStyleBackColor = true;
            this.rdoBtnCategory1.CheckedChanged += new System.EventHandler(this.rdoBtnOnHand_CheckedChanged);
            // 
            // rdoBtnCategory2
            // 
            this.rdoBtnCategory2.AutoSize = true;
            this.rdoBtnCategory2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnCategory2.Location = new System.Drawing.Point(216, 45);
            this.rdoBtnCategory2.Name = "rdoBtnCategory2";
            this.rdoBtnCategory2.Size = new System.Drawing.Size(140, 24);
            this.rdoBtnCategory2.TabIndex = 6;
            this.rdoBtnCategory2.TabStop = true;
            this.rdoBtnCategory2.Text = "CATEGORY 2";
            this.rdoBtnCategory2.UseVisualStyleBackColor = true;
            this.rdoBtnCategory2.CheckedChanged += new System.EventHandler(this.rdoBtnOnHand_CheckedChanged);
            // 
            // rdoBtnCategory3
            // 
            this.rdoBtnCategory3.AutoSize = true;
            this.rdoBtnCategory3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnCategory3.Location = new System.Drawing.Point(216, 78);
            this.rdoBtnCategory3.Name = "rdoBtnCategory3";
            this.rdoBtnCategory3.Size = new System.Drawing.Size(140, 24);
            this.rdoBtnCategory3.TabIndex = 7;
            this.rdoBtnCategory3.TabStop = true;
            this.rdoBtnCategory3.Text = "CATEGORY 3";
            this.rdoBtnCategory3.UseVisualStyleBackColor = true;
            this.rdoBtnCategory3.CheckedChanged += new System.EventHandler(this.rdoBtnOnHand_CheckedChanged);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(8, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 30);
            this.label1.TabIndex = 14;
            this.label1.Text = "VALUE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TargetField
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 229);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpBoxCommon);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TargetField";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TARGET FIELD";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.TargetField_Load);
            this.grpBoxCommon.ResumeLayout(false);
            this.grpBoxCommon.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoBtnOnHand;
        private System.Windows.Forms.RadioButton rdoBtnRetailPrice;
        private System.Windows.Forms.RadioButton rdoBtnBinNumber;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.GroupBox grpBoxCommon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoBtnCategory1;
        private System.Windows.Forms.RadioButton rdoBtnCategory2;
        private System.Windows.Forms.RadioButton rdoBtnCategory3;
        private System.Windows.Forms.RadioButton rdoBtnModelNum;
        private System.Windows.Forms.RadioButton rdoBtnBrand;
        private System.Windows.Forms.RadioButton rdoBtnItemName;
        private System.Windows.Forms.RadioButton rdoBtnCostPrice;
        private System.Windows.Forms.RadioButton rdoBtnStylistPrice;
        private System.Windows.Forms.RadioButton rdoBtnActive;
        private System.Windows.Forms.RadioButton rdoBtnVendor;
        private System.Windows.Forms.RadioButton rdoBtnSubBrand;
    }
}