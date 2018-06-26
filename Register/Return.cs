// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 02-06-2018
// ***********************************************************************
// <copyright file="Return.cs" company="Beauty4u">
//     Copyright © Beauty4u 2009
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using apiAlias = StatusAPI;
//using PSCharge;
using System.Globalization;

/// <summary>
/// The Register namespace.
/// </summary>
namespace Register
{
    /// <summary>
    /// Class Return.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class Return : Form
    {
        /// <summary>
        /// The parent form
        /// </summary>
        public MainForm parentForm;
        /// <summary>
        /// The user
        /// </summary>
        string user;
        /// <summary>
        /// The redeem
        /// </summary>
        double redeem = 0;

        /// <summary>
        /// The nfi
        /// </summary>
        NumberFormatInfo nfi = new NumberFormatInfo();

        /// <summary>
        /// The option
        /// </summary>
        public int option = 0;

        /// <summary>
        /// The check date
        /// </summary>
        bool checkDate = false;
        /// <summary>
        /// The credit pay by
        /// </summary>
        int creditPayBy;

        /// <summary>
        /// The brand
        /// </summary>
        /// <summary>
        /// The name
        /// </summary>
        /// <summary>
        /// The maximum qty
        /// </summary>
        /// <summary>
        /// The upc
        /// </summary>
        /// <summary>
        /// The index
        /// </summary>
        /// <summary>
        /// The itm GP1
        /// </summary>
        /// <summary>
        /// The itm GP2
        /// </summary>
        /// <summary>
        /// The itm GP3
        /// </summary>
        /// <summary>
        /// The size
        /// </summary>
        /// <summary>
        /// The color
        /// </summary>
        /// <summary>
        /// The sell date
        /// </summary>
        /// <summary>
        /// The sell time
        /// </summary>
        string brand, name, maxQty, upc, index, ItmGp1, ItmGp2, ItmGp3, size, color, sellDate, sellTime;
        /// <summary>
        /// The base price
        /// </summary>
        /// <summary>
        /// The discount price
        /// </summary>
        /// <summary>
        /// The price
        /// </summary>
        double basePrice, discountPrice, price;
        /// <summary>
        /// The original grand total
        /// </summary>
        double originalGrandTotal = 0;

        /// <summary>
        /// The store code
        /// </summary>
        string StoreCode;
        /// <summary>
        /// The cashier identifier
        /// </summary>
        string CashierID;
        /// <summary>
        /// The register number
        /// </summary>
        string RegisterNum;
        /// <summary>
        /// The member identifier
        /// </summary>
        string MemberID = "101";
        /// <summary>
        /// The member name
        /// </summary>
        string MemberName = "WALK INS";
        /// <summary>
        /// The pay by
        /// </summary>
        int PayBy;
        /// <summary>
        /// The new sell date
        /// </summary>
        string NewSellDate;
        /// <summary>
        /// The new sell time
        /// </summary>
        string NewSellTime;
        /// <summary>
        /// The sub total
        /// </summary>
        double SubTotal;
        /// <summary>
        /// The tax
        /// </summary>
        double Tax;
        /// <summary>
        /// The member points
        /// </summary>
        double MemberPoints;
        /// <summary>
        /// The n grand total
        /// </summary>
        double nGrandTotal;
        /// <summary>
        /// The receipt type
        /// </summary>
        string ReceiptType;
        /// <summary>
        /// The receipt status
        /// </summary>
        string ReceiptStatus;

        /// <summary>
        /// The itm brand
        /// </summary>
        string ItmBrand;
        /// <summary>
        /// The itm name
        /// </summary>
        string ItmName;
        /// <summary>
        /// The itm group1
        /// </summary>
        string ItmGroup1;
        /// <summary>
        /// The itm group2
        /// </summary>
        string ItmGroup2;
        /// <summary>
        /// The itm group3
        /// </summary>
        string ItmGroup3;
        /// <summary>
        /// The itm upc
        /// </summary>
        string ItmUpc;
        /// <summary>
        /// The itm base price
        /// </summary>
        double ItmBasePrice;
        /// <summary>
        /// The itm discount price
        /// </summary>
        double ItmDiscountPrice;
        /// <summary>
        /// The itm price
        /// </summary>
        double ItmPrice;
        /// <summary>
        /// The itm size
        /// </summary>
        string ItmSize;
        /// <summary>
        /// The itm color
        /// </summary>
        string ItmColor;
        /// <summary>
        /// The itm qty
        /// </summary>
        string ItmQty;

        /// <summary>
        /// The remaining points
        /// </summary>
        double remainingPoints = 0;
        /// <summary>
        /// The points back
        /// </summary>
        bool pointsBack = false;
        /// <summary>
        /// The points back amount
        /// </summary>
        double pointsBackAmount = 0;

        /// <summary>
        /// The r count
        /// </summary>
        public int rCnt = 0;

        /// <summary>
        /// The amount
        /// </summary>
        /// <summary>
        /// The balance
        /// </summary>
        double amount, balance;
        /// <summary>
        /// The start date
        /// </summary>
        /// <summary>
        /// The exp date
        /// </summary>
        /// <summary>
        /// The refund method
        /// </summary>
        /// <summary>
        /// The refund date
        /// </summary>
        /// <summary>
        /// The refund time
        /// </summary>
        /// <summary>
        /// The refund type
        /// </summary>
        string startDate, expDate, refundMethod, refundDate, refundTime, refundType;

        /// <summary>
        /// The store credit print
        /// </summary>
        PrintDocument storeCreditPrint;
        /// <summary>
        /// The cash refund print
        /// </summary>
        PrintDocument cashRefundPrint;
        /// <summary>
        /// The cash signiture print
        /// </summary>
        PrintDocument cashSigniturePrint;
        /// <summary>
        /// The credit refund print
        /// </summary>
        PrintDocument creditRefundPrint;
        /// <summary>
        /// The credit signiture print
        /// </summary>
        PrintDocument creditSigniturePrint;
        /// <summary>
        /// The credit terminal print
        /// </summary>
        PrintDocument creditTerminalPrint;
        /// <summary>
        /// The print font
        /// </summary>
        /// <summary>
        /// The print font2
        /// </summary>
        /// <summary>
        /// The print font3
        /// </summary>
        /// <summary>
        /// The print font4
        /// </summary>
        /// <summary>
        /// The print bold font
        /// </summary>
        /// <summary>
        /// The print bold font2
        /// </summary>
        /// <summary>
        /// The barcode font
        /// </summary>
        Font printFont, printFont2, printFont3, printFont4, printFont5, printBoldFont, printBoldFont2, barcodeFont;
        /// <summary>
        /// The print itm count
        /// </summary>
        int printItmCount;
        /// <summary>
        /// The mp handle
        /// </summary>
        Int32 mpHandle;
        /// <summary>
        /// The is finish
        /// </summary>
        Boolean isFinish;
        /// <summary>
        /// The cancel error
        /// </summary>
        Boolean cancelErr;
        /// <summary>
        /// The print status
        /// </summary>
        int printStatus;

        /// <summary>
        /// The connection
        /// </summary>
        SqlConnection connection = new SqlConnection();
        /// <summary>
        /// The reference receipt identifier
        /// </summary>
        /// <summary>
        /// The receipt identifier
        /// </summary>
        /// <summary>
        /// The store credit identifier
        /// </summary>
        /// <summary>
        /// The refund identifier
        /// </summary>
        Int64 refReceiptID, ReceiptID, StoreCreditID, RefundID;

        /// <summary>
        /// The return table
        /// </summary>
        DataTable returnTable = new DataTable();

        /// <summary>
        /// The m type
        /// </summary>
        string mType;

        /// <summary>
        /// The o amount
        /// </summary>
        double oAmount = 0;
        /// <summary>
        /// The o payment identifier
        /// </summary>
        string oPaymentID;
        /// <summary>
        /// The o order identifier
        /// </summary>
        string oOrderID;
        //public string rExternalPaymentID;
        //public string rReferenceID;
        //public Int64 rCreatedTime;
        //public string rSellDate;
        //public string rSellTime;
        //public string rCardType;
        //public string rEntryType;
        //public string rTransactionLabel;
        /// <summary>
        /// The o last4
        /// </summary>
        string oLast4;
        //public string rCardHolderName;
        //public string rAuthCode;
        //public string rAID = "N/A";
        //public string rCVM;

        /// <summary>
        /// The r amount
        /// </summary>
        double rAmount = 0;

        /// <summary>
        /// The cp amount
        /// </summary>
        public double CPAmount = 0;
        /// <summary>
        /// The c pcredit identifier
        /// </summary>
        public string CPcreditID= null;
        /// <summary>
        /// The c porder identifier
        /// </summary>
        public string CPorderID;
        /// <summary>
        /// The c pexternal payment identifier
        /// </summary>
        public string CPexternalPaymentID;
        /// <summary>
        /// The c preference identifier
        /// </summary>
        public string CPreferenceID;
        /// <summary>
        /// The c pcreated time
        /// </summary>
        public Int64 CPcreatedTime;
        /// <summary>
        /// The c psell date
        /// </summary>
        public string CPsellDate;
        /// <summary>
        /// The c psell time
        /// </summary>
        public string CPsellTime;
        /// <summary>
        /// The c pcard type
        /// </summary>
        public string CPcardType;
        /// <summary>
        /// The c pentry type
        /// </summary>
        public string CPentryType;
        /// <summary>
        /// The c ptransaction label
        /// </summary>
        public string CPtransactionLabel;
        /// <summary>
        /// The c plast4
        /// </summary>
        public string CPlast4;
        /// <summary>
        /// The c pcard holder name
        /// </summary>
        public string CPcardHolderName;
        /// <summary>
        /// The c pauth code
        /// </summary>
        public string CPauthCode;
        /// <summary>
        /// The cpaid
        /// </summary>
        public string CPAID = "N/A";
        /// <summary>
        /// The c PCVM
        /// </summary>
        public string CPcvm;

        /// <summary>
        /// The manager identifier
        /// </summary>
        public string managerID;
        /// <summary>
        /// The witness identifier
        /// </summary>
        public string witnessID;
        /// <summary>
        /// The refund witness identifier
        /// </summary>
        string refundWitnessID;
        /// <summary>
        /// The bool second authentication
        /// </summary>
        public bool boolSecondAuthentication = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="Return"/> class.
        /// </summary>
        /// <param name="conn">The connection.</param>
        /// <param name="opt">The opt.</param>
        /// <param name="mID">The m identifier.</param>
        public Return(SqlConnection conn, int opt, string mID)
        {
            connection = conn;
            managerID = mID;
            InitializeComponent();

            option = opt;
        }

        /// <summary>
        /// Handles the Load event of the Return control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Return_Load(object sender, EventArgs e)
        {
            ConnectStatusLabel.Text = parentForm.cloverDeviceConnection;

            nfi.CurrencySymbol = Application.CurrentCulture.NumberFormat.CurrencySymbol;
            nfi.CurrencyNegativePattern = 1;

            returnTable.Columns.Add("Brand");
            returnTable.Columns.Add("Name");
            returnTable.Columns.Add("Qty");
            returnTable.Columns.Add("Base Price");
            returnTable.Columns.Add("Discount Price");
            returnTable.Columns.Add("Price");
            returnTable.Columns.Add("UPC");
            returnTable.Columns.Add("Index");
            returnTable.Columns.Add("ItmGroup1");
            returnTable.Columns.Add("ItmGroup2");
            returnTable.Columns.Add("ItmGroup3");
            returnTable.Columns.Add("Size");
            returnTable.Columns.Add("Color");
            returnTable.Columns.Add("SellDate");
            returnTable.Columns.Add("SellTime");
            returnTable.Columns.Add("Max Qty");

            if (parentForm.cashRegisterNum == "REG01")
            {
                user = parentForm.user1;
            }
            else if (parentForm.cashRegisterNum == "REG02")
            {
                user = parentForm.user2;
            }
            else if (parentForm.cashRegisterNum == "REG03")
            {
                user = parentForm.user3;
            }
            else if (parentForm.cashRegisterNum == "REG04")
            {
                user = parentForm.user4;
            }

            if (option == 1)
            {
                txtReceiptID.Enabled = false;
                btnInput.Enabled = false;
                btnSearch.Enabled = false;
                dataGridView1.Enabled = false;
                btnSelectAll.Enabled = false;
                btnAdd.Enabled = false;
                btnReset.Enabled = false;
                lblGrandTotal.Text = "$0.00";

                if (parentForm.dataGridView1.RowCount < 1)
                {
                    return;
                }

                for (int i = 0; i < parentForm.dataGridView1.RowCount; i++)
                {
                    Set_Variables(i);
                    returnTable.Rows.Add(brand, name, maxQty, basePrice, discountPrice, price, upc, index, ItmGp1, ItmGp2, ItmGp3, size, color, sellDate, sellTime, maxQty);
                }

                dataGridView2.DataSource = returnTable;
                dataGridView2.Columns[0].HeaderText = "Brand";
                dataGridView2.Columns[0].Width = 80;
                dataGridView2.Columns[1].HeaderText = "Name";
                dataGridView2.Columns[1].Width = 150;
                dataGridView2.Columns[2].HeaderText = "Qty";
                dataGridView2.Columns[2].Width = 30;
                dataGridView2.Columns[3].HeaderText = "Base Price";
                dataGridView2.Columns[3].DefaultCellStyle.Format = "c";
                dataGridView2.Columns[3].Width = 55;
                dataGridView2.Columns[4].HeaderText = "Discount Price";
                dataGridView2.Columns[4].DefaultCellStyle.Format = "c";
                dataGridView2.Columns[4].Width = 55;
                dataGridView2.Columns[5].HeaderText = "Price";
                dataGridView2.Columns[5].DefaultCellStyle.Format = "c";
                dataGridView2.Columns[5].Width = 55;

                SubTotal = 0;
                Tax = 0;
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    SubTotal = SubTotal + Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value);
                }
                Tax = Math.Round(SubTotal * parentForm.storeTaxRate, 2, MidpointRounding.AwayFromZero);
                nGrandTotal = SubTotal + Tax;
                lblNewSubTotal.Text = string.Format("{0:$0.00}", SubTotal);
                lblNewTax.Text = string.Format("{0:$0.00}", Tax);
                lblNewGrandTotal.Text = string.Format("{0:$0.00}", nGrandTotal);

                //DeviceCurrentStatus.Visible = true;
            }
            else
            {
                btnInput.Select();
                btnInput.Focus();
                //txtReceiptID.Select();
                //txtReceiptID.Focus();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnInput control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnInput_Click(object sender, EventArgs e)
        {
            InputReceiptID inputReceiptIDForm = new InputReceiptID();
            inputReceiptIDForm.parentForm = this;
            inputReceiptIDForm.ShowDialog();
        }

        /// <summary>
        /// Handles the Click event of the btnClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (option == 2)
            {
            }
            else
            {
                this.Close();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnSearch_Click(object sender, EventArgs e)
        {
            returnTable.Clear();
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;

            if (Int64.TryParse(txtReceiptID.Text, out refReceiptID))
            {
                SqlCommand cmd_Count = new SqlCommand("Get_Item_Count_From_ReceiptBody", connection);
                cmd_Count.CommandType = CommandType.StoredProcedure;
                cmd_Count.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = refReceiptID;
                SqlParameter ItmCount_Param = cmd_Count.Parameters.Add("@ItmCount", SqlDbType.Int);
                ItmCount_Param.Direction = ParameterDirection.Output;
                connection.Open();
                cmd_Count.ExecuteNonQuery();
                connection.Close();
                int ItmCount = Convert.ToInt16(cmd_Count.Parameters["@ItmCount"].Value);

                if (ItmCount == 0)
                {
                    lblReceiptID.Text = "";
                    lblMemberName.Text = "";
                    lblDate.Text = "";
                    lblSubTotal.Text = "";
                    lblTax.Text = "";
                    lblGrandTotal.Text = "";

                    radioBtnCash.Checked = true;
                    radioBtnCash.Enabled = false;
                    radioBtnCredit.Enabled = false;
                    btnRefund.Enabled = false;

                    MyMessageBox.ShowBox("NO RECORD", "ERROR");
                    //MessageBox.Show("No Record", "Error");
                    txtReceiptID.SelectAll();
                    return;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dataGridView1.DataSource = null;

                    for (int i = 1; i <= ItmCount; i++)
                    {
                        SqlCommand cmd = new SqlCommand("Show_ReceiptBody_By_ReceiptID", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = refReceiptID;
                        cmd.Parameters.Add("@ItmIndex", SqlDbType.Int).Value = i;
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;

                        connection.Open();
                        adapter.Fill(dt);
                        connection.Close();

                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns[0].HeaderText = "Brand";
                        dataGridView1.Columns[0].Width = 80;
                        dataGridView1.Columns[1].HeaderText = "Name";
                        dataGridView1.Columns[1].Width = 150;
                        dataGridView1.Columns[2].HeaderText = "Qty";
                        dataGridView1.Columns[2].Width = 30;
                        dataGridView1.Columns[3].HeaderText = "Base Price";
                        dataGridView1.Columns[3].DefaultCellStyle.Format = "c";
                        dataGridView1.Columns[3].Width = 55;
                        dataGridView1.Columns[3].DefaultCellStyle.FormatProvider = nfi;
                        dataGridView1.Columns[4].HeaderText = "Discount Price";
                        dataGridView1.Columns[4].DefaultCellStyle.Format = "c";
                        dataGridView1.Columns[4].Width = 55;
                        dataGridView1.Columns[4].DefaultCellStyle.FormatProvider = nfi;
                        dataGridView1.Columns[5].HeaderText = "Price";
                        dataGridView1.Columns[5].DefaultCellStyle.Format = "c";
                        dataGridView1.Columns[5].Width = 55;
                        dataGridView1.Columns[5].DefaultCellStyle.FormatProvider = nfi;
                        //dataGridView1.Columns[6].HeaderText = "Tax";
                        //dataGridView1.Columns[6].Width = 55;
                        //dataGridView1.Columns[6].DefaultCellStyle.Format = "c";
                    }

                    SqlCommand cmd_ReceiptHeader_Info = new SqlCommand("Get_ReceiptHeader_Info", connection);
                    cmd_ReceiptHeader_Info.CommandType = CommandType.StoredProcedure;
                    cmd_ReceiptHeader_Info.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = refReceiptID;
                    SqlParameter MemberID_Param = cmd_ReceiptHeader_Info.Parameters.Add("@MemberID", SqlDbType.NVarChar, 50);
                    SqlParameter MemberName_Param = cmd_ReceiptHeader_Info.Parameters.Add("@MemberName", SqlDbType.NVarChar, 50);
                    SqlParameter PayBy_Param = cmd_ReceiptHeader_Info.Parameters.Add("@PayBy", SqlDbType.Int);
                    SqlParameter SellDate_Param = cmd_ReceiptHeader_Info.Parameters.Add("@SellDate", SqlDbType.NVarChar, 20);
                    SqlParameter SellTime_Param = cmd_ReceiptHeader_Info.Parameters.Add("@SellTime", SqlDbType.NVarChar, 20);
                    SqlParameter SubTotal_Param = cmd_ReceiptHeader_Info.Parameters.Add("@SubTotal", SqlDbType.Money);
                    SqlParameter Tax_Param = cmd_ReceiptHeader_Info.Parameters.Add("@Tax", SqlDbType.Money);
                    SqlParameter GrandTotal_Param = cmd_ReceiptHeader_Info.Parameters.Add("@GrandTotal", SqlDbType.Money);
                    MemberID_Param.Direction = ParameterDirection.Output;
                    MemberName_Param.Direction = ParameterDirection.Output;
                    PayBy_Param.Direction = ParameterDirection.Output;
                    SellDate_Param.Direction = ParameterDirection.Output;
                    SellTime_Param.Direction = ParameterDirection.Output;
                    SubTotal_Param.Direction = ParameterDirection.Output;
                    Tax_Param.Direction = ParameterDirection.Output;
                    GrandTotal_Param.Direction = ParameterDirection.Output;

                    connection.Open();
                    cmd_ReceiptHeader_Info.ExecuteNonQuery();
                    connection.Close();

                    PayBy = Convert.ToInt16(cmd_ReceiptHeader_Info.Parameters["@PayBy"].Value);

                    lblReceiptID.Text = Convert.ToString(refReceiptID);
                    MemberID = cmd_ReceiptHeader_Info.Parameters["@MemberID"].Value.ToString();
                    MemberName = cmd_ReceiptHeader_Info.Parameters["@MemberName"].Value.ToString();

                    lblMemberName.Text = MemberName;

                    if (cmd_ReceiptHeader_Info.Parameters["@SellDate"].Value.ToString() == string.Format("{0:MM/dd/yyyy}", DateTime.Today))
                    {
                        checkDate = true;
                        lblDate.Text = cmd_ReceiptHeader_Info.Parameters["@SellDate"].Value.ToString() + " " + cmd_ReceiptHeader_Info.Parameters["@SellTime"].Value.ToString();
                    }
                    else
                    {
                        checkDate = false;
                        lblDate.Text = cmd_ReceiptHeader_Info.Parameters["@SellDate"].Value.ToString() + " " + cmd_ReceiptHeader_Info.Parameters["@SellTime"].Value.ToString();
                    }

                    lblDate.Text = cmd_ReceiptHeader_Info.Parameters["@SellDate"].Value.ToString() + " " + cmd_ReceiptHeader_Info.Parameters["@SellTime"].Value.ToString();
                    lblSubTotal.Text = string.Format("{0:$0.00}", Convert.ToDouble(cmd_ReceiptHeader_Info.Parameters["@SubTotal"].Value));
                    lblTax.Text = string.Format("{0:$0.00}", Convert.ToDouble(cmd_ReceiptHeader_Info.Parameters["@Tax"].Value));
                    lblGrandTotal.Text = string.Format("{0:$0.00}", Convert.ToDouble(cmd_ReceiptHeader_Info.Parameters["@GrandTotal"].Value));
                    lblPayBy.Text = PaymentMethod(PayBy);
                    
                    txtReceiptID.Clear();
                    txtReceiptID.Select();
                    txtReceiptID.Focus();
                }
            }
            else
            {
                radioBtnCash.Checked = true;
                radioBtnCash.Enabled = false;
                radioBtnCredit.Enabled = false;
                btnRefund.Enabled = false;

                MyMessageBox.ShowBox("ENTER RECEIPT NUMBER", "ERROR");
                //MessageBox.Show("Enter receipt number", "Error");
                txtReceiptID.SelectAll();
                txtReceiptID.Focus();
                return;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSelectAll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Selected = true;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnAdd control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount < 1)
                return;

            if (lblPayBy.Text == "RETURN")
            {
                MyMessageBox.ShowBox("THIS TRANSACTION IS NOT RETURNABLE", "ERROR");
                return;
            }

            /*if (Convert.ToDouble(dataGridView1.SelectedCells[3].Value) == 0 | Convert.ToDouble(dataGridView1.SelectedCells[5].Value) < 0)
            {
                MyMessageBox.ShowBox("THIS ITEM CAN NOT BE RETURNED", "ERROR");
                //MessageBox.Show("This item can not be returned", "Error");
                return;
            }*/

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Selected == true)
                {
                    if (dataGridView1.Rows[i].Cells[6].Value.ToString() == "000000999109" | dataGridView1.Rows[i].Cells[6].Value.ToString() == "000000999111" | dataGridView1.Rows[i].Cells[6].Value.ToString() == "000000999112")
                    {
                        MyMessageBox.ShowBox("NOT AVAILABLE (COUPON/GIFTCARD)", "ERROR");
                        return;
                    }
                    else if (dataGridView1.Rows[i].Cells[6].Value.ToString() == "B4UGIFTCARD1" | dataGridView1.Rows[i].Cells[6].Value.ToString() == "B4UGIFTCARD2" | dataGridView1.Rows[i].Cells[6].Value.ToString() == "B4UGIFTCARD3")
                    {
                        MyMessageBox.ShowBox("NOT AVAILABLE (COUPON/GIFTCARD)", "ERROR");
                        return;
                    }

                    /*if (dataGridView2.RowCount > 0)
                    {
                        for (int j = 0; j < dataGridView2.RowCount; j++)
                        {
                            if (dataGridView2.Rows[j].Cells[6].Value.ToString() == dataGridView1.Rows[i].Cells[6].Value.ToString() & Convert.ToDouble(dataGridView2.Rows[j].Cells[3].Value) == Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value))
                            {
                                //MyMessageBox.ShowBox("THIS ITEM IS ALREADY ADDED", "ERROR");
                                return;
                            }
                        }
                    }*/

                    Set_Variables(i);
                    returnTable.Rows.Add(brand, name, '1', basePrice, discountPrice, price, upc, index, ItmGp1, ItmGp2, ItmGp3, size, color, sellDate, sellTime, maxQty);
                }
            }

            dataGridView2.DataSource = returnTable;
            dataGridView2.Columns[0].HeaderText = "Brand";
            dataGridView2.Columns[0].Width = 80;
            dataGridView2.Columns[1].HeaderText = "Name";
            dataGridView2.Columns[1].Width = 150;
            dataGridView2.Columns[2].HeaderText = "Qty";
            dataGridView2.Columns[2].Width = 30;
            dataGridView2.Columns[3].HeaderText = "Base Price";
            dataGridView2.Columns[3].DefaultCellStyle.Format = "c";
            dataGridView2.Columns[3].Width = 55;
            dataGridView2.Columns[4].HeaderText = "Discount Price";
            dataGridView2.Columns[4].DefaultCellStyle.Format = "c";
            dataGridView2.Columns[4].Width = 55;
            dataGridView2.Columns[5].HeaderText = "Price";
            dataGridView2.Columns[5].DefaultCellStyle.Format = "c";
            dataGridView2.Columns[5].Width = 55;

            /*int ItmIndex = Convert.ToInt16(dataGridView1.SelectedRows[0].Cells[8].Value);

            SqlCommand cmd = new SqlCommand("Create_Return_Item", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = receiptID;
            cmd.Parameters.Add("@ItmIndex", SqlDbType.Int).Value = ItmIndex;
            cmd.Parameters.Add("@ItmBasePrice", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.SelectedCells[3].Value);
            cmd.Parameters.Add("@ItmDiscountPrice", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.SelectedCells[4].Value);

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            connection.Open();
            adapter.Fill(returnTable);
            connection.Close();
      
            dataGridView2.DataSource = returnTable;
            dataGridView2.Columns[0].HeaderText = "Brand";
            dataGridView2.Columns[0].Width = 80;
            dataGridView2.Columns[1].HeaderText = "Name";
            dataGridView2.Columns[1].Width = 150;
            dataGridView2.Columns[2].HeaderText = "Qty";
            dataGridView2.Columns[2].Width = 30;
            dataGridView2.Columns[3].HeaderText = "Unit Price";
            dataGridView2.Columns[3].DefaultCellStyle.Format = "c";
            dataGridView2.Columns[3].Width = 55;
            dataGridView2.Columns[4].HeaderText = "Discount Price";
            dataGridView2.Columns[4].DefaultCellStyle.Format = "c";
            dataGridView2.Columns[4].Width = 55;
            dataGridView2.Columns[5].HeaderText = "Price";
            dataGridView2.Columns[5].DefaultCellStyle.Format = "c";
            dataGridView2.Columns[5].Width = 55;
            dataGridView2.Columns[6].HeaderText = "Tax";
            dataGridView2.Columns[6].Width = 55;
            dataGridView2.Columns[6].DefaultCellStyle.Format = "c";
            dataGridView2.Columns[12].HeaderText = "Max Qty";*/

            SubTotal = 0;
            Tax = 0;
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                SubTotal = SubTotal + Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value);
            }
            Tax = Math.Round(SubTotal * parentForm.storeTaxRate, 2, MidpointRounding.AwayFromZero);
            nGrandTotal = SubTotal + Tax;
            lblNewSubTotal.Text = string.Format("{0:$0.00}", SubTotal);
            lblNewTax.Text = string.Format("{0:$0.00}", Tax);
            lblNewGrandTotal.Text = string.Format("{0:$0.00}", nGrandTotal);
        }

        /// <summary>
        /// Handles the Click event of the btnSameCopy control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSameCopy_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount < 1)
                return;

            /*for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Selected == true)
                {
                    if (dataGridView2.RowCount > 0)
                    {
                        for (int j = 0; j < dataGridView2.RowCount; j++)
                        {
                            if (dataGridView2.Rows[j].Cells[6].Value.ToString() == dataGridView1.Rows[i].Cells[6].Value.ToString() & Convert.ToDouble(dataGridView2.Rows[j].Cells[3].Value) == Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value))
                            {
                                return;
                            }
                        }
                    }

                    if (dataGridView1.Rows[i].Cells[1].Value.ToString().ToUpper() == "POINTS REDEEMED" | dataGridView1.Rows[i].Cells[6].Value.ToString().ToUpper() == "000000999110")
                    {
                        Set_Variables(i);
                        returnTable.Rows.Add(brand, name, "0", basePrice, discountPrice, price, upc, index, ItmGp1, ItmGp2, ItmGp3, size, color, sellDate, sellTime, maxQty);
                    }
                    else
                    {
                        Set_Variables(i);
                        returnTable.Rows.Add(brand, name, maxQty, basePrice, discountPrice, Math.Round((price * Convert.ToInt16(maxQty)), 2, MidpointRounding.AwayFromZero), upc, index, ItmGp1, ItmGp2, ItmGp3, size, color, sellDate, sellTime, maxQty);
                    }
                }
            }*/

            dataGridView2.DataSource = null;
            returnTable.Clear();

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[6].Value.ToString() == "000000999109" | dataGridView1.Rows[i].Cells[6].Value.ToString() == "000000999111" | dataGridView1.Rows[i].Cells[6].Value.ToString() == "000000999112")
                {
                    MyMessageBox.ShowBox("NOT AVAILABLE (COUPON/GIFTCARD)", "ERROR");
                    returnTable.Clear();
                    return;
                }
                else if (dataGridView1.Rows[i].Cells[6].Value.ToString() == "B4UGIFTCARD1" | dataGridView1.Rows[i].Cells[6].Value.ToString() == "B4UGIFTCARD2" | dataGridView1.Rows[i].Cells[6].Value.ToString() == "B4UGIFTCARD3")
                {
                    MyMessageBox.ShowBox("NOT AVAILABLE (COUPON/GIFTCARD)", "ERROR");
                    return;
                }
                
                if (dataGridView1.Rows[i].Cells[1].Value.ToString().ToUpper() == "POINTS REDEEMED" | dataGridView1.Rows[i].Cells[6].Value.ToString().ToUpper() == "000000999110")
                {
                    Set_Variables(i);
                    returnTable.Rows.Add(brand, name, "0", basePrice, discountPrice, price, upc, index, ItmGp1, ItmGp2, ItmGp3, size, color, sellDate, sellTime, maxQty);
                }
                else
                {
                    Set_Variables(i);
                    returnTable.Rows.Add(brand, name, maxQty, basePrice, discountPrice, Math.Round((price * Convert.ToInt16(maxQty)), 2, MidpointRounding.AwayFromZero), upc, index, ItmGp1, ItmGp2, ItmGp3, size, color, sellDate, sellTime, maxQty);
                }
            }

            dataGridView2.DataSource = returnTable;
            dataGridView2.Columns[0].HeaderText = "Brand";
            dataGridView2.Columns[0].Width = 80;
            dataGridView2.Columns[1].HeaderText = "Name";
            dataGridView2.Columns[1].Width = 150;
            dataGridView2.Columns[2].HeaderText = "Qty";
            dataGridView2.Columns[2].Width = 30;
            dataGridView2.Columns[3].HeaderText = "Base Price";
            dataGridView2.Columns[3].DefaultCellStyle.Format = "c";
            dataGridView2.Columns[3].Width = 55;
            dataGridView2.Columns[4].HeaderText = "Discount Price";
            dataGridView2.Columns[4].DefaultCellStyle.Format = "c";
            dataGridView2.Columns[4].Width = 55;
            dataGridView2.Columns[5].HeaderText = "Price";
            dataGridView2.Columns[5].DefaultCellStyle.Format = "c";
            dataGridView2.Columns[5].Width = 55;

            SubTotal = 0;
            Tax = 0;
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                SubTotal = SubTotal + Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value);
            }
            Tax = Math.Round(SubTotal * parentForm.storeTaxRate, 2, MidpointRounding.AwayFromZero);
            nGrandTotal = SubTotal + Tax;
            lblNewSubTotal.Text = string.Format("{0:$0.00}", SubTotal);
            lblNewTax.Text = string.Format("{0:$0.00}", Tax);
            lblNewGrandTotal.Text = string.Format("{0:$0.00}", nGrandTotal);
        }

        /// <summary>
        /// Handles the Click event of the btnReset control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            returnTable.Clear();
            btnQtyPlus.Enabled = true;
            btnQtyMinus.Enabled = true;
            btnAdd.Enabled = true;
            btnSameCopy.Enabled = true;
            btnReturn.Enabled = true;
            btnStoreCredit.Enabled = false;
            btnTransferRefund.Enabled = false;

            radioBtnCash.Checked = true;
            radioBtnCash.Enabled = false;
            radioBtnCredit.Enabled = false;
            grpBoxRefundOptions.Enabled = false;
            txtRefundAmount.Text = "0.00";
            btnVoid.Enabled = false;
            btnRefund.Enabled = false;
            rdoBtnWithTax.Enabled = true;
            rdoBtnWithNoTax.Enabled = true;

            //pointsBack = false;
            //pointsBackAmount = 0;

            Resetting();
        }

        /// <summary>
        /// Handles the Click event of the btnQtyPlus control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnQtyPlus_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                if (dataGridView1.Enabled == true)
                {
                    if (Convert.ToInt16(dataGridView2.SelectedCells[2].Value) == Convert.ToInt16(dataGridView2.SelectedCells[15].Value))
                    {
                        return;
                    }
                }
                else
                {
                }

                if (Convert.ToDouble(dataGridView2.SelectedCells[4].Value) == 0)
                {
                    int n = Convert.ToInt16(dataGridView2.SelectedCells[2].Value);

                    if (n == 0)
                    {
                        return;
                    }

                    double qbasePrice = Convert.ToDouble(dataGridView2.SelectedCells[3].Value);
                    dataGridView2.SelectedCells[2].Value = n + 1;
                    dataGridView2.SelectedCells[5].Value = (n + 1) * qbasePrice;

                    double qsubTotal = 0;
                    double qtax = 0;
                    for (int i = 0; i < dataGridView2.RowCount; i++)
                    {
                        qsubTotal = qsubTotal + Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value);
                    }
                    qtax = Math.Round(qsubTotal * parentForm.storeTaxRate, 2, MidpointRounding.AwayFromZero);
                    double qgrandTotal = qsubTotal + qtax;
                    lblNewSubTotal.Text = string.Format("{0:$0.00}", qsubTotal);
                    lblNewTax.Text = string.Format("{0:$0.00}", qtax);
                    lblNewGrandTotal.Text = string.Format("{0:$0.00}", qgrandTotal);
                }
                else
                {
                    int n = Convert.ToInt16(dataGridView2.SelectedCells[2].Value);

                    if (n == 0)
                    {
                        return;
                    }

                    double qdiscountPrice = Convert.ToDouble(dataGridView2.SelectedCells[4].Value);
                    dataGridView2.SelectedCells[2].Value = n + 1;
                    dataGridView2.SelectedCells[5].Value = (n + 1) * qdiscountPrice;

                    double qsubTotal = 0;
                    double qtax = 0;
                    for (int i = 0; i < dataGridView2.RowCount; i++)
                    {
                        qsubTotal = qsubTotal + Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value);
                    }
                    qtax = Math.Round(qsubTotal * parentForm.storeTaxRate, 2, MidpointRounding.AwayFromZero);
                    double qgrandTotal = qsubTotal + qtax;
                    lblNewSubTotal.Text = string.Format("{0:$0.00}", qsubTotal);
                    lblNewTax.Text = string.Format("{0:$0.00}", qtax);
                    lblNewGrandTotal.Text = string.Format("{0:$0.00}", qgrandTotal);
                }
            }
            else
            {
                MyMessageBox.ShowBox("NO ITEM", "ERROR");
                //MessageBox.Show("No item", "Error");
                return;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnQtyMinus control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnQtyMinus_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                int n = Convert.ToInt16(dataGridView2.SelectedCells[2].Value);

                if (n == 0)
                {
                    return;
                }

                if (n > 1)
                {
                    if (Convert.ToDouble(dataGridView2.SelectedCells[4].Value) == 0)
                    {
                        double qunitPrice = Convert.ToDouble(dataGridView2.SelectedCells[3].Value);
                        dataGridView2.SelectedCells[2].Value = n - 1;
                        dataGridView2.SelectedCells[5].Value = (n - 1) * qunitPrice;

                        double qsubTotal = 0;
                        double qtax = 0;
                        for (int i = 0; i < dataGridView2.RowCount; i++)
                        {
                            qsubTotal = qsubTotal + Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value);
                        }
                        qtax = Math.Round(qsubTotal * parentForm.storeTaxRate, 2, MidpointRounding.AwayFromZero);
                        double qgrandTotal = qsubTotal +qtax;
                        lblNewSubTotal.Text = string.Format("{0:$0.00}", qsubTotal);
                        lblNewTax.Text = string.Format("{0:$0.00}", qtax);
                        lblNewGrandTotal.Text = string.Format("{0:$0.00}", qgrandTotal);
                    }
                    else
                    {
                        double qdiscountPrice = Convert.ToDouble(dataGridView2.SelectedCells[4].Value);
                        dataGridView2.SelectedCells[2].Value = n - 1;   
                        dataGridView2.SelectedCells[5].Value = (n - 1) * qdiscountPrice;

                        double qsubTotal = 0;
                        double qtax = 0;
                        for (int i = 0; i < dataGridView2.RowCount; i++)
                        {
                            qsubTotal = qsubTotal + Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value);
                        }
                        qtax = Math.Round(qsubTotal * parentForm.storeTaxRate, 2, MidpointRounding.AwayFromZero);
                        double qgrandTotal = qsubTotal + qtax;
                        lblNewSubTotal.Text = string.Format("{0:$0.00}", qsubTotal);
                        lblNewTax.Text = string.Format("{0:$0.00}", qtax);
                        lblNewGrandTotal.Text = string.Format("{0:$0.00}", qgrandTotal);
                    }
                }
            }
            else
            {
                MyMessageBox.ShowBox("NO ITEM", "ERROR");
                //MessageBox.Show("No item", "Error");
                return;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the rdoBtnWithTax control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rdoBtnWithTax_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBtnWithTax.Checked == true)
            {
                rdoBtnWithTax.BackColor = Color.ForestGreen;
                rdoBtnWithNoTax.BackColor = Color.DarkSeaGreen;

                SubTotal = 0;
                Tax = 0;
                nGrandTotal = 0;
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    SubTotal = SubTotal + Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value);
                }
                Tax = Math.Round(SubTotal * parentForm.storeTaxRate, 2, MidpointRounding.AwayFromZero);
                nGrandTotal = SubTotal + Tax;
                lblNewSubTotal.Text = string.Format("{0:$0.00}", SubTotal);
                lblNewTax.Text = string.Format("{0:$0.00}", Tax);
                lblNewGrandTotal.Text = string.Format("{0:$0.00}", nGrandTotal);
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the rdoBtnWithNoTax control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rdoBtnWithNoTax_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBtnWithNoTax.Checked == true)
            {
                rdoBtnWithTax.BackColor = Color.DarkSeaGreen;
                rdoBtnWithNoTax.BackColor = Color.ForestGreen;

                SubTotal = 0;
                Tax = 0;
                nGrandTotal = 0;
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    SubTotal = SubTotal + Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value);
                }
                //Tax = Math.Round(SubTotal * parentForm.storeTaxRate, 2, MidpointRounding.AwayFromZero);
                nGrandTotal = SubTotal + Tax;
                lblNewSubTotal.Text = string.Format("{0:$0.00}", SubTotal);
                lblNewTax.Text = string.Format("{0:$0.00}", Tax);
                lblNewGrandTotal.Text = string.Format("{0:$0.00}", nGrandTotal);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnReturn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (dataGridView2.RowCount > 0)
            {
                for (int j = 0; j < dataGridView2.RowCount; j++)
                {
                    if (Convert.ToDouble(dataGridView2.Rows[j].Cells[4].Value) > 0)
                    {
                        dataGridView2.Rows[j].Cells[2].Value = -Convert.ToDouble(dataGridView2.Rows[j].Cells[2].Value);
                        dataGridView2.Rows[j].Cells[5].Value = Convert.ToInt16(dataGridView2.Rows[j].Cells[2].Value) * Convert.ToDouble(dataGridView2.Rows[j].Cells[4].Value);
                    }
                    else if (Convert.ToDouble(dataGridView2.Rows[j].Cells[4].Value) < 0)
                    {
                        dataGridView2.Rows[j].Cells[2].Value = Convert.ToDouble(dataGridView2.Rows[j].Cells[2].Value);
                        dataGridView2.Rows[j].Cells[4].Value = -Convert.ToDouble(dataGridView2.Rows[j].Cells[4].Value);

                        if (Convert.ToString(dataGridView2.Rows[j].Cells[8].Value) == "10" | Convert.ToString(dataGridView2.Rows[j].Cells[1].Value) == "POINTS REDEEMED")
                        {
                            dataGridView2.Rows[j].Cells[5].Value = Convert.ToDouble(dataGridView2.Rows[j].Cells[4].Value);

                            dataGridView2.Rows[j].Cells[1].Value = "POINTS BACK";
                            pointsBack = true;
                            pointsBackAmount = Convert.ToDouble(dataGridView2.Rows[j].Cells[5].Value);
                        }
                        else
                        {
                            dataGridView2.Rows[j].Cells[5].Value = Convert.ToInt16(dataGridView2.Rows[j].Cells[2].Value) * Convert.ToDouble(dataGridView2.Rows[j].Cells[4].Value);
                        }
                    }
                    else
                    {
                        dataGridView2.Rows[j].Cells[2].Value = -Convert.ToDouble(dataGridView2.Rows[j].Cells[2].Value);
                        dataGridView2.Rows[j].Cells[5].Value = Convert.ToInt16(dataGridView2.Rows[j].Cells[2].Value) * Convert.ToDouble(dataGridView2.Rows[j].Cells[3].Value);
                    }
                }

                if (rdoBtnWithTax.Checked == true)
                {
                    SubTotal = 0;
                    Tax = 0;
                    nGrandTotal = 0;
                    for (int i = 0; i < dataGridView2.RowCount; i++)
                    {
                        SubTotal = SubTotal + Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value);
                    }
                    Tax = Math.Round(SubTotal * parentForm.storeTaxRate, 2, MidpointRounding.AwayFromZero);
                    nGrandTotal = SubTotal + Tax;
                    lblNewSubTotal.Text = string.Format("{0:$0.00}", SubTotal);
                    lblNewTax.Text = string.Format("{0:$0.00}", Tax);
                    lblNewGrandTotal.Text = string.Format("{0:$0.00}", nGrandTotal);
                }
                else if (rdoBtnWithNoTax.Checked == true)
                {
                    SubTotal = 0;
                    Tax = 0;
                    nGrandTotal = 0;
                    for (int i = 0; i < dataGridView2.RowCount; i++)
                    {
                        SubTotal = SubTotal + Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value);
                    }
                    //Tax = Math.Round(SubTotal * parentForm.storeTaxRate, 2, MidpointRounding.AwayFromZero);
                    nGrandTotal = SubTotal + Tax;
                    lblNewSubTotal.Text = string.Format("{0:$0.00}", SubTotal);
                    lblNewTax.Text = string.Format("{0:$0.00}", Tax);
                    lblNewGrandTotal.Text = string.Format("{0:$0.00}", nGrandTotal);
                }

                btnQtyPlus.Enabled = false;
                btnQtyMinus.Enabled = false;
                btnAdd.Enabled = false;
                btnSameCopy.Enabled = false;
                btnReturn.Enabled = false;
                btnStoreCredit.Enabled = true;
                btnTransferRefund.Enabled = true;
                rdoBtnWithTax.Enabled = false;
                rdoBtnWithNoTax.Enabled = false;

                SubTotal = -SubTotal;
                Tax = -Tax;
                nGrandTotal = -nGrandTotal;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnStoreCredit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnStoreCredit_Click(object sender, EventArgs e)
        {
            if (boolSecondAuthentication == false)
            {
                SecondAuthentication secondAuthenticationForm = new SecondAuthentication(2);
                secondAuthenticationForm.parentForm1 = this.parentForm;
                secondAuthenticationForm.parentForm2 = this;
                secondAuthenticationForm.ShowDialog();
            }
            else
            {
                if (option == 0)
                {
                    if (Checking_Duplicated_StoreCredit(refReceiptID) == false)
                    {
                        DialogResult MyDialogResult;
                        MyDialogResult = MessageBox.Show(this, "THIS TRANSACTION WAS ALREADY RETURNED AT LEAST ONCE.\n\n" + "DO YOU WANT TO PROCEED THIS TRANSACTION?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (MyDialogResult == DialogResult.No)
                            return;
                    }

                    if (Checking_Duplicated_Refund(refReceiptID) == false)
                    {
                        DialogResult MyDialogResult;
                        MyDialogResult = MessageBox.Show(this, "THIS TRANSACTION WAS ALREADY REFUNDED AT LEAST ONCE.\n\n" + "DO YOU WANT TO PROCEED THIS TRANSACTION?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (MyDialogResult == DialogResult.No)
                            return;
                    }
                }

                btnStoreCredit.Enabled = false;

                DateTime currentTime = DateTime.Now;
                rCnt = dataGridView2.RowCount;
                StoreCode = parentForm.storeCode;
                CashierID = parentForm.employeeID;
                RegisterNum = parentForm.cashRegisterNum;
                NewSellDate = string.Format("{0:MM/dd/yyyy}", currentTime);
                NewSellTime = string.Format("{0:T}", currentTime);
                mType = Get_MemberType(Convert.ToInt64(MemberID));

                if (MemberID == "101" | MemberID == "" | MemberID == "0")
                {
                    MemberPoints = 0;
                }
                else
                {
                    if (mType == parentForm.MType1)
                    {
                        MemberPoints = Math.Round(Convert.ToDouble(-SubTotal) * (parentForm.MPts1 / 100), 2, MidpointRounding.AwayFromZero);
                    }
                    else if (mType == parentForm.MType2)
                    {
                        MemberPoints = Math.Round(Convert.ToDouble(-SubTotal) * (parentForm.MPts2 / 100), 2, MidpointRounding.AwayFromZero);
                    }
                    else if (mType == parentForm.MType3)
                    {
                        MemberPoints = Math.Round(Convert.ToDouble(-SubTotal) * (parentForm.MPts3 / 100), 2, MidpointRounding.AwayFromZero);
                    }
                    else if (mType == parentForm.MType4)
                    {
                        MemberPoints = Math.Round(Convert.ToDouble(-SubTotal) * (parentForm.MPts4 / 100), 2, MidpointRounding.AwayFromZero);
                    }
                    else if (mType == parentForm.MType5)
                    {
                        MemberPoints = Math.Round(Convert.ToDouble(-SubTotal) * (parentForm.MPts5 / 100), 2, MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        MemberPoints = 0;
                    }

                    //MemberPoints = Math.Round(Math.Round((-SubTotal), 2, MidpointRounding.AwayFromZero) * 0.05, 2, MidpointRounding.AwayFromZero);
                }

                ReceiptType = "RETURN";
                ReceiptStatus = "ISSUED";

                SqlCommand cmd_ReceiptHeader = new SqlCommand("Create_ReceiptHeader_Information", connection);
                cmd_ReceiptHeader.CommandType = CommandType.StoredProcedure;
                cmd_ReceiptHeader.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = StoreCode;
                cmd_ReceiptHeader.Parameters.Add("@CashierID", SqlDbType.NVarChar).Value = managerID;
                cmd_ReceiptHeader.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = RegisterNum;
                cmd_ReceiptHeader.Parameters.Add("@MemberID", SqlDbType.NVarChar).Value = MemberID;
                cmd_ReceiptHeader.Parameters.Add("@MemberName", SqlDbType.NVarChar).Value = MemberName;
                cmd_ReceiptHeader.Parameters.Add("@PayBy", SqlDbType.Int).Value = 0;
                cmd_ReceiptHeader.Parameters.Add("@SellDate", SqlDbType.NVarChar).Value = NewSellDate;
                cmd_ReceiptHeader.Parameters.Add("@SellTime", SqlDbType.NVarChar).Value = NewSellTime;
                cmd_ReceiptHeader.Parameters.Add("@SubTotal", SqlDbType.Money).Value = -SubTotal;
                cmd_ReceiptHeader.Parameters.Add("@GrandTotal", SqlDbType.Money).Value = -nGrandTotal;
                cmd_ReceiptHeader.Parameters.Add("@Tax", SqlDbType.Money).Value = -Tax;
                cmd_ReceiptHeader.Parameters.Add("@Discount", SqlDbType.Money).Value = 0;
                cmd_ReceiptHeader.Parameters.Add("@MemberPoints", SqlDbType.Money).Value = MemberPoints;
                cmd_ReceiptHeader.Parameters.Add("@Pay", SqlDbType.Money).Value = 0;
                cmd_ReceiptHeader.Parameters.Add("@Change", SqlDbType.Money).Value = 0;
                cmd_ReceiptHeader.Parameters.Add("@ReceiptType", SqlDbType.NVarChar).Value = ReceiptType;
                cmd_ReceiptHeader.Parameters.Add("@ReceiptStatus", SqlDbType.NVarChar).Value = ReceiptStatus;
                connection.Open();
                cmd_ReceiptHeader.ExecuteNonQuery();
                connection.Close();

                SqlCommand cmd_ReceiptID = new SqlCommand("Get_ReceiptID", connection);
                cmd_ReceiptID.CommandType = CommandType.StoredProcedure;
                cmd_ReceiptID.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = StoreCode;
                cmd_ReceiptID.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = RegisterNum;
                cmd_ReceiptID.Parameters.Add("@SellDate", SqlDbType.NVarChar).Value = NewSellDate;
                cmd_ReceiptID.Parameters.Add("@SellTime", SqlDbType.NVarChar).Value = NewSellTime;
                SqlParameter ReceiptID_Param = cmd_ReceiptID.Parameters.Add("@ReceiptID", SqlDbType.BigInt);
                ReceiptID_Param.Direction = ParameterDirection.Output;
                connection.Open();
                cmd_ReceiptID.ExecuteNonQuery();
                connection.Close();
                ReceiptID = Convert.ToInt64(cmd_ReceiptID.Parameters["@ReceiptID"].Value);

                for (int i = 1; i <= rCnt; i++)
                {
                    ItmBrand = dataGridView2.Rows[i - 1].Cells[0].Value.ToString();
                    ItmName = dataGridView2.Rows[i - 1].Cells[1].Value.ToString();
                    ItmQty = dataGridView2.Rows[i - 1].Cells[2].Value.ToString();
                    ItmGroup1 = dataGridView2.Rows[i - 1].Cells[8].Value.ToString();
                    ItmGroup2 = dataGridView2.Rows[i - 1].Cells[9].Value.ToString();
                    ItmGroup3 = dataGridView2.Rows[i - 1].Cells[10].Value.ToString();
                    string ItmGroup4 = "0";
                    string ItmGroup5 = "0";
                    ItmUpc = dataGridView2.Rows[i - 1].Cells[6].Value.ToString();
                    ItmBasePrice = Convert.ToDouble(dataGridView2.Rows[i - 1].Cells[3].Value);
                    ItmDiscountPrice = Convert.ToDouble(dataGridView2.Rows[i - 1].Cells[4].Value);
                    ItmPrice = Convert.ToDouble(dataGridView2.Rows[i - 1].Cells[5].Value);
                    ItmSize = dataGridView2.Rows[i - 1].Cells[11].Value.ToString();
                    ItmColor = dataGridView2.Rows[i - 1].Cells[12].Value.ToString();

                    SqlCommand cmd_ReceiptBody = new SqlCommand("Create_ReceiptBody_Information", connection);
                    cmd_ReceiptBody.CommandType = CommandType.StoredProcedure;
                    cmd_ReceiptBody.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
                    cmd_ReceiptBody.Parameters.Add("@ItmIndex", SqlDbType.Int).Value = i;
                    cmd_ReceiptBody.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = ItmGroup1;
                    cmd_ReceiptBody.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = ItmGroup2;
                    cmd_ReceiptBody.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = ItmGroup3;
                    cmd_ReceiptBody.Parameters.Add("@ItmGroup4", SqlDbType.NVarChar).Value = ItmGroup4;
                    cmd_ReceiptBody.Parameters.Add("@ItmGroup5", SqlDbType.NVarChar).Value = ItmGroup5;
                    cmd_ReceiptBody.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                    cmd_ReceiptBody.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = ItmName;
                    cmd_ReceiptBody.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
                    cmd_ReceiptBody.Parameters.Add("@ItmBasePrice", SqlDbType.Money).Value = ItmBasePrice;
                    cmd_ReceiptBody.Parameters.Add("@ItmDiscountPrice", SqlDbType.Money).Value = ItmDiscountPrice;
                    cmd_ReceiptBody.Parameters.Add("@ItmPrice", SqlDbType.Money).Value = ItmPrice;
                    cmd_ReceiptBody.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
                    cmd_ReceiptBody.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
                    cmd_ReceiptBody.Parameters.Add("@ItmQty", SqlDbType.Int).Value = Convert.ToInt16(ItmQty);
                    cmd_ReceiptBody.Parameters.Add("@SellDate", SqlDbType.NVarChar).Value = NewSellDate;
                    cmd_ReceiptBody.Parameters.Add("@SellTime", SqlDbType.NVarChar).Value = NewSellTime;

                    if (ItmGroup1 == "10")
                    {
                        connection.Open();
                        cmd_ReceiptBody.ExecuteNonQuery();
                        connection.Close();
                    }
                    else
                    {
                        SqlCommand cmd_CalculatingOnHand = new SqlCommand("Calculating_OnHand_From_Return", connection);
                        cmd_CalculatingOnHand.CommandType = CommandType.StoredProcedure;
                        cmd_CalculatingOnHand.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = ItmGroup1;
                        cmd_CalculatingOnHand.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = ItmGroup2;
                        cmd_CalculatingOnHand.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = ItmGroup3;
                        cmd_CalculatingOnHand.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                        cmd_CalculatingOnHand.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = ItmName;
                        cmd_CalculatingOnHand.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
                        cmd_CalculatingOnHand.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
                        cmd_CalculatingOnHand.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
                        cmd_CalculatingOnHand.Parameters.Add("@ItmQty", SqlDbType.Int).Value = Convert.ToInt16(ItmQty);

                        connection.Open();
                        cmd_ReceiptBody.ExecuteNonQuery();
                        cmd_CalculatingOnHand.ExecuteNonQuery();
                        connection.Close();
                    }
                }

                startDate = NewSellDate;
                expDate = string.Format("{0:MM/dd/yyyy}", DateTime.Today.AddYears(1));

                SqlCommand cmd = new SqlCommand("Create_StoreCredit", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = StoreCode;
                cmd.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = parentForm.cashRegisterNum;
                cmd.Parameters.Add("@RefReceiptID", SqlDbType.BigInt).Value = refReceiptID;
                cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
                cmd.Parameters.Add("@Amount", SqlDbType.Money).Value = nGrandTotal;
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                cmd.Parameters.Add("@ExpDate", SqlDbType.NVarChar).Value = expDate;
                cmd.Parameters.Add("@WitnessID", SqlDbType.NVarChar).Value = witnessID;

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

                SqlCommand cmd_StoreCreditID = new SqlCommand("Get_StoreCreditID", connection);
                cmd_StoreCreditID.CommandType = CommandType.StoredProcedure;
                cmd_StoreCreditID.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
                SqlParameter StoreCreditID_Param = cmd_StoreCreditID.Parameters.Add("@StoreCreditID", SqlDbType.BigInt);
                StoreCreditID_Param.Direction = ParameterDirection.Output;

                connection.Open();
                cmd_StoreCreditID.ExecuteNonQuery();
                connection.Close();
                StoreCreditID = Convert.ToInt64(cmd_StoreCreditID.Parameters["@StoreCreditID"].Value);

                SqlCommand cmd_StoreCreditInfo = new SqlCommand("Get_StoreCredit_Info", connection);
                cmd_StoreCreditInfo.CommandType = CommandType.StoredProcedure;
                cmd_StoreCreditInfo.Parameters.Add("@StoreCreditID", SqlDbType.BigInt).Value = StoreCreditID;
                SqlParameter Amount_Param = cmd_StoreCreditInfo.Parameters.Add("@Amount", SqlDbType.Money);
                SqlParameter Balance_Param = cmd_StoreCreditInfo.Parameters.Add("@Balance", SqlDbType.Money);
                SqlParameter ExpDate_Param = cmd_StoreCreditInfo.Parameters.Add("@ExpDate", SqlDbType.NVarChar, 20);
                Amount_Param.Direction = ParameterDirection.Output;
                Balance_Param.Direction = ParameterDirection.Output;
                ExpDate_Param.Direction = ParameterDirection.Output;

                connection.Open();
                cmd_StoreCreditInfo.ExecuteNonQuery();
                connection.Close();

                amount = Convert.ToDouble(cmd_StoreCreditInfo.Parameters["@Amount"].Value);
                balance = Convert.ToDouble(cmd_StoreCreditInfo.Parameters["@Balance"].Value);
                expDate = cmd_StoreCreditInfo.Parameters["@ExpDate"].Value.ToString();

                if (MemberID == "0" | MemberID == "101" | MemberID == "")
                {
                }
                else
                {
                    remainingPoints = Remaining_Points(parentForm.storeCode, Convert.ToInt64(MemberID));
                    double pointsGap = remainingPoints + MemberPoints;

                    if (pointsGap >= 0)
                    {
                        Calculate_Customer_Points();
                        remainingPoints = Remaining_Points(parentForm.storeCode, Convert.ToInt64(MemberID));
                    }
                    else
                    {
                        MemberPoints = MemberPoints - pointsGap;

                        Calculate_Customer_Points();
                        remainingPoints = Remaining_Points(parentForm.storeCode, Convert.ToInt64(MemberID));
                    }

                    parentForm.Customer_Transaction_Update(0, parentForm.storeCode, Convert.ToInt64(MemberID), -nGrandTotal, NewSellDate);
                }

                Int32 retVal;
                String errMsg;
                apiAlias.StatusMonitoring pMonitorCB = new apiAlias.StatusMonitoring(StatusMonitoring);

                storeCreditPrint = new PrintDocument();
                storeCreditPrint.PrintPage += new PrintPageEventHandler(storeCreditPrint_PrintPage);
                storeCreditPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;

                try
                {
                    // Open Printer Monitor of Status API.
                    mpHandle = apiAlias.BiOpenMonPrinter(apiAlias.TYPE_PRINTER, storeCreditPrint.PrinterSettings.PrinterName);
                    if (mpHandle < 0)
                        MessageBox.Show("Failed to open printer status monitor.", "", MessageBoxButtons.OK);
                    else
                    {
                        isFinish = false;
                        cancelErr = false;

                        // Set the callback function that will monitor printer status.
                        retVal = apiAlias.BiSetStatusBackFunction(mpHandle, pMonitorCB);

                        if (retVal != apiAlias.SUCCESS)
                            MessageBox.Show("Failed to set callback function.", "", MessageBoxButtons.OK);
                        else
                        {
                            if (cancelErr)
                                retVal = apiAlias.BiCancelError(mpHandle);
                            else
                            {
                                // Call the function to open cash drawer.
                                //OpenDrawer(storeCreditPrint.PrinterSettings.PrinterName);
                                storeCreditPrint.Print();
                            }

                            //if (MemberID != "101" | MemberID != "")
                            //    Calculate_Customer_Points();
                        }
                    }
                }
                catch (Exception ex)
                {
                    errMsg = ex.Message;
                    MessageBox.Show("Failed to open StatusAPI.", errMsg, MessageBoxButtons.OK);
                }
                finally
                {
                    // Close Printer Monitor.
                    if (mpHandle > 0)
                    {
                        if (apiAlias.BiCloseMonPrinter(mpHandle) != apiAlias.SUCCESS)
                            MessageBox.Show("Failed to close printer status monitor.", "", MessageBoxButtons.OK);
                    }
                }

                radioBtnCash.Checked = true;
                radioBtnCash.Enabled = false;
                radioBtnCredit.Enabled = false;
                radioBtnCreditTerminal.Enabled = false;
                btnRefund.Enabled = false;

                btnStoreCredit.Enabled = false;
                btnAdd.Enabled = true;
                btnReturn.Enabled = true;
                btnTransferRefund.Enabled = false;
                txtRefundAmount.Text = "0.00";

                dataGridView1.DataSource = null;
                dataGridView2.DataSource = null;

                Resetting();

                //if (option == 1)
                //{
                //    parentForm.btnDeleteAll_Click(null, null);
                //    this.Close();
                //}
            }
        }

        /// <summary>
        /// Handles the Click event of the btnTransferRefund control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnTransferRefund_Click(object sender, EventArgs e)
        {
            if (option == 0)
            {
                if (nGrandTotal > 0)
                {
                    if (PaymentMethod(PayBy) == "CASH")
                    {
                        txtRefundAmount.Text = string.Format("{0:0.00}", nGrandTotal);

                        grpBoxRefundOptions.Enabled = true;
                        radioBtnCash.Checked = true;
                        radioBtnCredit.Enabled = false;
                        radioBtnCreditTerminal.Enabled = false;
                        btnRefund.Enabled = true;
                        btnVoid.Enabled = false;
                    }
                    else if (PaymentMethod(PayBy) == "TERMINAL (DEBIT)")
                    {
                        txtRefundAmount.Text = string.Format("{0:0.00}", nGrandTotal);

                        grpBoxRefundOptions.Enabled = true;
                        radioBtnCash.Checked = true;
                        radioBtnCredit.Enabled = false;
                        radioBtnCreditTerminal.Enabled = false;
                        btnRefund.Enabled = true;
                        btnVoid.Enabled = false;
                    }
                    else if (PaymentMethod(PayBy) == "TERMINAL (CREDIT)")
                    {
                        txtRefundAmount.Text = string.Format("{0:0.00}", nGrandTotal);

                        grpBoxRefundOptions.Enabled = true;
                        radioBtnCreditTerminal.Checked = true;
                        radioBtnCredit.Enabled = true;
                        radioBtnCash.Enabled = false;
                        btnRefund.Enabled = true;
                        btnVoid.Enabled = false;
                    }
                    else if (PaymentMethod(PayBy) == "VISA" | PaymentMethod(PayBy) == "MASTER" | PaymentMethod(PayBy) == "AMEX" | PaymentMethod(PayBy) == "DISCOVER")
                    {
                        txtRefundAmount.Text = string.Format("{0:0.00}", nGrandTotal);

                        grpBoxRefundOptions.Enabled = true;
                        radioBtnCredit.Checked = true;
                        radioBtnCash.Enabled = false;
                        radioBtnCreditTerminal.Enabled = true;
                        btnRefund.Enabled = true;
                        btnVoid.Enabled = true;
                    }
                    else if (PaymentMethod(PayBy) == "DEBIT")
                    {
                        txtRefundAmount.Text = string.Format("{0:0.00}", nGrandTotal);

                        grpBoxRefundOptions.Enabled = true;
                        radioBtnCash.Checked = true;
                        radioBtnCredit.Enabled = false;
                        radioBtnCreditTerminal.Enabled = false;
                        btnRefund.Enabled = true;
                        btnVoid.Enabled = false;
                    }
                    else if (PaymentMethod(PayBy) == "MULTIPLE")
                    {
                        txtRefundAmount.Text = string.Format("{0:0.00}", nGrandTotal);

                        grpBoxRefundOptions.Enabled = true;
                        radioBtnCash.Checked = true;
                        radioBtnCredit.Enabled = true;
                        radioBtnCreditTerminal.Enabled = true;
                        btnRefund.Enabled = true;
                        btnVoid.Enabled = false;
                    }
                    else
                    {
                        MyMessageBox.ShowBox("THIS RECEIPT IS NOT AVAILABLE FOR REFUND.", "ERROR");
                        return;
                    }
                }
                else
                {
                    MyMessageBox.ShowBox("INVALID REFUND AMOUNT (NEGATIVE).", "ERROR");
                    return;
                }
            }
            else if (option == 1)
            {
                txtRefundAmount.Text = string.Format("{0:0.00}", nGrandTotal);
                grpBoxRefundOptions.Enabled = true;
                //radioBtnCash.Checked = true;
                radioBtnCash.Enabled = true;
                radioBtnCredit.Enabled = true;
                radioBtnCreditTerminal.Enabled = true;
                btnRefund.Enabled = true;
                btnVoid.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnVoid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnVoid_Click(object sender, EventArgs e)
        {
            if (txtRefundAmount.Text == "0.00")
                return;

            if (lblPayBy.Text == "VISA" | lblPayBy.Text == "MASTER" | lblPayBy.Text == "AMEX" | lblPayBy.Text == "DISCOVER")
            {
                if (checkDate == true)
                {
                    try
                    {
                        if (boolSecondAuthentication == false)
                        {
                            SecondAuthentication secondAuthenticationForm = new SecondAuthentication(1);
                            secondAuthenticationForm.parentForm1 = this.parentForm;
                            secondAuthenticationForm.parentForm2 = this;
                            secondAuthenticationForm.ShowDialog();
                        }
                        else
                        {
                            if (Checking_Duplicated_StoreCredit(refReceiptID) == false)
                            {
                                DialogResult MyDialogResult;
                                MyDialogResult = MessageBox.Show(this, "THIS TRANSACTION WAS ALREADY RETURNED AT LEAST ONCE.\n\n" + "DO YOU WANT TO PROCEED THIS TRANSACTION?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (MyDialogResult == DialogResult.No)
                                    return;
                            }

                            if (Checking_Duplicated_Refund(refReceiptID) == false)
                            {
                                DialogResult MyDialogResult;
                                MyDialogResult = MessageBox.Show(this, "THIS TRANSACTION WAS ALREADY REFUNDED AT LEAST ONCE.\n\n" + "DO YOU WANT TO PROCEED THIS TRANSACTION?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (MyDialogResult == DialogResult.No)
                                    return;
                            }

                            SqlCommand cmd_Void = new SqlCommand("Get_CloverTransactionInfo_ForVoid", connection);
                            cmd_Void.CommandType = CommandType.StoredProcedure;
                            cmd_Void.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = refReceiptID;
                            SqlParameter PID_Param = cmd_Void.Parameters.Add("@PaymentID", SqlDbType.NVarChar, 50);
                            SqlParameter OID_Param = cmd_Void.Parameters.Add("@OrderID", SqlDbType.NVarChar, 50);
                            SqlParameter Amount_Param = cmd_Void.Parameters.Add("@Amount", SqlDbType.Money);
                            SqlParameter LastFour_Param = cmd_Void.Parameters.Add("@LastFour", SqlDbType.NVarChar, 10);
                            PID_Param.Direction = ParameterDirection.Output;
                            OID_Param.Direction = ParameterDirection.Output;
                            Amount_Param.Direction = ParameterDirection.Output;
                            LastFour_Param.Direction = ParameterDirection.Output;

                            connection.Open();
                            cmd_Void.ExecuteNonQuery();
                            connection.Close();

                            if (cmd_Void.Parameters["@PaymentID"].Value != DBNull.Value)
                            {
                                oPaymentID = cmd_Void.Parameters["@PaymentID"].Value.ToString();
                            }
                            else
                            {
                                MyMessageBox.ShowBox("PAYMENT ID ERROR.", "ERROR");
                                return;
                            }

                            if (cmd_Void.Parameters["@OrderID"].Value != DBNull.Value)
                            {
                                oOrderID = cmd_Void.Parameters["@OrderID"].Value.ToString();
                            }
                            else
                            {
                                MyMessageBox.ShowBox("ORDER ID ERROR.", "ERROR");
                                return;
                            }

                            if (cmd_Void.Parameters["@LastFour"].Value != DBNull.Value)
                            {
                                oLast4 = cmd_Void.Parameters["@LastFour"].Value.ToString();
                            }
                            else
                            {
                                MyMessageBox.ShowBox("LAST FOUR DIGIT ERROR.", "ERROR");
                                return;
                            }

                            if (cmd_Void.Parameters["@Amount"].Value != DBNull.Value)
                            {
                                oAmount = Convert.ToDouble(cmd_Void.Parameters["@Amount"].Value);
                            }
                            else
                            {
                                MyMessageBox.ShowBox("VOID AMOUNT IS 0.", "ERROR");
                                return;
                            }

                            rAmount = Convert.ToDouble(txtRefundAmount.Text.Trim());

                            if (oAmount == rAmount)
                            {
                                btnVoid.Enabled = false;
                                btnRefund.Enabled = false;
                                parentForm.Void_Credit_Transaction(oPaymentID, oOrderID, refReceiptID, oAmount, managerID, "REFUND");
                            }
                            else
                            {
                                MyMessageBox.ShowBox("VOID AMOUNT MUST BE SAME WITH ORIGINAL TRANSACTION AMOUNT.", "ERROR");
                                return;
                            }
                        }
                    }
                    catch
                    {
                        connection.Close();
                        MyMessageBox.ShowBox("RETRIEVING TRANSACTION ERROR", "ERROR");
                        return;
                    }
                }
                else
                {
                    MyMessageBox.ShowBox("IT CAN NOT BE VOIDED DUE TO SETTLEMENT.", "ERROR");
                    return;
                }
            }
            else
            {
                MyMessageBox.ShowBox("VOID TRANSACTION IS NOT AVAILABLE FOR THIS RECEIPT.", "ERROR");
                return;
            }
        }

        /// <summary>
        /// Voids the transaction.
        /// </summary>
        public void Void_Transaction()
        {
            rCnt = dataGridView2.RowCount;

            DateTime currentTime = DateTime.Now;

            StoreCode = parentForm.storeCode;
            CashierID = parentForm.employeeID;
            RegisterNum = parentForm.cashRegisterNum;
            NewSellDate = string.Format("{0:MM/dd/yyyy}", currentTime);
            NewSellTime = string.Format("{0:T}", currentTime);
            mType = Get_MemberType(Convert.ToInt64(MemberID));

            if (MemberID == "101" | MemberID == "" | MemberID == "0")
            {
                MemberPoints = 0;
            }
            else
            {
                if (mType == parentForm.MType1)
                {
                    MemberPoints = Math.Round(Convert.ToDouble(-SubTotal) * (parentForm.MPts1 / 100), 2, MidpointRounding.AwayFromZero);
                }
                else if (mType == parentForm.MType2)
                {
                    MemberPoints = Math.Round(Convert.ToDouble(-SubTotal) * (parentForm.MPts2 / 100), 2, MidpointRounding.AwayFromZero);
                }
                else if (mType == parentForm.MType3)
                {
                    MemberPoints = Math.Round(Convert.ToDouble(-SubTotal) * (parentForm.MPts3 / 100), 2, MidpointRounding.AwayFromZero);
                }
                else if (mType == parentForm.MType4)
                {
                    MemberPoints = Math.Round(Convert.ToDouble(-SubTotal) * (parentForm.MPts4 / 100), 2, MidpointRounding.AwayFromZero);
                }
                else if (mType == parentForm.MType5)
                {
                    MemberPoints = Math.Round(Convert.ToDouble(-SubTotal) * (parentForm.MPts5 / 100), 2, MidpointRounding.AwayFromZero);
                }
                else
                {
                    MemberPoints = 0;
                }

                //MemberPoints = Math.Round(Math.Round((-SubTotal), 2, MidpointRounding.AwayFromZero) * 0.05, 2, MidpointRounding.AwayFromZero);
            }

            ReceiptType = "RETURN";
            ReceiptStatus = "ISSUED";

            SqlCommand cmd_ReceiptHeader = new SqlCommand("Create_ReceiptHeader_Information", connection);
            cmd_ReceiptHeader.CommandType = CommandType.StoredProcedure;
            cmd_ReceiptHeader.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = StoreCode;
            cmd_ReceiptHeader.Parameters.Add("@CashierID", SqlDbType.NVarChar).Value = managerID;
            cmd_ReceiptHeader.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = RegisterNum;
            cmd_ReceiptHeader.Parameters.Add("@MemberID", SqlDbType.NVarChar).Value = MemberID;
            cmd_ReceiptHeader.Parameters.Add("@MemberName", SqlDbType.NVarChar).Value = MemberName;
            cmd_ReceiptHeader.Parameters.Add("@PayBy", SqlDbType.Int).Value = 0;
            cmd_ReceiptHeader.Parameters.Add("@SellDate", SqlDbType.NVarChar).Value = NewSellDate;
            cmd_ReceiptHeader.Parameters.Add("@SellTime", SqlDbType.NVarChar).Value = NewSellTime;
            cmd_ReceiptHeader.Parameters.Add("@SubTotal", SqlDbType.Money).Value = -SubTotal;
            cmd_ReceiptHeader.Parameters.Add("@GrandTotal", SqlDbType.Money).Value = -nGrandTotal;
            cmd_ReceiptHeader.Parameters.Add("@Tax", SqlDbType.Money).Value = -Tax;
            cmd_ReceiptHeader.Parameters.Add("@Discount", SqlDbType.Money).Value = 0;
            cmd_ReceiptHeader.Parameters.Add("@MemberPoints", SqlDbType.Money).Value = MemberPoints;
            cmd_ReceiptHeader.Parameters.Add("@Pay", SqlDbType.Money).Value = 0;
            cmd_ReceiptHeader.Parameters.Add("@Change", SqlDbType.Money).Value = 0;
            cmd_ReceiptHeader.Parameters.Add("@ReceiptType", SqlDbType.NVarChar).Value = ReceiptType;
            cmd_ReceiptHeader.Parameters.Add("@ReceiptStatus", SqlDbType.NVarChar).Value = ReceiptStatus;
            connection.Open();
            cmd_ReceiptHeader.ExecuteNonQuery();
            connection.Close();

            SqlCommand cmd_ReceiptID = new SqlCommand("Get_ReceiptID", connection);
            cmd_ReceiptID.CommandType = CommandType.StoredProcedure;
            cmd_ReceiptID.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = StoreCode;
            cmd_ReceiptID.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = RegisterNum;
            cmd_ReceiptID.Parameters.Add("@SellDate", SqlDbType.NVarChar).Value = NewSellDate;
            cmd_ReceiptID.Parameters.Add("@SellTime", SqlDbType.NVarChar).Value = NewSellTime;
            SqlParameter ReceiptID_Param = cmd_ReceiptID.Parameters.Add("@ReceiptID", SqlDbType.BigInt);
            ReceiptID_Param.Direction = ParameterDirection.Output;
            connection.Open();
            cmd_ReceiptID.ExecuteNonQuery();
            connection.Close();
            ReceiptID = Convert.ToInt64(cmd_ReceiptID.Parameters["@ReceiptID"].Value);

            for (int i = 1; i <= rCnt; i++)
            {
                ItmBrand = dataGridView2.Rows[i - 1].Cells[0].Value.ToString();
                ItmName = dataGridView2.Rows[i - 1].Cells[1].Value.ToString();
                ItmQty = dataGridView2.Rows[i - 1].Cells[2].Value.ToString();
                ItmGroup1 = dataGridView2.Rows[i - 1].Cells[8].Value.ToString();
                ItmGroup2 = dataGridView2.Rows[i - 1].Cells[9].Value.ToString();
                ItmGroup3 = dataGridView2.Rows[i - 1].Cells[10].Value.ToString();
                string ItmGroup4 = "0";
                string ItmGroup5 = "0";
                ItmUpc = dataGridView2.Rows[i - 1].Cells[6].Value.ToString();
                ItmBasePrice = Convert.ToDouble(dataGridView2.Rows[i - 1].Cells[3].Value);
                ItmDiscountPrice = Convert.ToDouble(dataGridView2.Rows[i - 1].Cells[4].Value);
                ItmPrice = Convert.ToDouble(dataGridView2.Rows[i - 1].Cells[5].Value);
                ItmSize = dataGridView2.Rows[i - 1].Cells[11].Value.ToString();
                ItmColor = dataGridView2.Rows[i - 1].Cells[12].Value.ToString();

                SqlCommand cmd_ReceiptBody = new SqlCommand("Create_ReceiptBody_Information", connection);
                cmd_ReceiptBody.CommandType = CommandType.StoredProcedure;
                cmd_ReceiptBody.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
                cmd_ReceiptBody.Parameters.Add("@ItmIndex", SqlDbType.Int).Value = i;
                cmd_ReceiptBody.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = ItmGroup1;
                cmd_ReceiptBody.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = ItmGroup2;
                cmd_ReceiptBody.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = ItmGroup3;
                cmd_ReceiptBody.Parameters.Add("@ItmGroup4", SqlDbType.NVarChar).Value = ItmGroup4;
                cmd_ReceiptBody.Parameters.Add("@ItmGroup5", SqlDbType.NVarChar).Value = ItmGroup5;
                cmd_ReceiptBody.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                cmd_ReceiptBody.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = ItmName;
                cmd_ReceiptBody.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
                cmd_ReceiptBody.Parameters.Add("@ItmBasePrice", SqlDbType.Money).Value = ItmBasePrice;
                cmd_ReceiptBody.Parameters.Add("@ItmDiscountPrice", SqlDbType.Money).Value = ItmDiscountPrice;
                cmd_ReceiptBody.Parameters.Add("@ItmPrice", SqlDbType.Money).Value = ItmPrice;
                cmd_ReceiptBody.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
                cmd_ReceiptBody.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
                cmd_ReceiptBody.Parameters.Add("@ItmQty", SqlDbType.Int).Value = Convert.ToInt16(ItmQty);
                cmd_ReceiptBody.Parameters.Add("@SellDate", SqlDbType.NVarChar).Value = NewSellDate;
                cmd_ReceiptBody.Parameters.Add("@SellTime", SqlDbType.NVarChar).Value = NewSellTime;

                if (ItmGroup1 == "10")
                {
                    connection.Open();
                    cmd_ReceiptBody.ExecuteNonQuery();
                    connection.Close();
                }
                else
                {
                    SqlCommand cmd_CalculatingOnHand = new SqlCommand("Calculating_OnHand_From_Return", connection);
                    cmd_CalculatingOnHand.CommandType = CommandType.StoredProcedure;
                    cmd_CalculatingOnHand.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = ItmGroup1;
                    cmd_CalculatingOnHand.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = ItmGroup2;
                    cmd_CalculatingOnHand.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = ItmGroup3;
                    cmd_CalculatingOnHand.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                    cmd_CalculatingOnHand.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = ItmName;
                    cmd_CalculatingOnHand.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
                    cmd_CalculatingOnHand.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
                    cmd_CalculatingOnHand.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
                    cmd_CalculatingOnHand.Parameters.Add("@ItmQty", SqlDbType.Int).Value = Convert.ToInt16(ItmQty);

                    connection.Open();
                    cmd_ReceiptBody.ExecuteNonQuery();
                    cmd_CalculatingOnHand.ExecuteNonQuery();
                    connection.Close();
                }
            }

            SqlCommand cmd = new SqlCommand("Create_Refund", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = StoreCode;
            cmd.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = RegisterNum;
            cmd.Parameters.Add("@RefReceiptID", SqlDbType.BigInt).Value = refReceiptID;
            cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
            cmd.Parameters.Add("@Amount", SqlDbType.Money).Value = Convert.ToDouble(txtRefundAmount.Text);
            cmd.Parameters.Add("@RefundMethod", SqlDbType.Int).Value = ReturnCreditCardType(lblPayBy.Text);
            cmd.Parameters.Add("@RefundDate", SqlDbType.NVarChar).Value = NewSellDate;
            cmd.Parameters.Add("@RefundTime", SqlDbType.NVarChar).Value = NewSellTime;
            cmd.Parameters.Add("@RefundType", SqlDbType.NVarChar).Value = "VOID";
            cmd.Parameters.Add("@WitnessID", SqlDbType.NVarChar).Value = witnessID;

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            SqlCommand cmd_RefundID = new SqlCommand("Get_RefundID", connection);
            cmd_RefundID.CommandType = CommandType.StoredProcedure;
            cmd_RefundID.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
            SqlParameter RefundID_Param = cmd_RefundID.Parameters.Add("@RefundID", SqlDbType.BigInt);
            RefundID_Param.Direction = ParameterDirection.Output;

            connection.Open();
            cmd_RefundID.ExecuteNonQuery();
            connection.Close();
            RefundID = Convert.ToInt64(cmd_RefundID.Parameters["@RefundID"].Value);

            SqlCommand cmd_RefundInfo = new SqlCommand("Get_Refund_Info", connection);
            cmd_RefundInfo.CommandType = CommandType.StoredProcedure;
            cmd_RefundInfo.Parameters.Add("@RefundID", SqlDbType.BigInt).Value = RefundID;
            SqlParameter Amount_Param = cmd_RefundInfo.Parameters.Add("@Amount", SqlDbType.Money);
            SqlParameter RefundMethod_Param = cmd_RefundInfo.Parameters.Add("@RefundMethod", SqlDbType.Int);
            SqlParameter RefundDate_Param = cmd_RefundInfo.Parameters.Add("@RefundDate", SqlDbType.NVarChar, 20);
            SqlParameter RefundTime_Param = cmd_RefundInfo.Parameters.Add("@RefundTime", SqlDbType.NVarChar, 20);
            SqlParameter RefundType_Param = cmd_RefundInfo.Parameters.Add("@RefundType", SqlDbType.NVarChar, 50);
            SqlParameter WitnessID_Param = cmd_RefundInfo.Parameters.Add("@WitnessID", SqlDbType.NVarChar, 50);
            Amount_Param.Direction = ParameterDirection.Output;
            RefundMethod_Param.Direction = ParameterDirection.Output;
            RefundDate_Param.Direction = ParameterDirection.Output;
            RefundTime_Param.Direction = ParameterDirection.Output;
            RefundType_Param.Direction = ParameterDirection.Output;
            WitnessID_Param.Direction = ParameterDirection.Output;

            connection.Open();
            cmd_RefundInfo.ExecuteNonQuery();
            connection.Close();

            amount = Convert.ToDouble(cmd_RefundInfo.Parameters["@Amount"].Value);
            refundMethod = PaymentMethod(Convert.ToInt16(cmd.Parameters["@RefundMethod"].Value));
            refundDate = cmd_RefundInfo.Parameters["@RefundDate"].Value.ToString();
            refundTime = cmd_RefundInfo.Parameters["@RefundTime"].Value.ToString();
            refundType = cmd_RefundInfo.Parameters["@RefundType"].Value.ToString();
            refundWitnessID = cmd_RefundInfo.Parameters["@WitnessID"].Value.ToString();

            if (MemberID == "0" | MemberID == "101" | MemberID == "")
            {
            }
            else
            {
                remainingPoints = Remaining_Points(parentForm.storeCode, Convert.ToInt64(MemberID));
                double pointsGap = remainingPoints + MemberPoints;

                if (pointsGap >= 0)
                {
                    Calculate_Customer_Points();
                    remainingPoints = Remaining_Points(parentForm.storeCode, Convert.ToInt64(MemberID));
                }
                else
                {
                    MemberPoints = MemberPoints - pointsGap;

                    Calculate_Customer_Points();
                    remainingPoints = Remaining_Points(parentForm.storeCode, Convert.ToInt64(MemberID));
                }

                parentForm.Customer_Transaction_Update(0, parentForm.storeCode, Convert.ToInt64(MemberID), -nGrandTotal, NewSellDate);
            }

            Int32 retVal;
            String errMsg;
            apiAlias.StatusMonitoring pMonitorCB = new apiAlias.StatusMonitoring(StatusMonitoring);

            creditRefundPrint = new PrintDocument();
            creditRefundPrint.PrintPage += new PrintPageEventHandler(creditRefundPrint_PrintPage);
            creditRefundPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;

            creditSigniturePrint = new PrintDocument();
            creditSigniturePrint.PrintPage += new PrintPageEventHandler(creditSigniturePrint_PrintPage);
            creditSigniturePrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;

            try
            {
                // Open Printer Monitor of Status API.
                mpHandle = apiAlias.BiOpenMonPrinter(apiAlias.TYPE_PRINTER, creditSigniturePrint.PrinterSettings.PrinterName);
                if (mpHandle < 0)
                    MessageBox.Show("Failed to open printer status monitor.", "Printing error", MessageBoxButtons.OK);
                else
                {
                    isFinish = false;
                    cancelErr = false;

                    // Set the callback function that will monitor printer status.
                    retVal = apiAlias.BiSetStatusBackFunction(mpHandle, pMonitorCB);

                    if (retVal != apiAlias.SUCCESS)
                        MessageBox.Show("Failed to set callback function.", "Printing error", MessageBoxButtons.OK);
                    else
                    {
                        if (cancelErr)
                            retVal = apiAlias.BiCancelError(mpHandle);
                        else
                        {
                            // Call the function to open cash drawer.
                            //OpenDrawer(creditSigniturePrint.PrinterSettings.PrinterName);
                            parentForm.VHReceiptID = ReceiptID;
                            creditSigniturePrint.Print();
                            creditRefundPrint.Print();
                        }

                        //if (MemberID != "101" | MemberID != "")
                        //    Calculate_Customer_Points();
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                MessageBox.Show("Failed to open StatusAPI. Printing error.", errMsg, MessageBoxButtons.OK);
            }
            finally
            {
                // Close Printer Monitor.
                if (mpHandle > 0)
                {
                    if (apiAlias.BiCloseMonPrinter(mpHandle) != apiAlias.SUCCESS)
                        MessageBox.Show("Failed to close printer status monitor.", "Printing error", MessageBoxButtons.OK);
                }
            }

            radioBtnCash.Checked = true;
            radioBtnCash.Enabled = false;
            radioBtnCredit.Enabled = false;
            radioBtnCreditTerminal.Enabled = false;
            btnRefund.Enabled = false;

            btnStoreCredit.Enabled = false;
            btnAdd.Enabled = true;
            btnReturn.Enabled = true;
            btnTransferRefund.Enabled = false;
            txtRefundAmount.Text = "0.00";

            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;

            Resetting();
        }

        /// <summary>
        /// Handles the Click event of the btnRefund control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnRefund_Click(object sender, EventArgs e)
        {
            if (txtRefundAmount.Text == "0.00")
                return;

            if (radioBtnCash.Checked == true)
            {
                if (boolSecondAuthentication == false)
                {
                    SecondAuthentication secondAuthenticationForm = new SecondAuthentication(0);
                    secondAuthenticationForm.parentForm1 = this.parentForm;
                    secondAuthenticationForm.parentForm2 = this;
                    secondAuthenticationForm.ShowDialog();
                }
                else
                {
                    if (option == 0)
                    {
                        if (Checking_Duplicated_StoreCredit(refReceiptID) == false)
                        {
                            DialogResult MyDialogResult;
                            MyDialogResult = MessageBox.Show(this, "THIS TRANSACTION WAS ALREADY RETURNED AT LEAST ONCE.\n\n" + "DO YOU WANT TO PROCEED THIS TRANSACTION?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (MyDialogResult == DialogResult.No)
                                return;
                        }

                        if (Checking_Duplicated_Refund(refReceiptID) == false)
                        {
                            DialogResult MyDialogResult;
                            MyDialogResult = MessageBox.Show(this, "THIS TRANSACTION WAS ALREADY REFUNDED AT LEAST ONCE.\n\n" + "DO YOU WANT TO PROCEED THIS TRANSACTION?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (MyDialogResult == DialogResult.No)
                                return;
                        }
                    }

                    rCnt = dataGridView2.RowCount;
                    DateTime currentTime = DateTime.Now;
                    StoreCode = parentForm.storeCode;
                    CashierID = parentForm.employeeID;
                    RegisterNum = parentForm.cashRegisterNum;
                    NewSellDate = string.Format("{0:MM/dd/yyyy}", currentTime);
                    NewSellTime = string.Format("{0:T}", currentTime);
                    mType = Get_MemberType(Convert.ToInt64(MemberID));

                    if (MemberID == "101" | MemberID == "" | MemberID == "0")
                    {
                        MemberPoints = 0;
                    }
                    else
                    {
                        if (mType == parentForm.MType1)
                        {
                            MemberPoints = Math.Round(Convert.ToDouble(-SubTotal) * (parentForm.MPts1 / 100), 2, MidpointRounding.AwayFromZero);
                        }
                        else if (mType == parentForm.MType2)
                        {
                            MemberPoints = Math.Round(Convert.ToDouble(-SubTotal) * (parentForm.MPts2 / 100), 2, MidpointRounding.AwayFromZero);
                        }
                        else if (mType == parentForm.MType3)
                        {
                            MemberPoints = Math.Round(Convert.ToDouble(-SubTotal) * (parentForm.MPts3 / 100), 2, MidpointRounding.AwayFromZero);
                        }
                        else if (mType == parentForm.MType4)
                        {
                            MemberPoints = Math.Round(Convert.ToDouble(-SubTotal) * (parentForm.MPts4 / 100), 2, MidpointRounding.AwayFromZero);
                        }
                        else if (mType == parentForm.MType5)
                        {
                            MemberPoints = Math.Round(Convert.ToDouble(-SubTotal) * (parentForm.MPts5 / 100), 2, MidpointRounding.AwayFromZero);
                        }
                        else
                        {
                            MemberPoints = 0;
                        }

                        //MemberPoints = Math.Round(Math.Round((-SubTotal), 2, MidpointRounding.AwayFromZero) * 0.05, 2, MidpointRounding.AwayFromZero);
                    }

                    ReceiptType = "RETURN";
                    ReceiptStatus = "ISSUED";

                    SqlCommand cmd_ReceiptHeader = new SqlCommand("Create_ReceiptHeader_Information", connection);
                    cmd_ReceiptHeader.CommandType = CommandType.StoredProcedure;
                    cmd_ReceiptHeader.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = StoreCode;
                    cmd_ReceiptHeader.Parameters.Add("@CashierID", SqlDbType.NVarChar).Value = managerID;
                    cmd_ReceiptHeader.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = RegisterNum;
                    cmd_ReceiptHeader.Parameters.Add("@MemberID", SqlDbType.NVarChar).Value = MemberID;
                    cmd_ReceiptHeader.Parameters.Add("@MemberName", SqlDbType.NVarChar).Value = MemberName;
                    cmd_ReceiptHeader.Parameters.Add("@PayBy", SqlDbType.Int).Value = 0;
                    cmd_ReceiptHeader.Parameters.Add("@SellDate", SqlDbType.NVarChar).Value = NewSellDate;
                    cmd_ReceiptHeader.Parameters.Add("@SellTime", SqlDbType.NVarChar).Value = NewSellTime;
                    cmd_ReceiptHeader.Parameters.Add("@SubTotal", SqlDbType.Money).Value = -SubTotal;
                    cmd_ReceiptHeader.Parameters.Add("@GrandTotal", SqlDbType.Money).Value = -nGrandTotal;
                    cmd_ReceiptHeader.Parameters.Add("@Tax", SqlDbType.Money).Value = -Tax;
                    cmd_ReceiptHeader.Parameters.Add("@Discount", SqlDbType.Money).Value = 0;
                    cmd_ReceiptHeader.Parameters.Add("@MemberPoints", SqlDbType.Money).Value = MemberPoints;
                    cmd_ReceiptHeader.Parameters.Add("@Pay", SqlDbType.Money).Value = 0;
                    cmd_ReceiptHeader.Parameters.Add("@Change", SqlDbType.Money).Value = 0;
                    cmd_ReceiptHeader.Parameters.Add("@ReceiptType", SqlDbType.NVarChar).Value = ReceiptType;
                    cmd_ReceiptHeader.Parameters.Add("@ReceiptStatus", SqlDbType.NVarChar).Value = ReceiptStatus;
                    connection.Open();
                    cmd_ReceiptHeader.ExecuteNonQuery();
                    connection.Close();

                    SqlCommand cmd_ReceiptID = new SqlCommand("Get_ReceiptID", connection);
                    cmd_ReceiptID.CommandType = CommandType.StoredProcedure;
                    cmd_ReceiptID.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = StoreCode;
                    cmd_ReceiptID.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = RegisterNum;
                    cmd_ReceiptID.Parameters.Add("@SellDate", SqlDbType.NVarChar).Value = NewSellDate;
                    cmd_ReceiptID.Parameters.Add("@SellTime", SqlDbType.NVarChar).Value = NewSellTime;
                    SqlParameter ReceiptID_Param = cmd_ReceiptID.Parameters.Add("@ReceiptID", SqlDbType.BigInt);
                    ReceiptID_Param.Direction = ParameterDirection.Output;
                    connection.Open();
                    cmd_ReceiptID.ExecuteNonQuery();
                    connection.Close();
                    ReceiptID = Convert.ToInt64(cmd_ReceiptID.Parameters["@ReceiptID"].Value);

                    for (int i = 1; i <= rCnt; i++)
                    {
                        ItmBrand = dataGridView2.Rows[i - 1].Cells[0].Value.ToString();
                        ItmName = dataGridView2.Rows[i - 1].Cells[1].Value.ToString();
                        ItmQty = dataGridView2.Rows[i - 1].Cells[2].Value.ToString();
                        ItmGroup1 = dataGridView2.Rows[i - 1].Cells[8].Value.ToString();
                        ItmGroup2 = dataGridView2.Rows[i - 1].Cells[9].Value.ToString();
                        ItmGroup3 = dataGridView2.Rows[i - 1].Cells[10].Value.ToString();
                        string ItmGroup4 = "0";
                        string ItmGroup5 = "0";
                        ItmUpc = dataGridView2.Rows[i - 1].Cells[6].Value.ToString();
                        ItmBasePrice = Convert.ToDouble(dataGridView2.Rows[i - 1].Cells[3].Value);
                        ItmDiscountPrice = Convert.ToDouble(dataGridView2.Rows[i - 1].Cells[4].Value);
                        ItmPrice = Convert.ToDouble(dataGridView2.Rows[i - 1].Cells[5].Value);
                        ItmSize = dataGridView2.Rows[i - 1].Cells[11].Value.ToString();
                        ItmColor = dataGridView2.Rows[i - 1].Cells[12].Value.ToString();

                        SqlCommand cmd_ReceiptBody = new SqlCommand("Create_ReceiptBody_Information", connection);
                        cmd_ReceiptBody.CommandType = CommandType.StoredProcedure;
                        cmd_ReceiptBody.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
                        cmd_ReceiptBody.Parameters.Add("@ItmIndex", SqlDbType.Int).Value = i;
                        cmd_ReceiptBody.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = ItmGroup1;
                        cmd_ReceiptBody.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = ItmGroup2;
                        cmd_ReceiptBody.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = ItmGroup3;
                        cmd_ReceiptBody.Parameters.Add("@ItmGroup4", SqlDbType.NVarChar).Value = ItmGroup4;
                        cmd_ReceiptBody.Parameters.Add("@ItmGroup5", SqlDbType.NVarChar).Value = ItmGroup5;
                        cmd_ReceiptBody.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                        cmd_ReceiptBody.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = ItmName;
                        cmd_ReceiptBody.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
                        cmd_ReceiptBody.Parameters.Add("@ItmBasePrice", SqlDbType.Money).Value = ItmBasePrice;
                        cmd_ReceiptBody.Parameters.Add("@ItmDiscountPrice", SqlDbType.Money).Value = ItmDiscountPrice;
                        cmd_ReceiptBody.Parameters.Add("@ItmPrice", SqlDbType.Money).Value = ItmPrice;
                        cmd_ReceiptBody.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
                        cmd_ReceiptBody.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
                        cmd_ReceiptBody.Parameters.Add("@ItmQty", SqlDbType.Int).Value = Convert.ToInt16(ItmQty);
                        cmd_ReceiptBody.Parameters.Add("@SellDate", SqlDbType.NVarChar).Value = NewSellDate;
                        cmd_ReceiptBody.Parameters.Add("@SellTime", SqlDbType.NVarChar).Value = NewSellTime;

                        if (ItmGroup1 == "10")
                        {
                            connection.Open();
                            cmd_ReceiptBody.ExecuteNonQuery();
                            connection.Close();
                        }
                        else
                        {
                            SqlCommand cmd_CalculatingOnHand = new SqlCommand("Calculating_OnHand_From_Return", connection);
                            cmd_CalculatingOnHand.CommandType = CommandType.StoredProcedure;
                            cmd_CalculatingOnHand.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = ItmGroup1;
                            cmd_CalculatingOnHand.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = ItmGroup2;
                            cmd_CalculatingOnHand.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = ItmGroup3;
                            cmd_CalculatingOnHand.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                            cmd_CalculatingOnHand.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = ItmName;
                            cmd_CalculatingOnHand.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
                            cmd_CalculatingOnHand.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
                            cmd_CalculatingOnHand.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
                            cmd_CalculatingOnHand.Parameters.Add("@ItmQty", SqlDbType.Int).Value = Convert.ToInt16(ItmQty);

                            connection.Open();
                            cmd_ReceiptBody.ExecuteNonQuery();
                            cmd_CalculatingOnHand.ExecuteNonQuery();
                            connection.Close();
                        }
                    }

                    SqlCommand cmd = new SqlCommand("Create_Refund", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = StoreCode;
                    cmd.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = parentForm.cashRegisterNum;
                    cmd.Parameters.Add("@RefReceiptID", SqlDbType.BigInt).Value = refReceiptID;
                    cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
                    cmd.Parameters.Add("@Amount", SqlDbType.Money).Value = Convert.ToDouble(txtRefundAmount.Text);
                    cmd.Parameters.Add("@RefundMethod", SqlDbType.Int).Value = 1;
                    cmd.Parameters.Add("@RefundDate", SqlDbType.NVarChar).Value = NewSellDate;
                    cmd.Parameters.Add("@RefundTime", SqlDbType.NVarChar).Value = NewSellTime;

                    if (option == 0)
                    {
                        cmd.Parameters.Add("@RefundType", SqlDbType.NVarChar).Value = "REGULAR";
                    }
                    else if (option == 1)
                    {
                        cmd.Parameters.Add("@RefundType", SqlDbType.NVarChar).Value = "MANUAL";
                    }

                    cmd.Parameters.Add("@WitnessID", SqlDbType.NVarChar).Value = witnessID;

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    SqlCommand cmd_RefundID = new SqlCommand("Get_RefundID", connection);
                    cmd_RefundID.CommandType = CommandType.StoredProcedure;
                    cmd_RefundID.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
                    SqlParameter RefundID_Param = cmd_RefundID.Parameters.Add("@RefundID", SqlDbType.BigInt);
                    RefundID_Param.Direction = ParameterDirection.Output;

                    connection.Open();
                    cmd_RefundID.ExecuteNonQuery();
                    connection.Close();
                    RefundID = Convert.ToInt64(cmd_RefundID.Parameters["@RefundID"].Value);

                    SqlCommand cmd_RefundInfo = new SqlCommand("Get_Refund_Info", connection);
                    cmd_RefundInfo.CommandType = CommandType.StoredProcedure;
                    cmd_RefundInfo.Parameters.Add("@RefundID", SqlDbType.BigInt).Value = RefundID;
                    SqlParameter Amount_Param = cmd_RefundInfo.Parameters.Add("@Amount", SqlDbType.Money);
                    SqlParameter RefundMethod_Param = cmd_RefundInfo.Parameters.Add("@RefundMethod", SqlDbType.Int);
                    SqlParameter RefundDate_Param = cmd_RefundInfo.Parameters.Add("@RefundDate", SqlDbType.NVarChar, 20);
                    SqlParameter RefundTime_Param = cmd_RefundInfo.Parameters.Add("@RefundTime", SqlDbType.NVarChar, 20);
                    SqlParameter RefundType_Param = cmd_RefundInfo.Parameters.Add("@RefundType", SqlDbType.NVarChar, 50);
                    SqlParameter WitnessID_Param = cmd_RefundInfo.Parameters.Add("@WitnessID", SqlDbType.NVarChar, 50);
                    Amount_Param.Direction = ParameterDirection.Output;
                    RefundMethod_Param.Direction = ParameterDirection.Output;
                    RefundDate_Param.Direction = ParameterDirection.Output;
                    RefundTime_Param.Direction = ParameterDirection.Output;
                    RefundType_Param.Direction = ParameterDirection.Output;
                    WitnessID_Param.Direction = ParameterDirection.Output;

                    connection.Open();
                    cmd_RefundInfo.ExecuteNonQuery();
                    connection.Close();

                    amount = Convert.ToDouble(cmd_RefundInfo.Parameters["@Amount"].Value);
                    refundMethod = PaymentMethod(Convert.ToInt16(cmd.Parameters["@RefundMethod"].Value));
                    refundDate = cmd_RefundInfo.Parameters["@RefundDate"].Value.ToString();
                    refundTime = cmd_RefundInfo.Parameters["@RefundTime"].Value.ToString();
                    refundType = cmd_RefundInfo.Parameters["@RefundType"].Value.ToString();
                    refundWitnessID = cmd_RefundInfo.Parameters["@WitnessID"].Value.ToString();

                    if (MemberID == "0" | MemberID == "101" | MemberID == "")
                    {
                    }
                    else
                    {
                        remainingPoints = Remaining_Points(parentForm.storeCode, Convert.ToInt64(MemberID));
                        double pointsGap = remainingPoints + MemberPoints;

                        if (pointsGap >= 0)
                        {
                            Calculate_Customer_Points();
                            remainingPoints = Remaining_Points(parentForm.storeCode, Convert.ToInt64(MemberID));
                        }
                        else
                        {
                            MemberPoints = MemberPoints - pointsGap;

                            Calculate_Customer_Points();
                            remainingPoints = Remaining_Points(parentForm.storeCode, Convert.ToInt64(MemberID));
                        }

                        parentForm.Customer_Transaction_Update(0, parentForm.storeCode, Convert.ToInt64(MemberID), -nGrandTotal, NewSellDate);
                    }

                    Int32 retVal;
                    String errMsg;
                    apiAlias.StatusMonitoring pMonitorCB = new apiAlias.StatusMonitoring(StatusMonitoring);

                    cashRefundPrint = new PrintDocument();
                    cashRefundPrint.PrintPage += new PrintPageEventHandler(cashRefundPrint_PrintPage);
                    cashRefundPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;

                    cashSigniturePrint = new PrintDocument();
                    cashSigniturePrint.PrintPage += new PrintPageEventHandler(cashSigniturePrint_PrintPage);
                    cashSigniturePrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;

                    try
                    {
                        // Open Printer Monitor of Status API.
                        mpHandle = apiAlias.BiOpenMonPrinter(apiAlias.TYPE_PRINTER, cashRefundPrint.PrinterSettings.PrinterName);
                        if (mpHandle < 0)
                            MessageBox.Show("Failed to open printer status monitor.", "Printing error", MessageBoxButtons.OK);
                        else
                        {
                            isFinish = false;
                            cancelErr = false;

                            // Set the callback function that will monitor printer status.
                            retVal = apiAlias.BiSetStatusBackFunction(mpHandle, pMonitorCB);

                            if (retVal != apiAlias.SUCCESS)
                                MessageBox.Show("Failed to set callback function.", "Printing error", MessageBoxButtons.OK);
                            else
                            {
                                // Start printing.
                                //cashRefundPrint.Print();

                                // Wait until callback function will say that the task is done.
                                // When done, end the monitoring of printer status.
                                //do
                                //{
                                //    if (isFinish)
                                //        retVal = apiAlias.BiCancelStatusBack(mpHandle);
                                //} while (!isFinish);

                                // Display the status/error message.
                                //DisplayStatusMessage();

                                // If an error occurred, restore the recoverable error.
                                if (cancelErr)
                                    retVal = apiAlias.BiCancelError(mpHandle);
                                else
                                {
                                    // Call the function to open cash drawer.
                                    OpenDrawer(cashRefundPrint.PrinterSettings.PrinterName);
                                    cashSigniturePrint.Print();
                                    cashRefundPrint.Print();
                                }

                                //if (MemberID != "101" | MemberID != "")
                                //    Calculate_Customer_Points();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        errMsg = ex.Message;
                        MessageBox.Show("Failed to open StatusAPI. Printing error.", errMsg, MessageBoxButtons.OK);
                    }
                    finally
                    {
                        // Close Printer Monitor.
                        if (mpHandle > 0)
                        {
                            if (apiAlias.BiCloseMonPrinter(mpHandle) != apiAlias.SUCCESS)
                                MessageBox.Show("Failed to close printer status monitor.", "Printing error", MessageBoxButtons.OK);
                        }
                    }

                    radioBtnCash.Checked = true;
                    radioBtnCash.Enabled = false;
                    radioBtnCredit.Enabled = false;
                    radioBtnCreditTerminal.Enabled = false;
                    btnRefund.Enabled = false;

                    btnStoreCredit.Enabled = false;
                    btnAdd.Enabled = true;
                    btnReturn.Enabled = true;
                    btnTransferRefund.Enabled = false;
                    txtRefundAmount.Text = "0.00";

                    dataGridView1.DataSource = null;
                    dataGridView2.DataSource = null;

                    Resetting();
                }
            }
            else if (radioBtnCredit.Checked == true)
            {
                if (option == 0)
                {
                    if (lblPayBy.Text == "VISA" | lblPayBy.Text == "MASTER" | lblPayBy.Text == "AMEX" | lblPayBy.Text == "DISCOVER")
                    {
                        /*if (Checking_Duplicated_Refund(refReceiptID) == false)
                        {
                            DialogResult MyDialogResult;
                            MyDialogResult = MessageBox.Show(this, "THIS TRANSACTION WAS ALREADY REFUNDED\n\n" + "DO YOU WANT TO PROCEED THIS TRANSACTION?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (MyDialogResult == DialogResult.No)
                                return;
                        }*/

                        if (boolSecondAuthentication == false)
                        {
                            SecondAuthentication secondAuthenticationForm = new SecondAuthentication(0);
                            secondAuthenticationForm.parentForm1 = this.parentForm;
                            secondAuthenticationForm.parentForm2 = this;
                            secondAuthenticationForm.ShowDialog();
                        }
                        else
                        {
                            if (option == 0)
                            {
                                if (Checking_Duplicated_StoreCredit(refReceiptID) == false)
                                {
                                    DialogResult MyDialogResult;
                                    MyDialogResult = MessageBox.Show(this, "THIS TRANSACTION WAS ALREADY RETURNED AT LEAST ONCE.\n\n" + "DO YOU WANT TO PROCEED THIS TRANSACTION?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                    if (MyDialogResult == DialogResult.No)
                                        return;
                                }

                                if (Checking_Duplicated_Refund(refReceiptID) == false)
                                {
                                    DialogResult MyDialogResult;
                                    MyDialogResult = MessageBox.Show(this, "THIS TRANSACTION WAS ALREADY REFUNDED AT LEAST ONCE.\n\n" + "DO YOU WANT TO PROCEED THIS TRANSACTION?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                    if (MyDialogResult == DialogResult.No)
                                        return;
                                }
                            }

                            btnVoid.Enabled = false;
                            btnRefund.Enabled = false;
                            btnClose.Enabled = false;

                            rAmount = Convert.ToDouble(txtRefundAmount.Text.Trim());
                            parentForm.Manual_Refund_Credit_Transaction(rAmount);
                        }

                        /*SqlCommand cmd_Void = new SqlCommand("Get_CloverTransactionInfo_ForVoid", connection);
                        cmd_Void.CommandType = CommandType.StoredProcedure;
                        cmd_Void.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = refReceiptID;
                        SqlParameter PID_Param = cmd_Void.Parameters.Add("@PaymentID", SqlDbType.NVarChar, 50);
                        SqlParameter OID_Param = cmd_Void.Parameters.Add("@OrderID", SqlDbType.NVarChar, 50);
                        SqlParameter Amount_Param = cmd_Void.Parameters.Add("@Amount", SqlDbType.Money);
                        SqlParameter LastFour_Param = cmd_Void.Parameters.Add("@LastFour", SqlDbType.NVarChar, 10);
                        PID_Param.Direction = ParameterDirection.Output;
                        OID_Param.Direction = ParameterDirection.Output;
                        Amount_Param.Direction = ParameterDirection.Output;
                        LastFour_Param.Direction = ParameterDirection.Output;

                        connection.Open();
                        cmd_Void.ExecuteNonQuery();
                        connection.Close();

                        if (cmd_Void.Parameters["@PaymentID"].Value != DBNull.Value)
                        {
                            oPaymentID = cmd_Void.Parameters["@PaymentID"].Value.ToString();
                        }
                        else
                        {
                            MyMessageBox.ShowBox("PAYMENT ID ERROR.", "ERROR");
                            return;
                        }

                        if (cmd_Void.Parameters["@OrderID"].Value != DBNull.Value)
                        {
                            oOrderID = cmd_Void.Parameters["@OrderID"].Value.ToString();
                        }
                        else
                        {
                            MyMessageBox.ShowBox("ORDER ID ERROR.", "ERROR");
                            return;
                        }

                        if (cmd_Void.Parameters["@LastFour"].Value != DBNull.Value)
                        {
                            oLast4 = cmd_Void.Parameters["@LastFour"].Value.ToString();
                        }

                        if (cmd_Void.Parameters["@Amount"].Value != DBNull.Value)
                        {
                            oAmount = Convert.ToDouble(cmd_Void.Parameters["@Amount"].Value);
                            rAmount = Convert.ToDouble(txtRefundAmount.Text.Trim());

                            if (oAmount == rAmount)
                            {
                                parentForm.Refund_Credit_Transaction(oPaymentID, oOrderID, oAmount, true);
                            }
                            else
                            {
                                parentForm.Refund_Credit_Transaction(oPaymentID, oOrderID, rAmount, false);
                            }
                        }
                        else
                        {
                            MyMessageBox.ShowBox("REFUND AMOUNT ERROR.", "ERROR");
                            return;
                        }*/
                    }
                    else
                    {
                        MyMessageBox.ShowBox("REGULAR CREDIT REFUND TRANSACTION IS NOT AVAILABLE BY THIS RECEIPT.", "ERROR");
                        return;
                    }
                }
                else if (option == 1)
                {
                    if (boolSecondAuthentication == false)
                    {
                        SecondAuthentication secondAuthenticationForm = new SecondAuthentication(0);
                        secondAuthenticationForm.parentForm1 = this.parentForm;
                        secondAuthenticationForm.parentForm2 = this;
                        secondAuthenticationForm.ShowDialog();
                    }
                    else
                    {
                        /*if (option == 0)
                        {
                            if (Checking_Duplicated_StoreCredit(refReceiptID) == false)
                            {
                                DialogResult MyDialogResult;
                                MyDialogResult = MessageBox.Show(this, "THIS TRANSACTION WAS ALREADY RETURNED AT LEAST ONCE.\n\n" + "DO YOU WANT TO PROCEED THIS TRANSACTION?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (MyDialogResult == DialogResult.No)
                                    return;
                            }

                            if (Checking_Duplicated_Refund(refReceiptID) == false)
                            {
                                DialogResult MyDialogResult;
                                MyDialogResult = MessageBox.Show(this, "THIS TRANSACTION WAS ALREADY REFUNDED AT LEAST ONCE.\n\n" + "DO YOU WANT TO PROCEED THIS TRANSACTION?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (MyDialogResult == DialogResult.No)
                                    return;
                            }
                        }*/

                        btnVoid.Enabled = false;
                        btnRefund.Enabled = false;
                        btnClose.Enabled = false;

                        rAmount = Convert.ToDouble(txtRefundAmount.Text.Trim());
                        parentForm.Manual_Refund_Credit_Transaction(rAmount);
                    }
                }
            }
            else if (radioBtnCreditTerminal.Checked == true)
            {
                if (boolSecondAuthentication == false)
                {
                    SecondAuthentication secondAuthenticationForm = new SecondAuthentication(0);
                    secondAuthenticationForm.parentForm1 = this.parentForm;
                    secondAuthenticationForm.parentForm2 = this;
                    secondAuthenticationForm.ShowDialog();
                }
                else
                {
                    if (option == 0)
                    {
                        if (Checking_Duplicated_StoreCredit(refReceiptID) == false)
                        {
                            DialogResult MyDialogResult;
                            MyDialogResult = MessageBox.Show(this, "THIS TRANSACTION WAS ALREADY RETURNED AT LEAST ONCE.\n\n" + "DO YOU WANT TO PROCEED THIS TRANSACTION?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (MyDialogResult == DialogResult.No)
                                return;
                        }

                        if (Checking_Duplicated_Refund(refReceiptID) == false)
                        {
                            DialogResult MyDialogResult;
                            MyDialogResult = MessageBox.Show(this, "THIS TRANSACTION WAS ALREADY REFUNDED AT LEAST ONCE.\n\n" + "DO YOU WANT TO PROCEED THIS TRANSACTION?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (MyDialogResult == DialogResult.No)
                                return;
                        }
                    }

                    rCnt = dataGridView2.RowCount;
                    DateTime currentTime = DateTime.Now;
                    StoreCode = parentForm.storeCode;
                    CashierID = parentForm.employeeID;
                    RegisterNum = parentForm.cashRegisterNum;
                    NewSellDate = string.Format("{0:MM/dd/yyyy}", currentTime);
                    NewSellTime = string.Format("{0:T}", currentTime);
                    mType = Get_MemberType(Convert.ToInt64(MemberID));

                    if (MemberID == "101" | MemberID == "" | MemberID == "0")
                    {
                        MemberPoints = 0;
                    }
                    else
                    {
                        if (mType == parentForm.MType1)
                        {
                            MemberPoints = Math.Round(Convert.ToDouble(-SubTotal) * (parentForm.MPts1 / 100), 2, MidpointRounding.AwayFromZero);
                        }
                        else if (mType == parentForm.MType2)
                        {
                            MemberPoints = Math.Round(Convert.ToDouble(-SubTotal) * (parentForm.MPts2 / 100), 2, MidpointRounding.AwayFromZero);
                        }
                        else if (mType == parentForm.MType3)
                        {
                            MemberPoints = Math.Round(Convert.ToDouble(-SubTotal) * (parentForm.MPts3 / 100), 2, MidpointRounding.AwayFromZero);
                        }
                        else if (mType == parentForm.MType4)
                        {
                            MemberPoints = Math.Round(Convert.ToDouble(-SubTotal) * (parentForm.MPts4 / 100), 2, MidpointRounding.AwayFromZero);
                        }
                        else if (mType == parentForm.MType5)
                        {
                            MemberPoints = Math.Round(Convert.ToDouble(-SubTotal) * (parentForm.MPts5 / 100), 2, MidpointRounding.AwayFromZero);
                        }
                        else
                        {
                            MemberPoints = 0;
                        }

                        //MemberPoints = Math.Round(Math.Round((-SubTotal), 2, MidpointRounding.AwayFromZero) * 0.05, 2, MidpointRounding.AwayFromZero);
                    }

                    ReceiptType = "RETURN";
                    ReceiptStatus = "ISSUED";

                    SqlCommand cmd_ReceiptHeader = new SqlCommand("Create_ReceiptHeader_Information", connection);
                    cmd_ReceiptHeader.CommandType = CommandType.StoredProcedure;
                    cmd_ReceiptHeader.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = StoreCode;
                    cmd_ReceiptHeader.Parameters.Add("@CashierID", SqlDbType.NVarChar).Value = managerID;
                    cmd_ReceiptHeader.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = RegisterNum;
                    cmd_ReceiptHeader.Parameters.Add("@MemberID", SqlDbType.NVarChar).Value = MemberID;
                    cmd_ReceiptHeader.Parameters.Add("@MemberName", SqlDbType.NVarChar).Value = MemberName;
                    cmd_ReceiptHeader.Parameters.Add("@PayBy", SqlDbType.Int).Value = 0;
                    cmd_ReceiptHeader.Parameters.Add("@SellDate", SqlDbType.NVarChar).Value = NewSellDate;
                    cmd_ReceiptHeader.Parameters.Add("@SellTime", SqlDbType.NVarChar).Value = NewSellTime;
                    cmd_ReceiptHeader.Parameters.Add("@SubTotal", SqlDbType.Money).Value = -SubTotal;
                    cmd_ReceiptHeader.Parameters.Add("@GrandTotal", SqlDbType.Money).Value = -nGrandTotal;
                    cmd_ReceiptHeader.Parameters.Add("@Tax", SqlDbType.Money).Value = -Tax;
                    cmd_ReceiptHeader.Parameters.Add("@Discount", SqlDbType.Money).Value = 0;
                    cmd_ReceiptHeader.Parameters.Add("@MemberPoints", SqlDbType.Money).Value = MemberPoints;
                    cmd_ReceiptHeader.Parameters.Add("@Pay", SqlDbType.Money).Value = 0;
                    cmd_ReceiptHeader.Parameters.Add("@Change", SqlDbType.Money).Value = 0;
                    cmd_ReceiptHeader.Parameters.Add("@ReceiptType", SqlDbType.NVarChar).Value = ReceiptType;
                    cmd_ReceiptHeader.Parameters.Add("@ReceiptStatus", SqlDbType.NVarChar).Value = ReceiptStatus;
                    connection.Open();
                    cmd_ReceiptHeader.ExecuteNonQuery();
                    connection.Close();

                    SqlCommand cmd_ReceiptID = new SqlCommand("Get_ReceiptID", connection);
                    cmd_ReceiptID.CommandType = CommandType.StoredProcedure;
                    cmd_ReceiptID.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = StoreCode;
                    cmd_ReceiptID.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = RegisterNum;
                    cmd_ReceiptID.Parameters.Add("@SellDate", SqlDbType.NVarChar).Value = NewSellDate;
                    cmd_ReceiptID.Parameters.Add("@SellTime", SqlDbType.NVarChar).Value = NewSellTime;
                    SqlParameter ReceiptID_Param = cmd_ReceiptID.Parameters.Add("@ReceiptID", SqlDbType.BigInt);
                    ReceiptID_Param.Direction = ParameterDirection.Output;
                    connection.Open();
                    cmd_ReceiptID.ExecuteNonQuery();
                    connection.Close();
                    ReceiptID = Convert.ToInt64(cmd_ReceiptID.Parameters["@ReceiptID"].Value);

                    for (int i = 1; i <= rCnt; i++)
                    {
                        ItmBrand = dataGridView2.Rows[i - 1].Cells[0].Value.ToString();
                        ItmName = dataGridView2.Rows[i - 1].Cells[1].Value.ToString();
                        ItmQty = dataGridView2.Rows[i - 1].Cells[2].Value.ToString();
                        ItmGroup1 = dataGridView2.Rows[i - 1].Cells[8].Value.ToString();
                        ItmGroup2 = dataGridView2.Rows[i - 1].Cells[9].Value.ToString();
                        ItmGroup3 = dataGridView2.Rows[i - 1].Cells[10].Value.ToString();
                        string ItmGroup4 = "0";
                        string ItmGroup5 = "0";
                        ItmUpc = dataGridView2.Rows[i - 1].Cells[6].Value.ToString();
                        ItmBasePrice = Convert.ToDouble(dataGridView2.Rows[i - 1].Cells[3].Value);
                        ItmDiscountPrice = Convert.ToDouble(dataGridView2.Rows[i - 1].Cells[4].Value);
                        ItmPrice = Convert.ToDouble(dataGridView2.Rows[i - 1].Cells[5].Value);
                        ItmSize = dataGridView2.Rows[i - 1].Cells[11].Value.ToString();
                        ItmColor = dataGridView2.Rows[i - 1].Cells[12].Value.ToString();

                        SqlCommand cmd_ReceiptBody = new SqlCommand("Create_ReceiptBody_Information", connection);
                        cmd_ReceiptBody.CommandType = CommandType.StoredProcedure;
                        cmd_ReceiptBody.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
                        cmd_ReceiptBody.Parameters.Add("@ItmIndex", SqlDbType.Int).Value = i;
                        cmd_ReceiptBody.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = ItmGroup1;
                        cmd_ReceiptBody.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = ItmGroup2;
                        cmd_ReceiptBody.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = ItmGroup3;
                        cmd_ReceiptBody.Parameters.Add("@ItmGroup4", SqlDbType.NVarChar).Value = ItmGroup4;
                        cmd_ReceiptBody.Parameters.Add("@ItmGroup5", SqlDbType.NVarChar).Value = ItmGroup5;
                        cmd_ReceiptBody.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                        cmd_ReceiptBody.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = ItmName;
                        cmd_ReceiptBody.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
                        cmd_ReceiptBody.Parameters.Add("@ItmBasePrice", SqlDbType.Money).Value = ItmBasePrice;
                        cmd_ReceiptBody.Parameters.Add("@ItmDiscountPrice", SqlDbType.Money).Value = ItmDiscountPrice;
                        cmd_ReceiptBody.Parameters.Add("@ItmPrice", SqlDbType.Money).Value = ItmPrice;
                        cmd_ReceiptBody.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
                        cmd_ReceiptBody.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
                        cmd_ReceiptBody.Parameters.Add("@ItmQty", SqlDbType.Int).Value = Convert.ToInt16(ItmQty);
                        cmd_ReceiptBody.Parameters.Add("@SellDate", SqlDbType.NVarChar).Value = NewSellDate;
                        cmd_ReceiptBody.Parameters.Add("@SellTime", SqlDbType.NVarChar).Value = NewSellTime;

                        if (ItmGroup1 == "10")
                        {
                            connection.Open();
                            cmd_ReceiptBody.ExecuteNonQuery();
                            connection.Close();
                        }
                        else
                        {
                            SqlCommand cmd_CalculatingOnHand = new SqlCommand("Calculating_OnHand_From_Return", connection);
                            cmd_CalculatingOnHand.CommandType = CommandType.StoredProcedure;
                            cmd_CalculatingOnHand.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = ItmGroup1;
                            cmd_CalculatingOnHand.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = ItmGroup2;
                            cmd_CalculatingOnHand.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = ItmGroup3;
                            cmd_CalculatingOnHand.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                            cmd_CalculatingOnHand.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = ItmName;
                            cmd_CalculatingOnHand.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
                            cmd_CalculatingOnHand.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
                            cmd_CalculatingOnHand.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
                            cmd_CalculatingOnHand.Parameters.Add("@ItmQty", SqlDbType.Int).Value = Convert.ToInt16(ItmQty);

                            connection.Open();
                            cmd_ReceiptBody.ExecuteNonQuery();
                            cmd_CalculatingOnHand.ExecuteNonQuery();
                            connection.Close();
                        }
                    }

                    SqlCommand cmd = new SqlCommand("Create_Refund", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = StoreCode;
                    cmd.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = RegisterNum;
                    cmd.Parameters.Add("@RefReceiptID", SqlDbType.BigInt).Value = refReceiptID;
                    cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
                    cmd.Parameters.Add("@Amount", SqlDbType.Money).Value = Convert.ToDouble(txtRefundAmount.Text);
                    cmd.Parameters.Add("@RefundMethod", SqlDbType.Int).Value = 3;
                    cmd.Parameters.Add("@RefundDate", SqlDbType.NVarChar).Value = NewSellDate;
                    cmd.Parameters.Add("@RefundTime", SqlDbType.NVarChar).Value = NewSellTime;

                    if (option == 0)
                    {
                        cmd.Parameters.Add("@RefundType", SqlDbType.NVarChar).Value = "REGULAR";
                    }
                    else if (option == 1)
                    {
                        cmd.Parameters.Add("@RefundType", SqlDbType.NVarChar).Value = "MANUAL";
                    }

                    cmd.Parameters.Add("@WitnessID", SqlDbType.NVarChar).Value = witnessID;

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    SqlCommand cmd_RefundID = new SqlCommand("Get_RefundID", connection);
                    cmd_RefundID.CommandType = CommandType.StoredProcedure;
                    cmd_RefundID.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
                    SqlParameter RefundID_Param = cmd_RefundID.Parameters.Add("@RefundID", SqlDbType.BigInt);
                    RefundID_Param.Direction = ParameterDirection.Output;

                    connection.Open();
                    cmd_RefundID.ExecuteNonQuery();
                    connection.Close();
                    RefundID = Convert.ToInt64(cmd_RefundID.Parameters["@RefundID"].Value);

                    SqlCommand cmd_RefundInfo = new SqlCommand("Get_Refund_Info", connection);
                    cmd_RefundInfo.CommandType = CommandType.StoredProcedure;
                    cmd_RefundInfo.Parameters.Add("@RefundID", SqlDbType.BigInt).Value = RefundID;
                    SqlParameter Amount_Param = cmd_RefundInfo.Parameters.Add("@Amount", SqlDbType.Money);
                    SqlParameter RefundMethod_Param = cmd_RefundInfo.Parameters.Add("@RefundMethod", SqlDbType.Int);
                    SqlParameter RefundDate_Param = cmd_RefundInfo.Parameters.Add("@RefundDate", SqlDbType.NVarChar, 20);
                    SqlParameter RefundTime_Param = cmd_RefundInfo.Parameters.Add("@RefundTime", SqlDbType.NVarChar, 20);
                    SqlParameter RefundType_Param = cmd_RefundInfo.Parameters.Add("@RefundType", SqlDbType.NVarChar, 50);
                    SqlParameter WitnessID_Param = cmd_RefundInfo.Parameters.Add("@WitnessID", SqlDbType.NVarChar, 50);
                    Amount_Param.Direction = ParameterDirection.Output;
                    RefundMethod_Param.Direction = ParameterDirection.Output;
                    RefundDate_Param.Direction = ParameterDirection.Output;
                    RefundTime_Param.Direction = ParameterDirection.Output;
                    RefundType_Param.Direction = ParameterDirection.Output;
                    WitnessID_Param.Direction = ParameterDirection.Output;

                    connection.Open();
                    cmd_RefundInfo.ExecuteNonQuery();
                    connection.Close();

                    amount = Convert.ToDouble(cmd_RefundInfo.Parameters["@Amount"].Value);
                    refundMethod = PaymentMethod(Convert.ToInt16(cmd.Parameters["@RefundMethod"].Value));
                    refundDate = cmd_RefundInfo.Parameters["@RefundDate"].Value.ToString();
                    refundTime = cmd_RefundInfo.Parameters["@RefundTime"].Value.ToString();
                    refundType = cmd_RefundInfo.Parameters["@RefundType"].Value.ToString();
                    refundWitnessID = cmd_RefundInfo.Parameters["@WitnessID"].Value.ToString();

                    if (MemberID == "0" | MemberID == "101" | MemberID == "")
                    {
                    }
                    else
                    {
                        remainingPoints = Remaining_Points(parentForm.storeCode, Convert.ToInt64(MemberID));
                        double pointsGap = remainingPoints + MemberPoints;

                        if (pointsGap >= 0)
                        {
                            Calculate_Customer_Points();
                            remainingPoints = Remaining_Points(parentForm.storeCode, Convert.ToInt64(MemberID));
                        }
                        else
                        {
                            MemberPoints = MemberPoints - pointsGap;

                            Calculate_Customer_Points();
                            remainingPoints = Remaining_Points(parentForm.storeCode, Convert.ToInt64(MemberID));
                        }

                        parentForm.Customer_Transaction_Update(0, parentForm.storeCode, Convert.ToInt64(MemberID), -nGrandTotal, NewSellDate);
                    }

                    Int32 retVal;
                    String errMsg;
                    apiAlias.StatusMonitoring pMonitorCB = new apiAlias.StatusMonitoring(StatusMonitoring);

                    creditTerminalPrint = new PrintDocument();
                    creditTerminalPrint.PrintPage += new PrintPageEventHandler(creditTerminalPrint_PrintPage);
                    creditTerminalPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;

                    try
                    {
                        // Open Printer Monitor of Status API.
                        mpHandle = apiAlias.BiOpenMonPrinter(apiAlias.TYPE_PRINTER, creditTerminalPrint.PrinterSettings.PrinterName);
                        if (mpHandle < 0)
                            MessageBox.Show("Failed to open printer status monitor.", "Printing error", MessageBoxButtons.OK);
                        else
                        {
                            isFinish = false;
                            cancelErr = false;

                            // Set the callback function that will monitor printer status.
                            retVal = apiAlias.BiSetStatusBackFunction(mpHandle, pMonitorCB);

                            if (retVal != apiAlias.SUCCESS)
                                MessageBox.Show("Failed to set callback function.", "Printing error", MessageBoxButtons.OK);
                            else
                            {
                                if (cancelErr)
                                    retVal = apiAlias.BiCancelError(mpHandle);
                                else
                                {
                                    // Call the function to open cash drawer.
                                    //OpenDrawer(creditTerminalPrint.PrinterSettings.PrinterName);
                                    creditTerminalPrint.Print();
                                    creditTerminalPrint.Print();
                                }

                                //if (MemberID != "101" | MemberID != "")
                                //    Calculate_Customer_Points();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        errMsg = ex.Message;
                        MessageBox.Show("Failed to open StatusAPI. Printing error", errMsg, MessageBoxButtons.OK);
                    }
                    finally
                    {
                        // Close Printer Monitor.
                        if (mpHandle > 0)
                        {
                            if (apiAlias.BiCloseMonPrinter(mpHandle) != apiAlias.SUCCESS)
                                MessageBox.Show("Failed to close printer status monitor.", "Printing error", MessageBoxButtons.OK);
                        }
                    }

                    radioBtnCash.Checked = true;
                    radioBtnCash.Enabled = false;
                    radioBtnCredit.Enabled = false;
                    radioBtnCreditTerminal.Enabled = false;
                    btnRefund.Enabled = false;

                    btnStoreCredit.Enabled = false;
                    btnAdd.Enabled = true;
                    btnReturn.Enabled = true;
                    btnTransferRefund.Enabled = false;
                    txtRefundAmount.Text = "0.00";

                    dataGridView1.DataSource = null;
                    dataGridView2.DataSource = null;

                    Resetting();
                }
            }
            else
            {
                MyMessageBox.ShowBox("PLEASE SELECT REFUND METHOD", "ERROR");
                return;
            }
        }

        /// <summary>
        /// Regulars the refund transaction.
        /// </summary>
        public void Regular_Refund_Transaction()
        {
            rCnt = dataGridView2.RowCount;

            DateTime currentTime = DateTime.Now;

            StoreCode = parentForm.storeCode;
            CashierID = parentForm.employeeID;
            RegisterNum = parentForm.cashRegisterNum;
            NewSellDate = string.Format("{0:MM/dd/yyyy}", currentTime);
            NewSellTime = string.Format("{0:T}", currentTime);
            mType = Get_MemberType(Convert.ToInt64(MemberID));

            if (MemberID == "101" | MemberID == "" | MemberID == "0")
            {
                MemberPoints = 0;
            }
            else
            {
                if (mType == parentForm.MType1)
                {
                    MemberPoints = Math.Round(Convert.ToDouble(-SubTotal) * (parentForm.MPts1 / 100), 2, MidpointRounding.AwayFromZero);
                }
                else if (mType == parentForm.MType2)
                {
                    MemberPoints = Math.Round(Convert.ToDouble(-SubTotal) * (parentForm.MPts2 / 100), 2, MidpointRounding.AwayFromZero);
                }
                else if (mType == parentForm.MType3)
                {
                    MemberPoints = Math.Round(Convert.ToDouble(-SubTotal) * (parentForm.MPts3 / 100), 2, MidpointRounding.AwayFromZero);
                }
                else if (mType == parentForm.MType4)
                {
                    MemberPoints = Math.Round(Convert.ToDouble(-SubTotal) * (parentForm.MPts4 / 100), 2, MidpointRounding.AwayFromZero);
                }
                else if (mType == parentForm.MType5)
                {
                    MemberPoints = Math.Round(Convert.ToDouble(-SubTotal) * (parentForm.MPts5 / 100), 2, MidpointRounding.AwayFromZero);
                }
                else
                {
                    MemberPoints = 0;
                }

                //MemberPoints = Math.Round(Math.Round((-SubTotal), 2, MidpointRounding.AwayFromZero) * 0.05, 2, MidpointRounding.AwayFromZero);
            }

            ReceiptType = "RETURN";
            ReceiptStatus = "ISSUED";

            SqlCommand cmd_ReceiptHeader = new SqlCommand("Create_ReceiptHeader_Information", connection);
            cmd_ReceiptHeader.CommandType = CommandType.StoredProcedure;
            cmd_ReceiptHeader.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = StoreCode;
            cmd_ReceiptHeader.Parameters.Add("@CashierID", SqlDbType.NVarChar).Value = managerID;
            cmd_ReceiptHeader.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = RegisterNum;
            cmd_ReceiptHeader.Parameters.Add("@MemberID", SqlDbType.NVarChar).Value = MemberID;
            cmd_ReceiptHeader.Parameters.Add("@MemberName", SqlDbType.NVarChar).Value = MemberName;
            cmd_ReceiptHeader.Parameters.Add("@PayBy", SqlDbType.Int).Value = 0;
            cmd_ReceiptHeader.Parameters.Add("@SellDate", SqlDbType.NVarChar).Value = NewSellDate;
            cmd_ReceiptHeader.Parameters.Add("@SellTime", SqlDbType.NVarChar).Value = NewSellTime;
            cmd_ReceiptHeader.Parameters.Add("@SubTotal", SqlDbType.Money).Value = -SubTotal;
            cmd_ReceiptHeader.Parameters.Add("@GrandTotal", SqlDbType.Money).Value = -nGrandTotal;
            cmd_ReceiptHeader.Parameters.Add("@Tax", SqlDbType.Money).Value = -Tax;
            cmd_ReceiptHeader.Parameters.Add("@Discount", SqlDbType.Money).Value = 0;
            cmd_ReceiptHeader.Parameters.Add("@MemberPoints", SqlDbType.Money).Value = MemberPoints;
            cmd_ReceiptHeader.Parameters.Add("@Pay", SqlDbType.Money).Value = 0;
            cmd_ReceiptHeader.Parameters.Add("@Change", SqlDbType.Money).Value = 0;
            cmd_ReceiptHeader.Parameters.Add("@ReceiptType", SqlDbType.NVarChar).Value = ReceiptType;
            cmd_ReceiptHeader.Parameters.Add("@ReceiptStatus", SqlDbType.NVarChar).Value = ReceiptStatus;
            connection.Open();
            cmd_ReceiptHeader.ExecuteNonQuery();
            connection.Close();

            SqlCommand cmd_ReceiptID = new SqlCommand("Get_ReceiptID", connection);
            cmd_ReceiptID.CommandType = CommandType.StoredProcedure;
            cmd_ReceiptID.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = StoreCode;
            cmd_ReceiptID.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = RegisterNum;
            cmd_ReceiptID.Parameters.Add("@SellDate", SqlDbType.NVarChar).Value = NewSellDate;
            cmd_ReceiptID.Parameters.Add("@SellTime", SqlDbType.NVarChar).Value = NewSellTime;
            SqlParameter ReceiptID_Param = cmd_ReceiptID.Parameters.Add("@ReceiptID", SqlDbType.BigInt);
            ReceiptID_Param.Direction = ParameterDirection.Output;
            connection.Open();
            cmd_ReceiptID.ExecuteNonQuery();
            connection.Close();
            ReceiptID = Convert.ToInt64(cmd_ReceiptID.Parameters["@ReceiptID"].Value);

            for (int i = 1; i <= rCnt; i++)
            {
                ItmBrand = dataGridView2.Rows[i - 1].Cells[0].Value.ToString();
                ItmName = dataGridView2.Rows[i - 1].Cells[1].Value.ToString();
                ItmQty = dataGridView2.Rows[i - 1].Cells[2].Value.ToString();
                ItmGroup1 = dataGridView2.Rows[i - 1].Cells[8].Value.ToString();
                ItmGroup2 = dataGridView2.Rows[i - 1].Cells[9].Value.ToString();
                ItmGroup3 = dataGridView2.Rows[i - 1].Cells[10].Value.ToString();
                string ItmGroup4 = "0";
                string ItmGroup5 = "0";
                ItmUpc = dataGridView2.Rows[i - 1].Cells[6].Value.ToString();
                ItmBasePrice = Convert.ToDouble(dataGridView2.Rows[i - 1].Cells[3].Value);
                ItmDiscountPrice = Convert.ToDouble(dataGridView2.Rows[i - 1].Cells[4].Value);
                ItmPrice = Convert.ToDouble(dataGridView2.Rows[i - 1].Cells[5].Value);
                ItmSize = dataGridView2.Rows[i - 1].Cells[11].Value.ToString();
                ItmColor = dataGridView2.Rows[i - 1].Cells[12].Value.ToString();

                SqlCommand cmd_ReceiptBody = new SqlCommand("Create_ReceiptBody_Information", connection);
                cmd_ReceiptBody.CommandType = CommandType.StoredProcedure;
                cmd_ReceiptBody.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
                cmd_ReceiptBody.Parameters.Add("@ItmIndex", SqlDbType.Int).Value = i;
                cmd_ReceiptBody.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = ItmGroup1;
                cmd_ReceiptBody.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = ItmGroup2;
                cmd_ReceiptBody.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = ItmGroup3;
                cmd_ReceiptBody.Parameters.Add("@ItmGroup4", SqlDbType.NVarChar).Value = ItmGroup4;
                cmd_ReceiptBody.Parameters.Add("@ItmGroup5", SqlDbType.NVarChar).Value = ItmGroup5;
                cmd_ReceiptBody.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                cmd_ReceiptBody.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = ItmName;
                cmd_ReceiptBody.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
                cmd_ReceiptBody.Parameters.Add("@ItmBasePrice", SqlDbType.Money).Value = ItmBasePrice;
                cmd_ReceiptBody.Parameters.Add("@ItmDiscountPrice", SqlDbType.Money).Value = ItmDiscountPrice;
                cmd_ReceiptBody.Parameters.Add("@ItmPrice", SqlDbType.Money).Value = ItmPrice;
                cmd_ReceiptBody.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
                cmd_ReceiptBody.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
                cmd_ReceiptBody.Parameters.Add("@ItmQty", SqlDbType.Int).Value = Convert.ToInt16(ItmQty);
                cmd_ReceiptBody.Parameters.Add("@SellDate", SqlDbType.NVarChar).Value = NewSellDate;
                cmd_ReceiptBody.Parameters.Add("@SellTime", SqlDbType.NVarChar).Value = NewSellTime;

                if (ItmGroup1 == "10")
                {
                    connection.Open();
                    cmd_ReceiptBody.ExecuteNonQuery();
                    connection.Close();
                }
                else
                {
                    SqlCommand cmd_CalculatingOnHand = new SqlCommand("Calculating_OnHand_From_Return", connection);
                    cmd_CalculatingOnHand.CommandType = CommandType.StoredProcedure;
                    cmd_CalculatingOnHand.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = ItmGroup1;
                    cmd_CalculatingOnHand.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = ItmGroup2;
                    cmd_CalculatingOnHand.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = ItmGroup3;
                    cmd_CalculatingOnHand.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                    cmd_CalculatingOnHand.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = ItmName;
                    cmd_CalculatingOnHand.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
                    cmd_CalculatingOnHand.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
                    cmd_CalculatingOnHand.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
                    cmd_CalculatingOnHand.Parameters.Add("@ItmQty", SqlDbType.Int).Value = Convert.ToInt16(ItmQty);

                    connection.Open();
                    cmd_ReceiptBody.ExecuteNonQuery();
                    cmd_CalculatingOnHand.ExecuteNonQuery();
                    connection.Close();
                }
            }

            SqlCommand cmd = new SqlCommand("Create_Refund", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = StoreCode;
            cmd.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = RegisterNum;
            cmd.Parameters.Add("@RefReceiptID", SqlDbType.BigInt).Value = refReceiptID;
            cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
            cmd.Parameters.Add("@Amount", SqlDbType.Money).Value = Convert.ToDouble(txtRefundAmount.Text);
            cmd.Parameters.Add("@RefundMethod", SqlDbType.Int).Value = ReturnCreditCardType(lblPayBy.Text);
            cmd.Parameters.Add("@RefundDate", SqlDbType.NVarChar).Value = NewSellDate;
            cmd.Parameters.Add("@RefundTime", SqlDbType.NVarChar).Value = NewSellTime;
            cmd.Parameters.Add("@RefundType", SqlDbType.NVarChar).Value = "REGULAR";

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            SqlCommand cmd_RefundID = new SqlCommand("Get_RefundID", connection);
            cmd_RefundID.CommandType = CommandType.StoredProcedure;
            cmd_RefundID.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
            SqlParameter RefundID_Param = cmd_RefundID.Parameters.Add("@RefundID", SqlDbType.BigInt);
            RefundID_Param.Direction = ParameterDirection.Output;

            connection.Open();
            cmd_RefundID.ExecuteNonQuery();
            connection.Close();
            RefundID = Convert.ToInt64(cmd_RefundID.Parameters["@RefundID"].Value);

            SqlCommand cmd_RefundInfo = new SqlCommand("Get_Refund_Info", connection);
            cmd_RefundInfo.CommandType = CommandType.StoredProcedure;
            cmd_RefundInfo.Parameters.Add("@RefundID", SqlDbType.BigInt).Value = RefundID;
            SqlParameter Amount_Param = cmd_RefundInfo.Parameters.Add("@Amount", SqlDbType.Money);
            SqlParameter RefundMethod_Param = cmd_RefundInfo.Parameters.Add("@RefundMethod", SqlDbType.Int);
            SqlParameter RefundDate_Param = cmd_RefundInfo.Parameters.Add("@RefundDate", SqlDbType.NVarChar, 20);
            SqlParameter RefundTime_Param = cmd_RefundInfo.Parameters.Add("@RefundTime", SqlDbType.NVarChar, 20);
            SqlParameter RefundType_Param = cmd_RefundInfo.Parameters.Add("@RefundType", SqlDbType.NVarChar, 50);
            Amount_Param.Direction = ParameterDirection.Output;
            RefundMethod_Param.Direction = ParameterDirection.Output;
            RefundDate_Param.Direction = ParameterDirection.Output;
            RefundTime_Param.Direction = ParameterDirection.Output;
            RefundType_Param.Direction = ParameterDirection.Output;

            connection.Open();
            cmd_RefundInfo.ExecuteNonQuery();
            connection.Close();

            amount = Convert.ToDouble(cmd_RefundInfo.Parameters["@Amount"].Value);
            refundMethod = PaymentMethod(Convert.ToInt16(cmd.Parameters["@RefundMethod"].Value));
            refundDate = cmd_RefundInfo.Parameters["@RefundDate"].Value.ToString();
            refundTime = cmd_RefundInfo.Parameters["@RefundTime"].Value.ToString();
            refundType = cmd_RefundInfo.Parameters["@RefundType"].Value.ToString();

            if (MemberID == "0" | MemberID == "101" | MemberID == "")
            {
            }
            else
            {
                remainingPoints = Remaining_Points(parentForm.storeCode, Convert.ToInt64(MemberID));
                double pointsGap = remainingPoints + MemberPoints;

                if (pointsGap >= 0)
                {
                    Calculate_Customer_Points();
                    remainingPoints = Remaining_Points(parentForm.storeCode, Convert.ToInt64(MemberID));
                }
                else
                {
                    MemberPoints = MemberPoints - pointsGap;

                    Calculate_Customer_Points();
                    remainingPoints = Remaining_Points(parentForm.storeCode, Convert.ToInt64(MemberID));
                }

                parentForm.Customer_Transaction_Update(0, parentForm.storeCode, Convert.ToInt64(MemberID), -nGrandTotal, NewSellDate);
            }

            Int32 retVal;
            String errMsg;
            apiAlias.StatusMonitoring pMonitorCB = new apiAlias.StatusMonitoring(StatusMonitoring);

            creditRefundPrint = new PrintDocument();
            creditRefundPrint.PrintPage += new PrintPageEventHandler(creditRefundPrint_PrintPage);
            creditRefundPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;

            creditSigniturePrint = new PrintDocument();
            creditSigniturePrint.PrintPage += new PrintPageEventHandler(creditSigniturePrint_PrintPage);
            creditSigniturePrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;

            try
            {
                // Open Printer Monitor of Status API.
                mpHandle = apiAlias.BiOpenMonPrinter(apiAlias.TYPE_PRINTER, creditSigniturePrint.PrinterSettings.PrinterName);
                if (mpHandle < 0)
                    MessageBox.Show("Failed to open printer status monitor.", "Printing error", MessageBoxButtons.OK);
                else
                {
                    isFinish = false;
                    cancelErr = false;

                    // Set the callback function that will monitor printer status.
                    retVal = apiAlias.BiSetStatusBackFunction(mpHandle, pMonitorCB);

                    if (retVal != apiAlias.SUCCESS)
                        MessageBox.Show("Failed to set callback function.", "Printing error", MessageBoxButtons.OK);
                    else
                    {
                        if (cancelErr)
                            retVal = apiAlias.BiCancelError(mpHandle);
                        else
                        {
                            // Call the function to open cash drawer.
                            //OpenDrawer(creditSigniturePrint.PrinterSettings.PrinterName);
                            creditSigniturePrint.Print();
                            creditRefundPrint.Print();
                        }

                        //if (MemberID != "101" | MemberID != "")
                        //    Calculate_Customer_Points();
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                MessageBox.Show("Failed to open StatusAPI. Printing error.", errMsg, MessageBoxButtons.OK);
            }
            finally
            {
                // Close Printer Monitor.
                if (mpHandle > 0)
                {
                    if (apiAlias.BiCloseMonPrinter(mpHandle) != apiAlias.SUCCESS)
                        MessageBox.Show("Failed to close printer status monitor.", "Printing error", MessageBoxButtons.OK);
                }
            }

            radioBtnCash.Checked = true;
            radioBtnCash.Enabled = false;
            radioBtnCredit.Enabled = false;
            radioBtnCreditTerminal.Enabled = false;
            btnRefund.Enabled = false;

            btnStoreCredit.Enabled = false;
            btnAdd.Enabled = true;
            btnReturn.Enabled = true;
            btnTransferRefund.Enabled = false;
            btnClose.Enabled = true;
            txtRefundAmount.Text = "0.00";

            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;

            Resetting();
        }

        /// <summary>
        /// Manuals the refund transaction.
        /// </summary>
        public void Manual_Refund_Transaction()
        {
            rCnt = dataGridView2.RowCount;

            DateTime currentTime = DateTime.Now;

            StoreCode = parentForm.storeCode;
            CashierID = parentForm.employeeID;
            RegisterNum = parentForm.cashRegisterNum;
            NewSellDate = string.Format("{0:MM/dd/yyyy}", currentTime);
            NewSellTime = string.Format("{0:T}", currentTime);
            mType = Get_MemberType(Convert.ToInt64(MemberID));

            if (MemberID == "101" | MemberID == "" | MemberID == "0")
            {
                MemberPoints = 0;
            }
            else
            {
                if (mType == parentForm.MType1)
                {
                    MemberPoints = Math.Round(Convert.ToDouble(-SubTotal) * (parentForm.MPts1 / 100), 2, MidpointRounding.AwayFromZero);
                }
                else if (mType == parentForm.MType2)
                {
                    MemberPoints = Math.Round(Convert.ToDouble(-SubTotal) * (parentForm.MPts2 / 100), 2, MidpointRounding.AwayFromZero);
                }
                else if (mType == parentForm.MType3)
                {
                    MemberPoints = Math.Round(Convert.ToDouble(-SubTotal) * (parentForm.MPts3 / 100), 2, MidpointRounding.AwayFromZero);
                }
                else if (mType == parentForm.MType4)
                {
                    MemberPoints = Math.Round(Convert.ToDouble(-SubTotal) * (parentForm.MPts4 / 100), 2, MidpointRounding.AwayFromZero);
                }
                else if (mType == parentForm.MType5)
                {
                    MemberPoints = Math.Round(Convert.ToDouble(-SubTotal) * (parentForm.MPts5 / 100), 2, MidpointRounding.AwayFromZero);
                }
                else
                {
                    MemberPoints = 0;
                }

                //MemberPoints = Math.Round(Math.Round((-SubTotal), 2, MidpointRounding.AwayFromZero) * 0.05, 2, MidpointRounding.AwayFromZero);
            }

            ReceiptType = "RETURN";
            ReceiptStatus = "ISSUED";

            SqlCommand cmd_ReceiptHeader = new SqlCommand("Create_ReceiptHeader_Information", connection);
            cmd_ReceiptHeader.CommandType = CommandType.StoredProcedure;
            cmd_ReceiptHeader.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = StoreCode;
            cmd_ReceiptHeader.Parameters.Add("@CashierID", SqlDbType.NVarChar).Value = managerID;
            cmd_ReceiptHeader.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = RegisterNum;
            cmd_ReceiptHeader.Parameters.Add("@MemberID", SqlDbType.NVarChar).Value = MemberID;
            cmd_ReceiptHeader.Parameters.Add("@MemberName", SqlDbType.NVarChar).Value = MemberName;
            cmd_ReceiptHeader.Parameters.Add("@PayBy", SqlDbType.Int).Value = 0;
            cmd_ReceiptHeader.Parameters.Add("@SellDate", SqlDbType.NVarChar).Value = NewSellDate;
            cmd_ReceiptHeader.Parameters.Add("@SellTime", SqlDbType.NVarChar).Value = NewSellTime;
            cmd_ReceiptHeader.Parameters.Add("@SubTotal", SqlDbType.Money).Value = -SubTotal;
            cmd_ReceiptHeader.Parameters.Add("@GrandTotal", SqlDbType.Money).Value = -nGrandTotal;
            cmd_ReceiptHeader.Parameters.Add("@Tax", SqlDbType.Money).Value = -Tax;
            cmd_ReceiptHeader.Parameters.Add("@Discount", SqlDbType.Money).Value = 0;
            cmd_ReceiptHeader.Parameters.Add("@MemberPoints", SqlDbType.Money).Value = MemberPoints;
            cmd_ReceiptHeader.Parameters.Add("@Pay", SqlDbType.Money).Value = 0;
            cmd_ReceiptHeader.Parameters.Add("@Change", SqlDbType.Money).Value = 0;
            cmd_ReceiptHeader.Parameters.Add("@ReceiptType", SqlDbType.NVarChar).Value = ReceiptType;
            cmd_ReceiptHeader.Parameters.Add("@ReceiptStatus", SqlDbType.NVarChar).Value = ReceiptStatus;
            connection.Open();
            cmd_ReceiptHeader.ExecuteNonQuery();
            connection.Close();

            SqlCommand cmd_ReceiptID = new SqlCommand("Get_ReceiptID", connection);
            cmd_ReceiptID.CommandType = CommandType.StoredProcedure;
            cmd_ReceiptID.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = StoreCode;
            cmd_ReceiptID.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = RegisterNum;
            cmd_ReceiptID.Parameters.Add("@SellDate", SqlDbType.NVarChar).Value = NewSellDate;
            cmd_ReceiptID.Parameters.Add("@SellTime", SqlDbType.NVarChar).Value = NewSellTime;
            SqlParameter ReceiptID_Param = cmd_ReceiptID.Parameters.Add("@ReceiptID", SqlDbType.BigInt);
            ReceiptID_Param.Direction = ParameterDirection.Output;
            connection.Open();
            cmd_ReceiptID.ExecuteNonQuery();
            connection.Close();
            ReceiptID = Convert.ToInt64(cmd_ReceiptID.Parameters["@ReceiptID"].Value);

            for (int i = 1; i <= rCnt; i++)
            {
                ItmBrand = dataGridView2.Rows[i - 1].Cells[0].Value.ToString();
                ItmName = dataGridView2.Rows[i - 1].Cells[1].Value.ToString();
                ItmQty = dataGridView2.Rows[i - 1].Cells[2].Value.ToString();
                ItmGroup1 = dataGridView2.Rows[i - 1].Cells[8].Value.ToString();
                ItmGroup2 = dataGridView2.Rows[i - 1].Cells[9].Value.ToString();
                ItmGroup3 = dataGridView2.Rows[i - 1].Cells[10].Value.ToString();
                string ItmGroup4 = "0";
                string ItmGroup5 = "0";
                ItmUpc = dataGridView2.Rows[i - 1].Cells[6].Value.ToString();
                ItmBasePrice = Convert.ToDouble(dataGridView2.Rows[i - 1].Cells[3].Value);
                ItmDiscountPrice = Convert.ToDouble(dataGridView2.Rows[i - 1].Cells[4].Value);
                ItmPrice = Convert.ToDouble(dataGridView2.Rows[i - 1].Cells[5].Value);
                ItmSize = dataGridView2.Rows[i - 1].Cells[11].Value.ToString();
                ItmColor = dataGridView2.Rows[i - 1].Cells[12].Value.ToString();

                SqlCommand cmd_ReceiptBody = new SqlCommand("Create_ReceiptBody_Information", connection);
                cmd_ReceiptBody.CommandType = CommandType.StoredProcedure;
                cmd_ReceiptBody.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
                cmd_ReceiptBody.Parameters.Add("@ItmIndex", SqlDbType.Int).Value = i;
                cmd_ReceiptBody.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = ItmGroup1;
                cmd_ReceiptBody.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = ItmGroup2;
                cmd_ReceiptBody.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = ItmGroup3;
                cmd_ReceiptBody.Parameters.Add("@ItmGroup4", SqlDbType.NVarChar).Value = ItmGroup4;
                cmd_ReceiptBody.Parameters.Add("@ItmGroup5", SqlDbType.NVarChar).Value = ItmGroup5;
                cmd_ReceiptBody.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                cmd_ReceiptBody.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = ItmName;
                cmd_ReceiptBody.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
                cmd_ReceiptBody.Parameters.Add("@ItmBasePrice", SqlDbType.Money).Value = ItmBasePrice;
                cmd_ReceiptBody.Parameters.Add("@ItmDiscountPrice", SqlDbType.Money).Value = ItmDiscountPrice;
                cmd_ReceiptBody.Parameters.Add("@ItmPrice", SqlDbType.Money).Value = ItmPrice;
                cmd_ReceiptBody.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
                cmd_ReceiptBody.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
                cmd_ReceiptBody.Parameters.Add("@ItmQty", SqlDbType.Int).Value = Convert.ToInt16(ItmQty);
                cmd_ReceiptBody.Parameters.Add("@SellDate", SqlDbType.NVarChar).Value = NewSellDate;
                cmd_ReceiptBody.Parameters.Add("@SellTime", SqlDbType.NVarChar).Value = NewSellTime;

                if (ItmGroup1 == "10")
                {
                    connection.Open();
                    cmd_ReceiptBody.ExecuteNonQuery();
                    connection.Close();
                }
                else
                {
                    SqlCommand cmd_CalculatingOnHand = new SqlCommand("Calculating_OnHand_From_Return", connection);
                    cmd_CalculatingOnHand.CommandType = CommandType.StoredProcedure;
                    cmd_CalculatingOnHand.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = ItmGroup1;
                    cmd_CalculatingOnHand.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = ItmGroup2;
                    cmd_CalculatingOnHand.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = ItmGroup3;
                    cmd_CalculatingOnHand.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                    cmd_CalculatingOnHand.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = ItmName;
                    cmd_CalculatingOnHand.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
                    cmd_CalculatingOnHand.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
                    cmd_CalculatingOnHand.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
                    cmd_CalculatingOnHand.Parameters.Add("@ItmQty", SqlDbType.Int).Value = Convert.ToInt16(ItmQty);

                    connection.Open();
                    cmd_ReceiptBody.ExecuteNonQuery();
                    cmd_CalculatingOnHand.ExecuteNonQuery();
                    connection.Close();
                }
            }

            try
            {
                SqlCommand cmd_RefCreditTransaction = new SqlCommand("Create_RefCloverTransaction", connection);
                cmd_RefCreditTransaction.CommandType = CommandType.StoredProcedure;
                cmd_RefCreditTransaction.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
                cmd_RefCreditTransaction.Parameters.Add("@PaymentID", SqlDbType.NVarChar).Value = "";
                cmd_RefCreditTransaction.Parameters.Add("@CreditID", SqlDbType.NVarChar).Value = CPcreditID;
                cmd_RefCreditTransaction.Parameters.Add("@OrderID", SqlDbType.NVarChar).Value = CPorderID;
                cmd_RefCreditTransaction.Parameters.Add("@ExternalPaymentID", SqlDbType.NVarChar).Value = "";
                cmd_RefCreditTransaction.Parameters.Add("@ReferenceID", SqlDbType.NVarChar).Value = CPreferenceID;
                cmd_RefCreditTransaction.Parameters.Add("@CreatedTime", SqlDbType.BigInt).Value = CPcreatedTime;
                cmd_RefCreditTransaction.Parameters.Add("@TransactionLabel", SqlDbType.NVarChar).Value = CPtransactionLabel;
                cmd_RefCreditTransaction.Parameters.Add("@AuthCode", SqlDbType.NVarChar).Value = "";
                cmd_RefCreditTransaction.Parameters.Add("@LastFour", SqlDbType.NVarChar).Value = CPlast4;
                cmd_RefCreditTransaction.Parameters.Add("@CardType", SqlDbType.NVarChar).Value = CPcardType.ToUpper();
                cmd_RefCreditTransaction.Parameters.Add("@EntryType", SqlDbType.NVarChar).Value = CPentryType;
                cmd_RefCreditTransaction.Parameters.Add("@CardHolderName", SqlDbType.NVarChar).Value = "";
                cmd_RefCreditTransaction.Parameters.Add("@AID", SqlDbType.NVarChar).Value = "N/A";
                cmd_RefCreditTransaction.Parameters.Add("@Verification", SqlDbType.NVarChar).Value = "";
                cmd_RefCreditTransaction.Parameters.Add("@Amount", SqlDbType.Money).Value = Convert.ToDouble(txtRefundAmount.Text);
                cmd_RefCreditTransaction.Parameters.Add("@IssueDate", SqlDbType.NVarChar).Value = CPsellDate;
                cmd_RefCreditTransaction.Parameters.Add("@IssueTime", SqlDbType.NVarChar).Value = CPsellTime;

                connection.Open();
                cmd_RefCreditTransaction.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();

                MyMessageBox.ShowBox("CLOVER TRANSACTION CREATION ERROR", "ERROR");
            }

            SqlCommand cmd = new SqlCommand("Create_Refund", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = StoreCode;
            cmd.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = RegisterNum;
            cmd.Parameters.Add("@RefReceiptID", SqlDbType.BigInt).Value = refReceiptID;
            cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
            cmd.Parameters.Add("@Amount", SqlDbType.Money).Value = Convert.ToDouble(txtRefundAmount.Text);
            cmd.Parameters.Add("@RefundMethod", SqlDbType.Int).Value = ReturnCreditCardType(CPcardType);
            cmd.Parameters.Add("@RefundDate", SqlDbType.NVarChar).Value = NewSellDate;
            cmd.Parameters.Add("@RefundTime", SqlDbType.NVarChar).Value = NewSellTime;

            if (option == 0)
            {
                cmd.Parameters.Add("@RefundType", SqlDbType.NVarChar).Value = "REGULAR";
            }
            else if (option == 1)
            {
                cmd.Parameters.Add("@RefundType", SqlDbType.NVarChar).Value = "MANUAL";
            }

            cmd.Parameters.Add("@WitnessID", SqlDbType.NVarChar).Value = witnessID;

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            SqlCommand cmd_RefundID = new SqlCommand("Get_RefundID", connection);
            cmd_RefundID.CommandType = CommandType.StoredProcedure;
            cmd_RefundID.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
            SqlParameter RefundID_Param = cmd_RefundID.Parameters.Add("@RefundID", SqlDbType.BigInt);
            RefundID_Param.Direction = ParameterDirection.Output;

            connection.Open();
            cmd_RefundID.ExecuteNonQuery();
            connection.Close();
            RefundID = Convert.ToInt64(cmd_RefundID.Parameters["@RefundID"].Value);

            SqlCommand cmd_RefundInfo = new SqlCommand("Get_Refund_Info", connection);
            cmd_RefundInfo.CommandType = CommandType.StoredProcedure;
            cmd_RefundInfo.Parameters.Add("@RefundID", SqlDbType.BigInt).Value = RefundID;
            SqlParameter Amount_Param = cmd_RefundInfo.Parameters.Add("@Amount", SqlDbType.Money);
            SqlParameter RefundMethod_Param = cmd_RefundInfo.Parameters.Add("@RefundMethod", SqlDbType.Int);
            SqlParameter RefundDate_Param = cmd_RefundInfo.Parameters.Add("@RefundDate", SqlDbType.NVarChar, 20);
            SqlParameter RefundTime_Param = cmd_RefundInfo.Parameters.Add("@RefundTime", SqlDbType.NVarChar, 20);
            SqlParameter RefundType_Param = cmd_RefundInfo.Parameters.Add("@RefundType", SqlDbType.NVarChar, 50);
            SqlParameter WitnessID_Param = cmd_RefundInfo.Parameters.Add("@WitnessID", SqlDbType.NVarChar, 50);
            Amount_Param.Direction = ParameterDirection.Output;
            RefundMethod_Param.Direction = ParameterDirection.Output;
            RefundDate_Param.Direction = ParameterDirection.Output;
            RefundTime_Param.Direction = ParameterDirection.Output;
            RefundType_Param.Direction = ParameterDirection.Output;
            WitnessID_Param.Direction = ParameterDirection.Output;

            connection.Open();
            cmd_RefundInfo.ExecuteNonQuery();
            connection.Close();

            amount = Convert.ToDouble(cmd_RefundInfo.Parameters["@Amount"].Value);
            refundMethod = PaymentMethod(Convert.ToInt16(cmd.Parameters["@RefundMethod"].Value));
            refundDate = cmd_RefundInfo.Parameters["@RefundDate"].Value.ToString();
            refundTime = cmd_RefundInfo.Parameters["@RefundTime"].Value.ToString();
            refundType = cmd_RefundInfo.Parameters["@RefundType"].Value.ToString();
            refundWitnessID = cmd_RefundInfo.Parameters["@WitnessID"].Value.ToString();

            if (MemberID == "0" | MemberID == "101" | MemberID == "")
            {
            }
            else
            {
                remainingPoints = Remaining_Points(parentForm.storeCode, Convert.ToInt64(MemberID));
                double pointsGap = remainingPoints + MemberPoints;

                if (pointsGap >= 0)
                {
                    Calculate_Customer_Points();
                    remainingPoints = Remaining_Points(parentForm.storeCode, Convert.ToInt64(MemberID));
                }
                else
                {
                    MemberPoints = MemberPoints - pointsGap;

                    Calculate_Customer_Points();
                    remainingPoints = Remaining_Points(parentForm.storeCode, Convert.ToInt64(MemberID));
                }

                parentForm.Customer_Transaction_Update(0, parentForm.storeCode, Convert.ToInt64(MemberID), -nGrandTotal, NewSellDate);
            }

            Int32 retVal;
            String errMsg;
            apiAlias.StatusMonitoring pMonitorCB = new apiAlias.StatusMonitoring(StatusMonitoring);

            creditRefundPrint = new PrintDocument();
            creditRefundPrint.PrintPage += new PrintPageEventHandler(creditRefundPrint_PrintPage);
            creditRefundPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;

            creditSigniturePrint = new PrintDocument();
            creditSigniturePrint.PrintPage += new PrintPageEventHandler(creditSigniturePrint_PrintPage);
            creditSigniturePrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;

            try
            {
                // Open Printer Monitor of Status API.
                mpHandle = apiAlias.BiOpenMonPrinter(apiAlias.TYPE_PRINTER, creditSigniturePrint.PrinterSettings.PrinterName);
                if (mpHandle < 0)
                    MessageBox.Show("Failed to open printer status monitor.", "Printing error", MessageBoxButtons.OK);
                else
                {
                    isFinish = false;
                    cancelErr = false;

                    // Set the callback function that will monitor printer status.
                    retVal = apiAlias.BiSetStatusBackFunction(mpHandle, pMonitorCB);

                    if (retVal != apiAlias.SUCCESS)
                        MessageBox.Show("Failed to set callback function.", "Printing error", MessageBoxButtons.OK);
                    else
                    {
                        if (cancelErr)
                            retVal = apiAlias.BiCancelError(mpHandle);
                        else
                        {
                            // Call the function to open cash drawer.
                            //OpenDrawer(creditSigniturePrint.PrinterSettings.PrinterName);
                            creditSigniturePrint.Print();
                            creditRefundPrint.Print();
                        }

                        //if (MemberID != "101" | MemberID != "")
                        //    Calculate_Customer_Points();
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                MessageBox.Show("Failed to open StatusAPI. Printing error.", errMsg, MessageBoxButtons.OK);
            }
            finally
            {
                // Close Printer Monitor.
                if (mpHandle > 0)
                {
                    if (apiAlias.BiCloseMonPrinter(mpHandle) != apiAlias.SUCCESS)
                        MessageBox.Show("Failed to close printer status monitor.", "Printing error", MessageBoxButtons.OK);
                }
            }

            radioBtnCash.Checked = true;
            radioBtnCash.Enabled = false;
            radioBtnCredit.Enabled = false;
            radioBtnCreditTerminal.Enabled = false;
            btnRefund.Enabled = false;

            btnStoreCredit.Enabled = false;
            btnAdd.Enabled = true;
            btnReturn.Enabled = true;
            btnTransferRefund.Enabled = false;
            btnClose.Enabled = true;
            txtRefundAmount.Text = "0.00";

            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;

            Resetting();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the radioBtnCash control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void radioBtnCash_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnCash.Checked == true)
            {
                radioBtnCash.BackColor = Color.Green;
                radioBtnCredit.BackColor = Color.PaleGreen;
                radioBtnCreditTerminal.BackColor = Color.PaleGreen;

                btnRefund.Enabled = true;
                btnVoid.Enabled = false;
            }
            else if (radioBtnCredit.Checked == true)
            {
                radioBtnCash.BackColor = Color.PaleGreen;
                radioBtnCredit.BackColor = Color.Green;
                radioBtnCreditTerminal.BackColor = Color.PaleGreen;

                btnRefund.Enabled = true;
                btnVoid.Enabled = true;
            }
            else if (radioBtnCreditTerminal.Checked == true)
            {
                radioBtnCash.BackColor = Color.PaleGreen;
                radioBtnCredit.BackColor = Color.PaleGreen;
                radioBtnCreditTerminal.BackColor = Color.Green;

                btnRefund.Enabled = true;
                btnVoid.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the radioBtnCredit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void radioBtnCredit_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnCash.Checked == true)
            {
                radioBtnCash.BackColor = Color.Green;
                radioBtnCredit.BackColor = Color.PaleGreen;
                radioBtnCreditTerminal.BackColor = Color.PaleGreen;

                btnRefund.Enabled = true;
                btnVoid.Enabled = false;
            }
            else if (radioBtnCredit.Checked == true)
            {
                radioBtnCash.BackColor = Color.PaleGreen;
                radioBtnCredit.BackColor = Color.Green;
                radioBtnCreditTerminal.BackColor = Color.PaleGreen;

                if (option == 0)
                {
                    btnRefund.Enabled = true;
                    btnVoid.Enabled = true;
                }
                else if (option == 1)
                {
                    btnRefund.Enabled = true;
                    btnVoid.Enabled = false;
                }
            }
            else if (radioBtnCreditTerminal.Checked == true)
            {
                radioBtnCash.BackColor = Color.PaleGreen;
                radioBtnCredit.BackColor = Color.PaleGreen;
                radioBtnCreditTerminal.BackColor = Color.Green;

                btnRefund.Enabled = true;
                btnVoid.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the radioBtnCreditTerminal control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void radioBtnCreditTerminal_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnCash.Checked == true)
            {
                radioBtnCash.BackColor = Color.Green;
                radioBtnCredit.BackColor = Color.PaleGreen;
                radioBtnCreditTerminal.BackColor = Color.PaleGreen;

                btnRefund.Enabled = true;
                btnVoid.Enabled = false;
            }
            else if (radioBtnCredit.Checked == true)
            {
                radioBtnCash.BackColor = Color.PaleGreen;
                radioBtnCredit.BackColor = Color.Green;
                radioBtnCreditTerminal.BackColor = Color.PaleGreen;

                btnRefund.Enabled = true;
                btnVoid.Enabled = true;
            }
            else if (radioBtnCreditTerminal.Checked == true)
            {
                radioBtnCash.BackColor = Color.PaleGreen;
                radioBtnCredit.BackColor = Color.PaleGreen;
                radioBtnCreditTerminal.BackColor = Color.Green;

                btnRefund.Enabled = true;
                btnVoid.Enabled = false;
            }
        }

        /// <summary>
        /// Sets the variables.
        /// </summary>
        /// <param name="idx">The index.</param>
        private void Set_Variables(int idx)
        {
            if (dataGridView1.Enabled == true)
            {
                brand = Convert.ToString(dataGridView1.Rows[idx].Cells[0].Value);
                name = Convert.ToString(dataGridView1.Rows[idx].Cells[1].Value);
                maxQty = Convert.ToString(dataGridView1.Rows[idx].Cells[2].Value);
                basePrice = Convert.ToDouble(dataGridView1.Rows[idx].Cells[3].Value);
                discountPrice = Convert.ToDouble(dataGridView1.Rows[idx].Cells[4].Value);

                if (Convert.ToDouble(dataGridView1.Rows[idx].Cells[4].Value) == 0 & Convert.ToDouble(dataGridView1.Rows[idx].Cells[5].Value) == 0)
                {
                    price = 0;
                }
                else if (Convert.ToDouble(dataGridView1.Rows[idx].Cells[4].Value) > 0)
                {
                    price = Convert.ToDouble(dataGridView1.Rows[idx].Cells[4].Value);
                }
                else if (Convert.ToDouble(dataGridView1.Rows[idx].Cells[4].Value) < 0)
                {
                    price = Convert.ToDouble(dataGridView1.Rows[idx].Cells[4].Value);
                }
                else
                {
                    price = Convert.ToDouble(dataGridView1.Rows[idx].Cells[3].Value);
                }

                upc = Convert.ToString(dataGridView1.Rows[idx].Cells[6].Value);
                index = Convert.ToString(dataGridView1.Rows[idx].Cells[7].Value);
                ItmGp1 = Convert.ToString(dataGridView1.Rows[idx].Cells[8].Value);
                ItmGp2 = Convert.ToString(dataGridView1.Rows[idx].Cells[9].Value);
                ItmGp3 = Convert.ToString(dataGridView1.Rows[idx].Cells[10].Value);
                size = Convert.ToString(dataGridView1.Rows[idx].Cells[11].Value);
                color = Convert.ToString(dataGridView1.Rows[idx].Cells[12].Value);
                sellDate = Convert.ToString(dataGridView1.Rows[idx].Cells[13].Value);
                sellTime = Convert.ToString(dataGridView1.Rows[idx].Cells[14].Value);
            }
            else
            {
                brand = Convert.ToString(parentForm.dataGridView1.Rows[idx].Cells[0].Value);
                name = Convert.ToString(parentForm.dataGridView1.Rows[idx].Cells[1].Value);
                maxQty = Convert.ToString(parentForm.dataGridView1.Rows[idx].Cells[2].Value);
                basePrice = Convert.ToDouble(parentForm.dataGridView1.Rows[idx].Cells[3].Value);
                discountPrice = Convert.ToDouble(parentForm.dataGridView1.Rows[idx].Cells[4].Value);
                price = Convert.ToDouble(parentForm.dataGridView1.Rows[idx].Cells[5].Value);
                upc = Convert.ToString(parentForm.dataGridView1.Rows[idx].Cells[7].Value);
                index = "";
                ItmGp1 = Convert.ToString(parentForm.dataGridView1.Rows[idx].Cells[8].Value);
                ItmGp2 = Convert.ToString(parentForm.dataGridView1.Rows[idx].Cells[9].Value);
                ItmGp3 = Convert.ToString(parentForm.dataGridView1.Rows[idx].Cells[10].Value);
                size = Convert.ToString(parentForm.dataGridView1.Rows[idx].Cells[13].Value);
                color = Convert.ToString(parentForm.dataGridView1.Rows[idx].Cells[14].Value);
                sellDate = "";
                sellTime = "";
            }
        }

        /*/// <summary>
        /// Handles the PrintPage event of the storeCreditPrint control. - Original
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PrintPageEventArgs"/> instance containing the event data.</param>
        private void storeCreditPrint_PrintPage(object sender, PrintPageEventArgs e)
        {
            ArrayList text = new ArrayList();
            Single yPos, yPos2, xPos;
            int ctr, ctr2, ctrTemp;

            printFont = new Font("Arial", 10);
            printFont2 = new Font("Arial", 9);
            //printFont3 = new Font("Arial", 7, FontStyle.Bold);
            printFont3 = new Font("Arial", 8);
            printFont4 = new Font("Arial", 12);
            printBoldFont = new Font("Arial", 14, FontStyle.Bold);
            barcodeFont = new Font("3 of 9 Barcode", 25);

            //text.Add("BEAUTY 4 U");
            //text.Add("10654 CAMPUS WAY SOUTH");
            //text.Add("UPPER MARLBORO, MD 20774");
            //text.Add("TEL : 301-333-1430");
            text.Add(parentForm.companyName);
            text.Add(parentForm.storeStreet);
            text.Add(parentForm.storeCityState);
            text.Add(parentForm.storeTelephone);
            text.Add(" ");
            text.Add(" ");
            text.Add(" ");
            text.Add(" ");

            text.Add("PAYMENT METHOD");
            text.Add(":");
            text.Add("RETURN");
            text.Add("DATE & TIME");
            text.Add(":");
            text.Add(Convert.ToString(NewSellDate) + " " + Convert.ToString(NewSellTime));
            text.Add("RECEIPT ID");
            text.Add(":");
            text.Add(parentForm.storeCode + "-" + Convert.ToString(ReceiptID));
            text.Add("CASHIER ID");
            text.Add(":");
            text.Add(Convert.ToString(managerID));
            text.Add("REGISTER NO");
            text.Add(":");
            text.Add(Convert.ToString(RegisterNum));
            text.Add("MEMBER ID");
            text.Add(":");
            text.Add(Convert.ToString(MemberID));
            text.Add("MEMBER NAME");
            text.Add(":");
            text.Add(Convert.ToString(MemberName));
            text.Add("----------------------------------------------------------------");
            text.Add("       DESCRIPTION                         QTY     PRICE    ");
            text.Add("----------------------------------------------------------------");

            SqlCommand cmd_Count = new SqlCommand("Get_Item_Count_From_ReceiptBody", parentForm.conn);
            cmd_Count.CommandType = CommandType.StoredProcedure;
            cmd_Count.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
            SqlParameter ItmCount_Param = cmd_Count.Parameters.Add("@ItmCount", SqlDbType.Int);
            ItmCount_Param.Direction = ParameterDirection.Output;
            parentForm.conn.Open();
            cmd_Count.ExecuteNonQuery();
            parentForm.conn.Close();
            int ItmCount = Convert.ToInt16(cmd_Count.Parameters["@ItmCount"].Value);

            for (int a = 1; a <= ItmCount; a++)
            {
                SqlCommand cmd = new SqlCommand("Get_Item_From_ReceiptBody", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
                cmd.Parameters.Add("@ItmIndex", SqlDbType.Int).Value = a;
                SqlParameter ItmName_Param = cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar, 50);
                SqlParameter ItmQty_Param = cmd.Parameters.Add("@ItmQty", SqlDbType.Int);
                SqlParameter ItmBasePrice_Param = cmd.Parameters.Add("@ItmBasePrice", SqlDbType.Money);
                SqlParameter ItmDiscountPrice_Param = cmd.Parameters.Add("@ItmDiscountPrice", SqlDbType.Money);
                SqlParameter ItmPrice_Param = cmd.Parameters.Add("@ItmPrice", SqlDbType.Money);
                SqlParameter ItmUpc_Param = cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar, 20);
                ItmName_Param.Direction = ParameterDirection.Output;
                ItmQty_Param.Direction = ParameterDirection.Output;
                ItmBasePrice_Param.Direction = ParameterDirection.Output;
                ItmDiscountPrice_Param.Direction = ParameterDirection.Output;
                ItmPrice_Param.Direction = ParameterDirection.Output;
                ItmUpc_Param.Direction = ParameterDirection.Output;
                parentForm.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm.conn.Close();
                ItmName = cmd.Parameters["@ItmName"].Value.ToString();
                ItmQty = cmd.Parameters["@ItmQty"].Value.ToString();
                ItmBasePrice = Convert.ToDouble(cmd.Parameters["@ItmBasePrice"].Value);
                ItmDiscountPrice = Convert.ToDouble(cmd.Parameters["@ItmDiscountPrice"].Value);
                ItmPrice = Convert.ToDouble(cmd.Parameters["@ItmPrice"].Value);
                ItmUpc = cmd.Parameters["@ItmUpc"].Value.ToString();

                if (ItmDiscountPrice != 0)
                {
                    text.Add(ItmName);
                    text.Add(ItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", ItmPrice) + " T");
                    text.Add(ItmUpc);
                    text.Add("-PURCHASE PRICE: " + string.Format("{0:$0.00}", ItmDiscountPrice) + " * " + ItmQty + " =" + string.Format("{0:$0.00}", ItmPrice));
                    text.Add(" ");
                }
                else
                {
                    text.Add(ItmName);
                    text.Add(ItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", ItmPrice) + " T");
                    text.Add(ItmUpc);
                    text.Add("-PURCHASE PRICE: " + string.Format("{0:$0.00}", ItmBasePrice) + " * " + ItmQty + " = " + string.Format("{0:$0.00}", ItmPrice));
                    text.Add(" ");
                }
            }

            text.Add("----------------------------------------------------------------");
            text.Add("SUB TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:   - 0.00}", SubTotal));
            text.Add("SALES TAX");
            text.Add("$");
            text.Add(string.Format("{0:   - 0.00}", Tax));
            text.Add("RETURN TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:   - 0.00}", nGrandTotal));

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            ctr = 0;
            yPos = ctr * printBoldFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printBoldFont, Brushes.Black, 83, yPos);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            xPos = (e.PageBounds.Width + parentForm.ss) - e.Graphics.MeasureString((string)text[ctr], printFont).Width;
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, xPos, yPos + 10, sf);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            xPos = (e.PageBounds.Width + parentForm.scs) - e.Graphics.MeasureString((string)text[ctr], printFont).Width;
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, xPos, yPos + 10, sf);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            xPos = (e.PageBounds.Width + parentForm.st) - e.Graphics.MeasureString((string)text[ctr], printFont).Width;
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, xPos, yPos + 10, sf);

            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 77, yPos + 10);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 77, yPos + 10);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 77, yPos + 10);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 77, yPos + 10);

            ctrTemp = ctr;
            for (ctr = 8; ctr <= 28; ctr += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr + 1], printFont2, Brushes.Black, 120, yPos + 3);
                e.Graphics.DrawString((String)text[ctr + 2], printFont2, Brushes.Black, 125, yPos + 3);
                ctrTemp += 1;
            }

            ctr = 29;
            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctr += 1;
            ctrTemp += 1;
            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctr += 1;
            ctrTemp += 1;
            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            printItmCount = (ItmCount * 7) + 31;

            for (ctr2 = 32; ctr2 <= printItmCount; ctr2 += 7)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 3], printFont3).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont3, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont3, Brushes.Black, 208, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont3, Brushes.Black, 225, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 3], printFont3, Brushes.Black, xPos, yPos + 3);
                ctrTemp += 1;
                yPos2 = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2 + 4], printFont3, Brushes.Black, 0, yPos2 + 3);
                ctrTemp += 1;
                yPos2 = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2 + 5], printFont3, Brushes.Black, 0, yPos2 + 3);
                ctrTemp += 1;
                yPos2 = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2 + 6], printFont3, Brushes.Black, 0, yPos2 + 3);
                ctrTemp += 1;
            }

            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr2], printFont2, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            for (ctr2 = printItmCount + 2; ctr2 <= text.Count - 4; ctr2 += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 2], printFont2).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont2, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont2, Brushes.Black, 215, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont2, Brushes.Black, xPos, yPos + 3);
                ctrTemp += 1;
            }

            for (ctr2 = printItmCount + 8; ctr2 <= text.Count - 1; ctr2 += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 2], printFont4).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont4, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont4, Brushes.Black, 200, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont4, Brushes.Black, xPos, yPos + 3);
                ctrTemp += 1;
            }

            text.Add(" ");
            text.Add(" ");
            text.Add(" ");
            text.Add("STORE CREDIT");
            text.Add(" ");
            text.Add(" ");

            for (ctr2 = text.Count - 6; ctr2 <= text.Count - 1; ctr2++)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2], printBoldFont, Brushes.Black, 75, yPos);
                ctrTemp += 1;
            }

            text.Add("STORE CREDIT ID");
            text.Add(":");
            text.Add(Convert.ToString(StoreCreditID));
            text.Add("STORE CODE");
            text.Add(":");
            text.Add(Convert.ToString(StoreCode));
            text.Add("AMOUNT");
            text.Add(":");
            text.Add(string.Format("{0:c}", amount));
            text.Add("BALANCE");
            text.Add(":");
            text.Add("$" + Convert.ToString(balance));
            text.Add("EXPIRATION DATE");
            text.Add(":");
            text.Add(Convert.ToString(expDate));

            for (ctr2 = text.Count - 15; ctr2 <= text.Count - 1; ctr2 += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2], printFont2, Brushes.Black, 50, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont2, Brushes.Black, 170, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont2, Brushes.Black, 175, yPos + 3);
                ctrTemp += 1;
            }

            text.Add(" ");
            text.Add(parentForm.SP_Line1);
            text.Add(parentForm.SP_Line2);
            text.Add(parentForm.SP_Line3);
            text.Add(parentForm.SP_Line4);
            text.Add(parentForm.SP_Line5);
            text.Add(parentForm.SP_Line6);
            text.Add(parentForm.SP_Line7);
            text.Add(parentForm.SP_Line8);
            text.Add(parentForm.SP_Line9);
            text.Add(parentForm.SP_Line10);
            text.Add(parentForm.SP_Line11);
            text.Add(parentForm.SP_Line12);
            text.Add(parentForm.SP_Line13);
            text.Add(parentForm.SP_Line14);
            text.Add(parentForm.SP_Line15);
            text.Add(parentForm.SP_Line16);
            text.Add(parentForm.SP_Line17);
            text.Add(parentForm.SP_Line18);
            text.Add(parentForm.SP_Line19);
            text.Add(parentForm.SP_Line20);
            text.Add(" ");
            text.Add(" ");

            for (ctr2 = text.Count - 23; ctr2 <= text.Count - 1; ctr2++)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2], printFont, Brushes.Black, 0, yPos + 3);
                ctrTemp += 1;
            }

            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString("*" + Convert.ToString(ReceiptID) + "*", barcodeFont, Brushes.Black, 55, yPos + 3);
            ctrTemp += 1;

            text.Add(" ");
            text.Add(" ");
            text.Add(parentForm.receiptLastComment);

            for (ctr2 = text.Count - 3; ctr2 <= text.Count - 1; ctr2++)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2], printFont, Brushes.Black, 0, yPos + 3);
                ctrTemp += 1;
            }

            e.HasMorePages = false;
        }*/

        /// <summary>
        /// Handles the PrintPage event of the storeCreditPrint control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PrintPageEventArgs"/> instance containing the event data.</param>
        private void storeCreditPrint_PrintPage(object sender, PrintPageEventArgs e)
        {
            ArrayList text = new ArrayList();
            Single yPos, yPos2, xPos;
            int ctr, ctr2, ctrTemp;

            printFont = new Font("Arial", 10);
            printFont2 = new Font("Arial", 9);
            printFont3 = new Font("Arial", 8);
            printFont4 = new Font("Arial", 12);
            printBoldFont = new Font("Arial", 14, FontStyle.Bold);
            barcodeFont = new Font("3 of 9 Barcode", 25);

            text.Add(parentForm.companyName);
            text.Add(parentForm.storeStreet);
            text.Add(parentForm.storeCityState);
            text.Add(parentForm.storeTelephone);
            text.Add(" ");
            text.Add(" ");
            text.Add(" ");
            text.Add(" ");

            text.Add("PAYMENT METHOD");
            text.Add(":");
            text.Add("RETURN");
            text.Add("DATE & TIME");
            text.Add(":");
            text.Add(Convert.ToString(NewSellDate) + " " + Convert.ToString(NewSellTime));
            text.Add("RECEIPT ID");
            text.Add(":");
            text.Add(parentForm.storeCode + "-" + Convert.ToString(ReceiptID));
            text.Add("MANAGER ID");
            text.Add(":");
            text.Add(Convert.ToString(managerID));
            text.Add("WITNESS ID");
            text.Add(":");
            text.Add(Convert.ToString(witnessID));
            text.Add("REGISTER NO");
            text.Add(":");
            text.Add(Convert.ToString(RegisterNum));
            text.Add("MEMBER ID");
            text.Add(":");
            text.Add(Convert.ToString(MemberID));
            text.Add("MEMBER NAME");
            text.Add(":");
            text.Add(Convert.ToString(MemberName));
            text.Add("----------------------------------------------------------------");
            text.Add("       DESCRIPTION                         QTY     PRICE    ");
            text.Add("----------------------------------------------------------------");

            SqlCommand cmd_Count = new SqlCommand("Get_Item_Count_From_ReceiptBody", parentForm.conn);
            cmd_Count.CommandType = CommandType.StoredProcedure;
            cmd_Count.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
            SqlParameter ItmCount_Param = cmd_Count.Parameters.Add("@ItmCount", SqlDbType.Int);
            ItmCount_Param.Direction = ParameterDirection.Output;
            parentForm.conn.Open();
            cmd_Count.ExecuteNonQuery();
            parentForm.conn.Close();
            int ItmCount = Convert.ToInt16(cmd_Count.Parameters["@ItmCount"].Value);

            for (int a = 1; a <= ItmCount; a++)
            {
                SqlCommand cmd = new SqlCommand("Get_Item_From_ReceiptBody", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
                cmd.Parameters.Add("@ItmIndex", SqlDbType.Int).Value = a;
                SqlParameter ItmName_Param = cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar, 50);
                SqlParameter ItmQty_Param = cmd.Parameters.Add("@ItmQty", SqlDbType.Int);
                SqlParameter ItmBasePrice_Param = cmd.Parameters.Add("@ItmBasePrice", SqlDbType.Money);
                SqlParameter ItmDiscountPrice_Param = cmd.Parameters.Add("@ItmDiscountPrice", SqlDbType.Money);
                SqlParameter ItmPrice_Param = cmd.Parameters.Add("@ItmPrice", SqlDbType.Money);
                SqlParameter ItmUpc_Param = cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar, 20);
                ItmName_Param.Direction = ParameterDirection.Output;
                ItmQty_Param.Direction = ParameterDirection.Output;
                ItmBasePrice_Param.Direction = ParameterDirection.Output;
                ItmDiscountPrice_Param.Direction = ParameterDirection.Output;
                ItmPrice_Param.Direction = ParameterDirection.Output;
                ItmUpc_Param.Direction = ParameterDirection.Output;
                parentForm.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm.conn.Close();
                ItmName = cmd.Parameters["@ItmName"].Value.ToString();
                ItmQty = cmd.Parameters["@ItmQty"].Value.ToString();
                ItmBasePrice = Convert.ToDouble(cmd.Parameters["@ItmBasePrice"].Value);
                ItmDiscountPrice = Convert.ToDouble(cmd.Parameters["@ItmDiscountPrice"].Value);
                ItmPrice = Convert.ToDouble(cmd.Parameters["@ItmPrice"].Value);
                ItmUpc = cmd.Parameters["@ItmUpc"].Value.ToString();

                if (ItmDiscountPrice != 0)
                {
                    text.Add(ItmName);
                    text.Add(ItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", ItmPrice) + " T");
                    text.Add(ItmUpc);
                    text.Add("-PURCHASE PRICE: " + string.Format("{0:$0.00}", ItmDiscountPrice) + " * " + ItmQty + " =" + string.Format("{0:$0.00}", ItmPrice));
                    text.Add(" ");
                }
                else
                {
                    text.Add(ItmName);
                    text.Add(ItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", ItmPrice) + " T");
                    text.Add(ItmUpc);
                    text.Add("-PURCHASE PRICE: " + string.Format("{0:$0.00}", ItmBasePrice) + " * " + ItmQty + " = " + string.Format("{0:$0.00}", ItmPrice));
                    text.Add(" ");
                }
            }

            text.Add("----------------------------------------------------------------");
            text.Add("SUB TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:   - 0.00}", SubTotal));
            text.Add("SALES TAX");
            text.Add("$");
            text.Add(string.Format("{0:   - 0.00}", Tax));
            text.Add("RETURN TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:   - 0.00}", nGrandTotal));

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            ctr = 0;
            yPos = ctr * printBoldFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printBoldFont, Brushes.Black, 83, yPos);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            xPos = (e.PageBounds.Width + parentForm.ss) - e.Graphics.MeasureString((string)text[ctr], printFont).Width;
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, xPos, yPos + 10, sf);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            xPos = (e.PageBounds.Width + parentForm.scs) - e.Graphics.MeasureString((string)text[ctr], printFont).Width;
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, xPos, yPos + 10, sf);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            xPos = (e.PageBounds.Width + parentForm.st) - e.Graphics.MeasureString((string)text[ctr], printFont).Width;
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, xPos, yPos + 10, sf);

            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 77, yPos + 10);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 77, yPos + 10);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 77, yPos + 10);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 77, yPos + 10);

            ctrTemp = ctr;
            for (ctr = 8; ctr <= 31; ctr += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr + 1], printFont2, Brushes.Black, 120, yPos + 3);
                e.Graphics.DrawString((String)text[ctr + 2], printFont2, Brushes.Black, 125, yPos + 3);
                ctrTemp += 1;
            }

            ctr = 32;
            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctr += 1;
            ctrTemp += 1;
            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctr += 1;
            ctrTemp += 1;
            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            printItmCount = (ItmCount * 7) + 34;

            for (ctr2 = 35; ctr2 <= printItmCount; ctr2 += 7)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 3], printFont3).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont3, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont3, Brushes.Black, 208, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont3, Brushes.Black, 225, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 3], printFont3, Brushes.Black, xPos, yPos + 3);
                ctrTemp += 1;
                yPos2 = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2 + 4], printFont3, Brushes.Black, 0, yPos2 + 3);
                ctrTemp += 1;
                yPos2 = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2 + 5], printFont3, Brushes.Black, 0, yPos2 + 3);
                ctrTemp += 1;
                yPos2 = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2 + 6], printFont3, Brushes.Black, 0, yPos2 + 3);
                ctrTemp += 1;
            }

            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr2], printFont2, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            for (ctr2 = printItmCount + 2; ctr2 <= text.Count - 4; ctr2 += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 2], printFont2).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont2, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont2, Brushes.Black, 215, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont2, Brushes.Black, xPos, yPos + 3);
                ctrTemp += 1;
            }

            for (ctr2 = printItmCount + 8; ctr2 <= text.Count - 1; ctr2 += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 2], printFont4).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont4, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont4, Brushes.Black, 200, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont4, Brushes.Black, xPos, yPos + 3);
                ctrTemp += 1;
            }

            text.Add(" ");
            text.Add(" ");
            text.Add(" ");
            text.Add("STORE CREDIT");
            text.Add(" ");
            text.Add(" ");

            for (ctr2 = text.Count - 6; ctr2 <= text.Count - 1; ctr2++)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2], printBoldFont, Brushes.Black, 75, yPos);
                ctrTemp += 1;
            }

            text.Add("STORE CREDIT ID");
            text.Add(":");
            text.Add(Convert.ToString(StoreCreditID));
            text.Add("STORE CODE");
            text.Add(":");
            text.Add(Convert.ToString(StoreCode));
            text.Add("AMOUNT");
            text.Add(":");
            text.Add(string.Format("{0:c}", amount));
            text.Add("BALANCE");
            text.Add(":");
            text.Add("$" + Convert.ToString(balance));
            text.Add("EXPIRATION DATE");
            text.Add(":");
            text.Add(Convert.ToString(expDate));

            for (ctr2 = text.Count - 15; ctr2 <= text.Count - 1; ctr2 += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2], printFont2, Brushes.Black, 50, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont2, Brushes.Black, 170, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont2, Brushes.Black, 175, yPos + 3);
                ctrTemp += 1;
            }

            text.Add(" ");
            text.Add(parentForm.SP_Line1);
            text.Add(parentForm.SP_Line2);
            text.Add(parentForm.SP_Line3);
            text.Add(parentForm.SP_Line4);
            text.Add(parentForm.SP_Line5);
            text.Add(parentForm.SP_Line6);
            text.Add(parentForm.SP_Line7);
            text.Add(parentForm.SP_Line8);
            text.Add(parentForm.SP_Line9);
            text.Add(parentForm.SP_Line10);
            text.Add(parentForm.SP_Line11);
            text.Add(parentForm.SP_Line12);
            text.Add(parentForm.SP_Line13);
            text.Add(parentForm.SP_Line14);
            text.Add(parentForm.SP_Line15);
            text.Add(parentForm.SP_Line16);
            text.Add(parentForm.SP_Line17);
            text.Add(parentForm.SP_Line18);
            text.Add(parentForm.SP_Line19);
            text.Add(parentForm.SP_Line20);
            text.Add(" ");
            text.Add(" ");

            for (ctr2 = text.Count - 23; ctr2 <= text.Count - 1; ctr2++)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2], printFont, Brushes.Black, 0, yPos + 3);
                ctrTemp += 1;
            }

            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString("*" + Convert.ToString(ReceiptID) + "*", barcodeFont, Brushes.Black, 55, yPos + 3);
            ctrTemp += 1;

            text.Add(" ");
            text.Add(" ");
            text.Add(parentForm.receiptLastComment);

            for (ctr2 = text.Count - 3; ctr2 <= text.Count - 1; ctr2++)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2], printFont, Brushes.Black, 0, yPos + 3);
                ctrTemp += 1;
            }

            e.HasMorePages = false;
        }

        /// <summary>
        /// Handles the PrintPage event of the cashRefundPrint control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PrintPageEventArgs"/> instance containing the event data.</param>
        private void cashRefundPrint_PrintPage(object sender, PrintPageEventArgs e)
        {
            ArrayList text = new ArrayList();
            Single yPos, yPos2, xPos;
            int ctr, ctr2, ctrTemp;

            printFont = new Font("Arial", 10);
            printFont2 = new Font("Arial", 9);
            //printFont3 = new Font("Arial", 7, FontStyle.Bold);
            printFont3 = new Font("Arial", 8);
            printFont4 = new Font("Arial", 12);
            printBoldFont = new Font("Arial", 14, FontStyle.Bold);
            barcodeFont = new Font("3 of 9 Barcode", 25);

            //text.Add("BEAUTY 4 U");
            //text.Add("10654 CAMPUS WAY SOUTH");
            //text.Add("UPPER MARLBORO, MD 20774");
            //text.Add("TEL : 301-333-1430");
            text.Add(parentForm.companyName);
            text.Add(parentForm.storeStreet);
            text.Add(parentForm.storeCityState);
            text.Add(parentForm.storeTelephone);
            text.Add(" ");
            text.Add(" ");
            text.Add(" ");
            text.Add(" ");

            text.Add("PAYMENT METHOD");
            text.Add(":");
            text.Add("RETURN");
            text.Add("DATE & TIME");
            text.Add(":");
            text.Add(Convert.ToString(NewSellDate) + " " + Convert.ToString(NewSellTime));
            text.Add("RECEIPT ID");
            text.Add(":");
            text.Add(parentForm.storeCode + "-" + Convert.ToString(ReceiptID));
            text.Add("MANAGER ID");
            text.Add(":");
            text.Add(Convert.ToString(managerID));
            text.Add("WITNESS ID");
            text.Add(":");
            text.Add(Convert.ToString(witnessID));
            text.Add("REGISTER NO");
            text.Add(":");
            text.Add(Convert.ToString(RegisterNum));
            text.Add("MEMBER ID");
            text.Add(":");
            text.Add(Convert.ToString(MemberID));
            text.Add("MEMBER NAME");
            text.Add(":");
            text.Add(Convert.ToString(MemberName));
            text.Add("----------------------------------------------------------------");
            text.Add("       DESCRIPTION                         QTY     PRICE    ");
            text.Add("----------------------------------------------------------------");

            SqlCommand cmd_Count = new SqlCommand("Get_Item_Count_From_ReceiptBody", parentForm.conn);
            cmd_Count.CommandType = CommandType.StoredProcedure;
            cmd_Count.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
            SqlParameter ItmCount_Param = cmd_Count.Parameters.Add("@ItmCount", SqlDbType.Int);
            ItmCount_Param.Direction = ParameterDirection.Output;
            parentForm.conn.Open();
            cmd_Count.ExecuteNonQuery();
            parentForm.conn.Close();
            int ItmCount = Convert.ToInt16(cmd_Count.Parameters["@ItmCount"].Value);

            for (int a = 1; a <= ItmCount; a++)
            {
                SqlCommand cmd = new SqlCommand("Get_Item_From_ReceiptBody", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
                cmd.Parameters.Add("@ItmIndex", SqlDbType.Int).Value = a;
                SqlParameter ItmName_Param = cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar, 50);
                SqlParameter ItmQty_Param = cmd.Parameters.Add("@ItmQty", SqlDbType.Int);
                SqlParameter ItmBasePrice_Param = cmd.Parameters.Add("@ItmBasePrice", SqlDbType.Money);
                SqlParameter ItmDiscountPrice_Param = cmd.Parameters.Add("@ItmDiscountPrice", SqlDbType.Money);
                SqlParameter ItmPrice_Param = cmd.Parameters.Add("@ItmPrice", SqlDbType.Money);
                SqlParameter ItmUpc_Param = cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar, 20);
                ItmName_Param.Direction = ParameterDirection.Output;
                ItmQty_Param.Direction = ParameterDirection.Output;
                ItmBasePrice_Param.Direction = ParameterDirection.Output;
                ItmDiscountPrice_Param.Direction = ParameterDirection.Output;
                ItmPrice_Param.Direction = ParameterDirection.Output;
                ItmUpc_Param.Direction = ParameterDirection.Output;
                parentForm.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm.conn.Close();
                ItmName = cmd.Parameters["@ItmName"].Value.ToString();
                ItmQty = cmd.Parameters["@ItmQty"].Value.ToString();
                ItmBasePrice = Convert.ToDouble(cmd.Parameters["@ItmBasePrice"].Value);
                ItmDiscountPrice = Convert.ToDouble(cmd.Parameters["@ItmDiscountPrice"].Value);
                ItmPrice = Convert.ToDouble(cmd.Parameters["@ItmPrice"].Value);
                ItmUpc = cmd.Parameters["@ItmUpc"].Value.ToString();

                if (ItmDiscountPrice != 0)
                {
                    text.Add(ItmName);
                    text.Add(ItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", ItmPrice) + " T");
                    text.Add(ItmUpc);
                    text.Add("-PURCHASE PRICE: " + string.Format("{0:$0.00}", ItmDiscountPrice) + " * " + ItmQty + " =" + string.Format("{0:$0.00}", ItmPrice));
                    text.Add(" ");
                }
                else
                {
                    text.Add(ItmName);
                    text.Add(ItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", ItmPrice) + " T");
                    text.Add(ItmUpc);
                    text.Add("-PURCHASE PRICE: " + string.Format("{0:$0.00}", ItmBasePrice) + " * " + ItmQty + " = " + string.Format("{0:$0.00}", ItmPrice));
                    text.Add(" ");
                }
            }

            text.Add("----------------------------------------------------------------");
            text.Add("SUB TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:   - 0.00}", SubTotal));
            text.Add("SALES TAX");
            text.Add("$");
            text.Add(string.Format("{0:   - 0.00}", Tax));
            text.Add("RETURN TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:   - 0.00}", nGrandTotal));

            /*ctr = 0;
            yPos = ctr * printBoldFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printBoldFont, Brushes.Black, 83, yPos);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 50, yPos + 10);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 50, yPos + 10);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 77, yPos + 10);*/

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            ctr = 0;
            yPos = ctr * printBoldFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printBoldFont, Brushes.Black, 83, yPos);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            xPos = (e.PageBounds.Width + parentForm.ss) - e.Graphics.MeasureString((string)text[ctr], printFont).Width;
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, xPos, yPos + 10, sf);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            xPos = (e.PageBounds.Width + parentForm.scs) - e.Graphics.MeasureString((string)text[ctr], printFont).Width;
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, xPos, yPos + 10, sf);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            xPos = (e.PageBounds.Width + parentForm.st) - e.Graphics.MeasureString((string)text[ctr], printFont).Width;
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, xPos, yPos + 10, sf);

            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 77, yPos + 10);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 77, yPos + 10);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 77, yPos + 10);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 77, yPos + 10);

            ctrTemp = ctr;
            for (ctr = 8; ctr <= 31; ctr += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr + 1], printFont2, Brushes.Black, 120, yPos + 3);
                e.Graphics.DrawString((String)text[ctr + 2], printFont2, Brushes.Black, 125, yPos + 3);
                ctrTemp += 1;
            }

            ctr = 32;
            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctr += 1;
            ctrTemp += 1;
            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctr += 1;
            ctrTemp += 1;
            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            printItmCount = (ItmCount * 7) + 34;

            for (ctr2 = 35; ctr2 <= printItmCount; ctr2 += 7)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 3], printFont3).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont3, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont3, Brushes.Black, 208, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont3, Brushes.Black, 225, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 3], printFont3, Brushes.Black, xPos, yPos + 3);
                ctrTemp += 1;
                yPos2 = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2 + 4], printFont3, Brushes.Black, 0, yPos2 + 3);
                ctrTemp += 1;
                yPos2 = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2 + 5], printFont3, Brushes.Black, 0, yPos2 + 3);
                ctrTemp += 1;
                yPos2 = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2 + 6], printFont3, Brushes.Black, 0, yPos2 + 3);
                ctrTemp += 1;
            }

            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr2], printFont2, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            for (ctr2 = printItmCount + 2; ctr2 <= text.Count - 4; ctr2 += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 2], printFont2).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont2, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont2, Brushes.Black, 215, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont2, Brushes.Black, xPos, yPos + 3);
                ctrTemp += 1;
            }

            for (ctr2 = printItmCount + 8; ctr2 <= text.Count - 1; ctr2 += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 2], printFont4).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont4, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont4, Brushes.Black, 200, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont4, Brushes.Black, xPos, yPos + 3);
                ctrTemp += 1;
            }

            text.Add(" ");
            text.Add(" ");
            text.Add("REFUND");
            text.Add(" ");

            for (ctr2 = text.Count - 4; ctr2 <= text.Count - 1; ctr2++)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2], printBoldFont, Brushes.Black, 100, yPos);
                ctrTemp += 1;
            }

            text.Add("REFUND ID");
            text.Add(":");
            text.Add(Convert.ToString(RefundID));
            text.Add("AMOUNT");
            text.Add(":");
            text.Add(string.Format("{0:c}", amount));
            text.Add("REFUND METHOD");
            text.Add(":");
            text.Add(refundMethod);
            text.Add("REFUND DATE");
            text.Add(":");
            text.Add(Convert.ToString(refundDate));
            text.Add("REFUND TIME");
            text.Add(":");
            text.Add(Convert.ToString(refundTime));
            text.Add("REFUND TYPE");
            text.Add(":");
            text.Add(refundType);

            for (ctr2 = text.Count - 18; ctr2 <= text.Count - 1; ctr2 += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                //xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 2], printFont2).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont2, Brushes.Black, 50, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont2, Brushes.Black, 170, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont2, Brushes.Black, 175, yPos + 3);
                ctrTemp += 1;
            }

            text.Add(" ");
            //text.Add("    All items can exchange or receive");
            //text.Add("    Beauty4U store credit within 14 days");
            //text.Add("    from the date of purchase with original");
            //text.Add("    condition & receipt presented. ");
            //text.Add("    Except the following: Electrical equipment");
            //text.Add("    /Appliances exchange only. Wig, Ponytail,");
            //text.Add("    Cosmetic, Hair Care, Jewelry, Slipper,");
            //text.Add("    Sandal, Hat and Sale Item are final sale.");
            text.Add(parentForm.SP_Line1);
            text.Add(parentForm.SP_Line2);
            text.Add(parentForm.SP_Line3);
            text.Add(parentForm.SP_Line4);
            text.Add(parentForm.SP_Line5);
            text.Add(parentForm.SP_Line6);
            text.Add(parentForm.SP_Line7);
            text.Add(parentForm.SP_Line8);
            text.Add(parentForm.SP_Line9);
            text.Add(parentForm.SP_Line10);
            text.Add(parentForm.SP_Line11);
            text.Add(parentForm.SP_Line12);
            text.Add(parentForm.SP_Line13);
            text.Add(parentForm.SP_Line14);
            text.Add(parentForm.SP_Line15);
            text.Add(parentForm.SP_Line16);
            text.Add(parentForm.SP_Line17);
            text.Add(parentForm.SP_Line18);
            text.Add(parentForm.SP_Line19);
            text.Add(parentForm.SP_Line20);
            text.Add(" ");
            text.Add(" ");

            for (ctr2 = text.Count - 23; ctr2 <= text.Count - 1; ctr2++)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2], printFont, Brushes.Black, 0, yPos + 3);
                ctrTemp += 1;
            }

            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString("*" + Convert.ToString(ReceiptID) + "*", barcodeFont, Brushes.Black, 55, yPos + 3);
            ctrTemp += 1;

            text.Add(" ");
            text.Add(" ");
            //text.Add("               Thank you for shopping !");
            text.Add(parentForm.receiptLastComment);

            for (ctr2 = text.Count - 3; ctr2 <= text.Count - 1; ctr2++)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2], printFont, Brushes.Black, 0, yPos + 3);
                ctrTemp += 1;
            }

            e.HasMorePages = false;
        }

        /// <summary>
        /// Handles the PrintPage event of the cashSigniturePrint control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PrintPageEventArgs"/> instance containing the event data.</param>
        private void cashSigniturePrint_PrintPage(object sender, PrintPageEventArgs e)
        {
            ArrayList text = new ArrayList();
            Single yPos, yPos2, xPos;
            int ctr, ctr2, ctrTemp;

            printFont = new Font("Arial", 10);
            printFont2 = new Font("Arial", 9);
            //printFont3 = new Font("Arial", 7, FontStyle.Bold);
            printFont3 = new Font("Arial", 8);
            printFont4 = new Font("Arial", 12);
            printFont5 = new Font("Arial", 10, FontStyle.Underline);
            printBoldFont = new Font("Arial", 14, FontStyle.Bold);
            printBoldFont2 = new Font("Arial", 18);

            //text.Add("BEAUTY 4 U");
            //text.Add("10654 CAMPUS WAY SOUTH");
            //text.Add("UPPER MARLBORO, MD 20774");
            //text.Add("TEL : 301-333-1430");
            text.Add(parentForm.companyName);
            text.Add(parentForm.storeStreet);
            text.Add(parentForm.storeCityState);
            text.Add(parentForm.storeTelephone);
            text.Add(" ");
            text.Add(" ");
            text.Add(" ");
            text.Add(" ");

            text.Add("PAYMENT METHOD");
            text.Add(":");
            text.Add("RETURN");
            text.Add("DATE & TIME");
            text.Add(":");
            text.Add(Convert.ToString(NewSellDate) + " " + Convert.ToString(NewSellTime));
            text.Add("RECEIPT ID");
            text.Add(":");
            text.Add(parentForm.storeCode + "-" + Convert.ToString(ReceiptID));
            text.Add("MANAGER ID");
            text.Add(":");
            text.Add(Convert.ToString(managerID));
            text.Add("WITNESS ID");
            text.Add(":");
            text.Add(Convert.ToString(witnessID));
            text.Add("REGISTER NO");
            text.Add(":");
            text.Add(Convert.ToString(RegisterNum));
            text.Add("MEMBER ID");
            text.Add(":");
            text.Add(Convert.ToString(MemberID));
            text.Add("MEMBER NAME");
            text.Add(":");
            text.Add(Convert.ToString(MemberName));
            text.Add("----------------------------------------------------------------");
            text.Add("       DESCRIPTION                         QTY     PRICE    ");
            text.Add("----------------------------------------------------------------");

            SqlCommand cmd_Count = new SqlCommand("Get_Item_Count_From_ReceiptBody", parentForm.conn);
            cmd_Count.CommandType = CommandType.StoredProcedure;
            cmd_Count.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
            SqlParameter ItmCount_Param = cmd_Count.Parameters.Add("@ItmCount", SqlDbType.Int);
            ItmCount_Param.Direction = ParameterDirection.Output;
            parentForm.conn.Open();
            cmd_Count.ExecuteNonQuery();
            parentForm.conn.Close();
            int ItmCount = Convert.ToInt16(cmd_Count.Parameters["@ItmCount"].Value);

            for (int a = 1; a <= ItmCount; a++)
            {
                SqlCommand cmd = new SqlCommand("Get_Item_From_ReceiptBody", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
                cmd.Parameters.Add("@ItmIndex", SqlDbType.Int).Value = a;
                SqlParameter ItmName_Param = cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar, 50);
                SqlParameter ItmQty_Param = cmd.Parameters.Add("@ItmQty", SqlDbType.Int);
                SqlParameter ItmBasePrice_Param = cmd.Parameters.Add("@ItmBasePrice", SqlDbType.Money);
                SqlParameter ItmDiscountPrice_Param = cmd.Parameters.Add("@ItmDiscountPrice", SqlDbType.Money);
                SqlParameter ItmPrice_Param = cmd.Parameters.Add("@ItmPrice", SqlDbType.Money);
                SqlParameter ItmUpc_Param = cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar, 20);
                ItmName_Param.Direction = ParameterDirection.Output;
                ItmQty_Param.Direction = ParameterDirection.Output;
                ItmBasePrice_Param.Direction = ParameterDirection.Output;
                ItmDiscountPrice_Param.Direction = ParameterDirection.Output;
                ItmPrice_Param.Direction = ParameterDirection.Output;
                ItmUpc_Param.Direction = ParameterDirection.Output;
                parentForm.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm.conn.Close();
                ItmName = cmd.Parameters["@ItmName"].Value.ToString();
                ItmQty = cmd.Parameters["@ItmQty"].Value.ToString();
                ItmBasePrice = Convert.ToDouble(cmd.Parameters["@ItmBasePrice"].Value);
                ItmDiscountPrice = Convert.ToDouble(cmd.Parameters["@ItmDiscountPrice"].Value);
                ItmPrice = Convert.ToDouble(cmd.Parameters["@ItmPrice"].Value);
                ItmUpc = cmd.Parameters["@ItmUpc"].Value.ToString();

                if (ItmDiscountPrice != 0)
                {
                    text.Add(ItmName);
                    text.Add(ItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", ItmPrice) + " T");
                    text.Add(ItmUpc);
                    text.Add("-PURCHASE PRICE: " + string.Format("{0:$0.00}", ItmDiscountPrice) + " * " + ItmQty + " =" + string.Format("{0:$0.00}", ItmPrice));
                    text.Add(" ");
                }
                else
                {
                    text.Add(ItmName);
                    text.Add(ItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", ItmPrice) + " T");
                    text.Add(ItmUpc);
                    text.Add("-PURCHASE PRICE: " + string.Format("{0:$0.00}", ItmBasePrice) + " * " + ItmQty + " = " + string.Format("{0:$0.00}", ItmPrice));
                    text.Add(" ");
                }
            }

            text.Add("----------------------------------------------------------------");
            text.Add("SUB TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:   - 0.00}", SubTotal));
            text.Add("SALES TAX");
            text.Add("$");
            text.Add(string.Format("{0:   - 0.00}", Tax));
            text.Add("RETURN TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:   - 0.00}", nGrandTotal));

            /*ctr = 0;
            yPos = ctr * printBoldFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printBoldFont, Brushes.Black, 83, yPos);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 50, yPos + 10);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 50, yPos + 10);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 77, yPos + 10);*/

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            ctr = 0;
            yPos = ctr * printBoldFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printBoldFont, Brushes.Black, 83, yPos);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            xPos = (e.PageBounds.Width + parentForm.ss) - e.Graphics.MeasureString((string)text[ctr], printFont).Width;
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, xPos, yPos + 10, sf);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            xPos = (e.PageBounds.Width + parentForm.scs) - e.Graphics.MeasureString((string)text[ctr], printFont).Width;
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, xPos, yPos + 10, sf);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            xPos = (e.PageBounds.Width + parentForm.st) - e.Graphics.MeasureString((string)text[ctr], printFont).Width;
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, xPos, yPos + 10, sf);

            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 77, yPos + 10);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 77, yPos + 10);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 77, yPos + 10);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 77, yPos + 10);

            ctrTemp = ctr;
            for (ctr = 8; ctr <= 31; ctr += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr + 1], printFont2, Brushes.Black, 120, yPos + 3);
                e.Graphics.DrawString((String)text[ctr + 2], printFont2, Brushes.Black, 125, yPos + 3);
                ctrTemp += 1;
            }

            ctr = 32;
            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctr += 1;
            ctrTemp += 1;
            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctr += 1;
            ctrTemp += 1;
            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            printItmCount = (ItmCount * 7) + 34;

            for (ctr2 = 35; ctr2 <= printItmCount; ctr2 += 7)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 3], printFont3).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont3, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont3, Brushes.Black, 208, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont3, Brushes.Black, 225, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 3], printFont3, Brushes.Black, xPos, yPos + 3);
                ctrTemp += 1;
                yPos2 = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2 + 4], printFont3, Brushes.Black, 0, yPos2 + 3);
                ctrTemp += 1;
                yPos2 = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2 + 5], printFont3, Brushes.Black, 0, yPos2 + 3);
                ctrTemp += 1;
                yPos2 = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2 + 6], printFont3, Brushes.Black, 0, yPos2 + 3);
                ctrTemp += 1;
            }

            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr2], printFont2, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            for (ctr2 = printItmCount + 2; ctr2 <= text.Count - 4; ctr2 += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 2], printFont2).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont2, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont2, Brushes.Black, 215, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont2, Brushes.Black, xPos, yPos + 3);
                ctrTemp += 1;
            }

            for (ctr2 = printItmCount + 8; ctr2 <= text.Count - 1; ctr2 += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 2], printFont4).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont4, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont4, Brushes.Black, 200, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont4, Brushes.Black, xPos, yPos + 3);
                ctrTemp += 1;
            }

            text.Add(" ");
            text.Add(" ");
            text.Add("REFUND");
            text.Add(" ");

            for (ctr2 = text.Count - 4; ctr2 <= text.Count - 1; ctr2++)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2], printBoldFont, Brushes.Black, 100, yPos);
                ctrTemp += 1;
            }

            text.Add("REFUND ID");
            text.Add(":");
            text.Add(Convert.ToString(RefundID));
            text.Add("AMOUNT");
            text.Add(":");
            text.Add(string.Format("{0:c}", amount));
            text.Add("REFUND METHOD");
            text.Add(":");
            text.Add(refundMethod);
            text.Add("REFUND DATE");
            text.Add(":");
            text.Add(Convert.ToString(refundDate));
            text.Add("REFUND TIME");
            text.Add(":");
            text.Add(Convert.ToString(refundTime));

            for (ctr2 = text.Count - 15; ctr2 <= text.Count - 1; ctr2 += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                //xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 2], printFont2).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont2, Brushes.Black, 50, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont2, Brushes.Black, 170, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont2, Brushes.Black, 175, yPos + 3);
                ctrTemp += 1;
            }

            //text.Add("ADDRESS : ");
            //text.Add("      _________________________");
            //text.Add(" ");
            //text.Add("      _________________________");
            //text.Add(" ");
            //text.Add("      _________________________");
            //text.Add(" ");
            text.Add("NAME : ");
            text.Add("   ____________________________");
            text.Add(" ");
            text.Add("PHONE : ");
            text.Add("    ___________________________");
            text.Add(" ");
            text.Add(" ");
            text.Add("SIGN :");
            text.Add("  _____________________________");
            text.Add(" ");
            text.Add(" ");
            text.Add("              ***MERCHANT COPY***");

            /*ctr = text.Count - 19;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 0, yPos + 3);

            ctr = text.Count - 18;
            xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr], printFont5).Width;
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, xPos, yPos + 3);
            ctrTemp += 1;

            ctr = text.Count - 17;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            ctr = text.Count - 16;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr], printFont5).Width;
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, xPos, yPos + 3);
            ctrTemp += 1;

            ctr = text.Count - 15;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            ctr = text.Count - 14;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr], printFont5).Width;
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, xPos, yPos + 3);
            ctrTemp += 1;

            ctr = text.Count - 13;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;*/

            ctr = text.Count - 12;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 0, yPos + 3);

            ctr = text.Count - 11;
            xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr], printFont5).Width;
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, xPos, yPos + 3);
            ctrTemp += 1;

            ctr = text.Count - 10;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            ctr = text.Count - 9;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 0, yPos + 3);

            ctr = text.Count - 8;
            xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr], printFont5).Width;
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, xPos, yPos + 3);
            ctrTemp += 1;

            ctr = text.Count - 7;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;
            ctr = text.Count - 6;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            ctr = text.Count - 5;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            ctr = text.Count - 4;
            xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr], printFont5).Width;
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, xPos, yPos + 3);
            ctrTemp += 1;

            ctr = text.Count - 3;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            ctr = text.Count - 2;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            ctr = text.Count - 1;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 0, yPos + 3);

            e.HasMorePages = false;
        }

        /// <summary>
        /// Handles the PrintPage event of the creditRefundPrint control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PrintPageEventArgs"/> instance containing the event data.</param>
        private void creditRefundPrint_PrintPage(object sender, PrintPageEventArgs e)
        {
            ArrayList text = new ArrayList();
            Single yPos, yPos2, xPos;
            int ctr, ctr2, ctrTemp;

            printFont = new Font("Arial", 10);
            printFont2 = new Font("Arial", 9);
            //printFont3 = new Font("Arial", 7, FontStyle.Bold);
            printFont3 = new Font("Arial", 8);
            printFont4 = new Font("Arial", 12);
            printBoldFont = new Font("Arial", 14, FontStyle.Bold);
            barcodeFont = new Font("3 of 9 Barcode", 25);

            //text.Add("BEAUTY 4 U");
            //text.Add("10654 CAMPUS WAY SOUTH");
            //text.Add("UPPER MARLBORO, MD 20774");
            //text.Add("TEL : 301-333-1430");
            text.Add(parentForm.companyName);
            text.Add(parentForm.storeStreet);
            text.Add(parentForm.storeCityState);
            text.Add(parentForm.storeTelephone);
            text.Add(" ");
            text.Add(" ");
            text.Add(" ");
            text.Add(" ");

            text.Add("PAYMENT METHOD");
            text.Add(":");
            text.Add("RETURN");
            text.Add("DATE & TIME");
            text.Add(":");
            text.Add(Convert.ToString(NewSellDate) + " " + Convert.ToString(NewSellTime));
            text.Add("RECEIPT ID");
            text.Add(":");
            text.Add(parentForm.storeCode + "-" + Convert.ToString(ReceiptID));
            text.Add("MANAGER ID");
            text.Add(":");
            text.Add(Convert.ToString(managerID));
            text.Add("WITNESS ID");
            text.Add(":");
            text.Add(Convert.ToString(witnessID));
            text.Add("REGISTER NO");
            text.Add(":");
            text.Add(Convert.ToString(RegisterNum));
            text.Add("MEMBER ID");
            text.Add(":");
            text.Add(Convert.ToString(MemberID));
            text.Add("MEMBER NAME");
            text.Add(":");
            text.Add(Convert.ToString(MemberName));
            text.Add("----------------------------------------------------------------");
            text.Add("       DESCRIPTION                         QTY     PRICE    ");
            text.Add("----------------------------------------------------------------");

            SqlCommand cmd_Count = new SqlCommand("Get_Item_Count_From_ReceiptBody", parentForm.conn);
            cmd_Count.CommandType = CommandType.StoredProcedure;
            cmd_Count.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
            SqlParameter ItmCount_Param = cmd_Count.Parameters.Add("@ItmCount", SqlDbType.Int);
            ItmCount_Param.Direction = ParameterDirection.Output;
            parentForm.conn.Open();
            cmd_Count.ExecuteNonQuery();
            parentForm.conn.Close();
            int ItmCount = Convert.ToInt16(cmd_Count.Parameters["@ItmCount"].Value);

            for (int a = 1; a <= ItmCount; a++)
            {
                SqlCommand cmd = new SqlCommand("Get_Item_From_ReceiptBody", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
                cmd.Parameters.Add("@ItmIndex", SqlDbType.Int).Value = a;
                SqlParameter ItmName_Param = cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar, 50);
                SqlParameter ItmQty_Param = cmd.Parameters.Add("@ItmQty", SqlDbType.Int);
                SqlParameter ItmBasePrice_Param = cmd.Parameters.Add("@ItmBasePrice", SqlDbType.Money);
                SqlParameter ItmDiscountPrice_Param = cmd.Parameters.Add("@ItmDiscountPrice", SqlDbType.Money);
                SqlParameter ItmPrice_Param = cmd.Parameters.Add("@ItmPrice", SqlDbType.Money);
                SqlParameter ItmUpc_Param = cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar, 20);
                ItmName_Param.Direction = ParameterDirection.Output;
                ItmQty_Param.Direction = ParameterDirection.Output;
                ItmBasePrice_Param.Direction = ParameterDirection.Output;
                ItmDiscountPrice_Param.Direction = ParameterDirection.Output;
                ItmPrice_Param.Direction = ParameterDirection.Output;
                ItmUpc_Param.Direction = ParameterDirection.Output;
                parentForm.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm.conn.Close();
                ItmName = cmd.Parameters["@ItmName"].Value.ToString();
                ItmQty = cmd.Parameters["@ItmQty"].Value.ToString();
                ItmBasePrice = Convert.ToDouble(cmd.Parameters["@ItmBasePrice"].Value);
                ItmDiscountPrice = Convert.ToDouble(cmd.Parameters["@ItmDiscountPrice"].Value);
                ItmPrice = Convert.ToDouble(cmd.Parameters["@ItmPrice"].Value);
                ItmUpc = cmd.Parameters["@ItmUpc"].Value.ToString();

                if (ItmDiscountPrice != 0)
                {
                    text.Add(ItmName);
                    text.Add(ItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", ItmPrice) + " T");
                    text.Add(ItmUpc);
                    text.Add("-PURCHASE PRICE: " + string.Format("{0:$0.00}", ItmDiscountPrice) + " * " + ItmQty + " =" + string.Format("{0:$0.00}", ItmPrice));
                    text.Add(" ");
                }
                else
                {
                    text.Add(ItmName);
                    text.Add(ItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", ItmPrice) + " T");
                    text.Add(ItmUpc);
                    text.Add("-PURCHASE PRICE: " + string.Format("{0:$0.00}", ItmBasePrice) + " * " + ItmQty + " = " + string.Format("{0:$0.00}", ItmPrice));
                    text.Add(" ");
                }
            }

            text.Add("----------------------------------------------------------------");
            text.Add("SUB TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:   - 0.00}", SubTotal));
            text.Add("SALES TAX");
            text.Add("$");
            text.Add(string.Format("{0:   - 0.00}", Tax));
            text.Add("RETURN TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:   - 0.00}", nGrandTotal));

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            ctr = 0;
            yPos = ctr * printBoldFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printBoldFont, Brushes.Black, 83, yPos);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            xPos = (e.PageBounds.Width + parentForm.ss) - e.Graphics.MeasureString((string)text[ctr], printFont).Width;
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, xPos, yPos + 10, sf);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            xPos = (e.PageBounds.Width + parentForm.scs) - e.Graphics.MeasureString((string)text[ctr], printFont).Width;
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, xPos, yPos + 10, sf);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            xPos = (e.PageBounds.Width + parentForm.st) - e.Graphics.MeasureString((string)text[ctr], printFont).Width;
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, xPos, yPos + 10, sf);

            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 77, yPos + 10);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 77, yPos + 10);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 77, yPos + 10);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 77, yPos + 10);

            ctrTemp = ctr;
            for (ctr = 8; ctr <= 31; ctr += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr + 1], printFont2, Brushes.Black, 120, yPos + 3);
                e.Graphics.DrawString((String)text[ctr + 2], printFont2, Brushes.Black, 125, yPos + 3);
                ctrTemp += 1;
            }

            ctr = 32;
            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctr += 1;
            ctrTemp += 1;
            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctr += 1;
            ctrTemp += 1;
            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            printItmCount = (ItmCount * 7) + 34;

            for (ctr2 = 35; ctr2 <= printItmCount; ctr2 += 7)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 3], printFont3).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont3, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont3, Brushes.Black, 208, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont3, Brushes.Black, 225, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 3], printFont3, Brushes.Black, xPos, yPos + 3);
                ctrTemp += 1;
                yPos2 = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2 + 4], printFont3, Brushes.Black, 0, yPos2 + 3);
                ctrTemp += 1;
                yPos2 = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2 + 5], printFont3, Brushes.Black, 0, yPos2 + 3);
                ctrTemp += 1;
                yPos2 = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2 + 6], printFont3, Brushes.Black, 0, yPos2 + 3);
                ctrTemp += 1;
            }

            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr2], printFont2, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            for (ctr2 = printItmCount + 2; ctr2 <= text.Count - 4; ctr2 += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 2], printFont2).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont2, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont2, Brushes.Black, 215, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont2, Brushes.Black, xPos, yPos + 3);
                ctrTemp += 1;
            }

            for (ctr2 = printItmCount + 8; ctr2 <= text.Count - 1; ctr2 += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 2], printFont4).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont4, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont4, Brushes.Black, 200, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont4, Brushes.Black, xPos, yPos + 3);
                ctrTemp += 1;
            }

            text.Add(" ");
            text.Add(" ");
            text.Add("REFUND");
            text.Add(" ");

            for (ctr2 = text.Count - 4; ctr2 <= text.Count - 1; ctr2++)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2], printBoldFont, Brushes.Black, 100, yPos);
                ctrTemp += 1;
            }

            text.Add("REFUND ID");
            text.Add(":");
            text.Add(Convert.ToString(RefundID));
            text.Add("AMOUNT");
            text.Add(":");
            text.Add(string.Format("{0:c}", amount));
            text.Add("REFUND METHOD");
            text.Add(":");
            text.Add(refundMethod);
            
            if (option == 0)
            {
                text.Add("CARD NUMBER");
                text.Add(":");
                text.Add("ENDING " + oLast4);
            }
            else if (option == 1)
            {
                text.Add("CARD NUMBER");
                text.Add(":");
                text.Add("ENDING " + CPlast4);
            }
            
            text.Add("REFUND DATE");
            text.Add(":");
            text.Add(Convert.ToString(refundDate));
            text.Add("REFUND TIME");
            text.Add(":");
            text.Add(Convert.ToString(refundTime));
            text.Add("REFUND TYPE");
            text.Add(":");
            text.Add(refundType);

            for (ctr2 = text.Count - 21; ctr2 <= text.Count - 1; ctr2 += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                //xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 2], printFont2).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont2, Brushes.Black, 50, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont2, Brushes.Black, 170, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont2, Brushes.Black, 175, yPos + 3);
                ctrTemp += 1;
            }

            text.Add(" ");
            text.Add(parentForm.SP_Line1);
            text.Add(parentForm.SP_Line2);
            text.Add(parentForm.SP_Line3);
            text.Add(parentForm.SP_Line4);
            text.Add(parentForm.SP_Line5);
            text.Add(parentForm.SP_Line6);
            text.Add(parentForm.SP_Line7);
            text.Add(parentForm.SP_Line8);
            text.Add(parentForm.SP_Line9);
            text.Add(parentForm.SP_Line10);
            text.Add(parentForm.SP_Line11);
            text.Add(parentForm.SP_Line12);
            text.Add(parentForm.SP_Line13);
            text.Add(parentForm.SP_Line14);
            text.Add(parentForm.SP_Line15);
            text.Add(parentForm.SP_Line16);
            text.Add(parentForm.SP_Line17);
            text.Add(parentForm.SP_Line18);
            text.Add(parentForm.SP_Line19);
            text.Add(parentForm.SP_Line20);
            text.Add(" ");
            text.Add(" ");

            for (ctr2 = text.Count - 23; ctr2 <= text.Count - 1; ctr2++)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2], printFont, Brushes.Black, 0, yPos + 3);
                ctrTemp += 1;
            }

            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString("*" + Convert.ToString(ReceiptID) + "*", barcodeFont, Brushes.Black, 55, yPos + 3);
            ctrTemp += 1;

            text.Add(" ");
            text.Add(" ");
            //text.Add("               Thank you for shopping !");
            text.Add(parentForm.receiptLastComment);

            for (ctr2 = text.Count - 3; ctr2 <= text.Count - 1; ctr2++)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2], printFont, Brushes.Black, 0, yPos + 3);
                ctrTemp += 1;
            }

            e.HasMorePages = false;
        }

        /// <summary>
        /// Handles the PrintPage event of the creditSigniturePrint control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PrintPageEventArgs"/> instance containing the event data.</param>
        private void creditSigniturePrint_PrintPage(object sender, PrintPageEventArgs e)
        {
            ArrayList text = new ArrayList();
            Single yPos, yPos2, xPos;
            int ctr, ctr2, ctrTemp;

            printFont = new Font("Arial", 10);
            printFont2 = new Font("Arial", 9);
            //printFont3 = new Font("Arial", 7, FontStyle.Bold);
            printFont3 = new Font("Arial", 8);
            printFont4 = new Font("Arial", 12);
            printFont5 = new Font("Arial", 10, FontStyle.Underline);
            printBoldFont = new Font("Arial", 14, FontStyle.Bold);
            printBoldFont2 = new Font("Arial", 18);

            //text.Add("BEAUTY 4 U");
            //text.Add("10654 CAMPUS WAY SOUTH");
            //text.Add("UPPER MARLBORO, MD 20774");
            //text.Add("TEL : 301-333-1430");
            text.Add(parentForm.companyName);
            text.Add(parentForm.storeStreet);
            text.Add(parentForm.storeCityState);
            text.Add(parentForm.storeTelephone);
            text.Add(" ");
            text.Add(" ");
            text.Add(" ");
            text.Add(" ");

            text.Add("PAYMENT METHOD");
            text.Add(":");
            text.Add("RETURN");
            text.Add("DATE & TIME");
            text.Add(":");
            text.Add(Convert.ToString(NewSellDate) + " " + Convert.ToString(NewSellTime));
            text.Add("RECEIPT ID");
            text.Add(":");
            text.Add(parentForm.storeCode + "-" + Convert.ToString(ReceiptID));
            text.Add("MANAGER ID");
            text.Add(":");
            text.Add(Convert.ToString(managerID));
            text.Add("WITNESS ID");
            text.Add(":");
            text.Add(Convert.ToString(witnessID));
            text.Add("REGISTER NO");
            text.Add(":");
            text.Add(Convert.ToString(RegisterNum));
            text.Add("MEMBER ID");
            text.Add(":");
            text.Add(Convert.ToString(MemberID));
            text.Add("MEMBER NAME");
            text.Add(":");
            text.Add(Convert.ToString(MemberName));
            text.Add("----------------------------------------------------------------");
            text.Add("       DESCRIPTION                         QTY     PRICE    ");
            text.Add("----------------------------------------------------------------");

            SqlCommand cmd_Count = new SqlCommand("Get_Item_Count_From_ReceiptBody", parentForm.conn);
            cmd_Count.CommandType = CommandType.StoredProcedure;
            cmd_Count.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
            SqlParameter ItmCount_Param = cmd_Count.Parameters.Add("@ItmCount", SqlDbType.Int);
            ItmCount_Param.Direction = ParameterDirection.Output;
            parentForm.conn.Open();
            cmd_Count.ExecuteNonQuery();
            parentForm.conn.Close();
            int ItmCount = Convert.ToInt16(cmd_Count.Parameters["@ItmCount"].Value);

            for (int a = 1; a <= ItmCount; a++)
            {
                SqlCommand cmd = new SqlCommand("Get_Item_From_ReceiptBody", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
                cmd.Parameters.Add("@ItmIndex", SqlDbType.Int).Value = a;
                SqlParameter ItmName_Param = cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar, 50);
                SqlParameter ItmQty_Param = cmd.Parameters.Add("@ItmQty", SqlDbType.Int);
                SqlParameter ItmBasePrice_Param = cmd.Parameters.Add("@ItmBasePrice", SqlDbType.Money);
                SqlParameter ItmDiscountPrice_Param = cmd.Parameters.Add("@ItmDiscountPrice", SqlDbType.Money);
                SqlParameter ItmPrice_Param = cmd.Parameters.Add("@ItmPrice", SqlDbType.Money);
                SqlParameter ItmUpc_Param = cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar, 20);
                ItmName_Param.Direction = ParameterDirection.Output;
                ItmQty_Param.Direction = ParameterDirection.Output;
                ItmBasePrice_Param.Direction = ParameterDirection.Output;
                ItmDiscountPrice_Param.Direction = ParameterDirection.Output;
                ItmPrice_Param.Direction = ParameterDirection.Output;
                ItmUpc_Param.Direction = ParameterDirection.Output;
                parentForm.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm.conn.Close();
                ItmName = cmd.Parameters["@ItmName"].Value.ToString();
                ItmQty = cmd.Parameters["@ItmQty"].Value.ToString();
                ItmBasePrice = Convert.ToDouble(cmd.Parameters["@ItmBasePrice"].Value);
                ItmDiscountPrice = Convert.ToDouble(cmd.Parameters["@ItmDiscountPrice"].Value);
                ItmPrice = Convert.ToDouble(cmd.Parameters["@ItmPrice"].Value);
                ItmUpc = cmd.Parameters["@ItmUpc"].Value.ToString();

                if (ItmDiscountPrice != 0)
                {
                    text.Add(ItmName);
                    text.Add(ItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", ItmPrice) + " T");
                    text.Add(ItmUpc);
                    text.Add("-PURCHASE PRICE: " + string.Format("{0:$0.00}", ItmDiscountPrice) + " * " + ItmQty + " =" + string.Format("{0:$0.00}", ItmPrice));
                    text.Add(" ");
                }
                else
                {
                    text.Add(ItmName);
                    text.Add(ItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", ItmPrice) + " T");
                    text.Add(ItmUpc);
                    text.Add("-PURCHASE PRICE: " + string.Format("{0:$0.00}", ItmBasePrice) + " * " + ItmQty + " = " + string.Format("{0:$0.00}", ItmPrice));
                    text.Add(" ");
                }
            }

            text.Add("----------------------------------------------------------------");
            text.Add("SUB TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:   - 0.00}", SubTotal));
            text.Add("SALES TAX");
            text.Add("$");
            text.Add(string.Format("{0:   - 0.00}", Tax));
            text.Add("RETURN TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:   - 0.00}", nGrandTotal));

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            ctr = 0;
            yPos = ctr * printBoldFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printBoldFont, Brushes.Black, 83, yPos);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            xPos = (e.PageBounds.Width + parentForm.ss) - e.Graphics.MeasureString((string)text[ctr], printFont).Width;
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, xPos, yPos + 10, sf);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            xPos = (e.PageBounds.Width + parentForm.scs) - e.Graphics.MeasureString((string)text[ctr], printFont).Width;
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, xPos, yPos + 10, sf);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            xPos = (e.PageBounds.Width + parentForm.st) - e.Graphics.MeasureString((string)text[ctr], printFont).Width;
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, xPos, yPos + 10, sf);

            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 77, yPos + 10);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 77, yPos + 10);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 77, yPos + 10);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 77, yPos + 10);

            ctrTemp = ctr;
            for (ctr = 8; ctr <= 31; ctr += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr + 1], printFont2, Brushes.Black, 120, yPos + 3);
                e.Graphics.DrawString((String)text[ctr + 2], printFont2, Brushes.Black, 125, yPos + 3);
                ctrTemp += 1;
            }

            ctr = 32;
            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctr += 1;
            ctrTemp += 1;
            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctr += 1;
            ctrTemp += 1;
            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            printItmCount = (ItmCount * 7) + 34;

            for (ctr2 = 35; ctr2 <= printItmCount; ctr2 += 7)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 3], printFont3).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont3, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont3, Brushes.Black, 208, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont3, Brushes.Black, 225, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 3], printFont3, Brushes.Black, xPos, yPos + 3);
                ctrTemp += 1;
                yPos2 = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2 + 4], printFont3, Brushes.Black, 0, yPos2 + 3);
                ctrTemp += 1;
                yPos2 = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2 + 5], printFont3, Brushes.Black, 0, yPos2 + 3);
                ctrTemp += 1;
                yPos2 = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2 + 6], printFont3, Brushes.Black, 0, yPos2 + 3);
                ctrTemp += 1;
            }

            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr2], printFont2, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            for (ctr2 = printItmCount + 2; ctr2 <= text.Count - 4; ctr2 += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 2], printFont2).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont2, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont2, Brushes.Black, 215, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont2, Brushes.Black, xPos, yPos + 3);
                ctrTemp += 1;
            }

            for (ctr2 = printItmCount + 8; ctr2 <= text.Count - 1; ctr2 += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 2], printFont4).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont4, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont4, Brushes.Black, 200, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont4, Brushes.Black, xPos, yPos + 3);
                ctrTemp += 1;
            }

            text.Add(" ");
            text.Add(" ");
            text.Add("REFUND");
            text.Add(" ");

            for (ctr2 = text.Count - 4; ctr2 <= text.Count - 1; ctr2++)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2], printBoldFont, Brushes.Black, 100, yPos);
                ctrTemp += 1;
            }

            text.Add("REFUND ID");
            text.Add(":");
            text.Add(Convert.ToString(RefundID));
            text.Add("AMOUNT");
            text.Add(":");
            text.Add(string.Format("{0:c}", amount));
            text.Add("REFUND METHOD");
            text.Add(":");
            text.Add(refundMethod);

            if (option == 0)
            {
                text.Add("CARD NUMBER");
                text.Add(":");
                text.Add("ENDING " + oLast4);
            }
            else if (option == 1)
            {
                text.Add("CARD NUMBER");
                text.Add(":");
                text.Add("ENDING " + CPlast4);
            }

            text.Add("REFUND DATE");
            text.Add(":");
            text.Add(Convert.ToString(refundDate));
            text.Add("REFUND TIME");
            text.Add(":");
            text.Add(Convert.ToString(refundTime));
            text.Add("REFUND TYPE");
            text.Add(":");
            text.Add(refundType);

            for (ctr2 = text.Count - 21; ctr2 <= text.Count - 1; ctr2 += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                //xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 2], printFont2).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont2, Brushes.Black, 50, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont2, Brushes.Black, 170, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont2, Brushes.Black, 175, yPos + 3);
                ctrTemp += 1;
            }

            //text.Add("ADDRESS : ");
            //text.Add("      _________________________");
            //text.Add(" ");
            //text.Add("      _________________________");
            //text.Add(" ");
            //text.Add("      _________________________");
            //text.Add(" ");
            text.Add("NAME : ");
            text.Add("   ____________________________");
            text.Add(" ");
            text.Add("PHONE : ");
            text.Add("    ___________________________");
            text.Add(" ");
            text.Add(" ");
            text.Add("SIGN :");
            text.Add("  _____________________________");
            text.Add(" ");
            text.Add(" ");
            text.Add("              ***MERCHANT COPY***");

            /*ctr = text.Count - 19;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 0, yPos + 3);

            ctr = text.Count - 18;
            xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr], printFont5).Width;
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, xPos, yPos + 3);
            ctrTemp += 1;

            ctr = text.Count - 17;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            ctr = text.Count - 16;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr], printFont5).Width;
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, xPos, yPos + 3);
            ctrTemp += 1;

            ctr = text.Count - 15;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            ctr = text.Count - 14;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr], printFont5).Width;
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, xPos, yPos + 3);
            ctrTemp += 1;

            ctr = text.Count - 13;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;*/

            ctr = text.Count - 12;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 0, yPos + 3);

            ctr = text.Count - 11;
            xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr], printFont5).Width;
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, xPos, yPos + 3);
            ctrTemp += 1;

            ctr = text.Count - 10;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            ctr = text.Count - 9;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 0, yPos + 3);

            ctr = text.Count - 8;
            xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr], printFont5).Width;
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, xPos, yPos + 3);
            ctrTemp += 1;

            ctr = text.Count - 7;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;
            ctr = text.Count - 6;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            ctr = text.Count - 5;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            ctr = text.Count - 4;
            xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr], printFont5).Width;
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, xPos, yPos + 3);
            ctrTemp += 1;

            ctr = text.Count - 3;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            ctr = text.Count - 2;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            ctr = text.Count - 1;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 0, yPos + 3);

            e.HasMorePages = false;
        }

        /// <summary>
        /// Handles the PrintPage event of the creditTerminalPrint control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PrintPageEventArgs"/> instance containing the event data.</param>
        private void creditTerminalPrint_PrintPage(object sender, PrintPageEventArgs e)
        {
            ArrayList text = new ArrayList();
            Single yPos, yPos2, xPos;
            int ctr, ctr2, ctrTemp;

            printFont = new Font("Arial", 10);
            printFont2 = new Font("Arial", 9);
            //printFont3 = new Font("Arial", 7, FontStyle.Bold);
            printFont3 = new Font("Arial", 8);
            printFont4 = new Font("Arial", 12);
            printBoldFont = new Font("Arial", 14, FontStyle.Bold);
            barcodeFont = new Font("3 of 9 Barcode", 25);

            //text.Add("BEAUTY 4 U");
            //text.Add("10654 CAMPUS WAY SOUTH");
            //text.Add("UPPER MARLBORO, MD 20774");
            //text.Add("TEL : 301-333-1430");
            text.Add(parentForm.companyName);
            text.Add(parentForm.storeStreet);
            text.Add(parentForm.storeCityState);
            text.Add(parentForm.storeTelephone);
            text.Add(" ");
            text.Add(" ");
            text.Add(" ");
            text.Add(" ");

            text.Add("PAYMENT METHOD");
            text.Add(":");
            text.Add("RETURN");
            text.Add("DATE & TIME");
            text.Add(":");
            text.Add(Convert.ToString(NewSellDate) + " " + Convert.ToString(NewSellTime));
            text.Add("RECEIPT ID");
            text.Add(":");
            text.Add(parentForm.storeCode + "-" + Convert.ToString(ReceiptID));
            text.Add("MANAGER ID");
            text.Add(":");
            text.Add(Convert.ToString(managerID));
            text.Add("WITNESS ID");
            text.Add(":");
            text.Add(Convert.ToString(witnessID));
            text.Add("REGISTER NO");
            text.Add(":");
            text.Add(Convert.ToString(RegisterNum));
            text.Add("MEMBER ID");
            text.Add(":");
            text.Add(Convert.ToString(MemberID));
            text.Add("MEMBER NAME");
            text.Add(":");
            text.Add(Convert.ToString(MemberName));
            text.Add("----------------------------------------------------------------");
            text.Add("       DESCRIPTION                         QTY     PRICE    ");
            text.Add("----------------------------------------------------------------");

            SqlCommand cmd_Count = new SqlCommand("Get_Item_Count_From_ReceiptBody", parentForm.conn);
            cmd_Count.CommandType = CommandType.StoredProcedure;
            cmd_Count.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
            SqlParameter ItmCount_Param = cmd_Count.Parameters.Add("@ItmCount", SqlDbType.Int);
            ItmCount_Param.Direction = ParameterDirection.Output;
            parentForm.conn.Open();
            cmd_Count.ExecuteNonQuery();
            parentForm.conn.Close();
            int ItmCount = Convert.ToInt16(cmd_Count.Parameters["@ItmCount"].Value);

            for (int a = 1; a <= ItmCount; a++)
            {
                SqlCommand cmd = new SqlCommand("Get_Item_From_ReceiptBody", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
                cmd.Parameters.Add("@ItmIndex", SqlDbType.Int).Value = a;
                SqlParameter ItmName_Param = cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar, 50);
                SqlParameter ItmQty_Param = cmd.Parameters.Add("@ItmQty", SqlDbType.Int);
                SqlParameter ItmBasePrice_Param = cmd.Parameters.Add("@ItmBasePrice", SqlDbType.Money);
                SqlParameter ItmDiscountPrice_Param = cmd.Parameters.Add("@ItmDiscountPrice", SqlDbType.Money);
                SqlParameter ItmPrice_Param = cmd.Parameters.Add("@ItmPrice", SqlDbType.Money);
                SqlParameter ItmUpc_Param = cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar, 20);
                ItmName_Param.Direction = ParameterDirection.Output;
                ItmQty_Param.Direction = ParameterDirection.Output;
                ItmBasePrice_Param.Direction = ParameterDirection.Output;
                ItmDiscountPrice_Param.Direction = ParameterDirection.Output;
                ItmPrice_Param.Direction = ParameterDirection.Output;
                ItmUpc_Param.Direction = ParameterDirection.Output;
                parentForm.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm.conn.Close();
                ItmName = cmd.Parameters["@ItmName"].Value.ToString();
                ItmQty = cmd.Parameters["@ItmQty"].Value.ToString();
                ItmBasePrice = Convert.ToDouble(cmd.Parameters["@ItmBasePrice"].Value);
                ItmDiscountPrice = Convert.ToDouble(cmd.Parameters["@ItmDiscountPrice"].Value);
                ItmPrice = Convert.ToDouble(cmd.Parameters["@ItmPrice"].Value);
                ItmUpc = cmd.Parameters["@ItmUpc"].Value.ToString();

                if (ItmDiscountPrice != 0)
                {
                    text.Add(ItmName);
                    text.Add(ItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", ItmPrice) + " T");
                    text.Add(ItmUpc);
                    text.Add("-PURCHASE PRICE: " + string.Format("{0:$0.00}", ItmDiscountPrice) + " * " + ItmQty + " =" + string.Format("{0:$0.00}", ItmPrice));
                    text.Add(" ");
                }
                else
                {
                    text.Add(ItmName);
                    text.Add(ItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", ItmPrice) + " T");
                    text.Add(ItmUpc);
                    text.Add("-PURCHASE PRICE: " + string.Format("{0:$0.00}", ItmBasePrice) + " * " + ItmQty + " = " + string.Format("{0:$0.00}", ItmPrice));
                    text.Add(" ");
                }
            }

            text.Add("----------------------------------------------------------------");
            text.Add("SUB TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:   - 0.00}", SubTotal));
            text.Add("SALES TAX");
            text.Add("$");
            text.Add(string.Format("{0:   - 0.00}", Tax));
            text.Add("RETURN TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:   - 0.00}", nGrandTotal));

            /*ctr = 0;
            yPos = ctr * printBoldFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printBoldFont, Brushes.Black, 83, yPos);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 50, yPos + 10);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 50, yPos + 10);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 77, yPos + 10);*/

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            ctr = 0;
            yPos = ctr * printBoldFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printBoldFont, Brushes.Black, 83, yPos);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            xPos = (e.PageBounds.Width + parentForm.ss) - e.Graphics.MeasureString((string)text[ctr], printFont).Width;
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, xPos, yPos + 10, sf);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            xPos = (e.PageBounds.Width + parentForm.scs) - e.Graphics.MeasureString((string)text[ctr], printFont).Width;
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, xPos, yPos + 10, sf);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            xPos = (e.PageBounds.Width + parentForm.st) - e.Graphics.MeasureString((string)text[ctr], printFont).Width;
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, xPos, yPos + 10, sf);

            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 77, yPos + 10);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 77, yPos + 10);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 77, yPos + 10);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 77, yPos + 10);

            ctrTemp = ctr;
            for (ctr = 8; ctr <= 31; ctr += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr + 1], printFont2, Brushes.Black, 120, yPos + 3);
                e.Graphics.DrawString((String)text[ctr + 2], printFont2, Brushes.Black, 125, yPos + 3);
                ctrTemp += 1;
            }

            ctr = 32;
            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctr += 1;
            ctrTemp += 1;
            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctr += 1;
            ctrTemp += 1;
            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            printItmCount = (ItmCount * 7) + 34;

            for (ctr2 = 35; ctr2 <= printItmCount; ctr2 += 7)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 3], printFont3).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont3, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont3, Brushes.Black, 208, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont3, Brushes.Black, 225, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 3], printFont3, Brushes.Black, xPos, yPos + 3);
                ctrTemp += 1;
                yPos2 = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2 + 4], printFont3, Brushes.Black, 0, yPos2 + 3);
                ctrTemp += 1;
                yPos2 = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2 + 5], printFont3, Brushes.Black, 0, yPos2 + 3);
                ctrTemp += 1;
                yPos2 = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2 + 6], printFont3, Brushes.Black, 0, yPos2 + 3);
                ctrTemp += 1;
            }

            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr2], printFont2, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            for (ctr2 = printItmCount + 2; ctr2 <= text.Count - 4; ctr2 += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 2], printFont2).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont2, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont2, Brushes.Black, 215, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont2, Brushes.Black, xPos, yPos + 3);
                ctrTemp += 1;
            }

            for (ctr2 = printItmCount + 8; ctr2 <= text.Count - 1; ctr2 += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 2], printFont4).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont4, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont4, Brushes.Black, 200, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont4, Brushes.Black, xPos, yPos + 3);
                ctrTemp += 1;
            }

            text.Add(" ");
            text.Add(" ");
            text.Add("REFUND");
            text.Add(" ");

            for (ctr2 = text.Count - 4; ctr2 <= text.Count - 1; ctr2++)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2], printBoldFont, Brushes.Black, 100, yPos);
                ctrTemp += 1;
            }

            text.Add("REFUND ID");
            text.Add(":");
            text.Add(Convert.ToString(RefundID));
            text.Add("AMOUNT");
            text.Add(":");
            text.Add(string.Format("{0:c}", amount));
            text.Add("REFUND METHOD");
            text.Add(":");
            text.Add(refundMethod);
            //text.Add("CARD NUMBER");
            //text.Add(":");
            //text.Add("ENDING " + oLast4);
            text.Add("REFUND DATE");
            text.Add(":");
            text.Add(Convert.ToString(refundDate));
            text.Add("REFUND TIME");
            text.Add(":");
            text.Add(Convert.ToString(refundTime));
            text.Add("REFUND TYPE");
            text.Add(":");
            text.Add(refundType);

            for (ctr2 = text.Count - 18; ctr2 <= text.Count - 1; ctr2 += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                //xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 2], printFont2).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont2, Brushes.Black, 50, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont2, Brushes.Black, 170, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont2, Brushes.Black, 175, yPos + 3);
                ctrTemp += 1;
            }

            text.Add(" ");
            //text.Add("    All items can exchange or receive");
            //text.Add("    Beauty4U store credit within 14 days");
            //text.Add("    from the date of purchase with original");
            //text.Add("    condition & receipt presented. ");
            //text.Add("    Except the following: Electrical equipment");
            //text.Add("    /Appliances exchange only. Wig, Ponytail,");
            //text.Add("    Cosmetic, Hair Care, Jewelry, Slipper,");
            //text.Add("    Sandal, Hat and Sale Item are final sale.");
            text.Add(parentForm.SP_Line1);
            text.Add(parentForm.SP_Line2);
            text.Add(parentForm.SP_Line3);
            text.Add(parentForm.SP_Line4);
            text.Add(parentForm.SP_Line5);
            text.Add(parentForm.SP_Line6);
            text.Add(parentForm.SP_Line7);
            text.Add(parentForm.SP_Line8);
            text.Add(parentForm.SP_Line9);
            text.Add(parentForm.SP_Line10);
            text.Add(parentForm.SP_Line11);
            text.Add(parentForm.SP_Line12);
            text.Add(parentForm.SP_Line13);
            text.Add(parentForm.SP_Line14);
            text.Add(parentForm.SP_Line15);
            text.Add(parentForm.SP_Line16);
            text.Add(parentForm.SP_Line17);
            text.Add(parentForm.SP_Line18);
            text.Add(parentForm.SP_Line19);
            text.Add(parentForm.SP_Line20);
            text.Add(" ");
            text.Add(" ");

            for (ctr2 = text.Count - 23; ctr2 <= text.Count - 1; ctr2++)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2], printFont, Brushes.Black, 0, yPos + 3);
                ctrTemp += 1;
            }

            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString("*" + Convert.ToString(ReceiptID) + "*", barcodeFont, Brushes.Black, 55, yPos + 3);
            ctrTemp += 1;

            text.Add(" ");
            text.Add(" ");
            //text.Add("               Thank you for shopping !");
            text.Add(parentForm.receiptLastComment);

            for (ctr2 = text.Count - 3; ctr2 <= text.Count - 1; ctr2++)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2], printFont, Brushes.Black, 0, yPos + 3);
                ctrTemp += 1;
            }

            e.HasMorePages = false;
        }

        /// <summary>
        /// Statuses the monitoring.
        /// </summary>
        /// <param name="dwStatus">The dw status.</param>
        /// <returns>Int32.</returns>
        public Int32 StatusMonitoring(int dwStatus)
        {
            if ((dwStatus & apiAlias.ASB_PRINT_SUCCESS) == apiAlias.ASB_PRINT_SUCCESS)
            {
                printStatus = dwStatus;
                isFinish = true;
            }
            if (((dwStatus & apiAlias.ASB_NO_RESPONSE) == apiAlias.ASB_NO_RESPONSE)
                ||
                ((dwStatus & apiAlias.ASB_COVER_OPEN) == apiAlias.ASB_COVER_OPEN)
                ||
                ((dwStatus & apiAlias.ASB_AUTOCUTTER_ERR) == apiAlias.ASB_AUTOCUTTER_ERR)
                ||
                (((dwStatus & apiAlias.ASB_PAPER_END_FIRST) == apiAlias.ASB_PAPER_END_FIRST) || ((dwStatus & apiAlias.ASB_PAPER_END_SECOND) == apiAlias.ASB_PAPER_END_SECOND))
                )
            {
                printStatus = dwStatus;
                isFinish = true;
                cancelErr = true;
            }

            return (apiAlias.SUCCESS);
        }

        /// <summary>
        /// Opens the drawer.
        /// </summary>
        /// <param name="printerName">Name of the printer.</param>
        private void OpenDrawer(String printerName)
        {
            Int32 retVal;
            String errMsg;

            try
            {
                // Execute drawer operation.
                retVal = apiAlias.BiOpenDrawer(mpHandle, apiAlias.EPS_BI_DRAWER_1, apiAlias.EPS_BI_PULSE_100);
                if (retVal != apiAlias.SUCCESS)
                    MessageBox.Show("Failed to open drawer.", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                MessageBox.Show("Failed to open drawer.", "", MessageBoxButtons.OK);
            }
        }

        /*private void DisplayStatusMessage()
        {
            if ((printStatus & apiAlias.ASB_PRINT_SUCCESS) == apiAlias.ASB_PRINT_SUCCESS)
                //MessageBox.Show("Complete printing.", "", MessageBoxButtons.OK);
                MyMessageBox.ShowBox("COMPLETE PRINTING", "INFORMATION");
            if ((printStatus & apiAlias.ASB_NO_RESPONSE) == apiAlias.ASB_NO_RESPONSE)
                MessageBox.Show("No response.", "", MessageBoxButtons.OK);
            if ((printStatus & apiAlias.ASB_COVER_OPEN) == apiAlias.ASB_COVER_OPEN)
                MessageBox.Show("Cover is open.", "", MessageBoxButtons.OK);
            if ((printStatus & apiAlias.ASB_AUTOCUTTER_ERR) == apiAlias.ASB_AUTOCUTTER_ERR)
                MessageBox.Show("Autocutter error occurred.", "", MessageBoxButtons.OK);
            if (((printStatus & apiAlias.ASB_PAPER_END_FIRST) == apiAlias.ASB_PAPER_END_FIRST) || ((printStatus & apiAlias.ASB_PAPER_END_SECOND) == apiAlias.ASB_PAPER_END_SECOND))
                MessageBox.Show("Roll paper end sensor: paper not present.", "", MessageBoxButtons.OK);
        }*/

        /// <summary>
        /// Payments the method.
        /// </summary>
        /// <param name="num">The number.</param>
        /// <returns>System.String.</returns>
        private string PaymentMethod(int num)
        {
            string methodName;

            switch (num)
            {
                case 0:
                    methodName = "RETURN";
                    break;
                case 1:
                    methodName = "CASH";
                    break;
                case 3:
                    methodName = "TERMINAL (CREDIT)";
                    break;
                case 4:
                    methodName = "VISA";
                    break;
                case 5:
                    methodName = "DEBIT";
                    break;
                case 6:
                    methodName = "MASTER";
                    break;
                case 7:
                    methodName = "AMEX";
                    break;
                case 8:
                    methodName = "DISCOVER";
                    break;
                case 77:
                    methodName = "GIFT CARD";
                    break;
                case 88:
                    methodName = "STORE CREDIT";
                    break;
                case 99:
                    methodName = "MULTIPLE";
                    break;
                default:
                    methodName = "NULL";
                    break;
            }

            return methodName;
        }

        /// <summary>
        /// Returns the type of the credit card.
        /// </summary>
        /// <param name="creditCardType">Type of the credit card.</param>
        /// <returns>System.Int32.</returns>
        private int ReturnCreditCardType(string creditCardType)
        {
            int cardTypeNum;

            switch (creditCardType)
            {
                case "VISA":
                    cardTypeNum = 4;
                    break;
                case "DEBIT":
                    cardTypeNum = 5;
                    break;
                case "MC":
                    cardTypeNum = 6;
                    break;
                case "MASTER":
                    cardTypeNum = 6;
                    break;
                case "AMEX":
                    cardTypeNum = 7;
                    break;
                case "DISC":
                    cardTypeNum = 8;
                    break;
                case "DISCOVER":
                    cardTypeNum = 8;
                    break;
                default:
                    cardTypeNum = 3;
                    break;
            }

            return cardTypeNum;
        }

        /// <summary>
        /// Resettings this instance.
        /// </summary>
        private void Resetting()
        {
            lblReceiptID.Text = "";
            lblMemberName.Text = "";
            lblDate.Text = "";
            lblSubTotal.Text = "";
            lblTax.Text = "";
            lblGrandTotal.Text = "";
            lblPayBy.Text = "";

            lblNewSubTotal.Text = "";
            lblNewTax.Text = "";
            lblNewGrandTotal.Text = "";

            MemberID = "101";
            MemberName = "WALK INS";
            MemberPoints = 0;
            remainingPoints = 0;
            pointsBack = false;
            pointsBackAmount = 0;

            btnQtyPlus.Enabled = true;
            btnQtyMinus.Enabled = true;

            rdoBtnWithTax.Enabled = true;
            rdoBtnWithNoTax.Enabled = true;
            rdoBtnWithTax.Checked = true;

            oAmount = 0;
            oPaymentID = "";
            oOrderID = "";
            oLast4 = "";
            rAmount = 0;

            CPAmount = 0;
            CPcreditID = null;
            CPorderID = null;
            CPexternalPaymentID = null;
            CPreferenceID = null;
            CPcreatedTime = 0;
            CPsellDate = null;
            CPsellTime = null;
            CPcardType = null;
            CPentryType = null;
            CPtransactionLabel = null;
            CPlast4 = null;
            CPcardHolderName = null;
            CPauthCode = null;
            CPAID = "N/A";
            CPcvm = null;

            txtReceiptID.Select();
            txtReceiptID.Focus();

            /*if (option == 2)
            {
                parentForm.btnDeleteAll_Click(null, null);
            }
            else
            {
                txtReceiptID.Select();
                txtReceiptID.Focus();
            }*/

            if (option == 1)
            {
                parentForm.btnDeleteAll_Click(null, null);
                this.Close();
            }
        }

        /// <summary>
        /// Calculates the customer points.
        /// </summary>
        public void Calculate_Customer_Points()
        {
            if (pointsBack == true)
            {
                Create_Redeem_History(0);

                SqlCommand cmd1 = new SqlCommand("Calculate_Member_Points", parentForm.connHQ);
                SqlCommand cmd2 = new SqlCommand("Points_Back_To_Member", parentForm.connHQ);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add("@MemberID", SqlDbType.NVarChar).Value = MemberID;
                cmd1.Parameters.Add("@Redeem", SqlDbType.Money).Value = redeem;
                cmd1.Parameters.Add("@NewPoints", SqlDbType.Money).Value = MemberPoints;
                cmd2.Parameters.Add("@MemberID", SqlDbType.NVarChar).Value = MemberID;
                cmd2.Parameters.Add("@PointsBackAmount", SqlDbType.Money).Value = pointsBackAmount;

                parentForm.connHQ.Open();
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                parentForm.connHQ.Close();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("Calculate_Member_Points", parentForm.connHQ);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MemberID", SqlDbType.NVarChar).Value = MemberID;
                cmd.Parameters.Add("@Redeem", SqlDbType.Money).Value = redeem;
                cmd.Parameters.Add("@NewPoints", SqlDbType.Money).Value = MemberPoints;

                parentForm.connHQ.Open();
                cmd.ExecuteNonQuery();
                parentForm.connHQ.Close();
            }
        }

        /// <summary>
        /// Remainings the points.
        /// </summary>
        /// <param name="s_Code">The s code.</param>
        /// <param name="m_Code">The m code.</param>
        /// <returns>System.Double.</returns>
        private double Remaining_Points(string s_Code, Int64 m_Code)
        {
            SqlCommand cmd = new SqlCommand("Get_Remaining_Points", parentForm.connHQ);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = s_Code;
            cmd.Parameters.Add("@MemberCode", SqlDbType.BigInt).Value = m_Code;
            SqlParameter RemainingPoints_Param = cmd.Parameters.Add("@RemainingPoints", SqlDbType.Money);
            RemainingPoints_Param.Direction = ParameterDirection.Output;

            parentForm.connHQ.Open();
            cmd.ExecuteNonQuery();
            parentForm.connHQ.Close();

            if (cmd.Parameters["@RemainingPoints"].Value == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToDouble(cmd.Parameters["@RemainingPoints"].Value);
            }
        }

        /// <summary>
        /// Creates the redeem history.
        /// </summary>
        /// <param name="boolNum">The bool number.</param>
        public void Create_Redeem_History(int boolNum)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Create_Redeem_History", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@BoolNum", SqlDbType.Int).Value = boolNum;
                cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = parentForm.storeCode;
                cmd.Parameters.Add("@CashierID", SqlDbType.NVarChar).Value = parentForm.employeeID;
                cmd.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = parentForm.cashRegisterNum;
                cmd.Parameters.Add("@RefReceiptID", SqlDbType.BigInt).Value = ReceiptID;
                cmd.Parameters.Add("@MemberID", SqlDbType.BigInt).Value = Convert.ToInt64(MemberID);
                cmd.Parameters.Add("@MemberName", SqlDbType.NVarChar).Value = MemberName;
                cmd.Parameters.Add("@RedeemCode", SqlDbType.BigInt).Value = 10;
                cmd.Parameters.Add("@Amount", SqlDbType.Money).Value = -pointsBackAmount;
                cmd.Parameters.Add("@TransactionDate", SqlDbType.NVarChar).Value = NewSellDate;
                cmd.Parameters.Add("@TransactionTime", SqlDbType.NVarChar).Value = NewSellTime;

                parentForm.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm.conn.Close();
            }
            catch
            {
                MessageBox.Show("CREATING REDEEM HISTORY ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                parentForm.conn.Close();
                return;
            }
        }

        /// <summary>
        /// Gets the type of the member.
        /// </summary>
        /// <param name="mID">The m identifier.</param>
        /// <returns>System.String.</returns>
        private string Get_MemberType(Int64 mID)
        {
            SqlCommand cmd_GetMemberType = new SqlCommand("Get_MemberType", parentForm.connHQ);
            cmd_GetMemberType.CommandType = CommandType.StoredProcedure;
            cmd_GetMemberType.Parameters.Add("@MemberCode", SqlDbType.BigInt).Value = mID;
            SqlParameter MemberType_Param = cmd_GetMemberType.Parameters.Add("@MemberType", SqlDbType.NVarChar, 20);
            MemberType_Param.Direction = ParameterDirection.Output;

            parentForm.connHQ.Open();
            cmd_GetMemberType.ExecuteNonQuery();
            parentForm.connHQ.Close();

            return Convert.ToString(cmd_GetMemberType.Parameters["@MemberType"].Value);
        }

        /// <summary>
        /// Checkings the duplicated refund.
        /// </summary>
        /// <param name="RID">The rid.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool Checking_Duplicated_Refund(Int64 RID)
        {
            SqlCommand cmd_CheckingDuplicatedRefund = new SqlCommand("Checking_Duplicated_Refund", connection);
            cmd_CheckingDuplicatedRefund.CommandType = CommandType.StoredProcedure;
            cmd_CheckingDuplicatedRefund.Parameters.Add("@RefReceiptID", SqlDbType.BigInt).Value = RID;
            SqlParameter CheckNum_Param = cmd_CheckingDuplicatedRefund.Parameters.Add("@CheckNum", SqlDbType.TinyInt);
            CheckNum_Param.Direction = ParameterDirection.Output;

            connection.Open();
            cmd_CheckingDuplicatedRefund.ExecuteNonQuery();
            connection.Close();

            if(Convert.ToInt16(cmd_CheckingDuplicatedRefund.Parameters["@CheckNum"].Value) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool Checking_Duplicated_StoreCredit(Int64 RID)
        {
            SqlCommand cmd_CheckingDuplicatedStoreCredit = new SqlCommand("Checking_Duplicated_StoreCredit", connection);
            cmd_CheckingDuplicatedStoreCredit.CommandType = CommandType.StoredProcedure;
            cmd_CheckingDuplicatedStoreCredit.Parameters.Add("@RefReceiptID", SqlDbType.BigInt).Value = RID;
            SqlParameter CheckNum_Param = cmd_CheckingDuplicatedStoreCredit.Parameters.Add("@CheckNum", SqlDbType.TinyInt);
            CheckNum_Param.Direction = ParameterDirection.Output;

            connection.Open();
            cmd_CheckingDuplicatedStoreCredit.ExecuteNonQuery();
            connection.Close();

            if (Convert.ToInt16(cmd_CheckingDuplicatedStoreCredit.Parameters["@CheckNum"].Value) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the window will be activated when it is shown.
        /// </summary>
        /// <value><c>true</c> if [show without activation]; otherwise, <c>false</c>.</value>
        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnResetDevice control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnResetDevice_Click(object sender, EventArgs e)
        {
            parentForm.cloverConnector.ResetDevice();
        }

        /// <summary>
        /// Handles the Click event of the radioBtnCash control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void radioBtnCash_Click(object sender, EventArgs e)
        {
            if (grpBoxRefundOptions.Enabled == true)
                radioBtnCash.Checked = true;
        }

        /// <summary>
        /// Handles the Click event of the radioBtnCredit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void radioBtnCredit_Click(object sender, EventArgs e)
        {
            if (grpBoxRefundOptions.Enabled == true)
                radioBtnCredit.Checked = true;
        }

        /// <summary>
        /// Handles the Click event of the radioBtnCreditTerminal control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void radioBtnCreditTerminal_Click(object sender, EventArgs e)
        {
            if (grpBoxRefundOptions.Enabled == true)
                radioBtnCreditTerminal.Checked = true;
        }
    }
}