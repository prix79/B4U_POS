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
    public partial class ChangeStore : Form
    {
        public LogInManagements parentForm1;
        public ManagementsMain parentForm2;
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        //SqlConnection conn;
        //string tempConnectionString, tempStoreName, tempStoreCode;
        string storeName;

        public ChangeStore()
        {
            InitializeComponent();
        }

        private void ChangeStore_Load(object sender, EventArgs e)
        {
            if (parentForm1.storeName == "TEST2")
            {
                MessageBox.Show("Can not use this function at current store.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            if (parentForm1.StoreCode == "B4UHQ")
            {
                rdoBtnBeauty4UHeadquarters.Checked = true;
            }
            else if (parentForm1.StoreCode == "B4UWH")
            {
                rdoBtnBeauty4UWarehouse.Checked = true;
            }
            else if (parentForm1.StoreCode == "CH")
            {
                rdoBtnCapitolHeights.Checked = true;
            }
            else if (parentForm1.StoreCode == "OH")
            {
                rdoBtnOxonHill.Checked = true;
            }
            else if (parentForm1.StoreCode == "WB")
            {
                rdoBtnWoodbridge.Checked = true;
            }
            else if (parentForm1.StoreCode == "CV")
            {
                rdoBtnCatonsville.Checked = true;
            }
            else if (parentForm1.StoreCode == "UM")
            {
                rdoBtnUpperMarlboro.Checked = true;
            }
            else if (parentForm1.StoreCode == "WM")
            {
                rdoBtnWindsorMill.Checked = true;
            }
            else if (parentForm1.StoreCode == "TH")
            {
                rdoBtnTempleHills.Checked = true;
            }
            else if (parentForm1.StoreCode == "WD")
            {
                rdoBtnWaldorf.Checked = true;
            }
            else if (parentForm1.StoreCode == "PW")
            {
                rdoBtnPrinceWilliam.Checked = true;
            }
            else if (parentForm1.StoreCode == "GB")
            {
                rdoBtnGaithersburg.Checked = true;
            }
            else if (parentForm1.StoreCode == "BW")
            {
                rdoBtnBowie.Checked = true;
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            //tempConnectionString = parentForm1.serverConnectionString;
            //tempStoreName = parentForm1.storeName;
            //tempStoreCode = parentForm1.StoreCode;

            if(parentForm1.originalUserLevel < parentForm1.btnManagementChangeStore)
            {
                MessageBox.Show("You are not authorized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (rdoBtnCapitolHeights.Checked == true)
                {
                    if (DBConnectionStatus(parentForm1.CHCS_IP) == true)
                    {
                        storeName = "CAPITOL HEIGHTS";

                        if (parentForm1.UserChecking("CH") == 0)
                        {
                            MessageBox.Show("You are not authorized to access " + storeName + " store.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            parentForm1.userLevel = parentForm1.UserChecking("CH");
                        }
                        
                        parentForm1.CHCS = parentForm1.CHCS_IP;

                        parentForm1.cmbStoreName.DropDownStyle = ComboBoxStyle.Simple;
                        parentForm1.cmbStoreName.Text = storeName;
                        parentForm1.boolBtnConnect = true;
                        parentForm1.btnConnect_Click(null, null);

                        MessageBox.Show("The server has changed to " + parentForm1.storeName + " store successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                        for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                        {
                            if (Application.OpenForms[i].Name == "LogInManagements")
                            {
                            }
                            else if (Application.OpenForms[i].Name == "ManagementsMain")
                            {
                            }
                            else
                            {
                                Application.OpenForms[i].Close();
                            }
                        }

                        parentForm2.ManagementsMain_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("The server connect failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (rdoBtnOxonHill.Checked == true)
                {
                    if (DBConnectionStatus(parentForm1.OHCS_IP) == true)
                    {
                        storeName = "OXON HILL";

                        if (parentForm1.UserChecking("OH") == 0)
                        {
                            MessageBox.Show("You are not authorized to access " + storeName + " store.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            parentForm1.userLevel = parentForm1.UserChecking("OH");
                        }

                        parentForm1.OHCS = parentForm1.OHCS_IP;

                        parentForm1.cmbStoreName.DropDownStyle = ComboBoxStyle.Simple;
                        parentForm1.cmbStoreName.Text = storeName;
                        parentForm1.boolBtnConnect = true;
                        parentForm1.btnConnect_Click(null, null);

                        MessageBox.Show("The server has changed to " + parentForm1.storeName + " store successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                        for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                        {
                            if (Application.OpenForms[i].Name == "LogInManagements")
                            {
                            }
                            else if (Application.OpenForms[i].Name == "ManagementsMain")
                            {
                            }
                            else
                            {
                                Application.OpenForms[i].Close();
                            }
                        }

                        parentForm2.ManagementsMain_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("The server connect failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (rdoBtnWoodbridge.Checked == true)
                {
                    if (DBConnectionStatus(parentForm1.WBCS_IP) == true)
                    {
                        storeName = "WOODBRIDGE";

                        if (parentForm1.UserChecking("WB") == 0)
                        {
                            MessageBox.Show("You are not authorized to access " + storeName + " store.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            parentForm1.userLevel = parentForm1.UserChecking("WB");
                        }

                        parentForm1.WBCS = parentForm1.WBCS_IP;

                        parentForm1.cmbStoreName.DropDownStyle = ComboBoxStyle.Simple;
                        parentForm1.cmbStoreName.Text = storeName;
                        parentForm1.boolBtnConnect = true;
                        parentForm1.btnConnect_Click(null, null);

                        MessageBox.Show("The server has changed to " + parentForm1.storeName + " store successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                        for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                        {
                            if (Application.OpenForms[i].Name == "LogInManagements")
                            {
                            }
                            else if (Application.OpenForms[i].Name == "ManagementsMain")
                            {
                            }
                            else
                            {
                                Application.OpenForms[i].Close();
                            }
                        }

                        parentForm2.ManagementsMain_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("The server connect failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (rdoBtnCatonsville.Checked == true)
                {
                    if (DBConnectionStatus(parentForm1.CVCS_IP) == true)
                    {
                        storeName = "CATONSVILLE";

                        if (parentForm1.UserChecking("CV") == 0)
                        {
                            MessageBox.Show("You are not authorized to access " + storeName + " store.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            parentForm1.userLevel = parentForm1.UserChecking("CV");
                        }

                        parentForm1.CVCS = parentForm1.CVCS_IP;

                        parentForm1.cmbStoreName.DropDownStyle = ComboBoxStyle.Simple;
                        parentForm1.cmbStoreName.Text = storeName;
                        parentForm1.boolBtnConnect = true;
                        parentForm1.btnConnect_Click(null, null);

                        MessageBox.Show("The server has changed to " + parentForm1.storeName + " store successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                        for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                        {
                            if (Application.OpenForms[i].Name == "LogInManagements")
                            {
                            }
                            else if (Application.OpenForms[i].Name == "ManagementsMain")
                            {
                            }
                            else
                            {
                                Application.OpenForms[i].Close();
                            }
                        }

                        parentForm2.ManagementsMain_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("The server connect failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (rdoBtnUpperMarlboro.Checked == true)
                {
                    if (DBConnectionStatus(parentForm1.UMCS_IP) == true)
                    {
                        storeName = "UPPER MARLBORO";

                        if (parentForm1.UserChecking("UM") == 0)
                        {
                            MessageBox.Show("You are not authorized to access " + storeName + " store.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            parentForm1.userLevel = parentForm1.UserChecking("UM");
                        }

                        parentForm1.UMCS = parentForm1.UMCS_IP;

                        parentForm1.cmbStoreName.DropDownStyle = ComboBoxStyle.Simple;
                        parentForm1.cmbStoreName.Text = storeName;
                        parentForm1.boolBtnConnect = true;
                        parentForm1.btnConnect_Click(null, null);

                        MessageBox.Show("The server has changed to " + parentForm1.storeName + " store successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                        for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                        {
                            if (Application.OpenForms[i].Name == "LogInManagements")
                            {
                            }
                            else if (Application.OpenForms[i].Name == "ManagementsMain")
                            {
                            }
                            else
                            {
                                Application.OpenForms[i].Close();
                            }
                        }

                        parentForm2.ManagementsMain_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("The server connect failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (rdoBtnWindsorMill.Checked == true)
                {
                    if (DBConnectionStatus(parentForm1.WMCS_IP) == true)
                    {
                        storeName = "WINDSOR MILL";

                        if (parentForm1.UserChecking("WM") == 0)
                        {
                            MessageBox.Show("You are not authorized to access " + storeName + " store.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            parentForm1.userLevel = parentForm1.UserChecking("WM");
                        }

                        parentForm1.WMCS = parentForm1.WMCS_IP;

                        parentForm1.cmbStoreName.DropDownStyle = ComboBoxStyle.Simple;
                        parentForm1.cmbStoreName.Text = storeName;
                        parentForm1.boolBtnConnect = true;
                        parentForm1.btnConnect_Click(null, null);

                        MessageBox.Show("The server has changed to " + parentForm1.storeName + " store successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                        for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                        {
                            if (Application.OpenForms[i].Name == "LogInManagements")
                            {
                            }
                            else if (Application.OpenForms[i].Name == "ManagementsMain")
                            {
                            }
                            else
                            {
                                Application.OpenForms[i].Close();
                            }
                        }

                        parentForm2.ManagementsMain_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("The server connect failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (rdoBtnTempleHills.Checked == true)
                {
                    if (DBConnectionStatus(parentForm1.THCS_IP) == true)
                    {
                        storeName = "TEMPLE HILLS";

                        if (parentForm1.UserChecking("TH") == 0)
                        {
                            MessageBox.Show("You are not authorized to access " + storeName + " store.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            parentForm1.userLevel = parentForm1.UserChecking("TH");
                        }

                        parentForm1.THCS = parentForm1.THCS_IP;

                        parentForm1.cmbStoreName.DropDownStyle = ComboBoxStyle.Simple;
                        parentForm1.cmbStoreName.Text = storeName;
                        parentForm1.boolBtnConnect = true;
                        parentForm1.btnConnect_Click(null, null);

                        MessageBox.Show("The server has changed to " + parentForm1.storeName + " store successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                        for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                        {
                            if (Application.OpenForms[i].Name == "LogInManagements")
                            {
                            }
                            else if (Application.OpenForms[i].Name == "ManagementsMain")
                            {
                            }
                            else
                            {
                                Application.OpenForms[i].Close();
                            }
                        }

                        parentForm2.ManagementsMain_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("The server connect failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (rdoBtnWaldorf.Checked == true)
                {
                    if (DBConnectionStatus(parentForm1.WDCS_IP) == true)
                    {
                        storeName = "WALDORF";

                        if (parentForm1.UserChecking("WD") == 0)
                        {
                            MessageBox.Show("You are not authorized to access " + storeName + " store.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            parentForm1.userLevel = parentForm1.UserChecking("WD");
                        }

                        parentForm1.WDCS = parentForm1.WDCS_IP;

                        parentForm1.cmbStoreName.DropDownStyle = ComboBoxStyle.Simple;
                        parentForm1.cmbStoreName.Text = storeName;
                        parentForm1.boolBtnConnect = true;
                        parentForm1.btnConnect_Click(null, null);

                        MessageBox.Show("The server has changed to " + parentForm1.storeName + " store successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                        for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                        {
                            if (Application.OpenForms[i].Name == "LogInManagements")
                            {
                            }
                            else if (Application.OpenForms[i].Name == "ManagementsMain")
                            {
                            }
                            else
                            {
                                Application.OpenForms[i].Close();
                            }
                        }

                        parentForm2.ManagementsMain_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("The server connect failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (rdoBtnPrinceWilliam.Checked == true)
                {
                    if (DBConnectionStatus(parentForm1.PWCS_IP) == true)
                    {
                        storeName = "PRINCE WILLIAM";

                        if (parentForm1.UserChecking("PW") == 0)
                        {
                            MessageBox.Show("You are not authorized to access " + storeName + " store.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            parentForm1.userLevel = parentForm1.UserChecking("PW");
                        }

                        parentForm1.PWCS = parentForm1.PWCS_IP;

                        parentForm1.cmbStoreName.DropDownStyle = ComboBoxStyle.Simple;
                        parentForm1.cmbStoreName.Text = storeName;
                        parentForm1.boolBtnConnect = true;
                        parentForm1.btnConnect_Click(null, null);

                        MessageBox.Show("The server has changed to " + parentForm1.storeName + " store successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                        for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                        {
                            if (Application.OpenForms[i].Name == "LogInManagements")
                            {
                            }
                            else if (Application.OpenForms[i].Name == "ManagementsMain")
                            {
                            }
                            else
                            {
                                Application.OpenForms[i].Close();
                            }
                        }

                        parentForm2.ManagementsMain_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("The server connect failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (rdoBtnGaithersburg.Checked == true)
                {
                    if (DBConnectionStatus(parentForm1.GBCS_IP) == true)
                    {
                        storeName = "GAITHERSBURG";

                        if (parentForm1.UserChecking("GB") == 0)
                        {
                            MessageBox.Show("You are not authorized to access " + storeName + " store.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            parentForm1.userLevel = parentForm1.UserChecking("GB");
                        }

                        parentForm1.GBCS = parentForm1.GBCS_IP;

                        parentForm1.cmbStoreName.DropDownStyle = ComboBoxStyle.Simple;
                        parentForm1.cmbStoreName.Text = storeName;
                        parentForm1.boolBtnConnect = true;
                        parentForm1.btnConnect_Click(null, null);

                        MessageBox.Show("The server has changed to " + parentForm1.storeName + " store successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                        for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                        {
                            if (Application.OpenForms[i].Name == "LogInManagements")
                            {
                            }
                            else if (Application.OpenForms[i].Name == "ManagementsMain")
                            {
                            }
                            else
                            {
                                Application.OpenForms[i].Close();
                            }
                        }

                        parentForm2.ManagementsMain_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("The server connect failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (rdoBtnBowie.Checked == true)
                {
                    if (DBConnectionStatus(parentForm1.BWCS_IP) == true)
                    {
                        storeName = "BOWIE";

                        if (parentForm1.UserChecking("BW") == 0)
                        {
                            MessageBox.Show("You are not authorized to access " + storeName + " store.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            parentForm1.userLevel = parentForm1.UserChecking("BW");
                        }

                        parentForm1.BWCS = parentForm1.BWCS_IP;

                        parentForm1.cmbStoreName.DropDownStyle = ComboBoxStyle.Simple;
                        parentForm1.cmbStoreName.Text = storeName;
                        parentForm1.boolBtnConnect = true;
                        parentForm1.btnConnect_Click(null, null);

                        MessageBox.Show("The server has changed to " + parentForm1.storeName + " store successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                        for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                        {
                            if (Application.OpenForms[i].Name == "LogInManagements")
                            {
                            }
                            else if (Application.OpenForms[i].Name == "ManagementsMain")
                            {
                            }
                            else
                            {
                                Application.OpenForms[i].Close();
                            }
                        }

                        parentForm2.ManagementsMain_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("The server connect failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (rdoBtnBeauty4UWarehouse.Checked == true)
                {
                    if (DBConnectionStatus(parentForm1.B4UWHCS_IP) == true)
                    {
                        storeName = "BEAUTY 4U WAREHOUSE";

                        if (parentForm1.UserChecking("B4UWH") == 0)
                        {
                            MessageBox.Show("You are not authorized to access " + storeName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            parentForm1.userLevel = parentForm1.UserChecking("B4UWH");
                        }

                        parentForm1.B4UWHCS = parentForm1.B4UWHCS_IP;

                        parentForm1.cmbStoreName.DropDownStyle = ComboBoxStyle.Simple;
                        parentForm1.cmbStoreName.Text = storeName;
                        parentForm1.boolBtnConnect = true;
                        parentForm1.btnConnect_Click(null, null);

                        MessageBox.Show("The server has changed to " + parentForm1.storeName + " successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                        for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                        {
                            if (Application.OpenForms[i].Name == "LogInManagements")
                            {
                            }
                            else if (Application.OpenForms[i].Name == "ManagementsMain")
                            {
                            }
                            else
                            {
                                Application.OpenForms[i].Close();
                            }
                        }

                        parentForm2.ManagementsMain_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("The server connect failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (rdoBtnBeauty4UHeadquarters.Checked == true)
                {
                    if (DBConnectionStatus(parentForm1.B4UHQCS_IP) == true)
                    {
                        SqlConnection newConn = new SqlConnection(parentForm1.B4UHQCS_IP);
                        SqlCommand cmd = new SqlCommand("Check_HQ_Employee", newConn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@LoginID", SqlDbType.NVarChar).Value = parentForm1.employeeID.ToUpper();
                        cmd.Parameters.Add("@HQStoreCode", SqlDbType.NVarChar).Value = "B4UHQ";
                        SqlParameter CheckNum_Param = cmd.Parameters.Add("@CheckNum", SqlDbType.Int);
                        CheckNum_Param.Direction = ParameterDirection.Output;

                        newConn.Open();
                        cmd.ExecuteNonQuery();
                        newConn.Close();

                        if (Convert.ToInt16(cmd.Parameters["@CheckNum"].Value) == 0)
                        {
                            if (parentForm1.employeeID == parentForm1.SystemMasterUserName)
                            {
                                storeName = "BEAUTY 4U HEADQUARTERS";
                                parentForm1.B4UHQCS = parentForm1.B4UHQCS_IP;

                                parentForm1.cmbStoreName.DropDownStyle = ComboBoxStyle.Simple;
                                parentForm1.cmbStoreName.Text = storeName;
                                parentForm1.boolBtnConnect = true;
                                parentForm1.btnConnect_Click(null, null);

                                MessageBox.Show("The server has changed to " + parentForm1.storeName + " successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();

                                for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                                {
                                    if (Application.OpenForms[i].Name == "LogInManagements")
                                    {
                                    }
                                    else if (Application.OpenForms[i].Name == "ManagementsMain")
                                    {
                                    }
                                    else
                                    {
                                        Application.OpenForms[i].Close();
                                    }
                                }

                                parentForm2.ManagementsMain_Load(null, null);
                            }
                            else
                            {
                                MessageBox.Show("You are not authorized to access Beauty 4U Headquarters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            storeName = "BEAUTY 4U HEADQUARTERS";
                            parentForm1.B4UHQCS = parentForm1.B4UHQCS_IP;
                            parentForm1.userLevel = parentForm1.UserChecking("B4UHQ");

                            parentForm1.cmbStoreName.DropDownStyle = ComboBoxStyle.Simple;
                            parentForm1.cmbStoreName.Text = storeName;
                            parentForm1.boolBtnConnect = true;
                            parentForm1.btnConnect_Click(null, null);

                            MessageBox.Show("The server has changed to " + parentForm1.storeName + " successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();

                            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                            {
                                if (Application.OpenForms[i].Name == "LogInManagements")
                                {
                                }
                                else if (Application.OpenForms[i].Name == "ManagementsMain")
                                {
                                }
                                else
                                {
                                    Application.OpenForms[i].Close();
                                }
                            }

                            parentForm2.ManagementsMain_Load(null, null);
                        }
                    }
                    else
                    {
                        MessageBox.Show("The server connect failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Exception error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            parentForm2.ManagementsMain_Load(null, null);
            this.Close();
        }

        private static bool DBConnectionStatus(string cs)
        {
            try
            {
                using (SqlConnection sqlConn =
                    //new SqlConnection("Server=VMWARE_DEV;Database=TestHQ;UID=ssk;Password=cherry"))
                    new SqlConnection(cs))
                {
                    sqlConn.Open();
                    return (sqlConn.State == ConnectionState.Open);
                }
            }
            catch (SqlException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}