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
    public partial class ReceivingMain : Form
    {
        public LogInManagements parentForm1;
        public POandReceiving parentForm2;
        public POandReceivingForWarehouse parentForm3;
        SqlCommand cmd;
        DataTable dt = new DataTable();
        SqlDataAdapter adapt = new SqlDataAdapter();
        int checkNum = 0;
        int idx = 0;

        public Font drvFont = new Font("Arial", 11);

        public Int64 POID;

        int orderTotalQty = 0, receivingTotalQty = 0;
        double orderTotalAmount = 0, receivingTotalAmount = 0;

        double costPrice;
        double receivingAmount;
        int receivingQty;

        public bool boolWarehouse = false;

        public ReceivingMain()
        {
            InitializeComponent();
        }

        private void ReceivingMain_Load(object sender, EventArgs e)
        {
            if (boolWarehouse == true)
            {
                POID = Convert.ToInt64(parentForm3.dataGridView1.SelectedCells[0].Value);
                lblPOID.Text = Convert.ToString(POID);
                lblEmployeeID.Text = Convert.ToString(parentForm3.dataGridView1.SelectedCells[9].Value);
                lblPOStatus.Text = Convert.ToString(parentForm3.dataGridView1.SelectedCells[10].Value);
                lblVendor.Text = Convert.ToString(parentForm3.dataGridView1.SelectedCells[4].Value);
                cmd = new SqlCommand("Show_POBody", parentForm1.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                adapt.SelectCommand = cmd;

                parentForm1.conn.Open();
                dt.Clear();
                adapt.Fill(dt);
                parentForm1.conn.Close();
            }
            else
            {
                POID = Convert.ToInt64(parentForm2.dataGridView1.SelectedCells[0].Value);
                lblPOID.Text = Convert.ToString(POID);
                lblEmployeeID.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[9].Value);
                lblPOStatus.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[10].Value);
                lblVendor.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[4].Value);

                cmd = new SqlCommand("Show_POBody", parentForm1.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                adapt.SelectCommand = cmd;

                parentForm1.conn.Open();
                dt.Clear();
                adapt.Fill(dt);
                parentForm1.conn.Close();
            }

            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "Brand";
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].HeaderText = "Name";
            dataGridView1.Columns[1].Width = 240;
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].HeaderText = "Size";
            dataGridView1.Columns[2].Width = 70;
            dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].HeaderText = "Color";
            dataGridView1.Columns[3].Width = 75;
            dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].HeaderText = "Unit Cost";
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
            dataGridView1.Columns[4].Width = 60;
            dataGridView1.Columns[4].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[4].ReadOnly = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].HeaderText = "Order QTY";
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            dataGridView1.Columns[6].Width = 55;
            dataGridView1.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[6].ReadOnly = true;
            dataGridView1.Columns[7].HeaderText = "Receiving QTY";
            dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[7].DefaultCellStyle.BackColor = Color.NavajoWhite;
            dataGridView1.Columns[7].Width = 55;
            dataGridView1.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[7].ReadOnly = false;
            dataGridView1.Columns[8].HeaderText = "Order Amount";
            dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[8].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            dataGridView1.Columns[8].Width = 65;
            dataGridView1.Columns[8].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[8].ReadOnly = true;
            dataGridView1.Columns[9].HeaderText = "Receiving Amount";
            dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[9].DefaultCellStyle.BackColor = Color.NavajoWhite;
            dataGridView1.Columns[9].Width = 65;
            dataGridView1.Columns[9].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[9].ReadOnly = true;
            dataGridView1.Columns[10].HeaderText = "UPC";
            dataGridView1.Columns[10].Width = 110;
            dataGridView1.Columns[10].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[10].ReadOnly = true;
            dataGridView1.Columns[11].HeaderText = "Bin#";
            dataGridView1.Columns[11].Width = 50;
            dataGridView1.Columns[11].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[11].ReadOnly = true;

            if (lblPOStatus.Text == "RECEIVED")
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    orderTotalQty = orderTotalQty + Convert.ToInt16(dataGridView1.Rows[i].Cells[6].Value);
                    orderTotalAmount = orderTotalAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);
                    receivingTotalQty = receivingTotalQty + Convert.ToInt16(dataGridView1.Rows[i].Cells[7].Value);
                    receivingTotalAmount = receivingTotalAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[9].Value);
                }

                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.ReadOnly = true;
                btnReceiving.Enabled = false;
                //btnBarcode.Enabled = true;
            }
            else
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    orderTotalQty = orderTotalQty + Convert.ToInt16(dataGridView1.Rows[i].Cells[6].Value);
                    orderTotalAmount = orderTotalAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);
                    dataGridView1.Rows[i].Cells[7].Value = Convert.ToInt16(dataGridView1.Rows[i].Cells[6].Value);
                    dataGridView1.Rows[i].Cells[9].Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);
                    receivingTotalQty = receivingTotalQty + Convert.ToInt16(dataGridView1.Rows[i].Cells[7].Value);
                    receivingTotalAmount = receivingTotalAmount + Convert.ToDouble(dataGridView1.Rows[i].Cells[9].Value);
                }

                btnReceiving.Enabled = true;
                //btnBarcode.Enabled = false;
            }

            lblOrderTotalQty.Text = Convert.ToString(orderTotalQty);
            lblOrderTotalAmount.Text = string.Format("{0:$0.00}", orderTotalAmount);
            lblReceivingTotalQty.Text = Convert.ToString(receivingTotalQty);
            lblReceivingTotalAmount.Text = string.Format("{0:$0.00}", receivingTotalAmount);

            lblTotalCount1.Text = dataGridView1.RowCount.ToString();
        }

        private void btnReceiving_Click(object sender, EventArgs e)
        {
            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    checkNum = CheckDuplicatedUpc(dataGridView1.Rows[i].Cells[10].Value.ToString());

                    if (checkNum == 0)
                    {
                        MessageBox.Show("COULD NOT FOUND " + Convert.ToString(dataGridView1.Rows[i].Cells[10].Value) + " (ROW " + Convert.ToString(i + 1) + ") IN THE INVENTORY", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        checkNum = 0;
                        return;
                    }
                    else if (checkNum > 1)
                    {
                        MessageBox.Show(Convert.ToString(dataGridView1.Rows[i].Cells[10].Value) + " (ROW " + Convert.ToString(i + 1) + ") IS DUPLICATED UPC", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        checkNum = 0;
                        return;
                    }
                    else if (checkNum == -1)
                    {
                        MessageBox.Show("DB UPDATE FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        checkNum = 0;
                        return;
                    }
                    else
                    {
                        checkNum = 0;
                    }
                }

                progressBar1.Minimum = 0;
                progressBar1.Maximum = dataGridView1.RowCount + 1;
                progressBar1.Step = 1;

                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                receivingTotalQty = 0;
                receivingTotalAmount = 0;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    costPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                    receivingQty = Convert.ToInt16(dataGridView1.Rows[i].Cells[7].Value);
                    receivingAmount = Math.Round(costPrice * receivingQty, 2, MidpointRounding.AwayFromZero);
                    dataGridView1.Rows[i].Cells[9].Value = receivingAmount;

                    receivingTotalQty = receivingTotalQty + receivingQty;
                    receivingTotalAmount = receivingTotalAmount + receivingAmount;
                }

                lblReceivingTotalQty.Text = Convert.ToString(receivingTotalQty);
                lblReceivingTotalAmount.Text = string.Format("{0:$0.00}", receivingTotalAmount);
            }
            catch
            {
                MessageBox.Show("INVALID AMOUNT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            LabelPrint labelPrintForm = new LabelPrint(1);
            labelPrintForm.parentForm1 = this.parentForm1;
            labelPrintForm.parentForm2 = this;
            labelPrintForm.Show();
        }

        public int CheckDuplicatedUpc(string upc)
        {
            try
            {
                cmd = new SqlCommand("Check_Upc", parentForm1.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = upc;
                SqlParameter CheckNum_Param = cmd.Parameters.Add("@CheckNum", SqlDbType.Int);
                CheckNum_Param.Direction = ParameterDirection.Output;

                parentForm1.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm1.conn.Close();

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

                parentForm1.conn.Close();
                return -1;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.Connection = parentForm1.conn;

                for (idx = 0; idx < dataGridView1.RowCount; idx++)
                {
                    cmd.CommandText = "Check_OnHand";
                    //cmd.Connection = parentForm1.conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    //cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
                    //cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value);
                    cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[idx].Cells[10].Value);
                    SqlParameter CheckOnHand_Param = cmd.Parameters.Add("@ItmOnHand", SqlDbType.Int);
                    CheckOnHand_Param.Direction = ParameterDirection.Output;

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    if (cmd.Parameters["@ItmOnHand"].Value == DBNull.Value)
                    {
                        MessageBox.Show("UPDATE FAILED (ERROR IN ROW " + Convert.ToString(idx + 1) + ")\n" + "CHECK UPC NUMBER IN INVENTORY", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (Convert.ToInt16(cmd.Parameters["@ItmOnHand"].Value) > 0)
                    {
                        cmd.CommandText = "Update_ReceivingPO_To_Inventory";
                        //cmd.Connection = parentForm1.conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        //cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[idx].Cells[2].Value);
                        //cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value);
                        cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[idx].Cells[10].Value);
                        cmd.Parameters.Add("@ItmCostPrice", SqlDbType.Money).Value = Convert.ToString(dataGridView1.Rows[idx].Cells[4].Value);
                        cmd.Parameters.Add("@ReceivingQty", SqlDbType.Int).Value = Convert.ToInt16(dataGridView1.Rows[idx].Cells[7].Value);

                        parentForm1.conn.Open();
                        cmd.ExecuteNonQuery();
                        parentForm1.conn.Close();
                    }
                    else
                    {
                        cmd.CommandText = "Update_ReceivingPO_To_Inventory_By_Nagative";
                        //cmd.Connection = parentForm1.conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        //cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
                        //cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value);
                        cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[idx].Cells[10].Value);
                        cmd.Parameters.Add("@ItmCostPrice", SqlDbType.Money).Value = Convert.ToString(dataGridView1.Rows[idx].Cells[4].Value);
                        cmd.Parameters.Add("@ReceivingQty", SqlDbType.Int).Value = Convert.ToInt16(dataGridView1.Rows[idx].Cells[7].Value);

                        parentForm1.conn.Open();
                        cmd.ExecuteNonQuery();
                        parentForm1.conn.Close();
                    }

                    cmd.CommandText = "Update_POBody";
                    //cmd.Connection = parentForm1.conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    //cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
                    //cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value);
                    cmd.Parameters.Add("@ItmCostPrice", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[idx].Cells[4].Value);
                    cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[idx].Cells[10].Value);
                    cmd.Parameters.Add("@ReceivingQty", SqlDbType.Money).Value = Convert.ToInt16(dataGridView1.Rows[idx].Cells[7].Value);
                    cmd.Parameters.Add("@ReceivingAmount", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[idx].Cells[9].Value);

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    backgroundWorker1.ReportProgress(idx + 1);
                }
            }
            catch
            {
                MessageBox.Show("DB UPDATE FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            cmd = new SqlCommand("Update_POHeader_New", parentForm1.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@Seq", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
            cmd.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
            cmd.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = receivingTotalAmount;
            cmd.Parameters.Add("@ReceiveDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            cmd.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "RECEIVED";

            parentForm1.conn.Open();
            cmd.ExecuteNonQuery();
            parentForm1.conn.Close();

            progressBar1.PerformStep();
            MessageBox.Show("RECEIVING COMPLETE", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnReceiving.Enabled = false;
            dataGridView1.ReadOnly = true;
            lblPOStatus.Text = "RECEIVED";
        }

        private void ReceivingMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (boolWarehouse == true)
            {
                if (parentForm3.IsDisposed == false)
                    parentForm3.SearchPOList();

                //this.Close();
            }
            else
            {
                if (parentForm2.IsDisposed == false)
                    parentForm2.SearchPOList();

                //this.Close();
            }
        }
    }
}