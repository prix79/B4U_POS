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
    public partial class UpdateInvoice : Form
    {
        public LogInManagements parentForm1;
        public InvoiceSummaryMain parentForm2;
        public SqlCommand cmd;
        public DataSet ds;
        public SqlDataAdapter adapt;

        int index1;

        double amount;
        string invoiceType, storeCode, invoiceNumber, POID, vendor, employeeID, invoiceDate, updateDate, note;
        DateTime d;
        Int64 seqNo;

        public UpdateInvoice()
        {
            InitializeComponent();
        }

        private void UpdateInvoice_Load(object sender, EventArgs e)
        {
            this.Text = "UPDATE INVOICE - " + parentForm1.employeeID + " LOGGED IN " + parentForm1.storeName;

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

            btnVendor_Click(null, null);

            seqNo = Convert.ToInt64(parentForm2.dataGridView1.SelectedCells[0].Value);

            if (Convert.ToString(parentForm2.dataGridView1.SelectedCells[1].Value) == "P")
            {
                cmbInvoiceType.Text = "PURCHASE";
            }
            else if (Convert.ToString(parentForm2.dataGridView1.SelectedCells[1].Value) == "C")
            {
                cmbInvoiceType.Text = "CREDIT";
            }

            txtInvoiceNumber.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[3].Value).ToUpper();
            txtPOID.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[4].Value).ToUpper();
            cmbVendor.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[5].Value).ToUpper();

            if (Convert.ToInt16(parentForm2.dataGridView1.SelectedCells[6].Value) < 6)
            {
                cmbCategory1.SelectedIndex = Convert.ToInt16(parentForm2.dataGridView1.SelectedCells[6].Value);
            }
            else
            {
                cmbCategory1.SelectedIndex = Convert.ToInt16(parentForm2.dataGridView1.SelectedCells[6].Value) - 1;
            }

            txtAmount.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[7].Value).ToUpper();
            txtInvoiceDate.Text = string.Format("{0:MM/dd/yyyy}", parentForm2.dataGridView1.SelectedCells[9].Value);
            richTxtNote.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[12].Value).ToUpper();

            btnUpdate.Select();
            btnUpdate.Focus();
        }

        private void btnVendor_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Get_VendorName", parentForm1.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            ds = new DataSet();
            adapt = new SqlDataAdapter(cmd);

            parentForm1.conn.Open();
            ds.Clear();
            adapt.Fill(ds);
            parentForm1.conn.Close();

            cmbVendor.DataSource = ds.Tables[0].DefaultView;
            cmbVendor.ValueMember = "VendorName";
            cmbVendor.DisplayMember = "VendorName";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
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

            if (txtPOID.Text == "")
            {
                MessageBox.Show("INPUT P/O ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPOID.SelectAll();
                txtPOID.Focus();

                return;
            }

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

            if (ValidateDate(txtInvoiceDate.Text) == true)
            {
                invoiceDate = txtInvoiceDate.Text;
            }
            else
            {
                MessageBox.Show("INPUT VALID DATE (MM/DD/YYYY)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInvoiceDate.SelectAll();
                txtInvoiceDate.Focus();
                return;
            }

            invoiceType = cmbInvoiceType.Text.Trim().ToUpper();
            storeCode = parentForm1.StoreCode.ToUpper();
            invoiceNumber = txtInvoiceNumber.Text.Trim().ToUpper();
            POID = txtPOID.Text.Trim().ToUpper();
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
            employeeID = parentForm1.employeeID.ToUpper();
            //invoiceDate = txtInvoiceDate.Text.Trim().ToUpper();
            updateDate = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

            try
            {
                cmd = new SqlCommand("Update_Invoice_Summary", parentForm1.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@seqNo", SqlDbType.BigInt).Value = seqNo;
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
                cmd.Parameters.Add("@IvSmEmployeeID", SqlDbType.NVarChar).Value = employeeID;
                cmd.Parameters.Add("@IvSmInvoiceDate", SqlDbType.NVarChar).Value = invoiceDate;
                cmd.Parameters.Add("@IvSmUpdateDate", SqlDbType.NVarChar).Value = updateDate;
                cmd.Parameters.Add("@IvSmNote", SqlDbType.NVarChar).Value = note;

                parentForm1.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm1.conn.Close();
            }
            catch
            {
                parentForm1.conn.Close();
                MessageBox.Show("DB UPDATE FAILED OR LOST CONNECTION", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("SUCCESSFULLY UPDATED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
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