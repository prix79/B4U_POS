// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 04-25-2017
// ***********************************************************************
// <copyright file="ClosingRegister.cs" company="Beauty4u">
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
    /// Class ClosingRegister.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class ClosingRegister : Form
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
        /// The penny
        /// </summary>
        double penny = 0;
        /// <summary>
        /// The nickel
        /// </summary>
        double nickel = 0;
        /// <summary>
        /// The dime
        /// </summary>
        double dime = 0;
        /// <summary>
        /// The quarter
        /// </summary>
        double quarter = 0;
        /// <summary>
        /// The dollar
        /// </summary>
        double dollar = 0;
        /// <summary>
        /// The two dollar
        /// </summary>
        double twoDollar = 0;
        /// <summary>
        /// The five dollar
        /// </summary>
        double fiveDollar = 0;
        /// <summary>
        /// The ten dollar
        /// </summary>
        double tenDollar = 0;
        /// <summary>
        /// The twenty dollar
        /// </summary>
        double twentyDollar = 0;
        /// <summary>
        /// The fifty dollar
        /// </summary>
        double fiftyDollar = 0;
        /// <summary>
        /// The hundred dollar
        /// </summary>
        double hundredDollar = 0;
        /// <summary>
        /// The cash sale
        /// </summary>
        double cashSale = 0;
        /// <summary>
        /// The cash drawer
        /// </summary>
        double cashDrawer = 0;
        /// <summary>
        /// The difference
        /// </summary>
        double difference = 0;
        //double todayCashSale = 0;
        /// <summary>
        /// The withdrawn
        /// </summary>
        double withdrawn = 0;
        /// <summary>
        /// The withdraw
        /// </summary>
        double withdraw = 0;
        /// <summary>
        /// The start cash
        /// </summary>
        double startCash = 0;
        /// <summary>
        /// The next day start amount
        /// </summary>
        double nextDayStartAmount = 0;

        /// <summary>
        /// The end date
        /// </summary>
        string endDate;
        /// <summary>
        /// The end time
        /// </summary>
        string endTime;

        /// <summary>
        /// The start date
        /// </summary>
        string startDate;
        /// <summary>
        /// The start time
        /// </summary>
        string startTime;

        /// <summary>
        /// The manager identifier
        /// </summary>
        string managerID;
        /// <summary>
        /// The manager PSW
        /// </summary>
        string managerPsw;

        /// <summary>
        /// The transaction identifier
        /// </summary>
        Int64 transactionID;

        //private const string PRINTER_NAME = "EPSON TM-T88III Receipt";
        /// <summary>
        /// The pd print1
        /// </summary>
        PrintDocument pdPrint1;
        /// <summary>
        /// The pd print2
        /// </summary>
        PrintDocument pdPrint2;
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
        /// Initializes a new instance of the <see cref="ClosingRegister"/> class.
        /// </summary>
        /// <param name="empID">The emp identifier.</param>
        public ClosingRegister(string empID)
        {
            InitializeComponent();
            lblCashierID.Text = empID;
        }

        /// <summary>
        /// Handles the Load event of the ClosingRegister control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ClosingRegister_Load(object sender, EventArgs e)
        {
            //string todayDate = string.Format("{0:d}", DateTime.Today);
            string todayDate = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            lblDate.Text = todayDate;

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

            SqlCommand cmd_CashSale = new SqlCommand("Get_Today_CashSale", parentForm.conn);
            cmd_CashSale.CommandType = CommandType.StoredProcedure;
            cmd_CashSale.Parameters.Add("@SellDate", SqlDbType.NVarChar).Value = todayDate;
            cmd_CashSale.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = parentForm.cashRegisterNum;
            SqlParameter CashSale_Param = cmd_CashSale.Parameters.Add("@CashSale", SqlDbType.Money);
            CashSale_Param.Direction = ParameterDirection.Output;

            parentForm.conn.Open();
            cmd_CashSale.ExecuteNonQuery();
            parentForm.conn.Close();

            if (cmd_CashSale.Parameters["@CashSale"].Value != DBNull.Value)
            {
                cashSale = Convert.ToDouble(cmd_CashSale.Parameters["@CashSale"].Value);
            }
            else
            {
                cashSale = 0;
            }

            SqlCommand cmd_Withdrawn = new SqlCommand("Get_Today_Withdrawn_Amount", parentForm.conn);
            cmd_Withdrawn.CommandType = CommandType.StoredProcedure;
            cmd_Withdrawn.Parameters.Add("@RegDate", SqlDbType.NVarChar).Value = todayDate;
            cmd_Withdrawn.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = parentForm.cashRegisterNum;
            SqlParameter Withdrawn_Param = cmd_Withdrawn.Parameters.Add("@Withdrawn", SqlDbType.Money);
            Withdrawn_Param.Direction = ParameterDirection.Output;

            parentForm.conn.Open();
            cmd_Withdrawn.ExecuteNonQuery();
            parentForm.conn.Close();

            if (cmd_Withdrawn.Parameters["@Withdrawn"].Value != DBNull.Value)
            {
                withdrawn = Convert.ToDouble(cmd_Withdrawn.Parameters["@Withdrawn"].Value);
            }
            else
            {
                withdrawn = 0;
            }

            SqlCommand cmd_StartCash = new SqlCommand("Get_Today_StartCash", parentForm.conn);
            cmd_StartCash.CommandType = CommandType.StoredProcedure;
            cmd_StartCash.Parameters.Add("@RegDate", SqlDbType.NVarChar).Value = todayDate;
            cmd_StartCash.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = parentForm.cashRegisterNum;
            SqlParameter StartCash_Param = cmd_StartCash.Parameters.Add("@StartCash", SqlDbType.Money);
            StartCash_Param.Direction = ParameterDirection.Output;

            parentForm.conn.Open();
            cmd_StartCash.ExecuteNonQuery();
            parentForm.conn.Close();

            if (cmd_StartCash.Parameters["@StartCash"].Value != DBNull.Value)
            {
                startCash = Convert.ToDouble(cmd_StartCash.Parameters["@StartCash"].Value);
            }
            else
            {
                startCash = 0;
            }

            txt100Dollar.SelectAll();
            lblStartCash.Text = string.Format("{0:$0.00}", startCash);
            lblCashSales.Text = string.Format("{0:$0.00}", cashSale);
            lblWithdrawn.Text = string.Format("{0:$0.00}", withdrawn);
            lblCashDrawer.Text = "$0.00";

            Int32 retVal;
            String errMsg;
            apiAlias.StatusMonitoring pMonitorCB = new apiAlias.StatusMonitoring(StatusMonitoring);

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
                        // Display the status/error message.
                        DisplayStatusMessage();

                        // If an error occurred, restore the recoverable error.
                        if (cancelErr)
                            retVal = apiAlias.BiCancelError(mpHandle);
                        else
                            // Call the function to open cash drawer.
                            OpenDrawer(parentForm.PRINTER_NAME);
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
        /// Handles the TextChanged event of the txtPenny control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtPenny_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtPenny.Text.Trim().ToString(), out penny))
            {
                if (penny >= 0)
                {
                    lblPenny.Text = string.Format("{0:$0.00}", penny * 0.01);
                    nickel = Convert.ToDouble(txtNickel.Text);
                    dime = Convert.ToDouble(txtDime.Text);
                    quarter = Convert.ToDouble(txtQuarter.Text);
                    dollar = Convert.ToDouble(txt1Dollar.Text);
                    twoDollar = Convert.ToDouble(txt2Dollar.Text);
                    fiveDollar = Convert.ToDouble(txt5Dollar.Text);
                    tenDollar = Convert.ToDouble(txt10Dollar.Text);
                    twentyDollar = Convert.ToDouble(txt20Dollar.Text);
                    fiftyDollar = Convert.ToDouble(txt50Dollar.Text);
                    hundredDollar = Convert.ToDouble(txt100Dollar.Text);

                    cashDrawer = hundredDollar * 100 + fiftyDollar * 50 + twentyDollar * 20 + tenDollar * 10 + fiveDollar * 5 + twoDollar * 2 + dollar + quarter * 0.25 + dime * 0.1 + nickel * 0.05 + penny * 0.01;
                    lblCashDrawer.Text = string.Format("{0:$0.00}", cashDrawer);
                    //cashSale = Convert.ToDouble(lblCashSales.Text.Substring(1));
                    difference = cashDrawer + withdrawn - startCash - cashSale;

                    if (difference < 0)
                    {
                        lblDifference.BackColor = Color.Red;
                    }
                    else
                    {
                        lblDifference.BackColor = Color.Green;
                    }

                    lblDifference.Text = string.Format("{0:$0.00}", difference);
                    //cashSale = 0;
                    //cashDrawer = 0;
                    //difference = 0;
                }
                else
                {
                    MyMessageBox.ShowBox("INPUT POSITIVE NUMBER", "ERROR");
                    //MessageBox.Show("Input positive number");
                    txtPenny.SelectAll();
                }
            }
            else
            {
                txtPenny.Text = "0";
                txtPenny.SelectAll();
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the txtNickel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtNickel_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtNickel.Text.Trim().ToString(), out nickel))
            {
                if (nickel >= 0)
                {
                    lblNickel.Text = string.Format("{0:$0.00}", nickel * 0.05);
                    penny = Convert.ToDouble(txtPenny.Text);
                    dime = Convert.ToDouble(txtDime.Text);
                    quarter = Convert.ToDouble(txtQuarter.Text);
                    dollar = Convert.ToDouble(txt1Dollar.Text);
                    twoDollar = Convert.ToDouble(txt2Dollar.Text);
                    fiveDollar = Convert.ToDouble(txt5Dollar.Text);
                    tenDollar = Convert.ToDouble(txt10Dollar.Text);
                    twentyDollar = Convert.ToDouble(txt20Dollar.Text);
                    fiftyDollar = Convert.ToDouble(txt50Dollar.Text);
                    hundredDollar = Convert.ToDouble(txt100Dollar.Text);

                    cashDrawer = hundredDollar * 100 + fiftyDollar * 50 + twentyDollar * 20 + tenDollar * 10 + fiveDollar * 5 + twoDollar * 2 + dollar + quarter * 0.25 + dime * 0.1 + nickel * 0.05 + penny * 0.01;
                    lblCashDrawer.Text = string.Format("{0:$0.00}", cashDrawer);
                    //cashSale = Convert.ToDouble(lblCashSales.Text.Substring(1));
                    difference = cashDrawer + withdrawn - startCash - cashSale;

                    if (difference < 0)
                    {
                        lblDifference.BackColor = Color.Red;
                    }
                    else
                    {
                        lblDifference.BackColor = Color.Green;
                    }

                    lblDifference.Text = string.Format("{0:$0.00}", difference);
                }
                else
                {
                    MyMessageBox.ShowBox("INPUT POSITIVE NUMBER", "ERROR");
                    //MessageBox.Show("Input positive number");
                    txtNickel.SelectAll();
                }
            }
            else
            {
                txtNickel.Text = "0";
                txtNickel.SelectAll();
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the txtDime control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtDime_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtDime.Text.Trim().ToString(), out dime))
            {
                if (dime >= 0)
                {
                    lblDime.Text = string.Format("{0:$0.00}", dime * 0.1);
                    penny = Convert.ToDouble(txtPenny.Text);
                    nickel = Convert.ToDouble(txtNickel.Text);
                    quarter = Convert.ToDouble(txtQuarter.Text);
                    dollar = Convert.ToDouble(txt1Dollar.Text);
                    twoDollar = Convert.ToDouble(txt2Dollar.Text);
                    fiveDollar = Convert.ToDouble(txt5Dollar.Text);
                    tenDollar = Convert.ToDouble(txt10Dollar.Text);
                    twentyDollar = Convert.ToDouble(txt20Dollar.Text);
                    fiftyDollar = Convert.ToDouble(txt50Dollar.Text);
                    hundredDollar = Convert.ToDouble(txt100Dollar.Text);

                    cashDrawer = hundredDollar * 100 + fiftyDollar * 50 + twentyDollar * 20 + tenDollar * 10 + fiveDollar * 5 + twoDollar * 2 + dollar + quarter * 0.25 + dime * 0.1 + nickel * 0.05 + penny * 0.01;
                    lblCashDrawer.Text = string.Format("{0:$0.00}", cashDrawer);
                    //cashSale = Convert.ToDouble(lblCashSales.Text.Substring(1));
                    difference = cashDrawer + withdrawn - startCash - cashSale;

                    if (difference < 0)
                    {
                        lblDifference.BackColor = Color.Red;
                    }
                    else
                    {
                        lblDifference.BackColor = Color.Green;
                    }

                    lblDifference.Text = string.Format("{0:$0.00}", difference);
                }
                else
                {
                    MyMessageBox.ShowBox("INPUT POSITIVE NUMBER", "ERROR");
                    //MessageBox.Show("Input positive number");
                    txtDime.SelectAll();
                }
            }
            else
            {
                txtDime.Text = "0";
                txtDime.SelectAll();
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the txtQuarter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtQuarter_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtQuarter.Text.Trim().ToString(), out quarter))
            {
                if (quarter >= 0)
                {
                    lblQuarter.Text = string.Format("{0:$0.00}", quarter * 0.25);
                    penny = Convert.ToDouble(txtPenny.Text);
                    nickel = Convert.ToDouble(txtNickel.Text);
                    dime = Convert.ToDouble(txtDime.Text);
                    dollar = Convert.ToDouble(txt1Dollar.Text);
                    twoDollar = Convert.ToDouble(txt2Dollar.Text);
                    fiveDollar = Convert.ToDouble(txt5Dollar.Text);
                    tenDollar = Convert.ToDouble(txt10Dollar.Text);
                    twentyDollar = Convert.ToDouble(txt20Dollar.Text);
                    fiftyDollar = Convert.ToDouble(txt50Dollar.Text);
                    hundredDollar = Convert.ToDouble(txt100Dollar.Text);

                    cashDrawer = hundredDollar * 100 + fiftyDollar * 50 + twentyDollar * 20 + tenDollar * 10 + fiveDollar * 5 + twoDollar * 2 + dollar + quarter * 0.25 + dime * 0.1 + nickel * 0.05 + penny * 0.01;
                    lblCashDrawer.Text = string.Format("{0:$0.00}", cashDrawer);
                    //cashSale = Convert.ToDouble(lblCashSales.Text.Substring(1));
                    difference = cashDrawer + withdrawn - startCash - cashSale;

                    if (difference < 0)
                    {
                        lblDifference.BackColor = Color.Red;
                    }
                    else
                    {
                        lblDifference.BackColor = Color.Green;
                    }

                    lblDifference.Text = string.Format("{0:$0.00}", difference);
                }
                else
                {
                    MyMessageBox.ShowBox("INPUT POSITIVE NUMBER", "ERROR");
                    //MessageBox.Show("Input positive number");
                    txtQuarter.SelectAll();
                }
            }
            else
            {
                txtQuarter.Text = "0";
                txtQuarter.SelectAll();
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the txt1Dollar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txt1Dollar_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txt1Dollar.Text.Trim().ToString(), out dollar))
            {
                if (dollar >= 0)
                {
                    lbl1Dollar.Text = string.Format("{0:$0.00}", dollar);
                    penny = Convert.ToDouble(txtPenny.Text);
                    nickel = Convert.ToDouble(txtNickel.Text);
                    dime = Convert.ToDouble(txtDime.Text);
                    quarter = Convert.ToDouble(txtQuarter.Text);
                    twoDollar = Convert.ToDouble(txt2Dollar.Text);
                    fiveDollar = Convert.ToDouble(txt5Dollar.Text);
                    tenDollar = Convert.ToDouble(txt10Dollar.Text);
                    twentyDollar = Convert.ToDouble(txt20Dollar.Text);
                    fiftyDollar = Convert.ToDouble(txt50Dollar.Text);
                    hundredDollar = Convert.ToDouble(txt100Dollar.Text);

                    cashDrawer = hundredDollar * 100 + fiftyDollar * 50 + twentyDollar * 20 + tenDollar * 10 + fiveDollar * 5 + twoDollar * 2 + dollar + quarter * 0.25 + dime * 0.1 + nickel * 0.05 + penny * 0.01;
                    lblCashDrawer.Text = string.Format("{0:$0.00}", cashDrawer);
                    //cashSale = Convert.ToDouble(lblCashSales.Text.Substring(1));
                    difference = cashDrawer + withdrawn - startCash - cashSale;

                    if (difference < 0)
                    {
                        lblDifference.BackColor = Color.Red;
                    }
                    else
                    {
                        lblDifference.BackColor = Color.Green;
                    }

                    lblDifference.Text = string.Format("{0:$0.00}", difference);
                }
                else
                {
                    MyMessageBox.ShowBox("INPUT POSITIVE NUMBER", "ERROR");
                    //MessageBox.Show("Input positive number");
                    txt1Dollar.SelectAll();
                }
            }
            else
            {
                txt1Dollar.Text = "0";
                txt1Dollar.SelectAll();
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the txt2Dollar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txt2Dollar_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txt2Dollar.Text.Trim().ToString(), out twoDollar))
            {
                if (twoDollar >= 0)
                {
                    lbl2Dollar.Text = string.Format("{0:$0.00}", twoDollar * 2);
                    penny = Convert.ToDouble(txtPenny.Text);
                    nickel = Convert.ToDouble(txtNickel.Text);
                    dime = Convert.ToDouble(txtDime.Text);
                    quarter = Convert.ToDouble(txtQuarter.Text);
                    dollar = Convert.ToDouble(txt1Dollar.Text);
                    fiveDollar = Convert.ToDouble(txt5Dollar.Text);
                    tenDollar = Convert.ToDouble(txt10Dollar.Text);
                    twentyDollar = Convert.ToDouble(txt20Dollar.Text);
                    fiftyDollar = Convert.ToDouble(txt50Dollar.Text);
                    hundredDollar = Convert.ToDouble(txt100Dollar.Text);

                    cashDrawer = hundredDollar * 100 + fiftyDollar * 50 + twentyDollar * 20 + tenDollar * 10 + fiveDollar * 5 + twoDollar * 2 + dollar + quarter * 0.25 + dime * 0.1 + nickel * 0.05 + penny * 0.01;
                    lblCashDrawer.Text = string.Format("{0:$0.00}", cashDrawer);
                    //cashSale = Convert.ToDouble(lblCashSales.Text.Substring(1));
                    difference = cashDrawer + withdrawn - startCash - cashSale;

                    if (difference < 0)
                    {
                        lblDifference.BackColor = Color.Red;
                    }
                    else
                    {
                        lblDifference.BackColor = Color.Green;
                    }

                    lblDifference.Text = string.Format("{0:$0.00}", difference);
                }
                else
                {
                    MyMessageBox.ShowBox("INPUT POSITIVE NUMBER", "ERROR");
                    //MessageBox.Show("Input positive number");
                    txt2Dollar.SelectAll();
                }
            }
            else
            {
                txt2Dollar.Text = "0";
                txt2Dollar.SelectAll();
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the txt5Dollar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txt5Dollar_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txt5Dollar.Text.Trim().ToString(), out fiveDollar))
            {
                if (fiveDollar >= 0)
                {
                    lbl5Dollar.Text = string.Format("{0:$0.00}", fiveDollar * 5);
                    penny = Convert.ToDouble(txtPenny.Text);
                    nickel = Convert.ToDouble(txtNickel.Text);
                    dime = Convert.ToDouble(txtDime.Text);
                    quarter = Convert.ToDouble(txtQuarter.Text);
                    dollar = Convert.ToDouble(txt1Dollar.Text);
                    twoDollar = Convert.ToDouble(txt2Dollar.Text);
                    tenDollar = Convert.ToDouble(txt10Dollar.Text);
                    twentyDollar = Convert.ToDouble(txt20Dollar.Text);
                    fiftyDollar = Convert.ToDouble(txt50Dollar.Text);
                    hundredDollar = Convert.ToDouble(txt100Dollar.Text);

                    cashDrawer = hundredDollar * 100 + fiftyDollar * 50 + twentyDollar * 20 + tenDollar * 10 + fiveDollar * 5 + twoDollar * 2 + dollar + quarter * 0.25 + dime * 0.1 + nickel * 0.05 + penny * 0.01;
                    lblCashDrawer.Text = string.Format("{0:$0.00}", cashDrawer);
                    //cashSale = Convert.ToDouble(lblCashSales.Text.Substring(1));
                    difference = cashDrawer + withdrawn - startCash - cashSale;

                    if (difference < 0)
                    {
                        lblDifference.BackColor = Color.Red;
                    }
                    else
                    {
                        lblDifference.BackColor = Color.Green;
                    }

                    lblDifference.Text = string.Format("{0:$0.00}", difference);
                }
                else
                {
                    MyMessageBox.ShowBox("INPUT POSITIVE NUMBER", "ERROR");
                    //MessageBox.Show("Input positive number");
                    txt5Dollar.SelectAll();
                }
            }
            else
            {
                txt5Dollar.Text = "0";
                txt5Dollar.SelectAll();
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the txt10Dollar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txt10Dollar_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txt10Dollar.Text.Trim().ToString(), out tenDollar))
            {
                if (tenDollar >= 0)
                {
                    lbl10Dollar.Text = string.Format("{0:$0.00}", tenDollar * 10);
                    penny = Convert.ToDouble(txtPenny.Text);
                    nickel = Convert.ToDouble(txtNickel.Text);
                    dime = Convert.ToDouble(txtDime.Text);
                    quarter = Convert.ToDouble(txtQuarter.Text);
                    dollar = Convert.ToDouble(txt1Dollar.Text);
                    twoDollar = Convert.ToDouble(txt2Dollar.Text);
                    fiveDollar = Convert.ToDouble(txt5Dollar.Text);
                    twentyDollar = Convert.ToDouble(txt20Dollar.Text);
                    fiftyDollar = Convert.ToDouble(txt50Dollar.Text);
                    hundredDollar = Convert.ToDouble(txt100Dollar.Text);

                    cashDrawer = hundredDollar * 100 + fiftyDollar * 50 + twentyDollar * 20 + tenDollar * 10 + fiveDollar * 5 + twoDollar * 2 + dollar + quarter * 0.25 + dime * 0.1 + nickel * 0.05 + penny * 0.01;
                    lblCashDrawer.Text = string.Format("{0:$0.00}", cashDrawer);
                    //cashSale = Convert.ToDouble(lblCashSales.Text.Substring(1));
                    difference = cashDrawer + withdrawn - startCash - cashSale;

                    if (difference < 0)
                    {
                        lblDifference.BackColor = Color.Red;
                    }
                    else
                    {
                        lblDifference.BackColor = Color.Green;
                    }

                    lblDifference.Text = string.Format("{0:$0.00}", difference);
                }
                else
                {
                    MyMessageBox.ShowBox("INPUT POSITIVE NUMBER", "ERROR");
                    //MessageBox.Show("Input positive number");
                    txt10Dollar.SelectAll();
                }
            }
            else
            {
                txt10Dollar.Text = "0";
                txt10Dollar.SelectAll();
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the txt20Dollar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txt20Dollar_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txt20Dollar.Text.Trim().ToString(), out twentyDollar))
            {
                if (twentyDollar >= 0)
                {
                    lbl20Dollar.Text = string.Format("{0:$0.00}", twentyDollar * 20);
                    penny = Convert.ToDouble(txtPenny.Text);
                    nickel = Convert.ToDouble(txtNickel.Text);
                    dime = Convert.ToDouble(txtDime.Text);
                    quarter = Convert.ToDouble(txtQuarter.Text);
                    dollar = Convert.ToDouble(txt1Dollar.Text);
                    twoDollar = Convert.ToDouble(txt2Dollar.Text);
                    fiveDollar = Convert.ToDouble(txt5Dollar.Text);
                    tenDollar = Convert.ToDouble(txt10Dollar.Text);
                    fiftyDollar = Convert.ToDouble(txt50Dollar.Text);
                    hundredDollar = Convert.ToDouble(txt100Dollar.Text);

                    cashDrawer = hundredDollar * 100 + fiftyDollar * 50 + twentyDollar * 20 + tenDollar * 10 + fiveDollar * 5 + twoDollar * 2 + dollar + quarter * 0.25 + dime * 0.1 + nickel * 0.05 + penny * 0.01;
                    lblCashDrawer.Text = string.Format("{0:$0.00}", cashDrawer);
                    //cashSale = Convert.ToDouble(lblCashSales.Text.Substring(1));
                    difference = cashDrawer + withdrawn - startCash - cashSale;

                    if (difference < 0)
                    {
                        lblDifference.BackColor = Color.Red;
                    }
                    else
                    {
                        lblDifference.BackColor = Color.Green;
                    }

                    lblDifference.Text = string.Format("{0:$0.00}", difference);
                }
                else
                {
                    MyMessageBox.ShowBox("INPUT POSITIVE NUMBER", "ERROR");
                    //MessageBox.Show("Input positive number");
                    txt20Dollar.SelectAll();
                }
            }
            else
            {
                txt20Dollar.Text = "0";
                txt20Dollar.SelectAll();
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the txt50Dollar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txt50Dollar_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txt50Dollar.Text.Trim().ToString(), out fiftyDollar))
            {
                if (fiftyDollar >= 0)
                {
                    lbl50Dollar.Text = string.Format("{0:$0.00}", fiftyDollar * 50);
                    penny = Convert.ToDouble(txtPenny.Text);
                    nickel = Convert.ToDouble(txtNickel.Text);
                    dime = Convert.ToDouble(txtDime.Text);
                    quarter = Convert.ToDouble(txtQuarter.Text);
                    dollar = Convert.ToDouble(txt1Dollar.Text);
                    twoDollar = Convert.ToDouble(txt2Dollar.Text);
                    fiveDollar = Convert.ToDouble(txt5Dollar.Text);
                    tenDollar = Convert.ToDouble(txt10Dollar.Text);
                    twentyDollar = Convert.ToDouble(txt20Dollar.Text);
                    hundredDollar = Convert.ToDouble(txt100Dollar.Text);

                    cashDrawer = hundredDollar * 100 + fiftyDollar * 50 + twentyDollar * 20 + tenDollar * 10 + fiveDollar * 5 + twoDollar * 2 + dollar + quarter * 0.25 + dime * 0.1 + nickel * 0.05 + penny * 0.01;
                    lblCashDrawer.Text = string.Format("{0:$0.00}", cashDrawer);
                    //cashSale = Convert.ToDouble(lblCashSales.Text.Substring(1));
                    difference = cashDrawer + withdrawn - startCash - cashSale;

                    if (difference < 0)
                    {
                        lblDifference.BackColor = Color.Red;
                    }
                    else
                    {
                        lblDifference.BackColor = Color.Green;
                    }

                    lblDifference.Text = string.Format("{0:$0.00}", difference);
                }
                else
                {
                    MyMessageBox.ShowBox("INPUT POSITIVE NUMBER", "ERROR");
                    //MessageBox.Show("Input positive number");
                    txt50Dollar.SelectAll();
                }
            }
            else
            {
                txt50Dollar.Text = "0";
                txt50Dollar.SelectAll();
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the txt100Dollar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txt100Dollar_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txt100Dollar.Text.Trim().ToString(), out hundredDollar))
            {
                if (hundredDollar >= 0)
                {
                    lbl100Dollar.Text = string.Format("{0:$0.00}", hundredDollar * 100);
                    penny = Convert.ToDouble(txtPenny.Text);
                    nickel = Convert.ToDouble(txtNickel.Text);
                    dime = Convert.ToDouble(txtDime.Text);
                    quarter = Convert.ToDouble(txtQuarter.Text);
                    dollar = Convert.ToDouble(txt1Dollar.Text);
                    twoDollar = Convert.ToDouble(txt2Dollar.Text);
                    fiveDollar = Convert.ToDouble(txt5Dollar.Text);
                    tenDollar = Convert.ToDouble(txt10Dollar.Text);
                    twentyDollar = Convert.ToDouble(txt20Dollar.Text);
                    fiftyDollar = Convert.ToDouble(txt50Dollar.Text);

                    cashDrawer = hundredDollar * 100 + fiftyDollar * 50 + twentyDollar * 20 + tenDollar * 10 + fiveDollar * 5 + twoDollar * 2 + dollar + quarter * 0.25 + dime * 0.1 + nickel * 0.05 + penny * 0.01;
                    lblCashDrawer.Text = string.Format("{0:$0.00}", cashDrawer);
                    //cashSale = Convert.ToDouble(lblCashSales.Text.Substring(1));
                    difference = cashDrawer + withdrawn - startCash - cashSale;

                    if (difference < 0)
                    {
                        lblDifference.BackColor = Color.Red;
                    }
                    else
                    {
                        lblDifference.BackColor = Color.Green;
                    }

                    lblDifference.Text = string.Format("{0:$0.00}", difference);
                }
                else
                {
                    MyMessageBox.ShowBox("INPUT POSITIVE NUMBER", "ERROR");
                    //MessageBox.Show("Input positive number");
                    txt100Dollar.SelectAll();
                }
            }
            else
            {
                txt100Dollar.Text = "0";
                txt100Dollar.SelectAll();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnClosing control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnClosing_Click(object sender, EventArgs e)
        {
            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "ARE YOU SURE WITH CLOSING REGISTER?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.No)
            {
                return;
            }

            //endDate = string.Format("{0:d}", DateTime.Now);
            endDate = string.Format("{0:MM/dd/yyyy}", DateTime.Now);
            endTime = string.Format("{0:T}", DateTime.Now);

            if (double.TryParse(richtxtWithdraw.Text, out withdraw))
            {
                if (txtManagerID.Text == "")
                {
                    MyMessageBox.ShowBox("INPUT MANAGER ID", "ERROR");
                    return;
                }

                if (txtPsw.Text == "")
                {
                    MyMessageBox.ShowBox("INPUT PASSWORD", "ERROR");
                    return;
                }

                managerID = txtManagerID.Text.ToString().ToUpper();
                managerPsw = txtPsw.Text.ToString().ToUpper();
                
                SqlCommand cmd_User = new SqlCommand("Get_User", parentForm.conn);

                cmd_User.CommandType = CommandType.StoredProcedure;
                cmd_User.Parameters.Add("@empLoginID", SqlDbType.NVarChar).Value = managerID;
                cmd_User.Parameters.Add("@empPassword", SqlDbType.NVarChar).Value = managerPsw;
                SqlParameter UserName_Param = cmd_User.Parameters.Add("@empFirstName", SqlDbType.NVarChar, 50);
                SqlParameter UserName_Param2 = cmd_User.Parameters.Add("@empLastName", SqlDbType.NVarChar, 50);
                UserName_Param.Direction = ParameterDirection.Output;
                UserName_Param2.Direction = ParameterDirection.Output;

                parentForm.conn.Open();
                cmd_User.ExecuteNonQuery();
                parentForm.conn.Close();

                if (cmd_User.Parameters["@empFirstName"].Value == DBNull.Value)
                {
                    MyMessageBox.ShowBox("INVALID ACCOUNT", "ERROR");
                    return;
                }

                SqlCommand cmd = new SqlCommand("Create_ClosingRegister", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = parentForm.cashRegisterNum;
                cmd.Parameters.Add("@TransactionStatus", SqlDbType.NVarChar).Value = "END";
                cmd.Parameters.Add("@RegEndAmount", SqlDbType.Money).Value = startCash + cashSale - withdrawn - withdraw;
                cmd.Parameters.Add("@RegCashSalesAmount", SqlDbType.Money).Value = cashSale;
                cmd.Parameters.Add("@RegCashRealAmount", SqlDbType.Money).Value = cashDrawer;
                cmd.Parameters.Add("@RegWithdrawAmount", SqlDbType.Money).Value = withdraw;
                cmd.Parameters.Add("@RegShortageAmount", SqlDbType.Money).Value = difference;
                cmd.Parameters.Add("@RegDate", SqlDbType.NVarChar).Value = endDate;
                cmd.Parameters.Add("@RegTime", SqlDbType.NVarChar).Value = endTime;
                cmd.Parameters.Add("@RegCashierID", SqlDbType.NVarChar).Value = lblCashierID.Text;
                cmd.Parameters.Add("@RegManagerID", SqlDbType.NVarChar).Value = txtManagerID.Text.Trim().ToString().ToUpper();

                parentForm.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm.conn.Close();
            }
            else
            {
                MyMessageBox.ShowBox("INVALID AMOUNT", "ERROR");
                return;
            }

            SqlCommand cmd_TransactionID = new SqlCommand("Get_TransactionID", parentForm.conn);
            cmd_TransactionID.CommandType = CommandType.StoredProcedure;
            cmd_TransactionID.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = parentForm.cashRegisterNum;
            cmd_TransactionID.Parameters.Add("@RegDate", SqlDbType.NVarChar).Value = endDate;
            cmd_TransactionID.Parameters.Add("@TransactionStatus", SqlDbType.NVarChar).Value = "END";
            SqlParameter TransactionID_Param = cmd_TransactionID.Parameters.Add("@TransactionID", SqlDbType.BigInt);
            TransactionID_Param.Direction = ParameterDirection.Output;
            parentForm.conn.Open();
            cmd_TransactionID.ExecuteNonQuery();
            parentForm.conn.Close();

            transactionID = Convert.ToInt64(cmd_TransactionID.Parameters["@TransactionID"].Value);

            if (DateTime.Today.DayOfWeek != DayOfWeek.Saturday)
            {
                startDate = string.Format("{0:MM/dd/yyyy}", DateTime.Today.AddDays(1));
                startTime = "10:00:00 AM";
                nextDayStartAmount = cashDrawer - withdraw;

                SqlCommand cmd2 = new SqlCommand("Create_StartRegister", parentForm.conn);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = parentForm.cashRegisterNum;
                cmd2.Parameters.Add("@TransactionStatus", SqlDbType.NVarChar).Value = "START";
                cmd2.Parameters.Add("@RegStartAmount", SqlDbType.Money).Value = nextDayStartAmount;
                cmd2.Parameters.Add("@RegDate", SqlDbType.NVarChar).Value = startDate;
                cmd2.Parameters.Add("@RegTime", SqlDbType.NVarChar).Value = startTime;
                cmd2.Parameters.Add("@RegCashierID", SqlDbType.NVarChar).Value = lblCashierID.Text;
                cmd2.Parameters.Add("@RegManagerID", SqlDbType.NVarChar).Value = txtManagerID.Text.Trim().ToString().ToUpper();

                parentForm.conn.Open();
                cmd2.ExecuteNonQuery();
                parentForm.conn.Close();

                lblEndCash.Text = string.Format("{0:$0.00}", nextDayStartAmount);
                MyMessageBox.ShowBox("SUCCESSFULLY CLOSED", "INFORMATION"); ;
                this.Close();
            }
            else
            {
                startDate = string.Format("{0:MM/dd/yyyy}", DateTime.Today.AddDays(1));
                startTime = "11:00:00 AM";
                nextDayStartAmount = cashDrawer - withdraw;

                SqlCommand cmd2 = new SqlCommand("Create_StartRegister", parentForm.conn);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = parentForm.cashRegisterNum;
                cmd2.Parameters.Add("@TransactionStatus", SqlDbType.NVarChar).Value = "START";
                cmd2.Parameters.Add("@RegStartAmount", SqlDbType.Money).Value = nextDayStartAmount;
                cmd2.Parameters.Add("@RegDate", SqlDbType.NVarChar).Value = startDate;
                cmd2.Parameters.Add("@RegTime", SqlDbType.NVarChar).Value = startTime;
                cmd2.Parameters.Add("@RegCashierID", SqlDbType.NVarChar).Value = lblCashierID.Text;
                cmd2.Parameters.Add("@RegManagerID", SqlDbType.NVarChar).Value = txtManagerID.Text.Trim().ToString();

                parentForm.conn.Open();
                cmd2.ExecuteNonQuery();
                parentForm.conn.Close();

                lblEndCash.Text = string.Format("{0:$0.00}", nextDayStartAmount);
                MyMessageBox.ShowBox("SUCCESSFULLY CLOSED", "INFORMATION");
                //MessageBox.Show("Successfully closed", "Info");
                this.Close();
            }

            Int32 retVal;
            String errMsg;
            apiAlias.StatusMonitoring pMonitorCB = new apiAlias.StatusMonitoring(StatusMonitoring);

            pdPrint1 = new PrintDocument();
            pdPrint1.PrintPage += new PrintPageEventHandler(pdPrint1_PrintPage);
            pdPrint1.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;

            pdPrint2 = new PrintDocument();
            pdPrint2.PrintPage += new PrintPageEventHandler(pdPrint2_PrintPage);
            pdPrint2.PrinterSettings.PrinterName = parentForm.PRINTER_NAME;

            try
            {
                // Open Printer Monitor of Status API.
                mpHandle = apiAlias.BiOpenMonPrinter(apiAlias.TYPE_PRINTER, pdPrint1.PrinterSettings.PrinterName);
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
                            pdPrint1.Print();
                            pdPrint2.Print();
                        }
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

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "ARE YOU SURE WITH CANCELING THE CLOSING REGISTER?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
            {
                this.Close();
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
            text.Add(Convert.ToString(endDate) + " " + Convert.ToString(endTime));
            text.Add("TRANSACTION ID");
            text.Add(":");
            text.Add(Convert.ToString(transactionID));
            text.Add("STORE CODE");
            text.Add(":");
            text.Add(parentForm.storeCode);
            text.Add("REGISTER NO");
            text.Add(":");
            text.Add(parentForm.cashRegisterNum);
            text.Add("CASHIER ID");
            text.Add(":");
            text.Add(lblCashierID.Text.ToUpper());
            text.Add("MANAGER ID");
            text.Add(":");
            text.Add(txtManagerID.Text.ToUpper());
            text.Add("----------------------------------------------------------------");
            text.Add("CASH START");
            text.Add(":");
            text.Add(string.Format("{0:$0.00}", startCash));
            text.Add("CASH SALES");
            text.Add(":");
            text.Add(string.Format("{0:$0.00}", cashSale));
            text.Add("CASH WITHDRAWN");
            text.Add(":");
            text.Add(string.Format("{0:$0.00}", withdrawn));
            text.Add("----------------------------------------------------------------");
            text.Add("   1 CENT    X");
            text.Add(string.Format("{0,5}", penny));
            text.Add(" =     $");
            text.Add(string.Format("{0:0.00}", penny * 0.01));
            text.Add("   5 CENT    X");
            text.Add(string.Format("{0,5}", nickel));
            text.Add(" =     $");
            text.Add(string.Format("{0:0.00}", nickel * 0.05));      
            text.Add(" 10 CENT    X");
            text.Add(string.Format("{0,5}", dime));
            text.Add(" =     $");
            text.Add(string.Format("{0:0.00}", dime * 0.1));
            text.Add(" 25 CENT    X");
            text.Add(string.Format("{0,5}", quarter));
            text.Add(" =     $");
            text.Add(string.Format("{0:0.00}", quarter * 0.25));
            text.Add("----------------------------------------------------------------");
            text.Add("    1 DOLLAR    X");
            text.Add(string.Format("{0,5}", dollar));
            text.Add(" =     $");
            text.Add(string.Format("{0:0.00}", dollar));
            text.Add("    2 DOLLAR    X");
            text.Add(string.Format("{0,5}", twoDollar));
            text.Add(" =     $");
            text.Add(string.Format("{0:0.00}", twoDollar * 2));
            text.Add("    5 DOLLAR    X");
            text.Add(string.Format("{0,5}", fiveDollar));
            text.Add(" =     $");
            text.Add(string.Format("{0:0.00}", fiveDollar * 5));
            text.Add("  10 DOLLAR    X");
            text.Add(string.Format("{0,5}", tenDollar));
            text.Add(" =     $");
            text.Add(string.Format("{0:0.00}", tenDollar * 10));
            text.Add("  20 DOLLAR    X");
            text.Add(string.Format("{0,5}", twentyDollar));
            text.Add(" =     $");
            text.Add(string.Format("{0:0.00}", twentyDollar * 20));
            text.Add("  50 DOLLAR    X");
            text.Add(string.Format("{0,5}", fiftyDollar));
            text.Add(" =     $");
            text.Add(string.Format("{0:0.00}", fiftyDollar * 50));
            text.Add("100 DOLLAR    X");
            text.Add(string.Format("{0,5}", hundredDollar));
            text.Add(" =     $");
            text.Add(string.Format("{0:0.00}", hundredDollar * 100));
            text.Add("----------------------------------------------------------------");
            text.Add("CASH IN DRAWER");
            text.Add(":");
            text.Add(string.Format("{0:$0.00}", cashDrawer));
            text.Add("DIFFERENCE");
            text.Add(":");
            text.Add(string.Format("{0:$0.00}", difference));
            text.Add("================================================================");
            text.Add("CASH WITHDRAW");
            text.Add(":");
            text.Add(string.Format("{0:$0.00}", withdraw));
            text.Add("CASH END");
            text.Add(":");
            text.Add(string.Format("{0:$0.00}", nextDayStartAmount));
            text.Add("NEXT DAY START");
            text.Add(":");
            text.Add(string.Format("{0:$0.00}", nextDayStartAmount));

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

            for (ctr = 30; ctr <= 38 ; ctr +=3)
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

            for (ctr = 40; ctr <= 55; ctr +=4)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr + 3], printFont2).Width;
                e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
                yPos2 = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr + 1], printFont2, Brushes.Black, 105, yPos + 3);
                yPos2 = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr + 2], printFont2, Brushes.Black, 150, yPos + 3);
                yPos2 = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr + 3], printFont2, Brushes.Black, xPos - 50, yPos + 3);
                ctrTemp += 1;
            }

            ctr = 56;
            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            for (ctr = 57; ctr <= 84; ctr += 4)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                xPos = (e.PageBounds.Width - 35) - e.Graphics.MeasureString((string)text[ctr + 3], printFont2).Width;
                e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
                yPos2 = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr + 1], printFont2, Brushes.Black, 105, yPos + 3);
                yPos2 = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr + 2], printFont2, Brushes.Black, 150, yPos + 3);
                yPos2 = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr + 3], printFont2, Brushes.Black, xPos - 50, yPos + 3);
                ctrTemp += 1;
            }

            ctr = 85;
            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            for (ctr = 86; ctr <= 91; ctr += 3)
            {
                yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
                e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
                e.Graphics.DrawString((String)text[ctr + 1], printFont2, Brushes.Black, 118, yPos + 3);
                e.Graphics.DrawString((String)text[ctr + 2], printFont2, Brushes.Black, 128, yPos + 3);
                ctrTemp += 1;
            }

            ctr = 92;
            yPos = ctrTemp * printFont2.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont2, Brushes.Black, 0, yPos + 3);
            ctrTemp += 1;

            for (ctr = 93; ctr <= 101; ctr += 3)
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
        /// Handles the PrintPage event of the pdPrint2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PrintPageEventArgs"/> instance containing the event data.</param>
        private void pdPrint2_PrintPage(object sender, PrintPageEventArgs e)
        {
            ArrayList text = new ArrayList();
            Single yPos, xPos;
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
            text.Add("STARTING REGISTER");
            text.Add("DATE & TIME");
            text.Add(":");
            text.Add(Convert.ToString(startDate) + " " + Convert.ToString(startTime));
            text.Add("TRANSACTION ID");
            text.Add(":");
            text.Add(Convert.ToString(transactionID + 1));
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
            text.Add("CASH START");
            text.Add(":");
            text.Add(string.Format("{0:$0.00}", nextDayStartAmount));
            text.Add("----------------------------------------------------------------");


            ctr = 0;
            yPos = ctr * printBoldFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printBoldFont, Brushes.Black, 83, yPos);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 60, yPos + 10);
            ctr += 1;
            yPos = ctr * printFont.GetHeight(e.Graphics);
            e.Graphics.DrawString((String)text[ctr], printFont, Brushes.Black, 70, yPos + 10);
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
        /// Handles the Click event of the txtPenny control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtPenny_Click(object sender, EventArgs e)
        {
            txtPenny.SelectAll();
        }

        /// <summary>
        /// Handles the Click event of the txtNickel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtNickel_Click(object sender, EventArgs e)
        {
            txtNickel.SelectAll();
        }

        /// <summary>
        /// Handles the Click event of the txtDime control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtDime_Click(object sender, EventArgs e)
        {
            txtDime.SelectAll();
        }

        /// <summary>
        /// Handles the Click event of the txtQuarter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtQuarter_Click(object sender, EventArgs e)
        {
            txtQuarter.SelectAll();
        }

        /// <summary>
        /// Handles the Click event of the txt1Dollar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txt1Dollar_Click(object sender, EventArgs e)
        {
            txt1Dollar.SelectAll();
        }

        /// <summary>
        /// Handles the Click event of the txt2Dollar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txt2Dollar_Click(object sender, EventArgs e)
        {
            txt2Dollar.SelectAll();
        }

        /// <summary>
        /// Handles the Click event of the txt5Dollar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txt5Dollar_Click(object sender, EventArgs e)
        {
            txt5Dollar.SelectAll();
        }

        /// <summary>
        /// Handles the Click event of the txt10Dollar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txt10Dollar_Click(object sender, EventArgs e)
        {
            txt10Dollar.SelectAll();
        }

        /// <summary>
        /// Handles the Click event of the txt20Dollar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txt20Dollar_Click(object sender, EventArgs e)
        {
            txt20Dollar.SelectAll();
        }

        /// <summary>
        /// Handles the Click event of the txt50Dollar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txt50Dollar_Click(object sender, EventArgs e)
        {
            txt50Dollar.SelectAll();
        }

        /// <summary>
        /// Handles the Click event of the txt100Dollar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txt100Dollar_Click(object sender, EventArgs e)
        {
            txt100Dollar.SelectAll();
        }

        /// <summary>
        /// Handles the Click event of the richtxtWithdraw control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void richtxtWithdraw_Click(object sender, EventArgs e)
        {
            richtxtWithdraw.SelectAll();
        }

        /// <summary>
        /// Handles the TextChanged event of the lblCashDrawer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lblCashDrawer_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(richtxtWithdraw.Text, out withdraw))
            {
                lblEndCash.Text = string.Format("{0:$0.00}", cashDrawer - withdraw);
            }
            else
            {
                MyMessageBox.ShowBox("INVALID AMOUNT", "ERROR");
                return;
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the richtxtWithdraw control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void richtxtWithdraw_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(richtxtWithdraw.Text, out withdraw))
            {
                lblEndCash.Text = string.Format("{0:$0.00}", cashDrawer - withdraw);
            }
            else
            {
                MyMessageBox.ShowBox("INVALID AMOUNT", "ERROR");
                return;
            }
        }
    }
}