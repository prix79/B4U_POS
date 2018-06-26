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
    public partial class InputOnhand : Form
    {
        public LogInManagements parentForm1;
        public ItemInformation parentForm2;
        public InventoryMain parentForm3;
        public ItemSoldList parentForm4;
        public InventoryMainHQ parentForm5;
        public ItemSoldListForReturn parentForm6;
        Int64 newOnhand = 0;

        public InputOnhand()
        {
            InitializeComponent();
        }

        private void InputOnhand_Load(object sender, EventArgs e)
        {
            lblOldOnhand.Text = parentForm2.lblOnhand.Text;

            txtNewOnhand.SelectAll();
            txtNewOnhand.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "ARE YOU SURE?", "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
            {
                if (Int64.TryParse(txtNewOnhand.Text, out newOnhand))
                {
                    if (newOnhand >= 0)
                    {
                        try
                        {
                            if (parentForm2.option == 0)
                            {
                                SqlCommand cmd = new SqlCommand("Update_Onhand", parentForm1.conn);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = parentForm2.itmUpc;
                                cmd.Parameters.Add("@NewOnhand", SqlDbType.Int).Value = newOnhand;

                                parentForm1.conn.Open();
                                cmd.ExecuteNonQuery();
                                parentForm1.conn.Close();

                                parentForm2.ItemInformation_Load(null, null);
                                parentForm3.btnSearch_Click(null, null);
                                this.Close();
                            }
                            else if (parentForm2.option == 1)
                            {
                                SqlCommand cmd = new SqlCommand("Update_Onhand", parentForm1.conn);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = parentForm2.itmUpc;
                                cmd.Parameters.Add("@NewOnhand", SqlDbType.Int).Value = newOnhand;

                                parentForm1.conn.Open();
                                cmd.ExecuteNonQuery();
                                parentForm1.conn.Close();

                                parentForm2.ItemInformation_Load(null, null);
                                parentForm4.btnOK_Click(null, null);
                                this.Close();
                            }
                            else if (parentForm2.option == 2)
                            {
                                SqlCommand cmd = new SqlCommand("Update_Onhand", parentForm1.conn);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = parentForm2.itmUpc;
                                cmd.Parameters.Add("@NewOnhand", SqlDbType.Int).Value = newOnhand;

                                parentForm1.conn.Open();
                                cmd.ExecuteNonQuery();
                                parentForm1.conn.Close();

                                parentForm2.ItemInformation_Load(null, null);
                                parentForm5.btnSearch_Click(null, null);
                                this.Close();
                            }
                            else if (parentForm2.option == 3)
                            {
                                SqlCommand cmd = new SqlCommand("Update_Onhand", parentForm1.conn);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add("@ItmUpc", SqlDbType.NVarChar).Value = parentForm2.itmUpc;
                                cmd.Parameters.Add("@NewOnhand", SqlDbType.Int).Value = newOnhand;

                                parentForm1.conn.Open();
                                cmd.ExecuteNonQuery();
                                parentForm1.conn.Close();

                                parentForm2.ItemInformation_Load(null, null);
                                parentForm6.btnOK_Click(null, null);
                                this.Close();
                            }
                        }
                        catch
                        {
                            MessageBox.Show("UPDATE FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            parentForm1.conn.Close();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("INVALID VALUE (NAGATIVE NUMBER)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtNewOnhand.SelectAll();
                        txtNewOnhand.Focus();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("INVALID VALUE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNewOnhand.SelectAll();
                    txtNewOnhand.Focus();
                    return;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNewOnhand_Click(object sender, EventArgs e)
        {
            txtNewOnhand.SelectAll();
            txtNewOnhand.Focus();
        }
    }
}