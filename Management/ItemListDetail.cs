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
    public partial class ItemListDetail : Form
    {
        public LogInManagements parentForm1;
        public ItemList parentForm2;
        public SqlConnection newConn;
        DataTable dt;

        string itmBrand, itmName;
        double itmRetailPrice;
        int option;
        Int64 totalOnHand = 0;

        public ItemListDetail(string bName, string iName, double iRprice, int opt)
        {
            InitializeComponent();
            itmBrand = bName;
            itmName = iName;
            itmRetailPrice = iRprice;
            option = opt;
        }

        private void ItemListDetail_Load(object sender, EventArgs e)
        {
            this.Text = "ITEM LIST DETAIL - " + parentForm1.storeName;

            if (parentForm1.StoreCode == parentForm2.cmbStoreCode.Text.ToUpper().ToString())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Show_ItemList_Detail", parentForm1.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = itmBrand;
                    cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = itmName;
                    cmd.Parameters.Add("@ItmRetailPrice", SqlDbType.NVarChar).Value = itmRetailPrice;
                    cmd.Parameters.Add("@Option", SqlDbType.Int).Value = option;
                    dt = new DataTable();
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);

                    parentForm1.conn.Open();
                    adapt.Fill(dt);
                    parentForm1.conn.Close();
                }
                catch
                {
                    if (parentForm1.conn.State == ConnectionState.Open)
                        parentForm1.conn.Close();

                    MessageBox.Show("DB Connection failed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                newConn = new SqlConnection(parentForm1.OtherStoreConnectionString(parentForm2.cmbStoreCode.Text.Trim()));

                try
                {
                    SqlCommand cmd = new SqlCommand("Show_ItemList_Detail", newConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = itmBrand;
                    cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = itmName;
                    cmd.Parameters.Add("@ItmRetailPrice", SqlDbType.NVarChar).Value = itmRetailPrice;
                    cmd.Parameters.Add("@Option", SqlDbType.Int).Value = option;
                    dt = new DataTable();
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);

                    newConn.Open();
                    adapt.Fill(dt);
                    newConn.Close();
                }
                catch
                {
                    if (newConn.State == ConnectionState.Open)
                        newConn.Close();

                    MessageBox.Show("DB Connection failed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = "Brand";
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].HeaderText = "Name";
            dataGridView1.Columns[3].Width = 180;
            dataGridView1.Columns[4].HeaderText = "Size";
            dataGridView1.Columns[4].Width = 50;
            dataGridView1.Columns[5].HeaderText = "Color";
            dataGridView1.Columns[5].Width = 50;
            dataGridView1.Columns[6].HeaderText = "Model Number";
            dataGridView1.Columns[6].Width = 80;
            dataGridView1.Columns[7].HeaderText = "Gp1";
            dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[7].Width = 35;
            dataGridView1.Columns[8].HeaderText = "Gp2";
            dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[8].Width = 35;
            dataGridView1.Columns[9].HeaderText = "Gp3";
            dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[9].Width = 35;
            //dataGridView1.Columns[7].Visible = false;
            //dataGridView1.Columns[8].Visible = false;
            //dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].HeaderText = "Minimum Stock";
            dataGridView1.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[13].Width = 55;
            dataGridView1.Columns[14].HeaderText = "On Hand";
            dataGridView1.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[14].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            dataGridView1.Columns[14].Width = 55;
            dataGridView1.Columns[15].HeaderText = "Retail Price";
            dataGridView1.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[15].Width = 55;
            dataGridView1.Columns[15].DefaultCellStyle.BackColor = Color.NavajoWhite;
            dataGridView1.Columns[15].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns[16].HeaderText = "Cost Price";
            dataGridView1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[16].Width = 55;
            dataGridView1.Columns[16].DefaultCellStyle.Format = "N2";
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
            //dataGridView1.Columns[27].Visible = false;
            dataGridView1.Columns[27].HeaderText = "Stylist Price";
            dataGridView1.Columns[27].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[27].Width = 55;
            dataGridView1.Columns[27].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns[28].HeaderText = "UPC";
            dataGridView1.Columns[28].Width = 100;
            dataGridView1.Columns[29].HeaderText = "Bin#";
            dataGridView1.Columns[29].Width = 40;
            dataGridView1.Columns[30].HeaderText = "Vendor";
            dataGridView1.Columns[30].Width = 80;
            dataGridView1.Columns[31].Visible = false;
            dataGridView1.Columns[32].HeaderText = "Register Date";
            dataGridView1.Columns[32].Width = 80;
            dataGridView1.Columns[33].Visible = false;
            dataGridView1.Columns[34].Visible = false;
            dataGridView1.Columns[35].Visible = false;
            dataGridView1.Columns[36].Visible = false;
            dataGridView1.Columns[37].Visible = false;
            dataGridView1.Columns[38].HeaderText = "Active";
            dataGridView1.Columns[38].Width = 40;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (Convert.ToInt64(dataGridView1.Rows[i].Cells[14].Value) >= 0)
                    totalOnHand = totalOnHand + Convert.ToInt64(dataGridView1.Rows[i].Cells[14].Value);
            }

            lblTotalCount.Text = Convert.ToString(dataGridView1.RowCount);
            lblTotalOnHand.Text = Convert.ToString(totalOnHand);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}