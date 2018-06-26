using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Office = Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;

namespace Management
{
    public partial class UploadExcelFile : Form
    {
        public LogInManagements parentForm1;
        //public WebInventory parentForm2;
        public SqlCommand cmd0;
        public SqlCommand cmd1;
        public SqlCommand cmd2;

        public SqlConnection connChk;
        public SqlCommand cmdChk;
        public SqlCommand cmdUdt;

        SqlDataAdapter adapter;
        DataTable dt = new DataTable();

        //Int64 ItmCode;
        //string ItmstoreCode;
        int act = 0;
        //DateTime d;
        DateTime uploadDate;
        //DateTime webUpdateDate;
        //double retailPrice = 0;
        Int64 createdItem = 0;
        Int64 overwrittenItem = 0;
        int checkItmCode = 0;
        bool updateComplete = true;

        Int64 ItmCode;
        string ItmStoreCode, ItmBrand, ItmName, ItmSize, ItmColor, ItmModelNum;
        string ItmGroup1, ItmGroup2, ItmGroup3, ItmGroup4, ItmGroup5;
        int ItmReservedQty, ItmStockMin, ItmOnHand, ItmMixMatchVal;
        double ItmRetailPrice, ItmCostPrice, ItmPrc1, ItmPrc2, ItmPrc3, ItmPrc4, ItmPrc5, ItmPrc6, ItmPrc7, ItmPrc8, ItmPrc9, ItmPrc10, ItmStylistPrice;
        string ItmUpc, ItmBin, ItmVendor, ItmImage, ItmRegisterDate;
        double ItmTax, ItmMixMatchPrc;
        bool ItmTaxable, ItmMixMatch, ItmActive;

        Int64 updatedItem = 0;
        Int64 nonUpdatedItem = 0;

        public UploadExcelFile()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "OPEN EXCEL FILE";
            fDialog.InitialDirectory = @"C:\";
            fDialog.RestoreDirectory = true;
            fDialog.DefaultExt = "xls";
            fDialog.Filter = "Excel files (*.xls;*.xlsx)|*.xls;*.xlsx|All files (*.*)|*.*";
            fDialog.FilterIndex = 1;
            fDialog.CheckFileExists = true;
            fDialog.CheckPathExists = true;

            //fDialog.ShowDialog();

            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = fDialog.FileName;
                btnUpload.Enabled = true;
                dataGridView1.DataSource = null;

                //string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Sample.xlsx;Extended Properties=""Excel 12.0;HDR=YES;""";
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtFileName.Text.Trim() + ";Extended Properties=\"Excel 8.0;HDR=YES;\"";

                // if you don't want to show the header row (first row)
                // use 'HDR=NO' in the string

                string strSQL = "SELECT * FROM [ItmInventory$]";

                OleDbConnection excelConnection = new OleDbConnection(connectionString);
                excelConnection.Open();

                OleDbCommand dbCommand = new OleDbCommand(strSQL, excelConnection);
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(dbCommand);

                DataTable dTable = new DataTable();
                dataAdapter.Fill(dTable);

                try
                {
                    dataBingingSrc.DataSource = dTable;
                    dataGridView1.DataSource = dataBingingSrc;

                    dTable.Dispose();
                    dataAdapter.Dispose();
                    dbCommand.Dispose();

                    excelConnection.Close();
                    excelConnection.Dispose();
                }
                catch
                {
                    MessageBox.Show("EXCEL FILE OPEN ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dTable.Dispose();
                    dataAdapter.Dispose();
                    dbCommand.Dispose();

                    excelConnection.Close();
                    excelConnection.Dispose();
                }
            }
            else
            {
                return;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            MessageBox.Show("NOT AVAILABLE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;

            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
            {
                btnUpload.Enabled = false;
                createdItem = 0;
                overwrittenItem = 0;
                checkItmCode = 0;
                updateComplete = true;

                cmd0 = new SqlCommand("Delete_All_WebInventory", parentForm1.conn);
                cmd0.CommandType = CommandType.StoredProcedure;

                parentForm1.conn.Open();
                cmd0.ExecuteNonQuery();
                parentForm1.conn.Close();

                progressBar1.Minimum = 0;
                progressBar1.Maximum = dataGridView1.RowCount;
                progressBar1.Step = 1;

                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (Int64.TryParse(Convert.ToString(dataGridView1.Rows[i].Cells[1].Value), out ItmCode))
                    {
                        ItmStoreCode = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value).ToUpper();
                    }
                    else
                    {
                        updateComplete = false;
                        return;
                    }

                    if (int.TryParse(Convert.ToString(dataGridView1.Rows[i].Cells[2].Value), out act))
                    {
                    }
                    else
                    {
                        updateComplete = false;
                        return;
                    }

                    if (DateTime.TryParse(Convert.ToString(dataGridView1.Rows[i].Cells[3].Value), out uploadDate))
                    {
                    }
                    else
                    {
                        updateComplete = false;
                        return;
                    }

                    /*if (double.TryParse(Convert.ToString(dataGridView1.Rows[i].Cells[4].Value), out retailPrice))
                    {
                    }
                    else
                    {
                        updateComplete = false;
                        return;
                    }

                    if (DateTime.TryParse(Convert.ToString(dataGridView1.Rows[i].Cells[5].Value), out webUpdateDate))
                    {
                    }
                    else
                    {
                        updateComplete = false;
                        return;
                    }*/

                    checkItmCode = Check_ItmCode(ItmCode, ItmStoreCode, 1);

                    if (checkItmCode == -1)
                    {
                        updateComplete = false;
                        MessageBox.Show(Convert.ToString(createdItem) + " CREATED\n" + Convert.ToString(overwrittenItem) + " OVERWRITTEN\n", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (checkItmCode == 0)
                    {
                        cmd1 = new SqlCommand("Register_NewWebItem", parentForm1.conn);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.Clear();
                        cmd1.Parameters.Add("@ItmStoreCode", SqlDbType.NVarChar).Value = ItmStoreCode;
                        cmd1.Parameters.Add("@ItmCode", SqlDbType.BigInt).Value = ItmCode;
                        cmd1.Parameters.Add("@ItmActive", SqlDbType.NVarChar).Value = act;
                        cmd1.Parameters.Add("@ItmUploadDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", uploadDate);
                        //cmd1.Parameters.Add("@ItmRetailPrice", SqlDbType.NVarChar).Value = retailPrice;
                        //cmd1.Parameters.Add("@ItmWebUpdateDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", webUpdateDate);

                        parentForm1.conn.Open();
                        cmd1.ExecuteNonQuery();
                        parentForm1.conn.Close();

                        backgroundWorker1.ReportProgress(i + 1);
                        createdItem = createdItem + 1;
                    }
                    else
                    {
                        cmd1 = new SqlCommand("Overwrite_ExistingWebItem", parentForm1.conn);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.Clear();
                        cmd1.Parameters.Add("@ItmCode", SqlDbType.BigInt).Value = ItmCode;
                        cmd1.Parameters.Add("@ItmStoreCode", SqlDbType.NVarChar).Value = ItmStoreCode;
                        cmd1.Parameters.Add("@ItmActive", SqlDbType.NVarChar).Value = act;

                        parentForm1.conn.Open();
                        cmd1.ExecuteNonQuery();
                        parentForm1.conn.Close();

                        backgroundWorker1.ReportProgress(i + 1);
                        overwrittenItem = overwrittenItem + 1;
                    }
                }
            }
            catch
            {
                MessageBox.Show("UNEXPECTED ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                parentForm1.conn.Close();
                return;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (updateComplete == true)
            {
                MessageBox.Show("SUCCESSFULLY " + Convert.ToString(createdItem) + " CREATED\n" + "SUCCESSFULLY " + Convert.ToString(overwrittenItem) + " OVERWRITTEN\n", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
                //parentForm2.btnLoadItems_Click(null, null);
            }
            else
            {
                MessageBox.Show("UPADTE INCOMPLETE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
                //parentForm2.btnLoadItems_Click(null, null);
            }
        }

        private int Check_ItmCode(Int64 ic, string sc, int opt)
        {
            //try
            //{
                if (opt == 0)
                {
                    cmd2 = new SqlCommand("Check_ItmCode", parentForm1.conn);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Clear();
                    cmd2.Parameters.Add("@ItmCode", SqlDbType.BigInt).Value = ic;
                    cmd2.Parameters.Add("@ItmStoreCode", SqlDbType.NVarChar).Value = sc;
                    cmd2.Parameters.Add("@Opt", SqlDbType.NVarChar).Value = opt;
                    SqlParameter ItmCode_Param = cmd2.Parameters.Add("@Checknum", SqlDbType.Int);
                    ItmCode_Param.Direction = ParameterDirection.Output;

                    parentForm1.conn.Open();
                    cmd2.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    if (Convert.ToInt16(cmd2.Parameters["@CheckNum"].Value) > 0)
                    {
                        return Convert.ToInt16(cmd2.Parameters["@CheckNum"].Value);
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (opt == 1)
                {
                    cmd2 = new SqlCommand("Check_ItmCode", parentForm1.conn);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Clear();
                    cmd2.Parameters.Add("@ItmCode", SqlDbType.BigInt).Value = ic;
                    cmd2.Parameters.Add("@ItmStoreCode", SqlDbType.NVarChar).Value = sc;
                    cmd2.Parameters.Add("@Opt", SqlDbType.NVarChar).Value = opt;
                    SqlParameter ItmCode_Param = cmd2.Parameters.Add("@Checknum", SqlDbType.Int);
                    ItmCode_Param.Direction = ParameterDirection.Output;

                    parentForm1.conn.Open();
                    cmd2.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    if (Convert.ToInt16(cmd2.Parameters["@CheckNum"].Value) > 0)
                    {
                        return Convert.ToInt16(cmd2.Parameters["@CheckNum"].Value);
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return -1;
                }
            /*}
            catch
            {
                MessageBox.Show("CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                parentForm1.conn.Close();
                return -1;
            }*/
        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {
            if (txtFileName.Text == "")
            {
                btnUpload.Enabled = false;
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                try
                {
                    dt.Clear();

                    //connChk = new SqlConnection("Server=TH-SERVER;Database=Test;UID=ssk;Password=cherry");
                    connChk = new SqlConnection("Data Source=70.22.126.169,1433;Network Library=DBMSSOCN;Initial Catalog=Test;UID=sa;Password=macross7");
                    cmdChk = new SqlCommand("Get_Item_From_Inventory_By_ItmCode", connChk);
                    cmdChk.CommandType = CommandType.StoredProcedure;


                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        cmdChk.Parameters.Clear();
                        cmdChk.Parameters.Add("@ItmCode", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);

                        adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmdChk;

                        connChk.Open();
                        adapter.Fill(dt);
                        connChk.Close();
                    }

                    dataGridView2.DataSource = dt;
                }
                catch
                {
                    MessageBox.Show("DB UPDATE FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connChk.Close();
                    return;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView2.RowCount > 0)
            {
                DialogResult MyDialogResult;
                MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (MyDialogResult == DialogResult.Yes)
                {
                    updatedItem = 0;
                    nonUpdatedItem = 0;
                    checkItmCode = 0;

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dataGridView2.RowCount;
                    progressBar1.Step = 1;

                    backgroundWorker2.RunWorkerAsync();
                }
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            //try
            //{
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    Set_Variables(i);

                    checkItmCode = Check_ItmCode(ItmCode, ItmStoreCode, 0);

                    if (checkItmCode == -1)
                    {
                        MessageBox.Show("DB UPDATE FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        parentForm1.conn.Close();
                        return;
                    }
                    else if (checkItmCode > 0)
                    {
                        cmd1 = new SqlCommand("Update_Inventory_Admin", parentForm1.conn);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.Clear();
                        cmd1.Parameters.Add("@ItmCode", SqlDbType.BigInt).Value = ItmCode;
                        cmd1.Parameters.Add("@ItmStoreCode", SqlDbType.NVarChar).Value = ItmStoreCode;
                        cmd1.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                        cmd1.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = ItmName;
                        cmd1.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
                        cmd1.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
                        cmd1.Parameters.Add("@ItmModelNum", SqlDbType.NVarChar).Value = ItmModelNum;
                        cmd1.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = ItmGroup1;
                        cmd1.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = ItmGroup2;
                        cmd1.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = ItmGroup3;
                        cmd1.Parameters.Add("@ItmGroup4", SqlDbType.NVarChar).Value = ItmGroup4;
                        cmd1.Parameters.Add("@ItmGroup5", SqlDbType.NVarChar).Value = ItmGroup5;
                        cmd1.Parameters.Add("@ItmReservedQty", SqlDbType.Int).Value = ItmReservedQty;
                        cmd1.Parameters.Add("@ItmStockMin", SqlDbType.Int).Value = ItmStockMin;
                        cmd1.Parameters.Add("@ItmOnHand", SqlDbType.Int).Value = ItmOnHand;
                        cmd1.Parameters.Add("@ItmRetailPrice", SqlDbType.Money).Value = ItmRetailPrice;
                        cmd1.Parameters.Add("@ItmCostPrice", SqlDbType.Money).Value = ItmCostPrice;
                        cmd1.Parameters.Add("@ItmPrc1", SqlDbType.Money).Value = ItmPrc1;
                        cmd1.Parameters.Add("@ItmPrc2", SqlDbType.Money).Value = ItmPrc2;
                        cmd1.Parameters.Add("@ItmPrc3", SqlDbType.Money).Value = ItmPrc3;
                        cmd1.Parameters.Add("@ItmPrc4", SqlDbType.Money).Value = ItmPrc4;
                        cmd1.Parameters.Add("@ItmPrc5", SqlDbType.Money).Value = ItmPrc5;
                        cmd1.Parameters.Add("@ItmPrc6", SqlDbType.Money).Value = ItmPrc6;
                        cmd1.Parameters.Add("@ItmPrc7", SqlDbType.Money).Value = ItmPrc7;
                        cmd1.Parameters.Add("@ItmPrc8", SqlDbType.Money).Value = ItmPrc8;
                        cmd1.Parameters.Add("@ItmPrc9", SqlDbType.Money).Value = ItmPrc9;
                        cmd1.Parameters.Add("@ItmPrc10", SqlDbType.Money).Value = ItmPrc10;
                        cmd1.Parameters.Add("@ItmStylistPrice", SqlDbType.Money).Value = ItmStylistPrice;
                        cmd1.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
                        cmd1.Parameters.Add("@ItmBin", SqlDbType.NVarChar).Value = ItmBin;
                        cmd1.Parameters.Add("@ItmVendor", SqlDbType.NVarChar).Value = ItmVendor;
                        cmd1.Parameters.Add("@ItmImage", SqlDbType.NVarChar).Value = ItmImage;
                        cmd1.Parameters.Add("@ItmRegisterDate", SqlDbType.NVarChar).Value = ItmRegisterDate;
                        cmd1.Parameters.Add("@ItmTax", SqlDbType.Money).Value = ItmTax;
                        cmd1.Parameters.Add("@ItmTaxable", SqlDbType.Bit).Value = ItmTaxable;
                        cmd1.Parameters.Add("@ItmMixMatch", SqlDbType.Bit).Value = ItmMixMatch;
                        cmd1.Parameters.Add("@ItmMixMatchVal", SqlDbType.Int).Value = ItmMixMatchVal;
                        cmd1.Parameters.Add("@ItmMixMatchPrc", SqlDbType.Money).Value = ItmMixMatchPrc;
                        cmd1.Parameters.Add("@ItmActive", SqlDbType.Bit).Value = ItmActive;

                        parentForm1.conn.Open();
                        cmd1.ExecuteNonQuery();
                        parentForm1.conn.Close();

                        backgroundWorker1.ReportProgress(i + 1);
                        updatedItem = updatedItem + 1;
                    }
                    else
                    {
                        backgroundWorker1.ReportProgress(i + 1);
                        nonUpdatedItem = nonUpdatedItem + 1;
                    }
                }
            /*}
            catch
            {
                MessageBox.Show("DB UPDATE FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                parentForm1.conn.Close();
                return;
            }*/
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(Convert.ToString(updatedItem)+ " ITEM(S) UPDATED\n" + Convert.ToString(nonUpdatedItem)+" ITEM(S) NOT UPDATED", "RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Set_Variables(int idx)
        {
            try
            {
                ItmCode = Convert.ToInt64(dataGridView2.Rows[idx].Cells[0].Value);
                ItmStoreCode = Convert.ToString(dataGridView2.Rows[idx].Cells[1].Value);
                ItmBrand = Convert.ToString(dataGridView2.Rows[idx].Cells[2].Value);
                ItmName = Convert.ToString(dataGridView2.Rows[idx].Cells[3].Value);
                ItmSize = Convert.ToString(dataGridView2.Rows[idx].Cells[4].Value);
                ItmColor = Convert.ToString(dataGridView2.Rows[idx].Cells[5].Value);
                ItmModelNum = Convert.ToString(dataGridView2.Rows[idx].Cells[6].Value);
                ItmGroup1 = Convert.ToString(dataGridView2.Rows[idx].Cells[7].Value);
                ItmGroup2 = Convert.ToString(dataGridView2.Rows[idx].Cells[8].Value);
                ItmGroup3 = Convert.ToString(dataGridView2.Rows[idx].Cells[9].Value);
                ItmGroup4 = Convert.ToString(dataGridView2.Rows[idx].Cells[10].Value);
                ItmGroup5 = Convert.ToString(dataGridView2.Rows[idx].Cells[11].Value);
                ItmReservedQty = Convert.ToInt16(dataGridView2.Rows[idx].Cells[12].Value);
                ItmStockMin = Convert.ToInt16(dataGridView2.Rows[idx].Cells[13].Value);
                ItmOnHand = Convert.ToInt16(dataGridView2.Rows[idx].Cells[14].Value);
                ItmRetailPrice = Convert.ToDouble(dataGridView2.Rows[idx].Cells[15].Value);
                ItmCostPrice = Convert.ToDouble(dataGridView2.Rows[idx].Cells[16].Value);
                ItmPrc1 = Convert.ToDouble(dataGridView2.Rows[idx].Cells[17].Value);
                ItmPrc2 = Convert.ToDouble(dataGridView2.Rows[idx].Cells[18].Value);
                ItmPrc3 = Convert.ToDouble(dataGridView2.Rows[idx].Cells[19].Value);
                ItmPrc4 = Convert.ToDouble(dataGridView2.Rows[idx].Cells[20].Value);
                ItmPrc5 = Convert.ToDouble(dataGridView2.Rows[idx].Cells[21].Value);
                ItmPrc6 = Convert.ToDouble(dataGridView2.Rows[idx].Cells[22].Value);
                ItmPrc7 = Convert.ToDouble(dataGridView2.Rows[idx].Cells[23].Value);
                ItmPrc8 = Convert.ToDouble(dataGridView2.Rows[idx].Cells[24].Value);
                ItmPrc9 = Convert.ToDouble(dataGridView2.Rows[idx].Cells[25].Value);
                ItmPrc10 = Convert.ToDouble(dataGridView2.Rows[idx].Cells[26].Value);
                ItmStylistPrice = Convert.ToDouble(dataGridView2.Rows[idx].Cells[27].Value);
                ItmUpc = Convert.ToString(dataGridView2.Rows[idx].Cells[28].Value);
                ItmBin = Convert.ToString(dataGridView2.Rows[idx].Cells[29].Value);
                ItmVendor = Convert.ToString(dataGridView2.Rows[idx].Cells[30].Value);
                ItmImage = Convert.ToString(dataGridView2.Rows[idx].Cells[31].Value);
                ItmRegisterDate = Convert.ToString(dataGridView2.Rows[idx].Cells[32].Value);
                ItmTax = Convert.ToDouble(dataGridView2.Rows[idx].Cells[33].Value);
                ItmTaxable = Convert.ToBoolean(dataGridView2.Rows[idx].Cells[34].Value);
                ItmMixMatch = Convert.ToBoolean(dataGridView2.Rows[idx].Cells[35].Value);
                ItmMixMatchVal = Convert.ToInt16(dataGridView2.Rows[idx].Cells[36].Value);
                ItmMixMatchPrc = Convert.ToDouble(dataGridView2.Rows[idx].Cells[37].Value);
                ItmActive = Convert.ToBoolean(dataGridView2.Rows[idx].Cells[38].Value);
            }
            catch
            {
                MessageBox.Show("DATA FORMAT ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}