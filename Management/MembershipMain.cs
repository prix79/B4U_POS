using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using Office_12 = Microsoft.Office.Core;
using Excel_12 = Microsoft.Office.Interop.Excel;

namespace Management
{
    public partial class MembershipMain : Form
    {
        public LogInManagements parentForm;

        public SqlConnection newConn = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public DataTable dt = new DataTable();
        public Font drvFont = new Font("Arial", 9, FontStyle.Bold);
        public Font drvFont2 = new Font("Arial", 8, FontStyle.Bold);

        Int64 memberCode;

        int opt = 0;

        public string mgrID;
        double memberMergingPoints = 0;

        public MembershipMain()
        {
            InitializeComponent();
        }

        private void MembershipMain_Load(object sender, EventArgs e)
        {
            if (parentForm.userLevel >= parentForm.SystemAdministratorLV & parentForm.employeeID.ToUpper() == "ADMIN")
                btnExcel.Visible = true;

            if (parentForm.userLevel < parentForm.btnCustomerUpdate)
            {
                btnUpdateCustomer.Enabled = false;
            }

            if (parentForm.userLevel < parentForm.btnCustomerDelete)
                btnDeleteCustomer.Enabled = false;
            
            //Temporary disabled
            //if (parentForm.StoreCode == parentForm.HQStoreCode & parentForm.userLevel >= parentForm.btnCustomerExcel)
            //    btnExcel.Visible = true;

            /*if (parentForm.userLevel == parentForm.SystemAdministratorLV & parentForm.employeeID.ToUpper() == parentForm.SystemMasterUserName.ToUpper())
            {
                dataGridView1.ReadOnly = false;
                btnUpdateByAdmin.Visible = true;
            }*/

            this.Text = "MEMBERSHIP MAIN - " + parentForm.employeeID + " LOGGED IN " + parentForm.storeName;
            newConn.ConnectionString = parentForm.B4UHQCS_IP;

            if (DBConnectionStatus(parentForm.B4UHQCS_IP) == false)
            {
                MessageBox.Show("MEMBERSHIP DB CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                groupBox1.Enabled = false;
                btnRegisterNewCustomer.Enabled = false;
                btnLoadingAllCustomer.Enabled = false;
                btnDeleteCustomer.Enabled = false;
                btnUpdateCustomer.Enabled = false;
                btnViewCustomerInfo.Enabled = false;
            }
            else
            {
                txtSearchKeyword.Select();
                txtSearchKeyword.Focus();

                //btnMerge.Enabled = false;
            }
        }

        public void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdoBtnFirstName.Checked == true)
                {
                    cmd.CommandText = "Show_Member_With_Keyword";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = newConn;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@Index", SqlDbType.Int).Value = 1;
                    cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = txtSearchKeyword.Text.ToUpper() + "%";
                    SqlDataAdapter adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd;

                    newConn.Open();
                    dt.Clear();
                    adapt.Fill(dt);
                    newConn.Close();

                    BindingData(0);

                    btnMerge.Enabled = false;
                }
                else if (rdoBtnLastName.Checked == true)
                {
                    cmd.CommandText = "Show_Member_With_Keyword";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = newConn;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@Index", SqlDbType.Int).Value = 2;
                    cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = txtSearchKeyword.Text.ToUpper() + "%";
                    SqlDataAdapter adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd;

                    newConn.Open();
                    dt.Clear();
                    adapt.Fill(dt);
                    newConn.Close();

                    BindingData(0);

                    btnMerge.Enabled = false;
                }
                else if (rdoBtnHomePhone.Checked == true)
                {
                    cmd.CommandText = "Show_Member_With_Keyword";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = newConn;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@Index", SqlDbType.Int).Value = 3;
                    cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = txtSearchKeyword.Text.ToUpper() + "%";
                    SqlDataAdapter adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd;

                    newConn.Open();
                    dt.Clear();
                    adapt.Fill(dt);
                    newConn.Close();

                    BindingData(1);

                    if (dataGridView1.RowCount > 1 & txtSearchKeyword.Text != "")
                    {
                        DialogResult MyDialogResult;
                        MyDialogResult = MessageBox.Show(this, "MULTIPLE MEMBERSHIPS ARE FOUND. DO YOU WANT TO MERGE THEM?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

                        if (MyDialogResult == DialogResult.Yes)
                        {
                            btnMerge.Enabled = true;
                            dataGridView1.Columns[32].Visible = true;
                            dataGridView1.Columns[33].Visible = true;
                        }
                        else
                        {
                            btnMerge.Enabled = false;
                            dataGridView1.Columns[32].Visible = false;
                            dataGridView1.Columns[33].Visible = false;
                        }
                    }
                }
                else if (rdoBtnCellPhone.Checked == true)
                {
                    cmd.CommandText = "Show_Member_With_Keyword";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = newConn;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@Index", SqlDbType.Int).Value = 4;
                    cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = txtSearchKeyword.Text.ToUpper() + "%";
                    SqlDataAdapter adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd;

                    newConn.Open();
                    dt.Clear();
                    adapt.Fill(dt);
                    newConn.Close();

                    BindingData(1);

                    if (dataGridView1.RowCount > 1 & txtSearchKeyword.Text != "")
                    {
                        DialogResult MyDialogResult;
                        MyDialogResult = MessageBox.Show(this, "MULTIPLE MEMBERSHIPS ARE FOUND. DO YOU WANT TO MERGE THEM?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

                        if (MyDialogResult == DialogResult.Yes)
                        {
                            btnMerge.Enabled = true;
                            dataGridView1.Columns[32].Visible = true;
                            dataGridView1.Columns[33].Visible = true;
                        }
                        else
                        {
                            btnMerge.Enabled = false;
                            dataGridView1.Columns[32].Visible = false;
                            dataGridView1.Columns[33].Visible = false;
                        }
                    }
                }
                else if (rdoBtnMemberCode.Checked == true)
                {
                    if (Int64.TryParse(txtSearchKeyword.Text, out memberCode))
                    {
                        cmd.CommandText = "Show_Member_With_Keyword";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = newConn;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@Index", SqlDbType.Int).Value = 5;
                        cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = Convert.ToString(memberCode);
                        SqlDataAdapter adapt = new SqlDataAdapter();
                        adapt.SelectCommand = cmd;

                        newConn.Open();
                        dt.Clear();
                        adapt.Fill(dt);
                        newConn.Close();

                        BindingData(0);

                        btnMerge.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("INPUT VALID MEMBER CODE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSearchKeyword.SelectAll();
                        txtSearchKeyword.Focus();
                        return;
                    }
                }

                lblNumberOfMembers.Text = Convert.ToString(dataGridView1.RowCount);
                txtSearchKeyword.SelectAll();
                txtSearchKeyword.Focus();
            }
            catch
            {
                MessageBox.Show("CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                newConn.Close();
                txtSearchKeyword.SelectAll();
                txtSearchKeyword.Focus();
                return;
            }
        }

        private void btnLoadingAllCustomer_Click(object sender, EventArgs e)
        {
            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "IT MAY TAKE A LOT OF TIME DEPENDS ON THE INTERNET CONNECTION.\n\n" + "ARE YOU SURE TO PROCEED?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
            {
                this.Enabled = false;

                cmd.CommandText = "Show_All_Members";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = newConn;
                cmd.Parameters.Clear();
                SqlDataAdapter adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                newConn.Open();
                dt.Clear();
                adapt.Fill(dt);
                newConn.Close();

                BindingData(0);
                this.Enabled = true;
                btnMerge.Enabled = false;

                txtSearchKeyword.Clear();
                txtSearchKeyword.SelectAll();
                txtSearchKeyword.Focus();

                lblNumberOfMembers.Text = dataGridView1.RowCount.ToString();
            }
            else
            {
                txtSearchKeyword.SelectAll();
                txtSearchKeyword.Focus();
            }
        }

        private void btnRegisterNewCustomer_Click(object sender, EventArgs e)
        {
            RegisterNewCustomer registerNewCustomerForm = new RegisterNewCustomer();
            registerNewCustomerForm.parentForm1 = this.parentForm;
            registerNewCustomerForm.parentForm2 = this;
            registerNewCustomerForm.ShowDialog();
        }

        public void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (Convert.ToString(dataGridView1.SelectedCells[13].Value) == "VVIP STORE MEMBER" | Convert.ToString(dataGridView1.SelectedCells[13].Value) == "VVIP BEAUTICIAN")
                {
                    if (parentForm.userLevel >= parentForm.StoreManagerLV)
                    {
                        UpdateCustomer updateCustomerForm = new UpdateCustomer();
                        updateCustomerForm.parentForm1 = this.parentForm;
                        updateCustomerForm.parentForm2 = this;
                        updateCustomerForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("NOT AUTHORIZED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    UpdateCustomer updateCustomerForm = new UpdateCustomer();
                    updateCustomerForm.parentForm1 = this.parentForm;
                    updateCustomerForm.parentForm2 = this;
                    updateCustomerForm.ShowDialog();
                }
            }
            else
            {
                txtSearchKeyword.SelectAll();
                txtSearchKeyword.Focus();
            }
        }

        public void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (Convert.ToString(dataGridView1.SelectedCells[13].Value) == "VVIP STORE MEMBER" | Convert.ToString(dataGridView1.SelectedCells[13].Value) == "VVIP BEAUTICIAN")
                {
                    if (parentForm.userLevel >= parentForm.StoreManagerLV)
                    {
                        DialogResult MyDialogResult;
                        MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (MyDialogResult == DialogResult.Yes)
                        {
                            cmd.CommandText = "Delete_Member";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = newConn;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@MemberSeqNo", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.SelectedCells[0].Value);

                            newConn.Open();
                            cmd.ExecuteNonQuery();
                            newConn.Close();

                            btnSearch_Click(null, null);
                        }
                    }
                    else
                    {
                        MessageBox.Show("NOT AUTHORIZED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    DialogResult MyDialogResult;
                    MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (MyDialogResult == DialogResult.Yes)
                    {
                        cmd.CommandText = "Delete_Member";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = newConn;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@MemberSeqNo", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.SelectedCells[0].Value);

                        newConn.Open();
                        cmd.ExecuteNonQuery();
                        newConn.Close();

                        btnSearch_Click(null, null);
                    }
                }
            }
            else
            {
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoBtnFirstName_CheckedChanged(object sender, EventArgs e)
        {
            txtSearchKeyword.SelectAll();
            txtSearchKeyword.Focus();
        }

        private void rdoBtnHomePhone_CheckedChanged(object sender, EventArgs e)
        {
            txtSearchKeyword.SelectAll();
            txtSearchKeyword.Focus();
        }

        private void rdoBtnMemberCode_CheckedChanged(object sender, EventArgs e)
        {
            txtSearchKeyword.SelectAll();
            txtSearchKeyword.Focus();
        }

        private void rdoBtnLastName_CheckedChanged(object sender, EventArgs e)
        {
            txtSearchKeyword.SelectAll();
            txtSearchKeyword.Focus();
        }

        private void rdoBtnCellPhone_CheckedChanged(object sender, EventArgs e)
        {
            txtSearchKeyword.SelectAll();
            txtSearchKeyword.Focus();
        }

        private void BindingData(int option)
        {
            opt = option;

            dataGridView1.DataSource = null;

            if (parentForm.userLevel > 6)
            {
                if (option == 0)
                {
                    dataGridView1.RowTemplate.Height = 40;
                    dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                    dataGridView1.DataSource = dt;
                    dataGridView1.ReadOnly = true;
                    dataGridView1.AllowUserToResizeRows = false;

                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "STORE CODE";
                    dataGridView1.Columns[1].Width = 50;
                    //dataGridView1.Columns[1].Visible = false;
                    dataGridView1.Columns[2].HeaderText = "FIRST NAME";
                    dataGridView1.Columns[2].Width = 130;
                    dataGridView1.Columns[3].HeaderText = "LAST NAME";
                    dataGridView1.Columns[3].Width = 130;
                    dataGridView1.Columns[4].HeaderText = "DATE OF BIRTH";
                    dataGridView1.Columns[4].Width = 90;
                    dataGridView1.Columns[4].DefaultCellStyle.Format = "MM/dd/yyyy";
                    dataGridView1.Columns[5].HeaderText = "ADDRESS";
                    dataGridView1.Columns[5].Width = 200;
                    dataGridView1.Columns[6].HeaderText = "CITY";
                    dataGridView1.Columns[6].Width = 150;
                    dataGridView1.Columns[7].HeaderText = "STATE";
                    dataGridView1.Columns[7].Width = 50;
                    dataGridView1.Columns[8].HeaderText = "ZIP CODE";
                    dataGridView1.Columns[8].Width = 50;
                    dataGridView1.Columns[9].HeaderText = "HOME PHONE";
                    dataGridView1.Columns[9].Width = 95;
                    dataGridView1.Columns[10].HeaderText = "CELL PHONE";
                    dataGridView1.Columns[10].Width = 95;
                    dataGridView1.Columns[11].HeaderText = "EMAIL";
                    dataGridView1.Columns[11].Width = 100;
                    dataGridView1.Columns[12].HeaderText = "MEMBER CODE";
                    dataGridView1.Columns[12].Width = 100;
                    dataGridView1.Columns[13].HeaderText = "MEMBER TYPE";
                    dataGridView1.Columns[13].Width = 130;
                    dataGridView1.Columns[14].HeaderText = "LICENSE NUMBER";
                    dataGridView1.Columns[14].Width = 100;
                    dataGridView1.Columns[15].HeaderText = "DISCOUNT OPTION";
                    dataGridView1.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[15].DefaultCellStyle.Format = "0\\%";
                    dataGridView1.Columns[15].Width = 70;
                    dataGridView1.Columns[16].HeaderText = "INITIAL MP";
                    dataGridView1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //dataGridView1.Columns[16].DefaultCellStyle.Format = "C";
                    dataGridView1.Columns[16].Width = 70;
                    dataGridView1.Columns[17].HeaderText = "MEMBER POINTS";
                    dataGridView1.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //dataGridView1.Columns[17].DefaultCellStyle.Format = "C";
                    dataGridView1.Columns[17].Width = 70;
                    dataGridView1.Columns[18].HeaderText = "START DATE";
                    dataGridView1.Columns[18].Width = 90;
                    dataGridView1.Columns[18].DefaultCellStyle.Format = "MM/dd/yyyy h:mm:ss tt";
                    dataGridView1.Columns[19].HeaderText = "EXPIRATION DATE";
                    dataGridView1.Columns[19].Width = 90;
                    dataGridView1.Columns[19].DefaultCellStyle.Format = "MM/dd/yyyy";
                    dataGridView1.Columns[20].HeaderText = "LAST VISIT DATE";
                    dataGridView1.Columns[20].Width = 90;
                    dataGridView1.Columns[20].DefaultCellStyle.Format = "MM/dd/yyyy h:mm:ss tt";
                    dataGridView1.Columns[21].HeaderText = "TRNS(P)";
                    dataGridView1.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[21].Width = 60;
                    dataGridView1.Columns[22].HeaderText = "TRNS(R)";
                    dataGridView1.Columns[22].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[22].Width = 60;
                    dataGridView1.Columns[23].HeaderText = "TRNS(T)";
                    dataGridView1.Columns[23].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[23].Width = 60;
                    dataGridView1.Columns[24].HeaderText = "TOTAL TRANSACTION AMOUNT";
                    dataGridView1.Columns[24].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[24].DefaultCellStyle.Format = "c";
                    dataGridView1.Columns[24].Width = 100;
                    dataGridView1.Columns[25].HeaderText = "SCHOOL GRADUATED";
                    dataGridView1.Columns[25].Width = 100;
                    dataGridView1.Columns[26].HeaderText = "MEMO";
                    dataGridView1.Columns[26].Width = 100;
                    dataGridView1.Columns[27].HeaderText = "ACT";
                    dataGridView1.Columns[27].Width = 50;
                    dataGridView1.Columns[28].HeaderText = "EMP";
                    dataGridView1.Columns[28].Width = 50;
                    dataGridView1.Columns[29].HeaderText = "UPDATE STORE CODE";
                    dataGridView1.Columns[29].Width = 50;
                    dataGridView1.Columns[30].HeaderText = "UPDATE ID";
                    dataGridView1.Columns[30].Width = 90;
                    dataGridView1.Columns[31].HeaderText = "UPDATE DATE";
                    dataGridView1.Columns[31].Width = 90;
                    dataGridView1.Columns[31].DefaultCellStyle.Format = "MM/dd/yyyy h:mm:ss tt";
                    dataGridView1.Columns[32].Visible = false;
                    dataGridView1.Columns[33].Visible = false;

                    dataGridView1.ClearSelection();
                }
                else if (option == 1)
                {
                    dataGridView1.ReadOnly = false;
                    dataGridView1.RowTemplate.Height = 40;
                    dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                    dataGridView1.DataSource = dt;
                    dataGridView1.AllowUserToResizeRows = false;

                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "STORE CODE";
                    dataGridView1.Columns[1].Width = 50;
                    dataGridView1.Columns[1].ReadOnly = true;
                    dataGridView1.Columns[2].HeaderText = "FIRST NAME";
                    dataGridView1.Columns[2].Width = 130;
                    dataGridView1.Columns[2].ReadOnly = true;
                    dataGridView1.Columns[3].HeaderText = "LAST NAME";
                    dataGridView1.Columns[3].Width = 130;
                    dataGridView1.Columns[3].ReadOnly = true;
                    dataGridView1.Columns[4].HeaderText = "DATE OF BIRTH";
                    dataGridView1.Columns[4].Width = 90;
                    dataGridView1.Columns[4].DefaultCellStyle.Format = "MM/dd/yyyy";
                    dataGridView1.Columns[4].ReadOnly = true;
                    dataGridView1.Columns[5].HeaderText = "ADDRESS";
                    dataGridView1.Columns[5].Width = 200;
                    dataGridView1.Columns[5].ReadOnly = true;
                    dataGridView1.Columns[6].HeaderText = "CITY";
                    dataGridView1.Columns[6].Width = 150;
                    dataGridView1.Columns[6].ReadOnly = true;
                    dataGridView1.Columns[7].HeaderText = "STATE";
                    dataGridView1.Columns[7].Width = 50;
                    dataGridView1.Columns[7].ReadOnly = true;
                    dataGridView1.Columns[8].HeaderText = "ZIP CODE";
                    dataGridView1.Columns[8].Width = 50;
                    dataGridView1.Columns[8].ReadOnly = true;
                    dataGridView1.Columns[9].HeaderText = "HOME PHONE";
                    dataGridView1.Columns[9].Width = 95;
                    dataGridView1.Columns[9].ReadOnly = true;
                    dataGridView1.Columns[10].HeaderText = "CELL PHONE";
                    dataGridView1.Columns[10].Width = 95;
                    dataGridView1.Columns[10].ReadOnly = true;
                    dataGridView1.Columns[11].HeaderText = "EMAIL";
                    dataGridView1.Columns[11].Width = 100;
                    dataGridView1.Columns[11].ReadOnly = true;
                    dataGridView1.Columns[12].HeaderText = "MEMBER CODE";
                    dataGridView1.Columns[12].Width = 100;
                    dataGridView1.Columns[12].ReadOnly = true;
                    dataGridView1.Columns[13].HeaderText = "MEMBER TYPE";
                    dataGridView1.Columns[13].Width = 130;
                    dataGridView1.Columns[13].ReadOnly = true;
                    dataGridView1.Columns[14].HeaderText = "LICENSE NUMBER";
                    dataGridView1.Columns[14].Width = 100;
                    dataGridView1.Columns[14].ReadOnly = true;
                    dataGridView1.Columns[15].HeaderText = "DISCOUNT OPTION";
                    dataGridView1.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[15].DefaultCellStyle.Format = "0\\%";
                    dataGridView1.Columns[15].Width = 70;
                    dataGridView1.Columns[15].ReadOnly = true;
                    dataGridView1.Columns[16].HeaderText = "INITIAL MP";
                    dataGridView1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //dataGridView1.Columns[16].DefaultCellStyle.Format = "C";
                    dataGridView1.Columns[16].Width = 70;
                    dataGridView1.Columns[16].ReadOnly = true;
                    dataGridView1.Columns[17].HeaderText = "MEMBER POINTS";
                    dataGridView1.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //dataGridView1.Columns[17].DefaultCellStyle.Format = "C";
                    dataGridView1.Columns[17].Width = 70;
                    dataGridView1.Columns[17].ReadOnly = true;
                    dataGridView1.Columns[18].HeaderText = "START DATE";
                    dataGridView1.Columns[18].Width = 90;
                    dataGridView1.Columns[18].DefaultCellStyle.Format = "MM/dd/yyyy h:mm:ss tt";
                    dataGridView1.Columns[18].ReadOnly = true;
                    dataGridView1.Columns[19].HeaderText = "EXPIRATION DATE";
                    dataGridView1.Columns[19].Width = 90;
                    dataGridView1.Columns[19].DefaultCellStyle.Format = "MM/dd/yyyy";
                    dataGridView1.Columns[19].ReadOnly = true;
                    dataGridView1.Columns[20].HeaderText = "LAST VISIT DATE";
                    dataGridView1.Columns[20].Width = 90;
                    dataGridView1.Columns[20].DefaultCellStyle.Format = "MM/dd/yyyy h:mm:ss tt";
                    dataGridView1.Columns[20].ReadOnly = true;
                    dataGridView1.Columns[21].HeaderText = "TRNS(P)";
                    dataGridView1.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[21].Width = 60;
                    dataGridView1.Columns[21].ReadOnly = true;
                    dataGridView1.Columns[22].HeaderText = "TRNS(R)";
                    dataGridView1.Columns[22].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[22].Width = 60;
                    dataGridView1.Columns[22].ReadOnly = true;
                    dataGridView1.Columns[23].HeaderText = "TRNS(T)";
                    dataGridView1.Columns[23].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[23].Width = 60;
                    dataGridView1.Columns[23].ReadOnly = true;
                    dataGridView1.Columns[24].HeaderText = "TOTAL TRANSACTION AMOUNT";
                    dataGridView1.Columns[24].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[24].DefaultCellStyle.Format = "c";
                    dataGridView1.Columns[24].Width = 100;
                    dataGridView1.Columns[24].ReadOnly = true;
                    dataGridView1.Columns[25].HeaderText = "SCHOOL GRADUATED";
                    dataGridView1.Columns[25].Width = 100;
                    dataGridView1.Columns[25].ReadOnly = true;
                    dataGridView1.Columns[26].HeaderText = "MEMO";
                    dataGridView1.Columns[26].Width = 100;
                    dataGridView1.Columns[26].ReadOnly = true;
                    dataGridView1.Columns[27].HeaderText = "ACT";
                    dataGridView1.Columns[27].Width = 50;
                    dataGridView1.Columns[27].ReadOnly = true;
                    dataGridView1.Columns[28].HeaderText = "EMP";
                    dataGridView1.Columns[28].Width = 50;
                    dataGridView1.Columns[28].ReadOnly = true;
                    dataGridView1.Columns[29].HeaderText = "UPDATE STORE CODE";
                    dataGridView1.Columns[29].Width = 50;
                    dataGridView1.Columns[29].ReadOnly = true;
                    dataGridView1.Columns[30].HeaderText = "UPDATE ID";
                    dataGridView1.Columns[30].Width = 90;
                    dataGridView1.Columns[30].ReadOnly = true;
                    dataGridView1.Columns[31].HeaderText = "UPDATE DATE";
                    dataGridView1.Columns[31].Width = 90;
                    dataGridView1.Columns[31].DefaultCellStyle.Format = "MM/dd/yyyy h:mm:ss tt";
                    dataGridView1.Columns[31].ReadOnly = true;
                    dataGridView1.Columns[32].HeaderText = "PRIMARY";
                    dataGridView1.Columns[32].Width = 60;
                    dataGridView1.Columns[32].Visible = false;
                    dataGridView1.Columns[32].ReadOnly = false;
                    dataGridView1.Columns[33].HeaderText = "SELECT";
                    dataGridView1.Columns[33].Width = 60;
                    dataGridView1.Columns[33].Visible = false;
                    dataGridView1.Columns[33].ReadOnly = false;

                    dataGridView1.ClearSelection();
                }
            }
            else
            {
                if (option == 0)
                {
                    dataGridView1.RowTemplate.Height = 40;
                    dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                    dataGridView1.DataSource = dt;
                    dataGridView1.ReadOnly = true;
                    dataGridView1.AllowUserToResizeRows = false;

                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "STORE CODE";
                    dataGridView1.Columns[1].Width = 50;
                    dataGridView1.Columns[2].HeaderText = "FIRST NAME";
                    dataGridView1.Columns[2].Width = 80;
                    dataGridView1.Columns[3].HeaderText = "LAST NAME";
                    dataGridView1.Columns[3].Width = 80;
                    dataGridView1.Columns[4].HeaderText = "DATE OF BIRTH";
                    dataGridView1.Columns[4].Width = 70;
                    dataGridView1.Columns[4].DefaultCellStyle.Format = "MM/dd/yyyy";
                    dataGridView1.Columns[5].HeaderText = "ADDRESS";
                    dataGridView1.Columns[5].Width = 130;
                    dataGridView1.Columns[6].HeaderText = "CITY";
                    dataGridView1.Columns[6].Width = 100;
                    dataGridView1.Columns[7].HeaderText = "STATE";
                    dataGridView1.Columns[7].Width = 50;
                    dataGridView1.Columns[8].HeaderText = "ZIP CODE";
                    dataGridView1.Columns[8].Width = 45;
                    dataGridView1.Columns[9].HeaderText = "HOME PHONE";
                    dataGridView1.Columns[9].Width = 80;
                    dataGridView1.Columns[10].HeaderText = "CELL PHONE";
                    dataGridView1.Columns[10].Width = 80;
                    dataGridView1.Columns[11].HeaderText = "EMAIL";
                    dataGridView1.Columns[11].Width = 100;
                    dataGridView1.Columns[11].Visible = false;
                    dataGridView1.Columns[12].HeaderText = "MEMBER CODE";
                    dataGridView1.Columns[12].Width = 95;
                    dataGridView1.Columns[13].HeaderText = "MEMBER TYPE";
                    dataGridView1.Columns[13].Width = 115;
                    dataGridView1.Columns[14].HeaderText = "LICENSE NUMBER";
                    dataGridView1.Columns[14].Width = 100;
                    dataGridView1.Columns[14].Visible = false;
                    dataGridView1.Columns[15].HeaderText = "DISCOUNT OPTION";
                    dataGridView1.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[15].DefaultCellStyle.Format = "0\\%";
                    dataGridView1.Columns[15].Width = 70;
                    dataGridView1.Columns[15].Visible = false;
                    dataGridView1.Columns[16].HeaderText = "INITIAL MP";
                    dataGridView1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //dataGridView1.Columns[16].DefaultCellStyle.Format = "C";
                    dataGridView1.Columns[16].Width = 70;
                    dataGridView1.Columns[16].Visible = false;
                    dataGridView1.Columns[17].HeaderText = "MEMBER POINTS";
                    dataGridView1.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //dataGridView1.Columns[17].DefaultCellStyle.Format = "C";
                    dataGridView1.Columns[17].Width = 60;
                    dataGridView1.Columns[18].HeaderText = "START DATE";
                    dataGridView1.Columns[18].Width = 70;
                    dataGridView1.Columns[18].DefaultCellStyle.Format = "MM/dd/yyyy";
                    dataGridView1.Columns[19].HeaderText = "EXPIRATION DATE";
                    dataGridView1.Columns[19].Width = 90;
                    dataGridView1.Columns[19].DefaultCellStyle.Format = "MM/dd/yyyy";
                    dataGridView1.Columns[19].Visible = false;
                    dataGridView1.Columns[20].HeaderText = "LAST VISIT DATE";
                    dataGridView1.Columns[20].Width = 70;
                    dataGridView1.Columns[20].DefaultCellStyle.Format = "MM/dd/yyyy";
                    dataGridView1.Columns[21].HeaderText = "TRNS(P)";
                    dataGridView1.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[21].Width = 60;
                    dataGridView1.Columns[21].Visible = false;
                    dataGridView1.Columns[22].HeaderText = "TRNS(R)";
                    dataGridView1.Columns[22].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[22].Width = 60;
                    dataGridView1.Columns[22].Visible = false;
                    dataGridView1.Columns[23].HeaderText = "TRNS(T)";
                    dataGridView1.Columns[23].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[23].Width = 60;
                    dataGridView1.Columns[23].Visible = false;
                    dataGridView1.Columns[24].HeaderText = "TOTAL TRANSACTION AMOUNT";
                    dataGridView1.Columns[24].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[24].DefaultCellStyle.Format = "c";
                    dataGridView1.Columns[24].Width = 100;
                    dataGridView1.Columns[24].Visible = false;
                    dataGridView1.Columns[25].HeaderText = "SCHOOL GRADUATED";
                    dataGridView1.Columns[25].Width = 100;
                    dataGridView1.Columns[25].Visible = false;
                    dataGridView1.Columns[26].HeaderText = "MEMO";
                    dataGridView1.Columns[26].Width = 100;
                    dataGridView1.Columns[26].Visible = false;
                    dataGridView1.Columns[27].HeaderText = "ACT";
                    dataGridView1.Columns[27].Width = 50;
                    dataGridView1.Columns[27].Visible = false;
                    dataGridView1.Columns[28].HeaderText = "EMP";
                    dataGridView1.Columns[28].Width = 50;
                    dataGridView1.Columns[28].Visible = false;
                    dataGridView1.Columns[29].HeaderText = "UPDATE STORE CODE";
                    dataGridView1.Columns[29].Width = 50;
                    dataGridView1.Columns[29].Visible = false;
                    dataGridView1.Columns[30].HeaderText = "UPDATE ID";
                    dataGridView1.Columns[30].Width = 90;
                    dataGridView1.Columns[30].Visible = false;
                    dataGridView1.Columns[31].HeaderText = "UPDATE DATE";
                    dataGridView1.Columns[31].Width = 90;
                    dataGridView1.Columns[31].DefaultCellStyle.Format = "MM/dd/yyyy h:mm:ss tt";
                    dataGridView1.Columns[31].Visible = false;
                    dataGridView1.Columns[32].Visible = false;
                    dataGridView1.Columns[33].Visible = false;

                    dataGridView1.ClearSelection();
                }
                else if (option == 1)
                {
                    dataGridView1.ReadOnly = false;
                    dataGridView1.RowTemplate.Height = 40;
                    dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont2;
                    dataGridView1.DataSource = dt;
                    dataGridView1.AllowUserToResizeRows = false;

                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "STORE CODE";
                    dataGridView1.Columns[1].Width = 40;
                    dataGridView1.Columns[1].ReadOnly = true;
                    dataGridView1.Columns[2].HeaderText = "FIRST NAME";
                    dataGridView1.Columns[2].Width = 60;
                    dataGridView1.Columns[2].ReadOnly = true;
                    dataGridView1.Columns[3].HeaderText = "LAST NAME";
                    dataGridView1.Columns[3].Width = 60;
                    dataGridView1.Columns[3].ReadOnly = true;
                    dataGridView1.Columns[4].HeaderText = "DATE OF BIRTH";
                    dataGridView1.Columns[4].Width = 65;
                    dataGridView1.Columns[4].DefaultCellStyle.Format = "MM/dd/yyyy";
                    dataGridView1.Columns[4].ReadOnly = true;
                    dataGridView1.Columns[5].HeaderText = "ADDRESS";
                    dataGridView1.Columns[5].Width = 110;
                    dataGridView1.Columns[5].ReadOnly = true;
                    dataGridView1.Columns[6].HeaderText = "CITY";
                    dataGridView1.Columns[6].Width = 90;
                    dataGridView1.Columns[6].ReadOnly = true;
                    dataGridView1.Columns[7].HeaderText = "STATE";
                    dataGridView1.Columns[7].Width = 40;
                    dataGridView1.Columns[7].ReadOnly = true;
                    dataGridView1.Columns[8].HeaderText = "ZIP CODE";
                    dataGridView1.Columns[8].Width = 40;
                    dataGridView1.Columns[8].ReadOnly = true;
                    dataGridView1.Columns[9].HeaderText = "HOME PHONE";
                    dataGridView1.Columns[9].Width = 70;
                    dataGridView1.Columns[9].ReadOnly = true;
                    dataGridView1.Columns[10].HeaderText = "CELL PHONE";
                    dataGridView1.Columns[10].Width = 70;
                    dataGridView1.Columns[10].ReadOnly = true;
                    dataGridView1.Columns[11].HeaderText = "EMAIL";
                    dataGridView1.Columns[11].Width = 100;
                    dataGridView1.Columns[11].ReadOnly = true;
                    dataGridView1.Columns[11].Visible = false;
                    dataGridView1.Columns[12].HeaderText = "MEMBER CODE";
                    dataGridView1.Columns[12].Width = 80;
                    dataGridView1.Columns[12].ReadOnly = true;
                    dataGridView1.Columns[13].HeaderText = "MEMBER TYPE";
                    dataGridView1.Columns[13].Width = 100;
                    dataGridView1.Columns[13].ReadOnly = true;
                    dataGridView1.Columns[14].HeaderText = "LICENSE NUMBER";
                    dataGridView1.Columns[14].Width = 100;
                    dataGridView1.Columns[14].ReadOnly = true;
                    dataGridView1.Columns[14].Visible = false;
                    dataGridView1.Columns[15].HeaderText = "DISCOUNT OPTION";
                    dataGridView1.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[15].DefaultCellStyle.Format = "0\\%";
                    dataGridView1.Columns[15].Width = 70;
                    dataGridView1.Columns[15].ReadOnly = true;
                    dataGridView1.Columns[15].Visible = false;
                    dataGridView1.Columns[16].HeaderText = "INITIAL MP";
                    dataGridView1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //dataGridView1.Columns[16].DefaultCellStyle.Format = "C";
                    dataGridView1.Columns[16].Width = 70;
                    dataGridView1.Columns[16].ReadOnly = true;
                    dataGridView1.Columns[16].Visible = false;
                    dataGridView1.Columns[17].HeaderText = "MEMBER POINTS";
                    dataGridView1.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //dataGridView1.Columns[17].DefaultCellStyle.Format = "C";
                    dataGridView1.Columns[17].Width = 60;
                    dataGridView1.Columns[17].ReadOnly = true;
                    dataGridView1.Columns[18].HeaderText = "START DATE";
                    dataGridView1.Columns[18].Width = 65;
                    dataGridView1.Columns[18].DefaultCellStyle.Format = "MM/dd/yyyy";
                    dataGridView1.Columns[18].Visible = false;
                    dataGridView1.Columns[18].ReadOnly = true;
                    dataGridView1.Columns[19].HeaderText = "EXPIRATION DATE";
                    dataGridView1.Columns[19].Width = 90;
                    dataGridView1.Columns[19].DefaultCellStyle.Format = "MM/dd/yyyy";
                    dataGridView1.Columns[19].ReadOnly = true;
                    dataGridView1.Columns[19].Visible = false;
                    dataGridView1.Columns[20].HeaderText = "LAST VISIT DATE";
                    dataGridView1.Columns[20].Width = 65;
                    dataGridView1.Columns[20].DefaultCellStyle.Format = "MM/dd/yyyy";
                    dataGridView1.Columns[20].Visible = false;
                    dataGridView1.Columns[20].ReadOnly = true;
                    dataGridView1.Columns[21].HeaderText = "TRNS(P)";
                    dataGridView1.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[21].Width = 60;
                    dataGridView1.Columns[21].ReadOnly = true;
                    dataGridView1.Columns[21].Visible = false;
                    dataGridView1.Columns[22].HeaderText = "TRNS(R)";
                    dataGridView1.Columns[22].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[22].Width = 60;
                    dataGridView1.Columns[22].ReadOnly = true;
                    dataGridView1.Columns[22].Visible = false;
                    dataGridView1.Columns[23].HeaderText = "TRNS(T)";
                    dataGridView1.Columns[23].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[23].Width = 60;
                    dataGridView1.Columns[23].ReadOnly = true;
                    dataGridView1.Columns[23].Visible = false;
                    dataGridView1.Columns[24].HeaderText = "TOTAL TRANSACTION AMOUNT";
                    dataGridView1.Columns[24].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[24].DefaultCellStyle.Format = "c";
                    dataGridView1.Columns[24].Width = 100;
                    dataGridView1.Columns[24].ReadOnly = true;
                    dataGridView1.Columns[24].Visible = false;
                    dataGridView1.Columns[25].HeaderText = "SCHOOL GRADUATED";
                    dataGridView1.Columns[25].Width = 100;
                    dataGridView1.Columns[25].ReadOnly = true;
                    dataGridView1.Columns[25].Visible = false;
                    dataGridView1.Columns[26].HeaderText = "MEMO";
                    dataGridView1.Columns[26].Width = 100;
                    dataGridView1.Columns[26].ReadOnly = true;
                    dataGridView1.Columns[26].Visible = false;
                    dataGridView1.Columns[27].HeaderText = "ACT";
                    dataGridView1.Columns[27].Width = 50;
                    dataGridView1.Columns[27].ReadOnly = true;
                    dataGridView1.Columns[27].Visible = false;
                    dataGridView1.Columns[28].HeaderText = "EMP";
                    dataGridView1.Columns[28].Width = 50;
                    dataGridView1.Columns[28].ReadOnly = true;
                    dataGridView1.Columns[28].Visible = false;
                    dataGridView1.Columns[29].HeaderText = "UPDATE STORE CODE";
                    dataGridView1.Columns[29].Width = 50;
                    dataGridView1.Columns[29].ReadOnly = true;
                    dataGridView1.Columns[29].Visible = false;
                    dataGridView1.Columns[30].HeaderText = "UPDATE ID";
                    dataGridView1.Columns[30].Width = 90;
                    dataGridView1.Columns[30].ReadOnly = true;
                    dataGridView1.Columns[30].Visible = false;
                    dataGridView1.Columns[31].HeaderText = "UPDATE DATE";
                    dataGridView1.Columns[31].Width = 90;
                    dataGridView1.Columns[31].DefaultCellStyle.Format = "MM/dd/yyyy h:mm:ss tt";
                    dataGridView1.Columns[31].ReadOnly = true;
                    dataGridView1.Columns[31].Visible = false;
                    dataGridView1.Columns[32].HeaderText = "PRIMARY";
                    dataGridView1.Columns[32].Width = 60;
                    dataGridView1.Columns[32].Visible = false;
                    dataGridView1.Columns[32].ReadOnly = false;
                    dataGridView1.Columns[33].HeaderText = "SELECT";
                    dataGridView1.Columns[33].Width = 60;
                    dataGridView1.Columns[33].Visible = false;
                    dataGridView1.Columns[33].ReadOnly = false;

                    dataGridView1.ClearSelection();
                }
            }
        }

        public void btnMerge_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
                return;

            //Validation
            memberCode = 0;
            memberMergingPoints = 0;
            int j = 0;
            int k = 0;
            int idxPrimary = 0;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[32].Value) == true)
                {
                    idxPrimary = i;
                    j = j + 1;
                }

                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[32].Value) == true | Convert.ToBoolean(dataGridView1.Rows[i].Cells[33].Value) == true)
                {
                    k = k + 1;
                    memberMergingPoints = memberMergingPoints + Convert.ToDouble(dataGridView1.Rows[i].Cells[17].Value);
                }
            }

            if (j == 1)
            {
                if (k > 1)
                {
                    DialogResult MyDialogResult;
                    MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "MEMBER ACCOUNT MERGING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (MyDialogResult == DialogResult.Yes)
                    {
                        if (MemberCodeCheck(Convert.ToInt64(dataGridView1.Rows[idxPrimary].Cells[12].Value)) == false)
                        {
                            MessageBox.Show("DUPLICATED MEMBER CODE ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtSearchKeyword.SelectAll();
                            txtSearchKeyword.Focus();
                            return;
                        }
                        else
                        {
                            memberCode = Convert.ToInt64(dataGridView1.Rows[idxPrimary].Cells[12].Value);
                        }

                        btnMerge.Enabled = false;

                        cmd.CommandText = "Merge_Member_Points";
                        cmd.Connection = newConn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@MemberCode", SqlDbType.BigInt).Value = memberCode;
                        cmd.Parameters.Add("@MemberMergingPoints", SqlDbType.Money).Value = memberMergingPoints;
                        cmd.Parameters.Add("@UpdateID", SqlDbType.NVarChar).Value = mgrID;
                        cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = DateTime.Now;

                        newConn.Open();
                        cmd.ExecuteNonQuery();
                        newConn.Close();

                        cmd.CommandText = "Delete_Merged_Member";
                        cmd.Connection = newConn;
                        cmd.CommandType = CommandType.StoredProcedure;

                        for (int l = 0; l < dataGridView1.RowCount; l++)
                        {
                            if (Convert.ToBoolean(dataGridView1.Rows[l].Cells[32].Value) == false && Convert.ToBoolean(dataGridView1.Rows[l].Cells[33].Value) == true)
                            {
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@MemberCode", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.Rows[l].Cells[12].Value);

                                newConn.Open();
                                cmd.ExecuteNonQuery();
                                newConn.Close();

                                //DataGridViewRow row = dataGridView1.Rows[l];
                                //this.dataGridView1.Rows.Remove(row);
                            }
                        }

                        lblNumberOfMembers.Text = Convert.ToString(dataGridView1.RowCount);

                        MessageBox.Show("SUCCESSFULLY MERGED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        rdoBtnMemberCode.Checked = true;
                        txtSearchKeyword.Text = Convert.ToString(memberCode);
                        dataGridView1.DataSource = null;
                        btnSearch_Click(null, null);
                        txtSearchKeyword.SelectAll();
                        txtSearchKeyword.Focus();
                        return;

                    }
                    else
                    {
                        txtSearchKeyword.SelectAll();
                        txtSearchKeyword.Focus();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("SELECT ACCOUNT TO MERGE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSearchKeyword.SelectAll();
                    txtSearchKeyword.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("SELECT ONLY ONE PRIMARY ACCOUNT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSearchKeyword.SelectAll();
                txtSearchKeyword.Focus();
                return;
            }
        }

        private bool MemberCodeCheck(Int64 mCode)
        {
            try
            {
                SqlCommand cmd_MemberCodeCheck = new SqlCommand("Duplicated_Member_Code_Check", newConn);
                cmd_MemberCodeCheck.CommandType = CommandType.StoredProcedure;
                cmd_MemberCodeCheck.Parameters.Add("@MemberCode", SqlDbType.BigInt).Value = mCode;
                SqlParameter MemberCodeCheck_Param = cmd_MemberCodeCheck.Parameters.Add("@CheckNum", SqlDbType.Int);
                MemberCodeCheck_Param.Direction = ParameterDirection.Output;

                newConn.Open();
                cmd_MemberCodeCheck.ExecuteNonQuery();
                newConn.Close();

                if (Convert.ToInt16(cmd_MemberCodeCheck.Parameters["@CheckNum"].Value) == 1)
                    return true;
                else
                    return false;
            }
            catch
            {
                MessageBox.Show("DB ERROR - DUPLICATED MEMBER CODE CHECKING", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                newConn.Close();
                return false;
            }
        }

        private void btnViewCustomerInfo_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                CustomerInfo customerInfoForm = new CustomerInfo();
                customerInfoForm.parentForm = this;
                customerInfoForm.ShowDialog();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
                btnViewCustomerInfo_Click(null, null);
        }

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

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (parentForm.employeeID.ToUpper() == "ADMIN" | parentForm.specialCode == parentForm.txtSpecialCode.Text.Trim().ToString().ToUpper())
            {
                if (dataGridView1.RowCount > 0)
                {
                    this.Enabled = false;

                    Excel_12.Application ReportFile;
                    Excel_12._Workbook WorkBook;
                    Excel_12._Worksheet WorkSheet;
                    //Excel_12.Range Range;

                    string MaxRow = Convert.ToString(dt.Rows.Count + 1);
                    String MaxColumn = ((String)(Convert.ToChar((dt.Columns.Count - 2) / 26 + 64).ToString() + Convert.ToChar((dt.Columns.Count - 2) % 26 + 64))).Replace('@', ' ').Trim();
                    String MaxCell = MaxColumn + MaxRow;

                    ReportFile = new Excel_12.Application();
                    ReportFile.Visible = false;

                    WorkBook = (Excel_12._Workbook)(ReportFile.Workbooks.Add("workbook"));
                    WorkSheet = (Excel_12._Worksheet)WorkBook.ActiveSheet;

                    for (int i = 0; i < dt.Columns.Count - 2; i++)
                        WorkSheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;

                    string[,] Values = new string[dt.Rows.Count, dt.Columns.Count - 2];

                    for (int i = 0; i < dt.Rows.Count; i++)
                        for (int j = 0; j < dt.Columns.Count - 2; j++)
                        {

                            Values[i, j] = dt.Rows[i][j].ToString();

                        }

                    WorkSheet.get_Range("A2", MaxCell).Value2 = Values;
                    ReportFile.Visible = true;
                    ReportFile.UserControl = true;

                    this.Enabled = true;
                }
                else
                {
                    MessageBox.Show("NO DATA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (dataGridView1.RowCount > 0)
                {
                    ExportDataGridViewTo_Excel12(dataGridView1);
                }
                else
                {
                    MessageBox.Show("NO DATA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        public static void ExportDataGridViewTo_Excel12(DataGridView myDataGridView)
        {
            try
            {
                Excel_12.Application oExcel_12 = null;                //Excel_12 Application
                Excel_12.Workbook oBook = null;                       // Excel_12 Workbook
                Excel_12.Sheets oSheetsColl = null;                   // Excel_12 Worksheets collection
                Excel_12.Worksheet oSheet = null;                     // Excel_12 Worksheet
                Excel_12.Range oRange = null;                         // Cell or Range in worksheet
                Object oMissing = System.Reflection.Missing.Value;

                // Create an instance of Excel_12.
                oExcel_12 = new Excel_12.Application();

                // Make Excel_12 visible to the user.
                oExcel_12.Visible = true;

                // Set the UserControl property so Excel_12 won't shut down.
                oExcel_12.UserControl = true;

                // System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");

                // Add a workbook.
                oBook = oExcel_12.Workbooks.Add(oMissing);

                // Get worksheets collection 
                oSheetsColl = oExcel_12.Worksheets;

                // Get Worksheet "Sheet1"
                oSheet = (Excel_12.Worksheet)oSheetsColl.get_Item("Sheet1");

                // Export titles
                for (int j = 0; j < myDataGridView.Columns.Count; j++)
                {
                    oRange = (Excel_12.Range)oSheet.Cells[1, j + 1];
                    oRange.Value2 = myDataGridView.Columns[j].HeaderText;
                }

                // Export data
                for (int i = 0; i < myDataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < myDataGridView.Columns.Count; j++)
                    {
                        oRange = (Excel_12.Range)oSheet.Cells[i + 2, j + 1];
                        oRange.Value2 = myDataGridView[j, i].Value.ToString();
                    }
                }

                // Release the variables.
                //oBook.Close(false, oMissing, oMissing);
                oBook = null;

                //oExcel_12.Quit();
                oExcel_12 = null;

                // Collect garbage.
                GC.Collect();
            }
            catch
            {
                MessageBox.Show("CAN NOT GENERATE EXCEL FILE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}