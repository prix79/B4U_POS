using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Management
{
    public partial class InputCreditMemo : Form
    {
        public LogInManagements parentForm1;
        public ReturnReportDetail parentForm2;
        public ViewCreditMemo parentForm3;

        Int64 RRID;
        string RRStoreCode;

        SqlConnection conn;
        SqlCommand cmd1;
        SqlCommand cmd2;

        string creditMemoNumber;
        double creditMemoAmount;
        string creditMemoNote;

        public InputCreditMemo(Int64 RID, string SC)
        {
            InitializeComponent();
            RRID = RID;
            RRStoreCode = SC;
        }

        private void InputCreditMemo_Load(object sender, EventArgs e)
        {
            this.Text = "INPUT CREDIT MEMO";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (richTxtNumber.Text.Trim() == "")
            {
                MessageBox.Show("INPUT CREDIT MEMO NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                richTxtNumber.SelectAll();
                richTxtNumber.Focus();
                return;
            }
            else
            {
                creditMemoNumber = richTxtNumber.Text.Trim();
            }


            if (double.TryParse(richTxtAmount.Text.Trim(), out creditMemoAmount))
            {
            }
            else
            {
                MessageBox.Show("INVALID VALUE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                richTxtAmount.SelectAll();
                richTxtAmount.Focus();
                return;
            }

            creditMemoNote = richTxtNote.Text.Trim();

            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
            {
                try
                {
                    conn = new SqlConnection(parentForm1.OtherStoreConnectionString(RRStoreCode));

                    cmd1 = new SqlCommand("Create_CreditMemo", conn);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = RRStoreCode;
                    cmd1.Parameters.Add("@rrID", SqlDbType.BigInt).Value = RRID;
                    cmd1.Parameters.Add("@CreditMemoNumber", SqlDbType.NVarChar).Value = creditMemoNumber;
                    cmd1.Parameters.Add("@CreditMemoAmount", SqlDbType.Money).Value = creditMemoAmount;
                    cmd1.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = parentForm1.employeeID;
                    cmd1.Parameters.Add("@ReceiveDate", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd1.Parameters.Add("@Note", SqlDbType.NVarChar).Value = creditMemoNote;

                    cmd2 = new SqlCommand("Update_ReturnReportHeader", conn);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 3;
                    cmd2.Parameters.Add("@rrID", SqlDbType.BigInt).Value = RRID;
                    cmd2.Parameters.Add("@rrShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                    cmd2.Parameters.Add("@rrSubmitDate", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd2.Parameters.Add("@rrReturnedDate", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd2.Parameters.Add("@rrTrackingNumber", SqlDbType.NVarChar).Value = "N/A";
                    cmd2.Parameters.Add("@rrReturnTotalAmount", SqlDbType.Money).Value = 0;
                    cmd2.Parameters.Add("@rrReceivingTotalAmount", SqlDbType.Money).Value = creditMemoAmount;
                    cmd2.Parameters.Add("@rrConfirmationID", SqlDbType.NVarChar).Value = "N/A";
                    cmd2.Parameters.Add("@rrStatus", SqlDbType.NVarChar).Value = "RECEIVING";
                    cmd2.Parameters.Add("@rrFirstContact", SqlDbType.NVarChar).Value = "N/A";

                    conn.Open();
                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    conn.Close();

                    parentForm3.Bind_DataGridview();
                    parentForm2.Show_CreditMemo_Count(RRID, RRStoreCode);
                    parentForm2.rrTotalReceivingAmount = parentForm3.creditMemoAmount;
                    parentForm2.lblTotalReceivingAmount.Text = string.Format("{0:c}", parentForm2.rrTotalReceivingAmount);
                    parentForm2.lblStatus.Text = "RECEIVING";

                    if (parentForm2.parentForm2.IsDisposed == false)
                    {
                        if (parentForm2.parentForm2.dataGridView1.RowCount == 0)
                            return;

                        parentForm2.parentForm2.SearchAllReturnReportList();
                    }

                    this.Close();
                }
                catch
                {
                    MessageBox.Show("DB CONNECTION ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                    return;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}