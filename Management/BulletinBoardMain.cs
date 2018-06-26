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
    public partial class BulletinBoardMain : Form
    {
        public LogInManagements parentForm;

        public SqlConnection connHQ = new SqlConnection();
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter adapt;

        Font drvFont = new Font("Arial", 11, FontStyle.Bold);

        public BulletinBoardMain()
        {
            InitializeComponent();
        }

        private void BulletinBoardMain_Load(object sender, EventArgs e)
        {
            connHQ.ConnectionString = parentForm.B4UHQCS_IP;
            cmbCategory.SelectedIndex = 0;
            btnRefresh_Click(null, null);
        }

        public void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("Show_BulletinBoad", connHQ);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Option", SqlDbType.TinyInt).Value = cmbCategory.SelectedIndex;

                dt = new DataTable();
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                connHQ.Open();
                adapt.Fill(dt);
                connHQ.Close();

                dataGridView1.DataSource = dt;
                dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                dataGridView1.RowTemplate.Height = 35;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].HeaderText = "Store Location";
                dataGridView1.Columns[2].Width = 190;
                dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[3].HeaderText = "Subject";
                dataGridView1.Columns[3].Width = 330;
                dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].HeaderText = "Employee ID";
                dataGridView1.Columns[5].Width = 170;
                dataGridView1.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[6].HeaderText = "Date Created";
                dataGridView1.Columns[6].Width = 160;
                dataGridView1.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[7].HeaderText = "Date Modified";
                dataGridView1.Columns[7].Width = 160;
                dataGridView1.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[8].HeaderText = "Reply";
                dataGridView1.Columns[8].Width = 60;
                dataGridView1.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dataGridView1.ClearSelection();
            }
            catch
            {
                MessageBox.Show("Connection Failed. Please try again...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connHQ.Close();
                this.Close();
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
                return;

            if (Check_Selected() == 0)
                return;

            ReadBulletinBoard readBulletinBoardForm = new ReadBulletinBoard(cmbCategory.SelectedIndex, Convert.ToInt64(dataGridView1.SelectedCells[0].Value));
            readBulletinBoardForm.parentForm1 = this.parentForm;
            readBulletinBoardForm.parentForm2 = this;
            readBulletinBoardForm.ShowDialog();

        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedIndex == 0)
            {
                if (parentForm.userLevel >= parentForm.GeneralManagerLV)
                {
                    WriteBulletinBoard writeBulletinBoardForm = new WriteBulletinBoard(cmbCategory.SelectedIndex);
                    writeBulletinBoardForm.parentForm1 = this.parentForm;
                    writeBulletinBoardForm.parentForm2 = this;
                    writeBulletinBoardForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("You are not authorized to write an article in the announcement.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                WriteBulletinBoard writeBulletinBoardForm = new WriteBulletinBoard(cmbCategory.SelectedIndex);
                writeBulletinBoardForm.parentForm1 = this.parentForm;
                writeBulletinBoardForm.parentForm2 = this;
                writeBulletinBoardForm.ShowDialog();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
                return;

            if (Check_Selected() == 0)
                return;

            ModifyBulletinBoard modifyBulletinBoardForm = new ModifyBulletinBoard(cmbCategory.SelectedIndex, Convert.ToInt64(dataGridView1.SelectedCells[0].Value));
            modifyBulletinBoardForm.parentForm1 = this.parentForm;
            modifyBulletinBoardForm.parentForm2 = this;
            modifyBulletinBoardForm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
                return;

            if (Check_Selected() == 0)
                return;

            if (parentForm.userLevel >= parentForm.SystemAdministratorLV)
            {
                DialogResult MyDialogResult;
                MyDialogResult = MessageBox.Show(this, "Do you want to delete a selected article?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (MyDialogResult == DialogResult.Yes)
                {
                    try
                    {
                        cmd = new SqlCommand("Delete_BulletinBoard", connHQ);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@Option", SqlDbType.TinyInt).Value = cmbCategory.SelectedIndex;
                        cmd.Parameters.Add("@seqNo", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.SelectedCells[0].Value);

                        connHQ.Open();
                        cmd.ExecuteNonQuery();
                        connHQ.Close();

                        MessageBox.Show("Successfully deleted !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnRefresh_Click(null, null);
                    }
                    catch
                    {
                        MessageBox.Show("Connection failed.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connHQ.Close();
                        return;
                    }
                }
            }
            else
            {
                if (Convert.ToString(dataGridView1.SelectedCells[5].Value).ToUpper() == parentForm.employeeID.ToString().ToUpper())
                {
                    DialogResult MyDialogResult;
                    MyDialogResult = MessageBox.Show(this, "Do you want to delete a selected article?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (MyDialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            cmd = new SqlCommand("Delete_BulletinBoard", connHQ);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@Option", SqlDbType.TinyInt).Value = cmbCategory.SelectedIndex;
                            cmd.Parameters.Add("@seqNo", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.SelectedCells[0].Value);

                            connHQ.Open();
                            cmd.ExecuteNonQuery();
                            connHQ.Close();

                            MessageBox.Show("Successfully deleted !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnRefresh_Click(null, null);
                        }
                        catch
                        {
                            MessageBox.Show("Connection failed.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            connHQ.Close();
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("You are not authorized to delete this article", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                btnRead_Click(null, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRefresh_Click(null, null);
        }

        private int Check_Selected()
        {
            int chk = 0;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Selected == true)
                    chk = chk + 1;
            }

            return chk;
        }

        public void Select_Row(Int64 seq)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value) == seq)
                {
                    dataGridView1.Rows[i].Selected = true;
                    break;
                }
            }
        }
    }
}