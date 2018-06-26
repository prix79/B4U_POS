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
    public partial class ViewCreditMemo : Form
    {
        public LogInManagements parentForm1;
        public POandReceiving parentForm2;
        public ReturnReportDetail parentForm3;

        SqlConnection conn;
        SqlCommand cmd;
        SqlCommand cmd2;
        SqlDataAdapter adapt;
        DataTable dt = new DataTable();

        public Int64 cmRRID;
        public string cmRRStoreCode;

        public double creditMemoAmount = 0;

        public ViewCreditMemo(Int64 RID, string SC)
        {
            InitializeComponent();
            cmRRID = RID;
            cmRRStoreCode = SC;
        }

        private void ViewCreditMemo_Load(object sender, EventArgs e)
        {
            this.Text = "VIEW CREDIT MEMO - " + parentForm1.employeeID + " LOGGED IN " + parentForm1.storeName;

            if (parentForm3.lblStatus.Text == "RETURNED")
            {
                btnInput.Enabled = false;
                btnDelete.Enabled = false;
            }

            Bind_DataGridview();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            InputCreditMemo inputCreditMemoForm = new InputCreditMemo(cmRRID, cmRRStoreCode);
            inputCreditMemoForm.parentForm1 = this.parentForm1;
            inputCreditMemoForm.parentForm2 = this.parentForm3;
            inputCreditMemoForm.parentForm3 = this;
            inputCreditMemoForm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
            {
                if (dataGridView1.RowCount == 1)
                {
                    conn = new SqlConnection(parentForm1.OtherStoreConnectionString(cmRRStoreCode));
                    cmd = new SqlCommand("Delete_CreditMemo", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@seqNum", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.SelectedCells[0].Value);

                    cmd2 = new SqlCommand("Update_ReturnReportHeader", conn);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 3;
                    cmd2.Parameters.Add("@rrID", SqlDbType.BigInt).Value = cmRRID;
                    cmd2.Parameters.Add("@rrShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                    cmd2.Parameters.Add("@rrSubmitDate", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd2.Parameters.Add("@rrReturnedDate", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd2.Parameters.Add("@rrTrackingNumber", SqlDbType.NVarChar).Value = "N/A";
                    cmd2.Parameters.Add("@rrReturnTotalAmount", SqlDbType.Money).Value = 0;
                    cmd2.Parameters.Add("@rrReceivingTotalAmount", SqlDbType.Money).Value = -Convert.ToInt16(dataGridView1.SelectedCells[4].Value);
                    cmd2.Parameters.Add("@rrConfirmationID", SqlDbType.NVarChar).Value = "N/A";
                    cmd2.Parameters.Add("@rrStatus", SqlDbType.NVarChar).Value = "PROCESSING";
                    cmd2.Parameters.Add("@rrFirstContact", SqlDbType.NVarChar).Value = "N/A";

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    conn.Close();

                    Bind_DataGridview();
                    parentForm3.Show_CreditMemo_Count(cmRRID, cmRRStoreCode);
                    parentForm3.rrTotalReceivingAmount = creditMemoAmount;
                    parentForm3.lblTotalReceivingAmount.Text = string.Format("{0:c}", parentForm3.rrTotalReceivingAmount);
                    parentForm3.lblStatus.Text = "PROCESSING";

                    if (parentForm2.IsDisposed == false)
                    {
                        if (parentForm2.dataGridView1.RowCount == 0)
                            return;

                        parentForm2.SearchAllReturnReportList();
                    }

                    MessageBox.Show("SUCCESSFULLY DELETED !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    conn = new SqlConnection(parentForm1.OtherStoreConnectionString(cmRRStoreCode));
                    cmd = new SqlCommand("Delete_CreditMemo", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@seqNum", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.SelectedCells[0].Value);

                    cmd2 = new SqlCommand("Update_ReturnReportHeader", conn);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 3;
                    cmd2.Parameters.Add("@rrID", SqlDbType.BigInt).Value = cmRRID;
                    cmd2.Parameters.Add("@rrShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                    cmd2.Parameters.Add("@rrSubmitDate", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd2.Parameters.Add("@rrReturnedDate", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd2.Parameters.Add("@rrTrackingNumber", SqlDbType.NVarChar).Value = "N/A";
                    cmd2.Parameters.Add("@rrReturnTotalAmount", SqlDbType.Money).Value = 0;
                    cmd2.Parameters.Add("@rrReceivingTotalAmount", SqlDbType.Money).Value = -Convert.ToInt16(dataGridView1.SelectedCells[4].Value);
                    cmd2.Parameters.Add("@rrConfirmationID", SqlDbType.NVarChar).Value = "N/A";
                    cmd2.Parameters.Add("@rrStatus", SqlDbType.NVarChar).Value = "RECEIVING";
                    cmd2.Parameters.Add("@rrFirstContact", SqlDbType.NVarChar).Value = "N/A";

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    conn.Close();

                    Bind_DataGridview();
                    parentForm3.Show_CreditMemo_Count(cmRRID, cmRRStoreCode);
                    parentForm3.rrTotalReceivingAmount = creditMemoAmount;
                    parentForm3.lblTotalReceivingAmount.Text = string.Format("{0:c}", parentForm3.rrTotalReceivingAmount);
                    parentForm3.lblStatus.Text = "RECEIVING";

                    if (parentForm2.IsDisposed == false)
                    {
                        if (parentForm2.dataGridView1.RowCount == 0)
                            return;

                        parentForm2.SearchAllReturnReportList();
                    }

                    MessageBox.Show("SUCCESSFULLY DELETED !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Bind_DataGridview()
        {
            creditMemoAmount = 0;
            dt.Clear();
            dataGridView1.DataSource = null;

            conn = new SqlConnection(parentForm1.OtherStoreConnectionString(cmRRStoreCode));
            cmd = new SqlCommand("Load_CreditMemo", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@rrID", SqlDbType.BigInt).Value = cmRRID;
            adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;

            conn.Open();
            adapt.Fill(dt);
            conn.Close();

            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Store Code";
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[2].HeaderText = "Return #";
            dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].Width = 50;
            dataGridView1.Columns[3].HeaderText = "CM Number";
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].Width = 90;
            dataGridView1.Columns[4].HeaderText = "CM Amount";
            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].Width = 70;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].DefaultCellStyle.BackColor = Color.NavajoWhite;
            dataGridView1.Columns[4].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[5].HeaderText = "EmployeeID";
            dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].HeaderText = "Receive Date";
            dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].Width = 100;
            dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[7].HeaderText = "Note";
            dataGridView1.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[7].Width = 100;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                creditMemoAmount = creditMemoAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
            }

            lblCreditMemoCount.Text = dataGridView1.RowCount.ToString();
            lblCreditMemoAmount.Text = string.Format("{0:c}", creditMemoAmount);

            dataGridView1.ClearSelection();
        }
    }
}