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

namespace Management
{
    public partial class InvoiceSummaryMain : Form
    {
        public LogInManagements parentForm;
        public SqlCommand cmd;
        public DataTable dt;
        public SqlDataAdapter adapt;

        public int tempF_Opt = 0;
        public string startDate, endDate;
        public string empID;
        public int category1 = 0;
        double totalPurchase = 0;
        double totalCredit = 0;

        Int64 checkNum = 0;

        public Font drvFont = new Font("Arial", 10);

        public InvoiceSummaryMain()
        {
            InitializeComponent();
        }

        private void InvoiceSummaryMain_Load(object sender, EventArgs e)
        {
            this.Text = "INVOICE SUMMARY MAIN - " + parentForm.employeeID + " LOGGED IN " + parentForm.storeName;
            lblStoreName.Text = parentForm.storeName.ToUpper().ToString();
            lblStoreCode.Text = parentForm.StoreCode.ToUpper().ToString();
            lblEmployeeID.Text = parentForm.employeeID.ToUpper().ToString();

            lblNumOfInv.Text = "0";
            lblTotalPurchaseAmount.Text = "0";
            lblTotalCreditAmount.Text = "0";
        }

        private void btnInputInvoice_Click(object sender, EventArgs e)
        {
            InputInvoice inputInvoiceForm = new InputInvoice();
            inputInvoiceForm.parentForm = this.parentForm;
            inputInvoiceForm.parentForm2 = this;
            inputInvoiceForm.Show();
        }

        private void btnShowInvoiceList_Click(object sender, EventArgs e)
        {
            LoadOption loadOptionForm = new LoadOption(2);
            loadOptionForm.parentForm3 = this;
            loadOptionForm.ShowDialog();
        }

        private void btnDeleteInvoice_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                checkNum = 0;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Selected == true)
                    {
                        checkNum = checkNum + 1;
                    }
                }

                if (checkNum == 0)
                {
                    return;
                }
                else if (checkNum == 1)
                {
                    DialogResult MyDialogResult;
                    MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (MyDialogResult == DialogResult.Yes)
                    {
                        cmd = new SqlCommand("Delete_InvoiceList", parentForm.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@IvSmSeqNo", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.SelectedCells[0].Value);

                        parentForm.conn.Open();
                        cmd.ExecuteNonQuery();
                        parentForm.conn.Close();

                        MessageBox.Show("SUCCESSFULLY DELETED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Load_InvoiceList(tempF_Opt);
                        dataGridView1.ClearSelection();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void btnUpdateInvoice_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                checkNum = 0;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Selected == true)
                    {
                        checkNum = checkNum + 1;
                    }
                }

                if (checkNum == 0)
                {
                    return;
                }
                else if (checkNum == 1)
                {
                    if (Convert.ToString(dataGridView1.SelectedCells[8].Value) == parentForm.employeeID | parentForm.userLevel >= parentForm.SystemAdministratorLV)
                    {
                        UpdateInvoice updateInvoiceForm = new UpdateInvoice();
                        updateInvoiceForm.parentForm1 = this.parentForm;
                        updateInvoiceForm.parentForm2 = this;
                        updateInvoiceForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("NOT AUTHORIZED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Load_InvoiceList(int FilterOption)
        {
            dataGridView1.DataSource = DBNull.Value;
            tempF_Opt = FilterOption;

            if (FilterOption == 0)
            {
                if (parentForm.userLevel >= parentForm.StoreManagerLV)
                {
                    cmd = new SqlCommand("Load_InvoiceList_All", parentForm.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                    adapt = new SqlDataAdapter(cmd);
                    dt = new DataTable();

                    parentForm.conn.Open();
                    adapt.Fill(dt);
                    parentForm.conn.Close();
                }
                else
                {
                    cmd = new SqlCommand("Load_InvoiceList", parentForm.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                    cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = parentForm.employeeID.ToUpper();
                    adapt = new SqlDataAdapter(cmd);
                    dt = new DataTable();

                    parentForm.conn.Open();
                    adapt.Fill(dt);
                    parentForm.conn.Close();
                }
            }
            else
            {
                if (parentForm.userLevel >= parentForm.StoreManagerLV)
                {
                    cmd = new SqlCommand("Load_InvoiceList_For_Manager_By_Filter", parentForm.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@FilterOption", SqlDbType.TinyInt).Value = FilterOption;
                    cmd.Parameters.Add("@Category1", SqlDbType.NVarChar).Value = category1;
                    cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = empID;
                    cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                    adapt = new SqlDataAdapter(cmd);
                    dt = new DataTable();

                    parentForm.conn.Open();
                    adapt.Fill(dt);
                    parentForm.conn.Close();
                }
                else
                {
                    cmd = new SqlCommand("Load_InvoiceList_By_Filter", parentForm.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@FilterOption", SqlDbType.TinyInt).Value = FilterOption;
                    cmd.Parameters.Add("@Category1", SqlDbType.NVarChar).Value = category1;
                    cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = parentForm.employeeID;
                    cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                    adapt = new SqlDataAdapter(cmd);
                    dt = new DataTable();

                    parentForm.conn.Open();
                    adapt.Fill(dt);
                    parentForm.conn.Close();
                }

            }

            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "INV TYPE";
            dataGridView1.Columns[1].Width = 55;
            dataGridView1.Columns[2].HeaderText = "STORE CODE";
            dataGridView1.Columns[2].Width = 55;
            dataGridView1.Columns[3].HeaderText = "INV #";
            dataGridView1.Columns[3].Width = 95;
            dataGridView1.Columns[4].HeaderText = "P/O ID";
            dataGridView1.Columns[4].Width = 95;
            dataGridView1.Columns[5].HeaderText = "VENDOR";
            dataGridView1.Columns[5].Width = 150;
            dataGridView1.Columns[6].HeaderText = "GP1";
            dataGridView1.Columns[6].Width = 40;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[7].HeaderText = "AMOUNT";
            dataGridView1.Columns[7].Width = 90;
            dataGridView1.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[7].DefaultCellStyle.Format = "0.00";
            dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[8].HeaderText = "EMPLOYEE ID";
            dataGridView1.Columns[8].Width = 120;
            dataGridView1.Columns[9].HeaderText = "INVOICE DATE";
            dataGridView1.Columns[9].Width = 90;
            dataGridView1.Columns[9].DefaultCellStyle.Format = "MM/dd/yyyy";
            dataGridView1.Columns[10].HeaderText = "INPUT DATE";
            dataGridView1.Columns[10].Width = 90;
            dataGridView1.Columns[10].DefaultCellStyle.Format = "MM/dd/yyyy";
            dataGridView1.Columns[11].HeaderText = "UPDATE DATE";
            dataGridView1.Columns[11].Width = 90;
            dataGridView1.Columns[11].DefaultCellStyle.Format = "MM/dd/yyyy";
            dataGridView1.Columns[12].HeaderText = "NOTE";
            dataGridView1.Columns[12].Width = 50;

            totalPurchase = 0; totalCredit = 0;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (Convert.ToString(dataGridView1.Rows[i].Cells[1].Value) == "P")
                {
                    totalPurchase = totalPurchase + Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value);
                }
                else if (Convert.ToString(dataGridView1.Rows[i].Cells[1].Value) == "C")
                {
                    totalCredit = totalCredit + Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value);
                }
            }

            lblNumOfInv.Text = dataGridView1.RowCount.ToString();
            lblTotalPurchaseAmount.Text = string.Format("{0:c}", totalPurchase);
            lblTotalCreditAmount.Text = string.Format("{0:c}", totalCredit);

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
   }
}