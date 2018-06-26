using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using GenCode128;
using IDAutomation.Windows.Forms.LinearBarCode;

namespace Management
{
    public partial class BarcodePrinting : Form
    {
        public InventoryMain parentForm;

        public PrintDocument pdPrint;
        public PrintDialog printDialog;
        public PrintPreviewDialog printPreviewDialog;
        //public string Printer_Name1 = "Zebra  TLP2844";
        //public string Printer_Name2 = "ZDesigner TLP 2844";
        //public string Printer_Name = "ZDesigner GC420T (EPL)";
        public Image myimg;

        public Font BrandFont;
        public Font NameFont;
        public Font SizeFont;
        public Font ColorFont;
        public Font ModelNumFont;
        public Font UpcFont;
        public Font BinNumFont;
        public Font RetailPriceFont;
        public Font m_BarcodeFont = new Font("3 of 9 Barcode", 16);

        string ItmGroup1, ItmGroup2;
        int index;
        int selectedItems = 0;

        string ItmBrand;
        string ItmName;
        string ItmSize;
        string ItmColor;    
        string ItmModelNum;
        string ItmUpc;
        string ItmBinNum;
        double ItmRetailPrice;
        //string ItmRetailPrice;

        public BarcodePrinting()
        {
            InitializeComponent();
        }

        private void BarcodePrinting_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < parentForm.dataGridView1.RowCount; i++)
            {
                if (parentForm.dataGridView1.Rows[i].Cells[28].Selected == true)
                {
                    selectedItems = selectedItems + 1;
                }
            }

            if (selectedItems > 1)
                btnPrintPreview.Enabled = false;

            //barcode1.DataToEncode = ItmUpc;
            barcode1.SymbologyID = Symbologies.Code39;
            barcode1.BarHeightCM = 0.6F;
            barcode1.XDimensionCM = 0.012F;
            barcode1.NarrowToWideRatio = 2;
            barcode1.WhiteBarIncrease = 0;
            barcode1.LeftMarginCM = 0.01F;
            barcode1.TopMarginCM = 0.15F;
            barcode1.CharacterGrouping = 0;
            barcode1.BearerBarHorizontal = 0;
            barcode1.BearerBarVertical = 0;
            barcode1.Code128Set = Code128CharacterSets.Auto;
            barcode1.CheckCharacter = false;
            barcode1.ApplyTilde = false;
            barcode1.ShowText = false;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (rdoBtnOpt1.Checked == true)
            {
                if (selectedItems == 1)
                {
                    //index = parentForm.dataGridView1.SelectedRows[0].Index;
                    index = parentForm.dataGridView1.SelectedCells[0].RowIndex;

                    Set_Variable(index);

                    if (ItmUpc.Length <= 7)
                    {
                        myimg = Code128Rendering.MakeBarcodeImage(ItmUpc, 2, true);
                    }
                    else
                    {
                        myimg = Code128Rendering.MakeBarcodeImage(ItmUpc, 1, true);
                    }

                    pdPrint = new PrintDocument();
                    printDialog = new PrintDialog();
                    printDialog.UseEXDialog = true;
                    printDialog.Document = pdPrint;
                    pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage1);
                    //pdPrint.PrinterSettings.PrinterName = Printer_Name;

                    DialogResult result = new DialogResult();
                    result = printDialog.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        pdPrint.Print();
                        this.Close();
                    }
                }
                else
                {
                    pdPrint = new PrintDocument();
                    printDialog = new PrintDialog();
                    printDialog.UseEXDialog = true;
                    printDialog.Document = pdPrint;
                    pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage1);
                    //pdPrint.PrinterSettings.PrinterName = Printer_Name;

                    DialogResult result = new DialogResult();
                    result = printDialog.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        for (int i = 0; i < parentForm.dataGridView1.RowCount; i++)
                        {
                            //if (parentForm.dataGridView1.Rows[i].Selected == true)
                            if (parentForm.dataGridView1.Rows[i].Cells[28].Selected == true)
                            {
                                Set_Variable(i);

                                if (ItmUpc.Length <= 7)
                                {
                                    myimg = Code128Rendering.MakeBarcodeImage(ItmUpc, 2, true);
                                }
                                else
                                {
                                    myimg = Code128Rendering.MakeBarcodeImage(ItmUpc, 1, true);
                                }

                                pdPrint.Print();
                            }
                        }

                        this.Close();
                    }
                }
            }
            else if (rdoBtnOpt2.Checked == true)
            {
                if (selectedItems == 1)
                {
                    //index = parentForm.dataGridView1.SelectedRows[0].Index;
                    index = parentForm.dataGridView1.SelectedCells[0].RowIndex;

                    pdPrint = new PrintDocument();
                    printDialog = new PrintDialog();
                    printDialog.UseEXDialog = true;
                    printDialog.Document = pdPrint;
                    pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage2);

                    DialogResult result = new DialogResult();
                    result = printDialog.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        Set_Variable(index);
                        barcode1.DataToEncode = ItmUpc;

                        pdPrint.Print();

                        this.Close();
                    }
                }
                else
                {
                    pdPrint = new PrintDocument();
                    printDialog = new PrintDialog();
                    printDialog.UseEXDialog = true;
                    printDialog.Document = pdPrint;
                    pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage2);
                    //pdPrint.PrinterSettings.PrinterName = Printer_Name;

                    DialogResult result = new DialogResult();
                    result = printDialog.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        for (int i = 0; i < parentForm.dataGridView1.RowCount; i++)
                        {
                            if (parentForm.dataGridView1.Rows[i].Cells[28].Selected == true)
                            {
                                Set_Variable(i);
                                barcode1.DataToEncode = ItmUpc;

                                pdPrint.Print();
                            }
                        }

                        this.Close();
                    }
                }
            }
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdoBtnOpt1.Checked == true)
                {
                    //index = parentForm.dataGridView1.SelectedRows[0].Index;
                    index = parentForm.dataGridView1.SelectedCells[0].RowIndex;

                    Set_Variable(index);

                    if (ItmUpc.Length <= 7)
                    {
                        myimg = Code128Rendering.MakeBarcodeImage(ItmUpc, 2, true);
                    }
                    else
                    {
                        myimg = Code128Rendering.MakeBarcodeImage(ItmUpc, 1, true);
                    }

                    pdPrint = new PrintDocument();
                    printPreviewDialog = new PrintPreviewDialog();
                    printPreviewDialog.Document = pdPrint;
                    pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage1);

                    DialogResult result = new DialogResult();
                    result = printPreviewDialog.ShowDialog();

                    this.Close();
                }
                else
                {
                    //index = parentForm.dataGridView1.SelectedRows[0].Index;
                    index = parentForm.dataGridView1.SelectedCells[0].RowIndex;

                    Set_Variable(index);
                    barcode1.DataToEncode = ItmUpc;

                    pdPrint = new PrintDocument();
                    printPreviewDialog = new PrintPreviewDialog();
                    printPreviewDialog.Document = pdPrint;
                    pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage2);

                    DialogResult result = new DialogResult();
                    result = printPreviewDialog.ShowDialog();

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            Set_Variable(index);

            if (Convert.ToInt16(parentForm.dataGridView1.SelectedCells[7].Value) == 7 & Convert.ToInt16(parentForm.dataGridView1.SelectedCells[8].Value) == 1)
            {

            }
            else
            {
                if (ItmUpc.Length == 4)
                {
                    myimg = Code128Rendering.MakeBarcodeImage(ItmUpc, 2, true);
                    pictureBox1.Image = myimg;
                }
                else if (ItmUpc.Length == 7)
                {
                    myimg = Code128Rendering.MakeBarcodeImage(ItmUpc, 2, true);
                    pictureBox1.Image = myimg;
                }
                else
                {
                    myimg = Code128Rendering.MakeBarcodeImage(ItmUpc, 1, true);
                    pictureBox1.Image = myimg;
                }
            }
        }

        private void Set_Variable(int i)
        {
            ItmGroup1 = parentForm.dataGridView1.Rows[i].Cells[7].Value.ToString();
            ItmGroup2 = parentForm.dataGridView1.Rows[i].Cells[8].Value.ToString();

            ItmBrand = parentForm.dataGridView1.Rows[i].Cells[2].Value.ToString();
            ItmName = parentForm.dataGridView1.Rows[i].Cells[3].Value.ToString();
            ItmSize = parentForm.dataGridView1.Rows[i].Cells[4].Value.ToString();
            ItmColor = parentForm.dataGridView1.Rows[i].Cells[5].Value.ToString();
            ItmModelNum = parentForm.dataGridView1.Rows[i].Cells[6].Value.ToString();
            ItmUpc = parentForm.dataGridView1.Rows[i].Cells[28].Value.ToString();
            ItmBinNum = parentForm.dataGridView1.Rows[i].Cells[29].Value.ToString();
            ItmRetailPrice = Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[15].Value);
            //ItmRetailPrice = parentForm.dataGridView1.Rows[i].Cells[15].ToString();
        }

        private void pdPrint_PrintPage1(object sender, PrintPageEventArgs e)
        {
            if (ItmGroup1 == "2" | ItmGroup1 == "3")
            {
                if (ItmUpc.Length == 7)
                {
                    Graphics g = e.Graphics;
                    BrandFont = new Font("Arial", 8, FontStyle.Bold);
                    NameFont = new Font("Arial", 8, FontStyle.Bold);
                    BinNumFont = new Font("Arial", 17, FontStyle.Bold);
                    UpcFont = new Font("Arial", 8);
                    SizeFont = new Font("Arial", 11, FontStyle.Bold);
                    RetailPriceFont = new Font("Georgia", 10, FontStyle.Bold);

                    g.DrawString(ItmBrand, BrandFont, Brushes.Black, 12, 0);
                    g.DrawString(ItmName, NameFont, Brushes.Black, 12, 11);

                    float xPos;

                    if (ItmRetailPrice == 1)
                    {
                        xPos = 145.187752f;
                    }
                    else
                    {
                        xPos = (e.PageBounds.Width - 15) - e.Graphics.MeasureString(Convert.ToString(ItmRetailPrice), RetailPriceFont).Width;
                    }

                    //float xPos = (e.PageBounds.Width - 8) - e.Graphics.MeasureString(Convert.ToString(ItmRetailPrice), RetailPriceFont).Width;
                    g.DrawString(string.Format("{0:$0.00}", ItmRetailPrice), RetailPriceFont, Brushes.Black, xPos, 3);
                    //g.DrawImage(pictureBox1.Image, 9, 23);
                    g.DrawImage(myimg, 9, 23);
                    g.DrawString(ItmUpc, UpcFont, Brushes.Black, 11, 57);
                    g.DrawString(ItmSize + " - " + ItmColor, SizeFont, Brushes.Black, 11, 67);
                    xPos = (e.PageBounds.Width) - e.Graphics.MeasureString(ItmBinNum, BinNumFont).Width;
                    g.DrawString(ItmBinNum, BinNumFont, Brushes.Black, xPos, 58);
                }
                else
                {
                    Graphics g = e.Graphics;
                    BrandFont = new Font("Arial", 8, FontStyle.Bold);
                    NameFont = new Font("Arial", 8, FontStyle.Bold);
                    BinNumFont = new Font("Arial", 17, FontStyle.Bold);
                    UpcFont = new Font("Arial", 8);
                    SizeFont = new Font("Arial", 11, FontStyle.Bold);
                    RetailPriceFont = new Font("Georgia", 10, FontStyle.Bold);

                    g.DrawString(ItmBrand, BrandFont, Brushes.Black, 12, 1);
                    g.DrawString(ItmName, NameFont, Brushes.Black, 12, 12);

                    float xPos;

                    if (ItmRetailPrice == 1)
                    {
                        xPos = 145.187752f;
                    }
                    else
                    {
                        xPos = (e.PageBounds.Width - 15) - e.Graphics.MeasureString(Convert.ToString(ItmRetailPrice), RetailPriceFont).Width;
                    }

                    //float xPos = (e.PageBounds.Width - 8) - e.Graphics.MeasureString(Convert.ToString(ItmRetailPrice), RetailPriceFont).Width;
                    g.DrawString(string.Format("{0:$0.00}", ItmRetailPrice), RetailPriceFont, Brushes.Black, xPos, 3);
                    //g.DrawImage(pictureBox1.Image, 9, 26);
                    g.DrawImage(myimg, 9, 26);
                    g.DrawString(ItmUpc, UpcFont, Brushes.Black, 11, 53);
                    g.DrawString(ItmSize + " - " + ItmColor, SizeFont, Brushes.Black, 10, 63);
                    xPos = (e.PageBounds.Width) - e.Graphics.MeasureString(ItmBinNum, BinNumFont).Width;
                    g.DrawString(ItmBinNum, BinNumFont, Brushes.Black, xPos, 56);
                }
            }
            else if (ItmGroup1 == "7" & ItmGroup2 == "1")
            {
                Graphics g = e.Graphics;
                NameFont = new Font("Arial", 8, FontStyle.Bold);
                UpcFont = new Font("Arial", 9);
                RetailPriceFont = new Font("Georgia", 17, FontStyle.Bold);

                float xPos = (e.PageBounds.Width - 15) - e.Graphics.MeasureString(Convert.ToString(ItmRetailPrice), RetailPriceFont).Width;

                Brush br = new SolidBrush(Color.Black);

                g.DrawString(ItmName, NameFont, Brushes.Black, 13, 7);
                g.DrawImage(myimg, 10, 20);
                g.DrawString(ItmUpc, UpcFont, Brushes.Black, 12, 53);
                g.DrawString(string.Format("{0:c}", ItmRetailPrice), RetailPriceFont, Brushes.Black, xPos, 56);
            }
            else
            {
                if (ItmUpc.Length == 7)
                {
                    Graphics g = e.Graphics;
                    BrandFont = new Font("Arial", 6, FontStyle.Bold);
                    NameFont = new Font("Arial", 6, FontStyle.Bold);
                    UpcFont = new Font("Arial", 9);
                    SizeFont = new Font("Arial", 6, FontStyle.Bold);
                    ColorFont = new Font("Arial", 6, FontStyle.Bold);
                    ModelNumFont = new Font("Arial", 6, FontStyle.Bold);
                    RetailPriceFont = new Font("Georgia", 17, FontStyle.Bold);

                    float xPos;

                    if (ItmRetailPrice == 1)
                    {
                        xPos = 121.187752f;
                    }
                    else
                    {
                        xPos = (e.PageBounds.Width - 15) - e.Graphics.MeasureString(Convert.ToString(ItmRetailPrice), RetailPriceFont).Width;
                    }

                    //float xPos = (e.PageBounds.Width - 15) - e.Graphics.MeasureString(Convert.ToString(ItmRetailPrice), RetailPriceFont).Width;
                    g.DrawString(ItmBrand, BrandFont, Brushes.Black, 13, 0);
                    g.DrawString(ItmName, NameFont, Brushes.Black, 13, 9);
                    g.DrawImage(myimg, 10, 18);
                    g.DrawString(ItmUpc, UpcFont, Brushes.Black, 12, 53);
                    g.DrawString(ItmModelNum, ModelNumFont, Brushes.Black, 13, 65);

                    if (ItmSize.Trim().Length != 0 & ItmColor.Trim().Length == 0)
                    {
                        g.DrawString(ItmSize, SizeFont, Brushes.Black, 13, 73);
                    }
                    else if (ItmSize.Trim().Length == 0 & ItmColor.Trim().Length != 0)
                    {
                        g.DrawString(ItmColor, SizeFont, Brushes.Black, 13, 73);
                    }
                    else if (ItmSize.Trim().Length != 0 & ItmColor.Trim().Length != 0)
                    {
                        g.DrawString(ItmSize + " - " + ItmColor, SizeFont, Brushes.Black, 13, 73);
                    }
                    else
                    {
                    }

                    g.DrawString(string.Format("{0:c}", ItmRetailPrice), RetailPriceFont, Brushes.Black, xPos, 56);
                }
                else
                {
                    Graphics g = e.Graphics;
                    BrandFont = new Font("Arial", 6, FontStyle.Bold);
                    NameFont = new Font("Arial", 6, FontStyle.Bold);
                    UpcFont = new Font("Arial", 9);
                    SizeFont = new Font("Arial", 6, FontStyle.Bold);
                    ModelNumFont = new Font("Arial", 6, FontStyle.Bold);
                    RetailPriceFont = new Font("Georgia", 17, FontStyle.Bold);

                    float xPos;

                    if (ItmRetailPrice == 1)
                    {
                        xPos = 121.187752f;
                    }
                    else
                    {
                        xPos = (e.PageBounds.Width - 15) - e.Graphics.MeasureString(Convert.ToString(ItmRetailPrice), RetailPriceFont).Width;
                    }

                    g.DrawString(ItmBrand, BrandFont, Brushes.Black, 13, 1);
                    g.DrawString(ItmName, NameFont, Brushes.Black, 13, 10);
                    g.DrawImage(myimg, 10, 20);
                    g.DrawString(ItmUpc, UpcFont, Brushes.Black, 12, 48);
                    g.DrawString(ItmModelNum, ModelNumFont, Brushes.Black, 13, 61);

                    if (ItmSize.Trim().Length != 0 & ItmColor.Trim().Length == 0)
                    {
                        g.DrawString(ItmSize, SizeFont, Brushes.Black, 13, 70);
                    }
                    else if (ItmSize.Trim().Length == 0 & ItmColor.Trim().Length != 0)
                    {
                        g.DrawString(ItmColor, SizeFont, Brushes.Black, 13, 70);
                    }
                    else if (ItmSize.Trim().Length != 0 & ItmColor.Trim().Length != 0)
                    {
                        g.DrawString(ItmSize + " - " + ItmColor, SizeFont, Brushes.Black, 13, 70);
                    }
                    else
                    {
                    }

                    g.DrawString(string.Format("{0:c}", ItmRetailPrice), RetailPriceFont, Brushes.Black, xPos, 56);
                }
            }
        }

        /*private void pdPrint_PrintPage2(object sender, PrintPageEventArgs e)
        {
            if (ItmGroup1 == "2" | ItmGroup1 == "3")
            {
                Graphics g = e.Graphics;
                NameFont = new Font("Arial", 6, FontStyle.Bold);
                UpcFont = new Font("Arial", 5);
                SizeFont = new Font("Arial", 6, FontStyle.Bold);
                RetailPriceFont = new Font("Georgia", 9, FontStyle.Bold);

                float xPos;

                if (ItmRetailPrice == 1)
                {
                    xPos = 61f;
                }
                else
                {
                    xPos = (e.PageBounds.Width - 4) - e.Graphics.MeasureString(Convert.ToString(ItmRetailPrice), RetailPriceFont).Width;
                }

                g.DrawString(ItmSize + " - " + ItmColor, SizeFont, Brushes.Black, 10, 63);

                Brush br = new SolidBrush(Color.Black);

                g.DrawString(ItmName, NameFont, Brushes.Black, 5, 0);
                g.DrawString("*" + ItmUpc + "*", m_BarcodeFont, br, 3, 12);
                g.DrawString(ItmUpc, UpcFont, Brushes.Black, 5, 30);
                g.DrawString(ItmSize + " - " + ItmColor, SizeFont, Brushes.Black, 5, 37);
                g.DrawString(string.Format("{0:$0.00}", ItmRetailPrice), RetailPriceFont, Brushes.Black, xPos, 27);
            }
            else if (ItmGroup1 == "7" & ItmGroup2 == "1")
            {
                Graphics g = e.Graphics;
                NameFont = new Font("Arial", 6, FontStyle.Bold);
                UpcFont = new Font("Arial", 5);
                RetailPriceFont = new Font("Georgia", 9, FontStyle.Bold);

                float xPos = (e.PageBounds.Width - 4) - e.Graphics.MeasureString(Convert.ToString(ItmRetailPrice), RetailPriceFont).Width;

                Brush br = new SolidBrush(Color.Black);

                g.DrawString(ItmName, NameFont, Brushes.Black, 5, 0);
                g.DrawString("*" + ItmUpc + "*", m_BarcodeFont, br, 3, 12);
                g.DrawString(ItmUpc, UpcFont, Brushes.Black, 5, 30);
                g.DrawString(string.Format("{0:$0.00}", ItmRetailPrice), RetailPriceFont, Brushes.Black, xPos, 27);
            }
            else
            {
                Graphics g = e.Graphics;
                NameFont = new Font("Arial", 6, FontStyle.Bold);
                UpcFont = new Font("Arial", 5);
                ModelNumFont = new Font("Arial", 6, FontStyle.Bold);
                RetailPriceFont = new Font("Georgia", 9, FontStyle.Bold);

                float xPos;

                if (ItmRetailPrice == 1)
                {
                    xPos = 61f;
                }
                else
                {
                    xPos = (e.PageBounds.Width - 4) - e.Graphics.MeasureString(Convert.ToString(ItmRetailPrice), RetailPriceFont).Width;
                }

                Brush br = new SolidBrush(Color.Black);

                g.DrawString(ItmName, NameFont, Brushes.Black, 5, 0);
                g.DrawString("*" + ItmUpc + "*", m_BarcodeFont, br, 3, 12);
                g.DrawString(ItmUpc, UpcFont, Brushes.Black, 5, 30);
                g.DrawString(ItmModelNum, ModelNumFont, Brushes.Black, 5, 37);
                g.DrawString(string.Format("{0:$0.00}", ItmRetailPrice), RetailPriceFont, Brushes.Black, xPos, 27);
            }
        }*/

        private void pdPrint_PrintPage2(object sender, PrintPageEventArgs e)
        {
            //Graphics grfx = e.Graphics;
            //System.Drawing.Imaging.Metafile myImage;
            //grfx.DrawString("", this.Font, Brushes.Black, 0, 0);
            //barcode1.PaintOnGraphics(grfx, 0, 0);

            Graphics g = e.Graphics;
            System.Drawing.Imaging.Metafile myImage;
            NameFont = new Font("Arial", 6, FontStyle.Bold);
            //UpcFont = new Font("Arial", 5);
            RetailPriceFont = new Font("Georgia", 9, FontStyle.Bold);

            float xPos = (e.PageBounds.Width - 3) - e.Graphics.MeasureString(Convert.ToString(string.Format("{0:c}", ItmRetailPrice)), RetailPriceFont).Width;

            Brush br = new SolidBrush(Color.Black);

            g.DrawString("", this.Font, Brushes.Black, 0, 0);
            barcode1.PaintOnGraphics(g, 0, 0);
            //g.DrawString(ItmName, NameFont, Brushes.Black, 5, 0);
            //g.DrawString("*" + ItmUpc + "*", m_BarcodeFont, br, 3, 12);
            //g.DrawString(ItmUpc, UpcFont, Brushes.Black, 5, 30);

            if (ItmName.Length > 7)
            {
                g.DrawString(ItmName.Substring(0, 7), NameFont, Brushes.Black, 0, 30);
            }
            else
            {
                g.DrawString(ItmName, NameFont, Brushes.Black, 0, 30);
            }

            g.DrawString(string.Format("{0:c}", ItmRetailPrice), RetailPriceFont, Brushes.Black, xPos, 27);
        }
    }
}