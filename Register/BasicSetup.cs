// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 11-05-2015
// ***********************************************************************
// <copyright file="BasicSetup.cs" company="Beauty4u">
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
    /// Class BasicSetup.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class BasicSetup : Form
    {
        /// <summary>
        /// The parent form
        /// </summary>
        public MainForm parentForm;
        /// <summary>
        /// The DRV font
        /// </summary>
        public Font drvFont = new Font("Arial", 10, FontStyle.Bold);
        /// <summary>
        /// The CMD1
        /// </summary>
        SqlCommand cmd1;
        /// <summary>
        /// The CMD2
        /// </summary>
        SqlCommand cmd2;
        /// <summary>
        /// The CMD3
        /// </summary>
        SqlCommand cmd3;
        /// <summary>
        /// The DT1
        /// </summary>
        DataTable dt1 = new DataTable();
        /// <summary>
        /// The DT2
        /// </summary>
        DataTable dt2 = new DataTable();
        /// <summary>
        /// The DT3
        /// </summary>
        DataTable dt3 = new DataTable();

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicSetup"/> class.
        /// </summary>
        public BasicSetup()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the BasicSetup control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BasicSetup_Load(object sender, EventArgs e)
        {
            try
            {
                cmd1 = new SqlCommand("Loading_StoreBasicSetup", parentForm.conn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Clear();
                cmd1.Parameters.Add("@StoreName", SqlDbType.NVarChar).Value = parentForm.storeName.ToUpper();
                SqlDataAdapter adapt1 = new SqlDataAdapter();
                adapt1.SelectCommand = cmd1;

                cmd2 = new SqlCommand("Loading_HardwareSetup", parentForm.conn);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Clear();
                SqlDataAdapter adapt2 = new SqlDataAdapter();
                adapt2.SelectCommand = cmd2;

                cmd3 = new SqlCommand("Loading_ShortcutKey", parentForm.conn);
                cmd3.CommandType = CommandType.StoredProcedure;
                cmd3.Parameters.Clear();
                SqlDataAdapter adapt3 = new SqlDataAdapter();
                adapt3.SelectCommand = cmd3;

                parentForm.conn.Open();
                adapt1.Fill(dt1);
                adapt2.Fill(dt2);
                adapt3.Fill(dt3);
                parentForm.conn.Close();

                dataGridView1.RowTemplate.Height = 45;
                dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                dataGridView1.DataSource = dt1;
                dataGridView1.Columns[0].HeaderText = "STORE NAME";
                dataGridView1.Columns[0].Width = 150;
                dataGridView1.Columns[1].HeaderText = "STORE CODE";
                dataGridView1.Columns[1].Width = 45;
                dataGridView1.Columns[2].HeaderText = "STREET";
                dataGridView1.Columns[2].Width = 250;
                dataGridView1.Columns[3].HeaderText = "CITY";
                dataGridView1.Columns[3].Width = 150;
                dataGridView1.Columns[4].HeaderText = "STATE";
                dataGridView1.Columns[4].Width = 45;
                dataGridView1.Columns[5].HeaderText = "ZIP CODE";
                dataGridView1.Columns[5].Width = 50;
                dataGridView1.Columns[6].HeaderText = "TELEPHONE";
                dataGridView1.Columns[6].Width = 100;
                dataGridView1.Columns[7].HeaderText = "STREET MARGIN";
                dataGridView1.Columns[7].Width = 40;
                dataGridView1.Columns[8].HeaderText = "CITY/STATE MARGIN";
                dataGridView1.Columns[8].Width = 40;
                dataGridView1.Columns[9].HeaderText = "TELEPHONE MARGIN";
                dataGridView1.Columns[9].Width = 40;
                dataGridView1.Columns[10].HeaderText = "TAX RATE";
                dataGridView1.Columns[10].Width = 55;
                dataGridView1.Columns[11].HeaderText = "PC CHARGE PATH";
                dataGridView1.Columns[11].Width = 40;
                dataGridView1.Columns[12].HeaderText = "PRC";
                dataGridView1.Columns[12].Width = 40;
                dataGridView1.Columns[13].HeaderText = "MERCHANT NUMBER";
                dataGridView1.Columns[13].Width = 180;
                dataGridView1.Columns[14].HeaderText = "PC CHARGE USER1";
                dataGridView1.Columns[14].Width = 50;
                dataGridView1.Columns[15].HeaderText = "PC CHARGE USER2";
                dataGridView1.Columns[15].Width = 50;
                dataGridView1.Columns[16].HeaderText = "PC CHARGE USER3";
                dataGridView1.Columns[16].Width = 50;
                dataGridView1.Columns[17].HeaderText = "PC CHARGE USER4";
                dataGridView1.Columns[17].Width = 50;
                dataGridView1.Columns[18].HeaderText = "PC CHARGE LOGIN ID";
                dataGridView1.Columns[18].Width = 80;
                dataGridView1.Columns[19].HeaderText = "PC CHARGE PASSWORD";
                dataGridView1.Columns[19].Width = 100;

                dataGridView2.RowTemplate.Height = 45;
                dataGridView2.RowTemplate.DefaultCellStyle.Font = drvFont;
                dataGridView2.DataSource = dt2;
                dataGridView2.Columns[0].HeaderText = "STORE CODE";
                dataGridView2.Columns[0].Width = 120;
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[1].HeaderText = "RECEIPT PRINTER TYPE";
                dataGridView2.Columns[1].Width = 120;
                dataGridView2.Columns[2].HeaderText = "RECEIPT PRINTER NAME";
                dataGridView2.Columns[2].Width = 120;
                dataGridView2.Columns[3].HeaderText = "RECEIPT PRINTER PORT";
                dataGridView2.Columns[3].Width = 120;
                dataGridView2.Columns[4].HeaderText = "VFD COMMAND TYPE";
                dataGridView2.Columns[4].Width = 120;
                dataGridView2.Columns[5].HeaderText = "VFD NAME";
                dataGridView2.Columns[5].Width = 120;
                dataGridView2.Columns[6].HeaderText = "VFD PORT";
                dataGridView2.Columns[6].Width = 120;
                dataGridView2.Columns[7].HeaderText = "VFD BAUD RATE";
                dataGridView2.Columns[7].Width = 120;

                dataGridView3.RowTemplate.Height = 45;
                dataGridView3.RowTemplate.DefaultCellStyle.Font = drvFont;
                dataGridView3.DataSource = dt3;
                dataGridView3.Columns[0].HeaderText = "F1";
                dataGridView3.Columns[0].Width = 120;
                dataGridView3.Columns[1].HeaderText = "F2";
                dataGridView3.Columns[1].Width = 120;
                dataGridView3.Columns[2].HeaderText = "F3";
                dataGridView3.Columns[2].Width = 120;
                dataGridView3.Columns[3].HeaderText = "F4";
                dataGridView3.Columns[3].Width = 120;
                dataGridView3.Columns[4].HeaderText = "F5";
                dataGridView3.Columns[4].Width = 120;
                dataGridView3.Columns[5].HeaderText = "F6";
                dataGridView3.Columns[5].Width = 120;
                dataGridView3.Columns[6].HeaderText = "F7";
                dataGridView3.Columns[6].Width = 120;
                dataGridView3.Columns[7].HeaderText = "F8";
                dataGridView3.Columns[7].Width = 120;
                dataGridView3.Columns[8].HeaderText = "F9";
                dataGridView3.Columns[8].Width = 120;
                dataGridView3.Columns[9].HeaderText = "F10";
                dataGridView3.Columns[9].Width = 120;
                dataGridView3.Columns[10].HeaderText = "F11";
                dataGridView3.Columns[10].Width = 120;
                dataGridView3.Columns[11].HeaderText = "F12";
                dataGridView3.Columns[11].Width = 120;
            }
            catch
            {
            }
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
        /// Handles the Click event of the btnSaveStoreBasicSetup control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSaveStoreBasicSetup_Click(object sender, EventArgs e)
        {
            try
            {
                cmd1 = new SqlCommand("Save_StoreBasicSetup", parentForm.conn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Clear();
                cmd1.Parameters.Add("@StoreName", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[0].Cells[0].Value).ToUpper();
                cmd1.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[0].Cells[1].Value).ToUpper();
                cmd1.Parameters.Add("@StoreStreet", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[0].Cells[2].Value).ToUpper();
                cmd1.Parameters.Add("@StoreCity", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[0].Cells[3].Value).ToUpper();
                cmd1.Parameters.Add("@StoreState", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[0].Cells[4].Value).ToUpper();
                cmd1.Parameters.Add("@StoreZipCode", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[0].Cells[5].Value);
                cmd1.Parameters.Add("@StoreTelephone", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[0].Cells[6].Value);
                cmd1.Parameters.Add("@StoreStreetMargin", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[0].Cells[7].Value);
                cmd1.Parameters.Add("@StoreCityStateMargin", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[0].Cells[8].Value);
                cmd1.Parameters.Add("@StoreTelephoneMargin", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[0].Cells[9].Value);
                cmd1.Parameters.Add("@StoreTaxRate", SqlDbType.NVarChar).Value = Convert.ToDouble(dataGridView1.Rows[0].Cells[10].Value);
                cmd1.Parameters.Add("@StorePcChargePath", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[0].Cells[11].Value);
                cmd1.Parameters.Add("@StoreProcessor", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[0].Cells[12].Value);
                cmd1.Parameters.Add("@StoreMerchantNum", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[0].Cells[13].Value);
                cmd1.Parameters.Add("@StorePcChargeUser1", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[0].Cells[14].Value);
                cmd1.Parameters.Add("@StorePcChargeUser2", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[0].Cells[15].Value);
                cmd1.Parameters.Add("@StorePcChargeUser3", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[0].Cells[16].Value);
                cmd1.Parameters.Add("@StorePcChargeUser4", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[0].Cells[17].Value);
                cmd1.Parameters.Add("@StorePcchargeLoginID", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[0].Cells[18].Value);
                cmd1.Parameters.Add("@StorePcChargePassword", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[0].Cells[19].Value);

                parentForm.conn.Open();
                cmd1.ExecuteNonQuery();
                parentForm.conn.Close();

                MyMessageBox.ShowBox("SUCCESSFULLY SAVED", "INFORMATION");
            }
            catch
            {
                MyMessageBox.ShowBox("SAVE FAILED", "ERROR");
                parentForm.conn.Close();
                return;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSaveHardwareSetup control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSaveHardwareSetup_Click(object sender, EventArgs e)
        {
            try
            {
                cmd1 = new SqlCommand("Save_HardwareSetup", parentForm.conn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Clear();
                cmd1.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[0].Cells[0].Value).ToUpper();
                cmd1.Parameters.Add("@ReceiptPrinterType", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[0].Cells[1].Value);
                cmd1.Parameters.Add("@ReceiptPrinterName", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[0].Cells[2].Value).ToUpper();
                cmd1.Parameters.Add("@ReceiptPrinterPort", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[0].Cells[3].Value);
                cmd1.Parameters.Add("@VFDCommandType", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[0].Cells[4].Value);
                cmd1.Parameters.Add("@VFDName", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[0].Cells[5].Value);
                cmd1.Parameters.Add("@VFDPort", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[0].Cells[6].Value).ToUpper();
                cmd1.Parameters.Add("@VFDBaudRate", SqlDbType.Int).Value = Convert.ToInt16(dataGridView2.Rows[0].Cells[7].Value);

                parentForm.conn.Open();
                cmd1.ExecuteNonQuery();
                parentForm.conn.Close();

                MyMessageBox.ShowBox("SUCCESSFULLY SAVED", "INFORMATION");
            }
            catch
            {
                MyMessageBox.ShowBox("SAVE FAILED", "ERROR");
                parentForm.conn.Close();
                return;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSaveShortcutKey control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSaveShortcutKey_Click(object sender, EventArgs e)
        {
            try
            {
                cmd2 = new SqlCommand("Save_ShortcutKey", parentForm.conn);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Clear();
                cmd2.Parameters.Add("@F1Value", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView3.Rows[0].Cells[0].Value).ToUpper();
                cmd2.Parameters.Add("@F2Value", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView3.Rows[0].Cells[1].Value).ToUpper();
                cmd2.Parameters.Add("@F3Value", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView3.Rows[0].Cells[2].Value).ToUpper();
                cmd2.Parameters.Add("@F4Value", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView3.Rows[0].Cells[3].Value).ToUpper();
                cmd2.Parameters.Add("@F5Value", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView3.Rows[0].Cells[4].Value).ToUpper();
                cmd2.Parameters.Add("@F6Value", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView3.Rows[0].Cells[5].Value).ToUpper();
                cmd2.Parameters.Add("@F7Value", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView3.Rows[0].Cells[6].Value).ToUpper();
                cmd2.Parameters.Add("@F8Value", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView3.Rows[0].Cells[7].Value).ToUpper();
                cmd2.Parameters.Add("@F9Value", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView3.Rows[0].Cells[8].Value).ToUpper();
                cmd2.Parameters.Add("@F10Value", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView3.Rows[0].Cells[9].Value).ToUpper();
                cmd2.Parameters.Add("@F11Value", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView3.Rows[0].Cells[10].Value).ToUpper();
                cmd2.Parameters.Add("@F12Value", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView3.Rows[0].Cells[11].Value).ToUpper();
                
                parentForm.conn.Open();
                cmd2.ExecuteNonQuery();
                parentForm.conn.Close();

                MyMessageBox.ShowBox("SUCCESSFULLY SAVED", "INFORMATION");
            }
            catch
            {
                MyMessageBox.ShowBox("SAVE FAILED", "ERROR");
                parentForm.conn.Close();
                return;
            }
        }
    }
}