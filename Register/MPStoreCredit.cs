// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 03-27-2017
// ***********************************************************************
// <copyright file="MPStoreCredit.cs" company="Beauty4u">
//     Copyright © Beauty4u 2009
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

/// <summary>
/// The Register namespace.
/// </summary>
namespace Register
{
    /// <summary>
    /// Class MPStoreCredit.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class MPStoreCredit : Form
    {
        /// <summary>
        /// The parent form
        /// </summary>
        public MultiplePayment parentForm;
        /// <summary>
        /// The authentication
        /// </summary>
        public bool auth;

        /// <summary>
        /// The command
        /// </summary>
        SqlCommand cmd = new SqlCommand();

        /// <summary>
        /// The store credit identifier
        /// </summary>
        Int64 storeCreditID;
        /// <summary>
        /// The balance
        /// </summary>
        double balance;

        /// <summary>
        /// The store credit pay amount
        /// </summary>
        double storeCreditPayAmount = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="MPStoreCredit"/> class.
        /// </summary>
        /// <param name="nPay">The n pay.</param>
        public MPStoreCredit(double nPay)
        {
            InitializeComponent();
            storeCreditPayAmount = nPay;
            lblPay.Text = string.Format("{0:c}", storeCreditPayAmount);
        }

        /// <summary>
        /// Handles the Load event of the MPStoreCredit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MPStoreCredit_Load(object sender, EventArgs e)
        {
            auth = true;

            if (parentForm.StoreCode == "TEST")
                cmbStoreCode.Items.Add("TEST");

            if (parentForm.StoreCode == "TH")
            {
                cmbStoreCode.SelectedIndex = 0;
            }
            else if (parentForm.StoreCode == "OH")
            {
                cmbStoreCode.SelectedIndex = 1;
            }
            else if (parentForm.StoreCode == "UM")
            {
                cmbStoreCode.SelectedIndex = 2;
            }
            else if (parentForm.StoreCode == "CH")
            {
                cmbStoreCode.SelectedIndex = 3;
            }
            else if (parentForm.StoreCode == "WM")
            {
                cmbStoreCode.SelectedIndex = 4;
            }
            else if (parentForm.StoreCode == "CV")
            {
                cmbStoreCode.SelectedIndex = 5;
            }
            else if (parentForm.StoreCode == "WB")
            {
                cmbStoreCode.SelectedIndex = 6;
            }
            else if (parentForm.StoreCode == "WD")
            {
                cmbStoreCode.SelectedIndex = 7;
            }
            else if (parentForm.StoreCode == "PW")
            {
                cmbStoreCode.SelectedIndex = 8;
            }
            else if (parentForm.StoreCode == "GB")
            {
                cmbStoreCode.SelectedIndex = 9;
            }
            else if (parentForm.StoreCode == "BW")
            {
                cmbStoreCode.SelectedIndex = 10;
            }
            else if (parentForm.StoreCode == "TEST")
            {
                cmbStoreCode.Text = "TEST";
            }

            auth = false;

            richtxtStoreCreditID.Select();
            richtxtStoreCreditID.Focus();
        }

        /// <summary>
        /// Handles the Click event of the btnInput control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnInput_Click(object sender, EventArgs e)
        {
            if (richtxtStoreCreditID.Text == "")
            {
                MyMessageBox.ShowBox("INPUT STORECREDIT ID", "ERROR");
                richtxtStoreCreditID.Select();
                richtxtStoreCreditID.Focus();
            }
            else
            {
                lblCurrentBalance.Text = "";
                lblRemainingBalance.Text = "";

                if (parentForm.StoreCode != cmbStoreCode.Text)
                {
                    if (auth == false)
                    {
                        Authentication authenticationForm = new Authentication(7);
                        authenticationForm.parentForm1 = this.parentForm.parentForm;
                        authenticationForm.parentForm5 = this;
                        authenticationForm.ShowDialog();
                    }
                    else
                    {
                        try
                        {
                            parentForm.newConn_StoreCredit = new SqlConnection(parentForm.parentForm.parentForm.OtherStoreConnectionString(cmbStoreCode.Text));

                            if (Int64.TryParse(richtxtStoreCreditID.Text, out storeCreditID))
                            {
                                //Store Credit Double Check
                                for (int i = 0; i < parentForm.dataGridView1.RowCount; i++)
                                {
                                    if (Convert.ToInt16(parentForm.dataGridView1.Rows[i].Cells[1].Value) == 88)
                                    {
                                        if (Convert.ToString(parentForm.dataGridView1.Rows[i].Cells[3].Value) == cmbStoreCode.Text & Convert.ToInt64(parentForm.dataGridView1.Rows[i].Cells[4].Value) == Convert.ToInt64(richtxtStoreCreditID.Text.Trim()))
                                        {
                                            MyMessageBox.ShowBox("DUPLICATED STORE CREDIT ID", "ERROR");
                                            richtxtStoreCreditID.SelectAll();
                                            richtxtStoreCreditID.Focus();
                                            return;
                                        }
                                    }
                                }

                                cmd.Connection = parentForm.newConn_StoreCredit;
                                cmd.CommandText = "Show_StoreCredit_Balance";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@StoreCreditID", SqlDbType.BigInt).Value = storeCreditID;
                                cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = cmbStoreCode.Text;
                                SqlParameter Balance_Param = cmd.Parameters.Add("@Balance", SqlDbType.Money);
                                Balance_Param.Direction = ParameterDirection.Output;

                                parentForm.newConn_StoreCredit.Open();
                                cmd.ExecuteNonQuery();
                                parentForm.newConn_StoreCredit.Close();

                                if (cmd.Parameters["@Balance"].Value == DBNull.Value)
                                {
                                    MyMessageBox.ShowBox("COULD NOT FOUND STORE CREDIT ID", "ERROR");
                                    richtxtStoreCreditID.SelectAll();
                                    richtxtStoreCreditID.Focus();
                                }
                                else if (Convert.ToDouble(cmd.Parameters["@Balance"].Value) <= 0)
                                {
                                    MyMessageBox.ShowBox("YOUR BALANCE IS 0", "ERROR");
                                    richtxtStoreCreditID.SelectAll();
                                    richtxtStoreCreditID.Focus();
                                }
                                else
                                {
                                    balance = Convert.ToDouble(cmd.Parameters["@Balance"].Value);
                                    lblCurrentBalance.Text = string.Format("{0:c}", balance);

                                    if (balance >= storeCreditPayAmount)
                                    {
                                        richtxtStoreCreditID.Enabled = false;
                                        cmbStoreCode.Enabled = false;
                                        btnCheckOut.Enabled = true;
                                    }
                                    else
                                    {
                                        MyMessageBox.ShowBox("NOT ENOUGH STORE CREDIT", "ERROR");
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                MyMessageBox.ShowBox("INVALID STORE CREDIT ID", "ERROR");
                                richtxtStoreCreditID.SelectAll();
                                richtxtStoreCreditID.Focus();
                            }
                        }
                        catch
                        {
                            if (parentForm.newConn_StoreCredit.State == ConnectionState.Open)
                                parentForm.newConn_StoreCredit.Close();

                            MyMessageBox.ShowBox(cmbStoreCode.Text + " CONNECTION", "ERROR");
                            richtxtStoreCreditID.SelectAll();
                            richtxtStoreCreditID.Focus();
                        }
                    }
                }
                else
                {
                    if (Int64.TryParse(richtxtStoreCreditID.Text, out storeCreditID))
                    {
                        //Store Credit Double Check
                        for (int i = 0; i < parentForm.dataGridView1.RowCount; i++)
                        {
                            if (Convert.ToInt16(parentForm.dataGridView1.Rows[i].Cells[1].Value) == 88)
                            {
                                if (Convert.ToString(parentForm.dataGridView1.Rows[i].Cells[3].Value) == cmbStoreCode.Text & Convert.ToInt64(parentForm.dataGridView1.Rows[i].Cells[4].Value) == Convert.ToInt64(richtxtStoreCreditID.Text.Trim()))
                                {
                                    MyMessageBox.ShowBox("DUPLICATED STORE CREDIT ID", "ERROR");
                                    richtxtStoreCreditID.SelectAll();
                                    richtxtStoreCreditID.Focus();
                                    return;
                                }
                            }
                        }

                        cmd.Connection = parentForm.parentForm.conn;
                        cmd.CommandText = "Show_StoreCredit_Balance";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@StoreCreditID", SqlDbType.BigInt).Value = storeCreditID;
                        cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = parentForm.parentForm.storeCode;
                        SqlParameter Balance_Param = cmd.Parameters.Add("@Balance", SqlDbType.Money);
                        Balance_Param.Direction = ParameterDirection.Output;

                        parentForm.parentForm.conn.Open();
                        cmd.ExecuteNonQuery();
                        parentForm.parentForm.conn.Close();

                        if (cmd.Parameters["@Balance"].Value == DBNull.Value)
                        {
                            MyMessageBox.ShowBox("COULD NOT FOUND STORE CREDIT ID", "ERROR");
                            richtxtStoreCreditID.SelectAll();
                            richtxtStoreCreditID.Focus();
                        }
                        else if (Convert.ToDouble(cmd.Parameters["@Balance"].Value) <= 0)
                        {
                            MyMessageBox.ShowBox("YOUR BALANCE IS 0", "ERROR");
                            richtxtStoreCreditID.SelectAll();
                            richtxtStoreCreditID.Focus();
                        }
                        else
                        {
                            balance = Convert.ToDouble(cmd.Parameters["@Balance"].Value);
                            lblCurrentBalance.Text = "$" + Convert.ToString(balance);

                            if (balance >= storeCreditPayAmount)
                            {
                                richtxtStoreCreditID.Enabled = false;
                                cmbStoreCode.Enabled = false;
                                btnCheckOut.Enabled = true;
                            }
                            else
                            {
                                MyMessageBox.ShowBox("NOT ENOUGH STORE CREDIT", "ERROR");
                                return;
                            }
                        }
                    }
                    else
                    {
                        MyMessageBox.ShowBox("INVALID STORE CREDIT ID", "ERROR");
                        richtxtStoreCreditID.SelectAll();
                        richtxtStoreCreditID.Focus();
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCheckOut control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            parentForm.dt.Rows.Add("STORE CREDIT", 88, storeCreditPayAmount, cmbStoreCode.Text.Trim().ToUpper(), storeCreditID, balance, balance - storeCreditPayAmount);
            parentForm.Binding_dataGridView1();

            parentForm.Check_RemainingAmount();
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
    }
}