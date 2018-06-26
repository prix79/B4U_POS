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
    public partial class ModifyBulletinBoard : Form
    {
        public LogInManagements parentForm1;
        public BulletinBoardMain parentForm2;

        //string Contents;

        int opt;
        Int64 seqNo;
        SqlCommand cmd;

        public ModifyBulletinBoard(int c, Int64 s)
        {
            InitializeComponent();
            opt = c;
            seqNo = s;
        }

        private void ModifyBulletinBoard_Load(object sender, EventArgs e)
        {
            try
            {
                if (parentForm1.userLevel >= parentForm1.SystemAdministratorLV)
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

                    parentForm2.connHQ.Open();
                    cmd.ExecuteNonQuery();
                    parentForm2.connHQ.Close();

                    txtSubject.Text = cmd.Parameters["@Subject"].Value.ToString();
                    richTxtContents.Text = cmd.Parameters["@Contents"].Value.ToString();
                }
                else
                {
                    cmd = new SqlCommand("Read_BulletinBoard", parentForm2.connHQ);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@Option", SqlDbType.TinyInt).Value = opt;
                    cmd.Parameters.Add("@seqNo", SqlDbType.BigInt).Value = Convert.ToInt64(parentForm2.dataGridView1.SelectedCells[0].Value);
                    cmd.Parameters.Add("@EmployeeID", SqlDbType.NText).Value = parentForm1.employeeID.ToString().ToUpper();
                    SqlParameter Subject_Param = cmd.Parameters.Add("@Subject", SqlDbType.NVarChar, 50);
                    SqlParameter Contents_Param = cmd.Parameters.Add("@Contents", SqlDbType.NVarChar, 4000);
                    Subject_Param.Direction = ParameterDirection.Output;
                    Contents_Param.Direction = ParameterDirection.Output;

                    parentForm2.connHQ.Open();
                    cmd.ExecuteNonQuery();
                    parentForm2.connHQ.Close();

                    if (cmd.Parameters["@Subject"].Value == DBNull.Value)
                    {
                        MessageBox.Show("You are not authorized to modify this article.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        return;
                    }
                    else
                    {
                        txtSubject.Text = cmd.Parameters["@Subject"].Value.ToString();
                        richTxtContents.Text = cmd.Parameters["@Contents"].Value.ToString();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Loading Failed or connection Failed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                parentForm2.connHQ.Close();
                return;
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (txtSubject.Text.Trim() == "")
            {
                MessageBox.Show("Please input a subject.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSubject.SelectAll();
                txtSubject.Focus();
                return;
            }

            if (richTxtContents.Text.Trim() == "")
            {
                MessageBox.Show("No content.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                richTxtContents.SelectAll();
                richTxtContents.Focus();
                return;
            }

            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "Do you want to update this article?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
            {
                try
                {
                    //Contents = richTxtContents.Text;

                    cmd = new SqlCommand("Update_BulletinBoard", parentForm2.connHQ);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@Option", SqlDbType.TinyInt).Value = opt;
                    cmd.Parameters.Add("@seqNo", SqlDbType.BigInt).Value = Convert.ToInt64(parentForm2.dataGridView1.SelectedCells[0].Value);
                    cmd.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = txtSubject.Text.Trim().ToString();
                    cmd.Parameters.Add("@Contents", SqlDbType.NVarChar).Value = richTxtContents.Text.Trim().ToString();
                    cmd.Parameters.Add("@DateModified", SqlDbType.DateTime).Value = DateTime.Now;

                    parentForm2.connHQ.Open();
                    cmd.ExecuteNonQuery();
                    parentForm2.connHQ.Close();

                    MessageBox.Show("Successfully updated !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    parentForm2.btnRefresh_Click(null, null);
                    parentForm2.Select_Row(seqNo);
                }
                catch
                {
                    MessageBox.Show("Connection failed. Please try again...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parentForm2.connHQ.Close();
                    return;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}