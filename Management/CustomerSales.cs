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
    public partial class CustomerSales : Form
    {
        public LogInManagements parentForm;
        Int64 memberID;
        double totalPurchase = 0;

        public Font drvFont = new Font("Arial", 10, FontStyle.Bold);

        SqlConnection newConn;
        SqlCommand newCmd;
        DataTable dt = new DataTable();
        string[] newConnectionString = new string[11];

        public CustomerSales(Int64 mID)
        {
            InitializeComponent();
            memberID = mID;
        }

        private void CustomerSales_Load(object sender, EventArgs e)
        {
            if (parentForm.employeeID.ToUpper() == "ADMIN")
                btnExcel.Visible = true;

            newConnectionString[0] = parentForm.THCS_IP;
            newConnectionString[1] = parentForm.OHCS_IP;
            newConnectionString[2] = parentForm.UMCS_IP;
            newConnectionString[3] = parentForm.CHCS_IP;
            newConnectionString[4] = parentForm.WMCS_IP;
            newConnectionString[5] = parentForm.CVCS_IP;
            newConnectionString[6] = parentForm.PWCS_IP;
            newConnectionString[7] = parentForm.WBCS_IP;
            newConnectionString[8] = parentForm.WDCS_IP;
            newConnectionString[9] = parentForm.GBCS_IP;
            newConnectionString[10] = parentForm.BWCS_IP;

            lblTotalAmount.Text = "$0.00";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                ReceiptDetail receiptDetailForm = new ReceiptDetail(1);
                receiptDetailForm.parentForm1 = this.parentForm;
                receiptDetailForm.parentForm3 = this;
                receiptDetailForm.ShowDialog();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            totalPurchase = 0;
            dt.Clear();

            try
            {
                SqlDataAdapter adapt = new SqlDataAdapter();
                //DataTable dt = new DataTable();

                progressBar1.Visible = true;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = 11;
                progressBar1.Step = 1;

                for (int i = 0; i < 11; i++)
                {
                    newConn = new SqlConnection(newConnectionString[i]);
                    newCmd = new SqlCommand("Show_Customer_Sales", newConn);
                    newCmd.CommandType = CommandType.StoredProcedure;
                    newCmd.Parameters.Clear();
                    newCmd.Parameters.Add("@MemberID", SqlDbType.BigInt).Value = memberID;
                    adapt.SelectCommand = newCmd;

                    newConn.Open();
                    adapt.Fill(dt);
                    newConn.Close();

                    progressBar1.Value = i + 1;
                }

                dataGridView1.RowTemplate.Height = 40;
                dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                dataGridView1.DataSource = dt;

                dataGridView1.Columns[7].HeaderText = "SellDate";
                dataGridView1.Columns[7].DefaultCellStyle.Format = "MM/dd/yyyy";
                dataGridView1.Sort(dataGridView1.Columns[7], ListSortDirection.Ascending);
                dataGridView1.Columns[7].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    totalPurchase = totalPurchase + Convert.ToDouble(dataGridView1.Rows[i].Cells[10].Value);
                }

                lblTotalAmount.Text = string.Format("{0:$0.00}", totalPurchase);
                progressBar1.Visible = false;

                dataGridView1.ClearSelection();
            }
            catch
            {
                MessageBox.Show("CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressBar1.Visible = false;
                newConn.Close();
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