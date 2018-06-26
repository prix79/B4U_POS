// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 02-09-2017
//
// Last Modified By : Seungkeun
// Last Modified On : 02-09-2017
// ***********************************************************************
// <copyright file="ConfirmPaymentForm.cs" company="Beauty4u">
//     Copyright © Beauty4u 2009
// </copyright>
// <summary></summary>
// ***********************************************************************.

using com.clover.remotepay.sdk;
using com.clover.remotepay.transport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/// <summary>
/// The Register namespace.
/// </summary>
namespace Register
{
    /// <summary>
    /// Class ConfirmPaymentForm.
    /// </summary>
    /// <seealso cref="Register.OverlayForm" />
    public partial class ConfirmPaymentForm : OverlayForm
    {
        /// <summary>
        /// The form to cover
        /// </summary>
        private Form formToCover = null;
        /// <summary>
        /// The challenge
        /// </summary>
        private Challenge challenge = null;
        /// <summary>
        /// The last challenge
        /// </summary>
        private bool lastChallenge = false;
        /// <summary>
        /// The title
        /// </summary>
        private string title = "";

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmPaymentForm"/> class.
        /// </summary>
        /// <param name="formToCover">The form to cover.</param>
        /// <param name="challenge">The challenge.</param>
        /// <param name="lastChallenge">if set to <c>true</c> [last challenge].</param>
        public ConfirmPaymentForm(Form formToCover, Challenge challenge, bool lastChallenge) : base(formToCover)
        {
            this.formToCover = formToCover;
            this.challenge = challenge;
            this.lastChallenge = lastChallenge;
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the ConfirmPaymentForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ConfirmPaymentForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public String Title
        {
            get
            {
                //return Text;
                return TitleTextBox.Text;
            }
            set
            {
                //Text = value;
                TitleTextBox.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>The label.</value>
        public string Label
        {
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
            }
        }


        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <value>The status.</value>
        public DialogResult Status
        {
            get; internal set;
        }

        /// <summary>
        /// Handles the Click event of the AcceptButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AcceptButton_Click(object sender, EventArgs e)
        {
            if (lastChallenge)
            {
                Status = DialogResult.OK; // set to OK when accepting the last challenge
            } else                        // this is used to trigger the PaymentConfirmedMessage
            {
                Status = DialogResult.Yes; // set to Yes when accepting challenges preceeding
            }                              // the last challenge
            this.Close();
        }
        /// <summary>
        /// Handles the Click event of the RejectButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void RejectButton_Click(object sender, EventArgs e)
        {
            Status = DialogResult.No;   // Used to trigger the PaymentRejectedMessage
            this.Close();
        }
    }
}
