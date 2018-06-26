using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;

namespace Management
{
    public partial class InputInvoice : Form
    {
        public LogInManagements parentForm;
        public InvoiceSummaryMain parentForm2;
        public SqlCommand cmd;
        public DataSet ds;
        public SqlDataAdapter adapt;

        int index1;

        double amount;
        string invoiceType, storeCode, invoiceNumber, POID, vendor, employeeID, invoiceDate, inputDate, note;
        DateTime d;

        public InputInvoice()
        {
            InitializeComponent();
        }

        private void InputInvoice_Load(object sender, EventArgs e)
        {
            this.Text = "INPUT INVOICE - " + parentForm.employeeID + " LOGGED IN " + parentForm.storeName;

            cmd = new SqlCommand("Get_Category_Group1", parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            ds = new DataSet();
            adapt = new SqlDataAdapter(cmd);

            parentForm.conn.Open();
            ds.Clear();
            adapt.Fill(ds);
            parentForm.conn.Close();

            cmbCategory1.DataSource = ds.Tables[0].DefaultView;
            cmbCategory1.ValueMember = "ItmGp_Desc";
            cmbCategory1.DisplayMember = "ItmGp_Desc";

            txtInvoiceDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

            cmbInvoiceType.Select();
            cmbInvoiceType.Focus();
        }

        private void btnVendor_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Get_VendorName", parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            ds = new DataSet();
            adapt = new SqlDataAdapter(cmd);

            parentForm.conn.Open();
            ds.Clear();
            adapt.Fill(ds);
            parentForm.conn.Close();

            cmbVendor.DataSource = ds.Tables[0].DefaultView;
            cmbVendor.ValueMember = "VendorName";
            cmbVendor.DisplayMember = "VendorName";
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            if (cmbInvoiceType.Text == "")
            {
                MessageBox.Show("SELECT INVOICE TYPE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbInvoiceType.SelectAll();
                cmbInvoiceType.Focus();

                return;
            }

            if (txtInvoiceNumber.Text == "")
            {
                MessageBox.Show("INPUT INVOICE NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInvoiceNumber.SelectAll();
                txtInvoiceNumber.Focus();

                return;
            }

            /*if (txtPOID.Text == "")
            {
                MessageBox.Show("INPUT P/O ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPOID.SelectAll();
                txtPOID.Focus();

                return;
            }*/

            if (cmbVendor.Text == "")
            {
                MessageBox.Show("SELECT VENDOR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbVendor.SelectAll();
                cmbVendor.Focus();

                return;
            }

            if (cmbCategory1.SelectedIndex < 1 | cmbCategory1.Text == "")
            {
                MessageBox.Show("SELECT CATEGORY 1", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (double.TryParse(txtAmount.Text, out amount))
            {
            }
            else
            {
                MessageBox.Show("INPUT VALID AMOUNT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAmount.SelectAll();
                txtAmount.Focus();

                return;
            }

            /*if (DateTime.TryParse(txtInvoiceDate.Text, out d))
            {
            }
            else
            {
                MessageBox.Show("INPUT VALID DATE (MM/DD/YYYY)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInvoiceDate.SelectAll();
                txtInvoiceDate.Focus();
            }*/

            if (txtInvoiceDate.Text.Trim().Length != 10)
            {
                MessageBox.Show("INPUT VALID DATE (MM/DD/YYYY)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInvoiceDate.SelectAll();
                txtInvoiceDate.Focus();
                return;
            }

            if (ValidateDate(txtInvoiceDate.Text.Trim()) == true)
            {
                invoiceDate = txtInvoiceDate.Text.Trim();
            }
            else
            {
                MessageBox.Show("INPUT VALID DATE (MM/DD/YYYY)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInvoiceDate.SelectAll();
                txtInvoiceDate.Focus();
                return;
            }

            invoiceType = cmbInvoiceType.Text.Trim().ToUpper();
            storeCode = parentForm.StoreCode.ToUpper();
            invoiceNumber = txtInvoiceNumber.Text.Trim().ToUpper();

            if (txtPOID.Text.Trim().ToString() == "")
            {
                POID = "N/A";
            }
            else
            {
                POID = txtPOID.Text.Trim().ToUpper();
            }

            vendor = cmbVendor.Text.Trim().ToUpper();
            note = richTxtNote.Text.Trim().ToUpper().ToString();

            if (cmbCategory1.SelectedIndex < 6)
            {
                index1 = cmbCategory1.SelectedIndex;
            }
            else
            {
                index1 = (cmbCategory1.SelectedIndex + 1);
            }

            amount = Convert.ToDouble(txtAmount.Text.Trim());
            employeeID = parentForm.employeeID.ToUpper();
            //invoiceDate = string.Format("{0:MM/dd/yyyy}", d);
            inputDate = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

            try
            {
                cmd = new SqlCommand("Create_Invoice_Summary", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                if (invoiceType == "PURCHASE")
                {
                    cmd.Parameters.Add("@IvSmType", SqlDbType.NVarChar).Value = "P";
                }
                else if (invoiceType == "CREDIT")
                {
                    cmd.Parameters.Add("@IvSmType", SqlDbType.NVarChar).Value = "C";
                }
                cmd.Parameters.Add("@IvSmStoreCode", SqlDbType.NVarChar).Value = storeCode;
                cmd.Parameters.Add("@IvSmNumber", SqlDbType.NVarChar).Value = invoiceNumber;
                cmd.Parameters.Add("@IvSmPOID", SqlDbType.NVarChar).Value = POID;
                cmd.Parameters.Add("@IvSmVendor", SqlDbType.NVarChar).Value = vendor;
                cmd.Parameters.Add("@IvSmGp1", SqlDbType.NVarChar).Value = index1.ToString();
                cmd.Parameters.Add("@IvSmAmount", SqlDbType.Money).Value = amount;
                cmd.Parameters.Add("@IvSmEmpolyeeID", SqlDbType.NVarChar).Value = employeeID;
                cmd.Parameters.Add("@IvSmInvoiceDate", SqlDbType.NVarChar).Value = invoiceDate;
                cmd.Parameters.Add("@IvSmInputDate", SqlDbType.NVarChar).Value = inputDate;
                cmd.Parameters.Add("@IvSmNote", SqlDbType.NVarChar).Value = note;

                parentForm.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm.conn.Close();
            }
            catch
            {
                MessageBox.Show("DB UPDATE FAILED OR LOST CONNECTION", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                parentForm.conn.Close();
                return;
            }

            cmbInvoiceType.Text = "";
            txtInvoiceNumber.Clear();
            txtPOID.Clear();
            cmbCategory1.SelectedIndex = 0;
            txtAmount.Clear();
            richTxtNote.Clear();

            MessageBox.Show("SUCCESSFULLY INPUTTED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (parentForm2.dataGridView1.RowCount > 0)
                parentForm2.Load_InvoiceList(parentForm2.tempF_Opt);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtInvoiceDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtInvoiceDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar1.SelectionStart));
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
    }
}