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
    public partial class PromotionMain : Form
    {
        //public SqlConnection conn = new SqlConnection("Server=KTSC-SERVER;Database=KTSC;UID=sa;Password=cherry");
        public LogInManagements parentForm;
        public Int64 promotionCode = 0;
        public string startDay;
        public string endDay;
        //int promotionItemCount = 0;

        string pmName, pmStartDate, pmEndDate;

        int selected = 0;
        public int selectedIndex = 0;
            
        //string pItmBrand, pItmName, pItmSize, pItmColor, pItmStyle, pItmUpc, pType, pStartDate, pEndDate;
        //float pOption;
        //double regularPrice, stylistPrice, salePrice;

        int index1, index2, index3;
        //int num1, num2;
        string sp;
        string ItmBrand, ItmColor, ItmSize, ItmName, ItmUpc;
        int brandBoolNum, sizeBoolNum, colorBoolNum, nameBoolNum, upcBoolNum, totalBoolNum;
        SqlCommand cmd_PromotionBody;
        SqlCommand cmd_ResetMixMatch;
        public DataTable dt = new DataTable();
        public DataTable PromotionTable = new DataTable();

        bool saveComplete = true;

        public PromotionMain()
        {
            InitializeComponent();

            /*PromotionTable.Columns.Add("Brand");
            PromotionTable.Columns.Add("Name");
            PromotionTable.Columns.Add("Size");
            PromotionTable.Columns.Add("Color");
            PromotionTable.Columns.Add("Style #");
            PromotionTable.Columns.Add("Regular Price");
            PromotionTable.Columns.Add("Stylist Price");
            PromotionTable.Columns.Add("Promotion Type");
            PromotionTable.Columns.Add("Promotion Option");
            PromotionTable.Columns.Add("Sale Price");
            PromotionTable.Columns.Add("UPC");
            PromotionTable.Columns.Add("Start Day");
            PromotionTable.Columns.Add("End Day");*/
        }

        public void PromotionMain_Load(object sender, EventArgs e)
        {
            this.Text = "PROMOTION MAIN - " + parentForm.employeeID + " LOGGED IN " + parentForm.storeName;

            SqlCommand cmd = new SqlCommand("Show_Promotion", parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            parentForm.conn.Open();
            adapter.Fill(dt);
            parentForm.conn.Close();

            dataGridView1.DataSource = dt;
            dataGridView1.RowTemplate.Height = 20;
            dataGridView1.Columns[0].HeaderText = "SEQ NO";
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "PROMOTION CODE";
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].HeaderText = "PROMOTION NAME";
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].HeaderText = "START DATE";
            dataGridView1.Columns[3].Width = 110;
            dataGridView1.Columns[4].HeaderText = "END DATE";
            dataGridView1.Columns[4].Width = 110;
            dataGridView1.Columns[5].HeaderText = "ACT";
            dataGridView1.Columns[5].Width = 45;

            if (dataGridView1.RowCount > 0)
                dataGridView1.Rows[selectedIndex].Selected = true;

            selectedIndex = 0;
        }

        private void btnCreateNewPM_Click(object sender, EventArgs e)
        {
            if (dataGridView3.RowCount > 0)
            {
                MessageBox.Show("UNLOAD THE PROMOTION", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                CreateNewPromotion createNewPromotionForm = new CreateNewPromotion();
                createNewPromotionForm.parentForm1 = this.parentForm;
                createNewPromotionForm.parentForm2 = this;
                createNewPromotionForm.ShowDialog();
            }
        }

        private void btnUnloadPM_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView3.DataSource = null;
            promotionCode = 0;
            startDay = string.Empty;
            endDay = string.Empty;

            dataGridView1.Enabled = true;
            cmbCategory1.SelectedIndex = 0;
            cmbCategory1.Enabled = false;
            cmbCategory2.DataSource = null;
            cmbCategory2.Enabled = false;
            cmbCategory3.DataSource = null;
            cmbCategory3.Enabled = false;
            cmbBrand.DataSource = null;
            btnBrand.Enabled = false;
            cmbBrand.Enabled = false;
            cmbSize.DataSource = null;
            btnSize.Enabled = false;
            cmbSize.Enabled = false;
            cmbColor.DataSource = null;
            btnColor.Enabled = false;
            cmbColor.Enabled = false;
            txtName.Clear();
            txtName.Enabled = false;
            txtUpc.Clear();
            txtUpc.Enabled = false;
            btnSearch.Enabled = false;
            btnReset.Enabled = false;
            txtFind.Enabled = false;
            btnFind.Enabled = false;

            btnLoadPM.Enabled = true;
            btnUnloadPM.Enabled = false;
            btnTransferPM.Enabled = false;

            lblTotalCount1.Text = "";
            lblTotalCount2.Text = "";

            PromotionTable.Clear();
        }

        private void btnLoadPM_Click(object sender, EventArgs e)
        {
            //dataGridView2.DataSource = null;
            dataGridView3.DataSource = null;
            promotionCode = 0;
            startDay = string.Empty;
            endDay = string.Empty;
            PromotionTable.Clear();

            selected = 0;

            if (dataGridView3.RowCount > 0)
            {
                MessageBox.Show("PROMOTION IS ALREADY LOADING", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dataGridView1.RowCount > 0)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Selected == true)
                    {
                        selected = 1;
                    }
                }
            }

            if (selected == 0)
                return;

            dataGridView1.Enabled = false;
            cmbCategory1.Enabled = true;
            cmbCategory2.Enabled = true;
            cmbCategory3.Enabled = true;
            btnBrand.Enabled = true;
            cmbBrand.Enabled = true;
            btnSize.Enabled = true;
            cmbSize.Enabled = true;
            btnColor.Enabled = true;
            cmbColor.Enabled = true;
            txtName.Enabled = true;
            txtUpc.Enabled = true;
            btnSearch.Enabled = true;
            btnReset.Enabled = true;
            txtFind.Enabled = true;
            btnFind.Enabled = true;

            btnLoadPM.Enabled = false;
            btnUnloadPM.Enabled = true;
            btnTransferPM.Enabled = true;

            promotionCode = Convert.ToInt64(dataGridView1.SelectedCells[1].Value);
            startDay = Convert.ToString(dataGridView1.SelectedCells[3].Value);
            endDay = Convert.ToString(dataGridView1.SelectedCells[4].Value);

            SqlCommand cmd = new SqlCommand("Get_Item_From_PromotionBody2", parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PromotionCode", SqlDbType.BigInt).Value = promotionCode;
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            PromotionTable.Clear();
            adapt.Fill(PromotionTable);
            parentForm.conn.Close();
            
            dataGridView3.DataSource = PromotionTable;

            dataGridView3.Columns[0].Visible = false;
            dataGridView3.Columns[1].HeaderText = "Brand";
            dataGridView3.Columns[1].Width = 140;
            dataGridView3.Columns[2].HeaderText = "Name";
            dataGridView3.Columns[2].Width = 260;
            dataGridView3.Columns[3].HeaderText = "Size";
            dataGridView3.Columns[3].Width = 80;
            dataGridView3.Columns[4].HeaderText = "Color";
            dataGridView3.Columns[4].Width = 80;
            dataGridView3.Columns[5].HeaderText = "Style #";
            dataGridView3.Columns[5].Width = 95;
            dataGridView3.Columns[6].HeaderText = "Regular Price";
            dataGridView3.Columns[6].DefaultCellStyle.Format = "c";
            dataGridView3.Columns[6].Width = 55;
            dataGridView3.Columns[7].HeaderText = "Stylist Price";
            dataGridView3.Columns[7].DefaultCellStyle.Format = "c";
            dataGridView3.Columns[7].Width = 55;
            dataGridView3.Columns[8].HeaderText = "M&M";
            dataGridView3.Columns[8].Width = 45;
            dataGridView3.Columns[9].HeaderText = "M&M Val";
            dataGridView3.Columns[9].Width = 45;
            dataGridView3.Columns[10].HeaderText = "M&M Qty";
            dataGridView3.Columns[10].Width = 45;
            dataGridView3.Columns[11].HeaderText = "Promotion Type";
            dataGridView3.Columns[11].Width = 60;
            dataGridView3.Columns[12].HeaderText = "Promotion Option";
            dataGridView3.Columns[12].Width = 60;
            dataGridView3.Columns[13].HeaderText = "Sale Price";
            dataGridView3.Columns[13].DefaultCellStyle.Format = "c";
            dataGridView3.Columns[13].Width = 55;
            dataGridView3.Columns[14].HeaderText = "UPC";
            dataGridView3.Columns[14].Width = 90;
            dataGridView3.Columns[15].HeaderText = "Start Date";
            dataGridView3.Columns[15].Width = 80;
            dataGridView3.Columns[16].HeaderText = "End Date";
            dataGridView3.Columns[16].Width = 80;

            lblTotalCount2.Text = Convert.ToString(dataGridView3.RowCount);

            SqlCommand cmd_CmbCategory1 = new SqlCommand("Get_Category_Group1", parentForm.conn);
            cmd_CmbCategory1.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter adapt2 = new SqlDataAdapter();
            adapt2.SelectCommand = cmd_CmbCategory1;

            parentForm.conn.Open();
            adapt2.Fill(ds);
            parentForm.conn.Close();

            cmbCategory1.DataSource = ds.Tables[0].DefaultView;
            cmbCategory1.ValueMember = "ItmGp_Desc";
            cmbCategory1.DisplayMember = "ItmGp_Desc";
        }

        private void btnDeletePM_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
                return;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Selected == true)
                    promotionCode = Convert.ToInt64(dataGridView1.Rows[i].Cells[1].Value);
            }

            if (promotionCode == 0)
            {
                MessageBox.Show("SELECT PROMOTION", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "DO YOU WANT TO DELETE SELETED PROMOTION?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
            {
                SqlCommand cmd_PmHeader = new SqlCommand("Delete_PromotionHeader", parentForm.conn);
                cmd_PmHeader.CommandType = CommandType.StoredProcedure;
                cmd_PmHeader.Parameters.Add("@PromotionCode", SqlDbType.BigInt).Value = promotionCode;

                parentForm.conn.Open();
                cmd_PmHeader.ExecuteNonQuery();
                parentForm.conn.Close();

                SqlCommand cmd_PmBody = new SqlCommand("Delete_PromotionBody", parentForm.conn);
                cmd_PmBody.CommandType = CommandType.StoredProcedure;
                cmd_PmBody.Parameters.Add("@PromotionCode", SqlDbType.BigInt).Value = promotionCode;

                parentForm.conn.Open();
                cmd_PmBody.ExecuteNonQuery();
                parentForm.conn.Close();

                SqlCommand cmd = new SqlCommand("Show_Promotion", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                parentForm.conn.Open();
                adapter.Fill(dt);
                parentForm.conn.Close();

                dataGridView1.DataSource = dt;
                dataGridView1.RowTemplate.Height = 20;
                dataGridView1.Columns[0].HeaderText = "SEQ NO";
                dataGridView1.Columns[0].Width = 80;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "PROMOTION CODE";
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].HeaderText = "PROMOTION NAME";
                dataGridView1.Columns[2].Width = 200;
                dataGridView1.Columns[3].HeaderText = "START DATE";
                dataGridView1.Columns[3].Width = 110;
                dataGridView1.Columns[4].HeaderText = "END DATE";
                dataGridView1.Columns[4].Width = 110;
                dataGridView1.Columns[5].HeaderText = "ACT";
                dataGridView1.Columns[5].Width = 45;

                if (dataGridView1.RowCount > 0)
                    dataGridView1.Rows[0].Selected = false;

                promotionCode = 0;
                dataGridView3.DataSource = null;
                btnLoadPM.Enabled = true;
                btnUnloadPM.Enabled = false;

                if (dataGridView1.Enabled == false)
                    dataGridView1.Enabled = true;
            }
        }

        private void btnEditPM_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Selected == true)
                {
                    promotionCode = Convert.ToInt64(dataGridView1.Rows[i].Cells[1].Value);
                    pmName = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
                    pmStartDate = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value);
                    pmEndDate = Convert.ToString(dataGridView1.Rows[i].Cells[4].Value);

                    selectedIndex = i;
                }

            }

            if (promotionCode == 0)
                return;

            EditPromotion editPromotionForm = new EditPromotion(promotionCode, pmName, pmStartDate, pmEndDate);
            editPromotionForm.parentForm1 = this.parentForm;
            editPromotionForm.parentForm2 = this;
            editPromotionForm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbCategory1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory1.SelectedIndex == 0 | cmbCategory1.SelectedIndex > 6)
            {
                cmbCategory2.DataSource = null;
                cmbCategory2.Items.Clear();
                cmbCategory3.DataSource = null;
                cmbCategory3.Items.Clear();
                return;
            }

            SqlCommand cmd_CmbCategory2 = new SqlCommand("Get_Category_Group2", parentForm.conn);
            cmd_CmbCategory2.CommandType = CommandType.StoredProcedure;
            cmd_CmbCategory2.Parameters.Add("@ItmGp_Parents", SqlDbType.Int).Value = cmbCategory1.SelectedIndex;
            DataSet ds = new DataSet();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd_CmbCategory2;

            parentForm.conn.Open();
            adapt.Fill(ds);
            parentForm.conn.Close();

            cmbCategory2.DataSource = ds.Tables[0].DefaultView;
            cmbCategory2.ValueMember = "ItmGp_Desc";
            cmbCategory2.DisplayMember = "ItmGp_Desc";

            ds.Tables.Clear();
        }

        private void cmbCategory2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCategory3.DataSource = null;
            cmbCategory3.Items.Clear();

            index1 = cmbCategory1.SelectedIndex;
            index2 = cmbCategory2.SelectedIndex;

            SqlCommand cmd_CmbCategory3 = new SqlCommand("Get_Category_Group3", parentForm.conn);
            cmd_CmbCategory3.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter adapt = new SqlDataAdapter();

            switch (index1)
            {
                case 6:
                    cmd_CmbCategory3.Parameters.Add("@ItmGp_Parents", SqlDbType.Int).Value = index1 + 1;
                    cmd_CmbCategory3.Parameters.Add("@ItmGp_Parents2", SqlDbType.Int).Value = index2;
                    adapt.SelectCommand = cmd_CmbCategory3;

                    parentForm.conn.Open();
                    adapt.Fill(ds);
                    parentForm.conn.Close();

                    cmbCategory3.DataSource = ds.Tables[0].DefaultView;
                    cmbCategory3.ValueMember = "ItmGp_Desc";
                    cmbCategory3.DisplayMember = "ItmGp_Desc";
                    break;
                default:
                    cmd_CmbCategory3.Parameters.Add("@ItmGp_Parents", SqlDbType.Int).Value = index1;
                    cmd_CmbCategory3.Parameters.Add("@ItmGp_Parents2", SqlDbType.Int).Value = index2;
                    adapt.SelectCommand = cmd_CmbCategory3;

                    parentForm.conn.Open();
                    adapt.Fill(ds);
                    parentForm.conn.Close();

                    cmbCategory3.DataSource = ds.Tables[0].DefaultView;
                    cmbCategory3.ValueMember = "ItmGp_Desc";
                    cmbCategory3.DisplayMember = "ItmGp_Desc";
                    break;
            }
        }

        private void btnBrand_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Get_BrandName", parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            adapt.Fill(ds);
            parentForm.conn.Close();

            cmbBrand.DataSource = ds.Tables[0].DefaultView;
            cmbBrand.ValueMember = "BrandName";
            cmbBrand.DisplayMember = "BrandName";
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Get_ColorName", parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            adapt.Fill(ds);
            parentForm.conn.Close();

            cmbColor.DataSource = ds.Tables[0].DefaultView;
            cmbColor.ValueMember = "ColorName";
            cmbColor.DisplayMember = "ColorName";
        }

        private void btnSize_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Get_SizeName", parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            adapt.Fill(ds);
            parentForm.conn.Close();

            cmbSize.DataSource = ds.Tables[0].DefaultView;
            cmbSize.ValueMember = "SizeName";
            cmbSize.DisplayMember = "SizeName";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            brandBoolNum = 0; sizeBoolNum = 0; colorBoolNum = 0; nameBoolNum = 0; upcBoolNum = 0; totalBoolNum = 0;

            if (cmbBrand.Text == "")
            {
                brandBoolNum = 0;
                ItmBrand = "1";
            }
            else
            {
                brandBoolNum = 16;
                ItmBrand = cmbBrand.Text.ToUpper();
            }

            if (cmbSize.Text == "")
            {
                sizeBoolNum = 0;
                ItmSize = "1";
            }
            else
            {
                sizeBoolNum = 8;
                ItmSize = cmbSize.Text.ToUpper();
            }

            if (cmbColor.Text == "")
            {
                colorBoolNum = 0;
                ItmColor = "1";
            }
            else
            {
                colorBoolNum = 4;
                ItmColor = cmbColor.Text.ToUpper();
            }

            if (txtName.Text == "")
            {
                nameBoolNum = 0;
                ItmName = "1";
            }
            else
            {
                nameBoolNum = 2;
                ItmName = txtName.Text.ToUpper();
            }

            if (txtUpc.Text == "")
            {
                upcBoolNum = 0;
                ItmUpc = "1";
            }
            else
            {
                upcBoolNum = 1;
                ItmUpc = txtUpc.Text.ToUpper();
            }

            totalBoolNum = brandBoolNum + sizeBoolNum + colorBoolNum + nameBoolNum + upcBoolNum;
            //sp = "Show_All";
            //dataGridView2.DataSource = DataBind(sp);

            if (cmbCategory1.SelectedIndex == 0)
            {
                //sp = "Show_With_Conditions";
                sp = "Show_With_Conditions_To_Promotion";
                dataGridView2.DataSource = DataBind(totalBoolNum, sp, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);

                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[1].HeaderText = "Brand";
                dataGridView2.Columns[1].Width = 140;
                dataGridView2.Columns[2].HeaderText = "Name";
                dataGridView2.Columns[2].Width = 260;
                dataGridView2.Columns[3].HeaderText = "Size";
                dataGridView2.Columns[3].Width = 80;
                dataGridView2.Columns[4].HeaderText = "Color";
                dataGridView2.Columns[4].Width = 80;
                dataGridView2.Columns[5].HeaderText = "Style #";
                dataGridView2.Columns[5].Width = 95;
                dataGridView2.Columns[6].Visible = false;
                dataGridView2.Columns[7].HeaderText = "Regular Price";
                dataGridView2.Columns[7].DefaultCellStyle.Format = "c";
                dataGridView2.Columns[7].Width = 55;
                dataGridView2.Columns[8].HeaderText = "Stylist Price";
                dataGridView2.Columns[8].DefaultCellStyle.Format = "c";
                dataGridView2.Columns[8].Width = 55;
                dataGridView2.Columns[9].HeaderText = "Sale Price";
                dataGridView2.Columns[9].DefaultCellStyle.Format = "c";
                dataGridView2.Columns[9].Width = 55;
                dataGridView2.Columns[10].HeaderText = "UPC";
                dataGridView2.Columns[10].Width = 90;
                dataGridView2.Columns[11].Visible = false;
                dataGridView2.Columns[12].Visible = false;
                dataGridView2.Columns[13].Visible = false;
            }
            else
            {
                if (cmbCategory2.SelectedIndex > 0)
                {
                    if (cmbCategory3.SelectedIndex >= 0)
                    {
                        if (cmbCategory1.SelectedIndex > 5)
                        {
                            index1 = cmbCategory1.SelectedIndex + 1;
                        }
                        else
                        {
                            index1 = cmbCategory1.SelectedIndex;
                        }
                        index2 = cmbCategory2.SelectedIndex;
                        index3 = cmbCategory3.SelectedIndex + 1;
                        //sp = "Show_Category_1_2_3_With_Conditions";
                        sp = "Show_Category_1_2_3_With_Conditions_To_Promotion";
                        dataGridView2.DataSource = DataBind(totalBoolNum, sp, index1, index2, index3, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);

                        dataGridView2.Columns[0].Visible = false;
                        dataGridView2.Columns[1].HeaderText = "Brand";
                        dataGridView2.Columns[1].Width = 140;
                        dataGridView2.Columns[2].HeaderText = "Name";
                        dataGridView2.Columns[2].Width = 260;
                        dataGridView2.Columns[3].HeaderText = "Size";
                        dataGridView2.Columns[3].Width = 80;
                        dataGridView2.Columns[4].HeaderText = "Color";
                        dataGridView2.Columns[4].Width = 80;
                        dataGridView2.Columns[5].HeaderText = "Style #";
                        dataGridView2.Columns[5].Width = 95;
                        dataGridView2.Columns[6].Visible = false;
                        dataGridView2.Columns[7].HeaderText = "Regular Price";
                        dataGridView2.Columns[7].DefaultCellStyle.Format = "c";
                        dataGridView2.Columns[7].Width = 55;
                        dataGridView2.Columns[8].HeaderText = "Stylist Price";
                        dataGridView2.Columns[8].DefaultCellStyle.Format = "c";
                        dataGridView2.Columns[8].Width = 55;
                        dataGridView2.Columns[9].HeaderText = "Sale Price";
                        dataGridView2.Columns[9].DefaultCellStyle.Format = "c";
                        dataGridView2.Columns[9].Width = 55;
                        dataGridView2.Columns[10].HeaderText = "UPC";
                        dataGridView2.Columns[10].Width = 90;
                        dataGridView2.Columns[11].Visible = false;
                        dataGridView2.Columns[12].Visible = false;
                        dataGridView2.Columns[13].Visible = false;
                    }
                    else
                    {
                        if (cmbCategory1.SelectedIndex > 5)
                        {
                            index1 = cmbCategory1.SelectedIndex + 1;
                        }
                        else
                        {
                            index1 = cmbCategory1.SelectedIndex;
                        }
                        index2 = cmbCategory2.SelectedIndex;
                        //sp = "Show_Category_1_2_With_Conditions";
                        sp = "Show_Category_1_2_With_Conditions_To_Promotion";
                        dataGridView2.DataSource = DataBind(totalBoolNum, sp, index1, index2, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);

                        dataGridView2.Columns[0].Visible = false;
                        dataGridView2.Columns[1].HeaderText = "Brand";
                        dataGridView2.Columns[1].Width = 140;
                        dataGridView2.Columns[2].HeaderText = "Name";
                        dataGridView2.Columns[2].Width = 260;
                        dataGridView2.Columns[3].HeaderText = "Size";
                        dataGridView2.Columns[3].Width = 80;
                        dataGridView2.Columns[4].HeaderText = "Color";
                        dataGridView2.Columns[4].Width = 80;
                        dataGridView2.Columns[5].HeaderText = "Style #";
                        dataGridView2.Columns[5].Width = 95;
                        dataGridView2.Columns[6].Visible = false;
                        dataGridView2.Columns[7].HeaderText = "Regular Price";
                        dataGridView2.Columns[7].DefaultCellStyle.Format = "c";
                        dataGridView2.Columns[7].Width = 55;
                        dataGridView2.Columns[8].HeaderText = "Stylist Price";
                        dataGridView2.Columns[8].DefaultCellStyle.Format = "c";
                        dataGridView2.Columns[8].Width = 55;
                        dataGridView2.Columns[9].HeaderText = "Sale Price";
                        dataGridView2.Columns[9].DefaultCellStyle.Format = "c";
                        dataGridView2.Columns[9].Width = 55;
                        dataGridView2.Columns[10].HeaderText = "UPC";
                        dataGridView2.Columns[10].Width = 90;
                        dataGridView2.Columns[11].Visible = false;
                        dataGridView2.Columns[12].Visible = false;
                        dataGridView2.Columns[13].Visible = false;
                    }
                }
                else
                {
                    if (cmbCategory1.SelectedIndex > 5)
                    {
                        index1 = cmbCategory1.SelectedIndex + 1;
                    }
                    else
                    {
                        index1 = cmbCategory1.SelectedIndex;
                    }
                    //sp = "Show_Category_1_With_Conditions";
                    sp = "Show_Category_1_With_Conditions_To_Promotion";
                    dataGridView2.DataSource = DataBind(totalBoolNum, sp, index1, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);

                    dataGridView2.Columns[0].Visible = false;
                    dataGridView2.Columns[1].HeaderText = "Brand";
                    dataGridView2.Columns[1].Width = 140;
                    dataGridView2.Columns[2].HeaderText = "Name";
                    dataGridView2.Columns[2].Width = 260;
                    dataGridView2.Columns[3].HeaderText = "Size";
                    dataGridView2.Columns[3].Width = 80;
                    dataGridView2.Columns[4].HeaderText = "Color";
                    dataGridView2.Columns[4].Width = 80;
                    dataGridView2.Columns[5].HeaderText = "Style #";
                    dataGridView2.Columns[5].Width = 95;
                    dataGridView2.Columns[6].Visible = false;
                    dataGridView2.Columns[7].HeaderText = "Regular Price";
                    dataGridView2.Columns[7].DefaultCellStyle.Format = "c";
                    dataGridView2.Columns[7].Width = 55;
                    dataGridView2.Columns[8].HeaderText = "Stylist Price";
                    dataGridView2.Columns[8].DefaultCellStyle.Format = "c";
                    dataGridView2.Columns[8].Width = 55;
                    dataGridView2.Columns[9].HeaderText = "Sale Price";
                    dataGridView2.Columns[9].DefaultCellStyle.Format = "c";
                    dataGridView2.Columns[9].Width = 55;
                    dataGridView2.Columns[10].HeaderText = "UPC";
                    dataGridView2.Columns[10].Width = 90;
                    dataGridView2.Columns[11].Visible = false;
                    dataGridView2.Columns[12].Visible = false;
                    dataGridView2.Columns[13].Visible = false;
                }
            }

            //dataGridView2.Rows[0].Selected = false;
            lblTotalCount1.Text = Convert.ToString(dataGridView2.RowCount);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            cmbCategory2.DataSource = null;
            cmbCategory2.Items.Clear();
            cmbCategory3.DataSource = null;
            cmbCategory3.Items.Clear();
            cmbBrand.DataSource = null;
            cmbBrand.Items.Clear();
            cmbColor.DataSource = null;
            cmbColor.Items.Clear();
            cmbSize.DataSource = null;
            cmbSize.Items.Clear();

            txtName.Clear();
            txtUpc.Clear();

            SqlCommand cmd_CmbCategory1 = new SqlCommand("Get_Category_Group1", parentForm.conn);
            cmd_CmbCategory1.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd_CmbCategory1;

            parentForm.conn.Open();
            adapt.Fill(ds);
            parentForm.conn.Close();

            cmbCategory1.DataSource = ds.Tables[0].DefaultView;
            cmbCategory1.ValueMember = "ItmGp_Desc";
            cmbCategory1.DisplayMember = "ItmGp_Desc";

            lblTotalCount1.Text = "";
        }

        public void btnPromotionAdd_Click(object sender, EventArgs e)
        {
            if (dataGridView2.RowCount > 0)
            {
                PromotionOprions promotionOptionsForm = new PromotionOprions();
                promotionOptionsForm.parentForm = this;
                promotionOptionsForm.ShowDialog();
            }
            else
            {
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            /*if (dataGridView3.SelectedRows.Count > 0)
            {

                PromotionTable.Rows[dataGridView3.SelectedRows[0].Index].Delete();
            }

            dataGridView3.DataSource = PromotionTable;*/

            /*for (int i = 0; i < dataGridView3.RowCount; i++)
            {
                if (dataGridView3.Rows[i].Selected == true)
                {
                    PromotionTable.Rows[dataGridView3.Rows[i].Index].Delete();
                }
            }*/

            //dataGridView3.DataSource = PromotionTable;

            if (dataGridView3.RowCount == 0)
                return;

            foreach (DataGridViewRow row in dataGridView3.SelectedRows)
            {
                dataGridView3.Rows.Remove(row);
            }

            lblTotalCount2.Text = Convert.ToString(dataGridView3.RowCount);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (promotionCode == 0)
                return;

            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
            {
                promotionCode = Convert.ToInt64(dataGridView1.SelectedCells[1].Value);
                startDay = Convert.ToString(dataGridView1.SelectedCells[3].Value);
                endDay = Convert.ToString(dataGridView1.SelectedCells[4].Value);

                try
                {
                    cmd_ResetMixMatch = new SqlCommand("Reset_MixMatch", parentForm.conn);
                    cmd_ResetMixMatch.CommandType = CommandType.StoredProcedure;
                    cmd_ResetMixMatch.Parameters.Clear();
                    cmd_ResetMixMatch.Parameters.Add("@PromotionCode", SqlDbType.BigInt).Value = promotionCode;

                    SqlCommand cmd_Previous_PromotionBody = new SqlCommand("Delete_PromotionBody", parentForm.conn);
                    cmd_Previous_PromotionBody.Parameters.Clear();
                    cmd_Previous_PromotionBody.CommandType = CommandType.StoredProcedure;
                    cmd_Previous_PromotionBody.Parameters.Add("@PromotionCode", SqlDbType.BigInt).Value = promotionCode;

                    //SqlCommand cmd_ResetPrice = new SqlCommand("Reset_All_SalePrice", conn);
                    //cmd_ResetPrice.Parameters.Add("@PromotionCode", SqlDbType.BigInt).Value = promotionCode;
                    //cmd_ResetPrice.CommandType = CommandType.StoredProcedure;

                    parentForm.conn.Open();
                    //cmd_ResetPrice.ExecuteNonQuery();
                    cmd_ResetMixMatch.ExecuteNonQuery();
                    cmd_Previous_PromotionBody.ExecuteNonQuery();
                    parentForm.conn.Close();

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dataGridView3.RowCount;
                    progressBar1.Step = 1;
                    progressBar1.Visible = true;

                    backgroundWorker1.RunWorkerAsync();
                }
                catch
                {
                    MessageBox.Show("UNHANDLED ERROR (ASK DEVELOPER)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parentForm.conn.Close();
                    return;
                }
            }
        }

        public DataTable DataBind(string sp)
        {
            SqlCommand cmd = new SqlCommand(sp, parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            adapt.Fill(dt);
            parentForm.conn.Close();

            return dt;
        }

        public DataTable DataBind(int totalBoolNum, string sp, string ItmBrand, string ItmSize, string ItmColor, string ItmName, string ItmUpc)
        {
            SqlCommand cmd = new SqlCommand(sp, parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
            cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
            cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
            cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
            dt.Clear();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            adapt.Fill(dt);
            parentForm.conn.Close();

            return dt;
        }

        public DataTable DataBind(int totalBoolNum, string sp, int index1, string ItmBrand, string ItmSize, string ItmColor, string ItmName, string ItmUpc)
        {
            SqlCommand cmd = new SqlCommand(sp, parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
            cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
            cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
            cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
            cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
            //DataTable dt = new DataTable();
            dt.Clear();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            adapt.Fill(dt);
            parentForm.conn.Close();

            return dt;
        }

        public DataTable DataBind(int totalBoolNum, string sp, int index1, int index2, string ItmBrand, string ItmSize, string ItmColor, string ItmName, string ItmUpc)
        {
            SqlCommand cmd = new SqlCommand(sp, parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
            cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
            cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = index2;
            cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
            cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
            cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
            //DataTable dt = new DataTable();
            dt.Clear();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            adapt.Fill(dt);
            parentForm.conn.Close();

            return dt;
        }

        public DataTable DataBind(int totalBoolNum, string sp, int index1, int index2, int index3, string ItmBrand, string ItmSize, string ItmColor, string ItmName, string ItmUpc)
        {
            SqlCommand cmd = new SqlCommand(sp, parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
            cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
            cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = index2;
            cmd.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = index3;
            cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
            cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
            cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
            //DataTable dt = new DataTable();
            dt.Clear();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            adapt.Fill(dt);
            parentForm.conn.Close();

            return dt;
        }

        private void btnSelectAll1_Click(object sender, EventArgs e)
        {
            if (dataGridView2.RowCount > 0)
            {
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    dataGridView2.Rows[i].Selected = true;
                }
            }
        }

        private void btnSelectAll2_Click(object sender, EventArgs e)
        {
            if (dataGridView3.RowCount > 0)
            {
                for (int i = 0; i < dataGridView3.RowCount; i++)
                {
                    dataGridView3.Rows[i].Selected = true;
                }
            }
        }

        private void btnTransferPM_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Selected == true)
                {
                    promotionCode = Convert.ToInt64(dataGridView1.Rows[i].Cells[1].Value);
                    pmName = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
                    pmStartDate = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value);
                    pmEndDate = Convert.ToString(dataGridView1.Rows[i].Cells[4].Value);
                }
            }

            if (promotionCode == 0)
                return;

            PromotionTransfer promotionTransferForm = new PromotionTransfer(promotionCode, pmName, pmStartDate, pmEndDate);
            promotionTransferForm.parentForm1 = this.parentForm;
            promotionTransferForm.parentForm2 = this;
            promotionTransferForm.ShowDialog();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                cmd_PromotionBody = new SqlCommand("Create_PromotionBody", parentForm.conn);

                for (int i = 0; i < dataGridView3.RowCount; i++)
                {
                    cmd_PromotionBody.CommandType = CommandType.StoredProcedure;
                    cmd_PromotionBody.Parameters.Clear();
                    cmd_PromotionBody.Parameters.Add("@PromotionCode", SqlDbType.BigInt).Value = promotionCode;
                    cmd_PromotionBody.Parameters.Add("@PromotionItemIndex", SqlDbType.Int).Value = i + 1;
                    cmd_PromotionBody.Parameters.Add("@PromotionItemCode", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView3.Rows[i].Cells[0].Value);
                    cmd_PromotionBody.Parameters.Add("@PromotionItemBrand", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView3.Rows[i].Cells[1].Value);
                    cmd_PromotionBody.Parameters.Add("@PromotionItemName", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView3.Rows[i].Cells[2].Value);
                    cmd_PromotionBody.Parameters.Add("@PromotionItemSize", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView3.Rows[i].Cells[3].Value);
                    cmd_PromotionBody.Parameters.Add("@PromotionItemColor", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView3.Rows[i].Cells[4].Value);
                    cmd_PromotionBody.Parameters.Add("@PromotionItemStyle", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView3.Rows[i].Cells[5].Value);
                    cmd_PromotionBody.Parameters.Add("@RegularPrice", SqlDbType.Money).Value = Convert.ToDouble(dataGridView3.Rows[i].Cells[6].Value);
                    cmd_PromotionBody.Parameters.Add("@StylistPrice", SqlDbType.Money).Value = Convert.ToDouble(dataGridView3.Rows[i].Cells[7].Value);
                    cmd_PromotionBody.Parameters.Add("@PromotionMixMatch", SqlDbType.Bit).Value = Convert.ToBoolean(dataGridView3.Rows[i].Cells[8].Value);
                    cmd_PromotionBody.Parameters.Add("@PromotionMixMatchVal", SqlDbType.Int).Value = Convert.ToInt16(dataGridView3.Rows[i].Cells[9].Value);
                    cmd_PromotionBody.Parameters.Add("@PromotionMixMatchQty", SqlDbType.Int).Value = Convert.ToInt16(dataGridView3.Rows[i].Cells[10].Value);
                    cmd_PromotionBody.Parameters.Add("@PromotionType", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView3.Rows[i].Cells[11].Value);
                    cmd_PromotionBody.Parameters.Add("@PromotionOption", SqlDbType.Float).Value = Convert.ToString(dataGridView3.Rows[i].Cells[12].Value);
                    cmd_PromotionBody.Parameters.Add("@SalePrice", SqlDbType.Money).Value = Convert.ToDouble(dataGridView3.Rows[i].Cells[13].Value);
                    cmd_PromotionBody.Parameters.Add("@PromotionItemUpc", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView3.Rows[i].Cells[14].Value);
                    cmd_PromotionBody.Parameters.Add("@PromotionStartDate", SqlDbType.NVarChar).Value = startDay;
                    cmd_PromotionBody.Parameters.Add("@PromotionEndDate", SqlDbType.NVarChar).Value = endDay;

                    //SqlCommand cmd_UpdatePrice = new SqlCommand("Update_SalePrice", conn);
                    //cmd_UpdatePrice.CommandType = CommandType.StoredProcedure;
                    //cmd_UpdatePrice.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView3.Rows[i].Cells[1].Value);
                    //cmd_UpdatePrice.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView3.Rows[i].Cells[2].Value);
                    //cmd_UpdatePrice.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView3.Rows[i].Cells[3].Value);
                    //cmd_UpdatePrice.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView3.Rows[i].Cells[10].Value);
                    //cmd_UpdatePrice.Parameters.Add("@SalePrice", SqlDbType.Money).Value = Convert.ToDouble(dataGridView3.Rows[i].Cells[9].Value);

                    parentForm.conn.Open();
                    cmd_PromotionBody.ExecuteNonQuery();
                    //cmd_UpdatePrice.ExecuteNonQuery();
                    parentForm.conn.Close();

                    backgroundWorker1.ReportProgress(i + 1);
                }
            }
            catch
            {
                MessageBox.Show("CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                parentForm.conn.Close();
                return;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (saveComplete == true)
            {
                MessageBox.Show("SUCCESSFULLY SAVED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnLoadPM_Click(null, null);
                lblTotalCount2.Text = Convert.ToString(dataGridView3.RowCount);

                progressBar1.Visible = false;
                progressBar1.Value = 0;
            }
            else
            {
                MessageBox.Show("SAVE FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnLoadPM_Click(null, null);
                lblTotalCount2.Text = Convert.ToString(dataGridView3.RowCount);

                progressBar1.Visible = false;
                progressBar1.Value = 0;
                saveComplete = true;
            }
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView2.RowCount > 0)
                btnPromotionAdd_Click(null, null);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (dataGridView3.RowCount > 0)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < 17; j++)
                    {
                        if (dataGridView3.Rows[i].Cells[j].Value.ToString() == txtFind.Text.ToUpper().ToString().Trim())
                        {
                            dataGridView3.Rows[i].Selected = true;
                            dataGridView3.FirstDisplayedScrollingRowIndex = i;
                            return;
                        }
                        else
                        {
                            dataGridView3.Rows[i].Selected = false;
                        }
                    }
                }
            }
        }

        private void btnUnloadPM_EnabledChanged(object sender, EventArgs e)
        {
            if (btnUnloadPM.Enabled == true)
            {
                txtFind.Enabled = true;
                btnFind.Enabled = true;
            }
            else
            {
                txtFind.Enabled = false;
                btnFind.Enabled = false;
            }
        }
    }
}