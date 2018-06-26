using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Management
{
    public partial class TargetField : Form
    {
        public LogInManagements parentForm1;
        public InventoryMain parentForm2;
        public EditCostPrice parentForm3;
        public POMain parentForm4;
        public InventoryMainHQ parentForm5;

        int option = 0;
        int targetOnHand;
        double targetRetailPrice, targetCostPrce, targetStylistPrice;
        int itmGroup1, itmGroup2, itmGroup3;
        bool active;

        public TargetField(int opt)
        {
            InitializeComponent();
            option = opt;
        }

        private void TargetField_Load(object sender, EventArgs e)
        {
            if (option == 0)
            {
                if (parentForm1.userLevel >= parentForm1.SystemAdministratorLV & parentForm1.employeeID.ToUpper() == parentForm1.SystemMasterUserName.ToUpper())
                {
                    rdoBtnStylistPrice.Enabled = true;
                    rdoBtnCostPrice.Enabled = true;
                }
                else if (parentForm1.userLevel < parentForm1.SystemAdministratorLV & parentForm1.userLevel >= parentForm1.GeneralManagerLV & parentForm1.txtSpecialCode.Text.Trim().ToUpper() == parentForm1.specialCode)
                {
                    rdoBtnStylistPrice.Enabled = false;
                    rdoBtnCostPrice.Enabled = true;
                }
                else
                {
                    rdoBtnRetailPrice.Enabled = false;
                    rdoBtnItemName.Enabled = false;
                    rdoBtnBrand.Enabled = false;
                    rdoBtnCategory1.Enabled = false;
                    rdoBtnCategory2.Enabled = false;
                    rdoBtnCategory3.Enabled = false;
                    rdoBtnModelNum.Enabled = false;
                    rdoBtnVendor.Enabled = false;
                    rdoBtnStylistPrice.Enabled = false;
                    rdoBtnCostPrice.Enabled = false;
                }
            }
            else if (option == 1)
            {
                rdoBtnOnHand.Enabled = false;
                rdoBtnRetailPrice.Enabled = false;
                rdoBtnBinNumber.Enabled = false;
                rdoBtnCategory1.Enabled = false;
                rdoBtnCategory2.Enabled = false;
                rdoBtnCategory3.Enabled = false;
                rdoBtnItemName.Enabled = false;
                rdoBtnBrand.Enabled = false;
                rdoBtnSubBrand.Enabled = false;
                rdoBtnModelNum.Enabled = false;
                rdoBtnVendor.Enabled = false;
                rdoBtnStylistPrice.Enabled = false;
                rdoBtnActive.Enabled = false;

                rdoBtnCostPrice.Checked = true;
            }
            else if (option == 2)
            {
                rdoBtnItemName.Enabled = false;
                rdoBtnBrand.Enabled = false;
                rdoBtnRetailPrice.Enabled = false;
                rdoBtnCategory1.Enabled = false;
                rdoBtnCategory2.Enabled = false;
                rdoBtnCategory3.Enabled = false;
                rdoBtnModelNum.Enabled = false;
                rdoBtnVendor.Enabled = false;
                rdoBtnStylistPrice.Enabled = false;
                rdoBtnCostPrice.Enabled = false;
                rdoBtnActive.Enabled = false;

                rdoBtnOnHand.Checked = true;
            }
            else if (option == 5)
            {
                if (parentForm1.userLevel >= parentForm1.SystemAdministratorLV & parentForm1.employeeID.ToUpper() == parentForm1.SystemMasterUserName.ToUpper())
                {
                    rdoBtnStylistPrice.Enabled = true;
                    rdoBtnCostPrice.Enabled = true;
                }
                else if (parentForm1.userLevel < parentForm1.SystemAdministratorLV & parentForm1.userLevel >= parentForm1.GeneralManagerLV & parentForm1.txtSpecialCode.Text.Trim().ToUpper() == parentForm1.specialCode)
                {
                    rdoBtnStylistPrice.Enabled = true;
                    rdoBtnCostPrice.Enabled = true;
                }
                else
                {
                    rdoBtnRetailPrice.Enabled = false;
                    rdoBtnCostPrice.Enabled = false;
                    rdoBtnStylistPrice.Enabled = false;
                    rdoBtnItemName.Enabled = false;
                    rdoBtnBrand.Enabled = false;
                    rdoBtnSubBrand.Enabled = false;
                    rdoBtnCategory1.Enabled = false;
                    rdoBtnCategory2.Enabled = false;
                    rdoBtnCategory3.Enabled = false;
                    rdoBtnModelNum.Enabled = false;
                    rdoBtnVendor.Enabled = false;
                }
            }

            txtValue.Select();
            txtValue.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtValue.Text == "")
            {
                MessageBox.Show("INPUT TARGET VALUE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtValue.Select();
                txtValue.Focus();
                return;
            }

            if (rdoBtnOnHand.Checked == true)
            {
                if (option == 0)
                {
                    if (int.TryParse(txtValue.Text, out targetOnHand))
                    {
                        for (int i = 0; i < parentForm2.dataGridView1.RowCount; i++)
                        {
                            parentForm2.dataGridView1.Rows[i].Cells[14].Value = targetOnHand;
                        }

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("INVALID AMOUNT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtValue.SelectAll();
                        txtValue.Focus();
                    }
                }
                else if (option == 2)
                {
                    if (int.TryParse(txtValue.Text, out targetOnHand))
                    {
                        for (int i = 0; i < parentForm4.dataGridView1.RowCount; i++)
                        {
                            parentForm4.dataGridView1.Rows[i].Cells[14].Value = targetOnHand;
                        }

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("INVALID AMOUNT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtValue.SelectAll();
                        txtValue.Focus();
                    }
                }
                else if (option == 5)
                {
                    if (int.TryParse(txtValue.Text, out targetOnHand))
                    {
                        for (int i = 0; i < parentForm5.dataGridView1.RowCount; i++)
                        {
                            parentForm5.dataGridView1.Rows[i].Cells[15].Value = targetOnHand;
                        }

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("INVALID AMOUNT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtValue.SelectAll();
                        txtValue.Focus();
                    }
                }
            }
            else if (rdoBtnRetailPrice.Checked == true)
            {
                if (option == 0)
                {
                    if (double.TryParse(txtValue.Text, out targetRetailPrice))
                    {
                        for (int i = 0; i < parentForm2.dataGridView1.RowCount; i++)
                        {
                            parentForm2.dataGridView1.Rows[i].Cells[15].Value = targetRetailPrice;
                        }

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("INVALID AMOUNT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtValue.SelectAll();
                        txtValue.Focus();
                    }
                }
                else if (option == 5)
                {
                    if (double.TryParse(txtValue.Text, out targetRetailPrice))
                    {
                        for (int i = 0; i < parentForm5.dataGridView1.RowCount; i++)
                        {
                            parentForm5.dataGridView1.Rows[i].Cells[16].Value = targetRetailPrice;
                        }

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("INVALID AMOUNT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtValue.SelectAll();
                        txtValue.Focus();
                    }
                }
            }
            else if (rdoBtnBinNumber.Checked == true)
            {
                if (option == 0)
                {
                    for (int i = 0; i < parentForm2.dataGridView1.RowCount; i++)
                    {
                        parentForm2.dataGridView1.Rows[i].Cells[29].Value = txtValue.Text.Trim().ToString().ToUpper();
                    }

                    this.Close();
                }
                else if (option == 2)
                {
                    for (int i = 0; i < parentForm4.dataGridView1.RowCount; i++)
                    {
                        parentForm4.dataGridView1.Rows[i].Cells[29].Value = txtValue.Text.Trim().ToString().ToUpper();
                    }

                    this.Close();
                }
                else if (option == 5)
                {
                    for (int i = 0; i < parentForm5.dataGridView1.RowCount; i++)
                    {
                        parentForm5.dataGridView1.Rows[i].Cells[30].Value = txtValue.Text.Trim().ToString().ToUpper();
                    }

                    this.Close();
                }
            }
            else if (rdoBtnCostPrice.Checked == true)
            {
                if (option == 0)
                {
                    if (double.TryParse(txtValue.Text, out targetCostPrce))
                    {
                        for (int i = 0; i < parentForm2.dataGridView1.RowCount; i++)
                        {
                            parentForm2.dataGridView1.Rows[i].Cells[16].Value = targetCostPrce;
                        }

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("INVALID AMOUNT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtValue.SelectAll();
                        txtValue.Focus();
                    }
                }
                else if (option == 1)
                {
                    if (parentForm1.StoreCode == "B4UHQ")
                    {
                        if (double.TryParse(txtValue.Text, out targetCostPrce))
                        {
                            for (int i = 0; i < parentForm3.dataGridView1.RowCount; i++)
                            {
                                parentForm3.dataGridView1.Rows[i].Cells[17].Value = targetCostPrce;
                            }

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("INVALID AMOUNT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtValue.SelectAll();
                            txtValue.Focus();
                        }
                    }
                    else
                    {
                        if (double.TryParse(txtValue.Text, out targetCostPrce))
                        {
                            for (int i = 0; i < parentForm3.dataGridView1.RowCount; i++)
                            {
                                parentForm3.dataGridView1.Rows[i].Cells[16].Value = targetCostPrce;
                            }

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("INVALID AMOUNT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtValue.SelectAll();
                            txtValue.Focus();
                        }
                    }
                }
                else if (option == 2)
                {
                    if (double.TryParse(txtValue.Text, out targetCostPrce))
                    {
                        for (int i = 0; i < parentForm4.dataGridView1.RowCount; i++)
                        {
                            parentForm4.dataGridView1.Rows[i].Cells[16].Value = targetCostPrce;
                        }

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("INVALID AMOUNT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtValue.SelectAll();
                        txtValue.Focus();
                    }
                }
                else if (option == 5)
                {
                    if (double.TryParse(txtValue.Text, out targetCostPrce))
                    {
                        for (int i = 0; i < parentForm5.dataGridView1.RowCount; i++)
                        {
                            parentForm5.dataGridView1.Rows[i].Cells[17].Value = targetCostPrce;
                        }

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("INVALID AMOUNT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtValue.SelectAll();
                        txtValue.Focus();
                    }
                }
            }
            else if (rdoBtnStylistPrice.Checked == true)
            {
                if (option == 0)
                {
                    if (double.TryParse(txtValue.Text, out targetStylistPrice))
                    {
                        for (int i = 0; i < parentForm2.dataGridView1.RowCount; i++)
                        {
                            parentForm2.dataGridView1.Rows[i].Cells[27].Value = targetStylistPrice;
                        }

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("INVALID AMOUNT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtValue.SelectAll();
                        txtValue.Focus();
                    }
                }
                else if(option == 5)
                {
                    if (double.TryParse(txtValue.Text, out targetStylistPrice))
                    {
                        for (int i = 0; i < parentForm5.dataGridView1.RowCount; i++)
                        {
                            parentForm5.dataGridView1.Rows[i].Cells[28].Value = targetStylistPrice;
                        }

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("INVALID AMOUNT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtValue.SelectAll();
                        txtValue.Focus();
                    }
                }
            }
            else if (rdoBtnItemName.Checked == true)
            {
                if (option == 0)
                {
                    for (int i = 0; i < parentForm2.dataGridView1.RowCount; i++)
                    {
                        parentForm2.dataGridView1.Rows[i].Cells[3].Value = txtValue.Text.Trim().ToString().ToUpper();
                    }

                    this.Close();
                }
                else if (option == 2)
                {
                    for (int i = 0; i < parentForm4.dataGridView1.RowCount; i++)
                    {
                        parentForm4.dataGridView1.Rows[i].Cells[3].Value = txtValue.Text.Trim().ToString().ToUpper();
                    }

                    this.Close();
                }
                else if (option == 5)
                {
                    for (int i = 0; i < parentForm5.dataGridView1.RowCount; i++)
                    {
                        parentForm5.dataGridView1.Rows[i].Cells[4].Value = txtValue.Text.Trim().ToString().ToUpper();
                    }

                    this.Close();
                }
            }
            else if (rdoBtnCategory1.Checked == true)
            {
                if (option == 0)
                {
                    if (int.TryParse(txtValue.Text, out itmGroup1))
                    {
                        for (int i = 0; i < parentForm2.dataGridView1.RowCount; i++)
                        {
                            parentForm2.dataGridView1.Rows[i].Cells[7].Value = itmGroup1;
                        }

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("INVALID NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtValue.SelectAll();
                        txtValue.Focus();
                    }
                }
                else if (option == 5)
                {
                    if (int.TryParse(txtValue.Text, out itmGroup1))
                    {
                        for (int i = 0; i < parentForm5.dataGridView1.RowCount; i++)
                        {
                            parentForm5.dataGridView1.Rows[i].Cells[8].Value = itmGroup1;
                        }

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("INVALID NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtValue.SelectAll();
                        txtValue.Focus();
                    }
                }
            }
            else if (rdoBtnCategory2.Checked == true)
            {
                if (option == 0)
                {
                    if (int.TryParse(txtValue.Text, out itmGroup2))
                    {
                        for (int i = 0; i < parentForm2.dataGridView1.RowCount; i++)
                        {
                            parentForm2.dataGridView1.Rows[i].Cells[8].Value = itmGroup2;
                        }

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("INVALID NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtValue.SelectAll();
                        txtValue.Focus();
                    }
                }
                else if (option == 5)
                {
                    if (int.TryParse(txtValue.Text, out itmGroup2))
                    {
                        for (int i = 0; i < parentForm5.dataGridView1.RowCount; i++)
                        {
                            parentForm5.dataGridView1.Rows[i].Cells[9].Value = itmGroup2;
                        }

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("INVALID NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtValue.SelectAll();
                        txtValue.Focus();
                    }
                }
            }
            else if (rdoBtnCategory3.Checked == true)
            {
                if (option == 0)
                {
                    if (int.TryParse(txtValue.Text, out itmGroup3))
                    {
                        for (int i = 0; i < parentForm2.dataGridView1.RowCount; i++)
                        {
                            parentForm2.dataGridView1.Rows[i].Cells[9].Value = itmGroup3;
                        }

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("INVALID NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtValue.SelectAll();
                        txtValue.Focus();
                    }
                }
                else if (option == 5)
                {
                    if (int.TryParse(txtValue.Text, out itmGroup3))
                    {
                        for (int i = 0; i < parentForm5.dataGridView1.RowCount; i++)
                        {
                            parentForm5.dataGridView1.Rows[i].Cells[10].Value = itmGroup3;
                        }

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("INVALID NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtValue.SelectAll();
                        txtValue.Focus();
                    }
                }
            }
            else if (rdoBtnBrand.Checked == true)
            {
                if (option == 0)
                {
                    for (int i = 0; i < parentForm2.dataGridView1.RowCount; i++)
                    {
                        parentForm2.dataGridView1.Rows[i].Cells[2].Value = txtValue.Text.Trim().ToString().ToUpper();
                    }

                    this.Close();
                }
                else if (option == 2)
                {
                    for (int i = 0; i < parentForm4.dataGridView1.RowCount; i++)
                    {
                        parentForm4.dataGridView1.Rows[i].Cells[2].Value = txtValue.Text.Trim().ToString().ToUpper();
                    }

                    this.Close();
                }
                else if (option == 5)
                {
                    for (int i = 0; i < parentForm5.dataGridView1.RowCount; i++)
                    {
                        parentForm5.dataGridView1.Rows[i].Cells[2].Value = txtValue.Text.Trim().ToString().ToUpper();
                    }

                    this.Close();
                }
            }
            else if (rdoBtnSubBrand.Checked == true)
            {
                if (option == 0)
                {
                    for (int i = 0; i < parentForm2.dataGridView1.RowCount; i++)
                    {
                        parentForm2.dataGridView1.Rows[i].Cells[2].Value = txtValue.Text.Trim().ToString().ToUpper();
                    }

                    this.Close();
                }
                else if (option == 2)
                {
                    for (int i = 0; i < parentForm4.dataGridView1.RowCount; i++)
                    {
                        parentForm4.dataGridView1.Rows[i].Cells[2].Value = txtValue.Text.Trim().ToString().ToUpper();
                    }

                    this.Close();
                }
                else if (option == 5)
                {
                    for (int i = 0; i < parentForm5.dataGridView1.RowCount; i++)
                    {
                        parentForm5.dataGridView1.Rows[i].Cells[3].Value = txtValue.Text.Trim().ToString().ToUpper();
                    }

                    this.Close();
                }
            }
            else if (rdoBtnModelNum.Checked == true)
            {
                if (option == 0)
                {
                    for (int i = 0; i < parentForm2.dataGridView1.RowCount; i++)
                    {
                        parentForm2.dataGridView1.Rows[i].Cells[6].Value = txtValue.Text.Trim().ToString().ToUpper();
                    }

                    this.Close();
                }
                else if (option == 5)
                {
                    for (int i = 0; i < parentForm5.dataGridView1.RowCount; i++)
                    {
                        parentForm5.dataGridView1.Rows[i].Cells[7].Value = txtValue.Text.Trim().ToString().ToUpper();
                    }

                    this.Close();
                }
            }
            else if (rdoBtnVendor.Checked == true)
            {
                if (option == 0)
                {
                    for (int i = 0; i < parentForm2.dataGridView1.RowCount; i++)
                    {
                        parentForm2.dataGridView1.Rows[i].Cells[30].Value = txtValue.Text.Trim().ToString().ToUpper();
                    }

                    this.Close();
                }
                else if (option == 5)
                {
                    for (int i = 0; i < parentForm5.dataGridView1.RowCount; i++)
                    {
                        parentForm5.dataGridView1.Rows[i].Cells[31].Value = txtValue.Text.Trim().ToString().ToUpper();
                    }

                    this.Close();
                }
            }
            else if (rdoBtnActive.Checked == true)
            {
                if (option == 0)
                {
                    if (txtValue.Text.Trim().ToUpper() == "TRUE")
                    {
                        active = true;

                        for (int i = 0; i < parentForm2.dataGridView1.RowCount; i++)
                        {
                            parentForm2.dataGridView1.Rows[i].Cells[38].Value = active;
                        }

                        this.Close();
                    }
                    else if (txtValue.Text.Trim().ToUpper() == "FALSE")
                    {
                        active = false;

                        for (int i = 0; i < parentForm2.dataGridView1.RowCount; i++)
                        {
                            parentForm2.dataGridView1.Rows[i].Cells[38].Value = active;
                        }

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("INPUT TRUE OR FALSE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtValue.SelectAll();
                        txtValue.Focus();
                    }
                }
                else if (option == 5)
                {
                    if (txtValue.Text.Trim().ToUpper() == "TRUE")
                    {
                        active = true;

                        for (int i = 0; i < parentForm5.dataGridView1.RowCount; i++)
                        {
                            parentForm5.dataGridView1.Rows[i].Cells[42].Value = active;
                        }

                        this.Close();
                    }
                    else if (txtValue.Text.Trim().ToUpper() == "FALSE")
                    {
                        active = false;

                        for (int i = 0; i < parentForm5.dataGridView1.RowCount; i++)
                        {
                            parentForm5.dataGridView1.Rows[i].Cells[42].Value = active;
                        }

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("INPUT TRUE OR FALSE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtValue.SelectAll();
                        txtValue.Focus();
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoBtnOnHand_CheckedChanged(object sender, EventArgs e)
        {
            txtValue.Select();
            txtValue.Focus();
        }            
    }
}