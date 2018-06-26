// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 09-12-2012
// ***********************************************************************
// <copyright file="FindItem.cs" company="Beauty4u">
//     Copyright © Beauty4u 2009
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

/// <summary>
/// The Register namespace.
/// </summary>
namespace Register
{
    /// <summary>
    /// Class FindItem.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class FindItem : Form
    {
        /// <summary>
        /// The index1
        /// </summary>
        /// <summary>
        /// The index2
        /// </summary>
        /// <summary>
        /// The index3
        /// </summary>
        int index1, index2, index3;
        /// <summary>
        /// The sp
        /// </summary>
        string sp;
        /// <summary>
        /// The itm brand
        /// </summary>
        /// <summary>
        /// The itm color
        /// </summary>
        /// <summary>
        /// The itm size
        /// </summary>
        /// <summary>
        /// The itm name
        /// </summary>
        /// <summary>
        /// The itm upc
        /// </summary>
        string ItmBrand, ItmColor, ItmSize, ItmName, ItmUpc;
        /// <summary>
        /// The brand bool number
        /// </summary>
        /// <summary>
        /// The size bool number
        /// </summary>
        /// <summary>
        /// The color bool number
        /// </summary>
        /// <summary>
        /// The name bool number
        /// </summary>
        /// <summary>
        /// The upc bool number
        /// </summary>
        /// <summary>
        /// The total bool number
        /// </summary>
        int brandBoolNum, sizeBoolNum, colorBoolNum, nameBoolNum, upcBoolNum, totalBoolNum;
        /// <summary>
        /// The dt
        /// </summary>
        public DataTable dt = new DataTable();

        /// <summary>
        /// The DRV font
        /// </summary>
        public Font drvFont = new Font("Arial", 10, FontStyle.Bold);
        /// <summary>
        /// The nfi
        /// </summary>
        NumberFormatInfo nfi = new NumberFormatInfo();

        //string getUpc = string.Empty;

        /// <summary>
        /// The parent form
        /// </summary>
        public MainForm parentForm;

        /// <summary>
        /// Initializes a new instance of the <see cref="FindItem"/> class.
        /// </summary>
        public FindItem()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the FindItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FindItem_Load(object sender, EventArgs e)
        {
            nfi.CurrencySymbol = Application.CurrentCulture.NumberFormat.CurrencySymbol;
            nfi.CurrencyNegativePattern = 1;

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

            txtName.Select();
            txtName.Focus();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbCategory1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbCategory2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Click event of the btnBrand control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Click event of the btnColor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Click event of the btnSize control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Click event of the btnSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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
                sp = "Show_With_Conditions";
                dataGridView2.RowTemplate.Height = 40;
                dataGridView2.RowTemplate.DefaultCellStyle.Font = drvFont;
                dataGridView2.DataSource = DataBind(totalBoolNum, sp, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);


                dataGridView2.Columns[0].HeaderText = "Brand";
                dataGridView2.Columns[0].Width = 140;
                dataGridView2.Columns[1].HeaderText = "Name";
                dataGridView2.Columns[1].Width = 280;
                dataGridView2.Columns[2].HeaderText = "Size";
                dataGridView2.Columns[2].Width = 80;
                dataGridView2.Columns[3].HeaderText = "Color";
                dataGridView2.Columns[3].Width = 80;
                dataGridView2.Columns[4].HeaderText = "Style #";
                dataGridView2.Columns[4].Width = 110;
                dataGridView2.Columns[5].Visible = false;
                dataGridView2.Columns[6].HeaderText = "Regular Price";
                dataGridView2.Columns[6].DefaultCellStyle.FormatProvider = nfi;
                dataGridView2.Columns[6].DefaultCellStyle.Format = "c";
                dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView2.Columns[6].Width = 80;
                dataGridView2.Columns[7].Visible = false;
                dataGridView2.Columns[8].Visible = false;
                dataGridView2.Columns[9].HeaderText = "UPC";
                dataGridView2.Columns[9].Width = 120;
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
                        sp = "Show_Category_1_2_3_With_Conditions";
                        dataGridView2.RowTemplate.Height = 40;
                        dataGridView2.RowTemplate.DefaultCellStyle.Font = drvFont;
                        dataGridView2.DataSource = DataBind(totalBoolNum, sp, index1, index2, index3, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);


                        dataGridView2.Columns[0].HeaderText = "Brand";
                        dataGridView2.Columns[0].Width = 140;
                        dataGridView2.Columns[1].HeaderText = "Name";
                        dataGridView2.Columns[1].Width = 280;
                        dataGridView2.Columns[2].HeaderText = "Size";
                        dataGridView2.Columns[2].Width = 80;
                        dataGridView2.Columns[3].HeaderText = "Color";
                        dataGridView2.Columns[3].Width = 80;
                        dataGridView2.Columns[4].HeaderText = "Style #";
                        dataGridView2.Columns[4].Width = 110;
                        dataGridView2.Columns[5].Visible = false;
                        dataGridView2.Columns[6].HeaderText = "Regular Price";
                        dataGridView2.Columns[6].DefaultCellStyle.FormatProvider = nfi;
                        dataGridView2.Columns[6].DefaultCellStyle.Format = "c";
                        dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[6].Width = 80;
                        dataGridView2.Columns[7].Visible = false;
                        dataGridView2.Columns[8].Visible = false;
                        dataGridView2.Columns[9].HeaderText = "UPC";
                        dataGridView2.Columns[9].Width = 120;
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
                        sp = "Show_Category_1_2_With_Conditions";
                        dataGridView2.RowTemplate.Height = 40;
                        dataGridView2.RowTemplate.DefaultCellStyle.Font = drvFont;
                        dataGridView2.DataSource = DataBind(totalBoolNum, sp, index1, index2, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);

                        dataGridView2.Columns[0].HeaderText = "Brand";
                        dataGridView2.Columns[0].Width = 140;
                        dataGridView2.Columns[1].HeaderText = "Name";
                        dataGridView2.Columns[1].Width = 280;
                        dataGridView2.Columns[2].HeaderText = "Size";
                        dataGridView2.Columns[2].Width = 80;
                        dataGridView2.Columns[3].HeaderText = "Color";
                        dataGridView2.Columns[3].Width = 80;
                        dataGridView2.Columns[4].HeaderText = "Style #";
                        dataGridView2.Columns[4].Width = 110;
                        dataGridView2.Columns[5].Visible = false;
                        dataGridView2.Columns[6].HeaderText = "Regular Price";
                        dataGridView2.Columns[6].DefaultCellStyle.FormatProvider = nfi;
                        dataGridView2.Columns[6].DefaultCellStyle.Format = "c";
                        dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[6].Width = 80;
                        dataGridView2.Columns[7].Visible = false;
                        dataGridView2.Columns[8].Visible = false;
                        dataGridView2.Columns[9].HeaderText = "UPC";
                        dataGridView2.Columns[9].Width = 120;
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
                    sp = "Show_Category_1_With_Conditions";
                    dataGridView2.RowTemplate.Height = 40;
                    dataGridView2.RowTemplate.DefaultCellStyle.Font = drvFont;
                    dataGridView2.DataSource = DataBind(totalBoolNum, sp, index1, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);

                    dataGridView2.Columns[0].HeaderText = "Brand";
                    dataGridView2.Columns[0].Width = 140;
                    dataGridView2.Columns[1].HeaderText = "Name";
                    dataGridView2.Columns[1].Width = 280;
                    dataGridView2.Columns[2].HeaderText = "Size";
                    dataGridView2.Columns[2].Width = 80;
                    dataGridView2.Columns[3].HeaderText = "Color";
                    dataGridView2.Columns[3].Width = 80;
                    dataGridView2.Columns[4].HeaderText = "Style #";
                    dataGridView2.Columns[4].Width = 110;
                    dataGridView2.Columns[5].Visible = false;
                    dataGridView2.Columns[6].HeaderText = "Regular Price";
                    dataGridView2.Columns[6].DefaultCellStyle.FormatProvider = nfi;
                    dataGridView2.Columns[6].DefaultCellStyle.Format = "c";
                    dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns[6].Width = 80;
                    dataGridView2.Columns[7].Visible = false;
                    dataGridView2.Columns[8].Visible = false;
                    dataGridView2.Columns[9].HeaderText = "UPC";
                    dataGridView2.Columns[9].Width = 120;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnReset control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

            txtName.SelectAll();
            txtName.Focus();
        }

        /// <summary>
        /// Handles the Click event of the btnClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            parentForm.Enabled = true;
            this.Close();
            parentForm.richTxtUpc.Select();
            parentForm.richTxtUpc.Focus();
        }

        /// <summary>
        /// Datas the bind.
        /// </summary>
        /// <param name="sp">The sp.</param>
        /// <returns>DataTable.</returns>
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

        /// <summary>
        /// Datas the bind.
        /// </summary>
        /// <param name="totalBoolNum">The total bool number.</param>
        /// <param name="sp">The sp.</param>
        /// <param name="ItmBrand">The itm brand.</param>
        /// <param name="ItmSize">Size of the itm.</param>
        /// <param name="ItmColor">Color of the itm.</param>
        /// <param name="ItmName">Name of the itm.</param>
        /// <param name="ItmUpc">The itm upc.</param>
        /// <returns>DataTable.</returns>
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

        /// <summary>
        /// Datas the bind.
        /// </summary>
        /// <param name="totalBoolNum">The total bool number.</param>
        /// <param name="sp">The sp.</param>
        /// <param name="index1">The index1.</param>
        /// <param name="ItmBrand">The itm brand.</param>
        /// <param name="ItmSize">Size of the itm.</param>
        /// <param name="ItmColor">Color of the itm.</param>
        /// <param name="ItmName">Name of the itm.</param>
        /// <param name="ItmUpc">The itm upc.</param>
        /// <returns>DataTable.</returns>
        public DataTable DataBind(int totalBoolNum, string sp, int index1, string ItmBrand, string ItmSize, string ItmColor, string ItmName, string ItmUpc)
        {
            SqlCommand cmd = new SqlCommand(sp, parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
            cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
            cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = "%" + ItmBrand + "%";
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

        /// <summary>
        /// Datas the bind.
        /// </summary>
        /// <param name="totalBoolNum">The total bool number.</param>
        /// <param name="sp">The sp.</param>
        /// <param name="index1">The index1.</param>
        /// <param name="index2">The index2.</param>
        /// <param name="ItmBrand">The itm brand.</param>
        /// <param name="ItmSize">Size of the itm.</param>
        /// <param name="ItmColor">Color of the itm.</param>
        /// <param name="ItmName">Name of the itm.</param>
        /// <param name="ItmUpc">The itm upc.</param>
        /// <returns>DataTable.</returns>
        public DataTable DataBind(int totalBoolNum, string sp, int index1, int index2, string ItmBrand, string ItmSize, string ItmColor, string ItmName, string ItmUpc)
        {
            SqlCommand cmd = new SqlCommand(sp, parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
            cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
            cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = index2;
            cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = "%" + ItmBrand + "%";
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

        /// <summary>
        /// Datas the bind.
        /// </summary>
        /// <param name="totalBoolNum">The total bool number.</param>
        /// <param name="sp">The sp.</param>
        /// <param name="index1">The index1.</param>
        /// <param name="index2">The index2.</param>
        /// <param name="index3">The index3.</param>
        /// <param name="ItmBrand">The itm brand.</param>
        /// <param name="ItmSize">Size of the itm.</param>
        /// <param name="ItmColor">Color of the itm.</param>
        /// <param name="ItmName">Name of the itm.</param>
        /// <param name="ItmUpc">The itm upc.</param>
        /// <returns>DataTable.</returns>
        public DataTable DataBind(int totalBoolNum, string sp, int index1, int index2, int index3, string ItmBrand, string ItmSize, string ItmColor, string ItmName, string ItmUpc)
        {
            SqlCommand cmd = new SqlCommand(sp, parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
            cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
            cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = index2;
            cmd.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = index3;
            cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = "%" + ItmBrand + "%";
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

        /// <summary>
        /// Handles the Click event of the btnSelect control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            //getUpc = Convert.ToString(dataGridView2.SelectedCells[9].Value);
            //parentForm.richTxtUpc.Text = getUpc;
            //getUpc = string.Empty;

            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                if (dataGridView2.Rows[i].Selected == true)
                {
                    parentForm.richTxtUpc.Text = Convert.ToString(dataGridView2.Rows[i].Cells[9].Value).ToUpper();
                    parentForm.btnInput_Click(null, null);
                }
            }

            /*parentForm.Enabled = true;
            this.Close();
            //parentForm.btnInput_Click(null, null);
            parentForm.richTxtUpc.Select();
            parentForm.richTxtUpc.Focus();*/
        }
    }
}