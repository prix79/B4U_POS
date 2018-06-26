// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 02-05-2018
// ***********************************************************************
// <copyright file="StoreCreditOption.cs" company="Beauty4u">
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

/// <summary>
/// The Register namespace.
/// </summary>
namespace Register
{
    /// <summary>
    /// Class StoreCreditOption.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class StoreCreditOption : Form
    {
        /// <summary>
        /// The parent form
        /// </summary>
        public MainForm parentForm;
        /// <summary>
        /// The new connection
        /// </summary>
        SqlConnection newConn;
        /// <summary>
        /// The new conn2
        /// </summary>
        SqlConnection newConn2;
        /// <summary>
        /// The authentication
        /// </summary>
        public bool auth = false;

        /// <summary>
        /// The command
        /// </summary>
        SqlCommand cmd = new SqlCommand();
        //public int tempIdx;
        /// <summary>
        /// The i
        /// </summary>
        int i;
        /// <summary>
        /// The opt
        /// </summary>
        int opt = 0;
        /// <summary>
        /// The redeem
        /// </summary>
        double redeem = 0;
        /// <summary>
        /// The s grand total
        /// </summary>
        string sGrandTotal = string.Empty;
        /// <summary>
        /// The n grand total
        /// </summary>
        /// <summary>
        /// The n pay
        /// </summary>
        double nGrandTotal, nPay;

        /// <summary>
        /// The store credit identifier
        /// </summary>
        Int64 storeCreditID;
        /// <summary>
        /// The amount
        /// </summary>
        double amount;
        /// <summary>
        /// The old balance
        /// </summary>
        double oldBalance;
        /// <summary>
        /// The balance
        /// </summary>
        double balance;
        /// <summary>
        /// The exp date
        /// </summary>
        string expDate;

        /// <summary>
        /// The r count
        /// </summary>
        public int rCnt = 0;

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
        string MemberID;
        /// <summary>
        /// The member name
        /// </summary>
        string MemberName;
        /// <summary>
        /// The pay by
        /// </summary>
        int PayBy = 88;
        /// <summary>
        /// The sell date
        /// </summary>
        string SellDate;
        /// <summary>
        /// The sell time
        /// </summary>
        string SellTime;
        /// <summary>
        /// The sub total
        /// </summary>
        string SubTotal;
        /// <summary>
        /// The tax
        /// </summary>
        string Tax;
        /// <summary>
        /// The discount
        /// </summary>
        double Discount;
        /// <summary>
        /// The member points
        /// </summary>
        double MemberPoints;
        /// <summary>
        /// The receipt type
        /// </summary>
        string ReceiptType;
        /// <summary>
        /// The receipt status
        /// </summary>
        string ReceiptStatus;
        /// <summary>
        /// The receipt identifier
        /// </summary>
        Int64 ReceiptID;

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
        /// The itm original price
        /// </summary>
        double ItmOriginalPrice;
        /// <summary>
        /// The itm save
        /// </summary>
        double ItmSave;

        /// <summary>
        /// The remaining points
        /// </summary>
        double remainingPoints = 0;

        /// <summary>
        /// The itm code
        /// </summary>
        Int64 ItmCode;

        /// <summary>
        /// The pd print
        /// </summary>
        PrintDocument pdPrint;
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
        /// The barcode font
        /// </summary>
        Font printFont, printFont2, printFont3, printFont4, printBoldFont, barcodeFont;
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
        /// The number ofgc
        /// </summary>
        int numOfgc = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreCreditOption"/> class.
        /// </summary>
        /// <param name="grandTotal">The grand total.</param>
        /// <param name="option">The option.</param>
        /// <param name="points">The points.</param>
        public StoreCreditOption(string grandTotal, int option, double points)
        {
            InitializeComponent();
            lblGrandTotal.Text = grandTotal;
            nGrandTotal = Convert.ToDouble(grandTotal.Substring(1));
            opt = option;
            redeem = points;
        }

        /// <summary>
        /// Handles the Load event of the StoreCredit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void StoreCredit_Load(object sender, EventArgs e)
        {
            if (parentForm.storeCode == "TEST")
                cmbStoreCode.Items.Add("TEST");

            if (parentForm.storeCode == "TH")
            {
                cmbStoreCode.SelectedIndex = 0;
            }
            else if (parentForm.storeCode == "OH")
            {
                cmbStoreCode.SelectedIndex = 1;
            }
            else if (parentForm.storeCode == "UM")
            {
                cmbStoreCode.SelectedIndex = 2;
            }
            else if (parentForm.storeCode == "CH")
            {
                cmbStoreCode.SelectedIndex = 3;
            }
            else if (parentForm.storeCode == "WM")
            {
                cmbStoreCode.SelectedIndex = 4;
            }
            else if (parentForm.storeCode == "CV")
            {
                cmbStoreCode.SelectedIndex = 5;
            }
            else if (parentForm.storeCode == "WB")
            {
                cmbStoreCode.SelectedIndex = 6;
            }
            else if (parentForm.storeCode == "WD")
            {
                cmbStoreCode.SelectedIndex = 7;
            }
            else if (parentForm.storeCode == "PW")
            {
                cmbStoreCode.SelectedIndex = 8;
            }
            else if (parentForm.storeCode == "GB")
            {
                cmbStoreCode.SelectedIndex = 9;
            }
            else if (parentForm.storeCode == "BW")
            {
                cmbStoreCode.SelectedIndex = 10;
            }

            richtxtStoreCreditID.Select();
            richtxtStoreCreditID.Focus();
        }

        /// <summary>
        /// Handles the Click event of the btnInput control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnInput_Click(object sender, EventArgs e)
        {
            if (richtxtStoreCreditID.Enabled == false)
                return;

            if (richtxtStoreCreditID.Text == "")
            {
                MyMessageBox.ShowBox("INPUT STORE CREDIT ID", "ERROR");
                richtxtStoreCreditID.Select();
                richtxtStoreCreditID.Focus();
            }
            else
            {
                lblCurrentBalance.Text = "";
                lblRemainingBalance.Text = "";

                if (parentForm.storeCode != cmbStoreCode.Text)
                {
                    if (auth == false)
                    {
                        Authentication authenticationForm = new Authentication(6);
                        authenticationForm.parentForm1 = this.parentForm;
                        authenticationForm.parentForm4 = this;
                        authenticationForm.ShowDialog();
                    }
                    else
                    {
                        //tempIdx = cmbStoreCode.SelectedIndex;

                        try
                        {
                            newConn = new SqlConnection(parentForm.parentForm.OtherStoreConnectionString(cmbStoreCode.Text));

                            if (Int64.TryParse(richtxtStoreCreditID.Text, out storeCreditID))
                            {
                                cmd.Connection = newConn;
                                cmd.CommandText = "Show_StoreCredit_Balance";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@StoreCreditID", SqlDbType.BigInt).Value = storeCreditID;
                                cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = cmbStoreCode.Text;
                                SqlParameter Balance_Param = cmd.Parameters.Add("@Balance", SqlDbType.Money);
                                Balance_Param.Direction = ParameterDirection.Output;

                                newConn.Open();
                                cmd.ExecuteNonQuery();
                                newConn.Close();

                                if (cmd.Parameters["@Balance"].Value == DBNull.Value)
                                {
                                    MyMessageBox.ShowBox("COULD NOT FOUND STORE CREDIT ID", "ERROR");
                                    richtxtStoreCreditID.SelectAll();
                                    richtxtStoreCreditID.Focus();
                                }
                                else if (Convert.ToDouble(cmd.Parameters["@Balance"].Value) == 0)
                                {
                                    MyMessageBox.ShowBox("YOUR BALANCE IS 0", "ERROR");
                                    richtxtStoreCreditID.SelectAll();
                                    richtxtStoreCreditID.Focus();
                                }
                                else
                                {
                                    balance = Convert.ToDouble(cmd.Parameters["@Balance"].Value);
                                    lblCurrentBalance.Text = string.Format("{0:c}", balance);

                                    if ((balance - nGrandTotal) < 0)
                                    {
                                        MyMessageBox.ShowBox("NOT ENOUGH STORE CREDIT\n" + "TRY TO PAY BY MULTIPLE METHODS", "ERROR");
                                        richtxtStoreCreditID.SelectAll();
                                        richtxtStoreCreditID.Focus();
                                    }
                                    else
                                    {
                                        lblRemainingBalance.Text = string.Format("{0:$0.00}", balance - nGrandTotal);
                                    }

                                    if (balance >= nGrandTotal)
                                    {
                                        richtxtStoreCreditID.Enabled = false;
                                        cmbStoreCode.Enabled = false;
                                        btnCheckOut.Enabled = true;
                                    }
                                }
                            }
                            else
                            {
                                MyMessageBox.ShowBox("INVALID STORE CREDIT ID", "ERROR");
                                richtxtStoreCreditID.SelectAll();
                                richtxtStoreCreditID.Focus();
                            }
                        }
                        catch
                        {
                            MyMessageBox.ShowBox("CAN NOT CONNECT SERVER", "ERROR");
                            richtxtStoreCreditID.SelectAll();
                            richtxtStoreCreditID.Focus();
                            return;
                        }
                    }
                }
                else
                {
                    if (Int64.TryParse(richtxtStoreCreditID.Text, out storeCreditID))
                    {
                        cmd.Connection = parentForm.conn;
                        cmd.CommandText = "Show_StoreCredit_Balance";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@StoreCreditID", SqlDbType.BigInt).Value = storeCreditID;
                        cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = cmbStoreCode.Text;
                        SqlParameter Balance_Param = cmd.Parameters.Add("@Balance", SqlDbType.Money);
                        Balance_Param.Direction = ParameterDirection.Output;

                        parentForm.conn.Open();
                        cmd.ExecuteNonQuery();
                        parentForm.conn.Close();

                        if (cmd.Parameters["@Balance"].Value == DBNull.Value)
                        {
                            MyMessageBox.ShowBox("COULD NOT FOUND STORE CREDIT ID", "ERROR");
                            richtxtStoreCreditID.SelectAll();
                            richtxtStoreCreditID.Focus();
                        }
                        else if (Convert.ToDouble(cmd.Parameters["@Balance"].Value) == 0)
                        {
                            MyMessageBox.ShowBox("YOUR BALANCE IS 0", "ERROR");
                            richtxtStoreCreditID.SelectAll();
                            richtxtStoreCreditID.Focus();
                        }
                        else
                        {
                            balance = Convert.ToDouble(cmd.Parameters["@Balance"].Value);
                            lblCurrentBalance.Text = string.Format("{0:c}", balance);

                            if ((balance - nGrandTotal) < 0)
                            {
                                MyMessageBox.ShowBox("NOT ENOUGH STORE CREDIT\n" + "TRY TO PAY BY MULTIPLE METHODS", "ERROR");
                                richtxtStoreCreditID.SelectAll();
                                richtxtStoreCreditID.Focus();
                            }
                            else
                            {
                                lblRemainingBalance.Text = string.Format("{0:$0.00}", balance - nGrandTotal);
                            }

                            if (balance >= nGrandTotal)
                            {
                                richtxtStoreCreditID.Enabled = false;
                                cmbStoreCode.Enabled = false;
                                btnCheckOut.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        MyMessageBox.ShowBox("INVALID STORE CREDIT ID", "ERROR");
                        richtxtStoreCreditID.SelectAll();
                        richtxtStoreCreditID.Focus();
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCheckOut control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            btnCheckOut.BackColor = Color.Gray;
            btnCheckOut.Enabled = false;
            nPay = Convert.ToDouble(lblGrandTotal.Text.Trim().ToString().Substring(1));
            DateTime currentTime = DateTime.Now;
            rCnt = parentForm.dataGridView1.RowCount;

            Calculating_StoreCredit_Balance();
            lblRemainingBalance.Text = string.Format("{0:$0.00}", balance - nGrandTotal);

            if (nPay > 0)
            {
                if (parentForm.storeCode != cmbStoreCode.Text)
                {
                    StoreCode = cmbStoreCode.Text;
                    CashierID = parentForm.employeeID;
                    RegisterNum = parentForm.cashRegisterNum;
                    MemberID = parentForm.lblMemberCode.Text;
                    MemberName = parentForm.lblName.Text;
                    //SellDate = string.Format("{0:d}", currentTime);
                    SellDate = string.Format("{0:MM/dd/yyyy}", currentTime);
                    SellTime = string.Format("{0:T}", currentTime);
                    SubTotal = parentForm.lblSubTotal.Text.Substring(1);
                    Tax = parentForm.lblTax.Text.Substring(1);

                    Discount = 0;
                    for (i = 0; i < rCnt; i++)
                    {
                        if (parentForm.dataGridView1.Rows[i].Cells[7].Value.ToString() == "000000999111")
                        {
                        }
                        else if (Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[16].Value) > 0)
                        {
                            //int qty = Convert.ToInt16(parentForm.dataGridView1.Rows[i].Cells[2].Value);
                            //double unitPrice = Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[3].Value);
                            //double discountPrice = Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[4].Value);
                            //Discount = Discount + (unitPrice - discountPrice) * qty;
                            Discount = Discount + Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[16].Value);
                        }
                        else if (parentForm.dataGridView1.Rows[i].Cells[7].Value.ToString() == "000000999110")
                        {
                            Discount = Discount - Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[5].Value);
                        }
                        else if (parentForm.dataGridView1.Rows[i].Cells[7].Value.ToString() == "000000999109")
                        {
                            Discount = Discount - Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[5].Value);
                        }
                    }

                    if (opt == 0)
                    {
                        MemberPoints = 0;
                    }
                    else
                    {
                        if (parentForm.lblType.Text == parentForm.MType1)
                        {
                            MemberPoints = Math.Round(Convert.ToDouble(SubTotal) * (parentForm.MPts1 / 100), 2, MidpointRounding.AwayFromZero);
                        }
                        else if (parentForm.lblType.Text == parentForm.MType2)
                        {
                            MemberPoints = Math.Round(Convert.ToDouble(SubTotal) * (parentForm.MPts2 / 100), 2, MidpointRounding.AwayFromZero);
                        }
                        else if (parentForm.lblType.Text == parentForm.MType3)
                        {
                            MemberPoints = Math.Round(Convert.ToDouble(SubTotal) * (parentForm.MPts3 / 100), 2, MidpointRounding.AwayFromZero);
                        }
                        else if (parentForm.lblType.Text == parentForm.MType4)
                        {
                            MemberPoints = Math.Round(Convert.ToDouble(SubTotal) * (parentForm.MPts4 / 100), 2, MidpointRounding.AwayFromZero);
                        }
                        else if (parentForm.lblType.Text == parentForm.MType5)
                        {
                            MemberPoints = Math.Round(Convert.ToDouble(SubTotal) * (parentForm.MPts5 / 100), 2, MidpointRounding.AwayFromZero);
                        }
                        else
                        {
                            MemberPoints = 0;
                        }
                    }

                    ReceiptType = "SALES";
                    ReceiptStatus = "ISSUED";

                    SqlCommand cmd_ReceiptHeader = new SqlCommand("Create_ReceiptHeader_Information", parentForm.conn);
                    cmd_ReceiptHeader.CommandType = CommandType.StoredProcedure;
                    cmd_ReceiptHeader.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = parentForm.storeCode.ToUpper();
                    cmd_ReceiptHeader.Parameters.Add("@CashierID", SqlDbType.NVarChar).Value = CashierID;
                    cmd_ReceiptHeader.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = RegisterNum;
                    cmd_ReceiptHeader.Parameters.Add("@MemberID", SqlDbType.NVarChar).Value = MemberID;
                    cmd_ReceiptHeader.Parameters.Add("@MemberName", SqlDbType.NVarChar).Value = MemberName;
                    cmd_ReceiptHeader.Parameters.Add("@PayBy", SqlDbType.Int).Value = PayBy;
                    cmd_ReceiptHeader.Parameters.Add("@SellDate", SqlDbType.NVarChar).Value = SellDate;
                    cmd_ReceiptHeader.Parameters.Add("@SellTime", SqlDbType.NVarChar).Value = SellTime;
                    cmd_ReceiptHeader.Parameters.Add("@SubTotal", SqlDbType.Money).Value = SubTotal;
                    cmd_ReceiptHeader.Parameters.Add("@GrandTotal", SqlDbType.Money).Value = nGrandTotal;
                    cmd_ReceiptHeader.Parameters.Add("@Tax", SqlDbType.Money).Value = Tax;
                    cmd_ReceiptHeader.Parameters.Add("@Discount", SqlDbType.Money).Value = Discount;
                    cmd_ReceiptHeader.Parameters.Add("@MemberPoints", SqlDbType.Money).Value = MemberPoints;
                    cmd_ReceiptHeader.Parameters.Add("@Pay", SqlDbType.Money).Value = nPay;
                    cmd_ReceiptHeader.Parameters.Add("@Change", SqlDbType.Money).Value = 0;
                    cmd_ReceiptHeader.Parameters.Add("@ReceiptType", SqlDbType.NVarChar).Value = ReceiptType;
                    cmd_ReceiptHeader.Parameters.Add("@ReceiptStatus", SqlDbType.NVarChar).Value = ReceiptStatus;
                    parentForm.conn.Open();
                    cmd_ReceiptHeader.ExecuteNonQuery();
                    parentForm.conn.Close();

                    SqlCommand cmd_ReceiptID = new SqlCommand("Get_ReceiptID", parentForm.conn);
                    cmd_ReceiptID.CommandType = CommandType.StoredProcedure;
                    cmd_ReceiptID.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = parentForm.storeCode.ToUpper();
                    cmd_ReceiptID.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = RegisterNum;
                    cmd_ReceiptID.Parameters.Add("@SellDate", SqlDbType.NVarChar).Value = SellDate;
                    cmd_ReceiptID.Parameters.Add("@SellTime", SqlDbType.NVarChar).Value = SellTime;
                    SqlParameter ReceiptID_Param = cmd_ReceiptID.Parameters.Add("@ReceiptID", SqlDbType.BigInt);
                    ReceiptID_Param.Direction = ParameterDirection.Output;
                    parentForm.conn.Open();
                    cmd_ReceiptID.ExecuteNonQuery();
                    parentForm.conn.Close();
                    ReceiptID = Convert.ToInt64(cmd_ReceiptID.Parameters["@ReceiptID"].Value);

                    for (i = 1; i <= rCnt; i++)
                    {
                        ItmBrand = parentForm.dataGridView1.Rows[i - 1].Cells[0].Value.ToString();
                        ItmName = parentForm.dataGridView1.Rows[i - 1].Cells[1].Value.ToString();
                        ItmQty = parentForm.dataGridView1.Rows[i - 1].Cells[2].Value.ToString();
                        ItmGroup1 = parentForm.dataGridView1.Rows[i - 1].Cells[8].Value.ToString();
                        ItmGroup2 = parentForm.dataGridView1.Rows[i - 1].Cells[9].Value.ToString();
                        ItmGroup3 = parentForm.dataGridView1.Rows[i - 1].Cells[10].Value.ToString();
                        string ItmGroup4 = "0";
                        string ItmGroup5 = "0";
                        ItmUpc = parentForm.dataGridView1.Rows[i - 1].Cells[7].Value.ToString();

                        if (ItmUpc == "B4UGIFTCARD1" | ItmUpc == "B4UGIFTCARD2" | ItmUpc == "B4UGIFTCARD3")
                            numOfgc = numOfgc + 1;

                        ItmBasePrice = Convert.ToDouble(parentForm.dataGridView1.Rows[i - 1].Cells[3].Value);
                        ItmDiscountPrice = Convert.ToDouble(parentForm.dataGridView1.Rows[i - 1].Cells[4].Value);
                        ItmPrice = Convert.ToDouble(parentForm.dataGridView1.Rows[i - 1].Cells[5].Value);
                        ItmSize = parentForm.dataGridView1.Rows[i - 1].Cells[13].Value.ToString();
                        ItmColor = parentForm.dataGridView1.Rows[i - 1].Cells[14].Value.ToString();

                        SqlCommand cmd_ReceiptBody = new SqlCommand("Create_ReceiptBody_Information", parentForm.conn);
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
                        cmd_ReceiptBody.Parameters.Add("@SellDate", SqlDbType.NVarChar).Value = SellDate;
                        cmd_ReceiptBody.Parameters.Add("@SellTime", SqlDbType.NVarChar).Value = SellTime;

                        ItmCode = Convert.ToInt64(parentForm.dataGridView1.Rows[i - 1].Cells[15].Value);

                        if (ItmGroup1 == "9" | ItmGroup1 == "10" | ItmGroup1 == "11")
                        {
                            parentForm.conn.Open();
                            cmd_ReceiptBody.ExecuteNonQuery();
                            parentForm.conn.Close();
                        }
                        else
                        {
                            SqlCommand cmd_CalculatingOnHand = new SqlCommand("Calculating_OnHand", parentForm.conn);
                            cmd_CalculatingOnHand.CommandType = CommandType.StoredProcedure;
                            //cmd_CalculatingOnHand.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = ItmGroup1;
                            //cmd_CalculatingOnHand.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = ItmGroup2;
                            //cmd_CalculatingOnHand.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = ItmGroup3;
                            //cmd_CalculatingOnHand.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                            //cmd_CalculatingOnHand.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = ItmName;
                            //cmd_CalculatingOnHand.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
                            //cmd_CalculatingOnHand.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
                            //cmd_CalculatingOnHand.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
                            cmd_CalculatingOnHand.Parameters.Add("@ItmCode", SqlDbType.BigInt).Value = ItmCode;
                            cmd_CalculatingOnHand.Parameters.Add("@ItmQty", SqlDbType.Int).Value = Convert.ToInt16(ItmQty);

                            parentForm.conn.Open();
                            cmd_ReceiptBody.ExecuteNonQuery();
                            cmd_CalculatingOnHand.ExecuteNonQuery();
                            parentForm.conn.Close();
                        }
                    }

                    SqlCommand cmd_StoreCreditInfo = new SqlCommand("Get_StoreCredit_Info", newConn);
                    cmd_StoreCreditInfo.CommandType = CommandType.StoredProcedure;
                    cmd_StoreCreditInfo.Parameters.Add("@StoreCreditID", SqlDbType.BigInt).Value = storeCreditID;
                    SqlParameter Amount_Param = cmd_StoreCreditInfo.Parameters.Add("@Amount", SqlDbType.Money);
                    SqlParameter Balance_Param = cmd_StoreCreditInfo.Parameters.Add("@Balance", SqlDbType.Money);
                    SqlParameter ExpDate_Param = cmd_StoreCreditInfo.Parameters.Add("@ExpDate", SqlDbType.NVarChar, 20);
                    Amount_Param.Direction = ParameterDirection.Output;
                    Balance_Param.Direction = ParameterDirection.Output;
                    ExpDate_Param.Direction = ParameterDirection.Output;

                    newConn.Open();
                    cmd_StoreCreditInfo.ExecuteNonQuery();
                    newConn.Close();

                    amount = Convert.ToDouble(cmd_StoreCreditInfo.Parameters["@Amount"].Value);
                    balance = Convert.ToDouble(cmd_StoreCreditInfo.Parameters["@Balance"].Value);
                    expDate = cmd_StoreCreditInfo.Parameters["@ExpDate"].Value.ToString();

                    if (parentForm.CouponAmt > 0)
                    {
                        Create_Redeem_History(3, 9, parentForm.CouponAmt, parentForm.CouponDesc, parentForm.CouponMgrID);
                        parentForm.CouponAmt = 0;
                        parentForm.CouponDesc = string.Empty;
                        parentForm.CouponMgrID = string.Empty;
                    }

                    if (parentForm.giftcardRedeem > 0)
                    {
                        //Create_Redeem_History(2, 11, parentForm.giftcardRedeem);
                        Calculate_Giftcard_Balance();
                        parentForm.giftcardRedeem = 0;
                        parentForm.giftcardCodeDesc = "";
                        parentForm.giftcardStoreCode = "";
                    }

                    if (parentForm.cpRedeem == true)
                    {
                        parentForm.Coupon_Update(parentForm.wp_cpNum, ReceiptID);
                        parentForm.cpRedeem = false;
                        parentForm.wp_cpNum = string.Empty;
                        parentForm.wp_cpDescription = string.Empty;
                        parentForm.wp_cpTargetItem = string.Empty;
                    }

                    if (parentForm.smDiscount == true)
                    {
                        parentForm.SocialMediaDiscount_History(StoreCode, ReceiptID, MemberID, MemberName, parentForm.smCashierID);
                    }

                    if (parentForm.eDiscount1 == true)
                    {
                        parentForm.ExtraDiscount_History(StoreCode, ReceiptID, MemberID, MemberName, parentForm.eCashierID);
                    }

                    if (numOfgc > 0)
                        parentForm.Giftcard_Activation();

                    if (MemberID == "0" | MemberID == "101" | MemberID == "")
                    {
                        Create_Redeem_History(1, storeCreditID, nGrandTotal, StoreCode);
                    }
                    else
                    {
                        Calculate_Customer_Points();
                        parentForm.Customer_Transaction_Update(1, parentForm.storeCode, Convert.ToInt64(MemberID), nGrandTotal, SellDate);

                        if (redeem > 0)
                            Create_Redeem_History(0, 10, redeem);

                        remainingPoints = Remaining_Points(parentForm.storeCode, Convert.ToInt64(MemberID));
                        Create_Redeem_History(1, storeCreditID, nGrandTotal, StoreCode);
                    }

                    Int32 retVal;
                    String errMsg;
                    apiAlias.StatusMonitoring pMonitorCB = new apiAlias.StatusMonitoring(StatusMonitoring);

                    pdPrint = new PrintDocument();
                    pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage);
                    pdPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;

                    try
                    {
                        // Open Printer Monitor of Status API.
                        mpHandle = apiAlias.BiOpenMonPrinter(apiAlias.TYPE_PRINTER, pdPrint.PrinterSettings.PrinterName);
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
                                //pdPrint.Print();

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
                                    OpenDrawer(pdPrint.PrinterSettings.PrinterName);

                                    /*if (MemberID != "101" | MemberID != "")
                                    {
                                        Calculate_Customer_Points();
                                        remainingPoints = Remaining_Points(parentForm.storeCode, Convert.ToInt64(MemberID));
                                    }*/

                                    pdPrint.Print();
                                }

                                //if (MemberID != "101" | MemberID != "")
                                //    Calculate_Customer_Points();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        errMsg = ex.Message;
                        MessageBox.Show("Failed to open StatusAPI.", "Printing error", MessageBoxButtons.OK);
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

                    parentForm.lblQty.Text = "1";
                    parentForm.lblTotalQty.Text = "0";
                    parentForm.lblSubTotal.Text = "$0.00";
                    parentForm.lblTax.Text = "$0.00";
                    parentForm.lblGrandTotal.Text = "$0.00";
                    parentForm.dt.Clear();
                    parentForm.dataGridView1.DataSource = null;
                    //parentForm.radioBtnDefault.Checked = true;
                    parentForm.lblMemberCode.Text = parentForm.defaultMemberCode;
                    parentForm.lblName.Text = parentForm.defaultMemberName;
                    parentForm.lblType.Text = parentForm.defaultMemberType;
                    parentForm.lblPoints.Text = parentForm.defaultMemberPoints;
                    parentForm.points = 0;
                    parentForm.CtmPoint = 0;
                    parentForm.SetFocusOnInputBox();

                    parentForm.giftcardRedeem = 0;
                    parentForm.giftcardCodeDesc = string.Empty;
                    parentForm.giftcardStoreCode = string.Empty;

                    parentForm.CouponAmt = 0;
                    parentForm.CouponDesc = string.Empty;
                    parentForm.CouponMgrID = string.Empty;

                    parentForm.boolNumSecondVisitCoupon = false;
                    parentForm.PTrns = 0;
                    parentForm.TTrns = 0;

                    parentForm.smDiscount = false;
                    parentForm.smCashierID = "";

                    parentForm.eDiscount1 = false;
                    parentForm.eCashierID = "";

                    parentForm.Enabled = true;
                    this.Close();
                    parentForm.richTxtUpc.Select();
                    parentForm.richTxtUpc.Focus();
                }
                else
                {
                    StoreCode = parentForm.storeCode;
                    CashierID = parentForm.employeeID;
                    RegisterNum = parentForm.cashRegisterNum;
                    MemberID = parentForm.lblMemberCode.Text;
                    MemberName = parentForm.lblName.Text;
                    //SellDate = string.Format("{0:d}", currentTime);
                    SellDate = string.Format("{0:MM/dd/yyyy}", currentTime);
                    SellTime = string.Format("{0:T}", currentTime);
                    SubTotal = parentForm.lblSubTotal.Text.Substring(1);
                    Tax = parentForm.lblTax.Text.Substring(1);

                    Discount = 0;
                    for (i = 0; i < rCnt; i++)
                    {
                        if (parentForm.dataGridView1.Rows[i].Cells[7].Value.ToString() == "000000999111")
                        {
                        }
                        else if (Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[16].Value) > 0)
                        {
                            int qty = Convert.ToInt16(parentForm.dataGridView1.Rows[i].Cells[2].Value);
                            double unitPrice = Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[3].Value);
                            double discountPrice = Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[4].Value);
                            Discount = Discount + (unitPrice - discountPrice) * qty;
                        }
                        else if (parentForm.dataGridView1.Rows[i].Cells[7].Value.ToString() == "000000999110")
                        {
                            Discount = Discount - Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[5].Value);
                        }
                        else if (parentForm.dataGridView1.Rows[i].Cells[7].Value.ToString() == "000000999109")
                        {
                            Discount = Discount - Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[5].Value);
                        }
                    }

                    if (opt == 0)
                    {
                        MemberPoints = 0;
                    }
                    else
                    {
                        if (parentForm.lblType.Text == parentForm.MType1)
                        {
                            MemberPoints = Math.Round(Convert.ToDouble(SubTotal) * (parentForm.MPts1 / 100), 2, MidpointRounding.AwayFromZero);
                        }
                        else if (parentForm.lblType.Text == parentForm.MType2)
                        {
                            MemberPoints = Math.Round(Convert.ToDouble(SubTotal) * (parentForm.MPts2 / 100), 2, MidpointRounding.AwayFromZero);
                        }
                        else if (parentForm.lblType.Text == parentForm.MType3)
                        {
                            MemberPoints = Math.Round(Convert.ToDouble(SubTotal) * (parentForm.MPts3 / 100), 2, MidpointRounding.AwayFromZero);
                        }
                        else if (parentForm.lblType.Text == parentForm.MType4)
                        {
                            MemberPoints = Math.Round(Convert.ToDouble(SubTotal) * (parentForm.MPts4 / 100), 2, MidpointRounding.AwayFromZero);
                        }
                        else if (parentForm.lblType.Text == parentForm.MType5)
                        {
                            MemberPoints = Math.Round(Convert.ToDouble(SubTotal) * (parentForm.MPts5 / 100), 2, MidpointRounding.AwayFromZero);
                        }
                        else
                        {
                            MemberPoints = 0;
                        }
                    }

                    ReceiptType = "SALES";
                    ReceiptStatus = "ISSUED";

                    SqlCommand cmd_ReceiptHeader = new SqlCommand("Create_ReceiptHeader_Information", parentForm.conn);
                    cmd_ReceiptHeader.CommandType = CommandType.StoredProcedure;
                    cmd_ReceiptHeader.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = StoreCode;
                    cmd_ReceiptHeader.Parameters.Add("@CashierID", SqlDbType.NVarChar).Value = CashierID;
                    cmd_ReceiptHeader.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = RegisterNum;
                    cmd_ReceiptHeader.Parameters.Add("@MemberID", SqlDbType.NVarChar).Value = MemberID;
                    cmd_ReceiptHeader.Parameters.Add("@MemberName", SqlDbType.NVarChar).Value = MemberName;
                    cmd_ReceiptHeader.Parameters.Add("@PayBy", SqlDbType.Int).Value = PayBy;
                    cmd_ReceiptHeader.Parameters.Add("@SellDate", SqlDbType.NVarChar).Value = SellDate;
                    cmd_ReceiptHeader.Parameters.Add("@SellTime", SqlDbType.NVarChar).Value = SellTime;
                    cmd_ReceiptHeader.Parameters.Add("@SubTotal", SqlDbType.Money).Value = SubTotal;
                    cmd_ReceiptHeader.Parameters.Add("@GrandTotal", SqlDbType.Money).Value = nGrandTotal;
                    cmd_ReceiptHeader.Parameters.Add("@Tax", SqlDbType.Money).Value = Tax;
                    cmd_ReceiptHeader.Parameters.Add("@Discount", SqlDbType.Money).Value = Discount;
                    cmd_ReceiptHeader.Parameters.Add("@MemberPoints", SqlDbType.Money).Value = MemberPoints;
                    cmd_ReceiptHeader.Parameters.Add("@Pay", SqlDbType.Money).Value = nPay;
                    cmd_ReceiptHeader.Parameters.Add("@Change", SqlDbType.Money).Value = 0;
                    cmd_ReceiptHeader.Parameters.Add("@ReceiptType", SqlDbType.NVarChar).Value = ReceiptType;
                    cmd_ReceiptHeader.Parameters.Add("@ReceiptStatus", SqlDbType.NVarChar).Value = ReceiptStatus;
                    parentForm.conn.Open();
                    cmd_ReceiptHeader.ExecuteNonQuery();
                    parentForm.conn.Close();

                    SqlCommand cmd_ReceiptID = new SqlCommand("Get_ReceiptID", parentForm.conn);
                    cmd_ReceiptID.CommandType = CommandType.StoredProcedure;
                    cmd_ReceiptID.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = StoreCode;
                    cmd_ReceiptID.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = RegisterNum;
                    cmd_ReceiptID.Parameters.Add("@SellDate", SqlDbType.NVarChar).Value = SellDate;
                    cmd_ReceiptID.Parameters.Add("@SellTime", SqlDbType.NVarChar).Value = SellTime;
                    SqlParameter ReceiptID_Param = cmd_ReceiptID.Parameters.Add("@ReceiptID", SqlDbType.BigInt);
                    ReceiptID_Param.Direction = ParameterDirection.Output;
                    parentForm.conn.Open();
                    cmd_ReceiptID.ExecuteNonQuery();
                    parentForm.conn.Close();
                    ReceiptID = Convert.ToInt64(cmd_ReceiptID.Parameters["@ReceiptID"].Value);

                    for (i = 1; i <= rCnt; i++)
                    {
                        ItmBrand = parentForm.dataGridView1.Rows[i - 1].Cells[0].Value.ToString();
                        ItmName = parentForm.dataGridView1.Rows[i - 1].Cells[1].Value.ToString();
                        ItmQty = parentForm.dataGridView1.Rows[i - 1].Cells[2].Value.ToString();
                        ItmGroup1 = parentForm.dataGridView1.Rows[i - 1].Cells[8].Value.ToString();
                        ItmGroup2 = parentForm.dataGridView1.Rows[i - 1].Cells[9].Value.ToString();
                        ItmGroup3 = parentForm.dataGridView1.Rows[i - 1].Cells[10].Value.ToString();
                        string ItmGroup4 = "0";
                        string ItmGroup5 = "0";
                        ItmUpc = parentForm.dataGridView1.Rows[i - 1].Cells[7].Value.ToString();

                        if (ItmUpc == "B4UGIFTCARD1" | ItmUpc == "B4UGIFTCARD2" | ItmUpc == "B4UGIFTCARD3")
                            numOfgc = numOfgc + 1;

                        ItmBasePrice = Convert.ToDouble(parentForm.dataGridView1.Rows[i - 1].Cells[3].Value);
                        ItmDiscountPrice = Convert.ToDouble(parentForm.dataGridView1.Rows[i - 1].Cells[4].Value);
                        ItmPrice = Convert.ToDouble(parentForm.dataGridView1.Rows[i - 1].Cells[5].Value);
                        ItmSize = parentForm.dataGridView1.Rows[i - 1].Cells[13].Value.ToString();
                        ItmColor = parentForm.dataGridView1.Rows[i - 1].Cells[14].Value.ToString();

                        SqlCommand cmd_ReceiptBody = new SqlCommand("Create_ReceiptBody_Information", parentForm.conn);
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
                        cmd_ReceiptBody.Parameters.Add("@SellDate", SqlDbType.NVarChar).Value = SellDate;
                        cmd_ReceiptBody.Parameters.Add("@SellTime", SqlDbType.NVarChar).Value = SellTime;

                        ItmCode = Convert.ToInt64(parentForm.dataGridView1.Rows[i - 1].Cells[15].Value);

                        if (ItmGroup1 == "9" | ItmGroup1 == "10" | ItmGroup1 == "11")
                        {
                            parentForm.conn.Open();
                            cmd_ReceiptBody.ExecuteNonQuery();
                            parentForm.conn.Close();
                        }
                        else
                        {
                            SqlCommand cmd_CalculatingOnHand = new SqlCommand("Calculating_OnHand", parentForm.conn);
                            cmd_CalculatingOnHand.CommandType = CommandType.StoredProcedure;
                            //cmd_CalculatingOnHand.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = ItmGroup1;
                            //cmd_CalculatingOnHand.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = ItmGroup2;
                            //cmd_CalculatingOnHand.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = ItmGroup3;
                            //cmd_CalculatingOnHand.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                            //cmd_CalculatingOnHand.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = ItmName;
                            //cmd_CalculatingOnHand.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
                            //cmd_CalculatingOnHand.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
                            //cmd_CalculatingOnHand.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
                            cmd_CalculatingOnHand.Parameters.Add("@ItmCode", SqlDbType.BigInt).Value = ItmCode;
                            cmd_CalculatingOnHand.Parameters.Add("@ItmQty", SqlDbType.Int).Value = Convert.ToInt16(ItmQty);

                            parentForm.conn.Open();
                            cmd_ReceiptBody.ExecuteNonQuery();
                            cmd_CalculatingOnHand.ExecuteNonQuery();
                            parentForm.conn.Close();
                        }
                    }

                    SqlCommand cmd_StoreCreditInfo = new SqlCommand("Get_StoreCredit_Info", parentForm.conn);
                    cmd_StoreCreditInfo.CommandType = CommandType.StoredProcedure;
                    cmd_StoreCreditInfo.Parameters.Add("@StoreCreditID", SqlDbType.BigInt).Value = storeCreditID;
                    SqlParameter Amount_Param = cmd_StoreCreditInfo.Parameters.Add("@Amount", SqlDbType.Money);
                    SqlParameter Balance_Param = cmd_StoreCreditInfo.Parameters.Add("@Balance", SqlDbType.Money);
                    SqlParameter ExpDate_Param = cmd_StoreCreditInfo.Parameters.Add("@ExpDate", SqlDbType.NVarChar, 20);
                    Amount_Param.Direction = ParameterDirection.Output;
                    Balance_Param.Direction = ParameterDirection.Output;
                    ExpDate_Param.Direction = ParameterDirection.Output;

                    parentForm.conn.Open();
                    cmd_StoreCreditInfo.ExecuteNonQuery();
                    parentForm.conn.Close();

                    amount = Convert.ToDouble(cmd_StoreCreditInfo.Parameters["@Amount"].Value);
                    balance = Convert.ToDouble(cmd_StoreCreditInfo.Parameters["@Balance"].Value);
                    expDate = cmd_StoreCreditInfo.Parameters["@ExpDate"].Value.ToString();

                    if (parentForm.CouponAmt > 0)
                    {
                        Create_Redeem_History(3, 9, parentForm.CouponAmt, parentForm.CouponDesc, parentForm.CouponMgrID);
                        parentForm.CouponAmt = 0;
                        parentForm.CouponDesc = string.Empty;
                        parentForm.CouponMgrID = string.Empty;
                    }

                    if (parentForm.giftcardRedeem > 0)
                    {
                        //Create_Redeem_History(2, 11, parentForm.giftcardRedeem);
                        Calculate_Giftcard_Balance();
                        parentForm.giftcardRedeem = 0;
                        parentForm.giftcardCodeDesc = "";
                        parentForm.giftcardStoreCode = "";
                    }

                    if (parentForm.cpRedeem == true)
                    {
                        parentForm.Coupon_Update(parentForm.wp_cpNum, ReceiptID);
                        parentForm.cpRedeem = false;
                        parentForm.wp_cpNum = string.Empty;
                        parentForm.wp_cpDescription = string.Empty;
                        parentForm.wp_cpTargetItem = string.Empty;
                    }

                    if (parentForm.smDiscount == true)
                    {
                        parentForm.SocialMediaDiscount_History(StoreCode, ReceiptID, MemberID, MemberName, parentForm.smCashierID);
                    }

                    if (parentForm.eDiscount1 == true)
                    {
                        parentForm.ExtraDiscount_History(StoreCode, ReceiptID, MemberID, MemberName, parentForm.eCashierID);
                    }

                    if (numOfgc > 0)
                        parentForm.Giftcard_Activation();

                    if (MemberID == "0" | MemberID == "101" | MemberID == "")
                    {
                        Create_Redeem_History(1, storeCreditID, nGrandTotal);
                    }
                    else
                    {
                        Calculate_Customer_Points();
                        parentForm.Customer_Transaction_Update(1, parentForm.storeCode, Convert.ToInt64(MemberID), nGrandTotal, SellDate);

                        if (redeem > 0)
                            Create_Redeem_History(0, 10, redeem);

                        remainingPoints = Remaining_Points(parentForm.storeCode, Convert.ToInt64(MemberID));
                        Create_Redeem_History(1, storeCreditID, nGrandTotal);
                    }

                    Int32 retVal;
                    String errMsg;
                    apiAlias.StatusMonitoring pMonitorCB = new apiAlias.StatusMonitoring(StatusMonitoring);

                    pdPrint = new PrintDocument();
                    pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage);
                    pdPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;

                    try
                    {
                        // Open Printer Monitor of Status API.
                        mpHandle = apiAlias.BiOpenMonPrinter(apiAlias.TYPE_PRINTER, pdPrint.PrinterSettings.PrinterName);
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
                                //pdPrint.Print();

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
                                    OpenDrawer(pdPrint.PrinterSettings.PrinterName);
                                    pdPrint.Print();
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

                    parentForm.lblQty.Text = "1";
                    parentForm.lblTotalQty.Text = "0";
                    parentForm.lblSubTotal.Text = "$0.00";
                    parentForm.lblTax.Text = "$0.00";
                    parentForm.lblGrandTotal.Text = "$0.00";
                    parentForm.dt.Clear();
                    parentForm.dataGridView1.DataSource = null;
                    //parentForm.radioBtnDefault.Checked = true;
                    parentForm.lblMemberCode.Text = parentForm.defaultMemberCode;
                    parentForm.lblName.Text = parentForm.defaultMemberName;
                    parentForm.lblType.Text = parentForm.defaultMemberType;
                    parentForm.lblPoints.Text = parentForm.defaultMemberPoints;
                    parentForm.points = 0;
                    parentForm.CtmPoint = 0;
                    parentForm.SetFocusOnInputBox();

                    parentForm.giftcardRedeem = 0;
                    parentForm.giftcardCodeDesc = string.Empty;
                    parentForm.giftcardStoreCode = string.Empty;

                    parentForm.CouponAmt = 0;
                    parentForm.CouponDesc = string.Empty;
                    parentForm.CouponMgrID = string.Empty;

                    parentForm.boolNumSecondVisitCoupon = false;
                    parentForm.PTrns = 0;
                    parentForm.TTrns = 0;

                    parentForm.smDiscount = false;
                    parentForm.smCashierID = "";

                    parentForm.eDiscount1 = false;
                    parentForm.eCashierID = "";

                    parentForm.Enabled = true;
                    this.Close();
                    parentForm.richTxtUpc.Select();
                    parentForm.richTxtUpc.Focus();
                }

            }
            else
            {
                MyMessageBox.ShowBox("INPUT CORRECT AMOUNT", "ERROR");
                //MessageBox.Show("Input correct amount", "Error");
                return;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            parentForm.Enabled = true;
            this.Close();
            parentForm.LineDisply(parentForm.openingMSG1, parentForm.openingMSG2);
            parentForm.richTxtUpc.Select();
            parentForm.richTxtUpc.Focus();
        }

        /// <summary>
        /// Handles the Click event of the richtxtStoreCreditID control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void richtxtStoreCreditID_Click(object sender, EventArgs e)
        {
            richtxtStoreCreditID.SelectAll();
            richtxtStoreCreditID.Focus();
        }

        /// <summary>
        /// Handles the PrintPage event of the pdPrint control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PrintPageEventArgs"/> instance containing the event data.</param>
        private void pdPrint_PrintPage(object sender, PrintPageEventArgs e)
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
            //text.Add("MULTI");
            text.Add("STORE CREDIT");
            text.Add("DATE & TIME");
            text.Add(":");
            text.Add(Convert.ToString(SellDate) + " " + Convert.ToString(SellTime));
            text.Add("RECEIPT ID");
            text.Add(":");
            //text.Add("BCAT-372031");
            text.Add(parentForm.storeCode + "-" + Convert.ToString(ReceiptID));
            text.Add("CASHIER ID");
            text.Add(":");
            text.Add(Convert.ToString(CashierID));
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
            text.Add("       DESCRIPTION                          QTY   PRICE    ");
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
                ItmOriginalPrice = Math.Round(ItmBasePrice * Convert.ToInt16(ItmQty), 2);

                if (ItmDiscountPrice == ItmBasePrice & ItmDiscountPrice > 0)
                {
                    text.Add(ItmName);
                    text.Add(ItmQty);
                    text.Add("");
                    text.Add(string.Format("{0:$0.00}", ItmPrice) + " T");
                    text.Add(ItmUpc);
                    text.Add("-FINAL SALE PRICE: " + string.Format("{0:$0.00}", ItmBasePrice) + " * " + ItmQty + " = " + string.Format("{0:$0.00}", ItmOriginalPrice));
                    text.Add(" ");
                }
                else if (ItmDiscountPrice > 0)
                {
                    ItmSave = ItmOriginalPrice - Convert.ToDouble(ItmPrice);
                    text.Add(ItmName);
                    text.Add(ItmQty);
                    text.Add("");
                    text.Add(string.Format("{0:$0.00}", ItmPrice) + " T");
                    text.Add(ItmUpc + "(REGULAR PRICE: " + string.Format("{0:$0.00}", ItmBasePrice) + " * " + ItmQty + " = " + ItmOriginalPrice + ")");
                    text.Add("-DISCOUNT PRICE: " + string.Format("{0:$0.00}", ItmDiscountPrice) + " * " + ItmQty + " =" + string.Format("{0:$0.00}", ItmPrice) + " /SAVED: " + string.Format("{0:$0.00}", ItmSave));
                    text.Add(" ");
                }
                else if (ItmUpc == "000000999111")
                {
                    text.Add(ItmName);
                    text.Add(" ");
                    text.Add("");
                    text.Add(string.Format("{0:$0.00}", ItmPrice));
                    text.Add(ItmUpc);
                    text.Add("-AMOUNT USED: " + string.Format("{0:$0.00}", -ItmPrice));
                    text.Add(" ");
                }
                else if (ItmUpc == "000000999112")
                {
                    text.Add(ItmName);
                    text.Add(" ");
                    text.Add(" ");
                    text.Add(" ");
                    text.Add(ItmUpc);
                    text.Add("-COUPON USED");
                    text.Add(" ");
                }
                else if (ItmPrice == 0)
                {
                    ItmSave = ItmOriginalPrice - Convert.ToDouble(ItmPrice);
                    text.Add(ItmName);
                    text.Add(ItmQty);
                    text.Add("");
                    text.Add(string.Format("{0:$0.00}", ItmPrice) + " T");
                    text.Add(ItmUpc + "(REGULAR PRICE: " + string.Format("{0:$0.00}", ItmBasePrice) + " * " + ItmQty + " = " + ItmOriginalPrice + ")");
                    text.Add("-DISCOUNT PRICE: " + string.Format("{0:$0.00}", ItmPrice) + " * " + ItmQty + " =" + string.Format("{0:$0.00}", ItmPrice) + " /SAVED: " + string.Format("{0:$0.00}", ItmSave));
                    text.Add(" ");
                }
                else if (ItmBasePrice == 0 & ItmQty == "0")
                {
                    text.Add(ItmName);
                    text.Add(" ");
                    text.Add("");
                    text.Add(string.Format("{0:$0.00}", ItmPrice));
                    text.Add(ItmUpc);
                    text.Add("-SAVED: " + string.Format("{0:$0.00}", -ItmPrice));
                    text.Add(" ");
                }
                else
                {
                    text.Add(ItmName);
                    text.Add(ItmQty);
                    text.Add("");
                    text.Add(string.Format("{0:$0.00}", ItmPrice) + " T");
                    text.Add(ItmUpc);
                    text.Add("-REGULAR PRICE: " + string.Format("{0:$0.00}", ItmBasePrice) + " * " + ItmQty + " = " + string.Format("{0:$0.00}", ItmOriginalPrice));
                    text.Add(" ");
                }
            }

            text.Add("----------------------------------------------------------------");
            text.Add("SUB TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", Convert.ToDouble(SubTotal)));
            text.Add("SALES TAX");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", Convert.ToDouble(Tax)));
            text.Add("GRAND TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", nGrandTotal));
            text.Add("================================================================");
            text.Add("AMOUNT SAVED");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", Discount));
            text.Add("NEW POINTS");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", MemberPoints));
            text.Add("REMAINING POINTS");
            text.Add("$");
            text.Add(string.Format("{0:    0.00}", remainingPoints));
            text.Add("================================================================");
            text.Add("STORE CREDIT TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", nPay));

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

            for (ctr2 = printItmCount + 2; ctr2 <= text.Count - 19; ctr2 += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 2], printFont2).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont2, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont2, Brushes.Black, 215, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont2, Brushes.Black, xPos, yPos + 3);
                ctrTemp += 1;
            }

            for (ctr2 = printItmCount + 8; ctr2 <= text.Count - 16; ctr2 += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 2], printFont4).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont4, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont4, Brushes.Black, 200, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont4, Brushes.Black, xPos, yPos + 3);
                ctrTemp += 1;
            }

            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr2], printFont2, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            for (ctr2 = printItmCount + 12; ctr2 <= text.Count - 7; ctr2 += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 2], printFont2).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont2, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont2, Brushes.Black, 215, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont2, Brushes.Black, xPos, yPos + 3);
                ctrTemp += 1;
            }

            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr2], printFont2, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            for (ctr2 = printItmCount + 22; ctr2 <= text.Count - 1; ctr2 += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 2], printFont2).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont2, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont2, Brushes.Black, 215, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont2, Brushes.Black, xPos, yPos + 3);
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
            text.Add(Convert.ToString(storeCreditID));
            text.Add("STORE CODE");
            text.Add(":");
            text.Add(Convert.ToString(StoreCode));
            text.Add("OLD BALANCE");
            text.Add(":");
            text.Add("$" + Convert.ToString(oldBalance));
            text.Add("NEW BALANCE");
            text.Add(":");
            text.Add("$" + Convert.ToString(balance));
            text.Add("EXPIRATION DATE");
            text.Add(":");
            text.Add(Convert.ToString(expDate));

            for (ctr2 = text.Count - 15; ctr2 <= text.Count - 1; ctr2 += 3)
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
                //MyMessageBox.ShowBox("REMAINING STORECREDIT: " + lblRemainingBalance.Text, "INFORMATION");
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
        /// Calculates the customer points.
        /// </summary>
        public void Calculate_Customer_Points()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Calculate_Member_Points", parentForm.connHQ);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@MemberID", SqlDbType.NVarChar).Value = MemberID;
                cmd.Parameters.Add("@Redeem", SqlDbType.Money).Value = redeem;
                cmd.Parameters.Add("@NewPoints", SqlDbType.Money).Value = MemberPoints;

                parentForm.connHQ.Open();
                cmd.ExecuteNonQuery();
                parentForm.connHQ.Close();
            }
            catch
            {
                MessageBox.Show("CALCULATING MEMBER POINTS ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                parentForm.connHQ.Close();
                return;
            }
        }

        /// <summary>
        /// Calculates the giftcard balance.
        /// </summary>
        public void Calculate_Giftcard_Balance()
        {
            try
            {
                if (parentForm.storeCode == parentForm.giftcardStoreCode)
                {
                    SqlCommand cmd = new SqlCommand("Calculate_Giftcard_Balance", parentForm.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@GiftCardCode", SqlDbType.NVarChar).Value = parentForm.giftcardCodeDesc;
                    cmd.Parameters.Add("@Redeem", SqlDbType.Money).Value = parentForm.giftcardRedeem;
                    //cmd.Parameters.Add("@NewPoints", SqlDbType.Money).Value = MemberPoints;

                    parentForm.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm.conn.Close();

                    Create_Redeem_History(2, Convert.ToInt64(parentForm.giftcardCodeDesc), parentForm.giftcardRedeem);
                }
                else
                {
                    newConn2 = new SqlConnection(parentForm.parentForm.OtherStoreConnectionString(parentForm.giftcardStoreCode));

                    SqlCommand cmd = new SqlCommand("Calculate_Giftcard_Balance", newConn2);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@GiftCardCode", SqlDbType.NVarChar).Value = parentForm.giftcardCodeDesc;
                    cmd.Parameters.Add("@Redeem", SqlDbType.Money).Value = parentForm.giftcardRedeem;
                    //cmd.Parameters.Add("@NewPoints", SqlDbType.Money).Value = MemberPoints;

                    newConn2.Open();
                    cmd.ExecuteNonQuery();
                    newConn2.Close();

                    Create_Redeem_History(2, Convert.ToInt64(parentForm.giftcardCodeDesc), parentForm.giftcardRedeem, parentForm.giftcardStoreCode);
                }
            }
            catch
            {
                MessageBox.Show("CALCULATING GIFTCARD BALANCE ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                parentForm.conn.Close();
                return;
            }
        }

        /// <summary>
        /// Creates the redeem history.
        /// </summary>
        /// <param name="boolNum">The bool number.</param>
        /// <param name="rCode">The r code.</param>
        /// <param name="amt">The amt.</param>
        public void Create_Redeem_History(int boolNum, Int64 rCode, double amt)
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
                cmd.Parameters.Add("@RedeemCode", SqlDbType.BigInt).Value = rCode;
                cmd.Parameters.Add("@RedeemType", SqlDbType.NVarChar).Value = "";
                cmd.Parameters.Add("@Amount", SqlDbType.Money).Value = amt;
                cmd.Parameters.Add("@TransactionDate", SqlDbType.NVarChar).Value = SellDate;
                cmd.Parameters.Add("@TransactionTime", SqlDbType.NVarChar).Value = SellTime;

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

        public void Create_Redeem_History(int boolNum, Int64 rCode, double amt, string desc, string mID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Create_Redeem_History", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@BoolNum", SqlDbType.Int).Value = boolNum;
                cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = parentForm.storeCode;
                cmd.Parameters.Add("@CashierID", SqlDbType.NVarChar).Value = mID;
                cmd.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = parentForm.cashRegisterNum;
                cmd.Parameters.Add("@RefReceiptID", SqlDbType.BigInt).Value = ReceiptID;
                cmd.Parameters.Add("@MemberID", SqlDbType.BigInt).Value = Convert.ToInt64(MemberID);
                cmd.Parameters.Add("@MemberName", SqlDbType.NVarChar).Value = MemberName;
                cmd.Parameters.Add("@RedeemCode", SqlDbType.BigInt).Value = rCode;
                cmd.Parameters.Add("@RedeemType", SqlDbType.NVarChar).Value = desc;
                cmd.Parameters.Add("@Amount", SqlDbType.Money).Value = amt;
                cmd.Parameters.Add("@TransactionDate", SqlDbType.NVarChar).Value = SellDate;
                cmd.Parameters.Add("@TransactionTime", SqlDbType.NVarChar).Value = SellTime;

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
        /// Creates the redeem history.
        /// </summary>
        /// <param name="boolNum">The bool number.</param>
        /// <param name="rCode">The r code.</param>
        /// <param name="amt">The amt.</param>
        /// <param name="sc">The sc.</param>
        public void Create_Redeem_History(int boolNum, Int64 rCode, double amt, string sc)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Create_Redeem_History", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@BoolNum", SqlDbType.Int).Value = boolNum;
                cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = sc;
                cmd.Parameters.Add("@CashierID", SqlDbType.NVarChar).Value = parentForm.employeeID;
                cmd.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = parentForm.cashRegisterNum;
                cmd.Parameters.Add("@RefReceiptID", SqlDbType.BigInt).Value = ReceiptID;
                cmd.Parameters.Add("@MemberID", SqlDbType.BigInt).Value = Convert.ToInt64(MemberID);
                cmd.Parameters.Add("@MemberName", SqlDbType.NVarChar).Value = MemberName;
                cmd.Parameters.Add("@RedeemCode", SqlDbType.BigInt).Value = rCode;
                cmd.Parameters.Add("@RedeemType", SqlDbType.NVarChar).Value = "";
                cmd.Parameters.Add("@Amount", SqlDbType.Money).Value = amt;
                cmd.Parameters.Add("@TransactionDate", SqlDbType.NVarChar).Value = SellDate;
                cmd.Parameters.Add("@TransactionTime", SqlDbType.NVarChar).Value = SellTime;

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
        /// Calculatings the store credit balance.
        /// </summary>
        public void Calculating_StoreCredit_Balance()
        {
            oldBalance = balance;

            if (parentForm.storeCode != cmbStoreCode.Text)
            {
                cmd.Connection = newConn;
                cmd.CommandText = "Calculating_StoreCredit_Balance";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StoreCreditID", SqlDbType.BigInt).Value = storeCreditID;
                cmd.Parameters.Add("@CurrentBalance", SqlDbType.Money).Value = balance;
                cmd.Parameters.Add("@PayAmount", SqlDbType.Money).Value = nGrandTotal;

                newConn.Open();
                cmd.ExecuteNonQuery();
                newConn.Close();
            }
            else
            {
                cmd.Connection = parentForm.conn;
                cmd.CommandText = "Calculating_StoreCredit_Balance";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StoreCreditID", SqlDbType.BigInt).Value = storeCreditID;
                cmd.Parameters.Add("@CurrentBalance", SqlDbType.Money).Value = balance;
                cmd.Parameters.Add("@PayAmount", SqlDbType.Money).Value = nGrandTotal;

                parentForm.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm.conn.Close();
            }
        }

        /// <summary>
        /// Handles the FormClosed event of the StoreCreditOption control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosedEventArgs"/> instance containing the event data.</param>
        private void StoreCreditOption_FormClosed(object sender, FormClosedEventArgs e)
        {
            parentForm.Enabled = true;
            this.Close();
            parentForm.richTxtUpc.Select();
            parentForm.richTxtUpc.Focus();
        }

        /// <summary>
        /// Remainings the points.
        /// </summary>
        /// <param name="s_Code">The s code.</param>
        /// <param name="m_Code">The m code.</param>
        /// <returns>System.Double.</returns>
        private double Remaining_Points(string s_Code, Int64 m_Code)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Get_Remaining_Points", parentForm.connHQ);
                cmd.CommandType = CommandType.StoredProcedure;
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
            catch
            {
                MessageBox.Show("CAN NOT GET THE REMAINING POINTS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                parentForm.connHQ.Close();
                return 0;
            }
        }

        /*private void lblCurrentBalance_TextChanged(object sender, EventArgs e)
        {
            if ((balance - nGrandTotal) < 0)
            {
                MyMessageBox.ShowBox("NOT ENOUGH STORE CREDIT\n"+"TRY TO PAY BY MULTIPLE METHODS", "ERROR");
                richtxtStoreCreditID.SelectAll();
                richtxtStoreCreditID.Focus();
            }
            else
            {
                lblRemainingBalance.Text = string.Format("{0:$0.00}", balance - nGrandTotal);
            }
        }*/
    }
}