using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Office_12 = Microsoft.Office.Core;
using Excel_12 = Microsoft.Office.Interop.Excel;

namespace Management
{
    public partial class EditCostPrice : Form
    {
        public LogInManagements parentForm;
        public Font drvFont = new Font("Arial", 9);

        int index1, index2, index3;
        string sp;
        string ItmBrand, ItmColor, ItmSize, ItmName, ItmUpc;
        bool ItmTF;
        int brandBoolNum, sizeBoolNum, colorBoolNum, nameBoolNum, upcBoolNum, totalBoolNum;
        public DataTable dt = new DataTable();
        SqlDataAdapter adapt = new SqlDataAdapter();
        SqlCommand cmd;

        Int64 totalOnhand = 0;
        double totalValueOfProduct = 0;

        public EditCostPrice()
        {
            InitializeComponent();
        }

        private void EditCostPrice_Load(object sender, EventArgs e)
        {
            //if (parentForm.userLevel >= parentForm.SectionManagerLV)
            if (parentForm.userLevel >= parentForm.GeneralManagerLV)
            {
                btnUpdate.Enabled = true;
                btnTargetField.Enabled = true;
                dataGridView1.ReadOnly = false;
            }

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

            lblTotalCount1.Text = "0";

            if (parentForm.StoreCode == "B4UHQ")
            {
                this.MaximizeBox = true;
            }
            else
            {
                this.MaximizeBox = false;
            }
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
            cmd = new SqlCommand("Get_BrandName", parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
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
            cmd = new SqlCommand("Get_ColorName", parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
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
            cmd = new SqlCommand("Get_SizeName", parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
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
            btnSearch.Enabled = false;

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

            if (rdoBtnAll.Checked == true)
            {
                if (cmbCategory1.SelectedIndex == 0)
                {
                    sp = "Show_With_Conditions_From_Inventory";
                    DataBind(totalBoolNum, sp, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);
                    BindDataGridView();
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
                            sp = "Show_Category_1_2_3_With_Conditions_From_Inventory";
                            DataBind(totalBoolNum, sp, index1, index2, index3, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);
                            BindDataGridView();
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
                            sp = "Show_Category_1_2_With_Conditions_From_Inventory";
                            DataBind(totalBoolNum, sp, index1, index2, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);
                            BindDataGridView();
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
                        sp = "Show_Category_1_With_Conditions_From_Inventory";
                        DataBind(totalBoolNum, sp, index1, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);
                        BindDataGridView();
                    }
                }
            }
            else
            {
                if (rdoBtnTrue.Checked == true)
                {
                    ItmTF = true;
                }
                else if (rdoBtnFalse.Checked == true)
                {
                    ItmTF = false;
                }

                if (cmbCategory1.SelectedIndex == 0)
                {
                    sp = "Show_With_Conditions_From_Inventory_TF";
                    DataBind(totalBoolNum, sp, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc, ItmTF);
                    BindDataGridView();
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
                            sp = "Show_Category_1_2_3_With_Conditions_From_Inventory_TF";
                            DataBind(totalBoolNum, sp, index1, index2, index3, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc, ItmTF);
                            BindDataGridView();
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
                            sp = "Show_Category_1_2_With_Conditions_From_Inventory_TF";
                            DataBind(totalBoolNum, sp, index1, index2, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc, ItmTF);
                            BindDataGridView();
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
                        sp = "Show_Category_1_With_Conditions_From_Inventory_TF";
                        DataBind(totalBoolNum, sp, index1, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc, ItmTF);
                        BindDataGridView();
                    }
                }
            }

            if (parentForm.StoreCode == "B4UHQ")
            {
                totalOnhand = 0;
                totalValueOfProduct = 0;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (Convert.ToInt64(dataGridView1.Rows[i].Cells[15].Value) > 0)
                    {
                        totalOnhand = totalOnhand + Convert.ToInt64(dataGridView1.Rows[i].Cells[15].Value);
                        totalValueOfProduct = totalValueOfProduct + (Convert.ToInt64(dataGridView1.Rows[i].Cells[15].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[17].Value));
                    }
                }

                //dataGridView2.Rows[0].Selected = false;
                lblTotalOnhand.Text = Convert.ToString(totalOnhand);
                lblTotalValueOfProduct.Text = string.Format("{0:c}", totalValueOfProduct);
                lblTotalCount1.Text = Convert.ToString(dataGridView1.RowCount);

                btnSearch.Enabled = true;

                txtUpc.SelectAll();
                txtUpc.Focus();
            }
            else
            {
                totalOnhand = 0;
                totalValueOfProduct = 0;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (Convert.ToInt64(dataGridView1.Rows[i].Cells[14].Value) > 0)
                    {
                        totalOnhand = totalOnhand + Convert.ToInt64(dataGridView1.Rows[i].Cells[14].Value);
                        totalValueOfProduct = totalValueOfProduct + (Convert.ToInt64(dataGridView1.Rows[i].Cells[14].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[16].Value));
                    }
                }

                //dataGridView2.Rows[0].Selected = false;
                lblTotalOnhand.Text = Convert.ToString(totalOnhand);
                lblTotalValueOfProduct.Text = string.Format("{0:c}", totalValueOfProduct);
                lblTotalCount1.Text = Convert.ToString(dataGridView1.RowCount);

                btnSearch.Enabled = true;

                txtUpc.SelectAll();
                txtUpc.Focus();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
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

            lblTotalCount1.Text = "0";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;

            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?\n\n" + "(ATTENTION! ONLY COST PRICE WILL BE UPDATED)", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                btnUpdate.Enabled = true;
            }

        }

        private void btnTargetField_Click(object sender, EventArgs e)
        {
            TargetField targetFieldForm = new TargetField(1);
            targetFieldForm.parentForm1 = this.parentForm;
            targetFieldForm.parentForm3 = this;
            targetFieldForm.ShowDialog();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (parentForm.employeeID.ToUpper() == "ADMIN" | parentForm.specialCode == parentForm.txtSpecialCode.Text.Trim().ToString().ToUpper())
            {
                if (dataGridView1.RowCount > 0)
                {
                    this.Enabled = false;

                    Excel_12.Application ReportFile;
                    Excel_12._Workbook WorkBook;
                    Excel_12._Worksheet WorkSheet;
                    //Excel_12.Range Range;

                    string MaxRow = Convert.ToString(dt.Rows.Count + 1);
                    String MaxColumn = ((String)(Convert.ToChar(dt.Columns.Count / 26 + 64).ToString() + Convert.ToChar(dt.Columns.Count % 26 + 64))).Replace('@', ' ').Trim();
                    String MaxCell = MaxColumn + MaxRow;

                    ReportFile = new Excel_12.Application();
                    ReportFile.Visible = false;

                    WorkBook = (Excel_12._Workbook)(ReportFile.Workbooks.Add("workbook"));
                    WorkSheet = (Excel_12._Worksheet)WorkBook.ActiveSheet;

                    for (int i = 0; i < dt.Columns.Count; i++)
                        WorkSheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;

                    string[,] Values = new string[dt.Rows.Count, dt.Columns.Count];

                    for (int i = 0; i < dt.Rows.Count; i++)
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {

                            Values[i, j] = dt.Rows[i][j].ToString();

                        }

                    WorkSheet.get_Range("A2", MaxCell).Value2 = Values;
                    ReportFile.Visible = true;
                    ReportFile.UserControl = true;

                    this.Enabled = true;
                }
                else
                {
                    MessageBox.Show("NO DATA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
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
        }

        public void DataBind(int totalBoolNum, string sp, string ItmBrand, string ItmSize, string ItmColor, string ItmName, string ItmUpc)
        {
            cmd = new SqlCommand(sp, parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
            cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
            cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
            cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = ItmName + "%";
            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
            dt.Clear();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            adapt.Fill(dt);
            parentForm.conn.Close();
        }

        public void DataBind(int totalBoolNum, string sp, int index1, string ItmBrand, string ItmSize, string ItmColor, string ItmName, string ItmUpc)
        {
            cmd = new SqlCommand(sp, parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
            cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
            cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
            cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
            cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = ItmName + "%";
            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
            dt.Clear();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            adapt.Fill(dt);
            parentForm.conn.Close();
        }

        public void DataBind(int totalBoolNum, string sp, int index1, int index2, string ItmBrand, string ItmSize, string ItmColor, string ItmName, string ItmUpc)
        {
            cmd = new SqlCommand(sp, parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
            cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
            cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = index2;
            cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
            cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
            cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = ItmName + "%";
            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
            dt.Clear();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            adapt.Fill(dt);
            parentForm.conn.Close();
        }

        public void DataBind(int totalBoolNum, string sp, int index1, int index2, int index3, string ItmBrand, string ItmSize, string ItmColor, string ItmName, string ItmUpc)
        {
            cmd = new SqlCommand(sp, parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
            cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
            cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = index2;
            cmd.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = index3;
            cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
            cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
            cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = ItmName + "%";
            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
            dt.Clear();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            adapt.Fill(dt);
            parentForm.conn.Close();
        }

        public void DataBind(int totalBoolNum, string sp, string ItmBrand, string ItmSize, string ItmColor, string ItmName, string ItmUpc, bool ItmTF)
        {
            cmd = new SqlCommand(sp, parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
            cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
            cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
            cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = ItmName + "%";
            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
            cmd.Parameters.Add("@ItmTF", SqlDbType.Bit).Value = ItmTF;
            dt.Clear();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            adapt.Fill(dt);
            parentForm.conn.Close();
        }

        public void DataBind(int totalBoolNum, string sp, int index1, string ItmBrand, string ItmSize, string ItmColor, string ItmName, string ItmUpc, bool ItmTF)
        {
            cmd = new SqlCommand(sp, parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
            cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
            cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
            cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
            cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = ItmName + "%";
            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
            cmd.Parameters.Add("@ItmTF", SqlDbType.Bit).Value = ItmTF;
            dt.Clear();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            adapt.Fill(dt);
            parentForm.conn.Close();
        }

        public void DataBind(int totalBoolNum, string sp, int index1, int index2, string ItmBrand, string ItmSize, string ItmColor, string ItmName, string ItmUpc, bool ItmTF)
        {
            cmd = new SqlCommand(sp, parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
            cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
            cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = index2;
            cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
            cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
            cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = ItmName + "%";
            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
            cmd.Parameters.Add("@ItmTF", SqlDbType.Bit).Value = ItmTF;
            dt.Clear();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            adapt.Fill(dt);
            parentForm.conn.Close();
        }

        public void DataBind(int totalBoolNum, string sp, int index1, int index2, int index3, string ItmBrand, string ItmSize, string ItmColor, string ItmName, string ItmUpc, bool ItmTF)
        {
            cmd = new SqlCommand(sp, parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
            cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
            cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = index2;
            cmd.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = index3;
            cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
            cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
            cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = ItmName + "%";
            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
            cmd.Parameters.Add("@ItmTF", SqlDbType.Bit).Value = ItmTF;
            dt.Clear();
            adapt.SelectCommand = cmd;

            parentForm.conn.Open();
            adapt.Fill(dt);
            parentForm.conn.Close();
        }

        private void BindDataGridView()
        {
            if (parentForm.StoreCode == "B4UHQ")
            {
                dataGridView1.RowTemplate.Height = 35;
                dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].HeaderText = "Brand";
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[2].ReadOnly = true;
                dataGridView1.Columns[3].HeaderText = "Sub Brand";
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[3].ReadOnly = true;
                dataGridView1.Columns[4].HeaderText = "Name";
                dataGridView1.Columns[4].Width = 190;
                dataGridView1.Columns[4].ReadOnly = true;
                dataGridView1.Columns[5].HeaderText = "Size";
                dataGridView1.Columns[5].Width = 50;
                dataGridView1.Columns[5].ReadOnly = true;
                dataGridView1.Columns[6].HeaderText = "Color";
                dataGridView1.Columns[6].Width = 50;
                dataGridView1.Columns[6].ReadOnly = true;
                dataGridView1.Columns[7].HeaderText = "Model Number";
                dataGridView1.Columns[7].Width = 80;
                dataGridView1.Columns[7].ReadOnly = true;
                dataGridView1.Columns[8].HeaderText = "Gp1";
                dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[8].Width = 35;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].HeaderText = "Gp2";
                dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[9].Width = 35;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].HeaderText = "Gp3";
                dataGridView1.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[10].Width = 35;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[14].HeaderText = "Minimum Stock";
                dataGridView1.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[14].Width = 55;
                dataGridView1.Columns[14].Visible = false;
                dataGridView1.Columns[15].HeaderText = "On Hand";
                dataGridView1.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[15].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                dataGridView1.Columns[15].Width = 40;
                dataGridView1.Columns[15].ReadOnly = true;
                //dataGridView1.Columns[15].Visible = false;
                dataGridView1.Columns[16].HeaderText = "Retail Price";
                dataGridView1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[16].Width = 50;
                //dataGridView1.Columns[16].DefaultCellStyle.BackColor = Color.NavajoWhite;
                dataGridView1.Columns[16].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns[16].ReadOnly = true;
                dataGridView1.Columns[17].HeaderText = "Cost Price";
                dataGridView1.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[17].Width = 50;
                dataGridView1.Columns[17].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                dataGridView1.Columns[17].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns[18].Visible = false;
                dataGridView1.Columns[19].Visible = false;
                dataGridView1.Columns[20].Visible = false;
                dataGridView1.Columns[21].Visible = false;
                dataGridView1.Columns[22].Visible = false;
                dataGridView1.Columns[23].Visible = false;
                dataGridView1.Columns[24].Visible = false;
                dataGridView1.Columns[25].Visible = false;
                dataGridView1.Columns[26].Visible = false;
                dataGridView1.Columns[27].Visible = false;
                dataGridView1.Columns[28].HeaderText = "Stylist Price";
                dataGridView1.Columns[28].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[28].Width = 55;
                dataGridView1.Columns[28].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns[28].Visible = false;
                dataGridView1.Columns[29].HeaderText = "UPC";
                dataGridView1.Columns[29].Width = 100;
                dataGridView1.Columns[29].ReadOnly = true;
                dataGridView1.Columns[30].HeaderText = "Bin#";
                dataGridView1.Columns[30].Width = 40;
                dataGridView1.Columns[30].ReadOnly = true;
                dataGridView1.Columns[31].HeaderText = "Vendor";
                dataGridView1.Columns[31].Width = 80;
                dataGridView1.Columns[32].Visible = false;
                dataGridView1.Columns[33].HeaderText = "Register Date";
                dataGridView1.Columns[33].Width = 80;
                dataGridView1.Columns[33].ReadOnly = true;
                dataGridView1.Columns[34].HeaderText = "Register ID";
                dataGridView1.Columns[34].Width = 80;
                dataGridView1.Columns[34].ReadOnly = true;
                dataGridView1.Columns[35].HeaderText = "Update Date";
                dataGridView1.Columns[35].Width = 80;
                dataGridView1.Columns[35].ReadOnly = true;
                dataGridView1.Columns[36].HeaderText = "Update ID";
                dataGridView1.Columns[36].Width = 80;
                dataGridView1.Columns[36].ReadOnly = true;
                dataGridView1.Columns[37].Visible = false;
                dataGridView1.Columns[38].Visible = false;
                dataGridView1.Columns[39].Visible = false;
                dataGridView1.Columns[40].Visible = false;
                dataGridView1.Columns[41].Visible = false;
                dataGridView1.Columns[42].HeaderText = "Active";
                dataGridView1.Columns[42].Width = 40;
                dataGridView1.Columns[42].ReadOnly = true;
            }
            else
            {
                dataGridView1.RowTemplate.Height = 35;
                dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].HeaderText = "Brand";
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[2].ReadOnly = true;
                dataGridView1.Columns[3].HeaderText = "Name";
                dataGridView1.Columns[3].Width = 190;
                dataGridView1.Columns[3].ReadOnly = true;
                dataGridView1.Columns[4].HeaderText = "Size";
                dataGridView1.Columns[4].Width = 50;
                dataGridView1.Columns[4].ReadOnly = true;
                dataGridView1.Columns[5].HeaderText = "Color";
                dataGridView1.Columns[5].Width = 50;
                dataGridView1.Columns[5].ReadOnly = true;
                dataGridView1.Columns[6].HeaderText = "Model Number";
                dataGridView1.Columns[6].Width = 80;
                dataGridView1.Columns[6].ReadOnly = true;
                dataGridView1.Columns[7].HeaderText = "Gp1";
                dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[7].Width = 35;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].HeaderText = "Gp2";
                dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[8].Width = 35;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].HeaderText = "Gp3";
                dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[9].Width = 35;
                dataGridView1.Columns[9].Visible = false;
                //dataGridView1.Columns[7].Visible = false;
                //dataGridView1.Columns[8].Visible = false;
                //dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].HeaderText = "Minimum Stock";
                dataGridView1.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[13].Width = 55;
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[14].HeaderText = "On Hand";
                dataGridView1.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[14].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                dataGridView1.Columns[14].Width = 40;
                dataGridView1.Columns[14].ReadOnly = true;
                //dataGridView1.Columns[14].Visible = false;
                dataGridView1.Columns[15].HeaderText = "Retail Price";
                dataGridView1.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[15].Width = 50;
                //dataGridView1.Columns[15].DefaultCellStyle.BackColor = Color.NavajoWhite;
                dataGridView1.Columns[15].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns[15].ReadOnly = true;
                dataGridView1.Columns[16].HeaderText = "Cost Price";
                dataGridView1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[16].Width = 50;
                dataGridView1.Columns[16].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                dataGridView1.Columns[16].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns[17].Visible = false;
                dataGridView1.Columns[18].Visible = false;
                dataGridView1.Columns[19].Visible = false;
                dataGridView1.Columns[20].Visible = false;
                dataGridView1.Columns[21].Visible = false;
                dataGridView1.Columns[22].Visible = false;
                dataGridView1.Columns[23].Visible = false;
                dataGridView1.Columns[24].Visible = false;
                dataGridView1.Columns[25].Visible = false;
                dataGridView1.Columns[26].Visible = false;
                //dataGridView1.Columns[27].Visible = false;
                dataGridView1.Columns[27].HeaderText = "Stylist Price";
                dataGridView1.Columns[27].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[27].Width = 55;
                dataGridView1.Columns[27].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns[27].Visible = false;
                dataGridView1.Columns[28].HeaderText = "UPC";
                dataGridView1.Columns[28].Width = 100;
                dataGridView1.Columns[28].ReadOnly = true;
                dataGridView1.Columns[29].HeaderText = "Bin#";
                dataGridView1.Columns[29].Width = 40;
                dataGridView1.Columns[29].ReadOnly = true;
                dataGridView1.Columns[29].Visible = false;
                dataGridView1.Columns[30].Visible = false;
                dataGridView1.Columns[31].Visible = false;
                dataGridView1.Columns[32].HeaderText = "Register Date";
                dataGridView1.Columns[32].Width = 80;
                dataGridView1.Columns[32].ReadOnly = true;
                dataGridView1.Columns[32].Visible = false;
                dataGridView1.Columns[33].Visible = false;
                dataGridView1.Columns[34].Visible = false;
                dataGridView1.Columns[35].Visible = false;
                dataGridView1.Columns[36].Visible = false;
                dataGridView1.Columns[37].Visible = false;
                dataGridView1.Columns[38].HeaderText = "Active";
                dataGridView1.Columns[38].Width = 40;
                dataGridView1.Columns[38].ReadOnly = true;
            }

            dataGridView1.ClearSelection();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (parentForm.StoreCode == "B4UHQ")
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    cmd = new SqlCommand("Update_CostPrice", parentForm.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@ItmCode", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                    cmd.Parameters.Add("@ItmCostPrice", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[17].Value);
                    cmd.Parameters.Add("@ItmUpdateDate", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@ItmUpdateID", SqlDbType.NVarChar).Value = parentForm.employeeID;

                    parentForm.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm.conn.Close();

                    backgroundWorker1.ReportProgress(i);
                }
            }
            else
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    cmd = new SqlCommand("Update_CostPrice", parentForm.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@ItmCode", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                    cmd.Parameters.Add("@ItmCostPrice", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[16].Value);

                    parentForm.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm.conn.Close();

                    backgroundWorker1.ReportProgress(i);
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (parentForm.StoreCode == "B4UHQ")
            {
                totalOnhand = 0;
                totalValueOfProduct = 0;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (Convert.ToInt64(dataGridView1.Rows[i].Cells[15].Value) > 0)
                    {
                        totalOnhand = totalOnhand + Convert.ToInt64(dataGridView1.Rows[i].Cells[15].Value);
                        totalValueOfProduct = totalValueOfProduct + (Convert.ToInt64(dataGridView1.Rows[i].Cells[15].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[17].Value));
                    }
                }

                //dataGridView2.Rows[0].Selected = false;
                lblTotalOnhand.Text = Convert.ToString(totalOnhand);
                lblTotalValueOfProduct.Text = string.Format("{0:c}", totalValueOfProduct);
                lblTotalCount1.Text = Convert.ToString(dataGridView1.RowCount);

                MessageBox.Show("SUCCESSFULLY UPDATED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                progressBar1.Visible = false;
                progressBar1.Value = 0;
                btnUpdate.Enabled = true;
                btnSearch_Click(null, null);
            }
            else
            {
                totalOnhand = 0;
                totalValueOfProduct = 0;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (Convert.ToInt64(dataGridView1.Rows[i].Cells[14].Value) > 0)
                    {
                        totalOnhand = totalOnhand + Convert.ToInt64(dataGridView1.Rows[i].Cells[14].Value);
                        totalValueOfProduct = totalValueOfProduct + (Convert.ToInt64(dataGridView1.Rows[i].Cells[14].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[16].Value));
                    }
                }

                //dataGridView2.Rows[0].Selected = false;
                lblTotalOnhand.Text = Convert.ToString(totalOnhand);
                lblTotalValueOfProduct.Text = string.Format("{0:c}", totalValueOfProduct);
                lblTotalCount1.Text = Convert.ToString(dataGridView1.RowCount);

                MessageBox.Show("SUCCESSFULLY UPDATED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                progressBar1.Visible = false;
                progressBar1.Value = 0;
                btnUpdate.Enabled = true;
                btnSearch_Click(null, null);
            }
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
    }
}