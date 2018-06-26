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
    public partial class InputMemberPoints : Form
    {
        public LogInManagements parentForm1;
        public UpdateCustomer parentFrom2;

        SqlConnection conn = new SqlConnection();
        SqlCommand cmd1 = new SqlCommand();
        SqlCommand cmd2 = new SqlCommand();

        Int64 Mseq;
        double oldPoints = 0;
        double newPoints = 0;

        public InputMemberPoints(Int64 seq)
        {
            InitializeComponent();
            Mseq = seq;
        }

        private void InputMemberPoints_Load(object sender, EventArgs e)
        {
            this.Text = "INPUT NEW MEMBER POINTS";
            conn.ConnectionString = parentForm1.B4UHQCS_IP;

            txtMemberPoints.SelectAll();
            txtMemberPoints.Focus();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (double.TryParse(parentFrom2.txtMemberPoints.Text, out oldPoints))
            {

            }
            else
            {
                MessageBox.Show("Invalid old poits.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemberPoints.SelectAll();
                txtMemberPoints.Focus();
                return;

            }
            if (double.TryParse(txtMemberPoints.Text, out newPoints))
            {

            }
            else
            {
                MessageBox.Show("Invalid new points", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemberPoints.SelectAll();
                txtMemberPoints.Focus();
                return;
            }

            if (txtReason.Text.Trim() != "")
            {

            }
            else
            {
                MessageBox.Show("Input a reason.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtReason.SelectAll();
                txtReason.Focus();
                return;
            }

            if (txtReason.Text.Trim().Length >= 10)
            {

            }
            else
            {
                MessageBox.Show("Please input a reason in more detail. (At least 10 characters)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtReason.SelectAll();
                txtReason.Focus();
                return;
            }

            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "Are you sure?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
            {
                try
                {
                    cmd1.CommandText = "Update_MemberPoints";
                    cmd1.Connection = conn;
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Clear();
                    cmd1.Parameters.Add("@MemberSeqNo", SqlDbType.BigInt).Value = Mseq;
                    cmd1.Parameters.Add("@MemberPoints", SqlDbType.Money).Value = newPoints;

                    cmd2.CommandText = "Create_MemberPoints_Update_History_New";
                    cmd2.Connection = conn;
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Clear();
                    cmd2.Parameters.Add("@MemberSeqNo", SqlDbType.BigInt).Value = Mseq;
                    cmd2.Parameters.Add("@MemberCode", SqlDbType.BigInt).Value = Convert.ToInt64(parentFrom2.txtMemberCode.Text.Trim());
                    cmd2.Parameters.Add("@OldMemberPoints", SqlDbType.Money).Value = oldPoints;
                    cmd2.Parameters.Add("@NewMemberPoints", SqlDbType.Money).Value = newPoints;
                    cmd2.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = parentForm1.StoreCode.ToUpper();
                    cmd2.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd2.Parameters.Add("@UpdateID", SqlDbType.NVarChar).Value = parentForm1.employeeID.ToUpper();
                    cmd2.Parameters.Add("@Reason", SqlDbType.NVarChar).Value = txtReason.Text.Trim();

                    conn.Open();
                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Successfully updated !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    parentFrom2.txtMemberPoints.Text = newPoints.ToString();
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("DB updating failed.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}