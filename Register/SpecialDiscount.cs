// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 04-28-2011
// ***********************************************************************
// <copyright file="SpecialDiscount.cs" company="Beauty4u">
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

/// <summary>
/// The Register namespace.
/// </summary>
namespace Register
{
    /// <summary>
    /// Class SpecialDiscount.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class SpecialDiscount : Form
    {
        /// <summary>
        /// The parent form
        /// </summary>
        public MainForm parentForm;
        /// <summary>
        /// The row count
        /// </summary>
        int rowCount = 0;
        /// <summary>
        /// The money off
        /// </summary>
        double moneyOff = 0;
        /// <summary>
        /// The discount price
        /// </summary>
        double discountPrice = 0;
        /// <summary>
        /// The final price
        /// </summary>
        double finalPrice = 0;
        /// <summary>
        /// The price
        /// </summary>
        double price = 0;
        /// <summary>
        /// The qty
        /// </summary>
        int qty = 0;

        /// <summary>
        /// The line input
        /// </summary>
        double lineInput = 0;
        /// <summary>
        /// The d price
        /// </summary>
        double dPrice = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpecialDiscount"/> class.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        public SpecialDiscount(int i, string j)
        {
            InitializeComponent();
            rowCount = i;
            discountPrice = Convert.ToDouble(j);
        }

        /// <summary>
        /// Handles the Load event of the SpecialDiscount control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SpecialDiscount_Load(object sender, EventArgs e)
        {
            lblDiscountPrice.Text = string.Format("{0:$0.00}", discountPrice);
            lblFinalPrice.Text = lblDiscountPrice.Text;
            txtMoneyOff.Select();
            txtMoneyOff.Focus();
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            finalPrice = Convert.ToDouble(lblFinalPrice.Text.Substring(1));

            if (finalPrice >= 0 & finalPrice < discountPrice)
            {
                qty = Convert.ToInt16(parentForm.dataGridView1.Rows[rowCount].Cells[2].Value);
                price = qty * Math.Round(finalPrice, 2, MidpointRounding.AwayFromZero);
                parentForm.dataGridView1.Rows[rowCount].Cells[4].Value = Math.Round(finalPrice, 2, MidpointRounding.AwayFromZero);
                parentForm.dataGridView1.Rows[rowCount].Cells[5].Value = price;
                parentForm.dataGridView1.Rows[rowCount].Cells[6].Value = Math.Round(price * parentForm.storeTaxRate, 2, MidpointRounding.AwayFromZero);

                parentForm.Calculation();
                parentForm.Calculating_Saved_Amount();

                parentForm.Enabled = true;
                this.Close();
                parentForm.richTxtUpc.Select();
                parentForm.richTxtUpc.Focus();
            }
            else
            {
                MyMessageBox.ShowBox("DISCOUNT ERROR", "ERROR");
                //MessageBox.Show("Discount error", "Error");
                return;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnLineOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnLineOK_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtLine.Text, out lineInput))
            {
                if (lineInput > 100)
                {
                    MyMessageBox.ShowBox("OVER DISCOUNT", "ERROR");
                    txtLine.SelectAll();
                    txtLine.Focus();
                }
                else
                {
                    dPrice = Convert.ToDouble(parentForm.dataGridView1.Rows[rowCount].Cells[4].Value);

                    if (dPrice == 16.99 | dPrice == 17.99 | dPrice == 18.99 | dPrice == 19.99)
                    {
                        dPrice = dPrice + 0.01;
                    }

                    qty = Convert.ToInt16(parentForm.dataGridView1.Rows[rowCount].Cells[2].Value);
                    finalPrice = dPrice * (1 - (lineInput / 100.00));
                    price = qty * Math.Round(finalPrice, 2, MidpointRounding.AwayFromZero);
                    parentForm.dataGridView1.Rows[rowCount].Cells[4].Value = Math.Round(finalPrice, 2, MidpointRounding.AwayFromZero);
                    parentForm.dataGridView1.Rows[rowCount].Cells[5].Value = price;
                    parentForm.dataGridView1.Rows[rowCount].Cells[6].Value = Math.Round(price * parentForm.storeTaxRate, 2, MidpointRounding.AwayFromZero);

                    parentForm.Calculation();
                    parentForm.Calculating_Saved_Amount();

                    parentForm.Enabled = true;
                    this.Close();
                    parentForm.richTxtUpc.Select();
                    parentForm.richTxtUpc.Focus();
                }
            }
            else
            {
                MyMessageBox.ShowBox("INVALID AMOUNT", "ERROR");
                txtLine.SelectAll();
                txtLine.Focus();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnTotalOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnTotalOK_Click(object sender, EventArgs e)
        {
        }

        /*private void Calculation()
        {
            double subTotal = 0;
            double tax = 0;
            for (int i = 0; i < parentForm.dataGridView1.RowCount; i++)
            {
                subTotal = subTotal + Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[5].Value);
                //tax = tax + Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[6].Value);
            }
            tax = Math.Round(subTotal * parentForm.storeTaxRate, 2, MidpointRounding.AwayFromZero);
            double grandTotal = subTotal + tax;
            parentForm.lblSubTotal.Text = string.Format("{0:$0.00}", subTotal);
            parentForm.lblTax.Text = string.Format("{0:$0.00}", tax);
            parentForm.lblGrandTotal.Text = string.Format("{0:$0.00}", grandTotal);

            discountPrice = 0;
            price = 0;
            parentForm.Display_Item_Price(0);
            parentForm.richTxtUpc.Focus();
            parentForm.richTxtUpc.Select();
        }*/

        /// <summary>
        /// Handles the TextChanged event of the txtMoneyOff control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtMoneyOff_TextChanged(object sender, EventArgs e)
        {
            if (txtMoneyOff.Text == "")
            {
                lblFinalPrice.Text = lblDiscountPrice.Text;
            }
            else
            {
                if (double.TryParse(txtMoneyOff.Text, out moneyOff))
                {
                    finalPrice = discountPrice - moneyOff;

                    if (finalPrice >= 0)
                    {
                        lblFinalPrice.Text = string.Format("{0:$0.00}", finalPrice);
                    }
                    else
                    {
                        MyMessageBox.ShowBox("DISCOUNT EXCEEDED", "ERROR");
                        //MessageBox.Show("Your discount exceed the basic price", "Error");
                        txtMoneyOff.SelectAll();
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnclose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnclose_Click(object sender, EventArgs e)
        {
            parentForm.Enabled = true;
            this.Close();
            parentForm.richTxtUpc.Select();
            parentForm.richTxtUpc.Focus();
        }
    }
}