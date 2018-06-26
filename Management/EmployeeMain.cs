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
    public partial class EmployeeMain : Form
    {
        public LogInManagements parentForm;
        SqlCommand cmd;
        SqlDataAdapter adapt;
        DataTable dt = new DataTable();
        public DataTable temp = new DataTable();
        public Font drvFont = new Font("Arial", 9, FontStyle.Bold);

        SqlConnection newConn;
        SqlCommand newCmd;
        string[] newConnectionString = new string[13];

        string scCurrent;
        string empSystemAdminPassword = "";
        string empLoginID, empPassword, empFirstName, empLastName, empPosition, empSSN, empAddress, empCity, empState, empZipCode, empPhone1, empPhone2, empEmail, empEmerName, empEmerPhone;
        int empAccessLv;
        DateTime empStartDate, empDOB;
        bool empStatus;

        int bNum = 0, aNum = 0;
        public int idx = 0;

        int activeEmployees = 0;

        string selectedEmployeeID;

        public EmployeeMain()
        {
            InitializeComponent();
        }

        public void EmployeeMain_Load(object sender, EventArgs e)
        {
            this.Text = "EMPLOYEE MAIN - " + parentForm.employeeID + " LOGGED IN " + parentForm.storeName;

            if (parentForm.StoreCode.ToUpper() == "B4UHQ")
            {
                btnTransferEmployee.Enabled = true;
            }
            else
            {
                btnTransferEmployee.Enabled = false;
            }

            try
            {
                cmd = new SqlCommand("Get_UserAll", parentForm.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                parentForm.conn.Open();
                dt.Clear();
                adapt.Fill(dt);
                parentForm.conn.Close();

                temp = dt.Copy();
                BindingData();

                if (parentForm.userLevel < parentForm.btnEmployeeDelete)
                    btnDeleteEmployee.Enabled = false;

                if (parentForm.userLevel < parentForm.btnEmployeeEditTimeCard & parentForm.employeeID.ToUpper() != parentForm.SystemMasterUserName.ToUpper())
                {
                    btnEditTimeCard.Visible = false;
                    btnEditTimeCard.Enabled = false;
                }

                if (parentForm.userLevel < parentForm.btnEmployeeExcel)
                    btnExcel.Enabled = false;

                if (dataGridView1.RowCount > 0)
                {
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        if (parentForm.StoreCode.ToUpper() == "B4UHQ")
                        {
                            if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[10].Value) == true)
                                activeEmployees = activeEmployees + 1;
                        }
                        else
                        {
                            if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[9].Value) == true)
                                activeEmployees = activeEmployees + 1;
                        }
                    }

                    lblActiveEmployees.Text = activeEmployees.ToString();
                    lblTotalEmployees.Text = dataGridView1.RowCount.ToString();
                    activeEmployees = 0;
                }

                newConnectionString[0] = parentForm.B4UHQCS_IP;
                newConnectionString[1] = parentForm.B4UWHCS_IP;
                newConnectionString[2] = parentForm.THCS_IP;
                newConnectionString[3] = parentForm.OHCS_IP;
                newConnectionString[4] = parentForm.UMCS_IP;
                newConnectionString[5] = parentForm.CHCS_IP;
                newConnectionString[6] = parentForm.WMCS_IP;
                newConnectionString[7] = parentForm.CVCS_IP;
                newConnectionString[8] = parentForm.PWCS_IP;
                newConnectionString[9] = parentForm.WBCS_IP;
                newConnectionString[10] = parentForm.WDCS_IP;
                newConnectionString[11] = parentForm.GBCS_IP;
                newConnectionString[12] = parentForm.BWCS_IP;
            }
            catch
            {
                MessageBox.Show("EMPLOYEE LOADING FAILED OR CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                parentForm.conn.Close();
                this.Close();
            }
        }

        private void btnRegisterNewEmployee_Click(object sender, EventArgs e)
        {
            RegisterNewEmployee registerNewEmployeeForm = new RegisterNewEmployee();
            registerNewEmployeeForm.parentForm1 = this.parentForm;
            registerNewEmployeeForm.parentForm2 = this;
            registerNewEmployeeForm.ShowDialog();
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            if (parentForm.StoreCode.ToUpper() == "B4UHQ")
            {
                selectedEmployeeID = Convert.ToString(dataGridView1.SelectedCells[5].Value);
            }
            else
            {
                selectedEmployeeID = Convert.ToString(dataGridView1.SelectedCells[4].Value);
            }

            if (parentForm.employeeID.ToUpper() == "ADMIN" | parentForm.employeeID.ToUpper() == selectedEmployeeID)
            {
                UpdateEmployee updateEmployeeForm = new UpdateEmployee();
                updateEmployeeForm.parentForm1 = this.parentForm;
                updateEmployeeForm.parentForm2 = this;
                updateEmployeeForm.ShowDialog();
            }
            else
            {
                if (parentForm.StoreCode.ToUpper() == "B4UHQ")
                {
                    if (parentForm.userLevel >= parentForm.btnEmployeeUpdate)
                    {
                        if (Convert.ToString(dataGridView1.SelectedCells[5].Value).ToUpper().ToString() == parentForm.SystemMasterUserName.ToUpper())
                        {
                            if (parentForm.employeeID.ToUpper() != parentForm.SystemMasterUserName.ToUpper())
                            {
                                MessageBox.Show("YOU CAN NOT EDIT THIS EMPLOYEE'S INFORMATION", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                if (Convert.ToInt16(dataGridView1.SelectedCells[8].Value) >= parentForm.userLevel)
                                {
                                    MessageBox.Show("YOU CAN NOT EDIT THIS EMPLOYEE'S INFORMATION", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                else
                                {
                                    UpdateEmployee updateEmployeeForm = new UpdateEmployee();
                                    updateEmployeeForm.parentForm1 = this.parentForm;
                                    updateEmployeeForm.parentForm2 = this;
                                    updateEmployeeForm.ShowDialog();
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt16(dataGridView1.SelectedCells[8].Value) >= parentForm.userLevel)
                            {
                                MessageBox.Show("YOU CAN NOT EDIT THIS EMPLOYEE'S INFORMATION", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                UpdateEmployee updateEmployeeForm = new UpdateEmployee();
                                updateEmployeeForm.parentForm1 = this.parentForm;
                                updateEmployeeForm.parentForm2 = this;
                                updateEmployeeForm.ShowDialog();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("NOT AUTHORIZED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    if (parentForm.userLevel >= parentForm.btnEmployeeUpdate)
                    {
                        if (Convert.ToString(dataGridView1.SelectedCells[4].Value).ToUpper().ToString() == parentForm.SystemMasterUserName.ToUpper())
                        {
                            if (parentForm.employeeID.ToUpper() != parentForm.SystemMasterUserName.ToUpper())
                            {
                                MessageBox.Show("YOU CAN NOT EDIT THIS EMPLOYEE'S INFORMATION", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                if (Convert.ToInt16(dataGridView1.SelectedCells[7].Value) >= parentForm.userLevel)
                                {
                                    MessageBox.Show("YOU CAN NOT EDIT THIS EMPLOYEE'S INFORMATION", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                else
                                {
                                    UpdateEmployee updateEmployeeForm = new UpdateEmployee();
                                    updateEmployeeForm.parentForm1 = this.parentForm;
                                    updateEmployeeForm.parentForm2 = this;
                                    updateEmployeeForm.ShowDialog();
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt16(dataGridView1.SelectedCells[7].Value) >= parentForm.userLevel)
                            {
                                MessageBox.Show("YOU CAN NOT EDIT THIS EMPLOYEE'S INFORMATION", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                UpdateEmployee updateEmployeeForm = new UpdateEmployee();
                                updateEmployeeForm.parentForm1 = this.parentForm;
                                updateEmployeeForm.parentForm2 = this;
                                updateEmployeeForm.ShowDialog();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("NOT AUTHORIZED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            if (parentForm.StoreCode.ToUpper() == "B4UHQ")
            {
                if (Convert.ToString(dataGridView1.SelectedCells[5].Value) == parentForm.SystemMasterUserName.ToUpper())
                {
                    MessageBox.Show("CAN NOT DELETE ADMIN ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (parentForm.userLevel <= Convert.ToInt16(dataGridView1.SelectedCells[8].Value))
                {
                    MessageBox.Show("CAN NOT DELETE HIGHER OR SAME LEVEL ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    DialogResult MyDialogResult;
                    MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (MyDialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            bNum = dataGridView1.RowCount;
                            idx = dataGridView1.SelectedRows[0].Index;

                            if (DBConnectionStatus(parentForm.B4UWHCS_IP) == false)
                            {
                                MessageBox.Show("B4U WAREHOUSE DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (DBConnectionStatus(parentForm.THCS_IP) == false)
                            {
                                MessageBox.Show("TEMPLE HILLS DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (DBConnectionStatus(parentForm.OHCS_IP) == false)
                            {
                                MessageBox.Show("OXON HILL DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (DBConnectionStatus(parentForm.UMCS_IP) == false)
                            {
                                MessageBox.Show("UPPER MARLBORO DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (DBConnectionStatus(parentForm.CHCS_IP) == false)
                            {
                                MessageBox.Show("CAPITOL HEIGHTS DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (DBConnectionStatus(parentForm.WMCS_IP) == false)
                            {
                                MessageBox.Show("WINDSOR MILL DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (DBConnectionStatus(parentForm.CVCS_IP) == false)
                            {
                                MessageBox.Show("CATONSVILLE DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (DBConnectionStatus(parentForm.PWCS_IP) == false)
                            {
                                MessageBox.Show("PRINCE WILLIAM DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (DBConnectionStatus(parentForm.WBCS_IP) == false)
                            {
                                MessageBox.Show("WOODBRIDGE DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (DBConnectionStatus(parentForm.WDCS_IP) == false)
                            {
                                MessageBox.Show("WALDORF DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (DBConnectionStatus(parentForm.GBCS_IP) == false)
                            {
                                MessageBox.Show("GAITHERSBURG DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (DBConnectionStatus(parentForm.BWCS_IP) == false)
                            {
                                MessageBox.Show("BOWIE DB CONNECTION FAILED. PLEASE TRY AGAIN.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            progressBar1.Visible = true;
                            progressBar1.Minimum = 0;
                            progressBar1.Maximum = 13;
                            progressBar1.Step = 1;

                            for (int i = 0; i < 13; i++)
                            {
                                newConn = new SqlConnection(newConnectionString[i]);
                                newCmd = new SqlCommand("Delete_Employee", newConn);
                                newCmd.CommandType = CommandType.StoredProcedure;
                                newCmd.Parameters.Clear();
                                newCmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.SelectedCells[5].Value).ToUpper();
                                newCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.SelectedCells[6].Value).ToUpper();

                                newConn.Open();
                                newCmd.ExecuteNonQuery();
                                newConn.Close();

                                progressBar1.Value = i + 1;
                            }

                            EmployeeMain_Load(null, null);
                            aNum = dataGridView1.RowCount;
                            dataGridView1.Rows[idx].Selected = true;

                            if (idx > 12)
                                dataGridView1.FirstDisplayedScrollingRowIndex = idx;

                            if (aNum == bNum)
                            {
                                MessageBox.Show("INCORRECT EMPLOYEE ID OR INCORRECT PASSWORD", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                bNum = 0;
                                aNum = 0;

                                progressBar1.Visible = false;
                            }
                            else
                            {
                                MessageBox.Show("SUCCESSFULLY DELETED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                bNum = 0;
                                aNum = 0;

                                progressBar1.Visible = false;
                            }
                        }
                        catch
                        {
                            MessageBox.Show("DELETE FAILED OR CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            progressBar1.Visible = false;
                            parentForm.conn.Close();
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                if (Convert.ToString(dataGridView1.SelectedCells[4].Value) == parentForm.SystemMasterUserName.ToUpper())
                {
                    MessageBox.Show("CAN NOT DELETE ADMIN ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (parentForm.userLevel <= Convert.ToInt16(dataGridView1.SelectedCells[7].Value))
                {
                    MessageBox.Show("CAN NOT DELETE HIGHER OR SAME LEVEL ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    DialogResult MyDialogResult;
                    MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (MyDialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            bNum = dataGridView1.RowCount;
                            idx = dataGridView1.SelectedRows[0].Index;

                            cmd = new SqlCommand("Delete_Employee", parentForm.conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.SelectedCells[4].Value).ToUpper();
                            cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Convert.ToString(dataGridView1.SelectedCells[5].Value).ToUpper();

                            parentForm.conn.Open();
                            cmd.ExecuteNonQuery();
                            parentForm.conn.Close();

                            EmployeeMain_Load(null, null);
                            aNum = dataGridView1.RowCount;
                            dataGridView1.Rows[idx].Selected = true;

                            if (idx > 12)
                                dataGridView1.FirstDisplayedScrollingRowIndex = idx;

                            if (aNum == bNum)
                            {
                                MessageBox.Show("INCORRECT EMPLOYEE ID OR INCORRECT PASSWORD", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                bNum = 0;
                                aNum = 0;
                            }
                            else
                            {
                                MessageBox.Show("SUCCESSFULLY DELETED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                bNum = 0;
                                aNum = 0;
                            }
                        }
                        catch
                        {
                            MessageBox.Show("DELETE FAILED OR CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            parentForm.conn.Close();
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        private void btnEditTimeCard_Click(object sender, EventArgs e)
        {
            TimeCard timeCardForm = new TimeCard(1);
            timeCardForm.parentForm = this.parentForm;
            timeCardForm.Show();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BindingData()
        {
            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.RowTemplate.DefaultCellStyle.Font = drvFont;
            dataGridView1.DataSource = dt;

            if (parentForm.StoreCode.ToUpper() == "B4UHQ")
            {
                if (parentForm.userLevel >= parentForm.SystemAdministratorLV & parentForm.employeeID.ToUpper() == parentForm.SystemMasterUserName.ToUpper())
                {
                    dataGridView1.Columns[0].HeaderText = "EMP NO";
                    dataGridView1.Columns[1].HeaderText = "SC (R)";
                    dataGridView1.Columns[2].HeaderText = "SC (C)";
                    dataGridView1.Columns[3].HeaderText = "FIRST NAME";
                    dataGridView1.Columns[4].HeaderText = "LAST NAME";
                    dataGridView1.Columns[5].HeaderText = "LOGIN ID";
                    dataGridView1.Columns[6].HeaderText = "PASSWORD";
                    dataGridView1.Columns[7].HeaderText = "POSITION";
                    dataGridView1.Columns[8].HeaderText = "ACCESS LV";
                    dataGridView1.Columns[9].HeaderText = "START DATE";
                    dataGridView1.Columns[9].DefaultCellStyle.Format = "MM/dd/yyyy h:mm:ss tt";
                    dataGridView1.Columns[10].HeaderText = "ACTIVE";
                    dataGridView1.Columns[11].HeaderText = "SSN";
                    dataGridView1.Columns[12].HeaderText = "DOB";
                    dataGridView1.Columns[12].DefaultCellStyle.Format = "MM/dd/yyyy";
                    dataGridView1.Columns[13].HeaderText = "ADDRESS";
                    dataGridView1.Columns[14].HeaderText = "CITY";
                    dataGridView1.Columns[15].HeaderText = "STATE";
                    dataGridView1.Columns[16].HeaderText = "ZIPCODE";
                    dataGridView1.Columns[17].HeaderText = "PHONE1";
                    dataGridView1.Columns[18].HeaderText = "PHONE2";
                    dataGridView1.Columns[19].HeaderText = "EMAIL";
                    dataGridView1.Columns[20].HeaderText = "EMR CONT NAME";
                    dataGridView1.Columns[21].HeaderText = "EMR CONT PHONE";

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        if (Convert.ToString(dataGridView1.Rows[i].Cells[5].Value).ToUpper() == parentForm.SystemMasterUserName.ToUpper())
                        {
                            if (empSystemAdminPassword == "")
                            {
                                empSystemAdminPassword = Convert.ToString(dataGridView1.Rows[i].Cells[6].Value);
                                dataGridView1.Rows[i].Cells[6].Value = "********";
                            }
                            else
                            {
                                dataGridView1.Rows[i].Cells[6].Value = "********";
                            }
                        }
                    }

                }
                else
                {
                    dataGridView1.Columns[0].HeaderText = "EMP NO";
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "SC (R)";
                    dataGridView1.Columns[1].Width = 50;
                    dataGridView1.Columns[2].HeaderText = "SC (C)";
                    dataGridView1.Columns[2].Width = 50;
                    dataGridView1.Columns[3].HeaderText = "FIRST NAME";
                    dataGridView1.Columns[3].Width = 120;
                    dataGridView1.Columns[4].HeaderText = "LAST NAME";
                    dataGridView1.Columns[4].Width = 120;
                    dataGridView1.Columns[5].HeaderText = "LOGIN ID";
                    dataGridView1.Columns[5].Width = 100;
                    dataGridView1.Columns[6].HeaderText = "PASSWORD";
                    dataGridView1.Columns[6].Visible = false;
                    dataGridView1.Columns[7].HeaderText = "POSITION";
                    dataGridView1.Columns[7].Width = 90;
                    dataGridView1.Columns[8].HeaderText = "ACC LV";
                    dataGridView1.Columns[8].Width = 40;
                    dataGridView1.Columns[9].HeaderText = "START DATE";
                    dataGridView1.Columns[9].Width = 90;
                    dataGridView1.Columns[9].DefaultCellStyle.Format = "MM/dd/yyyy";
                    dataGridView1.Columns[10].HeaderText = "ACT";
                    dataGridView1.Columns[10].Width = 40;
                    dataGridView1.Columns[11].HeaderText = "SSN";
                    dataGridView1.Columns[11].Width = 70;
                    dataGridView1.Columns[11].Visible = false;
                    dataGridView1.Columns[12].HeaderText = "DOB";
                    dataGridView1.Columns[12].Width = 70;
                    dataGridView1.Columns[12].DefaultCellStyle.Format = "MM/dd/yyyy";
                    dataGridView1.Columns[13].HeaderText = "ADDRESS";
                    dataGridView1.Columns[13].Width = 170;
                    dataGridView1.Columns[14].HeaderText = "CITY";
                    dataGridView1.Columns[14].Width = 120;
                    dataGridView1.Columns[15].HeaderText = "STATE";
                    dataGridView1.Columns[15].Width = 50;
                    dataGridView1.Columns[16].HeaderText = "ZIP";
                    dataGridView1.Columns[16].Width = 50;
                    dataGridView1.Columns[17].HeaderText = "PHONE1";
                    dataGridView1.Columns[17].Width = 80;
                    dataGridView1.Columns[18].HeaderText = "PHONE2";    
                    dataGridView1.Columns[18].Width = 80;
                    dataGridView1.Columns[19].HeaderText = "EMAIL";
                    dataGridView1.Columns[19].Width = 100;
                    dataGridView1.Columns[20].HeaderText = "EMR CONT NAME";
                    dataGridView1.Columns[20].Width = 150;
                    dataGridView1.Columns[21].HeaderText = "EMR CONT PHONE";
                    dataGridView1.Columns[21].Width = 100;

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        //dataGridView1.Rows[i].Cells[6].Value = "********";

                        if (Convert.ToString(dataGridView1.Rows[i].Cells[11].Value) != "")
                            dataGridView1.Rows[i].Cells[11].Value = "**********";
                    }
                }
            }
            else
            {
                if (parentForm.userLevel >= parentForm.SystemAdministratorLV & parentForm.employeeID.ToUpper() == parentForm.SystemMasterUserName.ToUpper())
                {
                    dataGridView1.Columns[0].HeaderText = "EMP NO";
                    dataGridView1.Columns[1].HeaderText = "SC";
                    dataGridView1.Columns[2].HeaderText = "FIRST NAME";
                    dataGridView1.Columns[3].HeaderText = "LAST NAME";
                    dataGridView1.Columns[4].HeaderText = "LOGIN ID";
                    dataGridView1.Columns[5].HeaderText = "PASSWORD";
                    dataGridView1.Columns[6].HeaderText = "POSITION";
                    dataGridView1.Columns[7].HeaderText = "ACCESS LV";
                    dataGridView1.Columns[8].HeaderText = "START DATE";
                    dataGridView1.Columns[8].DefaultCellStyle.Format = "MM/dd/yyyy h:mm:ss tt";
                    dataGridView1.Columns[9].HeaderText = "STATUS";
                    dataGridView1.Columns[10].HeaderText = "SSN";
                    dataGridView1.Columns[11].HeaderText = "DOB";
                    dataGridView1.Columns[11].DefaultCellStyle.Format = "MM/dd/yyyy";
                    dataGridView1.Columns[12].HeaderText = "ADDRESS";
                    dataGridView1.Columns[13].HeaderText = "CITY";
                    dataGridView1.Columns[14].HeaderText = "STATE";
                    dataGridView1.Columns[15].HeaderText = "ZIPCODE";
                    dataGridView1.Columns[16].HeaderText = "PHONE1";
                    dataGridView1.Columns[17].HeaderText = "PHONE2";
                    dataGridView1.Columns[18].HeaderText = "EMAIL";
                    dataGridView1.Columns[19].HeaderText = "EMR CONT NAME";
                    dataGridView1.Columns[20].HeaderText = "EMR CONT PHONE";

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        if (Convert.ToString(dataGridView1.Rows[i].Cells[4].Value).ToUpper() == parentForm.SystemMasterUserName.ToUpper())
                            dataGridView1.Rows[i].Cells[5].Value = "********";
                    }

                }
                else
                {
                    dataGridView1.Columns[0].HeaderText = "EMP NO";
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "SC";
                    dataGridView1.Columns[1].Visible = false;
                    dataGridView1.Columns[2].HeaderText = "FIRST NAME";
                    dataGridView1.Columns[2].Width = 150;
                    dataGridView1.Columns[3].HeaderText = "LAST NAME";
                    dataGridView1.Columns[3].Width = 150;
                    dataGridView1.Columns[4].HeaderText = "LOGIN ID";
                    dataGridView1.Columns[4].Width = 120;
                    dataGridView1.Columns[5].HeaderText = "PASSWORD";
                    dataGridView1.Columns[5].Visible = false;
                    dataGridView1.Columns[6].HeaderText = "POSITION";
                    dataGridView1.Columns[6].Width = 90;
                    dataGridView1.Columns[7].HeaderText = "ACCESS LV";
                    dataGridView1.Columns[7].Width = 80;
                    dataGridView1.Columns[8].HeaderText = "START DATE";
                    dataGridView1.Columns[8].Width = 90;
                    dataGridView1.Columns[8].DefaultCellStyle.Format = "MM/dd/yyyy";
                    dataGridView1.Columns[9].HeaderText = "STATUS";
                    dataGridView1.Columns[9].Width = 70;
                    dataGridView1.Columns[10].HeaderText = "SSN";
                    dataGridView1.Columns[10].Width = 90;
                    dataGridView1.Columns[11].HeaderText = "DOB";
                    dataGridView1.Columns[11].Width = 90;
                    dataGridView1.Columns[11].DefaultCellStyle.Format = "MM/dd/yyyy";
                    dataGridView1.Columns[12].HeaderText = "ADDRESS";
                    dataGridView1.Columns[12].Width = 200;
                    dataGridView1.Columns[13].HeaderText = "CITY";
                    dataGridView1.Columns[13].Width = 150;
                    dataGridView1.Columns[14].HeaderText = "STATE";
                    dataGridView1.Columns[14].Width = 70;
                    dataGridView1.Columns[15].HeaderText = "ZIPCODE";
                    dataGridView1.Columns[15].Width = 80;
                    dataGridView1.Columns[16].HeaderText = "PHONE1";
                    dataGridView1.Columns[16].Width = 90;
                    dataGridView1.Columns[17].HeaderText = "PHONE2";
                    dataGridView1.Columns[17].Width = 90;
                    dataGridView1.Columns[18].HeaderText = "EMAIL";
                    dataGridView1.Columns[18].Width = 200;
                    dataGridView1.Columns[19].HeaderText = "EMR CONT NAME";
                    dataGridView1.Columns[19].Width = 180;
                    dataGridView1.Columns[20].HeaderText = "EMR CONT PHONE";
                    dataGridView1.Columns[20].Width = 90;

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        //dataGridView1.Rows[i].Cells[5].Value = "********";

                        if (Convert.ToString(dataGridView1.Rows[i].Cells[10].Value) != "")
                            dataGridView1.Rows[i].Cells[10].Value = "**********";
                    }
                }
            }

            dataGridView1.ClearSelection();
        }

        public void ExportDataGridViewTo_Excel12(DataGridView myDataGridView)
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
                if (parentForm.StoreCode.ToUpper() == "B4UHQ")
                {
                    for (int i = 0; i < myDataGridView.Rows.Count; i++)
                    {
                        for (int j = 0; j < myDataGridView.Columns.Count; j++)
                        {
                            if (j == 6)
                            {
                                oRange = (Excel_12.Range)oSheet.Cells[i + 2, j + 1];
                                oRange.Value2 = "********";
                            }
                            else
                            {
                                oRange = (Excel_12.Range)oSheet.Cells[i + 2, j + 1];
                                oRange.Value2 = myDataGridView[j, i].Value.ToString();
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < myDataGridView.Rows.Count; i++)
                    {
                        for (int j = 0; j < myDataGridView.Columns.Count; j++)
                        {
                            if (j == 5)
                            {
                                oRange = (Excel_12.Range)oSheet.Cells[i + 2, j + 1];
                                oRange.Value2 = "********";
                            }
                            else
                            {
                                oRange = (Excel_12.Range)oSheet.Cells[i + 2, j + 1];
                                oRange.Value2 = myDataGridView[j, i].Value.ToString();
                            }
                        }
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

        private void btnProfile_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                EmployeeProfile employeeProfileForm = new EmployeeProfile(dataGridView1.SelectedRows[0].Index);
                employeeProfileForm.parentForm1 = this.parentForm;
                employeeProfileForm.parentForm2 = this;
                employeeProfileForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("NO EMPLOYEE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            if (e.RowIndex != -1)
            {
                btnProfile_Click(null, null);
            }
        }

        private void btnTransferEmployee_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            if (Convert.ToString(dataGridView1.SelectedCells[5].Value) == parentForm.SystemMasterUserName.ToUpper())
            {
                if (parentForm.employeeID.ToUpper() != "ADMIN")
                {
                    MessageBox.Show("CAN NOT TRANSFER SYSTEM ADMINISTRATOR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (parentForm.userLevel < Convert.ToInt16(dataGridView1.SelectedCells[8].Value))
            {
                MessageBox.Show("CAN NOT TRANSFER HIGHER LEVEL EMPLOYEE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                DialogResult MyDialogResult;
                MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (MyDialogResult == DialogResult.Yes)
                {
                    scCurrent = Convert.ToString(dataGridView1.SelectedCells[2].Value);
                    empFirstName = Convert.ToString(dataGridView1.SelectedCells[3].Value);
                    empLastName = Convert.ToString(dataGridView1.SelectedCells[4].Value);
                    empLoginID = Convert.ToString(dataGridView1.SelectedCells[5].Value);
                    empPassword = Convert.ToString(dataGridView1.SelectedCells[6].Value);
                    empPosition = Convert.ToString(dataGridView1.SelectedCells[7].Value);
                    empAccessLv = Convert.ToInt16(dataGridView1.SelectedCells[8].Value);
                    //empStartDate = Convert.ToDateTime(dataGridView1.SelectedCells[9].Value);
                    empStartDate = DateTime.Now;
                    empStatus = Convert.ToBoolean(dataGridView1.SelectedCells[10].Value);
                    empSSN = Convert.ToString(dataGridView1.SelectedCells[11].Value);
                    empDOB = Convert.ToDateTime(dataGridView1.SelectedCells[12].Value);
                    empAddress = Convert.ToString(dataGridView1.SelectedCells[13].Value);
                    empCity = Convert.ToString(dataGridView1.SelectedCells[14].Value);
                    empState = Convert.ToString(dataGridView1.SelectedCells[15].Value);
                    empZipCode = Convert.ToString(dataGridView1.SelectedCells[16].Value);
                    empPhone1 = Convert.ToString(dataGridView1.SelectedCells[17].Value);
                    empPhone2 = Convert.ToString(dataGridView1.SelectedCells[18].Value);
                    empEmail = Convert.ToString(dataGridView1.SelectedCells[19].Value);
                    empEmerName = Convert.ToString(dataGridView1.SelectedCells[20].Value);
                    empEmerPhone = Convert.ToString(dataGridView1.SelectedCells[21].Value);
                  
                    if (scCurrent.ToUpper() == "B4UHQ")
                    {
                        MessageBox.Show("EMPLOYEE CAN NOT BE TRANSFERRED TO BEAUTY 4U HEADQUARTERS", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (scCurrent.ToUpper() == "B4UWH")
                    {
                        if (DBConnectionStatus(parentForm.B4UWHCS_IP) == false)
                        {
                            MessageBox.Show("B4U WAREHOUSE DB CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            if (Duplicated_Employee_Check(parentForm.B4UWHCS_IP, empLoginID) == 0)
                            {
                                newConn = new SqlConnection(parentForm.B4UWHCS_IP);
                                newCmd = new SqlCommand("Register_New_Employee", newConn);
                                newCmd.CommandType = CommandType.StoredProcedure;
                                newCmd.Parameters.Clear();
                                newCmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = scCurrent;
                                newCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = empFirstName;
                                newCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = empLastName;
                                newCmd.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = empLoginID;
                                newCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = empPassword;
                                newCmd.Parameters.Add("@EmployeePosition", SqlDbType.NVarChar).Value = empPosition;
                                newCmd.Parameters.Add("@EmployeeAccessLV", SqlDbType.TinyInt).Value = empAccessLv;
                                newCmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = DateTime.Now;
                                newCmd.Parameters.Add("@Status", SqlDbType.Bit).Value = true;
                                newCmd.Parameters.Add("@SSN", SqlDbType.NVarChar).Value = empSSN;
                                newCmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = empDOB;
                                newCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = empAddress;
                                newCmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = empCity;
                                newCmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = empState;
                                newCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = empZipCode;
                                newCmd.Parameters.Add("@Phone1", SqlDbType.NVarChar).Value = empPhone1;
                                newCmd.Parameters.Add("@Phone2", SqlDbType.NVarChar).Value = empPhone2;
                                newCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = empEmail;
                                newCmd.Parameters.Add("@EmergencyName", SqlDbType.NVarChar).Value = empEmerName;
                                newCmd.Parameters.Add("@EmergencyPhone", SqlDbType.NVarChar).Value = empEmerPhone;

                                newConn.Open();
                                newCmd.ExecuteNonQuery();
                                newConn.Close();

                                Employee_Transfer_History(scCurrent, empFirstName, empLastName, empLoginID, DateTime.Today);

                                MessageBox.Show("SUCCESSFULLY TRANSFERRED TO BEAUTY 4U WAREHOUSE", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                DialogResult MyDialogResult2;
                                MyDialogResult2 = MessageBox.Show(this, "SELECTED EMPLOYEE INFORMATION IS ALREADY EXIST.\n\n" + "DO YOU WANT TO OVERWRITE EMPLOYEE INFORMATION?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (MyDialogResult2 == DialogResult.Yes)
                                {
                                    newConn = new SqlConnection(parentForm.B4UWHCS_IP);
                                    newCmd = new SqlCommand("Update_Employee2", newConn);
                                    newCmd.CommandType = CommandType.StoredProcedure;
                                    newCmd.Parameters.Clear();
                                    newCmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = scCurrent;
                                    newCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = empFirstName;
                                    newCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = empLastName;
                                    newCmd.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = empLoginID;
                                    newCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = empPassword;
                                    newCmd.Parameters.Add("@EmployeePosition", SqlDbType.NVarChar).Value = empPosition;
                                    newCmd.Parameters.Add("@EmployeeAccessLV", SqlDbType.TinyInt).Value = empAccessLv;
                                    newCmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = DateTime.Now;
                                    newCmd.Parameters.Add("@Status", SqlDbType.Bit).Value = true;
                                    newCmd.Parameters.Add("@SSN", SqlDbType.NVarChar).Value = empSSN;
                                    newCmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = empDOB;
                                    newCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = empAddress;
                                    newCmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = empCity;
                                    newCmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = empState;
                                    newCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = empZipCode;
                                    newCmd.Parameters.Add("@Phone1", SqlDbType.NVarChar).Value = empPhone1;
                                    newCmd.Parameters.Add("@Phone2", SqlDbType.NVarChar).Value = empPhone2;
                                    newCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = empEmail;
                                    newCmd.Parameters.Add("@EmergencyName", SqlDbType.NVarChar).Value = empEmerName;
                                    newCmd.Parameters.Add("@EmergencyPhone", SqlDbType.NVarChar).Value = empEmerPhone;

                                    newConn.Open();
                                    newCmd.ExecuteNonQuery();
                                    newConn.Close();

                                    MessageBox.Show("SUCCESSFULLY OVERWRITTEN TO BEAUTY 4U WAREHOUSE", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    return;
                                }
                            }
                        }
                    }
                    else if (scCurrent.ToUpper() == "TH")
                    {
                        if (DBConnectionStatus(parentForm.THCS_IP) == false)
                        {
                            MessageBox.Show("TEMPLE HILLS DB CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            if (Duplicated_Employee_Check(parentForm.THCS_IP, empLoginID) == 0)
                            {
                                newConn = new SqlConnection(parentForm.THCS_IP);
                                newCmd = new SqlCommand("Register_New_Employee", newConn);
                                newCmd.CommandType = CommandType.StoredProcedure;
                                newCmd.Parameters.Clear();
                                newCmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = scCurrent;
                                newCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = empFirstName;
                                newCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = empLastName;
                                newCmd.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = empLoginID;
                                newCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = empPassword;
                                newCmd.Parameters.Add("@EmployeePosition", SqlDbType.NVarChar).Value = empPosition;
                                newCmd.Parameters.Add("@EmployeeAccessLV", SqlDbType.TinyInt).Value = empAccessLv;
                                newCmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = DateTime.Now;
                                newCmd.Parameters.Add("@Status", SqlDbType.Bit).Value = true;
                                newCmd.Parameters.Add("@SSN", SqlDbType.NVarChar).Value = empSSN;
                                newCmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = empDOB;
                                newCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = empAddress;
                                newCmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = empCity;
                                newCmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = empState;
                                newCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = empZipCode;
                                newCmd.Parameters.Add("@Phone1", SqlDbType.NVarChar).Value = empPhone1;
                                newCmd.Parameters.Add("@Phone2", SqlDbType.NVarChar).Value = empPhone2;
                                newCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = empEmail;
                                newCmd.Parameters.Add("@EmergencyName", SqlDbType.NVarChar).Value = empEmerName;
                                newCmd.Parameters.Add("@EmergencyPhone", SqlDbType.NVarChar).Value = empEmerPhone;

                                newConn.Open();
                                newCmd.ExecuteNonQuery();
                                newConn.Close();

                                Employee_Transfer_History(scCurrent, empFirstName, empLastName, empLoginID, DateTime.Today);

                                MessageBox.Show("SUCCESSFULLY TRANSFERRED TO TEMPLE HILLS", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                DialogResult MyDialogResult2;
                                MyDialogResult2 = MessageBox.Show(this, "SELECTED EMPLOYEE INFORMATION IS ALREADY EXIST.\n\n" + "DO YOU WANT TO OVERWRITE EMPLOYEE INFORMATION?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (MyDialogResult2 == DialogResult.Yes)
                                {
                                    newConn = new SqlConnection(parentForm.THCS_IP);
                                    newCmd = new SqlCommand("Update_Employee2", newConn);
                                    newCmd.CommandType = CommandType.StoredProcedure;
                                    newCmd.Parameters.Clear();
                                    newCmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = scCurrent;
                                    newCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = empFirstName;
                                    newCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = empLastName;
                                    newCmd.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = empLoginID;
                                    newCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = empPassword;
                                    newCmd.Parameters.Add("@EmployeePosition", SqlDbType.NVarChar).Value = empPosition;
                                    newCmd.Parameters.Add("@EmployeeAccessLV", SqlDbType.TinyInt).Value = empAccessLv;
                                    newCmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = empStartDate;
                                    newCmd.Parameters.Add("@Status", SqlDbType.Bit).Value = empStatus;
                                    newCmd.Parameters.Add("@SSN", SqlDbType.NVarChar).Value = empSSN;
                                    newCmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = empDOB;
                                    newCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = empAddress;
                                    newCmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = empCity;
                                    newCmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = empState;
                                    newCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = empZipCode;
                                    newCmd.Parameters.Add("@Phone1", SqlDbType.NVarChar).Value = empPhone1;
                                    newCmd.Parameters.Add("@Phone2", SqlDbType.NVarChar).Value = empPhone2;
                                    newCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = empEmail;
                                    newCmd.Parameters.Add("@EmergencyName", SqlDbType.NVarChar).Value = empEmerName;
                                    newCmd.Parameters.Add("@EmergencyPhone", SqlDbType.NVarChar).Value = empEmerPhone;

                                    newConn.Open();
                                    newCmd.ExecuteNonQuery();
                                    newConn.Close();

                                    MessageBox.Show("SUCCESSFULLY OVERWRITTEN TO TEMPLE HILLS", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    return;
                                }
                            }
                        }
                    }
                    else if (scCurrent.ToUpper() == "OH")
                    {
                        if (DBConnectionStatus(parentForm.OHCS_IP) == false)
                        {
                            MessageBox.Show("OXON HILL DB CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            if (Duplicated_Employee_Check(parentForm.OHCS_IP, empLoginID) == 0)
                            {
                                newConn = new SqlConnection(parentForm.OHCS_IP);
                                newCmd = new SqlCommand("Register_New_Employee", newConn);
                                newCmd.CommandType = CommandType.StoredProcedure;
                                newCmd.Parameters.Clear();
                                newCmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = scCurrent;
                                newCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = empFirstName;
                                newCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = empLastName;
                                newCmd.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = empLoginID;
                                newCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = empPassword;
                                newCmd.Parameters.Add("@EmployeePosition", SqlDbType.NVarChar).Value = empPosition;
                                newCmd.Parameters.Add("@EmployeeAccessLV", SqlDbType.TinyInt).Value = empAccessLv;
                                newCmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = DateTime.Now;
                                newCmd.Parameters.Add("@Status", SqlDbType.Bit).Value = true;
                                newCmd.Parameters.Add("@SSN", SqlDbType.NVarChar).Value = empSSN;
                                newCmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = empDOB;
                                newCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = empAddress;
                                newCmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = empCity;
                                newCmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = empState;
                                newCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = empZipCode;
                                newCmd.Parameters.Add("@Phone1", SqlDbType.NVarChar).Value = empPhone1;
                                newCmd.Parameters.Add("@Phone2", SqlDbType.NVarChar).Value = empPhone2;
                                newCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = empEmail;
                                newCmd.Parameters.Add("@EmergencyName", SqlDbType.NVarChar).Value = empEmerName;
                                newCmd.Parameters.Add("@EmergencyPhone", SqlDbType.NVarChar).Value = empEmerPhone;

                                newConn.Open();
                                newCmd.ExecuteNonQuery();
                                newConn.Close();

                                Employee_Transfer_History(scCurrent, empFirstName, empLastName, empLoginID, DateTime.Today);

                                MessageBox.Show("SUCCESSFULLY TRANSFERRED TO OXON HILL", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                DialogResult MyDialogResult2;
                                MyDialogResult2 = MessageBox.Show(this, "SELECTED EMPLOYEE INFORMATION IS ALREADY EXIST.\n\n" + "DO YOU WANT TO OVERWRITE EMPLOYEE INFORMATION?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (MyDialogResult2 == DialogResult.Yes)
                                {
                                    newConn = new SqlConnection(parentForm.OHCS_IP);
                                    newCmd = new SqlCommand("Update_Employee2", newConn);
                                    newCmd.CommandType = CommandType.StoredProcedure;
                                    newCmd.Parameters.Clear();
                                    newCmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = scCurrent;
                                    newCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = empFirstName;
                                    newCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = empLastName;
                                    newCmd.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = empLoginID;
                                    newCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = empPassword;
                                    newCmd.Parameters.Add("@EmployeePosition", SqlDbType.NVarChar).Value = empPosition;
                                    newCmd.Parameters.Add("@EmployeeAccessLV", SqlDbType.TinyInt).Value = empAccessLv;
                                    newCmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = empStartDate;
                                    newCmd.Parameters.Add("@Status", SqlDbType.Bit).Value = empStatus;
                                    newCmd.Parameters.Add("@SSN", SqlDbType.NVarChar).Value = empSSN;
                                    newCmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = empDOB;
                                    newCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = empAddress;
                                    newCmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = empCity;
                                    newCmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = empState;
                                    newCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = empZipCode;
                                    newCmd.Parameters.Add("@Phone1", SqlDbType.NVarChar).Value = empPhone1;
                                    newCmd.Parameters.Add("@Phone2", SqlDbType.NVarChar).Value = empPhone2;
                                    newCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = empEmail;
                                    newCmd.Parameters.Add("@EmergencyName", SqlDbType.NVarChar).Value = empEmerName;
                                    newCmd.Parameters.Add("@EmergencyPhone", SqlDbType.NVarChar).Value = empEmerPhone;

                                    newConn.Open();
                                    newCmd.ExecuteNonQuery();
                                    newConn.Close();

                                    MessageBox.Show("SUCCESSFULLY OVERWRITTEN TO OXON HILL", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    return;
                                }
                            }
                        }
                    }
                    else if (scCurrent.ToUpper() == "UM")
                    {
                        if (DBConnectionStatus(parentForm.UMCS_IP) == false)
                        {
                            MessageBox.Show("UPPER MARLBORO DB CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            if (Duplicated_Employee_Check(parentForm.UMCS_IP, empLoginID) == 0)
                            {
                                newConn = new SqlConnection(parentForm.UMCS_IP);
                                newCmd = new SqlCommand("Register_New_Employee", newConn);
                                newCmd.CommandType = CommandType.StoredProcedure;
                                newCmd.Parameters.Clear();
                                newCmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = scCurrent;
                                newCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = empFirstName;
                                newCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = empLastName;
                                newCmd.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = empLoginID;
                                newCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = empPassword;
                                newCmd.Parameters.Add("@EmployeePosition", SqlDbType.NVarChar).Value = empPosition;
                                newCmd.Parameters.Add("@EmployeeAccessLV", SqlDbType.TinyInt).Value = empAccessLv;
                                newCmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = DateTime.Now;
                                newCmd.Parameters.Add("@Status", SqlDbType.Bit).Value = true;
                                newCmd.Parameters.Add("@SSN", SqlDbType.NVarChar).Value = empSSN;
                                newCmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = empDOB;
                                newCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = empAddress;
                                newCmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = empCity;
                                newCmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = empState;
                                newCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = empZipCode;
                                newCmd.Parameters.Add("@Phone1", SqlDbType.NVarChar).Value = empPhone1;
                                newCmd.Parameters.Add("@Phone2", SqlDbType.NVarChar).Value = empPhone2;
                                newCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = empEmail;
                                newCmd.Parameters.Add("@EmergencyName", SqlDbType.NVarChar).Value = empEmerName;
                                newCmd.Parameters.Add("@EmergencyPhone", SqlDbType.NVarChar).Value = empEmerPhone;

                                newConn.Open();
                                newCmd.ExecuteNonQuery();
                                newConn.Close();

                                Employee_Transfer_History(scCurrent, empFirstName, empLastName, empLoginID, DateTime.Today);

                                MessageBox.Show("SUCCESSFULLY TRANSFERRED TO UPPER MARLBORO", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                DialogResult MyDialogResult2;
                                MyDialogResult2 = MessageBox.Show(this, "SELECTED EMPLOYEE INFORMATION IS ALREADY EXIST.\n\n" + "DO YOU WANT TO OVERWRITE EMPLOYEE INFORMATION?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (MyDialogResult2 == DialogResult.Yes)
                                {
                                    newConn = new SqlConnection(parentForm.UMCS_IP);
                                    newCmd = new SqlCommand("Update_Employee2", newConn);
                                    newCmd.CommandType = CommandType.StoredProcedure;
                                    newCmd.Parameters.Clear();
                                    newCmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = scCurrent;
                                    newCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = empFirstName;
                                    newCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = empLastName;
                                    newCmd.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = empLoginID;
                                    newCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = empPassword;
                                    newCmd.Parameters.Add("@EmployeePosition", SqlDbType.NVarChar).Value = empPosition;
                                    newCmd.Parameters.Add("@EmployeeAccessLV", SqlDbType.TinyInt).Value = empAccessLv;
                                    newCmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = empStartDate;
                                    newCmd.Parameters.Add("@Status", SqlDbType.Bit).Value = empStatus;
                                    newCmd.Parameters.Add("@SSN", SqlDbType.NVarChar).Value = empSSN;
                                    newCmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = empDOB;
                                    newCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = empAddress;
                                    newCmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = empCity;
                                    newCmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = empState;
                                    newCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = empZipCode;
                                    newCmd.Parameters.Add("@Phone1", SqlDbType.NVarChar).Value = empPhone1;
                                    newCmd.Parameters.Add("@Phone2", SqlDbType.NVarChar).Value = empPhone2;
                                    newCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = empEmail;
                                    newCmd.Parameters.Add("@EmergencyName", SqlDbType.NVarChar).Value = empEmerName;
                                    newCmd.Parameters.Add("@EmergencyPhone", SqlDbType.NVarChar).Value = empEmerPhone;

                                    newConn.Open();
                                    newCmd.ExecuteNonQuery();
                                    newConn.Close();

                                    MessageBox.Show("SUCCESSFULLY OVERWRITTEN TO UPPER MARLBORO", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    return;
                                }
                            }
                        }
                    }
                    else if (scCurrent.ToUpper() == "CH")
                    {
                        if (DBConnectionStatus(parentForm.CHCS_IP) == false)
                        {
                            MessageBox.Show("CAPITOL HEIGHTS DB CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            if (Duplicated_Employee_Check(parentForm.CHCS_IP, empLoginID) == 0)
                            {
                                newConn = new SqlConnection(parentForm.CHCS_IP);
                                newCmd = new SqlCommand("Register_New_Employee", newConn);
                                newCmd.CommandType = CommandType.StoredProcedure;
                                newCmd.Parameters.Clear();
                                newCmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = scCurrent;
                                newCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = empFirstName;
                                newCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = empLastName;
                                newCmd.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = empLoginID;
                                newCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = empPassword;
                                newCmd.Parameters.Add("@EmployeePosition", SqlDbType.NVarChar).Value = empPosition;
                                newCmd.Parameters.Add("@EmployeeAccessLV", SqlDbType.TinyInt).Value = empAccessLv;
                                newCmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = DateTime.Now;
                                newCmd.Parameters.Add("@Status", SqlDbType.Bit).Value = true;
                                newCmd.Parameters.Add("@SSN", SqlDbType.NVarChar).Value = empSSN;
                                newCmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = empDOB;
                                newCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = empAddress;
                                newCmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = empCity;
                                newCmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = empState;
                                newCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = empZipCode;
                                newCmd.Parameters.Add("@Phone1", SqlDbType.NVarChar).Value = empPhone1;
                                newCmd.Parameters.Add("@Phone2", SqlDbType.NVarChar).Value = empPhone2;
                                newCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = empEmail;
                                newCmd.Parameters.Add("@EmergencyName", SqlDbType.NVarChar).Value = empEmerName;
                                newCmd.Parameters.Add("@EmergencyPhone", SqlDbType.NVarChar).Value = empEmerPhone;

                                newConn.Open();
                                newCmd.ExecuteNonQuery();
                                newConn.Close();

                                Employee_Transfer_History(scCurrent, empFirstName, empLastName, empLoginID, DateTime.Today);

                                MessageBox.Show("SUCCESSFULLY TRANSFERRED TO CAPITOL HEIGHTS", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                DialogResult MyDialogResult2;
                                MyDialogResult2 = MessageBox.Show(this, "SELECTED EMPLOYEE INFORMATION IS ALREADY EXIST.\n\n" + "DO YOU WANT TO OVERWRITE EMPLOYEE INFORMATION?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (MyDialogResult2 == DialogResult.Yes)
                                {
                                    newConn = new SqlConnection(parentForm.CHCS_IP);
                                    newCmd = new SqlCommand("Update_Employee2", newConn);
                                    newCmd.CommandType = CommandType.StoredProcedure;
                                    newCmd.Parameters.Clear();
                                    newCmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = scCurrent;
                                    newCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = empFirstName;
                                    newCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = empLastName;
                                    newCmd.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = empLoginID;
                                    newCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = empPassword;
                                    newCmd.Parameters.Add("@EmployeePosition", SqlDbType.NVarChar).Value = empPosition;
                                    newCmd.Parameters.Add("@EmployeeAccessLV", SqlDbType.TinyInt).Value = empAccessLv;
                                    newCmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = empStartDate;
                                    newCmd.Parameters.Add("@Status", SqlDbType.Bit).Value = empStatus;
                                    newCmd.Parameters.Add("@SSN", SqlDbType.NVarChar).Value = empSSN;
                                    newCmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = empDOB;
                                    newCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = empAddress;
                                    newCmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = empCity;
                                    newCmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = empState;
                                    newCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = empZipCode;
                                    newCmd.Parameters.Add("@Phone1", SqlDbType.NVarChar).Value = empPhone1;
                                    newCmd.Parameters.Add("@Phone2", SqlDbType.NVarChar).Value = empPhone2;
                                    newCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = empEmail;
                                    newCmd.Parameters.Add("@EmergencyName", SqlDbType.NVarChar).Value = empEmerName;
                                    newCmd.Parameters.Add("@EmergencyPhone", SqlDbType.NVarChar).Value = empEmerPhone;

                                    newConn.Open();
                                    newCmd.ExecuteNonQuery();
                                    newConn.Close();

                                    MessageBox.Show("SUCCESSFULLY OVERWRITTEN TO CAPITOL HEIGHTS", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    return;
                                }
                            }
                        }
                    }
                    else if (scCurrent.ToUpper() == "WM")
                    {
                        if (DBConnectionStatus(parentForm.WMCS_IP) == false)
                        {
                            MessageBox.Show("WINDSOR MILL DB CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            if (Duplicated_Employee_Check(parentForm.WMCS_IP, empLoginID) == 0)
                            {
                                newConn = new SqlConnection(parentForm.WMCS_IP);
                                newCmd = new SqlCommand("Register_New_Employee", newConn);
                                newCmd.CommandType = CommandType.StoredProcedure;
                                newCmd.Parameters.Clear();
                                newCmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = scCurrent;
                                newCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = empFirstName;
                                newCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = empLastName;
                                newCmd.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = empLoginID;
                                newCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = empPassword;
                                newCmd.Parameters.Add("@EmployeePosition", SqlDbType.NVarChar).Value = empPosition;
                                newCmd.Parameters.Add("@EmployeeAccessLV", SqlDbType.TinyInt).Value = empAccessLv;
                                newCmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = DateTime.Now;
                                newCmd.Parameters.Add("@Status", SqlDbType.Bit).Value = true;
                                newCmd.Parameters.Add("@SSN", SqlDbType.NVarChar).Value = empSSN;
                                newCmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = empDOB;
                                newCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = empAddress;
                                newCmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = empCity;
                                newCmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = empState;
                                newCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = empZipCode;
                                newCmd.Parameters.Add("@Phone1", SqlDbType.NVarChar).Value = empPhone1;
                                newCmd.Parameters.Add("@Phone2", SqlDbType.NVarChar).Value = empPhone2;
                                newCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = empEmail;
                                newCmd.Parameters.Add("@EmergencyName", SqlDbType.NVarChar).Value = empEmerName;
                                newCmd.Parameters.Add("@EmergencyPhone", SqlDbType.NVarChar).Value = empEmerPhone;

                                newConn.Open();
                                newCmd.ExecuteNonQuery();
                                newConn.Close();

                                Employee_Transfer_History(scCurrent, empFirstName, empLastName, empLoginID, DateTime.Today);

                                MessageBox.Show("SUCCESSFULLY TRANSFERRED TO WINDSOR MILL", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                DialogResult MyDialogResult2;
                                MyDialogResult2 = MessageBox.Show(this, "SELECTED EMPLOYEE INFORMATION IS ALREADY EXIST.\n\n" + "DO YOU WANT TO OVERWRITE EMPLOYEE INFORMATION?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (MyDialogResult2 == DialogResult.Yes)
                                {
                                    newConn = new SqlConnection(parentForm.WMCS_IP);
                                    newCmd = new SqlCommand("Update_Employee2", newConn);
                                    newCmd.CommandType = CommandType.StoredProcedure;
                                    newCmd.Parameters.Clear();
                                    newCmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = scCurrent;
                                    newCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = empFirstName;
                                    newCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = empLastName;
                                    newCmd.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = empLoginID;
                                    newCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = empPassword;
                                    newCmd.Parameters.Add("@EmployeePosition", SqlDbType.NVarChar).Value = empPosition;
                                    newCmd.Parameters.Add("@EmployeeAccessLV", SqlDbType.TinyInt).Value = empAccessLv;
                                    newCmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = empStartDate;
                                    newCmd.Parameters.Add("@Status", SqlDbType.Bit).Value = empStatus;
                                    newCmd.Parameters.Add("@SSN", SqlDbType.NVarChar).Value = empSSN;
                                    newCmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = empDOB;
                                    newCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = empAddress;
                                    newCmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = empCity;
                                    newCmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = empState;
                                    newCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = empZipCode;
                                    newCmd.Parameters.Add("@Phone1", SqlDbType.NVarChar).Value = empPhone1;
                                    newCmd.Parameters.Add("@Phone2", SqlDbType.NVarChar).Value = empPhone2;
                                    newCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = empEmail;
                                    newCmd.Parameters.Add("@EmergencyName", SqlDbType.NVarChar).Value = empEmerName;
                                    newCmd.Parameters.Add("@EmergencyPhone", SqlDbType.NVarChar).Value = empEmerPhone;

                                    newConn.Open();
                                    newCmd.ExecuteNonQuery();
                                    newConn.Close();

                                    MessageBox.Show("SUCCESSFULLY OVERWRITTEN TO WINDSOR MILL", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    return;
                                }
                            }
                        }
                    }
                    else if (scCurrent.ToUpper() == "CV")
                    {
                        if (DBConnectionStatus(parentForm.CVCS_IP) == false)
                        {
                            MessageBox.Show("CATONSVILLE DB CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            if (Duplicated_Employee_Check(parentForm.CVCS_IP, empLoginID) == 0)
                            {
                                newConn = new SqlConnection(parentForm.CVCS_IP);
                                newCmd = new SqlCommand("Register_New_Employee", newConn);
                                newCmd.CommandType = CommandType.StoredProcedure;
                                newCmd.Parameters.Clear();
                                newCmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = scCurrent;
                                newCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = empFirstName;
                                newCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = empLastName;
                                newCmd.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = empLoginID;
                                newCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = empPassword;
                                newCmd.Parameters.Add("@EmployeePosition", SqlDbType.NVarChar).Value = empPosition;
                                newCmd.Parameters.Add("@EmployeeAccessLV", SqlDbType.TinyInt).Value = empAccessLv;
                                newCmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = DateTime.Now;
                                newCmd.Parameters.Add("@Status", SqlDbType.Bit).Value = true;
                                newCmd.Parameters.Add("@SSN", SqlDbType.NVarChar).Value = empSSN;
                                newCmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = empDOB;
                                newCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = empAddress;
                                newCmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = empCity;
                                newCmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = empState;
                                newCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = empZipCode;
                                newCmd.Parameters.Add("@Phone1", SqlDbType.NVarChar).Value = empPhone1;
                                newCmd.Parameters.Add("@Phone2", SqlDbType.NVarChar).Value = empPhone2;
                                newCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = empEmail;
                                newCmd.Parameters.Add("@EmergencyName", SqlDbType.NVarChar).Value = empEmerName;
                                newCmd.Parameters.Add("@EmergencyPhone", SqlDbType.NVarChar).Value = empEmerPhone;

                                newConn.Open();
                                newCmd.ExecuteNonQuery();
                                newConn.Close();

                                Employee_Transfer_History(scCurrent, empFirstName, empLastName, empLoginID, DateTime.Today);

                                MessageBox.Show("SUCCESSFULLY TRANSFERRED TO CATONSVILLE", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                DialogResult MyDialogResult2;
                                MyDialogResult2 = MessageBox.Show(this, "SELECTED EMPLOYEE INFORMATION IS ALREADY EXIST.\n\n" + "DO YOU WANT TO OVERWRITE EMPLOYEE INFORMATION?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (MyDialogResult2 == DialogResult.Yes)
                                {
                                    newConn = new SqlConnection(parentForm.CVCS_IP);
                                    newCmd = new SqlCommand("Update_Employee2", newConn);
                                    newCmd.CommandType = CommandType.StoredProcedure;
                                    newCmd.Parameters.Clear();
                                    newCmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = scCurrent;
                                    newCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = empFirstName;
                                    newCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = empLastName;
                                    newCmd.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = empLoginID;
                                    newCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = empPassword;
                                    newCmd.Parameters.Add("@EmployeePosition", SqlDbType.NVarChar).Value = empPosition;
                                    newCmd.Parameters.Add("@EmployeeAccessLV", SqlDbType.TinyInt).Value = empAccessLv;
                                    newCmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = empStartDate;
                                    newCmd.Parameters.Add("@Status", SqlDbType.Bit).Value = empStatus;
                                    newCmd.Parameters.Add("@SSN", SqlDbType.NVarChar).Value = empSSN;
                                    newCmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = empDOB;
                                    newCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = empAddress;
                                    newCmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = empCity;
                                    newCmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = empState;
                                    newCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = empZipCode;
                                    newCmd.Parameters.Add("@Phone1", SqlDbType.NVarChar).Value = empPhone1;
                                    newCmd.Parameters.Add("@Phone2", SqlDbType.NVarChar).Value = empPhone2;
                                    newCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = empEmail;
                                    newCmd.Parameters.Add("@EmergencyName", SqlDbType.NVarChar).Value = empEmerName;
                                    newCmd.Parameters.Add("@EmergencyPhone", SqlDbType.NVarChar).Value = empEmerPhone;

                                    newConn.Open();
                                    newCmd.ExecuteNonQuery();
                                    newConn.Close();

                                    MessageBox.Show("SUCCESSFULLY OVERWRITTEN TO CATONSVILLE", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    return;
                                }
                            }
                        }
                    }
                    else if (scCurrent.ToUpper() == "PW")
                    {
                        if (DBConnectionStatus(parentForm.PWCS_IP) == false)
                        {
                            MessageBox.Show("PRINCE WILLIAM DB CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            if (Duplicated_Employee_Check(parentForm.PWCS_IP, empLoginID) == 0)
                            {
                                newConn = new SqlConnection(parentForm.PWCS_IP);
                                newCmd = new SqlCommand("Register_New_Employee", newConn);
                                newCmd.CommandType = CommandType.StoredProcedure;
                                newCmd.Parameters.Clear();
                                newCmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = scCurrent;
                                newCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = empFirstName;
                                newCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = empLastName;
                                newCmd.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = empLoginID;
                                newCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = empPassword;
                                newCmd.Parameters.Add("@EmployeePosition", SqlDbType.NVarChar).Value = empPosition;
                                newCmd.Parameters.Add("@EmployeeAccessLV", SqlDbType.TinyInt).Value = empAccessLv;
                                newCmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = DateTime.Now;
                                newCmd.Parameters.Add("@Status", SqlDbType.Bit).Value = true;
                                newCmd.Parameters.Add("@SSN", SqlDbType.NVarChar).Value = empSSN;
                                newCmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = empDOB;
                                newCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = empAddress;
                                newCmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = empCity;
                                newCmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = empState;
                                newCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = empZipCode;
                                newCmd.Parameters.Add("@Phone1", SqlDbType.NVarChar).Value = empPhone1;
                                newCmd.Parameters.Add("@Phone2", SqlDbType.NVarChar).Value = empPhone2;
                                newCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = empEmail;
                                newCmd.Parameters.Add("@EmergencyName", SqlDbType.NVarChar).Value = empEmerName;
                                newCmd.Parameters.Add("@EmergencyPhone", SqlDbType.NVarChar).Value = empEmerPhone;

                                newConn.Open();
                                newCmd.ExecuteNonQuery();
                                newConn.Close();

                                Employee_Transfer_History(scCurrent, empFirstName, empLastName, empLoginID, DateTime.Today);

                                MessageBox.Show("SUCCESSFULLY TRANSFERRED TO PRINCE WILLIAM", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                DialogResult MyDialogResult2;
                                MyDialogResult2 = MessageBox.Show(this, "SELECTED EMPLOYEE INFORMATION IS ALREADY EXIST.\n\n" + "DO YOU WANT TO OVERWRITE EMPLOYEE INFORMATION?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (MyDialogResult2 == DialogResult.Yes)
                                {
                                    newConn = new SqlConnection(parentForm.PWCS_IP);
                                    newCmd = new SqlCommand("Update_Employee2", newConn);
                                    newCmd.CommandType = CommandType.StoredProcedure;
                                    newCmd.Parameters.Clear();
                                    newCmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = scCurrent;
                                    newCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = empFirstName;
                                    newCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = empLastName;
                                    newCmd.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = empLoginID;
                                    newCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = empPassword;
                                    newCmd.Parameters.Add("@EmployeePosition", SqlDbType.NVarChar).Value = empPosition;
                                    newCmd.Parameters.Add("@EmployeeAccessLV", SqlDbType.TinyInt).Value = empAccessLv;
                                    newCmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = empStartDate;
                                    newCmd.Parameters.Add("@Status", SqlDbType.Bit).Value = empStatus;
                                    newCmd.Parameters.Add("@SSN", SqlDbType.NVarChar).Value = empSSN;
                                    newCmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = empDOB;
                                    newCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = empAddress;
                                    newCmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = empCity;
                                    newCmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = empState;
                                    newCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = empZipCode;
                                    newCmd.Parameters.Add("@Phone1", SqlDbType.NVarChar).Value = empPhone1;
                                    newCmd.Parameters.Add("@Phone2", SqlDbType.NVarChar).Value = empPhone2;
                                    newCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = empEmail;
                                    newCmd.Parameters.Add("@EmergencyName", SqlDbType.NVarChar).Value = empEmerName;
                                    newCmd.Parameters.Add("@EmergencyPhone", SqlDbType.NVarChar).Value = empEmerPhone;

                                    newConn.Open();
                                    newCmd.ExecuteNonQuery();
                                    newConn.Close();

                                    MessageBox.Show("SUCCESSFULLY OVERWRITTEN TO PRINCE WILLIAM", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    return;
                                }
                            }
                        }
                    }
                    else if (scCurrent.ToUpper() == "WB")
                    {
                        if (DBConnectionStatus(parentForm.WBCS_IP) == false)
                        {
                            MessageBox.Show("WOODBRIDGE DB CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            if (Duplicated_Employee_Check(parentForm.WBCS_IP, empLoginID) == 0)
                            {
                                newConn = new SqlConnection(parentForm.WBCS_IP);
                                newCmd = new SqlCommand("Register_New_Employee", newConn);
                                newCmd.CommandType = CommandType.StoredProcedure;
                                newCmd.Parameters.Clear();
                                newCmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = scCurrent;
                                newCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = empFirstName;
                                newCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = empLastName;
                                newCmd.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = empLoginID;
                                newCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = empPassword;
                                newCmd.Parameters.Add("@EmployeePosition", SqlDbType.NVarChar).Value = empPosition;
                                newCmd.Parameters.Add("@EmployeeAccessLV", SqlDbType.TinyInt).Value = empAccessLv;
                                newCmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = DateTime.Now;
                                newCmd.Parameters.Add("@Status", SqlDbType.Bit).Value = true;
                                newCmd.Parameters.Add("@SSN", SqlDbType.NVarChar).Value = empSSN;
                                newCmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = empDOB;
                                newCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = empAddress;
                                newCmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = empCity;
                                newCmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = empState;
                                newCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = empZipCode;
                                newCmd.Parameters.Add("@Phone1", SqlDbType.NVarChar).Value = empPhone1;
                                newCmd.Parameters.Add("@Phone2", SqlDbType.NVarChar).Value = empPhone2;
                                newCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = empEmail;
                                newCmd.Parameters.Add("@EmergencyName", SqlDbType.NVarChar).Value = empEmerName;
                                newCmd.Parameters.Add("@EmergencyPhone", SqlDbType.NVarChar).Value = empEmerPhone;

                                newConn.Open();
                                newCmd.ExecuteNonQuery();
                                newConn.Close();

                                Employee_Transfer_History(scCurrent, empFirstName, empLastName, empLoginID, DateTime.Today);

                                MessageBox.Show("SUCCESSFULLY TRANSFERRED TO WOODBRIDGE", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                DialogResult MyDialogResult2;
                                MyDialogResult2 = MessageBox.Show(this, "SELECTED EMPLOYEE INFORMATION IS ALREADY EXIST.\n\n" + "DO YOU WANT TO OVERWRITE EMPLOYEE INFORMATION?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (MyDialogResult2 == DialogResult.Yes)
                                {
                                    newConn = new SqlConnection(parentForm.WBCS_IP);
                                    newCmd = new SqlCommand("Update_Employee2", newConn);
                                    newCmd.CommandType = CommandType.StoredProcedure;
                                    newCmd.Parameters.Clear();
                                    newCmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = scCurrent;
                                    newCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = empFirstName;
                                    newCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = empLastName;
                                    newCmd.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = empLoginID;
                                    newCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = empPassword;
                                    newCmd.Parameters.Add("@EmployeePosition", SqlDbType.NVarChar).Value = empPosition;
                                    newCmd.Parameters.Add("@EmployeeAccessLV", SqlDbType.TinyInt).Value = empAccessLv;
                                    newCmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = empStartDate;
                                    newCmd.Parameters.Add("@Status", SqlDbType.Bit).Value = empStatus;
                                    newCmd.Parameters.Add("@SSN", SqlDbType.NVarChar).Value = empSSN;
                                    newCmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = empDOB;
                                    newCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = empAddress;
                                    newCmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = empCity;
                                    newCmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = empState;
                                    newCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = empZipCode;
                                    newCmd.Parameters.Add("@Phone1", SqlDbType.NVarChar).Value = empPhone1;
                                    newCmd.Parameters.Add("@Phone2", SqlDbType.NVarChar).Value = empPhone2;
                                    newCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = empEmail;
                                    newCmd.Parameters.Add("@EmergencyName", SqlDbType.NVarChar).Value = empEmerName;
                                    newCmd.Parameters.Add("@EmergencyPhone", SqlDbType.NVarChar).Value = empEmerPhone;

                                    newConn.Open();
                                    newCmd.ExecuteNonQuery();
                                    newConn.Close();

                                    MessageBox.Show("SUCCESSFULLY OVERWRITTEN TO WOODBRIDGE", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    return;
                                }
                            }
                        }
                    }
                    else if (scCurrent.ToUpper() == "WD")
                    {
                        if (DBConnectionStatus(parentForm.WDCS_IP) == false)
                        {
                            MessageBox.Show("WALDORF DB CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            if (Duplicated_Employee_Check(parentForm.WDCS_IP, empLoginID) == 0)
                            {
                                newConn = new SqlConnection(parentForm.WDCS_IP);
                                newCmd = new SqlCommand("Register_New_Employee", newConn);
                                newCmd.CommandType = CommandType.StoredProcedure;
                                newCmd.Parameters.Clear();
                                newCmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = scCurrent;
                                newCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = empFirstName;
                                newCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = empLastName;
                                newCmd.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = empLoginID;
                                newCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = empPassword;
                                newCmd.Parameters.Add("@EmployeePosition", SqlDbType.NVarChar).Value = empPosition;
                                newCmd.Parameters.Add("@EmployeeAccessLV", SqlDbType.TinyInt).Value = empAccessLv;
                                newCmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = DateTime.Now;
                                newCmd.Parameters.Add("@Status", SqlDbType.Bit).Value = true;
                                newCmd.Parameters.Add("@SSN", SqlDbType.NVarChar).Value = empSSN;
                                newCmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = empDOB;
                                newCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = empAddress;
                                newCmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = empCity;
                                newCmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = empState;
                                newCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = empZipCode;
                                newCmd.Parameters.Add("@Phone1", SqlDbType.NVarChar).Value = empPhone1;
                                newCmd.Parameters.Add("@Phone2", SqlDbType.NVarChar).Value = empPhone2;
                                newCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = empEmail;
                                newCmd.Parameters.Add("@EmergencyName", SqlDbType.NVarChar).Value = empEmerName;
                                newCmd.Parameters.Add("@EmergencyPhone", SqlDbType.NVarChar).Value = empEmerPhone;

                                newConn.Open();
                                newCmd.ExecuteNonQuery();
                                newConn.Close();

                                Employee_Transfer_History(scCurrent, empFirstName, empLastName, empLoginID, DateTime.Today);

                                MessageBox.Show("SUCCESSFULLY TRANSFERRED TO WALDORF", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                DialogResult MyDialogResult2;
                                MyDialogResult2 = MessageBox.Show(this, "SELECTED EMPLOYEE INFORMATION IS ALREADY EXIST.\n\n" + "DO YOU WANT TO OVERWRITE EMPLOYEE INFORMATION?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (MyDialogResult2 == DialogResult.Yes)
                                {
                                    newConn = new SqlConnection(parentForm.WDCS_IP);
                                    newCmd = new SqlCommand("Update_Employee2", newConn);
                                    newCmd.CommandType = CommandType.StoredProcedure;
                                    newCmd.Parameters.Clear();
                                    newCmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = scCurrent;
                                    newCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = empFirstName;
                                    newCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = empLastName;
                                    newCmd.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = empLoginID;
                                    newCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = empPassword;
                                    newCmd.Parameters.Add("@EmployeePosition", SqlDbType.NVarChar).Value = empPosition;
                                    newCmd.Parameters.Add("@EmployeeAccessLV", SqlDbType.TinyInt).Value = empAccessLv;
                                    newCmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = empStartDate;
                                    newCmd.Parameters.Add("@Status", SqlDbType.Bit).Value = empStatus;
                                    newCmd.Parameters.Add("@SSN", SqlDbType.NVarChar).Value = empSSN;
                                    newCmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = empDOB;
                                    newCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = empAddress;
                                    newCmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = empCity;
                                    newCmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = empState;
                                    newCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = empZipCode;
                                    newCmd.Parameters.Add("@Phone1", SqlDbType.NVarChar).Value = empPhone1;
                                    newCmd.Parameters.Add("@Phone2", SqlDbType.NVarChar).Value = empPhone2;
                                    newCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = empEmail;
                                    newCmd.Parameters.Add("@EmergencyName", SqlDbType.NVarChar).Value = empEmerName;
                                    newCmd.Parameters.Add("@EmergencyPhone", SqlDbType.NVarChar).Value = empEmerPhone;

                                    newConn.Open();
                                    newCmd.ExecuteNonQuery();
                                    newConn.Close();

                                    MessageBox.Show("SUCCESSFULLY OVERWRITTEN TO WALDORF", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    return;
                                }
                            }
                        }
                    }
                    else if (scCurrent.ToUpper() == "GB")
                    {
                        if (DBConnectionStatus(parentForm.GBCS_IP) == false)
                        {
                            MessageBox.Show("GAITHERSBURG DB CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            if (Duplicated_Employee_Check(parentForm.GBCS_IP, empLoginID) == 0)
                            {
                                newConn = new SqlConnection(parentForm.GBCS_IP);
                                newCmd = new SqlCommand("Register_New_Employee", newConn);
                                newCmd.CommandType = CommandType.StoredProcedure;
                                newCmd.Parameters.Clear();
                                newCmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = scCurrent;
                                newCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = empFirstName;
                                newCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = empLastName;
                                newCmd.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = empLoginID;
                                newCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = empPassword;
                                newCmd.Parameters.Add("@EmployeePosition", SqlDbType.NVarChar).Value = empPosition;
                                newCmd.Parameters.Add("@EmployeeAccessLV", SqlDbType.TinyInt).Value = empAccessLv;
                                newCmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = DateTime.Now;
                                newCmd.Parameters.Add("@Status", SqlDbType.Bit).Value = true;
                                newCmd.Parameters.Add("@SSN", SqlDbType.NVarChar).Value = empSSN;
                                newCmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = empDOB;
                                newCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = empAddress;
                                newCmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = empCity;
                                newCmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = empState;
                                newCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = empZipCode;
                                newCmd.Parameters.Add("@Phone1", SqlDbType.NVarChar).Value = empPhone1;
                                newCmd.Parameters.Add("@Phone2", SqlDbType.NVarChar).Value = empPhone2;
                                newCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = empEmail;
                                newCmd.Parameters.Add("@EmergencyName", SqlDbType.NVarChar).Value = empEmerName;
                                newCmd.Parameters.Add("@EmergencyPhone", SqlDbType.NVarChar).Value = empEmerPhone;

                                newConn.Open();
                                newCmd.ExecuteNonQuery();
                                newConn.Close();

                                Employee_Transfer_History(scCurrent, empFirstName, empLastName, empLoginID, DateTime.Today);

                                MessageBox.Show("SUCCESSFULLY TRANSFERRED TO GAITHERSBURG", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                DialogResult MyDialogResult2;
                                MyDialogResult2 = MessageBox.Show(this, "SELECTED EMPLOYEE INFORMATION IS ALREADY EXIST.\n\n" + "DO YOU WANT TO OVERWRITE EMPLOYEE INFORMATION?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (MyDialogResult2 == DialogResult.Yes)
                                {
                                    newConn = new SqlConnection(parentForm.GBCS_IP);
                                    newCmd = new SqlCommand("Update_Employee2", newConn);
                                    newCmd.CommandType = CommandType.StoredProcedure;
                                    newCmd.Parameters.Clear();
                                    newCmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = scCurrent;
                                    newCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = empFirstName;
                                    newCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = empLastName;
                                    newCmd.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = empLoginID;
                                    newCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = empPassword;
                                    newCmd.Parameters.Add("@EmployeePosition", SqlDbType.NVarChar).Value = empPosition;
                                    newCmd.Parameters.Add("@EmployeeAccessLV", SqlDbType.TinyInt).Value = empAccessLv;
                                    newCmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = empStartDate;
                                    newCmd.Parameters.Add("@Status", SqlDbType.Bit).Value = empStatus;
                                    newCmd.Parameters.Add("@SSN", SqlDbType.NVarChar).Value = empSSN;
                                    newCmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = empDOB;
                                    newCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = empAddress;
                                    newCmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = empCity;
                                    newCmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = empState;
                                    newCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = empZipCode;
                                    newCmd.Parameters.Add("@Phone1", SqlDbType.NVarChar).Value = empPhone1;
                                    newCmd.Parameters.Add("@Phone2", SqlDbType.NVarChar).Value = empPhone2;
                                    newCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = empEmail;
                                    newCmd.Parameters.Add("@EmergencyName", SqlDbType.NVarChar).Value = empEmerName;
                                    newCmd.Parameters.Add("@EmergencyPhone", SqlDbType.NVarChar).Value = empEmerPhone;

                                    newConn.Open();
                                    newCmd.ExecuteNonQuery();
                                    newConn.Close();

                                    MessageBox.Show("SUCCESSFULLY OVERWRITTEN TO GAITHERSBURG", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    return;
                                }
                            }
                        }
                    }
                    else if (scCurrent.ToUpper() == "BW")
                    {
                        if (DBConnectionStatus(parentForm.BWCS_IP) == false)
                        {
                            MessageBox.Show("BOWIE DB CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            if (Duplicated_Employee_Check(parentForm.BWCS_IP, empLoginID) == 0)
                            {
                                newConn = new SqlConnection(parentForm.BWCS_IP);
                                newCmd = new SqlCommand("Register_New_Employee", newConn);
                                newCmd.CommandType = CommandType.StoredProcedure;
                                newCmd.Parameters.Clear();
                                newCmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = scCurrent;
                                newCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = empFirstName;
                                newCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = empLastName;
                                newCmd.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = empLoginID;
                                newCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = empPassword;
                                newCmd.Parameters.Add("@EmployeePosition", SqlDbType.NVarChar).Value = empPosition;
                                newCmd.Parameters.Add("@EmployeeAccessLV", SqlDbType.TinyInt).Value = empAccessLv;
                                newCmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = DateTime.Now;
                                newCmd.Parameters.Add("@Status", SqlDbType.Bit).Value = true;
                                newCmd.Parameters.Add("@SSN", SqlDbType.NVarChar).Value = empSSN;
                                newCmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = empDOB;
                                newCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = empAddress;
                                newCmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = empCity;
                                newCmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = empState;
                                newCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = empZipCode;
                                newCmd.Parameters.Add("@Phone1", SqlDbType.NVarChar).Value = empPhone1;
                                newCmd.Parameters.Add("@Phone2", SqlDbType.NVarChar).Value = empPhone2;
                                newCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = empEmail;
                                newCmd.Parameters.Add("@EmergencyName", SqlDbType.NVarChar).Value = empEmerName;
                                newCmd.Parameters.Add("@EmergencyPhone", SqlDbType.NVarChar).Value = empEmerPhone;

                                newConn.Open();
                                newCmd.ExecuteNonQuery();
                                newConn.Close();

                                Employee_Transfer_History(scCurrent, empFirstName, empLastName, empLoginID, DateTime.Today);

                                MessageBox.Show("SUCCESSFULLY TRANSFERRED TO BOWIE", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                DialogResult MyDialogResult2;
                                MyDialogResult2 = MessageBox.Show(this, "SELECTED EMPLOYEE INFORMATION IS ALREADY EXIST.\n\n" + "DO YOU WANT TO OVERWRITE EMPLOYEE INFORMATION?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (MyDialogResult2 == DialogResult.Yes)
                                {
                                    newConn = new SqlConnection(parentForm.BWCS_IP);
                                    newCmd = new SqlCommand("Update_Employee2", newConn);
                                    newCmd.CommandType = CommandType.StoredProcedure;
                                    newCmd.Parameters.Clear();
                                    newCmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = scCurrent;
                                    newCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = empFirstName;
                                    newCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = empLastName;
                                    newCmd.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = empLoginID;
                                    newCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = empPassword;
                                    newCmd.Parameters.Add("@EmployeePosition", SqlDbType.NVarChar).Value = empPosition;
                                    newCmd.Parameters.Add("@EmployeeAccessLV", SqlDbType.TinyInt).Value = empAccessLv;
                                    newCmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = empStartDate;
                                    newCmd.Parameters.Add("@Status", SqlDbType.Bit).Value = empStatus;
                                    newCmd.Parameters.Add("@SSN", SqlDbType.NVarChar).Value = empSSN;
                                    newCmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = empDOB;
                                    newCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = empAddress;
                                    newCmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = empCity;
                                    newCmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = empState;
                                    newCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = empZipCode;
                                    newCmd.Parameters.Add("@Phone1", SqlDbType.NVarChar).Value = empPhone1;
                                    newCmd.Parameters.Add("@Phone2", SqlDbType.NVarChar).Value = empPhone2;
                                    newCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = empEmail;
                                    newCmd.Parameters.Add("@EmergencyName", SqlDbType.NVarChar).Value = empEmerName;
                                    newCmd.Parameters.Add("@EmergencyPhone", SqlDbType.NVarChar).Value = empEmerPhone;

                                    newConn.Open();
                                    newCmd.ExecuteNonQuery();
                                    newConn.Close();

                                    MessageBox.Show("SUCCESSFULLY OVERWRITTEN TO BOWIE", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        private static bool DBConnectionStatus(string CS)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(CS))
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

        private int Duplicated_Employee_Check(string cs, string ID)
        {
            SqlConnection connection = new SqlConnection(cs);
            SqlCommand cmd_CheckUser = new SqlCommand("Check_Employee", connection);
            cmd_CheckUser.CommandType = CommandType.StoredProcedure;
            cmd_CheckUser.Parameters.Add("@LoginIDIn", SqlDbType.NVarChar).Value = ID;
            SqlParameter CheckUser_Param = cmd_CheckUser.Parameters.Add("@LoginIDOut", SqlDbType.NVarChar, 15);
            CheckUser_Param.Direction = ParameterDirection.Output;

            connection.Open();
            cmd_CheckUser.ExecuteNonQuery();
            connection.Close();

            if (cmd_CheckUser.Parameters["@LoginIDOut"].Value == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        private void Employee_Transfer_History(string sc, string fname, string lname, string ID, DateTime sdate)
        {
            SqlCommand cmd_ETH = new SqlCommand("Create_Employee_Transfer_History", parentForm.conn);
            cmd_ETH.CommandType = CommandType.StoredProcedure;
            cmd_ETH.Parameters.Clear();
            cmd_ETH.Parameters.Add("@ETHStoreCode", SqlDbType.NVarChar).Value = sc;
            cmd_ETH.Parameters.Add("@ETHFirstName", SqlDbType.NVarChar).Value = fname;
            cmd_ETH.Parameters.Add("@ETHLastName", SqlDbType.NVarChar).Value = lname;
            cmd_ETH.Parameters.Add("@ETHLoginID", SqlDbType.NVarChar).Value = ID;
            cmd_ETH.Parameters.Add("@ETHStartDate", SqlDbType.DateTime).Value = sdate;
            cmd_ETH.Parameters.Add("@ETHUpdateID", SqlDbType.NVarChar).Value = parentForm.employeeID.ToUpper();

            parentForm.conn.Open();
            cmd_ETH.ExecuteNonQuery();
            parentForm.conn.Close();
        }
    }
}