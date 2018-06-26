// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 04-20-2010
// ***********************************************************************
// <copyright file="NumberPad.cs" company="Beauty4u">
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
    /// Class NumberPad.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class NumberPad : Form
    {
        /// <summary>
        /// The parentform
        /// </summary>
        public MainForm parentform;
        /// <summary>
        /// The temporary
        /// </summary>
        string temp = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="NumberPad"/> class.
        /// </summary>
        public NumberPad()
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
            temp = lblInput.Text;
            lblInput.Text = temp + "1";
            temp = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the button2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            temp = lblInput.Text;
            lblInput.Text = temp + "2";
            temp = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the button3 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button3_Click(object sender, EventArgs e)
        {
            temp = lblInput.Text;
            lblInput.Text = temp + "3";
            temp = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the button4 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button4_Click(object sender, EventArgs e)
        {
            temp = lblInput.Text;
            lblInput.Text = temp + "4";
            temp = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the button5 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button5_Click(object sender, EventArgs e)
        {
            temp = lblInput.Text;
            lblInput.Text = temp + "5";
            temp = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the button6 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button6_Click(object sender, EventArgs e)
        {
            temp = lblInput.Text;
            lblInput.Text = temp + "6";
            temp = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the button7 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button7_Click(object sender, EventArgs e)
        {
            temp = lblInput.Text;
            lblInput.Text = temp + "7";
            temp = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the button8 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button8_Click(object sender, EventArgs e)
        {
            temp = lblInput.Text;
            lblInput.Text = temp + "8";
            temp = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the button9 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button9_Click(object sender, EventArgs e)
        {
            temp = lblInput.Text;
            lblInput.Text = temp + "9";
            temp = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the button0 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button0_Click(object sender, EventArgs e)
        {
            temp = lblInput.Text;
            lblInput.Text = temp + "0";
            temp = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the button00 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button00_Click(object sender, EventArgs e)
        {
            temp = lblInput.Text;
            lblInput.Text = temp + "00";
            temp = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the buttonCLS control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonCLS_Click(object sender, EventArgs e)
        {
            lblInput.Text = "";
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
            parentform.richTxtUpc.Text = lblInput.Text;

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