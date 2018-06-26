using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Management
{
    public partial class CreateNewPO : Form
    {
        public LogInManagements parentForm1;
        public POandReceiving parentForm2;
        public ItemSoldList parentForm3;
        public POandReceivingForWarehouse parentForm4;

        int option = 0;

        SqlCommand cmd = new SqlCommand();
        DataSet ds;
        SqlDataAdapter adapt;

        bool vendorBool = false;

        Int64 vendorID;
        string vendorCode, vendorName;

        public Int64 POID = 0;
        public string POEmployeeID = string.Empty;
        public string POStatus = string.Empty;
        public string POVendor = string.Empty;
        public string POCreateDate = string.Empty;

        public bool boolNumEmpID = true;

        public CreateNewPO(int opt)
        {
            InitializeComponent();
            option = opt;
        }

        private void CreateNewPO_Load(object sender, EventArgs e)
        {
            if (parentForm1.userLevel >= parentForm1.GeneralManagerLV)
                cmbEmployeeID.Visible = true;

            lblStoreCode.Text = parentForm1.StoreCode.ToUpper();
            lblEmployeeID.Text = parentForm1.employeeID.ToUpper();

            if (option == 0)
            {
                this.Text = "CRETE NEW P/O";
            }
            else if(option == 1)
            {
                this.Text = "CREATE NEW P/O";
            }
            else if (option == 2)
            {
                this.Text = "CREATE WAREHOUSE P/O";

                btnLoadVendor_Click(null, null);
                cmbVendor.Text = parentForm1.WarehouseName1.ToUpper();
                cmbVendor.Enabled = false;
                btnLoadVendor.Enabled = false;
            }
            else if (option == 3)
            {
                this.Text = "CREATE NEW P/O";
            }

            cmd.CommandText = "Get_UserID";
            cmd.Connection = parentForm1.conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            ds = new DataSet();
            adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;

            parentForm1.conn.Open();
            ds.Clear();
            adapt.Fill(ds);
            parentForm1.conn.Close();

            cmbEmployeeID.DataSource = ds.Tables[0].DefaultView;
            cmbEmployeeID.ValueMember = "empLoginID";
            cmbEmployeeID.DisplayMember = "empLoginID";

            cmbEmployeeID.Text = lblEmployeeID.Text;
        }

        private void btnLoadVendor_Click(object sender, EventArgs e)
        {
            vendorBool = true;

            cmd.CommandText = "Get_VendorName";
            cmd.Connection = parentForm1.conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            ds = new DataSet();
            adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;

            parentForm1.conn.Open();
            ds.Clear();
            adapt.Fill(ds);
            parentForm1.conn.Close();

            cmbVendor.DataSource = ds.Tables[0].DefaultView;
            cmbVendor.ValueMember = "VendorName";
            cmbVendor.DisplayMember = "VendorName";

            toolTip1.SetToolTip(cmbVendor, cmbVendor.SelectedValue.ToString());
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lblEmployeeID.Text != cmbEmployeeID.Text)
                boolNumEmpID = false;

            if (option == 0)
            {
                if (lblStoreCode.Text == "")
                {
                    MessageBox.Show("INCORRECT STORE CODE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (lblEmployeeID.Text == "")
                {
                    MessageBox.Show("INCORRECT EMPLOYEE ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cmbVendor.Text == "")
                {
                    MessageBox.Show("SELECT VENDOR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (vendorBool == false)
                {
                    MessageBox.Show("LOAD VENDOR FIRST...", "ERORR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                vendorName = cmbVendor.Text;

                cmd.CommandText = "Get_Vendor_ID_Code";
                cmd.Connection = parentForm1.conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@VendorName", SqlDbType.NVarChar).Value = vendorName;
                SqlParameter VendorID_Param = cmd.Parameters.Add("@VendorID", SqlDbType.BigInt);
                SqlParameter VendorName_Param = cmd.Parameters.Add("@VendorCode", SqlDbType.NVarChar, 50);
                VendorID_Param.Direction = ParameterDirection.Output;
                VendorName_Param.Direction = ParameterDirection.Output;

                parentForm1.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm1.conn.Close();

                if (cmd.Parameters["@VendorID"].Value != DBNull.Value & cmd.Parameters["@VendorCode"].Value != DBNull.Value)
                {
                    vendorID = Convert.ToInt64(cmd.Parameters["@VendorID"].Value);
                    vendorCode = Convert.ToString(cmd.Parameters["@VendorCode"].Value);

                    cmd.CommandText = "Create_New_PO";
                    cmd.Connection = parentForm1.conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = lblStoreCode.Text;
                    cmd.Parameters.Add("@VendorID", SqlDbType.BigInt).Value = vendorID;
                    cmd.Parameters.Add("@VendorCode", SqlDbType.NVarChar).Value = vendorCode;
                    cmd.Parameters.Add("@VendorName", SqlDbType.NVarChar).Value = vendorName;
                    cmd.Parameters.Add("@CreateDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                    //cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = lblEmployeeID.Text;
                    cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = cmbEmployeeID.Text;

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    Create_PO_Generate_History();

                    parentForm2.dateOption = 0;
                    parentForm2.startDate = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                    parentForm2.endDate = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                    parentForm2.SearchPOList();
                    parentForm2.startDate = string.Empty;
                    parentForm2.endDate = string.Empty;
                    this.Close();
                }
                else if (cmd.Parameters["@VendorID"].Value == DBNull.Value)
                {
                    MessageBox.Show("CAN NOT FIND VENDOR ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (cmd.Parameters["@VendorCode"].Value == DBNull.Value)
                {
                    MessageBox.Show("CAN NOT FIND VENDOR CODE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (option == 1)
            {
                if (lblStoreCode.Text == "")
                {
                    MessageBox.Show("INCORRECT STORE CODE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (lblEmployeeID.Text == "")
                {
                    MessageBox.Show("INCORRECT EMPLOYEE ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cmbVendor.Text == "")
                {
                    MessageBox.Show("SELECT VENDOR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (vendorBool == false)
                {
                    MessageBox.Show("LOAD VENDOR FIRST...", "ERORR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cmbVendor.Text.ToUpper() == parentForm1.WarehouseName1.ToUpper())
                {
                    MessageBox.Show("CAN NOT CREATE WAREHOUSE P/O HERE", "ERORR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                vendorName = cmbVendor.Text;

                cmd.CommandText = "Get_Vendor_ID_Code";
                cmd.Connection = parentForm1.conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@VendorName", SqlDbType.NVarChar).Value = vendorName;
                SqlParameter VendorID_Param = cmd.Parameters.Add("@VendorID", SqlDbType.BigInt);
                SqlParameter VendorName_Param = cmd.Parameters.Add("@VendorCode", SqlDbType.NVarChar, 50);
                VendorID_Param.Direction = ParameterDirection.Output;
                VendorName_Param.Direction = ParameterDirection.Output;

                parentForm1.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm1.conn.Close();

                if (cmd.Parameters["@VendorID"].Value != DBNull.Value & cmd.Parameters["@VendorCode"].Value != DBNull.Value)
                {
                    vendorID = Convert.ToInt64(cmd.Parameters["@VendorID"].Value);
                    vendorCode = Convert.ToString(cmd.Parameters["@VendorCode"].Value);

                    cmd.CommandText = "Create_New_PO_From_SOldItemList";
                    cmd.Connection = parentForm1.conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = lblStoreCode.Text;
                    cmd.Parameters.Add("@VendorID", SqlDbType.BigInt).Value = vendorID;
                    cmd.Parameters.Add("@VendorCode", SqlDbType.NVarChar).Value = vendorCode;
                    cmd.Parameters.Add("@VendorName", SqlDbType.NVarChar).Value = vendorName;
                    cmd.Parameters.Add("@CreateDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                    //cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = lblEmployeeID.Text;
                    cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = cmbEmployeeID.Text;
                    SqlParameter POID_Param = cmd.Parameters.Add("@POID", SqlDbType.BigInt);
                    POID_Param.Direction = ParameterDirection.Output;

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    if (cmd.Parameters["@POID"].Value == DBNull.Value)
                    {

                    }
                    else
                    {
                        POID = Convert.ToInt64(cmd.Parameters["@POID"].Value);

                        cmd.CommandText = "Get_POHeader_Info";
                        cmd.Connection = parentForm1.conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                        SqlParameter EmployeeID_Param = cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar, 15);
                        SqlParameter POStatus_Param = cmd.Parameters.Add("@POStatus", SqlDbType.NVarChar, 20);
                        SqlParameter Vendor_Param = cmd.Parameters.Add("@VendorName", SqlDbType.NVarChar, 50);
                        SqlParameter CreateDate_Param = cmd.Parameters.Add("@CreateDate", SqlDbType.NVarChar, 20);
                        EmployeeID_Param.Direction = ParameterDirection.Output;
                        POStatus_Param.Direction = ParameterDirection.Output;
                        Vendor_Param.Direction = ParameterDirection.Output;
                        CreateDate_Param.Direction = ParameterDirection.Output;

                        parentForm1.conn.Open();
                        cmd.ExecuteNonQuery();
                        parentForm1.conn.Close();

                        if (cmd.Parameters["@EmployeeID"].Value != DBNull.Value)
                            POEmployeeID = cmd.Parameters["@EmployeeID"].Value.ToString();

                        if (cmd.Parameters["@POStatus"].Value != DBNull.Value)
                            POStatus = cmd.Parameters["@POStatus"].Value.ToString();

                        if (cmd.Parameters["@VendorName"].Value != DBNull.Value)
                            POVendor = cmd.Parameters["@VendorName"].Value.ToString();

                        if (cmd.Parameters["@CreateDate"].Value != DBNull.Value)
                            POCreateDate = cmd.Parameters["@CreateDate"].Value.ToString();

                        Create_PO_Generate_History();

                        POMain POMainForm = new POMain(0, 1);
                        POMainForm.parentForm1 = this.parentForm1;
                        POMainForm.parentForm2 = this.parentForm2;
                        POMainForm.parentForm3 = this;
                        POMainForm.parentForm4 = this.parentForm3;
                        POMainForm.Show();

                        //this.Close();
                    }
                    
                    parentForm2.dateOption = 0;
                    parentForm2.startDate = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                    parentForm2.endDate = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                    parentForm2.SearchPOList();
                    parentForm2.startDate = string.Empty;
                    parentForm2.endDate = string.Empty;
                    //this.Close();
                }
                else if (cmd.Parameters["@VendorID"].Value == DBNull.Value)
                {
                    MessageBox.Show("CAN NOT FIND VENDOR ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (cmd.Parameters["@VendorCode"].Value == DBNull.Value)
                {
                    MessageBox.Show("CAN NOT FIND VENDOR CODE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (option == 2)
            {
                if (lblStoreCode.Text == "")
                {
                    MessageBox.Show("INCORRECT STORE CODE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (lblEmployeeID.Text == "")
                {
                    MessageBox.Show("INCORRECT EMPLOYEE ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                /*if (cmbVendor.Text == "")
                {
                    MessageBox.Show("SELECT VENDOR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (vendorBool == false)
                {
                    MessageBox.Show("LOAD VENDOR FIRST...", "ERORR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }*/

                vendorName = cmbVendor.Text;

                cmd.CommandText = "Get_Vendor_ID_Code";
                cmd.Connection = parentForm1.conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@VendorName", SqlDbType.NVarChar).Value = vendorName;
                SqlParameter VendorID_Param = cmd.Parameters.Add("@VendorID", SqlDbType.BigInt);
                SqlParameter VendorName_Param = cmd.Parameters.Add("@VendorCode", SqlDbType.NVarChar, 50);
                VendorID_Param.Direction = ParameterDirection.Output;
                VendorName_Param.Direction = ParameterDirection.Output;

                parentForm1.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm1.conn.Close();

                if (cmd.Parameters["@VendorID"].Value != DBNull.Value & cmd.Parameters["@VendorCode"].Value != DBNull.Value)
                {
                    vendorID = Convert.ToInt64(cmd.Parameters["@VendorID"].Value);
                    vendorCode = Convert.ToString(cmd.Parameters["@VendorCode"].Value);

                    cmd.CommandText = "Create_New_PO2";
                    cmd.Connection = parentForm1.conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = lblStoreCode.Text;
                    cmd.Parameters.Add("@VendorID", SqlDbType.BigInt).Value = vendorID;
                    cmd.Parameters.Add("@VendorCode", SqlDbType.NVarChar).Value = vendorCode;
                    cmd.Parameters.Add("@VendorName", SqlDbType.NVarChar).Value = vendorName;
                    cmd.Parameters.Add("@CreateDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                    //cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = lblEmployeeID.Text;
                    cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = cmbEmployeeID.Text;
                    SqlParameter POID_Param = cmd.Parameters.Add("@POID", SqlDbType.BigInt);
                    POID_Param.Direction = ParameterDirection.Output;

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    if (cmd.Parameters["@POID"].Value != DBNull.Value)
                        POID = Convert.ToInt64(cmd.Parameters["@POID"].Value);

                    Create_PO_Generate_History();

                    parentForm2.dateOption = 0;
                    parentForm2.startDate = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                    parentForm2.endDate = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                    parentForm2.SearchPOList();
                    parentForm2.startDate = string.Empty;
                    parentForm2.endDate = string.Empty;
                    this.Close();
                }
                else if (cmd.Parameters["@VendorID"].Value == DBNull.Value)
                {
                    MessageBox.Show("CAN NOT FIND VENDOR ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (cmd.Parameters["@VendorCode"].Value == DBNull.Value)
                {
                    MessageBox.Show("CAN NOT FIND VENDOR CODE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (option == 3)
            {
                if (lblStoreCode.Text == "")
                {
                    MessageBox.Show("INCORRECT STORE CODE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (lblEmployeeID.Text == "")
                {
                    MessageBox.Show("INCORRECT EMPLOYEE ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cmbVendor.Text == "")
                {
                    MessageBox.Show("SELECT VENDOR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (vendorBool == false)
                {
                    MessageBox.Show("LOAD VENDOR FIRST...", "ERORR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                vendorName = cmbVendor.Text;

                cmd.CommandText = "Get_Vendor_ID_Code";
                cmd.Connection = parentForm1.conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@VendorName", SqlDbType.NVarChar).Value = vendorName;
                SqlParameter VendorID_Param = cmd.Parameters.Add("@VendorID", SqlDbType.BigInt);
                SqlParameter VendorName_Param = cmd.Parameters.Add("@VendorCode", SqlDbType.NVarChar, 50);
                VendorID_Param.Direction = ParameterDirection.Output;
                VendorName_Param.Direction = ParameterDirection.Output;

                parentForm1.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm1.conn.Close();

                if (cmd.Parameters["@VendorID"].Value != DBNull.Value & cmd.Parameters["@VendorCode"].Value != DBNull.Value)
                {
                    vendorID = Convert.ToInt64(cmd.Parameters["@VendorID"].Value);
                    vendorCode = Convert.ToString(cmd.Parameters["@VendorCode"].Value);

                    cmd.CommandText = "Create_New_PO";
                    cmd.Connection = parentForm1.conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = lblStoreCode.Text;
                    cmd.Parameters.Add("@VendorID", SqlDbType.BigInt).Value = vendorID;
                    cmd.Parameters.Add("@VendorCode", SqlDbType.NVarChar).Value = vendorCode;
                    cmd.Parameters.Add("@VendorName", SqlDbType.NVarChar).Value = vendorName;
                    cmd.Parameters.Add("@CreateDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                    //cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = lblEmployeeID.Text;
                    cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = cmbEmployeeID.Text;

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    Create_PO_Generate_History();

                    parentForm4.dateOption = 0;
                    parentForm4.startDate = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                    parentForm4.endDate = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                    parentForm4.storeOption = 0;
                    parentForm4.SearchPOList();
                    parentForm4.startDate = string.Empty;
                    parentForm4.endDate = string.Empty;
                    this.Close();
                }
                else if (cmd.Parameters["@VendorID"].Value == DBNull.Value)
                {
                    MessageBox.Show("CAN NOT FIND VENDOR ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (cmd.Parameters["@VendorCode"].Value == DBNull.Value)
                {
                    MessageBox.Show("CAN NOT FIND VENDOR CODE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            /*if (boolNumEmpID == false)
            {
                cmd.CommandText = "Create_PO_Generate_History";
                cmd.Connection = parentForm1.conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@PGHStoreCode", SqlDbType.NVarChar).Value = lblStoreCode.Text;
                cmd.Parameters.Add("@PGHPOID", SqlDbType.BigInt).Value = POID;
                cmd.Parameters.Add("@PGHVendorName", SqlDbType.NVarChar).Value = vendorName;
                cmd.Parameters.Add("@PGHGenerateID", SqlDbType.NVarChar).Value = cmbEmployeeID.Text;
                cmd.Parameters.Add("@PGHOrderID", SqlDbType.NVarChar).Value = lblEmployeeID.Text;
                cmd.Parameters.Add("@PGHCreateDate", SqlDbType.DateTime).Value = DateTime.Now;

                parentForm1.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm1.conn.Close();
            }*/
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Create_PO_Generate_History()
        {
            if (boolNumEmpID == false)
            {
                cmd.CommandText = "Create_PO_Generate_History";
                cmd.Connection = parentForm1.conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@PGHStoreCode", SqlDbType.NVarChar).Value = lblStoreCode.Text;
                cmd.Parameters.Add("@PGHPOID", SqlDbType.BigInt).Value = POID;
                cmd.Parameters.Add("@PGHVendorName", SqlDbType.NVarChar).Value = vendorName;
                cmd.Parameters.Add("@PGHGenerateID", SqlDbType.NVarChar).Value = lblEmployeeID.Text;
                cmd.Parameters.Add("@PGHOrderID", SqlDbType.NVarChar).Value = cmbEmployeeID.Text;
                cmd.Parameters.Add("@PGHCreateDate", SqlDbType.DateTime).Value = DateTime.Now;

                parentForm1.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm1.conn.Close();
            }
        }

        private void cmbVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(cmbVendor, cmbVendor.SelectedValue.ToString());
        }
    }
}