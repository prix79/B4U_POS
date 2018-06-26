using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Management
{
    public partial class InputIPAddress : Form
    {
        public LogInManagements parentForm;

        public InputIPAddress()
        {
            InitializeComponent();
        }

        private void InputIPAddress_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rdoBtnIPAddress.Checked == true)
            {
                if (txtIPAddress.Text.Trim().ToString() == "")
                {
                    MessageBox.Show("INPUT IP ADDRESS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (parentForm.cmbStoreName.Text == "BEAUTY 4U HEADQUARTERS")
                    {
                        parentForm.B4UHQCS = "Data Source=" + txtIPAddress.Text + ";Network Library=DBMSSOCN;Initial Catalog=Beauty4U_HQ;UID=ssk;Password=cherry";
                        this.Close();
                    }
                    else if (parentForm.cmbStoreName.Text == "BEAUTY 4U WAREHOUSE")
                    {
                        parentForm.B4UWHCS = "Data Source=" + txtIPAddress.Text + ";Network Library=DBMSSOCN;Initial Catalog=Beauty4UWarehouse;UID=ssk;Password=cherry";
                        this.Close();
                    }
                    else if (parentForm.cmbStoreName.Text == "CAPITOL HEIGHTS")
                    {
                        parentForm.CHCS = "Data Source=" + txtIPAddress.Text + ";Network Library=DBMSSOCN;Initial Catalog=CapitolHeights;UID=ssk;Password=cherry";
                        this.Close();
                    }
                    else if (parentForm.cmbStoreName.Text == "OXON HILL")
                    {
                        parentForm.OHCS = "Data Source=" + txtIPAddress.Text + ";Network Library=DBMSSOCN;Initial Catalog=OxonHill;UID=ssk;Password=cherry";
                        this.Close();
                    }
                    else if (parentForm.cmbStoreName.Text == "WOODBRIDGE")
                    {
                        parentForm.WBCS = "Data Source=" + txtIPAddress.Text + ";Network Library=DBMSSOCN;Initial Catalog=Woodbridge;UID=ssk;Password=cherry";
                        this.Close();
                    }
                    else if (parentForm.cmbStoreName.Text == "CATONSVILLE")
                    {
                        parentForm.CVCS = "Data Source=" + txtIPAddress.Text + ";Network Library=DBMSSOCN;Initial Catalog=Catonsville;UID=ssk;Password=cherry";
                        this.Close();
                    }
                    else if (parentForm.cmbStoreName.Text == "UPPER MARLBORO")
                    {
                        parentForm.UMCS = "Data Source=" + txtIPAddress.Text + ";Network Library=DBMSSOCN;Initial Catalog=KTSC;UID=ssk;Password=cherry";
                        this.Close();
                    }
                    else if (parentForm.cmbStoreName.Text == "WINDSOR MILL")
                    {
                        parentForm.WMCS = "Data Source=" + txtIPAddress.Text + ";Network Library=DBMSSOCN;Initial Catalog=WindsorMill;UID=ssk;Password=cherry";
                        this.Close();
                    }
                    else if (parentForm.cmbStoreName.Text == "TEMPLE HILLS")
                    {
                        parentForm.THCS = "Data Source=" + txtIPAddress.Text + ";Network Library=DBMSSOCN;Initial Catalog=TempleHills;UID=ssk;Password=cherry";
                        this.Close();
                    }
                    else if (parentForm.cmbStoreName.Text == "WALDORF")
                    {
                        parentForm.WDCS = "Data Source=" + txtIPAddress.Text + ";Network Library=DBMSSOCN;Initial Catalog=Waldorf;UID=ssk;Password=cherry";
                        this.Close();
                    }
                    else if (parentForm.cmbStoreName.Text == "PRINCE WILLIAM")
                    {
                        parentForm.PWCS = "Data Source=" + txtIPAddress.Text + ";Network Library=DBMSSOCN;Initial Catalog=PrinceWilliam;UID=ssk;Password=cherry";
                        this.Close();
                    }
                    else if (parentForm.cmbStoreName.Text == "GAITHERSBURG")
                    {
                        parentForm.GBCS = "Data Source=" + txtIPAddress.Text + ";Network Library=DBMSSOCN;Initial Catalog=Gaithersburg;UID=ssk;Password=cherry";
                        this.Close();
                    }
                    else if (parentForm.cmbStoreName.Text == "BOWIE")
                    {
                        parentForm.BWCS = "Data Source=" + txtIPAddress.Text + ";Network Library=DBMSSOCN;Initial Catalog=Bowie;UID=ssk;Password=cherry";
                        this.Close();
                    }
                    else if (parentForm.cmbStoreName.Text == "TEST" | parentForm.cmbStoreName.Text == "TEST2")
                    {
                        MessageBox.Show("USE CUSTOM", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else if (rdoBtnNamedPipe.Checked == true)
            {
                if (txtNamedPipe.Text.Trim().ToString() == "")
                {
                    MessageBox.Show("INPUT NAMED PIPE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (parentForm.cmbStoreName.Text == "CAPITOL HEIGHTS")
                    {
                        parentForm.CHCS = "Server=" + txtNamedPipe.Text + ";Database=CapitolHeights;UID=;Password=";
                        this.Close();
                    }
                    else if (parentForm.cmbStoreName.Text == "OXON HILL")
                    {
                        parentForm.OHCS = "Server=" + txtNamedPipe.Text + ";Database=OxonHill;UID=;Password=";
                        this.Close();
                    }
                    else if (parentForm.cmbStoreName.Text == "WOODBRIDGE")
                    {
                        parentForm.WBCS = "Server=" + txtNamedPipe.Text + ";Database=Woodbridge;UID=;Password=";
                        this.Close();
                    }
                    else if (parentForm.cmbStoreName.Text == "CATONSVILLE")
                    {
                        parentForm.CVCS = "Server=" + txtNamedPipe.Text + ";Database=Catonsville;UID=;Password=";
                        this.Close();
                    }
                    else if (parentForm.cmbStoreName.Text == "UPPER MARLBORO")
                    {
                        parentForm.UMCS = "Server=" + txtNamedPipe.Text + ";Database=KTSC;UID=;Password=";
                        this.Close();
                    }
                    else if (parentForm.cmbStoreName.Text == "WINDSOR MILL")
                    {
                        parentForm.WMCS = "Server=" + txtNamedPipe.Text + ";Database=WindsorMill;UID=;Password=";
                        this.Close();
                    }
                    else if (parentForm.cmbStoreName.Text == "TEMPLE HILLS")
                    {
                        parentForm.THCS = "Server=" + txtNamedPipe.Text + ";Database=TempleHills;UID=;Password=";
                        this.Close();
                    }
                    else if (parentForm.cmbStoreName.Text == "TEST" | parentForm.cmbStoreName.Text == "TEST2")
                    {
                        MessageBox.Show("USE CUSTOM", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else if (rdoBtnCustom.Checked == true)
            {
                if (txtCustom.Text.Trim().ToString() == "")
                {
                    MessageBox.Show("INPUT CUSTOM", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (parentForm.cmbStoreName.Text == "CAPITOL HEIGHTS")
                    {
                        parentForm.CHCS = txtCustom.Text;
                        this.Close();
                    }
                    else if (parentForm.cmbStoreName.Text == "OXON HILL")
                    {
                        parentForm.OHCS = txtCustom.Text;
                        this.Close();
                    }
                    else if (parentForm.cmbStoreName.Text == "WOODBRIDGE")
                    {
                        parentForm.WBCS = txtCustom.Text;
                        this.Close();
                    }
                    else if (parentForm.cmbStoreName.Text == "CATONSVILLE")
                    {
                        parentForm.CVCS = txtCustom.Text;
                        this.Close();
                    }
                    else if (parentForm.cmbStoreName.Text == "UPPER MARLBORO")
                    {
                        parentForm.UMCS = txtCustom.Text;
                        this.Close();
                    }
                    else if (parentForm.cmbStoreName.Text == "WINDSOR MILL")
                    {
                        parentForm.WMCS = txtCustom.Text;
                        this.Close();
                    }
                    else if (parentForm.cmbStoreName.Text == "TEMPLE HILLS")
                    {
                        parentForm.THCS = txtCustom.Text;
                        this.Close();
                    }
                    else if (parentForm.cmbStoreName.Text == "TEST")
                    {
                        parentForm.Test1CS = txtCustom.Text;
                        this.Close();
                    }
                    else if (parentForm.cmbStoreName.Text == "TEST2")
                    {
                        parentForm.Test2CS = txtCustom.Text;
                        this.Close();
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}