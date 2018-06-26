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
    public partial class RegisterNewItem : Form
    {
        public LogInManagements parentForm;
        public SqlCommand cmd = new SqlCommand();
        public SqlCommand cmd2 = new SqlCommand();
        public DataSet ds;
        public SqlDataAdapter adapt = new SqlDataAdapter();
        public SqlConnection newConn = new SqlConnection();

        int index1, index2;
        int checkNum;
        int checkNum2;

        Int64 newNumGen;
        int newNumGenLen;
        string newNumGenToString;

        double ItmRetailPrice, ItmCostPrice;
        double ItmPrc1, ItmPrc2, ItmPrc3, ItmPrc4, ItmPrc5, ItmPrc6, ItmPrc7, ItmPrc8, ItmPrc9, ItmPrc10;
        double ItmStylistPrice;
        int ItmReservedQty, ItmStockMin, ItmOnHand;
        string ItmRegisterDate;
        double ItmTax;

        bool vendorBool = false, brandBool = false, sizeBool = false, colorBool = false;

        public string sDate, eDate;

        bool boolFromOtherStore = false;

        public RegisterNewItem()
        {
            InitializeComponent();
        }

        public void btnLoadVendor_Click(object sender, EventArgs e)
        {
            vendorBool = true;

            cmd.CommandText = "Get_VendorName";
            cmd.Connection = parentForm.conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            ds = new DataSet();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            ds.Clear();
            adapt.Fill(ds);
            parentForm.conn.Close();

            cmbVendor.DataSource = ds.Tables[0].DefaultView;
            cmbVendor.ValueMember = "VendorName";
            cmbVendor.DisplayMember = "VendorName";

            toolTip1.SetToolTip(cmbVendor, cmbVendor.SelectedValue.ToString());
        }

        public void btnLoadBrand_Click(object sender, EventArgs e)
        {
            brandBool = true;

            cmd.CommandText = "Get_BrandName";
            cmd.Connection = parentForm.conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            ds = new DataSet();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            ds.Clear();
            adapt.Fill(ds);
            parentForm.conn.Close();

            cmbBrand.DataSource = ds.Tables[0].DefaultView;
            cmbBrand.ValueMember = "BrandName";
            cmbBrand.DisplayMember = "BrandName";

            toolTip2.SetToolTip(cmbBrand, cmbBrand.SelectedValue.ToString());
        }

        public void btnLoadSize_Click(object sender, EventArgs e)
        {
            sizeBool = true;

            cmd.CommandText = "Get_SizeName";
            cmd.Connection = parentForm.conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            ds = new DataSet();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            ds.Clear();
            adapt.Fill(ds);
            parentForm.conn.Close();

            cmbSize.DataSource = ds.Tables[0].DefaultView;
            cmbSize.ValueMember = "SizeName";
            cmbSize.DisplayMember = "SizeName";
        }

        public void btnLoadColor_Click(object sender, EventArgs e)
        {
            colorBool = true;

            cmd.CommandText = "Get_ColorName";
            cmd.Connection = parentForm.conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            ds = new DataSet();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            ds.Clear();
            adapt.Fill(ds);
            parentForm.conn.Close();

            cmbColor.DataSource = ds.Tables[0].DefaultView;
            cmbColor.ValueMember = "ColorName";
            cmbColor.DisplayMember = "ColorName";
        }

        private void RegisterNewItem_Load(object sender, EventArgs e)
        {
            if (parentForm.userLevel >= parentForm.btnInventoryGenerateNewUpc)
            {
                if (parentForm.employeeID.ToUpper() == "ADMIN")
                {
                    //if (parentForm.StoreCode == "TH" | parentForm.StoreCode == "B4UWH")
                    if (parentForm.StoreCode == "B4UHQ")
                        btnGenerateNewUpc.Enabled = true;
                }
                else
                {
                    if (parentForm.specialCode == parentForm.txtSpecialCode.Text.Trim().ToString().ToUpper())
                    {
                        //if (parentForm.StoreCode == "TH" | parentForm.StoreCode == "B4UWH")
                        if (parentForm.StoreCode == "B4UHQ")
                            btnGenerateNewUpc.Enabled = true;
                    }
                }
            }

            this.Text = "REGISTER NEW ITEM - " + parentForm.employeeID + " LOGGED IN " + parentForm.storeName;

            cmd.CommandText = "Get_Category_Group1";
            cmd.Connection = parentForm.conn;
            cmd.CommandType = CommandType.StoredProcedure;
            ds = new DataSet();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            ds.Clear();
            adapt.Fill(ds);
            parentForm.conn.Close();

            cmbCategory1.DataSource = ds.Tables[0].DefaultView;
            cmbCategory1.ValueMember = "ItmGp_Desc";
            cmbCategory1.DisplayMember = "ItmGp_Desc";

            txtStartDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            txtEndDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

            txtUpc.Select();
            txtUpc.Focus();
        }

        private void cmbCategory1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory1.SelectedIndex == 0 | cmbCategory1.SelectedIndex > 6)
            {
                cmbCategory2.DataSource = null;
                cmbCategory2.Items.Clear();
                cmbCategory3.DataSource = null;
                cmbCategory3.Items.Clear();
                return;
            }

            cmd.CommandText = "Get_Category_Group2";
            cmd.Connection = parentForm.conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@ItmGp_Parents", SqlDbType.Int).Value = cmbCategory1.SelectedIndex;
            ds = new DataSet();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            adapt.Fill(ds);
            parentForm.conn.Close();

            cmbCategory2.DataSource = ds.Tables[0].DefaultView;
            cmbCategory2.ValueMember = "ItmGp_Desc";
            cmbCategory2.DisplayMember = "ItmGp_Desc";

            ds.Tables.Clear();
        }

        private void cmbCategory2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCategory3.DataSource = null;
            cmbCategory3.Items.Clear();

            index1 = cmbCategory1.SelectedIndex;
            index2 = cmbCategory2.SelectedIndex;


            cmd.CommandText = "Get_Category_Group3";
            cmd.Connection = parentForm.conn;
            cmd.CommandType = CommandType.StoredProcedure;
            ds = new DataSet();
            
            switch (index1)
            {
                case 6:
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@ItmGp_Parents", SqlDbType.Int).Value = index1 + 1;
                    cmd.Parameters.Add("@ItmGp_Parents2", SqlDbType.Int).Value = index2;
                    adapt.SelectCommand = cmd;

                    parentForm.conn.Open();
                    adapt.Fill(ds);
                    parentForm.conn.Close();

                    cmbCategory3.DataSource = ds.Tables[0].DefaultView;
                    cmbCategory3.ValueMember = "ItmGp_Desc";
                    cmbCategory3.DisplayMember = "ItmGp_Desc";
                    break;
                default:
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@ItmGp_Parents", SqlDbType.Int).Value = index1;
                    cmd.Parameters.Add("@ItmGp_Parents2", SqlDbType.Int).Value = index2;
                    adapt.SelectCommand = cmd;

                    parentForm.conn.Open();
                    adapt.Fill(ds);
                    parentForm.conn.Close();

                    cmbCategory3.DataSource = ds.Tables[0].DefaultView;
                    cmbCategory3.ValueMember = "ItmGp_Desc";
                    cmbCategory3.DisplayMember = "ItmGp_Desc";
                    break;
            }
        }

        private void btnUpcCheck_Click(object sender, EventArgs e)
        {
            if (txtUpc.Text != "" & txtUpc.Text.Length < 15)
            {
                cmd.CommandText = "Check_Upc";
                cmd.Connection = parentForm.conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = txtUpc.Text.Trim().ToString();
                SqlParameter CheckNum_Param = cmd.Parameters.Add("@CheckNum", SqlDbType.Int);
                CheckNum_Param.Direction = ParameterDirection.Output;

                parentForm.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm.conn.Close();

                checkNum = Convert.ToInt16(cmd.Parameters["@CheckNum"].Value);

                if (checkNum > 0)
                {
                    MessageBox.Show("THIS UPC NUMBER IS ALREADY EXIST", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUpc.SelectAll();
                    txtUpc.Focus();
                }
                else
                {
                    MessageBox.Show("THIS UPC NUMBER IS AVAILABLE", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUpc.Enabled = false;
                    btnRegister.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("INVALID UPC NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUpc.SelectAll();
                txtUpc.Focus();
            }
        }

        private void btnGenerateNewUpc_Click(object sender, EventArgs e)
        {
            if (parentForm.StoreCode == "B4UHQ")
            {
                if (txtUpc.Enabled == false)
                {
                    MessageBox.Show("YOU ALREADY GOT UPC NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                boolFromOtherStore = false;

                cmd.CommandText = "Get_Latest_Number_Generated";
                cmd.Connection = parentForm.conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Seed", SqlDbType.NVarChar).Value = "B4U0%";
                SqlParameter LatestNumGen_Param = cmd.Parameters.Add("@LatestNumGen", SqlDbType.NVarChar, 15);
                LatestNumGen_Param.Direction = ParameterDirection.Output;

                parentForm.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm.conn.Close();

                if (cmd.Parameters["@LatestNumGen"].Value == DBNull.Value)
                {
                    newNumGen = 0;
                }
                else
                {
                    newNumGen = Convert.ToInt64((cmd.Parameters["@LatestNumGen"].Value.ToString().Substring(3))) + 1;
                }
                newNumGenLen = Convert.ToString(newNumGen).Length;

                switch (newNumGenLen)
                {
                    case 1:
                        newNumGenToString = "B4U00000000" + Convert.ToString(newNumGen);
                        newNumGenLen = 0;
                        break;
                    case 2:
                        newNumGenToString = "B4U0000000" + Convert.ToString(newNumGen);
                        newNumGenLen = 0;
                        break;
                    case 3:
                        newNumGenToString = "B4U000000" + Convert.ToString(newNumGen);
                        newNumGenLen = 0;
                        break;
                    case 4:
                        newNumGenToString = "B4U00000" + Convert.ToString(newNumGen);
                        newNumGenLen = 0;
                        break;
                    case 5:
                        newNumGenToString = "B4U0000" + Convert.ToString(newNumGen);
                        newNumGenLen = 0;
                        break;
                    case 6:
                        newNumGenToString = "B4U000" + Convert.ToString(newNumGen);
                        newNumGenLen = 0;
                        break;
                    case 7:
                        newNumGenToString = "B4U00" + Convert.ToString(newNumGen);
                        newNumGenLen = 0;
                        break;
                    case 8:
                        newNumGenToString = "B4U0" + Convert.ToString(newNumGen);
                        newNumGenLen = 0;
                        break;
                    case 9:
                        newNumGenToString = "B4U" + Convert.ToString(newNumGen);
                        newNumGenLen = 0;
                        break;
                    default:
                        newNumGenToString = Convert.ToString(newNumGen);
                        newNumGenLen = 0;
                        break;
                }

                cmd.CommandText = "Check_Upc";
                cmd.Connection = parentForm.conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = newNumGenToString;
                SqlParameter CheckNum_Param = cmd.Parameters.Add("@CheckNum", SqlDbType.Int);
                CheckNum_Param.Direction = ParameterDirection.Output;

                parentForm.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm.conn.Close();

                checkNum = Convert.ToInt16(cmd.Parameters["@CheckNum"].Value);

                if (checkNum > 0)
                {
                    MessageBox.Show("UPC GENERATE ERROR. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUpc.Clear();
                    txtUpc.SelectAll();
                    txtUpc.Focus();
                    return;

                    /*for (int i = 2; i <= 50; i++)
                    {
                        newNumGen = Convert.ToInt64((cmd.Parameters["@LatestNumGen"].Value.ToString().Substring(3))) + i;
                        newNumGenLen = Convert.ToString(newNumGen).Length;

                        switch (newNumGenLen)
                        {
                            case 1:
                                newNumGenToString = "B4U00000000" + Convert.ToString(newNumGen);
                                newNumGenLen = 0;
                                break;
                            case 2:
                                newNumGenToString = "B4U0000000" + Convert.ToString(newNumGen);
                                newNumGenLen = 0;
                                break;
                            case 3:
                                newNumGenToString = "B4U000000" + Convert.ToString(newNumGen);
                                newNumGenLen = 0;
                                break;
                            case 4:
                                newNumGenToString = "B4U00000" + Convert.ToString(newNumGen);
                                newNumGenLen = 0;
                                break;
                            case 5:
                                newNumGenToString = "B4U0000" + Convert.ToString(newNumGen);
                                newNumGenLen = 0;
                                break;
                            case 6:
                                newNumGenToString = "B4U000" + Convert.ToString(newNumGen);
                                newNumGenLen = 0;
                                break;
                            case 7:
                                newNumGenToString = "B4U00" + Convert.ToString(newNumGen);
                                newNumGenLen = 0;
                                break;
                            case 8:
                                newNumGenToString = "B4U0" + Convert.ToString(newNumGen);
                                newNumGenLen = 0;
                                break;
                            case 9:
                                newNumGenToString = "B4U" + Convert.ToString(newNumGen);
                                newNumGenLen = 0;
                                break;
                            default:
                                newNumGenToString = "B4U" + Convert.ToString(newNumGen);
                                newNumGenLen = 0;
                                break;
                        }

                        cmd.CommandText = "Check_Upc";
                        cmd.Connection = parentForm.conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = newNumGenToString;
                        CheckNum_Param = cmd.Parameters.Add("@CheckNum", SqlDbType.Int);
                        CheckNum_Param.Direction = ParameterDirection.Output;

                        parentForm.conn.Open();
                        cmd.ExecuteNonQuery();
                        parentForm.conn.Close();

                        checkNum = Convert.ToInt16(cmd.Parameters["@CheckNum"].Value);

                        if (checkNum == 0)
                        {
                            txtUpc.Text = Convert.ToString(newNumGenToString);
                            btnUpcCheck_Click(null, null);
                            return;
                        }
                    }*/
                }
                else
                {
                    txtUpc.Text = Convert.ToString(newNumGenToString);
                    btnUpcCheck_Click(null, null);
                    return;
                }
            }
            /*else if (parentForm.StoreCode == "B4UWH")
            {
                if (txtUpc.Enabled == false)
                {
                    MessageBox.Show("YOU ALREADY GOT UPC NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (DBConnectionStatus(parentForm.THCS_IP) == false)
                {
                    MessageBox.Show("TEMPLE HILLS DB CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                boolFromOtherStore = true;

                cmd.CommandText = "Get_Latest_Number_Generated";
                newConn.ConnectionString = parentForm.THCS_IP;
                cmd.Connection = newConn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Seed", SqlDbType.NVarChar).Value = "B4U0%";
                SqlParameter LatestNumGen_Param = cmd.Parameters.Add("@LatestNumGen", SqlDbType.NVarChar, 15);
                LatestNumGen_Param.Direction = ParameterDirection.Output;

                newConn.Open();
                cmd.ExecuteNonQuery();
                newConn.Close();

                if (cmd.Parameters["@LatestNumGen"].Value == DBNull.Value)
                {
                    newNumGen = 0;
                }
                else
                {
                    newNumGen = Convert.ToInt64((cmd.Parameters["@LatestNumGen"].Value.ToString().Substring(3))) + 1;
                }
                newNumGenLen = Convert.ToString(newNumGen).Length;

                switch (newNumGenLen)
                {
                    case 1:
                        newNumGenToString = "B4U00000000" + Convert.ToString(newNumGen);
                        newNumGenLen = 0;
                        break;
                    case 2:
                        newNumGenToString = "B4U0000000" + Convert.ToString(newNumGen);
                        newNumGenLen = 0;
                        break;
                    case 3:
                        newNumGenToString = "B4U000000" + Convert.ToString(newNumGen);
                        newNumGenLen = 0;
                        break;
                    case 4:
                        newNumGenToString = "B4U00000" + Convert.ToString(newNumGen);
                        newNumGenLen = 0;
                        break;
                    case 5:
                        newNumGenToString = "B4U0000" + Convert.ToString(newNumGen);
                        newNumGenLen = 0;
                        break;
                    case 6:
                        newNumGenToString = "B4U000" + Convert.ToString(newNumGen);
                        newNumGenLen = 0;
                        break;
                    case 7:
                        newNumGenToString = "B4U00" + Convert.ToString(newNumGen);
                        newNumGenLen = 0;
                        break;
                    case 8:
                        newNumGenToString = "B4U0" + Convert.ToString(newNumGen);
                        newNumGenLen = 0;
                        break;
                    case 9:
                        newNumGenToString = "B4U" + Convert.ToString(newNumGen);
                        newNumGenLen = 0;
                        break;
                    default:
                        newNumGenToString = Convert.ToString(newNumGen);
                        newNumGenLen = 0;
                        break;
                }

                cmd.CommandText = "Check_Upc";
                newConn.ConnectionString = parentForm.THCS_IP;
                cmd.Connection = newConn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = newNumGenToString;
                SqlParameter CheckNum_Param = cmd.Parameters.Add("@CheckNum", SqlDbType.Int);
                CheckNum_Param.Direction = ParameterDirection.Output;

                newConn.Open();
                cmd.ExecuteNonQuery();
                newConn.Close();

                checkNum = Convert.ToInt16(cmd.Parameters["@CheckNum"].Value);

                cmd.CommandText = "Check_Upc";
                cmd.Connection = parentForm.conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = newNumGenToString;
                SqlParameter CheckNum_Param2 = cmd.Parameters.Add("@CheckNum", SqlDbType.Int);
                CheckNum_Param2.Direction = ParameterDirection.Output;

                parentForm.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm.conn.Close();

                checkNum2 = Convert.ToInt16(cmd.Parameters["@CheckNum"].Value);

                if (checkNum > 0)
                {
                    MessageBox.Show("UPC " + newNumGenToString + " ALREADY EXIST IN TEMPLE HILLS. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUpc.Clear();
                    txtUpc.SelectAll();
                    txtUpc.Focus();
                    return;
                }
                else if (checkNum2 > 0)
                {
                    MessageBox.Show("UPC " + newNumGenToString + " ALREADY EXIST IN WAREHOUSE. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUpc.Clear();
                    txtUpc.SelectAll();
                    txtUpc.Focus();
                    return;
                }
                else
                {
                    txtUpc.Text = Convert.ToString(newNumGenToString);
                    btnUpcCheck_Click(null, null);
                    return;
                }
            }*/
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtUpc.Text == "")
            {
                MessageBox.Show("INPUT ITEM UPC NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUpc.SelectAll();
                txtUpc.Focus();

                return;
            }

            if (cmbVendor.Text == "")
            {
                MessageBox.Show("INPUT ITEM VENDOR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbVendor.SelectAll();
                cmbVendor.Focus();

                return;
            }

            if (cmbBrand.Text == "")
            {
                MessageBox.Show("INPUT ITEM BRAND", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbBrand.SelectAll();
                cmbBrand.Focus();

                return;
            }

            if (txtName.Text == "")
            {
                MessageBox.Show("INPUT ITEM NAME", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.SelectAll();
                txtName.Focus();

                return;
            }

            if (txtModelNum.Text == "")
            {
                MessageBox.Show("INPUT ITEM MODEL NUM", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtModelNum.SelectAll();
                txtModelNum.Focus();

                return;
            }

            if (txtBin.Text == "")
            {
                MessageBox.Show("INPUT ITEM BIN NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBin.SelectAll();
                txtBin.Focus();

                return;
            }

            if (cmbSize.Text == "")
            {
                MessageBox.Show("INPUT ITEM SIZE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSize.SelectAll();
                cmbSize.Focus();

                return;
            }

            if (cmbColor.Text == "")
            {
                MessageBox.Show("INPUT ITEM COLOR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbColor.SelectAll();
                cmbColor.Focus();

                return;
            }

            if (double.TryParse(txtRetailPrice.Text, out ItmRetailPrice))
            {
            }
            else
            {
                MessageBox.Show("INPUT VALID ITEM RETAIL PRICE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRetailPrice.SelectAll();
                txtRetailPrice.Focus();

                return;
            }

            if (double.TryParse(txtCostPrice.Text, out ItmCostPrice))
            {
            }
            else
            {
                MessageBox.Show("INPUT VALID ITEM COST PRICE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCostPrice.SelectAll();
                txtCostPrice.Focus();

                return;
            }

            if (int.TryParse(txtMinStock.Text, out ItmStockMin))
            {
            }
            else
            {
                MessageBox.Show("INPUT VALID ITEM MINIMUM STOCK", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMinStock.SelectAll();
                txtMinStock.Focus();

                return;
            }

            if (int.TryParse(txtOnHand.Text, out ItmOnHand))
            {
            }
            else
            {
                MessageBox.Show("INPUT VALID ITEM ON HAND", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOnHand.SelectAll();
                txtOnHand.Focus();

                return;
            }

            if (cmbCategory1.SelectedIndex < 1 | cmbCategory1.Text == "")
            {
                MessageBox.Show("SELECT CATEGORY 1", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if (cmbCategory2.SelectedIndex < 1 | cmbCategory2.Text == "")
            //{
            //    MessageBox.Show("SELECT CATEGORY 2", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //if (cmbCategory3.SelectedIndex < 0 | cmbCategory3.Text == "")
            //{
            //    MessageBox.Show("SELECT CATEGORY 3", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            if (vendorBool == false)
            {
                MessageBox.Show("LOAD VENDOR LIST AND MAKE SURE WE HAVE THIS VENDOR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnAddVendor.TabStop = true;
                return;
            }

            if (brandBool == false)
            {
                MessageBox.Show("LOAD BRAND LIST AND MAKE SURE WE HAVE THIS BRAND", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnAddBrand.TabStop = true;
                return;
            }

            if (sizeBool == false)
            {
                MessageBox.Show("LOAD SIZE LIST AND MAKE SURE WE HAVE THIS SIZE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnAddSize.TabStop = true;
                return;
            }

            if (colorBool == false)
            {
                MessageBox.Show("LOAD COLOR LIST AND MAKE SURE WE HAVE THIS COLOR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnAddColor.TabStop = true;
                return;
            }

            cmd.CommandText = "Register_New_Item";
            cmd.Connection = parentForm.conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@ItmStoreCode", SqlDbType.NVarChar).Value = parentForm.StoreCode.ToUpper();
            cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = cmbBrand.Text.Trim().ToString().ToUpper();
            cmd.Parameters.Add("@ItmSubBrand", SqlDbType.NVarChar).Value = txtSubBrand.Text.Trim().ToUpper().ToString();
            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = txtName.Text.Trim().ToString().ToUpper();
            cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = cmbSize.Text.Trim().ToString().ToUpper();
            cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = cmbColor.Text.Trim().ToString().ToUpper();
            cmd.Parameters.Add("@ItmModelNum", SqlDbType.NVarChar).Value = txtModelNum.Text.Trim().ToString().ToUpper();

            if (cmbCategory1.SelectedIndex < 6)
            {
                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = cmbCategory1.SelectedIndex;
            }
            else
            {
                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = (cmbCategory1.SelectedIndex + 1);
            }

            cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = cmbCategory2.SelectedIndex;
            cmd.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = cmbCategory3.SelectedIndex + 1;
            cmd.Parameters.Add("@ItmGroup4", SqlDbType.NVarChar).Value = 0;
            cmd.Parameters.Add("@ItmGroup5", SqlDbType.NVarChar).Value = 0;

            ItmReservedQty = 0;

            cmd.Parameters.Add("@ItmReservedQty", SqlDbType.Int).Value = ItmReservedQty;
            cmd.Parameters.Add("@ItmStockMin", SqlDbType.Int).Value = ItmStockMin;
            cmd.Parameters.Add("@ItmOnHand", SqlDbType.Int).Value = ItmOnHand;

            ItmPrc1 = ItmRetailPrice;
            ItmPrc2 = ItmPrc3 = ItmPrc4 = ItmPrc5 = ItmPrc6 = ItmPrc7 = ItmPrc8 = ItmPrc9 = ItmPrc10 = ItmStylistPrice = 0;

            cmd.Parameters.Add("@ItmRetailPrice", SqlDbType.Money).Value = ItmRetailPrice;
            cmd.Parameters.Add("@ItmCostPrice", SqlDbType.Money).Value = ItmCostPrice;
            cmd.Parameters.Add("@ItmPrc1", SqlDbType.Money).Value = ItmPrc1;
            cmd.Parameters.Add("@ItmPrc2", SqlDbType.Money).Value = ItmPrc2;
            cmd.Parameters.Add("@ItmPrc3", SqlDbType.Money).Value = ItmPrc3;
            cmd.Parameters.Add("@ItmPrc4", SqlDbType.Money).Value = ItmPrc4;
            cmd.Parameters.Add("@ItmPrc5", SqlDbType.Money).Value = ItmPrc5;
            cmd.Parameters.Add("@ItmPrc6", SqlDbType.Money).Value = ItmPrc6;
            cmd.Parameters.Add("@ItmPrc7", SqlDbType.Money).Value = ItmPrc7;
            cmd.Parameters.Add("@ItmPrc8", SqlDbType.Money).Value = ItmPrc8;
            cmd.Parameters.Add("@ItmPrc9", SqlDbType.Money).Value = ItmPrc9;
            cmd.Parameters.Add("@ItmPrc10", SqlDbType.Money).Value = ItmPrc10;
            cmd.Parameters.Add("@ItmStylistPrice", SqlDbType.Money).Value = ItmStylistPrice;

            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = txtUpc.Text.ToUpper();
            cmd.Parameters.Add("@ItmBin", SqlDbType.NVarChar).Value = txtBin.Text.ToUpper();
            cmd.Parameters.Add("@ItmVendor", SqlDbType.NVarChar).Value = cmbVendor.Text.Trim().ToString().ToUpper();
            cmd.Parameters.Add("@ItmImage", SqlDbType.NVarChar).Value = "-";

            //ItmRegisterDate = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            cmd.Parameters.Add("@ItmRegisterDate", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@ItmRegisterID", SqlDbType.NVarChar).Value = parentForm.employeeID.ToUpper().ToString();
            cmd.Parameters.Add("@ItmUpdateDate", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@ItmUpdateID", SqlDbType.NVarChar).Value = parentForm.employeeID.ToUpper().ToString();

            if (parentForm.StoreCode == "B4UHQ")
            {
                ItmTax = 0.06;
            }
            else if (parentForm.StoreCode == "B4UWH")
            {
                ItmTax = 0.06;
            }
            else if (parentForm.StoreCode == "TH")
            {
                ItmTax = 0.06;
            }
            else if (parentForm.StoreCode == "OH")
            {
                ItmTax = 0.06;
            }
            else if (parentForm.StoreCode == "UM")
            {
                ItmTax = 0.06;
            }
            else if (parentForm.StoreCode == "CH")
            {
                ItmTax = 0.06;
            }
            else if (parentForm.StoreCode == "WM")
            {
                ItmTax = 0.06;
            }
            else if (parentForm.StoreCode == "CV")
            {
                ItmTax = 0.06;
            }
            else if (parentForm.StoreCode == "PW")
            {
                ItmTax = 0.05;
            }
            else if (parentForm.StoreCode == "WB")
            {
                ItmTax = 0.05;
            }
            else if (parentForm.StoreCode == "WD")
            {
                ItmTax = 0.06;
            }
            else if (parentForm.StoreCode == "GB")
            {
                ItmTax = 0.06;
            }
            else if (parentForm.StoreCode == "BW")
            {
                ItmTax = 0.06;
            }

            cmd.Parameters.Add("@ItmTax", SqlDbType.Money).Value = ItmTax;

            cmd.Parameters.Add("@ItmTaxable", SqlDbType.Bit).Value = true;
            cmd.Parameters.Add("@ItmMixMatch", SqlDbType.Bit).Value = false;
            cmd.Parameters.Add("@ItmMixMatchVal", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@ItmMixMatchPrc", SqlDbType.Money).Value = 0;
            cmd.Parameters.Add("@ItmActive", SqlDbType.Bit).Value = true;

            parentForm.conn.Open();
            cmd.ExecuteNonQuery();
            parentForm.conn.Close();

            MessageBox.Show("SUCCESSFULLY REGISTERED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (cmbCategory1.SelectedIndex == 2)
            {
                cmbColor.Text = "";
                Resetting();
            }
            else
            {
                Resetting();
            }

            /*if (boolFromOtherStore == true)
            {
                if (DBConnectionStatus(parentForm.THCS_IP) == false)
                {
                    MessageBox.Show("TEMPLE HILLS DB CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                cmd.CommandText = "Register_New_Item";
                cmd.Connection = parentForm.conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@ItmStoreCode", SqlDbType.NVarChar).Value = parentForm.StoreCode.ToUpper();
                cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = cmbBrand.Text.Trim().ToString().ToUpper();
                cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = txtName.Text.Trim().ToString().ToUpper();
                cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = cmbSize.Text.Trim().ToString().ToUpper();
                cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = cmbColor.Text.Trim().ToString().ToUpper();
                cmd.Parameters.Add("@ItmModelNum", SqlDbType.NVarChar).Value = txtModelNum.Text.Trim().ToString().ToUpper();

                if (cmbCategory1.SelectedIndex < 6)
                {
                    cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = cmbCategory1.SelectedIndex;
                }
                else
                {
                    cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = (cmbCategory1.SelectedIndex + 1);
                }

                cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = cmbCategory2.SelectedIndex;
                cmd.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = cmbCategory3.SelectedIndex + 1;
                cmd.Parameters.Add("@ItmGroup4", SqlDbType.NVarChar).Value = 0;
                cmd.Parameters.Add("@ItmGroup5", SqlDbType.NVarChar).Value = 0;

                ItmReservedQty = 0;

                cmd.Parameters.Add("@ItmReservedQty", SqlDbType.Int).Value = ItmReservedQty;
                cmd.Parameters.Add("@ItmStockMin", SqlDbType.Int).Value = ItmStockMin;
                cmd.Parameters.Add("@ItmOnHand", SqlDbType.Int).Value = ItmOnHand;

                ItmPrc1 = ItmRetailPrice;
                ItmPrc2 = ItmPrc3 = ItmPrc4 = ItmPrc5 = ItmPrc6 = ItmPrc7 = ItmPrc8 = ItmPrc9 = ItmPrc10 = ItmStylistPrice = 0;

                cmd.Parameters.Add("@ItmRetailPrice", SqlDbType.Money).Value = ItmRetailPrice;
                cmd.Parameters.Add("@ItmCostPrice", SqlDbType.Money).Value = ItmCostPrice;
                cmd.Parameters.Add("@ItmPrc1", SqlDbType.Money).Value = ItmPrc1;
                cmd.Parameters.Add("@ItmPrc2", SqlDbType.Money).Value = ItmPrc2;
                cmd.Parameters.Add("@ItmPrc3", SqlDbType.Money).Value = ItmPrc3;
                cmd.Parameters.Add("@ItmPrc4", SqlDbType.Money).Value = ItmPrc4;
                cmd.Parameters.Add("@ItmPrc5", SqlDbType.Money).Value = ItmPrc5;
                cmd.Parameters.Add("@ItmPrc6", SqlDbType.Money).Value = ItmPrc6;
                cmd.Parameters.Add("@ItmPrc7", SqlDbType.Money).Value = ItmPrc7;
                cmd.Parameters.Add("@ItmPrc8", SqlDbType.Money).Value = ItmPrc8;
                cmd.Parameters.Add("@ItmPrc9", SqlDbType.Money).Value = ItmPrc9;
                cmd.Parameters.Add("@ItmPrc10", SqlDbType.Money).Value = ItmPrc10;
                cmd.Parameters.Add("@ItmStylistPrice", SqlDbType.Money).Value = ItmStylistPrice;

                cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = txtUpc.Text.ToUpper();
                cmd.Parameters.Add("@ItmBin", SqlDbType.NVarChar).Value = txtBin.Text.ToUpper();
                cmd.Parameters.Add("@ItmVendor", SqlDbType.NVarChar).Value = cmbVendor.Text.Trim().ToString().ToUpper();
                cmd.Parameters.Add("@ItmImage", SqlDbType.NVarChar).Value = "-";

                //DateTime currentTime = DateTime.Now;
                //ItmRegisterDate = string.Format("{0:d}", currentTime);
                ItmRegisterDate = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                cmd.Parameters.Add("@ItmRegisterDate", SqlDbType.NVarChar).Value = ItmRegisterDate;


                if (parentForm.StoreCode == "B4UHQ")
                {
                    ItmTax = 0.06;
                }
                else if (parentForm.StoreCode == "B4UWH")
                {
                    ItmTax = 0.06;
                }
                else if (parentForm.StoreCode == "TH")
                {
                    ItmTax = 0.06;
                }
                else if (parentForm.StoreCode == "OH")
                {
                    ItmTax = 0.06;
                }
                else if (parentForm.StoreCode == "UM")
                {
                    ItmTax = 0.06;
                }
                else if (parentForm.StoreCode == "CH")
                {
                    ItmTax = 0.06;
                }
                else if (parentForm.StoreCode == "WM")
                {
                    ItmTax = 0.06;
                }
                else if (parentForm.StoreCode == "CV")
                {
                    ItmTax = 0.06;
                }
                else if (parentForm.StoreCode == "PW")
                {
                    ItmTax = 0.05;
                }
                else if (parentForm.StoreCode == "WB")
                {
                    ItmTax = 0.05;
                }
                else if (parentForm.StoreCode == "WD")
                {
                    ItmTax = 0.06;
                }
                else if (parentForm.StoreCode == "GB")
                {
                    ItmTax = 0.06;
                }

                cmd.Parameters.Add("@ItmTax", SqlDbType.Money).Value = ItmTax;

                cmd.Parameters.Add("@ItmTaxable", SqlDbType.Bit).Value = true;
                cmd.Parameters.Add("@ItmMixMatch", SqlDbType.Bit).Value = false;
                cmd.Parameters.Add("@ItmMixMatchVal", SqlDbType.Int).Value = 0;
                cmd.Parameters.Add("@ItmMixMatchPrc", SqlDbType.Money).Value = 0;
                cmd.Parameters.Add("@ItmActive", SqlDbType.Bit).Value = true;

                parentForm.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm.conn.Close();

                cmd2.CommandText = "Register_New_Item";
                newConn.ConnectionString = parentForm.THCS_IP;
                cmd2.Connection = newConn;
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Clear();
                cmd2.Parameters.Add("@ItmStoreCode", SqlDbType.NVarChar).Value = "TH";
                cmd2.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = cmbBrand.Text.Trim().ToString().ToUpper();
                cmd2.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = txtName.Text.Trim().ToString().ToUpper();
                cmd2.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = cmbSize.Text.Trim().ToString().ToUpper();
                cmd2.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = cmbColor.Text.Trim().ToString().ToUpper();
                cmd2.Parameters.Add("@ItmModelNum", SqlDbType.NVarChar).Value = txtModelNum.Text.Trim().ToString().ToUpper();

                if (cmbCategory1.SelectedIndex < 6)
                {
                    cmd2.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = cmbCategory1.SelectedIndex;
                }
                else
                {
                    cmd2.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = (cmbCategory1.SelectedIndex + 1);
                }

                cmd2.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = cmbCategory2.SelectedIndex;
                cmd2.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = cmbCategory3.SelectedIndex + 1;
                cmd2.Parameters.Add("@ItmGroup4", SqlDbType.NVarChar).Value = 0;
                cmd2.Parameters.Add("@ItmGroup5", SqlDbType.NVarChar).Value = 0;

                ItmReservedQty = 0;

                cmd2.Parameters.Add("@ItmReservedQty", SqlDbType.Int).Value = ItmReservedQty;
                cmd2.Parameters.Add("@ItmStockMin", SqlDbType.Int).Value = ItmStockMin;
                cmd2.Parameters.Add("@ItmOnHand", SqlDbType.Int).Value = ItmOnHand;

                ItmPrc1 = ItmRetailPrice;
                ItmPrc2 = ItmPrc3 = ItmPrc4 = ItmPrc5 = ItmPrc6 = ItmPrc7 = ItmPrc8 = ItmPrc9 = ItmPrc10 = ItmStylistPrice = 0;

                cmd2.Parameters.Add("@ItmRetailPrice", SqlDbType.Money).Value = ItmRetailPrice;
                cmd2.Parameters.Add("@ItmCostPrice", SqlDbType.Money).Value = ItmCostPrice;
                cmd2.Parameters.Add("@ItmPrc1", SqlDbType.Money).Value = ItmPrc1;
                cmd2.Parameters.Add("@ItmPrc2", SqlDbType.Money).Value = ItmPrc2;
                cmd2.Parameters.Add("@ItmPrc3", SqlDbType.Money).Value = ItmPrc3;
                cmd2.Parameters.Add("@ItmPrc4", SqlDbType.Money).Value = ItmPrc4;
                cmd2.Parameters.Add("@ItmPrc5", SqlDbType.Money).Value = ItmPrc5;
                cmd2.Parameters.Add("@ItmPrc6", SqlDbType.Money).Value = ItmPrc6;
                cmd2.Parameters.Add("@ItmPrc7", SqlDbType.Money).Value = ItmPrc7;
                cmd2.Parameters.Add("@ItmPrc8", SqlDbType.Money).Value = ItmPrc8;
                cmd2.Parameters.Add("@ItmPrc9", SqlDbType.Money).Value = ItmPrc9;
                cmd2.Parameters.Add("@ItmPrc10", SqlDbType.Money).Value = ItmPrc10;
                cmd2.Parameters.Add("@ItmStylistPrice", SqlDbType.Money).Value = ItmStylistPrice;

                cmd2.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = txtUpc.Text.ToUpper();
                cmd2.Parameters.Add("@ItmBin", SqlDbType.NVarChar).Value = txtBin.Text.ToUpper();
                cmd2.Parameters.Add("@ItmVendor", SqlDbType.NVarChar).Value = cmbVendor.Text.Trim().ToString().ToUpper();
                cmd2.Parameters.Add("@ItmImage", SqlDbType.NVarChar).Value = "-";

                //DateTime currentTime = DateTime.Now;
                //ItmRegisterDate = string.Format("{0:d}", currentTime);
                ItmRegisterDate = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                cmd2.Parameters.Add("@ItmRegisterDate", SqlDbType.NVarChar).Value = ItmRegisterDate;


                if (parentForm.StoreCode == "B4UHQ")
                {
                    ItmTax = 0.06;
                }
                else if (parentForm.StoreCode == "B4UWH")
                {
                    ItmTax = 0.06;
                }
                else if (parentForm.StoreCode == "TH")
                {
                    ItmTax = 0.06;
                }
                else if (parentForm.StoreCode == "OH")
                {
                    ItmTax = 0.06;
                }
                else if (parentForm.StoreCode == "UM")
                {
                    ItmTax = 0.06;
                }
                else if (parentForm.StoreCode == "CH")
                {
                    ItmTax = 0.06;
                }
                else if (parentForm.StoreCode == "WM")
                {
                    ItmTax = 0.06;
                }
                else if (parentForm.StoreCode == "CV")
                {
                    ItmTax = 0.06;
                }
                else if (parentForm.StoreCode == "PW")
                {
                    ItmTax = 0.05;
                }
                else if (parentForm.StoreCode == "WB")
                {
                    ItmTax = 0.05;
                }
                else if (parentForm.StoreCode == "WD")
                {
                    ItmTax = 0.06;
                }
                else if (parentForm.StoreCode == "GB")
                {
                    ItmTax = 0.06;
                }

                cmd2.Parameters.Add("@ItmTax", SqlDbType.Money).Value = ItmTax;

                cmd2.Parameters.Add("@ItmTaxable", SqlDbType.Bit).Value = true;
                cmd2.Parameters.Add("@ItmMixMatch", SqlDbType.Bit).Value = false;
                cmd2.Parameters.Add("@ItmMixMatchVal", SqlDbType.Int).Value = 0;
                cmd2.Parameters.Add("@ItmMixMatchPrc", SqlDbType.Money).Value = 0;
                cmd2.Parameters.Add("@ItmActive", SqlDbType.Bit).Value = true;

                newConn.Open();
                cmd2.ExecuteNonQuery();
                newConn.Close();

                MessageBox.Show("SUCCESSFULLY REGISTERED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (cmbCategory1.SelectedIndex == 2)
                {
                    cmbColor.Text = "";
                    Resetting();
                }
                else
                {
                    Resetting();
                }
            }
            else
            {
                cmd.CommandText = "Register_New_Item";
                cmd.Connection = parentForm.conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@ItmStoreCode", SqlDbType.NVarChar).Value = parentForm.StoreCode.ToUpper();
                cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = cmbBrand.Text.Trim().ToString().ToUpper();
                cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = txtName.Text.Trim().ToString().ToUpper();
                cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = cmbSize.Text.Trim().ToString().ToUpper();
                cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = cmbColor.Text.Trim().ToString().ToUpper();
                cmd.Parameters.Add("@ItmModelNum", SqlDbType.NVarChar).Value = txtModelNum.Text.Trim().ToString().ToUpper();

                if (cmbCategory1.SelectedIndex < 6)
                {
                    cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = cmbCategory1.SelectedIndex;
                }
                else
                {
                    cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = (cmbCategory1.SelectedIndex + 1);
                }

                cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = cmbCategory2.SelectedIndex;
                cmd.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = cmbCategory3.SelectedIndex + 1;
                cmd.Parameters.Add("@ItmGroup4", SqlDbType.NVarChar).Value = 0;
                cmd.Parameters.Add("@ItmGroup5", SqlDbType.NVarChar).Value = 0;

                ItmReservedQty = 0;

                cmd.Parameters.Add("@ItmReservedQty", SqlDbType.Int).Value = ItmReservedQty;
                cmd.Parameters.Add("@ItmStockMin", SqlDbType.Int).Value = ItmStockMin;
                cmd.Parameters.Add("@ItmOnHand", SqlDbType.Int).Value = ItmOnHand;

                ItmPrc1 = ItmRetailPrice;
                ItmPrc2 = ItmPrc3 = ItmPrc4 = ItmPrc5 = ItmPrc6 = ItmPrc7 = ItmPrc8 = ItmPrc9 = ItmPrc10 = ItmStylistPrice = 0;

                cmd.Parameters.Add("@ItmRetailPrice", SqlDbType.Money).Value = ItmRetailPrice;
                cmd.Parameters.Add("@ItmCostPrice", SqlDbType.Money).Value = ItmCostPrice;
                cmd.Parameters.Add("@ItmPrc1", SqlDbType.Money).Value = ItmPrc1;
                cmd.Parameters.Add("@ItmPrc2", SqlDbType.Money).Value = ItmPrc2;
                cmd.Parameters.Add("@ItmPrc3", SqlDbType.Money).Value = ItmPrc3;
                cmd.Parameters.Add("@ItmPrc4", SqlDbType.Money).Value = ItmPrc4;
                cmd.Parameters.Add("@ItmPrc5", SqlDbType.Money).Value = ItmPrc5;
                cmd.Parameters.Add("@ItmPrc6", SqlDbType.Money).Value = ItmPrc6;
                cmd.Parameters.Add("@ItmPrc7", SqlDbType.Money).Value = ItmPrc7;
                cmd.Parameters.Add("@ItmPrc8", SqlDbType.Money).Value = ItmPrc8;
                cmd.Parameters.Add("@ItmPrc9", SqlDbType.Money).Value = ItmPrc9;
                cmd.Parameters.Add("@ItmPrc10", SqlDbType.Money).Value = ItmPrc10;
                cmd.Parameters.Add("@ItmStylistPrice", SqlDbType.Money).Value = ItmStylistPrice;

                cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = txtUpc.Text.ToUpper();
                cmd.Parameters.Add("@ItmBin", SqlDbType.NVarChar).Value = txtBin.Text.ToUpper();
                cmd.Parameters.Add("@ItmVendor", SqlDbType.NVarChar).Value = cmbVendor.Text.Trim().ToString().ToUpper();
                cmd.Parameters.Add("@ItmImage", SqlDbType.NVarChar).Value = "-";

                //DateTime currentTime = DateTime.Now;
                //ItmRegisterDate = string.Format("{0:d}", currentTime);
                ItmRegisterDate = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                cmd.Parameters.Add("@ItmRegisterDate", SqlDbType.NVarChar).Value = ItmRegisterDate;


                if (parentForm.StoreCode == "B4UHQ")
                {
                    ItmTax = 0.06;
                }
                else if (parentForm.StoreCode == "B4UWH")
                {
                    ItmTax = 0.06;
                }
                else if (parentForm.StoreCode == "TH")
                {
                    ItmTax = 0.06;
                }
                else if (parentForm.StoreCode == "OH")
                {
                    ItmTax = 0.06;
                }
                else if (parentForm.StoreCode == "UM")
                {
                    ItmTax = 0.06;
                }
                else if (parentForm.StoreCode == "CH")
                {
                    ItmTax = 0.06;
                }
                else if (parentForm.StoreCode == "WM")
                {
                    ItmTax = 0.06;
                }
                else if (parentForm.StoreCode == "CV")
                {
                    ItmTax = 0.06;
                }
                else if (parentForm.StoreCode == "PW")
                {
                    ItmTax = 0.05;
                }
                else if (parentForm.StoreCode == "WB")
                {
                    ItmTax = 0.05;
                }
                else if (parentForm.StoreCode == "WD")
                {
                    ItmTax = 0.06;
                }
                else if (parentForm.StoreCode == "GB")
                {
                    ItmTax = 0.06;
                }

                cmd.Parameters.Add("@ItmTax", SqlDbType.Money).Value = ItmTax;

                cmd.Parameters.Add("@ItmTaxable", SqlDbType.Bit).Value = true;
                cmd.Parameters.Add("@ItmMixMatch", SqlDbType.Bit).Value = false;
                cmd.Parameters.Add("@ItmMixMatchVal", SqlDbType.Int).Value = 0;
                cmd.Parameters.Add("@ItmMixMatchPrc", SqlDbType.Money).Value = 0;
                cmd.Parameters.Add("@ItmActive", SqlDbType.Bit).Value = true;

                parentForm.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm.conn.Close();

                MessageBox.Show("SUCCESSFULLY REGISTERED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (cmbCategory1.SelectedIndex == 2)
                {
                    cmbColor.Text = "";
                    Resetting();
                }
                else
                {
                    Resetting();
                }
            }*/
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                txtUpc.SelectAll();
                txtUpc.Focus();
            }
        }

        private void txtRetailPrice_Click(object sender, EventArgs e)
        {
            txtRetailPrice.SelectAll();
            txtRetailPrice.Focus();
        }

        private void txtCostPrice_Click(object sender, EventArgs e)
        {
            txtCostPrice.SelectAll();
            txtCostPrice.Focus();
        }

        private void txtMinStock_Click(object sender, EventArgs e)
        {
            txtMinStock.SelectAll();
            txtMinStock.Focus();
        }

        private void txtOnHand_Click(object sender, EventArgs e)
        {
            txtOnHand.SelectAll();
            txtOnHand.Focus();
        }

        private void txtUpc_Click(object sender, EventArgs e)
        {
            txtUpc.SelectAll();
            txtUpc.Focus();
        }

        void Resetting()
        {
            /*cmbBrand.DataSource = null;
            cmbBrand.Text = "";
            txtName.Clear();
            cmbSize.DataSource = null;
            cmbSize.Text = "";
            cmbColor.DataSource = null;
            cmbColor.Text = "";
            txtModelNum.Clear();
            txtBin.Clear();
            cmbVendor.DataSource = null;
            cmbVendor.Text = "";
            txtRetailPrice.Text = "0.00";
            txtCostPrice.Text = "0.00";
            txtMinStock.Text = "1";
            txtOnHand.Text = "0";*/
            
            txtUpc.Clear();
            txtUpc.Enabled = true;
            txtUpc.Select();
            txtUpc.Focus();
            btnUpcCheck.Enabled = true;
            btnRegister.Enabled = false;
        }

        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            cmbBrand.DataSource = null;

            AddBrand addBrandForm = new AddBrand();
            addBrandForm.parentForm1 = this.parentForm;
            addBrandForm.parentForm2 = this;
            addBrandForm.ShowDialog();
        }

        private void btnAddSize_Click(object sender, EventArgs e)
        {
            cmbSize.DataSource = null;

            AddSize addSizeForm = new AddSize();
            addSizeForm.parentForm1 = this.parentForm;
            addSizeForm.parentForm2 = this;
            addSizeForm.ShowDialog();
        }

        private void btnAddColor_Click(object sender, EventArgs e)
        {
            cmbColor.DataSource = null;

            AddColor addColorForm = new AddColor();
            addColorForm.parentForm1 = this.parentForm;
            addColorForm.parentForm2 = this;
            addColorForm.ShowDialog();
        }

        private void btnAddVendor_Click(object sender, EventArgs e)
        {
            cmbVendor.DataSource = null;

            AddVendor addVendorForm = new AddVendor();
            addVendorForm.parentForm1 = this.parentForm;
            addVendorForm.parentForm2 = this;
            addVendorForm.ShowDialog();
        }

        private void txtStartDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void txtEndDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar2.Visible = true;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtStartDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar1.SelectionStart));
            monthCalendar1.Visible = false;
        }

        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtEndDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar2.SelectionStart));
            monthCalendar2.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            sDate = txtStartDate.Text.Trim();
            eDate = txtEndDate.Text.Trim();

            LabelPrint labelPrintForm = new LabelPrint(2);
            labelPrintForm.parentForm1 = this.parentForm;
            labelPrintForm.parentForm3 = this;
            labelPrintForm.Show();
        }

        private void cmbVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(cmbVendor, cmbVendor.SelectedValue.ToString());
        }

        private void cmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolTip2.SetToolTip(cmbBrand, cmbBrand.SelectedValue.ToString());
        }

        /*private static bool DBConnectionStatus(string CS)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(CS))
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
        }*/
    }
}