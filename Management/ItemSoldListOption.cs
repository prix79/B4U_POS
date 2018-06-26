using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Management
{
    public partial class ItemSoldListOption : Form
    {
        public ItemSoldList parentForm1;
        public ItemSoldListForReturn parentForm2;
        Int64 num = 0;
        int option;

        public ItemSoldListOption(int opt)
        {
            InitializeComponent();
            option = opt;
        }

        private void ItemSoldListOption_Load(object sender, EventArgs e)
        {
            txtNum.SelectAll();
            txtNum.Focus();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (option == 0)
            {
                if (Int64.TryParse(txtNum.Text, out num))
                {
                    parentForm1.intNum = num;
                }
                else
                {
                    MessageBox.Show("INVALID NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNum.SelectAll();
                    txtNum.Focus();
                    return;
                }

                if (rdoBtnTop.Checked == true)
                {
                    parentForm1.optTopBottom = 0;

                    if (rdoBtnTrue.Checked == true)
                    {
                        parentForm1.optTrueFalse = 0;
                    }
                    else if (rdoBtnFalse.Checked == true)
                    {
                        parentForm1.optTrueFalse = 1;
                    }
                    else if (rdoBtnAll.Checked == true)
                    {
                        parentForm1.optTrueFalse = 2;
                    }
                }
                else if (rdoBtnBottom.Checked == true)
                {
                    parentForm1.optTopBottom = 1;

                    if (rdoBtnTrue.Checked == true)
                    {
                        parentForm1.optTrueFalse = 0;
                    }
                    else if (rdoBtnFalse.Checked == true)
                    {
                        parentForm1.optTrueFalse = 1;
                    }
                    else if (rdoBtnAll.Checked == true)
                    {
                        parentForm1.optTrueFalse = 2;
                    }
                }

                this.Close();
                parentForm1.btnDisplaySeletedOptions_Click(null, null);
            }
            else if (option == 1)
            {
                if (Int64.TryParse(txtNum.Text, out num))
                {
                    parentForm2.intNum = num;
                }
                else
                {
                    MessageBox.Show("INVALID NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNum.SelectAll();
                    txtNum.Focus();
                    return;
                }

                if (rdoBtnTop.Checked == true)
                {
                    parentForm2.optTopBottom = 0;

                    if (rdoBtnTrue.Checked == true)
                    {
                        parentForm2.optTrueFalse = 0;
                    }
                    else if (rdoBtnFalse.Checked == true)
                    {
                        parentForm2.optTrueFalse = 1;
                    }
                    else if (rdoBtnAll.Checked == true)
                    {
                        parentForm2.optTrueFalse = 2;
                    }
                }
                else if (rdoBtnBottom.Checked == true)
                {
                    parentForm2.optTopBottom = 1;

                    if (rdoBtnTrue.Checked == true)
                    {
                        parentForm2.optTrueFalse = 0;
                    }
                    else if (rdoBtnFalse.Checked == true)
                    {
                        parentForm2.optTrueFalse = 1;
                    }
                    else if (rdoBtnAll.Checked == true)
                    {
                        parentForm2.optTrueFalse = 2;
                    }
                }

                this.Close();
                parentForm2.btnDisplaySeletedOptions_Click(null, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoBtnTop_Click(object sender, EventArgs e)
        {
            txtNum.SelectAll();
            txtNum.Focus();
        }
    }
}