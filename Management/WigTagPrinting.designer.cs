namespace Management
{
    partial class WigTagPrinting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WigTagPrinting));
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.rdoBtnIncludingPrice = new System.Windows.Forms.RadioButton();
            this.rdoBtnNoPrice = new System.Windows.Forms.RadioButton();
            this.rdoBtnPriceTag = new System.Windows.Forms.RadioButton();
            this.rdoBtnNew = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoBtnWigTag3 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPrintPreview.Location = new System.Drawing.Point(293, 13);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(180, 40);
            this.btnPrintPreview.TabIndex = 5;
            this.btnPrintPreview.Text = "PRINT PREVIEW";
            this.btnPrintPreview.UseVisualStyleBackColor = true;
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(293, 111);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(180, 40);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPrint.Location = new System.Drawing.Point(293, 62);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(180, 40);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // rdoBtnIncludingPrice
            // 
            this.rdoBtnIncludingPrice.AutoSize = true;
            this.rdoBtnIncludingPrice.Checked = true;
            this.rdoBtnIncludingPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnIncludingPrice.Location = new System.Drawing.Point(6, 21);
            this.rdoBtnIncludingPrice.Name = "rdoBtnIncludingPrice";
            this.rdoBtnIncludingPrice.Size = new System.Drawing.Size(256, 21);
            this.rdoBtnIncludingPrice.TabIndex = 9;
            this.rdoBtnIncludingPrice.TabStop = true;
            this.rdoBtnIncludingPrice.Text = "WIG TAG 1 - INCLUDING PRICE";
            this.rdoBtnIncludingPrice.UseVisualStyleBackColor = true;
            // 
            // rdoBtnNoPrice
            // 
            this.rdoBtnNoPrice.AutoSize = true;
            this.rdoBtnNoPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnNoPrice.Location = new System.Drawing.Point(6, 44);
            this.rdoBtnNoPrice.Name = "rdoBtnNoPrice";
            this.rdoBtnNoPrice.Size = new System.Drawing.Size(196, 21);
            this.rdoBtnNoPrice.TabIndex = 10;
            this.rdoBtnNoPrice.Text = "WIG TAG 1 - NO PRICE";
            this.rdoBtnNoPrice.UseVisualStyleBackColor = true;
            // 
            // rdoBtnPriceTag
            // 
            this.rdoBtnPriceTag.AutoSize = true;
            this.rdoBtnPriceTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnPriceTag.Location = new System.Drawing.Point(6, 113);
            this.rdoBtnPriceTag.Name = "rdoBtnPriceTag";
            this.rdoBtnPriceTag.Size = new System.Drawing.Size(177, 21);
            this.rdoBtnPriceTag.TabIndex = 11;
            this.rdoBtnPriceTag.Text = "PRICE TAG (1 X 0.5)";
            this.rdoBtnPriceTag.UseVisualStyleBackColor = true;
            // 
            // rdoBtnNew
            // 
            this.rdoBtnNew.AutoSize = true;
            this.rdoBtnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnNew.Location = new System.Drawing.Point(6, 67);
            this.rdoBtnNew.Name = "rdoBtnNew";
            this.rdoBtnNew.Size = new System.Drawing.Size(189, 21);
            this.rdoBtnNew.TabIndex = 12;
            this.rdoBtnNew.Text = "WIG TAG 2 (421 X 69)";
            this.rdoBtnNew.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoBtnWigTag3);
            this.groupBox1.Controls.Add(this.rdoBtnIncludingPrice);
            this.groupBox1.Controls.Add(this.rdoBtnNew);
            this.groupBox1.Controls.Add(this.rdoBtnNoPrice);
            this.groupBox1.Controls.Add(this.rdoBtnPriceTag);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(10, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 146);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "OPTION";
            // 
            // rdoBtnWigTag3
            // 
            this.rdoBtnWigTag3.AutoSize = true;
            this.rdoBtnWigTag3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnWigTag3.Location = new System.Drawing.Point(6, 90);
            this.rdoBtnWigTag3.Name = "rdoBtnWigTag3";
            this.rdoBtnWigTag3.Size = new System.Drawing.Size(189, 21);
            this.rdoBtnWigTag3.TabIndex = 13;
            this.rdoBtnWigTag3.Text = "WIG TAG 3 (421 X 80)";
            this.rdoBtnWigTag3.UseVisualStyleBackColor = true;
            // 
            // WigTagPrinting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 161);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnPrintPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WigTagPrinting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WIG TAG PRINT";
            this.Load += new System.EventHandler(this.WigTagPrinting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrintPreview;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.RadioButton rdoBtnIncludingPrice;
        private System.Windows.Forms.RadioButton rdoBtnNoPrice;
        private System.Windows.Forms.RadioButton rdoBtnPriceTag;
        private System.Windows.Forms.RadioButton rdoBtnNew;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoBtnWigTag3;
    }
}