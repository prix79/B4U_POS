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

namespace Management
{
    public partial class WigTagPrinting : Form
    {
        public InventoryMain parentForm;

        public PrintDocument pdPrint;
        public PrintDocument pdPrintRemainder;
        public PrintDialog printDialog;
        public PrintPreviewDialog printPreviewDialog;
        //public Image myimg;

        public Font BrandFont;
        public Font NameFont;
        public Font SizeFont;
        public Font ColorFont;
        public Font BinNumFont;
        public Font RetailPriceFont;

        int i, j, total;

        int pageNum, remainder;
        int tempPageNum;

        string[] ItmBrand = new string[1000];
        string[] ItmName = new string[1000];
        string TempItmName;
        string[] ItmSize = new string[1000];
        string[] ItmColor = new string[1000];
        string[] ItmBinNum = new string[1000];
        double[] ItmRetailPrice = new double[1000];

        public WigTagPrinting()
        {
            InitializeComponent();
        }

        private void WigTagPrinting_Load(object sender, EventArgs e)
        {
            j = 0;
            total = 0;
            ItmName[j] = string.Empty;          
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (rdoBtnIncludingPrice.Checked == true)
            {
                for (i = 0; i < parentForm.dataGridView1.RowCount; i++)
                {
                    if (ItmName[j] == "")
                    {
                        if (parentForm.dataGridView1.Rows[i].Cells[3].Selected == true)
                        {
                            ItmBrand[j] = parentForm.dataGridView1.Rows[i].Cells[2].Value.ToString();
                            ItmName[j] = parentForm.dataGridView1.Rows[i].Cells[3].Value.ToString();
                            ItmSize[j] = parentForm.dataGridView1.Rows[i].Cells[4].Value.ToString();
                            ItmColor[j] = parentForm.dataGridView1.Rows[i].Cells[5].Value.ToString();
                            ItmBinNum[j] = parentForm.dataGridView1.Rows[i].Cells[29].Value.ToString();
                            ItmRetailPrice[j] = Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[15].Value);

                            j += 1;
                        }
                    }
                    else
                    {
                        if (parentForm.dataGridView1.Rows[i].Cells[3].Selected == true)
                        {
                            TempItmName = ItmName[j - 1];

                            if (parentForm.dataGridView1.Rows[i].Cells[3].Value.ToString() == TempItmName)
                            {
                                ItmColor[j - 1] = ItmColor[j - 1] + ", " + parentForm.dataGridView1.Rows[i].Cells[5].Value.ToString();
                            }
                            else
                            {
                                ItmBrand[j] = parentForm.dataGridView1.Rows[i].Cells[2].Value.ToString();
                                ItmName[j] = parentForm.dataGridView1.Rows[i].Cells[3].Value.ToString();
                                ItmSize[j] = parentForm.dataGridView1.Rows[i].Cells[4].Value.ToString();
                                ItmColor[j] = parentForm.dataGridView1.Rows[i].Cells[5].Value.ToString();
                                ItmBinNum[j] = parentForm.dataGridView1.Rows[i].Cells[29].Value.ToString();
                                ItmRetailPrice[j] = Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[15].Value);

                                j += 1;
                            }
                        }
                    }
                }

                pageNum = j / 6;
                remainder = j % 6;
                tempPageNum = 1;

                total = 0;

                pdPrint = new PrintDocument();
                printPreviewDialog = new PrintPreviewDialog();
                printPreviewDialog.Document = pdPrint;
                pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage1);
                printPreviewDialog.ShowDialog();

                DialogResult result = new DialogResult();
                result = printPreviewDialog.ShowDialog();

                this.Close();
            }
            else if (rdoBtnNoPrice.Checked == true)
            {
                for (i = 0; i < parentForm.dataGridView1.RowCount; i++)
                {
                    if (ItmName[j] == "")
                    {
                        if (parentForm.dataGridView1.Rows[i].Cells[3].Selected == true)
                        {
                            ItmBrand[j] = parentForm.dataGridView1.Rows[i].Cells[2].Value.ToString();
                            ItmName[j] = parentForm.dataGridView1.Rows[i].Cells[3].Value.ToString();
                            ItmSize[j] = parentForm.dataGridView1.Rows[i].Cells[4].Value.ToString();
                            ItmColor[j] = parentForm.dataGridView1.Rows[i].Cells[5].Value.ToString();
                            ItmBinNum[j] = parentForm.dataGridView1.Rows[i].Cells[29].Value.ToString();
                            //ItmRetailPrice[j] = Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[15].Value);

                            j += 1;
                        }
                    }
                    else
                    {
                        if (parentForm.dataGridView1.Rows[i].Cells[3].Selected == true)
                        {
                            TempItmName = ItmName[j - 1];

                            if (parentForm.dataGridView1.Rows[i].Cells[3].Value.ToString() == TempItmName)
                            {
                                ItmColor[j - 1] = ItmColor[j - 1] + ", " + parentForm.dataGridView1.Rows[i].Cells[5].Value.ToString();
                            }
                            else
                            {
                                ItmBrand[j] = parentForm.dataGridView1.Rows[i].Cells[2].Value.ToString();
                                ItmName[j] = parentForm.dataGridView1.Rows[i].Cells[3].Value.ToString();
                                ItmSize[j] = parentForm.dataGridView1.Rows[i].Cells[4].Value.ToString();
                                ItmColor[j] = parentForm.dataGridView1.Rows[i].Cells[5].Value.ToString();
                                ItmBinNum[j] = parentForm.dataGridView1.Rows[i].Cells[29].Value.ToString();
                                //ItmRetailPrice[j] = Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[15].Value);

                                j += 1;
                            }
                        }
                    }
                }

                pageNum = j / 6;
                remainder = j % 6;
                tempPageNum = 1;

                total = 0;

                pdPrint = new PrintDocument();
                printPreviewDialog = new PrintPreviewDialog();
                printPreviewDialog.Document = pdPrint;
                pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage2);
                printPreviewDialog.ShowDialog();

                DialogResult result = new DialogResult();
                result = printPreviewDialog.ShowDialog();

                this.Close();
            }
            else if (rdoBtnNew.Checked == true)
            {
                for (i = 0; i < parentForm.dataGridView1.RowCount; i++)
                {
                    if (ItmName[j] == "")
                    {
                        if (parentForm.dataGridView1.Rows[i].Cells[3].Selected == true)
                        {
                            ItmBrand[j] = parentForm.dataGridView1.Rows[i].Cells[2].Value.ToString();
                            ItmName[j] = parentForm.dataGridView1.Rows[i].Cells[3].Value.ToString();
                            ItmSize[j] = parentForm.dataGridView1.Rows[i].Cells[4].Value.ToString();
                            ItmColor[j] = parentForm.dataGridView1.Rows[i].Cells[5].Value.ToString();
                            ItmBinNum[j] = parentForm.dataGridView1.Rows[i].Cells[29].Value.ToString();
                            ItmRetailPrice[j] = Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[15].Value);

                            j += 1;
                        }
                    }
                    else
                    {
                        if (parentForm.dataGridView1.Rows[i].Cells[3].Selected == true)
                        {
                            TempItmName = ItmName[j - 1];

                            if (parentForm.dataGridView1.Rows[i].Cells[3].Value.ToString() == TempItmName)
                            {
                                ItmColor[j - 1] = ItmColor[j - 1] + ", " + parentForm.dataGridView1.Rows[i].Cells[5].Value.ToString();
                            }
                            else
                            {
                                ItmBrand[j] = parentForm.dataGridView1.Rows[i].Cells[2].Value.ToString();
                                ItmName[j] = parentForm.dataGridView1.Rows[i].Cells[3].Value.ToString();
                                ItmSize[j] = parentForm.dataGridView1.Rows[i].Cells[4].Value.ToString();
                                ItmColor[j] = parentForm.dataGridView1.Rows[i].Cells[5].Value.ToString();
                                ItmBinNum[j] = parentForm.dataGridView1.Rows[i].Cells[29].Value.ToString();
                                ItmRetailPrice[j] = Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[15].Value);

                                j += 1;
                            }
                        }
                    }
                }

                if (j == 0)
                {
                    MessageBox.Show("SELECT ITEM YOU WANT TO PRINT FIRST", "ERROR");
                    return;
                }

                pageNum = j / 18;
                remainder = j % 18;
                tempPageNum = 1;

                total = 0;

                pdPrint = new PrintDocument();
                printPreviewDialog = new PrintPreviewDialog();
                printPreviewDialog.Document = pdPrint;
                pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage4);
                printPreviewDialog.ShowDialog();

                DialogResult result = new DialogResult();
                result = printPreviewDialog.ShowDialog();

                this.Close();
            }
            else if (rdoBtnPriceTag.Checked == true)
            {
                for (i = 0; i < parentForm.dataGridView1.RowCount; i++)
                {
                    if (parentForm.dataGridView1.Rows[i].Cells[3].Selected == true)
                    {
                        ItmRetailPrice[j] = Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[15].Value);

                        j += 1;
                    }
                }

                pageNum = j;
                tempPageNum = 1;

                pdPrint = new PrintDocument();
                printPreviewDialog = new PrintPreviewDialog();
                //printPreviewDialog.UseEXDialog = true;
                printPreviewDialog.Document = pdPrint;
                pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage3);
                printPreviewDialog.ShowDialog();

                DialogResult result = new DialogResult();
                result = printDialog.ShowDialog();

                this.Close();
            }
            else if (rdoBtnWigTag3.Checked == true)
            {
                for (i = 0; i < parentForm.dataGridView1.RowCount; i++)
                {
                    if (ItmName[j] == "")
                    {
                        if (parentForm.dataGridView1.Rows[i].Cells[3].Selected == true)
                        {
                            ItmBrand[j] = parentForm.dataGridView1.Rows[i].Cells[2].Value.ToString();
                            ItmName[j] = parentForm.dataGridView1.Rows[i].Cells[3].Value.ToString();
                            ItmSize[j] = parentForm.dataGridView1.Rows[i].Cells[4].Value.ToString();
                            ItmColor[j] = parentForm.dataGridView1.Rows[i].Cells[5].Value.ToString();
                            ItmBinNum[j] = parentForm.dataGridView1.Rows[i].Cells[29].Value.ToString();
                            ItmRetailPrice[j] = Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[15].Value);

                            j += 1;
                        }
                    }
                    else
                    {
                        if (parentForm.dataGridView1.Rows[i].Cells[3].Selected == true)
                        {
                            TempItmName = ItmName[j - 1];

                            if (parentForm.dataGridView1.Rows[i].Cells[3].Value.ToString() == TempItmName)
                            {
                                ItmColor[j - 1] = ItmColor[j - 1] + ", " + parentForm.dataGridView1.Rows[i].Cells[5].Value.ToString();
                            }
                            else
                            {
                                ItmBrand[j] = parentForm.dataGridView1.Rows[i].Cells[2].Value.ToString();
                                ItmName[j] = parentForm.dataGridView1.Rows[i].Cells[3].Value.ToString();
                                ItmSize[j] = parentForm.dataGridView1.Rows[i].Cells[4].Value.ToString();
                                ItmColor[j] = parentForm.dataGridView1.Rows[i].Cells[5].Value.ToString();
                                ItmBinNum[j] = parentForm.dataGridView1.Rows[i].Cells[29].Value.ToString();
                                ItmRetailPrice[j] = Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[15].Value);

                                j += 1;
                            }
                        }
                    }
                }

                if (j == 0)
                {
                    MessageBox.Show("SELECT ITEM YOU WANT TO PRINT FIRST", "ERROR");
                    return;
                }

                pageNum = j / 16;
                remainder = j % 16;
                tempPageNum = 1;

                total = 0;

                pdPrint = new PrintDocument();
                printPreviewDialog = new PrintPreviewDialog();
                printPreviewDialog.Document = pdPrint;
                pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage5);
                printPreviewDialog.ShowDialog();

                DialogResult result = new DialogResult();
                result = printPreviewDialog.ShowDialog();

                this.Close();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (rdoBtnIncludingPrice.Checked == true)
            {
                for (i = 0; i < parentForm.dataGridView1.RowCount; i++)
                {
                    if (ItmName[j] == "")
                    {
                        if (parentForm.dataGridView1.Rows[i].Cells[3].Selected == true)
                        {
                            ItmBrand[j] = parentForm.dataGridView1.Rows[i].Cells[2].Value.ToString();
                            ItmName[j] = parentForm.dataGridView1.Rows[i].Cells[3].Value.ToString();
                            ItmSize[j] = parentForm.dataGridView1.Rows[i].Cells[4].Value.ToString();
                            ItmColor[j] = parentForm.dataGridView1.Rows[i].Cells[5].Value.ToString();
                            ItmBinNum[j] = parentForm.dataGridView1.Rows[i].Cells[29].Value.ToString();
                            ItmRetailPrice[j] = Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[15].Value);

                            j += 1;
                        }
                    }
                    else
                    {
                        if (parentForm.dataGridView1.Rows[i].Cells[3].Selected == true)
                        {
                            TempItmName = ItmName[j - 1];

                            if (parentForm.dataGridView1.Rows[i].Cells[3].Value.ToString() == TempItmName)
                            {
                                ItmColor[j - 1] = ItmColor[j - 1] + ", " + parentForm.dataGridView1.Rows[i].Cells[5].Value.ToString();
                            }
                            else
                            {
                                ItmBrand[j] = parentForm.dataGridView1.Rows[i].Cells[2].Value.ToString();
                                ItmName[j] = parentForm.dataGridView1.Rows[i].Cells[3].Value.ToString();
                                ItmSize[j] = parentForm.dataGridView1.Rows[i].Cells[4].Value.ToString();
                                ItmColor[j] = parentForm.dataGridView1.Rows[i].Cells[5].Value.ToString();
                                ItmBinNum[j] = parentForm.dataGridView1.Rows[i].Cells[29].Value.ToString();
                                ItmRetailPrice[j] = Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[15].Value);

                                j += 1;
                            }
                        }
                    }
                }

                if (j == 0)
                {
                    MessageBox.Show("SELECT ITEM YOU WANT TO PRINT FIRST", "ERROR");
                    return;
                }

                pageNum = j / 6;
                remainder = j % 6;
                tempPageNum = 1;

                pdPrint = new PrintDocument();
                printDialog = new PrintDialog();
                printDialog.UseEXDialog = true;
                printDialog.Document = pdPrint;
                pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage1);

                DialogResult result = new DialogResult();
                result = printDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    pdPrint.Print();
                }

                this.Close();
            }
            else if (rdoBtnNoPrice.Checked == true)
            {
                for (i = 0; i < parentForm.dataGridView1.RowCount; i++)
                {
                    if (ItmName[j] == "")
                    {
                        if (parentForm.dataGridView1.Rows[i].Cells[3].Selected == true)
                        {
                            ItmBrand[j] = parentForm.dataGridView1.Rows[i].Cells[2].Value.ToString();
                            ItmName[j] = parentForm.dataGridView1.Rows[i].Cells[3].Value.ToString();
                            ItmSize[j] = parentForm.dataGridView1.Rows[i].Cells[4].Value.ToString();
                            ItmColor[j] = parentForm.dataGridView1.Rows[i].Cells[5].Value.ToString();
                            ItmBinNum[j] = parentForm.dataGridView1.Rows[i].Cells[29].Value.ToString();
                            //ItmRetailPrice[j] = Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[15].Value);

                            j += 1;
                        }
                    }
                    else
                    {
                        if (parentForm.dataGridView1.Rows[i].Cells[3].Selected == true)
                        {
                            TempItmName = ItmName[j - 1];

                            if (parentForm.dataGridView1.Rows[i].Cells[3].Value.ToString() == TempItmName)
                            {
                                ItmColor[j - 1] = ItmColor[j - 1] + ", " + parentForm.dataGridView1.Rows[i].Cells[5].Value.ToString();
                            }
                            else
                            {
                                ItmBrand[j] = parentForm.dataGridView1.Rows[i].Cells[2].Value.ToString();
                                ItmName[j] = parentForm.dataGridView1.Rows[i].Cells[3].Value.ToString();
                                ItmSize[j] = parentForm.dataGridView1.Rows[i].Cells[4].Value.ToString();
                                ItmColor[j] = parentForm.dataGridView1.Rows[i].Cells[5].Value.ToString();
                                ItmBinNum[j] = parentForm.dataGridView1.Rows[i].Cells[29].Value.ToString();
                                //ItmRetailPrice[j] = Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[15].Value);

                                j += 1;
                            }
                        }
                    }
                }

                if (j == 0)
                {
                    MessageBox.Show("SELECT ITEM YOU WANT TO PRINT FIRST", "ERROR");
                    return;
                }

                pageNum = j / 6;
                remainder = j % 6;
                tempPageNum = 1;

                pdPrint = new PrintDocument();
                printDialog = new PrintDialog();
                printDialog.UseEXDialog = true;
                printDialog.Document = pdPrint;
                pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage2);

                DialogResult result = new DialogResult();
                result = printDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    pdPrint.Print();
                }

                this.Close();
            }
            else if (rdoBtnPriceTag.Checked == true)
            {
                for (i = 0; i < parentForm.dataGridView1.RowCount; i++)
                {
                    if (parentForm.dataGridView1.Rows[i].Cells[3].Selected == true)
                    {
                        ItmRetailPrice[j] = Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[15].Value);

                        j += 1;
                    }
                }

                pageNum = j;
                tempPageNum = 1;

                pdPrint = new PrintDocument();
                printDialog = new PrintDialog();
                printDialog.UseEXDialog = true;
                printDialog.Document = pdPrint;
                pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage3);

                DialogResult result = new DialogResult();
                result = printDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    pdPrint.Print();
                }

                this.Close();
            }
            else if (rdoBtnNew.Checked == true)
            {
                for (i = 0; i < parentForm.dataGridView1.RowCount; i++)
                {
                    if (ItmName[j] == "")
                    {
                        if (parentForm.dataGridView1.Rows[i].Cells[3].Selected == true)
                        {
                            ItmBrand[j] = parentForm.dataGridView1.Rows[i].Cells[2].Value.ToString();
                            ItmName[j] = parentForm.dataGridView1.Rows[i].Cells[3].Value.ToString();
                            ItmSize[j] = parentForm.dataGridView1.Rows[i].Cells[4].Value.ToString();
                            ItmColor[j] = parentForm.dataGridView1.Rows[i].Cells[5].Value.ToString();
                            ItmBinNum[j] = parentForm.dataGridView1.Rows[i].Cells[29].Value.ToString();
                            ItmRetailPrice[j] = Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[15].Value);

                            j += 1;
                        }
                    }
                    else
                    {
                        if (parentForm.dataGridView1.Rows[i].Cells[3].Selected == true)
                        {
                            TempItmName = ItmName[j - 1];

                            if (parentForm.dataGridView1.Rows[i].Cells[3].Value.ToString() == TempItmName)
                            {
                                ItmColor[j - 1] = ItmColor[j - 1] + ", " + parentForm.dataGridView1.Rows[i].Cells[5].Value.ToString();
                            }
                            else
                            {
                                ItmBrand[j] = parentForm.dataGridView1.Rows[i].Cells[2].Value.ToString();
                                ItmName[j] = parentForm.dataGridView1.Rows[i].Cells[3].Value.ToString();
                                ItmSize[j] = parentForm.dataGridView1.Rows[i].Cells[4].Value.ToString();
                                ItmColor[j] = parentForm.dataGridView1.Rows[i].Cells[5].Value.ToString();
                                ItmBinNum[j] = parentForm.dataGridView1.Rows[i].Cells[29].Value.ToString();
                                ItmRetailPrice[j] = Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[15].Value);

                                j += 1;
                            }
                        }
                    }
                }

                if (j == 0)
                {
                    MessageBox.Show("SELECT ITEM YOU WANT TO PRINT FIRST", "ERROR");
                    return;
                }

                pageNum = j / 18;
                remainder = j % 18;
                tempPageNum = 1;

                pdPrint = new PrintDocument();
                printDialog = new PrintDialog();
                printDialog.UseEXDialog = true;
                printDialog.Document = pdPrint;
                pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage4);

                DialogResult result = new DialogResult();
                result = printDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    pdPrint.Print();
                }

                this.Close();
            }
            else if (rdoBtnWigTag3.Checked == true)
            {
                for (i = 0; i < parentForm.dataGridView1.RowCount; i++)
                {
                    if (ItmName[j] == "")
                    {
                        if (parentForm.dataGridView1.Rows[i].Cells[3].Selected == true)
                        {
                            ItmBrand[j] = parentForm.dataGridView1.Rows[i].Cells[2].Value.ToString();
                            ItmName[j] = parentForm.dataGridView1.Rows[i].Cells[3].Value.ToString();
                            ItmSize[j] = parentForm.dataGridView1.Rows[i].Cells[4].Value.ToString();
                            ItmColor[j] = parentForm.dataGridView1.Rows[i].Cells[5].Value.ToString();
                            ItmBinNum[j] = parentForm.dataGridView1.Rows[i].Cells[29].Value.ToString();
                            ItmRetailPrice[j] = Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[15].Value);

                            j += 1;
                        }
                    }
                    else
                    {
                        if (parentForm.dataGridView1.Rows[i].Cells[3].Selected == true)
                        {
                            TempItmName = ItmName[j - 1];

                            if (parentForm.dataGridView1.Rows[i].Cells[3].Value.ToString() == TempItmName)
                            {
                                ItmColor[j - 1] = ItmColor[j - 1] + ", " + parentForm.dataGridView1.Rows[i].Cells[5].Value.ToString();
                            }
                            else
                            {
                                ItmBrand[j] = parentForm.dataGridView1.Rows[i].Cells[2].Value.ToString();
                                ItmName[j] = parentForm.dataGridView1.Rows[i].Cells[3].Value.ToString();
                                ItmSize[j] = parentForm.dataGridView1.Rows[i].Cells[4].Value.ToString();
                                ItmColor[j] = parentForm.dataGridView1.Rows[i].Cells[5].Value.ToString();
                                ItmBinNum[j] = parentForm.dataGridView1.Rows[i].Cells[29].Value.ToString();
                                ItmRetailPrice[j] = Convert.ToDouble(parentForm.dataGridView1.Rows[i].Cells[15].Value);

                                j += 1;
                            }
                        }
                    }
                }

                if (j == 0)
                {
                    MessageBox.Show("SELECT ITEM YOU WANT TO PRINT FIRST", "ERROR");
                    return;
                }

                pageNum = j / 16;
                remainder = j % 16;
                tempPageNum = 1;

                total = 0;

                pdPrint = new PrintDocument();
                printDialog = new PrintDialog();
                printDialog.UseEXDialog = true;
                printDialog.Document = pdPrint;
                pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage5);

                DialogResult result = new DialogResult();
                result = printDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    pdPrint.Print();
                }

                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pdPrint_PrintPage1(object sender, PrintPageEventArgs e)
        {
            BrandFont = new Font("Arial", 15, FontStyle.Bold);
            NameFont = new Font("Georgia", 25, FontStyle.Bold);
            BinNumFont = new Font("Arial", 15, FontStyle.Bold);
            SizeFont = new Font("Arial", 15, FontStyle.Bold);
            ColorFont = new Font("Arial", 10, FontStyle.Bold);
            RetailPriceFont = new Font("Impact", 28, FontStyle.Italic);

            Graphics g = e.Graphics;
            //Image img = new Bitmap("Blue hills.jpg");
            //TextureBrush tBrush = new TextureBrush(img);
            //tBrush.WrapMode = WrapMode.Clamp;

            //g.FillRectangle(tBrush, this.ClientRectangle);
            g.FillRectangle(Brushes.White, this.ClientRectangle);

            StringFormat sf = new StringFormat();
            StringFormat sf2 = new StringFormat();
            StringFormat sf3 = new StringFormat();

            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            sf2.Alignment = StringAlignment.Near;
            sf2.LineAlignment = StringAlignment.Center;
            sf3.Alignment = StringAlignment.Far;
            sf3.LineAlignment = StringAlignment.Center;

            if (remainder == 0)
            {
                if (tempPageNum < pageNum)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        Rectangle r = new Rectangle(60, 20 + (k * 262), 421, 242);
                        Rectangle rName = new Rectangle(62, 30 + (k * 262), 416, NameFont.Height);
                        Rectangle rRetailPrice = new Rectangle(62, 105 + (k * 262), 416, RetailPriceFont.Height);
                        Rectangle rColor = new Rectangle(62, 150 + (k * 262), 416, ColorFont.Height * 2);
                        Rectangle rBrandSize = new Rectangle(62, 230 + (k * 262), 350, BrandFont.Height);
                        Rectangle rBinNum = new Rectangle(397, 230 + (k * 262), 80, BinNumFont.Height);
                        g.DrawRectangle(Pens.Black, r);
                        g.DrawRectangle(Pens.White, rName);
                        g.DrawRectangle(Pens.White, rRetailPrice);
                        g.DrawRectangle(Pens.White, rColor);

                        g.DrawString(ItmName[total], NameFont, Brushes.Black, rName, sf);
                        g.DrawString(string.Format("{0:c}", ItmRetailPrice[total]), RetailPriceFont, Brushes.Black, rRetailPrice, sf);
                        g.DrawString(ItmColor[total], ColorFont, Brushes.Black, rColor, sf);
                        g.DrawString(ItmBrand[total] + "   " + ItmSize[total], BrandFont, Brushes.Black, rBrandSize, sf2);
                        g.DrawString(ItmBinNum[total], BinNumFont, Brushes.Black, rBinNum, sf3);

                        total += 1;
                    }

                    int l = 0;

                    for (int k = 3; k < 6; k++)
                    {
                        Rectangle r = new Rectangle(60 + (465), 20 + (l * 262), 421, 242);
                        Rectangle rName = new Rectangle(62 + (465), 30 + (l * 262), 416, NameFont.Height);
                        Rectangle rRetailPrice = new Rectangle(62 + (465), 105 + (l * 262), 416, RetailPriceFont.Height);
                        Rectangle rColor = new Rectangle(62 + (465), 150 + (l * 262), 416, ColorFont.Height * 2);
                        Rectangle rBrandSize = new Rectangle(62 + (465), 230 + (l * 262), 350, BrandFont.Height);
                        Rectangle rBinNum = new Rectangle(397 + (465), 230 + (l * 262), 80, BinNumFont.Height);
                        g.DrawRectangle(Pens.Black, r);
                        g.DrawRectangle(Pens.White, rName);
                        g.DrawRectangle(Pens.White, rRetailPrice);
                        g.DrawRectangle(Pens.White, rColor);

                        g.DrawString(ItmName[total], NameFont, Brushes.Black, rName, sf);
                        g.DrawString(string.Format("{0:c}", ItmRetailPrice[total]), RetailPriceFont, Brushes.Black, rRetailPrice, sf);
                        g.DrawString(ItmColor[total], ColorFont, Brushes.Black, rColor, sf);
                        g.DrawString(ItmBrand[total] + "   " + ItmSize[total], BrandFont, Brushes.Black, rBrandSize, sf2);
                        g.DrawString(ItmBinNum[total], BinNumFont, Brushes.Black, rBinNum, sf3);

                        l += 1;
                        total += 1;
                    }

                    tempPageNum += 1;
                    e.HasMorePages = true;
                }
                else
                {
                    for (int k = 0; k < 3; k++)
                    {
                        Rectangle r = new Rectangle(60, 20 + (k * 262), 421, 242);
                        Rectangle rName = new Rectangle(62, 30 + (k * 262), 416, NameFont.Height);
                        Rectangle rRetailPrice = new Rectangle(62, 105 + (k * 262), 416, RetailPriceFont.Height);
                        Rectangle rColor = new Rectangle(62, 150 + (k * 262), 416, ColorFont.Height * 2);
                        Rectangle rBrandSize = new Rectangle(62, 230 + (k * 262), 350, BrandFont.Height);
                        Rectangle rBinNum = new Rectangle(397, 230 + (k * 262), 80, BinNumFont.Height);
                        g.DrawRectangle(Pens.Black, r);
                        g.DrawRectangle(Pens.White, rName);
                        g.DrawRectangle(Pens.White, rRetailPrice);
                        g.DrawRectangle(Pens.White, rColor);

                        g.DrawString(ItmName[total], NameFont, Brushes.Black, rName, sf);
                        g.DrawString(string.Format("{0:c}", ItmRetailPrice[total]), RetailPriceFont, Brushes.Black, rRetailPrice, sf);
                        g.DrawString(ItmColor[total], ColorFont, Brushes.Black, rColor, sf);
                        g.DrawString(ItmBrand[total] + "   " + ItmSize[total], BrandFont, Brushes.Black, rBrandSize, sf2);
                        g.DrawString(ItmBinNum[total], BinNumFont, Brushes.Black, rBinNum, sf3);

                        total += 1;
                    }

                    int l = 0;

                    for (int k = 3; k < 6; k++)
                    {
                        Rectangle r = new Rectangle(60 + (465), 20 + (l * 262), 421, 242);
                        Rectangle rName = new Rectangle(62 + (465), 30 + (l * 262), 416, NameFont.Height);
                        Rectangle rRetailPrice = new Rectangle(62 + (465), 105 + (l * 262), 416, RetailPriceFont.Height);
                        Rectangle rColor = new Rectangle(62 + (465), 150 + (l * 262), 416, ColorFont.Height * 2);
                        Rectangle rBrandSize = new Rectangle(62 + (465), 230 + (l * 262), 350, BrandFont.Height);
                        Rectangle rBinNum = new Rectangle(397 + (465), 230 + (l * 262), 80, BinNumFont.Height);
                        g.DrawRectangle(Pens.Black, r);
                        g.DrawRectangle(Pens.White, rName);
                        g.DrawRectangle(Pens.White, rRetailPrice);
                        g.DrawRectangle(Pens.White, rColor);

                        g.DrawString(ItmName[total], NameFont, Brushes.Black, rName, sf);
                        g.DrawString(string.Format("{0:c}", ItmRetailPrice[total]), RetailPriceFont, Brushes.Black, rRetailPrice, sf);
                        g.DrawString(ItmColor[total], ColorFont, Brushes.Black, rColor, sf);
                        g.DrawString(ItmBrand[total] + "   " + ItmSize[total], BrandFont, Brushes.Black, rBrandSize, sf2);
                        g.DrawString(ItmBinNum[total], BinNumFont, Brushes.Black, rBinNum, sf3);

                        l += 1;
                        total += 1;
                    }

                    tempPageNum += 1;
                    e.HasMorePages = false;
                }
            }
            else
            {
                if (tempPageNum <= pageNum)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        Rectangle r = new Rectangle(60, 20 + (k * 262), 421, 242);
                        Rectangle rName = new Rectangle(62, 30 + (k * 262), 416, NameFont.Height);
                        Rectangle rRetailPrice = new Rectangle(62, 105 + (k * 262), 416, RetailPriceFont.Height);
                        Rectangle rColor = new Rectangle(62, 150 + (k * 262), 416, ColorFont.Height * 2);
                        Rectangle rBrandSize = new Rectangle(62, 230 + (k * 262), 350, BrandFont.Height);
                        Rectangle rBinNum = new Rectangle(397, 230 + (k * 262), 80, BinNumFont.Height);
                        g.DrawRectangle(Pens.Black, r);
                        g.DrawRectangle(Pens.White, rName);
                        g.DrawRectangle(Pens.White, rRetailPrice);
                        g.DrawRectangle(Pens.White, rColor);

                        g.DrawString(ItmName[total], NameFont, Brushes.Black, rName, sf);
                        g.DrawString(string.Format("{0:c}", ItmRetailPrice[total]), RetailPriceFont, Brushes.Black, rRetailPrice, sf);
                        g.DrawString(ItmColor[total], ColorFont, Brushes.Black, rColor, sf);
                        g.DrawString(ItmBrand[total] + "   " + ItmSize[total], BrandFont, Brushes.Black, rBrandSize, sf2);
                        g.DrawString(ItmBinNum[total], BinNumFont, Brushes.Black, rBinNum, sf3);

                        total += 1;
                    }

                    int l = 0;

                    for (int k = 3; k < 6; k++)
                    {
                        Rectangle r = new Rectangle(60 + (465), 20 + (l * 262), 421, 242);
                        Rectangle rName = new Rectangle(62 + (465), 30 + (l * 262), 416, NameFont.Height);
                        Rectangle rRetailPrice = new Rectangle(62 + (465), 105 + (l * 262), 416, RetailPriceFont.Height);
                        Rectangle rColor = new Rectangle(62 + (465), 150 + (l * 262), 416, ColorFont.Height * 2);
                        Rectangle rBrandSize = new Rectangle(62 + (465), 230 + (l * 262), 350, BrandFont.Height);
                        Rectangle rBinNum = new Rectangle(397 + (465), 230 + (l * 262), 80, BinNumFont.Height);
                        g.DrawRectangle(Pens.Black, r);
                        g.DrawRectangle(Pens.White, rName);
                        g.DrawRectangle(Pens.White, rRetailPrice);
                        g.DrawRectangle(Pens.White, rColor);

                        g.DrawString(ItmName[total], NameFont, Brushes.Black, rName, sf);
                        g.DrawString(string.Format("{0:c}", ItmRetailPrice[total]), RetailPriceFont, Brushes.Black, rRetailPrice, sf);
                        g.DrawString(ItmColor[total], ColorFont, Brushes.Black, rColor, sf);
                        g.DrawString(ItmBrand[total] + "   " + ItmSize[total], BrandFont, Brushes.Black, rBrandSize, sf2);
                        g.DrawString(ItmBinNum[total], BinNumFont, Brushes.Black, rBinNum, sf3);

                        l += 1;
                        total += 1;
                    }

                    tempPageNum += 1;
                    e.HasMorePages = true;
                }
                else
                {
                    if (remainder < 4 & remainder > 0)
                    {
                        for (int k = 0; k < remainder; k++)
                        {
                            Rectangle r = new Rectangle(60, 20 + (k * 262), 421, 242);
                            Rectangle rName = new Rectangle(62, 30 + (k * 262), 416, NameFont.Height);
                            Rectangle rRetailPrice = new Rectangle(62, 105 + (k * 262), 416, RetailPriceFont.Height);
                            Rectangle rColor = new Rectangle(62, 150 + (k * 262), 416, ColorFont.Height * 2);
                            Rectangle rBrandSize = new Rectangle(62, 230 + (k * 262), 350, BrandFont.Height);
                            Rectangle rBinNum = new Rectangle(397, 230 + (k * 262), 80, BinNumFont.Height);
                            g.DrawRectangle(Pens.Black, r);
                            g.DrawRectangle(Pens.White, rName);
                            g.DrawRectangle(Pens.White, rRetailPrice);
                            g.DrawRectangle(Pens.White, rColor);

                            g.DrawString(ItmName[total], NameFont, Brushes.Black, rName, sf);
                            g.DrawString(string.Format("{0:c}", ItmRetailPrice[total]), RetailPriceFont, Brushes.Black, rRetailPrice, sf);
                            g.DrawString(ItmColor[total], ColorFont, Brushes.Black, rColor, sf);
                            g.DrawString(ItmBrand[total] + "   " + ItmSize[total], BrandFont, Brushes.Black, rBrandSize, sf2);
                            g.DrawString(ItmBinNum[total], BinNumFont, Brushes.Black, rBinNum, sf3);

                            total += 1;
                        }

                        e.HasMorePages = false;
                    }
                    else
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            Rectangle r = new Rectangle(60, 20 + (k * 262), 421, 242);
                            Rectangle rName = new Rectangle(62, 30 + (k * 262), 416, NameFont.Height);
                            Rectangle rRetailPrice = new Rectangle(62, 105 + (k * 262), 416, RetailPriceFont.Height);
                            Rectangle rColor = new Rectangle(62, 150 + (k * 262), 416, ColorFont.Height * 2);
                            Rectangle rBrandSize = new Rectangle(62, 230 + (k * 262), 350, BrandFont.Height);
                            Rectangle rBinNum = new Rectangle(397, 230 + (k * 262), 80, BinNumFont.Height);
                            g.DrawRectangle(Pens.Black, r);
                            g.DrawRectangle(Pens.White, rName);
                            g.DrawRectangle(Pens.White, rRetailPrice);
                            g.DrawRectangle(Pens.White, rColor);

                            g.DrawString(ItmName[total], NameFont, Brushes.Black, rName, sf);
                            g.DrawString(string.Format("{0:c}", ItmRetailPrice[total]), RetailPriceFont, Brushes.Black, rRetailPrice, sf);
                            g.DrawString(ItmColor[total], ColorFont, Brushes.Black, rColor, sf);
                            g.DrawString(ItmBrand[total] + "   " + ItmSize[total], BrandFont, Brushes.Black, rBrandSize, sf2);
                            g.DrawString(ItmBinNum[total], BinNumFont, Brushes.Black, rBinNum, sf3);

                            total += 1;
                        }

                        int l = 0;

                        for (int k = 3; k < remainder; k++)
                        {
                            Rectangle r = new Rectangle(60 + (465), 20 + (l * 262), 421, 242);
                            Rectangle rName = new Rectangle(62 + (465), 30 + (l * 262), 416, NameFont.Height);
                            Rectangle rRetailPrice = new Rectangle(62 + (465), 105 + (l * 262), 416, RetailPriceFont.Height);
                            Rectangle rColor = new Rectangle(62 + (465), 150 + (l * 262), 416, ColorFont.Height * 2);
                            Rectangle rBrandSize = new Rectangle(62 + (465), 230 + (l * 262), 350, BrandFont.Height);
                            Rectangle rBinNum = new Rectangle(397 + (465), 230 + (l * 262), 80, BinNumFont.Height);
                            g.DrawRectangle(Pens.Black, r);
                            g.DrawRectangle(Pens.White, rName);
                            g.DrawRectangle(Pens.White, rRetailPrice);
                            g.DrawRectangle(Pens.White, rColor);

                            g.DrawString(ItmName[total], NameFont, Brushes.Black, rName, sf);
                            g.DrawString(string.Format("{0:c}", ItmRetailPrice[total]), RetailPriceFont, Brushes.Black, rRetailPrice, sf);
                            g.DrawString(ItmColor[total], ColorFont, Brushes.Black, rColor, sf);
                            g.DrawString(ItmBrand[total] + "   " + ItmSize[total], BrandFont, Brushes.Black, rBrandSize, sf2);
                            g.DrawString(ItmBinNum[total], BinNumFont, Brushes.Black, rBinNum, sf3);

                            l += 1;
                            total += 1;
                        }

                        e.HasMorePages = false;
                    }

                    //e.HasMorePages = false;
                }
            }
        }

        private void pdPrint_PrintPage2(object sender, PrintPageEventArgs e)
        {
            BrandFont = new Font("Arial", 15, FontStyle.Bold);
            NameFont = new Font("Georgia", 25, FontStyle.Bold);
            BinNumFont = new Font("Arial", 15, FontStyle.Bold);
            SizeFont = new Font("Arial", 15, FontStyle.Bold);
            ColorFont = new Font("Arial", 10, FontStyle.Bold);
            //RetailPriceFont = new Font("Impact", 28, FontStyle.Italic);
            RetailPriceFont = new Font("Impact", 28, FontStyle.Bold);

            Graphics g = e.Graphics;
            //Image img = new Bitmap("Blue hills.jpg");
            //TextureBrush tBrush = new TextureBrush(img);
            //tBrush.WrapMode = WrapMode.Clamp;

            //g.FillRectangle(tBrush, this.ClientRectangle);
            g.FillRectangle(Brushes.White, this.ClientRectangle);

            StringFormat sf = new StringFormat();
            StringFormat sf2 = new StringFormat();
            StringFormat sf3 = new StringFormat();

            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            sf2.Alignment = StringAlignment.Near;
            sf2.LineAlignment = StringAlignment.Center;
            sf3.Alignment = StringAlignment.Far;
            sf3.LineAlignment = StringAlignment.Center;

            if (tempPageNum <= pageNum)
            {
                for (int k = 0; k < 3; k++)
                {
                    Rectangle r = new Rectangle(60, 20 + (k * 262), 421, 242);
                    Rectangle rName = new Rectangle(62, 30 + (k * 262), 416, NameFont.Height);
                    Rectangle rRetailPrice = new Rectangle(62, 105 + (k * 262), 416, RetailPriceFont.Height);
                    Rectangle rColor = new Rectangle(62, 150 + (k * 262), 416, ColorFont.Height * 2);
                    Rectangle rBrandSize = new Rectangle(62, 230 + (k * 262), 350, BrandFont.Height);
                    Rectangle rBinNum = new Rectangle(397, 230 + (k * 262), 80, BinNumFont.Height);
                    g.DrawRectangle(Pens.Black, r);
                    g.DrawRectangle(Pens.White, rName);
                    g.DrawRectangle(Pens.White, rRetailPrice);
                    g.DrawRectangle(Pens.White, rColor);

                    g.DrawString(ItmName[total], NameFont, Brushes.Black, rName, sf);
                    g.DrawString(ItmSize[total], RetailPriceFont, Brushes.Black, rRetailPrice, sf);
                    g.DrawString(ItmColor[total], ColorFont, Brushes.Black, rColor, sf);
                    g.DrawString(ItmBrand[total], BrandFont, Brushes.Black, rBrandSize, sf2);
                    g.DrawString(ItmBinNum[total], BinNumFont, Brushes.Black, rBinNum, sf3);

                    total += 1;
                }

                int l = 0;

                for (int k = 3; k < 6; k++)
                {
                    Rectangle r = new Rectangle(60 + (465), 20 + (l * 262), 421, 242);
                    Rectangle rName = new Rectangle(62 + (465), 30 + (l * 262), 416, NameFont.Height);
                    Rectangle rRetailPrice = new Rectangle(62 + (465), 105 + (l * 262), 416, RetailPriceFont.Height);
                    Rectangle rColor = new Rectangle(62 + (465), 150 + (l * 262), 416, ColorFont.Height * 2);
                    Rectangle rBrandSize = new Rectangle(62 + (465), 230 + (l * 262), 350, BrandFont.Height);
                    Rectangle rBinNum = new Rectangle(397 + (465), 230 + (l * 262), 80, BinNumFont.Height);
                    g.DrawRectangle(Pens.Black, r);
                    g.DrawRectangle(Pens.White, rName);
                    g.DrawRectangle(Pens.White, rRetailPrice);
                    g.DrawRectangle(Pens.White, rColor);

                    g.DrawString(ItmName[total], NameFont, Brushes.Black, rName, sf);
                    g.DrawString(ItmSize[total], RetailPriceFont, Brushes.Black, rRetailPrice, sf);
                    g.DrawString(ItmColor[total], ColorFont, Brushes.Black, rColor, sf);
                    g.DrawString(ItmBrand[total], BrandFont, Brushes.Black, rBrandSize, sf2);
                    g.DrawString(ItmBinNum[total], BinNumFont, Brushes.Black, rBinNum, sf3);

                    l += 1;
                    total += 1;
                }

                tempPageNum += 1;
                e.HasMorePages = true;
            }
            else
            {
                if (remainder < 4 & remainder > 0)
                {
                    for (int k = 0; k < remainder; k++)
                    {
                        Rectangle r = new Rectangle(60, 20 + (k * 262), 421, 242);
                        Rectangle rName = new Rectangle(62, 30 + (k * 262), 416, NameFont.Height);
                        Rectangle rRetailPrice = new Rectangle(62, 105 + (k * 262), 416, RetailPriceFont.Height);
                        Rectangle rColor = new Rectangle(62, 150 + (k * 262), 416, ColorFont.Height * 2);
                        Rectangle rBrandSize = new Rectangle(62, 230 + (k * 262), 350, BrandFont.Height);
                        Rectangle rBinNum = new Rectangle(397, 230 + (k * 262), 80, BinNumFont.Height);
                        g.DrawRectangle(Pens.Black, r);
                        g.DrawRectangle(Pens.White, rName);
                        g.DrawRectangle(Pens.White, rRetailPrice);
                        g.DrawRectangle(Pens.White, rColor);

                        g.DrawString(ItmName[total], NameFont, Brushes.Black, rName, sf);
                        g.DrawString(ItmSize[total], RetailPriceFont, Brushes.Black, rRetailPrice, sf);
                        g.DrawString(ItmColor[total], ColorFont, Brushes.Black, rColor, sf);
                        g.DrawString(ItmBrand[total], BrandFont, Brushes.Black, rBrandSize, sf2);
                        g.DrawString(ItmBinNum[total], BinNumFont, Brushes.Black, rBinNum, sf3);

                        total += 1;
                    }
                }
                else
                {
                    for (int k = 0; k < 3; k++)
                    {
                        Rectangle r = new Rectangle(60, 20 + (k * 262), 421, 242);
                        Rectangle rName = new Rectangle(62, 30 + (k * 262), 416, NameFont.Height);
                        Rectangle rRetailPrice = new Rectangle(62, 105 + (k * 262), 416, RetailPriceFont.Height);
                        Rectangle rColor = new Rectangle(62, 150 + (k * 262), 416, ColorFont.Height * 2);
                        Rectangle rBrandSize = new Rectangle(62, 230 + (k * 262), 350, BrandFont.Height);
                        Rectangle rBinNum = new Rectangle(397, 230 + (k * 262), 80, BinNumFont.Height);
                        g.DrawRectangle(Pens.Black, r);
                        g.DrawRectangle(Pens.White, rName);
                        g.DrawRectangle(Pens.White, rRetailPrice);
                        g.DrawRectangle(Pens.White, rColor);

                        g.DrawString(ItmName[total], NameFont, Brushes.Black, rName, sf);
                        g.DrawString(ItmSize[total], RetailPriceFont, Brushes.Black, rRetailPrice, sf);
                        g.DrawString(ItmColor[total], ColorFont, Brushes.Black, rColor, sf);
                        g.DrawString(ItmBrand[total], BrandFont, Brushes.Black, rBrandSize, sf2);
                        g.DrawString(ItmBinNum[total], BinNumFont, Brushes.Black, rBinNum, sf3);

                        total += 1;
                    }

                    int l = 0;

                    for (int k = 3; k < remainder; k++)
                    {
                        Rectangle r = new Rectangle(60 + (465), 20 + (l * 262), 421, 242);
                        Rectangle rName = new Rectangle(62 + (465), 30 + (l * 262), 416, NameFont.Height);
                        Rectangle rRetailPrice = new Rectangle(62 + (465), 105 + (l * 262), 416, RetailPriceFont.Height);
                        Rectangle rColor = new Rectangle(62 + (465), 150 + (l * 262), 416, ColorFont.Height * 2);
                        Rectangle rBrandSize = new Rectangle(62 + (465), 230 + (l * 262), 350, BrandFont.Height);
                        Rectangle rBinNum = new Rectangle(397 + (465), 230 + (l * 262), 80, BinNumFont.Height);
                        g.DrawRectangle(Pens.Black, r);
                        g.DrawRectangle(Pens.White, rName);
                        g.DrawRectangle(Pens.White, rRetailPrice);
                        g.DrawRectangle(Pens.White, rColor);

                        g.DrawString(ItmName[total], NameFont, Brushes.Black, rName, sf);
                        g.DrawString(ItmSize[total], RetailPriceFont, Brushes.Black, rRetailPrice, sf);
                        g.DrawString(ItmColor[total], ColorFont, Brushes.Black, rColor, sf);
                        g.DrawString(ItmBrand[total], BrandFont, Brushes.Black, rBrandSize, sf2);
                        g.DrawString(ItmBinNum[total], BinNumFont, Brushes.Black, rBinNum, sf3);

                        l += 1;
                        total += 1;
                    }
                }

                e.HasMorePages = false;
            }
        }

        private void pdPrint_PrintPage3(object sender, PrintPageEventArgs e)
        {
            BrandFont = new Font("Arial", 15, FontStyle.Bold);
            NameFont = new Font("Georgia", 25, FontStyle.Bold);
            BinNumFont = new Font("Arial", 15, FontStyle.Bold);
            SizeFont = new Font("Arial", 15, FontStyle.Bold);
            ColorFont = new Font("Arial", 10, FontStyle.Bold);
            //RetailPriceFont = new Font("Impact", 28, FontStyle.Italic);
            RetailPriceFont = new Font("Georgia", 20, FontStyle.Bold);

            Graphics g = e.Graphics;
            g.FillRectangle(Brushes.White, this.ClientRectangle);

            float xPos;

            if (tempPageNum < pageNum)
            {
                if (ItmRetailPrice[tempPageNum - 1] == 1)
                {
                    xPos = 145.187752f;
                }
                else
                {
                    xPos = (e.PageBounds.Width + 7) - e.Graphics.MeasureString(Convert.ToString(ItmRetailPrice[tempPageNum - 1]), RetailPriceFont).Width;
                }

                g.DrawString(string.Format("{0:0.00}", ItmRetailPrice[tempPageNum - 1]), RetailPriceFont, Brushes.Black, xPos, 0);

                tempPageNum += 1;
                e.HasMorePages = true;
            }
            else
            {
                if (ItmRetailPrice[tempPageNum - 1] == 1)
                {
                    xPos = 145.187752f;
                }
                else
                {
                    xPos = (e.PageBounds.Width + 7) - e.Graphics.MeasureString(Convert.ToString(ItmRetailPrice[tempPageNum - 1]), RetailPriceFont).Width;
                }

                g.DrawString(string.Format("{0:0.00}", ItmRetailPrice[tempPageNum - 1]), RetailPriceFont, Brushes.Black, xPos, 0);

                e.HasMorePages = false;
            }
        }

        private void pdPrint_PrintPage4(object sender, PrintPageEventArgs e)
        {
            BrandFont = new Font("Arial", 12);
            NameFont = new Font("Arial", 11, FontStyle.Bold);
            ColorFont = new Font("Arial", 7);
            BinNumFont = new Font("Arial", 9, FontStyle.Bold);
            RetailPriceFont = new Font("Arial", 24, FontStyle.Bold);

            Graphics g = e.Graphics;
            g.FillRectangle(Brushes.White, this.ClientRectangle);
            
            StringFormat sf = new StringFormat();
            StringFormat sf2 = new StringFormat();
            StringFormat sf3 = new StringFormat();

            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            sf2.Alignment = StringAlignment.Near;
            sf2.LineAlignment = StringAlignment.Center;
            sf3.Alignment = StringAlignment.Far;
            sf3.LineAlignment = StringAlignment.Center;

            if (tempPageNum <= pageNum)
            {
                for (int k = 0; k < 9; k++)
                {
                    Rectangle r = new Rectangle(60, 10 + (k * 89), 421, 69);
                    Rectangle rBrand = new Rectangle(60, 10 + (k * 89), 240, 23);
                    Rectangle rName = new Rectangle(60, 33 + (k * 89), 240, 23);
                    Rectangle rColor = new Rectangle(60, 56 + (k * 89), 190, 23);
                    Rectangle rBinNum = new Rectangle(250, 56 + (k * 89), 60, 23);
                    Rectangle rRetailPrice = new Rectangle(300, 10 + (k * 89), 171, 69);
                    g.DrawRectangle(Pens.White, rBrand);
                    g.DrawRectangle(Pens.White, rName);
                    g.DrawRectangle(Pens.White, rColor);
                    g.DrawRectangle(Pens.White, rBinNum);
                    g.DrawRectangle(Pens.White, rRetailPrice);
                    g.DrawRectangle(Pens.Black, r);

                    g.DrawString(ItmBrand[total], BrandFont, Brushes.Black, rBrand, sf2);
                    g.DrawString(ItmName[total], NameFont, Brushes.Black, rName, sf2);
                    g.DrawString(ItmColor[total], ColorFont, Brushes.Black, rColor, sf2);
                    g.DrawString(ItmBinNum[total], BinNumFont, Brushes.Black, rBinNum, sf2);
                    g.DrawString(string.Format("{0:c}", ItmRetailPrice[total]), RetailPriceFont, Brushes.Black, rRetailPrice, sf3);
                    
                    total += 1;
                }

                int l = 0;

                for (int k = 9; k < 18; k++)
                {
                    Rectangle r = new Rectangle(541, 10 + (l * 89), 421, 69);
                    Rectangle rBrand = new Rectangle(541, 10 + (l * 89), 240, 23);
                    Rectangle rName = new Rectangle(541, 33 + (l * 89), 240, 23);
                    Rectangle rColor = new Rectangle(541, 56 + (l * 89), 190, 23);
                    Rectangle rBinNum = new Rectangle(731, 56 + (l * 89), 60, 23);
                    Rectangle rRetailPrice = new Rectangle(781, 10 + (l * 89), 171, 69);
                    g.DrawRectangle(Pens.White, rBrand);
                    g.DrawRectangle(Pens.White, rName);
                    g.DrawRectangle(Pens.White, rColor);
                    g.DrawRectangle(Pens.White, rBinNum);
                    g.DrawRectangle(Pens.White, rRetailPrice);
                    g.DrawRectangle(Pens.Black, r);

                    g.DrawString(ItmBrand[total], BrandFont, Brushes.Black, rBrand, sf2);
                    g.DrawString(ItmName[total], NameFont, Brushes.Black, rName, sf2);
                    g.DrawString(ItmColor[total], ColorFont, Brushes.Black, rColor, sf2);
                    g.DrawString(ItmBinNum[total], BinNumFont, Brushes.Black, rBinNum, sf2);
                    g.DrawString(string.Format("{0:c}", ItmRetailPrice[total]), RetailPriceFont, Brushes.Black, rRetailPrice, sf3);

                    l += 1;
                    total += 1;
                }

                tempPageNum += 1;
                e.HasMorePages = true;
            }
            else
            {
                if (remainder < 10 & remainder > 0)
                {
                    for (int k = 0; k < remainder; k++)
                    {
                        Rectangle r = new Rectangle(60, 10 + (k * 89), 421, 69);
                        Rectangle rBrand = new Rectangle(60, 10 + (k * 89), 240, 23);
                        Rectangle rName = new Rectangle(60, 33 + (k * 89), 240, 23);
                        Rectangle rColor = new Rectangle(60, 56 + (k * 89), 190, 23);
                        Rectangle rBinNum = new Rectangle(250, 56 + (k * 89), 60, 23);
                        Rectangle rRetailPrice = new Rectangle(300, 10 + (k * 89), 171, 69);
                        g.DrawRectangle(Pens.White, rBrand);
                        g.DrawRectangle(Pens.White, rName);
                        g.DrawRectangle(Pens.White, rColor);
                        g.DrawRectangle(Pens.White, rBinNum);
                        g.DrawRectangle(Pens.White, rRetailPrice);
                        g.DrawRectangle(Pens.Black, r);

                        g.DrawString(ItmBrand[total], BrandFont, Brushes.Black, rBrand, sf2);
                        g.DrawString(ItmName[total], NameFont, Brushes.Black, rName, sf2);
                        g.DrawString(ItmColor[total], ColorFont, Brushes.Black, rColor, sf2);
                        g.DrawString(ItmBinNum[total], BinNumFont, Brushes.Black, rBinNum, sf2);
                        g.DrawString(string.Format("{0:c}", ItmRetailPrice[total]), RetailPriceFont, Brushes.Black, rRetailPrice, sf3);

                        total += 1;
                    }
                }
                else
                {
                    for (int k = 0; k < 9; k++)
                    {
                        Rectangle r = new Rectangle(60, 10 + (k * 89), 421, 69);
                        Rectangle rBrand = new Rectangle(60, 10 + (k * 89), 240, 23);
                        Rectangle rName = new Rectangle(60, 33 + (k * 89), 240, 23);
                        Rectangle rColor = new Rectangle(60, 56 + (k * 89), 190, 23);
                        Rectangle rBinNum = new Rectangle(250, 56 + (k * 89), 60, 23);
                        Rectangle rRetailPrice = new Rectangle(300, 10 + (k * 89), 171, 69);
                        g.DrawRectangle(Pens.White, rBrand);
                        g.DrawRectangle(Pens.White, rName);
                        g.DrawRectangle(Pens.White, rColor);
                        g.DrawRectangle(Pens.White, rBinNum);
                        g.DrawRectangle(Pens.White, rRetailPrice);
                        g.DrawRectangle(Pens.Black, r);

                        g.DrawString(ItmBrand[total], BrandFont, Brushes.Black, rBrand, sf2);
                        g.DrawString(ItmName[total], NameFont, Brushes.Black, rName, sf2);
                        g.DrawString(ItmColor[total], ColorFont, Brushes.Black, rColor, sf2);
                        g.DrawString(ItmBinNum[total], BinNumFont, Brushes.Black, rBinNum, sf2);
                        g.DrawString(string.Format("{0:c}", ItmRetailPrice[total]), RetailPriceFont, Brushes.Black, rRetailPrice, sf3);

                        total += 1;
                    }

                    int l = 0;

                    for (int k = 9; k < remainder; k++)
                    {
                        Rectangle r = new Rectangle(541, 10 + (l * 89), 421, 69);
                        Rectangle rBrand = new Rectangle(541, 10 + (l * 89), 240, 23);
                        Rectangle rName = new Rectangle(541, 33 + (l * 89), 240, 23);
                        Rectangle rColor = new Rectangle(541, 56 + (l * 89), 190, 23);
                        Rectangle rBinNum = new Rectangle(731, 56 + (l * 89), 60, 23);
                        Rectangle rRetailPrice = new Rectangle(781, 10 + (l * 89), 171, 69);
                        g.DrawRectangle(Pens.White, rBrand);
                        g.DrawRectangle(Pens.White, rName);
                        g.DrawRectangle(Pens.White, rColor);
                        g.DrawRectangle(Pens.White, rBinNum);
                        g.DrawRectangle(Pens.White, rRetailPrice);
                        g.DrawRectangle(Pens.Black, r);

                        g.DrawString(ItmBrand[total], BrandFont, Brushes.Black, rBrand, sf2);
                        g.DrawString(ItmName[total], NameFont, Brushes.Black, rName, sf2);
                        g.DrawString(ItmColor[total], ColorFont, Brushes.Black, rColor, sf2);
                        g.DrawString(ItmBinNum[total], BinNumFont, Brushes.Black, rBinNum, sf2);
                        g.DrawString(string.Format("{0:c}", ItmRetailPrice[total]), RetailPriceFont, Brushes.Black, rRetailPrice, sf3);

                        l += 1;
                        total += 1;
                    }
                }

                e.HasMorePages = false;
            }
        }

        private void pdPrint_PrintPage5(object sender, PrintPageEventArgs e)
        {
            BrandFont = new Font("Arial", 12);
            NameFont = new Font("Arial", 14, FontStyle.Bold);
            ColorFont = new Font("Arial", 9);
            BinNumFont = new Font("Arial", 13, FontStyle.Bold);
            RetailPriceFont = new Font("Arial", 14, FontStyle.Bold);

            Graphics g = e.Graphics;
            g.FillRectangle(Brushes.White, this.ClientRectangle);

            StringFormat sf = new StringFormat();
            StringFormat sf2 = new StringFormat();
            StringFormat sf3 = new StringFormat();

            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            sf2.Alignment = StringAlignment.Near;
            sf2.LineAlignment = StringAlignment.Center;
            sf3.Alignment = StringAlignment.Far;
            sf3.LineAlignment = StringAlignment.Center;

            if (tempPageNum <= pageNum)
            {
                for (int k = 0; k < 8; k++)
                {
                    Rectangle r = new Rectangle(60, 10 + (k * 100), 421, 80);
                    //Rectangle rBrand = new Rectangle(60, 10 + (k * 89), 240, 23);
                    Rectangle rName = new Rectangle(65, 15 + (k * 100), 311, 40);
                    Rectangle rColor = new Rectangle(65, 58 + (k * 100), 311, 29);
                    Rectangle rBinNum = new Rectangle(376, 58 + (k * 100), 100, 29);
                    Rectangle rRetailPrice = new Rectangle(376, 15 + (k * 100), 100, 40);
                    //g.DrawRectangle(Pens.White, rBrand);
                    g.DrawRectangle(Pens.White, rName);
                    g.DrawRectangle(Pens.White, rColor);
                    g.DrawRectangle(Pens.White, rBinNum);
                    g.DrawRectangle(Pens.White, rRetailPrice);
                    g.DrawRectangle(Pens.Black, r);

                    //g.DrawString(ItmBrand[total], BrandFont, Brushes.Black, rBrand, sf2);
                    g.DrawString(ItmName[total], NameFont, Brushes.Black, rName, sf2);
                    g.DrawString(ItmColor[total], ColorFont, Brushes.Black, rColor, sf2);
                    g.DrawString(ItmBinNum[total], BinNumFont, Brushes.Black, rBinNum, sf3);
                    g.DrawString(string.Format("{0:c}", ItmRetailPrice[total]), RetailPriceFont, Brushes.Black, rRetailPrice, sf3);

                    total += 1;
                }

                int l = 0;

                for (int k = 8; k < 16; k++)
                {
                    Rectangle r = new Rectangle(541, 10 + (l * 100), 421, 80);
                    //Rectangle rBrand = new Rectangle(541, 10 + (l * 89), 240, 23);
                    Rectangle rName = new Rectangle(546, 15 + (l * 100), 311, 40);
                    Rectangle rColor = new Rectangle(546, 58 + (l * 100), 311, 29);
                    Rectangle rBinNum = new Rectangle(857, 58 + (l * 100), 100, 29);
                    Rectangle rRetailPrice = new Rectangle(857, 15 + (l * 100), 100, 40);
                    //g.DrawRectangle(Pens.White, rBrand);
                    g.DrawRectangle(Pens.White, rName);
                    g.DrawRectangle(Pens.White, rColor);
                    g.DrawRectangle(Pens.White, rBinNum);
                    g.DrawRectangle(Pens.White, rRetailPrice);
                    g.DrawRectangle(Pens.Black, r);

                    //g.DrawString(ItmBrand[total], BrandFont, Brushes.Black, rBrand, sf2);
                    g.DrawString(ItmName[total], NameFont, Brushes.Black, rName, sf2);
                    g.DrawString(ItmColor[total], ColorFont, Brushes.Black, rColor, sf2);
                    g.DrawString(ItmBinNum[total], BinNumFont, Brushes.Black, rBinNum, sf3);
                    g.DrawString(string.Format("{0:c}", ItmRetailPrice[total]), RetailPriceFont, Brushes.Black, rRetailPrice, sf3);

                    l += 1;
                    total += 1;
                }

                tempPageNum += 1;

                if (tempPageNum > pageNum)
                {
                    if (remainder == 0)
                    {
                        e.HasMorePages = false;
                    }
                    else
                    {
                        e.HasMorePages = true;
                    }
                }
                else
                {
                    e.HasMorePages = true;
                }
            }
            else
            {
                if (remainder < 9 & remainder > 0)
                {
                    for (int k = 0; k < remainder; k++)
                    {
                        Rectangle r = new Rectangle(60, 10 + (k * 100), 421, 80);
                        //Rectangle rBrand = new Rectangle(60, 10 + (k * 100), 240, 23);
                        Rectangle rName = new Rectangle(65, 15 + (k * 100), 311, 40);
                        Rectangle rColor = new Rectangle(65, 58 + (k * 100), 311, 29);
                        Rectangle rBinNum = new Rectangle(376, 58 + (k * 100), 100, 29);
                        Rectangle rRetailPrice = new Rectangle(376, 15 + (k * 100), 100, 40);
                        //g.DrawRectangle(Pens.Black, rBrand);
                        g.DrawRectangle(Pens.White, rName);
                        g.DrawRectangle(Pens.White, rColor);
                        g.DrawRectangle(Pens.White, rBinNum);
                        g.DrawRectangle(Pens.White, rRetailPrice);
                        g.DrawRectangle(Pens.Black, r);

                        //g.DrawString(ItmBrand[total], BrandFont, Brushes.Black, rBrand, sf2);
                        g.DrawString(ItmName[total], NameFont, Brushes.Black, rName, sf2);
                        g.DrawString(ItmColor[total], ColorFont, Brushes.Black, rColor, sf2);
                        g.DrawString(ItmBinNum[total], BinNumFont, Brushes.Black, rBinNum, sf3);
                        g.DrawString(string.Format("{0:c}", ItmRetailPrice[total]), RetailPriceFont, Brushes.Black, rRetailPrice, sf3);

                        total += 1;
                    }
                }
                else
                {
                    for (int k = 0; k < 8; k++)
                    {
                        Rectangle r = new Rectangle(60, 10 + (k * 100), 421, 80);
                        //Rectangle rBrand = new Rectangle(60, 10 + (k * 100), 240, 23);
                        Rectangle rName = new Rectangle(65, 15 + (k * 100), 311, 40);
                        Rectangle rColor = new Rectangle(65, 58 + (k * 100), 311, 29);
                        Rectangle rBinNum = new Rectangle(376, 58 + (k * 100), 100, 29);
                        Rectangle rRetailPrice = new Rectangle(376, 15 + (k * 100), 100, 40);
                        //g.DrawRectangle(Pens.Black, rBrand);
                        g.DrawRectangle(Pens.White, rName);
                        g.DrawRectangle(Pens.White, rColor);
                        g.DrawRectangle(Pens.White, rBinNum);
                        g.DrawRectangle(Pens.White, rRetailPrice);
                        g.DrawRectangle(Pens.Black, r);

                        //g.DrawString(ItmBrand[total], BrandFont, Brushes.Black, rBrand, sf2);
                        g.DrawString(ItmName[total], NameFont, Brushes.Black, rName, sf2);
                        g.DrawString(ItmColor[total], ColorFont, Brushes.Black, rColor, sf2);
                        g.DrawString(ItmBinNum[total], BinNumFont, Brushes.Black, rBinNum, sf3);
                        g.DrawString(string.Format("{0:c}", ItmRetailPrice[total]), RetailPriceFont, Brushes.Black, rRetailPrice, sf3);

                        total += 1;
                    }

                    int l = 0;

                    for (int k = 8; k < remainder; k++)
                    {
                        Rectangle r = new Rectangle(541, 10 + (l * 100), 421, 80);
                        //Rectangle rBrand = new Rectangle(541, 10 + (l * 89), 240, 23);
                        Rectangle rName = new Rectangle(546, 15 + (l * 100), 311, 40);
                        Rectangle rColor = new Rectangle(546, 58 + (l * 100), 311, 29);
                        Rectangle rBinNum = new Rectangle(857, 58 + (l * 100), 100, 29);
                        Rectangle rRetailPrice = new Rectangle(857, 15 + (l * 100), 100, 40);
                        //g.DrawRectangle(Pens.White, rBrand);
                        g.DrawRectangle(Pens.White, rName);
                        g.DrawRectangle(Pens.White, rColor);
                        g.DrawRectangle(Pens.White, rBinNum);
                        g.DrawRectangle(Pens.White, rRetailPrice);
                        g.DrawRectangle(Pens.Black, r);

                        //g.DrawString(ItmBrand[total], BrandFont, Brushes.Black, rBrand, sf2);
                        g.DrawString(ItmName[total], NameFont, Brushes.Black, rName, sf2);
                        g.DrawString(ItmColor[total], ColorFont, Brushes.Black, rColor, sf2);
                        g.DrawString(ItmBinNum[total], BinNumFont, Brushes.Black, rBinNum, sf3);
                        g.DrawString(string.Format("{0:c}", ItmRetailPrice[total]), RetailPriceFont, Brushes.Black, rRetailPrice, sf3);

                        l += 1;
                        total += 1;
                    }
                }

                e.HasMorePages = false;
            }
        }
    }
}