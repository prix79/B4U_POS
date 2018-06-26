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
    public partial class AddColor : Form
    {
        public LogInManagements parentForm1;
        public RegisterNewItem parentForm2;
        int checkNum = 0;

        public AddColor()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtColorName.Text == "")
            {
                MessageBox.Show("INPUT NEW COLOR NAME", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtColorName.Select();
                txtColorName.Focus();
            }
            else
            {
                checkNum = Check_Existing_Color(txtColorName.Text.Trim().ToString().ToUpper());

                if (checkNum == 0)
                {
                    SqlCommand cmd = new SqlCommand("Add_Color", parentForm1.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ColorName", SqlDbType.NVarChar).Value = txtColorName.Text.Trim().ToString().ToUpper();

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    MessageBox.Show("SUCCESSFULLY ADDED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    parentForm2.btnLoadColor_Click(null, null);
                    parentForm2.cmbColor.Text = txtColorName.Text.Trim().ToString().ToUpper();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("THIS COLOR IS ALREADY EXIST", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtColorName.SelectAll();
                    txtColorName.Focus();
                    return;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddColor_Load(object sender, EventArgs e)
        {
            txtColorName.Select();
            txtColorName.Focus();
        }

        private int Check_Existing_Color(string colorName)
        {
            SqlCommand cmd = new SqlCommand("Checking_Existing_Color", parentForm1.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@ColorName", SqlDbType.NVarChar).Value = colorName;

            SqlParameter CheckNum_Param = cmd.Parameters.Add("@CheckNum", SqlDbType.Int);
            CheckNum_Param.Direction = ParameterDirection.Output;

            parentForm1.conn.Open();
            cmd.ExecuteNonQuery();
            parentForm1.conn.Close();

            return Convert.ToInt16(cmd.Parameters["@CheckNum"].Value);
        }
    }
}