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
    public partial class AddSize : Form
    {
        public LogInManagements parentForm1;
        public RegisterNewItem parentForm2;
        int checkNum = 0;

        public AddSize()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtSizeName.Text == "")
            {
                MessageBox.Show("INPUT NEW SIZE NAME", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSizeName.Select();
                txtSizeName.Focus();
            }
            else
            {
                checkNum = Check_Existing_Size(txtSizeName.Text.Trim().ToString().ToUpper());

                if (checkNum == 0)
                {
                    SqlCommand cmd = new SqlCommand("Add_Size", parentForm1.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@SizeName", SqlDbType.NVarChar).Value = txtSizeName.Text.Trim().ToString().ToUpper();

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    MessageBox.Show("SUCCESSFULLY ADDED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    parentForm2.btnLoadSize_Click(null, null);
                    parentForm2.cmbSize.Text = txtSizeName.Text.Trim().ToString().ToUpper();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("THIS SIZE IS ALREADY EXIST", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSizeName.SelectAll();
                    txtSizeName.Focus();
                    return;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddSize_Load(object sender, EventArgs e)
        {
            txtSizeName.Select();
            txtSizeName.Focus();
        }

        private int Check_Existing_Size(string sizeName)
        {
            SqlCommand cmd = new SqlCommand("Checking_Existing_Size", parentForm1.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@SizeName", SqlDbType.NVarChar).Value = sizeName;

            SqlParameter CheckNum_Param = cmd.Parameters.Add("@CheckNum", SqlDbType.Int);
            CheckNum_Param.Direction = ParameterDirection.Output;

            parentForm1.conn.Open();
            cmd.ExecuteNonQuery();
            parentForm1.conn.Close();

            return Convert.ToInt16(cmd.Parameters["@CheckNum"].Value);
        }
    }
}