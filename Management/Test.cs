using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace Management
{
    public partial class Test : Form
    {
        public PrintDocument pdPrint;
        public PrintDialog printDialog;
        public PrintPreviewDialog printPreviewDialog;

        public Test()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {

        }

        private Bitmap CreateBarcode(string data)
        {
            Bitmap barcode = new Bitmap(1, 1);

            Font threeOfNine = new Font("barcod39", 20, FontStyle.Regular, GraphicsUnit.Point);

            Graphics graphics = Graphics.FromImage(barcode);

            SizeF dataSize = graphics.MeasureString(data, threeOfNine);

            barcode = new Bitmap(barcode, dataSize.ToSize());

            graphics = Graphics.FromImage(barcode);

            graphics.Clear(Color.White);

            graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;

            graphics.DrawString(data, threeOfNine, new SolidBrush(Color.Black), 0, 0);

            graphics.Flush();

            threeOfNine.Dispose();
            graphics.Dispose();

            return barcode;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = CreateBarcode("*" + textBox1.Text + "*");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            pdPrint = new PrintDocument();
            printDialog = new PrintDialog();
            printDialog.Document = pdPrint;
            pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage);

            DialogResult result = new DialogResult();
            result = printDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                pdPrint.Print();
                this.Close();
            }
        }

        private void pdPrint_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawImage(pictureBox1.Image, 5, 20);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pdPrint = new PrintDocument();
            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = pdPrint;
            pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage);
            pdPrint.PrinterSettings.PrinterName = "ZDesigner TLP 2844";

            DialogResult result = new DialogResult();
            result = printPreviewDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                pdPrint.Print();
                this.Close();
            }
        }
    }
}