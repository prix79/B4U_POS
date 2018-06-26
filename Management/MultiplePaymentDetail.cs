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
    public partial class MultiplePaymentDetail : Form
    {
        public LogInManagements parentForm1;
        public ReceiptDetail parentForm2;
        SqlConnection newConn;

        public Font drvFont = new Font("Arial", 10, FontStyle.Bold);

        public MultiplePaymentDetail()
        {
            InitializeComponent();
        }

        private void MultiplePaymentDetail_Load(object sender, EventArgs e)
        {
            lblReceiptID.Text = Convert.ToString(parentForm2.receiptID);
            lblStoreCode.Text = parentForm2.lblStoreCode.Text;

            if (parentForm2.option == 0)
            {
                SqlCommand cmd = new SqlCommand("Show_MultiplePayment_Detail", parentForm1.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = parentForm2.receiptID;
                DataTable dt = new DataTable();
                SqlDataAdapter adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                parentForm1.conn.Open();
                adapt.Fill(dt);
                parentForm1.conn.Close();

                dataGridView1.RowTemplate.Height = 35;
                dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "PAYMENT METHOD";
                dataGridView1.Columns[1].HeaderText = "PAY AMOUNT";
                dataGridView1.Columns[1].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[2].HeaderText = "DATE";
                dataGridView1.Columns[3].HeaderText = "TIME";

                dataGridView1.ClearSelection();
            }
            else if (parentForm2.option == 1)
            {
                newConn = new SqlConnection(parentForm1.OtherStoreConnectionString(lblStoreCode.Text.Trim().ToUpper()));

                SqlCommand cmd = new SqlCommand("Show_MultiplePayment_Detail", newConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ReceiptID", SqlDbType.BigInt).Value = parentForm2.receiptID;
                DataTable dt = new DataTable();
                SqlDataAdapter adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                newConn.Open();
                adapt.Fill(dt);
                newConn.Close();

                dataGridView1.RowTemplate.Height = 35;
                dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "PAYMENT METHOD";
                dataGridView1.Columns[1].HeaderText = "PAY AMOUNT";
                dataGridView1.Columns[1].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[2].HeaderText = "DATE";
                dataGridView1.Columns[3].HeaderText = "TIME";

                dataGridView1.ClearSelection();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}