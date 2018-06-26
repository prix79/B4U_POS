// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 05-04-2017
// ***********************************************************************
// <copyright file="AboutRegister.cs" company="Beauty4u">
//     Copyright © Beauty4u 2009
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;

/// <summary>
/// The Register namespace.
/// </summary>
namespace Register
{
    /// <summary>
    /// Class AboutRegister.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class AboutRegister : Form
    {
        /// <summary>
        /// The parent form
        /// </summary>
        public LoginRegister parentForm;

        /// <summary>
        /// The client information
        /// </summary>
        string clientInfo;
        /// <summary>
        /// The client name
        /// </summary>
        string clientName;
        /// <summary>
        /// The current client version
        /// </summary>
        int currentClientVersion;
        /// <summary>
        /// The lastest client version
        /// </summary>
        int lastestClientVersion;
        /// <summary>
        /// The update password
        /// </summary>
        public string updatePassword;
        /// <summary>
        /// The FTP directory name
        /// </summary>
        public string FTPDirectoryName;
        /// <summary>
        /// The local directory
        /// </summary>
        public string LocalDirectory;

        //public string _ftpURL = "ftp://173.167.197.50/Development/Beauty4U/POS_Clients/";
        /// <summary>
        /// The FTP URL
        /// </summary>
        public string _ftpURL;
        /// <summary>
        /// The user name
        /// </summary>
        public string _UserName;
        /// <summary>
        /// The password
        /// </summary>
        public string _Password;
        /// <summary>
        /// The file name
        /// </summary>
        public string _FileName = "Register.exe";
        /// <summary>
        /// The temporary file name
        /// </summary>
        public string _TempFileName;

        //string[] fileList;
        /// <summary>
        /// The oldfile
        /// </summary>
        string[] oldfile = new string[50];
        /// <summary>
        /// The newfile
        /// </summary>
        string[] newfile = new string[50];

        /// <summary>
        /// The authentication
        /// </summary>
        public bool auth = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="AboutRegister"/> class.
        /// </summary>
        public AboutRegister()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the AboutManagement control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AboutManagement_Load(object sender, EventArgs e)
        {
            OperatingSystem os = Environment.OSVersion;

            lblRegisterVersion.Text = parentForm.ClinetVersion;
            clientInfo = lblRegisterVersion.Text.Trim().ToUpper().ToString();
            currentClientVersion = Convert.ToInt16(clientInfo.Substring(0, 4));
            clientName = "Register";

            SqlConnection conn = new SqlConnection(parentForm.B4UHQCS);
            SqlCommand cmd = new SqlCommand("Get_FTP_Info", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FTP_Index", SqlDbType.TinyInt).Value = 1;
            SqlParameter FTPIP_Param = cmd.Parameters.Add("@FTP_IP", SqlDbType.NVarChar, 50);
            SqlParameter FTPPort_Param = cmd.Parameters.Add("@FTP_Port", SqlDbType.NVarChar, 50);
            SqlParameter FTPRoot_Param = cmd.Parameters.Add("@FTP_Root", SqlDbType.NVarChar, 100);
            FTPIP_Param.Direction = ParameterDirection.Output;
            FTPPort_Param.Direction = ParameterDirection.Output;
            FTPRoot_Param.Direction = ParameterDirection.Output;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                _ftpURL = "ftp://" + cmd.Parameters["@FTP_IP"].Value.ToString() + ":" + cmd.Parameters["@FTP_Port"].Value.ToString() + "/" + cmd.Parameters["@FTP_Root"].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Connection failed.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                btnUpdateCheck.Enabled = false;
                return;
            }

            if (parentForm.storeName == "BEAUTY 4U HEADQUARTERS")
            {
                FTPDirectoryName = "Headquarters/" + parentForm.cashRegister;
            }
            else if (parentForm.storeName == "BEAUTY 4U WAREHOUSE")
            {
                FTPDirectoryName = "Warehouse/" + parentForm.cashRegister;
            }
            else if (parentForm.storeName == "TEMPLE HILLS")
            {
                FTPDirectoryName = "TempleHills/" + parentForm.cashRegister;
            }
            else if (parentForm.storeName == "OXON HILL")
            {
                FTPDirectoryName = "OxonHill/" + parentForm.cashRegister;
            }
            else if (parentForm.storeName == "UPPER MARLBORO")
            {
                FTPDirectoryName = "UpperMarlboro/" + parentForm.cashRegister;
            }
            else if (parentForm.storeName == "CAPITOL HEIGHTS")
            {
                FTPDirectoryName = "CapitolHeights/" + parentForm.cashRegister;
            }
            else if (parentForm.storeName == "WINDSOR MILL")
            {
                FTPDirectoryName = "WindsorMill/" + parentForm.cashRegister;
            }
            else if (parentForm.storeName == "CATONSVILLE")
            {
                FTPDirectoryName = "Catonsville/" + parentForm.cashRegister;
            }
            else if (parentForm.storeName == "PRINCE WILLIAM")
            {
                FTPDirectoryName = "PrinceWilliam/" + parentForm.cashRegister;
            }
            else if (parentForm.storeName == "WOODBRIDGE")
            {
                FTPDirectoryName = "Woodbridge/" + parentForm.cashRegister;
            }
            else if (parentForm.storeName == "WALDORF")
            {
                FTPDirectoryName = "Waldorf/" + parentForm.cashRegister;
            }
            else if (parentForm.storeName == "GAITHERSBURG")
            {
                FTPDirectoryName = "Gaithersburg/" + parentForm.cashRegister;
            }
            else if (parentForm.storeName == "BOWIE")
            {
                FTPDirectoryName = "Bowie/" + parentForm.cashRegister;
            }
            else if (parentForm.storeName == "TEST")
            {
                FTPDirectoryName = "TEST/" + clientName;
            }

            //string root = Path.GetPathRoot(System.Reflection.Assembly.GetEntryAssembly().Location);
            LocalDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            //string root = Path.GetFullPath(System.Reflection.Assembly.GetEntryAssembly().Location);
            lblClientPath.Text = LocalDirectory;

            switch (os.Platform)
            {
                case PlatformID.Win32S:
                    lblOSPlatform.Text = "Windows 3.1";
                    break;
                case PlatformID.Win32Windows:
                    switch (os.Version.Minor)
                    {
                        case 0:
                            lblOSPlatform.Text = "Windows 95";
                            break;
                        case 10:
                            lblOSPlatform.Text = "Windows 98";
                            break;
                        case 90:
                            lblOSPlatform.Text = "Windows ME";
                            break;
                        default:
                            lblOSPlatform.Text = "Unknown OS";
                            break;
                    }
                    break;
                case PlatformID.Win32NT:
                    switch (os.Version.Major)
                    {
                        case 3:
                            lblOSPlatform.Text = "Windows NT 3.51";
                            break;
                        case 4:
                            lblOSPlatform.Text = "Windows NT 4.0";
                            break;
                        case 5:
                            switch (os.Version.Minor)
                            {
                                case 0:
                                    lblOSPlatform.Text = "Windows 2000";
                                    break;
                                case 1:
                                    lblOSPlatform.Text = "Windows XP";
                                    break;
                                case 2:
                                    lblOSPlatform.Text = "Windows Server 2003";
                                    break;
                                default:
                                    lblOSPlatform.Text = "Unknown OS";
                                    break;
                            }
                            break;
                        case 6:
                            switch (os.Version.Minor)
                            {
                                case 0:
                                    lblOSPlatform.Text = "Windows Vista/Windows 2008";
                                    break;
                                case 1:
                                    lblOSPlatform.Text = "Windows 7";
                                    break;
                                default:
                                    lblOSPlatform.Text = "Unknown OS";
                                    break;
                            }
                            break;
                    }
                    break;
                case PlatformID.WinCE:
                    lblOSPlatform.Text = "Windows CE";
                    break;
                case PlatformID.Unix:
                    lblOSPlatform.Text = "Unix";
                    break;
                default:
                    lblOSPlatform.Text = "Unknown OS";
                    break;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnUpdateCheck control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnUpdateCheck_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(parentForm.B4UHQCS);
                SqlCommand cmd = new SqlCommand("ClientVersionCheck", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientName", SqlDbType.NVarChar).Value = clientName;
                SqlParameter ClientVersion_Param = cmd.Parameters.Add("@ClientVersion", SqlDbType.Int);
                SqlParameter UpdatePassword_Param = cmd.Parameters.Add("@UpdatePassword", SqlDbType.NVarChar, 50);
                SqlParameter FTPUserName_Param = cmd.Parameters.Add("@FTPUserName", SqlDbType.NVarChar, 50);
                SqlParameter FTPPassword_Param = cmd.Parameters.Add("@FTPPassword", SqlDbType.NVarChar, 50);
                ClientVersion_Param.Direction = ParameterDirection.Output;
                UpdatePassword_Param.Direction = ParameterDirection.Output;
                FTPUserName_Param.Direction = ParameterDirection.Output;
                FTPPassword_Param.Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                if (cmd.Parameters["@UpdatePassword"].Value == DBNull.Value)
                {

                    updatePassword = "Expired passcode";
                }
                else
                {
                    updatePassword = cmd.Parameters["@UpdatePassword"].Value.ToString().Trim();
                }

                lastestClientVersion = Convert.ToInt16(cmd.Parameters["@ClientVersion"].Value);
                _UserName = cmd.Parameters["@FTPUserName"].Value.ToString().Trim();
                _Password = cmd.Parameters["@FTPPassword"].Value.ToString().Trim();

                if (lastestClientVersion > currentClientVersion)
                {
                    if (btnUpdateCheck.Text == "UPDATE")
                    {
                        listBox1.DataSource = GetFtpDirectoryDetails(_ftpURL + FTPDirectoryName, _UserName, _Password);
                        string[] fileList = GetFileList(_ftpURL + FTPDirectoryName, _UserName, _Password);

                        if (fileList.Length > 50)
                        {
                            MessageBox.Show("Can not download more than 50 files. \r\nPlese contact IT department.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else if (fileList.Length == 1)
                        {
                            progressBar1.Minimum = 0;
                            progressBar1.Maximum = 1;
                            progressBar1.Step = 1;
                            //ret_str += fileList[0];
                            DownloadFile(_ftpURL, _UserName, _Password, FTPDirectoryName, fileList[0].Substring(6), LocalDirectory, 0);
                            progressBar1.PerformStep();

                            MessageBox.Show("Update completes successfully! \r\nPlease hit OK button to restart the program...", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnUpdateCheck.Enabled = false;
                            Application.Restart();
                        }
                        else
                        {
                            progressBar1.Minimum = 0;
                            progressBar1.Maximum = fileList.Length;
                            progressBar1.Step = 1;

                            for (int i = 0; i < fileList.Length; i++)
                            {
                                oldfile[i] = fileList[i].Substring(6);
                                //ret_str += fileList[i] + ",";
                                DownloadFile(_ftpURL, _UserName, _Password, FTPDirectoryName, oldfile[i], LocalDirectory, i);
                                progressBar1.PerformStep();
                            }

                            MessageBox.Show("Update completes successfully! \r\nPlease hit OK button to restart the program...", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnUpdateCheck.Enabled = false;
                            Application.Restart();
                        }
                    }
                    else
                    {
                        DialogResult MyDialogResult;
                        MyDialogResult = MessageBox.Show(this, "A new version of POS Register program client is available. \r\nDo you want to proceed with the update now?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (MyDialogResult == DialogResult.Yes)
                        {
                            if (auth == false)
                            {
                                InputPasscode inputPasscodeForm = new InputPasscode();
                                inputPasscodeForm.parentForm = this;
                                inputPasscodeForm.ShowDialog();
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No update is available.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Can not connect the update server...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Gets the FTP directory details.
        /// </summary>
        /// <param name="ftpURL">The FTP URL.</param>
        /// <param name="UserName">Name of the user.</param>
        /// <param name="Password">The password.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        public List<string> GetFtpDirectoryDetails(string ftpURL, string UserName, string Password)
        {
            List<string> lst_strFiles = new List<string>();
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpURL);
                request.Credentials = new NetworkCredential(UserName, Password);
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                //request.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
  
                StreamReader file = new StreamReader(response.GetResponseStream());
                while (!file.EndOfStream)
                {
                    lst_strFiles.Add(file.ReadLine());
                }
                file.Close();
                response.Close();
            }
            catch (Exception exc)
            {
                lst_strFiles.Add(exc.Message);
            }
            return lst_strFiles;
        }

        /// <summary>
        /// Downloads the file.
        /// </summary>
        /// <param name="ftpURL">The FTP URL.</param>
        /// <param name="UserName">Name of the user.</param>
        /// <param name="Password">The password.</param>
        /// <param name="ftpDirectory">The FTP directory.</param>
        /// <param name="FileName">Name of the file.</param>
        /// <param name="LocalDirectory">The local directory.</param>
        /// <param name="idx">The index.</param>
        public void DownloadFile(string ftpURL, string UserName, string Password, string ftpDirectory, string FileName, string LocalDirectory, int idx)
        {
            if (FileExistsCheck(LocalDirectory + "\\" + FileName) == true)
            {
                //RenameFile(LocalDirectory, FileName, FileName.Substring(0, FileName.Length - 1), idx);
                RenameFile(LocalDirectory, FileName, FileName + ".temp", idx);

                try
                {
                    FtpWebRequest requestFileDownload = (FtpWebRequest)WebRequest.Create(ftpURL + "/" + ftpDirectory + "/" + FileName);
                    requestFileDownload.Credentials = new NetworkCredential(UserName, Password);
                    requestFileDownload.Method = WebRequestMethods.Ftp.DownloadFile;
                    FtpWebResponse responseFileDownload = (FtpWebResponse)requestFileDownload.GetResponse();
                    Stream responseStream = responseFileDownload.GetResponseStream();
                    FileStream writeStream = new FileStream(LocalDirectory + "/" + FileName, FileMode.Create);
                    int Length = 2048;
                    Byte[] buffer = new Byte[Length];
                    int bytesRead = responseStream.Read(buffer, 0, Length);
                    while (bytesRead > 0)
                    {
                        writeStream.Write(buffer, 0, bytesRead);
                        bytesRead = responseStream.Read(buffer, 0, Length);
                    }
                    responseStream.Close();
                    writeStream.Close();
                    requestFileDownload = null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                try
                {
                    FtpWebRequest requestFileDownload = (FtpWebRequest)WebRequest.Create(ftpURL + "/" + ftpDirectory + "/" + FileName);
                    requestFileDownload.Credentials = new NetworkCredential(UserName, Password);
                    requestFileDownload.Method = WebRequestMethods.Ftp.DownloadFile;
                    FtpWebResponse responseFileDownload = (FtpWebResponse)requestFileDownload.GetResponse();
                    Stream responseStream = responseFileDownload.GetResponseStream();
                    FileStream writeStream = new FileStream(LocalDirectory + "/" + FileName, FileMode.Create);
                    int Length = 2048;
                    Byte[] buffer = new Byte[Length];
                    int bytesRead = responseStream.Read(buffer, 0, Length);
                    while (bytesRead > 0)
                    {
                        writeStream.Write(buffer, 0, bytesRead);
                        bytesRead = responseStream.Read(buffer, 0, Length);
                    }
                    responseStream.Close();
                    writeStream.Close();
                    requestFileDownload = null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Files the exists check.
        /// </summary>
        /// <param name="oldFilePath">The old file path.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool FileExistsCheck(string oldFilePath)
        {
            if (System.IO.File.Exists(oldFilePath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Renames the file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="oldFileName">Old name of the file.</param>
        /// <param name="newFileName">New name of the file.</param>
        /// <param name="index">The index.</param>
        public void RenameFile(string filePath, string oldFileName, string newFileName, int index)
        {
            oldfile[index] = filePath + "\\" + oldFileName;
            newfile[index] = filePath + "\\" + newFileName;

            System.IO.File.Move(oldfile[index], newfile[index]);
        }

        /// <summary>
        /// Gets the file list.
        /// </summary>
        /// <param name="ftpURL">The FTP URL.</param>
        /// <param name="UserName">Name of the user.</param>
        /// <param name="Password">The password.</param>
        /// <returns>System.String[].</returns>
        public string[] GetFileList(string ftpURL, string UserName, string Password)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpURL);
            request.Credentials = new NetworkCredential(UserName, Password);
            request.Method = WebRequestMethods.Ftp.ListDirectory;

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string strData;
            strData = reader.ReadToEnd();
            string[] filesInDirectory = strData.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            response.Close();

            return filesInDirectory;
        }
    }
}