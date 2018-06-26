// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 09-19-2015
// ***********************************************************************
// <copyright file="GiftcardRedeem.cs" company="Beauty4u">
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

/// <summary>
/// The Register namespace.
/// </summary>
namespace Register
{
    /// <summary>
    /// Class GiftcardRedeem.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class GiftcardRedeem : Form
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
        /// The command
        /// </summary>
        SqlCommand cmd;
        /// <summary>
        /// The gift card code
        /// </summary>
        string giftCardCode;
        /// <summary>
        /// The current balance
        /// </summary>
        double currentBalance = 0;
        /// <summary>
        /// The input amount
        /// </summary>
        double inputAmount = 0;
        /// <summary>
        /// All amount
        /// </summary>
        double allAmount = 0;
        /// <summary>
        /// The redeem amount
        /// </summary>
        double redeemAmount = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="GiftcardRedeem"/> class.
        /// </summary>
        public GiftcardRedeem()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the GiftcardRedeem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void GiftcardRedeem_Load(object sender, EventArgs e)
        {
            if (parentForm.storeCode == "TH")
            {
                cmbStoreCode.SelectedIndex = 0;
            }
            else if (parentForm.storeCode == "OH")
            {
                cmbStoreCode.SelectedIndex = 1;
            }
            else if (parentForm.storeCode == "UM")
            {
                cmbStoreCode.SelectedIndex = 2;
            }
            else if (parentForm.storeCode == "CH")
            {
                cmbStoreCode.SelectedIndex = 3;
            }
            else if (parentForm.storeCode == "WM")
            {
                cmbStoreCode.SelectedIndex = 4;
            }
            else if (parentForm.storeCode == "CV")
            {
                cmbStoreCode.SelectedIndex = 5;
            }
            else if (parentForm.storeCode == "WB")
            {
                cmbStoreCode.SelectedIndex = 6;
            }
            else if (parentForm.storeCode == "WD")
            {
                cmbStoreCode.SelectedIndex = 7;
            }
            else if (parentForm.storeCode == "PW")
            {
                cmbStoreCode.SelectedIndex = 8;
            }
            else if (parentForm.storeCode == "GB")
            {
                cmbStoreCode.SelectedIndex = 9;
            }
            else if (parentForm.storeCode == "BW")
            {
                cmbStoreCode.SelectedIndex = 10;
            }

            txtGiftCardCode.SelectAll();
            txtGiftCardCode.Focus();
        }

        /// <summary>
        /// Handles the Click event of the btnInput control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnInput_Click(object sender, EventArgs e)
        {
            if (txtGiftCardCode.Text == "")
            {
                MyMessageBox.ShowBox("INPUT GIFTCARD CODE", "ERROR");
                txtGiftCardCode.Select();
                txtGiftCardCode.Focus();
            }
            else
            {
                lblCurrentBalance.Text = "";

                if (parentForm.storeCode != cmbStoreCode.Text)
                {
                    newConn = new SqlConnection(parentForm.parentForm.OtherStoreConnectionString(cmbStoreCode.Text));
                    giftCardCode = txtGiftCardCode.Text.ToString().ToUpper().Trim();

                    try
                    {
                        cmd = new SqlCommand("Get_Giftcard_Balance", newConn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@GiftCardCode", SqlDbType.NVarChar).Value = giftCardCode;
                        SqlParameter GiftcardBalance_Param = cmd.Parameters.Add("@Balance", SqlDbType.Money);
                        GiftcardBalance_Param.Direction = ParameterDirection.Output;

                        newConn.Open();
                        cmd.ExecuteNonQuery();
                        newConn.Close();

                        if (cmd.Parameters["@Balance"].Value != DBNull.Value)
                        {
                            currentBalance = Convert.ToDouble(cmd.Parameters["@Balance"].Value);
                            txtGiftCardCode.Enabled = false;
                            btnInput.Enabled = false;
                            cmbStoreCode.Enabled = false;
                            lblCurrentBalance.Text = string.Format("{0:$0.00}", currentBalance);

                            if (currentBalance == 0)
                                MyMessageBox.ShowBox("THIS GIFTCARD BALANCE IS 0", "INFORMATION");
                        }
                        else
                        {
                            MyMessageBox.ShowBox("CAN NOT FIND GIFTCARD", "ERROR");
                            txtGiftCardCode.SelectAll();
                            txtGiftCardCode.Focus();
                            return;
                        }
                    }
                    catch
                    {
                        MyMessageBox.ShowBox("DUPLICATED GIFTCARD CODE OR SERVER CONNECT FAILED", "ERROR");
                        newConn.Close();
                        txtGiftCardCode.SelectAll();
                        txtGiftCardCode.Focus();
                        return;
                    }
                }
                else
                {
                    giftCardCode = txtGiftCardCode.Text.ToString().ToUpper().Trim();

                    try
                    {
                        cmd = new SqlCommand("Get_Giftcard_Balance", parentForm.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@GiftCardCode", SqlDbType.NVarChar).Value = giftCardCode;
                        SqlParameter GiftcardBalance_Param = cmd.Parameters.Add("@Balance", SqlDbType.Money);
                        GiftcardBalance_Param.Direction = ParameterDirection.Output;

                        parentForm.conn.Open();
                        cmd.ExecuteNonQuery();
                        parentForm.conn.Close();

                        if (cmd.Parameters["@Balance"].Value != DBNull.Value)
                        {
                            currentBalance = Convert.ToDouble(cmd.Parameters["@Balance"].Value);
                            txtGiftCardCode.Enabled = false;
                            btnInput.Enabled = false;
                            cmbStoreCode.Enabled = false;
                            lblCurrentBalance.Text = string.Format("{0:$0.00}", currentBalance);

                            if (currentBalance == 0)
                                MyMessageBox.ShowBox("THIS GIFTCARD BALANCE IS 0", "INFORMATION");
                        }
                        else
                        {
                            MyMessageBox.ShowBox("CAN NOT FIND GIFTCARD", "ERROR");
                            txtGiftCardCode.SelectAll();
                            txtGiftCardCode.Focus();
                            return;
                        }
                    }
                    catch
                    {
                        MyMessageBox.ShowBox("DUPLICATED GIFTCARD CODE OR SERVER CONNECT FAILED", "ERROR");
                        parentForm.conn.Close();
                        txtGiftCardCode.SelectAll();
                        txtGiftCardCode.Focus();
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnRedeem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnRedeem_Click(object sender, EventArgs e)
        {
            if (parentForm.dataGridView1.RowCount == 0)
            {
                MyMessageBox.ShowBox("NO ITEM", "ERROR");
                return;
            }

            if (currentBalance > 0 & parentForm.calSubTotal > 0)
            {
                if (radioBtnInputAmount.Checked == true)
                {
                    if (double.TryParse(txtInputAmount.Text, out inputAmount))
                    {
                        if (inputAmount == 0)
                            return;

                        if (inputAmount > currentBalance)
                        {
                            MyMessageBox.ShowBox("INPUT AMOUNT EXCEEDS CURRENT BALANCE", "ERROR");
                            txtInputAmount.SelectAll();
                            txtInputAmount.Focus();
                            return;
                        }
                        else
                        {
                            redeemAmount = inputAmount;
                            parentForm.giftcardRedeem = redeemAmount;
                            parentForm.giftcardCodeDesc = giftCardCode;
                            parentForm.giftcardStoreCode = cmbStoreCode.Text.ToUpper();
                            parentForm.richTxtUpc.Text = "000000999111";
                            parentForm.btnInput_Click(null, null);

                            parentForm.Enabled = true;
                            this.Close();
                            parentForm.richTxtUpc.Select();
                            parentForm.richTxtUpc.Focus();
                        }
                    }
                    else
                    {
                        MyMessageBox.ShowBox("INVALID AMOUNT", "ERROR");
                        txtInputAmount.SelectAll();
                        txtInputAmount.Focus();
                        return;
                    }
                }
                else if (radioBtnAllAmount.Checked == true)
                {
                    redeemAmount = currentBalance;
                    parentForm.giftcardRedeem = redeemAmount;
                    parentForm.giftcardCodeDesc = giftCardCode;
                    parentForm.giftcardStoreCode = cmbStoreCode.Text.ToUpper();
                    parentForm.richTxtUpc.Text = "000000999111";
                    parentForm.btnInput_Click(null, null);

                    parentForm.Enabled = true;
                    this.Close();
                    parentForm.richTxtUpc.Select();
                    parentForm.richTxtUpc.Focus();
                }
            }
            else
            {
                txtGiftCardCode.SelectAll();
                txtGiftCardCode.Focus();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            parentForm.Enabled = true;
            parentForm.giftcardRedeem = 0;
            parentForm.giftcardCodeDesc = "";
            this.Close();
            parentForm.richTxtUpc.Select();
            parentForm.richTxtUpc.Focus();
        }

        /// <summary>
        /// Handles the TextChanged event of the lblCurrentBalance control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lblCurrentBalance_TextChanged(object sender, EventArgs e)
        {
            if (currentBalance > 0)
            {
                btnRedeem.Enabled = true;
            }
            else
            {
                btnRedeem.Enabled = false;
            }

        }

        /// <summary>
        /// Handles the Click event of the txtInputAmount control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtInputAmount_Click(object sender, EventArgs e)
        {
            txtInputAmount.SelectAll();
            txtInputAmount.Focus();
        }
    }
    
}