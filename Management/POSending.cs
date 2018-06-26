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
    public partial class POSending : Form
    {
        public LogInManagements parentForm1;
        public POandReceivingForWarehouse parentForm2;

        public int WHStatus = 0;
        SqlCommand cmd, cmd2;
        DataTable dt = new DataTable();
        SqlDataAdapter adapt = new SqlDataAdapter();
        public Font drvFont = new Font("Arial", 11);
        int checkNum = 0;
        int idx = 0;

        public Int64 POID;
        public string storeCode;
        public string storeName;
        bool workcomplete = false;

        int orderTotalQty = 0, sendingTotalQty = 0;
        double orderTotalAmount = 0, sendingTotalAmount = 0;

        double costPrice;
        double sendingAmount;
        int sendingQty;

        public string createDate, ordererID, shipDate, senderID;

        public POSending(int sts)
        {
            InitializeComponent();
            WHStatus = sts;
        }

        private void POSending_Load(object sender, EventArgs e)
        {
            if (WHStatus == 0)
            {
                btnSend.Enabled = false;
                //btnPrintInvoice.Enabled = false;
                dataGridView1.ReadOnly = true;
            }
            else if (WHStatus == 1)
            {
                btnSend.Enabled = true;
                //btnPrintInvoice.Enabled = true;
                dataGridView1.ReadOnly = false;
            }
            else if (WHStatus == 2)
            {
                btnSend.Enabled = false;
                //btnPrintInvoice.Enabled = true;
                dataGridView1.ReadOnly = true;
            }

            if (parentForm2.storeOption == 0)
            {
                POID = Convert.ToInt64(parentForm2.dataGridView1.SelectedCells[0].Value);
                storeCode = parentForm2.dataGridView1.SelectedCells[1].Value.ToString().ToUpper();
                lblPOStatus.Text = parentForm2.dataGridView1.SelectedCells[10].Value.ToString().ToUpper();
                createDate = parentForm2.dataGridView1.SelectedCells[5].Value.ToString().ToUpper();
                ordererID = parentForm2.dataGridView1.SelectedCells[9].Value.ToString().ToUpper();
                shipDate = parentForm2.dataGridView1.SelectedCells[12].Value.ToString().ToUpper();
                senderID = parentForm2.dataGridView1.SelectedCells[13].Value.ToString().ToUpper();
            }
            else
            {
                POID = Convert.ToInt64(parentForm2.dataGridView1.SelectedCells[0].Value);
                storeCode = parentForm2.dataGridView1.SelectedCells[1].Value.ToString().ToUpper();
                lblPOStatus.Text = parentForm2.dataGridView1.SelectedCells[11].Value.ToString().ToUpper();
                createDate = parentForm2.dataGridView1.SelectedCells[5].Value.ToString().ToUpper();
                ordererID = parentForm2.dataGridView1.SelectedCells[10].Value.ToString().ToUpper();
                shipDate = parentForm2.dataGridView1.SelectedCells[13].Value.ToString().ToUpper();
                senderID = parentForm2.dataGridView1.SelectedCells[14].Value.ToString().ToUpper();
            }

            if (storeCode == "TH")
            {
                this.Text = "P/O SENDING - " + parentForm1.storeName + " (P/O FROM " + Convert.ToString(parentForm2.dataGridView1.SelectedCells[10].Value) + " IN TEMPLE HILLS)";
                storeName = "TEMPLE HILLS";

                if (WHStatus == 0 | WHStatus == 1)
                {
                    cmd = new SqlCommand("Show_POBody_From_Other_Stores", parentForm2.connTH);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    adapt.SelectCommand = cmd;

                    parentForm2.connTH.Open();
                    dt.Clear();
                    adapt.Fill(dt);
                    parentForm2.connTH.Close();
                }
                else
                {
                    cmd = new SqlCommand("Show_POBody_From_Warehouse", parentForm1.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = storeCode; 
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    adapt.SelectCommand = cmd;

                    parentForm1.conn.Open();
                    dt.Clear();
                    adapt.Fill(dt);
                    parentForm1.conn.Close();
                }
            }
            else if (storeCode == "OH")
            {
                this.Text = "P/O SENDING - " + parentForm1.storeName + " (P/O FROM " + Convert.ToString(parentForm2.dataGridView1.SelectedCells[10].Value) + " IN OXON HILL)";
                storeName = "OXON HILL";

                if (WHStatus == 0 | WHStatus == 1)
                {
                    cmd = new SqlCommand("Show_POBody_From_Other_Stores", parentForm2.connOH);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    adapt.SelectCommand = cmd;

                    parentForm2.connOH.Open();
                    dt.Clear();
                    adapt.Fill(dt);
                    parentForm2.connOH.Close();
                }
                else
                {
                    cmd = new SqlCommand("Show_POBody_From_Warehouse", parentForm1.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = storeCode;
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    adapt.SelectCommand = cmd;

                    parentForm1.conn.Open();
                    dt.Clear();
                    adapt.Fill(dt);
                    parentForm1.conn.Close();
                }
            }
            else if (storeCode == "UM")
            {
                this.Text = "P/O SENDING - " + parentForm1.storeName + " (P/O FROM " + Convert.ToString(parentForm2.dataGridView1.SelectedCells[10].Value) + " IN UPPER MARLBORO)";
                storeName = "UPPER MARLBORO";

                if (WHStatus == 0 | WHStatus == 1)
                {
                    cmd = new SqlCommand("Show_POBody_From_Other_Stores", parentForm2.connUM);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    adapt.SelectCommand = cmd;

                    parentForm2.connUM.Open();
                    dt.Clear();
                    adapt.Fill(dt);
                    parentForm2.connUM.Close();
                }
                else
                {
                    cmd = new SqlCommand("Show_POBody_From_Warehouse", parentForm1.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = storeCode;
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    adapt.SelectCommand = cmd;

                    parentForm1.conn.Open();
                    dt.Clear();
                    adapt.Fill(dt);
                    parentForm1.conn.Close();
                }
            }
            else if (storeCode == "CH")
            {
                this.Text = "P/O SENDING - " + parentForm1.storeName + " (P/O FROM " + Convert.ToString(parentForm2.dataGridView1.SelectedCells[10].Value) + " IN CAPITOL HEIGHTS)";
                storeName = "CAPITOL HEIGHTS";

                if (WHStatus == 0 | WHStatus == 1)
                {
                    cmd = new SqlCommand("Show_POBody_From_Other_Stores", parentForm2.connCH);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    adapt.SelectCommand = cmd;

                    parentForm2.connCH.Open();
                    dt.Clear();
                    adapt.Fill(dt);
                    parentForm2.connCH.Close();
                }
                else
                {
                    cmd = new SqlCommand("Show_POBody_From_Warehouse", parentForm1.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = storeCode;
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    adapt.SelectCommand = cmd;

                    parentForm1.conn.Open();
                    dt.Clear();
                    adapt.Fill(dt);
                    parentForm1.conn.Close();
                }
            }
            else if (storeCode == "WM")
            {
                this.Text = "P/O SENDING - " + parentForm1.storeName + " (P/O FROM " + Convert.ToString(parentForm2.dataGridView1.SelectedCells[10].Value) + " IN WINDSOR MILL)";
                storeName = "WINDSOR MILL";

                if (WHStatus == 0 | WHStatus == 1)
                {
                    cmd = new SqlCommand("Show_POBody_From_Other_Stores", parentForm2.connWM);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    adapt.SelectCommand = cmd;

                    parentForm2.connWM.Open();
                    dt.Clear();
                    adapt.Fill(dt);
                    parentForm2.connWM.Close();
                }
                else
                {
                    cmd = new SqlCommand("Show_POBody_From_Warehouse", parentForm1.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = storeCode;
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    adapt.SelectCommand = cmd;

                    parentForm1.conn.Open();
                    dt.Clear();
                    adapt.Fill(dt);
                    parentForm1.conn.Close();
                }
            }
            else if (storeCode == "CV")
            {
                this.Text = "P/O SENDING - " + parentForm1.storeName + " (P/O FROM " + Convert.ToString(parentForm2.dataGridView1.SelectedCells[10].Value) + " IN CATONSVILLE)";
                storeName = "CATONSVILLE";

                if (WHStatus == 0 | WHStatus == 1)
                {
                    cmd = new SqlCommand("Show_POBody_From_Other_Stores", parentForm2.connCV);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    adapt.SelectCommand = cmd;

                    parentForm2.connCV.Open();
                    dt.Clear();
                    adapt.Fill(dt);
                    parentForm2.connCV.Close();
                }
                else
                {
                    cmd = new SqlCommand("Show_POBody_From_Warehouse", parentForm1.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = storeCode;
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    adapt.SelectCommand = cmd;

                    parentForm1.conn.Open();
                    dt.Clear();
                    adapt.Fill(dt);
                    parentForm1.conn.Close();
                }
            }
            else if (storeCode == "WB")
            {
                this.Text = "P/O SENDING - " + parentForm1.storeName + " (P/O FROM " + Convert.ToString(parentForm2.dataGridView1.SelectedCells[10].Value) + " IN WOODBRIDGE)";
                storeName = "WOODBRIDGE";

                if (WHStatus == 0 | WHStatus == 1)
                {
                    cmd = new SqlCommand("Show_POBody_From_Other_Stores", parentForm2.connWB);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    adapt.SelectCommand = cmd;

                    parentForm2.connWB.Open();
                    dt.Clear();
                    adapt.Fill(dt);
                    parentForm2.connWB.Close();
                }
                else
                {
                    cmd = new SqlCommand("Show_POBody_From_Warehouse", parentForm1.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = storeCode;
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    adapt.SelectCommand = cmd;

                    parentForm1.conn.Open();
                    dt.Clear();
                    adapt.Fill(dt);
                    parentForm1.conn.Close();
                }
            }
            else if (storeCode == "WD")
            {
                this.Text = "P/O SENDING - " + parentForm1.storeName + " (P/O FROM " + Convert.ToString(parentForm2.dataGridView1.SelectedCells[10].Value) + " IN WALDORF)";
                storeName = "WALDORF";

                if (WHStatus == 0 | WHStatus == 1)
                {
                    cmd = new SqlCommand("Show_POBody_From_Other_Stores", parentForm2.connWD);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    adapt.SelectCommand = cmd;

                    parentForm2.connWD.Open();
                    dt.Clear();
                    adapt.Fill(dt);
                    parentForm2.connWD.Close();
                }
                else
                {
                    cmd = new SqlCommand("Show_POBody_From_Warehouse", parentForm1.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = storeCode;
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    adapt.SelectCommand = cmd;

                    parentForm1.conn.Open();
                    dt.Clear();
                    adapt.Fill(dt);
                    parentForm1.conn.Close();
                }
            }
            else if (storeCode == "PW")
            {
                this.Text = "P/O SENDING - " + parentForm1.storeName + " (P/O FROM " + Convert.ToString(parentForm2.dataGridView1.SelectedCells[10].Value) + " IN PRINCE WILLIAM)";
                storeName = "PRINCE WILLIAM";

                if (WHStatus == 0 | WHStatus == 1)
                {
                    cmd = new SqlCommand("Show_POBody_From_Other_Stores", parentForm2.connPW);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    adapt.SelectCommand = cmd;

                    parentForm2.connPW.Open();
                    dt.Clear();
                    adapt.Fill(dt);
                    parentForm2.connPW.Close();
                }
                else
                {
                    cmd = new SqlCommand("Show_POBody_From_Warehouse", parentForm1.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = storeCode;
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    adapt.SelectCommand = cmd;

                    parentForm1.conn.Open();
                    dt.Clear();
                    adapt.Fill(dt);
                    parentForm1.conn.Close();
                }
            }
            else if (storeCode == "GB")
            {
                this.Text = "P/O SENDING - " + parentForm1.storeName + " (P/O FROM " + Convert.ToString(parentForm2.dataGridView1.SelectedCells[10].Value) + " IN GAITHERSBURG)";
                storeName = "GAITHERSBURG";

                if (WHStatus == 0 | WHStatus == 1)
                {
                    cmd = new SqlCommand("Show_POBody_From_Other_Stores", parentForm2.connGB);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    adapt.SelectCommand = cmd;

                    parentForm2.connGB.Open();
                    dt.Clear();
                    adapt.Fill(dt);
                    parentForm2.connGB.Close();
                }
                else
                {
                    cmd = new SqlCommand("Show_POBody_From_Warehouse", parentForm1.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = storeCode;
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    adapt.SelectCommand = cmd;

                    parentForm1.conn.Open();
                    dt.Clear();
                    adapt.Fill(dt);
                    parentForm1.conn.Close();
                }
            }
            else if (storeCode == "BW")
            {
                this.Text = "P/O SENDING - " + parentForm1.storeName + " (P/O FROM " + Convert.ToString(parentForm2.dataGridView1.SelectedCells[10].Value) + " IN BOWIE)";
                storeName = "BOWIE";

                if (WHStatus == 0 | WHStatus == 1)
                {
                    cmd = new SqlCommand("Show_POBody_From_Other_Stores", parentForm2.connBW);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    adapt.SelectCommand = cmd;

                    parentForm2.connBW.Open();
                    dt.Clear();
                    adapt.Fill(dt);
                    parentForm2.connBW.Close();
                }
                else
                {
                    cmd = new SqlCommand("Show_POBody_From_Warehouse", parentForm1.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = storeCode;
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    adapt.SelectCommand = cmd;

                    parentForm1.conn.Open();
                    dt.Clear();
                    adapt.Fill(dt);
                    parentForm1.conn.Close();
                }
            }

            if (WHStatus == 0)
            {
                dataGridView1.RowTemplate.Height = 40;
                dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "Brand";
                //dataGridView1.Columns[0].Width = 80;
                dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[1].HeaderText = "Name";
                //dataGridView1.Columns[1].Width = 240;
                dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridView1.Columns[1].ReadOnly = true;
                dataGridView1.Columns[2].HeaderText = "Size";
                dataGridView1.Columns[2].Width = 90;
                dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridView1.Columns[2].ReadOnly = true;
                dataGridView1.Columns[3].HeaderText = "Color";
                //dataGridView1.Columns[3].Width = 90;
                dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridView1.Columns[3].ReadOnly = true;
                dataGridView1.Columns[4].HeaderText = "Unit Cost";
                dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[4].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                //dataGridView1.Columns[4].Width = 60;
                dataGridView1.Columns[4].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridView1.Columns[4].ReadOnly = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].HeaderText = "Store Onhand";
                dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //dataGridView1.Columns[5].Width = 60;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].HeaderText = "Order QTY";
                dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[6].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                //dataGridView1.Columns[6].Width = 55;
                dataGridView1.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridView1.Columns[6].ReadOnly = true;
                dataGridView1.Columns[7].HeaderText = "Sending QTY";
                dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[7].DefaultCellStyle.BackColor = Color.NavajoWhite;
                //dataGridView1.Columns[7].Width = 55;
                dataGridView1.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridView1.Columns[7].ReadOnly = false;
                dataGridView1.Columns[8].HeaderText = "Order Amount";
                dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[8].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                //dataGridView1.Columns[8].Width = 65;
                dataGridView1.Columns[8].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridView1.Columns[8].ReadOnly = true;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].HeaderText = "Sending Amount";
                dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[9].DefaultCellStyle.BackColor = Color.NavajoWhite;
                //dataGridView1.Columns[9].Width = 65;
                dataGridView1.Columns[9].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridView1.Columns[9].ReadOnly = true;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].HeaderText = "UPC";
                //dataGridView1.Columns[10].Width = 110;
                dataGridView1.Columns[10].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridView1.Columns[10].ReadOnly = true;
                dataGridView1.Columns[11].HeaderText = "WH Onhand";
                dataGridView1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[11].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                //dataGridView1.Columns[11].Width = 60;
                dataGridView1.Columns[11].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridView1.Columns[11].ReadOnly = true;
                dataGridView1.Columns[12].HeaderText = "Bin#";
                //dataGridView1.Columns[12].Width = 100;
                //dataGridView1.Columns[12].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridView1.Columns[12].ReadOnly = true;

                if (parentForm1.employeeID.ToUpper() == "ADMIN")
                {
                    dataGridView1.Columns[4].Visible = true;
                    dataGridView1.Columns[5].Visible = true;
                    dataGridView1.Columns[8].Visible = true;
                    dataGridView1.Columns[9].Visible = true;
                }

                if (dataGridView1.RowCount > 0)
                {
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        cmd = new SqlCommand("Get_ItmOnHand_To_POSending", parentForm1.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[10].Value);
                        SqlParameter ItmOnHand_Param = cmd.Parameters.Add("@ItmOnHand", SqlDbType.Int);
                        ItmOnHand_Param.Direction = ParameterDirection.Output;

                        parentForm1.conn.Open();
                        cmd.ExecuteNonQuery();
                        parentForm1.conn.Close();

                        if (cmd.Parameters["@ItmOnHand"].Value != DBNull.Value)
                            dataGridView1.Rows[i].Cells[11].Value = Convert.ToInt16(cmd.Parameters["@ItmOnHand"].Value);
                    }
                }
            }
            else if (WHStatus == 1)
            {
                dataGridView1.RowTemplate.Height = 40;
                dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "Brand";
                //dataGridView1.Columns[0].Width = 80;
                dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[1].HeaderText = "Name";
                //dataGridView1.Columns[1].Width = 240;
                dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[1].ReadOnly = true;
                dataGridView1.Columns[2].HeaderText = "Size";
                //dataGridView1.Columns[2].Width = 90;
                dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[2].ReadOnly = true;
                dataGridView1.Columns[3].HeaderText = "Color";
                //dataGridView1.Columns[3].Width = 90;
                dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[3].ReadOnly = true;
                dataGridView1.Columns[4].HeaderText = "Unit Cost";
                dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[4].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                //dataGridView1.Columns[4].Width = 60;
                dataGridView1.Columns[4].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[4].ReadOnly = true;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].HeaderText = "Store Onhand";
                dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //dataGridView1.Columns[5].Width = 60;
                dataGridView1.Columns[5].ReadOnly = true;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].HeaderText = "Order QTY";
                dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[6].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                //dataGridView1.Columns[6].Width = 55;
                dataGridView1.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[6].ReadOnly = true;
                dataGridView1.Columns[7].HeaderText = "Sending QTY";
                dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[7].DefaultCellStyle.BackColor = Color.NavajoWhite;
                //dataGridView1.Columns[7].Width = 55;
                dataGridView1.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[7].ReadOnly = false;
                dataGridView1.Columns[8].HeaderText = "Order Amount";
                dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[8].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                //dataGridView1.Columns[8].Width = 65;
                dataGridView1.Columns[8].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[8].ReadOnly = true;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].HeaderText = "Sending Amount";
                dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[9].DefaultCellStyle.BackColor = Color.NavajoWhite;
                //dataGridView1.Columns[9].Width = 65;
                dataGridView1.Columns[9].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[9].ReadOnly = true;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].HeaderText = "UPC";
                //dataGridView1.Columns[10].Width = 110;
                dataGridView1.Columns[10].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[10].ReadOnly = true;
                dataGridView1.Columns[11].HeaderText = "WH Onhand";
                dataGridView1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[11].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                //dataGridView1.Columns[11].Width = 60;
                dataGridView1.Columns[11].ReadOnly = true;
                dataGridView1.Columns[11].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[12].HeaderText = "Bin#";
                //dataGridView1.Columns[12].Width = 100;
                //dataGridView1.Columns[12].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[12].ReadOnly = true;

                if (parentForm1.employeeID.ToUpper() == "ADMIN")
                {
                    dataGridView1.Columns[4].Visible = true;
                    dataGridView1.Columns[5].Visible = true;
                    dataGridView1.Columns[8].Visible = true;
                    dataGridView1.Columns[9].Visible = true;
                }

                if (dataGridView1.RowCount > 0)
                {
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        cmd = new SqlCommand("Get_ItmOnHand_To_POSending", parentForm1.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[10].Value);
                        SqlParameter ItmOnHand_Param = cmd.Parameters.Add("@ItmOnHand", SqlDbType.Int);
                        ItmOnHand_Param.Direction = ParameterDirection.Output;

                        parentForm1.conn.Open();
                        cmd.ExecuteNonQuery();
                        parentForm1.conn.Close();

                        if (cmd.Parameters["@ItmOnHand"].Value != DBNull.Value)
                            dataGridView1.Rows[i].Cells[11].Value = Convert.ToInt16(cmd.Parameters["@ItmOnHand"].Value);
                    }
                }
            }
            else if (WHStatus == 2)
            {
                dataGridView1.RowTemplate.Height = 40;
                dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "Brand";
                //dataGridView1.Columns[0].Width = 80;
                dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[1].HeaderText = "Name";
                //dataGridView1.Columns[1].Width = 240;
                dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridView1.Columns[1].ReadOnly = true;
                dataGridView1.Columns[2].HeaderText = "Size";
                //dataGridView1.Columns[2].Width = 90;
                dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridView1.Columns[2].ReadOnly = true;
                dataGridView1.Columns[3].HeaderText = "Color";
                //dataGridView1.Columns[3].Width = 90;
                dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridView1.Columns[3].ReadOnly = true;
                dataGridView1.Columns[4].HeaderText = "Unit Cost";
                dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[4].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                //dataGridView1.Columns[4].Width = 60;
                dataGridView1.Columns[4].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridView1.Columns[4].ReadOnly = true;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[5].HeaderText = "Store Onhand";
                dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //dataGridView1.Columns[5].Width = 60;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].HeaderText = "Order QTY";
                dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[6].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                //dataGridView1.Columns[6].Width = 55;
                dataGridView1.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridView1.Columns[6].ReadOnly = true;
                dataGridView1.Columns[7].HeaderText = "Sending QTY";
                dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[7].DefaultCellStyle.BackColor = Color.NavajoWhite;
                //dataGridView1.Columns[7].Width = 55;
                dataGridView1.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridView1.Columns[7].ReadOnly = false;
                dataGridView1.Columns[8].HeaderText = "Order Amount";
                dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[8].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                //dataGridView1.Columns[8].Width = 65;
                dataGridView1.Columns[8].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridView1.Columns[8].ReadOnly = true;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].HeaderText = "Sending Amount";
                dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[9].DefaultCellStyle.BackColor = Color.NavajoWhite;
                //dataGridView1.Columns[9].Width = 65;
                dataGridView1.Columns[9].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridView1.Columns[9].ReadOnly = true;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].HeaderText = "UPC";
                //dataGridView1.Columns[10].Width = 110;
                dataGridView1.Columns[10].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridView1.Columns[10].ReadOnly = true;
                dataGridView1.Columns[11].HeaderText = "Previous WH Onhand";
                dataGridView1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[11].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                //dataGridView1.Columns[11].Width = 60;
                dataGridView1.Columns[11].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[12].HeaderText = "Bin#";
                //dataGridView1.Columns[12].Width = 100;
                dataGridView1.Columns[12].SortMode = DataGridViewColumnSortMode.NotSortable;

                if (parentForm1.employeeID.ToUpper() == "ADMIN")
                {
                    dataGridView1.Columns[4].Visible = true;
                    dataGridView1.Columns[5].Visible = true;
                    dataGridView1.Columns[8].Visible = true;
                    dataGridView1.Columns[9].Visible = true;
                }
            }

            sendingTotalQty = 0;
            sendingTotalAmount = 0;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                costPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                sendingQty = Convert.ToInt16(dataGridView1.Rows[i].Cells[7].Value);
                sendingAmount = Math.Round(costPrice * sendingQty, 2, MidpointRounding.AwayFromZero);

                sendingTotalAmount = sendingTotalAmount + sendingAmount;
            }

            lblSendingTotalAmount.Text = string.Format("{0:$0.00}", sendingTotalAmount);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
            {
                if (DBConnectionStatus(parentForm1.OtherStoreConnectionString(storeCode)) == false)
                {
                    MessageBox.Show(storeName + "DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    checkNum = CheckDuplicatedUpc(dataGridView1.Rows[i].Cells[10].Value.ToString());

                    if (checkNum == 0)
                    {
                        MessageBox.Show("COULD NOT FOUND " + Convert.ToString(dataGridView1.Rows[i].Cells[10].Value) + " (ROW " + Convert.ToString(i + 1) + ") IN THE INVENTORY", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        checkNum = 0;
                        return;
                    }
                    else if (checkNum > 1)
                    {
                        MessageBox.Show(Convert.ToString(dataGridView1.Rows[i].Cells[10].Value) + " (ROW " + Convert.ToString(i + 1) + ") IS DUPLICATED UPC", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        checkNum = 0;
                        return;
                    }
                    else if (checkNum == -1)
                    {
                        MessageBox.Show("DB UPDATE FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        checkNum = 0;
                        return;
                    }
                    else
                    {
                        checkNum = 0;
                    }
                }

                progressBar1.Minimum = 0;
                progressBar1.Maximum = dataGridView1.RowCount + 1;
                progressBar1.Step = 1;

                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            /*if (parentForm2.IsDisposed == false)
                parentForm2.SearchPOList();

            this.Close();*/

            this.Close();
        }

        private void btnOnHandCheck_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    cmd = new SqlCommand("Get_ItmOnHand_To_POSending", parentForm1.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[10].Value);
                    SqlParameter ItmOnHand_Param = cmd.Parameters.Add("@ItmOnHand", SqlDbType.Int);
                    ItmOnHand_Param.Direction = ParameterDirection.Output;

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    if (cmd.Parameters["@ItmOnHand"].Value != DBNull.Value)
                        dataGridView1.Rows[i].Cells[11].Value = Convert.ToInt16(cmd.Parameters["@ItmOnHand"].Value);
                }
            }
        }

        public int CheckDuplicatedUpc(string upc)
        {
            try
            {
                cmd = new SqlCommand("Check_Upc", parentForm1.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = upc;
                SqlParameter CheckNum_Param = cmd.Parameters.Add("@CheckNum", SqlDbType.Int);
                CheckNum_Param.Direction = ParameterDirection.Output;

                parentForm1.conn.Open();
                cmd.ExecuteNonQuery();
                parentForm1.conn.Close();

                if (cmd.Parameters["@CheckNum"].Value == DBNull.Value)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt16(cmd.Parameters["@CheckNum"].Value);
                }
            }
            catch
            {
                MessageBox.Show("DUPLICATE UPC CHECKING FAILED OR CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                parentForm1.conn.Close();
                return -1;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.Connection = parentForm1.conn;

                for (idx = 0; idx < dataGridView1.RowCount; idx++)
                {
                    cmd.CommandText = "Check_OnHand";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[idx].Cells[10].Value);
                    SqlParameter CheckOnHand_Param = cmd.Parameters.Add("@ItmOnHand", SqlDbType.Int);
                    CheckOnHand_Param.Direction = ParameterDirection.Output;

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    if (cmd.Parameters["@ItmOnHand"].Value == DBNull.Value)
                    {
                        MessageBox.Show("UPDATE FAILED (ERROR IN ROW " + Convert.ToString(idx + 1) + ")\n" + "CHECK UPC NUMBER IN INVENTORY", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        cmd.CommandText = "Update_SendingPO_To_Inventory";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        //cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[idx].Cells[2].Value);
                        //cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value);
                        cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[idx].Cells[10].Value);
                        cmd.Parameters.Add("@SendingQty", SqlDbType.Int).Value = Convert.ToInt16(dataGridView1.Rows[idx].Cells[7].Value);

                        parentForm1.conn.Open();
                        cmd.ExecuteNonQuery();
                        parentForm1.conn.Close();
                    }

                    cmd.CommandText = "Create_POWarehouseBody";
                    cmd.Connection = parentForm1.conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = storeCode;
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    cmd.Parameters.Add("@POItemIndex", SqlDbType.Int).Value = idx + 1;
                    cmd.Parameters.Add("@POItemBrand", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[idx].Cells[0].Value);
                    cmd.Parameters.Add("@POItemName", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[idx].Cells[1].Value);
                    cmd.Parameters.Add("@POItemSize", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[idx].Cells[2].Value);
                    cmd.Parameters.Add("@POItemColor", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[idx].Cells[3].Value);
                    cmd.Parameters.Add("@POItemCostPrice", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[idx].Cells[4].Value);
                    cmd.Parameters.Add("@POItemOnHand", SqlDbType.Int).Value = Convert.ToInt16(dataGridView1.Rows[idx].Cells[5].Value);
                    cmd.Parameters.Add("@POItemOrderQty", SqlDbType.Int).Value = Convert.ToInt16(dataGridView1.Rows[idx].Cells[6].Value);
                    cmd.Parameters.Add("@POItemReceivingQty", SqlDbType.Int).Value = Convert.ToInt16(dataGridView1.Rows[idx].Cells[7].Value);
                    cmd.Parameters.Add("@POItemOrderAmount", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[idx].Cells[8].Value);
                    cmd.Parameters.Add("@POItemReceivingAmount", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[idx].Cells[9].Value);
                    cmd.Parameters.Add("@POItemUpc", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[idx].Cells[10].Value);
                    cmd.Parameters.Add("@POItemBin", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[idx].Cells[12].Value);

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    backgroundWorker1.ReportProgress(idx + 1);
                }

                workcomplete = true;
            }
            catch
            {
                MessageBox.Show("DB UPDATE FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                parentForm1.conn.Close();
                return;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (workcomplete == true)
            {
                if (storeCode == "TH")
                {
                    cmd = new SqlCommand("Update_POWarehouseStatus", parentForm2.connTH);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    //cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = storeCode;
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    cmd.Parameters.Add("@WarehouseStatus", SqlDbType.NVarChar).Value = 2;
                    cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                    cmd.Parameters.Add("@SenderID", SqlDbType.NVarChar).Value = parentForm1.employeeID.ToUpper();

                    cmd2 = new SqlCommand("Update_POHeader", parentForm2.connTH);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Clear();
                    cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                    cmd2.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    cmd2.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                    cmd2.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                    cmd2.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "SENT";

                    parentForm2.connTH.Open();
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    parentForm2.connTH.Close();
                }
                else if (storeCode == "OH")
                {
                    cmd = new SqlCommand("Update_POWarehouseStatus", parentForm2.connOH);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    //cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = storeCode;
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    cmd.Parameters.Add("@WarehouseStatus", SqlDbType.NVarChar).Value = 2;
                    cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                    cmd.Parameters.Add("@SenderID", SqlDbType.NVarChar).Value = parentForm1.employeeID.ToUpper();

                    cmd2 = new SqlCommand("Update_POHeader", parentForm2.connOH);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Clear();
                    cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                    cmd2.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    cmd2.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                    cmd2.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                    cmd2.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "SENT";

                    parentForm2.connOH.Open();
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    parentForm2.connOH.Close();
                }
                else if (storeCode == "UM")
                {
                    cmd = new SqlCommand("Update_POWarehouseStatus", parentForm2.connUM);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    //cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = storeCode;
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    cmd.Parameters.Add("@WarehouseStatus", SqlDbType.NVarChar).Value = 2;
                    cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                    cmd.Parameters.Add("@SenderID", SqlDbType.NVarChar).Value = parentForm1.employeeID.ToUpper();

                    cmd2 = new SqlCommand("Update_POHeader", parentForm2.connUM);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Clear();
                    cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                    cmd2.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    cmd2.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                    cmd2.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                    cmd2.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "SENT";

                    parentForm2.connUM.Open();
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    parentForm2.connUM.Close();
                }
                else if (storeCode == "CH")
                {
                    cmd = new SqlCommand("Update_POWarehouseStatus", parentForm2.connCH);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    //cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = storeCode;
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    cmd.Parameters.Add("@WarehouseStatus", SqlDbType.NVarChar).Value = 2;
                    cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                    cmd.Parameters.Add("@SenderID", SqlDbType.NVarChar).Value = parentForm1.employeeID.ToUpper();

                    cmd2 = new SqlCommand("Update_POHeader", parentForm2.connCH);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Clear();
                    cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                    cmd2.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    cmd2.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                    cmd2.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                    cmd2.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "SENT";

                    parentForm2.connCH.Open();
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    parentForm2.connCH.Close();
                }
                else if (storeCode == "WM")
                {
                    cmd = new SqlCommand("Update_POWarehouseStatus", parentForm2.connWM);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    //cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = storeCode;
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    cmd.Parameters.Add("@WarehouseStatus", SqlDbType.NVarChar).Value = 2;
                    cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                    cmd.Parameters.Add("@SenderID", SqlDbType.NVarChar).Value = parentForm1.employeeID.ToUpper();

                    cmd2 = new SqlCommand("Update_POHeader", parentForm2.connWM);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Clear();
                    cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                    cmd2.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    cmd2.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                    cmd2.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                    cmd2.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "SENT";

                    parentForm2.connWM.Open();
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    parentForm2.connWM.Close();
                }
                else if (storeCode == "CV")
                {
                    cmd = new SqlCommand("Update_POWarehouseStatus", parentForm2.connCV);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    //cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = storeCode;
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    cmd.Parameters.Add("@WarehouseStatus", SqlDbType.NVarChar).Value = 2;
                    cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                    cmd.Parameters.Add("@SenderID", SqlDbType.NVarChar).Value = parentForm1.employeeID.ToUpper();

                    cmd2 = new SqlCommand("Update_POHeader", parentForm2.connCV);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Clear();
                    cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                    cmd2.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    cmd2.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                    cmd2.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                    cmd2.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "SENT";

                    parentForm2.connCV.Open();
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    parentForm2.connCV.Close();
                }
                else if (storeCode == "PW")
                {
                    cmd = new SqlCommand("Update_POWarehouseStatus", parentForm2.connPW);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    //cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = storeCode;
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    cmd.Parameters.Add("@WarehouseStatus", SqlDbType.NVarChar).Value = 2;
                    cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                    cmd.Parameters.Add("@SenderID", SqlDbType.NVarChar).Value = parentForm1.employeeID.ToUpper();

                    cmd2 = new SqlCommand("Update_POHeader", parentForm2.connPW);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Clear();
                    cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                    cmd2.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    cmd2.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                    cmd2.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                    cmd2.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "SENT";

                    parentForm2.connPW.Open();
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    parentForm2.connPW.Close();
                }
                else if (storeCode == "WB")
                {
                    cmd = new SqlCommand("Update_POWarehouseStatus", parentForm2.connWB);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    //cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = storeCode;
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    cmd.Parameters.Add("@WarehouseStatus", SqlDbType.NVarChar).Value = 2;
                    cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                    cmd.Parameters.Add("@SenderID", SqlDbType.NVarChar).Value = parentForm1.employeeID.ToUpper();

                    cmd2 = new SqlCommand("Update_POHeader", parentForm2.connWB);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Clear();
                    cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                    cmd2.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    cmd2.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                    cmd2.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                    cmd2.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "SENT";

                    parentForm2.connWB.Open();
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    parentForm2.connWB.Close();
                }
                else if (storeCode == "WD")
                {
                    cmd = new SqlCommand("Update_POWarehouseStatus", parentForm2.connWD);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    //cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = storeCode;
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    cmd.Parameters.Add("@WarehouseStatus", SqlDbType.NVarChar).Value = 2;
                    cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                    cmd.Parameters.Add("@SenderID", SqlDbType.NVarChar).Value = parentForm1.employeeID.ToUpper();

                    cmd2 = new SqlCommand("Update_POHeader", parentForm2.connWD);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Clear();
                    cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                    cmd2.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    cmd2.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                    cmd2.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                    cmd2.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "SENT";

                    parentForm2.connWD.Open();
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    parentForm2.connWD.Close();
                }
                else if (storeCode == "GB")
                {
                    cmd = new SqlCommand("Update_POWarehouseStatus", parentForm2.connGB);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    //cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = storeCode;
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    cmd.Parameters.Add("@WarehouseStatus", SqlDbType.NVarChar).Value = 2;
                    cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                    cmd.Parameters.Add("@SenderID", SqlDbType.NVarChar).Value = parentForm1.employeeID.ToUpper();

                    cmd2 = new SqlCommand("Update_POHeader", parentForm2.connGB);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Clear();
                    cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                    cmd2.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    cmd2.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                    cmd2.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                    cmd2.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "SENT";

                    parentForm2.connGB.Open();
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    parentForm2.connGB.Close();
                }
                else if (storeCode == "BW")
                {
                    cmd = new SqlCommand("Update_POWarehouseStatus", parentForm2.connBW);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    //cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = storeCode;
                    cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    cmd.Parameters.Add("@WarehouseStatus", SqlDbType.NVarChar).Value = 2;
                    cmd.Parameters.Add("@ShippingDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                    cmd.Parameters.Add("@SenderID", SqlDbType.NVarChar).Value = parentForm1.employeeID.ToUpper();

                    cmd2 = new SqlCommand("Update_POHeader", parentForm2.connBW);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Clear();
                    cmd2.Parameters.Add("@Seq", SqlDbType.Int).Value = 2;
                    cmd2.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                    cmd2.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                    cmd2.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                    cmd2.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "SENT";

                    parentForm2.connBW.Open();
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    parentForm2.connBW.Close();
                }

                progressBar1.PerformStep();
                MessageBox.Show("SENDING COMPLETE", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                progressBar1.Value = 0;
                btnSend.Enabled = false;
                //btnPrintInvoice.Enabled = true;
                dataGridView1.ReadOnly = true;

                lblPOStatus.Text = "SENT";
                dataGridView1.ReadOnly = true;
                dataGridView1.Columns[12].SortMode = DataGridViewColumnSortMode.NotSortable;
                shipDate = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                senderID = parentForm1.employeeID.ToUpper();
            }
            else
            {
                MessageBox.Show("SENDING INCOMPLETE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            InvoicePrinting invoicePrintingForm = new InvoicePrinting(POID, storeCode, WHStatus);
            invoicePrintingForm.parentForm1 = this.parentForm1;
            invoicePrintingForm.parentForm2 = this;
            invoicePrintingForm.ShowDialog();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                sendingTotalQty = 0;
                sendingTotalAmount = 0;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    costPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                    sendingQty = Convert.ToInt16(dataGridView1.Rows[i].Cells[7].Value);
                    sendingAmount = Math.Round(costPrice * sendingQty, 2, MidpointRounding.AwayFromZero);
                    dataGridView1.Rows[i].Cells[9].Value = sendingAmount;

                    //sendningTotalQty = sendningTotalQty + sendingQty;
                    sendingTotalAmount = sendingTotalAmount + sendingAmount;
                }

                //lblReceivingTotalQty.Text = Convert.ToString(receivingTotalQty);
                lblSendingTotalAmount.Text = string.Format("{0:$0.00}", sendingTotalAmount);
            }
            catch
            {
                MessageBox.Show("INVALID AMOUNT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void POSending_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (parentForm2.IsDisposed == false)
                parentForm2.SearchPOList();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (parentForm1.employeeID.ToUpper() == "ADMIN" | parentForm1.specialCode == parentForm1.txtSpecialCode.Text.Trim().ToString().ToUpper())
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

        public static bool DBConnectionStatus(string cs)
        {
            try
            {
                using (SqlConnection sqlConn =
                    //new SqlConnection("Server=VMWARE_DEV;Database=TestHQ;UID=ssk;Password=cherry"))
                    new SqlConnection(cs))
                {
                    sqlConn.Open();
                    return (sqlConn.State == ConnectionState.Open);
                }
            }
            catch (SqlException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}