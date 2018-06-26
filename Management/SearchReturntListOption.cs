using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Management
{
    public partial class SearchReturntListOption : Form
    {
        public LogInManagements parentForm1;
        public POandReceiving parentForm2;
        public POandReceivingForWarehouse parentForm3;
        DateTime d;
        int option = 0;

        public SearchReturntListOption(int opt)
        {
            InitializeComponent();
            option = opt;
        }

        private void SearchReturnReportListOption_Load(object sender, EventArgs e)
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtStartDate.Text == "")
            {
                MessageBox.Show("SELECT START DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStartDate.SelectAll();
                txtStartDate.Focus();
                return;
            }

            if (txtEndDate.Text == "")
            {
                MessageBox.Show("SELECT END DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEndDate.SelectAll();
                txtEndDate.Focus();
                return;
            }

            if (DateTime.TryParse(txtStartDate.Text, out d))
            {
            }
            else
            {
                MessageBox.Show("INVALID DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStartDate.SelectAll();
                txtStartDate.Focus();
                return;
            }

            if (DateTime.TryParse(txtEndDate.Text, out d))
            {
            }
            else
            {
                MessageBox.Show("INVALID DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEndDate.SelectAll();
                txtEndDate.Focus();
                return;
            }

            if (option == 2)
            {
                if (rdoBtnCreateDate.Checked == true)
                {
                    parentForm3.dateOption = 0;
                }
                else if (rdoBtnReceiveDate.Checked == true)
                {
                    parentForm3.dateOption = 1;
                }

                parentForm3.startDate = txtStartDate.Text.ToString();
                parentForm3.endDate = txtEndDate.Text.ToString();
                parentForm3.SearchAllReturnReportList();
            }
            else
            {
                if (rdoBtnCreateDate.Checked == true)
                {
                    parentForm2.dateOption = 0;
                }
                else if (rdoBtnReceiveDate.Checked == true)
                {
                    parentForm2.dateOption = 1;
                }

                parentForm2.startDate = txtStartDate.Text.ToString();
                parentForm2.endDate = txtEndDate.Text.ToString();

                if (option == 0)
                {
                    parentForm2.SearchReturnReportList();
                }
                else if (option == 1)
                {
                    parentForm2.SearchAllReturnReportList();
                }  
            }
 
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}