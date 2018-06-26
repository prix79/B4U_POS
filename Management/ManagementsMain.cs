using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using B4Udll;

namespace Management
{
    public partial class ManagementsMain : Form
    {
        public LogInManagements parentForm;

        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adapt = new SqlDataAdapter();
        DataTable dt = new DataTable();

        DateTime currentTime;
        string today;
        DateTime TcTimeOn, TcTimeOff;

        public bool Authorized;
        public bool BtnInventory = true;

        private long idleCounter = 0;
        public double idleSec = 0;
        int idleMaxTime = 2400;

        string clientInfo;
        string clientName;
        int currentClientVersion;
        int lastestClientVersion;
        public string updatePassword;
        public string FTPDirectoryName;
        public string LocalDirectory;

        //public string _ftpURL = "ftp://173.167.197.50:65000/Development/Beauty4U/POS_Clients/";
        public string _ftpURL;
        public string _UserName;
        public string _Password;
        public string _FileName = "Management.exe";
        public string _TempFileName;

        //string[] fileList;
        string[] oldfile = new string[50];
        string[] newfile = new string[50];

        public bool auth = false;

        private Thread _thread1;

        public ManagementsMain()
        {
            InitializeComponent();

            // Hook into the ApplicationIdle event
            ApplicationIdleTimer.ApplicationIdle += new ApplicationIdleTimer.ApplicationIdleEventHandler(this.App_Idle);

            // Also hook into the Application.Idle event, for comparison
            Application.Idle += new System.EventHandler(this.Idle_Count);
            // Start the timer
            this.timer1.Start();
        }

        public void ManagementsMain_Load(object sender, EventArgs e)
        {
            clientInfo = parentForm.ClinetVersion.Trim();
            currentClientVersion = Convert.ToInt16(clientInfo.Substring(0, 4));
            clientName = "Management";

            SqlConnection conn = new SqlConnection(parentForm.B4UHQCS_IP);
            SqlCommand cmd = new SqlCommand("Get_FTP_Info", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FTP_Index", SqlDbType.TinyInt).Value = 1;
            SqlParameter FTPIP_Param = cmd.Parameters.Add("@FTP_IP", SqlDbType.NVarChar, 50);
            SqlParameter FTPPort_Param = cmd.Parameters.Add("@FTP_Port", SqlDbType.NVarChar, 50);
            SqlParameter FTPRoot_Param = cmd.Parameters.Add("@FTP_Root", SqlDbType.NVarChar, 100);
            FTPIP_Param.Direction = ParameterDirection.Output;
            FTPPort_Param.Direction = ParameterDirection.Output;
            FTPRoot_Param.Direction = ParameterDirection.Output;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                _ftpURL = "ftp://" + cmd.Parameters["@FTP_IP"].Value.ToString() + ":" + cmd.Parameters["@FTP_Port"].Value.ToString() + "/" + cmd.Parameters["@FTP_Root"].Value.ToString();

                if (parentForm.storeName == "BEAUTY 4U HEADQUARTERS")
                {
                    FTPDirectoryName = "Headquarters/" + clientName;
                }
                else if (parentForm.storeName == "BEAUTY 4U WAREHOUSE")
                {
                    FTPDirectoryName = "Warehouse/" + clientName;
                }
                else if (parentForm.storeName == "TEMPLE HILLS")
                {
                    FTPDirectoryName = "TempleHills/" + clientName;
                }
                else if (parentForm.storeName == "OXON HILL")
                {
                    FTPDirectoryName = "OxonHill/" + clientName;
                }
                else if (parentForm.storeName == "UPPER MARLBORO")
                {
                    FTPDirectoryName = "UpperMarlboro/" + clientName;
                }
                else if (parentForm.storeName == "CAPITOL HEIGHTS")
                {
                    FTPDirectoryName = "CapitolHeights/" + clientName;
                }
                else if (parentForm.storeName == "WINDSOR MILL")
                {
                    FTPDirectoryName = "WindsorMill/" + clientName;
                }
                else if (parentForm.storeName == "CATONSVILLE")
                {
                    FTPDirectoryName = "Catonsville/" + clientName;
                }
                else if (parentForm.storeName == "PRINCE WILLIAM")
                {
                    FTPDirectoryName = "PrinceWilliam/" + clientName;
                }
                else if (parentForm.storeName == "WOODBRIDGE")
                {
                    FTPDirectoryName = "Woodbridge/" + clientName;
                }
                else if (parentForm.storeName == "WALDORF")
                {
                    FTPDirectoryName = "Waldorf/" + clientName;
                }
                else if (parentForm.storeName == "GAITHERSBURG")
                {
                    FTPDirectoryName = "Gaithersburg/" + clientName;
                }
                else if (parentForm.storeName == "BOWIE")
                {
                    FTPDirectoryName = "Bowie/" + clientName;
                }
                else if (parentForm.storeName == "TEST")
                {
                    FTPDirectoryName = "TEST/" + clientName;
                }

                LocalDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                btnUpdateCheck_Click(null, null);
            }
            catch
            {
                MessageBox.Show("Update server Connection failed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conn.Close();
                listBox1.Visible = false;
                btnUpdateCheck.Visible=false;
                lblList.Visible = false;
                progressBar1.Visible = false;
                //return;
            }

            //this.Text = "Management System - " + parentForm.storeName;
            this.Text = "BEAUTY 4U MANAGEMENT SYSTEM - " + parentForm.employeeID + " LOGGED IN " + parentForm.storeName;
            lblStoreName.Text = parentForm.storeName.ToUpper().ToString();
            lblComputerName.Text = Environment.MachineName.ToString();
            Authorized = false;

            btnInventory.Image = (Image)Properties.Resources.inventory;
            btnPromotion.Image = (Image)Properties.Resources.promotion;
            btnPOReceiving.Image = (Image)Properties.Resources.po_receiving;
            btnEmployee.Image = (Image)Properties.Resources.employee;
            btnCustomer.Image = (Image)Properties.Resources.customer;
            btnReport.Image = (Image)Properties.Resources.report;
            btnBulletinBoard.Image = (Image)Properties.Resources.bulletin;
            btnChangeStore.Image = (Image)Properties.Resources.store;
            btnAdminTools.Image = (Image)Properties.Resources.admintool;
            btnAboutManagement.Image = (Image)Properties.Resources.about;
            btnExit.Image = (Image)Properties.Resources.exit;

            //if (parentForm.employeeID.ToUpper() == parentForm.SystemMasterUserName.ToUpper())
            //    btnOneTime.Visible = true;

            if (parentForm.StoreCode.ToUpper().ToString() == parentForm.WarehouseStoreCode1.ToUpper() & parentForm.storeName.ToUpper().ToString() == parentForm.WarehouseName1.ToUpper())
            {
                btnInventory.Enabled = true;
                btnPromotion.Enabled = false;
                btnPOReceiving.Enabled = true;
                btnCustomer.Enabled = false;
                btnReport.Enabled = true;
                btnAdminTools.Enabled = false;
            }
            else if (parentForm.StoreCode == "B4UHQ")
            {
                if (parentForm.userLevel >= parentForm.SystemAdministratorLV | parentForm.txtSpecialCode.Text.Trim().ToUpper().ToString() == parentForm.specialCode.ToUpper().ToString())
                {
                    btnInventory.Enabled = true;
                }
                else
                {
                    btnInventory.Enabled = false;
                }

                btnPromotion.Enabled = true;
                btnPOReceiving.Enabled = true;
                btnCustomer.Enabled = true;
                btnReport.Enabled = true;
                btnAdminTools.Enabled = false;
            }
            else
            {
                btnInventory.Enabled = true;
                btnPromotion.Enabled = true;
                btnPOReceiving.Enabled = true;
                btnCustomer.Enabled = true;
                btnReport.Enabled = true;
                btnAdminTools.Enabled = true;
            }
        }

        public void btnInventory_Click(object sender, EventArgs e)
        {
            if (parentForm.StoreCode.ToUpper().ToString() == parentForm.WarehouseStoreCode1.ToUpper() & parentForm.storeName.ToUpper().ToString() == parentForm.WarehouseName1.ToUpper())
            {
                if (parentForm.employeeID.ToUpper().ToString() == parentForm.SystemMasterUserName.ToUpper())
                {
                    Authorized = true;
                }
                else
                {
                    if (Authorized == false)
                    {
                        BtnInventory = false;
                    }
                    else
                    {
                        BtnInventory = true;
                    }
                }
            }
            else
            {
                BtnInventory = true;
            }

            try
            {
                if (BtnInventory == true)
                {
                    SqlCommand cmd = new SqlCommand("Check_User", parentForm.conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@empLoginID", SqlDbType.NVarChar).Value = parentForm.employeeID.ToUpper().ToString();
                    SqlParameter UserName_Param = cmd.Parameters.Add("@empFirstName", SqlDbType.NVarChar, 50);
                    UserName_Param.Direction = ParameterDirection.Output;

                    parentForm.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm.conn.Close();

                    if (cmd.Parameters["@empFirstName"].Value == DBNull.Value)
                    {
                        if (parentForm.employeeID == parentForm.SystemMasterUserName)
                        {
                            if (parentForm.StoreCode == "B4UHQ")
                            {
                                InventoryMainHQ inventoryMainHQForm = new InventoryMainHQ();
                                inventoryMainHQForm.parentForm = this.parentForm;
                                inventoryMainHQForm.Show();
                            }
                            else
                            {
                                InventoryMain inventoryMainForm = new InventoryMain();
                                inventoryMainForm.parentForm = this.parentForm;
                                inventoryMainForm.Show();
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
                        if (parentForm.userLevel >= parentForm.btnManagementInventory)
                        {
                            if (parentForm.StoreCode == "B4UHQ")
                            {
                                InventoryMainHQ inventoryMainHQForm = new InventoryMainHQ();
                                inventoryMainHQForm.parentForm = this.parentForm;
                                inventoryMainHQForm.Show();
                            }
                            else
                            {
                                InventoryMain inventoryMainForm = new InventoryMain();
                                inventoryMainForm.parentForm = this.parentForm;
                                inventoryMainForm.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("NOT AUTHORIZED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                else
                {
                    InputPasscode inputPasscodeFrom = new InputPasscode(1);
                    inputPasscodeFrom.parentForm1 = this.parentForm;
                    inputPasscodeFrom.parentForm2 = this;
                    inputPasscodeFrom.Show();
                }
            }
            catch
            {
                MessageBox.Show("CAN NOT CONNECT TO SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                parentForm.conn.Close();
                return;
            }
        }

        private void btnPromotion_Click(object sender, EventArgs e)
        {
            //if (parentForm.userLevel >= parentForm.btnManagementPromotion)
            //{
            if (parentForm.userLevel > parentForm.btnManagementPromotion | parentForm.txtSpecialCode.Text.Trim() == parentForm.specialCode)
            {
                PromotionMain promotionMainForm = new PromotionMain();
                promotionMainForm.parentForm = this.parentForm;
                promotionMainForm.Show();
            }
            else
            {
                MessageBox.Show("Your employee ID is not authorized", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnPOReceiving_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Check_User", parentForm.conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@empLoginID", SqlDbType.NVarChar).Value = parentForm.employeeID.ToUpper().ToString();
            SqlParameter UserName_Param = cmd.Parameters.Add("@empFirstName", SqlDbType.NVarChar, 50);
            UserName_Param.Direction = ParameterDirection.Output;

            parentForm.conn.Open();
            cmd.ExecuteNonQuery();
            parentForm.conn.Close();

            if (cmd.Parameters["@empFirstName"].Value == DBNull.Value)
            {
                if (parentForm.employeeID == parentForm.SystemMasterUserName)
                {
                    if (parentForm.StoreCode == "B4UWH")
                    {
                        POandReceivingForWarehouse POandReceivingForWarehouseForm = new POandReceivingForWarehouse();
                        POandReceivingForWarehouseForm.parentForm = this.parentForm;
                        POandReceivingForWarehouseForm.Show();
                    }
                    else
                    {
                        POandReceiving POandReceivingForm = new POandReceiving();
                        POandReceivingForm.parentForm = this.parentForm;
                        POandReceivingForm.Show();
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
                if (parentForm.userLevel >= parentForm.btnManagementPOReceiving)
                {
                    if (parentForm.StoreCode == "B4UWH")
                    {
                        POandReceivingForWarehouse POandReceivingForWarehouseForm = new POandReceivingForWarehouse();
                        POandReceivingForWarehouseForm.parentForm = this.parentForm;
                        POandReceivingForWarehouseForm.Show();
                    }
                    else
                    {
                        POandReceiving POandReceivingForm = new POandReceiving();
                        POandReceivingForm.parentForm = this.parentForm;
                        POandReceivingForm.Show();
                    }
                }
                else
                {
                    MessageBox.Show("NOT AUTHORIZED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Check_User", parentForm.conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@empLoginID", SqlDbType.NVarChar).Value = parentForm.employeeID.ToUpper().ToString();
            SqlParameter UserName_Param = cmd.Parameters.Add("@empFirstName", SqlDbType.NVarChar, 50);
            UserName_Param.Direction = ParameterDirection.Output;

            parentForm.conn.Open();
            cmd.ExecuteNonQuery();
            parentForm.conn.Close();

            if (cmd.Parameters["@empFirstName"].Value == DBNull.Value)
            {
                if (parentForm.employeeID == parentForm.SystemMasterUserName)
                {
                    EmployeeMain employeeMainForm = new EmployeeMain();
                    employeeMainForm.parentForm = this.parentForm;
                    employeeMainForm.Show();
                }
                else
                {
                    MessageBox.Show("NOT AUTHORIZED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (parentForm.userLevel >= parentForm.btnManagementEmployee)
                {
                    EmployeeMain employeeMainForm = new EmployeeMain();
                    employeeMainForm.parentForm = this.parentForm;
                    employeeMainForm.Show();
                }
                else
                {
                    MessageBox.Show("NOT AUTHORIZED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Check_User", parentForm.conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@empLoginID", SqlDbType.NVarChar).Value = parentForm.employeeID.ToUpper().ToString();
            SqlParameter UserName_Param = cmd.Parameters.Add("@empFirstName", SqlDbType.NVarChar, 50);
            UserName_Param.Direction = ParameterDirection.Output;

            parentForm.conn.Open();
            cmd.ExecuteNonQuery();
            parentForm.conn.Close();

            if (cmd.Parameters["@empFirstName"].Value == DBNull.Value)
            {
                if (parentForm.employeeID == parentForm.SystemMasterUserName)
                {
                    MembershipMain membershipMainForm = new MembershipMain();
                    membershipMainForm.parentForm = this.parentForm;
                    membershipMainForm.Show();
                }
                else
                {
                    MessageBox.Show("NOT AUTHORIZED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (parentForm.userLevel >= parentForm.btnManagementCustomer)
                {
                    /*CustomerMain customerMainForm = new CustomerMain();
                    customerMainForm.parentForm = this.parentForm;
                    customerMainForm.Show();*/

                    MembershipMain membershipMainForm = new MembershipMain();
                    membershipMainForm.parentForm = this.parentForm;
                    membershipMainForm.Show();
                }
                else
                {
                    MessageBox.Show("NOT AUTHORIZED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Check_User", parentForm.conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@empLoginID", SqlDbType.NVarChar).Value = parentForm.employeeID.ToUpper().ToString();
            SqlParameter UserName_Param = cmd.Parameters.Add("@empFirstName", SqlDbType.NVarChar, 50);
            UserName_Param.Direction = ParameterDirection.Output;

            parentForm.conn.Open();
            cmd.ExecuteNonQuery();
            parentForm.conn.Close();

            if (cmd.Parameters["@empFirstName"].Value == DBNull.Value)
            {
                if (parentForm.employeeID == parentForm.SystemMasterUserName)
                {
                    ReportMain reportMainForm = new ReportMain();
                    reportMainForm.parentForm = this.parentForm;
                    reportMainForm.Show();
                }
                else
                {
                    MessageBox.Show("NOT AUTHORIZED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (parentForm.userLevel >= parentForm.btnManagementReport)
                {
                    ReportMain reportMainForm = new ReportMain();
                    reportMainForm.parentForm = this.parentForm;
                    reportMainForm.Show();
                }
                else
                {
                    MessageBox.Show("NOT AUTHORIZED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnAdminTools_Click(object sender, EventArgs e)
        {
            if (parentForm.userLevel >= parentForm.btnManagementAdminTools | parentForm.employeeID == parentForm.SystemMasterUserName.ToUpper())
            {
                AdminToolsMain adminToolsMainForm = new AdminToolsMain();
                adminToolsMainForm.parentForm = this.parentForm;
                adminToolsMainForm.Show();
            }
            else
            {
                MessageBox.Show("NOT AUTHORIZED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnChangeStore_Click(object sender, EventArgs e)
        {
            if (parentForm.originalUserLevel >= parentForm.btnManagementChangeStore)
            {
                ChangeStore changeStoreForm = new ChangeStore();
                changeStoreForm.parentForm1 = this.parentForm;
                changeStoreForm.parentForm2 = this;
                changeStoreForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You are not authorized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _thread1.Abort();
            Application.Exit();
        }

        private void ManagementsMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            _thread1.Abort();
            Application.Exit();
        }

        private void btnBulletinBoard_Click(object sender, EventArgs e)
        {
            /*if (parentForm.storeName != "TEST2")
            {
                BulletinBoard bulletinBoardForm = new BulletinBoard();
                bulletinBoardForm.parentForm = this.parentForm;
                bulletinBoardForm.Show();
            }
            else
            {
                MessageBox.Show("CAN NOT USE THIS FUNCTION", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/

            BulletinBoardMain bulletinBoardMainForm = new BulletinBoardMain();
            bulletinBoardMainForm.parentForm = this.parentForm;
            bulletinBoardMainForm.Show();
        }

        private void btnAboutManagement_Click(object sender, EventArgs e)
        {
            AboutManagement aboutManagementForm = new AboutManagement();
            aboutManagementForm.parentForm = this.parentForm;
            aboutManagementForm.ShowDialog();
        }

        private void btnOneTime_Click(object sender, EventArgs e)
        {
            currentTime = DateTime.Now;
            today = currentTime.ToString("yyyy") + currentTime.ToString("MM") + currentTime.ToString("dd");

            if (currentTime.DayOfWeek == DayOfWeek.Sunday)
            {
                TcTimeOn = Convert.ToDateTime(currentTime.ToString("MM") + "/" + currentTime.ToString("dd") + "/" + currentTime.ToString("yyyy") + " 11:00:00 AM");
                TcTimeOff = Convert.ToDateTime(currentTime.ToString("MM") + "/" + currentTime.ToString("dd") + "/" + currentTime.ToString("yyyy") + " 5:00:00 PM");
            }
            else
            {
                TcTimeOn = Convert.ToDateTime(currentTime.ToString("MM") + "/" + currentTime.ToString("dd") + "/" + currentTime.ToString("yyyy") + " 10:00:00 AM");
                TcTimeOff = Convert.ToDateTime(currentTime.ToString("MM") + "/" + currentTime.ToString("dd") + "/" + currentTime.ToString("yyyy") + " 8:00:00 PM");
            }

            SqlCommand cmd_ClockIn = new SqlCommand("Add_Clock_In", parentForm.conn);
            cmd_ClockIn.CommandType = CommandType.StoredProcedure;
            cmd_ClockIn.Parameters.Add("@TcStaCode", SqlDbType.NVarChar).Value = parentForm.StoreCode;
            cmd_ClockIn.Parameters.Add("@TcUserID", SqlDbType.NVarChar).Value = parentForm.employeeID.ToUpper().ToString();
            cmd_ClockIn.Parameters.Add("@TcDate", SqlDbType.Int).Value = Convert.ToInt32(today);
            cmd_ClockIn.Parameters.Add("@TcTimeON", SqlDbType.DateTime).Value = TcTimeOn;
            cmd_ClockIn.Parameters.Add("@TcTotalWage", SqlDbType.Money).Value = 0;
            cmd_ClockIn.Parameters.Add("@TcPaid", SqlDbType.Bit).Value = 0;

            SqlCommand cmd_ClockOut = new SqlCommand("Add_Clock_Out", parentForm.conn);
            cmd_ClockOut.CommandType = CommandType.StoredProcedure;
            cmd_ClockOut.Parameters.Add("@TcUserID", SqlDbType.NVarChar).Value = parentForm.employeeID.ToUpper().ToString();
            cmd_ClockOut.Parameters.Add("@TcTimeON", SqlDbType.DateTime).Value = TcTimeOn;
            cmd_ClockOut.Parameters.Add("@TcTimeOFF", SqlDbType.DateTime).Value = TcTimeOff;
            cmd_ClockOut.Parameters.Add("@TcUsing", SqlDbType.Bit).Value = 1;

            parentForm.conn.Open();
            cmd_ClockIn.ExecuteNonQuery();
            cmd_ClockOut.ExecuteNonQuery();
            parentForm.conn.Close();

            MessageBox.Show("COMPLETED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnInventory_EnabledChanged(object sender, EventArgs e)
        {
            if (btnInventory.Enabled == true)
            {
                btnInventory.Image = (Image)Properties.Resources.inventory;
            }
            else
            {
                btnInventory.Image = (Image)Properties.Resources.inventory_grey;
            }
        }

        private void btnPromotion_EnabledChanged(object sender, EventArgs e)
        {
            if (btnPromotion.Enabled == true)
            {
                btnPromotion.Image = (Image)Properties.Resources.promotion;
            }
            else
            {
                btnPromotion.Image = (Image)Properties.Resources.promotion_grey;
            }
        }

        private void btnPOReceiving_EnabledChanged(object sender, EventArgs e)
        {
            if (btnPOReceiving.Enabled == true)
            {
                btnPOReceiving.Image = (Image)Properties.Resources.po_receiving;
            }
            else
            {
                btnPOReceiving.Image = (Image)Properties.Resources.po_receiving_grey;
            }
        }

        private void btnAboutManagement_EnabledChanged(object sender, EventArgs e)
        {
            if (btnAboutManagement.Enabled == true)
            {
                btnAboutManagement.Image = (Image)Properties.Resources.about;
            }
            else
            {
                btnAboutManagement.Image = (Image)Properties.Resources.about_grey;
            }
        }

        private void btnEmployee_EnabledChanged(object sender, EventArgs e)
        {
            if (btnEmployee.Enabled == true)
            {
                btnEmployee.Image = (Image)Properties.Resources.employee;
            }
            else
            {
                btnEmployee.Image = (Image)Properties.Resources.employee_grey;
            }
        }

        private void btnCustomer_EnabledChanged(object sender, EventArgs e)
        {
            if (btnCustomer.Enabled == true)
            {
                btnCustomer.Image = (Image)Properties.Resources.customer;
            }
            else
            {
                btnCustomer.Image = (Image)Properties.Resources.customer_grey;
            }
        }

        private void btnReport_EnabledChanged(object sender, EventArgs e)
        {
            if (btnReport.Enabled == true)
            {
                btnReport.Image = (Image)Properties.Resources.report;
            }
            else
            {
                btnReport.Image = (Image)Properties.Resources.report_grey;
            }
        }

        private void btnBulletinBoard_EnabledChanged(object sender, EventArgs e)
        {
            if (btnBulletinBoard.Enabled == true)
            {
                btnBulletinBoard.Image = (Image)Properties.Resources.bulletin;
            }
            else
            {
                btnBulletinBoard.Image = (Image)Properties.Resources.bulletin_grey;
            }
        }

        private void btnChangeStore_EnabledChanged(object sender, EventArgs e)
        {
            if (btnChangeStore.Enabled == true)
            {
                btnChangeStore.Image = (Image)Properties.Resources.store;
            }
            else
            {
                btnChangeStore.Image = (Image)Properties.Resources.store_grey;
            }
        }

        private void btnAdminTools_EnabledChanged(object sender, EventArgs e)
        {
            if (btnAdminTools.Enabled == true)
            {
                btnAdminTools.Image = (Image)Properties.Resources.admintool;
            }
            else
            {
                btnAdminTools.Image = (Image)Properties.Resources.admintool_grey;
            }
        }

        private void btnExit_EnabledChanged(object sender, EventArgs e)
        {
            if (btnExit.Enabled == true)
            {
                btnExit.Image = (Image)Properties.Resources.exit;
            }
            else
            {
                btnExit.Image = (Image)Properties.Resources.exit_grey;
            }
        }

        private void App_Idle(ApplicationIdleTimer.ApplicationIdleEventArgs e)
        {
            this.lblStatus.BackColor = Color.Green;
            this.lblStatus.Text = string.Format("Idle: {0}s", e.IdleDuration.TotalSeconds.ToString("0"));
            idleSec = e.IdleDuration.TotalSeconds;

        }

        private void Idle_Count(object sender, System.EventArgs e)
        {
            idleCounter++;
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            if (!ApplicationIdleTimer.IsIdle && this.lblStatus.Text != "Busy")
            {
                this.lblStatus.BackColor = Color.Red;
                this.lblStatus.Text = "Busy";
            }
            else
            {
                if (Convert.ToInt16(idleSec) > 0 & Convert.ToInt16(idleSec) % idleMaxTime == 0)
                {
                    //Application.Restart();

                    this.timer1.Stop();
                    LogOffMSG logOffMSGForm = new LogOffMSG();
                    logOffMSGForm.parentForm = this;
                    logOffMSGForm.ShowDialog();
                }
            }
        }

        private void DisplayDateTime(DateTime dateTime)
        {
            lblLocalTime.Text = dateTime.ToString("F");
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            _thread1 = new Thread(DisplayLocalTime);
            _thread1.Start();
        }

        protected override void OnClosed(EventArgs e)
        {
            _thread1.Abort();

            base.OnClosed(e);
        }

        private void DisplayLocalTime()
        {
            while (true)
            {
                lblLocalTime.InvokeIfNeeded(DisplayDateTime, DateTime.Now);

                Thread.Sleep(1000);
            }
        }

        private void btnUpdateCheck_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(parentForm.B4UHQCS_IP);
                SqlCommand cmd = new SqlCommand("ClientVersionCheck", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientName", SqlDbType.NVarChar).Value = clientName;
                SqlParameter ClientVersion_Param = cmd.Parameters.Add("@ClientVersion", SqlDbType.Int);
                SqlParameter UpdatePassword_Param = cmd.Parameters.Add("@UpdatePassword", SqlDbType.NVarChar, 50);
                SqlParameter FTPUserName_Param = cmd.Parameters.Add("@FTPUserName", SqlDbType.NVarChar, 50);
                SqlParameter FTPPassword_Param = cmd.Parameters.Add("@FTPPassword", SqlDbType.NVarChar, 50);
                ClientVersion_Param.Direction = ParameterDirection.Output;
                UpdatePassword_Param.Direction = ParameterDirection.Output;
                FTPUserName_Param.Direction = ParameterDirection.Output;
                FTPPassword_Param.Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                if (cmd.Parameters["@UpdatePassword"].Value == DBNull.Value)
                {

                    updatePassword = "Expired passcode";
                }
                else
                {
                    updatePassword = cmd.Parameters["@UpdatePassword"].Value.ToString().Trim();
                }

                lastestClientVersion = Convert.ToInt16(cmd.Parameters["@ClientVersion"].Value);
                _UserName = cmd.Parameters["@FTPUserName"].Value.ToString().Trim();
                _Password = cmd.Parameters["@FTPPassword"].Value.ToString().Trim();

                if (lastestClientVersion > currentClientVersion)
                {
                    if (btnUpdateCheck.Text == "UPDATE")
                    {
                        listBox1.DataSource = GetFtpDirectoryDetails(_ftpURL + FTPDirectoryName, _UserName, _Password);
                        string[] fileList = GetFileList(_ftpURL + FTPDirectoryName, _UserName, _Password);

                        if (fileList.Length > 50)
                        {
                            MessageBox.Show("Can not download more than 50 files. \r\nPlese contact IT department.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else if (fileList.Length == 1)
                        {
                            progressBar1.Minimum = 0;
                            progressBar1.Maximum = 1;
                            progressBar1.Step = 1;
                            //ret_str += fileList[0];
                            DownloadFile(_ftpURL, _UserName, _Password, FTPDirectoryName, fileList[0].Substring(11), LocalDirectory, 0);
                            progressBar1.PerformStep();

                            MessageBox.Show("Update completed successfully! \r\nPlease hit OK button to restart the program...", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnUpdateCheck.Enabled = false;
                            Application.Restart();
                        }
                        else
                        {
                            progressBar1.Minimum = 0;
                            progressBar1.Maximum = fileList.Length;
                            progressBar1.Step = 1;

                            for (int i = 0; i < fileList.Length; i++)
                            {
                                oldfile[i] = fileList[i].Substring(11);
                                //ret_str += fileList[i] + ",";
                                DownloadFile(_ftpURL, _UserName, _Password, FTPDirectoryName, oldfile[i], LocalDirectory, i);
                                progressBar1.PerformStep();
                            }

                            MessageBox.Show("Update completes successfully! \r\nPlease hit OK button to restart the program...", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnUpdateCheck.Enabled = false;
                            Application.Restart();
                        }
                    }
                    else
                    {
                        DialogResult MyDialogResult;
                        MyDialogResult = MessageBox.Show(this, "A new version of POS MANAGEMENT program client is available. \r\nDo you want to proceed with the update now?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (MyDialogResult == DialogResult.Yes)
                        {
                            if (auth == false)
                            {
                                InputPasscode inputPasscodeForm = new InputPasscode(4);
                                inputPasscodeForm.parentForm1 = this.parentForm;
                                inputPasscodeForm.parentForm6 = this;
                                inputPasscodeForm.ShowDialog();
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else
                {
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Can not connect the update server...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public List<string> GetFtpDirectoryDetails(string ftpURL, string UserName, string Password)
        {
            List<string> lst_strFiles = new List<string>();
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpURL);
                request.Credentials = new NetworkCredential(UserName, Password);
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                StreamReader file = new StreamReader(response.GetResponseStream());
                while (!file.EndOfStream)
                {
                    lst_strFiles.Add(file.ReadLine());
                }
                file.Close();
                response.Close();
            }
            catch (Exception exc)
            {
                lst_strFiles.Add(exc.Message);
            }
            return lst_strFiles;
        }

        public void DownloadFile(string ftpURL, string UserName, string Password, string ftpDirectory, string FileName, string LocalDirectory, int idx)
        {
            if (FileExistsCheck(LocalDirectory + "\\" + FileName) == true)
            {
                //RenameFile(LocalDirectory, FileName, FileName.Substring(0, FileName.Length - 1), idx);
                RenameFile(LocalDirectory, FileName, FileName + ".temp", idx);

                try
                {
                    FtpWebRequest requestFileDownload = (FtpWebRequest)WebRequest.Create(ftpURL + "/" + ftpDirectory + "/" + FileName);
                    requestFileDownload.Credentials = new NetworkCredential(UserName, Password);
                    requestFileDownload.Method = WebRequestMethods.Ftp.DownloadFile;
                    FtpWebResponse responseFileDownload = (FtpWebResponse)requestFileDownload.GetResponse();
                    Stream responseStream = responseFileDownload.GetResponseStream();
                    FileStream writeStream = new FileStream(LocalDirectory + "/" + FileName, FileMode.Create);
                    int Length = 2048;
                    Byte[] buffer = new Byte[Length];
                    int bytesRead = responseStream.Read(buffer, 0, Length);
                    while (bytesRead > 0)
                    {
                        writeStream.Write(buffer, 0, bytesRead);
                        bytesRead = responseStream.Read(buffer, 0, Length);
                    }
                    responseStream.Close();
                    writeStream.Close();
                    requestFileDownload = null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                try
                {
                    FtpWebRequest requestFileDownload = (FtpWebRequest)WebRequest.Create(ftpURL + "/" + ftpDirectory + "/" + FileName);
                    requestFileDownload.Credentials = new NetworkCredential(UserName, Password);
                    requestFileDownload.Method = WebRequestMethods.Ftp.DownloadFile;
                    FtpWebResponse responseFileDownload = (FtpWebResponse)requestFileDownload.GetResponse();
                    Stream responseStream = responseFileDownload.GetResponseStream();
                    FileStream writeStream = new FileStream(LocalDirectory + "/" + FileName, FileMode.Create);
                    int Length = 2048;
                    Byte[] buffer = new Byte[Length];
                    int bytesRead = responseStream.Read(buffer, 0, Length);
                    while (bytesRead > 0)
                    {
                        writeStream.Write(buffer, 0, bytesRead);
                        bytesRead = responseStream.Read(buffer, 0, Length);
                    }
                    responseStream.Close();
                    writeStream.Close();
                    requestFileDownload = null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool FileExistsCheck(string oldFilePath)
        {
            if (System.IO.File.Exists(oldFilePath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RenameFile(string filePath, string oldFileName, string newFileName, int index)
        {
            oldfile[index] = filePath + "\\" + oldFileName;
            newfile[index] = filePath + "\\" + newFileName;

            System.IO.File.Move(oldfile[index], newfile[index]);
        }

        public string[] GetFileList(string ftpURL, string UserName, string Password)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpURL);
            request.Credentials = new NetworkCredential(UserName, Password);
            request.Method = WebRequestMethods.Ftp.ListDirectory;

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string strData;
            strData = reader.ReadToEnd();
            string[] filesInDirectory = strData.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            response.Close();

            return filesInDirectory;
        }
    }
}