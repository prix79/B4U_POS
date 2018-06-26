using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Management
{
    public partial class CreateGiftcard : Form
    {
        public ManageGiftcard parentForm;
        int sn, en, yn;
        double amt;

        public CreateGiftcard()
        {
            InitializeComponent();
        }

        private void CreateGiftcard_Load(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtStartNum.Text == "")
            {
                MessageBox.Show("ENTER START NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStartNum.Focus();
                return;
            }

            if (txtEndNum.Text == "")
            {
                MessageBox.Show("ENTER END NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEndNum.Focus();
                return;
            }

            if (txtAmount.Text == "")
            {
                MessageBox.Show("ENTER AMOUNT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAmount.Focus();
                return;
            }

            if (txtYear.Text == "")
            {
                MessageBox.Show("ENTER YEAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtYear.Focus();
                return;
            }

            if (int.TryParse(txtStartNum.Text, out sn))
            {
                if (sn < 0 | sn > 9999)
                {
                    MessageBox.Show("INVALID RANGE, INPUT NUMBER BETWEEN 1 TO 9999", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtStartNum.Focus();
                    txtStartNum.SelectAll();
                    return;
                }
            }
            else
            {
                MessageBox.Show("INVALID NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStartNum.Focus();
                txtStartNum.SelectAll();
                return;
            }

            if (int.TryParse(txtEndNum.Text, out en))
            {
                if (en < 0 | en > 9999)
                {
                    MessageBox.Show("INVALID RANGE, INPUT NUMBER BETWEEN 1 TO 9999", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEndNum.Focus();
                    txtEndNum.SelectAll();
                    return;
                }
            }
            else
            {
                MessageBox.Show("INVALID NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEndNum.Focus();
                txtEndNum.SelectAll();
                return;
            }

            if (double.TryParse(txtAmount.Text, out amt))
            {
                if (amt < 0)
                {
                    MessageBox.Show("INVALID AMOUNT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAmount.Focus();
                    txtAmount.SelectAll();
                    return;
                }
            }
            else
            {
                MessageBox.Show("INVALID AMOUNT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAmount.Focus();
                txtAmount.SelectAll();
                return;
            }

            if (int.TryParse(txtYear.Text, out yn))
            {
                if (txtYear.Text.Trim().Length != 4)
                {
                    MessageBox.Show("INVALID YEAR, INPUT YEAR BETWEEN 0000 TO 9999", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEndNum.Focus();
                    txtEndNum.SelectAll();
                    return;
                }
            }
            else
            {
                MessageBox.Show("INVALID NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtYear.Focus();
                txtYear.SelectAll();
                return;
            }

            parentForm.startNum = sn;
            parentForm.endNum = en;
            parentForm.yearNum = yn;
            parentForm.numOfgiftcard = parentForm.endNum - parentForm.startNum + 1;

            if (parentForm.numOfgiftcard < 1)
            {
                MessageBox.Show("CAN NOT CREATE GIFTCARD, CHECK START NUMBER AND END NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStartNum.Focus();
                txtStartNum.SelectAll();
                return;
            }

            this.Close();
            //parentForm.Giftcard_Validation();
            parentForm.Create_Giftcard(Convert.ToDouble(txtAmount.Text.Trim()));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}