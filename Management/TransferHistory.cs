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
    public partial class TransferHistory : Form
    {
        public LogInManagements parentForm1;
        public EmployeeProfile parentform2;

        public Font drvFont = new Font("Arial", 10, FontStyle.Bold);

        public TransferHistory()
        {
            InitializeComponent();
        }

        private void LocationHistory_Load(object sender, EventArgs e)
        {
            this.Text = "TRANSFER HISTORY - " + parentform2.lblFirstName.Text + " " + parentform2.lblLastName.Text;

            try
            {
                SqlCommand cmd = new SqlCommand("Show_Transfer_History", parentForm1.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = parentform2.lblLoginID.Text.ToUpper();
                DataTable dt = new DataTable();
                SqlDataAdapter adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                parentForm1.conn.Open();
                adapt.Fill(dt);
                parentForm1.conn.Close();

                dataGridView1.RowTemplate.Height = 30;
                dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                dataGridView1.DataSource = dt;

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "STORE CODE";
                dataGridView1.Columns[1].Width = 50;
                dataGridView1.Columns[2].HeaderText = "FIRST NAME";
                dataGridView1.Columns[2].Width = 130;
                dataGridView1.Columns[3].HeaderText = "LAST NAME";
                dataGridView1.Columns[3].Width = 130;
                dataGridView1.Columns[4].HeaderText = "LOGIN ID";
                dataGridView1.Columns[4].Width = 120;
                dataGridView1.Columns[5].HeaderText = "TRANSFER DATE";
                dataGridView1.Columns[5].Width = 90;
                dataGridView1.Columns[6].HeaderText = "TRANSFER ID";
                dataGridView1.Columns[6].Width = 120;
            }
            catch
            {
                MessageBox.Show("DB CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                parentForm1.conn.Close();
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}