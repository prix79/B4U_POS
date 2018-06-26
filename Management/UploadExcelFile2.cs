using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Office = Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;

namespace Management
{
    public partial class UploadExcelFile2 : Form
    {
        public LogInManagements parentForm1;
        public LabelPrint parentForm2;
        public DataTransferScannedItems parentForm3;
        public SqlCommand cmd0;
        public SqlCommand cmd1;
        public SqlCommand cmd2;

        Int64 ItmCode;
        string ItmstoreCode;
        int act = 0;
        //DateTime d;
        DateTime uploadDate;
        //DateTime webUpdateDate;
        //double retailPrice = 0;
        Int64 addedItem = 0;
        Int64 nonaddedItem = 0;
        int checkItmCode = 0;
        bool updateComplete = true;
        int option;

        public UploadExcelFile2(int opt)
        {
            InitializeComponent();
            option = opt;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Excel file requirement \n\n 1. Excel sheet name : Sheet1 \n 2. Number of colum : 1 \n 3. Column header name : UPC", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "OPEN EXCEL FILE";
            fDialog.InitialDirectory = @"C:\";
            fDialog.RestoreDirectory = true;
            fDialog.DefaultExt = "xls";
            fDialog.Filter = "Excel files (*.xls;*.xlsx)|*.xls;*.xlsx|All files (*.*)|*.*";
            fDialog.FilterIndex = 1;
            fDialog.CheckFileExists = true;
            fDialog.CheckPathExists = true;

            //fDialog.ShowDialog();

            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = fDialog.FileName;
                btnUpload.Enabled = true;
                dataGridView1.DataSource = null;

                //string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Sample.xlsx;Extended Properties=""Excel 12.0;HDR=YES;""";
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtFileName.Text.Trim() + ";Extended Properties=\"Excel 8.0;HDR=YES;\"";

                // if you don't want to show the header row (first row)
                // use 'HDR=NO' in the string

                string strSQL = "SELECT * FROM [Sheet1$]";

                OleDbConnection excelConnection = new OleDbConnection(connectionString);
                excelConnection.Open();

                OleDbCommand dbCommand = new OleDbCommand(strSQL, excelConnection);
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(dbCommand);

                DataTable dTable = new DataTable();
                dataAdapter.Fill(dTable);

                try
                {
                    dataBingingSrc.DataSource = dTable;
                    dataGridView1.DataSource = dataBingingSrc;

                    dTable.Dispose();
                    dataAdapter.Dispose();
                    dbCommand.Dispose();

                    excelConnection.Close();
                    excelConnection.Dispose();
                }
                catch
                {
                    MessageBox.Show("Excel file opening error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dTable.Dispose();
                    dataAdapter.Dispose();
                    dbCommand.Dispose();

                    excelConnection.Close();
                    excelConnection.Dispose();
                }
            }
            else
            {
                return;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            DialogResult MyDialogResult;
            MyDialogResult = MessageBox.Show(this, "Do you want to proceed to upload the file?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MyDialogResult == DialogResult.Yes)
            {
                if (option == 0)
                {
                    btnUpload.Enabled = false;
                    parentForm2.excelUploadBoolNum = true;

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dataGridView1.RowCount;
                    progressBar1.Step = 1;

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        parentForm2.txtUpc.Text = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
                        parentForm2.btnAdd_Click(null, null);
                        progressBar1.PerformStep();
                    }

                    parentForm2.excelUploadBoolNum = false;
                    this.Close();
                }
                else if (option == 1)
                {
                    btnUpload.Enabled = false;

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dataGridView1.RowCount;
                    progressBar1.Step = 1;

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        parentForm3.txtUpc.Text = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
                        parentForm3.btnAdd_Click(null, null);
                        progressBar1.PerformStep();
                    }

                    this.Close();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {
            if (txtFileName.Text == "")
            {
                btnUpload.Enabled = false;
            }
        }
    }
}