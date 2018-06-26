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
    public partial class ChangePasscode : Form
    {
        public LogInManagements parentForm;

        int option;

        public ChangePasscode(int opt)
        {
            InitializeComponent();
            option = opt;
        }

        private void ChangePasscode_Load(object sender, EventArgs e)
        {
            txtOldPasscode.Select();
            txtOldPasscode.Focus();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtOldPasscode.Text == "")
            {
                MessageBox.Show("INPUT OLD PASSCODE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOldPasscode.SelectAll();
                txtOldPasscode.Focus();
                return;
            }

            if (txtNewPasscode.Text == "")
            {
                MessageBox.Show("INPUT NEW PASSCODE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNewPasscode.SelectAll();
                txtNewPasscode.Focus();
                return;
            }

            if (txtConfirmPasscode.Text == "")
            {
                MessageBox.Show("INPUT CONFIRM PASSCODE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmPasscode.SelectAll();
                txtConfirmPasscode.Focus();
                return;
            }

            if (option == 0)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Check_Passcode", parentForm.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@Passcode", SqlDbType.NVarChar).Value = txtOldPasscode.Text.Trim().ToUpper().ToString();
                    SqlParameter Check_Passcode_Param = cmd.Parameters.Add("@CheckNum", SqlDbType.Int);
                    Check_Passcode_Param.Direction = ParameterDirection.Output;

                    parentForm.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm.conn.Close();

                    if (Convert.ToInt16(cmd.Parameters["@CheckNum"].Value) > 0)
                    {
                        if (txtConfirmPasscode.Text == txtNewPasscode.Text)
                        {
                            SqlCommand cmd2 = new SqlCommand("Change_Passcode", parentForm.conn);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.Clear();
                            cmd2.Parameters.Add("@NewPasscode", SqlDbType.NVarChar).Value = txtNewPasscode.Text.Trim().ToUpper().ToString();

                            parentForm.conn.Open();
                            cmd2.ExecuteNonQuery();
                            parentForm.conn.Close();

                            MessageBox.Show("SUCCESSFULLY CHANGED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("CONFIRMATION PASSCODE IS INCORRENT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtConfirmPasscode.SelectAll();
                            txtConfirmPasscode.Focus();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("OLD PASSCODE IS INCORRENT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtOldPasscode.SelectAll();
                        txtOldPasscode.Focus();
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("UPDATE FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parentForm.conn.Close();
                    return;
                }
            }
            else if (option == 1)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Check_Warehouse_Passcode", parentForm.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@Passcode", SqlDbType.NVarChar).Value = txtOldPasscode.Text.Trim().ToUpper().ToString();
                    SqlParameter Check_Passcode_Param = cmd.Parameters.Add("@CheckNum", SqlDbType.Int);
                    Check_Passcode_Param.Direction = ParameterDirection.Output;

                    parentForm.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm.conn.Close();

                    if (Convert.ToInt16(cmd.Parameters["@CheckNum"].Value) > 0)
                    {
                        if (txtConfirmPasscode.Text == txtNewPasscode.Text)
                        {
                            SqlCommand cmd2 = new SqlCommand("Change_Warehouse_Passcode", parentForm.conn);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.Clear();
                            cmd2.Parameters.Add("@NewPasscode", SqlDbType.NVarChar).Value = txtNewPasscode.Text.Trim().ToUpper().ToString();

                            parentForm.conn.Open();
                            cmd2.ExecuteNonQuery();
                            parentForm.conn.Close();

                            MessageBox.Show("SUCCESSFULLY CHANGED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("CONFIRMATION PASSCODE IS INCORRENT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtConfirmPasscode.SelectAll();
                            txtConfirmPasscode.Focus();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("OLD PASSCODE IS INCORRENT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtOldPasscode.SelectAll();
                        txtOldPasscode.Focus();
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("UPDATE FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parentForm.conn.Close();
                    return;
                }
            }
            else if (option == 2)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Check_Passcode_For_Unsettle_TimeCard", parentForm.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@Passcode", SqlDbType.NVarChar).Value = txtOldPasscode.Text.Trim().ToUpper().ToString();
                    SqlParameter Check_Passcode_Param = cmd.Parameters.Add("@CheckNum", SqlDbType.Int);
                    Check_Passcode_Param.Direction = ParameterDirection.Output;

                    parentForm.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm.conn.Close();

                    if (Convert.ToInt16(cmd.Parameters["@CheckNum"].Value) > 0)
                    {
                        if (txtConfirmPasscode.Text == txtNewPasscode.Text)
                        {
                            SqlCommand cmd2 = new SqlCommand("Change_Passcode_For_Unsettle_TimeCard", parentForm.conn);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.Clear();
                            cmd2.Parameters.Add("@NewPasscode", SqlDbType.NVarChar).Value = txtNewPasscode.Text.Trim().ToUpper().ToString();

                            parentForm.conn.Open();
                            cmd2.ExecuteNonQuery();
                            parentForm.conn.Close();

                            MessageBox.Show("SUCCESSFULLY CHANGED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("CONFIRMATION PASSCODE IS INCORRENT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtConfirmPasscode.SelectAll();
                            txtConfirmPasscode.Focus();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("OLD PASSCODE IS INCORRENT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtOldPasscode.SelectAll();
                        txtOldPasscode.Focus();
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("UPDATE FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parentForm.conn.Close();
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