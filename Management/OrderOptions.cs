using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Management
{
    public partial class OrderOptions : Form
    {
        public POMain parentForm;

        string ItmBrand, ItmName, ItmSize, ItmColor, ItmUpc, ItmBin;
        Int64 ItmOnHand = 0;
        int orderQty = 1;
        double costPrice = 0, orderAmount = 0;
        bool c;
        Int64 selectedItems = 0;

        public OrderOptions()
        {
            InitializeComponent();
        }

        private void OrderOptions_Load(object sender, EventArgs e)
        {
            txtOrderQty.Select();
            txtOrderQty.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            orderQty = 0;
            
            if (int.TryParse(txtOrderQty.Text, out orderQty))
            {
                for (int i = 0; i < parentForm.dataGridView1.RowCount; i++)
                {
                    //if (parentForm.dataGridView1.Rows[i].Selected == true)
                    if (parentForm.dataGridView1.Rows[i].Cells[28].Selected == true)
                    {
                        Set_Variables(i);
                        c = Check_Duplicated(ItmSize, ItmColor, ItmUpc);

                        if (c == false)
                        {
                            orderAmount = Math.Round(orderQty * costPrice, 2, MidpointRounding.AwayFromZero);
                            parentForm.POBodyTable.Rows.Add(ItmBrand, ItmName, ItmSize, ItmColor, costPrice, ItmOnHand, orderQty, 0, orderAmount, 0, ItmUpc, ItmBin);
                        }
                        else
                        {
                            for (int j = 0; j < parentForm.dataGridView2.RowCount; j++)
                            {
                                if (Convert.ToString(parentForm.dataGridView2.Rows[j].Cells[10].Value) == ItmUpc & Convert.ToInt16(parentForm.dataGridView2.Rows[j].Cells[6].Value) != orderQty)
                                {
                                    orderAmount = Math.Round(orderQty * costPrice, 2, MidpointRounding.AwayFromZero);
                                    parentForm.dataGridView2.Rows[j].Cells[6].Value = orderQty;
                                    parentForm.dataGridView2.Rows[j].Cells[8].Value = orderAmount;
                                }
                            }
                        }

                        selectedItems = selectedItems + 1;
                    }
                }

                if (selectedItems > 0)
                {
                    BindDataGridView();
                    parentForm.lblTotalCount2.Text = Convert.ToString(parentForm.dataGridView2.RowCount);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("SELECT ITEM UPC TO ADD", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parentForm.lblTotalCount2.Text = Convert.ToString(parentForm.dataGridView2.RowCount);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("INVALID AMOUNT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtOrderQty_Click(object sender, EventArgs e)
        {
            txtOrderQty.SelectAll();
            txtOrderQty.Focus();
        }

        private bool Check_Duplicated(string size, string color, string upc)
        {
            for (int i = 0; i < parentForm.dataGridView2.RowCount; i++)
            {
                if (Convert.ToString(parentForm.dataGridView2.Rows[i].Cells[2].Value) == size & Convert.ToString(parentForm.dataGridView2.Rows[i].Cells[3].Value) == color & Convert.ToString(parentForm.dataGridView2.Rows[i].Cells[10].Value) == upc)
                {
                    return true;
                }
            }

            return false;
        }

        private void Set_Variables(int idx)
        {
            ItmBrand = Convert.ToString(parentForm.dataGridView1.Rows[idx].Cells[2].Value);
            ItmName = Convert.ToString(parentForm.dataGridView1.Rows[idx].Cells[3].Value);
            ItmSize = Convert.ToString(parentForm.dataGridView1.Rows[idx].Cells[4].Value);
            ItmColor = Convert.ToString(parentForm.dataGridView1.Rows[idx].Cells[5].Value);
            ItmOnHand = Convert.ToInt64(parentForm.dataGridView1.Rows[idx].Cells[14].Value);
            costPrice = Convert.ToDouble(parentForm.dataGridView1.Rows[idx].Cells[16].Value);
            ItmUpc = Convert.ToString(parentForm.dataGridView1.Rows[idx].Cells[28].Value);
            ItmBin = Convert.ToString(parentForm.dataGridView1.Rows[idx].Cells[29].Value);
        }

        private void BindDataGridView()
        {
            if (parentForm.VendorName.ToUpper() == parentForm.parentForm1.WarehouseName1.ToUpper())
            {
                parentForm.dataGridView2.RowTemplate.Height = 30;
                parentForm.dataGridView2.DataSource = parentForm.POBodyTable;
                parentForm.dataGridView2.Columns[0].HeaderText = "Brand";
                parentForm.dataGridView2.Columns[0].Width = 120;
                parentForm.dataGridView2.Columns[1].HeaderText = "Name";
                parentForm.dataGridView2.Columns[1].Width = 270;
                parentForm.dataGridView2.Columns[2].HeaderText = "Size";
                parentForm.dataGridView2.Columns[2].Width = 75;
                parentForm.dataGridView2.Columns[3].HeaderText = "Color";
                parentForm.dataGridView2.Columns[3].Width = 75;
                parentForm.dataGridView2.Columns[4].HeaderText = "Unit Cost";
                parentForm.dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                parentForm.dataGridView2.Columns[4].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                parentForm.dataGridView2.Columns[4].Width = 65;
                parentForm.dataGridView2.Columns[4].DefaultCellStyle.Format = "N2";
                parentForm.dataGridView2.Columns[5].HeaderText = "WH On Hand";
                parentForm.dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                parentForm.dataGridView2.Columns[5].Width = 65;
                parentForm.dataGridView2.Columns[6].HeaderText = "Order QTY";
                parentForm.dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                parentForm.dataGridView2.Columns[6].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                parentForm.dataGridView2.Columns[6].Width = 65;
                parentForm.dataGridView2.Columns[7].HeaderText = "Receiving QTY";
                parentForm.dataGridView2.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                parentForm.dataGridView2.Columns[7].Width = 55;
                parentForm.dataGridView2.Columns[7].Visible = false;
                parentForm.dataGridView2.Columns[8].HeaderText = "Order Amount";
                parentForm.dataGridView2.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                parentForm.dataGridView2.Columns[8].DefaultCellStyle.BackColor = Color.NavajoWhite;
                parentForm.dataGridView2.Columns[8].Width = 70;
                parentForm.dataGridView2.Columns[8].DefaultCellStyle.Format = "N2";
                parentForm.dataGridView2.Columns[9].HeaderText = "Receiving Amount";
                parentForm.dataGridView2.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                parentForm.dataGridView2.Columns[9].Width = 65;
                parentForm.dataGridView2.Columns[9].DefaultCellStyle.Format = "N2";
                parentForm.dataGridView2.Columns[9].Visible = false;
                parentForm.dataGridView2.Columns[10].HeaderText = "UPC";
                parentForm.dataGridView2.Columns[10].Width = 100;
                parentForm.dataGridView2.Columns[11].Visible = false;
            }
            else
            {
                parentForm.dataGridView2.RowTemplate.Height = 30;
                parentForm.dataGridView2.DataSource = parentForm.POBodyTable;
                parentForm.dataGridView2.Columns[0].HeaderText = "Brand";
                parentForm.dataGridView2.Columns[0].Width = 120;
                parentForm.dataGridView2.Columns[1].HeaderText = "Name";
                parentForm.dataGridView2.Columns[1].Width = 270;
                parentForm.dataGridView2.Columns[2].HeaderText = "Size";
                parentForm.dataGridView2.Columns[2].Width = 75;
                parentForm.dataGridView2.Columns[3].HeaderText = "Color";
                parentForm.dataGridView2.Columns[3].Width = 75;
                parentForm.dataGridView2.Columns[4].HeaderText = "Unit Cost";
                parentForm.dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                parentForm.dataGridView2.Columns[4].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                parentForm.dataGridView2.Columns[4].Width = 65;
                parentForm.dataGridView2.Columns[4].DefaultCellStyle.Format = "N2";
                parentForm.dataGridView2.Columns[5].HeaderText = "On Hand";
                parentForm.dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                parentForm.dataGridView2.Columns[5].Width = 65;
                parentForm.dataGridView2.Columns[6].HeaderText = "Order QTY";
                parentForm.dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                parentForm.dataGridView2.Columns[6].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                parentForm.dataGridView2.Columns[6].Width = 65;
                parentForm.dataGridView2.Columns[7].HeaderText = "Receiving QTY";
                parentForm.dataGridView2.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                parentForm.dataGridView2.Columns[7].Width = 55;
                parentForm.dataGridView2.Columns[7].Visible = false;
                parentForm.dataGridView2.Columns[8].HeaderText = "Order Amount";
                parentForm.dataGridView2.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                parentForm.dataGridView2.Columns[8].DefaultCellStyle.BackColor = Color.NavajoWhite;
                parentForm.dataGridView2.Columns[8].Width = 70;
                parentForm.dataGridView2.Columns[8].DefaultCellStyle.Format = "N2";
                parentForm.dataGridView2.Columns[9].HeaderText = "Receiving Amount";
                parentForm.dataGridView2.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                parentForm.dataGridView2.Columns[9].Width = 65;
                parentForm.dataGridView2.Columns[9].DefaultCellStyle.Format = "N2";
                parentForm.dataGridView2.Columns[9].Visible = false;
                parentForm.dataGridView2.Columns[10].HeaderText = "UPC";
                parentForm.dataGridView2.Columns[10].Width = 100;
                parentForm.dataGridView2.Columns[11].Visible = false;
            }

            parentForm.orderTotalQty = 0;
            parentForm.orderTotalAmount = 0;

            for (int i = 0; i < parentForm.dataGridView2.RowCount; i++)
            {
                parentForm.orderTotalQty = parentForm.orderTotalQty + Convert.ToInt16(parentForm.dataGridView2.Rows[i].Cells[6].Value);
                parentForm.orderTotalAmount = parentForm.orderTotalAmount + Convert.ToDouble(parentForm.dataGridView2.Rows[i].Cells[8].Value);
                parentForm.dataGridView2.Rows[i].Selected = false;
            }

            parentForm.lblOrderTotalQty.Text = Convert.ToString(parentForm.orderTotalQty);
            parentForm.lblOrderTotalAmount.Text = string.Format("{0:c}", parentForm.orderTotalAmount);

            if (parentForm.dataGridView2.RowCount > 0)
            {
                parentForm.dataGridView2.FirstDisplayedScrollingRowIndex = parentForm.dataGridView2.RowCount - 1;
                parentForm.dataGridView2.Rows[parentForm.dataGridView2.RowCount - 1].Selected = true;
            }
        }

        private void txtOrderQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(null, null);
            }
        }
    }
}