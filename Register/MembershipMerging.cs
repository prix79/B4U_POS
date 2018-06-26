// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 09-19-2015
// ***********************************************************************
// <copyright file="MembershipMerging.cs" company="Beauty4u">
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
using System.Data.SqlClient;

/// <summary>
/// The Register namespace.
/// </summary>
namespace Register
{
    /// <summary>
    /// Class MembershipMerging.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class MembershipMerging : Form
    {
        /// <summary>
        /// The parent form1
        /// </summary>
        public MainForm parentForm1;
        /// <summary>
        /// The parent form2
        /// </summary>
        public MembershipMain parentForm2;

        /// <summary>
        /// Initializes a new instance of the <see cref="MembershipMerging"/> class.
        /// </summary>
        public MembershipMerging()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the btnUpdateCustomer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {

        }
    }
}