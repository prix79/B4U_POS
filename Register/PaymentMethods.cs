// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 12-19-2017
// ***********************************************************************
// <copyright file="PaymentMethods.cs" company="Beauty4u">
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
    /// Class PaymentMethods.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class PaymentMethods : Form
    {
        /// <summary>
        /// The parent form
        /// </summary>
        public MainForm parentForm;
        /// <summary>
        /// The display grand total
        /// </summary>
        string displayGrandTotal;

        /// <summary>
        /// The t
        /// </summary>
        Timer t = new Timer();
        /// <summary>
        /// The count
        /// </summary>
        int count;

        /// <summary>
        /// The opt
        /// </summary>
        int opt = 0;
        /// <summary>
        /// The redeem points
        /// </summary>
        double redeemPoints = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentMethods"/> class.
        /// </summary>
        /// <param name="grandTotal">The grand total.</param>
        /// <param name="option">The option.</param>
        /// <param name="points">The points.</param>
        public PaymentMethods(string grandTotal, int option, double points)
        {
            InitializeComponent();
            lblGrandTotal.Text = grandTotal;
            displayGrandTotal = lblGrandTotal.Text;
            opt = option;
            redeemPoints = points;
        }

        /// <summary>
        /// Handles the Load event of the PaymentMethods control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void PaymentMethods_Load(object sender, EventArgs e)
        {
            //if (parentForm.storeCode == "BW")
            //    btnCredit.Enabled = false;

            count = 90;
            t.Interval = 1000;
            t.Tick += t_Tick;
            t.Start();
        }

        /// <summary>
        /// Handles the Tick event of the t control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void t_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = "TIME OUT: " + count + " seconds left...";
            count--;

            if (count == -1)
            {
                t.Stop();
                this.Close();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCash control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCash_Click(object sender, EventArgs e)
        {
            t.Stop();

            CashOption cashOptionForm = new CashOption(displayGrandTotal, opt, redeemPoints);
            cashOptionForm.parentForm = this.parentForm;
            //cashOptionForm.Show();
            cashOptionForm.ShowDialog();

            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the btnCredit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCredit_Click(object sender, EventArgs e)
        {
            t.Stop();

            /*CreditOption creditOptionForm = new CreditOption(displayGrandTotal, opt, redeemPoints);
            creditOptionForm.parentForm = this.parentForm;
            //creditOptionForm.Show();
            creditOptionForm.ShowDialog();*/

            //CloverPayment cloverPaymentForm = new CloverPayment(displayGrandTotal, opt, redeemPoints, this.parentForm);
            parentForm.cloverPaymentForm = new CloverPayment(displayGrandTotal, opt, redeemPoints, 0);
            parentForm.cloverPaymentForm.parentForm = this.parentForm;
            //creditOptionForm.Show();
            parentForm.cloverPaymentForm.ShowDialog();

            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the btnTerminal control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnTerminal_Click(object sender, EventArgs e)
        {
            t.Stop();

            Terminal terminalForm = new Terminal(displayGrandTotal, opt, redeemPoints);
            terminalForm.parentForm = this.parentForm;
            //terminalForm.Show();
            terminalForm.ShowDialog();

            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            t.Stop();

            parentForm.LineDisply(parentForm.openingMSG1, parentForm.openingMSG2);

            parentForm.Enabled = true;
            this.Close();
            parentForm.richTxtUpc.Select();
            parentForm.richTxtUpc.Focus();
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
        /// Handles the Click event of the btnMultiple control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnMultiple_Click(object sender, EventArgs e)
        {
            t.Stop();

            //MultiplePayment multiplePaymentForm = new MultiplePayment(displayGrandTotal, opt, redeemPoints);
            //multiplePaymentForm.parentForm = this.parentForm;
            //multiplePaymentForm.Show();
            //multiplePaymentForm.ShowDialog();

            parentForm.multiplePaymentForm = new MultiplePayment(displayGrandTotal, opt, redeemPoints);
            parentForm.multiplePaymentForm.parentForm = this.parentForm;
            //creditOptionForm.Show();
            parentForm.multiplePaymentForm.ShowDialog();

            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the btnStoreCredit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnStoreCredit_Click(object sender, EventArgs e)
        {
            t.Stop();

            StoreCreditOption storeCreditOptionForm = new StoreCreditOption(displayGrandTotal, opt, redeemPoints);
            storeCreditOptionForm.parentForm = this.parentForm;
            //storeCreditOptionForm.Show();
            storeCreditOptionForm.ShowDialog();

            this.Close();
        }

        /// <summary>
        /// Handles the FormClosed event of the PaymentMethods control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosedEventArgs"/> instance containing the event data.</param>
        private void PaymentMethods_FormClosed(object sender, FormClosedEventArgs e)
        {
            t.Stop();

            parentForm.Enabled = true;
            this.Close();
            parentForm.richTxtUpc.Select();
            parentForm.richTxtUpc.Focus();
        }

        /// <summary>
        /// Handles the Click event of the btnGiftCard control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnGiftCard_Click(object sender, EventArgs e)
        {
            t.Stop();

            GiftCardOption giftCardOptionForm = new GiftCardOption(displayGrandTotal, opt, redeemPoints);
            giftCardOptionForm.parentForm = this.parentForm;
            giftCardOptionForm.ShowDialog();

            this.Close();
        }
    }
}   