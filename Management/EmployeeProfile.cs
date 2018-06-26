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
    public partial class EmployeeProfile : Form
    {
        public LogInManagements parentForm1;
        public EmployeeMain parentForm2;

        int idx;

        public EmployeeProfile(int index)
        {
            InitializeComponent();
            idx = index;
        }

        private void EmployeeProfile_Load(object sender, EventArgs e)
        {
            if (parentForm1.StoreCode.ToUpper() == "B4UHQ")
            {
                lblStoreCodeRegistered.Visible = true;
                txtStoreCodeRegistered.Visible = true;
                btnTransferHistory.Visible = true;

                txtStoreCodeRegistered.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[1].Value);
                lblStoreLocation.Text = parentForm1.storeName;
                lblLoginID.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[5].Value);
                lblFirstName.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[3].Value);
                lblLastName.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[4].Value);
                lblDOB.Text = string.Format("{0:MM/dd/yyyy}", parentForm2.dataGridView1.SelectedCells[12].Value);
                lblPosition.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[7].Value);

                switch (Convert.ToInt16(parentForm2.dataGridView1.SelectedCells[8].Value))
                {
                    case 1:
                        lblAccessLevel.Text = "1 - CASHIER";
                        break;
                    case 2:
                        lblAccessLevel.Text = "2 - ASSITANT SECTION MANAGER";
                        break;
                    case 3:
                        lblAccessLevel.Text = "3 - ASSITANT STORE MANAGER";
                        break;
                    case 4:
                        lblAccessLevel.Text = "4 - SECTION MANAGER";
                        break;
                    case 5:
                        lblAccessLevel.Text = "5 - STORE MANAGER";
                        break;
                    case 6:
                        lblAccessLevel.Text = "6 - DIRECTOR";
                        break;
                    case 7:
                        lblAccessLevel.Text = "7 - ADMINISTRATOR";
                        break;
                    default:
                        lblAccessLevel.Text = "NOT SPECIFIED";
                        break;
                }

                lblStartDate.Text = string.Format("{0:MM/dd/yyyy}", parentForm2.dataGridView1.SelectedCells[9].Value);
                lblSSN.Text = Convert.ToString(parentForm2.temp.Rows[idx][11]);

                if (Convert.ToBoolean(parentForm2.dataGridView1.SelectedCells[10].Value) == true)
                {
                    lblStatus.Text = "ACTIVE";
                    lblStatus.ForeColor = Color.Green;
                }
                else
                {
                    lblStatus.Text = "INACTIVE";
                    lblStatus.ForeColor = Color.Red;
                }

                lblAddress.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[13].Value);
                lblCity.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[14].Value);
                lblState.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[15].Value);
                lblZipCode.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[16].Value);
                lblPhone1.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[17].Value);
                lblPhone2.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[18].Value);
                lblEmail.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[19].Value);
                lblEmerContName.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[20].Value);
                lblEmerContPhone.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[21].Value);
            }
            else
            {
                lblStoreLocation.Text = parentForm1.storeName;
                lblLoginID.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[4].Value);
                lblFirstName.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[2].Value);
                lblLastName.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[3].Value);
                lblDOB.Text = string.Format("{0:MM/dd/yyyy}", parentForm2.dataGridView1.SelectedCells[11].Value);
                lblPosition.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[6].Value);

                switch (Convert.ToInt16(parentForm2.dataGridView1.SelectedCells[7].Value))
                {
                    case 1:
                        lblAccessLevel.Text = "1 - CASHIER";
                        break;
                    case 2:
                        lblAccessLevel.Text = "2 - ASSITANT SECTION MANAGER";
                        break;
                    case 3:
                        lblAccessLevel.Text = "3 - ASSITANT STORE MANAGER";
                        break;
                    case 4:
                        lblAccessLevel.Text = "4 - SECTION MANAGER";
                        break;
                    case 5:
                        lblAccessLevel.Text = "5 - STORE MANAGER";
                        break;
                    case 6:
                        lblAccessLevel.Text = "6 - DIRECTOR";
                        break;
                    case 7:
                        lblAccessLevel.Text = "7 - ADMINISTRATOR";
                        break;
                    default:
                        lblAccessLevel.Text = "NOT SPECIFIED";
                        break;
                }

                lblStartDate.Text = string.Format("{0:MM/dd/yyyy}", parentForm2.dataGridView1.SelectedCells[8].Value);
                lblSSN.Text = Convert.ToString(parentForm2.temp.Rows[idx][10]);

                if (Convert.ToBoolean(parentForm2.dataGridView1.SelectedCells[9].Value) == true)
                {
                    lblStatus.Text = "ACTIVE";
                    lblStatus.ForeColor = Color.Green;
                }
                else
                {
                    lblStatus.Text = "INACTIVE";
                    lblStatus.ForeColor = Color.Red;
                }

                lblAddress.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[12].Value);
                lblCity.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[13].Value);
                lblState.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[14].Value);
                lblZipCode.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[15].Value);
                lblPhone1.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[16].Value);
                lblPhone2.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[17].Value);
                lblEmail.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[18].Value);
                lblEmerContName.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[19].Value);
                lblEmerContPhone.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[20].Value);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTransferHistory_Click(object sender, EventArgs e)
        {
            TransferHistory transferHistoryForm = new TransferHistory();
            transferHistoryForm.parentForm1 = this.parentForm1;
            transferHistoryForm.parentform2 = this;
            transferHistoryForm.ShowDialog();
        }
    }
}