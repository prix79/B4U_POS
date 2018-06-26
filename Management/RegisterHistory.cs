using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Management
{
    public partial class RegisterHistory : Form
    {
        public LogInManagements parentForm;
        public SqlCommand cmd;
        public SqlConnection newConn;

        string receiptTransStartDate, receiptTransEndDate, receiptTransRegisterNum;
        double cashSales = 0, cardSales = 0, terminalSales = 0, storeCreditSales = 0;
        double paymentTotal = 0;
        double cashChangeFromMultiPay = 0;
        double cashSalesFromMultiPay = 0, debitSalesFromMultiPay = 0, storeCreditSalesFromMultiPay = 0, tCreditSalesFromMultiPay = 0, visaSalesFromMultiPay = 0, masterSalesFromMultiPay = 0, amexSalesFromMultiPay = 0, discoverSalesFromMultiPay = 0;
        double cashRefundAmount = 0, cardRefundAmount = 0;
        double visaRefundAmount = 0, masterRefundAmount = 0, amexRefundAmount = 0, discoverRefundAmount = 0, tCreditRefundAmount = 0, debitRefundAmount = 0;
        double storeCreditIssueAmount = 0;
        double netSales = 0, totalGrossSales = 0;
        Int64 numberOfTrans = 0;
        double everageNetSales = 0, everageSales = 0;

        string registerTransStartDate, registerTransEndDate, registerTransRegisterNum;
        double shortage = 0;
        double totalWithdrawal = 0;

        string batchHistoryStartDate, batchHistoryEndDate;

        Int64 totalBatchCount = 0;

        double totalBatchAmount = 0;

        public RegisterHistory()
        {
            InitializeComponent();
        }

        private void RegisterHistory_Load(object sender, EventArgs e)
        {
            txtReceiptTransStart.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            txtReceiptTransEnd.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            cmbReceiptTransRegisterNum.SelectedIndex = 0;

            txtRegisterTransStart.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            txtRegisterTransEnd.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            cmbRegisterTransRegisterNum.SelectedIndex = 0;

            txtBatchHistoryStart.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            txtBatchHistoryEnd.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            //cmbRegisterTransRegisterNum.SelectedIndex = 0;

            txtDSRStartDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            txtDSREndDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

            SqlCommand cmd_StoreList = new SqlCommand("Get_Retail_StoreCode", parentForm.conn);
            cmd_StoreList.CommandType = CommandType.StoredProcedure;
            DataSet ds_StoreList = new DataSet();
            SqlDataAdapter adapt_StoreList = new SqlDataAdapter(cmd_StoreList);

            parentForm.conn.Open();
            ds_StoreList.Clear();
            adapt_StoreList.Fill(ds_StoreList);
            parentForm.conn.Close();

            cmbCPBHStoreCode.DataSource = ds_StoreList.Tables[0].DefaultView;
            cmbCPBHStoreCode.ValueMember = "CIStoreCode";
            cmbCPBHStoreCode.DisplayMember = "CIStoreCode";

            cmbCPBHStoreCode.Text = parentForm.StoreCode.ToUpper();

            cmbDSRStoreCode.DataSource = ds_StoreList.Tables[0].DefaultView;
            cmbDSRStoreCode.ValueMember = "CIStoreCode";
            cmbDSRStoreCode.DisplayMember = "CIStoreCode";

            cmbDSRStoreCode.Text = parentForm.StoreCode.ToUpper();

            if (parentForm.userLevel >= parentForm.btnManagementChangeStore)
            {
                lblCPBHStoreCode.Visible = true;
                cmbCPBHStoreCode.Visible = true;

                lblDSRStoreCode.Visible = true;
                cmbDSRStoreCode.Visible = true;
            }
            else
            {
                lblCPBHStoreCode.Visible = false;
                cmbCPBHStoreCode.Visible = false;

                lblDSRStoreCode.Visible = false;
                cmbDSRStoreCode.Visible = false;
            }
        }

        private void btnReceiptTransOK_Click(object sender, EventArgs e)
        {
            cashSales = 0; cardSales = 0; terminalSales = 0; storeCreditSales = 0;
            cashChangeFromMultiPay = 0;
            cashSalesFromMultiPay = 0; debitSalesFromMultiPay = 0; storeCreditSalesFromMultiPay = 0;
            tCreditSalesFromMultiPay = 0; visaSalesFromMultiPay = 0; masterSalesFromMultiPay = 0; amexSalesFromMultiPay = 0; discoverSalesFromMultiPay = 0;
            cashRefundAmount = 0; cardRefundAmount = 0;
            visaRefundAmount = 0; masterRefundAmount = 0; amexRefundAmount = 0; discoverRefundAmount = 0; tCreditRefundAmount = 0; debitRefundAmount = 0;
            storeCreditIssueAmount = 0;
            paymentTotal = 0;
            netSales = 0; totalGrossSales = 0;
            numberOfTrans = 0;
            everageNetSales = 0; everageSales = 0;

            receiptTransStartDate = txtReceiptTransStart.Text;
            receiptTransEndDate = txtReceiptTransEnd.Text;
            receiptTransRegisterNum = cmbReceiptTransRegisterNum.Text;

            if (receiptTransStartDate == "")
            {
                MessageBox.Show("SELECT DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (receiptTransEndDate == "")
            {
                MessageBox.Show("SELECT END DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (receiptTransRegisterNum == "")
            {
                MessageBox.Show("SELECT REGISTER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cmd = new SqlCommand("ReceiptTransactions_RegisterHistory", parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = receiptTransStartDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = receiptTransEndDate;
            cmd.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = receiptTransRegisterNum;

            SqlDataAdapter adapt = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            adapt.Fill(dt);
            parentForm.conn.Close();

            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = dt;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (Convert.ToString(dataGridView1.Rows[i].Cells[6].Value) == "1")
                {
                    cashSales = cashSales + Convert.ToDouble(dataGridView1.Rows[i].Cells[10].Value);
                }
                else if (Convert.ToString(dataGridView1.Rows[i].Cells[6].Value) == "2" | Convert.ToString(dataGridView1.Rows[i].Cells[6].Value) == "3")
                {
                    terminalSales = terminalSales + Convert.ToDouble(dataGridView1.Rows[i].Cells[10].Value);
                }
                else if (Convert.ToString(dataGridView1.Rows[i].Cells[6].Value) == "4" | Convert.ToString(dataGridView1.Rows[i].Cells[6].Value) == "5" | Convert.ToString(dataGridView1.Rows[i].Cells[6].Value) == "6" | Convert.ToString(dataGridView1.Rows[i].Cells[6].Value) == "7" | Convert.ToString(dataGridView1.Rows[i].Cells[6].Value) == "8")
                {
                    cardSales = cardSales + Convert.ToDouble(dataGridView1.Rows[i].Cells[10].Value);
                }
                else if (Convert.ToString(dataGridView1.Rows[i].Cells[6].Value) == "88")
                {
                    storeCreditSales = storeCreditSales + Convert.ToDouble(dataGridView1.Rows[i].Cells[10].Value);
                }
                /*else if (Convert.ToString(dataGridView1.Rows[i].Cells[6].Value) == "0")
                {
                    returnAmount = returnAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[10].Value);
                }*/

                if (Convert.ToString(dataGridView1.Rows[i].Cells[6].Value) == "99")
                {
                    cashChangeFromMultiPay = cashChangeFromMultiPay + Convert.ToDouble(dataGridView1.Rows[i].Cells[15].Value);
                }

                netSales = netSales + Convert.ToDouble(dataGridView1.Rows[i].Cells[9].Value);
                totalGrossSales = totalGrossSales + Convert.ToDouble(dataGridView1.Rows[i].Cells[10].Value);
            }

            cmd.CommandText = "Get_Sales_From_MultiPay_and_Refund_New";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = receiptTransStartDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = receiptTransEndDate;
            cmd.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = receiptTransRegisterNum;
            SqlParameter CashSalesFromMultiPay_Param = cmd.Parameters.Add("@CashSalesFromMultiPay", SqlDbType.Money);
            SqlParameter VisaSalesFromMultiPay_Param = cmd.Parameters.Add("@VisaSalesFromMultiPay", SqlDbType.Money);
            SqlParameter MasterSalesFromMultiPay_Param = cmd.Parameters.Add("@MasterSalesFromMultiPay", SqlDbType.Money);
            SqlParameter AmexFromMultiPay_Param = cmd.Parameters.Add("@AmexSalesFromMultiPay", SqlDbType.Money);
            SqlParameter DiscoverSalesFromMultiPay_Param = cmd.Parameters.Add("@DiscoverSalesFromMultiPay", SqlDbType.Money);
            SqlParameter DebitSalesFromMultiPay_Param = cmd.Parameters.Add("@DebitSalesFromMultiPay", SqlDbType.Money);
            SqlParameter TCreditSalesFromMultiPay_Param = cmd.Parameters.Add("@TCreditSalesFromMultiPay", SqlDbType.Money);
            SqlParameter StoreCreditSalesFromMultiPay_Param = cmd.Parameters.Add("@StoreCreditSalesFromMultiPay", SqlDbType.Money);
            SqlParameter CashRefundAmount_Param = cmd.Parameters.Add("@CashRefundAmount", SqlDbType.Money);
            SqlParameter VisaRefundAmount_Param = cmd.Parameters.Add("@VisaRefundAmount", SqlDbType.Money);
            SqlParameter MasterRefundAmount_Param = cmd.Parameters.Add("@MasterRefundAmount", SqlDbType.Money);
            SqlParameter AmexRefundAmount_Param = cmd.Parameters.Add("@AmexRefundAmount", SqlDbType.Money);
            SqlParameter DiscoverRefundAmount_Param = cmd.Parameters.Add("@DiscoverRefundAmount", SqlDbType.Money);
            SqlParameter TCreditRefundAmount_Param = cmd.Parameters.Add("@TCreditRefundAmount", SqlDbType.Money);
            SqlParameter DebitRefundAmount_Param = cmd.Parameters.Add("@DebitRefundAmount", SqlDbType.Money);
            SqlParameter StoreCreditIssueAmount_Param = cmd.Parameters.Add("@StoreCreditIssueAmount", SqlDbType.Money);

            CashSalesFromMultiPay_Param.Direction = ParameterDirection.Output;
            VisaSalesFromMultiPay_Param.Direction = ParameterDirection.Output;
            MasterSalesFromMultiPay_Param.Direction = ParameterDirection.Output;
            AmexFromMultiPay_Param.Direction = ParameterDirection.Output;
            DiscoverSalesFromMultiPay_Param.Direction = ParameterDirection.Output;
            DebitSalesFromMultiPay_Param.Direction = ParameterDirection.Output;
            TCreditSalesFromMultiPay_Param.Direction = ParameterDirection.Output;
            StoreCreditSalesFromMultiPay_Param.Direction = ParameterDirection.Output;
            CashRefundAmount_Param.Direction = ParameterDirection.Output;
            VisaRefundAmount_Param.Direction = ParameterDirection.Output;
            MasterRefundAmount_Param.Direction = ParameterDirection.Output;
            AmexRefundAmount_Param.Direction = ParameterDirection.Output;
            DiscoverRefundAmount_Param.Direction = ParameterDirection.Output;
            TCreditRefundAmount_Param.Direction = ParameterDirection.Output;
            DebitRefundAmount_Param.Direction = ParameterDirection.Output;
            StoreCreditIssueAmount_Param.Direction = ParameterDirection.Output;

            parentForm.conn.Open();
            cmd.ExecuteNonQuery();
            parentForm.conn.Close();

            if (cmd.Parameters["@CashSalesFromMultiPay"].Value != DBNull.Value)
                cashSalesFromMultiPay = Convert.ToDouble(cmd.Parameters["@CashSalesFromMultiPay"].Value);

            if (cmd.Parameters["@VisaSalesFromMultiPay"].Value != DBNull.Value)
                visaSalesFromMultiPay = Convert.ToDouble(cmd.Parameters["@VisaSalesFromMultiPay"].Value);

            if (cmd.Parameters["@MasterSalesFromMultiPay"].Value != DBNull.Value)
                masterSalesFromMultiPay = Convert.ToDouble(cmd.Parameters["@MasterSalesFromMultiPay"].Value);

            if (cmd.Parameters["@AmexSalesFromMultiPay"].Value != DBNull.Value)
                amexSalesFromMultiPay = Convert.ToDouble(cmd.Parameters["@AmexSalesFromMultiPay"].Value);

            if (cmd.Parameters["@DiscoverSalesFromMultiPay"].Value != DBNull.Value)
                discoverSalesFromMultiPay = Convert.ToDouble(cmd.Parameters["@DiscoverSalesFromMultiPay"].Value);

            if (cmd.Parameters["@DebitSalesFromMultiPay"].Value != DBNull.Value)
                debitSalesFromMultiPay = Convert.ToDouble(cmd.Parameters["@DebitSalesFromMultiPay"].Value);

            if (cmd.Parameters["@TCreditSalesFromMultiPay"].Value != DBNull.Value)
                tCreditSalesFromMultiPay = Convert.ToDouble(cmd.Parameters["@TCreditSalesFromMultiPay"].Value);

            if (cmd.Parameters["@StoreCreditSalesFromMultiPay"].Value != DBNull.Value)
                storeCreditSalesFromMultiPay = Convert.ToDouble(cmd.Parameters["@StoreCreditSalesFromMultiPay"].Value);

            if (cmd.Parameters["@CashRefundAmount"].Value != DBNull.Value)
                cashRefundAmount = Convert.ToDouble(cmd.Parameters["@CashRefundAmount"].Value);

            if (cmd.Parameters["@VisaRefundAmount"].Value != DBNull.Value)
                visaRefundAmount = Convert.ToDouble(cmd.Parameters["@VisaRefundAmount"].Value);

            if (cmd.Parameters["@MasterRefundAmount"].Value != DBNull.Value)
                masterRefundAmount = Convert.ToDouble(cmd.Parameters["@MasterRefundAmount"].Value);

            if (cmd.Parameters["@AmexRefundAmount"].Value != DBNull.Value)
                amexRefundAmount = Convert.ToDouble(cmd.Parameters["@AmexRefundAmount"].Value);

            if (cmd.Parameters["@DiscoverRefundAmount"].Value != DBNull.Value)
                discoverRefundAmount = Convert.ToDouble(cmd.Parameters["@DiscoverRefundAmount"].Value);

            if (cmd.Parameters["@TCreditRefundAmount"].Value != DBNull.Value)
                tCreditRefundAmount = Convert.ToDouble(cmd.Parameters["@TCreditRefundAmount"].Value);

            if (cmd.Parameters["@DebitRefundAmount"].Value != DBNull.Value)
                debitRefundAmount = Convert.ToDouble(cmd.Parameters["@DebitRefundAmount"].Value);

            if (cmd.Parameters["@StoreCreditIssueAmount"].Value != DBNull.Value)
                storeCreditIssueAmount = Convert.ToDouble(cmd.Parameters["@StoreCreditIssueAmount"].Value);

            cashSales = cashSales + cashSalesFromMultiPay - cashChangeFromMultiPay;
            cardSales = cardSales + visaSalesFromMultiPay + masterSalesFromMultiPay + amexSalesFromMultiPay + discoverSalesFromMultiPay + debitSalesFromMultiPay;
            terminalSales = terminalSales + tCreditSalesFromMultiPay;
            storeCreditSales = storeCreditSales + storeCreditSalesFromMultiPay;

            cardRefundAmount = visaRefundAmount + masterRefundAmount + amexRefundAmount + discoverRefundAmount + debitRefundAmount;

            paymentTotal = cashSales + cardSales + terminalSales + storeCreditSales - cashRefundAmount - cardRefundAmount - tCreditRefundAmount - storeCreditIssueAmount;

            numberOfTrans = dataGridView1.Rows.Count;
            everageNetSales = netSales / numberOfTrans;
            everageSales = totalGrossSales / numberOfTrans;

            lblCashSales.Text = string.Format("{0:c}", cashSales);
            lblCCardSales.Text = string.Format("{0:c}", cardSales);
            lblTCardSales.Text = string.Format("{0:c}", terminalSales);
            lblStoreCreditSales.Text = string.Format("{0:c}", storeCreditSales);

            lblCashRefund.Text = string.Format("{0:c}", cashRefundAmount);
            lblCCardRefund.Text = string.Format("{0:c}", cardRefundAmount);
            lblTCardRefund.Text = string.Format("{0:c}", tCreditRefundAmount);
            lblStoreCreditIssue.Text = string.Format("{0:c}", storeCreditIssueAmount);

            lblCashTotal.Text = string.Format("{0:c}", cashSales - cashRefundAmount);
            lblCCardTotal.Text = string.Format("{0:c}", cardSales - cardRefundAmount);
            lblTCardTotal.Text = string.Format("{0:c}", terminalSales - tCreditRefundAmount);
            lblPaymentTotal.Text = string.Format("{0:c}", paymentTotal);

            lblNetSale.Text = string.Format("{0:c}", netSales);
            lblTotalGrossSale.Text = string.Format("{0:c}", totalGrossSales);
            lblNumberOfTrans.Text = Convert.ToString(numberOfTrans);
            lblEverageNetSales.Text = string.Format("{0:c}", everageNetSales);
            lblEverageSales.Text = string.Format("{0:c}", everageSales);

            dataGridView1.ClearSelection();
        }

        private void btnReceiptTransClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtReceiptTransStart_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void txtReceiptTransEnd_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar2.Visible = true;
        }

        private void btnRegisterTransOK_Click(object sender, EventArgs e)
        {
            shortage = 0;
            totalWithdrawal = 0;

            registerTransStartDate = txtRegisterTransStart.Text;
            registerTransEndDate = txtRegisterTransEnd.Text;
            registerTransRegisterNum = cmbRegisterTransRegisterNum.Text;

            if (registerTransStartDate == "")
            {
                MessageBox.Show("SELECT START DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (registerTransEndDate == "")
            {
                MessageBox.Show("SELECT END DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (registerTransRegisterNum == "")
            {
                MessageBox.Show("SELECT REGISTER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cmd = new SqlCommand("RegisterTransactions_RegisterHistory", parentForm.conn);
            cmd.CommandType=CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = registerTransStartDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = registerTransEndDate;
            cmd.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = registerTransRegisterNum;

            SqlDataAdapter adapt = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            adapt.Fill(dt);
            parentForm.conn.Close();

            dataGridView2.RowTemplate.Height = 30;
            dataGridView2.DataSource = dt;
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[1].HeaderText = "REGISTER NUMBER";
            dataGridView2.Columns[1].Width = 90;
            dataGridView2.Columns[2].HeaderText = "STATUS";
            dataGridView2.Columns[2].Width = 90;
            dataGridView2.Columns[3].HeaderText = "START AMOUNT";
            dataGridView2.Columns[4].HeaderText = "END AMOUNT";
            dataGridView2.Columns[5].HeaderText = "CASH PAYMENT TOTAL";
            dataGridView2.Columns[6].HeaderText = "CASH IN DRAWER";
            dataGridView2.Columns[7].HeaderText = "WITHDRAW AMOUNT";
            dataGridView2.Columns[8].HeaderText = "SHORTAGE";
            dataGridView2.Columns[9].HeaderText = "DATE";
            dataGridView2.Columns[10].HeaderText = "TIME";
            dataGridView2.Columns[11].HeaderText = "CASHIER ID";
            dataGridView2.Columns[12].HeaderText = "MANAGER ID";

            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                shortage = shortage + Convert.ToDouble(dataGridView2.Rows[i].Cells[8].Value);
                totalWithdrawal = totalWithdrawal + Convert.ToDouble(dataGridView2.Rows[i].Cells[7].Value);
            }

            lblShortage.Text = string.Format("{0:c}", shortage);
            lblTotalWithdrawal.Text = string.Format("{0:c}", totalWithdrawal);

            if (shortage == 0)
            {
                lblShortage.ForeColor = Color.Black;
            }
            else if(shortage > 0)
            {
                lblShortage.ForeColor = Color.DarkGreen;
            }
            else
            {
                lblShortage.ForeColor = Color.Red;
            }

            dataGridView2.ClearSelection();
        }

        private void btnRegisterTransClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void monthCalendar1_DateSelected_1(object sender, DateRangeEventArgs e)
        {
            txtReceiptTransStart.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar1.SelectionStart));
            monthCalendar1.Visible = false;
        }

        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtReceiptTransEnd.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar2.SelectionStart));
            monthCalendar2.Visible = false;
        }

        private void monthCalendar3_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtRegisterTransStart.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar3.SelectionStart));
            monthCalendar3.Visible = false;
        }

        private void monthCalendar4_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtRegisterTransEnd.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar4.SelectionStart));
            monthCalendar4.Visible = false;
        }

        private void monthCalendar9_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtBatchHistoryStart.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar9.SelectionStart));
            monthCalendar9.Visible = false;
        }

        private void monthCalendar10_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtBatchHistoryEnd.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar10.SelectionStart));
            monthCalendar10.Visible = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ReceiptDetail receiptDetailForm = new ReceiptDetail(0);
            receiptDetailForm.parentForm1 = this.parentForm;
            receiptDetailForm.parentform2 = this;
            receiptDetailForm.ShowDialog();
        }

        private void txtRegisterTransStart_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar3.Visible = true;
        }

        private void txtRegisterTransEnd_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar4.Visible = true;
        }

        private void txtBatchHistoryStart_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            monthCalendar9.Visible = true;
        }

        private void txtBatchHistoryEnd_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            monthCalendar10.Visible = true;
        }

        private void btnBatchHistoryOK_Click(object sender, EventArgs e)
        {
            totalBatchCount = 0;
            totalBatchAmount = 0;

            batchHistoryStartDate = txtBatchHistoryStart.Text;
            batchHistoryEndDate = txtBatchHistoryEnd.Text;
            registerTransRegisterNum = cmbRegisterTransRegisterNum.Text;

            if (batchHistoryStartDate == "")
            {
                MessageBox.Show("SELECT START DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (batchHistoryEndDate == "")
            {
                MessageBox.Show("SELECT END DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbCPBHStoreCode.Text.Trim().ToUpper() == parentForm.StoreCode.ToUpper())
            {
                try
                {
                    cmd = new SqlCommand("CardPaymentBatchHistory_RegisterHistory", parentForm.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = batchHistoryStartDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = batchHistoryEndDate;

                    SqlDataAdapter adapt = new SqlDataAdapter();
                    DataTable dt = new DataTable();
                    adapt.SelectCommand = cmd;

                    parentForm.conn.Open();
                    adapt.Fill(dt);
                    parentForm.conn.Close();

                    dataGridView5.RowTemplate.Height = 30;
                    dataGridView5.DataSource = dt;
                    dataGridView5.Columns[0].Visible = false;
                    dataGridView5.Columns[1].HeaderText = "BATCH ID";
                    dataGridView5.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView5.Columns[1].Width = 130;
                    dataGridView5.Columns[2].HeaderText = "REGISTER NUMBER";
                    dataGridView5.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView5.Columns[2].Width = 50;
                    dataGridView5.Columns[3].Visible = false;
                    dataGridView5.Columns[4].Visible = false;
                    dataGridView5.Columns[5].HeaderText = "BATCH COUNT";
                    dataGridView5.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView5.Columns[5].Width = 70;
                    dataGridView5.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView5.Columns[6].HeaderText = "BATCH AMOUNT";
                    dataGridView5.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView5.Columns[6].Width = 100;
                    dataGridView5.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView5.Columns[6].DefaultCellStyle.Format = "c";
                    dataGridView5.Columns[7].Visible = false;
                    dataGridView5.Columns[8].HeaderText = "BATCH DATE AND TIME";
                    dataGridView5.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView5.Columns[8].Width = 150;
                    dataGridView5.Columns[9].HeaderText = "MANAGER ID";
                    dataGridView5.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView5.Columns[9].Width = 120;

                    for (int i = 0; i < dataGridView5.RowCount; i++)
                    {
                        totalBatchCount = totalBatchCount + Convert.ToInt64(dataGridView5.Rows[i].Cells[5].Value);
                        totalBatchAmount = totalBatchAmount + Convert.ToDouble(dataGridView5.Rows[i].Cells[6].Value);
                    }

                    lblTotalBatchCount.Text = totalBatchCount.ToString();
                    lblTotalBatchAmount.Text = string.Format("{0:c}", totalBatchAmount);

                    dataGridView5.ClearSelection();
                }
                catch
                {
                    MessageBox.Show("DB connection error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parentForm.conn.Close();
                    return;
                }
            }
            else
            {
                try
                {
                    newConn = new SqlConnection(parentForm.OtherStoreConnectionString(cmbCPBHStoreCode.Text.Trim().ToUpper()));

                    cmd = new SqlCommand("CardPaymentBatchHistory_RegisterHistory", newConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = batchHistoryStartDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = batchHistoryEndDate;

                    SqlDataAdapter adapt = new SqlDataAdapter();
                    DataTable dt = new DataTable();
                    adapt.SelectCommand = cmd;

                    newConn.Open();
                    adapt.Fill(dt);
                    newConn.Close();

                    dataGridView5.RowTemplate.Height = 30;
                    dataGridView5.DataSource = dt;
                    dataGridView5.Columns[0].Visible = false;
                    dataGridView5.Columns[1].HeaderText = "BATCH ID";
                    dataGridView5.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView5.Columns[1].Width = 130;
                    dataGridView5.Columns[2].HeaderText = "REGISTER NUMBER";
                    dataGridView5.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView5.Columns[2].Width = 50;
                    dataGridView5.Columns[3].Visible = false;
                    dataGridView5.Columns[4].Visible = false;
                    dataGridView5.Columns[5].HeaderText = "BATCH COUNT";
                    dataGridView5.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView5.Columns[5].Width = 70;
                    dataGridView5.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView5.Columns[6].HeaderText = "BATCH AMOUNT";
                    dataGridView5.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView5.Columns[6].Width = 100;
                    dataGridView5.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView5.Columns[6].DefaultCellStyle.Format = "c";
                    dataGridView5.Columns[7].Visible = false;
                    dataGridView5.Columns[8].HeaderText = "BATCH DATE AND TIME";
                    dataGridView5.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView5.Columns[8].Width = 150;
                    dataGridView5.Columns[9].HeaderText = "MANAGER ID";
                    dataGridView5.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView5.Columns[9].Width = 120;

                    for (int i = 0; i < dataGridView5.RowCount; i++)
                    {
                        totalBatchCount = totalBatchCount + Convert.ToInt64(dataGridView5.Rows[i].Cells[5].Value);
                        totalBatchAmount = totalBatchAmount + Convert.ToDouble(dataGridView5.Rows[i].Cells[6].Value);
                    }

                    lblTotalBatchCount.Text = totalBatchCount.ToString();
                    lblTotalBatchAmount.Text = string.Format("{0:c}", totalBatchAmount);

                    dataGridView5.ClearSelection();
                }
                catch
                {
                    MessageBox.Show("DB connection error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    newConn.Close();
                    return;
                }
            }
        }

        private void btnBatchHistoryClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDSRStartDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar11.Visible = true;
        }

        private void txtDSREndDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar12.Visible = true;
        }

        private void monthCalendar11_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtDSRStartDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar11.SelectionStart));
            monthCalendar11.Visible = false;
        }

        private void monthCalendar12_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtDSREndDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar12.SelectionStart));
            monthCalendar12.Visible = false;
        }

        private void btnCreateReport_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("Check_Initializing_DailySalesReport", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter CheckNumParam = cmd.Parameters.Add("@CheckNum", SqlDbType.TinyInt);
                CheckNumParam.Direction = ParameterDirection.Output;

                parentForm.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm.conn.Close();

                if(Convert.ToInt16(cmd.Parameters["@CheckNum"].Value) == 0)
                {
                    MessageBox.Show("Please initialize cash amount in your safe.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    AdjustCashInSafe adjustCashInSafeForm = new AdjustCashInSafe(0);
                    adjustCashInSafeForm.parentForm1 = this.parentForm;
                    adjustCashInSafeForm.parentForm2 = this;
                    adjustCashInSafeForm.ShowDialog();
                }
                else
                {
                    CreateDailySettlementReport createDailySalesReportform = new CreateDailySettlementReport();
                    createDailySalesReportform.parentForm1 = this.parentForm;
                    createDailySalesReportform.parentForm2 = this;
                    createDailySalesReportform.ShowDialog();
                }
                
            }
            catch
            {
                MessageBox.Show("DB connection error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (parentForm.conn.State == ConnectionState.Open)
                    parentForm.conn.Close();

                return;
            }
        }

        private void btnModifyReport_Click(object sender, EventArgs e)
        {
            if (dataGridView6.RowCount == 0)
                return;

            MessageBox.Show("Not available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        private void btnDeleteReport_Click(object sender, EventArgs e)
        {
            if (dataGridView6.RowCount == 0)
                return;

            if (dataGridView6.SelectedRows.Count <= 0)
                return;

            if (dataGridView6.SelectedRows.Count > 1)
            {
                MessageBox.Show("Please select only one report for deletion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Convert.ToString(dataGridView6.SelectedCells[20].Value) == "CASH INITIALIZATION")
            {
                MessageBox.Show("Cash initialization can not be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "Do you want to delete a selected report?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
            {
                try
                {
                    cmd = new SqlCommand("Delete_DailySettlementReport", parentForm.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@DSRSeqNo", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView6.SelectedCells[0].Value);
                    cmd.Parameters.Add("@DSRDeleteID", SqlDbType.NVarChar).Value = parentForm.employeeID.ToUpper();
                    cmd.Parameters.Add("@DSRDeleteDate", SqlDbType.DateTime).Value = DateTime.Now;

                    parentForm.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm.conn.Close();

                    MessageBox.Show("Successfully deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSettlementReportOK_Click(null, null);
                }
                catch
                {
                    MessageBox.Show("DB connection error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (parentForm.conn.State == ConnectionState.Open)
                        parentForm.conn.Close();

                    return;
                }
            }
        }

        private void btnAdjustCashInSafe_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("Check_Initializing_DailySalesReport", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter CheckNumParam = cmd.Parameters.Add("@CheckNum", SqlDbType.TinyInt);
                CheckNumParam.Direction = ParameterDirection.Output;

                parentForm.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm.conn.Close();

                if (Convert.ToInt16(cmd.Parameters["@CheckNum"].Value) == 0)
                {
                    MessageBox.Show("Please initialize cash amount in your safe.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    AdjustCashInSafe adjustCashInSafeForm = new AdjustCashInSafe(0);
                    adjustCashInSafeForm.parentForm1 = this.parentForm;
                    adjustCashInSafeForm.parentForm2 = this;
                    adjustCashInSafeForm.ShowDialog();
                }
                else
                {
                    AdjustCashInSafe adjustCashInSafeForm = new AdjustCashInSafe(1);
                    adjustCashInSafeForm.parentForm1 = this.parentForm;
                    adjustCashInSafeForm.parentForm2 = this;
                    adjustCashInSafeForm.ShowDialog();
                }

            }
            catch
            {
                MessageBox.Show("DB connection error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (parentForm.conn.State == ConnectionState.Open)
                    parentForm.conn.Close();

                return;
            }
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView6_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                btnViewReport_Click(null, null);
            }
        }

        public void btnSettlementReportOK_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("Show_RegisterDailySettlementReport", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = txtDSRStartDate.Text.Trim();
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = txtDSREndDate.Text.Trim();
                SqlDataAdapter adapt = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adapt.SelectCommand = cmd;

                parentForm.conn.Open();
                adapt.Fill(dt);
                parentForm.conn.Close();

                dataGridView6.RowTemplate.Height = 30;
                dataGridView6.DataSource = dt;
                dataGridView6.Columns[0].Visible = false;
                dataGridView6.Columns[1].HeaderText = "SC";
                dataGridView6.Columns[1].Width = 40;
                dataGridView6.Columns[2].HeaderText = "Date";
                dataGridView6.Columns[2].Width = 80;
                dataGridView6.Columns[3].HeaderText = "Day";
                dataGridView6.Columns[3].Width = 105;
                dataGridView6.Columns[4].HeaderText = "Card Payment";
                dataGridView6.Columns[4].Width = 90;
                dataGridView6.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView6.Columns[4].DefaultCellStyle.Format = "c";
                dataGridView6.Columns[5].HeaderText = "Card Settlement";
                dataGridView6.Columns[5].Width = 90;
                dataGridView6.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView6.Columns[5].DefaultCellStyle.Format = "c";
                dataGridView6.Columns[6].HeaderText = "Card Diff";
                dataGridView6.Columns[6].Width = 65;
                dataGridView6.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView6.Columns[6].DefaultCellStyle.Format = "c";
                dataGridView6.Columns[7].HeaderText = "Cash Payment";
                dataGridView6.Columns[7].Width = 90;
                dataGridView6.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView6.Columns[7].DefaultCellStyle.Format = "c";
                dataGridView6.Columns[8].HeaderText = "Cash Settlement";
                dataGridView6.Columns[8].Width = 90;
                dataGridView6.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView6.Columns[8].DefaultCellStyle.Format = "c";
                dataGridView6.Columns[9].HeaderText = "Cash Diff";
                dataGridView6.Columns[9].Width = 65;
                dataGridView6.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView6.Columns[9].DefaultCellStyle.Format = "c";
                dataGridView6.Columns[10].HeaderText = "Cash Withdrawal";
                dataGridView6.Columns[10].Width = 90;
                dataGridView6.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView6.Columns[10].DefaultCellStyle.Format = "c";
                dataGridView6.Columns[11].HeaderText = "Cash Deposit";
                dataGridView6.Columns[11].Width = 90;
                dataGridView6.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView6.Columns[11].DefaultCellStyle.Format = "c";
                dataGridView6.Columns[12].HeaderText = "Deposit Date";
                dataGridView6.Columns[12].Width = 80;
                dataGridView6.Columns[13].HeaderText = "Deposit Input Date";
                dataGridView6.Columns[13].Width = 130;
                dataGridView6.Columns[14].HeaderText = "Cash In Safe";
                dataGridView6.Columns[14].Width = 90;
                dataGridView6.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView6.Columns[14].DefaultCellStyle.Format = "c";
                dataGridView6.Columns[15].HeaderText = "Create Date";
                dataGridView6.Columns[15].Width = 130;
                dataGridView6.Columns[16].HeaderText = "Create ID";
                dataGridView6.Columns[16].Width = 85;
                dataGridView6.Columns[17].HeaderText = "Update Date";
                dataGridView6.Columns[17].Width = 130;
                dataGridView6.Columns[18].HeaderText = "Update ID";
                dataGridView6.Columns[18].Width = 85;
                dataGridView6.Columns[19].HeaderText = "Note";
                dataGridView6.Columns[19].Width = 120;
                dataGridView6.Columns[20].HeaderText = "Report Type";
                dataGridView6.Columns[20].Width = 155;


                if (parentForm.userLevel >= parentForm.SystemAdministratorLV)
                {
                    dataGridView6.Columns[21].HeaderText = "Del";
                    dataGridView6.Columns[21].Width = 40;
                    dataGridView6.Columns[22].HeaderText = "Delete Date";
                    dataGridView6.Columns[22].Width = 130;
                    dataGridView6.Columns[23].HeaderText = "Delete ID";
                    dataGridView6.Columns[23].Width = 85;
                }
                else
                {
                    dataGridView6.Columns[21].HeaderText = "Del";
                    dataGridView6.Columns[21].Width = 40;
                    dataGridView6.Columns[21].Visible = false;
                    dataGridView6.Columns[22].HeaderText = "Delete Date";
                    dataGridView6.Columns[22].Width = 130;
                    dataGridView6.Columns[22].Visible = false;
                    dataGridView6.Columns[23].HeaderText = "Delete ID";
                    dataGridView6.Columns[23].Width = 85;
                    dataGridView6.Columns[23].Visible = false;
                }

                dataGridView6.ClearSelection();

                lblReportCount.Text = dataGridView6.RowCount.ToString();

                if (dataGridView6.RowCount > 0)
                {
                    for (int i = dataGridView6.RowCount - 1; i >= 0; i--)
                    {
                        if (Convert.ToBoolean(dataGridView6.Rows[i].Cells[21].Value) == false)
                        {
                            lblCashInSafe.Text = string.Format("{0:c}", Convert.ToDouble(dataGridView6.Rows[i].Cells[14].Value));
                            break;
                        }
                    }
                }
                else
                {
                    lblCashInSafe.Text = "$0.00";
                }

                foreach (DataGridViewColumn column in dataGridView6.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch
            {
                MessageBox.Show("DB connection error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (parentForm.conn.State == ConnectionState.Open)
                    parentForm.conn.Close();

                return;
            }
        }

        private void btnSettlementReportClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int Checking_DuplicatedDate_DailySettlementReport(string checkingDate)
        {
            try
            {
                cmd = new SqlCommand("Checking_DuplicatedDate_DailySettlementReport", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CheckingDate", SqlDbType.NVarChar).Value = checkingDate;
                SqlParameter CheckNumParam = cmd.Parameters.Add("@CheckNum", SqlDbType.TinyInt);
                CheckNumParam.Direction = ParameterDirection.Output;

                parentForm.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm.conn.Close();

                if (cmd.Parameters["@CheckNum"].Value != DBNull.Value)
                {

                    return Convert.ToInt16(cmd.Parameters["@CheckNum"].Value);
                }
                else
                {
                    return -1;
                }


            }
            catch
            {
                MessageBox.Show("DB connection error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (parentForm.conn.State == ConnectionState.Open)
                    parentForm.conn.Close();

                return -1;
            }
        }

        public int Checking_DuplicatedDate_CashAdjustment(string checkingDate)
        {
            try
            {
                cmd = new SqlCommand("Checking_DuplicatedDate_CashAdjustment", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CheckingDate", SqlDbType.NVarChar).Value = checkingDate;
                SqlParameter CheckNumParam = cmd.Parameters.Add("@CheckNum", SqlDbType.TinyInt);
                CheckNumParam.Direction = ParameterDirection.Output;

                parentForm.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm.conn.Close();

                if (cmd.Parameters["@CheckNum"].Value != DBNull.Value)
                {

                    return Convert.ToInt16(cmd.Parameters["@CheckNum"].Value);
                }
                else
                {
                    return -1;
                }


            }
            catch
            {
                MessageBox.Show("DB connection error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (parentForm.conn.State == ConnectionState.Open)
                    parentForm.conn.Close();

                return -1;
            }
        }
    }
}