// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 02-08-2017
//
// Last Modified By : Seungkeun
// Last Modified On : 02-27-2017
// ***********************************************************************
// <copyright file="SignaturePanel.cs" company="Beauty4u">
//     Copyright © Beauty4u 2009
// </copyright>
// <summary></summary>
// ***********************************************************************

using com.clover.remotepay.transport;
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
    /// Class SignaturePanel.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public partial class SignaturePanel : Control
    {
        /// <summary>
        /// The sig
        /// </summary>
        private Signature2 sig;
        /// <summary>
        /// Gets or sets the signature.
        /// </summary>
        /// <value>The signature.</value>
        public Signature2 Signature {
            get
            {
                return sig;
            }
            set
            {
                sig = value;
                if(value != null)
                {
                    SetBounds(0, 0, (int)(sig.width*scale), (int)(sig.height*scale));
                }
            }
        }
        /// <summary>
        /// The scale
        /// </summary>
        float scale = 0.5f;

        /// <summary>
        /// Handles the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if(Signature != null)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // draw box
                Pen borderPen = new Pen(Color.FromArgb(255, 128, 128, 128));
                borderPen.Width = 1;
                Rectangle border = new Rectangle(new Point(0, 0), new Size((int)(Signature.width * scale), (int)(Signature.height * scale)));

                // draw X
                int xWidth = (int)(Signature.width * .1 * .6 * scale);
                int xHeight = (int)(xWidth * 1.5);
                e.Graphics.DrawLine(borderPen, new Point((int)(Signature.width * scale * .1 - xWidth), (int)(Signature.height * .6 * scale - xHeight)), new Point((int)(Signature.width * scale * .01) + xWidth, (int)(Signature.height * .6 * scale)));
                e.Graphics.DrawLine(borderPen, new Point((int)(Signature.width * scale * .1 - xWidth) + xWidth, (int)(Signature.height * .6 * scale - xHeight)), new Point((int)(Signature.width * scale * .01), (int)(Signature.height * .6 * scale)));
                // draw signature line
                e.Graphics.DrawLine(borderPen, new Point((int)(Signature.width * .1 * scale), (int)(Signature.height * .6 * scale)), new Point((int)(Signature.width * .9 * scale), (int)(Signature.height * .6 * scale)));

                Pen pen = new Pen(Color.FromArgb(255, 0, 0, 205));
                pen.Width = 2;

                foreach (Signature2.Stroke stroke in Signature.strokes)
                {
                    if (stroke.points.Count == 1)
                    {
                        Signature2.Point dot = stroke.points[0];
                        Rectangle rect = new Rectangle(new Point(dot.x, dot.y), new Size(2, 2));

                        e.Graphics.DrawEllipse(pen, rect);
                    }
                    else if (stroke.points.Count > 1)
                    {
                        for (int i = 1; i < stroke.points.Count; i++)
                        {
                            Signature2.Point strokePoint1 = stroke.points[i - 1];
                            Signature2.Point strokePoint2 = stroke.points[i];

                            Point pt1 = new Point();
                            pt1.X = (int)(strokePoint1.x * scale);
                            pt1.Y = (int)(strokePoint1.y * scale);
                            Point pt2 = new Point();
                            pt2.X = (int)(strokePoint2.x * scale);
                            pt2.Y = (int)(strokePoint2.y * scale);

                            e.Graphics.DrawLine(pen, pt1, pt2);
                        }
                    }
                }
            }
        }
    }
}
