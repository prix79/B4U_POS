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
    public partial class AdjustTime : Form
    {
        public LogInManagements parentForm1;
        public TimeCard parentForm2;

        int rowNum;
        double adjustedHours;
        DateTime d;

        public AdjustTime(int i)
        {
            InitializeComponent();
            rowNum = i;
        }

        private void AdjustTime_Load(object sender, EventArgs e)
        {
            lblCurrentWorkingTime.Text = Convert.ToString(parentForm2.dataGridView1.Rows[rowNum].Cells[11].Value);
            d = Convert.ToDateTime(parentForm2.dataGridView1.Rows[rowNum].Cells[6].Value);
            txtAdjustedTime.SelectAll();
            txtAdjustedTime.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtAdjustedTime.Text == "")
            {
                MessageBox.Show("INPUT ADJUSTED TIME (HOURS)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAdjustedTime.SelectAll();
                txtAdjustedTime.Focus();
                return;
            }

            if (richTxtReason.Text == "")
            {
                MessageBox.Show("INPUT REASON", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                richTxtReason.SelectAll();
                richTxtReason.Focus();
                return;
            }

            if (double.TryParse(txtAdjustedTime.Text.Trim(), out adjustedHours))
            {
                if (d.DayOfWeek != DayOfWeek.Sunday)
                {
                    if (adjustedHours > 20)
                    {
                        MessageBox.Show("NOT ALLOWED INPUTTING MORE THAN 20 HR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtAdjustedTime.SelectAll();
                        txtAdjustedTime.Focus();
                        return;
                    }
                }
                else
                {
                    if (adjustedHours > 8.5)
                    {
                        MessageBox.Show("NOT ALLOWED INPUTTING MORE THAN 8.5 HR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtAdjustedTime.SelectAll();
                        txtAdjustedTime.Focus();
                        return;
                    }
                }

                DialogResult MyDialogResult;
                MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (MyDialogResult == DialogResult.Yes)
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("Update_AdjustedHours", parentForm1.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@TcNum", SqlDbType.BigInt).Value = Convert.ToInt64(parentForm2.dataGridView1.Rows[rowNum].Cells[0].Value);
                        cmd.Parameters.Add("@TcAdjustedHours", SqlDbType.Decimal).Value = adjustedHours;
                        cmd.Parameters.Add("@TcReason", SqlDbType.NVarChar).Value = richTxtReason.Text.Trim().ToUpper().ToString();
                        cmd.Parameters.Add("@TcUpdaterID", SqlDbType.NVarChar).Value = parentForm1.employeeID.ToUpper().ToString();
                        cmd.Parameters.Add("@TcUpdateDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                        parentForm1.conn.Open();
                        cmd.ExecuteNonQuery();
                        parentForm1.conn.Close();

                        MessageBox.Show("SUCCESSFULLY UPDATED", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        parentForm2.btnOK_Click(null, null);
                        this.Close();
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
            else
            {
                MessageBox.Show("INVALID VALUE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAdjustedTime.SelectAll();
                txtAdjustedTime.Focus();
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}