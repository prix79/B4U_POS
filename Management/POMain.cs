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
    public partial class POMain : Form
    {
        public LogInManagements parentForm1;
        public POandReceiving parentForm2;
        public CreateNewPO parentForm3;
        public ItemSoldList parentForm4;
        public POandReceivingForWarehouse parentForm5;

        SqlConnection WarehouseConn;
        string WHCS1;

        int option = 0;
        bool boolParentForm2 = true;
        bool boolParentForm5 = true;

        SqlCommand cmd;
        DataTable dt = new DataTable();
        SqlDataAdapter adapt = new SqlDataAdapter();
        public DataTable POBodyTable = new DataTable();
        //DataTable temp = new DataTable();
        SqlCommand cmd_POBody;

        //int POHeaderStatus;
        public Int64 POID;

        public Int64 VendorID;
        public string VendorCode;
        public string VendorName;
        public string CreateDate;

        int index1, index2, index3;
        string sp;
        string ItmBrand, ItmColor, ItmSize, ItmName, ItmUpc;
        bool ItmTF = true;
        int brandBoolNum, sizeBoolNum, colorBoolNum, nameBoolNum, upcBoolNum, totalBoolNum;

        //Int64 selectedItems = 0;

        public Int64 orderTotalQty = 0;
        public double orderTotalAmount = 0;

        string gpoBrand, gpoName, gpoSize, gpoColor, gpoUpc, gpoBin;
        double gpoUnitPrice, gpoOrderAmount;
        Int64 gpoOnHand, gpoOrderQty;

        public int msgOpt = 0;
        
        public POMain(int sts, int opt)
        {
            InitializeComponent();

            if (sts > 1)
            {
                btnAdd.Enabled = false;
                btnSavePO.Enabled = false;
                btnDeletePO.Enabled = false;
            }

            option = opt;
        }

        private void POMain_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            WHCS1 = "Data Source=" + parentForm1.B4UWHIP + "," + parentForm1.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm1.B4UWHDB + ";User ID=" + parentForm1.DBUID + ";Password=" + parentForm1.DBPSW;

            orderTotalQty = 0;
            orderTotalAmount = 0;

            if (option == 0)
            {
                if (parentForm1.userLevel < 5)
                {
                    if (parentForm1.employeeID != Convert.ToString(parentForm2.dataGridView1.SelectedCells[9].Value).ToUpper())
                    {
                        btnAdd.Enabled = false;
                        btnSavePO.Enabled = false;
                        btnDeletePO.Enabled = false;
                        btnPrintPO.Enabled = false;
                    }
                }

                boolParentForm2 = true;

                POID = Convert.ToInt64(parentForm2.dataGridView1.SelectedCells[0].Value);
                lblPOID.Text = Convert.ToString(POID);
                VendorID = Convert.ToInt64(parentForm2.dataGridView1.SelectedCells[2].Value);
                VendorCode = Convert.ToString(parentForm2.dataGridView1.SelectedCells[3].Value).ToUpper();
                VendorName = Convert.ToString(parentForm2.dataGridView1.SelectedCells[4].Value).ToUpper();

                if (VendorName.Length > 20)
                {
                    lblVendorName.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
                    lblVendorName.Text = VendorName;
                }
                else
                {
                    lblVendorName.Text = VendorName;
                }

                CreateDate = Convert.ToString(parentForm2.dataGridView1.SelectedCells[5].Value);
                lblCreateDate.Text = CreateDate;
                lblEmployeeID.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[9].Value).ToUpper();
                lblPOStatus.Text = Convert.ToString(parentForm2.dataGridView1.SelectedCells[10].Value).ToUpper();

                Bind_DatagridView2(POID);

                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    orderTotalQty = orderTotalQty + Convert.ToInt16(dataGridView2.Rows[i].Cells[6].Value);
                    orderTotalAmount = orderTotalAmount + Convert.ToDouble(dataGridView2.Rows[i].Cells[8].Value);
                }

                lblOrderTotalQty.Text = Convert.ToString(orderTotalQty);
                lblOrderTotalAmount.Text = string.Format("{0:c}", orderTotalAmount);

                SqlCommand cmd_CmbCategory1 = new SqlCommand("Get_Category_Group1", parentForm1.conn);
                cmd_CmbCategory1.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                SqlDataAdapter adapt2 = new SqlDataAdapter();
                adapt2.SelectCommand = cmd_CmbCategory1;

                parentForm1.conn.Open();
                adapt2.Fill(ds);
                parentForm1.conn.Close();

                cmbCategory1.DataSource = ds.Tables[0].DefaultView;
                cmbCategory1.ValueMember = "ItmGp_Desc";
                cmbCategory1.DisplayMember = "ItmGp_Desc";

                lblTotalCount1.Text = dataGridView1.RowCount.ToString();
                lblTotalCount2.Text = dataGridView2.RowCount.ToString();

                if (dataGridView2.RowCount == 0)
                    btnPrintPO.Enabled = false;
            }
            else if (option == 1)
            {
                if (parentForm1.userLevel < 5)
                {
                    if (parentForm1.employeeID != parentForm3.lblEmployeeID.Text.ToString().ToUpper())
                    {
                        btnAdd.Enabled = false;
                        btnSavePO.Enabled = false;
                        btnDeletePO.Enabled = false;
                        btnPrintPO.Enabled = false;
                    }
                }

                boolParentForm2 = false;

                POID = parentForm3.POID;
                lblPOID.Text = Convert.ToString(POID);
                VendorName = parentForm3.POVendor;

                if (parentForm3.POVendor.Length > 20)
                {
                    lblVendorName.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
                    lblVendorName.Text = parentForm3.POVendor;
                }
                else
                {
                    lblVendorName.Text = parentForm3.POVendor;
                }

                lblCreateDate.Text = parentForm3.POCreateDate;
                lblEmployeeID.Text = parentForm3.POEmployeeID;
                lblPOStatus.Text = parentForm3.POStatus;

                cmd = new SqlCommand("Show_POBody", parentForm1.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                adapt.SelectCommand = cmd;

                parentForm1.conn.Open();
                POBodyTable.Clear();
                adapt.Fill(POBodyTable);
                parentForm1.conn.Close();

                for (int i = 0; i < parentForm4.dataGridView2.RowCount; i++)
                {
                    Set_Variables(i);
                    POBodyTable.Rows.Add(gpoBrand, gpoName, gpoSize, gpoColor, gpoUnitPrice, gpoOnHand, gpoOrderQty, 0, gpoOrderAmount, 0, gpoUpc, gpoBin);
                }

                if (parentForm1.userLevel >= parentForm1.SystemAdministratorLV)
                {
                    if (VendorName.ToUpper() == parentForm1.WarehouseName1.ToUpper())
                    {
                        btnUpdate.Enabled = false;
                        btnTargetField.Enabled = false;
                        dataGridView1.ReadOnly = true;

                        dataGridView2.RowTemplate.Height = 30;
                        dataGridView2.DataSource = POBodyTable;
                        dataGridView2.Columns[0].HeaderText = "Brand";
                        dataGridView2.Columns[0].Width = 125;
                        dataGridView2.Columns[1].HeaderText = "Name";
                        dataGridView2.Columns[1].Width = 270;
                        dataGridView2.Columns[2].HeaderText = "Size";
                        dataGridView2.Columns[2].Width = 75;
                        dataGridView2.Columns[3].HeaderText = "Color";
                        dataGridView2.Columns[3].Width = 75;
                        dataGridView2.Columns[4].HeaderText = "Unit Cost";
                        dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[4].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                        dataGridView2.Columns[4].Width = 65;
                        dataGridView2.Columns[4].DefaultCellStyle.Format = "N2";
                        //dataGridView2.Columns[4].Visible = false;
                        dataGridView2.Columns[5].HeaderText = "WH On Hand";
                        dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[5].Width = 65;
                        //dataGridView2.Columns[5].Visible = false;
                        dataGridView2.Columns[6].HeaderText = "Order QTY";
                        dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[6].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                        dataGridView2.Columns[6].Width = 65;
                        dataGridView2.Columns[7].HeaderText = "Receiving QTY";
                        dataGridView2.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[7].Width = 55;
                        //dataGridView2.Columns[7].Visible = false;
                        dataGridView2.Columns[8].HeaderText = "Order Amount";
                        dataGridView2.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[8].DefaultCellStyle.BackColor = Color.NavajoWhite;
                        dataGridView2.Columns[8].Width = 70;
                        dataGridView2.Columns[8].DefaultCellStyle.Format = "N2";
                        //dataGridView2.Columns[8].Visible = false;
                        dataGridView2.Columns[9].HeaderText = "Receiving Amount";
                        dataGridView2.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[9].Width = 65;
                        dataGridView2.Columns[9].DefaultCellStyle.Format = "N2";
                        //dataGridView2.Columns[9].Visible = false;
                        //dataGridView2.Columns[9].Visible = false;
                        dataGridView2.Columns[10].HeaderText = "UPC";
                        dataGridView2.Columns[10].Width = 100;
                        dataGridView2.Columns[11].HeaderText = "Bin#";
                        dataGridView2.Columns[11].Width = 60;
                        //dataGridView2.Columns[11].Visible = false;

                        dataGridView2.ClearSelection();
                    }
                    else
                    {
                        dataGridView2.RowTemplate.Height = 30;
                        dataGridView2.DataSource = POBodyTable;
                        dataGridView2.Columns[0].HeaderText = "Brand";
                        dataGridView2.Columns[0].Width = 125;
                        dataGridView2.Columns[1].HeaderText = "Name";
                        dataGridView2.Columns[1].Width = 270;
                        dataGridView2.Columns[2].HeaderText = "Size";
                        dataGridView2.Columns[2].Width = 75;
                        dataGridView2.Columns[3].HeaderText = "Color";
                        dataGridView2.Columns[3].Width = 75;
                        dataGridView2.Columns[4].HeaderText = "Unit Cost";
                        dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[4].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                        dataGridView2.Columns[4].Width = 65;
                        dataGridView2.Columns[4].DefaultCellStyle.Format = "N2";
                        dataGridView2.Columns[5].HeaderText = "On Hand";
                        dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[5].Width = 65;
                        dataGridView2.Columns[6].HeaderText = "Order QTY";
                        dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[6].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                        dataGridView2.Columns[6].Width = 65;
                        dataGridView2.Columns[7].HeaderText = "Receiving QTY";
                        dataGridView2.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[7].Width = 55;
                        //dataGridView2.Columns[7].Visible = false;
                        dataGridView2.Columns[8].HeaderText = "Order Amount";
                        dataGridView2.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[8].DefaultCellStyle.BackColor = Color.NavajoWhite;
                        dataGridView2.Columns[8].Width = 70;
                        dataGridView2.Columns[8].DefaultCellStyle.Format = "N2";
                        dataGridView2.Columns[9].HeaderText = "Receiving Amount";
                        dataGridView2.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[9].Width = 65;
                        dataGridView2.Columns[9].DefaultCellStyle.Format = "N2";
                        //dataGridView2.Columns[9].Visible = false;
                        dataGridView2.Columns[10].HeaderText = "UPC";
                        dataGridView2.Columns[10].Width = 100;
                        dataGridView2.Columns[11].HeaderText = "Bin#";
                        //dataGridView2.Columns[11].Visible = false;

                        dataGridView2.ClearSelection();
                    }
                }
                else
                {
                    if (VendorName == parentForm1.WarehouseName1)
                    {
                        btnUpdate.Enabled = false;
                        btnTargetField.Enabled = false;
                        dataGridView1.ReadOnly = true;

                        dataGridView2.RowTemplate.Height = 30;
                        dataGridView2.DataSource = POBodyTable;
                        dataGridView2.Columns[0].HeaderText = "Brand";
                        dataGridView2.Columns[0].Width = 125;
                        dataGridView2.Columns[1].HeaderText = "Name";
                        dataGridView2.Columns[1].Width = 270;
                        dataGridView2.Columns[2].HeaderText = "Size";
                        dataGridView2.Columns[2].Width = 75;
                        dataGridView2.Columns[3].HeaderText = "Color";
                        dataGridView2.Columns[3].Width = 75;
                        dataGridView2.Columns[4].HeaderText = "Unit Cost";
                        dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[4].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                        dataGridView2.Columns[4].Width = 65;
                        dataGridView2.Columns[4].DefaultCellStyle.Format = "N2";
                        dataGridView2.Columns[4].Visible = false;
                        dataGridView2.Columns[5].HeaderText = "WH On Hand";
                        dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[5].Width = 65;
                        dataGridView2.Columns[5].Visible = false;
                        dataGridView2.Columns[6].HeaderText = "Order QTY";
                        dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[6].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                        dataGridView2.Columns[6].Width = 65;
                        dataGridView2.Columns[7].HeaderText = "Receiving QTY";
                        dataGridView2.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[7].Width = 55;
                        dataGridView2.Columns[7].Visible = false;
                        dataGridView2.Columns[8].HeaderText = "Order Amount";
                        dataGridView2.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[8].DefaultCellStyle.BackColor = Color.NavajoWhite;
                        dataGridView2.Columns[8].Width = 70;
                        dataGridView2.Columns[8].DefaultCellStyle.Format = "N2";
                        dataGridView2.Columns[8].Visible = false;
                        dataGridView2.Columns[9].HeaderText = "Receiving Amount";
                        dataGridView2.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[9].Width = 65;
                        dataGridView2.Columns[9].DefaultCellStyle.Format = "N2";
                        dataGridView2.Columns[9].Visible = false;
                        dataGridView2.Columns[9].Visible = false;
                        dataGridView2.Columns[10].HeaderText = "UPC";
                        dataGridView2.Columns[10].Width = 100;
                        dataGridView2.Columns[11].HeaderText = "Bin#";
                        dataGridView2.Columns[11].Width = 60;
                        //dataGridView2.Columns[11].Visible = false;

                        dataGridView2.ClearSelection();
                    }
                    else
                    {
                        dataGridView2.RowTemplate.Height = 30;
                        dataGridView2.DataSource = POBodyTable;
                        dataGridView2.Columns[0].HeaderText = "Brand";
                        dataGridView2.Columns[0].Width = 125;
                        dataGridView2.Columns[1].HeaderText = "Name";
                        dataGridView2.Columns[1].Width = 270;
                        dataGridView2.Columns[2].HeaderText = "Size";
                        dataGridView2.Columns[2].Width = 75;
                        dataGridView2.Columns[3].HeaderText = "Color";
                        dataGridView2.Columns[3].Width = 75;
                        dataGridView2.Columns[4].HeaderText = "Unit Cost";
                        dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[4].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                        dataGridView2.Columns[4].Width = 65;
                        dataGridView2.Columns[4].DefaultCellStyle.Format = "N2";
                        dataGridView2.Columns[5].HeaderText = "On Hand";
                        dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[5].Width = 65;
                        dataGridView2.Columns[6].HeaderText = "Order QTY";
                        dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[6].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                        dataGridView2.Columns[6].Width = 65;
                        dataGridView2.Columns[7].HeaderText = "Receiving QTY";
                        dataGridView2.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[7].Width = 55;
                        dataGridView2.Columns[7].Visible = false;
                        dataGridView2.Columns[8].HeaderText = "Order Amount";
                        dataGridView2.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[8].DefaultCellStyle.BackColor = Color.NavajoWhite;
                        dataGridView2.Columns[8].Width = 70;
                        dataGridView2.Columns[8].DefaultCellStyle.Format = "N2";
                        dataGridView2.Columns[9].HeaderText = "Receiving Amount";
                        dataGridView2.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns[9].Width = 65;
                        dataGridView2.Columns[9].DefaultCellStyle.Format = "N2";
                        dataGridView2.Columns[9].Visible = false;
                        dataGridView2.Columns[10].HeaderText = "UPC";
                        dataGridView2.Columns[10].Width = 100;
                        dataGridView2.Columns[11].HeaderText = "Bin#";
                        dataGridView2.Columns[11].Visible = false;

                        dataGridView2.ClearSelection();
                    }
                }

                btnSavePO_Click(null, null);
                //Bind_DatagridView2(POID);

                SqlCommand cmd_CmbCategory1 = new SqlCommand("Get_Category_Group1", parentForm1.conn);
                cmd_CmbCategory1.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                SqlDataAdapter adapt2 = new SqlDataAdapter();
                adapt2.SelectCommand = cmd_CmbCategory1;

                parentForm1.conn.Open();
                adapt2.Fill(ds);
                parentForm1.conn.Close();

                cmbCategory1.DataSource = ds.Tables[0].DefaultView;
                cmbCategory1.ValueMember = "ItmGp_Desc";
                cmbCategory1.DisplayMember = "ItmGp_Desc";

                orderTotalQty = 0;
                orderTotalAmount = 0;

                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    orderTotalQty = orderTotalQty + Convert.ToInt16(dataGridView2.Rows[i].Cells[6].Value);
                    orderTotalAmount = orderTotalAmount + Convert.ToDouble(dataGridView2.Rows[i].Cells[8].Value);
                }

                lblOrderTotalQty.Text = Convert.ToString(orderTotalQty);
                lblOrderTotalAmount.Text = string.Format("{0:c}", orderTotalAmount);

                lblTotalCount1.Text = dataGridView1.RowCount.ToString();
                lblTotalCount2.Text = dataGridView2.RowCount.ToString();

                parentForm3.Close();
            }
            else if (option == 2)
            {
                if (parentForm1.userLevel < 5)
                {
                    if (parentForm1.employeeID != Convert.ToString(parentForm5.dataGridView1.SelectedCells[9].Value).ToUpper())
                    {
                        btnAdd.Enabled = false;
                        btnSavePO.Enabled = false;
                        btnDeletePO.Enabled = false;
                        btnPrintPO.Enabled = false;
                    }
                }

                boolParentForm5 = true;

                POID = Convert.ToInt64(parentForm5.dataGridView1.SelectedCells[0].Value);
                lblPOID.Text = Convert.ToString(POID);
                VendorID = Convert.ToInt64(parentForm5.dataGridView1.SelectedCells[2].Value);
                VendorCode = Convert.ToString(parentForm5.dataGridView1.SelectedCells[3].Value).ToUpper();
                VendorName = Convert.ToString(parentForm5.dataGridView1.SelectedCells[4].Value).ToUpper();

                if (VendorName.Length > 20)
                {
                    lblVendorName.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
                    lblVendorName.Text = VendorName;
                }
                else
                {
                    lblVendorName.Text = VendorName;
                }

                CreateDate = Convert.ToString(parentForm5.dataGridView1.SelectedCells[5].Value);
                lblCreateDate.Text = CreateDate;
                lblEmployeeID.Text = Convert.ToString(parentForm5.dataGridView1.SelectedCells[9].Value).ToUpper();
                lblPOStatus.Text = Convert.ToString(parentForm5.dataGridView1.SelectedCells[10].Value).ToUpper();

                Bind_DatagridView2(POID);

                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    orderTotalQty = orderTotalQty + Convert.ToInt16(dataGridView2.Rows[i].Cells[6].Value);
                    orderTotalAmount = orderTotalAmount + Convert.ToDouble(dataGridView2.Rows[i].Cells[8].Value);
                }

                lblOrderTotalQty.Text = Convert.ToString(orderTotalQty);
                lblOrderTotalAmount.Text = string.Format("{0:c}", orderTotalAmount);

                SqlCommand cmd_CmbCategory1 = new SqlCommand("Get_Category_Group1", parentForm1.conn);
                cmd_CmbCategory1.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                SqlDataAdapter adapt2 = new SqlDataAdapter();
                adapt2.SelectCommand = cmd_CmbCategory1;

                parentForm1.conn.Open();
                adapt2.Fill(ds);
                parentForm1.conn.Close();

                cmbCategory1.DataSource = ds.Tables[0].DefaultView;
                cmbCategory1.ValueMember = "ItmGp_Desc";
                cmbCategory1.DisplayMember = "ItmGp_Desc";

                lblTotalCount1.Text = dataGridView1.RowCount.ToString();
                lblTotalCount2.Text = dataGridView2.RowCount.ToString();

                if (dataGridView2.RowCount == 0)
                    btnPrintPO.Enabled = false;
            }
        }

        private void btnSavePO_Click(object sender, EventArgs e)
        {
            if (lblPOStatus.Text == "PENDING")
            {
                if (msgOpt == 0)
                {
                    DialogResult MyDialogResult;
                    MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (MyDialogResult == DialogResult.Yes)
                    {
                        if (dataGridView2.RowCount == 0)
                        {
                            SqlCommand cmd_Previous_POBody = new SqlCommand("Delete_Previous_POBody", parentForm1.conn);
                            cmd_Previous_POBody.CommandType = CommandType.StoredProcedure;
                            cmd_Previous_POBody.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;

                            parentForm1.conn.Open();
                            cmd_Previous_POBody.ExecuteNonQuery();
                            parentForm1.conn.Close();

                            cmd = new SqlCommand("Update_POHeader", parentForm1.conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@Seq", SqlDbType.Int).Value = 0;
                            cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                            cmd.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                            cmd.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                            cmd.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "PENDING";

                            parentForm1.conn.Open();
                            cmd.ExecuteNonQuery();
                            parentForm1.conn.Close();

                            lblTotalCount2.Text = Convert.ToString(dataGridView2.RowCount);

                            if (dataGridView2.RowCount <= 0)
                            {
                                btnPrintPO.Enabled = false;
                            }
                            else
                            {
                                btnPrintPO.Enabled = true;
                            }

                            if (msgOpt == 0)
                            {
                                MessageBox.Show("SUCCESFULLY SAVED !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                            }

                            msgOpt = 0;
                        }
                        else if (dataGridView2.RowCount > 0)
                        {
                            SqlCommand cmd_Previous_POBody = new SqlCommand("Delete_Previous_POBody", parentForm1.conn);
                            cmd_Previous_POBody.CommandType = CommandType.StoredProcedure;
                            cmd_Previous_POBody.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;

                            parentForm1.conn.Open();
                            cmd_Previous_POBody.ExecuteNonQuery();
                            parentForm1.conn.Close();

                            /*progressBar1.Visible = true;
                            progressBar1.Minimum = 0;
                            progressBar1.Maximum = dataGridView2.RowCount + 1;
                            progressBar1.Step = 1;

                            backgroundWorker1.RunWorkerAsync();*/

                            cmd_POBody = new SqlCommand("Create_POBody", parentForm1.conn);
                            cmd_POBody.CommandType = CommandType.StoredProcedure;

                            for (int i = 0; i < dataGridView2.RowCount; i++)
                            {
                                cmd_POBody.Parameters.Clear();
                                cmd_POBody.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = parentForm1.StoreCode;
                                cmd_POBody.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                                cmd_POBody.Parameters.Add("@POItemIndex", SqlDbType.Int).Value = i + 1;
                                cmd_POBody.Parameters.Add("@POItemBrand", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[i].Cells[0].Value);
                                cmd_POBody.Parameters.Add("@POItemName", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[i].Cells[1].Value);
                                cmd_POBody.Parameters.Add("@POItemSize", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[i].Cells[2].Value);
                                cmd_POBody.Parameters.Add("@POItemColor", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[i].Cells[3].Value);
                                cmd_POBody.Parameters.Add("@POItemCostPrice", SqlDbType.Money).Value = Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value);
                                cmd_POBody.Parameters.Add("@POItemOnHand", SqlDbType.Int).Value = Convert.ToInt16(dataGridView2.Rows[i].Cells[5].Value);
                                cmd_POBody.Parameters.Add("@POItemOrderQty", SqlDbType.Int).Value = Convert.ToInt16(dataGridView2.Rows[i].Cells[6].Value);
                                cmd_POBody.Parameters.Add("@POItemReceivingQty", SqlDbType.Int).Value = 0;
                                cmd_POBody.Parameters.Add("@POItemOrderAmount", SqlDbType.Money).Value = Convert.ToDouble(dataGridView2.Rows[i].Cells[8].Value);
                                cmd_POBody.Parameters.Add("@POItemReceivingAmount", SqlDbType.Money).Value = 0;
                                cmd_POBody.Parameters.Add("@POItemUpc", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[i].Cells[10].Value);
                                cmd_POBody.Parameters.Add("@POItemBin", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[i].Cells[11].Value);

                                parentForm1.conn.Open();
                                cmd_POBody.ExecuteNonQuery();
                                parentForm1.conn.Close();
                            }

                            Bind_DatagridView2(POID);

                            orderTotalQty = 0;
                            orderTotalAmount = 0;

                            for (int i = 0; i < dataGridView2.RowCount; i++)
                            {
                                orderTotalQty = orderTotalQty + Convert.ToInt16(dataGridView2.Rows[i].Cells[6].Value);
                                orderTotalAmount = orderTotalAmount + Convert.ToDouble(dataGridView2.Rows[i].Cells[8].Value);
                            }

                            lblOrderTotalQty.Text = Convert.ToString(orderTotalQty);
                            lblOrderTotalAmount.Text = string.Format("{0:$0.00}", orderTotalAmount);

                            cmd = new SqlCommand("Update_POHeader", parentForm1.conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@Seq", SqlDbType.Int).Value = 0;
                            cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                            cmd.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = orderTotalAmount;
                            cmd.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                            cmd.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "PENDING";

                            parentForm1.conn.Open();
                            cmd.ExecuteNonQuery();
                            parentForm1.conn.Close();

                            lblTotalCount2.Text = Convert.ToString(dataGridView2.RowCount);
                            btnPrintPO.Enabled = true;
                        }

                        /*orderTotalQty = 0;
                        orderTotalAmount = 0;

                        for (int i = 0; i < dataGridView2.RowCount; i++)
                        {
                            orderTotalQty = orderTotalQty + Convert.ToInt16(dataGridView2.Rows[i].Cells[6].Value);
                            orderTotalAmount = orderTotalAmount + Convert.ToDouble(dataGridView2.Rows[i].Cells[8].Value);
                        }

                        lblOrderTotalQty.Text = Convert.ToString(orderTotalQty);
                        lblOrderTotalAmount.Text = string.Format("{0:$0.00}", orderTotalAmount);*/
                    }
                    else
                    {
                    }
                }
                else
                {
                    if (dataGridView2.RowCount == 0)
                    {
                        SqlCommand cmd_Previous_POBody = new SqlCommand("Delete_Previous_POBody", parentForm1.conn);
                        cmd_Previous_POBody.CommandType = CommandType.StoredProcedure;
                        cmd_Previous_POBody.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;

                        parentForm1.conn.Open();
                        cmd_Previous_POBody.ExecuteNonQuery();
                        parentForm1.conn.Close();

                        cmd = new SqlCommand("Update_POHeader", parentForm1.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@Seq", SqlDbType.Int).Value = 0;
                        cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                        cmd.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = 0;
                        cmd.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                        cmd.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "PENDING";

                        parentForm1.conn.Open();
                        cmd.ExecuteNonQuery();
                        parentForm1.conn.Close();

                        lblTotalCount2.Text = Convert.ToString(dataGridView2.RowCount);

                        if (dataGridView2.RowCount <= 0)
                        {
                            btnPrintPO.Enabled = false;
                        }
                        else
                        {
                            btnPrintPO.Enabled = true;
                        }

                        if (msgOpt == 0)
                        {
                            MessageBox.Show("SUCCESFULLY SAVED !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                        }

                        msgOpt = 0;
                    }
                    else if (dataGridView2.RowCount > 0)
                    {
                        SqlCommand cmd_Previous_POBody = new SqlCommand("Delete_Previous_POBody", parentForm1.conn);
                        cmd_Previous_POBody.CommandType = CommandType.StoredProcedure;
                        cmd_Previous_POBody.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;

                        parentForm1.conn.Open();
                        cmd_Previous_POBody.ExecuteNonQuery();
                        parentForm1.conn.Close();

                        /*progressBar1.Visible = true;
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = dataGridView2.RowCount + 1;
                        progressBar1.Step = 1;

                        backgroundWorker1.RunWorkerAsync();*/

                        cmd_POBody = new SqlCommand("Create_POBody", parentForm1.conn);
                        cmd_POBody.CommandType = CommandType.StoredProcedure;

                        for (int i = 0; i < dataGridView2.RowCount; i++)
                        {
                            cmd_POBody.Parameters.Clear();
                            cmd_POBody.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = parentForm1.StoreCode;
                            cmd_POBody.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                            cmd_POBody.Parameters.Add("@POItemIndex", SqlDbType.Int).Value = i + 1;
                            cmd_POBody.Parameters.Add("@POItemBrand", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[i].Cells[0].Value);
                            cmd_POBody.Parameters.Add("@POItemName", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[i].Cells[1].Value);
                            cmd_POBody.Parameters.Add("@POItemSize", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[i].Cells[2].Value);
                            cmd_POBody.Parameters.Add("@POItemColor", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[i].Cells[3].Value);
                            cmd_POBody.Parameters.Add("@POItemCostPrice", SqlDbType.Money).Value = Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value);
                            cmd_POBody.Parameters.Add("@POItemOnHand", SqlDbType.Int).Value = Convert.ToInt16(dataGridView2.Rows[i].Cells[5].Value);
                            cmd_POBody.Parameters.Add("@POItemOrderQty", SqlDbType.Int).Value = Convert.ToInt16(dataGridView2.Rows[i].Cells[6].Value);
                            cmd_POBody.Parameters.Add("@POItemReceivingQty", SqlDbType.Int).Value = 0;
                            cmd_POBody.Parameters.Add("@POItemOrderAmount", SqlDbType.Money).Value = Convert.ToDouble(dataGridView2.Rows[i].Cells[8].Value);
                            cmd_POBody.Parameters.Add("@POItemReceivingAmount", SqlDbType.Money).Value = 0;
                            cmd_POBody.Parameters.Add("@POItemUpc", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[i].Cells[10].Value);
                            cmd_POBody.Parameters.Add("@POItemBin", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[i].Cells[11].Value);

                            parentForm1.conn.Open();
                            cmd_POBody.ExecuteNonQuery();
                            parentForm1.conn.Close();
                        }

                        Bind_DatagridView2(POID);

                        orderTotalQty = 0;
                        orderTotalAmount = 0;

                        for (int i = 0; i < dataGridView2.RowCount; i++)
                        {
                            orderTotalQty = orderTotalQty + Convert.ToInt16(dataGridView2.Rows[i].Cells[6].Value);
                            orderTotalAmount = orderTotalAmount + Convert.ToDouble(dataGridView2.Rows[i].Cells[8].Value);
                        }

                        lblOrderTotalQty.Text = Convert.ToString(orderTotalQty);
                        lblOrderTotalAmount.Text = string.Format("{0:$0.00}", orderTotalAmount);

                        cmd = new SqlCommand("Update_POHeader", parentForm1.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@Seq", SqlDbType.Int).Value = 0;
                        cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                        cmd.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = orderTotalAmount;
                        cmd.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
                        cmd.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "PENDING";

                        parentForm1.conn.Open();
                        cmd.ExecuteNonQuery();
                        parentForm1.conn.Close();

                        lblTotalCount2.Text = Convert.ToString(dataGridView2.RowCount);
                    }

                    /*orderTotalQty = 0;
                    orderTotalAmount = 0;

                    for (int i = 0; i < dataGridView2.RowCount; i++)
                    {
                        orderTotalQty = orderTotalQty + Convert.ToInt16(dataGridView2.Rows[i].Cells[6].Value);
                        orderTotalAmount = orderTotalAmount + Convert.ToDouble(dataGridView2.Rows[i].Cells[8].Value);
                    }

                    lblOrderTotalQty.Text = Convert.ToString(orderTotalQty);
                    lblOrderTotalAmount.Text = string.Format("{0:$0.00}", orderTotalAmount);*/
                }
            }
            else
            {
                return;
            }
        }

        private void btnDeletePO_Click(object sender, EventArgs e)
        {
            if (lblPOStatus.Text == "ORDERING" | lblPOStatus.Text == "RECEIVED")
                return;

            if (dataGridView2.RowCount == 0)
                return;

            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                {
                    dataGridView2.Rows.Remove(row);
                }

                orderTotalQty = 0;
                orderTotalAmount = 0;

                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    dataGridView2.Rows[i].Selected = false;
                    orderTotalQty = orderTotalQty + Convert.ToInt16(dataGridView2.Rows[i].Cells[6].Value);
                    orderTotalAmount = orderTotalAmount + Convert.ToDouble(dataGridView2.Rows[i].Cells[8].Value);
                }

                lblOrderTotalQty.Text = Convert.ToString(orderTotalQty);
                lblOrderTotalAmount.Text = string.Format("{0:$0.00}", orderTotalAmount);
                lblTotalCount2.Text = Convert.ToString(dataGridView2.RowCount);

                if (dataGridView2.RowCount == 0)
                {
                    btnPrintPO.Enabled = false;
                }
                else
                {
                    btnPrintPO.Enabled = true;
                }

                msgOpt = 1;
                btnSavePO_Click(null, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (option == 0)
            {
                if (parentForm2.IsDisposed == false)
                    parentForm2.SearchPOList();

                this.Close();

                /*if (boolParentForm2 == true)
                {
                    if (parentForm2.IsDisposed == false)
                        parentForm2.SearchPOList();

                    this.Close();
                }
                else if (boolParentForm2 == false)
                {
                    this.Close();
                }*/
            }
            else if (option == 1)
            {
                if (parentForm2.IsDisposed == false)
                    parentForm2.SearchPOList();

                if (parentForm4.IsDisposed == false)
                    parentForm4.Close();

                this.Close();

                /*if (boolParentForm2 == true)
                {
                    if (parentForm2.IsDisposed == false)
                        parentForm2.SearchPOList();

                    this.Close();
                }
                else if (boolParentForm2 == false)
                {
                    this.Close();
                }*/
            }
            else if (option == 2)
            {
                if (parentForm5.IsDisposed == false)
                    parentForm5.SearchPOList();

                this.Close();

                /*if (boolParentForm5 == true)
                {
                    if (parentForm5.IsDisposed == false)
                        parentForm5.SearchPOList();

                    this.Close();
                }
                else if (boolParentForm5 == false)
                {
                    this.Close();
                }*/
            }
            else if (option == 3)
            {
                if (parentForm2.IsDisposed == false)
                    parentForm2.SearchPOList();

                this.Close();

                /*if (boolParentForm2 == true)
                {
                    if (parentForm2.IsDisposed == false)
                        parentForm2.SearchPOList();

                    this.Close();
                }
                else if (boolParentForm2 == false)
                {
                    this.Close();
                }*/
            }
            else
            {
                if (parentForm2.IsDisposed == false)
                    parentForm2.SearchPOList();

                this.Close();

                /*if (boolParentForm2 == true)
                {
                    if (parentForm2.IsDisposed == false)
                        parentForm2.SearchPOList();

                    this.Close();
                }
                else if (boolParentForm2 == false)
                {
                    this.Close();
                }*/
            }     
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("NO ITEM", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OrderOptions orderOptionsForm = new OrderOptions();
            orderOptionsForm.parentForm = this;
            orderOptionsForm.ShowDialog();
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

            SqlCommand cmd_CmbCategory2 = new SqlCommand("Get_Category_Group2", parentForm1.conn);
            cmd_CmbCategory2.CommandType = CommandType.StoredProcedure;
            cmd_CmbCategory2.Parameters.Add("@ItmGp_Parents", SqlDbType.Int).Value = cmbCategory1.SelectedIndex;
            DataSet ds = new DataSet();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd_CmbCategory2;

            parentForm1.conn.Open();
            adapt.Fill(ds);
            parentForm1.conn.Close();

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

            SqlCommand cmd_CmbCategory3 = new SqlCommand("Get_Category_Group3", parentForm1.conn);
            cmd_CmbCategory3.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter adapt = new SqlDataAdapter();

            switch (index1)
            {
                case 6:
                    cmd_CmbCategory3.Parameters.Add("@ItmGp_Parents", SqlDbType.Int).Value = index1 + 1;
                    cmd_CmbCategory3.Parameters.Add("@ItmGp_Parents2", SqlDbType.Int).Value = index2;
                    adapt.SelectCommand = cmd_CmbCategory3;

                    parentForm1.conn.Open();
                    adapt.Fill(ds);
                    parentForm1.conn.Close();

                    cmbCategory3.DataSource = ds.Tables[0].DefaultView;
                    cmbCategory3.ValueMember = "ItmGp_Desc";
                    cmbCategory3.DisplayMember = "ItmGp_Desc";
                    break;
                default:
                    cmd_CmbCategory3.Parameters.Add("@ItmGp_Parents", SqlDbType.Int).Value = index1;
                    cmd_CmbCategory3.Parameters.Add("@ItmGp_Parents2", SqlDbType.Int).Value = index2;
                    adapt.SelectCommand = cmd_CmbCategory3;

                    parentForm1.conn.Open();
                    adapt.Fill(ds);
                    parentForm1.conn.Close();

                    cmbCategory3.DataSource = ds.Tables[0].DefaultView;
                    cmbCategory3.ValueMember = "ItmGp_Desc";
                    cmbCategory3.DisplayMember = "ItmGp_Desc";
                    break;
            }
        }

        private void btnBrand_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Get_BrandName", parentForm1.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            DataSet ds = new DataSet();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;

            parentForm1.conn.Open();
            adapt.Fill(ds);
            parentForm1.conn.Close();

            cmbBrand.DataSource = ds.Tables[0].DefaultView;
            cmbBrand.ValueMember = "BrandName";
            cmbBrand.DisplayMember = "BrandName";
        }

        private void btnSize_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Get_SizeName", parentForm1.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            DataSet ds = new DataSet();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;

            parentForm1.conn.Open();
            adapt.Fill(ds);
            parentForm1.conn.Close();

            cmbSize.DataSource = ds.Tables[0].DefaultView;
            cmbSize.ValueMember = "SizeName";
            cmbSize.DisplayMember = "SizeName";
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Get_ColorName", parentForm1.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            DataSet ds = new DataSet();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;

            parentForm1.conn.Open();
            adapt.Fill(ds);
            parentForm1.conn.Close();

            cmbColor.DataSource = ds.Tables[0].DefaultView;
            cmbColor.ValueMember = "ColorName";
            cmbColor.DisplayMember = "ColorName";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbCategory1.SelectedIndex == 0)
            {
                MessageBox.Show("SELECT CATEGORY 1", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

            lblTotalCount1.Text = dataGridView1.RowCount.ToString();

            btnSearch.Enabled = true;

            dataGridView1.Focus();

            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.CurrentCell.Selected = false;
                //dataGridView1.Rows[0].Cells[0].Selected = false;
                dataGridView1.Rows[0].Cells[28].Selected = true;
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

            SqlCommand cmd_CmbCategory1 = new SqlCommand("Get_Category_Group1", parentForm1.conn);
            cmd_CmbCategory1.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd_CmbCategory1;

            parentForm1.conn.Open();
            adapt.Fill(ds);
            parentForm1.conn.Close();

            cmbCategory1.DataSource = ds.Tables[0].DefaultView;
            cmbCategory1.ValueMember = "ItmGp_Desc";
            cmbCategory1.DisplayMember = "ItmGp_Desc";

            lblTotalCount1.Text = dataGridView1.RowCount.ToString();
        }

        public void DataBind(int totalBoolNum, string sp, string ItmBrand, string ItmSize, string ItmColor, string ItmName, string ItmUpc, bool ItmTF)
        {
            if (VendorName == parentForm1.WarehouseName1)
            {
                WarehouseConn = new SqlConnection(WHCS1);

                cmd = new SqlCommand(sp, WarehouseConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
                cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
                cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
                cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
                cmd.Parameters.Add("@ItmTF", SqlDbType.Bit).Value = ItmTF;
                dt.Clear();
                adapt.SelectCommand = cmd;

                WarehouseConn.Open();
                adapt.Fill(dt);
                WarehouseConn.Close();
            }
            else
            {
                cmd = new SqlCommand(sp, parentForm1.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
                cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
                cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
                cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
                cmd.Parameters.Add("@ItmTF", SqlDbType.Bit).Value = ItmTF;
                dt.Clear();
                adapt.SelectCommand = cmd;

                parentForm1.conn.Open();
                adapt.Fill(dt);
                parentForm1.conn.Close();
            }
        }

        public void DataBind(int totalBoolNum, string sp, int index1, string ItmBrand, string ItmSize, string ItmColor, string ItmName, string ItmUpc, bool ItmTF)
        {
            if (VendorName == parentForm1.WarehouseName1)
            {
                WarehouseConn = new SqlConnection(WHCS1);

                cmd = new SqlCommand(sp, WarehouseConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
                cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
                cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
                cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
                cmd.Parameters.Add("@ItmTF", SqlDbType.Bit).Value = ItmTF;
                dt.Clear();
                adapt.SelectCommand = cmd;

                WarehouseConn.Open();
                adapt.Fill(dt);
                WarehouseConn.Close();
            }
            else
            {
                cmd = new SqlCommand(sp, parentForm1.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@totalBoolNum", SqlDbType.Int).Value = totalBoolNum;
                cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = index1;
                cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = ItmBrand;
                cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = ItmSize;
                cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = ItmColor;
                cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = "%" + ItmName + "%";
                cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = ItmUpc;
                cmd.Parameters.Add("@ItmTF", SqlDbType.Bit).Value = ItmTF;
                dt.Clear();
                adapt.SelectCommand = cmd;

                parentForm1.conn.Open();
                adapt.Fill(dt);
                parentForm1.conn.Close();
            }
        }

        public void DataBind(int totalBoolNum, string sp, int index1, int index2, string ItmBrand, string ItmSize, string ItmColor, string ItmName, string ItmUpc, bool ItmTF)
        {
            if (VendorName == parentForm1.WarehouseName1)
            {
                WarehouseConn = new SqlConnection(WHCS1);

                cmd = new SqlCommand(sp, WarehouseConn);
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
                cmd.Parameters.Add("@ItmTF", SqlDbType.Bit).Value = ItmTF;
                dt.Clear();
                adapt.SelectCommand = cmd;

                WarehouseConn.Open();
                adapt.Fill(dt);
                WarehouseConn.Close();
            }
            else
            {
                cmd = new SqlCommand(sp, parentForm1.conn);
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
                cmd.Parameters.Add("@ItmTF", SqlDbType.Bit).Value = ItmTF;
                dt.Clear();
                adapt.SelectCommand = cmd;

                parentForm1.conn.Open();
                adapt.Fill(dt);
                parentForm1.conn.Close();
            }
        }

        public void DataBind(int totalBoolNum, string sp, int index1, int index2, int index3, string ItmBrand, string ItmSize, string ItmColor, string ItmName, string ItmUpc, bool ItmTF)
        {
            if (VendorName == parentForm1.WarehouseName1)
            {
                WarehouseConn = new SqlConnection(WHCS1);

                cmd = new SqlCommand(sp, WarehouseConn);
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
                cmd.Parameters.Add("@ItmTF", SqlDbType.Bit).Value = ItmTF;
                dt.Clear();
                adapt.SelectCommand = cmd;

                WarehouseConn.Open();
                adapt.Fill(dt);
                WarehouseConn.Close();
            }
            else
            {
                cmd = new SqlCommand(sp, parentForm1.conn);
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
                cmd.Parameters.Add("@ItmTF", SqlDbType.Bit).Value = ItmTF;
                dt.Clear();
                adapt.SelectCommand = cmd;

                parentForm1.conn.Open();
                adapt.Fill(dt);
                parentForm1.conn.Close();
            }
        }

        private void BindDataGridView()
        {
            if (VendorName == parentForm1.WarehouseName1)
            {
                dataGridView1.ReadOnly = true;
                dataGridView1.RowTemplate.Height = 30;
                //dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].HeaderText = "Brand";
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].HeaderText = "Name";
                dataGridView1.Columns[3].Width = 270;
                dataGridView1.Columns[4].HeaderText = "Size";
                dataGridView1.Columns[4].Width = 60;
                dataGridView1.Columns[5].HeaderText = "Color";
                dataGridView1.Columns[5].Width = 60;

                if (cmbCategory1.SelectedIndex == 2 | cmbCategory1.SelectedIndex == 3)
                {
                    dataGridView1.Columns[6].Visible = false;
                    dataGridView1.Columns[6].HeaderText = "Model Number";
                    dataGridView1.Columns[6].Width = 80;
                }
                else
                {
                    dataGridView1.Columns[6].Visible = true;
                    dataGridView1.Columns[6].HeaderText = "Model Number";
                    dataGridView1.Columns[6].Width = 80;
                }

                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].HeaderText = "Reserved Stock";
                dataGridView1.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[12].Width = 59;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].HeaderText = "Minimum Stock";
                dataGridView1.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[13].Width = 59;
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[14].HeaderText = "On Hand";
                dataGridView1.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[14].DefaultCellStyle.BackColor = Color.Cornsilk;
                dataGridView1.Columns[14].Width = 59;
                //dataGridView1.Columns[14].Visible = false;
                dataGridView1.Columns[15].Visible = false;
                dataGridView1.Columns[16].HeaderText = "Cost Price";
                dataGridView1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[16].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                dataGridView1.Columns[16].Width = 55;
                dataGridView1.Columns[16].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns[16].Visible = false;
                //dataGridView1.Columns[16].Visible = false;
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
                dataGridView1.Columns[27].Visible = false;
                dataGridView1.Columns[28].HeaderText = "UPC";
                dataGridView1.Columns[28].Width = 100;
                dataGridView1.Columns[29].HeaderText = "Bin#";
                dataGridView1.Columns[29].Width = 50;
                dataGridView1.Columns[30].Visible = false;
                dataGridView1.Columns[31].Visible = false;
                dataGridView1.Columns[32].Visible = false;
                dataGridView1.Columns[33].Visible = false;
                dataGridView1.Columns[34].Visible = false;
                dataGridView1.Columns[35].Visible = false;
                dataGridView1.Columns[36].Visible = false;
                dataGridView1.Columns[37].Visible = false;
                dataGridView1.Columns[38].HeaderText = "Active";
                dataGridView1.Columns[38].Width = 40;

                dataGridView1.ClearSelection();
            }
            else
            {
                if (parentForm1.userLevel >= parentForm1.GeneralManagerLV)
                {
                    dataGridView1.ReadOnly = false;
                    dataGridView1.RowTemplate.Height = 30;
                    //dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].Visible = false;
                    dataGridView1.Columns[2].HeaderText = "Brand";
                    dataGridView1.Columns[2].Width = 100;
                    dataGridView1.Columns[3].HeaderText = "Name";
                    dataGridView1.Columns[3].Width = 270;
                    dataGridView1.Columns[4].HeaderText = "Size";
                    dataGridView1.Columns[4].Width = 60;
                    dataGridView1.Columns[5].HeaderText = "Color";
                    dataGridView1.Columns[5].Width = 60;

                    if (cmbCategory1.SelectedIndex == 2 | cmbCategory1.SelectedIndex == 3)
                    {
                        dataGridView1.Columns[6].Visible = false;
                        dataGridView1.Columns[6].HeaderText = "Model Number";
                        dataGridView1.Columns[6].Width = 80;
                    }
                    else
                    {
                        dataGridView1.Columns[6].Visible = true;
                        dataGridView1.Columns[6].HeaderText = "Model Number";
                        dataGridView1.Columns[6].Width = 80;
                    }

                    dataGridView1.Columns[7].Visible = false;
                    dataGridView1.Columns[8].Visible = false;
                    dataGridView1.Columns[9].Visible = false;
                    dataGridView1.Columns[10].Visible = false;
                    dataGridView1.Columns[11].Visible = false;
                    dataGridView1.Columns[12].HeaderText = "Reserved Stock";
                    dataGridView1.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[12].Width = 59;
                    dataGridView1.Columns[13].HeaderText = "Minimum Stock";
                    dataGridView1.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[13].Width = 59;
                    dataGridView1.Columns[14].HeaderText = "On Hand";
                    dataGridView1.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[14].DefaultCellStyle.BackColor = Color.Cornsilk;
                    dataGridView1.Columns[14].Width = 59;
                    dataGridView1.Columns[15].Visible = false;
                    dataGridView1.Columns[16].HeaderText = "Cost Price";
                    dataGridView1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[16].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                    dataGridView1.Columns[16].Width = 55;
                    dataGridView1.Columns[16].DefaultCellStyle.Format = "N2";
                    //dataGridView1.Columns[16].Visible = false;
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
                    dataGridView1.Columns[27].Visible = false;
                    dataGridView1.Columns[28].HeaderText = "UPC";
                    dataGridView1.Columns[28].Width = 100;
                    dataGridView1.Columns[28].ReadOnly = true;
                    dataGridView1.Columns[29].HeaderText = "Bin#";
                    dataGridView1.Columns[29].Width = 50;
                    dataGridView1.Columns[30].Visible = false;
                    dataGridView1.Columns[31].Visible = false;
                    dataGridView1.Columns[32].Visible = false;
                    dataGridView1.Columns[33].Visible = false;
                    dataGridView1.Columns[34].Visible = false;
                    dataGridView1.Columns[35].Visible = false;
                    dataGridView1.Columns[36].Visible = false;
                    dataGridView1.Columns[37].Visible = false;
                    dataGridView1.Columns[38].HeaderText = "Active";
                    dataGridView1.Columns[38].Width = 40;

                    dataGridView1.ClearSelection();
                }
                else
                {
                    dataGridView1.RowTemplate.Height = 30;
                    //dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].Visible = false;
                    dataGridView1.Columns[2].HeaderText = "Brand";
                    dataGridView1.Columns[2].Width = 100;
                    dataGridView1.Columns[2].ReadOnly = true;
                    dataGridView1.Columns[3].HeaderText = "Name";
                    dataGridView1.Columns[3].Width = 270;
                    dataGridView1.Columns[3].ReadOnly = true;
                    dataGridView1.Columns[4].HeaderText = "Size";
                    dataGridView1.Columns[4].Width = 60;
                    dataGridView1.Columns[4].ReadOnly = true;
                    dataGridView1.Columns[5].HeaderText = "Color";
                    dataGridView1.Columns[5].Width = 60;
                    dataGridView1.Columns[5].ReadOnly = true;

                    if (cmbCategory1.SelectedIndex == 2 | cmbCategory1.SelectedIndex == 3)
                    {
                        dataGridView1.Columns[6].Visible = false;
                        dataGridView1.Columns[6].HeaderText = "Model Number";
                        dataGridView1.Columns[6].Width = 80;
                        dataGridView1.Columns[6].ReadOnly = true;
                    }
                    else
                    {
                        dataGridView1.Columns[6].Visible = true;
                        dataGridView1.Columns[6].HeaderText = "Model Number";
                        dataGridView1.Columns[6].Width = 80;
                        dataGridView1.Columns[6].ReadOnly = true;
                    }

                    dataGridView1.Columns[7].Visible = false;
                    dataGridView1.Columns[8].Visible = false;
                    dataGridView1.Columns[9].Visible = false;
                    dataGridView1.Columns[10].Visible = false;
                    dataGridView1.Columns[11].Visible = false;
                    dataGridView1.Columns[12].HeaderText = "Reserved Stock";
                    dataGridView1.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[12].Width = 59;
                    dataGridView1.Columns[12].ReadOnly = true;
                    dataGridView1.Columns[13].HeaderText = "Minimum Stock";
                    dataGridView1.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[13].Width = 59;
                    dataGridView1.Columns[13].ReadOnly = true;
                    dataGridView1.Columns[14].HeaderText = "On Hand";
                    dataGridView1.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[14].DefaultCellStyle.BackColor = Color.Cornsilk;
                    dataGridView1.Columns[14].Width = 59;
                    dataGridView1.Columns[14].ReadOnly = false;
                    dataGridView1.Columns[15].Visible = false;
                    dataGridView1.Columns[16].HeaderText = "Cost Price";
                    dataGridView1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[16].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                    dataGridView1.Columns[16].Width = 55;
                    dataGridView1.Columns[16].DefaultCellStyle.Format = "N2";
                    dataGridView1.Columns[16].ReadOnly = true;
                    //dataGridView1.Columns[16].Visible = false;
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
                    dataGridView1.Columns[27].Visible = false;
                    dataGridView1.Columns[28].HeaderText = "UPC";
                    dataGridView1.Columns[28].Width = 100;
                    dataGridView1.Columns[28].ReadOnly = true;
                    dataGridView1.Columns[29].HeaderText = "Bin#";
                    dataGridView1.Columns[29].Width = 50;
                    dataGridView1.Columns[29].ReadOnly = false;
                    dataGridView1.Columns[30].Visible = false;
                    dataGridView1.Columns[31].Visible = false;
                    dataGridView1.Columns[32].Visible = false;
                    dataGridView1.Columns[33].Visible = false;
                    dataGridView1.Columns[34].Visible = false;
                    dataGridView1.Columns[35].Visible = false;
                    dataGridView1.Columns[36].Visible = false;
                    dataGridView1.Columns[37].Visible = false;
                    dataGridView1.Columns[38].HeaderText = "Active";
                    dataGridView1.Columns[38].Width = 40;
                    dataGridView1.Columns[38].ReadOnly = true;

                    dataGridView1.ClearSelection();
                }
            }
        }

        private void btnPrintPO_Click(object sender, EventArgs e)
        {
            if (lblPOStatus.Text == "EMPTY")
            {
                MessageBox.Show("THIS P/O IS EMPTY, TRY TO SAVE FIRST", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                DialogResult MyDialogResult;
                MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (MyDialogResult == DialogResult.Yes)
                {
                    POPrinting POPrintingForm = new POPrinting();
                    POPrintingForm.parentForm1 = this.parentForm1;
                    POPrintingForm.parentForm2 = this;
                    POPrintingForm.ShowDialog();
                }
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (btnAdd.Enabled == true)
            {
                if (dataGridView1.RowCount > 0)
                {
                    if (e.KeyCode == Keys.Escape)
                    {
                        txtUpc.SelectAll();
                        txtUpc.Focus();
                    }
                    else if (e.KeyCode == Keys.Space)
                    {
                        btnAdd_Click(null, null);
                    }
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

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (parentForm1.employeeID.ToUpper() == "ADMIN" | parentForm1.specialCode == parentForm1.txtSpecialCode.Text.Trim().ToString().ToUpper())
            {
                if (dataGridView2.RowCount > 0)
                {
                    this.Enabled = false;

                    Excel_12.Application ReportFile;
                    Excel_12._Workbook WorkBook;
                    Excel_12._Worksheet WorkSheet;
                    //Excel_12.Range Range;

                    string MaxRow = Convert.ToString(POBodyTable.Rows.Count + 1);
                    String MaxColumn = ((String)(Convert.ToChar(POBodyTable.Columns.Count / 26 + 64).ToString() + Convert.ToChar(POBodyTable.Columns.Count % 26 + 64))).Replace('@', ' ').Trim();
                    String MaxCell = MaxColumn + MaxRow;

                    ReportFile = new Excel_12.Application();
                    ReportFile.Visible = false;

                    WorkBook = (Excel_12._Workbook)(ReportFile.Workbooks.Add("workbook"));
                    WorkSheet = (Excel_12._Worksheet)WorkBook.ActiveSheet;

                    for (int i = 0; i < POBodyTable.Columns.Count; i++)
                        WorkSheet.Cells[1, i + 1] = POBodyTable.Columns[i].ColumnName;

                    string[,] Values = new string[POBodyTable.Rows.Count, POBodyTable.Columns.Count];

                    for (int i = 0; i < POBodyTable.Rows.Count; i++)
                        for (int j = 0; j < POBodyTable.Columns.Count; j++)
                        {

                            Values[i, j] = POBodyTable.Rows[i][j].ToString();

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
                if (dataGridView2.RowCount > 0)
                {
                    ExportDataGridViewTo_Excel12(dataGridView2);
                }
                else
                {
                    MessageBox.Show("NO DATA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            cmd_POBody = new SqlCommand("Create_POBody", parentForm1.conn);
            cmd_POBody.CommandType = CommandType.StoredProcedure;

            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                cmd_POBody.Parameters.Clear();
                cmd_POBody.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = parentForm1.StoreCode;
                cmd_POBody.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
                cmd_POBody.Parameters.Add("@POItemIndex", SqlDbType.Int).Value = i + 1;
                cmd_POBody.Parameters.Add("@POItemBrand", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[i].Cells[0].Value);
                cmd_POBody.Parameters.Add("@POItemName", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[i].Cells[1].Value);
                cmd_POBody.Parameters.Add("@POItemSize", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[i].Cells[2].Value);
                cmd_POBody.Parameters.Add("@POItemColor", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[i].Cells[3].Value);
                cmd_POBody.Parameters.Add("@POItemCostPrice", SqlDbType.Money).Value = Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value);
                cmd_POBody.Parameters.Add("@POItemOnHand", SqlDbType.Int).Value = Convert.ToInt16(dataGridView2.Rows[i].Cells[5].Value);
                cmd_POBody.Parameters.Add("@POItemOrderQty", SqlDbType.Int).Value = Convert.ToInt16(dataGridView2.Rows[i].Cells[6].Value);
                cmd_POBody.Parameters.Add("@POItemReceivingQty", SqlDbType.Int).Value = 0;
                cmd_POBody.Parameters.Add("@POItemOrderAmount", SqlDbType.Money).Value = Convert.ToDouble(dataGridView2.Rows[i].Cells[8].Value);
                cmd_POBody.Parameters.Add("@POItemReceivingAmount", SqlDbType.Money).Value = 0;
                cmd_POBody.Parameters.Add("@POItemUpc", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[i].Cells[10].Value);
                cmd_POBody.Parameters.Add("@POItemBin", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView2.Rows[i].Cells[11].Value);

                parentForm1.conn.Open();
                cmd_POBody.ExecuteNonQuery();
                parentForm1.conn.Close();

                backgroundWorker1.ReportProgress(i + 1);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            orderTotalQty = 0;
            orderTotalAmount = 0;

            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                orderTotalQty = orderTotalQty + Convert.ToInt16(dataGridView2.Rows[i].Cells[6].Value);
                orderTotalAmount = orderTotalAmount + Convert.ToDouble(dataGridView2.Rows[i].Cells[8].Value);
            }

            lblOrderTotalQty.Text = Convert.ToString(orderTotalQty);
            lblOrderTotalAmount.Text = string.Format("{0:$0.00}", orderTotalAmount);

            cmd = new SqlCommand("Update_POHeader", parentForm1.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@Seq", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = POID;
            cmd.Parameters.Add("@OrderTotalAmount", SqlDbType.Money).Value = orderTotalAmount;
            cmd.Parameters.Add("@ReceivingTotalAmount", SqlDbType.Money).Value = 0;
            cmd.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = "PENDING";

            parentForm1.conn.Open();
            cmd.ExecuteNonQuery();
            parentForm1.conn.Close();

            progressBar1.PerformStep();

            lblTotalCount2.Text = Convert.ToString(dataGridView2.RowCount);
            progressBar1.Value = 0;
            progressBar1.Visible = false;

            if (dataGridView2.RowCount == 0)
            {
                btnPrintPO.Enabled = false;
            }
            else
            {
                btnPrintPO.Enabled = true;
            }

            if (msgOpt == 0)
            {
                MessageBox.Show("SUCCESFULLY SAVED !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Bind_DatagridView2(POID);

                //parentForm2.dateOption = 0;
                //parentForm2.startDate = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                //parentForm2.endDate = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                //parentForm2.SearchPOList();
                //parentForm2.startDate = string.Empty;
                //parentForm2.endDate = string.Empty;
            }
            else
            {
            }

            msgOpt = 0;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;

            if (dataGridView1.RowCount > 0)
            {
                DialogResult MyDialogResult;
                MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (MyDialogResult == DialogResult.Yes)
                {
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dataGridView1.RowCount;
                    progressBar1.Step = 1;
                    progressBar1.Visible = true;

                    backgroundWorker2.RunWorkerAsync();
                }
                else
                {
                    btnUpdate.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("NO ITEM", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnUpdate.Enabled = true;
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                btnSelectAll.Enabled = false;

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Selected = true;
                    }
                }

                btnSelectAll.Enabled = true;
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (parentForm1.userLevel >= parentForm1.GeneralManagerLV)
                    {
                        cmd = new SqlCommand("Update_Inventory_Admin", parentForm1.conn);
                    }
                    else
                    {
                        cmd = new SqlCommand("Update_Inventory", parentForm1.conn);
                    }

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@ItmCode", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                    cmd.Parameters.Add("@ItmStoreCode", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[1].Value.ToString().Trim().ToUpper();
                    cmd.Parameters.Add("@ItmBrand", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[2].Value.ToString().Trim().ToUpper();
                    cmd.Parameters.Add("@ItmName", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[3].Value.ToString().Trim().ToUpper();
                    cmd.Parameters.Add("@ItmSize", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[4].Value.ToString().Trim().ToUpper();
                    cmd.Parameters.Add("@ItmColor", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[5].Value.ToString().Trim().ToUpper();
                    cmd.Parameters.Add("@ItmModelNum", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[6].Value.ToString().Trim().ToUpper();
                    cmd.Parameters.Add("@ItmGroup1", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[7].Value.ToString();
                    cmd.Parameters.Add("@ItmGroup2", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[8].Value.ToString();
                    cmd.Parameters.Add("@ItmGroup3", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[9].Value.ToString();
                    cmd.Parameters.Add("@ItmGroup4", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[10].Value.ToString();
                    cmd.Parameters.Add("@ItmGroup5", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[11].Value.ToString();
                    cmd.Parameters.Add("@ItmReservedQty", SqlDbType.Int).Value = Convert.ToInt16(dataGridView1.Rows[i].Cells[12].Value);
                    cmd.Parameters.Add("@ItmStockMin", SqlDbType.Int).Value = Convert.ToInt16(dataGridView1.Rows[i].Cells[13].Value);
                    cmd.Parameters.Add("@ItmOnHand", SqlDbType.Int).Value = Convert.ToInt16(dataGridView1.Rows[i].Cells[14].Value);
                    cmd.Parameters.Add("@ItmRetailPrice", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[15].Value);
                    cmd.Parameters.Add("@ItmCostPrice", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[16].Value);
                    cmd.Parameters.Add("@ItmPrc1", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[17].Value);
                    cmd.Parameters.Add("@ItmPrc2", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[18].Value);
                    cmd.Parameters.Add("@ItmPrc3", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[19].Value);
                    cmd.Parameters.Add("@ItmPrc4", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[20].Value);
                    cmd.Parameters.Add("@ItmPrc5", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[21].Value);
                    cmd.Parameters.Add("@ItmPrc6", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[22].Value);
                    cmd.Parameters.Add("@ItmPrc7", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[23].Value);
                    cmd.Parameters.Add("@ItmPrc8", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[24].Value);
                    cmd.Parameters.Add("@ItmPrc9", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[25].Value);
                    cmd.Parameters.Add("@ItmPrc10", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[26].Value);
                    cmd.Parameters.Add("@ItmStylistPrice", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[27].Value);
                    cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[28].Value.ToString().Trim().ToUpper();
                    cmd.Parameters.Add("@ItmBin", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[29].Value.ToString().Trim().ToUpper();
                    cmd.Parameters.Add("@ItmVendor", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[30].Value.ToString().Trim().ToUpper();
                    cmd.Parameters.Add("@ItmImage", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[31].Value.ToString();
                    cmd.Parameters.Add("@ItmRegisterDate", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[32].Value.ToString();
                    cmd.Parameters.Add("@ItmTax", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[33].Value);
                    cmd.Parameters.Add("@ItmTaxable", SqlDbType.Bit).Value = Convert.ToBoolean(dataGridView1.Rows[i].Cells[34].Value);
                    cmd.Parameters.Add("@ItmMixMatch", SqlDbType.Bit).Value = Convert.ToBoolean(dataGridView1.Rows[i].Cells[35].Value);
                    cmd.Parameters.Add("@ItmMixMatchVal", SqlDbType.Int).Value = Convert.ToInt16(dataGridView1.Rows[i].Cells[36].Value);
                    cmd.Parameters.Add("@ItmMixMatchPrc", SqlDbType.Money).Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[37].Value);
                    cmd.Parameters.Add("@ItmActive", SqlDbType.Bit).Value = Convert.ToBoolean(dataGridView1.Rows[i].Cells[38].Value);

                    parentForm1.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm1.conn.Close();

                    backgroundWorker2.ReportProgress(i + 1);
                }
            }
            catch
            {
                MessageBox.Show("UPDATE FAILED OR CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                parentForm1.conn.Close();
                progressBar1.Visible = false;
                progressBar1.Value = 0;
                btnUpdate.Enabled = true;
                return;
            }
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("SUCCESSFULLY UPDATED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

            progressBar1.Value = 0;
            progressBar1.Visible = false;
            btnUpdate.Enabled = true;
            btnSearch_Click(null, null);
        }

        private void btnTargetField_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                TargetField targetFieldForm = new TargetField(2);
                targetFieldForm.parentForm1 = this.parentForm1;
                targetFieldForm.parentForm4 = this;
                targetFieldForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("NO ITEM", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                dataGridView2.Rows.Remove(row);
            }

            dataGridView2.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }

        private void Set_Variables(int idx)
        {
            gpoBrand= Convert.ToString(parentForm4.dataGridView2.Rows[idx].Cells[0].Value);
            gpoName = Convert.ToString(parentForm4.dataGridView2.Rows[idx].Cells[1].Value);
            gpoSize = Convert.ToString(parentForm4.dataGridView2.Rows[idx].Cells[2].Value);
            gpoColor = Convert.ToString(parentForm4.dataGridView2.Rows[idx].Cells[3].Value);
            gpoUnitPrice = Convert.ToDouble(parentForm4.dataGridView2.Rows[idx].Cells[7].Value);
            gpoOnHand = Convert.ToInt64(parentForm4.dataGridView2.Rows[idx].Cells[8].Value);
            gpoOrderQty = Convert.ToInt64(parentForm4.dataGridView2.Rows[idx].Cells[10].Value);
            gpoUpc = Convert.ToString(parentForm4.dataGridView2.Rows[idx].Cells[5].Value);
            gpoOrderAmount = Convert.ToDouble(parentForm4.dataGridView2.Rows[idx].Cells[11].Value);
            gpoBin = Convert.ToString(parentForm4.dataGridView2.Rows[idx].Cells[12].Value);
        }

        /*private void dataGridView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridView2.RowCount > 0)
            {
                if (btnSavePO.Enabled == true)
                {
                    ChangeValue changeValueForm = new ChangeValue(1);
                    changeValueForm.parentForm2 = this;
                    changeValueForm.ShowDialog();
                }
            }
        }*/

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.RowCount == 0)
                return;

            if (e.RowIndex != -1)
            {
                if (btnSavePO.Enabled == true)
                {
                    ChangeValue changeValueForm = new ChangeValue(1);
                    changeValueForm.parentForm2 = this;
                    changeValueForm.ShowDialog();
                }
            }
        }

        private void Bind_DatagridView2(Int64 PID)
        {
            cmd = new SqlCommand("Show_POBody", parentForm1.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@POID", SqlDbType.BigInt).Value = PID;
            adapt.SelectCommand = cmd;

            parentForm1.conn.Open();
            POBodyTable.Clear();
            adapt.Fill(POBodyTable);
            parentForm1.conn.Close();

            if (parentForm1.userLevel >= parentForm1.SystemAdministratorLV)
            {
                if (VendorName == parentForm1.WarehouseName1)
                {
                    btnUpdate.Enabled = false;
                    btnTargetField.Enabled = false;
                    dataGridView1.ReadOnly = true;

                    dataGridView2.RowTemplate.Height = 30;
                    dataGridView2.DataSource = POBodyTable;
                    dataGridView2.Columns[0].HeaderText = "Brand";
                    dataGridView2.Columns[0].Width = 125;
                    dataGridView2.Columns[1].HeaderText = "Name";
                    dataGridView2.Columns[1].Width = 270;
                    dataGridView2.Columns[2].HeaderText = "Size";
                    dataGridView2.Columns[2].Width = 75;
                    dataGridView2.Columns[3].HeaderText = "Color";
                    dataGridView2.Columns[3].Width = 75;
                    dataGridView2.Columns[4].HeaderText = "Unit Cost";
                    dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns[4].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                    dataGridView2.Columns[4].Width = 65;
                    dataGridView2.Columns[4].DefaultCellStyle.Format = "N2";
                    //dataGridView2.Columns[4].Visible = false;
                    dataGridView2.Columns[5].HeaderText = "WH On Hand";
                    dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns[5].Width = 65;
                    //dataGridView2.Columns[5].Visible = false;
                    dataGridView2.Columns[6].HeaderText = "Order QTY";
                    dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns[6].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                    dataGridView2.Columns[6].Width = 65;
                    dataGridView2.Columns[7].HeaderText = "Receiving QTY";
                    dataGridView2.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns[7].Width = 55;
                    //dataGridView2.Columns[7].Visible = false;
                    dataGridView2.Columns[8].HeaderText = "Order Amount";
                    dataGridView2.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns[8].DefaultCellStyle.BackColor = Color.NavajoWhite;
                    dataGridView2.Columns[8].Width = 70;
                    dataGridView2.Columns[8].DefaultCellStyle.Format = "N2";
                    //dataGridView2.Columns[8].Visible = false;
                    dataGridView2.Columns[9].HeaderText = "Receiving Amount";
                    dataGridView2.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns[9].Width = 65;
                    dataGridView2.Columns[9].DefaultCellStyle.Format = "N2";
                    //dataGridView2.Columns[9].Visible = false;
                    //dataGridView2.Columns[9].Visible = false;
                    dataGridView2.Columns[10].HeaderText = "UPC";
                    dataGridView2.Columns[10].Width = 100;
                    dataGridView2.Columns[11].HeaderText = "Bin#";
                    dataGridView2.Columns[11].Width = 60;
                    //dataGridView2.Columns[11].Visible = false;

                    dataGridView2.ClearSelection();
                }
                else
                {
                    dataGridView2.RowTemplate.Height = 30;
                    dataGridView2.DataSource = POBodyTable;
                    dataGridView2.Columns[0].HeaderText = "Brand";
                    dataGridView2.Columns[0].Width = 125;
                    dataGridView2.Columns[1].HeaderText = "Name";
                    dataGridView2.Columns[1].Width = 270;
                    dataGridView2.Columns[2].HeaderText = "Size";
                    dataGridView2.Columns[2].Width = 75;
                    dataGridView2.Columns[3].HeaderText = "Color";
                    dataGridView2.Columns[3].Width = 75;
                    dataGridView2.Columns[4].HeaderText = "Unit Cost";
                    dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns[4].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                    dataGridView2.Columns[4].Width = 65;
                    dataGridView2.Columns[4].DefaultCellStyle.Format = "N2";
                    dataGridView2.Columns[5].HeaderText = "On Hand";
                    dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns[5].Width = 65;
                    dataGridView2.Columns[6].HeaderText = "Order QTY";
                    dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns[6].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                    dataGridView2.Columns[6].Width = 65;
                    dataGridView2.Columns[7].HeaderText = "Receiving QTY";
                    dataGridView2.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns[7].Width = 55;
                    //dataGridView2.Columns[7].Visible = false;
                    dataGridView2.Columns[8].HeaderText = "Order Amount";
                    dataGridView2.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns[8].DefaultCellStyle.BackColor = Color.NavajoWhite;
                    dataGridView2.Columns[8].Width = 70;
                    dataGridView2.Columns[8].DefaultCellStyle.Format = "N2";
                    dataGridView2.Columns[9].HeaderText = "Receiving Amount";
                    dataGridView2.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns[9].Width = 65;
                    dataGridView2.Columns[9].DefaultCellStyle.Format = "N2";
                    //dataGridView2.Columns[9].Visible = false;
                    dataGridView2.Columns[10].HeaderText = "UPC";
                    dataGridView2.Columns[10].Width = 100;
                    dataGridView2.Columns[11].HeaderText = "Bin#";
                    //dataGridView2.Columns[11].Visible = false;

                    dataGridView2.ClearSelection();
                }
            }
            else
            {
                if (VendorName == parentForm1.WarehouseName1)
                {
                    btnUpdate.Enabled = false;
                    btnTargetField.Enabled = false;
                    dataGridView1.ReadOnly = true;

                    dataGridView2.RowTemplate.Height = 30;
                    dataGridView2.DataSource = POBodyTable;
                    dataGridView2.Columns[0].HeaderText = "Brand";
                    dataGridView2.Columns[0].Width = 125;
                    dataGridView2.Columns[1].HeaderText = "Name";
                    dataGridView2.Columns[1].Width = 270;
                    dataGridView2.Columns[2].HeaderText = "Size";
                    dataGridView2.Columns[2].Width = 75;
                    dataGridView2.Columns[3].HeaderText = "Color";
                    dataGridView2.Columns[3].Width = 75;
                    dataGridView2.Columns[4].HeaderText = "Unit Cost";
                    dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns[4].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                    dataGridView2.Columns[4].Width = 65;
                    dataGridView2.Columns[4].DefaultCellStyle.Format = "N2";
                    dataGridView2.Columns[4].Visible = false;
                    dataGridView2.Columns[5].HeaderText = "WH On Hand";
                    dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns[5].Width = 65;
                    dataGridView2.Columns[5].Visible = false;
                    dataGridView2.Columns[6].HeaderText = "Order QTY";
                    dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns[6].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                    dataGridView2.Columns[6].Width = 65;
                    dataGridView2.Columns[7].HeaderText = "Receiving QTY";
                    dataGridView2.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns[7].Width = 55;
                    dataGridView2.Columns[7].Visible = false;
                    dataGridView2.Columns[8].HeaderText = "Order Amount";
                    dataGridView2.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns[8].DefaultCellStyle.BackColor = Color.NavajoWhite;
                    dataGridView2.Columns[8].Width = 70;
                    dataGridView2.Columns[8].DefaultCellStyle.Format = "N2";
                    dataGridView2.Columns[8].Visible = false;
                    dataGridView2.Columns[9].HeaderText = "Receiving Amount";
                    dataGridView2.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns[9].Width = 65;
                    dataGridView2.Columns[9].DefaultCellStyle.Format = "N2";
                    dataGridView2.Columns[9].Visible = false;
                    dataGridView2.Columns[9].Visible = false;
                    dataGridView2.Columns[10].HeaderText = "UPC";
                    dataGridView2.Columns[10].Width = 100;
                    dataGridView2.Columns[11].HeaderText = "Bin#";
                    dataGridView2.Columns[11].Width = 60;
                    //dataGridView2.Columns[11].Visible = false;

                    dataGridView2.ClearSelection();
                }
                else
                {
                    dataGridView2.RowTemplate.Height = 30;
                    dataGridView2.DataSource = POBodyTable;
                    dataGridView2.Columns[0].HeaderText = "Brand";
                    dataGridView2.Columns[0].Width = 125;
                    dataGridView2.Columns[1].HeaderText = "Name";
                    dataGridView2.Columns[1].Width = 270;
                    dataGridView2.Columns[2].HeaderText = "Size";
                    dataGridView2.Columns[2].Width = 75;
                    dataGridView2.Columns[3].HeaderText = "Color";
                    dataGridView2.Columns[3].Width = 75;
                    dataGridView2.Columns[4].HeaderText = "Unit Cost";
                    dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns[4].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                    dataGridView2.Columns[4].Width = 65;
                    dataGridView2.Columns[4].DefaultCellStyle.Format = "N2";
                    dataGridView2.Columns[5].HeaderText = "On Hand";
                    dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns[5].Width = 65;
                    dataGridView2.Columns[6].HeaderText = "Order QTY";
                    dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns[6].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                    dataGridView2.Columns[6].Width = 65;
                    dataGridView2.Columns[7].HeaderText = "Receiving QTY";
                    dataGridView2.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns[7].Width = 55;
                    dataGridView2.Columns[7].Visible = false;
                    dataGridView2.Columns[8].HeaderText = "Order Amount";
                    dataGridView2.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns[8].DefaultCellStyle.BackColor = Color.NavajoWhite;
                    dataGridView2.Columns[8].Width = 70;
                    dataGridView2.Columns[8].DefaultCellStyle.Format = "N2";
                    dataGridView2.Columns[9].HeaderText = "Receiving Amount";
                    dataGridView2.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns[9].Width = 65;
                    dataGridView2.Columns[9].DefaultCellStyle.Format = "N2";
                    dataGridView2.Columns[9].Visible = false;
                    dataGridView2.Columns[10].HeaderText = "UPC";
                    dataGridView2.Columns[10].Width = 100;
                    dataGridView2.Columns[11].HeaderText = "Bin#";
                    dataGridView2.Columns[11].Visible = false;

                    dataGridView2.ClearSelection();
                }
            }
        }

        private void POMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (option == 0)
            {
                if (parentForm2.IsDisposed == false)
                    parentForm2.SearchPOList();
            }
            else if (option == 1)
            {
                if (parentForm2.IsDisposed == false)
                    parentForm2.SearchPOList();

                if (parentForm4.IsDisposed == false)
                    parentForm4.Close();
            }
            else if (option == 2)
            {
                if (parentForm5.IsDisposed == false)
                    parentForm5.SearchPOList();
            }
            else if (option == 3)
            {
                if (parentForm2.IsDisposed == false)
                    parentForm2.SearchPOList();
            }
            else
            {
                if (parentForm2.IsDisposed == false)
                    parentForm2.SearchPOList();
            } 
        }
    }
}