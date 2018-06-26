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
    public partial class PromotionTransfer : Form
    {
        public LogInManagements parentForm1;
        public PromotionMain parentForm2;
        Int64 pmCode;

        public SqlCommand cmd = new SqlCommand();
        public SqlCommand cmd_PH = new SqlCommand();
        public SqlCommand cmd_PB = new SqlCommand();
        public DataTable dt = new DataTable();
        public SqlConnection connectionTo;

        public PromotionTransfer(Int64 promotionCode, string pmName, string pmStartDate, string pmEndDate)
        {
            InitializeComponent();
            pmCode = promotionCode;
            txtPromotionCode.Text = Convert.ToString(pmCode);
            txtPromotionName.Text = pmName;
            txtStartDate.Text = pmStartDate;
            txtEndDate.Text = pmEndDate;
        }

        private void TransferPromotion_Load(object sender, EventArgs e)
        {
            //cmbStoreCdoe.SelectedIndex = 0;

            SqlCommand cmd_StoreList = new SqlCommand("Get_Retail_StoreCode", parentForm1.conn);
            cmd_StoreList.CommandType = CommandType.StoredProcedure;
            DataSet ds_StoreList = new DataSet();
            SqlDataAdapter adapt_StoreList = new SqlDataAdapter(cmd_StoreList);

            parentForm1.conn.Open();
            ds_StoreList.Clear();
            adapt_StoreList.Fill(ds_StoreList);
            parentForm1.conn.Close();
            
            cmbStoreCdoe.DataSource = ds_StoreList.Tables[0].DefaultView;
            cmbStoreCdoe.ValueMember = "CIStoreCode";
            cmbStoreCdoe.DisplayMember = "CIStoreCode";

            cmbStoreCdoe.Text = parentForm1.StoreCode.ToUpper();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
            {
                if (cmbStoreCdoe.Text == parentForm1.StoreCode)
                {
                    MessageBox.Show("CAN NOT TRANSFER TO SAME SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (parentForm2.dataGridView3.RowCount == 0)
                {
                    MessageBox.Show("NO PROMOTION ITEM IN BODY", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cmbStoreCdoe.Text == "OH")
                {
                    connectionTo = new SqlConnection("Data Source=" + parentForm1.OHIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.OHDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                }
                else if (cmbStoreCdoe.Text == "TH")
                {
                    connectionTo = new SqlConnection("Data Source=" + parentForm1.THIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.THDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                }
                else if (cmbStoreCdoe.Text == "CH")
                {
                    connectionTo = new SqlConnection("Data Source=" + parentForm1.CHIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.CHDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                }
                else if (cmbStoreCdoe.Text == "WB")
                {
                    connectionTo = new SqlConnection("Data Source=" + parentForm1.WBIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.WBDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                }
                else if (cmbStoreCdoe.Text == "CV")
                {
                    connectionTo = new SqlConnection("Data Source=" + parentForm1.CVIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.CVDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                }
                else if (cmbStoreCdoe.Text == "UM")
                {
                    connectionTo = new SqlConnection("Data Source=" + parentForm1.UMIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.UMDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                }
                else if (cmbStoreCdoe.Text == "WM")
                {
                    connectionTo = new SqlConnection("Data Source=" + parentForm1.WMIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.WMDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                }
                else if (cmbStoreCdoe.Text == "WD")
                {
                    connectionTo = new SqlConnection("Data Source=" + parentForm1.WDIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.WDDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                }
                else if (cmbStoreCdoe.Text == "PW")
                {
                    connectionTo = new SqlConnection("Data Source=" + parentForm1.PWIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.PWDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW);
                }
                else if (cmbStoreCdoe.Text == "GB")
                {
                    connectionTo = new SqlConnection(parentForm1.GBCS_IP);
                }
                else if (cmbStoreCdoe.Text == "BW")
                {
                    connectionTo = new SqlConnection(parentForm1.BWCS_IP);
                }
                else if (cmbStoreCdoe.Text == "TEST")
                {
                    connectionTo = new SqlConnection("Server=BEAUTY4U-SEUNG;Database=TempleHills;UID=ssk;Password=cherry");
                }
                else
                {
                    return;
                }

                try
                {
                    cmd.CommandText = "Check_PromotionCode";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connectionTo;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@PromotionCode", SqlDbType.BigInt).Value = pmCode;
                    SqlParameter CheckNum_Param = cmd.Parameters.Add("@CheckNum", SqlDbType.Int);
                    CheckNum_Param.Direction = ParameterDirection.Output;

                    connectionTo.Open();
                    cmd.ExecuteNonQuery();
                    connectionTo.Close();

                    if (Convert.ToInt16(cmd.Parameters["@CheckNum"].Value) > 0)
                    {
                        MessageBox.Show("THIS PROMOTION CODE IS ALREADY EXIST", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        cmd_PH.CommandText = "Create_PromotionHeader";
                        cmd_PH.CommandType = CommandType.StoredProcedure;
                        cmd_PH.Connection = connectionTo;
                        cmd_PH.Parameters.Clear();
                        cmd_PH.Parameters.Add("@PromotionCode", SqlDbType.BigInt).Value = pmCode;
                        cmd_PH.Parameters.Add("@PromotionName", SqlDbType.NVarChar).Value = txtPromotionName.Text;
                        cmd_PH.Parameters.Add("@PromotionStartDate", SqlDbType.NVarChar).Value = txtStartDate.Text;
                        cmd_PH.Parameters.Add("@PromotionEndDate", SqlDbType.NVarChar).Value = txtEndDate.Text;

                        connectionTo.Open();
                        cmd_PH.ExecuteNonQuery();
                        connectionTo.Close();
                        progressBar1.PerformStep();

                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = parentForm2.dataGridView3.RowCount;
                        progressBar1.Step = 1;
                        progressBar1.Visible = true;

                        backgroundWorker1.RunWorkerAsync();
                    }
                }
                catch
                {
                    MessageBox.Show("TRANSFER FAILED OR CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    connectionTo.Close();
                    return;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            cmd_PB.CommandText = "Create_PromotionBody";
            cmd_PB.CommandType = CommandType.StoredProcedure;
            cmd_PB.Connection = connectionTo;

            for (int i = 0; i < parentForm2.dataGridView3.RowCount; i++)
            {
                cmd_PB.Parameters.Clear();
                cmd_PB.Parameters.Add("@PromotionCode", SqlDbType.BigInt).Value = pmCode;
                cmd_PB.Parameters.Add("@PromotionItemIndex", SqlDbType.Int).Value = i + 1;
                cmd_PB.Parameters.Add("@PromotionItemCode", SqlDbType.BigInt).Value = Convert.ToInt64(parentForm2.dataGridView3.Rows[i].Cells[0].Value);
                cmd_PB.Parameters.Add("@PromotionItemBrand", SqlDbType.NVarChar).Value = Convert.ToString(parentForm2.dataGridView3.Rows[i].Cells[1].Value);
                cmd_PB.Parameters.Add("@PromotionItemName", SqlDbType.NVarChar).Value = Convert.ToString(parentForm2.dataGridView3.Rows[i].Cells[2].Value);
                cmd_PB.Parameters.Add("@PromotionItemSize", SqlDbType.NVarChar).Value = Convert.ToString(parentForm2.dataGridView3.Rows[i].Cells[3].Value);
                cmd_PB.Parameters.Add("@PromotionItemColor", SqlDbType.NVarChar).Value = Convert.ToString(parentForm2.dataGridView3.Rows[i].Cells[4].Value);
                cmd_PB.Parameters.Add("@PromotionItemStyle", SqlDbType.NVarChar).Value = Convert.ToString(parentForm2.dataGridView3.Rows[i].Cells[5].Value);
                cmd_PB.Parameters.Add("@RegularPrice", SqlDbType.Money).Value = Convert.ToDouble(parentForm2.dataGridView3.Rows[i].Cells[6].Value);
                cmd_PB.Parameters.Add("@StylistPrice", SqlDbType.Money).Value = Convert.ToDouble(parentForm2.dataGridView3.Rows[i].Cells[7].Value);
                cmd_PB.Parameters.Add("@PromotionMixMatch", SqlDbType.Bit).Value = Convert.ToBoolean(parentForm2.dataGridView3.Rows[i].Cells[8].Value);
                cmd_PB.Parameters.Add("@PromotionMixMatchVal", SqlDbType.Int).Value = Convert.ToInt16(parentForm2.dataGridView3.Rows[i].Cells[9].Value);
                cmd_PB.Parameters.Add("@PromotionMixMatchQty", SqlDbType.Int).Value = Convert.ToInt16(parentForm2.dataGridView3.Rows[i].Cells[10].Value);
                cmd_PB.Parameters.Add("@PromotionType", SqlDbType.NVarChar).Value = Convert.ToString(parentForm2.dataGridView3.Rows[i].Cells[11].Value);
                cmd_PB.Parameters.Add("@PromotionOption", SqlDbType.Float).Value = Convert.ToString(parentForm2.dataGridView3.Rows[i].Cells[12].Value);
                cmd_PB.Parameters.Add("@SalePrice", SqlDbType.Money).Value = Convert.ToDouble(parentForm2.dataGridView3.Rows[i].Cells[13].Value);
                cmd_PB.Parameters.Add("@PromotionItemUpc", SqlDbType.NVarChar).Value = Convert.ToString(parentForm2.dataGridView3.Rows[i].Cells[14].Value);
                cmd_PB.Parameters.Add("@PromotionStartDate", SqlDbType.NVarChar).Value = txtStartDate.Text;
                cmd_PB.Parameters.Add("@PromotionEndDate", SqlDbType.NVarChar).Value = txtEndDate.Text;

                connectionTo.Open();
                cmd_PB.ExecuteNonQuery();
                connectionTo.Close();

                backgroundWorker1.ReportProgress(i + 1);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("SUCCESSFULLY PROMOTION CODE " + Convert.ToString(pmCode) + " TRANSFERRED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

            progressBar1.Visible = false;
            progressBar1.Value = 0;
        }
    }
}