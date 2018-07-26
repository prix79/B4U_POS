using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
using System.Management;
using System.Globalization;
using System.Threading;

namespace Management
{
    public partial class LogInManagements : Form
    {
        public string ClinetVersion = "1803M";
        public string workgroupName;
        public string workgroupSC;
        public SqlConnection conn;
        public string serverConnectionString;

        public string B4UHQCS = "";
        public string B4UWHCS = "";
        public string CHCS = "";
        public string OHCS = "";
        public string WBCS = "";
        public string CVCS = "";
        public string UMCS = "";
        public string WMCS = "";
        public string THCS = "";
        public string WDCS = "";
        public string PWCS = "";
        public string GBCS = "";
        public string BWCS = "";
        public string Test1CS = "";
        public string Test2CS = "";

        //Connection string example : "Data Source=,;Network Library=DBMSSOCN;Initial Catalog=;UID=;Password=";

        public string B4UHQCS_IP, B4UWHCS_IP, THCS_IP, OHCS_IP, UMCS_IP, CHCS_IP, WMCS_IP, CVCS_IP, PWCS_IP, WBCS_IP, WDCS_IP, GBCS_IP, BWCS_IP;

        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        public string StoreCode;
        public string storeName;
        public string employeeID;
        public string password;
        public int userLevel = 0;
        public int originalUserLevel = 0;

        public string storeStreet = string.Empty;
        public string storeCityStateZipCode = string.Empty;
        public string storeTelephone = string.Empty;
        public string storeFax = string.Empty;

        public int btnManagementInventory;
        public int btnManagementPromotion;
        public int btnManagementPOReceiving;
        public int btnManagementEmployee;
        public int btnManagementCustomer;
        public int btnManagementReport;
        public int btnManagementAdminTools;
        public int btnManagementChangeStore;
        public int btnInventoryRegisterNewItem;
        public int btnInventoryUpdateItem;
        public int btnInventoryDeleteItem;
        public int btnInventoryTargetField;
        public int btnInventoryExcel;
        public int btnInventoryDataTransfer;
        public int btnInventoryGenerateNewUpc;
        public int btnPOReceivingSearchPOList;
        public int btnPOReceivingEditCostPrice;
        public int btnPOReceivingSoldItemList;
        public int btnPOReceivingExcel;
        public int btnPOReceivingDeletePO;
        public int btnEmployeeUpdate;
        public int btnEmployeeDelete;
        public int btnEmployeeEditTimeCard;
        public int btnEmployeeExcel;
        public int btnCustomerUpdate;
        public int btnCustomerDelete;
        public int btnCustomerExcel;
        public int btnReportTimeCard;
        public int btnReportSalesByStore;

        public int CahierLV;
        public int SalesAssociateLV;
        public int AssistantSectionManagerLV;
        public int AssistantStoreManagerLV;
        public int SectionManagerLV;
        public int FloorManagerLV;
        public int StoreManagerLV;
        public int GeneralManagerLV;
        public int DirectorLV;
        public int VicePresidentLV;
        public int PresidentLV;
        public int SystemAdministratorLV;

        public string B4UHQIP;
        public string B4UWHIP;
        public string CHIP;
        public string OHIP;
        public string WBIP;
        public string CVIP;
        public string UMIP;
        public string WMIP;
        public string THIP;
        public string WDIP;
        public string PWIP;
        public string GBIP;
        public string BWIP;

        public string B4UHQDB;
        public string B4UWHDB;
        public string CHDB;
        public string OHDB;
        public string WBDB;
        public string CVDB;
        public string UMDB;
        public string WMDB;
        public string THDB;
        public string WDDB;
        public string PWDB;
        public string GBDB;
        public string BWDB;

        public string sqlPort;

        public string DBUID;
        public string DBPSW;
        public string specialCode;
        public string noBarcodeAdmin1;
        public string noBarcodeAdmin2;
        public string noBarcodeAdmin3;
        
        public bool boolBtnConnect = false;

        public string SystemMasterUserName;
        public string SystemMasterPassword;
        public string HQStoreCode = "B4UHQ";
        public string WarehouseName1 = "BEAUTY 4U WAREHOUSE";
        public string WarehouseStoreCode1 = "B4UWH";

        public string OtherStoreCS;
        public string OtherStoreNM;
       
        public LogInManagements()
        {
            InitializeComponent();
        }

        private void LogInManagements_Load(object sender, EventArgs e)
        {
            if (cmbStoreName.Items.Count > 0)
                cmbStoreName.SelectedIndex = 0;

            if (cmbStoreName.Text != "TEST" && cmbStoreName.Text != "BEAUTY 4U HEADQUARTERS")
            {
                try
                {
                    ManagementObjectSearcher mosComputer = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");

                    foreach (ManagementObject moComputer in mosComputer.Get())
                    {
                        if (moComputer["Workgroup"] != null)
                        {
                            workgroupName = moComputer["Workgroup"].ToString();

                            if (workgroupName.Substring(0, 8) == "BEAUTY4U")
                            {
                                if (Properties.Settings.Default.IsRestarting == false)
                                    MessageBox.Show("This computer is in " + moComputer["Workgroup"].ToString() + ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                workgroupSC = workgroupName.Substring(9, 2).ToUpper();

                                if (workgroupSC == "HQ")
                                {
                                    if (System.Environment.MachineName == "HQ-WH-DESKTOP")
                                    {
                                        cmbStoreName.Items.Add("BEAUTY 4U WAREHOUSE");
                                        cmbStoreName.SelectedIndex = 0;
                                        btnConnect_Click(null, null);
                                    }
                                    else
                                    {
                                        cmbStoreName.Items.Add(OtherStoreName("B4U" + workgroupSC));
                                        cmbStoreName.SelectedIndex = 0;
                                        btnConnect_Click(null, null);
                                    }
                                }
                                else if (workgroupSC == "WH")
                                {
                                    cmbStoreName.Items.Add(OtherStoreName("B4U" + workgroupSC));
                                    cmbStoreName.SelectedIndex = 0;
                                    btnConnect_Click(null, null);
                                }
                                else
                                {
                                    cmbStoreName.Items.Add(OtherStoreName(workgroupSC));
                                    cmbStoreName.SelectedIndex = 0;
                                    btnConnect_Click(null, null);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invaild workgroup name, this client will be shut down...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Application.Exit();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invaild workgroup name, this client will be shut down...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Invaild workgroup name, this client will be shut down...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (btnConnect.Enabled == true)
            {
                MessageBox.Show("Please connect the server...", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbStoreName.Text == "" | cmbStoreName.SelectedIndex < 0 | txtEmployeeID.Text == "" | txtPsw.Text == "")
            {
            }
            else
            {
                employeeID = txtEmployeeID.Text.Trim().ToString().ToUpper();
                password = txtPsw.Text.Trim().ToString().ToUpper();

                if (employeeID == SystemMasterUserName & password == SystemMasterPassword)
                {
                    userLevel = 7;
                    originalUserLevel = userLevel;

                    this.Hide();
                    this.Visible = false;

                    ManagementsMain managementsMainForm = new ManagementsMain();
                    managementsMainForm.parentForm = this;
                    managementsMainForm.ShowDialog();
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
                        //MyMessageBox.ShowBox("INVALID ACCOUNT", "ERROR");
                        MessageBox.Show("INVALID ACCOUNT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPsw.SelectAll();
                        txtPsw.Focus();
                        return;
                    }
                    else
                    {
                        userLevel = Convert.ToInt16(cmd.Parameters["@empAccessLv"].Value);
                        originalUserLevel = userLevel;

                        if (userLevel >= SystemAdministratorLV)
                        {
                            this.Hide();
                            this.Visible = false;

                            ManagementsMain managementsMainForm = new ManagementsMain();
                            managementsMainForm.parentForm = this;
                            managementsMainForm.ShowDialog();
                        }
                        else
                        {
                            if (cmbStoreName.Text.Trim().ToString().ToUpper() == "TEST")
                            {
                                //MessageBox.Show("NOT AUTHORIZED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //return;

                                this.Hide();
                                this.Visible = false;

                                ManagementsMain managementsMainForm = new ManagementsMain();
                                managementsMainForm.parentForm = this;
                                managementsMainForm.ShowDialog();
                            }
                            else if (cmbStoreName.Text.Trim().ToString().ToUpper() == "BEAUTY 4U HEADQUARTERS")
                            {
                                this.Hide();
                                this.Visible = false;

                                ManagementsMain managementsMainForm = new ManagementsMain();
                                managementsMainForm.parentForm = this;
                                managementsMainForm.ShowDialog();
                            }
                            else if (cmbStoreName.Text.Trim().ToString().ToUpper() == "BEAUTY 4U WAREHOUSE")
                            {
                                this.Hide();
                                this.Visible = false;

                                ManagementsMain managementsMainForm = new ManagementsMain();
                                managementsMainForm.parentForm = this;
                                managementsMainForm.ShowDialog();
                            }
                            else
                            {
                                if (ProcessChecking() > 1)
                                {
                                    MessageBox.Show("Management client is already running...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Application.Exit();
                                }
                                else
                                {
                                    this.Hide();
                                    this.Visible = false;

                                    ManagementsMain managementsMainForm = new ManagementsMain();
                                    managementsMainForm.parentForm = this;
                                    managementsMainForm.ShowDialog();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LogInManagements_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
            
        public void btnConnect_Click(object sender, EventArgs e)
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

            //try
            //{
                if (cmbStoreName.Text == "BEAUTY 4U HEADQUARTERS")
                {
                    serverConnectionString = B4UHQCS;
                    conn = new SqlConnection(serverConnectionString);

                    SqlDataReader dReader;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "Select Distinct empLoginID From Employee Where empStatus='True' and empSCCurrent='B4UHQ' Order by empLoginID asc";
                    cmd.CommandTimeout = 5;
                    conn.Open();
                    dReader = cmd.ExecuteReader();
                    if (dReader.HasRows == true)
                    {
                        while (dReader.Read())
                            namesCollection.Add(dReader["empLoginID"].ToString());
                    }
                    else
                    {
                        //MyMessageBox.ShowBox("USER DATA NOT FOUND", "ERROR");
                        MessageBox.Show("Data not found");
                    }

                    dReader.Close();
                    conn.Close();

                    storeName = cmbStoreName.Text.Trim().ToString().ToUpper();
                    //MessageBox.Show(storeName + " SERVER IS CONNECTED!", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //StoreCode = "CH";

                    //storeStreet = "9185 C. CENTRAL AVE";
                    //storeCityState = "CAPITOL HEIGHTS, MD 20743";
                    //storeTelephone = "TEL : 301-808-1317";
                    //storeFax = "FAX : 301-808-1318";
                }
                else if (cmbStoreName.Text == "BEAUTY 4U WAREHOUSE")
                {
                    serverConnectionString = B4UWHCS;
                    conn = new SqlConnection(serverConnectionString);

                    SqlDataReader dReader;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select Distinct empLoginID From Employee Where empStatus='True' Order by empLoginID asc";
                    conn.Open();
                    dReader = cmd.ExecuteReader();
                    if (dReader.HasRows == true)
                    {
                        while (dReader.Read())
                            namesCollection.Add(dReader["empLoginID"].ToString());
                    }
                    else
                    {
                        //MyMessageBox.ShowBox("USER DATA NOT FOUND", "ERROR");
                        MessageBox.Show("Data not found");
                    }

                    dReader.Close();
                    conn.Close();

                    storeName = cmbStoreName.Text.Trim().ToString().ToUpper();
                    //MessageBox.Show(storeName + " SERVER IS CONNECTED!", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //StoreCode = "KTSC";

                    //storeStreet = "10654 CAMPUS WAY SOUTH";
                    //storeCityState = "UPPER MARLBORO, MD 20774";
                    //storeTelephone = "TEL : 301-333-1430";
                    //storeFax = "FAX : 240-766-2011";
                }
                else if (cmbStoreName.Text == "CAPITOL HEIGHTS")
                {
                    serverConnectionString = CHCS;
                    conn = new SqlConnection(serverConnectionString);

                    SqlDataReader dReader;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "Select Distinct empLoginID From Employee Where empStatus='True' Order by empLoginID asc";
                    cmd.CommandTimeout = 5;
                    conn.Open();
                    dReader = cmd.ExecuteReader();
                    if (dReader.HasRows == true)
                    {
                        while (dReader.Read())
                            namesCollection.Add(dReader["empLoginID"].ToString());
                    }
                    else
                    {
                        //MyMessageBox.ShowBox("USER DATA NOT FOUND", "ERROR");
                        MessageBox.Show("Data not found");
                    }

                    dReader.Close();
                    conn.Close();

                    storeName = cmbStoreName.Text.Trim().ToString().ToUpper();
                    //MessageBox.Show(storeName + " SERVER IS CONNECTED!", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //StoreCode = "CH";

                    //storeStreet = "9185 C. CENTRAL AVE";
                    //storeCityState = "CAPITOL HEIGHTS, MD 20743";
                    //storeTelephone = "TEL : 301-808-1317";
                    //storeFax = "FAX : 301-808-1318";
                }
                else if (cmbStoreName.Text == "OXON HILL")
                {
                    serverConnectionString = OHCS;
                    conn = new SqlConnection(serverConnectionString);

                    SqlDataReader dReader;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select Distinct empLoginID From Employee Where empStatus='True' Order by empLoginID asc";
                    conn.Open();
                    dReader = cmd.ExecuteReader();
                    if (dReader.HasRows == true)
                    {
                        while (dReader.Read())
                            namesCollection.Add(dReader["empLoginID"].ToString());
                    }
                    else
                    {
                        //MyMessageBox.ShowBox("USER DATA NOT FOUND", "ERROR");
                        MessageBox.Show("Data not found");
                    }

                    dReader.Close();
                    conn.Close();

                    storeName = cmbStoreName.Text.Trim().ToString().ToUpper();
                    //MessageBox.Show(storeName + " SERVER IS CONNECTED!", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //StoreCode = "OH";

                    //storeStreet = "6333 LIVINGSTON ROAD";
                    //storeCityState = "OXON HILL, MD 20745";
                    //storeTelephone = "TEL : 301-567-0900";
                    //storeFax = "FAX : 301-567-5138";
                }
                else if (cmbStoreName.Text == "WOODBRIDGE")
                {
                    serverConnectionString = WBCS;
                    conn = new SqlConnection(serverConnectionString);

                    SqlDataReader dReader;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select Distinct empLoginID From Employee Where empStatus='True' Order by empLoginID asc";
                    conn.Open();
                    dReader = cmd.ExecuteReader();
                    if (dReader.HasRows == true)
                    {
                        while (dReader.Read())
                            namesCollection.Add(dReader["empLoginID"].ToString());
                    }
                    else
                    {
                        //MyMessageBox.ShowBox("USER DATA NOT FOUND", "ERROR");
                        MessageBox.Show("Data not found");
                    }

                    dReader.Close();
                    conn.Close();

                    storeName = cmbStoreName.Text.Trim().ToString().ToUpper();
                    //MessageBox.Show(storeName + " SERVER IS CONNECTED!", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //StoreCode = "WB";

                    //storeStreet = "14353 POTOMAC MILLS ROAD";
                    //storeCityState = "WOODBRIDGE, VA 22192";
                    //storeTelephone = "TEL : 703-497-2066";
                    //storeFax = "FAX : 703-497-2077";
                }
                else if (cmbStoreName.Text == "CATONSVILLE")
                {
                    serverConnectionString = CVCS;
                    conn = new SqlConnection(serverConnectionString);

                    SqlDataReader dReader;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select Distinct empLoginID From Employee Where empStatus='True' Order by empLoginID asc";
                    conn.Open();
                    dReader = cmd.ExecuteReader();
                    if (dReader.HasRows == true)
                    {
                        while (dReader.Read())
                            namesCollection.Add(dReader["empLoginID"].ToString());
                    }
                    else
                    {
                        //MyMessageBox.ShowBox("USER DATA NOT FOUND", "ERROR");
                        MessageBox.Show("Data not found");
                    }

                    dReader.Close();
                    conn.Close();

                    storeName = cmbStoreName.Text.Trim().ToString().ToUpper();
                    //MessageBox.Show(storeName + " SERVER IS CONNECTED!", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //StoreCode = "CV";

                    //storeStreet = "6510 BALTIMORE NATIONAL PIKE";
                    //storeCityState = "CATONSVILLE, MD 21228";
                    //storeTelephone = "TEL : 410-788-0395";
                    //storeFax = "FAX : 410-788-0413";
                }
                else if (cmbStoreName.Text == "UPPER MARLBORO")
                {
                    serverConnectionString = UMCS;
                    conn = new SqlConnection(serverConnectionString);

                    SqlDataReader dReader;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select Distinct empLoginID From Employee Where empStatus='True' Order by empLoginID asc";
                    conn.Open();
                    dReader = cmd.ExecuteReader();
                    if (dReader.HasRows == true)
                    {
                        while (dReader.Read())
                            namesCollection.Add(dReader["empLoginID"].ToString());
                    }
                    else
                    {
                        //MyMessageBox.ShowBox("USER DATA NOT FOUND", "ERROR");
                        MessageBox.Show("Data not found");
                    }

                    dReader.Close();
                    conn.Close();

                    storeName = cmbStoreName.Text.Trim().ToString().ToUpper();
                    //MessageBox.Show(storeName + " SERVER IS CONNECTED!", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //StoreCode = "UM";

                    //storeStreet = "10654 CAMPUS WAY SOUTH";
                    //storeCityState = "UPPER MARLBORO, MD 20774";
                    //storeTelephone = "TEL : 301-333-1430";
                    //storeFax = "FAX : 301-333-1432";
                }
                else if (cmbStoreName.Text == "WINDSOR MILL")
                {
                    serverConnectionString = WMCS;
                    conn = new SqlConnection(serverConnectionString);

                    SqlDataReader dReader;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select Distinct empLoginID From Employee Where empStatus='True' Order by empLoginID asc";
                    conn.Open();
                    dReader = cmd.ExecuteReader();
                    if (dReader.HasRows == true)
                    {
                        while (dReader.Read())
                            namesCollection.Add(dReader["empLoginID"].ToString());
                    }
                    else
                    {
                        //MyMessageBox.ShowBox("USER DATA NOT FOUND", "ERROR");
                        MessageBox.Show("Data not found");
                    }

                    dReader.Close();
                    conn.Close();

                    storeName = cmbStoreName.Text.Trim().ToString().ToUpper();
                    //MessageBox.Show(storeName + " SERVER IS CONNECTED!", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //StoreCode = "WM";

                    //storeStreet = "1727 ROLLING ROAD";
                    //storeCityState = "WINDSOR MILL, MD 21244";
                    //storeTelephone = "TEL : 410-298-8880";
                    //storeFax = "FAX : 410-298-8881";
                }
                else if (cmbStoreName.Text == "TEMPLE HILLS")
                {
                    serverConnectionString = THCS;
                    conn = new SqlConnection(serverConnectionString);

                    SqlDataReader dReader;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select Distinct empLoginID From Employee Where empStatus='True' Order by empLoginID asc";
                    conn.Open();
                    dReader = cmd.ExecuteReader();
                    if (dReader.HasRows == true)
                    {
                        while (dReader.Read())
                            namesCollection.Add(dReader["empLoginID"].ToString());
                    }
                    else
                    {
                        //MyMessageBox.ShowBox("USER DATA NOT FOUND", "ERROR");
                        MessageBox.Show("Data not found");
                    }

                    dReader.Close();
                    conn.Close();

                    storeName = cmbStoreName.Text.Trim().ToString().ToUpper();
                    //MessageBox.Show(storeName + " SERVER IS CONNECTED!", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //StoreCode = "CH";

                    //storeStreet = "9185 C. CENTRAL AVE";
                    //storeCityState = "CAPITOL HEIGHTS, MD 20743";
                    //storeTelephone = "TEL : 301-808-1317";
                    //storeFax = "FAX : 240-493-6747";
                }
                else if (cmbStoreName.Text == "WALDORF")
                {
                    serverConnectionString = WDCS;
                    conn = new SqlConnection(serverConnectionString);

                    SqlDataReader dReader;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select Distinct empLoginID From Employee Where empStatus='True' Order by empLoginID asc";
                    conn.Open();
                    dReader = cmd.ExecuteReader();
                    if (dReader.HasRows == true)
                    {
                        while (dReader.Read())
                            namesCollection.Add(dReader["empLoginID"].ToString());
                    }
                    else
                    {
                        //MyMessageBox.ShowBox("USER DATA NOT FOUND", "ERROR");
                        MessageBox.Show("Data not found");
                    }

                    dReader.Close();
                    conn.Close();

                    storeName = cmbStoreName.Text.Trim().ToString().ToUpper();
                    //storeFax = "FAX : 301-645-8223";
                }
                else if (cmbStoreName.Text == "PRINCE WILLIAM")
                {
                    serverConnectionString = PWCS;
                    conn = new SqlConnection(serverConnectionString);

                    SqlDataReader dReader;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select Distinct empLoginID From Employee Where empStatus='True' Order by empLoginID asc";
                    conn.Open();
                    dReader = cmd.ExecuteReader();
                    if (dReader.HasRows == true)
                    {
                        while (dReader.Read())
                            namesCollection.Add(dReader["empLoginID"].ToString());
                    }
                    else
                    {
                        //MyMessageBox.ShowBox("USER DATA NOT FOUND", "ERROR");
                        MessageBox.Show("Data not found");
                    }

                    dReader.Close();
                    conn.Close();

                    storeName = cmbStoreName.Text.Trim().ToString().ToUpper();
                    //storeFax = "FAX : 703-910-6379";
                }
                else if (cmbStoreName.Text == "GAITHERSBURG")
                {
                    serverConnectionString = GBCS;
                    conn = new SqlConnection(serverConnectionString);

                    SqlDataReader dReader;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select Distinct empLoginID From Employee Where empStatus='True' Order by empLoginID asc";
                    conn.Open();
                    dReader = cmd.ExecuteReader();
                    if (dReader.HasRows == true)
                    {
                        while (dReader.Read())
                            namesCollection.Add(dReader["empLoginID"].ToString());
                    }
                    else
                    {
                        //MyMessageBox.ShowBox("USER DATA NOT FOUND", "ERROR");
                        MessageBox.Show("Data not found");
                    }

                    dReader.Close();
                    conn.Close();

                    storeName = cmbStoreName.Text.Trim().ToString().ToUpper();
                    //storeFax = "FAX : 703-910-6379";
                }
                else if (cmbStoreName.Text == "BOWIE")
                {
                    serverConnectionString = BWCS;
                    conn = new SqlConnection(serverConnectionString);

                    SqlDataReader dReader;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select Distinct empLoginID From Employee Where empStatus='True' Order by empLoginID asc";
                    conn.Open();
                    dReader = cmd.ExecuteReader();
                    if (dReader.HasRows == true)
                    {
                        while (dReader.Read())
                            namesCollection.Add(dReader["empLoginID"].ToString());
                    }
                    else
                    {
                        //MyMessageBox.ShowBox("USER DATA NOT FOUND", "ERROR");
                        MessageBox.Show("Data not found");
                    }

                    dReader.Close();
                    conn.Close();

                    storeName = cmbStoreName.Text.Trim().ToString().ToUpper();
                    //storeFax = "FAX : 703-910-6379";
                }
                else if (cmbStoreName.Text == "TEST")
                {
                    serverConnectionString = Test1CS;
                    conn = new SqlConnection(serverConnectionString);

                    SqlDataReader dReader;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select Distinct empLoginID From Employee Where empStatus='True' Order by empLoginID asc";
                    conn.Open();
                    dReader = cmd.ExecuteReader();
                    if (dReader.HasRows == true)
                    {
                        while (dReader.Read())
                            namesCollection.Add(dReader["empLoginID"].ToString());
                    }
                    else
                    {
                        //MyMessageBox.ShowBox("USER DATA NOT FOUND", "ERROR");
                        MessageBox.Show("Data not found");
                    }

                    dReader.Close();
                    conn.Close();

                    storeName = "TEST";
                    //MessageBox.Show(storeName + " SERVER IS CONNECTED!", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //StoreCode = "KTSC";

                    //storeStreet = "10654 CAMPUS WAY SOUTH";
                    //storeCityState = "UPPER MARLBORO, MD 20774";
                    //storeTelephone = "TEL : 301-333-1430";
                    //storeFax = "FAX : 240-414-7201";
                }
                else if (cmbStoreName.Text == "TEST2")
                {
                    serverConnectionString = Test2CS;
                    conn = new SqlConnection(serverConnectionString);

                    SqlDataReader dReader;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select Distinct empLoginID From Employee Where empStatus='True' Order by empLoginID asc";
                    conn.Open();
                    dReader = cmd.ExecuteReader();
                    if (dReader.HasRows == true)
                    {
                        while (dReader.Read())
                            namesCollection.Add(dReader["empLoginID"].ToString());
                    }
                    else
                    {
                        //MyMessageBox.ShowBox("USER DATA NOT FOUND", "ERROR");
                        MessageBox.Show("Data not found");
                    }

                    dReader.Close();
                    conn.Close();

                    storeName = "TEST2";
                    //MessageBox.Show(storeName + " SERVER IS CONNECTED!", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //StoreCode = "KTSC";

                    //storeStreet = "10654 CAMPUS WAY SOUTH";
                    //storeCityState = "UPPER MARLBORO, MD 20774";
                    //storeTelephone = "TEL : 301-333-1430";
                    //storeFax = "FAX : 240-414-7201";
                }
                else
                {
                    MessageBox.Show("INCORRECT STORE NAME", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbStoreName.SelectAll();
                    cmbStoreName.Focus();
                    return;
                }

                txtEmployeeID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtEmployeeID.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtEmployeeID.AutoCompleteCustomSource = namesCollection;

                SqlCommand cmd_Loading_BtnAccessManagement = new SqlCommand();
                SqlCommand cmd_Loading_StoreBasicSetup = new SqlCommand();
                SqlCommand cmd_Loading_EmployeeTitleLevel = new SqlCommand();
                SqlCommand cmd_Loading_StoreIPs = new SqlCommand();
                SqlCommand cmd_Loading_StoreDBInfo = new SqlCommand();
                SqlCommand cmd_Loading_AdminOption = new SqlCommand();
                SqlCommand cmd_LoadConecctionInfo = new SqlCommand();
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();
                DataTable dt6 = new DataTable();
                DataTable dt7 = new DataTable();
                SqlDataAdapter adapt1 = new SqlDataAdapter();
                SqlDataAdapter adapt2 = new SqlDataAdapter();
                SqlDataAdapter adapt3 = new SqlDataAdapter();
                SqlDataAdapter adapt6 = new SqlDataAdapter();
                SqlDataAdapter adapt7 = new SqlDataAdapter();
                cmd_Loading_BtnAccessManagement.Connection = conn;
                cmd_Loading_StoreBasicSetup.Connection = conn;
                cmd_Loading_EmployeeTitleLevel.Connection = conn;
                cmd_Loading_StoreIPs.Connection = conn;
                cmd_Loading_StoreDBInfo.Connection = conn;
                cmd_Loading_AdminOption.Connection = conn;
                cmd_LoadConecctionInfo.Connection = conn;
                cmd_Loading_BtnAccessManagement.CommandType = CommandType.StoredProcedure;
                cmd_Loading_StoreBasicSetup.CommandType = CommandType.StoredProcedure;
                cmd_Loading_EmployeeTitleLevel.CommandType = CommandType.StoredProcedure;
                cmd_Loading_StoreIPs.CommandType = CommandType.StoredProcedure;
                cmd_Loading_StoreDBInfo.CommandType = CommandType.StoredProcedure;
                cmd_Loading_AdminOption.CommandType = CommandType.StoredProcedure;
                cmd_LoadConecctionInfo.CommandType = CommandType.StoredProcedure;
                cmd_Loading_BtnAccessManagement.CommandText = "Loading_BtnAccessManagement";
                cmd_Loading_StoreBasicSetup.CommandText = "Loading_StoreBasicSetup2";
                cmd_Loading_StoreBasicSetup.Parameters.Add("@StoreName", SqlDbType.NVarChar).Value = storeName;
                cmd_Loading_EmployeeTitleLevel.CommandText = "Loading_EmployeeTitleLevel";
                cmd_Loading_AdminOption.CommandText = "Loading_AdminOption";
                cmd_LoadConecctionInfo.CommandText = "Loading_ConnectionInfo";

                conn.Open();
                adapt1.SelectCommand = cmd_Loading_BtnAccessManagement;
                adapt2.SelectCommand = cmd_Loading_StoreBasicSetup;
                adapt3.SelectCommand = cmd_Loading_EmployeeTitleLevel;
                adapt6.SelectCommand = cmd_Loading_AdminOption;
                adapt7.SelectCommand = cmd_LoadConecctionInfo;
                adapt1.Fill(dt1);
                adapt2.Fill(dt2);
                adapt3.Fill(dt3);
                adapt6.Fill(dt6);
                adapt7.Fill(dt7);
                conn.Close();

                dataGridView1.DataSource = dt1;
                dataGridView2.DataSource = dt2;
                dataGridView3.DataSource = dt3;
                dataGridView6.DataSource = dt6;
                dataGridView7.DataSource = dt7;

                btnManagementInventory = Convert.ToInt16(dataGridView1.Rows[0].Cells[0].Value);
                btnManagementPromotion = Convert.ToInt16(dataGridView1.Rows[0].Cells[1].Value);
                btnManagementPOReceiving = Convert.ToInt16(dataGridView1.Rows[0].Cells[2].Value);
                btnManagementEmployee = Convert.ToInt16(dataGridView1.Rows[0].Cells[3].Value);
                btnManagementCustomer = Convert.ToInt16(dataGridView1.Rows[0].Cells[4].Value);
                btnManagementReport = Convert.ToInt16(dataGridView1.Rows[0].Cells[5].Value);
                btnManagementAdminTools = Convert.ToInt16(dataGridView1.Rows[0].Cells[6].Value);
                btnManagementChangeStore = Convert.ToInt16(dataGridView1.Rows[0].Cells[7].Value);
                btnInventoryRegisterNewItem = Convert.ToInt16(dataGridView1.Rows[0].Cells[8].Value);
                btnInventoryUpdateItem = Convert.ToInt16(dataGridView1.Rows[0].Cells[9].Value);
                btnInventoryDeleteItem = Convert.ToInt16(dataGridView1.Rows[0].Cells[10].Value);
                btnInventoryTargetField = Convert.ToInt16(dataGridView1.Rows[0].Cells[11].Value);
                btnInventoryExcel = Convert.ToInt16(dataGridView1.Rows[0].Cells[12].Value);
                btnInventoryDataTransfer = Convert.ToInt16(dataGridView1.Rows[0].Cells[13].Value);
                btnInventoryGenerateNewUpc = Convert.ToInt16(dataGridView1.Rows[0].Cells[14].Value);
                btnPOReceivingSearchPOList = Convert.ToInt16(dataGridView1.Rows[0].Cells[15].Value);
                btnPOReceivingEditCostPrice = Convert.ToInt16(dataGridView1.Rows[0].Cells[16].Value);
                btnPOReceivingSoldItemList = Convert.ToInt16(dataGridView1.Rows[0].Cells[17].Value);
                btnPOReceivingExcel = Convert.ToInt16(dataGridView1.Rows[0].Cells[18].Value);
                btnPOReceivingDeletePO = Convert.ToInt16(dataGridView1.Rows[0].Cells[19].Value);
                btnEmployeeUpdate = Convert.ToInt16(dataGridView1.Rows[0].Cells[20].Value);
                btnEmployeeDelete = Convert.ToInt16(dataGridView1.Rows[0].Cells[21].Value);
                btnEmployeeEditTimeCard = Convert.ToInt16(dataGridView1.Rows[0].Cells[22].Value);
                btnEmployeeExcel = Convert.ToInt16(dataGridView1.Rows[0].Cells[23].Value);
                btnCustomerUpdate = Convert.ToInt16(dataGridView1.Rows[0].Cells[24].Value);
                btnCustomerDelete = Convert.ToInt16(dataGridView1.Rows[0].Cells[25].Value);
                btnCustomerExcel = Convert.ToInt16(dataGridView1.Rows[0].Cells[26].Value);
                btnReportTimeCard = Convert.ToInt16(dataGridView1.Rows[0].Cells[27].Value);
                btnReportSalesByStore = Convert.ToInt16(dataGridView1.Rows[0].Cells[28].Value);

                StoreCode = Convert.ToString(dataGridView2.Rows[0].Cells[1].Value);
                storeStreet = Convert.ToString(dataGridView2.Rows[0].Cells[2].Value);
                storeCityStateZipCode = Convert.ToString(dataGridView2.Rows[0].Cells[3].Value) + ", " + Convert.ToString(dataGridView2.Rows[0].Cells[4].Value) + " " + Convert.ToString(dataGridView2.Rows[0].Cells[5].Value);
                storeTelephone = "TEL : " + Convert.ToString(dataGridView2.Rows[0].Cells[6].Value);
                storeFax = "FAX : " + Convert.ToString(dataGridView2.Rows[0].Cells[7].Value);

                CahierLV = Convert.ToInt16(dataGridView3.Rows[0].Cells[2].Value);
                SalesAssociateLV = Convert.ToInt16(dataGridView3.Rows[1].Cells[2].Value);
                AssistantSectionManagerLV = Convert.ToInt16(dataGridView3.Rows[2].Cells[2].Value);
                AssistantStoreManagerLV = Convert.ToInt16(dataGridView3.Rows[3].Cells[2].Value);
                SectionManagerLV = Convert.ToInt16(dataGridView3.Rows[4].Cells[2].Value);
                FloorManagerLV = Convert.ToInt16(dataGridView3.Rows[5].Cells[2].Value);
                StoreManagerLV = Convert.ToInt16(dataGridView3.Rows[6].Cells[2].Value);
                GeneralManagerLV = Convert.ToInt16(dataGridView3.Rows[7].Cells[2].Value);
                DirectorLV = Convert.ToInt16(dataGridView3.Rows[8].Cells[2].Value);
                VicePresidentLV = Convert.ToInt16(dataGridView3.Rows[9].Cells[2].Value);
                PresidentLV = Convert.ToInt16(dataGridView3.Rows[10].Cells[2].Value);
                SystemAdministratorLV = Convert.ToInt16(dataGridView3.Rows[11].Cells[2].Value);

                B4UHQIP = Convert.ToString(dataGridView7.Rows[0].Cells[4].Value);
                B4UWHIP = Convert.ToString(dataGridView7.Rows[1].Cells[4].Value);
                THIP = Convert.ToString(dataGridView7.Rows[2].Cells[4].Value);
                OHIP = Convert.ToString(dataGridView7.Rows[3].Cells[4].Value);
                UMIP = Convert.ToString(dataGridView7.Rows[4].Cells[4].Value);
                CHIP = Convert.ToString(dataGridView7.Rows[5].Cells[4].Value);
                WMIP = Convert.ToString(dataGridView7.Rows[6].Cells[4].Value);
                CVIP = Convert.ToString(dataGridView7.Rows[7].Cells[4].Value);
                PWIP = Convert.ToString(dataGridView7.Rows[8].Cells[4].Value);
                WBIP = Convert.ToString(dataGridView7.Rows[9].Cells[4].Value);
                WDIP = Convert.ToString(dataGridView7.Rows[10].Cells[4].Value);
                GBIP = Convert.ToString(dataGridView7.Rows[11].Cells[4].Value);
                BWIP = Convert.ToString(dataGridView7.Rows[12].Cells[4].Value);

                B4UHQDB = Convert.ToString(dataGridView7.Rows[0].Cells[5].Value);
                B4UWHDB = Convert.ToString(dataGridView7.Rows[1].Cells[5].Value);
                THDB = Convert.ToString(dataGridView7.Rows[2].Cells[5].Value);
                OHDB = Convert.ToString(dataGridView7.Rows[3].Cells[5].Value);
                UMDB = Convert.ToString(dataGridView7.Rows[4].Cells[5].Value);
                CHDB = Convert.ToString(dataGridView7.Rows[5].Cells[5].Value);
                WMDB = Convert.ToString(dataGridView7.Rows[6].Cells[5].Value);
                CVDB = Convert.ToString(dataGridView7.Rows[7].Cells[5].Value);
                PWDB = Convert.ToString(dataGridView7.Rows[8].Cells[5].Value);
                WBDB = Convert.ToString(dataGridView7.Rows[9].Cells[5].Value);
                WDDB = Convert.ToString(dataGridView7.Rows[10].Cells[5].Value);
                GBDB = Convert.ToString(dataGridView7.Rows[11].Cells[5].Value);
                BWDB = Convert.ToString(dataGridView7.Rows[12].Cells[5].Value);

                DBUID = Convert.ToString(dataGridView7.Rows[0].Cells[6].Value);
                DBPSW = Convert.ToString(dataGridView7.Rows[0].Cells[7].Value);
                sqlPort = Convert.ToString(dataGridView7.Rows[0].Cells[8].Value);

                specialCode = Convert.ToString(dataGridView6.Rows[0].Cells[2].Value);
                noBarcodeAdmin1 = Convert.ToString(dataGridView6.Rows[0].Cells[3].Value);
                noBarcodeAdmin2 = Convert.ToString(dataGridView6.Rows[0].Cells[4].Value);
                noBarcodeAdmin3 = Convert.ToString(dataGridView6.Rows[0].Cells[5].Value);
                SystemMasterUserName = Convert.ToString(dataGridView6.Rows[0].Cells[6].Value);
                SystemMasterPassword = Convert.ToString(dataGridView6.Rows[0].Cells[7].Value);

                B4UHQCS_IP = "Data Source=" + B4UHQIP + "," + sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + B4UHQDB + ";User ID=" + DBUID + ";Password=" + DBPSW;
                B4UWHCS_IP = "Data Source=" + B4UWHIP + "," + sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + B4UWHDB + ";User ID=" + DBUID + ";Password=" + DBPSW;
                THCS_IP = "Data Source=" + THIP + "," + sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + THDB + ";User ID=" + DBUID + ";Password=" + DBPSW;
                OHCS_IP = "Data Source=" + OHIP + "," + sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + OHDB + ";User ID=" + DBUID + ";Password=" + DBPSW;
                UMCS_IP = "Data Source=" + UMIP + "," + sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + UMDB + ";User ID=" + DBUID + ";Password=" + DBPSW;
                CHCS_IP = "Data Source=" + CHIP + "," + sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + CHDB + ";User ID=" + DBUID + ";Password=" + DBPSW;
                WMCS_IP = "Data Source=" + WMIP + "," + sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + WMDB + ";User ID=" + DBUID + ";Password=" + DBPSW;
                CVCS_IP = "Data Source=" + CVIP + "," + sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + CVDB + ";User ID=" + DBUID + ";Password=" + DBPSW;
                PWCS_IP = "Data Source=" + PWIP + "," + sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + PWDB + ";User ID=" + DBUID + ";Password=" + DBPSW;
                WBCS_IP = "Data Source=" + WBIP + "," + sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + WBDB + ";User ID=" + DBUID + ";Password=" + DBPSW;
                WDCS_IP = "Data Source=" + WDIP + "," + sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + WDDB + ";User ID=" + DBUID + ";Password=" + DBPSW;
                GBCS_IP = "Data Source=" + GBIP + "," + sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + GBDB + ";User ID=" + DBUID + ";Password=" + DBPSW;
                BWCS_IP = "Data Source=" + BWIP + "," + sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + BWDB + ";User ID=" + DBUID + ";Password=" + DBPSW;

                if (boolBtnConnect == false)
                {
                    if (Properties.Settings.Default.IsRestarting == false)
                    {
                        MessageBox.Show(storeName + " server is connected !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        cmbStoreName.Enabled = false;
                        btnConnect.Enabled = false;
                        txtEmployeeID.Select();
                        txtEmployeeID.Focus();
                    }
                    else
                    {
                        Properties.Settings.Default.IsRestarting = false;
                        Properties.Settings.Default.Save();

                        cmbStoreName.Enabled = false;
                        btnConnect.Enabled = false;
                        txtEmployeeID.Select();
                        txtEmployeeID.Focus();
                    }
                }

                boolBtnConnect = false;
            /*}
            catch
            {
                if (boolBtnConnect == false)
                {
                    if (Properties.Settings.Default.IsRestarting == false)
                    {
                        MessageBox.Show("Can not connect the server...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmbStoreName.SelectAll();
                        cmbStoreName.Focus();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Can not connect the server...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        Properties.Settings.Default.IsRestarting = false;
                        Properties.Settings.Default.Save();
                        cmbStoreName.SelectAll();
                        cmbStoreName.Focus();
                        return;
                    }
                }
                else
                {
                }
            }*/
        }

        private void txtEmployeeID_TextChanged(object sender, EventArgs e)
        {
            if (noBarcodeAdmin1 == txtEmployeeID.Text.Trim().ToUpper() | noBarcodeAdmin2 == txtEmployeeID.Text.Trim().ToUpper() | noBarcodeAdmin3 == txtEmployeeID.Text.Trim().ToUpper())
            {
                lblSpecialCode.Visible = true;
                txtSpecialCode.Visible = true;
            }
            else
            {
                lblSpecialCode.Visible = false;
                txtSpecialCode.Visible = false;
            }
        }

        private void lblStoreName_DoubleClick(object sender, EventArgs e)
        {
            if (cmbStoreName.Text != "")
            {
                InputIPAddress inputIPAddressForm = new InputIPAddress();
                inputIPAddressForm.parentForm = this;
                inputIPAddressForm.ShowDialog();
            }
        }

        private void cmbStoreName_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(cmbStoreName, cmbStoreName.SelectedItem.ToString());
        }

        public string OtherStoreConnectionString(string sc)
        {
            OtherStoreCS = string.Empty;

            if (sc == "B4UHQ")
            {
                OtherStoreCS = "Data Source=" + B4UHQIP + ", " + sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + B4UHQDB + ";User ID=" + DBUID + ";Password=" + DBPSW;
            }
            else if (sc == "B4UWH")
            {
                OtherStoreCS = "Data Source=" + B4UWHIP + ", " + sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + B4UWHDB + ";User ID=" + DBUID + ";Password=" + DBPSW;
            }
            else if (sc == "TH")
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
                OtherStoreCS = "Server=VMWARE_DEV;Database=TestDB;UID=ssk;Password=cherry;Connect Timeout=10";
            }

            return OtherStoreCS;
        }

        public string OtherStoreName(string sc)
        {
            OtherStoreNM = string.Empty;

            if (sc == "B4UHQ")
            {
                OtherStoreNM = "BEAUTY 4U HEADQUARTERS";
            }
            else if (sc == "B4UWH")
            {
                OtherStoreNM = "BEAUTY 4U WAREHOUSE";
            }
            else if (sc == "TH")
            {
                OtherStoreNM = "TEMPLE HILLS";
            }
            else if (sc == "OH")
            {
                OtherStoreNM = "OXON HILL";
            }
            else if (sc == "UM")
            {
                OtherStoreNM = "UPPER MARLBORO";
            }
            else if (sc == "CH")
            {
                OtherStoreNM = "CAPITOL HEIGHTS";
            }
            else if (sc == "WM")
            {
                OtherStoreNM = "WINDSOR MILL";
            }
            else if (sc == "CV")
            {
                OtherStoreNM = "CATONSVILLE";
            }
            else if (sc == "PW")
            {
                OtherStoreNM = "PRINCE WILLIAM";
            }
            else if (sc == "WB")
            {
                OtherStoreNM = "WOODBRIDGE";
            }
            else if (sc == "WD")
            {
                OtherStoreNM = "WALDORF";
            }
            else if (sc == "GB")
            {
                OtherStoreNM = "GAITHERSBURG";
            }
            else if (sc == "BW")
            {
                OtherStoreNM = "BOWIE";
            }
            else if (sc == "TEST")
            {
                OtherStoreNM = "TEST";
            }

            return OtherStoreNM;
        }

        public int UserChecking(string newSC)
        {
            if (employeeID == SystemMasterUserName)
                return 7;

            SqlConnection newConn = new SqlConnection(OtherStoreConnectionString(newSC));
            SqlCommand cmd = new SqlCommand("Get_User_LogIn_Info", newConn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@empLoginID", SqlDbType.NVarChar).Value = employeeID.ToUpper().ToString();
            cmd.Parameters.Add("@empPassword", SqlDbType.NVarChar).Value = password;
            SqlParameter UserName_Param = cmd.Parameters.Add("@empFirstName", SqlDbType.NVarChar, 50);
            SqlParameter UserLevel_Param = cmd.Parameters.Add("@empAccessLv", SqlDbType.TinyInt);
            UserName_Param.Direction = ParameterDirection.Output;
            UserLevel_Param.Direction = ParameterDirection.Output;

            newConn.Open();
            cmd.ExecuteNonQuery();
            newConn.Close();

            if (cmd.Parameters["@empFirstName"].Value == DBNull.Value)
            {
                return 0;
            }
            else
            {
                int usrLv = Convert.ToInt16(cmd.Parameters["@empAccessLv"].Value);
                return usrLv;
            }
        }

        private int ProcessChecking()
        {
            Process[] procList = Process.GetProcesses();
            int existProc = 0;
            string procName = "";

            for (int i = 0; i < procList.Length; i++)
            {
                procName = procList[i].ProcessName;

                if (procName == "Management")
                {
                    existProc++;
                }
            }

            return existProc;
        }
    }
}
