// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 01-30-2018
// ***********************************************************************
// <copyright file="Authentication.cs" company="Beauty4u">
//     Copyright © Beauty4u 2009
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

/// <summary>
/// The Register namespace.
/// </summary>
namespace Register
{
    /// <summary>
    /// Class Authentication.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class Authentication : Form
    {
        /// <summary>
        /// The parent form1
        /// </summary>
        public MainForm parentForm1;
        /// <summary>
        /// The parent form2
        /// </summary>
        public ManagerTools parentForm2;
        //public CustomerMain parentForm3;
        /// <summary>
        /// The parent form3
        /// </summary>
        public MembershipMain parentForm3;
        /// <summary>
        /// The parent form4
        /// </summary>
        public StoreCreditOption parentForm4;
        /// <summary>
        /// The parent form5
        /// </summary>
        public MPStoreCredit parentForm5;
        /// <summary>
        /// The parent form6
        /// </summary>
        public StartRegister parentForm6;
        /// <summary>
        /// The parent form7
        /// </summary>
        public ClosingRegister parentForm7;
        /// <summary>
        /// The parent form8
        /// </summary>
        public CashWithdraw parentForm8;
        /// <summary>
        /// The parent form9
        /// </summary>
        public GiftCardOption parentForm9;
        //public MPGiftCard parentForm10;
        /// <summary>
        /// The parent form11
        /// </summary>
        public CouponGenerate parentForm11;
        /// <summary>
        /// The parent form12
        /// </summary>
        public RegisterNewCustomer parentForm12;
        /// <summary>
        /// The parent form13
        /// </summary>
        public Return parentForm13;
        /// <summary>
        /// The seq
        /// </summary>
        int seq;

        /// <summary>
        /// The names collection
        /// </summary>
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();

        /// <summary>
        /// The manager identifier
        /// </summary>
        /// <summary>
        /// The manager password
        /// </summary>
        string managerID, managerPassword;

        /// <summary>
        /// Initializes a new instance of the <see cref="Authentication"/> class.
        /// </summary>
        /// <param name="s">The s.</param>
        public Authentication(int s)
        {
            InitializeComponent();
            seq = s;
        }

        /// <summary>
        /// Handles the Load event of the Authentication control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Authentication_Load(object sender, EventArgs e)
        {
            SqlDataReader dReader;
            SqlCommand cmd = new SqlCommand("Get_User_Level", parentForm1.conn);
            cmd.CommandType = CommandType.StoredProcedure;

            parentForm1.conn.Open();
            dReader = cmd.ExecuteReader();
            if (dReader.HasRows == true)
            {
                while (dReader.Read())
                    namesCollection.Add(dReader["empLoginID"].ToString());
            }
            else
            {
                MyMessageBox.ShowBox("USER DATA NOT FOUND", "ERROR");
                //MessageBox.Show("Data not found");
            }

            dReader.Close();
            parentForm1.conn.Close();

            txtManagerID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtManagerID.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtManagerID.AutoCompleteCustomSource = namesCollection;

            //cmbManagerID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cmbManagerID.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //cmbManagerID.AutoCompleteCustomSource = namesCollection;
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            managerID = txtManagerID.Text.Trim().ToString().ToUpper();
            managerPassword = txtPsw.Text.Trim().ToString().ToUpper();

            if (managerID == parentForm1.parentForm.SystemMasterUserName & managerPassword == parentForm1.parentForm.SystemMasterPassword)
            {
                //parentForm2.auth = true;
                if (seq == 0)
                {
                }
                else if (seq == 1)
                {
                    parentForm2.auth = true;
                    parentForm2.mgrID = txtManagerID.Text.Trim().ToUpper();
                    this.Close();
                    parentForm2.btnReturnByReceipt_Click(null, null);
                    parentForm2.auth = false;
                }
                else if (seq == 2)
                {
                    parentForm2.auth = true;
                    parentForm2.mgrID = txtManagerID.Text.Trim().ToUpper();
                    this.Close();
                    parentForm2.btnReturnByItem_Click(null, null);
                    parentForm2.auth = false;
                }
                else if (seq == 3)
                {
                    parentForm2.auth = true;
                    parentForm2.mgrID = txtManagerID.Text.Trim().ToUpper();
                    this.Close();
                    parentForm2.btnSpecialDiscount_Click(null, null);
                    parentForm2.auth = false;
                }
                else if (seq == 4)
                {
                    parentForm3.auth = true;
                    this.Close();
                    parentForm3.btnUpdateCustomer_Click(null, null);
                }
                else if (seq == 6)
                {
                    parentForm4.auth = true;
                    this.Close();
                    parentForm4.btnInput_Click(null, null);
                }
                else if (seq == 7)
                {
                    parentForm5.auth = true;
                    this.Close();
                    parentForm5.btnInput_Click(null, null);
                }
                else if (seq == 8)
                {
                    parentForm2.auth = true;
                    parentForm2.mgrID = txtManagerID.Text.Trim().ToUpper();
                    this.Close();
                    parentForm2.btnStartRegister_Click(null, null);
                    parentForm2.auth = false;
                }
                else if (seq == 9)
                {
                    parentForm2.auth = true;
                    parentForm2.mgrID = txtManagerID.Text.Trim().ToUpper();
                    this.Close();
                    parentForm2.btnClosingRegister_Click(null, null);
                    parentForm2.auth = false;
                }
                else if (seq == 10)
                {
                    parentForm2.auth = true;
                    parentForm2.mgrID = txtManagerID.Text.Trim().ToUpper();
                    this.Close();
                    parentForm2.btnCashWithdraw_Click(null, null);
                    parentForm2.auth = false;
                }
                else if (seq == 11)
                {
                    parentForm2.auth = true;
                    parentForm2.mgrID = txtManagerID.Text.Trim().ToUpper();
                    this.Close();
                    parentForm2.btnOpenCashDrawer_Click(null, null);
                    parentForm2.auth = false;
                }
                else if (seq == 12)
                {
                    parentForm2.auth = true;
                    parentForm2.mgrID = txtManagerID.Text.Trim().ToUpper();
                    this.Close();
                    parentForm2.btnBasicSetup_Click(null, null);
                    parentForm2.auth = false;
                }
                else if (seq == 13)
                {
                    parentForm2.auth = true;
                    parentForm2.mgrID = txtManagerID.Text.Trim().ToUpper();
                    this.Close();
                    parentForm2.btnLineNoTax_Click(null, null);
                    parentForm2.auth = false;
                }
                else if (seq == 14)
                {
                    parentForm2.auth = true;
                    parentForm2.mgrID = txtManagerID.Text.Trim().ToUpper();
                    this.Close();
                    parentForm2.btnAllNoTax_Click(null, null);
                    parentForm2.auth = false;
                }
                else if (seq == 15)
                {
                    parentForm2.auth = true;
                    parentForm2.mgrID = txtManagerID.Text.Trim().ToUpper();
                    this.Close();
                    parentForm2.btnDiscount_Click(null, null);
                    parentForm2.auth = false;
                }
                else if (seq == 16)
                {
                    parentForm9.auth = true;
                    this.Close();
                    parentForm9.btnInput_Click(null, null);
                }
                else if (seq == 17)
                {
                    //parentForm10.auth = true;
                    //this.Close();
                    //parentForm10.btnInput_Click(null, null);
                }
                else if (seq == 18)
                {
                    parentForm3.auth = true;
                    this.Close();
                    parentForm3.btnDeleteCustomer_Click(null, null);
                }
                else if (seq == 19)
                {
                    this.Close();

                    CouponGenerate couponGenerateForm = new CouponGenerate(managerID);
                    couponGenerateForm.parentForm = this.parentForm1;
                    couponGenerateForm.ShowDialog();
                }
                else if (seq == 20)
                {
                    parentForm3.auth = true;
                    parentForm3.mgrID = managerID;
                    this.Close();
                    parentForm3.btnMerge_Click(null, null);
                }
                else if (seq == 21)
                {
                    parentForm1.NoBarcodeButtonAuth = true;
                    this.Close();
                    parentForm1.btnNoBarcodeItem_Click(null, null);
                    parentForm1.NoBarcodeButtonAuth = false;
                }
                else if (seq == 22)
                {
                    parentForm3.MemberTransactionAuth = true;
                    this.Close();
                    parentForm3.btnSelectCustomer_Click(null, null);
                }
                else if (seq == 23)
                {
                    parentForm2.auth = true;
                    parentForm2.mgrID = txtManagerID.Text.Trim().ToUpper();
                    this.Close();
                    parentForm2.btnCloverSettlement_Click(null, null);
                    parentForm2.auth = false;
                }
                else if (seq == 24)
                {
                    parentForm12.BeauticianAuth = true;
                    this.Close();
                    parentForm12.btnRegister_Click(null, null);
                }
                else if (seq == 25)
                {
                    parentForm2.auth = true;
                    parentForm2.mgrID = txtManagerID.Text.Trim().ToUpper();
                    this.Close();
                    parentForm2.btnReprintReceipt_Click(null, null);
                    parentForm2.auth = false;
                }
                else if (seq == 26)
                {
                    parentForm2.auth = true;
                    parentForm2.mgrID = txtManagerID.Text.Trim().ToUpper();
                    this.Close();
                    parentForm2.btnReprintStoreCredit_Click(null, null);
                    parentForm2.auth = false;
                }
                else if (seq == 27)
                {
                    parentForm2.auth = true;
                    parentForm2.mgrID = txtManagerID.Text.Trim().ToUpper();
                    this.Close();
                    parentForm2.btnCoupon_Click(null, null);
                    parentForm2.auth = false;
                }
                else if (seq == 28)
                {
                    parentForm1.CouponMgrID = txtManagerID.Text.Trim().ToUpper();
                    this.Close();
                    parentForm1.btnSecondVisitCoupon_Click(null, null);
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                SqlCommand cmd = new SqlCommand("Get_ManagerID", parentForm1.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = managerID.ToUpper().ToString();
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = managerPassword;
                SqlParameter UserName_Param = cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50);
                UserName_Param.Direction = ParameterDirection.Output;

                parentForm1.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm1.conn.Close();

                if (cmd.Parameters["@FirstName"].Value == DBNull.Value)
                {
                    MyMessageBox.ShowBox("AUTHENTICATION FAILED", "ERROR");
                    txtPsw.SelectAll();
                    txtPsw.Focus();
                    return;
                }
                else
                {
                    //parentForm2.auth = true;
                    if (seq == 0)
                    {
                    }
                    else if (seq == 1)
                    {
                        parentForm2.auth = true;
                        parentForm2.mgrID = txtManagerID.Text.Trim().ToUpper();
                        this.Close();
                        parentForm2.btnReturnByReceipt_Click(null, null);
                        parentForm2.auth = false;
                    }
                    else if (seq == 2)
                    {
                        parentForm2.auth = true;
                        parentForm2.mgrID = txtManagerID.Text.Trim().ToUpper();
                        this.Close();
                        parentForm2.btnReturnByItem_Click(null, null);
                        parentForm2.auth = false;
                    }
                    else if (seq == 3)
                    {
                        parentForm2.auth = true;
                        parentForm2.mgrID = txtManagerID.Text.Trim().ToUpper();
                        this.Close();
                        parentForm2.btnSpecialDiscount_Click(null, null);
                        parentForm2.auth = false;
                    }
                    else if (seq == 4)
                    {
                        parentForm3.auth = true;
                        this.Close();
                        parentForm3.btnUpdateCustomer_Click(null, null);
                    }
                    else if (seq == 6)
                    {
                        parentForm4.auth = true;
                        this.Close();
                        parentForm4.btnInput_Click(null, null);
                    }
                    else if (seq == 7)
                    {
                        parentForm5.auth = true;
                        this.Close();
                        parentForm5.btnInput_Click(null, null);
                    }
                    else if (seq == 8)
                    {
                        parentForm2.auth = true;
                        this.Close();
                        parentForm2.btnStartRegister_Click(null, null);
                        parentForm2.auth = false;
                    }
                    else if (seq == 9)
                    {
                        parentForm2.auth = true;
                        parentForm2.mgrID = txtManagerID.Text.Trim().ToUpper();
                        this.Close();
                        parentForm2.btnClosingRegister_Click(null, null);
                        parentForm2.auth = false;
                    }
                    else if (seq == 10)
                    {
                        parentForm2.auth = true;
                        parentForm2.mgrID = txtManagerID.Text.Trim().ToUpper();
                        this.Close();
                        parentForm2.btnCashWithdraw_Click(null, null);
                        parentForm2.auth = false;
                    }
                    else if (seq == 11)
                    {
                        parentForm2.auth = true;
                        parentForm2.mgrID = txtManagerID.Text.Trim().ToUpper();
                        this.Close();
                        parentForm2.btnOpenCashDrawer_Click(null, null);
                        parentForm2.auth = false;
                    }
                    else if (seq == 12)
                    {
                        parentForm2.auth = true;
                        parentForm2.mgrID = txtManagerID.Text.Trim().ToUpper();
                        this.Close();
                        parentForm2.btnBasicSetup_Click(null, null);
                        parentForm2.auth = false;
                    }
                    else if (seq == 13)
                    {
                        parentForm2.auth = true;
                        parentForm2.mgrID = txtManagerID.Text.Trim().ToUpper();
                        this.Close();
                        parentForm2.btnLineNoTax_Click(null, null);
                        parentForm2.auth = false;
                    }
                    else if (seq == 14)
                    {
                        parentForm2.auth = true;
                        parentForm2.mgrID = txtManagerID.Text.Trim().ToUpper();
                        this.Close();
                        parentForm2.btnAllNoTax_Click(null, null);
                        parentForm2.auth = false;
                    }
                    else if (seq == 15)
                    {
                        parentForm2.auth = true;
                        parentForm2.mgrID = txtManagerID.Text.Trim().ToUpper();
                        this.Close();
                        parentForm2.btnDiscount_Click(null, null);
                        parentForm2.auth = false;
                    }
                    else if (seq == 16)
                    {
                        parentForm9.auth = true;
                        this.Close();
                        parentForm9.btnInput_Click(null, null);
                    }
                    else if (seq == 17)
                    {
                        //parentForm10.auth = true;
                        //this.Close();
                        //parentForm10.btnInput_Click(null, null);
                    }
                    else if (seq == 18)
                    {
                        parentForm3.auth = true;
                        this.Close();
                        parentForm3.btnDeleteCustomer_Click(null, null);
                    }
                    else if (seq == 19)
                    {
                        this.Close();

                        CouponGenerate couponGenerateForm = new CouponGenerate(managerID);
                        couponGenerateForm.parentForm = this.parentForm1;
                        couponGenerateForm.ShowDialog();
                    }
                    else if (seq == 20)
                    {
                        parentForm3.auth = true;
                        parentForm3.mgrID = managerID;
                        this.Close();
                        parentForm3.btnMerge_Click(null, null);
                    }
                    else if (seq == 21)
                    {
                        parentForm1.NoBarcodeButtonAuth = true;
                        this.Close();
                        parentForm1.btnNoBarcodeItem_Click(null, null);
                        parentForm1.NoBarcodeButtonAuth = false;
                    }
                    else if (seq == 22)
                    {
                        parentForm3.MemberTransactionAuth = true;
                        this.Close();
                        parentForm3.btnSelectCustomer_Click(null, null);
                    }
                    else if (seq == 23)
                    {
                        parentForm2.auth = true;
                        parentForm2.mgrID = txtManagerID.Text.Trim().ToUpper();
                        this.Close();
                        parentForm2.btnCloverSettlement_Click(null, null);
                        parentForm2.auth = false;
                    }
                    else if (seq == 24)
                    {
                        parentForm12.BeauticianAuth = true;
                        this.Close();
                        parentForm12.btnRegister_Click(null, null);
                    }
                    else if (seq == 25)
                    {
                        parentForm2.auth = true;
                        parentForm2.mgrID = txtManagerID.Text.Trim().ToUpper();
                        this.Close();
                        parentForm2.btnReprintReceipt_Click(null, null);
                        parentForm2.auth = false;
                    }
                    else if (seq == 26)
                    {
                        parentForm2.auth = true;
                        parentForm2.mgrID = txtManagerID.Text.Trim().ToUpper();
                        this.Close();
                        parentForm2.btnReprintStoreCredit_Click(null, null);
                        parentForm2.auth = false;
                    }
                    else if (seq == 27)
                    {
                        parentForm2.auth = true;
                        parentForm2.mgrID = txtManagerID.Text.Trim().ToUpper();
                        this.Close();
                        parentForm2.btnCoupon_Click(null, null);
                        parentForm2.auth = false;
                    }
                    else if (seq == 28)
                    {
                        parentForm1.CouponMgrID = txtManagerID.Text.Trim().ToUpper();
                        this.Close();
                        parentForm1.btnSecondVisitCoupon_Click(null, null);
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (seq == 15)
            {
                parentForm2.basicPrice = parentForm1.dataGridView1.Rows[parentForm2.selectedRowIndex].Cells[3].Value.ToString();
                Discount discountForm = new Discount(parentForm2.selectedRowIndex, parentForm2.basicPrice, 1);
                discountForm.parentForm = this.parentForm1;
                discountForm.ShowDialog();
                parentForm2.selectedRowIndex = 0;
                parentForm2.basicPrice = string.Empty;

                parentForm2.Close();
                this.Close();
            }
            else
            {
                this.Close();
            }
        }
    }
}