using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using Office_12 = Microsoft.Office.Core;
using Excel_12 = Microsoft.Office.Interop.Excel;

namespace Management
{
    public partial class CustomerMain : Form
    {
        public LogInManagements parentForm;

        public SqlCommand cmd = new SqlCommand();
        public DataTable dt = new DataTable();
        public Font drvFont = new Font("Arial", 10, FontStyle.Bold);

        Int64 memberCode;

        DateTime d1, d2, d3, d4;
        string dob, startDate, expDate, lastVisitDate;

        public CustomerMain()
        {
            InitializeComponent();
        }

        public void CustomerMain_Load(object sender, EventArgs e)
        {
            /*if (parentForm.userLevel < 4)
            {
                btnUpdateCustomer.Enabled = false;
                btnExcel.Enabled = false;
            }*/

            if (parentForm.userLevel < parentForm.btnCustomerUpdate)
                btnUpdateCustomer.Enabled = false;

            if (parentForm.userLevel < parentForm.btnCustomerDelete)
                btnDeleteCustomer.Enabled = false;

            if (parentForm.userLevel < parentForm.btnCustomerExcel)
                btnExcel.Enabled = false;

            if (parentForm.userLevel == parentForm.SystemAdministratorLV & parentForm.employeeID.ToUpper() == parentForm.SystemMasterUserName.ToUpper())
            {
                dataGridView1.ReadOnly = false;
                btnUpdateByAdmin.Visible = true;
            }

            this.Text = "CUSTOMER MAIN - " + parentForm.employeeID + " LOGGED IN " + parentForm.storeName;

            /*dt.Columns.Add("STORE CODE", typeof(string));
            dt.Columns.Add("FIRST NAME", typeof(string));
            dt.Columns.Add("LAST NAME", typeof(string));
            dt.Columns.Add("DATE OF BIRTH", typeof(string));
            dt.Columns.Add("ADDRESS", typeof(string));
            dt.Columns.Add("CITY", typeof(string));
            dt.Columns.Add("STATE", typeof(string));
            dt.Columns.Add("ZIP CODE", typeof(string));
            dt.Columns.Add("HOME PHONE", typeof(string));
            dt.Columns.Add("CELL PHONE", typeof(string));
            dt.Columns.Add("EMAIL", typeof(string));
            dt.Columns.Add("MEMBER CODE", typeof(Int64));
            dt.Columns.Add("LICENSE NUMBER", typeof(string));
            dt.Columns.Add("DISCOUNT OPTION", typeof(double));
            dt.Columns.Add("INITIAL MP", typeof(double));
            dt.Columns.Add("MEMBER POINTS", typeof(double));
            dt.Columns.Add("START DATE", typeof(DateTime));
            dt.Columns.Add("EXPIRATION DATE", typeof(DateTime));
            dt.Columns.Add("LAST VISIT DATE", typeof(DateTime));
            dt.Columns.Add("TRNS(P)", typeof(int));
            dt.Columns.Add("TRNS(R)", typeof(int));
            dt.Columns.Add("TRNS(T)", typeof(int));
            dt.Columns.Add("TOTAL TRANSACTION AMOUNT", typeof(double));
            dt.Columns.Add("SCHOOL GRADUATED", typeof(string));
            dt.Columns.Add("MEMO", typeof(string));
            dt.Columns.Add("ACTIVE", typeof(bool));*/

            /*cmd.CommandText = "Show_Customers";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = parentForm.conn;
            cmd.Parameters.Clear();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            dt.Clear();
            adapt.Fill(dt);
            parentForm.conn.Close();

            BindingData();*/

            txtSearchKeyword.Select();
            txtSearchKeyword.Focus();

            lblNumberOfMembers.Text = dataGridView1.RowCount.ToString();
        }

        public void btnSearch_Click(object sender, EventArgs e)
        {
            if (rdoBtnFirstName.Checked == true)
            {
                cmd.CommandText = "Show_Customer_With_Keyword";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = parentForm.conn;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Index", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = txtSearchKeyword.Text.ToUpper() + "%";
                SqlDataAdapter adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                parentForm.conn.Open();
                dt.Clear();
                adapt.Fill(dt);
                parentForm.conn.Close();

                BindingData();
            }
            else if (rdoBtnLastName.Checked == true)
            {
                cmd.CommandText = "Show_Customer_With_Keyword";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = parentForm.conn;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Index", SqlDbType.Int).Value = 2;
                cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = txtSearchKeyword.Text.ToUpper() + "%";
                SqlDataAdapter adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                parentForm.conn.Open();
                dt.Clear();
                adapt.Fill(dt);
                parentForm.conn.Close();

                BindingData();
            }
            else if (rdoBtnHomePhone.Checked == true)
            {
                cmd.CommandText = "Show_Customer_With_Keyword";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = parentForm.conn;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Index", SqlDbType.Int).Value = 3;
                cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = txtSearchKeyword.Text.ToUpper() + "%";
                SqlDataAdapter adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                parentForm.conn.Open();
                dt.Clear();
                adapt.Fill(dt);
                parentForm.conn.Close();

                BindingData();
            }
            else if (rdoBtnCellPhone.Checked == true)
            {
                cmd.CommandText = "Show_Customer_With_Keyword";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = parentForm.conn;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Index", SqlDbType.Int).Value = 4;
                cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = txtSearchKeyword.Text.ToUpper() + "%";
                SqlDataAdapter adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                parentForm.conn.Open();
                dt.Clear();
                adapt.Fill(dt);
                parentForm.conn.Close();

                BindingData();
            }
            else if (rdoBtnMemberCode.Checked == true)
            {
                if (Int64.TryParse(txtSearchKeyword.Text, out memberCode))
                {
                    cmd.CommandText = "Show_Customer_With_Keyword";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = parentForm.conn;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@Index", SqlDbType.Int).Value = 5;
                    cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = Convert.ToString(memberCode);
                    SqlDataAdapter adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd;

                    parentForm.conn.Open();
                    dt.Clear();
                    adapt.Fill(dt);
                    parentForm.conn.Close();

                    BindingData();
                }
                else
                {
                    MessageBox.Show("INPUT VALID MEMBER CODE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSearchKeyword.SelectAll();
                    txtSearchKeyword.Focus();
                    return;
                }
            }

            lblNumberOfMembers.Text = Convert.ToString(dataGridView1.RowCount);
        }

        private void rdoBtnFirstName_CheckedChanged(object sender, EventArgs e)
        {
            txtSearchKeyword.Select();
            txtSearchKeyword.Focus();
        }

        private void rdoBtnHomePhone_CheckedChanged(object sender, EventArgs e)
        {
            txtSearchKeyword.Select();
            txtSearchKeyword.Focus();
        }

        private void rdoBtnMemberCode_CheckedChanged(object sender, EventArgs e)
        {
            txtSearchKeyword.Select();
            txtSearchKeyword.Focus();
        }

        private void rdoBtnLastName_CheckedChanged(object sender, EventArgs e)
        {
            txtSearchKeyword.Select();
            txtSearchKeyword.Focus();
        }

        private void rdoBtnCellPhone_CheckedChanged(object sender, EventArgs e)
        {
            txtSearchKeyword.Select();
            txtSearchKeyword.Focus();
        }

        private void btnLoadAllCustomer_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "Show_Customers";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = parentForm.conn;
            cmd.Parameters.Clear();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            dt.Clear();
            adapt.Fill(dt);
            parentForm.conn.Close();

            BindingData();

            txtSearchKeyword.Clear();
            txtSearchKeyword.Select();
            txtSearchKeyword.Focus();

            lblNumberOfMembers.Text = dataGridView1.RowCount.ToString();
        }

        private void btnRegisterNewCustomer_Click(object sender, EventArgs e)
        {
            /*RegisterNewCustomer registerNewCustomerForm = new RegisterNewCustomer();
            registerNewCustomerForm.parentForm = this.parentForm;
            registerNewCustomerForm.parentForm2 = this;
            registerNewCustomerForm.Show();*/
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                int j = 0;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Selected == true)
                    {
                        j = j + 1;
                    }
                }

                if (j > 0)
                {
                    if (Convert.ToString(dataGridView1.SelectedCells[13].Value) == "VVIP STORE MEMBER" | Convert.ToString(dataGridView1.SelectedCells[13].Value) == "VVIP BEAUTICIAN")
                    {
                        if (parentForm.userLevel >= parentForm.StoreManagerLV)
                        {
                            /*UpdateCustomer updateCustomerForm = new UpdateCustomer();
                            updateCustomerForm.parentForm1 = this.parentForm;
                            updateCustomerForm.parentForm2 = this;
                            updateCustomerForm.ShowDialog();*/
                        }
                        else
                        {
                            MessageBox.Show("NOT AUTHORIZED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        /*UpdateCustomer updateCustomerForm = new UpdateCustomer();
                        updateCustomerForm.parentForm1 = this.parentForm;
                        updateCustomerForm.parentForm2 = this;
                        updateCustomerForm.ShowDialog();*/
                    }
                }
            }
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                int j = 0;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Selected == true)
                    {
                        j = j + 1;
                    }
                }

                if (j > 0)
                {
                    if (Convert.ToString(dataGridView1.SelectedCells[13].Value) == "VVIP STORE MEMBER" | Convert.ToString(dataGridView1.SelectedCells[13].Value) == "VVIP BEAUTICIAN")
                    {
                        if (parentForm.userLevel >= parentForm.StoreManagerLV)
                        {
                            DialogResult MyDialogResult;
                            MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (MyDialogResult == DialogResult.Yes)
                            {
                                cmd.CommandText = "Delete_Customer";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = parentForm.conn;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@CustomerNo", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.SelectedCells[0].Value);

                                parentForm.conn.Open();
                                cmd.ExecuteNonQuery();
                                parentForm.conn.Close();

                                btnSearch_Click(null, null);
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
                        DialogResult MyDialogResult;
                        MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (MyDialogResult == DialogResult.Yes)
                        {
                            cmd.CommandText = "Delete_Customer";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = parentForm.conn;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@CustomerNo", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.SelectedCells[0].Value);

                            parentForm.conn.Open();
                            cmd.ExecuteNonQuery();
                            parentForm.conn.Close();

                            btnSearch_Click(null, null);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("SELECT CUSTOMER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("NO CUSTOMER ON THE LIST", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnViewCustomerInfo_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                /*CustomerInfo customerInfoForm = new CustomerInfo();
                customerInfoForm.parentForm = this;
                customerInfoForm.ShowDialog();*/
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                ExportDataGridViewTo_Excel12(dataGridView1);
            }
            else
            {
                MessageBox.Show("NO DATA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnUpdateByAdmin_Click(object sender, EventArgs e)
        {
            btnUpdateByAdmin.Enabled = false;

            if (dataGridView1.RowCount > 0)
            {
                DialogResult MyDialogResult;
                MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (MyDialogResult == DialogResult.Yes)
                {
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dataGridView1.RowCount;
                    progressBar1.Step = 1;
                    progressBar1.Visible = true;

                    backgroundWorker1.RunWorkerAsync();
                }
                else
                {
                    btnUpdateByAdmin.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("NO ITEM", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnUpdateByAdmin.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BindingData()
        {          
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "STORE CODE";
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[2].HeaderText = "FIRST NAME";
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].HeaderText = "LAST NAME";
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].HeaderText = "DATE OF BIRTH";
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].HeaderText = "ADDRESS";
            dataGridView1.Columns[5].Width = 200;
            dataGridView1.Columns[6].HeaderText = "CITY";
            dataGridView1.Columns[6].Width = 150;
            dataGridView1.Columns[7].HeaderText = "STATE";
            dataGridView1.Columns[7].Width = 50;
            dataGridView1.Columns[8].HeaderText = "ZIP CODE";
            dataGridView1.Columns[8].Width = 50;
            dataGridView1.Columns[9].HeaderText = "HOME PHONE";
            dataGridView1.Columns[9].Width = 100;
            dataGridView1.Columns[10].HeaderText = "CELL PHONE";
            dataGridView1.Columns[10].Width = 100;
            dataGridView1.Columns[11].HeaderText = "EMAIL";
            dataGridView1.Columns[11].Width = 150;
            dataGridView1.Columns[12].HeaderText = "MEMBER CODE";
            dataGridView1.Columns[12].Width = 100;
            dataGridView1.Columns[13].HeaderText = "MEMBER TYPE";
            dataGridView1.Columns[13].Width = 130;
            dataGridView1.Columns[14].HeaderText = "LICENSE NUMBER";
            dataGridView1.Columns[14].Width = 100;
            dataGridView1.Columns[15].HeaderText = "DISCOUNT OPTION";
            dataGridView1.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[15].DefaultCellStyle.Format = "0\\%";
            dataGridView1.Columns[15].Width = 70;
            dataGridView1.Columns[16].HeaderText = "INITIAL MP";
            dataGridView1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[16].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[16].Width = 70;
            dataGridView1.Columns[17].HeaderText = "MEMBER POINTS";
            dataGridView1.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[17].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[17].Width = 70;
            dataGridView1.Columns[18].HeaderText = "START DATE";
            dataGridView1.Columns[18].Width = 90;
            dataGridView1.Columns[19].HeaderText = "EXPIRATION DATE";
            dataGridView1.Columns[19].Width = 90;
            dataGridView1.Columns[20].HeaderText = "LAST VISIT DATE";
            dataGridView1.Columns[20].Width = 90;
            dataGridView1.Columns[21].HeaderText = "TRNS(P)";
            dataGridView1.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[21].Width = 60;
            dataGridView1.Columns[22].HeaderText = "TRNS(R)";
            dataGridView1.Columns[22].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[22].Width = 60;
            dataGridView1.Columns[23].HeaderText = "TRNS(T)";
            dataGridView1.Columns[23].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[23].Width = 60;
            dataGridView1.Columns[24].HeaderText = "TOTAL TRANSACTION AMOUNT";
            dataGridView1.Columns[24].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[24].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[24].Width = 100;
            dataGridView1.Columns[25].HeaderText = "SCHOOL GRADUATED";
            dataGridView1.Columns[25].Width = 100;
            dataGridView1.Columns[26].HeaderText = "MEMO";
            dataGridView1.Columns[26].Width = 100;
            dataGridView1.Columns[27].HeaderText = "ACTIVE";
            dataGridView1.Columns[27].Width = 50;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
                btnViewCustomerInfo_Click(null, null);
        }

        public static void ExportDataGridViewTo_Excel12(DataGridView myDataGridView)
        {
            try
            {
                Excel_12.Application oExcel_12 = null;                //Excel_12 Application
                Excel_12.Workbook oBook = null;                       // Excel_12 Workbook
                Excel_12.Sheets oSheetsColl = null;                   // Excel_12 Worksheets collection
                Excel_12.Worksheet oSheet = null;                     // Excel_12 Worksheet
                Excel_12.Range oRange = null;                         // Cell or Range in worksheet
                Object oMissing = System.Reflection.Missing.Value;

                // Create an instance of Excel_12.
                oExcel_12 = new Excel_12.Application();

                // Make Excel_12 visible to the user.
                oExcel_12.Visible = true;

                // Set the UserControl property so Excel_12 won't shut down.
                oExcel_12.UserControl = true;

                // System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");

                // Add a workbook.
                oBook = oExcel_12.Workbooks.Add(oMissing);

                // Get worksheets collection 
                oSheetsColl = oExcel_12.Worksheets;

                // Get Worksheet "Sheet1"
                oSheet = (Excel_12.Worksheet)oSheetsColl.get_Item("Sheet1");

                // Export titles
                for (int j = 0; j < myDataGridView.Columns.Count; j++)
                {
                    oRange = (Excel_12.Range)oSheet.Cells[1, j + 1];
                    oRange.Value2 = myDataGridView.Columns[j].HeaderText;
                }

                // Export data
                for (int i = 0; i < myDataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < myDataGridView.Columns.Count; j++)
                    {
                        oRange = (Excel_12.Range)oSheet.Cells[i + 2, j + 1];
                        oRange.Value2 = myDataGridView[j, i].Value.ToString();
                    }
                }

                // Release the variables.
                //oBook.Close(false, oMissing, oMissing);
                oBook = null;

                //oExcel_12.Quit();
                oExcel_12 = null;

                // Collect garbage.
                GC.Collect();
            }
            catch
            {
                MessageBox.Show("CAN NOT GENERATE EXCEL FILE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (DateTime.TryParse(dataGridView1.Rows[i].Cells[4].Value.ToString(), out d1))
                {
                    dob = string.Format("{0:MM/dd/yyyy}", d1);
                }
                else
                {
                    dob = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                }

                if (DateTime.TryParse(dataGridView1.Rows[i].Cells[18].Value.ToString(), out d2))
                {
                    startDate = string.Format("{0:MM/dd/yyyy}", d2);
                }
                else
                {
                    startDate = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                }

                if (DateTime.TryParse(dataGridView1.Rows[i].Cells[19].Value.ToString(), out d3))
                {
                    expDate = string.Format("{0:MM/dd/yyyy}", d3);
                }
                else
                {
                    expDate = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(startDate).AddYears(5));
                }

                if (DateTime.TryParse(dataGridView1.Rows[i].Cells[20].Value.ToString(), out d4))
                {
                    lastVisitDate = string.Format("{0:MM/dd/yyyy}", d4);
                }
                else
                {
                    lastVisitDate = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(startDate));
                }

                cmd = new SqlCommand("Update_Customer_ByAdmin", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@CustomerNo", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                cmd.Parameters.Add("@DateOfBirth", SqlDbType.NVarChar).Value = dob;
                cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = startDate;
                cmd.Parameters.Add("@ExpirationDate", SqlDbType.NVarChar).Value = expDate;
                cmd.Parameters.Add("@LastVisitDate", SqlDbType.NVarChar).Value = lastVisitDate;

                parentForm.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm.conn.Close();

                backgroundWorker1.ReportProgress(i + 1);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("SUCCESSFULLY UPDATED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

            progressBar1.Visible = false;
            progressBar1.Value = 0;
            btnUpdateByAdmin.Enabled = true;

            if (txtSearchKeyword.Text == "")
            {
                btnLoadAllCustomer_Click(null, null);
            }
            else
            {
                btnSearch_Click(null, null);
            }
        }
    }
}