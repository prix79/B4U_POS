// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 08-25-2014
// ***********************************************************************
// <copyright file="CustomerMain.cs" company="Beauty4u">
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
    /// Class CustomerMain.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class CustomerMain : Form
    {
        /// <summary>
        /// The parent form
        /// </summary>
        public MainForm parentForm;
        /// <summary>
        /// The authentication
        /// </summary>
        public bool auth = false;
        /// <summary>
        /// The command
        /// </summary>
        public SqlCommand cmd = new SqlCommand();
        /// <summary>
        /// The dt
        /// </summary>
        public DataTable dt = new DataTable();
        /// <summary>
        /// The DRV font
        /// </summary>
        public Font drvFont = new Font("Arial", 10, FontStyle.Bold);

        /// <summary>
        /// The member code
        /// </summary>
        Int64 memberCode;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerMain"/> class.
        /// </summary>
        public CustomerMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the CustomerMain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void CustomerMain_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the btnLoadingAllCustomer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnLoadingAllCustomer_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "Show_Customers";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = parentForm.conn;
            cmd.Parameters.Clear();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            dt.Clear();
            adapt.Fill(dt);
            parentForm.conn.Close();

            BindingData();

            txtSearchKeyword.Clear();
            txtSearchKeyword.Select();
            txtSearchKeyword.Focus();

            lblNumberOfMembers.Text = dataGridView1.RowCount.ToString();
        }

        /// <summary>
        /// Handles the Click event of the btnSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnSearch_Click(object sender, EventArgs e)
        {
            if (rdoBtnFirstName.Checked == true)
            {
                cmd.CommandText = "Show_Customer_With_Keyword";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = parentForm.conn;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Index", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = txtSearchKeyword.Text.ToUpper() + "%";
                SqlDataAdapter adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                parentForm.conn.Open();
                dt.Clear();
                adapt.Fill(dt);
                parentForm.conn.Close();

                BindingData();
            }
            else if (rdoBtnLastName.Checked == true)
            {
                cmd.CommandText = "Show_Customer_With_Keyword";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = parentForm.conn;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Index", SqlDbType.Int).Value = 2;
                cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = txtSearchKeyword.Text.ToUpper() + "%";
                SqlDataAdapter adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                parentForm.conn.Open();
                dt.Clear();
                adapt.Fill(dt);
                parentForm.conn.Close();

                BindingData();
            }
            else if (rdoBtnHomePhone.Checked == true)
            {
                cmd.CommandText = "Show_Customer_With_Keyword";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = parentForm.conn;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Index", SqlDbType.Int).Value = 3;
                cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = txtSearchKeyword.Text.ToUpper() + "%";
                SqlDataAdapter adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                parentForm.conn.Open();
                dt.Clear();
                adapt.Fill(dt);
                parentForm.conn.Close();

                BindingData();
            }
            else if (rdoBtnCellPhone.Checked == true)
            {
                cmd.CommandText = "Show_Customer_With_Keyword";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = parentForm.conn;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Index", SqlDbType.Int).Value = 4;
                cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = txtSearchKeyword.Text.ToUpper() + "%";
                SqlDataAdapter adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                parentForm.conn.Open();
                dt.Clear();
                adapt.Fill(dt);
                parentForm.conn.Close();

                BindingData();
            }
            else if (rdoBtnMemberCode.Checked == true)
            {
                if (Int64.TryParse(txtSearchKeyword.Text, out memberCode))
                {
                    cmd.CommandText = "Show_Customer_With_Keyword";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = parentForm.conn;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@Index", SqlDbType.Int).Value = 5;
                    cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = Convert.ToString(memberCode);
                    SqlDataAdapter adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd;

                    parentForm.conn.Open();
                    dt.Clear();
                    adapt.Fill(dt);
                    parentForm.conn.Close();

                    BindingData();
                }
                else
                {
                    MyMessageBox.ShowBox("INPUT VALID MEMBER CODE", "ERROR");
                    txtSearchKeyword.SelectAll();
                    txtSearchKeyword.Focus();
                    return;
                }
            }

            lblNumberOfMembers.Text = Convert.ToString(dataGridView1.RowCount);
        }

        /// <summary>
        /// Handles the Click event of the btnRegisterNewCustomer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnRegisterNewCustomer_Click(object sender, EventArgs e)
        {
            RegisterNewCustomer registerNewCustomerForm = new RegisterNewCustomer();
            registerNewCustomerForm.parentForm = this.parentForm;
            //registerNewCustomerForm.parentForm2 = this;
            registerNewCustomerForm.ShowDialog();
        }

        /// <summary>
        /// Handles the Click event of the btnUpdateCustomer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                int j = 0;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Selected == true)
                    {
                        j = j + 1;
                    }
                }

                if (j > 0)
                {
                    if (Convert.ToString(dataGridView1.SelectedCells[13].Value) == "VVIP STORE MEMBER" | Convert.ToString(dataGridView1.SelectedCells[13].Value) == "VVIP BEAUTICIAN")
                    {
                        MyMessageBox.ShowBox("NOT AUTHORIZED ON THE REGISTER", "ERROR");
                        return;
                    }
                    else
                    {
                        if (auth == true)
                        {
                            UpdateCustomer updateCustomerForm = new UpdateCustomer();
                            updateCustomerForm.parentForm1 = this.parentForm;
                            //updateCustomerForm.parentForm2 = this;
                            updateCustomerForm.ShowDialog();
                        }
                        else
                        {
                            Authentication authenticationForm = new Authentication(4);
                            authenticationForm.parentForm1 = this.parentForm;
                            //authenticationForm.parentForm3 = this;
                            authenticationForm.ShowDialog();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSelectCustomer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSelectCustomer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                if (parentForm.dataGridView1.RowCount > 0)
                {
                    MyMessageBox.ShowBox("INPUT MEMBER CODE BEFORE TRANSACTION START", "ERROR");
                    return;
                }
                else
                {
                    parentForm.Enabled = true;
                    parentForm.radioBtnMember.Checked = true;
                    parentForm.txtMemberID.Text = Convert.ToString(dataGridView1.SelectedCells[12].Value);
                    //parentForm.Calculating_Saved_Amount();
                    this.Close();
                    parentForm.richTxtUpc.Select();
                    parentForm.richTxtUpc.Focus();
                }
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnDeleteCustomer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                int j = 0;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Selected == true)
                    {
                        j = j + 1;
                    }
                }

                if (j > 0)
                {
                    if (Convert.ToString(dataGridView1.SelectedCells[13].Value) == "VVIP STORE MEMBER" | Convert.ToString(dataGridView1.SelectedCells[13].Value) == "VVIP BEAUTICIAN")
                    {
                        MyMessageBox.ShowBox("NOT AUTHORIZED ON THE REGISTER", "ERROR");
                        return;
                    }
                    else
                    {
                        if (auth == true)
                        {
                            DialogResult MyDialogResult;
                            MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (MyDialogResult == DialogResult.Yes)
                            {
                                cmd.CommandText = "Delete_Customer";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = parentForm.conn;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@CustomerNo", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.SelectedCells[0].Value);

                                parentForm.conn.Open();
                                cmd.ExecuteNonQuery();
                                parentForm.conn.Close();

                                btnSearch_Click(null, null);
                            }
                        }
                        else
                        {
                            Authentication authenticationForm = new Authentication(18);
                            authenticationForm.parentForm1 = this.parentForm;
                            //authenticationForm.parentForm3 = this;
                            authenticationForm.ShowDialog();
                        }
                    }
                }
                else
                {
                    MyMessageBox.ShowBox("SELECT CUSTOMER", "ERROR");
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
            parentForm.Enabled = true;
            this.Close();
            parentForm.richTxtUpc.Select();
            parentForm.richTxtUpc.Focus();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the rdoBtnFirstName control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rdoBtnFirstName_CheckedChanged(object sender, EventArgs e)
        {
            txtSearchKeyword.Select();
            txtSearchKeyword.Focus();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the rdoBtnHomePhone control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rdoBtnHomePhone_CheckedChanged(object sender, EventArgs e)
        {
            txtSearchKeyword.Select();
            txtSearchKeyword.Focus();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the rdoBtnMemberCode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rdoBtnMemberCode_CheckedChanged(object sender, EventArgs e)
        {
            txtSearchKeyword.Select();
            txtSearchKeyword.Focus();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the rdoBtnLastName control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rdoBtnLastName_CheckedChanged(object sender, EventArgs e)
        {
            txtSearchKeyword.Select();
            txtSearchKeyword.Focus();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the rdoBtnCellPhone control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rdoBtnCellPhone_CheckedChanged(object sender, EventArgs e)
        {
            txtSearchKeyword.Select();
            txtSearchKeyword.Focus();
        }

        /// <summary>
        /// Bindings the data.
        /// </summary>
        private void BindingData()
        {
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "STORE CODE";
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = "FIRST NAME";
            dataGridView1.Columns[2].Width = 130;
            dataGridView1.Columns[3].HeaderText = "LAST NAME";
            dataGridView1.Columns[3].Width = 130;
            dataGridView1.Columns[4].HeaderText = "DATE OF BIRTH";
            dataGridView1.Columns[4].Width = 90;
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
            dataGridView1.Columns[16].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[16].Width = 70;
            dataGridView1.Columns[17].HeaderText = "MEMBER POINTS";
            dataGridView1.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[17].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[17].Width = 70;
            dataGridView1.Columns[18].HeaderText = "START DATE";
            dataGridView1.Columns[18].Width = 90;
            dataGridView1.Columns[19].HeaderText = "EXPIRATION DATE";
            dataGridView1.Columns[19].Width = 90;
            dataGridView1.Columns[20].HeaderText = "LAST VISIT DATE";
            dataGridView1.Columns[20].Width = 90;
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
            dataGridView1.Columns[27].HeaderText = "ACTIVE";
            dataGridView1.Columns[27].Width = 50;
        }
    }
}