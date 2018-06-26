using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;
//using Excel = Microsoft.Office.Interop.Excel;
using Office_12 = Microsoft.Office.Core;
using Excel_12 = Microsoft.Office.Interop.Excel;

namespace Management
{
    public partial class TimeCard : Form
    {
        public LogInManagements parentForm;

        int option;
        DataTable dt = new DataTable();

        DateTime startDate, endDate;
        Int32 nStartDate, nEndDate;

        DateTime BVStartDate, BVEndDate, BVStartDate_s, BVEndDate_s;
        Int32 nBVStartDate, nBVEndDate;
        Int32 nBVStartDate_s, nBVEndDate_s;

        SqlConnection newConn;

        public Font drvFont = new Font("Arial", 9);

        SqlCommand cmd_BV = new SqlCommand();
        DataTable BVdt = new DataTable();
        string fName, lName, biweekly;
        double sun = 0, mon = 0, tue = 0, wed = 0, thu = 0, fri = 0, sat = 0, sum = 0;
        double sun_fh = 0, mon_fh = 0, tue_fh = 0, wed_fh = 0, thu_fh = 0, fri_fh = 0, sat_fh = 0;
        double sun_ah = 0, mon_ah = 0, tue_ah = 0, wed_ah = 0, thu_ah = 0, fri_ah = 0, sat_ah = 0;
        double rh = 0, oh = 0;

        SqlCommand cmd_Settle;
        SqlCommand cmd_Unsettle;
        SqlCommand cmd_CheckSettle;

        double totalRegularHour = 0;
        double totalOvertimehour = 0;
        double totalWorkingHour = 0;

        public bool boolNumBtnUnsettle = false;
        Int64 checkNum;

        public TimeCard(int opt)
        {
            InitializeComponent();
            option = opt;
        }

        private void TimeCardView_Load(object sender, EventArgs e)
        {
            this.Text = "TIME CARD (LOCATION : " + parentForm.storeName.ToUpper() + " )";

            if (parentForm.StoreCode.ToUpper() == "TEST")
            {
                cmbStoreCode.Items.Add("TEST");
                cmbBVStoreCode.Items.Add("TEST");
                cmbStoreCode.Text = parentForm.StoreCode.ToUpper();
                cmbBVStoreCode.Text = parentForm.StoreCode.ToUpper();
            }
            else
            {
                SqlCommand cmd_StoreList = new SqlCommand("Get_StoreList_All", parentForm.conn);
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

                cmbStoreCode.Text = parentForm.StoreCode.ToUpper();

                cmbBVStoreCode.DataSource = ds_StoreList.Tables[0].DefaultView;
                cmbBVStoreCode.ValueMember = "CIStoreCode";
                cmbBVStoreCode.DisplayMember = "CIStoreCode";

                cmbBVStoreCode.Text = parentForm.StoreCode.ToUpper();
            }

            BVdt.Columns.Add("WEEK OF", typeof(string));
            BVdt.Columns.Add("LAST NAME", typeof(string));
            BVdt.Columns.Add("FIRST NAME", typeof(string));
            BVdt.Columns.Add("SUN", typeof(string));
            BVdt.Columns.Add("MON", typeof(string));
            BVdt.Columns.Add("TUE", typeof(string));
            BVdt.Columns.Add("WED", typeof(string));
            BVdt.Columns.Add("THU", typeof(string));
            BVdt.Columns.Add("FRI", typeof(string));
            BVdt.Columns.Add("SAT", typeof(string));
            BVdt.Columns.Add("SUM", typeof(string));
            BVdt.Columns.Add("R/H", typeof(string));
            BVdt.Columns.Add("O/H", typeof(string));

            if (parentForm.userLevel >= parentForm.GeneralManagerLV)
            {
                lblStoreCode.Visible = true;
                cmbStoreCode.Visible = true;
                lblBVStoreCode.Visible = true;
                cmbBVStoreCode.Visible = true;
            }
            else
            {
                lblStoreCode.Visible = false;
                cmbStoreCode.Visible = false;
                lblBVStoreCode.Visible = false;
                cmbBVStoreCode.Visible = false;
            }

            if (option == 0)
            {
                dataGridView1.ReadOnly = true;
                btnGenerateExcel.Visible = true;
                btnUpdatePost.Visible = false;
                btnDelete.Visible = false;
            }
            else if (option == 1)
            {
                //tabControl1.TabPages.Remove(tabPage2);
                dataGridView1.ReadOnly = false;
                btnDetailView.Visible = false;
                //btnSettle.Visible = false;
                //btnUnsettle.Visible = false;
                btnSettle.Visible = true;
                btnUnsettle.Visible = true;
                btnGenerateExcel.Visible = true;
                btnUpdatePost.Visible = true;
                btnDelete.Visible = true;
                //lblStoreCode.Visible = false;
                //cmbStoreCode.Visible = false;
            }

            txtStartDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            txtEndDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            txtBVStartDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

            if (parentForm.employeeID.ToUpper() == parentForm.SystemMasterUserName.ToUpper())
            {
                dataGridView4.Visible = true;
                label15.Visible = true;
            }
        }

        public void btnOK_Click(object sender, EventArgs e)
        {
            if (startDate.ToString() == "")
            {
                MessageBox.Show("SELECT DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (endDate.ToString() == "")
            {
                MessageBox.Show("SELECT END DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            startDate = Convert.ToDateTime(txtStartDate.Text);
            endDate = Convert.ToDateTime(txtEndDate.Text);

            nStartDate = Convert.ToInt32(startDate.ToString("yyyy") + startDate.ToString("MM") + startDate.ToString("dd"));
            nEndDate = Convert.ToInt32(endDate.ToString("yyyy") + endDate.ToString("MM") + endDate.ToString("dd"));

            if (parentForm.StoreCode == cmbStoreCode.Text.ToUpper().ToString())
            {
                dt.Clear();

                try
                {
                    this.Text = "TIME CARD (LOCATION : " + parentForm.storeName.ToUpper() + " )";

                    SqlCommand cmd = new SqlCommand("Show_TimeCard", parentForm.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@StartDate", SqlDbType.Int).Value = nStartDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.Int).Value = nEndDate;

                    SqlDataAdapter adapt = new SqlDataAdapter();
                    //dt = new DataTable();
                    adapt.SelectCommand = cmd;

                    parentForm.conn.Open();
                    adapt.Fill(dt);
                    parentForm.conn.Close();

                    SqlCommand cmd_WorkingHours = new SqlCommand("Get_WorkingHour", parentForm.conn);
                    cmd_WorkingHours.CommandType = CommandType.StoredProcedure;
                    cmd_WorkingHours.Parameters.Add("@StartDate", SqlDbType.Int).Value = nStartDate;
                    cmd_WorkingHours.Parameters.Add("@EndDate", SqlDbType.Int).Value = nEndDate;
                    SqlParameter Workinghours_Param = cmd_WorkingHours.Parameters.Add("@WorkingHour", SqlDbType.Float);
                    SqlParameter Numbers_Param = cmd_WorkingHours.Parameters.Add("@Numbers", SqlDbType.Int);
                    Workinghours_Param.Direction = ParameterDirection.Output;
                    Numbers_Param.Direction = ParameterDirection.Output;

                    parentForm.conn.Open();
                    cmd_WorkingHours.ExecuteNonQuery();
                    parentForm.conn.Close();

                    if (cmd_WorkingHours.Parameters["@WorkingHour"].Value != DBNull.Value)
                    {
                        label22.Text = string.Format("{0:0.00}", Convert.ToDouble(cmd_WorkingHours.Parameters["@WorkingHour"].Value));
                    }
                    else
                    {
                        label22.Text = "0.00";
                    }

                    if (cmd_WorkingHours.Parameters["@Numbers"].Value != DBNull.Value)
                    {
                        label20.Text = Convert.ToString(cmd_WorkingHours.Parameters["@Numbers"].Value);
                    }
                    else
                    {
                        label20.Text = "0";
                    }
                }
                catch
                {
                    MessageBox.Show("CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parentForm.conn.Close();
                    return;
                }
            }
            else
            {
                if (parentForm.UserChecking(cmbStoreCode.Text.Trim().ToUpper()) < 6)
                {
                    MessageBox.Show("You are not authorized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.DataSource = DBNull.Value;
                    return;
                }

                dt.Clear();

                if (cmbStoreCode.Text == "OH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.OHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.OHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    this.Text = "TIME CARD (LOCATION : OXON HILL)";
                }
                else if (cmbStoreCode.Text == "CH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    this.Text = "TIME CARD (LOCATION : CAPITOL HEIGHTS)";
                }
                else if (cmbStoreCode.Text == "WB")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WBIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WBDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    this.Text = "TIME CARD (LOCATION : WOODBRIDGE)";
                }
                else if (cmbStoreCode.Text == "CV")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CVIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CVDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    this.Text = "TIME CARD (LOCATION : CATONSVILLE)";
                }
                else if (cmbStoreCode.Text == "UM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.UMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.UMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    this.Text = "TIME CARD (LOCATION : UPPER MARLBORO)";
                }
                else if (cmbStoreCode.Text == "WM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    this.Text = "TIME CARD (LOCATION : WINDSOR MILL)";
                }
                else if (cmbStoreCode.Text == "TH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.THIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.THDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    this.Text = "TIME CARD (LOCATION : TEMPLE HILLS)";
                }
                else if (cmbStoreCode.Text == "WD")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WDIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WDDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    this.Text = "TIME CARD (LOCATION : WALDORF)";
                }
                else if (cmbStoreCode.Text == "PW")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.PWIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.PWDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    this.Text = "TIME CARD (LOCATION : PRINCE WILLIAM)";
                }
                else if (cmbStoreCode.Text == "GB")
                {
                    newConn = new SqlConnection(parentForm.GBCS_IP);
                    this.Text = "TIME CARD (LOCATION : GAITHERSBURG)";
                }
                else if (cmbStoreCode.Text == "BW")
                {
                    newConn = new SqlConnection(parentForm.BWCS_IP);
                    this.Text = "TIME CARD (LOCATION : BOWIE)";
                }
                else if (cmbStoreCode.Text == "B4UHQ")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.B4UHQIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.B4UHQDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    this.Text = "TIME CARD (LOCATION : BEAUTY 4U HEADQUARTES)";
                }
                else if (cmbStoreCode.Text == "B4UWH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.B4UWHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.B4UWHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    this.Text = "TIME CARD (LOCATION : BEAUTY 4U WAREHOUSE)";
                }
                else if (cmbStoreCode.Text == "TEST")
                {
                    newConn = new SqlConnection(parentForm.Test1CS);
                    this.Text = "TIME CARD (LOCATION : TEST)";
                }

                try
                {
                    SqlCommand cmd = new SqlCommand("Show_TimeCard", newConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@StartDate", SqlDbType.Int).Value = nStartDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.Int).Value = nEndDate;

                    SqlDataAdapter adapt = new SqlDataAdapter();
                    //dt = new DataTable();
                    adapt.SelectCommand = cmd;

                    newConn.Open();
                    adapt.Fill(dt);
                    newConn.Close();

                    SqlCommand cmd_WorkingHours = new SqlCommand("Get_WorkingHour", newConn);
                    cmd_WorkingHours.CommandType = CommandType.StoredProcedure;
                    cmd_WorkingHours.Parameters.Add("@StartDate", SqlDbType.Int).Value = nStartDate;
                    cmd_WorkingHours.Parameters.Add("@EndDate", SqlDbType.Int).Value = nEndDate;
                    SqlParameter Workinghours_Param = cmd_WorkingHours.Parameters.Add("@WorkingHour", SqlDbType.Float);
                    SqlParameter Numbers_Param = cmd_WorkingHours.Parameters.Add("@Numbers", SqlDbType.Int);
                    Workinghours_Param.Direction = ParameterDirection.Output;
                    Numbers_Param.Direction = ParameterDirection.Output;

                    newConn.Open();
                    cmd_WorkingHours.ExecuteNonQuery();
                    newConn.Close();

                    if (cmd_WorkingHours.Parameters["@WorkingHour"].Value != DBNull.Value)
                    {
                        label22.Text = string.Format("{0:0.00}", Convert.ToDouble(cmd_WorkingHours.Parameters["@WorkingHour"].Value));
                    }
                    else
                    {
                        label22.Text = "0.00";
                    }

                    if (cmd_WorkingHours.Parameters["@Numbers"].Value != DBNull.Value)
                    {
                        label20.Text = Convert.ToString(cmd_WorkingHours.Parameters["@Numbers"].Value);
                    }
                    else
                    {
                        label20.Text = "0";
                    }
                }
                catch
                {
                    MessageBox.Show("CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    newConn.Close();
                    return;
                }
            }

            if (parentForm.userLevel >= parentForm.SystemAdministratorLV & parentForm.employeeID.ToUpper() == parentForm.SystemMasterUserName.ToUpper())
            {
                dataGridView1.RowTemplate.Height = 30;
                dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 60;
                dataGridView1.Columns[1].HeaderText = "Store Code";
                dataGridView1.Columns[1].Width = 50;
                dataGridView1.Columns[2].HeaderText = "Employee ID";
                dataGridView1.Columns[2].Width = 80;
                dataGridView1.Columns[3].HeaderText = "Employee First Name";
                dataGridView1.Columns[3].Width = 95;
                dataGridView1.Columns[4].HeaderText = "Employee Last Name";
                dataGridView1.Columns[4].Width = 95;
                dataGridView1.Columns[5].HeaderText = "Date";
                dataGridView1.Columns[5].Width = 70;
                dataGridView1.Columns[6].HeaderText = "Clock In  (R)";
                dataGridView1.Columns[6].Width = 120;
                dataGridView1.Columns[7].HeaderText = "Clock Out (R)";
                dataGridView1.Columns[7].Width = 120;
                dataGridView1.Columns[8].HeaderText = "Clock In  (C)";
                dataGridView1.Columns[8].Width = 120;
                dataGridView1.Columns[9].HeaderText = "Clock Out (C)";
                dataGridView1.Columns[9].Width = 120;
                dataGridView1.Columns[10].HeaderText = "Min";
                dataGridView1.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[10].Width = 45;
                dataGridView1.Columns[11].HeaderText = "Hr";
                dataGridView1.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[11].Width = 45;
                dataGridView1.Columns[12].HeaderText = "Hr (A)";
                dataGridView1.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[12].Width = 45;
                dataGridView1.Columns[13].HeaderText = "Reason";
                dataGridView1.Columns[13].Width = 70;
                dataGridView1.Columns[14].HeaderText = "Updater ID";
                dataGridView1.Columns[14].Width = 90;
                dataGridView1.Columns[15].HeaderText = "Update Date";
                dataGridView1.Columns[15].Width = 80;
                dataGridView1.Columns[16].HeaderText = "Hr (F)";
                dataGridView1.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[16].Width = 45;
                dataGridView1.Columns[16].DefaultCellStyle.BackColor = Color.Yellow;
                dataGridView1.Columns[17].HeaderText = "Wage (T)";
                dataGridView1.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[17].Width = 50;
                dataGridView1.Columns[18].HeaderText = "Settled";
                dataGridView1.Columns[18].Width = 65;
                dataGridView1.Columns[19].HeaderText = "Settle ID";
                dataGridView1.Columns[19].Width = 90;
                dataGridView1.Columns[20].HeaderText = "Settle Date";
                dataGridView1.Columns[20].Width = 90;
                dataGridView1.Columns[21].HeaderText = "Unsettle ID";
                dataGridView1.Columns[21].Width = 80;
                dataGridView1.Columns[22].HeaderText = "Unsettle Date";
                dataGridView1.Columns[22].Width = 80;

                dataGridView1.ClearSelection();
            }
            else
            {
                dataGridView1.RowTemplate.Height = 30;
                dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 60;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Store Code";
                dataGridView1.Columns[1].Width = 50;
                //dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[2].HeaderText = "Employee ID";
                dataGridView1.Columns[2].Width = 80;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].HeaderText = "Employee First Name";
                dataGridView1.Columns[3].Width = 95;
                //dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[4].HeaderText = "Employee Last Name";
                dataGridView1.Columns[4].Width = 95;
                //dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[5].HeaderText = "Date";
                dataGridView1.Columns[5].Width = 70;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].HeaderText = "Clock In  (R)";
                dataGridView1.Columns[6].Width = 110;
                //dataGridView1.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[7].HeaderText = "Clock Out (R)";
                dataGridView1.Columns[7].Width = 110;
                //dataGridView1.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[8].HeaderText = "Clock In  (C)";
                dataGridView1.Columns[8].Width = 110;
                //dataGridView1.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[9].HeaderText = "Clock Out (C)";
                dataGridView1.Columns[9].Width = 110;
                //dataGridView1.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[10].HeaderText = "Min";
                dataGridView1.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[10].Width = 45;
                //dataGridView1.Columns[10].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[11].HeaderText = "Hr";
                dataGridView1.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[11].Width = 45;
                //dataGridView1.Columns[11].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[12].HeaderText = "Hr (A)";
                dataGridView1.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[12].Width = 45;
                //dataGridView1.Columns[12].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[13].HeaderText = "Reason";
                dataGridView1.Columns[13].Width = 70;
                //dataGridView1.Columns[13].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[14].HeaderText = "Updater ID";
                dataGridView1.Columns[14].Width = 90;
                //dataGridView1.Columns[14].Visible = false;
                dataGridView1.Columns[15].HeaderText = "Update Date";
                dataGridView1.Columns[15].Width = 80;
                //dataGridView1.Columns[15].Visible = false;
                dataGridView1.Columns[16].HeaderText = "Hr (F)";
                dataGridView1.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[16].Width = 45;
                //dataGridView1.Columns[16].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[16].DefaultCellStyle.BackColor = Color.Yellow;
                dataGridView1.Columns[17].HeaderText = "Wage (T)";
                dataGridView1.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[17].Width = 50;
                dataGridView1.Columns[17].Visible = false;
                dataGridView1.Columns[18].HeaderText = "Settled";
                dataGridView1.Columns[18].Width = 65;
                //dataGridView1.Columns[18].Visible = false;
                dataGridView1.Columns[19].HeaderText = "Settle ID";
                dataGridView1.Columns[19].Width = 90;
                //dataGridView1.Columns[19].Visible = false;
                dataGridView1.Columns[20].HeaderText = "Settle Date";
                dataGridView1.Columns[20].Width = 90;
                //dataGridView1.Columns[20].Visible = false;
                dataGridView1.Columns[21].HeaderText = "Unsettle ID";
                dataGridView1.Columns[21].Width = 80;
                dataGridView1.Columns[21].Visible = false;
                dataGridView1.Columns[22].HeaderText = "Unsettle Date";
                dataGridView1.Columns[22].Width = 80;
                dataGridView1.Columns[22].Visible = false;

                dataGridView1.ClearSelection();
            }

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[12].Value == DBNull.Value)
                {
                    if (dataGridView1.Rows[i].Cells[16].Value == DBNull.Value)
                    {
                        dataGridView1.Rows[i].Cells[10].Style.BackColor = Color.Red;
                        dataGridView1.Rows[i].Cells[11].Style.BackColor = Color.Red;
                    }
                    else if (Convert.ToDouble(dataGridView1.Rows[i].Cells[16].Value) < 1)
                    {
                        dataGridView1.Rows[i].Cells[10].Style.BackColor = Color.Red;
                        dataGridView1.Rows[i].Cells[11].Style.BackColor = Color.Red;
                    }
                }
                else
                {
                    if (dataGridView1.Rows[i].Cells[12].Value != DBNull.Value)
                        dataGridView1.Rows[i].Cells[11].Style.ForeColor = Color.Red;

                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtStartDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void txtEndDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar2.Visible = true;
        }

        private void btnGenerateExcel_Click(object sender, EventArgs e)
        {
            if (parentForm.employeeID.ToUpper() == "ADMIN")
            {
                if (dataGridView1.RowCount > 0)
                {
                    /*for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        if (dataGridView1.Rows[i].Cells[10].Style.BackColor == Color.Red | dataGridView1.Rows[i].Cells[11].Style.BackColor == Color.Red)
                        {
                            MessageBox.Show("PLEASE CORRECT ALL ERRORS (INDICATED BY THE RED CELL) ON THE TIME CARD IN ORDER TO SETTLE AND GENERATE AN EXCEL SHEEET", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[18].Value) == false)
                        {
                            MessageBox.Show("UNSETTLED TIME CARDS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }*/

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
            //else if (parentForm.specialCode == parentForm.txtSpecialCode.Text.Trim().ToString().ToUpper())
            else
            {
                if (dataGridView1.RowCount > 0)
                {
                    /*if (parentForm.StoreCode != cmbStoreCode.Text.ToUpper().ToString())
                    {
                        MessageBox.Show("INCORRECT STORE CODE \n" + "YOUR ORIGINAL LOCATION IS " + parentForm.storeName + " STORE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }*/

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        if (dataGridView1.Rows[i].Cells[10].Style.BackColor == Color.Red | dataGridView1.Rows[i].Cells[11].Style.BackColor == Color.Red)
                        {
                            MessageBox.Show("PLEASE CORRECT ALL ERRORS (INDICATED BY THE RED CELL) ON THE TIME CARD IN ORDER TO SETTLE AND GENERATE AN EXCEL SHEEET", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[18].Value) == false)
                        {
                            MessageBox.Show("UNSETTLED TIME CARDS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

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
            /*else
            {
                if (dataGridView1.RowCount > 0)
                {
                    if (parentForm.StoreCode != cmbStoreCode.Text.ToUpper().ToString())
                    {
                        MessageBox.Show("INCORRECT STORE CODE \n" + "YOUR ORIGINAL LOCATION IS " + parentForm.storeName + " STORE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        if (dataGridView1.Rows[i].Cells[10].Style.BackColor == Color.Red | dataGridView1.Rows[i].Cells[11].Style.BackColor == Color.Red)
                        {
                            MessageBox.Show("PLEASE CORRECT ALL ERRORS (INDICATED BY THE RED CELL) ON THE TIME CARD IN ORDER TO SETTLE AND GENERATE AN EXCEL SHEEET", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[18].Value) == false)
                        {
                            MessageBox.Show("UNSETTLED TIME CARDS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    ExportDataGridViewTo_Excel12(dataGridView1);
                }
                else
                {
                    MessageBox.Show("NO DATA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }*/
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (parentForm.StoreCode == cmbStoreCode.Text.ToUpper().ToString())
            {
                if (e.RowIndex != -1)
                {
                    startDate = Convert.ToDateTime(txtStartDate.Text);
                    endDate = Convert.ToDateTime(txtEndDate.Text);

                    nStartDate = Convert.ToInt32(startDate.ToString("yyyy") + startDate.ToString("MM") + startDate.ToString("dd"));
                    nEndDate = Convert.ToInt32(endDate.ToString("yyyy") + endDate.ToString("MM") + endDate.ToString("dd"));

                    if (startDate.ToString() == "")
                    {
                        MessageBox.Show("SELECT DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (endDate.ToString() == "")
                    {
                        MessageBox.Show("SELECT END DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        for (int j = 0; j < dataGridView1.ColumnCount; j++)
                        {
                            if (dataGridView1.Rows[i].Cells[j].Selected == true)
                            {
                                SqlCommand cmd = new SqlCommand("Show_TimeCard_By_EmployeeID", parentForm.conn);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@StartDate", SqlDbType.Int).Value = nStartDate;
                                cmd.Parameters.Add("@EndDate", SqlDbType.Int).Value = nEndDate;
                                cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[2].Value.ToString().ToUpper();

                                SqlDataAdapter adapt = new SqlDataAdapter();
                                DataTable dt = new DataTable();
                                adapt.SelectCommand = cmd;

                                parentForm.conn.Open();
                                adapt.Fill(dt);
                                parentForm.conn.Close();

                                SqlCommand cmd_WorkingHours = new SqlCommand("Get_WorkingHour_By_EmployeeID", parentForm.conn);
                                cmd_WorkingHours.CommandType = CommandType.StoredProcedure;
                                cmd_WorkingHours.Parameters.Add("@StartDate", SqlDbType.Int).Value = nStartDate;
                                cmd_WorkingHours.Parameters.Add("@EndDate", SqlDbType.Int).Value = nEndDate;
                                cmd_WorkingHours.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[2].Value.ToString().ToUpper();
                                SqlParameter Workinghours_Param = cmd_WorkingHours.Parameters.Add("@WorkingHour", SqlDbType.Float);
                                SqlParameter Numbers_Param = cmd_WorkingHours.Parameters.Add("@Numbers", SqlDbType.Int);
                                Workinghours_Param.Direction = ParameterDirection.Output;
                                Numbers_Param.Direction = ParameterDirection.Output;

                                parentForm.conn.Open();
                                cmd_WorkingHours.ExecuteNonQuery();
                                parentForm.conn.Close();

                                if (cmd_WorkingHours.Parameters["@WorkingHour"].Value != DBNull.Value)
                                {
                                    label22.Text = string.Format("{0:0.00}", Convert.ToDouble(cmd_WorkingHours.Parameters["@WorkingHour"].Value));
                                }
                                else
                                {
                                    label22.Text = "0.00";
                                }

                                if (cmd_WorkingHours.Parameters["@Numbers"].Value != DBNull.Value)
                                {
                                    label20.Text = Convert.ToString(cmd_WorkingHours.Parameters["@Numbers"].Value);
                                }
                                else
                                {
                                    label20.Text = "0";
                                }

                                if (parentForm.userLevel >= parentForm.SystemAdministratorLV & parentForm.employeeID.ToUpper() == parentForm.SystemMasterUserName.ToUpper())
                                {
                                    dataGridView1.RowTemplate.Height = 30;
                                    dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                                    dataGridView1.DataSource = dt;
                                    dataGridView1.Columns[0].Width = 60;
                                    dataGridView1.Columns[1].HeaderText = "Store Code";
                                    dataGridView1.Columns[1].Width = 50;
                                    dataGridView1.Columns[2].HeaderText = "Employee ID";
                                    dataGridView1.Columns[2].Width = 80;
                                    dataGridView1.Columns[3].HeaderText = "Employee First Name";
                                    dataGridView1.Columns[3].Width = 95;
                                    dataGridView1.Columns[4].HeaderText = "Employee Last Name";
                                    dataGridView1.Columns[4].Width = 95;
                                    dataGridView1.Columns[5].HeaderText = "Date";
                                    dataGridView1.Columns[5].Width = 70;
                                    dataGridView1.Columns[6].HeaderText = "Clock In  (R)";
                                    dataGridView1.Columns[6].Width = 120;
                                    dataGridView1.Columns[7].HeaderText = "Clock Out (R)";
                                    dataGridView1.Columns[7].Width = 120;
                                    dataGridView1.Columns[8].HeaderText = "Clock In  (C)";
                                    dataGridView1.Columns[8].Width = 120;
                                    dataGridView1.Columns[9].HeaderText = "Clock Out (C)";
                                    dataGridView1.Columns[9].Width = 120;
                                    dataGridView1.Columns[10].HeaderText = "Min";
                                    dataGridView1.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    dataGridView1.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    dataGridView1.Columns[10].Width = 45;
                                    dataGridView1.Columns[11].HeaderText = "Hr";
                                    dataGridView1.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    dataGridView1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    dataGridView1.Columns[11].Width = 45;
                                    dataGridView1.Columns[12].HeaderText = "Hr (A)";
                                    dataGridView1.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    dataGridView1.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    dataGridView1.Columns[12].Width = 45;
                                    dataGridView1.Columns[13].HeaderText = "Reason";
                                    dataGridView1.Columns[13].Width = 70;
                                    dataGridView1.Columns[14].HeaderText = "Updater ID";
                                    dataGridView1.Columns[14].Width = 90;
                                    dataGridView1.Columns[15].HeaderText = "Update Date";
                                    dataGridView1.Columns[15].Width = 80;
                                    dataGridView1.Columns[16].HeaderText = "Hr (F)";
                                    dataGridView1.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    dataGridView1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    dataGridView1.Columns[16].Width = 45;
                                    dataGridView1.Columns[16].DefaultCellStyle.BackColor = Color.Yellow;
                                    dataGridView1.Columns[17].HeaderText = "Wage (T)";
                                    dataGridView1.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    dataGridView1.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    dataGridView1.Columns[17].Width = 50;
                                    dataGridView1.Columns[18].HeaderText = "Settled";
                                    dataGridView1.Columns[18].Width = 65;
                                    dataGridView1.Columns[19].HeaderText = "Settle ID";
                                    dataGridView1.Columns[19].Width = 90;
                                    dataGridView1.Columns[20].HeaderText = "Settle Date";
                                    dataGridView1.Columns[20].Width = 90;
                                    dataGridView1.Columns[21].HeaderText = "Unsettle ID";
                                    dataGridView1.Columns[21].Width = 80;
                                    dataGridView1.Columns[22].HeaderText = "Unsettle Date";
                                    dataGridView1.Columns[22].Width = 80;

                                    dataGridView1.ClearSelection();
                                }
                                else
                                {
                                    dataGridView1.RowTemplate.Height = 30;
                                    dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                                    dataGridView1.DataSource = dt;
                                    dataGridView1.Columns[0].Width = 60;
                                    dataGridView1.Columns[0].Visible = false;
                                    dataGridView1.Columns[1].HeaderText = "Store Code";
                                    dataGridView1.Columns[1].Width = 50;
                                    dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                                    dataGridView1.Columns[2].HeaderText = "Employee ID";
                                    dataGridView1.Columns[2].Width = 80;
                                    dataGridView1.Columns[2].Visible = false;
                                    dataGridView1.Columns[3].HeaderText = "Employee First Name";
                                    dataGridView1.Columns[3].Width = 95;
                                    dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                                    dataGridView1.Columns[4].HeaderText = "Employee Last Name";
                                    dataGridView1.Columns[4].Width = 95;
                                    dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                                    dataGridView1.Columns[5].HeaderText = "Date";
                                    dataGridView1.Columns[5].Width = 70;
                                    dataGridView1.Columns[5].Visible = false;
                                    dataGridView1.Columns[6].HeaderText = "Clock In  (R)";
                                    dataGridView1.Columns[6].Width = 120;
                                    dataGridView1.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
                                    dataGridView1.Columns[7].HeaderText = "Clock Out (R)";
                                    dataGridView1.Columns[7].Width = 120;
                                    dataGridView1.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
                                    dataGridView1.Columns[8].HeaderText = "Clock In  (C)";
                                    dataGridView1.Columns[8].Width = 120;
                                    dataGridView1.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
                                    dataGridView1.Columns[9].HeaderText = "Clock Out (C)";
                                    dataGridView1.Columns[9].Width = 120;
                                    dataGridView1.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;
                                    dataGridView1.Columns[10].HeaderText = "Min";
                                    dataGridView1.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    dataGridView1.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    dataGridView1.Columns[10].Width = 45;
                                    dataGridView1.Columns[10].SortMode = DataGridViewColumnSortMode.NotSortable;
                                    dataGridView1.Columns[11].HeaderText = "Hr";
                                    dataGridView1.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    dataGridView1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    dataGridView1.Columns[11].Width = 45;
                                    dataGridView1.Columns[11].SortMode = DataGridViewColumnSortMode.NotSortable;
                                    dataGridView1.Columns[12].HeaderText = "Hr (A)";
                                    dataGridView1.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    dataGridView1.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    dataGridView1.Columns[12].Width = 45;
                                    dataGridView1.Columns[12].SortMode = DataGridViewColumnSortMode.NotSortable;
                                    dataGridView1.Columns[13].HeaderText = "Reason";
                                    dataGridView1.Columns[13].Width = 70;
                                    dataGridView1.Columns[13].SortMode = DataGridViewColumnSortMode.NotSortable;
                                    dataGridView1.Columns[14].HeaderText = "Updater ID";
                                    dataGridView1.Columns[14].Width = 90;
                                    dataGridView1.Columns[14].Visible = false;
                                    dataGridView1.Columns[15].HeaderText = "Update Date";
                                    dataGridView1.Columns[15].Width = 80;
                                    dataGridView1.Columns[15].Visible = false;
                                    dataGridView1.Columns[16].HeaderText = "Hr (F)";
                                    dataGridView1.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    dataGridView1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    dataGridView1.Columns[16].Width = 45;
                                    dataGridView1.Columns[16].SortMode = DataGridViewColumnSortMode.NotSortable;
                                    dataGridView1.Columns[16].DefaultCellStyle.BackColor = Color.Yellow;
                                    dataGridView1.Columns[17].HeaderText = "Wage (T)";
                                    dataGridView1.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    dataGridView1.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    dataGridView1.Columns[17].Width = 50;
                                    dataGridView1.Columns[17].Visible = false;
                                    dataGridView1.Columns[18].HeaderText = "Settled";
                                    dataGridView1.Columns[18].Width = 65;
                                    dataGridView1.Columns[18].Visible = false;
                                    dataGridView1.Columns[19].HeaderText = "Settle ID";
                                    dataGridView1.Columns[19].Width = 90;
                                    dataGridView1.Columns[19].Visible = false;
                                    dataGridView1.Columns[20].HeaderText = "Settle Date";
                                    dataGridView1.Columns[20].Width = 90;
                                    dataGridView1.Columns[20].Visible = false;
                                    dataGridView1.Columns[21].HeaderText = "Unsettle ID";
                                    dataGridView1.Columns[21].Width = 80;
                                    dataGridView1.Columns[21].Visible = false;
                                    dataGridView1.Columns[22].HeaderText = "Unsettle Date";
                                    dataGridView1.Columns[22].Width = 80;
                                    dataGridView1.Columns[22].Visible = false;

                                    dataGridView1.ClearSelection();
                                }

                                break;
                            }
                        }
                    }

                    for (int k = 0; k < dataGridView1.RowCount; k++)
                    {
                        if (dataGridView1.Rows[k].Cells[12].Value == DBNull.Value)
                        {
                            if (dataGridView1.Rows[k].Cells[16].Value == DBNull.Value)
                            {
                                dataGridView1.Rows[k].Cells[10].Style.BackColor = Color.Red;
                                dataGridView1.Rows[k].Cells[11].Style.BackColor = Color.Red;
                            }
                            else if (Convert.ToDouble(dataGridView1.Rows[k].Cells[16].Value) < 1)
                            {
                                dataGridView1.Rows[k].Cells[10].Style.BackColor = Color.Red;
                                dataGridView1.Rows[k].Cells[11].Style.BackColor = Color.Red;
                            }
                        }
                        else
                        {
                            if (dataGridView1.Rows[k].Cells[12].Value != DBNull.Value)
                                dataGridView1.Rows[k].Cells[11].Style.ForeColor = Color.Red;

                        }
                    }
                }
            }
            else
            {
                if (e.RowIndex != -1)
                {
                    if (cmbStoreCode.Text == "OH")
                    {
                        newConn = new SqlConnection("Data Source=" + parentForm.OHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.OHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                        this.Text = "TIME CARD (LOCATION : OXON HILL)";
                    }
                    else if (cmbStoreCode.Text == "CH")
                    {
                        newConn = new SqlConnection("Data Source=" + parentForm.CHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                        this.Text = "TIME CARD (LOCATION : CAPITOL HEIGHTS)";
                    }
                    else if (cmbStoreCode.Text == "WB")
                    {
                        newConn = new SqlConnection("Data Source=" + parentForm.WBIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WBDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                        this.Text = "TIME CARD (LOCATION : WOODBRIDGE)";
                    }
                    else if (cmbStoreCode.Text == "CV")
                    {
                        newConn = new SqlConnection("Data Source=" + parentForm.CVIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CVDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                        this.Text = "TIME CARD (LOCATION : CATONSVILLE)";
                    }
                    else if (cmbStoreCode.Text == "UM")
                    {
                        newConn = new SqlConnection("Data Source=" + parentForm.UMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.UMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                        this.Text = "TIME CARD (LOCATION : UPPER MARLBORO)";
                    }
                    else if (cmbStoreCode.Text == "WM")
                    {
                        newConn = new SqlConnection("Data Source=" + parentForm.WMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                        this.Text = "TIME CARD (LOCATION : WINDSOR MILL)";
                    }
                    else if (cmbStoreCode.Text == "TH")
                    {
                        newConn = new SqlConnection("Data Source=" + parentForm.THIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.THDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                        this.Text = "TIME CARD (LOCATION : TEMPLE HILLS)";
                    }
                    else if (cmbStoreCode.Text == "WD")
                    {
                        newConn = new SqlConnection("Data Source=" + parentForm.WDIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WDDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                        this.Text = "TIME CARD (LOCATION : WALDORF)";
                    }
                    else if (cmbStoreCode.Text == "PW")
                    {
                        newConn = new SqlConnection("Data Source=" + parentForm.PWIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.PWDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                        this.Text = "TIME CARD (LOCATION : PRINCE WILLIAM)";
                    }
                    else if (cmbStoreCode.Text == "GB")
                    {
                        newConn = new SqlConnection(parentForm.GBCS_IP);
                        this.Text = "TIME CARD (LOCATION : GAITHERSBURG)";
                    }
                    else if (cmbStoreCode.Text == "B4UHQ")
                    {
                        newConn = new SqlConnection("Data Source=" + parentForm.B4UHQIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.B4UHQDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                        this.Text = "TIME CARD (LOCATION : BEAUTY 4U HEADQUARTES)";
                    }
                    else if (cmbStoreCode.Text == "B4UWH")
                    {
                        newConn = new SqlConnection("Data Source=" + parentForm.B4UWHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.B4UWHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                        this.Text = "TIME CARD (LOCATION : BEAUTY 4U WAREHOUSE)";
                    }
                    else if (cmbStoreCode.Text == "TEST")
                    {
                        newConn = new SqlConnection(parentForm.Test1CS);
                        this.Text = "TIME CARD (LOCATION : TEST)";
                    }

                    startDate = Convert.ToDateTime(txtStartDate.Text);
                    endDate = Convert.ToDateTime(txtEndDate.Text);

                    nStartDate = Convert.ToInt32(startDate.ToString("yyyy") + startDate.ToString("MM") + startDate.ToString("dd"));
                    nEndDate = Convert.ToInt32(endDate.ToString("yyyy") + endDate.ToString("MM") + endDate.ToString("dd"));

                    if (startDate.ToString() == "")
                    {
                        MessageBox.Show("SELECT DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (endDate.ToString() == "")
                    {
                        MessageBox.Show("SELECT END DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        for (int j = 0; j < dataGridView1.ColumnCount; j++)
                        {
                            if (dataGridView1.Rows[i].Cells[j].Selected == true)
                            {
                                SqlCommand cmd = new SqlCommand("Show_TimeCard_By_EmployeeID", newConn);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@StartDate", SqlDbType.Int).Value = nStartDate;
                                cmd.Parameters.Add("@EndDate", SqlDbType.Int).Value = nEndDate;
                                cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[2].Value.ToString().ToUpper();

                                SqlDataAdapter adapt = new SqlDataAdapter();
                                DataTable dt = new DataTable();
                                adapt.SelectCommand = cmd;

                                newConn.Open();
                                adapt.Fill(dt);
                                newConn.Close();

                                SqlCommand cmd_WorkingHours = new SqlCommand("Get_WorkingHour_By_EmployeeID", newConn);
                                cmd_WorkingHours.CommandType = CommandType.StoredProcedure;
                                cmd_WorkingHours.Parameters.Add("@StartDate", SqlDbType.Int).Value = nStartDate;
                                cmd_WorkingHours.Parameters.Add("@EndDate", SqlDbType.Int).Value = nEndDate;
                                cmd_WorkingHours.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[2].Value.ToString().ToUpper();
                                SqlParameter Workinghours_Param = cmd_WorkingHours.Parameters.Add("@WorkingHour", SqlDbType.Float);
                                SqlParameter Numbers_Param = cmd_WorkingHours.Parameters.Add("@Numbers", SqlDbType.Int);
                                Workinghours_Param.Direction = ParameterDirection.Output;
                                Numbers_Param.Direction = ParameterDirection.Output;

                                newConn.Open();
                                cmd_WorkingHours.ExecuteNonQuery();
                                newConn.Close();

                                if (cmd_WorkingHours.Parameters["@WorkingHour"].Value != DBNull.Value)
                                {
                                    label22.Text = string.Format("{0:0.00}", Convert.ToDouble(cmd_WorkingHours.Parameters["@WorkingHour"].Value));
                                }
                                else
                                {
                                    label22.Text = "0.00";
                                }

                                if (cmd_WorkingHours.Parameters["@Numbers"].Value != DBNull.Value)
                                {
                                    label20.Text = Convert.ToString(cmd_WorkingHours.Parameters["@Numbers"].Value);
                                }
                                else
                                {
                                    label20.Text = "0";
                                }

                                if (parentForm.userLevel >= parentForm.SystemAdministratorLV & parentForm.employeeID.ToUpper() == parentForm.SystemMasterUserName.ToUpper())
                                {
                                    dataGridView1.RowTemplate.Height = 30;
                                    dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                                    dataGridView1.DataSource = dt;
                                    dataGridView1.Columns[0].Width = 60;
                                    dataGridView1.Columns[1].HeaderText = "Store Code";
                                    dataGridView1.Columns[1].Width = 50;
                                    dataGridView1.Columns[2].HeaderText = "Employee ID";
                                    dataGridView1.Columns[2].Width = 80;
                                    dataGridView1.Columns[3].HeaderText = "Employee First Name";
                                    dataGridView1.Columns[3].Width = 95;
                                    dataGridView1.Columns[4].HeaderText = "Employee Last Name";
                                    dataGridView1.Columns[4].Width = 95;
                                    dataGridView1.Columns[5].HeaderText = "Date";
                                    dataGridView1.Columns[5].Width = 70;
                                    dataGridView1.Columns[6].HeaderText = "Clock In  (R)";
                                    dataGridView1.Columns[6].Width = 120;
                                    dataGridView1.Columns[7].HeaderText = "Clock Out (R)";
                                    dataGridView1.Columns[7].Width = 120;
                                    dataGridView1.Columns[8].HeaderText = "Clock In  (C)";
                                    dataGridView1.Columns[8].Width = 120;
                                    dataGridView1.Columns[9].HeaderText = "Clock Out (C)";
                                    dataGridView1.Columns[9].Width = 120;
                                    dataGridView1.Columns[10].HeaderText = "Min";
                                    dataGridView1.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    dataGridView1.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    dataGridView1.Columns[10].Width = 45;
                                    dataGridView1.Columns[11].HeaderText = "Hr";
                                    dataGridView1.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    dataGridView1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    dataGridView1.Columns[11].Width = 45;
                                    dataGridView1.Columns[12].HeaderText = "Hr (A)";
                                    dataGridView1.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    dataGridView1.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    dataGridView1.Columns[12].Width = 45;
                                    dataGridView1.Columns[13].HeaderText = "Reason";
                                    dataGridView1.Columns[13].Width = 70;
                                    dataGridView1.Columns[14].HeaderText = "Updater ID";
                                    dataGridView1.Columns[14].Width = 90;
                                    dataGridView1.Columns[15].HeaderText = "Update Date";
                                    dataGridView1.Columns[15].Width = 80;
                                    dataGridView1.Columns[16].HeaderText = "Hr (F)";
                                    dataGridView1.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    dataGridView1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    dataGridView1.Columns[16].Width = 45;
                                    dataGridView1.Columns[16].DefaultCellStyle.BackColor = Color.LightYellow;
                                    dataGridView1.Columns[17].HeaderText = "Wage (T)";
                                    dataGridView1.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    dataGridView1.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    dataGridView1.Columns[17].Width = 50;
                                    dataGridView1.Columns[18].HeaderText = "Settled";
                                    dataGridView1.Columns[18].Width = 65;
                                    dataGridView1.Columns[19].HeaderText = "Settle ID";
                                    dataGridView1.Columns[19].Width = 90;
                                    dataGridView1.Columns[20].HeaderText = "Settle Date";
                                    dataGridView1.Columns[20].Width = 90;
                                    dataGridView1.Columns[21].HeaderText = "Unsettle ID";
                                    dataGridView1.Columns[21].Width = 80;
                                    dataGridView1.Columns[22].HeaderText = "Unsettle Date";
                                    dataGridView1.Columns[22].Width = 80;

                                    dataGridView1.ClearSelection();
                                }
                                else
                                {
                                    dataGridView1.RowTemplate.Height = 30;
                                    dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
                                    dataGridView1.DataSource = dt;
                                    dataGridView1.Columns[0].Width = 60;
                                    dataGridView1.Columns[0].Visible = false;
                                    dataGridView1.Columns[1].HeaderText = "Store Code";
                                    dataGridView1.Columns[1].Width = 50;
                                    dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                                    dataGridView1.Columns[2].HeaderText = "Employee ID";
                                    dataGridView1.Columns[2].Width = 80;
                                    dataGridView1.Columns[2].Visible = false;
                                    dataGridView1.Columns[3].HeaderText = "Employee First Name";
                                    dataGridView1.Columns[3].Width = 95;
                                    dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                                    dataGridView1.Columns[4].HeaderText = "Employee Last Name";
                                    dataGridView1.Columns[4].Width = 95;
                                    dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                                    dataGridView1.Columns[5].HeaderText = "Date";
                                    dataGridView1.Columns[5].Width = 70;
                                    dataGridView1.Columns[5].Visible = false;
                                    dataGridView1.Columns[6].HeaderText = "Clock In  (R)";
                                    dataGridView1.Columns[6].Width = 120;
                                    dataGridView1.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
                                    dataGridView1.Columns[7].HeaderText = "Clock Out (R)";
                                    dataGridView1.Columns[7].Width = 120;
                                    dataGridView1.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
                                    dataGridView1.Columns[8].HeaderText = "Clock In  (C)";
                                    dataGridView1.Columns[8].Width = 120;
                                    dataGridView1.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
                                    dataGridView1.Columns[9].HeaderText = "Clock Out (C)";
                                    dataGridView1.Columns[9].Width = 120;
                                    dataGridView1.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;
                                    dataGridView1.Columns[10].HeaderText = "Min";
                                    dataGridView1.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    dataGridView1.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    dataGridView1.Columns[10].Width = 45;
                                    dataGridView1.Columns[10].SortMode = DataGridViewColumnSortMode.NotSortable;
                                    dataGridView1.Columns[11].HeaderText = "Hr";
                                    dataGridView1.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    dataGridView1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    dataGridView1.Columns[11].Width = 45;
                                    dataGridView1.Columns[11].SortMode = DataGridViewColumnSortMode.NotSortable;
                                    dataGridView1.Columns[12].HeaderText = "Hr (A)";
                                    dataGridView1.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    dataGridView1.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    dataGridView1.Columns[12].Width = 45;
                                    dataGridView1.Columns[12].SortMode = DataGridViewColumnSortMode.NotSortable;
                                    dataGridView1.Columns[13].HeaderText = "Reason";
                                    dataGridView1.Columns[13].Width = 70;
                                    dataGridView1.Columns[13].SortMode = DataGridViewColumnSortMode.NotSortable;
                                    dataGridView1.Columns[14].HeaderText = "Updater ID";
                                    dataGridView1.Columns[14].Width = 90;
                                    dataGridView1.Columns[14].Visible = false;
                                    dataGridView1.Columns[15].HeaderText = "Update Date";
                                    dataGridView1.Columns[15].Width = 80;
                                    dataGridView1.Columns[15].Visible = false;
                                    dataGridView1.Columns[16].HeaderText = "Hr (F)";
                                    dataGridView1.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    dataGridView1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    dataGridView1.Columns[16].Width = 45;
                                    dataGridView1.Columns[16].SortMode = DataGridViewColumnSortMode.NotSortable;
                                    dataGridView1.Columns[16].DefaultCellStyle.BackColor = Color.LightYellow;
                                    dataGridView1.Columns[17].HeaderText = "Wage (T)";
                                    dataGridView1.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    dataGridView1.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    dataGridView1.Columns[17].Width = 50;
                                    dataGridView1.Columns[17].Visible = false;
                                    dataGridView1.Columns[18].HeaderText = "Settled";
                                    dataGridView1.Columns[18].Width = 65;
                                    dataGridView1.Columns[18].Visible = false;
                                    dataGridView1.Columns[19].HeaderText = "Settle ID";
                                    dataGridView1.Columns[19].Width = 90;
                                    dataGridView1.Columns[19].Visible = false;
                                    dataGridView1.Columns[20].HeaderText = "Settle Date";
                                    dataGridView1.Columns[20].Width = 90;
                                    dataGridView1.Columns[20].Visible = false;
                                    dataGridView1.Columns[21].HeaderText = "Unsettle ID";
                                    dataGridView1.Columns[21].Width = 80;
                                    dataGridView1.Columns[21].Visible = false;
                                    dataGridView1.Columns[22].HeaderText = "Unsettle Date";
                                    dataGridView1.Columns[22].Width = 80;
                                    dataGridView1.Columns[22].Visible = false;

                                    dataGridView1.ClearSelection();
                                }

                                break;
                            }
                        }
                    }

                    for (int k = 0; k < dataGridView1.RowCount; k++)
                    {
                        if (dataGridView1.Rows[k].Cells[12].Value == DBNull.Value)
                        {
                            if (dataGridView1.Rows[k].Cells[16].Value == DBNull.Value)
                            {
                                dataGridView1.Rows[k].Cells[10].Style.BackColor = Color.Red;
                                dataGridView1.Rows[k].Cells[11].Style.BackColor = Color.Red;
                            }
                            else if (Convert.ToDouble(dataGridView1.Rows[k].Cells[16].Value) < 1)
                            {
                                dataGridView1.Rows[k].Cells[10].Style.BackColor = Color.Red;
                                dataGridView1.Rows[k].Cells[11].Style.BackColor = Color.Red;
                            }
                        }
                        else
                        {
                            if (dataGridView1.Rows[k].Cells[12].Value != DBNull.Value)
                                dataGridView1.Rows[k].Cells[11].Style.ForeColor = Color.Red;

                        }
                    }
                }
            }
        }

        private void btnUpdatePost_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
                return;

            if (parentForm.StoreCode != cmbStoreCode.Text)
            {
                MessageBox.Show("Not available, please change the store...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Update_TimeCard", parentForm.conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@TcNum", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                        cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value).ToUpper();
                        cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value).ToUpper();
                        cmd.Parameters.Add("@TcDate", SqlDbType.Int).Value = Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                        cmd.Parameters.Add("@TcTimeON", SqlDbType.DateTime).Value = Convert.ToDateTime(dataGridView1.Rows[i].Cells[5].Value);

                        if (Convert.ToString(dataGridView1.Rows[i].Cells[6].Value) != "")
                        {
                            cmd.Parameters.Add("@TcTimeOFF", SqlDbType.DateTime).Value = Convert.ToDateTime(dataGridView1.Rows[i].Cells[6].Value);
                            cmd.Parameters.Add("@Option", SqlDbType.Int).Value = 1;
                        }
                        else
                        {
                            cmd.Parameters.Add("@TcTimeOFF", SqlDbType.DateTime).Value = "1/1/1900 1:11:11 AM";
                            cmd.Parameters.Add("@Option", SqlDbType.Int).Value = 0;
                        }

                        parentForm.conn.Open();
                        cmd.ExecuteNonQuery();
                        parentForm.conn.Close();
                    }

                    MessageBox.Show("SUCCESSFULLY UPDATED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnOK_Click(null, null);
                    return;
                }
                catch
                {
                    MessageBox.Show("UPDATE FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
                return;

            if (parentForm.StoreCode != cmbStoreCode.Text)
            {
                MessageBox.Show("Not available, please change the store...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
            {
                try
                {
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        for (int j = 0; j < dataGridView1.ColumnCount; j++)
                        {
                            if (dataGridView1.Rows[i].Cells[j].Selected == true)
                            {
                                SqlCommand cmd = new SqlCommand("Delete_TimeCard", parentForm.conn);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@TcNum", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                                cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value).ToUpper();

                                parentForm.conn.Open();
                                cmd.ExecuteNonQuery();
                                parentForm.conn.Close();

                                MessageBox.Show("SUCCESSFULLY DELETED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnOK_Click(null, null);
                                return;
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("UPDATE FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtStartDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar1.SelectionStart));
            monthCalendar1.Visible = false;
        }

        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtEndDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar2.SelectionStart));
            monthCalendar2.Visible = false;
        }

        private void btnAdjustTime_Click(object sender, EventArgs e)
        {
            if (parentForm.StoreCode != cmbStoreCode.Text.ToUpper().ToString())
            {
                MessageBox.Show("INCORRECT STORE CODE \n" + "YOUR ORIGINAL LOCATION IS " + parentForm.storeName + " STORE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dataGridView1.RowCount == 0)
            {
                return;
            }
            else
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells[12].Selected == true)
                    {
                        AdjustTime adjustTimeForm = new AdjustTime(i);
                        adjustTimeForm.parentForm1 = this.parentForm;
                        adjustTimeForm.parentForm2 = this;
                        adjustTimeForm.ShowDialog();

                        return;
                    }
                }

                MessageBox.Show("PLEASE SELECT A CELL WITHIN THE ¡°HR (A)¡± COLUMN TO ADJUST THE TIME FOR THAT ROW", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDetailView_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
                return;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Selected == true)
                    {
                        TimeCardDetailView timeCardDetailViewForm = new TimeCardDetailView(i);
                        timeCardDetailViewForm.parentForm = this;
                        timeCardDetailViewForm.ShowDialog();

                        return;
                    }
                }
            }
        }

        private void btnSettle_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[10].Style.BackColor == Color.Red | dataGridView1.Rows[i].Cells[11].Style.BackColor == Color.Red)
                {
                    MessageBox.Show("PLEASE CORRECT ALL ERRORS (INDICATED BY THE RED CELL) ON THE TIME CARD IN ORDER TO SETTLE AND GENERATE AN EXCEL SHEEET", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            btnSettle.Enabled = false;

            if (dataGridView1.RowCount > 0)
            {
                if (parentForm.StoreCode != cmbStoreCode.Text.ToUpper().ToString())
                {
                    MessageBox.Show("INCORRECT STORE CODE \n" + "YOUR ORIGINAL LOCATION IS " + parentForm.storeName + " STORE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult MyDialogResult;
                MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                    btnSettle.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("NO TIME CARD", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSettle.Enabled = true;
            }
        }

        public void btnUnsettle_Click(object sender, EventArgs e)
        {
            btnUnsettle.Enabled = false;

            if (dataGridView1.RowCount > 0)
            {
                if (parentForm.StoreCode != cmbStoreCode.Text.ToUpper().ToString())
                {
                    MessageBox.Show("INCORRECT STORE CODE \n" + "YOUR ORIGINAL LOCATION IS " + parentForm.storeName + " STORE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (boolNumBtnUnsettle == true)
                {
                    /*DialogResult MyDialogResult;
                    MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (MyDialogResult == DialogResult.Yes)
                    {*/
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = dataGridView1.RowCount;
                        progressBar1.Step = 1;
                        progressBar1.Visible = true;

                        backgroundWorker2.RunWorkerAsync();
                    /*}
                    else
                    {
                        btnUnsettle.Enabled = true;
                    }*/
                }
                else
                {
                    InputPasscode inputPasscodeForm = new InputPasscode(2);
                    inputPasscodeForm.parentForm1 = this.parentForm;
                    inputPasscodeForm.parentForm4 = this;
                    inputPasscodeForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("NO TIME CARD", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnUnsettle.Enabled = true;
            }
        }

        private void btnBVOK_Click(object sender, EventArgs e)
        {
            btnBVOK.Enabled = false;
            dataGridView4.DataSource = null;
            BVdt.Clear();

            if (txtBVStartDate.Text.Trim() == "")
            {
                MessageBox.Show("SELECT DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridView3.DataSource = DBNull.Value;
                btnBVOK.Enabled = true;
                return;
            }

            BVStartDate = Convert.ToDateTime(txtBVStartDate.Text.Trim());

            if (BVStartDate.DayOfWeek != DayOfWeek.Sunday)
            {
                MessageBox.Show("START DATE MUST BE SUNDAY", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnBVOK.Enabled = true;
                return;
            }

            BVEndDate = BVStartDate.AddDays(13);
            nBVStartDate = Convert.ToInt32(BVStartDate.ToString("yyyy") + BVStartDate.ToString("MM") + BVStartDate.ToString("dd"));
            nBVEndDate = Convert.ToInt32(BVEndDate.ToString("yyyy") + BVEndDate.ToString("MM") + BVEndDate.ToString("dd"));
            BVStartDate_s = BVStartDate.AddDays(7);
            BVEndDate_s = BVEndDate.AddDays(7);
            nBVStartDate_s = Convert.ToInt32(BVStartDate_s.ToString("yyyy") + BVStartDate_s.ToString("MM") + BVStartDate_s.ToString("dd"));
            nBVEndDate_s = Convert.ToInt32(BVEndDate_s.ToString("yyyy") + BVEndDate_s.ToString("MM") + BVEndDate_s.ToString("dd"));

            if (parentForm.StoreCode == cmbBVStoreCode.Text.ToUpper().ToString())
            {
                SqlCommand cmd = new SqlCommand("Get_UserID_From_TimeCard", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StartDate", SqlDbType.Int).Value = nBVStartDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.Int).Value = nBVEndDate;

                SqlDataAdapter adapt = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adapt.SelectCommand = cmd;

                parentForm.conn.Open();
                adapt.Fill(dt);
                parentForm.conn.Close();

                dataGridView4.DataSource = dt;
                label15.Text = Convert.ToString(dataGridView4.RowCount);

                for (int i = 0; i < dataGridView4.RowCount - 1; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (j == 0)
                        {
                            fName = string.Empty;
                            lName = string.Empty;
                            biweekly = string.Empty;
                            sun = 0; mon = 0; tue = 0; wed = 0; thu = 0; fri = 0; sat = 0; sum = 0; rh = 0; oh = 0;
                            sun_fh = 0; mon_fh = 0; tue_fh = 0; wed_fh = 0; thu_fh = 0; fri_fh = 0; sat_fh = 0;
                            sun_ah = 0; mon_ah = 0; tue_ah = 0; wed_ah = 0; thu_ah = 0; fri_ah = 0; sat_ah = 0;

                            cmd_BV.CommandText = "Calculate_Weekly_TimeCard";
                            cmd_BV.CommandType = CommandType.StoredProcedure;
                            cmd_BV.Connection = parentForm.conn;
                            cmd_BV.Parameters.Clear();
                            cmd_BV.Parameters.Add("@sDate", SqlDbType.NVarChar).Value = Convert.ToString(nBVStartDate);
                            cmd_BV.Parameters.Add("@TcLoginID", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView4.Rows[i].Cells[0].Value);
                            SqlParameter FirstName_Param = cmd_BV.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50);
                            SqlParameter LastName_Param = cmd_BV.Parameters.Add("@LastName", SqlDbType.NVarChar, 50);
                            SqlParameter SunFinalHours_Param = cmd_BV.Parameters.Add("@Sun_FH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Sun_FH"].Precision = 10;
                            cmd_BV.Parameters["@Sun_FH"].Scale = 2;
                            SqlParameter MonFinalHours_Param = cmd_BV.Parameters.Add("@Mon_FH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Mon_FH"].Precision = 10;
                            cmd_BV.Parameters["@Mon_FH"].Scale = 2;
                            SqlParameter TueFinalHours_Param = cmd_BV.Parameters.Add("@Tue_FH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Tue_FH"].Precision = 10;
                            cmd_BV.Parameters["@Tue_FH"].Scale = 2;
                            SqlParameter WedFinalHours_Param = cmd_BV.Parameters.Add("@Wed_FH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Wed_FH"].Precision = 10;
                            cmd_BV.Parameters["@Wed_FH"].Scale = 2;
                            SqlParameter ThuFinalHours_Param = cmd_BV.Parameters.Add("@Thu_FH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Thu_FH"].Precision = 10;
                            cmd_BV.Parameters["@Thu_FH"].Scale = 2;
                            SqlParameter FriFinalHours_Param = cmd_BV.Parameters.Add("@Fri_FH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Fri_FH"].Precision = 10;
                            cmd_BV.Parameters["@Fri_FH"].Scale = 2;
                            SqlParameter SatFinalHours_Param = cmd_BV.Parameters.Add("@Sat_FH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Sat_FH"].Precision = 10;
                            cmd_BV.Parameters["@Sat_FH"].Scale = 2;
                            FirstName_Param.Direction = ParameterDirection.Output;
                            LastName_Param.Direction = ParameterDirection.Output;
                            SunFinalHours_Param.Direction = ParameterDirection.Output;
                            MonFinalHours_Param.Direction = ParameterDirection.Output;
                            TueFinalHours_Param.Direction = ParameterDirection.Output;
                            WedFinalHours_Param.Direction = ParameterDirection.Output;
                            ThuFinalHours_Param.Direction = ParameterDirection.Output;
                            FriFinalHours_Param.Direction = ParameterDirection.Output;
                            SatFinalHours_Param.Direction = ParameterDirection.Output;

                            SqlParameter SunAdjustedHours_Param = cmd_BV.Parameters.Add("@Sun_AH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Sun_AH"].Precision = 10;
                            cmd_BV.Parameters["@Sun_AH"].Scale = 2;
                            SqlParameter MonAdjustedHours_Param = cmd_BV.Parameters.Add("@Mon_AH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Mon_AH"].Precision = 10;
                            cmd_BV.Parameters["@Mon_AH"].Scale = 2;
                            SqlParameter TueAdjustedHours_Param = cmd_BV.Parameters.Add("@Tue_AH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Tue_AH"].Precision = 10;
                            cmd_BV.Parameters["@Tue_AH"].Scale = 2;
                            SqlParameter WedAdjustedHours_Param = cmd_BV.Parameters.Add("@Wed_AH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Wed_AH"].Precision = 10;
                            cmd_BV.Parameters["@Wed_AH"].Scale = 2;
                            SqlParameter ThuAdjustedHours_Param = cmd_BV.Parameters.Add("@Thu_AH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Thu_AH"].Precision = 10;
                            cmd_BV.Parameters["@Thu_AH"].Scale = 2;
                            SqlParameter FriAdjustedHours_Param = cmd_BV.Parameters.Add("@Fri_AH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Fri_AH"].Precision = 10;
                            cmd_BV.Parameters["@Fri_AH"].Scale = 2;
                            SqlParameter SatAdjustedHours_Param = cmd_BV.Parameters.Add("@Sat_AH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Sat_AH"].Precision = 10;
                            cmd_BV.Parameters["@Sat_AH"].Scale = 2;
                            SunAdjustedHours_Param.Direction = ParameterDirection.Output;
                            MonAdjustedHours_Param.Direction = ParameterDirection.Output;
                            TueAdjustedHours_Param.Direction = ParameterDirection.Output;
                            WedAdjustedHours_Param.Direction = ParameterDirection.Output;
                            ThuAdjustedHours_Param.Direction = ParameterDirection.Output;
                            FriAdjustedHours_Param.Direction = ParameterDirection.Output;
                            SatAdjustedHours_Param.Direction = ParameterDirection.Output;

                            parentForm.conn.Open();
                            cmd_BV.Prepare();
                            cmd_BV.ExecuteNonQuery();
                            parentForm.conn.Close();

                            if (cmd_BV.Parameters["@FirstName"].Value != DBNull.Value)
                                fName = Convert.ToString(cmd_BV.Parameters["@FirstName"].Value);

                            if (cmd_BV.Parameters["@LastName"].Value != DBNull.Value)
                                lName = Convert.ToString(cmd_BV.Parameters["@LastName"].Value);

                            if (cmd_BV.Parameters["@Sun_FH"].Value != DBNull.Value)
                                sun_fh = Convert.ToDouble(cmd_BV.Parameters["@Sun_FH"].Value);

                            if (cmd_BV.Parameters["@Mon_FH"].Value != DBNull.Value)
                                mon_fh = Convert.ToDouble(cmd_BV.Parameters["@Mon_FH"].Value);

                            if (cmd_BV.Parameters["@Tue_FH"].Value != DBNull.Value)
                                tue_fh = Convert.ToDouble(cmd_BV.Parameters["@Tue_FH"].Value);

                            if (cmd_BV.Parameters["@Wed_FH"].Value != DBNull.Value)
                                wed_fh = Convert.ToDouble(cmd_BV.Parameters["@Wed_FH"].Value);

                            if (cmd_BV.Parameters["@Thu_FH"].Value != DBNull.Value)
                                thu_fh = Convert.ToDouble(cmd_BV.Parameters["@Thu_FH"].Value);

                            if (cmd_BV.Parameters["@Fri_FH"].Value != DBNull.Value)
                                fri_fh = Convert.ToDouble(cmd_BV.Parameters["@Fri_FH"].Value);

                            if (cmd_BV.Parameters["@Sat_FH"].Value != DBNull.Value)
                                sat_fh = Convert.ToDouble(cmd_BV.Parameters["@Sat_FH"].Value);

                            if (cmd_BV.Parameters["@Sun_AH"].Value != DBNull.Value)
                                sun_ah = Convert.ToDouble(cmd_BV.Parameters["@Sun_AH"].Value);

                            if (cmd_BV.Parameters["@Mon_AH"].Value != DBNull.Value)
                                mon_ah = Convert.ToDouble(cmd_BV.Parameters["@Mon_AH"].Value);

                            if (cmd_BV.Parameters["@Tue_AH"].Value != DBNull.Value)
                                tue_ah = Convert.ToDouble(cmd_BV.Parameters["@Tue_AH"].Value);

                            if (cmd_BV.Parameters["@Wed_AH"].Value != DBNull.Value)
                                wed_ah = Convert.ToDouble(cmd_BV.Parameters["@Wed_AH"].Value);

                            if (cmd_BV.Parameters["@Thu_AH"].Value != DBNull.Value)
                                thu_ah = Convert.ToDouble(cmd_BV.Parameters["@Thu_AH"].Value);

                            if (cmd_BV.Parameters["@Fri_AH"].Value != DBNull.Value)
                                fri_ah = Convert.ToDouble(cmd_BV.Parameters["@Fri_AH"].Value);

                            if (cmd_BV.Parameters["@Sat_AH"].Value != DBNull.Value)
                                sat_ah = Convert.ToDouble(cmd_BV.Parameters["@Sat_AH"].Value);

                            if (sun_fh > 20)
                            {
                                sun = 20;
                            }
                            else if (sun_fh > 6.5 & sun_ah == 0)
                            {
                                sun = 6.5;
                            }
                            else
                            {
                                sun = sun_fh;
                            }

                            if (mon_fh > 20)
                            {
                                mon = 20;
                            }
                            else if (mon_fh > 10.5 & mon_ah == 0)
                            {
                                mon = 10.5;
                            }
                            else
                            {
                                mon = mon_fh;
                            }

                            if (tue_fh > 20)
                            {
                                tue = 20;
                            }
                            else if (tue_fh > 10.5 & tue_ah == 0)
                            {
                                tue = 10.5;
                            }
                            else
                            {
                                tue = tue_fh;
                            }

                            if (wed_fh > 20)
                            {
                                wed = 20;
                            }
                            else if (wed_fh > 10.5 & wed_ah == 0)
                            {
                                wed = 10.5;
                            }
                            else
                            {
                                wed = wed_fh;
                            }

                            if (thu_fh > 20)
                            {
                                thu = 20;
                            }
                            else if (thu_fh > 10.5 & thu_ah == 0)
                            {
                                thu = 10.5;
                            }
                            else
                            {
                                thu = thu_fh;
                            }

                            if (fri_fh > 20)
                            {
                                fri = 20;
                            }
                            else if (fri_fh > 10.5 & fri_ah == 0)
                            {
                                fri = 10.5;
                            }
                            else
                            {
                                fri = fri_fh;
                            }

                            if (sat_fh > 20)
                            {
                                sat = 20;
                            }
                            else if (sat_fh > 10.5 & sat_ah == 0)
                            {
                                sat = 10.5;
                            }
                            else
                            {
                                sat = sat_fh;
                            }

                            sum = sun + mon + tue + wed + thu + fri + sat;

                            if (sum > 40)
                            {
                                rh = 40;
                                oh = sum - rh;
                            }
                            else
                            {
                                rh = sum;
                                oh = 0;
                            }

                            biweekly = string.Format("{0:MM/dd/yyyy}", BVStartDate) + " - " + string.Format("{0:MM/dd/yyyy}", BVStartDate.AddDays(6));
                            BVdt.Rows.Add(biweekly, lName, fName,
                                          string.Format("{0:0.00}", sun),
                                          string.Format("{0:0.00}", mon),
                                          string.Format("{0:0.00}", tue),
                                          string.Format("{0:0.00}", wed),
                                          string.Format("{0:0.00}", thu),
                                          string.Format("{0:0.00}", fri),
                                          string.Format("{0:0.00}", sat),
                                          string.Format("{0:0.00}", sum),
                                          string.Format("{0:0.00}", rh),
                                          string.Format("{0:0.00}", oh));
                        }
                        else
                        {
                            fName = string.Empty;
                            lName = string.Empty;
                            biweekly = string.Empty;
                            sun = 0; mon = 0; tue = 0; wed = 0; thu = 0; fri = 0; sat = 0; sum = 0; rh = 0; oh = 0;
                            sun_fh = 0; mon_fh = 0; tue_fh = 0; wed_fh = 0; thu_fh = 0; fri_fh = 0; sat_fh = 0;
                            sun_ah = 0; mon_ah = 0; tue_ah = 0; wed_ah = 0; thu_ah = 0; fri_ah = 0; sat_ah = 0;

                            cmd_BV.CommandText = "Calculate_Weekly_TimeCard";
                            cmd_BV.CommandType = CommandType.StoredProcedure;
                            cmd_BV.Connection = parentForm.conn;
                            cmd_BV.Parameters.Clear();
                            cmd_BV.Parameters.Add("@sDate", SqlDbType.NVarChar).Value = Convert.ToString(nBVStartDate_s);
                            cmd_BV.Parameters.Add("@TcLoginID", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView4.Rows[i].Cells[0].Value);
                            SqlParameter FirstName_Param = cmd_BV.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50);
                            SqlParameter LastName_Param = cmd_BV.Parameters.Add("@LastName", SqlDbType.NVarChar, 50);
                            SqlParameter SunFinalHours_Param = cmd_BV.Parameters.Add("@Sun_FH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Sun_FH"].Precision = 10;
                            cmd_BV.Parameters["@Sun_FH"].Scale = 2;
                            SqlParameter MonFinalHours_Param = cmd_BV.Parameters.Add("@Mon_FH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Mon_FH"].Precision = 10;
                            cmd_BV.Parameters["@Mon_FH"].Scale = 2;
                            SqlParameter TueFinalHours_Param = cmd_BV.Parameters.Add("@Tue_FH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Tue_FH"].Precision = 10;
                            cmd_BV.Parameters["@Tue_FH"].Scale = 2;
                            SqlParameter WedFinalHours_Param = cmd_BV.Parameters.Add("@Wed_FH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Wed_FH"].Precision = 10;
                            cmd_BV.Parameters["@Wed_FH"].Scale = 2;
                            SqlParameter ThuFinalHours_Param = cmd_BV.Parameters.Add("@Thu_FH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Thu_FH"].Precision = 10;
                            cmd_BV.Parameters["@Thu_FH"].Scale = 2;
                            SqlParameter FriFinalHours_Param = cmd_BV.Parameters.Add("@Fri_FH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Fri_FH"].Precision = 10;
                            cmd_BV.Parameters["@Fri_FH"].Scale = 2;
                            SqlParameter SatFinalHours_Param = cmd_BV.Parameters.Add("@Sat_FH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Sat_FH"].Precision = 10;
                            cmd_BV.Parameters["@Sat_FH"].Scale = 2;
                            FirstName_Param.Direction = ParameterDirection.Output;
                            LastName_Param.Direction = ParameterDirection.Output;
                            SunFinalHours_Param.Direction = ParameterDirection.Output;
                            MonFinalHours_Param.Direction = ParameterDirection.Output;
                            TueFinalHours_Param.Direction = ParameterDirection.Output;
                            WedFinalHours_Param.Direction = ParameterDirection.Output;
                            ThuFinalHours_Param.Direction = ParameterDirection.Output;
                            FriFinalHours_Param.Direction = ParameterDirection.Output;
                            SatFinalHours_Param.Direction = ParameterDirection.Output;

                            SqlParameter SunAdjustedHours_Param = cmd_BV.Parameters.Add("@Sun_AH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Sun_AH"].Precision = 10;
                            cmd_BV.Parameters["@Sun_AH"].Scale = 2;
                            SqlParameter MonAdjustedHours_Param = cmd_BV.Parameters.Add("@Mon_AH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Mon_AH"].Precision = 10;
                            cmd_BV.Parameters["@Mon_AH"].Scale = 2;
                            SqlParameter TueAdjustedHours_Param = cmd_BV.Parameters.Add("@Tue_AH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Tue_AH"].Precision = 10;
                            cmd_BV.Parameters["@Tue_AH"].Scale = 2;
                            SqlParameter WedAdjustedHours_Param = cmd_BV.Parameters.Add("@Wed_AH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Wed_AH"].Precision = 10;
                            cmd_BV.Parameters["@Wed_AH"].Scale = 2;
                            SqlParameter ThuAdjustedHours_Param = cmd_BV.Parameters.Add("@Thu_AH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Thu_AH"].Precision = 10;
                            cmd_BV.Parameters["@Thu_AH"].Scale = 2;
                            SqlParameter FriAdjustedHours_Param = cmd_BV.Parameters.Add("@Fri_AH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Fri_AH"].Precision = 10;
                            cmd_BV.Parameters["@Fri_AH"].Scale = 2;
                            SqlParameter SatAdjustedHours_Param = cmd_BV.Parameters.Add("@Sat_AH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Sat_AH"].Precision = 10;
                            cmd_BV.Parameters["@Sat_AH"].Scale = 2;
                            SunAdjustedHours_Param.Direction = ParameterDirection.Output;
                            MonAdjustedHours_Param.Direction = ParameterDirection.Output;
                            TueAdjustedHours_Param.Direction = ParameterDirection.Output;
                            WedAdjustedHours_Param.Direction = ParameterDirection.Output;
                            ThuAdjustedHours_Param.Direction = ParameterDirection.Output;
                            FriAdjustedHours_Param.Direction = ParameterDirection.Output;
                            SatAdjustedHours_Param.Direction = ParameterDirection.Output;

                            parentForm.conn.Open();
                            cmd_BV.Prepare();
                            cmd_BV.ExecuteNonQuery();
                            parentForm.conn.Close();

                            if (cmd_BV.Parameters["@FirstName"].Value != DBNull.Value)
                                fName = Convert.ToString(cmd_BV.Parameters["@FirstName"].Value);

                            if (cmd_BV.Parameters["@LastName"].Value != DBNull.Value)
                                lName = Convert.ToString(cmd_BV.Parameters["@LastName"].Value);

                            if (cmd_BV.Parameters["@Sun_FH"].Value != DBNull.Value)
                                sun_fh = Convert.ToDouble(cmd_BV.Parameters["@Sun_FH"].Value);

                            if (cmd_BV.Parameters["@Mon_FH"].Value != DBNull.Value)
                                mon_fh = Convert.ToDouble(cmd_BV.Parameters["@Mon_FH"].Value);

                            if (cmd_BV.Parameters["@Tue_FH"].Value != DBNull.Value)
                                tue_fh = Convert.ToDouble(cmd_BV.Parameters["@Tue_FH"].Value);

                            if (cmd_BV.Parameters["@Wed_FH"].Value != DBNull.Value)
                                wed_fh = Convert.ToDouble(cmd_BV.Parameters["@Wed_FH"].Value);

                            if (cmd_BV.Parameters["@Thu_FH"].Value != DBNull.Value)
                                thu_fh = Convert.ToDouble(cmd_BV.Parameters["@Thu_FH"].Value);

                            if (cmd_BV.Parameters["@Fri_FH"].Value != DBNull.Value)
                                fri_fh = Convert.ToDouble(cmd_BV.Parameters["@Fri_FH"].Value);

                            if (cmd_BV.Parameters["@Sat_FH"].Value != DBNull.Value)
                                sat_fh = Convert.ToDouble(cmd_BV.Parameters["@Sat_FH"].Value);

                            if (cmd_BV.Parameters["@Sun_AH"].Value != DBNull.Value)
                                sun_ah = Convert.ToDouble(cmd_BV.Parameters["@Sun_AH"].Value);

                            if (cmd_BV.Parameters["@Mon_AH"].Value != DBNull.Value)
                                mon_ah = Convert.ToDouble(cmd_BV.Parameters["@Mon_AH"].Value);

                            if (cmd_BV.Parameters["@Tue_AH"].Value != DBNull.Value)
                                tue_ah = Convert.ToDouble(cmd_BV.Parameters["@Tue_AH"].Value);

                            if (cmd_BV.Parameters["@Wed_AH"].Value != DBNull.Value)
                                wed_ah = Convert.ToDouble(cmd_BV.Parameters["@Wed_AH"].Value);

                            if (cmd_BV.Parameters["@Thu_AH"].Value != DBNull.Value)
                                thu_ah = Convert.ToDouble(cmd_BV.Parameters["@Thu_AH"].Value);

                            if (cmd_BV.Parameters["@Fri_AH"].Value != DBNull.Value)
                                fri_ah = Convert.ToDouble(cmd_BV.Parameters["@Fri_AH"].Value);

                            if (cmd_BV.Parameters["@Sat_AH"].Value != DBNull.Value)
                                sat_ah = Convert.ToDouble(cmd_BV.Parameters["@Sat_AH"].Value);

                            if (sun_fh > 20)
                            {
                                sun = 20;
                            }
                            else if (sun_fh > 6.5 & sun_ah == 0)
                            {
                                sun = 6.5;
                            }
                            else
                            {
                                sun = sun_fh;
                            }

                            if (mon_fh > 20)
                            {
                                mon = 20;
                            }
                            else if (mon_fh > 10.5 & mon_ah == 0)
                            {
                                mon = 10.5;
                            }
                            else
                            {
                                mon = mon_fh;
                            }

                            if (tue_fh > 20)
                            {
                                tue = 20;
                            }
                            else if (tue_fh > 10.5 & tue_ah == 0)
                            {
                                tue = 10.5;
                            }
                            else
                            {
                                tue = tue_fh;
                            }

                            if (wed_fh > 20)
                            {
                                wed = 20;
                            }
                            else if (wed_fh > 10.5 & wed_ah == 0)
                            {
                                wed = 10.5;
                            }
                            else
                            {
                                wed = wed_fh;
                            }

                            if (thu_fh > 20)
                            {
                                thu = 20;
                            }
                            else if (thu_fh > 10.5 & thu_ah == 0)
                            {
                                thu = 10.5;
                            }
                            else
                            {
                                thu = thu_fh;
                            }

                            if (fri_fh > 20)
                            {
                                fri = 20;
                            }
                            else if (fri_fh > 10.5 & fri_ah == 0)
                            {
                                fri = 10.5;
                            }
                            else
                            {
                                fri = fri_fh;
                            }

                            if (sat_fh > 20)
                            {
                                sat = 20;
                            }
                            else if (sat_fh > 10.5 & sat_ah == 0)
                            {
                                sat = 10.5;
                            }
                            else
                            {
                                sat = sat_fh;
                            }

                            sum = sun + mon + tue + wed + thu + fri + sat;

                            if (sum > 40)
                            {
                                rh = 40;
                                oh = sum - rh;
                            }
                            else
                            {
                                rh = sum;
                                oh = 0;
                            }

                            biweekly = string.Format("{0:MM/dd/yyyy}", BVStartDate.AddDays(7)) + " - " + string.Format("{0:MM/dd/yyyy}", BVStartDate.AddDays(13));
                            BVdt.Rows.Add(biweekly, lName, fName,
                                          string.Format("{0:0.00}", sun),
                                          string.Format("{0:0.00}", mon),
                                          string.Format("{0:0.00}", tue),
                                          string.Format("{0:0.00}", wed),
                                          string.Format("{0:0.00}", thu),
                                          string.Format("{0:0.00}", fri),
                                          string.Format("{0:0.00}", sat),
                                          string.Format("{0:0.00}", sum),
                                          string.Format("{0:0.00}", rh),
                                          string.Format("{0:0.00}", oh));
                        }
                    }
                }

                dataGridView3.DataSource = BVdt;
                dataGridView3.Columns[0].Width = 200;
                dataGridView3.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView3.Columns[1].Width = 100;
                dataGridView3.Sort(dataGridView3.Columns[1], ListSortDirection.Ascending);
                dataGridView3.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView3.Columns[2].Width = 100;
                dataGridView3.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView3.Columns[3].Width = 55;
                dataGridView3.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView3.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView3.Columns[4].Width = 55;
                dataGridView3.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView3.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView3.Columns[5].Width = 55;
                dataGridView3.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView3.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView3.Columns[6].Width = 55;
                dataGridView3.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView3.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView3.Columns[7].Width = 55;
                dataGridView3.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView3.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView3.Columns[8].Width = 55;
                dataGridView3.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView3.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView3.Columns[9].Width = 55;
                dataGridView3.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView3.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView3.Columns[10].Width = 55;
                dataGridView3.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView3.Columns[10].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView3.Columns[10].DefaultCellStyle.BackColor = Color.Tan;
                dataGridView3.Columns[11].Width = 55;
                dataGridView3.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView3.Columns[11].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView3.Columns[11].DefaultCellStyle.BackColor = Color.Orange;
                dataGridView3.Columns[12].Width = 55;
                dataGridView3.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView3.Columns[12].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView3.Columns[12].DefaultCellStyle.BackColor = Color.Peru;

                Last_Check();

                dataGridView3.ClearSelection();
            }
            else
            {
                if (parentForm.UserChecking(cmbBVStoreCode.Text.Trim().ToUpper()) < 6)
                {
                    MessageBox.Show("You are not authorized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnBVOK.Enabled = true;
                    return;
                }

                if (cmbBVStoreCode.Text == "OH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.OHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.OHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    this.Text = "TIME CARD (LOCATION : OXON HILL)";
                }
                else if (cmbBVStoreCode.Text == "CH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    this.Text = "TIME CARD (LOCATION : CAPITOL HEIGHTS)";
                }
                else if (cmbBVStoreCode.Text == "WB")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WBIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WBDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    this.Text = "TIME CARD (LOCATION : WOODBRIDGE)";
                }
                else if (cmbBVStoreCode.Text == "CV")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.CVIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CVDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    this.Text = "TIME CARD (LOCATION : CATONSVILLE)";
                }
                else if (cmbBVStoreCode.Text == "UM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.UMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.UMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    this.Text = "TIME CARD (LOCATION : UPPER MARLBORO)";
                }
                else if (cmbBVStoreCode.Text == "WM")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    this.Text = "TIME CARD (LOCATION : WINDSOR MILL)";
                }
                else if (cmbBVStoreCode.Text == "TH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.THIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.THDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    this.Text = "TIME CARD (LOCATION : TEMPLE HILLS)";
                }
                else if (cmbBVStoreCode.Text == "WD")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.WDIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WDDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    this.Text = "TIME CARD (LOCATION : WALDORF)";
                }
                else if (cmbBVStoreCode.Text == "PW")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.PWIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.PWDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    this.Text = "TIME CARD (LOCATION : PRINCE WILLIAM)";
                }
                else if (cmbBVStoreCode.Text == "GB")
                {
                    newConn = new SqlConnection(parentForm.GBCS_IP);
                    this.Text = "TIME CARD (LOCATION : GAITHERSBURG)";
                }
                else if (cmbBVStoreCode.Text == "BW")
                {
                    newConn = new SqlConnection(parentForm.BWCS_IP);
                    this.Text = "TIME CARD (LOCATION : BOWIE)";
                }
                else if (cmbBVStoreCode.Text == "B4UHQ")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.B4UHQIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.B4UHQDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    this.Text = "TIME CARD (LOCATION : BEAUTY 4U HEADQUARTES)";
                }
                else if (cmbBVStoreCode.Text == "B4UWH")
                {
                    newConn = new SqlConnection("Data Source=" + parentForm.B4UWHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.B4UWHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                    this.Text = "TIME CARD (LOCATION : BEAUTY 4U WAREHOUSE)";
                }
                else if (cmbStoreCode.Text == "TEST")
                {
                    newConn = new SqlConnection(parentForm.Test1CS);
                    this.Text = "TIME CARD (LOCATION : TEST)";
                }


                SqlCommand cmd = new SqlCommand("Get_UserID_From_TimeCard", newConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@StartDate", SqlDbType.Int).Value = nBVStartDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.Int).Value = nBVEndDate;

                SqlDataAdapter adapt = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adapt.SelectCommand = cmd;

                newConn.Open();
                adapt.Fill(dt);
                newConn.Close();

                dataGridView4.DataSource = dt;
                label15.Text = Convert.ToString(dataGridView4.RowCount);

                for (int i = 0; i < dataGridView4.RowCount - 1; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (j == 0)
                        {
                            fName = string.Empty;
                            lName = string.Empty;
                            biweekly = string.Empty;
                            sun = 0; mon = 0; tue = 0; wed = 0; thu = 0; fri = 0; sat = 0; sum = 0; rh = 0; oh = 0;
                            sun_fh = 0; mon_fh = 0; tue_fh = 0; wed_fh = 0; thu_fh = 0; fri_fh = 0; sat_fh = 0;
                            sun_ah = 0; mon_ah = 0; tue_ah = 0; wed_ah = 0; thu_ah = 0; fri_ah = 0; sat_ah = 0;

                            cmd_BV.CommandText = "Calculate_Weekly_TimeCard";
                            cmd_BV.CommandType = CommandType.StoredProcedure;
                            cmd_BV.Connection = newConn;
                            cmd_BV.Parameters.Clear();
                            cmd_BV.Parameters.Add("@sDate", SqlDbType.NVarChar).Value = Convert.ToString(nBVStartDate);
                            cmd_BV.Parameters.Add("@TcLoginID", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView4.Rows[i].Cells[0].Value);
                            SqlParameter FirstName_Param = cmd_BV.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50);
                            SqlParameter LastName_Param = cmd_BV.Parameters.Add("@LastName", SqlDbType.NVarChar, 50);
                            SqlParameter SunFinalHours_Param = cmd_BV.Parameters.Add("@Sun_FH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Sun_FH"].Precision = 10;
                            cmd_BV.Parameters["@Sun_FH"].Scale = 2;
                            SqlParameter MonFinalHours_Param = cmd_BV.Parameters.Add("@Mon_FH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Mon_FH"].Precision = 10;
                            cmd_BV.Parameters["@Mon_FH"].Scale = 2;
                            SqlParameter TueFinalHours_Param = cmd_BV.Parameters.Add("@Tue_FH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Tue_FH"].Precision = 10;
                            cmd_BV.Parameters["@Tue_FH"].Scale = 2;
                            SqlParameter WedFinalHours_Param = cmd_BV.Parameters.Add("@Wed_FH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Wed_FH"].Precision = 10;
                            cmd_BV.Parameters["@Wed_FH"].Scale = 2;
                            SqlParameter ThuFinalHours_Param = cmd_BV.Parameters.Add("@Thu_FH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Thu_FH"].Precision = 10;
                            cmd_BV.Parameters["@Thu_FH"].Scale = 2;
                            SqlParameter FriFinalHours_Param = cmd_BV.Parameters.Add("@Fri_FH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Fri_FH"].Precision = 10;
                            cmd_BV.Parameters["@Fri_FH"].Scale = 2;
                            SqlParameter SatFinalHours_Param = cmd_BV.Parameters.Add("@Sat_FH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Sat_FH"].Precision = 10;
                            cmd_BV.Parameters["@Sat_FH"].Scale = 2;
                            FirstName_Param.Direction = ParameterDirection.Output;
                            LastName_Param.Direction = ParameterDirection.Output;
                            SunFinalHours_Param.Direction = ParameterDirection.Output;
                            MonFinalHours_Param.Direction = ParameterDirection.Output;
                            TueFinalHours_Param.Direction = ParameterDirection.Output;
                            WedFinalHours_Param.Direction = ParameterDirection.Output;
                            ThuFinalHours_Param.Direction = ParameterDirection.Output;
                            FriFinalHours_Param.Direction = ParameterDirection.Output;
                            SatFinalHours_Param.Direction = ParameterDirection.Output;

                            SqlParameter SunAdjustedHours_Param = cmd_BV.Parameters.Add("@Sun_AH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Sun_AH"].Precision = 10;
                            cmd_BV.Parameters["@Sun_AH"].Scale = 2;
                            SqlParameter MonAdjustedHours_Param = cmd_BV.Parameters.Add("@Mon_AH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Mon_AH"].Precision = 10;
                            cmd_BV.Parameters["@Mon_AH"].Scale = 2;
                            SqlParameter TueAdjustedHours_Param = cmd_BV.Parameters.Add("@Tue_AH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Tue_AH"].Precision = 10;
                            cmd_BV.Parameters["@Tue_AH"].Scale = 2;
                            SqlParameter WedAdjustedHours_Param = cmd_BV.Parameters.Add("@Wed_AH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Wed_AH"].Precision = 10;
                            cmd_BV.Parameters["@Wed_AH"].Scale = 2;
                            SqlParameter ThuAdjustedHours_Param = cmd_BV.Parameters.Add("@Thu_AH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Thu_AH"].Precision = 10;
                            cmd_BV.Parameters["@Thu_AH"].Scale = 2;
                            SqlParameter FriAdjustedHours_Param = cmd_BV.Parameters.Add("@Fri_AH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Fri_AH"].Precision = 10;
                            cmd_BV.Parameters["@Fri_AH"].Scale = 2;
                            SqlParameter SatAdjustedHours_Param = cmd_BV.Parameters.Add("@Sat_AH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Sat_AH"].Precision = 10;
                            cmd_BV.Parameters["@Sat_AH"].Scale = 2;
                            SunAdjustedHours_Param.Direction = ParameterDirection.Output;
                            MonAdjustedHours_Param.Direction = ParameterDirection.Output;
                            TueAdjustedHours_Param.Direction = ParameterDirection.Output;
                            WedAdjustedHours_Param.Direction = ParameterDirection.Output;
                            ThuAdjustedHours_Param.Direction = ParameterDirection.Output;
                            FriAdjustedHours_Param.Direction = ParameterDirection.Output;
                            SatAdjustedHours_Param.Direction = ParameterDirection.Output;

                            newConn.Open();
                            cmd_BV.Prepare();
                            cmd_BV.ExecuteNonQuery();
                            newConn.Close();

                            if (cmd_BV.Parameters["@FirstName"].Value != DBNull.Value)
                                fName = Convert.ToString(cmd_BV.Parameters["@FirstName"].Value);

                            if (cmd_BV.Parameters["@LastName"].Value != DBNull.Value)
                                lName = Convert.ToString(cmd_BV.Parameters["@LastName"].Value);

                            if (cmd_BV.Parameters["@Sun_FH"].Value != DBNull.Value)
                                sun_fh = Convert.ToDouble(cmd_BV.Parameters["@Sun_FH"].Value);

                            if (cmd_BV.Parameters["@Mon_FH"].Value != DBNull.Value)
                                mon_fh = Convert.ToDouble(cmd_BV.Parameters["@Mon_FH"].Value);

                            if (cmd_BV.Parameters["@Tue_FH"].Value != DBNull.Value)
                                tue_fh = Convert.ToDouble(cmd_BV.Parameters["@Tue_FH"].Value);

                            if (cmd_BV.Parameters["@Wed_FH"].Value != DBNull.Value)
                                wed_fh = Convert.ToDouble(cmd_BV.Parameters["@Wed_FH"].Value);

                            if (cmd_BV.Parameters["@Thu_FH"].Value != DBNull.Value)
                                thu_fh = Convert.ToDouble(cmd_BV.Parameters["@Thu_FH"].Value);

                            if (cmd_BV.Parameters["@Fri_FH"].Value != DBNull.Value)
                                fri_fh = Convert.ToDouble(cmd_BV.Parameters["@Fri_FH"].Value);

                            if (cmd_BV.Parameters["@Sat_FH"].Value != DBNull.Value)
                                sat_fh = Convert.ToDouble(cmd_BV.Parameters["@Sat_FH"].Value);

                            if (cmd_BV.Parameters["@Sun_AH"].Value != DBNull.Value)
                                sun_ah = Convert.ToDouble(cmd_BV.Parameters["@Sun_AH"].Value);

                            if (cmd_BV.Parameters["@Mon_AH"].Value != DBNull.Value)
                                mon_ah = Convert.ToDouble(cmd_BV.Parameters["@Mon_AH"].Value);

                            if (cmd_BV.Parameters["@Tue_AH"].Value != DBNull.Value)
                                tue_ah = Convert.ToDouble(cmd_BV.Parameters["@Tue_AH"].Value);

                            if (cmd_BV.Parameters["@Wed_AH"].Value != DBNull.Value)
                                wed_ah = Convert.ToDouble(cmd_BV.Parameters["@Wed_AH"].Value);

                            if (cmd_BV.Parameters["@Thu_AH"].Value != DBNull.Value)
                                thu_ah = Convert.ToDouble(cmd_BV.Parameters["@Thu_AH"].Value);

                            if (cmd_BV.Parameters["@Fri_AH"].Value != DBNull.Value)
                                fri_ah = Convert.ToDouble(cmd_BV.Parameters["@Fri_AH"].Value);

                            if (cmd_BV.Parameters["@Sat_AH"].Value != DBNull.Value)
                                sat_ah = Convert.ToDouble(cmd_BV.Parameters["@Sat_AH"].Value);

                            if (sun_fh > 20)
                            {
                                sun = 20;
                            }
                            else if (sun_fh > 6.5 & sun_ah == 0)
                            {
                                sun = 6.5;
                            }
                            else
                            {
                                sun = sun_fh;
                            }

                            if (mon_fh > 20)
                            {
                                mon = 20;
                            }
                            else if (mon_fh > 10.5 & mon_ah == 0)
                            {
                                mon = 10.5;
                            }
                            else
                            {
                                mon = mon_fh;
                            }

                            if (tue_fh > 20)
                            {
                                tue = 20;
                            }
                            else if (tue_fh > 10.5 & tue_ah == 0)
                            {
                                tue = 10.5;
                            }
                            else
                            {
                                tue = tue_fh;
                            }

                            if (wed_fh > 20)
                            {
                                wed = 20;
                            }
                            else if (wed_fh > 10.5 & wed_ah == 0)
                            {
                                wed = 10.5;
                            }
                            else
                            {
                                wed = wed_fh;
                            }

                            if (thu_fh > 20)
                            {
                                thu = 20;
                            }
                            else if (thu_fh > 10.5 & thu_ah == 0)
                            {
                                thu = 10.5;
                            }
                            else
                            {
                                thu = thu_fh;
                            }

                            if (fri_fh > 20)
                            {
                                fri = 20;
                            }
                            else if (fri_fh > 10.5 & fri_ah == 0)
                            {
                                fri = 10.5;
                            }
                            else
                            {
                                fri = fri_fh;
                            }

                            if (sat_fh > 20)
                            {
                                sat = 20;
                            }
                            else if (sat_fh > 10.5 & sat_ah == 0)
                            {
                                sat = 10.5;
                            }
                            else
                            {
                                sat = sat_fh;
                            }

                            sum = sun + mon + tue + wed + thu + fri + sat;

                            if (sum > 40)
                            {
                                rh = 40;
                                oh = sum - rh;
                            }
                            else
                            {
                                rh = sum;
                                oh = 0;
                            }

                            biweekly = string.Format("{0:MM/dd/yyyy}", BVStartDate) + " - " + string.Format("{0:MM/dd/yyyy}", BVStartDate.AddDays(6));
                            BVdt.Rows.Add(biweekly, lName, fName,
                                          string.Format("{0:0.00}", sun),
                                          string.Format("{0:0.00}", mon),
                                          string.Format("{0:0.00}", tue),
                                          string.Format("{0:0.00}", wed),
                                          string.Format("{0:0.00}", thu),
                                          string.Format("{0:0.00}", fri),
                                          string.Format("{0:0.00}", sat),
                                          string.Format("{0:0.00}", sum),
                                          string.Format("{0:0.00}", rh),
                                          string.Format("{0:0.00}", oh));
                        }
                        else
                        {
                            fName = string.Empty;
                            lName = string.Empty;
                            biweekly = string.Empty;
                            sun = 0; mon = 0; tue = 0; wed = 0; thu = 0; fri = 0; sat = 0; sum = 0; rh = 0; oh = 0;
                            sun_fh = 0; mon_fh = 0; tue_fh = 0; wed_fh = 0; thu_fh = 0; fri_fh = 0; sat_fh = 0;
                            sun_ah = 0; mon_ah = 0; tue_ah = 0; wed_ah = 0; thu_ah = 0; fri_ah = 0; sat_ah = 0;

                            cmd_BV.CommandText = "Calculate_Weekly_TimeCard";
                            cmd_BV.CommandType = CommandType.StoredProcedure;
                            cmd_BV.Connection = newConn;
                            cmd_BV.Parameters.Clear();
                            cmd_BV.Parameters.Add("@sDate", SqlDbType.NVarChar).Value = Convert.ToString(nBVStartDate_s);
                            cmd_BV.Parameters.Add("@TcLoginID", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView4.Rows[i].Cells[0].Value);
                            SqlParameter FirstName_Param = cmd_BV.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50);
                            SqlParameter LastName_Param = cmd_BV.Parameters.Add("@LastName", SqlDbType.NVarChar, 50);
                            SqlParameter SunFinalHours_Param = cmd_BV.Parameters.Add("@Sun_FH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Sun_FH"].Precision = 10;
                            cmd_BV.Parameters["@Sun_FH"].Scale = 2;
                            SqlParameter MonFinalHours_Param = cmd_BV.Parameters.Add("@Mon_FH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Mon_FH"].Precision = 10;
                            cmd_BV.Parameters["@Mon_FH"].Scale = 2;
                            SqlParameter TueFinalHours_Param = cmd_BV.Parameters.Add("@Tue_FH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Tue_FH"].Precision = 10;
                            cmd_BV.Parameters["@Tue_FH"].Scale = 2;
                            SqlParameter WedFinalHours_Param = cmd_BV.Parameters.Add("@Wed_FH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Wed_FH"].Precision = 10;
                            cmd_BV.Parameters["@Wed_FH"].Scale = 2;
                            SqlParameter ThuFinalHours_Param = cmd_BV.Parameters.Add("@Thu_FH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Thu_FH"].Precision = 10;
                            cmd_BV.Parameters["@Thu_FH"].Scale = 2;
                            SqlParameter FriFinalHours_Param = cmd_BV.Parameters.Add("@Fri_FH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Fri_FH"].Precision = 10;
                            cmd_BV.Parameters["@Fri_FH"].Scale = 2;
                            SqlParameter SatFinalHours_Param = cmd_BV.Parameters.Add("@Sat_FH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Sat_FH"].Precision = 10;
                            cmd_BV.Parameters["@Sat_FH"].Scale = 2;
                            FirstName_Param.Direction = ParameterDirection.Output;
                            LastName_Param.Direction = ParameterDirection.Output;
                            SunFinalHours_Param.Direction = ParameterDirection.Output;
                            MonFinalHours_Param.Direction = ParameterDirection.Output;
                            TueFinalHours_Param.Direction = ParameterDirection.Output;
                            WedFinalHours_Param.Direction = ParameterDirection.Output;
                            ThuFinalHours_Param.Direction = ParameterDirection.Output;
                            FriFinalHours_Param.Direction = ParameterDirection.Output;
                            SatFinalHours_Param.Direction = ParameterDirection.Output;

                            SqlParameter SunAdjustedHours_Param = cmd_BV.Parameters.Add("@Sun_AH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Sun_AH"].Precision = 10;
                            cmd_BV.Parameters["@Sun_AH"].Scale = 2;
                            SqlParameter MonAdjustedHours_Param = cmd_BV.Parameters.Add("@Mon_AH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Mon_AH"].Precision = 10;
                            cmd_BV.Parameters["@Mon_AH"].Scale = 2;
                            SqlParameter TueAdjustedHours_Param = cmd_BV.Parameters.Add("@Tue_AH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Tue_AH"].Precision = 10;
                            cmd_BV.Parameters["@Tue_AH"].Scale = 2;
                            SqlParameter WedAdjustedHours_Param = cmd_BV.Parameters.Add("@Wed_AH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Wed_AH"].Precision = 10;
                            cmd_BV.Parameters["@Wed_AH"].Scale = 2;
                            SqlParameter ThuAdjustedHours_Param = cmd_BV.Parameters.Add("@Thu_AH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Thu_AH"].Precision = 10;
                            cmd_BV.Parameters["@Thu_AH"].Scale = 2;
                            SqlParameter FriAdjustedHours_Param = cmd_BV.Parameters.Add("@Fri_AH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Fri_AH"].Precision = 10;
                            cmd_BV.Parameters["@Fri_AH"].Scale = 2;
                            SqlParameter SatAdjustedHours_Param = cmd_BV.Parameters.Add("@Sat_AH", SqlDbType.Decimal, 10);
                            cmd_BV.Parameters["@Sat_AH"].Precision = 10;
                            cmd_BV.Parameters["@Sat_AH"].Scale = 2;
                            SunAdjustedHours_Param.Direction = ParameterDirection.Output;
                            MonAdjustedHours_Param.Direction = ParameterDirection.Output;
                            TueAdjustedHours_Param.Direction = ParameterDirection.Output;
                            WedAdjustedHours_Param.Direction = ParameterDirection.Output;
                            ThuAdjustedHours_Param.Direction = ParameterDirection.Output;
                            FriAdjustedHours_Param.Direction = ParameterDirection.Output;
                            SatAdjustedHours_Param.Direction = ParameterDirection.Output;

                            newConn.Open();
                            cmd_BV.Prepare();
                            cmd_BV.ExecuteNonQuery();
                            newConn.Close();

                            if (cmd_BV.Parameters["@FirstName"].Value != DBNull.Value)
                                fName = Convert.ToString(cmd_BV.Parameters["@FirstName"].Value);

                            if (cmd_BV.Parameters["@LastName"].Value != DBNull.Value)
                                lName = Convert.ToString(cmd_BV.Parameters["@LastName"].Value);

                            if (cmd_BV.Parameters["@Sun_FH"].Value != DBNull.Value)
                                sun_fh = Convert.ToDouble(cmd_BV.Parameters["@Sun_FH"].Value);

                            if (cmd_BV.Parameters["@Mon_FH"].Value != DBNull.Value)
                                mon_fh = Convert.ToDouble(cmd_BV.Parameters["@Mon_FH"].Value);

                            if (cmd_BV.Parameters["@Tue_FH"].Value != DBNull.Value)
                                tue_fh = Convert.ToDouble(cmd_BV.Parameters["@Tue_FH"].Value);

                            if (cmd_BV.Parameters["@Wed_FH"].Value != DBNull.Value)
                                wed_fh = Convert.ToDouble(cmd_BV.Parameters["@Wed_FH"].Value);

                            if (cmd_BV.Parameters["@Thu_FH"].Value != DBNull.Value)
                                thu_fh = Convert.ToDouble(cmd_BV.Parameters["@Thu_FH"].Value);

                            if (cmd_BV.Parameters["@Fri_FH"].Value != DBNull.Value)
                                fri_fh = Convert.ToDouble(cmd_BV.Parameters["@Fri_FH"].Value);

                            if (cmd_BV.Parameters["@Sat_FH"].Value != DBNull.Value)
                                sat_fh = Convert.ToDouble(cmd_BV.Parameters["@Sat_FH"].Value);

                            if (cmd_BV.Parameters["@Sun_AH"].Value != DBNull.Value)
                                sun_ah = Convert.ToDouble(cmd_BV.Parameters["@Sun_AH"].Value);

                            if (cmd_BV.Parameters["@Mon_AH"].Value != DBNull.Value)
                                mon_ah = Convert.ToDouble(cmd_BV.Parameters["@Mon_AH"].Value);

                            if (cmd_BV.Parameters["@Tue_AH"].Value != DBNull.Value)
                                tue_ah = Convert.ToDouble(cmd_BV.Parameters["@Tue_AH"].Value);

                            if (cmd_BV.Parameters["@Wed_AH"].Value != DBNull.Value)
                                wed_ah = Convert.ToDouble(cmd_BV.Parameters["@Wed_AH"].Value);

                            if (cmd_BV.Parameters["@Thu_AH"].Value != DBNull.Value)
                                thu_ah = Convert.ToDouble(cmd_BV.Parameters["@Thu_AH"].Value);

                            if (cmd_BV.Parameters["@Fri_AH"].Value != DBNull.Value)
                                fri_ah = Convert.ToDouble(cmd_BV.Parameters["@Fri_AH"].Value);

                            if (cmd_BV.Parameters["@Sat_AH"].Value != DBNull.Value)
                                sat_ah = Convert.ToDouble(cmd_BV.Parameters["@Sat_AH"].Value);

                            if (sun_fh > 20)
                            {
                                sun = 20;
                            }
                            else if (sun_fh > 6.5 & sun_ah == 0)
                            {
                                sun = 6.5;
                            }
                            else
                            {
                                sun = sun_fh;
                            }

                            if (mon_fh > 20)
                            {
                                mon = 20;
                            }
                            else if (mon_fh > 10.5 & mon_ah == 0)
                            {
                                mon = 10.5;
                            }
                            else
                            {
                                mon = mon_fh;
                            }

                            if (tue_fh > 20)
                            {
                                tue = 20;
                            }
                            else if (tue_fh > 10.5 & tue_ah == 0)
                            {
                                tue = 10.5;
                            }
                            else
                            {
                                tue = tue_fh;
                            }

                            if (wed_fh > 20)
                            {
                                wed = 20;
                            }
                            else if (wed_fh > 10.5 & wed_ah == 0)
                            {
                                wed = 10.5;
                            }
                            else
                            {
                                wed = wed_fh;
                            }

                            if (thu_fh > 20)
                            {
                                thu = 20;
                            }
                            else if (thu_fh > 10.5 & thu_ah == 0)
                            {
                                thu = 10.5;
                            }
                            else
                            {
                                thu = thu_fh;
                            }

                            if (fri_fh > 20)
                            {
                                fri = 20;
                            }
                            else if (fri_fh > 10.5 & fri_ah == 0)
                            {
                                fri = 10.5;
                            }
                            else
                            {
                                fri = fri_fh;
                            }

                            if (sat_fh > 20)
                            {
                                sat = 20;
                            }
                            else if (sat_fh > 10.5 & sat_ah == 0)
                            {
                                sat = 10.5;
                            }
                            else
                            {
                                sat = sat_fh;
                            }

                            sum = sun + mon + tue + wed + thu + fri + sat;

                            if (sum > 40)
                            {
                                rh = 40;
                                oh = sum - rh;
                            }
                            else
                            {
                                rh = sum;
                                oh = 0;
                            }

                            biweekly = string.Format("{0:MM/dd/yyyy}", BVStartDate.AddDays(7)) + " - " + string.Format("{0:MM/dd/yyyy}", BVStartDate.AddDays(13));
                            BVdt.Rows.Add(biweekly, lName, fName,
                                          string.Format("{0:0.00}", sun),
                                          string.Format("{0:0.00}", mon),
                                          string.Format("{0:0.00}", tue),
                                          string.Format("{0:0.00}", wed),
                                          string.Format("{0:0.00}", thu),
                                          string.Format("{0:0.00}", fri),
                                          string.Format("{0:0.00}", sat),
                                          string.Format("{0:0.00}", sum),
                                          string.Format("{0:0.00}", rh),
                                          string.Format("{0:0.00}", oh));
                        }
                    }
                }

                dataGridView3.DataSource = BVdt;
                dataGridView3.Columns[0].Width = 200;
                dataGridView3.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView3.Columns[1].Width = 100;
                dataGridView3.Sort(dataGridView3.Columns[1], ListSortDirection.Ascending);
                dataGridView3.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView3.Columns[2].Width = 100;
                dataGridView3.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView3.Columns[3].Width = 55;
                dataGridView3.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView3.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView3.Columns[4].Width = 55;
                dataGridView3.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView3.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView3.Columns[5].Width = 55;
                dataGridView3.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView3.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView3.Columns[6].Width = 55;
                dataGridView3.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView3.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView3.Columns[7].Width = 55;
                dataGridView3.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView3.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView3.Columns[8].Width = 55;
                dataGridView3.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView3.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView3.Columns[9].Width = 55;
                dataGridView3.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView3.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView3.Columns[10].Width = 55;
                dataGridView3.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView3.Columns[10].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView3.Columns[10].DefaultCellStyle.BackColor = Color.Tan;
                dataGridView3.Columns[11].Width = 55;
                dataGridView3.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView3.Columns[11].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView3.Columns[11].DefaultCellStyle.BackColor = Color.Orange;
                dataGridView3.Columns[12].Width = 55;
                dataGridView3.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView3.Columns[12].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView3.Columns[12].DefaultCellStyle.BackColor = Color.Peru;

                Last_Check();

                dataGridView3.ClearSelection();
            }
        }

        private void monthCalendar5_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtBVStartDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar5.SelectionStart));
            monthCalendar5.Visible = false;
        }

        private void txtBVStartDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar5.Visible = true;
        }

        private void btnBVClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBVGenerateExcel_Click(object sender, EventArgs e)
        {
            if (parentForm.employeeID.ToUpper() == "ADMIN" | parentForm.specialCode == parentForm.txtSpecialCode.Text.Trim().ToString().ToUpper())
            {
                if (dataGridView3.RowCount > 0)
                {
                    this.Enabled = false;

                    Excel_12.Application ReportFile;
                    Excel_12._Workbook WorkBook;
                    Excel_12._Worksheet WorkSheet;
                    //Excel_12.Range Range;

                    string MaxRow = Convert.ToString(BVdt.Rows.Count + 1);
                    String MaxColumn = ((String)(Convert.ToChar(BVdt.Columns.Count / 26 + 64).ToString() + Convert.ToChar(BVdt.Columns.Count % 26 + 64))).Replace('@', ' ').Trim();
                    String MaxCell = MaxColumn + MaxRow;

                    ReportFile = new Excel_12.Application();
                    ReportFile.Visible = false;

                    WorkBook = (Excel_12._Workbook)(ReportFile.Workbooks.Add("workbook"));
                    WorkSheet = (Excel_12._Worksheet)WorkBook.ActiveSheet;

                    for (int i = 0; i < BVdt.Columns.Count; i++)
                        WorkSheet.Cells[1, i + 1] = BVdt.Columns[i].ColumnName;

                    string[,] Values = new string[BVdt.Rows.Count, BVdt.Columns.Count];

                    for (int i = 0; i < BVdt.Rows.Count; i++)
                        for (int j = 0; j < BVdt.Columns.Count; j++)
                        {

                            Values[i, j] = BVdt.Rows[i][j].ToString();

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
                if (dataGridView3.RowCount > 0)
                {
                    /*if (parentForm.StoreCode != cmbBVStoreCode.Text.ToUpper().ToString())
                    {
                        MessageBox.Show("INCORRECT STORE CODE \n" + "YOUR ORIGINAL LOCATION IS " + parentForm.storeName.ToUpper() + " STORE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }*/

                    if (parentForm.StoreCode == cmbBVStoreCode.Text.ToUpper().ToString())
                    {
                        checkNum = -1;

                        cmd_CheckSettle = new SqlCommand("Check_Settle_TimeCard", parentForm.conn);
                        cmd_CheckSettle.CommandType = CommandType.StoredProcedure;
                        cmd_CheckSettle.Parameters.Clear();
                        cmd_CheckSettle.Parameters.Add("@StartDate", SqlDbType.Int).Value = nBVStartDate;
                        cmd_CheckSettle.Parameters.Add("@EndDate", SqlDbType.Int).Value = nBVEndDate;
                        //cmd_CheckSettle.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", BVStartDate);
                        //cmd_CheckSettle.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", BVEndDate);
                        SqlParameter CheckNum_Param = cmd_CheckSettle.Parameters.Add("@CheckNum", SqlDbType.Int);
                        CheckNum_Param.Direction = ParameterDirection.Output;

                        parentForm.conn.Open();
                        cmd_CheckSettle.ExecuteNonQuery();
                        parentForm.conn.Close();

                        if (cmd_CheckSettle.Parameters["@CheckNum"].Value != DBNull.Value)
                            checkNum = Convert.ToInt64(cmd_CheckSettle.Parameters["@CheckNum"].Value);

                        if (checkNum == 0)
                        {
                            ExportDataGridViewTo_Excel12(dataGridView3);
                        }
                        else
                        {
                            MessageBox.Show("YOU CANNOT GENERATE AN EXCEL BECAUSE THE HOURS WITHIN THE TIME FRAME HAVE NOT BEEN SETTLED.\n" + "PLEASE GO TO THE DAILY VIEW AND SETTLE THE TIME CARD.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        if (cmbBVStoreCode.Text == "OH")
                        {
                            newConn = new SqlConnection("Data Source=" + parentForm.OHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.OHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                            this.Text = "TIME CARD (LOCATION : OXON HILL)";
                        }
                        else if (cmbBVStoreCode.Text == "CH")
                        {
                            newConn = new SqlConnection("Data Source=" + parentForm.CHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                            this.Text = "TIME CARD (LOCATION : CAPITOL HEIGHTS)";
                        }
                        else if (cmbBVStoreCode.Text == "WB")
                        {
                            newConn = new SqlConnection("Data Source=" + parentForm.WBIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WBDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                            this.Text = "TIME CARD (LOCATION : WOODBRIDGE)";
                        }
                        else if (cmbBVStoreCode.Text == "CV")
                        {
                            newConn = new SqlConnection("Data Source=" + parentForm.CVIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.CVDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                            this.Text = "TIME CARD (LOCATION : CATONSVILLE)";
                        }
                        else if (cmbBVStoreCode.Text == "UM")
                        {
                            newConn = new SqlConnection("Data Source=" + parentForm.UMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.UMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                            this.Text = "TIME CARD (LOCATION : UPPER MARLBORO)";
                        }
                        else if (cmbBVStoreCode.Text == "WM")
                        {
                            newConn = new SqlConnection("Data Source=" + parentForm.WMIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WMDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                            this.Text = "TIME CARD (LOCATION : WINDSOR MILL)";
                        }
                        else if (cmbBVStoreCode.Text == "TH")
                        {
                            newConn = new SqlConnection("Data Source=" + parentForm.THIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.THDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                            this.Text = "TIME CARD (LOCATION : TEMPLE HILLS)";
                        }
                        else if (cmbBVStoreCode.Text == "WD")
                        {
                            newConn = new SqlConnection("Data Source=" + parentForm.WDIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.WDDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                            this.Text = "TIME CARD (LOCATION : WALDORF)";
                        }
                        else if (cmbBVStoreCode.Text == "PW")
                        {
                            newConn = new SqlConnection("Data Source=" + parentForm.PWIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.PWDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                            this.Text = "TIME CARD (LOCATION : PRINCE WILLIAM)";
                        }
                        else if (cmbBVStoreCode.Text == "GB")
                        {
                            newConn = new SqlConnection(parentForm.GBCS_IP);
                            this.Text = "TIME CARD (LOCATION : GAITHERSBURG)";
                        }
                        else if (cmbBVStoreCode.Text == "BW")
                        {
                            newConn = new SqlConnection(parentForm.BWCS_IP);
                            this.Text = "TIME CARD (LOCATION : BOWIE)";
                        }
                        else if (cmbBVStoreCode.Text == "B4UHQ")
                        {
                            newConn = new SqlConnection("Data Source=" + parentForm.B4UHQIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.B4UHQDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                            this.Text = "TIME CARD (LOCATION : BEAUTY 4U HEADQUARTES)";
                        }
                        else if (cmbBVStoreCode.Text == "B4UWH")
                        {
                            newConn = new SqlConnection("Data Source=" + parentForm.B4UWHIP + "," + parentForm.sqlPort + ";Network Library=DBMSSOCN;Initial Catalog=" + parentForm.B4UWHDB + ";User ID=" + parentForm.DBUID + ";Password=" + parentForm.DBPSW);
                            this.Text = "TIME CARD (LOCATION : BEAUTY 4U WAREHOUSE)";
                        }
                        else if (cmbStoreCode.Text == "TEST")
                        {
                            newConn = new SqlConnection(parentForm.Test1CS);
                            this.Text = "TIME CARD (LOCATION : TEST)";
                        }

                        checkNum = -1;

                        cmd_CheckSettle = new SqlCommand("Check_Settle_TimeCard", newConn);
                        cmd_CheckSettle.CommandType = CommandType.StoredProcedure;
                        cmd_CheckSettle.Parameters.Clear();
                        cmd_CheckSettle.Parameters.Add("@StartDate", SqlDbType.Int).Value = nBVStartDate;
                        cmd_CheckSettle.Parameters.Add("@EndDate", SqlDbType.Int).Value = nBVEndDate;
                        //cmd_CheckSettle.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", BVStartDate);
                        //cmd_CheckSettle.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", BVEndDate);
                        SqlParameter CheckNum_Param = cmd_CheckSettle.Parameters.Add("@CheckNum", SqlDbType.Int);
                        CheckNum_Param.Direction = ParameterDirection.Output;

                        newConn.Open();
                        cmd_CheckSettle.ExecuteNonQuery();
                        newConn.Close();

                        if (cmd_CheckSettle.Parameters["@CheckNum"].Value != DBNull.Value)
                            checkNum = Convert.ToInt64(cmd_CheckSettle.Parameters["@CheckNum"].Value);

                        if (checkNum == 0)
                        {
                            ExportDataGridViewTo_Excel12(dataGridView3);
                        }
                        else
                        {
                            MessageBox.Show("YOU CANNOT GENERATE AN EXCEL BECAUSE THE HOURS WITHIN THE TIME FRAME HAVE NOT BEEN SETTLED.\n" + "PLEASE GO TO THE DAILY VIEW AND SETTLE THE TIME CARD.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
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
            try
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    cmd_Settle = new SqlCommand("Settle_TimeCard", parentForm.conn);
                    cmd_Settle.CommandType = CommandType.StoredProcedure;
                    cmd_Settle.Parameters.Add("@TcNum", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                    cmd_Settle.Parameters.Add("@TcSettleID", SqlDbType.NVarChar).Value = parentForm.employeeID.ToUpper();
                    cmd_Settle.Parameters.Add("@TcSettleDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

                    parentForm.conn.Open();
                    cmd_Settle.ExecuteNonQuery();
                    parentForm.conn.Close();

                    backgroundWorker1.ReportProgress(i + 1);
                }
            }
            catch
            {
                MessageBox.Show("UPDATE FAILED OR CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                parentForm.conn.Close();
                progressBar1.Visible = false;
                progressBar1.Value = 0;
                btnSettle.Enabled = true;
                return;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("SUCCESSFULLY SETTLED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnOK_Click(null, null);
            progressBar1.Visible = false;
            progressBar1.Value = 0;
            btnSettle.Enabled = true;
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    cmd_Unsettle = new SqlCommand("Unsettle_TimeCard", parentForm.conn);
                    cmd_Unsettle.CommandType = CommandType.StoredProcedure;
                    cmd_Unsettle.Parameters.Add("@TcNum", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                    cmd_Unsettle.Parameters.Add("@TcUnsettleID", SqlDbType.NVarChar).Value = parentForm.employeeID.ToUpper();
                    cmd_Unsettle.Parameters.Add("@TcUnsettleDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);

                    parentForm.conn.Open();
                    cmd_Unsettle.ExecuteNonQuery();
                    parentForm.conn.Close();

                    backgroundWorker2.ReportProgress(i + 1);
                }
            }
            catch
            {
                MessageBox.Show("UPDATE FAILED OR CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                parentForm.conn.Close();
                progressBar1.Visible = false;
                progressBar1.Value = 0;
                btnUnsettle.Enabled = true;
                return;
            }
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("SUCCESSFULLY UNSETTLED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnOK_Click(null, null);
            progressBar1.Visible = false;
            progressBar1.Value = 0;
            btnUnsettle.Enabled = true;
        }

        private void Last_Check()
        {
            if (dataGridView3.RowCount == 0)
            {
                btnBVOK.Enabled = true;
                return;
            }

            totalRegularHour = 0;
            totalOvertimehour = 0;
            totalWorkingHour = 0;

            for (int i = 0; i < dataGridView3.RowCount; i++)
            {
                totalRegularHour = totalRegularHour + Convert.ToDouble(dataGridView3.Rows[i].Cells[11].Value);
                totalOvertimehour = totalOvertimehour + Convert.ToDouble(dataGridView3.Rows[i].Cells[12].Value);
                totalWorkingHour = totalWorkingHour + Convert.ToDouble(dataGridView3.Rows[i].Cells[10].Value);

                for (int j = 3; j < 13; j++)
                {
                    if (Convert.ToDouble(dataGridView3.Rows[i].Cells[j].Value) > 0)
                    {
                        if (j < 10)
                        {
                            dataGridView3.Rows[i].Cells[j].Style.ForeColor = Color.DarkGreen;
                            dataGridView3.Rows[i].Cells[j].Style.BackColor = Color.Yellow;
                        }
                        else
                        {
                            dataGridView3.Rows[i].Cells[j].Style.ForeColor = Color.DarkRed;
                        }
                    }
                    else if (Convert.ToDouble(dataGridView3.Rows[i].Cells[j].Value) < 0)
                    {
                        dataGridView3.Rows[i].Cells[j].Value = 0;
                    }
                }
            }

            label24.Text = string.Format("{0:0.00}", totalRegularHour);
            label26.Text = string.Format("{0:0.00}", totalOvertimehour);
            label17.Text = string.Format("{0:0.00}", totalWorkingHour);
            label19.Text = Convert.ToString(dataGridView4.RowCount - 1);
            btnBVOK.Enabled = true;
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.RowCount == 0)
                return;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[12].Value == DBNull.Value)
                {
                    if (dataGridView1.Rows[i].Cells[16].Value == DBNull.Value)
                    {
                        dataGridView1.Rows[i].Cells[10].Style.BackColor = Color.Red;
                        dataGridView1.Rows[i].Cells[11].Style.BackColor = Color.Red;
                    }
                    else if (Convert.ToDouble(dataGridView1.Rows[i].Cells[16].Value) < 1)
                    {
                        dataGridView1.Rows[i].Cells[10].Style.BackColor = Color.Red;
                        dataGridView1.Rows[i].Cells[11].Style.BackColor = Color.Red;
                    }
                }
                else
                {
                    if (dataGridView1.Rows[i].Cells[12].Value != DBNull.Value)
                        dataGridView1.Rows[i].Cells[11].Style.ForeColor = Color.Red;

                }
            }
        }

        private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.RowCount == 0)
                return;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[12].Value == DBNull.Value)
                {
                    if (dataGridView1.Rows[i].Cells[16].Value == DBNull.Value)
                    {
                        dataGridView1.Rows[i].Cells[10].Style.BackColor = Color.Red;
                        dataGridView1.Rows[i].Cells[11].Style.BackColor = Color.Red;
                    }
                    else if (Convert.ToDouble(dataGridView1.Rows[i].Cells[16].Value) < 1)
                    {
                        dataGridView1.Rows[i].Cells[10].Style.BackColor = Color.Red;
                        dataGridView1.Rows[i].Cells[11].Style.BackColor = Color.Red;
                    }
                }
                else
                {
                    if (dataGridView1.Rows[i].Cells[12].Value != DBNull.Value)
                        dataGridView1.Rows[i].Cells[11].Style.ForeColor = Color.Red;

                }
            }
        }
    }
}