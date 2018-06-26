// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 10-30-2013
// ***********************************************************************
// <copyright file="ReprintRegisterTransaction.cs" company="Beauty4u">
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
    /// Class ReprintRegisterTransaction.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class ReprintRegisterTransaction : Form
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
        /// The d
        /// </summary>
        DateTime d;
        /// <summary>
        /// The transaction identifier
        /// </summary>
        Int64 TransactionID;
        /// <summary>
        /// The reg date
        /// </summary>
        /// <summary>
        /// The reg time
        /// </summary>
        /// <summary>
        /// The reg cashier identifier
        /// </summary>
        /// <summary>
        /// The reg manager identifier
        /// </summary>
        string regDate, regTime, regCashierID, regManagerID;
        /// <summary>
        /// The reg start amount
        /// </summary>
        /// <summary>
        /// The reg cash sales amount
        /// </summary>
        /// <summary>
        /// The reg cash real amount
        /// </summary>
        /// <summary>
        /// The reg withdraw amount
        /// </summary>
        /// <summary>
        /// The reg shortage amount
        /// </summary>
        double regStartAmount, regCashSalesAmount, regCashRealAmount, regWithdrawAmount, regShortageAmount;

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
        /// The print font4
        /// </summary>
        /// <summary>
        /// The print bold font
        /// </summary>
        Font printFont, printFont2, printFont4, printBoldFont;
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
        /// Initializes a new instance of the <see cref="ReprintRegisterTransaction"/> class.
        /// </summary>
        public ReprintRegisterTransaction()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the ReprintRegisterTransaction control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ReprintRegisterTransaction_Load(object sender, EventArgs e)
        {
            txtDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
        }

        /// <summary>
        /// Handles the Click event of the btnPrintClosingRegister control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnPrintClosingRegister_Click(object sender, EventArgs e)
        {
            if (txtDate.Text == "")
            {
                MyMessageBox.ShowBox("INPUT DATE", "ERROR");
                txtDate.Select();
                txtDate.Focus();
                return;
            }
            else
            {
                if (DateTime.TryParse(txtDate.Text.Trim(), out d))
                {
                    cmd = new SqlCommand("Get_ClosingRegister_Information", parentForm.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = parentForm.cashRegisterNum.ToUpper();
                    cmd.Parameters.Add("@RegDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", d);
                    SqlParameter CheckNum_Param = cmd.Parameters.Add("@CheckNum", SqlDbType.TinyInt);
                    SqlParameter TransactionID_Param = cmd.Parameters.Add("@TransactionID", SqlDbType.BigInt);
                    SqlParameter RegStartAmount_Param = cmd.Parameters.Add("@RegStartAmount", SqlDbType.Money);
                    SqlParameter RegCashSalesAmount_Param = cmd.Parameters.Add("@RegCashSalesAmount", SqlDbType.Money);
                    SqlParameter RegCashRealAmount_Param = cmd.Parameters.Add("@RegCashRealAmount", SqlDbType.Money);
                    SqlParameter RegWithdrawAmount_Param = cmd.Parameters.Add("@RegWithdrawAmount", SqlDbType.Money);
                    SqlParameter RegShortageAmount_Param = cmd.Parameters.Add("@RegShortageAmount", SqlDbType.Money);
                    SqlParameter RegTime_Param = cmd.Parameters.Add("@RegTime", SqlDbType.NVarChar, 50);
                    SqlParameter RegCashierID_Param = cmd.Parameters.Add("@RegCashierID", SqlDbType.NVarChar, 50);
                    SqlParameter RegManagerID_Param = cmd.Parameters.Add("@RegManagerID", SqlDbType.NVarChar, 50);
                    CheckNum_Param.Direction = ParameterDirection.Output;
                    TransactionID_Param.Direction = ParameterDirection.Output;
                    RegStartAmount_Param.Direction = ParameterDirection.Output;
                    RegCashSalesAmount_Param.Direction = ParameterDirection.Output;
                    RegCashRealAmount_Param.Direction = ParameterDirection.Output;
                    RegWithdrawAmount_Param.Direction = ParameterDirection.Output;
                    RegShortageAmount_Param.Direction = ParameterDirection.Output;
                    RegTime_Param.Direction = ParameterDirection.Output;
                    RegCashierID_Param.Direction = ParameterDirection.Output;
                    RegManagerID_Param.Direction = ParameterDirection.Output;

                    parentForm.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm.conn.Close();

                    if (Convert.ToInt16(cmd.Parameters["@CheckNum"].Value) != 0)
                    {
                        TransactionID = Convert.ToInt64(cmd.Parameters["@TransactionID"].Value);
                        regStartAmount = Convert.ToDouble(cmd.Parameters["@RegStartAmount"].Value);
                        regCashSalesAmount = Convert.ToDouble(cmd.Parameters["@RegCashSalesAmount"].Value);
                        regCashRealAmount = Convert.ToDouble(cmd.Parameters["@RegCashRealAmount"].Value);
                        regWithdrawAmount = Convert.ToDouble(cmd.Parameters["@RegWithdrawAmount"].Value);
                        regShortageAmount = Convert.ToDouble(cmd.Parameters["@RegShortageAmount"].Value);
                        regDate = string.Format("{0:MM/dd/yyyy}", d);
                        regTime = Convert.ToString(cmd.Parameters["@RegTime"].Value);
                        regCashierID = Convert.ToString(cmd.Parameters["@RegCashierID"].Value);
                        regManagerID = Convert.ToString(cmd.Parameters["@RegManagerID"].Value);

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
                                    //pdPrint1.Print();
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
                                        pdPrint.Print();
                                    }
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
                    else
                    {
                        MyMessageBox.ShowBox("NOT YET CLOSED", "ERROR");
                        txtDate.SelectAll();
                        txtDate.Focus();
                        return;
                    }
                }
                else
                {
                    MyMessageBox.ShowBox("INVALID DATE", "ERROR");
                    txtDate.SelectAll();
                    txtDate.Focus();
                    return;
                }
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
        /// Handles the DoubleClick event of the txtDate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        /// <summary>
        /// Handles the DateSelected event of the monthCalendar1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DateRangeEventArgs"/> instance containing the event data.</param>
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar1.SelectionStart));
            monthCalendar1.Visible = false;
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
            int ctr, ctrTemp;

            //string regDate = string.Format("{0:d}", DateTime.Now);
            //string regTime = string.Format("{0:T}", DateTime.Now);

            printFont = new Font("Arial", 10);
            printFont2 = new Font("Arial", 9);
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

            text.Add("REG STATUS");
            text.Add(":");
            text.Add("CLOSING REGISTER");
            text.Add("DATE & TIME");
            text.Add(":");
            text.Add(regDate + " " + regTime);
            text.Add("TRANSACTION ID");
            text.Add(":");
            text.Add(Convert.ToString(TransactionID));
            text.Add("STORE CODE");
            text.Add(":");
            text.Add(parentForm.storeCode);
            text.Add("REGISTER NO");
            text.Add(":");
            text.Add(parentForm.cashRegisterNum);
            text.Add("CASHIER ID");
            text.Add(":");
            text.Add(regCashierID);
            text.Add("MANAGER ID");
            text.Add(":");
            text.Add(regManagerID);
            text.Add("----------------------------------------------------------------");
            text.Add("CASH START");
            text.Add(":");
            text.Add(string.Format("{0:$0.00}", regStartAmount));
            text.Add("CASH SALES");
            text.Add(":");
            text.Add(string.Format("{0:$0.00}", regCashSalesAmount));
            text.Add("CASH WITHDRAW");
            text.Add(":");
            text.Add(string.Format("{0:$0.00}", regWithdrawAmount));
            text.Add("----------------------------------------------------------------");
            text.Add("CASH IN DRAWER");
            text.Add(":");
            text.Add(string.Format("{0:$0.00}", regCashRealAmount));
            text.Add("DIFFERENCE");
            text.Add(":");
            text.Add(string.Format("{0:$0.00}", regShortageAmount));

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
            for (ctr = 8; ctr <= 28; ctr += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr + 1], printFont2, Brushes.Black, 118, yPos + 3);
                e.Graphics.DrawString((String)text[ctr + 2], printFont2, Brushes.Black, 128, yPos + 3);
                ctrTemp += 1;
            }

            ctr = 29;
            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            for (ctr = 30; ctr <= 38; ctr += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr + 1], printFont2, Brushes.Black, 118, yPos + 3);
                e.Graphics.DrawString((String)text[ctr + 2], printFont2, Brushes.Black, 128, yPos + 3);
                ctrTemp += 1;
            }

            ctr = 39;
            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            for (ctr = 40; ctr <= 45; ctr += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr + 1], printFont2, Brushes.Black, 118, yPos + 3);
                e.Graphics.DrawString((String)text[ctr + 2], printFont2, Brushes.Black, 128, yPos + 3);
                ctrTemp += 1;
            }

            text.Add(" ");
            text.Add(" ");
            text.Add(" ");
            text.Add(" ");
            text.Add("**REPRINT TRANSACTION - NOT ORIGINAL**");

            ctr = text.Count - 5;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;
            ctr = text.Count - 4;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;
            ctr = text.Count - 3;
            yPos = ctrTemp * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;
            ctr = text.Count - 2;
            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 0, yPos + 3);
            ctr = text.Count - 1;
            xPos = (e.PageBounds.Width - 10) - e.Graphics.MeasureString((string)text[ctr], printFont4).Width;
            e.Graphics.DrawString((String)text[ctr], printFont4, Brushes.Black, xPos, yPos + 3);

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
    }
}