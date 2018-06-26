// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 01-30-2018
//
// Last Modified By : Seungkeun
// Last Modified On : 01-30-2018
// ***********************************************************************
// <copyright file="SecondAuthentication.cs" company="Beauty4u">
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
    /// Class SecondAuthentication.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class SecondAuthentication : Form
    {
        /// <summary>
        /// The parent form1
        /// </summary>
        public MainForm parentForm1;
        /// <summary>
        /// The parent form2
        /// </summary>
        public Return parentForm2;

        /// <summary>
        /// The option
        /// </summary>
        int option = 0;

        /// <summary>
        /// The names collection
        /// </summary>
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();

        /// <summary>
        /// The employee identifier
        /// </summary>
        /// <summary>
        /// The employee password
        /// </summary>
        string employeeID, employeePassword;
        /// <summary>
        /// Initializes a new instance of the <see cref="SecondAuthentication"/> class.
        /// </summary>
        /// <param name="opt">The opt.</param>
        public SecondAuthentication(int opt)
        {
            InitializeComponent();
            option = opt;
        }

        /// <summary>
        /// Handles the Load event of the SecondAuthentication control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SecondAuthentication_Load(object sender, EventArgs e)
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

            txtEmployeeID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtEmployeeID.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtEmployeeID.AutoCompleteCustomSource = namesCollection;
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            employeeID = txtEmployeeID.Text.Trim().ToString().ToUpper();
            employeePassword = txtPsw.Text.Trim().ToString().ToUpper();

            if(parentForm2.managerID.ToUpper() == employeeID.ToUpper())
            {
                MyMessageBox.ShowBox("WITNESS ID CAN NOT BE SAME WITH MANAGER ID", "ERROR");
                return;
            }

            SqlCommand cmd = new SqlCommand("Get_User", parentForm1.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@empLoginID", SqlDbType.NVarChar).Value = employeeID.ToUpper().ToString();
            cmd.Parameters.Add("@empPassword", SqlDbType.NVarChar).Value = employeePassword;
            SqlParameter UserFirstName_Param = cmd.Parameters.Add("@empFirstName", SqlDbType.NVarChar, 50);
            SqlParameter UserLastName_Param = cmd.Parameters.Add("@empLastName", SqlDbType.NVarChar, 50);
            UserFirstName_Param.Direction = ParameterDirection.Output;
            UserLastName_Param.Direction = ParameterDirection.Output;

            parentForm1.conn.Open();
            cmd.ExecuteNonQuery();
            parentForm1.conn.Close();

            if (cmd.Parameters["@empFirstName"].Value == DBNull.Value)
            {
                MyMessageBox.ShowBox("AUTHENTICATION FAILED", "ERROR");
                txtPsw.SelectAll();
                txtPsw.Focus();
                return;
            }
            else
            {
                if (option == 0)
                {
                    parentForm2.boolSecondAuthentication = true;
                    parentForm2.witnessID = employeeID.Trim().ToUpper().ToString();
                    this.Close();
                    parentForm2.btnRefund_Click(null, null);
                    parentForm2.boolSecondAuthentication = false;
                }
                else if (option == 1)
                {
                    parentForm2.boolSecondAuthentication = true;
                    parentForm2.witnessID = employeeID.Trim().ToUpper().ToString();
                    this.Close();
                    parentForm2.btnVoid_Click(null, null);
                    parentForm2.boolSecondAuthentication = false;
                }
                else if (option == 2)
                {
                    parentForm2.boolSecondAuthentication = true;
                    parentForm2.witnessID = employeeID.Trim().ToUpper().ToString();
                    this.Close();
                    parentForm2.btnStoreCredit_Click(null, null);
                    parentForm2.boolSecondAuthentication = false;
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
            this.Close();
        }
    }
}
