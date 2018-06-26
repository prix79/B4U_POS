using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Management
{
    public partial class SubmitReturnReport : Form
    {
        public LogInManagements parentForm1;
        public POandReceiving parentForm2;
        public ItemSoldListForReturn parentForm3;

        //SqlConnection conn;
        SqlCommand cmd;

        Int64 RRID;
        string trackingNumber1, trackingNumber2, trackingNumber3, trackingNumber4, trackingNumber5;
        string totalTrackingNumber;
        string shippingDate;
        int T1Num=0; 
        int T2Num=0;
        int T3Num=0; 
        int T4Num=0; 
        int T5Num=0; 
        int totalTNum=0;

        int checkNum = 0;
        int idx = 0;

        public SubmitReturnReport(Int64 RID)
        {
            InitializeComponent();
            RRID = RID;
        }

        private void SubmitReturnReport_Load(object sender, EventArgs e)
        {
            this.Text = "SUBMIT RETURN REPORT - " + parentForm1.employeeID.ToUpper() + " LOGGED IN " + parentForm1.storeName.ToUpper();
            richTxtSendingDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            totalTrackingNumber = string.Empty;
            totalTNum = 0;

            if (chkTrackingNumber1.Checked == true)
            {
                if (txtTrackingNumber1.Text.Trim() == "")
                {
                    MessageBox.Show("INPUT TRACKING NUMBER 1", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    trackingNumber1 = txtTrackingNumber1.Text.Trim();
                    T1Num = 1;
                }
            }

            if (chkTrackingNumber2.Checked == true)
            {
                if (txtTrackingNumber2.Text.Trim() == "")
                {
                    MessageBox.Show("INPUT TRACKING NUMBER 2", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    trackingNumber2 = txtTrackingNumber2.Text.Trim();
                    T2Num = 2;
                }
            }

            if (chkTrackingNumber3.Checked == true)
            {
                if (txtTrackingNumber3.Text.Trim() == "")
                {
                    MessageBox.Show("INPUT TRACKING NUMBER 3", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    trackingNumber3 = txtTrackingNumber3.Text.Trim();
                    T3Num = 4;
                }
            }

            if (chkTrackingNumber4.Checked == true)
            {
                if (txtTrackingNumber4.Text.Trim() == "")
                {
                    MessageBox.Show("INPUT TRACKING NUMBER 4", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    trackingNumber4 = txtTrackingNumber4.Text.Trim();
                    T4Num = 8;
                }
            }

            if (chkTrackingNumber5.Checked == true)
            {
                if (txtTrackingNumber5.Text.Trim() == "")
                {
                    MessageBox.Show("INPUT TRACKING NUMBER 5", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    trackingNumber5 = txtTrackingNumber5.Text.Trim();
                    T5Num = 16;
                }
            }

            if (richTxtSendingDate.Text.Trim().Length == 10)
            {
                if (ValidateDate(richTxtSendingDate.Text.Trim()) == true)
                {
                }
                else
                {
                    MessageBox.Show("INPUT VALID DATE (MM/DD/YYYY)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    richTxtSendingDate.SelectAll();
                    richTxtSendingDate.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("INPUT VALID DATE (MM/DD/YYYY)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                richTxtSendingDate.SelectAll();
                richTxtSendingDate.Focus();
                return;
            }

            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
            {
                totalTNum = T1Num + T2Num + T3Num + T4Num + T5Num;

                switch (totalTNum)
                {
                    case 1:
                        totalTrackingNumber = trackingNumber1;
                        break;
                    case 3:
                        totalTrackingNumber = trackingNumber1 + ", " + trackingNumber2;
                        break;
                    case 5:
                        totalTrackingNumber = trackingNumber1 + ", " + trackingNumber3;
                        break;
                    case 7:
                        totalTrackingNumber = trackingNumber1 + ", " + trackingNumber2 + ", " + trackingNumber3;
                        break;
                    case 9:
                        totalTrackingNumber = trackingNumber1 + ", " + trackingNumber4;
                        break;
                    case 11:
                        totalTrackingNumber = trackingNumber1 + ", " + trackingNumber2 + ", " + trackingNumber4;
                        break;
                    case 13:
                        totalTrackingNumber = trackingNumber1 + ", " + trackingNumber3 + ", " + trackingNumber4;
                        break;
                    case 15:
                        totalTrackingNumber = trackingNumber1 + ", " + trackingNumber2 + ", " + trackingNumber3 + ", " + trackingNumber4;
                        break;
                    case 17:
                        totalTrackingNumber = trackingNumber1 + ", " + trackingNumber5;
                        break;
                    case 19:
                        totalTrackingNumber = trackingNumber1 + ", " + trackingNumber2 + ", " + trackingNumber5;
                        break;
                    case 21:
                        totalTrackingNumber = trackingNumber1 + ", " + trackingNumber3 + ", " + trackingNumber5;
                        break;
                    case 23:
                        totalTrackingNumber = trackingNumber1 + ", " + trackingNumber2 + ", " + trackingNumber3 + ", " + trackingNumber5;
                        break;
                    case 25:
                        totalTrackingNumber = trackingNumber1 + ", " + trackingNumber4 + ", " + trackingNumber5;
                        break;
                    case 27:
                        totalTrackingNumber = trackingNumber1 + ", " + trackingNumber2 + ", " + trackingNumber4 + ", " + trackingNumber5;
                        break;
                    case 29:
                        totalTrackingNumber = trackingNumber1 + ", " + trackingNumber3 + ", " + trackingNumber4 + ", " + trackingNumber5;
                        break;
                    case 31:
                        totalTrackingNumber = trackingNumber1 + ", " + trackingNumber2 + ", " + trackingNumber3 + ", " + trackingNumber4 + ", " + trackingNumber5;
                        break;
                    default:
                        totalTrackingNumber = "ERROR";
                        break;
                }

                for (int i = 0; i < parentForm3.dataGridView2.RowCount; i++)
                {
                    checkNum = CheckDuplicatedUpc(parentForm3.dataGridView2.Rows[i].Cells[5].Value.ToString());

                    if (checkNum == 0)
                    {
                        MessageBox.Show("COULD NOT FOUND " + Convert.ToString(parentForm3.dataGridView2.Rows[i].Cells[5].Value) + " (ROW " + Convert.ToString(i + 1) + ") IN THE INVENTORY", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        checkNum = 0;
                        return;
                    }
                    else if (checkNum > 1)
                    {
                        MessageBox.Show(Convert.ToString(parentForm3.dataGridView2.Rows[i].Cells[5].Value) + " (ROW " + Convert.ToString(i + 1) + ") IS DUPLICATED UPC", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                progressBar1.Maximum = parentForm3.dataGridView2.RowCount;
                progressBar1.Step = 1;

                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkTrackingNumber1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTrackingNumber1.Checked == true)
            {
                txtTrackingNumber1.Enabled = true;
            }
            else
            {
                MessageBox.Show("YOU CAN NOT CHAGE THE CHECKING OPTION OF TRACKING NUMBER 1.\n\n THIS IS THE DEFAULT OPTION.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                chkTrackingNumber1.Checked = true;
            }
        }

        private void chkTrackingNumber2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTrackingNumber2.Checked == true)
            {
                txtTrackingNumber2.Enabled = true;
            }
            else
            {
                txtTrackingNumber2.Enabled = false;
            }
        }

        private void chkTrackingNumber3_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTrackingNumber3.Checked == true)
            {
                txtTrackingNumber3.Enabled = true;
            }
            else
            {
                txtTrackingNumber3.Enabled = false;
            }
        }

        private void chkTrackingNumber4_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTrackingNumber4.Checked == true)
            {
                txtTrackingNumber4.Enabled = true;
            }
            else
            {
                txtTrackingNumber4.Enabled = false;
            }
        }

        private void chkTrackingNumber5_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTrackingNumber5.Checked == true)
            {
                txtTrackingNumber5.Enabled = true;
            }
            else
            {
                txtTrackingNumber5.Enabled = false;
            }
        }

        private void richTxtSendingDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            richTxtSendingDate.Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(monthCalendar1.SelectionStart));
            monthCalendar1.Visible = false;
        }

        private bool ValidateDate(string date)
        {
            bool valid = false;
            //DateTime testDate = DateTime.MinValue;
            //DateTime minDateTime = DateTime.MaxValue;
            //DateTime maxDateTime = DateTime.MinValue;

            DateTime testDate;
            DateTime minDateTime;
            DateTime maxDateTime;

            minDateTime = new DateTime(1900, 1, 1, 0, 0, 0);
            maxDateTime = new DateTime(2100, 12, 31, 23, 59, 59, 997);

            if (DateTime.TryParse(date, out testDate))
            {
                if (testDate >= minDateTime && testDate <= maxDateTime)
                {
                    valid = true;
                }
                else
                {
                    valid = false;
                }
            }

            return valid;
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

                for (idx = 0; idx < parentForm3.dataGridView2.RowCount; idx++)
                {
                    cmd.CommandText = "Check_OnHand";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = Convert.ToString(parentForm3.dataGridView2.Rows[idx].Cells[5].Value);
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
                        cmd.CommandText = "Calculating_OnHand_From_Return2";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = Convert.ToString(parentForm3.dataGridView2.Rows[idx].Cells[5].Value);
                        cmd.Parameters.Add("@ReturnQty", SqlDbType.Int).Value = Convert.ToInt16(parentForm3.dataGridView2.Rows[idx].Cells[7].Value);

                        parentForm1.conn.Open();
                        cmd.ExecuteNonQuery();
                        parentForm1.conn.Close();
                    }

                    backgroundWorker1.ReportProgress(idx + 1);
                }
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
            shippingDate = richTxtSendingDate.Text.Trim();

            cmd = new SqlCommand("Update_ReturnReportHeader", parentForm1.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@Seq", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@rrID", SqlDbType.BigInt).Value = RRID;
            cmd.Parameters.Add("@rrShippingDate", SqlDbType.NVarChar).Value = shippingDate;
            cmd.Parameters.Add("@rrSubmitDate", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@rrReturnedDate", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@rrTrackingNumber", SqlDbType.NVarChar).Value = totalTrackingNumber;
            cmd.Parameters.Add("@rrReturnTotalAmount", SqlDbType.Money).Value = 0;
            cmd.Parameters.Add("@rrReceivingTotalAmount", SqlDbType.Money).Value = 0;
            cmd.Parameters.Add("@rrConfirmationID", SqlDbType.NVarChar).Value = "N/A";
            cmd.Parameters.Add("@rrStatus", SqlDbType.NVarChar).Value = "SUBMITTED";
            cmd.Parameters.Add("@rrFirstContact", SqlDbType.NVarChar).Value = "N/A";

            parentForm1.conn.Open();
            cmd.ExecuteNonQuery();
            parentForm1.conn.Close();

            MessageBox.Show("SUCCESSFULLY SUBMITTED !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

            parentForm3.RRShippingDate = shippingDate;
            parentForm3.RRTrackingNumber = totalTrackingNumber;
            parentForm3.dataGridView2.Enabled = false;
            parentForm3.btnSelectAll.Enabled = false;
            parentForm3.btnAdd.Enabled = false;
            parentForm3.btnReset2.Enabled = false;
            parentForm3.btnSaveReturnReport.Enabled = false;
            parentForm3.btnDelete.Enabled = false;
            parentForm3.lblReturnReportStatus.Text = "SUBMITTED";

            if (this.parentForm2 != null)
            {
                if (this.parentForm2.dataGridView1.RowCount != 0)
                    parentForm2.SearchReturnReportList();
            }
        }
    }
}