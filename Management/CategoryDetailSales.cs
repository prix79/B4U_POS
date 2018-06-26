using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Office_12 = Microsoft.Office.Core;
using Excel_12 = Microsoft.Office.Interop.Excel;
using System.Globalization;

namespace Management
{
    public partial class CategoryDetailSales : Form
    {
        public LogInManagements parentForm1;
        public SalesHistory parentForm2;

        int index1, index2, index3;
        string sp;
        public DataTable dt = new DataTable();
        SqlDataAdapter adapt = new SqlDataAdapter();
        SqlCommand cmd;
        SqlConnection newConn = new SqlConnection();
        public Font drvFont = new Font("Arial", 9);
        NumberFormatInfo nfi = new NumberFormatInfo();

        int soldQty = 0;

        double CDCategory1Nasles = 0;
        double CDNetSales = 0, CDTotalDiscount = 0;
        int CDSoldQty = 0, CDReturnQty = 0;

        public CategoryDetailSales(string Category1Name, int Category1Index, double Category1NSales)
        {
            InitializeComponent();
            lblCategory1.Text = Category1Name;
            index1 = Category1Index;
            CDCategory1Nasles = Category1NSales;
        }

        private void CategoryDetailSales_Load(object sender, EventArgs e)
        {
            nfi.CurrencySymbol = Application.CurrentCulture.NumberFormat.CurrencySymbol;
            nfi.CurrencyNegativePattern = 1;

            try
            {
                if (parentForm2.cmbStoreCode.Text == parentForm1.StoreCode)
                {
                    SqlCommand cmd_CmbCategory2 = new SqlCommand("Get_Category_Group2", parentForm1.conn);
                    cmd_CmbCategory2.CommandType = CommandType.StoredProcedure;
                    cmd_CmbCategory2.Parameters.Add("@ItmGp_Parents", SqlDbType.Int).Value = index1;
                    DataSet ds = new DataSet();
                    SqlDataAdapter adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd_CmbCategory2;

                    parentForm1.conn.Open();
                    adapt.Fill(ds);
                    parentForm1.conn.Close();

                    cmbCategory2.DataSource = ds.Tables[0].DefaultView;
                    cmbCategory2.ValueMember = "ItmGp_Desc";
                    cmbCategory2.DisplayMember = "ItmGp_Desc";

                    ds.Tables.Clear();

                    if (index1 > 5)
                    {
                        index1 = index1 + 1;
                    }

                    sp = "Show_SoldItems_By_Category_1_New";
                    DataBind(sp, index1, parentForm2.startDate, parentForm2.endDate, parentForm1.conn);
                    BindDataGridView();

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        CDNetSales = CDNetSales + Convert.ToDouble(dataGridView1.Rows[i].Cells[13].Value);
                        soldQty = Convert.ToInt16(dataGridView1.Rows[i].Cells[14].Value);

                        if (Convert.ToDouble(dataGridView1.Rows[i].Cells[12].Value) > 0 | Convert.ToDouble(dataGridView1.Rows[i].Cells[13].Value) == 0)
                            CDTotalDiscount = CDTotalDiscount + ((Convert.ToDouble(dataGridView1.Rows[i].Cells[11].Value) * soldQty) - Convert.ToDouble(dataGridView1.Rows[i].Cells[13].Value));

                        if (Convert.ToInt16(dataGridView1.Rows[i].Cells[14].Value) > 0)
                        {
                            CDSoldQty = CDSoldQty + Convert.ToInt16(dataGridView1.Rows[i].Cells[14].Value);
                        }
                        else
                        {
                            CDReturnQty = CDReturnQty + Convert.ToInt16(dataGridView1.Rows[i].Cells[14].Value);
                        }
                    }

                    lblCDNetSales.Text = string.Format("{0:$0.00}", CDNetSales);
                    lblCDTotalDiscount.Text = string.Format("{0:$0.00}", CDTotalDiscount);
                    lblCDSoldQty.Text = Convert.ToString(CDSoldQty);
                    lblCDReturnQty.Text = Convert.ToString(CDReturnQty);
                    lblCDPercentage.Text = string.Format("{0:P}", CDNetSales / CDCategory1Nasles);

                    dataGridView1.Select();
                    dataGridView1.Focus();
                }
                else
                {
                    if (parentForm2.cmbStoreCode.Text == "OH")
                    {
                        newConn.ConnectionString = "Data Source=" + parentForm1.OHIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.OHDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW;
                    }
                    else if (parentForm2.cmbStoreCode.Text == "CH")
                    {
                        newConn.ConnectionString = "Data Source=" + parentForm1.CHIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.CHDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW;
                    }
                    else if (parentForm2.cmbStoreCode.Text == "WB")
                    {
                        newConn.ConnectionString = "Data Source=" + parentForm1.WBIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.WBDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW;
                    }
                    else if (parentForm2.cmbStoreCode.Text == "CV")
                    {
                        newConn.ConnectionString = "Data Source=" + parentForm1.CVIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.CVDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW;
                    }
                    else if (parentForm2.cmbStoreCode.Text == "UM")
                    {
                        newConn.ConnectionString = "Data Source=" + parentForm1.UMIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.UMDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW;
                    }
                    else if (parentForm2.cmbStoreCode.Text == "WM")
                    {
                        newConn.ConnectionString = "Data Source=" + parentForm1.WMIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.WMDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW;
                    }
                    else if (parentForm2.cmbStoreCode.Text == "TH")
                    {
                        newConn.ConnectionString = "Data Source=" + parentForm1.THIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.THDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW;
                    }
                    else if (parentForm2.cmbStoreCode.Text == "WD")
                    {
                        newConn.ConnectionString = "Data Source=" + parentForm1.WDIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.WDDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW;
                    }
                    else if (parentForm2.cmbStoreCode.Text == "PW")
                    {
                        newConn.ConnectionString = "Data Source=" + parentForm1.PWIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.PWDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW;
                    }
                    else if (parentForm2.cmbStoreCode.Text == "GB")
                    {
                        newConn.ConnectionString = parentForm1.GBCS_IP;
                    }
                    else if (parentForm2.cmbStoreCode.Text == "BW")
                    {
                        newConn.ConnectionString = parentForm1.BWCS_IP;
                    }

                    SqlCommand cmd_CmbCategory2 = new SqlCommand("Get_Category_Group2", newConn);
                    cmd_CmbCategory2.CommandType = CommandType.StoredProcedure;
                    cmd_CmbCategory2.Parameters.Add("@ItmGp_Parents", SqlDbType.Int).Value = index1;
                    DataSet ds = new DataSet();
                    SqlDataAdapter adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd_CmbCategory2;

                    newConn.Open();
                    adapt.Fill(ds);
                    newConn.Close();

                    cmbCategory2.DataSource = ds.Tables[0].DefaultView;
                    cmbCategory2.ValueMember = "ItmGp_Desc";
                    cmbCategory2.DisplayMember = "ItmGp_Desc";

                    ds.Tables.Clear();

                    if (index1 > 5)
                    {
                        index1 = index1 + 1;
                    }

                    sp = "Show_SoldItems_By_Category_1_New";
                    DataBind(sp, index1, parentForm2.startDate, parentForm2.endDate, newConn);
                    BindDataGridView();

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        CDNetSales = CDNetSales + Convert.ToDouble(dataGridView1.Rows[i].Cells[13].Value);
                        soldQty = Convert.ToInt16(dataGridView1.Rows[i].Cells[14].Value);

                        if (Convert.ToDouble(dataGridView1.Rows[i].Cells[12].Value) > 0 | Convert.ToDouble(dataGridView1.Rows[i].Cells[13].Value) == 0)
                            CDTotalDiscount = CDTotalDiscount + ((Convert.ToDouble(dataGridView1.Rows[i].Cells[11].Value) * soldQty) - Convert.ToDouble(dataGridView1.Rows[i].Cells[13].Value));

                        if (Convert.ToInt16(dataGridView1.Rows[i].Cells[14].Value) > 0)
                        {
                            CDSoldQty = CDSoldQty + Convert.ToInt16(dataGridView1.Rows[i].Cells[14].Value);
                        }
                        else
                        {
                            CDReturnQty = CDReturnQty + Convert.ToInt16(dataGridView1.Rows[i].Cells[14].Value);
                        }
                    }

                    lblCDNetSales.Text = string.Format("{0:$0.00}", CDNetSales);
                    lblCDTotalDiscount.Text = string.Format("{0:$0.00}", CDTotalDiscount);
                    lblCDSoldQty.Text = Convert.ToString(CDSoldQty);
                    lblCDReturnQty.Text = Convert.ToString(CDReturnQty);
                    lblCDPercentage.Text = string.Format("{0:P}", CDNetSales / CDCategory1Nasles);

                    dataGridView1.Select();
                    dataGridView1.Focus();
                }
            }
            catch
            {
                parentForm1.conn.Close();
                MessageBox.Show("CAN NOT LOAD ITEM LIST\n" + "SOME ITEM GOT UPC NUMBER MORE THAN 1", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

                DoubleUPCList doubleUPCListForm = new DoubleUPCList(index1);
                doubleUPCListForm.parentForm = this.parentForm1;
                doubleUPCListForm.Show();
            }
        }

        private void cmbCategory2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (parentForm2.cmbStoreCode.Text == parentForm1.StoreCode)
            {
                cmbCategory3.DataSource = null;
                cmbCategory3.Items.Clear();

                index2 = cmbCategory2.SelectedIndex;

                SqlCommand cmd_CmbCategory3 = new SqlCommand("Get_Category_Group3", parentForm1.conn);
                cmd_CmbCategory3.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                SqlDataAdapter adapt = new SqlDataAdapter();

                switch (index1)
                {
                    case 6:
                        cmd_CmbCategory3.Parameters.Add("@ItmGp_Parents", SqlDbType.Int).Value = index1 + 1;
                        cmd_CmbCategory3.Parameters.Add("@ItmGp_Parents2", SqlDbType.Int).Value = index2;
                        adapt.SelectCommand = cmd_CmbCategory3;

                        parentForm1.conn.Open();
                        adapt.Fill(ds);
                        parentForm1.conn.Close();

                        cmbCategory3.DataSource = ds.Tables[0].DefaultView;
                        cmbCategory3.ValueMember = "ItmGp_Desc";
                        cmbCategory3.DisplayMember = "ItmGp_Desc";
                        break;
                    default:
                        cmd_CmbCategory3.Parameters.Add("@ItmGp_Parents", SqlDbType.Int).Value = index1;
                        cmd_CmbCategory3.Parameters.Add("@ItmGp_Parents2", SqlDbType.Int).Value = index2;
                        adapt.SelectCommand = cmd_CmbCategory3;

                        parentForm1.conn.Open();
                        adapt.Fill(ds);
                        parentForm1.conn.Close();

                        cmbCategory3.DataSource = ds.Tables[0].DefaultView;
                        cmbCategory3.ValueMember = "ItmGp_Desc";
                        cmbCategory3.DisplayMember = "ItmGp_Desc";
                        break;
                }
            }
            else
            {
                cmbCategory3.DataSource = null;
                cmbCategory3.Items.Clear();

                index2 = cmbCategory2.SelectedIndex;

                SqlCommand cmd_CmbCategory3 = new SqlCommand("Get_Category_Group3", newConn);
                cmd_CmbCategory3.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                SqlDataAdapter adapt = new SqlDataAdapter();

                switch (index1)
                {
                    case 6:
                        cmd_CmbCategory3.Parameters.Add("@ItmGp_Parents", SqlDbType.Int).Value = index1 + 1;
                        cmd_CmbCategory3.Parameters.Add("@ItmGp_Parents2", SqlDbType.Int).Value = index2;
                        adapt.SelectCommand = cmd_CmbCategory3;

                        newConn.Open();
                        adapt.Fill(ds);
                        newConn.Close();

                        cmbCategory3.DataSource = ds.Tables[0].DefaultView;
                        cmbCategory3.ValueMember = "ItmGp_Desc";
                        cmbCategory3.DisplayMember = "ItmGp_Desc";
                        break;
                    default:
                        cmd_CmbCategory3.Parameters.Add("@ItmGp_Parents", SqlDbType.Int).Value = index1;
                        cmd_CmbCategory3.Parameters.Add("@ItmGp_Parents2", SqlDbType.Int).Value = index2;
                        adapt.SelectCommand = cmd_CmbCategory3;

                        newConn.Open();
                        adapt.Fill(ds);
                        newConn.Close();

                        cmbCategory3.DataSource = ds.Tables[0].DefaultView;
                        cmbCategory3.ValueMember = "ItmGp_Desc";
                        cmbCategory3.DisplayMember = "ItmGp_Desc";
                        break;
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (parentForm2.cmbStoreCode.Text == parentForm1.StoreCode)
            {
                CDNetSales = 0; CDTotalDiscount = 0;
                CDSoldQty = 0; CDReturnQty = 0;

                btnOK.Enabled = false;

                if (cmbCategory2.SelectedIndex > 0)
                {
                    if (cmbCategory3.SelectedIndex >= 0)
                    {
                        index2 = cmbCategory2.SelectedIndex;
                        index3 = cmbCategory3.SelectedIndex + 1;
                        sp = "Show_SoldItems_By_Category_1_2_3_New";
                        DataBind(sp, index1, index2, index3, parentForm2.startDate, parentForm2.endDate, parentForm1.conn);
                        BindDataGridView();
                    }
                    else
                    {
                        index2 = cmbCategory2.SelectedIndex;
                        sp = "Show_SoldItems_By_Category_1_2_New";
                        DataBind(sp, index1, index2, parentForm2.startDate, parentForm2.endDate, parentForm1.conn);
                        BindDataGridView();
                    }
                }
                else
                {
                    sp = "Show_SoldItems_By_Category_1_New";
                    DataBind(sp, index1, parentForm2.startDate, parentForm2.endDate, parentForm1.conn);
                    BindDataGridView();
                }

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    CDNetSales = CDNetSales + Convert.ToDouble(dataGridView1.Rows[i].Cells[13].Value);
                    soldQty = Convert.ToInt16(dataGridView1.Rows[i].Cells[14].Value);

                    if (Convert.ToDouble(dataGridView1.Rows[i].Cells[12].Value) > 0 | Convert.ToDouble(dataGridView1.Rows[i].Cells[13].Value) == 0)
                        CDTotalDiscount = CDTotalDiscount + ((Convert.ToDouble(dataGridView1.Rows[i].Cells[11].Value) * soldQty) - Convert.ToDouble(dataGridView1.Rows[i].Cells[13].Value));

                    if (Convert.ToInt16(dataGridView1.Rows[i].Cells[14].Value) > 0)
                    {
                        CDSoldQty = CDSoldQty + Convert.ToInt16(dataGridView1.Rows[i].Cells[14].Value);
                    }
                    else
                    {
                        CDReturnQty = CDReturnQty + Convert.ToInt16(dataGridView1.Rows[i].Cells[14].Value);
                    }
                }

                lblCDNetSales.Text = string.Format("{0:$0.00}", CDNetSales);
                lblCDTotalDiscount.Text = string.Format("{0:$0.00}", CDTotalDiscount);
                lblCDSoldQty.Text = Convert.ToString(CDSoldQty);
                lblCDReturnQty.Text = Convert.ToString(CDReturnQty);
                lblCDPercentage.Text = string.Format("{0:P}", CDNetSales / CDCategory1Nasles);
            }
            else
            {
                CDNetSales = 0; CDTotalDiscount = 0;
                CDSoldQty = 0; CDReturnQty = 0;

                btnOK.Enabled = false;

                if (cmbCategory2.SelectedIndex > 0)
                {
                    if (cmbCategory3.SelectedIndex >= 0)
                    {
                        index2 = cmbCategory2.SelectedIndex;
                        index3 = cmbCategory3.SelectedIndex + 1;
                        sp = "Show_SoldItems_By_Category_1_2_3_New";
                        DataBind(sp, index1, index2, index3, parentForm2.startDate, parentForm2.endDate, newConn);
                        BindDataGridView();
                    }
                    else
                    {
                        index2 = cmbCategory2.SelectedIndex;
                        sp = "Show_SoldItems_By_Category_1_2_New";
                        DataBind(sp, index1, index2, parentForm2.startDate, parentForm2.endDate, newConn);
                        BindDataGridView();
                    }
                }
                else
                {
                    sp = "Show_SoldItems_By_Category_1_New";
                    DataBind(sp, index1, parentForm2.startDate, parentForm2.endDate, newConn);
                    BindDataGridView();
                }

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    CDNetSales = CDNetSales + Convert.ToDouble(dataGridView1.Rows[i].Cells[13].Value);
                    soldQty = Convert.ToInt16(dataGridView1.Rows[i].Cells[14].Value);

                    if (Convert.ToDouble(dataGridView1.Rows[i].Cells[12].Value) > 0 | Convert.ToDouble(dataGridView1.Rows[i].Cells[13].Value) == 0)
                        CDTotalDiscount = CDTotalDiscount + ((Convert.ToDouble(dataGridView1.Rows[i].Cells[11].Value) * soldQty) - Convert.ToDouble(dataGridView1.Rows[i].Cells[13].Value));

                    if (Convert.ToInt16(dataGridView1.Rows[i].Cells[14].Value) > 0)
                    {
                        CDSoldQty = CDSoldQty + Convert.ToInt16(dataGridView1.Rows[i].Cells[14].Value);
                    }
                    else
                    {
                        CDReturnQty = CDReturnQty + Convert.ToInt16(dataGridView1.Rows[i].Cells[14].Value);
                    }
                }

                lblCDNetSales.Text = string.Format("{0:$0.00}", CDNetSales);
                lblCDTotalDiscount.Text = string.Format("{0:$0.00}", CDTotalDiscount);
                lblCDSoldQty.Text = Convert.ToString(CDSoldQty);
                lblCDReturnQty.Text = Convert.ToString(CDReturnQty);
                lblCDPercentage.Text = string.Format("{0:P}", CDNetSales / CDCategory1Nasles);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void DataBind(string sp, int index1, string startDate, string endDate,SqlConnection cn)
        {
            cmd = new SqlCommand(sp, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
            cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
            dt.Clear();
            adapt.SelectCommand = cmd;

            cn.Open();
            //parentForm1.conn.Open();
            adapt.Fill(dt);
            //parentForm1.conn.Close();
            cn.Close();
        }

        public void DataBind(string sp, int index1, int index2, string startDate, string endDate, SqlConnection cn)
        {
            cmd = new SqlCommand(sp, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
            cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = index2;
            cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
            dt.Clear();
            adapt.SelectCommand = cmd;

            cn.Open();
            //parentForm1.conn.Open();
            adapt.Fill(dt);
            //parentForm1.conn.Close();
            cn.Close();
        }

        public void DataBind(string sp, int index1, int index2, int index3, string startDate, string endDate, SqlConnection cn)
        {
            cmd = new SqlCommand(sp, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
            cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = index2;
            cmd.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = index3;
            cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
            dt.Clear();
            adapt.SelectCommand = cmd;

            cn.Open();
            //parentForm1.conn.Open();
            adapt.Fill(dt);
            //parentForm1.conn.Close();
            cn.Close();
        }

        private void BindDataGridView()
        {
            if (parentForm1.userLevel >= parentForm1.SystemAdministratorLV)
            {
                dataGridView1.RowTemplate.Height = 30;
                dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                dataGridView1.DataSource = dt;
            }
            else
            {
                dataGridView1.RowTemplate.Height = 30;
                dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].HeaderText = "BRAND";
                dataGridView1.Columns[8].HeaderText = "NAME";
                dataGridView1.Columns[9].HeaderText = "SIZE";
                dataGridView1.Columns[10].HeaderText = "COLOR";

                dataGridView1.Columns[11].HeaderText = "RETAIL PRICE";
                dataGridView1.Columns[11].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[12].HeaderText = "DISCOUNT PRICE";
                dataGridView1.Columns[12].DefaultCellStyle.FormatProvider = nfi;
                dataGridView1.Columns[12].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[13].HeaderText = "SOLD PRICE";
                dataGridView1.Columns[13].DefaultCellStyle.FormatProvider = nfi;
                dataGridView1.Columns[13].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[14].HeaderText = "QTY";
                dataGridView1.Columns[15].HeaderText = "ONHAND";
                dataGridView1.Columns[16].HeaderText = "UPC";
                dataGridView1.Columns[17].HeaderText = "SOLD DATE";
                dataGridView1.Columns[18].HeaderText = "SOLD TIME";
                dataGridView1.Columns[19].Visible = false;
            }

            btnOK.Enabled = true;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (parentForm1.employeeID.ToUpper() == "ADMIN" | parentForm1.specialCode == parentForm1.txtSpecialCode.Text.Trim().ToString().ToUpper())
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
    }
}