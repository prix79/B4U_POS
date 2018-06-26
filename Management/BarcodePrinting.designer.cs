namespace Management
{
    partial class BarcodePrinting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BarcodePrinting));
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.btnBarcode = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoBtnOpt2 = new System.Windows.Forms.RadioButton();
            this.rdoBtnOpt1 = new System.Windows.Forms.RadioButton();
            this.barcode1 = new IDAutomation.Windows.Forms.LinearBarCode.Barcode();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(120, 197);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(109, 20);
            this.txtBarcode.TabIndex = 0;
            this.txtBarcode.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPrint.Location = new System.Drawing.Point(200, 12);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(179, 150);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "INPUT BARCODE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(4, 251);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPrintPreview.Location = new System.Drawing.Point(7, 12);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(179, 150);
            this.btnPrintPreview.TabIndex = 4;
            this.btnPrintPreview.Text = "PRINT PREVIEW";
            this.btnPrintPreview.UseVisualStyleBackColor = true;
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // btnBarcode
            // 
            this.btnBarcode.Location = new System.Drawing.Point(7, 222);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Size = new System.Drawing.Size(222, 23);
            this.btnBarcode.TabIndex = 5;
            this.btnBarcode.Text = "MAKE BARCODE";
            this.btnBarcode.UseVisualStyleBackColor = true;
            this.btnBarcode.Visible = false;
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.Location = new System.Drawing.Point(200, 174);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(179, 150);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoBtnOpt2);
            this.groupBox1.Controls.Add(this.rdoBtnOpt1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(7, 166);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(179, 158);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PRINT OPTION";
            // 
            // rdoBtnOpt2
            // 
            this.rdoBtnOpt2.AutoSize = true;
            this.rdoBtnOpt2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnOpt2.Location = new System.Drawing.Point(31, 85);
            this.rdoBtnOpt2.Name = "rdoBtnOpt2";
            this.rdoBtnOpt2.Size = new System.Drawing.Size(105, 28);
            this.rdoBtnOpt2.TabIndex = 1;
            this.rdoBtnOpt2.Text = "1 BY 0.5";
            this.rdoBtnOpt2.UseVisualStyleBackColor = true;
            // 
            // rdoBtnOpt1
            // 
            this.rdoBtnOpt1.AutoSize = true;
            this.rdoBtnOpt1.Checked = true;
            this.rdoBtnOpt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnOpt1.Location = new System.Drawing.Point(31, 46);
            this.rdoBtnOpt1.Name = "rdoBtnOpt1";
            this.rdoBtnOpt1.Size = new System.Drawing.Size(88, 28);
            this.rdoBtnOpt1.TabIndex = 0;
            this.rdoBtnOpt1.TabStop = true;
            this.rdoBtnOpt1.Text = "2 BY 1";
            this.rdoBtnOpt1.UseVisualStyleBackColor = true;
            // 
            // barcode1
            // 
            this.barcode1.ApplyTilde = true;
            this.barcode1.BarHeightCM = 1F;
            this.barcode1.BearerBarHorizontal = 0;
            this.barcode1.BearerBarVertical = 0;
            this.barcode1.CaptionAbove = "";
            this.barcode1.CaptionBelow = "";
            this.barcode1.CaptionBottomAlignment = System.Drawing.StringAlignment.Center;
            this.barcode1.CaptionBottomColor = System.Drawing.Color.Black;
            this.barcode1.CaptionBottomSpace = 0.1F;
            this.barcode1.CaptionFontAbove = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.barcode1.CaptionFontBelow = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.barcode1.CaptionTopAlignment = System.Drawing.StringAlignment.Center;
            this.barcode1.CaptionTopColor = System.Drawing.Color.Black;
            this.barcode1.CaptionTopSpace = 0.1F;
            this.barcode1.CharacterGrouping = 0;
            this.barcode1.CheckCharacter = false;
            this.barcode1.CheckCharacterInText = true;
            this.barcode1.CODABARStartChar = "A";
            this.barcode1.CODABARStopChar = "B";
            this.barcode1.Code128Set = IDAutomation.Windows.Forms.LinearBarCode.Code128CharacterSets.Auto;
            this.barcode1.DataToEncode = "123456789012";
            this.barcode1.DoPaint = true;
            this.barcode1.FitControlToBarcode = true;
            this.barcode1.LeftMarginCM = 0.2F;
            this.barcode1.Location = new System.Drawing.Point(182, 260);
            this.barcode1.Name = "barcode1";
            this.barcode1.NarrowToWideRatio = 2F;
            this.barcode1.OneBitPerPixelImage = false;
            this.barcode1.PostnetHeightShort = 0.127F;
            this.barcode1.PostnetHeightTall = 0.3226F;
            this.barcode1.PostnetSpacing = 0.065F;
            this.barcode1.Resolution = IDAutomation.Windows.Forms.LinearBarCode.Resolutions.Printer;
            this.barcode1.ResolutionCustomDPI = 203F;
            this.barcode1.ResolutionPrinterToUse = "";
            this.barcode1.RotationAngle = IDAutomation.Windows.Forms.LinearBarCode.RotationAngles.Zero_Degrees;
            this.barcode1.ShowText = true;
            this.barcode1.ShowTextLocation = IDAutomation.Windows.Forms.LinearBarCode.HRTextPositions.Bottom;
            this.barcode1.Size = new System.Drawing.Size(197, 74);
            this.barcode1.SuppSeparationCM = 0.5F;
            this.barcode1.SymbologyID = IDAutomation.Windows.Forms.LinearBarCode.Symbologies.Code39;
            this.barcode1.TabIndex = 2;
            this.barcode1.TextFontColor = System.Drawing.Color.Black;
            this.barcode1.TextMarginCM = 0.1F;
            this.barcode1.TopMarginCM = 0.2F;
            this.barcode1.UPCESystem = "0";
            this.barcode1.Visible = false;
            this.barcode1.WhiteBarIncrease = 0F;
            this.barcode1.XDimensionCM = 0.0299F;
            this.barcode1.XDimensionMILS = 0.0761F;
            // 
            // BarcodePrinting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 335);
            this.ControlBox = false;
            this.Controls.Add(this.barcode1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBarcode);
            this.Controls.Add(this.btnPrintPreview);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtBarcode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BarcodePrinting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BARCODE PRINT";
            this.Load += new System.EventHandler(this.BarcodePrinting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnPrintPreview;
        private System.Windows.Forms.Button btnBarcode;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoBtnOpt2;
        private System.Windows.Forms.RadioButton rdoBtnOpt1;
        private IDAutomation.Windows.Forms.LinearBarCode.Barcode barcode1;
    }
}