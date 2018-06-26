using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using Office_12 = Microsoft.Office.Core;
using Excel_12 = Microsoft.Office.Interop.Excel;
using System.Globalization;

namespace Management
{
    public partial class ItemSoldList : Form
    {
        public LogInManagements parentForm;
        public POandReceiving parentForm2;
        int formOpt = 0;
        NumberFormatInfo nfi = new NumberFormatInfo();
        SqlCommand cmd;
        SqlDataAdapter adapt;
        DataTable dt = new DataTable();
        DataTable dt2_All = new DataTable();

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblNumberOfItems;
        private System.Windows.Forms.Label lblTotalSoldSales;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotalSoldQty;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalDiscount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ProgressBar progressBar1;

        int index1, index2, index3;
        string sp;
        string ItmBrand, ItmColor, ItmSize, ItmName, ItmUpc;
        int brandBoolNum, sizeBoolNum, colorBoolNum, nameBoolNum, upcBoolNum, totalBoolNum;

        Int64 totalSoldQty;
        double totalDiscount, totalSoldSales;

        public int optTopBottom = 0; 
        public Int64 intNum = 0;
        public int optTrueFalse = 0;

        string ItmPOBrand, ItmPOName, ItmPOSize, ItmPOColor, ItmPOModel, ItmPOUpc, ItmPOBin;
        Int64 ItmPOOnHand = 0, ItmPOSoldQty = 0;
        double ItmPORetailPrice = 0, ItmPOCostPrice = 0;

        bool c;

        public Int64 totalQty = 0;
        public double totalCost = 0;

        int selectedcount = 0;
        int oldcount = 0;

        public ItemSoldList(int opt)
        {
            InitializeComponent();
            formOpt = opt;
        }

        private void ItemSoldList_Load(object sender, EventArgs e)
        {
            //this.Text = "ITEM SOLD LIST - " + parentForm.employeeID + " LOGGED IN " + parentForm.storeName;

            dt2_All.Columns.Add("Brand", typeof(string));
            dt2_All.Columns.Add("Name", typeof(string));
            dt2_All.Columns.Add("Size", typeof(string));
            dt2_All.Columns.Add("Color", typeof(string));
            dt2_All.Columns.Add("Model #", typeof(string));
            dt2_All.Columns.Add("UPC", typeof(string));
            dt2_All.Columns.Add("Retail Price", typeof(double));
            dt2_All.Columns.Add("Cost Price", typeof(double));
            dt2_All.Columns.Add("On Hand", typeof(Int64));
            dt2_All.Columns.Add("Sold Qty", typeof(Int64));
            dt2_All.Columns.Add("Order Qty", typeof(Int64));
            dt2_All.Columns.Add("Order Amount", typeof(double));
            dt2_All.Columns.Add("Bin #", typeof(string));

            if (formOpt == 0)
            {
                this.Text = "ITEM SOLD LIST FOR P/O - " + parentForm.employeeID + " LOGGED IN " + parentForm.storeName;

                this.lblNumberOfItems = new System.Windows.Forms.Label();
                this.label9 = new System.Windows.Forms.Label();
                this.lblTotalSoldSales = new System.Windows.Forms.Label();
                this.label8 = new System.Windows.Forms.Label();
                this.lblTotalSoldQty = new System.Windows.Forms.Label();
                this.label7 = new System.Windows.Forms.Label();
                this.lblTotalDiscount = new System.Windows.Forms.Label();
                this.label10 = new System.Windows.Forms.Label();
                this.progressBar1 = new System.Windows.Forms.ProgressBar();

                this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                this.label9.Location = new System.Drawing.Point(2, 372);
                this.label9.Name = "label9";
                this.label9.Size = new System.Drawing.Size(90, 36);
                this.label9.TabIndex = 206;
                this.label9.Text = "NUMBER OF ITEMS";
                this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                this.lblNumberOfItems.BackColor = System.Drawing.Color.White;
                this.lblNumberOfItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.lblNumberOfItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                this.lblNumberOfItems.Location = new System.Drawing.Point(93, 372);
                this.lblNumberOfItems.Name = "lblNumberOfItems";
                this.lblNumberOfItems.Size = new System.Drawing.Size(100, 36);
                this.lblNumberOfItems.TabIndex = 207;
                this.lblNumberOfItems.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                this.label7.Location = new System.Drawing.Point(201, 372);
                this.label7.Name = "label7";
                this.label7.Size = new System.Drawing.Size(90, 36);
                this.label7.TabIndex = 191;
                this.label7.Text = "TOTAL SOLD QTY";
                this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                this.lblTotalSoldQty.BackColor = System.Drawing.Color.White;
                this.lblTotalSoldQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.lblTotalSoldQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                this.lblTotalSoldQty.Location = new System.Drawing.Point(292, 372);
                this.lblTotalSoldQty.Name = "lblTotalSoldQty";
                this.lblTotalSoldQty.Size = new System.Drawing.Size(100, 36);
                this.lblTotalSoldQty.TabIndex = 192;
                this.lblTotalSoldQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                this.label10.Location = new System.Drawing.Point(433, 372);
                this.label10.Name = "label10";
                this.label10.Size = new System.Drawing.Size(90, 36);
                this.label10.TabIndex = 195;
                this.label10.Text = "TOTAL DISCOUNT";
                this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                this.lblTotalDiscount.BackColor = System.Drawing.Color.White;
                this.lblTotalDiscount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.lblTotalDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                this.lblTotalDiscount.Location = new System.Drawing.Point(524, 372);
                this.lblTotalDiscount.Name = "lblTotalDiscount";
                this.lblTotalDiscount.Size = new System.Drawing.Size(170, 36);
                this.lblTotalDiscount.TabIndex = 196;
                this.lblTotalDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                this.label8.Location = new System.Drawing.Point(703, 372);
                this.label8.Name = "label8";
                this.label8.Size = new System.Drawing.Size(106, 36);
                this.label8.TabIndex = 193;
                this.label8.Text = "TOTAL SOLD SALES";
                this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                this.lblTotalSoldSales.BackColor = System.Drawing.Color.White;
                this.lblTotalSoldSales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.lblTotalSoldSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                this.lblTotalSoldSales.Location = new System.Drawing.Point(810, 372);
                this.lblTotalSoldSales.Name = "lblTotalSoldSales";
                this.lblTotalSoldSales.Size = new System.Drawing.Size(170, 36);
                this.lblTotalSoldSales.TabIndex = 194;
                this.lblTotalSoldSales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                this.progressBar1.Location = new System.Drawing.Point(2, 340);
                this.progressBar1.Name = "progressBar1";
                this.progressBar1.Size = new System.Drawing.Size(978, 29);
                this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
                this.progressBar1.TabIndex = 197;
                this.progressBar1.Visible = false;

                this.Controls.Add(this.label9);
                this.Controls.Add(this.lblNumberOfItems);
                this.Controls.Add(this.label7);
                this.Controls.Add(this.lblTotalSoldQty);
                this.Controls.Add(this.label10);
                this.Controls.Add(this.lblTotalDiscount);
                this.Controls.Add(this.label8);
                this.Controls.Add(this.lblTotalSoldSales);
                this.Controls.Add(this.progressBar1);

                lblTotalItems.Text = dataGridView2.RowCount.ToString();
                lblTotalQty.Text = totalQty.ToString();
                lblTotalCost.Text = string.Format("{0:$0.00}", totalCost);

                nfi.CurrencySymbol = Application.CurrentCulture.NumberFormat.CurrencySymbol;
                nfi.CurrencyNegativePattern = 1;

                SqlCommand cmd_CmbCategory1 = new SqlCommand("Get_Category_Group1", parentForm.conn);
                cmd_CmbCategory1.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd_CmbCategory1;

                parentForm.conn.Open();
                adapt.Fill(ds);
                parentForm.conn.Close();

                cmbCategory1.DataSource = ds.Tables[0].DefaultView;
                cmbCategory1.ValueMember = "ItmGp_Desc";
                cmbCategory1.DisplayMember = "ItmGp_Desc";

                txtStartDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                txtEndDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

                btnOK.Select();
                btnOK.Focus();
            }
            else if (formOpt == 1)
            {
                this.Text = "ITEM SOLD LIST FOR REPORT - " + parentForm.employeeID + " LOGGED IN " + parentForm.storeName;

                btnSelectAll.Visible = false;
                btnAdd.Visible = false;
                btnDelete.Visible = false;
                btnReset2.Visible = false;
                btnGeneratePO.Visible = false;
                dataGridView2.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                lblTotalItems.Visible = false;
                lblTotalQty.Visible = false;
                lblTotalCost.Visible = false;

                dataGridView1.Height = 555;

                this.lblNumberOfItems = new System.Windows.Forms.Label();
                this.label9 = new System.Windows.Forms.Label();
                this.lblTotalSoldSales = new System.Windows.Forms.Label();
                this.label8 = new System.Windows.Forms.Label();
                this.lblTotalSoldQty = new System.Windows.Forms.Label();
                this.label7 = new System.Windows.Forms.Label();
                this.lblTotalDiscount = new System.Windows.Forms.Label();
                this.label10 = new System.Windows.Forms.Label();
                this.progressBar1 = new System.Windows.Forms.ProgressBar();

                this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                this.label9.Location = new System.Drawing.Point(2, 659);
                this.label9.Name = "label9";
                this.label9.Size = new System.Drawing.Size(90, 36);
                this.label9.TabIndex = 206;
                this.label9.Text = "NUMBER OF ITEMS";
                this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                this.lblNumberOfItems.BackColor = System.Drawing.Color.White;
                this.lblNumberOfItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.lblNumberOfItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                this.lblNumberOfItems.Location = new System.Drawing.Point(93, 659);
                this.lblNumberOfItems.Name = "lblNumberOfItems";
                this.lblNumberOfItems.Size = new System.Drawing.Size(100, 36);
                this.lblNumberOfItems.TabIndex = 207;
                this.lblNumberOfItems.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                this.label7.Location = new System.Drawing.Point(201, 659);
                this.label7.Name = "label7";
                this.label7.Size = new System.Drawing.Size(90, 36);
                this.label7.TabIndex = 191;
                this.label7.Text = "TOTAL SOLD QTY";
                this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                this.lblTotalSoldQty.BackColor = System.Drawing.Color.White;
                this.lblTotalSoldQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.lblTotalSoldQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                this.lblTotalSoldQty.Location = new System.Drawing.Point(292, 659);
                this.lblTotalSoldQty.Name = "lblTotalSoldQty";
                this.lblTotalSoldQty.Size = new System.Drawing.Size(100, 36);
                this.lblTotalSoldQty.TabIndex = 192;
                this.lblTotalSoldQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                this.label10.Location = new System.Drawing.Point(433, 659);
                this.label10.Name = "label10";
                this.label10.Size = new System.Drawing.Size(90, 36);
                this.label10.TabIndex = 195;
                this.label10.Text = "TOTAL DISCOUNT";
                this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                this.lblTotalDiscount.BackColor = System.Drawing.Color.White;
                this.lblTotalDiscount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.lblTotalDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                this.lblTotalDiscount.Location = new System.Drawing.Point(524, 659);
                this.lblTotalDiscount.Name = "lblTotalDiscount";
                this.lblTotalDiscount.Size = new System.Drawing.Size(170, 36);
                this.lblTotalDiscount.TabIndex = 196;
                this.lblTotalDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                this.label8.Location = new System.Drawing.Point(703, 659);
                this.label8.Name = "label8";
                this.label8.Size = new System.Drawing.Size(106, 36);
                this.label8.TabIndex = 193;
                this.label8.Text = "TOTAL SOLD SALES";
                this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                this.lblTotalSoldSales.BackColor = System.Drawing.Color.White;
                this.lblTotalSoldSales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.lblTotalSoldSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                this.lblTotalSoldSales.Location = new System.Drawing.Point(810, 659);
                this.lblTotalSoldSales.Name = "lblTotalSoldSales";
                this.lblTotalSoldSales.Size = new System.Drawing.Size(170, 36);
                this.lblTotalSoldSales.TabIndex = 194;
                this.lblTotalSoldSales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                this.progressBar1.Location = new System.Drawing.Point(2, 626);
                this.progressBar1.Name = "progressBar1";
                this.progressBar1.Size = new System.Drawing.Size(978, 29);
                this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
                this.progressBar1.TabIndex = 197;
                this.progressBar1.Visible = false;

                this.Controls.Add(this.label9);
                this.Controls.Add(this.lblNumberOfItems);
                this.Controls.Add(this.label7);
                this.Controls.Add(this.lblTotalSoldQty);
                this.Controls.Add(this.label10);
                this.Controls.Add(this.lblTotalDiscount);
                this.Controls.Add(this.label8);
                this.Controls.Add(this.lblTotalSoldSales);
                this.Controls.Add(this.progressBar1);

                nfi.CurrencySymbol = Application.CurrentCulture.NumberFormat.CurrencySymbol;
                nfi.CurrencyNegativePattern = 1;

                SqlCommand cmd_CmbCategory1 = new SqlCommand("Get_Category_Group1", parentForm.conn);
                cmd_CmbCategory1.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd_CmbCategory1;

                parentForm.conn.Open();
                adapt.Fill(ds);
                parentForm.conn.Close();

                cmbCategory1.DataSource = ds.Tables[0].DefaultView;
                cmbCategory1.ValueMember = "ItmGp_Desc";
                cmbCategory1.DisplayMember = "ItmGp_Desc";

                txtStartDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                txtEndDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

                btnOK.Select();
                btnOK.Focus();
            }
        }

        private void txtStartDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void txtEndDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar2.Visible = true;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtStartDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar1.SelectionStart));
            monthCalendar1.Visible = false;
        }

        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtEndDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar2.SelectionStart));
            monthCalendar2.Visible = false;
        }

        public void btnOK_Click(object sender, EventArgs e)
        {
            if (txtStartDate.Text == "")
            {
                MessageBox.Show("SELECT DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtEndDate.Text == "")
            {
                MessageBox.Show("SELECT END DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (lblOpt.Text == "")
            {
                MessageBox.Show("SELECT OPTIONS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnOK.Enabled = false;

            totalSoldQty = 0; totalDiscount = 0; totalSoldSales = 0;
            brandBoolNum = 0; sizeBoolNum = 0; colorBoolNum = 0; nameBoolNum = 0; upcBoolNum = 0; totalBoolNum = 0;

            if (cmbBrand.Text == "")
            {
                brandBoolNum = 0;
                ItmBrand = "1";
            }
            else
            {
                brandBoolNum = 16;
                ItmBrand = cmbBrand.Text.ToUpper();
            }

            if (cmbSize.Text == "")
            {
                sizeBoolNum = 0;
                ItmSize = "1";
            }
            else
            {
                sizeBoolNum = 8;
                ItmSize = cmbSize.Text.ToUpper();
            }

            if (cmbColor.Text == "")
            {
                colorBoolNum = 0;
                ItmColor = "1";
            }
            else
            {
                colorBoolNum = 4;
                ItmColor = cmbColor.Text.ToUpper();
            }

            if (txtName.Text == "")
            {
                nameBoolNum = 0;
                ItmName = "1";
            }
            else
            {
                nameBoolNum = 2;
                ItmName = txtName.Text.ToUpper();
            }

            if (txtUpc.Text == "")
            {
                upcBoolNum = 0;
                ItmUpc = "1";
            }
            else
            {
                upcBoolNum = 1;
                ItmUpc = txtUpc.Text.ToUpper();
            }

            totalBoolNum = brandBoolNum + sizeBoolNum + colorBoolNum + nameBoolNum + upcBoolNum;

            if (optTopBottom == 0)
            {
                if (optTrueFalse == 2)
                {
                    if (cmbCategory1.SelectedIndex == 0)
                    {
                        sp = "Show_Item_Sold_History_Top_All";
                        DataBind(totalBoolNum, intNum, sp, txtStartDate.Text, txtEndDate.Text, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);
                        BindDataGridView();
                    }
                    else
                    {
                        if (cmbCategory2.SelectedIndex > 0)
                        {
                            if (cmbCategory3.SelectedIndex >= 0)
                            {
                                if (cmbCategory1.SelectedIndex > 5)
                                {
                                    index1 = cmbCategory1.SelectedIndex + 1;
                                }
                                else
                                {
                                    index1 = cmbCategory1.SelectedIndex;
                                }
                                index2 = cmbCategory2.SelectedIndex;
                                index3 = cmbCategory3.SelectedIndex + 1;
                                sp = "Show_Item_Sold_History_With_Category_1_2_3_Top_All";
                                DataBind(totalBoolNum, intNum, sp, index1, index2, index3, txtStartDate.Text, txtEndDate.Text, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);
                                BindDataGridView();
                            }
                            else
                            {
                                if (cmbCategory1.SelectedIndex > 5)
                                {
                                    index1 = cmbCategory1.SelectedIndex + 1;
                                }
                                else
                                {
                                    index1 = cmbCategory1.SelectedIndex;
                                }
                                index2 = cmbCategory2.SelectedIndex;
                                sp = "Show_Item_Sold_History_With_Category_1_2_Top_All";
                                DataBind(totalBoolNum, intNum, sp, index1, index2, txtStartDate.Text, txtEndDate.Text, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);
                                BindDataGridView();
                            }
                        }
                        else
                        {
                            if (cmbCategory1.SelectedIndex > 5)
                            {
                                index1 = cmbCategory1.SelectedIndex + 1;
                            }
                            else
                            {
                                index1 = cmbCategory1.SelectedIndex;
                            }
                            sp = "Show_Item_Sold_History_With_Category_1_Top_All";
                            DataBind(totalBoolNum, intNum, sp, index1, txtStartDate.Text, txtEndDate.Text, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);
                            BindDataGridView();
                        }
                    }
                }
                else
                {
                    if (cmbCategory1.SelectedIndex == 0)
                    {
                        sp = "Show_Item_Sold_History_Top_TF";
                        DataBind(totalBoolNum, intNum, sp, txtStartDate.Text, txtEndDate.Text, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc, optTrueFalse);
                        BindDataGridView();
                    }
                    else
                    {
                        if (cmbCategory2.SelectedIndex > 0)
                        {
                            if (cmbCategory3.SelectedIndex >= 0)
                            {
                                if (cmbCategory1.SelectedIndex > 5)
                                {
                                    index1 = cmbCategory1.SelectedIndex + 1;
                                }
                                else
                                {
                                    index1 = cmbCategory1.SelectedIndex;
                                }
                                index2 = cmbCategory2.SelectedIndex;
                                index3 = cmbCategory3.SelectedIndex + 1;
                                sp = "Show_Item_Sold_History_With_Category_1_2_3_Top_TF";
                                DataBind(totalBoolNum, intNum, sp, index1, index2, index3, txtStartDate.Text, txtEndDate.Text, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc, optTrueFalse);
                                BindDataGridView();
                            }
                            else
                            {
                                if (cmbCategory1.SelectedIndex > 5)
                                {
                                    index1 = cmbCategory1.SelectedIndex + 1;
                                }
                                else
                                {
                                    index1 = cmbCategory1.SelectedIndex;
                                }
                                index2 = cmbCategory2.SelectedIndex;
                                sp = "Show_Item_Sold_History_With_Category_1_2_Top_TF";
                                DataBind(totalBoolNum, intNum, sp, index1, index2, txtStartDate.Text, txtEndDate.Text, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc, optTrueFalse);
                                BindDataGridView();
                            }
                        }
                        else
                        {
                            if (cmbCategory1.SelectedIndex > 5)
                            {
                                index1 = cmbCategory1.SelectedIndex + 1;
                            }
                            else
                            {
                                index1 = cmbCategory1.SelectedIndex;
                            }
                            sp = "Show_Item_Sold_History_With_Category_1_Top_TF";
                            DataBind(totalBoolNum, intNum, sp, index1, txtStartDate.Text, txtEndDate.Text, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc, optTrueFalse);
                            BindDataGridView();
                        }
                    }
                }
            }
            else if (optTopBottom == 1)
            {
                if (optTrueFalse == 2)
                {
                    if (cmbCategory1.SelectedIndex == 0)
                    {
                        sp = "Show_Item_Sold_History_Bottom_All";
                        DataBind(totalBoolNum, intNum, sp, txtStartDate.Text, txtEndDate.Text, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);
                        BindDataGridView();
                    }
                    else
                    {
                        if (cmbCategory2.SelectedIndex > 0)
                        {
                            if (cmbCategory3.SelectedIndex >= 0)
                            {
                                if (cmbCategory1.SelectedIndex > 5)
                                {
                                    index1 = cmbCategory1.SelectedIndex + 1;
                                }
                                else
                                {
                                    index1 = cmbCategory1.SelectedIndex;
                                }
                                index2 = cmbCategory2.SelectedIndex;
                                index3 = cmbCategory3.SelectedIndex + 1;
                                sp = "Show_Item_Sold_History_With_Category_1_2_3_Bottom_All";
                                DataBind(totalBoolNum, intNum, sp, index1, index2, index3, txtStartDate.Text, txtEndDate.Text, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);
                                BindDataGridView();
                            }
                            else
                            {
                                if (cmbCategory1.SelectedIndex > 5)
                                {
                                    index1 = cmbCategory1.SelectedIndex + 1;
                                }
                                else
                                {
                                    index1 = cmbCategory1.SelectedIndex;
                                }
                                index2 = cmbCategory2.SelectedIndex;
                                sp = "Show_Item_Sold_History_With_Category_1_2_Bottom_All";
                                DataBind(totalBoolNum, intNum, sp, index1, index2, txtStartDate.Text, txtEndDate.Text, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);
                                BindDataGridView();
                            }
                        }
                        else
                        {
                            if (cmbCategory1.SelectedIndex > 5)
                            {
                                index1 = cmbCategory1.SelectedIndex + 1;
                            }
                            else
                            {
                                index1 = cmbCategory1.SelectedIndex;
                            }
                            sp = "Show_Item_Sold_History_With_Category_1_Bottom_All";
                            DataBind(totalBoolNum, intNum, sp, index1, txtStartDate.Text, txtEndDate.Text, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);
                            BindDataGridView();
                        }
                    }
                }
                else
                {
                    if (cmbCategory1.SelectedIndex == 0)
                    {
                        sp = "Show_Item_Sold_History_Bottom_TF";
                        DataBind(totalBoolNum, intNum, sp, txtStartDate.Text, txtEndDate.Text, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc, optTrueFalse);
                        BindDataGridView();
                    }
                    else
                    {
                        if (cmbCategory2.SelectedIndex > 0)
                        {
                            if (cmbCategory3.SelectedIndex >= 0)
                            {
                                if (cmbCategory1.SelectedIndex > 5)
                                {
                                    index1 = cmbCategory1.SelectedIndex + 1;
                                }
                                else
                                {
                                    index1 = cmbCategory1.SelectedIndex;
                                }
                                index2 = cmbCategory2.SelectedIndex;
                                index3 = cmbCategory3.SelectedIndex + 1;
                                sp = "Show_Item_Sold_History_With_Category_1_2_3_Bottom_TF";
                                DataBind(totalBoolNum, intNum, sp, index1, index2, index3, txtStartDate.Text, txtEndDate.Text, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc, optTrueFalse);
                                BindDataGridView();
                            }
                            else
                            {
                                if (cmbCategory1.SelectedIndex > 5)
                                {
                                    index1 = cmbCategory1.SelectedIndex + 1;
                                }
                                else
                                {
                                    index1 = cmbCategory1.SelectedIndex;
                                }
                                index2 = cmbCategory2.SelectedIndex;
                                sp = "Show_Item_Sold_History_With_Category_1_2_Bottom_TF";
                                DataBind(totalBoolNum, intNum, sp, index1, index2, txtStartDate.Text, txtEndDate.Text, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc, optTrueFalse);
                                BindDataGridView();
                            }
                        }
                        else
                        {
                            if (cmbCategory1.SelectedIndex > 5)
                            {
                                index1 = cmbCategory1.SelectedIndex + 1;
                            }
                            else
                            {
                                index1 = cmbCategory1.SelectedIndex;
                            }
                            sp = "Show_Item_Sold_History_With_Category_1_Bottom_TF";
                            DataBind(totalBoolNum, intNum, sp, index1, txtStartDate.Text, txtEndDate.Text, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc, optTrueFalse);
                            BindDataGridView();
                        }
                    }
                }
            }

            totalSoldQty = 0;
            totalDiscount = 0;
            totalSoldSales = 0;
            lblNumberOfItems.Text = "PLEASE";
            lblTotalSoldQty.Text = "WAIT";
            lblTotalDiscount.Text = "CALCULATING";
            lblTotalSoldSales.Text = ".....";

            progressBar1.Minimum = 0;
            progressBar1.Maximum = dataGridView1.RowCount;
            progressBar1.Step = 1;
            progressBar1.Visible = true;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                //dataGridView1.Rows[i].Selected = false;

                if (dataGridView1.Rows[i].Cells[9].Value == DBNull.Value)
                    dataGridView1.Rows[i].Cells[9].Value = 0;

                if (dataGridView1.Rows[i].Cells[10].Value == DBNull.Value)
                    dataGridView1.Rows[i].Cells[10].Value = 0;

                if (dataGridView1.Rows[i].Cells[11].Value == DBNull.Value)
                    dataGridView1.Rows[i].Cells[11].Value = 0;

                totalSoldQty = totalSoldQty + Convert.ToInt64(dataGridView1.Rows[i].Cells[9].Value);
                totalDiscount = totalDiscount + Convert.ToDouble(dataGridView1.Rows[i].Cells[10].Value);
                totalSoldSales = totalSoldSales + Convert.ToDouble(dataGridView1.Rows[i].Cells[11].Value);

                progressBar1.PerformStep();
                Application.DoEvents();
            }

            lblNumberOfItems.Text = Convert.ToString(dataGridView1.RowCount);
            lblTotalSoldQty.Text = Convert.ToString(totalSoldQty);
            lblTotalDiscount.Text = string.Format("{0:$0.00}", totalDiscount);
            lblTotalSoldSales.Text = string.Format("{0:$0.00}", totalSoldSales);

            btnOK.Enabled = true;
            progressBar1.Visible = false;
            progressBar1.Value = 0;

            dataGridView1.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
                this.Close();
        }

        private void cmbCategory1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory1.SelectedIndex == 0 | cmbCategory1.SelectedIndex > 6)
            {
                cmbCategory2.DataSource = null;
                cmbCategory2.Items.Clear();
                cmbCategory3.DataSource = null;
                cmbCategory3.Items.Clear();
                return;
            }

            SqlCommand cmd_CmbCategory2 = new SqlCommand("Get_Category_Group2", parentForm.conn);
            cmd_CmbCategory2.CommandType = CommandType.StoredProcedure;
            cmd_CmbCategory2.Parameters.Add("@ItmGp_Parents", SqlDbType.Int).Value = cmbCategory1.SelectedIndex;
            DataSet ds = new DataSet();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd_CmbCategory2;

            parentForm.conn.Open();
            adapt.Fill(ds);
            parentForm.conn.Close();

            cmbCategory2.DataSource = ds.Tables[0].DefaultView;
            cmbCategory2.ValueMember = "ItmGp_Desc";
            cmbCategory2.DisplayMember = "ItmGp_Desc";

            ds.Tables.Clear();
        }

        private void cmbCategory2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCategory3.DataSource = null;
            cmbCategory3.Items.Clear();

            index1 = cmbCategory1.SelectedIndex;
            index2 = cmbCategory2.SelectedIndex;

            SqlCommand cmd_CmbCategory3 = new SqlCommand("Get_Category_Group3", parentForm.conn);
            cmd_CmbCategory3.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter adapt = new SqlDataAdapter();

            switch (index1)
            {
                case 6:
                    cmd_CmbCategory3.Parameters.Add("@ItmGp_Parents", SqlDbType.Int).Value = index1 + 1;
                    cmd_CmbCategory3.Parameters.Add("@ItmGp_Parents2", SqlDbType.Int).Value = index2;
                    adapt.SelectCommand = cmd_CmbCategory3;

                    parentForm.conn.Open();
                    adapt.Fill(ds);
                    parentForm.conn.Close();

                    cmbCategory3.DataSource = ds.Tables[0].DefaultView;
                    cmbCategory3.ValueMember = "ItmGp_Desc";
                    cmbCategory3.DisplayMember = "ItmGp_Desc";
                    break;
                default:
                    cmd_CmbCategory3.Parameters.Add("@ItmGp_Parents", SqlDbType.Int).Value = index1;
                    cmd_CmbCategory3.Parameters.Add("@ItmGp_Parents2", SqlDbType.Int).Value = index2;
                    adapt.SelectCommand = cmd_CmbCategory3;

                    parentForm.conn.Open();
                    adapt.Fill(ds);
                    parentForm.conn.Close();

                    cmbCategory3.DataSource = ds.Tables[0].DefaultView;
                    cmbCategory3.ValueMember = "ItmGp_Desc";
                    cmbCategory3.DisplayMember = "ItmGp_Desc";
                    break;
            }
        }

        public void DataBind(int totalBoolNum, Int64 ItmNum, string sp, string sDate, string eDate, string ItmBrand, string ItmSize, string ItmColor, string ItmName, string ItmUpc)
        {
            dt.Clear();

            cmd = new SqlCommand(sp, parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
            cmd.Parameters.Add("@ItmNum", SqlDbType.BigInt).Value = ItmNum;
            cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = sDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = eDate;
            cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
            cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
            cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
            adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            adapt.Fill(dt);
            parentForm.conn.Close();
        }

        public void DataBind(int totalBoolNum, Int64 ItmNum, string sp, int idx1, string sDate, string eDate, string ItmBrand, string ItmSize, string ItmColor, string ItmName, string ItmUpc)
        {
            dt.Clear();

            cmd = new SqlCommand(sp, parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
            cmd.Parameters.Add("@ItmNum", SqlDbType.BigInt).Value = ItmNum;
            cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = idx1;
            cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = sDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = eDate;
            cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
            cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
            cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
            adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            adapt.Fill(dt);
            parentForm.conn.Close();
        }

        public void DataBind(int totalBoolNum, Int64 ItmNum, string sp, int idx1, int idx2, string sDate, string eDate, string ItmBrand, string ItmSize, string ItmColor, string ItmName, string ItmUpc)
        {
            dt.Clear();

            cmd = new SqlCommand(sp, parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
            cmd.Parameters.Add("@ItmNum", SqlDbType.BigInt).Value = ItmNum;
            cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = idx1;
            cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = idx2;
            cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = sDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = eDate;
            cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
            cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
            cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
            adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            adapt.Fill(dt);
            parentForm.conn.Close();
        }

        public void DataBind(int totalBoolNum, Int64 ItmNum, string sp, int idx1, int idx2, int idx3, string sDate, string eDate, string ItmBrand, string ItmSize, string ItmColor, string ItmName, string ItmUpc)
        {
            dt.Clear();

            cmd = new SqlCommand(sp, parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
            cmd.Parameters.Add("@ItmNum", SqlDbType.BigInt).Value = ItmNum;
            cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = idx1;
            cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = idx2;
            cmd.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = idx3;
            cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = sDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = eDate;
            cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
            cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
            cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
            adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            adapt.Fill(dt);
            parentForm.conn.Close();
        }

        public void DataBind(int totalBoolNum, Int64 ItmNum, string sp, string sDate, string eDate, string ItmBrand, string ItmSize, string ItmColor, string ItmName, string ItmUpc, int OptTrueFalse)
        {
            dt.Clear();

            cmd = new SqlCommand(sp, parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
            cmd.Parameters.Add("@ItmNum", SqlDbType.BigInt).Value = ItmNum;
            cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = sDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = eDate;
            cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
            cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
            cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;

            if (optTrueFalse == 0)
            {
                cmd.Parameters.Add("@ItmTF", SqlDbType.Bit).Value = true;
            }
            else if (optTrueFalse == 1)
            {
                cmd.Parameters.Add("@ItmTF", SqlDbType.Bit).Value = false;
            }

            adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            adapt.Fill(dt);
            parentForm.conn.Close();
        }

        public void DataBind(int totalBoolNum, Int64 ItmNum, string sp, int idx1, string sDate, string eDate, string ItmBrand, string ItmSize, string ItmColor, string ItmName, string ItmUpc, int OptTrueFalse)
        {
            dt.Clear();

            cmd = new SqlCommand(sp, parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
            cmd.Parameters.Add("@ItmNum", SqlDbType.BigInt).Value = ItmNum;
            cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = idx1;
            cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = sDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = eDate;
            cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
            cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
            cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;

            if (optTrueFalse == 0)
            {
                cmd.Parameters.Add("@ItmTF", SqlDbType.Bit).Value = true;
            }
            else if (optTrueFalse == 1)
            {
                cmd.Parameters.Add("@ItmTF", SqlDbType.Bit).Value = false;
            }

            adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            adapt.Fill(dt);
            parentForm.conn.Close();
        }

        public void DataBind(int totalBoolNum, Int64 ItmNum, string sp, int idx1, int idx2, string sDate, string eDate, string ItmBrand, string ItmSize, string ItmColor, string ItmName, string ItmUpc, int OptTrueFalse)
        {
            dt.Clear();

            cmd = new SqlCommand(sp, parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
            cmd.Parameters.Add("@ItmNum", SqlDbType.BigInt).Value = ItmNum;
            cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = idx1;
            cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = idx2;
            cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = sDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = eDate;
            cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
            cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
            cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;

            if (optTrueFalse == 0)
            {
                cmd.Parameters.Add("@ItmTF", SqlDbType.Bit).Value = true;
            }
            else if (optTrueFalse == 1)
            {
                cmd.Parameters.Add("@ItmTF", SqlDbType.Bit).Value = false;
            }

            adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            adapt.Fill(dt);
            parentForm.conn.Close();
        }

        public void DataBind(int totalBoolNum, Int64 ItmNum, string sp, int idx1, int idx2, int idx3, string sDate, string eDate, string ItmBrand, string ItmSize, string ItmColor, string ItmName, string ItmUpc, int OptTrueFalse)
        {
            dt.Clear();

            cmd = new SqlCommand(sp, parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
            cmd.Parameters.Add("@ItmNum", SqlDbType.BigInt).Value = ItmNum;
            cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = idx1;
            cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = idx2;
            cmd.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = idx3;
            cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = sDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = eDate;
            cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
            cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
            cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;

            if (optTrueFalse == 0)
            {
                cmd.Parameters.Add("@ItmTF", SqlDbType.Bit).Value = true;
            }
            else if (optTrueFalse == 1)
            {
                cmd.Parameters.Add("@ItmTF", SqlDbType.Bit).Value = false;
            }

            adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            adapt.Fill(dt);
            parentForm.conn.Close();
        }

        private void BindDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "Brand";
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].Width = 90;
            dataGridView1.Columns[1].HeaderText = "Name";
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].Width = 160;
            dataGridView1.Columns[2].HeaderText = "Size";
            dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].Width = 50;
            dataGridView1.Columns[3].HeaderText = "Color";
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].Width = 50;
            dataGridView1.Columns[4].HeaderText = "Model #";
            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].Width = 145;
            dataGridView1.Columns[5].HeaderText = "UPC";
            dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].Width = 90;
            dataGridView1.Columns[6].HeaderText = "Retail Price";
            dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].Width = 55;
            dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[6].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[6].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[7].HeaderText = "Cost Price";
            dataGridView1.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[7].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[7].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].HeaderText = "On Hand";
            dataGridView1.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[8].Width = 40;
            dataGridView1.Columns[9].HeaderText = "Sold Qty";
            dataGridView1.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[9].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            dataGridView1.Columns[9].Width = 55;
            dataGridView1.Columns[10].HeaderText = "Discount";
            dataGridView1.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[10].DefaultCellStyle.BackColor = Color.LightYellow;
            dataGridView1.Columns[10].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[10].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[10].Width = 75;
            dataGridView1.Columns[11].HeaderText = "Sold Price";
            dataGridView1.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[11].DefaultCellStyle.BackColor = Color.NavajoWhite;
            dataGridView1.Columns[11].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[11].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[11].Width = 75;
            //dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[12].HeaderText = "Bin #";
            dataGridView1.Columns[12].Width = 40;
            dataGridView1.Columns[13].HeaderText = "Act";
            dataGridView1.Columns[13].Width = 30;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].Visible = false;
            dataGridView1.Columns[17].Visible = false;

            dataGridView1.ClearSelection();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (parentForm.employeeID.ToUpper() == "ADMIN" | parentForm.specialCode == parentForm.txtSpecialCode.Text.Trim().ToString().ToUpper())
            {
                if (dataGridView1.RowCount > 0)
                {
                    this.Enabled = false;

                    Excel_12.Application ReportFile;
                    Excel_12._Workbook WorkBook;
                    Excel_12._Worksheet WorkSheet;
                    //Excel_12.Range Range;

                    string MaxRow = Convert.ToString(dt.Rows.Count + 1);
                    String MaxColumn = ((String)(Convert.ToChar(dt.Columns.Count / 26 + 64).ToString() + Convert.ToChar(dt.Columns.Count % 26 + 64))).Replace('@', ' ').Trim();
                    String MaxCell = MaxColumn + MaxRow;

                    ReportFile = new Excel_12.Application();
                    ReportFile.Visible = false;

                    WorkBook = (Excel_12._Workbook)(ReportFile.Workbooks.Add("workbook"));
                    WorkSheet = (Excel_12._Worksheet)WorkBook.ActiveSheet;

                    for (int i = 0; i < dt.Columns.Count; i++)
                        WorkSheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;

                    string[,] Values = new string[dt.Rows.Count, dt.Columns.Count];

                    //for (int i = 0; i < dt.Rows.Count; i++)
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {

                            Values[i, j] = dt.Rows[i][j].ToString();

                        }

                    WorkSheet.get_Range("A2", MaxCell).Value2 = Values;
                    ReportFile.Visible = true;
                    ReportFile.UserControl = true;

                    this.Enabled = true;
                }
                else
                {
                    MessageBox.Show("NO DATA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (dataGridView1.RowCount > 0)
                {
                    ExportDataGridViewTo_Excel12(dataGridView1);
                }
                else
                {
                    MessageBox.Show("NO DATA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        public static void ExportDataGridViewTo_Excel12(DataGridView myDataGridView)
        {
            try
            {
                Excel_12.Application oExcel_12 = null;                //Excel_12 Application
                Excel_12.Workbook oBook = null;                       // Excel_12 Workbook
                Excel_12.Sheets oSheetsColl = null;                   // Excel_12 Worksheets collection
                Excel_12.Worksheet oSheet = null;                     // Excel_12 Worksheet
                Excel_12.Range oRange = null;                         // Cell or Range in worksheet
                Object oMissing = System.Reflection.Missing.Value;

                // Create an instance of Excel_12.
                oExcel_12 = new Excel_12.Application();

                // Make Excel_12 visible to the user.
                oExcel_12.Visible = true;

                // Set the UserControl property so Excel_12 won't shut down.
                oExcel_12.UserControl = true;

                // System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");

                // Add a workbook.
                oBook = oExcel_12.Workbooks.Add(oMissing);

                // Get worksheets collection 
                oSheetsColl = oExcel_12.Worksheets;

                // Get Worksheet "Sheet1"
                oSheet = (Excel_12.Worksheet)oSheetsColl.get_Item("Sheet1");

                // Export titles
                for (int j = 0; j < myDataGridView.Columns.Count; j++)
                {
                    oRange = (Excel_12.Range)oSheet.Cells[1, j + 1];
                    oRange.Value2 = myDataGridView.Columns[j].HeaderText;
                }

                // Export data
                for (int i = 0; i < myDataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < myDataGridView.Columns.Count; j++)
                    {
                        oRange = (Excel_12.Range)oSheet.Cells[i + 2, j + 1];
                        oRange.Value2 = myDataGridView[j, i].Value.ToString();
                    }
                }

                // Release the variables.
                //oBook.Close(false, oMissing, oMissing);
                oBook = null;

                //oExcel_12.Quit();
                oExcel_12 = null;

                // Collect garbage.
                GC.Collect();
            }
            catch
            {
                MessageBox.Show("CAN NOT GENERATE EXCEL FILE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnBrand_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Get_BrandName", parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            DataSet ds = new DataSet();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            adapt.Fill(ds);
            parentForm.conn.Close();

            cmbBrand.DataSource = ds.Tables[0].DefaultView;
            cmbBrand.ValueMember = "BrandName";
            cmbBrand.DisplayMember = "BrandName";
        }

        private void btnSize_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Get_SizeName", parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            DataSet ds = new DataSet();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            adapt.Fill(ds);
            parentForm.conn.Close();

            cmbSize.DataSource = ds.Tables[0].DefaultView;
            cmbSize.ValueMember = "SizeName";
            cmbSize.DisplayMember = "SizeName";
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Get_ColorName", parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            DataSet ds = new DataSet();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            adapt.Fill(ds);
            parentForm.conn.Close();

            cmbColor.DataSource = ds.Tables[0].DefaultView;
            cmbColor.ValueMember = "ColorName";
            cmbColor.DisplayMember = "ColorName";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                txtUpc.SelectAll();
                txtUpc.Focus();
                return;
            }
            else
            {
                selectedcount = 0;
                oldcount = dataGridView2.RowCount;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Selected == true)
                    {
                        if (dataGridView2.RowCount == 0)
                        {
                            Set_Variables(i);
                            dt2_All.Rows.Add(ItmPOBrand, ItmPOName, ItmPOSize, ItmPOColor, ItmPOModel, ItmPOUpc, ItmPORetailPrice, ItmPOCostPrice, ItmPOOnHand, ItmPOSoldQty, ItmPOSoldQty, ItmPOSoldQty * ItmPOCostPrice, ItmPOBin);
                        }
                        else
                        {
                            Set_Variables(i);
                            c = Check_Duplicated(ItmPOSize, ItmPOColor, ItmPOUpc);

                            if (c == false)
                            {
                                dt2_All.Rows.Add(ItmPOBrand, ItmPOName, ItmPOSize, ItmPOColor, ItmPOModel, ItmPOUpc, ItmPORetailPrice, ItmPOCostPrice, ItmPOOnHand, ItmPOSoldQty, ItmPOSoldQty, ItmPOSoldQty * ItmPOCostPrice, ItmPOBin);
                            }
                        }

                        selectedcount = selectedcount + 1;
                    }
                }

                dataGridView2.DataSource = dt2_All;
                dataGridView2.Columns[0].HeaderText = "Brand";
                dataGridView2.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns[0].Width = 100;
                dataGridView2.Columns[1].HeaderText = "Name";
                dataGridView2.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns[1].Width = 180;
                dataGridView2.Columns[2].HeaderText = "Size";
                dataGridView2.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns[2].Width = 50;
                dataGridView2.Columns[3].HeaderText = "Color";
                dataGridView2.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns[3].Width = 50;
                dataGridView2.Columns[4].HeaderText = "Model #";
                dataGridView2.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns[4].Width = 140;
                dataGridView2.Columns[5].HeaderText = "UPC";
                dataGridView2.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns[5].Width = 90;
                dataGridView2.Columns[6].HeaderText = "Retail Price";
                dataGridView2.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns[6].Width = 55;
                dataGridView2.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView2.Columns[6].DefaultCellStyle.FormatProvider = nfi;
                dataGridView2.Columns[6].DefaultCellStyle.Format = "c";
                dataGridView2.Columns[7].HeaderText = "Cost Price";
                dataGridView2.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns[7].Width = 55;
                dataGridView2.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView2.Columns[7].DefaultCellStyle.BackColor = Color.NavajoWhite;
                dataGridView2.Columns[7].DefaultCellStyle.FormatProvider = nfi;
                dataGridView2.Columns[7].DefaultCellStyle.Format = "c";
                dataGridView2.Columns[8].HeaderText = "On Hand";
                dataGridView2.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView2.Columns[8].Width = 45;
                dataGridView2.Columns[9].HeaderText = "Sold Qty";
                dataGridView2.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //dataGridView2.Columns[9].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                dataGridView2.Columns[9].Width = 45;
                dataGridView2.Columns[10].HeaderText = "Order Qty";
                dataGridView2.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView2.Columns[10].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                dataGridView2.Columns[10].Width = 45;
                dataGridView2.Columns[11].HeaderText = "Order AMT";
                dataGridView2.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns[11].Width = 60;
                dataGridView2.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView2.Columns[11].DefaultCellStyle.BackColor = Color.NavajoWhite;
                dataGridView2.Columns[11].DefaultCellStyle.FormatProvider = nfi;
                dataGridView2.Columns[11].DefaultCellStyle.Format = "c";
                dataGridView2.Columns[12].HeaderText = "Bin #";
                dataGridView2.Columns[12].Width = 40;

                if (dataGridView2.RowCount > 0)
                {
                    if (selectedcount == 1)
                    {
                        if (dataGridView2.RowCount > oldcount)
                        {
                            //dataGridView2.SelectionMode = DataGridViewSelectionMode.CellSelect;
                            //dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                            dataGridView2.FirstDisplayedScrollingRowIndex = dataGridView2.RowCount - 1;
                            dataGridView2.Rows[dataGridView2.RowCount - 1].Selected = true;
                        }

                        totalQty = 0; totalCost = 0;

                        for (int i = 0; i < dataGridView2.RowCount; i++)
                        {
                            totalQty = totalQty + Convert.ToInt64(dataGridView2.Rows[i].Cells[10].Value);
                            totalCost = totalCost + Convert.ToDouble(dataGridView2.Rows[i].Cells[11].Value);
                        }

                        lblTotalItems.Text = dataGridView2.RowCount.ToString();
                        lblTotalQty.Text = totalQty.ToString();
                        lblTotalCost.Text = string.Format("{0:$0.00}", totalCost);

                        oldcount = dataGridView2.RowCount;
                        dataGridView2_MouseDoubleClick(null, null);
                    }
                    else
                    {
                        if (dataGridView2.RowCount > oldcount)
                        {
                            //dataGridView2.SelectionMode = DataGridViewSelectionMode.CellSelect;
                            //dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                            dataGridView2.FirstDisplayedScrollingRowIndex = dataGridView2.RowCount - 1;
                            dataGridView2.Rows[dataGridView2.RowCount - 1].Selected = true;
                        }

                        totalQty = 0; totalCost = 0;

                        for (int i = 0; i < dataGridView2.RowCount; i++)
                        {
                            totalQty = totalQty + Convert.ToInt64(dataGridView2.Rows[i].Cells[10].Value);
                            totalCost = totalCost + Convert.ToDouble(dataGridView2.Rows[i].Cells[11].Value);
                        }

                        lblTotalItems.Text = dataGridView2.RowCount.ToString();
                        lblTotalQty.Text = totalQty.ToString();
                        lblTotalCost.Text = string.Format("{0:$0.00}", totalCost);

                        oldcount = dataGridView2.RowCount;
                    }
                }
                else
                {
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Selected = true;
                }
            }
            else
            {
                MessageBox.Show("NO ITEM", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnSelectOpt_Click(object sender, EventArgs e)
        {
            ItemSoldListOption soldItemListOptionForm = new ItemSoldListOption(0);
            soldItemListOptionForm.parentForm1 = this;
            soldItemListOptionForm.ShowDialog();
        }

        public void btnDisplaySeletedOptions_Click(object sender, EventArgs e)
        {
            if (optTopBottom == 0)
            {
                if (optTrueFalse == 0)
                {
                    lblOpt.Text = "TOP/" + Convert.ToString(intNum) + "/T";
                }
                else if (optTrueFalse == 1)
                {
                    lblOpt.Text = "TOP/" + Convert.ToString(intNum) + "/F";
                }
                else if (optTrueFalse == 2)
                {
                    lblOpt.Text = "TOP/" + Convert.ToString(intNum) + "/A";
                }
            }
            else if (optTopBottom == 1)
            {
                if (optTrueFalse == 0)
                {
                    lblOpt.Text = "BTM/" + Convert.ToString(intNum) + "/T";
                }
                else if (optTrueFalse == 1)
                {
                    lblOpt.Text = "BTM/" + Convert.ToString(intNum) + "/F";
                }
                else if (optTrueFalse == 2)
                {
                    lblOpt.Text = "BTM/" + Convert.ToString(intNum) + "/A";
                }
            }
        }

        private void btnDeleteUnsoldItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                int SelectedItems = 0;
                totalSoldQty = 0; totalDiscount = 0; totalSoldSales = 0;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (Convert.ToInt64(dataGridView1.Rows[i].Cells[9].Value) == 0)
                    {
                        dataGridView1.Rows[i].Selected = true;
                        SelectedItems = SelectedItems + 1;
                    }
                    else
                    {
                        dataGridView1.Rows[i].Selected = false;
                    }
                }

                //if (Convert.ToInt64(dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[9].Value) == 0)
                if (SelectedItems > 0)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        dataGridView1.Rows.Remove(row);
                    }
                }

                progressBar1.Minimum = 0;
                progressBar1.Maximum = dataGridView1.RowCount;
                progressBar1.Step = 1;
                progressBar1.Visible = true;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells[9].Value == DBNull.Value)
                        dataGridView1.Rows[i].Cells[9].Value = 0;

                    if (dataGridView1.Rows[i].Cells[10].Value == DBNull.Value)
                        dataGridView1.Rows[i].Cells[10].Value = 0;

                    if (dataGridView1.Rows[i].Cells[11].Value == DBNull.Value)
                        dataGridView1.Rows[i].Cells[11].Value = 0;

                    totalSoldQty = totalSoldQty + Convert.ToInt64(dataGridView1.Rows[i].Cells[9].Value);
                    totalDiscount = totalDiscount + Convert.ToDouble(dataGridView1.Rows[i].Cells[10].Value);
                    totalSoldSales = totalSoldSales + Convert.ToDouble(dataGridView1.Rows[i].Cells[11].Value);

                    progressBar1.PerformStep();
                    Application.DoEvents();
                }

                lblNumberOfItems.Text = Convert.ToString(dataGridView1.RowCount);
                lblTotalSoldQty.Text = Convert.ToString(totalSoldQty);
                lblTotalDiscount.Text = string.Format("{0:$0.00}", totalDiscount);
                lblTotalSoldSales.Text = string.Format("{0:$0.00}", totalSoldSales);

                progressBar1.Visible = false;
                progressBar1.Value = 0;
            }
        }

        private void btnReset1_Click(object sender, EventArgs e)
        {
            dt.Clear();
            dataGridView1.DataSource = null;
            cmbCategory2.DataSource = null;
            cmbCategory2.Items.Clear();
            cmbCategory3.DataSource = null;
            cmbCategory3.Items.Clear();
            cmbBrand.DataSource = null;
            cmbBrand.Items.Clear();
            cmbColor.DataSource = null;
            cmbColor.Items.Clear();
            cmbSize.DataSource = null;
            cmbSize.Items.Clear();

            SqlCommand cmd_CmbCategory1 = new SqlCommand("Get_Category_Group1", parentForm.conn);
            cmd_CmbCategory1.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd_CmbCategory1;

            parentForm.conn.Open();
            adapt.Fill(ds);
            parentForm.conn.Close();

            cmbCategory1.DataSource = ds.Tables[0].DefaultView;
            cmbCategory1.ValueMember = "ItmGp_Desc";
            cmbCategory1.DisplayMember = "ItmGp_Desc";

            txtStartDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            txtEndDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

            totalSoldQty = 0; totalDiscount = 0; totalSoldSales = 0;
            optTopBottom = 0; intNum = 0; optTrueFalse = 0;

            lblNumberOfItems.Text = "";
            lblTotalSoldQty.Text = "";
            lblTotalDiscount.Text = "";
            lblTotalSoldSales.Text = "";
            txtName.Text = "";
            txtUpc.Text = "";
            lblOpt.Text = "";

            oldcount = 0;

            txtName.Select();
            txtName.Focus();
        }

        private void Set_Variables(int idx)
        {
            ItmPOBrand = Convert.ToString(dataGridView1.Rows[idx].Cells[0].Value);
            ItmPOName = Convert.ToString(dataGridView1.Rows[idx].Cells[1].Value);
            ItmPOSize = Convert.ToString(dataGridView1.Rows[idx].Cells[2].Value);
            ItmPOColor = Convert.ToString(dataGridView1.Rows[idx].Cells[3].Value);
            ItmPOModel = Convert.ToString(dataGridView1.Rows[idx].Cells[4].Value);
            ItmPOUpc = Convert.ToString(dataGridView1.Rows[idx].Cells[5].Value);
            ItmPORetailPrice = Convert.ToDouble(dataGridView1.Rows[idx].Cells[6].Value);
            ItmPOCostPrice = Convert.ToDouble(dataGridView1.Rows[idx].Cells[7].Value);
            ItmPOOnHand = Convert.ToInt64(dataGridView1.Rows[idx].Cells[8].Value);
            ItmPOSoldQty = Convert.ToInt64(dataGridView1.Rows[idx].Cells[9].Value);
            ItmPOBin = Convert.ToString(dataGridView1.Rows[idx].Cells[12].Value);
        }

        private bool Check_Duplicated(string size, string color, string upc)
        {
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                if (Convert.ToString(dataGridView2.Rows[i].Cells[2].Value) == size & Convert.ToString(dataGridView2.Rows[i].Cells[3].Value) == color & Convert.ToString(dataGridView2.Rows[i].Cells[5].Value) == upc)
                {
                    dataGridView2.Rows[i].Selected = true;
                    return true;
                }
            }

            return false;
        }

        private void btnReset2_Click(object sender, EventArgs e)
        {
            dt2_All.Clear();
            dataGridView2.DataSource = null;

            totalQty = 0; totalCost = 0;

            lblTotalItems.Text = dataGridView2.RowCount.ToString();
            lblTotalQty.Text = totalQty.ToString();
            lblTotalCost.Text = string.Format("{0:$0.00}", totalCost);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView2.RowCount == 0)
                return;

            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                dataGridView2.Rows.Remove(row);
            }

            totalQty = 0; totalCost = 0;

            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                totalQty = totalQty + Convert.ToInt64(dataGridView2.Rows[i].Cells[9].Value);
                totalCost = totalCost + Convert.ToDouble(dataGridView2.Rows[i].Cells[7].Value) * Convert.ToInt64(dataGridView2.Rows[i].Cells[9].Value);
            }

            lblTotalItems.Text = dataGridView2.RowCount.ToString();
            lblTotalQty.Text = totalQty.ToString();
            lblTotalCost.Text = string.Format("{0:$0.00}", totalCost);
        }

        private void btnGeneratePO_Click(object sender, EventArgs e)
        {
            if (dataGridView2.RowCount > 0)
            {
                if (parentForm2.CheckOpened("ItemSoldListForReturn") == true)
                {
                    MessageBox.Show("PLEASE CLOSE EXISING RETURN REPORT WINDOWS(S)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    CreateNewPO createNewPOForm = new CreateNewPO(1);
                    createNewPOForm.parentForm1 = this.parentForm;
                    createNewPOForm.parentForm2 = this.parentForm2;
                    createNewPOForm.parentForm3 = this;
                    createNewPOForm.Show();
                }
            }
            else
            {
                MessageBox.Show("NO ITEM", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void dataGridView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridView2.RowCount > 0)
            {
                ChangeValue changeValueForm = new ChangeValue(0);
                changeValueForm.parentForm1 = this;
                changeValueForm.ShowDialog();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (formOpt == 0)
                {
                    if (dataGridView1.RowCount > 0)
                    {
                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            if (dataGridView1.Rows[i].Selected == true)
                            {
                                ItemInformation itemInformationForm = new ItemInformation(Convert.ToString(dataGridView1.Rows[i].Cells[5].Value), 1);
                                itemInformationForm.parentForm1 = this.parentForm;
                                itemInformationForm.parentForm3 = this;
                                itemInformationForm.ShowDialog();

                                break;
                            }
                        }
                    }
                }
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txtUpc.SelectAll();
                txtUpc.Focus();
            }
            else if (e.KeyCode == Keys.Space)
            {
                btnAdd_Click(null, null);
            }
        }

        private void ItemSoldList_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (formOpt == 0)
            {
                if (parentForm2.IsDisposed == false)
                {
                    if (parentForm2.dataGridView1.RowCount == 0)
                        return;

                    parentForm2.SearchPOList();
                }
            }
        }
    }
}