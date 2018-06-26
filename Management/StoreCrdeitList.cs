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
    public partial class StoreCrdeitList : Form
    {
        public LogInManagements parentForm;
        SqlCommand cmd;
        SqlDataAdapter adapt;
        DataTable dt;
        public string startDate, endDate;

        public Font drvFont = new Font("Arial", 10);

        public StoreCrdeitList()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadOption loadOptionForm = new LoadOption(0);
            loadOptionForm.parentForm1 = this;
            loadOptionForm.ShowDialog();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Load_StoreCreditList()
        {
            cmd = new SqlCommand("Load_StoreCreditList", parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = endDate;
            adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;
            dt = new DataTable();

            parentForm.conn.Open();
            adapt.Fill(dt);
            parentForm.conn.Close();

            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "STORE CREDIT ID";
            dataGridView1.Columns[0].Width = 95;
            dataGridView1.Columns[1].HeaderText = "STORE CODE";
            dataGridView1.Columns[1].Width = 60;
            dataGridView1.Columns[2].HeaderText = "REG#";
            dataGridView1.Columns[2].Width = 70;
            dataGridView1.Columns[3].HeaderText = "ORIGINAL RECEIPT ID";
            dataGridView1.Columns[3].Width = 95;
            dataGridView1.Columns[4].HeaderText = "RECEIPT ID";
            dataGridView1.Columns[4].Width = 95;
            dataGridView1.Columns[5].HeaderText = "ORIGINAL AMOUNT";
            dataGridView1.Columns[5].Width = 90;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[6].HeaderText = "CURRENT BALANCE";
            dataGridView1.Columns[6].Width = 90;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[7].HeaderText = "START DATE";
            dataGridView1.Columns[7].Width = 90;
            dataGridView1.Columns[8].HeaderText = "EXPIRATION DATE";
            dataGridView1.Columns[8].Width = 90;
            dataGridView1.Columns[9].HeaderText = "LAST PAY DATE";
            dataGridView1.Columns[9].Width = 90;
            
        }

        private void StoreCrdeitList_Load(object sender, EventArgs e)
        {

        }
    }
}