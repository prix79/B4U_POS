// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 09-28-2017
// ***********************************************************************
// <copyright file="ReprintReceipt.cs" company="Beauty4u">
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
using System.Drawing.Printing;
using System.Data.SqlClient;
using apiAlias = StatusAPI;

/// <summary>
/// The Register namespace.
/// </summary>
namespace Register
{
    /// <summary>
    /// Class ReprintReceipt.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class ReprintReceipt : Form
    {
        /// <summary>
        /// The parent form
        /// </summary>
        public MainForm parentForm;

        /// <summary>
        /// The rr receipt identifier
        /// </summary>
        Int64 rrReceiptID;
        /// <summary>
        /// The rr store code
        /// </summary>
        string rrStoreCode;
        /// <summary>
        /// The rr cashier identifier
        /// </summary>
        string rrCashierID;
        /// <summary>
        /// The rr register number
        /// </summary>
        string rrRegisterNum;
        /// <summary>
        /// The rr member identifier
        /// </summary>
        string rrMemberID;
        /// <summary>
        /// The rr member name
        /// </summary>
        string rrMemberName;
        /// <summary>
        /// The rr pay by
        /// </summary>
        int rrPayBy;
        /// <summary>
        /// The rr sell date
        /// </summary>
        string rrSellDate;
        /// <summary>
        /// The rr sell time
        /// </summary>
        string rrSellTime;
        /// <summary>
        /// The rr sub total
        /// </summary>
        double rrSubTotal;
        /// <summary>
        /// The rr tax
        /// </summary>
        double rrTax;
        /// <summary>
        /// The rr grand total
        /// </summary>
        double rrGrandTotal;
        /// <summary>
        /// The rr discount
        /// </summary>
        double rrDiscount;
        /// <summary>
        /// The rr member points
        /// </summary>
        double rrMemberPoints;
        /// <summary>
        /// The rr pay
        /// </summary>
        double rrPay;
        /// <summary>
        /// The rr change
        /// </summary>
        double rrChange;

        /// <summary>
        /// The rr cash pay
        /// </summary>
        double rrCashPay;
        /// <summary>
        /// The rr credit pay
        /// </summary>
        double rrCreditPay;
        /// <summary>
        /// The rr debit pay
        /// </summary>
        double rrDebitPay;
        /// <summary>
        /// The rr t creditpay
        /// </summary>
        double rrTCreditpay;
        /// <summary>
        /// The rr giftcard
        /// </summary>
        double rrGiftcard;
        /// <summary>
        /// The rr store credit
        /// </summary>
        double rrStoreCredit;

        /// <summary>
        /// The rr itm name
        /// </summary>
        string rrItmName;
        /// <summary>
        /// The rr itm upc
        /// </summary>
        string rrItmUpc;
        /// <summary>
        /// The rr itm base price
        /// </summary>
        double rrItmBasePrice;
        /// <summary>
        /// The rr itm discount price
        /// </summary>
        double rrItmDiscountPrice;
        /// <summary>
        /// The rr itm price
        /// </summary>
        double rrItmPrice;
        /// <summary>
        /// The rr itm qty
        /// </summary>
        string rrItmQty;
        /// <summary>
        /// The rr itm original price
        /// </summary>
        double rrItmOriginalPrice;
        /// <summary>
        /// The rr itm save
        /// </summary>
        double rrItmSave;

        /// <summary>
        /// The rr remaining points
        /// </summary>
        double rrRemainingPoints;

        /// <summary>
        /// The rr store credit identifier
        /// </summary>
        Int64 rrStoreCreditID = 0;
        //double rrAmount;
        /// <summary>
        /// The rr balance
        /// </summary>
        double rrBalance = 0;
        /// <summary>
        /// The rr exp date
        /// </summary>
        string rrExpDate = "";

        /// <summary>
        /// The pd print
        /// </summary>
        PrintDocument pdPrint;
        //PrintDocument pdPrint0;
        //PrintDocument pdPrint1;
        //PrintDocument pdPrint3;
        //PrintDocument pdPrint4;
        //PrintDocument pdPrint5;
        //PrintDocument pdPrint6;
        //PrintDocument pdPrint7;
        //PrintDocument pdPrint8;
        //PrintDocument pdPrint77;
        //PrintDocument pdPrint88;
        //PrintDocument pdPrint99;
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
        /// The numoftransaction
        /// </summary>
        int numoftransaction;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReprintReceipt"/> class.
        /// </summary>
        public ReprintReceipt()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the ReprintReceipt control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ReprintReceipt_Load(object sender, EventArgs e)
        {
            txtSellDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

            txtReceiptID.Select();
            txtReceiptID.Focus();
        }

        /// <summary>
        /// Handles the Click event of the btnPrint control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (Int64.TryParse(txtReceiptID.Text, out rrReceiptID))
            {
                rrReceiptID = Convert.ToInt64(txtReceiptID.Text);

                SqlCommand cmd = new SqlCommand("Get_ReceiptID_All_Info", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@rrReceiptID", SqlDbType.BigInt).Value = rrReceiptID;
                SqlParameter StoreCode_Param = cmd.Parameters.Add("@rrStoreCode", SqlDbType.NVarChar, 20);
                SqlParameter CashierID_Param = cmd.Parameters.Add("@rrCashierID", SqlDbType.NVarChar, 50);
                SqlParameter RegisterNum_Param = cmd.Parameters.Add("@rrRegisterNum", SqlDbType.NVarChar, 20);
                SqlParameter MemberID_Param = cmd.Parameters.Add("@rrMemberID", SqlDbType.NVarChar, 50);
                SqlParameter MemberName_Param = cmd.Parameters.Add("@rrMemberName", SqlDbType.NVarChar, 50);
                SqlParameter PayBy_Param = cmd.Parameters.Add("@rrPayBy", SqlDbType.Int);
                SqlParameter SellDate_Param = cmd.Parameters.Add("@rrSellDate", SqlDbType.NVarChar, 20);
                SqlParameter SellTime_Param = cmd.Parameters.Add("@rrSellTime", SqlDbType.NVarChar, 20);
                SqlParameter SubTotal_Param = cmd.Parameters.Add("@rrSubTotal", SqlDbType.Money);
                SqlParameter Tax_Param = cmd.Parameters.Add("@rrTax", SqlDbType.Money);
                SqlParameter GrandTotal_Param = cmd.Parameters.Add("@rrGrandTotal", SqlDbType.Money);
                SqlParameter Discount_Param = cmd.Parameters.Add("@rrDiscount", SqlDbType.Money);
                SqlParameter MemberPoints_Param = cmd.Parameters.Add("@rrMemberPoints", SqlDbType.Money);
                SqlParameter Pay_Param = cmd.Parameters.Add("@rrPay", SqlDbType.Money);
                SqlParameter Change_Param = cmd.Parameters.Add("@rrChange", SqlDbType.Money);
                StoreCode_Param.Direction = ParameterDirection.Output;
                CashierID_Param.Direction = ParameterDirection.Output;
                RegisterNum_Param.Direction = ParameterDirection.Output;
                MemberID_Param.Direction = ParameterDirection.Output;
                MemberName_Param.Direction = ParameterDirection.Output;
                PayBy_Param.Direction = ParameterDirection.Output;
                SellDate_Param.Direction = ParameterDirection.Output;
                SellTime_Param.Direction = ParameterDirection.Output;
                SubTotal_Param.Direction = ParameterDirection.Output;
                Tax_Param.Direction = ParameterDirection.Output;
                GrandTotal_Param.Direction = ParameterDirection.Output;
                Discount_Param.Direction = ParameterDirection.Output;
                MemberPoints_Param.Direction = ParameterDirection.Output;
                Pay_Param.Direction = ParameterDirection.Output;
                Change_Param.Direction = ParameterDirection.Output;

                parentForm.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm.conn.Close();

                if (cmd.Parameters["@rrGrandTotal"].Value == DBNull.Value)
                {
                    MyMessageBox.ShowBox("INVALID RECEIPT ID", "ERROR");
                    //MessageBox.Show("Invalid receipt ID", "Error");
                    txtReceiptID.Select();
                    txtReceiptID.Focus();
                    return;
                }

                rrStoreCode = Convert.ToString(cmd.Parameters["@rrStoreCode"].Value);
                rrCashierID = Convert.ToString(cmd.Parameters["@rrCashierID"].Value);
                rrRegisterNum = Convert.ToString(cmd.Parameters["@rrRegisterNum"].Value);
                rrMemberID = Convert.ToString(cmd.Parameters["@rrMemberID"].Value);
                rrMemberName = Convert.ToString(cmd.Parameters["@rrMemberName"].Value);
                rrPayBy = Convert.ToInt16(cmd.Parameters["@rrPayBy"].Value);
                rrSellDate = Convert.ToString(cmd.Parameters["@rrSellDate"].Value);
                rrSellTime = Convert.ToString(cmd.Parameters["@rrSellTime"].Value);
                rrSubTotal = Convert.ToDouble(cmd.Parameters["@rrSubTotal"].Value);
                rrTax = Convert.ToDouble(cmd.Parameters["@rrTax"].Value);
                rrGrandTotal = Convert.ToDouble(cmd.Parameters["@rrGrandTotal"].Value);
                rrDiscount = Convert.ToDouble(cmd.Parameters["@rrDiscount"].Value);
                rrMemberPoints = Convert.ToDouble(cmd.Parameters["@rrMemberPoints"].Value);
                rrPay = Convert.ToDouble(cmd.Parameters["@rrPay"].Value);
                rrChange = Convert.ToDouble(cmd.Parameters["@rrChange"].Value);

                if (rrMemberID == "0" | rrMemberID == "101" | rrMemberID == "")
                {
                }
                else
                {
                    rrRemainingPoints = Remaining_Points(rrStoreCode, Convert.ToInt64(rrMemberID));
                }

                Int32 retVal;
                String errMsg;
                apiAlias.StatusMonitoring pMonitorCB = new apiAlias.StatusMonitoring(StatusMonitoring);

                pdPrint = new PrintDocument();

                switch (rrPayBy)
                {
                    case 0:
                        pdPrint.PrintPage += new PrintPageEventHandler(pdPrint0_PrintPage);
                        pdPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;
                        break;
                    case 1:
                        pdPrint.PrintPage += new PrintPageEventHandler(pdPrint1_PrintPage);
                        pdPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;
                        break;
                    case 3:
                        pdPrint.PrintPage += new PrintPageEventHandler(pdPrint3_PrintPage);
                        pdPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;
                        break;
                    case 4:
                        pdPrint.PrintPage += new PrintPageEventHandler(pdPrint4_PrintPage);
                        pdPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;
                        break;
                    case 5:
                        pdPrint.PrintPage += new PrintPageEventHandler(pdPrint5_PrintPage);
                        pdPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;
                        break;
                    case 6:
                        pdPrint.PrintPage += new PrintPageEventHandler(pdPrint6_PrintPage);
                        pdPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;
                        break;
                    case 7:
                        pdPrint.PrintPage += new PrintPageEventHandler(pdPrint7_PrintPage);
                        pdPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;
                        break;
                    case 8:
                        pdPrint.PrintPage += new PrintPageEventHandler(pdPrint8_PrintPage);
                        pdPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;
                        break;
                    case 77:
                        pdPrint.PrintPage += new PrintPageEventHandler(pdPrint77_PrintPage);
                        pdPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;
                        break;
                    case 88:
                        pdPrint.PrintPage += new PrintPageEventHandler(pdPrint88_PrintPage);
                        pdPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;
                        break;
                    case 99:
                        pdPrint.PrintPage += new PrintPageEventHandler(pdPrint99_PrintPage);
                        pdPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;
                        break;
                    default:
                        MyMessageBox.ShowBox("NOT AVAILABLE", "ERROR");
                        return;
                }

                try
                {
                    // Open Printer Monitor of Status API.
                    mpHandle = apiAlias.BiOpenMonPrinter(apiAlias.TYPE_PRINTER, parentForm.PRINTER_NAME);
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
                                pdPrint.Print();                               
                            }
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
            }
            else
            {
                MyMessageBox.ShowBox("INVALID RECEIPT ID", "ERROR");
                //MessageBox.Show("Invalid receipt ID", "Error");
            }

            txtReceiptID.Clear();
            txtReceiptID.Select();
            txtReceiptID.Focus();
        }

        /// <summary>
        /// Handles the Click event of the btnLatest control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnLatest_Click(object sender, EventArgs e)
        {
            SqlCommand cmd_ReceiptID = new SqlCommand("Get_Latest_ReceiptID", parentForm.conn);
            cmd_ReceiptID.CommandType = CommandType.StoredProcedure;
            cmd_ReceiptID.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = parentForm.cashRegisterNum;
            SqlParameter Latest_Param = cmd_ReceiptID.Parameters.Add("@ReceiptID", SqlDbType.BigInt);
            Latest_Param.Direction = ParameterDirection.Output;

            parentForm.conn.Open();
            cmd_ReceiptID.ExecuteNonQuery();
            parentForm.conn.Close();

            if (cmd_ReceiptID.Parameters["@ReceiptID"].Value == DBNull.Value)
            {
                MyMessageBox.ShowBox("NO DATA", "ERROR");
                txtReceiptID.Select();
                txtReceiptID.Focus();
            }
            else
            {

                rrReceiptID = Convert.ToInt64(cmd_ReceiptID.Parameters["@ReceiptID"].Value);

                SqlCommand cmd = new SqlCommand("Get_ReceiptID_All_Info", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@rrReceiptID", SqlDbType.BigInt).Value = rrReceiptID;
                SqlParameter StoreCode_Param = cmd.Parameters.Add("@rrStoreCode", SqlDbType.NVarChar, 20);
                SqlParameter CashierID_Param = cmd.Parameters.Add("@rrCashierID", SqlDbType.NVarChar, 50);
                SqlParameter RegisterNum_Param = cmd.Parameters.Add("@rrRegisterNum", SqlDbType.NVarChar, 20);
                SqlParameter MemberID_Param = cmd.Parameters.Add("@rrMemberID", SqlDbType.NVarChar, 50);
                SqlParameter MemberName_Param = cmd.Parameters.Add("@rrMemberName", SqlDbType.NVarChar, 50);
                SqlParameter PayBy_Param = cmd.Parameters.Add("@rrPayBy", SqlDbType.Int);
                SqlParameter SellDate_Param = cmd.Parameters.Add("@rrSellDate", SqlDbType.NVarChar, 20);
                SqlParameter SellTime_Param = cmd.Parameters.Add("@rrSellTime", SqlDbType.NVarChar, 20);
                SqlParameter SubTotal_Param = cmd.Parameters.Add("@rrSubTotal", SqlDbType.Money);
                SqlParameter Tax_Param = cmd.Parameters.Add("@rrTax", SqlDbType.Money);
                SqlParameter GrandTotal_Param = cmd.Parameters.Add("@rrGrandTotal", SqlDbType.Money);
                SqlParameter Discount_Param = cmd.Parameters.Add("@rrDiscount", SqlDbType.Money);
                SqlParameter MemberPoints_Param = cmd.Parameters.Add("@rrMemberPoints", SqlDbType.Money);
                SqlParameter Pay_Param = cmd.Parameters.Add("@rrPay", SqlDbType.Money);
                SqlParameter Change_Param = cmd.Parameters.Add("@rrChange", SqlDbType.Money);
                StoreCode_Param.Direction = ParameterDirection.Output;
                CashierID_Param.Direction = ParameterDirection.Output;
                RegisterNum_Param.Direction = ParameterDirection.Output;
                MemberID_Param.Direction = ParameterDirection.Output;
                MemberName_Param.Direction = ParameterDirection.Output;
                PayBy_Param.Direction = ParameterDirection.Output;
                SellDate_Param.Direction = ParameterDirection.Output;
                SellTime_Param.Direction = ParameterDirection.Output;
                SubTotal_Param.Direction = ParameterDirection.Output;
                Tax_Param.Direction = ParameterDirection.Output;
                GrandTotal_Param.Direction = ParameterDirection.Output;
                Discount_Param.Direction = ParameterDirection.Output;
                MemberPoints_Param.Direction = ParameterDirection.Output;
                Pay_Param.Direction = ParameterDirection.Output;
                Change_Param.Direction = ParameterDirection.Output;

                parentForm.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm.conn.Close();

                rrStoreCode = Convert.ToString(cmd.Parameters["@rrStoreCode"].Value);
                rrCashierID = Convert.ToString(cmd.Parameters["@rrCashierID"].Value);
                rrRegisterNum = Convert.ToString(cmd.Parameters["@rrRegisterNum"].Value);
                rrMemberID = Convert.ToString(cmd.Parameters["@rrMemberID"].Value);
                rrMemberName = Convert.ToString(cmd.Parameters["@rrMemberName"].Value);
                rrPayBy = Convert.ToInt16(cmd.Parameters["@rrPayBy"].Value);
                rrSellDate = Convert.ToString(cmd.Parameters["@rrSellDate"].Value);
                rrSellTime = Convert.ToString(cmd.Parameters["@rrSellTime"].Value);
                rrSubTotal = Convert.ToDouble(cmd.Parameters["@rrSubTotal"].Value);
                rrTax = Convert.ToDouble(cmd.Parameters["@rrTax"].Value);
                rrGrandTotal = Convert.ToDouble(cmd.Parameters["@rrGrandTotal"].Value);
                rrDiscount = Convert.ToDouble(cmd.Parameters["@rrDiscount"].Value);
                rrMemberPoints = Convert.ToDouble(cmd.Parameters["@rrMemberPoints"].Value);
                rrPay = Convert.ToDouble(cmd.Parameters["@rrPay"].Value);
                rrChange = Convert.ToDouble(cmd.Parameters["@rrChange"].Value);

                if (rrMemberID == "0" | rrMemberID == "101" | rrMemberID == "")
                {
                }
                else
                {
                    rrRemainingPoints = Remaining_Points(rrStoreCode, Convert.ToInt64(rrMemberID));
                }

                Int32 retVal;
                String errMsg;
                apiAlias.StatusMonitoring pMonitorCB = new apiAlias.StatusMonitoring(StatusMonitoring);

                pdPrint = new PrintDocument();

                switch (rrPayBy)
                {
                    case 0:
                        pdPrint.PrintPage += new PrintPageEventHandler(pdPrint0_PrintPage);
                        pdPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;
                        break;
                    case 1:
                        pdPrint.PrintPage += new PrintPageEventHandler(pdPrint1_PrintPage);
                        pdPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;
                        break;
                    case 3:
                        pdPrint.PrintPage += new PrintPageEventHandler(pdPrint3_PrintPage);
                        pdPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;
                        break;
                    case 4:
                        pdPrint.PrintPage += new PrintPageEventHandler(pdPrint4_PrintPage);
                        pdPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;
                        break;
                    case 5:
                        pdPrint.PrintPage += new PrintPageEventHandler(pdPrint5_PrintPage);
                        pdPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;
                        break;
                    case 6:
                        pdPrint.PrintPage += new PrintPageEventHandler(pdPrint6_PrintPage);
                        pdPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;
                        break;
                    case 7:
                        pdPrint.PrintPage += new PrintPageEventHandler(pdPrint7_PrintPage);
                        pdPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;
                        break;
                    case 8:
                        pdPrint.PrintPage += new PrintPageEventHandler(pdPrint8_PrintPage);
                        pdPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;
                        break;
                    case 77:
                        pdPrint.PrintPage += new PrintPageEventHandler(pdPrint77_PrintPage);
                        pdPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;
                        break;
                    case 88:
                        pdPrint.PrintPage += new PrintPageEventHandler(pdPrint88_PrintPage);
                        pdPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;
                        break;
                    case 99:
                        pdPrint.PrintPage += new PrintPageEventHandler(pdPrint99_PrintPage);
                        pdPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;
                        break;
                    default:
                        MyMessageBox.ShowBox("NOT AVAILABLE", "ERROR");
                        return;
                }

                try
                {
                    // Open Printer Monitor of Status API.
                    mpHandle = apiAlias.BiOpenMonPrinter(apiAlias.TYPE_PRINTER, parentForm.PRINTER_NAME);
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
                                pdPrint.Print();
                            }
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

                txtReceiptID.Select();
                txtReceiptID.Focus();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the PrintPage event of the pdPrint0 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PrintPageEventArgs"/> instance containing the event data.</param>
        private void pdPrint0_PrintPage(object sender, PrintPageEventArgs e)
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
            text.Add(Convert.ToString(rrSellDate) + " " + Convert.ToString(rrSellTime));
            text.Add("RECEIPT ID");
            text.Add(":");
            text.Add(parentForm.storeCode + "-" + Convert.ToString(rrReceiptID));
            text.Add("CASHIER ID");
            text.Add(":");
            text.Add(Convert.ToString(rrCashierID));
            text.Add("REGISTER NO");
            text.Add(":");
            text.Add(Convert.ToString(rrRegisterNum));
            text.Add("MEMBER ID");
            text.Add(":");
            text.Add(Convert.ToString(rrMemberID));
            text.Add("MEMBER NAME");
            text.Add(":");
            text.Add(Convert.ToString(rrMemberName));
            text.Add("----------------------------------------------------------------");
            text.Add("       DESCRIPTION                         QTY     PRICE    ");
            text.Add("----------------------------------------------------------------");

            SqlCommand cmd_Count = new SqlCommand("Get_Item_Count_From_ReceiptBody", parentForm.conn);
            cmd_Count.CommandType = CommandType.StoredProcedure;
            cmd_Count.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = rrReceiptID;
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
                cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = rrReceiptID;
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
                rrItmName = cmd.Parameters["@ItmName"].Value.ToString();
                rrItmQty = cmd.Parameters["@ItmQty"].Value.ToString();
                rrItmBasePrice = Convert.ToDouble(cmd.Parameters["@ItmBasePrice"].Value);
                rrItmDiscountPrice = Convert.ToDouble(cmd.Parameters["@ItmDiscountPrice"].Value);
                //rrItmPrice = string.Format("{0:  0.00}", Convert.ToDouble(cmd.Parameters["@ItmPrice"].Value));
                rrItmPrice = Convert.ToDouble(cmd.Parameters["@ItmPrice"].Value);
                rrItmUpc = cmd.Parameters["@ItmUpc"].Value.ToString();

                if (rrItmDiscountPrice != 0)
                {
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc);
                    text.Add("-PURCHASE PRICE: " + string.Format("{0:$0.00}", rrItmDiscountPrice) + " * " + rrItmQty + " =" + string.Format("{0:$0.00}", rrItmPrice));
                    text.Add(" ");
                }
                else
                {
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc);
                    text.Add("-PURCHASE PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + string.Format("{0:$0.00}", rrItmPrice));
                    text.Add(" ");
                }
            }

            text.Add("----------------------------------------------------------------");
            text.Add("SUB TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:   0.00}", rrSubTotal));
            text.Add("SALES TAX");
            text.Add("$");
            text.Add(string.Format("{0:   0.00}", rrTax));
            text.Add("RETURN TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:   0.00}", rrGrandTotal));

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

            if (rrStoreCreditID == 0)
            {
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
                e.Graphics.DrawString("*" + Convert.ToString(rrReceiptID) + "*", barcodeFont, Brushes.Black, 55, yPos + 3);
                ctrTemp += 1;

                text.Add(" ");
                text.Add(" ");
                //text.Add("               Thank you for shopping !");
                text.Add(parentForm.receiptLastComment);
                text.Add(" ");
                text.Add(" ");
                text.Add(" ");
                text.Add("***REPRINT RECEIPT - NOT ORIGINAL***");

                for (ctr2 = text.Count - 7; ctr2 <= text.Count - 1; ctr2++)
                {
                    yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                    e.Graphics.DrawString((String)text[ctr2], printFont, Brushes.Black, 0, yPos + 3);
                    ctrTemp += 1;
                }

                e.HasMorePages = false;
            }
            else
            {

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
                text.Add(Convert.ToString(rrStoreCreditID));
                //text.Add("AMOUNT");
                //text.Add(":");
                //text.Add("$" + Convert.ToString(rrAmount));
                text.Add("BALANCE");
                text.Add(":");
                text.Add("$" + Convert.ToString(rrBalance));
                text.Add("EXPIRATION DATE");
                text.Add(":");
                text.Add(Convert.ToString(rrExpDate));

                for (ctr2 = text.Count - 9; ctr2 <= text.Count - 1; ctr2 += 3)
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
                e.Graphics.DrawString("*" + Convert.ToString(rrReceiptID) + "*", barcodeFont, Brushes.Black, 55, yPos + 3);
                ctrTemp += 1;

                text.Add(" ");
                text.Add(" ");
                //text.Add("               Thank you for shopping !");
                text.Add(parentForm.receiptLastComment);
                text.Add(" ");
                text.Add(" ");
                text.Add(" ");
                text.Add("***REPRINT RECEIPT - NOT ORIGINAL***");

                for (ctr2 = text.Count - 7; ctr2 <= text.Count - 1; ctr2++)
                {
                    yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                    e.Graphics.DrawString((String)text[ctr2], printFont, Brushes.Black, 0, yPos + 3);
                    ctrTemp += 1;
                }

                e.HasMorePages = false;
            }
        }

        /// <summary>
        /// Handles the PrintPage event of the pdPrint1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PrintPageEventArgs"/> instance containing the event data.</param>
        private void pdPrint1_PrintPage(object sender, PrintPageEventArgs e)
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
            text.Add("CASH");
            text.Add("DATE & TIME");
            text.Add(":");
            text.Add(Convert.ToString(rrSellDate) + " " + Convert.ToString(rrSellTime));
            text.Add("RECEIPT ID");
            text.Add(":");
            text.Add(rrStoreCode + "-" + Convert.ToString(rrReceiptID));
            text.Add("CASHIER ID");
            text.Add(":");
            text.Add(rrCashierID);
            text.Add("REGISTER NO");
            text.Add(":");
            text.Add(rrRegisterNum);
            text.Add("MEMBER ID");
            text.Add(":");
            text.Add(rrMemberID);
            text.Add("MEMBER NAME");
            text.Add(":");
            text.Add(rrMemberName);
            text.Add("----------------------------------------------------------------");
            text.Add("       DESCRIPTION                           QTY    PRICE    ");
            text.Add("----------------------------------------------------------------");

            SqlCommand cmd_Count = new SqlCommand("Get_Item_Count_From_ReceiptBody", parentForm.conn);
            cmd_Count.CommandType = CommandType.StoredProcedure;
            cmd_Count.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = rrReceiptID;
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
                cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = rrReceiptID;
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
                rrItmName = cmd.Parameters["@ItmName"].Value.ToString();
                rrItmQty = cmd.Parameters["@ItmQty"].Value.ToString();
                rrItmBasePrice = Convert.ToDouble(cmd.Parameters["@ItmBasePrice"].Value);
                rrItmDiscountPrice = Convert.ToDouble(cmd.Parameters["@ItmDiscountPrice"].Value);
                rrItmPrice = Convert.ToDouble(cmd.Parameters["@ItmPrice"].Value);
                rrItmUpc = cmd.Parameters["@ItmUpc"].Value.ToString();
                rrItmOriginalPrice = Math.Round(rrItmBasePrice * Convert.ToInt16(rrItmQty), 2);

                if (rrItmDiscountPrice == rrItmBasePrice & rrItmDiscountPrice > 0)
                {
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc);
                    text.Add("-FINAL SALE PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + string.Format("{0:$0.00}", rrItmOriginalPrice));
                    text.Add(" ");
                }
                else if (rrItmDiscountPrice > 0)
                {
                    rrItmSave = rrItmOriginalPrice - Convert.ToDouble(rrItmPrice);
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc + "(REGULAR PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + rrItmOriginalPrice + ")");
                    text.Add("-DISCOUNT PRICE: " + string.Format("{0:$0.00}", rrItmDiscountPrice) + " * " + rrItmQty + " =" + string.Format("{0:$0.00}", rrItmPrice) + " /SAVED: " + string.Format("{0:$0.00}", rrItmSave));
                    text.Add(" ");
                }
                else if (rrItmUpc == "000000999111")
                {
                    text.Add(rrItmName);
                    text.Add(" ");
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice));
                    text.Add(rrItmUpc);
                    text.Add("-AMOUNT USED: " + string.Format("{0:$0.00}", -rrItmPrice));
                    text.Add(" ");
                }
                else if (rrItmUpc == "000000999112")
                {
                    text.Add(rrItmName);
                    text.Add(" ");
                    text.Add(" ");
                    text.Add(" ");
                    text.Add(rrItmUpc);
                    text.Add("-COUPON USED");
                    text.Add(" ");
                }
                else if (rrItmPrice == 0)
                {
                    rrItmSave = rrItmOriginalPrice - Convert.ToDouble(rrItmPrice);
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc + "(REGULAR PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + rrItmOriginalPrice + ")");
                    text.Add("-DISCOUNT PRICE: " + string.Format("{0:$0.00}", rrItmPrice) + " * " + rrItmQty + " =" + string.Format("{0:$0.00}", rrItmPrice) + " /SAVED: " + string.Format("{0:$0.00}", rrItmSave));
                    text.Add(" ");
                }
                else if (rrItmBasePrice == 0 & rrItmQty == "0")
                {
                    text.Add(rrItmName);
                    text.Add(" ");
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice));
                    text.Add(rrItmUpc);
                    text.Add("-SAVED: " + string.Format("{0:$0.00}", -rrItmPrice));
                    text.Add(" ");
                }
                else
                {
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc);
                    text.Add("-REGULAR PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + string.Format("{0:$0.00}", rrItmOriginalPrice));
                    text.Add(" ");
                }
            }

            text.Add("----------------------------------------------------------------");
            text.Add("SUB TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:    0.00}", rrSubTotal));
            text.Add("SALES TAX");
            text.Add("$");
            text.Add(string.Format("{0:    0.00}", rrTax));
            text.Add("GRAND TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:    0.00}", rrGrandTotal));
            text.Add("================================================================");
            text.Add("AMOUNT SAVED");
            text.Add("$");
            text.Add(string.Format("{0:    0.00}", rrDiscount));
            text.Add("NEW POINTS");
            text.Add("$");
            text.Add(string.Format("{0:    0.00}", rrMemberPoints));
            text.Add("REMAINING POINTS");
            text.Add("$");
            text.Add(string.Format("{0:    0.00}", rrRemainingPoints));
            text.Add("================================================================");
            text.Add("CASH PAY");
            text.Add("$");
            text.Add(string.Format("{0:    0.00}", rrPay));
            text.Add("CASH CHANGE");
            text.Add("$");
            text.Add(string.Format("{0:    0.00}", rrChange));

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

            for (ctr2 = printItmCount + 2; ctr2 <= text.Count - 21; ctr2 += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 2], printFont2).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont2, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont2, Brushes.Black, 215, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont2, Brushes.Black, xPos, yPos + 3);
                ctrTemp += 1;
            }

            for (ctr2 = printItmCount + 8; ctr2 <= text.Count - 19; ctr2 += 3)
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

            for (ctr2 = printItmCount + 12; ctr2 <= text.Count - 10; ctr2 += 3)
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
            e.Graphics.DrawString("*" + Convert.ToString(rrReceiptID) + "*", barcodeFont, Brushes.Black, 55, yPos + 3);
            ctrTemp += 1;

            text.Add(" ");
            text.Add(" ");
            //text.Add("               Thank you for shopping !");
            text.Add(parentForm.receiptLastComment);
            text.Add(" ");
            text.Add(" ");
            text.Add(" ");
            text.Add("***REPRINT RECEIPT - NOT ORIGINAL***");

            for (ctr2 = text.Count - 7; ctr2 <= text.Count - 1; ctr2++)
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
            text.Add("TERMINAL (CREDIT)");
            text.Add("DATE & TIME");
            text.Add(":");
            text.Add(Convert.ToString(rrSellDate) + " " + Convert.ToString(rrSellTime));
            text.Add("RECEIPT ID");
            text.Add(":");
            //text.Add("BCAT-372031");
            text.Add(rrStoreCode + "-" + Convert.ToString(rrReceiptID));
            text.Add("CASHIER ID");
            text.Add(":");
            text.Add(rrCashierID);
            text.Add("REGISTER NO");
            text.Add(":");
            text.Add(rrRegisterNum);
            text.Add("MEMBER ID");
            text.Add(":");
            text.Add(rrMemberID);
            text.Add("MEMBER NAME");
            text.Add(":");
            text.Add(rrMemberName);
            text.Add("----------------------------------------------------------------");
            text.Add("       DESCRIPTION                           QTY    PRICE    ");
            text.Add("----------------------------------------------------------------");

            SqlCommand cmd_Count = new SqlCommand("Get_Item_Count_From_ReceiptBody", parentForm.conn);
            cmd_Count.CommandType = CommandType.StoredProcedure;
            cmd_Count.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = rrReceiptID;
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
                cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = rrReceiptID;
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
                rrItmName = cmd.Parameters["@ItmName"].Value.ToString();
                rrItmQty = cmd.Parameters["@ItmQty"].Value.ToString();
                rrItmBasePrice = Convert.ToDouble(cmd.Parameters["@ItmBasePrice"].Value);
                rrItmDiscountPrice = Convert.ToDouble(cmd.Parameters["@ItmDiscountPrice"].Value);
                rrItmPrice = Convert.ToDouble(cmd.Parameters["@ItmPrice"].Value);
                rrItmUpc = cmd.Parameters["@ItmUpc"].Value.ToString();
                rrItmOriginalPrice = Math.Round(rrItmBasePrice * Convert.ToInt16(rrItmQty), 2);

                if (rrItmDiscountPrice == rrItmBasePrice & rrItmDiscountPrice > 0)
                {
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc);
                    text.Add("-FINAL SALE PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + string.Format("{0:$0.00}", rrItmOriginalPrice));
                    text.Add(" ");
                }
                else if (rrItmDiscountPrice > 0)
                {
                    rrItmSave = rrItmOriginalPrice - Convert.ToDouble(rrItmPrice);
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc + "(REGULAR PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + rrItmOriginalPrice + ")");
                    text.Add("-DISCOUNT PRICE: " + string.Format("{0:$0.00}", rrItmDiscountPrice) + " * " + rrItmQty + " =" + string.Format("{0:$0.00}", rrItmPrice) + " /SAVED: " + string.Format("{0:$0.00}", rrItmSave));
                    text.Add(" ");
                }
                else if (rrItmUpc == "000000999111")
                {
                    text.Add(rrItmName);
                    text.Add(" ");
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice));
                    text.Add(rrItmUpc);
                    text.Add("-AMOUNT USED: " + string.Format("{0:$0.00}", -rrItmPrice));
                    text.Add(" ");
                }
                else if (rrItmUpc == "000000999112")
                {
                    text.Add(rrItmName);
                    text.Add(" ");
                    text.Add(" ");
                    text.Add(" ");
                    text.Add(rrItmUpc);
                    text.Add("-COUPON USED");
                    text.Add(" ");
                }
                else if (rrItmPrice == 0)
                {
                    rrItmSave = rrItmOriginalPrice - Convert.ToDouble(rrItmPrice);
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc + "(REGULAR PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + rrItmOriginalPrice + ")");
                    text.Add("-DISCOUNT PRICE: " + string.Format("{0:$0.00}", rrItmPrice) + " * " + rrItmQty + " =" + string.Format("{0:$0.00}", rrItmPrice) + " /SAVED: " + string.Format("{0:$0.00}", rrItmSave));
                    text.Add(" ");
                }
                else if (rrItmBasePrice == 0 & rrItmQty == "0")
                {
                    text.Add(rrItmName);
                    text.Add(" ");
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice));
                    text.Add(rrItmUpc);
                    text.Add("-SAVED: " + string.Format("{0:$0.00}", -rrItmPrice));
                    text.Add(" ");
                }
                else
                {
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc);
                    text.Add("-REGULAR PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + string.Format("{0:$0.00}", rrItmOriginalPrice));
                    text.Add(" ");
                }
            }

            text.Add("----------------------------------------------------------------");
            text.Add("SUB TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrSubTotal));
            text.Add("SALES TAX");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrTax));
            text.Add("GRAND TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrGrandTotal));
            text.Add("================================================================");
            text.Add("AMOUNT SAVED");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrDiscount));
            text.Add("NEW POINTS");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrMemberPoints));
            text.Add("REMAINING POINTS");
            text.Add("$");
            text.Add(string.Format("{0:    0.00}", rrRemainingPoints));
            text.Add("================================================================");
            text.Add("CREDIT CARD TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrGrandTotal));

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
            e.Graphics.DrawString("*" + Convert.ToString(rrReceiptID) + "*", barcodeFont, Brushes.Black, 55, yPos + 3);
            ctrTemp += 1;

            text.Add(" ");
            text.Add(" ");
            //text.Add("               Thank you for shopping !");
            text.Add(parentForm.receiptLastComment);
            text.Add(" ");
            text.Add(" ");
            text.Add(" ");
            text.Add("***REPRINT RECEIPT - NOT ORIGINAL***");

            for (ctr2 = text.Count - 7; ctr2 <= text.Count - 1; ctr2++)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2], printFont, Brushes.Black, 0, yPos + 3);
                ctrTemp += 1;
            }

            e.HasMorePages = false;
        }

        /// <summary>
        /// Handles the PrintPage event of the pdPrint4 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PrintPageEventArgs"/> instance containing the event data.</param>
        private void pdPrint4_PrintPage(object sender, PrintPageEventArgs e)
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
            text.Add("VISA");
            text.Add("DATE & TIME");
            text.Add(":");
            text.Add(Convert.ToString(rrSellDate) + " " + Convert.ToString(rrSellTime));
            text.Add("RECEIPT ID");
            text.Add(":");
            text.Add(rrStoreCode + "-" + Convert.ToString(rrReceiptID));
            text.Add("CASHIER ID");
            text.Add(":");
            text.Add(rrCashierID);
            text.Add("REGISTER NO");
            text.Add(":");
            text.Add(rrRegisterNum);
            text.Add("MEMBER ID");
            text.Add(":");
            text.Add(rrMemberID);
            text.Add("MEMBER NAME");
            text.Add(":");
            text.Add(rrMemberName);
            text.Add("----------------------------------------------------------------");
            text.Add("       DESCRIPTION                           QTY    PRICE    ");
            text.Add("----------------------------------------------------------------");

            SqlCommand cmd_Count = new SqlCommand("Get_Item_Count_From_ReceiptBody", parentForm.conn);
            cmd_Count.CommandType = CommandType.StoredProcedure;
            cmd_Count.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = rrReceiptID;
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
                cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = rrReceiptID;
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
                rrItmName = cmd.Parameters["@ItmName"].Value.ToString();
                rrItmQty = cmd.Parameters["@ItmQty"].Value.ToString();
                rrItmBasePrice = Convert.ToDouble(cmd.Parameters["@ItmBasePrice"].Value);
                rrItmDiscountPrice = Convert.ToDouble(cmd.Parameters["@ItmDiscountPrice"].Value);
                rrItmPrice = Convert.ToDouble(cmd.Parameters["@ItmPrice"].Value);
                rrItmUpc = cmd.Parameters["@ItmUpc"].Value.ToString();
                rrItmOriginalPrice = Math.Round(rrItmBasePrice * Convert.ToInt16(rrItmQty), 2);

                if (rrItmDiscountPrice == rrItmBasePrice & rrItmDiscountPrice > 0)
                {
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc);
                    text.Add("-FINAL SALE PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + string.Format("{0:$0.00}", rrItmOriginalPrice));
                    text.Add(" ");
                }
                else if (rrItmDiscountPrice > 0)
                {
                    rrItmSave = rrItmOriginalPrice - Convert.ToDouble(rrItmPrice);
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc + "(REGULAR PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + rrItmOriginalPrice + ")");
                    text.Add("-DISCOUNT PRICE: " + string.Format("{0:$0.00}", rrItmDiscountPrice) + " * " + rrItmQty + " =" + string.Format("{0:$0.00}", rrItmPrice) + " /SAVED: " + string.Format("{0:$0.00}", rrItmSave));
                    text.Add(" ");
                }
                else if (rrItmUpc == "000000999111")
                {
                    text.Add(rrItmName);
                    text.Add(" ");
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice));
                    text.Add(rrItmUpc);
                    text.Add("-AMOUNT USED: " + string.Format("{0:$0.00}", -rrItmPrice));
                    text.Add(" ");
                }
                else if (rrItmUpc == "000000999112")
                {
                    text.Add(rrItmName);
                    text.Add(" ");
                    text.Add(" ");
                    text.Add(" ");
                    text.Add(rrItmUpc);
                    text.Add("-COUPON USED");
                    text.Add(" ");
                }
                else if (rrItmPrice == 0)
                {
                    rrItmSave = rrItmOriginalPrice - Convert.ToDouble(rrItmPrice);
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc + "(REGULAR PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + rrItmOriginalPrice + ")");
                    text.Add("-DISCOUNT PRICE: " + string.Format("{0:$0.00}", rrItmPrice) + " * " + rrItmQty + " =" + string.Format("{0:$0.00}", rrItmPrice) + " /SAVED: " + string.Format("{0:$0.00}", rrItmSave));
                    text.Add(" ");
                }
                else if (rrItmBasePrice == 0 & rrItmQty == "0")
                {
                    text.Add(rrItmName);
                    text.Add(" ");
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice));
                    text.Add(rrItmUpc);
                    text.Add("-SAVED: " + string.Format("{0:$0.00}", -rrItmPrice));
                    text.Add(" ");
                }
                else
                {
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc);
                    text.Add("-REGULAR PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + string.Format("{0:$0.00}", rrItmOriginalPrice));
                    text.Add(" ");
                }
            }

            text.Add("----------------------------------------------------------------");
            text.Add("SUB TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrSubTotal));
            text.Add("SALES TAX");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrTax));
            text.Add("GRAND TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrGrandTotal));
            text.Add("================================================================");
            text.Add("AMOUNT SAVED");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrDiscount));
            text.Add("NEW POINTS");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrMemberPoints));
            text.Add("REMAINING POINTS");
            text.Add("$");
            text.Add(string.Format("{0:    0.00}", rrRemainingPoints));
            text.Add("================================================================");
            text.Add("CREDIT CARD TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrGrandTotal));

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
            e.Graphics.DrawString("*" + Convert.ToString(rrReceiptID) + "*", barcodeFont, Brushes.Black, 55, yPos + 3);
            ctrTemp += 1;

            text.Add(" ");
            text.Add(" ");
            //text.Add("               Thank you for shopping !");
            text.Add(parentForm.receiptLastComment);
            text.Add(" ");
            text.Add(" ");
            text.Add(" ");
            text.Add("***REPRINT RECEIPT - NOT ORIGINAL***");

            for (ctr2 = text.Count - 7; ctr2 <= text.Count - 1; ctr2++)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2], printFont, Brushes.Black, 0, yPos + 3);
                ctrTemp += 1;
            }

            e.HasMorePages = false;
        }

        /// <summary>
        /// Handles the PrintPage event of the pdPrint5 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PrintPageEventArgs"/> instance containing the event data.</param>
        private void pdPrint5_PrintPage(object sender, PrintPageEventArgs e)
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
            text.Add("DEBIT");
            text.Add("DATE & TIME");
            text.Add(":");
            text.Add(Convert.ToString(rrSellDate) + " " + Convert.ToString(rrSellTime));
            text.Add("RECEIPT ID");
            text.Add(":");
            //text.Add("BCAT-372031");
            text.Add(rrStoreCode + "-" + Convert.ToString(rrReceiptID));
            text.Add("CASHIER ID");
            text.Add(":");
            text.Add(rrCashierID);
            text.Add("REGISTER NO");
            text.Add(":");
            text.Add(rrRegisterNum);
            text.Add("MEMBER ID");
            text.Add(":");
            text.Add(rrMemberID);
            text.Add("MEMBER NAME");
            text.Add(":");
            text.Add(rrMemberName);
            text.Add("----------------------------------------------------------------");
            text.Add("       DESCRIPTION                           QTY    PRICE    ");
            text.Add("----------------------------------------------------------------");

            SqlCommand cmd_Count = new SqlCommand("Get_Item_Count_From_ReceiptBody", parentForm.conn);
            cmd_Count.CommandType = CommandType.StoredProcedure;
            cmd_Count.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = rrReceiptID;
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
                cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = rrReceiptID;
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
                rrItmName = cmd.Parameters["@ItmName"].Value.ToString();
                rrItmQty = cmd.Parameters["@ItmQty"].Value.ToString();
                rrItmBasePrice = Convert.ToDouble(cmd.Parameters["@ItmBasePrice"].Value);
                rrItmDiscountPrice = Convert.ToDouble(cmd.Parameters["@ItmDiscountPrice"].Value);
                rrItmPrice = Convert.ToDouble(cmd.Parameters["@ItmPrice"].Value);
                rrItmUpc = cmd.Parameters["@ItmUpc"].Value.ToString();
                rrItmOriginalPrice = Math.Round(rrItmBasePrice * Convert.ToInt16(rrItmQty), 2);

                if (rrItmDiscountPrice == rrItmBasePrice & rrItmDiscountPrice > 0)
                {
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc);
                    text.Add("-FINAL SALE PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + string.Format("{0:$0.00}", rrItmOriginalPrice));
                    text.Add(" ");
                }
                else if (rrItmDiscountPrice > 0)
                {
                    rrItmSave = rrItmOriginalPrice - Convert.ToDouble(rrItmPrice);
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc + "(REGULAR PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + rrItmOriginalPrice + ")");
                    text.Add("-DISCOUNT PRICE: " + string.Format("{0:$0.00}", rrItmDiscountPrice) + " * " + rrItmQty + " =" + string.Format("{0:$0.00}", rrItmPrice) + " /SAVED: " + string.Format("{0:$0.00}", rrItmSave));
                    text.Add(" ");
                }
                else if (rrItmUpc == "000000999111")
                {
                    text.Add(rrItmName);
                    text.Add(" ");
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice));
                    text.Add(rrItmUpc);
                    text.Add("-AMOUNT USED: " + string.Format("{0:$0.00}", -rrItmPrice));
                    text.Add(" ");
                }
                else if (rrItmUpc == "000000999112")
                {
                    text.Add(rrItmName);
                    text.Add(" ");
                    text.Add(" ");
                    text.Add(" ");
                    text.Add(rrItmUpc);
                    text.Add("-COUPON USED");
                    text.Add(" ");
                }
                else if (rrItmPrice == 0)
                {
                    rrItmSave = rrItmOriginalPrice - Convert.ToDouble(rrItmPrice);
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc + "(REGULAR PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + rrItmOriginalPrice + ")");
                    text.Add("-DISCOUNT PRICE: " + string.Format("{0:$0.00}", rrItmPrice) + " * " + rrItmQty + " =" + string.Format("{0:$0.00}", rrItmPrice) + " /SAVED: " + string.Format("{0:$0.00}", rrItmSave));
                    text.Add(" ");
                }
                else if (rrItmBasePrice == 0 & rrItmQty == "0")
                {
                    text.Add(rrItmName);
                    text.Add(" ");
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice));
                    text.Add(rrItmUpc);
                    text.Add("-SAVED: " + string.Format("{0:$0.00}", -rrItmPrice));
                    text.Add(" ");
                }
                else
                {
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc);
                    text.Add("-REGULAR PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + string.Format("{0:$0.00}", rrItmOriginalPrice));
                    text.Add(" ");
                }
            }

            text.Add("----------------------------------------------------------------");
            text.Add("SUB TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrSubTotal));
            text.Add("SALES TAX");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrTax));
            text.Add("GRAND TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrGrandTotal));
            text.Add("================================================================");
            text.Add("AMOUNT SAVED");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrDiscount));
            text.Add("NEW POINTS");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrMemberPoints));
            text.Add("REMAINING POINTS");
            text.Add("$");
            text.Add(string.Format("{0:    0.00}", rrRemainingPoints));
            text.Add("================================================================");
            text.Add("DEBIT CARD TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrGrandTotal));

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
            e.Graphics.DrawString("*" + Convert.ToString(rrReceiptID) + "*", barcodeFont, Brushes.Black, 55, yPos + 3);
            ctrTemp += 1;

            text.Add(" ");
            text.Add(" ");
            //text.Add("               Thank you for shopping !");
            text.Add(parentForm.receiptLastComment);
            text.Add(" ");
            text.Add(" ");
            text.Add(" ");
            text.Add("***REPRINT RECEIPT - NOT ORIGINAL***");

            for (ctr2 = text.Count - 7; ctr2 <= text.Count - 1; ctr2++)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2], printFont, Brushes.Black, 0, yPos + 3);
                ctrTemp += 1;
            }

            e.HasMorePages = false;
        }

        /// <summary>
        /// Handles the PrintPage event of the pdPrint6 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PrintPageEventArgs"/> instance containing the event data.</param>
        private void pdPrint6_PrintPage(object sender, PrintPageEventArgs e)
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
            text.Add("MC");
            text.Add("DATE & TIME");
            text.Add(":");
            text.Add(Convert.ToString(rrSellDate) + " " + Convert.ToString(rrSellTime));
            text.Add("RECEIPT ID");
            text.Add(":");
            text.Add(rrStoreCode + "-" + Convert.ToString(rrReceiptID));
            text.Add("CASHIER ID");
            text.Add(":");
            text.Add(rrCashierID);
            text.Add("REGISTER NO");
            text.Add(":");
            text.Add(rrRegisterNum);
            text.Add("MEMBER ID");
            text.Add(":");
            text.Add(rrMemberID);
            text.Add("MEMBER NAME");
            text.Add(":");
            text.Add(rrMemberName);
            text.Add("----------------------------------------------------------------");
            text.Add("       DESCRIPTION                           QTY    PRICE    ");
            text.Add("----------------------------------------------------------------");

            SqlCommand cmd_Count = new SqlCommand("Get_Item_Count_From_ReceiptBody", parentForm.conn);
            cmd_Count.CommandType = CommandType.StoredProcedure;
            cmd_Count.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = rrReceiptID;
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
                cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = rrReceiptID;
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
                rrItmName = cmd.Parameters["@ItmName"].Value.ToString();
                rrItmQty = cmd.Parameters["@ItmQty"].Value.ToString();
                rrItmBasePrice = Convert.ToDouble(cmd.Parameters["@ItmBasePrice"].Value);
                rrItmDiscountPrice = Convert.ToDouble(cmd.Parameters["@ItmDiscountPrice"].Value);
                rrItmPrice = Convert.ToDouble(cmd.Parameters["@ItmPrice"].Value);
                rrItmUpc = cmd.Parameters["@ItmUpc"].Value.ToString();
                rrItmOriginalPrice = Math.Round(rrItmBasePrice * Convert.ToInt16(rrItmQty), 2);

                if (rrItmDiscountPrice == rrItmBasePrice & rrItmDiscountPrice > 0)
                {
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc);
                    text.Add("-FINAL SALE PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + string.Format("{0:$0.00}", rrItmOriginalPrice));
                    text.Add(" ");
                }
                else if (rrItmDiscountPrice > 0)
                {
                    rrItmSave = rrItmOriginalPrice - Convert.ToDouble(rrItmPrice);
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc + "(REGULAR PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + rrItmOriginalPrice + ")");
                    text.Add("-DISCOUNT PRICE: " + string.Format("{0:$0.00}", rrItmDiscountPrice) + " * " + rrItmQty + " =" + string.Format("{0:$0.00}", rrItmPrice) + " /SAVED: " + string.Format("{0:$0.00}", rrItmSave));
                    text.Add(" ");
                }
                else if (rrItmUpc == "000000999111")
                {
                    text.Add(rrItmName);
                    text.Add(" ");
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice));
                    text.Add(rrItmUpc);
                    text.Add("-AMOUNT USED: " + string.Format("{0:$0.00}", -rrItmPrice));
                    text.Add(" ");
                }
                else if (rrItmUpc == "000000999112")
                {
                    text.Add(rrItmName);
                    text.Add(" ");
                    text.Add(" ");
                    text.Add(" ");
                    text.Add(rrItmUpc);
                    text.Add("-COUPON USED");
                    text.Add(" ");
                }
                else if (rrItmPrice == 0)
                {
                    rrItmSave = rrItmOriginalPrice - Convert.ToDouble(rrItmPrice);
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc + "(REGULAR PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + rrItmOriginalPrice + ")");
                    text.Add("-DISCOUNT PRICE: " + string.Format("{0:$0.00}", rrItmPrice) + " * " + rrItmQty + " =" + string.Format("{0:$0.00}", rrItmPrice) + " /SAVED: " + string.Format("{0:$0.00}", rrItmSave));
                    text.Add(" ");
                }
                else if (rrItmBasePrice == 0 & rrItmQty == "0")
                {
                    text.Add(rrItmName);
                    text.Add(" ");
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice));
                    text.Add(rrItmUpc);
                    text.Add("-SAVED: " + string.Format("{0:$0.00}", -rrItmPrice));
                    text.Add(" ");
                }
                else
                {
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc);
                    text.Add("-REGULAR PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + string.Format("{0:$0.00}", rrItmOriginalPrice));
                    text.Add(" ");
                }
            }

            text.Add("----------------------------------------------------------------");
            text.Add("SUB TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrSubTotal));
            text.Add("SALES TAX");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrTax));
            text.Add("GRAND TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrGrandTotal));
            text.Add("================================================================");
            text.Add("AMOUNT SAVED");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrDiscount));
            text.Add("NEW POINTS");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrMemberPoints));
            text.Add("REMAINING POINTS");
            text.Add("$");
            text.Add(string.Format("{0:    0.00}", rrRemainingPoints));
            text.Add("================================================================");
            text.Add("CREDIT CARD TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrGrandTotal));

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
            e.Graphics.DrawString("*" + Convert.ToString(rrReceiptID) + "*", barcodeFont, Brushes.Black, 55, yPos + 3);
            ctrTemp += 1;

            text.Add(" ");
            text.Add(" ");
            //text.Add("               Thank you for shopping !");
            text.Add(parentForm.receiptLastComment);
            text.Add(" ");
            text.Add(" ");
            text.Add(" ");
            text.Add("***REPRINT RECEIPT - NOT ORIGINAL***");

            for (ctr2 = text.Count - 7; ctr2 <= text.Count - 1; ctr2++)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2], printFont, Brushes.Black, 0, yPos + 3);
                ctrTemp += 1;
            }

            e.HasMorePages = false;
        }

        /// <summary>
        /// Handles the PrintPage event of the pdPrint7 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PrintPageEventArgs"/> instance containing the event data.</param>
        private void pdPrint7_PrintPage(object sender, PrintPageEventArgs e)
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
            text.Add("AMEX");
            text.Add("DATE & TIME");
            text.Add(":");
            text.Add(Convert.ToString(rrSellDate) + " " + Convert.ToString(rrSellTime));
            text.Add("RECEIPT ID");
            text.Add(":");
            text.Add(rrStoreCode + "-" + Convert.ToString(rrReceiptID));
            text.Add("CASHIER ID");
            text.Add(":");
            text.Add(rrCashierID);
            text.Add("REGISTER NO");
            text.Add(":");
            text.Add(rrRegisterNum);
            text.Add("MEMBER ID");
            text.Add(":");
            text.Add(rrMemberID);
            text.Add("MEMBER NAME");
            text.Add(":");
            text.Add(rrMemberName);
            text.Add("----------------------------------------------------------------");
            text.Add("       DESCRIPTION                           QTY    PRICE    ");
            text.Add("----------------------------------------------------------------");

            SqlCommand cmd_Count = new SqlCommand("Get_Item_Count_From_ReceiptBody", parentForm.conn);
            cmd_Count.CommandType = CommandType.StoredProcedure;
            cmd_Count.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = rrReceiptID;
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
                cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = rrReceiptID;
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
                rrItmName = cmd.Parameters["@ItmName"].Value.ToString();
                rrItmQty = cmd.Parameters["@ItmQty"].Value.ToString();
                rrItmBasePrice = Convert.ToDouble(cmd.Parameters["@ItmBasePrice"].Value);
                rrItmDiscountPrice = Convert.ToDouble(cmd.Parameters["@ItmDiscountPrice"].Value);
                rrItmPrice = Convert.ToDouble(cmd.Parameters["@ItmPrice"].Value);
                rrItmUpc = cmd.Parameters["@ItmUpc"].Value.ToString();
                rrItmOriginalPrice = Math.Round(rrItmBasePrice * Convert.ToInt16(rrItmQty), 2);

                if (rrItmDiscountPrice == rrItmBasePrice & rrItmDiscountPrice > 0)
                {
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc);
                    text.Add("-FINAL SALE PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + string.Format("{0:$0.00}", rrItmOriginalPrice));
                    text.Add(" ");
                }
                else if (rrItmDiscountPrice > 0)
                {
                    rrItmSave = rrItmOriginalPrice - Convert.ToDouble(rrItmPrice);
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc + "(REGULAR PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + rrItmOriginalPrice + ")");
                    text.Add("-DISCOUNT PRICE: " + string.Format("{0:$0.00}", rrItmDiscountPrice) + " * " + rrItmQty + " =" + string.Format("{0:$0.00}", rrItmPrice) + " /SAVED: " + string.Format("{0:$0.00}", rrItmSave));
                    text.Add(" ");
                }
                else if (rrItmUpc == "000000999111")
                {
                    text.Add(rrItmName);
                    text.Add(" ");
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice));
                    text.Add(rrItmUpc);
                    text.Add("-AMOUNT USED: " + string.Format("{0:$0.00}", -rrItmPrice));
                    text.Add(" ");
                }
                else if (rrItmUpc == "000000999112")
                {
                    text.Add(rrItmName);
                    text.Add(" ");
                    text.Add(" ");
                    text.Add(" ");
                    text.Add(rrItmUpc);
                    text.Add("-COUPON USED");
                    text.Add(" ");
                }
                else if (rrItmPrice == 0)
                {
                    rrItmSave = rrItmOriginalPrice - Convert.ToDouble(rrItmPrice);
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc + "(REGULAR PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + rrItmOriginalPrice + ")");
                    text.Add("-DISCOUNT PRICE: " + string.Format("{0:$0.00}", rrItmPrice) + " * " + rrItmQty + " =" + string.Format("{0:$0.00}", rrItmPrice) + " /SAVED: " + string.Format("{0:$0.00}", rrItmSave));
                    text.Add(" ");
                }
                else if (rrItmBasePrice == 0 & rrItmQty == "0")
                {
                    text.Add(rrItmName);
                    text.Add(" ");
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice));
                    text.Add(rrItmUpc);
                    text.Add("-SAVED: " + string.Format("{0:$0.00}", -rrItmPrice));
                    text.Add(" ");
                }
                else
                {
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc);
                    text.Add("-REGULAR PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + string.Format("{0:$0.00}", rrItmOriginalPrice));
                    text.Add(" ");
                }
            }

            text.Add("----------------------------------------------------------------");
            text.Add("SUB TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrSubTotal));
            text.Add("SALES TAX");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrTax));
            text.Add("GRAND TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrGrandTotal));
            text.Add("================================================================");
            text.Add("AMOUNT SAVED");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrDiscount));
            text.Add("NEW POINTS");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrMemberPoints));
            text.Add("REMAINING POINTS");
            text.Add("$");
            text.Add(string.Format("{0:    0.00}", rrRemainingPoints));
            text.Add("================================================================");
            text.Add("CREDIT CARD TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrGrandTotal));

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
            e.Graphics.DrawString("*" + Convert.ToString(rrReceiptID) + "*", barcodeFont, Brushes.Black, 55, yPos + 3);
            ctrTemp += 1;

            text.Add(" ");
            text.Add(" ");
            //text.Add("               Thank you for shopping !");
            text.Add(parentForm.receiptLastComment);
            text.Add(" ");
            text.Add(" ");
            text.Add(" ");
            text.Add("***REPRINT RECEIPT - NOT ORIGINAL***");

            for (ctr2 = text.Count - 7; ctr2 <= text.Count - 1; ctr2++)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2], printFont, Brushes.Black, 0, yPos + 3);
                ctrTemp += 1;
            }

            e.HasMorePages = false;
        }

        /// <summary>
        /// Handles the PrintPage event of the pdPrint8 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PrintPageEventArgs"/> instance containing the event data.</param>
        private void pdPrint8_PrintPage(object sender, PrintPageEventArgs e)
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
            text.Add("DISCOVER");
            text.Add("DATE & TIME");
            text.Add(":");
            text.Add(Convert.ToString(rrSellDate) + " " + Convert.ToString(rrSellTime));
            text.Add("RECEIPT ID");
            text.Add(":");
            text.Add(rrStoreCode + "-" + Convert.ToString(rrReceiptID));
            text.Add("CASHIER ID");
            text.Add(":");
            text.Add(rrCashierID);
            text.Add("REGISTER NO");
            text.Add(":");
            text.Add(rrRegisterNum);
            text.Add("MEMBER ID");
            text.Add(":");
            text.Add(rrMemberID);
            text.Add("MEMBER NAME");
            text.Add(":");
            text.Add(rrMemberName);
            text.Add("----------------------------------------------------------------");
            text.Add("       DESCRIPTION                           QTY    PRICE    ");
            text.Add("----------------------------------------------------------------");

            SqlCommand cmd_Count = new SqlCommand("Get_Item_Count_From_ReceiptBody", parentForm.conn);
            cmd_Count.CommandType = CommandType.StoredProcedure;
            cmd_Count.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = rrReceiptID;
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
                cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = rrReceiptID;
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
                rrItmName = cmd.Parameters["@ItmName"].Value.ToString();
                rrItmQty = cmd.Parameters["@ItmQty"].Value.ToString();
                rrItmBasePrice = Convert.ToDouble(cmd.Parameters["@ItmBasePrice"].Value);
                rrItmDiscountPrice = Convert.ToDouble(cmd.Parameters["@ItmDiscountPrice"].Value);
                rrItmPrice = Convert.ToDouble(cmd.Parameters["@ItmPrice"].Value);
                rrItmUpc = cmd.Parameters["@ItmUpc"].Value.ToString();
                rrItmOriginalPrice = Math.Round(rrItmBasePrice * Convert.ToInt16(rrItmQty), 2);

                if (rrItmDiscountPrice == rrItmBasePrice & rrItmDiscountPrice > 0)
                {
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc);
                    text.Add("-FINAL SALE PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + string.Format("{0:$0.00}", rrItmOriginalPrice));
                    text.Add(" ");
                }
                else if (rrItmDiscountPrice > 0)
                {
                    rrItmSave = rrItmOriginalPrice - Convert.ToDouble(rrItmPrice);
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc + "(REGULAR PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + rrItmOriginalPrice + ")");
                    text.Add("-DISCOUNT PRICE: " + string.Format("{0:$0.00}", rrItmDiscountPrice) + " * " + rrItmQty + " =" + string.Format("{0:$0.00}", rrItmPrice) + " /SAVED: " + string.Format("{0:$0.00}", rrItmSave));
                    text.Add(" ");
                }
                else if (rrItmUpc == "000000999111")
                {
                    text.Add(rrItmName);
                    text.Add(" ");
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice));
                    text.Add(rrItmUpc);
                    text.Add("-AMOUNT USED: " + string.Format("{0:$0.00}", -rrItmPrice));
                    text.Add(" ");
                }
                else if (rrItmUpc == "000000999112")
                {
                    text.Add(rrItmName);
                    text.Add(" ");
                    text.Add(" ");
                    text.Add(" ");
                    text.Add(rrItmUpc);
                    text.Add("-COUPON USED");
                    text.Add(" ");
                }
                else if (rrItmPrice == 0)
                {
                    rrItmSave = rrItmOriginalPrice - Convert.ToDouble(rrItmPrice);
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc + "(REGULAR PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + rrItmOriginalPrice + ")");
                    text.Add("-DISCOUNT PRICE: " + string.Format("{0:$0.00}", rrItmPrice) + " * " + rrItmQty + " =" + string.Format("{0:$0.00}", rrItmPrice) + " /SAVED: " + string.Format("{0:$0.00}", rrItmSave));
                    text.Add(" ");
                }
                else if (rrItmBasePrice == 0 & rrItmQty == "0")
                {
                    text.Add(rrItmName);
                    text.Add(" ");
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice));
                    text.Add(rrItmUpc);
                    text.Add("-SAVED: " + string.Format("{0:$0.00}", -rrItmPrice));
                    text.Add(" ");
                }
                else
                {
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc);
                    text.Add("-REGULAR PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + string.Format("{0:$0.00}", rrItmOriginalPrice));
                    text.Add(" ");
                }
            }

            text.Add("----------------------------------------------------------------");
            text.Add("SUB TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrSubTotal));
            text.Add("SALES TAX");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrTax));
            text.Add("GRAND TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrGrandTotal));
            text.Add("================================================================");
            text.Add("AMOUNT SAVED");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrDiscount));
            text.Add("NEW POINTS");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrMemberPoints));
            text.Add("REMAINING POINTS");
            text.Add("$");
            text.Add(string.Format("{0:    0.00}", rrRemainingPoints));
            text.Add("================================================================");
            text.Add("CREDIT CARD TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrGrandTotal));

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
            e.Graphics.DrawString("*" + Convert.ToString(rrReceiptID) + "*", barcodeFont, Brushes.Black, 55, yPos + 3);
            ctrTemp += 1;

            text.Add(" ");
            text.Add(" ");
            //text.Add("               Thank you for shopping !");
            text.Add(parentForm.receiptLastComment);
            text.Add(" ");
            text.Add(" ");
            text.Add(" ");
            text.Add("***REPRINT RECEIPT - NOT ORIGINAL***");

            for (ctr2 = text.Count - 7; ctr2 <= text.Count - 1; ctr2++)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2], printFont, Brushes.Black, 0, yPos + 3);
                ctrTemp += 1;
            }

            e.HasMorePages = false;
        }

        /// <summary>
        /// Handles the PrintPage event of the pdPrint77 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PrintPageEventArgs"/> instance containing the event data.</param>
        private void pdPrint77_PrintPage(object sender, PrintPageEventArgs e)
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
            text.Add("GIFT CARD");
            text.Add("DATE & TIME");
            text.Add(":");
            text.Add(Convert.ToString(rrSellDate) + " " + Convert.ToString(rrSellTime));
            text.Add("RECEIPT ID");
            text.Add(":");
            //text.Add("BCAT-372031");
            text.Add(rrStoreCode + "-" + Convert.ToString(rrReceiptID));
            text.Add("CASHIER ID");
            text.Add(":");
            text.Add(Convert.ToString(rrCashierID));
            text.Add("REGISTER NO");
            text.Add(":");
            text.Add(Convert.ToString(rrRegisterNum));
            text.Add("MEMBER ID");
            text.Add(":");
            text.Add(Convert.ToString(rrMemberID));
            text.Add("MEMBER NAME");
            text.Add(":");
            text.Add(Convert.ToString(rrMemberName));
            text.Add("----------------------------------------------------------------");
            text.Add("       DESCRIPTION                          QTY   PRICE    ");
            text.Add("----------------------------------------------------------------");

            SqlCommand cmd_Count = new SqlCommand("Get_Item_Count_From_ReceiptBody", parentForm.conn);
            cmd_Count.CommandType = CommandType.StoredProcedure;
            cmd_Count.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = rrReceiptID;
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
                cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = rrReceiptID;
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
                rrItmName = cmd.Parameters["@ItmName"].Value.ToString();
                rrItmQty = cmd.Parameters["@ItmQty"].Value.ToString();
                rrItmBasePrice = Convert.ToDouble(cmd.Parameters["@ItmBasePrice"].Value);
                rrItmDiscountPrice = Convert.ToDouble(cmd.Parameters["@ItmDiscountPrice"].Value);
                rrItmPrice = Convert.ToDouble(cmd.Parameters["@ItmPrice"].Value);
                rrItmUpc = cmd.Parameters["@ItmUpc"].Value.ToString();
                rrItmOriginalPrice = Math.Round(rrItmBasePrice * Convert.ToInt16(rrItmQty), 2);

                if (rrItmDiscountPrice == rrItmBasePrice)
                {
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc);
                    text.Add("-FINAL SALE PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + string.Format("{0:$0.00}", rrItmOriginalPrice));
                    text.Add(" ");
                }
                else if (rrItmDiscountPrice > 0)
                {
                    rrItmSave = rrItmOriginalPrice - Convert.ToDouble(rrItmPrice);
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc + "(REGULAR PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + rrItmOriginalPrice + ")");
                    text.Add("-DISCOUNT PRICE: " + string.Format("{0:$0.00}", rrItmDiscountPrice) + " * " + rrItmQty + " =" + string.Format("{0:$0.00}", rrItmPrice) + " /SAVED: " + string.Format("{0:$0.00}", rrItmSave));
                    text.Add(" ");
                }
                else if (rrItmPrice == 0)
                {
                    rrItmSave = rrItmOriginalPrice - Convert.ToDouble(rrItmPrice);
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc + "(REGULAR PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + rrItmOriginalPrice + ")");
                    text.Add("-DISCOUNT PRICE: " + string.Format("{0:$0.00}", rrItmPrice) + " * " + rrItmQty + " =" + string.Format("{0:$0.00}", rrItmPrice) + " /SAVED: " + string.Format("{0:$0.00}", rrItmSave));
                    text.Add(" ");
                }
                else if (rrItmUpc == "000000999111")
                {
                    text.Add(rrItmName);
                    text.Add(" ");
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice));
                    text.Add(rrItmUpc);
                    text.Add("-AMOUNT USED: " + string.Format("{0:$0.00}", -rrItmPrice));
                    text.Add(" ");
                }
                else if (rrItmBasePrice == 0 & rrItmQty == "0")
                {
                    text.Add(rrItmName);
                    text.Add(" ");
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice));
                    text.Add(rrItmUpc);
                    text.Add("-SAVED: " + string.Format("{0:$0.00}", -rrItmPrice));
                    text.Add(" ");
                }
                else
                {
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc);
                    text.Add("-REGULAR PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + string.Format("{0:$0.00}", rrItmOriginalPrice));
                    text.Add(" ");
                }
            }

            text.Add("----------------------------------------------------------------");
            text.Add("SUB TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", Convert.ToDouble(rrSubTotal)));
            text.Add("SALES TAX");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", Convert.ToDouble(rrTax)));
            text.Add("GRAND TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrGrandTotal));
            text.Add("================================================================");
            text.Add("AMOUNT SAVED");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrDiscount));
            text.Add("NEW POINTS");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrMemberPoints));
            text.Add("REMAINING POINTS");
            text.Add("$");
            text.Add(string.Format("{0:    0.00}", rrRemainingPoints));
            text.Add("================================================================");
            text.Add("GIFT CARD TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrPay));

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
            e.Graphics.DrawString("*" + Convert.ToString(rrReceiptID) + "*", barcodeFont, Brushes.Black, 55, yPos + 3);
            ctrTemp += 1;

            text.Add(" ");
            text.Add(" ");
            //text.Add("               Thank you for shopping !");
            text.Add(parentForm.receiptLastComment);
            text.Add(" ");
            text.Add(" ");
            text.Add(" ");
            text.Add("***REPRINT RECEIPT - NOT ORIGINAL***");

            for (ctr2 = text.Count - 7; ctr2 <= text.Count - 1; ctr2++)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2], printFont, Brushes.Black, 0, yPos + 3);
                ctrTemp += 1;
            }

            e.HasMorePages = false;
        }

        /// <summary>
        /// Handles the PrintPage event of the pdPrint88 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PrintPageEventArgs"/> instance containing the event data.</param>
        private void pdPrint88_PrintPage(object sender, PrintPageEventArgs e)
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
            text.Add(Convert.ToString(rrSellDate) + " " + Convert.ToString(rrSellTime));
            text.Add("RECEIPT ID");
            text.Add(":");
            //text.Add("BCAT-372031");
            text.Add(parentForm.storeCode + "-" + Convert.ToString(rrReceiptID));
            text.Add("CASHIER ID");
            text.Add(":");
            text.Add(Convert.ToString(rrCashierID));
            text.Add("REGISTER NO");
            text.Add(":");
            text.Add(Convert.ToString(rrRegisterNum));
            text.Add("MEMBER ID");
            text.Add(":");
            text.Add(Convert.ToString(rrMemberID));
            text.Add("MEMBER NAME");
            text.Add(":");
            text.Add(Convert.ToString(rrMemberName));
            text.Add("----------------------------------------------------------------");
            text.Add("       DESCRIPTION                          QTY   PRICE    ");
            text.Add("----------------------------------------------------------------");

            SqlCommand cmd_Count = new SqlCommand("Get_Item_Count_From_ReceiptBody", parentForm.conn);
            cmd_Count.CommandType = CommandType.StoredProcedure;
            cmd_Count.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = rrReceiptID;
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
                cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = rrReceiptID;
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
                rrItmName = cmd.Parameters["@ItmName"].Value.ToString();
                rrItmQty = cmd.Parameters["@ItmQty"].Value.ToString();
                rrItmBasePrice = Convert.ToDouble(cmd.Parameters["@ItmBasePrice"].Value);
                rrItmDiscountPrice = Convert.ToDouble(cmd.Parameters["@ItmDiscountPrice"].Value);
                rrItmPrice = Convert.ToDouble(cmd.Parameters["@ItmPrice"].Value);
                rrItmUpc = cmd.Parameters["@ItmUpc"].Value.ToString();
                rrItmOriginalPrice = Math.Round(rrItmBasePrice * Convert.ToInt16(rrItmQty), 2);

                if (rrItmDiscountPrice == rrItmBasePrice & rrItmDiscountPrice > 0)
                {
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc);
                    text.Add("-FINAL SALE PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + string.Format("{0:$0.00}", rrItmOriginalPrice));
                    text.Add(" ");
                }
                else if (rrItmDiscountPrice > 0)
                {
                    rrItmSave = rrItmOriginalPrice - Convert.ToDouble(rrItmPrice);
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc + "(REGULAR PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + rrItmOriginalPrice + ")");
                    text.Add("-DISCOUNT PRICE: " + string.Format("{0:$0.00}", rrItmDiscountPrice) + " * " + rrItmQty + " =" + string.Format("{0:$0.00}", rrItmPrice) + " /SAVED: " + string.Format("{0:$0.00}", rrItmSave));
                    text.Add(" ");
                }
                else if (rrItmUpc == "000000999111")
                {
                    text.Add(rrItmName);
                    text.Add(" ");
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice));
                    text.Add(rrItmUpc);
                    text.Add("-AMOUNT USED: " + string.Format("{0:$0.00}", -rrItmPrice));
                    text.Add(" ");
                }
                else if (rrItmUpc == "000000999112")
                {
                    text.Add(rrItmName);
                    text.Add(" ");
                    text.Add(" ");
                    text.Add(" ");
                    text.Add(rrItmUpc);
                    text.Add("-COUPON USED");
                    text.Add(" ");
                }
                else if (rrItmPrice == 0)
                {
                    rrItmSave = rrItmOriginalPrice - Convert.ToDouble(rrItmPrice);
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc + "(REGULAR PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + rrItmOriginalPrice + ")");
                    text.Add("-DISCOUNT PRICE: " + string.Format("{0:$0.00}", rrItmPrice) + " * " + rrItmQty + " =" + string.Format("{0:$0.00}", rrItmPrice) + " /SAVED: " + string.Format("{0:$0.00}", rrItmSave));
                    text.Add(" ");
                }
                else if (rrItmBasePrice == 0 & rrItmQty == "0")
                {
                    text.Add(rrItmName);
                    text.Add(" ");
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice));
                    text.Add(rrItmUpc);
                    text.Add("-SAVED: " + string.Format("{0:$0.00}", -rrItmPrice));
                    text.Add(" ");
                }
                else
                {
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc);
                    text.Add("-REGULAR PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + string.Format("{0:$0.00}", rrItmOriginalPrice));
                    text.Add(" ");
                }
            }

            text.Add("----------------------------------------------------------------");
            text.Add("SUB TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", Convert.ToDouble(rrSubTotal)));
            text.Add("SALES TAX");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", Convert.ToDouble(rrTax)));
            text.Add("GRAND TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrGrandTotal));
            text.Add("================================================================");
            text.Add("AMOUNT SAVED");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrDiscount));
            text.Add("NEW POINTS");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrMemberPoints));
            text.Add("REMAINING POINTS");
            text.Add("$");
            text.Add(string.Format("{0:    0.00}", rrRemainingPoints));
            text.Add("================================================================");
            text.Add("STORE CREDIT TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrPay));

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
            
            if (rrStoreCreditID == 0)
            {
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
                e.Graphics.DrawString("*" + Convert.ToString(rrReceiptID) + "*", barcodeFont, Brushes.Black, 55, yPos + 3);
                ctrTemp += 1;

                text.Add(" ");
                text.Add(" ");
                //text.Add("               Thank you for shopping !");
                text.Add(parentForm.receiptLastComment);
                text.Add(" ");
                text.Add(" ");
                text.Add(" ");
                text.Add("***REPRINT RECEIPT - NOT ORIGINAL***");

                for (ctr2 = text.Count - 7; ctr2 <= text.Count - 1; ctr2++)
                {
                    yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                    e.Graphics.DrawString((String)text[ctr2], printFont, Brushes.Black, 0, yPos + 3);
                    ctrTemp += 1;
                }

                e.HasMorePages = false;
            }
            else
            {
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
                text.Add(Convert.ToString(rrStoreCreditID));
                //text.Add("AMOUNT");
                //text.Add(":");
                //text.Add("$" + Convert.ToString(rrAmount));
                text.Add("BALANCE");
                text.Add(":");
                text.Add("$" + Convert.ToString(rrBalance));
                text.Add("EXPIRATION DATE");
                text.Add(":");
                text.Add(Convert.ToString(rrExpDate));

                for (ctr2 = text.Count - 9; ctr2 <= text.Count - 1; ctr2 += 3)
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
                e.Graphics.DrawString("*" + Convert.ToString(rrReceiptID) + "*", barcodeFont, Brushes.Black, 55, yPos + 3);
                ctrTemp += 1;

                text.Add(" ");
                text.Add(" ");
                //text.Add("               Thank you for shopping !");
                text.Add(parentForm.receiptLastComment);
                text.Add(" ");
                text.Add(" ");
                text.Add(" ");
                text.Add("***REPRINT RECEIPT - NOT ORIGINAL***");

                for (ctr2 = text.Count - 7; ctr2 <= text.Count - 1; ctr2++)
                {
                    yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                    e.Graphics.DrawString((String)text[ctr2], printFont, Brushes.Black, 0, yPos + 3);
                    ctrTemp += 1;
                }

                e.HasMorePages = false;
            }
        }

        /// <summary>
        /// Handles the PrintPage event of the pdPrint99 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PrintPageEventArgs"/> instance containing the event data.</param>
        private void pdPrint99_PrintPage(object sender, PrintPageEventArgs e)
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
            text.Add(Convert.ToString(rrSellDate) + " " + Convert.ToString(rrSellTime));
            text.Add("RECEIPT ID");
            text.Add(":");
            text.Add(rrStoreCode + "-" + Convert.ToString(rrReceiptID));
            text.Add("CASHIER ID");
            text.Add(":");
            text.Add(rrCashierID);
            text.Add("REGISTER NO");
            text.Add(":");
            text.Add(rrRegisterNum);
            text.Add("MEMBER ID");
            text.Add(":");
            text.Add(rrMemberID);
            text.Add("MEMBER NAME");
            text.Add(":");
            text.Add(rrMemberName);
            text.Add("----------------------------------------------------------------");
            text.Add("       DESCRIPTION                           QTY    PRICE    ");
            text.Add("----------------------------------------------------------------");

            SqlCommand cmd_Count = new SqlCommand("Get_Item_Count_From_ReceiptBody", parentForm.conn);
            cmd_Count.CommandType = CommandType.StoredProcedure;
            cmd_Count.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = rrReceiptID;
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
                cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = rrReceiptID;
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
                rrItmName = cmd.Parameters["@ItmName"].Value.ToString();
                rrItmQty = cmd.Parameters["@ItmQty"].Value.ToString();
                rrItmBasePrice = Convert.ToDouble(cmd.Parameters["@ItmBasePrice"].Value);
                rrItmDiscountPrice = Convert.ToDouble(cmd.Parameters["@ItmDiscountPrice"].Value);
                rrItmPrice = Convert.ToDouble(cmd.Parameters["@ItmPrice"].Value);
                rrItmUpc = cmd.Parameters["@ItmUpc"].Value.ToString();
                rrItmOriginalPrice = Math.Round(rrItmBasePrice * Convert.ToInt16(rrItmQty), 2);

                if (rrItmDiscountPrice == rrItmBasePrice & rrItmDiscountPrice > 0)
                {
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc);
                    text.Add("-FINAL SALE PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + string.Format("{0:$0.00}", rrItmOriginalPrice));
                    text.Add(" ");
                }
                else if (rrItmDiscountPrice > 0)
                {
                    rrItmSave = rrItmOriginalPrice - Convert.ToDouble(rrItmPrice);
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc + "(REGULAR PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + rrItmOriginalPrice + ")");
                    text.Add("-DISCOUNT PRICE: " + string.Format("{0:$0.00}", rrItmDiscountPrice) + " * " + rrItmQty + " =" + string.Format("{0:$0.00}", rrItmPrice) + " /SAVED: " + string.Format("{0:$0.00}", rrItmSave));
                    text.Add(" ");
                }
                else if (rrItmUpc == "000000999111")
                {
                    text.Add(rrItmName);
                    text.Add(" ");
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice));
                    text.Add(rrItmUpc);
                    text.Add("-AMOUNT USED: " + string.Format("{0:$0.00}", -rrItmPrice));
                    text.Add(" ");
                }
                else if (rrItmUpc == "000000999112")
                {
                    text.Add(rrItmName);
                    text.Add(" ");
                    text.Add(" ");
                    text.Add(" ");
                    text.Add(rrItmUpc);
                    text.Add("-COUPON USED");
                    text.Add(" ");
                }
                else if (rrItmPrice == 0)
                {
                    rrItmSave = rrItmOriginalPrice - Convert.ToDouble(rrItmPrice);
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc + "(REGULAR PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + rrItmOriginalPrice + ")");
                    text.Add("-DISCOUNT PRICE: " + string.Format("{0:$0.00}", rrItmPrice) + " * " + rrItmQty + " =" + string.Format("{0:$0.00}", rrItmPrice) + " /SAVED: " + string.Format("{0:$0.00}", rrItmSave));
                    text.Add(" ");
                }
                else if (rrItmBasePrice == 0 & rrItmQty == "0")
                {
                    text.Add(rrItmName);
                    text.Add(" ");
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice));
                    text.Add(rrItmUpc);
                    text.Add("-SAVED: " + string.Format("{0:$0.00}", -rrItmPrice));
                    text.Add(" ");
                }
                else
                {
                    text.Add(rrItmName);
                    text.Add(rrItmQty);
                    text.Add("$");
                    text.Add(string.Format("{0:$0.00}", rrItmPrice) + " T");
                    text.Add(rrItmUpc);
                    text.Add("-REGULAR PRICE: " + string.Format("{0:$0.00}", rrItmBasePrice) + " * " + rrItmQty + " = " + string.Format("{0:$0.00}", rrItmOriginalPrice));
                    text.Add(" ");
                }
            }

            SqlCommand cmd_CashPay = new SqlCommand("Get_CashPay_From_Multi", parentForm.conn);
            cmd_CashPay.CommandType = CommandType.StoredProcedure;
            cmd_CashPay.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = rrReceiptID;
            SqlParameter CashPay_Param = cmd_CashPay.Parameters.Add("@PayAmount", SqlDbType.Money);
            CashPay_Param.Direction = ParameterDirection.Output;

            SqlCommand cmd_CreditPay = new SqlCommand("Get_CreditPay_From_Multi", parentForm.conn);
            cmd_CreditPay.CommandType = CommandType.StoredProcedure;
            cmd_CreditPay.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = rrReceiptID;
            SqlParameter CreditPay_Param = cmd_CreditPay.Parameters.Add("@PayAmount", SqlDbType.Money);
            CreditPay_Param.Direction = ParameterDirection.Output;

            SqlCommand cmd_DebitPay = new SqlCommand("Get_DebitPay_From_Multi", parentForm.conn);
            cmd_DebitPay.CommandType = CommandType.StoredProcedure;
            cmd_DebitPay.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = rrReceiptID;
            SqlParameter DebitPay_Param = cmd_DebitPay.Parameters.Add("@PayAmount", SqlDbType.Money);
            DebitPay_Param.Direction = ParameterDirection.Output;

            SqlCommand cmd_TCreditPay = new SqlCommand("Get_TCreditPay_From_Multi", parentForm.conn);
            cmd_TCreditPay.CommandType = CommandType.StoredProcedure;
            cmd_TCreditPay.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = rrReceiptID;
            SqlParameter cmd_TCreditPay_Param = cmd_TCreditPay.Parameters.Add("@PayAmount", SqlDbType.Money);
            cmd_TCreditPay_Param.Direction = ParameterDirection.Output;

            SqlCommand cmd_GiftCard = new SqlCommand("Get_GiftCard_From_Multi", parentForm.conn);
            cmd_GiftCard.CommandType = CommandType.StoredProcedure;
            cmd_GiftCard.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = rrReceiptID;
            SqlParameter GiftCard_Param = cmd_GiftCard.Parameters.Add("@PayAmount", SqlDbType.Money);
            GiftCard_Param.Direction = ParameterDirection.Output;

            SqlCommand cmd_StoreCredit = new SqlCommand("Get_StoreCredit_From_Multi", parentForm.conn);
            cmd_StoreCredit.CommandType = CommandType.StoredProcedure;
            cmd_StoreCredit.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = rrReceiptID;
            SqlParameter StoreCredit_Param = cmd_StoreCredit.Parameters.Add("@PayAmount", SqlDbType.Money);
            StoreCredit_Param.Direction = ParameterDirection.Output;

            parentForm.conn.Open();
            cmd_CashPay.ExecuteNonQuery();
            cmd_CreditPay.ExecuteNonQuery();
            cmd_DebitPay.ExecuteNonQuery();
            cmd_TCreditPay.ExecuteNonQuery();
            cmd_GiftCard.ExecuteNonQuery();
            cmd_StoreCredit.ExecuteNonQuery();
            parentForm.conn.Close();

            if (cmd_CashPay.Parameters["@PayAmount"].Value == DBNull.Value)
            {
                rrCashPay = 0;
            }
            else
            {
                rrCashPay = Convert.ToDouble(cmd_CashPay.Parameters["@PayAmount"].Value);
            }

            if (cmd_CreditPay.Parameters["@PayAmount"].Value == DBNull.Value)
            {
                rrCreditPay = 0;
            }
            else
            {
                rrCreditPay = Convert.ToDouble(cmd_CreditPay.Parameters["@PayAmount"].Value);
            }

            if (cmd_DebitPay.Parameters["@PayAmount"].Value == DBNull.Value)
            {
                rrDebitPay = 0;
            }
            else
            {
                rrDebitPay = Convert.ToDouble(cmd_DebitPay.Parameters["@PayAmount"].Value);
            }

            if (cmd_TCreditPay.Parameters["@PayAmount"].Value == DBNull.Value)
            {
                rrTCreditpay = 0;
            }
            else
            {
                rrTCreditpay = Convert.ToDouble(cmd_TCreditPay.Parameters["@PayAmount"].Value);
            }

            if (cmd_GiftCard.Parameters["@PayAmount"].Value == DBNull.Value)
            {
                rrGiftcard = 0;
            }
            else
            {
                rrGiftcard = Convert.ToDouble(cmd_GiftCard.Parameters["@PayAmount"].Value);
            }

            if (cmd_StoreCredit.Parameters["@PayAmount"].Value == DBNull.Value)
            {
                rrStoreCredit = 0;
            }
            else
            {
                rrStoreCredit = Convert.ToDouble(cmd_StoreCredit.Parameters["@PayAmount"].Value);
            }
          
            text.Add("----------------------------------------------------------------");
            text.Add("SUB TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrSubTotal));
            text.Add("SALES TAX");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrTax));
            text.Add("GRAND TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrGrandTotal));
            text.Add("================================================================");
            text.Add("AMOUNT SAVED");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrDiscount));
            text.Add("NEW POINTS");
            text.Add("$");
            text.Add(string.Format("{0:  0.00}", rrMemberPoints));
            text.Add("REMAINING POINTS");
            text.Add("$");
            text.Add(string.Format("{0:    0.00}", rrRemainingPoints));
            text.Add("================================================================");
            text.Add("CASH");
            text.Add("$");
            text.Add(string.Format("{0:    0.00}", rrCashPay));
            text.Add("CREDIT TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:    0.00}", rrCreditPay));
            text.Add("DEBIT TOTAL");
            text.Add("$");
            text.Add(string.Format("{0:    0.00}", rrDebitPay));
            text.Add("CREDIT TOTAL (TERMINAL)");
            text.Add("$");
            text.Add(string.Format("{0:    0.00}", rrTCreditpay));

            text.Add("GIFT CARD");
            text.Add("$");
            text.Add(string.Format("{0:    0.00}", rrGiftcard));

            text.Add("STORE CREDIT");
            text.Add("$");
            text.Add(string.Format("{0:    0.00}", rrStoreCredit));
            text.Add("================================================================");
            text.Add("TOTAL PAY");
            text.Add("$");
            text.Add(string.Format("{0:    0.00}", rrPay));
            text.Add("CASH CHANGE");
            text.Add("$");
            text.Add(string.Format("{0:    0.00}", rrChange));

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

            for (ctr2 = printItmCount + 2; ctr2 <= text.Count - 40; ctr2 += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 2], printFont2).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont2, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont2, Brushes.Black, 215, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont2, Brushes.Black, xPos, yPos + 3);
                ctrTemp += 1;
            }

            for (ctr2 = printItmCount + 8; ctr2 <= text.Count - 38; ctr2 += 3)
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

            for (ctr2 = printItmCount + 12; ctr2 <= text.Count - 29; ctr2 += 3)
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

            for (ctr2 = printItmCount + 22; ctr2 <= text.Count - 9; ctr2 += 3)
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

            for (ctr2 = printItmCount + 41; ctr2 <= text.Count - 1; ctr2 += 3)
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
            e.Graphics.DrawString("*" + Convert.ToString(rrReceiptID) + "*", barcodeFont, Brushes.Black, 55, yPos + 3);
            ctrTemp += 1;

            text.Add(" ");
            text.Add(" ");
            //text.Add("               Thank you for shopping !");
            text.Add(parentForm.receiptLastComment);
            text.Add(" ");
            text.Add(" ");
            text.Add(" ");
            text.Add("***REPRINT RECEIPT - NOT ORIGINAL***");

            for (ctr2 = text.Count - 7; ctr2 <= text.Count - 1; ctr2++)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2], printFont, Brushes.Black, 0, yPos + 3);
                ctrTemp += 1;
            }

            e.HasMorePages = false;
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
        /// Handles the Click event of the button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("Show_NumberOfTransaction", parentForm.conn);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("@RegNum", SqlDbType.NVarChar).Value = cmbREG.Text.Trim().ToUpper();
            cmd1.Parameters.Add("@PayBy", SqlDbType.Int).Value = Convert.ToInt16(cmbPayBy.Text.Trim());
            cmd1.Parameters.Add("@SellDate", SqlDbType.NVarChar).Value = txtSellDate.Text.Trim();

            SqlDataAdapter adapt = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adapt.SelectCommand = cmd1;

            parentForm.conn.Open();
            adapt.Fill(dt);
            parentForm.conn.Close();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;
        }

        /// <summary>
        /// Handles the Click event of the button2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
                return;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value.ToString() != "")
                {
                    txtReceiptID.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    btnPrint_Click(null, null);
                }
            }
        }
    }
}