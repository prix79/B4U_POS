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
    public partial class ReturnPrinting : Form
    {
        public LogInManagements parentForm1;
        public ItemSoldListForReturn parentForm2;
        public ReturnReportDetail parentForm3;

        SqlConnection conn;
        SqlCommand cmd;

        public PrintDocument pdPrint;
        public PrintDocument pdPrintRemainder;
        public PrintDialog printDialog;
        public PrintPreviewDialog printPreviewDialog;

        Font TitleFont;
        Font SubTitleFont;
        Font FromToFont;
        Font AddressFont;
        Font HeaderFont;
        Font BodyFont;
        Font FooterFont;

        int i, j, k, total;

        int pageNum, remainder;
        int tempPageNum;

        string[] ItmBrand = new string[1000];
        string[] ItmName = new string[1000];
        string[] ItmSize = new string[1000];
        string[] ItmColor = new string[1000];
        string[] ItmModelNum = new string[1000];
        string[] ItmUpc = new string[1000];
        double[] ItmCostPrice = new double[1000];
        int[] ReturnQty = new int[1000];
        double[] ReturnAmount = new double[1000];
        int totalReturnQty;
        double totalReturnAmout;

        int ctr;
        Single yPos;

        int option;

        public ReturnPrinting(int opt)
        {
            InitializeComponent();
            option = opt;
        }

        private void ReturnPrinting_Load(object sender, EventArgs e)
        {
            if (option == 0)
            {
                this.Text = "RETURN PRINTING OPTION (INVOICE)";
                btnTest.Enabled = false;
            }
            else if (option == 1)
            {
                this.Text = "RETURN PRINTING OPTION (REPORT)";

                if (parentForm3.lblStatus.Text == "SUBMITTED")
                {
                    btnTest.Enabled = true;
                }
                else
                {
                    btnTest.Enabled = false;
                }
            }
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (option == 0)
            {
                totalReturnQty = 0;
                totalReturnAmout = 0;

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

                    ItmModelNum[i] = parentForm2.dataGridView2.Rows[i].Cells[4].Value.ToString();

                    if (ItmModelNum[i].Length > 30)
                        ItmModelNum[i] = parentForm2.dataGridView2.Rows[i].Cells[4].Value.ToString().Substring(0, 29);

                    ItmUpc[i] = parentForm2.dataGridView2.Rows[i].Cells[5].Value.ToString();
                    ItmCostPrice[i] = Convert.ToDouble(parentForm2.dataGridView2.Rows[i].Cells[6].Value);
                    ReturnQty[i] = Convert.ToInt16(parentForm2.dataGridView2.Rows[i].Cells[7].Value);
                    ReturnAmount[i] = Convert.ToDouble(parentForm2.dataGridView2.Rows[i].Cells[8].Value);

                    totalReturnQty = totalReturnQty + ReturnQty[i];
                    totalReturnAmout = totalReturnAmout + ReturnAmount[i];
                }

                pageNum = i / 25;
                remainder = i % 25;
                tempPageNum = 1;

                total = 0;

                pdPrint = new PrintDocument();
                printPreviewDialog = new PrintPreviewDialog();
                printPreviewDialog.Document = pdPrint;
                pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_Invoice);
                printPreviewDialog.ShowDialog();

                this.Close();
            }
            else if (option == 1)
            {
                totalReturnQty = 0;
                totalReturnAmout = 0;

                for (i = 0; i < parentForm3.dataGridView1.RowCount; i++)
                {
                    ItmBrand[i] = parentForm3.dataGridView1.Rows[i].Cells[0].Value.ToString();

                    if (ItmBrand[i].Length > 15)
                        ItmBrand[i] = parentForm3.dataGridView1.Rows[i].Cells[0].Value.ToString().Substring(0, 14);

                    ItmName[i] = parentForm3.dataGridView1.Rows[i].Cells[1].Value.ToString();

                    if (ItmName[i].Length > 30)
                        ItmName[i] = parentForm3.dataGridView1.Rows[i].Cells[1].Value.ToString().Substring(0, 29);

                    ItmSize[i] = parentForm3.dataGridView1.Rows[i].Cells[2].Value.ToString();

                    if (ItmSize[i].Length > 9)
                        ItmSize[i] = parentForm3.dataGridView1.Rows[i].Cells[2].Value.ToString().Substring(0, 8);

                    ItmColor[i] = parentForm3.dataGridView1.Rows[i].Cells[3].Value.ToString();

                    if (ItmColor[i].Length > 12)
                        ItmColor[i] = parentForm3.dataGridView1.Rows[i].Cells[3].Value.ToString().Substring(0, 11);

                    ItmModelNum[i] = parentForm3.dataGridView1.Rows[i].Cells[4].Value.ToString();

                    if (ItmModelNum[i].Length > 30)
                        ItmModelNum[i] = parentForm3.dataGridView1.Rows[i].Cells[4].Value.ToString().Substring(0, 29);

                    ItmUpc[i] = parentForm3.dataGridView1.Rows[i].Cells[5].Value.ToString();
                    ItmCostPrice[i] = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[6].Value);
                    ReturnQty[i] = Convert.ToInt16(parentForm3.dataGridView1.Rows[i].Cells[7].Value);
                    ReturnAmount[i] = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[8].Value);

                    totalReturnQty = totalReturnQty + ReturnQty[i];
                    totalReturnAmout = totalReturnAmout + ReturnAmount[i];
                }

                pageNum = i / 25;
                remainder = i % 25;
                tempPageNum = 1;

                total = 0;

                pdPrint = new PrintDocument();
                printPreviewDialog = new PrintPreviewDialog();
                printPreviewDialog.Document = pdPrint;
                pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_Report);
                printPreviewDialog.ShowDialog();

                this.Close();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (option == 0)
            {
                totalReturnQty = 0;
                totalReturnAmout = 0;

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

                    ItmModelNum[i] = parentForm2.dataGridView2.Rows[i].Cells[4].Value.ToString();

                    if (ItmModelNum[i].Length > 30)
                        ItmModelNum[i] = parentForm2.dataGridView2.Rows[i].Cells[4].Value.ToString().Substring(0, 29);

                    ItmUpc[i] = parentForm2.dataGridView2.Rows[i].Cells[5].Value.ToString();
                    ItmCostPrice[i] = Convert.ToDouble(parentForm2.dataGridView2.Rows[i].Cells[6].Value);
                    ReturnQty[i] = Convert.ToInt16(parentForm2.dataGridView2.Rows[i].Cells[7].Value);
                    ReturnAmount[i] = Convert.ToDouble(parentForm2.dataGridView2.Rows[i].Cells[8].Value);

                    totalReturnQty = totalReturnQty + ReturnQty[i];
                    totalReturnAmout = totalReturnAmout + ReturnAmount[i];
                }

                pageNum = i / 25;
                remainder = i % 25;
                tempPageNum = 1;

                total = 0;

                pdPrint = new PrintDocument();
                printDialog = new PrintDialog();
                printDialog.UseEXDialog = true;
                printDialog.Document = pdPrint;
                pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_Invoice);
                pdPrint.PrinterSettings.PrinterName = printDialog.PrinterSettings.PrinterName;

                DialogResult result = new DialogResult();
                result = printDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    pdPrint.Print();
                    this.Close();
                }
            }
            else if (option == 1)
            {
                totalReturnQty = 0;
                totalReturnAmout = 0;

                for (i = 0; i < parentForm3.dataGridView1.RowCount; i++)
                {
                    ItmBrand[i] = parentForm3.dataGridView1.Rows[i].Cells[0].Value.ToString();

                    if (ItmBrand[i].Length > 15)
                        ItmBrand[i] = parentForm3.dataGridView1.Rows[i].Cells[0].Value.ToString().Substring(0, 14);

                    ItmName[i] = parentForm3.dataGridView1.Rows[i].Cells[1].Value.ToString();

                    if (ItmName[i].Length > 30)
                        ItmName[i] = parentForm3.dataGridView1.Rows[i].Cells[1].Value.ToString().Substring(0, 29);

                    ItmSize[i] = parentForm3.dataGridView1.Rows[i].Cells[2].Value.ToString();

                    if (ItmSize[i].Length > 9)
                        ItmSize[i] = parentForm3.dataGridView1.Rows[i].Cells[2].Value.ToString().Substring(0, 8);

                    ItmColor[i] = parentForm3.dataGridView1.Rows[i].Cells[3].Value.ToString();

                    if (ItmColor[i].Length > 12)
                        ItmColor[i] = parentForm3.dataGridView1.Rows[i].Cells[3].Value.ToString().Substring(0, 11);

                    ItmModelNum[i] = parentForm3.dataGridView1.Rows[i].Cells[4].Value.ToString();

                    if (ItmModelNum[i].Length > 30)
                        ItmModelNum[i] = parentForm3.dataGridView1.Rows[i].Cells[4].Value.ToString().Substring(0, 29);

                    ItmUpc[i] = parentForm3.dataGridView1.Rows[i].Cells[5].Value.ToString();
                    ItmCostPrice[i] = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[6].Value);
                    ReturnQty[i] = Convert.ToInt16(parentForm3.dataGridView1.Rows[i].Cells[7].Value);
                    ReturnAmount[i] = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[8].Value);

                    totalReturnQty = totalReturnQty + ReturnQty[i];
                    totalReturnAmout = totalReturnAmout + ReturnAmount[i];
                }

                pageNum = i / 25;
                remainder = i % 25;
                tempPageNum = 1;

                total = 0;

                pdPrint = new PrintDocument();
                printDialog = new PrintDialog();
                printDialog.UseEXDialog = true;
                printDialog.Document = pdPrint;
                pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_Report);
                pdPrint.PrinterSettings.PrinterName = printDialog.PrinterSettings.PrinterName;

                DialogResult result = new DialogResult();
                result = printDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    pdPrint.Print();

                    if (parentForm3.lblStatus.Text == "SUBMITTED")
                    {
                        try
                        {
                            conn = new SqlConnection(parentForm1.OtherStoreConnectionString(parentForm3.rrStoreCode));
                            cmd = new SqlCommand("Update_ReturnReportHeader", conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                            cmd.Parameters.Add("@rrID", SqlDbType.BigInt).Value = parentForm3.rrID;
                            cmd.Parameters.Add("@rrShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                            cmd.Parameters.Add("@rrSubmitDate", SqlDbType.DateTime).Value = DateTime.Now;
                            cmd.Parameters.Add("@rrReturnedDate", SqlDbType.DateTime).Value = DateTime.Now;
                            cmd.Parameters.Add("@rrTrackingNumber", SqlDbType.NVarChar).Value = "N/A";
                            cmd.Parameters.Add("@rrReturnTotalAmount", SqlDbType.Money).Value = 0;
                            cmd.Parameters.Add("@rrReceivingTotalAmount", SqlDbType.Money).Value = 0;
                            cmd.Parameters.Add("@rrConfirmationID", SqlDbType.NVarChar).Value = "N/A";
                            cmd.Parameters.Add("@rrStatus", SqlDbType.NVarChar).Value = "PROCESSING";
                            cmd.Parameters.Add("@rrFirstContact", SqlDbType.NVarChar).Value = "N/A";

                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();

                            MessageBox.Show("THIS RETURN IS NOW UNDER PROCESSING", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.parentForm3.lblStatus.Text = "PROCESSING";

                            if (parentForm3.parentForm2.IsDisposed == false)
                            {
                                if (parentForm3.parentForm2.dataGridView1.RowCount == 0)
                                    return;

                                parentForm3.parentForm2.SearchAllReturnReportList();
                            }

                            this.Close();
                        }
                        catch
                        {
                            MessageBox.Show("UPDATE FAILED OR CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            conn.Close();
                        }
                    }

                    this.Close();
                }
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
            {
                try
                {
                    conn = new SqlConnection(parentForm1.OtherStoreConnectionString(parentForm3.rrStoreCode));
                    cmd = new SqlCommand("Update_ReturnReportHeader", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                    cmd.Parameters.Add("@rrID", SqlDbType.BigInt).Value = parentForm3.rrID;
                    cmd.Parameters.Add("@rrShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                    cmd.Parameters.Add("@rrSubmitDate", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@rrReturnedDate", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@rrTrackingNumber", SqlDbType.NVarChar).Value = "N/A";
                    cmd.Parameters.Add("@rrReturnTotalAmount", SqlDbType.Money).Value = 0;
                    cmd.Parameters.Add("@rrReceivingTotalAmount", SqlDbType.Money).Value = 0;
                    cmd.Parameters.Add("@rrConfirmationID", SqlDbType.NVarChar).Value = "N/A";
                    cmd.Parameters.Add("@rrStatus", SqlDbType.NVarChar).Value = "PROCESSING";
                    cmd.Parameters.Add("@rrFirstContact", SqlDbType.NVarChar).Value = "N/A";

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("THIS RETURN IS NOW UNDER PROCESSING", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.parentForm3.lblStatus.Text = "PROCESSING";

                    if (parentForm3.parentForm2.IsDisposed == false)
                    {
                        if (parentForm3.parentForm2.dataGridView1.RowCount == 0)
                            return;

                        parentForm3.parentForm2.SearchAllReturnReportList();
                    }

                    this.Close();
                }
                catch
                {
                    MessageBox.Show("UPDATE FAILED OR CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pdPrint_Invoice(object sender, PrintPageEventArgs e)
        {
            ctr = 0;
            TitleFont = new Font("Cambria", 26, FontStyle.Bold);
            SubTitleFont = new Font("Cambria", 18, FontStyle.Bold);
            FromToFont = new Font("Cambria", 14, FontStyle.Bold);
            AddressFont = new Font("Cambria", 12, FontStyle.Bold);
            HeaderFont = new Font("Cambria", 15, FontStyle.Bold);
            BodyFont = new Font("Cambria", 9, FontStyle.Bold);
            FooterFont = new Font("Cambria", 15, FontStyle.Bold);
            //FooterFont = new Font("Cambria", 15, FontStyle.Bold | FontStyle.Underline);

            /*TitleFont = new Font("Agency FB", 26, FontStyle.Bold);
            SubTitleFont = new Font("Agency FB", 18, FontStyle.Bold);
            AddressFont = new Font("Agency FB", 12, FontStyle.Bold);
            HeaderFont = new Font("Agency FB", 15, FontStyle.Bold);
            BodyFont = new Font("Agency FB", 10, FontStyle.Bold);*/

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
            e.Graphics.DrawString("RETURN INVOICE", TitleFont, Brushes.Black, 250, yPos + 20);
            ctr = +3;
            yPos = ctr * SubTitleFont.GetHeight(e.Graphics);
            Rectangle rRRID = new Rectangle(510, Convert.ToInt16(yPos + 30) + 14, 250, 30);
            g1.DrawRectangle(Thick_Pen, rRRID);
            g1.DrawString("RETURN #:" + Convert.ToString(parentForm2.RRID), SubTitleFont, Brushes.Black, rRRID, sf);
            ctr = +8;
            yPos = ctr * FromToFont.GetHeight(e.Graphics);
            //e.Graphics.DrawString("FROM : " + parentForm1.storeName + " STORE", FromToFont, Brushes.Black, 30, yPos + 30);
            //e.Graphics.DrawString("TO : " + parentForm2.RRVendor, FromToFont, Brushes.Black, 450, yPos + 30);
            e.Graphics.DrawString("FROM : " + parentForm1.storeName + " STORE", FromToFont, Brushes.Black, 30, yPos);
            e.Graphics.DrawString("TO : " + parentForm2.RRVendor, FromToFont, Brushes.Black, 450, yPos);
            ctr = +9;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawString(parentForm1.storeTelephone, AddressFont, Brushes.Black, 30, yPos + 30);
            ctr = +10;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawString(parentForm1.storeFax, AddressFont, Brushes.Black, 30, yPos + 30);
            ctr = +11;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawLine(Dash_Pen, 32, yPos + 35, 770, yPos + 35);
            ctr = +12;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawString("PACKING DATE : " + parentForm2.RRPackingDate, AddressFont, Brushes.Black, 30, yPos + 27);
            e.Graphics.DrawString("PACKING BY : " + parentForm2.RREmployeeName, AddressFont, Brushes.Black, 450, yPos + 27);
            ctr = +13;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawString("SHIPPING DATE : " + parentForm2.RRShippingDate, AddressFont, Brushes.Black, 30, yPos + 27);
            e.Graphics.DrawString("SHIPPING BY : " + parentForm2.RREmployeeName, AddressFont, Brushes.Black, 450, yPos + 27);
            ctr = +14;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawLine(Dash_Pen, 32, yPos + 37, 770, yPos + 37);


            ctr = +15;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawLine(Normal_Pen, 0, yPos + 40, 830, yPos + 40);
            ctr = +16;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawString("BRAND".ToString(), HeaderFont, Brushes.Black, 0, yPos + 19);
            e.Graphics.DrawString("ITEM", HeaderFont, Brushes.Black, 130, yPos + 19);
            e.Graphics.DrawString("SZ", HeaderFont, Brushes.Black, 380, yPos + 19);
            e.Graphics.DrawString("CL", HeaderFont, Brushes.Black, 450, yPos + 19);
            e.Graphics.DrawString("QTY", HeaderFont, Brushes.Black, 540, yPos + 19);
            e.Graphics.DrawString("COST", HeaderFont, Brushes.Black, 595, yPos + 19);
            e.Graphics.DrawString("UPC", HeaderFont, Brushes.Black, 680, yPos + 19);
            ctr = +17;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawString("DESCRIPTION", HeaderFont, Brushes.Black, 130, yPos + 19);
            e.Graphics.DrawString("(R)", HeaderFont, Brushes.Black, 540, yPos + 19);
            e.Graphics.DrawString("(T)", HeaderFont, Brushes.Black, 595, yPos + 19);
            ctr = +18;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawLine(Normal_Pen, 0, yPos + 24, 830, yPos + 24);

            if (tempPageNum <= pageNum)
            {
                for (j = 0; j < 25; j++)
                {
                    k = j + 14;
                    yPos = (k * HeaderFont.GetHeight(e.Graphics)) - 4;

                    e.Graphics.DrawString(ItmBrand[total], BodyFont, Brushes.Black, 0, yPos + 42);
                    e.Graphics.DrawString(ItmName[total], BodyFont, Brushes.Black, 130, yPos + 42);
                    e.Graphics.DrawString(ItmSize[total], BodyFont, Brushes.Black, 380, yPos + 42);
                    e.Graphics.DrawString(ItmColor[total], BodyFont, Brushes.Black, 450, yPos + 42);
                    e.Graphics.DrawString(ReturnQty[total].ToString(), BodyFont, Brushes.Black, 540, yPos + 42);
                    e.Graphics.DrawString(string.Format("{0:$ 0.00}", ReturnAmount[total]), BodyFont, Brushes.Black, 595, yPos + 42);
                    e.Graphics.DrawString(ItmUpc[total], BodyFont, Brushes.Black, 680, yPos + 42);

                    total += 1;
                }

                yPos = (k + 2) * AddressFont.GetHeight(e.Graphics);

                if (pageNum == 0)
                {
                    e.Graphics.DrawString("PAGE #" + Convert.ToString(tempPageNum) + "/1", HeaderFont, Brushes.Black, 670, 1040);
                }
                else if (pageNum > 0 && remainder > 0)
                {
                    e.Graphics.DrawString("PAGE #" + Convert.ToString(tempPageNum) + "/" + Convert.ToString(pageNum + 1), HeaderFont, Brushes.Black, 670, 1040);
                }
                else
                {
                    e.Graphics.DrawString("PAGE #" + Convert.ToString(tempPageNum) + "/" + Convert.ToString(pageNum), HeaderFont, Brushes.Black, 670, 1040);
                }

                if (tempPageNum == pageNum && remainder == 0)
                {
                    e.HasMorePages = false;
                }
                else
                {
                    e.HasMorePages = true;
                }

                if (tempPageNum == pageNum && remainder == 0)
                {
                    yPos = k * HeaderFont.GetHeight(e.Graphics) + 15;
                    Rectangle rSummary = new Rectangle(250, Convert.ToInt16(yPos + 42), 400, 60);
                    Rectangle rItemTitle = new Rectangle(250, Convert.ToInt16(yPos + 42), 150, 30);
                    Rectangle rItem = new Rectangle(400, Convert.ToInt16(yPos + 42), 50, 30);
                    Rectangle rQtyTitle = new Rectangle(450, Convert.ToInt16(yPos + 42), 130, 30);
                    Rectangle rQty = new Rectangle(580, Convert.ToInt16(yPos + 42), 70, 30);
                    Rectangle rAmountTitle = new Rectangle(250, Convert.ToInt16(yPos + 42) + 30, 270, 30);
                    Rectangle rAmount = new Rectangle(520, Convert.ToInt16(yPos + 42) + 30, 130, 30);
                    g1.DrawRectangle(Thick_Pen, rSummary);
                    g1.DrawRectangle(Thick_Pen, rItemTitle);
                    g1.DrawRectangle(Thick_Pen, rItem);
                    g1.DrawRectangle(Thick_Pen, rQtyTitle);
                    g1.DrawRectangle(Thick_Pen, rQty);
                    g1.DrawRectangle(Thick_Pen, rAmountTitle);
                    g1.DrawRectangle(Thick_Pen, rAmount);
                    g1.DrawString("TOTAL ITEMS", FooterFont, Brushes.Black, rItemTitle, sf);
                    g1.DrawString(Convert.ToString(total), FooterFont, Brushes.Black, rItem, sf3);
                    g1.DrawString("TOTAL QTY", FooterFont, Brushes.Black, rQtyTitle, sf);
                    g1.DrawString(totalReturnQty.ToString(), FooterFont, Brushes.Black, rQty, sf3);
                    g1.DrawString("TOTAL RETURN AMOUNT", FooterFont, Brushes.Black, rAmountTitle, sf);
                    g1.DrawString(string.Format("{0:$ 0.00}", totalReturnAmout), FooterFont, Brushes.Black, rAmount, sf3);
                    e.HasMorePages = false;

                    //yPos = k * HeaderFont.GetHeight(e.Graphics) + 15;
                    //e.Graphics.DrawString("TOTAL RETURN AMOUNT : ", FooterFont, Brushes.Black, 250, yPos + 42);
                    //e.Graphics.DrawString(string.Format("{0:$ 0.00}", totalReturnAmout), FooterFont, Brushes.Black, 520, yPos + 42);
                    //e.HasMorePages = false;
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

                    e.Graphics.DrawString(ItmBrand[total], BodyFont, Brushes.Black, 0, yPos + 42);
                    e.Graphics.DrawString(ItmName[total], BodyFont, Brushes.Black, 130, yPos + 42);
                    e.Graphics.DrawString(ItmSize[total], BodyFont, Brushes.Black, 380, yPos + 42);
                    e.Graphics.DrawString(ItmColor[total], BodyFont, Brushes.Black, 450, yPos + 42);
                    e.Graphics.DrawString(ReturnQty[total].ToString(), BodyFont, Brushes.Black, 540, yPos + 42);
                    e.Graphics.DrawString(string.Format("{0:$ 0.00}", ReturnAmount[total]), BodyFont, Brushes.Black, 595, yPos + 42);
                    e.Graphics.DrawString(ItmUpc[total], BodyFont, Brushes.Black, 680, yPos + 42);

                    total += 1;
                }

                yPos = (k + 2) * AddressFont.GetHeight(e.Graphics);

                if (pageNum == 0)
                {
                    e.Graphics.DrawString("PAGE #" + Convert.ToString(tempPageNum) + "/1", HeaderFont, Brushes.Black, 670, 1040);
                }
                else if (pageNum > 0 && remainder > 0)
                {
                    e.Graphics.DrawString("PAGE #" + Convert.ToString(tempPageNum) + "/" + Convert.ToString(pageNum + 1), HeaderFont, Brushes.Black, 670, 1040);
                }
                else
                {
                    e.Graphics.DrawString("PAGE #" + Convert.ToString(tempPageNum) + "/" + Convert.ToString(pageNum), HeaderFont, Brushes.Black, 670, 1040);
                }

                yPos = k * HeaderFont.GetHeight(e.Graphics) + 15;
                Rectangle rSummary = new Rectangle(250, Convert.ToInt16(yPos + 42), 400, 60);
                Rectangle rItemTitle = new Rectangle(250, Convert.ToInt16(yPos + 42), 150, 30);
                Rectangle rItem = new Rectangle(400, Convert.ToInt16(yPos + 42), 50, 30);
                Rectangle rQtyTitle = new Rectangle(450, Convert.ToInt16(yPos + 42), 130, 30);
                Rectangle rQty = new Rectangle(580, Convert.ToInt16(yPos + 42), 70, 30);
                Rectangle rAmountTitle = new Rectangle(250, Convert.ToInt16(yPos + 42) + 30, 270, 30);
                Rectangle rAmount = new Rectangle(520, Convert.ToInt16(yPos + 42) + 30, 130, 30);
                g1.DrawRectangle(Thick_Pen, rSummary);
                g1.DrawRectangle(Thick_Pen, rItemTitle);
                g1.DrawRectangle(Thick_Pen, rItem);
                g1.DrawRectangle(Thick_Pen, rQtyTitle);
                g1.DrawRectangle(Thick_Pen, rQty);
                g1.DrawRectangle(Thick_Pen, rAmountTitle);
                g1.DrawRectangle(Thick_Pen, rAmount);
                g1.DrawString("TOTAL ITEMS", FooterFont, Brushes.Black, rItemTitle, sf);
                g1.DrawString(Convert.ToString(total), FooterFont, Brushes.Black, rItem, sf3);
                g1.DrawString("TOTAL QTY", FooterFont, Brushes.Black, rQtyTitle, sf);
                g1.DrawString(totalReturnQty.ToString(), FooterFont, Brushes.Black, rQty, sf3);
                g1.DrawString("TOTAL RETURN AMOUNT", FooterFont, Brushes.Black, rAmountTitle, sf);
                g1.DrawString(string.Format("{0:$ 0.00}", totalReturnAmout), FooterFont, Brushes.Black, rAmount, sf3);
                e.HasMorePages = false;

                //yPos = k * HeaderFont.GetHeight(e.Graphics) + 15;
                //e.Graphics.DrawString("TOTAL RETURN AMOUNT : ", FooterFont, Brushes.Black, 250, yPos + 42);
                //e.Graphics.DrawString(string.Format("{0:$ 0.00}", totalReturnAmout), FooterFont, Brushes.Black, 520, yPos + 42);
                //e.HasMorePages = false;
            }
        }

        private void pdPrint_Report(object sender, PrintPageEventArgs e)
        {
            ctr = 0;
            TitleFont = new Font("Cambria", 26, FontStyle.Bold);
            SubTitleFont = new Font("Cambria", 18, FontStyle.Bold);
            FromToFont = new Font("Cambria", 14, FontStyle.Bold);
            AddressFont = new Font("Cambria", 12, FontStyle.Bold);
            HeaderFont = new Font("Cambria", 15, FontStyle.Bold);
            BodyFont = new Font("Cambria", 9, FontStyle.Bold);
            FooterFont = new Font("Cambria", 15, FontStyle.Bold);
            //FooterFont = new Font("Cambria", 15, FontStyle.Bold | FontStyle.Underline);

            /*TitleFont = new Font("Agency FB", 26, FontStyle.Bold);
            SubTitleFont = new Font("Agency FB", 18, FontStyle.Bold);
            AddressFont = new Font("Agency FB", 12, FontStyle.Bold);
            HeaderFont = new Font("Agency FB", 15, FontStyle.Bold);
            BodyFont = new Font("Agency FB", 10, FontStyle.Bold);*/

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
            e.Graphics.DrawString("RETURN REPORT", TitleFont, Brushes.Black, 260, yPos + 20);
            ctr = +3;
            yPos = ctr * SubTitleFont.GetHeight(e.Graphics);
            Rectangle rRRID = new Rectangle(510, Convert.ToInt16(yPos) + 14, 250, 30);
            g1.DrawRectangle(Thick_Pen, rRRID);
            g1.DrawString("RETURN #:" + Convert.ToString(parentForm3.rrID), SubTitleFont, Brushes.Black, rRRID, sf);
            ctr = +8;
            yPos = ctr * FromToFont.GetHeight(e.Graphics);
            e.Graphics.DrawString("FROM : " + parentForm1.OtherStoreName(parentForm3.rrStoreCode) + " STORE", FromToFont, Brushes.Black, 30, yPos - 30);
            e.Graphics.DrawString("TO : " + parentForm3.lblVendorName.Text, FromToFont, Brushes.Black, 450, yPos - 30);
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
            e.Graphics.DrawString("PACKING DATE : " + parentForm3.lblPackingDate.Text, AddressFont, Brushes.Black, 30, yPos - 3);
            e.Graphics.DrawString("PACKING BY : " + parentForm3.lblEmployeeName.Text, AddressFont, Brushes.Black, 450, yPos - 3);
            ctr = +13;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawString("SHIPPING DATE : " + parentForm3.lblShippingDate.Text, AddressFont, Brushes.Black, 30, yPos - 3);
            e.Graphics.DrawString("SHIPPING BY : " + parentForm3.lblEmployeeName.Text, AddressFont, Brushes.Black, 450, yPos - 3);
            ctr = +14;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawString("TRACKING NUMBER : " + parentForm3.txtTrackingNumber.Text.Trim(), AddressFont, Brushes.Black, 30, yPos - 3);
            ctr = +15;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawLine(Dash_Pen, 32, yPos + 7, 770, yPos + 7);

            ctr = +16;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawLine(Normal_Pen, 0, yPos + 10, 830, yPos + 10);
            ctr = +17;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawString("BRAND".ToString(), HeaderFont, Brushes.Black, 0, yPos - 11);
            e.Graphics.DrawString("ITEM", HeaderFont, Brushes.Black, 130, yPos - 11);
            e.Graphics.DrawString("SZ", HeaderFont, Brushes.Black, 380, yPos - 11);
            e.Graphics.DrawString("CL", HeaderFont, Brushes.Black, 450, yPos - 11);
            e.Graphics.DrawString("QTY", HeaderFont, Brushes.Black, 540, yPos - 11);
            e.Graphics.DrawString("COST", HeaderFont, Brushes.Black, 595, yPos - 11);
            e.Graphics.DrawString("UPC", HeaderFont, Brushes.Black, 680, yPos - 11);
            ctr = +18;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawString("DESCRIPTION", HeaderFont, Brushes.Black, 130, yPos - 11);
            e.Graphics.DrawString("(R)", HeaderFont, Brushes.Black, 540, yPos - 11);
            e.Graphics.DrawString("(T)", HeaderFont, Brushes.Black, 595, yPos - 11);
            ctr = +19;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawLine(Normal_Pen, 0, yPos - 6, 830, yPos - 6);

            if (tempPageNum <= pageNum)
            {
                for (j = 0; j < 25; j++)
                {
                    k = j + 14;
                    yPos = (k * HeaderFont.GetHeight(e.Graphics)) - 4;

                    e.Graphics.DrawString(ItmBrand[total], BodyFont, Brushes.Black, 0, yPos + 42);
                    e.Graphics.DrawString(ItmName[total], BodyFont, Brushes.Black, 130, yPos + 42);
                    e.Graphics.DrawString(ItmSize[total], BodyFont, Brushes.Black, 380, yPos + 42);
                    e.Graphics.DrawString(ItmColor[total], BodyFont, Brushes.Black, 450, yPos + 42);
                    e.Graphics.DrawString(ReturnQty[total].ToString(), BodyFont, Brushes.Black, 540, yPos + 42);
                    e.Graphics.DrawString(string.Format("{0:$ 0.00}", ReturnAmount[total]), BodyFont, Brushes.Black, 595, yPos + 42);
                    e.Graphics.DrawString(ItmUpc[total], BodyFont, Brushes.Black, 680, yPos + 42);

                    total += 1;
                }

                yPos = (k + 2) * AddressFont.GetHeight(e.Graphics);

                if (pageNum == 0)
                {
                    e.Graphics.DrawString("PAGE #" + Convert.ToString(tempPageNum) + "/1", HeaderFont, Brushes.Black, 670, 1040);
                }
                else if (pageNum > 0 && remainder > 0)
                {
                    e.Graphics.DrawString("PAGE #" + Convert.ToString(tempPageNum) + "/" + Convert.ToString(pageNum + 1), HeaderFont, Brushes.Black, 670, 1040);
                }
                else
                {
                    e.Graphics.DrawString("PAGE #" + Convert.ToString(tempPageNum) + "/" + Convert.ToString(pageNum), HeaderFont, Brushes.Black, 670, 1040);
                }

                if (tempPageNum == pageNum && remainder == 0)
                {
                    e.HasMorePages = false;
                }
                else
                {
                    e.HasMorePages = true;
                }

                if (tempPageNum == pageNum && remainder == 0)
                {
                    yPos = k * HeaderFont.GetHeight(e.Graphics) + 15;
                    Rectangle rSummary = new Rectangle(250, Convert.ToInt16(yPos + 42), 400, 60);
                    Rectangle rItemTitle = new Rectangle(250, Convert.ToInt16(yPos + 42), 150, 30);
                    Rectangle rItem = new Rectangle(400, Convert.ToInt16(yPos + 42), 50, 30);
                    Rectangle rQtyTitle = new Rectangle(450, Convert.ToInt16(yPos + 42), 130, 30);
                    Rectangle rQty = new Rectangle(580, Convert.ToInt16(yPos + 42), 70, 30);
                    Rectangle rAmountTitle = new Rectangle(250, Convert.ToInt16(yPos + 42) + 30, 270, 30);
                    Rectangle rAmount = new Rectangle(520, Convert.ToInt16(yPos + 42) + 30, 130, 30);
                    g1.DrawRectangle(Thick_Pen, rSummary);
                    g1.DrawRectangle(Thick_Pen, rItemTitle);
                    g1.DrawRectangle(Thick_Pen, rItem);
                    g1.DrawRectangle(Thick_Pen, rQtyTitle);
                    g1.DrawRectangle(Thick_Pen, rQty);
                    g1.DrawRectangle(Thick_Pen, rAmountTitle);
                    g1.DrawRectangle(Thick_Pen, rAmount);
                    g1.DrawString("TOTAL ITEMS", FooterFont, Brushes.Black, rItemTitle, sf);
                    g1.DrawString(Convert.ToString(total), FooterFont, Brushes.Black, rItem, sf3);
                    g1.DrawString("TOTAL QTY", FooterFont, Brushes.Black, rQtyTitle, sf);
                    g1.DrawString(totalReturnQty.ToString(), FooterFont, Brushes.Black, rQty, sf3);
                    g1.DrawString("TOTAL RETURN AMOUNT", FooterFont, Brushes.Black, rAmountTitle, sf);
                    g1.DrawString(string.Format("{0:$ 0.00}", totalReturnAmout), FooterFont, Brushes.Black, rAmount, sf3);
                    e.HasMorePages = false;

                    //yPos = k * HeaderFont.GetHeight(e.Graphics) + 15;
                    //e.Graphics.DrawString("TOTAL RETURN AMOUNT : ", FooterFont, Brushes.Black, 250, yPos + 42);
                    //e.Graphics.DrawString(string.Format("{0:$ 0.00}", totalReturnAmout), FooterFont, Brushes.Black, 520, yPos + 42);
                    //e.HasMorePages = false;
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

                    e.Graphics.DrawString(ItmBrand[total], BodyFont, Brushes.Black, 0, yPos + 42);
                    e.Graphics.DrawString(ItmName[total], BodyFont, Brushes.Black, 130, yPos + 42);
                    e.Graphics.DrawString(ItmSize[total], BodyFont, Brushes.Black, 380, yPos + 42);
                    e.Graphics.DrawString(ItmColor[total], BodyFont, Brushes.Black, 450, yPos + 42);
                    e.Graphics.DrawString(ReturnQty[total].ToString(), BodyFont, Brushes.Black, 540, yPos + 42);
                    e.Graphics.DrawString(string.Format("{0:$ 0.00}", ReturnAmount[total]), BodyFont, Brushes.Black, 595, yPos + 42);
                    e.Graphics.DrawString(ItmUpc[total], BodyFont, Brushes.Black, 680, yPos + 42);

                    total += 1;
                }

                yPos = (k + 2) * AddressFont.GetHeight(e.Graphics);

                if (pageNum == 0)
                {
                    e.Graphics.DrawString("PAGE #" + Convert.ToString(tempPageNum) + "/1", HeaderFont, Brushes.Black, 670, 1040);
                }
                else if (pageNum > 0 && remainder > 0)
                {
                    e.Graphics.DrawString("PAGE #" + Convert.ToString(tempPageNum) + "/" + Convert.ToString(pageNum + 1), HeaderFont, Brushes.Black, 670, 1040);
                }
                else
                {
                    e.Graphics.DrawString("PAGE #" + Convert.ToString(tempPageNum) + "/" + Convert.ToString(pageNum), HeaderFont, Brushes.Black, 670, 1040);
                }

                yPos = k * HeaderFont.GetHeight(e.Graphics) + 15;
                Rectangle rSummary = new Rectangle(250, Convert.ToInt16(yPos + 42), 400, 60);
                Rectangle rItemTitle = new Rectangle(250, Convert.ToInt16(yPos + 42), 150, 30);
                Rectangle rItem = new Rectangle(400, Convert.ToInt16(yPos + 42), 50, 30);
                Rectangle rQtyTitle = new Rectangle(450, Convert.ToInt16(yPos + 42), 130, 30);
                Rectangle rQty = new Rectangle(580, Convert.ToInt16(yPos + 42), 70, 30);
                Rectangle rAmountTitle = new Rectangle(250, Convert.ToInt16(yPos + 42) + 30, 270, 30);
                Rectangle rAmount = new Rectangle(520, Convert.ToInt16(yPos + 42) + 30, 130, 30);
                g1.DrawRectangle(Thick_Pen, rSummary);
                g1.DrawRectangle(Thick_Pen, rItemTitle);
                g1.DrawRectangle(Thick_Pen, rItem);
                g1.DrawRectangle(Thick_Pen, rQtyTitle);
                g1.DrawRectangle(Thick_Pen, rQty);
                g1.DrawRectangle(Thick_Pen, rAmountTitle);
                g1.DrawRectangle(Thick_Pen, rAmount);
                g1.DrawString("TOTAL ITEMS", FooterFont, Brushes.Black, rItemTitle, sf);
                g1.DrawString(Convert.ToString(total), FooterFont, Brushes.Black, rItem, sf3);
                g1.DrawString("TOTAL QTY", FooterFont, Brushes.Black, rQtyTitle, sf);
                g1.DrawString(totalReturnQty.ToString(), FooterFont, Brushes.Black, rQty, sf3);
                g1.DrawString("TOTAL RETURN AMOUNT", FooterFont, Brushes.Black, rAmountTitle, sf);
                g1.DrawString(string.Format("{0:$ 0.00}", totalReturnAmout), FooterFont, Brushes.Black, rAmount, sf3);
                e.HasMorePages = false;

                //yPos = k * HeaderFont.GetHeight(e.Graphics) + 15;
                //e.Graphics.DrawString("TOTAL RETURN AMOUNT : ", FooterFont, Brushes.Black, 250, yPos + 42);
                //e.Graphics.DrawString(string.Format("{0:$ 0.00}", totalReturnAmout), FooterFont, Brushes.Black, 520, yPos + 42);
                //e.HasMorePages = false;
            }
        }
    }
}