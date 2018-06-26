using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Management
{
    public partial class AdminToolsMain : Form
    {
        public LogInManagements parentForm;

        public AdminToolsMain()
        {
            InitializeComponent();
        }

        private void AdminToolMain_Load(object sender, EventArgs e)
        {
            if (parentForm.employeeID.ToUpper() == parentForm.SystemMasterUserName.ToUpper())
                btnCategoryUpdate.Enabled = true;

            if (parentForm.StoreCode.ToUpper() == parentForm.WarehouseStoreCode1.ToUpper() & parentForm.storeName.ToUpper() == parentForm.WarehouseName1.ToUpper())
            {
                btnManageTransactions.Enabled = false;
            }
            else
            {
                btnManageTransactions.Enabled = true;
            }
        }

        private void btnManageTransactions_Click(object sender, EventArgs e)
        {
            AdminRegisterHistory adminRegisterHistoryForm = new AdminRegisterHistory();
            adminRegisterHistoryForm.parentForm = this.parentForm;
            adminRegisterHistoryForm.Show();

            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditStorePolicy_Click(object sender, EventArgs e)
        {

        }

        private void btnManageButtonAccess_Click(object sender, EventArgs e)
        {

        }

        private void btnChangePasscode_Click(object sender, EventArgs e)
        {
            if (parentForm.StoreCode.ToUpper() == parentForm.WarehouseStoreCode1.ToUpper() & parentForm.storeName.ToUpper() == parentForm.WarehouseName1.ToUpper())
            {
                ChangePasscode changePasscodeForm = new ChangePasscode(1);
                changePasscodeForm.parentForm = this.parentForm;
                changePasscodeForm.ShowDialog();
            }
            else
            {
                ChangePasscode changePasscodeForm = new ChangePasscode(0);
                changePasscodeForm.parentForm = this.parentForm;
                changePasscodeForm.ShowDialog();
            }
        }

        private void btnCategoryUpdate_Click(object sender, EventArgs e)
        {
            CategoryUpdates categoryUpdatesForm = new CategoryUpdates();
            categoryUpdatesForm.parentForm = this.parentForm;
            categoryUpdatesForm.Show();

            this.Close();
        }

        private void btnUploadExcelFile_Click(object sender, EventArgs e)
        {
            UploadExcelFile uploadExcelFile = new UploadExcelFile();
            uploadExcelFile.parentForm1 = this.parentForm;
            uploadExcelFile.Show();

            this.Close();
        }
    }
}