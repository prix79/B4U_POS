// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 03-24-2011
// ***********************************************************************
// <copyright file="BasicSetup.Designer.cs" company="Beauty4u">
//     Copyright © Beauty4u 2009
// </copyright>
// <summary></summary>
// ***********************************************************************
/// <summary>
/// The Register namespace.
/// </summary>
namespace Register
{
    /// <summary>
    /// Class BasicSetup.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class BasicSetup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        /// <summary>
        /// The components
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /// <summary>
        /// Disposes of the resources (other than memory) used by the <see cref="T:System.Windows.Forms.Form" />.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
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
        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasicSetup));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSaveStoreBasicSetup = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.btnSaveShortcutKey = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnSaveHardwareSetup = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridView1.ColumnHeadersHeight = 45;
            this.dataGridView1.Location = new System.Drawing.Point(2, 36);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(890, 119);
            this.dataGridView1.TabIndex = 15;
            // 
            // btnSaveStoreBasicSetup
            // 
            this.btnSaveStoreBasicSetup.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSaveStoreBasicSetup.Location = new System.Drawing.Point(758, 160);
            this.btnSaveStoreBasicSetup.Name = "btnSaveStoreBasicSetup";
            this.btnSaveStoreBasicSetup.Size = new System.Drawing.Size(134, 45);
            this.btnSaveStoreBasicSetup.TabIndex = 16;
            this.btnSaveStoreBasicSetup.Text = "SAVE";
            this.btnSaveStoreBasicSetup.UseVisualStyleBackColor = true;
            this.btnSaveStoreBasicSetup.Click += new System.EventHandler(this.btnSaveStoreBasicSetup_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridView3.ColumnHeadersHeight = 45;
            this.dataGridView3.Location = new System.Drawing.Point(2, 461);
            this.dataGridView3.MultiSelect = false;
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.Size = new System.Drawing.Size(890, 119);
            this.dataGridView3.TabIndex = 17;
            // 
            // btnSaveShortcutKey
            // 
            this.btnSaveShortcutKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSaveShortcutKey.Location = new System.Drawing.Point(618, 585);
            this.btnSaveShortcutKey.Name = "btnSaveShortcutKey";
            this.btnSaveShortcutKey.Size = new System.Drawing.Size(134, 45);
            this.btnSaveShortcutKey.TabIndex = 19;
            this.btnSaveShortcutKey.Text = "SAVE";
            this.btnSaveShortcutKey.UseVisualStyleBackColor = true;
            this.btnSaveShortcutKey.Click += new System.EventHandler(this.btnSaveShortcutKey_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(758, 585);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(134, 45);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(404, 32);
            this.label1.TabIndex = 20;
            this.label1.Text = "CASH REGISTER MAIN PARAMETERS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(2, 426);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 32);
            this.label2.TabIndex = 21;
            this.label2.Text = "FUNCTION KEY SETUP";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(2, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(217, 32);
            this.label3.TabIndex = 23;
            this.label3.Text = "HARDWARE SETUP";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridView2.ColumnHeadersHeight = 45;
            this.dataGridView2.Location = new System.Drawing.Point(2, 249);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(890, 119);
            this.dataGridView2.TabIndex = 22;
            // 
            // btnSaveHardwareSetup
            // 
            this.btnSaveHardwareSetup.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSaveHardwareSetup.Location = new System.Drawing.Point(758, 374);
            this.btnSaveHardwareSetup.Name = "btnSaveHardwareSetup";
            this.btnSaveHardwareSetup.Size = new System.Drawing.Size(134, 45);
            this.btnSaveHardwareSetup.TabIndex = 24;
            this.btnSaveHardwareSetup.Text = "SAVE";
            this.btnSaveHardwareSetup.UseVisualStyleBackColor = true;
            this.btnSaveHardwareSetup.Click += new System.EventHandler(this.btnSaveHardwareSetup_Click);
            // 
            // BasicSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(892, 635);
            this.ControlBox = false;
            this.Controls.Add(this.btnSaveHardwareSetup);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveShortcutKey);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.btnSaveStoreBasicSetup);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BasicSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BASIC SETUP";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.BasicSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The data grid view1
        /// </summary>
        private System.Windows.Forms.DataGridView dataGridView1;
        /// <summary>
        /// The BTN save store basic setup
        /// </summary>
        private System.Windows.Forms.Button btnSaveStoreBasicSetup;
        /// <summary>
        /// The data grid view3
        /// </summary>
        private System.Windows.Forms.DataGridView dataGridView3;
        /// <summary>
        /// The BTN save shortcut key
        /// </summary>
        private System.Windows.Forms.Button btnSaveShortcutKey;
        /// <summary>
        /// The BTN close
        /// </summary>
        private System.Windows.Forms.Button btnClose;
        /// <summary>
        /// The label1
        /// </summary>
        private System.Windows.Forms.Label label1;
        /// <summary>
        /// The label2
        /// </summary>
        private System.Windows.Forms.Label label2;
        /// <summary>
        /// The label3
        /// </summary>
        private System.Windows.Forms.Label label3;
        /// <summary>
        /// The data grid view2
        /// </summary>
        private System.Windows.Forms.DataGridView dataGridView2;
        /// <summary>
        /// The BTN save hardware setup
        /// </summary>
        private System.Windows.Forms.Button btnSaveHardwareSetup;
    }
}