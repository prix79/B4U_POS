// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 04-25-2017
// ***********************************************************************
// <copyright file="ReprintStoreCredit.cs" company="Beauty4u">
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
    /// Class ReprintStoreCredit.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class ReprintStoreCredit : Form
    {
        /// <summary>
        /// The parent form
        /// </summary>
        public MainForm parentForm;

        /// <summary>
        /// The rr store credit identifier
        /// </summary>
        Int64 rrStoreCreditID = 0;
        /// <summary>
        /// The rr amount
        /// </summary>
        double rrAmount;
        /// <summary>
        /// The rr balance
        /// </summary>
        double rrBalance = 0;
        /// <summary>
        /// The rr start date
        /// </summary>
        string rrStartDate;
        /// <summary>
        /// The rr exp date
        /// </summary>
        string rrExpDate;

        /// <summary>
        /// The rs date
        /// </summary>
        /// <summary>
        /// The rs time
        /// </summary>
        string rsDate, rsTime;

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
        /// Initializes a new instance of the <see cref="ReprintStoreCredit"/> class.
        /// </summary>
        public ReprintStoreCredit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the ReprintStoreCredit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ReprintStoreCredit_Load(object sender, EventArgs e)
        {
            txtStoreCreditID.Select();
            txtStoreCreditID.Focus();
        }

        /// <summary>
        /// Handles the Click event of the btnPrint control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            rsDate = string.Format("{0:MM/dd/yyyy}", currentTime);
            rsTime = string.Format("{0:T}", currentTime);

            if (Int64.TryParse(txtStoreCreditID.Text, out rrStoreCreditID))
            {
                SqlCommand cmd_StoreCreditInfo = new SqlCommand("Get_StoreCredit_Info2", parentForm.conn);
                cmd_StoreCreditInfo.CommandType = CommandType.StoredProcedure;
                cmd_StoreCreditInfo.Parameters.Add("@StoreCreditID", SqlDbType.BigInt).Value = rrStoreCreditID;
                SqlParameter Amount_Param = cmd_StoreCreditInfo.Parameters.Add("@Amount", SqlDbType.Money);
                SqlParameter Balance_Param = cmd_StoreCreditInfo.Parameters.Add("@Balance", SqlDbType.Money);
                SqlParameter StartDate_Param = cmd_StoreCreditInfo.Parameters.Add("@StartDate", SqlDbType.NVarChar, 20);
                SqlParameter ExpDate_Param = cmd_StoreCreditInfo.Parameters.Add("@ExpDate", SqlDbType.NVarChar, 20);
                Amount_Param.Direction = ParameterDirection.Output;
                Balance_Param.Direction = ParameterDirection.Output;
                StartDate_Param.Direction = ParameterDirection.Output;
                ExpDate_Param.Direction = ParameterDirection.Output;

                parentForm.conn.Open();
                cmd_StoreCreditInfo.ExecuteNonQuery();
                parentForm.conn.Close();

                rrAmount = Convert.ToDouble(cmd_StoreCreditInfo.Parameters["@Amount"].Value);
                rrBalance = Convert.ToDouble(cmd_StoreCreditInfo.Parameters["@Balance"].Value);
                rrStartDate = cmd_StoreCreditInfo.Parameters["@StartDate"].Value.ToString();
                rrExpDate = cmd_StoreCreditInfo.Parameters["@ExpDate"].Value.ToString();

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

                txtStoreCreditID.Clear();
                txtStoreCreditID.Select();
                txtStoreCreditID.Focus();
            }
            else
            {
                MyMessageBox.ShowBox("INVALID STORE CREDIT ID", "ERROR");
                txtStoreCreditID.SelectAll();
                txtStoreCreditID.Focus();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnLatest control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnLatest_Click(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            rsDate = string.Format("{0:MM/dd/yyyy}", currentTime);
            rsTime = string.Format("{0:T}", currentTime);

            SqlCommand cmd_StoreCreditID = new SqlCommand("Get_Latest_StoreCreditID", parentForm.conn);
            cmd_StoreCreditID.CommandType = CommandType.StoredProcedure;
            cmd_StoreCreditID.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = parentForm.cashRegisterNum;
            SqlParameter Latest_Param = cmd_StoreCreditID.Parameters.Add("@StoreCreditID", SqlDbType.BigInt);
            Latest_Param.Direction = ParameterDirection.Output;

            parentForm.conn.Open();
            cmd_StoreCreditID.ExecuteNonQuery();
            parentForm.conn.Close();

            if (cmd_StoreCreditID.Parameters["@StoreCreditID"].Value == DBNull.Value)
            {
                MyMessageBox.ShowBox("NO DATA", "ERROR");
                txtStoreCreditID.Select();
                txtStoreCreditID.Focus();
            }
            else
            {
                rrStoreCreditID = Convert.ToInt64(cmd_StoreCreditID.Parameters["@StoreCreditID"].Value);

                SqlCommand cmd_StoreCreditInfo = new SqlCommand("Get_StoreCredit_Info2", parentForm.conn);
                cmd_StoreCreditInfo.CommandType = CommandType.StoredProcedure;
                cmd_StoreCreditInfo.Parameters.Add("@StoreCreditID", SqlDbType.BigInt).Value = rrStoreCreditID;
                SqlParameter Amount_Param = cmd_StoreCreditInfo.Parameters.Add("@Amount", SqlDbType.Money);
                SqlParameter Balance_Param = cmd_StoreCreditInfo.Parameters.Add("@Balance", SqlDbType.Money);
                SqlParameter StartDate_Param = cmd_StoreCreditInfo.Parameters.Add("@StartDate", SqlDbType.NVarChar, 20);
                SqlParameter ExpDate_Param = cmd_StoreCreditInfo.Parameters.Add("@ExpDate", SqlDbType.NVarChar, 20);
                Amount_Param.Direction = ParameterDirection.Output;
                Balance_Param.Direction = ParameterDirection.Output;
                StartDate_Param.Direction = ParameterDirection.Output;
                ExpDate_Param.Direction = ParameterDirection.Output;

                parentForm.conn.Open();
                cmd_StoreCreditInfo.ExecuteNonQuery();
                parentForm.conn.Close();

                rrAmount = Convert.ToDouble(cmd_StoreCreditInfo.Parameters["@Amount"].Value);
                rrBalance = Convert.ToDouble(cmd_StoreCreditInfo.Parameters["@Balance"].Value);
                rrStartDate = cmd_StoreCreditInfo.Parameters["@StartDate"].Value.ToString();
                rrExpDate = cmd_StoreCreditInfo.Parameters["@ExpDate"].Value.ToString();

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

                txtStoreCreditID.Select();
                txtStoreCreditID.Focus();
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
            //printFont3 = new Font("Arial", 8);
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

            text.Add("DATE & TIME");
            text.Add(":");
            text.Add(Convert.ToString(rsDate) + " " + Convert.ToString(rsTime));
            text.Add("TASK NAME");
            text.Add(":");
            text.Add("REPRINT STORE CREDIT");
            text.Add("CASHIER ID");
            text.Add(":");
            text.Add(parentForm.employeeID);
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
            text.Add("STORE CREDIT");
            text.Add(" ");
            text.Add(" ");

            for (ctr2 = text.Count - 6; ctr2 <= text.Count - 1; ctr2++)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr2], printBoldFont, Brushes.Black, 65, yPos);
                ctrTemp += 1;
            }

            text.Add("STORE CREDIT ID");
            text.Add(":");
            text.Add(Convert.ToString(rrStoreCreditID));
            text.Add("ORIGINAL AMOUNT");
            text.Add(":");
            text.Add("$" + Convert.ToString(rrAmount));
            text.Add("BALANCE");
            text.Add(":");
            text.Add("$" + Convert.ToString(rrBalance));

            text.Add("GENERATE DATE");
            text.Add(":");
            text.Add(Convert.ToString(rrStartDate));

            text.Add("EXPIRATION DATE");
            text.Add(":");
            text.Add(Convert.ToString(rrExpDate));

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

            //text.Add("               Thank you for shopping !");
            text.Add(parentForm.receiptLastComment);
            text.Add(" ");
            text.Add(" ");
            text.Add(" ");
            text.Add(" REPRINT STORE CREDIT - NOT ORIGINAL");

            for (ctr2 = text.Count - 5; ctr2 <= text.Count - 1; ctr2++)
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
        /// Gets a value indicating whether [show without activation].
        /// </summary>
        /// <value><c>true</c> if [show without activation]; otherwise, <c>false</c>.</value>
        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }
    }
}