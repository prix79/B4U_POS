// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 12-12-2014
// ***********************************************************************
// <copyright file="InputGiftcardCode.cs" company="Beauty4u">
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
    /// Class InputGiftcardCode.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class InputGiftcardCode : Form
    {
        /// <summary>
        /// The parent form
        /// </summary>
        public MainForm parentForm;
        /// <summary>
        /// The parent form2
        /// </summary>
        public NoBarcodeItem parentForm2;
        /// <summary>
        /// The command
        /// </summary>
        SqlCommand cmd;
        /// <summary>
        /// The CMD2
        /// </summary>
        SqlCommand cmd2;

        /// <summary>
        /// The balance code
        /// </summary>
        int balanceCode;
        /// <summary>
        /// The opt
        /// </summary>
        int opt;

        /// <summary>
        /// Initializes a new instance of the <see cref="InputGiftcardCode"/> class.
        /// </summary>
        /// <param name="a">a.</param>
        public InputGiftcardCode(int a)
        {
            InitializeComponent();
            opt = a;
        }

        /// <summary>
        /// Handles the Load event of the InputGiftcardCode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void InputGiftcardCode_Load(object sender, EventArgs e)
        {
            richtxtGiftcardCode.Focus();
        }

        /// <summary>
        /// Handles the Click event of the btnInput control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnInput_Click(object sender, EventArgs e)
        {
            try
            {
                balanceCode = Convert.ToInt16(richtxtGiftcardCode.Text.Trim().Substring(4, 1));

                if (balanceCode != opt)
                {
                    if (opt == 1)
                    {
                        MyMessageBox.ShowBox("THIS CODE IS NOT VALID FOR $25 GIFTCARD.", "ERROR");
                    }
                    else if (opt == 2)
                    {
                        MyMessageBox.ShowBox("THIS CODE IS NOT VALID FOR $50 GIFTCARD.", "ERROR");
                    }
                    else if (opt == 3)
                    {
                        MyMessageBox.ShowBox("THIS CODE IS NOT VALID FOR $100 GIFTCARD.", "ERROR");
                    }
                 
                    richtxtGiftcardCode.SelectAll();
                    richtxtGiftcardCode.Focus();
                    return;
                }

                cmd = new SqlCommand("Check_GiftcardCode", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@GiftCardCode", SqlDbType.NVarChar).Value = richtxtGiftcardCode.Text.Trim().ToString().ToUpper();
                SqlParameter Check_Param = cmd.Parameters.Add("@CheckNum", SqlDbType.Int);
                Check_Param.Direction = ParameterDirection.Output;

                parentForm.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm.conn.Close();

                if (cmd.Parameters["@CheckNum"].Value == DBNull.Value)
                {
                    MyMessageBox.ShowBox("INVALID GIFTCARD CODE", "ERROR");
                    richtxtGiftcardCode.SelectAll();
                    richtxtGiftcardCode.Focus();
                    return;
                }
                else if (Convert.ToInt16(cmd.Parameters["@CheckNum"].Value) == 0)
                {
                    MyMessageBox.ShowBox("INVALID GIFTCARD CODE", "ERROR");
                    richtxtGiftcardCode.SelectAll();
                    richtxtGiftcardCode.Focus();
                    return;
                }
                else if (Convert.ToInt16(cmd.Parameters["@CheckNum"].Value) == 1)
                {
                    cmd2 = new SqlCommand("Get_Giftcard_Balance2", parentForm.conn);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Clear();
                    cmd2.Parameters.Add("@GiftCardCode", SqlDbType.NVarChar).Value = richtxtGiftcardCode.Text.Trim().ToString().ToUpper();
                    SqlParameter GiftcardBalance_Param = cmd2.Parameters.Add("@Balance", SqlDbType.Money);
                    GiftcardBalance_Param.Direction = ParameterDirection.Output;

                    parentForm.conn.Open();
                    cmd2.ExecuteNonQuery();
                    parentForm.conn.Close();

                    if (Convert.ToDouble(cmd2.Parameters["@Balance"].Value) == 0)
                    {
                        MyMessageBox.ShowBox("THIS GIFTCARD BALANCE IS 0", "INFORMATION");
                        richtxtGiftcardCode.SelectAll();
                        richtxtGiftcardCode.Focus();
                        return;
                    }
                    else
                    {
                        parentForm2.gcCode = richtxtGiftcardCode.Text.Trim().ToString().ToUpper();
                        this.Close();
                        parentForm2.Giftcard_Scanning(balanceCode);
                    }
                }
                else if (Convert.ToInt16(cmd.Parameters["@CheckNum"].Value) > 1)
                {
                    MyMessageBox.ShowBox("DUPLICATED GIFTCARD CODE", "ERROR");
                    richtxtGiftcardCode.SelectAll();
                    richtxtGiftcardCode.Focus();
                    return;
                }
            }
            catch
            {
                parentForm.conn.Close();
                MyMessageBox.ShowBox("CONNECTION FAILED", "ERROR");
                richtxtGiftcardCode.SelectAll();
                richtxtGiftcardCode.Focus();
                return;
            }
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