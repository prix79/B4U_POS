// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 04-25-2017
// ***********************************************************************
// <copyright file="CashWithdraw.cs" company="Beauty4u">
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
    /// Class CashWithdraw.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class CashWithdraw : Form
    {
        /// <summary>
        /// The parent form
        /// </summary>
        public MainForm parentForm;
        /// <summary>
        /// The names collection
        /// </summary>
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        /// <summary>
        /// The cashier identifier
        /// </summary>
        string cashierID;

        /// <summary>
        /// The manager identifier
        /// </summary>
        /// <summary>
        /// The manager password
        /// </summary>
        string managerID, managerPassword;

        /// <summary>
        /// The amount
        /// </summary>
        double amount = 0;
        /// <summary>
        /// The transaction identifier
        /// </summary>
        Int64 transactionID;

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
        /// Initializes a new instance of the <see cref="CashWithdraw"/> class.
        /// </summary>
        /// <param name="empID">The emp identifier.</param>
        public CashWithdraw(string empID)
        {
            InitializeComponent();
            cashierID = empID;
        }

        /// <summary>
        /// Handles the Click event of the txtWithdraw control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtWithdraw_Click(object sender, EventArgs e)
        {
            if (txtManagerID.Text == "")
            {
                MyMessageBox.ShowBox("INPUT MANAGER ID", "ERROR");
                //MessageBox.Show("Input Manager ID", "Error");
                return;
            }

            if (txtPsw.Text == "")
            {
                MyMessageBox.ShowBox("INPUT PASSWORD", "ERROR");
                //MessageBox.Show("Input password", "Error");
                return;
            }

            managerID = txtManagerID.Text.Trim().ToString().ToUpper();
            managerPassword = txtPsw.Text.Trim().ToString().ToUpper();
            SqlCommand cmd1 = new SqlCommand("Get_ManagerID", parentForm.conn);

            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = managerID.ToUpper().ToString();
            cmd1.Parameters.Add("@Password", SqlDbType.NVarChar).Value = managerPassword;
            SqlParameter UserName_Param = cmd1.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50);
            UserName_Param.Direction = ParameterDirection.Output;

            parentForm.conn.Open();
            cmd1.ExecuteNonQuery();
            parentForm.conn.Close();

            if (cmd1.Parameters["@FirstName"].Value == DBNull.Value)
            {
                MyMessageBox.ShowBox("AUTHENTICATION FAILED", "ERROR");
                return;
            }


            DateTime currentTime = DateTime.Now;

            string withDrawDate = string.Format("{0:MM/dd/yyyy}", currentTime);
            string withDrawTime = string.Format("{0:T}", currentTime);

            if(double.TryParse(txtAmount.Text, out amount))
            {
                SqlCommand cmd = new SqlCommand("Create_CashWithdraw", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = parentForm.cashRegisterNum;
                cmd.Parameters.Add("@TransactionStatus", SqlDbType.NVarChar).Value = "WITHDRAW";
                cmd.Parameters.Add("@RegWithdrawAmount", SqlDbType.Money).Value = amount;
                cmd.Parameters.Add("@RegDate", SqlDbType.NVarChar).Value = withDrawDate;
                cmd.Parameters.Add("@RegTime", SqlDbType.NVarChar).Value = withDrawTime;
                cmd.Parameters.Add("@RegCashierID", SqlDbType.NVarChar).Value = cashierID;
                cmd.Parameters.Add("@RegManagerID", SqlDbType.NVarChar).Value = txtManagerID.Text.Trim().ToString().ToUpper();

                parentForm.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm.conn.Close();

                SqlCommand cmd_TransactionID = new SqlCommand("Get_TransactionID", parentForm.conn);
                cmd_TransactionID.CommandType = CommandType.StoredProcedure;
                cmd_TransactionID.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = parentForm.cashRegisterNum;
                cmd_TransactionID.Parameters.Add("@RegDate", SqlDbType.NVarChar).Value = withDrawDate;
                cmd_TransactionID.Parameters.Add("@TransactionStatus", SqlDbType.NVarChar).Value = "WITHDRAW";
                SqlParameter TransactionID_Param = cmd_TransactionID.Parameters.Add("@TransactionID", SqlDbType.BigInt);
                TransactionID_Param.Direction = ParameterDirection.Output;
                parentForm.conn.Open();
                cmd_TransactionID.ExecuteNonQuery();
                parentForm.conn.Close();

                transactionID = Convert.ToInt64(cmd_TransactionID.Parameters["@TransactionID"].Value);

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
                                pdPrint.Print();
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

                MyMessageBox.ShowBox("SUCCESSFULLY WITHDRAWN", "INFORMATION");
                //MessageBox.Show("Successfully withdrawn", "Info");
                this.Close();
            }
            else
            {
                MyMessageBox.ShowBox("INVALID AMOUNT", "ERROR");
                //MessageBox.Show("Invalid amount", "Error");
                return;
            }
        }

        /// <summary>
        /// Handles the Load event of the CashWithdraw control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CashWithdraw_Load(object sender, EventArgs e)
        {
            SqlDataReader dReader;
            SqlCommand cmd = new SqlCommand("Get_User_Level", parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;

            parentForm.conn.Open();
            dReader = cmd.ExecuteReader();
            if (dReader.HasRows == true)
            {
                while (dReader.Read())
                    namesCollection.Add(dReader["empLoginID"].ToString());
            }
            else
            {
                MyMessageBox.ShowBox("USER DATA NOT FOUND", "ERROR");
                //MessageBox.Show("Data not found");
            }

            dReader.Close();
            parentForm.conn.Close();

            txtManagerID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtManagerID.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtManagerID.AutoCompleteCustomSource = namesCollection;

            Int32 retVal;
            String errMsg;
            apiAlias.StatusMonitoring pMonitorCB = new apiAlias.StatusMonitoring(StatusMonitoring);

            pdPrint = new PrintDocument();
            //pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage);
            pdPrint.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;

            try
            {
                // Open Printer Monitor of Status API.
                mpHandle = apiAlias.BiOpenMonPrinter(apiAlias.TYPE_PRINTER, pdPrint.PrinterSettings.PrinterName);
                if (mpHandle < 0)
                    MessageBox.Show("Failed to open printer status monitor.", "Printing error", MessageBoxButtons.OK);
                else
                {
                    //isFinish = false;
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
                        DisplayStatusMessage();

                        // If an error occurred, restore the recoverable error.
                        if (cancelErr)
                            retVal = apiAlias.BiCancelError(mpHandle);
                        else
                            // Call the function to open cash drawer.
                            OpenDrawer(pdPrint.PrinterSettings.PrinterName);

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

            txtAmount.SelectAll();
            txtAmount.Focus();
        }

        /// <summary>
        /// Handles the Click event of the cmdCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmdCancel_Click(object sender, EventArgs e)
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
            int ctr, ctrTemp;

            string regDate = string.Format("{0:d}", DateTime.Now);
            string regTime = string.Format("{0:T}", DateTime.Now);

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
            text.Add("CASH WITHDRAW");
            text.Add("DATE & TIME");
            text.Add(":");
            text.Add(Convert.ToString(regDate) + " " + Convert.ToString(regTime));
            text.Add("TRANSACTION ID");
            text.Add(":");
            text.Add(Convert.ToString(transactionID));
            text.Add("STORE CODE");
            text.Add(":");
            text.Add(parentForm.storeCode);
            text.Add("REGISTER NO");
            text.Add(":");
            text.Add(parentForm.cashRegisterNum);
            text.Add("MANAGER ID");
            text.Add(":");
            text.Add(txtManagerID.Text.ToUpper());
            text.Add("----------------------------------------------------------------");
            text.Add("AMOUNT");
            text.Add(":");
            text.Add(string.Format("{0:$0.00}", amount));
            text.Add("----------------------------------------------------------------");


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
            for (ctr = 8; ctr <= 25; ctr += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr + 1], printFont2, Brushes.Black, 118, yPos + 3);
                e.Graphics.DrawString((String)text[ctr + 2], printFont2, Brushes.Black, 128, yPos + 3);
                ctrTemp += 1;
            }

            ctr = 26;
            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            for (ctr = 27; ctr <= 29; ctr += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr + 1], printFont2, Brushes.Black, 118, yPos + 3);
                e.Graphics.DrawString((String)text[ctr + 2], printFont2, Brushes.Black, 128, yPos + 3);
                ctrTemp += 1;
            }

            ctr = 30;
            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            text.Add(" ");
            text.Add(" ");
            text.Add(" ");
            text.Add("Sign :");
            text.Add(" ______________________________");

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
            xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr], printFont4).Width;
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
        /// Displays the status message.
        /// </summary>
        private void DisplayStatusMessage()
        {
            if ((printStatus & apiAlias.ASB_PRINT_SUCCESS) == apiAlias.ASB_PRINT_SUCCESS)
                //MessageBox.Show("Complete printing.", "", MessageBoxButtons.OK);
            if ((printStatus & apiAlias.ASB_NO_RESPONSE) == apiAlias.ASB_NO_RESPONSE)
                MessageBox.Show("No response.", "", MessageBoxButtons.OK);
            if ((printStatus & apiAlias.ASB_COVER_OPEN) == apiAlias.ASB_COVER_OPEN)
                MessageBox.Show("Cover is open.", "", MessageBoxButtons.OK);
            if ((printStatus & apiAlias.ASB_AUTOCUTTER_ERR) == apiAlias.ASB_AUTOCUTTER_ERR)
                MessageBox.Show("Autocutter error occurred.", "", MessageBoxButtons.OK);
            if (((printStatus & apiAlias.ASB_PAPER_END_FIRST) == apiAlias.ASB_PAPER_END_FIRST) || ((printStatus & apiAlias.ASB_PAPER_END_SECOND) == apiAlias.ASB_PAPER_END_SECOND))
                MessageBox.Show("Roll paper end sensor: paper not present.", "", MessageBoxButtons.OK);
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
        /// Handles the Click event of the txtAmount control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtAmount_Click(object sender, EventArgs e)
        {
            txtAmount.SelectAll();
            txtAmount.Focus();
        }
    }
}