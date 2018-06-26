// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 03-31-2017
// ***********************************************************************
// <copyright file="MyMessageBox.cs" company="Beauty4u">
//     Copyright © Beauty4u 2009
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.Media;

/// <summary>
/// The Register namespace.
/// </summary>
namespace Register
{
    /// <summary>
    /// Class MyMessageBox.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class MyMessageBox : Form
    {
        /// <summary>
        /// The new message box
        /// </summary>
        static MyMessageBox newMessageBox;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyMessageBox"/> class.
        /// </summary>
        public MyMessageBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Shows the box.
        /// </summary>
        /// <param name="txtMessage">The text message.</param>
        /// <param name="txtTitle">The text title.</param>
        public static void ShowBox(string txtMessage, string txtTitle)
        {
            if (txtTitle == "ERROR")
            {
                if (txtMessage == "CAN NOT FIND UPC")
                {
                    SystemSounds.Beep.Play();
                    newMessageBox = new MyMessageBox();
                    newMessageBox.lblTitle.Text = txtTitle;
                    newMessageBox.lblMessage.BackColor = Color.Red;
                    newMessageBox.lblMessage.ForeColor = Color.White;
                    newMessageBox.lblMessage.Text = txtMessage;
                    newMessageBox.btnOK.Visible = false;
                    newMessageBox.lblExitMsg.Visible = true;
                    newMessageBox.ShowDialog();
                }
                else
                {
                    SystemSounds.Beep.Play();
                    newMessageBox = new MyMessageBox();
                    newMessageBox.lblTitle.Text = txtTitle;
                    newMessageBox.lblMessage.BackColor = Color.Red;
                    newMessageBox.lblMessage.ForeColor = Color.White;
                    newMessageBox.lblMessage.Text = txtMessage;
                    newMessageBox.ShowDialog();
                }
            }
            else if(txtTitle == "WARNING")
            {
                SystemSounds.Beep.Play();
                newMessageBox = new MyMessageBox();
                newMessageBox.lblTitle.Text = txtTitle;
                newMessageBox.lblMessage.BackColor = Color.Yellow;
                newMessageBox.lblMessage.ForeColor = Color.Black;
                newMessageBox.lblMessage.Text = txtMessage;
                newMessageBox.ShowDialog();
            }
            else
            {
                SystemSounds.Beep.Play();
                newMessageBox = new MyMessageBox();
                newMessageBox.lblTitle.Text = txtTitle;
                newMessageBox.lblMessage.BackColor = Color.White;
                newMessageBox.lblMessage.ForeColor = Color.Black;
                newMessageBox.lblMessage.Text = txtMessage;
                newMessageBox.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            newMessageBox.Close();
        }

        /// <summary>
        /// Handles the DoubleClick event of the MyMessageBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MyMessageBox_DoubleClick(object sender, EventArgs e)
        {
            newMessageBox.Close();
        }

        /// <summary>
        /// Handles the DoubleClick event of the lblExitMsg control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lblExitMsg_DoubleClick(object sender, EventArgs e)
        {
            newMessageBox.Close();
        }
    }
}