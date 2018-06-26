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
    public partial class WriteBulletinBoard : Form
    {
        public LogInManagements parentForm1;
        public BulletinBoardMain parentForm2;

        int opt;
        SqlCommand cmd;

        public WriteBulletinBoard(int c)
        {
            InitializeComponent();
            opt = c;
        }

        private void WriteBulletinBoard_Load(object sender, EventArgs e)
        {

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
            MyDialogResult = MessageBox.Show(this, "Do you want to post your article?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
            {
                try
                {
                    cmd = new SqlCommand("Write_BulletinBoard", parentForm2.connHQ);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@Option", SqlDbType.TinyInt).Value = opt;
                    cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = parentForm1.StoreCode;
                    cmd.Parameters.Add("@StoreName", SqlDbType.NVarChar).Value = parentForm1.storeName;
                    cmd.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = txtSubject.Text.Trim().ToString();
                    cmd.Parameters.Add("@Contents", SqlDbType.NVarChar).Value = richTxtContents.Text.Trim().ToString();
                    cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = parentForm1.employeeID.ToString().ToUpper();
                    cmd.Parameters.Add("@DateCreated", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@DateModified", SqlDbType.DateTime).Value = DateTime.Now;

                    parentForm2.connHQ.Open();
                    cmd.ExecuteNonQuery();
                    parentForm2.connHQ.Close();

                    MessageBox.Show("Successfully Posted !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    parentForm2.btnRefresh_Click(null, null);
                }
                catch
                {
                    MessageBox.Show("Connection failed. Please try again...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parentForm2.connHQ.Close();
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}