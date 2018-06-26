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
    public partial class ReturnReportDetail : Form
    {
        public LogInManagements parentForm1;
        public POandReceiving parentForm2;

        NumberFormatInfo nfi = new NumberFormatInfo();

        public SqlConnection conn;
        public SqlCommand cmd;
        public SqlDataAdapter adapt;
        public DataTable dt = new DataTable();

        public Int64 rrID;
        public string rrStoreCode; 
        string rrVenderName, rrEmployeeName, rrEmployeeID, rrSalesmanName, rrSalesmanPhone, rrPackingDate, rrShippingDate;
        string rrTrackingNumber, rrConfirmationID, rrReason, rrStatus, rrFirstContact, rrSecondContact, rrThirdContact, rrFourthContact;
        int rrCategory1;
        public double rrTotalReturnAmount = 0;
        public double rrTotalReceivingAmount = 0;
        DateTime rrCreateDate, rrSubmitDate, rrReturnedDate;

        Int64 totalReturnQty = 0;

        public ReturnReportDetail()
        {
            InitializeComponent();
        }

        private void ReturnReportDetail_Load(object sender, EventArgs e)
        {
            this.Text = "RETURN REPORT IN DETAIL - " + parentForm1.employeeID + " LOGGED IN " + parentForm1.storeName;

            if (parentForm2.dataGridView1.SelectedCells[0].Value != DBNull.Value)
            {
                rrID = Convert.ToInt64(parentForm2.dataGridView1.SelectedCells[0].Value);
                lblRRID.Text = rrID.ToString();
            }

            if (parentForm2.dataGridView1.SelectedCells[1].Value != DBNull.Value)
            {
                rrStoreCode = parentForm2.dataGridView1.SelectedCells[1].Value.ToString();
                lblStoreCode.Text = rrStoreCode;
            }

            if (parentForm2.dataGridView1.SelectedCells[4].Value != DBNull.Value)
            {
                rrVenderName = parentForm2.dataGridView1.SelectedCells[4].Value.ToString();
                lblVendorName.Text = rrVenderName;
            }

            if (parentForm2.dataGridView1.SelectedCells[5].Value != DBNull.Value)
            {
                rrEmployeeName = parentForm2.dataGridView1.SelectedCells[5].Value.ToString() + " " + parentForm2.dataGridView1.SelectedCells[6].Value.ToString();
                lblEmployeeName.Text = rrEmployeeName;
            }

            if (parentForm2.dataGridView1.SelectedCells[7].Value != DBNull.Value)
            {
                rrEmployeeID = parentForm2.dataGridView1.SelectedCells[7].Value.ToString();
                lblEmployeeID.Text = rrEmployeeID;
            }

            if (parentForm2.dataGridView1.SelectedCells[8].Value != DBNull.Value)
            {
                rrCategory1 = Convert.ToInt16(parentForm2.dataGridView1.SelectedCells[8].Value);

                switch (rrCategory1)
                {
                    case 1:
                        lblCategory1.Text = rrCategory1.ToString() + " - HAIR CARE";
                        break;
                    case 2:
                        lblCategory1.Text = rrCategory1.ToString() + " - WIG";
                        break;
                    case 3:
                        lblCategory1.Text = rrCategory1.ToString() + " - HAIR";
                        break;
                    case 4:
                        lblCategory1.Text = rrCategory1.ToString() + " - STYLING & SALON SUPPLIES";
                        break;
                    case 5:
                        lblCategory1.Text = rrCategory1.ToString() + " - SKIN / COSMETIC / NAIL / FOOT";
                        break;
                    case 7:
                        lblCategory1.Text = rrCategory1.ToString() + " - GENERAL MERCHANDISE";
                        break;
                    default:
                        lblCategory1.Text = rrCategory1.ToString() + " - INVALID CATEGORY";
                        break;
                }
            }

            if (parentForm2.dataGridView1.SelectedCells[9].Value != DBNull.Value)
            {
                rrSalesmanName = parentForm2.dataGridView1.SelectedCells[9].Value.ToString();
                lblSalesmanName.Text = rrSalesmanName;
            }

            if (parentForm2.dataGridView1.SelectedCells[10].Value != DBNull.Value)
            {
                rrSalesmanPhone = parentForm2.dataGridView1.SelectedCells[10].Value.ToString();
                lblSalesmanPhone.Text = rrSalesmanPhone;
            }

            if (parentForm2.dataGridView1.SelectedCells[11].Value != DBNull.Value)
            {
                rrCreateDate = Convert.ToDateTime(parentForm2.dataGridView1.SelectedCells[11].Value);
                lblCreateDate.Text = string.Format("{0:MM/dd/yyyy HH:mm:ss}", rrCreateDate);
            }

            if (parentForm2.dataGridView1.SelectedCells[12].Value != DBNull.Value)
            {
                rrPackingDate = parentForm2.dataGridView1.SelectedCells[12].Value.ToString();
                lblPackingDate.Text = rrPackingDate;
            }

            if (parentForm2.dataGridView1.SelectedCells[13].Value != DBNull.Value)
            {
                rrShippingDate = parentForm2.dataGridView1.SelectedCells[13].Value.ToString();
                lblShippingDate.Text = rrShippingDate;
            }

            if (parentForm2.dataGridView1.SelectedCells[14].Value != DBNull.Value)
            {
                rrSubmitDate = Convert.ToDateTime(parentForm2.dataGridView1.SelectedCells[14].Value);
                lblSubmitDate.Text = string.Format("{0:MM/dd/yyyy HH:mm:ss}", rrSubmitDate);
            }

            if (parentForm2.dataGridView1.SelectedCells[15].Value != DBNull.Value)
            {
                rrReturnedDate = Convert.ToDateTime(parentForm2.dataGridView1.SelectedCells[15].Value);
                lblReturnedDate.Text = string.Format("{0:MM/dd/yyyy HH:mm:ss}", rrReturnedDate);
            }

            if (parentForm2.dataGridView1.SelectedCells[16].Value != DBNull.Value)
            {
                rrTrackingNumber = parentForm2.dataGridView1.SelectedCells[16].Value.ToString();
                txtTrackingNumber.Text = rrTrackingNumber;
            }

            if (parentForm2.dataGridView1.SelectedCells[17].Value != DBNull.Value)
            {
                rrTotalReturnAmount = Convert.ToDouble(parentForm2.dataGridView1.SelectedCells[17].Value);
                lblTotalReturnAmount.Text = string.Format("{0:c}", rrTotalReturnAmount);
            }

            if (parentForm2.dataGridView1.SelectedCells[18].Value != DBNull.Value)
            {
                rrTotalReceivingAmount = Convert.ToDouble(parentForm2.dataGridView1.SelectedCells[18].Value);
                lblTotalReceivingAmount.Text = string.Format("{0:c}", rrTotalReceivingAmount);
            }

            if (parentForm2.dataGridView1.SelectedCells[19].Value != DBNull.Value)
            {
                rrConfirmationID = parentForm2.dataGridView1.SelectedCells[19].Value.ToString();
                lblConfirmationID.Text = rrConfirmationID;
            }

            if (parentForm2.dataGridView1.SelectedCells[20].Value != DBNull.Value)
            {
                rrReason = parentForm2.dataGridView1.SelectedCells[20].Value.ToString();
                lblReason.Text = rrReason;
            }

            if (parentForm2.dataGridView1.SelectedCells[21].Value != DBNull.Value)
            {
                rrStatus = parentForm2.dataGridView1.SelectedCells[21].Value.ToString();
                lblStatus.Text = rrStatus;
            }

            if (parentForm2.dataGridView1.SelectedCells[22].Value != DBNull.Value)
            {
                rrFirstContact = parentForm2.dataGridView1.SelectedCells[22].Value.ToString();
            }

            Bind_DatagridView(rrID, rrStoreCode);
            Show_CreditMemo_Count(rrID, rrStoreCode);

            totalReturnQty = 0;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                totalReturnQty = totalReturnQty + Convert.ToInt64(dataGridView1.Rows[i].Cells[7].Value);
            }

            lblTotalItems.Text = dataGridView1.RowCount.ToString();
            lblTotalQty.Text = totalReturnQty.ToString();
        }

        private void btnViewCreditMemo_Click(object sender, EventArgs e)
        {
            if (lblStatus.Text == "SUBMITTED")
            {
                MessageBox.Show("YOU ALLOW TO ACCESS CREDIT MEMO MENU AFTER RETURN STATUS CHANGES TO PROCESSING.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                ViewCreditMemo viewCreditMemoForm = new ViewCreditMemo(rrID, rrStoreCode);
                viewCreditMemoForm.parentForm1 = this.parentForm1;
                viewCreditMemoForm.parentForm2 = this.parentForm2;
                viewCreditMemoForm.parentForm3 = this;
                viewCreditMemoForm.ShowDialog();
            }
        }

        private void btnViewContact_Click(object sender, EventArgs e)
        {

        }

        private void btnInputContact_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintReturnReport_Click(object sender, EventArgs e)
        {
            ReturnPrinting returnPrintingForm = new ReturnPrinting(1);
            returnPrintingForm.parentForm1 = this.parentForm1;
            returnPrintingForm.parentForm3 = this;
            returnPrintingForm.ShowDialog();
        }

        private void btnConfirmation_Click(object sender, EventArgs e)
        {
            if (lblStatus.Text == "RETURNED")
            {
                MessageBox.Show("THIS RETURN IS ALREADY CONFIRMED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
            {
                if (rrTotalReceivingAmount == 0)
                {
                    DialogResult MyDialogResult2;
                    MyDialogResult2 = MessageBox.Show(this, "THIS RETURN HAS 0 RECEIVING AMOUNT. ARE YOU SURE?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (MyDialogResult2 == DialogResult.Yes)
                    {
                        conn = new SqlConnection(parentForm1.OtherStoreConnectionString(rrStoreCode));
                        cmd = new SqlCommand("Update_ReturnReportHeader", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Seq", SqlDbType.Int).Value = 4;
                        cmd.Parameters.Add("@rrID", SqlDbType.BigInt).Value = rrID;
                        cmd.Parameters.Add("@rrShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                        cmd.Parameters.Add("@rrSubmitDate", SqlDbType.DateTime).Value = DateTime.Now;
                        cmd.Parameters.Add("@rrReturnedDate", SqlDbType.DateTime).Value = DateTime.Now;
                        cmd.Parameters.Add("@rrTrackingNumber", SqlDbType.NVarChar).Value = "N/A";
                        cmd.Parameters.Add("@rrReturnTotalAmount", SqlDbType.Money).Value = 0;
                        cmd.Parameters.Add("@rrReceivingTotalAmount", SqlDbType.Money).Value = 0;
                        cmd.Parameters.Add("@rrConfirmationID", SqlDbType.NVarChar).Value = parentForm1.employeeID;
                        cmd.Parameters.Add("@rrStatus", SqlDbType.NVarChar).Value = "RETURNED";
                        cmd.Parameters.Add("@rrFirstContact", SqlDbType.NVarChar).Value = "N/A";

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        lblStatus.Text = "RETURNED";
                        lblReturnedDate.Text = string.Format("{0:MM/dd/yyyy HH:mm:ss}", DateTime.Now);
                        lblConfirmationID.Text = parentForm1.employeeID;

                        if (parentForm2.IsDisposed == false)
                        {
                            if (parentForm2.dataGridView1.RowCount == 0)
                                return;

                            parentForm2.SearchAllReturnReportList();
                        }

                        MessageBox.Show("SUCCESSFULLY CONFIRMED !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    conn = new SqlConnection(parentForm1.OtherStoreConnectionString(rrStoreCode));
                    cmd = new SqlCommand("Update_ReturnReportHeader", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Seq", SqlDbType.Int).Value = 4;
                    cmd.Parameters.Add("@rrID", SqlDbType.BigInt).Value = rrID;
                    cmd.Parameters.Add("@rrShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                    cmd.Parameters.Add("@rrSubmitDate", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@rrReturnedDate", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@rrTrackingNumber", SqlDbType.NVarChar).Value = "N/A";
                    cmd.Parameters.Add("@rrReturnTotalAmount", SqlDbType.Money).Value = 0;
                    cmd.Parameters.Add("@rrReceivingTotalAmount", SqlDbType.Money).Value = 0;
                    cmd.Parameters.Add("@rrConfirmationID", SqlDbType.NVarChar).Value = parentForm1.employeeID;
                    cmd.Parameters.Add("@rrStatus", SqlDbType.NVarChar).Value = "RETURNED";
                    cmd.Parameters.Add("@rrFirstContact", SqlDbType.NVarChar).Value = "N/A";

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    lblStatus.Text = "RETURNED";
                    lblReturnedDate.Text = string.Format("{0:MM/dd/yyyy HH:mm:ss}", DateTime.Today);
                    lblConfirmationID.Text = parentForm1.employeeID;

                    if (parentForm2.IsDisposed == false)
                    {
                        if (parentForm2.dataGridView1.RowCount == 0)
                            return;

                        parentForm2.SearchAllReturnReportList();
                    }

                    MessageBox.Show("SUCCESSFULLY CONFIRMED !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReturnReportDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (parentForm2.IsDisposed == false)
            {
                if (parentForm2.dataGridView1.RowCount == 0)
                    return;

                parentForm2.SearchAllReturnReportList();
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

        private void Bind_DatagridView(Int64 RID, string SC)
        {
            try
            {
                dataGridView1.DataSource = null;
                dt.Clear();

                conn = new SqlConnection(parentForm1.OtherStoreConnectionString(SC));
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Show_ReturnReportBody";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@rrID", SqlDbType.BigInt).Value = RID;
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                conn.Open();
                adapt.Fill(dt);
                conn.Close();

                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "Brand";
                dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[1].HeaderText = "Name";
                dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[1].Width = 180;
                dataGridView1.Columns[2].HeaderText = "Size";
                dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[2].Width = 50;
                dataGridView1.Columns[3].HeaderText = "Color";
                dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[3].Width = 50;
                dataGridView1.Columns[4].HeaderText = "Model #";
                dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[4].Width = 140;
                dataGridView1.Columns[5].HeaderText = "UPC";
                dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[5].Width = 90;
                dataGridView1.Columns[6].HeaderText = "Cost Price";
                dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[6].Width = 55;
                dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[6].DefaultCellStyle.BackColor = Color.NavajoWhite;
                //dataGridView1.Columns[6].DefaultCellStyle.FormatProvider = nfi;
                dataGridView1.Columns[6].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[7].HeaderText = "Return Qty";
                dataGridView1.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[7].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                dataGridView1.Columns[7].Width = 45;
                dataGridView1.Columns[8].HeaderText = "Return Amount";
                dataGridView1.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[8].Width = 60;
                dataGridView1.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[8].DefaultCellStyle.BackColor = Color.NavajoWhite;
                //dataGridView1.Columns[8].DefaultCellStyle.FormatProvider = nfi;
                dataGridView1.Columns[8].DefaultCellStyle.Format = "c";

                dataGridView1.ClearSelection();
            }
            catch
            {
                MessageBox.Show("DB CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                return;
            }
        }

        public void Show_CreditMemo_Count(Int64 RID, string SC)
        {
            try
            {
                conn = new SqlConnection(parentForm1.OtherStoreConnectionString(SC));
                cmd = new SqlCommand("Get_CreditMemo_Count", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@rrID", SqlDbType.BigInt).Value = RID;
                SqlParameter CMCount_Param = cmd.Parameters.Add("@CMCount", SqlDbType.Int);
                CMCount_Param.Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                lblNumberOfCreditMemo.Text = cmd.Parameters["@CMCount"].Value.ToString();
            }
            catch
            {
                MessageBox.Show("DB CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                return;
            }
        }
    }
}