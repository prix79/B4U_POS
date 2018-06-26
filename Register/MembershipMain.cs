// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 02-06-2018
// ***********************************************************************
// <copyright file="MembershipMain.cs" company="Beauty4u">
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
    /// Class MembershipMain.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class MembershipMain : Form
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
        public Font drvFont = new Font("Arial", 9, FontStyle.Bold);
        /// <summary>
        /// The DRV font2
        /// </summary>
        public Font drvFont2 = new Font("Arial", 8, FontStyle.Bold);

        /// <summary>
        /// The member code
        /// </summary>
        Int64 memberCode;

        /// <summary>
        /// The opt
        /// </summary>
        int opt = 0;

        /// <summary>
        /// The MGR identifier
        /// </summary>
        public string mgrID;
        /// <summary>
        /// The member merging points
        /// </summary>
        double memberMergingPoints = 0;

        /// <summary>
        /// The member transaction authentication
        /// </summary>
        public bool MemberTransactionAuth = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="MembershipMain"/> class.
        /// </summary>
        public MembershipMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the MembershipMain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MembershipMain_Load(object sender, EventArgs e)
        {
            if (DBConnectionStatus(parentForm.parentForm.B4UHQCS) == false)
            {
                MyMessageBox.ShowBox("MEMBERSHIP DB CONNECTION FAILED", "ERROR");
                groupBox1.Enabled = false;
                btnRegisterNewCustomer.Enabled = false;
                btnLoadingAllCustomer.Enabled = false;
                btnDeleteCustomer.Enabled = false;
                btnUpdateCustomer.Enabled = false;
                btnSelectCustomer.Enabled = false;
            }
            else
            {
                txtSearchKeyword.Select();
                txtSearchKeyword.Focus();

                //btnMerge.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdoBtnFirstName.Checked == true)
                {
                    cmd.CommandText = "Show_Member_With_Keyword";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = parentForm.connHQ;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@Index", SqlDbType.Int).Value = 1;
                    cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = txtSearchKeyword.Text.ToUpper() + "%";
                    SqlDataAdapter adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd;

                    parentForm.connHQ.Open();
                    dt.Clear();
                    adapt.Fill(dt);
                    parentForm.connHQ.Close();

                    BindingData(0);

                    if (dataGridView1.RowCount == 1)
                        dataGridView1.Rows[0].Selected = true;

                    btnMerge.Enabled = false;
                }
                else if (rdoBtnLastName.Checked == true)
                {
                    cmd.CommandText = "Show_Member_With_Keyword";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = parentForm.connHQ;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@Index", SqlDbType.Int).Value = 2;
                    cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = txtSearchKeyword.Text.ToUpper() + "%";
                    SqlDataAdapter adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd;

                    parentForm.connHQ.Open();
                    dt.Clear();
                    adapt.Fill(dt);
                    parentForm.connHQ.Close();

                    BindingData(0);

                    if (dataGridView1.RowCount == 1)
                        dataGridView1.Rows[0].Selected = true;

                    btnMerge.Enabled = false;
                }
                else if (rdoBtnHomePhone.Checked == true)
                {
                    cmd.CommandText = "Show_Member_With_Keyword";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = parentForm.connHQ;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@Index", SqlDbType.Int).Value = 3;
                    cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = txtSearchKeyword.Text.ToUpper() + "%";
                    SqlDataAdapter adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd;

                    parentForm.connHQ.Open();
                    dt.Clear();
                    adapt.Fill(dt);
                    parentForm.connHQ.Close();

                    BindingData(1);

                    if (dataGridView1.RowCount == 1)
                        dataGridView1.Rows[0].Selected = true;

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
                    cmd.Connection = parentForm.connHQ;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@Index", SqlDbType.Int).Value = 4;
                    cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = txtSearchKeyword.Text.ToUpper() + "%";
                    SqlDataAdapter adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd;

                    parentForm.connHQ.Open();
                    dt.Clear();
                    adapt.Fill(dt);
                    parentForm.connHQ.Close();

                    BindingData(1);

                    if (dataGridView1.RowCount == 1)
                        dataGridView1.Rows[0].Selected = true;

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
                        cmd.Connection = parentForm.connHQ;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@Index", SqlDbType.Int).Value = 5;
                        cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = Convert.ToString(memberCode);
                        SqlDataAdapter adapt = new SqlDataAdapter();
                        adapt.SelectCommand = cmd;

                        parentForm.connHQ.Open();
                        dt.Clear();
                        adapt.Fill(dt);
                        parentForm.connHQ.Close();

                        BindingData(0);

                        if (dataGridView1.RowCount == 1)
                            dataGridView1.Rows[0].Selected = true;

                        btnMerge.Enabled = false;
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
                txtSearchKeyword.SelectAll();
                txtSearchKeyword.Focus();
            }
            catch
            {
                MyMessageBox.ShowBox("CONNECTION FAILED", "ERROR");
                parentForm.connHQ.Close();
                txtSearchKeyword.SelectAll();
                txtSearchKeyword.Focus();
                return;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnLoadingAllCustomer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnLoadingAllCustomer_Click(object sender, EventArgs e)
        {
            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "IT MAY TAKE A LOT OF TIME DEPENDS ON THE INTERNET CONNECTION.\n\n" + "ARE YOU SURE TO PROCEED?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
            {
                this.Enabled = false;

                cmd.CommandText = "Show_All_Members";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = parentForm.connHQ;
                cmd.Parameters.Clear();
                SqlDataAdapter adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                parentForm.connHQ.Open();
                dt.Clear();
                adapt.Fill(dt);
                parentForm.connHQ.Close();

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

        /// <summary>
        /// Handles the Click event of the btnRegisterNewCustomer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnRegisterNewCustomer_Click(object sender, EventArgs e)
        {
            RegisterNewCustomer registerNewCustomerForm = new RegisterNewCustomer();
            registerNewCustomerForm.parentForm = this.parentForm;
            registerNewCustomerForm.parentForm2 = this;
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
                this.Enabled = false;

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
                        this.Enabled = true;
                        return;
                    }
                    else
                    {
                        if (auth == true)
                        {
                            this.Enabled = true;

                            UpdateCustomer updateCustomerForm = new UpdateCustomer();
                            updateCustomerForm.parentForm1 = this.parentForm;
                            updateCustomerForm.parentForm2 = this;
                            updateCustomerForm.ShowDialog();
                        }
                        else
                        {
                            this.Enabled = true;

                            Authentication authenticationForm = new Authentication(4);
                            authenticationForm.parentForm1 = this.parentForm;
                            authenticationForm.parentForm3 = this;
                            authenticationForm.ShowDialog();
                        }
                    }
                }
                else
                {
                    MyMessageBox.ShowBox("SELECT MEMBER", "ERROR");
                    this.Enabled = true;

                    txtSearchKeyword.SelectAll();
                    txtSearchKeyword.Focus();
                }
            }
            else
            {
                txtSearchKeyword.SelectAll();
                txtSearchKeyword.Focus();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSelectCustomer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnSelectCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.RowCount > 0)
                {
                    parentForm.btnDefault_Click(null, null);

                    if (parentForm.dataGridView1.RowCount > 0)
                    {
                        if (Convert.ToString(dataGridView1.SelectedCells[13].Value) != parentForm.MType1)
                        {
                            MyMessageBox.ShowBox("BEAUTICIAN/VIP/VVIP MEMBERS MUST BE SCANNED FIRST", "ERROR");
                            txtSearchKeyword.SelectAll();
                            txtSearchKeyword.Focus();
                            return;
                        }
                        else
                        {
                            if (Convert.ToString(dataGridView1.SelectedCells[1].Value).ToUpper() != parentForm.storeCode && Convert.ToString(dataGridView1.SelectedCells[13].Value) == parentForm.MType5)
                            {
                                MyMessageBox.ShowBox("BASE STORE ONLY FOR STORE EMPLOYEE DISCOUNT ", "ERROR");
                                txtSearchKeyword.SelectAll();
                                txtSearchKeyword.Focus();
                                return;
                            }
                            else
                            {
                                if (Get_NumberOfTransactionByMember(Convert.ToString(dataGridView1.SelectedCells[12].Value)) >= 3)
                                {
                                    if (MemberTransactionAuth == true)
                                    {
                                        int mYear = (Convert.ToDateTime(dataGridView1.SelectedCells[4].Value).AddYears(parentForm.BithdayMinimumAge)).Year;

                                        if (mYear <= DateTime.Today.Year)
                                        {
                                            if (Convert.ToDateTime(dataGridView1.SelectedCells[4].Value).Month == DateTime.Today.Month & Convert.ToDateTime(dataGridView1.SelectedCells[4].Value).Day == DateTime.Today.Day)
                                            {
                                                BirthdayMessage birthdayMessageForm = new BirthdayMessage();
                                                birthdayMessageForm.ShowDialog();
                                            }
                                        }

                                        parentForm.Enabled = true;
                                        parentForm.radioBtnMember.Checked = true;
                                        parentForm.txtMemberID.Text = Convert.ToString(dataGridView1.SelectedCells[12].Value);
                                        //parentForm.Calculating_Saved_Amount();
                                        parentForm.lblMemberCode.Text = Convert.ToString(dataGridView1.SelectedCells[12].Value);
                                        parentForm.lblName.Text = Convert.ToString(dataGridView1.SelectedCells[2].Value) + " " + Convert.ToString(dataGridView1.SelectedCells[3].Value);
                                        parentForm.lblType.Text = Convert.ToString(dataGridView1.SelectedCells[13].Value);
                                        parentForm.CtmPoint = Convert.ToDouble(dataGridView1.SelectedCells[17].Value);
                                        parentForm.lblPoints.Text = string.Format("{0:$0.00}", Math.Round(parentForm.CtmPoint, 2, MidpointRounding.AwayFromZero));

                                        if (Convert.ToDateTime(dataGridView1.SelectedCells[18].Value).AddDays(parentForm.SecondVisitValidDays) >= DateTime.Today)
                                        {
                                            parentForm.PTrns = Convert.ToInt16(dataGridView1.SelectedCells[21].Value);
                                            parentForm.TTrns = Convert.ToInt16(dataGridView1.SelectedCells[23].Value);
                                        }
                                        else
                                        {
                                            parentForm.PTrns = 0;
                                            parentForm.TTrns = 0;
                                        }

                                        parentForm.LineDisply("MEMBER: " + parentForm.lblMemberCode.Text, "POINTS: " + parentForm.lblPoints.Text);
                                        this.Close();
                                        parentForm.richTxtUpc.Select();
                                        parentForm.richTxtUpc.Focus();
                                    }
                                    else
                                    {
                                        MyMessageBox.ShowBox("THIS MEMBER ALREADY MADE MORE THAN 3 TRANSACTIONS TODAY.\n" + "PLEASE PASS THE AUTHENTICATION BY MANAGER.", "WARNING");

                                        Authentication authenticationForm = new Authentication(22);
                                        authenticationForm.parentForm1 = this.parentForm;
                                        authenticationForm.parentForm3 = this;
                                        authenticationForm.ShowDialog();
                                    }
                                }
                                else
                                {
                                    int mYear = (Convert.ToDateTime(dataGridView1.SelectedCells[4].Value).AddYears(parentForm.BithdayMinimumAge)).Year;

                                    if (mYear <= DateTime.Today.Year)
                                    {
                                        if (Convert.ToDateTime(dataGridView1.SelectedCells[4].Value).Month == DateTime.Today.Month & Convert.ToDateTime(dataGridView1.SelectedCells[4].Value).Day == DateTime.Today.Day)
                                        {
                                            BirthdayMessage birthdayMessageForm = new BirthdayMessage();
                                            birthdayMessageForm.ShowDialog();
                                        }
                                    }

                                    parentForm.Enabled = true;
                                    parentForm.radioBtnMember.Checked = true;
                                    parentForm.txtMemberID.Text = Convert.ToString(dataGridView1.SelectedCells[12].Value);
                                    //parentForm.Calculating_Saved_Amount();
                                    parentForm.lblMemberCode.Text = Convert.ToString(dataGridView1.SelectedCells[12].Value);
                                    parentForm.lblName.Text = Convert.ToString(dataGridView1.SelectedCells[2].Value) + " " + Convert.ToString(dataGridView1.SelectedCells[3].Value);
                                    parentForm.lblType.Text = Convert.ToString(dataGridView1.SelectedCells[13].Value);
                                    parentForm.CtmPoint = Convert.ToDouble(dataGridView1.SelectedCells[17].Value);
                                    parentForm.lblPoints.Text = string.Format("{0:$0.00}", Math.Round(parentForm.CtmPoint, 2, MidpointRounding.AwayFromZero));

                                    if (Convert.ToDateTime(dataGridView1.SelectedCells[18].Value).AddDays(parentForm.SecondVisitValidDays) >= DateTime.Today)
                                    {
                                        parentForm.PTrns = Convert.ToInt16(dataGridView1.SelectedCells[21].Value);
                                        parentForm.TTrns = Convert.ToInt16(dataGridView1.SelectedCells[23].Value);
                                    }
                                    else
                                    {
                                        parentForm.PTrns = 0;
                                        parentForm.TTrns = 0;
                                    }

                                    parentForm.LineDisply("MEMBER: " + parentForm.lblMemberCode.Text, "POINTS: " + parentForm.lblPoints.Text);
                                    this.Close();
                                    parentForm.richTxtUpc.Select();
                                    parentForm.richTxtUpc.Focus();
                                }
                            }
                        }
                    }
                    else
                    {
                        if (Convert.ToString(dataGridView1.SelectedCells[1].Value).ToUpper() != parentForm.storeCode && Convert.ToString(dataGridView1.SelectedCells[13].Value) == parentForm.MType5)
                        {
                            MyMessageBox.ShowBox("BASE STORE ONLY FOR STORE EMPLOYEE DISCOUNT ", "ERROR");
                            txtSearchKeyword.SelectAll();
                            txtSearchKeyword.Focus();
                            return;
                        }
                        else
                        {
                            if (Get_NumberOfTransactionByMember(Convert.ToString(dataGridView1.SelectedCells[12].Value)) >= 3)
                            {
                                if (MemberTransactionAuth == true)
                                {
                                    int mYear = (Convert.ToDateTime(dataGridView1.SelectedCells[4].Value).AddYears(parentForm.BithdayMinimumAge)).Year;

                                    if (mYear <= DateTime.Today.Year)
                                    {
                                        if (Convert.ToDateTime(dataGridView1.SelectedCells[4].Value).Month == DateTime.Today.Month & Convert.ToDateTime(dataGridView1.SelectedCells[4].Value).Day == DateTime.Today.Day)
                                        {
                                            BirthdayMessage birthdayMessageForm = new BirthdayMessage();
                                            birthdayMessageForm.ShowDialog();
                                        }
                                    }

                                    parentForm.Enabled = true;
                                    parentForm.radioBtnMember.Checked = true;
                                    parentForm.txtMemberID.Text = Convert.ToString(dataGridView1.SelectedCells[12].Value);
                                    //parentForm.Calculating_Saved_Amount();
                                    parentForm.lblMemberCode.Text = Convert.ToString(dataGridView1.SelectedCells[12].Value);
                                    parentForm.lblName.Text = Convert.ToString(dataGridView1.SelectedCells[2].Value) + " " + Convert.ToString(dataGridView1.SelectedCells[3].Value);
                                    parentForm.lblType.Text = Convert.ToString(dataGridView1.SelectedCells[13].Value);
                                    parentForm.CtmPoint = Convert.ToDouble(dataGridView1.SelectedCells[17].Value);
                                    parentForm.lblPoints.Text = string.Format("{0:$0.00}", Math.Round(parentForm.CtmPoint, 2, MidpointRounding.AwayFromZero));

                                    if (Convert.ToDateTime(dataGridView1.SelectedCells[18].Value).AddDays(parentForm.SecondVisitValidDays) >= DateTime.Today)
                                    {
                                        parentForm.PTrns = Convert.ToInt16(dataGridView1.SelectedCells[21].Value);
                                        parentForm.TTrns = Convert.ToInt16(dataGridView1.SelectedCells[23].Value);
                                    }
                                    else
                                    {
                                        parentForm.PTrns = 0;
                                        parentForm.TTrns = 0;
                                    }

                                    parentForm.LineDisply("MEMBER: " + parentForm.lblMemberCode.Text, "POINTS: " + parentForm.lblPoints.Text);
                                    this.Close();
                                    parentForm.richTxtUpc.Select();
                                    parentForm.richTxtUpc.Focus();
                                }
                                else
                                {
                                    MyMessageBox.ShowBox("THIS MEMBER ALREADY MADE MORE THAN 3 TRANSACTIONS TODAY.\n" + "PLEASE PASS THE AUTHENTICATION BY MANAGER.", "WARNING");

                                    Authentication authenticationForm = new Authentication(22);
                                    authenticationForm.parentForm1 = this.parentForm;
                                    authenticationForm.parentForm3 = this;
                                    authenticationForm.ShowDialog();
                                }
                            }
                            else
                            {
                                int mYear = (Convert.ToDateTime(dataGridView1.SelectedCells[4].Value).AddYears(parentForm.BithdayMinimumAge)).Year;

                                if (mYear <= DateTime.Today.Year)
                                {
                                    if (Convert.ToDateTime(dataGridView1.SelectedCells[4].Value).Month == DateTime.Today.Month & Convert.ToDateTime(dataGridView1.SelectedCells[4].Value).Day == DateTime.Today.Day)
                                    {
                                        BirthdayMessage birthdayMessageForm = new BirthdayMessage();
                                        birthdayMessageForm.ShowDialog();
                                    }
                                }

                                parentForm.Enabled = true;
                                parentForm.radioBtnMember.Checked = true;
                                parentForm.txtMemberID.Text = Convert.ToString(dataGridView1.SelectedCells[12].Value);
                                //parentForm.Calculating_Saved_Amount();
                                parentForm.lblMemberCode.Text = Convert.ToString(dataGridView1.SelectedCells[12].Value);
                                parentForm.lblName.Text = Convert.ToString(dataGridView1.SelectedCells[2].Value) + " " + Convert.ToString(dataGridView1.SelectedCells[3].Value);
                                parentForm.lblType.Text = Convert.ToString(dataGridView1.SelectedCells[13].Value);
                                parentForm.CtmPoint = Convert.ToDouble(dataGridView1.SelectedCells[17].Value);
                                parentForm.lblPoints.Text = string.Format("{0:$0.00}", Math.Round(parentForm.CtmPoint, 2, MidpointRounding.AwayFromZero));

                                if (Convert.ToDateTime(dataGridView1.SelectedCells[18].Value).AddDays(parentForm.SecondVisitValidDays) >= DateTime.Today)
                                {
                                    parentForm.PTrns = Convert.ToInt16(dataGridView1.SelectedCells[21].Value);
                                    parentForm.TTrns = Convert.ToInt16(dataGridView1.SelectedCells[23].Value);
                                }
                                else
                                {
                                    parentForm.PTrns = 0;
                                    parentForm.TTrns = 0;
                                }

                                parentForm.LineDisply("MEMBER: " + parentForm.lblMemberCode.Text, "POINTS: " + parentForm.lblPoints.Text);
                                this.Close();
                                parentForm.richTxtUpc.Select();
                                parentForm.richTxtUpc.Focus();
                            }
                        }
                    }
                }
                else
                {
                    txtSearchKeyword.SelectAll();
                    txtSearchKeyword.Focus();
                    return;
                }
            }
            catch
            {
                MyMessageBox.ShowBox("MEMBER SELECT ERROR", "ERROR");
                txtSearchKeyword.SelectAll();
                txtSearchKeyword.Focus();
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
                                cmd.CommandText = "Delete_Member";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = parentForm.connHQ;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@MemberSeqNo", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.SelectedCells[0].Value);

                                parentForm.connHQ.Open();
                                cmd.ExecuteNonQuery();
                                parentForm.connHQ.Close();

                                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                                {
                                    this.dataGridView1.Rows.Remove(item);
                                }

                                lblNumberOfMembers.Text = Convert.ToString(dataGridView1.RowCount);
                            }
                        }
                        else
                        {
                            Authentication authenticationForm = new Authentication(18);
                            authenticationForm.parentForm1 = this.parentForm;
                            authenticationForm.parentForm3 = this;
                            authenticationForm.ShowDialog();
                        }
                    }
                }
                else
                {
                    MyMessageBox.ShowBox("SELECT MEMBER", "ERROR");
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

        /*private void MembershipMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            parentForm.Enabled = true;
            this.Close();
            parentForm.richTxtUpc.Select();
            parentForm.richTxtUpc.Focus();
        }*/

        /// <summary>
        /// Handles the CheckedChanged event of the rdoBtnFirstName control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rdoBtnFirstName_CheckedChanged(object sender, EventArgs e)
        {
            rdoBtnHomePhone.BackColor = Color.DarkSeaGreen;
            rdoBtnCellPhone.BackColor = Color.DarkSeaGreen;
            rdoBtnFirstName.BackColor = Color.Green;
            rdoBtnLastName.BackColor = Color.DarkSeaGreen;
            rdoBtnMemberCode.BackColor = Color.DarkSeaGreen;

            txtSearchKeyword.SelectAll();
            txtSearchKeyword.Focus();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the rdoBtnHomePhone control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rdoBtnHomePhone_CheckedChanged(object sender, EventArgs e)
        {
            rdoBtnHomePhone.BackColor = Color.Green;
            rdoBtnCellPhone.BackColor = Color.DarkSeaGreen;
            rdoBtnFirstName.BackColor = Color.DarkSeaGreen;
            rdoBtnLastName.BackColor = Color.DarkSeaGreen;
            rdoBtnMemberCode.BackColor = Color.DarkSeaGreen;

            txtSearchKeyword.SelectAll();
            txtSearchKeyword.Focus();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the rdoBtnMemberCode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rdoBtnMemberCode_CheckedChanged(object sender, EventArgs e)
        {
            rdoBtnHomePhone.BackColor = Color.DarkSeaGreen;
            rdoBtnCellPhone.BackColor = Color.DarkSeaGreen;
            rdoBtnFirstName.BackColor = Color.DarkSeaGreen;
            rdoBtnLastName.BackColor = Color.DarkSeaGreen;
            rdoBtnMemberCode.BackColor = Color.Green;

            txtSearchKeyword.SelectAll();
            txtSearchKeyword.Focus();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the rdoBtnLastName control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rdoBtnLastName_CheckedChanged(object sender, EventArgs e)
        {
            rdoBtnHomePhone.BackColor = Color.DarkSeaGreen;
            rdoBtnCellPhone.BackColor = Color.DarkSeaGreen;
            rdoBtnFirstName.BackColor = Color.DarkSeaGreen;
            rdoBtnLastName.BackColor = Color.Green;
            rdoBtnMemberCode.BackColor = Color.DarkSeaGreen;

            txtSearchKeyword.SelectAll();
            txtSearchKeyword.Focus();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the rdoBtnCellPhone control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rdoBtnCellPhone_CheckedChanged(object sender, EventArgs e)
        {
            rdoBtnHomePhone.BackColor = Color.DarkSeaGreen;
            rdoBtnCellPhone.BackColor = Color.Green;
            rdoBtnFirstName.BackColor = Color.DarkSeaGreen;
            rdoBtnLastName.BackColor = Color.DarkSeaGreen;
            rdoBtnMemberCode.BackColor = Color.DarkSeaGreen;

            txtSearchKeyword.SelectAll();
            txtSearchKeyword.Focus();
        }

        /// <summary>
        /// Bindings the data.
        /// </summary>
        /// <param name="option">The option.</param>
        private void BindingData(int option)
        {
            opt = option;

            dataGridView1.DataSource = null;

            if (parentForm.employeeLevel > 6)
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

        /// <summary>
        /// Handles the Click event of the btnMerge control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnMerge_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
                return;

            if (auth == true)
            {
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
                                MyMessageBox.ShowBox("DUPLICATED MEMBER CODE ", "ERROR");
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
                            cmd.Connection = parentForm.connHQ;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@MemberCode", SqlDbType.BigInt).Value = memberCode;
                            cmd.Parameters.Add("@MemberMergingPoints", SqlDbType.Money).Value = memberMergingPoints;
                            cmd.Parameters.Add("@UpdateID", SqlDbType.NVarChar).Value = mgrID;
                            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = DateTime.Now;

                            parentForm.connHQ.Open();
                            cmd.ExecuteNonQuery();
                            parentForm.connHQ.Close();

                            cmd.CommandText = "Delete_Merged_Member";
                            cmd.Connection = parentForm.connHQ;
                            cmd.CommandType = CommandType.StoredProcedure;

                            for (int l = 0; l < dataGridView1.RowCount; l++)
                            {
                                if (Convert.ToBoolean(dataGridView1.Rows[l].Cells[32].Value) == false && Convert.ToBoolean(dataGridView1.Rows[l].Cells[33].Value) == true)
                                {
                                    cmd.Parameters.Clear();
                                    cmd.Parameters.Add("@MemberCode", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.Rows[l].Cells[12].Value);

                                    parentForm.connHQ.Open();
                                    cmd.ExecuteNonQuery();
                                    parentForm.connHQ.Close();

                                    //DataGridViewRow row = dataGridView1.Rows[l];
                                    //this.dataGridView1.Rows.Remove(row);
                                }
                            }

                            lblNumberOfMembers.Text = Convert.ToString(dataGridView1.RowCount);

                            MyMessageBox.ShowBox("SUCCESSFULLY MERGED", "INFORMATION");
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
                        MyMessageBox.ShowBox("SELECT ACCOUNT TO MERGE", "ERROR");
                        txtSearchKeyword.SelectAll();
                        txtSearchKeyword.Focus();
                        return;
                    }
                }
                else
                {
                    MyMessageBox.ShowBox("SELECT ONLY ONE PRIMARY ACCOUNT", "ERROR");
                    txtSearchKeyword.SelectAll();
                    txtSearchKeyword.Focus();
                    return;
                }
            }
            else
            {
                Authentication authenticationForm = new Authentication(20);
                authenticationForm.parentForm1 = this.parentForm;
                authenticationForm.parentForm3 = this;
                authenticationForm.ShowDialog();
            }
        }

        /// <summary>
        /// Members the code check.
        /// </summary>
        /// <param name="mCode">The m code.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool MemberCodeCheck(Int64 mCode)
        {
            try
            {
                SqlCommand cmd_MemberCodeCheck = new SqlCommand("Duplicated_Member_Code_Check", parentForm.connHQ);
                cmd_MemberCodeCheck.CommandType = CommandType.StoredProcedure;
                cmd_MemberCodeCheck.Parameters.Add("@MemberCode", SqlDbType.BigInt).Value = mCode;
                SqlParameter MemberCodeCheck_Param = cmd_MemberCodeCheck.Parameters.Add("@CheckNum", SqlDbType.Int);
                MemberCodeCheck_Param.Direction = ParameterDirection.Output;

                parentForm.connHQ.Open();
                cmd_MemberCodeCheck.ExecuteNonQuery();
                parentForm.connHQ.Close();

                if (Convert.ToInt16(cmd_MemberCodeCheck.Parameters["@CheckNum"].Value) == 1)
                    return true;
                else
                    return false;
            }
            catch
            {
                MyMessageBox.ShowBox("DB ERROR - DUPLICATED MEMBER CODE CHECKING", "ERROR");
                parentForm.connHQ.Close();
                return false;
            }
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

        /// <summary>
        /// Gets the number of transaction by member.
        /// </summary>
        /// <param name="mID">The m identifier.</param>
        /// <returns>System.Int32.</returns>
        private int Get_NumberOfTransactionByMember(string mID)
        {
            SqlCommand cmd_MemberTransactionCheck = new SqlCommand("Get_NumberOfTransactionByMember", parentForm.conn);
            cmd_MemberTransactionCheck.CommandType = CommandType.StoredProcedure;
            cmd_MemberTransactionCheck.Parameters.Add("@MemberID", SqlDbType.NVarChar).Value = mID;
            cmd_MemberTransactionCheck.Parameters.Add("@Date", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Now); ;
            SqlParameter TransactionCount_Param = cmd_MemberTransactionCheck.Parameters.Add("@Number", SqlDbType.Int);
            TransactionCount_Param.Direction = ParameterDirection.Output;

            parentForm.conn.Open();
            cmd_MemberTransactionCheck.ExecuteNonQuery();
            parentForm.conn.Close();

            if (cmd_MemberTransactionCheck.Parameters["@Number"].Value == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt16(cmd_MemberTransactionCheck.Parameters["@Number"].Value);
            }
        }

        /// <summary>
        /// Handles the Click event of the button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            BirthdayMessage birthdayMessageForm = new BirthdayMessage();
            birthdayMessageForm.ShowDialog();
        }
    }
}