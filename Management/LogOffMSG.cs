using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Management
{
    public partial class LogOffMSG : Form
    {
        public ManagementsMain parentForm;
        int timeLeft = 30;

        public LogOffMSG()
        {
            InitializeComponent();
        }

        private void LogOffMSG_Load(object sender, EventArgs e)
        {
            this.Text = "ALERT";
            tmr.Start();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            tmr.Stop();
            parentForm.timer1.Start();
            this.Close();
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                btnCancel.Enabled = true;
                timeLeft = timeLeft - 1;
                label1.Text = "Your employee ID will be logged out " + timeLeft.ToString() + " seconds after due to no activity more than 20 minutes.";
            }
            else
            {
                tmr.Stop();
                Properties.Settings.Default.IsRestarting = true;
                Properties.Settings.Default.Save();
                Application.Restart();
            }
        }
    }
}