// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 04-20-2010
// ***********************************************************************
// <copyright file="ChangeQty.cs" company="Beauty4u">
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
using System.IO;

/// <summary>
/// The Register namespace.
/// </summary>
namespace Register
{
    /// <summary>
    /// Class ChangeQty.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class ChangeQty : Form
    {
        /// <summary>
        /// The parentform
        /// </summary>
        public MainForm parentform;
        /// <summary>
        /// The temporary qty
        /// </summary>
        string tempQty = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeQty"/> class.
        /// </summary>
        public ChangeQty()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            tempQty = lblQty.Text;
            lblQty.Text = tempQty + "1";
            tempQty = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the button2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            tempQty = lblQty.Text;
            lblQty.Text = tempQty + "2";
            tempQty = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the button3 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button3_Click(object sender, EventArgs e)
        {
            tempQty = lblQty.Text;
            lblQty.Text = tempQty + "3";
            tempQty = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the button4 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button4_Click(object sender, EventArgs e)
        {
            tempQty = lblQty.Text;
            lblQty.Text = tempQty + "4";
            tempQty = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the button5 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button5_Click(object sender, EventArgs e)
        {
            tempQty = lblQty.Text;
            lblQty.Text = tempQty + "5";
            tempQty = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the button6 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button6_Click(object sender, EventArgs e)
        {
            tempQty = lblQty.Text;
            lblQty.Text = tempQty + "6";
            tempQty = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the button7 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button7_Click(object sender, EventArgs e)
        {
            tempQty = lblQty.Text;
            lblQty.Text = tempQty + "7";
            tempQty = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the button8 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button8_Click(object sender, EventArgs e)
        {
            tempQty = lblQty.Text;
            lblQty.Text = tempQty + "8";
            tempQty = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the button9 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button9_Click(object sender, EventArgs e)
        {
            tempQty = lblQty.Text;
            lblQty.Text = tempQty + "9";
            tempQty = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the button0 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button0_Click(object sender, EventArgs e)
        {
            tempQty = lblQty.Text;
            lblQty.Text = tempQty + "0";
            tempQty = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the button00 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button00_Click(object sender, EventArgs e)
        {
            tempQty = lblQty.Text;
            lblQty.Text = tempQty + "00";
            tempQty = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the buttonCLS control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonCLS_Click(object sender, EventArgs e)
        {
            lblQty.Text = "";
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            parentform.Enabled = true;
            this.Close();
            parentform.richTxtUpc.Select();
            parentform.richTxtUpc.Focus();
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lblQty.Text == "")
            {
                parentform.getQty = "1";
            }
            else
            {
                parentform.getQty = this.lblQty.Text;
            }

            parentform.Enabled = true;
            this.Close();
            parentform.richTxtUpc.Select();
            parentform.richTxtUpc.Focus();
        }

        /// <summary>
        /// Gets a value indicating whether [show without activation].
        /// </summary>
        /// <value><c>true</c> if [show without activation]; otherwise, <c>false</c>.</value>
        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }
    }
}