using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using Office_12 = Microsoft.Office.Core;
using Excel_12 = Microsoft.Office.Interop.Excel;


namespace Management
{
    public partial class SalesHistory : Form
    {
        public LogInManagements parentForm;
        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd_Brand;
        public Font drvFont = new Font("Arial", 15, FontStyle.Bold);
        public Font drvFont1 = new Font("Arial", 15);
        public Font drvFont2 = new Font("Arial", 9);
        public Font drvFont3 = new Font("Arial", 12, FontStyle.Bold);
        NumberFormatInfo nfi = new NumberFormatInfo();

        int index1, index2;
        DateTime d;
        int brandBoolNum, nameBoolNum, totalBoolNum;
        string ItmBrand, ItmName;

        public string startDate, endDate;
        double wigPonyTailSales = 0, hairSales = 0, hairCareSales = 0, stylingSalonSuppliesSales = 0, skinCosmeticNailFootSales = 0, generalMerchandiseSales = 0;
        Int64 wigPonyTailSold = 0, hairSold = 0, hairCareSold = 0, stylingSalonSuppliesSold = 0, skinCosmeticNailFootSold = 0, generalMerchandiseSold = 0, pointRedeemedCount = 0;
        Int64 totalSold = 0;
        double pointRedeemed = 0;
        double netSales = 0, tax = 0, grossSales = 0;
        Int64 numOfTrans = 0;
        public DataTable dt = new DataTable();

        string SBPStartDate, SBPEndDate;
        string SBPYear, SBPStartYear, SBPEndYear;
        DateTime hour;
        int days = 0;
        int yearSpan = 0;
        string sHour;
        double SBPNetSales = 0, SBPTax = 0, SBPGrossSales = 0;
        Int64 SBPNumOfTrans = 0;
        double SBPTotalDiscount = 0, SBPAverageNetSales = 0; 
        public DataTable dt2_All = new DataTable();

        string SBRStartDate, SBREndDate;
        string SBRRegisterNum;
        double SBRNetSales = 0, SBRTax = 0, SBRGrossSales = 0;
        Int64 SBRNumOfTrans = 0;
        double SBRTotalDiscount = 0, SBRAverageNetSales = 0;
        public DataTable dt3 = new DataTable();

        int SBBGp1, SBBGp2, SBBGp3;
        public string SBBStartDate, SBBEndDate;
        Int64 SBBTotalSoldQty = 0;
        double SBBTotalSales = 0;
        public DataTable dt4 = new DataTable();

        int SBSGp1, SBSGp2, SBSGp3;
        public string SBSStartDate, SBSEndDate;
        Int64 SBSTotalSoldQty = 0;
        double SBSTotalSales = 0;
        public DataTable dt6 = new DataTable();

        int SBVGp1, SBVGp2, SBVGp3;
        public string SBVStartDate, SBVEndDate;
        Int64 SBVTotalSoldQty = 0;
        double SBVTotalSales = 0;
        public DataTable dt5 = new DataTable();

        SqlConnection newConn;
        
        public SalesHistory()
        {
            InitializeComponent();
        }

        private void SalesHistory_Load(object sender, EventArgs e)
        {
            this.Text = "SALES HISTORY (ACCESSED STORE : " + parentForm.storeName + ")";

            if (parentForm.StoreCode == "B4UHQ")
                btnSBROk.Enabled = false;

            nfi.CurrencySymbol = Application.CurrentCulture.NumberFormat.CurrencySymbol;
            nfi.CurrencyNegativePattern = 1;

            txtStartDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            txtEndDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            txtSBPStartDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            txtSBPEndDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            txtSBRStartDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            txtSBREndDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            txtSBBStartDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            txtSBBEndDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            txtSBSStartDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            txtSBSEndDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            txtSBVStartDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            txtSBVEndDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            cmbStartYear.Text = string.Format("{0:yyyy}", DateTime.Today);
            cmbEndYear.Text = string.Format("{0:yyyy}", DateTime.Today);
            cmbYear.Text = string.Format("{0:yyyy}", DateTime.Today);

            dt.Columns.Add("CATEGORY", typeof(String));
            dt.Columns.Add("SALES", typeof(Double));
            dt.Columns.Add("SOLD QTY", typeof(Int64));
            dt.Columns.Add("AVERAGE", typeof(Double));
            dt.Columns.Add("PERCENTAGE", typeof(Double));

            //lblStoreName.Text = parentForm.storeName.ToUpper();
            //lblSBPStoreName.Text = parentForm.storeName.ToUpper();
            //lblSBRStoreName.Text = parentForm.storeName.ToUpper();
            //lblSBBStoreName.Text = parentForm.storeName.ToUpper();
            //lblSBSStoreName.Text = parentForm.storeName.ToUpper();

            SqlCommand cmd_StoreList = new SqlCommand("Get_Retail_StoreCode", parentForm.conn);
            cmd_StoreList.CommandType = CommandType.StoredProcedure;
            DataSet ds_StoreList = new DataSet();
            SqlDataAdapter adapt_StoreList = new SqlDataAdapter(cmd_StoreList);

            parentForm.conn.Open();
            ds_StoreList.Clear();
            adapt_StoreList.Fill(ds_StoreList);
            parentForm.conn.Close();

            cmbSBBStoreCode.DataSource = ds_StoreList.Tables[0].DefaultView;
            cmbSBBStoreCode.ValueMember = "CIStoreCode";
            cmbSBBStoreCode.DisplayMember = "CIStoreCode";
            cmbSBPStoreCode.DataSource = ds_StoreList.Tables[0].DefaultView;
            cmbSBPStoreCode.ValueMember = "CIStoreCode";
            cmbSBBStoreCode.DisplayMember = "CIStoreCode";
            cmbStoreCode.DataSource = ds_StoreList.Tables[0].DefaultView;
            cmbStoreCode.ValueMember = "CIStoreCode";
            cmbStoreCode.DisplayMember = "CIStoreCode";
            cmbSBSStoreCode.DataSource = ds_StoreList.Tables[0].DefaultView;
            cmbSBSStoreCode.ValueMember = "CIStoreCode";
            cmbSBSStoreCode.DisplayMember = "CIStoreCode";
            cmbSBVStoreCode.DataSource = ds_StoreList.Tables[0].DefaultView;
            cmbSBVStoreCode.ValueMember = "CIStoreCode";
            cmbSBVStoreCode.DisplayMember = "CIStoreCode";

            cmbSBPStoreCode.Text = parentForm.StoreCode.ToUpper();
            cmbStoreCode.Text = parentForm.StoreCode.ToUpper();
            cmbSBBStoreCode.Text = parentForm.StoreCode.ToUpper();
            cmbSBSStoreCode.Text = parentForm.StoreCode.ToUpper();
            cmbSBVStoreCode.Text = parentForm.StoreCode.ToUpper();

            if (parentForm.userLevel >= parentForm.btnManagementChangeStore)
            {
                lblSBPStoreCode.Visible = true;
                cmbSBPStoreCode.Visible = true;
                lblStoreCode.Visible = true;
                cmbStoreCode.Visible = true;
                lblSBBStoreCode.Visible = true;
                cmbSBBStoreCode.Visible = true;
                btnSBBExcel.Visible = true;
                lblSBSStoreCode.Visible = true;
                cmbSBSStoreCode.Visible = true;
                btnSBSExcel.Visible = true;
                lblSBVStoreCode.Visible = true;
                cmbSBVStoreCode.Visible = true;
                btnSBVExcel.Visible = true;
            }
            else
            {
                lblSBPStoreCode.Visible = false;
                cmbSBPStoreCode.Visible = false;
                lblStoreCode.Visible = false;
                cmbStoreCode.Visible = false;
                lblSBBStoreCode.Visible = false;
                cmbSBBStoreCode.Visible = false;
                btnSBSExcel.Visible = false;
                lblSBSStoreCode.Visible = false;
                cmbSBSStoreCode.Visible = false;
                btnSBSExcel.Visible = false;
                lblSBVStoreCode.Visible = false;
                cmbSBVStoreCode.Visible = false;
                btnSBVExcel.Visible = false;
            }

            lblRef.ForeColor = Color.LightYellow;
            dataGridView2.ColumnHeadersHeight = 45;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);

            SqlCommand cmd_CmbCategory1 = new SqlCommand("Get_Category_Group1", parentForm.conn);
            cmd_CmbCategory1.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd_CmbCategory1;

            parentForm.conn.Open();
            adapt.Fill(ds);
            parentForm.conn.Close();

            cmbSBBCategory1.DataSource = ds.Tables[0].DefaultView;
            cmbSBBCategory1.ValueMember = "ItmGp_Desc";
            cmbSBBCategory1.DisplayMember = "ItmGp_Desc";

            cmbSBSCategory1.DataSource = ds.Tables[0].DefaultView;
            cmbSBSCategory1.ValueMember = "ItmGp_Desc";
            cmbSBSCategory1.DisplayMember = "ItmGp_Desc";

            cmbSBVCategory1.DataSource = ds.Tables[0].DefaultView;
            cmbSBVCategory1.ValueMember = "ItmGp_Desc";
            cmbSBVCategory1.DisplayMember = "ItmGp_Desc";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (startDate == "")
            {
                MessageBox.Show("SELECT START DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (endDate == "")
            {
                MessageBox.Show("SELECT END DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnOK.Enabled = false;

            if (parentForm.StoreCode == cmbStoreCode.Text.ToUpper().ToString())
            {
                lblStoreName.Text = parentForm.storeName;

                dt.Clear();
                wigPonyTailSales = 0; hairSales = 0; hairCareSales = 0; stylingSalonSuppliesSales = 0; skinCosmeticNailFootSales = 0; generalMerchandiseSales = 0;
                pointRedeemed = 0;
                wigPonyTailSold = 0; hairSold = 0; hairCareSold = 0; stylingSalonSuppliesSold = 0; skinCosmeticNailFootSold = 0; generalMerchandiseSold = 0; pointRedeemedCount = 0;
                totalSold = 0;
                netSales = 0; tax = 0; grossSales = 0;
                numOfTrans = 0;
                //averageNetSales = 0; averageGrossSales = 0;

                startDate = txtStartDate.Text.Trim();
                endDate = txtEndDate.Text.Trim();

                cmd.CommandText = "Report_SalesHistory";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = parentForm.conn;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                SqlParameter WigPonyTailSales_Param = cmd.Parameters.Add("@WigPonyTailSales", SqlDbType.Money);
                SqlParameter HairSales_Param = cmd.Parameters.Add("@HairSales", SqlDbType.Money);
                SqlParameter HairCareSales_Param = cmd.Parameters.Add("@HairCareSales", SqlDbType.Money);
                SqlParameter StylingSalonSuppliesSales_Param = cmd.Parameters.Add("@StylingSalonSuppliesSales", SqlDbType.Money);
                SqlParameter SkinCosmeticNailFootSales_Param = cmd.Parameters.Add("@SkinCosmeticNailFootSales", SqlDbType.Money);
                SqlParameter GeneralMerchandiseSales_Param = cmd.Parameters.Add("@GeneralMerchandiseSales", SqlDbType.Money);
                SqlParameter PointRedeemed_Param = cmd.Parameters.Add("@PointRedeemed", SqlDbType.Money);
                SqlParameter NetSales_Param = cmd.Parameters.Add("@NetSales", SqlDbType.Money);
                SqlParameter Tax_Param = cmd.Parameters.Add("@Tax", SqlDbType.Money);
                SqlParameter GrossSales_Param = cmd.Parameters.Add("@GrossSales", SqlDbType.Money);
                SqlParameter NumOfTrans_Param = cmd.Parameters.Add("@NumOfTrans", SqlDbType.BigInt);
                WigPonyTailSales_Param.Direction = ParameterDirection.Output;
                HairSales_Param.Direction = ParameterDirection.Output;
                HairCareSales_Param.Direction = ParameterDirection.Output;
                StylingSalonSuppliesSales_Param.Direction = ParameterDirection.Output;
                SkinCosmeticNailFootSales_Param.Direction = ParameterDirection.Output;
                GeneralMerchandiseSales_Param.Direction = ParameterDirection.Output;
                PointRedeemed_Param.Direction = ParameterDirection.Output;
                NetSales_Param.Direction = ParameterDirection.Output;
                Tax_Param.Direction = ParameterDirection.Output;
                GrossSales_Param.Direction = ParameterDirection.Output;
                NumOfTrans_Param.Direction = ParameterDirection.Output;

                parentForm.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm.conn.Close();

                if (cmd.Parameters["@WigPonyTailSales"].Value != DBNull.Value)
                    wigPonyTailSales = Convert.ToDouble(cmd.Parameters["@WigPonyTailSales"].Value);

                if (cmd.Parameters["@HairSales"].Value != DBNull.Value)
                    hairSales = Convert.ToDouble(cmd.Parameters["@HairSales"].Value);

                if (cmd.Parameters["@HairCareSales"].Value != DBNull.Value)
                    hairCareSales = Convert.ToDouble(cmd.Parameters["@HairCareSales"].Value);

                if (cmd.Parameters["@StylingSalonSuppliesSales"].Value != DBNull.Value)
                    stylingSalonSuppliesSales = Convert.ToDouble(cmd.Parameters["@StylingSalonSuppliesSales"].Value);

                if (cmd.Parameters["@SkinCosmeticNailFootSales"].Value != DBNull.Value)
                    skinCosmeticNailFootSales = Convert.ToDouble(cmd.Parameters["@SkinCosmeticNailFootSales"].Value);

                if (cmd.Parameters["@GeneralMerchandiseSales"].Value != DBNull.Value)
                    generalMerchandiseSales = Convert.ToDouble(cmd.Parameters["@GeneralMerchandiseSales"].Value);

                if (cmd.Parameters["@PointRedeemed"].Value != DBNull.Value)
                    pointRedeemed = Convert.ToDouble(cmd.Parameters["@PointRedeemed"].Value);

                if (cmd.Parameters["@NetSales"].Value != DBNull.Value)
                    netSales = Convert.ToDouble(cmd.Parameters["@NetSales"].Value);

                if (cmd.Parameters["@Tax"].Value != DBNull.Value)
                    tax = Convert.ToDouble(cmd.Parameters["@Tax"].Value);

                if (cmd.Parameters["@GrossSales"].Value != DBNull.Value)
                    grossSales = Convert.ToDouble(cmd.Parameters["@GrossSales"].Value);

                if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                    numOfTrans = Convert.ToInt64(cmd.Parameters["@NumOfTrans"].Value);

                cmd.CommandText = "Get_Category_Sold";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = parentForm.conn;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                SqlParameter WigPonyTailSold_Param = cmd.Parameters.Add("@WigPonyTailSold", SqlDbType.BigInt);
                SqlParameter HairSold_Param = cmd.Parameters.Add("@HairSold", SqlDbType.BigInt);
                SqlParameter HairCareSold_Param = cmd.Parameters.Add("@HairCareSold", SqlDbType.BigInt);
                SqlParameter StylingSalonSuppliesSold_Param = cmd.Parameters.Add("@StylingSalonSuppliesSold", SqlDbType.BigInt);
                SqlParameter SkinCosmeticNailFootSold_Param = cmd.Parameters.Add("@SkinCosmeticNailFootSold", SqlDbType.BigInt);
                SqlParameter GeneralMerchandiseSold_Param = cmd.Parameters.Add("@GeneralMerchandiseSold", SqlDbType.BigInt);
                SqlParameter PointRedeemedCount_Param = cmd.Parameters.Add("@PointRedeemedCount", SqlDbType.BigInt);
                WigPonyTailSold_Param.Direction = ParameterDirection.Output;
                HairSold_Param.Direction = ParameterDirection.Output;
                HairCareSold_Param.Direction = ParameterDirection.Output;
                StylingSalonSuppliesSold_Param.Direction = ParameterDirection.Output;
                SkinCosmeticNailFootSold_Param.Direction = ParameterDirection.Output;
                GeneralMerchandiseSold_Param.Direction = ParameterDirection.Output;
                PointRedeemedCount_Param.Direction = ParameterDirection.Output;

                parentForm.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm.conn.Close();

                if (cmd.Parameters["@WigPonyTailSold"].Value != DBNull.Value)
                    wigPonyTailSold = Convert.ToInt64(cmd.Parameters["@WigPonyTailSold"].Value);

                if (cmd.Parameters["@HairSold"].Value != DBNull.Value)
                    hairSold = Convert.ToInt64(cmd.Parameters["@HairSold"].Value);

                if (cmd.Parameters["@HairCareSold"].Value != DBNull.Value)
                    hairCareSold = Convert.ToInt64(cmd.Parameters["@HairCareSold"].Value);

                if (cmd.Parameters["@StylingSalonSuppliesSold"].Value != DBNull.Value)
                    stylingSalonSuppliesSold = Convert.ToInt64(cmd.Parameters["@StylingSalonSuppliesSold"].Value);

                if (cmd.Parameters["@SkinCosmeticNailFootSold"].Value != DBNull.Value)
                    skinCosmeticNailFootSold = Convert.ToInt64(cmd.Parameters["@SkinCosmeticNailFootSold"].Value);

                if (cmd.Parameters["@GeneralMerchandiseSold"].Value != DBNull.Value)
                    generalMerchandiseSold = Convert.ToInt64(cmd.Parameters["@GeneralMerchandiseSold"].Value);

                if (cmd.Parameters["@PointRedeemedCount"].Value != DBNull.Value)
                    pointRedeemedCount = Convert.ToInt64(cmd.Parameters["@PointRedeemedCount"].Value);

                dt.Rows.Add("WIG/PONY TAIL", wigPonyTailSales, wigPonyTailSold, wigPonyTailSales / wigPonyTailSold, wigPonyTailSales / netSales);
                //dt.Rows.Add("HAIR", string.Format("{0:$0.00}", hairSales), string.Format("{0:0%}", Math.Round(hairSales / netSales, 2, MidpointRounding.AwayFromZero)));
                //dt.Rows.Add("HAIR CARE", string.Format("{0:$0.00}", hairCareSales),  string.Format("{0:0%}", Math.Round(hairCareSales / netSales, 2, MidpointRounding.AwayFromZero)));
                //dt.Rows.Add("STYLING & SALON SUPPLIES", string.Format("{0:$0.00}", stylingSalonSuppliesSales),  string.Format("{0:0%}", Math.Round(stylingSalonSuppliesSales / netSales, 2, MidpointRounding.AwayFromZero)));
                //dt.Rows.Add("SKIN/COSMETIC/NAIL/FOOT", string.Format("{0:$0.00}", skinCosmeticNailFootSales),  string.Format("{0:0%}", Math.Round(skinCosmeticNailFootSales / netSales, 2, MidpointRounding.AwayFromZero)));
                //dt.Rows.Add("GENERAL MERCHANDISE", string.Format("{0:$0.00}", generalMerchandiseSales), string.Format("{0:0%}", Math.Round(generalMerchandiseSales / netSales, 2, MidpointRounding.AwayFromZero)));
                //dt.Rows.Add("POINT REDEEMED", string.Format("{0:$0.00}", pointRedeemed), string.Format("{0:0%}", Math.Round(pointRedeemed / netSales, 2, MidpointRounding.AwayFromZero)));
                dt.Rows.Add("HAIR", hairSales, hairSold, hairSales / hairSold, hairSales / netSales);
                dt.Rows.Add("HAIR CARE", hairCareSales, hairCareSold, hairCareSales / hairCareSold, hairCareSales / netSales);
                dt.Rows.Add("STYLING & SALON SUPPLIES", stylingSalonSuppliesSales, stylingSalonSuppliesSold, stylingSalonSuppliesSales / stylingSalonSuppliesSold, stylingSalonSuppliesSales / netSales);
                dt.Rows.Add("SKIN/COSMETIC/NAIL/FOOT", skinCosmeticNailFootSales, skinCosmeticNailFootSold, skinCosmeticNailFootSales / skinCosmeticNailFootSold, skinCosmeticNailFootSales / netSales);
                dt.Rows.Add("GENERAL MERCHANDISE", generalMerchandiseSales, generalMerchandiseSold, generalMerchandiseSales / generalMerchandiseSold, generalMerchandiseSales / netSales);
                dt.Rows.Add("POINTS/GIFTCARD REDEEMED", pointRedeemed, pointRedeemedCount, pointRedeemed / pointRedeemedCount, pointRedeemed / netSales);

                if (numOfTrans == 0)
                {
                    lblNetSales.Text = string.Format("{0:$0.00}", netSales);
                    lblTax.Text = string.Format("{0:$0.00}", tax);
                    lblGrossSales.Text = string.Format("{0:$0.00}", grossSales);
                    lblAverageSales.Text = "0";
                    lblTransactions.Text = Convert.ToString(numOfTrans);
                    lblAverageGrossSales.Text = "0";
                }
                else
                {
                    lblNetSales.Text = string.Format("{0:$0.00}", netSales);
                    lblTax.Text = string.Format("{0:$0.00}", tax);
                    lblGrossSales.Text = string.Format("{0:$0.00}", grossSales);
                    lblAverageSales.Text = string.Format("{0:$0.00}", Math.Round(netSales / numOfTrans, 2, MidpointRounding.AwayFromZero));
                    lblTransactions.Text = Convert.ToString(numOfTrans);
                    lblAverageGrossSales.Text = string.Format("{0:$0.00}", Math.Round(grossSales / numOfTrans, 2, MidpointRounding.AwayFromZero));
                }

                dataGridView1.RowTemplate.Height = 55;
                dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                dataGridView1.DataSource = dt;

                dataGridView1.Columns[0].Width = 320;
                dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridView1.Columns[1].Width = 180;
                dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[1].DefaultCellStyle.FormatProvider = nfi;
                dataGridView1.Columns[1].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridView1.Columns[3].Width = 105;
                dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[3].DefaultCellStyle.FormatProvider = nfi;
                dataGridView1.Columns[3].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridView1.Columns[4].Width = 120;
                dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[4].DefaultCellStyle.Format = "P";
                dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

                //lblTitleStoreName.Visible = true;
                //lblStoreName.Visible = true;
                //lblStoreName.Text = parentForm.storeName.ToUpper();

                totalSold = wigPonyTailSold + hairSold + hairCareSold + stylingSalonSuppliesSold + skinCosmeticNailFootSold + generalMerchandiseSold;

                dt.Rows.Add("TOTAL SALES", netSales, totalSold, netSales / totalSold, netSales / netSales);
                dt.Rows.Add("TAX", tax, totalSold, tax / totalSold);
                dt.Rows.Add("TOTAL GROSS SALES", grossSales, totalSold, grossSales / totalSold);
                dataGridView1.DataSource = dt;
                dataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.Tan;
                dataGridView1.Rows[1].DefaultCellStyle.BackColor = Color.Tan;
                dataGridView1.Rows[2].DefaultCellStyle.BackColor = Color.Tan;
                dataGridView1.Rows[3].DefaultCellStyle.BackColor = Color.Tan;
                dataGridView1.Rows[4].DefaultCellStyle.BackColor = Color.Tan;
                dataGridView1.Rows[5].DefaultCellStyle.BackColor = Color.Tan;
                dataGridView1.Rows[6].DefaultCellStyle.BackColor = Color.Orange;
                dataGridView1.Rows[7].DefaultCellStyle.BackColor = Color.GreenYellow;
                dataGridView1.Rows[8].DefaultCellStyle.BackColor = Color.Peru;
                dataGridView1.Rows[9].DefaultCellStyle.BackColor = Color.Peru;

                if (dataGridView1.RowCount > 0)
                    dataGridView1.Rows[0].Selected = false;

                btnOK.Enabled = true;
            }
            else
            {
                /*if (parentForm.UserChecking(cmbStoreCode.Text.Trim().ToUpper()) < 6)
                {
                    MessageBox.Show("You are not authorized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.DataSource = DBNull.Value;
                    btnOK.Enabled = true;
                    return;
                }*/

                if (cmbStoreCode.Text == "OH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.OHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.OHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblStoreName.Text = "OXON HILL";
                }
                else if (cmbStoreCode.Text == "CH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblStoreName.Text = "CAPITOL HEIGHTS";
                }
                else if (cmbStoreCode.Text == "WB")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WBIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WBDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblStoreName.Text = "WOODBRIDGE";
                }
                else if (cmbStoreCode.Text == "CV")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CVIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CVDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblStoreName.Text = "CATONSVILLE";
                }
                else if (cmbStoreCode.Text == "UM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.UMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.UMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblStoreName.Text = "UPPER MARLBORO";
                }
                else if (cmbStoreCode.Text == "WM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblStoreName.Text = "WINDSOR MILL";
                }
                else if (cmbStoreCode.Text == "TH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.THIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.THDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblStoreName.Text = "TEMPLE HILLS";
                }
                else if (cmbStoreCode.Text == "WD")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WDIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WDDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblStoreName.Text = "WALDORF";
                }
                else if (cmbStoreCode.Text == "PW")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.PWIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.PWDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblStoreName.Text = "PRINCE WILLIAM";
                }
                else if (cmbStoreCode.Text == "GB")
                {
                    newConn = new SqlConnection(parentForm.GBCS_IP);
                    lblStoreName.Text = "GAITHERSBURG";
                }
                else if (cmbStoreCode.Text == "BW")
                {
                    newConn = new SqlConnection(parentForm.BWCS_IP);
                    lblStoreName.Text = "BOWIE";
                }

                dt.Clear();
                wigPonyTailSales = 0; hairSales = 0; hairCareSales = 0; stylingSalonSuppliesSales = 0; skinCosmeticNailFootSales = 0; generalMerchandiseSales = 0;
                pointRedeemed = 0;
                wigPonyTailSold = 0; hairSold = 0; hairCareSold = 0; stylingSalonSuppliesSold = 0; skinCosmeticNailFootSold = 0; generalMerchandiseSold = 0; pointRedeemedCount = 0;
                totalSold = 0;
                netSales = 0; tax = 0; grossSales = 0;
                numOfTrans = 0;
                //averageNetSales = 0; averageGrossSales = 0;

                startDate = txtStartDate.Text.Trim();
                endDate = txtEndDate.Text.Trim();

                cmd.CommandText = "Report_SalesHistory";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = newConn;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                SqlParameter WigPonyTailSales_Param = cmd.Parameters.Add("@WigPonyTailSales", SqlDbType.Money);
                SqlParameter HairSales_Param = cmd.Parameters.Add("@HairSales", SqlDbType.Money);
                SqlParameter HairCareSales_Param = cmd.Parameters.Add("@HairCareSales", SqlDbType.Money);
                SqlParameter StylingSalonSuppliesSales_Param = cmd.Parameters.Add("@StylingSalonSuppliesSales", SqlDbType.Money);
                SqlParameter SkinCosmeticNailFootSales_Param = cmd.Parameters.Add("@SkinCosmeticNailFootSales", SqlDbType.Money);
                SqlParameter GeneralMerchandiseSales_Param = cmd.Parameters.Add("@GeneralMerchandiseSales", SqlDbType.Money);
                SqlParameter PointRedeemed_Param = cmd.Parameters.Add("@PointRedeemed", SqlDbType.Money);
                SqlParameter NetSales_Param = cmd.Parameters.Add("@NetSales", SqlDbType.Money);
                SqlParameter Tax_Param = cmd.Parameters.Add("@Tax", SqlDbType.Money);
                SqlParameter GrossSales_Param = cmd.Parameters.Add("@GrossSales", SqlDbType.Money);
                SqlParameter NumOfTrans_Param = cmd.Parameters.Add("@NumOfTrans", SqlDbType.BigInt);
                WigPonyTailSales_Param.Direction = ParameterDirection.Output;
                HairSales_Param.Direction = ParameterDirection.Output;
                HairCareSales_Param.Direction = ParameterDirection.Output;
                StylingSalonSuppliesSales_Param.Direction = ParameterDirection.Output;
                SkinCosmeticNailFootSales_Param.Direction = ParameterDirection.Output;
                GeneralMerchandiseSales_Param.Direction = ParameterDirection.Output;
                PointRedeemed_Param.Direction = ParameterDirection.Output;
                NetSales_Param.Direction = ParameterDirection.Output;
                Tax_Param.Direction = ParameterDirection.Output;
                GrossSales_Param.Direction = ParameterDirection.Output;
                NumOfTrans_Param.Direction = ParameterDirection.Output;

                newConn.Open();
                cmd.ExecuteNonQuery();
                newConn.Close();

                if (cmd.Parameters["@WigPonyTailSales"].Value != DBNull.Value)
                    wigPonyTailSales = Convert.ToDouble(cmd.Parameters["@WigPonyTailSales"].Value);

                if (cmd.Parameters["@HairSales"].Value != DBNull.Value)
                    hairSales = Convert.ToDouble(cmd.Parameters["@HairSales"].Value);

                if (cmd.Parameters["@HairCareSales"].Value != DBNull.Value)
                    hairCareSales = Convert.ToDouble(cmd.Parameters["@HairCareSales"].Value);

                if (cmd.Parameters["@StylingSalonSuppliesSales"].Value != DBNull.Value)
                    stylingSalonSuppliesSales = Convert.ToDouble(cmd.Parameters["@StylingSalonSuppliesSales"].Value);

                if (cmd.Parameters["@SkinCosmeticNailFootSales"].Value != DBNull.Value)
                    skinCosmeticNailFootSales = Convert.ToDouble(cmd.Parameters["@SkinCosmeticNailFootSales"].Value);

                if (cmd.Parameters["@GeneralMerchandiseSales"].Value != DBNull.Value)
                    generalMerchandiseSales = Convert.ToDouble(cmd.Parameters["@GeneralMerchandiseSales"].Value);

                if (cmd.Parameters["@PointRedeemed"].Value != DBNull.Value)
                    pointRedeemed = Convert.ToDouble(cmd.Parameters["@PointRedeemed"].Value);

                if (cmd.Parameters["@NetSales"].Value != DBNull.Value)
                    netSales = Convert.ToDouble(cmd.Parameters["@NetSales"].Value);

                if (cmd.Parameters["@Tax"].Value != DBNull.Value)
                    tax = Convert.ToDouble(cmd.Parameters["@Tax"].Value);

                if (cmd.Parameters["@GrossSales"].Value != DBNull.Value)
                    grossSales = Convert.ToDouble(cmd.Parameters["@GrossSales"].Value);

                if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                    numOfTrans = Convert.ToInt64(cmd.Parameters["@NumOfTrans"].Value);

                cmd.CommandText = "Get_Category_Sold";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = newConn;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                SqlParameter WigPonyTailSold_Param = cmd.Parameters.Add("@WigPonyTailSold", SqlDbType.BigInt);
                SqlParameter HairSold_Param = cmd.Parameters.Add("@HairSold", SqlDbType.BigInt);
                SqlParameter HairCareSold_Param = cmd.Parameters.Add("@HairCareSold", SqlDbType.BigInt);
                SqlParameter StylingSalonSuppliesSold_Param = cmd.Parameters.Add("@StylingSalonSuppliesSold", SqlDbType.BigInt);
                SqlParameter SkinCosmeticNailFootSold_Param = cmd.Parameters.Add("@SkinCosmeticNailFootSold", SqlDbType.BigInt);
                SqlParameter GeneralMerchandiseSold_Param = cmd.Parameters.Add("@GeneralMerchandiseSold", SqlDbType.BigInt);
                SqlParameter PointRedeemedCount_Param = cmd.Parameters.Add("@PointRedeemedCount", SqlDbType.BigInt);
                WigPonyTailSold_Param.Direction = ParameterDirection.Output;
                HairSold_Param.Direction = ParameterDirection.Output;
                HairCareSold_Param.Direction = ParameterDirection.Output;
                StylingSalonSuppliesSold_Param.Direction = ParameterDirection.Output;
                SkinCosmeticNailFootSold_Param.Direction = ParameterDirection.Output;
                GeneralMerchandiseSold_Param.Direction = ParameterDirection.Output;
                PointRedeemedCount_Param.Direction = ParameterDirection.Output;

                newConn.Open();
                cmd.ExecuteNonQuery();
                newConn.Close();

                if (cmd.Parameters["@WigPonyTailSold"].Value != DBNull.Value)
                    wigPonyTailSold = Convert.ToInt64(cmd.Parameters["@WigPonyTailSold"].Value);

                if (cmd.Parameters["@HairSold"].Value != DBNull.Value)
                    hairSold = Convert.ToInt64(cmd.Parameters["@HairSold"].Value);

                if (cmd.Parameters["@HairCareSold"].Value != DBNull.Value)
                    hairCareSold = Convert.ToInt64(cmd.Parameters["@HairCareSold"].Value);

                if (cmd.Parameters["@StylingSalonSuppliesSold"].Value != DBNull.Value)
                    stylingSalonSuppliesSold = Convert.ToInt64(cmd.Parameters["@StylingSalonSuppliesSold"].Value);

                if (cmd.Parameters["@SkinCosmeticNailFootSold"].Value != DBNull.Value)
                    skinCosmeticNailFootSold = Convert.ToInt64(cmd.Parameters["@SkinCosmeticNailFootSold"].Value);

                if (cmd.Parameters["@GeneralMerchandiseSold"].Value != DBNull.Value)
                    generalMerchandiseSold = Convert.ToInt64(cmd.Parameters["@GeneralMerchandiseSold"].Value);

                if (cmd.Parameters["@PointRedeemedCount"].Value != DBNull.Value)
                    pointRedeemedCount = Convert.ToInt64(cmd.Parameters["@PointRedeemedCount"].Value);

                dt.Rows.Add("WIG/PONY TAIL", wigPonyTailSales, wigPonyTailSold, wigPonyTailSales / wigPonyTailSold, wigPonyTailSales / netSales);
                //dt.Rows.Add("HAIR", string.Format("{0:$0.00}", hairSales), string.Format("{0:0%}", Math.Round(hairSales / netSales, 2, MidpointRounding.AwayFromZero)));
                //dt.Rows.Add("HAIR CARE", string.Format("{0:$0.00}", hairCareSales),  string.Format("{0:0%}", Math.Round(hairCareSales / netSales, 2, MidpointRounding.AwayFromZero)));
                //dt.Rows.Add("STYLING & SALON SUPPLIES", string.Format("{0:$0.00}", stylingSalonSuppliesSales),  string.Format("{0:0%}", Math.Round(stylingSalonSuppliesSales / netSales, 2, MidpointRounding.AwayFromZero)));
                //dt.Rows.Add("SKIN/COSMETIC/NAIL/FOOT", string.Format("{0:$0.00}", skinCosmeticNailFootSales),  string.Format("{0:0%}", Math.Round(skinCosmeticNailFootSales / netSales, 2, MidpointRounding.AwayFromZero)));
                //dt.Rows.Add("GENERAL MERCHANDISE", string.Format("{0:$0.00}", generalMerchandiseSales), string.Format("{0:0%}", Math.Round(generalMerchandiseSales / netSales, 2, MidpointRounding.AwayFromZero)));
                //dt.Rows.Add("POINT REDEEMED", string.Format("{0:$0.00}", pointRedeemed), string.Format("{0:0%}", Math.Round(pointRedeemed / netSales, 2, MidpointRounding.AwayFromZero)));
                dt.Rows.Add("HAIR", hairSales, hairSold, hairSales / hairSold, hairSales / netSales);
                dt.Rows.Add("HAIR CARE", hairCareSales, hairCareSold, hairCareSales / hairCareSold, hairCareSales / netSales);
                dt.Rows.Add("STYLING & SALON SUPPLIES", stylingSalonSuppliesSales, stylingSalonSuppliesSold, stylingSalonSuppliesSales / stylingSalonSuppliesSold, stylingSalonSuppliesSales / netSales);
                dt.Rows.Add("SKIN/COSMETIC/NAIL/FOOT", skinCosmeticNailFootSales, skinCosmeticNailFootSold, skinCosmeticNailFootSales / skinCosmeticNailFootSold, skinCosmeticNailFootSales / netSales);
                dt.Rows.Add("GENERAL MERCHANDISE", generalMerchandiseSales, generalMerchandiseSold, generalMerchandiseSales / generalMerchandiseSold, generalMerchandiseSales / netSales);
                dt.Rows.Add("POINTS REDEEMED", pointRedeemed, pointRedeemedCount, pointRedeemed / pointRedeemedCount, pointRedeemed / netSales);

                if (numOfTrans == 0)
                {
                    lblNetSales.Text = string.Format("{0:$0.00}", netSales);
                    lblTax.Text = string.Format("{0:$0.00}", tax);
                    lblGrossSales.Text = string.Format("{0:$0.00}", grossSales);
                    lblAverageSales.Text = "0";
                    lblTransactions.Text = Convert.ToString(numOfTrans);
                    lblAverageGrossSales.Text = "0";
                }
                else
                {
                    lblNetSales.Text = string.Format("{0:$0.00}", netSales);
                    lblTax.Text = string.Format("{0:$0.00}", tax);
                    lblGrossSales.Text = string.Format("{0:$0.00}", grossSales);
                    lblAverageSales.Text = string.Format("{0:$0.00}", Math.Round(netSales / numOfTrans, 2, MidpointRounding.AwayFromZero));
                    lblTransactions.Text = Convert.ToString(numOfTrans);
                    lblAverageGrossSales.Text = string.Format("{0:$0.00}", Math.Round(grossSales / numOfTrans, 2, MidpointRounding.AwayFromZero));
                }

                dataGridView1.RowTemplate.Height = 55;
                dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                dataGridView1.DataSource = dt;

                dataGridView1.Columns[0].Width = 320;
                dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridView1.Columns[1].Width = 180;
                dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[1].DefaultCellStyle.FormatProvider = nfi;
                dataGridView1.Columns[1].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridView1.Columns[3].Width = 105;
                dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[3].DefaultCellStyle.FormatProvider = nfi;
                dataGridView1.Columns[3].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridView1.Columns[4].Width = 120;
                dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[4].DefaultCellStyle.Format = "P";
                dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

                //lblTitleStoreName.Visible = true;
                //lblStoreName.Visible = true;
                //lblStoreName.Text = parentForm.storeName.ToUpper();

                totalSold = wigPonyTailSold + hairSold + hairCareSold + stylingSalonSuppliesSold + skinCosmeticNailFootSold + generalMerchandiseSold;

                dt.Rows.Add("TOTAL SALES", netSales, totalSold, netSales / totalSold, netSales / netSales);
                dt.Rows.Add("TAX", tax, totalSold, tax / totalSold);
                dt.Rows.Add("TOTAL GROSS SALES", grossSales, totalSold, grossSales / totalSold);
                dataGridView1.DataSource = dt;
                dataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.Tan;
                dataGridView1.Rows[1].DefaultCellStyle.BackColor = Color.Tan;
                dataGridView1.Rows[2].DefaultCellStyle.BackColor = Color.Tan;
                dataGridView1.Rows[3].DefaultCellStyle.BackColor = Color.Tan;
                dataGridView1.Rows[4].DefaultCellStyle.BackColor = Color.Tan;
                dataGridView1.Rows[5].DefaultCellStyle.BackColor = Color.Tan;
                dataGridView1.Rows[6].DefaultCellStyle.BackColor = Color.Orange;
                dataGridView1.Rows[7].DefaultCellStyle.BackColor = Color.GreenYellow;
                dataGridView1.Rows[8].DefaultCellStyle.BackColor = Color.Peru;
                dataGridView1.Rows[9].DefaultCellStyle.BackColor = Color.Peru;

                if (dataGridView1.RowCount > 0)
                    dataGridView1.Rows[0].Selected = false;

                btnOK.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtStartDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void txtEndDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar2.Visible = true;
        }

        private void txtSBPStartDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar3.Visible = true;
        }

        private void txtSBPEndDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar4.Visible = true;
        }

        private void btnSBPOk_Click(object sender, EventArgs e)
        {
            try
            {
                btnSBPOk.Enabled = false;

                if (parentForm.StoreCode == cmbSBPStoreCode.Text.ToUpper().ToString())
                {
                    lblSBPStoreName.Text = parentForm.storeName;

                    if (rdoBtnHouly.Checked == true)
                    {
                        SBPStartDate = txtSBPStartDate.Text;

                        if (SBPStartDate == "")
                        {
                            MessageBox.Show("SELECT DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnSBPOk.Enabled = true;
                            return;
                        }
                        else
                        {
                            if (Convert.ToDateTime(SBPStartDate).DayOfWeek != DayOfWeek.Sunday)
                            {
                                dt2_All.Clear();
                                SBPNetSales = 0; SBPTax = 0; SBPGrossSales = 0;
                                SBPNumOfTrans = 0;
                                SBPTotalDiscount = 0; SBPAverageNetSales = 0;
                                hour = Convert.ToDateTime("9:00:00");

                                for (int i = 9; i <= 21; i++)
                                {
                                    sHour = hour.ToString("T");

                                    cmd.CommandText = "Sales_History_Hourly_New";
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Connection = parentForm.conn;
                                    cmd.Parameters.Clear();
                                    cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = SBPStartDate;
                                    cmd.Parameters.Add("@StartHour", SqlDbType.NVarChar).Value = sHour;

                                    hour = hour.AddHours(1);
                                    sHour = hour.ToString("T");

                                    cmd.Parameters.Add("@EndHour", SqlDbType.NVarChar).Value = sHour;
                                    cmd.Parameters.Add("@DisplayHour", SqlDbType.NVarChar).Value = Convert.ToString(i);

                                    SqlDataAdapter adapter = new SqlDataAdapter();
                                    adapter.SelectCommand = cmd;

                                    parentForm.conn.Open();
                                    adapter.Fill(dt2_All);
                                    parentForm.conn.Close();
                                }

                                dataGridView2.RowTemplate.Height = 37;
                                dataGridView2.RowTemplate.DefaultCellStyle.Font = drvFont1;
                                dataGridView2.DataSource = dt2_All;
                                dataGridView2.Columns[0].HeaderText = "HOUR";
                                //dataGridView2.Columns[0].Width = 100;
                                dataGridView2.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                dataGridView2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                dataGridView2.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                                dataGridView2.Columns[1].HeaderText = "SALES";
                                //dataGridView2.Columns[1].Width = 150;
                                dataGridView2.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[1].DefaultCellStyle.Format = "c";
                                dataGridView2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                                dataGridView2.Columns[2].HeaderText = "TRNs";
                                //dataGridView2.Columns[2].Width = 70;
                                dataGridView2.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                                dataGridView2.Columns[3].HeaderText = "AVERAGE";
                                //dataGridView2.Columns[3].Width = 100;
                                dataGridView2.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[3].DefaultCellStyle.Format = "c";
                                dataGridView2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                                dataGridView2.Columns[4].HeaderText = "TAX";
                                //dataGridView2.Columns[4].Width = 130;
                                dataGridView2.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[4].DefaultCellStyle.Format = "c";
                                dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                                dataGridView2.Columns[5].HeaderText = "GROSS SALES";
                                //dataGridView2.Columns[5].Width = 150;
                                dataGridView2.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[5].DefaultCellStyle.Format = "c";
                                dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
                                dataGridView2.Columns[6].HeaderText = "DISCOUNTS";
                                //dataGridView2.Columns[6].Width = 130;
                                dataGridView2.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[6].DefaultCellStyle.Format = "c";
                                dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

                                dataGridView2.Columns[1].DefaultCellStyle.FormatProvider = nfi;
                                dataGridView2.Columns[3].DefaultCellStyle.FormatProvider = nfi;
                                dataGridView2.Columns[4].DefaultCellStyle.FormatProvider = nfi;
                                dataGridView2.Columns[5].DefaultCellStyle.FormatProvider = nfi;
                                dataGridView2.Columns[6].DefaultCellStyle.FormatProvider = nfi;

                                for (int i = 0; i < dataGridView2.RowCount; i++)
                                {
                                    if (dataGridView2.Rows[i].Cells[1].Value != DBNull.Value)
                                        SBPNetSales = SBPNetSales + Convert.ToDouble(dataGridView2.Rows[i].Cells[1].Value);

                                    if (dataGridView2.Rows[i].Cells[2].Value != DBNull.Value)
                                        SBPNumOfTrans = SBPNumOfTrans + Convert.ToInt64(dataGridView2.Rows[i].Cells[2].Value);

                                    if (dataGridView2.Rows[i].Cells[4].Value != DBNull.Value)
                                        SBPTax = SBPTax + Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value);

                                    if (dataGridView2.Rows[i].Cells[5].Value != DBNull.Value)
                                        SBPGrossSales = SBPGrossSales + Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value);

                                    if (dataGridView2.Rows[i].Cells[6].Value != DBNull.Value)
                                        SBPTotalDiscount = SBPTotalDiscount + Convert.ToDouble(dataGridView2.Rows[i].Cells[6].Value);
                                }

                                if (SBPNumOfTrans == 0)
                                {
                                    SBPAverageNetSales = 0;
                                }
                                else
                                {
                                    SBPAverageNetSales = SBPNetSales / SBPNumOfTrans;
                                }

                                lblSBPTitleStoreName.Visible = true;
                                lblSBPStoreName.Visible = true;
                                lblSBPStoreName.Text = parentForm.storeName.ToUpper();

                                dt2_All.Rows.Add("TOTAL", SBPNetSales, SBPNumOfTrans, SBPAverageNetSales, SBPTax, SBPGrossSales, SBPTotalDiscount);
                                dataGridView2.DataSource = dt2_All;
                                dataGridView2.Rows[dataGridView2.RowCount - 1].DefaultCellStyle.BackColor = Color.BurlyWood;

                                if (dataGridView2.RowCount > 0)
                                    dataGridView2.Rows[0].Selected = false;
                            }
                            else
                            {
                                dt2_All.Clear();
                                SBPNetSales = 0; SBPTax = 0; SBPGrossSales = 0;
                                SBPNumOfTrans = 0;
                                SBPTotalDiscount = 0; SBPAverageNetSales = 0;
                                hour = Convert.ToDateTime("10:00:00");

                                for (int i = 10; i <= 18; i++)
                                {
                                    sHour = hour.ToString("T");

                                    cmd.CommandText = "Sales_History_Hourly_New";
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Connection = parentForm.conn;
                                    cmd.Parameters.Clear();
                                    cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = SBPStartDate;
                                    cmd.Parameters.Add("@StartHour", SqlDbType.NVarChar).Value = sHour;

                                    hour = hour.AddHours(1);
                                    sHour = hour.ToString("T");

                                    cmd.Parameters.Add("@EndHour", SqlDbType.NVarChar).Value = sHour;
                                    cmd.Parameters.Add("@DisplayHour", SqlDbType.NVarChar).Value = Convert.ToString(i);

                                    SqlDataAdapter adapter = new SqlDataAdapter();
                                    adapter.SelectCommand = cmd;

                                    parentForm.conn.Open();
                                    adapter.Fill(dt2_All);
                                    parentForm.conn.Close();
                                }

                                dataGridView2.RowTemplate.Height = 37;
                                dataGridView2.RowTemplate.DefaultCellStyle.Font = drvFont1;
                                dataGridView2.DataSource = dt2_All;
                                dataGridView2.Columns[0].HeaderText = "HOUR";
                                //dataGridView2.Columns[0].Width = 100;
                                dataGridView2.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                dataGridView2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                dataGridView2.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                                dataGridView2.Columns[1].HeaderText = "SALES";
                                //dataGridView2.Columns[1].Width = 150;
                                dataGridView2.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[1].DefaultCellStyle.Format = "c";
                                dataGridView2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                                dataGridView2.Columns[2].HeaderText = "TRNs";
                                //dataGridView2.Columns[2].Width = 70;
                                dataGridView2.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                                dataGridView2.Columns[3].HeaderText = "AVERAGE";
                                //dataGridView2.Columns[3].Width = 100;
                                dataGridView2.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[3].DefaultCellStyle.Format = "c";
                                dataGridView2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                                dataGridView2.Columns[4].HeaderText = "TAX";
                                //dataGridView2.Columns[4].Width = 130;
                                dataGridView2.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[4].DefaultCellStyle.Format = "c";
                                dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                                dataGridView2.Columns[5].HeaderText = "GROSS SALES";
                                //dataGridView2.Columns[5].Width = 150;
                                dataGridView2.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[5].DefaultCellStyle.Format = "c";
                                dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
                                dataGridView2.Columns[6].HeaderText = "DISCOUNTS";
                                //dataGridView2.Columns[6].Width = 130;
                                dataGridView2.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[6].DefaultCellStyle.Format = "c";
                                dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

                                dataGridView2.Columns[1].DefaultCellStyle.FormatProvider = nfi;
                                dataGridView2.Columns[3].DefaultCellStyle.FormatProvider = nfi;
                                dataGridView2.Columns[4].DefaultCellStyle.FormatProvider = nfi;
                                dataGridView2.Columns[5].DefaultCellStyle.FormatProvider = nfi;
                                dataGridView2.Columns[6].DefaultCellStyle.FormatProvider = nfi;

                                for (int i = 0; i < dataGridView2.RowCount; i++)
                                {
                                    if (dataGridView2.Rows[i].Cells[1].Value != DBNull.Value)
                                        SBPNetSales = SBPNetSales + Convert.ToDouble(dataGridView2.Rows[i].Cells[1].Value);

                                    if (dataGridView2.Rows[i].Cells[2].Value != DBNull.Value)
                                        SBPNumOfTrans = SBPNumOfTrans + Convert.ToInt64(dataGridView2.Rows[i].Cells[2].Value);

                                    if (dataGridView2.Rows[i].Cells[4].Value != DBNull.Value)
                                        SBPTax = SBPTax + Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value);

                                    if (dataGridView2.Rows[i].Cells[5].Value != DBNull.Value)
                                        SBPGrossSales = SBPGrossSales + Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value);

                                    if (dataGridView2.Rows[i].Cells[6].Value != DBNull.Value)
                                        SBPTotalDiscount = SBPTotalDiscount + Convert.ToDouble(dataGridView2.Rows[i].Cells[6].Value);
                                }

                                if (SBPNumOfTrans == 0)
                                {
                                    SBPAverageNetSales = 0;
                                }
                                else
                                {
                                    SBPAverageNetSales = SBPNetSales / SBPNumOfTrans;
                                }

                                lblSBPTitleStoreName.Visible = true;
                                lblSBPStoreName.Visible = true;
                                lblSBPStoreName.Text = parentForm.storeName.ToUpper();

                                dt2_All.Rows.Add("TOTAL", SBPNetSales, SBPNumOfTrans, SBPAverageNetSales, SBPTax, SBPGrossSales, SBPTotalDiscount);
                                dataGridView2.DataSource = dt2_All;
                                dataGridView2.Rows[dataGridView2.RowCount - 1].DefaultCellStyle.BackColor = Color.BurlyWood;

                                if (dataGridView2.RowCount > 0)
                                    dataGridView2.Rows[0].Selected = false;
                            }
                        }
                    }
                    else if (rdoBtnDaily.Checked == true)
                    {
                        SBPStartDate = txtSBPStartDate.Text;
                        SBPEndDate = txtSBPEndDate.Text;

                        if (SBPStartDate == "")
                        {
                            MessageBox.Show("SELECT START DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnSBPOk.Enabled = true;
                            return;
                        }

                        if (SBPEndDate == "")
                        {
                            MessageBox.Show("SELECT END DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnSBPOk.Enabled = true;
                            return;
                        }

                        dt2_All.Clear();
                        SBPNetSales = 0; SBPTax = 0; SBPGrossSales = 0;
                        SBPNumOfTrans = 0;
                        SBPTotalDiscount = 0; SBPAverageNetSales = 0;

                        TimeSpan t = Convert.ToDateTime(SBPEndDate).Subtract(Convert.ToDateTime(SBPStartDate));
                        days = t.Days;

                        if (SBPStartDate == SBPEndDate)
                        {
                            cmd.CommandText = "Sales_History_Daily_New";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = parentForm.conn;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = SBPStartDate;

                            SqlDataAdapter adapter = new SqlDataAdapter();
                            adapter.SelectCommand = cmd;

                            parentForm.conn.Open();
                            adapter.Fill(dt2_All);
                            parentForm.conn.Close();

                            dataGridView2.RowTemplate.Height = 18;
                            dataGridView2.RowTemplate.DefaultCellStyle.Font = drvFont2;
                            dataGridView2.DataSource = dt2_All;
                            dataGridView2.Columns[0].HeaderText = "DATE";
                            //dataGridView2.Columns[0].Width = 115;
                            dataGridView2.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            dataGridView2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            dataGridView2.Columns[0].DefaultCellStyle.Format = "MM/dd/yyyy";
                            dataGridView2.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dataGridView2.Columns[1].HeaderText = "SALES";
                            //dataGridView2.Columns[1].Width = 150;
                            dataGridView2.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[1].DefaultCellStyle.Format = "c";
                            dataGridView2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dataGridView2.Columns[2].HeaderText = "TRNs";
                            //dataGridView2.Columns[2].Width = 75;
                            dataGridView2.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dataGridView2.Columns[3].HeaderText = "AVERAGE";
                            //dataGridView2.Columns[3].Width = 90;
                            dataGridView2.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[3].DefaultCellStyle.Format = "c";
                            dataGridView2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dataGridView2.Columns[4].HeaderText = "TAX";
                            //dataGridView2.Columns[4].Width = 120;
                            dataGridView2.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[4].DefaultCellStyle.Format = "c";
                            dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dataGridView2.Columns[5].HeaderText = "GROSS SALES";
                            //dataGridView2.Columns[5].Width = 150;
                            dataGridView2.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[5].DefaultCellStyle.Format = "c";
                            dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dataGridView2.Columns[6].HeaderText = "DISCOUNTS";
                            //dataGridView2.Columns[6].Width = 130;
                            dataGridView2.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[6].DefaultCellStyle.Format = "c";
                            dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

                            dataGridView2.Columns[1].DefaultCellStyle.FormatProvider = nfi;
                            dataGridView2.Columns[3].DefaultCellStyle.FormatProvider = nfi;
                            dataGridView2.Columns[4].DefaultCellStyle.FormatProvider = nfi;
                            dataGridView2.Columns[5].DefaultCellStyle.FormatProvider = nfi;
                            dataGridView2.Columns[6].DefaultCellStyle.FormatProvider = nfi;

                            for (int i = 0; i < dataGridView2.RowCount; i++)
                            {
                                if (Convert.ToDateTime(dataGridView2.Rows[i].Cells[0].Value).DayOfWeek == DayOfWeek.Sunday)
                                    dataGridView2.Rows[i].Cells[0].Style.ForeColor = Color.Red;

                                if (dataGridView2.Rows[i].Cells[5].Value != DBNull.Value)
                                    SBPGrossSales = SBPGrossSales + Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value);

                                if (dataGridView2.Rows[i].Cells[2].Value != DBNull.Value)
                                    SBPNumOfTrans = SBPNumOfTrans + Convert.ToInt64(dataGridView2.Rows[i].Cells[2].Value);

                                if (dataGridView2.Rows[i].Cells[4].Value != DBNull.Value)
                                    SBPTax = SBPTax + Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value);

                                if (dataGridView2.Rows[i].Cells[1].Value != DBNull.Value)
                                    SBPNetSales = SBPNetSales + Convert.ToDouble(dataGridView2.Rows[i].Cells[1].Value);

                                if (dataGridView2.Rows[i].Cells[6].Value != DBNull.Value)
                                    SBPTotalDiscount = SBPTotalDiscount + Convert.ToDouble(dataGridView2.Rows[i].Cells[6].Value);
                            }

                            if (SBPNumOfTrans == 0)
                            {
                                SBPAverageNetSales = 0;
                            }
                            else
                            {
                                SBPAverageNetSales = SBPNetSales / SBPNumOfTrans;
                            }

                            lblSBPTitleStoreName.Visible = true;
                            lblSBPStoreName.Visible = true;
                            lblSBPStoreName.Text = parentForm.storeName.ToUpper();

                            dt2_All.Rows.Add("TOTAL", SBPNetSales, SBPNumOfTrans, SBPAverageNetSales, SBPTax, SBPGrossSales, SBPTotalDiscount);
                            dataGridView2.DataSource = dt2_All;
                            dataGridView2.Rows[dataGridView2.RowCount - 1].DefaultCellStyle.BackColor = Color.BurlyWood;

                            if (dataGridView2.RowCount > 0)
                                dataGridView2.Rows[0].Selected = false;
                        }
                        else
                        {
                            for (int i = 0; i <= days; i++)
                            {
                                cmd.CommandText = "Sales_History_Daily_New";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = parentForm.conn;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(SBPStartDate).AddDays(i));

                                SqlDataAdapter adapter = new SqlDataAdapter();
                                adapter.SelectCommand = cmd;

                                parentForm.conn.Open();
                                adapter.Fill(dt2_All);
                                parentForm.conn.Close();
                            }

                            dataGridView2.RowTemplate.Height = 18;
                            dataGridView2.RowTemplate.DefaultCellStyle.Font = drvFont2;
                            dataGridView2.DataSource = dt2_All;
                            dataGridView2.Columns[0].HeaderText = "DATE";
                            //dataGridView2.Columns[0].Width = 115;
                            dataGridView2.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            dataGridView2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            dataGridView2.Columns[0].DefaultCellStyle.Format = "MM/dd/yyyy";
                            dataGridView2.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dataGridView2.Columns[1].HeaderText = "SALES";
                            //dataGridView2.Columns[1].Width = 150;
                            dataGridView2.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[1].DefaultCellStyle.Format = "c";
                            dataGridView2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dataGridView2.Columns[2].HeaderText = "TRNs";
                            //dataGridView2.Columns[2].Width = 75;
                            dataGridView2.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dataGridView2.Columns[3].HeaderText = "AVERAGE";
                            //dataGridView2.Columns[3].Width = 90;
                            dataGridView2.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[3].DefaultCellStyle.Format = "c";
                            dataGridView2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dataGridView2.Columns[4].HeaderText = "TAX";
                            //dataGridView2.Columns[4].Width = 120;
                            dataGridView2.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[4].DefaultCellStyle.Format = "c";
                            dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dataGridView2.Columns[5].HeaderText = "GROSS SALES";
                            //dataGridView2.Columns[5].Width = 150;
                            dataGridView2.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[5].DefaultCellStyle.Format = "c";
                            dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dataGridView2.Columns[6].HeaderText = "DISCOUNTS";
                            //dataGridView2.Columns[6].Width = 130;
                            dataGridView2.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[6].DefaultCellStyle.Format = "c";
                            dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                            dataGridView2.Columns[1].DefaultCellStyle.FormatProvider = nfi;
                            dataGridView2.Columns[3].DefaultCellStyle.FormatProvider = nfi;
                            dataGridView2.Columns[4].DefaultCellStyle.FormatProvider = nfi;
                            dataGridView2.Columns[5].DefaultCellStyle.FormatProvider = nfi;
                            dataGridView2.Columns[6].DefaultCellStyle.FormatProvider = nfi;

                            for (int i = 0; i < dataGridView2.RowCount; i++)
                            {
                                if (Convert.ToDateTime(dataGridView2.Rows[i].Cells[0].Value).DayOfWeek == DayOfWeek.Sunday)
                                    dataGridView2.Rows[i].Cells[0].Style.ForeColor = Color.Red;

                                if (dataGridView2.Rows[i].Cells[5].Value != DBNull.Value)
                                    SBPGrossSales = SBPGrossSales + Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value);

                                if (dataGridView2.Rows[i].Cells[2].Value != DBNull.Value)
                                    SBPNumOfTrans = SBPNumOfTrans + Convert.ToInt64(dataGridView2.Rows[i].Cells[2].Value);

                                if (dataGridView2.Rows[i].Cells[4].Value != DBNull.Value)
                                    SBPTax = SBPTax + Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value);

                                if (dataGridView2.Rows[i].Cells[1].Value != DBNull.Value)
                                    SBPNetSales = SBPNetSales + Convert.ToDouble(dataGridView2.Rows[i].Cells[1].Value);

                                if (dataGridView2.Rows[i].Cells[6].Value != DBNull.Value)
                                    SBPTotalDiscount = SBPTotalDiscount + Convert.ToDouble(dataGridView2.Rows[i].Cells[6].Value);
                            }

                            if (SBPNumOfTrans == 0)
                            {
                                SBPAverageNetSales = 0;
                            }
                            else
                            {
                                SBPAverageNetSales = SBPNetSales / SBPNumOfTrans;
                            }

                            lblSBPTitleStoreName.Visible = true;
                            lblSBPStoreName.Visible = true;
                            lblSBPStoreName.Text = parentForm.storeName.ToUpper();

                            dt2_All.Rows.Add("TOTAL", SBPNetSales, SBPNumOfTrans, SBPAverageNetSales, SBPTax, SBPGrossSales, SBPTotalDiscount);
                            dataGridView2.DataSource = dt2_All;
                            dataGridView2.Rows[dataGridView2.RowCount - 1].DefaultCellStyle.BackColor = Color.BurlyWood;

                            if (dataGridView2.RowCount > 0)
                                dataGridView2.Rows[0].Selected = false;
                        }
                    }
                    else if (rdoBtnMonthly.Checked == true)
                    {
                        SBPYear = cmbYear.Text;

                        if (SBPYear == "")
                        {
                            MessageBox.Show("SELECT YEAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnSBPOk.Enabled = true;
                            return;
                        }

                        dt2_All.Clear();
                        SBPNetSales = 0; SBPTax = 0; SBPGrossSales = 0;
                        SBPNumOfTrans = 0;
                        SBPTotalDiscount = 0; SBPAverageNetSales = 0;

                        //cmd.CommandText = "Sales_History_Monthly";
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Connection = parentForm.conn;
                        //cmd.Parameters.Clear();
                        //cmd.Parameters.Add("@Year", SqlDbType.NVarChar).Value = SBPYear;

                        //SqlDataAdapter adapter = new SqlDataAdapter();
                        //adapter.SelectCommand = cmd;

                        //parentForm.conn.Open();
                        //adapter.Fill(dt2_All);
                        //parentForm.conn.Close();

                        for (int i = 1; i <= 12; i++)
                        {
                            cmd.CommandText = "Sales_History_Monthly_New";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = parentForm.conn;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@Year", SqlDbType.NVarChar).Value = SBPYear;
                            cmd.Parameters.Add("@Month", SqlDbType.NVarChar).Value = i;

                            SqlDataAdapter adapter = new SqlDataAdapter();
                            adapter.SelectCommand = cmd;

                            parentForm.conn.Open();
                            adapter.Fill(dt2_All);
                            parentForm.conn.Close();
                        }

                        dataGridView2.RowTemplate.Height = 42;
                        dataGridView2.RowTemplate.DefaultCellStyle.Font = drvFont3;
                        dataGridView2.DataSource = dt2_All;
                        dataGridView2.Columns[0].HeaderText = "MONTH";
                        //dataGridView2.Columns[0].Width = 90;
                        dataGridView2.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        //dataGridView2.Columns[0].DefaultCellStyle.Format = "MM/dd/yyyy";
                        dataGridView2.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                        dataGridView2.Columns[1].HeaderText = "SALES";
                        //dataGridView2.Columns[1].Width = 160;
                        dataGridView2.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[1].DefaultCellStyle.Format = "c";
                        dataGridView2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                        dataGridView2.Columns[2].HeaderText = "TRNs";
                        //dataGridView2.Columns[2].Width = 70;
                        dataGridView2.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                        dataGridView2.Columns[3].HeaderText = "AVERAGE";
                        //dataGridView2.Columns[3].Width = 90;
                        dataGridView2.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[3].DefaultCellStyle.Format = "c";
                        dataGridView2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                        dataGridView2.Columns[4].HeaderText = "TAX";
                        //dataGridView2.Columns[4].Width = 130;
                        dataGridView2.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[4].DefaultCellStyle.Format = "c";
                        dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                        dataGridView2.Columns[5].HeaderText = "GROSS SALES";
                        //dataGridView2.Columns[5].Width = 160;
                        dataGridView2.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[5].DefaultCellStyle.Format = "c";
                        dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
                        dataGridView2.Columns[6].HeaderText = "DISCOUNTS";
                        //dataGridView2.Columns[6].Width = 130;
                        dataGridView2.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[6].DefaultCellStyle.Format = "c";
                        dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

                        dataGridView2.Columns[1].DefaultCellStyle.FormatProvider = nfi;
                        dataGridView2.Columns[3].DefaultCellStyle.FormatProvider = nfi;
                        dataGridView2.Columns[4].DefaultCellStyle.FormatProvider = nfi;
                        dataGridView2.Columns[5].DefaultCellStyle.FormatProvider = nfi;
                        dataGridView2.Columns[6].DefaultCellStyle.FormatProvider = nfi;

                        for (int i = 0; i < dataGridView2.RowCount; i++)
                        {
                            if (dataGridView2.Rows[i].Cells[5].Value != DBNull.Value)
                                SBPGrossSales = SBPGrossSales + Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value);

                            if (dataGridView2.Rows[i].Cells[2].Value != DBNull.Value)
                                SBPNumOfTrans = SBPNumOfTrans + Convert.ToInt64(dataGridView2.Rows[i].Cells[2].Value);

                            if (dataGridView2.Rows[i].Cells[4].Value != DBNull.Value)
                                SBPTax = SBPTax + Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value);

                            if (dataGridView2.Rows[i].Cells[1].Value != DBNull.Value)
                                SBPNetSales = SBPNetSales + Convert.ToDouble(dataGridView2.Rows[i].Cells[1].Value);

                            if (dataGridView2.Rows[i].Cells[6].Value != DBNull.Value)
                                SBPTotalDiscount = SBPTotalDiscount + Convert.ToDouble(dataGridView2.Rows[i].Cells[6].Value);
                        }

                        if (SBPNumOfTrans == 0)
                        {
                            SBPAverageNetSales = 0;
                        }
                        else
                        {
                            SBPAverageNetSales = SBPNetSales / SBPNumOfTrans;
                        }

                        lblSBPTitleStoreName.Visible = true;
                        lblSBPStoreName.Visible = true;
                        lblSBPStoreName.Text = parentForm.storeName.ToUpper();

                        dt2_All.Rows.Add("TOTAL", SBPNetSales, SBPNumOfTrans, SBPAverageNetSales, SBPTax, SBPGrossSales, SBPTotalDiscount);
                        dataGridView2.DataSource = dt2_All;
                        dataGridView2.Rows[dataGridView2.RowCount - 1].DefaultCellStyle.BackColor = Color.BurlyWood;

                        if (dataGridView2.RowCount > 0)
                            dataGridView2.Rows[0].Selected = false;
                    }
                    else if (rdoBtnYearly.Checked == true)
                    {
                        SBPStartYear = cmbStartYear.Text;
                        SBPEndYear = cmbEndYear.Text;

                        if (SBPStartYear == "")
                        {
                            MessageBox.Show("SELECT START YEAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnSBPOk.Enabled = true;
                            return;
                        }

                        if (SBPEndYear == "")
                        {
                            MessageBox.Show("SELECT END YEAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnSBPOk.Enabled = true;
                            return;
                        }

                        dt2_All.Clear();
                        SBPNetSales = 0; SBPTax = 0; SBPGrossSales = 0;
                        SBPNumOfTrans = 0;
                        SBPTotalDiscount = 0; SBPAverageNetSales = 0;

                        yearSpan = Convert.ToInt16(SBPEndYear) - Convert.ToInt16(SBPStartYear);

                        if (yearSpan < 0)
                        {
                            MessageBox.Show("INVALID YEAR RANGE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cmbEndYear.SelectAll();
                            cmbEndYear.Focus();
                            btnSBPOk.Enabled = true;
                            return;
                        }

                        for (int i = 0; i <= yearSpan; i++)
                        {
                            cmd.CommandText = "Sales_History_Yearly_New";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = parentForm.conn;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@Year", SqlDbType.NVarChar).Value = Convert.ToInt16(SBPStartYear) + i;

                            SqlDataAdapter adapter = new SqlDataAdapter();
                            adapter.SelectCommand = cmd;

                            parentForm.conn.Open();
                            adapter.Fill(dt2_All);
                            parentForm.conn.Close();
                        }

                        dataGridView2.RowTemplate.Height = 42;
                        dataGridView2.RowTemplate.DefaultCellStyle.Font = drvFont3;
                        dataGridView2.DataSource = dt2_All;
                        dataGridView2.Columns[0].HeaderText = "YEAR";
                        //dataGridView2.Columns[0].Width = 80;
                        dataGridView2.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                        dataGridView2.Columns[1].HeaderText = "SALES";
                        //dataGridView2.Columns[1].Width = 160;
                        dataGridView2.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[1].DefaultCellStyle.Format = "c";
                        dataGridView2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                        dataGridView2.Columns[2].HeaderText = "TRNs";
                        //dataGridView2.Columns[2].Width = 70;
                        dataGridView2.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                        dataGridView2.Columns[3].HeaderText = "AVERAGE";
                        //dataGridView2.Columns[3].Width = 90;
                        dataGridView2.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[3].DefaultCellStyle.Format = "c";
                        dataGridView2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                        dataGridView2.Columns[4].HeaderText = "TAX";
                        //dataGridView2.Columns[4].Width = 130;
                        dataGridView2.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[4].DefaultCellStyle.Format = "c";
                        dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                        dataGridView2.Columns[5].HeaderText = "GROSS SALES";
                        //dataGridView2.Columns[5].Width = 160;
                        dataGridView2.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[5].DefaultCellStyle.Format = "c";
                        dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
                        dataGridView2.Columns[6].HeaderText = "DISCOUNTS";
                        //dataGridView2.Columns[6].Width = 130;
                        dataGridView2.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[6].DefaultCellStyle.Format = "c";
                        dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

                        dataGridView2.Columns[1].DefaultCellStyle.FormatProvider = nfi;
                        dataGridView2.Columns[3].DefaultCellStyle.FormatProvider = nfi;
                        dataGridView2.Columns[4].DefaultCellStyle.FormatProvider = nfi;
                        dataGridView2.Columns[5].DefaultCellStyle.FormatProvider = nfi;
                        dataGridView2.Columns[6].DefaultCellStyle.FormatProvider = nfi;

                        for (int i = 0; i < dataGridView2.RowCount; i++)
                        {
                            if (dataGridView2.Rows[i].Cells[5].Value != DBNull.Value)
                                SBPGrossSales = SBPGrossSales + Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value);

                            if (dataGridView2.Rows[i].Cells[2].Value != DBNull.Value)
                                SBPNumOfTrans = SBPNumOfTrans + Convert.ToInt64(dataGridView2.Rows[i].Cells[2].Value);

                            if (dataGridView2.Rows[i].Cells[4].Value != DBNull.Value)
                                SBPTax = SBPTax + Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value);

                            if (dataGridView2.Rows[i].Cells[1].Value != DBNull.Value)
                                SBPNetSales = SBPNetSales + Convert.ToDouble(dataGridView2.Rows[i].Cells[1].Value);

                            if (dataGridView2.Rows[i].Cells[6].Value != DBNull.Value)
                                SBPTotalDiscount = SBPTotalDiscount + Convert.ToDouble(dataGridView2.Rows[i].Cells[6].Value);
                        }

                        if (SBPNumOfTrans == 0)
                        {
                            SBPAverageNetSales = 0;
                        }
                        else
                        {
                            SBPAverageNetSales = SBPNetSales / SBPNumOfTrans;
                        }

                        lblSBPTitleStoreName.Visible = true;
                        lblSBPStoreName.Visible = true;
                        lblSBPStoreName.Text = parentForm.storeName.ToUpper();

                        dt2_All.Rows.Add("TOTAL", SBPNetSales, SBPNumOfTrans, SBPAverageNetSales, SBPTax, SBPGrossSales, SBPTotalDiscount);
                        dataGridView2.DataSource = dt2_All;
                        dataGridView2.Rows[dataGridView2.RowCount - 1].DefaultCellStyle.BackColor = Color.BurlyWood;

                        if (dataGridView2.RowCount > 0)
                            dataGridView2.Rows[0].Selected = false;
                    }

                    btnSBPOk.Enabled = true;
                }
                else
                {
                    if (parentForm.UserChecking(cmbSBPStoreCode.Text.Trim().ToUpper()) < 6)
                    {
                        MessageBox.Show("You are not authorized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dataGridView2.DataSource = DBNull.Value;
                        btnSBPOk.Enabled = true;
                        return;
                    }

                    if (cmbSBPStoreCode.Text == "OH")
                    {
                        newConn = new SqlConnection("Data Source=" + parentForm.OHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.OHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                        lblSBPStoreName.Text = "OXON HILL";
                    }
                    else if (cmbSBPStoreCode.Text == "CH")
                    {
                        newConn = new SqlConnection("Data Source=" + parentForm.CHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                        lblSBPStoreName.Text = "CAPITOL HEIGHTS";
                    }
                    else if (cmbSBPStoreCode.Text == "WB")
                    {
                        newConn = new SqlConnection("Data Source=" + parentForm.WBIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WBDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                        lblSBPStoreName.Text = "WOODBRIDGE";
                    }
                    else if (cmbSBPStoreCode.Text == "CV")
                    {
                        newConn = new SqlConnection("Data Source=" + parentForm.CVIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CVDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                        lblSBPStoreName.Text = "CATONSVILLE";
                    }
                    else if (cmbSBPStoreCode.Text == "UM")
                    {
                        newConn = new SqlConnection("Data Source=" + parentForm.UMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.UMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                        lblSBPStoreName.Text = "UPPER MARLBORO";
                    }
                    else if (cmbSBPStoreCode.Text == "WM")
                    {
                        newConn = new SqlConnection("Data Source=" + parentForm.WMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                        lblSBPStoreName.Text = "WINDSOR MILL";
                    }
                    else if (cmbSBPStoreCode.Text == "TH")
                    {
                        newConn = new SqlConnection("Data Source=" + parentForm.THIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.THDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                        lblSBPStoreName.Text = "TEMPLE HILLS";
                    }
                    else if (cmbSBPStoreCode.Text == "WD")
                    {
                        newConn = new SqlConnection("Data Source=" + parentForm.WDIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WDDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                        lblSBPStoreName.Text = "WALDORF";
                    }
                    else if (cmbSBPStoreCode.Text == "PW")
                    {
                        newConn = new SqlConnection("Data Source=" + parentForm.PWIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.PWDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                        lblSBPStoreName.Text = "PRINCE WILLIAM";
                    }
                    else if (cmbSBPStoreCode.Text == "GB")
                    {
                        newConn = new SqlConnection(parentForm.GBCS_IP);
                        lblSBPStoreName.Text = "GAITHERSBURG";
                    }
                    else if (cmbSBPStoreCode.Text == "BW")
                    {
                        newConn = new SqlConnection(parentForm.BWCS_IP);
                        lblSBPStoreName.Text = "BOWIE";
                    }

                    if (rdoBtnHouly.Checked == true)
                    {
                        SBPStartDate = txtSBPStartDate.Text;

                        if (SBPStartDate == "")
                        {
                            MessageBox.Show("SELECT DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnSBPOk.Enabled = true;
                            return;
                        }
                        else
                        {
                            if (Convert.ToDateTime(SBPStartDate).DayOfWeek != DayOfWeek.Sunday)
                            {
                                dt2_All.Clear();
                                SBPNetSales = 0; SBPTax = 0; SBPGrossSales = 0;
                                SBPNumOfTrans = 0;
                                SBPTotalDiscount = 0; SBPAverageNetSales = 0;
                                hour = Convert.ToDateTime("9:00:00");

                                for (int i = 9; i <= 21; i++)
                                {
                                    sHour = hour.ToString("T");

                                    cmd.CommandText = "Sales_History_Hourly_New";
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Connection = newConn;
                                    cmd.Parameters.Clear();
                                    cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = SBPStartDate;
                                    cmd.Parameters.Add("@StartHour", SqlDbType.NVarChar).Value = sHour;

                                    hour = hour.AddHours(1);
                                    sHour = hour.ToString("T");

                                    cmd.Parameters.Add("@EndHour", SqlDbType.NVarChar).Value = sHour;
                                    cmd.Parameters.Add("@DisplayHour", SqlDbType.NVarChar).Value = Convert.ToString(i);

                                    SqlDataAdapter adapter = new SqlDataAdapter();
                                    adapter.SelectCommand = cmd;

                                    newConn.Open();
                                    adapter.Fill(dt2_All);
                                    newConn.Close();
                                }

                                dataGridView2.RowTemplate.Height = 37;
                                dataGridView2.RowTemplate.DefaultCellStyle.Font = drvFont1;
                                dataGridView2.DataSource = dt2_All;
                                dataGridView2.Columns[0].HeaderText = "HOUR";
                                //dataGridView2.Columns[0].Width = 100;
                                dataGridView2.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                dataGridView2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                dataGridView2.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                                dataGridView2.Columns[1].HeaderText = "SALES";
                                //dataGridView2.Columns[1].Width = 150;
                                dataGridView2.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[1].DefaultCellStyle.Format = "c";
                                dataGridView2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                                dataGridView2.Columns[2].HeaderText = "TRNs";
                                //dataGridView2.Columns[2].Width = 70;
                                dataGridView2.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                                dataGridView2.Columns[3].HeaderText = "AVERAGE";
                                //dataGridView2.Columns[3].Width = 100;
                                dataGridView2.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[3].DefaultCellStyle.Format = "c";
                                dataGridView2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                                dataGridView2.Columns[4].HeaderText = "TAX";
                                //dataGridView2.Columns[4].Width = 130;
                                dataGridView2.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[4].DefaultCellStyle.Format = "c";
                                dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                                dataGridView2.Columns[5].HeaderText = "GROSS SALES";
                                //dataGridView2.Columns[5].Width = 150;
                                dataGridView2.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[5].DefaultCellStyle.Format = "c";
                                dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
                                dataGridView2.Columns[6].HeaderText = "DISCOUNTS";
                                //dataGridView2.Columns[6].Width = 130;
                                dataGridView2.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[6].DefaultCellStyle.Format = "c";
                                dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

                                dataGridView2.Columns[1].DefaultCellStyle.FormatProvider = nfi;
                                dataGridView2.Columns[3].DefaultCellStyle.FormatProvider = nfi;
                                dataGridView2.Columns[4].DefaultCellStyle.FormatProvider = nfi;
                                dataGridView2.Columns[5].DefaultCellStyle.FormatProvider = nfi;
                                dataGridView2.Columns[6].DefaultCellStyle.FormatProvider = nfi;

                                for (int i = 0; i < dataGridView2.RowCount; i++)
                                {
                                    if (dataGridView2.Rows[i].Cells[5].Value != DBNull.Value)
                                        SBPGrossSales = SBPGrossSales + Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value);

                                    if (dataGridView2.Rows[i].Cells[2].Value != DBNull.Value)
                                        SBPNumOfTrans = SBPNumOfTrans + Convert.ToInt64(dataGridView2.Rows[i].Cells[2].Value);

                                    if (dataGridView2.Rows[i].Cells[4].Value != DBNull.Value)
                                        SBPTax = SBPTax + Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value);

                                    if (dataGridView2.Rows[i].Cells[1].Value != DBNull.Value)
                                        SBPNetSales = SBPNetSales + Convert.ToDouble(dataGridView2.Rows[i].Cells[1].Value);

                                    if (dataGridView2.Rows[i].Cells[6].Value != DBNull.Value)
                                        SBPTotalDiscount = SBPTotalDiscount + Convert.ToDouble(dataGridView2.Rows[i].Cells[6].Value);
                                }

                                if (SBPNumOfTrans == 0)
                                {
                                    SBPAverageNetSales = 0;
                                }
                                else
                                {
                                    SBPAverageNetSales = SBPNetSales / SBPNumOfTrans;
                                }

                                //lblSBPTitleStoreName.Visible = true;
                                //lblSBPStoreName.Visible = true;
                                //lblSBPStoreName.Text = parentForm.storeName.ToUpper();

                                dt2_All.Rows.Add("TOTAL", SBPNetSales, SBPNumOfTrans, SBPAverageNetSales, SBPTax, SBPGrossSales, SBPTotalDiscount);
                                dataGridView2.DataSource = dt2_All;
                                dataGridView2.Rows[dataGridView2.RowCount - 1].DefaultCellStyle.BackColor = Color.BurlyWood;

                                if (dataGridView2.RowCount > 0)
                                    dataGridView2.Rows[0].Selected = false;
                            }
                            else
                            {
                                dt2_All.Clear();
                                SBPNetSales = 0; SBPTax = 0; SBPGrossSales = 0;
                                SBPNumOfTrans = 0;
                                SBPTotalDiscount = 0; SBPAverageNetSales = 0;
                                hour = Convert.ToDateTime("10:00:00");

                                for (int i = 10; i <= 18; i++)
                                {
                                    sHour = hour.ToString("T");

                                    cmd.CommandText = "Sales_History_Hourly_New";
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Connection = newConn;
                                    cmd.Parameters.Clear();
                                    cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = SBPStartDate;
                                    cmd.Parameters.Add("@StartHour", SqlDbType.NVarChar).Value = sHour;

                                    hour = hour.AddHours(1);
                                    sHour = hour.ToString("T");

                                    cmd.Parameters.Add("@EndHour", SqlDbType.NVarChar).Value = sHour;
                                    cmd.Parameters.Add("@DisplayHour", SqlDbType.NVarChar).Value = Convert.ToString(i);

                                    SqlDataAdapter adapter = new SqlDataAdapter();
                                    adapter.SelectCommand = cmd;

                                    newConn.Open();
                                    adapter.Fill(dt2_All);
                                    newConn.Close();
                                }

                                dataGridView2.RowTemplate.Height = 37;
                                dataGridView2.RowTemplate.DefaultCellStyle.Font = drvFont1;
                                dataGridView2.DataSource = dt2_All;
                                dataGridView2.Columns[0].HeaderText = "HOUR";
                                //dataGridView2.Columns[0].Width = 100;
                                dataGridView2.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                dataGridView2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                dataGridView2.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                                dataGridView2.Columns[1].HeaderText = "SALES";
                                //dataGridView2.Columns[1].Width = 150;
                                dataGridView2.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[1].DefaultCellStyle.Format = "c";
                                dataGridView2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                                dataGridView2.Columns[2].HeaderText = "TRNs";
                                //dataGridView2.Columns[2].Width = 70;
                                dataGridView2.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                                dataGridView2.Columns[3].HeaderText = "AVERAGE";
                                //dataGridView2.Columns[3].Width = 100;
                                dataGridView2.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[3].DefaultCellStyle.Format = "c";
                                dataGridView2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                                dataGridView2.Columns[4].HeaderText = "TAX";
                                //dataGridView2.Columns[4].Width = 130;
                                dataGridView2.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[4].DefaultCellStyle.Format = "c";
                                dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                                dataGridView2.Columns[5].HeaderText = "GROSS SALES";
                                //dataGridView2.Columns[5].Width = 150;
                                dataGridView2.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[5].DefaultCellStyle.Format = "c";
                                dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
                                dataGridView2.Columns[6].HeaderText = "DISCOUNTS";
                                //dataGridView2.Columns[6].Width = 130;
                                dataGridView2.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[6].DefaultCellStyle.Format = "c";
                                dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dataGridView2.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

                                dataGridView2.Columns[1].DefaultCellStyle.FormatProvider = nfi;
                                dataGridView2.Columns[3].DefaultCellStyle.FormatProvider = nfi;
                                dataGridView2.Columns[4].DefaultCellStyle.FormatProvider = nfi;
                                dataGridView2.Columns[5].DefaultCellStyle.FormatProvider = nfi;
                                dataGridView2.Columns[6].DefaultCellStyle.FormatProvider = nfi;

                                for (int i = 0; i < dataGridView2.RowCount; i++)
                                {
                                    if (dataGridView2.Rows[i].Cells[5].Value != DBNull.Value)
                                        SBPGrossSales = SBPGrossSales + Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value);

                                    if (dataGridView2.Rows[i].Cells[2].Value != DBNull.Value)
                                        SBPNumOfTrans = SBPNumOfTrans + Convert.ToInt64(dataGridView2.Rows[i].Cells[2].Value);

                                    if (dataGridView2.Rows[i].Cells[4].Value != DBNull.Value)
                                        SBPTax = SBPTax + Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value);

                                    if (dataGridView2.Rows[i].Cells[1].Value != DBNull.Value)
                                        SBPNetSales = SBPNetSales + Convert.ToDouble(dataGridView2.Rows[i].Cells[1].Value);

                                    if (dataGridView2.Rows[i].Cells[6].Value != DBNull.Value)
                                        SBPTotalDiscount = SBPTotalDiscount + Convert.ToDouble(dataGridView2.Rows[i].Cells[6].Value);
                                }

                                if (SBPNumOfTrans == 0)
                                {
                                    SBPAverageNetSales = 0;
                                }
                                else
                                {
                                    SBPAverageNetSales = SBPNetSales / SBPNumOfTrans;
                                }

                                //lblSBPTitleStoreName.Visible = true;
                                //lblSBPStoreName.Visible = true;
                                //lblSBPStoreName.Text = parentForm.storeName.ToUpper();

                                dt2_All.Rows.Add("TOTAL", SBPNetSales, SBPNumOfTrans, SBPAverageNetSales, SBPTax, SBPGrossSales, SBPTotalDiscount);
                                dataGridView2.DataSource = dt2_All;
                                dataGridView2.Rows[dataGridView2.RowCount - 1].DefaultCellStyle.BackColor = Color.BurlyWood;

                                if (dataGridView2.RowCount > 0)
                                    dataGridView2.Rows[0].Selected = false;
                            }
                        }
                    }
                    else if (rdoBtnDaily.Checked == true)
                    {
                        SBPStartDate = txtSBPStartDate.Text;
                        SBPEndDate = txtSBPEndDate.Text;

                        if (SBPStartDate == "")
                        {
                            MessageBox.Show("SELECT START DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnSBPOk.Enabled = true;
                            return;
                        }

                        if (SBPEndDate == "")
                        {
                            MessageBox.Show("SELECT END DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnSBPOk.Enabled = true;
                            return;
                        }

                        dt2_All.Clear();
                        SBPNetSales = 0; SBPTax = 0; SBPGrossSales = 0;
                        SBPNumOfTrans = 0;
                        SBPTotalDiscount = 0; SBPAverageNetSales = 0;

                        TimeSpan t = Convert.ToDateTime(SBPEndDate).Subtract(Convert.ToDateTime(SBPStartDate));
                        days = t.Days;

                        if (SBPStartDate == SBPEndDate)
                        {
                            cmd.CommandText = "Sales_History_Daily_New";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = newConn;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = SBPStartDate;

                            SqlDataAdapter adapter = new SqlDataAdapter();
                            adapter.SelectCommand = cmd;

                            newConn.Open();
                            adapter.Fill(dt2_All);
                            newConn.Close();

                            dataGridView2.RowTemplate.Height = 18;
                            dataGridView2.RowTemplate.DefaultCellStyle.Font = drvFont2;
                            dataGridView2.DataSource = dt2_All;
                            dataGridView2.Columns[0].HeaderText = "DATE";
                            //dataGridView2.Columns[0].Width = 115;
                            dataGridView2.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            dataGridView2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            dataGridView2.Columns[0].DefaultCellStyle.Format = "MM/dd/yyyy";
                            dataGridView2.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dataGridView2.Columns[1].HeaderText = "SALES";
                            //dataGridView2.Columns[1].Width = 150;
                            dataGridView2.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[1].DefaultCellStyle.Format = "c";
                            dataGridView2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dataGridView2.Columns[2].HeaderText = "TRNs";
                            //dataGridView2.Columns[2].Width = 75;
                            dataGridView2.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dataGridView2.Columns[3].HeaderText = "AVERAGE";
                            //dataGridView2.Columns[3].Width = 90;
                            dataGridView2.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[3].DefaultCellStyle.Format = "c";
                            dataGridView2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dataGridView2.Columns[4].HeaderText = "TAX";
                            //dataGridView2.Columns[4].Width = 120;
                            dataGridView2.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[4].DefaultCellStyle.Format = "c";
                            dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dataGridView2.Columns[5].HeaderText = "GROSS SALES";
                            //dataGridView2.Columns[5].Width = 150;
                            dataGridView2.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[5].DefaultCellStyle.Format = "c";
                            dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dataGridView2.Columns[6].HeaderText = "DISCOUNTS";
                            //dataGridView2.Columns[6].Width = 130;
                            dataGridView2.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[6].DefaultCellStyle.Format = "c";
                            dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                            dataGridView2.Columns[1].DefaultCellStyle.FormatProvider = nfi;
                            dataGridView2.Columns[3].DefaultCellStyle.FormatProvider = nfi;
                            dataGridView2.Columns[4].DefaultCellStyle.FormatProvider = nfi;
                            dataGridView2.Columns[5].DefaultCellStyle.FormatProvider = nfi;
                            dataGridView2.Columns[6].DefaultCellStyle.FormatProvider = nfi;

                            for (int i = 0; i < dataGridView2.RowCount; i++)
                            {
                                if (Convert.ToDateTime(dataGridView2.Rows[i].Cells[0].Value).DayOfWeek == DayOfWeek.Sunday)
                                    dataGridView2.Rows[i].Cells[0].Style.ForeColor = Color.Red;

                                if (dataGridView2.Rows[i].Cells[5].Value != DBNull.Value)
                                    SBPGrossSales = SBPGrossSales + Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value);

                                if (dataGridView2.Rows[i].Cells[2].Value != DBNull.Value)
                                    SBPNumOfTrans = SBPNumOfTrans + Convert.ToInt64(dataGridView2.Rows[i].Cells[2].Value);

                                if (dataGridView2.Rows[i].Cells[4].Value != DBNull.Value)
                                    SBPTax = SBPTax + Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value);

                                if (dataGridView2.Rows[i].Cells[1].Value != DBNull.Value)
                                    SBPNetSales = SBPNetSales + Convert.ToDouble(dataGridView2.Rows[i].Cells[1].Value);

                                if (dataGridView2.Rows[i].Cells[6].Value != DBNull.Value)
                                    SBPTotalDiscount = SBPTotalDiscount + Convert.ToDouble(dataGridView2.Rows[i].Cells[6].Value);
                            }

                            if (SBPNumOfTrans == 0)
                            {
                                SBPAverageNetSales = 0;
                            }
                            else
                            {
                                SBPAverageNetSales = SBPNetSales / SBPNumOfTrans;
                            }

                            //lblSBPTitleStoreName.Visible = true;
                            //lblSBPStoreName.Visible = true;
                            //lblSBPStoreName.Text = parentForm.storeName.ToUpper();

                            dt2_All.Rows.Add("TOTAL", SBPNetSales, SBPNumOfTrans, SBPAverageNetSales, SBPTax, SBPGrossSales, SBPTotalDiscount);
                            dataGridView2.DataSource = dt2_All;
                            dataGridView2.Rows[dataGridView2.RowCount - 1].DefaultCellStyle.BackColor = Color.BurlyWood;

                            if (dataGridView2.RowCount > 0)
                                dataGridView2.Rows[0].Selected = false;
                        }
                        else
                        {
                            for (int i = 0; i <= days; i++)
                            {
                                cmd.CommandText = "Sales_History_Daily_New";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = newConn;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(SBPStartDate).AddDays(i));

                                SqlDataAdapter adapter = new SqlDataAdapter();
                                adapter.SelectCommand = cmd;

                                newConn.Open();
                                adapter.Fill(dt2_All);
                                newConn.Close();
                            }

                            dataGridView2.RowTemplate.Height = 18;
                            dataGridView2.RowTemplate.DefaultCellStyle.Font = drvFont2;
                            dataGridView2.DataSource = dt2_All;
                            dataGridView2.Columns[0].HeaderText = "DATE";
                            //dataGridView2.Columns[0].Width = 115;
                            dataGridView2.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            dataGridView2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            dataGridView2.Columns[0].DefaultCellStyle.Format = "MM/dd/yyyy";
                            dataGridView2.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dataGridView2.Columns[1].HeaderText = "SALES";
                            //dataGridView2.Columns[1].Width = 150;
                            dataGridView2.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[1].DefaultCellStyle.Format = "c";
                            dataGridView2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dataGridView2.Columns[2].HeaderText = "TRNs";
                            //dataGridView2.Columns[2].Width = 75;
                            dataGridView2.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dataGridView2.Columns[3].HeaderText = "AVERAGE";
                            //dataGridView2.Columns[3].Width = 90;
                            dataGridView2.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[3].DefaultCellStyle.Format = "c";
                            dataGridView2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dataGridView2.Columns[4].HeaderText = "TAX";
                            //dataGridView2.Columns[4].Width = 120;
                            dataGridView2.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[4].DefaultCellStyle.Format = "c";
                            dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dataGridView2.Columns[5].HeaderText = "GROSS SALES";
                            //dataGridView2.Columns[5].Width = 150;
                            dataGridView2.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[5].DefaultCellStyle.Format = "c";
                            dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dataGridView2.Columns[6].HeaderText = "DISCOUNTS";
                            //dataGridView2.Columns[6].Width = 130;
                            dataGridView2.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView2.Columns[6].DefaultCellStyle.Format = "c";
                            dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                            dataGridView2.Columns[1].DefaultCellStyle.FormatProvider = nfi;
                            dataGridView2.Columns[3].DefaultCellStyle.FormatProvider = nfi;
                            dataGridView2.Columns[4].DefaultCellStyle.FormatProvider = nfi;
                            dataGridView2.Columns[5].DefaultCellStyle.FormatProvider = nfi;
                            dataGridView2.Columns[6].DefaultCellStyle.FormatProvider = nfi;

                            for (int i = 0; i < dataGridView2.RowCount; i++)
                            {
                                if (Convert.ToDateTime(dataGridView2.Rows[i].Cells[0].Value).DayOfWeek == DayOfWeek.Sunday)
                                    dataGridView2.Rows[i].Cells[0].Style.ForeColor = Color.Red;

                                if (dataGridView2.Rows[i].Cells[5].Value != DBNull.Value)
                                    SBPGrossSales = SBPGrossSales + Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value);

                                if (dataGridView2.Rows[i].Cells[2].Value != DBNull.Value)
                                    SBPNumOfTrans = SBPNumOfTrans + Convert.ToInt64(dataGridView2.Rows[i].Cells[2].Value);

                                if (dataGridView2.Rows[i].Cells[4].Value != DBNull.Value)
                                    SBPTax = SBPTax + Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value);

                                if (dataGridView2.Rows[i].Cells[1].Value != DBNull.Value)
                                    SBPNetSales = SBPNetSales + Convert.ToDouble(dataGridView2.Rows[i].Cells[1].Value);

                                if (dataGridView2.Rows[i].Cells[6].Value != DBNull.Value)
                                    SBPTotalDiscount = SBPTotalDiscount + Convert.ToDouble(dataGridView2.Rows[i].Cells[6].Value);
                            }

                            if (SBPNumOfTrans == 0)
                            {
                                SBPAverageNetSales = 0;
                            }
                            else
                            {
                                SBPAverageNetSales = SBPNetSales / SBPNumOfTrans;
                            }

                            //lblSBPTitleStoreName.Visible = true;
                            //lblSBPStoreName.Visible = true;
                            //lblSBPStoreName.Text = parentForm.storeName.ToUpper();

                            dt2_All.Rows.Add("TOTAL", SBPNetSales, SBPNumOfTrans, SBPAverageNetSales, SBPTax, SBPGrossSales, SBPTotalDiscount);
                            dataGridView2.DataSource = dt2_All;
                            dataGridView2.Rows[dataGridView2.RowCount - 1].DefaultCellStyle.BackColor = Color.BurlyWood;

                            if (dataGridView2.RowCount > 0)
                                dataGridView2.Rows[0].Selected = false;
                        }
                    }
                    else if (rdoBtnMonthly.Checked == true)
                    {
                        SBPYear = cmbYear.Text;

                        if (SBPYear == "")
                        {
                            MessageBox.Show("SELECT YEAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnSBPOk.Enabled = true;
                            return;
                        }

                        dt2_All.Clear();
                        SBPNetSales = 0; SBPTax = 0; SBPGrossSales = 0;
                        SBPNumOfTrans = 0;
                        SBPTotalDiscount = 0; SBPAverageNetSales = 0;

                        //cmd.CommandText = "Sales_History_Monthly";
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Connection = newConn;
                        //cmd.Parameters.Clear();
                        //cmd.Parameters.Add("@Year", SqlDbType.NVarChar).Value = SBPYear;

                        //SqlDataAdapter adapter = new SqlDataAdapter();
                        //adapter.SelectCommand = cmd;

                        //newConn.Open();
                        //adapter.Fill(dt2_All);
                        //newConn.Close();

                        for (int i = 1; i <= 12; i++)
                        {
                            cmd.CommandText = "Sales_History_Monthly_New";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = newConn;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@Year", SqlDbType.NVarChar).Value = SBPYear;
                            cmd.Parameters.Add("@Month", SqlDbType.NVarChar).Value = i;

                            SqlDataAdapter adapter = new SqlDataAdapter();
                            adapter.SelectCommand = cmd;

                            newConn.Open();
                            adapter.Fill(dt2_All);
                            newConn.Close();
                        }

                        dataGridView2.RowTemplate.Height = 42;
                        dataGridView2.RowTemplate.DefaultCellStyle.Font = drvFont3;
                        dataGridView2.DataSource = dt2_All;
                        dataGridView2.Columns[0].HeaderText = "MONTH";
                        //dataGridView2.Columns[0].Width = 90;
                        dataGridView2.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                        dataGridView2.Columns[1].HeaderText = "SALES";
                        //dataGridView2.Columns[1].Width = 160;
                        dataGridView2.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[1].DefaultCellStyle.Format = "c";
                        dataGridView2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                        dataGridView2.Columns[2].HeaderText = "TRNs";
                        //dataGridView2.Columns[2].Width = 70;
                        dataGridView2.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                        dataGridView2.Columns[3].HeaderText = "AVERAGE";
                        //dataGridView2.Columns[3].Width = 90;
                        dataGridView2.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[3].DefaultCellStyle.Format = "c";
                        dataGridView2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                        dataGridView2.Columns[4].HeaderText = "TAX";
                        //dataGridView2.Columns[4].Width = 130;
                        dataGridView2.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[4].DefaultCellStyle.Format = "c";
                        dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                        dataGridView2.Columns[5].HeaderText = "GROSS SALES";
                        //dataGridView2.Columns[5].Width = 160;
                        dataGridView2.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[5].DefaultCellStyle.Format = "c";
                        dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
                        dataGridView2.Columns[6].HeaderText = "DISCOUNTS";
                        //dataGridView2.Columns[6].Width = 130;
                        dataGridView2.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[6].DefaultCellStyle.Format = "c";
                        dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

                        dataGridView2.Columns[1].DefaultCellStyle.FormatProvider = nfi;
                        dataGridView2.Columns[3].DefaultCellStyle.FormatProvider = nfi;
                        dataGridView2.Columns[4].DefaultCellStyle.FormatProvider = nfi;
                        dataGridView2.Columns[5].DefaultCellStyle.FormatProvider = nfi;
                        dataGridView2.Columns[6].DefaultCellStyle.FormatProvider = nfi;

                        for (int i = 0; i < dataGridView2.RowCount; i++)
                        {
                            if (dataGridView2.Rows[i].Cells[5].Value != DBNull.Value)
                                SBPGrossSales = SBPGrossSales + Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value);

                            if (dataGridView2.Rows[i].Cells[2].Value != DBNull.Value)
                                SBPNumOfTrans = SBPNumOfTrans + Convert.ToInt64(dataGridView2.Rows[i].Cells[2].Value);

                            if (dataGridView2.Rows[i].Cells[4].Value != DBNull.Value)
                                SBPTax = SBPTax + Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value);

                            if (dataGridView2.Rows[i].Cells[1].Value != DBNull.Value)
                                SBPNetSales = SBPNetSales + Convert.ToDouble(dataGridView2.Rows[i].Cells[1].Value);

                            if (dataGridView2.Rows[i].Cells[6].Value != DBNull.Value)
                                SBPTotalDiscount = SBPTotalDiscount + Convert.ToDouble(dataGridView2.Rows[i].Cells[6].Value);
                        }

                        if (SBPNumOfTrans == 0)
                        {
                            SBPAverageNetSales = 0;
                        }
                        else
                        {
                            SBPAverageNetSales = SBPNetSales / SBPNumOfTrans;
                        }

                        //lblSBPTitleStoreName.Visible = true;
                        //lblSBPStoreName.Visible = true;
                        //lblSBPStoreName.Text = parentForm.storeName.ToUpper();

                        dt2_All.Rows.Add("TOTAL", SBPNetSales, SBPNumOfTrans, SBPAverageNetSales, SBPTax, SBPGrossSales, SBPTotalDiscount);
                        dataGridView2.DataSource = dt2_All;
                        dataGridView2.Rows[dataGridView2.RowCount - 1].DefaultCellStyle.BackColor = Color.BurlyWood;

                        if (dataGridView2.RowCount > 0)
                            dataGridView2.Rows[0].Selected = false;
                    }
                    else if (rdoBtnYearly.Checked == true)
                    {
                        SBPStartYear = cmbStartYear.Text;
                        SBPEndYear = cmbEndYear.Text;

                        if (SBPStartYear == "")
                        {
                            MessageBox.Show("SELECT START YEAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnSBPOk.Enabled = true;
                            return;
                        }

                        if (SBPEndYear == "")
                        {
                            MessageBox.Show("SELECT END YEAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnSBPOk.Enabled = true;
                            return;
                        }

                        dt2_All.Clear();
                        SBPNetSales = 0; SBPTax = 0; SBPGrossSales = 0;
                        SBPNumOfTrans = 0;
                        SBPTotalDiscount = 0; SBPAverageNetSales = 0;

                        yearSpan = Convert.ToInt16(SBPEndYear) - Convert.ToInt16(SBPStartYear);

                        if (yearSpan < 0)
                        {
                            MessageBox.Show("INVALID YEAR RANGE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cmbEndYear.SelectAll();
                            cmbEndYear.Focus();
                            btnSBPOk.Enabled = true;
                            return;
                        }

                        for (int i = 0; i <= yearSpan; i++)
                        {
                            cmd.CommandText = "Sales_History_Yearly_New";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = newConn;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@Year", SqlDbType.NVarChar).Value = Convert.ToInt16(SBPStartYear) + i;

                            SqlDataAdapter adapter = new SqlDataAdapter();
                            adapter.SelectCommand = cmd;

                            newConn.Open();
                            adapter.Fill(dt2_All);
                            newConn.Close();
                        }

                        dataGridView2.RowTemplate.Height = 42;
                        dataGridView2.RowTemplate.DefaultCellStyle.Font = drvFont3;
                        dataGridView2.DataSource = dt2_All;
                        dataGridView2.Columns[0].HeaderText = "YEAR";
                        //dataGridView2.Columns[0].Width = 80;
                        dataGridView2.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[1].HeaderText = "SALES";
                        //dataGridView2.Columns[1].Width = 160;
                        dataGridView2.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[1].DefaultCellStyle.Format = "c";
                        dataGridView2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[2].HeaderText = "TRNs";
                        //dataGridView2.Columns[2].Width = 70;
                        dataGridView2.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[3].HeaderText = "AVERAGE";
                        //dataGridView2.Columns[3].Width = 90;
                        dataGridView2.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[3].DefaultCellStyle.Format = "c";
                        dataGridView2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[4].HeaderText = "TAX";
                        //dataGridView2.Columns[4].Width = 130;
                        dataGridView2.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[4].DefaultCellStyle.Format = "c";
                        dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[5].HeaderText = "GROSS SALES";
                        //dataGridView2.Columns[5].Width = 160;
                        dataGridView2.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[5].DefaultCellStyle.Format = "c";
                        dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[6].HeaderText = "DISCOUNTS";
                        //dataGridView2.Columns[6].Width = 130;
                        dataGridView2.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[6].DefaultCellStyle.Format = "c";
                        dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                        dataGridView2.Columns[1].DefaultCellStyle.FormatProvider = nfi;
                        dataGridView2.Columns[3].DefaultCellStyle.FormatProvider = nfi;
                        dataGridView2.Columns[4].DefaultCellStyle.FormatProvider = nfi;
                        dataGridView2.Columns[5].DefaultCellStyle.FormatProvider = nfi;
                        dataGridView2.Columns[6].DefaultCellStyle.FormatProvider = nfi;

                        for (int i = 0; i < dataGridView2.RowCount; i++)
                        {
                            if (dataGridView2.Rows[i].Cells[5].Value != DBNull.Value)
                                SBPGrossSales = SBPGrossSales + Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value);

                            if (dataGridView2.Rows[i].Cells[2].Value != DBNull.Value)
                                SBPNumOfTrans = SBPNumOfTrans + Convert.ToInt64(dataGridView2.Rows[i].Cells[2].Value);

                            if (dataGridView2.Rows[i].Cells[4].Value != DBNull.Value)
                                SBPTax = SBPTax + Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value);

                            if (dataGridView2.Rows[i].Cells[1].Value != DBNull.Value)
                                SBPNetSales = SBPNetSales + Convert.ToDouble(dataGridView2.Rows[i].Cells[1].Value);

                            if (dataGridView2.Rows[i].Cells[6].Value != DBNull.Value)
                                SBPTotalDiscount = SBPTotalDiscount + Convert.ToDouble(dataGridView2.Rows[i].Cells[6].Value);
                        }

                        if (SBPNumOfTrans == 0)
                        {
                            SBPAverageNetSales = 0;
                        }
                        else
                        {
                            SBPAverageNetSales = SBPNetSales / SBPNumOfTrans;
                        }

                        //lblSBPTitleStoreName.Visible = true;
                        //lblSBPStoreName.Visible = true;
                        //lblSBPStoreName.Text = parentForm.storeName.ToUpper();

                        dt2_All.Rows.Add("TOTAL", SBPNetSales, SBPNumOfTrans, SBPAverageNetSales, SBPTax, SBPGrossSales, SBPTotalDiscount);
                        dataGridView2.DataSource = dt2_All;
                        dataGridView2.Rows[dataGridView2.RowCount - 1].DefaultCellStyle.BackColor = Color.BurlyWood;

                        if (dataGridView2.RowCount > 0)
                            dataGridView2.Rows[0].Selected = false;
                    }

                    btnSBPOk.Enabled = true;
                }
            }
            catch
            {
                MessageBox.Show("CAN NOT CONNECT TO THE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                if (parentForm.StoreCode == cmbSBPStoreCode.Text.ToUpper().ToString())
                {
                    parentForm.conn.Close();
                }
                else
                {
                    newConn.Close();
                }

                btnSBPOk.Enabled = true;
                return;
            }
        }

        private void btnSBPClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoBtnHouly_CheckedChanged(object sender, EventArgs e)
        {
            dt2_All.Clear();
            dataGridView2.DataSource = null;

            if (rdoBtnHouly.Checked == true)
            {
                label10.Visible = false;
                txtSBPEndDate.Visible = false;

                lblYear.Visible = false;
                cmbYear.Visible = false;
            }
            else
            {
                label10.Visible = true;
                txtSBPEndDate.Visible = true;
            }
        }

        private void rdoBtnDaily_CheckedChanged(object sender, EventArgs e)
        {
            dt2_All.Clear();
            dataGridView2.DataSource = null;

            if (rdoBtnDaily.Checked == true)
            {
                lblRef.ForeColor = Color.Red;
                dataGridView2.ColumnHeadersHeight = 21;
                dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            }
            else
            {
                lblRef.ForeColor = Color.LightYellow;
                dataGridView2.ColumnHeadersHeight = 45;
                dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);
            }
        }

        private void rdoBtnMonthly_CheckedChanged(object sender, EventArgs e)
        {
            dt2_All.Clear();
            dataGridView2.DataSource = null;

            if (rdoBtnMonthly.Checked == true)
            {
                label10.Visible = false;
                label11.Visible = false;
                txtSBPStartDate.Visible = false;
                txtSBPEndDate.Visible = false;

                lblYear.Visible = true;
                cmbYear.Visible = true;
            }
            else
            {
                label10.Visible = true;
                label11.Visible = true;
                txtSBPStartDate.Visible = true;
                txtSBPEndDate.Visible = true;

                lblYear.Visible = false;
                cmbYear.Visible = false;
            }
        }

        private void rdoBtnYearly_CheckedChanged(object sender, EventArgs e)
        {
            dt2_All.Clear();
            dataGridView2.DataSource = null;

            if (rdoBtnYearly.Checked == true)
            {
                lblStartYear.Visible = true;
                lblEndYear.Visible = true;
                cmbStartYear.Visible = true;
                cmbEndYear.Visible = true;
            }
            else
            {
                lblStartYear.Visible = false;
                lblEndYear.Visible = false;
                cmbStartYear.Visible = false;
                cmbEndYear.Visible = false;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (parentForm.userLevel >= parentForm.SectionManagerLV)
                {
                    if (dataGridView1.SelectedCells[0].Value.ToString() == "HAIR CARE")
                    {
                        CategoryDetailSales categoryDetailSalesForm = new CategoryDetailSales(dataGridView1.SelectedCells[0].Value.ToString(), 1, Convert.ToDouble(dataGridView1.SelectedCells[1].Value));
                        categoryDetailSalesForm.parentForm1 = this.parentForm;
                        categoryDetailSalesForm.parentForm2 = this;
                        categoryDetailSalesForm.Show();
                    }
                    else if (dataGridView1.SelectedCells[0].Value.ToString() == "WIG/PONY TAIL")
                    {
                        CategoryDetailSales categoryDetailSalesForm = new CategoryDetailSales(dataGridView1.SelectedCells[0].Value.ToString(), 2, Convert.ToDouble(dataGridView1.SelectedCells[1].Value));
                        categoryDetailSalesForm.parentForm1 = this.parentForm;
                        categoryDetailSalesForm.parentForm2 = this;
                        categoryDetailSalesForm.Show();
                    }
                    else if (dataGridView1.SelectedCells[0].Value.ToString() == "HAIR")
                    {
                        CategoryDetailSales categoryDetailSalesForm = new CategoryDetailSales(dataGridView1.SelectedCells[0].Value.ToString(), 3, Convert.ToDouble(dataGridView1.SelectedCells[1].Value));
                        categoryDetailSalesForm.parentForm1 = this.parentForm;
                        categoryDetailSalesForm.parentForm2 = this;
                        categoryDetailSalesForm.Show();
                    }
                    else if (dataGridView1.SelectedCells[0].Value.ToString() == "STYLING & SALON SUPPLIES")
                    {
                        CategoryDetailSales categoryDetailSalesForm = new CategoryDetailSales(dataGridView1.SelectedCells[0].Value.ToString(), 4, Convert.ToDouble(dataGridView1.SelectedCells[1].Value));
                        categoryDetailSalesForm.parentForm1 = this.parentForm;
                        categoryDetailSalesForm.parentForm2 = this;
                        categoryDetailSalesForm.Show();
                    }
                    else if (dataGridView1.SelectedCells[0].Value.ToString() == "SKIN/COSMETIC/NAIL/FOOT")
                    {
                        CategoryDetailSales categoryDetailSalesForm = new CategoryDetailSales(dataGridView1.SelectedCells[0].Value.ToString(), 5, Convert.ToDouble(dataGridView1.SelectedCells[1].Value));
                        categoryDetailSalesForm.parentForm1 = this.parentForm;
                        categoryDetailSalesForm.parentForm2 = this;
                        categoryDetailSalesForm.Show();
                    }
                    else if (dataGridView1.SelectedCells[0].Value.ToString() == "GENERAL MERCHANDISE")
                    {
                        CategoryDetailSales categoryDetailSalesForm = new CategoryDetailSales(dataGridView1.SelectedCells[0].Value.ToString(), 6, Convert.ToDouble(dataGridView1.SelectedCells[1].Value));
                        categoryDetailSalesForm.parentForm1 = this.parentForm;
                        categoryDetailSalesForm.parentForm2 = this;
                        categoryDetailSalesForm.Show();
                    }
                }
                else
                {
                    MessageBox.Show("NOT AUTHORIZED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch
            {
                return;
            }
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

        private void monthCalendar3_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtSBPStartDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar3.SelectionStart));
            monthCalendar3.Visible = false;
        }

        private void monthCalendar4_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtSBPEndDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar4.SelectionStart));
            monthCalendar4.Visible = false;
        }

        private void monthCalendar5_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtSBRStartDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar5.SelectionStart));
            monthCalendar5.Visible = false;
        }

        private void monthCalendar6_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtSBREndDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar6.SelectionStart));
            monthCalendar6.Visible = false;
        }

        private void btnSBROk_Click(object sender, EventArgs e)
        {
            lblSBRStoreName.Text = parentForm.storeName.ToUpper();

            SBRStartDate = txtSBRStartDate.Text.Trim();
            SBREndDate = txtSBREndDate.Text.Trim();

            if (SBRStartDate == "")
            {
                MessageBox.Show("SELECT START DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (SBREndDate == "")
            {
                MessageBox.Show("SELECT END DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dt3.Clear();
            SBRNetSales = 0; SBRTax = 0; SBRGrossSales = 0;
            SBRNumOfTrans = 0;
            SBRAverageNetSales = 0; SBRTotalDiscount = 0;

            for (int i = 0; i < 4; i++)
            {
                SBRRegisterNum = "REG0" + Convert.ToString(i + 1);
                cmd.CommandText = "Sales_History_RegisterNum_New";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = parentForm.conn;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = SBRStartDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = SBREndDate;
                cmd.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = SBRRegisterNum;

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                parentForm.conn.Open();
                adapter.Fill(dt3);
                parentForm.conn.Close();
            }

            dataGridView3.RowTemplate.Height = 50;
            dataGridView3.RowTemplate.DefaultCellStyle.Font = drvFont;
            dataGridView3.DataSource = dt3;
            dataGridView3.Columns[0].HeaderText = "REG #";
            //dataGridView3.Columns[0].Width = 100;
            dataGridView3.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView3.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView3.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView3.Columns[1].HeaderText = "SALES";
            //dataGridView3.Columns[1].Width = 150;
            dataGridView3.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView3.Columns[1].DefaultCellStyle.FormatProvider = nfi;
            dataGridView3.Columns[1].DefaultCellStyle.Format = "c";
            dataGridView3.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView3.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView3.Columns[2].HeaderText = "TRNs";
            //dataGridView3.Columns[2].Width = 70;
            dataGridView3.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView3.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView3.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView3.Columns[3].HeaderText = "AVERAGE";
            //dataGridView3.Columns[3].Width = 100;
            dataGridView3.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView3.Columns[3].DefaultCellStyle.FormatProvider = nfi;
            dataGridView3.Columns[3].DefaultCellStyle.Format = "c";
            dataGridView3.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView3.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView3.Columns[4].HeaderText = "TAX";
            //dataGridView3.Columns[4].Width = 130;
            dataGridView3.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView3.Columns[4].DefaultCellStyle.FormatProvider = nfi;
            dataGridView3.Columns[4].DefaultCellStyle.Format = "c";
            dataGridView3.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView3.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView3.Columns[5].HeaderText = "GROSS SALES";
            //dataGridView3.Columns[5].Width = 150;
            dataGridView3.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView3.Columns[5].DefaultCellStyle.FormatProvider = nfi;
            dataGridView3.Columns[5].DefaultCellStyle.Format = "c";
            dataGridView3.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView3.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView3.Columns[6].HeaderText = "DISCOUNTS";
            //dataGridView3.Columns[6].Width = 130;
            dataGridView3.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView3.Columns[6].DefaultCellStyle.FormatProvider = nfi;
            dataGridView3.Columns[6].DefaultCellStyle.Format = "c";
            dataGridView3.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView3.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

            for (int i = 0; i < dataGridView3.RowCount; i++)
            {
                if (dataGridView3.Rows[i].Cells[1].Value != DBNull.Value)
                    SBRNetSales = SBRNetSales + Convert.ToDouble(dataGridView3.Rows[i].Cells[1].Value);

                if (dataGridView3.Rows[i].Cells[2].Value != DBNull.Value)
                    SBRNumOfTrans = SBRNumOfTrans + Convert.ToInt64(dataGridView3.Rows[i].Cells[2].Value);

                if (dataGridView3.Rows[i].Cells[4].Value != DBNull.Value)
                    SBRTax = SBRTax + Convert.ToDouble(dataGridView3.Rows[i].Cells[4].Value);

                if (dataGridView3.Rows[i].Cells[5].Value != DBNull.Value)
                    SBRGrossSales = SBRGrossSales + Convert.ToDouble(dataGridView3.Rows[i].Cells[5].Value);

                if (dataGridView3.Rows[i].Cells[6].Value != DBNull.Value)
                    SBRTotalDiscount = SBRTotalDiscount + Convert.ToDouble(dataGridView3.Rows[i].Cells[6].Value);
            }

            if (SBRNumOfTrans == 0)
            {
                SBRAverageNetSales = 0;
            }
            else
            {
                SBRAverageNetSales = SBRNetSales / SBRNumOfTrans;
            }

            //lblSBRTitleStoreName.Visible = true;
            //lblSBRStoreName.Visible = true;
            //lblSBRStoreName.Text = parentForm.storeName.ToUpper();

            dt3.Rows.Add("TOTAL", SBRNetSales, SBRNumOfTrans, SBRAverageNetSales, SBRTax, SBRGrossSales, SBRTotalDiscount);
            dataGridView3.DataSource = dt3;
            dataGridView3.Rows[dataGridView3.RowCount - 1].DefaultCellStyle.BackColor = Color.BurlyWood;

            if (dataGridView3.RowCount > 0)
                dataGridView3.Rows[0].Selected = false;
        }

        private void btnSBRClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSBRStartDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar5.Visible = true;
        }

        private void txtSBREndDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar6.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbSBBCategory1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSBBCategory1.SelectedIndex == 0 | cmbSBBCategory1.SelectedIndex > 6)
            {
                cmbSBBCategory2.DataSource = null;
                cmbSBBCategory2.Items.Clear();
                cmbSBBCategory3.DataSource = null;
                cmbSBBCategory3.Items.Clear();
                return;
            }

            SqlCommand cmd_CmbCategory2 = new SqlCommand("Get_Category_Group2", parentForm.conn);
            cmd_CmbCategory2.CommandType = CommandType.StoredProcedure;
            cmd_CmbCategory2.Parameters.Add("@ItmGp_Parents", SqlDbType.Int).Value = cmbSBBCategory1.SelectedIndex;
            DataSet ds = new DataSet();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd_CmbCategory2;

            parentForm.conn.Open();
            adapt.Fill(ds);
            parentForm.conn.Close();

            cmbSBBCategory2.DataSource = ds.Tables[0].DefaultView;
            cmbSBBCategory2.ValueMember = "ItmGp_Desc";
            cmbSBBCategory2.DisplayMember = "ItmGp_Desc";

            ds.Tables.Clear();
        }

        private void cmbSBBCategory2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSBBCategory3.DataSource = null;
            cmbSBBCategory3.Items.Clear();

            index1 = cmbSBBCategory1.SelectedIndex;
            index2 = cmbSBBCategory2.SelectedIndex;

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

                    cmbSBBCategory3.DataSource = ds.Tables[0].DefaultView;
                    cmbSBBCategory3.ValueMember = "ItmGp_Desc";
                    cmbSBBCategory3.DisplayMember = "ItmGp_Desc";
                    break;
                default:
                    cmd_CmbCategory3.Parameters.Add("@ItmGp_Parents", SqlDbType.Int).Value = index1;
                    cmd_CmbCategory3.Parameters.Add("@ItmGp_Parents2", SqlDbType.Int).Value = index2;
                    adapt.SelectCommand = cmd_CmbCategory3;

                    parentForm.conn.Open();
                    adapt.Fill(ds);
                    parentForm.conn.Close();

                    cmbSBBCategory3.DataSource = ds.Tables[0].DefaultView;
                    cmbSBBCategory3.ValueMember = "ItmGp_Desc";
                    cmbSBBCategory3.DisplayMember = "ItmGp_Desc";
                    break;
            }
        }

        private void btnSBBOk_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParse(txtSBBStartDate.Text, out d))
            {
                SBBStartDate = txtSBBStartDate.Text.Trim();
            }
            else
            {
                MessageBox.Show("INVALID START DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSBBStartDate.SelectAll();
                txtSBBStartDate.Focus();
                return;
            }

            if (DateTime.TryParse(txtSBBEndDate.Text, out d))
            {
                SBBEndDate = txtSBBEndDate.Text.Trim();
            }
            else
            {
                MessageBox.Show("INVALID END DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSBBEndDate.SelectAll();
                txtSBBEndDate.Focus();
                return;
            }

            btnSBBOk.Enabled = false;

            if (parentForm.StoreCode == cmbSBBStoreCode.Text.ToUpper().ToString())
            {
                try
                {
                    lblSBBStoreName.Text = parentForm.storeName.ToUpper().ToString();
                    dt4.Clear();
                    SBBTotalSoldQty = 0; SBBTotalSales = 0;

                    if (cmbSBBCategory1.SelectedIndex == 0)
                    {
                        cmd.CommandText = "Sales_History_Brand";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = parentForm.conn;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = SBBStartDate;
                        cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = SBBEndDate;
                    }
                    else
                    {
                        if (cmbSBBCategory2.SelectedIndex > 0)
                        {
                            if (cmbSBBCategory3.SelectedIndex >= 0)
                            {
                                if (cmbSBBCategory1.SelectedIndex > 5)
                                {
                                    SBBGp1 = cmbSBBCategory1.SelectedIndex + 1;
                                }
                                else
                                {
                                    SBBGp1 = cmbSBBCategory1.SelectedIndex;
                                }
                                SBBGp2 = cmbSBBCategory2.SelectedIndex;
                                SBBGp3 = cmbSBBCategory3.SelectedIndex + 1;

                                cmd.CommandText = "Sales_History_Brand_With_Category_1_2_3";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = parentForm.conn;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = SBBGp1;
                                cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = SBBGp2;
                                cmd.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = SBBGp3;
                                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = SBBStartDate;
                                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = SBBEndDate;
                            }
                            else
                            {
                                if (cmbSBBCategory1.SelectedIndex > 5)
                                {
                                    SBBGp1 = cmbSBBCategory1.SelectedIndex + 1;
                                }
                                else
                                {
                                    SBBGp1 = cmbSBBCategory1.SelectedIndex;
                                }
                                SBBGp2 = cmbSBBCategory2.SelectedIndex;

                                cmd.CommandText = "Sales_History_Brand_With_Category_1_2";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = parentForm.conn;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = SBBGp1;
                                cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = SBBGp2;
                                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = SBBStartDate;
                                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = SBBEndDate;
                            }
                        }
                        else
                        {
                            if (cmbSBBCategory1.SelectedIndex > 5)
                            {
                                SBBGp1 = cmbSBBCategory1.SelectedIndex + 1;
                            }
                            else
                            {
                                SBBGp1 = cmbSBBCategory1.SelectedIndex;
                            }

                            cmd.CommandText = "Sales_History_Brand_With_Category_1";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = parentForm.conn;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = SBBGp1;
                            cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = SBBStartDate;
                            cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = SBBEndDate;
                        }
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;

                    parentForm.conn.Open();
                    adapter.Fill(dt4);
                    parentForm.conn.Close();

                    dataGridView4.RowTemplate.Height = 40;
                    dataGridView4.RowTemplate.DefaultCellStyle.Font = drvFont3;
                    dataGridView4.DataSource = dt4;
                    dataGridView4.Columns[0].HeaderText = "BRAND";
                    //dataGridView4.Columns[0].Width = 200;
                    dataGridView4.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dataGridView4.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView4.Columns[1].HeaderText = "SOLD QTY";
                    //dataGridView4.Columns[1].Width = 100;
                    dataGridView4.Columns[1].DefaultCellStyle.FormatProvider = nfi;
                    dataGridView4.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView4.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView4.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView4.Columns[2].HeaderText = "SALES AMOUNT";
                    //dataGridView4.Columns[2].Width = 200;
                    dataGridView4.Columns[2].DefaultCellStyle.FormatProvider = nfi;
                    dataGridView4.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView4.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView4.Columns[2].DefaultCellStyle.Format = "c";
                    dataGridView4.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView4.Columns[3].HeaderText = "PERCENTAGE";
                    //dataGridView4.Columns[3].Width = 120;
                    dataGridView4.Columns[3].DefaultCellStyle.FormatProvider = nfi;
                    dataGridView4.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView4.Columns[3].DefaultCellStyle.Format = "p";
                    dataGridView4.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView4.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

                    for (int i = 0; i < dataGridView4.RowCount; i++)
                    {
                        if (dataGridView4.Rows[i].Cells[1].Value != DBNull.Value)
                            SBBTotalSoldQty = SBBTotalSoldQty + Convert.ToInt64(dataGridView4.Rows[i].Cells[1].Value);

                        if (dataGridView4.Rows[i].Cells[2].Value != DBNull.Value)
                            SBBTotalSales = SBBTotalSales + Convert.ToDouble(dataGridView4.Rows[i].Cells[2].Value);
                    }

                    for (int i = 0; i < dataGridView4.RowCount; i++)
                    {
                        dataGridView4.Rows[i].Cells[3].Value = Convert.ToDouble(dataGridView4.Rows[i].Cells[2].Value) / SBBTotalSales;
                    }

                    //dt4.Rows.Add("TOTAL (NET SALES)", SBBTotalSoldQty, SBBTotalSales, SBBTotalSales / SBBTotalSales);
                    //dataGridView4.DataSource = dt4;
                    //dataGridView4.Rows[dataGridView4.RowCount - 1].DefaultCellStyle.BackColor = Color.BurlyWood;

                    if (dataGridView4.RowCount > 0)
                    {
                        dataGridView4.Rows[0].Selected = false;
                        dt4.Rows.Add("TOTAL", SBBTotalSoldQty, SBBTotalSales, SBBTotalSales / SBBTotalSales);
                        dataGridView4.DataSource = dt4;
                        dataGridView4.Rows[dataGridView4.RowCount - 1].DefaultCellStyle.BackColor = Color.BurlyWood;
                    }

                    btnSBBOk.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("CAN NOT CONNECT TO THE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parentForm.conn.Close();
                    btnSBBOk.Enabled = true;
                    return;
                }
            }
            else
            {
                /*if (parentForm.UserChecking(cmbSBBStoreCode.Text.Trim().ToUpper()) < 6)
                {
                    MessageBox.Show("You are not authorized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView4.DataSource = DBNull.Value;
                    btnSBBOk.Enabled = true;
                    return;
                }*/

                if (cmbSBBStoreCode.Text == "OH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.OHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.OHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblSBBStoreName.Text = "OXON HILL";
                }
                else if (cmbSBBStoreCode.Text == "CH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblSBBStoreName.Text = "CAPITOL HEIGHTS";
                }
                else if (cmbSBBStoreCode.Text == "WB")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WBIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WBDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblSBBStoreName.Text = "WOODBRIDGE";
                }
                else if (cmbSBBStoreCode.Text == "CV")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CVIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CVDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblSBBStoreName.Text = "CATONSVILLE";
                }
                else if (cmbSBBStoreCode.Text == "UM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.UMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.UMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblSBBStoreName.Text = "UPPER MARLBORO";
                }
                else if (cmbSBBStoreCode.Text == "WM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblSBBStoreName.Text = "WINDSOR MILL";
                }
                else if (cmbSBBStoreCode.Text == "TH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.THIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.THDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblSBBStoreName.Text = "TEMPLE HILLS";
                }
                else if (cmbSBBStoreCode.Text == "WD")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WDIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WDDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblSBBStoreName.Text = "WALDORF";
                }
                else if (cmbSBBStoreCode.Text == "PW")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.PWIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.PWDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblSBBStoreName.Text = "PRINCE WILLIAM";
                }
                else if (cmbSBBStoreCode.Text == "GB")
                {
                    newConn = new SqlConnection(parentForm.GBCS_IP);
                    lblSBBStoreName.Text = "GAITHERSBURG";
                }
                else if (cmbSBBStoreCode.Text == "BW")
                {
                    newConn = new SqlConnection(parentForm.BWCS_IP);
                    lblSBBStoreName.Text = "BOWIE";
                }

                try
                {
                    dt4.Clear();
                    SBBTotalSoldQty = 0; SBBTotalSales = 0;

                    if (cmbSBBCategory1.SelectedIndex == 0)
                    {
                        cmd.CommandText = "Sales_History_Brand";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = newConn;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = SBBStartDate;
                        cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = SBBEndDate;
                    }
                    else
                    {
                        if (cmbSBBCategory2.SelectedIndex > 0)
                        {
                            if (cmbSBBCategory3.SelectedIndex >= 0)
                            {
                                if (cmbSBBCategory1.SelectedIndex > 5)
                                {
                                    SBBGp1 = cmbSBBCategory1.SelectedIndex + 1;
                                }
                                else
                                {
                                    SBBGp1 = cmbSBBCategory1.SelectedIndex;
                                }
                                SBBGp2 = cmbSBBCategory2.SelectedIndex;
                                SBBGp3 = cmbSBBCategory3.SelectedIndex + 1;

                                cmd.CommandText = "Sales_History_Brand_With_Category_1_2_3";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = newConn;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = SBBGp1;
                                cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = SBBGp2;
                                cmd.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = SBBGp3;
                                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = SBBStartDate;
                                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = SBBEndDate;
                            }
                            else
                            {
                                if (cmbSBBCategory1.SelectedIndex > 5)
                                {
                                    SBBGp1 = cmbSBBCategory1.SelectedIndex + 1;
                                }
                                else
                                {
                                    SBBGp1 = cmbSBBCategory1.SelectedIndex;
                                }
                                SBBGp2 = cmbSBBCategory2.SelectedIndex;

                                cmd.CommandText = "Sales_History_Brand_With_Category_1_2";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = newConn;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = SBBGp1;
                                cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = SBBGp2;
                                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = SBBStartDate;
                                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = SBBEndDate;
                            }
                        }
                        else
                        {
                            if (cmbSBBCategory1.SelectedIndex > 5)
                            {
                                SBBGp1 = cmbSBBCategory1.SelectedIndex + 1;
                            }
                            else
                            {
                                SBBGp1 = cmbSBBCategory1.SelectedIndex;
                            }

                            cmd.CommandText = "Sales_History_Brand_With_Category_1";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = newConn;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = SBBGp1;
                            cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = SBBStartDate;
                            cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = SBBEndDate;
                        }
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;

                    newConn.Open();
                    adapter.Fill(dt4);
                    newConn.Close();

                    dataGridView4.RowTemplate.Height = 40;
                    dataGridView4.RowTemplate.DefaultCellStyle.Font = drvFont3;
                    dataGridView4.DataSource = dt4;
                    dataGridView4.Columns[0].HeaderText = "BRAND";
                    //dataGridView4.Columns[0].Width = 200;
                    dataGridView4.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView4.Columns[1].HeaderText = "SOLD QTY";
                    //dataGridView4.Columns[1].Width = 100;
                    dataGridView4.Columns[1].DefaultCellStyle.FormatProvider = nfi;
                    dataGridView4.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView4.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView4.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView4.Columns[2].HeaderText = "SALES AMOUNT";
                    //dataGridView4.Columns[2].Width = 200;
                    dataGridView4.Columns[2].DefaultCellStyle.FormatProvider = nfi;
                    dataGridView4.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView4.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView4.Columns[2].DefaultCellStyle.Format = "c";
                    dataGridView4.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView4.Columns[3].HeaderText = "PERCENTAGE";
                    //dataGridView4.Columns[3].Width = 120;
                    dataGridView4.Columns[3].DefaultCellStyle.FormatProvider = nfi;
                    dataGridView4.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView4.Columns[3].DefaultCellStyle.Format = "p";
                    dataGridView4.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView4.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

                    for (int i = 0; i < dataGridView4.RowCount; i++)
                    {
                        if (dataGridView4.Rows[i].Cells[1].Value != DBNull.Value)
                            SBBTotalSoldQty = SBBTotalSoldQty + Convert.ToInt64(dataGridView4.Rows[i].Cells[1].Value);

                        if (dataGridView4.Rows[i].Cells[2].Value != DBNull.Value)
                            SBBTotalSales = SBBTotalSales + Convert.ToDouble(dataGridView4.Rows[i].Cells[2].Value);
                    }

                    for (int i = 0; i < dataGridView4.RowCount; i++)
                    {
                        dataGridView4.Rows[i].Cells[3].Value = Convert.ToDouble(dataGridView4.Rows[i].Cells[2].Value) / SBBTotalSales;
                    }

                    //dt4.Rows.Add("TOTAL (NET SALES)", SBBTotalSoldQty, SBBTotalSales, SBBTotalSales / SBBTotalSales);
                    //dataGridView4.DataSource = dt4;
                    //dataGridView4.Rows[dataGridView4.RowCount - 1].DefaultCellStyle.BackColor = Color.BurlyWood;

                    if (dataGridView4.RowCount > 0)
                    {
                        dataGridView4.Rows[0].Selected = false;
                        dt4.Rows.Add("TOTAL", SBBTotalSoldQty, SBBTotalSales, SBBTotalSales / SBBTotalSales);
                        dataGridView4.DataSource = dt4;
                        dataGridView4.Rows[dataGridView4.RowCount - 1].DefaultCellStyle.BackColor = Color.BurlyWood;
                    }

                    btnSBBOk.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("CAN NOT CONNECT TO THE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    newConn.Close();
                    btnSBBOk.Enabled = true;
                    return;
                }
            }
        }

        private void btnSBBReset_Click(object sender, EventArgs e)
        {
            dataGridView4.DataSource = null;
            cmbSBBCategory2.DataSource = null;
            cmbSBBCategory2.Items.Clear();
            cmbSBBCategory3.DataSource = null;
            cmbSBBCategory3.Items.Clear();

            SqlCommand cmd_CmbCategory1 = new SqlCommand("Get_Category_Group1", parentForm.conn);
            cmd_CmbCategory1.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd_CmbCategory1;

            parentForm.conn.Open();
            adapt.Fill(ds);
            parentForm.conn.Close();

            cmbSBBCategory1.DataSource = ds.Tables[0].DefaultView;
            cmbSBBCategory1.ValueMember = "ItmGp_Desc";
            cmbSBBCategory1.DisplayMember = "ItmGp_Desc";
        }

        private void btnSBBClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSBBStartDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar7.Visible = true;
        }

        private void txtSBBEndDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar8.Visible = true;
        }

        private void monthCalendar7_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtSBBStartDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar7.SelectionStart));
            monthCalendar7.Visible = false;
        }

        private void monthCalendar8_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtSBBEndDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar8.SelectionStart));
            monthCalendar8.Visible = false;
        }

        private void btnSBBExcel_Click(object sender, EventArgs e)
        {
            if (parentForm.employeeID.ToUpper() == "ADMIN" | parentForm.specialCode == parentForm.txtSpecialCode.Text.Trim().ToString().ToUpper())
            {
                if (dataGridView4.RowCount > 0)
                {
                    this.Enabled = false;

                    Excel_12.Application ReportFile;
                    Excel_12._Workbook WorkBook;
                    Excel_12._Worksheet WorkSheet;
                    //Excel_12.Range Range;

                    string MaxRow = Convert.ToString(dt4.Rows.Count + 1);
                    String MaxColumn = ((String)(Convert.ToChar(dt4.Columns.Count / 26 + 64).ToString() + Convert.ToChar(dt4.Columns.Count % 26 + 64))).Replace('@', ' ').Trim();
                    String MaxCell = MaxColumn + MaxRow;

                    ReportFile = new Excel_12.Application();
                    ReportFile.Visible = false;

                    WorkBook = (Excel_12._Workbook)(ReportFile.Workbooks.Add("workbook"));
                    WorkSheet = (Excel_12._Worksheet)WorkBook.ActiveSheet;

                    for (int i = 0; i < dt4.Columns.Count; i++)
                        WorkSheet.Cells[1, i + 1] = dt4.Columns[i].ColumnName;

                    string[,] Values = new string[dt4.Rows.Count, dt4.Columns.Count];

                    for (int i = 0; i < dt4.Rows.Count; i++)
                        for (int j = 0; j < dt4.Columns.Count; j++)
                        {

                            Values[i, j] = dt4.Rows[i][j].ToString();

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
                if (dataGridView4.RowCount > 0)
                {
                    ExportDataGridViewTo_Excel12(dataGridView4);
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

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (parentForm.userLevel >= parentForm.SectionManagerLV)
                {
                    BrandDetailSlaes brandDetailSalesForm = new BrandDetailSlaes(dataGridView4.SelectedCells[0].Value.ToString(), Convert.ToDouble(dataGridView4.SelectedCells[2].Value));
                    brandDetailSalesForm.parentForm1 = this.parentForm;
                    brandDetailSalesForm.parentForm2 = this;
                    brandDetailSalesForm.Show();
                }
                else
                {
                    MessageBox.Show("NOT AUTHORIZED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch
            {
                return;
            }
        }

        private void btnSBVOk_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParse(txtSBVStartDate.Text, out d))
            {
                SBVStartDate = txtSBVStartDate.Text.Trim();
            }
            else
            {
                MessageBox.Show("INVALID START DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSBVStartDate.SelectAll();
                txtSBVStartDate.Focus();
                return;
            }

            if (DateTime.TryParse(txtSBVEndDate.Text, out d))
            {
                SBVEndDate = txtSBVEndDate.Text.Trim();
            }
            else
            {
                MessageBox.Show("INVALID END DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSBVEndDate.SelectAll();
                txtSBVEndDate.Focus();
                return;
            }

            btnSBVOk.Enabled = false;

            if (parentForm.StoreCode == cmbSBBStoreCode.Text.ToUpper().ToString())
            {
                btnSBVOk.Enabled = true;

                try
                {
                    lblSBVStoreName.Text = parentForm.storeName.ToUpper().ToString();
                    dt5.Clear();
                    SBVTotalSoldQty = 0; SBVTotalSales = 0;

                    if (cmbSBVCategory1.SelectedIndex == 0)
                    {
                        cmd.CommandText = "Sales_History_Vendor";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = parentForm.conn;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = SBVStartDate;
                        cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = SBVEndDate;
                    }
                    else
                    {
                        if (cmbSBVCategory2.SelectedIndex > 0)
                        {
                            if (cmbSBVCategory3.SelectedIndex >= 0)
                            {
                                if (cmbSBVCategory1.SelectedIndex > 5)
                                {
                                    SBVGp1 = cmbSBVCategory1.SelectedIndex + 1;
                                }
                                else
                                {
                                    SBVGp1 = cmbSBVCategory1.SelectedIndex;
                                }
                                SBVGp2 = cmbSBVCategory2.SelectedIndex;
                                SBVGp3 = cmbSBVCategory3.SelectedIndex + 1;

                                cmd.CommandText = "Sales_History_Vendor_With_Category_1_2_3";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = parentForm.conn;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = SBVGp1;
                                cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = SBVGp2;
                                cmd.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = SBVGp3;
                                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = SBVStartDate;
                                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = SBVEndDate;
                            }
                            else
                            {
                                if (cmbSBVCategory1.SelectedIndex > 5)
                                {
                                    SBVGp1 = cmbSBVCategory1.SelectedIndex + 1;
                                }
                                else
                                {
                                    SBVGp1 = cmbSBVCategory1.SelectedIndex;
                                }
                                SBVGp2 = cmbSBVCategory2.SelectedIndex;

                                cmd.CommandText = "Sales_History_Vendor_With_Category_1_2";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = parentForm.conn;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = SBVGp1;
                                cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = SBVGp2;
                                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = SBVStartDate;
                                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = SBVEndDate;
                            }
                        }
                        else
                        {
                            if (cmbSBVCategory1.SelectedIndex > 5)
                            {
                                SBVGp1 = cmbSBVCategory1.SelectedIndex + 1;
                            }
                            else
                            {
                                SBVGp1 = cmbSBVCategory1.SelectedIndex;
                            }

                            cmd.CommandText = "Sales_History_Vendor_With_Category_1";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = parentForm.conn;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = SBVGp1;
                            cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = SBVStartDate;
                            cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = SBVEndDate;
                        }
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;

                    parentForm.conn.Open();
                    adapter.Fill(dt5);
                    parentForm.conn.Close();

                    dataGridView5.RowTemplate.Height = 40;
                    dataGridView5.RowTemplate.DefaultCellStyle.Font = drvFont3;
                    dataGridView5.DataSource = dt5;
                    dataGridView5.Columns[0].HeaderText = "VENDOR";
                    //dataGridView5.Columns[0].Width = 200;
                    dataGridView5.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dataGridView5.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView5.Columns[1].HeaderText = "SOLD QTY";
                    //dataGridView5.Columns[1].Width = 100;
                    dataGridView5.Columns[1].DefaultCellStyle.FormatProvider = nfi;
                    dataGridView5.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView5.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView5.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView5.Columns[2].HeaderText = "SALES AMOUNT";
                    //dataGridView5.Columns[2].Width = 200;
                    dataGridView5.Columns[2].DefaultCellStyle.FormatProvider = nfi;
                    dataGridView5.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView5.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView5.Columns[2].DefaultCellStyle.Format = "c";
                    dataGridView5.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView5.Columns[3].HeaderText = "PERCENTAGE";
                    //dataGridView5.Columns[3].Width = 120;
                    dataGridView5.Columns[3].DefaultCellStyle.FormatProvider = nfi;
                    dataGridView5.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView5.Columns[3].DefaultCellStyle.Format = "p";
                    dataGridView5.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView5.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

                    for (int i = 0; i < dataGridView5.RowCount; i++)
                    {
                        if (dataGridView5.Rows[i].Cells[1].Value != DBNull.Value)
                            SBVTotalSoldQty = SBVTotalSoldQty + Convert.ToInt64(dataGridView5.Rows[i].Cells[1].Value);

                        if (dataGridView5.Rows[i].Cells[2].Value != DBNull.Value)
                            SBVTotalSales = SBVTotalSales + Convert.ToDouble(dataGridView5.Rows[i].Cells[2].Value);
                    }

                    for (int i = 0; i < dataGridView5.RowCount; i++)
                    {
                        dataGridView5.Rows[i].Cells[3].Value = Convert.ToDouble(dataGridView5.Rows[i].Cells[2].Value) / SBVTotalSales;
                    }

                    if (dataGridView5.RowCount > 0)
                    {
                        dataGridView5.Rows[0].Selected = false;
                        dt5.Rows.Add("TOTAL", SBVTotalSoldQty, SBVTotalSales, SBVTotalSales / SBVTotalSales);
                        dataGridView5.DataSource = dt5;
                        dataGridView5.Rows[dataGridView5.RowCount - 1].DefaultCellStyle.BackColor = Color.BurlyWood;
                    }

                    btnSBVOk.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("CAN NOT CONNECT TO THE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parentForm.conn.Close();
                    btnSBVOk.Enabled = true;
                    return;
                }
            }
            else
            {
                /*if (parentForm.UserChecking(cmbSBVStoreCode.Text.Trim().ToUpper()) < 6)
                {
                    MessageBox.Show("You are not authorized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView5.DataSource = DBNull.Value;
                    btnSBVOk.Enabled = true;
                    return;
                }*/

                if (cmbSBVStoreCode.Text == "OH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.OHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.OHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblSBVStoreName.Text = "OXON HILL";
                }
                else if (cmbSBVStoreCode.Text == "CH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblSBVStoreName.Text = "CAPITOL HEIGHTS";
                }
                else if (cmbSBVStoreCode.Text == "WB")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WBIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WBDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblSBVStoreName.Text = "WOODBRIDGE";
                }
                else if (cmbSBVStoreCode.Text == "CV")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CVIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CVDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblSBVStoreName.Text = "CATONSVILLE";
                }
                else if (cmbSBVStoreCode.Text == "UM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.UMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.UMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblSBVStoreName.Text = "UPPER MARLBORO";
                }
                else if (cmbSBVStoreCode.Text == "WM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblSBVStoreName.Text = "WINDSOR MILL";
                }
                else if (cmbSBVStoreCode.Text == "TH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.THIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.THDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblSBVStoreName.Text = "TEMPLE HILLS";
                }
                else if (cmbSBVStoreCode.Text == "WD")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WDIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WDDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblSBVStoreName.Text = "WALDORF";
                }
                else if (cmbSBVStoreCode.Text == "PW")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.PWIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.PWDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblSBVStoreName.Text = "PRINCE WILLIAM";
                }
                else if (cmbSBVStoreCode.Text == "GB")
                {
                    newConn = new SqlConnection(parentForm.GBCS_IP);
                    lblSBVStoreName.Text = "GAITHERSBURG";
                }
                else if (cmbSBVStoreCode.Text == "BW")
                {
                    newConn = new SqlConnection(parentForm.BWCS_IP);
                    lblSBVStoreName.Text = "BOWIE";
                }

                try
                {
                    dt5.Clear();
                    SBVTotalSoldQty = 0; SBVTotalSales = 0;

                    if (cmbSBVCategory1.SelectedIndex == 0)
                    {
                        cmd.CommandText = "Sales_History_Vendor";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = newConn;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = SBVStartDate;
                        cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = SBVEndDate;
                    }
                    else
                    {
                        if (cmbSBVCategory2.SelectedIndex > 0)
                        {
                            if (cmbSBVCategory3.SelectedIndex >= 0)
                            {
                                if (cmbSBVCategory1.SelectedIndex > 5)
                                {
                                    SBVGp1 = cmbSBVCategory1.SelectedIndex + 1;
                                }
                                else
                                {
                                    SBVGp1 = cmbSBVCategory1.SelectedIndex;
                                }
                                SBVGp2 = cmbSBVCategory2.SelectedIndex;
                                SBVGp3 = cmbSBVCategory3.SelectedIndex + 1;

                                cmd.CommandText = "Sales_History_Vendor_With_Category_1_2_3";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = newConn;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = SBVGp1;
                                cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = SBVGp2;
                                cmd.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = SBVGp3;
                                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = SBVStartDate;
                                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = SBVEndDate;
                            }
                            else
                            {
                                if (cmbSBVCategory1.SelectedIndex > 5)
                                {
                                    SBVGp1 = cmbSBVCategory1.SelectedIndex + 1;
                                }
                                else
                                {
                                    SBVGp1 = cmbSBVCategory1.SelectedIndex;
                                }
                                SBVGp2 = cmbSBVCategory2.SelectedIndex;

                                cmd.CommandText = "Sales_History_Vendor_With_Category_1_2";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = newConn;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = SBVGp1;
                                cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = SBVGp2;
                                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = SBVStartDate;
                                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = SBVEndDate;
                            }
                        }
                        else
                        {
                            if (cmbSBVCategory1.SelectedIndex > 5)
                            {
                                SBVGp1 = cmbSBVCategory1.SelectedIndex + 1;
                            }
                            else
                            {
                                SBVGp1 = cmbSBVCategory1.SelectedIndex;
                            }

                            cmd.CommandText = "Sales_History_Vendor_With_Category_1";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = newConn;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = SBVGp1;
                            cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = SBVStartDate;
                            cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = SBVEndDate;
                        }
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;

                    newConn.Open();
                    adapter.Fill(dt5);
                    newConn.Close();

                    dataGridView5.RowTemplate.Height = 40;
                    dataGridView5.RowTemplate.DefaultCellStyle.Font = drvFont3;
                    dataGridView5.DataSource = dt5;
                    dataGridView5.Columns[0].HeaderText = "VENDOR";
                    //dataGridView5.Columns[0].Width = 200;
                    dataGridView5.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dataGridView5.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView5.Columns[1].HeaderText = "SOLD QTY";
                    //dataGridView5.Columns[1].Width = 100;
                    dataGridView5.Columns[1].DefaultCellStyle.FormatProvider = nfi;
                    dataGridView5.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView5.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView5.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView5.Columns[2].HeaderText = "SALES AMOUNT";
                    //dataGridView5.Columns[2].Width = 200;
                    dataGridView5.Columns[2].DefaultCellStyle.FormatProvider = nfi;
                    dataGridView5.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView5.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView5.Columns[2].DefaultCellStyle.Format = "c";
                    dataGridView5.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView5.Columns[3].HeaderText = "PERCENTAGE";
                    //dataGridView5.Columns[3].Width = 120;
                    dataGridView5.Columns[3].DefaultCellStyle.FormatProvider = nfi;
                    dataGridView5.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView5.Columns[3].DefaultCellStyle.Format = "p";
                    dataGridView5.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView5.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

                    for (int i = 0; i < dataGridView5.RowCount; i++)
                    {
                        if (dataGridView5.Rows[i].Cells[1].Value != DBNull.Value)
                            SBVTotalSoldQty = SBVTotalSoldQty + Convert.ToInt64(dataGridView5.Rows[i].Cells[1].Value);

                        if (dataGridView5.Rows[i].Cells[2].Value != DBNull.Value)
                            SBVTotalSales = SBVTotalSales + Convert.ToDouble(dataGridView5.Rows[i].Cells[2].Value);
                    }

                    for (int i = 0; i < dataGridView5.RowCount; i++)
                    {
                        dataGridView5.Rows[i].Cells[3].Value = Convert.ToDouble(dataGridView5.Rows[i].Cells[2].Value) / SBVTotalSales;
                    }

                    if (dataGridView5.RowCount > 0)
                    {
                        dataGridView5.Rows[0].Selected = false;
                        dt5.Rows.Add("TOTAL", SBVTotalSoldQty, SBVTotalSales, SBVTotalSales / SBVTotalSales);
                        dataGridView5.DataSource = dt5;
                        dataGridView5.Rows[dataGridView5.RowCount - 1].DefaultCellStyle.BackColor = Color.BurlyWood;
                    }

                    btnSBVOk.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("CAN NOT CONNECT TO THE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    newConn.Close();
                    btnSBVOk.Enabled = true;
                    return;
                }
            }
        }

        private void btnSBSOk_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParse(txtSBSStartDate.Text, out d))
            {
                SBSStartDate = txtSBSStartDate.Text.Trim();
            }
            else
            {
                MessageBox.Show("INVALID START DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSBSStartDate.SelectAll();
                txtSBSStartDate.Focus();
                return;
            }

            if (DateTime.TryParse(txtSBSEndDate.Text, out d))
            {
                SBSEndDate = txtSBSEndDate.Text.Trim();
            }
            else
            {
                MessageBox.Show("INVALID END DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSBSEndDate.SelectAll();
                txtSBSEndDate.Focus();
                return;
            }

            btnSBSOk.Enabled = false;

            if (parentForm.StoreCode == cmbSBSStoreCode.Text.ToUpper().ToString())
            {
                try
                {
                    lblSBSStoreName.Text = parentForm.storeName.ToUpper().ToString();
                    dt6.Clear();
                    SBSTotalSoldQty = 0; SBSTotalSales = 0;

                    brandBoolNum = 0; nameBoolNum = 0; totalBoolNum = 0;

                    if (cmbSBSBrand.Text == "")
                    {
                        brandBoolNum = 0;
                        ItmBrand = "1";
                    }
                    else
                    {
                        brandBoolNum = 1;
                        ItmBrand = cmbSBSBrand.Text.ToUpper();
                    }

                    if (txtSBSName.Text == "")
                    {
                        nameBoolNum = 0;
                        ItmName = "1";
                    }
                    else
                    {
                        nameBoolNum = 2;
                        ItmName = txtSBSName.Text.ToUpper();
                    }

                    totalBoolNum = brandBoolNum + nameBoolNum;

                    if (cmbSBSCategory1.SelectedIndex == 0)
                    {
                        cmd.CommandText = "Sales_History_Style";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = parentForm.conn;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@TotalBoolNum", SqlDbType.NVarChar).Value = totalBoolNum;
                        cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                        cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                        cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = SBSStartDate;
                        cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = SBSEndDate;
                    }
                    else
                    {
                        if (cmbSBSCategory2.SelectedIndex > 0)
                        {
                            if (cmbSBSCategory3.SelectedIndex >= 0)
                            {
                                if (cmbSBSCategory1.SelectedIndex > 5)
                                {
                                    SBSGp1 = cmbSBSCategory1.SelectedIndex + 1;
                                }
                                else
                                {
                                    SBSGp1 = cmbSBSCategory1.SelectedIndex;
                                }
                                SBSGp2 = cmbSBSCategory2.SelectedIndex;
                                SBSGp3 = cmbSBSCategory3.SelectedIndex + 1;

                                cmd.CommandText = "Sales_History_Style_With_Category_1_2_3";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = parentForm.conn;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@TotalBoolNum", SqlDbType.NVarChar).Value = totalBoolNum;
                                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = SBSGp1;
                                cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = SBSGp2;
                                cmd.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = SBSGp3;
                                cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                                cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = SBSStartDate;
                                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = SBSEndDate;
                            }
                            else
                            {
                                if (cmbSBSCategory1.SelectedIndex > 5)
                                {
                                    SBSGp1 = cmbSBSCategory1.SelectedIndex + 1;
                                }
                                else
                                {
                                    SBSGp1 = cmbSBSCategory1.SelectedIndex;
                                }
                                SBSGp2 = cmbSBSCategory2.SelectedIndex;

                                cmd.CommandText = "Sales_History_Style_With_Category_1_2";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = parentForm.conn;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@TotalBoolNum", SqlDbType.NVarChar).Value = totalBoolNum;
                                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = SBSGp1;
                                cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = SBSGp2;
                                cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                                cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = SBSStartDate;
                                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = SBSEndDate;
                            }
                        }
                        else
                        {
                            if (cmbSBSCategory1.SelectedIndex > 5)
                            {
                                SBSGp1 = cmbSBSCategory1.SelectedIndex + 1;
                            }
                            else
                            {
                                SBSGp1 = cmbSBSCategory1.SelectedIndex;
                            }

                            cmd.CommandText = "Sales_History_Style_With_Category_1";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = parentForm.conn;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@TotalBoolNum", SqlDbType.NVarChar).Value = totalBoolNum;
                            cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = SBSGp1;
                            cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                            cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = SBSStartDate;
                            cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = SBSEndDate;
                        }
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;

                    parentForm.conn.Open();
                    adapter.Fill(dt6);
                    parentForm.conn.Close();

                    dataGridView6.RowTemplate.Height = 40;
                    dataGridView6.RowTemplate.DefaultCellStyle.Font = drvFont3;
                    dataGridView6.DataSource = dt6;
                    dataGridView6.Columns[0].HeaderText = "BRAND";
                    //dataGridView6.Columns[0].Width = 170;
                    dataGridView6.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dataGridView6.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView6.Columns[1].HeaderText = "STYLE NAME";
                    //dataGridView6.Columns[1].Width = 300;
                    dataGridView6.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dataGridView6.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView6.Columns[2].HeaderText = "SOLD QTY";
                    //dataGridView6.Columns[2].Width = 85;
                    dataGridView6.Columns[2].DefaultCellStyle.FormatProvider = nfi;
                    dataGridView6.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView6.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView6.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView6.Columns[3].HeaderText = "SALES AMOUNT";
                    //dataGridView6.Columns[3].Width = 135;
                    dataGridView6.Columns[3].DefaultCellStyle.FormatProvider = nfi;
                    dataGridView6.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView6.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView6.Columns[3].DefaultCellStyle.Format = "c";
                    dataGridView6.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView6.Columns[4].HeaderText = "PERCENTAGE";
                    //dataGridView6.Columns[4].Width = 120;
                    dataGridView6.Columns[4].DefaultCellStyle.FormatProvider = nfi;
                    dataGridView6.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView6.Columns[4].DefaultCellStyle.Format = "p";
                    dataGridView6.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView6.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

                    if (dataGridView6.RowCount > 0)
                    {
                        for (int i = 0; i < dataGridView6.RowCount; i++)
                        {
                            if (dataGridView6.Rows[i].Cells[2].Value != DBNull.Value)
                                SBSTotalSoldQty = SBSTotalSoldQty + Convert.ToInt64(dataGridView6.Rows[i].Cells[2].Value);

                            if (dataGridView6.Rows[i].Cells[3].Value != DBNull.Value)
                                SBSTotalSales = SBSTotalSales + Convert.ToDouble(dataGridView6.Rows[i].Cells[3].Value);
                        }

                        for (int i = 0; i < dataGridView6.RowCount; i++)
                        {
                            dataGridView6.Rows[i].Cells[4].Value = Convert.ToDouble(dataGridView6.Rows[i].Cells[3].Value) / SBSTotalSales;
                        }

                        dt6.Rows.Add("TOTAL", "", SBSTotalSoldQty, SBSTotalSales, SBSTotalSales / SBSTotalSales);
                        dataGridView6.DataSource = dt6;
                        dataGridView6.Rows[dataGridView6.RowCount - 1].DefaultCellStyle.BackColor = Color.BurlyWood;

                        if (dataGridView6.RowCount > 0)
                            dataGridView6.Rows[0].Selected = false;
                    }

                    btnSBSOk.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("CAN NOT CONNECT TO THE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parentForm.conn.Close();
                    btnSBSOk.Enabled = true;
                    return;
                }
            }
            else
            {
                /*if (parentForm.UserChecking(cmbSBSStoreCode.Text.Trim().ToUpper()) < 6)
                {
                    MessageBox.Show("You are not authorized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView6.DataSource = DBNull.Value;
                    btnSBSOk.Enabled = true;
                    return;
                }*/

                if (cmbSBSStoreCode.Text == "OH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.OHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.OHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblSBSStoreName.Text = "OXON HILL";
                }
                else if (cmbSBSStoreCode.Text == "CH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblSBSStoreName.Text = "CAPITOL HEIGHTS";
                }
                else if (cmbSBSStoreCode.Text == "WB")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WBIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WBDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblSBSStoreName.Text = "WOODBRIDGE";
                }
                else if (cmbSBSStoreCode.Text == "CV")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CVIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CVDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblSBSStoreName.Text = "CATONSVILLE";
                }
                else if (cmbSBSStoreCode.Text == "UM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.UMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.UMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblSBSStoreName.Text = "UPPER MARLBORO";
                }
                else if (cmbSBSStoreCode.Text == "WM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblSBSStoreName.Text = "WINDSOR MILL";
                }
                else if (cmbSBSStoreCode.Text == "TH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.THIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.THDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblSBSStoreName.Text = "TEMPLE HILLS";
                }
                else if (cmbSBSStoreCode.Text == "WD")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WDIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WDDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblSBSStoreName.Text = "WALDORF";
                }
                else if (cmbSBSStoreCode.Text == "PW")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.PWIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.PWDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    lblSBSStoreName.Text = "PRINCE WILLIAM";
                }
                else if (cmbSBSStoreCode.Text == "GB")
                {
                    newConn = new SqlConnection(parentForm.GBCS_IP);
                    lblSBSStoreName.Text = "GAITHERSBURG";
                }
                else if (cmbSBSStoreCode.Text == "BW")
                {
                    newConn = new SqlConnection(parentForm.BWCS_IP);
                    lblSBSStoreName.Text = "BOWIE";
                }

                try
                {
                    dt6.Clear();
                    SBSTotalSoldQty = 0; SBSTotalSales = 0;

                    brandBoolNum = 0; nameBoolNum = 0; totalBoolNum = 0;

                    if (cmbSBSBrand.Text == "")
                    {
                        brandBoolNum = 0;
                        ItmBrand = "1";
                    }
                    else
                    {
                        brandBoolNum = 1;
                        ItmBrand = cmbSBSBrand.Text.ToUpper();
                    }

                    if (txtSBSName.Text == "")
                    {
                        nameBoolNum = 0;
                        ItmName = "1";
                    }
                    else
                    {
                        nameBoolNum = 2;
                        ItmName = txtSBSName.Text.ToUpper();
                    }

                    totalBoolNum = brandBoolNum + nameBoolNum;

                    if (cmbSBSCategory1.SelectedIndex == 0)
                    {
                        cmd.CommandText = "Sales_History_Style";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = newConn;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@TotalBoolNum", SqlDbType.NVarChar).Value = totalBoolNum;
                        cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                        cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                        cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = SBSStartDate;
                        cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = SBSEndDate;
                    }
                    else
                    {
                        if (cmbSBSCategory2.SelectedIndex > 0)
                        {
                            if (cmbSBSCategory3.SelectedIndex >= 0)
                            {
                                if (cmbSBSCategory1.SelectedIndex > 5)
                                {
                                    SBSGp1 = cmbSBSCategory1.SelectedIndex + 1;
                                }
                                else
                                {
                                    SBSGp1 = cmbSBSCategory1.SelectedIndex;
                                }
                                SBSGp2 = cmbSBSCategory2.SelectedIndex;
                                SBSGp3 = cmbSBSCategory3.SelectedIndex + 1;

                                cmd.CommandText = "Sales_History_Style_With_Category_1_2_3";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = newConn;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@TotalBoolNum", SqlDbType.NVarChar).Value = totalBoolNum;
                                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = SBSGp1;
                                cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = SBSGp2;
                                cmd.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = SBSGp3;
                                cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                                cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = SBSStartDate;
                                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = SBSEndDate;
                            }
                            else
                            {
                                if (cmbSBSCategory1.SelectedIndex > 5)
                                {
                                    SBSGp1 = cmbSBSCategory1.SelectedIndex + 1;
                                }
                                else
                                {
                                    SBSGp1 = cmbSBSCategory1.SelectedIndex;
                                }
                                SBSGp2 = cmbSBSCategory2.SelectedIndex;

                                cmd.CommandText = "Sales_History_Style_With_Category_1_2";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = newConn;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@TotalBoolNum", SqlDbType.NVarChar).Value = totalBoolNum;
                                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = SBSGp1;
                                cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = SBSGp2;
                                cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                                cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = SBSStartDate;
                                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = SBSEndDate;
                            }
                        }
                        else
                        {
                            if (cmbSBSCategory1.SelectedIndex > 5)
                            {
                                SBSGp1 = cmbSBSCategory1.SelectedIndex + 1;
                            }
                            else
                            {
                                SBSGp1 = cmbSBSCategory1.SelectedIndex;
                            }

                            cmd.CommandText = "Sales_History_Style_With_Category_1";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = newConn;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@TotalBoolNum", SqlDbType.NVarChar).Value = totalBoolNum;
                            cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = SBSGp1;
                            cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                            cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = SBSStartDate;
                            cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = SBSEndDate;
                        }
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;

                    newConn.Open();
                    adapter.Fill(dt6);
                    newConn.Close();

                    dataGridView6.RowTemplate.Height = 40;
                    dataGridView6.RowTemplate.DefaultCellStyle.Font = drvFont3;
                    dataGridView6.DataSource = dt6;
                    dataGridView6.Columns[0].HeaderText = "BRAND";
                    //dataGridView6.Columns[0].Width = 170;
                    dataGridView6.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dataGridView6.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView6.Columns[1].HeaderText = "STYLE NAME";
                    //dataGridView6.Columns[1].Width = 300;
                    dataGridView6.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dataGridView6.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView6.Columns[2].HeaderText = "SOLD QTY";
                    //dataGridView6.Columns[2].Width = 85;
                    dataGridView6.Columns[2].DefaultCellStyle.FormatProvider = nfi;
                    dataGridView6.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView6.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView6.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView6.Columns[3].HeaderText = "SALES AMOUNT";
                    //dataGridView6.Columns[3].Width = 135;
                    dataGridView6.Columns[3].DefaultCellStyle.FormatProvider = nfi;
                    dataGridView6.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView6.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView6.Columns[3].DefaultCellStyle.Format = "c";
                    dataGridView6.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView6.Columns[4].HeaderText = "PERCENTAGE";
                    //dataGridView6.Columns[4].Width = 120;
                    dataGridView6.Columns[4].DefaultCellStyle.FormatProvider = nfi;
                    dataGridView6.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView6.Columns[4].DefaultCellStyle.Format = "p";
                    dataGridView6.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView6.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

                    if (dataGridView6.RowCount > 0)
                    {
                        for (int i = 0; i < dataGridView6.RowCount; i++)
                        {
                            if (dataGridView6.Rows[i].Cells[2].Value != DBNull.Value)
                                SBSTotalSoldQty = SBSTotalSoldQty + Convert.ToInt64(dataGridView6.Rows[i].Cells[2].Value);

                            if (dataGridView6.Rows[i].Cells[3].Value != DBNull.Value)
                                SBSTotalSales = SBSTotalSales + Convert.ToDouble(dataGridView6.Rows[i].Cells[3].Value);
                        }

                        for (int i = 0; i < dataGridView6.RowCount; i++)
                        {
                            dataGridView6.Rows[i].Cells[4].Value = Convert.ToDouble(dataGridView6.Rows[i].Cells[3].Value) / SBSTotalSales;
                        }

                        dt6.Rows.Add("TOTAL", "", SBSTotalSoldQty, SBSTotalSales, SBSTotalSales / SBSTotalSales);
                        dataGridView6.DataSource = dt6;
                        dataGridView6.Rows[dataGridView6.RowCount - 1].DefaultCellStyle.BackColor = Color.BurlyWood;

                        if (dataGridView6.RowCount > 0)
                            dataGridView6.Rows[0].Selected = false;
                    }

                    btnSBSOk.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("CAN NOT CONNECT TO THE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    newConn.Close();
                    btnSBSOk.Enabled = true;
                    return;
                }
            }
        }

        private void btnSBSReset_Click(object sender, EventArgs e)
        {
            dataGridView6.DataSource = null;
            cmbSBSCategory2.DataSource = null;
            cmbSBSCategory2.Items.Clear();
            cmbSBSCategory3.DataSource = null;
            cmbSBSCategory3.Items.Clear();

            SqlCommand cmd_CmbCategory1 = new SqlCommand("Get_Category_Group1", parentForm.conn);
            cmd_CmbCategory1.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd_CmbCategory1;

            parentForm.conn.Open();
            adapt.Fill(ds);
            parentForm.conn.Close();

            cmbSBSCategory1.DataSource = ds.Tables[0].DefaultView;
            cmbSBSCategory1.ValueMember = "ItmGp_Desc";
            cmbSBSCategory1.DisplayMember = "ItmGp_Desc";
        }

        private void btnSBSClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSBSStartDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar11.Visible = true;
        }

        private void txtSBSEndDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar12.Visible = true;
        }

        private void monthCalendar11_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtSBSStartDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar11.SelectionStart));
            monthCalendar11.Visible = false;
        }

        private void monthCalendar12_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtSBSEndDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar12.SelectionStart));
            monthCalendar12.Visible = false;
        }

        private void cmbSBSCategory1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSBSCategory1.SelectedIndex == 0 | cmbSBSCategory1.SelectedIndex > 6)
            {
                cmbSBSCategory2.DataSource = null;
                cmbSBSCategory2.Items.Clear();
                cmbSBSCategory3.DataSource = null;
                cmbSBSCategory3.Items.Clear();
                return;
            }

            SqlCommand cmd_CmbCategory2 = new SqlCommand("Get_Category_Group2", parentForm.conn);
            cmd_CmbCategory2.CommandType = CommandType.StoredProcedure;
            cmd_CmbCategory2.Parameters.Add("@ItmGp_Parents", SqlDbType.Int).Value = cmbSBSCategory1.SelectedIndex;
            DataSet ds = new DataSet();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd_CmbCategory2;

            parentForm.conn.Open();
            adapt.Fill(ds);
            parentForm.conn.Close();

            cmbSBSCategory2.DataSource = ds.Tables[0].DefaultView;
            cmbSBSCategory2.ValueMember = "ItmGp_Desc";
            cmbSBSCategory2.DisplayMember = "ItmGp_Desc";

            ds.Tables.Clear();
        }

        private void cmbSBSCategory2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSBSCategory3.DataSource = null;
            cmbSBSCategory3.Items.Clear();

            index1 = cmbSBSCategory1.SelectedIndex;
            index2 = cmbSBSCategory2.SelectedIndex;

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

                    cmbSBSCategory3.DataSource = ds.Tables[0].DefaultView;
                    cmbSBSCategory3.ValueMember = "ItmGp_Desc";
                    cmbSBSCategory3.DisplayMember = "ItmGp_Desc";
                    break;
                default:
                    cmd_CmbCategory3.Parameters.Add("@ItmGp_Parents", SqlDbType.Int).Value = index1;
                    cmd_CmbCategory3.Parameters.Add("@ItmGp_Parents2", SqlDbType.Int).Value = index2;
                    adapt.SelectCommand = cmd_CmbCategory3;

                    parentForm.conn.Open();
                    adapt.Fill(ds);
                    parentForm.conn.Close();

                    cmbSBSCategory3.DataSource = ds.Tables[0].DefaultView;
                    cmbSBSCategory3.ValueMember = "ItmGp_Desc";
                    cmbSBSCategory3.DisplayMember = "ItmGp_Desc";
                    break;
            }
        }

        private void btnSBSBrand_Click(object sender, EventArgs e)
        {
            cmd_Brand = new SqlCommand("Get_BrandName", parentForm.conn);
            cmd_Brand.CommandType = CommandType.StoredProcedure;
            cmd_Brand.Parameters.Clear();
            DataSet ds_Brand = new DataSet();
            SqlDataAdapter adapt_Brand = new SqlDataAdapter();
            adapt_Brand.SelectCommand = cmd_Brand;

            parentForm.conn.Open();
            adapt_Brand.Fill(ds_Brand);
            parentForm.conn.Close();

            cmbSBSBrand.DataSource = ds_Brand.Tables[0].DefaultView;
            cmbSBSBrand.ValueMember = "BrandName";
            cmbSBSBrand.DisplayMember = "BrandName";
        }

        private void btnSBSExcel_Click(object sender, EventArgs e)
        {
            if (parentForm.employeeID.ToUpper() == "ADMIN" | parentForm.specialCode == parentForm.txtSpecialCode.Text.Trim().ToString().ToUpper())
            {
                if (dataGridView6.RowCount > 0)
                {
                    this.Enabled = false;

                    Excel_12.Application ReportFile;
                    Excel_12._Workbook WorkBook;
                    Excel_12._Worksheet WorkSheet;
                    //Excel_12.Range Range;

                    string MaxRow = Convert.ToString(dt6.Rows.Count + 1);
                    String MaxColumn = ((String)(Convert.ToChar(dt6.Columns.Count / 26 + 64).ToString() + Convert.ToChar(dt6.Columns.Count % 26 + 64))).Replace('@', ' ').Trim();
                    String MaxCell = MaxColumn + MaxRow;

                    ReportFile = new Excel_12.Application();
                    ReportFile.Visible = false;

                    WorkBook = (Excel_12._Workbook)(ReportFile.Workbooks.Add("workbook"));
                    WorkSheet = (Excel_12._Worksheet)WorkBook.ActiveSheet;

                    for (int i = 0; i < dt6.Columns.Count; i++)
                        WorkSheet.Cells[1, i + 1] = dt6.Columns[i].ColumnName;

                    string[,] Values = new string[dt6.Rows.Count, dt6.Columns.Count];

                    for (int i = 0; i < dt6.Rows.Count; i++)
                        for (int j = 0; j < dt6.Columns.Count; j++)
                        {

                            Values[i, j] = dt6.Rows[i][j].ToString();

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
                if (dataGridView6.RowCount > 0)
                {
                    ExportDataGridViewTo_Excel12(dataGridView6);
                }
                else
                {
                    MessageBox.Show("NO DATA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnSBVReset_Click(object sender, EventArgs e)
        {
            dataGridView5.DataSource = null;
            cmbSBVCategory2.DataSource = null;
            cmbSBVCategory2.Items.Clear();
            cmbSBVCategory3.DataSource = null;
            cmbSBVCategory3.Items.Clear();

            SqlCommand cmd_CmbCategory1 = new SqlCommand("Get_Category_Group1", parentForm.conn);
            cmd_CmbCategory1.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd_CmbCategory1;

            parentForm.conn.Open();
            adapt.Fill(ds);
            parentForm.conn.Close();

            cmbSBVCategory1.DataSource = ds.Tables[0].DefaultView;
            cmbSBVCategory1.ValueMember = "ItmGp_Desc";
            cmbSBVCategory1.DisplayMember = "ItmGp_Desc";
        }

        private void btnSBVClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSBVStartDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar9.Visible = true;
        }

        private void txtSBVEndDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar10.Visible = true;
        }

        private void monthCalendar9_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtSBVStartDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar9.SelectionStart));
            monthCalendar9.Visible = false;
        }

        private void monthCalendar10_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtSBVEndDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar10.SelectionStart));
            monthCalendar10.Visible = false;
        }

        private void cmbSBVCategory1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSBVCategory1.SelectedIndex == 0 | cmbSBVCategory1.SelectedIndex > 6)
            {
                cmbSBVCategory2.DataSource = null;
                cmbSBVCategory2.Items.Clear();
                cmbSBVCategory3.DataSource = null;
                cmbSBVCategory3.Items.Clear();
                return;
            }

            SqlCommand cmd_CmbCategory2 = new SqlCommand("Get_Category_Group2", parentForm.conn);
            cmd_CmbCategory2.CommandType = CommandType.StoredProcedure;
            cmd_CmbCategory2.Parameters.Add("@ItmGp_Parents", SqlDbType.Int).Value = cmbSBVCategory1.SelectedIndex;
            DataSet ds = new DataSet();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd_CmbCategory2;

            parentForm.conn.Open();
            adapt.Fill(ds);
            parentForm.conn.Close();

            cmbSBVCategory2.DataSource = ds.Tables[0].DefaultView;
            cmbSBVCategory2.ValueMember = "ItmGp_Desc";
            cmbSBVCategory2.DisplayMember = "ItmGp_Desc";

            ds.Tables.Clear();
        }

        private void cmbSBVCategory2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSBVCategory3.DataSource = null;
            cmbSBVCategory3.Items.Clear();

            index1 = cmbSBVCategory1.SelectedIndex;
            index2 = cmbSBVCategory2.SelectedIndex;

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

                    cmbSBVCategory3.DataSource = ds.Tables[0].DefaultView;
                    cmbSBVCategory3.ValueMember = "ItmGp_Desc";
                    cmbSBVCategory3.DisplayMember = "ItmGp_Desc";
                    break;
                default:
                    cmd_CmbCategory3.Parameters.Add("@ItmGp_Parents", SqlDbType.Int).Value = index1;
                    cmd_CmbCategory3.Parameters.Add("@ItmGp_Parents2", SqlDbType.Int).Value = index2;
                    adapt.SelectCommand = cmd_CmbCategory3;

                    parentForm.conn.Open();
                    adapt.Fill(ds);
                    parentForm.conn.Close();

                    cmbSBVCategory3.DataSource = ds.Tables[0].DefaultView;
                    cmbSBVCategory3.ValueMember = "ItmGp_Desc";
                    cmbSBVCategory3.DisplayMember = "ItmGp_Desc";
                    break;
            }
        }

        private void dataGridView5_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (parentForm.userLevel >= parentForm.SectionManagerLV)
                {
                    VendorDetailSales vendorDetailSalesForm = new VendorDetailSales(dataGridView5.SelectedCells[0].Value.ToString(), Convert.ToDouble(dataGridView5.SelectedCells[2].Value));
                    vendorDetailSalesForm.parentForm1 = this.parentForm;
                    vendorDetailSalesForm.parentForm2 = this;
                    vendorDetailSalesForm.Show();
                }
                else
                {
                    MessageBox.Show("NOT AUTHORIZED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch
            {
                return;
            }
        }

        private void btnSBVExcel_Click(object sender, EventArgs e)
        {
            if (parentForm.employeeID.ToUpper() == "ADMIN" | parentForm.specialCode == parentForm.txtSpecialCode.Text.Trim().ToString().ToUpper())
            {
                if (dataGridView5.RowCount > 0)
                {
                    this.Enabled = false;

                    Excel_12.Application ReportFile;
                    Excel_12._Workbook WorkBook;
                    Excel_12._Worksheet WorkSheet;
                    //Excel_12.Range Range;

                    string MaxRow = Convert.ToString(dt5.Rows.Count + 1);
                    String MaxColumn = ((String)(Convert.ToChar(dt5.Columns.Count / 26 + 64).ToString() + Convert.ToChar(dt5.Columns.Count % 26 + 64))).Replace('@', ' ').Trim();
                    String MaxCell = MaxColumn + MaxRow;

                    ReportFile = new Excel_12.Application();
                    ReportFile.Visible = false;

                    WorkBook = (Excel_12._Workbook)(ReportFile.Workbooks.Add("workbook"));
                    WorkSheet = (Excel_12._Worksheet)WorkBook.ActiveSheet;

                    for (int i = 0; i < dt5.Columns.Count; i++)
                        WorkSheet.Cells[1, i + 1] = dt5.Columns[i].ColumnName;

                    string[,] Values = new string[dt5.Rows.Count, dt5.Columns.Count];

                    for (int i = 0; i < dt5.Rows.Count; i++)
                        for (int j = 0; j < dt5.Columns.Count; j++)
                        {

                            Values[i, j] = dt5.Rows[i][j].ToString();

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
                if (dataGridView5.RowCount > 0)
                {
                    ExportDataGridViewTo_Excel12(dataGridView5);
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