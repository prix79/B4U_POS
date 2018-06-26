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
    public partial class AdminRegisterHistory : Form
    {
        public LogInManagements parentForm;
        public SqlCommand cmd;
        //public SqlCommand cmd_Customer_Point;

        string receiptTransStartDate, receiptTransEndDate, receiptTransRegisterNum;
        double cashSales = 0, creditCardSales = 0, debitSales = 0, storeCreditSales = 0;
        double cashChangeFromMultiPay = 0;
        double cashSalesFromMultiPay = 0, creditSalesFromMultiPay = 0, debitSalesFromMultiPay = 0, storeCreditSalesFromMultiPay = 0;
        double tCreditSalesFromMultiPay = 0, visaSalesFromMultiPay = 0, masterSalesFromMultiPay = 0, amexSalesFromMultiPay = 0, discoverSalesFromMultiPay = 0;
        double returnAmount = 0, storeCreditRefundAmount = 0, cashRefundAmount = 0, creditRefundAmount = 0;
        double visaRefundAmount = 0, masterRefundAmount = 0, amexRefundAmount = 0, discoverRefundAmount = 0, tCreditRefundAmount = 0;
        double netSales = 0, totalGrossSales = 0;
        int numberOfTrans = 0;
        double everageNetSales = 0, everageSales = 0;

        string registerTransStartDate, registerTransEndDate, registerTransRegisterNum;
        double shortage = 0;
        double totalWithdrawal = 0;

        public AdminRegisterHistory()
        {
            InitializeComponent();
        }

        private void btnReceiptTransUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                DialogResult MyDialogResult;
                MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (MyDialogResult == DialogResult.Yes)
                {
                    try
                    {
                        btnReceiptTransUpdate.Enabled = false;

                        progressBar1.Minimum = 1;
                        progressBar1.Maximum = dataGridView1.RowCount;
                        progressBar1.Step = 1;
                        progressBar1.Visible = true;

                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            cmd = new SqlCommand("Update_AdminReceiptHeader", parentForm.conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                            cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                            cmd.Parameters.Add("@CashierID", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
                            cmd.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value);
                            cmd.Parameters.Add("@MemberID", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[4].Value);
                            cmd.Parameters.Add("@MemberName", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[5].Value);
                            cmd.Parameters.Add("@PayBy", SqlDbType.Int).Value = Convert.ToInt16(dataGridView1.Rows[i].Cells[6].Value);
                            cmd.Parameters.Add("@SellDate", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[7].Value);
                            cmd.Parameters.Add("@SellTime", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[8].Value);
                            cmd.Parameters.Add("@SubTotal", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[9].Value);
                            cmd.Parameters.Add("@GrandTotal", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[10].Value);
                            cmd.Parameters.Add("@Tax", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[11].Value);
                            cmd.Parameters.Add("@Discount", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[12].Value);
                            cmd.Parameters.Add("@MemberPoints", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[13].Value);
                            cmd.Parameters.Add("@Pay", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[14].Value);
                            cmd.Parameters.Add("@Change", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[15].Value);
                            cmd.Parameters.Add("@ReceiptType", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[16].Value);
                            cmd.Parameters.Add("@ReceiptStatus", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[17].Value);

                            parentForm.conn.Open();
                            cmd.ExecuteNonQuery();
                            parentForm.conn.Close();

                            cmd.CommandText = "Update_AdminReceiptBody";
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                            cmd.Parameters.Add("@SellDate", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[7].Value);
                            cmd.Parameters.Add("@SellTime", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[8].Value);

                            parentForm.conn.Open();
                            cmd.ExecuteNonQuery();
                            parentForm.conn.Close();

                            cmd.CommandText = "Update_AdminReceiptMultiPay";
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                            cmd.Parameters.Add("@SellDate", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[7].Value);
                            cmd.Parameters.Add("@SellTime", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[8].Value);

                            parentForm.conn.Open();
                            cmd.ExecuteNonQuery();
                            parentForm.conn.Close();

                            cmd.CommandText = "Update_AdminRefCreditTransaction";
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                            cmd.Parameters.Add("@IssueDate", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[7].Value);
                            cmd.Parameters.Add("@IssueTime", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[8].Value);

                            parentForm.conn.Open();
                            cmd.ExecuteNonQuery();
                            parentForm.conn.Close();

                            cmd.CommandText = "Update_AdminRefund";
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                            cmd.Parameters.Add("@Amount", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[10].Value);
                            cmd.Parameters.Add("@RefundDate", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[7].Value);
                            cmd.Parameters.Add("@RefundTime", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[8].Value);

                            parentForm.conn.Open();
                            cmd.ExecuteNonQuery();
                            parentForm.conn.Close();

                            cmd.CommandText = "Update_AdminStoreCredit";
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                            cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[7].Value);
                            cmd.Parameters.Add("@ExpDate", SqlDbType.NVarChar).Value = string.Format("{0:d}", (Convert.ToDateTime(dataGridView1.Rows[i].Cells[7].Value)).AddYears(1));

                            parentForm.conn.Open();
                            cmd.ExecuteNonQuery();
                            parentForm.conn.Close();

                            progressBar1.PerformStep();
                            Application.DoEvents();
                        }

                        MessageBox.Show("SUCCESSFULLY UPDATED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        progressBar1.Visible = false;
                        progressBar1.Value = 1;
                        btnReceiptTransOK_Click(null, null);
                        btnReceiptTransUpdate.Enabled = true;
                    }
                    catch
                    {
                        parentForm.conn.Close();
                        MessageBox.Show("EXCEPTION ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnReceiptTransUpdate.Enabled = true;
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("NO ITEM", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnReceiptTransDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                DialogResult MyDialogResult;
                MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (MyDialogResult == DialogResult.Yes)
                {
                    int cnt = 0;
                    progressBar1.Minimum = 1;
                    progressBar1.Maximum = dataGridView1.RowCount;
                    progressBar1.Step = 1;
                    progressBar1.Visible = true;

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        if (dataGridView1.Rows[i].Selected == true)
                        {
                            if (Convert.ToString(dataGridView1.Rows[i].Cells[4].Value) == "101" | Convert.ToString(dataGridView1.Rows[i].Cells[4].Value) == "0" | Convert.ToString(dataGridView1.Rows[i].Cells[4].Value) == "")
                            {
                                cmd = new SqlCommand("Delete_AdminReceiptHeader", parentForm.conn);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);

                                parentForm.conn.Open();
                                cmd.ExecuteNonQuery();
                                parentForm.conn.Close();

                                cnt = cnt + 1;
                            }
                            else
                            {
                                cmd = new SqlCommand("Delete_AdminReceiptHeader", parentForm.conn);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);

                                //cmd_Customer_Point = new SqlCommand("Calculate_Customer_Points", parentForm.conn);
                                //cmd_Customer_Point.CommandType = CommandType.StoredProcedure;
                                //cmd_Customer_Point.Parameters.Clear();
                                //cmd_Customer_Point.Parameters.Add("@MemberID", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[4].Value);
                                //cmd_Customer_Point.Parameters.Add("@Redeem", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[13].Value);
                                //cmd_Customer_Point.Parameters.Add("@NewPoints", SqlDbType.Money).Value = 0;

                                parentForm.conn.Open();
                                cmd.ExecuteNonQuery();
                                //cmd_Customer_Point.ExecuteNonQuery();
                                parentForm.conn.Close();

                                cnt = cnt + 1;
                            }
                        }

                        progressBar1.PerformStep();
                    }

                    if (cnt == 0)
                    {
                        MessageBox.Show("NO ITEM SELECTED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        progressBar1.Visible = false;
                        progressBar1.Value = 1;
                        return;
                    }
                    else
                    {
                        MessageBox.Show("SUCCESSFULLY DELETED " + Convert.ToString(cnt) + " RECEIPT(S)", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        progressBar1.Visible = false;
                        progressBar1.Value = 1;
                        btnReceiptTransOK_Click(null, null);
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("NO ITEM", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void AdminRegisterHistory_Load(object sender, EventArgs e)
        {
            txtReceiptTransStart.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            txtReceiptTransEnd.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            cmbReceiptTransRegisterNum.SelectedIndex = 0;

            txtRegisterTransStart.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            txtRegisterTransEnd.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            cmbRegisterTransRegisterNum.SelectedIndex = 0;
        }

        private void btnReceiptTransOK_Click(object sender, EventArgs e)
        {
            cashSales = 0; creditCardSales = 0; debitSales = 0; storeCreditSales = 0;
            cashChangeFromMultiPay = 0;
            cashSalesFromMultiPay = 0; creditSalesFromMultiPay = 0; debitSalesFromMultiPay = 0; storeCreditSalesFromMultiPay = 0;
            tCreditSalesFromMultiPay = 0; visaSalesFromMultiPay = 0; masterSalesFromMultiPay = 0; amexSalesFromMultiPay = 0; discoverSalesFromMultiPay = 0;
            returnAmount = 0; storeCreditRefundAmount = 0; cashRefundAmount = 0; creditRefundAmount = 0;
            visaRefundAmount = 0; masterRefundAmount = 0; amexRefundAmount = 0; discoverRefundAmount = 0; tCreditRefundAmount = 0;
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
                else if (Convert.ToString(dataGridView1.Rows[i].Cells[6].Value) == "3" | Convert.ToString(dataGridView1.Rows[i].Cells[6].Value) == "4" | Convert.ToString(dataGridView1.Rows[i].Cells[6].Value) == "6" | Convert.ToString(dataGridView1.Rows[i].Cells[6].Value) == "7" | Convert.ToString(dataGridView1.Rows[i].Cells[6].Value) == "8")
                {
                    creditCardSales = creditCardSales + Convert.ToDouble(dataGridView1.Rows[i].Cells[10].Value);
                }
                else if (Convert.ToString(dataGridView1.Rows[i].Cells[6].Value) == "5")
                {
                    debitSales = debitSales + Convert.ToDouble(dataGridView1.Rows[i].Cells[10].Value);
                }
                else if (Convert.ToString(dataGridView1.Rows[i].Cells[6].Value) == "88")
                {
                    storeCreditSales = storeCreditSales + Convert.ToDouble(dataGridView1.Rows[i].Cells[10].Value);
                }
                else if (Convert.ToString(dataGridView1.Rows[i].Cells[6].Value) == "0")
                {
                    returnAmount = returnAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[10].Value);
                }

                if (Convert.ToString(dataGridView1.Rows[i].Cells[6].Value) == "99")
                {
                    cashChangeFromMultiPay = cashChangeFromMultiPay + Convert.ToDouble(dataGridView1.Rows[i].Cells[15].Value);
                }

                netSales = netSales + Convert.ToDouble(dataGridView1.Rows[i].Cells[9].Value);
                totalGrossSales = totalGrossSales + Convert.ToDouble(dataGridView1.Rows[i].Cells[10].Value);
            }

            cmd.CommandText = "Get_Sales_From_MultiPay_and_Refund";
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

            creditCardSales = creditCardSales + tCreditSalesFromMultiPay + visaSalesFromMultiPay + masterSalesFromMultiPay + amexSalesFromMultiPay + discoverSalesFromMultiPay;
            creditRefundAmount = visaRefundAmount + masterRefundAmount + amexRefundAmount + discoverRefundAmount + tCreditRefundAmount;
            debitSales = debitSales + debitSalesFromMultiPay;
            storeCreditSales = storeCreditSales + storeCreditSalesFromMultiPay;

            numberOfTrans = dataGridView1.Rows.Count;
            everageNetSales = netSales / numberOfTrans;
            everageSales = totalGrossSales / numberOfTrans;

            lblCashSales.Text = string.Format("{0:$0.00}", cashSales + cashSalesFromMultiPay - cashChangeFromMultiPay - cashRefundAmount);
            lblCreditCardSales.Text = string.Format("{0:$0.00}", creditCardSales - creditRefundAmount);
            lblDebitSales.Text = string.Format("{0:$0.00}", debitSales);
            lblStoreCreditSales.Text = string.Format("{0:$0.00}", storeCreditSales);
            lblReturn.Text = string.Format("{0:$0.00}", -returnAmount);
            lblStoreCreditRefund.Text = string.Format("{0:$0.00}", -returnAmount - cashRefundAmount - creditRefundAmount);
            lblCashRefund.Text = string.Format("{0:$0.00}", cashRefundAmount);
            lblCreditRefund.Text = string.Format("{0:$0.00}", creditRefundAmount);
            lblNetSale.Text = string.Format("{0:$0.00}", netSales);
            lblTotalGrossSale.Text = string.Format("{0:$0.00}", totalGrossSales);
            lblNumberOfTrans.Text = Convert.ToString(numberOfTrans);
            lblEverageNetSales.Text = string.Format("{0:$0.00}", everageNetSales);
            lblEverageSales.Text = string.Format("{0:$0.00}", everageSales);

            if (dataGridView1.RowCount > 0)
                dataGridView1.Rows[0].Selected = false;
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
            cmd.CommandType = CommandType.StoredProcedure;
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
            dataGridView2.Columns[5].HeaderText = "CASH SALES";
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

            lblShortage.Text = string.Format("{0:$0.00}", shortage);
            lblTotalWithdrawal.Text = string.Format("{0:$0.00}", totalWithdrawal);

            if (dataGridView2.RowCount > 0)
                dataGridView2.Rows[0].Selected = false;
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

        private void txtRegisterTransStart_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar3.Visible = true;
        }

        private void txtRegisterTransEnd_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar4.Visible = true;
        }
    }
}