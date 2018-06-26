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
    public partial class EditPromotion : Form
    {
        public LogInManagements parentForm1;
        public PromotionMain parentForm2;
        Int64 pmCode;

        DateTime d;

        public EditPromotion(Int64 promotionCode, string pmName, string pmStartDate, string pmEndDate)
        {
            InitializeComponent();
            pmCode = promotionCode;
            txtPromotionCode.Text = Convert.ToString(pmCode);
            txtPromotionName.Text = pmName;
            txtStartDate.Text = pmStartDate;
            txtEndDate.Text = pmEndDate;
        }
        private void EditPromotion_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(parentForm2.dataGridView1.SelectedCells[5].Value) == true)
            {
                rdoBtnTrue.Checked = true;
            }
            else
            {
                rdoBtnFalse.Checked = false;
            }
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParse(txtStartDate.Text, out d))
            {
            }
            else
            {
                MessageBox.Show("INVALID START DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStartDate.SelectAll();
                txtStartDate.Focus();
                return;
            }

            if (DateTime.TryParse(txtEndDate.Text, out d))
            {
            }
            else
            {
                MessageBox.Show("INVAILD END DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEndDate.SelectAll();
                txtEndDate.Focus();
                return;
            }

            SqlCommand cmd_Update_PMHeader = new SqlCommand("Update_PromotionHeader", parentForm1.conn);
            cmd_Update_PMHeader.CommandType = CommandType.StoredProcedure;
            cmd_Update_PMHeader.Parameters.Add("@PromotionCode", SqlDbType.BigInt).Value = pmCode;
            cmd_Update_PMHeader.Parameters.Add("@PromotionName", SqlDbType.NVarChar).Value = txtPromotionName.Text.Trim().ToString();
            cmd_Update_PMHeader.Parameters.Add("@PromotionStartDate", SqlDbType.NVarChar).Value = txtStartDate.Text.Trim().ToString();
            cmd_Update_PMHeader.Parameters.Add("@PromotionEndDate", SqlDbType.NVarChar).Value = txtEndDate.Text.Trim().ToString();

            if (rdoBtnTrue.Checked == true)
            {
                cmd_Update_PMHeader.Parameters.Add("@PromotionActive", SqlDbType.Bit).Value = true;
            }
            else if (rdoBtnFalse.Checked == true)
            {
                cmd_Update_PMHeader.Parameters.Add("@PromotionActive", SqlDbType.Bit).Value = false;
            }

            SqlCommand cmd_Update_PMBody = new SqlCommand("Update_PromotionBody", parentForm1.conn);
            cmd_Update_PMBody.CommandType = CommandType.StoredProcedure;
            cmd_Update_PMBody.Parameters.Add("@PromotionCode", SqlDbType.BigInt).Value = pmCode;
            cmd_Update_PMBody.Parameters.Add("@PromotionStartDate", SqlDbType.NVarChar).Value = txtStartDate.Text.Trim().ToString();
            cmd_Update_PMBody.Parameters.Add("@PromotionEndDate", SqlDbType.NVarChar).Value = txtEndDate.Text.Trim().ToString();

            parentForm1.conn.Open();
            cmd_Update_PMHeader.ExecuteNonQuery();
            cmd_Update_PMBody.ExecuteNonQuery();
            parentForm1.conn.Close();


            if (parentForm2.dataGridView3.RowCount > 0)
            {
                SqlCommand cmd = new SqlCommand("Get_Item_From_PromotionBody2", parentForm1.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PromotionCode", SqlDbType.BigInt).Value = pmCode;
                SqlDataAdapter adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;

                parentForm1.conn.Open();
                parentForm2.PromotionTable.Clear();
                adapt.Fill(parentForm2.PromotionTable);
                parentForm1.conn.Close();

                parentForm2.dataGridView3.DataSource = parentForm2.PromotionTable;

                parentForm2.dataGridView3.Columns[0].Visible = false;
                parentForm2.dataGridView3.Columns[1].HeaderText = "Brand";
                parentForm2.dataGridView3.Columns[1].Width = 140;
                parentForm2.dataGridView3.Columns[2].HeaderText = "Name";
                parentForm2.dataGridView3.Columns[2].Width = 260;
                parentForm2.dataGridView3.Columns[3].HeaderText = "Size";
                parentForm2.dataGridView3.Columns[3].Width = 80;
                parentForm2.dataGridView3.Columns[4].HeaderText = "Color";
                parentForm2.dataGridView3.Columns[4].Width = 80;
                parentForm2.dataGridView3.Columns[5].HeaderText = "Style #";
                parentForm2.dataGridView3.Columns[5].Width = 95;
                parentForm2.dataGridView3.Columns[6].HeaderText = "Regular Price";
                parentForm2.dataGridView3.Columns[6].DefaultCellStyle.Format = "c";
                parentForm2.dataGridView3.Columns[6].Width = 55;
                parentForm2.dataGridView3.Columns[7].HeaderText = "Stylist Price";
                parentForm2.dataGridView3.Columns[7].DefaultCellStyle.Format = "c";
                parentForm2.dataGridView3.Columns[7].Width = 55;
                parentForm2.dataGridView3.Columns[8].HeaderText = "M&M";
                parentForm2.dataGridView3.Columns[8].Width = 45;
                parentForm2.dataGridView3.Columns[9].HeaderText = "M&M Val";
                parentForm2.dataGridView3.Columns[9].Width = 45;
                parentForm2.dataGridView3.Columns[10].HeaderText = "M&M Qty";
                parentForm2.dataGridView3.Columns[10].Width = 45;
                parentForm2.dataGridView3.Columns[11].HeaderText = "Promotion Type";
                parentForm2.dataGridView3.Columns[11].Width = 60;
                parentForm2.dataGridView3.Columns[12].HeaderText = "Promotion Option";
                parentForm2.dataGridView3.Columns[12].Width = 60;
                parentForm2.dataGridView3.Columns[13].HeaderText = "Sale Price";
                parentForm2.dataGridView3.Columns[13].DefaultCellStyle.Format = "c";
                parentForm2.dataGridView3.Columns[13].Width = 55;
                parentForm2.dataGridView3.Columns[14].HeaderText = "UPC";
                parentForm2.dataGridView3.Columns[14].Width = 90;
                parentForm2.dataGridView3.Columns[15].HeaderText = "Start Date";
                parentForm2.dataGridView3.Columns[15].Width = 80;
                parentForm2.dataGridView3.Columns[16].HeaderText = "End Date";
                parentForm2.dataGridView3.Columns[16].Width = 80;

                parentForm2.lblTotalCount2.Text = Convert.ToString(parentForm2.dataGridView3.RowCount);

                parentForm2.PromotionMain_Load(null, null);
                this.Close();
            }
            else
            {
                parentForm2.PromotionMain_Load(null, null);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}