using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using Office_12 = Microsoft.Office.Core;
using Excel_12 = Microsoft.Office.Interop.Excel;

namespace Management
{
    public partial class POandReceivingForWarehouse : Form
    {
        public LogInManagements parentForm;
        public SqlCommand cmd;
        public SqlCommand cmd2;
        //SqlCommand cmd3;
        public SqlDataAdapter adapt;
        public DataTable dt;

        public SqlConnection[] connection = new SqlConnection[11];
        public string[] storeName = new string[11];
        public SqlConnection connOH;
        public SqlConnection connCH;
        public SqlConnection connWB;
        public SqlConnection connCV;
        public SqlConnection connUM;
        public SqlConnection connWM;
        public SqlConnection connTH;
        public SqlConnection connWD;
        public SqlConnection connPW;
        public SqlConnection connGB;
        public SqlConnection connBW;

        public int dateOption = 0;
        public string startDate, endDate;

        public int storeOption = 0;

        //Int64 numOfPO = 0;
        double totalOrderAmount = 0;
        double totalReceivingAmount = 0;
        double totalSendingAmount = 0;

        public Font drvFont = new Font("Arial", 10);
        public Font drvFont2 = new Font("Arial", 9);

        public bool boolNumPO = false;
        public bool boolNumRR = false;

        public POandReceivingForWarehouse()
        {
            InitializeComponent();
        }

        private void POandReceivingForWarehouse_Load(object sender, EventArgs e)
        {
            this.Text = "P/O AND RECEIVING FOR WAREHOUSE - " + parentForm.employeeID + " LOGGED IN " + parentForm.storeName;

            lblStoreName.Text = parentForm.storeName;
            lblStoreCode.Text = parentForm.StoreCode;
            lblEmployeeID.Text = parentForm.employeeID;

            if (parentForm.userLevel < parentForm.btnPOReceivingEditCostPrice)
                btnEditCostPrice.Enabled = false;

            if (parentForm.userLevel < parentForm.btnPOReceivingExcel)
                btnExcel.Enabled = false;

            //if (parentForm.userLevel < parentForm.btnPOReceivingDeletePO)
            //    btnDeletePO.Enabled = false;

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

            connection[0] = connTH;
            connection[1] = connOH;
            connection[2] = connUM;
            connection[3] = connCH;
            connection[4] = connWM;
            connection[5] = connCV;
            connection[6] = connPW;
            connection[7] = connWB;
            connection[8] = connWD;
            connection[9] = connGB;
            connection[10] = connBW;

            storeName[0] = "TEMPLE HILLS";
            storeName[1] = "OXON HILL";
            storeName[2] = "UPPER MARLBORO";
            storeName[3] = "CAPITOL HEIGHTS";
            storeName[4] = "WINDSOR MILL";
            storeName[5] = "CATONSVILLE";
            storeName[6] = "PRINCE WILLIAM";
            storeName[7] = "WOODBRIDGE";
            storeName[8] = "WALDORF";
            storeName[9] = "GAITHERSBURG";
            storeName[10] = "BOWIE";
        }

        private void btnSearchPOList_Click(object sender, EventArgs e)
        {
            if (CheckOpened("ReceivingReturn") == true)
            {
                MessageBox.Show("PLEASE CLOSE EXISING RECEIVING RETURN WINDOWS(S)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                SearchPOListOption searchPOListOptionForm = new SearchPOListOption();
                searchPOListOptionForm.parentForm1 = this.parentForm;
                searchPOListOptionForm.parentForm3 = this;
                searchPOListOptionForm.ShowDialog();
            }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SearchPOList()
        {
            this.Text = "P/O AND RECEIVING FOR WAREHOUSE - " + parentForm.employeeID + " LOGGED IN " + parentForm.storeName;

            totalOrderAmount = 0;
            totalReceivingAmount = 0;
            dt = new DataTable();
            dataGridView1.DataSource = null;

            if (storeOption == 0)
            {
                if (parentForm.userLevel >= parentForm.btnPOReceivingSearchPOList)
                {
                    try
                    {
                        cmd = new SqlCommand("Show_POList_All", parentForm.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                        cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                        cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                        adapt = new SqlDataAdapter();
                        adapt.SelectCommand = cmd;

                        parentForm.conn.Open();
                        //dt.Clear();
                        adapt.Fill(dt);
                        parentForm.conn.Close();
                    }
                    catch
                    {
                        MessageBox.Show("DB UPDATE FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        parentForm.conn.Close();
                    }
                }
                else
                {
                    try
                    {
                        cmd = new SqlCommand("Show_POList", parentForm.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = parentForm.employeeID.ToUpper();
                        cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                        cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                        cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                        adapt = new SqlDataAdapter();
                        adapt.SelectCommand = cmd;

                        parentForm.conn.Open();
                        //dt.Clear();
                        adapt.Fill(dt);
                        parentForm.conn.Close();
                    }
                    catch
                    {
                        MessageBox.Show("DB UPDATE FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        parentForm.conn.Close();
                    }
                }

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RowTemplate.Height = 40;
                dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 65;
                dataGridView1.Columns[0].HeaderText = "P/O ID";
                dataGridView1.Columns[1].Width = 50;
                dataGridView1.Columns[1].HeaderText = "STORE CODE";
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Width = 70;
                dataGridView1.Columns[3].HeaderText = "VENDOR CODE";
                dataGridView1.Columns[4].Width = 120;
                dataGridView1.Columns[4].HeaderText = "VENDOR NAME";
                dataGridView1.Columns[5].Width = 88;
                dataGridView1.Columns[5].HeaderText = "CREATE DATE";
                dataGridView1.Columns[6].Width = 88;
                dataGridView1.Columns[6].HeaderText = "RECEIVE DATE";
                dataGridView1.Columns[7].Width = 88;
                dataGridView1.Columns[7].HeaderText = "ORDER AMOUNT";
                dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[7].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[7].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                dataGridView1.Columns[8].HeaderText = "RECEIVING AMOUNT";
                dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[8].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[8].DefaultCellStyle.BackColor = Color.NavajoWhite;
                dataGridView1.Columns[8].Width = 85;
                dataGridView1.Columns[8].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[9].Width = 80;
                dataGridView1.Columns[9].HeaderText = "EMPLOYEE ID";
                dataGridView1.Columns[10].Width = 90;
                dataGridView1.Columns[10].HeaderText = "P/O STATUS";

                totalOrderAmount = 0;
                totalReceivingAmount = 0;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    /*cmd = new SqlCommand("Get_WarehouseStatus", parentForm.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                    cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                    SqlParameter WHStatus_Param1 = cmd.Parameters.Add("@WarehouseStatus", SqlDbType.Int);
                    SqlParameter WHStatus_Param2 = cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar, 20);
                    WHStatus_Param1.Direction = ParameterDirection.Output;
                    WHStatus_Param2.Direction = ParameterDirection.Output;

                    parentForm.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm.conn.Close();

                    if (cmd.Parameters["@WarehouseStatus"].Value != DBNull.Value)
                        dataGridView1.Rows[i].Cells[11].Value = Convert.ToInt16(cmd.Parameters["@WarehouseStatus"].Value);

                    if (cmd.Parameters["@ShippingDate"].Value != DBNull.Value)
                        dataGridView1.Rows[i].Cells[12].Value = Convert.ToString(cmd.Parameters["@ShippingDate"].Value);*/

                    if (Convert.ToString(dataGridView1.Rows[i].Cells[4].Value).ToUpper() == parentForm.WarehouseName1.ToUpper() && Convert.ToString(dataGridView1.Rows[i].Cells[10].Value).ToUpper() == "ORDERING")
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;

                    totalOrderAmount = totalOrderAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value);
                    totalReceivingAmount = totalReceivingAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);
                }

                label4.Text = "NUMBER OF P/O";
                label6.Text = "TOTAL ORDER AMOUNT";

                lblNumOfPO.Text = Convert.ToString(dataGridView1.RowCount);
                lblTotalOrderAmount.Text = string.Format("{0:c}", totalOrderAmount);
                lblTotalReceivingAmount.Text = string.Format("{0:c}", totalReceivingAmount);
                lblTotalSendingAmount.Text = "N/A";

                boolNumPO = true;
                boolNumRR = false;
                dataGridView1.ClearSelection();
            }
            else
            {
                /*try
                {
                    cmd = new SqlCommand("Show_POList_From_Other_Store", connTH);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                    cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                    cmd.Parameters.Add("@VendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                    adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd;

                    connTH.Open();
                    adapt.Fill(dt);
                    connTH.Close();

                    //progressBar1.PerformStep();
                    progressBar1.Value = 1;
                }
                catch
                {
                    MessageBox.Show("CAN NOT CONNECT TEMPLE HILLS SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connTH.Close();
                }

                try
                {
                    cmd = new SqlCommand("Show_POList_From_Other_Store", connOH);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                    cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                    cmd.Parameters.Add("@VendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                    adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd;

                    connOH.Open();
                    adapt.Fill(dt);
                    connOH.Close();

                    //progressBar1.PerformStep();
                    progressBar1.Value = 2;
                }
                catch
                {
                    MessageBox.Show("CAN NOT CONNECT OXON HILL SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connOH.Close();
                }

                try
                {
                    cmd = new SqlCommand("Show_POList_From_Other_Store", connUM);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                    cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                    cmd.Parameters.Add("@VendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                    adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd;

                    connUM.Open();
                    adapt.Fill(dt);
                    connUM.Close();

                    //progressBar1.PerformStep();
                    progressBar1.Value = 3;
                }
                catch
                {
                    MessageBox.Show("CAN NOT CONNECT UPPER MARLBORO SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connUM.Close();
                }

                try
                {
                    cmd = new SqlCommand("Show_POList_From_Other_Store", connCH);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                    cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                    cmd.Parameters.Add("@VendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                    adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd;

                    connCH.Open();
                    adapt.Fill(dt);
                    connCH.Close();

                    //progressBar1.PerformStep();
                    progressBar1.Value = 4;
                }
                catch
                {
                    MessageBox.Show("CAN NOT CONNECT CAPITOL HEIGHTS SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connCH.Close();
                }

                try
                {
                    cmd = new SqlCommand("Show_POList_From_Other_Store", connWM);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                    cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                    cmd.Parameters.Add("@VendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                    adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd;

                    connWM.Open();
                    adapt.Fill(dt);
                    connWM.Close();

                    //progressBar1.PerformStep();
                    progressBar1.Value = 5;
                }
                catch
                {
                    MessageBox.Show("CAN NOT CONNECT WINDSOR MILL SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connWM.Close();
                }

                try
                {
                    cmd = new SqlCommand("Show_POList_From_Other_Store", connCV);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                    cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                    cmd.Parameters.Add("@VendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                    adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd;

                    connCV.Open();
                    adapt.Fill(dt);
                    connCV.Close();

                    //progressBar1.PerformStep();
                    progressBar1.Value = 6;
                }
                catch
                {
                    MessageBox.Show("CAN NOT CONNECT CATONSVILLE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connCV.Close();
                }

                try
                {
                    cmd = new SqlCommand("Show_POList_From_Other_Store", connWB);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                    cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                    cmd.Parameters.Add("@VendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                    adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd;

                    connWB.Open();
                    adapt.Fill(dt);
                    connWB.Close();

                    //progressBar1.PerformStep();
                    progressBar1.Value = 7;
                }
                catch
                {
                    MessageBox.Show("CAN NOT CONNECT WOODBRIDGE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connWB.Close();
                }

                try
                {
                    cmd = new SqlCommand("Show_POList_From_Other_Store", connWD);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                    cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                    cmd.Parameters.Add("@VendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                    adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd;

                    connWD.Open();
                    adapt.Fill(dt);
                    connWD.Close();

                    //progressBar1.PerformStep();
                    progressBar1.Value = 8;
                }
                catch
                {
                    MessageBox.Show("CAN NOT CONNECT WALDORF SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connWD.Close();
                }

                try
                {
                    cmd = new SqlCommand("Show_POList_From_Other_Store", connPW);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                    cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                    cmd.Parameters.Add("@VendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                    adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd;

                    connPW.Open();
                    adapt.Fill(dt);
                    connPW.Close();

                    //progressBar1.PerformStep();
                    progressBar1.Value = 9;
                }
                catch
                {
                    MessageBox.Show("CAN NOT CONNECT PRINCE WILIIAM SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connPW.Close();
                }

                try
                {
                    cmd = new SqlCommand("Show_POList_From_Other_Store", connGB);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                    cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                    cmd.Parameters.Add("@VendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                    adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd;

                    connGB.Open();
                    adapt.Fill(dt);
                    connGB.Close();

                    //progressBar1.PerformStep();
                    progressBar1.Value = 10;
                }
                catch
                {
                    MessageBox.Show("CAN NOT CONNECT GAITHERSBURG SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connGB.Close();
                }

                try
                {
                    cmd = new SqlCommand("Show_POList_From_Other_Store", connBW);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                    cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                    cmd.Parameters.Add("@VendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                    adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd;

                    connBW.Open();
                    adapt.Fill(dt);
                    connBW.Close();

                    //progressBar1.PerformStep();
                    progressBar1.Value = 11;
                }
                catch
                {
                    MessageBox.Show("CAN NOT CONNECT BOWIE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connBW.Close();
                }*/

                backgroundWorker1.RunWorkerAsync();
            }
        }

        public void SearchAllReturnReportList()
        {
            this.Text = "RETURN REPORT LIST OF ALL STORES - " + parentForm.employeeID + " LOGGED IN " + parentForm.storeName;
            
            totalOrderAmount = 0;
            totalReceivingAmount = 0;
            dt = new DataTable();
            dataGridView1.DataSource = null;

            /*try
            {
                cmd = new SqlCommand("Show_ReturnReportList_All_From_WH", connTH);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                cmd.Parameters.Add("@WHVendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                connTH.Open();
                adapt.Fill(dt);
                connTH.Close();

                progressBar1.PerformStep();
            }
            catch
            {
                MessageBox.Show("CAN NOT CONNECT TEMPLE HILLS SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connTH.Close();
            }

            try
            {
                cmd = new SqlCommand("Show_ReturnReportList_All_From_WH", connOH);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                cmd.Parameters.Add("@WHVendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                connOH.Open();
                adapt.Fill(dt);
                connOH.Close();

                progressBar1.PerformStep();
            }
            catch
            {
                MessageBox.Show("CAN NOT CONNECT OXON HILL SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connOH.Close();
            }

            try
            {
                cmd = new SqlCommand("Show_ReturnReportList_All_From_WH", connUM);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                cmd.Parameters.Add("@WHVendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                connUM.Open();
                adapt.Fill(dt);
                connUM.Close();

                progressBar1.PerformStep();
            }
            catch
            {
                MessageBox.Show("CAN NOT CONNECT UPPER MARLBORO SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connUM.Close();
            }

            try
            {
                cmd = new SqlCommand("Show_ReturnReportList_All_From_WH", connCH);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                cmd.Parameters.Add("@WHVendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                connCH.Open();
                adapt.Fill(dt);
                connCH.Close();

                progressBar1.PerformStep();
            }
            catch
            {
                MessageBox.Show("CAN NOT CONNECT CAPITOL HEIGHTS SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connCH.Close();
            }

            try
            {
                cmd = new SqlCommand("Show_ReturnReportList_All_From_WH", connWM);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                cmd.Parameters.Add("@WHVendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                connWM.Open();
                adapt.Fill(dt);
                connWM.Close();

                progressBar1.PerformStep();
            }
            catch
            {
                MessageBox.Show("CAN NOT CONNECT WINDSOR MILL SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connWM.Close();
            }

            try
            {
                cmd = new SqlCommand("Show_ReturnReportList_All_From_WH", connCV);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                cmd.Parameters.Add("@WHVendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                connCV.Open();
                adapt.Fill(dt);
                connCV.Close();

                progressBar1.PerformStep();
            }
            catch
            {
                MessageBox.Show("CAN NOT CONNECT CATONSVILLE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connCV.Close();
            }

            try
            {
                cmd = new SqlCommand("Show_ReturnReportList_All_From_WH", connWB);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                cmd.Parameters.Add("@WHVendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                connWB.Open();
                adapt.Fill(dt);
                connWB.Close();

                progressBar1.PerformStep();
            }
            catch
            {
                MessageBox.Show("CAN NOT CONNECT WOODBRIDGE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connWB.Close();
            }

            try
            {
                cmd = new SqlCommand("Show_ReturnReportList_All_From_WH", connWD);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                cmd.Parameters.Add("@WHVendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                connWD.Open();
                adapt.Fill(dt);
                connWD.Close();

                progressBar1.PerformStep();
            }
            catch
            {
                MessageBox.Show("CAN NOT CONNECT WALDORF SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connWD.Close();
            }

            try
            {
                cmd = new SqlCommand("Show_ReturnReportList_All_From_WH", connPW);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                cmd.Parameters.Add("@WHVendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                connPW.Open();
                adapt.Fill(dt);
                connPW.Close();

                progressBar1.PerformStep();
            }
            catch
            {
                MessageBox.Show("CAN NOT CONNECT PRINCE WILIIAM SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connPW.Close();
            }

            try
            {
                cmd = new SqlCommand("Show_ReturnReportList_All_From_WH", connGB);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                cmd.Parameters.Add("@WHVendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                connGB.Open();
                adapt.Fill(dt);
                connGB.Close();

                progressBar1.PerformStep();
            }
            catch
            {
                MessageBox.Show("CAN NOT CONNECT GAITHERSBURG SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connGB.Close();
            }

            try
            {
                cmd = new SqlCommand("Show_ReturnReportList_All_From_WH", connBW);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                cmd.Parameters.Add("@WHVendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                connBW.Open();
                adapt.Fill(dt);
                connBW.Close();

                progressBar1.PerformStep();
            }
            catch
            {
                MessageBox.Show("CAN NOT CONNECT BOWIE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connBW.Close();
            }*/

            backgroundWorker2.RunWorkerAsync();
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (storeOption == 0)
            {
                totalOrderAmount = 0;
                totalReceivingAmount = 0;
                dt = new DataTable();

                cmd = new SqlCommand("Show_POList", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = dataGridView1.SelectedCells[9].Value.ToString();
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                parentForm.conn.Open();
                //dt.Clear();
                adapt.Fill(dt);
                parentForm.conn.Close();

                dataGridView1.RowTemplate.Height = 40;
                dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 65;
                dataGridView1.Columns[0].HeaderText = "P/O ID";
                dataGridView1.Columns[1].Width = 50;
                dataGridView1.Columns[1].HeaderText = "STORE CODE";
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Width = 110;
                dataGridView1.Columns[3].HeaderText = "VENDOR CODE";
                dataGridView1.Columns[4].Width = 120;
                dataGridView1.Columns[4].HeaderText = "VENDOR NAME";
                dataGridView1.Columns[5].Width = 88;
                dataGridView1.Columns[5].HeaderText = "CREATE DATE";
                dataGridView1.Columns[6].Width = 88;
                dataGridView1.Columns[6].HeaderText = "RECEIVE DATE";
                dataGridView1.Columns[7].Width = 85;
                dataGridView1.Columns[7].HeaderText = "ORDER TOTAL AMOUNT";
                dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[7].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[7].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                dataGridView1.Columns[8].HeaderText = "RECEIVING TOTAL AMOUNT";
                dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[8].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[8].DefaultCellStyle.BackColor = Color.NavajoWhite;
                dataGridView1.Columns[8].Width = 85;
                dataGridView1.Columns[8].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[9].Width = 80;
                dataGridView1.Columns[9].HeaderText = "EMPLOYEE ID";
                dataGridView1.Columns[10].Width = 90;
                dataGridView1.Columns[10].HeaderText = "P/O STATUS";

                totalOrderAmount = 0;
                totalReceivingAmount = 0;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    totalOrderAmount = totalOrderAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value);
                    totalReceivingAmount = totalReceivingAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);
                }

                lblNumOfPO.Text = Convert.ToString(dataGridView1.RowCount);
                lblTotalOrderAmount.Text = string.Format("{0:$0.00}", totalOrderAmount);
                lblTotalReceivingAmount.Text = string.Format("{0:$0.00}", totalReceivingAmount);
            }
            else if (storeOption == 1)
            {
                return;
            }
        }

        private void btnLoadPO_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
                return;

            if (storeOption == 0)
            {
                if (dataGridView1.SelectedRows.Count == 0)
                    return;

                if (Convert.ToString(dataGridView1.SelectedCells[10].Value) == "EMPTY")
                {
                    POMain POMainForm = new POMain(0, 2);
                    POMainForm.parentForm1 = this.parentForm;
                    POMainForm.parentForm5 = this;
                    POMainForm.Show();
                }
                else if (Convert.ToString(dataGridView1.SelectedCells[10].Value) == "PENDING")
                {
                    POMain POMainForm = new POMain(1, 2);
                    POMainForm.parentForm1 = this.parentForm;
                    POMainForm.parentForm5 = this;
                    POMainForm.Show();
                }
                else if (Convert.ToString(dataGridView1.SelectedCells[10].Value) == "ORDERING")
                {
                    POMain POMainForm = new POMain(2, 2);
                    POMainForm.parentForm1 = this.parentForm;
                    POMainForm.parentForm5 = this;
                    POMainForm.Show();
                }
                else if (Convert.ToString(dataGridView1.SelectedCells[10].Value) == "PACKING")
                {
                    POMain POMainForm = new POMain(2, 2);
                    POMainForm.parentForm1 = this.parentForm;
                    POMainForm.parentForm5 = this;
                    POMainForm.Show();
                }
                else if (Convert.ToString(dataGridView1.SelectedCells[10].Value) == "SENT")
                {
                    POMain POMainForm = new POMain(2, 2);
                    POMainForm.parentForm1 = this.parentForm;
                    POMainForm.parentForm5 = this;
                    POMainForm.Show();
                }
                else if (Convert.ToString(dataGridView1.SelectedCells[10].Value) == "RECEIVED")
                {
                    POMain POMainForm = new POMain(3, 2);
                    POMainForm.parentForm1 = this.parentForm;
                    POMainForm.parentForm5 = this;
                    POMainForm.Show();
                }
            }
            else if (storeOption == 1)
            {
                if (Convert.ToString(dataGridView1.SelectedCells[11].Value).ToUpper() != "PENDING")
                {
                    POSending POSendingForm = new POSending(Convert.ToInt16(dataGridView1.SelectedCells[12].Value));
                    POSendingForm.parentForm1 = this.parentForm;
                    POSendingForm.parentForm2 = this;
                    POSendingForm.Show();
                }
                else
                {
                    MessageBox.Show("THIS P/O IS NOT READY", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnEditCostPrice_Click(object sender, EventArgs e)
        {
            EditCostPrice editCostPriceForm = new EditCostPrice();
            editCostPriceForm.parentForm = this.parentForm;
            editCostPriceForm.Show();
        }

        private void btnInvoiceSummary_Click(object sender, EventArgs e)
        {
            InvoiceSummaryMain invoiceSummaryMainFrom = new InvoiceSummaryMain();
            invoiceSummaryMainFrom.parentForm = this.parentForm;
            invoiceSummaryMainFrom.Show();
        }

        private void btnReceiving_Click(object sender, EventArgs e)
        {
            if (boolNumPO == true)
            {
                if (dataGridView1.SelectedRows.Count == 0)
                    return;

                if (Convert.ToString(dataGridView1.SelectedCells[4].Value).ToUpper() == parentForm.WarehouseName1.ToUpper())
                {
                    MessageBox.Show("CHECK VENDOR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (Convert.ToString(dataGridView1.SelectedCells[10].Value) == "ORDERING" | Convert.ToString(dataGridView1.SelectedCells[10].Value) == "RECEIVED")
                    {
                        if (parentForm.userLevel < 5)
                        {
                            if (parentForm.employeeID != Convert.ToString(dataGridView1.SelectedCells[9].Value).ToUpper())
                            {
                                MessageBox.Show("THIS IS NOT YOUR P/O", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                if (CheckOpened("ReceivingReturn") == true)
                                {
                                    MessageBox.Show("PLEASE CLOSE EXISING RECEIVING RETURN WINDOWS(S)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                else
                                {
                                    ReceivingMain receivingMainForm = new ReceivingMain();
                                    receivingMainForm.parentForm1 = this.parentForm;
                                    receivingMainForm.parentForm3 = this;
                                    receivingMainForm.boolWarehouse = true;
                                    receivingMainForm.Show();
                                }
                            }
                        }
                        else
                        {
                            if (CheckOpened("ReceivingReturn") == true)
                            {
                                MessageBox.Show("PLEASE CLOSE EXISING RECEIVING RETURN WINDOWS(S)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                ReceivingMain receivingMainForm = new ReceivingMain();
                                receivingMainForm.parentForm1 = this.parentForm;
                                receivingMainForm.parentForm3 = this;
                                receivingMainForm.boolWarehouse = true;
                                receivingMainForm.Show();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("P/O STATUS IS NOT RECEIVABLE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (boolNumPO == true)
            {
                if (dataGridView1.RowCount > 0)
                {
                    totalOrderAmount = 0;
                    totalReceivingAmount = 0;

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        /*cmd = new SqlCommand("Get_WarehouseStatus", parentForm.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                        cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                        SqlParameter WHStatus_Param1 = cmd.Parameters.Add("@WarehouseStatus", SqlDbType.Int);
                        SqlParameter WHStatus_Param2 = cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar, 20);
                        WHStatus_Param1.Direction = ParameterDirection.Output;
                        WHStatus_Param2.Direction = ParameterDirection.Output;

                        parentForm.conn.Open();
                        cmd.ExecuteNonQuery();
                        parentForm.conn.Close();

                        if (cmd.Parameters["@WarehouseStatus"].Value != DBNull.Value)
                            dataGridView1.Rows[i].Cells[11].Value = Convert.ToInt16(cmd.Parameters["@WarehouseStatus"].Value);

                        if (cmd.Parameters["@ShippingDate"].Value != DBNull.Value)
                            dataGridView1.Rows[i].Cells[12].Value = Convert.ToString(cmd.Parameters["@ShippingDate"].Value);*/

                        if (Convert.ToString(dataGridView1.Rows[i].Cells[4].Value).ToUpper() == parentForm.WarehouseName1.ToUpper() && Convert.ToString(dataGridView1.Rows[i].Cells[11].Value).ToUpper() == "ORDERING")
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;

                        if (Convert.ToString(dataGridView1.Rows[i].Cells[4].Value).ToUpper() == parentForm.WarehouseName1.ToUpper() && Convert.ToString(dataGridView1.Rows[i].Cells[11].Value).ToUpper() == "RECEIVED")
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Silver;

                        totalOrderAmount = totalOrderAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value);
                        totalReceivingAmount = totalReceivingAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);
                    }

                    lblNumOfPO.Text = Convert.ToString(dataGridView1.RowCount);
                    lblTotalOrderAmount.Text = string.Format("{0:c}", totalOrderAmount);
                    lblTotalReceivingAmount.Text = string.Format("{0:c}", totalReceivingAmount);
                }
            }
            else if (boolNumRR == true)
            {
                totalOrderAmount = 0;
                totalReceivingAmount = 0;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (Convert.ToString(dataGridView1.Rows[i].Cells[21].Value).ToUpper() == "SUBMITTED")
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;

                    if (Convert.ToString(dataGridView1.Rows[i].Cells[21].Value).ToUpper() == "RETURNED")
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Silver;

                    totalOrderAmount = totalOrderAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[17].Value);
                    totalReceivingAmount = totalReceivingAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[18].Value);
                }

                lblNumOfPO.Text = Convert.ToString(dataGridView1.RowCount);
                lblTotalOrderAmount.Text = string.Format("{0:c}", totalOrderAmount);
                lblTotalReceivingAmount.Text = string.Format("{0:c}", totalReceivingAmount);
            }
        }

        private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (boolNumPO == true)
            {
                if (dataGridView1.RowCount > 0)
                {
                    totalOrderAmount = 0;
                    totalReceivingAmount = 0;

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        /*cmd = new SqlCommand("Get_WarehouseStatus", parentForm.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                        cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                        SqlParameter WHStatus_Param1 = cmd.Parameters.Add("@WarehouseStatus", SqlDbType.Int);
                        SqlParameter WHStatus_Param2 = cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar, 20);
                        WHStatus_Param1.Direction = ParameterDirection.Output;
                        WHStatus_Param2.Direction = ParameterDirection.Output;

                        parentForm.conn.Open();
                        cmd.ExecuteNonQuery();
                        parentForm.conn.Close();

                        if (cmd.Parameters["@WarehouseStatus"].Value != DBNull.Value)
                            dataGridView1.Rows[i].Cells[11].Value = Convert.ToInt16(cmd.Parameters["@WarehouseStatus"].Value);

                        if (cmd.Parameters["@ShippingDate"].Value != DBNull.Value)
                            dataGridView1.Rows[i].Cells[12].Value = Convert.ToString(cmd.Parameters["@ShippingDate"].Value);*/

                        if (Convert.ToString(dataGridView1.Rows[i].Cells[4].Value).ToUpper() == parentForm.WarehouseName1.ToUpper() && Convert.ToString(dataGridView1.Rows[i].Cells[11].Value).ToUpper() == "ORDERING")
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;

                        if (Convert.ToString(dataGridView1.Rows[i].Cells[4].Value).ToUpper() == parentForm.WarehouseName1.ToUpper() && Convert.ToString(dataGridView1.Rows[i].Cells[11].Value).ToUpper() == "RECEIVED")
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Silver;

                        totalOrderAmount = totalOrderAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value);
                        totalReceivingAmount = totalReceivingAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);
                    }

                    lblNumOfPO.Text = Convert.ToString(dataGridView1.RowCount);
                    lblTotalOrderAmount.Text = string.Format("{0:c}", totalOrderAmount);
                    lblTotalReceivingAmount.Text = string.Format("{0:c}", totalReceivingAmount);
                }
            }
            else if (boolNumRR == true)
            {
                totalOrderAmount = 0;
                totalReceivingAmount = 0;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (Convert.ToString(dataGridView1.Rows[i].Cells[21].Value).ToUpper() == "SUBMITTED")
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;

                    if (Convert.ToString(dataGridView1.Rows[i].Cells[21].Value).ToUpper() == "RETURNED")
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Silver;

                    totalOrderAmount = totalOrderAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[17].Value);
                    totalReceivingAmount = totalReceivingAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[18].Value);
                }

                lblNumOfPO.Text = Convert.ToString(dataGridView1.RowCount);
                lblTotalOrderAmount.Text = string.Format("{0:c}", totalOrderAmount);
                lblTotalReceivingAmount.Text = string.Format("{0:c}", totalReceivingAmount);
            }
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (boolNumPO == true)
            {
                if (e.RowIndex != -1)
                {
                    btnLoadPO_Click(null, null);
                }
            }
        }

        private void btnCreateNewPO_Click(object sender, EventArgs e)
        {
            if (CheckOpened("ReceivingReturn") == true)
            {
                MessageBox.Show("PLEASE CLOSE EXISING RECEIVING RETURN WINDOWS(S)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                CreateNewPO createNewPOForm = new CreateNewPO(3);
                createNewPOForm.parentForm1 = this.parentForm;
                createNewPOForm.parentForm4 = this;
                createNewPOForm.ShowDialog();
            }
        }

        private void btnDeletePO_Click(object sender, EventArgs e)
        {
            if (storeOption > 0)
            {
                MessageBox.Show("YOU CAN NOT DELETE WAREHOUSE ORDERS FROM OTHER STORES", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult MyDialogResult;
                MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (MyDialogResult == DialogResult.Yes)
                {
                    if (parentForm.userLevel < parentForm.btnPOReceivingDeletePO)
                    {
                        if (Convert.ToString(dataGridView1.SelectedCells[10].Value).ToUpper() == "ORDERING" | Convert.ToString(dataGridView1.SelectedCells[10].Value).ToUpper() == "RECEIVED")
                        {
                            MessageBox.Show("CAN NOT DELETE THIS P/O", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            cmd = new SqlCommand("Delete_POHeader", parentForm.conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.SelectedCells[0].Value);

                            cmd2 = new SqlCommand("Delete_POBody", parentForm.conn);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.Clear();
                            cmd2.Parameters.Add("@POID", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.SelectedCells[0].Value);

                            parentForm.conn.Open();
                            cmd.ExecuteNonQuery();
                            cmd2.ExecuteNonQuery();
                            parentForm.conn.Close();

                            MessageBox.Show("SUCCESSFULLY DELETED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            SearchPOList();
                        }
                    }
                    else
                    {
                        cmd = new SqlCommand("Delete_POHeader", parentForm.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.SelectedCells[0].Value);

                        cmd2 = new SqlCommand("Delete_POBody", parentForm.conn);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.Clear();
                        cmd2.Parameters.Add("@POID", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.SelectedCells[0].Value);

                        parentForm.conn.Open();
                        cmd.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                        parentForm.conn.Close();

                        MessageBox.Show("SUCCESSFULLY DELETED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SearchPOList();
                    }
                }
                else
                {
                }
            }
            else
            {
                MessageBox.Show("NO P/O LIST", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnSearchAllReturnList_Click(object sender, EventArgs e)
        {
            if (CheckOpened("POMain") == true)
            {
                MessageBox.Show("PLEASE CLOSE EXISING P/O WINDOWS(S)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (CheckOpened("ReceivingMain") == true)
            {
                MessageBox.Show("PLEASE CLOSE EXISING P/O RECEIVING WINDOWS(S)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (CheckOpened("POSending") == true)
            {
                MessageBox.Show("PLEASE CLOSE EXISING P/O SENDING WINDOWS(S)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                SearchReturntListOption searchReturnReportListOptionForm = new SearchReturntListOption(2);
                searchReturnReportListOptionForm.parentForm1 = this.parentForm;
                searchReturnReportListOptionForm.parentForm3 = this;
                searchReturnReportListOptionForm.ShowDialog();
            }
        }

        private void btnReceivingReturn_Click(object sender, EventArgs e)
        {
            if (CheckOpened("POMain") == true)
            {
                MessageBox.Show("PLEASE CLOSE EXISING P/O WINDOWS(S)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (CheckOpened("ReceivingMain") == true)
            {
                MessageBox.Show("PLEASE CLOSE EXISING P/O RECEIVING WINDOWS(S)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (CheckOpened("POSending") == true)
            {
                MessageBox.Show("PLEASE CLOSE EXISING P/O SENDING WINDOWS(S)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

            }
        }

        public bool CheckOpened(string name)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 11; i++)
            {
                try
                {
                    cmd = new SqlCommand("Show_POList_From_Other_Store", connection[i]);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                    cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                    cmd.Parameters.Add("@VendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                    adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd;

                    connection[i].Open();
                    adapt.Fill(dt);
                    connection[i].Close();

                    backgroundWorker1.ReportProgress(i + 1);
                    System.Threading.Thread.Sleep(300);
                }
                catch
                {
                    MessageBox.Show("Can not connect " + storeName[i] + " server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection[i].Close();
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 65;
            dataGridView1.Columns[0].HeaderText = "P/O ID";
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[1].HeaderText = "STORE CODE";
            //dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Width = 70;
            dataGridView1.Columns[3].HeaderText = "VENDOR CODE";
            dataGridView1.Columns[4].Width = 185;
            dataGridView1.Columns[4].HeaderText = "VENDOR NAME";
            dataGridView1.Columns[5].Width = 90;
            dataGridView1.Columns[5].HeaderText = "CREATE DATE";
            dataGridView1.Columns[6].Width = 90;
            dataGridView1.Columns[6].HeaderText = "RECEIVE DATE";
            dataGridView1.Columns[7].Width = 88;
            dataGridView1.Columns[7].HeaderText = "ORDER AMOUNT";
            dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[7].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[7].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            //dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].HeaderText = "RECEIVING AMOUNT";
            dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[8].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[8].DefaultCellStyle.BackColor = Color.NavajoWhite;
            dataGridView1.Columns[8].Width = 85;
            dataGridView1.Columns[8].DefaultCellStyle.Format = "c";
            //dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].HeaderText = "SENDING AMOUNT";
            dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[9].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[9].DefaultCellStyle.BackColor = Color.LightYellow;
            dataGridView1.Columns[9].Width = 85;
            dataGridView1.Columns[9].DefaultCellStyle.Format = "c";
            //dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Width = 80;
            dataGridView1.Columns[10].HeaderText = "EMPLOYEE ID";
            dataGridView1.Columns[11].Width = 90;
            dataGridView1.Columns[11].HeaderText = "P/O STATUS";
            dataGridView1.Columns[12].Width = 55;
            dataGridView1.Columns[12].HeaderText = "WH STATUS";
            dataGridView1.Columns[13].Width = 90;
            dataGridView1.Columns[13].HeaderText = "SHIPPING DATE";
            dataGridView1.Columns[14].Width = 80;
            dataGridView1.Columns[14].HeaderText = "SENDER ID";

            totalOrderAmount = 0;
            totalReceivingAmount = 0;
            totalSendingAmount = 0;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                //cmd = new SqlCommand("Get_WarehouseStatus", parentForm.conn);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Clear();
                //cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                //cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                //SqlParameter WHStatus_Param1 = cmd.Parameters.Add("@WarehouseStatus", SqlDbType.Int);
                //SqlParameter WHStatus_Param2 = cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar, 20);
                //WHStatus_Param1.Direction = ParameterDirection.Output;
                //WHStatus_Param2.Direction = ParameterDirection.Output;

                //parentForm.conn.Open();
                //cmd.ExecuteNonQuery();
                //parentForm.conn.Close();

                //if (cmd.Parameters["@WarehouseStatus"].Value != DBNull.Value)
                //    dataGridView1.Rows[i].Cells[11].Value = Convert.ToInt16(cmd.Parameters["@WarehouseStatus"].Value);

                //if (cmd.Parameters["@ShippingDate"].Value != DBNull.Value)
                //    dataGridView1.Rows[i].Cells[12].Value = Convert.ToString(cmd.Parameters["@ShippingDate"].Value);

                cmd = new SqlCommand("Get_Sending_Amount", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = Convert.ToUInt64(dataGridView1.Rows[i].Cells[0].Value);
                cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                SqlParameter SendingAmount_Param = cmd.Parameters.Add("@SendingAmount", SqlDbType.Money);
                SendingAmount_Param.Direction = ParameterDirection.Output;

                parentForm.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm.conn.Close();

                if (cmd.Parameters["@SendingAmount"].Value == DBNull.Value)
                {
                    dataGridView1.Rows[i].Cells[9].Value = 0;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[9].Value = Convert.ToDouble(cmd.Parameters["@SendingAmount"].Value);
                }

                if (Convert.ToString(dataGridView1.Rows[i].Cells[4].Value).ToUpper() == parentForm.WarehouseName1.ToUpper() && Convert.ToString(dataGridView1.Rows[i].Cells[11].Value).ToUpper() == "ORDERING")
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;

                if (Convert.ToString(dataGridView1.Rows[i].Cells[4].Value).ToUpper() == parentForm.WarehouseName1.ToUpper() && Convert.ToString(dataGridView1.Rows[i].Cells[11].Value).ToUpper() == "RECEIVED")
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Silver;

                totalOrderAmount = totalOrderAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value);
                totalReceivingAmount = totalReceivingAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);
                totalSendingAmount = totalSendingAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[9].Value);
            }

            label4.Text = "NUMBER OF P/O";
            label6.Text = "TOTAL ORDER AMOUNT";

            lblNumOfPO.Text = Convert.ToString(dataGridView1.RowCount);
            lblTotalOrderAmount.Text = string.Format("{0:c}", totalOrderAmount);
            lblTotalReceivingAmount.Text = string.Format("{0:c}", totalReceivingAmount);
            lblTotalSendingAmount.Text = string.Format("{0:c}", totalSendingAmount);

            boolNumPO = true;
            boolNumRR = false;
            dataGridView1.ClearSelection();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 11; i++)
            {
                try
                {
                    cmd = new SqlCommand("Show_ReturnReportList_All_From_WH", connection[i]);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                    cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                    cmd.Parameters.Add("@WHVendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                    adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd;

                    connection[i].Open();
                    adapt.Fill(dt);
                    connection[i].Close();

                    backgroundWorker2.ReportProgress(i + 1);
                    System.Threading.Thread.Sleep(300);
                }
                catch
                {
                    MessageBox.Show("Can not connect " + storeName[i] + " server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection[i].Close();
                }
            }
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont2;
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "RR ID";
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[1].HeaderText = "SC";
            dataGridView1.Columns[1].Width = 30;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].HeaderText = "Vendor";
            dataGridView1.Columns[4].Width = 70;
            dataGridView1.Columns[5].HeaderText = "FName";
            dataGridView1.Columns[5].Width = 40;
            dataGridView1.Columns[6].HeaderText = "LName";
            dataGridView1.Columns[6].Width = 40;
            dataGridView1.Columns[7].HeaderText = "Employee ID";
            dataGridView1.Columns[7].Width = 50;
            dataGridView1.Columns[8].HeaderText = "Gp1";
            dataGridView1.Columns[8].Width = 30;
            dataGridView1.Columns[9].HeaderText = "Salesman Name";
            dataGridView1.Columns[9].Width = 60;
            dataGridView1.Columns[10].HeaderText = "Salesman Phone";
            dataGridView1.Columns[10].Width = 50;
            dataGridView1.Columns[11].HeaderText = "Create Date";
            dataGridView1.Columns[11].Width = 50;
            dataGridView1.Columns[12].HeaderText = "Packing Date";
            dataGridView1.Columns[12].Width = 50;
            dataGridView1.Columns[13].HeaderText = "Shipping Date";
            dataGridView1.Columns[13].Width = 50;
            dataGridView1.Columns[14].HeaderText = "Submit Date";
            dataGridView1.Columns[14].Width = 50;
            dataGridView1.Columns[15].HeaderText = "Returned Date";
            dataGridView1.Columns[15].Width = 50;
            dataGridView1.Columns[16].Visible = false;
            dataGridView1.Columns[17].HeaderText = "Total Return Amt";
            dataGridView1.Columns[17].Width = 40;
            dataGridView1.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[17].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[17].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            dataGridView1.Columns[18].HeaderText = "Total Receiving Amt";
            dataGridView1.Columns[18].Width = 40;
            dataGridView1.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[18].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[18].DefaultCellStyle.BackColor = Color.NavajoWhite;
            dataGridView1.Columns[19].Visible = false;
            dataGridView1.Columns[20].HeaderText = "Reason";
            dataGridView1.Columns[20].Width = 50;
            dataGridView1.Columns[21].HeaderText = "Sts";
            dataGridView1.Columns[21].Width = 50;
            dataGridView1.Columns[22].Visible = false;

            totalOrderAmount = 0;
            totalReceivingAmount = 0;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (Convert.ToString(dataGridView1.Rows[i].Cells[21].Value).ToUpper() == "SUBMITTED")
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;

                if (Convert.ToString(dataGridView1.Rows[i].Cells[21].Value).ToUpper() == "RETURNED")
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Silver;

                totalOrderAmount = totalOrderAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[17].Value);
                totalReceivingAmount = totalReceivingAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[18].Value);
            }

            label4.Text = "NUMBER OF RETURN";
            label6.Text = "TOTAL RETURN AMOUNT";

            lblNumOfPO.Text = Convert.ToString(dataGridView1.RowCount);
            lblTotalOrderAmount.Text = string.Format("{0:c}", totalOrderAmount);
            lblTotalReceivingAmount.Text = string.Format("{0:c}", totalReceivingAmount);
            lblTotalSendingAmount.Text = "N/A";

            boolNumPO = false;
            boolNumRR = true;
            dataGridView1.ClearSelection();
        }
    }
}