// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 02-09-2017
// ***********************************************************************
// <copyright file="CreditOption.cs" company="Beauty4u">
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

/// <summary>
/// The Register namespace.
/// </summary>
namespace Register
{
    /// <summary>
    /// Class CreditOption.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class CreditOption : Form
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
        /// The user
        /// </summary>
        string user;

        /// <summary>
        /// The i
        /// </summary>
        int i = 0;
        /// <summary>
        /// The j
        /// </summary>
        int j = 0;
        /// <summary>
        /// The string len1
        /// </summary>
        int strLen1 = 0;
        /// <summary>
        /// The string len2
        /// </summary>
        int strLen2 = 0;
        /// <summary>
        /// The card information length
        /// </summary>
        int cardInfoLen = 0;
        /// <summary>
        /// The number qm
        /// </summary>
        int numQM = 0;
        /// <summary>
        /// The s
        /// </summary>
        string s;
        /// <summary>
        /// The card information
        /// </summary>
        string cardInfo;
        /// <summary>
        /// The month
        /// </summary>
        string month;
        /// <summary>
        /// The year
        /// </summary>
        string year;
        /// <summary>
        /// The card number
        /// </summary>
        string cardNum;
        /// <summary>
        /// The reference card number
        /// </summary>
        string RefCardNum;
        /// <summary>
        /// The n reference card number
        /// </summary>
        int nRefCardNum;
        /// <summary>
        /// The track
        /// </summary>
        string track;
        /// <summary>
        /// The card type
        /// </summary>
        string cardType;
        /// <summary>
        /// The trout d
        /// </summary>
        string troutD;
        /// <summary>
        /// The authentication number
        /// </summary>
        string authNum;
        //string cardCompany;

        /// <summary>
        /// The temporary pay
        /// </summary>
        string tempPay = string.Empty;
        //int i;
        /// <summary>
        /// The opt
        /// </summary>
        int opt = 0;
        /// <summary>
        /// The redeem
        /// </summary>
        double redeem = 0;
        /// <summary>
        /// The dot array
        /// </summary>
        string[] dotArray = new string[20];
        /// <summary>
        /// The zero array
        /// </summary>
        string[] zeroArray = new string[20];
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
        int PayBy;
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
        /// The bool zip code
        /// </summary>
        bool boolZipCode = false;
        /// <summary>
        /// The zip code
        /// </summary>
        Int32 zipCode;

        //private const string PRINTER_NAME = "EPSON TM-T88III Receipt";
        /// <summary>
        /// The pd print
        /// </summary>
        PrintDocument pdPrint;
        /// <summary>
        /// The pd print2
        /// </summary>
        PrintDocument pdPrint2;
        /// <summary>
        /// The pd print3
        /// </summary>
        PrintDocument pdPrint3;
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
        /// The chip card type
        /// </summary>
        string chipCardType;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreditOption"/> class.
        /// </summary>
        /// <param name="grandTotal">The grand total.</param>
        /// <param name="option">The option.</param>
        /// <param name="points">The points.</param>
        public CreditOption(string grandTotal, int option, double points)
        {
            InitializeComponent();
            lblGrandTotal.Text = grandTotal;
            lblPay.Text = grandTotal;
            nGrandTotal = Convert.ToDouble(grandTotal.Substring(1));
            opt = option;
            redeem = points;
        }

        /// <summary>
        /// Handles the Load event of the CreditOption control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CreditOption_Load(object sender, EventArgs e)
        {
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

            txtCardNum.Select();
            txtCardNum.Focus();
        }

        /// <summary>
        /// Handles the Click event of the btnCheckOut control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            /*if (chipCardType == "2")
            {
                MyMessageBox.ShowBox("USE TERMINAL FOR SMART CARD", "INFORMATION");
                return;
            }

            if (txtZipCode.Text != "")
            {
                if (Int32.TryParse(txtZipCode.Text, out zipCode))
                {
                    boolZipCode = true;
                }
                else
                {
                    MyMessageBox.ShowBox("INVALID ZIPCODE", "ERROR");
                    txtZipCode.SelectAll();
                    txtZipCode.Focus();
                    return;
                }
            }

            RefCardNum = cardNum.Substring(cardNum.Length - 4, 4);

            if (int.TryParse(txtInputCardNum.Text.Trim().ToString(), out nRefCardNum))
            {
                if (Convert.ToInt16(RefCardNum) == nRefCardNum)
                {
                }
                else
                {
                    MyMessageBox.ShowBox("LAST 4 DIGIT NOT MATCH", "ERROR");
                    txtInputCardNum.SelectAll();
                    txtInputCardNum.Focus();
                    return;
                }
            }
            else
            {
                MyMessageBox.ShowBox("INVALID LAST 4 DIGIT", "ERROR");
                txtInputCardNum.Select(15, txtInputCardNum.Text.Length - 15);
                txtInputCardNum.Focus();
                return;
            }

            btnCheckOut.BackColor = Color.Gray;
            btnCheckOut.Enabled = false;
            Charge creditPayment = new Charge();
            //creditPayment.Path = "s:\\";
            creditPayment.Path = parentForm.PcChargePath;
            
            if (creditPayment.PccSysExists() == false)
            {
                creditPayment.Action = 1;
                creditPayment.Amount = lblPay.Text.Substring(1);
                creditPayment.Manual = 1;
                creditPayment.Card = cardNum;
                creditPayment.Track = track;
                creditPayment.member = lblName.Text.Trim().ToString();
                creditPayment.ExpDate = month + year;
                //creditPayment.MerchantNumber = "518993290104108";
                //creditPayment.Processor = "FDC";
                creditPayment.MerchantNumber = parentForm.merchantNum;
                creditPayment.Processor = parentForm.pcr;
                creditPayment.User = user;
                creditPayment.TimeOut = 60;

                if (parentForm.storeCode == "CV")
                {
                    //creditPayment.CashierName = parentForm.PcChargeLoginID;
                    //creditPayment.CashierPassword = parentForm.PcChargePassword;
                }
                else
                {
                    creditPayment.CashierName = parentForm.PcChargeLoginID;
                    creditPayment.CashierPassword = parentForm.PcChargePassword;
                }

                PSCharge.FileType filetype = (PSCharge.FileType)3;
                creditPayment.Send(ref filetype);

                int error = creditPayment.GetErrorCode();
                if (error != 0)
                {
                    //MessageBox.Show("Error Description: " + creditPayment.GetErrorDesc() + "\r\n" + "Error Ccode: " + creditPayment.GetErrorCode(), "Error");
                    MyMessageBox.ShowBox("ERROR DESCRIPTION: " + creditPayment.GetErrorDesc() + "\r\n" + "ERROR CODE: " + creditPayment.GetErrorCode(), "ERROR");
                    creditPayment.Clear();
                    return;
                }
                else
                {
                    string result = String.Empty;
                    result = creditPayment.GetResult().ToUpper();
                    cardType = creditPayment.GetCreditCardType(cardNum);
                    PayBy = ReturnCreditCardType(cardType.ToUpper());

                    if (result == "CAPTURED" || result == "APPROVED" || result == "PROCESSED")
                    {
                        troutD = creditPayment.GetTroutD();
                        authNum = creditPayment.GetAuth();
                        lblAuthNum.Text = authNum;
                        //MyMessageBox.ShowBox("Transaction is " + result + "\r\n" + "TroutD: " + troutD, "INFORMATION - APPROVED");
                        //MessageBox.Show("Transaction is " + result + "\r\n" + "TroutD: " + troutD, "APPROVED");

                        nPay = Convert.ToDouble(lblPay.Text.Trim().ToString().Substring(1));
                        DateTime currentTime = DateTime.Now;
                        rCnt = parentForm.dataGridView1.RowCount;

                        if (nPay > 0)
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

                                if (ItmGroup1 == "10" | ItmGroup1 == "11")
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

                            SqlCommand cmd_RefCreditTransaction = new SqlCommand("Create_RefCreditTransaction", parentForm.conn);
                            cmd_RefCreditTransaction.CommandType = CommandType.StoredProcedure;
                            cmd_RefCreditTransaction.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
                            cmd_RefCreditTransaction.Parameters.Add("@TroutD", SqlDbType.NVarChar).Value = troutD;
                            cmd_RefCreditTransaction.Parameters.Add("@AuthNum", SqlDbType.NVarChar).Value = authNum;
                            cmd_RefCreditTransaction.Parameters.Add("@RefCardNum", SqlDbType.NVarChar).Value = RefCardNum;
                            cmd_RefCreditTransaction.Parameters.Add("@CardType", SqlDbType.NVarChar).Value = cardType.ToUpper();
                            cmd_RefCreditTransaction.Parameters.Add("@Amount", SqlDbType.Money).Value = nPay;
                            cmd_RefCreditTransaction.Parameters.Add("@IssueDate", SqlDbType.NVarChar).Value = SellDate;
                            cmd_RefCreditTransaction.Parameters.Add("@IssueTime", SqlDbType.NVarChar).Value = SellTime;

                            parentForm.conn.Open();
                            cmd_RefCreditTransaction.ExecuteNonQuery();
                            parentForm.conn.Close();

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
                            }
                            else
                            {
                                Calculate_Customer_Points();
                                parentForm.Customer_Transaction_Update(1, parentForm.storeCode, Convert.ToInt64(MemberID), nGrandTotal, SellDate);

                                if (redeem > 0)
                                    Create_Redeem_History(0, 10, redeem);

                                remainingPoints = Remaining_Points(parentForm.storeCode, Convert.ToInt64(MemberID));
                            }

                            Int32 retVal;
                            String errMsg;
                            apiAlias.StatusMonitoring pMonitorCB = new apiAlias.StatusMonitoring(StatusMonitoring);

                            pdPrint = new PrintDocument();
                            pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage);
                            pdPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;

                            pdPrint2 = new PrintDocument();
                            pdPrint2.PrintPage += new PrintPageEventHandler(pdPrint2_PrintPage);
                            pdPrint2.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;

                            try
                            {
                                // Open Printer Monitor of Status API.
                                mpHandle = apiAlias.BiOpenMonPrinter(apiAlias.TYPE_PRINTER, pdPrint.PrinterSettings.PrinterName);
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
                                        // Start printing.
                                        //pdPrint.Print();
                                        //pdPrint2.Print();

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
                                            OpenDrawer(pdPrint2.PrinterSettings.PrinterName);
                                            pdPrint.Print();
                                            pdPrint2.Print();
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

                            parentForm.lblQty.Text = "1";
                            parentForm.lblTotalQty.Text = "0";
                            parentForm.lblSubTotal.Text = "$0.00";
                            parentForm.lblTax.Text = "$0.00";
                            parentForm.lblGrandTotal.Text = "$0.00";
                            parentForm.dt.Clear();
                            parentForm.dataGridView1.DataSource = null;
                            parentForm.radioBtnDefault.Checked = true;
                            parentForm.points = 0;
                            parentForm.SetFocusOnInputBox();

                            parentForm.giftcardRedeem = 0;
                            parentForm.giftcardCodeDesc = string.Empty;
                            parentForm.giftcardStoreCode = string.Empty;

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
                            MyMessageBox.ShowBox("INPUT CORRECT AMOUNT", "ERROR");
                            //MessageBox.Show("Input correct amount", "Error");
                            return;
                        }

                        creditPayment.Clear();
                        txtCardNum.Enabled = false;
                        cmbCardType.Enabled = false;
                        btnClose.Visible = true;
                        btnCheckOut.Visible = false;
                        btnCancel.Visible = false;
                    }
                    //else if (result == "NOT CAPTURED" || result == "NOT APPROVED" || result == "CANCELED")
                    else if (result == "NOT APPROVED" || result == "CANCELED")
                    {
                        string errorMessage = "SORRY! NOT APPROVED! \n" + "PLEASE TRY ANOTHER CREDIT CARD";
                        MyMessageBox.ShowBox(errorMessage, "ERROR");
                        //MessageBox.Show(errorMessage, "Error");
                        return;
                    }
                    else
                    {
                        string response = creditPayment.GetResult().ToUpper();
                        authNum = creditPayment.GetAuth();
                        MyMessageBox.ShowBox(response + " (" + authNum + ")", "ERROR");
                        //MessageBox.Show(response + " (" + authNum + ")", "ERROR");
                        return;
                    }
                }
            }
            else
            {
                MyMessageBox.ShowBox("PC CHARGE NOT RUNNING", "ERROR");
                //MessageBox.Show("PCCharge not running", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }*/
        }

        /// <summary>
        /// Handles the TextChanged event of the txtCardNum control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtCardNum_TextChanged(object sender, EventArgs e)
        {
            /*try
            {
                if (txtCardNum.Text.Length <= 0)
                    return;

                cardInfo = txtCardNum.Text;
                cardInfoLen = cardInfo.Length;
                cardCompany = cmbCardType.Text;

                for (i = 0; i < cardInfoLen; i++)
                {
                    s = cardInfo.Substring(i, 1);

                    if (s == "?")
                    {
                        numQM += 1;
                    }
                }

                if (cardCompany == "AMEX")
                {
                    if (numQM == 2)
                    {
                        for (i = 0; i < cardInfo.Length; i++)
                        {
                            s = cardInfo.Substring(i, 1);

                            if (s == "^")
                            {
                                strLen1 = i + 1;
                                break;
                            }
                        }

                        for (j = strLen1; j < cardInfo.Length; j++)
                        {
                            s = cardInfo.Substring(j, 1);

                            if (s == "^")
                            {
                                strLen2 = j + 1;
                                break;
                            }
                        }

                        for (i = 0; i < cardInfo.Length; i++)
                        {
                            s = cardInfo.Substring(i, 1);

                            if (s == ";")
                            {
                                int semiColon = i + 1;
                                track = cardInfo.Substring(semiColon, (cardInfo.Length - semiColon - 1));
                                break;
                            }
                        }

                        lblName.Text = cardInfo.Substring(strLen1, strLen2 - strLen1 - 1);
                        cardNum = cardInfo.Substring(2, 15);
                        RefCardNum = cardInfo.Substring(12, 5);
                        txtCardNum.Enabled = false;
                        lblCardNum.Visible = true;
                        lblCardNum.Text = cardNum;
                        month = cardInfo.Substring(strLen2 + 2, 2);
                        year = cardInfo.Substring(strLen2, 2);
                        lblExpDate.Text = month + "/20" + year;
                    }
                    else
                    {
                        numQM = 0;
                        txtCardNum.Enabled = true;
                        lblCardNum.Visible = false;
                    }
                }
                else
                {
                    if (numQM == 2)
                    {
                        for (i = 0; i < cardInfo.Length; i++)
                        {
                            s = cardInfo.Substring(i, 1);

                            if (s == "^")
                            {
                                strLen1 = i + 1;
                                break;
                            }
                        }

                        for (j = strLen1; j < cardInfo.Length; j++)
                        {
                            s = cardInfo.Substring(j, 1);

                            if (s == "^")
                            {
                                strLen2 = j + 1;
                                break;
                            }
                        }

                        for (i = 0; i < cardInfo.Length; i++)
                        {
                            s = cardInfo.Substring(i, 1);

                            if (s == ";")
                            {
                                int semiColon = i + 1;
                                track = cardInfo.Substring(semiColon, (cardInfo.Length - semiColon - 1));
                                break;
                            }
                        }

                        lblName.Text = cardInfo.Substring(strLen1, strLen2 - strLen1 - 1);
                        cardNum = cardInfo.Substring(2, 16);
                        RefCardNum = cardInfo.Substring(14, 4);
                        txtCardNum.Enabled = false;
                        lblCardNum.Visible = true;
                        lblCardNum.Text = cardNum;
                        month = cardInfo.Substring(strLen2 + 2, 2);
                        year = cardInfo.Substring(strLen2, 2);
                        lblExpDate.Text = month + "/20" + year;
                    }
                    else
                    {
                        numQM = 0;
                        txtCardNum.Enabled = true;
                        lblCardNum.Visible = false;
                    }
                }
            }
            catch
            {
                txtCardNum.Enabled = false;
                txtCardNum.Visible = false;
                MyMessageBox.ShowBox("SWIPE ERROR! THIS WINDOW WILL BE CLOSED... \n" + "PLEASE TRY AGAIN", "ERROR");
                parentForm.Enabled = true;
                this.Close();
            }*/

            if (txtCardNum.Text.Length <= 0)
                return;

            cardInfo = txtCardNum.Text;
            cardInfoLen = cardInfo.Length;

            for (i = 0; i < cardInfoLen; i++)
            {
                s = cardInfo.Substring(i, 1);

                if (s == "?")
                {
                    numQM += 1;
                }
            }

            if (numQM >= 2)
            {
                btnGetCardInfo_Click(null, null);
            }
            else
            {
                numQM = 0;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            parentForm.Enabled = true;
            this.Close();
            parentForm.richTxtUpc.Select();
            parentForm.richTxtUpc.Focus();
        }

        /// <summary>
        /// Handles the 1 event of the btnCancel_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            parentForm.Enabled = true;
            this.Close();
            parentForm.LineDisply(parentForm.openingMSG1, parentForm.openingMSG2);
            parentForm.richTxtUpc.Select();
            parentForm.richTxtUpc.Focus();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbCardType control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmbCardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCardNum.Enabled = true;
            txtCardNum.SelectAll();
            txtCardNum.Focus();
        }

        /// <summary>
        /// Handles the TextChanged event of the cmbCardType control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmbCardType_TextChanged(object sender, EventArgs e)
        {
            if (cmbCardType.Text == "")
            {
                txtCardNum.Enabled = false;
                btnCheckOut.Enabled = false;
            }
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
                case "MC":
                    cardTypeNum = 6;
                    break;
                case "AMEX":
                    cardTypeNum = 7;
                    break;
                case "DISC":
                    cardTypeNum = 8;
                    break;
                default :
                    cardTypeNum = 3;
                    break;
            }

            return cardTypeNum;
        }

        /// <summary>
        /// Handles the PrintPage event of the pdPrint control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PrintPageEventArgs"/> instance containing the event data.</param>
        private void pdPrint_PrintPage(object sender, PrintPageEventArgs e)
        {
            ArrayList text = new ArrayList();
            Single yPos, xPos;
            int ctr, ctrTemp;

            printFont = new Font("Arial", 10);
            printFont2 = new Font("Arial", 9);
            printFont3 = new Font("Arial", 7, FontStyle.Bold);
            printFont4 = new Font("Arial", 10, FontStyle.Underline);
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

            text.Add("DATE & TIME");
            text.Add(":");
            text.Add(Convert.ToString(SellDate) + " " + Convert.ToString(SellTime));
            text.Add("AMOUNT");
            text.Add(":");
            text.Add(lblPay.Text);
            text.Add("PAYMENT METHOD");
            text.Add(":");
            text.Add(cardType.ToUpper() + " (SWIPED)");

            if (cardType.ToUpper() == "AMEX")
            {
                text.Add("CARD NUMBER");
                text.Add(":");
                text.Add("XXXX-XXXXXX-X" + RefCardNum);
            }
            else
            {
                text.Add("CARD NUMBER");
                text.Add(":");
                text.Add("XXXX-XXXX-XXXX-" + RefCardNum);
            }

            //text.Add("CARD NUMBER");
            //text.Add(":");
            //text.Add(txtInputCardNum.Text);

            text.Add("AUTH #");
            text.Add(":");
            text.Add(authNum);
            text.Add("RECEIPT ID");
            text.Add(":");
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
            for (ctr = 8; ctr <= 37; ctr += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr + 1], printFont2, Brushes.Black, 120, yPos + 3);
                e.Graphics.DrawString((String)text[ctr + 2], printFont2, Brushes.Black, 130, yPos + 3);
                ctrTemp += 1;
            }

            text.Add(" ");
            text.Add(" ");
            text.Add(" ");
            text.Add("Sign :");
            text.Add(" ______________________________");
            text.Add(lblName.Text.ToUpper());

            ctr = text.Count - 6;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;
            ctr = text.Count - 5;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;
            ctr = text.Count - 4;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;
            ctr = text.Count - 3;
            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 0, yPos + 3);
            ctr = text.Count - 2;
            xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr], printFont4).Width;
            e.Graphics.DrawString((String)text[ctr], printFont4, Brushes.Black, xPos, yPos + 3);
            ctrTemp += 1;
            ctr = text.Count - 1;
            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont3, Brushes.Black, 40, yPos + 3);

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

            for (ctr = text.Count - 21; ctr <= text.Count - 1; ctr++)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 0, yPos + 3);
                ctrTemp += 1;
            }

            e.HasMorePages = false;
        }

        /// <summary>
        /// Handles the PrintPage event of the pdPrint2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PrintPageEventArgs"/> instance containing the event data.</param>
        private void pdPrint2_PrintPage(object sender, PrintPageEventArgs e)
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
            text.Add(cardType.ToUpper());
            text.Add("DATE & TIME");
            text.Add(":");
            text.Add(Convert.ToString(SellDate) + " " + Convert.ToString(SellTime));
            text.Add("RECEIPT ID");
            text.Add(":");
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
            text.Add("       DESCRIPTION                           QTY    PRICE    ");
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
            text.Add("CREDIT CARD TOTAL");
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
                e.Graphics.DrawString((String)text[ctr + 2], printFont2, Brushes.Black, 130, yPos + 3);
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
        /// Handles the PrintPage event of the pdPrint3 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PrintPageEventArgs"/> instance containing the event data.</param>
        private void pdPrint3_PrintPage(object sender, PrintPageEventArgs e)
        {
            ArrayList text = new ArrayList();
            Single yPos, xPos;
            int ctr, ctrTemp;

            printFont = new Font("Arial", 10);
            printFont2 = new Font("Arial", 9);
            printFont3 = new Font("Arial", 7, FontStyle.Bold);
            printFont4 = new Font("Arial", 10, FontStyle.Underline);
            printBoldFont = new Font("Arial", 14, FontStyle.Bold);

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
            text.Add(" ");
            text.Add(" ");
            text.Add(" ");
            text.Add(" ");

            text.Add("DATE & TIME");
            text.Add(":");
            text.Add("7/25/2009 7:13:02 PM");
            text.Add("AMOUNT");
            text.Add(":");
            text.Add("$74.59");
            text.Add("PAYMENT METHOD");
            text.Add(":");
            text.Add("VISA (SWIPED)");
            text.Add("CARD NUMBER");
            text.Add(":");
            text.Add("XXXX-XXXX-XXXX-1005");
            text.Add("AUTH #");
            text.Add(":");
            text.Add("003136");
            text.Add("RECEIPT ID");
            text.Add(":");
            text.Add("BCAT-372031");
            text.Add("CASHIER ID");
            text.Add(":");
            text.Add("SHERRYL");
            text.Add("REGISTER NO");
            text.Add(":");
            text.Add("REG02");
            text.Add("MEMBER ID");
            text.Add(":");
            text.Add("101");
            text.Add("MEMBER NAME");
            text.Add(":");
            text.Add("WALK INS");

            ctr = 0;
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
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 77, yPos + 10);

            ctrTemp = ctr;
            for (ctr = 8; ctr <= 37; ctr += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr + 1], printFont2, Brushes.Black, 120, yPos + 3);
                e.Graphics.DrawString((String)text[ctr + 2], printFont2, Brushes.Black, 130, yPos + 3);
                ctrTemp += 1;
            }

            text.Add(" ");
            text.Add(" ");
            text.Add(" ");
            text.Add("Sign :");
            text.Add(" ______________________________");
            text.Add(lblName.Text.ToUpper());

            ctr = text.Count - 6;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;
            ctr = text.Count - 5;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;
            ctr = text.Count - 4;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;
            ctr = text.Count - 3;
            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 0, yPos + 3);
            ctr = text.Count - 2;
            xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr], printFont4).Width;
            e.Graphics.DrawString((String)text[ctr], printFont4, Brushes.Black, xPos, yPos + 3);
            ctrTemp += 1;
            ctr = text.Count - 1;
            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont3, Brushes.Black, 40, yPos + 3);

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

            for (ctr = text.Count - 21; ctr <= text.Count - 1; ctr++)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 0, yPos + 3);
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
                //MyMessageBox.ShowBox("COMPLETE PRINTING", "INFORMATION");
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
        /// Handles the Click event of the button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            Int32 retVal;
            String errMsg;
            apiAlias.StatusMonitoring pMonitorCB = new apiAlias.StatusMonitoring(StatusMonitoring);

            pdPrint3 = new PrintDocument();
            pdPrint3.PrintPage += new PrintPageEventHandler(pdPrint3_PrintPage);
            pdPrint3.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;

            try
            {
                // Open Printer Monitor of Status API.
                mpHandle = apiAlias.BiOpenMonPrinter(apiAlias.TYPE_PRINTER, pdPrint3.PrinterSettings.PrinterName);
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
                        // Start printing.
                        pdPrint3.Print();

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
                        //else
                            // Call the function to open cash drawer.
                            //OpenDrawer(pdPrint3.PrinterSettings.PrinterName);
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                MessageBox.Show("Failed to open StatusAPI.", "", MessageBoxButtons.OK);
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
        }

        /// <summary>
        /// Handles the VisibleChanged event of the lblCardNum control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lblCardNum_VisibleChanged(object sender, EventArgs e)
        {
            if (lblCardNum.Visible == true)
            {
                btnCheckOut.Enabled = true;
            }
            else
            {
                btnCheckOut.Enabled = false;
            }
        }

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
                    newConn = new SqlConnection(parentForm.parentForm.OtherStoreConnectionString(parentForm.giftcardStoreCode));

                    SqlCommand cmd = new SqlCommand("Calculate_Giftcard_Balance", newConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@GiftCardCode", SqlDbType.NVarChar).Value = parentForm.giftcardCodeDesc;
                    cmd.Parameters.Add("@Redeem", SqlDbType.Money).Value = parentForm.giftcardRedeem;
                    //cmd.Parameters.Add("@NewPoints", SqlDbType.Money).Value = MemberPoints;

                    newConn.Open();
                    cmd.ExecuteNonQuery();
                    newConn.Close();

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
        /// Handles the Click event of the btnClearCardNum control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnClearCardNum_Click(object sender, EventArgs e)
        {
            txtCardNum.Visible = true;
            lblCardNum.Visible = false;
            lblName.Text = "";
            lblExpDate.Text = "";
            txtCardNum.Clear();
            lblCardNumConfirm.Text = "";
            txtInputCardNum.Clear();
            txtCardNum.Select();
            txtCardNum.Focus();
        }

        /// <summary>
        /// Handles the FormClosed event of the CreditOption control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosedEventArgs"/> instance containing the event data.</param>
        private void CreditOption_FormClosed(object sender, FormClosedEventArgs e)
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

        /// <summary>
        /// Handles the Click event of the btnGetCardInfo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnGetCardInfo_Click(object sender, EventArgs e)
        {
            for (i = 0; i < cardInfo.Length; i++)
            {
                s = cardInfo.Substring(i, 1);

                if (s == "^")
                {
                    strLen1 = i + 1;
                    break;
                }
            }

            for (j = strLen1; j < cardInfo.Length; j++)
            {
                s = cardInfo.Substring(j, 1);

                if (s == "^")
                {
                    strLen2 = j + 1;
                    break;
                }
            }

            for (i = 0; i < cardInfo.Length; i++)
            {
                s = cardInfo.Substring(i, 1);

                if (s == ";")
                {
                    int semiColon = i + 1;
                    track = cardInfo.Substring(semiColon, (cardInfo.Length - semiColon - 1));
                    break;
                }
            }

            lblName.Text = cardInfo.Substring(strLen1, strLen2 - strLen1 - 1);
            cardNum = cardInfo.Substring(2, strLen1 - 3);
            if (cardNum.Length == 16)
            {
                //RefCardNum = cardInfo.Substring(14, 4);
                lblCardNumConfirm.Text = "XXXXXXXXXXXX";
                //txtInputCardNum.Clear();
                //txtInputCardNum.Select();
                //txtInputCardNum.Focus();
            }
            else
            {
                //RefCardNum = cardInfo.Substring(12, 5);
                lblCardNumConfirm.Text = "XXXXXXXXXXX";
                //txtInputCardNum.Clear();
                //txtInputCardNum.Select();
                //txtInputCardNum.Focus();

            }
            //RefCardNum = cardInfo.Substring(12, 5);
            lblCardNum.Text = cardNum;
            month = cardInfo.Substring(strLen2 + 2, 2);
            year = cardInfo.Substring(strLen2, 2);
            chipCardType = cardInfo.Substring(strLen2 + 4, 1);
            lblExpDate.Text = month + "/20" + year;

            //txtCardNum.Enabled = false;
            txtCardNum.Visible = false;
            lblCardNum.Visible = true;

            cmbCardType.Select();
            cmbCardType.Focus();
        }

        /// <summary>
        /// Recordings the customer zip code.
        /// </summary>
        /// <param name="rptID">The RPT identifier.</param>
        /// <param name="pDate">The p date.</param>
        private void Recording_Customer_ZipCode(Int64 rptID, string pDate)
        {
            SqlCommand cmd = new SqlCommand("Recording_Customer_ZipCode", parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = rptID;
            cmd.Parameters.Add("@ZipCode", SqlDbType.Int).Value = zipCode;
            cmd.Parameters.Add("@PurchasingDate", SqlDbType.NVarChar).Value = pDate;

            parentForm.conn.Open();
            cmd.ExecuteNonQuery();
            parentForm.conn.Close();
        }
    }
}