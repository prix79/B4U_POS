// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 12-12-2014
// ***********************************************************************
// <copyright file="NoBarcodeItem.cs" company="Beauty4u">
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
    /// Class NoBarcodeItem.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class NoBarcodeItem : Form
    {
        /// <summary>
        /// The parent form
        /// </summary>
        public MainForm parentForm;
        //string price = "";
        //string temp = string.Empty;
        //int priceLen = 0;

        /// <summary>
        /// The temporary pay
        /// </summary>
        string tempPay = string.Empty;
        /// <summary>
        /// The string length
        /// </summary>
        int strLen = 0;
        /// <summary>
        /// The n dot
        /// </summary>
        int nDot = 0;
        /// <summary>
        /// The i
        /// </summary>
        /// <summary>
        /// The j
        /// </summary>
        /// <summary>
        /// The k
        /// </summary>
        int i, j, k;
        /// <summary>
        /// The dot array
        /// </summary>
        string[] dotArray = new string[20];
        /// <summary>
        /// The zero array
        /// </summary>
        string[] zeroArray = new string[20];
        /// <summary>
        /// The n itm price
        /// </summary>
        double nItmPrice;

        /// <summary>
        /// The gc code
        /// </summary>
        public string gcCode;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoBarcodeItem"/> class.
        /// </summary>
        public NoBarcodeItem()
        {
            InitializeComponent();
            /*price = ItmPrice;
            priceLen = price.Length;
            switch (priceLen)
            {
                case 0:
                    price = "0";
                    break;
                case 1:
                    temp = price;
                    price = "0.0" + price;
                    break;
                case 2:
                    temp = price;
                    price = "0." + price;
                    break;
                default:
                    price = price.Insert(priceLen - 2, ".");
                    break;
            }*/
        }

        /// <summary>
        /// Handles the Click event of the button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (richtxtPrice.Text == "")
            {
                richtxtPrice.Text = "0.00";

                tempPay = richtxtPrice.Text;
                richtxtPrice.Text = tempPay + "1";
                strLen = richtxtPrice.Text.Trim().Length;
                richtxtPrice.Text = richtxtPrice.Text.Remove(strLen - 4, 1);
                nDot = strLen - 3;
                richtxtPrice.Text = richtxtPrice.Text.Insert(nDot, ".");
                string a = richtxtPrice.Text.Substring(0, 1);
                if (a == "0")
                {
                    richtxtPrice.Text = richtxtPrice.Text.Remove(0, 1);
                }
                tempPay = string.Empty;
            }
            else
            {
                tempPay = richtxtPrice.Text;
                richtxtPrice.Text = tempPay + "1";
                strLen = richtxtPrice.Text.Trim().Length;
                richtxtPrice.Text = richtxtPrice.Text.Remove(strLen - 4, 1);
                nDot = strLen - 3;
                richtxtPrice.Text = richtxtPrice.Text.Insert(nDot, ".");
                string a = richtxtPrice.Text.Substring(0, 1);
                if (a == "0")
                {
                    richtxtPrice.Text = richtxtPrice.Text.Remove(0, 1);
                }
                tempPay = string.Empty;
            }
        }

        /// <summary>
        /// Handles the Click event of the button2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (richtxtPrice.Text == "")
            {
                richtxtPrice.Text = "0.00";

                tempPay = richtxtPrice.Text;
                richtxtPrice.Text = tempPay + "2";
                strLen = richtxtPrice.Text.Trim().Length;
                richtxtPrice.Text = richtxtPrice.Text.Remove(strLen - 4, 1);
                nDot = strLen - 3;
                richtxtPrice.Text = richtxtPrice.Text.Insert(nDot, ".");
                string a = richtxtPrice.Text.Substring(0, 1);
                if (a == "0")
                {
                    richtxtPrice.Text = richtxtPrice.Text.Remove(0, 1);
                }
                tempPay = string.Empty;
            }
            else
            {
                tempPay = richtxtPrice.Text;
                richtxtPrice.Text = tempPay + "2";
                strLen = richtxtPrice.Text.Trim().Length;
                richtxtPrice.Text = richtxtPrice.Text.Remove(strLen - 4, 1);
                nDot = strLen - 3;
                richtxtPrice.Text = richtxtPrice.Text.Insert(nDot, ".");
                string a = richtxtPrice.Text.Substring(0, 1);
                if (a == "0")
                {
                    richtxtPrice.Text = richtxtPrice.Text.Remove(0, 1);
                }
                tempPay = string.Empty;
            }
        }

        /// <summary>
        /// Handles the Click event of the button3 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (richtxtPrice.Text == "")
            {
                richtxtPrice.Text = "0.00";

                tempPay = richtxtPrice.Text;
                richtxtPrice.Text = tempPay + "3";
                strLen = richtxtPrice.Text.Trim().Length;
                richtxtPrice.Text = richtxtPrice.Text.Remove(strLen - 4, 1);
                nDot = strLen - 3;
                richtxtPrice.Text = richtxtPrice.Text.Insert(nDot, ".");
                string a = richtxtPrice.Text.Substring(0, 1);
                if (a == "0")
                {
                    richtxtPrice.Text = richtxtPrice.Text.Remove(0, 1);
                }
                tempPay = string.Empty;
            }
            else
            {
                tempPay = richtxtPrice.Text;
                richtxtPrice.Text = tempPay + "3";
                strLen = richtxtPrice.Text.Trim().Length;
                richtxtPrice.Text = richtxtPrice.Text.Remove(strLen - 4, 1);
                nDot = strLen - 3;
                richtxtPrice.Text = richtxtPrice.Text.Insert(nDot, ".");
                string a = richtxtPrice.Text.Substring(0, 1);
                if (a == "0")
                {
                    richtxtPrice.Text = richtxtPrice.Text.Remove(0, 1);
                }
                tempPay = string.Empty;
            }
        }

        /// <summary>
        /// Handles the Click event of the button4 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (richtxtPrice.Text == "")
            {
                richtxtPrice.Text = "0.00";

                tempPay = richtxtPrice.Text;
                richtxtPrice.Text = tempPay + "4";
                strLen = richtxtPrice.Text.Trim().Length;
                richtxtPrice.Text = richtxtPrice.Text.Remove(strLen - 4, 1);
                nDot = strLen - 3;
                richtxtPrice.Text = richtxtPrice.Text.Insert(nDot, ".");
                string a = richtxtPrice.Text.Substring(0, 1);
                if (a == "0")
                {
                    richtxtPrice.Text = richtxtPrice.Text.Remove(0, 1);
                }
                tempPay = string.Empty;
            }
            else
            {
                tempPay = richtxtPrice.Text;
                richtxtPrice.Text = tempPay + "4";
                strLen = richtxtPrice.Text.Trim().Length;
                richtxtPrice.Text = richtxtPrice.Text.Remove(strLen - 4, 1);
                nDot = strLen - 3;
                richtxtPrice.Text = richtxtPrice.Text.Insert(nDot, ".");
                string a = richtxtPrice.Text.Substring(0, 1);
                if (a == "0")
                {
                    richtxtPrice.Text = richtxtPrice.Text.Remove(0, 1);
                }
                tempPay = string.Empty;
            }
        }

        /// <summary>
        /// Handles the Click event of the button5 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button5_Click(object sender, EventArgs e)
        {
            if (richtxtPrice.Text == "")
            {
                richtxtPrice.Text = "0.00";

                tempPay = richtxtPrice.Text;
                richtxtPrice.Text = tempPay + "5";
                strLen = richtxtPrice.Text.Trim().Length;
                richtxtPrice.Text = richtxtPrice.Text.Remove(strLen - 4, 1);
                nDot = strLen - 3;
                richtxtPrice.Text = richtxtPrice.Text.Insert(nDot, ".");
                string a = richtxtPrice.Text.Substring(0, 1);
                if (a == "0")
                {
                    richtxtPrice.Text = richtxtPrice.Text.Remove(0, 1);
                }
                tempPay = string.Empty;
            }
            else
            {
                tempPay = richtxtPrice.Text;
                richtxtPrice.Text = tempPay + "5";
                strLen = richtxtPrice.Text.Trim().Length;
                richtxtPrice.Text = richtxtPrice.Text.Remove(strLen - 4, 1);
                nDot = strLen - 3;
                richtxtPrice.Text = richtxtPrice.Text.Insert(nDot, ".");
                string a = richtxtPrice.Text.Substring(0, 1);
                if (a == "0")
                {
                    richtxtPrice.Text = richtxtPrice.Text.Remove(0, 1);
                }
                tempPay = string.Empty;
            }
        }

        /// <summary>
        /// Handles the Click event of the button6 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button6_Click(object sender, EventArgs e)
        {
            if (richtxtPrice.Text == "")
            {
                richtxtPrice.Text = "0.00";

                tempPay = richtxtPrice.Text;
                richtxtPrice.Text = tempPay + "6";
                strLen = richtxtPrice.Text.Trim().Length;
                richtxtPrice.Text = richtxtPrice.Text.Remove(strLen - 4, 1);
                nDot = strLen - 3;
                richtxtPrice.Text = richtxtPrice.Text.Insert(nDot, ".");
                string a = richtxtPrice.Text.Substring(0, 1);
                if (a == "0")
                {
                    richtxtPrice.Text = richtxtPrice.Text.Remove(0, 1);
                }
                tempPay = string.Empty;
            }
            else
            {
                tempPay = richtxtPrice.Text;
                richtxtPrice.Text = tempPay + "6";
                strLen = richtxtPrice.Text.Trim().Length;
                richtxtPrice.Text = richtxtPrice.Text.Remove(strLen - 4, 1);
                nDot = strLen - 3;
                richtxtPrice.Text = richtxtPrice.Text.Insert(nDot, ".");
                string a = richtxtPrice.Text.Substring(0, 1);
                if (a == "0")
                {
                    richtxtPrice.Text = richtxtPrice.Text.Remove(0, 1);
                }
                tempPay = string.Empty;
            }
        }

        /// <summary>
        /// Handles the Click event of the button7 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button7_Click(object sender, EventArgs e)
        {
            if (richtxtPrice.Text == "")
            {
                richtxtPrice.Text = "0.00";

                tempPay = richtxtPrice.Text;
                richtxtPrice.Text = tempPay + "7";
                strLen = richtxtPrice.Text.Trim().Length;
                richtxtPrice.Text = richtxtPrice.Text.Remove(strLen - 4, 1);
                nDot = strLen - 3;
                richtxtPrice.Text = richtxtPrice.Text.Insert(nDot, ".");
                string a = richtxtPrice.Text.Substring(0, 1);
                if (a == "0")
                {
                    richtxtPrice.Text = richtxtPrice.Text.Remove(0, 1);
                }
                tempPay = string.Empty;
            }
            else
            {
                tempPay = richtxtPrice.Text;
                richtxtPrice.Text = tempPay + "7";
                strLen = richtxtPrice.Text.Trim().Length;
                richtxtPrice.Text = richtxtPrice.Text.Remove(strLen - 4, 1);
                nDot = strLen - 3;
                richtxtPrice.Text = richtxtPrice.Text.Insert(nDot, ".");
                string a = richtxtPrice.Text.Substring(0, 1);
                if (a == "0")
                {
                    richtxtPrice.Text = richtxtPrice.Text.Remove(0, 1);
                }
                tempPay = string.Empty;
            }
        }

        /// <summary>
        /// Handles the Click event of the button8 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button8_Click(object sender, EventArgs e)
        {
            if (richtxtPrice.Text == "")
            {
                richtxtPrice.Text = "0.00";

                tempPay = richtxtPrice.Text;
                richtxtPrice.Text = tempPay + "8";
                strLen = richtxtPrice.Text.Trim().Length;
                richtxtPrice.Text = richtxtPrice.Text.Remove(strLen - 4, 1);
                nDot = strLen - 3;
                richtxtPrice.Text = richtxtPrice.Text.Insert(nDot, ".");
                string a = richtxtPrice.Text.Substring(0, 1);
                if (a == "0")
                {
                    richtxtPrice.Text = richtxtPrice.Text.Remove(0, 1);
                }
                tempPay = string.Empty;
            }
            else
            {
                tempPay = richtxtPrice.Text;
                richtxtPrice.Text = tempPay + "8";
                strLen = richtxtPrice.Text.Trim().Length;
                richtxtPrice.Text = richtxtPrice.Text.Remove(strLen - 4, 1);
                nDot = strLen - 3;
                richtxtPrice.Text = richtxtPrice.Text.Insert(nDot, ".");
                string a = richtxtPrice.Text.Substring(0, 1);
                if (a == "0")
                {
                    richtxtPrice.Text = richtxtPrice.Text.Remove(0, 1);
                }
                tempPay = string.Empty;
            }
        }

        /// <summary>
        /// Handles the Click event of the button9 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button9_Click(object sender, EventArgs e)
        {
            if (richtxtPrice.Text == "")
            {
                richtxtPrice.Text = "0.00";

                tempPay = richtxtPrice.Text;
                richtxtPrice.Text = tempPay + "9";
                strLen = richtxtPrice.Text.Trim().Length;
                richtxtPrice.Text = richtxtPrice.Text.Remove(strLen - 4, 1);
                nDot = strLen - 3;
                richtxtPrice.Text = richtxtPrice.Text.Insert(nDot, ".");
                string a = richtxtPrice.Text.Substring(0, 1);
                if (a == "0")
                {
                    richtxtPrice.Text = richtxtPrice.Text.Remove(0, 1);
                }
                tempPay = string.Empty;
            }
            else
            {
                tempPay = richtxtPrice.Text;
                richtxtPrice.Text = tempPay + "9";
                strLen = richtxtPrice.Text.Trim().Length;
                richtxtPrice.Text = richtxtPrice.Text.Remove(strLen - 4, 1);
                nDot = strLen - 3;
                richtxtPrice.Text = richtxtPrice.Text.Insert(nDot, ".");
                string a = richtxtPrice.Text.Substring(0, 1);
                if (a == "0")
                {
                    richtxtPrice.Text = richtxtPrice.Text.Remove(0, 1);
                }
                tempPay = string.Empty;
            }
        }

        /// <summary>
        /// Handles the Click event of the button0 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button0_Click(object sender, EventArgs e)
        {
            if (richtxtPrice.Text == "")
            {
                richtxtPrice.Select();
                richtxtPrice.Focus();
            }
            else
            {
                tempPay = richtxtPrice.Text;
                richtxtPrice.Text = tempPay + "0";
                strLen = richtxtPrice.Text.Trim().Length;
                richtxtPrice.Text = richtxtPrice.Text.Remove(strLen - 4, 1);
                nDot = strLen - 3;
                richtxtPrice.Text = richtxtPrice.Text.Insert(nDot, ".");
                string a = richtxtPrice.Text.Substring(0, 1);
                if (a == "0")
                {
                    richtxtPrice.Text = richtxtPrice.Text.Remove(0, 1);
                }
                tempPay = string.Empty;
            }
        }

        /// <summary>
        /// Handles the Click event of the button00 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button00_Click(object sender, EventArgs e)
        {
            if (richtxtPrice.Text == "0.00" | richtxtPrice.Text == "")
            {
                richtxtPrice.Select();
                richtxtPrice.Focus();
            }
            else
            {
                tempPay = richtxtPrice.Text;
                richtxtPrice.Text = tempPay + "00";
                strLen = richtxtPrice.Text.Trim().Length;

                for (i = 0; i < strLen; i++)
                {
                    dotArray[i] = richtxtPrice.Text.Trim().Substring(i, 1);
                    if (dotArray[i] == ".")
                    {
                        richtxtPrice.Text = richtxtPrice.Text.Remove(i, 1);
                        break;
                    }
                }

                for (j = 0; j < i; j++)
                {
                    zeroArray[j] = richtxtPrice.Text.Substring(j, 1);
                    if (zeroArray[j] == "0")
                    {
                        richtxtPrice.Text = richtxtPrice.Text.Remove(j, 1);
                        break;
                    }
                }

                strLen = richtxtPrice.Text.Trim().Length;
                richtxtPrice.Text = richtxtPrice.Text.Insert(strLen - 2, ".");
                tempPay = string.Empty;

                for (k = 0; k < richtxtPrice.Text.Length; k++)
                {
                    zeroArray[k] = richtxtPrice.Text.Substring(k, 1);
                    if (zeroArray[k] != "0")
                    {
                        break;
                    }
                    else
                    {
                        richtxtPrice.Text = richtxtPrice.Text.Remove(k, 1);
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCLS control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCLS_Click(object sender, EventArgs e)
        {
            richtxtPrice.Text = "";
            richtxtPrice.Select();
            richtxtPrice.Focus();
        }

        /// <summary>
        /// Handles the Click event of the btnGeneral control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnGeneral_Click(object sender, EventArgs e)
        {
            if (double.TryParse(richtxtPrice.Text, out nItmPrice))
            {
                if (nItmPrice > 0)
                {
                    parentForm.ItmPrice = richtxtPrice.Text;
                    parentForm.richTxtUpc.Text = "000000999101";

                    parentForm.Enabled = true;
                    this.Close();
                    parentForm.btnInput_Click(null, null);
                    parentForm.richTxtUpc.Select();
                    parentForm.richTxtUpc.Focus();
                }
                else
                {
                    MyMessageBox.ShowBox("INVAILD AMOUNT", "ERROR");
                    richtxtPrice.SelectAll();
                    richtxtPrice.Focus();
                }
            }
            else
            {
                MyMessageBox.ShowBox("INVAILD AMOUNT", "ERROR");
                richtxtPrice.SelectAll();
                richtxtPrice.Focus();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnHair control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnHair_Click(object sender, EventArgs e)
        {
            if (double.TryParse(richtxtPrice.Text, out nItmPrice))
            {
                if (nItmPrice > 0)
                {
                    parentForm.ItmPrice = richtxtPrice.Text;
                    parentForm.richTxtUpc.Text = "000000999102";

                    parentForm.Enabled = true;
                    this.Close();
                    parentForm.btnInput_Click(null, null);
                    parentForm.richTxtUpc.Select();
                    parentForm.richTxtUpc.Focus();
                }
                else
                {
                    MyMessageBox.ShowBox("INVAILD AMOUNT", "ERROR");
                    richtxtPrice.SelectAll();
                    richtxtPrice.Focus();
                }
            }
            else
            {
                MyMessageBox.ShowBox("INVAILD AMOUNT", "ERROR");
                richtxtPrice.SelectAll();
                richtxtPrice.Focus();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnHairCare control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnHairCare_Click(object sender, EventArgs e)
        {
            if (double.TryParse(richtxtPrice.Text, out nItmPrice))
            {
                if (nItmPrice > 0)
                {
                    parentForm.ItmPrice = richtxtPrice.Text;
                    parentForm.richTxtUpc.Text = "000000999103";

                    parentForm.Enabled = true;
                    this.Close();
                    parentForm.btnInput_Click(null, null);
                    parentForm.richTxtUpc.Select();
                    parentForm.richTxtUpc.Focus();
                }
                else
                {
                    MyMessageBox.ShowBox("INVAILD AMOUNT", "ERROR");
                    richtxtPrice.SelectAll();
                    richtxtPrice.Focus();
                }
            }
            else
            {
                MyMessageBox.ShowBox("INVAILD AMOUNT", "ERROR");
                richtxtPrice.SelectAll();
                richtxtPrice.Focus();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnNailFoot control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnNailFoot_Click(object sender, EventArgs e)
        {
            if (double.TryParse(richtxtPrice.Text, out nItmPrice))
            {
                if (nItmPrice > 0)
                {
                    parentForm.ItmPrice = richtxtPrice.Text;
                    parentForm.richTxtUpc.Text = "000000999104";

                    parentForm.Enabled = true;
                    this.Close();
                    parentForm.btnInput_Click(null, null);
                    parentForm.richTxtUpc.Select();
                    parentForm.richTxtUpc.Focus();
                }
                else
                {
                    MyMessageBox.ShowBox("INVAILD AMOUNT", "ERROR");
                    richtxtPrice.SelectAll();
                    richtxtPrice.Focus();
                }
            }
            else
            {
                MyMessageBox.ShowBox("INVAILD AMOUNT", "ERROR");
                richtxtPrice.SelectAll();
                richtxtPrice.Focus();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSalonSupply control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSalonSupply_Click(object sender, EventArgs e)
        {
            if (double.TryParse(richtxtPrice.Text, out nItmPrice))
            {
                if (nItmPrice > 0)
                {
                    parentForm.ItmPrice = richtxtPrice.Text;
                    parentForm.richTxtUpc.Text = "000000999105";

                    parentForm.Enabled = true;
                    this.Close();
                    parentForm.btnInput_Click(null, null);
                    parentForm.richTxtUpc.Select();
                    parentForm.richTxtUpc.Focus();
                }
                else
                {
                    MyMessageBox.ShowBox("INVAILD AMOUNT", "ERROR");
                    richtxtPrice.SelectAll();
                    richtxtPrice.Focus();
                }
            }
            else
            {
                MyMessageBox.ShowBox("INVAILD AMOUNT", "ERROR");
                richtxtPrice.SelectAll();
                richtxtPrice.Focus();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSkinCosmetic control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSkinCosmetic_Click(object sender, EventArgs e)
        {
            if (double.TryParse(richtxtPrice.Text, out nItmPrice))
            {
                if (nItmPrice > 0)
                {
                    parentForm.ItmPrice = richtxtPrice.Text;
                    parentForm.richTxtUpc.Text = "000000999106";

                    parentForm.Enabled = true;
                    this.Close();
                    parentForm.btnInput_Click(null, null);
                    parentForm.richTxtUpc.Select();
                    parentForm.richTxtUpc.Focus();
                }
                else
                {
                    MyMessageBox.ShowBox("INVAILD AMOUNT", "ERROR");
                    richtxtPrice.SelectAll();
                    richtxtPrice.Focus();
                }
            }
            else
            {
                MyMessageBox.ShowBox("INVAILD AMOUNT", "ERROR");
                richtxtPrice.SelectAll();
                richtxtPrice.Focus();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnStylingAppliance control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnStylingAppliance_Click(object sender, EventArgs e)
        {
            if (double.TryParse(richtxtPrice.Text, out nItmPrice))
            {
                if (nItmPrice > 0)
                {
                    parentForm.ItmPrice = richtxtPrice.Text;
                    parentForm.richTxtUpc.Text = "000000999107";

                    parentForm.Enabled = true;
                    this.Close();
                    parentForm.btnInput_Click(null, null);
                    parentForm.richTxtUpc.Select();
                    parentForm.richTxtUpc.Focus();
                }
                else
                {
                    MyMessageBox.ShowBox("INVAILD AMOUNT", "ERROR");
                    richtxtPrice.SelectAll();
                    richtxtPrice.Focus();
                }
            }
            else
            {
                MyMessageBox.ShowBox("INVAILD AMOUNT", "ERROR");
                richtxtPrice.SelectAll();
                richtxtPrice.Focus();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnWigPonytail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnWigPonytail_Click(object sender, EventArgs e)
        {
            if (double.TryParse(richtxtPrice.Text, out nItmPrice))
            {
                if (nItmPrice > 0)
                {
                    parentForm.ItmPrice = richtxtPrice.Text;
                    parentForm.richTxtUpc.Text = "000000999108";

                    parentForm.Enabled = true;
                    this.Close();
                    parentForm.btnInput_Click(null, null);
                    parentForm.richTxtUpc.Select();
                    parentForm.richTxtUpc.Focus();
                }
                else
                {
                    MyMessageBox.ShowBox("INVAILD AMOUNT", "ERROR");
                    richtxtPrice.SelectAll();
                    richtxtPrice.Focus();
                }
            }
            else
            {
                MyMessageBox.ShowBox("INVAILD AMOUNT", "ERROR");
                richtxtPrice.SelectAll();
                richtxtPrice.Focus();
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

        /*protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }*/

        /// <summary>
        /// Handles the Load event of the NoBarcodeItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void NoBarcodeItem_Load(object sender, EventArgs e)
        {
            richtxtPrice.Select();
            richtxtPrice.Focus();

        }

        /// <summary>
        /// Handles the Click event of the richtxtPrice control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void richtxtPrice_Click(object sender, EventArgs e)
        {
            richtxtPrice.SelectAll();
            richtxtPrice.Focus();
        }

        /// <summary>
        /// Handles the Click event of the btnGiftcard25 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnGiftcard25_Click(object sender, EventArgs e)
        {
            InputGiftcardCode inputGiftcardCodeForm = new InputGiftcardCode(1);
            inputGiftcardCodeForm.parentForm = this.parentForm;
            inputGiftcardCodeForm.parentForm2 = this;
            inputGiftcardCodeForm.ShowDialog();

            //MyMessageBox.ShowBox("NOT AVAILABLE", "ERROR");
            //return;
        }

        /// <summary>
        /// Handles the Click event of the btnGiftcard50 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnGiftcard50_Click(object sender, EventArgs e)
        {
            InputGiftcardCode inputGiftcardCodeForm = new InputGiftcardCode(2);
            inputGiftcardCodeForm.parentForm = this.parentForm;
            inputGiftcardCodeForm.parentForm2 = this;
            inputGiftcardCodeForm.ShowDialog();

            /*parentForm.richTxtUpc.Text = "B4UGIFTCARD2";

            parentForm.Enabled = true;
            this.Close();
            parentForm.btnInput_Click(null, null);
            parentForm.dataGridView1.SelectedCells[1].Value = gcCode.ToUpper() + " - GIFTCARD $50";
            parentForm.richTxtUpc.Select();
            parentForm.richTxtUpc.Focus();*/
        }

        /// <summary>
        /// Handles the Click event of the btnGiftcard100 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnGiftcard100_Click(object sender, EventArgs e)
        {
            InputGiftcardCode inputGiftcardCodeForm = new InputGiftcardCode(3);
            inputGiftcardCodeForm.parentForm = this.parentForm;
            inputGiftcardCodeForm.parentForm2 = this;
            inputGiftcardCodeForm.ShowDialog();

            //MyMessageBox.ShowBox("NOT AVAILABLE", "ERROR");
            //return;
        }

        /// <summary>
        /// Giftcards the scanning.
        /// </summary>
        /// <param name="opt">The opt.</param>
        public void Giftcard_Scanning(int opt)
        {
            if (opt == 1)
            {
                parentForm.richTxtUpc.Text = "B4UGIFTCARD1";

                parentForm.Enabled = true;
                this.Close();
                parentForm.btnInput_Click(null, null);
                parentForm.dataGridView1.SelectedCells[1].Value = gcCode.ToUpper() + " - GIFTCARD $25";
                parentForm.richTxtUpc.Select();
                parentForm.richTxtUpc.Focus();
            }
            else if (opt == 2)
            {
                parentForm.richTxtUpc.Text = "B4UGIFTCARD2";

                parentForm.Enabled = true;
                this.Close();
                parentForm.btnInput_Click(null, null);
                parentForm.dataGridView1.SelectedCells[1].Value = gcCode.ToUpper() + " - GIFTCARD $50";
                parentForm.richTxtUpc.Select();
                parentForm.richTxtUpc.Focus();
            }
            else if (opt == 3)
            {
                parentForm.richTxtUpc.Text = "B4UGIFTCARD3";

                parentForm.Enabled = true;
                this.Close();
                parentForm.btnInput_Click(null, null);
                parentForm.dataGridView1.SelectedCells[1].Value = gcCode.ToUpper() + " - GIFTCARD $100";
                parentForm.richTxtUpc.Select();
                parentForm.richTxtUpc.Focus();
            }
        }
    }
}