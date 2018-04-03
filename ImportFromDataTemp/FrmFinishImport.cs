using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TestFormDB.ImportFromDataTemp
{
    public partial class FrmFinishImport : Form
    {
        public delegate void UpdateLog(string s);

        public UpdateLog OnUpdateLog;
        private BackgroundWorker bw;

        List<Detail> detail = new List<Detail>();
        List<DataDetail> table = new List<DataDetail>();
        public FrmFinishImport()
        {
            InitializeComponent();
            this.richTextBox1.Text = string.Format("================{0} {1}===============", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());
            this.richTextBox1.Text += "\r\n";
            this.richTextBox1.Text += "Import Data From Temp..." + "\r\n\r\n";
            OnUpdateLog = (s) =>
            {
                this.richTextBox1.Text += s + "\r\n";
            };
        }
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            Application.DoEvents();
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            ProcessImport(e);
            // bao cao tien do

        }
        private void ProcessImport(DoWorkEventArgs e)
        {
            try
            {
                // Đọc File XML Data
                XmlDocument docProcess = new XmlDocument();
                docProcess.Load(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\dataImportCheck.xml");

                //lấy Table từ table sau khi check chọn
                var Table = docProcess.GetElementsByTagName("Function");

                foreach (XmlNode item in Table)
                {
                    table.Add(new DataDetail
                    {
                        ID = item.SelectNodes("ID").Item(0).InnerText,
                        Table = item.SelectNodes("Table").Item(0).InnerText,
                        Condition = item.SelectNodes("Condition").Item(0).InnerText
                    });
                    foreach (XmlNode itemdetail in item.SelectNodes("Detail"))
                    {
                        detail.Add(new Detail
                        {
                            ID = item.SelectNodes("ID").Item(0).InnerText,
                            DetailName = itemdetail.InnerXml,
                            ConditionDetail = itemdetail.Attributes[0].Value
                        });
                    }
                }
                var Posted = docProcess.GetElementsByTagName("Posted").Item(0).InnerText;
                var Overwrite = docProcess.GetElementsByTagName("OverWrite").Item(0).InnerText;

                // kết nối data lấy dữ liệu bảng muốn chuyển
                using (SqlConnection sourceConnection = new SqlConnection(GetStrConnect.GetStrDsc()))
                {
                    sourceConnection.Open();

                    //Lọc từng Table từ danh sách trong file XML

                    int i = 1;
                    //Import Master
                    foreach (var tableName in table)
                    {

                        //Lấy danh sách Data
                        SqlDataAdapter sqlDA;
                        sqlDA = new SqlDataAdapter("Select zzzlvimport" + tableName.Table + ".* from zzzlvimport" + tableName.Table + " Where " + tableName.Condition, sourceConnection);


                        var ds = new DataSet();
                        sqlDA.Fill(ds);

                        //Khởi tạo danh sách Column, dataTable, Khóa chính cột ----> Khi chạy từng vòng lặp
                        List<string> column = new List<string>();
                        Dictionary<string, string> openWith = new Dictionary<string, string>();
                        DataTable dataTable = new DataTable();

                        //check Posted

                        if (Posted.ToString() == "True" && i == 1)
                        {
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                row.SetField("Posted", 0);
                            }
                        }
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
                            this.Invoke(OnUpdateLog, "Import " + tableName.Table + ", Rows: " + dataTable.Rows.Count);
                        }
                        //===========//
                        //Import Detail//                      
                        foreach (var item in detail)
                        {
                            if (item.ID == tableName.ID)
                            {
                                SqlDataAdapter sqlDAdetail;
                                string query = "Select * From zzzlvimport" + item.DetailName;
                                sqlDAdetail = new SqlDataAdapter(query, sourceConnection);

                                var dsdetail = new DataSet();
                                sqlDAdetail.Fill(dsdetail);

                                //Khởi tạo danh sách Column, dataTable, Khóa chính cột ----> Khi chạy từng vòng lặp
                                List<string> columnDetail = new List<string>();
                                Dictionary<string, string> openWithDetail = new Dictionary<string, string>();
                                DataTable dataTableDetail = new DataTable();
                                DataTable results = new DataTable();


                                dataTableDetail = dsdetail.Tables[0];


                                var resultsDetail = from tableMaster in dataTable.AsEnumerable()
                                                    join tableDetail in dataTableDetail.AsEnumerable() on tableMaster[0] equals tableDetail[item.ConditionDetail]
                                                    select tableDetail;
                                results = resultsDetail.CopyToDataTable();
                                //Lấy danh sách Column trong Danh sách
                                //Lấy Khóa chính trong danh sách Column
                                foreach (var itemDetail in results.Columns)
                                {
                                    openWithDetail.Add(itemDetail.ToString(), itemDetail.ToString());
                                    columnDetail.Add(itemDetail.ToString());
                                }
                                var a = results.Rows.Count;
                                using (SqlConnection descConnection = new SqlConnection(GetStrConnect.GetStrDsc()))
                                {
                                    descConnection.Open();
                                    CopyData(descConnection, item.DetailName, results, bool.Parse(Overwrite), openWithDetail, item.DetailName, null, columnDetail[0]);
                                    this.Invoke(OnUpdateLog, "Import " + item.DetailName + ", Rows: " + results.Rows.Count);
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
                    var a = dt.Rows.Count;
                    bulkCopy.WriteToServer(dt);
                    bulkCopy.Close();
                }

                var insertString = InsertString(cloumnMap)[0];
                var insertStringAlias = InsertString(cloumnMap)[1];

                var keyCol = ColumnKey;
                if (string.IsNullOrEmpty(keyCol)) keyCol = "DocumentID";

                if (overwrite)
                {
                    if (!string.IsNullOrEmpty(tableDetail))
                    {
                        cmd1.CommandText = "DELETE M FROM #zzzlvimport" + tablename + " T INNER JOIN " + tableDetail + " M ON T." + keyCol + "= M." + keyCol + " \r\n";
                        cmd1.ExecuteNonQuery();
                    }

                    cmd1.CommandText = "DELETE M FROM #zzzlvimport" + tablename + " T INNER JOIN " + tablename + " M ON T." + keyCol + "= M." + keyCol + " \r\n";
                    cmd1.ExecuteNonQuery();

                    cmd1.CommandText = "INSERT INTO " + tablename + "(" + insertString + ") SELECT " + insertStringAlias + " FROM #zzzlvimport" + tablename + " T ";
                }
                else
                {
                    cmd1.CommandText = "INSERT INTO " + tablename + "(" + insertString + ") SELECT " + insertStringAlias + " FROM #zzzlvimport" + tablename + " T LEFT JOIN " + tablename + " M ON T." + keyCol + "= M." + keyCol + " WHERE M." + keyCol + " IS NULL";
                }

                cmd1.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception exp)
            {
                tran.Rollback();
                throw exp;
            }
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


        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.btnFinish.Enabled = true;
            if (string.IsNullOrEmpty(e.Result as string))
            {
                MessageBox.Show("Import dữ liệu thành công");
                richTextBox1.Text = richTextBox1.Text + "\r\n" + "Import into table SUCCESS !! " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
            }
            else
            {
                MessageBox.Show(e.Result.ToString());
            }
        }



        private void btnFinish_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmFinishImport_Load(object sender, EventArgs e)
        {
            bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true; // ho tro bao cao tien do
            bw.WorkerSupportsCancellation = true; // cho phep dung tien trinh

            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
            bw.DoWork += Bw_DoWork;
            bw.ProgressChanged += bw_ProgressChanged;

            this.btnFinish.Enabled = false;
            this.progressBar1.Visible = true;
            bw.RunWorkerAsync();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSavelog_Click(object sender, EventArgs e)
        {
            LogWriter log = new LogWriter(richTextBox1.Text, "import");
            MessageBox.Show("Lưu File thành công");

        }

        private void FrmFinishImport_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormMain frm = new FormMain();
            Hide();
            frm.Show();
        }

        private void btnchitiet_Click(object sender, EventArgs e)
        {
            string textname ="";
            int textcount = 0;
            List<TableOld> TableOld = new List<TableOld>();
            List<TableNew> TableNew = new List<TableNew>();
            int CountSrc = 0, CountDsc = 0;
            DataSet dsdetailSrc, dsSrc, dsDsc, dsdetailDsc;
            using (SqlConnection conn = new SqlConnection(GetStrConnect.GetStrDsc()))
            {
                conn.Open();

                foreach (var tableName in table)
                {

                    //Lấy danh sách Data
                    SqlDataAdapter sqlDA;
                    sqlDA = new SqlDataAdapter("Select zzzlvimport" + tableName.Table + ".* from zzzlvimport" + tableName.Table + " Where " + tableName.Condition, conn);


                    dsSrc = new DataSet();
                    sqlDA.Fill(dsSrc);
                    TableOld.Add(new TableOld {
                        tableNameOld = tableName.Table,
                        RowsCountOld = (int)dsSrc.Tables[0].Rows.Count,
                    });
                    foreach (var item in detail)
                    {
                        if (item.ID == tableName.ID)
                        {
                            SqlDataAdapter sqlDAdetail;
                            string query = "Select * From zzzlvimport" + item.DetailName;
                            sqlDAdetail = new SqlDataAdapter(query, conn);

                            dsdetailSrc = new DataSet();
                            sqlDAdetail.Fill(dsdetailSrc);
                            TableOld.Add(new TableOld
                            {
                                tableNameOld = item.DetailName,
                                RowsCountOld = dsdetailSrc.Tables[0].Rows.Count,
                            });

                        }
                    }
                }

                foreach (var tableName in table)
                {

                    //Lấy danh sách Data
                    SqlDataAdapter sqlDA;
                    sqlDA = new SqlDataAdapter("Select " + tableName.Table + ".* from " + tableName.Table + " Where " + tableName.Condition, conn);


                    dsDsc = new DataSet();
                    sqlDA.Fill(dsDsc);
                    TableNew.Add(new TableNew
                    {
                        tableNameNew = tableName.Table,
                        RowsCountNew = (int)dsDsc.Tables[0].Rows.Count,
                    });
                    foreach (var item in detail)
                    {
                        if (item.ID == tableName.ID)
                        {
                            SqlDataAdapter sqlDAdetail;
                            string query = "Select * From " + item.DetailName;
                            sqlDAdetail = new SqlDataAdapter(query, conn);

                            dsdetailDsc = new DataSet();
                            sqlDAdetail.Fill(dsdetailDsc);
                            TableNew.Add(new TableNew
                            {
                                tableNameNew = item.DetailName,
                                RowsCountNew = (int)dsdetailDsc.Tables[0].Rows.Count,
                            });
                        }
                    }
                }

                foreach (var itemold in TableOld)
                {
                    foreach (var itemnew in TableNew)
                    {
                        if (itemold.tableNameOld==itemnew.tableNameNew)
                        {
                            textname += itemold.tableNameOld;
                            textname += "\r\n";

                            textcount += itemnew.RowsCountNew-itemold.RowsCountOld;
                            //textcount += ;

                        }
                    }
                }

                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private class TableOld
        {
            public string tableNameOld { get; set; }
            public int RowsCountOld { get; set; }
        }
        private class TableNew
        {
            public string tableNameNew { get; set; }
            public int RowsCountNew { get; set; }
        }
    }
}
