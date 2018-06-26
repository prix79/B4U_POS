// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 04-20-2010
// ***********************************************************************
// <copyright file="Jewelry.cs" company="Beauty4u">
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
    /// Class Jewelry.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class Jewelry : Form
    {
        /// <summary>
        /// The parentform
        /// </summary>
        public MainForm parentform;
        /// <summary>
        /// The command page
        /// </summary>
        SqlCommand[] cmd_Page = new SqlCommand[10];
        /// <summary>
        /// The command BTN
        /// </summary>
        SqlCommand[] cmd_Btn = new SqlCommand[200];
        /// <summary>
        /// The page name parameter
        /// </summary>
        SqlParameter[] PageName_Param = new SqlParameter[10];
        /// <summary>
        /// The BTN name parameter
        /// </summary>
        SqlParameter[] BtnName_Param = new SqlParameter[200];
        /// <summary>
        /// The page name
        /// </summary>
        string[] pageName = new string[10];
        /// <summary>
        /// The BTN name
        /// </summary>
        string[] btnName = new string[200];
        /// <summary>
        /// The new tab page
        /// </summary>
        TabPage[] newTabPage = new TabPage[10];
        /// <summary>
        /// The BTN
        /// </summary>
        Button[] btn = new Button[200];

        /// <summary>
        /// The BTN number
        /// </summary>
        int btnNum = 0;
        /// <summary>
        /// The BTN itm number
        /// </summary>
        string btnItmNum = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="Jewelry"/> class.
        /// </summary>
        public Jewelry()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the Jewerly control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Jewerly_Load(object sender, EventArgs e)
        {
            int tabCount = 10;
            int btnCount = 20;
            int temp = 0;
            int i, j, k, l;

            for (i = 0; i < tabCount; i++)
            {
                cmd_Page[i] = new SqlCommand("Get_BtnPage", parentform.conn);
                cmd_Page[i].CommandType = CommandType.StoredProcedure;
                cmd_Page[i].Parameters.Add("@PageNum", SqlDbType.SmallInt).Value = i;
                PageName_Param[i] = cmd_Page[i].Parameters.Add("@PageName", SqlDbType.NVarChar, 50);
                PageName_Param[i].Direction = ParameterDirection.Output;

                parentform.conn.Open();
                cmd_Page[i].ExecuteNonQuery();
                parentform.conn.Close();

                pageName[i] = Convert.ToString(cmd_Page[i].Parameters["@PageName"].Value);

                newTabPage[i] = new TabPage(pageName[i]);
                tabControl1.TabPages.Add(newTabPage[i]);

                k = 1;
                l = 0;

                for (j = temp; j < btnCount; j++)
                {
                    cmd_Btn[j] = new SqlCommand("Get_BtnMenu", parentform.conn);
                    cmd_Btn[j].CommandType = CommandType.StoredProcedure;
                    cmd_Btn[j].Parameters.Add("@BtnNum", SqlDbType.SmallInt).Value = j + 1;
                    BtnName_Param[j] = cmd_Btn[j].Parameters.Add("@BtnName", SqlDbType.NVarChar, 50);
                    BtnName_Param[j].Direction = ParameterDirection.Output;

                    parentform.conn.Open();
                    cmd_Btn[j].ExecuteNonQuery();
                    parentform.conn.Close();

                    btnName[j] = Convert.ToString(cmd_Btn[j].Parameters["@BtnName"].Value);

                    btn[j] = new Button();
                    btn[j].Name = Convert.ToString(j + 1);
                    btn[j].Text = btnName[j];
                    btn[j].Size = new Size(120, 70);

                    switch(k)
                    {
                        case 1:
                            btn[j].Location = new Point(10, 20 + (l * 80));
                            newTabPage[i].Controls.Add(btn[j]);
                            btn[j].Click += new EventHandler(OnButtonClick);
                            break;
                        case 2:
                            btn[j].Location = new Point(140, 20 + (l * 80));
                            newTabPage[i].Controls.Add(btn[j]);
                            btn[j].Click += new EventHandler(OnButtonClick);
                            break;
                        case 3:
                            btn[j].Location = new Point(270, 20 + (l * 80));
                            newTabPage[i].Controls.Add(btn[j]);
                            btn[j].Click += new EventHandler(OnButtonClick);
                            break;
                        case 4:
                            btn[j].Location = new Point(400, 20 + (l * 80));
                            newTabPage[i].Controls.Add(btn[j]);
                            btn[j].Click += new EventHandler(OnButtonClick);
                            break;
                        case 5:
                            btn[j].Location = new Point(530, 20 + (l * 80));
                            newTabPage[i].Controls.Add(btn[j]);
                            btn[j].Click += new EventHandler(OnButtonClick);
                            break;
                    }

                    float f = k % 5;

                    if (f == 0)
                    {
                        k = 1;
                        l += 1;
                    }
                    else
                    {
                        k += 1;
                    }
                }

                temp += 20;
                btnCount += 20;
            }
        }

        /// <summary>
        /// Handles the <see cref="E:ButtonClick" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnButtonClick(object sender, EventArgs e)
        {
            btnNum = Convert.ToInt16(((Control)sender).Name);

            SqlCommand cmd = new SqlCommand("Get_Upc_From_Button", parentform.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BtnNum", SqlDbType.SmallInt).Value = btnNum;
            SqlParameter BtnItmNum_Param = cmd.Parameters.Add("@BtnItmNum", SqlDbType.NVarChar, 50);
            BtnItmNum_Param.Direction = ParameterDirection.Output;

            parentform.conn.Open();
            cmd.ExecuteNonQuery();
            parentform.conn.Close();

            btnItmNum = Convert.ToString(cmd.Parameters["@BtnItmNum"].Value);

            parentform.richTxtUpc.Text = btnItmNum;
            parentform.btnInput_Click(null, null);

            //this.Close();
            //parentform.richTxtUpc.Select();
            //parentform.richTxtUpc.Focus();
        }

        /// <summary>
        /// Handles the Click event of the btnClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            parentform.Enabled = true;
            this.Close();
            parentform.richTxtUpc.Select();
            parentform.richTxtUpc.Focus();
        }

        /// <summary>
        /// Handles the Click event of the btnJewerlyList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnJewerlyList_Click(object sender, EventArgs e)
        {
            JewelryList jewerlyListForm = new JewelryList();
            jewerlyListForm.parentForm = this.parentform;
            jewerlyListForm.ShowDialog();

            this.Close();
        }
    }
}