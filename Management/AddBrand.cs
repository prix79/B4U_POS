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
    public partial class AddBrand : Form
    {
        public LogInManagements parentForm1;
        public RegisterNewItem parentForm2;
        int checkNum = 0;

        public AddBrand()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtBrandName.Text == "")
            {
                MessageBox.Show("INPUT NEW BRAND NAME", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBrandName.Select();
                txtBrandName.Focus();
            }
            else
            {
                checkNum = Check_Existing_Brand(txtBrandName.Text.Trim().ToString().ToUpper());

                if (checkNum == 0)
                {
                    SqlCommand cmd = new SqlCommand("Add_Brand", parentForm1.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BrandName", SqlDbType.NVarChar).Value = txtBrandName.Text.Trim().ToString().ToUpper();

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    MessageBox.Show("SUCCESSFULLY ADDED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    parentForm2.btnLoadBrand_Click(null, null);
                    parentForm2.cmbBrand.Text = txtBrandName.Text.Trim().ToString().ToUpper();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("THIS BRAND IS ALREADY EXIST", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBrandName.SelectAll();
                    txtBrandName.Focus();
                    return;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddBrand_Load(object sender, EventArgs e)
        {
            txtBrandName.Select();
            txtBrandName.Focus();
        }

        private int Check_Existing_Brand(string brandName)
        {
            SqlCommand cmd = new SqlCommand("Checking_Existing_Brand", parentForm1.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@BrandName", SqlDbType.NVarChar).Value = brandName;

            SqlParameter CheckNum_Param = cmd.Parameters.Add("@CheckNum", SqlDbType.Int);
            CheckNum_Param.Direction = ParameterDirection.Output;

            parentForm1.conn.Open();
            cmd.ExecuteNonQuery();
            parentForm1.conn.Close();

            return Convert.ToInt16(cmd.Parameters["@CheckNum"].Value);
        }
    }
}