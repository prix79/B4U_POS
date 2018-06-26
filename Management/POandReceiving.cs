using System;
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

namespace Management
{
    public partial class POandReceiving : Form
    {
        public LogInManagements parentForm;
        public SqlCommand cmd;
        public SqlCommand cmd2;
        public SqlDataAdapter adapt;
        public DataTable dt = new DataTable();
        public DataTable dt2_All = new DataTable();
        public DataTable dt3 = new DataTable();

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

        //Int64 numOfPO = 0;
        double totalOrderAmount = 0;
        double totalReceivingAmount = 0;

        public Font drvFont = new Font("Arial", 10);
        public Font drvFont2 = new Font("Arial", 9);

        public bool boolNumPO = false;
        public bool boolNumRR = false;

        Int64 rrID;
        string rrEmployeeID;
        string rrEmployeeName;
        string rrStatus;
        string rrVendor;
        string rrCreateDate;
        string rrPackingDate;
        string rrShippingDate;
        string rrTrackingNumber;
        double rrTotalReturnAmount;

        public POandReceiving()
        {
            InitializeComponent();
        }

        private void POReceiving_Load(object sender, EventArgs e)
        {
            if (parentForm.StoreCode.ToUpper() == "B4UHQ")
            {
                this.Text = "P/O AND RECEIVING - " + parentForm.employeeID + " LOGGED IN " + parentForm.storeName;

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

                lblStoreName.Text = parentForm.storeName;
                lblStoreCode.Text = parentForm.StoreCode;
                lblEmployeeID.Text = parentForm.employeeID;

                btnSearchPOList.Enabled = false;
                btnItemSoldList.Enabled = false;
                btnCreateWarehousePO.Enabled = false;
                btnReceiving.Enabled = false;
                btnSearchReturnList.Enabled = false;
                btnCreateReturnReport.Enabled = false;
                btnInvoiceSummary.Enabled = false;
                btnDeletePO.Enabled = false;

                label6.Text = "TOTAL RETURN AMOUNT";
            }
            else
            {
                this.Text = "P/O AND RECEIVING - " + parentForm.employeeID + " LOGGED IN " + parentForm.storeName;

                lblStoreName.Text = parentForm.storeName;
                lblStoreCode.Text = parentForm.StoreCode;
                lblEmployeeID.Text = parentForm.employeeID;

                if (parentForm.userLevel < parentForm.btnPOReceivingEditCostPrice)
                    btnEditCostPrice.Enabled = false;

                if (parentForm.userLevel < parentForm.btnPOReceivingSoldItemList)
                    btnItemSoldList.Enabled = false;

                if (parentForm.userLevel < parentForm.btnPOReceivingExcel)
                    btnExcel.Enabled = false;

                //if (parentForm.userLevel < parentForm.btnPOReceivingDeletePO)
                //    btnDeletePO.Enabled = false;

                btnSearchAllReturnList.Visible = false;
            }
        }

        private void btnSearchPOList_Click(object sender, EventArgs e)
        {
            if (CheckOpened("ItemSoldListForReturn") == true)
            {
                MessageBox.Show("PLEASE CLOSE EXISING RETURN REPORT WINDOWS(S)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                SearchPOListOption searchPOListOptionForm = new SearchPOListOption();
                searchPOListOptionForm.parentForm1 = this.parentForm;
                searchPOListOptionForm.parentForm2 = this;
                searchPOListOptionForm.ShowDialog();
            }
        }

        private void btnCreateNewPO_Click(object sender, EventArgs e)
        {
            if (CheckOpened("ItemSoldListForReturn") == true)
            {
                MessageBox.Show("PLEASE CLOSE EXISING RETURN REPORT WINDOWS(S)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                CreateNewPO createNewPOForm = new CreateNewPO(0);
                createNewPOForm.parentForm1 = this.parentForm;
                createNewPOForm.parentForm2 = this;
                createNewPOForm.ShowDialog();
            }
        }

        private void btnLoadPO_Click(object sender, EventArgs e)
        {
            if (boolNumPO == true)
            {
                if (dataGridView1.RowCount == 0)
                    return;

                if (Convert.ToString(dataGridView1.SelectedCells[10].Value) == "EMPTY")
                {
                    POMain POMainForm = new POMain(0, 0);
                    POMainForm.parentForm1 = this.parentForm;
                    POMainForm.parentForm2 = this;
                    POMainForm.Show();
                }
                else if (Convert.ToString(dataGridView1.SelectedCells[10].Value) == "PENDING")
                {
                    POMain POMainForm = new POMain(1, 0);
                    POMainForm.parentForm1 = this.parentForm;
                    POMainForm.parentForm2 = this;
                    POMainForm.Show();
                }
                else if (Convert.ToString(dataGridView1.SelectedCells[10].Value) == "ORDERING")
                {
                    POMain POMainForm = new POMain(2, 0);
                    POMainForm.parentForm1 = this.parentForm;
                    POMainForm.parentForm2 = this;
                    POMainForm.Show();
                }
                else if (Convert.ToString(dataGridView1.SelectedCells[10].Value) == "PACKING")
                {
                    POMain POMainForm = new POMain(2, 0);
                    POMainForm.parentForm1 = this.parentForm;
                    POMainForm.parentForm2 = this;
                    POMainForm.Show();
                }
                else if (Convert.ToString(dataGridView1.SelectedCells[10].Value) == "SENT")
                {
                    POMain POMainForm = new POMain(2, 0);
                    POMainForm.parentForm1 = this.parentForm;
                    POMainForm.parentForm2 = this;
                    POMainForm.Show();
                }
                else if (Convert.ToString(dataGridView1.SelectedCells[10].Value) == "RECEIVED")
                {
                    POMain POMainForm = new POMain(3, 0);
                    POMainForm.parentForm1 = this.parentForm;
                    POMainForm.parentForm2 = this;
                    POMainForm.Show();
                }
            }
        }

        private void btnReceiving_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
                return;

            if (boolNumPO == true)
            {
                if (Convert.ToString(dataGridView1.SelectedCells[4].Value).ToUpper() == parentForm.WarehouseName1.ToUpper())
                {
                    if (Convert.ToString(dataGridView1.SelectedCells[10].Value) == "SENT" | Convert.ToString(dataGridView1.SelectedCells[10].Value) == "RECEIVED")
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
                                ReceivingMain receivingMainForm = new ReceivingMain();
                                receivingMainForm.parentForm1 = this.parentForm;
                                receivingMainForm.parentForm2 = this;
                                receivingMainForm.Show();
                            }
                        }
                        else
                        {
                            ReceivingMain receivingMainForm = new ReceivingMain();
                            receivingMainForm.parentForm1 = this.parentForm;
                            receivingMainForm.parentForm2 = this;
                            receivingMainForm.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("P/O (WAREHOUSE) STATUS IS NOT RECEIVABLE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
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
                                ReceivingMain receivingMainForm = new ReceivingMain();
                                receivingMainForm.parentForm1 = this.parentForm;
                                receivingMainForm.parentForm2 = this;
                                receivingMainForm.Show();
                            }
                        }
                        else
                        {
                            ReceivingMain receivingMainForm = new ReceivingMain();
                            receivingMainForm.parentForm1 = this.parentForm;
                            receivingMainForm.parentForm2 = this;
                            receivingMainForm.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("P/O STATUS IS NOT RECEIVABLE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else if (boolNumRR == true)
            {
            }
        }

        private void btnEditCostPrice_Click(object sender, EventArgs e)
        {
            EditCostPrice editCostPriceForm = new EditCostPrice();
            editCostPriceForm.parentForm = this.parentForm;
            editCostPriceForm.Show();
        }

        private void btnItemSoldList_Click(object sender, EventArgs e)
        {
            if (CheckOpened("ItemSoldListForReturn") == true)
            {
                MessageBox.Show("PLEASE CLOSE EXISING RETURN REPORT WINDOWS(S)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                ItemSoldList soldItemListForm = new ItemSoldList(0);
                soldItemListForm.parentForm = this.parentForm;
                soldItemListForm.parentForm2 = this;
                soldItemListForm.Show();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (parentForm.employeeID.ToUpper() == "ADMIN" | parentForm.specialCode == parentForm.txtSpecialCode.Text.Trim().ToString().ToUpper())
            {
                if (dataGridView1.RowCount > 0)
                {
                    if (boolNumPO == true)
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
                    else if (boolNumRR == true)
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
                        this.Enabled = false;

                        Excel_12.Application ReportFile;
                        Excel_12._Workbook WorkBook;
                        Excel_12._Worksheet WorkSheet;
                        //Excel_12.Range Range;

                        string MaxRow = Convert.ToString(dt3.Rows.Count + 1);
                        String MaxColumn = ((String)(Convert.ToChar(dt3.Columns.Count / 26 + 64).ToString() + Convert.ToChar(dt3.Columns.Count % 26 + 64))).Replace('@', ' ').Trim();
                        String MaxCell = MaxColumn + MaxRow;

                        ReportFile = new Excel_12.Application();
                        ReportFile.Visible = false;

                        WorkBook = (Excel_12._Workbook)(ReportFile.Workbooks.Add("workbook"));
                        WorkSheet = (Excel_12._Worksheet)WorkBook.ActiveSheet;

                        for (int i = 0; i < dt3.Columns.Count; i++)
                            WorkSheet.Cells[1, i + 1] = dt3.Columns[i].ColumnName;

                        string[,] Values = new string[dt3.Rows.Count, dt3.Columns.Count];

                        for (int i = 0; i < dt3.Rows.Count; i++)
                            for (int j = 0; j < dt3.Columns.Count; j++)
                            {

                                Values[i, j] = dt3.Rows[i][j].ToString();

                            }

                        WorkSheet.get_Range("A2", MaxCell).Value2 = Values;
                        ReportFile.Visible = true;
                        ReportFile.UserControl = true;

                        this.Enabled = true;
                    }
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

        private void btnDeletePO_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult MyDialogResult;
                MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (MyDialogResult == DialogResult.Yes)
                {
                    if (boolNumPO == true)
                    {
                        if (parentForm.userLevel < parentForm.btnPOReceivingDeletePO)
                        {
                            if (Convert.ToString(dataGridView1.SelectedCells[10].Value).ToUpper() == "PENDING")
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
                            else
                            {
                                MessageBox.Show("CAN NOT DELETE THIS P/O", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
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
                    else if (boolNumRR == true)
                    {
                        if (parentForm.userLevel < parentForm.btnPOReceivingDeletePO)
                        {
                            if (Convert.ToString(dataGridView1.SelectedCells[21].Value).ToUpper() == "PENDING")
                            {
                                cmd = new SqlCommand("Delete_ReturnReportHeader", parentForm.conn);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@rrID", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.SelectedCells[0].Value);

                                cmd2 = new SqlCommand("Delete_ReturnReportBody", parentForm.conn);
                                cmd2.CommandType = CommandType.StoredProcedure;
                                cmd2.Parameters.Clear();
                                cmd2.Parameters.Add("@rrID", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.SelectedCells[0].Value);

                                parentForm.conn.Open();
                                cmd.ExecuteNonQuery();
                                cmd2.ExecuteNonQuery();
                                parentForm.conn.Close();

                                MessageBox.Show("SUCCESSFULLY DELETED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                SearchReturnReportList();
                            }
                            else
                            {
                                MessageBox.Show("CAN NOT DELETE THIS RETURN REPORT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                        {
                            cmd = new SqlCommand("Delete_ReturnReportHeader", parentForm.conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@rrID", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.SelectedCells[0].Value);

                            cmd2 = new SqlCommand("Delete_ReturnReportBody", parentForm.conn);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.Clear();
                            cmd2.Parameters.Add("@rrID", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.SelectedCells[0].Value);

                            parentForm.conn.Open();
                            cmd.ExecuteNonQuery();
                            cmd2.ExecuteNonQuery();
                            parentForm.conn.Close();

                            MessageBox.Show("SUCCESSFULLY DELETED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            SearchReturnReportList();
                        }
                    }
                }
                else
                {
                }
            }
            else
            {
                MessageBox.Show("NO P/O OR RETURN LIST", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SearchPOList()
        {
            this.Text = "P/O AND RECEIVING - " + parentForm.employeeID + " LOGGED IN " + parentForm.storeName;

            totalOrderAmount = 0;
            totalReceivingAmount = 0;
            dataGridView1.DataSource = null;

            if (parentForm.userLevel >= parentForm.btnPOReceivingSearchPOList)
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
                dt.Clear();
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
            }
            else
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
                dt.Clear();
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
            }

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (Convert.ToString(dataGridView1.Rows[i].Cells[10].Value).ToUpper() == "RECEIVED")
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Silver;

                totalOrderAmount = totalOrderAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value);
                totalReceivingAmount = totalReceivingAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);
            }

            //lblNumOfPO.Text = string.Format("{0:n0}", dataGridView1.RowCount);
            //lblTotalOrderAmount.Text = string.Format("{0:c}", totalOrderAmount);
            //lblTotalReceivingAmount.Text = string.Format("{0:c}", totalReceivingAmount);

            label4.Text = "NUMBER OF P/O";
            label6.Text = "TOTAL ORDER AMOUNT";

            lblNumOfPO.Text = Convert.ToString(dataGridView1.RowCount);
            lblTotalOrderAmount.Text = string.Format("{0:c}", totalOrderAmount);
            lblTotalReceivingAmount.Text = string.Format("{0:c}", totalReceivingAmount);

            boolNumPO = true;
            boolNumRR = false;

            dataGridView1.ClearSelection();
        }

        public void SearchReturnReportList()
        {
            this.Text = "RETURN REPORT LIST - " + parentForm.employeeID + " LOGGED IN " + parentForm.storeName;

            totalOrderAmount = 0;
            totalReceivingAmount = 0;
            dataGridView1.DataSource = null;

            if (parentForm.userLevel >= parentForm.btnPOReceivingSearchPOList)
            {
                cmd = new SqlCommand("Show_ReturnReportList_All", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                parentForm.conn.Open();
                dt2_All.Clear();
                adapt.Fill(dt2_All);
                parentForm.conn.Close();

                dataGridView1.RowTemplate.Height = 40;
                dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont2;
                dataGridView1.DataSource = dt2_All;
                dataGridView1.Columns[0].HeaderText = "RR ID";
                dataGridView1.Columns[0].Width = 40;
                dataGridView1.Columns[1].HeaderText = "SC";
                dataGridView1.Columns[1].Width = 30;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].HeaderText = "Vendor";
                dataGridView1.Columns[4].Width =70;
                dataGridView1.Columns[5].HeaderText = "FName";
                dataGridView1.Columns[5].Width = 40;
                dataGridView1.Columns[6].HeaderText = "LName";
                dataGridView1.Columns[6].Width = 40;
                dataGridView1.Columns[7].HeaderText = "Employee ID";
                dataGridView1.Columns[7].Width = 50;
                dataGridView1.Columns[8].HeaderText = "Gp1";
                dataGridView1.Columns[8].Width = 30;
                dataGridView1.Columns[9].HeaderText = "Salesman Name";
                dataGridView1.Columns[9].Width = 55;
                dataGridView1.Columns[10].HeaderText = "Salesman Phone";
                dataGridView1.Columns[10].Width = 45;
                dataGridView1.Columns[11].HeaderText = "Create Date";
                dataGridView1.Columns[11].Width = 45;
                dataGridView1.Columns[12].HeaderText = "Packing Date";
                dataGridView1.Columns[12].Width = 45;
                dataGridView1.Columns[13].HeaderText = "Shipping Date";
                dataGridView1.Columns[13].Width = 45;
                dataGridView1.Columns[14].HeaderText = "Submit Date";
                dataGridView1.Columns[14].Width = 45;
                dataGridView1.Columns[15].HeaderText = "Returned Date";
                dataGridView1.Columns[15].Width = 45;
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
                dataGridView1.Columns[21].Width = 40;
                dataGridView1.Columns[22].Visible = false;

            }
            else
            {
                cmd = new SqlCommand("Show_ReturnReportList", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = parentForm.employeeID.ToUpper();
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                parentForm.conn.Open();
                dt2_All.Clear();
                adapt.Fill(dt2_All);
                parentForm.conn.Close();

                dataGridView1.RowTemplate.Height = 40;
                dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont2;
                dataGridView1.DataSource = dt2_All;
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
                dataGridView1.Columns[21].Width = 40;
                dataGridView1.Columns[22].Visible = false;
            }

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (Convert.ToString(dataGridView1.Rows[i].Cells[21].Value).ToUpper() == "RETURNED")
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Silver;

                totalOrderAmount = totalOrderAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[17].Value);
                totalReceivingAmount = totalReceivingAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[18].Value);
            }

            //lblNumOfPO.Text = string.Format("{0:n0}", dataGridView1.RowCount);
            //lblTotalOrderAmount.Text = string.Format("{0:c}", totalOrderAmount);
            //lblTotalReceivingAmount.Text = string.Format("{0:c}", totalReceivingAmount);

            label4.Text = "NUMBER OF RETURN REPORT";
            label6.Text = "TOTAL RETURN AMOUNT";

            lblNumOfPO.Text = Convert.ToString(dataGridView1.RowCount);
            lblTotalOrderAmount.Text = string.Format("{0:c}", totalOrderAmount);
            lblTotalReceivingAmount.Text = string.Format("{0:c}", totalReceivingAmount);

            boolNumPO = false;
            boolNumRR = true;

            dataGridView1.ClearSelection();
        }

        public void SearchAllReturnReportList()
        {
            this.Text = "RETURN REPORT LIST OF ALL STORES - " + parentForm.employeeID + " LOGGED IN " + parentForm.storeName;

            totalOrderAmount = 0;
            totalReceivingAmount = 0;
            dt3.Clear();
            dataGridView1.DataSource = null;

            //progressBar1.Minimum = 0;
            //progressBar1.Maximum = 11;
            //progressBar1.Step = 1;
            //progressBar1.Visible = true;

            try
            {
                cmd = new SqlCommand("Show_ReturnReportList_All_From_HQ", connTH);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                cmd.Parameters.Add("@WHVendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                connTH.Open();
                adapt.Fill(dt3);
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
                cmd = new SqlCommand("Show_ReturnReportList_All_From_HQ", connOH);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                cmd.Parameters.Add("@WHVendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                connOH.Open();
                adapt.Fill(dt3);
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
                cmd = new SqlCommand("Show_ReturnReportList_All_From_HQ", connUM);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                cmd.Parameters.Add("@WHVendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                connUM.Open();
                adapt.Fill(dt3);
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
                cmd = new SqlCommand("Show_ReturnReportList_All_From_HQ", connCH);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                cmd.Parameters.Add("@WHVendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                connCH.Open();
                adapt.Fill(dt3);
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
                cmd = new SqlCommand("Show_ReturnReportList_All_From_HQ", connWM);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                cmd.Parameters.Add("@WHVendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                connWM.Open();
                adapt.Fill(dt3);
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
                cmd = new SqlCommand("Show_ReturnReportList_All_From_HQ", connCV);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                cmd.Parameters.Add("@WHVendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                connCV.Open();
                adapt.Fill(dt3);
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
                cmd = new SqlCommand("Show_ReturnReportList_All_From_HQ", connWB);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                cmd.Parameters.Add("@WHVendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                connWB.Open();
                adapt.Fill(dt3);
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
                cmd = new SqlCommand("Show_ReturnReportList_All_From_HQ", connWD);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                cmd.Parameters.Add("@WHVendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                connWD.Open();
                adapt.Fill(dt3);
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
                cmd = new SqlCommand("Show_ReturnReportList_All_From_HQ", connPW);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                cmd.Parameters.Add("@WHVendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                connPW.Open();
                adapt.Fill(dt3);
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
                cmd = new SqlCommand("Show_ReturnReportList_All_From_HQ", connGB);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                cmd.Parameters.Add("@WHVendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                connGB.Open();
                adapt.Fill(dt3);
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
                cmd = new SqlCommand("Show_ReturnReportList_All_From_HQ", connBW);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                cmd.Parameters.Add("@DateOption", SqlDbType.TinyInt).Value = dateOption;
                cmd.Parameters.Add("@WHVendorName", SqlDbType.NVarChar).Value = parentForm.WarehouseName1;
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                connBW.Open();
                adapt.Fill(dt3);
                connBW.Close();

                progressBar1.PerformStep();
            }
            catch
            {
                MessageBox.Show("CAN NOT CONNECT BOWIE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connBW.Close();
            }

            //progressBar1.Visible = false;
            progressBar1.Value = 0;

            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont2;
            dataGridView1.DataSource = dt3;
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
            dataGridView1.Columns[21].Width = 40;
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

            lblNumOfPO.Text = Convert.ToString(dataGridView1.RowCount);
            lblTotalOrderAmount.Text = string.Format("{0:c}", totalOrderAmount);
            lblTotalReceivingAmount.Text = string.Format("{0:c}", totalReceivingAmount);

            dataGridView1.ClearSelection();
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
            if (e.RowIndex != -1)
            {
                if (parentForm.StoreCode.ToUpper() == "B4UHQ")
                {
                    btnLoadReturnReportHQ_Click(null, null);
                }
                else
                {
                    if (boolNumPO == true)
                    {
                        btnLoadPO_Click(null, null);
                    }
                    else if (boolNumRR == true)
                    {
                        btnLoadReturnReport_Click(null, null);
                    }
                }
            }
        }

        private void btnCreateWarehousePO_Click(object sender, EventArgs e)
        {
            if (CheckOpened("ItemSoldListForReturn") == true)
            {
                MessageBox.Show("PLEASE CLOSE EXISING RETURN REPORT WINDOWS(S)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                CreateNewPO createNewPOForm = new CreateNewPO(2);
                createNewPOForm.parentForm1 = this.parentForm;
                createNewPOForm.parentForm2 = this;
                createNewPOForm.ShowDialog();
            }
        }

        private void btnInvoiceSummary_Click(object sender, EventArgs e)
        {
            InvoiceSummaryMain invoiceSummaryMainFrom = new InvoiceSummaryMain();
            invoiceSummaryMainFrom.parentForm = this.parentForm;
            invoiceSummaryMainFrom.Show();
        }

        private void btnCreateReturnReport_Click(object sender, EventArgs e)
        {
            if (CheckOpened("ItemSoldList") == true | CheckOpened("POMain") == true)
            {
                MessageBox.Show("PLEASE CLOSE EXISING P/O WINDOWS(S)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                CreateReturnReport createReturnReportForm = new CreateReturnReport();
                createReturnReportForm.parentForm1 = this.parentForm;
                createReturnReportForm.parentform2 = this;
                createReturnReportForm.Show();
            }
        }

        private void btnSearchReturnList_Click(object sender, EventArgs e)
        {
            if (CheckOpened("ItemSoldList") == true | CheckOpened("POMain") == true)
            {
                MessageBox.Show("PLEASE CLOSE EXISING P/O WINDOWS(S)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                SearchReturntListOption searchReturnReportListOptionForm = new SearchReturntListOption(0);
                searchReturnReportListOptionForm.parentForm1 = this.parentForm;
                searchReturnReportListOptionForm.parentForm2 = this;
                searchReturnReportListOptionForm.ShowDialog();
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //ItemSoldListForReturn itemSoldListForReturnForm = new ItemSoldListForReturn();
            //itemSoldListForReturnForm.parentForm = this.parentForm;
            //itemSoldListForReturnForm.Show();
        }

        private void btnLoadReturnReport_Click(object sender, EventArgs e)
        {
            if (boolNumRR == true)
            {
                if (dataGridView1.RowCount == 0)
                    return;

                rrID = Convert.ToInt64(dataGridView1.SelectedCells[0].Value);
                rrEmployeeID = Convert.ToString(dataGridView1.SelectedCells[7].Value);
                rrEmployeeName = Convert.ToString(dataGridView1.SelectedCells[5].Value) + " " + Convert.ToString(dataGridView1.SelectedCells[6].Value);
                rrStatus = Convert.ToString(dataGridView1.SelectedCells[21].Value);
                rrVendor = Convert.ToString(dataGridView1.SelectedCells[4].Value);
                rrCreateDate = string.Format("{0:MM/dd/yyyy}", dataGridView1.SelectedCells[11].Value);
                rrPackingDate = Convert.ToString(dataGridView1.SelectedCells[12].Value);
                rrShippingDate = Convert.ToString(dataGridView1.SelectedCells[13].Value);
                rrTrackingNumber = Convert.ToString(dataGridView1.SelectedCells[16].Value);
                rrTotalReturnAmount = Convert.ToDouble(dataGridView1.SelectedCells[17].Value);

                if (parentForm.employeeID.ToUpper() == "ADMIN")
                {
                    ItemSoldListForReturn itemSoldListForReturnForm = new ItemSoldListForReturn(rrID, rrEmployeeID, rrEmployeeName, rrVendor, rrStatus, rrCreateDate, rrPackingDate, rrShippingDate, rrTrackingNumber, 1);
                    itemSoldListForReturnForm.parentForm = this.parentForm;
                    itemSoldListForReturnForm.parentForm2 = this;
                    itemSoldListForReturnForm.Show();
                }
                else
                {
                    if (parentForm.userLevel >= parentForm.GeneralManagerLV)
                    {
                        ItemSoldListForReturn itemSoldListForReturnForm = new ItemSoldListForReturn(rrID, rrEmployeeID, rrEmployeeName, rrVendor, rrStatus, rrCreateDate, rrPackingDate, rrShippingDate, rrTrackingNumber, 1);
                        itemSoldListForReturnForm.parentForm = this.parentForm;
                        itemSoldListForReturnForm.parentForm2 = this;
                        itemSoldListForReturnForm.Show();
                    }
                    else
                    {
                        if (rrEmployeeID.ToUpper() == parentForm.employeeID.ToUpper())
                        {
                            ItemSoldListForReturn itemSoldListForReturnForm = new ItemSoldListForReturn(rrID, rrEmployeeID, rrEmployeeName, rrVendor, rrStatus, rrCreateDate, rrPackingDate, rrShippingDate, rrTrackingNumber, 1);
                            itemSoldListForReturnForm.parentForm = this.parentForm;
                            itemSoldListForReturnForm.parentForm2 = this;
                            itemSoldListForReturnForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("THIS RETURN REPORT IS NOT YOURS.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
        }

        private void btnSearchAllReturnList_Click(object sender, EventArgs e)
        {
            SearchReturntListOption searchReturnReportListOptionForm = new SearchReturntListOption(1);
            searchReturnReportListOptionForm.parentForm1 = this.parentForm;
            searchReturnReportListOptionForm.parentForm2 = this;
            searchReturnReportListOptionForm.ShowDialog();
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

        private void btnLoadReturnReportHQ_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
                return;

            ReturnReportDetail returnReportDetailForm = new ReturnReportDetail();
            returnReportDetailForm.parentForm1 = this.parentForm;
            returnReportDetailForm.parentForm2 = this;
            returnReportDetailForm.Show();
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (boolNumPO == true)
            {
                totalOrderAmount = 0;
                totalReceivingAmount = 0;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (Convert.ToString(dataGridView1.Rows[i].Cells[10].Value).ToUpper() == "RECEIVED")
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Silver;

                    totalOrderAmount = totalOrderAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value);
                    totalReceivingAmount = totalReceivingAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);
                }

                lblNumOfPO.Text = Convert.ToString(dataGridView1.RowCount);
                lblTotalOrderAmount.Text = string.Format("{0:c}", totalOrderAmount);
                lblTotalReceivingAmount.Text = string.Format("{0:c}", totalReceivingAmount);

                dataGridView1.ClearSelection();
            }
            else if (boolNumRR == true)
            {
                totalOrderAmount = 0;
                totalReceivingAmount = 0;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (Convert.ToString(dataGridView1.Rows[i].Cells[21].Value).ToUpper() == "RETURNED")
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Silver;

                    totalOrderAmount = totalOrderAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[17].Value);
                    totalReceivingAmount = totalReceivingAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[18].Value);
                }

                lblNumOfPO.Text = Convert.ToString(dataGridView1.RowCount);
                lblTotalOrderAmount.Text = string.Format("{0:c}", totalOrderAmount);
                lblTotalReceivingAmount.Text = string.Format("{0:c}", totalReceivingAmount);

                dataGridView1.ClearSelection();
            }
            else
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

                dataGridView1.ClearSelection();
            }
        }

        private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (boolNumPO == true)
            {
                totalOrderAmount = 0;
                totalReceivingAmount = 0;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (Convert.ToString(dataGridView1.Rows[i].Cells[10].Value).ToUpper() == "RECEIVED")
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Silver;

                    totalOrderAmount = totalOrderAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value);
                    totalReceivingAmount = totalReceivingAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);
                }

                lblNumOfPO.Text = Convert.ToString(dataGridView1.RowCount);
                lblTotalOrderAmount.Text = string.Format("{0:c}", totalOrderAmount);
                lblTotalReceivingAmount.Text = string.Format("{0:c}", totalReceivingAmount);

                dataGridView1.ClearSelection();
            }
            else if (boolNumRR == true)
            {
                totalOrderAmount = 0;
                totalReceivingAmount = 0;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (Convert.ToString(dataGridView1.Rows[i].Cells[21].Value).ToUpper() == "RETURNED")
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Silver;

                    totalOrderAmount = totalOrderAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[17].Value);
                    totalReceivingAmount = totalReceivingAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[18].Value);
                }

                lblNumOfPO.Text = Convert.ToString(dataGridView1.RowCount);
                lblTotalOrderAmount.Text = string.Format("{0:c}", totalOrderAmount);
                lblTotalReceivingAmount.Text = string.Format("{0:c}", totalReceivingAmount);

                dataGridView1.ClearSelection();
            }
            else
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

                dataGridView1.ClearSelection();
            }
        }
    }
}