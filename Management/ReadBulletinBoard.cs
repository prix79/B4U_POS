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
    public partial class ReadBulletinBoard : Form
    {
        public LogInManagements parentForm1;
        public BulletinBoardMain parentForm2;

        int opt;
        public Int64 seqNo;
        SqlCommand cmd;
        SqlCommand cmd2;
        DataTable dt;
        SqlDataAdapter adapt;

        Font drvFont = new Font("Arial", 9);

        public ReadBulletinBoard(int c, Int64 s)
        {
            InitializeComponent();
            opt = c;
            seqNo = s;
        }

        public void ReadBulletinBoard_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt16(parentForm2.dataGridView1.SelectedCells[8].Value) > 0)
            {
                this.Height = 620;
                this.Width = 550;

                dataGridView1.Visible = true;

                CenterToParent();
            }
            else
            {
                this.Height = 441;
                this.Width = 550;

                dataGridView1.Visible = false;

                CenterToParent();
            }

            try
            {
                cmd = new SqlCommand("Read_BulletinBoard_Admin", parentForm2.connHQ);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Option", SqlDbType.TinyInt).Value = opt;
                cmd.Parameters.Add("@seqNo", SqlDbType.BigInt).Value = Convert.ToInt64(parentForm2.dataGridView1.SelectedCells[0].Value);
                SqlParameter Subject_Param = cmd.Parameters.Add("@Subject", SqlDbType.NVarChar, 50);
                SqlParameter Contents_Param = cmd.Parameters.Add("@Contents", SqlDbType.NVarChar, 4000);
                Subject_Param.Direction = ParameterDirection.Output;
                Contents_Param.Direction = ParameterDirection.Output;

                cmd2 = new SqlCommand("Show_BulletinBoadReply", parentForm2.connHQ);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Clear();
                cmd2.Parameters.Add("@Option", SqlDbType.TinyInt).Value = parentForm2.cmbCategory.SelectedIndex;
                cmd2.Parameters.Add("@BulletinSeqNo", SqlDbType.BigInt).Value = Convert.ToInt64(parentForm2.dataGridView1.SelectedCells[0].Value);
                dt = new DataTable();
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd2;

                parentForm2.connHQ.Open();
                cmd.ExecuteNonQuery();
                adapt.Fill(dt);
                parentForm2.connHQ.Close();

                txtSubject.Text = cmd.Parameters["@Subject"].Value.ToString();
                richTxtContents.Text = cmd.Parameters["@Contents"].Value.ToString();

                dataGridView1.DataSource = dt;
                dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                dataGridView1.RowTemplate.Height = 30;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].HeaderText = "Store Code";
                dataGridView1.Columns[2].Width = 50;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[4].HeaderText = "Comment";
                dataGridView1.Columns[4].Width = 260;
                dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[5].HeaderText = "Employee ID";
                dataGridView1.Columns[5].Width = 70;
                dataGridView1.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[6].HeaderText = "Date & Time";
                dataGridView1.Columns[6].Width = 120;
                dataGridView1.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

                dataGridView1.ClearSelection();
            }
            catch
            {
                MessageBox.Show("Loading failed or connection failed.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                parentForm2.connHQ.Close();
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReply_Click(object sender, EventArgs e)
        {
            InputReply inputReplyForm = new InputReply(0);
            inputReplyForm.parentForm1 = this.parentForm1;
            inputReplyForm.parentForm2 = this.parentForm2;
            inputReplyForm.parentForm3 = this;
            inputReplyForm.ShowDialog();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                InputReply inputReplyForm = new InputReply(1);
                inputReplyForm.parentForm1 = this.parentForm1;
                inputReplyForm.parentForm2 = this.parentForm2;
                inputReplyForm.parentForm3 = this;
                inputReplyForm.ShowDialog();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                InputReply inputReplyForm = new InputReply(1);
                inputReplyForm.parentForm1 = this.parentForm1;
                inputReplyForm.parentForm2 = this.parentForm2;
                inputReplyForm.parentForm3 = this;
                inputReplyForm.ShowDialog();
            }
        }
    }
}