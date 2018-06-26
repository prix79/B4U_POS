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
    public partial class UpdateEmployee : Form
    {
        public LogInManagements parentForm1;
        public EmployeeMain parentForm2;

        DateTime d1, d2;
        Int64 num;

        public UpdateEmployee()
        {
            InitializeComponent();
        }

        private void UpdateEmployee_Load(object sender, EventArgs e)
        {
            if (parentForm1.StoreCode.ToUpper() == "B4UHQ")
            {
                lblCurrentStoreLocation.Visible = true;
                lblRegisteredStoreLocation.Visible = true;
                cmbStoreList.Visible = true;
                cmbRStoreList.Visible = true;

                SqlCommand cmd_StoreList = new SqlCommand("Get_StoreList_All", parentForm1.conn);
                cmd_StoreList.CommandType = CommandType.StoredProcedure;
                DataSet ds_StoreList = new DataSet();
                SqlDataAdapter adapt_StoreList = new SqlDataAdapter(cmd_StoreList);

                parentForm1.conn.Open();
                ds_StoreList.Clear();
                adapt_StoreList.Fill(ds_StoreList);
                parentForm1.conn.Close();

                SqlCommand cmd_StoreList2 = new SqlCommand("Get_StoreList_All", parentForm1.conn);
                cmd_StoreList2.CommandType = CommandType.StoredProcedure;
                DataSet ds_StoreList2 = new DataSet();
                SqlDataAdapter adapt_StoreList2 = new SqlDataAdapter(cmd_StoreList2);

                parentForm1.conn.Open();
                ds_StoreList2.Clear();
                adapt_StoreList2.Fill(ds_StoreList2);
                parentForm1.conn.Close();

                cmbRStoreList.DataSource = ds_StoreList.Tables[0].DefaultView;
                cmbRStoreList.ValueMember = "CIStoreCode";
                cmbRStoreList.DisplayMember = "CIStoreCode";

                cmbStoreList.DataSource = ds_StoreList2.Tables[0].DefaultView;
                cmbStoreList.ValueMember = "CIStoreCode";
                cmbStoreList.DisplayMember = "CIStoreCode";

                cmbRStoreList.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[1].Value);
                cmbStoreList.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[2].Value);
                txtFirstName.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[3].Value);
                txtLastName.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[4].Value);
                txtLoginID.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[5].Value);
                txtPassword.Text = "******";
                txtEmployeePosition.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[7].Value);
                cmbEmployeeLV.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[8].Value);
                txtStartDate.Text = string.Format("{0:MM/dd/yyyy}", parentForm2.dataGridView1.SelectedCells[9].Value);

                if (Convert.ToBoolean(parentForm2.dataGridView1.SelectedCells[10].Value) == true)
                {
                    rdoBtnTrue.Checked = true;
                }
                else
                {
                    rdoBtnFalse.Checked = true;
                }

                txtSSN.Text = cmbEmployeeLV.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[11].Value);

                if (parentForm2.dataGridView1.SelectedCells[12].Value != DBNull.Value)
                    txtBirthday.Text = string.Format("{0:MM/dd/yyyy}", parentForm2.dataGridView1.SelectedCells[12].Value);

                txtAddress.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[13].Value);
                txtCity.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[14].Value);
                txtState.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[15].Value);
                txtZipCode.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[16].Value);
                txtPhone1.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[17].Value);
                txtPhone2.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[18].Value);
                txtEmail.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[19].Value);
                txtEmergencyContactName.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[20].Value);
                txtEmergencyContactPhone.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[21].Value);
            }
            else
            {
                txtFirstName.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[2].Value);
                txtLastName.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[3].Value);
                txtLoginID.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[4].Value);
                txtPassword.Text = "******";
                txtEmployeePosition.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[6].Value);
                cmbEmployeeLV.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[7].Value);
                txtStartDate.Text = string.Format("{0:MM/dd/yyyy}", parentForm2.dataGridView1.SelectedCells[8].Value);

                if (Convert.ToBoolean(parentForm2.dataGridView1.SelectedCells[9].Value) == true)
                {
                    rdoBtnTrue.Checked = true;
                }
                else
                {
                    rdoBtnFalse.Checked = true;
                }

                txtSSN.Text = cmbEmployeeLV.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[10].Value);

                if (parentForm2.dataGridView1.SelectedCells[11].Value != DBNull.Value)
                    txtBirthday.Text = string.Format("{0:MM/dd/yyyy}", parentForm2.dataGridView1.SelectedCells[11].Value);

                txtAddress.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[12].Value);
                txtCity.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[13].Value);
                txtState.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[14].Value);
                txtZipCode.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[15].Value);
                txtPhone1.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[16].Value);
                txtPhone2.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[17].Value);
                txtEmail.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[18].Value);
                txtEmergencyContactName.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[19].Value);
                txtEmergencyContactPhone.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[20].Value);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
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

            /*if (txtLoginID.Text.Trim().ToUpper() == "ADMIN")
            {
                MessageBox.Show("YOU CAN NOT UPDATE SYSTEM ADMINISTRATOR ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLoginID.Select();
                txtLoginID.Focus();
                return;
            }*/

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

            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
            {
                try
                {
                    if (parentForm1.StoreCode.ToUpper() == "B4UHQ")
                    {
                        parentForm2.idx = parentForm2.dataGridView1.SelectedRows[0].Index;

                        SqlCommand cmd = new SqlCommand("Update_Employee_HQ", parentForm1.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@SCRegistered", SqlDbType.NVarChar).Value = cmbRStoreList.Text.ToUpper();
                        cmd.Parameters.Add("@SCCurrent", SqlDbType.NVarChar).Value = cmbStoreList.Text.ToUpper();
                        cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = txtFirstName.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = txtLastName.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = txtLoginID.Text.Trim().ToUpper();
                        //cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = txtPassword.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@EmployeePosition", SqlDbType.NVarChar).Value = txtEmployeePosition.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@EmployeeAccessLV", SqlDbType.TinyInt).Value = cmbEmployeeLV.SelectedIndex + 1;
                        cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = string.Format("{0:MM/dd/yyyy}", d1);

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

                        MessageBox.Show("SUCCESSFULLY UPDATED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        parentForm2.EmployeeMain_Load(null, null);
                        parentForm2.dataGridView1.Rows[parentForm2.idx].Selected = true;

                        if (parentForm2.idx > 12)
                            parentForm2.dataGridView1.FirstDisplayedScrollingRowIndex = parentForm2.idx;
                    }
                    else
                    {
                        parentForm2.idx = parentForm2.dataGridView1.SelectedRows[0].Index;

                        SqlCommand cmd = new SqlCommand("Update_Employee", parentForm1.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = parentForm1.StoreCode;
                        cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = txtFirstName.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = txtLastName.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = txtLoginID.Text.Trim().ToUpper();
                        //cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = txtPassword.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@EmployeePosition", SqlDbType.NVarChar).Value = txtEmployeePosition.Text.Trim().ToUpper();
                        cmd.Parameters.Add("@EmployeeAccessLV", SqlDbType.TinyInt).Value = cmbEmployeeLV.SelectedIndex + 1;
                        cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = string.Format("{0:MM/dd/yyyy}", d1);

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

                        MessageBox.Show("SUCCESSFULLY UPDATED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        parentForm2.EmployeeMain_Load(null, null);
                        parentForm2.dataGridView1.Rows[parentForm2.idx].Selected = true;

                        if (parentForm2.idx > 12)
                            parentForm2.dataGridView1.FirstDisplayedScrollingRowIndex = parentForm2.idx;
                    }
                }
                catch
                {
                    MessageBox.Show("DB UPDATE FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parentForm1.conn.Close();
                    return;
                }
            }
            else
            {
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            parentForm2.EmployeeMain_Load(null, null);
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

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                MessageBox.Show("INPUT PASSWORD", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.SelectAll();
                txtPassword.Focus();
                return;
            }
            else if (txtPassword.Text.Trim().Substring(0, 1) == "*")
            {
                MessageBox.Show("INVALID CHARACTER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.SelectAll();
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

            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Change_Employee_Password", parentForm1.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = txtLoginID.Text.Trim().ToUpper();
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = txtPassword.Text.Trim().ToUpper();

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    MessageBox.Show("SUCCESSFULLY PASSWORD CHANGED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("DB UPDATE FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parentForm1.conn.Close();
                    return;
                }
            }
        }
    }
}