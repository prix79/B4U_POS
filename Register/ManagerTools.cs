// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 02-06-2018
// ***********************************************************************
// <copyright file="ManagerTools.cs" company="Beauty4u">
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
    /// Class ManagerTools.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class ManagerTools : Form
    {
        /// <summary>
        /// The parent form
        /// </summary>
        public MainForm parentForm;
        /// <summary>
        /// The authentication
        /// </summary>
        public bool auth = false;
        /// <summary>
        /// The emp identifier
        /// </summary>
        public string empID = string.Empty;
        /// <summary>
        /// The row count
        /// </summary>
        int rowCount = 0;
        /// <summary>
        /// The qty
        /// </summary>
        int qty = 0;
        /// <summary>
        /// The unit price
        /// </summary>
        double unitPrice = 0;
        /// <summary>
        /// The discount price
        /// </summary>
        double discountPrice = 0;
        /// <summary>
        /// The price
        /// </summary>
        double price = 0;

        /// <summary>
        /// The selected row index
        /// </summary>
        public int selectedRowIndex = 0;
        /// <summary>
        /// The basic price
        /// </summary>
        public string basicPrice;
        /// <summary>
        /// The s discount price
        /// </summary>
        string sDiscountPrice;

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

        //Int64 rrReceiptID;
        //string rrStoreCode;
        //string rrCashierID;
        //string rrRegisterNum;
        //string rrMemberID;
        //string rrMemberName;
        //int rrPayBy;
        //string rrSellDate;
        //string rrSellTime;
        //double rrSubTotal;
        //double rrTax;
        //double rrGrandTotal;
        //double rrDiscount;
        //double rrMemberPoints;
        //double rrPay;
        //double rrChange;

        //string rrItmBrand;
        //string rrItmName;
        //string rrItmGroup1;
        //string rrItmGroup2;
        //string rrItmGroup3;
        //string rrItmUpc;
        //double rrItmBasePrice;
        //double rrItmDiscountPrice;
        //string rrItmPrice;
        //double rrItmTax;
        //string rrItmQty;
        //double rrItmOriginalPrice;
        //double rrItmSave;

        //private const string PRINTER_NAME = "EPSON TM-T88III Receipt";
        /// <summary>
        /// The pd print
        /// </summary>
        PrintDocument pdPrint;
        //PrintDocument pdPrint1;
        //PrintDocument pdPrint4;
        //PrintDocument pdPrint5;
        //Font printFont, printFont2, printFont3, printFont4, printBoldFont;
        //int printItmCount;
        /// <summary>
        /// The mp handle
        /// </summary>
        Int32 mpHandle;
        //Boolean isFinish;
        /// <summary>
        /// The cancel error
        /// </summary>
        Boolean cancelErr;
        /// <summary>
        /// The print status
        /// </summary>
        int printStatus;

        /// <summary>
        /// The MGR identifier
        /// </summary>
        public string mgrID = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerTools"/> class.
        /// </summary>
        /// <param name="employeeID">The employee identifier.</param>
        public ManagerTools(string employeeID)
        {
            InitializeComponent();
            empID = employeeID;
        }

        /// <summary>
        /// Handles the Load event of the ManagerTools control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ManagerTools_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handles the Click event of the btnOpenCashDrawer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnOpenCashDrawer_Click(object sender, EventArgs e)
        {
            if (auth == true)
            {
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
            }
            else
            {
                Authentication authenticationForm = new Authentication(11);
                authenticationForm.parentForm1 = this.parentForm;
                authenticationForm.parentForm2 = this;
                authenticationForm.ShowDialog();
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
        /// Handles the Click event of the btnClosingRegister control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnClosingRegister_Click(object sender, EventArgs e)
        {
            SqlCommand cmd_Check_Register_Status = new SqlCommand("Check_Register_Status", parentForm.conn);
            cmd_Check_Register_Status.CommandType = CommandType.StoredProcedure;
            cmd_Check_Register_Status.Parameters.Clear();
            cmd_Check_Register_Status.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = parentForm.cashRegisterNum;
            cmd_Check_Register_Status.Parameters.Add("@TransactionStatus", SqlDbType.NVarChar).Value = "END";
            cmd_Check_Register_Status.Parameters.Add("@RegDate", SqlDbType.NVarChar).Value = DateTime.Today.ToString("d");
            SqlParameter Output_Param = cmd_Check_Register_Status.Parameters.Add("@Output", SqlDbType.NVarChar, 20);
            Output_Param.Direction = ParameterDirection.Output;

            parentForm.conn.Open();
            cmd_Check_Register_Status.ExecuteNonQuery();
            parentForm.conn.Close();

            if (cmd_Check_Register_Status.Parameters["@Output"].Value != DBNull.Value)
            {
                MyMessageBox.ShowBox("REGISTER IS ALREADEY CLOSED TODAY", "ERROR");
                return;
            }
            else
            {
                if (auth == true)
                {
                    ClosingRegister closingRegisterForm = new ClosingRegister(empID);
                    closingRegisterForm.parentForm = this.parentForm;
                    closingRegisterForm.ShowDialog();
                }
                else
                {
                    Authentication authenticationForm = new Authentication(9);
                    authenticationForm.parentForm1 = this.parentForm;
                    authenticationForm.parentForm2 = this;
                    authenticationForm.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCashWithdraw control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnCashWithdraw_Click(object sender, EventArgs e)
        {
            SqlCommand cmd_Check_Register_Status = new SqlCommand("Check_Register_Status", parentForm.conn);
            cmd_Check_Register_Status.CommandType = CommandType.StoredProcedure;
            cmd_Check_Register_Status.Parameters.Clear();
            cmd_Check_Register_Status.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = parentForm.cashRegisterNum;
            cmd_Check_Register_Status.Parameters.Add("@TransactionStatus", SqlDbType.NVarChar).Value = "END";
            cmd_Check_Register_Status.Parameters.Add("@RegDate", SqlDbType.NVarChar).Value = DateTime.Today.ToString("d");
            SqlParameter Output_Param = cmd_Check_Register_Status.Parameters.Add("@Output", SqlDbType.NVarChar, 20);
            Output_Param.Direction = ParameterDirection.Output;

            parentForm.conn.Open();
            cmd_Check_Register_Status.ExecuteNonQuery();
            parentForm.conn.Close();

            if (cmd_Check_Register_Status.Parameters["@Output"].Value != DBNull.Value)
            {
                MyMessageBox.ShowBox("REGISTER IS ALREADEY CLOSED TODAY", "ERROR");
                return;
            }
            else
            {
                if (auth == true)
                {
                    CashWithdraw cashWithdrawForm = new CashWithdraw(empID);
                    cashWithdrawForm.parentForm = this.parentForm;
                    cashWithdrawForm.ShowDialog();
                }
                else
                {
                    Authentication authenticationForm = new Authentication(10);
                    authenticationForm.parentForm1 = this.parentForm;
                    authenticationForm.parentForm2 = this;
                    authenticationForm.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnReturnByReceipt control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnReturnByReceipt_Click(object sender, EventArgs e)
        {
            if (auth == true)
            {
                //Return returnForm = new Return(parentForm.conn, 0);
                //returnForm.parentForm = this.parentForm;
                //returnForm.ShowDialog();

                parentForm.returnForm = new Return(parentForm.conn, 0, mgrID);
                parentForm.returnForm.parentForm = this.parentForm;
                parentForm.returnForm.ShowDialog();
            }
            else
            {
                Authentication authenticationForm = new Authentication(1);
                authenticationForm.parentForm1 = this.parentForm;
                authenticationForm.parentForm2 = this;
                authenticationForm.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnReturnByItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnReturnByItem_Click(object sender, EventArgs e)
        {
            if (auth == true)
            {
                //Return returnForm = new Return(parentForm.conn, 1);
                //returnForm.parentForm = this.parentForm;
                //returnForm.ShowDialog();

                parentForm.returnForm = new Return(parentForm.conn, 1, mgrID);
                parentForm.returnForm.parentForm = this.parentForm;
                parentForm.returnForm.ShowDialog();
            }
            else
            {
                Authentication authenticationForm = new Authentication(2);
                authenticationForm.parentForm1 = this.parentForm;
                authenticationForm.parentForm2 = this;
                authenticationForm.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnLineNoTax control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnLineNoTax_Click(object sender, EventArgs e)
        {
            if (parentForm.dataGridView1.RowCount == 0)
            {
                MyMessageBox.ShowBox("NO ITEM", "ERROR");
                //MessageBox.Show("No Item", "Error");
                return;
            }

            if (auth == true)
            {
                /*if (Convert.ToDouble(parentForm.dataGridView1.SelectedCells[6].Value) != 0)
                {
                    if (Convert.ToDouble(parentForm.dataGridView1.SelectedCells[4].Value) == 0)
                    {
                        qty = Convert.ToInt16(parentForm.dataGridView1.SelectedCells[2].Value);
                        unitPrice = Convert.ToDouble(parentForm.dataGridView1.SelectedCells[3].Value);
                        price = qty * unitPrice;
                        parentForm.dataGridView1.SelectedCells[5].Value = Math.Round(price, 2);
                        parentForm.dataGridView1.SelectedCells[6].Value = price * 0;

                        double subTotal = 0;
                        double tax = 0;
                        for (int i = 0; i < parentForm.dataGridView1.RowCount; i++)
                        {
                            subTotal = subTotal + Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[5].Value);
                            tax = tax + Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[6].Value);
                        }
                        //double tax = subTotal * parentForm.storeTaxRate;
                        double grandTotal = subTotal + tax;
                        parentForm.lblSubTotal.Text = string.Format("{0:$0.00}", (Math.Round(subTotal, 2)));
                        parentForm.lblTax.Text = string.Format("{0:$0.00}", (Math.Round(tax, 2)));
                        parentForm.lblGrandTotal.Text = string.Format("{0:$0.00}", grandTotal);

                        discountPrice = 0;
                        price = 0;

                        parentForm.Enabled = true;
                        this.Close();
                        parentForm.richTxtUpc.Focus();
                        parentForm.richTxtUpc.Select();
                    }
                    else
                    {
                        qty = Convert.ToInt16(parentForm.dataGridView1.SelectedCells[2].Value);
                        discountPrice = Convert.ToDouble(parentForm.dataGridView1.SelectedCells[4].Value);
                        price = qty * discountPrice;
                        parentForm.dataGridView1.SelectedCells[4].Value = discountPrice;
                        parentForm.dataGridView1.SelectedCells[5].Value = Math.Round(price, 2);
                        parentForm.dataGridView1.SelectedCells[6].Value = price * 0;

                        double subTotal = 0;
                        double tax = 0;
                        for (int i = 0; i < parentForm.dataGridView1.RowCount; i++)
                        {
                            subTotal = subTotal + Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[5].Value);
                            tax = tax + Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[6].Value);
                        }
                        //double tax = subTotal * parentForm.storeTaxRate;
                        double grandTotal = subTotal + tax;
                        parentForm.lblSubTotal.Text = string.Format("{0:$0.00}", (Math.Round(subTotal, 2)));
                        parentForm.lblTax.Text = string.Format("{0:$0.00}", (Math.Round(tax, 2)));
                        parentForm.lblGrandTotal.Text = string.Format("{0:$0.00}", grandTotal);

                        discountPrice = 0;
                        price = 0;

                        parentForm.Enabled = true;
                        this.Close();
                        parentForm.richTxtUpc.Focus();
                        parentForm.richTxtUpc.Select();
                    }
                }
                else
                {
                    MyMessageBox.ShowBox("ALREADY NO TAX ITEM", "ERROR");
                    //MessageBox.Show("It is already no tax item", "Error");
                    return;
                }*/


                parentForm.dataGridView1.SelectedCells[11].Value = false;

                parentForm.Calculation();

                parentForm.Enabled = true;
                this.Close();
                parentForm.richTxtUpc.Focus();
                parentForm.richTxtUpc.Select();
            }
            else
            {
                Authentication authenticationForm = new Authentication(13);
                authenticationForm.parentForm1 = this.parentForm;
                authenticationForm.parentForm2 = this;
                authenticationForm.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnAllNoTax control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnAllNoTax_Click(object sender, EventArgs e)
        {
            if (parentForm.dataGridView1.RowCount == 0)
            {
                MyMessageBox.ShowBox("NO ITEM", "ERROR");
                //MessageBox.Show("No Item", "Error");
                return;
            }

            if (auth == true)
            {
                /*rowCount = parentForm.dataGridView1.RowCount;

                for (int i = 0; i < rowCount; i++)
                {
                    parentForm.dataGridView1.Rows[i].Cells[6].Value = 0;
                }

                double subTotal = 0;
                double tax = 0;
                for (int i = 0; i < parentForm.dataGridView1.RowCount; i++)
                {
                    subTotal = subTotal + Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[5].Value);
                    tax = tax + Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[6].Value);
                }
                //double tax = subTotal * parentForm.storeTaxRate;
                double grandTotal = subTotal + tax;
                parentForm.lblSubTotal.Text = string.Format("{0:$0.00}", (Math.Round(subTotal, 2)));
                parentForm.lblTax.Text = string.Format("{0:$0.00}", (Math.Round(tax, 2)));
                parentForm.lblGrandTotal.Text = string.Format("{0:$0.00}", grandTotal);*/

                for (int i = 0; i < parentForm.dataGridView1.RowCount; i++)
                {
                    parentForm.dataGridView1.Rows[i].Cells[11].Value = false;
                }

                parentForm.Calculation();

                parentForm.Enabled = true;
                this.Close();
                parentForm.richTxtUpc.Focus();
                parentForm.richTxtUpc.Select();
            }
            else
            {
                Authentication authenticationForm = new Authentication(14);
                authenticationForm.parentForm1 = this.parentForm;
                authenticationForm.parentForm2 = this;
                authenticationForm.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnDiscount control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnDiscount_Click(object sender, EventArgs e)
        {
            if (parentForm.dataGridView1.RowCount > 0)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    if (Convert.ToString(parentForm.dataGridView1.Rows[i].Cells[7].Value) == parentForm.pointRedeemBarcode)
                    {
                        MyMessageBox.ShowBox("POINTS REDEEMED FOUND \n" + "CAN NOT DISCOUNT", "ERROR");
                        return;
                    }
                    else if(Convert.ToString(parentForm.dataGridView1.Rows[i].Cells[7].Value) == parentForm.couponBarcode)
                    {
                        MyMessageBox.ShowBox("COUPON FOUND \n" + "CAN NOT DISCOUNT", "ERROR");
                        return;
                    }
                }
                
                selectedRowIndex = parentForm.dataGridView1.SelectedRows[0].Index;

                if (Convert.ToDouble(parentForm.dataGridView1.Rows[selectedRowIndex].Cells[4].Value) == 0 & Convert.ToDouble(parentForm.dataGridView1.Rows[selectedRowIndex].Cells[3].Value) > 0)
                {
                    if (auth == true)
                    {
                        basicPrice = parentForm.dataGridView1.Rows[selectedRowIndex].Cells[3].Value.ToString();
                        Discount discountForm = new Discount(selectedRowIndex, basicPrice, 0);
                        discountForm.parentForm = this.parentForm;
                        //discountForm.Show();
                        discountForm.ShowDialog();
                        selectedRowIndex = 0;
                        basicPrice = string.Empty;

                        this.Close();
                    }
                    else
                    {
                        Authentication authenticationForm = new Authentication(15);
                        authenticationForm.parentForm1 = this.parentForm;
                        authenticationForm.parentForm2 = this;
                        authenticationForm.ShowDialog();
                    }
                }
                else
                {
                    MyMessageBox.ShowBox("DISCOUNTED ITEM OR NEGATIVE PRICE ITEM", "ERROR");
                    //MessageBox.Show("Discounted item", "Error");
                    return;
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
                //isFinish = true;
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
                //isFinish = true;
                cancelErr = true;
            }

            return (apiAlias.SUCCESS);
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
        /// Handles the Click event of the btnReprintReceipt control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnReprintReceipt_Click(object sender, EventArgs e)
        {
            if (auth == true)
            {
                ReprintReceipt reprintReceiptForm = new ReprintReceipt();
                reprintReceiptForm.parentForm = this.parentForm;
                reprintReceiptForm.ShowDialog();
            }
            else
            {
                Authentication authenticationForm = new Authentication(25);
                authenticationForm.parentForm1 = this.parentForm;
                authenticationForm.parentForm2 = this;
                authenticationForm.ShowDialog();
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
        /// Handles the Click event of the btnBasicSetup control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnBasicSetup_Click(object sender, EventArgs e)
        {
            if (auth == true)
            {
                BasicSetup basicSetupForm = new BasicSetup();
                basicSetupForm.parentForm = this.parentForm;
                basicSetupForm.ShowDialog();
            }
            else
            {
                Authentication authenticationForm = new Authentication(12);
                authenticationForm.parentForm1 = this.parentForm;
                authenticationForm.parentForm2 = this;
                authenticationForm.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnStartRegister control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnStartRegister_Click(object sender, EventArgs e)
        {
            SqlCommand cmd_Check_Register_Status = new SqlCommand("Check_Register_Status", parentForm.conn);
            cmd_Check_Register_Status.CommandType = CommandType.StoredProcedure;
            cmd_Check_Register_Status.Parameters.Clear();
            cmd_Check_Register_Status.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = parentForm.cashRegisterNum;
            cmd_Check_Register_Status.Parameters.Add("@TransactionStatus", SqlDbType.NVarChar).Value = "START";
            cmd_Check_Register_Status.Parameters.Add("@RegDate", SqlDbType.NVarChar).Value = DateTime.Today.ToString("d");
            SqlParameter Output_Param = cmd_Check_Register_Status.Parameters.Add("@Output", SqlDbType.NVarChar, 20);
            Output_Param.Direction = ParameterDirection.Output;

            parentForm.conn.Open();
            cmd_Check_Register_Status.ExecuteNonQuery();
            parentForm.conn.Close();

            if (cmd_Check_Register_Status.Parameters["@Output"].Value != DBNull.Value)
            {
                MyMessageBox.ShowBox("THIS REGISTER IS ALREADY STARTED TODAY", "ERROR");
                return;
            }
            else
            {
                if (auth == true)
                {
                    StartRegister startRegisterForm = new StartRegister(empID);
                    startRegisterForm.parentForm = this.parentForm;
                    startRegisterForm.ShowDialog();
                }
                else
                {
                    Authentication authenticationForm = new Authentication(8);
                    authenticationForm.parentForm1 = this.parentForm;
                    authenticationForm.parentForm2 = this;
                    authenticationForm.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSpecialDiscount control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnSpecialDiscount_Click(object sender, EventArgs e)
        {
            if (parentForm.dataGridView1.RowCount > 0)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    if (Convert.ToString(parentForm.dataGridView1.Rows[i].Cells[2].Value) == "POINTS REDEEMED" | Convert.ToInt16(parentForm.dataGridView1.Rows[i].Cells[8].Value) == 10)
                    {
                        MyMessageBox.ShowBox("POINTS REDEEMED FOUND \n" + "CAN NOT DISCOUNT", "ERROR");
                        return;
                    }
                }

                selectedRowIndex = parentForm.dataGridView1.SelectedRows[0].Index;

                if (Convert.ToDouble(parentForm.dataGridView1.Rows[selectedRowIndex].Cells[4].Value) == 0)
                {
                    MyMessageBox.ShowBox("USE REGULAR DISCOUNT FUNCTION", "ERROR");
                    return;
                }
                else
                {
                    if (auth == true)
                    {
                        sDiscountPrice = parentForm.dataGridView1.Rows[selectedRowIndex].Cells[4].Value.ToString();
                        SpecialDiscount specialDiscountForm = new SpecialDiscount(selectedRowIndex, sDiscountPrice);
                        specialDiscountForm.parentForm = this.parentForm;
                        specialDiscountForm.ShowDialog();
                        selectedRowIndex = 0;
                        sDiscountPrice = string.Empty;

                        this.Close();
                    }
                    else
                    {
                        Authentication authenticationForm = new Authentication(3);
                        authenticationForm.parentForm1 = this.parentForm;
                        authenticationForm.parentForm2 = this;
                        authenticationForm.ShowDialog();
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
        /// Handles the Click event of the btnReprintStoreCredit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnReprintStoreCredit_Click(object sender, EventArgs e)
        {
            if (auth == true)
            {
                ReprintStoreCredit reprintStoreCreditForm = new ReprintStoreCredit();
                reprintStoreCreditForm.parentForm = this.parentForm;
                reprintStoreCreditForm.ShowDialog();
            }
            else
            {
                Authentication authenticationForm = new Authentication(26);
                authenticationForm.parentForm1 = this.parentForm;
                authenticationForm.parentForm2 = this;
                authenticationForm.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCouponGenerate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCouponGenerate_Click(object sender, EventArgs e)
        {
            Authentication authenticationForm = new Authentication(19);
            authenticationForm.parentForm1 = this.parentForm;
            authenticationForm.parentForm2 = this;
            authenticationForm.ShowDialog();
        }

        /// <summary>
        /// Handles the Click event of the btnReprintClosingRegister control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnReprintClosingRegister_Click(object sender, EventArgs e)
        {
            ReprintRegisterTransaction reprintRegisterTransactionForm = new ReprintRegisterTransaction();
            reprintRegisterTransactionForm.parentForm = this.parentForm;
            reprintRegisterTransactionForm.ShowDialog();
        }

        /// <summary>
        /// Handles the Click event of the btnAbout control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutRegister aboutRegisterForm = new AboutRegister();
            aboutRegisterForm.parentForm = this.parentForm.parentForm;
            aboutRegisterForm.ShowDialog();
        }

        /// <summary>
        /// Handles the Click event of the btnCloverSettlement control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnCloverSettlement_Click(object sender, EventArgs e)
        {
            if (auth == true)
            {
                DialogResult MyDialogResult;
                MyDialogResult = MessageBox.Show(this, "DO YOU WANT TO PROCEED WITH CREDIT CARD TRANSACTION SETTLEMENT?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (MyDialogResult == DialogResult.Yes)
                {
                    if (mgrID != null)
                    {
                        parentForm.BatchUserID = mgrID;
                    }
                    else
                    {
                        MyMessageBox.ShowBox("MANAGER ID IS EMPTY. PLEASE RESTART THE PROGRAM.", "ERROR");
                        return;
                    }

                    parentForm.Settlement();
                }
            }
            else
            {
                Authentication authenticationForm = new Authentication(23);
                authenticationForm.parentForm1 = this.parentForm;
                authenticationForm.parentForm2 = this;
                authenticationForm.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCloverReset control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCloverReset_Click(object sender, EventArgs e)
        {
            parentForm.cloverConnector.ResetDevice();
        }

        public void btnCoupon_Click(object sender, EventArgs e)
        {
            if(parentForm.dataGridView1.RowCount == 0)
            {
                MyMessageBox.ShowBox("NO ITEM", "ERROR");
                return;
            }
            else
            {
                if (parentForm.CouponAmt > 0)
                {
                    MyMessageBox.ShowBox("ONLY ONE COUPON ALLOWED FOR EACH TRANSACTION", "ERROR");
                }
                else
                {
                    if (parentForm.lblGrandTotal.Text.Substring(0, 1) == "-")
                    {
                        MyMessageBox.ShowBox("THE GRAND TOTAL AMOUNT IS NOT PAYABLE", "ERROR");
                        return;
                    }
                    else
                    {
                        if (auth == true)
                        {
                            CouponList couponListForm = new CouponList(mgrID);
                            couponListForm.parentForm = this.parentForm;
                            this.Close();
                            couponListForm.ShowDialog();
                        }
                        else
                        {
                            Authentication authenticationForm = new Authentication(27);
                            authenticationForm.parentForm1 = this.parentForm;
                            authenticationForm.parentForm2 = this;
                            authenticationForm.ShowDialog();
                        }
                    }
                }
            }
        }
    }
}