// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 12-12-2014
// ***********************************************************************
// <copyright file="InputCashierID.cs" company="Beauty4u">
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
    /// Class InputCashierID.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class InputCashierID : Form
    {
        /// <summary>
        /// The parent form1
        /// </summary>
        public MainForm parentForm1;
        /// <summary>
        /// The parent form2
        /// </summary>
        public Discount parentForm2;
        /// <summary>
        /// The names collection
        /// </summary>
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();

        /// <summary>
        /// The option
        /// </summary>
        int option;
        /// <summary>
        /// The cashier identifier
        /// </summary>
        /// <summary>
        /// The cashier password
        /// </summary>
        string cashierID, cashierPassword;

        /// <summary>
        /// Initializes a new instance of the <see cref="InputCashierID"/> class.
        /// </summary>
        /// <param name="a">a.</param>
        public InputCashierID(int a)
        {
            InitializeComponent();
            option = a;
        }

        /// <summary>
        /// Handles the Load event of the InputCashierID control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void InputCashierID_Load(object sender, EventArgs e)
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

            txtCashierID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCashierID.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCashierID.AutoCompleteCustomSource = namesCollection;

            txtCashierID.SelectAll();
            txtCashierID.Focus();
        }

        /// <summary>
        /// Handles the Click event of the cmdOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (option == 0)
            {
                cashierID = txtCashierID.Text.Trim().ToString().ToUpper();
                cashierPassword = txtPsw.Text.Trim().ToString().ToUpper();
                SqlCommand cmd = new SqlCommand("Get_User_LogIn_Info", parentForm1.conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@empLoginID", SqlDbType.NVarChar).Value = cashierID.ToUpper().ToString();
                cmd.Parameters.Add("@empPassword", SqlDbType.NVarChar).Value = cashierPassword;
                SqlParameter UserName_Param = cmd.Parameters.Add("@empFirstName", SqlDbType.NVarChar, 50);
                SqlParameter UserLevel_Param = cmd.Parameters.Add("@empAccessLv", SqlDbType.TinyInt);
                UserName_Param.Direction = ParameterDirection.Output;
                UserLevel_Param.Direction = ParameterDirection.Output;

                parentForm1.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm1.conn.Close();

                if (cmd.Parameters["@empFirstName"].Value == DBNull.Value)
                {
                    MyMessageBox.ShowBox("INVALID ACCOUNT", "ERROR");
                    txtPsw.SelectAll();
                    txtPsw.Focus();
                    //MessageBox.Show("Invalid account", "Error");
                }
                else
                {
                    parentForm1.smDiscount = true;
                    parentForm1.smCashierID = cashierID;
                    this.Close();
                    parentForm2.btnSocialMediaDiscount_Click(null, null);
                }
            }
            else if (option == 1)
            {
                cashierID = txtCashierID.Text.Trim().ToString().ToUpper();
                cashierPassword = txtPsw.Text.Trim().ToString().ToUpper();
                SqlCommand cmd = new SqlCommand("Get_User_LogIn_Info", parentForm1.conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@empLoginID", SqlDbType.NVarChar).Value = cashierID.ToUpper().ToString();
                cmd.Parameters.Add("@empPassword", SqlDbType.NVarChar).Value = cashierPassword;
                SqlParameter UserName_Param = cmd.Parameters.Add("@empFirstName", SqlDbType.NVarChar, 50);
                SqlParameter UserLevel_Param = cmd.Parameters.Add("@empAccessLv", SqlDbType.TinyInt);
                UserName_Param.Direction = ParameterDirection.Output;
                UserLevel_Param.Direction = ParameterDirection.Output;

                parentForm1.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm1.conn.Close();

                if (cmd.Parameters["@empFirstName"].Value == DBNull.Value)
                {
                    MyMessageBox.ShowBox("INVALID ACCOUNT", "ERROR");
                    txtPsw.SelectAll();
                    txtPsw.Focus();
                    //MessageBox.Show("Invalid account", "Error");
                }
                else
                {
                    parentForm1.eDiscount1 = true;
                    parentForm1.eCashierID = cashierID;
                    this.Close();
                    parentForm2.btn25OFF_Click(null, null);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the cmdCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}