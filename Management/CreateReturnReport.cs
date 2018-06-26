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
    public partial class CreateReturnReport : Form
    {
        public LogInManagements parentForm1;
        public POandReceiving parentform2;

        SqlCommand cmd;
        DataSet ds;
        SqlDataAdapter adapt;

        public Int64 rrID;
        public string rrEmployeeID = string.Empty;
        public string rrStatus = string.Empty;
        public string rrVendor = string.Empty;
        public string rrCreateDate = string.Empty;

        Int64 vendorID;
        string vendorCode, vendorName;
        string firstName;
        string lastName;
        int category1;
        string salesmanName;
        string salesmanPhoneNumber;
        string packingDate;
        string reasonForReturn;
        string firstContact;

        public CreateReturnReport()
        {
            InitializeComponent();
        }

        private void CreateReturnReport_Load(object sender, EventArgs e)
        {
            this.Text = "CREATE NEW RETURN REPORT";
            lblStoreCode.Text = parentForm1.StoreCode.ToUpper();
            lblEmployeeID.Text = parentForm1.employeeID.ToUpper();
            cmbReason.SelectedIndex = 0;
            richTxtPackingDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

            cmd = new SqlCommand("Get_Category_Group1", parentForm1.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            ds = new DataSet();
            adapt = new SqlDataAdapter(cmd);

            parentForm1.conn.Open();
            ds.Clear();
            adapt.Fill(ds);
            parentForm1.conn.Close();

            cmbCategory1.DataSource = ds.Tables[0].DefaultView;
            cmbCategory1.ValueMember = "ItmGp_Desc";
            cmbCategory1.DisplayMember = "ItmGp_Desc";
        }

        private void btnLoadVendor_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Get_VendorName", parentForm1.conn);
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
        }

        private void btnGenerateReturnReport_Click(object sender, EventArgs e)
        {
            if (cmbVendor.Text.Trim() == "")
            {
                MessageBox.Show("SELECT THE VENDOR.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbVendor.SelectAll();
                cmbVendor.Focus();
                return;
            }

            if (richTxtFirstName.Text.Trim() == "")
            {
                MessageBox.Show("INPUT FIRST NAME.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                richTxtFirstName.SelectAll();
                richTxtFirstName.Focus();
                return;
            }

            if (richTxtLastName.Text.Trim() == "")
            {
                MessageBox.Show("INPUT LAST NAME.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                richTxtLastName.SelectAll();
                richTxtLastName.Focus();
                return;
            }

            if (cmbCategory1.SelectedIndex == 0)
            {
                MessageBox.Show("SELECT THE CATEGORY1 (SECTION).", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCategory1.SelectAll();
                cmbCategory1.Focus();
                return;
            }

            if (richTxtSalesmanName.Text.Trim() == "")
            {
                MessageBox.Show("INPUT SALESMAN NAME.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                richTxtSalesmanName.SelectAll();
                richTxtSalesmanName.Focus();
                return;
            }

            if (richTxtPackingDate.Text.Trim().Length == 10)
            {
                if (ValidateDate(richTxtPackingDate.Text.Trim()) == true)
                {
                    packingDate = richTxtPackingDate.Text.Trim();
                }
                else
                {
                    MessageBox.Show("INPUT VALID DATE (MM/DD/YYYY)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    richTxtPackingDate.SelectAll();
                    richTxtPackingDate.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("INPUT VALID DATE (MM/DD/YYYY)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                richTxtPackingDate.SelectAll();
                richTxtPackingDate.Focus();
                return;
            }

            if (cmbReason.SelectedIndex == 0)
            {
                MessageBox.Show("SELECT THE REASON FOR RETURN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbReason.SelectAll();
                cmbReason.Focus();
                return;
            }
            else if (cmbReason.Text.Trim() == "TYPE THE REASON")
            {
                MessageBox.Show("TYPE THE REASON FOR RETURN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbReason.SelectAll();
                cmbReason.Focus();
                return;
            }

            if (richTxtFirstContact.Text.Trim() == "")
            {
                MessageBox.Show("INPUT FIRST CONTACT AND RESULT.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                richTxtFirstContact.SelectAll();
                richTxtFirstContact.Focus();
                return;
            }

            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
            {
                if (parentform2.CheckOpened("ItemSoldList") == true | parentform2.CheckOpened("POMain") == true)
                {
                    MessageBox.Show("PLEASE CLOSE EXISING P/O WINDOWS(S)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                vendorName = cmbVendor.Text.Trim();
                firstName = richTxtFirstName.Text.Trim().ToUpper();
                lastName = richTxtLastName.Text.Trim().ToUpper();

                if (cmbCategory1.SelectedIndex < 6)
                {
                    category1 = cmbCategory1.SelectedIndex;
                }
                else
                {
                    category1 = (cmbCategory1.SelectedIndex + 1);
                }

                salesmanName = richTxtSalesmanName.Text.Trim().ToUpper();
                salesmanPhoneNumber = richTxtSalesmanPhoneNumber.Text.Trim().ToUpper();
                reasonForReturn = cmbReason.Text.Trim();
                firstContact = richTxtFirstContact.Text.Trim();

                cmd = new SqlCommand("Get_Vendor_ID_Code", parentForm1.conn);
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

                    cmd.CommandText = "Create_New_Return_Report_Header";
                    cmd.Connection = parentForm1.conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@rrStoreCode", SqlDbType.NVarChar).Value = lblStoreCode.Text;
                    cmd.Parameters.Add("@rrVendorID", SqlDbType.BigInt).Value = vendorID;
                    cmd.Parameters.Add("@rrVendorCode", SqlDbType.NVarChar).Value = vendorCode;
                    cmd.Parameters.Add("@rrVendorName", SqlDbType.NVarChar).Value = vendorName;
                    cmd.Parameters.Add("@rrFirstName", SqlDbType.NVarChar).Value = firstName;
                    cmd.Parameters.Add("@rrLastName", SqlDbType.NVarChar).Value = lastName;
                    cmd.Parameters.Add("@rrEmployeeID", SqlDbType.NVarChar).Value = lblEmployeeID.Text;
                    cmd.Parameters.Add("@rrGroup1", SqlDbType.NVarChar).Value = cmbCategory1.SelectedIndex.ToString();
                    cmd.Parameters.Add("@rrSalesmanName", SqlDbType.NVarChar).Value = salesmanName;
                    cmd.Parameters.Add("@rrSalesmanPhoneNumber", SqlDbType.NVarChar).Value = salesmanPhoneNumber;
                    cmd.Parameters.Add("@rrCreateDate", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@rrPackingDate", SqlDbType.NVarChar).Value = packingDate;
                    cmd.Parameters.Add("@rrReason", SqlDbType.NVarChar).Value = reasonForReturn;
                    cmd.Parameters.Add("@rrFirstContact", SqlDbType.NVarChar).Value = firstContact;
                    SqlParameter ReturnReportID_Param = cmd.Parameters.Add("@rrID", SqlDbType.BigInt);
                    ReturnReportID_Param.Direction = ParameterDirection.Output;

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    if (cmd.Parameters["@rrID"].Value == DBNull.Value)
                    {
                        MessageBox.Show("DB ERROR (Getting Return Report ID)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        rrID = Convert.ToInt64(cmd.Parameters["@rrID"].Value);
                        rrEmployeeID = lblEmployeeID.Text;
                        rrVendor = vendorName;
                        rrStatus = "PENDING";
                        rrCreateDate = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                        //MessageBox.Show("Return Report ID is " + cmd.Parameters["@rrID"].Value.ToString() + ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                        ItemSoldListForReturn itemSoldListForReturnForm = new ItemSoldListForReturn(rrID, rrEmployeeID, firstName + " " + lastName, rrVendor, rrStatus, rrCreateDate, packingDate, "N/A", "N/A", 0);
                        itemSoldListForReturnForm.parentForm = this.parentForm1;
                        itemSoldListForReturnForm.parentForm2 = this.parentform2;
                        itemSoldListForReturnForm.Show();
                    }
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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTxtPackingDate_DoubleClick(object sender, EventArgs e)
        {
            richTxtPackingDate.SelectAll();
            monthCalendar1.Visible = true;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            richTxtPackingDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar1.SelectionStart));
            monthCalendar1.Visible = false;
        }

        private bool ValidateDate(string date)
        {
            bool valid = false;
            //DateTime testDate = DateTime.MinValue;
            //DateTime minDateTime = DateTime.MaxValue;
            //DateTime maxDateTime = DateTime.MinValue;

            DateTime testDate;
            DateTime minDateTime;
            DateTime maxDateTime;

            minDateTime = new DateTime(1900, 1, 1, 0, 0, 0);
            maxDateTime = new DateTime(2100, 12, 31, 23, 59, 59, 997);

            if (DateTime.TryParse(date, out testDate))
            {
                if (testDate >= minDateTime && testDate <= maxDateTime)
                {
                    valid = true;
                }
                else
                {
                    valid = false;
                }
            }

            return valid;
        }

        private void cmbReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbReason.SelectedIndex == 6)
            {
                cmbReason.DropDownStyle = ComboBoxStyle.DropDown;
                cmbReason.Text = "TYPE THE REASON";
                cmbReason.SelectAll();
                cmbReason.Focus();
            }
            else
            {
                cmbReason.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
    }
}