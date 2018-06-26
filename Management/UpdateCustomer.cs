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
    public partial class UpdateCustomer : Form
    {
        public LogInManagements parentForm1;
        public MembershipMain parentForm2;

        SqlConnection newConn = new SqlConnection();

        public Int64 memberSeqNo;
        Int64 memberCode;
        Int64 tempMemberCode;
        DateTime d1;
        DateTime d2;
        DateTime d3;
        Int64 zipCode;
        double memberPoints = 0;
        double discRate = 0;
        string dob;
        string startDate;
        string expDate;

        Int64 homePhone;
        Int64 cellPhone;

        SqlCommand cmd = new SqlCommand();

        public UpdateCustomer()
        {
            InitializeComponent();
        }

        private void UpdateCustomer_Load(object sender, EventArgs e)
        {
            this.Text = "UPDATE NEW MEMBER - " + parentForm1.storeName.ToUpper().ToString();
            txtMemberCode.Enabled = false;
            newConn.ConnectionString = parentForm1.B4UHQCS_IP;

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

        private void txtDateOfBirth_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar3.Visible = true;
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

        private void monthCalendar3_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtDateOfBirth.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar3.SelectionStart));
            monthCalendar3.Visible = false;
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

            if (Int64.TryParse(txtMemberCode.Text, out memberCode))
            {
            }
            else
            {
                MessageBox.Show("INPUT VALID MEMBER CODE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemberCode.SelectAll();
                txtMemberCode.Focus();
                return;
            }

            if (cmbMemberType.SelectedIndex == 1 | cmbMemberType.SelectedIndex == 3)
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

            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
            {
                this.Enabled = false;

                try
                {
                    cmd.CommandText = "Update_Member";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = newConn;
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

                    cmd.Parameters.Add("@UpdateStoreCode", SqlDbType.NVarChar).Value = parentForm1.StoreCode.ToUpper().ToString();
                    cmd.Parameters.Add("@UpdateID", SqlDbType.NVarChar).Value = parentForm1.employeeID.ToUpper().ToString();
                    cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = DateTime.Now;

                    newConn.Open();
                    cmd.ExecuteNonQuery();
                    newConn.Close();

                    if (tempMemberCode != memberCode)
                        Transaction_Update(tempMemberCode, memberCode);

                    MessageBox.Show("SUCCESSFULLY UPDATED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                    parentForm2.txtSearchKeyword.Text = Convert.ToString(memberCode);
                    parentForm2.rdoBtnMemberCode.Checked = true;
                    parentForm2.btnSearch_Click(null, null);
                    parentForm2.txtSearchKeyword.SelectAll();
                    parentForm2.txtSearchKeyword.Focus();
                }
                catch
                {
                    MessageBox.Show("UPDATE FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    newConn.Close();
                    this.Enabled = true;
                    return;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            parentForm2.btnSearch_Click(null, null);
            this.Close();
        }

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
            else if (cmbMemberType.Text == "VVIP STORE MEMBER")
            {
                lblDiscountOption.Text = "10%";
                discRate = 10;
                rdoBtnSEFalse.Checked = true;
                txtStartDate.Enabled = true;
                txtExpirationDate.Enabled = true;
            }
            else if (cmbMemberType.Text == "VVIP BEAUTICIAN")
            {
                lblDiscountOption.Text = "15%";
                discRate = 15;
                rdoBtnSEFalse.Checked = true;
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

        private void btnMemberCodeChange_Click(object sender, EventArgs e)
        {
            txtMemberCode.Enabled = true;
            btnMemberCodeChange.Visible = false;
            btnMemberCodeCheck.Visible = true;
            btnUpdate.Enabled = false;

            txtMemberCode.SelectAll();
            txtMemberCode.Focus();
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
                    btnMemberCodeCheck.Visible = false;
                    btnMemberCodeChange.Visible = true;
                    txtMemberCode.Enabled = false;
                    btnUpdate.Enabled = true;
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

        private void Transaction_Update(Int64 oldMemberCode, Int64 newMemberCode)
        {
            if (DBConnectionStatus(parentForm1.THCS_IP) == false)
            {
                MessageBox.Show("TEMPLE HILLS DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DBConnectionStatus(parentForm1.OHCS_IP) == false)
            {
                MessageBox.Show("OXON HILL DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DBConnectionStatus(parentForm1.UMCS_IP) == false)
            {
                MessageBox.Show("UPPER MARLBORO DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DBConnectionStatus(parentForm1.CHCS_IP) == false)
            {
                MessageBox.Show("CAPITOL HEIGHTS DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DBConnectionStatus(parentForm1.WMCS_IP) == false)
            {
                MessageBox.Show("WINDSOR MILL DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DBConnectionStatus(parentForm1.CVCS_IP) == false)
            {
                MessageBox.Show("CATONSVILLE DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DBConnectionStatus(parentForm1.PWCS_IP) == false)
            {
                MessageBox.Show("PRINCE WILLIAM DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DBConnectionStatus(parentForm1.WBCS_IP) == false)
            {
                MessageBox.Show("WOODBRIDGE DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DBConnectionStatus(parentForm1.WDCS_IP) == false)
            {
                MessageBox.Show("WALDORF DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DBConnectionStatus(parentForm1.GBCS_IP) == false)
            {
                MessageBox.Show("GAITHERSBURG DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DBConnectionStatus(parentForm1.BWCS_IP) == false)
            {
                MessageBox.Show("BOWIE DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            progressBar1.Minimum = 0;
            progressBar1.Maximum = 11;
            progressBar1.Step = 1;
            progressBar1.Visible = true;

            SqlConnection connTH = new SqlConnection(parentForm1.THCS_IP);
            SqlConnection connOH = new SqlConnection(parentForm1.OHCS_IP);
            SqlConnection connUM = new SqlConnection(parentForm1.UMCS_IP);
            SqlConnection connCH = new SqlConnection(parentForm1.CHCS_IP);
            SqlConnection connWM = new SqlConnection(parentForm1.WMCS_IP);
            SqlConnection connCV = new SqlConnection(parentForm1.CVCS_IP);
            SqlConnection connPW = new SqlConnection(parentForm1.PWCS_IP);
            SqlConnection connWB = new SqlConnection(parentForm1.WBCS_IP);
            SqlConnection connWD = new SqlConnection(parentForm1.WDCS_IP);
            SqlConnection connGB = new SqlConnection(parentForm1.GBCS_IP);
            SqlConnection connBW = new SqlConnection(parentForm1.BWCS_IP);

            SqlCommand cmd_TransactionUpdtae = new SqlCommand();

            try
            {
                if (parentForm1.StoreCode.ToUpper() == "TH")
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
                if (parentForm1.StoreCode.ToUpper() == "TH")
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
                if (parentForm1.StoreCode.ToUpper() == "OH")
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
                if (parentForm1.StoreCode.ToUpper() == "OH")
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
                if (parentForm1.StoreCode.ToUpper() == "UM")
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
                if (parentForm1.StoreCode.ToUpper() == "UM")
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
                if (parentForm1.StoreCode.ToUpper() == "CH")
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
                if (parentForm1.StoreCode.ToUpper() == "CH")
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
                if (parentForm1.StoreCode.ToUpper() == "WM")
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
                if (parentForm1.StoreCode.ToUpper() == "WM")
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
                if (parentForm1.StoreCode.ToUpper() == "CV")
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
                if (parentForm1.StoreCode.ToUpper() == "CV")
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
                if (parentForm1.StoreCode.ToUpper() == "PW")
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
                if (parentForm1.StoreCode.ToUpper() == "PW")
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
                if (parentForm1.StoreCode.ToUpper() == "WB")
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
                if (parentForm1.StoreCode.ToUpper() == "WB")
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
                if (parentForm1.StoreCode.ToUpper() == "WD")
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
                if (parentForm1.StoreCode.ToUpper() == "WD")
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
                if (parentForm1.StoreCode.ToUpper() == "GB")
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
                if (parentForm1.StoreCode.ToUpper() == "GB")
                {
                    MessageBox.Show("CAN NOT CONNECT GAITHERSBURG SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parentForm1.conn.Close();
                }
                else
                {
                    MessageBox.Show("CAN NOT CONNECT GAITHERSBURG SERVER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connGB.Close();
                }
            }

            try
            {
                if (parentForm1.StoreCode.ToUpper() == "BW")
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
                if (parentForm1.StoreCode.ToUpper() == "BW")
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

        public static bool DBConnectionStatus(string cs)
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

        private void btnUpdateMemberPoints_Click(object sender, EventArgs e)
        {
            InputMemberPoints inputMemberPointsForm = new InputMemberPoints(memberSeqNo);
            inputMemberPointsForm.parentForm1 = this.parentForm1;
            inputMemberPointsForm.parentFrom2 = this;
            inputMemberPointsForm.ShowDialog();
        }
    }
}