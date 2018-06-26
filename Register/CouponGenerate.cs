// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 05-02-2013
// ***********************************************************************
// <copyright file="CouponGenerate.cs" company="Beauty4u">
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
    /// Class CouponGenerate.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class CouponGenerate : Form
    {
        /// <summary>
        /// The parent form
        /// </summary>
        public MainForm parentForm;

        /// <summary>
        /// The command
        /// </summary>
        SqlCommand cmd;
        /// <summary>
        /// The seed
        /// </summary>
        /// <summary>
        /// The issuer
        /// </summary>
        /// <summary>
        /// The cp date
        /// </summary>
        /// <summary>
        /// The cp time
        /// </summary>
        string seed, Issuer, cpDate, cpTime;
        /// <summary>
        /// The new coupon number
        /// </summary>
        Int64 newCouponNum;
        /// <summary>
        /// The new coupon number length
        /// </summary>
        int newCouponNumLen;
        /// <summary>
        /// The new coupon number to string
        /// </summary>
        string newCouponNumToString;
        /// <summary>
        /// The cp printing opt
        /// </summary>
        int cpPrintingOpt = 0;

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
        /// Initializes a new instance of the <see cref="CouponGenerate"/> class.
        /// </summary>
        /// <param name="isr">The isr.</param>
        public CouponGenerate(string isr)
        {
            InitializeComponent();
            Issuer = isr;
        }

        /// <summary>
        /// Handles the Click event of the btnGeneral20 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnGeneral20_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the btnHair20 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnHair20_Click(object sender, EventArgs e)
        {
            cpPrintingOpt = 6;

            DateTime currentTime = DateTime.Now;
            cpDate = string.Format("{0:MM/dd/yyyy}", currentTime);
            cpTime = string.Format("{0:T}", currentTime);
            seed = parentForm.storeCode.ToUpper() + "HP20";

            cmd = new SqlCommand("Get_Latest_CouponNum", parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@Seed", SqlDbType.NVarChar).Value = seed + "%";
            SqlParameter LatestCouponNum_Param = cmd.Parameters.Add("@LatestCouponNum", SqlDbType.NVarChar, 15);
            LatestCouponNum_Param.Direction = ParameterDirection.Output;

            parentForm.conn.Open();
            cmd.ExecuteNonQuery();
            parentForm.conn.Close();

            if (cmd.Parameters["@LatestCouponNum"].Value == DBNull.Value)
            {
                newCouponNum = 0;
            }
            else
            {
                newCouponNum = Convert.ToInt64((cmd.Parameters["@LatestCouponNum"].Value.ToString().Substring(6))) + 1;
            }
            newCouponNumLen = Convert.ToString(newCouponNum).Length;

            switch (newCouponNumLen)
            {
                case 1:
                    newCouponNumToString = seed + "00000" + Convert.ToString(newCouponNum);
                    newCouponNumLen = 0;
                    break;
                case 2:
                    newCouponNumToString = seed + "0000" + Convert.ToString(newCouponNum);
                    newCouponNumLen = 0;
                    break;
                case 3:
                    newCouponNumToString = seed + "000" + Convert.ToString(newCouponNum);
                    newCouponNumLen = 0;
                    break;
                case 4:
                    newCouponNumToString = seed + "00" + Convert.ToString(newCouponNum);
                    newCouponNumLen = 0;
                    break;
                case 5:
                    newCouponNumToString = seed + "0" + Convert.ToString(newCouponNum);
                    newCouponNumLen = 0;
                    break;
                case 6:
                    newCouponNumToString = seed + Convert.ToString(newCouponNum);
                    newCouponNumLen = 0;
                    break;
                default:
                    newCouponNumToString = Convert.ToString(newCouponNum);
                    newCouponNumLen = 0;
                    break;
            }

            cmd.CommandText = "Create_Coupon";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@CpStoreCode", SqlDbType.NVarChar).Value = parentForm.storeCode.ToUpper();
            cmd.Parameters.Add("@CpIssuer", SqlDbType.NVarChar).Value = Issuer;
            cmd.Parameters.Add("@CpNum", SqlDbType.NVarChar).Value = newCouponNumToString;
            cmd.Parameters.Add("@CpType", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@CpAmt", SqlDbType.Money).Value = 20;
            cmd.Parameters.Add("@CpIssDate", SqlDbType.NVarChar).Value = cpDate;
            cmd.Parameters.Add("@CpIsstime", SqlDbType.NVarChar).Value = cpTime;
            cmd.Parameters.Add("@CpExpDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today.AddYears(1));

            parentForm.conn.Open();
            cmd.ExecuteNonQuery();
            parentForm.conn.Close();

            Int32 retVal;
            String errMsg;
            apiAlias.StatusMonitoring pMonitorCB = new apiAlias.StatusMonitoring(StatusMonitoring);

            pdPrint = new PrintDocument();
            pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage);
            pdPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;

            try
            {
                // Open Printer Monitor of Status API.
                mpHandle = apiAlias.BiOpenMonPrinter(apiAlias.TYPE_PRINTER, parentForm.PRINTER_NAME);
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
                            pdPrint.Print();
                            cpPrintingOpt = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                MessageBox.Show("Failed to open StatusAPI.", errMsg, MessageBoxButtons.OK);
                cpPrintingOpt = 0;
            }
            finally
            {
                // Close Printer Monitor.
                if (mpHandle > 0)
                {
                    if (apiAlias.BiCloseMonPrinter(mpHandle) != apiAlias.SUCCESS)
                        MessageBox.Show("Failed to close printer status monitor.", "", MessageBoxButtons.OK);
                }

                cpPrintingOpt = 0;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnWig10 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnWig10_Click(object sender, EventArgs e)
        {
            cpPrintingOpt = 7;

            DateTime currentTime = DateTime.Now;
            cpDate = string.Format("{0:MM/dd/yyyy}", currentTime);
            cpTime = string.Format("{0:T}", currentTime);
            seed = parentForm.storeCode.ToUpper() + "WP10";

            cmd = new SqlCommand("Get_Latest_CouponNum", parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@Seed", SqlDbType.NVarChar).Value = seed + "%";
            SqlParameter LatestCouponNum_Param = cmd.Parameters.Add("@LatestCouponNum", SqlDbType.NVarChar, 15);
            LatestCouponNum_Param.Direction = ParameterDirection.Output;

            parentForm.conn.Open();
            cmd.ExecuteNonQuery();
            parentForm.conn.Close();

            if (cmd.Parameters["@LatestCouponNum"].Value == DBNull.Value)
            {
                newCouponNum = 0;
            }
            else
            {
                newCouponNum = Convert.ToInt64((cmd.Parameters["@LatestCouponNum"].Value.ToString().Substring(6))) + 1;
            }
            newCouponNumLen = Convert.ToString(newCouponNum).Length;

            switch (newCouponNumLen)
            {
                case 1:
                    newCouponNumToString = seed + "00000" + Convert.ToString(newCouponNum);
                    newCouponNumLen = 0;
                    break;
                case 2:
                    newCouponNumToString = seed + "0000" + Convert.ToString(newCouponNum);
                    newCouponNumLen = 0;
                    break;
                case 3:
                    newCouponNumToString = seed + "000" + Convert.ToString(newCouponNum);
                    newCouponNumLen = 0;
                    break;
                case 4:
                    newCouponNumToString = seed + "00" + Convert.ToString(newCouponNum);
                    newCouponNumLen = 0;
                    break;
                case 5:
                    newCouponNumToString = seed + "0" + Convert.ToString(newCouponNum);
                    newCouponNumLen = 0;
                    break;
                case 6:
                    newCouponNumToString = seed + Convert.ToString(newCouponNum);
                    newCouponNumLen = 0;
                    break;
                default:
                    newCouponNumToString = Convert.ToString(newCouponNum);
                    newCouponNumLen = 0;
                    break;
            }

            cmd.CommandText = "Create_Coupon";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@CpStoreCode", SqlDbType.NVarChar).Value = parentForm.storeCode.ToUpper();
            cmd.Parameters.Add("@CpIssuer", SqlDbType.NVarChar).Value = Issuer;
            cmd.Parameters.Add("@CpNum", SqlDbType.NVarChar).Value = newCouponNumToString;
            cmd.Parameters.Add("@CpType", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@CpAmt", SqlDbType.Money).Value = 10;
            cmd.Parameters.Add("@CpIssDate", SqlDbType.NVarChar).Value = cpDate;
            cmd.Parameters.Add("@CpIsstime", SqlDbType.NVarChar).Value = cpTime;
            cmd.Parameters.Add("@CpExpDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today.AddYears(1));

            parentForm.conn.Open();
            cmd.ExecuteNonQuery();
            parentForm.conn.Close();

            Int32 retVal;
            String errMsg;
            apiAlias.StatusMonitoring pMonitorCB = new apiAlias.StatusMonitoring(StatusMonitoring);

            pdPrint = new PrintDocument();
            pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage);
            pdPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;

            try
            {
                // Open Printer Monitor of Status API.
                mpHandle = apiAlias.BiOpenMonPrinter(apiAlias.TYPE_PRINTER, parentForm.PRINTER_NAME);
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
                            pdPrint.Print();
                            cpPrintingOpt = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                MessageBox.Show("Failed to open StatusAPI.", errMsg, MessageBoxButtons.OK);
                cpPrintingOpt = 0;
            }
            finally
            {
                // Close Printer Monitor.
                if (mpHandle > 0)
                {
                    if (apiAlias.BiCloseMonPrinter(mpHandle) != apiAlias.SUCCESS)
                        MessageBox.Show("Failed to close printer status monitor.", "", MessageBoxButtons.OK);
                }

                cpPrintingOpt = 0;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnWig20 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnWig20_Click(object sender, EventArgs e)
        {
            cpPrintingOpt = 9;

            DateTime currentTime = DateTime.Now;
            cpDate = string.Format("{0:MM/dd/yyyy}", currentTime);
            cpTime = string.Format("{0:T}", currentTime);
            seed = parentForm.storeCode.ToUpper() + "WP20";

            cmd = new SqlCommand("Get_Latest_CouponNum", parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@Seed", SqlDbType.NVarChar).Value = seed + "%";
            SqlParameter LatestCouponNum_Param = cmd.Parameters.Add("@LatestCouponNum", SqlDbType.NVarChar, 15);
            LatestCouponNum_Param.Direction = ParameterDirection.Output;

            parentForm.conn.Open();
            cmd.ExecuteNonQuery();
            parentForm.conn.Close();

            if (cmd.Parameters["@LatestCouponNum"].Value == DBNull.Value)
            {
                newCouponNum = 0;
            }
            else
            {
                newCouponNum = Convert.ToInt64((cmd.Parameters["@LatestCouponNum"].Value.ToString().Substring(6))) + 1;
            }
            newCouponNumLen = Convert.ToString(newCouponNum).Length;

            switch (newCouponNumLen)
            {
                case 1:
                    newCouponNumToString = seed + "00000" + Convert.ToString(newCouponNum);
                    newCouponNumLen = 0;
                    break;
                case 2:
                    newCouponNumToString = seed + "0000" + Convert.ToString(newCouponNum);
                    newCouponNumLen = 0;
                    break;
                case 3:
                    newCouponNumToString = seed + "000" + Convert.ToString(newCouponNum);
                    newCouponNumLen = 0;
                    break;
                case 4:
                    newCouponNumToString = seed + "00" + Convert.ToString(newCouponNum);
                    newCouponNumLen = 0;
                    break;
                case 5:
                    newCouponNumToString = seed + "0" + Convert.ToString(newCouponNum);
                    newCouponNumLen = 0;
                    break;
                case 6:
                    newCouponNumToString = seed + Convert.ToString(newCouponNum);
                    newCouponNumLen = 0;
                    break;
                default:
                    newCouponNumToString = Convert.ToString(newCouponNum);
                    newCouponNumLen = 0;
                    break;
            }

            cmd.CommandText = "Create_Coupon";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@CpStoreCode", SqlDbType.NVarChar).Value = parentForm.storeCode.ToUpper();
            cmd.Parameters.Add("@CpIssuer", SqlDbType.NVarChar).Value = Issuer;
            cmd.Parameters.Add("@CpNum", SqlDbType.NVarChar).Value = newCouponNumToString;
            cmd.Parameters.Add("@CpType", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@CpAmt", SqlDbType.Money).Value = 20;
            cmd.Parameters.Add("@CpIssDate", SqlDbType.NVarChar).Value = cpDate;
            cmd.Parameters.Add("@CpIsstime", SqlDbType.NVarChar).Value = cpTime;
            cmd.Parameters.Add("@CpExpDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today.AddYears(1));

            parentForm.conn.Open();
            cmd.ExecuteNonQuery();
            parentForm.conn.Close();

            Int32 retVal;
            String errMsg;
            apiAlias.StatusMonitoring pMonitorCB = new apiAlias.StatusMonitoring(StatusMonitoring);

            pdPrint = new PrintDocument();
            pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage);
            pdPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;

            try
            {
                // Open Printer Monitor of Status API.
                mpHandle = apiAlias.BiOpenMonPrinter(apiAlias.TYPE_PRINTER, parentForm.PRINTER_NAME);
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
                            pdPrint.Print();
                            cpPrintingOpt = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                MessageBox.Show("Failed to open StatusAPI.", errMsg, MessageBoxButtons.OK);
                cpPrintingOpt = 0;
            }
            finally
            {
                // Close Printer Monitor.
                if (mpHandle > 0)
                {
                    if (apiAlias.BiCloseMonPrinter(mpHandle) != apiAlias.SUCCESS)
                        MessageBox.Show("Failed to close printer status monitor.", "", MessageBoxButtons.OK);
                }

                cpPrintingOpt = 0;
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
        /// Handles the PrintPage event of the pdPrint control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PrintPageEventArgs"/> instance containing the event data.</param>
        private void pdPrint_PrintPage(object sender, PrintPageEventArgs e)
        {
            ArrayList text = new ArrayList();
            Single yPos, xPos;
            int ctr, ctr2, ctrTemp;

            printFont = new Font("Arial", 10);
            printFont2 = new Font("Arial", 9);
            printFont3 = new Font("Arial", 7, FontStyle.Bold);
            printFont4 = new Font("Arial", 12);
            printBoldFont = new Font("Arial", 14, FontStyle.Bold);
            barcodeFont = new Font("3 of 9 Barcode", 22);

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
            text.Add(Convert.ToString(cpDate) + " " + Convert.ToString(cpTime));
            text.Add("TASK NAME");
            text.Add(":");
            text.Add("COUPON");
            text.Add("ISSUER");
            text.Add(":");
            text.Add(Issuer);
            text.Add("REGISTER NO");
            text.Add(":");
            text.Add(parentForm.cashRegisterNum);

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
            for (ctr = 8; ctr <= 19; ctr += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr + 1], printFont2, Brushes.Black, 120, yPos + 3);
                e.Graphics.DrawString((String)text[ctr + 2], printFont2, Brushes.Black, 125, yPos + 3);
                ctrTemp += 1;
            }

            text.Add(" ");
            text.Add(" ");
            text.Add(" ");

            if (cpPrintingOpt == 6)
            {
                text.Add("HAIR COUPON 20%");
            }
            else if (cpPrintingOpt == 7)
            {
                text.Add("WIG COUPON 10%");
            }
            else if (cpPrintingOpt == 9)
            {
                text.Add("WIG COUPON 20%");
            }
            
            text.Add(" ");
            text.Add(" ");

            for (ctr2 = text.Count - 6; ctr2 <= text.Count - 1; ctr2++)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2], printBoldFont, Brushes.Black, 65, yPos);
                ctrTemp += 1;
            }

            text.Add("COUPON NUMBER");
            text.Add(":");
            text.Add(newCouponNumToString);

            //text.Add("DISCOUNT");
            //text.Add(":");
            //text.Add("$" + Convert.ToString(rrAmount));
            //text.Add("BALANCE");
            //text.Add(":");
            //text.Add("$" + Convert.ToString(rrBalance));

            text.Add("ISSUE DATE");
            text.Add(":");
            text.Add(string.Format("{0:MM/dd/yyyy}", DateTime.Today));

            text.Add("EXPIRATION DATE");
            text.Add(":");
            text.Add(string.Format("{0:MM/dd/yyyy}", DateTime.Today.AddYears(1)));
            text.Add(" ");
            text.Add(" ");
            text.Add(" ");

            for (ctr2 = text.Count - 12; ctr2 <= text.Count - 1; ctr2 += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                //xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr2 + 2], printFont2).Width;
                e.Graphics.DrawString((String)text[ctr2], printFont2, Brushes.Black, 30, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 1], printFont2, Brushes.Black, 150, yPos + 3);
                e.Graphics.DrawString((String)text[ctr2 + 2], printFont2, Brushes.Black, 155, yPos + 3);
                ctrTemp += 1;
            }

            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString("*" + newCouponNumToString + "*", barcodeFont, Brushes.Black, 5, yPos + 3);
            ctrTemp += 1;

            text.Add(" ");
            text.Add("    *VALID FOR " + parentForm.storeName.ToUpper() + " STORE ONLY");
            text.Add("    *ONLY ONE COUPON CAN BE USED");
            text.Add("      FOR A TRANSACTION");
            text.Add("    *NO RETURNABLE & NO REFUNDABLE");
            text.Add("    *NO DOUBLE DISCOUNT");

            for (ctr2 = text.Count - 6; ctr2 <= text.Count - 1; ctr2++)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2], printFont2, Brushes.Black, 0, yPos + 3);
                ctrTemp += 1;
            }

            text.Add(" ");
            text.Add(" ");
            text.Add(parentForm.receiptLastComment);
            text.Add(" ");
            text.Add(" ");
            text.Add(" ");

            for (ctr2 = text.Count - 6; ctr2 <= text.Count - 1; ctr2++)
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
        /// Handles the Load event of the CouponGenerate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CouponGenerate_Load(object sender, EventArgs e)
        {
            btnWig10.Enabled = true;

            if (parentForm.storeCode == "OH" | parentForm.storeCode == "UM" | parentForm.storeCode == "CH")
            {
                btnHair20.Enabled = true;
                btnWig20.Enabled = true;
            }
        }
    }
}