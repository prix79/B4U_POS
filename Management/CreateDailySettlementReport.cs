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
    public partial class CreateDailySettlementReport : Form
    {
        public LogInManagements parentForm1;
        public RegisterHistory parentForm2;
        public SqlCommand cmd;
        string sp_WithDeposit = "Create_DailySettlementReport_WithDeposit";
        string sp_WithoutDeposit = "Create_DailySettlementReport_WithoutDeposit";

        string sDate;
        double POSCardPayment = 0, POSCardSettlement = 0, CardPaymentDiff = 0;
        double POSCashPayment = 0, POSCashSettlement = 0, CashPaymentdiff = 0;
        double CashWithdrawal = 0;

        double CashDeposit = 0, CashInSafe = 0, NewCashBalance = 0;
        string CashDepositDate;

        public CreateDailySettlementReport()
        {
            InitializeComponent();
        }

        private void CreateDailySalesReport_Load(object sender, EventArgs e)
        {
            //txtDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            //lblDay.Text = DateTime.Today.DayOfWeek.ToString().ToUpper();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtDate.Text.Trim() == "")
            {
                MessageBox.Show("Please input daily report date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDate.SelectAll();
                txtDate.Focus();
                return;
            }

            if (txtPOSCardSettlement.Text.Trim() == "")
            {
                MessageBox.Show("Please input POS card settlement amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPOSCardSettlement.SelectAll();
                txtPOSCardSettlement.Focus();
                return;
            }

            if (CashDeposit > 0)
            {
                if (txtCashDepositDate.Text.Trim() == "")
                {
                    MessageBox.Show("Please input cash deposit date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCashDepositDate.SelectAll();
                    txtCashDepositDate.Focus();
                    return;
                }
                else
                {
                    CashDepositDate = txtCashDepositDate.Text.Trim();
                }
            }

            if (txtCashDepositDate.Text.Trim() != "")
            {
                if (CashDeposit == 0)
                {
                    MessageBox.Show("Please input cash deposit amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCashDepositDate.SelectAll();
                    txtCashDepositDate.Focus();
                    return;
                }
            }

            try
            {
                if (CashDeposit > 0)
                {
                    cmd = new SqlCommand(sp_WithDeposit, parentForm1.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@DSRStoreCode", SqlDbType.NVarChar).Value = parentForm1.StoreCode.ToUpper();
                    cmd.Parameters.Add("@DSRDate", SqlDbType.DateTime).Value = txtDate.Text.Trim();
                    cmd.Parameters.Add("@DSRDay", SqlDbType.NVarChar).Value = lblDay.Text.Trim();
                    cmd.Parameters.Add("@DSRPOSCardAmt", SqlDbType.Money).Value = POSCardPayment;
                    cmd.Parameters.Add("@DSRSettleCardAmt", SqlDbType.Money).Value = POSCardSettlement;
                    cmd.Parameters.Add("@DSRCardDiff", SqlDbType.Money).Value = CardPaymentDiff;
                    cmd.Parameters.Add("@DSRPOSCashAmt", SqlDbType.Money).Value = POSCashPayment;
                    cmd.Parameters.Add("@DSRSettleCashAmt", SqlDbType.Money).Value = POSCashSettlement;
                    cmd.Parameters.Add("@DSRCashDiff", SqlDbType.Money).Value = CashPaymentdiff;
                    cmd.Parameters.Add("@DSRCashWithdrawal", SqlDbType.Money).Value = CashWithdrawal;
                    cmd.Parameters.Add("@DSRCashDepositAmt", SqlDbType.Money).Value = CashDeposit;
                    cmd.Parameters.Add("@DSRCashDepositDate", SqlDbType.DateTime).Value = CashDepositDate;
                    cmd.Parameters.Add("@DSRCashDepositInputDate", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@DSRCashInSafe", SqlDbType.Money).Value = NewCashBalance;
                    cmd.Parameters.Add("@DSRCreateDate", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@DSRCreateID", SqlDbType.NVarChar).Value = parentForm1.employeeID.ToUpper();
                    cmd.Parameters.Add("@DSRNote", SqlDbType.NVarChar).Value = richTxtNote.Text.Trim();
                    cmd.Parameters.Add("@DSRType", SqlDbType.NVarChar).Value = "DAILY REPORT";
                    cmd.Parameters.Add("@DSRDeleted", SqlDbType.Bit).Value = false;

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();
                }
                else
                {
                    cmd = new SqlCommand(sp_WithoutDeposit, parentForm1.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@DSRStoreCode", SqlDbType.NVarChar).Value = parentForm1.StoreCode.ToUpper();
                    cmd.Parameters.Add("@DSRDate", SqlDbType.DateTime).Value = txtDate.Text.Trim();
                    cmd.Parameters.Add("@DSRDay", SqlDbType.NVarChar).Value = lblDay.Text.Trim();
                    cmd.Parameters.Add("@DSRPOSCardAmt", SqlDbType.Money).Value = POSCardPayment;
                    cmd.Parameters.Add("@DSRSettleCardAmt", SqlDbType.Money).Value = POSCardSettlement;
                    cmd.Parameters.Add("@DSRCardDiff", SqlDbType.Money).Value = CardPaymentDiff;
                    cmd.Parameters.Add("@DSRPOSCashAmt", SqlDbType.Money).Value = POSCashPayment;
                    cmd.Parameters.Add("@DSRSettleCashAmt", SqlDbType.Money).Value = POSCashSettlement;
                    cmd.Parameters.Add("@DSRCashDiff", SqlDbType.Money).Value = CashPaymentdiff;
                    cmd.Parameters.Add("@DSRCashWithdrawal", SqlDbType.Money).Value = CashWithdrawal;
                    //cmd.Parameters.Add("@DSRCashDepositAmt", SqlDbType.Money).Value = CashDeposit;
                    //cmd.Parameters.Add("@DSRCashDepositDate", SqlDbType.DateTime).Value = CashDepositDate;
                    //cmd.Parameters.Add("@DSRCashDepositInputDate", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@DSRCashInSafe", SqlDbType.Money).Value = CashInSafe + CashWithdrawal;
                    cmd.Parameters.Add("@DSRCreateDate", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@DSRCreateID", SqlDbType.NVarChar).Value = parentForm1.employeeID.ToUpper();
                    cmd.Parameters.Add("@DSRNote", SqlDbType.NVarChar).Value = richTxtNote.Text.Trim();
                    cmd.Parameters.Add("@DSRType", SqlDbType.NVarChar).Value = "DAILY REPORT";
                    cmd.Parameters.Add("@DSRDeleted", SqlDbType.Bit).Value = false;

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();
                }

                MessageBox.Show("Successfully created.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                parentForm2.btnSettlementReportOK_Click(null, null);
            }
            catch
            {
                MessageBox.Show("DB connection error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (parentForm1.conn.State == ConnectionState.Open)
                    parentForm1.conn.Close();

                return;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtDate.Text = "";
            txtCashDeposit.Text = "0.00";
            txtCashDepositDate.Text = "";


            txtDate.Select();
            txtDate.Focus();
            return;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPOSCardSettlement_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtPOSCardSettlement.Text.Trim().ToString(), out POSCardSettlement))
            {
                CardPaymentDiff = POSCardSettlement - POSCardPayment;
                lblCardPaymentDiff.Text = string.Format("{0:c}", CardPaymentDiff);

                if (CardPaymentDiff < 0)
                {
                    lblCardPaymentDiff.ForeColor = Color.Red;
                }
                else if (CardPaymentDiff > 0)
                {
                    lblCardPaymentDiff.ForeColor = Color.DarkGreen;
                }
                else
                {
                    lblCardPaymentDiff.ForeColor = Color.Black;
                }
            }
            else
            {
                MessageBox.Show("Invalid amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPOSCardSettlement.SelectAll();
                txtPOSCardSettlement.Focus();
            }
        }

        private void txtCashDeposit_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtCashDeposit.Text.Trim().ToString(), out CashDeposit))
            {
                if (CashDeposit < 0)
                {
                    MessageBox.Show("Invalid cash deposit amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCashDeposit.SelectAll();
                    txtCashDeposit.Focus();
                }

                NewCashBalance = CashInSafe + CashWithdrawal - CashDeposit;
                lblCashInSafe.Text = string.Format("{0:c}", NewCashBalance);

                if (NewCashBalance < 0)
                {
                    lblNewCashBalanceInSafe.ForeColor = Color.Red;
                }
                else if (NewCashBalance > 0)
                {
                    lblNewCashBalanceInSafe.ForeColor = Color.DarkGreen;
                }
                else
                {
                    lblNewCashBalanceInSafe.ForeColor = Color.Black;
                }

                if (NewCashBalance < 0)
                {
                    MessageBox.Show("Invalid cash deposit amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCashDeposit.SelectAll();
                    txtCashDeposit.Focus();
                }
            }
            else
            {
                MessageBox.Show("Invalid amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCashDeposit.SelectAll();
                txtCashDeposit.Focus();
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

                lblPOSCardPayment.Text = string.Format("{0:c}", POSCardPayment);
                CardPaymentDiff = POSCardSettlement - POSCardPayment;
                lblCardPaymentDiff.Text = string.Format("{0:c}", CardPaymentDiff);
                lblPOSCashPayment.Text = string.Format("{0:c}", POSCashPayment);
                lblPOSCashSettlement.Text = string.Format("{0:c}", POSCashSettlement);
                CashPaymentdiff = POSCashSettlement - POSCashPayment;
                lblCashPaymentDiff.Text = string.Format("{0:c}", CashPaymentdiff);
                lblCashwithdrawal.Text = string.Format("{0:c}", CashWithdrawal);
                lblCashInSafe.Text = string.Format("{0:c}", CashInSafe);
                lblNewCashBalanceInSafe.Text = string.Format("{0:c}", CashInSafe + CashWithdrawal);

                txtPOSCardSettlement.Text = "0.00";
                txtCashDeposit.Text = "0.00";

                if (CardPaymentDiff < 0)
                {
                    lblCardPaymentDiff.ForeColor = Color.Red;
                }
                else if (CardPaymentDiff > 0)
                {
                    lblCardPaymentDiff.ForeColor = Color.DarkGreen;
                }
                else
                {
                    lblCardPaymentDiff.ForeColor = Color.Black;
                }

                if (CashPaymentdiff < 0)
                {
                    lblCashPaymentDiff.ForeColor = Color.Red;
                }
                else if (CashPaymentdiff > 0)
                {
                    lblCashPaymentDiff.ForeColor = Color.DarkGreen;
                }
                else
                {
                    lblCashPaymentDiff.ForeColor = Color.Black;
                }

                if (CashInSafe + CashWithdrawal < 0)
                {
                    lblNewCashBalanceInSafe.ForeColor = Color.Red;
                }
                else if (CashInSafe + CashWithdrawal > 0)
                {
                    lblNewCashBalanceInSafe.ForeColor = Color.DarkGreen;
                }
                else
                {
                    lblNewCashBalanceInSafe.ForeColor = Color.Black;
                }

                txtDate.Select();
                txtDate.Focus();
                return;
            }

            if(parentForm2.Checking_DuplicatedDate_DailySettlementReport(txtDate.Text.Trim()) != 0)
            {
                MessageBox.Show("The seleted date ("+ txtDate.Text + ") is not available for new daily settlement report.\n"+"Daily settlement report must be created in order by date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if(DateTime.Today < d)
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

                    lblPOSCardPayment.Text = string.Format("{0:c}", POSCardPayment);
                    CardPaymentDiff = POSCardSettlement - POSCardPayment;
                    lblCardPaymentDiff.Text = string.Format("{0:c}", CardPaymentDiff);
                    lblPOSCashPayment.Text = string.Format("{0:c}", POSCashPayment);
                    lblPOSCashSettlement.Text = string.Format("{0:c}", POSCashSettlement);
                    CashPaymentdiff = POSCashSettlement - POSCashPayment;
                    lblCashPaymentDiff.Text = string.Format("{0:c}", CashPaymentdiff);
                    lblCashwithdrawal.Text = string.Format("{0:c}", CashWithdrawal);
                    lblCashInSafe.Text = string.Format("{0:c}", CashInSafe);
                    lblNewCashBalanceInSafe.Text = string.Format("{0:c}", CashInSafe + CashWithdrawal);

                    txtPOSCardSettlement.Text = "0.00";
                    txtCashDeposit.Text = "0.00";

                    if (CardPaymentDiff < 0)
                    {
                        lblCardPaymentDiff.ForeColor = Color.Red;
                    }
                    else if (CardPaymentDiff > 0)
                    {
                        lblCardPaymentDiff.ForeColor = Color.DarkGreen;
                    }
                    else
                    {
                        lblCardPaymentDiff.ForeColor = Color.Black;
                    }

                    if (CashPaymentdiff < 0)
                    {
                        lblCashPaymentDiff.ForeColor = Color.Red;
                    }
                    else if (CashPaymentdiff > 0)
                    {
                        lblCashPaymentDiff.ForeColor = Color.DarkGreen;
                    }
                    else
                    {
                        lblCashPaymentDiff.ForeColor = Color.Black;
                    }

                    if (CashInSafe + CashWithdrawal < 0)
                    {
                        lblNewCashBalanceInSafe.ForeColor = Color.Red;
                    }
                    else if (CashInSafe + CashWithdrawal > 0)
                    {
                        lblNewCashBalanceInSafe.ForeColor = Color.DarkGreen;
                    }
                    else
                    {
                        lblNewCashBalanceInSafe.ForeColor = Color.Black;
                    }

                    txtPOSCardSettlement.SelectAll();
                    txtPOSCardSettlement.Focus();
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

        private void txtCashDepositDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar2.Visible = true;
        }

        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtCashDepositDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar2.SelectionStart));
            monthCalendar2.Visible = false;
        }
    }
}
