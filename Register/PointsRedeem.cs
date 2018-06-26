// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 09-29-2010
// ***********************************************************************
// <copyright file="PointsRedeem.cs" company="Beauty4u">
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
    /// Class PointsRedeem.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class PointsRedeem : Form
    {
        /// <summary>
        /// The parent form
        /// </summary>
        public MainForm parentForm;
        /// <summary>
        /// The points
        /// </summary>
        double points = 0;
        /// <summary>
        /// The remain
        /// </summary>
        double remain = 0;
        /// <summary>
        /// The redeem
        /// </summary>
        double redeem = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="PointsRedeem"/> class.
        /// </summary>
        /// <param name="p">The p.</param>
        public PointsRedeem(double p)
        {
            InitializeComponent();
            points = p;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the radioBtnInputPoints control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void radioBtnInputPoints_CheckedChanged(object sender, EventArgs e)
        {
            txtPoints.Enabled = true;
            txtPoints.Select();
            txtPoints.Focus();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the radioBtnAllPoints control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void radioBtnAllPoints_CheckedChanged(object sender, EventArgs e)
        {
            txtPoints.Enabled = false;
        }

        /// <summary>
        /// Handles the Click event of the btnRedeem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnRedeem_Click(object sender, EventArgs e)
        {
            if (radioBtnAllPoints.Checked == true)
            {
                redeem = points;
                parentForm.points = redeem;
                parentForm.lblPoints.Text = "$0.00";
                parentForm.richTxtUpc.Text = "000000999110";
                parentForm.btnInput_Click(null, null);

                parentForm.Enabled = true;
                this.Close();
                parentForm.richTxtUpc.Select();
                parentForm.richTxtUpc.Focus();
            }
            else
            {
                if (double.TryParse(txtPoints.Text, out redeem))
                {
                    if (redeem == 0)
                    {
                        MyMessageBox.ShowBox("INPUT AMOUNT", "ERROR");
                        txtPoints.SelectAll();
                        txtPoints.Focus();
                        return;
                    }

                    remain = points - redeem;

                    if (remain >= 0)
                    {
                        parentForm.points = redeem;
                        parentForm.lblPoints.Text = string.Format("{0:$0.00}", remain);
                        parentForm.richTxtUpc.Text = "000000999110";
                        parentForm.btnInput_Click(null, null);

                        parentForm.Enabled = true;
                        this.Close();
                        parentForm.richTxtUpc.Select();
                        parentForm.richTxtUpc.Focus();
                    }
                    else
                    {
                        MyMessageBox.ShowBox("INVALID AMOUNT", "ERROR");
                        //MessageBox.Show("Input correct amount", "Error");
                        txtPoints.SelectAll();
                        return;
                    }
                }
                else
                {
                    MyMessageBox.ShowBox("INVALID AMOUNT", "ERROR");
                    //MessageBox.Show("Input correct amount", "Error");
                    txtPoints.SelectAll();
                    return;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            parentForm.Enabled = true;
            this.Close();
            parentForm.richTxtUpc.Select();
            parentForm.richTxtUpc.Focus();
        }

        /// <summary>
        /// Handles the Load event of the PointsRedeem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void PointsRedeem_Load(object sender, EventArgs e)
        {
            lblMemberCode.Text = parentForm.lblMemberCode.Text;
            lblName.Text = parentForm.lblName.Text;
            lblType.Text = parentForm.lblType.Text;
            lblPoints.Text = parentForm.lblPoints.Text;
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
        /// Handles the Click event of the txtPoints control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtPoints_Click(object sender, EventArgs e)
        {
            txtPoints.SelectAll();
        }
    }
}