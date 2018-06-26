// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 02-06-2018
// ***********************************************************************
// <copyright file="MainForm.cs" company="Beauty4u">
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
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Threading;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using com.clover.remotepay.transport.remote;
using com.clover.remotepay.transport;
using com.clover.remotepay.sdk;
using com.clover.remote.order;
using com.clover.sdk.v3.payments;
using Microsoft.Win32;

/// <summary>
/// The Register namespace.
/// </summary>
namespace Register
{
    /// <summary>
    /// Class MainForm.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    /// <seealso cref="com.clover.remotepay.sdk.ICloverConnectorListener" />
    public partial class MainForm : Form, ICloverConnectorListener
    {
        /// <summary>
        /// The parent form
        /// </summary>
        public LoginRegister parentForm;
        /// <summary>
        /// The clover payment form
        /// </summary>
        public CloverPayment cloverPaymentForm;
        /// <summary>
        /// The multiple payment form
        /// </summary>
        public MultiplePayment multiplePaymentForm;
        /// <summary>
        /// The return form
        /// </summary>
        public Return returnForm;

        /// <summary>
        /// The DRV font
        /// </summary>
        public Font drvFont = new Font("Arial", 12, FontStyle.Bold);
        /// <summary>
        /// The nfi
        /// </summary>
        NumberFormatInfo nfi = new NumberFormatInfo();
        /// <summary>
        /// The printer name
        /// </summary>
        public string PRINTER_NAME;
        /// <summary>
        /// The store tax rate
        /// </summary>
        public double storeTaxRate;
        /// <summary>
        /// The VFD command type
        /// </summary>
        public string VFDCmdType;
        /// <summary>
        /// The VFD port
        /// </summary>
        public string VFDPort;
        /// <summary>
        /// The VFD baud rate
        /// </summary>
        public int VFDBaudRate = 9600;

        //Variables from Login
        /// <summary>
        /// The store name
        /// </summary>
        public string storeName = string.Empty;
        /// <summary>
        /// The store code
        /// </summary>
        public string storeCode = string.Empty;
        /// <summary>
        /// The cash register number
        /// </summary>
        public string cashRegisterNum = string.Empty;
        /// <summary>
        /// The employee identifier
        /// </summary>
        public string employeeID = string.Empty;
        /// <summary>
        /// The employee level
        /// </summary>
        public int employeeLevel = 0;

        //Variables for Store Information on Receipt
        /// <summary>
        /// The store street
        /// </summary>
        public string storeStreet = string.Empty;
        /// <summary>
        /// The store city state
        /// </summary>
        public string storeCityState = string.Empty;
        /// <summary>
        /// The store telephone
        /// </summary>
        public string storeTelephone = string.Empty;
        /// <summary>
        /// The ss
        /// </summary>
        /// <summary>
        /// The SCS
        /// </summary>
        /// <summary>
        /// The st
        /// </summary>
        public int ss = 0, scs = 0, st = 0;

        //Variables for Credit Card Processing (PC-Charge)
        /// <summary>
        /// The pc charge path
        /// </summary>
        public string PcChargePath;
        /// <summary>
        /// The merchant number
        /// </summary>
        public string merchantNum;
        /// <summary>
        /// The PCR
        /// </summary>
        public string pcr;
        /// <summary>
        /// The user1
        /// </summary>
        /// <summary>
        /// The user2
        /// </summary>
        /// <summary>
        /// The user3
        /// </summary>
        /// <summary>
        /// The user4
        /// </summary>
        public string user1, user2, user3, user4;
        /// <summary>
        /// The pc charge login identifier
        /// </summary>
        public string PcChargeLoginID;
        /// <summary>
        /// The pc charge password
        /// </summary>
        public string PcChargePassword;

        //Variables for Data Binding
        /// <summary>
        /// The connection
        /// </summary>
        public SqlConnection conn;
        /// <summary>
        /// The connection hq
        /// </summary>
        public SqlConnection connHQ;
        /// <summary>
        /// The dt
        /// </summary>
        public DataTable dt = new DataTable();
        /// <summary>
        /// The hold table
        /// </summary>
        public DataTable holdTable = new DataTable();
        /// <summary>
        /// The command
        /// </summary>
        public SqlCommand cmd = new SqlCommand();
        /// <summary>
        /// The adapter
        /// </summary>
        SqlDataAdapter adapter;
        /// <summary>
        /// The count upc
        /// </summary>
        public SqlCommand countUpc = new SqlCommand();
        /// <summary>
        /// The command coupon
        /// </summary>
        SqlCommand cmd_coupon = new SqlCommand();

        /// <summary>
        /// The temporary upc
        /// </summary>
        string tempUpc = string.Empty;
        /// <summary>
        /// The itm upc
        /// </summary>
        public string ItmUpc = string.Empty;
        /// <summary>
        /// The itm brand
        /// </summary>
        public string ItmBrand = string.Empty;
        /// <summary>
        /// The itm name
        /// </summary>
        public string ItmName = string.Empty;
        /// <summary>
        /// The itm size
        /// </summary>
        public string ItmSize = string.Empty;
        /// <summary>
        /// The itm color
        /// </summary>
        public string ItmColor = string.Empty;
        /// <summary>
        /// The itm price
        /// </summary>
        public string ItmPrice = string.Empty;

        //System Barcode
        /// <summary>
        /// The coupon barcode
        /// </summary>
        //public string couponBarcode = "000000999112"; -- Old coupon redeem
        public string couponBarcode = "000000999109";
        /// <summary>
        /// The point redeem barcode
        /// </summary>
        public string pointRedeemBarcode = "000000999110";
        /// <summary>
        /// The gift card barcode
        /// </summary>
        public string giftCardBarcode = "000000999111";

        //btnInput_Click
        //int upcLen = 0;
        /// <summary>
        /// The number type upc
        /// </summary>
        Int64 numTypeUpc;
        /// <summary>
        /// The input upc
        /// </summary>
        string inputUpc;
        /// <summary>
        /// The upc check
        /// </summary>
        bool upcCheck;
        /// <summary>
        /// The points
        /// </summary>
        public double points = 0;
        /// <summary>
        /// The input qty
        /// </summary>
        int inputQty;
        /// <summary>
        /// The input discount price
        /// </summary>
        double inputDiscountPrice;
        /// <summary>
        /// The input unit price
        /// </summary>
        double inputUnitPrice;
        /// <summary>
        /// The input origin discount
        /// </summary>
        double inputOriginDiscount;

        //Hold/Show Hold
        /// <summary>
        /// The temporary points
        /// </summary>
        public double tempPoints = 0;
        //double tempPointRedeemed = 0;
        /// <summary>
        /// The temporary member identifier
        /// </summary>
        string tempMemberID = string.Empty;

        //btnQtyP_Click, btnQtyM_Click
        /// <summary>
        /// The n
        /// </summary>
        int n;
        /// <summary>
        /// The qty unit price
        /// </summary>
        double QtyUnitPrice;
        /// <summary>
        /// The qty discount price
        /// </summary>
        double QtyDiscountPrice;

        //lblType_TextChanged
        //int CTQty;
        //double CTUnitPrice;
        //double CTOriginDiscount;
        //double CTDiscountPrice;

        //txtMemberID_TextChanged
        /// <summary>
        /// The member identifier
        /// </summary>
        string memberID = string.Empty;
        /// <summary>
        /// The CTM point
        /// </summary>
        public double CtmPoint = 0;
        /// <summary>
        /// The member code check
        /// </summary>
        Int64 memberCodeCheck;

        //lblTitleGrandTotal_Click
        /// <summary>
        /// The s grand total
        /// </summary>
        string sGrandTotal;

        //CountUpc
        /// <summary>
        /// The count
        /// </summary>
        string cnt;
        /// <summary>
        /// The c
        /// </summary>
        int c;

        //BindDataGridView
        /// <summary>
        /// The dt row count p
        /// </summary>
        /// <summary>
        /// The dt row count n
        /// </summary>
        int dtRowCount_P, dtRowCount_N;

        //Check_Promotion_Active
        /// <summary>
        /// The today
        /// </summary>
        string today = DateTime.Today.ToString("d");
        /// <summary>
        /// The check number
        /// </summary>
        int checkNum;

        //radioBtnDefault_CheckedChanged
        /// <summary>
        /// The bd qty
        /// </summary>
        int BDQty;
        /// <summary>
        /// The bd unit price
        /// </summary>
        double BDUnitPrice;
        /// <summary>
        /// The bd price
        /// </summary>
        double BDPrice;
        /// <summary>
        /// The bd tax
        /// </summary>
        double BDTax;
        /// <summary>
        /// The bd rest discount
        /// </summary>
        bool BDRestDiscount = true;
        /// <summary>
        /// The bd error MSG
        /// </summary>
        bool BDErrorMsg = true;

        //Calculation
        /// <summary>
        /// The cal total qty
        /// </summary>
        public int calTotalQty;
        /// <summary>
        /// The cal sub total
        /// </summary>
        public double calSubTotal;
        /// <summary>
        /// The cal taxable sub total
        /// </summary>
        public double calTaxableSubTotal;
        /// <summary>
        /// The cal tax
        /// </summary>
        public double calTax;
        /// <summary>
        /// The cal grand total
        /// </summary>
        public double calGrandTotal;

        //Price_Comparing
        /// <summary>
        /// The command price comparing
        /// </summary>
        public SqlCommand cmd_PriceComparing;
        /// <summary>
        /// The promotion active
        /// </summary>
        public bool promotionActive = false;
        /// <summary>
        /// The pc sale price
        /// </summary>
        double PCSalePrice;
        /// <summary>
        /// The pc stylist price
        /// </summary>
        double PCStylistPrice;
        /// <summary>
        /// The pc regular price
        /// </summary>
        double PCRegularPrice;
        /// <summary>
        /// The pc discount price
        /// </summary>
        double PCDiscountPrice;
        /// <summary>
        /// The q
        /// </summary>
        int q;
        /// <summary>
        /// The pc price
        /// </summary>
        double PCPrice;
        /// <summary>
        /// The pc tax
        /// </summary>
        double PCTax;

        /// <summary>
        /// The pc check mm value
        /// </summary>
        bool PCCheckMMVal;
        /// <summary>
        /// The pc mix match
        /// </summary>
        bool PCMixMatch;
        /// <summary>
        /// The pc mix match value
        /// </summary>
        int PCMixMatchVal;
        //double PCMixMatchPrice;
        /// <summary>
        /// The pc mix match qty
        /// </summary>
        int PCMixMatchQty;
        //int PCMixMatchCount;

        //Calculating_Saved_Amount
        /// <summary>
        /// The sa qty
        /// </summary>
        int SAQty;
        /// <summary>
        /// The sa retail price
        /// </summary>
        double SARetailPrice;
        /// <summary>
        /// The sa discount price
        /// </summary>
        double SADiscountPrice;
        /// <summary>
        /// The sa price
        /// </summary>
        double SAPrice;

        //LineDisply
        /// <summary>
        /// The s port
        /// </summary>
        public SerialPort sPort = new SerialPort();
        /// <summary>
        /// The display name
        /// </summary>
        public string displayName;
        /// <summary>
        /// The display price
        /// </summary>
        public string displayPrice;
        /// <summary>
        /// The opening ms g1
        /// </summary>
        public string openingMSG1;
        /// <summary>
        /// The opening ms g2
        /// </summary>
        public string openingMSG2;
        /// <summary>
        /// The closing ms g1
        /// </summary>
        public string closingMSG1;
        /// <summary>
        /// The closing ms g2
        /// </summary>
        public string closingMSG2;

        /// <summary>
        /// The u1
        /// </summary>
        /// <summary>
        /// The u2
        /// </summary>
        public string U1, U2;
        /// <summary>
        /// The l1
        /// </summary>
        /// <summary>
        /// The l2
        /// </summary>
        public string L1, L2;

        /// <summary>
        /// The s VFD port
        /// </summary>
        private SerialPort sVFDPort = new SerialPort();

        //ShortcutKey
        /// <summary>
        /// The f1 value
        /// </summary>
        string F1Value;
        /// <summary>
        /// The f2 value
        /// </summary>
        string F2Value;
        /// <summary>
        /// The f3 value
        /// </summary>
        string F3Value;
        /// <summary>
        /// The f4 value
        /// </summary>
        string F4Value;
        /// <summary>
        /// The f5 value
        /// </summary>
        string F5Value;
        /// <summary>
        /// The f6 value
        /// </summary>
        string F6Value;
        /// <summary>
        /// The f7 value
        /// </summary>
        string F7Value;
        /// <summary>
        /// The f8 value
        /// </summary>
        string F8Value;
        /// <summary>
        /// The f9 value
        /// </summary>
        string F9Value;
        /// <summary>
        /// The F10 value
        /// </summary>
        string F10Value;
        /// <summary>
        /// The F11 value
        /// </summary>
        string F11Value;
        /// <summary>
        /// The F12 value
        /// </summary>
        string F12Value;

        //StorePolicy
        /// <summary>
        /// The sp line1
        /// </summary>
        public string SP_Line1;
        /// <summary>
        /// The sp line2
        /// </summary>
        public string SP_Line2;
        /// <summary>
        /// The sp line3
        /// </summary>
        public string SP_Line3;
        /// <summary>
        /// The sp line4
        /// </summary>
        public string SP_Line4;
        /// <summary>
        /// The sp line5
        /// </summary>
        public string SP_Line5;
        /// <summary>
        /// The sp line6
        /// </summary>
        public string SP_Line6;
        /// <summary>
        /// The sp line7
        /// </summary>
        public string SP_Line7;
        /// <summary>
        /// The sp line8
        /// </summary>
        public string SP_Line8;
        /// <summary>
        /// The sp line9
        /// </summary>
        public string SP_Line9;
        /// <summary>
        /// The sp line10
        /// </summary>
        public string SP_Line10;
        /// <summary>
        /// The sp line11
        /// </summary>
        public string SP_Line11;
        /// <summary>
        /// The sp line12
        /// </summary>
        public string SP_Line12;
        /// <summary>
        /// The sp line13
        /// </summary>
        public string SP_Line13;
        /// <summary>
        /// The sp line14
        /// </summary>
        public string SP_Line14;
        /// <summary>
        /// The sp line15
        /// </summary>
        public string SP_Line15;
        /// <summary>
        /// The sp line16
        /// </summary>
        public string SP_Line16;
        /// <summary>
        /// The sp line17
        /// </summary>
        public string SP_Line17;
        /// <summary>
        /// The sp line18
        /// </summary>
        public string SP_Line18;
        /// <summary>
        /// The sp line19
        /// </summary>
        public string SP_Line19;
        /// <summary>
        /// The sp line20
        /// </summary>
        public string SP_Line20;

        /// <summary>
        /// The company name
        /// </summary>
        public string companyName;
        /// <summary>
        /// The receipt last comment
        /// </summary>
        public string receiptLastComment;

        //MixAndMatch
        /// <summary>
        /// The mm value count
        /// </summary>
        int mmValCount = 0;

        //bool checkMMVal = false;
        /// <summary>
        /// The check mm qty
        /// </summary>
        int checkMMQty = 0;

        /// <summary>
        /// The mm value count2
        /// </summary>
        int mmValCount2 = 0;
        /// <summary>
        /// The quotient
        /// </summary>
        int quotient = 0;
        /// <summary>
        /// The mm minimum retail price
        /// </summary>
        double[] mmMinRetailPrice;

        /// <summary>
        /// The mm retail price
        /// </summary>
        ArrayList mmRetailPrice;

        //Member Parameter
        /// <summary>
        /// The default member code
        /// </summary>
        public string defaultMemberCode = "101";
        /// <summary>
        /// The default member name
        /// </summary>
        public string defaultMemberName = "WALK INS";
        /// <summary>
        /// The default member type
        /// </summary>
        public string defaultMemberType = "";
        /// <summary>
        /// The default member points
        /// </summary>
        public string defaultMemberPoints = "$0.00";

        /// <summary>
        /// The m type1
        /// </summary>
        public string MType1;
        /// <summary>
        /// The m type2
        /// </summary>
        public string MType2;
        /// <summary>
        /// The m type3
        /// </summary>
        public string MType3;
        /// <summary>
        /// The m type4
        /// </summary>
        public string MType4;
        /// <summary>
        /// The m type5
        /// </summary>
        public string MType5;
        /// <summary>
        /// The m disc1
        /// </summary>
        public double MDisc1 = 0;
        /// <summary>
        /// The m disc2
        /// </summary>
        public double MDisc2 = 0;
        /// <summary>
        /// The m disc3
        /// </summary>
        public double MDisc3 = 0;
        /// <summary>
        /// The m disc4
        /// </summary>
        public double MDisc4 = 0;
        /// <summary>
        /// The m disc5
        /// </summary>
        public double MDisc5 = 0;
        /// <summary>
        /// The m PTS1
        /// </summary>
        public double MPts1 = 0;
        /// <summary>
        /// The m PTS2
        /// </summary>
        public double MPts2 = 0;
        /// <summary>
        /// The m PTS3
        /// </summary>
        public double MPts3 = 0;
        /// <summary>
        /// The m PTS4
        /// </summary>
        public double MPts4 = 0;
        /// <summary>
        /// The m PTS5
        /// </summary>
        public double MPts5 = 0;

        /// <summary>
        /// The bithday minimum age
        /// </summary>
        public int BithdayMinimumAge = 20;

        //Customer_Transaction_Update
        /// <summary>
        /// The command ctu
        /// </summary>
        SqlCommand cmd_CTU;

        //Giftcard
        /// <summary>
        /// The giftcard redeem
        /// </summary>
        public double giftcardRedeem = 0;
        /// <summary>
        /// The giftcard code desc
        /// </summary>
        public string giftcardCodeDesc;
        /// <summary>
        /// The giftcard store code
        /// </summary>
        public string giftcardStoreCode;

        /// <summary>
        /// The giftcard code for activation
        /// </summary>
        string giftcardCodeForActivation;
        /// <summary>
        /// The command giftcard activation
        /// </summary>
        SqlCommand cmdGiftcardActivation;

        //Coupon
        /// <summary>
        /// The cp redeem
        /// </summary>
        public bool cpRedeem = false;
        /// <summary>
        /// The wp cp number
        /// </summary>
        public string wp_cpNum;
        /// <summary>
        /// The wp cp target item
        /// </summary>
        public string wp_cpTargetItem;
        /// <summary>
        /// The wp cp description
        /// </summary>
        public string wp_cpDescription;

        //Coupon for SMS/Second visit
        public double CouponAmt = 0;
        public string CouponDesc;
        public string CouponMgrID;

        public int SecondVisitValidDays = 90;
        public bool boolNumSecondVisitCoupon = false;
        public int PTrns = 0;
        public int TTrns = 0;

        //Social Media Discount
        /// <summary>
        /// The command socail media discount
        /// </summary>
        SqlCommand cmd_SocailMediaDiscount;
        /// <summary>
        /// The sm discount
        /// </summary>
        public bool smDiscount = false;
        /// <summary>
        /// The sm cashier identifier
        /// </summary>
        public string smCashierID;

        //Extra Discoint1 - 25% for $50 purchase or more
        /// <summary>
        /// The command extra discount
        /// </summary>
        SqlCommand cmd_ExtraDiscount;
        /// <summary>
        /// The e discount1
        /// </summary>
        public bool eDiscount1 = false;
        /// <summary>
        /// The e cashier identifier
        /// </summary>
        public string eCashierID;

        /// <summary>
        /// The application identifier
        /// </summary>
        const String APPLICATION_ID = "com.Beauty4U.Register";
        /// <summary>
        /// The clover connector
        /// </summary>
        public ICloverConnector cloverConnector;
        /// <summary>
        /// The UI thread
        /// </summary>
        public SynchronizationContext uiThread;
        /// <summary>
        /// The display order
        /// </summary>
        DisplayOrder DisplayOrder;
        //POSLineItem listItem = new POSLineItem();
        /// <summary>
        /// The selected line item
        /// </summary>
        POSLineItem SelectedLineItem = null;
        /// <summary>
        /// The position line item to display line item
        /// </summary>
        Dictionary<POSLineItem, DisplayLineItem> posLineItemToDisplayLineItem = new Dictionary<POSLineItem, DisplayLineItem>();
        /// <summary>
        /// The connected
        /// </summary>
        public bool Connected = false;

        /// <summary>
        /// The c response
        /// </summary>
        public bool cResponse = false;
        /// <summary>
        /// The r amount
        /// </summary>
        public double rAmount = 0;
        /// <summary>
        /// The payment identifier
        /// </summary>
        public string paymentID = null;
        /// <summary>
        /// The order identifier
        /// </summary>
        public string orderID;
        /// <summary>
        /// The external payment identifier
        /// </summary>
        public string externalPaymentID;
        /// <summary>
        /// The credit identifier
        /// </summary>
        public string creditID;
        /// <summary>
        /// The reference identifier
        /// </summary>
        public string referenceID;
        /// <summary>
        /// The created time
        /// </summary>
        public Int64 createdTime = 0;
        /// <summary>
        /// The c sell date
        /// </summary>
        public string cSellDate;
        /// <summary>
        /// The c sell time
        /// </summary>
        public string cSellTime;
        /// <summary>
        /// The card type
        /// </summary>
        public string cardType;
        /// <summary>
        /// The entry type
        /// </summary>
        public string entryType;
        /// <summary>
        /// The transaction label
        /// </summary>
        public string transactionLabel;
        /// <summary>
        /// The last4
        /// </summary>
        public string last4;
        /// <summary>
        /// The card holder name
        /// </summary>
        public string cardHolderName;
        /// <summary>
        /// The authentication code
        /// </summary>
        public string authCode;
        /// <summary>
        /// The aid
        /// </summary>
        public string AID = "N/A";
        /// <summary>
        /// The CVM
        /// </summary>
        public string cvm;

        /// <summary>
        /// The clover device connection
        /// </summary>
        public string cloverDeviceConnection;
        /// <summary>
        /// The clover device current status
        /// </summary>
        public string cloverDeviceCurrentStatus;

        /// <summary>
        /// The no barcode button authentication
        /// </summary>
        public bool NoBarcodeButtonAuth = false;

        /// <summary>
        /// The batch identifier
        /// </summary>
        string BatchID;
        /// <summary>
        /// The batch device
        /// </summary>
        string BatchDevice;
        /// <summary>
        /// The batch merchant identifier
        /// </summary>
        Int64 BatchMerchantID;
        /// <summary>
        /// The batch count
        /// </summary>
        Int64 BatchCount;
        /// <summary>
        /// The batch total amount
        /// </summary>
        double BatchTotalAmount;
        /// <summary>
        /// The batch created time
        /// </summary>
        Int64 BatchCreatedTime;
        /// <summary>
        /// The batch user identifier
        /// </summary>
        public string BatchUserID = "DEFAULT";
        /// <summary>
        /// The temporary amount
        /// </summary>
        Int64 TempAmount = 0;

        //Discount Clear
        /// <summary>
        /// The dc qty
        /// </summary>
        int DCQty;
        /// <summary>
        /// The dc unit price
        /// </summary>
        double DCUnitPrice;
        /// <summary>
        /// The dc price
        /// </summary>
        double DCPrice;
        /// <summary>
        /// The dc tax
        /// </summary>
        double DCTax;

        //Card Payment Void History
        /// <summary>
        /// The vh payment identifier
        /// </summary>
        public string VHPaymentID;
        /// <summary>
        /// The vh order identifier
        /// </summary>
        public string VHOrderID;
        /// <summary>
        /// The vh receipt identifier
        /// </summary>
        public Int64 VHReceiptID = 0;
        /// <summary>
        /// The vh reference receipt identifier
        /// </summary>
        public Int64 VHRefReceiptID = 0;
        /// <summary>
        /// The vh amount
        /// </summary>
        public double VHAmount = 0;
        /// <summary>
        /// The vh employee identifier
        /// </summary>
        public string VHEmployeeID;
        /// <summary>
        /// The vh type
        /// </summary>
        public string VHType;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        /// <param name="CR">The cr.</param>
        /// <param name="EmpID">The emp identifier.</param>
        /// <param name="serverConnectionString">The server connection string.</param>
        public MainForm(string CR, string EmpID, string serverConnectionString)
        {
            InitializeComponent();

            uiThread = WindowsFormsSynchronizationContext.Current;
            cashRegisterNum = CR;
            employeeID = EmpID;
            conn = new SqlConnection(serverConnectionString);
        }

        /// <summary>
        /// Handles the Load event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void MainForm_Load(object sender, EventArgs e)
        {
            Application.ApplicationExit += new EventHandler(this.AppShutdown);
            DisplayOrder = new DisplayOrder();
            DisplayOrder.title = "Your Item(s)";
            CloverDeviceConfiguration USBConfig = new USBCloverDeviceConfiguration("__deviceID__", APPLICATION_ID, false, 1);
            InitializeConnector(USBConfig);
            connHQ = new SqlConnection(parentForm.B4UHQCS);

            nfi.CurrencySymbol = Application.CurrentCulture.NumberFormat.CurrencySymbol;
            nfi.CurrencyNegativePattern = 1;

            holdTable.Columns.Add("ItmQty", typeof(int));
            holdTable.Columns.Add("ItmRetailPrice", typeof(double));
            holdTable.Columns.Add("ItmUpc", typeof(string));

            if (parentForm.txtEmployeeID.Text.ToUpper() == parentForm.SystemMasterUserName.ToUpper())
            {
                btnJewerly.Visible = true;
                btnFindItem.Visible = true;
            }

            try
            {
                employeeLevel = parentForm.userLevel;

                lblStoreName.Text = parentForm.storeName;
                storeName = lblStoreName.Text.Trim().ToUpper();
                storeCode = parentForm.LRStoreCode;
                lblStoreCode.Text = storeCode;
                this.Text = "WELCOME TO " + parentForm.CSComapnyName + " - " + cashRegisterNum + " (EMPLOYEE ID : " + employeeID + ")";

                storeStreet = parentForm.LRStoreStreet;
                storeCityState = parentForm.LRStoreCity + ", " + parentForm.LRStoreState + " " + parentForm.LRStoreZipCode;
                storeTelephone = "TEL : " + parentForm.LRStoreTelephone;
                ss = parentForm.LRStoreStreetMargin;
                scs = parentForm.LRStoreCityStateMargin;
                st = parentForm.LRStoreTelephoneMargin;
                storeTaxRate = parentForm.LRStoreTaxRate;
                PcChargePath = parentForm.LRStorePcChargePath;
                merchantNum = parentForm.LRStoreMerchantNum;
                pcr = parentForm.LRStoreProcessor;
                user1 = parentForm.LRStorePcChargeUser1;
                user2 = parentForm.LRStorePcChargeUser2;
                user3 = parentForm.LRStorePcChargeUser3;
                user4 = parentForm.LRStorePcChargeUser4;
                PcChargeLoginID = parentForm.LRStorePcChargeLoginID;
                PcChargePassword = parentForm.LRStorePcChargePassword;

                F1Value = parentForm.LRF1;
                F2Value = parentForm.LRF2;
                F3Value = parentForm.LRF3;
                F4Value = parentForm.LRF4;
                F5Value = parentForm.LRF5;
                F6Value = parentForm.LRF6;
                F7Value = parentForm.LRF7;
                F8Value = parentForm.LRF8;
                F9Value = parentForm.LRF9;
                F10Value = parentForm.LRF10;
                F11Value = parentForm.LRF11;
                F12Value = parentForm.LRF12;

                PRINTER_NAME = parentForm.HWReceiptPrinterName;
                VFDCmdType = parentForm.HWVFDCmdType;
                /*if (storeCode == "OH" & cashRegisterNum == "REG01")
                {
                    VFDPort = "COM9";
                }
                else
                {
                    VFDPort = parentForm.HWVFDPort;
                }*/
                VFDPort = parentForm.HWVFDPort;
                VFDBaudRate = parentForm.HWVFDBaudRate;

                sVFDPort.PortName = VFDPort;
                sVFDPort.BaudRate = VFDBaudRate;
                sVFDPort.Parity = Parity.None;
                sVFDPort.DataBits = 8;
                sVFDPort.StopBits = StopBits.One;

                companyName = parentForm.CSComapnyName;
                receiptLastComment = parentForm.CSReceiptLastComment;

                openingMSG1 = parentForm.CDMOpeningMsg1;
                openingMSG2 = parentForm.CDMOpeningMsg2;
                closingMSG1 = parentForm.CDMClosingMsg1;
                closingMSG2 = parentForm.CDMClosingMSG2;

                SqlCommand cmd_Check_Register_Status = new SqlCommand("Check_Register_Status", conn);
                cmd_Check_Register_Status.CommandType = CommandType.StoredProcedure;
                cmd_Check_Register_Status.Parameters.Clear();
                cmd_Check_Register_Status.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = cashRegisterNum;
                cmd_Check_Register_Status.Parameters.Add("@TransactionStatus", SqlDbType.NVarChar).Value = "START";
                cmd_Check_Register_Status.Parameters.Add("@RegDate", SqlDbType.NVarChar).Value = DateTime.Today.ToString("d");
                SqlParameter Output_Param = cmd_Check_Register_Status.Parameters.Add("@Output", SqlDbType.NVarChar, 20);
                Output_Param.Direction = ParameterDirection.Output;

                SqlCommand cmd_StorePolicy = new SqlCommand("Loading_StorePolicy", conn);
                cmd_StorePolicy.CommandType = CommandType.StoredProcedure;
                DataTable dt_StorePolicy = new DataTable();
                SqlDataAdapter adapt_StorePolicy = new SqlDataAdapter();
                adapt_StorePolicy.SelectCommand = cmd_StorePolicy;

                SqlCommand cmd_CustomerSetup = new SqlCommand("Loading_CustomerSetup", conn);
                cmd_CustomerSetup.CommandType = CommandType.StoredProcedure;
                DataTable dt_CustomerSetup = new DataTable();
                SqlDataAdapter adapt_CustomerSetup = new SqlDataAdapter();
                adapt_CustomerSetup.SelectCommand = cmd_CustomerSetup;

                conn.Open();
                cmd_Check_Register_Status.ExecuteNonQuery();
                adapt_StorePolicy.Fill(dt_StorePolicy);
                adapt_CustomerSetup.Fill(dt_CustomerSetup);
                conn.Close();

                dataGridView2.DataSource = dt_StorePolicy;
                SP_Line1 = Convert.ToString(dataGridView2.Rows[0].Cells[1].Value);
                SP_Line2 = Convert.ToString(dataGridView2.Rows[1].Cells[1].Value);
                SP_Line3 = Convert.ToString(dataGridView2.Rows[2].Cells[1].Value);
                SP_Line4 = Convert.ToString(dataGridView2.Rows[3].Cells[1].Value);
                SP_Line5 = Convert.ToString(dataGridView2.Rows[4].Cells[1].Value);
                SP_Line6 = Convert.ToString(dataGridView2.Rows[5].Cells[1].Value);
                SP_Line7 = Convert.ToString(dataGridView2.Rows[6].Cells[1].Value);
                SP_Line8 = Convert.ToString(dataGridView2.Rows[7].Cells[1].Value);
                SP_Line9 = Convert.ToString(dataGridView2.Rows[8].Cells[1].Value);
                SP_Line10 = Convert.ToString(dataGridView2.Rows[9].Cells[1].Value);
                SP_Line11 = Convert.ToString(dataGridView2.Rows[10].Cells[1].Value);
                SP_Line12 = Convert.ToString(dataGridView2.Rows[11].Cells[1].Value);
                SP_Line13 = Convert.ToString(dataGridView2.Rows[12].Cells[1].Value);
                SP_Line14 = Convert.ToString(dataGridView2.Rows[13].Cells[1].Value);
                SP_Line15 = Convert.ToString(dataGridView2.Rows[14].Cells[1].Value);
                SP_Line16 = Convert.ToString(dataGridView2.Rows[15].Cells[1].Value);
                SP_Line17 = Convert.ToString(dataGridView2.Rows[16].Cells[1].Value);
                SP_Line18 = Convert.ToString(dataGridView2.Rows[17].Cells[1].Value);
                SP_Line19 = Convert.ToString(dataGridView2.Rows[18].Cells[1].Value);
                SP_Line20 = Convert.ToString(dataGridView2.Rows[19].Cells[1].Value);

                dataGridView3.DataSource = dt_CustomerSetup;
                MType1 = Convert.ToString(dataGridView3.Rows[0].Cells[1].Value).ToUpper();
                MType2 = Convert.ToString(dataGridView3.Rows[1].Cells[1].Value).ToUpper();
                MType3 = Convert.ToString(dataGridView3.Rows[2].Cells[1].Value).ToUpper();
                MType4 = Convert.ToString(dataGridView3.Rows[3].Cells[1].Value).ToUpper();
                MType5 = Convert.ToString(dataGridView3.Rows[4].Cells[1].Value).ToUpper();
                MDisc1 = Convert.ToDouble(dataGridView3.Rows[0].Cells[2].Value);
                MDisc2 = Convert.ToDouble(dataGridView3.Rows[1].Cells[2].Value);
                MDisc3 = Convert.ToDouble(dataGridView3.Rows[2].Cells[2].Value);
                MDisc4 = Convert.ToDouble(dataGridView3.Rows[3].Cells[2].Value);
                MDisc5 = Convert.ToDouble(dataGridView3.Rows[4].Cells[2].Value);
                MPts1 = Convert.ToDouble(dataGridView3.Rows[0].Cells[3].Value);
                MPts2 = Convert.ToDouble(dataGridView3.Rows[1].Cells[3].Value);
                MPts3 = Convert.ToDouble(dataGridView3.Rows[2].Cells[3].Value);
                MPts4 = Convert.ToDouble(dataGridView3.Rows[3].Cells[3].Value);
                MPts5 = Convert.ToDouble(dataGridView3.Rows[4].Cells[3].Value);

                if (cmd_Check_Register_Status.Parameters["@Output"].Value == DBNull.Value)
                    MyMessageBox.ShowBox("REGISTER IS NOT STARTED\n" + "PLEASE START REGISTER FIRST", "ERROR");

                btnShowHold.Enabled = false;
                promotionActive = Check_Promotion_Active();

                LineDisply(openingMSG1, openingMSG2);

                richTxtUpc.Select();
                richTxtUpc.Focus();

                System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
                t.Tick += new EventHandler(t_Tick);
                t.Start();
            }
            catch
            {
                MyMessageBox.ShowBox("CAN NOT LOAD REGISTER\n" + "PLEASE TRY AGAIN", "ERROR");
                Application.Exit();
            }
        }

        /// <summary>
        /// Handles the Tick event of the t control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void t_Tick(object sender, EventArgs e)
        {
            this.lblLocalTime.Text = DateTime.Now.ToString();
        }

        /// <summary>
        /// Gets or sets the get qty.
        /// </summary>
        /// <value>The get qty.</value>
        public string getQty
        {
            get { return lblQty.Text; }
            set { lblQty.Text = value; }
        }

        /// <summary>
        /// Handles the Click event of the btnOne control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOne_Click(object sender, EventArgs e)
        {
            tempUpc = richTxtUpc.Text + "1";
            richTxtUpc.Text = tempUpc;
            tempUpc = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the btnTwo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnTwo_Click(object sender, EventArgs e)
        {
            tempUpc = richTxtUpc.Text + "2";
            richTxtUpc.Text = tempUpc;
            tempUpc = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the btnThree control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnThree_Click(object sender, EventArgs e)
        {
            tempUpc = richTxtUpc.Text + "3";
            richTxtUpc.Text = tempUpc;
            tempUpc = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the btnFour control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnFour_Click(object sender, EventArgs e)
        {
            tempUpc = richTxtUpc.Text + "4";
            richTxtUpc.Text = tempUpc;
            tempUpc = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the btnFive control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnFive_Click(object sender, EventArgs e)
        {
            tempUpc = richTxtUpc.Text + "5";
            richTxtUpc.Text = tempUpc;
            tempUpc = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the btnSix control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSix_Click(object sender, EventArgs e)
        {
            tempUpc = richTxtUpc.Text + "6";
            richTxtUpc.Text = tempUpc;
            tempUpc = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the btnSeven control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSeven_Click(object sender, EventArgs e)
        {
            tempUpc = richTxtUpc.Text + "7";
            richTxtUpc.Text = tempUpc;
            tempUpc = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the btnEight control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnEight_Click(object sender, EventArgs e)
        {
            tempUpc = richTxtUpc.Text + "8";
            richTxtUpc.Text = tempUpc;
            tempUpc = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the btnNine control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnNine_Click(object sender, EventArgs e)
        {
            tempUpc = richTxtUpc.Text + "9";
            richTxtUpc.Text = tempUpc;
            tempUpc = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the btnZero control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnZero_Click(object sender, EventArgs e)
        {
            tempUpc = richTxtUpc.Text + "0";
            richTxtUpc.Text = tempUpc;
            tempUpc = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the btnBack control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (richTxtUpc.Text != "")
                richTxtUpc.Text = richTxtUpc.Text.Substring(0, richTxtUpc.Text.Length - 1);

            richTxtUpc.Focus();
            richTxtUpc.Select();
        }

        /// <summary>
        /// Handles the Click event of the btnCLS control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCLS_Click(object sender, EventArgs e)
        {
            richTxtUpc.Clear();
            richTxtUpc.SelectAll();
            richTxtUpc.Focus();
        }

        /// <summary>
        /// Handles the Click event of the btnInput control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnInput_Click(object sender, EventArgs e)
        {
            if (ItmUpc == "")
            {
                if (richTxtUpc.Text == "")
                {
                    richTxtUpc.Focus();
                    richTxtUpc.Select();
                    return;
                }
                else
                {
                    //Checking if point or giftcard redeemed
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        if (richTxtUpc.Text.Trim().ToUpper() == pointRedeemBarcode | richTxtUpc.Text.Trim().ToUpper() == giftCardBarcode | richTxtUpc.Text.Trim().ToUpper() == couponBarcode)
                        {

                        }
                        else
                        {
                            if (Convert.ToString(dataGridView1.Rows[i].Cells[7].Value) == pointRedeemBarcode)
                            {
                                MyMessageBox.ShowBox("CAN NOT ADD MORE ITEMS AFTER USING POINTS REDEEMED", "ERROR");
                                richTxtUpc.Clear();
                                richTxtUpc.Focus();
                                richTxtUpc.Select();
                                return;
                            }
                            else if (Convert.ToString(dataGridView1.Rows[i].Cells[7].Value) == giftCardBarcode)
                            {
                                MyMessageBox.ShowBox("CAN NOT ADD MORE ITEMS AFTER USING GIFT CARD REDEEMED", "ERROR");
                                richTxtUpc.Clear();
                                richTxtUpc.Focus();
                                richTxtUpc.Select();
                                return;
                            }
                            else if (Convert.ToString(dataGridView1.Rows[i].Cells[7].Value) == couponBarcode)
                            {
                                MyMessageBox.ShowBox("CAN NOT ADD MORE ITEMS AFTER USING COUPON REDEEMED", "ERROR");
                                richTxtUpc.Clear();
                                richTxtUpc.Focus();
                                richTxtUpc.Select();
                                return;
                            }
                        }
                    }

                    if (richTxtUpc.Text == giftCardBarcode & giftcardRedeem != 0)
                    {
                        BindDataGridView("Giftcard_Redeemed", giftCardBarcode, giftcardRedeem, giftcardCodeDesc);

                        Calculation();
                        Calculating_Saved_Amount();
                        Display_Item_Price(2);

                        richTxtUpc.Focus();
                        richTxtUpc.Select();
                        return;
                    }

                    /*if (richTxtUpc.Text == couponBarcode & cpRedeem == true)
                    {
                        BindDataGridView("Coupon_Redeemed", couponBarcode, wp_cpNum, wp_cpDescription);

                        Calculation();
                        Calculating_Saved_Amount();
                        Display_Item_Price(3);

                        richTxtUpc.Focus();
                        richTxtUpc.Select();
                        return;
                    }*/

                    if (richTxtUpc.Text == couponBarcode & CouponAmt != 0)
                    {
                        BindDataGridView("Coupon_Redeemed_General", couponBarcode, CouponAmt, CouponDesc);

                        Calculation();
                        Calculating_Saved_Amount();
                        Display_Item_Price(2);

                        richTxtUpc.Focus();
                        richTxtUpc.Select();
                        return;
                    }

                    if (richTxtUpc.Text == "000000999110" & points != 0)
                    {
                        BindDataGridView("Points_Redeemed", pointRedeemBarcode, points);

                        Calculation();
                        Calculating_Saved_Amount();
                        Display_Item_Price(2);

                        richTxtUpc.Focus();
                        richTxtUpc.Select();
                        return;
                    }

                    inputUpc = richTxtUpc.Text.ToUpper();

                    //Check Duplicated Item
                    /*for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        if (dataGridView1.Rows[i].Cells[7].Value.ToString() == inputUpc & ItmPrice == "")
                        {
                            //if (dataGridView1.Rows[i].Cells[8].Value.ToString() == "2" | dataGridView1.Rows[i].Cells[8].Value.ToString() == "3")
                            if (promotionActive == true & Convert.ToInt16(dataGridView1.Rows[i].Cells[18].Value) != 0 & Convert.ToInt16(dataGridView1.Rows[i].Cells[20].Value) > 1)
                            {
                            }
                            else if (Convert.ToInt16(dataGridView1.SelectedCells[8].Value) == 7 & Convert.ToInt16(dataGridView1.SelectedCells[9].Value) == 5 & Convert.ToInt16(dataGridView1.SelectedCells[10].Value) == 1)
                            {
                            }
                            else
                            {
                                inputQty = Convert.ToInt16(dataGridView1.Rows[i].Cells[2].Value) + Convert.ToInt16(lblQty.Text);
                                dataGridView1.Rows[i].Cells[2].Value = inputQty;

                                if (Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) == 0)
                                {
                                    //if (Convert.ToDouble(dataGridView1.Rows[i].Cells[19].Value) > 0)
                                    if (promotionActive == true & Convert.ToBoolean(dataGridView1.Rows[i].Cells[17].Value) == true & Convert.ToDouble(dataGridView1.Rows[i].Cells[19].Value) >= 0)
                                    {
                                        dataGridView1.Rows[i].Cells[4].Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[19].Value);
                                        dataGridView1.Rows[i].Cells[5].Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * inputQty;
                                        dataGridView1.Rows[i].Cells[6].Value = Math.Round(Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value) * storeTaxRate, 2, MidpointRounding.AwayFromZero);
                                        dataGridView1.Rows[i].Selected = true;

                                        Calculation();
                                        Calculating_Saved_Amount();

                                        Display_Item_Price(0);
                                        richTxtUpc.Clear();
                                        richTxtUpc.Select();
                                        richTxtUpc.Focus();
                                        return;
                                    }
                                    else
                                    {
                                        dataGridView1.Rows[i].Cells[5].Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value) * inputQty;
                                        dataGridView1.Rows[i].Cells[6].Value = Math.Round(Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value) * storeTaxRate, 2, MidpointRounding.AwayFromZero);
                                        dataGridView1.Rows[i].Selected = true;

                                        Calculation();
                                        Calculating_Saved_Amount();

                                        Display_Item_Price(0);
                                        richTxtUpc.Clear();
                                        richTxtUpc.Select();
                                        richTxtUpc.Focus();
                                        return;
                                    }
                                }
                                else
                                {
                                    //if (Convert.ToDouble(dataGridView1.Rows[i].Cells[19].Value) > 0)
                                    if (promotionActive == true & Convert.ToBoolean(dataGridView1.Rows[i].Cells[17].Value) == true & Convert.ToDouble(dataGridView1.Rows[i].Cells[19].Value) >= 0)
                                    {
                                        inputDiscountPrice = Math.Min(Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value), Convert.ToDouble(dataGridView1.Rows[i].Cells[19].Value));
                                        dataGridView1.Rows[i].Cells[4].Value = inputDiscountPrice;
                                        dataGridView1.Rows[i].Cells[5].Value = inputDiscountPrice * inputQty;
                                        dataGridView1.Rows[i].Cells[6].Value = Math.Round(Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value) * storeTaxRate, 2, MidpointRounding.AwayFromZero);
                                        dataGridView1.Rows[i].Selected = true;

                                        Calculation();
                                        Calculating_Saved_Amount();

                                        Display_Item_Price(0);
                                        richTxtUpc.Clear();
                                        richTxtUpc.Select();
                                        richTxtUpc.Focus();
                                        return;
                                    }
                                    else
                                    {
                                        inputDiscountPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                                        dataGridView1.Rows[i].Cells[5].Value = inputDiscountPrice * inputQty;
                                        dataGridView1.Rows[i].Cells[6].Value = Math.Round(Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value) * storeTaxRate, 2, MidpointRounding.AwayFromZero);
                                        dataGridView1.Rows[i].Selected = true;

                                        Calculation();
                                        Calculating_Saved_Amount();

                                        Display_Item_Price(0);
                                        richTxtUpc.Clear();
                                        richTxtUpc.Select();
                                        richTxtUpc.Focus();
                                        return;
                                    }
                                }
                            }
                        }
                    }*/

                    c = CountUpc("Count_ItmUpc", richTxtUpc.Text.ToUpper());
                    if (c > 1)
                    {
                        SelectUpc selectUpcForm = new SelectUpc(richTxtUpc.Text.ToUpper());
                        selectUpcForm.parentform = this;
                        selectUpcForm.Show();
                    }
                    else
                    {
                        if (ItmPrice == "")
                        {
                            upcCheck = BindDataGridView("Get_Item_To_Register_By_Upc", lblQty.Text, richTxtUpc.Text.ToUpper());

                            if (upcCheck == false)
                            {
                                MyMessageBox.ShowBox("CAN NOT FIND UPC", "ERROR");
                                richTxtUpc.SelectAll();
                                richTxtUpc.Focus();
                                return;
                            }
                            else
                            {
                                richTxtUpc.Clear();
                            }

                            if (promotionActive == true)
                                Set_Promotion_Values();
                        }
                        else
                        {
                            BindDataGridView("Get_Item_To_Register_By_NonUpc", lblQty.Text, richTxtUpc.Text.ToUpper(), Convert.ToDouble(ItmPrice));
                            ItmPrice = string.Empty;
                        }
                    }

                }
            }
            else
            {
                BindDataGridView("Get_Item_To_Register_By_Others", lblQty.Text, ItmBrand, ItmName, ItmSize, ItmColor, ItmUpc);

                ItmBrand = string.Empty;
                ItmName = string.Empty;
                ItmUpc = string.Empty;
                ItmSize = string.Empty;
                ItmColor = string.Empty;

                if (promotionActive == true)
                    Set_Promotion_Values();
            }

            //if (promotionActive == true & Convert.ToBoolean(dataGridView1.SelectedCells[17].Value) == true & Convert.ToInt16(dataGridView1.SelectedCells[18].Value) >= 1)
            if (promotionActive == true & Convert.ToBoolean(dataGridView1.SelectedCells[17].Value) == true)
            {
                if (Convert.ToDouble(dataGridView1.SelectedCells[4].Value) > 0)
                {
                    //if (lblType.Text.ToUpper() == "BEAUTICIAN" | lblType.Text.ToUpper() == "10% OFF VIP")
                    if (lblName.Text.ToUpper() != defaultMemberName)
                    {
                        if (lblType.Text.ToUpper() == MType2)
                        {
                            inputUnitPrice = Convert.ToDouble(dataGridView1.SelectedCells[3].Value);
                            inputOriginDiscount = Convert.ToDouble(dataGridView1.SelectedCells[4].Value);
                            inputDiscountPrice = Math.Round(inputUnitPrice * ((100 - MDisc2) / 100), 2, MidpointRounding.AwayFromZero);

                            if (inputOriginDiscount > inputDiscountPrice)
                                dataGridView1.SelectedCells[4].Value = inputDiscountPrice;

                            if (inputUnitPrice == inputOriginDiscount)
                                dataGridView1.SelectedCells[4].Value = inputOriginDiscount;
                        }
                        else if (lblType.Text.ToUpper() == MType3)
                        {
                            inputUnitPrice = Convert.ToDouble(dataGridView1.SelectedCells[3].Value);
                            inputOriginDiscount = Convert.ToDouble(dataGridView1.SelectedCells[4].Value);
                            inputDiscountPrice = Math.Round(inputUnitPrice * ((100 - MDisc3) / 100), 2, MidpointRounding.AwayFromZero);

                            if (inputOriginDiscount > inputDiscountPrice)
                                dataGridView1.SelectedCells[4].Value = inputDiscountPrice;

                            if (inputUnitPrice == inputOriginDiscount)
                                dataGridView1.SelectedCells[4].Value = inputOriginDiscount;
                        }
                        else if (lblType.Text.ToUpper() == MType4)
                        {
                            inputUnitPrice = Convert.ToDouble(dataGridView1.SelectedCells[3].Value);
                            inputOriginDiscount = Convert.ToDouble(dataGridView1.SelectedCells[4].Value);
                            inputDiscountPrice = Math.Round(inputUnitPrice * ((100 - MDisc4) / 100), 2, MidpointRounding.AwayFromZero);

                            if (inputOriginDiscount > inputDiscountPrice)
                                dataGridView1.SelectedCells[4].Value = inputDiscountPrice;

                            if (inputUnitPrice == inputOriginDiscount)
                                dataGridView1.SelectedCells[4].Value = inputOriginDiscount;
                        }
                        else if (lblType.Text.ToUpper() == MType5)
                        {
                            inputUnitPrice = Convert.ToDouble(dataGridView1.SelectedCells[3].Value);
                            inputOriginDiscount = Convert.ToDouble(dataGridView1.SelectedCells[4].Value);
                            inputDiscountPrice = Math.Round(inputUnitPrice * ((100 - MDisc5) / 100), 2, MidpointRounding.AwayFromZero);

                            if (inputOriginDiscount > inputDiscountPrice)
                                dataGridView1.SelectedCells[4].Value = inputDiscountPrice;

                            if (inputUnitPrice == inputOriginDiscount)
                                dataGridView1.SelectedCells[4].Value = inputOriginDiscount;
                        }

                        /*inputUnitPrice = Convert.ToDouble(dataGridView1.SelectedCells[3].Value);
                        inputOriginDiscount = Convert.ToDouble(dataGridView1.SelectedCells[4].Value);
                        inputDiscountPrice = Math.Round(inputUnitPrice * 0.9, 2, MidpointRounding.AwayFromZero);

                        if (inputOriginDiscount > inputDiscountPrice)
                            dataGridView1.SelectedCells[4].Value = inputDiscountPrice;

                        if (inputUnitPrice == inputOriginDiscount)
                            dataGridView1.SelectedCells[4].Value = inputOriginDiscount;*/

                        Compare_MixMatchPrice(Convert.ToInt16(dataGridView1.SelectedCells[18].Value), Convert.ToInt16(dataGridView1.SelectedCells[20].Value), dataGridView1.SelectedRows[0].Index);
                    }
                    else
                    {
                        Compare_MixMatchPrice(Convert.ToInt16(dataGridView1.SelectedCells[18].Value), Convert.ToInt16(dataGridView1.SelectedCells[20].Value), dataGridView1.SelectedRows[0].Index);
                    }
                }
                else if (Convert.ToDouble(dataGridView1.SelectedCells[4].Value) == 0 & Convert.ToDouble(dataGridView1.SelectedCells[3].Value) > 0)
                {
                    //if (lblType.Text.ToUpper() == "BEAUTICIAN" | lblType.Text.ToUpper() == "10% OFF VIP")
                    if (lblName.Text.ToUpper() != defaultMemberName)
                    {
                        if (lblType.Text.ToUpper() == MType2)
                        {
                            inputUnitPrice = Convert.ToDouble(dataGridView1.SelectedCells[3].Value);
                            inputDiscountPrice = Math.Round(inputUnitPrice * ((100 - MDisc2) / 100), 2, MidpointRounding.AwayFromZero);
                            dataGridView1.SelectedCells[4].Value = inputDiscountPrice;
                        }
                        else if (lblType.Text.ToUpper() == MType3)
                        {
                            inputUnitPrice = Convert.ToDouble(dataGridView1.SelectedCells[3].Value);
                            inputDiscountPrice = Math.Round(inputUnitPrice * ((100 - MDisc3) / 100), 2, MidpointRounding.AwayFromZero);
                            dataGridView1.SelectedCells[4].Value = inputDiscountPrice;
                        }
                        else if (lblType.Text.ToUpper() == MType4)
                        {
                            inputUnitPrice = Convert.ToDouble(dataGridView1.SelectedCells[3].Value);
                            inputDiscountPrice = Math.Round(inputUnitPrice * ((100 - MDisc4) / 100), 2, MidpointRounding.AwayFromZero);
                            dataGridView1.SelectedCells[4].Value = inputDiscountPrice;
                        }
                        else if (lblType.Text.ToUpper() == MType5)
                        {
                            inputUnitPrice = Convert.ToDouble(dataGridView1.SelectedCells[3].Value);
                            inputDiscountPrice = Math.Round(inputUnitPrice * ((100 - MDisc5) / 100), 2, MidpointRounding.AwayFromZero);
                            dataGridView1.SelectedCells[4].Value = inputDiscountPrice;
                        }


                        //inputUnitPrice = Convert.ToDouble(dataGridView1.SelectedCells[3].Value);
                        //inputDiscountPrice = Math.Round(inputUnitPrice * 0.9, 2, MidpointRounding.AwayFromZero);
                        //dataGridView1.SelectedCells[4].Value = inputDiscountPrice;
                    }

                    Compare_MixMatchPrice(Convert.ToInt16(dataGridView1.SelectedCells[18].Value), Convert.ToInt16(dataGridView1.SelectedCells[20].Value), dataGridView1.SelectedRows[0].Index);
                }
                else
                {
                    Compare_MixMatchPrice(Convert.ToInt16(dataGridView1.SelectedCells[18].Value), Convert.ToInt16(dataGridView1.SelectedCells[20].Value), dataGridView1.SelectedRows[0].Index);
                }
            }
            else
            {
                if (Convert.ToDouble(dataGridView1.SelectedCells[4].Value) > 0)
                {
                    //if (lblType.Text.ToUpper() == "BEAUTICIAN" | lblType.Text.ToUpper() == "10% OFF VIP")
                    if (lblName.Text.ToUpper() != defaultMemberName)
                    {
                        if (lblType.Text.ToUpper() == MType2)
                        {
                            inputUnitPrice = Convert.ToDouble(dataGridView1.SelectedCells[3].Value);
                            inputOriginDiscount = Convert.ToDouble(dataGridView1.SelectedCells[4].Value);
                            inputDiscountPrice = Math.Round(inputUnitPrice * ((100 - MDisc2) / 100), 2, MidpointRounding.AwayFromZero);

                            if (inputOriginDiscount > inputDiscountPrice)
                                dataGridView1.SelectedCells[4].Value = inputDiscountPrice;

                            if (inputUnitPrice == inputOriginDiscount)
                                dataGridView1.SelectedCells[4].Value = inputOriginDiscount;
                        }
                        else if (lblType.Text.ToUpper() == MType3)
                        {
                            inputUnitPrice = Convert.ToDouble(dataGridView1.SelectedCells[3].Value);
                            inputOriginDiscount = Convert.ToDouble(dataGridView1.SelectedCells[4].Value);
                            inputDiscountPrice = Math.Round(inputUnitPrice * ((100 - MDisc3) / 100), 2, MidpointRounding.AwayFromZero);

                            if (inputOriginDiscount > inputDiscountPrice)
                                dataGridView1.SelectedCells[4].Value = inputDiscountPrice;

                            if (inputUnitPrice == inputOriginDiscount)
                                dataGridView1.SelectedCells[4].Value = inputOriginDiscount;
                        }
                        else if (lblType.Text.ToUpper() == MType4)
                        {
                            inputUnitPrice = Convert.ToDouble(dataGridView1.SelectedCells[3].Value);
                            inputOriginDiscount = Convert.ToDouble(dataGridView1.SelectedCells[4].Value);
                            inputDiscountPrice = Math.Round(inputUnitPrice * ((100 - MDisc4) / 100), 2, MidpointRounding.AwayFromZero);

                            if (inputOriginDiscount > inputDiscountPrice)
                                dataGridView1.SelectedCells[4].Value = inputDiscountPrice;

                            if (inputUnitPrice == inputOriginDiscount)
                                dataGridView1.SelectedCells[4].Value = inputOriginDiscount;
                        }
                        else if (lblType.Text.ToUpper() == MType5)
                        {
                            inputUnitPrice = Convert.ToDouble(dataGridView1.SelectedCells[3].Value);
                            inputOriginDiscount = Convert.ToDouble(dataGridView1.SelectedCells[4].Value);
                            inputDiscountPrice = Math.Round(inputUnitPrice * ((100 - MDisc5) / 100), 2, MidpointRounding.AwayFromZero);

                            if (inputOriginDiscount > inputDiscountPrice)
                                dataGridView1.SelectedCells[4].Value = inputDiscountPrice;

                            if (inputUnitPrice == inputOriginDiscount)
                                dataGridView1.SelectedCells[4].Value = inputOriginDiscount;
                        }

                        /*inputUnitPrice = Convert.ToDouble(dataGridView1.SelectedCells[3].Value);
                        inputOriginDiscount = Convert.ToDouble(dataGridView1.SelectedCells[4].Value);
                        inputDiscountPrice = Math.Round(inputUnitPrice * 0.9, 2, MidpointRounding.AwayFromZero);

                        if (inputOriginDiscount > inputDiscountPrice)
                            dataGridView1.SelectedCells[4].Value = inputDiscountPrice;

                        if (inputUnitPrice == inputOriginDiscount)
                            dataGridView1.SelectedCells[4].Value = inputOriginDiscount;*/

                        Price_Comparing(dataGridView1.SelectedRows[0].Index);
                    }
                    else
                    {
                        Price_Comparing(dataGridView1.SelectedRows[0].Index);
                    }
                }
                else if (Convert.ToDouble(dataGridView1.SelectedCells[4].Value) == 0 & Convert.ToDouble(dataGridView1.SelectedCells[3].Value) > 0)
                {
                    //if (lblType.Text.ToUpper() == "BEAUTICIAN" | lblType.Text.ToUpper() == "10% OFF VIP")
                    if (lblName.Text.ToUpper() != defaultMemberName)
                    {
                        if (lblType.Text.ToUpper() == MType2)
                        {
                            inputUnitPrice = Convert.ToDouble(dataGridView1.SelectedCells[3].Value);
                            inputDiscountPrice = Math.Round(inputUnitPrice * ((100 - MDisc2) / 100), 2, MidpointRounding.AwayFromZero);
                            dataGridView1.SelectedCells[4].Value = inputDiscountPrice;
                        }
                        else if (lblType.Text.ToUpper() == MType3)
                        {
                            inputUnitPrice = Convert.ToDouble(dataGridView1.SelectedCells[3].Value);
                            inputDiscountPrice = Math.Round(inputUnitPrice * ((100 - MDisc3) / 100), 2, MidpointRounding.AwayFromZero);
                            dataGridView1.SelectedCells[4].Value = inputDiscountPrice;
                        }
                        else if (lblType.Text.ToUpper() == MType4)
                        {
                            inputUnitPrice = Convert.ToDouble(dataGridView1.SelectedCells[3].Value);
                            inputDiscountPrice = Math.Round(inputUnitPrice * ((100 - MDisc4) / 100), 2, MidpointRounding.AwayFromZero);
                            dataGridView1.SelectedCells[4].Value = inputDiscountPrice;
                        }
                        else if (lblType.Text.ToUpper() == MType5)
                        {
                            inputUnitPrice = Convert.ToDouble(dataGridView1.SelectedCells[3].Value);
                            inputDiscountPrice = Math.Round(inputUnitPrice * ((100 - MDisc5) / 100), 2, MidpointRounding.AwayFromZero);
                            dataGridView1.SelectedCells[4].Value = inputDiscountPrice;
                        }

                        //inputUnitPrice = Convert.ToDouble(dataGridView1.SelectedCells[3].Value);
                        //inputDiscountPrice = Math.Round(inputUnitPrice * 0.9, 2, MidpointRounding.AwayFromZero);
                        //dataGridView1.SelectedCells[4].Value = inputDiscountPrice;
                    }

                    Price_Comparing(dataGridView1.SelectedRows[0].Index);
                }
                else
                {
                    Price_Comparing(dataGridView1.SelectedRows[0].Index);
                }
            }

            inputUpc = string.Empty;
            inputQty = 0;
            inputDiscountPrice = 0;
            inputUnitPrice = 0;
            inputOriginDiscount = 0;

            Calculation();
            Calculating_Saved_Amount();

            Display_Item_Price(0);
            //DisplayItemOnClover();
            richTxtUpc.Focus();
            richTxtUpc.Select();
        }

        /// <summary>
        /// Handles the Click event of the btnQty control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnQty_Click(object sender, EventArgs e)
        {
            ChangeQty changeQtyForm = new ChangeQty();
            changeQtyForm.parentform = this;
            changeQtyForm.ShowDialog();
        }

        /// <summary>
        /// Handles the Click event of the btnQtyP control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnQtyP_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (Convert.ToString(dataGridView1.SelectedCells[8].Value) == "10" | Convert.ToString(dataGridView1.SelectedCells[8].Value) == "11" | Convert.ToString(dataGridView1.SelectedCells[8].Value) == "12")
                    return;

                if (Convert.ToString(dataGridView1.SelectedCells[8].Value) == "7" & Convert.ToString(dataGridView1.SelectedCells[9].Value) == "5" & Convert.ToString(dataGridView1.SelectedCells[10].Value) == "1")
                    return;

                if (Convert.ToDouble(dataGridView1.SelectedCells[4].Value) == 0)
                {
                    n = Convert.ToInt16(dataGridView1.SelectedCells[2].Value);

                    if (n == 0)
                    {
                        return;
                    }

                    QtyUnitPrice = Convert.ToDouble(dataGridView1.SelectedCells[3].Value);
                    dataGridView1.SelectedCells[2].Value = n + 1;
                    dataGridView1.SelectedCells[5].Value = (n + 1) * QtyUnitPrice;
                    dataGridView1.SelectedCells[6].Value = Math.Round(((n + 1) * QtyUnitPrice * storeTaxRate), 2, MidpointRounding.AwayFromZero);

                    displayName = dataGridView1.SelectedCells[1].Value.ToString();

                    if (displayName.Length > 20)
                        displayName = displayName.Substring(0, 19);

                    if (Convert.ToDouble(dataGridView1.SelectedCells[4].Value) > 0)
                    {
                        displayPrice = string.Format("{0:$0.00}", Convert.ToDouble(dataGridView1.SelectedCells[4].Value));
                    }
                    else
                    {
                        displayPrice = string.Format("{0:$0.00}", Convert.ToDouble(dataGridView1.SelectedCells[3].Value));
                    }

                    LineDisply(displayName, displayPrice);
                    Calculation();
                }
                else
                {
                    n = Convert.ToInt16(dataGridView1.SelectedCells[2].Value);

                    if (n == 0)
                    {
                        return;
                    }

                    QtyDiscountPrice = Convert.ToDouble(dataGridView1.SelectedCells[4].Value);
                    dataGridView1.SelectedCells[2].Value = n + 1;
                    dataGridView1.SelectedCells[5].Value = (n + 1) * QtyDiscountPrice;
                    dataGridView1.SelectedCells[6].Value = Math.Round(((n + 1) * QtyDiscountPrice * storeTaxRate), 2, MidpointRounding.AwayFromZero);

                    displayName = dataGridView1.SelectedCells[1].Value.ToString();

                    if (displayName.Length > 20)
                        displayName = displayName.Substring(0, 19);

                    if (Convert.ToDouble(dataGridView1.SelectedCells[4].Value) > 0)
                    {
                        displayPrice = string.Format("{0:$0.00}", Convert.ToDouble(dataGridView1.SelectedCells[4].Value));
                    }
                    else
                    {
                        displayPrice = string.Format("{0:$0.00}", Convert.ToDouble(dataGridView1.SelectedCells[3].Value));
                    }

                    LineDisply(displayName, displayPrice);
                    Calculation();
                }
            }

            Calculating_Saved_Amount();
            richTxtUpc.Focus();
            richTxtUpc.Select();
        }

        /// <summary>
        /// Handles the Click event of the btnQtyM control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnQtyM_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (Convert.ToString(dataGridView1.SelectedCells[8].Value) == "10" | Convert.ToString(dataGridView1.SelectedCells[8].Value) == "11" | Convert.ToString(dataGridView1.SelectedCells[8].Value) == "12")
                    return;

                if (Convert.ToString(dataGridView1.SelectedCells[8].Value) == "7" & Convert.ToString(dataGridView1.SelectedCells[9].Value) == "5" & Convert.ToString(dataGridView1.SelectedCells[10].Value) == "1")
                    return;

                n = Convert.ToInt16(dataGridView1.SelectedCells[2].Value);

                if (n == 0)
                {
                    return;
                }

                if (n > 1)
                {
                    if (Convert.ToDouble(dataGridView1.SelectedCells[4].Value) == 0)
                    {
                        QtyUnitPrice = Convert.ToDouble(dataGridView1.SelectedCells[3].Value);
                        dataGridView1.SelectedCells[2].Value = n - 1;
                        dataGridView1.SelectedCells[5].Value = (n - 1) * QtyUnitPrice;
                        dataGridView1.SelectedCells[6].Value = Math.Round(((n - 1) * QtyUnitPrice * storeTaxRate), 2, MidpointRounding.AwayFromZero);

                        Display_Item_Price(1);
                        Calculation();
                    }
                    else
                    {
                        QtyDiscountPrice = Convert.ToDouble(dataGridView1.SelectedCells[4].Value);
                        dataGridView1.SelectedCells[2].Value = n - 1;
                        dataGridView1.SelectedCells[5].Value = (n - 1) * QtyDiscountPrice;
                        dataGridView1.SelectedCells[6].Value = Math.Round(((n - 1) * QtyDiscountPrice * storeTaxRate), 2, MidpointRounding.AwayFromZero);

                        Display_Item_Price(1);
                        Calculation();
                    }
                }
            }

            Calculating_Saved_Amount();
            richTxtUpc.Focus();
            richTxtUpc.Select();
        }

        /// <summary>
        /// Handles the Click event of the btnHold control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnHold_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                holdTable.Clear();

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    holdTable.Rows.Add(Convert.ToInt16(dataGridView1.Rows[i].Cells[2].Value), Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value), Convert.ToString(dataGridView1.Rows[i].Cells[7].Value));
                }

                dataGridView4.DataSource = holdTable;

                if (lblMemberCode.Text.Trim().ToString().ToUpper() != "101" | lblType.Text.ToUpper() != "WALK INS")
                {
                    tempPoints = points;
                    tempMemberID = lblMemberCode.Text.Trim().ToString().ToUpper();
                }

                points = 0;

                //holdTable = dt.Copy();
                dt.Clear();
                dataGridView1.DataSource = null;
                lblTotalQty.Text = "0";
                lblSubTotal.Text = "$0.00";
                lblTax.Text = "$0.00";
                lblGrandTotal.Text = "$0.00";

                richTxtUpc.Focus();
                richTxtUpc.Select();

                radioBtnDefault.Checked = true;
                btnHold.Enabled = false;
                btnShowHold.Enabled = true;
            }
            else
            {
                MyMessageBox.ShowBox("NO ITEM", "ERROR");
            }

            LineDisply(openingMSG1, openingMSG2);
            richTxtUpc.Clear();
            richTxtUpc.Select();
            richTxtUpc.Focus();
        }

        /// <summary>
        /// Handles the Click event of the btnShowHold control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnShowHold_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                MyMessageBox.ShowBox("FINISH CURRENT TRANSACTION FIRST", "ERROR");
                return;
            }

            if (lblName.Text.ToUpper() != "WALK INS")
            {
                MyMessageBox.ShowBox("CLEAR CURRENT CUSTOMER INFORMATION", "ERROR");
                return;
            }
            else
            {
                if (tempMemberID != "101")
                {
                    if (tempPoints > 0)
                    {
                        radioBtnMember.Checked = true;
                        points = tempPoints;
                        txtMemberID.Text = tempMemberID;
                        tempMemberID = string.Empty;
                        tempPoints = 0;
                        lblPoints.Text = string.Format("{0:$0.00}", Math.Round(Convert.ToDouble(lblPoints.Text.Substring(1)) - points, 2, MidpointRounding.AwayFromZero));
                    }
                    else
                    {
                        radioBtnMember.Checked = true;
                        txtMemberID.Text = tempMemberID;
                        tempMemberID = string.Empty;
                        tempPoints = 0;
                    }
                }

                for (int i = 0; i < dataGridView4.RowCount; i++)
                {
                    if (Convert.ToString(dataGridView4.Rows[i].Cells[2].Value) == "000000999110")
                    {
                        lblQty.Text = "1";
                        richTxtUpc.Text = Convert.ToString(dataGridView4.Rows[i].Cells[2].Value);
                        btnInput_Click(null, null);
                    }
                    else if (Convert.ToString(dataGridView4.Rows[i].Cells[2].Value) == "000000999101")
                    {
                        lblQty.Text = Convert.ToString(dataGridView4.Rows[i].Cells[0].Value);
                        ItmPrice = Convert.ToString(dataGridView4.Rows[i].Cells[1].Value);
                        richTxtUpc.Text = Convert.ToString(dataGridView4.Rows[i].Cells[2].Value);
                        btnInput_Click(null, null);

                    }
                    else if (Convert.ToString(dataGridView4.Rows[i].Cells[2].Value) == "000000999102")
                    {
                        lblQty.Text = Convert.ToString(dataGridView4.Rows[i].Cells[0].Value);
                        ItmPrice = Convert.ToString(dataGridView4.Rows[i].Cells[1].Value);
                        richTxtUpc.Text = Convert.ToString(dataGridView4.Rows[i].Cells[2].Value);
                        btnInput_Click(null, null);

                    }
                    else if (Convert.ToString(dataGridView4.Rows[i].Cells[2].Value) == "000000999103")
                    {
                        lblQty.Text = Convert.ToString(dataGridView4.Rows[i].Cells[0].Value);
                        ItmPrice = Convert.ToString(dataGridView4.Rows[i].Cells[1].Value);
                        richTxtUpc.Text = Convert.ToString(dataGridView4.Rows[i].Cells[2].Value);
                        btnInput_Click(null, null);

                    }
                    else if (Convert.ToString(dataGridView4.Rows[i].Cells[2].Value) == "000000999104")
                    {
                        lblQty.Text = Convert.ToString(dataGridView4.Rows[i].Cells[0].Value);
                        ItmPrice = Convert.ToString(dataGridView4.Rows[i].Cells[1].Value);
                        richTxtUpc.Text = Convert.ToString(dataGridView4.Rows[i].Cells[2].Value);
                        btnInput_Click(null, null);

                    }
                    else if (Convert.ToString(dataGridView4.Rows[i].Cells[2].Value) == "000000999105")
                    {
                        lblQty.Text = Convert.ToString(dataGridView4.Rows[i].Cells[0].Value);
                        ItmPrice = Convert.ToString(dataGridView4.Rows[i].Cells[1].Value);
                        richTxtUpc.Text = Convert.ToString(dataGridView4.Rows[i].Cells[2].Value);
                        btnInput_Click(null, null);

                    }
                    else if (Convert.ToString(dataGridView4.Rows[i].Cells[2].Value) == "000000999106")
                    {
                        lblQty.Text = Convert.ToString(dataGridView4.Rows[i].Cells[0].Value);
                        ItmPrice = Convert.ToString(dataGridView4.Rows[i].Cells[1].Value);
                        richTxtUpc.Text = Convert.ToString(dataGridView4.Rows[i].Cells[2].Value);
                        btnInput_Click(null, null);

                    }
                    else if (Convert.ToString(dataGridView4.Rows[i].Cells[2].Value) == "000000999107")
                    {
                        lblQty.Text = Convert.ToString(dataGridView4.Rows[i].Cells[0].Value);
                        ItmPrice = Convert.ToString(dataGridView4.Rows[i].Cells[1].Value);
                        richTxtUpc.Text = Convert.ToString(dataGridView4.Rows[i].Cells[2].Value);
                        btnInput_Click(null, null);

                    }
                    else if (Convert.ToString(dataGridView4.Rows[i].Cells[2].Value) == "000000999108")
                    {
                        lblQty.Text = Convert.ToString(dataGridView4.Rows[i].Cells[0].Value);
                        ItmPrice = Convert.ToString(dataGridView4.Rows[i].Cells[1].Value);
                        richTxtUpc.Text = Convert.ToString(dataGridView4.Rows[i].Cells[2].Value);
                        btnInput_Click(null, null);

                    }
                    else
                    {
                        lblQty.Text = Convert.ToString(dataGridView4.Rows[i].Cells[0].Value);
                        richTxtUpc.Text = Convert.ToString(dataGridView4.Rows[i].Cells[2].Value);
                        btnInput_Click(null, null);
                    }
                }

                /*dt.Clear();
                dt = holdTable.Copy();
                dataGridView1.RowTemplate.Height = 40;
                dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                dataGridView1.DataSource = dt;
                //dataGridView1.DataSource = holdTable;
                dataGridView1.Columns[0].HeaderText = "BRAND";
                dataGridView1.Columns[0].Width = 150;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "NAME";
                dataGridView1.Columns[1].Width = 380;
                dataGridView1.Columns[2].HeaderText = "QTY";
                dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[2].DefaultCellStyle.ForeColor = Color.DarkBlue;
                dataGridView1.Columns[2].Width = 60;
                dataGridView1.Columns[3].HeaderText = "RETAIL PRICE";
                dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[3].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].HeaderText = "DISCOUNT PRICE";
                dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[4].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].HeaderText = "YOUR PRICE";
                dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[5].DefaultCellStyle.ForeColor = Color.Red;
                dataGridView1.Columns[5].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[5].Width = 100;
                dataGridView1.Columns[6].HeaderText = "TAX";
                dataGridView1.Columns[6].Width = 90;
                dataGridView1.Columns[6].DefaultCellStyle.Format = "c";

                if (parentForm.employeeID != "ADMIN")
                {
                    dataGridView1.Columns[6].Visible = false;
                    dataGridView1.Columns[7].Visible = false;
                    dataGridView1.Columns[8].Visible = false;
                    dataGridView1.Columns[9].Visible = false;
                    dataGridView1.Columns[10].Visible = false;
                    dataGridView1.Columns[11].Visible = false;
                    dataGridView1.Columns[12].Visible = false;
                    dataGridView1.Columns[13].Visible = false;
                    dataGridView1.Columns[14].Visible = false;
                    dataGridView1.Columns[15].Visible = false;

                    dataGridView1.Columns[17].Visible = false;
                    dataGridView1.Columns[18].Visible = false;
                    dataGridView1.Columns[19].Visible = false;
                    dataGridView1.Columns[20].Visible = false;
                    dataGridView1.Columns[21].Visible = false;
                }

                dataGridView1.Columns[16].HeaderText = "SAVED";
                dataGridView1.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[16].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[16].Width = 85;*/

                Calculation();

                btnHold.Enabled = true;
                btnShowHold.Enabled = false;
                //holdTable.Clear();
            }

            LineDisply(openingMSG1, openingMSG2);
            richTxtUpc.Clear();
            richTxtUpc.Select();
            richTxtUpc.Focus();
        }

        /// <summary>
        /// Handles the Click event of the btnDeleteLine control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnDeleteLine_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                /*for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Selected == true)
                    {
                        displayName = dataGridView1.Rows[i].Cells[1].Value.ToString();

                        if (displayName.Length > 20)
                            displayName = displayName.Substring(0, 19);

                        displayPrice = "-$" + Convert.ToString(dataGridView1.Rows[i].Cells[5].Value);

                        LineDisply(displayName, displayPrice);
                    }
                }*/

                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    if (Convert.ToString(dataGridView1.SelectedCells[7].Value) == pointRedeemBarcode)
                    {
                        double tempCtmPoints = -Convert.ToDouble(dataGridView1.SelectedCells[5].Value);
                        this.dataGridView1.Rows.Remove(item);
                        points = 0;
                        CtmPoint = 0;
                        //txtMemberID.Clear();

                        try
                        {
                            if (lblMemberCode.Text.Trim().ToString().ToUpper() != defaultMemberCode)
                            {
                                BDErrorMsg = false;
                                //txtMemberID.Text = lblMemberCode.Text;

                                lblPoints.Text = string.Format("{0:$0.00}", Math.Round(Convert.ToDouble(lblPoints.Text.Substring(1)) + tempCtmPoints, 2, MidpointRounding.AwayFromZero));
                            }
                        }
                        catch
                        {
                            MyMessageBox.ShowBox("CUSTOMER POINST ERROR", "ERROR");
                            radioBtnDefault.Checked = true;
                            return;
                        }
                    }
                    else if (Convert.ToString(dataGridView1.SelectedCells[7].Value) == giftCardBarcode)
                    {
                        this.dataGridView1.Rows.Remove(item);

                        giftcardRedeem = 0;
                        giftcardCodeDesc = string.Empty;
                        giftcardStoreCode = string.Empty;
                    }
                    else if (Convert.ToString(dataGridView1.SelectedCells[7].Value) == couponBarcode)
                    {
                        this.dataGridView1.Rows.Remove(item);

                        CouponAmt = 0;
                        CouponDesc = string.Empty;
                        CouponMgrID = string.Empty;

                        boolNumSecondVisitCoupon = false;
                        //PTrns = 0;
                        //TTrns = 0;
                    }
                    else
                    {
                        /*DisplayLineItem dli = new DisplayLineItem();
                        dli.name = item.Cells[1].Value.ToString();
                        dli.quantity = item.Cells[2].Value.ToString();
                        dli.price = item.Cells[5].Value.ToString();
                        DisplayOrder.removeDisplayLineItem(dli);
                        UpdateDisplayOrderTotals();
                        cloverConnector.ShowDisplayOrder(DisplayOrder);*/

                        if (Convert.ToBoolean(dataGridView1.SelectedCells[17].Value) == true)
                        {
                            displayName = dataGridView1.SelectedCells[1].Value.ToString();

                            if (displayName.Length > 20)
                                displayName = displayName.Substring(0, 19);

                            displayPrice = "-$" + Convert.ToString(dataGridView1.SelectedCells[5].Value);

                            this.dataGridView1.Rows.Remove(item);

                            LineDisply(displayName, displayPrice);

                            for (int i = 0; i < dataGridView1.RowCount; i++)
                            {
                                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[17].Value) == true)
                                    Compare_MixMatchPrice(Convert.ToInt16(dataGridView1.Rows[i].Cells[18].Value), Convert.ToInt16(dataGridView1.Rows[i].Cells[20].Value), i);
                            }
                        }
                        else
                        {
                            displayName = dataGridView1.SelectedCells[1].Value.ToString();

                            if (displayName.Length > 20)
                                displayName = displayName.Substring(0, 19);

                            displayPrice = "-$" + Convert.ToString(dataGridView1.SelectedCells[5].Value);

                            this.dataGridView1.Rows.Remove(item);

                            LineDisply(displayName, displayPrice);
                        }
                    }
                }

                if (dataGridView1.Rows.Count == 0)
                {
                    //radioBtnDefault.Checked = true;
                    btnDefault_Click(null, null);
                    //points = 0;
                    //CtmPoint = 0;
                    lblQty.Text = "1";
                    lblTotalQty.Text = "0";
                    lblSubTotal.Text = "$0.00";
                    lblTax.Text = "$0.00";
                    lblGrandTotal.Text = "$0.00";

                    LineDisply(openingMSG1, openingMSG2);
                }
                else
                {
                    Calculation();
                    dataGridView1.Rows[dataGridView1.RowCount - 1].Selected = true;
                }
            }
            else if (dataGridView1.Rows.Count == 1)
            {
                if (Convert.ToString(dataGridView1.SelectedCells[7].Value) == pointRedeemBarcode)
                {
                    double tempCtmPoints = -Convert.ToDouble(dataGridView1.SelectedCells[5].Value);
                    points = 0;
                    CtmPoint = 0;
                    //txtMemberID.Clear();

                    try
                    {
                        if (lblMemberCode.Text.Trim().ToString().ToUpper() != defaultMemberCode)
                        {
                            BDErrorMsg = false;
                            //txtMemberID.Text = lblMemberCode.Text;

                            lblPoints.Text = string.Format("{0:$0.00}", Math.Round(Convert.ToDouble(lblPoints.Text.Substring(1)) + tempCtmPoints, 2, MidpointRounding.AwayFromZero));
                        }
                    }
                    catch
                    {
                        MyMessageBox.ShowBox("CUSTOMER POINST ERROR", "ERROR");
                        radioBtnDefault.Checked = true;
                        return;
                    }
                }

                dt.Clear();
                dataGridView1.DataSource = null;

                points = 0;

                giftcardRedeem = 0;
                giftcardCodeDesc = string.Empty;
                giftcardStoreCode = string.Empty;

                CouponAmt = 0;
                CouponDesc = string.Empty;
                CouponMgrID = string.Empty;

                boolNumSecondVisitCoupon = false;
                //PTrns = 0;
                //TTrns = 0;

                cpRedeem = false;
                wp_cpNum = string.Empty;
                wp_cpDescription = string.Empty;
                wp_cpTargetItem = string.Empty;

                smDiscount = false;
                smCashierID = "";

                eDiscount1 = false;
                eCashierID = "";

                lblTotalQty.Text = "0";
                lblSubTotal.Text = "$0.00";
                lblTax.Text = "$0.00";
                lblGrandTotal.Text = "$0.00";

                LineDisply(openingMSG1, openingMSG2);
            }
            else
            {
                MyMessageBox.ShowBox("NO ITEM", "ERROR");
            }

            richTxtUpc.Focus();
            richTxtUpc.Select();
        }

        /// <summary>
        /// Handles the Click event of the btnDeleteAll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnDeleteAll_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (Convert.ToString(dataGridView1.Rows[i].Cells[7].Value) == pointRedeemBarcode)
                    {
                        double tempCtmPoints = -Convert.ToDouble(dataGridView1.SelectedCells[5].Value);
                        points = 0;
                        CtmPoint = 0;

                        try
                        {
                            if (lblMemberCode.Text.Trim().ToString().ToUpper() != defaultMemberCode)
                            {
                                BDErrorMsg = false;
                                //txtMemberID.Text = lblMemberCode.Text;

                                lblPoints.Text = string.Format("{0:$0.00}", Math.Round(Convert.ToDouble(lblPoints.Text.Substring(1)) + tempCtmPoints, 2, MidpointRounding.AwayFromZero));
                            }
                        }
                        catch
                        {
                            MyMessageBox.ShowBox("CUSTOMER POINST ERROR", "ERROR");
                            radioBtnDefault.Checked = true;
                            return;
                        }
                    }
                }

                dt.Clear();
                dataGridView1.DataSource = null;

                lblTotalQty.Text = "0";
                lblSubTotal.Text = "$0.00";
                lblTax.Text = "$0.00";
                lblGrandTotal.Text = "$0.00";

                points = 0;
                //string tempMemberID = txtMemberID.Text;
                //radioBtnDefault.Checked = true;
                //radioBtnMember.Checked = false;
                //txtMemberID.Text = tempMemberID;

                giftcardRedeem = 0;
                giftcardCodeDesc = string.Empty;
                giftcardStoreCode = string.Empty;

                CouponAmt = 0;
                CouponDesc = string.Empty;
                CouponMgrID = string.Empty;

                boolNumSecondVisitCoupon = false;
                //PTrns = 0;
                //TTrns = 0;

                cpRedeem = false;
                wp_cpNum = string.Empty;
                wp_cpDescription = string.Empty;
                wp_cpTargetItem = string.Empty;

                smDiscount = false;
                smCashierID = "";

                eDiscount1 = false;
                eCashierID = "";

                LineDisply(openingMSG1, openingMSG2);

                richTxtUpc.Focus();
                richTxtUpc.Select();
            }
            else
            {
                MyMessageBox.ShowBox("NO ITEM", "ERROR");
            }
        }

        /// <summary>
        /// Handles the Click event of the btnPointsRedeem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnPointsRedeem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                if (points > 0)
                {
                    MyMessageBox.ShowBox("NOT ALLOWED POINTS REDEEMED MORE THAN ONE", "ERROR");
                }
                else
                {
                    if (lblName.Text != defaultMemberName & lblPoints.Text != "")
                    {
                        try
                        {
                            double pt = Convert.ToDouble(lblPoints.Text.Substring(1));

                            if (pt > 0)
                            {
                                PointsRedeem pointsRedeemForm = new PointsRedeem(pt);
                                pointsRedeemForm.parentForm = this;
                                pointsRedeemForm.ShowDialog();
                            }
                            else
                            {
                                MyMessageBox.ShowBox("NO POINT AVAILABLE", "ERROR");
                            }
                        }
                        catch
                        {
                            MyMessageBox.ShowBox("CUSTOMER POINST ERROR", "ERROR");
                            radioBtnDefault.Checked = true;
                            return;
                        }
                    }
                }

                richTxtUpc.Select();
                richTxtUpc.Focus();
            }
            else
            {
                MyMessageBox.ShowBox("NO ITEM", "ERROR");

                richTxtUpc.Select();
                richTxtUpc.Focus();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnManagerTools control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnManagerTools_Click(object sender, EventArgs e)
        {
            ManagerTools managerForm = new ManagerTools(employeeID);
            managerForm.parentForm = this;
            managerForm.ShowDialog();
        }

        /// <summary>
        /// Handles the Click event of the btnNoBarcodeItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnNoBarcodeItem_Click(object sender, EventArgs e)
        {
            if (NoBarcodeButtonAuth == true)
            {
                NoBarcodeItem noBarcodeItemForm = new NoBarcodeItem();
                noBarcodeItemForm.parentForm = this;
                noBarcodeItemForm.ShowDialog();
            }
            else
            {
                Authentication authenticationForm = new Authentication(21);
                authenticationForm.parentForm1 = this;
                authenticationForm.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnJewerly control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnJewerly_Click(object sender, EventArgs e)
        {
            Jewelry jewerlyForm = new Jewelry();
            jewerlyForm.parentform = this;
            jewerlyForm.ShowDialog();
        }

        /// <summary>
        /// Handles the Click event of the btnFindItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnFindItem_Click(object sender, EventArgs e)
        {
            FindItem findItemForm = new FindItem();
            findItemForm.parentForm = this;
            findItemForm.ShowDialog();
        }

        /// <summary>
        /// Handles the Click event of the btnNumberPad control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnNumberPad_Click(object sender, EventArgs e)
        {
            NumberPad numberPadForm = new NumberPad();
            numberPadForm.parentform = this;
            numberPadForm.ShowDialog();
        }

        /// <summary>
        /// Handles the Click event of the btnCustomer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            radioBtnDefault.Checked = true;
            this.Enabled = false;

            CustomerMain customerMainForm = new CustomerMain();
            customerMainForm.parentForm = this;
            customerMainForm.Show();
        }

        /// <summary>
        /// Handles the Click event of the btnClockInOut control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnClockInOut_Click(object sender, EventArgs e)
        {
            MyTimeCard mytimecardForm = new MyTimeCard();
            mytimecardForm.parentForm = this;
            mytimecardForm.ShowDialog();
        }

        /// <summary>
        /// Handles the Click event of the btnClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (cloverConnector != null)
            {
                cloverConnector.ShowWelcomeScreen(); // this may not fire, if the queue is processed before Exit();
            }

            LineDisply(closingMSG1, closingMSG2);
            this.parentForm.Close();
            Application.Exit();
        }

        /// <summary>
        /// Handles the FormClosed event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosedEventArgs"/> instance containing the event data.</param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (cloverConnector != null)
            {
                cloverConnector.ShowWelcomeScreen(); // this may not fire, if the queue is processed before Exit();
            }

            LineDisply(closingMSG1, closingMSG2);
            this.parentForm.Close();
            Application.Exit();
        }

        /// <summary>
        /// Handles the Click event of the richTxtUpc control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void richTxtUpc_Click(object sender, EventArgs e)
        {
            richTxtUpc.SelectAll();
            richTxtUpc.Focus();
        }

        /// <summary>
        /// Handles the KeyDown event of the richTxtUpc control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void richTxtUpc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                richTxtUpc.Text = F1Value;
                btnInput_Click(null, null);
            }
            else if (e.KeyCode == Keys.F2)
            {
                richTxtUpc.Text = F2Value;
                btnInput_Click(null, null);
            }
            else if (e.KeyCode == Keys.F3)
            {
                richTxtUpc.Text = F3Value;
                btnInput_Click(null, null);
            }
            else if (e.KeyCode == Keys.F4)
            {
                richTxtUpc.Text = F4Value;
                btnInput_Click(null, null);
            }
            else if (e.KeyCode == Keys.F5)
            {
                richTxtUpc.Text = F5Value;
                btnInput_Click(null, null);
            }
            else if (e.KeyCode == Keys.F6)
            {
                richTxtUpc.Text = F6Value;
                btnInput_Click(null, null);
            }
            else if (e.KeyCode == Keys.F7)
            {
                richTxtUpc.Text = F7Value;
                btnInput_Click(null, null);
            }
            else if (e.KeyCode == Keys.F8)
            {
                richTxtUpc.Text = F8Value;
                btnInput_Click(null, null);
            }
            else if (e.KeyCode == Keys.F9)
            {
                richTxtUpc.Text = F9Value;
                btnInput_Click(null, null);
            }
            else if (e.KeyCode == Keys.F11)
            {
                richTxtUpc.Text = F11Value;
                btnInput_Click(null, null);
            }
            else if (e.KeyCode == Keys.F12)
            {
                richTxtUpc.Text = F12Value;
                btnInput_Click(null, null);
            }
            //else if (e.KeyCode == Keys.Add)
            //{
            //    btnQtyP_Click(null, null);
            //}
            //else if (e.KeyCode == Keys.Subtract)
            //{
            //    btnQtyM_Click(null, null);
            //}
            else if (e.KeyCode == Keys.Delete)
            {
                btnDeleteLine_Click(null, null);
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the richTxtUpc control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void richTxtUpc_TextChanged(object sender, EventArgs e)
        {
            if (richTxtUpc.Text == "+")
            {
                richTxtUpc.Clear();
            }
            else if (richTxtUpc.Text == "-")
            {
                richTxtUpc.Clear();
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the radioBtnMember control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void radioBtnMember_CheckedChanged(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                if (radioBtnMember.Checked == true)
                {
                    //if (BDErrorMsg == true)
                    //    MyMessageBox.ShowBox("INPUT MEMBER CODE BEFORE TRANSACTION START", "ERROR");

                    BDRestDiscount = false;
                    radioBtnDefault.Checked = true;
                    txtMemberID.Clear();
                    richTxtUpc.Select();
                    richTxtUpc.Focus();
                }
                else
                {
                    if (BDRestDiscount == true)
                    {
                        smCashierID = "";
                        smDiscount = false;

                        eCashierID = "";
                        eDiscount1 = false;

                        txtMemberID.Enabled = false;
                        lblMemberCode.Text = "101";
                        lblName.Text = "WALK INS";
                        lblType.Text = "";
                        lblPoints.Text = "$0.00";
                        txtMemberID.Clear();
                        points = 0;

                        BDQty = 0; BDUnitPrice = 0; BDPrice = 0; BDTax = 0;

                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            if (Convert.ToInt16(dataGridView1.Rows[i].Cells[8].Value) == 10 | Convert.ToInt16(dataGridView1.Rows[i].Cells[8].Value) == 11)
                            {
                                this.dataGridView1.Rows.Remove(dataGridView1.Rows[i]);

                                dataGridView1.Rows[dataGridView1.RowCount - 1].Selected = true;

                                giftcardRedeem = 0;
                                giftcardCodeDesc = string.Empty;
                                giftcardStoreCode = string.Empty;

                                cpRedeem = false;
                                wp_cpNum = string.Empty;
                                wp_cpDescription = string.Empty;
                                wp_cpTargetItem = string.Empty;
                            }
                            else
                            {
                                BDQty = Convert.ToInt16(dataGridView1.Rows[i].Cells[2].Value);
                                BDUnitPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                                BDPrice = BDUnitPrice * BDQty;
                                BDTax = BDPrice * storeTaxRate;
                                dataGridView1.Rows[i].Cells[4].Value = 0.00;
                                dataGridView1.Rows[i].Cells[5].Value = BDPrice;
                                dataGridView1.Rows[i].Cells[6].Value = Math.Round(BDTax, 2, MidpointRounding.AwayFromZero);
                            }
                        }

                        Calculation();
                        Calculating_Saved_Amount();
                        LineDisply(openingMSG1, openingMSG2);
                        richTxtUpc.Focus();
                        richTxtUpc.Select();
                    }
                    else if (BDRestDiscount == false)
                    {
                        smCashierID = "";
                        smDiscount = false;

                        eCashierID = "";
                        eDiscount1 = false;

                        txtMemberID.Enabled = false;
                        lblMemberCode.Text = "101";
                        lblName.Text = "WALK INS";
                        lblType.Text = "";
                        lblPoints.Text = "$0.00";
                        txtMemberID.Clear();
                        points = 0;

                        BDRestDiscount = true;
                    }
                }
            }
            else
            {
                if (radioBtnMember.Checked == true)
                {
                    txtMemberID.Enabled = true;
                    //lblMemberCode.Text = "";
                    //lblName.Text = "";
                    //lblPoints.Text = "";
                    txtMemberID.Select();
                    txtMemberID.Focus();
                }
                else
                {
                    smCashierID = "";
                    smDiscount = false;

                    eCashierID = "";
                    eDiscount1 = false;

                    txtMemberID.Enabled = false;
                    lblMemberCode.Text = "101";
                    lblName.Text = "WALK INS";
                    lblType.Text = "";
                    lblPoints.Text = "$0.00";
                    txtMemberID.Clear();
                    richTxtUpc.Select();
                    richTxtUpc.Focus();
                }
            }

            BDErrorMsg = true;
        }

        /*private void radioBtnDefault_CheckedChanged(object sender, EventArgs e)
        {

        }*/

        /*private void txtMemberID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.RowCount > 0)
                {
                    if (txtMemberID.Text != "")
                    {
                        MyMessageBox.ShowBox("INPUT MEMBER CODE BEFORE TRANSACTION START", "ERROR");
                        txtMemberID.SelectAll();
                        txtMemberID.Focus();
                        return;
                    }
                }

                if (radioBtnDefault.Checked == true)
                {
                    txtMemberID.Clear();
                    txtMemberID.Enabled = false;
                }

                memberID = txtMemberID.Text.Trim().ToString();

                if (memberID.Length == 10)
                {
                    cmd.CommandText = "Get_Customer_Info_ByPhone";
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = txtMemberID.Text.Trim().ToString();
                    SqlParameter CtmCode_Param = cmd.Parameters.Add("@MemberCode", SqlDbType.BigInt);
                    SqlParameter CtmName_Param = cmd.Parameters.Add("@MemberName", SqlDbType.NVarChar, 50);
                    SqlParameter CtmType_Param = cmd.Parameters.Add("@MemberType", SqlDbType.NVarChar, 20);
                    SqlParameter CtmPoint_Param = cmd.Parameters.Add("@MemberPoints", SqlDbType.Money);
                    CtmCode_Param.Direction = ParameterDirection.Output;
                    CtmName_Param.Direction = ParameterDirection.Output;
                    CtmType_Param.Direction = ParameterDirection.Output;
                    CtmPoint_Param.Direction = ParameterDirection.Output;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    if (cmd.Parameters["@MemberPoints"].Value == DBNull.Value)
                    {
                        return;
                    }
                    else
                    {
                        lblMemberCode.Text = Convert.ToString(cmd.Parameters["@MemberCode"].Value);
                        lblName.Text = cmd.Parameters["@MemberName"].Value.ToString().ToUpper();
                        lblType.Text = cmd.Parameters["@MemberType"].Value.ToString().ToUpper();
                        CtmPoint = Convert.ToDouble(cmd.Parameters["@MemberPoints"].Value);
                        lblPoints.Text = string.Format("{0:$0.00}", Math.Round(CtmPoint, 2, MidpointRounding.AwayFromZero));
                    }

                    LineDisply("MEMBER: " + lblMemberCode.Text, "POINTS: " + lblPoints.Text);
                }
                else
                {
                    if (Int64.TryParse(txtMemberID.Text, out memberCodeCheck))
                    {
                        cmd.CommandText = "Get_Customer_Info";
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@MemberCode", SqlDbType.BigInt).Value = memberCodeCheck;
                        SqlParameter CtmName_Param = cmd.Parameters.Add("@MemberName", SqlDbType.NVarChar, 30);
                        SqlParameter CtmType_Param = cmd.Parameters.Add("@MemberType", SqlDbType.NVarChar, 30);
                        SqlParameter CtmPoint_Param = cmd.Parameters.Add("@MemberPoints", SqlDbType.Money);
                        CtmName_Param.Direction = ParameterDirection.Output;
                        CtmType_Param.Direction = ParameterDirection.Output;
                        CtmPoint_Param.Direction = ParameterDirection.Output;

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        if (cmd.Parameters["@MemberPoints"].Value == DBNull.Value)
                        {
                            return;
                        }
                        else
                        {
                            lblMemberCode.Text = txtMemberID.Text.Trim().ToString();
                            lblName.Text = cmd.Parameters["@MemberName"].Value.ToString().ToUpper();
                            lblType.Text = cmd.Parameters["@MemberType"].Value.ToString().ToUpper();
                            CtmPoint = Convert.ToDouble(cmd.Parameters["@MemberPoints"].Value);
                            lblPoints.Text = string.Format("{0:$0.00}", Math.Round(CtmPoint, 2, MidpointRounding.AwayFromZero));
                        }

                        LineDisply("MEMBER: " + lblMemberCode.Text, "POINTS: " + lblPoints.Text);
                    }
                    else
                    {
                    }
                }
            }
            catch
            {
                conn.Close();

                MyMessageBox.ShowBox("DUPLICATED CUSTOMER", "ERROR");
                txtMemberID.SelectAll();
                txtMemberID.Focus();
            }

            if (lblType.Text.ToUpper() == "VVIP STORE MEMBER" | lblType.Text.ToUpper() == "VVIP BEAUTICIAN")
            {
                MyMessageBox.ShowBox("NOTICE!!\nTHIS CUSTOMER IS A VVIP MEMBER", "INFORMATION");
            }
        }*/

        /// <summary>
        /// Handles the TextChanged event of the lblType control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lblType_TextChanged(object sender, EventArgs e)
        {
            if (lblType.Text.ToUpper() != "")
            {
                txtMemberID.Enabled = false;
            }
            else
            {
                txtMemberID.Enabled = true;
            }

            /*if (dataGridView1.RowCount == 0)
            {
                //richTxtUpc.Focus();
                //richTxtUpc.Select();
                //return;
            }
            else
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    CTQty = 0; CTUnitPrice = 0; CTOriginDiscount = 0; CTDiscountPrice = 0;

                    if (Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value) == 0)
                    {
                    }
                    else if (Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) > 0)
                    {
                        //if (lblType.Text.ToUpper() == "BEAUTICIAN" | lblType.Text.ToUpper() == "10% OFF VIP")
                        if (lblType.Text.ToUpper() != "WALK INS")
                        {
                            if (lblType.Text.ToUpper() == MType1)
                            {
                                CTQty = Convert.ToInt16(dataGridView1.Rows[i].Cells[2].Value);
                                CTUnitPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                                CTOriginDiscount = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                                CTDiscountPrice = Math.Round(CTUnitPrice * ((100 - MDisc1) / 100), 2, MidpointRounding.AwayFromZero);

                                if (CTOriginDiscount > CTDiscountPrice)
                                    dataGridView1.Rows[i].Cells[4].Value = CTDiscountPrice;

                                if (CTUnitPrice == CTOriginDiscount)
                                    dataGridView1.Rows[i].Cells[4].Value = CTOriginDiscount;
                            }
                            else if (lblType.Text.ToUpper() == MType2)
                            {
                                CTQty = Convert.ToInt16(dataGridView1.Rows[i].Cells[2].Value);
                                CTUnitPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                                CTOriginDiscount = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                                CTDiscountPrice = Math.Round(CTUnitPrice * ((100 - MDisc2) / 100), 2, MidpointRounding.AwayFromZero);

                                if (CTOriginDiscount > CTDiscountPrice)
                                    dataGridView1.Rows[i].Cells[4].Value = CTDiscountPrice;

                                if (CTUnitPrice == CTOriginDiscount)
                                    dataGridView1.Rows[i].Cells[4].Value = CTOriginDiscount;
                            }
                            else if (lblType.Text.ToUpper() == MType3)
                            {
                                CTQty = Convert.ToInt16(dataGridView1.Rows[i].Cells[2].Value);
                                CTUnitPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                                CTOriginDiscount = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                                CTDiscountPrice = Math.Round(CTUnitPrice * ((100 - MDisc3) / 100), 2, MidpointRounding.AwayFromZero);

                                if (CTOriginDiscount > CTDiscountPrice)
                                    dataGridView1.Rows[i].Cells[4].Value = CTDiscountPrice;

                                if (CTUnitPrice == CTOriginDiscount)
                                    dataGridView1.Rows[i].Cells[4].Value = CTOriginDiscount;
                            }
                            else if (lblType.Text.ToUpper() == MType4)
                            {
                                CTQty = Convert.ToInt16(dataGridView1.Rows[i].Cells[2].Value);
                                CTUnitPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                                CTOriginDiscount = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                                CTDiscountPrice = Math.Round(CTUnitPrice * ((100 - MDisc4) / 100), 2, MidpointRounding.AwayFromZero);

                                if (CTOriginDiscount > CTDiscountPrice)
                                    dataGridView1.Rows[i].Cells[4].Value = CTDiscountPrice;

                                if (CTUnitPrice == CTOriginDiscount)
                                    dataGridView1.Rows[i].Cells[4].Value = CTOriginDiscount;
                            }

                            //CTQty = Convert.ToInt16(dataGridView1.Rows[i].Cells[2].Value);
                            //CTUnitPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                            //CTOriginDiscount = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                            //CTDiscountPrice = Math.Round(CTUnitPrice * 0.9, 2);

                            //if (CTOriginDiscount > CTDiscountPrice)
                            //    dataGridView1.Rows[i].Cells[4].Value = CTDiscountPrice;
                        
                            //if (CTUnitPrice == CTOriginDiscount)
                            //    dataGridView1.Rows[i].Cells[4].Value = CTOriginDiscount;

                            Price_Comparing(i);
                        }
                    }
                    else if (Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) == 0 & Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value) > 0)
                    {
                        //if (lblType.Text.ToUpper() == "BEAUTICIAN" | lblType.Text.ToUpper() == "10% OFF VIP")
                        if (lblType.Text.ToUpper() != "WALK INS")
                        {
                            if (lblType.Text.ToUpper() == MType1)
                            {
                                CTQty = Convert.ToInt16(dataGridView1.Rows[i].Cells[2].Value);
                                CTUnitPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                                CTDiscountPrice = Math.Round(CTUnitPrice * ((100 - MDisc1) / 100), 2, MidpointRounding.AwayFromZero);
                                dataGridView1.Rows[i].Cells[4].Value = CTDiscountPrice;
                            }
                            else if (lblType.Text.ToUpper() == MType2)
                            {
                                CTQty = Convert.ToInt16(dataGridView1.Rows[i].Cells[2].Value);
                                CTUnitPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                                CTDiscountPrice = Math.Round(CTUnitPrice * ((100 - MDisc2) / 100), 2, MidpointRounding.AwayFromZero);
                                dataGridView1.Rows[i].Cells[4].Value = CTDiscountPrice;
                            }
                            else if (lblType.Text.ToUpper() == MType3)
                            {
                                CTQty = Convert.ToInt16(dataGridView1.Rows[i].Cells[2].Value);
                                CTUnitPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                                CTDiscountPrice = Math.Round(CTUnitPrice * ((100 - MDisc3) / 100), 2, MidpointRounding.AwayFromZero);
                                dataGridView1.Rows[i].Cells[4].Value = CTDiscountPrice;
                            }
                            else if (lblType.Text.ToUpper() == MType4)
                            {
                                CTQty = Convert.ToInt16(dataGridView1.Rows[i].Cells[2].Value);
                                CTUnitPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                                CTDiscountPrice = Math.Round(CTUnitPrice * ((100 - MDisc4) / 100), 2, MidpointRounding.AwayFromZero);
                                dataGridView1.Rows[i].Cells[4].Value = CTDiscountPrice;
                            }

                            //CTQty = Convert.ToInt16(dataGridView1.Rows[i].Cells[2].Value);
                            //CTUnitPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                            //CTDiscountPrice = Math.Round(CTUnitPrice * 0.9, 2);
                            //dataGridView1.Rows[i].Cells[4].Value = CTDiscountPrice;

                            Price_Comparing(i);
                        }
                    }
                }

                Calculation();
                Calculating_Saved_Amount();
            }*/

            richTxtUpc.Focus();
            richTxtUpc.Select();
        }

        /// <summary>
        /// Handles the Click event of the dataGridView1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                Display_Item_Price(0);
            }

            //richTxtUpc.Select();
            //richTxtUpc.Focus();
        }

        /// <summary>
        /// Handles the Click event of the lblSubTotalTitle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lblSubTotalTitle_Click(object sender, EventArgs e)
        {
            LineDisply("SUBTOTAL", lblSubTotal.Text);
        }

        /// <summary>
        /// Handles the Click event of the lblTitleGrandTotal control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lblTitleGrandTotal_Click(object sender, EventArgs e)
        {
            if (cashRegisterNum == "REG99")
                return;

            sGrandTotal = lblGrandTotal.Text.Trim().ToString();

            if (dataGridView1.RowCount == 0)
            {
                MyMessageBox.ShowBox("NO ITEM", "ERROR");
                return;
            }
            else
            {
                if (lblGrandTotal.Text.Substring(0, 1) == "-")
                {
                    MyMessageBox.ShowBox("THIS AMOUNT IS NOT PAYABLE", "ERROR");
                    return;
                }
                else
                {
                    if(PTrns==1 & TTrns==1)
                    {
                        if (boolNumSecondVisitCoupon == true)
                        {
                            if (lblMemberCode.Text == defaultMemberCode | lblMemberCode.Text == "0")
                            {
                                LineDisply("GRAND TOTAL", lblGrandTotal.Text);

                                this.Enabled = false;

                                PaymentMethods paymentMethodsForm = new PaymentMethods(sGrandTotal, 0, points);
                                paymentMethodsForm.parentForm = this;
                                paymentMethodsForm.ShowDialog();
                            }
                            else
                            {
                                LineDisply("GRAND TOTAL", lblGrandTotal.Text);

                                this.Enabled = false;

                                PaymentMethods paymentMethodsForm = new PaymentMethods(sGrandTotal, 1, points);
                                paymentMethodsForm.parentForm = this;
                                paymentMethodsForm.ShowDialog();
                            }
                        }
                        else
                        {
                            DialogResult MyDialogResult;
                            MyDialogResult = MessageBox.Show(this, "THIS TRANSACTION WILL BE MEMBER'S SECOND VISIT.\n\n" + "DO YOU WANT TO APPLY $5 COUPON NOW?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (MyDialogResult == DialogResult.No)
                            {
                                if (lblMemberCode.Text == defaultMemberCode | lblMemberCode.Text == "0")
                                {
                                    LineDisply("GRAND TOTAL", lblGrandTotal.Text);

                                    this.Enabled = false;

                                    PaymentMethods paymentMethodsForm = new PaymentMethods(sGrandTotal, 0, points);
                                    paymentMethodsForm.parentForm = this;
                                    paymentMethodsForm.ShowDialog();
                                }
                                else
                                {
                                    LineDisply("GRAND TOTAL", lblGrandTotal.Text);

                                    this.Enabled = false;

                                    PaymentMethods paymentMethodsForm = new PaymentMethods(sGrandTotal, 1, points);
                                    paymentMethodsForm.parentForm = this;
                                    paymentMethodsForm.ShowDialog();
                                }
                            }
                            else
                            {
                                Authentication authenticationForm = new Authentication(28);
                                authenticationForm.parentForm1 = this;
                                authenticationForm.ShowDialog();
                            }
                        }
                    }
                    else
                    {
                        if (lblMemberCode.Text == defaultMemberCode | lblMemberCode.Text == "0")
                        {
                            LineDisply("GRAND TOTAL", lblGrandTotal.Text);

                            this.Enabled = false;

                            PaymentMethods paymentMethodsForm = new PaymentMethods(sGrandTotal, 0, points);
                            paymentMethodsForm.parentForm = this;
                            paymentMethodsForm.ShowDialog();
                        }
                        else
                        {
                            LineDisply("GRAND TOTAL", lblGrandTotal.Text);

                            this.Enabled = false;

                            PaymentMethods paymentMethodsForm = new PaymentMethods(sGrandTotal, 1, points);
                            paymentMethodsForm.parentForm = this;
                            paymentMethodsForm.ShowDialog();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks the promotion active.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Check_Promotion_Active()
        {
            SqlCommand cmd_Check_Promotion_Active = new SqlCommand("Check_Promotion_Active", conn);
            cmd_Check_Promotion_Active.CommandType = CommandType.StoredProcedure;
            cmd_Check_Promotion_Active.Parameters.Add("@Today", SqlDbType.NVarChar).Value = today;
            SqlParameter CheckNum_Param = cmd_Check_Promotion_Active.Parameters.Add("@CheckNum", SqlDbType.Int);
            CheckNum_Param.Direction = ParameterDirection.Output;

            conn.Open();
            cmd_Check_Promotion_Active.ExecuteNonQuery();
            conn.Close();

            checkNum = Convert.ToInt16(cmd_Check_Promotion_Active.Parameters["@CheckNum"].Value);

            if (checkNum > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Counts the upc.
        /// </summary>
        /// <param name="sp">The sp.</param>
        /// <param name="upc">The upc.</param>
        /// <returns>System.Int32.</returns>
        private int CountUpc(string sp, string upc)
        {
            c = 0;

            countUpc.CommandText = sp;
            countUpc.Connection = conn;
            countUpc.CommandType = CommandType.StoredProcedure;
            countUpc.Parameters.Clear();
            countUpc.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = upc;

            conn.Open();
            SqlDataReader reader = countUpc.ExecuteReader();
            if (reader.Read())
            {
                cnt = reader["Num"].ToString();
                c = Convert.ToInt16(cnt);
            }
            conn.Close();

            return c;
        }

        /// <summary>
        /// Binds the data grid view.
        /// </summary>
        /// <param name="sp">The sp.</param>
        /// <param name="qty">The qty.</param>
        /// <param name="upc">The upc.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool BindDataGridView(string sp, string qty, string upc)
        {
            dtRowCount_P = dt.Rows.Count;

            cmd.CommandText = sp;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = qty;
            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = upc;
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            conn.Open();
            adapter.Fill(dt);
            conn.Close();

            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "BRAND";
            dataGridView1.Columns[0].Width = 140;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[1].HeaderText = "NAME";
            dataGridView1.Columns[1].Width = 360;
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[2].HeaderText = "QTY";
            dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[2].DefaultCellStyle.ForeColor = Color.DarkBlue;
            dataGridView1.Columns[2].Width = 40;
            dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[3].HeaderText = "REGULAR PRICE";
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[3].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[3].Width = 90;
            dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[4].HeaderText = "DISCOUNTED PRICE";
            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[4].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[4].Width = 90;
            dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[5].HeaderText = "YOUR PRICE";
            dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].DefaultCellStyle.ForeColor = Color.Red;
            dataGridView1.Columns[5].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[5].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[5].Width = 90;
            dataGridView1.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[6].HeaderText = "TAX";
            dataGridView1.Columns[6].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[6].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[6].Width = 90;
            dataGridView1.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

            if (parentForm.employeeID != "ADMIN")
            {
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = true;
                dataGridView1.Columns[13].HeaderText = "SZ";
                dataGridView1.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[13].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[13].Width = 40;
                dataGridView1.Columns[14].Visible = true;
                dataGridView1.Columns[14].HeaderText = "CL";
                dataGridView1.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[14].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[14].Width = 40;
                dataGridView1.Columns[15].Visible = false;

                dataGridView1.Columns[17].Visible = false;
                dataGridView1.Columns[18].Visible = false;
                dataGridView1.Columns[19].Visible = false;
                dataGridView1.Columns[20].Visible = false;
                dataGridView1.Columns[21].Visible = false;
            }

            dataGridView1.Columns[16].HeaderText = "SAVED";
            dataGridView1.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[16].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[16].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[16].Width = 85;
            dataGridView1.Columns[16].SortMode = DataGridViewColumnSortMode.NotSortable;

            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Selected = true;
            }

            dtRowCount_N = dt.Rows.Count;
            if (dtRowCount_N == dtRowCount_P)
            {
                dtRowCount_P = 0;
                dtRowCount_N = 0;
                return false;
            }
            else
            {
                dtRowCount_P = 0;
                dtRowCount_N = 0;
                richTxtUpc.Clear();
                return true;
            }
        }

        /// <summary>
        /// Binds the data grid view.
        /// </summary>
        /// <param name="sp">The sp.</param>
        /// <param name="qty">The qty.</param>
        /// <param name="upc">The upc.</param>
        /// <param name="prc">The PRC.</param>
        public void BindDataGridView(string sp, string qty, string upc, double prc)
        {
            cmd.CommandText = sp;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = qty;
            cmd.Parameters.Add("@ItmPrc1", SqlDbType.Money).Value = prc;
            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = upc;
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            conn.Open();
            adapter.Fill(dt);
            conn.Close();

            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "BRAND";
            dataGridView1.Columns[0].Width = 140;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[1].HeaderText = "NAME";
            dataGridView1.Columns[1].Width = 360;
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[2].HeaderText = "QTY";
            dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[2].DefaultCellStyle.ForeColor = Color.DarkBlue;
            dataGridView1.Columns[2].Width = 40;
            dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[3].HeaderText = "REGULAR PRICE";
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[3].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[3].Width = 90;
            dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[4].HeaderText = "DISCOUNTED PRICE";
            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[4].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[4].Width = 90;
            dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[5].HeaderText = "YOUR PRICE";
            dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].DefaultCellStyle.ForeColor = Color.Red;
            dataGridView1.Columns[5].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[5].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[5].Width = 90;
            dataGridView1.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[6].HeaderText = "TAX";
            dataGridView1.Columns[6].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[6].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[6].Width = 90;
            dataGridView1.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

            if (parentForm.employeeID != "ADMIN")
            {
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = true;
                dataGridView1.Columns[13].HeaderText = "SZ";
                dataGridView1.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[13].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[13].Width = 40;
                dataGridView1.Columns[14].Visible = true;
                dataGridView1.Columns[14].HeaderText = "CL";
                dataGridView1.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[14].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[14].Width = 40;
                dataGridView1.Columns[15].Visible = false;

                dataGridView1.Columns[17].Visible = false;
                dataGridView1.Columns[18].Visible = false;
                dataGridView1.Columns[19].Visible = false;
                dataGridView1.Columns[20].Visible = false;
                dataGridView1.Columns[21].Visible = false;
            }

            dataGridView1.Columns[16].HeaderText = "SAVED";
            dataGridView1.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[16].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[16].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[16].Width = 85;
            dataGridView1.Columns[16].SortMode = DataGridViewColumnSortMode.NotSortable;

            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Selected = true;
            }

            richTxtUpc.Clear();
        }

        /// <summary>
        /// Binds the data grid view.
        /// </summary>
        /// <param name="sp">The sp.</param>
        /// <param name="qty">The qty.</param>
        /// <param name="brand">The brand.</param>
        /// <param name="name">The name.</param>
        /// <param name="size">The size.</param>
        /// <param name="color">The color.</param>
        /// <param name="upc">The upc.</param>
        public void BindDataGridView(string sp, string qty, string brand, string name, string size, string color, string upc)
        {
            cmd.CommandText = sp;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = lblQty.Text;
            cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = brand;
            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = name;
            cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = size;
            cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = color;
            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = upc;
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            conn.Open();
            adapter.Fill(dt);
            conn.Close();

            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "BRAND";
            dataGridView1.Columns[0].Width = 140;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[1].HeaderText = "NAME";
            dataGridView1.Columns[1].Width = 360;
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[2].HeaderText = "QTY";
            dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[2].DefaultCellStyle.ForeColor = Color.DarkBlue;
            dataGridView1.Columns[2].Width = 40;
            dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[3].HeaderText = "REGULAR PRICE";
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[3].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[3].Width = 90;
            dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[4].HeaderText = "DISCOUNTED PRICE";
            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[4].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[4].Width = 90;
            dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[5].HeaderText = "YOUR PRICE";
            dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].DefaultCellStyle.ForeColor = Color.Red;
            dataGridView1.Columns[5].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[5].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[5].Width = 90;
            dataGridView1.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[6].HeaderText = "TAX";
            dataGridView1.Columns[6].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[6].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[6].Width = 90;
            dataGridView1.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

            if (parentForm.employeeID != "ADMIN")
            {
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = true;
                dataGridView1.Columns[13].HeaderText = "SZ";
                dataGridView1.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[13].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[13].Width = 40;
                dataGridView1.Columns[14].Visible = true;
                dataGridView1.Columns[14].HeaderText = "CL";
                dataGridView1.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[14].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[14].Width = 40;
                dataGridView1.Columns[15].Visible = false;

                dataGridView1.Columns[17].Visible = false;
                dataGridView1.Columns[18].Visible = false;
                dataGridView1.Columns[19].Visible = false;
                dataGridView1.Columns[20].Visible = false;
                dataGridView1.Columns[21].Visible = false;
            }

            dataGridView1.Columns[16].HeaderText = "SAVED";
            dataGridView1.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[16].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[16].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[16].Width = 85;
            dataGridView1.Columns[16].SortMode = DataGridViewColumnSortMode.NotSortable;

            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Selected = true;
            }

            richTxtUpc.Clear();
        }

        /// <summary>
        /// Binds the data grid view.
        /// </summary>
        /// <param name="sp">The sp.</param>
        /// <param name="upc">The upc.</param>
        /// <param name="pts">The PTS.</param>
        public void BindDataGridView(string sp, string upc, double pts)
        {
            cmd.CommandText = sp;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@Points", SqlDbType.Money).Value = pts;
            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = upc;
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            conn.Open();
            adapter.Fill(dt);
            conn.Close();

            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "BRAND";
            dataGridView1.Columns[0].Width = 140;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[1].HeaderText = "NAME";
            dataGridView1.Columns[1].Width = 360;
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[2].HeaderText = "QTY";
            dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[2].DefaultCellStyle.ForeColor = Color.DarkBlue;
            dataGridView1.Columns[2].Width = 40;
            dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[3].HeaderText = "REGULAR PRICE";
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[3].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[3].Width = 90;
            dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[4].HeaderText = "DISCOUNTED PRICE";
            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[4].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[4].Width = 90;
            dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[5].HeaderText = "YOUR PRICE";
            dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].DefaultCellStyle.ForeColor = Color.Red;
            dataGridView1.Columns[5].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[5].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[5].Width = 90;
            dataGridView1.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[6].HeaderText = "TAX";
            dataGridView1.Columns[6].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[6].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[6].Width = 90;
            dataGridView1.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

            if (parentForm.employeeID != "ADMIN")
            {
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = true;
                dataGridView1.Columns[13].HeaderText = "SZ";
                dataGridView1.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[13].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[13].Width = 40;
                dataGridView1.Columns[14].Visible = true;
                dataGridView1.Columns[14].HeaderText = "CL";
                dataGridView1.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[14].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[14].Width = 40;
                dataGridView1.Columns[15].Visible = false;

                dataGridView1.Columns[17].Visible = false;
                dataGridView1.Columns[18].Visible = false;
                dataGridView1.Columns[19].Visible = false;
                dataGridView1.Columns[20].Visible = false;
                dataGridView1.Columns[21].Visible = false;
            }

            dataGridView1.Columns[16].HeaderText = "SAVED";
            dataGridView1.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[16].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[16].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[16].Width = 85;
            dataGridView1.Columns[16].SortMode = DataGridViewColumnSortMode.NotSortable;

            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Selected = true;
            }

            richTxtUpc.Clear();
        }

        /// <summary>
        /// Binds the data grid view.
        /// </summary>
        /// <param name="sp">The sp.</param>
        /// <param name="upc">The upc.</param>
        /// <param name="pts">The PTS.</param>
        /// <param name="desc">The desc.</param>
        public void BindDataGridView(string sp, string upc, double pts, string desc)
        {
            cmd.CommandText = sp;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@Amount", SqlDbType.Money).Value = pts;
            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = upc;
            cmd.Parameters.Add("@Desc", SqlDbType.NVarChar).Value = desc;
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            conn.Open();
            adapter.Fill(dt);
            conn.Close();

            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "BRAND";
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[1].HeaderText = "NAME";
            dataGridView1.Columns[1].Width = 380;
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[2].HeaderText = "QTY";
            dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[2].DefaultCellStyle.ForeColor = Color.DarkBlue;
            dataGridView1.Columns[2].Width = 60;
            dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[3].HeaderText = "REGULAR PRICE";
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[3].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[4].HeaderText = "DISCOUNTED PRICE";
            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].DefaultCellStyle.FormatProvider = nfi; ;
            dataGridView1.Columns[4].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[5].HeaderText = "YOUR PRICE";
            dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].DefaultCellStyle.ForeColor = Color.Red;
            dataGridView1.Columns[5].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[5].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[6].HeaderText = "TAX";
            dataGridView1.Columns[6].Width = 90;
            dataGridView1.Columns[6].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[6].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

            if (parentForm.employeeID != "ADMIN")
            {
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = true;
                dataGridView1.Columns[14].Visible = true;
                dataGridView1.Columns[15].Visible = false;

                dataGridView1.Columns[17].Visible = false;
                dataGridView1.Columns[18].Visible = false;
                dataGridView1.Columns[19].Visible = false;
                dataGridView1.Columns[20].Visible = false;
                dataGridView1.Columns[21].Visible = false;
            }

            dataGridView1.Columns[16].HeaderText = "SAVED";
            dataGridView1.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[16].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[16].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[16].Width = 85;
            dataGridView1.Columns[16].SortMode = DataGridViewColumnSortMode.NotSortable;

            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Selected = true;
            }

            richTxtUpc.Clear();
        }

        /// <summary>
        /// Binds the data grid view.
        /// </summary>
        /// <param name="sp">The sp.</param>
        /// <param name="upc">The upc.</param>
        /// <param name="num">The number.</param>
        /// <param name="desc">The desc.</param>
        public void BindDataGridView(string sp, string upc, string num, string desc)
        {
            cmd.CommandText = sp;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = upc;
            cmd.Parameters.Add("@Desc", SqlDbType.NVarChar).Value = desc;
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            conn.Open();
            adapter.Fill(dt);
            conn.Close();

            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "BRAND";
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[1].HeaderText = "NAME";
            dataGridView1.Columns[1].Width = 380;
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[2].HeaderText = "QTY";
            dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[2].DefaultCellStyle.ForeColor = Color.DarkBlue;
            dataGridView1.Columns[2].Width = 60;
            dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[3].HeaderText = "REGULAR PRICE";
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[3].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[4].HeaderText = "DISCOUNTED PRICE";
            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].DefaultCellStyle.FormatProvider = nfi; ;
            dataGridView1.Columns[4].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[5].HeaderText = "YOUR PRICE";
            dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].DefaultCellStyle.ForeColor = Color.Red;
            dataGridView1.Columns[5].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[5].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[6].HeaderText = "TAX";
            dataGridView1.Columns[6].Width = 90;
            dataGridView1.Columns[6].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[6].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

            if (parentForm.employeeID != "ADMIN")
            {
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = true;
                dataGridView1.Columns[14].Visible = true;
                dataGridView1.Columns[15].Visible = false;

                dataGridView1.Columns[17].Visible = false;
                dataGridView1.Columns[18].Visible = false;
                dataGridView1.Columns[19].Visible = false;
                dataGridView1.Columns[20].Visible = false;
                dataGridView1.Columns[21].Visible = false;
            }

            dataGridView1.Columns[16].HeaderText = "SAVED";
            dataGridView1.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[16].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[16].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[16].Width = 85;
            dataGridView1.Columns[16].SortMode = DataGridViewColumnSortMode.NotSortable;

            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Selected = true;
            }

            richTxtUpc.Clear();
        }

        /// <summary>
        /// Prices the comparing.
        /// </summary>
        /// <param name="i">The i.</param>
        void Price_Comparing(int i)
        {
            if (Convert.ToString(dataGridView1.Rows[i].Cells[2].Value) == "POINTS REDEEMED" | Convert.ToInt16(dataGridView1.Rows[i].Cells[8].Value) == 10)
                return;

            PCSalePrice = 0; PCStylistPrice = 0; PCRegularPrice = 0; PCDiscountPrice = 0; q = 0; PCPrice = 0; PCTax = 0;

            if (promotionActive == true)
            {
                q = Convert.ToInt16(dataGridView1.Rows[i].Cells[2].Value);
                PCRegularPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                PCDiscountPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                PCStylistPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[12].Value);
                PCSalePrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[19].Value);

                PCMixMatch = Convert.ToBoolean(dataGridView1.Rows[i].Cells[17].Value);
                PCMixMatchVal = Convert.ToInt16(dataGridView1.Rows[i].Cells[18].Value);
                PCMixMatchQty = Convert.ToUInt16(dataGridView1.Rows[i].Cells[20].Value);

                //if (lblType.Text.ToUpper() == "BEAUTICIAN" | lblType.Text.ToUpper() == "10% OFF VIP")
                if (lblType.Text.ToUpper() == MType2 | lblType.Text.ToUpper() == MType3 | lblType.Text.ToUpper() == MType4 | lblType.Text.ToUpper() == MType5)
                {
                    if (PCMixMatch == true)
                    {
                        if (PCMixMatchVal == 0)
                        {
                            PCCheckMMVal = Check_MixMatchVal(i, PCMixMatchVal, PCMixMatchQty);

                            if (PCCheckMMVal == true)
                            {
                                if (PCDiscountPrice == 0 & PCStylistPrice == 0)
                                {
                                    dataGridView1.Rows[i].Cells[4].Value = PCSalePrice;

                                    PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * q;
                                    PCTax = PCPrice * storeTaxRate;
                                    dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                                    dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                                }
                                else if (PCDiscountPrice == 0 & PCStylistPrice > 0)
                                {
                                    dataGridView1.Rows[i].Cells[4].Value = Math.Min(PCStylistPrice, PCSalePrice);

                                    PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * q;
                                    PCTax = PCPrice * storeTaxRate;
                                    dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                                    dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                                }
                                else if (PCDiscountPrice > 0 & PCStylistPrice == 0)
                                {
                                    dataGridView1.Rows[i].Cells[4].Value = Math.Min(PCDiscountPrice, PCSalePrice);

                                    PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * q;
                                    PCTax = PCPrice * storeTaxRate;
                                    dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                                    dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                                }
                                else
                                {
                                    dataGridView1.Rows[i].Cells[4].Value = Math.Min(PCDiscountPrice, Math.Min(PCStylistPrice, PCSalePrice));

                                    PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * q;
                                    PCTax = PCPrice * storeTaxRate;
                                    dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                                    dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                                }
                            }
                            else
                            {
                                if (PCDiscountPrice == 0)
                                {
                                    PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value) * q;
                                    PCTax = PCPrice * storeTaxRate;
                                    dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                                    dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                                }
                                else
                                {
                                    PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * q;
                                    PCTax = PCPrice * storeTaxRate;
                                    dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                                    dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                                }
                            }
                        }
                        else if (PCMixMatchVal >= 1 & PCMixMatchVal <= 10)
                        {
                            if (PCDiscountPrice > 0)
                            {
                                if (Convert.ToInt16(dataGridView1.Rows[i].Cells[21].Value) == 0)
                                {
                                    PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * q;
                                    PCTax = PCPrice * storeTaxRate;
                                    dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                                    dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                                }
                                else if (Convert.ToInt16(dataGridView1.Rows[i].Cells[21].Value) == 1)
                                {
                                    dataGridView1.Rows[i].Cells[4].Value = PCSalePrice;

                                    PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * q;
                                    PCTax = PCPrice * storeTaxRate;
                                    dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                                    dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                                }
                            }
                            else
                            {
                                if (Convert.ToInt16(dataGridView1.Rows[i].Cells[21].Value) == 0)
                                {
                                    PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value) * q;
                                    PCTax = PCPrice * storeTaxRate;
                                    dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                                    dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                                }
                                else if (Convert.ToInt16(dataGridView1.Rows[i].Cells[21].Value) == 1)
                                {
                                    dataGridView1.Rows[i].Cells[4].Value = PCSalePrice;

                                    PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * q;
                                    PCTax = PCPrice * storeTaxRate;
                                    dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                                    dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                                }
                            }
                        }
                        else if (PCMixMatchVal > 10)
                        {
                            if (PCDiscountPrice == 0 & PCStylistPrice == 0)
                            {
                                PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value) * q;
                                PCTax = PCPrice * storeTaxRate;
                                dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                                dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                            }
                            else if (PCDiscountPrice == 0 & PCStylistPrice > 0)
                            {
                                dataGridView1.Rows[i].Cells[4].Value = PCStylistPrice;

                                PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * q;
                                PCTax = PCPrice * storeTaxRate;
                                dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                                dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                            }
                            else if (PCDiscountPrice > 0 & PCStylistPrice == 0)
                            {
                                dataGridView1.Rows[i].Cells[4].Value = PCDiscountPrice;

                                PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * q;
                                PCTax = PCPrice * storeTaxRate;
                                dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                                dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                            }
                            else
                            {
                                dataGridView1.Rows[i].Cells[4].Value = Math.Min(PCDiscountPrice, PCStylistPrice);

                                PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * q;
                                PCTax = PCPrice * storeTaxRate;
                                dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                                dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                            }
                        }
                    }
                    else
                    {
                        if (PCSalePrice > 0)
                        {
                            if (PCDiscountPrice == 0 & PCStylistPrice == 0)
                            {
                                dataGridView1.Rows[i].Cells[4].Value = PCSalePrice;

                                PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * q;
                                PCTax = PCPrice * storeTaxRate;
                                dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                                dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                            }
                            else if (PCDiscountPrice == 0 & PCStylistPrice > 0)
                            {
                                dataGridView1.Rows[i].Cells[4].Value = Math.Min(PCStylistPrice, PCSalePrice);

                                PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * q;
                                PCTax = PCPrice * storeTaxRate;
                                dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                                dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                            }
                            else if (PCDiscountPrice > 0 & PCStylistPrice == 0)
                            {
                                dataGridView1.Rows[i].Cells[4].Value = Math.Min(PCDiscountPrice, PCSalePrice);

                                PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * q;
                                PCTax = PCPrice * storeTaxRate;
                                dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                                dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                            }
                            else
                            {
                                dataGridView1.Rows[i].Cells[4].Value = Math.Min(PCDiscountPrice, Math.Min(PCStylistPrice, PCSalePrice));

                                PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * q;
                                PCTax = PCPrice * storeTaxRate;
                                dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                                dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                            }
                        }
                        else
                        {
                            if (PCDiscountPrice == 0 & PCStylistPrice > 0)
                            {
                                dataGridView1.Rows[i].Cells[4].Value = PCStylistPrice;

                                PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * q;
                                PCTax = PCPrice * storeTaxRate;
                                dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                                dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                            }
                            else if (PCDiscountPrice > 0 & PCStylistPrice == 0)
                            {
                                dataGridView1.Rows[i].Cells[4].Value = PCDiscountPrice;

                                PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * q;
                                PCTax = PCPrice * storeTaxRate;
                                dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                                dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                            }
                            else if (PCDiscountPrice > 0 & PCStylistPrice > 0)
                            {
                                dataGridView1.Rows[i].Cells[4].Value = Math.Min(PCDiscountPrice, PCStylistPrice);

                                PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * q;
                                PCTax = PCPrice * storeTaxRate;
                                dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                                dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                            }
                            else
                            {
                                PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value) * q;
                                PCTax = PCPrice * storeTaxRate;
                                dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                                dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                            }
                        }
                    }
                }
                else
                {
                    if (PCMixMatch == true)
                    {
                        if (PCMixMatchVal == 0)
                        {
                            PCCheckMMVal = Check_MixMatchVal(i, PCMixMatchVal, PCMixMatchQty);

                            if (PCCheckMMVal == true)
                            {
                                if (PCDiscountPrice == 0)
                                {
                                    dataGridView1.Rows[i].Cells[4].Value = PCSalePrice;

                                    PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * q;
                                    PCTax = PCPrice * storeTaxRate;
                                    dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                                    dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                                }
                                else
                                {
                                    dataGridView1.Rows[i].Cells[4].Value = Math.Min(PCDiscountPrice, PCSalePrice);

                                    PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * q;
                                    PCTax = PCPrice * storeTaxRate;
                                    dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                                    dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                                }
                            }
                            else
                            {
                                PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value) * q;
                                PCTax = PCPrice * storeTaxRate;
                                dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                                dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                            }
                        }
                        else if (PCMixMatchVal >= 1 & PCMixMatchVal <= 10)
                        {
                            if (Convert.ToInt16(dataGridView1.Rows[i].Cells[21].Value) == 0)
                            {
                                PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value) * q;
                                PCTax = PCPrice * storeTaxRate;
                                dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                                dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                            }
                            else if (Convert.ToInt16(dataGridView1.Rows[i].Cells[21].Value) == 1)
                            {
                                dataGridView1.Rows[i].Cells[4].Value = PCSalePrice;

                                PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * q;
                                PCTax = PCPrice * storeTaxRate;
                                dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                                dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                            }
                        }
                        else if (PCMixMatchVal > 10)
                        {
                            if (PCDiscountPrice == 0)
                            {
                                PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value) * q;
                                PCTax = PCPrice * storeTaxRate;
                                dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                                dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                            }
                            else
                            {
                                dataGridView1.Rows[i].Cells[4].Value = PCDiscountPrice;

                                PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * q;
                                PCTax = PCPrice * storeTaxRate;
                                dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                                dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                            }
                        }
                    }
                    else
                    {
                        if (PCSalePrice > 0)
                        {
                            if (PCDiscountPrice == 0)
                            {
                                dataGridView1.Rows[i].Cells[4].Value = PCSalePrice;

                                PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * q;
                                PCTax = PCPrice * storeTaxRate;
                                dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                                dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                            }
                            else
                            {
                                dataGridView1.Rows[i].Cells[4].Value = Math.Min(PCDiscountPrice, PCSalePrice);

                                PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * q;
                                PCTax = PCPrice * storeTaxRate;
                                dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                                dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                            }
                        }
                        else
                        {
                            if (PCDiscountPrice == 0)
                            {
                                PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value) * q;
                                PCTax = PCPrice * storeTaxRate;
                                dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                                dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                            }
                            else
                            {
                                PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * q;
                                PCTax = PCPrice * storeTaxRate;
                                dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                                dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                            }
                        }
                    }
                }
            }
            else
            {
                q = Convert.ToInt16(dataGridView1.Rows[i].Cells[2].Value);
                PCRegularPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                PCDiscountPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                PCStylistPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[12].Value);

                //if (lblType.Text.ToUpper() == "BEAUTICIAN" | lblType.Text.ToUpper() == "10% OFF VIP")
                if (lblType.Text.ToUpper() == MType2 | lblType.Text.ToUpper() == MType3 | lblType.Text.ToUpper() == MType4 | lblType.Text.ToUpper() == MType5)
                {
                    if (PCStylistPrice > 0)
                    {
                        if (PCDiscountPrice <= 0)
                        {
                            dataGridView1.Rows[i].Cells[4].Value = PCStylistPrice;

                            PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * q;
                            PCTax = PCPrice * storeTaxRate;
                            dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                            dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells[4].Value = Math.Min(PCDiscountPrice, PCStylistPrice);

                            PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * q;
                            PCTax = PCPrice * storeTaxRate;
                            dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                            dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                        }
                    }
                    else
                    {
                        if (PCDiscountPrice <= 0)
                        {
                            PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value) * q;
                            PCTax = PCPrice * storeTaxRate;
                            dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                            dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells[4].Value = PCDiscountPrice;

                            PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * q;
                            PCTax = PCPrice * storeTaxRate;
                            dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                            dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                        }
                    }
                }
                else
                {
                    if (PCDiscountPrice <= 0)
                    {
                        PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value) * q;
                        PCTax = PCPrice * storeTaxRate;
                        dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                        dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        PCPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * q;
                        PCTax = PCPrice * storeTaxRate;
                        dataGridView1.Rows[i].Cells[5].Value = PCPrice;
                        dataGridView1.Rows[i].Cells[6].Value = Math.Round(PCTax, 2, MidpointRounding.AwayFromZero);
                    }
                }
            }
        }

        /// <summary>
        /// Calculations this instance.
        /// </summary>
        public void Calculation()
        {
            calTotalQty = 0;
            calSubTotal = 0;
            calTaxableSubTotal = 0;
            calTax = 0;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                calTotalQty = calTotalQty + Convert.ToInt16(dataGridView1.Rows[i].Cells[2].Value);
                calSubTotal = calSubTotal + Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);

                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[11].Value) == true)
                    calTaxableSubTotal = calTaxableSubTotal + Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
            }

            calTax = Math.Round(calTaxableSubTotal * storeTaxRate, 2, MidpointRounding.AwayFromZero);

            if (calTax < 0)
                calTax = 0;

            calGrandTotal = calSubTotal + calTax;
            lblTotalQty.Text = Convert.ToString(calTotalQty);
            lblSubTotal.Text = string.Format("{0:$0.00}", calSubTotal);
            lblTax.Text = string.Format("{0:$0.00}", calTax);
            lblGrandTotal.Text = string.Format("{0:$0.00}", calGrandTotal);
            lblQty.Text = "1";
        }

        /// <summary>
        /// Calculatings the saved amount.
        /// </summary>
        public void Calculating_Saved_Amount()
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (Convert.ToString(dataGridView1.Rows[i].Cells[2].Value) == "POINTS REDEEMED" | Convert.ToInt16(dataGridView1.Rows[i].Cells[8].Value) == 10)
                {
                    SAQty = 0; SARetailPrice = 0; SADiscountPrice = 0; SAPrice = 0;

                    SAPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                    dataGridView1.Rows[i].Cells[16].Value = -SAPrice;
                }
                else
                {
                    SAQty = 0; SARetailPrice = 0; SADiscountPrice = 0; SAPrice = 0;

                    /*if (Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) > 0)
                    {
                        SAQty = Convert.ToInt16(dataGridView1.Rows[i].Cells[2].Value);
                        SARetailPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                        SADiscountPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);       
                        SAPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                        dataGridView1.Rows[i].Cells[16].Value = Math.Round((SARetailPrice * SAQty), 2, MidpointRounding.AwayFromZero) - SAPrice;
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[16].Value = 0;
                    }*/

                    SAQty = Convert.ToInt16(dataGridView1.Rows[i].Cells[2].Value);
                    SARetailPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                    SAPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                    dataGridView1.Rows[i].Cells[16].Value = Math.Round((SARetailPrice * SAQty), 2, MidpointRounding.AwayFromZero) - SAPrice;
                }
            }
        }

        /// <summary>
        /// Lines the disply.
        /// </summary>
        /// <param name="firstLine">The first line.</param>
        /// <param name="secondLine">The second line.</param>
        public void LineDisply(string firstLine, string secondLine)
        {
            foreach (string port in SerialPort.GetPortNames())
            {
                if (port == VFDPort)
                {
                    sPort.PortName = VFDPort;
                    sPort.BaudRate = VFDBaudRate;
                    sPort.Parity = Parity.None;
                    sPort.DataBits = 8;
                    sPort.StopBits = StopBits.One;

                    if (VFDCmdType == "ICD2002")
                    {
                        if (storeCode == "TH" & cashRegisterNum == "REG01")
                        {
                            this.PortOpen();
                            this.sVFDPort.Write("\f");
                            this.sVFDPort.Write("\v");
                            this.sVFDPort.Write("\x001bR\0");
                            this.sVFDPort.Write("\x001bt\0");
                            this.sVFDPort.Write(firstLine);
                            this.sVFDPort.Write("\x001fB");
                            this.sVFDPort.Write("\r");
                            this.sVFDPort.Write(secondLine);
                            this.PortClose();
                        }
                        else if (storeCode == "TH" & cashRegisterNum == "REG04")
                        {
                            sPort.Open();
                            sPort.Write("\x0C");
                            sPort.Write("\x1B" + "\x50" + "\x1" + "\x1");
                            sPort.Write(firstLine);
                            sPort.Write("\x1B" + "\x50" + "\x1" + "\x2");
                            sPort.Write(secondLine);
                            sPort.Close();
                        }
                        else
                        {
                            sPort.Open();
                            sPort.WriteLine("\x1B" + "\x40");
                            sPort.WriteLine("\x1B" + "\x45" + "\x58" + "\x34");
                            sPort.WriteLine("\x1B" + "\x43" + "\x0U" + "\x1");
                            sPort.Write(firstLine);
                            sPort.WriteLine("\x1B" + "\x44" + "\x0D" + "\x1");
                            sPort.Write(secondLine);
                            sPort.Close();
                        }
                    }
                    else if (VFDCmdType == "EPSON")
                    {
                        if (storeCode == "OH")
                        {
                            if (firstLine.Length > 10)
                            {
                                U1 = firstLine;
                                U2 = firstLine.Substring(10).ToString();

                                sPort.Open();
                                sPort.Write("\x0C");
                                sPort.Write("\x1F" + "\x24" + "\x1" + "\x1");
                                sPort.Write(U1);
                                sPort.Close();

                                sPort.Open();
                                sPort.Write("\x1F" + "\x24" + "\xB" + "\x1");
                                sPort.Write(U2);
                                sPort.Close();
                            }
                            else
                            {
                                U1 = firstLine;

                                sPort.Open();
                                sPort.Write("\x0C");
                                sPort.Write("\x1F" + "\x24" + "\x1" + "\x1");
                                sPort.Write(U1);
                                sPort.Close();
                            }

                            if (secondLine.Length > 10)
                            {
                                L1 = secondLine;
                                L2 = secondLine.Substring(10).ToString();

                                sPort.Open();
                                sPort.Write("\x1F" + "\x24" + "\x1" + "\x2");
                                sPort.Write(L1);
                                sPort.Close();

                                sPort.Open();
                                sPort.Write("\x1F" + "\x24" + "\xB" + "\x2");
                                sPort.Write(L2);
                                sPort.Close();
                            }
                            else
                            {
                                L1 = secondLine;

                                sPort.Open();
                                sPort.Write("\x1F" + "\x24" + "\x1" + "\x2");
                                sPort.Write(L1);
                                sPort.Close();
                            }
                        }
                        else if (storeCode == "WM" & cashRegisterNum == "REG03")
                        {
                            sPort.Open();
                            sPort.Write("\x0C");
                            sPort.Write("\x1B" + "\x50" + "\x1" + "\x1");
                            sPort.Write(firstLine);
                            sPort.Write("\x1B" + "\x50" + "\x1" + "\x2");
                            sPort.Write(secondLine);
                            sPort.Close();
                        }
                        else if (storeCode == "CH" | storeCode == "WB" | storeCode == "WM" | storeCode == "CV" | storeCode == "PW" | storeCode == "GB" | storeCode == "BW" | storeCode == "WD")
                        {
                            this.PortOpen();
                            this.sVFDPort.Write("\f");
                            this.sVFDPort.Write("\v");
                            this.sVFDPort.Write("\x001bR\0");
                            this.sVFDPort.Write("\x001bt\0");
                            this.sVFDPort.Write(firstLine);
                            this.sVFDPort.Write("\x001fB");
                            this.sVFDPort.Write("\r");
                            this.sVFDPort.Write(secondLine);
                            this.PortClose();
                        }
                        else
                        {
                            sPort.Open();
                            sPort.Write("\x0C");
                            sPort.Write("\x1F" + "\x24" + "\x1" + "\x2");
                            sPort.Write(firstLine);
                            sPort.Write("\x1F" + "\x24" + "\x1" + "\x1");
                            sPort.Write(secondLine);
                            sPort.Close();
                        }
                    }
                    else if (VFDCmdType == "POS7300")
                    {
                        sPort.Open();
                        sPort.Write("\x0C");
                        sPort.Write("\x1B" + "\x50" + "\x1" + "\x1");
                        sPort.Write(firstLine);
                        sPort.Write("\x1B" + "\x50" + "\x1" + "\x2");
                        sPort.Write(secondLine);
                        sPort.Close();
                    }
                    else if (VFDCmdType == "LOGIC CONTROLS")
                    {
                        sPort.Open();
                        sPort.WriteLine("\x1F");
                        sPort.WriteLine("\x10" + "\x00");
                        sPort.Write(firstLine);
                        sPort.WriteLine("\x10" + "\x14");
                        sPort.Write(secondLine);
                        sPort.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Ports the close.
        /// </summary>
        private void PortClose()
        {
            //while (this.VFDPort.BytesToWrite > 0)
            //{
            //}
            Thread.Sleep(100);
            this.sVFDPort.Close();
        }

        /// <summary>
        /// Ports the open.
        /// </summary>
        private void PortOpen()
        {
            if (!this.sVFDPort.IsOpen)
            {
                this.sVFDPort.Open();
            }
        }

        /// <summary>
        /// Displays the item price.
        /// </summary>
        /// <param name="vsdopt">The vsdopt.</param>
        public void Display_Item_Price(int vsdopt)
        {
            int idx = 0;

            if (dataGridView1.RowCount > 0)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Selected == true)
                    {
                        idx = i;
                    }
                }

                if (vsdopt == 0)
                {
                    displayName = dataGridView1.Rows[idx].Cells[1].Value.ToString();

                    if (displayName.Length > 20)
                        displayName = displayName.Substring(0, 19);

                    displayPrice = string.Format("{0:$0.00}", Convert.ToDouble(dataGridView1.Rows[idx].Cells[5].Value));

                    LineDisply(displayName, displayPrice);
                }
                else if (vsdopt == 1)
                {
                    displayName = dataGridView1.Rows[idx].Cells[1].Value.ToString();

                    if (displayName.Length > 20)
                        displayName = displayName.Substring(0, 19);

                    if (Convert.ToDouble(dataGridView1.Rows[idx].Cells[4].Value) > 0)
                    {
                        displayPrice = string.Format("{0:$0.00}", -Convert.ToDouble(dataGridView1.Rows[idx].Cells[4].Value));
                    }
                    else
                    {
                        displayPrice = string.Format("{0:$0.00}", -Convert.ToDouble(dataGridView1.Rows[idx].Cells[3].Value));
                    }

                    LineDisply(displayName, displayPrice);
                }
                else if (vsdopt == 2)
                {
                    displayName = dataGridView1.Rows[idx].Cells[1].Value.ToString();
                    displayPrice = string.Format("{0:$0.00}", Convert.ToDouble(dataGridView1.Rows[idx].Cells[5].Value));

                    LineDisply(displayName, displayPrice);
                }
                else if (vsdopt == 3)
                {
                    if (displayName.Length > 20)
                    {
                        displayName = displayName.Substring(0, 19);
                    }
                    else
                    {
                        displayName = dataGridView1.Rows[idx].Cells[1].Value.ToString();
                    }

                    displayPrice = " ";

                    LineDisply(displayName, displayPrice);
                }
            }
        }

        /// <summary>
        /// Sets the focus on input box.
        /// </summary>
        public void SetFocusOnInputBox()
        {
            LineDisply(openingMSG1, openingMSG2);
            this.richTxtUpc.Focus();
            this.richTxtUpc.Select();
        }

        /// <summary>
        /// Sets the focus on input box.
        /// </summary>
        /// <param name="firstLine">The first line.</param>
        /// <param name="secondLine">The second line.</param>
        public void SetFocusOnInputBox(string firstLine, string secondLine)
        {
            LineDisply(firstLine, secondLine);
            this.richTxtUpc.Focus();
            this.richTxtUpc.Select();
        }

        /// <summary>
        /// Processes a command key.
        /// </summary>
        /// <param name="msg">A <see cref="T:System.Windows.Forms.Message" />, passed by reference, that represents the Win32 message to process.</param>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values that represents the key to process.</param>
        /// <returns>true if the keystroke was processed and consumed by the control; otherwise, false to allow further processing.</returns>
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            if (keyData == Keys.F10)
            {
                richTxtUpc.Text = F10Value;
                btnInput_Click(null, null);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Counts the mix match value total.
        /// </summary>
        /// <param name="mmVal">The mm value.</param>
        /// <returns>System.Int32.</returns>
        private int Count_MixMatchVal_Total(int mmVal)
        {
            mmValCount = 0;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (Convert.ToInt16(dataGridView1.Rows[i].Cells[18].Value) == mmVal)
                    mmValCount = mmValCount + 1;
            }

            return mmValCount;
        }

        /// <summary>
        /// Checks the mix match value.
        /// </summary>
        /// <param name="sIdx">Index of the s.</param>
        /// <param name="mmVal">The mm value.</param>
        /// <param name="mmQty">The mm qty.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool Check_MixMatchVal(int sIdx, int mmVal, int mmQty)
        {
            checkMMQty = 0;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[17].Value) == true & Convert.ToInt16(dataGridView1.Rows[i].Cells[18].Value) == mmVal)
                    checkMMQty = checkMMQty + 1;
            }

            if (checkMMQty < mmQty)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Sets the promotion values.
        /// </summary>
        private void Set_Promotion_Values()
        {
            cmd_PriceComparing = new SqlCommand("Get_SalePrice", conn);
            cmd_PriceComparing.CommandType = CommandType.StoredProcedure;
            cmd_PriceComparing.Parameters.Clear();
            cmd_PriceComparing.Parameters.Add("@Today", SqlDbType.NVarChar).Value = today;
            cmd_PriceComparing.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = dataGridView1.SelectedCells[7].Value.ToString();
            SqlParameter MixMatch_Param = cmd_PriceComparing.Parameters.Add("@MixMatch", SqlDbType.Bit);
            SqlParameter MixMatchVal_Param = cmd_PriceComparing.Parameters.Add("@MixMatchVal", SqlDbType.Int);
            SqlParameter SalePrice_Param = cmd_PriceComparing.Parameters.Add("@SalePrice", SqlDbType.Money);
            SqlParameter MixMatchQty_Param = cmd_PriceComparing.Parameters.Add("@MixMatchQty", SqlDbType.Int);
            MixMatch_Param.Direction = ParameterDirection.Output;
            MixMatchVal_Param.Direction = ParameterDirection.Output;
            SalePrice_Param.Direction = ParameterDirection.Output;
            MixMatchQty_Param.Direction = ParameterDirection.Output;

            conn.Open();
            cmd_PriceComparing.ExecuteNonQuery();
            conn.Close();

            if (cmd_PriceComparing.Parameters["@MixMatch"].Value == DBNull.Value)
            {
                dataGridView1.SelectedCells[17].Value = false;
            }
            else
            {
                dataGridView1.SelectedCells[17].Value = Convert.ToBoolean(cmd_PriceComparing.Parameters["@MixMatch"].Value);
            }

            if (cmd_PriceComparing.Parameters["@MixMatchVal"].Value == DBNull.Value)
            {
                dataGridView1.SelectedCells[18].Value = 0;
            }
            else
            {
                dataGridView1.SelectedCells[18].Value = Convert.ToInt16(cmd_PriceComparing.Parameters["@MixMatchVal"].Value);
            }

            if (cmd_PriceComparing.Parameters["@SalePrice"].Value == DBNull.Value)
            {
                dataGridView1.SelectedCells[19].Value = 0;
            }
            else
            {
                dataGridView1.SelectedCells[19].Value = Convert.ToDouble(cmd_PriceComparing.Parameters["@SalePrice"].Value);
            }

            if (cmd_PriceComparing.Parameters["@MixMatchQty"].Value == DBNull.Value)
            {
                dataGridView1.SelectedCells[20].Value = 0;
            }
            else
            {
                dataGridView1.SelectedCells[20].Value = Convert.ToInt16(cmd_PriceComparing.Parameters["@MixMatchQty"].Value);
            }
        }

        /// <summary>
        /// Compares the mix match price.
        /// </summary>
        /// <param name="mmVal">The mm value.</param>
        /// <param name="mmQty">The mm qty.</param>
        /// <param name="idx">The index.</param>
        private void Compare_MixMatchPrice(int mmVal, int mmQty, int idx)
        {
            mmRetailPrice = new ArrayList();

            mmValCount2 = 0;
            quotient = 0;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[17].Value) == true & Convert.ToInt16(dataGridView1.Rows[i].Cells[18].Value) == mmVal)
                {
                    mmRetailPrice.Add(Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value));
                    //dataGridView1.Rows[i].Cells[4].Value = 0;
                    //dataGridView1.Rows[i].Cells[5].Value = 0;
                    //dataGridView1.Rows[i].Cells[21].Value = 0;
                    mmValCount2 = mmValCount2 + 1;
                }
            }

            mmRetailPrice.Sort();
            quotient = mmValCount2 / mmQty;
            mmMinRetailPrice = new double[quotient];

            if (quotient > 0)
            {
                for (int k = 0; k < dataGridView1.RowCount; k++)
                {
                    if (Convert.ToBoolean(dataGridView1.Rows[k].Cells[17].Value) == true & Convert.ToInt16(dataGridView1.Rows[k].Cells[18].Value) == mmVal)
                    {
                        dataGridView1.Rows[k].Cells[4].Value = 0;
                        dataGridView1.Rows[k].Cells[5].Value = 0;
                        dataGridView1.Rows[k].Cells[21].Value = 0;
                    }
                }

                for (int i = 0; i < quotient; i++)
                {
                    mmMinRetailPrice[i] = Convert.ToDouble(mmRetailPrice[i]);

                    for (int j = 0; j < dataGridView1.RowCount; j++)
                    //for (int j = dataGridView1.RowCount - 1; j >= 0; j--)
                    {
                        if (mmVal == 0)
                        {
                            dataGridView1.Rows[j].Cells[4].Value = Convert.ToDouble(dataGridView1.Rows[j].Cells[19].Value);
                        }
                        if (mmVal >= 1 & mmVal <= 10)
                        {
                            if (Convert.ToDouble(dataGridView1.Rows[j].Cells[3].Value) == mmMinRetailPrice[i] & Convert.ToDouble(dataGridView1.Rows[j].Cells[21].Value) == 0 & Convert.ToInt16(dataGridView1.Rows[j].Cells[18].Value) == mmVal)
                            {
                                dataGridView1.Rows[j].Cells[4].Value = Convert.ToDouble(dataGridView1.Rows[j].Cells[19].Value);

                                if (Convert.ToDouble(dataGridView1.Rows[j].Cells[4].Value) == 0)
                                    dataGridView1.Rows[j].Cells[21].Value = 1;

                                break;
                            }
                        }
                        else
                        {
                            if (Convert.ToDouble(dataGridView1.Rows[j].Cells[3].Value) == mmMinRetailPrice[i] & Convert.ToDouble(dataGridView1.Rows[j].Cells[4].Value) == 0 & Convert.ToInt16(dataGridView1.Rows[j].Cells[18].Value) == mmVal)
                            {
                                dataGridView1.Rows[j].Cells[4].Value = Convert.ToDouble(dataGridView1.Rows[j].Cells[19].Value);
                                break;
                            }
                        }
                    }
                }

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    Price_Comparing(i);
                }
            }
            else
            {
                for (int k = 0; k < dataGridView1.RowCount; k++)
                {
                    if (Convert.ToBoolean(dataGridView1.Rows[k].Cells[17].Value) == true & Convert.ToInt16(dataGridView1.Rows[k].Cells[18].Value) == mmVal)
                    {
                        dataGridView1.Rows[k].Cells[4].Value = 0;
                        dataGridView1.Rows[k].Cells[5].Value = 0;
                        dataGridView1.Rows[k].Cells[21].Value = 0;

                        Price_Comparing(k);
                    }
                }
            }
        }

        /// <summary>
        /// Customers the transaction update.
        /// </summary>
        /// <param name="opt">The opt.</param>
        /// <param name="sc">The sc.</param>
        /// <param name="mCode">The m code.</param>
        /// <param name="amt">The amt.</param>
        /// <param name="lDate">The l date.</param>
        public void Customer_Transaction_Update(int opt, string sc, Int64 mCode, double amt, string lDate)
        {
            try
            {
                cmd_CTU = new SqlCommand("Member_Transaction_Update", connHQ);
                cmd_CTU.CommandType = CommandType.StoredProcedure;
                cmd_CTU.Parameters.Clear();
                cmd_CTU.Parameters.Add("@Opt", SqlDbType.Int).Value = opt;
                cmd_CTU.Parameters.Add("@MemberCode", SqlDbType.BigInt).Value = mCode;
                cmd_CTU.Parameters.Add("@Amount", SqlDbType.Money).Value = amt;
                cmd_CTU.Parameters.Add("@LastVisitDate", SqlDbType.DateTime).Value = DateTime.Now;

                connHQ.Open();
                cmd_CTU.ExecuteNonQuery();
                connHQ.Close();
            }
            catch
            {
                MyMessageBox.ShowBox("CUSTOMER TRANSACTION UPDATE FAILED", "ERROR");
                connHQ.Close();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnGiftcardRedeem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnGiftcardRedeem_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.RowCount == 0)
            //{
            //    richTxtUpc.SelectAll();
            //    richTxtUpc.Focus();
            //    return;
            //}

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (Convert.ToString(dataGridView1.Rows[i].Cells[7].Value) == "000000999111")
                {
                    MyMessageBox.ShowBox("CAN NOT USE MORE THAN 2 GIFTCARDS", "ERROR");
                    richTxtUpc.Focus();
                    richTxtUpc.Select();
                    return;
                }
            }

            this.Enabled = false;
            GiftcardRedeem giftcardRedeemForm = new GiftcardRedeem();
            giftcardRedeemForm.parentForm = this;
            giftcardRedeemForm.ShowDialog();
        }

        /// <summary>
        /// Giftcards the activation.
        /// </summary>
        public void Giftcard_Activation()
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                //if (Convert.ToInt16(dataGridView1.SelectedCells[8].Value) == 7 & Convert.ToInt16(dataGridView1.SelectedCells[9].Value) == 5 & Convert.ToInt16(dataGridView1.SelectedCells[10].Value) == 1)
                if (Convert.ToString(dataGridView1.Rows[i].Cells[7].Value) == "B4UGIFTCARD1" | Convert.ToString(dataGridView1.Rows[i].Cells[7].Value) == "B4UGIFTCARD2" | Convert.ToString(dataGridView1.Rows[i].Cells[7].Value) == "B4UGIFTCARD3")
                {
                    giftcardCodeForActivation = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value).Substring(0, 9).ToUpper();

                    try
                    {
                        cmdGiftcardActivation = new SqlCommand("Activate_Giftcard", conn);
                        cmdGiftcardActivation.CommandType = CommandType.StoredProcedure;
                        cmdGiftcardActivation.Parameters.Clear();
                        cmdGiftcardActivation.Parameters.Add("@GiftCardCode", SqlDbType.NVarChar).Value = giftcardCodeForActivation;
                        cmdGiftcardActivation.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                        cmdGiftcardActivation.Parameters.Add("@ExpDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today.AddYears(1));

                        conn.Open();
                        cmdGiftcardActivation.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch
                    {
                        conn.Close();
                        MyMessageBox.ShowBox("GIFTCARD ACTIVATION FAILED", "ERROR");
                        return;
                    }
                }
            }

            giftcardCodeForActivation = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the btnCoupon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCoupon_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                richTxtUpc.SelectAll();
                richTxtUpc.Focus();
                return;
            }

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (Convert.ToString(dataGridView1.Rows[i].Cells[7].Value) == couponBarcode)
                {
                    MyMessageBox.ShowBox("CAN NOT USE MORE THAN 2 COUPONS", "ERROR");
                    richTxtUpc.Focus();
                    richTxtUpc.Select();
                    return;
                }
            }

            this.Enabled = false;
            CouponRedeem couponRedeemForm = new CouponRedeem();
            couponRedeemForm.parentForm = this;
            couponRedeemForm.ShowDialog();
        }

        /// <summary>
        /// Coupons the update.
        /// </summary>
        /// <param name="num">The number.</param>
        /// <param name="rcptID">The RCPT identifier.</param>
        public void Coupon_Update(string num, Int64 rcptID)
        {
            cmd_coupon.Connection = conn;
            cmd_coupon.CommandText = "Update_Coupon_Using";
            cmd_coupon.CommandType = CommandType.StoredProcedure;
            cmd_coupon.Parameters.Clear();
            cmd_coupon.Parameters.Add("@CpNum", SqlDbType.NVarChar).Value = num;
            cmd_coupon.Parameters.Add("@CpRefReceiptID", SqlDbType.NVarChar).Value = rcptID;
            cmd_coupon.Parameters.Add("@CpUsingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

            conn.Open();
            cmd_coupon.ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        /// Handles the Click event of the btnMembership control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnMembership_Click(object sender, EventArgs e)
        {
            /*if (dataGridView1.RowCount > 0)
            {
                MyMessageBox.ShowBox("INPUT MEMBER CODE BEFORE TRANSACTION START", "ERROR");
                return;
            }*/

            //radioBtnDefault.Checked = true;

            //btnDefault_Click(null, null);

            MembershipMain membershipMainForm = new MembershipMain();
            membershipMainForm.parentForm = this;
            membershipMainForm.Show();
        }

        /// <summary>
        /// Handles the Click event of the btnDefault control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnDefault_Click(object sender, EventArgs e)
        {
            //radioBtnDefault.Checked = true;

            lblMemberCode.Text = defaultMemberCode;
            lblName.Text = defaultMemberName;
            lblType.Text = defaultMemberType;
            lblPoints.Text = defaultMemberPoints;
            points = 0;
            CtmPoint = 0;

            if (dataGridView1.RowCount > 0)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (Convert.ToString(dataGridView1.Rows[i].Cells[7].Value) == pointRedeemBarcode)
                    {
                        this.dataGridView1.Rows.RemoveAt(i);
                    }
                }
            }

            if (dataGridView1.RowCount > 0)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (Convert.ToString(dataGridView1.Rows[i].Cells[7].Value) == couponBarcode & boolNumSecondVisitCoupon == true)
                    {
                        this.dataGridView1.Rows.RemoveAt(i);

                        CouponAmt = 0;
                        CouponDesc = string.Empty;
                        CouponMgrID = string.Empty;
                    }
                }
            }

            boolNumSecondVisitCoupon = false;
            PTrns = 0;
            TTrns = 0;

            Calculation();

            LineDisply(openingMSG1, openingMSG2);
            richTxtUpc.Focus();
            richTxtUpc.Select();
        }

        /// <summary>
        /// Socials the media discount history.
        /// </summary>
        /// <param name="sc">The sc.</param>
        /// <param name="rctID">The RCT identifier.</param>
        /// <param name="mCode">The m code.</param>
        /// <param name="mName">Name of the m.</param>
        /// <param name="cID">The c identifier.</param>
        public void SocialMediaDiscount_History(string sc, Int64 rctID, string mCode, string mName, string cID)
        {
            cmd_SocailMediaDiscount = new SqlCommand("Create_SocialMediaDiscount_History", conn);
            cmd_SocailMediaDiscount.CommandType = CommandType.StoredProcedure;
            cmd_SocailMediaDiscount.Parameters.Clear();
            cmd_SocailMediaDiscount.Parameters.Add("@SMDStoreCode", SqlDbType.NVarChar).Value = sc;
            cmd_SocailMediaDiscount.Parameters.Add("@SMDReceiptID", SqlDbType.NVarChar).Value = rctID;
            cmd_SocailMediaDiscount.Parameters.Add("@SMDMemberCode", SqlDbType.NVarChar).Value = mCode;
            cmd_SocailMediaDiscount.Parameters.Add("@SMDMemberName", SqlDbType.NVarChar).Value = mName;
            cmd_SocailMediaDiscount.Parameters.Add("@SMDCashierID", SqlDbType.NVarChar).Value = cID;
            cmd_SocailMediaDiscount.Parameters.Add("@SMDDate", SqlDbType.DateTime).Value = DateTime.Now;

            conn.Open();
            cmd_SocailMediaDiscount.ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        /// Extras the discount history.
        /// </summary>
        /// <param name="sc">The sc.</param>
        /// <param name="rctID">The RCT identifier.</param>
        /// <param name="mCode">The m code.</param>
        /// <param name="mName">Name of the m.</param>
        /// <param name="cID">The c identifier.</param>
        public void ExtraDiscount_History(string sc, Int64 rctID, string mCode, string mName, string cID)
        {
            cmd_ExtraDiscount = new SqlCommand("Create_ExtraDiscount_History", conn);
            cmd_ExtraDiscount.CommandType = CommandType.StoredProcedure;
            cmd_ExtraDiscount.Parameters.Clear();
            cmd_ExtraDiscount.Parameters.Add("@EDStoreCode", SqlDbType.NVarChar).Value = sc;
            cmd_ExtraDiscount.Parameters.Add("@EDDiscountType", SqlDbType.NVarChar).Value = "25% OFF FOR $50 PURCHASE OR MORE";
            cmd_ExtraDiscount.Parameters.Add("@EDReceiptID", SqlDbType.NVarChar).Value = rctID;
            cmd_ExtraDiscount.Parameters.Add("@EDMemberCode", SqlDbType.NVarChar).Value = mCode;
            cmd_ExtraDiscount.Parameters.Add("@EDMemberName", SqlDbType.NVarChar).Value = mName;
            cmd_ExtraDiscount.Parameters.Add("@EDCashierID", SqlDbType.NVarChar).Value = cID;
            cmd_ExtraDiscount.Parameters.Add("@EDDate", SqlDbType.DateTime).Value = DateTime.Now;

            conn.Open();
            cmd_ExtraDiscount.ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        /// Initializes the connector.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public void InitializeConnector(CloverDeviceConfiguration config)
        {
            if (cloverConnector != null)
            {
                cloverConnector.RemoveCloverConnectorListener(this);

                OnDeviceDisconnected(); // for any disabling, messaging, etc.
                //SaleButton.Enabled = false; // everything can work except Pay
                cloverConnector.Dispose();
            }

            if (config is RemoteRESTCloverConfiguration)
            {
                cloverConnector = new RemoteRESTCloverConnector(config);
                cloverConnector.InitializeConnection();
            }
            else if (config is RemoteWebSocketCloverConfiguration)
            {
                cloverConnector = new RemoteWebSocketCloverConnector(config);
                cloverConnector.InitializeConnection();
            }
            else
            {
                cloverConnector = new CloverConnector(config);
                cloverConnector.InitializeConnection();
            }

            cloverConnector.AddCloverConnectorListener(this);
        }

        /// <summary>
        /// Called when [device connected].
        /// </summary>
        public void OnDeviceConnected()
        {
            uiThread.Send(delegate (object state)
            {
                Form fc = Application.OpenForms["CloverPayment"];
                Form fc2 = Application.OpenForms["Return"];

                if (fc != null)
                {
                    cloverPaymentForm.ConnectStatusLabel.Text = "Connecting...";
                }
                else if (fc2 != null)
                {
                    returnForm.ConnectStatusLabel.Text = "Connecting...";
                }
            }, null);
        }

        /// <summary>
        /// Called when [device ready].
        /// </summary>
        /// <param name="merchantInfo">The merchant information.</param>
        public void OnDeviceReady(MerchantInfo merchantInfo)
        {
            uiThread.Send(delegate (object state)
            {
                Form fc = Application.OpenForms["CloverPayment"];
                Form fc2 = Application.OpenForms["Return"];

                if (fc != null)
                {
                    cloverPaymentForm.ConnectStatusLabel.Text = "Connected";
                }
                else if (fc2 != null)
                {
                    returnForm.ConnectStatusLabel.Text = "Connected";
                }

                cloverDeviceConnection = "Connected";
                Connected = true;
            }, null);
        }

        /// <summary>
        /// Called when [device disconnected].
        /// </summary>
        public void OnDeviceDisconnected()
        {
            try
            {
                uiThread.Send(delegate (object state)
                {
                    Form fc = Application.OpenForms["CloverPayment"];
                    Form fc2 = Application.OpenForms["Return"];

                    if (fc != null)
                    {
                        cloverPaymentForm.ConnectStatusLabel.Text = "Disconnected";
                    }
                    else if (fc2 != null)
                    {
                        returnForm.ConnectStatusLabel.Text = "Disconnected";
                    }

                    cloverDeviceConnection = "Disconnected";
                    Connected = false;
                    //PaymentReset();
                }, null);

            }
            catch (Exception)
            {
                // uiThread is gone on shutdown
            }
        }

        /// <summary>
        /// Called when [device activity start].
        /// </summary>
        /// <param name="deviceEvent">The device event.</param>
        public void OnDeviceActivityStart(CloverDeviceEvent deviceEvent)
        {
            uiThread.Send(delegate (object state)
            {
                /*foreach (InputOption io in deviceEvent.InputOptions)
                {
                    if (io.description == "No receipt")
                    {
                        cloverConnector.InvokeInputOption(io);
                    }
                }*/

                Form fc = Application.OpenForms["CloverPayment"];
                Form fc2 = Application.OpenForms["Return"];

                if (fc != null)
                {
                    cloverPaymentForm.DeviceCurrentStatus.Text = deviceEvent.Message;

                    cloverPaymentForm.UIStateButtonPanel.Controls.Clear();
                    if (deviceEvent.InputOptions != null)
                    {
                        foreach (InputOption io in deviceEvent.InputOptions)
                        {
                            Button b = new Button();
                            b.FlatStyle = FlatStyle.Flat;
                            b.BackColor = Color.White;
                            b.Text = io.description.ToUpper();
                            b.Font = new Font(Font.FontFamily, 9);
                            b.Click += getHandler(io);
                            cloverPaymentForm.UIStateButtonPanel.Controls.Add(b);
                        }
                    }
                    cloverPaymentForm.UIStateButtonPanel.Parent.PerformLayout();
                }
                else if (fc2 != null)
                {
                    returnForm.DeviceCurrentStatus.Text = deviceEvent.Message;

                    returnForm.UIStateButtonPanel.Controls.Clear();
                    if (deviceEvent.InputOptions != null)
                    {
                        foreach (InputOption io in deviceEvent.InputOptions)
                        {
                            Button b = new Button();
                            b.FlatStyle = FlatStyle.Flat;
                            b.BackColor = Color.White;
                            b.Text = io.description.ToUpper();
                            b.Font = new Font(Font.FontFamily, 9);
                            b.Click += getHandler(io);
                            returnForm.UIStateButtonPanel.Controls.Add(b);
                        }
                    }
                    returnForm.UIStateButtonPanel.Parent.PerformLayout();
                }
            }, null);
        }

        /// <summary>
        /// Called when [device activity end].
        /// </summary>
        /// <param name="deviceEvent">The device event.</param>
        public void OnDeviceActivityEnd(CloverDeviceEvent deviceEvent)
        {
            try
            {
                uiThread.Send(delegate (object state)
                {
                    Form fc = Application.OpenForms["CloverPayment"];
                    Form fc2 = Application.OpenForms["Return"];

                    if (fc != null)
                    {
                        cloverPaymentForm.UIStateButtonPanel.Controls.Clear();
                        cloverPaymentForm.DeviceCurrentStatus.Text = " ";
                    }
                    else if (fc2 != null)
                    {
                        returnForm.UIStateButtonPanel.Controls.Clear();
                        //returnForm.DeviceCurrentStatus.Text = deviceEvent.Message;
                        returnForm.DeviceCurrentStatus.Text = " ";
                    }
                }, null);
            }
            catch (Exception)
            {
                // if UI goes away, uiThread may be disposed
            }
        }

        /// <summary>
        /// Called when [device error].
        /// </summary>
        /// <param name="deviceErrorEvent">The device error event.</param>
        public void OnDeviceError(CloverDeviceErrorEvent deviceErrorEvent)
        {
            uiThread.Send(delegate (object state)
            {
                //MyMessageBox.ShowBox(deviceErrorEvent.Message + "\nPLEASE CHECK THE CARD MACHINE...", "ERROR");
                MyMessageBox.ShowBox(deviceErrorEvent.Message, "ERROR");
            }, null);
        }

        /// <summary>
        /// Called when [confirm payment request].
        /// </summary>
        /// <param name="request">The request.</param>
        public void OnConfirmPaymentRequest(ConfirmPaymentRequest request)
        {
            Form fc = Application.OpenForms["CloverPayment"];

            if (fc != null)
            {
                //MainForm parentForm = this;
                AutoResetEvent confirmPaymentFormBusy = new AutoResetEvent(false);
                bool lastChallenge = false;
                for (int i = 0; i < request.Challenges.Count; i++)
                {
                    uiThread.Send(delegate (object state)
                    {
                        if (i == request.Challenges.Count - 1) // if this is the last challenge
                        {
                            lastChallenge = true;
                        }
                        Challenge challenge = request.Challenges[i];
                        ConfirmPaymentForm confirmForm = new ConfirmPaymentForm(fc, challenge, lastChallenge);
                        confirmForm.TopMost = true;
                        confirmForm.FormClosed += (object s, FormClosedEventArgs ce) =>
                        {
                            if (confirmForm.Status == DialogResult.No)
                            {
                                cloverConnector.RejectPayment(request.Payment, challenge);
                                i = request.Challenges.Count;
                            }
                            else if (confirmForm.Status == DialogResult.OK) // Last challenge was accepted
                            {
                                cloverConnector.AcceptPayment(request.Payment);
                            }
                            confirmPaymentFormBusy.Set(); //release the confirmPaymentFormBusy WaitOne lock
                        };
                        confirmForm.Show();
                    }, null);
                    confirmPaymentFormBusy.WaitOne(); //wait here until Accept or Reject pressed
                }
            }
        }

        /// <summary>
        /// Pays the specified ce.
        /// </summary>
        /// <param name="CE">The ce.</param>
        /// <param name="amt">The amt.</param>
        public void Pay(int CE, double amt)
        {
            SaleRequest request = new SaleRequest();
            request.ExternalId = ExternalIDUtil.GenerateRandomString(13);

            // Card Entry methods
            //int CardEntry = 0;
            //CardEntry |= ManualEntryCheckbox.Checked ? CloverConnector.CARD_ENTRY_METHOD_MANUAL : 0;
            //CardEntry |= MagStripeCheckbox.Checked ? CloverConnector.CARD_ENTRY_METHOD_MAG_STRIPE : 0;
            //CardEntry |= ChipCheckbox.Checked ? CloverConnector.CARD_ENTRY_METHOD_ICC_CONTACT : 0;
            //CardEntry |= ContactlessCheckbox.Checked ? CloverConnector.CARD_ENTRY_METHOD_NFC_CONTACTLESS : 0;

            request.CardEntryMethods = CE;
            request.CardNotPresent = false;
            request.Amount = Convert.ToInt64(amt * 100);
            TempAmount = Convert.ToInt64(amt * 100);
            //Test value for partial authorization
            //TempAmount = 1000;
            //request.TipAmount = 0;
            //request.TaxAmount = Convert.ToInt64(tax * 100);

            request.DisableCashback = true;
            request.DisableRestartTransactionOnFail = false;
            request.DisablePrinting = true;
            request.DisableReceiptSelection = true;
            request.DisableDuplicateChecking = true;
            request.AutoAcceptSignature = false;
            request.AutoAcceptPaymentConfirmations = false;
            //request.AllowOfflinePayment = false;
            //request.ApproveOfflinePaymentWithoutPrompt = false;
            //request.ForceOfflinePayment = false;

            cloverConnector.Sale(request);
        }

        /// <summary>
        /// Called when [sale response].
        /// </summary>
        /// <param name="response">The response.</param>
        public void OnSaleResponse(SaleResponse response)
        {
            if (response.Success)
            {
                uiThread.Send(delegate (object state)
                {
                    if (response.Payment.amount >= TempAmount)
                    {
                        CardTransaction cTransaction = new CardTransaction();
                        cTransaction = response.Payment.cardTransaction;
                        CardType cType = new CardType();
                        cType = cTransaction.cardType;
                        CardTransactionType cTransactionType = new CardTransactionType();
                        cTransactionType = cTransaction.type;

                        rAmount = Convert.ToDouble(response.Payment.amount);
                        paymentID = response.Payment.id;
                        orderID = response.Payment.order.id;
                        externalPaymentID = response.Payment.externalPaymentId;
                        referenceID = cTransaction.referenceId;
                        createdTime = response.Payment.createdTime;
                        cardType = cType.ToString();
                        entryType = cTransaction.entryType.ToString();
                        transactionLabel = response.Payment.tender.label.ToUpper() + " SALE";
                        last4 = cTransaction.last4;
                        cardHolderName = cTransaction.cardholderName;
                        authCode = cTransaction.authCode;

                        if (cTransaction.extra.ContainsKey("applicationIdentifier"))
                        {
                            AID = cTransaction.extra["applicationIdentifier"];
                        }
                        else
                        {
                            AID = "N/A";
                        }

                        if (cTransaction.extra.ContainsKey("cvmResult"))
                        {
                            cvm = cTransaction.extra["cvmResult"];
                        }
                        else
                        {

                        }

                        if (paymentID == null)
                            paymentID = "";

                        if (orderID == null)
                            orderID = "";

                        if (externalPaymentID == null)
                            externalPaymentID = "";

                        if (referenceID == null)
                            referenceID = "";

                        if (createdTime == 0)
                        {
                            cSellDate = string.Format("{0:MM/dd/yyyy}", DateTime.Now);
                            cSellTime = string.Format("{0:T}", DateTime.Now);
                        }
                        else
                        {
                            TimeSpan ts = TimeSpan.FromMilliseconds(Convert.ToDouble(createdTime));
                            DateTime uDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                            uDate += ts;
                            DateTime lDate = uDate.ToLocalTime();
                            cSellDate = string.Format("{0:MM/dd/yyyy}", lDate);
                            cSellTime = string.Format("{0:T}", lDate);
                        }

                        if (cardType == null)
                            cardType = "";

                        if (entryType == null)
                            entryType = "";

                        if (transactionLabel == null)
                            transactionLabel = "";

                        if (last4 == null)
                            last4 = "";

                        if (cardHolderName == null)
                            cardHolderName = "CARD USER";

                        if (authCode == null)
                            authCode = "";

                        if (cvm == null)
                            cvm = "";

                        Form fc = Application.OpenForms["CloverPayment"];

                        if (fc != null)
                        {
                            cloverPaymentForm.txtCardTransactionType.Text = cTransactionType.ToString();
                            cloverPaymentForm.txtPaymentID.Text = paymentID;
                            cloverPaymentForm.txtOrderID.Text = orderID;
                            cloverPaymentForm.txtExternalPaymentID.Text = externalPaymentID;
                            cloverPaymentForm.txtAmount.Text = string.Format("{0:c}", rAmount / 100);
                            cloverPaymentForm.txtMethod.Text = entryType;
                            cloverPaymentForm.txtCardType.Text = cardType;
                            cloverPaymentForm.txtCardSaleType.Text = transactionLabel;
                            cloverPaymentForm.txtLast4Digit.Text = last4;
                            cloverPaymentForm.txtCardHolderName.Text = cardHolderName;
                            cloverPaymentForm.txtReferenceID.Text = referenceID;
                            cloverPaymentForm.txtAuthCode.Text = authCode;
                            cloverPaymentForm.txtAID.Text = AID;
                            cloverPaymentForm.txtVerification.Text = cvm;

                            cloverPaymentForm.CPAmount = rAmount / 100;
                            cloverPaymentForm.CPpaymentID = paymentID;
                            cloverPaymentForm.CPorderID = orderID;
                            cloverPaymentForm.CPexternalPaymentID = externalPaymentID;
                            cloverPaymentForm.CPreferenceID = referenceID;
                            cloverPaymentForm.CPcreatedTime = createdTime;
                            cloverPaymentForm.CPsellDate = cSellDate;
                            cloverPaymentForm.CPsellTime = cSellTime;
                            cloverPaymentForm.CPcardType = cardType;
                            cloverPaymentForm.CPentryType = entryType;
                            cloverPaymentForm.CPtransactionLabel = transactionLabel;
                            cloverPaymentForm.CPlast4 = last4;
                            cloverPaymentForm.CPcardHolderName = cardHolderName;
                            cloverPaymentForm.CPauthCode = authCode;
                            cloverPaymentForm.CPAID = AID;
                            cloverPaymentForm.CPcvm = cvm;

                            if (cloverPaymentForm.parentFormOpt == 0)
                            {
                                cloverPaymentForm.Regular_Transaction();
                            }
                            else if (cloverPaymentForm.parentFormOpt == 1)
                            {
                                cloverPaymentForm.Multiple_Transaction();
                            }

                            Resetting_CloverPayment();
                            cloverPaymentForm.btnCancel.Enabled = true;
                            cloverPaymentForm.btnCancel.ForeColor = Color.White;
                            cloverPaymentForm.btnCancel.Text = "CLOSE";
                        }
                        else
                        {
                            MyMessageBox.ShowBox("TRANSACTION ERROR", "ERROR");
                            return;
                        }
                    }
                    else
                    {
                        CardTransaction cTransaction = new CardTransaction();
                        cTransaction = response.Payment.cardTransaction;
                        CardType cType = new CardType();
                        cType = cTransaction.cardType;
                        CardTransactionType cTransactionType = new CardTransactionType();
                        cTransactionType = cTransaction.type;

                        rAmount = Convert.ToDouble(response.Payment.amount);
                        paymentID = response.Payment.id;
                        orderID = response.Payment.order.id;
                        externalPaymentID = response.Payment.externalPaymentId;
                        referenceID = cTransaction.referenceId;
                        createdTime = response.Payment.createdTime;
                        cardType = cType.ToString();
                        entryType = cTransaction.entryType.ToString();
                        transactionLabel = response.Payment.tender.label.ToUpper() + " SALE";
                        last4 = cTransaction.last4;
                        cardHolderName = cTransaction.cardholderName;
                        authCode = cTransaction.authCode;

                        if (createdTime == 0)
                        {
                            cSellDate = string.Format("{0:MM/dd/yyyy}", DateTime.Now);
                            cSellTime = string.Format("{0:T}", DateTime.Now);
                        }
                        else
                        {
                            TimeSpan ts = TimeSpan.FromMilliseconds(Convert.ToDouble(createdTime));
                            DateTime uDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                            uDate += ts;
                            DateTime lDate = uDate.ToLocalTime();
                            cSellDate = string.Format("{0:MM/dd/yyyy}", lDate);
                            cSellTime = string.Format("{0:T}", lDate);
                        }

                        cloverPaymentForm.CPAmount = rAmount / 100;
                        cloverPaymentForm.CPpaymentID = paymentID;
                        cloverPaymentForm.CPorderID = orderID;
                        cloverPaymentForm.CPexternalPaymentID = externalPaymentID;
                        cloverPaymentForm.CPreferenceID = referenceID;
                        cloverPaymentForm.CPcreatedTime = createdTime;
                        cloverPaymentForm.CPsellDate = cSellDate;
                        cloverPaymentForm.CPsellTime = cSellTime;
                        cloverPaymentForm.CPcardType = cardType;
                        cloverPaymentForm.CPentryType = entryType;
                        cloverPaymentForm.CPtransactionLabel = transactionLabel;
                        cloverPaymentForm.CPlast4 = last4;
                        cloverPaymentForm.CPcardHolderName = cardHolderName;
                        cloverPaymentForm.CPauthCode = authCode;
                        cloverPaymentForm.CPAID = AID;
                        cloverPaymentForm.CPcvm = cvm;

                        cloverConnector.ShowMessage("Not enough fund on your card");

                        Form fc = Application.OpenForms["CloverPayment"];

                        if (fc != null)
                        {
                            cloverPaymentForm.CPpaymentID = paymentID;
                            cloverPaymentForm.CPorderID = orderID;
                            cloverPaymentForm.lblNotEnoughFund.Text = "Not enough fund on the customer's card, \n" + "please void this payment.";
                            //cloverPaymentForm.DeviceCurrentStatus.Text = "Not enough fund on the customer's card, \n" + "please void this payment.";
                            cloverPaymentForm.btnVoid.Visible = true;
                        }
                    }
                }, null);
            }
            else if (response.Result.Equals(ResponseCode.FAIL))
            {
                uiThread.Send(delegate (object state)
                {
                    //MessageBox.Show(response.Reason + "(" + response.Message + ")", "Payment is failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MyMessageBox.ShowBox("Payment is failed\n" + response.Reason + "(" + response.Message + ")", "ERROR");

                    Form fc = Application.OpenForms["CloverPayment"];

                    if (fc != null)
                    {
                        Resetting_CloverPayment();
                        cloverPaymentForm.btnCheckOut.Enabled = true;
                        cloverPaymentForm.btnCancel.Enabled = true;
                    }
                }, null);
            }
            else if (response.Result.Equals(ResponseCode.CANCEL))
            {
                uiThread.Send(delegate (object state)
                {
                    //MessageBox.Show(response.Reason + "(" + response.Message + ")", "Payment is canceled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MyMessageBox.ShowBox("Payment is canceled\n" + response.Reason + "(" + response.Message + ")", "ERROR");

                    Form fc = Application.OpenForms["CloverPayment"];

                    if (fc != null)
                    {
                        Resetting_CloverPayment();
                        cloverPaymentForm.btnCheckOut.Enabled = true;
                        cloverPaymentForm.btnCancel.Enabled = true;
                    }
                }, null);
            }
        }

        /// <summary>
        /// Called when [verify signature request].
        /// </summary>
        /// <param name="request">The request.</param>
        public void OnVerifySignatureRequest(VerifySignatureRequest request)
        {
            Form fc = Application.OpenForms["CloverPayment"];

            if (fc != null)
            {
                //CloverPayment parentForm = fc;
                uiThread.Send(delegate (object state)
                {
                    SignatureForm sigForm = new SignatureForm(fc);
                    sigForm.VerifySignatureRequest = request;
                    sigForm.Show();
                }, null);
            }

            /*if (autoApproveSigYes.Checked)
            {
                request.Accept();
            }
            else
            {
                Form1 parentForm = this;
                uiThread.Send(delegate(object state)
                {
                    SignatureForm sigForm = new SignatureForm(parentForm);
                    sigForm.VerifySignatureRequest = request;
                    sigForm.Show();
                }, null);
            }*/
        }

        /// <summary>
        /// Voids the credit transaction.
        /// </summary>
        /// <param name="PID">The pid.</param>
        /// <param name="OID">The oid.</param>
        /// <param name="RID">The rid.</param>
        /// <param name="AMT">The amt.</param>
        /// <param name="EMPID">The empid.</param>
        /// <param name="TYPE">The type.</param>
        public void Void_Credit_Transaction(string PID, string OID, Int64 RID, double AMT, string EMPID, string TYPE)
        {
            VoidPaymentRequest request = new VoidPaymentRequest();

            request.PaymentId = PID;
            //request.EmployeeId = payment.EmployeeID;
            request.OrderId = OID;
            request.VoidReason = "USER_CANCEL";

            VHPaymentID = PID;
            VHOrderID = OID;
            VHRefReceiptID = RID;
            VHAmount = AMT;
            VHEmployeeID = EMPID;
            VHType = TYPE;

            cloverConnector.VoidPayment(request);
        }

        /// <summary>
        /// Called when [void payment response].
        /// </summary>
        /// <param name="response">The response.</param>
        public void OnVoidPaymentResponse(VoidPaymentResponse response)
        {
            if (response.Success)
            {
                uiThread.Send(delegate (object state)
                {
                    //MessageBox.Show("The transaction was voided", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyMessageBox.ShowBox("THE TRANSACTION WAS VOIDED.", "INFORMATION");

                    Form fc = Application.OpenForms["Return"];
                    Form fc2 = Application.OpenForms["CloverPayment"];

                    if (fc != null)
                    {
                        returnForm.Void_Transaction();
                        Create_CardPayment_Void_History();
                    }

                    if (fc2 != null)
                    {
                        Create_CardPayment_Void_History();
                        cloverPaymentForm.Printing_Void_Payment();
                        cloverConnector.Cancel();
                        cloverPaymentForm.Close();
                    }

                }, null);
            }
            else if (response.Result.Equals(ResponseCode.FAIL))
            {
                uiThread.Send(delegate (object state)
                {
                    MessageBox.Show(response.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    VHPaymentID = string.Empty;
                    VHOrderID = string.Empty;
                    VHReceiptID = 0;
                    VHRefReceiptID = 0;
                    VHAmount = 0;
                    VHEmployeeID = string.Empty;
                    VHType = string.Empty;

                    Form fc = Application.OpenForms["Return"];

                    if (fc != null)
                    {
                        returnForm.btnVoid.Enabled = false;
                        returnForm.btnRefund.Enabled = false;
                    }
                }, null);
            }
        }

        /// <summary>
        /// Refunds the credit transaction.
        /// </summary>
        /// <param name="PID">The pid.</param>
        /// <param name="OID">The oid.</param>
        /// <param name="amt">The amt.</param>
        /// <param name="full">if set to <c>true</c> [full].</param>
        public void Refund_Credit_Transaction(string PID, string OID, double amt, bool full)
        {
            RefundPaymentRequest request = new RefundPaymentRequest();

            if (full)
            {
                request.PaymentId = PID;
                request.OrderId = OID;
                request.Amount = 0;
                request.FullRefund = true;
            }
            else
            {
                request.PaymentId = PID;
                request.OrderId = OID;
                request.Amount = Convert.ToInt64(amt * 100);
                request.FullRefund = false;
            }

            cloverConnector.RefundPayment(request);
        }

        /// <summary>
        /// Called when [refund payment response].
        /// </summary>
        /// <param name="response">The response.</param>
        public void OnRefundPaymentResponse(RefundPaymentResponse response)
        {
            if (response.Success)
            {
                uiThread.Send(delegate (object state)
                {
                    //MessageBox.Show("The transaction was refunded", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyMessageBox.ShowBox("THE TRANSACTION WAS REFUNDED", "INFORMATION");

                    Form fc = Application.OpenForms["Return"];

                    if (fc != null)
                    {
                        returnForm.Regular_Refund_Transaction();
                    }

                }, null);
            }
            else if (response.Result.Equals(ResponseCode.FAIL))
            {
                uiThread.Send(delegate (object state)
                {
                    //MessageBox.Show(response.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MyMessageBox.ShowBox(response.Message, "ERROR");

                    Form fc = Application.OpenForms["Return"];

                    if (fc != null)
                    {
                        returnForm.btnVoid.Enabled = false;
                        returnForm.btnRefund.Enabled = false;
                    }
                }, null);
            }
        }

        /// <summary>
        /// Manuals the refund credit transaction.
        /// </summary>
        /// <param name="amt">The amt.</param>
        public void Manual_Refund_Credit_Transaction(double amt)
        {
            ManualRefundRequest request = new ManualRefundRequest();
            request.ExternalId = ExternalIDUtil.GenerateRandomString(32);
            request.Amount = Convert.ToInt64(amt * 100);

            // Card Entry methods
            long CardEntry = 0;
            CardEntry |= returnForm.ManualEntryCheckbox.Checked ? CloverConnector.CARD_ENTRY_METHOD_MANUAL : 0;
            CardEntry |= returnForm.MagStripeCheckbox.Checked ? CloverConnector.CARD_ENTRY_METHOD_MAG_STRIPE : 0;
            CardEntry |= returnForm.ChipCheckbox.Checked ? CloverConnector.CARD_ENTRY_METHOD_ICC_CONTACT : 0;
            CardEntry |= returnForm.ContactlessCheckbox.Checked ? CloverConnector.CARD_ENTRY_METHOD_NFC_CONTACTLESS : 0;

            request.CardEntryMethods = CardEntry;
            request.DisablePrinting = true;
            request.DisableReceiptSelection = true;

            cloverConnector.ManualRefund(request);
        }

        /// <summary>
        /// Called when [manual refund response].
        /// </summary>
        /// <param name="response">The response.</param>
        public void OnManualRefundResponse(ManualRefundResponse response)
        {
            if (response.Success)
            {
                uiThread.Send(delegate (object state)
                {
                    CardTransaction cTransaction = new CardTransaction();
                    cTransaction = response.Credit.cardTransaction;
                    CardType cType = new CardType();
                    cType = cTransaction.cardType;
                    CardTransactionType cTransactionType = new CardTransactionType();
                    cTransactionType = cTransaction.type;

                    rAmount = Convert.ToDouble(response.Credit.amount);
                    creditID = response.Credit.id;
                    orderID = response.Credit.orderRef.id;
                    referenceID = cTransaction.referenceId;
                    createdTime = response.Credit.createdTime;
                    cardType = cType.ToString();
                    entryType = cTransaction.entryType.ToString();
                    transactionLabel = response.Credit.tender.label.ToUpper() + " REFUND";
                    last4 = cTransaction.last4;
                    cardHolderName = cTransaction.cardholderName;
                    authCode = cTransaction.authCode;

                    if (cTransaction.extra.ContainsKey("applicationIdentifier"))
                    {
                        AID = cTransaction.extra["applicationIdentifier"];
                    }
                    else
                    {
                        AID = "N/A";
                    }

                    if (cTransaction.extra.ContainsKey("cvmResult"))
                    {
                        cvm = cTransaction.extra["cvmResult"];
                    }
                    else
                    {

                    }

                    if (creditID == null)
                        creditID = "";

                    if (orderID == null)
                        orderID = "";

                    if (referenceID == null)
                        referenceID = "";

                    if (createdTime == 0)
                    {
                        cSellDate = string.Format("{0:MM/dd/yyyy}", DateTime.Now);
                        cSellTime = string.Format("{0:T}", DateTime.Now);
                    }
                    else
                    {
                        TimeSpan ts = TimeSpan.FromMilliseconds(Convert.ToDouble(createdTime));
                        DateTime uDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                        uDate += ts;
                        DateTime lDate = uDate.ToLocalTime();
                        cSellDate = string.Format("{0:MM/dd/yyyy}", lDate);
                        cSellTime = string.Format("{0:T}", lDate);
                    }

                    if (cardType == null)
                        cardType = "";

                    if (entryType == null)
                        entryType = "";

                    if (transactionLabel == null)
                        transactionLabel = "";

                    if (last4 == null)
                        last4 = "";

                    if (cardHolderName == null)
                        cardHolderName = "CARD USER";

                    if (authCode == null)
                        authCode = "";

                    if (cvm == null)
                        cvm = "";

                    string msg = "REFUND OF " + (response.Credit.amount / 100.0).ToString("C2") + " WAS APPLIED TO CARD ENDING WITH " + response.Credit.cardTransaction.last4;
                    //MessageBox.Show(this, "Refund applied", msg);
                    MyMessageBox.ShowBox(msg, "INFORMATION");

                    Form fc = Application.OpenForms["Return"];

                    if (fc != null)
                    {
                        returnForm.CPAmount = rAmount / 100;
                        returnForm.CPcreditID = creditID;
                        returnForm.CPorderID = orderID;
                        returnForm.CPexternalPaymentID = externalPaymentID;
                        returnForm.CPreferenceID = referenceID;
                        returnForm.CPcreatedTime = createdTime;
                        returnForm.CPsellDate = cSellDate;
                        returnForm.CPsellTime = cSellTime;
                        returnForm.CPcardType = cardType;
                        returnForm.CPentryType = entryType;
                        returnForm.CPtransactionLabel = transactionLabel;
                        returnForm.CPlast4 = last4;
                        returnForm.CPcardHolderName = cardHolderName;
                        returnForm.CPauthCode = authCode;
                        returnForm.CPAID = AID;
                        returnForm.CPcvm = cvm;

                        returnForm.Manual_Refund_Transaction();

                        Resetting_CloverPayment();
                    }
                }, null);
            }
            else if (response.Result.Equals(ResponseCode.FAIL))
            {
                uiThread.Send(delegate (object state)
                {
                    //MessageBox.Show(this, response.Reason, response.Message);
                    MyMessageBox.ShowBox(response.Message, "ERROR");

                    Form fc = Application.OpenForms["Return"];

                    if (fc != null)
                    {
                        if (returnForm.option == 0)
                            returnForm.btnVoid.Enabled = true;

                        returnForm.btnRefund.Enabled = true;
                        returnForm.btnClose.Enabled = true;
                    }
                }, null);
            }
            else if (response.Result.Equals(ResponseCode.CANCEL))
            {
                uiThread.Send(delegate (object state)
                {
                    //MessageBox.Show(this, response.Reason, response.Message);
                    MyMessageBox.ShowBox(response.Message, "ERROR");

                    Form fc = Application.OpenForms["Return"];

                    if (fc != null)
                    {
                        if (returnForm.option == 0)
                            returnForm.btnVoid.Enabled = true;

                        returnForm.btnRefund.Enabled = true;
                        returnForm.btnClose.Enabled = true;
                    }
                }, null);
            }
        }

        /// <summary>
        /// Settlements this instance.
        /// </summary>
        public void Settlement()
        {
            cloverConnector.Closeout(new CloseoutRequest());
        }

        /// <summary>
        /// Called when [closeout response].
        /// </summary>
        /// <param name="response">The response.</param>
        public void OnCloseoutResponse(CloseoutResponse response)
        {
            if (response != null && response.Success)
            {
                uiThread.Send(delegate (object state)
                {
                    try
                    {
                        BatchID = response.Batch.id;
                        BatchDevice = response.Batch.devices;
                        BatchMerchantID = response.Batch.merchantId;
                        BatchCount = response.Batch.txCount;
                        BatchTotalAmount = Convert.ToDouble(response.Batch.totalBatchAmount);
                        BatchCreatedTime = response.Batch.createdTime;


                        if (BatchID == null)
                            BatchID = "";

                        if (BatchDevice == null)
                            BatchDevice = "";

                        SqlCommand cmd_Settlement = new SqlCommand("Create_CloverBatchHistory", conn);
                        cmd_Settlement.CommandType = CommandType.StoredProcedure;
                        cmd_Settlement.Parameters.Add("@BatchID", SqlDbType.NVarChar).Value = BatchID;
                        cmd_Settlement.Parameters.Add("@BatchRegisterNum", SqlDbType.NVarChar).Value = cashRegisterNum;
                        cmd_Settlement.Parameters.Add("@BatchDevice", SqlDbType.NVarChar).Value = BatchDevice;
                        cmd_Settlement.Parameters.Add("@BatchMerchantID", SqlDbType.BigInt).Value = BatchMerchantID;
                        cmd_Settlement.Parameters.Add("@BatchCount", SqlDbType.BigInt).Value = BatchCount;
                        cmd_Settlement.Parameters.Add("@BatchTotalAmount", SqlDbType.Money).Value = BatchTotalAmount / 100;
                        cmd_Settlement.Parameters.Add("@BatchCreatedTime", SqlDbType.BigInt).Value = BatchCreatedTime;
                        cmd_Settlement.Parameters.Add("@BatchDateTime", SqlDbType.DateTime).Value = DateTime.Now;
                        cmd_Settlement.Parameters.Add("@BatchUserID", SqlDbType.NVarChar).Value = BatchUserID;

                        conn.Open();
                        cmd_Settlement.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch
                    {
                        if (conn.State == ConnectionState.Open)
                            conn.Close();

                        MyMessageBox.ShowBox("BATCH HISTORY CREATION FAILED...", "ERROR");
                    }

                    //AlertForm.Show(this, "Batch Closed", "Batch " + response.Batch.id + " was successfully processed.");
                    MyMessageBox.ShowBox("BATCH " + response.Batch.id + " WAS SUCCESSFULLY PROCESSED.", "INFORMATION");
                    Resetting_Settlement();
                }, null);

            }
            if (response != null && response.Result.Equals(ResponseCode.FAIL))
            {
                uiThread.Send(delegate (object state)
                {
                    //AlertForm.Show(this, "Close Attempt Failed", "Reason: " + response.Reason + ".");
                    MyMessageBox.ShowBox("CLOSE ATTEMPT FAILED(Reason: " + response.Reason + ").", "ERROR");
                    Resetting_Settlement();
                }, null);
            }
        }

        /// <summary>
        /// Called when [vault card response].
        /// </summary>
        /// <param name="vcResponse">The vc response.</param>
        public void OnVaultCardResponse(VaultCardResponse vcResponse)
        {
        }

        /// <summary>
        /// Called when [authentication response].
        /// </summary>
        /// <param name="response">The response.</param>
        public void OnAuthResponse(AuthResponse response)
        {
        }

        /// <summary>
        /// Called when [capture pre authentication response].
        /// </summary>
        /// <param name="response">The response.</param>
        public void OnCapturePreAuthResponse(CapturePreAuthResponse response)
        {
        }

        /// <summary>
        /// Called when [tip added].
        /// </summary>
        /// <param name="message">The message.</param>
        public void OnTipAdded(TipAddedMessage message)
        {
        }

        /// <summary>
        /// Called when [tip adjust authentication response].
        /// </summary>
        /// <param name="response">The response.</param>
        public void OnTipAdjustAuthResponse(TipAdjustAuthResponse response)
        {
        }

        /// <summary>
        /// Called when [pre authentication response].
        /// </summary>
        /// <param name="response">The response.</param>
        public void OnPreAuthResponse(PreAuthResponse response)
        {
        }

        /// <summary>
        /// Called when [retrieve pending payments response].
        /// </summary>
        /// <param name="response">The response.</param>
        public void OnRetrievePendingPaymentsResponse(RetrievePendingPaymentsResponse response)
        {
            uiThread.Send(delegate (object state)
            {
                /*pendingPaymentListView.Items.Clear();
                Console.WriteLine(response.PendingPayments.Count);
                foreach (PendingPaymentEntry ppe in response.PendingPayments)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Tag = ppe;
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem());
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem());

                    lvi.SubItems[0].Text = ppe.paymentId;
                    lvi.SubItems[1].Text = (ppe.amount / 100.0).ToString("C2");

                    pendingPaymentListView.Items.Add(lvi);
                }*/
            }, null);
        }

        /// <summary>
        /// Called when [print manual refund receipt].
        /// </summary>
        /// <param name="printManualRefundReceiptMessage">The print manual refund receipt message.</param>
        public virtual void OnPrintManualRefundReceipt(PrintManualRefundReceiptMessage printManualRefundReceiptMessage)
        {
            uiThread.Send(delegate (object state)
            {
                //AlertForm.Show(this, "Print ManualRefund Receipt", (printManualRefundReceiptMessage.Credit.amount / 100.0).ToString("C2"));
            }, null);
        }

        /// <summary>
        /// Called when [print manual refund decline receipt].
        /// </summary>
        /// <param name="printManualRefundDeclineReceiptMessage">The print manual refund decline receipt message.</param>
        public virtual void OnPrintManualRefundDeclineReceipt(PrintManualRefundDeclineReceiptMessage printManualRefundDeclineReceiptMessage)
        {
            uiThread.Send(delegate (object state)
            {
                //AlertForm.Show(this, "Print ManualRefund Declined Receipt", printManualRefundDeclineReceiptMessage.Reason);
            }, null);
        }

        /// <summary>
        /// Called when [print payment receipt].
        /// </summary>
        /// <param name="printPaymentReceiptMessage">The print payment receipt message.</param>
        public virtual void OnPrintPaymentReceipt(PrintPaymentReceiptMessage printPaymentReceiptMessage)
        {
            uiThread.Send(delegate (object state)
            {
                //AlertForm.Show(this, "Print Payment Receipt", (printPaymentReceiptMessage.Payment.amount / 100.0).ToString("C2"));
            }, null);
        }

        /// <summary>
        /// Called when [print payment decline receipt].
        /// </summary>
        /// <param name="printPaymentDeclineReceiptMessage">The print payment decline receipt message.</param>
        public virtual void OnPrintPaymentDeclineReceipt(PrintPaymentDeclineReceiptMessage printPaymentDeclineReceiptMessage)
        {
            uiThread.Send(delegate (object state)
            {
                //AlertForm.Show(this, "Print Payment Declined Receipt", printPaymentDeclineReceiptMessage.Reason);
            }, null);
        }

        /// <summary>
        /// Called when [print payment merchant copy receipt].
        /// </summary>
        /// <param name="printPaymentMerchantCopyReceiptMessage">The print payment merchant copy receipt message.</param>
        public virtual void OnPrintPaymentMerchantCopyReceipt(PrintPaymentMerchantCopyReceiptMessage printPaymentMerchantCopyReceiptMessage)
        {
            uiThread.Send(delegate (object state)
            {
                //AlertForm.Show(this, "Print Merchant Payment Copy Receipt", (printPaymentMerchantCopyReceiptMessage.Payment.amount / 100.0).ToString("C2"));
            }, null);
        }

        /// <summary>
        /// Called when [print refund payment receipt].
        /// </summary>
        /// <param name="printRefundPaymentReceiptMessage">The print refund payment receipt message.</param>
        public virtual void OnPrintRefundPaymentReceipt(PrintRefundPaymentReceiptMessage printRefundPaymentReceiptMessage)
        {
            uiThread.Send(delegate (object state)
            {
                //AlertForm.Show(this, "Print Refund Payment Receipt", (printRefundPaymentReceiptMessage.Refund.amount / 100.0).ToString("C2"));
            }, null);
        }

        /// <summary>
        /// Called when [read card data response].
        /// </summary>
        /// <param name="rcdResponse">The RCD response.</param>
        public void OnReadCardDataResponse(ReadCardDataResponse rcdResponse)
        {
            String screenResponseMsg = "";
            if (rcdResponse.Success && rcdResponse.CardData != null &&
                (rcdResponse.CardData.Track1 != null ||
                 rcdResponse.CardData.Track2 != null ||
                 rcdResponse.CardData.Pan != null))
            {

                uiThread.Send(delegate (object state)
                {
                    if (rcdResponse.CardData.Track1 != null)
                    {
                        screenResponseMsg = "Track1: " + rcdResponse.CardData.Track1;
                    }
                    else
                    {
                        if (rcdResponse.CardData.Track2 != null)
                        {
                            screenResponseMsg = "Track2: " + rcdResponse.CardData.Track2;
                        }
                        else
                        {
                            screenResponseMsg = "Pan: " + rcdResponse.CardData.Pan;
                        }
                    }
                    //AlertForm.Show(this, "Card Data Info", screenResponseMsg);
                }, null);
            }
            else
            {
                uiThread.Send(delegate (object state)
                {
                    if (rcdResponse.Success)
                    {
                        screenResponseMsg = "Card track and pan information was blank.";
                    }
                    else
                    {
                        screenResponseMsg = "Card was not successfully read";
                    }
                    //AlertForm.Show(this, rcdResponse.Reason, screenResponseMsg);
                }, null);
            }
        }

        /// <summary>
        /// Applications the shutdown.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AppShutdown(object sender, EventArgs e)
        {
            if (cloverConnector != null)
            {
                try
                {
                    cloverConnector.Dispose();
                }
                catch (Exception)
                {
                    cloverConnector = null;
                }
            }
        }

        /// <summary>
        /// Resettings the clover payment.
        /// </summary>
        public void Resetting_CloverPayment()
        {
            rAmount = 0;
            paymentID = null;
            orderID = null;
            externalPaymentID = null;
            creditID = null;
            referenceID = null;
            createdTime = 0;
            cSellDate = null;
            cSellTime = null;
            cardType = null;
            entryType = null;
            transactionLabel = null;
            last4 = null;
            cardHolderName = null;
            authCode = null;
            AID = "N/A";
            cvm = null;
            TempAmount = 0;
        }

        /// <summary>
        /// Resettings the settlement.
        /// </summary>
        private void Resetting_Settlement()
        {
            BatchID = null;
            BatchDevice = null;
            BatchMerchantID = 0;
            BatchCount = 0;
            BatchTotalAmount = 0;
            BatchCreatedTime = 0;
            BatchUserID = "DEFAULT";
        }

        /// <summary>
        /// Gets the handler.
        /// </summary>
        /// <param name="io">The io.</param>
        /// <returns>EventHandler.</returns>
        public EventHandler getHandler(InputOption io)
        {
            return new EventHandler(delegate (object sender, EventArgs args)
            {
                cloverConnector.InvokeInputOption(io);
            });
        }

        /// <summary>
        /// Handles the Click event of the button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd_Settlement = new SqlCommand("Create_CloverBatchHistory", conn);
                cmd_Settlement.CommandType = CommandType.StoredProcedure;
                cmd_Settlement.Parameters.Add("@BatchID", SqlDbType.NVarChar).Value = 1234567;
                cmd_Settlement.Parameters.Add("@BatchDevice", SqlDbType.NVarChar).Value = "AAAAAAAAA";
                cmd_Settlement.Parameters.Add("@BatchMerchantID", SqlDbType.BigInt).Value = 1234566;
                cmd_Settlement.Parameters.Add("@BatchCount", SqlDbType.BigInt).Value = 50;
                cmd_Settlement.Parameters.Add("@BatchTotalAmount", SqlDbType.Money).Value = Convert.ToDouble(500000) / 100;
                cmd_Settlement.Parameters.Add("@BatchCreatedTime", SqlDbType.BigInt).Value = 123455465;
                cmd_Settlement.Parameters.Add("@BatchDateTime", SqlDbType.DateTime).Value = DateTime.Now;

                conn.Open();
                cmd_Settlement.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                conn.Close();
                MyMessageBox.ShowBox("BATCH HISTORY CREATION FAILED...", "ERROR");
            }
        }

        /// <summary>
        /// Called when [custom activity response].
        /// </summary>
        /// <param name="response">The response.</param>
        public virtual void OnCustomActivityResponse(CustomActivityResponse response)
        {
            uiThread.Send(delegate (object state)
            {
                /*try
                {
                    dynamic parsedPayload = JsonConvert.DeserializeObject(response.Payload);
                    string formattedPayload = JsonConvert.SerializeObject(parsedPayload, Formatting.Indented);
                    Console.WriteLine(formattedPayload);

                    AlertForm.Show(this, "Custom Activity Response" + (response.Success ? "" : ": Canceled"), formattedPayload);
                }
                catch (Exception e)
                {
                    AlertForm.Show(this, "Custom Activity Response" + (response.Success ? "" : ": Canceled"), response.Payload);
                }*/
            }, null);
        }

        /// <summary>
        /// Handles the Click event of the btnClearLineDisc control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnClearLineDisc_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            if (Convert.ToString(dataGridView1.SelectedCells[7].Value) == pointRedeemBarcode)
            {

            }
            else if (Convert.ToString(dataGridView1.SelectedCells[7].Value) == giftCardBarcode)
            {

            }
            else if (Convert.ToString(dataGridView1.SelectedCells[7].Value) == couponBarcode)
            {

            }
            else
            {
                DCQty = Convert.ToInt16(dataGridView1.SelectedCells[2].Value);
                DCUnitPrice = Convert.ToDouble(dataGridView1.SelectedCells[3].Value);
                DCPrice = DCUnitPrice * DCQty;
                DCTax = DCPrice * storeTaxRate;
                dataGridView1.SelectedCells[4].Value = 0.00;
                dataGridView1.SelectedCells[5].Value = DCPrice;
                dataGridView1.SelectedCells[6].Value = Math.Round(DCTax, 2, MidpointRounding.AwayFromZero);
            }

            smCashierID = "";
            smDiscount = false;
            eCashierID = "";
            eDiscount1 = false;
            Calculation();
            Calculating_Saved_Amount();
            LineDisply(openingMSG1, openingMSG2);
            richTxtUpc.Focus();
            richTxtUpc.Select();
        }

        /// <summary>
        /// Handles the Click event of the btnClearAllDisc control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnClearAllDisc_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (Convert.ToString(dataGridView1.Rows[i].Cells[7].Value) == pointRedeemBarcode)
                {

                }
                else if (Convert.ToString(dataGridView1.Rows[i].Cells[7].Value) == giftCardBarcode)
                {

                }
                else if (Convert.ToString(dataGridView1.Rows[i].Cells[7].Value) == couponBarcode)
                {

                }
                else
                {
                    DCQty = Convert.ToInt16(dataGridView1.Rows[i].Cells[2].Value);
                    DCUnitPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                    DCPrice = DCUnitPrice * DCQty;
                    DCTax = DCPrice * storeTaxRate;
                    dataGridView1.Rows[i].Cells[4].Value = 0.00;
                    dataGridView1.Rows[i].Cells[5].Value = DCPrice;
                    dataGridView1.Rows[i].Cells[6].Value = Math.Round(DCTax, 2, MidpointRounding.AwayFromZero);
                }
            }

            smCashierID = "";
            smDiscount = false;
            eCashierID = "";
            eDiscount1 = false;
            Calculation();
            Calculating_Saved_Amount();
            LineDisply(openingMSG1, openingMSG2);
            richTxtUpc.Focus();
            richTxtUpc.Select();
        }

        /// <summary>
        /// Called when [message from activity].
        /// </summary>
        /// <param name="message">The message.</param>
        public void OnMessageFromActivity(MessageFromActivity message)
        {
            /*PayloadMessage payloadMessage = JsonConvert.DeserializeObject<PayloadMessage>(message.Payload);
            switch (payloadMessage.messageType)
            {
                case MessageType.REQUEST_RATINGS:
                    handleRequestRatings();
                    break;
                case MessageType.RATINGS:
                    handleRatings(message.Payload);
                    break;
                case MessageType.PHONE_NUMBER:
                    handleCustomerLookup(message.Payload);
                    break;
                case MessageType.CONVERSATION_RESPONSE:
                    handleJokeResponse(message.Payload);
                    break;
                default:
                    break;
            }*/
        }

        /// <summary>
        /// Called when [retrieve device status response].
        /// </summary>
        /// <param name="response">The response.</param>
        public virtual void OnRetrieveDeviceStatusResponse(RetrieveDeviceStatusResponse response)
        {
            uiThread.Send(delegate (object state)
            {
                //AlertForm.Show(this, "OnRetrieveDeviceStatusResponse: ", response.State + ":" + JsonUtils.serialize(response.Data));
            }, null);
        }

        /// <summary>
        /// Called when [reset device response].
        /// </summary>
        /// <param name="response">The response.</param>
        public virtual void OnResetDeviceResponse(ResetDeviceResponse response)
        {
            uiThread.Send(delegate (object state)
            {
                //AlertForm.Show(this, "OnResetDeviceResponse", response.State.ToString());
            }, null);
        }

        /// <summary>
        /// Called when [retrieve payment response].
        /// </summary>
        /// <param name="response">The response.</param>
        public void OnRetrievePaymentResponse(RetrievePaymentResponse response)
        {
            /*if (response.Success)
            {
                uiThread.Send(delegate (object state)
                {
                    String details = "No matching payment";
                    Payment payment = response.Payment;
                    if (payment != null)
                    {
                        details = "Created:" + dateFormat(payment.createdTime) + "\nResult: " + payment.result
                       + "\nPaymentId: " + payment.id + "\nOrderId: " + payment.order.id
                        + "\nAmount: " + currencyFormat(payment.amount) + " Tip: " + currencyFormat(payment.tipAmount) + " Tax: " + currencyFormat(payment.taxAmount);
                    }
                    AlertForm.Show(this, response.QueryStatus.ToString(), details);
                }, null);
            }
            else if (response.Result.Equals(ResponseCode.FAIL))
            {
                uiThread.Send(delegate (object state)
                {
                    AlertForm.Show(this, response.Reason, response.Message);
                }, null);
            }
            else if (response.Result.Equals(ResponseCode.CANCEL))
            {
                uiThread.Send(delegate (object state)
                {
                    AlertForm.Show(this, response.Reason, response.Message);
                }, null);
            }*/
        }

        /// <summary>
        /// Displays the item on clover.
        /// </summary>
        public void DisplayItemOnClover()
        {
            /*DisplayLineItem displayLineItem = null;

            if (displayLineItem == null)
            {
                displayLineItem = DisplayFactory.createDisplayLineItem();
                displayLineItem.name = dataGridView1.SelectedCells[1].Value.ToString();
                displayLineItem.quantity = dataGridView1.SelectedCells[2].Value.ToString();
                //displayLineItem.unitPrice = string.Format("{0:$0.00}", Convert.ToDouble(dataGridView1.SelectedCells[3].Value));
                displayLineItem.price = string.Format("{0:$0.00}", Convert.ToDouble(dataGridView1.SelectedCells[5].Value));
                DisplayOrder.addDisplayLineItem(displayLineItem);
                UpdateDisplayOrderTotals();
                cloverConnector.ShowDisplayOrder(DisplayOrder);

            }
            else
            {
                //displayLineItem.quantity = lineItem.Quantity.ToString();
                //UpdateDisplayOrderTotals();
                cloverConnector.ShowDisplayOrder(DisplayOrder);
            }*/

            POSItem item = new POSItem(dataGridView1.SelectedRows[0].Index.ToString(), dataGridView1.SelectedCells[1].Value.ToString(), Convert.ToInt32(dataGridView1.SelectedCells[5].Value) * 100);
            POSLineItem lineItem = new POSLineItem();
            lineItem.Item = item;

            DisplayLineItem displayLineItem = null;
            posLineItemToDisplayLineItem.TryGetValue(lineItem, out displayLineItem);
            if (displayLineItem == null)
            {
                displayLineItem = DisplayFactory.createDisplayLineItem();
                posLineItemToDisplayLineItem[lineItem] = displayLineItem;
                displayLineItem.quantity = dataGridView1.SelectedCells[2].Value.ToString();
                displayLineItem.name = lineItem.Item.Name;
                //displayLineItem.price = (lineItem.Item.Price / 100.0).ToString("C2");
                displayLineItem.price = string.Format("{0:$0.00}", Convert.ToDouble(dataGridView1.SelectedCells[5].Value));
                DisplayOrder.addDisplayLineItem(displayLineItem);
                UpdateDisplayOrderTotals();
                UpdateOrderItem();
                cloverConnector.ShowDisplayOrder(DisplayOrder);              
            }
            else
            {
                displayLineItem.quantity = lineItem.Quantity.ToString();
                UpdateDisplayOrderTotals();
                cloverConnector.ShowDisplayOrder(DisplayOrder);
            }
        }

        /// <summary>
        /// Updates the order item.
        /// </summary>
        private void UpdateOrderItem()
        {
            OrderItems.Items.Clear();

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                POSItem item = new POSItem(i.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString(), Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value) * 100);
                POSLineItem lineItem = new POSLineItem();
                lineItem.Item = item;

                ListViewItem lvi = new ListViewItem();

                lvi.Tag = lineItem;
                lvi.Name = lineItem.Item.Name;

                lvi.SubItems.Add(new ListViewItem.ListViewSubItem());
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem());
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem());

                lvi.SubItems[0].Text = "" + lineItem.Quantity;
                lvi.SubItems[1].Text = lineItem.Item.Name;
                lvi.SubItems[2].Text = (lineItem.Item.Price / 100.0).ToString("C2");
 
                OrderItems.Items.Add(lvi);
            }
        }

        /// <summary>
        /// Updates the display order totals.
        /// </summary>
        public void UpdateDisplayOrderTotals()
        {
            DisplayOrder.tax = string.Format("{0:$0.00}", calTax);
            DisplayOrder.subtotal = string.Format("{0:$0.00}", calSubTotal);
            DisplayOrder.total = string.Format("{0:$0.00}", calGrandTotal);
        }

        /// <summary>
        /// Handles the Click event of the button2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                //POSItem D_item = new POSItem(dataGridView1.SelectedRows[0].Index.ToString(), dataGridView1.SelectedCells[1].Value.ToString(), Convert.ToInt32(dataGridView1.SelectedCells[5].Value) * 100);
                //POSLineItem lineItem = new POSLineItem();
                //lineItem.Item = D_item;

                POSLineItem lineItem = (POSLineItem)((DataGridViewRow)dataGridView1.SelectedRows[0]).Tag;
                SelectedLineItem = lineItem;
                DisplayLineItem dli = posLineItemToDisplayLineItem[lineItem];
                DisplayOrder.removeDisplayLineItem(dli);
                UpdateDisplayOrderTotals();
                cloverConnector.ShowDisplayOrder(DisplayOrder);

                this.dataGridView1.Rows.Remove(item);

                OrderItems.Items[0].Selected = true;
            }
        }

        /// <summary>
        /// Creates the card payment void history.
        /// </summary>
        public void Create_CardPayment_Void_History()
        {
            try
            {
                SqlCommand cmd_VH = new SqlCommand("Create_CardPayment_Void_History", conn);
                cmd_VH.CommandType = CommandType.StoredProcedure;
                cmd_VH.Parameters.Add("@VHPaymentID", SqlDbType.NVarChar).Value = VHPaymentID;
                cmd_VH.Parameters.Add("@VHOrderID", SqlDbType.NVarChar).Value = VHOrderID;
                cmd_VH.Parameters.Add("@VHReceiptID", SqlDbType.BigInt).Value = VHReceiptID;
                cmd_VH.Parameters.Add("@VHRefReceiptID", SqlDbType.BigInt).Value = VHRefReceiptID;
                cmd_VH.Parameters.Add("@VHAmount", SqlDbType.Money).Value = VHAmount;
                cmd_VH.Parameters.Add("@VHEmployeeID", SqlDbType.NVarChar).Value = VHEmployeeID;
                cmd_VH.Parameters.Add("@VHDateTime", SqlDbType.DateTime).Value = DateTime.Now;
                cmd_VH.Parameters.Add("@VHType", SqlDbType.NVarChar).Value = VHType;

                conn.Open();
                cmd_VH.ExecuteNonQuery();
                conn.Close();

                VHPaymentID = string.Empty;
                VHOrderID = string.Empty;
                VHReceiptID = 0;
                VHRefReceiptID = 0;
                VHAmount = 0;
                VHEmployeeID = string.Empty;
                VHType = string.Empty;
            }
            catch
            {
                VHPaymentID = string.Empty;
                VHOrderID = string.Empty;
                VHReceiptID = 0;
                VHRefReceiptID = 0;
                VHAmount = 0;
                VHEmployeeID = string.Empty;
                VHType = string.Empty;

                conn.Close();
                MyMessageBox.ShowBox("DB CONNECTION FAILED", "ERROR");
                return;
            }
        }

        public void btnSecondVisitCoupon_Click(object sender, EventArgs e)
        {
            if (CouponAmt > 0)
            {
                MyMessageBox.ShowBox("ONLY ONE COUPON ALLOWED FOR EACH TRANSACTION", "ERROR");
                richTxtUpc.Select();
                richTxtUpc.Focus();
                return;
            }
            else
            {
                if (Convert.ToDouble(lblSubTotal.Text.Substring(1)) < 5.00)
                {
                    MyMessageBox.ShowBox("YOU MUST PURCHASE MORE THAN $5 TO USE SECOND VISIT COUPON.", "ERROR");
                    richTxtUpc.Select();
                    richTxtUpc.Focus();
                    return;
                }
                else
                {
                    CouponAmt = 5;
                    CouponDesc = "SECOND VISIT $5 COUPON";
                    boolNumSecondVisitCoupon = true;
                    //CouponMgrID = managerID;
                    richTxtUpc.Text = "000000999109";
                    btnInput_Click(null, null);

                    richTxtUpc.Select();
                    richTxtUpc.Focus();
                }
            }
        }
    }
}