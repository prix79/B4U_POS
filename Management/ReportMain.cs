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
    public partial class ReportMain : Form
    {
        public LogInManagements parentForm;

        public bool Authorized;
        public bool BtnSalesByStore = true;

        public ReportMain()
        {
            InitializeComponent();
        }

        private void ReportMain_Load(object sender, EventArgs e)
        {
            this.Text = "REPORT MAIN - " + parentForm.employeeID + " LOGGED IN " + parentForm.storeName;
            Authorized = false;

            if (parentForm.userLevel < parentForm.btnReportTimeCard)
                btnTimeCard.Enabled = false;

            if (parentForm.userLevel < parentForm.btnReportSalesByStore)
                btnSalesByStore.Enabled = false;

            if (parentForm.userLevel < parentForm.AssistantSectionManagerLV)
                btnItemList.Enabled = false;

            if (parentForm.userLevel < parentForm.SectionManagerLV)
                btnCustomerReport.Enabled = false;

            if (parentForm.StoreCode == "B4UHQ")
            {
                btnSalesHistory.Enabled = true;
                btnRegisterHistory.Enabled = false;
                btnItemSoldHistory.Enabled = false;
                btnStoreCreditList.Enabled = false;
                btnRedeemHistory.Enabled = false;
                btnCustomerReport.Enabled = false;
                btnItemList.Enabled = true;
                btnItemMovingHistory.Enabled = false;
            }
            else if(parentForm.StoreCode == "B4UWH")
            {
                btnSalesHistory.Enabled = false;
                btnRegisterHistory.Enabled = false;
                btnItemSoldHistory.Enabled = false;
                btnSalesByStore.Enabled = false;
                btnStoreCreditList.Enabled = false;
                btnRedeemHistory.Enabled = false;
                btnCustomerReport.Enabled = false;
                btnItemList.Enabled = false;
            }
            else
            {
                btnSalesByStore.Enabled = false;
            }
        }

        private void btnSalesHistory_Click(object sender, EventArgs e)
        {
            SalesHistory salesHistoryForm = new SalesHistory();
            salesHistoryForm.parentForm = this.parentForm;
            salesHistoryForm.Show();
        }

        private void btnRegisterHistory_Click(object sender, EventArgs e)
        {
            RegisterHistory registerHistoryForm = new RegisterHistory();
            registerHistoryForm.parentForm = this.parentForm;
            registerHistoryForm.Show();
        }

        private void btnTimeCard_Click(object sender, EventArgs e)
        {
            if (parentForm.employeeID == "ADMIN" & parentForm.userLevel >= parentForm.SystemAdministratorLV)
            {
                TimeCard timeCardForm = new TimeCard(1);
                timeCardForm.parentForm = this.parentForm;
                timeCardForm.Show();
            }
            else
            {
                TimeCard timeCardForm = new TimeCard(0);
                timeCardForm.parentForm = this.parentForm;
                timeCardForm.Show();
            }
        }

        public void btnSalesByStore_Click(object sender, EventArgs e)
        {
            if (parentForm.userLevel >= parentForm.GeneralManagerLV)
            {
                Authorized = true;
            }
            else
            {
                if (Authorized == false)
                {
                    BtnSalesByStore = false;
                }
                else
                {
                    BtnSalesByStore = true;
                }
            }

            try
            {
                if (BtnSalesByStore == true)
                {
                    SqlCommand cmd = new SqlCommand("Check_User", parentForm.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@empLoginID", SqlDbType.NVarChar).Value = parentForm.employeeID.ToUpper().ToString();
                    SqlParameter UserName_Param = cmd.Parameters.Add("@empFirstName", SqlDbType.NVarChar, 50);
                    UserName_Param.Direction = ParameterDirection.Output;

                    parentForm.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm.conn.Close();

                    if (cmd.Parameters["@empFirstName"].Value == DBNull.Value)
                    {
                        if (parentForm.employeeID == parentForm.SystemMasterUserName)
                        {
                            SalesHistoryByStore salesHistoryByStoreForm = new SalesHistoryByStore();
                            salesHistoryByStoreForm.parentForm = this.parentForm;
                            salesHistoryByStoreForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("NOT AUTHORIZED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        if (parentForm.userLevel >= parentForm.SectionManagerLV)
                        {
                            SalesHistoryByStore salesHistoryByStoreForm = new SalesHistoryByStore();
                            salesHistoryByStoreForm.parentForm = this.parentForm;
                            salesHistoryByStoreForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("NOT AUTHORIZED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                else
                {
                    InputPasscode inputPasscodeFrom = new InputPasscode(0);
                    inputPasscodeFrom.parentForm1 = this.parentForm;
                    inputPasscodeFrom.parentForm3 = this;
                    inputPasscodeFrom.Show();
                }
            }
            catch
            {
                MessageBox.Show("CAN NOT CONNECT TO SERVER...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                parentForm.conn.Close();
                return;
            }

            /*if (parentForm.userLevel > 5)
            {
                SalesHistoryByStore salesHistoryByStoreForm = new SalesHistoryByStore();
                salesHistoryByStoreForm.Show();
            }
            else
            {
                MessageBox.Show("NOT AUTHORIZED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/

            //SalesHistoryByStore salesHistoryByStoreForm = new SalesHistoryByStore();
            //salesHistoryByStoreForm.parentForm = this.parentForm;
            //salesHistoryByStoreForm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnItemList_Click(object sender, EventArgs e)
        {
            ItemList itemListForm = new ItemList();
            itemListForm.parentForm = this.parentForm;
            itemListForm.Show();
        }

        private void btnCustomerReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("NOT AVAILABLE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;

            /*CustomerReport customerReportForm = new CustomerReport();
            customerReportForm.parentForm = this.parentForm;
            customerReportForm.Show();*/
        }

        private void btnRedeemHistory_Click(object sender, EventArgs e)
        {
            RedeemHistory redeemHistoryForm = new RedeemHistory();
            redeemHistoryForm.parentForm = this.parentForm;
            redeemHistoryForm.Show();
        }

        private void btnItemSoldHistory_Click(object sender, EventArgs e)
        {
            ItemSoldList itemSoldListForm = new ItemSoldList(1);
            itemSoldListForm.parentForm = this.parentForm;
            itemSoldListForm.Show();
        }

        private void btnStoreCreditList_Click(object sender, EventArgs e)
        {
            StoreCrdeitList storeCreditListForm = new StoreCrdeitList();
            storeCreditListForm.parentForm = this.parentForm;
            storeCreditListForm.Show();
        }

        private void btnItemMovingHistory_Click(object sender, EventArgs e)
        {
            POandReceivingHistory itemMovingHistoryForm = new POandReceivingHistory();
            itemMovingHistoryForm.parentForm = this.parentForm;
            itemMovingHistoryForm.Show();
        }
    }
}