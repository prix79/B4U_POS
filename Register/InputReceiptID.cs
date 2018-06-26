// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 02-14-2011
// ***********************************************************************
// <copyright file="InputReceiptID.cs" company="Beauty4u">
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
    /// Class InputReceiptID.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class InputReceiptID : Form
    {
        /// <summary>
        /// The parent form
        /// </summary>
        public Return parentForm;

        /// <summary>
        /// Initializes a new instance of the <see cref="InputReceiptID"/> class.
        /// </summary>
        public InputReceiptID()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the InputReceiptID control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void InputReceiptID_Load(object sender, EventArgs e)
        {
            txtInputReceiptID.Select();
            txtInputReceiptID.Focus();
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            parentForm.txtReceiptID.Text = txtInputReceiptID.Text.ToString().ToUpper();
            this.Close();
            parentForm.btnSearch_Click(null, null);
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