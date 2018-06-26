// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 02-01-2016
// ***********************************************************************
// <copyright file="InputPasscode.cs" company="Beauty4u">
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
    /// Class InputPasscode.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class InputPasscode : Form
    {
        /// <summary>
        /// The parent form
        /// </summary>
        public AboutRegister parentForm;

        /// <summary>
        /// Initializes a new instance of the <see cref="InputPasscode"/> class.
        /// </summary>
        public InputPasscode()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the InputPasscode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void InputPasscode_Load(object sender, EventArgs e)
        {
            txtInputPasscode.Select();
            txtInputPasscode.Focus();
        }

        /// <summary>
        /// Handles the Click event of the btnOk control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (parentForm.updatePassword == "Expired passcode")
            {
                MessageBox.Show("This passscode has been expired. \r\nPlease contact IT department.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInputPasscode.SelectAll();
                txtInputPasscode.Focus();
                return;
            }
            else if (txtInputPasscode.Text == parentForm.updatePassword)
            {
                parentForm.auth = true;
                parentForm.listBox1.DataSource = parentForm.GetFtpDirectoryDetails(parentForm._ftpURL + parentForm.FTPDirectoryName, parentForm._UserName, parentForm._Password);
                parentForm.btnUpdateCheck.Text = "UPDATE";
                parentForm.lblList.Visible = true;
                parentForm.listBox1.Visible = true;
                parentForm.progressBar1.Visible = true;
                parentForm.progressBar1.Value = 0;
                MessageBox.Show("Passcode authorization successes. Please click UPDATE button for downloading files.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid passcode.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInputPasscode.SelectAll();
                txtInputPasscode.Focus();
                return;
            }
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