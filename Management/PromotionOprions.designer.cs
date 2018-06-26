namespace Management
{
    partial class PromotionOprions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PromotionOprions));
            this.rdoBtnPercentOff = new System.Windows.Forms.RadioButton();
            this.rdoBtnMoneyOff = new System.Windows.Forms.RadioButton();
            this.rdoBtnFixedPrice = new System.Windows.Forms.RadioButton();
            this.txtPercentOff = new System.Windows.Forms.TextBox();
            this.txtMoneyOff = new System.Windows.Forms.TextBox();
            this.txtFixedPrice = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGenerateGroupValue = new System.Windows.Forms.Button();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.rdoBtnFalse = new System.Windows.Forms.RadioButton();
            this.rdoBtnTrue = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoBtnPercentOff
            // 
            this.rdoBtnPercentOff.AutoSize = true;
            this.rdoBtnPercentOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnPercentOff.Location = new System.Drawing.Point(8, 36);
            this.rdoBtnPercentOff.Name = "rdoBtnPercentOff";
            this.rdoBtnPercentOff.Size = new System.Drawing.Size(149, 24);
            this.rdoBtnPercentOff.TabIndex = 3;
            this.rdoBtnPercentOff.TabStop = true;
            this.rdoBtnPercentOff.Text = "PERCENT OFF";
            this.rdoBtnPercentOff.UseVisualStyleBackColor = true;
            this.rdoBtnPercentOff.CheckedChanged += new System.EventHandler(this.rdoBtnPercentOff_CheckedChanged);
            // 
            // rdoBtnMoneyOff
            // 
            this.rdoBtnMoneyOff.AutoSize = true;
            this.rdoBtnMoneyOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnMoneyOff.Location = new System.Drawing.Point(8, 79);
            this.rdoBtnMoneyOff.Name = "rdoBtnMoneyOff";
            this.rdoBtnMoneyOff.Size = new System.Drawing.Size(130, 24);
            this.rdoBtnMoneyOff.TabIndex = 4;
            this.rdoBtnMoneyOff.TabStop = true;
            this.rdoBtnMoneyOff.Text = "MONEY OFF";
            this.rdoBtnMoneyOff.UseVisualStyleBackColor = true;
            this.rdoBtnMoneyOff.CheckedChanged += new System.EventHandler(this.rdoBtnMoneyOff_CheckedChanged);
            // 
            // rdoBtnFixedPrice
            // 
            this.rdoBtnFixedPrice.AutoSize = true;
            this.rdoBtnFixedPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnFixedPrice.Location = new System.Drawing.Point(8, 123);
            this.rdoBtnFixedPrice.Name = "rdoBtnFixedPrice";
            this.rdoBtnFixedPrice.Size = new System.Drawing.Size(140, 24);
            this.rdoBtnFixedPrice.TabIndex = 5;
            this.rdoBtnFixedPrice.TabStop = true;
            this.rdoBtnFixedPrice.Text = "FIXED PRICE";
            this.rdoBtnFixedPrice.UseVisualStyleBackColor = true;
            this.rdoBtnFixedPrice.CheckedChanged += new System.EventHandler(this.rdoBtnFixedPrice_CheckedChanged);
            // 
            // txtPercentOff
            // 
            this.txtPercentOff.Enabled = false;
            this.txtPercentOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPercentOff.Location = new System.Drawing.Point(160, 36);
            this.txtPercentOff.Name = "txtPercentOff";
            this.txtPercentOff.Size = new System.Drawing.Size(99, 30);
            this.txtPercentOff.TabIndex = 6;
            this.txtPercentOff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMoneyOff
            // 
            this.txtMoneyOff.Enabled = false;
            this.txtMoneyOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMoneyOff.Location = new System.Drawing.Point(160, 79);
            this.txtMoneyOff.Name = "txtMoneyOff";
            this.txtMoneyOff.Size = new System.Drawing.Size(99, 30);
            this.txtMoneyOff.TabIndex = 7;
            this.txtMoneyOff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFixedPrice
            // 
            this.txtFixedPrice.Enabled = false;
            this.txtFixedPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtFixedPrice.Location = new System.Drawing.Point(160, 123);
            this.txtFixedPrice.Name = "txtFixedPrice";
            this.txtFixedPrice.Size = new System.Drawing.Size(99, 30);
            this.txtFixedPrice.TabIndex = 8;
            this.txtFixedPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoBtnPercentOff);
            this.groupBox1.Controls.Add(this.txtFixedPrice);
            this.groupBox1.Controls.Add(this.rdoBtnMoneyOff);
            this.groupBox1.Controls.Add(this.txtMoneyOff);
            this.groupBox1.Controls.Add(this.rdoBtnFixedPrice);
            this.groupBox1.Controls.Add(this.txtPercentOff);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(371, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 171);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "OPTION";
            // 
            // btnSet
            // 
            this.btnSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSet.Location = new System.Drawing.Point(432, 189);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(100, 40);
            this.btnSet.TabIndex = 10;
            this.btnSet.Text = "SET";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(538, 189);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGenerateGroupValue);
            this.groupBox2.Controls.Add(this.txtQty);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtValue);
            this.groupBox2.Controls.Add(this.rdoBtnFalse);
            this.groupBox2.Controls.Add(this.rdoBtnTrue);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(8, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(355, 171);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MIX AND MATCH";
            // 
            // btnGenerateGroupValue
            // 
            this.btnGenerateGroupValue.Enabled = false;
            this.btnGenerateGroupValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnGenerateGroupValue.Location = new System.Drawing.Point(261, 74);
            this.btnGenerateGroupValue.Name = "btnGenerateGroupValue";
            this.btnGenerateGroupValue.Size = new System.Drawing.Size(88, 30);
            this.btnGenerateGroupValue.TabIndex = 14;
            this.btnGenerateGroupValue.Text = "GENERATE";
            this.btnGenerateGroupValue.UseVisualStyleBackColor = true;
            this.btnGenerateGroupValue.Click += new System.EventHandler(this.btnGenerateGroupValue_Click);
            // 
            // txtQty
            // 
            this.txtQty.Enabled = false;
            this.txtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtQty.Location = new System.Drawing.Point(150, 117);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(109, 30);
            this.txtQty.TabIndex = 13;
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(6, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 30);
            this.label2.TabIndex = 12;
            this.label2.Text = "CONDITION QTY";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(6, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 30);
            this.label1.TabIndex = 11;
            this.label1.Text = "GROUP VALUE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtValue
            // 
            this.txtValue.Enabled = false;
            this.txtValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtValue.Location = new System.Drawing.Point(150, 74);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(109, 30);
            this.txtValue.TabIndex = 9;
            this.txtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rdoBtnFalse
            // 
            this.rdoBtnFalse.AutoSize = true;
            this.rdoBtnFalse.Checked = true;
            this.rdoBtnFalse.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnFalse.Location = new System.Drawing.Point(6, 33);
            this.rdoBtnFalse.Name = "rdoBtnFalse";
            this.rdoBtnFalse.Size = new System.Drawing.Size(99, 29);
            this.rdoBtnFalse.TabIndex = 10;
            this.rdoBtnFalse.TabStop = true;
            this.rdoBtnFalse.Text = "FALSE";
            this.rdoBtnFalse.UseVisualStyleBackColor = true;
            this.rdoBtnFalse.CheckedChanged += new System.EventHandler(this.rdoBtnFalse_CheckedChanged);
            // 
            // rdoBtnTrue
            // 
            this.rdoBtnTrue.AutoSize = true;
            this.rdoBtnTrue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoBtnTrue.Location = new System.Drawing.Point(153, 33);
            this.rdoBtnTrue.Name = "rdoBtnTrue";
            this.rdoBtnTrue.Size = new System.Drawing.Size(87, 29);
            this.rdoBtnTrue.TabIndex = 9;
            this.rdoBtnTrue.Text = "TRUE";
            this.rdoBtnTrue.UseVisualStyleBackColor = true;
            this.rdoBtnTrue.CheckedChanged += new System.EventHandler(this.rdoBtnTrue_CheckedChanged);
            // 
            // PromotionOprions
            // 
            this.AcceptButton = this.btnSet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(643, 243);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PromotionOprions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PROMOTION OPTION";
            this.Load += new System.EventHandler(this.PromotionOprions_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoBtnPercentOff;
        private System.Windows.Forms.RadioButton rdoBtnMoneyOff;
        private System.Windows.Forms.RadioButton rdoBtnFixedPrice;
        private System.Windows.Forms.TextBox txtPercentOff;
        private System.Windows.Forms.TextBox txtMoneyOff;
        private System.Windows.Forms.TextBox txtFixedPrice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.RadioButton rdoBtnFalse;
        private System.Windows.Forms.RadioButton rdoBtnTrue;
        private System.Windows.Forms.Button btnGenerateGroupValue;
    }
}