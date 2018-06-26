// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 02-05-2018
// ***********************************************************************
// <copyright file="MultiplePayment.cs" company="Beauty4u">
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
    /// Class MultiplePayment.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class MultiplePayment : Form
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
        /// The new connection store credit
        /// </summary>
        public SqlConnection newConn_StoreCredit;

        /// <summary>
        /// The print name
        /// </summary>
        public string printName;
        /// <summary>
        /// The temporary pay
        /// </summary>
        string tempPay = string.Empty;
        /// <summary>
        /// The string length
        /// </summary>
        int strLen = 0;
        /// <summary>
        /// The n dot
        /// </summary>
        int nDot = 0;
        /// <summary>
        /// The i
        /// </summary>
        /// <summary>
        /// The j
        /// </summary>
        /// <summary>
        /// The k
        /// </summary>
        int i, j, k;
        /// <summary>
        /// The ns
        /// </summary>
        int ns = 0;
        /// <summary>
        /// The cashp
        /// </summary>
        /// <summary>
        /// The terminalp
        /// </summary>
        /// <summary>
        /// The cp
        /// </summary>
        /// <summary>
        /// The dp
        /// </summary>
        /// <summary>
        /// The sp
        /// </summary>
        /// <summary>
        /// The tp
        /// </summary>
        int cashp, terminalp, cp, dp, sp, tp;
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
        /// <summary>
        /// The n change
        /// </summary>
        /// <summary>
        /// The n remaing amount
        /// </summary>
        public double nGrandTotal, nPay, nChange, nRemaingAmount;

        //public double cashPay = 0;
        //public double creditPay = 0;
        //public double debitPay = 0;
        //public double tDebitPay = 0;
        //public double tCreditPay = 0;
        /// <summary>
        /// The store credit pay
        /// </summary>
        public double storeCreditPay = 0;
        /// <summary>
        /// The total pay
        /// </summary>
        public double totalPay = 0;

        /*public string creditTroutD1;
        public string creditAuthNum1;
        public string creditRefCardNum1;
        public string creditCardType1;
        public int creditPayBy1;
        public string creditIssueDate1;
        public string creditIssueTime1;
        public bool boolCreditZipCode1 = false;
        public Int32 creditZipCode1;

        public string creditTroutD2;
        public string creditAuthNum2;
        public string creditRefCardNum2;
        public string creditCardType2;
        public int creditPayBy2;
        public string creditIssueDate2;
        public string creditIssueTime2;
        public bool boolCreditZipCode2 = false;
        public Int32 creditZipCode2;*/

        /// <summary>
        /// The t debit issue date1
        /// </summary>
        public string tDebitIssueDate1;
        /// <summary>
        /// The t debit issue time1
        /// </summary>
        public string tDebitIssueTime1;

        /// <summary>
        /// The t debit issue date2
        /// </summary>
        public string tDebitIssueDate2;
        /// <summary>
        /// The t debit issue time2
        /// </summary>
        public string tDebitIssueTime2;

        /// <summary>
        /// The t credit reference card num1
        /// </summary>
        public string tCreditRefCardNum1;
        /// <summary>
        /// The t credit reference card num2
        /// </summary>
        public string tCreditRefCardNum2;
        /// <summary>
        /// The t credit card type1
        /// </summary>
        public string tCreditCardType1;
        /// <summary>
        /// The t credit card type2
        /// </summary>
        public string tCreditCardType2;
        /// <summary>
        /// The t credit issue date1
        /// </summary>
        public string tCreditIssueDate1;
        /// <summary>
        /// The t credit issue date2
        /// </summary>
        public string tCreditIssueDate2;
        /// <summary>
        /// The t credit issue time1
        /// </summary>
        public string tCreditIssueTime1;
        /// <summary>
        /// The t credit issue time2
        /// </summary>
        public string tCreditIssueTime2;
        /// <summary>
        /// The t credit zip code1
        /// </summary>
        public Int32 tCreditZipCode1;
        /// <summary>
        /// The t credit zip code2
        /// </summary>
        public Int32 tCreditZipCode2;
        /// <summary>
        /// The boolt credit zip code1
        /// </summary>
        public bool booltCreditZipCode1 = false;
        /// <summary>
        /// The boolt credit zip code2
        /// </summary>
        public bool booltCreditZipCode2 = false;

        /// <summary>
        /// The r count
        /// </summary>
        public int rCnt = 0;

        /// <summary>
        /// The store code
        /// </summary>
        public string StoreCode;
        /// <summary>
        /// The cashier identifier
        /// </summary>
        public string CashierID;
        /// <summary>
        /// The register number
        /// </summary>
        public string RegisterNum;
        /// <summary>
        /// The member identifier
        /// </summary>
        public string MemberID;
        /// <summary>
        /// The member name
        /// </summary>
        public string MemberName;
        /// <summary>
        /// The pay by
        /// </summary>
        int PayBy = 99;
        /// <summary>
        /// The sell date
        /// </summary>
        public string SellDate;
        /// <summary>
        /// The sell time
        /// </summary>
        public string SellTime;
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
        /// The store credit identifier from MPSC
        /// </summary>
        public Int64 storeCreditIDFromMPSC;
        /// <summary>
        /// The balance from MPSC
        /// </summary>
        public double balanceFromMPSC;
        /// <summary>
        /// The selected store code
        /// </summary>
        public string selectedStoreCode;

        /// <summary>
        /// The store credit sc
        /// </summary>
        string[] storeCreditSC = new string[20];
        /// <summary>
        /// The store credit identifier
        /// </summary>
        Int64[] storeCreditID = new Int64[20];
        /// <summary>
        /// The original amount
        /// </summary>
        double[] originalAmount = new double[20];
        //double[] oldBalance =  new double[20];
        /// <summary>
        /// The amount used
        /// </summary>
        double[] amountUsed = new double[20];
        /// <summary>
        /// The new balance
        /// </summary>
        double[] newBalance = new double[20];
        /// <summary>
        /// The exp date
        /// </summary>
        string[] expDate = new string[20];

        /*public Int64 giftCardCodeFromMPGC1;
        public Int64 giftCardCodeFromMPGC2;
        public double balanceFromMPGC1;
        public double balanceFromMPGC2;
        public string selectedStoreCode3;
        public string selectedStoreCode4;

        public bool giftCardBalance1 = false;
        public double originalAmountGC1 = 0;
        public double oldBalanceGC1 = 0;
        public double newBalanceGC1 = 0;
        public string expDateGC1;
        public bool giftCardBalance2 = false;
        public double originalAmountGC2 = 0;
        public double oldBalanceGC2 = 0;
        public double newBalanceGC2 = 0;
        public string expDateGC2;*/

        //private const string PRINTER_NAME = "EPSON TM-T88III Receipt";
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
        /// The t
        /// </summary>
        Timer t = new Timer();
        /// <summary>
        /// The count
        /// </summary>
        int count;

        /// <summary>
        /// The number ofgc
        /// </summary>
        int numOfgc = 0;

        /// <summary>
        /// The DRV font
        /// </summary>
        Font drvFont = new Font("Arial", 12, FontStyle.Bold);
        /// <summary>
        /// The dt
        /// </summary>
        public DataTable dt = new DataTable();
        /// <summary>
        /// The sum amt
        /// </summary>
        double sumAmt = 0;

        /// <summary>
        /// The cash payment
        /// </summary>
        bool cashPayment = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiplePayment"/> class.
        /// </summary>
        /// <param name="grandTotal">The grand total.</param>
        /// <param name="option">The option.</param>
        /// <param name="points">The points.</param>
        public MultiplePayment(string grandTotal, int option, double points)
        {
            InitializeComponent();
            sGrandTotal = grandTotal;
            lblGrandTotal.Text = sGrandTotal;
            nGrandTotal = Convert.ToDouble(sGrandTotal.Substring(1));
            lblRemainingAmount.Text = sGrandTotal;
            nRemaingAmount = nGrandTotal;
            opt = option;
            redeem = points;
        }

        /// <summary>
        /// Handles the Load event of the MultiplePayment control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MultiplePayment_Load(object sender, EventArgs e)
        {
            printName = parentForm.PRINTER_NAME;

            rCnt = parentForm.dataGridView1.RowCount;

            StoreCode = parentForm.storeCode;
            CashierID = parentForm.employeeID;
            RegisterNum = parentForm.cashRegisterNum;
            MemberID = parentForm.lblMemberCode.Text;
            MemberName = parentForm.lblName.Text;
            SubTotal = parentForm.lblSubTotal.Text.Substring(1);
            Tax = parentForm.lblTax.Text.Substring(1);

            dt.Columns.Add("Method", typeof(string));
            dt.Columns.Add("Payby", typeof(Int16));
            dt.Columns.Add("Amount", typeof(double));
            dt.Columns.Add("StoreCode", typeof(string));
            dt.Columns.Add("StoreCreditID", typeof(Int64));
            dt.Columns.Add("CurrentBalance", typeof(double));
            dt.Columns.Add("AfterBalance", typeof(double));
            dt.Columns.Add("PaymentID", typeof(string));
            dt.Columns.Add("ExternalPaymentID", typeof(string));

            /*DataColumn Col1 = dt.Columns.Add("StoreCode", typeof(string));
            Col1.AllowDBNull = false;
            Col1.Unique = true;
            DataColumn Col2 = dt.Columns.Add("StoreCreditID", typeof(Int64));
            Col2.AllowDBNull = false;
            Col2.Unique = true;*/

            Binding_dataGridView1();
        }

        /// <summary>
        /// Handles the Load event of the CashOption control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CashOption_Load(object sender, EventArgs e)
        {
            richtxtPay.Focus();
            richtxtPay.SelectAll();
        }

        /// <summary>
        /// Handles the Click event of the button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            tempPay = richtxtPay.Text;
            richtxtPay.Text = tempPay + "1";
            strLen = richtxtPay.Text.Trim().Length;
            richtxtPay.Text = richtxtPay.Text.Remove(strLen - 4, 1);
            nDot = strLen - 3;
            richtxtPay.Text = richtxtPay.Text.Insert(nDot, ".");
            string a = richtxtPay.Text.Substring(0, 1);
            if (a == "0")
            {
                richtxtPay.Text = richtxtPay.Text.Remove(0, 1);
            }
            tempPay = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the button2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            tempPay = richtxtPay.Text;
            richtxtPay.Text = tempPay + "2";
            strLen = richtxtPay.Text.Trim().Length;
            richtxtPay.Text = richtxtPay.Text.Remove(strLen - 4, 1);
            nDot = strLen - 3;
            richtxtPay.Text = richtxtPay.Text.Insert(nDot, ".");
            string a = richtxtPay.Text.Substring(0, 1);
            if (a == "0")
            {
                richtxtPay.Text = richtxtPay.Text.Remove(0, 1);
            }
            tempPay = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the button3 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button3_Click(object sender, EventArgs e)
        {
            tempPay = richtxtPay.Text;
            richtxtPay.Text = tempPay + "3";
            strLen = richtxtPay.Text.Trim().Length;
            richtxtPay.Text = richtxtPay.Text.Remove(strLen - 4, 1);
            nDot = strLen - 3;
            richtxtPay.Text = richtxtPay.Text.Insert(nDot, ".");
            string a = richtxtPay.Text.Substring(0, 1);
            if (a == "0")
            {
                richtxtPay.Text = richtxtPay.Text.Remove(0, 1);
            }
            tempPay = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the button4 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button4_Click(object sender, EventArgs e)
        {
            tempPay = richtxtPay.Text;
            richtxtPay.Text = tempPay + "4";
            strLen = richtxtPay.Text.Trim().Length;
            richtxtPay.Text = richtxtPay.Text.Remove(strLen - 4, 1);
            nDot = strLen - 3;
            richtxtPay.Text = richtxtPay.Text.Insert(nDot, ".");
            string a = richtxtPay.Text.Substring(0, 1);
            if (a == "0")
            {
                richtxtPay.Text = richtxtPay.Text.Remove(0, 1);
            }
            tempPay = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the button5 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button5_Click(object sender, EventArgs e)
        {
            tempPay = richtxtPay.Text;
            richtxtPay.Text = tempPay + "5";
            strLen = richtxtPay.Text.Trim().Length;
            richtxtPay.Text = richtxtPay.Text.Remove(strLen - 4, 1);
            nDot = strLen - 3;
            richtxtPay.Text = richtxtPay.Text.Insert(nDot, ".");
            string a = richtxtPay.Text.Substring(0, 1);
            if (a == "0")
            {
                richtxtPay.Text = richtxtPay.Text.Remove(0, 1);
            }
            tempPay = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the button6 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button6_Click(object sender, EventArgs e)
        {
            tempPay = richtxtPay.Text;
            richtxtPay.Text = tempPay + "6";
            strLen = richtxtPay.Text.Trim().Length;
            richtxtPay.Text = richtxtPay.Text.Remove(strLen - 4, 1);
            nDot = strLen - 3;
            richtxtPay.Text = richtxtPay.Text.Insert(nDot, ".");
            string a = richtxtPay.Text.Substring(0, 1);
            if (a == "0")
            {
                richtxtPay.Text = richtxtPay.Text.Remove(0, 1);
            }
            tempPay = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the button7 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button7_Click(object sender, EventArgs e)
        {
            tempPay = richtxtPay.Text;
            richtxtPay.Text = tempPay + "7";
            strLen = richtxtPay.Text.Trim().Length;
            richtxtPay.Text = richtxtPay.Text.Remove(strLen - 4, 1);
            nDot = strLen - 3;
            richtxtPay.Text = richtxtPay.Text.Insert(nDot, ".");
            string a = richtxtPay.Text.Substring(0, 1);
            if (a == "0")
            {
                richtxtPay.Text = richtxtPay.Text.Remove(0, 1);
            }
            tempPay = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the button8 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button8_Click(object sender, EventArgs e)
        {
            tempPay = richtxtPay.Text;
            richtxtPay.Text = tempPay + "8";
            strLen = richtxtPay.Text.Trim().Length;
            richtxtPay.Text = richtxtPay.Text.Remove(strLen - 4, 1);
            nDot = strLen - 3;
            richtxtPay.Text = richtxtPay.Text.Insert(nDot, ".");
            string a = richtxtPay.Text.Substring(0, 1);
            if (a == "0")
            {
                richtxtPay.Text = richtxtPay.Text.Remove(0, 1);
            }
            tempPay = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the button9 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button9_Click(object sender, EventArgs e)
        {
            tempPay = richtxtPay.Text;
            richtxtPay.Text = tempPay + "9";
            strLen = richtxtPay.Text.Trim().Length;
            richtxtPay.Text = richtxtPay.Text.Remove(strLen - 4, 1);
            nDot = strLen - 3;
            richtxtPay.Text = richtxtPay.Text.Insert(nDot, ".");
            string a = richtxtPay.Text.Substring(0, 1);
            if (a == "0")
            {
                richtxtPay.Text = richtxtPay.Text.Remove(0, 1);
            }
            tempPay = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the button0 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button0_Click(object sender, EventArgs e)
        {
            tempPay = richtxtPay.Text;
            richtxtPay.Text = tempPay + "0";
            strLen = richtxtPay.Text.Trim().Length;
            richtxtPay.Text = richtxtPay.Text.Remove(strLen - 4, 1);
            nDot = strLen - 3;
            richtxtPay.Text = richtxtPay.Text.Insert(nDot, ".");
            string a = richtxtPay.Text.Substring(0, 1);
            if (a == "0")
            {
                richtxtPay.Text = richtxtPay.Text.Remove(0, 1);
            }
            tempPay = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the button00 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button00_Click(object sender, EventArgs e)
        {
            if (richtxtPay.Text == "0.00")
            {
            }
            else
            {
                tempPay = richtxtPay.Text;
                richtxtPay.Text = tempPay + "00";
                strLen = richtxtPay.Text.Trim().Length;

                for (i = 0; i < strLen; i++)
                {
                    dotArray[i] = richtxtPay.Text.Trim().Substring(i, 1);
                    if (dotArray[i] == ".")
                    {
                        richtxtPay.Text = richtxtPay.Text.Remove(i, 1);
                        break;
                    }
                }

                for (j = 0; j < i; j++)
                {
                    zeroArray[j] = richtxtPay.Text.Substring(j, 1);
                    if (zeroArray[j] == "0")
                    {
                        richtxtPay.Text = richtxtPay.Text.Remove(j, 1);
                        break;
                    }
                }

                strLen = richtxtPay.Text.Trim().Length;
                richtxtPay.Text = richtxtPay.Text.Insert(strLen - 2, ".");
                tempPay = string.Empty;

                for (k = 0; k < richtxtPay.Text.Length; k++)
                {
                    zeroArray[k] = richtxtPay.Text.Substring(k, 1);
                    if (zeroArray[k] != "0")
                    {
                        break;
                    }
                    else
                    {
                        richtxtPay.Text = richtxtPay.Text.Remove(k, 1);
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCLS control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCLS_Click(object sender, EventArgs e)
        {
            richtxtPay.Text = "0.00";
        }

        /// <summary>
        /// Handles the Click event of the btnCash control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCash_Click(object sender, EventArgs e)
        {
            nPay = 0;

            if (nRemaingAmount <= 0)
            {
                MyMessageBox.ShowBox("THIS AMOUNT IS NOT PAYABLE", "ERROR");
                return;
            }

            if (double.TryParse(richtxtPay.Text, out nPay))
            {
                if (nPay < 0)
                {
                    MyMessageBox.ShowBox("INVALID AMOUNT", "ERROR");
                    return;
                }
                else
                {
                    for (int s = 0; s < dt.Rows.Count; s++)
                    {
                        if (Convert.ToInt16(dt.Rows[s][1]) == 1)
                        {
                            dt.Rows.RemoveAt(s);
                        }
                    }

                    //foreach (DataRow row in dt.Rows)
                    //{
                    //    if (Convert.ToInt16(row[1]) == 1)
                    //        row.Delete();
                    //}

                    dt.Rows.Add("CASH", 1, nPay, StoreCode);
                    Binding_dataGridView1();

                    Check_RemainingAmount();

                    if (nRemaingAmount < 0)
                    {
                        lblTitleRA.Text = "CHANGE";
                        lblRemainingAmount.Text = string.Format("{0:$0.00}", -nRemaingAmount);
                    }
                    else
                    {
                        lblTitleRA.Text = "REMAINING AMOUNT";
                    }
                }
            }
            else
            {
                MyMessageBox.ShowBox("INVALID AMOUNT", "ERROR");
                richtxtPay.SelectAll();
                richtxtPay.Focus();
            }            
        }

        /// <summary>
        /// Handles the Click event of the btnCredit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCredit_Click(object sender, EventArgs e)
        {
            nPay = 0;

            if (nRemaingAmount <= 0)
            {
                MyMessageBox.ShowBox("THIS AMOUNT IS NOT PAYABLE", "ERROR");
                return;
            }

            if (double.TryParse(richtxtPay.Text, out nPay))
            {
                if (nPay < 0)
                {
                    MyMessageBox.ShowBox("INVALID AMOUNT", "ERROR");
                    return;
                }
                else
                {
                    if (nPay > Math.Round(nRemaingAmount, 2, MidpointRounding.AwayFromZero))
                    {
                        MyMessageBox.ShowBox("THE AMOUNT YOU INPUT IS GREATER THAN REMAING AMOUNT", "ERROR");
                        richtxtPay.SelectAll();
                        richtxtPay.Focus();
                        return;
                    }

                    if (nPay == 0)
                        nPay = nRemaingAmount;

                    parentForm.cloverPaymentForm = new CloverPayment("$" + Convert.ToString(nPay), 0, 0, 1);
                    parentForm.cloverPaymentForm.parentForm = this.parentForm;
                    parentForm.cloverPaymentForm.multiplePaymentForm = this;
                    parentForm.cloverPaymentForm.ShowDialog();
                }
            }
            else
            {
                MyMessageBox.ShowBox("INVALID AMOUNT", "ERROR");
                //MessageBox.Show("Invalid amount", "Error");
                richtxtPay.SelectAll();
                richtxtPay.Focus();
            }     
        }

        /// <summary>
        /// Handles the Click event of the btnTerminal control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnTerminal_Click(object sender, EventArgs e)
        {
            nPay = 0;

            if (nRemaingAmount <= 0)
            {
                MyMessageBox.ShowBox("THIS AMOUNT IS NOT PAYABLE", "ERROR");
                return;
            }

            if (double.TryParse(richtxtPay.Text, out nPay))
            {
                if (nPay < 0)
                {
                    MyMessageBox.ShowBox("INVALID AMOUNT", "ERROR");
                    return;
                }
                else
                {
                    if (nPay > Math.Round(nRemaingAmount, 2, MidpointRounding.AwayFromZero))
                    {
                        MyMessageBox.ShowBox("THE AMOUNT YOU INPUT IS GREATER THAN REMAING AMOUNT", "ERROR");
                        richtxtPay.SelectAll();
                        richtxtPay.Focus();
                        return;
                    }

                    if (nPay == 0)
                        nPay = nRemaingAmount;

                    MPTerminal MPTerminalForm = new MPTerminal(nPay);
                    MPTerminalForm.parentForm = this;
                    MPTerminalForm.ShowDialog();
                }
            }
            else
            {
                MyMessageBox.ShowBox("INVALID AMOUNT", "ERROR");
                //MessageBox.Show("Invalid amount", "Error");
                richtxtPay.SelectAll();
                richtxtPay.Focus();
            } 
        }

        /// <summary>
        /// Handles the Click event of the btnStoreCredit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnStoreCredit_Click(object sender, EventArgs e)
        {
            nPay = 0;

            if (nRemaingAmount <= 0)
            {
                MyMessageBox.ShowBox("THIS AMOUNT IS NOT PAYABLE", "ERROR");
                return;
            }

            if (double.TryParse(richtxtPay.Text, out nPay))
            {
                if (nPay < 0)
                {
                    MyMessageBox.ShowBox("INVALID AMOUNT", "ERROR");
                    return;
                }
                else
                {
                    if (nPay > Math.Round(nRemaingAmount, 2, MidpointRounding.AwayFromZero))
                    {
                        MyMessageBox.ShowBox("THE AMOUNT YOU INPUT IS GREATER THAN REMAING AMOUNT", "ERROR");
                        richtxtPay.SelectAll();
                        richtxtPay.Focus();
                        return;
                    }

                    if (nPay == 0)
                        nPay = nRemaingAmount;

                    MPStoreCredit MPStoreCreditForm = new MPStoreCredit(nPay);
                    MPStoreCreditForm.parentForm = this;
                    MPStoreCreditForm.ShowDialog();
                }
            }
            else
            {
                MyMessageBox.ShowBox("INVALID AMOUNT", "ERROR");
                //MessageBox.Show("Invalid amount", "Error");
                richtxtPay.SelectAll();
                richtxtPay.Focus();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            btnOK.BackColor = Color.Gray;
            btnOK.Enabled = false;

            DateTime currentTime = DateTime.Now;
            //SellDate = string.Format("{0:d}", currentTime);
            SellDate = string.Format("{0:MM/dd/yyyy}", currentTime);
            SellTime = string.Format("{0:T}", currentTime);
            //totalPay = cashPay + tDebitPay1 + tDebitPay2 + tCreditPay1 + tCreditPay2 + creditPay1 + creditPay2 + storeCreditPay1 + storeCreditPay2 + giftCardPay1 + giftCardPay2;
            totalPay = 0;
            for (i = 0; i < dataGridView1.RowCount; i++)
            {
                totalPay = totalPay + Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
            }
            nChange = nRemaingAmount;

            if (nChange < 0)
                nChange = -nChange;

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
            cmd_ReceiptHeader.Parameters.Add("@Pay", SqlDbType.Money).Value = totalPay;
            cmd_ReceiptHeader.Parameters.Add("@Change", SqlDbType.Money).Value = nChange;
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

            Calculating_StoreCredit_Balance();

            ns = 0;
            for (i = 0; i < dataGridView1.RowCount; i++)
            {
                if (Convert.ToInt16(dataGridView1.Rows[i].Cells[1].Value) == 1)
                {
                    cashPayment = true;
                }
                else if (Convert.ToInt16(dataGridView1.Rows[i].Cells[1].Value) == 3)
                {
                    try
                    {
                        SqlCommand cmd_RefCreditTransactionUpdating = new SqlCommand("UpdatingReceiptID_ToRefCreditTransaction", parentForm.conn);
                        cmd_RefCreditTransactionUpdating.CommandType = CommandType.StoredProcedure;
                        cmd_RefCreditTransactionUpdating.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
                        cmd_RefCreditTransactionUpdating.Parameters.Add("@RefReceiptID", SqlDbType.BigInt).Value = 99;
                        cmd_RefCreditTransactionUpdating.Parameters.Add("@Amount", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                        cmd_RefCreditTransactionUpdating.Parameters.Add("@IssueDate", SqlDbType.NVarChar).Value = SellDate;

                        parentForm.conn.Open();
                        cmd_RefCreditTransactionUpdating.ExecuteNonQuery();
                        parentForm.conn.Close();
                    }
                    catch
                    {
                        parentForm.conn.Close();
                        MyMessageBox.ShowBox("FAILED UPDATING TERMINAL TRANSACTION\n" + "(RECEIPT ID)", "ERROR");
                    }
                }
                else if (Convert.ToInt16(dataGridView1.Rows[i].Cells[1].Value) >= 4 & Convert.ToInt16(dataGridView1.Rows[i].Cells[1].Value) <= 8)
                {
                    //ReceiptID Updating to the Clover Transaction
                    SqlCommand cmd_CloverTransactionUpdating = new SqlCommand("UpdatingReceiptID_ToCloverTransaction", parentForm.conn);
                    cmd_CloverTransactionUpdating.CommandType = CommandType.StoredProcedure;
                    cmd_CloverTransactionUpdating.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
                    cmd_CloverTransactionUpdating.Parameters.Add("@PaymentID", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[7].Value);
                    cmd_CloverTransactionUpdating.Parameters.Add("@ExternalPaymentID", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[8].Value);

                    parentForm.conn.Open();
                    cmd_CloverTransactionUpdating.ExecuteNonQuery();
                    parentForm.conn.Close();
                }
                else if (Convert.ToInt16(dataGridView1.Rows[i].Cells[1].Value) == 88)
                {
                    if (parentForm.storeCode == Convert.ToString(dataGridView1.Rows[i].Cells[3].Value))
                    {
                        Create_Redeem_History(1, Convert.ToInt64(dataGridView1.Rows[i].Cells[4].Value), Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value));
                    }
                    else
                    {
                        Create_Redeem_History(1, Convert.ToInt64(dataGridView1.Rows[i].Cells[4].Value), Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value), Convert.ToString(dataGridView1.Rows[i].Cells[3].Value));
                    }

                    if (parentForm.storeCode == Convert.ToString(dataGridView1.Rows[i].Cells[3].Value))
                    {
                        SqlCommand cmd_StoreCreditInfo = new SqlCommand("Get_StoreCredit_Info", parentForm.conn);
                        cmd_StoreCreditInfo.CommandType = CommandType.StoredProcedure;
                        cmd_StoreCreditInfo.Parameters.Add("@StoreCreditID", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.Rows[i].Cells[4].Value);
                        SqlParameter Amount_Param = cmd_StoreCreditInfo.Parameters.Add("@Amount", SqlDbType.Money);
                        SqlParameter Balance_Param = cmd_StoreCreditInfo.Parameters.Add("@Balance", SqlDbType.Money);
                        SqlParameter ExpDate_Param = cmd_StoreCreditInfo.Parameters.Add("@ExpDate", SqlDbType.NVarChar, 20);
                        Amount_Param.Direction = ParameterDirection.Output;
                        Balance_Param.Direction = ParameterDirection.Output;
                        ExpDate_Param.Direction = ParameterDirection.Output;

                        parentForm.conn.Open();
                        cmd_StoreCreditInfo.ExecuteNonQuery();
                        parentForm.conn.Close();

                        storeCreditSC[ns] = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value);
                        storeCreditID[ns] = Convert.ToInt64(dataGridView1.Rows[i].Cells[4].Value);
                        amountUsed[ns] = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                        originalAmount[ns] = Convert.ToDouble(cmd_StoreCreditInfo.Parameters["@Amount"].Value);
                        newBalance[ns] = Convert.ToDouble(cmd_StoreCreditInfo.Parameters["@Balance"].Value);
                        expDate[ns] = cmd_StoreCreditInfo.Parameters["@ExpDate"].Value.ToString();

                        ns = ns + 1;
                    }
                    else
                    {
                        newConn_StoreCredit = new SqlConnection(parentForm.parentForm.OtherStoreConnectionString(Convert.ToString(dataGridView1.Rows[i].Cells[3].Value)));

                        SqlCommand cmd_StoreCreditInfo = new SqlCommand("Get_StoreCredit_Info", newConn_StoreCredit);
                        cmd_StoreCreditInfo.CommandType = CommandType.StoredProcedure;
                        cmd_StoreCreditInfo.Parameters.Add("@StoreCreditID", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.Rows[i].Cells[4].Value);
                        SqlParameter Amount_Param = cmd_StoreCreditInfo.Parameters.Add("@Amount", SqlDbType.Money);
                        SqlParameter Balance_Param = cmd_StoreCreditInfo.Parameters.Add("@Balance", SqlDbType.Money);
                        SqlParameter ExpDate_Param = cmd_StoreCreditInfo.Parameters.Add("@ExpDate", SqlDbType.NVarChar, 20);
                        Amount_Param.Direction = ParameterDirection.Output;
                        Balance_Param.Direction = ParameterDirection.Output;
                        ExpDate_Param.Direction = ParameterDirection.Output;

                        newConn_StoreCredit.Open();
                        cmd_StoreCreditInfo.ExecuteNonQuery();
                        newConn_StoreCredit.Close();

                        storeCreditSC[ns] = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value);
                        storeCreditID[ns] = Convert.ToInt64(dataGridView1.Rows[i].Cells[4].Value);
                        amountUsed[ns] = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                        originalAmount[ns] = Convert.ToDouble(cmd_StoreCreditInfo.Parameters["@Amount"].Value);
                        newBalance[ns] = Convert.ToDouble(cmd_StoreCreditInfo.Parameters["@Balance"].Value);
                        expDate[ns] = cmd_StoreCreditInfo.Parameters["@ExpDate"].Value.ToString();

                        ns = ns + 1;
                    }
                }

                SqlCommand cmd_ReceiptMultiPay = new SqlCommand("Create_ReceiptMultiPay_Information", parentForm.conn);
                cmd_ReceiptMultiPay.CommandType = CommandType.StoredProcedure;
                cmd_ReceiptMultiPay.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = ReceiptID;
                cmd_ReceiptMultiPay.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value);
                cmd_ReceiptMultiPay.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = RegisterNum;
                cmd_ReceiptMultiPay.Parameters.Add("@PayBy", SqlDbType.Int).Value = Convert.ToInt16(dataGridView1.Rows[i].Cells[1].Value);
                cmd_ReceiptMultiPay.Parameters.Add("@PayAmount", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                cmd_ReceiptMultiPay.Parameters.Add("@SellDate", SqlDbType.NVarChar).Value = SellDate;
                cmd_ReceiptMultiPay.Parameters.Add("@SellTime", SqlDbType.NVarChar).Value = SellTime;

                parentForm.conn.Open();
                cmd_ReceiptMultiPay.ExecuteNonQuery();
                parentForm.conn.Close();
            }

            /*if (boolCreditZipCode1 == true)
            {
                Recording_Customer_ZipCode(ReceiptID, creditZipCode1, SellDate);
            }

            if (boolCreditZipCode2 == true)
            {
                Recording_Customer_ZipCode(ReceiptID, creditZipCode2, SellDate);
            }

            if (booltCreditZipCode1 == true)
            {
                Recording_Customer_ZipCode(ReceiptID, tCreditZipCode1, SellDate);
            }

            if (booltCreditZipCode2 == true)
            {
                Recording_Customer_ZipCode(ReceiptID, tCreditZipCode2, SellDate);
            }*/

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
                            if (cashPayment == true)
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

            if (nChange > 0)
            {
                parentForm.LineDisply("CHANGE", lblRemainingAmount.Text);
            }
            else
            {
                parentForm.LineDisply(parentForm.openingMSG1, parentForm.openingMSG2);
            }

            btnOK.Visible = false;
            btnCancel.Visible = false;
            btnClose.Visible = true;
            lblTimer.Visible = true;

            count = 30;
            t.Interval = 1000;
            t.Tick += t_Tick;
            t.Start();
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                for (int s = 0; s < dataGridView1.RowCount; s++)
                {
                    if (Convert.ToInt16(dataGridView1.Rows[s].Cells[1].Value) >= 3 & Convert.ToInt16(dataGridView1.Rows[s].Cells[1].Value) <= 8)
                    {
                        DialogResult MyDialogResult;
                        MyDialogResult = MessageBox.Show(this, "THIS TRANSACTION IS ALREADY PAID BY CREDIT OR DEBIT ONCE\n\n" + "DO YOU WANT TO CANCEL THIS TRANSACTION?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (MyDialogResult == DialogResult.Yes)
                        {
                            parentForm.Enabled = true;
                            this.Close();
                            parentForm.LineDisply(parentForm.openingMSG1, parentForm.openingMSG2);
                            parentForm.richTxtUpc.Select();
                            parentForm.richTxtUpc.Focus();

                            return;
                        }
                        else
                        {
                            return;
                        }
                    }
                }

                parentForm.Enabled = true;
                this.Close();
                parentForm.LineDisply(parentForm.openingMSG1, parentForm.openingMSG2);
                parentForm.richTxtUpc.Select();
                parentForm.richTxtUpc.Focus();
            }
            else
            {
                parentForm.Enabled = true;
                this.Close();
                parentForm.LineDisply(parentForm.openingMSG1, parentForm.openingMSG2);
                parentForm.richTxtUpc.Select();
                parentForm.richTxtUpc.Focus();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            t.Stop();

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

        /// <summary>
        /// Checks the remaining amount.
        /// </summary>
        public void Check_RemainingAmount()
        {
            sumAmt = 0;
            
            for (int s = 0; s < dataGridView1.RowCount; s++)
            {
                sumAmt = sumAmt + Convert.ToDouble(dataGridView1.Rows[s].Cells[2].Value);        
            }

            nRemaingAmount = nGrandTotal - sumAmt;
            lblRemainingAmount.Text = string.Format("{0:$0.00}", nRemaingAmount);
            richtxtPay.Text = "0.00";

            if (Math.Round(nRemaingAmount, 2, MidpointRounding.AwayFromZero) <= 0)
            {
                btnOK.Enabled = true;
                parentForm.LineDisply("REMAINING AMOUNT", "$0.00");
            }
            else
            {
                btnOK.Enabled = false;
                parentForm.LineDisply("REMAINING AMOUNT", lblRemainingAmount.Text);
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
        /// <param name="ID">The identifier.</param>
        /// <param name="amt">The amt.</param>
        public void Create_Redeem_History(int boolNum, Int64 ID, double amt)
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

                if (boolNum == 0)
                {
                    cmd.Parameters.Add("@RedeemCode", SqlDbType.BigInt).Value = ID;
                    cmd.Parameters.Add("@RedeemType", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@Amount", SqlDbType.Money).Value = amt;
                }
                else if (boolNum == 1)
                {
                    cmd.Parameters.Add("@RedeemCode", SqlDbType.BigInt).Value = ID;
                    cmd.Parameters.Add("@RedeemType", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@Amount", SqlDbType.Money).Value = amt;
                }
                else if (boolNum == 2)
                {
                    cmd.Parameters.Add("@RedeemCode", SqlDbType.BigInt).Value = ID;
                    cmd.Parameters.Add("@RedeemType", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@Amount", SqlDbType.Money).Value = amt;
                }
                else if (boolNum == 3)
                {
                    cmd.Parameters.Add("@RedeemCode", SqlDbType.BigInt).Value = ID;
                    cmd.Parameters.Add("@RedeemType", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@Amount", SqlDbType.Money).Value = amt;
                }

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
        /// <param name="ID">The identifier.</param>
        /// <param name="amt">The amt.</param>
        /// <param name="sc">The sc.</param>
        public void Create_Redeem_History(int boolNum, Int64 ID, double amt, string sc)
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

                if (boolNum == 0)
                {
                    cmd.Parameters.Add("@RedeemCode", SqlDbType.BigInt).Value = ID;
                    cmd.Parameters.Add("@RedeemType", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@Amount", SqlDbType.Money).Value = amt;
                }
                else if (boolNum == 1)
                {
                    cmd.Parameters.Add("@RedeemCode", SqlDbType.BigInt).Value = ID;
                    cmd.Parameters.Add("@RedeemType", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@Amount", SqlDbType.Money).Value = amt;
                }
                else if (boolNum == 2)
                {
                    cmd.Parameters.Add("@RedeemCode", SqlDbType.BigInt).Value = ID;
                    cmd.Parameters.Add("@RedeemType", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@Amount", SqlDbType.Money).Value = amt;
                }
                else if (boolNum == 3)
                {
                    cmd.Parameters.Add("@RedeemCode", SqlDbType.BigInt).Value = ID;
                    cmd.Parameters.Add("@RedeemType", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@Amount", SqlDbType.Money).Value = amt;
                }

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
            text.Add("MULTIPLE");
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
            text.Add(string.Format("{0:    0.00}", Convert.ToDouble(SubTotal)));
            text.Add("SALES TAX");
            text.Add("$");
            text.Add(string.Format("{0:    0.00}", Convert.ToDouble(Tax)));
            text.Add("GRAND TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:    0.00}", nGrandTotal));
            text.Add("================================================================");
            text.Add("AMOUNT SAVED");
            text.Add("$");
            text.Add(string.Format("{0:    0.00}", Discount));
            text.Add("NEW POINTS");
            text.Add("$");
            text.Add(string.Format("{0:    0.00}", MemberPoints));
            text.Add("REMAINING POINTS");
            text.Add("$");
            text.Add(string.Format("{0:    0.00}", remainingPoints));
            text.Add("================================================================");
            //text.Add("CASH");
            //text.Add("$");
            //text.Add(string.Format("{0:    0.00}", cashPay));

            cashp = 0; terminalp = 0; cp = 0; dp = 0; sp = 0; tp = 0;

            for (int a = 0; a < dataGridView1.RowCount; a++)
            {
                if (Convert.ToInt16(dataGridView1.Rows[a].Cells[1].Value) == 1)
                {
                    text.Add("CASH");
                    text.Add("$");
                    text.Add(string.Format("{0:    0.00}", Convert.ToDouble(dataGridView1.Rows[a].Cells[2].Value)));
                    cashp = cashp + 1;
                }
                else if (Convert.ToInt16(dataGridView1.Rows[a].Cells[1].Value) == 3)
                {
                    text.Add("CREDIT (TERMINAL)");
                    text.Add("$");
                    text.Add(string.Format("{0:    0.00}", Convert.ToDouble(dataGridView1.Rows[a].Cells[2].Value)));
                    terminalp = terminalp + 1;
                }
                else if (Convert.ToInt16(dataGridView1.Rows[a].Cells[1].Value) == 4)
                {
                    text.Add("CREDIT (VISA)");
                    text.Add("$");
                    text.Add(string.Format("{0:    0.00}", Convert.ToDouble(dataGridView1.Rows[a].Cells[2].Value)));
                    cp = cp + 1;
                }
                else if (Convert.ToInt16(dataGridView1.Rows[a].Cells[1].Value) == 6)
                {
                    text.Add("CREDIT (MASTER)");
                    text.Add("$");
                    text.Add(string.Format("{0:    0.00}", Convert.ToDouble(dataGridView1.Rows[a].Cells[2].Value)));
                    cp = cp + 1;
                }
                else if (Convert.ToInt16(dataGridView1.Rows[a].Cells[1].Value) == 7)
                {
                    text.Add("CREDIT (AMEX)");
                    text.Add("$");
                    text.Add(string.Format("{0:    0.00}", Convert.ToDouble(dataGridView1.Rows[a].Cells[2].Value)));
                    cp = cp + 1;
                }
                else if (Convert.ToInt16(dataGridView1.Rows[a].Cells[1].Value) == 8)
                {
                    text.Add("CREDIT (DISCOVER)");
                    text.Add("$");
                    text.Add(string.Format("{0:    0.00}", Convert.ToDouble(dataGridView1.Rows[a].Cells[2].Value)));
                    cp = cp + 1;
                }
                else if (Convert.ToInt16(dataGridView1.Rows[a].Cells[1].Value) == 5)
                {
                    text.Add("DEBIT");
                    text.Add("$");
                    text.Add(string.Format("{0:    0.00}", Convert.ToDouble(dataGridView1.Rows[a].Cells[2].Value)));
                    dp = dp + 1;
                }
                else if (Convert.ToInt16(dataGridView1.Rows[a].Cells[1].Value) == 88)
                {
                    text.Add("STORE CREDIT");
                    text.Add("$");
                    text.Add(string.Format("{0:    0.00}", Convert.ToDouble(dataGridView1.Rows[a].Cells[2].Value)));
                    sp = sp + 1;
                }
            }

            tp = cashp + terminalp + cp + dp + sp;

            /*text.Add("CREDIT TOTAL");
            text.Add("$");
            //text.Add(string.Format("{0:    0.00}", creditPay1 + creditPay2));
            text.Add("TERMINAL DEBIT TOTAL");
            text.Add("$");
            //text.Add(string.Format("{0:    0.00}", tDebitPay1 + tDebitPay2));
            text.Add("TERMINAL CREDIT TOTAL");
            text.Add("$");
            //text.Add(string.Format("{0:    0.00}", tCreditPay1 + tCreditPay2));
            text.Add("GIFT CARD TOTAL");
            text.Add("$");
            //text.Add(string.Format("{0:    0.00}", giftCardPay1 + giftCardPay2));
            text.Add("STORE CREDIT TOTAL");
            text.Add("$");
            //text.Add(string.Format("{0:    0.00}", storeCreditPay1 + storeCreditPay2));*/

            text.Add("================================================================");
            text.Add("TOTAL PAYMENT");
            text.Add("$");
            text.Add(string.Format("{0:    0.00}", totalPay));
            text.Add("CASH CHANGE");
            text.Add("$");
            text.Add(string.Format("{0:    0.00}", nChange));

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

            for (ctr2 = printItmCount + 2; ctr2 <= printItmCount + 7; ctr2 += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 2], printFont2).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont2, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont2, Brushes.Black, 215, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont2, Brushes.Black, xPos, yPos + 3);
                ctrTemp += 1;
            }

            for (ctr2 = printItmCount + 8; ctr2 <= printItmCount + 10; ctr2 += 3)
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

            for (ctr2 = printItmCount + 12; ctr2 <= printItmCount + 20; ctr2 += 3)
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

            for (ctr2 = printItmCount + 22; ctr2 <= printItmCount + 21 + (tp * 3); ctr2 += 3)
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

            for (ctr2 = printItmCount + 23 + (3 * tp); ctr2 <= text.Count - 1; ctr2 += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 2], printFont2).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont2, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont2, Brushes.Black, 215, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont2, Brushes.Black, xPos, yPos + 3);
                ctrTemp += 1;
            }

            if (ns > 0)
            {

                text.Add(" ");
                text.Add(" ");
                text.Add(" ");
                text.Add("STORE CREDIT");
                text.Add(" ");

                for (ctr2 = text.Count - 5; ctr2 <= text.Count - 1; ctr2++)
                {
                    yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                    e.Graphics.DrawString((String)text[ctr2], printBoldFont, Brushes.Black, 75, yPos);
                    ctrTemp += 1;
                }

                for (int a = 0; a < ns; a++)
                {
                    text.Add(" ");
                    text.Add(" ");
                    text.Add(" ");
                    text.Add("STORE CREDIT ID");
                    text.Add(":");
                    text.Add(Convert.ToString(storeCreditID[a]));
                    text.Add("STORE CODE");
                    text.Add(":");
                    text.Add(storeCreditSC[a]);
                    text.Add("AMOUNT USED");
                    text.Add(":");
                    text.Add(string.Format("{0:c}", amountUsed[a]));
                    text.Add("NEW BALANCE");
                    text.Add(":");
                    text.Add(string.Format("{0:c}", newBalance[a]));
                    text.Add("EXPIRATION DATE");
                    text.Add(":");
                    text.Add(expDate[a]);
                }

                for (ctr2 = text.Count - (18 * ns); ctr2 <= text.Count - 1; ctr2 += 3)
                {
                    yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                    //xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 2], printFont2).Width;
                    e.Graphics.DrawString((String)text[ctr2], printFont2, Brushes.Black, 50, yPos + 3);
                    e.Graphics.DrawString((String)text[ctr2 + 1], printFont2, Brushes.Black, 170, yPos + 3);
                    e.Graphics.DrawString((String)text[ctr2 + 2], printFont2, Brushes.Black, 175, yPos + 3);
                    ctrTemp += 1;
                }
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
        /// Handles the Click event of the richtxtPay control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void richtxtPay_Click(object sender, EventArgs e)
        {
            richtxtPay.SelectAll();
            richtxtPay.Focus();
        }

        /// <summary>
        /// Handles the Tick event of the t control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void t_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = "Wait for " + count + " seconds...";
            count--;

            if (count == -1)
            {
                t.Stop();

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

        /// <summary>
        /// Calculatings the store credit balance.
        /// </summary>
        public void Calculating_StoreCredit_Balance()
        {
            for (int s = 0; s < dataGridView1.RowCount; s++)
            {
                if (Convert.ToInt16(dataGridView1.Rows[s].Cells[1].Value) == 88)
                {
                    selectedStoreCode = dataGridView1.Rows[s].Cells[3].Value.ToString();
                    storeCreditIDFromMPSC = Convert.ToInt64(dataGridView1.Rows[s].Cells[4].Value);
                    balanceFromMPSC = Convert.ToDouble(dataGridView1.Rows[s].Cells[5].Value);
                    storeCreditPay = Convert.ToDouble(dataGridView1.Rows[s].Cells[2].Value);

                    if (StoreCode != selectedStoreCode)
                    {
                        newConn_StoreCredit = new SqlConnection(parentForm.parentForm.OtherStoreConnectionString(selectedStoreCode));

                        SqlCommand cmd = new SqlCommand("Calculating_StoreCredit_Balance", newConn_StoreCredit);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@StoreCreditID", SqlDbType.BigInt).Value = storeCreditIDFromMPSC;
                        cmd.Parameters.Add("@CurrentBalance", SqlDbType.Money).Value = balanceFromMPSC;
                        cmd.Parameters.Add("@PayAmount", SqlDbType.Money).Value = storeCreditPay;

                        newConn_StoreCredit.Open();
                        cmd.ExecuteNonQuery();
                        newConn_StoreCredit.Close();
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("Calculating_StoreCredit_Balance", parentForm.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@StoreCreditID", SqlDbType.BigInt).Value = storeCreditIDFromMPSC;
                        cmd.Parameters.Add("@CurrentBalance", SqlDbType.Money).Value = balanceFromMPSC;
                        cmd.Parameters.Add("@PayAmount", SqlDbType.Money).Value = storeCreditPay;

                        parentForm.conn.Open();
                        cmd.ExecuteNonQuery();
                        parentForm.conn.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Handles the FormClosed event of the MultiplePayment control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosedEventArgs"/> instance containing the event data.</param>
        private void MultiplePayment_FormClosed(object sender, FormClosedEventArgs e)
        {
            t.Stop();

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
        /// Handles the EnabledChanged event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOK_EnabledChanged(object sender, EventArgs e)
        {
            if (btnOK.Enabled == true)
            {
                btnCash.Enabled = false;
                btnCredit.Enabled = false;
                btnTerminal.Enabled = false;
                btnStoreCredit.Enabled = false;
            }
            else
            {
                btnCash.Enabled = true;
                btnCredit.Enabled = true;
                btnTerminal.Enabled = true;
                btnStoreCredit.Enabled = true;
            }
        }

        /// <summary>
        /// Recordings the customer zip code.
        /// </summary>
        /// <param name="rptID">The RPT identifier.</param>
        /// <param name="zc">The zc.</param>
        /// <param name="pDate">The p date.</param>
        private void Recording_Customer_ZipCode(Int64 rptID, Int32 zc, string pDate)
        {
            SqlCommand cmd = new SqlCommand("Recording_Customer_ZipCode", parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = rptID;
            cmd.Parameters.Add("@ZipCode", SqlDbType.Int).Value = zc;
            cmd.Parameters.Add("@PurchasingDate", SqlDbType.NVarChar).Value = pDate;

            parentForm.conn.Open();
            cmd.ExecuteNonQuery();
            parentForm.conn.Close();
        }

        /// <summary>
        /// Bindings the data grid view1.
        /// </summary>
        public void Binding_dataGridView1()
        {
            dataGridView1.DataSource = null;

            dataGridView1.DataSource = dt;
            dataGridView1.RowTemplate.Height = 50;
            dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
            dataGridView1.Columns[0].HeaderText = "METHOD";
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[1].HeaderText = "PAY BY";
            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].HeaderText = "AMOUNT";
            dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[2].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].HeaderText = "STORE CODE";
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[4].HeaderText = "STORE CREDIT ID";
            dataGridView1.Columns[4].Width = 120;
            dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[5].HeaderText = "CURRENT BALANCE";
            dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].Width = 200;
            dataGridView1.Columns[5].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[6].HeaderText = "AFTER BALANCE";
            dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[6].Width = 200;
            dataGridView1.Columns[6].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[7].HeaderText = "PAYMENT ID";
            dataGridView1.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[7].Width = 150;
            dataGridView1.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[8].HeaderText = "EXTERNAL PAYMENT ID";
            dataGridView1.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[8].Width = 150;
            dataGridView1.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Sort(this.dataGridView1.Columns["Payby"], ListSortDirection.Ascending);
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

            if (parentForm.parentForm.employeeID != "ADMIN")
            {
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
            }

            dataGridView1.ClearSelection();
        }
    }
}