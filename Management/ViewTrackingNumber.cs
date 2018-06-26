using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Management
{
    public partial class ViewTrackingNumber : Form
    {
        public LogInManagements parentForm1;
        public ItemSoldListForReturn parentForm2;

        SqlConnection conn;
        SqlCommand cmd;

        public ViewTrackingNumber()
        {
            InitializeComponent();
        }

        private void ViewTrackingNumber_Load(object sender, EventArgs e)
        {
            this.Text = "VIEW TRACKING NUMBER";

            Show_TrackingNumber(parentForm2.RRID, parentForm1.StoreCode);
            txtTrackingNumber.DeselectAll();
            btnClose.Select();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Show_TrackingNumber(Int64 RID, string SC)
        {
            try
            {
                conn = new SqlConnection(parentForm1.OtherStoreConnectionString(SC));
                cmd = new SqlCommand("Get_TrackingNumber", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@rrID", SqlDbType.BigInt).Value = RID;
                SqlParameter CMCount_Param = cmd.Parameters.Add("@TrackingNumber", SqlDbType.NVarChar, 500);
                CMCount_Param.Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                if (cmd.Parameters["@TrackingNumber"].Value != DBNull.Value)
                    txtTrackingNumber.Text = cmd.Parameters["@TrackingNumber"].Value.ToString();
            }
            catch
            {
                MessageBox.Show("DB CONNECTION FAILED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                return;
            }
        }
    }
}