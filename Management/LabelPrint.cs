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
    public partial class LabelPrint : Form
    {
        public LogInManagements parentForm1;
        public ReceivingMain parentForm2;
        public RegisterNewItem parentForm3;
        public SqlCommand cmd;
        public DataTable dt = new DataTable();
        int option = 0;

        //CountUpc
        string cnt;
        int c;
        int barcodeQty;

        public Font drvFont = new Font("Arial", 11, FontStyle.Bold);

        string startDate, endDate;

        public bool excelUploadBoolNum = false;

        public LabelPrint(int opt)
        {
            InitializeComponent();
            option = opt;
        }

        public void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtUpc.Text == "")
            {
                MessageBox.Show("INPUT BARCODE", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUpc.Select();
                txtUpc.Focus();
                return;
            }

            int c = CountUpc("Count_ItmUpc", txtUpc.Text.ToUpper());

            if (c == 0)
            {
                if (excelUploadBoolNum == false)
                {
                    MessageBox.Show("CAN NOT FIND UPC", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUpc.SelectAll();
                    txtUpc.Focus();
                    return;
                }
            }
            else if (c > 1)
            {
                if (excelUploadBoolNum == false)
                {
                    MessageBox.Show("DUPLICATED UPC ITEM", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUpc.SelectAll();
                    txtUpc.Focus();
                    return;
                    //SelectUpc selectUpcForm = new SelectUpc(txtUpc.Text.ToUpper());
                    //selectUpcForm.parentform = this;
                    //selectUpcForm.Show();
                }
            }
            else
            {
                if (txtUpc.Text.Length > 0)
                {
                    BindDataGridView("Add_ItmUpc_To_LabelPrint", txtUpc.Text.ToString().ToUpper());
                    lblTotalCount1.Text = Convert.ToString(dataGridView1.RowCount);

                    txtUpc.Clear();
                    txtUpc.Select();
                    txtUpc.Focus();
                }
            }
        }

        private void btnSelectAll1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Selected = true;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int CountUpc(string sp, string upc)
        {
            c = 0;

            SqlCommand countUpc = new SqlCommand(sp, parentForm1.conn);
            countUpc.CommandType = CommandType.StoredProcedure;
            countUpc.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = upc;

            parentForm1.conn.Open();
            SqlDataReader reader = countUpc.ExecuteReader();
            if (reader.Read())
            {
                cnt = reader["Num"].ToString();
                c = Convert.ToInt16(cnt);
            }
            parentForm1.conn.Close();

            return c;
        }

        public void BindDataGridView(string sp, string upc)
        {
            cmd = new SqlCommand(sp, parentForm1.conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = upc;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            parentForm1.conn.Open();
            adapter.Fill(dt);
            parentForm1.conn.Close();

            if (parentForm1.StoreCode == "B4UHQ")
            {
                dataGridView1.RowTemplate.Height = 45;
                dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].HeaderText = "Brand";
                dataGridView1.Columns[2].Width = 180;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].HeaderText = "Name";
                dataGridView1.Columns[4].Width = 340;
                dataGridView1.Columns[5].HeaderText = "Size";
                dataGridView1.Columns[5].Width = 100;
                dataGridView1.Columns[6].HeaderText = "Color";
                dataGridView1.Columns[6].Width = 100;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[14].Visible = false;
                dataGridView1.Columns[15].Visible = false;
                dataGridView1.Columns[16].HeaderText = "Retail Price";
                dataGridView1.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[16].Width = 80;
                dataGridView1.Columns[16].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[17].Visible = false;
                dataGridView1.Columns[18].Visible = false;
                dataGridView1.Columns[19].Visible = false;
                dataGridView1.Columns[20].Visible = false;
                dataGridView1.Columns[21].Visible = false;
                dataGridView1.Columns[22].Visible = false;
                dataGridView1.Columns[23].Visible = false;
                dataGridView1.Columns[24].Visible = false;
                dataGridView1.Columns[25].Visible = false;
                dataGridView1.Columns[26].Visible = false;
                dataGridView1.Columns[27].Visible = false;
                dataGridView1.Columns[28].Visible = false;
                dataGridView1.Columns[29].HeaderText = "UPC";
                dataGridView1.Columns[29].Width = 130;
                dataGridView1.Columns[30].HeaderText = "Bin#";
                dataGridView1.Columns[30].Width = 60;
                dataGridView1.Columns[31].Visible = false;
                dataGridView1.Columns[32].Visible = false;
                dataGridView1.Columns[33].Visible = false;
                dataGridView1.Columns[34].Visible = false;
                dataGridView1.Columns[35].Visible = false;
                dataGridView1.Columns[36].Visible = false;
                dataGridView1.Columns[37].Visible = false;
                dataGridView1.Columns[38].Visible = false;
                dataGridView1.Columns[39].Visible = false;
                dataGridView1.Columns[40].Visible = false;
                dataGridView1.Columns[41].Visible = false;
                dataGridView1.Columns[42].Visible = false;
            }
            else
            {
                dataGridView1.RowTemplate.Height = 45;
                dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].HeaderText = "Brand";
                dataGridView1.Columns[2].Width = 180;
                dataGridView1.Columns[3].HeaderText = "Name";
                dataGridView1.Columns[3].Width = 340;
                dataGridView1.Columns[4].HeaderText = "Size";
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].HeaderText = "Color";
                dataGridView1.Columns[5].Width = 100;
                dataGridView1.Columns[6].Visible = false;
                //dataGridView1.Columns[6].HeaderText = "Model Number";
                //dataGridView1.Columns[6].Width = 95;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                //dataGridView1.Columns[13].HeaderText = "Minimum Stock";
                //dataGridView1.Columns[13].Width = 55;
                dataGridView1.Columns[13].Visible = false;
                //dataGridView1.Columns[14].HeaderText = "On Hand";
                //dataGridView1.Columns[14].Width = 55;
                dataGridView1.Columns[14].Visible = false;
                dataGridView1.Columns[15].HeaderText = "Retail Price";
                dataGridView1.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[15].Width = 80;
                dataGridView1.Columns[15].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[16].Visible = false;
                dataGridView1.Columns[17].Visible = false;
                dataGridView1.Columns[18].Visible = false;
                dataGridView1.Columns[19].Visible = false;
                dataGridView1.Columns[20].Visible = false;
                dataGridView1.Columns[21].Visible = false;
                dataGridView1.Columns[22].Visible = false;
                dataGridView1.Columns[23].Visible = false;
                dataGridView1.Columns[24].Visible = false;
                dataGridView1.Columns[25].Visible = false;
                dataGridView1.Columns[26].Visible = false;
                dataGridView1.Columns[27].Visible = false;
                dataGridView1.Columns[28].HeaderText = "UPC";
                dataGridView1.Columns[28].Width = 130;
                dataGridView1.Columns[29].HeaderText = "Bin#";
                dataGridView1.Columns[29].Width = 60;
                dataGridView1.Columns[30].Visible = false;
                dataGridView1.Columns[31].Visible = false;
                dataGridView1.Columns[32].Visible = false;
                dataGridView1.Columns[33].Visible = false;
                dataGridView1.Columns[34].Visible = false;
                dataGridView1.Columns[35].Visible = false;
                dataGridView1.Columns[36].Visible = false;
                dataGridView1.Columns[37].Visible = false;
                dataGridView1.Columns[38].Visible = false;
            }

            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Selected = true;
            }
        }

        private void LabelPrint_Load(object sender, EventArgs e)
        {
            if (option == 0)
            {
                lblTotalCount1.Text = Convert.ToString(dataGridView1.RowCount);

                txtUpc.Select();
                txtUpc.Focus();
            }
            else if (option == 1)
            {
                for (int i = 0; i < parentForm2.dataGridView1.RowCount; i++)
                {
                    if (Convert.ToInt16(parentForm2.dataGridView1.Rows[i].Cells[7].Value) > 0)
                    {
                        barcodeQty = Convert.ToInt16(parentForm2.dataGridView1.Rows[i].Cells[7].Value);

                        for (int j = 0; j < barcodeQty; j++)
                        {
                            txtUpc.Text = Convert.ToString(parentForm2.dataGridView1.Rows[i].Cells[10].Value);
                            btnAdd_Click(null, null);
                        }

                        txtUpc.Clear();
                    }
                }

                lblTotalCount1.Text = Convert.ToString(dataGridView1.RowCount);

                txtUpc.Enabled = false;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
            }
            else if (option == 2)
            {
                startDate = parentForm3.sDate;
                endDate = parentForm3.eDate;
                dt.Clear();

                cmd = new SqlCommand("Show_Items_By_RegisterDate", parentForm1.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
                SqlDataAdapter adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                parentForm1.conn.Open();
                adapt.Fill(dt);
                parentForm1.conn.Close();

                dataGridView1.RowTemplate.Height = 45;
                dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].HeaderText = "Brand";
                dataGridView1.Columns[2].Width = 180;
                dataGridView1.Columns[3].HeaderText = "Name";
                dataGridView1.Columns[3].Width = 340;
                dataGridView1.Columns[4].HeaderText = "Size";
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].HeaderText = "Color";
                dataGridView1.Columns[5].Width = 100;
                dataGridView1.Columns[6].Visible = false;
                //dataGridView1.Columns[6].HeaderText = "Model Number";
                //dataGridView1.Columns[6].Width = 95;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                //dataGridView1.Columns[13].HeaderText = "Minimum Stock";
                //dataGridView1.Columns[13].Width = 55;
                dataGridView1.Columns[13].Visible = false;
                //dataGridView1.Columns[14].HeaderText = "On Hand";
                //dataGridView1.Columns[14].Width = 55;
                dataGridView1.Columns[14].Visible = false;
                dataGridView1.Columns[15].HeaderText = "Retail Price";
                dataGridView1.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[15].Width = 80;
                dataGridView1.Columns[15].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[16].Visible = false;
                dataGridView1.Columns[17].Visible = false;
                dataGridView1.Columns[18].Visible = false;
                dataGridView1.Columns[19].Visible = false;
                dataGridView1.Columns[20].Visible = false;
                dataGridView1.Columns[21].Visible = false;
                dataGridView1.Columns[22].Visible = false;
                dataGridView1.Columns[23].Visible = false;
                dataGridView1.Columns[24].Visible = false;
                dataGridView1.Columns[25].Visible = false;
                dataGridView1.Columns[26].Visible = false;
                dataGridView1.Columns[27].Visible = false;
                dataGridView1.Columns[28].HeaderText = "UPC";
                dataGridView1.Columns[28].Width = 130;
                dataGridView1.Columns[29].HeaderText = "Bin#";
                dataGridView1.Columns[29].Width = 60;
                dataGridView1.Columns[30].Visible = false;
                dataGridView1.Columns[31].Visible = false;
                dataGridView1.Columns[32].Visible = false;
                dataGridView1.Columns[33].Visible = false;
                dataGridView1.Columns[34].Visible = false;
                dataGridView1.Columns[35].Visible = false;
                dataGridView1.Columns[36].Visible = false;
                dataGridView1.Columns[37].Visible = false;
                //dataGridView1.Columns[38].HeaderText = "Active";
                //dataGridView1.Columns[38].Width = 40;
                dataGridView1.Columns[38].Visible = false;

                lblTotalCount1.Text = Convert.ToString(dataGridView1.RowCount);

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Selected == false)
                        dataGridView1.Rows[i].Selected = true;
                }

                if (dataGridView1.RowCount > 0)
                {
                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                }

                txtUpc.Clear();
                txtUpc.Select();
                txtUpc.Focus();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                BarcodePrinting2 barcodePrinting2Form = new BarcodePrinting2();
                barcodePrinting2Form.parentForm = this;
                barcodePrinting2Form.ShowDialog();
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

        private void btnExcelUpload_Click(object sender, EventArgs e)
        {
            UploadExcelFile2 uploadExcelFile2Form = new UploadExcelFile2(0);
            uploadExcelFile2Form.parentForm1 = this.parentForm1;
            uploadExcelFile2Form.parentForm2 = this;
            uploadExcelFile2Form.ShowDialog();
        }
    }
}