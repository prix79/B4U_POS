using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Management
{
    public partial class CustomerInfo : Form
    {
        public MembershipMain parentForm;

        public CustomerInfo()
        {
            InitializeComponent();
        }

        private void CustomerInfo_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(parentForm.dataGridView1.SelectedCells[1].Value) == "TH")
            {
                lblOpenStore.Text = "TEMPLE HILLS";
            }
            else if (Convert.ToString(parentForm.dataGridView1.SelectedCells[1].Value) == "OH")
            {
                lblOpenStore.Text = "OXON HILL";
            }
            else if (Convert.ToString(parentForm.dataGridView1.SelectedCells[1].Value) == "UM")
            {
                lblOpenStore.Text = "UPPER MARLBORO";
            }
            else if (Convert.ToString(parentForm.dataGridView1.SelectedCells[1].Value) == "CH")
            {
                lblOpenStore.Text = "CAPITOL HEIGHTS";
            }
            else if (Convert.ToString(parentForm.dataGridView1.SelectedCells[1].Value) == "WM")
            {
                lblOpenStore.Text = "WINDSOR MILL";
            }
            else if (Convert.ToString(parentForm.dataGridView1.SelectedCells[1].Value) == "CV")
            {
                lblOpenStore.Text = "CATONSVILLE";
            }
            else if (Convert.ToString(parentForm.dataGridView1.SelectedCells[1].Value) == "PW")
            {
                lblOpenStore.Text = "PRINCE WILLIAM";
            }
            else if (Convert.ToString(parentForm.dataGridView1.SelectedCells[1].Value) == "WB")
            {
                lblOpenStore.Text = "WOODBRIDGE";
            }
            else if (Convert.ToString(parentForm.dataGridView1.SelectedCells[1].Value) == "WD")
            {
                lblOpenStore.Text = "WALDORF";
            }
            else if (Convert.ToString(parentForm.dataGridView1.SelectedCells[1].Value) == "GB")
            {
                lblOpenStore.Text = "GAITHERSBURG";
            }
            else if (Convert.ToString(parentForm.dataGridView1.SelectedCells[1].Value) == "BW")
            {
                lblOpenStore.Text = "BOWIE";
            }
            else
            {
                lblOpenStore.Text = "UNKNOWN";
            }

            lblName.Text = Convert.ToString(parentForm.dataGridView1.SelectedCells[2].Value) + " " + Convert.ToString(parentForm.dataGridView1.SelectedCells[3].Value);
            lblDOB.Text = Convert.ToString(parentForm.dataGridView1.SelectedCells[4].Value);
            lblAddress.Text = Convert.ToString(parentForm.dataGridView1.SelectedCells[5].Value);
            lblCity.Text = Convert.ToString(parentForm.dataGridView1.SelectedCells[6].Value);
            lblState.Text = Convert.ToString(parentForm.dataGridView1.SelectedCells[7].Value);
            lblZipCode.Text = Convert.ToString(parentForm.dataGridView1.SelectedCells[8].Value);
            lblHomePhone.Text = Convert.ToString(parentForm.dataGridView1.SelectedCells[9].Value);
            lblCellPhone.Text = Convert.ToString(parentForm.dataGridView1.SelectedCells[10].Value);
            lblEmail.Text = Convert.ToString(parentForm.dataGridView1.SelectedCells[11].Value);
            lblMemberCode.Text = Convert.ToString(parentForm.dataGridView1.SelectedCells[12].Value);
            lblMemberType.Text = Convert.ToString(parentForm.dataGridView1.SelectedCells[13].Value);
            lblLicenseNumber.Text = Convert.ToString(parentForm.dataGridView1.SelectedCells[14].Value);
            lblDiscountOption.Text = string.Format("{0:0\\%}", Convert.ToDouble(parentForm.dataGridView1.SelectedCells[15].Value));
            lblMemberPoints.Text = string.Format("{0:$0.00}", Convert.ToDouble(parentForm.dataGridView1.SelectedCells[17].Value));
            lblRegisterDate.Text = Convert.ToString(parentForm.dataGridView1.SelectedCells[18].Value);
            lblExpirationDate.Text = Convert.ToString(parentForm.dataGridView1.SelectedCells[19].Value);
            lblLastVisitDate.Text = Convert.ToString(parentForm.dataGridView1.SelectedCells[20].Value);
            lblPurchasingTransaction.Text = Convert.ToString(parentForm.dataGridView1.SelectedCells[21].Value);
            lblReturnTransaction.Text = Convert.ToString(parentForm.dataGridView1.SelectedCells[22].Value);
            lblTotalTransaction.Text = Convert.ToString(parentForm.dataGridView1.SelectedCells[23].Value);
            lblTotalTransactionAmount.Text = string.Format("{0:$0.00}", Convert.ToDouble(parentForm.dataGridView1.SelectedCells[24].Value));
            lblSchoolGraduated.Text = Convert.ToString(parentForm.dataGridView1.SelectedCells[25].Value);
            lblMemo.Text = Convert.ToString(parentForm.dataGridView1.SelectedCells[26].Value);


            if (Convert.ToBoolean(parentForm.dataGridView1.SelectedCells[27].Value) == true)
            {
                lblActive.Text = "TRUE";
            }
            else if (Convert.ToBoolean(parentForm.dataGridView1.SelectedCells[27].Value) == false)
            {
                lblActive.Text = "FALSE";
            }

            if (Convert.ToBoolean(parentForm.dataGridView1.SelectedCells[28].Value) == true)
            {
                lblStoreEmployee.Text = "TRUE";
            }
            else if (Convert.ToBoolean(parentForm.dataGridView1.SelectedCells[28].Value) == false)
            {
                lblStoreEmployee.Text = "FALSE";
            }

            this.Text = "MEMBER INFORMATION - " + lblName.Text + " (MEMBER CODE : " + lblMemberCode.Text + ")";
        }

        private void btnTransactionHistory_Click(object sender, EventArgs e)
        {
            CustomerSales customerSalesForm = new CustomerSales(Convert.ToInt64(lblMemberCode.Text.Trim()));
            customerSalesForm.parentForm = this.parentForm.parentForm;
            customerSalesForm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}