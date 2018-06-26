// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 02-09-2017
//
// Last Modified By : Seungkeun
// Last Modified On : 03-02-2017
// ***********************************************************************
// <copyright file="SignatureForm.cs" company="Beauty4u">
//     Copyright © Beauty4u 2009
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using com.clover.remotepay.sdk;
using com.clover.sdk.v3.payments;

/// <summary>
/// The Register namespace.
/// </summary>
namespace Register
{
    /// <summary>
    /// Class SignatureForm.
    /// </summary>
    /// <seealso cref="Register.OverlayForm" />
    public partial class SignatureForm : OverlayForm
    {
        /// <summary>
        /// The signature verify request
        /// </summary>
        private VerifySignatureRequest signatureVerifyRequest;

        /// <summary>
        /// Gets or sets the verify signature request.
        /// </summary>
        /// <value>The verify signature request.</value>
        public VerifySignatureRequest VerifySignatureRequest {
            get {
                return signatureVerifyRequest;
            }
            set {
                signatureVerifyRequest = value;
                signaturePanel1.Signature = signatureVerifyRequest.Signature;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="SignatureForm"/> class.
        /// </summary>
        /// <param name="toCover">To cover.</param>
        public SignatureForm(Form toCover) : base(toCover)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the SignatureForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SignatureForm_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handles the Click event of the AcceptButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bmp = new Bitmap(signaturePanel1.Width, signaturePanel1.Height);
                signaturePanel1.DrawToBitmap(bmp, signaturePanel1.Bounds);
                bmp.Save(@"C:\POS\Signature\sign.png", ImageFormat.Png);

                this.Dispose();
                VerifySignatureRequest.Accept();
            }
            catch
            {
                MyMessageBox.ShowBox("SIGNATURE FOLDER DOES NOT EXIST", "ERROR");
            }


        }

        /// <summary>
        /// Handles the Click event of the RejectButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void RejectButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            VerifySignatureRequest.Reject();
        }
    }
}
