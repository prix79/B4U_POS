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
    public partial class RegisterNewCustomer : Form
    {
        public LogInManagements parentForm1;
        public MembershipMain parentForm2;

        SqlConnection newConn = new SqlConnection();

        Int64 memberCode;
        DateTime d1;
        DateTime d2;
        DateTime d3;
        Int64 zipCode;
        double memberPoints = 0;
        string dob;
        string startDate;
        string expDate;
        double discRate = 0;

        Int64 homePhone;
        Int64 cellPhone;

        public SqlCommand cmd = new SqlCommand();

        public RegisterNewCustomer()
        {
            InitializeComponent();
        }

        private void RegisterNewCustomer_Load(object sender, EventArgs e)
        {
            this.Text = "REGISTER NEW MEMBER - " + parentForm1.storeName.ToUpper().ToString();
            newConn.ConnectionString = parentForm1.B4UHQCS_IP;

            txtDateOfBirth.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            txtStartDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            txtExpirationDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today.AddYears(5));
            cmbMemberType.SelectedIndex = 0;

            txtFirstName.Select();
            txtFirstName.Focus();
        }

        private void txtStartDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void txtExpirationDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar2.Visible = true;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtStartDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar1.SelectionStart));
            monthCalendar1.Visible = false;
        }

        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtExpirationDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar2.SelectionStart));
            monthCalendar2.Visible = false;
        }

        private void txtCustomerPoints_Click(object sender, EventArgs e)
        {
            txtMemberPoints.SelectAll();
            txtMemberPoints.Focus();
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

            if (ValidateDate(txtDateOfBirth.Text) == true)
            {
                dob = txtDateOfBirth.Text;
            }
            else
            {
                MessageBox.Show("INVALID DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDateOfBirth.SelectAll();
                txtDateOfBirth.Focus();
                return;
            }

            if (txtAddress.Text.Trim() == "")
            {
                MessageBox.Show("INPUT ADDRESS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAddress.SelectAll();
                txtAddress.Focus();
                return;
            }

            if (txtCity.Text.Trim() == "")
            {
                MessageBox.Show("INPUT CITY", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCity.SelectAll();
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
            else if (txtState.Text.Trim().Length != 2)
            {
                MessageBox.Show("INPUT USPS FORMAT (TWO LETTERS ONLY)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtState.SelectAll();
                txtState.Focus();
                return;
            }

            if (txtZipCode.Text.Trim() == "")
            {
                MessageBox.Show("INPUT ZIP CODE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtZipCode.Select();
                txtZipCode.Focus();
                return;
            }
            else if (txtZipCode.Text.Trim().Length != 5)
            {
                MessageBox.Show("FIVE DIGIT ONLY", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtZipCode.SelectAll();
                txtZipCode.Focus();
                return;
            }
            else
            {
                if (Int64.TryParse(txtZipCode.Text, out zipCode))
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

            if (txtHomePhone.Text.Trim() != "")
            {
                if (txtHomePhone.Text.Trim().Length != 10)
                {
                    MessageBox.Show("INVALID HOME PHONE NUMBER (INPUT 10 DIGIT ONLY)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtHomePhone.SelectAll();
                    txtHomePhone.Focus();
                    return;
                }
                else
                {
                    if (Int64.TryParse(txtHomePhone.Text, out homePhone))
                    {
                    }
                    else
                    {
                        MessageBox.Show("INVALID HOME PHONE NUMBER (INPUT 10 DIGIT ONLY)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtHomePhone.SelectAll();
                        txtHomePhone.Focus();
                        return;
                    }
                }
            }

            if (txtCellPhone.Text.Trim() != "")
            {
                if (txtCellPhone.Text.Trim().Length != 10)
                {
                    MessageBox.Show("INVALID CELL PHONE NUMBER (INPUT 10 DIGIT ONLY)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCellPhone.SelectAll();
                    txtCellPhone.Focus();
                    return;
                }
                else
                {
                    if (Int64.TryParse(txtCellPhone.Text, out cellPhone))
                    {
                    }
                    else
                    {
                        MessageBox.Show("INVALID CELL PHONE NUMBER (INPUT 10 DIGIT ONLY)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCellPhone.SelectAll();
                        txtCellPhone.Focus();
                        return;
                    }
                }
            }

            if (txtMemberCode.Text.Trim() == "")
            {
                MessageBox.Show("INPUT MEMBER CODE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemberCode.SelectAll();
                txtMemberCode.Focus();
                return;
            }

            if (cmbMemberType.SelectedIndex == 1)
            {
                if (txtLicenseNumber.Text == "")
                {
                    MessageBox.Show("INPUT LICENSE NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLicenseNumber.Select();
                    txtLicenseNumber.Focus();
                    return;
                }
            }

            if (double.TryParse(txtMemberPoints.Text, out memberPoints))
            {
            }
            else
            {
                MessageBox.Show("INPUT VALID MEMBER POINTS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemberPoints.SelectAll();
                txtMemberPoints.Focus();
                return;
            }

            if (ValidateDate(txtStartDate.Text) == true)
            {
                startDate = txtStartDate.Text;
            }
            else
            {
                MessageBox.Show("INVALID START DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStartDate.SelectAll();
                txtStartDate.Focus();
                return;
            }

            if (ValidateDate(txtExpirationDate.Text) == true)
            {
                expDate = txtExpirationDate.Text;
            }
            else
            {
                MessageBox.Show("INVALID EXPIRATION DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtExpirationDate.SelectAll();
                txtExpirationDate.Focus();
                return;
            }

            try
            {
                btnRegister.Enabled = false;

                cmd.CommandText = "Create_New_Member";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = newConn;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = parentForm1.StoreCode;
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = txtFirstName.Text.Trim().ToUpper();
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = txtLastName.Text.Trim().ToUpper();
                cmd.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = Convert.ToDateTime(dob);
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = txtAddress.Text.Trim().ToUpper();
                cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = txtCity.Text.Trim().ToUpper();
                cmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = txtState.Text.Trim().ToUpper();
                cmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = Convert.ToString(zipCode);
                cmd.Parameters.Add("@HomePhone", SqlDbType.NVarChar).Value = txtHomePhone.Text.Trim();
                cmd.Parameters.Add("@CellPhone", SqlDbType.NVarChar).Value = txtCellPhone.Text.Trim();
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = txtEmail.Text.Trim();
                cmd.Parameters.Add("@MemberCode", SqlDbType.BigInt).Value = memberCode;
                cmd.Parameters.Add("@MemberType", SqlDbType.NVarChar).Value = cmbMemberType.Text.Trim().ToUpper();
                cmd.Parameters.Add("@LicenseNumber", SqlDbType.NVarChar).Value = txtLicenseNumber.Text.Trim();
                //cmd.Parameters.Add("@DiscountOption", SqlDbType.Money).Value = Convert.ToDouble(lblDiscountOption.Text.Substring(0, lblDiscountOption.Text.Length - 1));
                cmd.Parameters.Add("@DiscountOption", SqlDbType.Money).Value = discRate;
                cmd.Parameters.Add("@MemberPoints", SqlDbType.Money).Value = memberPoints;
                cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = Convert.ToDateTime(startDate);
                cmd.Parameters.Add("@ExpirationDate", SqlDbType.DateTime).Value = Convert.ToDateTime(expDate);
                cmd.Parameters.Add("@SchoolGraduated", SqlDbType.NVarChar).Value = txtSchoolGraduated.Text.Trim().ToUpper();
                cmd.Parameters.Add("@Memo", SqlDbType.NVarChar).Value = txtMemo.Text.Trim().ToUpper();
                if (rdoBtnSETrue.Checked == true)
                {
                    cmd.Parameters.Add("@StoreEmployee", SqlDbType.Bit).Value = true;
                }
                else
                {
                    cmd.Parameters.Add("@StoreEmployee", SqlDbType.Bit).Value = false;
                }
                cmd.Parameters.Add("@UpdateStoreCode", SqlDbType.NVarChar).Value = parentForm1.StoreCode.ToUpper().ToString();
                cmd.Parameters.Add("@UpdateID", SqlDbType.NVarChar).Value = parentForm1.employeeID.ToUpper().ToString();
                cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = DateTime.Now;


                newConn.Open();
                cmd.ExecuteNonQuery();
                newConn.Close();

                MessageBox.Show("SUCCESSFULLY REGISTERED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Resetting();
            }
            catch
            {
                MessageBox.Show("UPDATE FAILED ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                newConn.Close();
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Resetting()
        {
            memberPoints = 0;
            discRate = 0;

            txtFirstName.Clear();
            txtLastName.Clear();
            txtDateOfBirth.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            txtAddress.Clear();
            txtCity.Clear();
            txtState.Clear();
            txtZipCode.Clear();
            txtHomePhone.Clear();
            txtCellPhone.Clear();
            txtEmail.Clear();
            txtMemberCode.Clear();
            txtLicenseNumber.Clear();
            txtMemberPoints.Text = "0.00";
            txtStartDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            txtExpirationDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today.AddYears(5));
            txtSchoolGraduated.Clear();
            txtMemo.Clear();
            rdoBtnTrue.Checked = true;
            rdoBtnSEFalse.Checked = true;
            cmbMemberType.SelectedIndex = 0;
            txtMemberCode.Enabled = true;
            btnMemberCodeCheck.Enabled = true;
            btnRegister.Enabled = false;

            txtFirstName.Select();
            txtFirstName.Focus();
        }

        private void txtDateOfBirth_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar3.Visible = true;
        }

        private void monthCalendar3_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtDateOfBirth.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar3.SelectionStart));
            monthCalendar3.Visible = false;
        }

        private void cmbMemberType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMemberType.Text == "BEAUTICIAN")
            {
                lblDiscountOption.Text = "10%";
                discRate = 10;
                rdoBtnSEFalse.Checked = true;
                txtExpirationDate.Enabled = true;
            }
            else if (cmbMemberType.Text == "STORE EMPLOYEE")
            {
                lblDiscountOption.Text = "30%";
                discRate = 30;
                rdoBtnSETrue.Checked = true;
                txtExpirationDate.Enabled = false;
            }
            else
            {
                lblDiscountOption.Text = "0%";
                discRate = 0;
                rdoBtnSEFalse.Checked = true;
                txtExpirationDate.Enabled = false;
            }
        }

        private void btnMemberCodeCheck_Click(object sender, EventArgs e)
        {
            if (Int64.TryParse(txtMemberCode.Text, out memberCode))
            {
                cmd.CommandText = "Check_MemberCode";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = newConn;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@MemberCode", SqlDbType.BigInt).Value = memberCode;
                SqlParameter MemberCode_Param = cmd.Parameters.Add("@CheckMemberCode", SqlDbType.BigInt);
                MemberCode_Param.Direction = ParameterDirection.Output;

                newConn.Open();
                cmd.ExecuteNonQuery();
                newConn.Close();

                if (Convert.ToInt16(cmd.Parameters["@CheckmemberCode"].Value) == 0)
                {
                    btnMemberCodeCheck.Enabled = false;
                    txtMemberCode.Enabled = false;
                    btnRegister.Enabled = true;
                    txtLicenseNumber.Select();
                    txtLicenseNumber.Focus();
                }
                else
                {
                    MessageBox.Show("THIS CODE IS NOT AVAILABLE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMemberCode.SelectAll();
                    txtMemberCode.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("INPUT VALID MEMBER CODE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemberCode.SelectAll();
                txtMemberCode.Focus();
                return;
            }
        }

        private void rdoBtnSETrue_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBtnSETrue.Checked == true)
                cmbMemberType.Text = "STORE EMPLOYEE";
        }

        private void rdoBtnSEFalse_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBtnSEFalse.Checked == true)
                cmbMemberType.Text = "STORE MEMBER";
        }

        private bool ValidateDate(string date)
        {
            bool valid = false;
            //DateTime testDate = DateTime.MinValue;
            //DateTime minDateTime = DateTime.MaxValue;
            //DateTime maxDateTime = DateTime.MinValue;

            DateTime testDate;
            DateTime minDateTime;
            DateTime maxDateTime;

            minDateTime = new DateTime(1900, 1, 1, 0, 0, 0);
            maxDateTime = new DateTime(2100, 12, 31, 23, 59, 59, 997);

            if (DateTime.TryParse(date, out testDate))
            {
                if (testDate >= minDateTime && testDate <= maxDateTime)
                {
                    valid = true;
                }
                else
                {
                    valid = false;
                }
            }

            return valid;
        }
    }
}