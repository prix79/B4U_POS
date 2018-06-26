// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 02-06-2018
// ***********************************************************************
// <copyright file="LoginRegister.cs" company="Beauty4u">
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
using System.IO;
using System.IO.Ports;
using System.Diagnostics;
using com.clover.remotepay.transport.remote;
using com.clover.remotepay.transport;
using Microsoft.Win32;

/// <summary>
/// The Register namespace.
/// </summary>
namespace Register
{
    /// <summary>
    /// Class LoginRegister.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class LoginRegister : Form
    {
        /// <summary>
        /// The clinet version
        /// </summary>
        public string ClinetVersion = "1807R";
        /// <summary>
        /// The connection
        /// </summary>
        public SqlConnection conn;
        /// <summary>
        /// The connection hq
        /// </summary>
        public SqlConnection connHQ;
        /// <summary>
        /// The connection other store
        /// </summary>
        public SqlConnection connOtherStore;
        /// <summary>
        /// The CMD1
        /// </summary>
        public SqlCommand cmd1;
        /// <summary>
        /// The CMD2
        /// </summary>
        public SqlCommand cmd2;
        /// <summary>
        /// The CMD3
        /// </summary>
        public SqlCommand cmd3;
        /// <summary>
        /// The CMD4
        /// </summary>
        public SqlCommand cmd4;
        /// <summary>
        /// The CMD5
        /// </summary>
        public SqlCommand cmd5;
        /// <summary>
        /// The CMD6
        /// </summary>
        public SqlCommand cmd6;
        /// <summary>
        /// The CMD7
        /// </summary>
        public SqlCommand cmd7;
        /// <summary>
        /// The CMD8
        /// </summary>
        public SqlCommand cmd8;
        /// <summary>
        /// The server connection string
        /// </summary>
        public string serverConnectionString;
        /// <summary>
        /// The names collection
        /// </summary>
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        /// <summary>
        /// The store name
        /// </summary>
        public string storeName;
        /// <summary>
        /// The cash register
        /// </summary>
        public string cashRegister;
        /// <summary>
        /// The employee identifier
        /// </summary>
        public string employeeID;
        /// <summary>
        /// The password
        /// </summary>
        public string password;
        /// <summary>
        /// The user level
        /// </summary>
        public int userLevel = 0;

        /// <summary>
        /// The b4 uhqip
        /// </summary>
        public string B4UHQIP;
        /// <summary>
        /// The thip
        /// </summary>
        public string THIP;
        /// <summary>
        /// The ohip
        /// </summary>
        public string OHIP;
        /// <summary>
        /// The umip
        /// </summary>
        public string UMIP;
        /// <summary>
        /// The chip
        /// </summary>
        public string CHIP;
        /// <summary>
        /// The wmip
        /// </summary>
        public string WMIP;
        /// <summary>
        /// The cvip
        /// </summary>
        public string CVIP;
        /// <summary>
        /// The pwip
        /// </summary>
        public string PWIP;
        /// <summary>
        /// The wbip
        /// </summary>
        public string WBIP;
        /// <summary>
        /// The wdip
        /// </summary>
        public string WDIP;
        /// <summary>
        /// The gbip
        /// </summary>
        public string GBIP;
        /// <summary>
        /// The bwip
        /// </summary>
        public string BWIP;

        /// <summary>
        /// The b4 uhqdb
        /// </summary>
        public string B4UHQDB;
        /// <summary>
        /// The THDB
        /// </summary>
        public string THDB;
        /// <summary>
        /// The ohdb
        /// </summary>
        public string OHDB;
        /// <summary>
        /// The umdb
        /// </summary>
        public string UMDB;
        /// <summary>
        /// The WMDB
        /// </summary>
        public string WMDB;
        /// <summary>
        /// The CVDB
        /// </summary>
        public string CVDB;
        /// <summary>
        /// The CHDB
        /// </summary>
        public string CHDB;
        /// <summary>
        /// The PWDB
        /// </summary>
        public string PWDB;
        /// <summary>
        /// The WBDB
        /// </summary>
        public string WBDB;
        /// <summary>
        /// The WDDB
        /// </summary>
        public string WDDB;
        /// <summary>
        /// The GBDB
        /// </summary>
        public string GBDB;
        /// <summary>
        /// The BWDB
        /// </summary>
        public string BWDB;

        /// <summary>
        /// The dbuid
        /// </summary>
        public string DBUID;
        /// <summary>
        /// The DBPSW
        /// </summary>
        public string DBPSW;
        /// <summary>
        /// The SQL port
        /// </summary>
        public string sqlPort;

        /// <summary>
        /// The lr store code
        /// </summary>
        public string LRStoreCode;
        /// <summary>
        /// The lr store street
        /// </summary>
        public string LRStoreStreet;
        /// <summary>
        /// The lr store city
        /// </summary>
        public string LRStoreCity;
        /// <summary>
        /// The lr store state
        /// </summary>
        public string LRStoreState;
        /// <summary>
        /// The lr store zip code
        /// </summary>
        public string LRStoreZipCode;
        /// <summary>
        /// The lr store telephone
        /// </summary>
        public string LRStoreTelephone;
        /// <summary>
        /// The lr store street margin
        /// </summary>
        public int LRStoreStreetMargin;
        /// <summary>
        /// The lr store city state margin
        /// </summary>
        public int LRStoreCityStateMargin;
        /// <summary>
        /// The lr store telephone margin
        /// </summary>
        public int LRStoreTelephoneMargin;
        /// <summary>
        /// The lr store tax rate
        /// </summary>
        public double LRStoreTaxRate;
        /// <summary>
        /// The lr store pc charge path
        /// </summary>
        public string LRStorePcChargePath;
        /// <summary>
        /// The lr store processor
        /// </summary>
        public string LRStoreProcessor;
        /// <summary>
        /// The lr store merchant number
        /// </summary>
        public string LRStoreMerchantNum;
        /// <summary>
        /// The lr store pc charge user1
        /// </summary>
        public string LRStorePcChargeUser1;
        /// <summary>
        /// The lr store pc charge user2
        /// </summary>
        public string LRStorePcChargeUser2;
        /// <summary>
        /// The lr store pc charge user3
        /// </summary>
        public string LRStorePcChargeUser3;
        /// <summary>
        /// The lr store pc charge user4
        /// </summary>
        public string LRStorePcChargeUser4;
        /// <summary>
        /// The lr store pc charge login identifier
        /// </summary>
        public string LRStorePcChargeLoginID;
        /// <summary>
        /// The lr store pc charge password
        /// </summary>
        public string LRStorePcChargePassword;

        /// <summary>
        /// The lr f1
        /// </summary>
        public string LRF1;
        /// <summary>
        /// The lr f2
        /// </summary>
        public string LRF2;
        /// <summary>
        /// The lr f3
        /// </summary>
        public string LRF3;
        /// <summary>
        /// The lr f4
        /// </summary>
        public string LRF4;
        /// <summary>
        /// The lr f5
        /// </summary>
        public string LRF5;
        /// <summary>
        /// The lr f6
        /// </summary>
        public string LRF6;
        /// <summary>
        /// The lr f7
        /// </summary>
        public string LRF7;
        /// <summary>
        /// The lr f8
        /// </summary>
        public string LRF8;
        /// <summary>
        /// The lr f9
        /// </summary>
        public string LRF9;
        /// <summary>
        /// The lr F10
        /// </summary>
        public string LRF10;
        /// <summary>
        /// The lr F11
        /// </summary>
        public string LRF11;
        /// <summary>
        /// The lr F12
        /// </summary>
        public string LRF12;

        /// <summary>
        /// The hw receipt printer name
        /// </summary>
        public string HWReceiptPrinterName;
        /// <summary>
        /// The HWVFD command type
        /// </summary>
        public string HWVFDCmdType;
        /// <summary>
        /// The HWVFD port
        /// </summary>
        public string HWVFDPort;
        /// <summary>
        /// The HWVFD baud rate
        /// </summary>
        public int HWVFDBaudRate = 9600;

        /// <summary>
        /// The cs comapny name
        /// </summary>
        public string CSComapnyName;
        /// <summary>
        /// The cs receipt last comment
        /// </summary>
        public string CSReceiptLastComment;

        /// <summary>
        /// The CDM opening MSG1
        /// </summary>
        public string CDMOpeningMsg1;
        /// <summary>
        /// The CDM opening MSG2
        /// </summary>
        public string CDMOpeningMsg2;
        /// <summary>
        /// The CDM closing MSG1
        /// </summary>
        public string CDMClosingMsg1;
        /// <summary>
        /// The CDM closing ms g2
        /// </summary>
        public string CDMClosingMSG2;

        /// <summary>
        /// The system master user name
        /// </summary>
        public string SystemMasterUserName;
        /// <summary>
        /// The system master password
        /// </summary>
        public string SystemMasterPassword;

        /// <summary>
        /// The b4 uhqcs
        /// </summary>
        public string B4UHQCS;
        /// <summary>
        /// The other store cs
        /// </summary>
        public string OtherStoreCS;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginRegister"/> class.
        /// </summary>
        public LoginRegister()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the LoginRegister control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void LoginRegister_Load(object sender, EventArgs e)
        {
            if (ProcessChecking() > 1)
            {
                MyMessageBox.ShowBox("REGISTER CLIENT IS ALREADY RUNNING...", "ERROR");
                Application.Exit();
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbStoreName control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmbStoreName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbStoreName.Text == "TEMPLE HILLS")
                {
                    //serverConnectionString = "Server=HQ-SERVER;Database=TempleHills;UID=ssk;Password=cherry";
                    serverConnectionString = "Data Source=173.167.197.49,41479;Network Library=DBMSSOCN;Initial Catalog=TempleHills;User ID=ssk;Password=cherry";
                    conn = new SqlConnection(serverConnectionString);
                }
                else if (cmbStoreName.Text == "OXON HILL")
                {
                    serverConnectionString = "Server=OH-SERVER;Database=OxonHill;UID=ssk;Password=cherry";
                    conn = new SqlConnection(serverConnectionString);
                }
                else if (cmbStoreName.Text == "UPPER MARLBORO")
                {
                    serverConnectionString = "Server=KTSC-SERVER;Database=KTSC;UID=ssk;Password=cherry";
                    //serverConnectionString = "Data Source=;Network Library=DBMSSOCN;Initial Catalog=;User ID=;Password=";                    
                    conn = new SqlConnection(serverConnectionString);
                }
                else if (cmbStoreName.Text == "CAPITOL HEIGHTS")
                {
                    serverConnectionString = "Server=CH-SERVER;Database=CapitolHeights;UID=ssk;Password=cherry";
                    //serverConnectionString = "Data Source=, ;Network Library=DBMSSOCN;Initial Catalog=;User ID=;Password=";
                    conn = new SqlConnection(serverConnectionString);
                }
                else if (cmbStoreName.Text == "WINDSOR MILL")
                {
                    serverConnectionString = "Server=WM-SERVER;Database=WindsorMill;UID=ssk;Password=cherry";
                    //serverConnectionString = "Data Source= ;Network Library=DBMSSOCN;Initial Catalog=;User ID=;Password=";
                    conn = new SqlConnection(serverConnectionString);
                }
                else if (cmbStoreName.Text == "CATONSVILLE")
                {
                    serverConnectionString = "Server=CV-SERVER;Database=Catonsville;UID=ssk;Password=cherry";
                    conn = new SqlConnection(serverConnectionString);
                }
                else if (cmbStoreName.Text == "PRINCE WILLIAM")
                {
                    serverConnectionString = "Server=PW-SERVER;Database=PrinceWilliam;UID=ssk;Password=cherry";
                    //serverConnectionString = "Data Source=;Network Library=DBMSSOCN;Initial Catalog=PrinceWilliam;User ID=;Password=";
                    conn = new SqlConnection(serverConnectionString);
                }
                else if (cmbStoreName.Text == "WOODBRIDGE")
                {
                    serverConnectionString = "Server=WB-SERVER;Database=Woodbridge;UID=ssk;Password=cherry";
                    //serverConnectionString = "Data Source=, ;Network Library=DBMSSOCN;Initial Catalog=;User ID=;Password=";
                    conn = new SqlConnection(serverConnectionString);
                }
                else if (cmbStoreName.Text == "WALDORF")
                {
                    //serverConnectionString = "Server=WD-SERVER;Database=Waldorf;UID=ssk;Password=cherry";
                    serverConnectionString = "Data Source=23.24.125.205,41479;Network Library=DBMSSOCN;Initial Catalog=Waldorf;User ID=ssk;Password=cherry";
                    conn = new SqlConnection(serverConnectionString);
                }

                else if (cmbStoreName.Text == "GAITHERSBURG")
                {
                    //serverConnectionString = "Server=GB-SERVER;Database=Gaithersburg;UID=ssk;Password=cherry";
                    serverConnectionString = "Data Source=;Network Library=DBMSSOCN;Initial Catalog=;User ID=;Password=";
                    conn = new SqlConnection(serverConnectionString);
                }
                else if (cmbStoreName.Text == "BOWIE")
                {
                    serverConnectionString = "Server=BW-SERVER;Database=Bowie;UID=ssk;Password=cherry";
                    conn = new SqlConnection(serverConnectionString);
                }
                else if (cmbStoreName.Text == "TEST")
                {
                    serverConnectionString = "Server=HQ-DEVELOPER;Database=TestDB;UID=ssk;Password=cherry";
                    conn = new SqlConnection(serverConnectionString);
                }
                else
                {
                    MyMessageBox.ShowBox("INVALID STORE NAME", "ERROR");
                    return;
                }

                SqlDataReader dReader;
                SqlDataAdapter adapt1 = new SqlDataAdapter();
                SqlDataAdapter adapt2 = new SqlDataAdapter();
                SqlDataAdapter adapt3 = new SqlDataAdapter();
                SqlDataAdapter adapt4 = new SqlDataAdapter();
                SqlDataAdapter adapt5 = new SqlDataAdapter();
                SqlDataAdapter adapt6 = new SqlDataAdapter();
                SqlDataAdapter adapt7 = new SqlDataAdapter();
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();
                DataTable dt4 = new DataTable();
                DataTable dt5 = new DataTable();
                DataTable dt6 = new DataTable();
                DataTable dt7 = new DataTable();
                cmd1 = new SqlCommand("Select Distinct empLoginID From Employee Where empStatus='True' Order By empLoginID Asc", conn);
                cmd1.CommandType = CommandType.Text;
                cmd2 = new SqlCommand("Loading_StoreBasicSetup", conn);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Add("@StoreName", SqlDbType.NVarChar).Value = cmbStoreName.Text.Trim().ToUpper();
                cmd3 = new SqlCommand("Loading_ShortcutKey", conn);
                cmd3.CommandType = CommandType.StoredProcedure;
                cmd4 = new SqlCommand("Loading_HardwareSetup", conn);
                cmd4.CommandType = CommandType.StoredProcedure;
                cmd5 = new SqlCommand("Loading_CompanySetup", conn);
                cmd5.CommandType = CommandType.StoredProcedure;
                cmd6 = new SqlCommand("Loading_CustomerDisplayMsg", conn);
                cmd6.CommandType = CommandType.StoredProcedure;
                cmd7 = new SqlCommand("Loading_ConnectionInfo", conn);
                cmd7.CommandType = CommandType.StoredProcedure;
                cmd8 = new SqlCommand("Loading_AdminOption", conn);
                cmd8.CommandType = CommandType.StoredProcedure;

                conn.Open();
                dReader = cmd1.ExecuteReader();
                if (dReader.HasRows == true)
                {
                    while (dReader.Read())
                        namesCollection.Add(dReader["empLoginID"].ToString());
                }
                else
                {
                    MyMessageBox.ShowBox("ACTIVE EMPLOYEE NOT FOUND", "ERROR");

                }
                dReader.Close();
                adapt1.SelectCommand = cmd2;
                adapt2.SelectCommand = cmd3;
                adapt3.SelectCommand = cmd4;
                adapt4.SelectCommand = cmd5;
                adapt5.SelectCommand = cmd6;
                adapt6.SelectCommand = cmd7;
                adapt7.SelectCommand = cmd8;
                adapt1.Fill(dt1);
                adapt2.Fill(dt2);
                adapt3.Fill(dt3);
                adapt4.Fill(dt4);
                adapt5.Fill(dt5);
                adapt6.Fill(dt6);
                adapt7.Fill(dt7);
                conn.Close();

                txtEmployeeID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtEmployeeID.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtEmployeeID.AutoCompleteCustomSource = namesCollection;

                dataGridView1.DataSource = dt1;
                dataGridView2.DataSource = dt2;
                dataGridView3.DataSource = dt3;
                dataGridView4.DataSource = dt4;
                dataGridView5.DataSource = dt5;
                dataGridView6.DataSource = dt6;
                dataGridView7.DataSource = dt7;

                storeName = cmbStoreName.Text.Trim().ToUpper();
                LRStoreCode = Convert.ToString(dataGridView1.Rows[0].Cells[1].Value);
                LRStoreStreet = Convert.ToString(dataGridView1.Rows[0].Cells[2].Value);
                LRStoreCity = Convert.ToString(dataGridView1.Rows[0].Cells[3].Value);
                LRStoreState = Convert.ToString(dataGridView1.Rows[0].Cells[4].Value);
                LRStoreZipCode = Convert.ToString(dataGridView1.Rows[0].Cells[5].Value);
                LRStoreTelephone = Convert.ToString(dataGridView1.Rows[0].Cells[6].Value);
                LRStoreStreetMargin = Convert.ToInt16(dataGridView1.Rows[0].Cells[7].Value);
                LRStoreCityStateMargin = Convert.ToInt16(dataGridView1.Rows[0].Cells[8].Value);
                LRStoreTelephoneMargin = Convert.ToInt16(dataGridView1.Rows[0].Cells[9].Value);
                LRStoreTaxRate = Convert.ToDouble(dataGridView1.Rows[0].Cells[10].Value);
                LRStorePcChargePath = Convert.ToString(dataGridView1.Rows[0].Cells[11].Value);
                LRStoreProcessor = Convert.ToString(dataGridView1.Rows[0].Cells[12].Value);
                LRStoreMerchantNum = Convert.ToString(dataGridView1.Rows[0].Cells[13].Value);
                LRStorePcChargeUser1 = Convert.ToString(dataGridView1.Rows[0].Cells[14].Value);
                LRStorePcChargeUser2 = Convert.ToString(dataGridView1.Rows[0].Cells[15].Value);
                LRStorePcChargeUser3 = Convert.ToString(dataGridView1.Rows[0].Cells[16].Value);
                LRStorePcChargeUser4 = Convert.ToString(dataGridView1.Rows[0].Cells[17].Value);
                LRStorePcChargeLoginID = Convert.ToString(dataGridView1.Rows[0].Cells[18].Value).Trim();
                LRStorePcChargePassword = Convert.ToString(dataGridView1.Rows[0].Cells[19].Value).Trim();

                LRF1 = Convert.ToString(dataGridView2.Rows[0].Cells[0].Value);
                LRF2 = Convert.ToString(dataGridView2.Rows[0].Cells[1].Value);
                LRF3 = Convert.ToString(dataGridView2.Rows[0].Cells[2].Value);
                LRF4 = Convert.ToString(dataGridView2.Rows[0].Cells[3].Value);
                LRF5 = Convert.ToString(dataGridView2.Rows[0].Cells[4].Value);
                LRF6 = Convert.ToString(dataGridView2.Rows[0].Cells[5].Value);
                LRF7 = Convert.ToString(dataGridView2.Rows[0].Cells[6].Value);
                LRF8 = Convert.ToString(dataGridView2.Rows[0].Cells[7].Value);
                LRF9 = Convert.ToString(dataGridView2.Rows[0].Cells[8].Value);
                LRF10 = Convert.ToString(dataGridView2.Rows[0].Cells[9].Value);
                LRF11 = Convert.ToString(dataGridView2.Rows[0].Cells[10].Value);
                LRF12 = Convert.ToString(dataGridView2.Rows[0].Cells[11].Value);

                HWReceiptPrinterName = Convert.ToString(dataGridView3.Rows[0].Cells[2].Value);
                HWVFDCmdType = Convert.ToString(dataGridView3.Rows[0].Cells[4].Value);
                HWVFDPort = Convert.ToString(dataGridView3.Rows[0].Cells[6].Value);
                HWVFDBaudRate = Convert.ToInt16(dataGridView3.Rows[0].Cells[7].Value);

                CSComapnyName = Convert.ToString(dataGridView4.Rows[0].Cells[0].Value);
                CSReceiptLastComment = Convert.ToString(dataGridView4.Rows[0].Cells[1].Value);

                CDMOpeningMsg1 = Convert.ToString(dataGridView5.Rows[0].Cells[0].Value);
                CDMOpeningMsg2 = Convert.ToString(dataGridView5.Rows[0].Cells[1].Value);
                CDMClosingMsg1 = Convert.ToString(dataGridView5.Rows[0].Cells[2].Value);
                CDMClosingMSG2 = Convert.ToString(dataGridView5.Rows[0].Cells[3].Value);

                B4UHQIP = Convert.ToString(dataGridView6.Rows[0].Cells[4].Value);
                //B4UWHIP = Convert.ToString(dataGridView6.Rows[1].Cells[4].Value);
                THIP = Convert.ToString(dataGridView6.Rows[2].Cells[4].Value);
                OHIP = Convert.ToString(dataGridView6.Rows[3].Cells[4].Value);
                UMIP = Convert.ToString(dataGridView6.Rows[4].Cells[4].Value);
                CHIP = Convert.ToString(dataGridView6.Rows[5].Cells[4].Value);
                WMIP = Convert.ToString(dataGridView6.Rows[6].Cells[4].Value);
                CVIP = Convert.ToString(dataGridView6.Rows[7].Cells[4].Value);
                PWIP = Convert.ToString(dataGridView6.Rows[8].Cells[4].Value);
                WBIP = Convert.ToString(dataGridView6.Rows[9].Cells[4].Value);
                WDIP = Convert.ToString(dataGridView6.Rows[10].Cells[4].Value);
                GBIP = Convert.ToString(dataGridView6.Rows[11].Cells[4].Value);
                BWIP = Convert.ToString(dataGridView6.Rows[12].Cells[4].Value);

                B4UHQDB = Convert.ToString(dataGridView6.Rows[0].Cells[5].Value);
                //B4UWHDB = Convert.ToString(dataGridView6.Rows[1].Cells[5].Value);
                THDB = Convert.ToString(dataGridView6.Rows[2].Cells[5].Value);
                OHDB = Convert.ToString(dataGridView6.Rows[3].Cells[5].Value);
                UMDB = Convert.ToString(dataGridView6.Rows[4].Cells[5].Value);
                CHDB = Convert.ToString(dataGridView6.Rows[5].Cells[5].Value);
                WMDB = Convert.ToString(dataGridView6.Rows[6].Cells[5].Value);
                CVDB = Convert.ToString(dataGridView6.Rows[7].Cells[5].Value);
                PWDB = Convert.ToString(dataGridView6.Rows[8].Cells[5].Value);
                WBDB = Convert.ToString(dataGridView6.Rows[9].Cells[5].Value);
                WDDB = Convert.ToString(dataGridView6.Rows[10].Cells[5].Value);
                GBDB = Convert.ToString(dataGridView6.Rows[11].Cells[5].Value);
                BWDB = Convert.ToString(dataGridView6.Rows[12].Cells[5].Value);

                DBUID = Convert.ToString(dataGridView6.Rows[0].Cells[6].Value);
                DBPSW = Convert.ToString(dataGridView6.Rows[0].Cells[7].Value);
                sqlPort = Convert.ToString(dataGridView6.Rows[0].Cells[8].Value);

                SystemMasterUserName = Convert.ToString(dataGridView7.Rows[0].Cells[6].Value);
                SystemMasterPassword = Convert.ToString(dataGridView7.Rows[0].Cells[7].Value);

                B4UHQCS = "Data Source=" + B4UHQIP + ", " + sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + B4UHQDB + ";User ID=" + DBUID + ";Password=" + DBPSW;
            }
            catch
            {
                MyMessageBox.ShowBox("CAN NOT CONNECT THE SERVER...", "ERROR");
                cmbStoreName.SelectAll();
                cmbStoreName.Focus();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnLogin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string sDirPath = Application.StartupPath;
            DirectoryInfo dir = new DirectoryInfo(sDirPath);
            FileInfo[] files;

            files = dir.GetFiles("*.temp", SearchOption.AllDirectories);

            foreach (FileInfo file in files)
            {
                if (file.Attributes == FileAttributes.ReadOnly)
                    file.Attributes = FileAttributes.Normal;
                file.Delete();
            }

            if (cmbStoreName.Text == "" | cmbCashRegister.Text == "" | txtEmployeeID.Text == "" | txtPsw.Text == "")
            {
                return;
            }
            else
            {
                employeeID = txtEmployeeID.Text.Trim().ToString().ToUpper();
                password = txtPsw.Text.Trim().ToString().ToUpper();

                if (employeeID == SystemMasterUserName & password == SystemMasterPassword)
                {
                    userLevel = 7;

                    storeName = cmbStoreName.Text.Trim().ToString().ToUpper();
                    cashRegister = cmbCashRegister.Text.Trim().ToString().ToUpper();

                    this.Hide();
                    this.Visible = false;

                    MyMessageBox.ShowBox("CURRENT SYSTEM CLOCK\n" + DateTime.Now.ToString(), "INFORMATION");

                    MainForm mainForm = new MainForm(cashRegister, employeeID, serverConnectionString);
                    mainForm.parentForm = this;
                    mainForm.ShowDialog();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("Get_User_LogIn_Info", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@empLoginID", SqlDbType.NVarChar).Value = employeeID.ToUpper().ToString();
                    cmd.Parameters.Add("@empPassword", SqlDbType.NVarChar).Value = password;
                    SqlParameter UserName_Param = cmd.Parameters.Add("@empFirstName", SqlDbType.NVarChar, 50);
                    SqlParameter UserLevel_Param = cmd.Parameters.Add("@empAccessLv", SqlDbType.TinyInt);
                    UserName_Param.Direction = ParameterDirection.Output;
                    UserLevel_Param.Direction = ParameterDirection.Output;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    if (cmd.Parameters["@empFirstName"].Value == DBNull.Value)
                    {
                        MyMessageBox.ShowBox("INVALID ACCOUNT", "ERROR");
                        txtPsw.SelectAll();
                        txtPsw.Focus();
                    }
                    else
                    {
                        userLevel = Convert.ToInt16(cmd.Parameters["@empAccessLv"].Value);

                        storeName = cmbStoreName.Text.Trim().ToString().ToUpper();
                        cashRegister = cmbCashRegister.Text.Trim().ToString().ToUpper();

                        this.Hide();
                        this.Visible = false;

                        MyMessageBox.ShowBox("CURRENT SYSTEM CLOCK\n" + DateTime.Now.ToString(), "INFORMATION");

                        MainForm mainForm = new MainForm(cashRegister, employeeID, serverConnectionString);
                        mainForm.parentForm = this;
                        mainForm.ShowDialog();
                    }
                }
            }
        }

        /// <summary>
        /// Others the store connection string.
        /// </summary>
        /// <param name="sc">The sc.</param>
        /// <returns>System.String.</returns>
        public string OtherStoreConnectionString(string sc)
        {
            OtherStoreCS = string.Empty;

            if (sc == "TH")
            {
                OtherStoreCS = "Data Source=" + THIP + ", " + sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + THDB + ";User ID=" + DBUID + ";Password=" + DBPSW;
            }
            else if (sc == "OH")
            {
                OtherStoreCS = "Data Source=" + OHIP + ", " + sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + OHDB + ";User ID=" + DBUID + ";Password=" + DBPSW;
            }
            else if (sc == "UM")
            {
                OtherStoreCS = "Data Source=" + UMIP + ", " + sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + UMDB + ";User ID=" + DBUID + ";Password=" + DBPSW;
            }
            else if (sc == "CH")
            {
                OtherStoreCS = "Data Source=" + CHIP + ", " + sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + CHDB + ";User ID=" + DBUID + ";Password=" + DBPSW;
            }
            else if (sc == "WM")
            {
                OtherStoreCS = "Data Source=" + WMIP + ", " + sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + WMDB + ";User ID=" + DBUID + ";Password=" + DBPSW;
            }
            else if (sc == "CV")
            {
                OtherStoreCS = "Data Source=" + CVIP + ", " + sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + CVDB + ";User ID=" + DBUID + ";Password=" + DBPSW;
            }
            else if (sc == "PW")
            {
                OtherStoreCS = "Data Source=" + PWIP + ", " + sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + PWDB + ";User ID=" + DBUID + ";Password=" + DBPSW;
            }
            else if (sc == "WB")
            {
                OtherStoreCS = "Data Source=" + WBIP + ", " + sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + WBDB + ";User ID=" + DBUID + ";Password=" + DBPSW;
            }
            else if (sc == "WD")
            {
                OtherStoreCS = "Data Source=" + WDIP + ", " + sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + WDDB + ";User ID=" + DBUID + ";Password=" + DBPSW;
            }
            else if (sc == "GB")
            {
                OtherStoreCS = "Data Source=" + GBIP + ", " + sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + GBDB + ";User ID=" + DBUID + ";Password=" + DBPSW;
            }
            else if (sc == "BW")
            {
                OtherStoreCS = "Data Source=" + BWIP + ", " + sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + BWDB + ";User ID=" + DBUID + ";Password=" + DBPSW;
            }
            else if (sc == "TEST")
            {
                OtherStoreCS = "Data Source=, 1433;Network Library=DBMSSOCN;Initial Catalog=;User ID=;Password=";
            }

            return OtherStoreCS;
        }

        /// <summary>
        /// Handles the Click event of the btnClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Processes the checking.
        /// </summary>
        /// <returns>System.Int32.</returns>
        private int ProcessChecking()
        {
            Process[] procList = Process.GetProcesses();
            int existProc = 0;
            string procName = "";

            for (int i = 0; i < procList.Length; i++)
            {
                procName = procList[i].ProcessName;

                if (procName == "Register")
                {
                    existProc++;
                }
            }

            return existProc;
        }
    }
}