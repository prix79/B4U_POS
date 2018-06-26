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
    public partial class InputReply : Form
    {
        public LogInManagements parentForm1;
        public BulletinBoardMain parentForm2;
        public ReadBulletinBoard parentForm3;

        int formOpt;
        SqlCommand cmd;

        public InputReply(int f)
        {
            InitializeComponent();
            formOpt = f;
        }

        private void InputReply_Load(object sender, EventArgs e)
        {
            if (formOpt == 0)
            {
                label1.Visible = false;
                label3.Visible = false;
                txtEmployeeID.Visible = false;
                txtDate.Visible = false;

                richTextBox1.SelectAll();
                richTextBox1.Focus();
            }
            else if (formOpt == 1)
            {
                this.Text = "VIEW A COMMENT";
                label2.Visible = false;
                btnInput.Visible = false;
                btnCancel.Text = "CLOSE";
                richTextBox1.ReadOnly = true;

                richTextBox1.Text = parentForm3.dataGridView1.SelectedCells[4].Value.ToString();
                txtEmployeeID.Text = parentForm3.dataGridView1.SelectedCells[5].Value.ToString(); ;
                txtDate.Text = parentForm3.dataGridView1.SelectedCells[6].Value.ToString(); ;
            }
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Trim() == "")
            {
                MessageBox.Show("Please input reply.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                richTextBox1.SelectAll();
                richTextBox1.Focus();
                return;
            }

            try
            {
                cmd = new SqlCommand("Write_BulletinBoardReply", parentForm2.connHQ);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Option", SqlDbType.TinyInt).Value = parentForm2.cmbCategory.SelectedIndex;
                cmd.Parameters.Add("@BulletinSeqNo", SqlDbType.BigInt).Value = Convert.ToInt64(parentForm2.dataGridView1.SelectedCells[0].Value);
                cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = parentForm1.StoreCode;
                cmd.Parameters.Add("@StoreName", SqlDbType.NVarChar).Value = parentForm1.storeName;
                cmd.Parameters.Add("@Contents", SqlDbType.NVarChar).Value = richTextBox1.Text.Trim().ToString();
                cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = parentForm1.employeeID.ToString().ToUpper();
                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = DateTime.Now;

                parentForm2.connHQ.Open();
                cmd.ExecuteNonQuery();
                parentForm2.connHQ.Close();

                this.Close();
                parentForm2.btnRefresh_Click(null, null);
                parentForm2.Select_Row(parentForm3.seqNo);
                parentForm3.ReadBulletinBoard_Load(null, null);
            }
            catch
            {
                MessageBox.Show("Loading failed or connection failed.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                parentForm2.connHQ.Close();
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}