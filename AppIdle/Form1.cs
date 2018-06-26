using System;
using System.Drawing;
using System.Windows.Forms;
using Utilities.WinForms;

namespace Demo
{
	public class Form1 : System.Windows.Forms.Form
	{
		private long idleCounter = 0;
		private System.Windows.Forms.Button btnGo;
		private System.Windows.Forms.Button btnIterate;
		private System.Windows.Forms.NumericUpDown spinIterations;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Label lblCPU;
		private System.Windows.Forms.Label lblGUI;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label lblCPUThreshold;
		private System.Windows.Forms.Label lblGUIThreshold;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TrackBar adjGUIThreshold;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TrackBar adjCPU;
		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Label lblIterations;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox chkYield;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lblAppIdle;
		private System.Windows.Forms.GroupBox groupBox1;
		/// 
		/// The main windows which the application launches.
		/// 
        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

			// Initialize the settings
			int cpuPct = (int)(ApplicationIdleTimer.CPUUsageThreshold * 100.0);
			this.adjCPU.Value = cpuPct;
			this.lblCPUThreshold.Text = cpuPct.ToString("#0") + "%";
			this.adjGUIThreshold.Value = (int)ApplicationIdleTimer.GUIActivityThreshold;
			this.lblGUIThreshold.Text = this.adjGUIThreshold.Value.ToString("#0.0");

			// Listen for changes
			this.adjGUIThreshold.Scroll += new System.EventHandler(this.adjGUIThreshold_Scroll);
			this.adjCPU.Scroll += new System.EventHandler(this.adjCPU_Scroll);

			// Hook into the ApplicationIdle event
			ApplicationIdleTimer.ApplicationIdle += new ApplicationIdleTimer.ApplicationIdleEventHandler(this.App_Idle);

			// Also hook into the Application.Idle event, for comparison
			Application.Idle += new System.EventHandler(this.Idle_Count);
			// Start the timer
			this.timer1.Start();
        }

		/// 
		/// Clean up any resources being used.
		///
		protected override void Dispose(bool disposing)
        {
			try
			{
				if(disposing)
				{
					// Release the managed resources you added in this derived class here.
				}
			}
			finally
			{
				// Call Dispose on your base class.
				base.Dispose(disposing);
			}
        }

		/// 
		/// Initialize the components/resources insides the windows.
		///
        private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.btnGo = new System.Windows.Forms.Button();
			this.btnIterate = new System.Windows.Forms.Button();
			this.spinIterations = new System.Windows.Forms.NumericUpDown();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblStatus = new System.Windows.Forms.Label();
			this.lblCPU = new System.Windows.Forms.Label();
			this.lblGUI = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.lblCPUThreshold = new System.Windows.Forms.Label();
			this.lblGUIThreshold = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.adjGUIThreshold = new System.Windows.Forms.TrackBar();
			this.label3 = new System.Windows.Forms.Label();
			this.adjCPU = new System.Windows.Forms.TrackBar();
			this.lblIterations = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.chkYield = new System.Windows.Forms.CheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.lblAppIdle = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.spinIterations)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.adjGUIThreshold)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.adjCPU)).BeginInit();
			this.SuspendLayout();
			// 
			// btnGo
			// 
			this.btnGo.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnGo.Location = new System.Drawing.Point(280, 344);
			this.btnGo.Name = "btnGo";
			this.btnGo.Size = new System.Drawing.Size(96, 24);
			this.btnGo.TabIndex = 2;
			this.btnGo.Text = "Show MsgBox";
			this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
			// 
			// btnIterate
			// 
			this.btnIterate.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnIterate.Location = new System.Drawing.Point(280, 312);
			this.btnIterate.Name = "btnIterate";
			this.btnIterate.Size = new System.Drawing.Size(96, 24);
			this.btnIterate.TabIndex = 3;
			this.btnIterate.Text = "Do Iterations";
			this.btnIterate.Click += new System.EventHandler(this.btnIterate_Click);
			// 
			// spinIterations
			// 
			this.spinIterations.Location = new System.Drawing.Point(8, 312);
			this.spinIterations.Name = "spinIterations";
			this.spinIterations.Size = new System.Drawing.Size(48, 20);
			this.spinIterations.TabIndex = 4;
			this.spinIterations.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
			this.spinIterations.Value = new System.Decimal(new int[] {
																		 5,
																		 0,
																		 0,
																		 0});
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.lblAppIdle,
																					this.label6,
																					this.lblStatus,
																					this.lblCPU,
																					this.lblGUI,
																					this.label2,
																					this.label1});
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(368, 112);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Current Status";
			// 
			// lblStatus
			// 
			this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.lblStatus.Font = new System.Drawing.Font("Verdana", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblStatus.Location = new System.Drawing.Point(200, 24);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(160, 48);
			this.lblStatus.TabIndex = 18;
			this.lblStatus.Text = "Loading...";
			this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblCPU
			// 
			this.lblCPU.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCPU.Location = new System.Drawing.Point(120, 56);
			this.lblCPU.Name = "lblCPU";
			this.lblCPU.Size = new System.Drawing.Size(64, 16);
			this.lblCPU.TabIndex = 17;
			this.lblCPU.Text = "0.0";
			this.lblCPU.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblGUI
			// 
			this.lblGUI.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblGUI.Location = new System.Drawing.Point(120, 24);
			this.lblGUI.Name = "lblGUI";
			this.lblGUI.Size = new System.Drawing.Size(64, 16);
			this.lblGUI.TabIndex = 16;
			this.lblGUI.Text = "0.0";
			this.lblGUI.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(8, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 16);
			this.label2.TabIndex = 15;
			this.label2.Text = "CPU Use:";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 14;
			this.label1.Text = "GUI Activity:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.groupBox3});
			this.groupBox2.Location = new System.Drawing.Point(80, 160);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(8, 8);
			this.groupBox2.TabIndex = 15;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "groupBox2";
			// 
			// groupBox3
			// 
			this.groupBox3.Location = new System.Drawing.Point(-96, -46);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "groupBox3";
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.groupBox4.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.lblCPUThreshold,
																					this.lblGUIThreshold,
																					this.label5,
																					this.adjGUIThreshold,
																					this.label3,
																					this.adjCPU});
			this.groupBox4.Location = new System.Drawing.Point(8, 128);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(368, 176);
			this.groupBox4.TabIndex = 16;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Settings";
			// 
			// lblCPUThreshold
			// 
			this.lblCPUThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCPUThreshold.Location = new System.Drawing.Point(120, 96);
			this.lblCPUThreshold.Name = "lblCPUThreshold";
			this.lblCPUThreshold.Size = new System.Drawing.Size(64, 16);
			this.lblCPUThreshold.TabIndex = 15;
			this.lblCPUThreshold.Text = "0.0";
			this.lblCPUThreshold.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblGUIThreshold
			// 
			this.lblGUIThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblGUIThreshold.Location = new System.Drawing.Point(120, 24);
			this.lblGUIThreshold.Name = "lblGUIThreshold";
			this.lblGUIThreshold.Size = new System.Drawing.Size(64, 16);
			this.lblGUIThreshold.TabIndex = 18;
			this.lblGUIThreshold.Text = "0.0";
			this.lblGUIThreshold.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(8, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(112, 16);
			this.label5.TabIndex = 17;
			this.label5.Text = "GUI Threshold:";
			// 
			// adjGUIThreshold
			// 
			this.adjGUIThreshold.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.adjGUIThreshold.LargeChange = 50;
			this.adjGUIThreshold.Location = new System.Drawing.Point(8, 48);
			this.adjGUIThreshold.Maximum = 1000;
			this.adjGUIThreshold.Minimum = 1;
			this.adjGUIThreshold.Name = "adjGUIThreshold";
			this.adjGUIThreshold.Size = new System.Drawing.Size(352, 42);
			this.adjGUIThreshold.TabIndex = 16;
			this.adjGUIThreshold.Value = 1;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(16, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(112, 16);
			this.label3.TabIndex = 14;
			this.label3.Text = "CPU Threshold:";
			// 
			// adjCPU
			// 
			this.adjCPU.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.adjCPU.Location = new System.Drawing.Point(8, 120);
			this.adjCPU.Maximum = 100;
			this.adjCPU.Name = "adjCPU";
			this.adjCPU.Size = new System.Drawing.Size(352, 42);
			this.adjCPU.TabIndex = 13;
			// 
			// lblIterations
			// 
			this.lblIterations.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.lblIterations.Location = new System.Drawing.Point(160, 312);
			this.lblIterations.Name = "lblIterations";
			this.lblIterations.Size = new System.Drawing.Size(112, 24);
			this.lblIterations.TabIndex = 17;
			// 
			// timer1
			// 
			this.timer1.Interval = 250;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.textBox1.Location = new System.Drawing.Point(8, 344);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(256, 20);
			this.textBox1.TabIndex = 18;
			this.textBox1.Text = "(type here)";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.label4.Location = new System.Drawing.Point(64, 312);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 16);
			this.label4.TabIndex = 19;
			this.label4.Text = "million";
			// 
			// chkYield
			// 
			this.chkYield.Checked = true;
			this.chkYield.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkYield.Location = new System.Drawing.Point(104, 312);
			this.chkYield.Name = "chkYield";
			this.chkYield.Size = new System.Drawing.Size(56, 16);
			this.chkYield.TabIndex = 20;
			this.chkYield.Text = "Yield";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(8, 88);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(112, 16);
			this.label6.TabIndex = 19;
			this.label6.Text = "App.Idle Events:";
			// 
			// lblAppIdle
			// 
			this.lblAppIdle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblAppIdle.Location = new System.Drawing.Point(144, 88);
			this.lblAppIdle.Name = "lblAppIdle";
			this.lblAppIdle.Size = new System.Drawing.Size(216, 16);
			this.lblAppIdle.TabIndex = 20;
			this.lblAppIdle.Text = "0.0";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(386, 375);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.chkYield,
																		  this.label4,
																		  this.textBox1,
																		  this.lblIterations,
																		  this.groupBox4,
																		  this.groupBox2,
																		  this.groupBox1,
																		  this.spinIterations,
																		  this.btnIterate,
																		  this.btnGo});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Application Idle Demo";
			((System.ComponentModel.ISupportInitialize)(this.spinIterations)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.adjGUIThreshold)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.adjCPU)).EndInit();
			this.ResumeLayout(false);

		}

		/// 
		/// The main entry point for the application.
		///
        public static void Main(string[] args) 
        {
            Application.Run(new Form1());
        }
		private void App_Idle(ApplicationIdleTimer.ApplicationIdleEventArgs e)
		{
			this.lblStatus.BackColor = Color.Green;
			this.lblStatus.Text = string.Format("Idle: {0}s", e.IdleDuration.TotalSeconds.ToString("0"));
		}
		private void Idle_Count(object sender, System.EventArgs e)
		{
			idleCounter ++;
		}

		private void adjCPU_Scroll(object sender, System.EventArgs e)
		{
			double val = (double)this.adjCPU.Value / 100.0;
			this.lblCPUThreshold.Text = val.ToString("#0%");
			ApplicationIdleTimer.CPUUsageThreshold = val;
		}
		private void adjGUIThreshold_Scroll(object sender, System.EventArgs e)
		{
			double val = (double)this.adjGUIThreshold.Value;
			this.lblGUIThreshold.Text = val.ToString("#0.0");
			ApplicationIdleTimer.GUIActivityThreshold = val;
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if (!ApplicationIdleTimer.IsIdle && this.lblStatus.Text != "Busy")
			{
				this.lblStatus.BackColor = Color.Red;
				this.lblStatus.Text = "Busy";			
			}
			this.lblCPU.Text = ApplicationIdleTimer.CurrentCPUUsage.ToString("#0.0%");
			this.lblGUI.Text = ApplicationIdleTimer.CurrentGUIActivity.ToString("#0.0");
			this.lblAppIdle.Text = idleCounter.ToString("#,##0");
		}

		private void btnIterate_Click(object sender, System.EventArgs e)
		{
			long iterations = (long)this.spinIterations.Value * 1000000L;
			long ticks = DateTime.UtcNow.Ticks;
			this.Cursor = Cursors.WaitCursor;
			string foo;
			bool yield = this.chkYield.Checked;
			for(long l=0; l<iterations; l++)
			{
				foo = l.ToString();

				// Yield occasionally
				if (yield && l%10000==0) Application.DoEvents();
			}
			ticks = DateTime.UtcNow.Ticks - ticks;
			this.lblIterations.Text = String.Format("Time: {0} sec.", new TimeSpan(ticks).TotalSeconds.ToString("#0.0"));
			this.Cursor = Cursors.Default;
		}

		private void btnGo_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show(this.textBox1.Text, "Hello, World!", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
    }
}
