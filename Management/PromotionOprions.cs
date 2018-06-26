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
    public partial class PromotionOprions : Form
    {
        public PromotionMain parentForm;
        Int64 code;
        string brand, name, size, color, style, upc;
        bool mixMatch = false;
        int mixMatchVal = 0, mixMatchQty = 0;
        string promotionType;
        string start, end;
        double regularPrice, stylistPrice, salePrice;
        bool c;
        double promotionOption;

        SqlCommand cmd;
        int latestMixMatchVal;

        public PromotionOprions()
        {
            InitializeComponent();
        }

        private void PromotionOprions_Load(object sender, EventArgs e)
        {

        }

        private void rdoBtnPercentOff_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBtnPercentOff.Checked == true)
            {
                txtPercentOff.Enabled = true;
                txtPercentOff.Select();
                txtPercentOff.Focus();
            }
            else
            {
                txtPercentOff.Enabled = false;
            }
        }

        private void rdoBtnMoneyOff_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBtnMoneyOff.Checked == true)
            {
                txtMoneyOff.Enabled = true;
                txtMoneyOff.Select();
                txtMoneyOff.Focus();
            }
            else
            {
                txtMoneyOff.Enabled = false;
            }
        }

        private void rdoBtnFixedPrice_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBtnFixedPrice.Checked == true)
            {
                txtFixedPrice.Enabled = true;
                txtFixedPrice.Select();
                txtFixedPrice.Focus();
            }
            else
            {
                txtFixedPrice.Enabled = false;
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (rdoBtnFalse.Checked == true)
            {
                mixMatch = false;
                mixMatchVal = 0;
                mixMatchQty = 0;

                if (txtPercentOff.Enabled == true)
                {
                    double percentOff;

                    if (double.TryParse(txtPercentOff.Text, out percentOff))
                    {
                        if (percentOff >= 0)
                        {
                            if (percentOff == 50)
                            {
                                promotionType = "PERCENT";
                                promotionOption = percentOff;
                                start = parentForm.startDay;
                                end = parentForm.endDay;

                                percentOff = 1 - (percentOff / 100);

                                for (int i = 0; i < parentForm.dataGridView2.RowCount; i++)
                                {
                                    if (parentForm.dataGridView2.Rows[i].Selected == true)
                                    {
                                        Set_Variables(i);
                                        c = Check_Duplicated(upc);

                                        if (c == false)
                                        {
                                            parentForm.PromotionTable.Rows.Add(code, brand, name, size, color, style, regularPrice, stylistPrice, mixMatch, mixMatchVal, mixMatchQty, promotionType, promotionOption, regularPrice - (Math.Round(regularPrice * percentOff, 2)), upc, start, end);
                                        }
                                    }
                                }

                                parentForm.dataGridView3.DataSource = parentForm.PromotionTable;
                                parentForm.lblTotalCount2.Text = Convert.ToString(parentForm.dataGridView3.RowCount);
                                this.Close();
                            }
                            else
                            {
                                promotionType = "PERCENT";
                                promotionOption = percentOff;
                                start = parentForm.startDay;
                                end = parentForm.endDay;

                                percentOff = 1 - (percentOff / 100);

                                for (int i = 0; i < parentForm.dataGridView2.RowCount; i++)
                                {
                                    if (parentForm.dataGridView2.Rows[i].Selected == true)
                                    {
                                        Set_Variables(i);
                                        c = Check_Duplicated(upc);

                                        if (c == false)
                                        {
                                            parentForm.PromotionTable.Rows.Add(code, brand, name, size, color, style, regularPrice, stylistPrice, mixMatch, mixMatchVal, mixMatchQty, promotionType, promotionOption, Math.Round(regularPrice * percentOff, 2), upc, start, end);
                                        }
                                    }
                                }

                                parentForm.dataGridView3.DataSource = parentForm.PromotionTable;
                                parentForm.lblTotalCount2.Text = Convert.ToString(parentForm.dataGridView3.RowCount);
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("INVALID AMOUNT (NAGATIVE PERCENT)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtPercentOff.SelectAll();
                            txtPercentOff.Focus();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("INVALID AMOUNT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPercentOff.SelectAll();
                        txtPercentOff.Focus();
                        return;
                    }
                }
                else if (txtMoneyOff.Enabled == true)
                {
                    double moneyOff;

                    if (double.TryParse(txtMoneyOff.Text, out moneyOff))
                    {
                        promotionType = "MONEY";
                        promotionOption = moneyOff;
                        start = parentForm.startDay;
                        end = parentForm.endDay;

                        for (int i = 0; i < parentForm.dataGridView2.RowCount; i++)
                        {
                            if (parentForm.dataGridView2.Rows[i].Selected == true)
                            {
                                Set_Variables(i);
                                c = Check_Duplicated(upc);

                                if (c == false)
                                {
                                    parentForm.PromotionTable.Rows.Add(code, brand, name, size, color, style, regularPrice, stylistPrice, mixMatch, mixMatchVal, mixMatchQty, promotionType, promotionOption, regularPrice - moneyOff, upc, start, end);
                                }
                            }
                        }

                        parentForm.dataGridView3.DataSource = parentForm.PromotionTable;
                        parentForm.lblTotalCount2.Text = Convert.ToString(parentForm.dataGridView3.RowCount);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("INVALID AMOUNT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMoneyOff.SelectAll();
                        txtMoneyOff.Focus();
                        return;
                    }
                }
                else if (txtFixedPrice.Enabled == true)
                {
                    double fixedPrice;

                    if (double.TryParse(txtFixedPrice.Text, out fixedPrice))
                    {
                        if (fixedPrice >= 0)
                        {
                            promotionType = "FIXED";
                            promotionOption = fixedPrice;
                            start = parentForm.startDay;
                            end = parentForm.endDay;

                            for (int i = 0; i < parentForm.dataGridView2.RowCount; i++)
                            {
                                if (parentForm.dataGridView2.Rows[i].Selected == true)
                                {
                                    Set_Variables(i);
                                    c = Check_Duplicated(upc);

                                    if (c == false)
                                    {
                                        parentForm.PromotionTable.Rows.Add(code, brand, name, size, color, style, regularPrice, stylistPrice, mixMatch, mixMatchVal, mixMatchQty, promotionType, promotionOption, fixedPrice, upc, start, end);
                                    }
                                }
                            }

                            parentForm.dataGridView3.DataSource = parentForm.PromotionTable;
                            parentForm.lblTotalCount2.Text = Convert.ToString(parentForm.dataGridView3.RowCount);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("INVALID AMOUNT (NAGATIVE AMOUNT)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtFixedPrice.SelectAll();
                            txtFixedPrice.Focus();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("INVALID AMOUNT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtFixedPrice.SelectAll();
                        txtFixedPrice.Focus();
                        return;
                    }
                }

                if (parentForm.dataGridView3.RowCount > 0)
                {
                    parentForm.dataGridView3.SelectionMode = DataGridViewSelectionMode.CellSelect;
                    parentForm.dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    parentForm.dataGridView3.FirstDisplayedScrollingRowIndex = parentForm.dataGridView3.RowCount - 1;
                    parentForm.dataGridView3.Rows[parentForm.dataGridView3.RowCount - 1].Selected = true;
                }
                /*parentForm.dataGridView3.Columns[0].Width = 140;
                parentForm.dataGridView3.Columns[1].Width = 260;
                parentForm.dataGridView3.Columns[2].Width = 80;
                parentForm.dataGridView3.Columns[3].Width = 80;
                parentForm.dataGridView3.Columns[4].Width = 95;
                parentForm.dataGridView3.Columns[5].Width = 55;
                parentForm.dataGridView3.Columns[6].Width = 55;
                parentForm.dataGridView3.Columns[7].Width = 60;
                parentForm.dataGridView3.Columns[8].Width = 60;
                parentForm.dataGridView3.Columns[9].Width = 55;
                parentForm.dataGridView3.Columns[10].Width = 90;
                parentForm.dataGridView3.Columns[11].Width = 80;
                parentForm.dataGridView3.Columns[12].Width = 80;*/
            }
            else if (rdoBtnTrue.Checked == true)
            {
                mixMatch = true;

                if (int.TryParse(txtValue.Text, out mixMatchVal))
                {
                }
                else
                {
                    MessageBox.Show("INVALID VALUE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtValue.SelectAll();
                    txtValue.Focus();
                    return;
                }

                if (int.TryParse(txtQty.Text, out mixMatchQty))
                {
                }
                else
                {
                    MessageBox.Show("INVALID QTY", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQty.SelectAll();
                    txtQty.Focus();
                    return;
                }

                if (txtPercentOff.Enabled == true)
                {
                    double percentOff;

                    if (double.TryParse(txtPercentOff.Text, out percentOff))
                    {
                        if (percentOff >= 0)
                        {
                            if (percentOff == 50)
                            {
                                promotionType = "PERCENT";
                                promotionOption = percentOff;
                                start = parentForm.startDay;
                                end = parentForm.endDay;

                                percentOff = 1 - (percentOff / 100);

                                for (int i = 0; i < parentForm.dataGridView2.RowCount; i++)
                                {
                                    if (parentForm.dataGridView2.Rows[i].Selected == true)
                                    {
                                        Set_Variables(i);
                                        c = Check_Duplicated(upc);

                                        if (c == false)
                                        {
                                            parentForm.PromotionTable.Rows.Add(code, brand, name, size, color, style, regularPrice, stylistPrice, mixMatch, mixMatchVal, mixMatchQty, promotionType, promotionOption, regularPrice - (Math.Round(regularPrice * percentOff, 2)), upc, start, end);
                                        }
                                    }
                                }

                                parentForm.dataGridView3.DataSource = parentForm.PromotionTable;
                                parentForm.lblTotalCount2.Text = Convert.ToString(parentForm.dataGridView3.RowCount);
                                this.Close();
                            }
                            else
                            {
                                promotionType = "PERCENT";
                                promotionOption = percentOff;
                                start = parentForm.startDay;
                                end = parentForm.endDay;

                                percentOff = 1 - (percentOff / 100);

                                for (int i = 0; i < parentForm.dataGridView2.RowCount; i++)
                                {
                                    if (parentForm.dataGridView2.Rows[i].Selected == true)
                                    {
                                        Set_Variables(i);
                                        c = Check_Duplicated(upc);

                                        if (c == false)
                                        {
                                            parentForm.PromotionTable.Rows.Add(code, brand, name, size, color, style, regularPrice, stylistPrice, mixMatch, mixMatchVal, mixMatchQty, promotionType, promotionOption, Math.Round(regularPrice * percentOff, 2), upc, start, end);
                                        }
                                    }
                                }

                                parentForm.dataGridView3.DataSource = parentForm.PromotionTable;
                                parentForm.lblTotalCount2.Text = Convert.ToString(parentForm.dataGridView3.RowCount);
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("INVALID AMOUNT (NAGATIVE PERCENT)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtPercentOff.SelectAll();
                            txtPercentOff.Focus();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("INVALID AMOUNT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPercentOff.SelectAll();
                        txtPercentOff.Focus();
                        return;
                    }
                }
                else if (txtMoneyOff.Enabled == true)
                {
                    double moneyOff;

                    if (double.TryParse(txtMoneyOff.Text, out moneyOff))
                    {
                        promotionType = "MONEY";
                        promotionOption = moneyOff;
                        start = parentForm.startDay;
                        end = parentForm.endDay;

                        for (int i = 0; i < parentForm.dataGridView2.RowCount; i++)
                        {
                            if (parentForm.dataGridView2.Rows[i].Selected == true)
                            {
                                Set_Variables(i);
                                c = Check_Duplicated(upc);

                                if (c == false)
                                {
                                    parentForm.PromotionTable.Rows.Add(code, brand, name, size, color, style, regularPrice, stylistPrice, mixMatch, mixMatchVal, mixMatchQty, promotionType, promotionOption, regularPrice - moneyOff, upc, start, end);
                                }
                            }
                        }

                        parentForm.dataGridView3.DataSource = parentForm.PromotionTable;
                        parentForm.lblTotalCount2.Text = Convert.ToString(parentForm.dataGridView3.RowCount);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("INVALID AMOUNT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMoneyOff.SelectAll();
                        txtMoneyOff.Focus();
                        return;
                    }
                }
                else if (txtFixedPrice.Enabled == true)
                {
                    double fixedPrice;

                    if (double.TryParse(txtFixedPrice.Text, out fixedPrice))
                    {
                        if (fixedPrice >= 0)
                        {
                            promotionType = "FIXED";
                            promotionOption = fixedPrice;
                            start = parentForm.startDay;
                            end = parentForm.endDay;

                            for (int i = 0; i < parentForm.dataGridView2.RowCount; i++)
                            {
                                if (parentForm.dataGridView2.Rows[i].Selected == true)
                                {
                                    Set_Variables(i);
                                    c = Check_Duplicated(upc);

                                    if (c == false)
                                    {
                                        parentForm.PromotionTable.Rows.Add(code, brand, name, size, color, style, regularPrice, stylistPrice, mixMatch, mixMatchVal, mixMatchQty, promotionType, promotionOption, fixedPrice, upc, start, end);
                                    }
                                }
                            }

                            parentForm.dataGridView3.DataSource = parentForm.PromotionTable;
                            parentForm.lblTotalCount2.Text = Convert.ToString(parentForm.dataGridView3.RowCount);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("INVALID AMOUNT (NAGATIVE AMOUNT)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtFixedPrice.SelectAll();
                            txtFixedPrice.Focus();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("INVALID AMOUNT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtFixedPrice.SelectAll();
                        txtFixedPrice.Focus();
                        return;
                    }
                }

                if (parentForm.dataGridView3.RowCount > 0)
                {
                    parentForm.dataGridView3.SelectionMode = DataGridViewSelectionMode.CellSelect;
                    parentForm.dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    parentForm.dataGridView3.FirstDisplayedScrollingRowIndex = parentForm.dataGridView3.RowCount - 1;
                    parentForm.dataGridView3.Rows[parentForm.dataGridView3.RowCount - 1].Selected = true;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Check_Duplicated(string upc)
        {
            for (int i = 0; i < parentForm.dataGridView3.RowCount; i++)
            {
                if (Convert.ToString(parentForm.dataGridView3.Rows[i].Cells[14].Value) == upc)
                {
                    return true;
                }            
            }

            return false;
        }

        private void Set_Variables(int i)
        {
            code = Convert.ToInt64(parentForm.dataGridView2.Rows[i].Cells[0].Value);
            brand = Convert.ToString(parentForm.dataGridView2.Rows[i].Cells[1].Value);
            name = Convert.ToString(parentForm.dataGridView2.Rows[i].Cells[2].Value);
            size = Convert.ToString(parentForm.dataGridView2.Rows[i].Cells[3].Value);
            color = Convert.ToString(parentForm.dataGridView2.Rows[i].Cells[4].Value);
            style = Convert.ToString(parentForm.dataGridView2.Rows[i].Cells[5].Value);
            regularPrice = Convert.ToDouble(parentForm.dataGridView2.Rows[i].Cells[7].Value);
            stylistPrice = Convert.ToDouble(parentForm.dataGridView2.Rows[i].Cells[8].Value);
            salePrice = Convert.ToDouble(parentForm.dataGridView2.Rows[i].Cells[9].Value);
            upc = Convert.ToString(parentForm.dataGridView2.Rows[i].Cells[10].Value);
        }

        private void rdoBtnFalse_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBtnFalse.Checked == true)
            {
                txtValue.Clear();
                txtQty.Clear();
                btnGenerateGroupValue.Enabled = false;
                txtValue.Enabled = false;
                txtQty.Enabled = false;
            }
        }

        private void rdoBtnTrue_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBtnTrue.Checked == true)
            {
                txtValue.Enabled = true;
                txtQty.Enabled = true;
                btnGenerateGroupValue.Enabled = true;
                txtValue.Select();
                txtValue.Focus();
            }
        }

        private void btnGenerateGroupValue_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Get_Latest_MixMatchVal", parentForm.parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            SqlParameter LatestMixMatchVal_Param = cmd.Parameters.Add("@LatestMixMatchVal", SqlDbType.Int);
            LatestMixMatchVal_Param.Direction = ParameterDirection.Output;

            parentForm.parentForm.conn.Open();
            cmd.ExecuteNonQuery();
            parentForm.parentForm.conn.Close();

            latestMixMatchVal = Convert.ToInt16(cmd.Parameters["@LatestMixMatchVal"].Value);
            txtValue.Text = Convert.ToString(latestMixMatchVal + 1);
        }
    }
}