// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 04-20-2010
// ***********************************************************************
// <copyright file="SelectUpc.cs" company="Beauty4u">
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

/// <summary>
/// The Register namespace.
/// </summary>
namespace Register
{
    /// <summary>
    /// Class SelectUpc.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class SelectUpc : Form
    {
        /// <summary>
        /// The parentform
        /// </summary>
        public MainForm parentform;
        /// <summary>
        /// The upc
        /// </summary>
        string Upc;
        /// <summary>
        /// a
        /// </summary>
        /// <summary>
        /// The b
        /// </summary>
        /// <summary>
        /// The c
        /// </summary>
        /// <summary>
        /// The d
        /// </summary>
        /// <summary>
        /// The f
        /// </summary>
        string a, b, c, d, f;

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectUpc"/> class.
        /// </summary>
        /// <param name="ItmUpc">The itm upc.</param>
        public SelectUpc(string ItmUpc)
        {
            InitializeComponent();
            Upc = ItmUpc;
        }

        /// <summary>
        /// Handles the Load event of the SelectUpc control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SelectUpc_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand("Get_Duplicated_ItmUpc", parentform.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = Upc;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            parentform.conn.Open();
            adapter.Fill(dt);
            parentform.conn.Close();

            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "Brand";
            dataGridView1.Columns[0].Width = 140;
            dataGridView1.Columns[1].HeaderText = "Name";
            dataGridView1.Columns[1].Width = 260;
            dataGridView1.Columns[2].HeaderText = "Size";
            dataGridView1.Columns[2].Width = 55;
            dataGridView1.Columns[3].HeaderText = "Color";
            dataGridView1.Columns[3].Width = 55;
            dataGridView1.Columns[4].HeaderText = "Price";
            dataGridView1.Columns[4].Width = 55;
            dataGridView1.Columns[5].HeaderText = "UPC";
            dataGridView1.Columns[5].Width = 80;
        }

        /// <summary>
        /// Handles the CellClick event of the dataGridView1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.SelectedRows[0].Index;
            a = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
            b = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
            c = Convert.ToString(dataGridView1.Rows[i].Cells[5].Value);
            d = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
            f = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value);
            parentform.ItmBrand = a;
            parentform.ItmName = b;
            parentform.ItmUpc = c;
            parentform.ItmSize = d;
            parentform.ItmColor = f;

            parentform.btnInput_Click(null, null);
            this.Close();
        }

        /// <summary>
        /// Gets a value indicating whether [show without activation].
        /// </summary>
        /// <value><c>true</c> if [show without activation]; otherwise, <c>false</c>.</value>
        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }
    }
}