// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 09-19-2015
// ***********************************************************************
// <copyright file="UpdateCustomer.cs" company="Beauty4u">
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
    /// Class UpdateCustomer.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class UpdateCustomer : Form
    {
        /// <summary>
        /// The parent form1
        /// </summary>
        public MainForm parentForm1;
        //public CustomerMain parentForm2;
        /// <summary>
        /// The parent form2
        /// </summary>
        public MembershipMain parentForm2;

        /// <summary>
        /// The member seq no
        /// </summary>
        Int64 memberSeqNo;
        /// <summary>
        /// The member code
        /// </summary>
        Int64 memberCode;
        /// <summary>
        /// The temporary member code
        /// </summary>
        Int64 tempMemberCode;
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
        /// The disc rate
        /// </summary>
        double discRate = 0;
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
        /// The home phone
        /// </summary>
        Int64 homePhone;
        /// <summary>
        /// The cell phone
        /// </summary>
        Int64 cellPhone;

        /// <summary>
        /// The command
        /// </summary>
        SqlCommand cmd = new SqlCommand();

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCustomer"/> class.
        /// </summary>
        public UpdateCustomer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the UpdateCustomer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void UpdateCustomer_Load(object sender, EventArgs e)
        {
            this.Text = "UPDATE NEW MEMBER - " + parentForm1.storeName.ToUpper().ToString();
            txtMemberCode.Enabled = false;

            memberSeqNo = Convert.ToInt64(parentForm2.dataGridView1.SelectedCells[0].Value);
            lblStoreCode.Text = parentForm2.dataGridView1.SelectedCells[1].Value.ToString().ToUpper();
            txtFirstName.Text = parentForm2.dataGridView1.SelectedCells[2].Value.ToString();
            txtLastName.Text = parentForm2.dataGridView1.SelectedCells[3].Value.ToString();
            txtDateOfBirth.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(parentForm2.dataGridView1.SelectedCells[4].Value));
            txtAddress.Text = parentForm2.dataGridView1.SelectedCells[5].Value.ToString();
            txtCity.Text = parentForm2.dataGridView1.SelectedCells[6].Value.ToString();
            txtState.Text = parentForm2.dataGridView1.SelectedCells[7].Value.ToString();
            txtZipCode.Text = parentForm2.dataGridView1.SelectedCells[8].Value.ToString();
            txtHomePhone.Text = parentForm2.dataGridView1.SelectedCells[9].Value.ToString();
            txtCellPhone.Text = parentForm2.dataGridView1.SelectedCells[10].Value.ToString();
            txtEmail.Text = parentForm2.dataGridView1.SelectedCells[11].Value.ToString();
            memberCode = Convert.ToInt64(parentForm2.dataGridView1.SelectedCells[12].Value);
            tempMemberCode = memberCode;
            txtMemberCode.Text = Convert.ToString(memberCode);
            cmbMemberType.Text = parentForm2.dataGridView1.SelectedCells[13].Value.ToString();
            txtLicenseNumber.Text = parentForm2.dataGridView1.SelectedCells[14].Value.ToString();
            discRate = Convert.ToDouble(parentForm2.dataGridView1.SelectedCells[15].Value);
            lblDiscountOption.Text = Convert.ToString(discRate) + "%";
            txtMemberPoints.Text = parentForm2.dataGridView1.SelectedCells[17].Value.ToString();
            txtStartDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(parentForm2.dataGridView1.SelectedCells[18].Value));
            txtExpirationDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(parentForm2.dataGridView1.SelectedCells[19].Value));
            txtSchoolGraduated.Text = parentForm2.dataGridView1.SelectedCells[25].Value.ToString();
            txtMemo.Text = parentForm2.dataGridView1.SelectedCells[26].Value.ToString();

            if (Convert.ToBoolean(parentForm2.dataGridView1.SelectedCells[27].Value) == true)
            {
                rdoBtnTrue.Checked = true;
            }
            else
            {
                rdoBtnFalse.Checked = true;
            }

            if (Convert.ToBoolean(parentForm2.dataGridView1.SelectedCells[28].Value) == true)
            {
                rdoBtnSETrue.Checked = true;
            }
            else
            {
                rdoBtnSEFalse.Checked = true;
            }
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
        /// Handles the Click event of the btnUpdate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnUpdate_Click(object sender, EventArgs e)
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

            if (Int64.TryParse(txtMemberCode.Text, out memberCode))
            {
            }
            else
            {
                MyMessageBox.ShowBox("INPUT VALID MEMBER CODE", "ERROR");
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

            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
            {
                this.Enabled = false;

                if (tempMemberCode != memberCode)
                {
                    if (DBConnectionStatus(parentForm1.parentForm.OtherStoreConnectionString("TH")) == false)
                    {
                        MessageBox.Show("TEMPLE HILLS DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Enabled = true;
                        return;
                    }

                    if (DBConnectionStatus(parentForm1.parentForm.OtherStoreConnectionString("OH")) == false)
                    {
                        MessageBox.Show("OXON HILL DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Enabled = true;
                        return;
                    }

                    if (DBConnectionStatus(parentForm1.parentForm.OtherStoreConnectionString("UM")) == false)
                    {
                        MessageBox.Show("UPPER MARLBORO DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Enabled = true;
                        return;
                    }

                    if (DBConnectionStatus(parentForm1.parentForm.OtherStoreConnectionString("CH")) == false)
                    {
                        MessageBox.Show("CAPITOL HEIGHTS DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Enabled = true;
                        return;
                    }

                    if (DBConnectionStatus(parentForm1.parentForm.OtherStoreConnectionString("WM")) == false)
                    {
                        MessageBox.Show("WINDSOR MILL DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Enabled = true;
                        return;
                    }

                    if (DBConnectionStatus(parentForm1.parentForm.OtherStoreConnectionString("CV")) == false)
                    {
                        MessageBox.Show("CATONSVILLE DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Enabled = true;
                        return;
                    }

                    if (DBConnectionStatus(parentForm1.parentForm.OtherStoreConnectionString("PW")) == false)
                    {
                        MessageBox.Show("PRINCE WILLIAM DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Enabled = true;
                        return;
                    }

                    if (DBConnectionStatus(parentForm1.parentForm.OtherStoreConnectionString("WB")) == false)
                    {
                        MessageBox.Show("WOODBRIDGE DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Enabled = true;
                        return;
                    }

                    if (DBConnectionStatus(parentForm1.parentForm.OtherStoreConnectionString("WD")) == false)
                    {
                        MessageBox.Show("WALDORF DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Enabled = true;
                        return;
                    }

                    if (DBConnectionStatus(parentForm1.parentForm.OtherStoreConnectionString("GB")) == false)
                    {
                        MessageBox.Show("GAITHERSBURG DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Enabled = true;
                        return;
                    }

                    if (DBConnectionStatus(parentForm1.parentForm.OtherStoreConnectionString("BW")) == false)
                    {
                        MessageBox.Show("BOWIE DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Enabled = true;
                        return;
                    }

                    Transaction_Update(tempMemberCode, memberCode);
                }

                try
                {
                    cmd.CommandText = "Update_Member";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = parentForm1.connHQ;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@MemberSeqNo", SqlDbType.BigInt).Value = memberSeqNo;
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
                    cmd.Parameters.Add("@DiscountOption", SqlDbType.Money).Value = Convert.ToDouble(lblDiscountOption.Text.Substring(0, lblDiscountOption.Text.Length - 1));
                    cmd.Parameters.Add("@MemberPoints", SqlDbType.Money).Value = memberPoints;
                    cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = Convert.ToDateTime(startDate);
                    cmd.Parameters.Add("@ExpirationDate", SqlDbType.DateTime).Value = Convert.ToDateTime(expDate);
                    cmd.Parameters.Add("@SchoolGraduated", SqlDbType.NVarChar).Value = txtSchoolGraduated.Text.Trim().ToUpper();
                    cmd.Parameters.Add("@Memo", SqlDbType.NVarChar).Value = txtMemo.Text.Trim().ToUpper();

                    if (rdoBtnTrue.Checked == true)
                    {
                        cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = true;
                    }
                    else if (rdoBtnFalse.Checked == true)
                    {
                        cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = false;
                    }

                    if (rdoBtnSETrue.Checked == true)
                    {
                        cmd.Parameters.Add("@StoreEmployee", SqlDbType.Bit).Value = true;
                    }
                    else
                    {
                        cmd.Parameters.Add("@StoreEmployee", SqlDbType.Bit).Value = false;
                    }

                    cmd.Parameters.Add("@UpdateStoreCode", SqlDbType.NVarChar).Value = parentForm1.storeCode.ToUpper().ToString();
                    cmd.Parameters.Add("@UpdateID", SqlDbType.NVarChar).Value = parentForm1.employeeID.ToUpper().ToString();
                    cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = DateTime.Now;

                    parentForm1.connHQ.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.connHQ.Close();

                    MyMessageBox.ShowBox("SUCCESSFULLY UPDATED", "INFORMATION");
                    //parentForm2.auth = false;
                    this.Close();

                    parentForm2.txtSearchKeyword.Text = Convert.ToString(memberCode);
                    parentForm2.rdoBtnMemberCode.Checked = true;
                    parentForm2.btnSearch_Click(null, null);
                    parentForm2.txtSearchKeyword.SelectAll();
                    parentForm2.txtSearchKeyword.Focus();
                }
                catch
                {
                    MyMessageBox.ShowBox("UPDATE FAILED", "ERROR");
                    parentForm1.connHQ.Close();
                    this.Enabled = true;
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
                txtStartDate.Enabled = true;
                txtExpirationDate.Enabled = true;
            }
            else if (cmbMemberType.Text == "STORE EMPLOYEE")
            {
                lblDiscountOption.Text = "30%";
                discRate = 30;
                rdoBtnSETrue.Checked = true;
                txtStartDate.Enabled = true;
                txtExpirationDate.Enabled = true;
            }
            else
            {
                lblDiscountOption.Text = "0%";
                discRate = 0;
                rdoBtnSEFalse.Checked = true;
                txtStartDate.Enabled = true;
                txtExpirationDate.Enabled = true;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnMemberCodeChange control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnMemberCodeChange_Click(object sender, EventArgs e)
        {
            txtMemberCode.Enabled = true;
            btnMemberCodeChange.Visible = false;
            btnMemberCodeCheck.Visible = true;
            btnUpdate.Enabled = false;

            txtMemberCode.SelectAll();
            txtMemberCode.Focus();
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
                cmd.Connection = parentForm1.connHQ;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@MemberCode", SqlDbType.BigInt).Value = memberCode;
                SqlParameter MemberCode_Param = cmd.Parameters.Add("@CheckMemberCode", SqlDbType.BigInt);
                MemberCode_Param.Direction = ParameterDirection.Output;

                parentForm1.connHQ.Open();
                cmd.ExecuteNonQuery();
                parentForm1.connHQ.Close();

                if (Convert.ToInt16(cmd.Parameters["@CheckmemberCode"].Value) == 0)
                {
                    btnMemberCodeCheck.Visible = false;
                    btnMemberCodeChange.Visible = true;
                    txtMemberCode.Enabled = false;
                    btnUpdate.Enabled = true;
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
        /// Transactions the update.
        /// </summary>
        /// <param name="oldMemberCode">The old member code.</param>
        /// <param name="newMemberCode">The new member code.</param>
        private void Transaction_Update(Int64 oldMemberCode, Int64 newMemberCode)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 10;
            progressBar1.Step = 1;
            progressBar1.Visible = true;

            SqlConnection connTH = new SqlConnection(parentForm1.parentForm.OtherStoreConnectionString("TH"));
            SqlConnection connOH = new SqlConnection(parentForm1.parentForm.OtherStoreConnectionString("OH"));
            SqlConnection connUM = new SqlConnection(parentForm1.parentForm.OtherStoreConnectionString("UM"));
            SqlConnection connCH = new SqlConnection(parentForm1.parentForm.OtherStoreConnectionString("CH"));
            SqlConnection connWM = new SqlConnection(parentForm1.parentForm.OtherStoreConnectionString("WM"));
            SqlConnection connCV = new SqlConnection(parentForm1.parentForm.OtherStoreConnectionString("CV"));
            SqlConnection connPW = new SqlConnection(parentForm1.parentForm.OtherStoreConnectionString("PW"));
            SqlConnection connWB = new SqlConnection(parentForm1.parentForm.OtherStoreConnectionString("WB"));
            SqlConnection connWD = new SqlConnection(parentForm1.parentForm.OtherStoreConnectionString("WD"));
            SqlConnection connGB = new SqlConnection(parentForm1.parentForm.OtherStoreConnectionString("GB"));
            SqlConnection connBW = new SqlConnection(parentForm1.parentForm.OtherStoreConnectionString("BW"));

            SqlConnection connTest = new SqlConnection("Server=VMWARE_DEV;Database=TestDB;UID=ssk;Password=cherry");

            SqlCommand cmd_TransactionUpdtae = new SqlCommand();

            /*try
            {
                cmd.CommandText = "TransactionUpdae_With_NewMemberCode";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connTest;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@OldMemberCode", SqlDbType.BigInt).Value = oldMemberCode;
                cmd.Parameters.Add("@NewMemberCode", SqlDbType.BigInt).Value = newMemberCode;

                connTest.Open();
                cmd.ExecuteNonQuery();
                connTest.Close();

                progressBar1.PerformStep();
            }
            catch
            {
                MessageBox.Show("CAN NOT CONNECT TEST SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connTest.Close();
            }*/

            try
            {
                if (parentForm1.storeCode.ToUpper() == "TH")
                {
                    cmd.CommandText = "TransactionUpdae_With_NewMemberCode";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = parentForm1.conn;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@OldMemberCode", SqlDbType.NVarChar).Value = oldMemberCode;
                    cmd.Parameters.Add("@NewMemberCode", SqlDbType.NVarChar).Value = newMemberCode;

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    progressBar1.PerformStep();
                }
                else
                {
                    cmd.CommandText = "TransactionUpdae_With_NewMemberCode";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connTH;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@OldMemberCode", SqlDbType.NVarChar).Value = oldMemberCode;
                    cmd.Parameters.Add("@NewMemberCode", SqlDbType.NVarChar).Value = newMemberCode;

                    connTH.Open();
                    cmd.ExecuteNonQuery();
                    connTH.Close();

                    progressBar1.PerformStep();
                }
            }
            catch
            {
                if (parentForm1.storeCode.ToUpper() == "TH")
                {
                    MessageBox.Show("CAN NOT CONNECT TEMPLE HILLS SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parentForm1.conn.Close();
                }
                else
                {
                    MessageBox.Show("CAN NOT CONNECT TEMPLE HILLS SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connTH.Close();
                }
            }

            try
            {
                if (parentForm1.storeCode.ToUpper() == "OH")
                {
                    cmd.CommandText = "TransactionUpdae_With_NewMemberCode";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = parentForm1.conn;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@OldMemberCode", SqlDbType.NVarChar).Value = oldMemberCode;
                    cmd.Parameters.Add("@NewMemberCode", SqlDbType.NVarChar).Value = newMemberCode;

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    progressBar1.PerformStep();
                }
                else
                {
                    cmd.CommandText = "TransactionUpdae_With_NewMemberCode";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connOH;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@OldMemberCode", SqlDbType.NVarChar).Value = oldMemberCode;
                    cmd.Parameters.Add("@NewMemberCode", SqlDbType.NVarChar).Value = newMemberCode;

                    connOH.Open();
                    cmd.ExecuteNonQuery();
                    connOH.Close();

                    progressBar1.PerformStep();
                }
            }
            catch
            {
                if (parentForm1.storeCode.ToUpper() == "OH")
                {
                    MessageBox.Show("CAN NOT CONNECT OXON HILL SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parentForm1.conn.Close();
                }
                else
                {
                    MessageBox.Show("CAN NOT CONNECT OXON HILL SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connOH.Close();
                }
            }

            try
            {
                if (parentForm1.storeCode.ToUpper() == "UM")
                {
                    cmd.CommandText = "TransactionUpdae_With_NewMemberCode";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = parentForm1.conn;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@OldMemberCode", SqlDbType.NVarChar).Value = oldMemberCode;
                    cmd.Parameters.Add("@NewMemberCode", SqlDbType.NVarChar).Value = newMemberCode;

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    progressBar1.PerformStep();
                }
                else
                {
                    cmd.CommandText = "TransactionUpdae_With_NewMemberCode";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connUM;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@OldMemberCode", SqlDbType.NVarChar).Value = oldMemberCode;
                    cmd.Parameters.Add("@NewMemberCode", SqlDbType.NVarChar).Value = newMemberCode;

                    connUM.Open();
                    cmd.ExecuteNonQuery();
                    connUM.Close();

                    progressBar1.PerformStep();
                }
            }
            catch
            {
                if (parentForm1.storeCode.ToUpper() == "UM")
                {
                    MessageBox.Show("CAN NOT CONNECT UPPER MARLBORO SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parentForm1.conn.Close();
                }
                else
                {
                    MessageBox.Show("CAN NOT CONNECT UPPER MARLBORO SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connUM.Close();
                }
            }

            try
            {
                if (parentForm1.storeCode.ToUpper() == "CH")
                {
                    cmd.CommandText = "TransactionUpdae_With_NewMemberCode";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = parentForm1.conn;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@OldMemberCode", SqlDbType.NVarChar).Value = oldMemberCode;
                    cmd.Parameters.Add("@NewMemberCode", SqlDbType.NVarChar).Value = newMemberCode;

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    progressBar1.PerformStep();
                }
                else
                {
                    cmd.CommandText = "TransactionUpdae_With_NewMemberCode";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connCH;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@OldMemberCode", SqlDbType.NVarChar).Value = oldMemberCode;
                    cmd.Parameters.Add("@NewMemberCode", SqlDbType.NVarChar).Value = newMemberCode;

                    connCH.Open();
                    cmd.ExecuteNonQuery();
                    connCH.Close();

                    progressBar1.PerformStep();
                }
            }
            catch
            {
                if (parentForm1.storeCode.ToUpper() == "CH")
                {
                    MessageBox.Show("CAN NOT CONNECT CAPITOL HEIGHTS SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parentForm1.conn.Close();
                }
                else
                {
                    MessageBox.Show("CAN NOT CONNECT CAPITOL HEIGHTS SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connCH.Close();
                }
            }

            try
            {
                if (parentForm1.storeCode.ToUpper() == "WM")
                {
                    cmd.CommandText = "TransactionUpdae_With_NewMemberCode";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = parentForm1.conn;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@OldMemberCode", SqlDbType.NVarChar).Value = oldMemberCode;
                    cmd.Parameters.Add("@NewMemberCode", SqlDbType.NVarChar).Value = newMemberCode;

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    progressBar1.PerformStep();
                }
                else
                {
                    cmd.CommandText = "TransactionUpdae_With_NewMemberCode";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connWM;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@OldMemberCode", SqlDbType.NVarChar).Value = oldMemberCode;
                    cmd.Parameters.Add("@NewMemberCode", SqlDbType.NVarChar).Value = newMemberCode;

                    connWM.Open();
                    cmd.ExecuteNonQuery();
                    connWM.Close();

                    progressBar1.PerformStep();
                }
            }
            catch
            {
                if (parentForm1.storeCode.ToUpper() == "WM")
                {
                    MessageBox.Show("CAN NOT CONNECT WINDSOR MILL SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parentForm1.conn.Close();
                }
                else
                {
                    MessageBox.Show("CAN NOT CONNECT WINDSOR MILL SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connWM.Close();
                }
            }

            try
            {
                if (parentForm1.storeCode.ToUpper() == "CV")
                {
                    cmd.CommandText = "TransactionUpdae_With_NewMemberCode";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = parentForm1.conn;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@OldMemberCode", SqlDbType.NVarChar).Value = oldMemberCode;
                    cmd.Parameters.Add("@NewMemberCode", SqlDbType.NVarChar).Value = newMemberCode;

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    progressBar1.PerformStep();
                }
                else
                {
                    cmd.CommandText = "TransactionUpdae_With_NewMemberCode";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connCV;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@OldMemberCode", SqlDbType.NVarChar).Value = oldMemberCode;
                    cmd.Parameters.Add("@NewMemberCode", SqlDbType.NVarChar).Value = newMemberCode;

                    connCV.Open();
                    cmd.ExecuteNonQuery();
                    connCV.Close();

                    progressBar1.PerformStep();
                }
            }
            catch
            {
                if (parentForm1.storeCode.ToUpper() == "CV")
                {
                    MessageBox.Show("CAN NOT CONNECT CATONSVILLE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parentForm1.conn.Close();
                }
                else
                {
                    MessageBox.Show("CAN NOT CONNECT CATONSVILLE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connCV.Close();
                }
            }

            try
            {
                if (parentForm1.storeCode.ToUpper() == "PW")
                {
                    cmd.CommandText = "TransactionUpdae_With_NewMemberCode";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = parentForm1.conn;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@OldMemberCode", SqlDbType.NVarChar).Value = oldMemberCode;
                    cmd.Parameters.Add("@NewMemberCode", SqlDbType.NVarChar).Value = newMemberCode;

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    progressBar1.PerformStep();
                }
                else
                {
                    cmd.CommandText = "TransactionUpdae_With_NewMemberCode";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connPW;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@OldMemberCode", SqlDbType.NVarChar).Value = oldMemberCode;
                    cmd.Parameters.Add("@NewMemberCode", SqlDbType.NVarChar).Value = newMemberCode;

                    connPW.Open();
                    cmd.ExecuteNonQuery();
                    connPW.Close();

                    progressBar1.PerformStep();
                }
            }
            catch
            {
                if (parentForm1.storeCode.ToUpper() == "PW")
                {
                    MessageBox.Show("CAN NOT CONNECT PRINCE WILLIAM SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parentForm1.conn.Close();
                }
                else
                {
                    MessageBox.Show("CAN NOT CONNECT PRINCE WILLIAM SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connPW.Close();
                }
            }

            try
            {
                if (parentForm1.storeCode.ToUpper() == "WB")
                {
                    cmd.CommandText = "TransactionUpdae_With_NewMemberCode";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = parentForm1.conn;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@OldMemberCode", SqlDbType.NVarChar).Value = oldMemberCode;
                    cmd.Parameters.Add("@NewMemberCode", SqlDbType.NVarChar).Value = newMemberCode;

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    progressBar1.PerformStep();
                }
                else
                {
                    cmd.CommandText = "TransactionUpdae_With_NewMemberCode";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connWB;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@OldMemberCode", SqlDbType.NVarChar).Value = oldMemberCode;
                    cmd.Parameters.Add("@NewMemberCode", SqlDbType.NVarChar).Value = newMemberCode;

                    connWB.Open();
                    cmd.ExecuteNonQuery();
                    connWB.Close();

                    progressBar1.PerformStep();
                }
            }
            catch
            {
                if (parentForm1.storeCode.ToUpper() == "WB")
                {
                    MessageBox.Show("CAN NOT CONNECT WOODBRIDGE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parentForm1.conn.Close();
                }
                else
                {
                    MessageBox.Show("CAN NOT CONNECT WOODBRIDGE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connWB.Close();
                }
            }

            try
            {
                if (parentForm1.storeCode.ToUpper() == "WD")
                {
                    cmd.CommandText = "TransactionUpdae_With_NewMemberCode";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = parentForm1.conn;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@OldMemberCode", SqlDbType.NVarChar).Value = oldMemberCode;
                    cmd.Parameters.Add("@NewMemberCode", SqlDbType.NVarChar).Value = newMemberCode;

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    progressBar1.PerformStep();
                }
                else
                {
                    cmd.CommandText = "TransactionUpdae_With_NewMemberCode";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connWD;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@OldMemberCode", SqlDbType.NVarChar).Value = oldMemberCode;
                    cmd.Parameters.Add("@NewMemberCode", SqlDbType.NVarChar).Value = newMemberCode;

                    connWD.Open();
                    cmd.ExecuteNonQuery();
                    connWD.Close();

                    progressBar1.PerformStep();
                }
            }
            catch
            {
                if (parentForm1.storeCode.ToUpper() == "WD")
                {
                    MessageBox.Show("CAN NOT CONNECT WALDORF SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parentForm1.conn.Close();
                }
                else
                {
                    MessageBox.Show("CAN NOT CONNECT WALDORF SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connWD.Close();
                }
            }

            try
            {
                if (parentForm1.storeCode.ToUpper() == "GB")
                {
                    cmd.CommandText = "TransactionUpdae_With_NewMemberCode";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = parentForm1.conn;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@OldMemberCode", SqlDbType.NVarChar).Value = oldMemberCode;
                    cmd.Parameters.Add("@NewMemberCode", SqlDbType.NVarChar).Value = newMemberCode;

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    progressBar1.PerformStep();
                }
                else
                {
                    cmd.CommandText = "TransactionUpdae_With_NewMemberCode";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connGB;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@OldMemberCode", SqlDbType.NVarChar).Value = oldMemberCode;
                    cmd.Parameters.Add("@NewMemberCode", SqlDbType.NVarChar).Value = newMemberCode;

                    connGB.Open();
                    cmd.ExecuteNonQuery();
                    connGB.Close();

                    progressBar1.PerformStep();
                }
            }
            catch
            {
                if (parentForm1.storeCode.ToUpper() == "GB")
                {
                    MessageBox.Show("CAN NOT CONNECT WALDORF SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parentForm1.conn.Close();
                }
                else
                {
                    MessageBox.Show("CAN NOT CONNECT WALDORF SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connGB.Close();
                }
            }

            try
            {
                if (parentForm1.storeCode.ToUpper() == "BW")
                {
                    cmd.CommandText = "TransactionUpdae_With_NewMemberCode";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = parentForm1.conn;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@OldMemberCode", SqlDbType.NVarChar).Value = oldMemberCode;
                    cmd.Parameters.Add("@NewMemberCode", SqlDbType.NVarChar).Value = newMemberCode;

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    progressBar1.PerformStep();
                }
                else
                {
                    cmd.CommandText = "TransactionUpdae_With_NewMemberCode";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connBW;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@OldMemberCode", SqlDbType.NVarChar).Value = oldMemberCode;
                    cmd.Parameters.Add("@NewMemberCode", SqlDbType.NVarChar).Value = newMemberCode;

                    connBW.Open();
                    cmd.ExecuteNonQuery();
                    connBW.Close();

                    progressBar1.PerformStep();
                }
            }
            catch
            {
                if (parentForm1.storeCode.ToUpper() == "BW")
                {
                    MessageBox.Show("CAN NOT CONNECT BOWIE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parentForm1.conn.Close();
                }
                else
                {
                    MessageBox.Show("CAN NOT CONNECT BOWIE SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connBW.Close();
                }
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

        /// <summary>
        /// Databases the connection status.
        /// </summary>
        /// <param name="cs">The cs.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private static bool DBConnectionStatus(string cs)
        {
            try
            {
                using (SqlConnection sqlConn =
                    //new SqlConnection("Server=VMWARE_DEV;Database=TestHQ;UID=ssk;Password=cherry"))
                    new SqlConnection(cs))
                {
                    sqlConn.Open();
                    return (sqlConn.State == ConnectionState.Open);
                }
            }
            catch (SqlException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}