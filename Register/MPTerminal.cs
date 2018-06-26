// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 04-05-2017
// ***********************************************************************
// <copyright file="MPTerminal.cs" company="Beauty4u">
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
    /// Class MPTerminal.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class MPTerminal : Form
    {
        /// <summary>
        /// The parent form
        /// </summary>
        public MultiplePayment parentForm;

        /// <summary>
        /// The terminal type
        /// </summary>
        string terminalType;
        /// <summary>
        /// The reference card number
        /// </summary>
        string RefCardNum;
        /// <summary>
        /// The n reference card number
        /// </summary>
        int nRefCardNum;
        /// <summary>
        /// The terminal credit type
        /// </summary>
        string terminalCreditType;

        /// <summary>
        /// The terminal pay amount
        /// </summary>
        double terminalPayAmount;

        /// <summary>
        /// The zip code
        /// </summary>
        Int32 zipCode;

        /// <summary>
        /// The store code
        /// </summary>
        string StoreCode;
        /// <summary>
        /// The cashier identifier
        /// </summary>
        string CashierID;
        /// <summary>
        /// The register number
        /// </summary>
        string RegisterNum;
        /// <summary>
        /// The member identifier
        /// </summary>
        string MemberID;
        /// <summary>
        /// The member name
        /// </summary>
        string MemberName;
        /// <summary>
        /// The pay by
        /// </summary>
        int PayBy = 5;
        /// <summary>
        /// The sell date
        /// </summary>
        string SellDate;
        /// <summary>
        /// The sell time
        /// </summary>
        string SellTime;
        /// <summary>
        /// The sub total
        /// </summary>
        string SubTotal;
        /// <summary>
        /// The tax
        /// </summary>
        string Tax;
        /// <summary>
        /// The discount
        /// </summary>
        double Discount;
        /// <summary>
        /// The member points
        /// </summary>
        double MemberPoints;
        /// <summary>
        /// The receipt type
        /// </summary>
        string ReceiptType;
        /// <summary>
        /// The receipt status
        /// </summary>
        string ReceiptStatus;
        /// <summary>
        /// The receipt identifier
        /// </summary>
        Int64 ReceiptID;

        /// <summary>
        /// Initializes a new instance of the <see cref="MPTerminal"/> class.
        /// </summary>
        /// <param name="nPay">The n pay.</param>
        public MPTerminal(double nPay)
        {
            InitializeComponent();
            terminalPayAmount = nPay;
            lblPay.Text = string.Format("{0:$0.00}", terminalPayAmount);
        }

        /// <summary>
        /// Handles the Load event of the MPTerminal control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MPTerminal_Load(object sender, EventArgs e)
        {
            //cmbTerminalType.SelectedIndex = 0;
        }

        /// <summary>
        /// Handles the Click event of the btnMakeSure control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnMakeSure_Click(object sender, EventArgs e)
        {
            btnCheckOut.Enabled = true;
            btnMakeSure.Enabled = false;
        }

        /// <summary>
        /// Handles the Click event of the btnCheckOut control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (cmbTerminalType.Text == "")
            {
                MyMessageBox.ShowBox("PLEASE SELECT CARD TYPE", "ERROR");
                return;
            }

            terminalType = cmbTerminalType.Text.Trim().ToUpper();

            if (cmbTerminalType.SelectedIndex == 2)
            {
                if (txtCardNum.Text.Length == 17)
                {
                    RefCardNum = txtCardNum.Text.Substring(txtCardNum.Text.Length - 4, 4);

                    if (int.TryParse(RefCardNum, out nRefCardNum))
                    {
                    }
                    else
                    {
                        MyMessageBox.ShowBox("INVALID LAST 4 DIGIT", "ERROR");
                        txtCardNum.Select(13, txtCardNum.Text.Length - 12);
                        txtCardNum.Focus();
                        return;
                    }
                }
                else
                {
                    MyMessageBox.ShowBox("INPUT LAST 4 DIGIT", "ERROR");
                    txtCardNum.Select(13, txtCardNum.Text.Length - 12);
                    txtCardNum.Focus();
                    return;
                }
            }
            else
            {
                if (txtCardNum.Text.Length == 19)
                {
                    RefCardNum = txtCardNum.Text.Substring(txtCardNum.Text.Length - 4, 4);

                    if (int.TryParse(RefCardNum, out nRefCardNum))
                    {
                    }
                    else
                    {
                        MyMessageBox.ShowBox("INVALID LAST 4 DIGIT", "ERROR");
                        txtCardNum.Select(15, txtCardNum.Text.Length - 15);
                        txtCardNum.Focus();
                        return;
                    }
                }
                else
                {
                    MyMessageBox.ShowBox("INPUT LAST 4 DIGIT", "ERROR");
                    txtCardNum.Select(15, txtCardNum.Text.Length - 15);
                    txtCardNum.Focus();
                    return;
                }
            }

            SellDate = string.Format("{0:MM/dd/yyyy}", DateTime.Now);
            SellTime = string.Format("{0:T}", DateTime.Now);

            SqlCommand cmd_RefCreditTransaction = new SqlCommand("Create_RefCreditTransaction", parentForm.parentForm.conn);
            cmd_RefCreditTransaction.CommandType = CommandType.StoredProcedure;
            cmd_RefCreditTransaction.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = 99;
            cmd_RefCreditTransaction.Parameters.Add("@TroutD", SqlDbType.NVarChar).Value = "TERMINAL";
            cmd_RefCreditTransaction.Parameters.Add("@AuthNum", SqlDbType.NVarChar).Value = "CREDIT";
            cmd_RefCreditTransaction.Parameters.Add("@RefCardNum", SqlDbType.NVarChar).Value = RefCardNum;
            cmd_RefCreditTransaction.Parameters.Add("@CardType", SqlDbType.NVarChar).Value = TerminalCreditType(cmbTerminalType.SelectedIndex);
            cmd_RefCreditTransaction.Parameters.Add("@Amount", SqlDbType.Money).Value = terminalPayAmount;
            cmd_RefCreditTransaction.Parameters.Add("@IssueDate", SqlDbType.NVarChar).Value = SellDate;
            cmd_RefCreditTransaction.Parameters.Add("@IssueTime", SqlDbType.NVarChar).Value = SellTime;

            parentForm.parentForm.conn.Open();
            cmd_RefCreditTransaction.ExecuteNonQuery();
            parentForm.parentForm.conn.Close();

            parentForm.dt.Rows.Add("TERMINAL", 3, terminalPayAmount, parentForm.parentForm.storeCode);
            parentForm.Binding_dataGridView1();

            parentForm.Check_RemainingAmount();
            this.Close();
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
        /// Handles the SelectedIndexChanged event of the cmbTerminalType control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmbTerminalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTerminalType.SelectedIndex >= 0)
            {
                txtCardNum.Enabled = true;
                //lblZipCode.Visible = true;
                //txtZipCode.Visible = true;

                if (cmbTerminalType.SelectedIndex == 2)
                {
                    lblLast4Digit.Visible = true;
                    txtCardNum.Text = "XXXX-XXXXXX-X";
                    txtCardNum.Select(13, 0);
                    txtCardNum.Focus();
                }
                else
                {
                    lblLast4Digit.Visible = true;
                    txtCardNum.Text = "XXXX-XXXX-XXXX-";
                    txtCardNum.Select(15, 0);
                    txtCardNum.Focus();
                }
            }
            else
            {
                lblLast4Digit.Visible = false;
                txtCardNum.Clear();
                txtCardNum.Enabled = false;
                lblZipCode.Visible = false;
                txtZipCode.Visible = false;
            }
        }

        /// <summary>
        /// Terminals the type of the credit.
        /// </summary>
        /// <param name="idx">The index.</param>
        /// <returns>System.String.</returns>
        private string TerminalCreditType(int idx)
        {
            switch (idx)
            {
                case 0:
                    terminalCreditType = "VISA";
                    break;
                case 1:
                    terminalCreditType = "MASTER";
                    break;
                case 2:
                    terminalCreditType = "AMEX";
                    break;
                case 3:
                    terminalCreditType = "DISCOVER";
                    break;
            }

            return terminalCreditType;
        }
    }
}