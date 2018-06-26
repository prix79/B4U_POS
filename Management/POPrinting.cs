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
using System.Data.SqlClient;

namespace Management
{
    public partial class POPrinting : Form
    {
        public LogInManagements parentForm1;
        public POMain parentForm2;
        SqlCommand cmd;

        public PrintDocument pdPrint, pdPrint1;
        public PrintDocument pdPrintRemainder;
        public PrintDialog printDialog;
        public PrintPreviewDialog printPreviewDialog;

        Font TitleFont;
        Font SubTitleFont;
        Font AddressFont;
        Font HeaderFont;
        Font BodyFont;

        int i, j, k, total;

        int pageNum, remainder;
        int tempPageNum;

        string[] ItmBrand = new string[1000];
        string[] ItmName = new string[1000];
        string[] ItmSize = new string[1000];
        string[] ItmColor = new string[1000];
        int[] ItmQty = new int[1000];
        string[] ItmUpc = new string[1000];
        string[] ItmBin = new string[1000];
        int totalQty;

        int ctr;
        Single yPos;

        public POPrinting()
        {
            InitializeComponent();
        }

        private void POPrinting_Load(object sender, EventArgs e)
        {
            //if (parentForm1.userLevel < 7)
            //    btnTest.Visible = false;

            this.Text = "P/O PRINTING OPTION";
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (parentForm2.lblPOStatus.Text.ToUpper() == "SENT" && parentForm1.StoreCode == "B4UWH")
            {
                totalQty = 0;

                for (i = 0; i < parentForm2.dataGridView2.RowCount; i++)
                {
                    ItmBrand[i] = parentForm2.dataGridView2.Rows[i].Cells[0].Value.ToString();

                    if (ItmBrand[i].Length > 15)
                        ItmBrand[i] = parentForm2.dataGridView2.Rows[i].Cells[0].Value.ToString().Substring(0, 14);

                    ItmName[i] = parentForm2.dataGridView2.Rows[i].Cells[1].Value.ToString();

                    if (ItmName[i].Length > 25)
                        ItmName[i] = parentForm2.dataGridView2.Rows[i].Cells[1].Value.ToString().Substring(0, 24);

                    ItmSize[i] = parentForm2.dataGridView2.Rows[i].Cells[2].Value.ToString();

                    if (ItmSize[i].Length > 9)
                        ItmSize[i] = parentForm2.dataGridView2.Rows[i].Cells[2].Value.ToString().Substring(0, 8);

                    ItmColor[i] = parentForm2.dataGridView2.Rows[i].Cells[3].Value.ToString();

                    if (ItmColor[i].Length > 12)
                        ItmColor[i] = parentForm2.dataGridView2.Rows[i].Cells[3].Value.ToString().Substring(0, 11);

                    ItmQty[i] = Convert.ToInt16(parentForm2.dataGridView2.Rows[i].Cells[6].Value);
                    ItmUpc[i] = parentForm2.dataGridView2.Rows[i].Cells[10].Value.ToString();
                    ItmBin[i] = parentForm2.dataGridView2.Rows[i].Cells[11].Value.ToString();

                    totalQty = totalQty + ItmQty[i];
                }

                pageNum = i / 25;
                remainder = i % 25;
                tempPageNum = 1;

                total = 0;

                pdPrint = new PrintDocument();
                printPreviewDialog = new PrintPreviewDialog();
                printPreviewDialog.Document = pdPrint;
                pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage);
                printPreviewDialog.ShowDialog();

                this.Close();
            }
            else
            {
                totalQty = 0;

                for (i = 0; i < parentForm2.dataGridView2.RowCount; i++)
                {
                    ItmBrand[i] = parentForm2.dataGridView2.Rows[i].Cells[0].Value.ToString();

                    if (ItmBrand[i].Length > 15)
                        ItmBrand[i] = parentForm2.dataGridView2.Rows[i].Cells[0].Value.ToString().Substring(0, 14);

                    ItmName[i] = parentForm2.dataGridView2.Rows[i].Cells[1].Value.ToString();

                    if (ItmName[i].Length > 30)
                        ItmName[i] = parentForm2.dataGridView2.Rows[i].Cells[1].Value.ToString().Substring(0, 29);

                    ItmSize[i] = parentForm2.dataGridView2.Rows[i].Cells[2].Value.ToString();

                    if (ItmSize[i].Length > 9)
                        ItmSize[i] = parentForm2.dataGridView2.Rows[i].Cells[2].Value.ToString().Substring(0, 8);

                    ItmColor[i] = parentForm2.dataGridView2.Rows[i].Cells[3].Value.ToString();

                    if (ItmColor[i].Length > 12)
                        ItmColor[i] = parentForm2.dataGridView2.Rows[i].Cells[3].Value.ToString().Substring(0, 11);
                    ItmQty[i] = Convert.ToInt16(parentForm2.dataGridView2.Rows[i].Cells[6].Value);

                    ItmUpc[i] = parentForm2.dataGridView2.Rows[i].Cells[10].Value.ToString();
                    ItmBin[i] = parentForm2.dataGridView2.Rows[i].Cells[11].Value.ToString();

                    totalQty = totalQty + ItmQty[i];
                }

                pageNum = i / 35;
                remainder = i % 35;
                tempPageNum = 1;

                total = 0;

                pdPrint = new PrintDocument();
                printPreviewDialog = new PrintPreviewDialog();
                printPreviewDialog.Document = pdPrint;
                pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage);
                printPreviewDialog.ShowDialog();

                this.Close();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (parentForm2.lblPOStatus.Text.ToUpper() == "SENT" && parentForm1.StoreCode == "B4UWH")
            {
                totalQty = 0;

                for (i = 0; i < parentForm2.dataGridView2.RowCount; i++)
                {
                    ItmBrand[i] = parentForm2.dataGridView2.Rows[i].Cells[0].Value.ToString();

                    if (ItmBrand[i].Length > 15)
                        ItmBrand[i] = parentForm2.dataGridView2.Rows[i].Cells[0].Value.ToString().Substring(0, 14);

                    ItmName[i] = parentForm2.dataGridView2.Rows[i].Cells[1].Value.ToString();

                    if (ItmName[i].Length > 25)
                        ItmName[i] = parentForm2.dataGridView2.Rows[i].Cells[1].Value.ToString().Substring(0, 24);

                    ItmSize[i] = parentForm2.dataGridView2.Rows[i].Cells[2].Value.ToString();

                    if (ItmSize[i].Length > 9)
                        ItmSize[i] = parentForm2.dataGridView2.Rows[i].Cells[2].Value.ToString().Substring(0, 8);

                    ItmColor[i] = parentForm2.dataGridView2.Rows[i].Cells[3].Value.ToString();

                    if (ItmColor[i].Length > 12)
                        ItmColor[i] = parentForm2.dataGridView2.Rows[i].Cells[3].Value.ToString().Substring(0, 11);

                    ItmQty[i] = Convert.ToInt16(parentForm2.dataGridView2.Rows[i].Cells[6].Value);
                    ItmUpc[i] = parentForm2.dataGridView2.Rows[i].Cells[10].Value.ToString();
                    ItmBin[i] = parentForm2.dataGridView2.Rows[i].Cells[11].Value.ToString();

                    totalQty = totalQty + ItmQty[i];
                }

                pageNum = i / 25;
                remainder = i % 25;
                tempPageNum = 1;

                total = 0;

                pdPrint = new PrintDocument();
                printDialog = new PrintDialog();
                printDialog.UseEXDialog = true;
                printDialog.Document = pdPrint;
                pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage1);
                pdPrint.PrinterSettings.PrinterName = printDialog.PrinterSettings.PrinterName;

                DialogResult result = new DialogResult();
                result = printDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    pdPrint.Print();

                    if (parentForm2.lblPOStatus.Text == "PENDING")
                    {
                        try
                        {
                            cmd = new SqlCommand("Update_POHeader", parentForm1.conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                            cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = parentForm2.POID;
                            cmd.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                            cmd.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                            cmd.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "ORDERING";

                            parentForm1.conn.Open();
                            cmd.ExecuteNonQuery();
                            parentForm1.conn.Close();

                            MessageBox.Show("YOUR ORDER IS COMPLETE", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            parentForm2.lblPOStatus.Text = "ORDERING";
                            parentForm2.btnAdd.Enabled = false;
                            parentForm2.btnSavePO.Enabled = false;
                            parentForm2.btnDeletePO.Enabled = false;
                        }
                        catch
                        {
                            MessageBox.Show("UPDATE FAILED OR CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            if (parentForm1.conn.State == ConnectionState.Open)
                                parentForm1.conn.Close();

                            return;
                        }
                    }
                }

                this.Close();
            }
            else
            {
                totalQty = 0;

                for (i = 0; i < parentForm2.dataGridView2.RowCount; i++)
                {
                    ItmBrand[i] = parentForm2.dataGridView2.Rows[i].Cells[0].Value.ToString();

                    if (ItmBrand[i].Length > 15)
                        ItmBrand[i] = parentForm2.dataGridView2.Rows[i].Cells[0].Value.ToString().Substring(0, 14);

                    ItmName[i] = parentForm2.dataGridView2.Rows[i].Cells[1].Value.ToString();

                    if (ItmName[i].Length > 25)
                        ItmName[i] = parentForm2.dataGridView2.Rows[i].Cells[1].Value.ToString().Substring(0, 24);

                    ItmSize[i] = parentForm2.dataGridView2.Rows[i].Cells[2].Value.ToString();

                    if (ItmSize[i].Length > 9)
                        ItmSize[i] = parentForm2.dataGridView2.Rows[i].Cells[2].Value.ToString().Substring(0, 8);

                    ItmColor[i] = parentForm2.dataGridView2.Rows[i].Cells[3].Value.ToString();

                    if (ItmColor[i].Length > 12)
                        ItmColor[i] = parentForm2.dataGridView2.Rows[i].Cells[3].Value.ToString().Substring(0, 11);

                    ItmQty[i] = Convert.ToInt16(parentForm2.dataGridView2.Rows[i].Cells[6].Value);
                    ItmUpc[i] = parentForm2.dataGridView2.Rows[i].Cells[10].Value.ToString();
                    ItmBin[i] = parentForm2.dataGridView2.Rows[i].Cells[11].Value.ToString();

                    totalQty = totalQty + ItmQty[i];
                }

                pageNum = i / 35;
                remainder = i % 35;
                tempPageNum = 1;

                total = 0;

                pdPrint = new PrintDocument();
                printDialog = new PrintDialog();
                printDialog.UseEXDialog = true;
                printDialog.Document = pdPrint;
                pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage);
                pdPrint.PrinterSettings.PrinterName = printDialog.PrinterSettings.PrinterName;

                DialogResult result = new DialogResult();
                result = printDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    pdPrint.Print();

                    if (parentForm2.lblPOStatus.Text == "PENDING")
                    {
                        try
                        {
                            cmd = new SqlCommand("Update_POHeader", parentForm1.conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                            cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = parentForm2.POID;
                            cmd.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                            cmd.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                            cmd.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "ORDERING";

                            parentForm1.conn.Open();
                            cmd.ExecuteNonQuery();
                            parentForm1.conn.Close();

                            MessageBox.Show("YOUR ORDER IS COMPLETE", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            parentForm2.lblPOStatus.Text = "ORDERING";
                            parentForm2.btnAdd.Enabled = false;
                            parentForm2.btnSavePO.Enabled = false;
                            parentForm2.btnDeletePO.Enabled = false;
                        }
                        catch
                        {
                            MessageBox.Show("UPDATE FAILED OR CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            parentForm1.conn.Close();
                        }
                    }
                }

                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pdPrint_PrintPage(object sender, PrintPageEventArgs e)
        {
            ctr = 0;
            TitleFont = new Font("Arial", 26, FontStyle.Bold);
            SubTitleFont = new Font("Arial", 20, FontStyle.Bold);
            AddressFont = new Font("Arial", 12, FontStyle.Bold);
            HeaderFont = new Font("Arial", 15, FontStyle.Bold);
            BodyFont = new Font("Arial", 10, FontStyle.Bold);
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black, 5);

            ctr = +1;
            yPos = ctr * HeaderFont.GetHeight(e.Graphics);
            e.Graphics.DrawString("BEAUTY 4U", TitleFont, Brushes.Black, 300, yPos);
            ctr = +1;
            yPos = ctr * TitleFont.GetHeight(e.Graphics);
            e.Graphics.DrawString("P/O ITEM LIST (P/O ID : " + Convert.ToString(parentForm2.POID) + ")", SubTitleFont, Brushes.Black, 200, yPos + 20);

            ctr = +3;
            yPos = ctr * TitleFont.GetHeight(e.Graphics);
            e.Graphics.DrawString("LOCATION : " + parentForm1.storeName + " STORE", AddressFont, Brushes.Black, 0, yPos + 10);
            e.Graphics.DrawString("VENDOR NAME : " + parentForm2.VendorName, AddressFont, Brushes.Black, 420, yPos + 10);
            ctr = +8;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawString(parentForm1.storeStreet, AddressFont, Brushes.Black, 0, yPos);
            e.Graphics.DrawString("DATE : " + parentForm2.CreateDate, AddressFont, Brushes.Black, 420, yPos);
            ctr = +9;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawString(parentForm1.storeCityStateZipCode, AddressFont, Brushes.Black, 0, yPos);
            ctr = +10;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawString(parentForm1.storeTelephone, AddressFont, Brushes.Black, 0, yPos);
            ctr = +11;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawString(parentForm1.storeFax, AddressFont, Brushes.Black, 0, yPos);

            ctr = +13;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawString("BRAND", HeaderFont, Brushes.Black, 0, yPos + 3);
            e.Graphics.DrawString("NAME (DESCRIPTION)", HeaderFont, Brushes.Black, 145, yPos + 3);
            e.Graphics.DrawString("SIZE", HeaderFont, Brushes.Black, 390, yPos + 3);
            e.Graphics.DrawString("COLOR", HeaderFont, Brushes.Black, 470, yPos + 3);
            e.Graphics.DrawString("QTY".ToString(), HeaderFont, Brushes.Black, 595, yPos + 3);
            e.Graphics.DrawString("UPC", HeaderFont, Brushes.Black, 670, yPos + 3);

            ctr = +14;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawLine(p, 0, yPos + 10, 800, yPos + 10);

            if (tempPageNum <= pageNum)
            {
                for (j = 0; j < 35; j++)
                {
                    k = j + 15;
                    yPos = k * AddressFont.GetHeight(e.Graphics);
                    e.Graphics.DrawString(ItmBrand[total], BodyFont, Brushes.Black, 0, yPos + 3);
                    e.Graphics.DrawString(ItmName[total], BodyFont, Brushes.Black, 145, yPos + 3);
                    e.Graphics.DrawString(ItmSize[total], BodyFont, Brushes.Black, 395, yPos + 3);
                    e.Graphics.DrawString(ItmColor[total], BodyFont, Brushes.Black, 480, yPos + 3);
                    e.Graphics.DrawString(ItmQty[total].ToString(), BodyFont, Brushes.Black, 620, yPos + 3);
                    e.Graphics.DrawString(ItmUpc[total], BodyFont, Brushes.Black, 675, yPos + 3);

                    total += 1;
                }

                e.Graphics.DrawString("PAGE #" + Convert.ToString(tempPageNum), HeaderFont, Brushes.Black, 670, 1000);
                tempPageNum += 1;
                e.HasMorePages = true;
            }
            else
            {
                for (j = 0; j < remainder; j++)
                {
                    k = j + 15;
                    yPos = k * AddressFont.GetHeight(e.Graphics);
                    e.Graphics.DrawString(ItmBrand[total], BodyFont, Brushes.Black, 0, yPos + 3);
                    e.Graphics.DrawString(ItmName[total], BodyFont, Brushes.Black, 145, yPos + 3);
                    e.Graphics.DrawString(ItmSize[total], BodyFont, Brushes.Black, 395, yPos + 3);
                    e.Graphics.DrawString(ItmColor[total], BodyFont, Brushes.Black, 480, yPos + 3);
                    e.Graphics.DrawString(ItmQty[total].ToString(), BodyFont, Brushes.Black, 620, yPos + 3);
                    e.Graphics.DrawString(ItmUpc[total], BodyFont, Brushes.Black, 675, yPos + 3);

                    total += 1;
                }

                yPos = (k + 2) * AddressFont.GetHeight(e.Graphics);
                e.Graphics.DrawString("TOTAL QTY", HeaderFont, Brushes.Black, 410, yPos + 3);
                e.Graphics.DrawString(totalQty.ToString(), HeaderFont, Brushes.Black, 610, yPos + 3);
                e.Graphics.DrawString("PAGE #" + Convert.ToString(tempPageNum), HeaderFont, Brushes.Black, 670, 1000);
                e.HasMorePages = false;
            }
        }

        private void pdPrint_PrintPage1(object sender, PrintPageEventArgs e)
        {
            ctr = 0;
            TitleFont = new Font("Cambria", 26, FontStyle.Bold);
            SubTitleFont = new Font("Cambria", 18, FontStyle.Bold);
            AddressFont = new Font("Cambria", 12, FontStyle.Bold);
            HeaderFont = new Font("Cambria", 15, FontStyle.Bold);
            BodyFont = new Font("Cambria", 10, FontStyle.Bold);

            Graphics g1 = e.Graphics;
            Pen Normal_Pen = new Pen(Color.Black, 1);
            Pen Thick_Pen = new Pen(Color.Black, 2);
            Pen Dash_Pen = new Pen(Color.Black, 2);
            Dash_Pen.DashStyle = DashStyle.Dash;

            StringFormat sf = new StringFormat();
            StringFormat sf2 = new StringFormat();
            StringFormat sf3 = new StringFormat();

            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            sf2.Alignment = StringAlignment.Near;
            sf2.LineAlignment = StringAlignment.Center;
            sf3.Alignment = StringAlignment.Far;
            sf3.LineAlignment = StringAlignment.Center;

            Image i = (Image)Properties.Resources.beauty4ulogohalf;

            ctr = +1;
            yPos = ctr * BodyFont.GetHeight(e.Graphics);
            g1.DrawImage(i, 350, yPos, 110, 50);
            ctr = +1;
            yPos = ctr * TitleFont.GetHeight(e.Graphics);
            e.Graphics.DrawString("WAREHOUSE PURCHASE ORDER", TitleFont, Brushes.Black, 130, yPos + 20);
            ctr = +3;
            yPos = ctr * SubTitleFont.GetHeight(e.Graphics);
            Rectangle rPOID = new Rectangle(580, Convert.ToInt16(yPos) + 14, 180, 30);
            g1.DrawRectangle(Thick_Pen, rPOID);
            g1.DrawString("P/O #:" + Convert.ToString(parentForm2.POID), SubTitleFont, Brushes.Black, rPOID, sf);
            ctr = +8;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawString("TO : " + parentForm1.storeName + " STORE", AddressFont, Brushes.Black, 30, yPos);
            e.Graphics.DrawString("FROM : BEAUTY 4U WAREHOUSE", AddressFont, Brushes.Black, 450, yPos);
            ctr = +9;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawString(parentForm1.storeTelephone, AddressFont, Brushes.Black, 30, yPos);
            ctr = +10;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawString(parentForm1.storeFax, AddressFont, Brushes.Black, 30, yPos);
            ctr = +11;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawLine(Dash_Pen, 32, yPos + 5, 770, yPos + 5);
            ctr = +12;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawString("ORDER DATE : " + parentForm2.lblCreateDate.Text.ToString(), AddressFont, Brushes.Black, 30, yPos);
            e.Graphics.DrawString("ORDER BY : " + parentForm2.lblEmployeeID.Text.ToString(), AddressFont, Brushes.Black, 450, yPos);
            ctr = +13;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawLine(Dash_Pen, 32, yPos + 10, 770, yPos + 10);


            ctr = +13;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawLine(Normal_Pen, 0, yPos + 30, 830, yPos + 30);
            ctr = +14;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawString("BIN", HeaderFont, Brushes.Black, 0, yPos + 9);
            e.Graphics.DrawString("QTY", HeaderFont, Brushes.Black, 50, yPos + 9);
            e.Graphics.DrawString("QTY", HeaderFont, Brushes.Black, 95, yPos + 9);
            e.Graphics.DrawString("BRAND".ToString(), HeaderFont, Brushes.Black, 140, yPos + 9);
            e.Graphics.DrawString("ITEM", HeaderFont, Brushes.Black, 270, yPos + 9);
            e.Graphics.DrawString("SZ", HeaderFont, Brushes.Black, 520, yPos + 9);
            e.Graphics.DrawString("CL", HeaderFont, Brushes.Black, 600, yPos + 9);
            e.Graphics.DrawString("UPC", HeaderFont, Brushes.Black, 680, yPos + 9);
            ctr = +15;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawString("(O)", HeaderFont, Brushes.Black, 50, yPos + 9);
            e.Graphics.DrawString("(S)", HeaderFont, Brushes.Black, 95, yPos + 9);
            e.Graphics.DrawString("DESCRIPTION", HeaderFont, Brushes.Black, 270, yPos + 9);
            ctr = +16;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawLine(Normal_Pen, 0, yPos + 12, 830, yPos + 14);

            if (tempPageNum <= pageNum)
            {
                for (j = 0; j < 25; j++)
                {
                    k = j + 14;
                    yPos = (k * HeaderFont.GetHeight(e.Graphics)) - 4;

                    e.Graphics.DrawString(ItmBin[total], BodyFont, Brushes.Black, 0, yPos + 3);
                    e.Graphics.DrawString(ItmQty[total].ToString(), BodyFont, Brushes.Black, 50, yPos + 3);
                    e.Graphics.DrawString(ItmBrand[total], BodyFont, Brushes.Black, 140, yPos + 3);
                    e.Graphics.DrawString(ItmName[total], BodyFont, Brushes.Black, 270, yPos + 3);
                    e.Graphics.DrawString(ItmSize[total], BodyFont, Brushes.Black, 520, yPos + 3);
                    e.Graphics.DrawString(ItmColor[total], BodyFont, Brushes.Black, 600, yPos + 3);
                    e.Graphics.DrawString(ItmUpc[total], BodyFont, Brushes.Black, 680, yPos + 3);

                    total += 1;
                }

                yPos = (k + 2) * AddressFont.GetHeight(e.Graphics);

                if (pageNum == 0)
                {
                    e.Graphics.DrawString("PAGE #" + Convert.ToString(tempPageNum) + "/1", HeaderFont, Brushes.Black, 670, 1000);
                }
                else if (pageNum > 0 && remainder > 0)
                {
                    e.Graphics.DrawString("PAGE #" + Convert.ToString(tempPageNum) + "/" + Convert.ToString(pageNum + 1), HeaderFont, Brushes.Black, 670, 1000);
                }
                else
                {
                    e.Graphics.DrawString("PAGE #" + Convert.ToString(tempPageNum) + "/" + Convert.ToString(pageNum), HeaderFont, Brushes.Black, 670, 1000);
                }

                if (tempPageNum == pageNum && remainder == 0)
                {
                    e.HasMorePages = false;
                }
                else
                {
                    e.HasMorePages = true;
                }

                tempPageNum += 1;
            }
            else
            {
                for (j = 0; j < remainder; j++)
                {
                    k = j + 14;
                    yPos = (k * HeaderFont.GetHeight(e.Graphics)) - 4;

                    e.Graphics.DrawString(ItmBin[total], BodyFont, Brushes.Black, 0, yPos + 3);
                    e.Graphics.DrawString(ItmQty[total].ToString(), BodyFont, Brushes.Black, 50, yPos + 3);
                    e.Graphics.DrawString(ItmBrand[total], BodyFont, Brushes.Black, 140, yPos + 3);
                    e.Graphics.DrawString(ItmName[total], BodyFont, Brushes.Black, 270, yPos + 3);
                    e.Graphics.DrawString(ItmSize[total], BodyFont, Brushes.Black, 520, yPos + 3);
                    e.Graphics.DrawString(ItmColor[total], BodyFont, Brushes.Black, 600, yPos + 3);
                    e.Graphics.DrawString(ItmUpc[total], BodyFont, Brushes.Black, 680, yPos + 3);

                    total += 1;
                }

                yPos = (k + 2) * AddressFont.GetHeight(e.Graphics);

                if (pageNum == 0)
                {
                    e.Graphics.DrawString("PAGE #" + Convert.ToString(tempPageNum) + "/1", HeaderFont, Brushes.Black, 670, 1000);
                }
                else if (pageNum > 0 && remainder > 0)
                {
                    e.Graphics.DrawString("PAGE #" + Convert.ToString(tempPageNum) + "/" + Convert.ToString(pageNum + 1), HeaderFont, Brushes.Black, 670, 1000);
                }
                else
                {
                    e.Graphics.DrawString("PAGE #" + Convert.ToString(tempPageNum) + "/" + Convert.ToString(pageNum), HeaderFont, Brushes.Black, 670, 1000);
                }

                e.HasMorePages = false;
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (parentForm2.lblPOStatus.Text == "PENDING")
            {
                DialogResult MyDialogResult;
                MyDialogResult = MessageBox.Show(this, "NO PRINTING OPTION. P/O STATUS WILL BE CHANGED TO ORDERING", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (MyDialogResult == DialogResult.Yes)
                {
                    try
                    {
                        cmd = new SqlCommand("Update_POHeader", parentForm1.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                        cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = parentForm2.POID;
                        cmd.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                        cmd.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                        cmd.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "ORDERING";

                        parentForm1.conn.Open();
                        cmd.ExecuteNonQuery();
                        parentForm1.conn.Close();

                        MessageBox.Show("YOUR ORDER IS COMPLETE", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        parentForm2.lblPOStatus.Text = "ORDERING";
                        parentForm2.btnAdd.Enabled = false;
                        parentForm2.btnSavePO.Enabled = false;
                        parentForm2.btnDeletePO.Enabled = false;
                    }
                    catch
                    {
                        MessageBox.Show("UPDATE FAILED OR CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        if (parentForm1.conn.State == ConnectionState.Open)
                            parentForm1.conn.Close();

                        return;
                    }
                }

                this.Close();
            }

            /*totalQty = 0;

            for (i = 0; i < parentForm2.dataGridView2.RowCount; i++)
            {
                ItmBrand[i] = parentForm2.dataGridView2.Rows[i].Cells[0].Value.ToString();
                ItmName[i] = parentForm2.dataGridView2.Rows[i].Cells[1].Value.ToString();
                ItmSize[i] = parentForm2.dataGridView2.Rows[i].Cells[2].Value.ToString();
                ItmColor[i] = parentForm2.dataGridView2.Rows[i].Cells[3].Value.ToString();
                ItmQty[i] = Convert.ToInt16(parentForm2.dataGridView2.Rows[i].Cells[6].Value);
                ItmUpc[i] = parentForm2.dataGridView2.Rows[i].Cells[10].Value.ToString();

                totalQty = totalQty + ItmQty[i];
            }

            pageNum = i / 35;
            remainder = i % 35;
            tempPageNum = 1;

            total = 0;

            pdPrint = new PrintDocument();
            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = pdPrint;
            pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage);
            printPreviewDialog.ShowDialog();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            totalQty = 0;

            for (i = 0; i < parentForm2.dataGridView2.RowCount; i++)
            {
                ItmBrand[i] = parentForm2.dataGridView2.Rows[i].Cells[0].Value.ToString();

                if (ItmBrand[i].Length > 15)
                    ItmBrand[i] = parentForm2.dataGridView2.Rows[i].Cells[0].Value.ToString().Substring(0, 14);

                ItmName[i] = parentForm2.dataGridView2.Rows[i].Cells[1].Value.ToString();

                if (ItmName[i].Length > 30)
                    ItmName[i] = parentForm2.dataGridView2.Rows[i].Cells[1].Value.ToString().Substring(0, 29);

                ItmSize[i] = parentForm2.dataGridView2.Rows[i].Cells[2].Value.ToString();

                if (ItmSize[i].Length > 9)
                    ItmSize[i] = parentForm2.dataGridView2.Rows[i].Cells[2].Value.ToString().Substring(0, 8);

                ItmColor[i] = parentForm2.dataGridView2.Rows[i].Cells[3].Value.ToString();

                if (ItmColor[i].Length > 9)
                    ItmColor[i] = parentForm2.dataGridView2.Rows[i].Cells[3].Value.ToString().Substring(0, 8);

                ItmQty[i] = Convert.ToInt16(parentForm2.dataGridView2.Rows[i].Cells[6].Value);
                ItmUpc[i] = parentForm2.dataGridView2.Rows[i].Cells[10].Value.ToString();
                ItmBin[i] = parentForm2.dataGridView2.Rows[i].Cells[11].Value.ToString();

                totalQty = totalQty + ItmQty[i];
            }

            pageNum = i / 25;
            remainder = i % 25;
            tempPageNum = 1;

            total = 0;

            pdPrint = new PrintDocument();
            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = pdPrint;
            pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage1);
            printPreviewDialog.ShowDialog();

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            totalQty = 0;

            for (i = 0; i < parentForm2.dataGridView2.RowCount; i++)
            {
                ItmBrand[i] = parentForm2.dataGridView2.Rows[i].Cells[0].Value.ToString();

                if (ItmBrand[i].Length > 15)
                    ItmBrand[i] = parentForm2.dataGridView2.Rows[i].Cells[0].Value.ToString().Substring(0, 14);

                ItmName[i] = parentForm2.dataGridView2.Rows[i].Cells[1].Value.ToString();

                if (ItmName[i].Length > 30)
                    ItmName[i] = parentForm2.dataGridView2.Rows[i].Cells[1].Value.ToString().Substring(0, 29);

                ItmSize[i] = parentForm2.dataGridView2.Rows[i].Cells[2].Value.ToString();

                if (ItmSize[i].Length > 9)
                    ItmSize[i] = parentForm2.dataGridView2.Rows[i].Cells[2].Value.ToString().Substring(0, 8);

                ItmColor[i] = parentForm2.dataGridView2.Rows[i].Cells[3].Value.ToString();

                if (ItmColor[i].Length > 9)
                    ItmColor[i] = parentForm2.dataGridView2.Rows[i].Cells[3].Value.ToString().Substring(0, 8);
          
                ItmQty[i] = Convert.ToInt16(parentForm2.dataGridView2.Rows[i].Cells[6].Value);
                ItmUpc[i] = parentForm2.dataGridView2.Rows[i].Cells[10].Value.ToString();
                ItmBin[i] = parentForm2.dataGridView2.Rows[i].Cells[11].Value.ToString();

                totalQty = totalQty + ItmQty[i];
            }

            pageNum = i / 25;
            remainder = i % 25;
            tempPageNum = 1;

            total = 0;

            pdPrint = new PrintDocument();
            printDialog = new PrintDialog();
            printDialog.UseEXDialog = true;
            printDialog.Document = pdPrint;
            pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage1);
            pdPrint.PrinterSettings.PrinterName = printDialog.PrinterSettings.PrinterName;

            DialogResult result = new DialogResult();
            result = printDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                pdPrint.Print();

                if (parentForm2.lblPOStatus.Text == "PENDING")
                {
                    try
                    {
                        cmd = new SqlCommand("Update_POHeader", parentForm1.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                        cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = parentForm2.POID;
                        cmd.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                        cmd.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                        cmd.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "ORDERING";

                        parentForm1.conn.Open();
                        cmd.ExecuteNonQuery();
                        parentForm1.conn.Close();

                        MessageBox.Show("YOUR ORDER IS COMPLETE", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        parentForm2.lblPOStatus.Text = "ORDERING";
                        parentForm2.btnAdd.Enabled = false;
                        parentForm2.btnSavePO.Enabled = false;
                        parentForm2.btnDeletePO.Enabled = false;
                    }
                    catch
                    {
                        MessageBox.Show("UPDATE FAILED OR CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        parentForm1.conn.Close();
                    }
                }
            }

            this.Close();
        }
    }
}