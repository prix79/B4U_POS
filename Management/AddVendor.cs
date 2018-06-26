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
    public partial class AddVendor : Form
    {
        public LogInManagements parentForm1;
        public RegisterNewItem parentForm2;
        int checkNum = 0;

        public AddVendor()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtVendorName.Text == "")
            {
                MessageBox.Show("INPUT NEW Vendor NAME", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVendorName.Select();
                txtVendorName.Focus();
            }
            else
            {
                checkNum = Check_Existing_Vendor(txtVendorName.Text.Trim().ToString().ToUpper());

                if (checkNum == 0)
                {
                    SqlCommand cmd = new SqlCommand("Add_Vendor", parentForm1.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@VendorName", SqlDbType.NVarChar).Value = txtVendorName.Text.Trim().ToString().ToUpper();

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    MessageBox.Show("SUCCESSFULLY ADDED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    parentForm2.btnLoadVendor_Click(null, null);
                    parentForm2.cmbVendor.Text = txtVendorName.Text.Trim().ToString().ToUpper();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("THIS VENDOR IS ALREADY EXIST", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtVendorName.SelectAll();
                    txtVendorName.Focus();
                    return;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddVendor_Load(object sender, EventArgs e)
        {
            txtVendorName.Select();
            txtVendorName.Focus();
        }

        private int Check_Existing_Vendor(string vendorName)
        {
            SqlCommand cmd = new SqlCommand("Checking_Existing_Vendor", parentForm1.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@VendorName", SqlDbType.NVarChar).Value = vendorName;

            SqlParameter CheckNum_Param = cmd.Parameters.Add("@CheckNum", SqlDbType.Int);
            CheckNum_Param.Direction = ParameterDirection.Output;

            parentForm1.conn.Open();
            cmd.ExecuteNonQuery();
            parentForm1.conn.Close();

            return Convert.ToInt16(cmd.Parameters["@CheckNum"].Value);
        }
    }
}