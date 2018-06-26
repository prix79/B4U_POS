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
    public partial class LoadOption : Form
    {
        public StoreCrdeitList parentForm1;
        public RedeemHistory parentForm2;
        public InvoiceSummaryMain parentForm3;

        int opt;
        DateTime d1, d2;

        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        int F_Opt = 1;

        public LoadOption(int option)
        {
            InitializeComponent();
            opt = option;
        }

        private void LoadOption_Load(object sender, EventArgs e)
        {
            txtStartDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            txtEndDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

            if (opt == 2)
            {
                label2.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
                label3.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
                label2.Text = "INVOICE START DATE";
                label3.Text = "INVOICE END DATE";

                groupBox1.Visible = true;

                if (parentForm3.parentForm.userLevel < parentForm3.parentForm.StoreManagerLV)
                {
                    rdoBtnEmployeeID.Enabled = false;
                }

                SqlCommand cmd_CmbCategory1 = new SqlCommand("Get_Category_Group1", parentForm3.parentForm.conn);
                cmd_CmbCategory1.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                SqlDataAdapter adapt2 = new SqlDataAdapter();
                adapt2.SelectCommand = cmd_CmbCategory1;

                SqlDataReader dReader;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = parentForm3.parentForm.conn;
                if (parentForm3.parentForm.StoreCode == "B4UHQ")
                {
                    cmd.CommandText = "Select Distinct empLoginID From Employee Where empStatus='True' and empSCCurrent='B4UHQ' Order by empLoginID asc";
                }
                else
                {
                    cmd.CommandText = "Select Distinct empLoginID From Employee Where empStatus='True' Order by empLoginID asc";
                }
                cmd.CommandTimeout = 5;

                parentForm3.parentForm.conn.Open();
                adapt2.Fill(ds);

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
                parentForm3.parentForm.conn.Close();

                cmbCategory1.DataSource = ds.Tables[0].DefaultView;
                cmbCategory1.ValueMember = "ItmGp_Desc";
                cmbCategory1.DisplayMember = "ItmGp_Desc";

                txtEmployeeID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtEmployeeID.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtEmployeeID.AutoCompleteCustomSource = namesCollection;
            }
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParse(txtStartDate.Text, out d1))
            {
            }
            else
            {
                MessageBox.Show("INVALID DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStartDate.SelectAll();
                txtStartDate.Focus();
                return;
            }

            if (DateTime.TryParse(txtEndDate.Text, out d2))
            {
            }
            else
            {
                MessageBox.Show("INVALID DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEndDate.SelectAll();
                txtEndDate.Focus();
                return;
            }

            if (opt == 0)
            {
                parentForm1.startDate = string.Format("{0:MM/dd/yyyy}", d1);
                parentForm1.endDate = string.Format("{0:MM/dd/yyyy}", d2);
                parentForm1.Load_StoreCreditList();
                this.Close();
            }
            else if (opt == 1)
            {
                parentForm2.startDate = string.Format("{0:MM/dd/yyyy}", d1);
                parentForm2.endDate = string.Format("{0:MM/dd/yyyy}", d2);
                parentForm2.Load_RedeemHistory();
                this.Close();
            }
            else if (opt == 2)
            {
                parentForm3.startDate = string.Format("{0:MM/dd/yyyy}", d1);
                parentForm3.endDate = string.Format("{0:MM/dd/yyyy}", d2);
                if (cmbCategory1.SelectedIndex > 5)
                {
                    parentForm3.category1 = cmbCategory1.SelectedIndex + 1;
                }
                else
                {
                    parentForm3.category1 = cmbCategory1.SelectedIndex;
                }
                parentForm3.empID = txtEmployeeID.Text.Trim().ToUpper();
                parentForm3.Load_InvoiceList(F_Opt);
                this.Close();
            }
        }

        private void rdoBtnCategory_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBtnCategory.Checked == true)
            {
                cmbCategory1.SelectedIndex = 0;
                cmbCategory1.Enabled = true;
                txtEmployeeID.Clear();
                txtEmployeeID.Enabled = false;

                F_Opt = 1;                
            }
            else if (rdoBtnEmployeeID.Checked == true)
            {
                cmbCategory1.SelectedIndex = 0;
                cmbCategory1.Enabled = false;
                txtEmployeeID.Clear();
                txtEmployeeID.Focus();
                txtEmployeeID.Enabled = true;

                F_Opt = 2;
            }
            else
            {
                cmbCategory1.SelectedIndex = 0;
                cmbCategory1.Enabled = false;
                txtEmployeeID.Clear();
                txtEmployeeID.Enabled = false;

                F_Opt = 0;
            }
        }

        private void rdoBtnEmployeeID_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBtnCategory.Checked == true)
            {
                cmbCategory1.SelectedIndex = 0;
                cmbCategory1.Enabled = true;
                txtEmployeeID.Clear();
                txtEmployeeID.Enabled = false;

                F_Opt = 1;
            }
            else if (rdoBtnEmployeeID.Checked == true)
            {
                cmbCategory1.SelectedIndex = 0;
                cmbCategory1.Enabled = false;
                txtEmployeeID.Clear();
                txtEmployeeID.Focus();
                txtEmployeeID.Enabled = true;

                F_Opt = 2;
            }
            else
            {
                cmbCategory1.SelectedIndex = 0;
                cmbCategory1.Enabled = false;
                txtEmployeeID.Clear();
                txtEmployeeID.Enabled = false;

                F_Opt = 0;
            }
        }

        private void rdoBtnAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBtnCategory.Checked == true)
            {
                cmbCategory1.SelectedIndex = 0;
                cmbCategory1.Enabled = true;
                txtEmployeeID.Clear();
                txtEmployeeID.Enabled = false;

                F_Opt = 1;
            }
            else if (rdoBtnEmployeeID.Checked == true)
            {
                cmbCategory1.SelectedIndex = 0;
                cmbCategory1.Enabled = false;
                txtEmployeeID.Clear();
                txtEmployeeID.Focus();
                txtEmployeeID.Enabled = true;

                F_Opt = 2;
            }
            else
            {
                cmbCategory1.SelectedIndex = 0;
                cmbCategory1.Enabled = false;
                txtEmployeeID.Clear();
                txtEmployeeID.Enabled = false;

                F_Opt = 0;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}