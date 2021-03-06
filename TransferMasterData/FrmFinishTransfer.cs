﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace TestFormDB
{
    public partial class FrmFinishTransfer : Form
    {
        public delegate void UpdateLog(string s);

        public UpdateLog OnUpdateLog;
        private BackgroundWorker bw;

        List<string> time = new List<string>();
        public FrmFinishTransfer()
        {
            InitializeComponent();
            this.richTextBox1.Text = string.Format("================{0} {1}===============", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());
            this.richTextBox1.Text += "\r\n";
            this.richTextBox1.Text += "Import Data..." + "\r\n\r\n";
            OnUpdateLog = (s) =>
            {
                this.richTextBox1.Text += s + "\r\n";
            };
            
        }
        //private const int CP_NOCLOSE_BUTTON = 0x200;
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams myCp = base.CreateParams;
        //        myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
        //        return myCp;
        //    }
        //}

        private void btnFinish_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            Application.DoEvents();
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            ProcessImport(e);
            // ProcessImport(e);
            // bao cao tien do

        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.btnFinish.Enabled = this.btnClose.Enabled = true;
            if (string.IsNullOrEmpty(e.Result as string))
            {

                MessageBox.Show("Chuyển dữ liệu thành công");
                richTextBox1.Text = richTextBox1.Text + "\r\n" + "Import into table SUCCESS !! " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
            }

            else
            {
                MessageBox.Show(e.Result.ToString());
            }
        }

        private void ProcessImport(DoWorkEventArgs e)
        {

            try
            {
                // Đọc File XML Data
                XmlDocument docProcess = new XmlDocument();
                docProcess.Load(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\dataSrcCheck.xml");

                //lấy Table từ table sau khi check chọn
                var Table = docProcess.GetElementsByTagName("Function");

                List<DataTransfer> table = new List<DataTransfer>();


                foreach (XmlNode item in Table)
                {
                    table.Add(new DataTransfer()
                    {
                        Table = item.SelectNodes("Table").Item(0).InnerText,
                        Condition = item.SelectNodes("Condition").Item(0).InnerText
                    });
                }
                var Overwrite = docProcess.GetElementsByTagName("Overwrite").Item(0).InnerText;

                // kết nối data lấy dữ liệu bảng muốn chuyển
                using (SqlConnection sourceConnection = new SqlConnection(GetStrConnect.GetStrSrc()))
                {
                    sourceConnection.Open();


                    //Lọc từng Table từ danh sách trong file XML
                    int i = 1;

                    foreach (var tablenameTrans in table)
                    {
                        List<DataTransfer> tabletrans = new List<DataTransfer>();
                        var tran = sourceConnection.BeginTransaction();

                        using (SqlCommand cmd = new SqlCommand("AD_spImportTable", sourceConnection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Transaction = tran;
                            cmd.Parameters.Add("@TableToInsert", SqlDbType.VarChar, 50).Value = tablenameTrans.Table;
                            using (SqlDataReader rdr = cmd.ExecuteReader())
                            {
                                // iterate through results, printing each to console
                                while (rdr.Read())
                                {
                                    tabletrans.Add(new DataTransfer()
                                    {
                                        Table = rdr["TableName"].ToString(),
                                    });
                                    //Console.WriteLine("Product: {0,-35} Total: {1,2}", rdr["TableName"], rdr["Level"]);
                                }
                            }
                            tran.Commit();
                        }

                        foreach (var tableName in tabletrans)
                        {
                            //Lấy danh sách Data
                            SqlDataAdapter sqlDA;
                            //if (tableName.Condition == "")
                            //{
                            //    sqlDA = new SqlDataAdapter("select * from " + tableName.Table, sourceConnection);
                            //}
                            //else
                            //{
                            //    sqlDA = new SqlDataAdapter("select * from " + tableName.Table + " Where " + tableName.Condition, sourceConnection);
                            //}
                            sqlDA = new SqlDataAdapter("select * from " + tableName.Table, sourceConnection);
                            var ds = new DataSet();
                            sqlDA.Fill(ds);

                            //Khởi tạo danh sách Column, dataTable, Khóa chính cột ---- Khi chạy từng vòng lặp
                            List<string> column = new List<string>();
                            Dictionary<string, string> openWith = new Dictionary<string, string>();
                            DataTable dataTable = new DataTable();
                            dataTable = ds.Tables[0];

                            //Lấy danh sách Column trong Danh sách
                            //Lấy Khóa chính trong danh sách Column
                            foreach (var item in dataTable.Columns)
                            {
                                openWith.Add(item.ToString(), item.ToString());
                                column.Add(item.ToString());
                            }

                            using (SqlConnection descConnection = new SqlConnection(GetStrConnect.GetStrDsc()))
                            {
                                descConnection.Open();
                                CopyData(descConnection, tableName.Table, ds.Tables[0], bool.Parse(Overwrite), openWith, tableName.Table, null, column[0]);
                                if (tableName.Table == tablenameTrans.Table)
                                {
                                    this.Invoke(OnUpdateLog, "Import " + tableName.Table + ", Rows: " + dataTable.Rows.Count);
                                }
                            }
                        }
                        bw.ReportProgress((100 * i) / table.Count);
                        i++;
                    }
                }

                e.Result = "";
            }
            catch (Exception ex)
            {
                e.Result = ex.Message;
            }
        }

        public static void CopyData(SqlConnection conn, string tablename, DataTable dt, bool overwrite, Dictionary<string, string> cloumnMap, string tableMaster, string tableDetail, string ColumnKey)
        {
            var tran = conn.BeginTransaction();
            try
            {

                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.Connection = conn;
                cmd1.Transaction = tran;

                string table = "";
                table += "IF OBJECT_ID('tempdb..#zzzlvimport" + tablename + "') IS NOT NULL ";
                table += "BEGIN ";
                table += "DROP TABLE #zzzlvimport" + tablename + " ";
                table += "END ";
                table += "SELECT TOP 0 * INTO #zzzlvimport" + tablename + " FROM " + tablename + " ";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = table;
                cmd.Connection = conn;
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.KeepIdentity | SqlBulkCopyOptions.KeepNulls, tran))
                {
                    bulkCopy.DestinationTableName = "#zzzlvimport" + tablename;

                    foreach (var item in cloumnMap)
                    {
                        bulkCopy.ColumnMappings.Add(item.Key, item.Value);
                    }

                    bulkCopy.WriteToServer(dt);
                    bulkCopy.Close();
                }

                var insertString = InsertString(cloumnMap)[0];
                var insertStringAlias = InsertString(cloumnMap)[1];

                var keyCol = ColumnKey;
                if (string.IsNullOrEmpty(keyCol)) keyCol = "DocumentID";

                //change code

                cmd1.CommandText = "INSERT INTO " + tablename + "(" + insertString + ") SELECT " + insertStringAlias + " FROM #zzzlvimport" + tablename + " T LEFT JOIN " + tablename + " M ON T." + keyCol + "= M." + keyCol + " WHERE M." + keyCol + " IS NULL";


                cmd1.ExecuteNonQuery();
                tran.Commit();

            }
            catch (Exception exp)
            {
                tran.Rollback();
                throw exp;
            }
        }

        public static void TransferData()
        {
        }

        private static string[] InsertString(Dictionary<string, string> cloumnMap)
        {
            string dest = "";
            string destalias = "";
            foreach (var item in cloumnMap)
            {
                if (!string.IsNullOrEmpty(destalias)) destalias = destalias + ",";
                destalias = destalias + "T." + item.Value;

                if (!string.IsNullOrEmpty(dest)) dest = dest + ",";
                dest = dest + item.Value;
            }

            return new string[] { dest, destalias };
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void btnhelp_Click(object sender, EventArgs e)
        {
        }

        private void btnSavelog_Click(object sender, EventArgs e)
        {
            LogWriter log = new LogWriter(richTextBox1.Text, "log");
            MessageBox.Show("Lưu File thành công");
        }

        private void FrmFinishTransfer_Load(object sender, EventArgs e)
        {
            bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true; // ho tro bao cao tien do
            bw.WorkerSupportsCancellation = true; // cho phep dung tien trinh

            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
            bw.DoWork += Bw_DoWork;
            bw.ProgressChanged += bw_ProgressChanged;

            this.btnFinish.Enabled = this.btnClose.Enabled = false;
            this.progressBar1.Visible = true;
            bw.RunWorkerAsync();
        }

        private void FrmFinishTransfer_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormMain frm = new FormMain();
            Hide();
            frm.Show();
        }
    }
}