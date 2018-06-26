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
    public partial class RedeemHistory : Form
    {
        public LogInManagements parentForm;
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        public string startDate, endDate;

        NumberFormatInfo nfi = new NumberFormatInfo();
        
        public RedeemHistory()
        {
            InitializeComponent();
        }

        private void RedeemHistory_Load(object sender, EventArgs e)
        {
            if (parentForm.userLevel >= parentForm.StoreManagerLV)
                btnExcel.Enabled = true;

            if (parentForm.employeeID.ToUpper() == parentForm.SystemMasterUserName.ToUpper())
            //if (parentForm.userLevel >= parentForm.SystemAdministratorLV)
                cmdManageGiftcard.Enabled = true;

            this.Text = "REDEEM HISTORY (STORE LOCATION : " + parentForm.storeName.ToUpper() + ")";
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadOption loadOptionForm = new LoadOption(1);
            loadOptionForm.parentForm2 = this;
            loadOptionForm.ShowDialog();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            MessageBox.Show("NOT AVAILABLE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExcel_Click(object sender, EventArgs e)
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

        public void Load_RedeemHistory()
        {
            nfi.CurrencySymbol = Application.CurrentCulture.NumberFormat.CurrencySymbol;
            nfi.CurrencyNegativePattern = 1;

            dt.Clear();
            dataGridView1.DataSource = null;

            cmd.CommandText = "Show_RedeemHistory";
            cmd.Connection = parentForm.conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;

            if (rdoBtnAll.Checked == true)
            {
                cmd.Parameters.Add("@BoolNum", SqlDbType.Int).Value = 0;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                parentForm.conn.Open();
                adapter.Fill(dt);
                parentForm.conn.Close();
            }
            else if (rdoBtnCustomerPoints.Checked == true)
            {
                cmd.Parameters.Add("@BoolNum", SqlDbType.Int).Value = 1;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                parentForm.conn.Open();
                adapter.Fill(dt);
                parentForm.conn.Close();
            }
            else if (rdoBtnStoreCredit.Checked == true)
            {
                cmd.Parameters.Add("@BoolNum", SqlDbType.Int).Value = 2;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                parentForm.conn.Open();
                adapter.Fill(dt);
                parentForm.conn.Close();
            }
            else if (rdoBtnGiftCard.Checked == true)
            {
                cmd.Parameters.Add("@BoolNum", SqlDbType.Int).Value = 3;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                parentForm.conn.Open();
                adapter.Fill(dt);
                parentForm.conn.Close();
            }
            else if (rdoBtnCoupon.Checked == true)
            {
                cmd.Parameters.Add("@BoolNum", SqlDbType.Int).Value = 4;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                parentForm.conn.Open();
                adapter.Fill(dt);
                parentForm.conn.Close();
            }

            dataGridView1.RowTemplate.Height = 35;
            //dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont2;
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "STORE CODE";
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].Width = 55;
            dataGridView1.Columns[2].HeaderText = "RECEIPT ID";
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].Width = 70;
            dataGridView1.Columns[3].HeaderText = "CASHIER ID";
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].Width = 70;
            dataGridView1.Columns[4].HeaderText = "REG#";
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].Width = 50;
            dataGridView1.Columns[5].HeaderText = "MEMBER ID";
            dataGridView1.Columns[5].Width = 75;
            dataGridView1.Columns[6].HeaderText = "MEMBER NAME";
            dataGridView1.Columns[6].Width = 145;
            dataGridView1.Columns[7].HeaderText = "REDEEM CODE";
            dataGridView1.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[7].Width = 75;
            dataGridView1.Columns[8].HeaderText = "REDEEM TYPE";
            dataGridView1.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[8].Width = 115;
            dataGridView1.Columns[9].HeaderText = "AMT";
            dataGridView1.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[9].Width = 55;
            dataGridView1.Columns[9].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[9].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[10].HeaderText = "DATE";
            dataGridView1.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[10].Width = 77;
            dataGridView1.Columns[11].HeaderText = "TIME";
            dataGridView1.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[11].Width = 77;
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

        private void cmdManageGiftcard_Click(object sender, EventArgs e)
        {
            ManageGiftcard manageGiftcardForm = new ManageGiftcard();
            manageGiftcardForm.parentForm = this.parentForm;
            manageGiftcardForm.Show();
        }
    }
}