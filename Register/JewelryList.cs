// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 04-22-2010
// ***********************************************************************
// <copyright file="JewelryList.cs" company="Beauty4u">
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
    /// Class JewelryList.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class JewelryList : Form
    {
        /// <summary>
        /// The parent form
        /// </summary>
        public MainForm parentForm;

        /// <summary>
        /// The index1
        /// </summary>
        /// <summary>
        /// The index2
        /// </summary>
        int index1, index2;
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
        string ItmBrand = "", ItmColor = "", ItmSize = "", ItmName = "", ItmUpc = "";
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

        /// <summary>
        /// The get upc
        /// </summary>
        string getUpc = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="JewelryList"/> class.
        /// </summary>
        public JewelryList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the JewerlyList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void JewerlyList_Load(object sender, EventArgs e)
        {
            nfi.CurrencySymbol = Application.CurrentCulture.NumberFormat.CurrencySymbol;
            nfi.CurrencyNegativePattern = 1;

            index1 = 7;
            index2 = 1;
            sp = "Show_Category_1_2_With_Conditions";
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
            dataGridView1.DataSource = DataBind(0, sp, index1, index2, ItmBrand, ItmSize, ItmColor, ItmName, ItmUpc);

            dataGridView1.Columns[0].HeaderText = "Brand";
            dataGridView1.Columns[0].Width = 140;
            dataGridView1.Columns[1].HeaderText = "Name";
            dataGridView1.Columns[1].Width = 280;
            dataGridView1.Columns[2].HeaderText = "Size";
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].HeaderText = "Color";
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].HeaderText = "Style #";
            dataGridView1.Columns[4].Width = 95;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].HeaderText = "Regular Price";
            dataGridView1.Columns[6].DefaultCellStyle.FormatProvider = nfi;
            dataGridView1.Columns[6].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[6].Width = 80;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].HeaderText = "UPC";
            dataGridView1.Columns[9].Width = 110;
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
            cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
            cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
            cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
            cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = ItmName + "%";
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
        /// Handles the Click event of the btnClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the btnSelect control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                getUpc = Convert.ToString(dataGridView1.SelectedCells[9].Value);
                parentForm.richTxtUpc.Text = getUpc;
                getUpc = string.Empty;

                parentForm.Enabled = true;
                this.Close();
                parentForm.btnInput_Click(null, null);
                parentForm.richTxtUpc.Select();
                parentForm.richTxtUpc.Focus();
            }
        }
    }
}