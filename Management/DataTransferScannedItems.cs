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
    public partial class DataTransferScannedItems : Form
    {
        public DataTransferOption parentForm;
        public SqlCommand cmd;
        public DataTable dt = new DataTable();
        public SqlConnection connectionTo;
        Int64 sCounts = 0, oCounts = 0, dCounts = 0;

        int checkNum = 0;

        int dtRowCount_P, dtRowCount_N;

        string sp;

        public DataTransferScannedItems()
        {
            InitializeComponent();
        }

        private void DataTransferScannedItems_Load(object sender, EventArgs e)
        {
            lblCurrentStore.Text = "CURRENT SERVER : " + parentForm.parentForm1.storeName;
            //cmbStoreCdoe.SelectedIndex = 0;

            /*SqlCommand cmd_StoreList = new SqlCommand("Get_StoreList", parentForm.parentForm1.conn);
            cmd_StoreList.CommandType = CommandType.StoredProcedure;
            DataSet ds_StoreList = new DataSet();
            SqlDataAdapter adapt_StoreList = new SqlDataAdapter(cmd_StoreList);

            parentForm.parentForm1.conn.Open();
            ds_StoreList.Clear();
            adapt_StoreList.Fill(ds_StoreList);
            parentForm.parentForm1.conn.Close();

            cmbStoreCdoe.DataSource = ds_StoreList.Tables[0].DefaultView;
            cmbStoreCdoe.ValueMember = "StoreCode";
            cmbStoreCdoe.DisplayMember = "StoreCode";*/

            cmbStoreCdoe.Text = parentForm.parentForm1.StoreCode.ToUpper();

            txtUpc.SelectAll();
            txtUpc.Focus();
        }

        public void btnAdd_Click(object sender, EventArgs e)
        {
            dtRowCount_P = dt.Rows.Count;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (Convert.ToString(dataGridView1.Rows[i].Cells[29].Value) == txtUpc.Text)
                {
                    MessageBox.Show("THIS UPC IS ALREADY ADDED ON THE LIST", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUpc.SelectAll();
                    txtUpc.Focus();
                    return;
                }
            }

            cmd = new SqlCommand("Add_ItmUpc_To_LabelPrint", parentForm.parentForm1.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = txtUpc.Text;
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;

            parentForm.parentForm1.conn.Open();
            adapt.Fill(dt);
            parentForm.parentForm1.conn.Close();

            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.DataSource = dt;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
            }

            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Selected = true;
            }

            lblTotalCount1.Text = Convert.ToString(dataGridView1.RowCount);

            dtRowCount_N = dt.Rows.Count;

            if (dtRowCount_N == dtRowCount_P)
            {
                MessageBox.Show("CAN NOT FIND UPC NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtRowCount_P = 0;
                dtRowCount_N = 0;
            }
            else if ((dtRowCount_N - dtRowCount_P) == 2)
            {
                MessageBox.Show("DOUBLE UPC NUMBER", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtRowCount_P = 0;
                dtRowCount_N = 0;
            }
            else
            {
                dtRowCount_P = 0;
                dtRowCount_N = 0;
            }

            txtUpc.Clear();
            txtUpc.SelectAll();
            txtUpc.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dt.Clear();
            dataGridView1.DataSource = null;
            cmbStoreCdoe.SelectedIndex = 0;

            cmbStoreCdoe.Text = "";
            lblTotalCount1.Text = "";
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("NO ITEM", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
            {
                if (cmbStoreCdoe.Text == parentForm.parentForm1.StoreCode)
                {
                    MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cmbStoreCdoe.Text == "OH")
                {
                    connectionTo = new SqlConnection("Data Source=" + parentForm.parentForm1.OHIP + "," + parentForm.parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.parentForm1.OHDB + ";User ID=" + parentForm.parentForm1.DBUID + ";Password=" + parentForm.parentForm1.DBPSW);
                }
                else if (cmbStoreCdoe.Text == "TH")
                {
                    connectionTo = new SqlConnection("Data Source=" + parentForm.parentForm1.THIP + "," + parentForm.parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.parentForm1.THDB + ";User ID=" + parentForm.parentForm1.DBUID + ";Password=" + parentForm.parentForm1.DBPSW);
                }
                else if (cmbStoreCdoe.Text == "CH")
                {
                    connectionTo = new SqlConnection("Data Source=" + parentForm.parentForm1.CHIP + "," + parentForm.parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.parentForm1.CHDB + ";User ID=" + parentForm.parentForm1.DBUID + ";Password=" + parentForm.parentForm1.DBPSW);
                }
                else if (cmbStoreCdoe.Text == "WB")
                {
                    connectionTo = new SqlConnection("Data Source=" + parentForm.parentForm1.WBIP + "," + parentForm.parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.parentForm1.WBDB + ";User ID=" + parentForm.parentForm1.DBUID + ";Password=" + parentForm.parentForm1.DBPSW);
                }
                else if (cmbStoreCdoe.Text == "CV")
                {
                    connectionTo = new SqlConnection("Data Source=" + parentForm.parentForm1.CVIP + "," + parentForm.parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.parentForm1.CVDB + ";User ID=" + parentForm.parentForm1.DBUID + ";Password=" + parentForm.parentForm1.DBPSW);
                }
                else if (cmbStoreCdoe.Text == "UM")
                {
                    connectionTo = new SqlConnection("Data Source=" + parentForm.parentForm1.UMIP + "," + parentForm.parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.parentForm1.UMDB + ";User ID=" + parentForm.parentForm1.DBUID + ";Password=" + parentForm.parentForm1.DBPSW);
                }
                else if (cmbStoreCdoe.Text == "WM")
                {
                    connectionTo = new SqlConnection("Data Source=" + parentForm.parentForm1.WMIP + "," + parentForm.parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.parentForm1.WMDB + ";User ID=" + parentForm.parentForm1.DBUID + ";Password=" + parentForm.parentForm1.DBPSW);
                }
                else if (cmbStoreCdoe.Text == "WD")
                {
                    connectionTo = new SqlConnection("Data Source=" + parentForm.parentForm1.WDIP + "," + parentForm.parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.parentForm1.WDDB + ";User ID=" + parentForm.parentForm1.DBUID + ";Password=" + parentForm.parentForm1.DBPSW);
                }
                else if (cmbStoreCdoe.Text == "PW")
                {
                    connectionTo = new SqlConnection("Data Source=" + parentForm.parentForm1.PWIP + "," + parentForm.parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.parentForm1.PWDB + ";User ID=" + parentForm.parentForm1.DBUID + ";Password=" + parentForm.parentForm1.DBPSW);
                }
                else if (cmbStoreCdoe.Text == "GB")
                {
                    connectionTo = new SqlConnection(parentForm.parentForm1.GBCS_IP);
                }
                else if (cmbStoreCdoe.Text == "BW")
                {
                    connectionTo = new SqlConnection(parentForm.parentForm1.BWCS_IP);
                }
                else if (cmbStoreCdoe.Text == "B4UWH")
                {
                    connectionTo = new SqlConnection("Data Source=" + parentForm.parentForm1.B4UWHIP + "," + parentForm.parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.parentForm1.B4UWHDB + ";User ID=" + parentForm.parentForm1.DBUID + ";Password=" + parentForm.parentForm1.DBPSW);
                }
                else if (cmbStoreCdoe.Text == "TEST")
                {
                    connectionTo = new SqlConnection("Server=HQ-DEVELOPER;Database=TestDB;UID=ssk;Password=cherry;Connect Timeout=10");
                }
                else
                {
                    return;
                }

                progressBar1.Minimum = 0;
                progressBar1.Maximum = dataGridView1.RowCount;
                progressBar1.Step = 1;
                progressBar1.Visible = true;

                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }

            lblTotalCount1.Text = Convert.ToString(dataGridView1.RowCount);

            txtUpc.Clear();
            txtUpc.Select();
            txtUpc.Focus();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    checkNum = CheckDuplicatedUpc(dataGridView1.Rows[i].Cells[29].Value.ToString());

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
                        cmd.Parameters.Add("@ItmStoreCode", SqlDbType.NVarChar).Value = cmbStoreCdoe.Text.Trim().ToString();
                        cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[2].Value.ToString();
                        cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[4].Value.ToString();
                        cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[5].Value.ToString();
                        cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[6].Value.ToString();
                        cmd.Parameters.Add("@ItmModelNum", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[7].Value.ToString();
                        cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[8].Value.ToString();
                        cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[9].Value.ToString();
                        cmd.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[10].Value.ToString();
                        cmd.Parameters.Add("@ItmGroup4", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[11].Value.ToString();
                        cmd.Parameters.Add("@ItmGroup5", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[12].Value.ToString();
                        cmd.Parameters.Add("@ItmReservedQty", SqlDbType.Int).Value = 0;
                        cmd.Parameters.Add("@ItmStockMin", SqlDbType.Int).Value = Convert.ToInt16(dataGridView1.Rows[i].Cells[14].Value);
                        cmd.Parameters.Add("@ItmOnHand", SqlDbType.Int).Value = 0;
                        cmd.Parameters.Add("@ItmRetailPrice", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[16].Value);
                        cmd.Parameters.Add("@ItmCostPrice", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[17].Value);
                        cmd.Parameters.Add("@ItmPrc1", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[18].Value);
                        cmd.Parameters.Add("@ItmPrc2", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[19].Value);
                        cmd.Parameters.Add("@ItmPrc3", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[20].Value);
                        cmd.Parameters.Add("@ItmPrc4", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[21].Value);
                        cmd.Parameters.Add("@ItmPrc5", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[22].Value);
                        cmd.Parameters.Add("@ItmPrc6", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[23].Value);
                        cmd.Parameters.Add("@ItmPrc7", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[24].Value);
                        cmd.Parameters.Add("@ItmPrc8", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[25].Value);
                        cmd.Parameters.Add("@ItmPrc9", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[26].Value);
                        cmd.Parameters.Add("@ItmPrc10", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[27].Value);
                        cmd.Parameters.Add("@ItmStylistPrice", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[28].Value);
                        cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[29].Value.ToString();
                        cmd.Parameters.Add("@ItmBin", SqlDbType.NVarChar).Value = "-";
                        cmd.Parameters.Add("@ItmVendor", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[31].Value.ToString();
                        cmd.Parameters.Add("@ItmImage", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[32].Value.ToString();
                        cmd.Parameters.Add("@ItmRegisterDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                        cmd.Parameters.Add("@ItmTax", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[37].Value);
                        cmd.Parameters.Add("@ItmTaxable", SqlDbType.Bit).Value = Convert.ToBoolean(dataGridView1.Rows[i].Cells[38].Value);
                        cmd.Parameters.Add("@ItmMixMatch", SqlDbType.Bit).Value = Convert.ToBoolean(dataGridView1.Rows[i].Cells[39].Value);
                        cmd.Parameters.Add("@ItmMixMatchVal", SqlDbType.Int).Value = Convert.ToInt16(dataGridView1.Rows[i].Cells[40].Value);
                        cmd.Parameters.Add("@ItmMixMatchPrc", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[41].Value);
                        cmd.Parameters.Add("@ItmActive", SqlDbType.Bit).Value = false; 

                        connectionTo.Open();
                        cmd.ExecuteNonQuery();
                        connectionTo.Close();

                        sCounts += 1;
                        backgroundWorker1.ReportProgress(i + 1);
                    }
                    else if (checkNum == 1)
                    {
                        if (rdoBtnNoPrice.Checked == true)
                        {
                            sp = "Overwrite_Transferred_Item";
                        }
                        else if (rdoBtnWithPrice.Checked == true)
                        {
                            sp = "Overwrite_Transferred_Item_With_Price";
                        }

                        cmd = new SqlCommand(sp, connectionTo);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        //cmd.Parameters.Add("@ItmCode", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                        cmd.Parameters.Add("@ItmStoreCode", SqlDbType.NVarChar).Value = cmbStoreCdoe.Text.Trim().ToString();
                        cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[2].Value.ToString();
                        cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[4].Value.ToString();
                        cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[5].Value.ToString();
                        cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[6].Value.ToString();
                        cmd.Parameters.Add("@ItmModelNum", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[7].Value.ToString();
                        cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[8].Value.ToString();
                        cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[9].Value.ToString();
                        cmd.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[10].Value.ToString();
                        cmd.Parameters.Add("@ItmGroup4", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[11].Value.ToString();
                        cmd.Parameters.Add("@ItmGroup5", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[12].Value.ToString();
                        cmd.Parameters.Add("@ItmReservedQty", SqlDbType.Int).Value = 0;
                        cmd.Parameters.Add("@ItmStockMin", SqlDbType.Int).Value = Convert.ToInt16(dataGridView1.Rows[i].Cells[14].Value);
                        cmd.Parameters.Add("@ItmOnHand", SqlDbType.Int).Value = 0;
                        cmd.Parameters.Add("@ItmRetailPrice", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[16].Value);
                        cmd.Parameters.Add("@ItmCostPrice", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[17].Value);
                        cmd.Parameters.Add("@ItmPrc1", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[18].Value);
                        cmd.Parameters.Add("@ItmPrc2", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[19].Value);
                        cmd.Parameters.Add("@ItmPrc3", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[20].Value);
                        cmd.Parameters.Add("@ItmPrc4", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[21].Value);
                        cmd.Parameters.Add("@ItmPrc5", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[22].Value);
                        cmd.Parameters.Add("@ItmPrc6", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[23].Value);
                        cmd.Parameters.Add("@ItmPrc7", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[24].Value);
                        cmd.Parameters.Add("@ItmPrc8", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[25].Value);
                        cmd.Parameters.Add("@ItmPrc9", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[26].Value);
                        cmd.Parameters.Add("@ItmPrc10", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[27].Value);
                        cmd.Parameters.Add("@ItmStylistPrice", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[28].Value);
                        cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[29].Value.ToString();
                        cmd.Parameters.Add("@ItmBin", SqlDbType.NVarChar).Value = "-";
                        cmd.Parameters.Add("@ItmVendor", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[31].Value.ToString();
                        cmd.Parameters.Add("@ItmImage", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[32].Value.ToString();
                        cmd.Parameters.Add("@ItmRegisterDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                        cmd.Parameters.Add("@ItmTax", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[37].Value);
                        cmd.Parameters.Add("@ItmTaxable", SqlDbType.Bit).Value = Convert.ToBoolean(dataGridView1.Rows[i].Cells[38].Value);
                        cmd.Parameters.Add("@ItmMixMatch", SqlDbType.Bit).Value = Convert.ToBoolean(dataGridView1.Rows[i].Cells[39].Value);
                        cmd.Parameters.Add("@ItmMixMatchVal", SqlDbType.Int).Value = Convert.ToInt16(dataGridView1.Rows[i].Cells[40].Value);
                        cmd.Parameters.Add("@ItmMixMatchPrc", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[41].Value);
                        cmd.Parameters.Add("@ItmActive", SqlDbType.Bit).Value = true;

                        connectionTo.Open();
                        cmd.ExecuteNonQuery();
                        connectionTo.Close();

                        oCounts += 1;
                        backgroundWorker1.ReportProgress(i + 1);
                    }
                    else if (checkNum > 1)
                    {
                        dCounts += 1;
                        backgroundWorker1.ReportProgress(i + 1);
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

        private void btnExcelUpload_Click(object sender, EventArgs e)
        {
            UploadExcelFile2 uploadExcelFile2Form = new UploadExcelFile2(1);
            uploadExcelFile2Form.parentForm1 = this.parentForm.parentForm1;
            uploadExcelFile2Form.parentForm3 = this;
            uploadExcelFile2Form.ShowDialog();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (dCounts > 0)
            {
                MessageBox.Show("TRANSFER COMPLETED TO " + cmbStoreCdoe.Text + " SUCCESSFULLY\n\n" + Convert.ToString(sCounts) + " ITEM(S) TRANSFERRED\n" + Convert.ToString(oCounts) + " ITEM(S) OVERWRITTEN\n" + Convert.ToString(dCounts) + " ITEM(S) FOUND MORE THAN 1", "INFORMATION - TRANSFER RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Resetting();
            }
            else
            {
                MessageBox.Show("TRANSFER COMPLETED TO " + cmbStoreCdoe.Text + " SUCCESSFULLY\n\n" + Convert.ToString(sCounts) + " ITEM(S) TRANSFERRED\n" + Convert.ToString(oCounts) + " ITEM(S) OVERWRITTEN", "INFORMATION - TRANSFER RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Resetting();
            }
        }

        private void Resetting()
        {
            sCounts = 0;
            oCounts = 0;
            dCounts = 0;
            progressBar1.Visible = false;
            progressBar1.Value = 0;
        }
    }
}