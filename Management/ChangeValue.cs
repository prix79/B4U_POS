using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Management
{
    public partial class ChangeValue : Form
    {
        public ItemSoldList parentForm1;
        public POMain parentForm2;
        public ItemSoldListForReturn parentForm3;

        int option = 0;

        Int64 orderQty = 0;
        Int64 returnQty = 0;
        double CostPrice = 0;

        public ChangeValue(int opt)
        {
            InitializeComponent();
            option = opt;
        }

        private void ChangeValue_Load(object sender, EventArgs e)
        {
            txtValue.SelectAll();
            txtValue.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (option == 0)
            {
                if (rdoBtnOrderQty.Checked == true)
                {
                    if (Int64.TryParse(txtValue.Text, out orderQty))
                    {
                        for (int i = 0; i < parentForm1.dataGridView2.RowCount; i++)
                        {
                            if (parentForm1.dataGridView2.Rows[i].Selected == true)
                            {
                                parentForm1.dataGridView2.Rows[i].Cells[10].Value = orderQty;
                                parentForm1.dataGridView2.Rows[i].Cells[11].Value = orderQty * Convert.ToDouble(parentForm1.dataGridView2.Rows[i].Cells[7].Value);
                            }
                        }

                        parentForm1.totalQty = 0; 
                        parentForm1.totalCost = 0;

                        for (int i = 0; i < parentForm1.dataGridView2.RowCount; i++)
                        {
                            parentForm1.totalQty = parentForm1.totalQty + Convert.ToInt64(parentForm1.dataGridView2.Rows[i].Cells[10].Value);
                            parentForm1.totalCost = parentForm1.totalCost + Convert.ToDouble(parentForm1.dataGridView2.Rows[i].Cells[11].Value);
                        }

                        parentForm1.lblTotalQty.Text = Convert.ToString(parentForm1.totalQty);
                        parentForm1.lblTotalCost.Text = string.Format("{0:$0.00}", parentForm1.totalCost);

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("INVALID ORDER QTY", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtValue.SelectAll();
                        txtValue.Focus();
                        return;
                    }
                }
                else if (rdoBtnCostPrice.Checked == true)
                {
                    if (double.TryParse(txtValue.Text, out CostPrice))
                    {
                        for (int i = 0; i < parentForm1.dataGridView2.RowCount; i++)
                        {
                            if (parentForm1.dataGridView2.Rows[i].Selected == true)
                            {
                                parentForm1.dataGridView2.Rows[i].Cells[7].Value = CostPrice;
                                parentForm1.dataGridView2.Rows[i].Cells[11].Value = CostPrice * Convert.ToInt64(parentForm1.dataGridView2.Rows[i].Cells[10].Value);
                            }
                        }

                        parentForm1.totalQty = 0;
                        parentForm1.totalCost = 0;

                        for (int i = 0; i < parentForm1.dataGridView2.RowCount; i++)
                        {
                            parentForm1.totalQty = parentForm1.totalQty + Convert.ToInt64(parentForm1.dataGridView2.Rows[i].Cells[10].Value);
                            parentForm1.totalCost = parentForm1.totalCost + Convert.ToDouble(parentForm1.dataGridView2.Rows[i].Cells[11].Value);
                        }

                        parentForm1.lblTotalQty.Text = Convert.ToString(parentForm1.totalQty);
                        parentForm1.lblTotalCost.Text = string.Format("{0:$0.00}", parentForm1.totalCost);

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("INVALID COST PRICE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtValue.SelectAll();
                        txtValue.Focus();
                        return;
                    }
                }
            }
            else if (option == 1)
            {
                if (rdoBtnOrderQty.Checked == true)
                {
                    if (Int64.TryParse(txtValue.Text, out orderQty))
                    {
                        for (int i = 0; i < parentForm2.dataGridView2.RowCount; i++)
                        {
                            if (parentForm2.dataGridView2.Rows[i].Selected == true)
                            {
                                parentForm2.dataGridView2.Rows[i].Cells[6].Value = orderQty;
                                parentForm2.dataGridView2.Rows[i].Cells[8].Value = Convert.ToInt64(parentForm2.dataGridView2.Rows[i].Cells[6].Value) * Convert.ToDouble(parentForm2.dataGridView2.Rows[i].Cells[4].Value);
                            }
                        }

                        parentForm2.orderTotalQty = 0;
                        parentForm2.orderTotalAmount = 0;

                        for (int i = 0; i < parentForm2.dataGridView2.RowCount; i++)
                        {
                            parentForm2.orderTotalQty = parentForm2.orderTotalQty + Convert.ToInt64(parentForm2.dataGridView2.Rows[i].Cells[6].Value);
                            parentForm2.orderTotalAmount = parentForm2.orderTotalAmount + Convert.ToDouble(parentForm2.dataGridView2.Rows[i].Cells[8].Value);
                        }

                        parentForm2.lblOrderTotalQty.Text = Convert.ToString(parentForm2.orderTotalQty);
                        parentForm2.lblOrderTotalAmount.Text = string.Format("{0:$0.00}", parentForm2.orderTotalAmount);

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("INVALID ORDER QTY", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtValue.SelectAll();
                        txtValue.Focus();
                        return;
                    }
                }
                else if (rdoBtnCostPrice.Checked == true)
                {
                    if (double.TryParse(txtValue.Text, out CostPrice))
                    {
                        for (int i = 0; i < parentForm2.dataGridView2.RowCount; i++)
                        {
                            if (parentForm2.dataGridView2.Rows[i].Selected == true)
                            {
                                parentForm2.dataGridView2.Rows[i].Cells[4].Value = CostPrice;
                                parentForm2.dataGridView2.Rows[i].Cells[8].Value = Convert.ToInt64(parentForm2.dataGridView2.Rows[i].Cells[6].Value) * Convert.ToDouble(parentForm2.dataGridView2.Rows[i].Cells[4].Value);
                            }
                        }

                        parentForm2.orderTotalQty = 0;
                        parentForm2.orderTotalAmount = 0;

                        for (int i = 0; i < parentForm2.dataGridView2.RowCount; i++)
                        {
                            parentForm2.orderTotalQty = parentForm2.orderTotalQty + Convert.ToInt64(parentForm2.dataGridView2.Rows[i].Cells[6].Value);
                            parentForm2.orderTotalAmount = parentForm2.orderTotalAmount + Convert.ToDouble(parentForm2.dataGridView2.Rows[i].Cells[8].Value);
                        }

                        parentForm2.lblOrderTotalQty.Text = Convert.ToString(parentForm2.orderTotalQty);
                        parentForm2.lblOrderTotalAmount.Text = string.Format("{0:$0.00}", parentForm2.orderTotalAmount);

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("INVALID COST PRICE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtValue.SelectAll();
                        txtValue.Focus();
                        return;
                    }
                }
            }
            else if (option == 2)
            {
                if (rdoBtnOrderQty.Checked == true)
                {
                    if (Int64.TryParse(txtValue.Text, out returnQty))
                    {
                        for (int i = 0; i < parentForm3.dataGridView2.RowCount; i++)
                        {
                            if (parentForm3.dataGridView2.Rows[i].Selected == true)
                            {
                                parentForm3.dataGridView2.Rows[i].Cells[7].Value = returnQty;
                                parentForm3.dataGridView2.Rows[i].Cells[8].Value = Convert.ToInt64(parentForm3.dataGridView2.Rows[i].Cells[7].Value) * Convert.ToDouble(parentForm3.dataGridView2.Rows[i].Cells[6].Value);
                            }
                        }

                        parentForm3.totalReturnQty = 0;
                        parentForm3.totalReturnAmount = 0;

                        for (int i = 0; i < parentForm3.dataGridView2.RowCount; i++)
                        {
                            parentForm3.totalReturnQty = parentForm3.totalReturnQty + Convert.ToInt64(parentForm3.dataGridView2.Rows[i].Cells[7].Value);
                            parentForm3.totalReturnAmount = parentForm3.totalReturnAmount + Convert.ToDouble(parentForm3.dataGridView2.Rows[i].Cells[8].Value);
                        }

                        parentForm3.lblTotalReturnQty.Text = Convert.ToString(parentForm3.totalReturnQty);
                        parentForm3.lblTotalReturnAmount.Text = string.Format("{0:$0.00}", parentForm3.totalReturnAmount);

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("INVALID ORDER QTY", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtValue.SelectAll();
                        txtValue.Focus();
                        return;
                    }
                }
                else if (rdoBtnCostPrice.Checked == true)
                {
                    if (double.TryParse(txtValue.Text, out CostPrice))
                    {
                        for (int i = 0; i < parentForm3.dataGridView2.RowCount; i++)
                        {
                            if (parentForm3.dataGridView2.Rows[i].Selected == true)
                            {
                                parentForm3.dataGridView2.Rows[i].Cells[6].Value = CostPrice;
                                parentForm3.dataGridView2.Rows[i].Cells[8].Value = Convert.ToInt64(parentForm3.dataGridView2.Rows[i].Cells[7].Value) * Convert.ToDouble(parentForm3.dataGridView2.Rows[i].Cells[6].Value);
                            }
                        }

                        parentForm3.totalReturnQty = 0;
                        parentForm3.totalReturnAmount = 0;

                        for (int i = 0; i < parentForm3.dataGridView2.RowCount; i++)
                        {
                            parentForm3.totalReturnQty = parentForm3.totalReturnQty + Convert.ToInt64(parentForm3.dataGridView2.Rows[i].Cells[7].Value);
                            parentForm3.totalReturnAmount = parentForm3.totalReturnAmount + Convert.ToDouble(parentForm3.dataGridView2.Rows[i].Cells[8].Value);
                        }

                        parentForm3.lblTotalReturnQty.Text = Convert.ToString(parentForm3.totalReturnQty);
                        parentForm3.lblTotalReturnAmount.Text = string.Format("{0:$0.00}", parentForm3.totalReturnAmount);

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("INVALID COST PRICE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtValue.SelectAll();
                        txtValue.Focus();
                        return;
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtValue_Click(object sender, EventArgs e)
        {
            txtValue.SelectAll();
            txtValue.Focus();
        }
    }
}