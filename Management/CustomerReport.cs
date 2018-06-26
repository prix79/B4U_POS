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
    public partial class CustomerReport : Form
    {
        public LogInManagements parentForm;
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter adapt;

        DateTime d1, d2;
        string startDate, endDate;

        double periodAmount= 0;
        int percentOpt = 0;

        public Font drvFont = new Font("Arial", 10, FontStyle.Bold);

        public CustomerReport()
        {
            InitializeComponent();
        }

        private void CustomerReport_Load(object sender, EventArgs e)
        {
            txtBCStartDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            txtBCEndDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

            try
            {
                cmd = new SqlCommand("Get_MemberType", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                DataSet ds = new DataSet();
                adapt = new SqlDataAdapter(cmd);

                parentForm.conn.Open();
                adapt.Fill(ds);
                parentForm.conn.Close();

                cmbMemberType.DataSource = ds.Tables[0].DefaultView;
                cmbMemberType.ValueMember = "MemberType";
                cmbMemberType.DisplayMember = "MemberType";

                cmbMemberType.SelectedIndex = 0;

                if (parentForm.userLevel >= parentForm.StoreManagerLV)
                    btnExcel.Enabled = true;
            }
            catch
            {
                MessageBox.Show("UPDATE FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                parentForm.conn.Close();
                return;
            }
        }

        private void txtBCStartDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void txtBCEndDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar2.Visible = true;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtBCStartDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar1.SelectionStart));
            monthCalendar1.Visible = false;
        }

        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtBCEndDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar2.SelectionStart));
            monthCalendar2.Visible = false;
        }

        private void btnBCOk_Click(object sender, EventArgs e)
        {
            btnBCOk.Enabled = false;
            btnBCClose.Enabled = false;

            if (rdoBtn5P.Checked == true)
            {
                percentOpt = 5;
            }
            else if (rdoBtn10P.Checked == true)
            {
                percentOpt = 10;
            }
            else if (rdoBtn20P.Checked == true)
            {
                percentOpt = 20;
            }
            else if (rdoBtnAll.Checked == true)
            {
                percentOpt = 100;
            }

            if (DateTime.TryParse(txtBCStartDate.Text, out d1))
            {
                startDate = string.Format("{0:MM/dd/yyyy}", d1);
            }
            else
            {
                MessageBox.Show("INVALID DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBCStartDate.SelectAll();
                txtBCStartDate.Focus();
                return;
            }

            if (DateTime.TryParse(txtBCEndDate.Text, out d2))
            {
                endDate = string.Format("{0:MM/dd/yyyy}", d2);
            }
            else
            {
                MessageBox.Show("INVALID DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBCEndDate.SelectAll();
                txtBCEndDate.Focus();
                return;
            }

            try
            {
                cmd = new SqlCommand("Show_BestCustomer", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@PercentOption", SqlDbType.Int).Value = percentOpt;
                cmd.Parameters.Add("@MemberType", SqlDbType.NVarChar).Value = cmbMemberType.Text.Trim().ToUpper().ToString();
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                adapt = new SqlDataAdapter(cmd);
                dt = new DataTable();

                parentForm.conn.Open();
                adapt.Fill(dt);
                parentForm.conn.Close();

                dataGridView1.RowTemplate.Height = 35;
                dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                dataGridView1.DataSource = dt;

                dataGridView1.Columns[0].HeaderText = "STORE CODE";
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].HeaderText = "FIRST NAME";
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].HeaderText = "LAST NAME";
                dataGridView1.Columns[2].Width = 150;
                dataGridView1.Columns[3].HeaderText = "DATE OF BIRTH";
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].HeaderText = "ADDRESS";
                dataGridView1.Columns[4].Width = 200;
                dataGridView1.Columns[5].HeaderText = "CITY";
                dataGridView1.Columns[5].Width = 150;
                dataGridView1.Columns[6].HeaderText = "STATE";
                dataGridView1.Columns[6].Width = 50;
                dataGridView1.Columns[7].HeaderText = "ZIP CODE";
                dataGridView1.Columns[7].Width = 50;
                dataGridView1.Columns[8].HeaderText = "HOME PHONE";
                dataGridView1.Columns[8].Width = 100;
                dataGridView1.Columns[9].HeaderText = "CELL PHONE";
                dataGridView1.Columns[9].Width = 100;
                dataGridView1.Columns[10].HeaderText = "EMAIL";
                dataGridView1.Columns[10].Width = 150;
                dataGridView1.Columns[11].HeaderText = "MEMBER CODE";
                dataGridView1.Columns[11].Width = 100;
                dataGridView1.Columns[12].HeaderText = "MEMBER TYPE";
                dataGridView1.Columns[12].Width = 130;
                dataGridView1.Columns[13].HeaderText = "MEMBER POINTS";
                dataGridView1.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[13].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[13].Width = 70;
                dataGridView1.Columns[14].HeaderText = "LAST VISIT DATE";
                dataGridView1.Columns[14].Width = 90;
                dataGridView1.Columns[15].HeaderText = "TRNS(P)";
                dataGridView1.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[15].Width = 60;
                dataGridView1.Columns[16].HeaderText = "TRNS(R)";
                dataGridView1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[16].Width = 60;
                dataGridView1.Columns[17].HeaderText = "TRNS(T)";
                dataGridView1.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[17].Width = 60;
                dataGridView1.Columns[18].HeaderText = "TOTAL TRANSACTION AMOUNT";
                dataGridView1.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[18].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[18].Width = 100;
                dataGridView1.Columns[19].HeaderText = "PERIOD TRANSACTION AMOUNT";
                dataGridView1.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[19].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[19].Width = 100;

                dataGridView1.Columns[11].DefaultCellStyle.BackColor = Color.LightYellow;
                dataGridView1.Columns[19].DefaultCellStyle.BackColor = Color.Orange;

                periodAmount = 0;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    periodAmount = periodAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[19].Value);
                }

                lblTotalPeriodTransactionAmount.Text = string.Format("{0:$0.00}", periodAmount);
                lblTotalNumberOfCustomer.Text = Convert.ToString(dataGridView1.RowCount);

                btnBCOk.Enabled = true;
                btnBCClose.Enabled = true;
            }
            catch
            {
                MessageBox.Show("UPDATE FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                parentForm.conn.Close();
                btnBCOk.Enabled = true;
                btnBCClose.Enabled = true;
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

        private void btnBCClose_Click(object sender, EventArgs e)
        {
            this.Close();
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