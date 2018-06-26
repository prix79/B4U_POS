using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Management
{
    public partial class DataTransferOption : Form
    {
        public LogInManagements parentForm1;
        public InventoryMain parentForm2;
        public InventoryMainHQ parentForm3;
        SqlCommand cmd;
        SqlCommand cmd2;
        SqlConnection connectionTo;
        SqlDataAdapter adapt;
        
        int costPriceBoolNum, retailPriceBoolNum, stylistPriceBoolNum, totalBoolNum;
        int checkNum = 0;
        string ItmUpc, sp;
        double ItmCostPrice, ItmRetailPrice, ItmStylistPrice;
        string destinationServer, destinationStoreCode;
        Int64 sCounts = 0, dCounts = 0, nCounts = 0, oCounts = 0;

        int option = 0;
        int syncOption = 0;

        public DataTransferOption(int opt)
        {
            InitializeComponent();
            option = opt;
        }

        private void DataTransferOption_Load(object sender, EventArgs e)
        {
            this.Text = "DATA TRANSFER (ACCESSED LOCATION: " + parentForm1.storeName.ToUpper() + ")";

            //if (parentForm1.StoreCode == "B4UHQ")
            //    rdoBtnTransScannedItems.Enabled = false;

            if (parentForm1.employeeID == "ADMIN")
            {
                rdoBtnTest.Visible = true;
                rdoBtnBeautyCare.Visible = true;

                rdoBtnSyncBrand.Visible = true;
                rdoBtnSyncSize.Visible = true;
                rdoBtnSyncColor.Visible = true;
                rdoBtnSyncVendor.Visible = true;
                dataGridView1.Visible = true;
            }

            if(parentForm1.txtSpecialCode.Text.Trim() == parentForm1.specialCode)
            {
                rdoBtnSyncBrand.Visible = true;
                rdoBtnSyncSize.Visible = true;
                rdoBtnSyncColor.Visible = true;
                rdoBtnSyncVendor.Visible = true;
            }

            chkBoxCostPrice.Enabled = false;
            chkBoxRetailPrice.Enabled = false;
            chkBoxStylistPrice.Enabled = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rdoBtnTransNewItems.Checked == true)
            {
                DataTransferNewItems dataTransferNewItemsForm = new DataTransferNewItems();
                dataTransferNewItemsForm.parentForm = this;
                dataTransferNewItemsForm.Show();
            }
            else if (rdoBtnTransScannedItems.Checked == true)
            {
                DataTransferScannedItems dataTransferScannedItemsForm = new DataTransferScannedItems();
                dataTransferScannedItemsForm.parentForm = this;
                dataTransferScannedItemsForm.Show();
            }
            else if (rdoBtnTransSelectedFields.Checked == true)
            {
                if (option == 0)
                {
                    if (parentForm3.dataGridView1.RowCount == 0)
                    {
                        MessageBox.Show("NO ITEM TO TRANSFER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DialogResult MyDialogResult;
                    MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (MyDialogResult == DialogResult.Yes)
                    {
                        if (chkBoxCostPrice.Checked == true)
                        {
                            costPriceBoolNum = 1;
                        }
                        else
                        {
                            costPriceBoolNum = 0;
                        }

                        if (chkBoxRetailPrice.Checked == true)
                        {
                            retailPriceBoolNum = 2;
                        }
                        else
                        {
                            retailPriceBoolNum = 0;
                        }

                        if (chkBoxStylistPrice.Checked == true)
                        {
                            stylistPriceBoolNum = 4;
                        }
                        else
                        {
                            stylistPriceBoolNum = 0;
                        }

                        totalBoolNum = costPriceBoolNum + retailPriceBoolNum + stylistPriceBoolNum;

                        if (totalBoolNum == 0)
                        {
                            MessageBox.Show("SELECT ONE FIELD AT LEAST", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (rdoBtnOH.Checked == true)
                        {
                            if (rdoBtnOH.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.OHIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.OHDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnOH.Text;
                            destinationStoreCode = "OH";
                        }
                        else if (rdoBtnCH.Checked == true)
                        {
                            if (rdoBtnCH.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.CHIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.CHDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnCH.Text;
                            destinationStoreCode = "CH";
                        }
                        else if (rdoBtnWB.Checked == true)
                        {
                            if (rdoBtnWB.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.WBIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.WBDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnWB.Text;
                            destinationStoreCode = "WB";
                        }
                        else if (rdoBtnCV.Checked == true)
                        {
                            if (rdoBtnCV.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.CVIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.CVDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnCV.Text;
                            destinationStoreCode = "CV";
                        }
                        else if (rdoBtnUM.Checked == true)
                        {
                            if (rdoBtnUM.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.UMIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.UMDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnUM.Text;
                            destinationStoreCode = "UM";
                        }
                        else if (rdoBtnWM.Checked == true)
                        {
                            if (rdoBtnWM.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.WMIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.WMDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnWM.Text;
                            destinationStoreCode = "WM";
                        }
                        else if (rdoBtnTH.Checked == true)
                        {
                            if (rdoBtnTH.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.THIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.THDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnTH.Text;
                            destinationStoreCode = "TH";
                        }
                        else if (rdoBtnWD.Checked == true)
                        {
                            if (rdoBtnWD.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.WDIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.WDDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnWD.Text;
                            destinationStoreCode = "WD";
                        }
                        else if (rdoBtnPW.Checked == true)
                        {
                            if (rdoBtnPW.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.PWIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.PWDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnPW.Text;
                            destinationStoreCode = "PW";
                        }
                        else if (rdoBtnGB.Checked == true)
                        {
                            if (rdoBtnGB.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection(parentForm1.GBCS_IP);
                            destinationServer = rdoBtnGB.Text;
                            destinationStoreCode = "GB";
                        }
                        else if (rdoBtnBW.Checked == true)
                        {
                            if (rdoBtnBW.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection(parentForm1.BWCS_IP);
                            destinationServer = rdoBtnBW.Text;
                            destinationStoreCode = "BW";
                        }
                        else if (rdoBtnB4UWH.Checked == true)
                        {
                            if (rdoBtnB4UWH.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.B4UWHIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.B4UWHDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnB4UWH.Text;
                            destinationStoreCode = "B4UWH";
                        }
                        else if (rdoBtnTest.Checked == true)
                        {
                            if (rdoBtnTest.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Server=VMWARE_DEV;Database=TestDB;UID=ssk;Password=cherry;Connect Timeout=10");
                            destinationServer = rdoBtnTest.Text;
                            destinationStoreCode = "TEST";
                        }
                        else if (rdoBtnBeautyCare.Checked == true)
                        {
                            if (rdoBtnBeautyCare.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=71.166.174.6,1433;Network Library=DBMSSOCN;Initial Catalog=BeautyCare;UID=beautycare;Password=beautycare");
                            destinationServer = rdoBtnBeautyCare.Text;
                            destinationStoreCode = "BC";
                        }
                        else
                        {
                            MessageBox.Show("SELECT DESTINATION SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        btnOK.Enabled = false;

                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = parentForm3.dataGridView1.RowCount;
                        progressBar1.Step = 1;

                        backgroundWorker1.RunWorkerAsync();
                    }
                }
                else if (option == 1)
                {
                    if (parentForm2.dataGridView1.RowCount == 0)
                    {
                        MessageBox.Show("NO ITEM TO TRANSFER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DialogResult MyDialogResult;
                    MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (MyDialogResult == DialogResult.Yes)
                    {
                        if (chkBoxCostPrice.Checked == true)
                        {
                            costPriceBoolNum = 1;
                        }
                        else
                        {
                            costPriceBoolNum = 0;
                        }

                        if (chkBoxRetailPrice.Checked == true)
                        {
                            retailPriceBoolNum = 2;
                        }
                        else
                        {
                            retailPriceBoolNum = 0;
                        }

                        if (chkBoxStylistPrice.Checked == true)
                        {
                            stylistPriceBoolNum = 4;
                        }
                        else
                        {
                            stylistPriceBoolNum = 0;
                        }

                        totalBoolNum = costPriceBoolNum + retailPriceBoolNum + stylistPriceBoolNum;

                        if (totalBoolNum == 0)
                        {
                            MessageBox.Show("SELECT ONE FIELD AT LEAST", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (rdoBtnOH.Checked == true)
                        {
                            if (rdoBtnOH.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.OHIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.OHDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnOH.Text;
                            destinationStoreCode = "OH";
                        }
                        else if (rdoBtnCH.Checked == true)
                        {
                            if (rdoBtnCH.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.CHIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.CHDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnCH.Text;
                            destinationStoreCode = "CH";
                        }
                        else if (rdoBtnWB.Checked == true)
                        {
                            if (rdoBtnWB.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.WBIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.WBDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnWB.Text;
                            destinationStoreCode = "WB";
                        }
                        else if (rdoBtnCV.Checked == true)
                        {
                            if (rdoBtnCV.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.CVIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.CVDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnCV.Text;
                            destinationStoreCode = "CV";
                        }
                        else if (rdoBtnUM.Checked == true)
                        {
                            if (rdoBtnUM.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.UMIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.UMDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnUM.Text;
                            destinationStoreCode = "UM";
                        }
                        else if (rdoBtnWM.Checked == true)
                        {
                            if (rdoBtnWM.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.WMIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.WMDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnWM.Text;
                            destinationStoreCode = "WM";
                        }
                        else if (rdoBtnTH.Checked == true)
                        {
                            if (rdoBtnTH.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.THIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.THDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnTH.Text;
                            destinationStoreCode = "TH";
                        }
                        else if (rdoBtnWD.Checked == true)
                        {
                            if (rdoBtnWD.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.WDIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.WDDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnWD.Text;
                            destinationStoreCode = "WD";
                        }
                        else if (rdoBtnPW.Checked == true)
                        {
                            if (rdoBtnPW.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.PWIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.PWDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnPW.Text;
                            destinationStoreCode = "PW";
                        }
                        else if (rdoBtnGB.Checked == true)
                        {
                            if (rdoBtnGB.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection(parentForm1.GBCS_IP);
                            destinationServer = rdoBtnGB.Text;
                            destinationStoreCode = "GB";
                        }
                        else if (rdoBtnBW.Checked == true)
                        {
                            if (rdoBtnBW.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection(parentForm1.BWCS_IP);
                            destinationServer = rdoBtnBW.Text;
                            destinationStoreCode = "BW";
                        }
                        else if (rdoBtnB4UWH.Checked == true)
                        {
                            if (rdoBtnB4UWH.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.B4UWHIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.B4UWHDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnB4UWH.Text;
                            destinationStoreCode = "B4UWH";
                        }
                        else if (rdoBtnTest.Checked == true)
                        {
                            if (rdoBtnTest.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Server=VMWARE_DEV;Database=TestDB;UID=ssk;Password=cherry;Connect Timeout=10");
                            destinationServer = rdoBtnTest.Text;
                            destinationStoreCode = "TEST";
                        }
                        else if (rdoBtnBeautyCare.Checked == true)
                        {
                            if (rdoBtnBeautyCare.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=71.166.174.6,1433;Network Library=DBMSSOCN;Initial Catalog=BeautyCare;UID=beautycare;Password=beautycare");
                            destinationServer = rdoBtnBeautyCare.Text;
                            destinationStoreCode = "BC";
                        }
                        else
                        {
                            MessageBox.Show("SELECT DESTINATION SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        btnOK.Enabled = false;

                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = parentForm2.dataGridView1.RowCount;
                        progressBar1.Step = 1;

                        backgroundWorker1.RunWorkerAsync();
                    }
                }
            }
            else if (rdoBtnTransAll.Checked == true)
            {
                if (option == 0)
                {
                    if (parentForm3.dataGridView1.RowCount == 0)
                    {
                        MessageBox.Show("NO ITEM TO TRANSFER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DialogResult MyDialogResult;
                    MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (MyDialogResult == DialogResult.Yes)
                    {
                        if (rdoBtnOH.Checked == true)
                        {
                            if (rdoBtnOH.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.OHIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.OHDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnOH.Text;
                            destinationStoreCode = "OH";
                        }
                        else if (rdoBtnCH.Checked == true)
                        {
                            if (rdoBtnCH.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.CHIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.CHDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnCH.Text;
                            destinationStoreCode = "CH";
                        }
                        else if (rdoBtnWB.Checked == true)
                        {
                            if (rdoBtnWB.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.WBIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.WBDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnWB.Text;
                            destinationStoreCode = "WB";
                        }
                        else if (rdoBtnCV.Checked == true)
                        {
                            if (rdoBtnCV.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.CVIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.CVDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnCV.Text;
                            destinationStoreCode = "CV";
                        }
                        else if (rdoBtnUM.Checked == true)
                        {
                            if (rdoBtnUM.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.UMIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.UMDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnUM.Text;
                            destinationStoreCode = "UM";
                        }
                        else if (rdoBtnWM.Checked == true)
                        {
                            if (rdoBtnWM.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.WMIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.WMDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnWM.Text;
                            destinationStoreCode = "WM";
                        }
                        else if (rdoBtnTH.Checked == true)
                        {
                            if (rdoBtnTH.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.THIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.THDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnTH.Text;
                            destinationStoreCode = "TH";
                        }
                        else if (rdoBtnWD.Checked == true)
                        {
                            if (rdoBtnWD.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.WDIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.WDDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnWD.Text;
                            destinationStoreCode = "WD";
                        }
                        else if (rdoBtnPW.Checked == true)
                        {
                            if (rdoBtnPW.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.PWIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.PWDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnPW.Text;
                            destinationStoreCode = "PW";
                        }
                        else if (rdoBtnGB.Checked == true)
                        {
                            if (rdoBtnGB.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection(parentForm1.GBCS_IP);
                            destinationServer = rdoBtnGB.Text;
                            destinationStoreCode = "GB";
                        }
                        else if (rdoBtnBW.Checked == true)
                        {
                            if (rdoBtnBW.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection(parentForm1.BWCS_IP);
                            destinationServer = rdoBtnBW.Text;
                            destinationStoreCode = "BW";
                        }
                        else if (rdoBtnB4UWH.Checked == true)
                        {
                            if (rdoBtnB4UWH.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.B4UWHIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.B4UWHDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnB4UWH.Text;
                            destinationStoreCode = "B4UWH";
                        }
                        else if (rdoBtnTest.Checked == true)
                        {
                            if (rdoBtnTest.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Server=HQ-DEVELOPER;Database=TestDB;UID=ssk;Password=cherry;Connect Timeout=10");
                            destinationServer = rdoBtnTest.Text;
                            destinationStoreCode = "TEST";
                        }
                        else if (rdoBtnBeautyCare.Checked == true)
                        {
                            if (rdoBtnBeautyCare.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=71.166.174.6,1433;Network Library=DBMSSOCN;Initial Catalog=BeautyCare;UID=beautycare;Password=beautycare");
                            destinationServer = rdoBtnBeautyCare.Text;
                            destinationStoreCode = "BC";
                        }
                        else
                        {
                            MessageBox.Show("SELECT DESTINATION SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        btnOK.Enabled = false;

                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = parentForm3.dataGridView1.RowCount;
                        progressBar1.Step = 1;

                        backgroundWorker2.RunWorkerAsync();
                    }
                }
                else if (option == 1)
                {
                    if (parentForm2.dataGridView1.RowCount == 0)
                    {
                        MessageBox.Show("NO ITEM TO TRANSFER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DialogResult MyDialogResult;
                    MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (MyDialogResult == DialogResult.Yes)
                    {
                        if (rdoBtnOH.Checked == true)
                        {
                            if (rdoBtnOH.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.OHIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.OHDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnOH.Text;
                            destinationStoreCode = "OH";
                        }
                        else if (rdoBtnCH.Checked == true)
                        {
                            if (rdoBtnCH.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.CHIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.CHDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnCH.Text;
                            destinationStoreCode = "CH";
                        }
                        else if (rdoBtnWB.Checked == true)
                        {
                            if (rdoBtnWB.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.WBIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.WBDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnWB.Text;
                            destinationStoreCode = "WB";
                        }
                        else if (rdoBtnCV.Checked == true)
                        {
                            if (rdoBtnCV.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.CVIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.CVDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnCV.Text;
                            destinationStoreCode = "CV";
                        }
                        else if (rdoBtnUM.Checked == true)
                        {
                            if (rdoBtnUM.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.UMIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.UMDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnUM.Text;
                            destinationStoreCode = "UM";
                        }
                        else if (rdoBtnWM.Checked == true)
                        {
                            if (rdoBtnWM.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.WMIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.WMDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnWM.Text;
                            destinationStoreCode = "WM";
                        }
                        else if (rdoBtnTH.Checked == true)
                        {
                            if (rdoBtnTH.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.THIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.THDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnTH.Text;
                            destinationStoreCode = "TH";
                        }
                        else if (rdoBtnWD.Checked == true)
                        {
                            if (rdoBtnWD.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.WDIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.WDDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnWD.Text;
                            destinationStoreCode = "WD";
                        }
                        else if (rdoBtnPW.Checked == true)
                        {
                            if (rdoBtnPW.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.PWIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.PWDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnPW.Text;
                            destinationStoreCode = "PW";
                        }
                        else if (rdoBtnGB.Checked == true)
                        {
                            if (rdoBtnGB.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection(parentForm1.GBCS_IP);
                            destinationServer = rdoBtnGB.Text;
                            destinationStoreCode = "GB";
                        }
                        else if (rdoBtnBW.Checked == true)
                        {
                            if (rdoBtnBW.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection(parentForm1.BWCS_IP);
                            destinationServer = rdoBtnBW.Text;
                            destinationStoreCode = "BW";
                        }
                        else if (rdoBtnB4UWH.Checked == true)
                        {
                            if (rdoBtnB4UWH.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=" + parentForm1.B4UWHIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.B4UWHDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                            destinationServer = rdoBtnB4UWH.Text;
                            destinationStoreCode = "B4UWH";
                        }
                        else if (rdoBtnTest.Checked == true)
                        {
                            if (rdoBtnTest.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Server=VMWARE_DEV;Database=TestDB;UID=ssk;Password=cherry;Connect Timeout=10");
                            destinationServer = rdoBtnTest.Text;
                            destinationStoreCode = "TEST";
                        }
                        else if (rdoBtnBeautyCare.Checked == true)
                        {
                            if (rdoBtnBeautyCare.Text == parentForm1.storeName.ToUpper())
                            {
                                MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            connectionTo = new SqlConnection("Data Source=71.166.174.6,1433;Network Library=DBMSSOCN;Initial Catalog=BeautyCare;UID=beautycare;Password=beautycare");
                            destinationServer = rdoBtnBeautyCare.Text;
                            destinationStoreCode = "BC";
                        }
                        else
                        {
                            MessageBox.Show("SELECT DESTINATION SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        btnOK.Enabled = false;

                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = parentForm2.dataGridView1.RowCount;
                        progressBar1.Step = 1;

                        backgroundWorker2.RunWorkerAsync();
                    }
                }
            }
            else
            {
                DialogResult MyDialogResult;
                MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (MyDialogResult == DialogResult.Yes)
                {
                    if (rdoBtnOH.Checked == true)
                    {
                        if (rdoBtnOH.Text == parentForm1.storeName.ToUpper())
                        {
                            MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        connectionTo = new SqlConnection(parentForm1.OHCS_IP);
                        destinationServer = rdoBtnOH.Text;
                        destinationStoreCode = "OH";
                    }
                    else if (rdoBtnCH.Checked == true)
                    {
                        if (rdoBtnCH.Text == parentForm1.storeName.ToUpper())
                        {
                            MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        connectionTo = new SqlConnection(parentForm1.CHCS_IP);
                        destinationServer = rdoBtnCH.Text;
                        destinationStoreCode = "CH";
                    }
                    else if (rdoBtnWB.Checked == true)
                    {
                        if (rdoBtnWB.Text == parentForm1.storeName.ToUpper())
                        {
                            MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        connectionTo = new SqlConnection(parentForm1.WBCS_IP);
                        destinationServer = rdoBtnWB.Text;
                        destinationStoreCode = "WB";
                    }
                    else if (rdoBtnCV.Checked == true)
                    {
                        if (rdoBtnCV.Text == parentForm1.storeName.ToUpper())
                        {
                            MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        connectionTo = new SqlConnection(parentForm1.CVCS_IP);
                        destinationServer = rdoBtnCV.Text;
                        destinationStoreCode = "CV";
                    }
                    else if (rdoBtnUM.Checked == true)
                    {
                        if (rdoBtnUM.Text == parentForm1.storeName.ToUpper())
                        {
                            MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        connectionTo = new SqlConnection(parentForm1.UMCS_IP);
                        destinationServer = rdoBtnUM.Text;
                        destinationStoreCode = "UM";
                    }
                    else if (rdoBtnWM.Checked == true)
                    {
                        if (rdoBtnWM.Text == parentForm1.storeName.ToUpper())
                        {
                            MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        connectionTo = new SqlConnection(parentForm1.WMCS_IP);
                        destinationServer = rdoBtnWM.Text;
                        destinationStoreCode = "WM";
                    }
                    else if (rdoBtnTH.Checked == true)
                    {
                        if (rdoBtnTH.Text == parentForm1.storeName.ToUpper())
                        {
                            MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        connectionTo = new SqlConnection(parentForm1.THCS_IP);
                        destinationServer = rdoBtnTH.Text;
                        destinationStoreCode = "TH";
                    }
                    else if (rdoBtnWD.Checked == true)
                    {
                        if (rdoBtnWD.Text == parentForm1.storeName.ToUpper())
                        {
                            MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        connectionTo = new SqlConnection(parentForm1.WDCS_IP);
                        destinationServer = rdoBtnWD.Text;
                        destinationStoreCode = "WD";
                    }
                    else if (rdoBtnPW.Checked == true)
                    {
                        if (rdoBtnPW.Text == parentForm1.storeName.ToUpper())
                        {
                            MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        connectionTo = new SqlConnection(parentForm1.PWCS_IP);
                        destinationServer = rdoBtnPW.Text;
                        destinationStoreCode = "PW";
                    }
                    else if (rdoBtnGB.Checked == true)
                    {
                        if (rdoBtnGB.Text == parentForm1.storeName.ToUpper())
                        {
                            MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        connectionTo = new SqlConnection(parentForm1.GBCS_IP);
                        destinationServer = rdoBtnGB.Text;
                        destinationStoreCode = "GB";
                    }
                    else if (rdoBtnBW.Checked == true)
                    {
                        if (rdoBtnBW.Text == parentForm1.storeName.ToUpper())
                        {
                            MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        connectionTo = new SqlConnection(parentForm1.BWCS_IP);
                        destinationServer = rdoBtnBW.Text;
                        destinationStoreCode = "BW";
                    }
                    else if (rdoBtnB4UWH.Checked == true)
                    {
                        if (rdoBtnB4UWH.Text == parentForm1.storeName.ToUpper())
                        {
                            MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        connectionTo = new SqlConnection(parentForm1.B4UWHCS_IP);
                        destinationServer = rdoBtnB4UWH.Text;
                        destinationStoreCode = "B4UWH";
                    }
                    else
                    {
                        MessageBox.Show("SELECT DESTINATION SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    btnOK.Enabled = false;

                    if (rdoBtnSyncBrand.Checked == true)
                    {
                        syncOption = 0;

                        cmd = new SqlCommand("Show_Brand_Table", parentForm1.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        adapt = new SqlDataAdapter();
                        adapt.SelectCommand = cmd;
                        DataTable dt = new DataTable();

                        parentForm1.conn.Open();
                        adapt.Fill(dt);
                        parentForm1.conn.Close();

                        dataGridView1.DataSource = dt;
                    }
                    else if (rdoBtnSyncSize.Checked == true)
                    {
                        syncOption = 1;

                        cmd = new SqlCommand("Show_Size_Table", parentForm1.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        adapt = new SqlDataAdapter();
                        adapt.SelectCommand = cmd;
                        DataTable dt = new DataTable();

                        parentForm1.conn.Open();
                        adapt.Fill(dt);
                        parentForm1.conn.Close();

                        dataGridView1.DataSource = dt;
                    }
                    else if (rdoBtnSyncColor.Checked == true)
                    {
                        syncOption = 2;

                        cmd = new SqlCommand("Show_Color_Table", parentForm1.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        adapt = new SqlDataAdapter();
                        adapt.SelectCommand = cmd;
                        DataTable dt = new DataTable();

                        parentForm1.conn.Open();
                        adapt.Fill(dt);
                        parentForm1.conn.Close();

                        dataGridView1.DataSource = dt;
                    }
                    else if (rdoBtnSyncVendor.Checked == true)
                    {
                        syncOption = 3;

                        cmd = new SqlCommand("Show_Vendor_Table", parentForm1.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        adapt = new SqlDataAdapter();
                        adapt.SelectCommand = cmd;
                        DataTable dt = new DataTable();

                        parentForm1.conn.Open();
                        adapt.Fill(dt);
                        parentForm1.conn.Close();

                        dataGridView1.DataSource = dt;
                    }

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dataGridView1.RowCount;
                    progressBar1.Step = 1;

                    backgroundWorker3.RunWorkerAsync();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void rdoBtnTransNewItems_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBtnTransNewItems.Checked == true)
            {
                grpDestinationServer.Enabled = false;
            }
            else
            {
                grpDestinationServer.Enabled = true;
            }
        }

        public void DataTransfer(int TBoolNum, string sp, double CostPrice, double RetailPrice, double StylistPrice, string Upc)
        {
            try
            {
                cmd = new SqlCommand(sp, connectionTo);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = TBoolNum;
                cmd.Parameters.Add("@ItmCostPrice", SqlDbType.NVarChar).Value = CostPrice;
                cmd.Parameters.Add("@ItmRetailPrice", SqlDbType.Money).Value = RetailPrice;
                cmd.Parameters.Add("@ItmStylistPrice", SqlDbType.Money).Value = StylistPrice;
                cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = Upc;

                connectionTo.Open();
                cmd.ExecuteNonQuery();
                connectionTo.Close();
            }
            catch
            {
                MessageBox.Show("TRANSFER FAILED OR CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                connectionTo.Close();
                Resetting();
                return;
            }
        }

        public int CheckDuplicatedUpc(string upc)
        {
            try
            {
                cmd = new SqlCommand("Check_Upc", connectionTo);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = upc;
                SqlParameter CheckNum_Param = cmd.Parameters.Add("@CheckNum", SqlDbType.Int);
                CheckNum_Param.Direction = ParameterDirection.Output;

                connectionTo.Open();
                cmd.ExecuteNonQuery();
                connectionTo.Close();

                if (cmd.Parameters["@CheckNum"].Value == DBNull.Value)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt16(cmd.Parameters["@CheckNum"].Value);
                }
            }
            catch
            {
                MessageBox.Show("DUPLICATE UPC CHECKING FAILED OR CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                connectionTo.Close();
                Resetting();
                return -1;
            }
        }

        private void rdoBtnTransSelectedFields_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBtnTransSelectedFields.Checked == true)
            {
                chkBoxCostPrice.Enabled = true;
                chkBoxRetailPrice.Enabled = true;
                chkBoxStylistPrice.Enabled = true;
            }
            else
            {
                chkBoxCostPrice.Checked = false;
                chkBoxRetailPrice.Checked = false;
                chkBoxStylistPrice.Checked = false;

                chkBoxCostPrice.Enabled = false;
                chkBoxRetailPrice.Enabled = false;
                chkBoxStylistPrice.Enabled = false;
            }
        }

        private void rdoBtnTransScannedItems_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBtnTransScannedItems.Checked == true)
            {
                grpDestinationServer.Enabled = false;
            }
            else
            {
                grpDestinationServer.Enabled = true;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (option == 0)
            {
                for (int i = 0; i < parentForm3.dataGridView1.RowCount; i++)
                {
                    checkNum = CheckDuplicatedUpc(parentForm3.dataGridView1.Rows[i].Cells[29].Value.ToString());

                    if (checkNum == -1)
                    {
                        return;
                    }
                    else if (checkNum == 0)
                    {
                        nCounts += 1;
                        //MessageBox.Show("COULD NOT FOUND " + parentForm2.dataGridView1.Rows[i].Cells[28].ToString(), "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (checkNum == 1)
                    {
                        switch (totalBoolNum)
                        {
                            case 1:
                                ItmRetailPrice = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[16].Value);
                                ItmCostPrice = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[17].Value);
                                ItmStylistPrice = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[28].Value);
                                ItmUpc = Convert.ToString(parentForm3.dataGridView1.Rows[i].Cells[29].Value);

                                sp = "Update_Transferred_Item_By_Selected_Fields";
                                DataTransfer(totalBoolNum, sp, ItmCostPrice, ItmRetailPrice, ItmStylistPrice, ItmUpc);
                                break;
                            case 2:
                                ItmRetailPrice = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[16].Value);
                                ItmCostPrice = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[17].Value);
                                ItmStylistPrice = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[28].Value);
                                ItmUpc = Convert.ToString(parentForm3.dataGridView1.Rows[i].Cells[29].Value);

                                sp = "Update_Transferred_Item_By_Selected_Fields";
                                DataTransfer(totalBoolNum, sp, ItmCostPrice, ItmRetailPrice, ItmStylistPrice, ItmUpc);
                                break;
                            case 3:
                                ItmRetailPrice = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[16].Value);
                                ItmCostPrice = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[17].Value);
                                ItmStylistPrice = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[28].Value);
                                ItmUpc = Convert.ToString(parentForm3.dataGridView1.Rows[i].Cells[29].Value);

                                sp = "Update_Transferred_Item_By_Selected_Fields";
                                DataTransfer(totalBoolNum, sp, ItmCostPrice, ItmRetailPrice, ItmStylistPrice, ItmUpc);
                                break;
                            case 4:
                                ItmRetailPrice = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[16].Value);
                                ItmCostPrice = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[17].Value);
                                ItmStylistPrice = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[28].Value);
                                ItmUpc = Convert.ToString(parentForm3.dataGridView1.Rows[i].Cells[29].Value);

                                sp = "Update_Transferred_Item_By_Selected_Fields";
                                DataTransfer(totalBoolNum, sp, ItmCostPrice, ItmRetailPrice, ItmStylistPrice, ItmUpc);
                                break;
                            case 5:
                                ItmRetailPrice = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[16].Value);
                                ItmCostPrice = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[17].Value);
                                ItmStylistPrice = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[28].Value);
                                ItmUpc = Convert.ToString(parentForm3.dataGridView1.Rows[i].Cells[29].Value);

                                sp = "Update_Transferred_Item_By_Selected_Fields";
                                DataTransfer(totalBoolNum, sp, ItmCostPrice, ItmRetailPrice, ItmStylistPrice, ItmUpc);
                                break;
                            case 6:
                                ItmRetailPrice = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[16].Value);
                                ItmCostPrice = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[17].Value);
                                ItmStylistPrice = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[28].Value);
                                ItmUpc = Convert.ToString(parentForm3.dataGridView1.Rows[i].Cells[29].Value);

                                sp = "Update_Transferred_Item_By_Selected_Fields";
                                DataTransfer(totalBoolNum, sp, ItmCostPrice, ItmRetailPrice, ItmStylistPrice, ItmUpc);
                                break;
                            case 7:
                                ItmRetailPrice = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[16].Value);
                                ItmCostPrice = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[17].Value);
                                ItmStylistPrice = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[28].Value);
                                ItmUpc = Convert.ToString(parentForm3.dataGridView1.Rows[i].Cells[29].Value);

                                sp = "Update_Transferred_Item_By_Selected_Fields";
                                DataTransfer(totalBoolNum, sp, ItmCostPrice, ItmRetailPrice, ItmStylistPrice, ItmUpc);
                                break;
                            default:
                                break;
                        }

                        sCounts += 1;
                    }
                    else if (checkNum > 1)
                    {
                        dCounts += 1;
                        //MessageBox.Show(parentForm2.dataGridView1.Rows[i].Cells[28].ToString() + " IS DUPLICATED", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    backgroundWorker1.ReportProgress(i + 1);
                }
            }
            else if (option == 1)
            {
                for (int i = 0; i < parentForm2.dataGridView1.RowCount; i++)
                {
                    checkNum = CheckDuplicatedUpc(parentForm2.dataGridView1.Rows[i].Cells[28].Value.ToString());

                    if (checkNum == -1)
                    {
                        return;
                    }
                    else if (checkNum == 0)
                    {
                        nCounts += 1;
                        //MessageBox.Show("COULD NOT FOUND " + parentForm2.dataGridView1.Rows[i].Cells[28].ToString(), "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (checkNum == 1)
                    {
                        switch (totalBoolNum)
                        {
                            case 1:
                                ItmCostPrice = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[16].Value);
                                ItmRetailPrice = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[15].Value);
                                ItmStylistPrice = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[27].Value);
                                ItmUpc = Convert.ToString(parentForm2.dataGridView1.Rows[i].Cells[28].Value);

                                sp = "Update_Transferred_Item_By_Selected_Fields";
                                DataTransfer(totalBoolNum, sp, ItmCostPrice, ItmRetailPrice, ItmStylistPrice, ItmUpc);
                                break;
                            case 2:
                                ItmCostPrice = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[16].Value);
                                ItmRetailPrice = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[15].Value);
                                ItmStylistPrice = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[27].Value);
                                ItmUpc = Convert.ToString(parentForm2.dataGridView1.Rows[i].Cells[28].Value);

                                sp = "Update_Transferred_Item_By_Selected_Fields";
                                DataTransfer(totalBoolNum, sp, ItmCostPrice, ItmRetailPrice, ItmStylistPrice, ItmUpc);
                                break;
                            case 3:
                                ItmCostPrice = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[16].Value);
                                ItmRetailPrice = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[15].Value);
                                ItmStylistPrice = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[27].Value);
                                ItmUpc = Convert.ToString(parentForm2.dataGridView1.Rows[i].Cells[28].Value);

                                sp = "Update_Transferred_Item_By_Selected_Fields";
                                DataTransfer(totalBoolNum, sp, ItmCostPrice, ItmRetailPrice, ItmStylistPrice, ItmUpc);
                                break;
                            case 4:
                                ItmCostPrice = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[16].Value);
                                ItmRetailPrice = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[15].Value);
                                ItmStylistPrice = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[27].Value);
                                ItmUpc = Convert.ToString(parentForm2.dataGridView1.Rows[i].Cells[28].Value);

                                sp = "Update_Transferred_Item_By_Selected_Fields";
                                DataTransfer(totalBoolNum, sp, ItmCostPrice, ItmRetailPrice, ItmStylistPrice, ItmUpc);
                                break;
                            case 5:
                                ItmCostPrice = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[16].Value);
                                ItmRetailPrice = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[15].Value);
                                ItmStylistPrice = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[27].Value);
                                ItmUpc = Convert.ToString(parentForm2.dataGridView1.Rows[i].Cells[28].Value);

                                sp = "Update_Transferred_Item_By_Selected_Fields";
                                DataTransfer(totalBoolNum, sp, ItmCostPrice, ItmRetailPrice, ItmStylistPrice, ItmUpc);
                                break;
                            case 6:
                                ItmCostPrice = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[16].Value);
                                ItmRetailPrice = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[15].Value);
                                ItmStylistPrice = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[27].Value);
                                ItmUpc = Convert.ToString(parentForm2.dataGridView1.Rows[i].Cells[28].Value);

                                sp = "Update_Transferred_Item_By_Selected_Fields";
                                DataTransfer(totalBoolNum, sp, ItmCostPrice, ItmRetailPrice, ItmStylistPrice, ItmUpc);
                                break;
                            case 7:
                                ItmCostPrice = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[16].Value);
                                ItmRetailPrice = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[15].Value);
                                ItmStylistPrice = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[27].Value);
                                ItmUpc = Convert.ToString(parentForm2.dataGridView1.Rows[i].Cells[28].Value);

                                sp = "Update_Transferred_Item_By_Selected_Fields";
                                DataTransfer(totalBoolNum, sp, ItmCostPrice, ItmRetailPrice, ItmStylistPrice, ItmUpc);
                                break;
                            default:
                                break;
                        }

                        sCounts += 1;
                    }
                    else if (checkNum > 1)
                    {
                        dCounts += 1;
                        //MessageBox.Show(parentForm2.dataGridView1.Rows[i].Cells[28].ToString() + " IS DUPLICATED", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    backgroundWorker1.ReportProgress(i + 1);
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("TRANSFER COMPLETED SUCCESSFULLY TO " + destinationServer + " SERVER\n\n" + Convert.ToUInt64(sCounts) + " ITEM(S) UPDATED\n" + Convert.ToString(dCounts) + " ITEM(S) GOT DOUBLE UPC\n" + Convert.ToString(nCounts) + " ITEM(S) COULD NOT BE FOUND", "INFORMATION - TRANSFER RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnOK.Enabled = true;
            Resetting();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (option == 0)
                {
                    for (int i = 0; i < parentForm3.dataGridView1.RowCount; i++)
                    {
                        checkNum = CheckDuplicatedUpc(parentForm3.dataGridView1.Rows[i].Cells[29].Value.ToString());

                        if (checkNum == -1)
                        {
                            return;
                        }
                        else if (checkNum == 0)
                        {
                            cmd = new SqlCommand("Insert_Transferred_Item", connectionTo);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            //cmd.Parameters.Add("@ItmCode", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                            cmd.Parameters.Add("@ItmStoreCode", SqlDbType.NVarChar).Value = destinationStoreCode;
                            cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = parentForm3.dataGridView1.Rows[i].Cells[2].Value.ToString();
                            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = parentForm3.dataGridView1.Rows[i].Cells[4].Value.ToString();
                            cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = parentForm3.dataGridView1.Rows[i].Cells[5].Value.ToString();
                            cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = parentForm3.dataGridView1.Rows[i].Cells[6].Value.ToString();
                            cmd.Parameters.Add("@ItmModelNum", SqlDbType.NVarChar).Value = parentForm3.dataGridView1.Rows[i].Cells[7].Value.ToString();
                            cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = parentForm3.dataGridView1.Rows[i].Cells[8].Value.ToString();
                            cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = parentForm3.dataGridView1.Rows[i].Cells[9].Value.ToString();
                            cmd.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = parentForm3.dataGridView1.Rows[i].Cells[10].Value.ToString();
                            cmd.Parameters.Add("@ItmGroup4", SqlDbType.NVarChar).Value = parentForm3.dataGridView1.Rows[i].Cells[11].Value.ToString();
                            cmd.Parameters.Add("@ItmGroup5", SqlDbType.NVarChar).Value = parentForm3.dataGridView1.Rows[i].Cells[12].Value.ToString();
                            cmd.Parameters.Add("@ItmReservedQty", SqlDbType.Int).Value = 0;
                            cmd.Parameters.Add("@ItmStockMin", SqlDbType.Int).Value = Convert.ToInt16(parentForm3.dataGridView1.Rows[i].Cells[14].Value);
                            cmd.Parameters.Add("@ItmOnHand", SqlDbType.Int).Value = 0;
                            cmd.Parameters.Add("@ItmRetailPrice", SqlDbType.Money).Value = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[16].Value);
                            cmd.Parameters.Add("@ItmCostPrice", SqlDbType.Money).Value = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[17].Value);
                            cmd.Parameters.Add("@ItmPrc1", SqlDbType.Money).Value = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[18].Value);
                            cmd.Parameters.Add("@ItmPrc2", SqlDbType.Money).Value = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[19].Value);
                            cmd.Parameters.Add("@ItmPrc3", SqlDbType.Money).Value = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[20].Value);
                            cmd.Parameters.Add("@ItmPrc4", SqlDbType.Money).Value = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[21].Value);
                            cmd.Parameters.Add("@ItmPrc5", SqlDbType.Money).Value = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[22].Value);
                            cmd.Parameters.Add("@ItmPrc6", SqlDbType.Money).Value = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[23].Value);
                            cmd.Parameters.Add("@ItmPrc7", SqlDbType.Money).Value = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[24].Value);
                            cmd.Parameters.Add("@ItmPrc8", SqlDbType.Money).Value = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[25].Value);
                            cmd.Parameters.Add("@ItmPrc9", SqlDbType.Money).Value = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[26].Value);
                            cmd.Parameters.Add("@ItmPrc10", SqlDbType.Money).Value = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[27].Value);
                            cmd.Parameters.Add("@ItmStylistPrice", SqlDbType.Money).Value = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[28].Value);
                            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = parentForm3.dataGridView1.Rows[i].Cells[29].Value.ToString();
                            cmd.Parameters.Add("@ItmBin", SqlDbType.NVarChar).Value = "-";
                            cmd.Parameters.Add("@ItmVendor", SqlDbType.NVarChar).Value = parentForm3.dataGridView1.Rows[i].Cells[31].Value.ToString();
                            cmd.Parameters.Add("@ItmImage", SqlDbType.NVarChar).Value = parentForm3.dataGridView1.Rows[i].Cells[32].Value.ToString();
                            cmd.Parameters.Add("@ItmRegisterDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                            cmd.Parameters.Add("@ItmTax", SqlDbType.Money).Value = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[37].Value);
                            cmd.Parameters.Add("@ItmTaxable", SqlDbType.Bit).Value = Convert.ToBoolean(parentForm3.dataGridView1.Rows[i].Cells[38].Value);
                            cmd.Parameters.Add("@ItmMixMatch", SqlDbType.Bit).Value = Convert.ToBoolean(parentForm3.dataGridView1.Rows[i].Cells[39].Value);
                            cmd.Parameters.Add("@ItmMixMatchVal", SqlDbType.Int).Value = Convert.ToInt16(parentForm3.dataGridView1.Rows[i].Cells[40].Value);
                            cmd.Parameters.Add("@ItmMixMatchPrc", SqlDbType.Money).Value = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[41].Value);
                            cmd.Parameters.Add("@ItmActive", SqlDbType.Bit).Value = false;

                            connectionTo.Open();
                            cmd.ExecuteNonQuery();
                            connectionTo.Close();

                            sCounts += 1;
                            backgroundWorker2.ReportProgress(i + 1);
                        }
                        else if (checkNum == 1)
                        {
                            cmd = new SqlCommand("Overwrite_Transferred_Item", connectionTo);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            //cmd.Parameters.Add("@ItmCode", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                            cmd.Parameters.Add("@ItmStoreCode", SqlDbType.NVarChar).Value = destinationStoreCode;
                            cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = parentForm3.dataGridView1.Rows[i].Cells[2].Value.ToString();
                            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = parentForm3.dataGridView1.Rows[i].Cells[4].Value.ToString();
                            cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = parentForm3.dataGridView1.Rows[i].Cells[5].Value.ToString();
                            cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = parentForm3.dataGridView1.Rows[i].Cells[6].Value.ToString();
                            cmd.Parameters.Add("@ItmModelNum", SqlDbType.NVarChar).Value = parentForm3.dataGridView1.Rows[i].Cells[7].Value.ToString();
                            cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = parentForm3.dataGridView1.Rows[i].Cells[8].Value.ToString();
                            cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = parentForm3.dataGridView1.Rows[i].Cells[9].Value.ToString();
                            cmd.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = parentForm3.dataGridView1.Rows[i].Cells[10].Value.ToString();
                            cmd.Parameters.Add("@ItmGroup4", SqlDbType.NVarChar).Value = parentForm3.dataGridView1.Rows[i].Cells[11].Value.ToString();
                            cmd.Parameters.Add("@ItmGroup5", SqlDbType.NVarChar).Value = parentForm3.dataGridView1.Rows[i].Cells[12].Value.ToString();
                            cmd.Parameters.Add("@ItmReservedQty", SqlDbType.Int).Value = 0;
                            cmd.Parameters.Add("@ItmStockMin", SqlDbType.Int).Value = Convert.ToInt16(parentForm3.dataGridView1.Rows[i].Cells[14].Value);
                            cmd.Parameters.Add("@ItmOnHand", SqlDbType.Int).Value = 0;
                            cmd.Parameters.Add("@ItmRetailPrice", SqlDbType.Money).Value = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[16].Value);
                            cmd.Parameters.Add("@ItmCostPrice", SqlDbType.Money).Value = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[17].Value);
                            cmd.Parameters.Add("@ItmPrc1", SqlDbType.Money).Value = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[18].Value);
                            cmd.Parameters.Add("@ItmPrc2", SqlDbType.Money).Value = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[19].Value);
                            cmd.Parameters.Add("@ItmPrc3", SqlDbType.Money).Value = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[20].Value);
                            cmd.Parameters.Add("@ItmPrc4", SqlDbType.Money).Value = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[21].Value);
                            cmd.Parameters.Add("@ItmPrc5", SqlDbType.Money).Value = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[22].Value);
                            cmd.Parameters.Add("@ItmPrc6", SqlDbType.Money).Value = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[23].Value);
                            cmd.Parameters.Add("@ItmPrc7", SqlDbType.Money).Value = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[24].Value);
                            cmd.Parameters.Add("@ItmPrc8", SqlDbType.Money).Value = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[25].Value);
                            cmd.Parameters.Add("@ItmPrc9", SqlDbType.Money).Value = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[26].Value);
                            cmd.Parameters.Add("@ItmPrc10", SqlDbType.Money).Value = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[27].Value);
                            cmd.Parameters.Add("@ItmStylistPrice", SqlDbType.Money).Value = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[28].Value);
                            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = parentForm3.dataGridView1.Rows[i].Cells[29].Value.ToString();
                            cmd.Parameters.Add("@ItmBin", SqlDbType.NVarChar).Value = "-";
                            cmd.Parameters.Add("@ItmVendor", SqlDbType.NVarChar).Value = parentForm3.dataGridView1.Rows[i].Cells[31].Value.ToString();
                            cmd.Parameters.Add("@ItmImage", SqlDbType.NVarChar).Value = parentForm3.dataGridView1.Rows[i].Cells[32].Value.ToString();
                            cmd.Parameters.Add("@ItmRegisterDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                            cmd.Parameters.Add("@ItmTax", SqlDbType.Money).Value = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[37].Value);
                            cmd.Parameters.Add("@ItmTaxable", SqlDbType.Bit).Value = Convert.ToBoolean(parentForm3.dataGridView1.Rows[i].Cells[38].Value);
                            cmd.Parameters.Add("@ItmMixMatch", SqlDbType.Bit).Value = Convert.ToBoolean(parentForm3.dataGridView1.Rows[i].Cells[39].Value);
                            cmd.Parameters.Add("@ItmMixMatchVal", SqlDbType.Int).Value = Convert.ToInt16(parentForm3.dataGridView1.Rows[i].Cells[40].Value);
                            cmd.Parameters.Add("@ItmMixMatchPrc", SqlDbType.Money).Value = Convert.ToDouble(parentForm3.dataGridView1.Rows[i].Cells[41].Value);
                            cmd.Parameters.Add("@ItmActive", SqlDbType.Bit).Value = true;

                            connectionTo.Open();
                            cmd.ExecuteNonQuery();
                            connectionTo.Close();

                            oCounts += 1;
                            backgroundWorker2.ReportProgress(i + 1);
                        }
                        else if (checkNum > 1)
                        {
                            dCounts += 1;
                            backgroundWorker2.ReportProgress(i + 1);
                        }
                    }
                }
                else if (option == 1)
                {
                    for (int i = 0; i < parentForm2.dataGridView1.RowCount; i++)
                    {
                        checkNum = CheckDuplicatedUpc(parentForm2.dataGridView1.Rows[i].Cells[28].Value.ToString());

                        if (checkNum == -1)
                        {
                            return;
                        }
                        else if (checkNum == 0)
                        {
                            cmd = new SqlCommand("Insert_Transferred_Item", connectionTo);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            //cmd.Parameters.Add("@ItmCode", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                            cmd.Parameters.Add("@ItmStoreCode", SqlDbType.NVarChar).Value = destinationStoreCode;
                            cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = parentForm2.dataGridView1.Rows[i].Cells[2].Value.ToString();
                            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = parentForm2.dataGridView1.Rows[i].Cells[3].Value.ToString();
                            cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = parentForm2.dataGridView1.Rows[i].Cells[4].Value.ToString();
                            cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = parentForm2.dataGridView1.Rows[i].Cells[5].Value.ToString();
                            cmd.Parameters.Add("@ItmModelNum", SqlDbType.NVarChar).Value = parentForm2.dataGridView1.Rows[i].Cells[6].Value.ToString();
                            cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = parentForm2.dataGridView1.Rows[i].Cells[7].Value.ToString();
                            cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = parentForm2.dataGridView1.Rows[i].Cells[8].Value.ToString();
                            cmd.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = parentForm2.dataGridView1.Rows[i].Cells[9].Value.ToString();
                            cmd.Parameters.Add("@ItmGroup4", SqlDbType.NVarChar).Value = parentForm2.dataGridView1.Rows[i].Cells[10].Value.ToString();
                            cmd.Parameters.Add("@ItmGroup5", SqlDbType.NVarChar).Value = parentForm2.dataGridView1.Rows[i].Cells[11].Value.ToString();
                            cmd.Parameters.Add("@ItmReservedQty", SqlDbType.Int).Value = 0;
                            cmd.Parameters.Add("@ItmStockMin", SqlDbType.Int).Value = Convert.ToInt16(parentForm2.dataGridView1.Rows[i].Cells[13].Value);
                            cmd.Parameters.Add("@ItmOnHand", SqlDbType.Int).Value = 0;
                            cmd.Parameters.Add("@ItmRetailPrice", SqlDbType.Money).Value = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[15].Value);
                            cmd.Parameters.Add("@ItmCostPrice", SqlDbType.Money).Value = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[16].Value);
                            cmd.Parameters.Add("@ItmPrc1", SqlDbType.Money).Value = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[17].Value);
                            cmd.Parameters.Add("@ItmPrc2", SqlDbType.Money).Value = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[18].Value);
                            cmd.Parameters.Add("@ItmPrc3", SqlDbType.Money).Value = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[19].Value);
                            cmd.Parameters.Add("@ItmPrc4", SqlDbType.Money).Value = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[20].Value);
                            cmd.Parameters.Add("@ItmPrc5", SqlDbType.Money).Value = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[21].Value);
                            cmd.Parameters.Add("@ItmPrc6", SqlDbType.Money).Value = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[22].Value);
                            cmd.Parameters.Add("@ItmPrc7", SqlDbType.Money).Value = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[23].Value);
                            cmd.Parameters.Add("@ItmPrc8", SqlDbType.Money).Value = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[24].Value);
                            cmd.Parameters.Add("@ItmPrc9", SqlDbType.Money).Value = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[25].Value);
                            cmd.Parameters.Add("@ItmPrc10", SqlDbType.Money).Value = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[26].Value);
                            cmd.Parameters.Add("@ItmStylistPrice", SqlDbType.Money).Value = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[27].Value);
                            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = parentForm2.dataGridView1.Rows[i].Cells[28].Value.ToString();
                            cmd.Parameters.Add("@ItmBin", SqlDbType.NVarChar).Value = "-";
                            cmd.Parameters.Add("@ItmVendor", SqlDbType.NVarChar).Value = parentForm2.dataGridView1.Rows[i].Cells[30].Value.ToString();
                            cmd.Parameters.Add("@ItmImage", SqlDbType.NVarChar).Value = parentForm2.dataGridView1.Rows[i].Cells[31].Value.ToString();
                            cmd.Parameters.Add("@ItmRegisterDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                            cmd.Parameters.Add("@ItmTax", SqlDbType.Money).Value = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[33].Value);
                            cmd.Parameters.Add("@ItmTaxable", SqlDbType.Bit).Value = Convert.ToBoolean(parentForm2.dataGridView1.Rows[i].Cells[34].Value);
                            cmd.Parameters.Add("@ItmMixMatch", SqlDbType.Bit).Value = Convert.ToBoolean(parentForm2.dataGridView1.Rows[i].Cells[35].Value);
                            cmd.Parameters.Add("@ItmMixMatchVal", SqlDbType.Int).Value = Convert.ToInt16(parentForm2.dataGridView1.Rows[i].Cells[36].Value);
                            cmd.Parameters.Add("@ItmMixMatchPrc", SqlDbType.Money).Value = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[37].Value);
                            cmd.Parameters.Add("@ItmActive", SqlDbType.Bit).Value = false;

                            connectionTo.Open();
                            cmd.ExecuteNonQuery();
                            connectionTo.Close();

                            sCounts += 1;
                            backgroundWorker2.ReportProgress(i + 1);
                        }
                        else if (checkNum == 1)
                        {
                            cmd = new SqlCommand("Overwrite_Transferred_Item", connectionTo);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            //cmd.Parameters.Add("@ItmCode", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                            cmd.Parameters.Add("@ItmStoreCode", SqlDbType.NVarChar).Value = destinationStoreCode;
                            cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = parentForm2.dataGridView1.Rows[i].Cells[2].Value.ToString();
                            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = parentForm2.dataGridView1.Rows[i].Cells[3].Value.ToString();
                            cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = parentForm2.dataGridView1.Rows[i].Cells[4].Value.ToString();
                            cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = parentForm2.dataGridView1.Rows[i].Cells[5].Value.ToString();
                            cmd.Parameters.Add("@ItmModelNum", SqlDbType.NVarChar).Value = parentForm2.dataGridView1.Rows[i].Cells[6].Value.ToString();
                            cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = parentForm2.dataGridView1.Rows[i].Cells[7].Value.ToString();
                            cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = parentForm2.dataGridView1.Rows[i].Cells[8].Value.ToString();
                            cmd.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = parentForm2.dataGridView1.Rows[i].Cells[9].Value.ToString();
                            cmd.Parameters.Add("@ItmGroup4", SqlDbType.NVarChar).Value = parentForm2.dataGridView1.Rows[i].Cells[10].Value.ToString();
                            cmd.Parameters.Add("@ItmGroup5", SqlDbType.NVarChar).Value = parentForm2.dataGridView1.Rows[i].Cells[11].Value.ToString();
                            cmd.Parameters.Add("@ItmReservedQty", SqlDbType.Int).Value = 0;
                            cmd.Parameters.Add("@ItmStockMin", SqlDbType.Int).Value = Convert.ToInt16(parentForm2.dataGridView1.Rows[i].Cells[13].Value);
                            cmd.Parameters.Add("@ItmOnHand", SqlDbType.Int).Value = 0;
                            cmd.Parameters.Add("@ItmRetailPrice", SqlDbType.Money).Value = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[15].Value);
                            cmd.Parameters.Add("@ItmCostPrice", SqlDbType.Money).Value = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[16].Value);
                            cmd.Parameters.Add("@ItmPrc1", SqlDbType.Money).Value = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[17].Value);
                            cmd.Parameters.Add("@ItmPrc2", SqlDbType.Money).Value = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[18].Value);
                            cmd.Parameters.Add("@ItmPrc3", SqlDbType.Money).Value = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[19].Value);
                            cmd.Parameters.Add("@ItmPrc4", SqlDbType.Money).Value = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[20].Value);
                            cmd.Parameters.Add("@ItmPrc5", SqlDbType.Money).Value = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[21].Value);
                            cmd.Parameters.Add("@ItmPrc6", SqlDbType.Money).Value = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[22].Value);
                            cmd.Parameters.Add("@ItmPrc7", SqlDbType.Money).Value = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[23].Value);
                            cmd.Parameters.Add("@ItmPrc8", SqlDbType.Money).Value = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[24].Value);
                            cmd.Parameters.Add("@ItmPrc9", SqlDbType.Money).Value = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[25].Value);
                            cmd.Parameters.Add("@ItmPrc10", SqlDbType.Money).Value = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[26].Value);
                            cmd.Parameters.Add("@ItmStylistPrice", SqlDbType.Money).Value = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[27].Value);
                            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = parentForm2.dataGridView1.Rows[i].Cells[28].Value.ToString();
                            cmd.Parameters.Add("@ItmBin", SqlDbType.NVarChar).Value = "-";
                            cmd.Parameters.Add("@ItmVendor", SqlDbType.NVarChar).Value = parentForm2.dataGridView1.Rows[i].Cells[30].Value.ToString();
                            cmd.Parameters.Add("@ItmImage", SqlDbType.NVarChar).Value = parentForm2.dataGridView1.Rows[i].Cells[31].Value.ToString();
                            cmd.Parameters.Add("@ItmRegisterDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                            cmd.Parameters.Add("@ItmTax", SqlDbType.Money).Value = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[33].Value);
                            cmd.Parameters.Add("@ItmTaxable", SqlDbType.Bit).Value = Convert.ToBoolean(parentForm2.dataGridView1.Rows[i].Cells[34].Value);
                            cmd.Parameters.Add("@ItmMixMatch", SqlDbType.Bit).Value = Convert.ToBoolean(parentForm2.dataGridView1.Rows[i].Cells[35].Value);
                            cmd.Parameters.Add("@ItmMixMatchVal", SqlDbType.Int).Value = Convert.ToInt16(parentForm2.dataGridView1.Rows[i].Cells[36].Value);
                            cmd.Parameters.Add("@ItmMixMatchPrc", SqlDbType.Money).Value = Convert.ToDouble(parentForm2.dataGridView1.Rows[i].Cells[37].Value);
                            cmd.Parameters.Add("@ItmActive", SqlDbType.Bit).Value = true;

                            connectionTo.Open();
                            cmd.ExecuteNonQuery();
                            connectionTo.Close();

                            oCounts += 1;
                            backgroundWorker2.ReportProgress(i + 1);
                        }
                        else if (checkNum > 1)
                        {
                            dCounts += 1;
                            backgroundWorker2.ReportProgress(i + 1);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("TRANSFER FAILED OR CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                connectionTo.Close();
                Resetting();
                return;
            }
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("TRANSFER COMPLETED SUCCESSFULLY TO " + destinationServer + " SERVER\n\n" + Convert.ToUInt64(sCounts) + " ITEM(S) CREATED\n" + Convert.ToString(oCounts) + " ITEM(S) OVERWRITTEN\n" + Convert.ToString(dCounts) + " ITEM(S) FOUND MORE THAN 1", "INFORMATION - TRANSFER RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnOK.Enabled = true;
            Resetting();
        }

        private void Resetting()
        {
            progressBar1.Value = 0;
            sCounts = 0;
            oCounts = 0;
            dCounts = 0;
            destinationServer = string.Empty;
            destinationStoreCode = string.Empty;
            //rdoBtnTransNewItems.Checked = true;
            syncOption = 0;
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (syncOption == 0)
                {
                    cmd = new SqlCommand("Delete_Brand", connectionTo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    connectionTo.Open();
                    cmd.ExecuteNonQuery();
                    connectionTo.Close();

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        cmd2 = new SqlCommand("Insert_Brand", connectionTo);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.Clear();
                        cmd2.Parameters.Add("@BrandName", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[1].Value.ToString();

                        connectionTo.Open();
                        cmd2.ExecuteNonQuery();
                        connectionTo.Close();

                        sCounts += 1;
                        backgroundWorker3.ReportProgress(i + 1);
                    }
                }
                else if (syncOption == 1)
                {
                    cmd = new SqlCommand("Delete_Size", connectionTo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    connectionTo.Open();
                    cmd.ExecuteNonQuery();
                    connectionTo.Close();

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        cmd2 = new SqlCommand("Insert_Size", connectionTo);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.Clear();
                        cmd2.Parameters.Add("@SizeName", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[1].Value.ToString();

                        connectionTo.Open();
                        cmd2.ExecuteNonQuery();
                        connectionTo.Close();

                        sCounts += 1;
                        backgroundWorker3.ReportProgress(i + 1);
                    }
                }
                else if (syncOption == 2)
                {
                    cmd = new SqlCommand("Delete_Color", connectionTo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    connectionTo.Open();
                    cmd.ExecuteNonQuery();
                    connectionTo.Close();

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        cmd2 = new SqlCommand("Insert_Color", connectionTo);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.Clear();
                        cmd2.Parameters.Add("@ColorName", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[1].Value.ToString();

                        connectionTo.Open();
                        cmd2.ExecuteNonQuery();
                        connectionTo.Close();

                        sCounts += 1;
                        backgroundWorker3.ReportProgress(i + 1);
                    }
                }
                else if (syncOption == 3)
                {
                    cmd = new SqlCommand("Delete_Vendor", connectionTo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    connectionTo.Open();
                    cmd.ExecuteNonQuery();
                    connectionTo.Close();

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        cmd2 = new SqlCommand("Insert_Vendor", connectionTo);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.Clear();
                        cmd2.Parameters.Add("@VendorCode", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        cmd2.Parameters.Add("@VendorName", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[2].Value.ToString();

                        connectionTo.Open();
                        cmd2.ExecuteNonQuery();
                        connectionTo.Close();

                        sCounts += 1;
                        backgroundWorker3.ReportProgress(i + 1);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Transfer failed or connection failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                connectionTo.Close();
                Resetting();
                return;
            }
        }

        private void backgroundWorker3_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (syncOption == 0)
            {
                MessageBox.Show(sCounts.ToString() + " brand(s) transfer completed successfully to " + destinationServer + " server\n\n", "Transfer result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnOK.Enabled = true;
                Resetting();
            }
            else if (syncOption == 1)
            {
                MessageBox.Show(sCounts.ToString() + " size(s) transfer completed successfully to " + destinationServer + " server\n\n", "Transfer result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnOK.Enabled = true;
                Resetting();
            }
            else if (syncOption == 2)
            {
                MessageBox.Show(sCounts.ToString() + " color(s) transfer completed successfully to " + destinationServer + " server\n\n", "Transfer result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnOK.Enabled = true;
                Resetting();
            }
            else if (syncOption == 3)
            {
                MessageBox.Show(sCounts.ToString() + " vendor(s) transfer completed successfully to " + destinationServer + " server\n\n", "Transfer result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnOK.Enabled = true;
                Resetting();
            }
        }
    }
}