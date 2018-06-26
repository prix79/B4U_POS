using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Office_12 = Microsoft.Office.Core;
using Excel_12 = Microsoft.Office.Interop.Excel;
using System.Globalization;

namespace Management
{
    public partial class ManageGiftcard : Form
    {
        public LogInManagements parentForm;
        SqlCommand cmd;
        DataTable dt;

        public int startNum, endNum, yearNum, numOfgiftcard;
        public double amount;

        public ManageGiftcard()
        {
            InitializeComponent();
        }

        private void ManageGiftcard_Load(object sender, EventArgs e)
        {
            this.Text = "MANAGE GIFTCARD (STORE LOCATION : " + parentForm.storeName.ToUpper() + ")";
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Load_Giftcard_All", parentForm.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            parentForm.conn.Open();
            adapter.Fill(dt);
            parentForm.conn.Close();

            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.DataSource = dt;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateGiftcard createGiftcardForm = new CreateGiftcard();
            createGiftcardForm.parentForm = this;
            createGiftcardForm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Giftcard_Validation()
        {
        }

        public void Create_Giftcard(double amt)
        {
            if (amt == 25)
            {
                for (int i = startNum; i <= endNum; i++)
                {
                    cmd = new SqlCommand("Create_Giftcard", parentForm.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = parentForm.StoreCode.ToString().ToUpper();
                    //cmd.Parameters.Add("@GiftCardCode", SqlDbType.NVarChar).Value = DateTime.Today.Year.ToString() + "1" + string.Format("{0:0000}", i).ToString();
                    cmd.Parameters.Add("@GiftCardCode", SqlDbType.NVarChar).Value = yearNum.ToString() + "1" + string.Format("{0:0000}", i).ToString();
                    cmd.Parameters.Add("@Amount", SqlDbType.Money).Value = 25;
                    cmd.Parameters.Add("@Balance", SqlDbType.Money).Value = 25;
                    //cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                    //cmd.Parameters.Add("@ExpDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today.AddYears(1));
                    cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = false;

                    parentForm.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm.conn.Close();
                }
            }
            else if (amt == 50)
            {
                for (int i = startNum; i <= endNum; i++)
                {
                    cmd = new SqlCommand("Create_Giftcard", parentForm.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = parentForm.StoreCode.ToString().ToUpper();
                    cmd.Parameters.Add("@GiftCardCode", SqlDbType.NVarChar).Value = yearNum.ToString() + "2" + string.Format("{0:0000}", i).ToString();
                    cmd.Parameters.Add("@Amount", SqlDbType.Money).Value = 50;
                    cmd.Parameters.Add("@Balance", SqlDbType.Money).Value = 50;
                    //cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                    //cmd.Parameters.Add("@ExpDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today.AddYears(1));
                    cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = false;

                    parentForm.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm.conn.Close();
                }
            }
            else if (amt == 100)
            {
                for (int i = startNum; i <= endNum; i++)
                {
                    cmd = new SqlCommand("Create_Giftcard", parentForm.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@StoreCode", SqlDbType.NVarChar).Value = parentForm.StoreCode.ToString().ToUpper();
                    cmd.Parameters.Add("@GiftCardCode", SqlDbType.NVarChar).Value = yearNum.ToString() + "3" + string.Format("{0:0000}", i).ToString();
                    cmd.Parameters.Add("@Amount", SqlDbType.Money).Value = 100;
                    cmd.Parameters.Add("@Balance", SqlDbType.Money).Value = 100;
                    //cmd.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today);
                    //cmd.Parameters.Add("@ExpDate", SqlDbType.NVarChar).Value = string.Format("{0:MM/dd/yyyy}", DateTime.Today.AddYears(1));
                    cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = false;

                    parentForm.conn.Open();
                    cmd.ExecuteNonQuery();
                    parentForm.conn.Close();
                }
            }

            btnLoad_Click(null, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Selected == true)
                    {
                        cmd = new SqlCommand("Delete_Giftcard", parentForm.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@GiftCardNum", SqlDbType.BigInt).Value = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);

                        parentForm.conn.Open();
                        cmd.ExecuteNonQuery();
                        parentForm.conn.Close();
                    }
                }

                btnLoad_Click(null, null);
            }
        }
    }
}