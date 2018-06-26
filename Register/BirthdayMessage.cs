// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 01-31-2018
//
// Last Modified By : Seungkeun
// Last Modified On : 02-06-2018
// ***********************************************************************
// <copyright file="BirthdayMessage.cs" company="Beauty4u">
//     Copyright © Beauty4u 2009
// </copyright>
// <summary></summary>
// ***********************************************************************
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
    /// Class BirthdayMessage.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class BirthdayMessage : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BirthdayMessage"/> class.
        /// </summary>
        public BirthdayMessage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
