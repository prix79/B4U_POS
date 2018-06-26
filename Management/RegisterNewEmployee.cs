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
    public partial class RegisterNewEmployee : Form
    {
        public LogInManagements parentForm1;
        public EmployeeMain parentForm2;

        DateTime d1, d2;
        Int64 num;

        public RegisterNewEmployee()
        {
            InitializeComponent();
        }

        private void RegisterNewEmployee_Load(object sender, EventArgs e)
        {
            txtStartDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

            txtFirstName.Select();
            txtFirstName.Focus();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text.Trim() == "")
            {
                MessageBox.Show("INPUT FIRST NAME", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFirstName.Select();
                txtFirstName.Focus();
                return;
            }

            if (txtLastName.Text.Trim() == "")
            {
                MessageBox.Show("INPUT LAST NAME", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLastName.Select();
                txtLastName.Focus();
                return;
            }

            if (txtLoginID.Text.Trim() == "")
            {
                MessageBox.Show("INPUT LOGIN ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLoginID.Select();
                txtLoginID.Focus();
                return;
            }

            if (txtLoginID.Text.Trim().ToUpper() == "ADMIN")
            {
                MessageBox.Show("YOU CAN NOT REGISTER SYSTEM ADMINISTRATOR ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLoginID.Select();
                txtLoginID.Focus();
                return;
            }

            if (txtLoginID.Text.Length > 15)
            {
                MessageBox.Show("LOGIN ID CAN NOT EXCEED 15 CHARACTERS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLoginID.SelectAll();
                txtLoginID.Focus();
                return;
            }

            if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("INPUT PASSWORD", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Select();
                txtPassword.Focus();
                return;
            }

            if (txtPassword.Text.Trim().Length < 6)
            {
                MessageBox.Show("USE AT LEAST 6 CHARACTERS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.SelectAll();
                txtPassword.Focus();
                return;
            }

            if (txtEmployeePosition.Text.Trim() == "")
            {
                MessageBox.Show("INPUT EMPLOYEE POSITION", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmployeePosition.Select();
                txtEmployeePosition.Focus();
                return;
            }

            if (cmbEmployeeLV.Text == "")
            {
                MessageBox.Show("SELECT EMPLOYEE LEVEL", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (parentForm1.userLevel < cmbEmployeeLV.SelectedIndex + 1)
                {
                    MessageBox.Show("YOU CAN NOT CHOOSE THIS LEVEL", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (txtStartDate.Text == "")
            {
                MessageBox.Show("INPUT SATRT DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStartDate.Select();
                txtStartDate.Focus();
                return;
            }
            else
            {
                if (DateTime.TryParse(txtStartDate.Text.Trim(), out d1))
                {
                }
                else
                {
                    MessageBox.Show("INVALID START DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtStartDate.SelectAll();
                    txtStartDate.Focus();
                    return;
                }
            }

            if (txtSSN.Text.Trim() != "")
            {
                if (txtSSN.Text.Trim().Length == 9)
                {
                    if (Int64.TryParse(txtSSN.Text.Trim(), out num))
                    {

                    }
                    else
                    {
                        MessageBox.Show("INVALID SSN", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSSN.SelectAll();
                        txtSSN.Focus();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("SSN MUST BE 9 DIGIT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSSN.SelectAll();
                    txtSSN.Focus();
                    return;
                }
            }

            if (txtBirthday.Text == "")
            {
                MessageBox.Show("INPUT BIRTHDAY", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBirthday.Select();
                txtBirthday.Focus();
                return;
            }
            else
            {
                if (DateTime.TryParse(txtBirthday.Text.Trim(), out d2))
                {
                }
                else
                {
                    MessageBox.Show("INVALID BIRTHDAY", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBirthday.SelectAll();
                    txtBirthday.Focus();
                    return;
                }
            }

            if (txtAddress.Text.Trim() == "")
            {
                MessageBox.Show("INPUT ADDRESS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAddress.Select();
                txtAddress.Focus();
                return;
            }

            if (txtCity.Text.Trim() == "")
            {
                MessageBox.Show("INPUT CITY", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCity.Select();
                txtCity.Focus();
                return;
            }

            if (txtState.Text.Trim() == "")
            {
                MessageBox.Show("INPUT STATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtState.Select();
                txtState.Focus();
                return;
            }
            else
            {
                if (txtState.Text.Trim().Length == 2)
                {
                }
                else
                {
                    MessageBox.Show("STATE MUST BE 2 LETTERS ONLY", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtState.SelectAll();
                    txtState.Focus();
                    return;
                }
            }

            if (txtZipCode.Text.Trim() == "")
            {
                MessageBox.Show("INPUT ZIP CODE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtZipCode.Select();
                txtZipCode.Focus();
                return;
            }
            else
            {
                if (txtZipCode.Text.Trim().Length == 5)
                {
                    if (Int64.TryParse(txtZipCode.Text.Trim(), out num))
                    {
                    }
                    else
                    {
                        MessageBox.Show("INVALID ZIPCODE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtZipCode.SelectAll();
                        txtZipCode.Focus();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("ZIPCODE MUST BE 5 DIGIT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtZipCode.SelectAll();
                    txtZipCode.Focus();
                    return;
                }
            }

            if (txtPhone1.Text.Trim() == "")
            {
                MessageBox.Show("INPUT PHONE NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhone1.Select();
                txtPhone1.Focus();
                return;
            }
            else
            {
                if (Int64.TryParse(txtPhone1.Text.Trim(), out num))
                {
                }
                else
                {
                    MessageBox.Show("INVALID PHONE NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPhone1.SelectAll();
                    txtPhone1.Focus();
                    return;
                }
            }

            try
            {
                if (parentForm1.StoreCode.ToUpper() == "B4UHQ")
                {
                    SqlCommand cmd_CheckUser = new SqlCommand("Check_Employee", parentForm1.conn);
                    cmd_CheckUser.CommandType = CommandType.StoredProcedure;
                    cmd_CheckUser.Parameters.Add("@LoginIDIn", SqlDbType.NVarChar).Value = txtLoginID.Text.Trim().ToUpper();
                    SqlParameter CheckUser_Param = cmd_CheckUser.Parameters.Add("@LoginIDOut", SqlDbType.NVarChar, 15);
                    CheckUser_Param.Direction = ParameterDirection.Output;

                    parentForm1.conn.Open();
                    cmd_CheckUser.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    if (cmd_CheckUser.Parameters["@LoginIDOut"].Value == DBNull.Value)
                    {
                        SqlCommand cmd = new SqlCommand("Register_New_Employee_HQ", parentForm1.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = parentForm1.StoreCode;
                        cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = txtFirstName.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = txtLastName.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = txtLoginID.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = txtPassword.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@EmployeePosition", SqlDbType.NVarChar).Value = txtEmployeePosition.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@EmployeeAccessLV", SqlDbType.TinyInt).Value = cmbEmployeeLV.SelectedIndex + 1;
                        cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = DateTime.Now;

                        if (rdoBtnTrue.Checked == true)
                        {
                            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = true;
                        }
                        else
                        {
                            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = false;
                        }

                        cmd.Parameters.Add("@SSN", SqlDbType.NVarChar).Value = txtSSN.Text.Trim();
                        cmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = string.Format("{0:MM/dd/yyyy}", d2);
                        cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = txtAddress.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = txtCity.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = txtState.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = txtZipCode.Text.Trim();
                        cmd.Parameters.Add("@Phone1", SqlDbType.NVarChar).Value = txtPhone1.Text.Trim();
                        cmd.Parameters.Add("@Phone2", SqlDbType.NVarChar).Value = txtPhone2.Text.Trim();
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = txtEmail.Text.Trim();
                        cmd.Parameters.Add("@EmergencyName", SqlDbType.NVarChar).Value = txtEmergencyContactName.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@EmergencyPhone", SqlDbType.NVarChar).Value = txtEmergencyContactPhone.Text.Trim();

                        parentForm1.conn.Open();
                        cmd.ExecuteNonQuery();
                        parentForm1.conn.Close();

                        MessageBox.Show("SUCCESSFULLY REGISTERED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        parentForm2.EmployeeMain_Load(null, null);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("THIS USER ID IS ALREADY EXIST\n", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    SqlConnection newConn = new SqlConnection(parentForm1.B4UHQCS_IP);
                    SqlCommand cmd_CheckUser_HQ = new SqlCommand("Check_Employee", newConn);
                    cmd_CheckUser_HQ.CommandType = CommandType.StoredProcedure;
                    cmd_CheckUser_HQ.Parameters.Add("@LoginIDIn", SqlDbType.NVarChar).Value = txtLoginID.Text.Trim().ToUpper();
                    SqlParameter CheckUser_Param_HQ = cmd_CheckUser_HQ.Parameters.Add("@LoginIDOut", SqlDbType.NVarChar, 15);
                    CheckUser_Param_HQ.Direction = ParameterDirection.Output;

                    newConn.Open();
                    cmd_CheckUser_HQ.ExecuteNonQuery();
                    newConn.Close();

                    if (cmd_CheckUser_HQ.Parameters["@LoginIDOut"].Value == DBNull.Value)
                    {
                        SqlCommand cmd = new SqlCommand("Register_New_Employee_HQ", newConn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = parentForm1.StoreCode;
                        cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = txtFirstName.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = txtLastName.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = txtLoginID.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = txtPassword.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@EmployeePosition", SqlDbType.NVarChar).Value = txtEmployeePosition.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@EmployeeAccessLV", SqlDbType.TinyInt).Value = cmbEmployeeLV.SelectedIndex + 1;
                        cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = DateTime.Now;

                        if (rdoBtnTrue.Checked == true)
                        {
                            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = true;
                        }
                        else
                        {
                            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = false;
                        }

                        cmd.Parameters.Add("@SSN", SqlDbType.NVarChar).Value = txtSSN.Text.Trim();
                        cmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = string.Format("{0:MM/dd/yyyy}", d2);
                        cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = txtAddress.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = txtCity.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = txtState.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = txtZipCode.Text.Trim();
                        cmd.Parameters.Add("@Phone1", SqlDbType.NVarChar).Value = txtPhone1.Text.Trim();
                        cmd.Parameters.Add("@Phone2", SqlDbType.NVarChar).Value = txtPhone2.Text.Trim();
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = txtEmail.Text.Trim();
                        cmd.Parameters.Add("@EmergencyName", SqlDbType.NVarChar).Value = txtEmergencyContactName.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@EmergencyPhone", SqlDbType.NVarChar).Value = txtEmergencyContactPhone.Text.Trim();

                        newConn.Open();
                        cmd.ExecuteNonQuery();
                        newConn.Close();

                        MessageBox.Show("SUCCESSFULLY REGISTERED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        parentForm2.EmployeeMain_Load(null, null);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("THIS USER ID IS ALREADY EXIST IN HEADQUARTERS\n\n" + "PLEASE CONTACT HR DEPARTMENT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    SqlCommand cmd_CheckUser = new SqlCommand("Check_Employee", parentForm1.conn);
                    cmd_CheckUser.CommandType = CommandType.StoredProcedure;
                    cmd_CheckUser.Parameters.Add("@LoginIDIn", SqlDbType.NVarChar).Value = txtLoginID.Text.Trim().ToUpper();
                    SqlParameter CheckUser_Param = cmd_CheckUser.Parameters.Add("@LoginIDOut", SqlDbType.NVarChar, 15);
                    CheckUser_Param.Direction = ParameterDirection.Output;

                    parentForm1.conn.Open();
                    cmd_CheckUser.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    if (cmd_CheckUser.Parameters["@LoginIDOut"].Value == DBNull.Value)
                    {
                        SqlCommand cmd = new SqlCommand("Register_New_Employee2", parentForm1.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = parentForm1.StoreCode;
                        cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = txtFirstName.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = txtLastName.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = txtLoginID.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = txtPassword.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@EmployeePosition", SqlDbType.NVarChar).Value = txtEmployeePosition.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@EmployeeAccessLV", SqlDbType.TinyInt).Value = cmbEmployeeLV.SelectedIndex + 1;
                        cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = DateTime.Now;

                        if (rdoBtnTrue.Checked == true)
                        {
                            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = true;
                        }
                        else
                        {
                            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = false;
                        }

                        cmd.Parameters.Add("@SSN", SqlDbType.NVarChar).Value = txtSSN.Text.Trim();
                        cmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = string.Format("{0:MM/dd/yyyy}", d2);
                        cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = txtAddress.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = txtCity.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = txtState.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = txtZipCode.Text.Trim();
                        cmd.Parameters.Add("@Phone1", SqlDbType.NVarChar).Value = txtPhone1.Text.Trim();
                        cmd.Parameters.Add("@Phone2", SqlDbType.NVarChar).Value = txtPhone2.Text.Trim();
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = txtEmail.Text.Trim();
                        cmd.Parameters.Add("@EmergencyName", SqlDbType.NVarChar).Value = txtEmergencyContactName.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@EmergencyPhone", SqlDbType.NVarChar).Value = txtEmergencyContactPhone.Text.Trim();

                        parentForm1.conn.Open();
                        cmd.ExecuteNonQuery();
                        parentForm1.conn.Close();

                        MessageBox.Show("SUCCESSFULLY REGISTERED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        parentForm2.EmployeeMain_Load(null, null);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("THIS USER ID IS ALREADY EXIST\n", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch
            {
                MessageBox.Show("DB UPDATE FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                parentForm1.conn.Close();
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBirthday_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtBirthday.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar1.SelectionStart));
            monthCalendar1.Visible = false;
        }

        private void txtStartDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar2.Visible = true;
        }

        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtStartDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar2.SelectionStart));
            monthCalendar2.Visible = false;
        }
    }
}