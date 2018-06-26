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
    public partial class BulletinBoard : Form
    {
        public LogInManagements parentForm;
        public SqlConnection connOH;
        //SqlConnection connCH;
        //SqlConnection connWB;
        //SqlConnection connCV;
        //SqlConnection connUM;
        //SqlConnection connWM;
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter adapt;

        Font drvFont = new Font("Arial", 11, FontStyle.Bold);

        public BulletinBoard()
        {
            InitializeComponent();
        }

        private void BulletinBoard_Load(object sender, EventArgs e)
        {
            connOH = new SqlConnection("Data Source=" + parentForm.OHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.OHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
            //connCH = new SqlConnection("Data Source=" + parentForm.CHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
            //connWB = new SqlConnection("Data Source=" + parentForm.WBIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WBDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
            //connCV = new SqlConnection("Data Source=" + parentForm.CVIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CVDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
            //connUM = new SqlConnection("Data Source=" + parentForm.UMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.UMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
            //connWM = new SqlConnection("Data Source=" + parentForm.WMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);

            try
            {
                cmd = new SqlCommand("Show_BulletinBoad", connOH);
                cmd.CommandType = CommandType.StoredProcedure;

                dt = new DataTable();
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                connOH.Open();
                adapt.Fill(dt);
                connOH.Close();

                dataGridView1.DataSource = dt;
                dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                dataGridView1.RowTemplate.Height = 35;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].HeaderText = "STORE LOCATION";
                dataGridView1.Columns[2].Width = 180;
                dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[3].HeaderText = "TITLE";
                dataGridView1.Columns[3].Width = 370;
                dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].HeaderText = "WRITER";
                dataGridView1.Columns[5].Width = 150;
                dataGridView1.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[6].HeaderText = "DATE CREATED";
                dataGridView1.Columns[6].Width = 130;
                dataGridView1.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[7].HeaderText = "DATE MODIFIED";
                dataGridView1.Columns[7].Width = 130;
                dataGridView1.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            catch
            {
                MessageBox.Show("CAN NOT CONNECT TO BULLETIN BOARD OR CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connOH.Close();
                this.Close();
            }

            btnRefresh_Click(null, null);
        }

        public void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("Show_BulletinBoad", connOH);
                cmd.CommandType = CommandType.StoredProcedure;

                dt = new DataTable();
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                connOH.Open();
                adapt.Fill(dt);
                connOH.Close();

                dataGridView1.DataSource = dt;
                dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                dataGridView1.RowTemplate.Height = 35;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].HeaderText = "STORE LOCATION";
                dataGridView1.Columns[2].Width = 180;
                dataGridView1.Columns[3].HeaderText = "TITLE";
                dataGridView1.Columns[3].Width = 370;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].HeaderText = "WRITER";
                dataGridView1.Columns[5].Width = 150;
                dataGridView1.Columns[6].HeaderText = "DATE CREATED";
                dataGridView1.Columns[6].Width = 130;
                dataGridView1.Columns[7].HeaderText = "DATE MODIFIED";
                dataGridView1.Columns[7].Width = 130;
            }
            catch
            {
                MessageBox.Show("CAN NOT CONNECT TO BULLETIN BOARD OR CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connOH.Close();
                this.Close();
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            /*ReadBulletinBoard readBulletinBoardForm = new ReadBulletinBoard();
            readBulletinBoardForm.parentForm1 = this.parentForm;
            readBulletinBoardForm.parentForm2 = this;
            readBulletinBoardForm.ShowDialog();*/
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            /*WriteBulletinBoard writeBulletinBoardForm = new WriteBulletinBoard();
            writeBulletinBoardForm.parentForm1 = this.parentForm;
            writeBulletinBoardForm.parentForm2 = this;
            writeBulletinBoardForm.ShowDialog();*/
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            /*ModifyBulletinBoard modifyBulletinBoardForm = new ModifyBulletinBoard();
            modifyBulletinBoardForm.parentForm1 = this.parentForm;
            modifyBulletinBoardForm.parentForm2 = this;
            modifyBulletinBoardForm.ShowDialog();*/
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (parentForm.userLevel >= parentForm.SystemAdministratorLV)
            {
                DialogResult MyDialogResult;
                MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (MyDialogResult == DialogResult.Yes)
                {
                    try
                    {
                        cmd = new SqlCommand("Delete_BulletinBoard", connOH);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@seqNo", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.SelectedCells[0].Value);

                        connOH.Open();
                        cmd.ExecuteNonQuery();
                        connOH.Close();

                        MessageBox.Show("SUCCESSFULLY DELETED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnRefresh_Click(null, null);
                    }
                    catch
                    {
                        MessageBox.Show("DELETE FAILED OR CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connOH.Close();
                        return;
                    }
                }
            }
            else
            {
                if (Convert.ToString(dataGridView1.SelectedCells[5].Value).ToUpper() == parentForm.employeeID.ToString().ToUpper())
                {
                    DialogResult MyDialogResult;
                    MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (MyDialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            cmd = new SqlCommand("Delete_BulletinBoard", connOH);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@seqNo", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.SelectedCells[0].Value);

                            connOH.Open();
                            cmd.ExecuteNonQuery();
                            connOH.Close();

                            MessageBox.Show("SUCCESSFULLY DELETED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnRefresh_Click(null, null);
                        }
                        catch
                        {
                            MessageBox.Show("DELETE FAILED OR CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            connOH.Close();
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("NOT AUTHORIZED TO DELETE THIS ARTICLE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnRead_Click(null, null);
        }
    }
}