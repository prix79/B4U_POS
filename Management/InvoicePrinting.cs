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
    public partial class InvoicePrinting : Form
    {
        public LogInManagements parentForm1;
        public POSending parentForm2;
        SqlCommand cmd, cmd2;

        Int64 Pid;
        string sc;
        int WHsts = 0;

        public PrintDocument pdPrint, pdPrint1;
        public PrintDocument pdPrintRemainder;
        public PrintDialog printDialog;
        public PrintPreviewDialog printPreviewDialog;

        Font TitleFont;
        Font SubTitleFont;
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
        double[] ItmUnitCost = new double[1000];
        int[] ItmOrderQty = new int[1000];
        int[] ItmSendingQty = new int[1000];
        string[] ItmUpc = new string[1000];
        string[] ItmBin = new string[1000];
        int totalOrderQty;
        int totalSendingQty;
        double totalShippingAmount = 0;

        int ctr;
        Single yPos;

        Int64 invoiceID = 0;
        string invoiceDate;
        string invoiceStore = "BEAUTY 4U";

        public InvoicePrinting(Int64 POID, string storeCode, int WHStatus)
        {
            InitializeComponent();
            Pid = POID;
            sc = storeCode;
            WHsts = WHStatus;
        }

        private void InvoicePrinting_Load(object sender, EventArgs e)
        {
            invoiceID = Get_InvoiceID();

            if (invoiceID == 0)
            {
                cmd = new SqlCommand("Create_InvoiceID", parentForm1.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = parentForm2.storeCode;
                cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = parentForm2.POID;
                cmd.Parameters.Add("@InvoiceDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

                parentForm1.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm1.conn.Close();

                invoiceID = Get_InvoiceID();
            }

            invoiceDate = Get_InvoiceDate();

            if (parentForm2.storeCode == "TH")
            {
                invoiceStore = "TEMPLE HILLS";
            }
            else if (parentForm2.storeCode == "OH")
            {
                invoiceStore = "OXON HILL";
            }
            else if (parentForm2.storeCode == "UM")
            {
                invoiceStore = "UPPER MARLBORO";
            }
            else if (parentForm2.storeCode == "CH")
            {
                invoiceStore = "CAPITOL HEIGHTS";
            }
            else if (parentForm2.storeCode == "WM")
            {
                invoiceStore = "WINDSOR MILL";
            }
            else if (parentForm2.storeCode == "CV")
            {
                invoiceStore = "CATONSVILLE";
            }
            else if (parentForm2.storeCode == "WB")
            {
                invoiceStore = "WOODBRIDGE";
            }
            else if (parentForm2.storeCode == "WD")
            {
                invoiceStore = "WALDORF";
            }
            else if (parentForm2.storeCode == "PW")
            {
                invoiceStore = "PRINCE WILLIAM";
            }
            else if (parentForm2.storeCode == "GB")
            {
                invoiceStore = "GAITHERSBURG";
            }
            else if (parentForm2.storeCode == "BW")
            {
                invoiceStore = "BOWIE";
            }
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (parentForm2.lblPOStatus.Text.ToUpper() == "ORDERING" | parentForm2.lblPOStatus.Text.ToUpper() == "PACKING")
            {
                totalOrderQty = 0;

                for (i = 0; i < parentForm2.dataGridView1.RowCount; i++)
                {
                    ItmBrand[i] = parentForm2.dataGridView1.Rows[i].Cells[0].Value.ToString();

                    if (ItmBrand[i].Length > 15)
                        ItmBrand[i] = parentForm2.dataGridView1.Rows[i].Cells[0].Value.ToString().Substring(0, 14);

                    ItmName[i] = parentForm2.dataGridView1.Rows[i].Cells[1].Value.ToString();

                    if (ItmName[i].Length > 30)
                        ItmName[i] = parentForm2.dataGridView1.Rows[i].Cells[1].Value.ToString().Substring(0, 29);

                    ItmSize[i] = parentForm2.dataGridView1.Rows[i].Cells[2].Value.ToString();

                    if (ItmSize[i].Length > 9)
                        ItmSize[i] = parentForm2.dataGridView1.Rows[i].Cells[2].Value.ToString().Substring(0, 8);

                    ItmColor[i] = parentForm2.dataGridView1.Rows[i].Cells[3].Value.ToString();

                    if (ItmColor[i].Length > 12)
                        ItmColor[i] = parentForm2.dataGridView1.Rows[i].Cells[3].Value.ToString().Substring(0, 11);

                    ItmOrderQty[i] = Convert.ToInt16(parentForm2.dataGridView1.Rows[i].Cells[6].Value);
                    ItmUpc[i] = parentForm2.dataGridView1.Rows[i].Cells[10].Value.ToString();
                    ItmBin[i] = parentForm2.dataGridView1.Rows[i].Cells[12].Value.ToString();

                    totalOrderQty = totalOrderQty + ItmOrderQty[i];
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
            else if (parentForm2.lblPOStatus.Text.ToUpper() == "SENT" | parentForm2.lblPOStatus.Text.ToUpper() == "RECEIVED")
            {
                totalOrderQty = 0;

                for (i = 0; i < parentForm2.dataGridView1.RowCount; i++)
                {
                    ItmBrand[i] = parentForm2.dataGridView1.Rows[i].Cells[0].Value.ToString();

                    if (ItmBrand[i].Length > 15)
                        ItmBrand[i] = parentForm2.dataGridView1.Rows[i].Cells[0].Value.ToString().Substring(0, 14);

                    ItmName[i] = parentForm2.dataGridView1.Rows[i].Cells[1].Value.ToString();

                    if (ItmName[i].Length > 30)
                        ItmName[i] = parentForm2.dataGridView1.Rows[i].Cells[1].Value.ToString().Substring(0, 29);

                    ItmSize[i] = parentForm2.dataGridView1.Rows[i].Cells[2].Value.ToString();

                    if (ItmSize[i].Length > 9)
                        ItmSize[i] = parentForm2.dataGridView1.Rows[i].Cells[2].Value.ToString().Substring(0, 8);

                    ItmColor[i] = parentForm2.dataGridView1.Rows[i].Cells[3].Value.ToString();

                    if (ItmColor[i].Length > 12)
                        ItmColor[i] = parentForm2.dataGridView1.Rows[i].Cells[3].Value.ToString().Substring(0, 11);

                    ItmUnitCost[i] = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[4].Value);
                    ItmOrderQty[i] = Convert.ToInt16(parentForm2.dataGridView1.Rows[i].Cells[6].Value);
                    ItmSendingQty[i] = Convert.ToInt16(parentForm2.dataGridView1.Rows[i].Cells[7].Value);
                    ItmUpc[i] = parentForm2.dataGridView1.Rows[i].Cells[10].Value.ToString();
                    ItmBin[i] = parentForm2.dataGridView1.Rows[i].Cells[12].Value.ToString();

                    totalOrderQty = totalOrderQty + ItmOrderQty[i];
                    totalShippingAmount = totalShippingAmount + (ItmSendingQty[i] * ItmUnitCost[i]);
                }

                pageNum = i / 25;
                remainder = i % 25;
                tempPageNum = 1;

                total = 0;

                pdPrint = new PrintDocument();
                printPreviewDialog = new PrintPreviewDialog();
                printPreviewDialog.Document = pdPrint;
                pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage2);
                printPreviewDialog.ShowDialog();

                this.Close();
            }
            else
            {
                MessageBox.Show("THIS P/O IS NOT READY", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

                /*totalSendingQty = 0;

                for (i = 0; i < parentForm2.dataGridView1.RowCount; i++)
                {
                    ItmBrand[i] = parentForm2.dataGridView1.Rows[i].Cells[0].Value.ToString();

                    if (ItmBrand[i].Length > 15)
                        ItmBrand[i] = parentForm2.dataGridView1.Rows[i].Cells[0].Value.ToString().Substring(0, 14);

                    ItmName[i] = parentForm2.dataGridView1.Rows[i].Cells[1].Value.ToString();

                    if (ItmName[i].Length > 27)
                        ItmName[i] = parentForm2.dataGridView1.Rows[i].Cells[1].Value.ToString().Substring(0, 26);

                    ItmSize[i] = parentForm2.dataGridView1.Rows[i].Cells[2].Value.ToString();

                    if (ItmSize[i].Length > 9)
                        ItmSize[i] = parentForm2.dataGridView1.Rows[i].Cells[2].Value.ToString().Substring(0, 8);

                    ItmColor[i] = parentForm2.dataGridView1.Rows[i].Cells[3].Value.ToString();

                    if (ItmColor[i].Length > 11)
                        ItmColor[i] = parentForm2.dataGridView1.Rows[i].Cells[3].Value.ToString().Substring(0, 10);

                    ItmOrderQty[i] = Convert.ToInt16(parentForm2.dataGridView1.Rows[i].Cells[6].Value);
                    ItmSendingQty[i] = Convert.ToInt16(parentForm2.dataGridView1.Rows[i].Cells[7].Value);
                    ItmUpc[i] = parentForm2.dataGridView1.Rows[i].Cells[10].Value.ToString();
                    ItmBin[i] = parentForm2.dataGridView1.Rows[i].Cells[12].Value.ToString();

                    totalSendingQty = totalSendingQty + ItmSendingQty[i];
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

                this.Close();*/
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (parentForm2.lblPOStatus.Text.ToUpper() == "ORDERING" | parentForm2.lblPOStatus.Text.ToUpper() == "PACKING")
            {
                totalOrderQty = 0;

                for (i = 0; i < parentForm2.dataGridView1.RowCount; i++)
                {
                    ItmBrand[i] = parentForm2.dataGridView1.Rows[i].Cells[0].Value.ToString();

                    if (ItmBrand[i].Length > 15)
                        ItmBrand[i] = parentForm2.dataGridView1.Rows[i].Cells[0].Value.ToString().Substring(0, 14);

                    ItmName[i] = parentForm2.dataGridView1.Rows[i].Cells[1].Value.ToString();

                    if (ItmName[i].Length > 30)
                        ItmName[i] = parentForm2.dataGridView1.Rows[i].Cells[1].Value.ToString().Substring(0, 29);

                    ItmSize[i] = parentForm2.dataGridView1.Rows[i].Cells[2].Value.ToString();

                    if (ItmSize[i].Length > 9)
                        ItmSize[i] = parentForm2.dataGridView1.Rows[i].Cells[2].Value.ToString().Substring(0, 8);

                    ItmColor[i] = parentForm2.dataGridView1.Rows[i].Cells[3].Value.ToString();

                    if (ItmColor[i].Length > 12)
                        ItmColor[i] = parentForm2.dataGridView1.Rows[i].Cells[3].Value.ToString().Substring(0, 11);

                    ItmOrderQty[i] = Convert.ToInt16(parentForm2.dataGridView1.Rows[i].Cells[6].Value);
                    ItmUpc[i] = parentForm2.dataGridView1.Rows[i].Cells[10].Value.ToString();
                    ItmBin[i] = parentForm2.dataGridView1.Rows[i].Cells[12].Value.ToString();

                    totalOrderQty = totalOrderQty + ItmOrderQty[i];
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

                    if (WHsts == 0)
                    {
                        parentForm2.WHStatus = 1;
                        parentForm2.btnSend.Enabled = true;
                        parentForm2.dataGridView1.ReadOnly = false;
                        parentForm2.dataGridView1.Columns[0].ReadOnly = true;
                        parentForm2.dataGridView1.Columns[1].ReadOnly = true;
                        parentForm2.dataGridView1.Columns[2].ReadOnly = true;
                        parentForm2.dataGridView1.Columns[3].ReadOnly = true;
                        parentForm2.dataGridView1.Columns[4].ReadOnly = true;
                        parentForm2.dataGridView1.Columns[5].ReadOnly = true;
                        parentForm2.dataGridView1.Columns[6].ReadOnly = true;
                        parentForm2.dataGridView1.Columns[8].ReadOnly = true;
                        parentForm2.dataGridView1.Columns[9].ReadOnly = true;
                        parentForm2.dataGridView1.Columns[10].ReadOnly = true;
                        parentForm2.dataGridView1.Columns[11].ReadOnly = true;
                        parentForm2.dataGridView1.Columns[12].ReadOnly = true;

                        if (sc == "TH")
                        {
                            cmd = new SqlCommand("Create_POWarehouseStatus", parentForm2.parentForm2.connTH);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = sc;
                            cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd.Parameters.Add("@WarehouseStatus", SqlDbType.NVarChar).Value = 1;
                            cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

                            cmd2 = new SqlCommand("Update_POHeader", parentForm2.parentForm2.connTH);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.Clear();
                            cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                            cmd2.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd2.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "PACKING";


                            parentForm2.parentForm2.connTH.Open();
                            cmd.ExecuteNonQuery();
                            cmd2.ExecuteNonQuery();
                            parentForm2.parentForm2.connTH.Close();
                        }
                        else if (sc == "OH")
                        {
                            cmd = new SqlCommand("Create_POWarehouseStatus", parentForm2.parentForm2.connOH);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = sc;
                            cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd.Parameters.Add("@WarehouseStatus", SqlDbType.NVarChar).Value = 1;
                            cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

                            cmd2 = new SqlCommand("Update_POHeader", parentForm2.parentForm2.connOH);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.Clear();
                            cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                            cmd2.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd2.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "PACKING";

                            parentForm2.parentForm2.connOH.Open();
                            cmd.ExecuteNonQuery();
                            cmd2.ExecuteNonQuery();
                            parentForm2.parentForm2.connOH.Close();
                        }
                        else if (sc == "UM")
                        {
                            cmd = new SqlCommand("Create_POWarehouseStatus", parentForm2.parentForm2.connUM);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = sc;
                            cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd.Parameters.Add("@WarehouseStatus", SqlDbType.NVarChar).Value = 1;
                            cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

                            cmd2 = new SqlCommand("Update_POHeader", parentForm2.parentForm2.connUM);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.Clear();
                            cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                            cmd2.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd2.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "PACKING";

                            parentForm2.parentForm2.connUM.Open();
                            cmd.ExecuteNonQuery();
                            cmd2.ExecuteNonQuery();
                            parentForm2.parentForm2.connUM.Close();
                        }
                        else if (sc == "CH")
                        {
                            cmd = new SqlCommand("Create_POWarehouseStatus", parentForm2.parentForm2.connCH);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = sc;
                            cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd.Parameters.Add("@WarehouseStatus", SqlDbType.NVarChar).Value = 1;
                            cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

                            cmd2 = new SqlCommand("Update_POHeader", parentForm2.parentForm2.connCH);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.Clear();
                            cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                            cmd2.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd2.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "PACKING";

                            parentForm2.parentForm2.connCH.Open();
                            cmd.ExecuteNonQuery();
                            cmd2.ExecuteNonQuery();
                            parentForm2.parentForm2.connCH.Close();
                        }
                        else if (sc == "WM")
                        {
                            cmd = new SqlCommand("Create_POWarehouseStatus", parentForm2.parentForm2.connWM);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = sc;
                            cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd.Parameters.Add("@WarehouseStatus", SqlDbType.NVarChar).Value = 1;
                            cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

                            cmd2 = new SqlCommand("Update_POHeader", parentForm2.parentForm2.connWM);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.Clear();
                            cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                            cmd2.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd2.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "PACKING";

                            parentForm2.parentForm2.connWM.Open();
                            cmd.ExecuteNonQuery();
                            cmd2.ExecuteNonQuery();
                            parentForm2.parentForm2.connWM.Close();
                        }
                        else if (sc == "CV")
                        {
                            cmd = new SqlCommand("Create_POWarehouseStatus", parentForm2.parentForm2.connCV);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = sc;
                            cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd.Parameters.Add("@WarehouseStatus", SqlDbType.NVarChar).Value = 1;
                            cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

                            cmd2 = new SqlCommand("Update_POHeader", parentForm2.parentForm2.connCV);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.Clear();
                            cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                            cmd2.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd2.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "PACKING";

                            parentForm2.parentForm2.connCV.Open();
                            cmd.ExecuteNonQuery();
                            cmd2.ExecuteNonQuery();
                            parentForm2.parentForm2.connCV.Close();
                        }
                        else if (sc == "PW")
                        {
                            cmd = new SqlCommand("Create_POWarehouseStatus", parentForm2.parentForm2.connPW);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = sc;
                            cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd.Parameters.Add("@WarehouseStatus", SqlDbType.NVarChar).Value = 1;
                            cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

                            cmd2 = new SqlCommand("Update_POHeader", parentForm2.parentForm2.connPW);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.Clear();
                            cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                            cmd2.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd2.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "PACKING";

                            parentForm2.parentForm2.connPW.Open();
                            cmd.ExecuteNonQuery();
                            cmd2.ExecuteNonQuery();
                            parentForm2.parentForm2.connPW.Close();
                        }
                        else if (sc == "WB")
                        {
                            cmd = new SqlCommand("Create_POWarehouseStatus", parentForm2.parentForm2.connWB);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = sc;
                            cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd.Parameters.Add("@WarehouseStatus", SqlDbType.NVarChar).Value = 1;
                            cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

                            cmd2 = new SqlCommand("Update_POHeader", parentForm2.parentForm2.connWB);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.Clear();
                            cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                            cmd2.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd2.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "PACKING";

                            parentForm2.parentForm2.connWB.Open();
                            cmd.ExecuteNonQuery();
                            cmd2.ExecuteNonQuery();
                            parentForm2.parentForm2.connWB.Close();
                        }
                        else if (sc == "WD")
                        {
                            cmd = new SqlCommand("Create_POWarehouseStatus", parentForm2.parentForm2.connWD);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = sc;
                            cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd.Parameters.Add("@WarehouseStatus", SqlDbType.NVarChar).Value = 1;
                            cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

                            cmd2 = new SqlCommand("Update_POHeader", parentForm2.parentForm2.connWD);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.Clear();
                            cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                            cmd2.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd2.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "PACKING";

                            parentForm2.parentForm2.connWD.Open();
                            cmd.ExecuteNonQuery();
                            cmd2.ExecuteNonQuery();
                            parentForm2.parentForm2.connWD.Close();
                        }
                        else if (sc == "GB")
                        {
                            cmd = new SqlCommand("Create_POWarehouseStatus", parentForm2.parentForm2.connGB);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = sc;
                            cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd.Parameters.Add("@WarehouseStatus", SqlDbType.NVarChar).Value = 1;
                            cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

                            cmd2 = new SqlCommand("Update_POHeader", parentForm2.parentForm2.connGB);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.Clear();
                            cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                            cmd2.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd2.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "PACKING";

                            parentForm2.parentForm2.connGB.Open();
                            cmd.ExecuteNonQuery();
                            cmd2.ExecuteNonQuery();
                            parentForm2.parentForm2.connGB.Close();
                        }
                        else if (sc == "BW")
                        {
                            cmd = new SqlCommand("Create_POWarehouseStatus", parentForm2.parentForm2.connBW);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = sc;
                            cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd.Parameters.Add("@WarehouseStatus", SqlDbType.NVarChar).Value = 1;
                            cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

                            cmd2 = new SqlCommand("Update_POHeader", parentForm2.parentForm2.connBW);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.Clear();
                            cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                            cmd2.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd2.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "PACKING";

                            parentForm2.parentForm2.connBW.Open();
                            cmd.ExecuteNonQuery();
                            cmd2.ExecuteNonQuery();
                            parentForm2.parentForm2.connBW.Close();
                        }
                    }

                    parentForm2.lblPOStatus.Text = "PACKING";
                    parentForm2.dataGridView1.Columns[7].ReadOnly = false;
                    this.Close();
                }
            }
            else if (parentForm2.lblPOStatus.Text.ToUpper() == "SENT" | parentForm2.lblPOStatus.Text.ToUpper() == "RECEIVED")
            {
                totalOrderQty = 0;

                for (i = 0; i < parentForm2.dataGridView1.RowCount; i++)
                {
                    ItmBrand[i] = parentForm2.dataGridView1.Rows[i].Cells[0].Value.ToString();

                    if (ItmBrand[i].Length > 15)
                        ItmBrand[i] = parentForm2.dataGridView1.Rows[i].Cells[0].Value.ToString().Substring(0, 14);

                    ItmName[i] = parentForm2.dataGridView1.Rows[i].Cells[1].Value.ToString();

                    if (ItmName[i].Length > 30)
                        ItmName[i] = parentForm2.dataGridView1.Rows[i].Cells[1].Value.ToString().Substring(0, 29);

                    ItmSize[i] = parentForm2.dataGridView1.Rows[i].Cells[2].Value.ToString();

                    if (ItmSize[i].Length > 9)
                        ItmSize[i] = parentForm2.dataGridView1.Rows[i].Cells[2].Value.ToString().Substring(0, 8);

                    ItmColor[i] = parentForm2.dataGridView1.Rows[i].Cells[3].Value.ToString();

                    if (ItmColor[i].Length > 12)
                        ItmColor[i] = parentForm2.dataGridView1.Rows[i].Cells[3].Value.ToString().Substring(0, 11);

                    ItmUnitCost[i] = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[4].Value);
                    ItmOrderQty[i] = Convert.ToInt16(parentForm2.dataGridView1.Rows[i].Cells[6].Value);
                    ItmSendingQty[i] = Convert.ToInt16(parentForm2.dataGridView1.Rows[i].Cells[7].Value);
                    ItmUpc[i] = parentForm2.dataGridView1.Rows[i].Cells[10].Value.ToString();
                    ItmBin[i] = parentForm2.dataGridView1.Rows[i].Cells[12].Value.ToString();

                    totalOrderQty = totalOrderQty + ItmOrderQty[i];
                    totalShippingAmount = totalShippingAmount + (ItmSendingQty[i] * ItmUnitCost[i]);
                }

                pageNum = i / 25;
                remainder = i % 25;
                tempPageNum = 1;

                total = 0;
                
                pdPrint = new PrintDocument();
                printDialog = new PrintDialog();
                printDialog.UseEXDialog = true;
                printDialog.Document = pdPrint;
                pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage2);
                pdPrint.PrinterSettings.PrinterName = printDialog.PrinterSettings.PrinterName;

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
                MessageBox.Show("THIS P/O IS NOT READY", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

                /*totalSendingQty = 0;

                for (i = 0; i < parentForm2.dataGridView1.RowCount; i++)
                {
                    ItmBrand[i] = parentForm2.dataGridView1.Rows[i].Cells[0].Value.ToString();

                    if (ItmBrand[i].Length > 15)
                        ItmBrand[i] = parentForm2.dataGridView1.Rows[i].Cells[0].Value.ToString().Substring(0, 14);

                    ItmName[i] = parentForm2.dataGridView1.Rows[i].Cells[1].Value.ToString();

                    if (ItmName[i].Length > 27)
                        ItmName[i] = parentForm2.dataGridView1.Rows[i].Cells[1].Value.ToString().Substring(0, 26);

                    ItmSize[i] = parentForm2.dataGridView1.Rows[i].Cells[2].Value.ToString();

                    if (ItmSize[i].Length > 9)
                        ItmSize[i] = parentForm2.dataGridView1.Rows[i].Cells[2].Value.ToString().Substring(0, 8);

                    ItmColor[i] = parentForm2.dataGridView1.Rows[i].Cells[3].Value.ToString();

                    if (ItmColor[i].Length > 11)
                        ItmColor[i] = parentForm2.dataGridView1.Rows[i].Cells[3].Value.ToString().Substring(0, 10);

                    ItmOrderQty[i] = Convert.ToInt16(parentForm2.dataGridView1.Rows[i].Cells[6].Value);
                    ItmSendingQty[i] = Convert.ToInt16(parentForm2.dataGridView1.Rows[i].Cells[7].Value);
                    ItmUpc[i] = parentForm2.dataGridView1.Rows[i].Cells[10].Value.ToString();
                    ItmBin[i] = parentForm2.dataGridView1.Rows[i].Cells[12].Value.ToString();

                    totalSendingQty = totalSendingQty + ItmSendingQty[i];
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

                    if (WHsts == 0)
                    {
                        parentForm2.WHStatus = 1;
                        parentForm2.btnSend.Enabled = true;
                        parentForm2.dataGridView1.ReadOnly = false;
                        parentForm2.dataGridView1.Columns[0].ReadOnly = true;
                        parentForm2.dataGridView1.Columns[1].ReadOnly = true;
                        parentForm2.dataGridView1.Columns[2].ReadOnly = true;
                        parentForm2.dataGridView1.Columns[3].ReadOnly = true;
                        parentForm2.dataGridView1.Columns[4].ReadOnly = true;
                        parentForm2.dataGridView1.Columns[5].ReadOnly = true;
                        parentForm2.dataGridView1.Columns[6].ReadOnly = true;
                        parentForm2.dataGridView1.Columns[8].ReadOnly = true;
                        parentForm2.dataGridView1.Columns[9].ReadOnly = true;
                        parentForm2.dataGridView1.Columns[10].ReadOnly = true;
                        parentForm2.dataGridView1.Columns[11].ReadOnly = true;
                        parentForm2.dataGridView1.Columns[12].ReadOnly = true;

                        if (sc == "TH")
                        {
                            cmd = new SqlCommand("Create_POWarehouseStatus", parentForm2.parentForm2.connTH);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = sc;
                            cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd.Parameters.Add("@WarehouseStatus", SqlDbType.NVarChar).Value = 1;
                            cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

                            cmd2 = new SqlCommand("Update_POHeader", parentForm2.parentForm2.connTH);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.Clear();
                            cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                            cmd2.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd2.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "PACKING";


                            parentForm2.parentForm2.connTH.Open();
                            cmd.ExecuteNonQuery();
                            cmd2.ExecuteNonQuery();
                            parentForm2.parentForm2.connTH.Close();
                        }
                        else if (sc == "OH")
                        {
                            cmd = new SqlCommand("Create_POWarehouseStatus", parentForm2.parentForm2.connOH);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = sc;
                            cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd.Parameters.Add("@WarehouseStatus", SqlDbType.NVarChar).Value = 1;
                            cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

                            cmd2 = new SqlCommand("Update_POHeader", parentForm2.parentForm2.connOH);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.Clear();
                            cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                            cmd2.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd2.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "PACKING";

                            parentForm2.parentForm2.connOH.Open();
                            cmd.ExecuteNonQuery();
                            cmd2.ExecuteNonQuery();
                            parentForm2.parentForm2.connOH.Close();
                        }
                        else if (sc == "UM")
                        {
                            cmd = new SqlCommand("Create_POWarehouseStatus", parentForm2.parentForm2.connUM);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = sc;
                            cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd.Parameters.Add("@WarehouseStatus", SqlDbType.NVarChar).Value = 1;
                            cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

                            cmd2 = new SqlCommand("Update_POHeader", parentForm2.parentForm2.connUM);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.Clear();
                            cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                            cmd2.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd2.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "PACKING";

                            parentForm2.parentForm2.connUM.Open();
                            cmd.ExecuteNonQuery();
                            cmd2.ExecuteNonQuery();
                            parentForm2.parentForm2.connUM.Close();
                        }
                        else if (sc == "CH")
                        {
                            cmd = new SqlCommand("Create_POWarehouseStatus", parentForm2.parentForm2.connCH);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = sc;
                            cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd.Parameters.Add("@WarehouseStatus", SqlDbType.NVarChar).Value = 1;
                            cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

                            cmd2 = new SqlCommand("Update_POHeader", parentForm2.parentForm2.connCH);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.Clear();
                            cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                            cmd2.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd2.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "PACKING";

                            parentForm2.parentForm2.connCH.Open();
                            cmd.ExecuteNonQuery();
                            cmd2.ExecuteNonQuery();
                            parentForm2.parentForm2.connCH.Close();
                        }
                        else if (sc == "WM")
                        {
                            cmd = new SqlCommand("Create_POWarehouseStatus", parentForm2.parentForm2.connWM);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = sc;
                            cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd.Parameters.Add("@WarehouseStatus", SqlDbType.NVarChar).Value = 1;
                            cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

                            cmd2 = new SqlCommand("Update_POHeader", parentForm2.parentForm2.connWM);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.Clear();
                            cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                            cmd2.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd2.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "PACKING";

                            parentForm2.parentForm2.connWM.Open();
                            cmd.ExecuteNonQuery();
                            cmd2.ExecuteNonQuery();
                            parentForm2.parentForm2.connWM.Close();
                        }
                        else if (sc == "CV")
                        {
                            cmd = new SqlCommand("Create_POWarehouseStatus", parentForm2.parentForm2.connCV);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = sc;
                            cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd.Parameters.Add("@WarehouseStatus", SqlDbType.NVarChar).Value = 1;
                            cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

                            cmd2 = new SqlCommand("Update_POHeader", parentForm2.parentForm2.connCV);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.Clear();
                            cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                            cmd2.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd2.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "PACKING";

                            parentForm2.parentForm2.connCV.Open();
                            cmd.ExecuteNonQuery();
                            cmd2.ExecuteNonQuery();
                            parentForm2.parentForm2.connCV.Close();
                        }
                        else if (sc == "PW")
                        {
                            cmd = new SqlCommand("Create_POWarehouseStatus", parentForm2.parentForm2.connPW);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = sc;
                            cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd.Parameters.Add("@WarehouseStatus", SqlDbType.NVarChar).Value = 1;
                            cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

                            cmd2 = new SqlCommand("Update_POHeader", parentForm2.parentForm2.connPW);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.Clear();
                            cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                            cmd2.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd2.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "PACKING";

                            parentForm2.parentForm2.connPW.Open();
                            cmd.ExecuteNonQuery();
                            cmd2.ExecuteNonQuery();
                            parentForm2.parentForm2.connPW.Close();
                        }
                        else if (sc == "WB")
                        {
                            cmd = new SqlCommand("Create_POWarehouseStatus", parentForm2.parentForm2.connWB);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = sc;
                            cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd.Parameters.Add("@WarehouseStatus", SqlDbType.NVarChar).Value = 1;
                            cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

                            cmd2 = new SqlCommand("Update_POHeader", parentForm2.parentForm2.connWB);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.Clear();
                            cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                            cmd2.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd2.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "PACKING";

                            parentForm2.parentForm2.connWB.Open();
                            cmd.ExecuteNonQuery();
                            cmd2.ExecuteNonQuery();
                            parentForm2.parentForm2.connWB.Close();
                        }
                        else if (sc == "WD")
                        {
                            cmd = new SqlCommand("Create_POWarehouseStatus", parentForm2.parentForm2.connWD);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = sc;
                            cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd.Parameters.Add("@WarehouseStatus", SqlDbType.NVarChar).Value = 1;
                            cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

                            cmd2 = new SqlCommand("Update_POHeader", parentForm2.parentForm2.connWD);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.Clear();
                            cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                            cmd2.Parameters.Add("@POID", SqlDbType.BigInt).Value = Pid;
                            cmd2.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                            cmd2.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "PACKING";

                            parentForm2.parentForm2.connWD.Open();
                            cmd.ExecuteNonQuery();
                            cmd2.ExecuteNonQuery();
                            parentForm2.parentForm2.connWD.Close();
                        }
                    }
                }

                this.Close();*/
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Int64 Get_InvoiceID()
        {
            cmd = new SqlCommand("Get_InvoiceID", parentForm1.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = parentForm2.storeCode;
            cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = parentForm2.POID;
            SqlParameter InvoiceID_Param = cmd.Parameters.Add("@InvoiceID", SqlDbType.BigInt);
            InvoiceID_Param.Direction = ParameterDirection.Output;

            parentForm1.conn.Open();
            cmd.ExecuteNonQuery();
            parentForm1.conn.Close();

            if (cmd.Parameters["@InvoiceID"].Value == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt64(cmd.Parameters["@InvoiceID"].Value);
            }
        }

        private string Get_InvoiceDate()
        {
            cmd = new SqlCommand("Get_InvoiceDate", parentForm1.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@InvoiceID", SqlDbType.NVarChar).Value = invoiceID;
            SqlParameter InvoiceID_Param = cmd.Parameters.Add("@InvoiceDate", SqlDbType.NVarChar, 20);
            InvoiceID_Param.Direction = ParameterDirection.Output;

            parentForm1.conn.Open();
            cmd.ExecuteNonQuery();
            parentForm1.conn.Close();

            if (cmd.Parameters["@InvoiceDate"].Value == DBNull.Value)
            {
                return "N/A";
            }
            else
            {
                return Convert.ToString(cmd.Parameters["@InvoiceDate"].Value);
            }
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
            //e.Graphics.DrawString("INVOICE ITEM LIST (INVOICE ID : " + Convert.ToString(invoiceID) + ")", SubTitleFont, Brushes.Black, 130, yPos + 20);
            e.Graphics.DrawString("INVOICE ITEM LIST", SubTitleFont, Brushes.Black, 275, yPos + 20);

            ctr = +3;
            yPos = ctr * TitleFont.GetHeight(e.Graphics);
            e.Graphics.DrawString("FROM : " + parentForm1.storeName, AddressFont, Brushes.Black, 0, yPos + 10);
            e.Graphics.DrawString("INVOICE ID : " + Convert.ToString(invoiceID), AddressFont, Brushes.Black, 500, yPos + 10);
            ctr = +8;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawString("TO : " + invoiceStore, AddressFont, Brushes.Black, 0, yPos);
            e.Graphics.DrawString("P/O ID : " + Convert.ToString(Pid), AddressFont, Brushes.Black, 500, yPos);
            ctr = +9;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawString("SHIPPING DATE : " + invoiceDate, AddressFont, Brushes.Black, 0, yPos);
            ctr = +10;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawString(parentForm1.storeTelephone, AddressFont, Brushes.Black, 0, yPos);
            ctr = +11;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawString(parentForm1.storeFax, AddressFont, Brushes.Black, 0, yPos);

            ctr = +13;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawString("BIN", HeaderFont, Brushes.Black, 0, yPos + 3);
            e.Graphics.DrawString("BRAND", HeaderFont, Brushes.Black, 50, yPos + 3);
            e.Graphics.DrawString("NAME (DESCRIPTION)", HeaderFont, Brushes.Black, 190, yPos + 3);
            e.Graphics.DrawString("SIZE", HeaderFont, Brushes.Black, 430, yPos + 3);
            e.Graphics.DrawString("COLOR", HeaderFont, Brushes.Black, 490, yPos + 3);
            e.Graphics.DrawString("QTY".ToString(), HeaderFont, Brushes.Black, 600, yPos + 3);
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
                    e.Graphics.DrawString(ItmBin[total], BodyFont, Brushes.Black, 0, yPos + 3);
                    e.Graphics.DrawString(ItmBrand[total], BodyFont, Brushes.Black, 50, yPos + 3);
                    e.Graphics.DrawString(ItmName[total], BodyFont, Brushes.Black, 190, yPos + 3);
                    e.Graphics.DrawString(ItmSize[total], BodyFont, Brushes.Black, 435, yPos + 3);
                    e.Graphics.DrawString(ItmColor[total], BodyFont, Brushes.Black, 500, yPos + 3);
                    e.Graphics.DrawString("(" + ItmOrderQty[total].ToString() + ")/" + ItmSendingQty[total].ToString(), BodyFont, Brushes.Black, 605, yPos + 3);
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
                    e.Graphics.DrawString(ItmBin[total], BodyFont, Brushes.Black, 0, yPos + 3);
                    e.Graphics.DrawString(ItmBrand[total], BodyFont, Brushes.Black, 50, yPos + 3);
                    e.Graphics.DrawString(ItmName[total], BodyFont, Brushes.Black, 190, yPos + 3);
                    e.Graphics.DrawString(ItmSize[total], BodyFont, Brushes.Black, 435, yPos + 3);
                    e.Graphics.DrawString(ItmColor[total], BodyFont, Brushes.Black, 500, yPos + 3);
                    e.Graphics.DrawString("(" + ItmOrderQty[total].ToString() + ")/" + ItmSendingQty[total].ToString(), BodyFont, Brushes.Black, 605, yPos + 3);
                    e.Graphics.DrawString(ItmUpc[total], BodyFont, Brushes.Black, 675, yPos + 3);

                    total += 1;
                }

                yPos = (k + 2) * AddressFont.GetHeight(e.Graphics);
                e.Graphics.DrawString("TOTAL SENDING QTY", HeaderFont, Brushes.Black, 330, yPos + 3);
                e.Graphics.DrawString(totalSendingQty.ToString(), HeaderFont, Brushes.Black, 610, yPos + 3);
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
            BodyFont = new Font("Cambria", 9, FontStyle.Bold);

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
            e.Graphics.DrawString("WAREHOUSE PURCHASE ORDER", TitleFont, Brushes.Black, 130, yPos + 20);
            ctr = +3;
            yPos = ctr * SubTitleFont.GetHeight(e.Graphics);
            Rectangle rPOID = new Rectangle(580, Convert.ToInt16(yPos) + 14, 180, 30);
            g1.DrawRectangle(Thick_Pen, rPOID);
            g1.DrawString("P/O #:" + Convert.ToString(parentForm2.POID), SubTitleFont, Brushes.Black, rPOID, sf);
            ctr = +8;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawString("FROM : " + parentForm2.storeName + " STORE", AddressFont, Brushes.Black, 30, yPos);
            e.Graphics.DrawString("TO : BEAUTY 4U WAREHOUSE", AddressFont, Brushes.Black, 450, yPos);
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
            e.Graphics.DrawString("ORDER DATE : " + parentForm2.createDate, AddressFont, Brushes.Black, 30, yPos);
            e.Graphics.DrawString("ORDER BY : " + parentForm2.ordererID, AddressFont, Brushes.Black, 450, yPos);
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
            e.Graphics.DrawString("CL", HeaderFont, Brushes.Black, 590, yPos + 9);
            e.Graphics.DrawString("UPC", HeaderFont, Brushes.Black, 680, yPos + 9);
            ctr = +15;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawString("(O)", HeaderFont, Brushes.Black, 50, yPos + 9);
            e.Graphics.DrawString("(S)", HeaderFont, Brushes.Black, 95, yPos + 9);
            e.Graphics.DrawString("DESCRIPTION", HeaderFont, Brushes.Black, 270, yPos + 9);
            ctr = +16;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawLine(Normal_Pen, 0, yPos + 14, 830, yPos + 14);

            if (tempPageNum <= pageNum)
            {
                for (j = 0; j < 25; j++)
                {
                    k = j + 14;
                    yPos = (k * HeaderFont.GetHeight(e.Graphics)) - 4;

                    e.Graphics.DrawString(ItmBin[total], BodyFont, Brushes.Black, 0, yPos + 3);
                    e.Graphics.DrawString(ItmOrderQty[total].ToString(), BodyFont, Brushes.Black, 50, yPos + 3);
                    e.Graphics.DrawString(ItmBrand[total], BodyFont, Brushes.Black, 140, yPos + 3);
                    e.Graphics.DrawString(ItmName[total], BodyFont, Brushes.Black, 270, yPos + 3);
                    e.Graphics.DrawString(ItmSize[total], BodyFont, Brushes.Black, 520, yPos + 3);
                    e.Graphics.DrawString(ItmColor[total], BodyFont, Brushes.Black, 590, yPos + 3);
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
                    e.Graphics.DrawString(ItmOrderQty[total].ToString(), BodyFont, Brushes.Black, 50, yPos + 3);
                    e.Graphics.DrawString(ItmBrand[total], BodyFont, Brushes.Black, 140, yPos + 3);
                    e.Graphics.DrawString(ItmName[total], BodyFont, Brushes.Black, 270, yPos + 3);
                    e.Graphics.DrawString(ItmSize[total], BodyFont, Brushes.Black, 520, yPos + 3);
                    e.Graphics.DrawString(ItmColor[total], BodyFont, Brushes.Black, 590, yPos + 3);
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

        private void pdPrint_PrintPage2(object sender, PrintPageEventArgs e)
        {
            ctr = 0;
            TitleFont = new Font("Cambria", 26, FontStyle.Bold);
            SubTitleFont = new Font("Cambria", 18, FontStyle.Bold);
            AddressFont = new Font("Cambria", 12, FontStyle.Bold);
            HeaderFont = new Font("Cambria", 15, FontStyle.Bold);
            BodyFont = new Font("Cambria", 9, FontStyle.Bold);
            FooterFont = new Font("Cambria", 15, FontStyle.Bold | FontStyle.Underline);

            /*TitleFont = new Font("Agency FB", 26);
            SubTitleFont = new Font("Agency FB", 18);
            AddressFont = new Font("Agency FB", 12);
            HeaderFont = new Font("Agency FB", 15);
            BodyFont = new Font("Agency FB", 10);
            FooterFont = new Font("Agency FB", 15, FontStyle.Underline);*/

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
            e.Graphics.DrawString("WAREHOUSE INVOICE", TitleFont, Brushes.Black, 220, yPos + 20);
            ctr = +3;
            yPos = ctr * SubTitleFont.GetHeight(e.Graphics);
            Rectangle rPOID = new Rectangle(530, Convert.ToInt16(yPos) + 14, 250, 60);
            g1.DrawRectangle(Thick_Pen, rPOID);
            g1.DrawString("INVOICE #:" + Convert.ToString(invoiceID) + "\nP/O #:" + Convert.ToString(parentForm2.POID), SubTitleFont, Brushes.Black, rPOID, sf);
            ctr = +8;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawString("TO : " + parentForm2.storeName + " STORE", AddressFont, Brushes.Black, 30, yPos + 30);
            e.Graphics.DrawString("FROM : BEAUTY 4U WAREHOUSE", AddressFont, Brushes.Black, 450, yPos + 30);
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
            e.Graphics.DrawString("SHIPPED DATE : " + parentForm2.shipDate, AddressFont, Brushes.Black, 30, yPos + 27);
            e.Graphics.DrawString("SHIPPED BY : " + parentForm2.senderID, AddressFont, Brushes.Black, 450, yPos + 27);
            ctr = +13;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawString("ORDER DATE : " + parentForm2.createDate, AddressFont, Brushes.Black, 30, yPos + 27);
            e.Graphics.DrawString("ORDER BY : " + parentForm2.ordererID, AddressFont, Brushes.Black, 450, yPos + 27);
            ctr = +14;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawLine(Dash_Pen, 32, yPos + 37, 770, yPos + 37);


            ctr = +15;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawLine(Normal_Pen, 0, yPos + 40, 830, yPos + 40);
            ctr = +16;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawString("QTY", HeaderFont, Brushes.Black, 0, yPos + 19);
            e.Graphics.DrawString("QTY", HeaderFont, Brushes.Black, 70, yPos + 19);
            e.Graphics.DrawString("BRAND".ToString(), HeaderFont, Brushes.Black, 140, yPos + 19);
            e.Graphics.DrawString("ITEM", HeaderFont, Brushes.Black, 270, yPos + 19);
            e.Graphics.DrawString("SZ", HeaderFont, Brushes.Black, 520, yPos + 19);
            e.Graphics.DrawString("CL", HeaderFont, Brushes.Black, 590, yPos + 19);
            e.Graphics.DrawString("UPC", HeaderFont, Brushes.Black, 680, yPos + 19);
            ctr = +17;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawString("(O)", HeaderFont, Brushes.Black, 0, yPos + 19);
            e.Graphics.DrawString("(S)", HeaderFont, Brushes.Black, 70, yPos + 19);
            e.Graphics.DrawString("DESCRIPTION", HeaderFont, Brushes.Black, 270, yPos + 19);
            ctr = +18;
            yPos = ctr * AddressFont.GetHeight(e.Graphics);
            e.Graphics.DrawLine(Normal_Pen, 0, yPos + 24, 830, yPos + 24);

            if (tempPageNum <= pageNum)
            {
                for (j = 0; j < 25; j++)
                {
                    k = j + 14;
                    yPos = (k * HeaderFont.GetHeight(e.Graphics)) - 4;

                    e.Graphics.DrawString(ItmOrderQty[total].ToString(), BodyFont, Brushes.Black, 0, yPos + 42);
                    e.Graphics.DrawString(ItmSendingQty[total].ToString(), BodyFont, Brushes.Black, 70, yPos + 42);
                    e.Graphics.DrawString(ItmBrand[total], BodyFont, Brushes.Black, 140, yPos + 42);
                    e.Graphics.DrawString(ItmName[total], BodyFont, Brushes.Black, 270, yPos + 42);
                    e.Graphics.DrawString(ItmSize[total], BodyFont, Brushes.Black, 520, yPos + 42);
                    e.Graphics.DrawString(ItmColor[total], BodyFont, Brushes.Black, 590, yPos + 42);
                    e.Graphics.DrawString(ItmUpc[total], BodyFont, Brushes.Black, 680, yPos + 42);

                    total += 1;
                }

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
                    yPos = k * HeaderFont.GetHeight(e.Graphics) + 15;
                    e.Graphics.DrawString("TOTAL SHIPPING AMOUNT : ", FooterFont, Brushes.Black, 250, yPos + 42);
                    e.Graphics.DrawString(string.Format("{0:$ 0.00}", totalShippingAmount), FooterFont, Brushes.Black, 520, yPos + 42);
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

                    e.Graphics.DrawString(ItmOrderQty[total].ToString(), BodyFont, Brushes.Black, 0, yPos + 42);
                    e.Graphics.DrawString(ItmSendingQty[total].ToString(), BodyFont, Brushes.Black, 70, yPos + 42);
                    e.Graphics.DrawString(ItmBrand[total], BodyFont, Brushes.Black, 140, yPos + 42);
                    e.Graphics.DrawString(ItmName[total], BodyFont, Brushes.Black, 270, yPos + 42);
                    e.Graphics.DrawString(ItmSize[total], BodyFont, Brushes.Black, 520, yPos + 42);
                    e.Graphics.DrawString(ItmColor[total], BodyFont, Brushes.Black, 590, yPos + 42);
                    e.Graphics.DrawString(ItmUpc[total], BodyFont, Brushes.Black, 680, yPos + 42);

                    total += 1;
                }

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

                yPos = k * HeaderFont.GetHeight(e.Graphics) + 15;
                e.Graphics.DrawString("TOTAL SHIPPING AMOUNT : ", FooterFont, Brushes.Black, 250, yPos + 42);
                e.Graphics.DrawString(string.Format("{0:$ 0.00}", totalShippingAmount), FooterFont, Brushes.Black, 520, yPos + 42);
                e.HasMorePages = false;
            }
        }
    }
}