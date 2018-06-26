using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace Management
{
    public partial class ReceiptDetail : Form
    {
        public LogInManagements parentForm1;
        public RegisterHistory parentform2;
        public CustomerSales parentForm3;

        public int option = 0;

        public Font drvFont = new Font("Arial", 10, FontStyle.Bold);
        NumberFormatInfo nfi = new NumberFormatInfo();

        public Int64 receiptID;
        string payMethod;
        string returnPayment;
        int totalSold = 0;

        SqlConnection newConn;

        public ReceiptDetail(int opt)
        {
            InitializeComponent();
            option = opt;
        }

        private void ReceiptDetail_Load(object sender, EventArgs e)
        {
            nfi.CurrencySymbol = Application.CurrentCulture.NumberFormat.CurrencySymbol;
            nfi.CurrencyNegativePattern = 1;

            if (option == 0)
            {
                receiptID = Convert.ToInt64(parentform2.dataGridView1.SelectedCells[0].Value);
                lblReceiptID.Text = Convert.ToString(receiptID);
                lblStoreCode.Text = parentform2.dataGridView1.SelectedCells[1].Value.ToString();
                lblCashierID.Text = parentform2.dataGridView1.SelectedCells[2].Value.ToString();
                lblRegNum.Text = parentform2.dataGridView1.SelectedCells[3].Value.ToString();
                lblMemberCode.Text = parentform2.dataGridView1.SelectedCells[4].Value.ToString();
                lblMemberName.Text = parentform2.dataGridView1.SelectedCells[5].Value.ToString();
                lblPayMethod.Text = Payment_Methods(Convert.ToInt16(parentform2.dataGridView1.SelectedCells[6].Value));

                if (lblPayMethod.Text == "MULTI")
                    lblPayMethod.ForeColor = Color.Red;

                if (lblPayMethod.Text == "RETURN")
                {
                    switch (Return_Methods(receiptID))
                    {
                        case 0:
                            payMethod = "";
                            lblPayMethod.Text = payMethod;
                            break;
                        case 1:
                            payMethod = "RETURN\n" + "(BOTH)";
                            lblPayMethod.Text = payMethod;
                            break;
                        case 2:
                            payMethod = "RETURN\n" + "(REFUND)";
                            lblPayMethod.Text = payMethod;
                            break;
                        case 3:
                            payMethod = "RETURN\n" + "(STORE CREDIT)";
                            lblPayMethod.Text = payMethod;
                            break;
                        case 4:
                            payMethod = "";
                            lblPayMethod.Text = payMethod;
                            break;
                        default:
                            payMethod = "ERROR";
                            lblPayMethod.Text = payMethod;
                            break;
                    }
                }

                lblDate.Text = parentform2.dataGridView1.SelectedCells[7].Value.ToString();
                lblTime.Text = parentform2.dataGridView1.SelectedCells[8].Value.ToString();
                lblSubTotal.Text = parentform2.dataGridView1.SelectedCells[9].Value.ToString();
                lblGrandTotal.Text = parentform2.dataGridView1.SelectedCells[10].Value.ToString();
                lblTax.Text = parentform2.dataGridView1.SelectedCells[11].Value.ToString();
                lblTotalDiscount.Text = parentform2.dataGridView1.SelectedCells[12].Value.ToString();
                lblPay.Text = parentform2.dataGridView1.SelectedCells[14].Value.ToString();
                lblChange.Text = parentform2.dataGridView1.SelectedCells[15].Value.ToString();
                lblReceiptType.Text = parentform2.dataGridView1.SelectedCells[16].Value.ToString();
                lblReceiptStatus.Text = parentform2.dataGridView1.SelectedCells[17].Value.ToString();

                SqlCommand cmd = new SqlCommand("Show_Receipt_Detail", parentForm1.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = receiptID;
                DataTable dt = new DataTable();
                SqlDataAdapter adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                parentForm1.conn.Open();
                adapt.Fill(dt);
                parentForm1.conn.Close();

                dataGridView1.RowTemplate.Height = 35;
                dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].HeaderText = "BRAND";
                dataGridView1.Columns[7].Width = 90;
                dataGridView1.Columns[8].HeaderText = "NAME";
                dataGridView1.Columns[8].Width = 210;
                dataGridView1.Columns[9].HeaderText = "SIZE";
                dataGridView1.Columns[9].Width = 60;
                dataGridView1.Columns[10].HeaderText = "COLOR";
                dataGridView1.Columns[10].Width = 60;
                dataGridView1.Columns[11].HeaderText = "UPC";
                dataGridView1.Columns[11].Width = 115;
                dataGridView1.Columns[12].HeaderText = "RETAIL PRICE";
                dataGridView1.Columns[12].Width = 65;
                dataGridView1.Columns[12].DefaultCellStyle.FormatProvider = nfi;
                dataGridView1.Columns[12].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[13].HeaderText = "DISCOUNTED PRICE";
                dataGridView1.Columns[13].Width = 65;
                dataGridView1.Columns[13].DefaultCellStyle.FormatProvider = nfi;
                dataGridView1.Columns[13].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[14].HeaderText = "SOLD PRICE";
                dataGridView1.Columns[14].Width = 65;
                dataGridView1.Columns[14].DefaultCellStyle.FormatProvider = nfi;
                dataGridView1.Columns[14].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[15].HeaderText = "QTY";
                dataGridView1.Columns[15].Width = 30;
                dataGridView1.Columns[16].Visible = false;
                dataGridView1.Columns[17].Visible = false;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    totalSold = totalSold + Convert.ToInt16(dataGridView1.Rows[i].Cells[15].Value);
                }

                lblTotalSold.Text = Convert.ToString(totalSold);

                dataGridView1.ClearSelection();
            }
            else if (option == 1)
            {
                receiptID = Convert.ToInt64(parentForm3.dataGridView1.SelectedCells[0].Value);
                lblReceiptID.Text = Convert.ToString(receiptID);
                lblStoreCode.Text = parentForm3.dataGridView1.SelectedCells[1].Value.ToString();
                lblCashierID.Text = parentForm3.dataGridView1.SelectedCells[2].Value.ToString();
                lblRegNum.Text = parentForm3.dataGridView1.SelectedCells[3].Value.ToString();
                lblMemberCode.Text = parentForm3.dataGridView1.SelectedCells[4].Value.ToString();
                lblMemberName.Text = parentForm3.dataGridView1.SelectedCells[5].Value.ToString();
                lblPayMethod.Text = Payment_Methods(Convert.ToInt16(parentForm3.dataGridView1.SelectedCells[6].Value));

                if (lblPayMethod.Text == "MULTI")
                    lblPayMethod.ForeColor = Color.Red;

                if (lblPayMethod.Text == "RETURN")
                {
                    switch (Return_Methods(receiptID))
                    {
                        case 0:
                            lblPayMethod.Text = "";
                            break;
                        case 1:
                            lblPayMethod.Text = "RETURN\n" + "(BOTH)";
                            break;
                        case 2:
                            lblPayMethod.Text = "RETURN\n" + "(REFUND)";
                            break;
                        case 3:
                            lblPayMethod.Text = "RETURN\n" + "(STORE CREDIT)";
                            break;
                        case 4:
                            lblPayMethod.Text = "";
                            break;
                        default:
                            break;
                    }
                }

                //lblDate.Text = parentForm3.dataGridView1.SelectedCells[7].Value.ToString();
                lblDate.Text = string.Format("{0:MM/dd/yyyy}", parentForm3.dataGridView1.SelectedCells[7].Value);
                lblTime.Text = parentForm3.dataGridView1.SelectedCells[8].Value.ToString();
                lblSubTotal.Text = parentForm3.dataGridView1.SelectedCells[9].Value.ToString();
                lblGrandTotal.Text = parentForm3.dataGridView1.SelectedCells[10].Value.ToString();
                lblTax.Text = parentForm3.dataGridView1.SelectedCells[11].Value.ToString();
                lblTotalDiscount.Text = parentForm3.dataGridView1.SelectedCells[12].Value.ToString();
                lblPay.Text = parentForm3.dataGridView1.SelectedCells[14].Value.ToString();
                lblChange.Text = parentForm3.dataGridView1.SelectedCells[15].Value.ToString();
                lblReceiptType.Text = parentForm3.dataGridView1.SelectedCells[16].Value.ToString();
                lblReceiptStatus.Text = parentForm3.dataGridView1.SelectedCells[17].Value.ToString();

                /*if (lblStoreCode.Text == "TH")
                {
                    newConn = new SqlConnection(parentForm1.THCS_IP);
                }
                else if (lblStoreCode.Text == "OH")
                {
                    newConn = new SqlConnection(parentForm1.OHCS_IP);
                }
                else if (lblStoreCode.Text == "UM")
                {
                    newConn = new SqlConnection(parentForm1.UMCS_IP);
                }
                else if (lblStoreCode.Text == "CH")
                {
                    newConn = new SqlConnection(parentForm1.CHCS_IP);
                }
                else if (lblStoreCode.Text == "WM")
                {
                    newConn = new SqlConnection(parentForm1.WMCS_IP);
                }
                else if (lblStoreCode.Text == "CV")
                {
                    newConn = new SqlConnection(parentForm1.CVCS_IP);
                }
                else if (lblStoreCode.Text == "PW")
                {
                    newConn = new SqlConnection(parentForm1.PWCS_IP);
                }
                else if (lblStoreCode.Text == "WB")
                {
                    newConn = new SqlConnection(parentForm1.WBCS_IP);
                }
                else if (lblStoreCode.Text == "WD")
                {
                    newConn = new SqlConnection(parentForm1.WDCS_IP);
                }
                else if (lblStoreCode.Text == "PW")
                {
                    newConn = new SqlConnection(parentForm1.PWCS_IP);
                }
                else if (lblStoreCode.Text == "GB")
                {
                    newConn = new SqlConnection(parentForm1.GBCS_IP);
                }
                else if (lblStoreCode.Text == "BW")
                {
                    newConn = new SqlConnection(parentForm1.BWCS_IP);
                }*/

                newConn = new SqlConnection(parentForm1.OtherStoreConnectionString(lblStoreCode.Text.Trim().ToUpper()));

                try
                {
                    SqlCommand cmd = new SqlCommand("Show_Receipt_Detail", newConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = receiptID;
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd;

                    newConn.Open();
                    adapt.Fill(dt);
                    newConn.Close();

                    dataGridView1.RowTemplate.Height = 35;
                    dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].Visible = false;
                    dataGridView1.Columns[2].Visible = false;
                    dataGridView1.Columns[3].Visible = false;
                    dataGridView1.Columns[4].Visible = false;
                    dataGridView1.Columns[5].Visible = false;
                    dataGridView1.Columns[6].Visible = false;
                    dataGridView1.Columns[7].HeaderText = "BRAND";
                    dataGridView1.Columns[7].Width = 90;
                    dataGridView1.Columns[8].HeaderText = "NAME";
                    dataGridView1.Columns[8].Width = 210;
                    dataGridView1.Columns[9].HeaderText = "SIZE";
                    dataGridView1.Columns[9].Width = 60;
                    dataGridView1.Columns[10].HeaderText = "COLOR";
                    dataGridView1.Columns[10].Width = 60;
                    dataGridView1.Columns[11].HeaderText = "UPC";
                    dataGridView1.Columns[11].Width = 115;
                    dataGridView1.Columns[12].HeaderText = "RETAIL PRICE";
                    dataGridView1.Columns[12].Width = 65;
                    dataGridView1.Columns[12].DefaultCellStyle.FormatProvider = nfi;
                    dataGridView1.Columns[12].DefaultCellStyle.Format = "c";
                    dataGridView1.Columns[13].HeaderText = "DISCOUNTED PRICE";
                    dataGridView1.Columns[13].Width = 65;
                    dataGridView1.Columns[13].DefaultCellStyle.FormatProvider = nfi;
                    dataGridView1.Columns[13].DefaultCellStyle.Format = "c";
                    dataGridView1.Columns[14].HeaderText = "SOLD PRICE";
                    dataGridView1.Columns[14].Width = 65;
                    dataGridView1.Columns[14].DefaultCellStyle.FormatProvider = nfi;
                    dataGridView1.Columns[14].DefaultCellStyle.Format = "c";
                    dataGridView1.Columns[15].HeaderText = "QTY";
                    dataGridView1.Columns[15].Width = 30;
                    dataGridView1.Columns[16].Visible = false;
                    dataGridView1.Columns[17].Visible = false;

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        totalSold = totalSold + Convert.ToInt16(dataGridView1.Rows[i].Cells[15].Value);
                    }

                    lblTotalSold.Text = Convert.ToString(totalSold);

                    dataGridView1.ClearSelection();
                }
                catch
                {
                    MessageBox.Show("DB CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    newConn.Close();
                }
            }
        }

        public string Payment_Methods(int PayBy)
        {
            switch (PayBy)
            {
                case 0:
                    returnPayment = "RETURN";
                    return returnPayment;                    
                case 1:
                    returnPayment = "CASH";
                    return returnPayment;
                case 3:
                    returnPayment = "TERMINAL";
                    return returnPayment; 
                case 4:
                    returnPayment = "VISA";
                    return returnPayment; 
                case 5:
                    returnPayment = "DEBIT";
                    return returnPayment; 
                case 6:
                    returnPayment = "MASTER";
                    return returnPayment; 
                case 7:
                    returnPayment = "AMEX";
                    return returnPayment; 
                case 8:
                    returnPayment = "DISCOVER";
                    return returnPayment; 
                case 88:
                    returnPayment = "STORE CREDIT";
                    return returnPayment; 
                case 99:
                    returnPayment = "MULTI";
                    return returnPayment; 
                default:
                    return "ERROR";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblPayMethod_DoubleClick(object sender, EventArgs e)
        {
            if (lblPayMethod.Text == "MULTI")
            {
                MultiplePaymentDetail multiplePaymentDetailform = new MultiplePaymentDetail();
                multiplePaymentDetailform.parentForm1 = this.parentForm1;
                multiplePaymentDetailform.parentForm2 = this;
                multiplePaymentDetailform.ShowDialog();
            }
        }

        public int Return_Methods(Int64 rcpID)
        {
            if (option == 0)
            {
                SqlCommand cmd = new SqlCommand("Get_Return_Methods", parentForm1.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = rcpID;
                SqlParameter NumOfSC_Param = cmd.Parameters.Add("@NumOfStoreCredit", SqlDbType.Int);
                SqlParameter NumOfRefund_Param = cmd.Parameters.Add("@NumOfRefund", SqlDbType.Int);
                NumOfSC_Param.Direction = ParameterDirection.Output;
                NumOfRefund_Param.Direction = ParameterDirection.Output;

                parentForm1.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm1.conn.Close();

                if (Convert.ToInt16(cmd.Parameters["@NumOfStoreCredit"].Value) > 0 & Convert.ToInt16(cmd.Parameters["@NumOfRefund"].Value) > 0)
                {
                    return 1;
                }
                else if (Convert.ToInt16(cmd.Parameters["@NumOfStoreCredit"].Value) == 0 & Convert.ToInt16(cmd.Parameters["@NumOfRefund"].Value) > 0)
                {
                    return 2;
                }
                else if (Convert.ToInt16(cmd.Parameters["@NumOfStoreCredit"].Value) > 0 & Convert.ToInt16(cmd.Parameters["@NumOfRefund"].Value) == 0)
                {
                    return 3;
                }
                else if (Convert.ToInt16(cmd.Parameters["@NumOfStoreCredit"].Value) == 0 & Convert.ToInt16(cmd.Parameters["@NumOfRefund"].Value) == 0)
                {
                    return 4;
                }
                else
                {
                    return 0;
                }
            }
            else if (option == 1)
            {
                newConn = new SqlConnection(parentForm1.OtherStoreConnectionString(lblStoreCode.Text.Trim().ToUpper()));

                SqlCommand cmd = new SqlCommand("Get_Return_Methods", newConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = rcpID;
                SqlParameter NumOfSC_Param = cmd.Parameters.Add("@NumOfStoreCredit", SqlDbType.Int);
                SqlParameter NumOfRefund_Param = cmd.Parameters.Add("@NumOfRefund", SqlDbType.Int);
                NumOfSC_Param.Direction = ParameterDirection.Output;
                NumOfRefund_Param.Direction = ParameterDirection.Output;

                newConn.Open();
                cmd.ExecuteNonQuery();
                newConn.Close();

                if (Convert.ToInt16(cmd.Parameters["@NumOfStoreCredit"].Value) > 0 & Convert.ToInt16(cmd.Parameters["@NumOfRefund"].Value) > 0)
                {
                    return 1;
                }
                else if (Convert.ToInt16(cmd.Parameters["@NumOfStoreCredit"].Value) == 0 & Convert.ToInt16(cmd.Parameters["@NumOfRefund"].Value) > 0)
                {
                    return 2;
                }
                else if (Convert.ToInt16(cmd.Parameters["@NumOfStoreCredit"].Value) > 0 & Convert.ToInt16(cmd.Parameters["@NumOfRefund"].Value) == 0)
                {
                    return 3;
                }
                else if (Convert.ToInt16(cmd.Parameters["@NumOfStoreCredit"].Value) == 0 & Convert.ToInt16(cmd.Parameters["@NumOfRefund"].Value) == 0)
                {
                    return 4;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}