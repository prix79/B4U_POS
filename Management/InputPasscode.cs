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
    public partial class InputPasscode : Form
    {
        public LogInManagements parentForm1;
        public ManagementsMain parentForm2;
        public ReportMain parentForm3;
        public TimeCard parentForm4;
        public AboutManagement parentForm5;
        public ManagementsMain parentForm6;

        int option = 0;

        public InputPasscode(int opt)
        {
            InitializeComponent();
            option = opt;
        }

        private void InputPasscode_Load(object sender, EventArgs e)
        {

            if (option == 0)
            {
                btnOk.Location = new Point(66, 107);
                btnChange.Location = new Point(172, 107);

                txtInputPasscode.Select();
                txtInputPasscode.Focus();
            }
            else if (option == 1)
            {
                txtInputPasscode.Select();
                txtInputPasscode.Focus();
            }
            else if (option == 2)
            {
                btnOk.Location = new Point(66, 107);
                btnChange.Location = new Point(172, 107);

                txtInputPasscode.Select();
                txtInputPasscode.Focus();
            }
            else if (option == 3)
            {
                btnChange.Visible = false;
                txtInputPasscode.Select();
                txtInputPasscode.Focus();
            }
            else if (option == 4)
            {
                btnChange.Visible = false;
                txtInputPasscode.Select();
                txtInputPasscode.Focus();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (option == 0)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Check_Passcode", parentForm1.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@Passcode", SqlDbType.NVarChar).Value = txtInputPasscode.Text.ToString();
                    SqlParameter Check_Passcode_Param = cmd.Parameters.Add("@CheckNum", SqlDbType.Int);
                    Check_Passcode_Param.Direction = ParameterDirection.Output;

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    if (Convert.ToInt16(cmd.Parameters["@CheckNum"].Value) > 0)
                    {
                        this.Close();
                        parentForm3.Authorized = true;
                        parentForm3.btnSalesByStore_Click(null, null);
                        parentForm3.Authorized = false;
                    }
                    else
                    {
                        MessageBox.Show("INVALID PASSCODE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtInputPasscode.SelectAll();
                        txtInputPasscode.Focus();
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("CAN NOT CONNECT TO SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parentForm1.conn.Close();
                    return;
                }
            }
            else if (option == 1)
            {
                try
                {
                    //SqlConnection conn = new SqlConnection("Data Source=70.108.251.110,1433;Network Library=DBMSSOCN;Initial Catalog=OxonHillWarehouse;UID=sa;Password=macross7");
                    SqlCommand cmd = new SqlCommand("Check_Warehouse_Passcode", parentForm1.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@Passcode", SqlDbType.NVarChar).Value = txtInputPasscode.Text.ToString();
                    SqlParameter Check_Passcode_Param = cmd.Parameters.Add("@CheckNum", SqlDbType.Int);
                    Check_Passcode_Param.Direction = ParameterDirection.Output;

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    if (Convert.ToInt16(cmd.Parameters["@CheckNum"].Value) > 0)
                    {
                        this.Close();
                        parentForm2.Authorized = true;
                        parentForm2.btnInventory_Click(null, null);
                        parentForm2.Authorized = false;
                    }
                    else
                    {
                        MessageBox.Show("INVALID PASSCODE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtInputPasscode.SelectAll();
                        txtInputPasscode.Focus();
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("CAN NOT CONNECT TO SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parentForm1.conn.Close();
                    return;
                }
            }
            else if (option == 2)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Check_Passcode_For_Unsettle_TimeCard", parentForm1.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@Passcode", SqlDbType.NVarChar).Value = txtInputPasscode.Text.ToString();
                    SqlParameter Check_Passcode_Param = cmd.Parameters.Add("@CheckNum", SqlDbType.Int);
                    Check_Passcode_Param.Direction = ParameterDirection.Output;

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    if (Convert.ToInt16(cmd.Parameters["@CheckNum"].Value) > 0)
                    {
                        this.Close();
                        parentForm4.boolNumBtnUnsettle = true;
                        parentForm4.btnUnsettle_Click(null, null);
                        parentForm4.boolNumBtnUnsettle = false;
                    }
                    else
                    {
                        MessageBox.Show("INVALID PASSCODE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtInputPasscode.SelectAll();
                        txtInputPasscode.Focus();
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("CAN NOT CONNECT TO SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parentForm1.conn.Close();
                    return;
                }
            }
            else if (option == 3)
            {
                if (parentForm5.updatePassword == "Expired passcode")
                {
                    MessageBox.Show("This passscode has been expired. \r\nPlease contact IT department.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtInputPasscode.SelectAll();
                    txtInputPasscode.Focus();
                    return;
                }
                else if (txtInputPasscode.Text == parentForm5.updatePassword)
                {
                    parentForm5.auth = true;
                    parentForm5.listBox1.DataSource = parentForm5.GetFtpDirectoryDetails(parentForm5._ftpURL + parentForm5.FTPDirectoryName, parentForm5._UserName, parentForm5._Password);
                    parentForm5.btnUpdateCheck.Text = "UPDATE";
                    parentForm5.pictureBox1.Visible = false;
                    parentForm5.lblList.Visible = true;
                    parentForm5.listBox1.Visible = true;
                    parentForm5.progressBar1.Visible = true;
                    parentForm5.progressBar1.Value = 0;
                    MessageBox.Show("Passcode authorization successes. Please click UPDATE button for downloading files.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid passcode.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtInputPasscode.SelectAll();
                    txtInputPasscode.Focus();
                    return;
                }
            }
            else if (option == 4)
            {
                if (parentForm6.updatePassword == "Expired passcode")
                {
                    MessageBox.Show("This passscode has been expired. \r\nPlease contact IT department.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtInputPasscode.SelectAll();
                    txtInputPasscode.Focus();
                    return;
                }
                else if (txtInputPasscode.Text == parentForm6.updatePassword)
                {
                    parentForm6.auth = true;
                    parentForm6.listBox1.DataSource = parentForm6.GetFtpDirectoryDetails(parentForm6._ftpURL + parentForm6.FTPDirectoryName, parentForm6._UserName, parentForm6._Password);
                    parentForm6.btnUpdateCheck.Text = "UPDATE";
                    parentForm6.btnUpdateCheck.Visible = true;
                    parentForm6.lblList.Visible = true;
                    parentForm6.listBox1.Visible = true;
                    parentForm6.listBox1.Height = 485;
                    parentForm6.listBox1.Width = 549;
                    parentForm6.progressBar1.Visible = true;
                    parentForm6.progressBar1.Value = 0;
                    MessageBox.Show("Passcode authorization successes. Please click UPDATE button for downloading files.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid passcode.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtInputPasscode.SelectAll();
                    txtInputPasscode.Focus();
                    return;
                }
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (option == 0)
            {
                ChangePasscode changePasscodeForm = new ChangePasscode(0);
                changePasscodeForm.parentForm = this.parentForm1;
                changePasscodeForm.ShowDialog();
            }
            else if (option == 2)
            {
                ChangePasscode changePasscodeForm = new ChangePasscode(2);
                changePasscodeForm.parentForm = this.parentForm1;
                changePasscodeForm.ShowDialog();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (option == 0)
            {
                this.Close();
            }
            else if (option == 1)
            {
                this.Close();
            }
            else if (option == 2)
            {
                this.Close();
                parentForm4.btnUnsettle.Enabled = true;
            }
            else if (option == 3)
            {
                this.Close();
            }
            else if (option == 4)
            {
                this.Close();
            }
        }
    }
}