using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Management
{
    public partial class AdjustCashInSafe : Form
    {
        public LogInManagements parentForm1;
        public RegisterHistory parentForm2;

        SqlCommand cmd;

        int option;
        double DSRCashInSafe = 0;
        string DSRType, DSRNote;

        string sDate;
        double POSCardPayment = 0, POSCardSettlement = 0, CardPaymentDiff = 0;
        double POSCashPayment = 0, POSCashSettlement = 0, CashPaymentdiff = 0;
        double CashWithdrawal = 0;

        double CashDeposit = 0, CashInSafe = 0, NewCashBalance = 0;
        string CashDepositDate;

        public AdjustCashInSafe(int opt)
        {
            InitializeComponent();
            option = opt;
        }

        private void AdjustCashInSafe_Load(object sender, EventArgs e)
        {
            if (option == 0)
            {
                lblDate.Text = "INITIALIZING DATE";
                lblText.Text = "INITIAL CASH AMOUNT IN SAFE";
                DSRType = "CASH INITIALIZATION";
                richTxtNote.Text = "Initialization";

                richTxtNote.Enabled = false;
            }
            else if (option == 1)
            {
                lblDate.Text = "ADJUSTMENT DATE";
                lblText.Text = "CASH ADJUSTMENT AMOUNT";
                DSRType = "CASH ADJUSTMENT";

                richTxtNote.Enabled = true;
            }

            txtAmount.SelectAll();
            txtAmount.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtDate.Text.Trim() == "")
            {
                MessageBox.Show("Please input date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDate.Select();
                txtDate.Focus();
                return;
            }

            if (txtAmount.Text.Trim() == "")
            {
                MessageBox.Show("Please input amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAmount.Select();
                txtAmount.Focus();
                return;
            }

            if(double.TryParse(txtAmount.Text.Trim(), out DSRCashInSafe))
            {
                if (DSRCashInSafe < 0)
                {
                    MessageBox.Show("Invalid amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAmount.SelectAll();
                    txtAmount.Focus();
                    return;
                }

                try
                {
                    DSRNote = richTxtNote.Text.Trim().ToString();

                    cmd = new SqlCommand("Create_CashInSafe", parentForm1.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@DSRStoreCode", SqlDbType.NVarChar).Value = parentForm1.StoreCode.ToUpper();
                    cmd.Parameters.Add("@DSRDate", SqlDbType.DateTime).Value = txtDate.Text.Trim();
                    cmd.Parameters.Add("@DSRDay", SqlDbType.NVarChar).Value = lblDay.Text.Trim();
                    cmd.Parameters.Add("@DSRCashInSafe", SqlDbType.Money).Value = DSRCashInSafe;
                    cmd.Parameters.Add("@DSRCreateDate", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@DSRCreateID", SqlDbType.NVarChar).Value = parentForm1.employeeID.ToUpper();
                    cmd.Parameters.Add("@DSRType", SqlDbType.NVarChar).Value = DSRType;
                    cmd.Parameters.Add("@DSRNote", SqlDbType.NVarChar).Value = DSRNote;
                    cmd.Parameters.Add("@DSRDeleted", SqlDbType.Bit).Value = false;

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    MessageBox.Show("Successfully created.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    parentForm2.btnSettlementReportOK_Click(null, null);
                }
                catch
                {
                    MessageBox.Show("DB connection error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (parentForm1.conn.State == ConnectionState.Open)
                        parentForm1.conn.Close();

                    txtAmount.SelectAll();
                    txtAmount.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Invalid amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAmount.SelectAll();
                txtAmount.Focus();
                return;
            }
        }

        private void txtDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar1.SelectionStart));
            monthCalendar1.Visible = false;
        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {
            if (txtDate.Text.Trim() == "")
            {
                POSCardPayment = 0; POSCardSettlement = 0; CardPaymentDiff = 0;
                POSCashPayment = 0; POSCashSettlement = 0; CashPaymentdiff = 0;
                CashWithdrawal = 0;

                CashDeposit = 0; CashInSafe = 0; NewCashBalance = 0;

                lblCurentCashInSafe.Text = "";

                txtDate.Select();
                txtDate.Focus();
                return;
            }

            if (parentForm2.Checking_DuplicatedDate_DailySettlementReport(txtDate.Text.Trim()) != 0)
            {
                MessageBox.Show("The seleted date (" + txtDate.Text + ") is not available for cash adjustment.\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDate.Clear();
                txtDate.Focus();
                return;
            }

            if (parentForm2.Checking_DuplicatedDate_CashAdjustment(txtDate.Text.Trim()) != 0)
            {
                MessageBox.Show("The seleted date (" + txtDate.Text + ") is not available for another cash adjustment.\n" + "Only one cash adjustment per day is allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDate.Clear();
                txtDate.Focus();
                return;
            }


            DateTime d;

            POSCardPayment = 0; POSCardSettlement = 0; CardPaymentDiff = 0;
            POSCashPayment = 0; POSCashSettlement = 0; CashPaymentdiff = 0;
            CashWithdrawal = 0;

            CashDeposit = 0; CashInSafe = 0; NewCashBalance = 0;

            if (DateTime.TryParse(txtDate.Text.Trim(), out d))
            {
                if (DateTime.Today < d)
                {
                    MessageBox.Show("You can not create a report in advance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDate.Clear();
                    txtDate.Focus();
                    return;
                }

                lblDay.Text = d.DayOfWeek.ToString().ToUpper();
                sDate = txtDate.Text.Trim();

                try
                {
                    cmd = new SqlCommand("Get_Daily_Settlement_Amount", parentForm1.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = sDate;
                    SqlParameter POSCardPaymentParam = cmd.Parameters.Add("@POSCardPayment", SqlDbType.Money);
                    SqlParameter POSCashPaymentParam = cmd.Parameters.Add("@POSCashPayment", SqlDbType.Money);
                    SqlParameter POSCashSettlementParam = cmd.Parameters.Add("@POSCashSettlement", SqlDbType.Money);
                    SqlParameter CashPaymentDiffParam = cmd.Parameters.Add("@CashPaymentDiff", SqlDbType.Money);
                    SqlParameter CashWithdrawalParam = cmd.Parameters.Add("@CashWithdrawal", SqlDbType.Money);
                    SqlParameter CashInSafeParam = cmd.Parameters.Add("@CashInSafe", SqlDbType.Money);
                    POSCardPaymentParam.Direction = ParameterDirection.Output;
                    POSCashPaymentParam.Direction = ParameterDirection.Output;
                    POSCashSettlementParam.Direction = ParameterDirection.Output;
                    CashPaymentDiffParam.Direction = ParameterDirection.Output;
                    CashWithdrawalParam.Direction = ParameterDirection.Output;
                    CashInSafeParam.Direction = ParameterDirection.Output;

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    if (cmd.Parameters["@POSCardPayment"].Value != DBNull.Value)
                        POSCardPayment = Convert.ToDouble(cmd.Parameters["@POSCardPayment"].Value);

                    if (cmd.Parameters["@POSCashPayment"].Value != DBNull.Value)
                        POSCashPayment = Convert.ToDouble(cmd.Parameters["@POSCashPayment"].Value);

                    if (cmd.Parameters["@POSCashSettlement"].Value != DBNull.Value)
                        POSCashSettlement = Convert.ToDouble(cmd.Parameters["@POSCashSettlement"].Value);

                    if (cmd.Parameters["@CashPaymentDiff"].Value != DBNull.Value)
                        CashPaymentdiff = Convert.ToDouble(cmd.Parameters["@CashPaymentDiff"].Value);

                    if (cmd.Parameters["@CashWithdrawal"].Value != DBNull.Value)
                        CashWithdrawal = Convert.ToDouble(cmd.Parameters["@CashWithdrawal"].Value);

                    if (cmd.Parameters["@CashInSafe"].Value != DBNull.Value)
                        CashInSafe = Convert.ToDouble(cmd.Parameters["@CashInSafe"].Value);

                    lblCurentCashInSafe.Text = string.Format("{0:c}", CashInSafe);
                }
                catch
                {
                    MessageBox.Show("DB connection error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (parentForm1.conn.State == ConnectionState.Open)
                        parentForm1.conn.Close();

                    return;
                }
            }
            else
            {
                MessageBox.Show("Invalid date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDate.SelectAll();
                txtDate.Focus();
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
