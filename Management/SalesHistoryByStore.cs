using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;


namespace Management
{
    public partial class SalesHistoryByStore : Form
    {
        public LogInManagements parentForm;
        SqlConnection connOH;
        SqlConnection connCH;
        SqlConnection connWB;
        SqlConnection connCV;
        SqlConnection connUM;
        SqlConnection connWM;
        SqlConnection connTH;
        SqlConnection connWD;
        SqlConnection connPW;
        SqlConnection connGB;
        SqlConnection connBW;
        SqlCommand cmd = new SqlCommand();
        public DataTable dt = new DataTable();
        public DataTable dt2_All = new DataTable();
        public DataTable dt3 = new DataTable();

        public Font drvFont = new Font("Arial", 9, FontStyle.Bold);
        NumberFormatInfo nfi = new NumberFormatInfo();

        public string startDate, endDate;

        double OHwigPonyTailSales = 0, OHhairSales = 0, OHhairCareSales = 0, OHstylingSalonSuppliesSales = 0, OHskinCosmeticNailFootSales = 0, OHgeneralMerchandiseSales = 0;
        double OHpointRedeemed = 0;
        double OHnetSales = 0, OHtax = 0, OHgrossSales = 0;
        Int64 OHnumOfTrans = 0;
        //double OHaverageNetSales = 0, OHaverageGrossSales = 0;

        double CHwigPonyTailSales = 0, CHhairSales = 0, CHhairCareSales = 0, CHstylingSalonSuppliesSales = 0, CHskinCosmeticNailFootSales = 0, CHgeneralMerchandiseSales = 0;
        double CHpointRedeemed = 0;
        double CHnetSales = 0, CHtax = 0, CHgrossSales = 0;
        Int64 CHnumOfTrans = 0;
        //double CHaverageNetSales = 0, CHaverageGrossSales = 0;

        double UMwigPonyTailSales = 0, UMhairSales = 0, UMhairCareSales = 0, UMstylingSalonSuppliesSales = 0, UMskinCosmeticNailFootSales = 0, UMgeneralMerchandiseSales = 0;
        double UMpointRedeemed = 0;
        double UMnetSales = 0, UMtax = 0, UMgrossSales = 0;
        Int64 UMnumOfTrans = 0;
        //double UMaverageNetSales = 0, UMaverageGrossSales = 0;

        double WMwigPonyTailSales = 0, WMhairSales = 0, WMhairCareSales = 0, WMstylingSalonSuppliesSales = 0, WMskinCosmeticNailFootSales = 0, WMgeneralMerchandiseSales = 0;
        double WMpointRedeemed = 0;
        double WMnetSales = 0, WMtax = 0, WMgrossSales = 0;
        Int64 WMnumOfTrans = 0;
        //double WMaverageNetSales = 0, WMaverageGrossSales = 0;

        double CVwigPonyTailSales = 0, CVhairSales = 0, CVhairCareSales = 0, CVstylingSalonSuppliesSales = 0, CVskinCosmeticNailFootSales = 0, CVgeneralMerchandiseSales = 0;
        double CVpointRedeemed = 0;
        double CVnetSales = 0, CVtax = 0, CVgrossSales = 0;
        Int64 CVnumOfTrans = 0;
        //double CVaverageNetSales = 0, CVaverageGrossSales = 0;

        double WBwigPonyTailSales = 0, WBhairSales = 0, WBhairCareSales = 0, WBstylingSalonSuppliesSales = 0, WBskinCosmeticNailFootSales = 0, WBgeneralMerchandiseSales = 0;
        double WBpointRedeemed = 0;
        double WBnetSales = 0, WBtax = 0, WBgrossSales = 0;
        Int64 WBnumOfTrans = 0;
        //double WBaverageNetSales = 0, WBaverageGrossSales = 0;

        double THwigPonyTailSales = 0, THhairSales = 0, THhairCareSales = 0, THstylingSalonSuppliesSales = 0, THskinCosmeticNailFootSales = 0, THgeneralMerchandiseSales = 0;
        double THpointRedeemed = 0;
        double THnetSales = 0, THtax = 0, THgrossSales = 0;
        Int64 THnumOfTrans = 0;
        //double THaverageNetSales = 0, THaverageGrossSales = 0;

        double WDwigPonyTailSales = 0, WDhairSales = 0, WDhairCareSales = 0, WDstylingSalonSuppliesSales = 0, WDskinCosmeticNailFootSales = 0, WDgeneralMerchandiseSales = 0;
        double WDpointRedeemed = 0;
        double WDnetSales = 0, WDtax = 0, WDgrossSales = 0;
        Int64 WDnumOfTrans = 0;
        //double WDaverageNetSales = 0, WDaverageGrossSales = 0;

        double PWwigPonyTailSales = 0, PWhairSales = 0, PWhairCareSales = 0, PWstylingSalonSuppliesSales = 0, PWskinCosmeticNailFootSales = 0, PWgeneralMerchandiseSales = 0;
        double PWpointRedeemed = 0;
        double PWnetSales = 0, PWtax = 0, PWgrossSales = 0;
        Int64 PWnumOfTrans = 0;
        //double PWaverageNetSales = 0, PWaverageGrossSales = 0;

        double GBwigPonyTailSales = 0, GBhairSales = 0, GBhairCareSales = 0, GBstylingSalonSuppliesSales = 0, GBskinCosmeticNailFootSales = 0, GBgeneralMerchandiseSales = 0;
        double GBpointRedeemed = 0;
        double GBnetSales = 0, GBtax = 0, GBgrossSales = 0;
        Int64 GBnumOfTrans = 0;
        //double GBaverageNetSales = 0, GBaverageGrossSales = 0;

        double BWwigPonyTailSales = 0, BWhairSales = 0, BWhairCareSales = 0, BWstylingSalonSuppliesSales = 0, BWskinCosmeticNailFootSales = 0, BWgeneralMerchandiseSales = 0;
        double BWpointRedeemed = 0;
        double BWnetSales = 0, BWtax = 0, BWgrossSales = 0;
        Int64 BWnumOfTrans = 0;
        //double BWaverageNetSales = 0, BWaverageGrossSales = 0;

        double SUMwigPonyTailSales = 0, SUMhairSales = 0, SUMhairCareSales = 0, SUMstylingSalonSuppliesSales = 0, SUMskinCosmeticNailFootSales = 0, SUMgeneralMerchandiseSales = 0;
        double SUMpointRedeemed = 0;
        double SUMnetSales = 0, SUMtax = 0, SUMgrossSales = 0;
        Int64 SUMnumOfTrans = 0;
        //double SUMaverageNetSales = 0, SUMaverageGrossSales = 0;

        DateTime hour;
        string sHour;
        double[] OHHoulySales = new double[15];
        double[] CHHoulySales = new double[15];
        double[] WBHoulySales = new double[15];
        double[] CVHoulySales = new double[15];
        double[] UMHoulySales = new double[15];
        double[] WMHoulySales = new double[15];
        double[] THHoulySales = new double[15];
        double[] WDHoulySales = new double[15];
        double[] PWHoulySales = new double[15];
        double[] GBHoulySales = new double[15];
        double[] BWHoulySales = new double[15];
        double OHhoulySalesTotal = 0, CHhoulySalesTotal = 0, WBhoulySalesTotal = 0, CVhoulySalesTotal = 0, UMhoulySalesTotal = 0,
               WMhoulySalesTotal = 0, THhoulySalesTotal = 0, WDhoulySalesTotal = 0, PWhoulySalesTotal = 0, GBhoulySalesTotal = 0,
               BWhoulySalesTotal = 0;

        int days = 0;
        double[] OHDailySales = new double[31];
        int[] OHNumOfTrns = new int[31];
        double[] OHAveDailySales = new double[31];
        double[] CHDailySales = new double[31];
        int[] CHNumOfTrns = new int[31];
        double[] CHAveDailySales = new double[31];
        double[] WBDailySales = new double[31];
        int[] WBNumOfTrns = new int[31];
        double[] WBAveDailySales = new double[31];
        double[] CVDailySales = new double[31];
        int[] CVNumOfTrns = new int[31];
        double[] CVAveDailySales = new double[31];
        double[] UMDailySales = new double[31];
        int[] UMNumOfTrns = new int[31];
        double[] UMAveDailySales = new double[31];
        double[] WMDailySales = new double[31];
        int[] WMNumOfTrns = new int[31];
        double[] WMAveDailySales = new double[31];
        double[] THDailySales = new double[31];
        int[] THNumOfTrns = new int[31];
        double[] THAveDailySales = new double[31];
        double[] WDDailySales = new double[31];
        int[] WDNumOfTrns = new int[31];
        double[] WDAveDailySales = new double[31];
        double[] PWDailySales = new double[31];
        int[] PWNumOfTrns = new int[31];
        double[] PWAveDailySales = new double[31];
        double[] GBDailySales = new double[31];
        int[] GBNumOfTrns = new int[31];
        double[] GBAveDailySales = new double[31];
        double[] BWDailySales = new double[31];
        int[] BWNumOfTrns = new int[31];
        double[] BWAveDailySales = new double[31];

        double OHDailySalesTotal = 0;
        double CHDailySalesTotal = 0;
        double WBDailySalesTotal = 0;
        double CVDailySalesTotal = 0;
        double UMDailySalesTotal = 0;
        double WMDailySalesTotal = 0;
        double THDailySalesTotal = 0;
        double WDDailySalesTotal = 0;
        double PWDailySalesTotal = 0;
        double GBDailySalesTotal = 0;
        double BWDailySalesTotal = 0;
        Int64 OHNumOfTransTotal = 0;
        Int64 CHNumOfTransTotal = 0;
        Int64 WBNumOfTransTotal = 0;
        Int64 CVNumOfTransTotal = 0;
        Int64 UMNumOfTransTotal = 0;
        Int64 WMNumOfTransTotal = 0;
        Int64 THNumOfTransTotal = 0;
        Int64 WDNumOfTransTotal = 0;
        Int64 PWNumOfTransTotal = 0;
        Int64 GBNumOfTransTotal = 0;
        Int64 BWNumOfTransTotal = 0;
        double OHAveDailySalesTotal = 0;
        double CHAveDailySalesTotal = 0;
        double WBAveDailySalesTotal = 0;
        double CVAveDailySalesTotal = 0;
        double UMAveDailySalesTotal = 0;
        double WMAveDailySalesTotal = 0;
        double THAveDailySalesTotal = 0;
        double WDAveDailySalesTotal = 0;
        double PWAveDailySalesTotal = 0;
        double GBAveDailySalesTotal = 0;
        double BWAveDailySalesTotal = 0;

        double[] SUMDailySales = new double[31];
        Int64[] SUMNumOfTrns = new long[31];
        double[] SUMAveDailySales = new double[31];
        double SUMDailySalesTotal = 0;
        Int64 SUMNumOfTrnsTotal = 0;
        double SUMAveDailySalesTotal = 0;

        public SalesHistoryByStore()
        {
            InitializeComponent();
        }

        private void SalesByStore_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;

            connOH = new SqlConnection("Data Source=" + parentForm.OHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.OHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
            connCH = new SqlConnection("Data Source=" + parentForm.CHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
            connWB = new SqlConnection("Data Source=" + parentForm.WBIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WBDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
            connCV = new SqlConnection("Data Source=" + parentForm.CVIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CVDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
            connUM = new SqlConnection("Data Source=" + parentForm.UMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.UMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
            connWM = new SqlConnection("Data Source=" + parentForm.WMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
            connTH = new SqlConnection("Data Source=" + parentForm.THIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.THDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
            connWD = new SqlConnection("Data Source=" + parentForm.WDIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WDDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
            connPW = new SqlConnection("Data Source=" + parentForm.PWIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.PWDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
            connGB = new SqlConnection(parentForm.GBCS_IP);
            connBW = new SqlConnection(parentForm.BWCS_IP);

            nfi.CurrencySymbol = Application.CurrentCulture.NumberFormat.CurrencySymbol;
            nfi.CurrencyNegativePattern = 1;

            cmbOption.SelectedIndex = 0;

            /*dt.Columns.Add("CATEGORY", typeof(string));
            dt.Columns.Add("OXON HILL", typeof(string));
            dt.Columns.Add("CAPITOL HEIGHTS", typeof(string));
            dt.Columns.Add("UPPER MARLBORO", typeof(string));
            dt.Columns.Add("WINDSOR MILL", typeof(string));
            dt.Columns.Add("CATONSVILLE", typeof(string));
            dt.Columns.Add("WOODBRIDGE", typeof(string));
            dt.Columns.Add("SUM", typeof(string));

            dt2_All.Columns.Add("HOUR", typeof(string));
            dt2_All.Columns.Add("OXON HILL", typeof(string));
            dt2_All.Columns.Add("CAPITOL HEIGHTS", typeof(string));
            dt2_All.Columns.Add("UPPER MARLBORO", typeof(string));
            dt2_All.Columns.Add("WINDSOR MILL", typeof(string));
            dt2_All.Columns.Add("CATONSVILLE", typeof(string));
            dt2_All.Columns.Add("WOODBRIDGE", typeof(string));
            dt2_All.Columns.Add("SUM", typeof(string));

            dt3.Columns.Add("DATE", typeof(string));
            dt3.Columns.Add("OXON HILL", typeof(string));
            dt3.Columns.Add("CAPITOL HEIGHTS", typeof(string));
            dt3.Columns.Add("UPPER MARLBORO", typeof(string));
            dt3.Columns.Add("WINDSOR MILL", typeof(string));
            dt3.Columns.Add("CATONSVILLE", typeof(string));
            dt3.Columns.Add("WOODBRIDGE", typeof(string));
            dt3.Columns.Add("SUM", typeof(string));*/

            dt.Columns.Add("CATEGORY", typeof(string));
            dt.Columns.Add("TEMPLE HILLS", typeof(string));
            dt.Columns.Add("OXON HILL", typeof(string));
            dt.Columns.Add("UPPER MARLBORO", typeof(string));
            dt.Columns.Add("CAPITOL HEIGHTS", typeof(string));
            dt.Columns.Add("WINDSOR MILL", typeof(string));
            dt.Columns.Add("CATONSVILLE", typeof(string));
            dt.Columns.Add("GAITHERSBURG", typeof(string));
            dt.Columns.Add("PRINCE WILLIAM", typeof(string));
            dt.Columns.Add("WOODBRIDGE", typeof(string));
            dt.Columns.Add("WALDORF", typeof(string));
            dt.Columns.Add("BOWIE", typeof(string));
            dt.Columns.Add("SUM", typeof(string));

            dt2_All.Columns.Add("HOUR", typeof(string));
            dt2_All.Columns.Add("TEMPLE HILLS", typeof(string));
            dt2_All.Columns.Add("OXON HILL", typeof(string));
            dt2_All.Columns.Add("UPPER MARLBORO", typeof(string));
            dt2_All.Columns.Add("CAPITOL HEIGHTS", typeof(string));
            dt2_All.Columns.Add("WINDSOR MILL", typeof(string));
            dt2_All.Columns.Add("CATONSVILLE", typeof(string));
            dt2_All.Columns.Add("GAITHERSBURG", typeof(string));
            dt2_All.Columns.Add("PRINCE WILLIAM", typeof(string));
            dt2_All.Columns.Add("WOODBRIDGE", typeof(string));
            dt2_All.Columns.Add("WALDORF", typeof(string));
            dt2_All.Columns.Add("BOWIE", typeof(string));
            dt2_All.Columns.Add("SUM", typeof(string));

            dt3.Columns.Add("DATE", typeof(string));
            dt3.Columns.Add("TEMPLE HILLS", typeof(string));
            dt3.Columns.Add("OXON HILL", typeof(string));
            dt3.Columns.Add("UPPER MARLBORO", typeof(string));
            dt3.Columns.Add("CAPITOL HEIGHTS", typeof(string));
            dt3.Columns.Add("WINDSOR MILL", typeof(string));
            dt3.Columns.Add("CATONSVILLE", typeof(string));
            dt3.Columns.Add("GAITHERSBURG", typeof(string));
            dt3.Columns.Add("PRINCE WILLIAM", typeof(string));
            dt3.Columns.Add("WOODBRIDGE", typeof(string));
            dt3.Columns.Add("WALDORF", typeof(string));
            dt3.Columns.Add("BOWIE", typeof(string));
            dt3.Columns.Add("SUM", typeof(string));

            dataGridView1.ColumnHeadersHeight = 45;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);

            dataGridView2.ColumnHeadersHeight = 45;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);

            dataGridView3.ColumnHeadersHeight = 45;
            dataGridView3.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);

            txtStartDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            txtEndDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

            btnOK.Select();
            btnOK.Focus();
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cmbOption.SelectedIndex == 0)
            {
                startDate = txtStartDate.Text.Trim();
                endDate = txtEndDate.Text.Trim();

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
                dt.Clear();

                OHwigPonyTailSales = 0; OHhairSales = 0; OHhairCareSales = 0; OHstylingSalonSuppliesSales = 0; OHskinCosmeticNailFootSales = 0; OHgeneralMerchandiseSales = 0;
                OHpointRedeemed = 0;
                OHnetSales = 0; OHtax = 0; OHgrossSales = 0;
                OHnumOfTrans = 0;
                //OHaverageNetSales = 0; OHaverageGrossSales = 0;

                CHwigPonyTailSales = 0; CHhairSales = 0; CHhairCareSales = 0; CHstylingSalonSuppliesSales = 0; CHskinCosmeticNailFootSales = 0; CHgeneralMerchandiseSales = 0;
                CHpointRedeemed = 0;
                CHnetSales = 0; CHtax = 0; CHgrossSales = 0;
                CHnumOfTrans = 0;
                //CHaverageNetSales = 0; CHaverageGrossSales = 0;

                UMwigPonyTailSales = 0; UMhairSales = 0; UMhairCareSales = 0; UMstylingSalonSuppliesSales = 0; UMskinCosmeticNailFootSales = 0; UMgeneralMerchandiseSales = 0;
                UMpointRedeemed = 0;
                UMnetSales = 0; UMtax = 0; UMgrossSales = 0;
                UMnumOfTrans = 0;
                //UMaverageNetSales = 0; UMaverageGrossSales = 0;

                WMwigPonyTailSales = 0; WMhairSales = 0; WMhairCareSales = 0; WMstylingSalonSuppliesSales = 0; WMskinCosmeticNailFootSales = 0; WMgeneralMerchandiseSales = 0;
                WMpointRedeemed = 0;
                WMnetSales = 0; WMtax = 0; WMgrossSales = 0;
                WMnumOfTrans = 0;
                //WMaverageNetSales = 0; WMaverageGrossSales = 0;

                CVwigPonyTailSales = 0; CVhairSales = 0; CVhairCareSales = 0; CVstylingSalonSuppliesSales = 0; CVskinCosmeticNailFootSales = 0; CVgeneralMerchandiseSales = 0;
                CVpointRedeemed = 0;
                CVnetSales = 0; CVtax = 0; CVgrossSales = 0;
                CVnumOfTrans = 0;
                //CVaverageNetSales = 0; CVaverageGrossSales = 0;

                WBwigPonyTailSales = 0; WBhairSales = 0; WBhairCareSales = 0; WBstylingSalonSuppliesSales = 0; WBskinCosmeticNailFootSales = 0; WBgeneralMerchandiseSales = 0;
                WBpointRedeemed = 0;
                WBnetSales = 0; WBtax = 0; WBgrossSales = 0;
                WBnumOfTrans = 0;
                //WBaverageNetSales = 0; WBaverageGrossSales = 0;

                THwigPonyTailSales = 0; THhairSales = 0; THhairCareSales = 0; THstylingSalonSuppliesSales = 0; THskinCosmeticNailFootSales = 0; THgeneralMerchandiseSales = 0;
                THpointRedeemed = 0;
                THnetSales = 0; THtax = 0; THgrossSales = 0;
                THnumOfTrans = 0;
                //THaverageNetSales = 0; THaverageGrossSales = 0;

                WDwigPonyTailSales = 0; WDhairSales = 0; WDhairCareSales = 0; WDstylingSalonSuppliesSales = 0; WDskinCosmeticNailFootSales = 0; WDgeneralMerchandiseSales = 0;
                WDpointRedeemed = 0;
                WDnetSales = 0; WDtax = 0; WDgrossSales = 0;
                WDnumOfTrans = 0;
                //WDaverageNetSales = 0; WDaverageGrossSales = 0;

                PWwigPonyTailSales = 0; PWhairSales = 0; PWhairCareSales = 0; PWstylingSalonSuppliesSales = 0; PWskinCosmeticNailFootSales = 0; PWgeneralMerchandiseSales = 0;
                PWpointRedeemed = 0;
                PWnetSales = 0; PWtax = 0; PWgrossSales = 0;
                PWnumOfTrans = 0;
                //PWaverageNetSales = 0; PWaverageGrossSales = 0;

                GBwigPonyTailSales = 0; GBhairSales = 0; GBhairCareSales = 0; GBstylingSalonSuppliesSales = 0; GBskinCosmeticNailFootSales = 0; GBgeneralMerchandiseSales = 0;
                GBpointRedeemed = 0;
                GBnetSales = 0; GBtax = 0; GBgrossSales = 0;
                GBnumOfTrans = 0;
                //GBaverageNetSales = 0; GBaverageGrossSales = 0;

                BWwigPonyTailSales = 0; BWhairSales = 0; BWhairCareSales = 0; BWstylingSalonSuppliesSales = 0; BWskinCosmeticNailFootSales = 0; BWgeneralMerchandiseSales = 0;
                BWpointRedeemed = 0;
                BWnetSales = 0; BWtax = 0; BWgrossSales = 0;
                BWnumOfTrans = 0;
                //BWaverageNetSales = 0; BWaverageGrossSales = 0;

                SUMwigPonyTailSales = 0; SUMhairSales = 0; SUMhairCareSales = 0; SUMstylingSalonSuppliesSales = 0; SUMskinCosmeticNailFootSales = 0; SUMgeneralMerchandiseSales = 0;
                SUMpointRedeemed = 0;
                SUMnetSales = 0; SUMtax = 0; SUMgrossSales = 0;
                SUMnumOfTrans = 0;
                //SUMaverageNetSales = 0; SUMaverageGrossSales = 0;

                try
                {
                    cmd.CommandText = "Report_SalesHistory";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connTH;
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

                    connTH.Open();
                    cmd.ExecuteNonQuery();
                    connTH.Close();

                    if (cmd.Parameters["@WigPonyTailSales"].Value != DBNull.Value)
                        THwigPonyTailSales = Convert.ToDouble(cmd.Parameters["@WigPonyTailSales"].Value);

                    if (cmd.Parameters["@HairSales"].Value != DBNull.Value)
                        THhairSales = Convert.ToDouble(cmd.Parameters["@HairSales"].Value);

                    if (cmd.Parameters["@HairCareSales"].Value != DBNull.Value)
                        THhairCareSales = Convert.ToDouble(cmd.Parameters["@HairCareSales"].Value);

                    if (cmd.Parameters["@StylingSalonSuppliesSales"].Value != DBNull.Value)
                        THstylingSalonSuppliesSales = Convert.ToDouble(cmd.Parameters["@StylingSalonSuppliesSales"].Value);

                    if (cmd.Parameters["@SkinCosmeticNailFootSales"].Value != DBNull.Value)
                        THskinCosmeticNailFootSales = Convert.ToDouble(cmd.Parameters["@SkinCosmeticNailFootSales"].Value);

                    if (cmd.Parameters["@GeneralMerchandiseSales"].Value != DBNull.Value)
                        THgeneralMerchandiseSales = Convert.ToDouble(cmd.Parameters["@GeneralMerchandiseSales"].Value);

                    if (cmd.Parameters["@PointRedeemed"].Value != DBNull.Value)
                        THpointRedeemed = Convert.ToDouble(cmd.Parameters["@PointRedeemed"].Value);

                    if (cmd.Parameters["@NetSales"].Value != DBNull.Value)
                        THnetSales = Convert.ToDouble(cmd.Parameters["@NetSales"].Value);

                    if (cmd.Parameters["@Tax"].Value != DBNull.Value)
                        THtax = Convert.ToDouble(cmd.Parameters["@Tax"].Value);

                    if (cmd.Parameters["@GrossSales"].Value != DBNull.Value)
                        THgrossSales = Convert.ToDouble(cmd.Parameters["@GrossSales"].Value);

                    if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                        THnumOfTrans = Convert.ToInt64(cmd.Parameters["@NumOfTrans"].Value);

                    progressBar1.PerformStep();
                }
                catch
                {
                    MessageBox.Show("CAN NOT CONNECT TEMPLE HILLS SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connTH.Close();
                }

                try
                {
                    cmd.CommandText = "Report_SalesHistory";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connOH;
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

                    connOH.Open();
                    cmd.ExecuteNonQuery();
                    connOH.Close();

                    if (cmd.Parameters["@WigPonyTailSales"].Value != DBNull.Value)
                        OHwigPonyTailSales = Convert.ToDouble(cmd.Parameters["@WigPonyTailSales"].Value);

                    if (cmd.Parameters["@HairSales"].Value != DBNull.Value)
                        OHhairSales = Convert.ToDouble(cmd.Parameters["@HairSales"].Value);

                    if (cmd.Parameters["@HairCareSales"].Value != DBNull.Value)
                        OHhairCareSales = Convert.ToDouble(cmd.Parameters["@HairCareSales"].Value);

                    if (cmd.Parameters["@StylingSalonSuppliesSales"].Value != DBNull.Value)
                        OHstylingSalonSuppliesSales = Convert.ToDouble(cmd.Parameters["@StylingSalonSuppliesSales"].Value);

                    if (cmd.Parameters["@SkinCosmeticNailFootSales"].Value != DBNull.Value)
                        OHskinCosmeticNailFootSales = Convert.ToDouble(cmd.Parameters["@SkinCosmeticNailFootSales"].Value);

                    if (cmd.Parameters["@GeneralMerchandiseSales"].Value != DBNull.Value)
                        OHgeneralMerchandiseSales = Convert.ToDouble(cmd.Parameters["@GeneralMerchandiseSales"].Value);

                    if (cmd.Parameters["@PointRedeemed"].Value != DBNull.Value)
                        OHpointRedeemed = Convert.ToDouble(cmd.Parameters["@PointRedeemed"].Value);

                    if (cmd.Parameters["@NetSales"].Value != DBNull.Value)
                        OHnetSales = Convert.ToDouble(cmd.Parameters["@NetSales"].Value);

                    if (cmd.Parameters["@Tax"].Value != DBNull.Value)
                        OHtax = Convert.ToDouble(cmd.Parameters["@Tax"].Value);

                    if (cmd.Parameters["@GrossSales"].Value != DBNull.Value)
                        OHgrossSales = Convert.ToDouble(cmd.Parameters["@GrossSales"].Value);

                    if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                        OHnumOfTrans = Convert.ToInt64(cmd.Parameters["@NumOfTrans"].Value);

                    progressBar1.PerformStep();
                }
                catch
                {
                    MessageBox.Show("CAN NOT CONNECT OXON HILL SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connOH.Close();
                }

                try
                {
                    cmd.CommandText = "Report_SalesHistory";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connCH;
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

                    connCH.Open();
                    cmd.ExecuteNonQuery();
                    connCH.Close();

                    if (cmd.Parameters["@WigPonyTailSales"].Value != DBNull.Value)
                        CHwigPonyTailSales = Convert.ToDouble(cmd.Parameters["@WigPonyTailSales"].Value);

                    if (cmd.Parameters["@HairSales"].Value != DBNull.Value)
                        CHhairSales = Convert.ToDouble(cmd.Parameters["@HairSales"].Value);

                    if (cmd.Parameters["@HairCareSales"].Value != DBNull.Value)
                        CHhairCareSales = Convert.ToDouble(cmd.Parameters["@HairCareSales"].Value);

                    if (cmd.Parameters["@StylingSalonSuppliesSales"].Value != DBNull.Value)
                        CHstylingSalonSuppliesSales = Convert.ToDouble(cmd.Parameters["@StylingSalonSuppliesSales"].Value);

                    if (cmd.Parameters["@SkinCosmeticNailFootSales"].Value != DBNull.Value)
                        CHskinCosmeticNailFootSales = Convert.ToDouble(cmd.Parameters["@SkinCosmeticNailFootSales"].Value);

                    if (cmd.Parameters["@GeneralMerchandiseSales"].Value != DBNull.Value)
                        CHgeneralMerchandiseSales = Convert.ToDouble(cmd.Parameters["@GeneralMerchandiseSales"].Value);

                    if (cmd.Parameters["@PointRedeemed"].Value != DBNull.Value)
                        CHpointRedeemed = Convert.ToDouble(cmd.Parameters["@PointRedeemed"].Value);

                    if (cmd.Parameters["@NetSales"].Value != DBNull.Value)
                        CHnetSales = Convert.ToDouble(cmd.Parameters["@NetSales"].Value);

                    if (cmd.Parameters["@Tax"].Value != DBNull.Value)
                        CHtax = Convert.ToDouble(cmd.Parameters["@Tax"].Value);

                    if (cmd.Parameters["@GrossSales"].Value != DBNull.Value)
                        CHgrossSales = Convert.ToDouble(cmd.Parameters["@GrossSales"].Value);

                    if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                        CHnumOfTrans = Convert.ToInt64(cmd.Parameters["@NumOfTrans"].Value);

                    progressBar1.PerformStep();
                }
                catch
                {
                    MessageBox.Show("CAN NOT CONNECT CAPITOL HEIGHTS SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connCH.Close();
                }

                try
                {
                    cmd.CommandText = "Report_SalesHistory";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connUM;
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

                    connUM.Open();
                    cmd.ExecuteNonQuery();
                    connUM.Close();

                    if (cmd.Parameters["@WigPonyTailSales"].Value != DBNull.Value)
                        UMwigPonyTailSales = Convert.ToDouble(cmd.Parameters["@WigPonyTailSales"].Value);

                    if (cmd.Parameters["@HairSales"].Value != DBNull.Value)
                        UMhairSales = Convert.ToDouble(cmd.Parameters["@HairSales"].Value);

                    if (cmd.Parameters["@HairCareSales"].Value != DBNull.Value)
                        UMhairCareSales = Convert.ToDouble(cmd.Parameters["@HairCareSales"].Value);

                    if (cmd.Parameters["@StylingSalonSuppliesSales"].Value != DBNull.Value)
                        UMstylingSalonSuppliesSales = Convert.ToDouble(cmd.Parameters["@StylingSalonSuppliesSales"].Value);

                    if (cmd.Parameters["@SkinCosmeticNailFootSales"].Value != DBNull.Value)
                        UMskinCosmeticNailFootSales = Convert.ToDouble(cmd.Parameters["@SkinCosmeticNailFootSales"].Value);

                    if (cmd.Parameters["@GeneralMerchandiseSales"].Value != DBNull.Value)
                        UMgeneralMerchandiseSales = Convert.ToDouble(cmd.Parameters["@GeneralMerchandiseSales"].Value);

                    if (cmd.Parameters["@PointRedeemed"].Value != DBNull.Value)
                        UMpointRedeemed = Convert.ToDouble(cmd.Parameters["@PointRedeemed"].Value);

                    if (cmd.Parameters["@NetSales"].Value != DBNull.Value)
                        UMnetSales = Convert.ToDouble(cmd.Parameters["@NetSales"].Value);

                    if (cmd.Parameters["@Tax"].Value != DBNull.Value)
                        UMtax = Convert.ToDouble(cmd.Parameters["@Tax"].Value);

                    if (cmd.Parameters["@GrossSales"].Value != DBNull.Value)
                        UMgrossSales = Convert.ToDouble(cmd.Parameters["@GrossSales"].Value);

                    if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                        UMnumOfTrans = Convert.ToInt64(cmd.Parameters["@NumOfTrans"].Value);

                    progressBar1.PerformStep();
                }
                catch
                {
                    MessageBox.Show("CAN NOT CONNECT UPPER MARLBORO SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connUM.Close();
                }

                try
                {
                    cmd.CommandText = "Report_SalesHistory";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connWM;
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

                    connWM.Open();
                    cmd.ExecuteNonQuery();
                    connWM.Close();

                    if (cmd.Parameters["@WigPonyTailSales"].Value != DBNull.Value)
                        WMwigPonyTailSales = Convert.ToDouble(cmd.Parameters["@WigPonyTailSales"].Value);

                    if (cmd.Parameters["@HairSales"].Value != DBNull.Value)
                        WMhairSales = Convert.ToDouble(cmd.Parameters["@HairSales"].Value);

                    if (cmd.Parameters["@HairCareSales"].Value != DBNull.Value)
                        WMhairCareSales = Convert.ToDouble(cmd.Parameters["@HairCareSales"].Value);

                    if (cmd.Parameters["@StylingSalonSuppliesSales"].Value != DBNull.Value)
                        WMstylingSalonSuppliesSales = Convert.ToDouble(cmd.Parameters["@StylingSalonSuppliesSales"].Value);

                    if (cmd.Parameters["@SkinCosmeticNailFootSales"].Value != DBNull.Value)
                        WMskinCosmeticNailFootSales = Convert.ToDouble(cmd.Parameters["@SkinCosmeticNailFootSales"].Value);

                    if (cmd.Parameters["@GeneralMerchandiseSales"].Value != DBNull.Value)
                        WMgeneralMerchandiseSales = Convert.ToDouble(cmd.Parameters["@GeneralMerchandiseSales"].Value);

                    if (cmd.Parameters["@PointRedeemed"].Value != DBNull.Value)
                        WMpointRedeemed = Convert.ToDouble(cmd.Parameters["@PointRedeemed"].Value);

                    if (cmd.Parameters["@NetSales"].Value != DBNull.Value)
                        WMnetSales = Convert.ToDouble(cmd.Parameters["@NetSales"].Value);

                    if (cmd.Parameters["@Tax"].Value != DBNull.Value)
                        WMtax = Convert.ToDouble(cmd.Parameters["@Tax"].Value);

                    if (cmd.Parameters["@GrossSales"].Value != DBNull.Value)
                        WMgrossSales = Convert.ToDouble(cmd.Parameters["@GrossSales"].Value);

                    if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                        WMnumOfTrans = Convert.ToInt64(cmd.Parameters["@NumOfTrans"].Value);

                    progressBar1.PerformStep();
                }
                catch
                {
                    MessageBox.Show("CAN NOT CONNECT WINDSOR MILL SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connWM.Close();
                }

                try
                {
                    cmd.CommandText = "Report_SalesHistory";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connCV;
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

                    connCV.Open();
                    cmd.ExecuteNonQuery();
                    connCV.Close();

                    if (cmd.Parameters["@WigPonyTailSales"].Value != DBNull.Value)
                        CVwigPonyTailSales = Convert.ToDouble(cmd.Parameters["@WigPonyTailSales"].Value);

                    if (cmd.Parameters["@HairSales"].Value != DBNull.Value)
                        CVhairSales = Convert.ToDouble(cmd.Parameters["@HairSales"].Value);

                    if (cmd.Parameters["@HairCareSales"].Value != DBNull.Value)
                        CVhairCareSales = Convert.ToDouble(cmd.Parameters["@HairCareSales"].Value);

                    if (cmd.Parameters["@StylingSalonSuppliesSales"].Value != DBNull.Value)
                        CVstylingSalonSuppliesSales = Convert.ToDouble(cmd.Parameters["@StylingSalonSuppliesSales"].Value);

                    if (cmd.Parameters["@SkinCosmeticNailFootSales"].Value != DBNull.Value)
                        CVskinCosmeticNailFootSales = Convert.ToDouble(cmd.Parameters["@SkinCosmeticNailFootSales"].Value);

                    if (cmd.Parameters["@GeneralMerchandiseSales"].Value != DBNull.Value)
                        CVgeneralMerchandiseSales = Convert.ToDouble(cmd.Parameters["@GeneralMerchandiseSales"].Value);

                    if (cmd.Parameters["@PointRedeemed"].Value != DBNull.Value)
                        CVpointRedeemed = Convert.ToDouble(cmd.Parameters["@PointRedeemed"].Value);

                    if (cmd.Parameters["@NetSales"].Value != DBNull.Value)
                        CVnetSales = Convert.ToDouble(cmd.Parameters["@NetSales"].Value);

                    if (cmd.Parameters["@Tax"].Value != DBNull.Value)
                        CVtax = Convert.ToDouble(cmd.Parameters["@Tax"].Value);

                    if (cmd.Parameters["@GrossSales"].Value != DBNull.Value)
                        CVgrossSales = Convert.ToDouble(cmd.Parameters["@GrossSales"].Value);

                    if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                        CVnumOfTrans = Convert.ToInt64(cmd.Parameters["@NumOfTrans"].Value);

                    progressBar1.PerformStep();
                }
                catch
                {
                    MessageBox.Show("CAN NOT CONNECT CATONSVILLE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connCV.Close();
                }

                try
                {
                    cmd.CommandText = "Report_SalesHistory";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connWB;
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

                    connWB.Open();
                    cmd.ExecuteNonQuery();
                    connWB.Close();

                    if (cmd.Parameters["@WigPonyTailSales"].Value != DBNull.Value)
                        WBwigPonyTailSales = Convert.ToDouble(cmd.Parameters["@WigPonyTailSales"].Value);

                    if (cmd.Parameters["@HairSales"].Value != DBNull.Value)
                        WBhairSales = Convert.ToDouble(cmd.Parameters["@HairSales"].Value);

                    if (cmd.Parameters["@HairCareSales"].Value != DBNull.Value)
                        WBhairCareSales = Convert.ToDouble(cmd.Parameters["@HairCareSales"].Value);

                    if (cmd.Parameters["@StylingSalonSuppliesSales"].Value != DBNull.Value)
                        WBstylingSalonSuppliesSales = Convert.ToDouble(cmd.Parameters["@StylingSalonSuppliesSales"].Value);

                    if (cmd.Parameters["@SkinCosmeticNailFootSales"].Value != DBNull.Value)
                        WBskinCosmeticNailFootSales = Convert.ToDouble(cmd.Parameters["@SkinCosmeticNailFootSales"].Value);

                    if (cmd.Parameters["@GeneralMerchandiseSales"].Value != DBNull.Value)
                        WBgeneralMerchandiseSales = Convert.ToDouble(cmd.Parameters["@GeneralMerchandiseSales"].Value);

                    if (cmd.Parameters["@PointRedeemed"].Value != DBNull.Value)
                        WBpointRedeemed = Convert.ToDouble(cmd.Parameters["@PointRedeemed"].Value);

                    if (cmd.Parameters["@NetSales"].Value != DBNull.Value)
                        WBnetSales = Convert.ToDouble(cmd.Parameters["@NetSales"].Value);

                    if (cmd.Parameters["@Tax"].Value != DBNull.Value)
                        WBtax = Convert.ToDouble(cmd.Parameters["@Tax"].Value);

                    if (cmd.Parameters["@GrossSales"].Value != DBNull.Value)
                        WBgrossSales = Convert.ToDouble(cmd.Parameters["@GrossSales"].Value);

                    if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                        WBnumOfTrans = Convert.ToInt64(cmd.Parameters["@NumOfTrans"].Value);

                    progressBar1.PerformStep();
                }
                catch
                {
                    MessageBox.Show("CAN NOT CONNECT WOODBRIDGE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connWB.Close();
                }

                try
                {
                    cmd.CommandText = "Report_SalesHistory";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connWD;
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

                    connWD.Open();
                    cmd.ExecuteNonQuery();
                    connWD.Close();

                    if (cmd.Parameters["@WigPonyTailSales"].Value != DBNull.Value)
                        WDwigPonyTailSales = Convert.ToDouble(cmd.Parameters["@WigPonyTailSales"].Value);

                    if (cmd.Parameters["@HairSales"].Value != DBNull.Value)
                        WDhairSales = Convert.ToDouble(cmd.Parameters["@HairSales"].Value);

                    if (cmd.Parameters["@HairCareSales"].Value != DBNull.Value)
                        WDhairCareSales = Convert.ToDouble(cmd.Parameters["@HairCareSales"].Value);

                    if (cmd.Parameters["@StylingSalonSuppliesSales"].Value != DBNull.Value)
                        WDstylingSalonSuppliesSales = Convert.ToDouble(cmd.Parameters["@StylingSalonSuppliesSales"].Value);

                    if (cmd.Parameters["@SkinCosmeticNailFootSales"].Value != DBNull.Value)
                        WDskinCosmeticNailFootSales = Convert.ToDouble(cmd.Parameters["@SkinCosmeticNailFootSales"].Value);

                    if (cmd.Parameters["@GeneralMerchandiseSales"].Value != DBNull.Value)
                        WDgeneralMerchandiseSales = Convert.ToDouble(cmd.Parameters["@GeneralMerchandiseSales"].Value);

                    if (cmd.Parameters["@PointRedeemed"].Value != DBNull.Value)
                        WDpointRedeemed = Convert.ToDouble(cmd.Parameters["@PointRedeemed"].Value);

                    if (cmd.Parameters["@NetSales"].Value != DBNull.Value)
                        WDnetSales = Convert.ToDouble(cmd.Parameters["@NetSales"].Value);

                    if (cmd.Parameters["@Tax"].Value != DBNull.Value)
                        WDtax = Convert.ToDouble(cmd.Parameters["@Tax"].Value);

                    if (cmd.Parameters["@GrossSales"].Value != DBNull.Value)
                        WDgrossSales = Convert.ToDouble(cmd.Parameters["@GrossSales"].Value);

                    if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                        WDnumOfTrans = Convert.ToInt64(cmd.Parameters["@NumOfTrans"].Value);

                    progressBar1.PerformStep();
                }
                catch
                {
                    MessageBox.Show("CAN NOT CONNECT WALDORF SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connWD.Close();
                }

                try
                {
                    cmd.CommandText = "Report_SalesHistory";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connPW;
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

                    connPW.Open();
                    cmd.ExecuteNonQuery();
                    connPW.Close();

                    if (cmd.Parameters["@WigPonyTailSales"].Value != DBNull.Value)
                        PWwigPonyTailSales = Convert.ToDouble(cmd.Parameters["@WigPonyTailSales"].Value);

                    if (cmd.Parameters["@HairSales"].Value != DBNull.Value)
                        PWhairSales = Convert.ToDouble(cmd.Parameters["@HairSales"].Value);

                    if (cmd.Parameters["@HairCareSales"].Value != DBNull.Value)
                        PWhairCareSales = Convert.ToDouble(cmd.Parameters["@HairCareSales"].Value);

                    if (cmd.Parameters["@StylingSalonSuppliesSales"].Value != DBNull.Value)
                        PWstylingSalonSuppliesSales = Convert.ToDouble(cmd.Parameters["@StylingSalonSuppliesSales"].Value);

                    if (cmd.Parameters["@SkinCosmeticNailFootSales"].Value != DBNull.Value)
                        PWskinCosmeticNailFootSales = Convert.ToDouble(cmd.Parameters["@SkinCosmeticNailFootSales"].Value);

                    if (cmd.Parameters["@GeneralMerchandiseSales"].Value != DBNull.Value)
                        PWgeneralMerchandiseSales = Convert.ToDouble(cmd.Parameters["@GeneralMerchandiseSales"].Value);

                    if (cmd.Parameters["@PointRedeemed"].Value != DBNull.Value)
                        PWpointRedeemed = Convert.ToDouble(cmd.Parameters["@PointRedeemed"].Value);

                    if (cmd.Parameters["@NetSales"].Value != DBNull.Value)
                        PWnetSales = Convert.ToDouble(cmd.Parameters["@NetSales"].Value);

                    if (cmd.Parameters["@Tax"].Value != DBNull.Value)
                        PWtax = Convert.ToDouble(cmd.Parameters["@Tax"].Value);

                    if (cmd.Parameters["@GrossSales"].Value != DBNull.Value)
                        PWgrossSales = Convert.ToDouble(cmd.Parameters["@GrossSales"].Value);

                    if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                        PWnumOfTrans = Convert.ToInt64(cmd.Parameters["@NumOfTrans"].Value);

                    progressBar1.PerformStep();
                }
                catch
                {
                    MessageBox.Show("CAN NOT CONNECT PRINCE WILLIAM SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connPW.Close();
                }

                try
                {
                    cmd.CommandText = "Report_SalesHistory";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connGB;
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

                    connGB.Open();
                    cmd.ExecuteNonQuery();
                    connGB.Close();

                    if (cmd.Parameters["@WigPonyTailSales"].Value != DBNull.Value)
                        GBwigPonyTailSales = Convert.ToDouble(cmd.Parameters["@WigPonyTailSales"].Value);

                    if (cmd.Parameters["@HairSales"].Value != DBNull.Value)
                        GBhairSales = Convert.ToDouble(cmd.Parameters["@HairSales"].Value);

                    if (cmd.Parameters["@HairCareSales"].Value != DBNull.Value)
                        GBhairCareSales = Convert.ToDouble(cmd.Parameters["@HairCareSales"].Value);

                    if (cmd.Parameters["@StylingSalonSuppliesSales"].Value != DBNull.Value)
                        GBstylingSalonSuppliesSales = Convert.ToDouble(cmd.Parameters["@StylingSalonSuppliesSales"].Value);

                    if (cmd.Parameters["@SkinCosmeticNailFootSales"].Value != DBNull.Value)
                        GBskinCosmeticNailFootSales = Convert.ToDouble(cmd.Parameters["@SkinCosmeticNailFootSales"].Value);

                    if (cmd.Parameters["@GeneralMerchandiseSales"].Value != DBNull.Value)
                        GBgeneralMerchandiseSales = Convert.ToDouble(cmd.Parameters["@GeneralMerchandiseSales"].Value);

                    if (cmd.Parameters["@PointRedeemed"].Value != DBNull.Value)
                        GBpointRedeemed = Convert.ToDouble(cmd.Parameters["@PointRedeemed"].Value);

                    if (cmd.Parameters["@NetSales"].Value != DBNull.Value)
                        GBnetSales = Convert.ToDouble(cmd.Parameters["@NetSales"].Value);

                    if (cmd.Parameters["@Tax"].Value != DBNull.Value)
                        GBtax = Convert.ToDouble(cmd.Parameters["@Tax"].Value);

                    if (cmd.Parameters["@GrossSales"].Value != DBNull.Value)
                        GBgrossSales = Convert.ToDouble(cmd.Parameters["@GrossSales"].Value);

                    if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                        GBnumOfTrans = Convert.ToInt64(cmd.Parameters["@NumOfTrans"].Value);

                    progressBar1.PerformStep();
                }
                catch
                {
                    MessageBox.Show("CAN NOT CONNECT GAITHERSBURG SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connGB.Close();
                }

                try
                {
                    cmd.CommandText = "Report_SalesHistory";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connBW;
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

                    connBW.Open();
                    cmd.ExecuteNonQuery();
                    connBW.Close();

                    if (cmd.Parameters["@WigPonyTailSales"].Value != DBNull.Value)
                        BWwigPonyTailSales = Convert.ToDouble(cmd.Parameters["@WigPonyTailSales"].Value);

                    if (cmd.Parameters["@HairSales"].Value != DBNull.Value)
                        BWhairSales = Convert.ToDouble(cmd.Parameters["@HairSales"].Value);

                    if (cmd.Parameters["@HairCareSales"].Value != DBNull.Value)
                        BWhairCareSales = Convert.ToDouble(cmd.Parameters["@HairCareSales"].Value);

                    if (cmd.Parameters["@StylingSalonSuppliesSales"].Value != DBNull.Value)
                        BWstylingSalonSuppliesSales = Convert.ToDouble(cmd.Parameters["@StylingSalonSuppliesSales"].Value);

                    if (cmd.Parameters["@SkinCosmeticNailFootSales"].Value != DBNull.Value)
                        BWskinCosmeticNailFootSales = Convert.ToDouble(cmd.Parameters["@SkinCosmeticNailFootSales"].Value);

                    if (cmd.Parameters["@GeneralMerchandiseSales"].Value != DBNull.Value)
                        BWgeneralMerchandiseSales = Convert.ToDouble(cmd.Parameters["@GeneralMerchandiseSales"].Value);

                    if (cmd.Parameters["@PointRedeemed"].Value != DBNull.Value)
                        BWpointRedeemed = Convert.ToDouble(cmd.Parameters["@PointRedeemed"].Value);

                    if (cmd.Parameters["@NetSales"].Value != DBNull.Value)
                        BWnetSales = Convert.ToDouble(cmd.Parameters["@NetSales"].Value);

                    if (cmd.Parameters["@Tax"].Value != DBNull.Value)
                        BWtax = Convert.ToDouble(cmd.Parameters["@Tax"].Value);

                    if (cmd.Parameters["@GrossSales"].Value != DBNull.Value)
                        BWgrossSales = Convert.ToDouble(cmd.Parameters["@GrossSales"].Value);

                    if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                        BWnumOfTrans = Convert.ToInt64(cmd.Parameters["@NumOfTrans"].Value);

                    progressBar1.PerformStep();
                }
                catch
                {
                    MessageBox.Show("CAN NOT CONNECT BOWIE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connBW.Close();
                }

                SUMwigPonyTailSales = OHwigPonyTailSales + CHwigPonyTailSales + CVwigPonyTailSales + UMwigPonyTailSales + WMwigPonyTailSales + WBwigPonyTailSales + THwigPonyTailSales + WDwigPonyTailSales + PWwigPonyTailSales + GBwigPonyTailSales + BWwigPonyTailSales;
                SUMhairSales = OHhairSales + CHhairSales + CVhairSales + UMhairSales + WMhairSales + WBhairSales + THhairSales + WDhairSales + PWhairSales + GBhairSales + BWhairSales;
                SUMhairCareSales = OHhairCareSales + CHhairCareSales + CVhairCareSales + UMhairCareSales + WMhairCareSales + WBhairCareSales + THhairCareSales + WDhairCareSales + PWhairCareSales + GBhairCareSales + BWhairCareSales;
                SUMstylingSalonSuppliesSales = OHstylingSalonSuppliesSales + CHstylingSalonSuppliesSales + CVstylingSalonSuppliesSales + UMstylingSalonSuppliesSales + WMstylingSalonSuppliesSales + WBstylingSalonSuppliesSales + THstylingSalonSuppliesSales + WDstylingSalonSuppliesSales + PWstylingSalonSuppliesSales + GBstylingSalonSuppliesSales + BWstylingSalonSuppliesSales;
                SUMskinCosmeticNailFootSales = OHskinCosmeticNailFootSales + CHskinCosmeticNailFootSales + CVskinCosmeticNailFootSales + UMskinCosmeticNailFootSales + WMskinCosmeticNailFootSales + WBskinCosmeticNailFootSales + THskinCosmeticNailFootSales + WDskinCosmeticNailFootSales + PWskinCosmeticNailFootSales + GBskinCosmeticNailFootSales + BWskinCosmeticNailFootSales;
                SUMgeneralMerchandiseSales = OHgeneralMerchandiseSales + CHgeneralMerchandiseSales + CVgeneralMerchandiseSales + UMgeneralMerchandiseSales + WMgeneralMerchandiseSales + WBgeneralMerchandiseSales + THgeneralMerchandiseSales + WDgeneralMerchandiseSales + PWgeneralMerchandiseSales + GBgeneralMerchandiseSales + BWgeneralMerchandiseSales;
                SUMpointRedeemed = OHpointRedeemed + CHpointRedeemed + CVpointRedeemed + UMpointRedeemed + WMpointRedeemed + WBpointRedeemed + THpointRedeemed + WDpointRedeemed + PWpointRedeemed + GBpointRedeemed + BWpointRedeemed;
                SUMnetSales = OHnetSales + CHnetSales + CVnetSales + UMnetSales + WMnetSales + WBnetSales + THnetSales + WDnetSales + PWnetSales + GBnetSales + BWnetSales;
                SUMtax = OHtax + CHtax + CVtax + UMtax + WMtax + WBtax + THtax + WDtax + PWtax + GBtax + BWtax;
                SUMgrossSales = OHgrossSales + CHgrossSales + CVgrossSales + UMgrossSales + WMgrossSales + WBgrossSales + THgrossSales + WDgrossSales + PWgrossSales + GBgrossSales + BWgrossSales;
                SUMnumOfTrans = OHnumOfTrans + CHnumOfTrans + CVnumOfTrans + UMnumOfTrans + WMnumOfTrans + WBnumOfTrans + THnumOfTrans + WDnumOfTrans + PWnumOfTrans + GBnumOfTrans + BWnumOfTrans;

                dt.Rows.Add("WIG/PONY TAIL", string.Format("{0:c}", THwigPonyTailSales) + "\n(" + string.Format("{0:p}", THwigPonyTailSales / THnetSales) + ")",
                                             string.Format("{0:c}", OHwigPonyTailSales) + "\n(" + string.Format("{0:p}", OHwigPonyTailSales / OHnetSales) + ")",
                                             string.Format("{0:c}", UMwigPonyTailSales) + "\n(" + string.Format("{0:p}", UMwigPonyTailSales / UMnetSales) + ")",
                                             string.Format("{0:c}", CHwigPonyTailSales) + "\n(" + string.Format("{0:p}", CHwigPonyTailSales / CHnetSales) + ")",
                                             string.Format("{0:c}", WMwigPonyTailSales) + "\n(" + string.Format("{0:p}", WMwigPonyTailSales / WMnetSales) + ")",
                                             string.Format("{0:c}", CVwigPonyTailSales) + "\n(" + string.Format("{0:p}", CVwigPonyTailSales / CVnetSales) + ")",
                                             string.Format("{0:c}", GBwigPonyTailSales) + "\n(" + string.Format("{0:p}", GBwigPonyTailSales / GBnetSales) + ")",
                                             string.Format("{0:c}", PWwigPonyTailSales) + "\n(" + string.Format("{0:p}", PWwigPonyTailSales / PWnetSales) + ")",
                                             string.Format("{0:c}", WBwigPonyTailSales) + "\n(" + string.Format("{0:p}", WBwigPonyTailSales / WBnetSales) + ")",
                                             string.Format("{0:c}", WDwigPonyTailSales) + "\n(" + string.Format("{0:p}", WDwigPonyTailSales / WDnetSales) + ")",
                                             string.Format("{0:c}", BWwigPonyTailSales) + "\n(" + string.Format("{0:p}", BWwigPonyTailSales / BWnetSales) + ")",
                                             string.Format("{0:c}", SUMwigPonyTailSales) + "\n(" + string.Format("{0:p}", SUMwigPonyTailSales / SUMnetSales) + ")");
                dt.Rows.Add("HAIR", string.Format("{0:c}", THhairSales) + "\n(" + string.Format("{0:p}", THhairSales / THnetSales) + ")",
                                    string.Format("{0:c}", OHhairSales) + "\n(" + string.Format("{0:p}", OHhairSales / OHnetSales) + ")",
                                    string.Format("{0:c}", UMhairSales) + "\n(" + string.Format("{0:p}", UMhairSales / UMnetSales) + ")",
                                    string.Format("{0:c}", CHhairSales) + "\n(" + string.Format("{0:p}", CHhairSales / CHnetSales) + ")",
                                    string.Format("{0:c}", WMhairSales) + "\n(" + string.Format("{0:p}", WMhairSales / WMnetSales) + ")",
                                    string.Format("{0:c}", CVhairSales) + "\n(" + string.Format("{0:p}", CVhairSales / CVnetSales) + ")",
                                    string.Format("{0:c}", GBhairSales) + "\n(" + string.Format("{0:p}", GBhairSales / GBnetSales) + ")",
                                    string.Format("{0:c}", PWhairSales) + "\n(" + string.Format("{0:p}", PWhairSales / PWnetSales) + ")",
                                    string.Format("{0:c}", WBhairSales) + "\n(" + string.Format("{0:p}", WBhairSales / WBnetSales) + ")",
                                    string.Format("{0:c}", WDhairSales) + "\n(" + string.Format("{0:p}", WDhairSales / WDnetSales) + ")",
                                    string.Format("{0:c}", BWhairSales) + "\n(" + string.Format("{0:p}", BWhairSales / BWnetSales) + ")",
                                    string.Format("{0:c}", SUMhairSales) + "\n(" + string.Format("{0:p}", SUMhairSales / SUMnetSales) + ")");
                dt.Rows.Add("HAIR CARE", string.Format("{0:c}", THhairCareSales) + "\n(" + string.Format("{0:p}", THhairCareSales / THnetSales) + ")",
                                         string.Format("{0:c}", OHhairCareSales) + "\n(" + string.Format("{0:p}", OHhairCareSales / OHnetSales) + ")",
                                         string.Format("{0:c}", UMhairCareSales) + "\n(" + string.Format("{0:p}", UMhairCareSales / UMnetSales) + ")",
                                         string.Format("{0:c}", CHhairCareSales) + "\n(" + string.Format("{0:p}", CHhairCareSales / CHnetSales) + ")",
                                         string.Format("{0:c}", WMhairCareSales) + "\n(" + string.Format("{0:p}", WMhairCareSales / WMnetSales) + ")",
                                         string.Format("{0:c}", CVhairCareSales) + "\n(" + string.Format("{0:p}", CVhairCareSales / CVnetSales) + ")",
                                         string.Format("{0:c}", GBhairCareSales) + "\n(" + string.Format("{0:p}", GBhairCareSales / GBnetSales) + ")",
                                         string.Format("{0:c}", PWhairCareSales) + "\n(" + string.Format("{0:p}", PWhairCareSales / PWnetSales) + ")",
                                         string.Format("{0:c}", WBhairCareSales) + "\n(" + string.Format("{0:p}", WBhairCareSales / WBnetSales) + ")",
                                         string.Format("{0:c}", WDhairCareSales) + "\n(" + string.Format("{0:p}", WDhairCareSales / WDnetSales) + ")",
                                         string.Format("{0:c}", BWhairCareSales) + "\n(" + string.Format("{0:p}", BWhairCareSales / BWnetSales) + ")",
                                         string.Format("{0:c}", SUMhairCareSales) + "\n(" + string.Format("{0:p}", SUMhairCareSales / SUMnetSales) + ")");
                dt.Rows.Add("STYLING & SALON SUPPLIES", string.Format("{0:c}", THstylingSalonSuppliesSales) + "\n(" + string.Format("{0:p}", THstylingSalonSuppliesSales / THnetSales) + ")",
                                                        string.Format("{0:c}", OHstylingSalonSuppliesSales) + "\n(" + string.Format("{0:p}", OHstylingSalonSuppliesSales / OHnetSales) + ")",
                                                        string.Format("{0:c}", UMstylingSalonSuppliesSales) + "\n(" + string.Format("{0:p}", UMstylingSalonSuppliesSales / UMnetSales) + ")",
                                                        string.Format("{0:c}", CHstylingSalonSuppliesSales) + "\n(" + string.Format("{0:p}", CHstylingSalonSuppliesSales / CHnetSales) + ")",
                                                        string.Format("{0:c}", WMstylingSalonSuppliesSales) + "\n(" + string.Format("{0:p}", WMstylingSalonSuppliesSales / WMnetSales) + ")",
                                                        string.Format("{0:c}", CVstylingSalonSuppliesSales) + "\n(" + string.Format("{0:p}", CVstylingSalonSuppliesSales / CVnetSales) + ")",
                                                        string.Format("{0:c}", GBstylingSalonSuppliesSales) + "\n(" + string.Format("{0:p}", GBstylingSalonSuppliesSales / GBnetSales) + ")",
                                                        string.Format("{0:c}", PWstylingSalonSuppliesSales) + "\n(" + string.Format("{0:p}", PWstylingSalonSuppliesSales / PWnetSales) + ")",
                                                        string.Format("{0:c}", WBstylingSalonSuppliesSales) + "\n(" + string.Format("{0:p}", WBstylingSalonSuppliesSales / WBnetSales) + ")",
                                                        string.Format("{0:c}", WDstylingSalonSuppliesSales) + "\n(" + string.Format("{0:p}", WDstylingSalonSuppliesSales / WDnetSales) + ")",
                                                        string.Format("{0:c}", BWstylingSalonSuppliesSales) + "\n(" + string.Format("{0:p}", BWstylingSalonSuppliesSales / BWnetSales) + ")",
                                                        string.Format("{0:c}", SUMstylingSalonSuppliesSales) + "\n(" + string.Format("{0:p}", SUMstylingSalonSuppliesSales / SUMnetSales) + ")");
                dt.Rows.Add("SKIN/COSMETIC /NAIL/FOOT", string.Format("{0:c}", THskinCosmeticNailFootSales) + "\n(" + string.Format("{0:p}", THskinCosmeticNailFootSales / THnetSales) + ")",
                                                        string.Format("{0:c}", OHskinCosmeticNailFootSales) + "\n(" + string.Format("{0:p}", OHskinCosmeticNailFootSales / OHnetSales) + ")",
                                                        string.Format("{0:c}", UMskinCosmeticNailFootSales) + "\n(" + string.Format("{0:p}", UMskinCosmeticNailFootSales / UMnetSales) + ")",
                                                        string.Format("{0:c}", CHskinCosmeticNailFootSales) + "\n(" + string.Format("{0:p}", CHskinCosmeticNailFootSales / CHnetSales) + ")",
                                                        string.Format("{0:c}", WMskinCosmeticNailFootSales) + "\n(" + string.Format("{0:p}", WMskinCosmeticNailFootSales / WMnetSales) + ")",
                                                        string.Format("{0:c}", CVskinCosmeticNailFootSales) + "\n(" + string.Format("{0:p}", CVskinCosmeticNailFootSales / CVnetSales) + ")",                                                        
                                                        string.Format("{0:c}", GBskinCosmeticNailFootSales) + "\n(" + string.Format("{0:p}", GBskinCosmeticNailFootSales / GBnetSales) + ")",
                                                        string.Format("{0:c}", PWskinCosmeticNailFootSales) + "\n(" + string.Format("{0:p}", PWskinCosmeticNailFootSales / PWnetSales) + ")",
                                                        string.Format("{0:c}", WBskinCosmeticNailFootSales) + "\n(" + string.Format("{0:p}", WBskinCosmeticNailFootSales / WBnetSales) + ")",
                                                        string.Format("{0:c}", WDskinCosmeticNailFootSales) + "\n(" + string.Format("{0:p}", WDskinCosmeticNailFootSales / WDnetSales) + ")",
                                                        string.Format("{0:c}", BWskinCosmeticNailFootSales) + "\n(" + string.Format("{0:p}", BWskinCosmeticNailFootSales / BWnetSales) + ")",
                                                        string.Format("{0:c}", SUMskinCosmeticNailFootSales) + "\n(" + string.Format("{0:p}", SUMskinCosmeticNailFootSales / SUMnetSales) + ")");
                dt.Rows.Add("GENERAL MERCHANDISE", string.Format("{0:c}", THgeneralMerchandiseSales) + "\n(" + string.Format("{0:p}", THgeneralMerchandiseSales / THnetSales) + ")",
                                                   string.Format("{0:c}", OHgeneralMerchandiseSales) + "\n(" + string.Format("{0:p}", OHgeneralMerchandiseSales / OHnetSales) + ")",
                                                   string.Format("{0:c}", UMgeneralMerchandiseSales) + "\n(" + string.Format("{0:p}", UMgeneralMerchandiseSales / UMnetSales) + ")",
                                                   string.Format("{0:c}", CHgeneralMerchandiseSales) + "\n(" + string.Format("{0:p}", CHgeneralMerchandiseSales / CHnetSales) + ")",
                                                   string.Format("{0:c}", WMgeneralMerchandiseSales) + "\n(" + string.Format("{0:p}", WMgeneralMerchandiseSales / WMnetSales) + ")",
                                                   string.Format("{0:c}", CVgeneralMerchandiseSales) + "\n(" + string.Format("{0:p}", CVgeneralMerchandiseSales / CVnetSales) + ")",                                                   
                                                   string.Format("{0:c}", GBgeneralMerchandiseSales) + "\n(" + string.Format("{0:p}", GBgeneralMerchandiseSales / GBnetSales) + ")",
                                                   string.Format("{0:c}", PWgeneralMerchandiseSales) + "\n(" + string.Format("{0:p}", PWgeneralMerchandiseSales / PWnetSales) + ")",
                                                   string.Format("{0:c}", WBgeneralMerchandiseSales) + "\n(" + string.Format("{0:p}", WBgeneralMerchandiseSales / WBnetSales) + ")",
                                                   string.Format("{0:c}", WDgeneralMerchandiseSales) + "\n(" + string.Format("{0:p}", WDgeneralMerchandiseSales / WDnetSales) + ")",
                                                   string.Format("{0:c}", BWgeneralMerchandiseSales) + "\n(" + string.Format("{0:p}", BWgeneralMerchandiseSales / BWnetSales) + ")",
                                                   string.Format("{0:c}", SUMgeneralMerchandiseSales) + "\n(" + string.Format("{0:p}", SUMgeneralMerchandiseSales / SUMnetSales) + ")");
                dt.Rows.Add("POINTS/GIFTCARD REDEEMED", string.Format("{0:c}", THpointRedeemed) + "\n(" + string.Format("{0:p}", THpointRedeemed / THnetSales) + ")",
                                               string.Format("{0:c}", OHpointRedeemed) + "\n(" + string.Format("{0:p}", OHpointRedeemed / OHnetSales) + ")",
                                               string.Format("{0:c}", UMpointRedeemed) + "\n(" + string.Format("{0:p}", UMpointRedeemed / UMnetSales) + ")",
                                               string.Format("{0:c}", CHpointRedeemed) + "\n(" + string.Format("{0:p}", CHpointRedeemed / CHnetSales) + ")",
                                               string.Format("{0:c}", WMpointRedeemed) + "\n(" + string.Format("{0:p}", WMpointRedeemed / WMnetSales) + ")",
                                               string.Format("{0:c}", CVpointRedeemed) + "\n(" + string.Format("{0:p}", CVpointRedeemed / CVnetSales) + ")",
                                               string.Format("{0:c}", GBpointRedeemed) + "\n(" + string.Format("{0:p}", GBpointRedeemed / GBnetSales) + ")",
                                               string.Format("{0:c}", PWpointRedeemed) + "\n(" + string.Format("{0:p}", PWpointRedeemed / PWnetSales) + ")",
                                               string.Format("{0:c}", WBpointRedeemed) + "\n(" + string.Format("{0:p}", WBpointRedeemed / WBnetSales) + ")",
                                               string.Format("{0:c}", WDpointRedeemed) + "\n(" + string.Format("{0:p}", WDpointRedeemed / WDnetSales) + ")",
                                               string.Format("{0:c}", BWpointRedeemed) + "\n(" + string.Format("{0:p}", BWpointRedeemed / BWnetSales) + ")",
                                               string.Format("{0:c}", SUMpointRedeemed) + "\n(" + string.Format("{0:p}", SUMpointRedeemed / SUMnetSales) + ")");

                dt.Rows.Add("SALES", string.Format("{0:c}", THnetSales),
                                         string.Format("{0:c}", OHnetSales),
                                         string.Format("{0:c}", UMnetSales),
                                         string.Format("{0:c}", CHnetSales),
                                         string.Format("{0:c}", WMnetSales),
                                         string.Format("{0:c}", CVnetSales),
                                         string.Format("{0:c}", GBnetSales),
                                         string.Format("{0:c}", PWnetSales),
                                         string.Format("{0:c}", WBnetSales),
                                         string.Format("{0:c}", WDnetSales),
                                         string.Format("{0:c}", BWnetSales),
                                         string.Format("{0:c}", SUMnetSales));
                dt.Rows.Add("TRNs", Convert.ToString(THnumOfTrans),
                                    Convert.ToString(OHnumOfTrans),
                                    Convert.ToString(UMnumOfTrans),
                                    Convert.ToString(CHnumOfTrans),
                                    Convert.ToString(WMnumOfTrans),
                                    Convert.ToString(CVnumOfTrans),
                                    Convert.ToString(GBnumOfTrans),
                                    Convert.ToString(PWnumOfTrans),
                                    Convert.ToString(WBnumOfTrans),
                                    Convert.ToString(WDnumOfTrans),
                                    Convert.ToString(BWnumOfTrans),
                                    Convert.ToString(SUMnumOfTrans));
                dt.Rows.Add("AVERAGE SALES", string.Format("{0:c}", THnetSales / THnumOfTrans),
                                       string.Format("{0:c}", OHnetSales / OHnumOfTrans),
                                       string.Format("{0:c}", UMnetSales / UMnumOfTrans),
                                       string.Format("{0:c}", CHnetSales / CHnumOfTrans),
                                       string.Format("{0:c}", WMnetSales / WMnumOfTrans),
                                       string.Format("{0:c}", CVnetSales / CVnumOfTrans), 
                                       string.Format("{0:c}", GBnetSales / GBnumOfTrans),
                                       string.Format("{0:c}", PWnetSales / PWnumOfTrans),
                                       string.Format("{0:c}", WBnetSales / WBnumOfTrans),
                                       string.Format("{0:c}", WDnetSales / WDnumOfTrans),
                                       string.Format("{0:c}", BWnetSales / BWnumOfTrans),
                                       string.Format("{0:c}", SUMnetSales / SUMnumOfTrans));
                dt.Rows.Add("TAX", string.Format("{0:c}", THtax),
                                   string.Format("{0:c}", OHtax),
                                   string.Format("{0:c}", UMtax),
                                   string.Format("{0:c}", CHtax),
                                   string.Format("{0:c}", WMtax),
                                   string.Format("{0:c}", CVtax),
                                   string.Format("{0:c}", GBtax),
                                   string.Format("{0:c}", PWtax),
                                   string.Format("{0:c}", WBtax),
                                   string.Format("{0:c}", WDtax),
                                   string.Format("{0:c}", BWtax),
                                   string.Format("{0:c}", SUMtax));
                dt.Rows.Add("GROSS SALES", string.Format("{0:c}", THgrossSales),
                                           string.Format("{0:c}", OHgrossSales),
                                           string.Format("{0:c}", UMgrossSales),
                                           string.Format("{0:c}", CHgrossSales),
                                           string.Format("{0:c}", WMgrossSales),
                                           string.Format("{0:c}", CVgrossSales),
                                           string.Format("{0:c}", GBgrossSales),
                                           string.Format("{0:c}", PWgrossSales),
                                           string.Format("{0:c}", WBgrossSales),
                                           string.Format("{0:c}", WDgrossSales),
                                           string.Format("{0:c}", BWgrossSales),
                                           string.Format("{0:c}", SUMgrossSales));

                dataGridView1.RowTemplate.Height = 53;
                dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                dataGridView1.DataSource = dt;

                dataGridView1.Columns[0].HeaderText = "CATEGORY";
                dataGridView1.Columns[0].Width = 110;
                dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

                dataGridView1.Columns[1].Width = 105;
                dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

                dataGridView1.Columns[2].Width = 105;
                dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

                dataGridView1.Columns[3].Width = 105;
                dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

                dataGridView1.Columns[4].Width = 105;
                dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

                dataGridView1.Columns[5].Width = 105;
                dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;

                dataGridView1.Columns[6].Width = 105;
                dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

                dataGridView1.Columns[7].Width = 105;
                dataGridView1.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;

                dataGridView1.Columns[8].Width = 105;
                dataGridView1.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;

                dataGridView1.Columns[9].Width = 105;
                dataGridView1.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;

                dataGridView1.Columns[10].Width = 105;
                dataGridView1.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[10].SortMode = DataGridViewColumnSortMode.NotSortable;

                dataGridView1.Columns[11].Width = 105;
                dataGridView1.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[11].SortMode = DataGridViewColumnSortMode.NotSortable;

                dataGridView1.Columns[12].Width = 120;
                dataGridView1.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[12].SortMode = DataGridViewColumnSortMode.NotSortable;

                dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.Orange;
                dataGridView1.Columns[12].DefaultCellStyle.BackColor = Color.LightYellow;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                }

                progressBar1.Value = 0;
                btnOK.Enabled = true;
            }
            else if (cmbOption.SelectedIndex == 1)
            {
                startDate = txtStartDate.Text.Trim();

                if (startDate == "")
                {
                    MessageBox.Show("SELECT START DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (Convert.ToDateTime(startDate).DayOfWeek != DayOfWeek.Sunday)
                    {
                        btnOK.Enabled = false;
                        dt2_All.Clear();

                        OHhoulySalesTotal = 0; CHhoulySalesTotal = 0; CVhoulySalesTotal = 0; UMhoulySalesTotal = 0; WMhoulySalesTotal = 0;
                        WBhoulySalesTotal = 0; THhoulySalesTotal = 0; WDhoulySalesTotal = 0; PWhoulySalesTotal = 0; GBhoulySalesTotal = 0;
                        BWhoulySalesTotal = 0;

                        try
                        {
                            hour = Convert.ToDateTime("9:00:00");

                            for (int i = 9; i <= 21; i++)
                            {
                                sHour = hour.ToString("T");

                                cmd.CommandText = "Sales_History_Hourly_By_Store";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = connTH;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = startDate;
                                cmd.Parameters.Add("@StartHour", SqlDbType.NVarChar).Value = sHour;

                                hour = hour.AddHours(1);
                                sHour = hour.ToString("T");

                                cmd.Parameters.Add("@EndHour", SqlDbType.NVarChar).Value = sHour;

                                SqlParameter HourlySales_Param = cmd.Parameters.Add("@HourlySales", SqlDbType.Money);
                                HourlySales_Param.Direction = ParameterDirection.Output;

                                connTH.Open();
                                cmd.ExecuteNonQuery();
                                connTH.Close();

                                if (cmd.Parameters["@HourlySales"].Value != DBNull.Value)
                                    THHoulySales[i - 9] = Convert.ToDouble(cmd.Parameters["@HourlySales"].Value);

                                THhoulySalesTotal = THhoulySalesTotal + THHoulySales[i - 9];
                            }

                            progressBar1.PerformStep();
                        }
                        catch
                        {
                            MessageBox.Show("CAN NOT CONNECT TEMPLE HILLS SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            connTH.Close();
                        }

                        try
                        {
                            hour = Convert.ToDateTime("9:00:00");

                            for (int i = 9; i <= 21; i++)
                            {
                                sHour = hour.ToString("T");

                                cmd.CommandText = "Sales_History_Hourly_By_Store";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = connOH;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = startDate;
                                cmd.Parameters.Add("@StartHour", SqlDbType.NVarChar).Value = sHour;

                                hour = hour.AddHours(1);
                                sHour = hour.ToString("T");

                                cmd.Parameters.Add("@EndHour", SqlDbType.NVarChar).Value = sHour;

                                SqlParameter HourlySales_Param = cmd.Parameters.Add("@HourlySales", SqlDbType.Money);
                                HourlySales_Param.Direction = ParameterDirection.Output;

                                connOH.Open();
                                cmd.ExecuteNonQuery();
                                connOH.Close();

                                if (cmd.Parameters["@HourlySales"].Value != DBNull.Value)
                                    OHHoulySales[i - 9] = Convert.ToDouble(cmd.Parameters["@HourlySales"].Value);

                                OHhoulySalesTotal = OHhoulySalesTotal + OHHoulySales[i - 9];
                            }

                            progressBar1.PerformStep();
                        }
                        catch
                        {
                            MessageBox.Show("CAN NOT CONNECT OXON HILL SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            connOH.Close();
                        }

                        try
                        {
                            hour = Convert.ToDateTime("9:00:00");

                            for (int i = 9; i <= 21; i++)
                            {
                                sHour = hour.ToString("T");

                                cmd.CommandText = "Sales_History_Hourly_By_Store";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = connCH;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = startDate;
                                cmd.Parameters.Add("@StartHour", SqlDbType.NVarChar).Value = sHour;

                                hour = hour.AddHours(1);
                                sHour = hour.ToString("T");

                                cmd.Parameters.Add("@EndHour", SqlDbType.NVarChar).Value = sHour;

                                SqlParameter HourlySales_Param = cmd.Parameters.Add("@HourlySales", SqlDbType.Money);
                                HourlySales_Param.Direction = ParameterDirection.Output;

                                connCH.Open();
                                cmd.ExecuteNonQuery();
                                connCH.Close();

                                if (cmd.Parameters["@HourlySales"].Value != DBNull.Value)
                                    CHHoulySales[i - 9] = Convert.ToDouble(cmd.Parameters["@HourlySales"].Value);

                                CHhoulySalesTotal = CHhoulySalesTotal + CHHoulySales[i - 9];
                            }

                            progressBar1.PerformStep();
                        }
                        catch
                        {
                            MessageBox.Show("CAN NOT CONNECT CAPITOL HEIGHTS SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            connCH.Close();
                        }

                        try
                        {
                            hour = Convert.ToDateTime("9:00:00");

                            for (int i = 9; i <= 21; i++)
                            {
                                sHour = hour.ToString("T");

                                cmd.CommandText = "Sales_History_Hourly_By_Store";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = connCV;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = startDate;
                                cmd.Parameters.Add("@StartHour", SqlDbType.NVarChar).Value = sHour;

                                hour = hour.AddHours(1);
                                sHour = hour.ToString("T");

                                cmd.Parameters.Add("@EndHour", SqlDbType.NVarChar).Value = sHour;

                                SqlParameter HourlySales_Param = cmd.Parameters.Add("@HourlySales", SqlDbType.Money);
                                HourlySales_Param.Direction = ParameterDirection.Output;

                                connCV.Open();
                                cmd.ExecuteNonQuery();
                                connCV.Close();

                                if (cmd.Parameters["@HourlySales"].Value != DBNull.Value)
                                    CVHoulySales[i - 9] = Convert.ToDouble(cmd.Parameters["@HourlySales"].Value);

                                CVhoulySalesTotal = CVhoulySalesTotal + CVHoulySales[i - 9];
                            }

                            progressBar1.PerformStep();
                        }
                        catch
                        {
                            MessageBox.Show("CAN NOT CONNECT CATONSVILLE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            connCV.Close();
                        }

                        try
                        {
                            hour = Convert.ToDateTime("9:00:00");

                            for (int i = 9; i <= 21; i++)
                            {
                                sHour = hour.ToString("T");

                                cmd.CommandText = "Sales_History_Hourly_By_Store";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = connUM;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = startDate;
                                cmd.Parameters.Add("@StartHour", SqlDbType.NVarChar).Value = sHour;

                                hour = hour.AddHours(1);
                                sHour = hour.ToString("T");

                                cmd.Parameters.Add("@EndHour", SqlDbType.NVarChar).Value = sHour;

                                SqlParameter HourlySales_Param = cmd.Parameters.Add("@HourlySales", SqlDbType.Money);
                                HourlySales_Param.Direction = ParameterDirection.Output;

                                connUM.Open();
                                cmd.ExecuteNonQuery();
                                connUM.Close();

                                if (cmd.Parameters["@HourlySales"].Value != DBNull.Value)
                                    UMHoulySales[i - 9] = Convert.ToDouble(cmd.Parameters["@HourlySales"].Value);

                                UMhoulySalesTotal = UMhoulySalesTotal + UMHoulySales[i - 9];
                            }

                            progressBar1.PerformStep();
                        }
                        catch
                        {
                            MessageBox.Show("CAN NOT CONNECT UPPER MARLBORO SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            connUM.Close();
                        }

                        try
                        {
                            hour = Convert.ToDateTime("9:00:00");

                            for (int i = 9; i <= 21; i++)
                            {
                                sHour = hour.ToString("T");

                                cmd.CommandText = "Sales_History_Hourly_By_Store";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = connWM;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = startDate;
                                cmd.Parameters.Add("@StartHour", SqlDbType.NVarChar).Value = sHour;

                                hour = hour.AddHours(1);
                                sHour = hour.ToString("T");

                                cmd.Parameters.Add("@EndHour", SqlDbType.NVarChar).Value = sHour;

                                SqlParameter HourlySales_Param = cmd.Parameters.Add("@HourlySales", SqlDbType.Money);
                                HourlySales_Param.Direction = ParameterDirection.Output;

                                connWM.Open();
                                cmd.ExecuteNonQuery();
                                connWM.Close();

                                if (cmd.Parameters["@HourlySales"].Value != DBNull.Value)
                                    WMHoulySales[i - 9] = Convert.ToDouble(cmd.Parameters["@HourlySales"].Value);

                                WMhoulySalesTotal = WMhoulySalesTotal + WMHoulySales[i - 9];
                            }

                            progressBar1.PerformStep();
                        }
                        catch
                        {
                            MessageBox.Show("CAN NOT CONNECT WINDSOR MILL SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            connWM.Close();
                        }

                        try
                        {
                            hour = Convert.ToDateTime("9:00:00");

                            for (int i = 9; i <= 21; i++)
                            {
                                sHour = hour.ToString("T");

                                cmd.CommandText = "Sales_History_Hourly_By_Store";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = connWB;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = startDate;
                                cmd.Parameters.Add("@StartHour", SqlDbType.NVarChar).Value = sHour;

                                hour = hour.AddHours(1);
                                sHour = hour.ToString("T");

                                cmd.Parameters.Add("@EndHour", SqlDbType.NVarChar).Value = sHour;

                                SqlParameter HourlySales_Param = cmd.Parameters.Add("@HourlySales", SqlDbType.Money);
                                HourlySales_Param.Direction = ParameterDirection.Output;

                                connWB.Open();
                                cmd.ExecuteNonQuery();
                                connWB.Close();

                                if (cmd.Parameters["@HourlySales"].Value != DBNull.Value)
                                    WBHoulySales[i - 9] = Convert.ToDouble(cmd.Parameters["@HourlySales"].Value);

                                WBhoulySalesTotal = WBhoulySalesTotal + WBHoulySales[i - 9];
                            }

                            progressBar1.PerformStep();
                        }
                        catch
                        {
                            MessageBox.Show("CAN NOT CONNECT WOODBRIDGE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            connWB.Close();
                        }

                        try
                        {
                            hour = Convert.ToDateTime("9:00:00");

                            for (int i = 9; i <= 21; i++)
                            {
                                sHour = hour.ToString("T");

                                cmd.CommandText = "Sales_History_Hourly_By_Store";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = connWD;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = startDate;
                                cmd.Parameters.Add("@StartHour", SqlDbType.NVarChar).Value = sHour;

                                hour = hour.AddHours(1);
                                sHour = hour.ToString("T");

                                cmd.Parameters.Add("@EndHour", SqlDbType.NVarChar).Value = sHour;

                                SqlParameter HourlySales_Param = cmd.Parameters.Add("@HourlySales", SqlDbType.Money);
                                HourlySales_Param.Direction = ParameterDirection.Output;

                                connWD.Open();
                                cmd.ExecuteNonQuery();
                                connWD.Close();

                                if (cmd.Parameters["@HourlySales"].Value != DBNull.Value)
                                    WDHoulySales[i - 9] = Convert.ToDouble(cmd.Parameters["@HourlySales"].Value);

                                WDhoulySalesTotal = WDhoulySalesTotal + WDHoulySales[i - 9];
                            }

                            progressBar1.PerformStep();
                        }
                        catch
                        {
                            MessageBox.Show("CAN NOT CONNECT WALDORF SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            connWD.Close();
                        }

                        try
                        {
                            hour = Convert.ToDateTime("9:00:00");

                            for (int i = 9; i <= 21; i++)
                            {
                                sHour = hour.ToString("T");

                                cmd.CommandText = "Sales_History_Hourly_By_Store";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = connPW;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = startDate;
                                cmd.Parameters.Add("@StartHour", SqlDbType.NVarChar).Value = sHour;

                                hour = hour.AddHours(1);
                                sHour = hour.ToString("T");

                                cmd.Parameters.Add("@EndHour", SqlDbType.NVarChar).Value = sHour;

                                SqlParameter HourlySales_Param = cmd.Parameters.Add("@HourlySales", SqlDbType.Money);
                                HourlySales_Param.Direction = ParameterDirection.Output;

                                connPW.Open();
                                cmd.ExecuteNonQuery();
                                connPW.Close();

                                if (cmd.Parameters["@HourlySales"].Value != DBNull.Value)
                                    PWHoulySales[i - 9] = Convert.ToDouble(cmd.Parameters["@HourlySales"].Value);

                                PWhoulySalesTotal = PWhoulySalesTotal + PWHoulySales[i - 9];
                            }

                            progressBar1.PerformStep();
                        }
                        catch
                        {
                            MessageBox.Show("CAN NOT CONNECT PRINCE WILLIAM SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            connPW.Close();
                        }

                        try
                        {
                            hour = Convert.ToDateTime("9:00:00");

                            for (int i = 9; i <= 21; i++)
                            {
                                sHour = hour.ToString("T");

                                cmd.CommandText = "Sales_History_Hourly_By_Store";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = connGB;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = startDate;
                                cmd.Parameters.Add("@StartHour", SqlDbType.NVarChar).Value = sHour;

                                hour = hour.AddHours(1);
                                sHour = hour.ToString("T");

                                cmd.Parameters.Add("@EndHour", SqlDbType.NVarChar).Value = sHour;

                                SqlParameter HourlySales_Param = cmd.Parameters.Add("@HourlySales", SqlDbType.Money);
                                HourlySales_Param.Direction = ParameterDirection.Output;

                                connGB.Open();
                                cmd.ExecuteNonQuery();
                                connGB.Close();

                                if (cmd.Parameters["@HourlySales"].Value != DBNull.Value)
                                    GBHoulySales[i - 9] = Convert.ToDouble(cmd.Parameters["@HourlySales"].Value);

                                GBhoulySalesTotal = GBhoulySalesTotal + GBHoulySales[i - 9];
                            }

                            progressBar1.PerformStep();
                        }
                        catch
                        {
                            MessageBox.Show("CAN NOT CONNECT GAITHERSBURG SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            connGB.Close();
                        }

                        try
                        {
                            hour = Convert.ToDateTime("9:00:00");

                            for (int i = 9; i <= 21; i++)
                            {
                                sHour = hour.ToString("T");

                                cmd.CommandText = "Sales_History_Hourly_By_Store";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = connBW;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = startDate;
                                cmd.Parameters.Add("@StartHour", SqlDbType.NVarChar).Value = sHour;

                                hour = hour.AddHours(1);
                                sHour = hour.ToString("T");

                                cmd.Parameters.Add("@EndHour", SqlDbType.NVarChar).Value = sHour;

                                SqlParameter HourlySales_Param = cmd.Parameters.Add("@HourlySales", SqlDbType.Money);
                                HourlySales_Param.Direction = ParameterDirection.Output;

                                connBW.Open();
                                cmd.ExecuteNonQuery();
                                connBW.Close();

                                if (cmd.Parameters["@HourlySales"].Value != DBNull.Value)
                                    BWHoulySales[i - 9] = Convert.ToDouble(cmd.Parameters["@HourlySales"].Value);

                                BWhoulySalesTotal = BWhoulySalesTotal + BWHoulySales[i - 9];
                            }

                            progressBar1.PerformStep();
                        }
                        catch
                        {
                            MessageBox.Show("CAN NOT CONNECT BOWIE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            connBW.Close();
                        }

                        for (int i = 0; i <= 12; i++)
                        {
                            dt2_All.Rows.Add(Convert.ToString(i + 9),
                                         string.Format("{0:c}",THHoulySales[i]),
                                         string.Format("{0:c}", OHHoulySales[i]),
                                         string.Format("{0:c}", UMHoulySales[i]),
                                         string.Format("{0:c}", CHHoulySales[i]),
                                         string.Format("{0:c}", WMHoulySales[i]),
                                         string.Format("{0:c}", CVHoulySales[i]),
                                         string.Format("{0:c}", GBHoulySales[i]),
                                         string.Format("{0:c}", PWHoulySales[i]),
                                         string.Format("{0:c}", WBHoulySales[i]),
                                         string.Format("{0:c}", WDHoulySales[i]),
                                         string.Format("{0:c}", BWHoulySales[i]),
                                         string.Format("{0:c}", OHHoulySales[i] + CHHoulySales[i] + UMHoulySales[i] + WMHoulySales[i] + CVHoulySales[i] + WBHoulySales[i] + THHoulySales[i] + WDHoulySales[i] + PWHoulySales[i] + GBHoulySales[i] + BWHoulySales[i]));
                        }

                        dt2_All.Rows.Add("TOTAL", string.Format("{0:c}", THhoulySalesTotal),
                                              string.Format("{0:c}", OHhoulySalesTotal),
                                              string.Format("{0:c}", UMhoulySalesTotal),
                                              string.Format("{0:c}", CHhoulySalesTotal),
                                              string.Format("{0:c}", WMhoulySalesTotal),
                                              string.Format("{0:c}", CVhoulySalesTotal),
                                              string.Format("{0:c}", GBhoulySalesTotal),
                                              string.Format("{0:c}", PWhoulySalesTotal),
                                              string.Format("{0:c}", WBhoulySalesTotal),
                                              string.Format("{0:c}", WDhoulySalesTotal),
                                              string.Format("{0:c}", BWhoulySalesTotal),
                                              string.Format("{0:c}", OHhoulySalesTotal + CHhoulySalesTotal + UMhoulySalesTotal + WMhoulySalesTotal + CVhoulySalesTotal + WBhoulySalesTotal + THhoulySalesTotal + WDhoulySalesTotal + PWhoulySalesTotal + GBhoulySalesTotal + BWhoulySalesTotal));

                        dataGridView2.RowTemplate.Height = 45;
                        dataGridView2.RowTemplate.DefaultCellStyle.Font = drvFont;
                        dataGridView2.DataSource = dt2_All;

                        dataGridView2.Columns[0].HeaderText = "HOUR";
                        dataGridView2.Columns[0].Width = 110;
                        dataGridView2.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

                        dataGridView2.Columns[1].Width = 105;
                        dataGridView2.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

                        dataGridView2.Columns[2].Width = 105;
                        dataGridView2.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

                        dataGridView2.Columns[3].Width = 105;
                        dataGridView2.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

                        dataGridView2.Columns[4].Width = 105;
                        dataGridView2.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

                        dataGridView2.Columns[5].Width = 105;
                        dataGridView2.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;

                        dataGridView2.Columns[6].Width = 105;
                        dataGridView2.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

                        dataGridView2.Columns[7].Width = 105;
                        dataGridView2.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;

                        dataGridView2.Columns[8].Width = 105;
                        dataGridView2.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;

                        dataGridView2.Columns[9].Width = 105;
                        dataGridView2.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;

                        dataGridView2.Columns[10].Width = 105;
                        dataGridView2.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[10].SortMode = DataGridViewColumnSortMode.NotSortable;

                        dataGridView2.Columns[11].Width = 105;
                        dataGridView2.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[11].SortMode = DataGridViewColumnSortMode.NotSortable;

                        dataGridView2.Columns[12].Width = 120;
                        dataGridView2.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[12].SortMode = DataGridViewColumnSortMode.NotSortable;

                        dataGridView2.Columns[0].DefaultCellStyle.BackColor = Color.Orange;
                        dataGridView2.Columns[12].DefaultCellStyle.BackColor = Color.LightYellow;

                        for (int i = 0; i < dataGridView2.RowCount; i++)
                        {
                            dataGridView2.Rows[i].Selected = false;
                        }

                        progressBar1.Value = 0;
                        btnOK.Enabled = true;
                    }
                    else
                    {
                        btnOK.Enabled = false;
                        dt2_All.Clear();

                        OHhoulySalesTotal = 0; CHhoulySalesTotal = 0; CVhoulySalesTotal = 0; UMhoulySalesTotal = 0; WMhoulySalesTotal = 0;
                        WBhoulySalesTotal = 0; THhoulySalesTotal = 0; WDhoulySalesTotal = 0; PWhoulySalesTotal = 0; GBhoulySalesTotal = 0;
                        BWhoulySalesTotal = 0;

                        try
                        {
                            hour = Convert.ToDateTime("10:00:00");

                            for (int i = 10; i <= 18; i++)
                            {
                                sHour = hour.ToString("T");

                                cmd.CommandText = "Sales_History_Hourly_By_Store";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = connTH;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = startDate;
                                cmd.Parameters.Add("@StartHour", SqlDbType.NVarChar).Value = sHour;

                                hour = hour.AddHours(1);
                                sHour = hour.ToString("T");

                                cmd.Parameters.Add("@EndHour", SqlDbType.NVarChar).Value = sHour;

                                SqlParameter HourlySales_Param = cmd.Parameters.Add("@HourlySales", SqlDbType.Money);
                                HourlySales_Param.Direction = ParameterDirection.Output;

                                connTH.Open();
                                cmd.ExecuteNonQuery();
                                connTH.Close();

                                if (cmd.Parameters["@HourlySales"].Value != DBNull.Value)
                                    THHoulySales[i - 10] = Convert.ToDouble(cmd.Parameters["@HourlySales"].Value);

                                THhoulySalesTotal = THhoulySalesTotal + THHoulySales[i - 10];
                            }

                            progressBar1.PerformStep();
                        }
                        catch
                        {
                            MessageBox.Show("CAN NOT CONNECT TEMPLE HILLS SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            connTH.Close();
                        }

                        try
                        {
                            hour = Convert.ToDateTime("10:00:00");

                            for (int i = 10; i <= 18; i++)
                            {
                                sHour = hour.ToString("T");

                                cmd.CommandText = "Sales_History_Hourly_By_Store";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = connOH;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = startDate;
                                cmd.Parameters.Add("@StartHour", SqlDbType.NVarChar).Value = sHour;

                                hour = hour.AddHours(1);
                                sHour = hour.ToString("T");

                                cmd.Parameters.Add("@EndHour", SqlDbType.NVarChar).Value = sHour;

                                SqlParameter HourlySales_Param = cmd.Parameters.Add("@HourlySales", SqlDbType.Money);
                                HourlySales_Param.Direction = ParameterDirection.Output;

                                connOH.Open();
                                cmd.ExecuteNonQuery();
                                connOH.Close();

                                if (cmd.Parameters["@HourlySales"].Value != DBNull.Value)
                                    OHHoulySales[i - 10] = Convert.ToDouble(cmd.Parameters["@HourlySales"].Value);

                                OHhoulySalesTotal = OHhoulySalesTotal + OHHoulySales[i - 10];
                            }

                            progressBar1.PerformStep();
                        }
                        catch
                        {
                            MessageBox.Show("CAN NOT CONNECT OXON HILL SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            connOH.Close();
                        }

                        try
                        {
                            hour = Convert.ToDateTime("10:00:00");

                            for (int i = 10; i <= 18; i++)
                            {
                                sHour = hour.ToString("T");

                                cmd.CommandText = "Sales_History_Hourly_By_Store";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = connCH;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = startDate;
                                cmd.Parameters.Add("@StartHour", SqlDbType.NVarChar).Value = sHour;

                                hour = hour.AddHours(1);
                                sHour = hour.ToString("T");

                                cmd.Parameters.Add("@EndHour", SqlDbType.NVarChar).Value = sHour;

                                SqlParameter HourlySales_Param = cmd.Parameters.Add("@HourlySales", SqlDbType.Money);
                                HourlySales_Param.Direction = ParameterDirection.Output;

                                connCH.Open();
                                cmd.ExecuteNonQuery();
                                connCH.Close();

                                if (cmd.Parameters["@HourlySales"].Value != DBNull.Value)
                                    CHHoulySales[i - 10] = Convert.ToDouble(cmd.Parameters["@HourlySales"].Value);

                                CHhoulySalesTotal = CHhoulySalesTotal + CHHoulySales[i - 10];
                            }

                            progressBar1.PerformStep();
                        }
                        catch
                        {
                            MessageBox.Show("CAN NOT CONNECT CAPITOL HEIGHTS SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            connCH.Close();
                        }

                        try
                        {
                            hour = Convert.ToDateTime("10:00:00");

                            for (int i = 10; i <= 18; i++)
                            {
                                sHour = hour.ToString("T");

                                cmd.CommandText = "Sales_History_Hourly_By_Store";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = connCV;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = startDate;
                                cmd.Parameters.Add("@StartHour", SqlDbType.NVarChar).Value = sHour;

                                hour = hour.AddHours(1);
                                sHour = hour.ToString("T");

                                cmd.Parameters.Add("@EndHour", SqlDbType.NVarChar).Value = sHour;

                                SqlParameter HourlySales_Param = cmd.Parameters.Add("@HourlySales", SqlDbType.Money);
                                HourlySales_Param.Direction = ParameterDirection.Output;

                                connCV.Open();
                                cmd.ExecuteNonQuery();
                                connCV.Close();

                                if (cmd.Parameters["@HourlySales"].Value != DBNull.Value)
                                    CVHoulySales[i - 10] = Convert.ToDouble(cmd.Parameters["@HourlySales"].Value);

                                CVhoulySalesTotal = CVhoulySalesTotal + CVHoulySales[i - 10];
                            }

                            progressBar1.PerformStep();
                        }
                        catch
                        {
                            MessageBox.Show("CAN NOT CONNECT CATONSVILLE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            connCV.Close();
                        }

                        try
                        {
                            hour = Convert.ToDateTime("10:00:00");

                            for (int i = 10; i <= 18; i++)
                            {
                                sHour = hour.ToString("T");

                                cmd.CommandText = "Sales_History_Hourly_By_Store";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = connUM;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = startDate;
                                cmd.Parameters.Add("@StartHour", SqlDbType.NVarChar).Value = sHour;

                                hour = hour.AddHours(1);
                                sHour = hour.ToString("T");

                                cmd.Parameters.Add("@EndHour", SqlDbType.NVarChar).Value = sHour;

                                SqlParameter HourlySales_Param = cmd.Parameters.Add("@HourlySales", SqlDbType.Money);
                                HourlySales_Param.Direction = ParameterDirection.Output;

                                connUM.Open();
                                cmd.ExecuteNonQuery();
                                connUM.Close();

                                if (cmd.Parameters["@HourlySales"].Value != DBNull.Value)
                                    UMHoulySales[i - 10] = Convert.ToDouble(cmd.Parameters["@HourlySales"].Value);

                                UMhoulySalesTotal = UMhoulySalesTotal + UMHoulySales[i - 10];
                            }

                            progressBar1.PerformStep();
                        }
                        catch
                        {
                            MessageBox.Show("CAN NOT CONNECT UPPER MARLBORO SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            connUM.Close();
                        }

                        try
                        {
                            hour = Convert.ToDateTime("10:00:00");

                            for (int i = 10; i <= 18; i++)
                            {
                                sHour = hour.ToString("T");

                                cmd.CommandText = "Sales_History_Hourly_By_Store";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = connWM;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = startDate;
                                cmd.Parameters.Add("@StartHour", SqlDbType.NVarChar).Value = sHour;

                                hour = hour.AddHours(1);
                                sHour = hour.ToString("T");

                                cmd.Parameters.Add("@EndHour", SqlDbType.NVarChar).Value = sHour;

                                SqlParameter HourlySales_Param = cmd.Parameters.Add("@HourlySales", SqlDbType.Money);
                                HourlySales_Param.Direction = ParameterDirection.Output;

                                connWM.Open();
                                cmd.ExecuteNonQuery();
                                connWM.Close();

                                if (cmd.Parameters["@HourlySales"].Value != DBNull.Value)
                                    WMHoulySales[i - 10] = Convert.ToDouble(cmd.Parameters["@HourlySales"].Value);

                                WMhoulySalesTotal = WMhoulySalesTotal + WMHoulySales[i - 10];
                            }

                            progressBar1.PerformStep();
                        }
                        catch
                        {
                            MessageBox.Show("CAN NOT CONNECT WINDSOR MILL SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            connWM.Close();
                        }

                        try
                        {
                            hour = Convert.ToDateTime("10:00:00");

                            for (int i = 10; i <= 18; i++)
                            {
                                sHour = hour.ToString("T");

                                cmd.CommandText = "Sales_History_Hourly_By_Store";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = connWB;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = startDate;
                                cmd.Parameters.Add("@StartHour", SqlDbType.NVarChar).Value = sHour;

                                hour = hour.AddHours(1);
                                sHour = hour.ToString("T");

                                cmd.Parameters.Add("@EndHour", SqlDbType.NVarChar).Value = sHour;

                                SqlParameter HourlySales_Param = cmd.Parameters.Add("@HourlySales", SqlDbType.Money);
                                HourlySales_Param.Direction = ParameterDirection.Output;

                                connWB.Open();
                                cmd.ExecuteNonQuery();
                                connWB.Close();

                                if (cmd.Parameters["@HourlySales"].Value != DBNull.Value)
                                    WBHoulySales[i - 10] = Convert.ToDouble(cmd.Parameters["@HourlySales"].Value);

                                WBhoulySalesTotal = WBhoulySalesTotal + WBHoulySales[i - 10];
                            }

                            progressBar1.PerformStep();
                        }
                        catch
                        {
                            MessageBox.Show("CAN NOT CONNECT WOODBRIDGE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            connWB.Close();
                        }

                        try
                        {
                            hour = Convert.ToDateTime("10:00:00");

                            for (int i = 10; i <= 18; i++)
                            {
                                sHour = hour.ToString("T");

                                cmd.CommandText = "Sales_History_Hourly_By_Store";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = connWD;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = startDate;
                                cmd.Parameters.Add("@StartHour", SqlDbType.NVarChar).Value = sHour;

                                hour = hour.AddHours(1);
                                sHour = hour.ToString("T");

                                cmd.Parameters.Add("@EndHour", SqlDbType.NVarChar).Value = sHour;

                                SqlParameter HourlySales_Param = cmd.Parameters.Add("@HourlySales", SqlDbType.Money);
                                HourlySales_Param.Direction = ParameterDirection.Output;

                                connWD.Open();
                                cmd.ExecuteNonQuery();
                                connWD.Close();

                                if (cmd.Parameters["@HourlySales"].Value != DBNull.Value)
                                    WDHoulySales[i - 10] = Convert.ToDouble(cmd.Parameters["@HourlySales"].Value);

                                WDhoulySalesTotal = WDhoulySalesTotal + WDHoulySales[i - 10];
                            }

                            progressBar1.PerformStep();
                        }
                        catch
                        {
                            MessageBox.Show("CAN NOT CONNECT WALDORF SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            connWD.Close();
                        }

                        try
                        {
                            hour = Convert.ToDateTime("10:00:00");

                            for (int i = 10; i <= 18; i++)
                            {
                                sHour = hour.ToString("T");

                                cmd.CommandText = "Sales_History_Hourly_By_Store";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = connPW;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = startDate;
                                cmd.Parameters.Add("@StartHour", SqlDbType.NVarChar).Value = sHour;

                                hour = hour.AddHours(1);
                                sHour = hour.ToString("T");

                                cmd.Parameters.Add("@EndHour", SqlDbType.NVarChar).Value = sHour;

                                SqlParameter HourlySales_Param = cmd.Parameters.Add("@HourlySales", SqlDbType.Money);
                                HourlySales_Param.Direction = ParameterDirection.Output;

                                connPW.Open();
                                cmd.ExecuteNonQuery();
                                connPW.Close();

                                if (cmd.Parameters["@HourlySales"].Value != DBNull.Value)
                                    PWHoulySales[i - 10] = Convert.ToDouble(cmd.Parameters["@HourlySales"].Value);

                                PWhoulySalesTotal = PWhoulySalesTotal + PWHoulySales[i - 10];
                            }

                            progressBar1.PerformStep();
                        }
                        catch
                        {
                            MessageBox.Show("CAN NOT CONNECT PRINCE WILLIAM SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            connPW.Close();
                        }

                        try
                        {
                            hour = Convert.ToDateTime("10:00:00");

                            for (int i = 10; i <= 18; i++)
                            {
                                sHour = hour.ToString("T");

                                cmd.CommandText = "Sales_History_Hourly_By_Store";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = connGB;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = startDate;
                                cmd.Parameters.Add("@StartHour", SqlDbType.NVarChar).Value = sHour;

                                hour = hour.AddHours(1);
                                sHour = hour.ToString("T");

                                cmd.Parameters.Add("@EndHour", SqlDbType.NVarChar).Value = sHour;

                                SqlParameter HourlySales_Param = cmd.Parameters.Add("@HourlySales", SqlDbType.Money);
                                HourlySales_Param.Direction = ParameterDirection.Output;

                                connGB.Open();
                                cmd.ExecuteNonQuery();
                                connGB.Close();

                                if (cmd.Parameters["@HourlySales"].Value != DBNull.Value)
                                    GBHoulySales[i - 10] = Convert.ToDouble(cmd.Parameters["@HourlySales"].Value);

                                GBhoulySalesTotal = GBhoulySalesTotal + GBHoulySales[i - 10];
                            }

                            progressBar1.PerformStep();
                        }
                        catch
                        {
                            MessageBox.Show("CAN NOT CONNECT GAITHERSBURG SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            connGB.Close();
                        }

                        try
                        {
                            hour = Convert.ToDateTime("10:00:00");

                            for (int i = 10; i <= 18; i++)
                            {
                                sHour = hour.ToString("T");

                                cmd.CommandText = "Sales_History_Hourly_By_Store";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = connBW;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = startDate;
                                cmd.Parameters.Add("@StartHour", SqlDbType.NVarChar).Value = sHour;

                                hour = hour.AddHours(1);
                                sHour = hour.ToString("T");

                                cmd.Parameters.Add("@EndHour", SqlDbType.NVarChar).Value = sHour;

                                SqlParameter HourlySales_Param = cmd.Parameters.Add("@HourlySales", SqlDbType.Money);
                                HourlySales_Param.Direction = ParameterDirection.Output;

                                connBW.Open();
                                cmd.ExecuteNonQuery();
                                connBW.Close();

                                if (cmd.Parameters["@HourlySales"].Value != DBNull.Value)
                                    BWHoulySales[i - 10] = Convert.ToDouble(cmd.Parameters["@HourlySales"].Value);

                                BWhoulySalesTotal = BWhoulySalesTotal + BWHoulySales[i - 10];
                            }

                            progressBar1.PerformStep();
                        }
                        catch
                        {
                            MessageBox.Show("CAN NOT CONNECT BOWIE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            connBW.Close();
                        }

                        for (int i = 0; i <= 8; i++)
                        {
                            dt2_All.Rows.Add(Convert.ToString(i + 10),
                                         string.Format("{0:c}", THHoulySales[i]),
                                         string.Format("{0:c}", OHHoulySales[i]),
                                         string.Format("{0:c}", UMHoulySales[i]),
                                         string.Format("{0:c}", CHHoulySales[i]),
                                         string.Format("{0:c}", WMHoulySales[i]),
                                         string.Format("{0:c}", CVHoulySales[i]),
                                         string.Format("{0:c}", GBHoulySales[i]),
                                         string.Format("{0:c}", PWHoulySales[i]),
                                         string.Format("{0:c}", WBHoulySales[i]),
                                         string.Format("{0:c}", WDHoulySales[i]),
                                         string.Format("{0:c}", BWHoulySales[i]),
                                         string.Format("{0:c}", OHHoulySales[i] + CHHoulySales[i] + UMHoulySales[i] + WMHoulySales[i] + CVHoulySales[i] + WBHoulySales[i] + THHoulySales[i] + WDHoulySales[i] + PWHoulySales[i] + GBHoulySales[i] + BWHoulySales[i]));
                        }

                        dt2_All.Rows.Add("TOTAL", string.Format("{0:c}", THhoulySalesTotal),
                                              string.Format("{0:c}", OHhoulySalesTotal),
                                              string.Format("{0:c}", UMhoulySalesTotal),
                                              string.Format("{0:c}", CHhoulySalesTotal),
                                              string.Format("{0:c}", WMhoulySalesTotal),
                                              string.Format("{0:c}", CVhoulySalesTotal),
                                              string.Format("{0:c}", GBhoulySalesTotal),
                                              string.Format("{0:c}", PWhoulySalesTotal),
                                              string.Format("{0:c}", WBhoulySalesTotal),
                                              string.Format("{0:c}", WDhoulySalesTotal),
                                              string.Format("{0:c}", BWhoulySalesTotal),
                                              string.Format("{0:c}", OHhoulySalesTotal + CHhoulySalesTotal + UMhoulySalesTotal + WMhoulySalesTotal + CVhoulySalesTotal + WBhoulySalesTotal + THhoulySalesTotal + WDhoulySalesTotal + PWhoulySalesTotal + GBhoulySalesTotal + BWhoulySalesTotal));

                        dataGridView2.RowTemplate.Height = 45;
                        dataGridView2.RowTemplate.DefaultCellStyle.Font = drvFont;
                        dataGridView2.DataSource = dt2_All;

                        dataGridView2.Columns[0].HeaderText = "HOUR";
                        dataGridView2.Columns[0].Width = 110;
                        dataGridView2.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

                        dataGridView2.Columns[1].Width = 105;
                        dataGridView2.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

                        dataGridView2.Columns[2].Width = 105;
                        dataGridView2.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

                        dataGridView2.Columns[3].Width = 105;
                        dataGridView2.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

                        dataGridView2.Columns[4].Width = 105;
                        dataGridView2.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

                        dataGridView2.Columns[5].Width = 105;
                        dataGridView2.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;

                        dataGridView2.Columns[6].Width = 105;
                        dataGridView2.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

                        dataGridView2.Columns[7].Width = 105;
                        dataGridView2.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;

                        dataGridView2.Columns[8].Width = 105;
                        dataGridView2.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;

                        dataGridView2.Columns[9].Width = 105;
                        dataGridView2.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;

                        dataGridView2.Columns[10].Width = 105;
                        dataGridView2.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[10].SortMode = DataGridViewColumnSortMode.NotSortable;

                        dataGridView2.Columns[11].Width = 105;
                        dataGridView2.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[11].SortMode = DataGridViewColumnSortMode.NotSortable;

                        dataGridView2.Columns[12].Width = 120;
                        dataGridView2.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView2.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[12].SortMode = DataGridViewColumnSortMode.NotSortable;

                        dataGridView2.Columns[0].DefaultCellStyle.BackColor = Color.Orange;
                        dataGridView2.Columns[12].DefaultCellStyle.BackColor = Color.LightYellow;

                        progressBar1.Value = 0;
                        btnOK.Enabled = true;
                    }
                }
            }
            else if (cmbOption.SelectedIndex == 2)
            {
                startDate = txtStartDate.Text.Trim();
                endDate = txtEndDate.Text.Trim();

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

                OHDailySalesTotal = 0;
                CHDailySalesTotal = 0;
                WBDailySalesTotal = 0;
                CVDailySalesTotal = 0;
                UMDailySalesTotal = 0;
                WMDailySalesTotal = 0;
                THDailySalesTotal = 0;
                WDDailySalesTotal = 0;
                PWDailySalesTotal = 0;
                GBDailySalesTotal = 0;
                BWDailySalesTotal = 0;

                OHNumOfTransTotal = 0;
                CHNumOfTransTotal = 0;
                WBNumOfTransTotal = 0;
                CVNumOfTransTotal = 0;
                UMNumOfTransTotal = 0;
                WMNumOfTransTotal = 0;
                THNumOfTransTotal = 0;
                WDNumOfTransTotal = 0;
                PWNumOfTransTotal = 0;
                GBNumOfTransTotal = 0;
                BWNumOfTransTotal = 0;

                OHAveDailySalesTotal = 0;
                CHAveDailySalesTotal = 0;
                WBAveDailySalesTotal = 0;
                CVAveDailySalesTotal = 0;
                UMAveDailySalesTotal = 0;
                WMAveDailySalesTotal = 0;
                THAveDailySalesTotal = 0;
                WDAveDailySalesTotal = 0;
                PWAveDailySalesTotal = 0;
                GBAveDailySalesTotal = 0;
                BWAveDailySalesTotal = 0;

                SUMDailySalesTotal = 0;
                SUMNumOfTrnsTotal = 0;
                SUMAveDailySalesTotal = 0;

                btnOK.Enabled = false;
                dt3.Clear();
                TimeSpan t = Convert.ToDateTime(endDate).Subtract(Convert.ToDateTime(startDate));
                days = t.Days;

                if (startDate == endDate)
                {
                    try
                    {
                        cmd.CommandText = "Sales_History_Daily_By_Store";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = connTH;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = startDate;
                        SqlParameter DailySales_Param = cmd.Parameters.Add("@DailySales", SqlDbType.Money);
                        SqlParameter NumOfTrans_Param = cmd.Parameters.Add("@NumOfTrans", SqlDbType.Int);
                        SqlParameter AveDailySales_Param = cmd.Parameters.Add("@AveDailySales", SqlDbType.Money);
                        DailySales_Param.Direction = ParameterDirection.Output;
                        NumOfTrans_Param.Direction = ParameterDirection.Output;
                        AveDailySales_Param.Direction = ParameterDirection.Output;

                        connTH.Open();
                        cmd.ExecuteNonQuery();
                        connTH.Close();

                        if (cmd.Parameters["@DailySales"].Value != DBNull.Value)
                            THDailySales[0] = Convert.ToDouble(cmd.Parameters["@DailySales"].Value);

                        if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                            THNumOfTrns[0] = Convert.ToInt16(cmd.Parameters["@NumOfTrans"].Value);

                        if (cmd.Parameters["@AveDailySales"].Value != DBNull.Value)
                            THAveDailySales[0] = Convert.ToDouble(cmd.Parameters["@AveDailySales"].Value);

                        THDailySalesTotal = THDailySalesTotal + THDailySales[0];
                        THNumOfTransTotal = THNumOfTransTotal + THNumOfTrns[0];
                        THAveDailySalesTotal = THDailySalesTotal / THNumOfTransTotal;

                        progressBar1.PerformStep();
                    }
                    catch
                    {
                        MessageBox.Show("CAN NOT CONNECT TEMPLE HILLS SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connTH.Close();
                    }

                    try
                    {
                        cmd.CommandText = "Sales_History_Daily_By_Store";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = connOH;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = startDate;
                        SqlParameter DailySales_Param = cmd.Parameters.Add("@DailySales", SqlDbType.Money);
                        SqlParameter NumOfTrans_Param = cmd.Parameters.Add("@NumOfTrans", SqlDbType.Int);
                        SqlParameter AveDailySales_Param = cmd.Parameters.Add("@AveDailySales", SqlDbType.Money);
                        DailySales_Param.Direction = ParameterDirection.Output;
                        NumOfTrans_Param.Direction = ParameterDirection.Output;
                        AveDailySales_Param.Direction = ParameterDirection.Output;

                        connOH.Open();
                        cmd.ExecuteNonQuery();
                        connOH.Close();

                        if (cmd.Parameters["@DailySales"].Value != DBNull.Value)
                            OHDailySales[0] = Convert.ToDouble(cmd.Parameters["@DailySales"].Value);

                        if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                            OHNumOfTrns[0] = Convert.ToInt16(cmd.Parameters["@NumOfTrans"].Value);

                        if (cmd.Parameters["@AveDailySales"].Value != DBNull.Value)
                            OHAveDailySales[0] = Convert.ToDouble(cmd.Parameters["@AveDailySales"].Value);

                        OHDailySalesTotal = OHDailySalesTotal + OHDailySales[0];
                        OHNumOfTransTotal = OHNumOfTransTotal + OHNumOfTrns[0];
                        OHAveDailySalesTotal = OHDailySalesTotal / OHNumOfTransTotal;

                        progressBar1.PerformStep();
                    }
                    catch
                    {
                        MessageBox.Show("CAN NOT CONNECT OXON HILL SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connOH.Close();
                    }

                    try
                    {
                        cmd.CommandText = "Sales_History_Daily_By_Store";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = connCH;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = startDate;
                        SqlParameter DailySales_Param = cmd.Parameters.Add("@DailySales", SqlDbType.Money);
                        SqlParameter NumOfTrans_Param = cmd.Parameters.Add("@NumOfTrans", SqlDbType.Int);
                        SqlParameter AveDailySales_Param = cmd.Parameters.Add("@AveDailySales", SqlDbType.Money);
                        DailySales_Param.Direction = ParameterDirection.Output;
                        NumOfTrans_Param.Direction = ParameterDirection.Output;
                        AveDailySales_Param.Direction = ParameterDirection.Output;

                        connCH.Open();
                        cmd.ExecuteNonQuery();
                        connCH.Close();

                        if (cmd.Parameters["@DailySales"].Value != DBNull.Value)
                            CHDailySales[0] = Convert.ToDouble(cmd.Parameters["@DailySales"].Value);

                        if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                            CHNumOfTrns[0] = Convert.ToInt16(cmd.Parameters["@NumOfTrans"].Value);

                        if (cmd.Parameters["@AveDailySales"].Value != DBNull.Value)
                            CHAveDailySales[0] = Convert.ToDouble(cmd.Parameters["@AveDailySales"].Value);

                        CHDailySalesTotal = CHDailySalesTotal + CHDailySales[0];
                        CHNumOfTransTotal = CHNumOfTransTotal + CHNumOfTrns[0];
                        CHAveDailySalesTotal = CHDailySalesTotal / CHNumOfTransTotal;

                        progressBar1.PerformStep();
                    }
                    catch
                    {
                        MessageBox.Show("CAN NOT CONNECT CAPITOL HEIGHTS SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connCH.Close();
                    }

                    try
                    {
                        cmd.CommandText = "Sales_History_Daily_By_Store";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = connCV;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = startDate;
                        SqlParameter DailySales_Param = cmd.Parameters.Add("@DailySales", SqlDbType.Money);
                        SqlParameter NumOfTrans_Param = cmd.Parameters.Add("@NumOfTrans", SqlDbType.Int);
                        SqlParameter AveDailySales_Param = cmd.Parameters.Add("@AveDailySales", SqlDbType.Money);
                        DailySales_Param.Direction = ParameterDirection.Output;
                        NumOfTrans_Param.Direction = ParameterDirection.Output;
                        AveDailySales_Param.Direction = ParameterDirection.Output;

                        connCV.Open();
                        cmd.ExecuteNonQuery();
                        connCV.Close();

                        if (cmd.Parameters["@DailySales"].Value != DBNull.Value)
                            CVDailySales[0] = Convert.ToDouble(cmd.Parameters["@DailySales"].Value);

                        if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                            CVNumOfTrns[0] = Convert.ToInt16(cmd.Parameters["@NumOfTrans"].Value);

                        if (cmd.Parameters["@AveDailySales"].Value != DBNull.Value)
                            CVAveDailySales[0] = Convert.ToDouble(cmd.Parameters["@AveDailySales"].Value);

                        CVDailySalesTotal = CVDailySalesTotal + CVDailySales[0];
                        CVNumOfTransTotal = CVNumOfTransTotal + CVNumOfTrns[0];
                        CVAveDailySalesTotal = CVDailySalesTotal / CVNumOfTransTotal;

                        progressBar1.PerformStep();
                    }
                    catch
                    {
                        MessageBox.Show("CAN NOT CONNECT CATONSVILLE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connCV.Close();
                    }

                    try
                    {
                        cmd.CommandText = "Sales_History_Daily_By_Store";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = connUM;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = startDate;
                        SqlParameter DailySales_Param = cmd.Parameters.Add("@DailySales", SqlDbType.Money);
                        SqlParameter NumOfTrans_Param = cmd.Parameters.Add("@NumOfTrans", SqlDbType.Int);
                        SqlParameter AveDailySales_Param = cmd.Parameters.Add("@AveDailySales", SqlDbType.Money);
                        DailySales_Param.Direction = ParameterDirection.Output;
                        NumOfTrans_Param.Direction = ParameterDirection.Output;
                        AveDailySales_Param.Direction = ParameterDirection.Output;

                        connUM.Open();
                        cmd.ExecuteNonQuery();
                        connUM.Close();

                        if (cmd.Parameters["@DailySales"].Value != DBNull.Value)
                            UMDailySales[0] = Convert.ToDouble(cmd.Parameters["@DailySales"].Value);

                        if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                            UMNumOfTrns[0] = Convert.ToInt16(cmd.Parameters["@NumOfTrans"].Value);

                        if (cmd.Parameters["@AveDailySales"].Value != DBNull.Value)
                            UMAveDailySales[0] = Convert.ToDouble(cmd.Parameters["@AveDailySales"].Value);

                        UMDailySalesTotal = UMDailySalesTotal + UMDailySales[0];
                        UMNumOfTransTotal = UMNumOfTransTotal + UMNumOfTrns[0];
                        UMAveDailySalesTotal = UMDailySalesTotal / UMNumOfTransTotal;

                        progressBar1.PerformStep();
                    }
                    catch
                    {
                        MessageBox.Show("CAN NOT CONNECT UPPER MARLBORO SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connUM.Close();
                    }

                    try
                    {
                        cmd.CommandText = "Sales_History_Daily_By_Store";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = connWM;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = startDate;
                        SqlParameter DailySales_Param = cmd.Parameters.Add("@DailySales", SqlDbType.Money);
                        SqlParameter NumOfTrans_Param = cmd.Parameters.Add("@NumOfTrans", SqlDbType.Int);
                        SqlParameter AveDailySales_Param = cmd.Parameters.Add("@AveDailySales", SqlDbType.Money);
                        DailySales_Param.Direction = ParameterDirection.Output;
                        NumOfTrans_Param.Direction = ParameterDirection.Output;
                        AveDailySales_Param.Direction = ParameterDirection.Output;

                        connWM.Open();
                        cmd.ExecuteNonQuery();
                        connWM.Close();

                        if (cmd.Parameters["@DailySales"].Value != DBNull.Value)
                            WMDailySales[0] = Convert.ToDouble(cmd.Parameters["@DailySales"].Value);

                        if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                            WMNumOfTrns[0] = Convert.ToInt16(cmd.Parameters["@NumOfTrans"].Value);

                        if (cmd.Parameters["@AveDailySales"].Value != DBNull.Value)
                            WMAveDailySales[0] = Convert.ToDouble(cmd.Parameters["@AveDailySales"].Value);

                        WMDailySalesTotal = WMDailySalesTotal + WMDailySales[0];
                        WMNumOfTransTotal = WMNumOfTransTotal + WMNumOfTrns[0];
                        WMAveDailySalesTotal = WMDailySalesTotal / WMNumOfTransTotal;

                        progressBar1.PerformStep();
                    }
                    catch
                    {
                        MessageBox.Show("CAN NOT CONNECT WINDSOR MILL SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connWM.Close();
                    }

                    try
                    {
                        cmd.CommandText = "Sales_History_Daily_By_Store";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = connWB;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = startDate;
                        SqlParameter DailySales_Param = cmd.Parameters.Add("@DailySales", SqlDbType.Money);
                        SqlParameter NumOfTrans_Param = cmd.Parameters.Add("@NumOfTrans", SqlDbType.Int);
                        SqlParameter AveDailySales_Param = cmd.Parameters.Add("@AveDailySales", SqlDbType.Money);
                        DailySales_Param.Direction = ParameterDirection.Output;
                        NumOfTrans_Param.Direction = ParameterDirection.Output;
                        AveDailySales_Param.Direction = ParameterDirection.Output;

                        connWB.Open();
                        cmd.ExecuteNonQuery();
                        connWB.Close();

                        if (cmd.Parameters["@DailySales"].Value != DBNull.Value)
                            WBDailySales[0] = Convert.ToDouble(cmd.Parameters["@DailySales"].Value);

                        if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                            WBNumOfTrns[0] = Convert.ToInt16(cmd.Parameters["@NumOfTrans"].Value);

                        if (cmd.Parameters["@AveDailySales"].Value != DBNull.Value)
                            WBAveDailySales[0] = Convert.ToDouble(cmd.Parameters["@AveDailySales"].Value);

                        WBDailySalesTotal = WBDailySalesTotal + WBDailySales[0];
                        WBNumOfTransTotal = WBNumOfTransTotal + WBNumOfTrns[0];
                        WBAveDailySalesTotal = WBDailySalesTotal / WBNumOfTransTotal;

                        progressBar1.PerformStep();
                    }
                    catch
                    {
                        MessageBox.Show("CAN NOT CONNECT WOODBRIDGE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connWB.Close();
                    }

                    try
                    {
                        cmd.CommandText = "Sales_History_Daily_By_Store";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = connWD;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = startDate;
                        SqlParameter DailySales_Param = cmd.Parameters.Add("@DailySales", SqlDbType.Money);
                        SqlParameter NumOfTrans_Param = cmd.Parameters.Add("@NumOfTrans", SqlDbType.Int);
                        SqlParameter AveDailySales_Param = cmd.Parameters.Add("@AveDailySales", SqlDbType.Money);
                        DailySales_Param.Direction = ParameterDirection.Output;
                        NumOfTrans_Param.Direction = ParameterDirection.Output;
                        AveDailySales_Param.Direction = ParameterDirection.Output;

                        connWD.Open();
                        cmd.ExecuteNonQuery();
                        connWD.Close();

                        if (cmd.Parameters["@DailySales"].Value != DBNull.Value)
                            WDDailySales[0] = Convert.ToDouble(cmd.Parameters["@DailySales"].Value);

                        if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                            WDNumOfTrns[0] = Convert.ToInt16(cmd.Parameters["@NumOfTrans"].Value);

                        if (cmd.Parameters["@AveDailySales"].Value != DBNull.Value)
                            WDAveDailySales[0] = Convert.ToDouble(cmd.Parameters["@AveDailySales"].Value);

                        WDDailySalesTotal = WDDailySalesTotal + WDDailySales[0];
                        WDNumOfTransTotal = WDNumOfTransTotal + WDNumOfTrns[0];
                        WDAveDailySalesTotal = WDDailySalesTotal / WDNumOfTransTotal;

                        progressBar1.PerformStep();
                    }
                    catch
                    {
                        MessageBox.Show("CAN NOT CONNECT WALDORF SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connWD.Close();
                    }

                    try
                    {
                        cmd.CommandText = "Sales_History_Daily_By_Store";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = connPW;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = startDate;
                        SqlParameter DailySales_Param = cmd.Parameters.Add("@DailySales", SqlDbType.Money);
                        SqlParameter NumOfTrans_Param = cmd.Parameters.Add("@NumOfTrans", SqlDbType.Int);
                        SqlParameter AveDailySales_Param = cmd.Parameters.Add("@AveDailySales", SqlDbType.Money);
                        DailySales_Param.Direction = ParameterDirection.Output;
                        NumOfTrans_Param.Direction = ParameterDirection.Output;
                        AveDailySales_Param.Direction = ParameterDirection.Output;

                        connPW.Open();
                        cmd.ExecuteNonQuery();
                        connPW.Close();

                        if (cmd.Parameters["@DailySales"].Value != DBNull.Value)
                            PWDailySales[0] = Convert.ToDouble(cmd.Parameters["@DailySales"].Value);

                        if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                            PWNumOfTrns[0] = Convert.ToInt16(cmd.Parameters["@NumOfTrans"].Value);

                        if (cmd.Parameters["@AveDailySales"].Value != DBNull.Value)
                            PWAveDailySales[0] = Convert.ToDouble(cmd.Parameters["@AveDailySales"].Value);

                        PWDailySalesTotal = PWDailySalesTotal + PWDailySales[0];
                        PWNumOfTransTotal = PWNumOfTransTotal + PWNumOfTrns[0];
                        PWAveDailySalesTotal = PWDailySalesTotal / PWNumOfTransTotal;

                        progressBar1.PerformStep();
                    }
                    catch
                    {
                        MessageBox.Show("CAN NOT CONNECT PRINCE WILLIAM SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connPW.Close();
                    }

                    try
                    {
                        cmd.CommandText = "Sales_History_Daily_By_Store";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = connGB;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = startDate;
                        SqlParameter DailySales_Param = cmd.Parameters.Add("@DailySales", SqlDbType.Money);
                        SqlParameter NumOfTrans_Param = cmd.Parameters.Add("@NumOfTrans", SqlDbType.Int);
                        SqlParameter AveDailySales_Param = cmd.Parameters.Add("@AveDailySales", SqlDbType.Money);
                        DailySales_Param.Direction = ParameterDirection.Output;
                        NumOfTrans_Param.Direction = ParameterDirection.Output;
                        AveDailySales_Param.Direction = ParameterDirection.Output;

                        connGB.Open();
                        cmd.ExecuteNonQuery();
                        connGB.Close();

                        if (cmd.Parameters["@DailySales"].Value != DBNull.Value)
                            GBDailySales[0] = Convert.ToDouble(cmd.Parameters["@DailySales"].Value);

                        if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                            GBNumOfTrns[0] = Convert.ToInt16(cmd.Parameters["@NumOfTrans"].Value);

                        if (cmd.Parameters["@AveDailySales"].Value != DBNull.Value)
                            GBAveDailySales[0] = Convert.ToDouble(cmd.Parameters["@AveDailySales"].Value);

                        GBDailySalesTotal = GBDailySalesTotal + GBDailySales[0];
                        GBNumOfTransTotal = GBNumOfTransTotal + GBNumOfTrns[0];
                        GBAveDailySalesTotal = GBDailySalesTotal / GBNumOfTransTotal;

                        progressBar1.PerformStep();
                    }
                    catch
                    {
                        MessageBox.Show("CAN NOT CONNECT GAITHERSBURG SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connGB.Close();
                    }

                    try
                    {
                        cmd.CommandText = "Sales_History_Daily_By_Store";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = connBW;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = startDate;
                        SqlParameter DailySales_Param = cmd.Parameters.Add("@DailySales", SqlDbType.Money);
                        SqlParameter NumOfTrans_Param = cmd.Parameters.Add("@NumOfTrans", SqlDbType.Int);
                        SqlParameter AveDailySales_Param = cmd.Parameters.Add("@AveDailySales", SqlDbType.Money);
                        DailySales_Param.Direction = ParameterDirection.Output;
                        NumOfTrans_Param.Direction = ParameterDirection.Output;
                        AveDailySales_Param.Direction = ParameterDirection.Output;

                        connBW.Open();
                        cmd.ExecuteNonQuery();
                        connBW.Close();

                        if (cmd.Parameters["@DailySales"].Value != DBNull.Value)
                            BWDailySales[0] = Convert.ToDouble(cmd.Parameters["@DailySales"].Value);

                        if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                            BWNumOfTrns[0] = Convert.ToInt16(cmd.Parameters["@NumOfTrans"].Value);

                        if (cmd.Parameters["@AveDailySales"].Value != DBNull.Value)
                            BWAveDailySales[0] = Convert.ToDouble(cmd.Parameters["@AveDailySales"].Value);

                        BWDailySalesTotal = BWDailySalesTotal + BWDailySales[0];
                        BWNumOfTransTotal = BWNumOfTransTotal + BWNumOfTrns[0];
                        BWAveDailySalesTotal = BWDailySalesTotal / BWNumOfTransTotal;

                        progressBar1.PerformStep();
                    }
                    catch
                    {
                        MessageBox.Show("CAN NOT CONNECT BOWIE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connBW.Close();
                    }

                    SUMDailySales[0] = OHDailySales[0] + CHDailySales[0] + CVDailySales[0] + UMDailySales[0] + WMDailySales[0] + WBDailySales[0] + THDailySales[0] + WDDailySales[0] + PWDailySales[0] + GBDailySales[0] + BWDailySales[0];
                    SUMNumOfTrns[0] = OHNumOfTrns[0] + CHNumOfTrns[0] + CVNumOfTrns[0] + UMNumOfTrns[0] + WMNumOfTrns[0] + WBNumOfTrns[0] + THNumOfTrns[0] + WDNumOfTrns[0] + PWNumOfTrns[0] + GBNumOfTrns[0] + BWNumOfTrns[0];
                    SUMAveDailySales[0] = SUMDailySales[0] / SUMNumOfTrns[0];

                    dt3.Rows.Add(Convert.ToDateTime(startDate).ToString("D"),
                                 string.Format("{0:c}", THDailySales[0]) + "\n(" + Convert.ToString(THNumOfTrns[0]) + "/" + string.Format("{0:c}", THAveDailySales[0]) + ")",
                                 string.Format("{0:c}", OHDailySales[0]) + "\n(" + Convert.ToString(OHNumOfTrns[0]) + "/" + string.Format("{0:c}", OHAveDailySales[0]) + ")",
                                 string.Format("{0:c}", UMDailySales[0]) + "\n(" + Convert.ToString(UMNumOfTrns[0]) + "/" + string.Format("{0:c}", UMAveDailySales[0]) + ")",
                                 string.Format("{0:c}", CHDailySales[0]) + "\n(" + Convert.ToString(CHNumOfTrns[0]) + "/" + string.Format("{0:c}", CHAveDailySales[0]) + ")",
                                 string.Format("{0:c}", WMDailySales[0]) + "\n(" + Convert.ToString(WMNumOfTrns[0]) + "/" + string.Format("{0:c}", WMAveDailySales[0]) + ")",
                                 string.Format("{0:c}", CVDailySales[0]) + "\n(" + Convert.ToString(CVNumOfTrns[0]) + "/" + string.Format("{0:c}", CVAveDailySales[0]) + ")",
                                 string.Format("{0:c}", GBDailySales[0]) + "\n(" + Convert.ToString(GBNumOfTrns[0]) + "/" + string.Format("{0:c}", GBAveDailySales[0]) + ")",
                                 string.Format("{0:c}", PWDailySales[0]) + "\n(" + Convert.ToString(PWNumOfTrns[0]) + "/" + string.Format("{0:c}", PWAveDailySales[0]) + ")",
                                 string.Format("{0:c}", WBDailySales[0]) + "\n(" + Convert.ToString(WBNumOfTrns[0]) + "/" + string.Format("{0:c}", WBAveDailySales[0]) + ")",
                                 string.Format("{0:c}", WDDailySales[0]) + "\n(" + Convert.ToString(WDNumOfTrns[0]) + "/" + string.Format("{0:c}", WDAveDailySales[0]) + ")",
                                 string.Format("{0:c}", BWDailySales[0]) + "\n(" + Convert.ToString(BWNumOfTrns[0]) + "/" + string.Format("{0:c}", BWAveDailySales[0]) + ")",
                                 string.Format("{0:c}", SUMDailySales[0]) + "\n(" + Convert.ToString(SUMNumOfTrns[0]) + "/" + string.Format("{0:c}", SUMAveDailySales[0]) + ")");

                    dataGridView3.RowTemplate.Height = 40;
                    //dataGridView1.RowTemplate.DefaultCellStyle.Font = new Font("Arial", 12);
                    dataGridView3.DataSource = dt3;

                    dataGridView3.Columns[0].HeaderText = "DATE";
                    dataGridView3.Columns[0].DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                    dataGridView3.Columns[0].Width = 110;
                    dataGridView3.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView3.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView3.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

                    dataGridView3.Columns[1].Width = 105;
                    dataGridView3.Columns[1].DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                    dataGridView3.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView3.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView3.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

                    dataGridView3.Columns[2].Width = 105;
                    dataGridView3.Columns[2].DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                    dataGridView3.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView3.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView3.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

                    dataGridView3.Columns[3].Width = 105;
                    dataGridView3.Columns[3].DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                    dataGridView3.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView3.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView3.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

                    dataGridView3.Columns[4].Width = 105;
                    dataGridView3.Columns[4].DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                    dataGridView3.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView3.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView3.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

                    dataGridView3.Columns[5].Width = 105;
                    dataGridView3.Columns[5].DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                    dataGridView3.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView3.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView3.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;

                    dataGridView3.Columns[6].Width = 105;
                    dataGridView3.Columns[6].DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                    dataGridView3.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView3.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView3.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

                    dataGridView3.Columns[7].Width = 105;
                    dataGridView3.Columns[7].DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                    dataGridView3.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView3.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView3.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;

                    dataGridView3.Columns[8].Width = 105;
                    dataGridView3.Columns[8].DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                    dataGridView3.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView3.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView3.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;

                    dataGridView3.Columns[9].Width = 105;
                    dataGridView3.Columns[9].DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                    dataGridView3.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView3.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView3.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;

                    dataGridView3.Columns[10].Width = 105;
                    dataGridView3.Columns[10].DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                    dataGridView3.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView3.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView3.Columns[10].SortMode = DataGridViewColumnSortMode.NotSortable;

                    dataGridView3.Columns[11].Width = 105;
                    dataGridView3.Columns[11].DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                    dataGridView3.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView3.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView3.Columns[11].SortMode = DataGridViewColumnSortMode.NotSortable;

                    dataGridView3.Columns[12].Width = 120;
                    dataGridView3.Columns[12].DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
                    dataGridView3.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView3.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView3.Columns[12].SortMode = DataGridViewColumnSortMode.NotSortable;

                    dataGridView3.Columns[0].DefaultCellStyle.BackColor = Color.Orange;
                    dataGridView3.Columns[12].DefaultCellStyle.BackColor = Color.LightYellow;
                }
                else
                {
                    try
                    {
                        for (int i = 0; i <= days; i++)
                        {
                            cmd.CommandText = "Sales_History_Daily_By_Store";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = connTH;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = Convert.ToDateTime(startDate).AddDays(i).ToString("d");
                            SqlParameter DailySales_Param = cmd.Parameters.Add("@DailySales", SqlDbType.Money);
                            SqlParameter NumOfTrans_Param = cmd.Parameters.Add("@NumOfTrans", SqlDbType.Int);
                            SqlParameter AveDailySales_Param = cmd.Parameters.Add("@AveDailySales", SqlDbType.Money);
                            DailySales_Param.Direction = ParameterDirection.Output;
                            NumOfTrans_Param.Direction = ParameterDirection.Output;
                            AveDailySales_Param.Direction = ParameterDirection.Output;

                            connTH.Open();
                            cmd.ExecuteNonQuery();
                            connTH.Close();

                            if (cmd.Parameters["@DailySales"].Value != DBNull.Value)
                                THDailySales[i] = Convert.ToDouble(cmd.Parameters["@DailySales"].Value);

                            if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                                THNumOfTrns[i] = Convert.ToInt16(cmd.Parameters["@NumOfTrans"].Value);

                            if (cmd.Parameters["@AveDailySales"].Value != DBNull.Value)
                                THAveDailySales[i] = Convert.ToDouble(cmd.Parameters["@AveDailySales"].Value);

                            THDailySalesTotal = THDailySalesTotal + THDailySales[i];
                            THNumOfTransTotal = THNumOfTransTotal + THNumOfTrns[i];
                        }

                        THAveDailySalesTotal = THDailySalesTotal / THNumOfTransTotal;

                        progressBar1.PerformStep();
                    }
                    catch
                    {
                        MessageBox.Show("CAN NOT CONNECT TEMPLE HILLS SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connTH.Close();
                    }

                    try
                    {
                        for (int i = 0; i <= days; i++)
                        {
                            cmd.CommandText = "Sales_History_Daily_By_Store";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = connOH;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = Convert.ToDateTime(startDate).AddDays(i).ToString("d");
                            SqlParameter DailySales_Param = cmd.Parameters.Add("@DailySales", SqlDbType.Money);
                            SqlParameter NumOfTrans_Param = cmd.Parameters.Add("@NumOfTrans", SqlDbType.Int);
                            SqlParameter AveDailySales_Param = cmd.Parameters.Add("@AveDailySales", SqlDbType.Money);
                            DailySales_Param.Direction = ParameterDirection.Output;
                            NumOfTrans_Param.Direction = ParameterDirection.Output;
                            AveDailySales_Param.Direction = ParameterDirection.Output;

                            connOH.Open();
                            cmd.ExecuteNonQuery();
                            connOH.Close();

                            if (cmd.Parameters["@DailySales"].Value != DBNull.Value)
                                OHDailySales[i] = Convert.ToDouble(cmd.Parameters["@DailySales"].Value);

                            if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                                OHNumOfTrns[i] = Convert.ToInt16(cmd.Parameters["@NumOfTrans"].Value);

                            if (cmd.Parameters["@AveDailySales"].Value != DBNull.Value)
                                OHAveDailySales[i] = Convert.ToDouble(cmd.Parameters["@AveDailySales"].Value);

                            OHDailySalesTotal = OHDailySalesTotal + OHDailySales[i];
                            OHNumOfTransTotal = OHNumOfTransTotal + OHNumOfTrns[i];
                        }

                        OHAveDailySalesTotal = OHDailySalesTotal / OHNumOfTransTotal;

                        progressBar1.PerformStep();
                    }
                    catch
                    {
                        MessageBox.Show("CAN NOT CONNECT OXON HILL SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connOH.Close();
                    }

                    try
                    {
                        for (int i = 0; i <= days; i++)
                        {
                            cmd.CommandText = "Sales_History_Daily_By_Store";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = connCH;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = Convert.ToDateTime(startDate).AddDays(i).ToString("d");
                            SqlParameter DailySales_Param = cmd.Parameters.Add("@DailySales", SqlDbType.Money);
                            SqlParameter NumOfTrans_Param = cmd.Parameters.Add("@NumOfTrans", SqlDbType.Int);
                            SqlParameter AveDailySales_Param = cmd.Parameters.Add("@AveDailySales", SqlDbType.Money);
                            DailySales_Param.Direction = ParameterDirection.Output;
                            NumOfTrans_Param.Direction = ParameterDirection.Output;
                            AveDailySales_Param.Direction = ParameterDirection.Output;

                            connCH.Open();
                            cmd.ExecuteNonQuery();
                            connCH.Close();

                            if (cmd.Parameters["@DailySales"].Value != DBNull.Value)
                                CHDailySales[i] = Convert.ToDouble(cmd.Parameters["@DailySales"].Value);

                            if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                                CHNumOfTrns[i] = Convert.ToInt16(cmd.Parameters["@NumOfTrans"].Value);

                            if (cmd.Parameters["@AveDailySales"].Value != DBNull.Value)
                                CHAveDailySales[i] = Convert.ToDouble(cmd.Parameters["@AveDailySales"].Value);

                            CHDailySalesTotal = CHDailySalesTotal + CHDailySales[i];
                            CHNumOfTransTotal = CHNumOfTransTotal + CHNumOfTrns[i];
                        }

                        CHAveDailySalesTotal = CHDailySalesTotal / CHNumOfTransTotal;

                        progressBar1.PerformStep();
                    }
                    catch
                    {
                        MessageBox.Show("CAN NOT CONNECT CAPITOL HEIGHTS SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connCH.Close();
                    }

                    try
                    {
                        for (int i = 0; i <= days; i++)
                        {
                            cmd.CommandText = "Sales_History_Daily_By_Store";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = connCV;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = Convert.ToDateTime(startDate).AddDays(i).ToString("d");
                            SqlParameter DailySales_Param = cmd.Parameters.Add("@DailySales", SqlDbType.Money);
                            SqlParameter NumOfTrans_Param = cmd.Parameters.Add("@NumOfTrans", SqlDbType.Int);
                            SqlParameter AveDailySales_Param = cmd.Parameters.Add("@AveDailySales", SqlDbType.Money);
                            DailySales_Param.Direction = ParameterDirection.Output;
                            NumOfTrans_Param.Direction = ParameterDirection.Output;
                            AveDailySales_Param.Direction = ParameterDirection.Output;

                            connCV.Open();
                            cmd.ExecuteNonQuery();
                            connCV.Close();

                            if (cmd.Parameters["@DailySales"].Value != DBNull.Value)
                                CVDailySales[i] = Convert.ToDouble(cmd.Parameters["@DailySales"].Value);

                            if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                                CVNumOfTrns[i] = Convert.ToInt16(cmd.Parameters["@NumOfTrans"].Value);

                            if (cmd.Parameters["@AveDailySales"].Value != DBNull.Value)
                                CVAveDailySales[i] = Convert.ToDouble(cmd.Parameters["@AveDailySales"].Value);

                            CVDailySalesTotal = CVDailySalesTotal + CVDailySales[i];
                            CVNumOfTransTotal = CVNumOfTransTotal + CVNumOfTrns[i];
                        }

                        CVAveDailySalesTotal = CVDailySalesTotal / CVNumOfTransTotal;

                        progressBar1.PerformStep();
                    }
                    catch
                    {
                        MessageBox.Show("CAN NOT CONNECT CATONSVILLE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connCV.Close();
                    }

                    try
                    {
                        for (int i = 0; i <= days; i++)
                        {
                            cmd.CommandText = "Sales_History_Daily_By_Store";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = connUM;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = Convert.ToDateTime(startDate).AddDays(i).ToString("d");
                            SqlParameter DailySales_Param = cmd.Parameters.Add("@DailySales", SqlDbType.Money);
                            SqlParameter NumOfTrans_Param = cmd.Parameters.Add("@NumOfTrans", SqlDbType.Int);
                            SqlParameter AveDailySales_Param = cmd.Parameters.Add("@AveDailySales", SqlDbType.Money);
                            DailySales_Param.Direction = ParameterDirection.Output;
                            NumOfTrans_Param.Direction = ParameterDirection.Output;
                            AveDailySales_Param.Direction = ParameterDirection.Output;

                            connUM.Open();
                            cmd.ExecuteNonQuery();
                            connUM.Close();

                            if (cmd.Parameters["@DailySales"].Value != DBNull.Value)
                                UMDailySales[i] = Convert.ToDouble(cmd.Parameters["@DailySales"].Value);

                            if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                                UMNumOfTrns[i] = Convert.ToInt16(cmd.Parameters["@NumOfTrans"].Value);

                            if (cmd.Parameters["@AveDailySales"].Value != DBNull.Value)
                                UMAveDailySales[i] = Convert.ToDouble(cmd.Parameters["@AveDailySales"].Value);

                            UMDailySalesTotal = UMDailySalesTotal + UMDailySales[i];
                            UMNumOfTransTotal = UMNumOfTransTotal + UMNumOfTrns[i];
                        }

                        UMAveDailySalesTotal = UMDailySalesTotal / UMNumOfTransTotal;

                        progressBar1.PerformStep();
                    }
                    catch
                    {
                        MessageBox.Show("CAN NOT CONNECT UPPER MARLBORO SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connUM.Close();
                    }

                    try
                    {
                        for (int i = 0; i <= days; i++)
                        {
                            cmd.CommandText = "Sales_History_Daily_By_Store";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = connWM;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = Convert.ToDateTime(startDate).AddDays(i).ToString("d");
                            SqlParameter DailySales_Param = cmd.Parameters.Add("@DailySales", SqlDbType.Money);
                            SqlParameter NumOfTrans_Param = cmd.Parameters.Add("@NumOfTrans", SqlDbType.Int);
                            SqlParameter AveDailySales_Param = cmd.Parameters.Add("@AveDailySales", SqlDbType.Money);
                            DailySales_Param.Direction = ParameterDirection.Output;
                            NumOfTrans_Param.Direction = ParameterDirection.Output;
                            AveDailySales_Param.Direction = ParameterDirection.Output;

                            connWM.Open();
                            cmd.ExecuteNonQuery();
                            connWM.Close();

                            if (cmd.Parameters["@DailySales"].Value != DBNull.Value)
                                WMDailySales[i] = Convert.ToDouble(cmd.Parameters["@DailySales"].Value);

                            if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                                WMNumOfTrns[i] = Convert.ToInt16(cmd.Parameters["@NumOfTrans"].Value);

                            if (cmd.Parameters["@AveDailySales"].Value != DBNull.Value)
                                WMAveDailySales[i] = Convert.ToDouble(cmd.Parameters["@AveDailySales"].Value);

                            WMDailySalesTotal = WMDailySalesTotal + WMDailySales[i];
                            WMNumOfTransTotal = WMNumOfTransTotal + WMNumOfTrns[i];
                        }

                        WMAveDailySalesTotal = WMDailySalesTotal / WMNumOfTransTotal;

                        progressBar1.PerformStep();
                    }
                    catch
                    {
                        MessageBox.Show("CAN NOT CONNECT WINDSOR MILL SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connWM.Close();
                    }

                    try
                    {
                        for (int i = 0; i <= days; i++)
                        {
                            cmd.CommandText = "Sales_History_Daily_By_Store";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = connWB;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = Convert.ToDateTime(startDate).AddDays(i).ToString("d");
                            SqlParameter DailySales_Param = cmd.Parameters.Add("@DailySales", SqlDbType.Money);
                            SqlParameter NumOfTrans_Param = cmd.Parameters.Add("@NumOfTrans", SqlDbType.Int);
                            SqlParameter AveDailySales_Param = cmd.Parameters.Add("@AveDailySales", SqlDbType.Money);
                            DailySales_Param.Direction = ParameterDirection.Output;
                            NumOfTrans_Param.Direction = ParameterDirection.Output;
                            AveDailySales_Param.Direction = ParameterDirection.Output;

                            connWB.Open();
                            cmd.ExecuteNonQuery();
                            connWB.Close();

                            if (cmd.Parameters["@DailySales"].Value != DBNull.Value)
                                WBDailySales[i] = Convert.ToDouble(cmd.Parameters["@DailySales"].Value);

                            if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                                WBNumOfTrns[i] = Convert.ToInt16(cmd.Parameters["@NumOfTrans"].Value);

                            if (cmd.Parameters["@AveDailySales"].Value != DBNull.Value)
                                WBAveDailySales[i] = Convert.ToDouble(cmd.Parameters["@AveDailySales"].Value);

                            WBDailySalesTotal = WBDailySalesTotal + WBDailySales[i];
                            WBNumOfTransTotal = WBNumOfTransTotal + WBNumOfTrns[i];
                        }

                        WBAveDailySalesTotal = WBDailySalesTotal / WBNumOfTransTotal;

                        progressBar1.PerformStep();
                    }
                    catch
                    {
                        MessageBox.Show("CAN NOT CONNECT WOODBRIDGE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connWB.Close();
                    }

                    try
                    {
                        for (int i = 0; i <= days; i++)
                        {
                            cmd.CommandText = "Sales_History_Daily_By_Store";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = connWD;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = Convert.ToDateTime(startDate).AddDays(i).ToString("d");
                            SqlParameter DailySales_Param = cmd.Parameters.Add("@DailySales", SqlDbType.Money);
                            SqlParameter NumOfTrans_Param = cmd.Parameters.Add("@NumOfTrans", SqlDbType.Int);
                            SqlParameter AveDailySales_Param = cmd.Parameters.Add("@AveDailySales", SqlDbType.Money);
                            DailySales_Param.Direction = ParameterDirection.Output;
                            NumOfTrans_Param.Direction = ParameterDirection.Output;
                            AveDailySales_Param.Direction = ParameterDirection.Output;

                            connWD.Open();
                            cmd.ExecuteNonQuery();
                            connWD.Close();

                            if (cmd.Parameters["@DailySales"].Value != DBNull.Value)
                                WDDailySales[i] = Convert.ToDouble(cmd.Parameters["@DailySales"].Value);

                            if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                                WDNumOfTrns[i] = Convert.ToInt16(cmd.Parameters["@NumOfTrans"].Value);

                            if (cmd.Parameters["@AveDailySales"].Value != DBNull.Value)
                                WDAveDailySales[i] = Convert.ToDouble(cmd.Parameters["@AveDailySales"].Value);

                            WDDailySalesTotal = WDDailySalesTotal + WDDailySales[i];
                            WDNumOfTransTotal = WDNumOfTransTotal + WDNumOfTrns[i];
                        }

                        WDAveDailySalesTotal = WDDailySalesTotal / WDNumOfTransTotal;

                        progressBar1.PerformStep();
                    }
                    catch
                    {
                        MessageBox.Show("CAN NOT CONNECT WOODBRIDGE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connWD.Close();
                    }

                    try
                    {
                        for (int i = 0; i <= days; i++)
                        {
                            cmd.CommandText = "Sales_History_Daily_By_Store";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = connPW;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = Convert.ToDateTime(startDate).AddDays(i).ToString("d");
                            SqlParameter DailySales_Param = cmd.Parameters.Add("@DailySales", SqlDbType.Money);
                            SqlParameter NumOfTrans_Param = cmd.Parameters.Add("@NumOfTrans", SqlDbType.Int);
                            SqlParameter AveDailySales_Param = cmd.Parameters.Add("@AveDailySales", SqlDbType.Money);
                            DailySales_Param.Direction = ParameterDirection.Output;
                            NumOfTrans_Param.Direction = ParameterDirection.Output;
                            AveDailySales_Param.Direction = ParameterDirection.Output;

                            connPW.Open();
                            cmd.ExecuteNonQuery();
                            connPW.Close();

                            if (cmd.Parameters["@DailySales"].Value != DBNull.Value)
                                PWDailySales[i] = Convert.ToDouble(cmd.Parameters["@DailySales"].Value);

                            if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                                PWNumOfTrns[i] = Convert.ToInt16(cmd.Parameters["@NumOfTrans"].Value);

                            if (cmd.Parameters["@AveDailySales"].Value != DBNull.Value)
                                PWAveDailySales[i] = Convert.ToDouble(cmd.Parameters["@AveDailySales"].Value);

                            PWDailySalesTotal = PWDailySalesTotal + PWDailySales[i];
                            PWNumOfTransTotal = PWNumOfTransTotal + PWNumOfTrns[i];
                        }

                        PWAveDailySalesTotal = PWDailySalesTotal / PWNumOfTransTotal;

                        progressBar1.PerformStep();
                    }
                    catch
                    {
                        MessageBox.Show("CAN NOT CONNECT PRINCE WILLIAM SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connPW.Close();
                    }

                    try
                    {
                        for (int i = 0; i <= days; i++)
                        {
                            cmd.CommandText = "Sales_History_Daily_By_Store";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = connGB;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = Convert.ToDateTime(startDate).AddDays(i).ToString("d");
                            SqlParameter DailySales_Param = cmd.Parameters.Add("@DailySales", SqlDbType.Money);
                            SqlParameter NumOfTrans_Param = cmd.Parameters.Add("@NumOfTrans", SqlDbType.Int);
                            SqlParameter AveDailySales_Param = cmd.Parameters.Add("@AveDailySales", SqlDbType.Money);
                            DailySales_Param.Direction = ParameterDirection.Output;
                            NumOfTrans_Param.Direction = ParameterDirection.Output;
                            AveDailySales_Param.Direction = ParameterDirection.Output;

                            connGB.Open();
                            cmd.ExecuteNonQuery();
                            connGB.Close();

                            if (cmd.Parameters["@DailySales"].Value != DBNull.Value)
                                GBDailySales[i] = Convert.ToDouble(cmd.Parameters["@DailySales"].Value);

                            if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                                GBNumOfTrns[i] = Convert.ToInt16(cmd.Parameters["@NumOfTrans"].Value);

                            if (cmd.Parameters["@AveDailySales"].Value != DBNull.Value)
                                GBAveDailySales[i] = Convert.ToDouble(cmd.Parameters["@AveDailySales"].Value);

                            GBDailySalesTotal = GBDailySalesTotal + GBDailySales[i];
                            GBNumOfTransTotal = GBNumOfTransTotal + GBNumOfTrns[i];
                        }

                        GBAveDailySalesTotal = GBDailySalesTotal / GBNumOfTransTotal;

                        progressBar1.PerformStep();
                    }
                    catch
                    {
                        MessageBox.Show("CAN NOT CONNECT GAITHERSBURG SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connGB.Close();
                    }

                    try
                    {
                        for (int i = 0; i <= days; i++)
                        {
                            cmd.CommandText = "Sales_History_Daily_By_Store";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = connBW;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = Convert.ToDateTime(startDate).AddDays(i).ToString("d");
                            SqlParameter DailySales_Param = cmd.Parameters.Add("@DailySales", SqlDbType.Money);
                            SqlParameter NumOfTrans_Param = cmd.Parameters.Add("@NumOfTrans", SqlDbType.Int);
                            SqlParameter AveDailySales_Param = cmd.Parameters.Add("@AveDailySales", SqlDbType.Money);
                            DailySales_Param.Direction = ParameterDirection.Output;
                            NumOfTrans_Param.Direction = ParameterDirection.Output;
                            AveDailySales_Param.Direction = ParameterDirection.Output;

                            connBW.Open();
                            cmd.ExecuteNonQuery();
                            connBW.Close();

                            if (cmd.Parameters["@DailySales"].Value != DBNull.Value)
                                BWDailySales[i] = Convert.ToDouble(cmd.Parameters["@DailySales"].Value);

                            if (cmd.Parameters["@NumOfTrans"].Value != DBNull.Value)
                                BWNumOfTrns[i] = Convert.ToInt16(cmd.Parameters["@NumOfTrans"].Value);

                            if (cmd.Parameters["@AveDailySales"].Value != DBNull.Value)
                                BWAveDailySales[i] = Convert.ToDouble(cmd.Parameters["@AveDailySales"].Value);

                            BWDailySalesTotal = BWDailySalesTotal + BWDailySales[i];
                            BWNumOfTransTotal = BWNumOfTransTotal + BWNumOfTrns[i];
                        }

                        BWAveDailySalesTotal = BWDailySalesTotal / BWNumOfTransTotal;

                        progressBar1.PerformStep();
                    }
                    catch
                    {
                        MessageBox.Show("CAN NOT CONNECT BOWIE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connBW.Close();
                    }

                    for (int i = 0; i <= days; i++)
                    {
                        SUMDailySales[i] = OHDailySales[i] + CHDailySales[i] + CVDailySales[i] + UMDailySales[i] + WMDailySales[i] + WBDailySales[i] + THDailySales[i] + WDDailySales[i] + PWDailySales[i] + GBDailySales[i] + BWDailySales[i];
                        SUMNumOfTrns[i] = OHNumOfTrns[i] + CHNumOfTrns[i] + CVNumOfTrns[i] + UMNumOfTrns[i] + WMNumOfTrns[i] + WBNumOfTrns[i] + THNumOfTrns[i] + WDNumOfTrns[i] + PWNumOfTrns[i] + GBNumOfTrns[i] + BWNumOfTrns[i];
                        SUMAveDailySales[i] = SUMDailySales[i] / SUMNumOfTrns[i];

                        dt3.Rows.Add(Convert.ToDateTime(startDate).AddDays(i).ToString("D"),
                                     string.Format("{0:c}", THDailySales[i]) + "\n(" + Convert.ToString(THNumOfTrns[i]) + "/" + string.Format("{0:c}", THAveDailySales[i]) + ")",
                                     string.Format("{0:c}", OHDailySales[i]) + "\n(" + Convert.ToString(OHNumOfTrns[i]) + "/" + string.Format("{0:c}", OHAveDailySales[i]) + ")",
                                     string.Format("{0:c}", UMDailySales[i]) + "\n(" + Convert.ToString(UMNumOfTrns[i]) + "/" + string.Format("{0:c}", UMAveDailySales[i]) + ")",
                                     string.Format("{0:c}", CHDailySales[i]) + "\n(" + Convert.ToString(CHNumOfTrns[i]) + "/" + string.Format("{0:c}", CHAveDailySales[i]) + ")",
                                     string.Format("{0:c}", WMDailySales[i]) + "\n(" + Convert.ToString(WMNumOfTrns[i]) + "/" + string.Format("{0:c}", WMAveDailySales[i]) + ")",
                                     string.Format("{0:c}", CVDailySales[i]) + "\n(" + Convert.ToString(CVNumOfTrns[i]) + "/" + string.Format("{0:c}", CVAveDailySales[i]) + ")",
                                     string.Format("{0:c}", GBDailySales[i]) + "\n(" + Convert.ToString(GBNumOfTrns[i]) + "/" + string.Format("{0:c}", GBAveDailySales[i]) + ")",
                                     string.Format("{0:c}", PWDailySales[i]) + "\n(" + Convert.ToString(PWNumOfTrns[i]) + "/" + string.Format("{0:c}", PWAveDailySales[i]) + ")",
                                     string.Format("{0:c}", WBDailySales[i]) + "\n(" + Convert.ToString(WBNumOfTrns[i]) + "/" + string.Format("{0:c}", WBAveDailySales[i]) + ")",
                                     string.Format("{0:c}", WDDailySales[i]) + "\n(" + Convert.ToString(WDNumOfTrns[i]) + "/" + string.Format("{0:c}", WDAveDailySales[i]) + ")",
                                     string.Format("{0:c}", BWDailySales[i]) + "\n(" + Convert.ToString(BWNumOfTrns[i]) + "/" + string.Format("{0:c}", BWAveDailySales[i]) + ")",
                                     string.Format("{0:c}", SUMDailySales[i]) + "\n(" + Convert.ToString(SUMNumOfTrns[i]) + "/" + string.Format("{0:c}", SUMAveDailySales[i]) + ")");
                    }

                    SUMDailySalesTotal = OHDailySalesTotal + CHDailySalesTotal + CVDailySalesTotal + UMDailySalesTotal + WMDailySalesTotal + WBDailySalesTotal + THDailySalesTotal + WDDailySalesTotal + PWDailySalesTotal + GBDailySalesTotal + BWDailySalesTotal;
                    SUMNumOfTrnsTotal = OHNumOfTransTotal + CHNumOfTransTotal + CVNumOfTransTotal + UMNumOfTransTotal + WMNumOfTransTotal + WBNumOfTransTotal + THNumOfTransTotal + WDNumOfTransTotal + PWNumOfTransTotal + GBNumOfTransTotal + BWNumOfTransTotal;
                    SUMAveDailySalesTotal = SUMDailySalesTotal / SUMNumOfTrnsTotal;

                    dt3.Rows.Add("TOTAL", string.Format("{0:c}", THDailySalesTotal) + "\n(" + Convert.ToString(THNumOfTransTotal) + "/" + string.Format("{0:c}", THAveDailySalesTotal) + ")",
                                          string.Format("{0:c}", OHDailySalesTotal) + "\n(" + Convert.ToString(OHNumOfTransTotal) + "/" + string.Format("{0:c}", OHAveDailySalesTotal) + ")",
                                          string.Format("{0:c}", UMDailySalesTotal) + "\n(" + Convert.ToString(UMNumOfTransTotal) + "/" + string.Format("{0:c}", UMAveDailySalesTotal) + ")",
                                          string.Format("{0:c}", CHDailySalesTotal) + "\n(" + Convert.ToString(CHNumOfTransTotal) + "/" + string.Format("{0:c}", CHAveDailySalesTotal) + ")",
                                          string.Format("{0:c}", WMDailySalesTotal) + "\n(" + Convert.ToString(WMNumOfTransTotal) + "/" + string.Format("{0:c}", WMAveDailySalesTotal) + ")",
                                          string.Format("{0:c}", CVDailySalesTotal) + "\n(" + Convert.ToString(CVNumOfTransTotal) + "/" + string.Format("{0:c}", CVAveDailySalesTotal) + ")",
                                          string.Format("{0:c}", GBDailySalesTotal) + "\n(" + Convert.ToString(GBNumOfTransTotal) + "/" + string.Format("{0:c}", GBAveDailySalesTotal) + ")",
                                          string.Format("{0:c}", PWDailySalesTotal) + "\n(" + Convert.ToString(PWNumOfTransTotal) + "/" + string.Format("{0:c}", PWAveDailySalesTotal) + ")",
                                          string.Format("{0:c}", WBDailySalesTotal) + "\n(" + Convert.ToString(WBNumOfTransTotal) + "/" + string.Format("{0:c}", WBAveDailySalesTotal) + ")",
                                          string.Format("{0:c}", WDDailySalesTotal) + "\n(" + Convert.ToString(WDNumOfTransTotal) + "/" + string.Format("{0:c}", WDAveDailySalesTotal) + ")",
                                          string.Format("{0:c}", BWDailySalesTotal) + "\n(" + Convert.ToString(BWNumOfTransTotal) + "/" + string.Format("{0:c}", BWAveDailySalesTotal) + ")",
                                          string.Format("{0:c}", SUMDailySalesTotal) + "\n(" + Convert.ToString(SUMNumOfTrnsTotal) + "/" + string.Format("{0:c}", SUMAveDailySalesTotal) + ")");

                    dataGridView3.RowTemplate.Height = 40;
                    //dataGridView1.RowTemplate.DefaultCellStyle.Font = new Font("Arial", 12);
                    dataGridView3.DataSource = dt3;

                    for (int i = 0; i < dataGridView3.RowCount - 1; i++)
                    {
                        if (Convert.ToDateTime(dataGridView3.Rows[i].Cells[0].Value).DayOfWeek == DayOfWeek.Sunday)
                            dataGridView3.Rows[i].Cells[0].Style.ForeColor = Color.Red;
                    }

                    dataGridView3.Columns[0].HeaderText = "DATE";
                    dataGridView3.Columns[0].DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                    dataGridView3.Columns[0].Width = 110;
                    dataGridView3.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView3.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView3.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

                    dataGridView3.Columns[1].Width = 105;
                    dataGridView3.Columns[1].DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                    dataGridView3.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView3.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView3.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

                    dataGridView3.Columns[2].Width = 105;
                    dataGridView3.Columns[2].DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                    dataGridView3.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView3.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView3.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

                    dataGridView3.Columns[3].Width = 105;
                    dataGridView3.Columns[3].DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                    dataGridView3.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView3.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView3.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

                    dataGridView3.Columns[4].Width = 105;
                    dataGridView3.Columns[4].DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                    dataGridView3.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView3.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView3.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

                    dataGridView3.Columns[5].Width = 105;
                    dataGridView3.Columns[5].DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                    dataGridView3.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView3.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView3.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;

                    dataGridView3.Columns[6].Width = 105;
                    dataGridView3.Columns[6].DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                    dataGridView3.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView3.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView3.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

                    dataGridView3.Columns[7].Width = 105;
                    dataGridView3.Columns[7].DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                    dataGridView3.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView3.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView3.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;

                    dataGridView3.Columns[8].Width = 105;
                    dataGridView3.Columns[8].DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                    dataGridView3.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView3.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView3.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;

                    dataGridView3.Columns[9].Width = 105;
                    dataGridView3.Columns[9].DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                    dataGridView3.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView3.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView3.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;

                    dataGridView3.Columns[10].Width = 105;
                    dataGridView3.Columns[10].DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                    dataGridView3.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView3.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView3.Columns[10].SortMode = DataGridViewColumnSortMode.NotSortable;

                    dataGridView3.Columns[11].Width = 105;
                    dataGridView3.Columns[11].DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                    dataGridView3.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView3.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView3.Columns[11].SortMode = DataGridViewColumnSortMode.NotSortable;

                    dataGridView3.Columns[12].Width = 120;
                    dataGridView3.Columns[12].DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
                    dataGridView3.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView3.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView3.Columns[12].SortMode = DataGridViewColumnSortMode.NotSortable;

                    dataGridView3.Columns[0].DefaultCellStyle.BackColor = Color.Orange;
                    dataGridView3.Columns[12].DefaultCellStyle.BackColor = Color.LightYellow;
                }

                dataGridView3.Rows[dataGridView3.RowCount - 1].DefaultCellStyle.BackColor = Color.BurlyWood;
                dataGridView3.Rows[dataGridView3.RowCount - 1].DefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);

                if (dataGridView3.RowCount > 0)
                    dataGridView3.Rows[0].Selected = false;

                progressBar1.Value = 0;
                btnOK.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOption.SelectedIndex == 0)
            {
                label2.Visible = true;
                txtEndDate.Visible = true;
                monthCalendar2.Visible = false;
                dataGridView1.Visible = true;
                dataGridView2.Visible = false;
                dataGridView3.Visible = false;
                dataGridView2.DataSource = null;
                dataGridView3.DataSource = null;
            }
            else if (cmbOption.SelectedIndex == 1)
            {
                label2.Visible = false;
                txtEndDate.Visible = false;
                monthCalendar2.Visible = false;
                dataGridView1.Visible = false;
                dataGridView2.Visible = true;
                dataGridView3.Visible = false;
                dataGridView1.DataSource = null;
                dataGridView3.DataSource = null;
            }
            else if (cmbOption.SelectedIndex == 2)
            {
                label2.Visible = true;
                txtEndDate.Visible = true;
                monthCalendar2.Visible = false;
                dataGridView1.Visible = false;
                dataGridView2.Visible = false;
                dataGridView3.Visible = true;
                dataGridView1.DataSource = null;
                dataGridView2.DataSource = null;
            }
        }
    }
}