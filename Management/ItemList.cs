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
    public partial class ItemList : Form
    {
        public LogInManagements parentForm;

        int index1, index2, index3;
        string sp;
        int brandBoolNum, nameBoolNum, totalBoolNum;
        string ItmBrand, ItmName;
        bool ItmTF, ItmDetailOption;
        public Font drvFont = new Font("Arial", 12, FontStyle.Bold);
        public DataTable dt1 = new DataTable();
        public DataTable dt = new DataTable();
        SqlDataAdapter adapt = new SqlDataAdapter();
        SqlCommand cmd;

        //Int64 totalCount = 0;
        Int64 totalOnHand = 0;

        SqlConnection newConn;
        string newStoreName;

        public ItemList()
        {
            InitializeComponent();
        }

        private void ItemList_Load(object sender, EventArgs e)
        {
            this.Text = "ITEM LIST - " + parentForm.storeName;

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

            SqlCommand cmd_StoreList = new SqlCommand("Get_Retail_StoreCode", parentForm.conn);
            cmd_StoreList.CommandType = CommandType.StoredProcedure;
            DataSet ds_StoreList = new DataSet();
            SqlDataAdapter adapt_StoreList = new SqlDataAdapter(cmd_StoreList);

            parentForm.conn.Open();
            ds_StoreList.Clear();
            adapt_StoreList.Fill(ds_StoreList);
            parentForm.conn.Close();

            cmbStoreCode.DataSource = ds_StoreList.Tables[0].DefaultView;
            cmbStoreCode.ValueMember = "CIStoreCode";
            cmbStoreCode.DisplayMember = "CIStoreCode";

            lblTotalCount.Text = "0";
            lblTotalOnHand.Text = "0";

            if (parentForm.userLevel < parentForm.SectionManagerLV)
            {
                lblStoreCode.Visible = false;
                cmbStoreCode.Visible = false;
            }

            cmbStoreCode.Text = parentForm.StoreCode.ToUpper();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                if (cmbCategory1.SelectedIndex == 0)
                {
                    sp = "Show_ItemList_By_Brand";
                    DataBind(sp);
                    BindDataGridView2();
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
                            sp = "Show_ItemList_By_Brand_With_Category_1_2_3";
                            DataBind(sp, index1, index2, index3);
                            BindDataGridView2();
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
                            sp = "Show_ItemList_By_Brand_With_Category_1_2";
                            DataBind(sp, index1, index2);
                            BindDataGridView2();
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
                        sp = "Show_ItemList_By_Brand_With_Category_1";
                        DataBind(sp, index1);
                        BindDataGridView2();
                    }
                }

                lblTotalCount.Text = "N/A";
                lblTotalOnHand.Text = "N/A";
            }
            else if (radioButton2.Checked == true)
            {
                brandBoolNum = 0; nameBoolNum = 0; totalBoolNum = 0;
                totalOnHand = 0;

                if (cmbBrand.Text == "")
                {
                    brandBoolNum = 0;
                    ItmBrand = "1";
                }
                else
                {
                    brandBoolNum = 1;
                    ItmBrand = cmbBrand.Text.ToUpper();
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

                totalBoolNum = brandBoolNum + nameBoolNum;

                if (rdoBtnAll.Checked == true)
                {
                    ItmDetailOption = false;

                    if (cmbCategory1.SelectedIndex == 0)
                    {
                        sp = "Show_ItemList";
                        DataBind(totalBoolNum, sp);
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
                                sp = "Show_ItemList_With_Category_1_2_3";
                                DataBind(totalBoolNum, sp, index1, index2, index3);
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
                                sp = "Show_ItemList_With_Category_1_2";
                                DataBind(totalBoolNum, sp, index1, index2);
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
                            sp = "Show_ItemList_With_Category_1";
                            DataBind(totalBoolNum, sp, index1);
                            BindDataGridView();
                        }
                    }
                }
                else
                {
                    ItmDetailOption = true;

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
                        sp = "Show_ItemList_TF";
                        DataBind(totalBoolNum, sp, ItmTF);
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
                                sp = "Show_ItemList_With_Category_1_2_3_TF";
                                DataBind(totalBoolNum, sp, index1, index2, index3, ItmTF);
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
                                sp = "Show_ItemList_With_Category_1_2_TF";
                                DataBind(totalBoolNum, sp, index1, index2, ItmTF);
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
                            sp = "Show_ItemList_With_Category_1_TF";
                            DataBind(totalBoolNum, sp, index1, ItmTF);
                            BindDataGridView();
                        }
                    }
                }

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (Convert.ToInt64(dataGridView1.Rows[i].Cells[3].Value) >= 0)
                        totalOnHand = totalOnHand + Convert.ToInt64(dataGridView1.Rows[i].Cells[3].Value);
                }

                lblTotalCount.Text = Convert.ToString(dataGridView1.RowCount);
                lblTotalOnHand.Text = Convert.ToString(totalOnHand);
            }
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            cmbCategory2.DataSource = null;
            cmbCategory2.Items.Clear();
            cmbCategory3.DataSource = null;
            cmbCategory3.Items.Clear();
            cmbBrand.DataSource = null;
            txtName.Clear();

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

            lblTotalCount.Text = "0";
            lblTotalOnHand.Text = "0";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                return;

            if (parentForm.StoreCode == cmbStoreCode.Text.ToUpper().ToString())
            {
                if (dataGridView1.RowCount > 0)
                {
                    if (ItmDetailOption == true)
                    {
                        if (ItmTF == true)
                        {
                            ItemListDetail itemListDetailForm = new ItemListDetail(Convert.ToString(dataGridView1.SelectedCells[0].Value), Convert.ToString(dataGridView1.SelectedCells[1].Value), Convert.ToDouble(dataGridView1.SelectedCells[4].Value), 1);
                            itemListDetailForm.parentForm1 = this.parentForm;
                            itemListDetailForm.parentForm2 = this;
                            itemListDetailForm.Show();
                        }
                        else if (ItmTF == false)
                        {
                            ItemListDetail itemListDetailForm = new ItemListDetail(Convert.ToString(dataGridView1.SelectedCells[0].Value), Convert.ToString(dataGridView1.SelectedCells[1].Value), Convert.ToDouble(dataGridView1.SelectedCells[4].Value), 2);
                            itemListDetailForm.parentForm1 = this.parentForm;
                            itemListDetailForm.parentForm2 = this;
                            itemListDetailForm.Show();
                        }
                    }
                    else
                    {
                        ItemListDetail itemListDetailForm = new ItemListDetail(Convert.ToString(dataGridView1.SelectedCells[0].Value), Convert.ToString(dataGridView1.SelectedCells[1].Value), Convert.ToDouble(dataGridView1.SelectedCells[4].Value), 0);
                        itemListDetailForm.parentForm1 = this.parentForm;
                        itemListDetailForm.parentForm2 = this;
                        itemListDetailForm.Show();
                    }
                }
            }
            else
            {
                if(parentForm.userLevel >= parentForm.GeneralManagerLV)
                {
                    if (dataGridView1.RowCount > 0)
                    {
                        if (ItmDetailOption == true)
                        {
                            if (ItmTF == true)
                            {
                                ItemListDetail itemListDetailForm = new ItemListDetail(Convert.ToString(dataGridView1.SelectedCells[0].Value), Convert.ToString(dataGridView1.SelectedCells[1].Value), Convert.ToDouble(dataGridView1.SelectedCells[4].Value), 1);
                                itemListDetailForm.parentForm1 = this.parentForm;
                                itemListDetailForm.parentForm2 = this;
                                itemListDetailForm.Show();
                            }
                            else if (ItmTF == false)
                            {
                                ItemListDetail itemListDetailForm = new ItemListDetail(Convert.ToString(dataGridView1.SelectedCells[0].Value), Convert.ToString(dataGridView1.SelectedCells[1].Value), Convert.ToDouble(dataGridView1.SelectedCells[4].Value), 2);
                                itemListDetailForm.parentForm1 = this.parentForm;
                                itemListDetailForm.parentForm2 = this;
                                itemListDetailForm.Show();
                            }
                        }
                        else
                        {
                            ItemListDetail itemListDetailForm = new ItemListDetail(Convert.ToString(dataGridView1.SelectedCells[0].Value), Convert.ToString(dataGridView1.SelectedCells[1].Value), Convert.ToDouble(dataGridView1.SelectedCells[4].Value), 0);
                            itemListDetailForm.parentForm1 = this.parentForm;
                            itemListDetailForm.parentForm2 = this;
                            itemListDetailForm.Show();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("You are not authorized...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
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

        public void DataBind(string sp)
        {
            if (parentForm.StoreCode == cmbStoreCode.Text.ToUpper().ToString())
            {
                cmd = new SqlCommand(sp, parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                dt1.Clear();
                adapt.SelectCommand = cmd;

                parentForm.conn.Open();
                adapt.Fill(dt1);
                parentForm.conn.Close();

                this.Text = "ITEM LIST - " + parentForm.storeName;
            }
            else
            {
                if (cmbStoreCode.Text == "OH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.OHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.OHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "OXON HILL";
                }
                else if (cmbStoreCode.Text == "CH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "CAPITOL HEIGHTS";
                }
                else if (cmbStoreCode.Text == "WB")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WBIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WBDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WOODBRIDGE";
                }
                else if (cmbStoreCode.Text == "CV")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CVIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CVDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "CATONSVILLE";
                }
                else if (cmbStoreCode.Text == "UM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.UMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.UMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "UPPER MARLBORO";
                }
                else if (cmbStoreCode.Text == "WM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WINDSOR MILL";
                }
                else if (cmbStoreCode.Text == "TH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.THIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.THDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "TEMPLE HILLS";
                }
                else if (cmbStoreCode.Text == "WD")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WDIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WDDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WALDORF";
                }
                else if (cmbStoreCode.Text == "PW")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.PWIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.PWDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "PRINCE WILLIAM";
                }
                else if (cmbStoreCode.Text == "GB")
                {
                    newConn = new SqlConnection(parentForm.GBCS_IP);
                    newStoreName = "GAITHERSBURG";
                }
                else if (cmbStoreCode.Text == "BW")
                {
                    newConn = new SqlConnection(parentForm.BWCS_IP);
                    newStoreName = "BOWIE";
                }

                cmd = new SqlCommand(sp, newConn);
                cmd.CommandType = CommandType.StoredProcedure;
                dt1.Clear();
                adapt.SelectCommand = cmd;

                newConn.Open();
                adapt.Fill(dt1);
                newConn.Close();

                this.Text = "ITEM LIST - " + newStoreName + " (YOUR LOCATION : " + parentForm.storeName.ToUpper().ToString() + ")";
            }
        }

        public void DataBind(string sp, int index1)
        {
            if (parentForm.StoreCode == cmbStoreCode.Text.ToUpper().ToString())
            {
                cmd = new SqlCommand(sp, parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
                dt1.Clear();
                adapt.SelectCommand = cmd;

                parentForm.conn.Open();
                adapt.Fill(dt1);
                parentForm.conn.Close();

                this.Text = "ITEM LIST - " + parentForm.storeName;
            }
            else
            {
                if (cmbStoreCode.Text == "OH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.OHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.OHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "OXON HILL";
                }
                else if (cmbStoreCode.Text == "CH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "CAPITOL HEIGHTS";
                }
                else if (cmbStoreCode.Text == "WB")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WBIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WBDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WOODBRIDGE";
                }
                else if (cmbStoreCode.Text == "CV")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CVIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CVDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "CATONSVILLE";
                }
                else if (cmbStoreCode.Text == "UM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.UMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.UMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "UPPER MARLBORO";
                }
                else if (cmbStoreCode.Text == "WM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WINDSOR MILL";
                }
                else if (cmbStoreCode.Text == "TH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.THIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.THDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "TEMPLE HILLS";
                }
                else if (cmbStoreCode.Text == "WD")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WDIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WDDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WALDORF";
                }
                else if (cmbStoreCode.Text == "PW")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.PWIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.PWDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "PRINCE WILLIAM";
                }
                else if (cmbStoreCode.Text == "GB")
                {
                    newConn = new SqlConnection(parentForm.GBCS_IP);
                    newStoreName = "GAITHERSBURG";
                }
                else if (cmbStoreCode.Text == "BW")
                {
                    newConn = new SqlConnection(parentForm.BWCS_IP);
                    newStoreName = "BOWIE";
                }

                cmd = new SqlCommand(sp, newConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
                dt1.Clear();
                adapt.SelectCommand = cmd;

                newConn.Open();
                adapt.Fill(dt1);
                newConn.Close();

                this.Text = "ITEM LIST - " + newStoreName + " (YOUR LOCATION : " + parentForm.storeName.ToUpper().ToString() + ")";
            }
        }

        public void DataBind(string sp, int index1, int index2)
        {
            if (parentForm.StoreCode == cmbStoreCode.Text.ToUpper().ToString())
            {
                cmd = new SqlCommand(sp, parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
                cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = index2;
                dt1.Clear();
                adapt.SelectCommand = cmd;

                parentForm.conn.Open();
                adapt.Fill(dt1);
                parentForm.conn.Close();

                this.Text = "ITEM LIST - " + parentForm.storeName;
            }
            else
            {
                if (cmbStoreCode.Text == "OH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.OHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.OHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "OXON HILL";
                }
                else if (cmbStoreCode.Text == "CH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "CAPITOL HEIGHTS";
                }
                else if (cmbStoreCode.Text == "WB")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WBIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WBDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WOODBRIDGE";
                }
                else if (cmbStoreCode.Text == "CV")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CVIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CVDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "CATONSVILLE";
                }
                else if (cmbStoreCode.Text == "UM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.UMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.UMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "UPPER MARLBORO";
                }
                else if (cmbStoreCode.Text == "WM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WINDSOR MILL";
                }
                else if (cmbStoreCode.Text == "TH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.THIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.THDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "TEMPLE HILLS";
                }
                else if (cmbStoreCode.Text == "WD")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WDIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WDDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WALDORF";
                }
                else if (cmbStoreCode.Text == "PW")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.PWIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.PWDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "PRINCE WILLIAM";
                }
                else if (cmbStoreCode.Text == "GB")
                {
                    newConn = new SqlConnection(parentForm.GBCS_IP);
                    newStoreName = "GAITHERSBURG";
                }
                else if (cmbStoreCode.Text == "BW")
                {
                    newConn = new SqlConnection(parentForm.BWCS_IP);
                    newStoreName = "BOWIE";
                }

                cmd = new SqlCommand(sp, newConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
                cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = index2;
                dt1.Clear();
                adapt.SelectCommand = cmd;

                newConn.Open();
                adapt.Fill(dt1);
                newConn.Close();

                this.Text = "ITEM LIST - " + newStoreName + " (YOUR LOCATION : " + parentForm.storeName.ToUpper().ToString() + ")";
            }
        }

        public void DataBind(string sp, int index1, int index2, int index3)
        {
            if (parentForm.StoreCode == cmbStoreCode.Text.ToUpper().ToString())
            {
                cmd = new SqlCommand(sp, parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
                cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = index2;
                cmd.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = index3;
                dt1.Clear();
                adapt.SelectCommand = cmd;

                parentForm.conn.Open();
                adapt.Fill(dt1);
                parentForm.conn.Close();

                this.Text = "ITEM LIST - " + parentForm.storeName;
            }
            else
            {
                if (cmbStoreCode.Text == "OH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.OHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.OHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "OXON HILL";
                }
                else if (cmbStoreCode.Text == "CH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "CAPITOL HEIGHTS";
                }
                else if (cmbStoreCode.Text == "WB")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WBIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WBDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WOODBRIDGE";
                }
                else if (cmbStoreCode.Text == "CV")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CVIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CVDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "CATONSVILLE";
                }
                else if (cmbStoreCode.Text == "UM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.UMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.UMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "UPPER MARLBORO";
                }
                else if (cmbStoreCode.Text == "WM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WINDSOR MILL";
                }
                else if (cmbStoreCode.Text == "TH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.THIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.THDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "TEMPLE HILLS";
                }
                else if (cmbStoreCode.Text == "WD")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WDIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WDDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WALDORF";
                }
                else if (cmbStoreCode.Text == "PW")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.PWIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.PWDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "PRINCE WILLIAM";
                }
                else if (cmbStoreCode.Text == "GB")
                {
                    newConn = new SqlConnection(parentForm.GBCS_IP);
                    newStoreName = "GAITHERSBURG";
                }
                else if (cmbStoreCode.Text == "BW")
                {
                    newConn = new SqlConnection(parentForm.BWCS_IP);
                    newStoreName = "BOWIE";
                }

                cmd = new SqlCommand(sp, newConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
                cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = index2;
                cmd.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = index3;
                dt1.Clear();
                adapt.SelectCommand = cmd;

                newConn.Open();
                adapt.Fill(dt1);
                newConn.Close();

                this.Text = "ITEM LIST - " + newStoreName + " (YOUR LOCATION : " + parentForm.storeName.ToUpper().ToString() + ")";
            }
        }

        public void DataBind(int totalBoolNum, string sp)
        {
            if (parentForm.StoreCode == cmbStoreCode.Text.ToUpper().ToString())
            {
                cmd = new SqlCommand(sp, parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
                cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                dt.Clear();
                adapt.SelectCommand = cmd;

                parentForm.conn.Open();
                adapt.Fill(dt);
                parentForm.conn.Close();

                this.Text = "ITEM LIST - " + parentForm.storeName;
            }
            else
            {
                if (cmbStoreCode.Text == "OH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.OHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.OHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "OXON HILL";
                }
                else if (cmbStoreCode.Text == "CH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "CAPITOL HEIGHTS";
                }
                else if (cmbStoreCode.Text == "WB")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WBIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WBDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WOODBRIDGE";
                }
                else if (cmbStoreCode.Text == "CV")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CVIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CVDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "CATONSVILLE";
                }
                else if (cmbStoreCode.Text == "UM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.UMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.UMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "UPPER MARLBORO";
                }
                else if (cmbStoreCode.Text == "WM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WINDSOR MILL";
                }
                else if (cmbStoreCode.Text == "TH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.THIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.THDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "TEMPLE HILLS";
                }
                else if (cmbStoreCode.Text == "WD")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WDIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WDDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WALDORF";
                }
                else if (cmbStoreCode.Text == "PW")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.PWIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.PWDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "PRINCE WILLIAM";
                }
                else if (cmbStoreCode.Text == "GB")
                {
                    newConn = new SqlConnection(parentForm.GBCS_IP);
                    newStoreName = "GAITHERSBURG";
                }
                else if (cmbStoreCode.Text == "BW")
                {
                    newConn = new SqlConnection(parentForm.BWCS_IP);
                    newStoreName = "BOWIE";
                }

                cmd = new SqlCommand(sp, newConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
                cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                dt.Clear();
                adapt.SelectCommand = cmd;

                newConn.Open();
                adapt.Fill(dt);
                newConn.Close();

                this.Text = "ITEM LIST - " + newStoreName + " (YOUR LOCATION : " + parentForm.storeName.ToUpper().ToString() + ")";
            }
        }

        public void DataBind(int totalBoolNum, string sp, int index1)
        {
            if (parentForm.StoreCode == cmbStoreCode.Text.ToUpper().ToString())
            {
                cmd = new SqlCommand(sp, parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
                cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                dt.Clear();
                adapt.SelectCommand = cmd;

                parentForm.conn.Open();
                adapt.Fill(dt);
                parentForm.conn.Close();

                this.Text = "ITEM LIST - " + parentForm.storeName;
            }
            else
            {
                if (cmbStoreCode.Text == "OH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.OHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.OHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "OXON HILL";
                }
                else if (cmbStoreCode.Text == "CH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "CAPITOL HEIGHTS";
                }
                else if (cmbStoreCode.Text == "WB")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WBIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WBDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WOODBRIDGE";
                }
                else if (cmbStoreCode.Text == "CV")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CVIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CVDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "CATONSVILLE";
                }
                else if (cmbStoreCode.Text == "UM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.UMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.UMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "UPPER MARLBORO";
                }
                else if (cmbStoreCode.Text == "WM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WINDSOR MILL";
                }
                else if (cmbStoreCode.Text == "TH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.THIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.THDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "TEMPLE HILLS";
                }
                else if (cmbStoreCode.Text == "WD")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WDIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WDDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WALDORF";
                }
                else if (cmbStoreCode.Text == "PW")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.PWIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.PWDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "PRINCE WILLIAM";
                }
                else if (cmbStoreCode.Text == "GB")
                {
                    newConn = new SqlConnection(parentForm.GBCS_IP);
                    newStoreName = "GAITHERSBURG";
                }
                else if (cmbStoreCode.Text == "BW")
                {
                    newConn = new SqlConnection(parentForm.BWCS_IP);
                    newStoreName = "BOWIE";
                }

                cmd = new SqlCommand(sp, newConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
                cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                dt.Clear();
                adapt.SelectCommand = cmd;

                newConn.Open();
                adapt.Fill(dt);
                newConn.Close();

                this.Text = "ITEM LIST - " + newStoreName + " (YOUR LOCATION : " + parentForm.storeName.ToUpper().ToString() + ")";
            }
        }

        public void DataBind(int totalBoolNum, string sp, int index1, int index2)
        {
            if (parentForm.StoreCode == cmbStoreCode.Text.ToUpper().ToString())
            {
                cmd = new SqlCommand(sp, parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
                cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = index2;
                cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                dt.Clear();
                adapt.SelectCommand = cmd;

                parentForm.conn.Open();
                adapt.Fill(dt);
                parentForm.conn.Close();

                this.Text = "ITEM LIST - " + parentForm.storeName;
            }
            else
            {
                if (cmbStoreCode.Text == "OH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.OHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.OHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "OXON HILL";
                }
                else if (cmbStoreCode.Text == "CH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "CAPITOL HEIGHTS";
                }
                else if (cmbStoreCode.Text == "WB")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WBIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WBDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WOODBRIDGE";
                }
                else if (cmbStoreCode.Text == "CV")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CVIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CVDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "CATONSVILLE";
                }
                else if (cmbStoreCode.Text == "UM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.UMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.UMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "UPPER MARLBORO";
                }
                else if (cmbStoreCode.Text == "WM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WINDSOR MILL";
                }
                else if (cmbStoreCode.Text == "TH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.THIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.THDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "TEMPLE HILLS";
                }
                else if (cmbStoreCode.Text == "WD")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WDIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WDDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WALDORF";
                }
                else if (cmbStoreCode.Text == "PW")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.PWIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.PWDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "PRINCE WILLIAM";
                }
                else if (cmbStoreCode.Text == "GB")
                {
                    newConn = new SqlConnection(parentForm.GBCS_IP);
                    newStoreName = "GAITHERSBURG";
                }
                else if (cmbStoreCode.Text == "BW")
                {
                    newConn = new SqlConnection(parentForm.BWCS_IP);
                    newStoreName = "BOWIE";
                }

                cmd = new SqlCommand(sp, newConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
                cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = index2;
                cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                dt.Clear();
                adapt.SelectCommand = cmd;

                newConn.Open();
                adapt.Fill(dt);
                newConn.Close();

                this.Text = "ITEM LIST - " + newStoreName + " (YOUR LOCATION : " + parentForm.storeName.ToUpper().ToString() + ")";
            }
        }

        public void DataBind(int totalBoolNum, string sp, int index1, int index2, int index3)
        {
            if (parentForm.StoreCode == cmbStoreCode.Text.ToUpper().ToString())
            {
                cmd = new SqlCommand(sp, parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
                cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = index2;
                cmd.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = index3;
                cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                dt.Clear();
                adapt.SelectCommand = cmd;

                parentForm.conn.Open();
                adapt.Fill(dt);
                parentForm.conn.Close();

                this.Text = "ITEM LIST - " + parentForm.storeName;
            }
            else
            {
                if (cmbStoreCode.Text == "OH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.OHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.OHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "OXON HILL";
                }
                else if (cmbStoreCode.Text == "CH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "CAPITOL HEIGHTS";
                }
                else if (cmbStoreCode.Text == "WB")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WBIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WBDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WOODBRIDGE";
                }
                else if (cmbStoreCode.Text == "CV")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CVIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CVDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "CATONSVILLE";
                }
                else if (cmbStoreCode.Text == "UM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.UMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.UMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "UPPER MARLBORO";
                }
                else if (cmbStoreCode.Text == "WM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WINDSOR MILL";
                }
                else if (cmbStoreCode.Text == "TH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.THIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.THDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "TEMPLE HILLS";
                }
                else if (cmbStoreCode.Text == "WD")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WDIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WDDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WALDORF";
                }
                else if (cmbStoreCode.Text == "PW")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.PWIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.PWDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "PRINCE WILLIAM";
                }
                else if (cmbStoreCode.Text == "GB")
                {
                    newConn = new SqlConnection(parentForm.GBCS_IP);
                    newStoreName = "GAITHERSBURG";
                }
                else if (cmbStoreCode.Text == "BW")
                {
                    newConn = new SqlConnection(parentForm.BWCS_IP);
                    newStoreName = "BOWIE";
                }

                cmd = new SqlCommand(sp, newConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
                cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = index2;
                cmd.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = index3;
                cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                dt.Clear();
                adapt.SelectCommand = cmd;

                newConn.Open();
                adapt.Fill(dt);
                newConn.Close();

                this.Text = "ITEM LIST - " + newStoreName + " (YOUR LOCATION : " + parentForm.storeName.ToUpper().ToString() + ")";
            }
        }

        public void DataBind(int totalBoolNum, string sp, bool ItmTF)
        {
            if (parentForm.StoreCode == cmbStoreCode.Text.ToUpper().ToString())
            {
                cmd = new SqlCommand(sp, parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
                cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                cmd.Parameters.Add("@ItmTF", SqlDbType.Bit).Value = ItmTF;
                dt.Clear();
                adapt.SelectCommand = cmd;

                parentForm.conn.Open();
                adapt.Fill(dt);
                parentForm.conn.Close();

                this.Text = "ITEM LIST - " + parentForm.storeName;
            }
            else
            {
                if (cmbStoreCode.Text == "OH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.OHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.OHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "OXON HILL";
                }
                else if (cmbStoreCode.Text == "CH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "CAPITOL HEIGHTS";
                }
                else if (cmbStoreCode.Text == "WB")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WBIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WBDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WOODBRIDGE";
                }
                else if (cmbStoreCode.Text == "CV")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CVIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CVDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "CATONSVILLE";
                }
                else if (cmbStoreCode.Text == "UM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.UMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.UMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "UPPER MARLBORO";
                }
                else if (cmbStoreCode.Text == "WM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WINDSOR MILL";
                }
                else if (cmbStoreCode.Text == "TH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.THIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.THDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "TEMPLE HILLS";
                }
                else if (cmbStoreCode.Text == "WD")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WDIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WDDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WALDORF";
                }
                else if (cmbStoreCode.Text == "PW")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.PWIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.PWDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "PRINCE WILLIAM";
                }
                else if (cmbStoreCode.Text == "GB")
                {
                    newConn = new SqlConnection(parentForm.GBCS_IP);
                    newStoreName = "GAITHERSBURG";
                }
                else if (cmbStoreCode.Text == "BW")
                {
                    newConn = new SqlConnection(parentForm.BWCS_IP);
                    newStoreName = "BOWIE";
                }

                cmd = new SqlCommand(sp, newConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
                cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                cmd.Parameters.Add("@ItmTF", SqlDbType.Bit).Value = ItmTF;
                dt.Clear();
                adapt.SelectCommand = cmd;

                newConn.Open();
                adapt.Fill(dt);
                newConn.Close();

                this.Text = "ITEM LIST - " + newStoreName + " (YOUR LOCATION : " + parentForm.storeName.ToUpper().ToString() + ")";
            }
        }

        public void DataBind(int totalBoolNum, string sp, int index1, bool ItmTF)
        {
            if (parentForm.StoreCode == cmbStoreCode.Text.ToUpper().ToString())
            {
                cmd = new SqlCommand(sp, parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
                cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                cmd.Parameters.Add("@ItmTF", SqlDbType.Bit).Value = ItmTF;
                dt.Clear();
                adapt.SelectCommand = cmd;

                parentForm.conn.Open();
                adapt.Fill(dt);
                parentForm.conn.Close();

                this.Text = "ITEM LIST - " + parentForm.storeName;
            }
            else
            {
                if (cmbStoreCode.Text == "OH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.OHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.OHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "OXON HILL";
                }
                else if (cmbStoreCode.Text == "CH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "CAPITOL HEIGHTS";
                }
                else if (cmbStoreCode.Text == "WB")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WBIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WBDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WOODBRIDGE";
                }
                else if (cmbStoreCode.Text == "CV")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CVIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CVDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "CATONSVILLE";
                }
                else if (cmbStoreCode.Text == "UM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.UMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.UMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "UPPER MARLBORO";
                }
                else if (cmbStoreCode.Text == "WM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WINDSOR MILL";
                }
                else if (cmbStoreCode.Text == "TH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.THIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.THDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "TEMPLE HILLS";
                }
                else if (cmbStoreCode.Text == "WD")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WDIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WDDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WALDORF";
                }
                else if (cmbStoreCode.Text == "PW")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.PWIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.PWDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "PRINCE WILLIAM";
                }
                else if (cmbStoreCode.Text == "GB")
                {
                    newConn = new SqlConnection(parentForm.GBCS_IP);
                    newStoreName = "GAITHERSBURG";
                }
                else if (cmbStoreCode.Text == "BW")
                {
                    newConn = new SqlConnection(parentForm.BWCS_IP);
                    newStoreName = "BOWIE";
                }

                cmd = new SqlCommand(sp, newConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
                cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                cmd.Parameters.Add("@ItmTF", SqlDbType.Bit).Value = ItmTF;
                dt.Clear();
                adapt.SelectCommand = cmd;

                newConn.Open();
                adapt.Fill(dt);
                newConn.Close();

                this.Text = "ITEM LIST - " + newStoreName + " (YOUR LOCATION : " + parentForm.storeName.ToUpper().ToString() + ")";
            }
        }

        public void DataBind(int totalBoolNum, string sp, int index1, int index2, bool ItmTF)
        {
            if (parentForm.StoreCode == cmbStoreCode.Text.ToUpper().ToString())
            {
                cmd = new SqlCommand(sp, parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
                cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = index2;
                cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                cmd.Parameters.Add("@ItmTF", SqlDbType.Bit).Value = ItmTF;
                dt.Clear();
                adapt.SelectCommand = cmd;

                parentForm.conn.Open();
                adapt.Fill(dt);
                parentForm.conn.Close();

                this.Text = "ITEM LIST - " + parentForm.storeName;
            }
            else
            {
                if (cmbStoreCode.Text == "OH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.OHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.OHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "OXON HILL";
                }
                else if (cmbStoreCode.Text == "CH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "CAPITOL HEIGHTS";
                }
                else if (cmbStoreCode.Text == "WB")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WBIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WBDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WOODBRIDGE";
                }
                else if (cmbStoreCode.Text == "CV")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CVIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CVDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "CATONSVILLE";
                }
                else if (cmbStoreCode.Text == "UM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.UMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.UMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "UPPER MARLBORO";
                }
                else if (cmbStoreCode.Text == "WM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WINDSOR MILL";
                }
                else if (cmbStoreCode.Text == "TH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.THIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.THDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "TEMPLE HILLS";
                }
                else if (cmbStoreCode.Text == "WD")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WDIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WDDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WALDORF";
                }
                else if (cmbStoreCode.Text == "PW")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.PWIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.PWDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "PRINCE WILLIAM";
                }
                else if (cmbStoreCode.Text == "GB")
                {
                    newConn = new SqlConnection(parentForm.GBCS_IP);
                    newStoreName = "GAITHERSBURG";
                }
                else if (cmbStoreCode.Text == "BW")
                {
                    newConn = new SqlConnection(parentForm.BWCS_IP);
                    newStoreName = "BOWIE";
                }

                cmd = new SqlCommand(sp, newConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
                cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = index2;
                cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                cmd.Parameters.Add("@ItmTF", SqlDbType.Bit).Value = ItmTF;
                dt.Clear();
                adapt.SelectCommand = cmd;

                newConn.Open();
                adapt.Fill(dt);
                newConn.Close();

                this.Text = "ITEM LIST - " + newStoreName + " (YOUR LOCATION : " + parentForm.storeName.ToUpper().ToString() + ")";
            }
        }

        public void DataBind(int totalBoolNum, string sp, int index1, int index2, int index3, bool ItmTF)
        {
            if (parentForm.StoreCode == cmbStoreCode.Text.ToUpper().ToString())
            {
                cmd = new SqlCommand(sp, parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
                cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = index2;
                cmd.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = index3;
                cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                cmd.Parameters.Add("@ItmTF", SqlDbType.Bit).Value = ItmTF;
                dt.Clear();
                adapt.SelectCommand = cmd;

                parentForm.conn.Open();
                adapt.Fill(dt);
                parentForm.conn.Close();

                this.Text = "ITEM LIST - " + parentForm.storeName;
            }
            else
            {
                if (cmbStoreCode.Text == "OH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.OHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.OHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "OXON HILL";
                }
                else if (cmbStoreCode.Text == "CH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "CAPITOL HEIGHTS";
                }
                else if (cmbStoreCode.Text == "WB")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WBIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WBDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WOODBRIDGE";
                }
                else if (cmbStoreCode.Text == "CV")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CVIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CVDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "CATONSVILLE";
                }
                else if (cmbStoreCode.Text == "UM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.UMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.UMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "UPPER MARLBORO";
                }
                else if (cmbStoreCode.Text == "WM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WINDSOR MILL";
                }
                else if (cmbStoreCode.Text == "TH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.THIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.THDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "TEMPLE HILLS";
                }
                else if (cmbStoreCode.Text == "WD")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WDIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WDDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "WALDORF";
                }
                else if (cmbStoreCode.Text == "PW")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.PWIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.PWDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    newStoreName = "PRINCE WILLIAM";
                }
                else if (cmbStoreCode.Text == "GB")
                {
                    newConn = new SqlConnection(parentForm.GBCS_IP);
                    newStoreName = "GAITHERSBURG";
                }
                else if (cmbStoreCode.Text == "BW")
                {
                    newConn = new SqlConnection(parentForm.BWCS_IP);
                    newStoreName = "BOWIE";
                }

                cmd = new SqlCommand(sp, newConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
                cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = index2;
                cmd.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = index3;
                cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                cmd.Parameters.Add("@ItmTF", SqlDbType.Bit).Value = ItmTF;
                dt.Clear();
                adapt.SelectCommand = cmd;

                newConn.Open();
                adapt.Fill(dt);
                newConn.Close();

                this.Text = "ITEM LIST - " + newStoreName + " (YOUR LOCATION : " + parentForm.storeName.ToUpper().ToString() + ")";
            }
        }

        private void BindDataGridView()
        {
            dataGridView1.DataSource = null;

            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "BRAND";
            dataGridView1.Columns[0].Width = 170;
            dataGridView1.Columns[1].HeaderText = "NAME";
            dataGridView1.Columns[1].Width = 330;
            dataGridView1.Columns[2].HeaderText = "NUMBER OF ITEM STYLE";
            dataGridView1.Columns[2].Width = 140;
            dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].HeaderText = "ON HAND";
            dataGridView1.Columns[3].Width = 140;
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].HeaderText = "RETAIL PRICE";
            dataGridView1.Columns[4].Width = 140;
            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].DefaultCellStyle.Format = "$0.00";
            dataGridView1.Columns[5].HeaderText = "BIN #";
            dataGridView1.Columns[5].Width = 70;
        }
        
        private void BindDataGridView2()
        {
            dataGridView1.DataSource = null;

            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
            dataGridView1.DataSource = dt1;
            dataGridView1.Columns[0].HeaderText = "VENDOR";
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].HeaderText = "BRAND";
            dataGridView1.Columns[1].Width = 340;
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            btnBrand.Enabled = false;
            cmbBrand.Enabled = false;
            label5.Enabled = false;
            txtName.Enabled = false;
            groupBox1.Enabled = false;
            dataGridView1.DataSource = DBNull.Value;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            btnBrand.Enabled = true;
            cmbBrand.Enabled = true;
            label5.Enabled = true;
            txtName.Enabled = true;
            groupBox1.Enabled = true;
            dataGridView1.DataSource = DBNull.Value;
        }
    }
}