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
    public partial class ItemSoldListForReturn : Form
    {
        public LogInManagements parentForm;
        public POandReceiving parentForm2;
        NumberFormatInfo nfi = new NumberFormatInfo();
        SqlCommand cmd;
        SqlDataAdapter adapt;
        DataTable dt = new DataTable();
        DataTable dt2_All = new DataTable();
        DataTable dt3 = new DataTable();

        public Int64 RRID;
        public string RREmployeeID;
        public string RREmployeeName;
        public string RRVendor;
        public string RRStatus;
        public string RRCreateDate;
        public string RRPackingDate;
        public string RRShippingDate;
        public string RRTrackingNumber;

        int index1, index2, index3;
        string sp;
        string ItmBrand, ItmColor, ItmSize, ItmName, ItmUpc;
        int brandBoolNum, sizeBoolNum, colorBoolNum, nameBoolNum, upcBoolNum, totalBoolNum;

        Int64 totalSoldQty;
        double totalDiscount, totalSoldSales;

        public int optTopBottom = 0;
        public Int64 intNum = 0;
        public int optTrueFalse = 0;

        string ItmRRBrand, ItmRRName, ItmRRSize, ItmRRColor, ItmRRModel, ItmRRUpc;
        double ItmRRCostPrice = 0;

        bool c;

        public Int64 totalReturnQty = 0;
        public double totalReturnAmount = 0;

        int selectedcount = 0;
        int oldcount = 0;

        int formOpt = 0;
        int msgOpt = 0;

        SqlConnection connWH;
        SqlCommand cmdWH;

        public ItemSoldListForReturn(Int64 a, string b, string c, string d, string e, string f, string g, string h, string j, int k)
        {
            InitializeComponent();
            RRID = a;
            RREmployeeID = b;
            RREmployeeName = c;
            RRVendor = d;
            RRStatus = e;
            RRCreateDate = f;
            RRPackingDate = g;
            RRShippingDate = h;
            RRTrackingNumber = j;
            formOpt = k;
        }

        private void ItemSoldListForReturn_Load(object sender, EventArgs e)
        {
            if (formOpt == 0)
            {
                dt2_All.Columns.Add("Brand", typeof(string));
                dt2_All.Columns.Add("Name", typeof(string));
                dt2_All.Columns.Add("Size", typeof(string));
                dt2_All.Columns.Add("Color", typeof(string));
                dt2_All.Columns.Add("Model #", typeof(string));
                dt2_All.Columns.Add("UPC", typeof(string));
                dt2_All.Columns.Add("Cost Price", typeof(double)); ;
                dt2_All.Columns.Add("Return Qty", typeof(Int64));
                dt2_All.Columns.Add("Return Amount", typeof(double));
            }
            else if (formOpt == 1)
            {
                Bind_DatagridView2(RRID);

                totalReturnQty = 0; totalReturnAmount = 0;

                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    totalReturnQty = totalReturnQty + Convert.ToInt64(dataGridView2.Rows[i].Cells[7].Value);
                    totalReturnAmount = totalReturnAmount + Convert.ToDouble(dataGridView2.Rows[i].Cells[8].Value);
                }

                lblTotalItems.Text = dataGridView2.RowCount.ToString();
                lblTotalReturnQty.Text = totalReturnQty.ToString();
                lblTotalReturnAmount.Text = string.Format("{0:$0.00}", totalReturnAmount);
            }

            this.Text = "ITEM SOLD LIST FOR RETURN REPORT - " + parentForm.employeeID + " LOGGED IN " + parentForm.storeName;

            lblReturnReportID.Text = RRID.ToString();
            lblEmployeeID.Text = RREmployeeID;
            lblVendorName.Text = RRVendor;
            lblReturnReportStatus.Text = RRStatus;
            lblCreateDate.Text = RRCreateDate;

            if (lblReturnReportStatus.Text == "PENDING")
            {
                dataGridView2.Enabled = true;
                btnSelectAll.Enabled = true;
                btnAdd.Enabled = true;
                btnReset2.Enabled = true;

                btnSaveReturnReport.Enabled = true;
                btnDelete.Enabled = true;
                btnSubmit.Visible = true;
                btnSubmit.Enabled = true;
                btnTrackingNumber.Visible = false;
                btnTrackingNumber.Enabled = false;
                //btnPrintReturn.Enabled = false;
            }
            else
            {
                dataGridView2.Enabled = true;
                btnSelectAll.Enabled = false;
                btnAdd.Enabled = false;
                btnReset2.Enabled = false;

                btnSaveReturnReport.Enabled = false;
                btnDelete.Enabled = false;
                btnSubmit.Visible = false;
                btnSubmit.Enabled = false;
                btnTrackingNumber.Visible = true;
                btnTrackingNumber.Enabled = true;
                //btnPrintReturn.Enabled = true;
            }

            lblTotalItems.Text = dataGridView2.RowCount.ToString();
            lblTotalReturnQty.Text = totalReturnQty.ToString();
            lblTotalReturnAmount.Text = string.Format("{0:$0.00}", totalReturnAmount);
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

        private void btnSelectOpt_Click(object sender, EventArgs e)
        {
            ItemSoldListOption soldItemListOptionForm = new ItemSoldListOption(1);
            soldItemListOptionForm.parentForm2 = this;
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

                    for (int i = 0; i < dt.Rows.Count; i++)
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
            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = ItmName + "%";
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
            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = ItmName + "%";
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
            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = ItmName + "%";
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
            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = ItmName + "%";
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
            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = ItmName + "%";
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
            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = ItmName + "%";
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
            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = ItmName + "%";
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
            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = ItmName + "%";
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
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].HeaderText = "Size";
            dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].Width = 40;
            dataGridView1.Columns[3].HeaderText = "Color";
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].Width = 40;
            dataGridView1.Columns[4].HeaderText = "Model #";
            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].Width = 130;
            dataGridView1.Columns[5].HeaderText = "UPC";
            dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].Width = 80;
            dataGridView1.Columns[6].HeaderText = "Retail Price";
            dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].Width = 45;
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
            dataGridView1.Columns[8].Width = 35;
            dataGridView1.Columns[9].HeaderText = "Sold Qty";
            dataGridView1.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[9].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            dataGridView1.Columns[9].Width = 45;
            dataGridView1.Columns[10].HeaderText = "Discount";
            dataGridView1.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[10].DefaultCellStyle.BackColor = Color.LightYellow;
            dataGridView1.Columns[10].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[10].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[10].Width = 55;
            dataGridView1.Columns[11].HeaderText = "Sold Price";
            dataGridView1.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[11].DefaultCellStyle.BackColor = Color.NavajoWhite;
            dataGridView1.Columns[11].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[11].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[11].Width = 55;
            //dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[12].HeaderText = "Bin #";
            dataGridView1.Columns[12].Width = 35;
            dataGridView1.Columns[13].HeaderText = "Act";
            dataGridView1.Columns[13].Width = 25;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].Visible = false;
            dataGridView1.Columns[17].Visible = false;

            dataGridView1.ClearSelection();
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
                            dt2_All.Rows.Add(ItmRRBrand, ItmRRName, ItmRRSize, ItmRRColor, ItmRRModel, ItmRRUpc, ItmRRCostPrice, 1, ItmRRCostPrice);
                        }
                        else
                        {
                            Set_Variables(i);
                            c = Check_Duplicated(ItmRRSize, ItmRRColor, ItmRRUpc);

                            if (c == false)
                            {
                                dt2_All.Rows.Add(ItmRRBrand, ItmRRName, ItmRRSize, ItmRRColor, ItmRRModel, ItmRRUpc, ItmRRCostPrice, 1, ItmRRCostPrice);
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
                dataGridView2.Columns[6].HeaderText = "Cost Price";
                dataGridView2.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns[6].Width = 55;
                dataGridView2.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView2.Columns[6].DefaultCellStyle.BackColor = Color.NavajoWhite;
                dataGridView2.Columns[6].DefaultCellStyle.FormatProvider = nfi;
                dataGridView2.Columns[6].DefaultCellStyle.Format = "c";
                dataGridView2.Columns[7].HeaderText = "Return Qty";
                dataGridView2.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView2.Columns[7].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                dataGridView2.Columns[7].Width = 45;
                dataGridView2.Columns[8].HeaderText = "Return Amount";
                dataGridView2.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns[8].Width = 60;
                dataGridView2.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView2.Columns[8].DefaultCellStyle.BackColor = Color.NavajoWhite;
                dataGridView2.Columns[8].DefaultCellStyle.FormatProvider = nfi;
                dataGridView2.Columns[8].DefaultCellStyle.Format = "c";

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

                        totalReturnQty = 0; totalReturnAmount = 0;

                        for (int i = 0; i < dataGridView2.RowCount; i++)
                        {
                            totalReturnQty = totalReturnQty + Convert.ToInt64(dataGridView2.Rows[i].Cells[7].Value);
                            totalReturnAmount = totalReturnAmount + Convert.ToDouble(dataGridView2.Rows[i].Cells[8].Value);
                        }

                        lblTotalItems.Text = dataGridView2.RowCount.ToString();
                        lblTotalReturnQty.Text = totalReturnQty.ToString();
                        lblTotalReturnAmount.Text = string.Format("{0:$0.00}", totalReturnAmount);

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

                        totalReturnQty = 0; totalReturnAmount = 0;

                        for (int i = 0; i < dataGridView2.RowCount; i++)
                        {
                            totalReturnQty = totalReturnQty + Convert.ToInt64(dataGridView2.Rows[i].Cells[7].Value);
                            totalReturnAmount = totalReturnAmount + Convert.ToDouble(dataGridView2.Rows[i].Cells[8].Value);
                        }

                        lblTotalItems.Text = dataGridView2.RowCount.ToString();
                        lblTotalReturnQty.Text = totalReturnQty.ToString();
                        lblTotalReturnAmount.Text = string.Format("{0:$0.00}", totalReturnAmount);

                        oldcount = dataGridView2.RowCount;
                    }
                }
                else
                {
                }
            }
        }

        private void btnReset2_Click(object sender, EventArgs e)
        {
            dt2_All.Clear();
            dataGridView2.DataSource = null;

            totalReturnQty = 0; totalReturnAmount = 0;

            lblTotalItems.Text = dataGridView2.RowCount.ToString();
            lblTotalReturnQty.Text = totalReturnQty.ToString();
            lblTotalReturnAmount.Text = string.Format("{0:$0.00}", totalReturnAmount);
        }

        private void btnSaveReturnReport_Click(object sender, EventArgs e)
        {
            if (msgOpt == 0)
            {
                DialogResult MyDialogResult;
                MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (MyDialogResult == DialogResult.Yes)
                {
                    if (RRVendor == parentForm.WarehouseName1)
                    {
                        for (int i = 0; i < dataGridView2.RowCount; i++)
                        {
                            if (Check_UPC_To_Warehouse(dataGridView2.Rows[i].Cells[5].Value.ToString().Trim()) == false)
                            {
                                MessageBox.Show("ITEM UPC " + dataGridView2.Rows[i].Cells[5].Value.ToString().Trim() + " DOES NOT EXIST IN THE WAREHOUSE INVENTORY", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                dataGridView2.Rows[i].Selected = true;
                                return;
                            }
                        }
                    }

                    if (dataGridView2.RowCount == 0)
                    {
                        cmd = new SqlCommand("Delete_Previous_ReturnReportBody", parentForm.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@rrID", SqlDbType.BigInt).Value = RRID;

                        parentForm.conn.Open();
                        cmd.ExecuteNonQuery();
                        parentForm.conn.Close();

                        cmd.CommandText = "Update_ReturnReportHeader";
                        cmd.Connection = parentForm.conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@Seq", SqlDbType.Int).Value = 0;
                        cmd.Parameters.Add("@rrID", SqlDbType.BigInt).Value = RRID;
                        cmd.Parameters.Add("@rrShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                        cmd.Parameters.Add("@rrSubmitDate", SqlDbType.DateTime).Value = DateTime.Now;
                        cmd.Parameters.Add("@rrReturnedDate", SqlDbType.DateTime).Value = DateTime.Now;
                        cmd.Parameters.Add("@rrTrackingNumber", SqlDbType.NVarChar).Value = "N/A";
                        cmd.Parameters.Add("@rrReturnTotalAmount", SqlDbType.Money).Value = 0;
                        cmd.Parameters.Add("@rrReceivingTotalAmount", SqlDbType.Money).Value = 0;
                        cmd.Parameters.Add("@rrConfirmationID", SqlDbType.NVarChar).Value = "N/A";
                        cmd.Parameters.Add("@rrStatus", SqlDbType.NVarChar).Value = "PENDING";
                        cmd.Parameters.Add("@rrFirstContact", SqlDbType.NVarChar).Value = "N/A";

                        parentForm.conn.Open();
                        cmd.ExecuteNonQuery();
                        parentForm.conn.Close();

                        MessageBox.Show("SUCCESFULLY SAVED !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (dataGridView2.RowCount > 0)
                    {
                        cmd = new SqlCommand("Delete_Previous_ReturnReportBody", parentForm.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@rrID", SqlDbType.BigInt).Value = RRID;

                        parentForm.conn.Open();
                        cmd.ExecuteNonQuery();
                        parentForm.conn.Close();

                        cmd.CommandText = "Create_ReturnReportBody";
                        cmd.Connection = parentForm.conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();

                        for (int i = 0; i < dataGridView2.RowCount; i++)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@rrStoreCode", SqlDbType.NVarChar).Value = parentForm.StoreCode;
                            cmd.Parameters.Add("@rrID", SqlDbType.BigInt).Value = RRID;
                            cmd.Parameters.Add("@rrItemIndex", SqlDbType.Int).Value = i + 1;
                            cmd.Parameters.Add("@rrItemBrand", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[i].Cells[0].Value);
                            cmd.Parameters.Add("@rrItemName", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[i].Cells[1].Value);
                            cmd.Parameters.Add("@rrItemSize", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[i].Cells[2].Value);
                            cmd.Parameters.Add("@rrItemColor", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[i].Cells[3].Value);
                            cmd.Parameters.Add("@rrItemModelNum", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[i].Cells[4].Value);
                            cmd.Parameters.Add("@rrItemUpc", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[i].Cells[5].Value);
                            cmd.Parameters.Add("@rrItemCostPrice", SqlDbType.Money).Value = Convert.ToDouble(dataGridView2.Rows[i].Cells[6].Value);
                            cmd.Parameters.Add("@rrItemReturnQty", SqlDbType.Int).Value = Convert.ToInt16(dataGridView2.Rows[i].Cells[7].Value);
                            cmd.Parameters.Add("@rrItemReturnAmount ", SqlDbType.Money).Value = Convert.ToDouble(dataGridView2.Rows[i].Cells[8].Value);

                            parentForm.conn.Open();
                            cmd.ExecuteNonQuery();
                            parentForm.conn.Close();
                        }

                        cmd.CommandText = "Update_ReturnReportHeader";
                        cmd.Connection = parentForm.conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@Seq", SqlDbType.Int).Value = 0;
                        cmd.Parameters.Add("@rrID", SqlDbType.BigInt).Value = RRID;
                        cmd.Parameters.Add("@rrShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                        cmd.Parameters.Add("@rrSubmitDate", SqlDbType.DateTime).Value = DateTime.Now;
                        cmd.Parameters.Add("@rrReturnedDate", SqlDbType.DateTime).Value = DateTime.Now;
                        cmd.Parameters.Add("@rrTrackingNumber", SqlDbType.NVarChar).Value = "N/A";
                        cmd.Parameters.Add("@rrReturnTotalAmount", SqlDbType.Money).Value = totalReturnAmount;
                        cmd.Parameters.Add("@rrReceivingTotalAmount", SqlDbType.Money).Value = 0;
                        cmd.Parameters.Add("@rrConfirmationID", SqlDbType.NVarChar).Value = "N/A";
                        cmd.Parameters.Add("@rrStatus", SqlDbType.NVarChar).Value = "PENDING";
                        cmd.Parameters.Add("@rrFirstContact", SqlDbType.NVarChar).Value = "N/A";

                        parentForm.conn.Open();
                        cmd.ExecuteNonQuery();
                        parentForm.conn.Close();

                        MessageBox.Show("SUCCESFULLY SAVED !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    //Bind_DatagridView2(RRID);
                    Bind_DatagridView2_2(RRID);
                }
            }
            else if (msgOpt == 1)
            {
                if (dataGridView2.RowCount == 0)
                {
                    cmd = new SqlCommand("Delete_Previous_ReturnReportBody", parentForm.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@rrID", SqlDbType.BigInt).Value = RRID;

                    parentForm.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm.conn.Close();

                    cmd.CommandText = "Update_ReturnReportHeader";
                    cmd.Connection = parentForm.conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@Seq", SqlDbType.Int).Value = 0;
                    cmd.Parameters.Add("@rrID", SqlDbType.BigInt).Value = RRID;
                    cmd.Parameters.Add("@rrShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                    cmd.Parameters.Add("@rrSubmitDate", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@rrReturnedDate", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@rrTrackingNumber", SqlDbType.NVarChar).Value = "N/A";
                    cmd.Parameters.Add("@rrReturnTotalAmount", SqlDbType.Money).Value = 0;
                    cmd.Parameters.Add("@rrReceivingTotalAmount", SqlDbType.Money).Value = 0;
                    cmd.Parameters.Add("@rrConfirmationID", SqlDbType.NVarChar).Value = "N/A";
                    cmd.Parameters.Add("@rrStatus", SqlDbType.NVarChar).Value = "PENDING";
                    cmd.Parameters.Add("@rrFirstContact", SqlDbType.NVarChar).Value = "N/A";

                    parentForm.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm.conn.Close();
                }
                else if (dataGridView2.RowCount > 0)
                {
                    cmd = new SqlCommand("Delete_Previous_ReturnReportBody", parentForm.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@rrID", SqlDbType.BigInt).Value = RRID;

                    parentForm.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm.conn.Close();

                    cmd.CommandText = "Create_ReturnReportBody";
                    cmd.Connection = parentForm.conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    for (int i = 0; i < dataGridView2.RowCount; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@rrStoreCode", SqlDbType.NVarChar).Value = parentForm.StoreCode;
                        cmd.Parameters.Add("@rrID", SqlDbType.BigInt).Value = RRID;
                        cmd.Parameters.Add("@rrItemIndex", SqlDbType.Int).Value = i + 1;
                        cmd.Parameters.Add("@rrItemBrand", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[i].Cells[0].Value);
                        cmd.Parameters.Add("@rrItemName", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[i].Cells[1].Value);
                        cmd.Parameters.Add("@rrItemSize", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[i].Cells[2].Value);
                        cmd.Parameters.Add("@rrItemColor", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[i].Cells[3].Value);
                        cmd.Parameters.Add("@rrItemModelNum", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[i].Cells[4].Value);
                        cmd.Parameters.Add("@rrItemUpc", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[i].Cells[5].Value);
                        cmd.Parameters.Add("@rrItemCostPrice", SqlDbType.Money).Value = Convert.ToDouble(dataGridView2.Rows[i].Cells[6].Value);
                        cmd.Parameters.Add("@rrItemReturnQty", SqlDbType.Int).Value = Convert.ToInt16(dataGridView2.Rows[i].Cells[7].Value);
                        cmd.Parameters.Add("@rrItemReturnAmount ", SqlDbType.Money).Value = Convert.ToDouble(dataGridView2.Rows[i].Cells[8].Value);

                        parentForm.conn.Open();
                        cmd.ExecuteNonQuery();
                        parentForm.conn.Close();
                    }

                    cmd.CommandText = "Update_ReturnReportHeader";
                    cmd.Connection = parentForm.conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@Seq", SqlDbType.Int).Value = 0;
                    cmd.Parameters.Add("@rrID", SqlDbType.BigInt).Value = RRID;
                    cmd.Parameters.Add("@rrShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                    cmd.Parameters.Add("@rrSubmitDate", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@rrReturnedDate", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@rrTrackingNumber", SqlDbType.NVarChar).Value = "N/A";
                    cmd.Parameters.Add("@rrReturnTotalAmount", SqlDbType.Money).Value = totalReturnAmount;
                    cmd.Parameters.Add("@rrReceivingTotalAmount", SqlDbType.Money).Value = 0;
                    cmd.Parameters.Add("@rrConfirmationID", SqlDbType.NVarChar).Value = "N/A";
                    cmd.Parameters.Add("@rrStatus", SqlDbType.NVarChar).Value = "PENDING";
                    cmd.Parameters.Add("@rrFirstContact", SqlDbType.NVarChar).Value = "N/A";

                    parentForm.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm.conn.Close();
                }

                Bind_DatagridView2_2(RRID);
            }

            if (parentForm2.IsDisposed == false)
            {
                if (parentForm2.dataGridView1.RowCount == 0)
                    return;

                parentForm2.SearchReturnReportList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView2.RowCount == 0)
                return;

            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                dataGridView2.Rows.Remove(row);
            }

            totalReturnQty = 0; totalReturnAmount = 0;

            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                totalReturnQty = totalReturnQty + Convert.ToInt64(dataGridView2.Rows[i].Cells[7].Value);
                totalReturnAmount = totalReturnAmount + Convert.ToDouble(dataGridView2.Rows[i].Cells[6].Value) * Convert.ToInt64(dataGridView2.Rows[i].Cells[7].Value);
            }

            lblTotalItems.Text = dataGridView2.RowCount.ToString();
            lblTotalReturnQty.Text = totalReturnQty.ToString();
            lblTotalReturnAmount.Text = string.Format("{0:$0.00}", totalReturnAmount);
        }

        private void btnExcel2_Click(object sender, EventArgs e)
        {
            if (parentForm.employeeID.ToUpper() == "ADMIN" | parentForm.specialCode == parentForm.txtSpecialCode.Text.Trim().ToString().ToUpper())
            {
                if (dataGridView2.RowCount > 0)
                {
                    this.Enabled = false;

                    Excel_12.Application ReportFile;
                    Excel_12._Workbook WorkBook;
                    Excel_12._Worksheet WorkSheet;
                    //Excel_12.Range Range;

                    string MaxRow = Convert.ToString(dt2_All.Rows.Count + 1);
                    String MaxColumn = ((String)(Convert.ToChar(dt2_All.Columns.Count / 26 + 64).ToString() + Convert.ToChar(dt2_All.Columns.Count % 26 + 64))).Replace('@', ' ').Trim();
                    String MaxCell = MaxColumn + MaxRow;

                    ReportFile = new Excel_12.Application();
                    ReportFile.Visible = false;

                    WorkBook = (Excel_12._Workbook)(ReportFile.Workbooks.Add("workbook"));
                    WorkSheet = (Excel_12._Worksheet)WorkBook.ActiveSheet;

                    for (int i = 0; i < dt2_All.Columns.Count; i++)
                        WorkSheet.Cells[1, i + 1] = dt2_All.Columns[i].ColumnName;

                    string[,] Values = new string[dt2_All.Rows.Count, dt2_All.Columns.Count];

                    for (int i = 0; i < dt2_All.Rows.Count; i++)
                        for (int j = 0; j < dt2_All.Columns.Count; j++)
                        {

                            Values[i, j] = dt2_All.Rows[i][j].ToString();

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
                if (dataGridView2.RowCount > 0)
                {
                    ExportDataGridViewTo_Excel12(dataGridView2);
                }
                else
                {
                    MessageBox.Show("NO DATA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            if (lblReturnReportStatus.Text == "PENDING")
            {
                if (dataGridView2.RowCount > 0)
                {
                    DialogResult MyDialogResult;
                    MyDialogResult = MessageBox.Show(this, "ARE YOU SURE YOU WANT TO SUBMIT THE RETURN REPORT?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (MyDialogResult == DialogResult.Yes)
                    {
                        msgOpt = 1;
                        btnSaveReturnReport_Click(null, null);
                        msgOpt = 0;

                        SubmitReturnReport submitReturnReportForm = new SubmitReturnReport(RRID);
                        submitReturnReportForm.parentForm1 = this.parentForm;

                        if (parentForm2.IsDisposed == false)
                            submitReturnReportForm.parentForm2 = this.parentForm2;
                        
                        submitReturnReportForm.parentForm3 = this;
                        submitReturnReportForm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("NO ITEM.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("THIS RETURN REPROT IS AREADY SUBMITTED.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        
        }

        private void dataGridView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lblReturnReportStatus.Text == "PENDING")
            {
                if (dataGridView2.RowCount > 0)
                {
                    ChangeValue changeValueForm = new ChangeValue(2);
                    changeValueForm.parentForm3 = this;
                    changeValueForm.ShowDialog();
                }
            }
        }

        private void Set_Variables(int idx)
        {
            ItmRRBrand = Convert.ToString(dataGridView1.Rows[idx].Cells[0].Value);
            ItmRRName = Convert.ToString(dataGridView1.Rows[idx].Cells[1].Value);
            ItmRRSize = Convert.ToString(dataGridView1.Rows[idx].Cells[2].Value);
            ItmRRColor = Convert.ToString(dataGridView1.Rows[idx].Cells[3].Value);
            ItmRRModel = Convert.ToString(dataGridView1.Rows[idx].Cells[4].Value);
            ItmRRUpc = Convert.ToString(dataGridView1.Rows[idx].Cells[5].Value);
            ItmRRCostPrice = Convert.ToDouble(dataGridView1.Rows[idx].Cells[7].Value);
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

        private void lblReturnReportStatus_TextChanged(object sender, EventArgs e)
        {
            if (lblReturnReportStatus.Text == "PENDING")
            {
                dataGridView2.Enabled = true;
                btnSelectAll.Enabled = true;
                btnAdd.Enabled = true;
                btnReset2.Enabled = true;

                btnSaveReturnReport.Enabled = true;
                btnDelete.Enabled = true;
                btnSubmit.Visible = true;
                btnSubmit.Enabled = true;
                btnTrackingNumber.Visible = false;
                btnTrackingNumber.Enabled = false;
                //btnPrintReturn.Enabled = false;
            }
            else
            {
                dataGridView2.Enabled = false;
                btnSelectAll.Enabled = false;
                btnAdd.Enabled = false;
                btnReset2.Enabled = false;

                btnSaveReturnReport.Enabled = false;
                btnDelete.Enabled = false;
                btnSubmit.Visible = false;
                btnSubmit.Enabled = false;
                btnTrackingNumber.Visible = true;
                btnTrackingNumber.Enabled = true;
                //btnPrintReturn.Enabled = true;
            }
        }

        private void Bind_DatagridView2(Int64 RID)
        {
            dataGridView2.DataSource = null;
            dt2_All.Clear();

            cmd = new SqlCommand("Show_ReturnReportBody", parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@rrID", SqlDbType.BigInt).Value = RID;
            adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            adapt.Fill(dt2_All);
            parentForm.conn.Close();

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
            dataGridView2.Columns[6].HeaderText = "Cost Price";
            dataGridView2.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns[6].Width = 55;
            dataGridView2.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView2.Columns[6].DefaultCellStyle.BackColor = Color.NavajoWhite;
            dataGridView2.Columns[6].DefaultCellStyle.FormatProvider = nfi;
            dataGridView2.Columns[6].DefaultCellStyle.Format = "c";
            dataGridView2.Columns[7].HeaderText = "Return Qty";
            dataGridView2.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView2.Columns[7].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            dataGridView2.Columns[7].Width = 45;
            dataGridView2.Columns[8].HeaderText = "Return Amount";
            dataGridView2.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns[8].Width = 60;
            dataGridView2.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView2.Columns[8].DefaultCellStyle.BackColor = Color.NavajoWhite;
            dataGridView2.Columns[8].DefaultCellStyle.FormatProvider = nfi;
            dataGridView2.Columns[8].DefaultCellStyle.Format = "c";

            dataGridView2.ClearSelection();
        }

        private void Bind_DatagridView2_2(Int64 RID)
        {
            dataGridView2.DataSource = null;
            dt3.Clear();

            cmd = new SqlCommand("Show_ReturnReportBody", parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@rrID", SqlDbType.BigInt).Value = RID;
            adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            adapt.Fill(dt3);
            parentForm.conn.Close();

            dataGridView2.DataSource = dt3;
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
            dataGridView2.Columns[6].HeaderText = "Cost Price";
            dataGridView2.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns[6].Width = 55;
            dataGridView2.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView2.Columns[6].DefaultCellStyle.BackColor = Color.NavajoWhite;
            dataGridView2.Columns[6].DefaultCellStyle.FormatProvider = nfi;
            dataGridView2.Columns[6].DefaultCellStyle.Format = "c";
            dataGridView2.Columns[7].HeaderText = "Return Qty";
            dataGridView2.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView2.Columns[7].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            dataGridView2.Columns[7].Width = 45;
            dataGridView2.Columns[8].HeaderText = "Return Amount";
            dataGridView2.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns[8].Width = 60;
            dataGridView2.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView2.Columns[8].DefaultCellStyle.BackColor = Color.NavajoWhite;
            dataGridView2.Columns[8].DefaultCellStyle.FormatProvider = nfi;
            dataGridView2.Columns[8].DefaultCellStyle.Format = "c";

            dataGridView2.ClearSelection();
        }

        private void ItemSoldListForReturn_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (parentForm2.IsDisposed == false)
            {
                if (parentForm2.dataGridView1.RowCount == 0)
                    return;

                parentForm2.SearchReturnReportList();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dataGridView1.RowCount > 0)
                {
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        if (dataGridView1.Rows[i].Selected == true)
                        {
                            ItemInformation itemInformationForm = new ItemInformation(Convert.ToString(dataGridView1.Rows[i].Cells[5].Value), 3);
                            itemInformationForm.parentForm1 = this.parentForm;
                            itemInformationForm.parentForm5 = this;
                            itemInformationForm.ShowDialog();

                            break;
                        }
                    }
                }
            }
        }

        private void btnPrintReturn_Click(object sender, EventArgs e)
        {
            if (dataGridView2.RowCount > 0)
            {
                ReturnPrinting returnPrintingForm = new ReturnPrinting(0);
                returnPrintingForm.parentForm1 = this.parentForm;
                returnPrintingForm.parentForm2 = this;
                returnPrintingForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("NO ITEM", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnTrackingNumber_Click(object sender, EventArgs e)
        {
            ViewTrackingNumber viewTrackingNumberForm = new ViewTrackingNumber();
            viewTrackingNumberForm.parentForm1 = this.parentForm;
            viewTrackingNumberForm.parentForm2 = this;
            viewTrackingNumberForm.ShowDialog();
        }

        private bool Check_UPC_To_Warehouse(string upc)
        {
            connWH = new SqlConnection(parentForm.OtherStoreConnectionString(parentForm.WarehouseStoreCode1));
            cmdWH = new SqlCommand("Check_Upc", connWH);
            cmdWH.CommandType = CommandType.StoredProcedure;
            cmdWH.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = upc;
            SqlParameter CheckNum_Param = cmdWH.Parameters.Add("@CheckNum", SqlDbType.Int);
            CheckNum_Param.Direction = ParameterDirection.Output;

            connWH.Open();
            cmdWH.ExecuteNonQuery();
            connWH.Close();

            if (Convert.ToInt16(cmdWH.Parameters["@CheckNum"].Value) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}