// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 02-05-2018
// ***********************************************************************
// <copyright file="Discount.cs" company="Beauty4u">
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
    /// Class Discount.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class Discount : Form
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
        /// The basic price
        /// </summary>
        double basicPrice = 0;
        /// <summary>
        /// The money off
        /// </summary>
        double moneyOff = 0;
        /// <summary>
        /// The money off qty
        /// </summary>
        int moneyOffQty = 0;
        /// <summary>
        /// The discount price
        /// </summary>
        double discountPrice = 0;
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
        /// The total input
        /// </summary>
        double totalInput = 0;
        /// <summary>
        /// The b price
        /// </summary>
        double bPrice = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Discount"/> class.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <param name="k">The k.</param>
        public Discount(int i, string j, int k)
        {
            InitializeComponent();
            rowCount = i;
            basicPrice = Convert.ToDouble(j);

            if (k == 1)
            {
                btnLine20.Enabled = false;
                btnTotal20.Enabled = false;
                btnLine30.Enabled = false;
                btnTotal30.Enabled = false;

                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the Load event of the Discount control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Discount_Load(object sender, EventArgs e)
        {
            moneyOffQty = Convert.ToInt16(parentForm.dataGridView1.Rows[rowCount].Cells[2].Value);
            lblQty.Text = Convert.ToString(moneyOffQty);
            lblBasicPrice.Text = string.Format("{0:$0.00}", basicPrice);
            lblDiscountPrice.Text = lblBasicPrice.Text;
            txtMoneyOff.Select();
            txtMoneyOff.Focus();        
        }

        /// <summary>
        /// Handles the Click event of the btnLine5 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnLine5_Click(object sender, EventArgs e)
        {
            if(Convert.ToDouble(parentForm.dataGridView1.Rows[rowCount].Cells[4].Value) > 0)
            {
                MyMessageBox.ShowBox("DISCOUNTED ALREADY", "ERROR");
                return;
            }
            else if (Convert.ToBoolean(parentForm.dataGridView1.Rows[rowCount].Cells[21].Value) == true)
            {
                MyMessageBox.ShowBox("DISCOUNTED ALREADY (BUY 1 GET 1 FREE)", "ERROR");
                return;
            }
            else if (Convert.ToDouble(parentForm.dataGridView1.Rows[rowCount].Cells[3].Value) > 0)
            {
                qty = Convert.ToInt16(parentForm.dataGridView1.Rows[rowCount].Cells[2].Value);
                discountPrice = Convert.ToDouble(parentForm.dataGridView1.Rows[rowCount].Cells[3].Value) * 0.95;
                price = qty * Math.Round(discountPrice, 2, MidpointRounding.AwayFromZero);
                parentForm.dataGridView1.Rows[rowCount].Cells[4].Value = Math.Round(discountPrice, 2, MidpointRounding.AwayFromZero);
                parentForm.dataGridView1.Rows[rowCount].Cells[5].Value = price;
                parentForm.dataGridView1.Rows[rowCount].Cells[6].Value = Math.Round(price * parentForm.storeTaxRate, 2, MidpointRounding.AwayFromZero);

                parentForm.Calculation();
                parentForm.Calculating_Saved_Amount();
                parentForm.Display_Item_Price(0);

                this.Close();
                parentForm.Enabled = true;
                parentForm.richTxtUpc.Select();
                parentForm.richTxtUpc.Focus();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnLine10 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnLine10_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(parentForm.dataGridView1.Rows[rowCount].Cells[4].Value) > 0)
            {
                MyMessageBox.ShowBox("DISCOUNTED ALREADY", "ERROR");
                return;
            }
            else if (Convert.ToBoolean(parentForm.dataGridView1.Rows[rowCount].Cells[21].Value) == true)
            {
                MyMessageBox.ShowBox("DISCOUNTED ALREADY (BUY 1 GET 1 FREE)", "ERROR");
                return;
            }
            else if (Convert.ToDouble(parentForm.dataGridView1.Rows[rowCount].Cells[3].Value) > 0)
            {
                qty = Convert.ToInt16(parentForm.dataGridView1.Rows[rowCount].Cells[2].Value);
                discountPrice = Convert.ToDouble(parentForm.dataGridView1.Rows[rowCount].Cells[3].Value) * 0.9;
                price = qty * Math.Round(discountPrice, 2, MidpointRounding.AwayFromZero);
                parentForm.dataGridView1.Rows[rowCount].Cells[4].Value = Math.Round(discountPrice, 2, MidpointRounding.AwayFromZero);
                parentForm.dataGridView1.Rows[rowCount].Cells[5].Value = price;
                parentForm.dataGridView1.Rows[rowCount].Cells[6].Value = Math.Round(price * parentForm.storeTaxRate, 2, MidpointRounding.AwayFromZero);

                parentForm.Calculation();
                parentForm.Calculating_Saved_Amount();
                parentForm.Display_Item_Price(0);

                this.Close();
                parentForm.Enabled = true;
                parentForm.richTxtUpc.Select();
                parentForm.richTxtUpc.Focus();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnLine20 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnLine20_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(parentForm.dataGridView1.Rows[rowCount].Cells[4].Value) > 0)
            {
                MyMessageBox.ShowBox("DISCOUNTED ALREADY", "ERROR");
                return;
            }
            else if (Convert.ToBoolean(parentForm.dataGridView1.Rows[rowCount].Cells[21].Value) == true)
            {
                MyMessageBox.ShowBox("DISCOUNTED ALREADY (BUY 1 GET 1 FREE)", "ERROR");
                return;
            }
            else if (Convert.ToDouble(parentForm.dataGridView1.Rows[rowCount].Cells[3].Value) > 0)
            {
                qty = Convert.ToInt16(parentForm.dataGridView1.Rows[rowCount].Cells[2].Value);
                discountPrice = Convert.ToDouble(parentForm.dataGridView1.Rows[rowCount].Cells[3].Value) * 0.8;
                price = qty * Math.Round(discountPrice, 2, MidpointRounding.AwayFromZero);
                parentForm.dataGridView1.Rows[rowCount].Cells[4].Value = Math.Round(discountPrice, 2, MidpointRounding.AwayFromZero);
                parentForm.dataGridView1.Rows[rowCount].Cells[5].Value = price;
                parentForm.dataGridView1.Rows[rowCount].Cells[6].Value = Math.Round(price * parentForm.storeTaxRate, 2, MidpointRounding.AwayFromZero);

                parentForm.Calculation();
                parentForm.Calculating_Saved_Amount();
                parentForm.Display_Item_Price(0);

                this.Close();
                parentForm.Enabled = true;
                parentForm.richTxtUpc.Select();
                parentForm.richTxtUpc.Focus();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnLine30 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnLine30_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(parentForm.dataGridView1.Rows[rowCount].Cells[4].Value) > 0)
            {
                MyMessageBox.ShowBox("DISCOUNTED ALREADY", "ERROR");
                return;
            }
            else if (Convert.ToBoolean(parentForm.dataGridView1.Rows[rowCount].Cells[21].Value) == true)
            {
                MyMessageBox.ShowBox("DISCOUNTED ALREADY (BUY 1 GET 1 FREE)", "ERROR");
                return;
            }
            else if (Convert.ToDouble(parentForm.dataGridView1.Rows[rowCount].Cells[3].Value) > 0)
            {
                qty = Convert.ToInt16(parentForm.dataGridView1.Rows[rowCount].Cells[2].Value);
                discountPrice = Convert.ToDouble(parentForm.dataGridView1.Rows[rowCount].Cells[3].Value) * 0.7;
                price = qty * Math.Round(discountPrice, 2, MidpointRounding.AwayFromZero);
                parentForm.dataGridView1.Rows[rowCount].Cells[4].Value = Math.Round(discountPrice, 2, MidpointRounding.AwayFromZero);
                parentForm.dataGridView1.Rows[rowCount].Cells[5].Value = price;
                parentForm.dataGridView1.Rows[rowCount].Cells[6].Value = Math.Round(price * parentForm.storeTaxRate, 2, MidpointRounding.AwayFromZero);

                parentForm.Calculation();
                parentForm.Calculating_Saved_Amount();
                parentForm.Display_Item_Price(0);

                this.Close();
                parentForm.Enabled = true;
                parentForm.richTxtUpc.Select();
                parentForm.richTxtUpc.Focus();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnTotal5 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnTotal5_Click(object sender, EventArgs e)
        {
            rowCount = parentForm.dataGridView1.RowCount;

            for (int i = 0; i < rowCount; i++)
            {
                if (Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[4].Value) > 0)
                {
                }
                else if (Convert.ToBoolean(parentForm.dataGridView1.Rows[i].Cells[21].Value) == true)
                {
                }
                else if (Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[4].Value) == 0 & Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[3].Value) > 0)
                {
                    qty = Convert.ToInt16(parentForm.dataGridView1.Rows[i].Cells[2].Value);
                    discountPrice = Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[3].Value) * 0.95;
                    price = qty * Math.Round(discountPrice, 2, MidpointRounding.AwayFromZero);
                    parentForm.dataGridView1.Rows[i].Cells[4].Value = Math.Round(discountPrice, 2, MidpointRounding.AwayFromZero);
                    parentForm.dataGridView1.Rows[i].Cells[5].Value = price;
                    parentForm.dataGridView1.Rows[i].Cells[6].Value = Math.Round(price * parentForm.storeTaxRate, 2, MidpointRounding.AwayFromZero);
                }
            }

            parentForm.Calculation();
            parentForm.Calculating_Saved_Amount();
            parentForm.Display_Item_Price(0);

            this.Close();
            parentForm.Enabled = true;
            parentForm.richTxtUpc.Select();
            parentForm.richTxtUpc.Focus();
        }

        /// <summary>
        /// Handles the Click event of the btnTotal10 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnTotal10_Click(object sender, EventArgs e)
        {
            rowCount = parentForm.dataGridView1.RowCount;

            for (int i = 0; i < rowCount; i++)
            {
                if (Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[4].Value) > 0)
                {
                }
                else if (Convert.ToBoolean(parentForm.dataGridView1.Rows[i].Cells[21].Value) == true)
                {
                }
                else if (Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[4].Value) == 0 & Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[3].Value) > 0)
                {
                    qty = Convert.ToInt16(parentForm.dataGridView1.Rows[i].Cells[2].Value);
                    discountPrice = Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[3].Value) * 0.9;
                    price = qty * Math.Round(discountPrice, 2, MidpointRounding.AwayFromZero);
                    parentForm.dataGridView1.Rows[i].Cells[4].Value = Math.Round(discountPrice, 2, MidpointRounding.AwayFromZero);
                    parentForm.dataGridView1.Rows[i].Cells[5].Value = price;
                    parentForm.dataGridView1.Rows[i].Cells[6].Value = Math.Round(price * parentForm.storeTaxRate, 2, MidpointRounding.AwayFromZero);
                }
            }

            parentForm.Calculation();
            parentForm.Calculating_Saved_Amount();
            parentForm.Display_Item_Price(0);

            this.Close();
            parentForm.Enabled = true;
            parentForm.richTxtUpc.Select();
            parentForm.richTxtUpc.Focus();
        }

        /// <summary>
        /// Handles the Click event of the btnTotal20 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnTotal20_Click(object sender, EventArgs e)
        {
            rowCount = parentForm.dataGridView1.RowCount;

            for (int i = 0; i < rowCount; i++)
            {
                if (Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[4].Value) > 0)
                {
                }
                else if (Convert.ToBoolean(parentForm.dataGridView1.Rows[i].Cells[21].Value) == true)
                {
                }
                else if (Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[4].Value) == 0 & Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[3].Value) > 0)
                {
                    qty = Convert.ToInt16(parentForm.dataGridView1.Rows[i].Cells[2].Value);
                    discountPrice = Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[3].Value) * 0.8;
                    price = qty * Math.Round(discountPrice, 2, MidpointRounding.AwayFromZero);
                    parentForm.dataGridView1.Rows[i].Cells[4].Value = Math.Round(discountPrice, 2, MidpointRounding.AwayFromZero);
                    parentForm.dataGridView1.Rows[i].Cells[5].Value = price;
                    parentForm.dataGridView1.Rows[i].Cells[6].Value = Math.Round(price * parentForm.storeTaxRate, 2, MidpointRounding.AwayFromZero);
                }
            }

            parentForm.Calculation();
            parentForm.Calculating_Saved_Amount();
            parentForm.Display_Item_Price(0);

            this.Close();
            parentForm.Enabled = true;
            parentForm.richTxtUpc.Select();
            parentForm.richTxtUpc.Focus();
        }

        /// <summary>
        /// Handles the Click event of the btnTotal30 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnTotal30_Click(object sender, EventArgs e)
        {
            rowCount = parentForm.dataGridView1.RowCount;

            for (int i = 0; i < rowCount; i++)
            {
                if (Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[4].Value) > 0)
                {
                }
                else if (Convert.ToBoolean(parentForm.dataGridView1.Rows[i].Cells[21].Value) == true)
                {
                }
                else if (Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[4].Value) == 0 & Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[3].Value) > 0)
                {
                    qty = Convert.ToInt16(parentForm.dataGridView1.Rows[i].Cells[2].Value);
                    discountPrice = Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[3].Value) * 0.7;
                    price = qty * Math.Round(discountPrice, 2, MidpointRounding.AwayFromZero);
                    parentForm.dataGridView1.Rows[i].Cells[4].Value = Math.Round(discountPrice, 2, MidpointRounding.AwayFromZero);
                    parentForm.dataGridView1.Rows[i].Cells[5].Value = price;
                    parentForm.dataGridView1.Rows[i].Cells[6].Value = Math.Round(price * parentForm.storeTaxRate, 2, MidpointRounding.AwayFromZero);
                }
            }

            parentForm.Calculation();
            parentForm.Calculating_Saved_Amount();
            parentForm.Display_Item_Price(0);

            this.Close();
            parentForm.Enabled = true;
            parentForm.richTxtUpc.Select();
            parentForm.richTxtUpc.Focus();
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            discountPrice = Convert.ToDouble(lblDiscountPrice.Text.Substring(1));

            if (discountPrice > 0 & discountPrice < basicPrice)
            {
                if (Convert.ToDouble(parentForm.dataGridView1.Rows[rowCount].Cells[4].Value) > 0)
                {
                    MyMessageBox.ShowBox("DISCOUNTED ALREADY", "ERROR");
                    return;
                }
                else if (Convert.ToBoolean(parentForm.dataGridView1.Rows[rowCount].Cells[21].Value) == true)
                {
                    MyMessageBox.ShowBox("DISCOUNTED ALREADY (BUY 1 GET 1 FREE)", "ERROR");
                    return;
                }
                else
                {
                    qty = Convert.ToInt16(parentForm.dataGridView1.Rows[rowCount].Cells[2].Value);
                    price = qty * Math.Round(discountPrice, 2, MidpointRounding.AwayFromZero);
                    //parentForm.dataGridView1.Rows[rowCount].Cells[4].Value = Math.Round(discountPrice / qty, 2, MidpointRounding.AwayFromZero);
                    parentForm.dataGridView1.Rows[rowCount].Cells[4].Value = discountPrice;
                    parentForm.dataGridView1.Rows[rowCount].Cells[5].Value = price;
                    //parentForm.dataGridView1.Rows[rowCount].Cells[5].Value = Math.Round(discountPrice, 2, MidpointRounding.AwayFromZero);
                    parentForm.dataGridView1.Rows[rowCount].Cells[6].Value = Math.Round(price * parentForm.storeTaxRate, 2, MidpointRounding.AwayFromZero);
                    //parentForm.dataGridView1.Rows[rowCount].Cells[6].Value = Math.Round(discountPrice * parentForm.storeTaxRate, 2, MidpointRounding.AwayFromZero);

                    parentForm.Calculation();
                    parentForm.Calculating_Saved_Amount();
                    parentForm.Display_Item_Price(0);

                    this.Close();
                    parentForm.Enabled = true;
                    parentForm.richTxtUpc.Select();
                    parentForm.richTxtUpc.Focus();
                }
            }
            else
            {
                MyMessageBox.ShowBox("DISCOUNT ERROR", "ERROR");
                return;
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the txtMoneyOff control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtMoneyOff_TextChanged(object sender, EventArgs e)
        {
            if (txtMoneyOff.Text == "")
            {
                lblDiscountPrice.Text = lblBasicPrice.Text;
            }
            else
            {
                if (double.TryParse(txtMoneyOff.Text, out moneyOff))
                {
                    discountPrice = basicPrice - Math.Round((moneyOff / moneyOffQty), 2, MidpointRounding.AwayFromZero);

                    if (discountPrice >= 0)
                    {
                        lblMoneyOff.Text = string.Format("{0:$0.00}", Math.Round((moneyOff / moneyOffQty), 2, MidpointRounding.AwayFromZero));
                        lblDiscountPrice.Text = string.Format("{0:$0.00}", discountPrice);
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
            this.Close();
            parentForm.Enabled = true;
            parentForm.richTxtUpc.Select();
            parentForm.richTxtUpc.Focus();
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
            parentForm.Display_Item_Price();
            parentForm.richTxtUpc.Focus();
            parentForm.richTxtUpc.Select();
        }*/

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
                    if (Convert.ToDouble(parentForm.dataGridView1.Rows[rowCount].Cells[4].Value) > 0)
                    {
                        MyMessageBox.ShowBox("DISCOUNTED ALREADY", "ERROR");
                        return;
                    }
                    else if (Convert.ToBoolean(parentForm.dataGridView1.Rows[rowCount].Cells[21].Value) == true)
                    {
                        MyMessageBox.ShowBox("DISCOUNTED ALREADY (BUY 1 GET 1 FREE)", "ERROR");
                        return;
                    }
                    else
                    {
                        bPrice = Convert.ToDouble(parentForm.dataGridView1.Rows[rowCount].Cells[3].Value);

                        if (bPrice == 16.99 | bPrice == 17.99 | bPrice == 18.99 | bPrice == 19.99)
                        {
                            bPrice = bPrice + 0.01;
                        }

                        qty = Convert.ToInt16(parentForm.dataGridView1.Rows[rowCount].Cells[2].Value);
                        discountPrice = bPrice * (1 - (lineInput / 100.00));
                        price = qty * Math.Round(discountPrice, 2, MidpointRounding.AwayFromZero);
                        parentForm.dataGridView1.Rows[rowCount].Cells[4].Value = Math.Round(discountPrice, 2, MidpointRounding.AwayFromZero);
                        parentForm.dataGridView1.Rows[rowCount].Cells[5].Value = price;
                        parentForm.dataGridView1.Rows[rowCount].Cells[6].Value = Math.Round(price * parentForm.storeTaxRate, 2, MidpointRounding.AwayFromZero);

                        parentForm.Calculation();
                        parentForm.Calculating_Saved_Amount();
                        parentForm.Display_Item_Price(0);

                        this.Close();
                        parentForm.Enabled = true;
                        parentForm.richTxtUpc.Select();
                        parentForm.richTxtUpc.Focus();
                    }
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
            if (double.TryParse(txtTotal.Text, out totalInput))
            {
                if (totalInput > 100)
                {
                    MyMessageBox.ShowBox("OVER DISCOUNT", "ERROR");
                    txtTotal.SelectAll();
                    txtTotal.Focus();
                }
                else
                {
                    rowCount = parentForm.dataGridView1.RowCount;

                    for (int i = 0; i < rowCount; i++)
                    {
                        if (Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[4].Value) > 0)
                        {
                        }
                        else if (Convert.ToBoolean(parentForm.dataGridView1.Rows[i].Cells[21].Value) == true)
                        {
                        }
                        else if (Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[4].Value) == 0)
                        {
                            bPrice = Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[3].Value);

                            if (bPrice == 16.99 | bPrice == 17.99 | bPrice == 18.99 | bPrice == 19.99)
                            {
                                bPrice = bPrice + 0.01;
                            }

                            qty = Convert.ToInt16(parentForm.dataGridView1.Rows[i].Cells[2].Value);
                            //discountPrice = Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[3].Value) * (1 - (totalInput / 100));
                            discountPrice = bPrice * (1 - (totalInput / 100.00));
                            price = qty * Math.Round(discountPrice, 2, MidpointRounding.AwayFromZero);
                            parentForm.dataGridView1.Rows[i].Cells[4].Value = Math.Round(discountPrice, 2, MidpointRounding.AwayFromZero);
                            parentForm.dataGridView1.Rows[i].Cells[5].Value = price;
                            parentForm.dataGridView1.Rows[i].Cells[6].Value = Math.Round(price * parentForm.storeTaxRate, 2, MidpointRounding.AwayFromZero);
                        }
                    }

                    parentForm.Calculation();
                    parentForm.Calculating_Saved_Amount();
                    parentForm.Display_Item_Price(0);

                    this.Close();
                    parentForm.Enabled = true;
                    parentForm.richTxtUpc.Select();
                    parentForm.richTxtUpc.Focus();
                }
            }
            else
            {
                MyMessageBox.ShowBox("INVALID AMOUNT", "ERROR");
                txtTotal.SelectAll();
                txtTotal.Focus();
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the radioBtnLine control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void radioBtnLine_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnLine.Checked == true)
            {
                txtLine.Clear();
                txtTotal.Clear();

                txtLine.Enabled = true;
                txtLine.Focus();
            }
            else
            {
                txtLine.Clear();
                txtTotal.Clear();

                txtLine.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the radioBtnTotal control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void radioBtnTotal_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnTotal.Checked == true)
            {
                txtLine.Clear();
                txtTotal.Clear();

                txtTotal.Enabled = true;
                txtTotal.Focus();
            }
            else
            {
                txtLine.Clear();
                txtTotal.Clear();

                txtTotal.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the Click event of the txtLine control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtLine_Click(object sender, EventArgs e)
        {
            radioBtnLine.Checked = true;
            txtLine.SelectAll();
            txtLine.Focus();
        }

        /// <summary>
        /// Handles the Click event of the txtTotal control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtTotal_Click(object sender, EventArgs e)
        {
            radioBtnTotal.Checked = true;
            txtTotal.SelectAll();
            txtTotal.Focus();
        }

        /// <summary>
        /// Handles the MouseClick event of the txtMoneyOff control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void txtMoneyOff_MouseClick(object sender, MouseEventArgs e)
        {
            txtMoneyOff.SelectAll();
            txtMoneyOff.Focus();
        }

        /// <summary>
        /// Handles the Click event of the btnSocialMediaDiscount control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnSocialMediaDiscount_Click(object sender, EventArgs e)
        {
            if (parentForm.smDiscount == false)
            {
                InputCashierID inputCashierForm = new InputCashierID(0);
                inputCashierForm.parentForm1 = this.parentForm;
                inputCashierForm.parentForm2 = this;
                inputCashierForm.ShowDialog();
            }
            else
            {
                rowCount = parentForm.dataGridView1.RowCount;

                for (int i = 0; i < rowCount; i++)
                {
                    if (Convert.ToString(parentForm.dataGridView1.Rows[i].Cells[7].Value) == "B4UGIFTCARD1" | Convert.ToString(parentForm.dataGridView1.Rows[i].Cells[7].Value) == "B4UGIFTCARD2" | Convert.ToString(parentForm.dataGridView1.Rows[i].Cells[7].Value) == "B4UGIFTCARD3")
                    {
                    }
                    else if (Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[4].Value) == 0 & Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[3].Value) > 0)
                    {
                        qty = Convert.ToInt16(parentForm.dataGridView1.Rows[i].Cells[2].Value);
                        discountPrice = Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[3].Value) * 0.95;
                        price = qty * Math.Round(discountPrice, 2, MidpointRounding.AwayFromZero);
                        parentForm.dataGridView1.Rows[i].Cells[4].Value = Math.Round(discountPrice, 2, MidpointRounding.AwayFromZero);
                        parentForm.dataGridView1.Rows[i].Cells[5].Value = price;
                        parentForm.dataGridView1.Rows[i].Cells[6].Value = Math.Round(price * parentForm.storeTaxRate, 2, MidpointRounding.AwayFromZero);
                    }
                }

                parentForm.Calculation();
                parentForm.Calculating_Saved_Amount();
                parentForm.Display_Item_Price(0);

                this.Close();
                parentForm.Enabled = true;
                parentForm.richTxtUpc.Select();
                parentForm.richTxtUpc.Focus();
            }
        }

        /// <summary>
        /// Handles the Click event of the btn25OFF control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btn25OFF_Click(object sender, EventArgs e)
        {
            if (parentForm.lblMemberCode.Text == "101" | parentForm.lblName.Text == "WALK INS")
            {
                MyMessageBox.ShowBox("MEMBERSHIP REQUIRED", "ERROR");
                return;
            }

            if (parentForm.calSubTotal >= 50)
            {
                if (parentForm.eDiscount1 == false)
                {
                    InputCashierID inputCashierForm = new InputCashierID(1);
                    inputCashierForm.parentForm1 = this.parentForm;
                    inputCashierForm.parentForm2 = this;
                    inputCashierForm.ShowDialog();
                }
                else
                {
                    rowCount = parentForm.dataGridView1.RowCount;

                    for (int i = 0; i < rowCount; i++)
                    {
                        if (Convert.ToString(parentForm.dataGridView1.Rows[i].Cells[7].Value) == "B4UGIFTCARD1" | Convert.ToString(parentForm.dataGridView1.Rows[i].Cells[7].Value) == "B4UGIFTCARD2" | Convert.ToString(parentForm.dataGridView1.Rows[i].Cells[7].Value) == "B4UGIFTCARD3")
                        {
                        }
                        else if (Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[4].Value) == 0 & Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[3].Value) > 0)
                        {
                            qty = Convert.ToInt16(parentForm.dataGridView1.Rows[i].Cells[2].Value);
                            discountPrice = Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[3].Value) * 0.75;
                            price = qty * Math.Round(discountPrice, 2, MidpointRounding.AwayFromZero);
                            parentForm.dataGridView1.Rows[i].Cells[4].Value = Math.Round(discountPrice, 2, MidpointRounding.AwayFromZero);
                            parentForm.dataGridView1.Rows[i].Cells[5].Value = price;
                            parentForm.dataGridView1.Rows[i].Cells[6].Value = Math.Round(price * parentForm.storeTaxRate, 2, MidpointRounding.AwayFromZero);
                        }
                    }

                    parentForm.Calculation();
                    parentForm.Calculating_Saved_Amount();
                    parentForm.Display_Item_Price(0);

                    this.Close();
                    parentForm.Enabled = true;
                    parentForm.richTxtUpc.Select();
                    parentForm.richTxtUpc.Focus();
                }
            }
            else
            {
                MyMessageBox.ShowBox("SUBTOTAL MUST EQUAL $5O OR MORE", "ERROR");
                return;
            }
        }
    }
}