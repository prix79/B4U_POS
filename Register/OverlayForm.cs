// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 02-09-2017
//
// Last Modified By : Seungkeun
// Last Modified On : 02-09-2017
// ***********************************************************************
// <copyright file="OverlayForm.cs" company="Beauty4u">
//     Copyright © Beauty4u 2009
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

/// <summary>
/// The Register namespace.
/// </summary>
namespace Register
{
    /// <summary>
    /// Class OverlayForm.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public class OverlayForm : Form
    {
        /// <summary>
        /// The tocover
        /// </summary>
        private Form tocover = null;
        /// <summary>
        /// Initializes a new instance of the <see cref="OverlayForm"/> class.
        /// </summary>
        public OverlayForm()
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="OverlayForm"/> class.
        /// </summary>
        /// <param name="formToCover">The form to cover.</param>
        public OverlayForm(Form formToCover) : base()
        {
            this.tocover = formToCover;
            this.Owner = formToCover;
            this.Shown += new System.EventHandler(FormShown);
            WindowState = FormWindowState.Normal;
            StartPosition = FormStartPosition.Manual;
            this.Visible = false;
        }

        /// <summary>
        /// Forms the shown.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FormShown(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkGray;
            this.Opacity = 0.98;
            this.FormBorderStyle = FormBorderStyle.None;
            this.AutoScaleMode = AutoScaleMode.None;
            this.ControlBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.Manual;

            this.Location = tocover.PointToScreen(Point.Empty);
            this.ClientSize = tocover.ClientSize;
            tocover.LocationChanged += ParentLocationChanged;
            tocover.ClientSizeChanged += ParentSizeChanged;
            //this.Show(tocover);
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int value = 1;
                DwmSetWindowAttribute(tocover.Handle, DWMWA_TRANSITIONS_FORCEDISABLED, ref value, 4);
            }
            this.Visible = true;
        }

        /// <summary>
        /// Parents the location changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ParentLocationChanged(object sender, EventArgs e)
        {
            this.Location = tocover.PointToScreen(Point.Empty);
        }
        /// <summary>
        /// Parents the size changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ParentSizeChanged(object sender, EventArgs e)
        {
            this.ClientSize = tocover.ClientSize;
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.FormClosing" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.FormClosingEventArgs" /> that contains the event data.</param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Restore owner
            this.Owner.LocationChanged -= ParentLocationChanged;
            this.Owner.ClientSizeChanged -= ParentSizeChanged;
            if (!this.Owner.IsDisposed && Environment.OSVersion.Version.Major >= 6)
            {
                int value = 1;
                DwmSetWindowAttribute(this.Owner.Handle, DWMWA_TRANSITIONS_FORCEDISABLED, ref value, 4);
            }
            base.OnFormClosing(e);
            this.Dispose();
        }

        /// <summary>
        /// The dwmwa transitions forcedisabled
        /// </summary>
        private const int DWMWA_TRANSITIONS_FORCEDISABLED = 3;
        /// <summary>
        /// DWMs the set window attribute.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="attr">The attribute.</param>
        /// <param name="value">The value.</param>
        /// <param name="attrLen">Length of the attribute.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hWnd, int attr, ref int value, int attrLen);

        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // OverlayForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "OverlayForm";
            this.ResumeLayout(false);

        }
    }
}
