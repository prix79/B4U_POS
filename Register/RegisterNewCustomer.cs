// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 04-07-2017
// ***********************************************************************
// <copyright file="RegisterNewCustomer.cs" company="Beauty4u">
//     Copyright © Beauty4u 2009
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

/// <summary>
/// The Register namespace.
/// </summary>
namespace Register
{
    /// <summary>
    /// Class RegisterNewCustomer.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class RegisterNewCustomer : Form
    {
        /// <summary>
        /// The parent form
        /// </summary>
        public MainForm parentForm;
        //public CustomerMain parentForm2;
        /// <summary>
        /// The parent form2
        /// </summary>
        public MembershipMain parentForm2;

        /// <summary>
        /// The member code
        /// </summary>
        Int64 memberCode;
        /// <summary>
        /// The d1
        /// </summary>
        DateTime d1;
        /// <summary>
        /// The d2
        /// </summary>
        DateTime d2;
        /// <summary>
        /// The d3
        /// </summary>
        DateTime d3;
        /// <summary>
        /// The zip code
        /// </summary>
        Int64 zipCode;
        /// <summary>
        /// The member points
        /// </summary>
        double memberPoints = 0;
        /// <summary>
        /// The dob
        /// </summary>
        string dob;
        /// <summary>
        /// The start date
        /// </summary>
        string startDate;
        /// <summary>
        /// The exp date
        /// </summary>
        string expDate;
        /// <summary>
        /// The disc rate
        /// </summary>
        double discRate = 0;

        /// <summary>
        /// The home phone
        /// </summary>
        Int64 homePhone;
        /// <summary>
        /// The cell phone
        /// </summary>
        Int64 cellPhone;

        /// <summary>
        /// The beautician authentication
        /// </summary>
        public bool BeauticianAuth = false;

        /// <summary>
        /// The command
        /// </summary>
        public SqlCommand cmd = new SqlCommand();

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterNewCustomer"/> class.
        /// </summary>
        public RegisterNewCustomer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the RegisterNewCustomer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void RegisterNewCustomer_Load(object sender, EventArgs e)
        {
            this.Text = "REGISTER NEW MEMBER - " + parentForm.storeName.ToUpper().ToString();

            if (parentForm.storeName == "TEST")
                txtMemberPoints.Enabled = true;

            txtDateOfBirth.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            txtStartDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            txtExpirationDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today.AddYears(5));
            cmbMemberType.SelectedIndex = 0;

            txtFirstName.Select();
            txtFirstName.Focus();
        }

        /// <summary>
        /// Handles the DoubleClick event of the txtStartDate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtStartDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        /// <summary>
        /// Handles the DoubleClick event of the txtExpirationDate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtExpirationDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar2.Visible = true;
        }

        /// <summary>
        /// Handles the DateSelected event of the monthCalendar1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DateRangeEventArgs"/> instance containing the event data.</param>
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtStartDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar1.SelectionStart));
            monthCalendar1.Visible = false;
        }

        /// <summary>
        /// Handles the DateSelected event of the monthCalendar2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DateRangeEventArgs"/> instance containing the event data.</param>
        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtExpirationDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar2.SelectionStart));
            monthCalendar2.Visible = false;
        }

        /// <summary>
        /// Handles the Click event of the txtCustomerPoints control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtCustomerPoints_Click(object sender, EventArgs e)
        {
            txtMemberPoints.SelectAll();
            txtMemberPoints.Focus();
        }

        /// <summary>
        /// Handles the Click event of the btnRegister control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text.Trim() == "")
            {
                MyMessageBox.ShowBox("INPUT FIRST NAME", "ERROR");
                txtFirstName.Select();
                txtFirstName.Focus();
                return;
            }

            if (txtLastName.Text.Trim() == "")
            {
                MyMessageBox.ShowBox("INPUT LAST NAME", "ERROR");
                txtLastName.Select();
                txtLastName.Focus();
                return;
            }

            /*if (DateTime.TryParse(txtDateOfBirth.Text, out d1))
            {
                dob = string.Format("{0:MM/dd/yyyy}", d1);
            }
            else
            {
                MyMessageBox.ShowBox("INVALID DATE", "ERROR");
                txtDateOfBirth.SelectAll();
                txtDateOfBirth.Focus();
                return;
            }*/

            if (ValidateDate(txtDateOfBirth.Text) == true)
            {
                dob = txtDateOfBirth.Text;
            }
            else
            {
                MyMessageBox.ShowBox("INVALID DATE", "ERROR");
                txtDateOfBirth.SelectAll();
                txtDateOfBirth.Focus();
                return;
            }

            if (txtAddress.Text.Trim() == "")
            {
                MyMessageBox.ShowBox("INPUT ADDRESS", "ERROR");
                txtAddress.SelectAll();
                txtAddress.Focus();
                return;
            }

            if (txtCity.Text.Trim() == "")
            {
                MyMessageBox.ShowBox("INPUT CITY", "ERROR");
                txtCity.SelectAll();
                txtCity.Focus();
                return;
            }

            if (txtState.Text.Trim() == "")
            {
                MyMessageBox.ShowBox("INPUT STATE", "ERROR");
                txtState.Select();
                txtState.Focus();
                return;
            }
            else if (txtState.Text.Trim().Length != 2)
            {
                MyMessageBox.ShowBox("INPUT USPS FORMAT (TWO LETTERS ONLY)", "ERROR");
                txtState.SelectAll();
                txtState.Focus();
                return;
            }

            if (txtZipCode.Text.Trim() == "")
            {
                MyMessageBox.ShowBox("INPUT ZIP CODE", "ERROR");
                txtZipCode.Select();
                txtZipCode.Focus();
                return;
            }
            else if (txtZipCode.Text.Trim().Length != 5)
            {
                MyMessageBox.ShowBox("FIVE DIGIT ONLY", "ERROR");
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
                    MyMessageBox.ShowBox("INVALID ZIPCODE", "ERROR");
                    txtZipCode.SelectAll();
                    txtZipCode.Focus();
                    return;
                }
            }

            if (txtHomePhone.Text.Trim() != "")
            {
                if (txtHomePhone.Text.Trim().Length != 10)
                {
                    MyMessageBox.ShowBox("INVALID HOME PHONE NUMBER (INPUT 10 DIGIT ONLY)", "ERROR");
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
                        MyMessageBox.ShowBox("INVALID HOME PHONE NUMBER (INPUT 10 DIGIT ONLY)", "ERROR");
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
                    MyMessageBox.ShowBox("INVALID CELL PHONE NUMBER (INPUT 10 DIGIT ONLY)", "ERROR");
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
                        MyMessageBox.ShowBox("INVALID CELL PHONE NUMBER (INPUT 10 DIGIT ONLY)", "ERROR");
                        txtCellPhone.SelectAll();
                        txtCellPhone.Focus();
                        return;
                    }
                }
            }

            if (txtMemberCode.Text.Trim() == "")
            {
                MyMessageBox.ShowBox("INPUT MEMBER CODE", "ERROR");
                txtMemberCode.SelectAll();
                txtMemberCode.Focus();
                return;
            }

            if (cmbMemberType.SelectedIndex == 1)
            {
                if (txtLicenseNumber.Text == "")
                {
                    MyMessageBox.ShowBox("INPUT LICENSE NUMBER", "ERROR");
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
                MyMessageBox.ShowBox("INPUT VALID MEMBER POINTS", "ERROR");
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
                MyMessageBox.ShowBox("INVALID START DATE", "ERROR");
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
                MyMessageBox.ShowBox("INVALID EXPIRATION DATE", "ERROR");
                txtExpirationDate.SelectAll();
                txtExpirationDate.Focus();
                return;
            }

            if (cmbMemberType.SelectedIndex == 1)
            {
                if (BeauticianAuth == true)
                {
                    try
                    {
                        btnRegister.Enabled = false;

                        cmd.CommandText = "Create_New_Member";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = parentForm.connHQ;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = parentForm.storeCode;
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
                        cmd.Parameters.Add("@UpdateStoreCode", SqlDbType.NVarChar).Value = parentForm.storeCode.ToUpper().ToString();
                        cmd.Parameters.Add("@UpdateID", SqlDbType.NVarChar).Value = parentForm.employeeID.ToUpper().ToString();
                        cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = DateTime.Now;


                        parentForm.connHQ.Open();
                        cmd.ExecuteNonQuery();
                        parentForm.connHQ.Close();

                        MyMessageBox.ShowBox("SUCCESSFULLY REGISTERED", "INFORMATION");

                        Resetting();
                    }
                    catch
                    {
                        MyMessageBox.ShowBox("UPDATE FAILED ERROR", "ERROR");
                        parentForm.connHQ.Close();
                        return;
                    }
                }
                else
                {
                    MyMessageBox.ShowBox("PLEASE PASS THE AUTHENTICATION BY MANAGER TO REGISTER A BEAUTICAIN MEMBER.", "WARNING");

                    Authentication authenticationForm = new Authentication(24);
                    authenticationForm.parentForm1 = this.parentForm;
                    authenticationForm.parentForm12 = this;
                    authenticationForm.ShowDialog();
                }
            }
            else
            {
                try
                {
                    btnRegister.Enabled = false;

                    cmd.CommandText = "Create_New_Member";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = parentForm.connHQ;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = parentForm.storeCode;
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
                    cmd.Parameters.Add("@UpdateStoreCode", SqlDbType.NVarChar).Value = parentForm.storeCode.ToUpper().ToString();
                    cmd.Parameters.Add("@UpdateID", SqlDbType.NVarChar).Value = parentForm.employeeID.ToUpper().ToString();
                    cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = DateTime.Now;


                    parentForm.connHQ.Open();
                    cmd.ExecuteNonQuery();
                    parentForm.connHQ.Close();

                    MyMessageBox.ShowBox("SUCCESSFULLY REGISTERED", "INFORMATION");

                    Resetting();
                }
                catch
                {
                    MyMessageBox.ShowBox("UPDATE FAILED ERROR", "ERROR");
                    parentForm.connHQ.Close();
                    return;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Resettings this instance.
        /// </summary>
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

        /// <summary>
        /// Handles the DoubleClick event of the txtDateOfBirth control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtDateOfBirth_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar3.Visible = true;
        }

        /// <summary>
        /// Handles the DateSelected event of the monthCalendar3 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DateRangeEventArgs"/> instance containing the event data.</param>
        private void monthCalendar3_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtDateOfBirth.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar3.SelectionStart));
            monthCalendar3.Visible = false;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbMemberType control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Click event of the btnMemberCodeCheck control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnMemberCodeCheck_Click(object sender, EventArgs e)
        {
            if (Int64.TryParse(txtMemberCode.Text, out memberCode))
            {
                cmd.CommandText = "Check_MemberCode";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = parentForm.connHQ;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@MemberCode", SqlDbType.BigInt).Value = memberCode;
                SqlParameter MemberCode_Param = cmd.Parameters.Add("@CheckMemberCode", SqlDbType.BigInt);
                MemberCode_Param.Direction = ParameterDirection.Output;

                parentForm.connHQ.Open();
                cmd.ExecuteNonQuery();
                parentForm.connHQ.Close();

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
                    MyMessageBox.ShowBox("THIS CODE IS NOT AVAILABLE", "ERROR");
                    txtMemberCode.SelectAll();
                    txtMemberCode.Focus();
                    return;
                }
            }
            else
            {
                MyMessageBox.ShowBox("INPUT VALID MEMBER CODE", "ERROR");
                txtMemberCode.SelectAll();
                txtMemberCode.Focus();
                return;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the rdoBtnSETrue control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rdoBtnSETrue_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBtnSETrue.Checked == true)
                cmbMemberType.Text = "STORE EMPLOYEE";
        }

        /// <summary>
        /// Handles the CheckedChanged event of the rdoBtnSEFalse control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rdoBtnSEFalse_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBtnSEFalse.Checked == true)
                cmbMemberType.Text = "STORE MEMBER";
        }

        /// <summary>
        /// Validates the date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
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