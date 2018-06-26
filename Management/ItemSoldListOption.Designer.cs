namespace Management
{
    partial class ItemSoldListOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemSoldListOption));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.rdoBtnBottom = new System.Windows.Forms.RadioButton();
            this.rdoBtnTop = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoBtnFalse = new System.Windows.Forms.RadioButton();
            this.rdoBtnAll = new System.Windows.Forms.RadioButton();
            this.rdoBtnTrue = new System.Windows.Forms.RadioButton();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNum);
            this.groupBox1.Controls.Add(this.rdoBtnBottom);
            this.groupBox1.Controls.Add(this.rdoBtnTop);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 220);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TOP/BOTTOM";
            // 
            // txtNum
            // 
            this.txtNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtNum.ForeColor = System.Drawing.Color.Blue;
            this.txtNum.Location = new System.Drawing.Point(8, 160);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(202, 38);
            this.txtNum.TabIndex = 184;
            this.txtNum.Text = "10000";
            this.txtNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rdoBtnBottom
            // 
            this.rdoBtnBottom.Location = new System.Drawing.Point(8, 85);
            this.rdoBtnBottom.Name = "rdoBtnBottom";
            this.rdoBtnBottom.Size = new System.Drawing.Size(144, 60);
            this.rdoBtnBottom.TabIndex = 183;
            this.rdoBtnBottom.Text = "BOTTOM";
            this.rdoBtnBottom.UseVisualStyleBackColor = true;
            this.rdoBtnBottom.Click += new System.EventHandler(this.rdoBtnTop_Click);
            // 
            // rdoBtnTop
            // 
            this.rdoBtnTop.Checked = true;
            this.rdoBtnTop.Location = new System.Drawing.Point(8, 19);
            this.rdoBtnTop.Name = "rdoBtnTop";
            this.rdoBtnTop.Size = new System.Drawing.Size(120, 60);
            this.rdoBtnTop.TabIndex = 181;
            this.rdoBtnTop.TabStop = true;
            this.rdoBtnTop.Text = "TOP";
            this.rdoBtnTop.UseVisualStyleBackColor = true;
            this.rdoBtnTop.Click += new System.EventHandler(this.rdoBtnTop_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoBtnFalse);
            this.groupBox2.Controls.Add(this.rdoBtnAll);
            this.groupBox2.Controls.Add(this.rdoBtnTrue);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(253, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 220);
            this.groupBox2.TabIndex = 184;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ACTIVE";
            // 
            // rdoBtnFalse
            // 
            this.rdoBtnFalse.Location = new System.Drawing.Point(50, 85);
            this.rdoBtnFalse.Name = "rdoBtnFalse";
            this.rdoBtnFalse.Size = new System.Drawing.Size(144, 60);
            this.rdoBtnFalse.TabIndex = 183;
            this.rdoBtnFalse.Text = "FALSE";
            this.rdoBtnFalse.UseVisualStyleBackColor = true;
            this.rdoBtnFalse.Click += new System.EventHandler(this.rdoBtnTop_Click);
            // 
            // rdoBtnAll
            // 
            this.rdoBtnAll.Location = new System.Drawing.Point(50, 148);
            this.rdoBtnAll.Name = "rdoBtnAll";
            this.rdoBtnAll.Size = new System.Drawing.Size(96, 60);
            this.rdoBtnAll.TabIndex = 182;
            this.rdoBtnAll.Text = "ALL";
            this.rdoBtnAll.UseVisualStyleBackColor = true;
            this.rdoBtnAll.Click += new System.EventHandler(this.rdoBtnTop_Click);
            // 
            // rdoBtnTrue
            // 
            this.rdoBtnTrue.Checked = true;
            this.rdoBtnTrue.Location = new System.Drawing.Point(50, 19);
            this.rdoBtnTrue.Name = "rdoBtnTrue";
            this.rdoBtnTrue.Size = new System.Drawing.Size(120, 60);
            this.rdoBtnTrue.TabIndex = 181;
            this.rdoBtnTrue.TabStop = true;
            this.rdoBtnTrue.Text = "TRUE";
            this.rdoBtnTrue.UseVisualStyleBackColor = true;
            this.rdoBtnTrue.Click += new System.EventHandler(this.rdoBtnTop_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSelect.ForeColor = System.Drawing.Color.Black;
            this.btnSelect.Location = new System.Drawing.Point(253, 241);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(107, 50);
            this.btnSelect.TabIndex = 185;
            this.btnSelect.Text = "SELECT";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(366, 241);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 50);
            this.btnClose.TabIndex = 186;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(12, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 50);
            this.label1.TabIndex = 187;
            this.label1.Text = "0 : ALL ITEMS EXCLUDING UNSOLD ITEM";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // ItemSoldListOption
            // 
            this.AcceptButton = this.btnSelect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 302);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ItemSoldListOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ITEM SOLD LIST OPTION";
            this.Load += new System.EventHandler(this.ItemSoldListOption_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoBtnBottom;
        private System.Windows.Forms.RadioButton rdoBtnTop;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoBtnFalse;
        private System.Windows.Forms.RadioButton rdoBtnAll;
        private System.Windows.Forms.RadioButton rdoBtnTrue;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
    }
}