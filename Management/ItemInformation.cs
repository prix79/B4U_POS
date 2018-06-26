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
    public partial class ItemInformation : Form
    {
        public LogInManagements parentForm1;
        public InventoryMain parentForm2;
        public ItemSoldList parentForm3;
        public InventoryMainHQ parentForm4;
        public ItemSoldListForReturn parentForm5;
        SqlCommand cmd;
        public string itmUpc;
        string t_Date;
        public int option = 0;

        public ItemInformation(string upc, int opt)
        {
            InitializeComponent();
            itmUpc = upc;
            option = opt;
        }

        public void ItemInformation_Load(object sender, EventArgs e)
        {
            lblUpc.Text = itmUpc;
            lblUpc.ForeColor = Color.DarkRed;
            t_Date = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

            cmd = new SqlCommand("Get_Item_Information", parentForm1.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = itmUpc;
            cmd.Parameters.Add("@T_Date", SqlDbType.NVarChar).Value = t_Date;
            SqlParameter Brand_param = cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar, 50);
            SqlParameter Name_param = cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar, 50);
            SqlParameter Size_param = cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar, 50);
            SqlParameter Color_param = cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar, 50);
            SqlParameter ModelNum_param = cmd.Parameters.Add("@ItmModelNum", SqlDbType.NVarChar, 50);
            SqlParameter Vendor_param = cmd.Parameters.Add("@ItmVendor", SqlDbType.NVarChar, 50);
            SqlParameter Bin_param = cmd.Parameters.Add("@ItmBin", SqlDbType.NVarChar, 10);
            SqlParameter RegisterDate_param = cmd.Parameters.Add("@ItmRegisterDate", SqlDbType.NVarChar, 20);
            //SqlParameter LastUpdateDate_param = cmd.Parameters.Add("@ItmLastUpdateDate", SqlDbType.NVarChar, 50);
            SqlParameter RetailPrice_param = cmd.Parameters.Add("@ItmRetailPrice", SqlDbType.Money);
            SqlParameter CostPrice_param = cmd.Parameters.Add("@ItmCostPrice", SqlDbType.Money);
            SqlParameter StylistPrice_param = cmd.Parameters.Add("@ItmStylistPrice", SqlDbType.Money);
            SqlParameter MinimumStock_param = cmd.Parameters.Add("@ItmStockMin", SqlDbType.Int);
            SqlParameter Onhand_param = cmd.Parameters.Add("@ItmOnHand", SqlDbType.Int);
            SqlParameter Taxable_param = cmd.Parameters.Add("@ItmTaxable", SqlDbType.Bit);
            SqlParameter TaxRate_param = cmd.Parameters.Add("@ItmTax", SqlDbType.Money);
            SqlParameter InventoryActive_param = cmd.Parameters.Add("@ItmActive", SqlDbType.Bit);
            SqlParameter PromotionActive_param = cmd.Parameters.Add("@PromotionActive", SqlDbType.Int);
            //SqlParameter PromotionActive_param = cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar, 50);
            Brand_param.Direction = ParameterDirection.Output;
            Name_param.Direction = ParameterDirection.Output;
            Size_param.Direction = ParameterDirection.Output;
            Brand_param.Direction = ParameterDirection.Output;
            Color_param.Direction = ParameterDirection.Output;
            ModelNum_param.Direction = ParameterDirection.Output;
            Vendor_param.Direction = ParameterDirection.Output;
            Bin_param.Direction = ParameterDirection.Output;
            RegisterDate_param.Direction = ParameterDirection.Output;
            RetailPrice_param.Direction = ParameterDirection.Output;
            CostPrice_param.Direction = ParameterDirection.Output;
            StylistPrice_param.Direction = ParameterDirection.Output;
            MinimumStock_param.Direction = ParameterDirection.Output;
            Onhand_param.Direction = ParameterDirection.Output;
            Taxable_param.Direction = ParameterDirection.Output;
            TaxRate_param.Direction = ParameterDirection.Output;
            InventoryActive_param.Direction = ParameterDirection.Output;
            PromotionActive_param.Direction = ParameterDirection.Output;

            parentForm1.conn.Open();
            cmd.ExecuteNonQuery();
            parentForm1.conn.Close();

            if (cmd.Parameters["@ItmBrand"].Value != DBNull.Value)
                lblBrand.Text = Convert.ToString(cmd.Parameters["@ItmBrand"].Value);

            if (cmd.Parameters["@ItmName"].Value != DBNull.Value)
                lblName.Text = Convert.ToString(cmd.Parameters["@ItmName"].Value);

            if (cmd.Parameters["@ItmSize"].Value != DBNull.Value)
                lblSize.Text = Convert.ToString(cmd.Parameters["@ItmSize"].Value);

            if (cmd.Parameters["@ItmColor"].Value != DBNull.Value)
                lblColor.Text = Convert.ToString(cmd.Parameters["@ItmColor"].Value);

            if (cmd.Parameters["@ItmmodelNum"].Value != DBNull.Value)
                lblModelNumber.Text = Convert.ToString(cmd.Parameters["@ItmModelNum"].Value);

            if (cmd.Parameters["@ItmVendor"].Value != DBNull.Value)
                lblVendor.Text = Convert.ToString(cmd.Parameters["@ItmVendor"].Value);

            if (cmd.Parameters["@ItmBin"].Value != DBNull.Value)
                lblBin.Text = Convert.ToString(cmd.Parameters["@ItmBin"].Value);

            if (cmd.Parameters["@ItmRegisterDate"].Value != DBNull.Value)
                lblRegisterDate.Text = Convert.ToString(cmd.Parameters["@ItmRegisterDate"].Value);

            if (cmd.Parameters["@ItmRetailPrice"].Value != DBNull.Value)
                lblRetailPrice.Text = string.Format("{0:$0.00}", Convert.ToDouble(cmd.Parameters["@ItmRetailPrice"].Value));

            if (cmd.Parameters["@ItmCostPrice"].Value != DBNull.Value)
                lblCostPrice.Text = string.Format("{0:$0.00}", Convert.ToDouble(cmd.Parameters["@ItmCostPrice"].Value));

            if (cmd.Parameters["@ItmStylistPrice"].Value != DBNull.Value)
                lblStylistPrice.Text = string.Format("{0:$0.00}", Convert.ToDouble(cmd.Parameters["@ItmStylistPrice"].Value));

            if (cmd.Parameters["@ItmStockMin"].Value != DBNull.Value)
                lblMinimumStock.Text = Convert.ToString(cmd.Parameters["@ItmStockMin"].Value);

            if (cmd.Parameters["@ItmOnHand"].Value != DBNull.Value)
                lblOnhand.Text = Convert.ToString(cmd.Parameters["@ItmOnHand"].Value);

            if (cmd.Parameters["@ItmTaxable"].Value != DBNull.Value)
            {
                if (Convert.ToBoolean(cmd.Parameters["@ItmTaxable"].Value) == true)
                {
                    lblTaxable.Text = Convert.ToString(cmd.Parameters["@ItmTaxable"].Value).ToUpper();
                    lblTaxable.ForeColor = Color.Blue;
                }
                else if (Convert.ToBoolean(cmd.Parameters["@ItmTaxable"].Value) == false)
                {
                    lblTaxable.Text = Convert.ToString(cmd.Parameters["@ItmTaxable"].Value).ToUpper();
                    lblTaxable.ForeColor = Color.Red;
                }
            }

            if (cmd.Parameters["@ItmTax"].Value != DBNull.Value)
                lblTaxRate.Text = Convert.ToString(cmd.Parameters["@ItmTax"].Value);

            if (cmd.Parameters["@ItmActive"].Value != DBNull.Value)
            {
                if (Convert.ToBoolean(cmd.Parameters["@ItmActive"].Value) == true)
                {
                    lblInventoryActive.Text = Convert.ToString(cmd.Parameters["@ItmActive"].Value).ToUpper();
                    lblInventoryActive.ForeColor = Color.Blue;
                }
                else if (Convert.ToBoolean(cmd.Parameters["@ItmActive"].Value) == false)
                {
                    lblInventoryActive.Text = Convert.ToString(cmd.Parameters["@ItmActive"].Value).ToUpper(); ;
                    lblInventoryActive.ForeColor = Color.Red;
                }
            }

            if (cmd.Parameters["@PromotionActive"].Value != DBNull.Value)
            {
                if (Convert.ToInt16(cmd.Parameters["@PromotionActive"].Value) >= 1)
                {
                    lblPromotionActive.Text = "TRUE";
                    lblPromotionActive.ForeColor = Color.Blue;
                }
                else if (Convert.ToInt16(cmd.Parameters["@PromotionActive"].Value) == 0)
                {
                    lblPromotionActive.Text = "FALSE";
                    lblPromotionActive.ForeColor = Color.Red;
                }
            }
        }

        private void btnUpdateOnhand_Click(object sender, EventArgs e)
        {
            if (option == 0)
            {
                InputOnhand inputOnhandForm = new InputOnhand();
                inputOnhandForm.parentForm1 = this.parentForm1;
                inputOnhandForm.parentForm2 = this;
                inputOnhandForm.parentForm3 = this.parentForm2;
                inputOnhandForm.ShowDialog();
            }
            else if (option == 1)
            {
                InputOnhand inputOnhandForm = new InputOnhand();
                inputOnhandForm.parentForm1 = this.parentForm1;
                inputOnhandForm.parentForm2 = this;
                inputOnhandForm.parentForm4 = this.parentForm3;
                inputOnhandForm.ShowDialog();
            }
            else if (option == 2)
            {
                InputOnhand inputOnhandForm = new InputOnhand();
                inputOnhandForm.parentForm1 = this.parentForm1;
                inputOnhandForm.parentForm2 = this;
                inputOnhandForm.parentForm5 = this.parentForm4;
                inputOnhandForm.ShowDialog();
            }
            else if (option == 3)
            {
                InputOnhand inputOnhandForm = new InputOnhand();
                inputOnhandForm.parentForm1 = this.parentForm1;
                inputOnhandForm.parentForm2 = this;
                inputOnhandForm.parentForm6 = this.parentForm5;
                inputOnhandForm.ShowDialog();
            }
        }

        private void btnShowSoldHistory_Click(object sender, EventArgs e)
        {
            MessageBox.Show("NOT AVAILABLE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        private void btnPromotionDetail_Click(object sender, EventArgs e)
        {
            MessageBox.Show("NOT AVAILABLE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            /*if (option == 0)
            {
                if (parentForm2.IsDisposed == false)
                    parentForm2.btnSearch_Click(null, null);

                this.Close();
            }
            else if (option == 1)
            {
                if (parentForm3.IsDisposed == false)
                {
                    //int temp = parentForm3.dataGridView1.SelectedRows[0].Index;
                    parentForm3.btnOK_Click(null, null);
                    //parentForm3.dataGridView1.Rows[0].Selected = false;
                    //parentForm3.dataGridView1.Rows[temp].Selected = true;
                    //parentForm3.dataGridView1.FirstDisplayedScrollingRowIndex = temp;
                }

                this.Close();
            }*/

            this.Close();
        }
    }
}