// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 05-09-2016
// ***********************************************************************
// <copyright file="CouponRedeem.cs" company="Beauty4u">
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
    /// Class CouponRedeem.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class CouponRedeem : Form
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
        /// The cp category1
        /// </summary>
        string cpCategory1;
        /// <summary>
        /// The cptype
        /// </summary>
        string cptype;
        /// <summary>
        /// The cp amt
        /// </summary>
        double cpAmt;

        /// <summary>
        /// The qty
        /// </summary>
        int qty;
        /// <summary>
        /// The disc PRC
        /// </summary>
        double discPrc;
        /// <summary>
        /// The PRC
        /// </summary>
        double prc;

        /// <summary>
        /// Initializes a new instance of the <see cref="CouponRedeem"/> class.
        /// </summary>
        public CouponRedeem()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the CouponRedeem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CouponRedeem_Load(object sender, EventArgs e)
        {
            txtCouponNum.SelectAll();
            txtCouponNum.Focus();
        }

        /// <summary>
        /// Handles the Click event of the btnRedeem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnRedeem_Click(object sender, EventArgs e)
        {
            if (txtCouponNum.Text.Trim().ToString() == "")
            {
                return;
            }
            else
            {
                cmd = new SqlCommand("Get_Coupon", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@CpNum", SqlDbType.NVarChar).Value = txtCouponNum.Text.Trim().ToUpper().ToString();
                SqlParameter CheckNum_Param = cmd.Parameters.Add("@CheckNum", SqlDbType.Int);
                CheckNum_Param.Direction = ParameterDirection.Output;

                parentForm.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm.conn.Close();

                if (Convert.ToInt16(cmd.Parameters["@CheckNum"].Value) == 1)
                {
                    cpCategory1 = txtCouponNum.Text.Substring(2, 1);
                    cptype = txtCouponNum.Text.Substring(3, 1);
                    cpAmt = Convert.ToDouble(txtCouponNum.Text.Substring(4, 2));

                    if (cpCategory1 == "G")
                    {

                    }
                    else if (cpCategory1 == "H")
                    {
                        if (Convert.ToString(parentForm.dataGridView1.SelectedCells[8].Value) == "3")
                        {
                            if (Convert.ToDouble(parentForm.dataGridView1.SelectedCells[4].Value) > 0)
                            {
                                MyMessageBox.ShowBox("SELECTED ITEM IS ALREADY DISCOUNTED", "ERROR");
                                txtCouponNum.SelectAll();
                                txtCouponNum.Focus();
                                return;
                            }
                            else if (Convert.ToDouble(parentForm.dataGridView1.SelectedCells[5].Value) < 0)
                            {
                                MyMessageBox.ShowBox("NOT DISCOUNTABLE ITEM", "ERROR");
                                txtCouponNum.SelectAll();
                                txtCouponNum.Focus();
                                return;
                            }
                            else
                            {
                                if (cptype == "P")
                                {
                                    qty = Convert.ToInt16(parentForm.dataGridView1.SelectedCells[2].Value);
                                    discPrc = Convert.ToDouble(parentForm.dataGridView1.SelectedCells[3].Value) * (1 - (cpAmt / 100));
                                    prc = qty * Math.Round(discPrc, 2, MidpointRounding.AwayFromZero);
                                    parentForm.dataGridView1.SelectedCells[4].Value = Math.Round(discPrc, 2, MidpointRounding.AwayFromZero);
                                    parentForm.dataGridView1.SelectedCells[5].Value = prc;
                                    parentForm.dataGridView1.SelectedCells[6].Value = Math.Round(prc * parentForm.storeTaxRate, 2, MidpointRounding.AwayFromZero);

                                    parentForm.cpRedeem = true;
                                    parentForm.wp_cpNum = txtCouponNum.Text.Trim().ToUpper().ToString();
                                    parentForm.wp_cpTargetItem = Convert.ToString(parentForm.dataGridView1.SelectedCells[7].Value);
                                    parentForm.wp_cpDescription = "HAIR " + Convert.ToString(cpAmt) + "% OFF COUPON (T:" + parentForm.wp_cpTargetItem + ")";
                                    parentForm.richTxtUpc.Text = "000000999112";
                                    parentForm.btnInput_Click(null, null);

                                    this.Close();
                                    parentForm.Enabled = true;
                                    parentForm.richTxtUpc.Select();
                                    parentForm.richTxtUpc.Focus();
                                }
                                else
                                {
                                    MyMessageBox.ShowBox("NOT AVAILABLE COUPON", "ERROR");
                                    txtCouponNum.SelectAll();
                                    txtCouponNum.Focus();
                                    return;
                                }
                            }
                        }
                        else
                        {
                            MyMessageBox.ShowBox("THIS COUPON IS VALID FOR WIG ITEM ONLY", "ERROR");
                            txtCouponNum.SelectAll();
                            txtCouponNum.Focus();
                            return;
                        }
                    }
                    else if (cpCategory1 == "W")
                    {
                        if (Convert.ToString(parentForm.dataGridView1.SelectedCells[8].Value) == "2")
                        {
                            if (Convert.ToDouble(parentForm.dataGridView1.SelectedCells[4].Value) > 0)
                            {
                                MyMessageBox.ShowBox("SELECTED ITEM IS ALREADY DISCOUNTED", "ERROR");
                                txtCouponNum.SelectAll();
                                txtCouponNum.Focus();
                                return;
                            }
                            else if (Convert.ToDouble(parentForm.dataGridView1.SelectedCells[5].Value) < 0)
                            {
                                MyMessageBox.ShowBox("NOT DISCOUNTABLE ITEM", "ERROR");
                                txtCouponNum.SelectAll();
                                txtCouponNum.Focus();
                                return;
                            }
                            else
                            {
                                if (cptype == "P")
                                {
                                    qty = Convert.ToInt16(parentForm.dataGridView1.SelectedCells[2].Value);
                                    discPrc = Convert.ToDouble(parentForm.dataGridView1.SelectedCells[3].Value) * (1 - (cpAmt / 100));
                                    prc = qty * Math.Round(discPrc, 2, MidpointRounding.AwayFromZero);
                                    parentForm.dataGridView1.SelectedCells[4].Value = Math.Round(discPrc, 2, MidpointRounding.AwayFromZero);
                                    parentForm.dataGridView1.SelectedCells[5].Value = prc;
                                    parentForm.dataGridView1.SelectedCells[6].Value = Math.Round(prc * parentForm.storeTaxRate, 2, MidpointRounding.AwayFromZero);

                                    parentForm.cpRedeem = true;
                                    parentForm.wp_cpNum = txtCouponNum.Text.Trim().ToUpper().ToString();
                                    parentForm.wp_cpTargetItem = Convert.ToString(parentForm.dataGridView1.SelectedCells[7].Value);
                                    parentForm.wp_cpDescription = "WIG " + Convert.ToString(cpAmt) + "% OFF COUPON (T:" + parentForm.wp_cpTargetItem + ")";
                                    parentForm.richTxtUpc.Text = "000000999112";
                                    parentForm.btnInput_Click(null, null);

                                    this.Close();
                                    parentForm.Enabled = true;
                                    parentForm.richTxtUpc.Select();
                                    parentForm.richTxtUpc.Focus();
                                }
                                else
                                {
                                    MyMessageBox.ShowBox("NOT AVAILABLE COUPON", "ERROR");
                                    txtCouponNum.SelectAll();
                                    txtCouponNum.Focus();
                                    return;
                                }
                            }
                        }
                        else
                        {
                            MyMessageBox.ShowBox("THIS COUPON IS VALID FOR WIG ITEM ONLY", "ERROR");
                            txtCouponNum.SelectAll();
                            txtCouponNum.Focus();
                            return;
                        }
                    }
                    else
                    {
                        MyMessageBox.ShowBox("INVALID COUPON", "ERROR");
                        txtCouponNum.SelectAll();
                        txtCouponNum.Focus();
                        return;
                    }
                }
                else
                {
                    MyMessageBox.ShowBox("INVALID COUPON", "ERROR");
                    txtCouponNum.SelectAll();
                    txtCouponNum.Focus();
                    return;
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
            parentForm.Enabled = true;
            this.Close();
            parentForm.richTxtUpc.Select();
            parentForm.richTxtUpc.Focus();
        }

        /// <summary>
        /// Handles the Click event of the btnSMCouponRedeem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSMCouponRedeem_Click(object sender, EventArgs e)
        {
            if (txtCouponNum.Text.Trim().ToString() == "")
            {
                return;
            }
            else
            {
                cmd = new SqlCommand("Get_SM_Coupon", parentForm.connHQ);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@CpNum", SqlDbType.NVarChar).Value = txtCouponNum.Text.Trim().ToUpper().ToString();
                SqlParameter CheckNum_Param = cmd.Parameters.Add("@CheckNum", SqlDbType.Int);
                CheckNum_Param.Direction = ParameterDirection.Output;

                parentForm.connHQ.Open();
                cmd.ExecuteNonQuery();
                parentForm.connHQ.Close();

                if (Convert.ToInt16(cmd.Parameters["@CheckNum"].Value) == 1)
                {
                    
                }
                else
                {
                }
            }
        }
    }
}