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
    public partial class CategoryUpdates : Form
    {
        public LogInManagements parentForm;
        SqlCommand cmd = new SqlCommand();
        int currentCategory1, currentCategory2, currentCategory3;
        int newCategory1, newCategory2, newCategory3;
        int btnCheck = 0;

        public CategoryUpdates()
        {
            InitializeComponent();
        }

        private void CategoryUpdates_Load(object sender, EventArgs e)
        {
            this.Text = "CATEGORY UPDATES - " + parentForm.storeName.ToUpper();

            txtCI1.Select();
            txtCI1.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtCI1.Text, out currentCategory1))
            {
            }
            else
            {
                MessageBox.Show("INVALID VALUE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCI1.SelectAll();
                txtCI1.Focus();
                return;
            }

            if (int.TryParse(txtCI2.Text, out currentCategory2))
            {
            }
            else
            {
                MessageBox.Show("INVALID VALUE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCI2.SelectAll();
                txtCI2.Focus();
                return;
            }

            if (int.TryParse(txtCI3.Text, out currentCategory3))
            {
            }
            else
            {
                MessageBox.Show("INVALID VALUE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCI3.SelectAll();
                txtCI3.Focus();
                return;
            }

            if (int.TryParse(txtNI1.Text, out newCategory1))
            {
            }
            else
            {
                MessageBox.Show("INVALID VALUE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNI1.SelectAll();
                txtNI1.Focus();
                return;
            }

            if (int.TryParse(txtNI2.Text, out newCategory2))
            {
            }
            else
            {
                MessageBox.Show("INVALID VALUE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNI2.SelectAll();
                txtNI2.Focus();
                return;
            }

            if (int.TryParse(txtNI3.Text, out newCategory3))
            {
            }
            else
            {
                MessageBox.Show("INVALID VALUE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNI3.SelectAll();
                txtNI3.Focus();
                return;
            }

            if (chkInventory.Checked == true)
                btnCheck = btnCheck + 1;

            if (chkSalesData.Checked == true)
                btnCheck = btnCheck + 1;

            if (btnCheck == 0)
            {
                MessageBox.Show("PLEASE CHECK THE TARGET", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
            {
                //try
                //{
                    if (btnCheck == 1)
                    {
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = btnCheck;
                        progressBar1.Step = 1;

                        if (chkInventory.Checked == true)
                        {
                            cmd.Connection = parentForm.conn;
                            cmd.CommandText = "Update_Category_To_Inventory";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@CurrentItmGroup1", SqlDbType.NVarChar).Value = currentCategory1;
                            cmd.Parameters.Add("@CurrentItmGroup2", SqlDbType.NVarChar).Value = currentCategory2;
                            cmd.Parameters.Add("@CurrentItmGroup3", SqlDbType.NVarChar).Value = currentCategory3;
                            cmd.Parameters.Add("@NewItmGroup1", SqlDbType.NVarChar).Value = newCategory1;
                            cmd.Parameters.Add("@NewItmGroup2", SqlDbType.NVarChar).Value = newCategory2;
                            cmd.Parameters.Add("@NewItmGroup3", SqlDbType.NVarChar).Value = newCategory3;

                            parentForm.conn.Open();
                            cmd.ExecuteNonQuery();
                            parentForm.conn.Close();
                        }
                        else if (chkSalesData.Checked == true)
                        {
                            cmd.Connection = parentForm.conn;
                            cmd.CommandText = "Update_Category_To_ReceiptBody";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@CurrentItmGroup1", SqlDbType.NVarChar).Value = currentCategory1;
                            cmd.Parameters.Add("@CurrentItmGroup2", SqlDbType.NVarChar).Value = currentCategory2;
                            cmd.Parameters.Add("@CurrentItmGroup3", SqlDbType.NVarChar).Value = currentCategory3;
                            cmd.Parameters.Add("@NewItmGroup1", SqlDbType.NVarChar).Value = newCategory1;
                            cmd.Parameters.Add("@NewItmGroup2", SqlDbType.NVarChar).Value = newCategory2;
                            cmd.Parameters.Add("@NewItmGroup3", SqlDbType.NVarChar).Value = newCategory3;

                            parentForm.conn.Open();
                            cmd.ExecuteNonQuery();
                            parentForm.conn.Close();
                        }
                    }
                    else if (btnCheck == 2)
                    {
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = btnCheck;
                        progressBar1.Step = 1;

                        cmd.Connection = parentForm.conn;
                        cmd.CommandText = "Update_Category_To_Inventory";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@CurrentItmGroup1", SqlDbType.NVarChar).Value = currentCategory1;
                        cmd.Parameters.Add("@CurrentItmGroup2", SqlDbType.NVarChar).Value = currentCategory2;
                        cmd.Parameters.Add("@CurrentItmGroup3", SqlDbType.NVarChar).Value = currentCategory3;
                        cmd.Parameters.Add("@NewItmGroup1", SqlDbType.NVarChar).Value = newCategory1;
                        cmd.Parameters.Add("@NewItmGroup2", SqlDbType.NVarChar).Value = newCategory2;
                        cmd.Parameters.Add("@NewItmGroup3", SqlDbType.NVarChar).Value = newCategory3;

                        parentForm.conn.Open();
                        cmd.ExecuteNonQuery();
                        parentForm.conn.Close();

                        progressBar1.PerformStep();

                        cmd.CommandText = "Update_Category_To_ReceiptBody";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@CurrentItmGroup1", SqlDbType.NVarChar).Value = currentCategory1;
                        cmd.Parameters.Add("@CurrentItmGroup2", SqlDbType.NVarChar).Value = currentCategory2;
                        cmd.Parameters.Add("@CurrentItmGroup3", SqlDbType.NVarChar).Value = currentCategory3;
                        cmd.Parameters.Add("@NewItmGroup1", SqlDbType.NVarChar).Value = newCategory1;
                        cmd.Parameters.Add("@NewItmGroup2", SqlDbType.NVarChar).Value = newCategory2;
                        cmd.Parameters.Add("@NewItmGroup3", SqlDbType.NVarChar).Value = newCategory3;

                        parentForm.conn.Open();
                        cmd.ExecuteNonQuery();
                        parentForm.conn.Close();

                        progressBar1.PerformStep();
                        Application.DoEvents();
                    }

                    MessageBox.Show("SUCCESSFULLY UPDATES COMPLETE", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    progressBar1.Value = 0;
                    btnCheck = 0;
                    txtCI1.Clear();
                    txtCI2.Clear();
                    txtCI3.Clear();
                    txtNI1.Clear();
                    txtNI2.Clear();
                    txtNI3.Clear();
                    txtCI1.Select();
                    txtCI1.Focus();
                /*}
                catch
                {
                    MessageBox.Show("DB UPDATE FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    parentForm.conn.Close();
                    return;
                }*/
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}