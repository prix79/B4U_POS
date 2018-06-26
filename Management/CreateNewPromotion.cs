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
    public partial class CreateNewPromotion : Form
    {
        public LogInManagements parentForm1;
        public PromotionMain parentForm2;

        public CreateNewPromotion()
        {
            InitializeComponent();
        }

        private void CreateNewPromotion_Load(object sender, EventArgs e)
        {
            txtStartDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
            txtEndDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
        }

        private void txtStartDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void txtEndDate_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar2.Visible = true;
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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            DateTime startDate;
            DateTime endDate;

            if (btnGenerate.Enabled == true)
            {
                MessageBox.Show("GENERATE PROMOTION CODE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtPromotionName.Text == "")
            {
                MessageBox.Show("INPUT PROMOTION NAME", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DateTime.TryParse(txtStartDate.Text, out startDate))
            {
                string sd = startDate.ToString();
            }
            else
            {
                MessageBox.Show("INVALID START DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DateTime.TryParse(txtEndDate.Text, out endDate))
            {
                string ed = endDate.ToString();
            }
            else
            {
                MessageBox.Show("INVAILD END DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlCommand cmd = new SqlCommand("Create_PromotionHeader", parentForm1.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@PromotionCode", SqlDbType.BigInt).Value = Convert.ToInt64(txtPromotionCode.Text);
            cmd.Parameters.Add("@PromotionName", SqlDbType.NVarChar).Value = txtPromotionName.Text.Trim().ToString();
            cmd.Parameters.Add("@PromotionStartDate", SqlDbType.NVarChar).Value = txtStartDate.Text.Trim().ToString();
            cmd.Parameters.Add("@PromotionEndDate", SqlDbType.NVarChar).Value = txtEndDate.Text.Trim().ToString();

            parentForm1.conn.Open();
            cmd.ExecuteNonQuery();
            parentForm1.conn.Close();

            parentForm2.PromotionMain_Load(null, null);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Get_Latest_PromotionCode", parentForm1.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            SqlParameter LatestNumGen_Param = cmd.Parameters.Add("@LatestNumGen", SqlDbType.NVarChar, 15);
            LatestNumGen_Param.Direction = ParameterDirection.Output;

            parentForm1.conn.Open();
            cmd.ExecuteNonQuery();
            parentForm1.conn.Close();

            txtPromotionCode.Text = Convert.ToString(Convert.ToInt64(cmd.Parameters["@LatestNumGen"].Value) + 1);
            btnGenerate.Enabled = false;
        }
    }
}