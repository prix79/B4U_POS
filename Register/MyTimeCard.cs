// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 09-01-2016
// ***********************************************************************
// <copyright file="MyTimeCard.cs" company="Beauty4u">
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
    /// Class MyTimeCard.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class MyTimeCard : Form
    {
        /// <summary>
        /// The parent form
        /// </summary>
        public MainForm parentForm;
        /// <summary>
        /// The employee identifier
        /// </summary>
        string employeeID;
        /// <summary>
        /// The password
        /// </summary>
        string password;
        /// <summary>
        /// The names collection
        /// </summary>
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        /// <summary>
        /// The current time
        /// </summary>
        DateTime currentTime;
        /// <summary>
        /// The today
        /// </summary>
        string today;
        /// <summary>
        /// The calculated ci
        /// </summary>
        DateTime CalculatedCI;
        /// <summary>
        /// The calculated co
        /// </summary>
        DateTime CalculatedCO;

        /// <summary>
        /// The tc clock in
        /// </summary>
        string TcClockIn;
        /// <summary>
        /// The tc clock out
        /// </summary>
        string TcClockOut;
        /// <summary>
        /// The tc number
        /// </summary>
        string TcNum;

        /// <summary>
        /// The DRV font
        /// </summary>
        public Font drvFont = new Font("Arial", 12, FontStyle.Bold);

        /// <summary>
        /// Initializes a new instance of the <see cref="MyTimeCard"/> class.
        /// </summary>
        public MyTimeCard()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btnLogin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtEmployeeID.Text == "" | txtPsw.Text == "")
            {
                MyMessageBox.ShowBox("INPUT EMPLOYEE ID / PASSWORD", "ERROR");
                //MessageBox.Show("Input Your Employee ID/Password","Error");
                txtEmployeeID.SelectAll();
                txtEmployeeID.Focus();
                return;
            }
            else
            {
                employeeID = txtEmployeeID.Text.Trim().ToString();
                password = txtPsw.Text.Trim().ToString();
                SqlCommand cmd = new SqlCommand("Get_User", parentForm.conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@empLoginID", SqlDbType.NVarChar).Value = employeeID.ToUpper().ToString();
                cmd.Parameters.Add("@empPassword", SqlDbType.NVarChar).Value = password;
                SqlParameter empFirstName_Param = cmd.Parameters.Add("@empFirstName", SqlDbType.NVarChar, 50);
                SqlParameter empLastName_Param = cmd.Parameters.Add("@empLastName", SqlDbType.NVarChar, 50);
                empFirstName_Param.Direction = ParameterDirection.Output;
                empLastName_Param.Direction = ParameterDirection.Output;

                parentForm.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm.conn.Close();

                if (cmd.Parameters["@empFirstName"].Value.ToString() == "")
                {
                    MyMessageBox.ShowBox("INVALID ACCOUNT", "ERROR");
                    //MessageBox.Show("Invalid Account", "Error");
                    txtEmployeeID.SelectAll();
                    txtEmployeeID.Focus();
                    return;
                }
                else
                {
                    //btnClockIn.Enabled = true;
                    //btnClockOut.Enabled = true;
                    btnLogin.Enabled = false;
                    btnLogin.Visible = false;
                    btnLogOut.Enabled = true;
                    btnLogOut.Visible = true;
                    txtEmployeeID.Enabled = false;
                    txtEmployeeID.Visible = false;
                    txtPsw.Enabled = false;
                    txtPsw.Visible = false;
                    lblUserName.Text = cmd.Parameters["@empFirstName"].Value.ToString().ToUpper() + " " + cmd.Parameters["@empLastName"].Value.ToString().ToUpper();
                    lblEmployeeID.Text =  employeeID.ToUpper().ToString();
                    lblTitlePsw.Text = "EMPLOYEE NAME";
                    lblEmployeeID.Enabled = true;
                    lblEmployeeID.Visible = true;
                    lblUserName.Enabled = true;
                    lblUserName.Visible = true;

                    SqlCommand cmd_MyTimeCard = new SqlCommand("Get_My_Time_Card", parentForm.conn);
                    cmd_MyTimeCard.CommandType = CommandType.StoredProcedure;
                    cmd_MyTimeCard.Parameters.Add("@TcLoginID", SqlDbType.NVarChar).Value = employeeID;
                    SqlDataAdapter adapt = new SqlDataAdapter();
                    DataTable MyTimeCardTable = new DataTable();
                    adapt.SelectCommand = cmd_MyTimeCard;

                    parentForm.conn.Open();
                    adapt.Fill(MyTimeCardTable);
                    dataGridView1.RowTemplate.Height = 40;
                    dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                    dataGridView1.DataSource = MyTimeCardTable;
                    dataGridView1.RowTemplate.Height = 30;
                    dataGridView1.Columns[0].HeaderText = "CLOCK IN";
                    dataGridView1.Columns[0].DefaultCellStyle.Format = "G";
                    dataGridView1.Columns[0].Width = 295;
                    dataGridView1.Columns[1].HeaderText = "CLOCK OUT";
                    dataGridView1.Columns[1].DefaultCellStyle.Format = "G";
                    dataGridView1.Columns[1].Width = 295;
                    parentForm.conn.Close();
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
            parentForm.Enabled = true;
            this.Close();
            parentForm.richTxtUpc.Select();
            parentForm.richTxtUpc.Focus();
        }

        /// <summary>
        /// Handles the Load event of the MyTimeCard control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MyTimeCard_Load(object sender, EventArgs e)
        {
            SqlDataReader dReader;
            SqlCommand cmd = new SqlCommand("Get_UserID", parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;

            parentForm.conn.Open();
            dReader = cmd.ExecuteReader();

            if (dReader.HasRows == true)
            {
                while (dReader.Read())
                    namesCollection.Add(dReader["empLoginID"].ToString());
            }
            else
            {
                MyMessageBox.ShowBox("USER DATA NOT FOUND", "ERROR");
                MessageBox.Show("Data not found");
            }

            dReader.Close();
            parentForm.conn.Close();

            txtEmployeeID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtEmployeeID.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtEmployeeID.AutoCompleteCustomSource = namesCollection;

            txtEmployeeID.SelectAll();
            txtEmployeeID.Focus();
        }

        /// <summary>
        /// Handles the Click event of the btnClockIn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnClockIn_Click(object sender, EventArgs e)
        {
            //today = string.Format("{0:d}", currentTime);
            currentTime = DateTime.Now;
            today = currentTime.ToString("yyyy") + currentTime.ToString("MM") + currentTime.ToString("dd");

            if (lblEmployeeID.Enabled == true || lblUserName.Enabled == true)
            {
                SqlCommand cmd = new SqlCommand("Check_Clock_In_Out", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TcLoginID", SqlDbType.NVarChar).Value = employeeID.ToUpper().ToString();
                cmd.Parameters.Add("@TcDate", SqlDbType.Int).Value = Convert.ToInt32(today);
                SqlParameter TcClockInParam = cmd.Parameters.Add("@TcClockIn", SqlDbType.DateTime);
                SqlParameter TcClockOut_Param = cmd.Parameters.Add("@TcClockOut", SqlDbType.DateTime);
                SqlParameter TcNum_Param = cmd.Parameters.Add("@TcNum", SqlDbType.BigInt);
                TcClockInParam.Direction = ParameterDirection.Output;
                TcClockOut_Param.Direction = ParameterDirection.Output;
                TcNum_Param.Direction = ParameterDirection.Output;

                parentForm.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm.conn.Close();

                TcClockIn = Convert.ToString(cmd.Parameters["@TcClockIn"].Value);
                TcClockOut = Convert.ToString(cmd.Parameters["@TcClockOut"].Value);
                TcNum = Convert.ToString(cmd.Parameters["@TcNum"].Value);

                if (TcClockIn == "" & TcClockOut == "")
                {
                    currentTime = DateTime.Now;
                    SqlCommand cmd_ClockIn = new SqlCommand("Add_Clock_In_New", parentForm.conn);
                    cmd_ClockIn.CommandType = CommandType.StoredProcedure;
                    cmd_ClockIn.Parameters.Add("@TcStoreCode", SqlDbType.NVarChar).Value = parentForm.storeCode;
                    cmd_ClockIn.Parameters.Add("@TcLoginID", SqlDbType.NVarChar).Value = employeeID.ToUpper().ToString();
                    cmd_ClockIn.Parameters.Add("@TcDate", SqlDbType.Int).Value = Convert.ToInt32(today);

                    if (currentTime.DayOfWeek != DayOfWeek.Sunday)
                    {
                        if (currentTime.Hour < 9)
                        {
                            cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                            CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 9, 30, 0);
                            cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                        }
                        else if (currentTime.Hour == 9)
                        {
                            if (currentTime.Minute <= 30)
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 9, 30, 0);
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                            }
                            else if (currentTime.Minute >= 31 & currentTime.Minute <= 37)
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 9, 30, 0);
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                            }
                            else if (currentTime.Minute >= 38 & currentTime.Minute <= 45)
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 9, 45, 0);
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                            }
                            else if (currentTime.Minute >= 46 & currentTime.Minute <= 52)
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 9, 45, 0);
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                            }
                            /*else if (currentTime.Minute >= 53 & currentTime.Minute <= 59)
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 10, 00, 0);
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                            }*/
                            else
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 10, 0, 0);
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                            }
                        }
                        else if (currentTime.Hour == 10)
                        {
                            if (currentTime.Minute <= 7)
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 10, 0, 0);
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                            }
                            else if (currentTime.Minute >= 8 & currentTime.Minute <= 14)
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 10, 15, 0);
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                            }
                            else
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = currentTime.ToString("G");
                            }
                        }
                        else
                        {
                            cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                            cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = currentTime.ToString("G");
                        }
                    }
                    else
                    {
                        if (currentTime.Hour < 10)
                        {
                            cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                            CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 10, 30, 0);
                            cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                        }
                        else if (currentTime.Hour == 10)
                        {
                            if (currentTime.Minute <= 30)
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 10, 30, 0);
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                            }
                            else if (currentTime.Minute >= 31 & currentTime.Minute <= 37)
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 10, 30, 0);
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                            }
                            else if (currentTime.Minute >= 38 & currentTime.Minute <= 45)
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 10, 45, 0);
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                            }
                            else if (currentTime.Minute >= 46 & currentTime.Minute <= 52)
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 10, 45, 0);
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                            }
                            else
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 11, 0, 0);
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                            }
                        }
                        else if (currentTime.Hour == 11)
                        {
                            if (currentTime.Minute <= 7)
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 11, 0, 0);
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                            }
                            else if (currentTime.Minute >= 8 & currentTime.Minute <= 14)
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 11, 15, 0);
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                            }
                            else
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = currentTime.ToString("G");
                            }
                        }
                        else
                        {
                            cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                            cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = currentTime.ToString("G");
                        }
                    }

                    cmd_ClockIn.Parameters.Add("@TcUsing", SqlDbType.Bit).Value = 0;

                    parentForm.conn.Open();
                    cmd_ClockIn.ExecuteNonQuery();
                    parentForm.conn.Close();

                    MyMessageBox.ShowBox("SUCCESSFULLY CLOCK IN", "INFORMATION");

                    SqlCommand cmd_MyTimeCard = new SqlCommand("Get_My_Time_Card", parentForm.conn);
                    cmd_MyTimeCard.CommandType = CommandType.StoredProcedure;
                    cmd_MyTimeCard.Parameters.Add("@TcLoginID", SqlDbType.NVarChar).Value = employeeID.ToUpper().ToString();
                    SqlDataAdapter adapt = new SqlDataAdapter();
                    DataTable MyTimeCardTable = new DataTable();
                    adapt.SelectCommand = cmd_MyTimeCard;

                    parentForm.conn.Open();
                    adapt.Fill(MyTimeCardTable);
                    dataGridView1.RowTemplate.Height = 40;
                    dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                    dataGridView1.DataSource = MyTimeCardTable;
                    dataGridView1.RowTemplate.Height = 30;
                    dataGridView1.Columns[0].HeaderText = "CLOCK IN";
                    dataGridView1.Columns[0].DefaultCellStyle.Format = "G";
                    dataGridView1.Columns[0].Width = 295;
                    dataGridView1.Columns[1].HeaderText = "CLOCK OUT";
                    dataGridView1.Columns[1].DefaultCellStyle.Format = "G";
                    dataGridView1.Columns[1].Width = 295;
                    parentForm.conn.Close();

                    TcClockIn = string.Empty;
                    TcClockOut = string.Empty;
                    TcNum = string.Empty;
                }
                else if (TcClockIn != "" & TcClockOut != "")
                {
                    currentTime = DateTime.Now;
                    SqlCommand cmd_ClockIn = new SqlCommand("Add_Clock_In_New", parentForm.conn);
                    cmd_ClockIn.CommandType = CommandType.StoredProcedure;
                    cmd_ClockIn.Parameters.Add("@TcStoreCode", SqlDbType.NVarChar).Value = parentForm.storeCode;
                    cmd_ClockIn.Parameters.Add("@TcLoginID", SqlDbType.NVarChar).Value = employeeID.ToUpper().ToString();
                    cmd_ClockIn.Parameters.Add("@TcDate", SqlDbType.Int).Value = Convert.ToInt32(today);

                    if (currentTime.DayOfWeek != DayOfWeek.Sunday)
                    {
                        if (currentTime.Hour < 9)
                        {
                            cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                            CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 9, 30, 0);
                            cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                        }
                        else if (currentTime.Hour == 9)
                        {
                            if (currentTime.Minute <= 30)
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 9, 30, 0);
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                            }
                            else if (currentTime.Minute >= 31 & currentTime.Minute <= 37)
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 9, 30, 0);
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                            }
                            else if (currentTime.Minute >= 38 & currentTime.Minute <= 45)
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 9, 45, 0);
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                            }
                            else if (currentTime.Minute >= 46 & currentTime.Minute <= 52)
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 9, 45, 0);
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                            }
                            /*else if (currentTime.Minute >= 53 & currentTime.Minute <= 59)
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 10, 00, 0);
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                            }*/
                            else
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 10, 0, 0);
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                            }
                        }
                        else if (currentTime.Hour == 10)
                        {
                            if (currentTime.Minute <= 7)
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 10, 0, 0);
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                            }
                            else if (currentTime.Minute >= 8 & currentTime.Minute <= 14)
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 10, 15, 0);
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                            }
                            else
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = currentTime.ToString("G");
                            }
                        }
                        else
                        {
                            cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                            cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = currentTime.ToString("G");
                        }
                    }
                    else
                    {
                        if (currentTime.Hour < 10)
                        {
                            cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                            CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 10, 30, 0);
                            cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                        }
                        else if (currentTime.Hour == 10)
                        {
                            if (currentTime.Minute <= 30)
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 10, 30, 0);
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                            }
                            else if (currentTime.Minute >= 31 & currentTime.Minute <= 37)
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 10, 30, 0);
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                            }
                            else if (currentTime.Minute >= 38 & currentTime.Minute <= 45)
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 10, 45, 0);
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                            }
                            else if (currentTime.Minute >= 46 & currentTime.Minute <= 52)
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 10, 45, 0);
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                            }
                            else
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 11, 0, 0);
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                            }
                        }
                        else if (currentTime.Hour == 11)
                        {
                            if (currentTime.Minute <= 7)
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 11, 0, 0);
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                            }
                            else if (currentTime.Minute >= 8 & currentTime.Minute <= 14)
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCI = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 11, 15, 0);
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = CalculatedCI.ToString("G");
                            }
                            else
                            {
                                cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = currentTime.ToString("G");
                            }
                        }
                        else
                        {
                            cmd_ClockIn.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = currentTime.ToString("G");
                            cmd_ClockIn.Parameters.Add("@TcCalculatedCI", SqlDbType.DateTime).Value = currentTime.ToString("G");
                        }
                    }

                    cmd_ClockIn.Parameters.Add("@TcUsing", SqlDbType.Bit).Value = 0;

                    parentForm.conn.Open();
                    cmd_ClockIn.ExecuteNonQuery();
                    parentForm.conn.Close();

                    MyMessageBox.ShowBox("SUCCESSFULLY CLOCK IN", "INFORMATION");

                    SqlCommand cmd_MyTimeCard = new SqlCommand("Get_My_Time_Card", parentForm.conn);
                    cmd_MyTimeCard.CommandType = CommandType.StoredProcedure;
                    cmd_MyTimeCard.Parameters.Add("@TcLoginID", SqlDbType.NVarChar).Value = employeeID.ToUpper().ToString();
                    SqlDataAdapter adapt = new SqlDataAdapter();
                    DataTable MyTimeCardTable = new DataTable();
                    adapt.SelectCommand = cmd_MyTimeCard;

                    parentForm.conn.Open();
                    adapt.Fill(MyTimeCardTable);
                    dataGridView1.RowTemplate.Height = 40;
                    dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                    dataGridView1.DataSource = MyTimeCardTable;
                    dataGridView1.RowTemplate.Height = 30;
                    dataGridView1.Columns[0].HeaderText = "CLOCK IN";
                    dataGridView1.Columns[0].DefaultCellStyle.Format = "G";
                    dataGridView1.Columns[0].Width = 295;
                    dataGridView1.Columns[1].HeaderText = "CLOCK OUT";
                    dataGridView1.Columns[1].DefaultCellStyle.Format = "G";
                    dataGridView1.Columns[1].Width = 295;
                    parentForm.conn.Close();

                    TcClockIn = string.Empty;
                    TcClockOut = string.Empty;
                    TcNum = string.Empty;
                }
                else
                {
                    MyMessageBox.ShowBox("NEED CLOCK OUT", "ERROR");
                    //MessageBox.Show("Need Clock Out", "Error");
                    return;
                }
            }
            else
            {
                MyMessageBox.ShowBox("PLEASE LOG IN FIRST", "ERROR");
                //MessageBox.Show("Log in first", "Error");
                return;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnClockOut control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnClockOut_Click(object sender, EventArgs e)
        {
            currentTime = DateTime.Now;
            today = currentTime.ToString("yyyy") + currentTime.ToString("MM") + currentTime.ToString("dd");

            if (lblEmployeeID.Enabled == true || lblUserName.Enabled == true)
            {
                SqlCommand cmd = new SqlCommand("Check_Clock_In_Out", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TcLoginID", SqlDbType.NVarChar).Value = employeeID.ToUpper().ToString();
                cmd.Parameters.Add("@TcDate", SqlDbType.Int).Value = Convert.ToInt32(today);
                SqlParameter TcClockInParam = cmd.Parameters.Add("@TcClockIn", SqlDbType.DateTime);
                SqlParameter TcClockOut_Param = cmd.Parameters.Add("@TcClockOut", SqlDbType.DateTime);
                SqlParameter TcNum_Param = cmd.Parameters.Add("@TcNum", SqlDbType.BigInt);
                TcClockInParam.Direction = ParameterDirection.Output;
                TcClockOut_Param.Direction = ParameterDirection.Output;
                TcNum_Param.Direction = ParameterDirection.Output;

                parentForm.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm.conn.Close();

                TcClockIn = Convert.ToString(cmd.Parameters["@TcClockIn"].Value);
                TcClockOut = Convert.ToString(cmd.Parameters["@TcClockOut"].Value);
                TcNum = Convert.ToString(cmd.Parameters["@TcNum"].Value);

                if (TcClockIn != "" & TcClockOut == "")
                {
                    currentTime = DateTime.Now;
                    SqlCommand cmd_ClockOut = new SqlCommand("Add_Clock_Out_New", parentForm.conn);
                    cmd_ClockOut.CommandType = CommandType.StoredProcedure;
                    //cmd_ClockOut.Parameters.Add("@TcLoginID", SqlDbType.NVarChar).Value = employeeID.ToUpper().ToString();
                    //cmd_ClockOut.Parameters.Add("@TcClockIn", SqlDbType.DateTime).Value = TcClockIn;
                    cmd_ClockOut.Parameters.Add("@TcNum", SqlDbType.BigInt).Value = Convert.ToInt64(TcNum);

                    if (currentTime.DayOfWeek != DayOfWeek.Sunday)
                    {
                        if (currentTime.Hour == 20)
                        {
                            if (currentTime.Minute <= 7)
                            {
                                cmd_ClockOut.Parameters.Add("@TcClockOut", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCO = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 20, 00, 0);
                                cmd_ClockOut.Parameters.Add("@TcCalculatedCO", SqlDbType.DateTime).Value = CalculatedCO.ToString("G");
                            }
                            else if (currentTime.Minute >= 8 & currentTime.Minute <= 15)
                            {
                                cmd_ClockOut.Parameters.Add("@TcClockOut", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCO = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 20, 15, 0);
                                cmd_ClockOut.Parameters.Add("@TcCalculatedCO", SqlDbType.DateTime).Value = CalculatedCO.ToString("G");
                            }
                            else if (currentTime.Minute >= 16 & currentTime.Minute <= 22)
                            {
                                cmd_ClockOut.Parameters.Add("@TcClockOut", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCO = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 20, 15, 0);
                                cmd_ClockOut.Parameters.Add("@TcCalculatedCO", SqlDbType.DateTime).Value = CalculatedCO.ToString("G");
                            }
                            else
                            {
                                cmd_ClockOut.Parameters.Add("@TcClockOut", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCO = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 20, 30, 0);
                                cmd_ClockOut.Parameters.Add("@TcCalculatedCO", SqlDbType.DateTime).Value = CalculatedCO.ToString("G");
                            }
                        }
                        else if (currentTime.Hour >= 21)
                        {
                            cmd_ClockOut.Parameters.Add("@TcClockOut", SqlDbType.DateTime).Value = currentTime.ToString("G");
                            CalculatedCO = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 20, 30, 0);
                            cmd_ClockOut.Parameters.Add("@TcCalculatedCO", SqlDbType.DateTime).Value = CalculatedCO.ToString("G");
                        }
                        else
                        {
                            cmd_ClockOut.Parameters.Add("@TcClockOut", SqlDbType.DateTime).Value = currentTime.ToString("G");
                            cmd_ClockOut.Parameters.Add("@TcCalculatedCO", SqlDbType.DateTime).Value = currentTime.ToString("G");
                        }

                        //cmd_ClockOut.Parameters.Add("@TcUsing", SqlDbType.Bit).Value = 1;

                        SqlCommand cmd_Calculate_TimeCard = new SqlCommand("Calculate_Time_Card_New", parentForm.conn);
                        cmd_Calculate_TimeCard.CommandType = CommandType.StoredProcedure;
                        cmd_Calculate_TimeCard.Parameters.Add("@TcNum", SqlDbType.BigInt).Value = Convert.ToInt64(TcNum);

                        parentForm.conn.Open();
                        cmd_ClockOut.ExecuteNonQuery();
                        cmd_Calculate_TimeCard.ExecuteNonQuery();
                        parentForm.conn.Close();

                        MyMessageBox.ShowBox("SUCCESSFULLY CLOCK OUT", "INFORMATION");

                        SqlCommand cmd_MyTimeCard = new SqlCommand("Get_My_Time_Card", parentForm.conn);
                        cmd_MyTimeCard.CommandType = CommandType.StoredProcedure;
                        cmd_MyTimeCard.Parameters.Add("@TcLoginID", SqlDbType.NVarChar).Value = employeeID.ToUpper().ToString();
                        SqlDataAdapter adapt = new SqlDataAdapter();
                        DataTable MyTimeCardTable = new DataTable();
                        adapt.SelectCommand = cmd_MyTimeCard;

                        parentForm.conn.Open();
                        adapt.Fill(MyTimeCardTable);
                        dataGridView1.RowTemplate.Height = 40;
                        dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                        dataGridView1.DataSource = MyTimeCardTable;
                        dataGridView1.RowTemplate.Height = 30;
                        dataGridView1.Columns[0].HeaderText = "CLOCK IN";
                        dataGridView1.Columns[0].DefaultCellStyle.Format = "G";
                        dataGridView1.Columns[0].Width = 295;
                        dataGridView1.Columns[1].HeaderText = "CLOCK OUT";
                        dataGridView1.Columns[1].DefaultCellStyle.Format = "G";
                        dataGridView1.Columns[1].Width = 295;
                        parentForm.conn.Close();

                        TcClockIn = string.Empty;
                        TcClockOut = string.Empty;
                        TcNum = string.Empty;
                    }
                    else
                    {
                        if (currentTime.Hour == 17)
                        {
                            if (currentTime.Minute <= 7)
                            {
                                cmd_ClockOut.Parameters.Add("@TcClockOut", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCO = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 17, 00, 0);
                                cmd_ClockOut.Parameters.Add("@TcCalculatedCO", SqlDbType.DateTime).Value = CalculatedCO.ToString("G");
                            }
                            else if (currentTime.Minute >= 8 & currentTime.Minute <= 15)
                            {
                                cmd_ClockOut.Parameters.Add("@TcClockOut", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCO = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 17, 15, 0);
                                cmd_ClockOut.Parameters.Add("@TcCalculatedCO", SqlDbType.DateTime).Value = CalculatedCO.ToString("G");
                            }
                            else if (currentTime.Minute >= 16 & currentTime.Minute <= 22)
                            {
                                cmd_ClockOut.Parameters.Add("@TcClockOut", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCO = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 17, 15, 0);
                                cmd_ClockOut.Parameters.Add("@TcCalculatedCO", SqlDbType.DateTime).Value = CalculatedCO.ToString("G");
                            }
                            else
                            {
                                cmd_ClockOut.Parameters.Add("@TcClockOut", SqlDbType.DateTime).Value = currentTime.ToString("G");
                                CalculatedCO = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 17, 30, 0);
                                cmd_ClockOut.Parameters.Add("@TcCalculatedCO", SqlDbType.DateTime).Value = CalculatedCO.ToString("G");
                            }
                        }
                        else if (currentTime.Hour >= 18)
                        {
                            cmd_ClockOut.Parameters.Add("@TcClockOut", SqlDbType.DateTime).Value = currentTime.ToString("G");
                            CalculatedCO = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 17, 30, 0);
                            cmd_ClockOut.Parameters.Add("@TcCalculatedCO", SqlDbType.DateTime).Value = CalculatedCO.ToString("G");
                        }
                        else
                        {
                            cmd_ClockOut.Parameters.Add("@TcClockOut", SqlDbType.DateTime).Value = currentTime.ToString("G");
                            cmd_ClockOut.Parameters.Add("@TcCalculatedCO", SqlDbType.DateTime).Value = currentTime.ToString("G");
                        }

                        //cmd_ClockOut.Parameters.Add("@TcUsing", SqlDbType.Bit).Value = 1;

                        SqlCommand cmd_Calculate_TimeCard = new SqlCommand("Calculate_Time_Card_On_Sunday_New", parentForm.conn);
                        cmd_Calculate_TimeCard.CommandType = CommandType.StoredProcedure;
                        cmd_Calculate_TimeCard.Parameters.Add("@TcNum", SqlDbType.BigInt).Value = Convert.ToInt64(TcNum);

                        parentForm.conn.Open();
                        cmd_ClockOut.ExecuteNonQuery();
                        cmd_Calculate_TimeCard.ExecuteNonQuery();
                        parentForm.conn.Close();

                        MyMessageBox.ShowBox("SUCCESSFULLY CLOCK OUT", "INFORMATION");

                        SqlCommand cmd_MyTimeCard = new SqlCommand("Get_My_Time_Card", parentForm.conn);
                        cmd_MyTimeCard.CommandType = CommandType.StoredProcedure;
                        cmd_MyTimeCard.Parameters.Add("@TcLoginID", SqlDbType.NVarChar).Value = employeeID.ToUpper().ToString();
                        SqlDataAdapter adapt = new SqlDataAdapter();
                        DataTable MyTimeCardTable = new DataTable();
                        adapt.SelectCommand = cmd_MyTimeCard;

                        parentForm.conn.Open();
                        adapt.Fill(MyTimeCardTable);
                        dataGridView1.RowTemplate.Height = 40;
                        dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                        dataGridView1.DataSource = MyTimeCardTable;
                        dataGridView1.RowTemplate.Height = 30;
                        dataGridView1.Columns[0].HeaderText = "CLOCK IN";
                        dataGridView1.Columns[0].DefaultCellStyle.Format = "G";
                        dataGridView1.Columns[0].Width = 295;
                        dataGridView1.Columns[1].HeaderText = "CLOCK OUT";
                        dataGridView1.Columns[1].DefaultCellStyle.Format = "G";
                        dataGridView1.Columns[1].Width = 295;
                        parentForm.conn.Close();

                        TcClockIn = string.Empty;
                        TcClockOut = string.Empty;
                        TcNum = string.Empty;
                    }
                }
                else
                {
                    MyMessageBox.ShowBox("NEED CLOCK IN", "ERROR");
                    //MessageBox.Show("Need Clock In", "Error");
                    return;
                }
            }
            else
            {
                MyMessageBox.ShowBox("PLEASE LOG IN FIRST", "ERROR");
                //MessageBox.Show("Log in first", "Error");
                return;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the window will be activated when it is shown.
        /// </summary>
        /// <value><c>true</c> if [show without activation]; otherwise, <c>false</c>.</value>
        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnLogOut control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            employeeID = string.Empty;
            password = string.Empty;

            btnLogin.Enabled = true;
            btnLogin.Visible = true;
            btnLogOut.Enabled = false;
            btnLogOut.Visible = false;
            txtEmployeeID.Enabled = true;
            txtEmployeeID.Visible = true;
            txtEmployeeID.Clear();
            txtEmployeeID.Select();
            txtEmployeeID.Focus();
            txtPsw.Enabled = true;
            txtPsw.Visible = true;
            txtPsw.Clear();
            lblEmployeeID.Enabled = false;
            lblEmployeeID.Visible = false;
            lblUserName.Enabled = false;
            lblUserName.Visible = false;
            lblTitlePsw.Text = "PASSWORD";

            dataGridView1.DataSource = null;
        }
    }
}