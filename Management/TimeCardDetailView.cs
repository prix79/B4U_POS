using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Management
{
    public partial class TimeCardDetailView : Form
    {
        public TimeCard parentForm;

        int rowNum;

        public TimeCardDetailView(int i)
        {
            InitializeComponent();
            rowNum = i;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TimeCardDetailView_Load(object sender, EventArgs e)
        {
            lblStoreCode.Text = Convert.ToString(parentForm.dataGridView1.Rows[rowNum].Cells[1].Value);
            lblLoginID.Text = Convert.ToString(parentForm.dataGridView1.Rows[rowNum].Cells[2].Value);
            lblFirstName.Text = Convert.ToString(parentForm.dataGridView1.Rows[rowNum].Cells[3].Value);
            lblLastName.Text = Convert.ToString(parentForm.dataGridView1.Rows[rowNum].Cells[4].Value);
            lblClockInR.Text = Convert.ToString(parentForm.dataGridView1.Rows[rowNum].Cells[6].Value);
            lblClockOutR.Text = Convert.ToString(parentForm.dataGridView1.Rows[rowNum].Cells[7].Value);
            lblClockInC.Text = Convert.ToString(parentForm.dataGridView1.Rows[rowNum].Cells[8].Value);
            lblClockOutC.Text = Convert.ToString(parentForm.dataGridView1.Rows[rowNum].Cells[9].Value);
            lblWorkingTimeM.Text = Convert.ToString(parentForm.dataGridView1.Rows[rowNum].Cells[10].Value);

            if (parentForm.dataGridView1.Rows[rowNum].Cells[11].Style.ForeColor == Color.Red)
            {
                lblWorkingTimeH.Text = Convert.ToString(parentForm.dataGridView1.Rows[rowNum].Cells[11].Value);
                lblWorkingTimeH.ForeColor = Color.Red;
            }
            else
            {
                lblWorkingTimeH.Text = Convert.ToString(parentForm.dataGridView1.Rows[rowNum].Cells[11].Value);
            }

            lblAdjustedTimeH.Text = Convert.ToString(parentForm.dataGridView1.Rows[rowNum].Cells[12].Value);
            lblReason.Text = Convert.ToString(parentForm.dataGridView1.Rows[rowNum].Cells[13].Value);
            lblUpdaterID.Text = Convert.ToString(parentForm.dataGridView1.Rows[rowNum].Cells[14].Value);
            lblUpdateDate.Text = Convert.ToString(parentForm.dataGridView1.Rows[rowNum].Cells[15].Value);
            lblFinalTimeH.Text = Convert.ToString(parentForm.dataGridView1.Rows[rowNum].Cells[16].Value);

            if (Convert.ToBoolean(parentForm.dataGridView1.Rows[rowNum].Cells[18].Value) == true)
            {
                lblSettle.Text = "YES";
                lblSettle.ForeColor = Color.Green;
            }
            else
            {
                lblSettle.Text = "NO";
                lblSettle.ForeColor = Color.Red;
            }

            lblSettleID.Text = Convert.ToString(parentForm.dataGridView1.Rows[rowNum].Cells[19].Value);
            lblSettleDate.Text = Convert.ToString(parentForm.dataGridView1.Rows[rowNum].Cells[20].Value);
        }

    }
}