// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 04-25-2017
// ***********************************************************************
// <copyright file="StartRegister.cs" company="Beauty4u">
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
    /// Class StartRegister.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class StartRegister : Form
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
        /// The cash drawer
        /// </summary>
        double cashDrawer = 0;

        /// <summary>
        /// The start date
        /// </summary>
        /// <summary>
        /// The start time
        /// </summary>
        string startDate, startTime;
        /// <summary>
        /// The manager identifier
        /// </summary>
        string managerID;
        /// <summary>
        /// The manager PSW
        /// </summary>
        string managerPsw;

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
        /// Initializes a new instance of the <see cref="StartRegister"/> class.
        /// </summary>
        /// <param name="empID">The emp identifier.</param>
        public StartRegister(string empID)
        {
            InitializeComponent();
            lblCashierID.Text = empID;
            lblDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
        }

        /// <summary>
        /// Handles the Load event of the StartRegister control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void StartRegister_Load(object sender, EventArgs e)
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

            txt100Dollar.SelectAll();
            lblCashDrawer.Text = "$0.00";

            Int32 retVal;
            String errMsg;
            apiAlias.StatusMonitoring pMonitorCB = new apiAlias.StatusMonitoring(StatusMonitoring);

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
        /// Handles the Click event of the btnStart control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtManagerID.Text == "")
                return;
            if (txtPsw.Text == "")
                return;

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
                MyMessageBox.ShowBox("INVALID ACCOUNT OR INCORRECT PASSWORD", "ERROR");
                return;
            }

            DateTime currentTime = DateTime.Now;
            startDate = string.Format("{0:MM/dd/yyyy}", currentTime);
            startTime = string.Format("{0:T}", currentTime);

            SqlCommand cmd = new SqlCommand("Create_StartRegister", parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RegisterNum", SqlDbType.NVarChar).Value = parentForm.cashRegisterNum;
            cmd.Parameters.Add("@TransactionStatus", SqlDbType.NVarChar).Value = "START";
            cmd.Parameters.Add("@RegStartAmount", SqlDbType.Money).Value = cashDrawer;
            cmd.Parameters.Add("@RegDate", SqlDbType.NVarChar).Value = startDate;
            cmd.Parameters.Add("@RegTime", SqlDbType.NVarChar).Value = startTime;
            cmd.Parameters.Add("@RegCashierID", SqlDbType.NVarChar).Value = lblCashierID.Text;
            cmd.Parameters.Add("@RegManagerID", SqlDbType.NVarChar).Value = txtManagerID.Text.Trim().ToString().ToUpper();

            parentForm.conn.Open();
            cmd.ExecuteNonQuery();
            parentForm.conn.Close();

            lblStartCash.Text = string.Format("{0:$0.00}", cashDrawer);
            MyMessageBox.ShowBox("SUCCESSFULLY STARTED", "INFORMATION"); ;
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the TextChanged event of the lblCashDrawer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lblCashDrawer_TextChanged(object sender, EventArgs e)
        {
            lblStartCash.Text = lblCashDrawer.Text;
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
    }
}