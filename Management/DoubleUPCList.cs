using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace Management
{
    public partial class DoubleUPCList : Form
    {
        public LogInManagements parentForm;
        int index1;
        NumberFormatInfo nfi = new NumberFormatInfo();

        public DoubleUPCList(int idx1)
        {
            InitializeComponent();
            index1 = idx1;
        }

        private void DoubleUPCList_Load(object sender, EventArgs e)
        {
            nfi.CurrencySymbol = Application.CurrentCulture.NumberFormat.CurrencySymbol;
            nfi.CurrencyNegativePattern = 1;

            SqlCommand cmd = new SqlCommand("Check_DoubleUPC", parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Index1", SqlDbType.Int).Value = index1;
            SqlDataAdapter adapt = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adapt.SelectCommand=cmd;

            parentForm.conn.Open();
            adapt.Fill(dt);
            parentForm.conn.Close();

            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.RowTemplate.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].HeaderText = "BRAND";
            dataGridView1.Columns[7].Width = 90;
            dataGridView1.Columns[8].HeaderText = "NAME";
            dataGridView1.Columns[8].Width = 165;
            dataGridView1.Columns[9].HeaderText = "SIZE";
            dataGridView1.Columns[9].Width = 60;
            dataGridView1.Columns[10].HeaderText = "COLOR";
            dataGridView1.Columns[10].Width = 60;
            dataGridView1.Columns[11].HeaderText = "UPC";
            dataGridView1.Columns[11].Width = 90;
            dataGridView1.Columns[12].HeaderText = "RETAIL PRICE";
            dataGridView1.Columns[12].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[12].Width = 60;
            dataGridView1.Columns[13].HeaderText = "DISCOUNT PRICE";
            dataGridView1.Columns[13].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[13].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[13].Width = 60;
            dataGridView1.Columns[14].HeaderText = "SOLD PRICE";
            dataGridView1.Columns[14].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[14].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[14].Width = 60;
            dataGridView1.Columns[15].HeaderText = "SOLD QTY";
            dataGridView1.Columns[15].Width = 45;
            dataGridView1.Columns[16].HeaderText = "SOLD DATE";
            dataGridView1.Columns[16].Width = 95;
            dataGridView1.Columns[17].HeaderText = "SOLD TIME";
            dataGridView1.Columns[17].Width = 95;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}