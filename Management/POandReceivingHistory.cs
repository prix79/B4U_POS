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
    public partial class POandReceivingHistory : Form
    {
        public LogInManagements parentForm;

        NumberFormatInfo nfi = new NumberFormatInfo();
        SqlCommand cmd;
        SqlDataAdapter adapt;
        DataTable dt = new DataTable();
        DataTable dt2_All = new DataTable();
        DataTable dt2_SC = new DataTable();

        int index1, index2, index3;
        string sp, sc;
        string ItmBrand, ItmColor, ItmSize, ItmName, ItmUpc;
        int brandBoolNum, sizeBoolNum, colorBoolNum, nameBoolNum, upcBoolNum, totalBoolNum;

        Int64 totalOrderQty, totalReceivingQty;
        double totalOrderAmount, totalReceivingAmount;

        public POandReceivingHistory()
        {
            InitializeComponent();
        }

        private void ItemMovingHistory_Load(object sender, EventArgs e)
        {
            this.Text = "P/O AND RECEIVING HISTORY - " + parentForm.employeeID + " LOGGED IN " + parentForm.storeName;

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

            SqlCommand cmd_StoreList = new SqlCommand("Get_Retail_StoreCode", parentForm.conn);
            cmd_StoreList.CommandType = CommandType.StoredProcedure;
            DataSet ds_StoreList = new DataSet();
            SqlDataAdapter adapt_StoreList = new SqlDataAdapter(cmd_StoreList);

            parentForm.conn.Open();
            ds_StoreList.Clear();
            adapt_StoreList.Fill(ds_StoreList);
            parentForm.conn.Close();

            cmbStoreCode.DataSource = ds_StoreList.Tables[0].DefaultView;
            cmbStoreCode.ValueMember = "CIStoreCode";
            cmbStoreCode.DisplayMember = "CIStoreCode";

            if (parentForm.userLevel >= parentForm.GeneralManagerLV)
            {
                //lblStoreCode.Visible = true;
                //cmbStoreCode.Visible = true;
            }
            else
            {
            }

            if (parentForm.StoreCode == "B4UWH")
            {
                DataRow dr = ds_StoreList.Tables[0].NewRow();
                dr["CIStoreCode"] = "ALL";
                ds_StoreList.Tables[0].Rows.Add(dr);
            }
            else
            {
                groupBox1.Enabled = false;
            }

            dataGridView1.Visible = true;
            dataGridView2.Visible = false;

            txtStartDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            txtEndDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
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

        private void btnOK_Click(object sender, EventArgs e)
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

            btnOK.Enabled = false;

            totalOrderQty = 0; totalReceivingQty = 0; totalOrderAmount = 0; totalReceivingAmount = 0;
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

            if (parentForm.StoreCode.ToUpper()=="B4UWH")
            {
                if (rdoBtnInStore.Checked == true)
                {
                    sc = parentForm.StoreCode.ToUpper();

                    if (cmbCategory1.SelectedIndex == 0)
                    {
                        sp = "Show_POandReceiving_History";
                        DataBind(totalBoolNum, sp, sc, txtStartDate.Text, txtEndDate.Text, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);
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
                                sp = "Show_POandReceiving_History_With_Category_1_2_3";
                                DataBind(totalBoolNum, sp, sc, index1, index2, index3, txtStartDate.Text, txtEndDate.Text, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);
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
                                sp = "Show_POandReceiving_History_With_Category_1_2";
                                DataBind(totalBoolNum, sp, sc, index1, index2, txtStartDate.Text, txtEndDate.Text, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);
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
                            sp = "Show_POandReceiving_History_With_Category_1";
                            DataBind(totalBoolNum, sp, sc, index1, txtStartDate.Text, txtEndDate.Text, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);
                            BindDataGridView();
                        }
                    }
                }
                else if (rdoBtnSending.Checked == true)
                {
                    sc = cmbStoreCode.Text.ToUpper();

                    if (cmbStoreCode.Text == "ALL")
                    {
                        if (cmbCategory1.SelectedIndex == 0)
                        {
                            sp = "Show_POSending_History";
                            DataBind(totalBoolNum, sp, sc, txtStartDate.Text, txtEndDate.Text, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);
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
                                    sp = "Show_POSending_History_With_Category_1_2_3";
                                    DataBind(totalBoolNum, sp, sc, index1, index2, index3, txtStartDate.Text, txtEndDate.Text, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);
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
                                    sp = "Show_POSending_History_With_Category_1_2";
                                    DataBind(totalBoolNum, sp, sc, index1, index2, txtStartDate.Text, txtEndDate.Text, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);
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
                                sp = "Show_POSending_History_With_Category_1";
                                DataBind(totalBoolNum, sp, sc, index1, txtStartDate.Text, txtEndDate.Text, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);
                                BindDataGridView();
                            }
                        }
                    }
                    else
                    {
                        if (cmbCategory1.SelectedIndex == 0)
                        {
                            sp = "Show_POSending_History_SC";
                            DataBind(totalBoolNum, sp, sc, txtStartDate.Text, txtEndDate.Text, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);
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
                                    sp = "Show_POSending_History_With_Category_1_2_3_SC";
                                    DataBind(totalBoolNum, sp, sc, index1, index2, index3, txtStartDate.Text, txtEndDate.Text, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);
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
                                    sp = "Show_POSending_History_With_Category_1_2_SC";
                                    DataBind(totalBoolNum, sp, sc, index1, index2, txtStartDate.Text, txtEndDate.Text, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);
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
                                sp = "Show_POSending_History_With_Category_1_SC";
                                DataBind(totalBoolNum, sp, sc, index1, txtStartDate.Text, txtEndDate.Text, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);
                                BindDataGridView();
                            }
                        }
                    }
                }
            }
            else
            {
                sc = parentForm.StoreCode.ToUpper();

                if (cmbCategory1.SelectedIndex == 0)
                {
                    sp = "Show_POandReceiving_History";
                    DataBind(totalBoolNum, sp, sc, txtStartDate.Text, txtEndDate.Text, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);
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
                            sp = "Show_POandReceiving_History_With_Category_1_2_3";
                            DataBind(totalBoolNum, sp, sc, index1, index2, index3, txtStartDate.Text, txtEndDate.Text, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);
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
                            sp = "Show_POandReceiving_History_With_Category_1_2";
                            DataBind(totalBoolNum, sp, sc, index1, index2, txtStartDate.Text, txtEndDate.Text, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);
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
                        sp = "Show_POandReceiving_History_With_Category_1";
                        DataBind(totalBoolNum, sp, sc, index1, txtStartDate.Text, txtEndDate.Text, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);
                        BindDataGridView();
                    }
                }
            }

            if (rdoBtnInStore.Checked == true)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    totalOrderQty = totalOrderQty + Convert.ToInt64(dataGridView1.Rows[i].Cells[11].Value);
                    totalReceivingQty = totalReceivingQty + Convert.ToInt64(dataGridView1.Rows[i].Cells[12].Value);
                    totalOrderAmount = totalOrderAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[13].Value);
                    totalReceivingAmount = totalReceivingAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[14].Value);
                }

                lblTotalCount.Text = Convert.ToString(dataGridView1.RowCount);
                lblTotalOrderQty.Text = Convert.ToString(totalOrderQty);
                label16.Text = "TOTAL RECEIVING QTY";
                lblTotalReceivingQty.Text = Convert.ToString(totalReceivingQty);
                lblTotalOrderAmount.Text = string.Format("{0:$0.00}", totalOrderAmount);
                label18.Text = "TOTAL RECEIVING AMOUNT";
                lblTotalReceivingAmount.Text = string.Format("{0:$0.00}", totalReceivingAmount);
            }
            else if (rdoBtnSending.Checked == true)
            {
                if (cmbStoreCode.Text.ToUpper() == "ALL")
                {
                    for (int i = 0; i < dataGridView2.RowCount; i++)
                    {
                        totalOrderQty = totalOrderQty + Convert.ToInt64(dataGridView2.Rows[i].Cells[10].Value);
                        totalReceivingQty = totalReceivingQty + Convert.ToInt64(dataGridView2.Rows[i].Cells[11].Value);
                        totalOrderAmount = totalOrderAmount + Convert.ToDouble(dataGridView2.Rows[i].Cells[12].Value);
                        totalReceivingAmount = totalReceivingAmount + Convert.ToDouble(dataGridView2.Rows[i].Cells[13].Value);
                    }

                    lblTotalCount.Text = Convert.ToString(dataGridView2.RowCount);
                    lblTotalOrderQty.Text = Convert.ToString(totalOrderQty);
                    label16.Text = "TOTAL SENDING QTY";
                    lblTotalReceivingQty.Text = Convert.ToString(totalReceivingQty);
                    lblTotalOrderAmount.Text = string.Format("{0:$0.00}", totalOrderAmount);
                    label18.Text = "TOTAL SENDING AMOUNT";
                    lblTotalReceivingAmount.Text = string.Format("{0:$0.00}", totalReceivingAmount);
                }
                else
                {
                    for (int i = 0; i < dataGridView2.RowCount; i++)
                    {
                        totalOrderQty = totalOrderQty + Convert.ToInt64(dataGridView2.Rows[i].Cells[11].Value);
                        totalReceivingQty = totalReceivingQty + Convert.ToInt64(dataGridView2.Rows[i].Cells[12].Value);
                        totalOrderAmount = totalOrderAmount + Convert.ToDouble(dataGridView2.Rows[i].Cells[13].Value);
                        totalReceivingAmount = totalReceivingAmount + Convert.ToDouble(dataGridView2.Rows[i].Cells[14].Value);
                    }

                    lblTotalCount.Text = Convert.ToString(dataGridView2.RowCount);
                    lblTotalOrderQty.Text = Convert.ToString(totalOrderQty);
                    label16.Text = "TOTAL SENDING QTY";
                    lblTotalReceivingQty.Text = Convert.ToString(totalReceivingQty);
                    lblTotalOrderAmount.Text = string.Format("{0:$0.00}", totalOrderAmount);
                    label18.Text = "TOTAL SENDING AMOUNT";
                    lblTotalReceivingAmount.Text = string.Format("{0:$0.00}", totalReceivingAmount);
                }
            }

            btnOK.Enabled = true;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
                this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dt.Clear();
            dt2_All.Clear();
            dt2_SC.Clear();
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
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

            totalOrderQty = 0; totalReceivingQty = 0; totalOrderAmount = 0; totalReceivingAmount = 0;

            lblTotalCount.Text = "";
            lblTotalOrderQty.Text = "";
            lblTotalReceivingQty.Text = "";
            lblTotalOrderAmount.Text = "";
            lblTotalReceivingAmount.Text = "";
            txtName.Text = "";
            txtUpc.Text = "";

            txtName.Select();
            txtName.Focus();
        }

        public void DataBind(int totalBoolNum, string sp, string sc, string sDate, string eDate, string ItmBrand, string ItmSize, string ItmColor, string ItmName, string ItmUpc)
        {
            if (rdoBtnInStore.Checked == true)
            {
                dt.Clear();

                cmd = new SqlCommand(sp, parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
                cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = sc;
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = sDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = eDate;
                cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = "%" + ItmBrand + "%";
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
            else
            {
                if (cmbStoreCode.Text.ToUpper() == "ALL")
                {
                    dt2_All.Clear();

                    cmd = new SqlCommand(sp, parentForm.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
                    cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = sc;
                    cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = sDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = eDate;
                    cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = "%" + ItmBrand + "%";
                    cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
                    cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
                    cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                    cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
                    adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd;

                    parentForm.conn.Open();
                    adapt.Fill(dt2_All);
                    parentForm.conn.Close();
                }
                else
                {
                    dt2_SC.Clear();

                    cmd = new SqlCommand(sp, parentForm.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
                    cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = sc;
                    cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = sDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = eDate;
                    cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = "%" + ItmBrand + "%";
                    cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
                    cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
                    cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                    cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
                    adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd;

                    parentForm.conn.Open();
                    adapt.Fill(dt2_SC);
                    parentForm.conn.Close();
                }
            }
        }

        public void DataBind(int totalBoolNum, string sp, string sc, int idx1, string sDate, string eDate, string ItmBrand, string ItmSize, string ItmColor, string ItmName, string ItmUpc)
        {
            if (rdoBtnInStore.Checked == true)
            {
                dt.Clear();

                cmd = new SqlCommand(sp, parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
                cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = sc;
                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = idx1;
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = sDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = eDate;
                cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = "%" + ItmBrand + "%";
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
            else
            {
                if (cmbStoreCode.Text.ToUpper() == "ALL")
                {
                    dt2_All.Clear();

                    cmd = new SqlCommand(sp, parentForm.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
                    cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = sc;
                    cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = idx1;
                    cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = sDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = eDate;
                    cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = "%" + ItmBrand + "%";
                    cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
                    cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
                    cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                    cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
                    adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd;

                    parentForm.conn.Open();
                    adapt.Fill(dt2_All);
                    parentForm.conn.Close();
                }
                else
                {
                    dt2_SC.Clear();

                    cmd = new SqlCommand(sp, parentForm.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
                    cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = sc;
                    cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = idx1;
                    cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = sDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = eDate;
                    cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = "%" + ItmBrand + "%";
                    cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
                    cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
                    cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                    cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
                    adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd;

                    parentForm.conn.Open();
                    adapt.Fill(dt2_SC);
                    parentForm.conn.Close();
                }
            }
        }

        public void DataBind(int totalBoolNum, string sp, string sc, int idx1, int idx2, string sDate, string eDate, string ItmBrand, string ItmSize, string ItmColor, string ItmName, string ItmUpc)
        {
            if (rdoBtnInStore.Checked == true)
            {
                dt.Clear();

                cmd = new SqlCommand(sp, parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
                cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = sc;
                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = idx1;
                cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = idx2;
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = sDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = eDate;
                cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = "%" + ItmBrand + "%";
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
            else
            {
                if (cmbStoreCode.Text.ToUpper() == "ALL")
                {
                    dt2_All.Clear();

                    cmd = new SqlCommand(sp, parentForm.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
                    cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = sc;
                    cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = idx1;
                    cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = idx2;
                    cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = sDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = eDate;
                    cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = "%" + ItmBrand + "%";
                    cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
                    cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
                    cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                    cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
                    adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd;

                    parentForm.conn.Open();
                    adapt.Fill(dt2_All);
                    parentForm.conn.Close();
                }
                else
                {
                    dt2_SC.Clear();

                    cmd = new SqlCommand(sp, parentForm.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
                    cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = sc;
                    cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = idx1;
                    cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = idx2;
                    cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = sDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = eDate;
                    cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = "%" + ItmBrand + "%";
                    cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
                    cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
                    cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                    cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
                    adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd;

                    parentForm.conn.Open();
                    adapt.Fill(dt2_SC);
                    parentForm.conn.Close();
                }
            }
        }

        public void DataBind(int totalBoolNum, string sp, string sc, int idx1, int idx2, int idx3, string sDate, string eDate, string ItmBrand, string ItmSize, string ItmColor, string ItmName, string ItmUpc)
        {
            if (rdoBtnInStore.Checked == true)
            {
                dt.Clear();

                cmd = new SqlCommand(sp, parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
                cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = sc;
                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = idx1;
                cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = idx2;
                cmd.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = idx3;
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = sDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = eDate;
                cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = "%" + ItmBrand + "%";
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
            else
            {
                if (cmbStoreCode.Text.ToUpper() == "ALL")
                {
                    dt2_All.Clear();

                    cmd = new SqlCommand(sp, parentForm.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
                    cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = sc;
                    cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = idx1;
                    cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = idx2;
                    cmd.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = idx3;
                    cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = sDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = eDate;
                    cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = "%" + ItmBrand + "%";
                    cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
                    cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
                    cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                    cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
                    adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd;

                    parentForm.conn.Open();
                    adapt.Fill(dt2_All);
                    parentForm.conn.Close();
                }
                else
                {
                    dt2_SC.Clear();

                    cmd = new SqlCommand(sp, parentForm.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
                    cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = sc;
                    cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = idx1;
                    cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = idx2;
                    cmd.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = idx3;
                    cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = sDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = eDate;
                    cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = "%" + ItmBrand + "%";
                    cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
                    cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
                    cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                    cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
                    adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd;

                    parentForm.conn.Open();
                    adapt.Fill(dt2_SC);
                    parentForm.conn.Close();
                }
            }
        }

        private void BindDataGridView()
        {
            if (parentForm.employeeID == "ADMIN")
            {
                if (rdoBtnInStore.Checked == true)
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = dt;
                    dataGridView1.ClearSelection();
                }
                else if (rdoBtnSending.Checked == true)
                {
                    if (cmbStoreCode.Text.ToUpper() == "ALL")
                    {
                        dataGridView2.DataSource = null;
                        dataGridView2.DataSource = dt2_All;
                        dataGridView2.ClearSelection();
                    }
                    else
                    {
                        dataGridView2.DataSource = null;
                        dataGridView2.DataSource = dt2_SC;
                        dataGridView2.ClearSelection();
                    }
                }
            }
            else
            {
                if (rdoBtnInStore.Checked == true)
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    dataGridView1.Columns[0].HeaderText = "Store Code";
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Brand";
                    dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[1].Width = 90;
                    dataGridView1.Columns[2].HeaderText = "Name";
                    dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[2].Width = 160;
                    dataGridView1.Columns[3].HeaderText = "Size";
                    dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[3].Width = 50;
                    dataGridView1.Columns[4].HeaderText = "Color";
                    dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[4].Width = 50;
                    dataGridView1.Columns[5].HeaderText = "Model #";
                    dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[5].Width = 135;
                    dataGridView1.Columns[6].Visible = false;
                    dataGridView1.Columns[7].Visible = false;
                    dataGridView1.Columns[8].Visible = false;
                    dataGridView1.Columns[9].HeaderText = "UPC";
                    dataGridView1.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[9].Width = 90;
                    dataGridView1.Columns[10].HeaderText = "On Hand";
                    dataGridView1.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[10].Width = 45;
                    dataGridView1.Columns[11].HeaderText = "Order Qty";
                    dataGridView1.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[11].Width = 55;
                    dataGridView1.Columns[11].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                    dataGridView1.Columns[12].HeaderText = "Receiving Qty";
                    dataGridView1.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[12].Width = 55;
                    dataGridView1.Columns[12].DefaultCellStyle.BackColor = Color.NavajoWhite;
                    dataGridView1.Columns[13].HeaderText = "Order Amount";
                    dataGridView1.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[13].Width = 70;
                    dataGridView1.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[13].DefaultCellStyle.FormatProvider = nfi;
                    dataGridView1.Columns[13].DefaultCellStyle.Format = "c";
                    dataGridView1.Columns[14].HeaderText = "Receiving Amount";
                    dataGridView1.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[14].Width = 70;
                    dataGridView1.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[14].DefaultCellStyle.FormatProvider = nfi;
                    dataGridView1.Columns[14].DefaultCellStyle.Format = "c";
                    dataGridView1.Columns[15].HeaderText = "Vendor";
                    dataGridView1.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[15].Width = 90;
                    dataGridView1.Columns[16].HeaderText = "Bin #";
                    dataGridView1.Columns[16].Width = 40;
                    dataGridView1.Columns[17].HeaderText = "Act";
                    dataGridView1.Columns[17].Width = 30;

                    dataGridView1.ClearSelection();
                }
                else if (rdoBtnSending.Checked == true)
                {
                    if (cmbStoreCode.Text.ToUpper() == "ALL")
                    {
                        dataGridView2.DataSource = null;
                        dataGridView2.DataSource = dt2_All;
                        dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                        dataGridView2.Columns[0].HeaderText = "Brand";
                        dataGridView2.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[0].Width = 90;
                        dataGridView2.Columns[1].HeaderText = "Name";
                        dataGridView2.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[1].Width = 160;
                        dataGridView2.Columns[2].HeaderText = "Size";
                        dataGridView2.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[2].Width = 50;
                        dataGridView2.Columns[3].HeaderText = "Color";
                        dataGridView2.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[3].Width = 50;
                        dataGridView2.Columns[4].HeaderText = "Model #";
                        dataGridView2.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[4].Width = 135;
                        dataGridView2.Columns[5].Visible = false;
                        dataGridView2.Columns[6].Visible = false;
                        dataGridView2.Columns[7].Visible = false;
                        dataGridView2.Columns[8].HeaderText = "UPC";
                        dataGridView2.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[8].Width = 90;
                        dataGridView2.Columns[9].HeaderText = "On Hand";
                        dataGridView2.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[9].Width = 45;
                        dataGridView2.Columns[10].HeaderText = "Order Qty";
                        dataGridView2.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[10].Width = 55;
                        dataGridView2.Columns[10].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                        dataGridView2.Columns[11].HeaderText = "Sending Qty";
                        dataGridView2.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[11].Width = 55;
                        dataGridView2.Columns[11].DefaultCellStyle.BackColor = Color.NavajoWhite;
                        dataGridView2.Columns[12].HeaderText = "Order Amount";
                        dataGridView2.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[12].Width = 70;
                        dataGridView2.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[12].DefaultCellStyle.FormatProvider = nfi;
                        dataGridView2.Columns[12].DefaultCellStyle.Format = "c";
                        dataGridView2.Columns[13].HeaderText = "Sending Amount";
                        dataGridView2.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[13].Width = 70;
                        dataGridView2.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[13].DefaultCellStyle.FormatProvider = nfi;
                        dataGridView2.Columns[13].DefaultCellStyle.Format = "c";
                        dataGridView2.Columns[14].HeaderText = "Vendor";
                        dataGridView2.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[14].Width = 90;
                        dataGridView2.Columns[15].HeaderText = "Bin #";
                        dataGridView2.Columns[15].Width = 40;
                        dataGridView2.Columns[16].HeaderText = "Act";
                        dataGridView2.Columns[16].Width = 30;
                    }
                    else
                    {
                        dataGridView2.DataSource = null;
                        dataGridView2.DataSource = dt2_SC;
                        dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                        dataGridView2.Columns[0].HeaderText = "Store Code";
                        dataGridView2.Columns[0].Visible = false;
                        dataGridView2.Columns[1].HeaderText = "Brand";
                        dataGridView2.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[1].Width = 90;
                        dataGridView2.Columns[2].HeaderText = "Name";
                        dataGridView2.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[2].Width = 160;
                        dataGridView2.Columns[3].HeaderText = "Size";
                        dataGridView2.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[3].Width = 50;
                        dataGridView2.Columns[4].HeaderText = "Color";
                        dataGridView2.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[4].Width = 50;
                        dataGridView2.Columns[5].HeaderText = "Model #";
                        dataGridView2.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[5].Width = 135;
                        dataGridView2.Columns[6].Visible = false;
                        dataGridView2.Columns[7].Visible = false;
                        dataGridView2.Columns[8].Visible = false;
                        dataGridView2.Columns[9].HeaderText = "UPC";
                        dataGridView2.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[9].Width = 90;
                        dataGridView2.Columns[10].HeaderText = "On Hand";
                        dataGridView2.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[10].Width = 45;
                        dataGridView2.Columns[11].HeaderText = "Order Qty";
                        dataGridView2.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[11].Width = 55;
                        dataGridView2.Columns[11].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                        dataGridView2.Columns[12].HeaderText = "Sending Qty";
                        dataGridView2.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[12].Width = 55;
                        dataGridView2.Columns[12].DefaultCellStyle.BackColor = Color.NavajoWhite;
                        dataGridView2.Columns[13].HeaderText = "Order Amount";
                        dataGridView2.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[13].Width = 70;
                        dataGridView2.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[13].DefaultCellStyle.FormatProvider = nfi;
                        dataGridView2.Columns[13].DefaultCellStyle.Format = "c";
                        dataGridView2.Columns[14].HeaderText = "Sending Amount";
                        dataGridView2.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[14].Width = 70;
                        dataGridView2.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[14].DefaultCellStyle.FormatProvider = nfi;
                        dataGridView2.Columns[14].DefaultCellStyle.Format = "c";
                        dataGridView2.Columns[15].HeaderText = "Vendor";
                        dataGridView2.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[15].Width = 90;
                        dataGridView2.Columns[16].HeaderText = "Bin #";
                        dataGridView2.Columns[16].Width = 40;
                        dataGridView2.Columns[17].HeaderText = "Act";
                        dataGridView2.Columns[17].Width = 30;
                    }

                    dataGridView2.ClearSelection();
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (rdoBtnInStore.Checked == true)
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
            else
            {
                if (cmbStoreCode.Text.ToUpper() == "ALL")
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

                            //for (int i = 0; i < dt.Rows.Count; i++)
                            for (int i = 0; i < dataGridView2.Rows.Count; i++)
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
                else
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

                            string MaxRow = Convert.ToString(dt2_SC.Rows.Count + 1);
                            String MaxColumn = ((String)(Convert.ToChar(dt2_SC.Columns.Count / 26 + 64).ToString() + Convert.ToChar(dt2_SC.Columns.Count % 26 + 64))).Replace('@', ' ').Trim();
                            String MaxCell = MaxColumn + MaxRow;

                            ReportFile = new Excel_12.Application();
                            ReportFile.Visible = false;

                            WorkBook = (Excel_12._Workbook)(ReportFile.Workbooks.Add("workbook"));
                            WorkSheet = (Excel_12._Worksheet)WorkBook.ActiveSheet;

                            for (int i = 0; i < dt2_SC.Columns.Count; i++)
                                WorkSheet.Cells[1, i + 1] = dt2_SC.Columns[i].ColumnName;

                            string[,] Values = new string[dt2_SC.Rows.Count, dt2_SC.Columns.Count];

                            //for (int i = 0; i < dt.Rows.Count; i++)
                            for (int i = 0; i < dataGridView2.Rows.Count; i++)
                                for (int j = 0; j < dt2_SC.Columns.Count; j++)
                                {

                                    Values[i, j] = dt2_SC.Rows[i][j].ToString();

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

        private void rdoBtnInStore_CheckedChanged(object sender, EventArgs e)
        {
            cmbStoreCode.Visible = false;
            cmbStoreCode.Visible = false;
            dataGridView1.Visible = true;
            dataGridView1.DataSource = null;
            dataGridView2.Visible = false;

            lblTotalCount.Text = "";
            lblTotalOrderQty.Text = "";
            label16.Text = "TOTAL RECEIVING QTY";
            lblTotalReceivingQty.Text = "";
            lblTotalOrderAmount.Text = "";
            label18.Text = "TOTAL RECEIVING AMOUNT";
            lblTotalReceivingAmount.Text = "";
        }

        private void rdoBtnSending_CheckedChanged(object sender, EventArgs e)
        {
            cmbStoreCode.Visible = true;
            cmbStoreCode.Visible = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            dataGridView2.DataSource = null;

            lblTotalCount.Text = "";
            lblTotalOrderQty.Text = "";
            label16.Text = "TOTAL SENDING QTY";
            lblTotalReceivingQty.Text = "";
            lblTotalOrderAmount.Text = "";
            label18.Text = "TOTAL SENDING AMOUNT";
            lblTotalReceivingAmount.Text = "";
        }

        /*private void POandReceivingHistory_Resize(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    //dataGridView1.DataSource = null;
                    //dataGridView1.DataSource = dt;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    dataGridView1.Columns[0].HeaderText = "Store Code";
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Brand";
                    dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[1].Width = 90;
                    dataGridView1.Columns[2].HeaderText = "Name";
                    dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[2].Width = 160;
                    dataGridView1.Columns[3].HeaderText = "Size";
                    dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[3].Width = 50;
                    dataGridView1.Columns[4].HeaderText = "Color";
                    dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[4].Width = 50;
                    dataGridView1.Columns[5].HeaderText = "Model #";
                    dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[5].Width = 135;
                    dataGridView1.Columns[6].Visible = false;
                    dataGridView1.Columns[7].Visible = false;
                    dataGridView1.Columns[8].Visible = false;
                    dataGridView1.Columns[9].HeaderText = "UPC";
                    dataGridView1.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[9].Width = 90;
                    dataGridView1.Columns[10].HeaderText = "On Hand";
                    dataGridView1.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[10].Width = 45;
                    dataGridView1.Columns[11].HeaderText = "Order Qty";
                    dataGridView1.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[11].Width = 55;
                    dataGridView1.Columns[11].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                    dataGridView1.Columns[12].HeaderText = "Receiving Qty";
                    dataGridView1.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[12].Width = 55;
                    dataGridView1.Columns[12].DefaultCellStyle.BackColor = Color.NavajoWhite;
                    dataGridView1.Columns[13].HeaderText = "Order Amount";
                    dataGridView1.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[13].Width = 70;
                    dataGridView1.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[13].DefaultCellStyle.FormatProvider = nfi;
                    dataGridView1.Columns[13].DefaultCellStyle.Format = "c";
                    dataGridView1.Columns[14].HeaderText = "Receiving Amount";
                    dataGridView1.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[14].Width = 70;
                    dataGridView1.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[14].DefaultCellStyle.FormatProvider = nfi;
                    dataGridView1.Columns[14].DefaultCellStyle.Format = "c";
                    dataGridView1.Columns[15].HeaderText = "Vendor";
                    dataGridView1.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[15].Width = 90;
                    dataGridView1.Columns[16].HeaderText = "Bin #";
                    dataGridView1.Columns[16].Width = 40;
                    dataGridView1.Columns[17].HeaderText = "Act";
                    dataGridView1.Columns[17].Width = 30;
                }
                else if (this.WindowState == FormWindowState.Maximized)
                {
                    //dataGridView1.DataSource = null;
                    //dataGridView1.DataSource = dt;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
        }*/
    }
}
