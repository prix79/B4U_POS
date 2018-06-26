using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Register
{
    public partial class CouponList : Form
    {
        public MainForm parentForm;
        string managerID;

        public CouponList(string mID)
        {
            InitializeComponent();
            managerID = mID;
        }

        private void CouponList_Load(object sender, EventArgs e)
        {

        }

        private void btnSMSFiveDollar_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(parentForm.lblGrandTotal.Text.Substring(1)) < 5.00)
            {
                MyMessageBox.ShowBox("PURCHASE AMOUNT IS LESS THAN COUPON AMOUNT", "ERROR");
                return;
            }
            else
            {
                parentForm.CouponAmt = 5;
                parentForm.CouponDesc = "SMS $5 COUPON";
                parentForm.CouponMgrID = managerID;
                parentForm.richTxtUpc.Text = "000000999109";
                parentForm.btnInput_Click(null, null);

                parentForm.Enabled = true;
                this.Close();
                parentForm.richTxtUpc.Select();
                parentForm.richTxtUpc.Focus();
            }
        }

        private void btnSMSTenDollar_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(parentForm.lblGrandTotal.Text.Substring(1)) < 10.00)
            {
                MyMessageBox.ShowBox("PURCHASE AMOUNT IS LESS THAN COUPON AMOUNT", "ERROR");
                return;
            }
            else
            {
                parentForm.CouponAmt = 10;
                parentForm.CouponDesc = "SMS $10 COUPON";
                parentForm.CouponMgrID = managerID;
                parentForm.richTxtUpc.Text = "000000999109";
                parentForm.btnInput_Click(null, null);

                parentForm.Enabled = true;
                this.Close();
                parentForm.richTxtUpc.Select();
                parentForm.richTxtUpc.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
