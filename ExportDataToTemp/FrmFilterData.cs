using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace TestFormDB.ExportDataToTemp
{

    public partial class FrmFilterData : Form
    {
        private List<DataDetail> data = new List<DataDetail>();

        List<Detail> detail = new List<Detail>();
        string server, username, pass, database;
        public FrmFilterData()
        {
            InitializeComponent();
            dtpfromdate.CustomFormat = "dd/MM/yyyy";
            dtptodate.CustomFormat = "dd/MM/yyyy";
            GetDatabaseList();
        }

        private void FrmFilterData_Load(object sender, EventArgs e)
        {
            try
            {
                XmlDocument docProcess = new XmlDocument();
                docProcess.Load(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\dataSrcExportCheck.xml");

                var after = docProcess.GetElementsByTagName("Root");
                var Table = docProcess.GetElementsByTagName("Function");
                foreach (XmlNode item in Table)
                {
                    data.Add(new DataDetail
                    {
                        ID = item.SelectNodes("ID").Item(0).InnerText,
                        Name = item.SelectNodes("Name").Item(0).InnerText,
                        Table = item.SelectNodes("Table").Item(0).InnerText,
                        Condition = item.SelectNodes("Condition").Item(0).InnerText,
                        Language = item.SelectNodes("Language").Item(0).InnerText
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkBatchNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBatchNo.Checked)
            {
                cbbBatchNo.Enabled = true;
            }
            else
                cbbBatchNo.Enabled = false;
        }

        private void chkDocDate_CheckedChanged(object sender, EventArgs e)
        {

            if (chkDocDate.Checked)
            {
                dtpfromdate.Enabled = true;
                dtptodate.Enabled = true;
            }
            else
            {
                dtpfromdate.Enabled = false;
                dtptodate.Enabled = false;
            }
        }

        public void CheckData()
        {
            try
            {
                string conString = "Data Source=" + server + ";Database=" + database + ";User Id=" + username + ";Password=" + pass + "; pooling=false";
                DataTable dtLockData = new DataTable();
                DataTable dtdata = new DataTable();
                using (SqlConnection conn = new SqlConnection(conString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("select * from AD_tblLockDataParameter", conn))
                    {
                        dtLockData.Load(cmd.ExecuteReader());
                    }
                    string Condition;
                    if (data[0].Condition !=null)
                    {
                        Condition = data[0].Condition + " and ";
                    }
                    else
                        Condition = "";
                    using (SqlCommand cmd1 = new SqlCommand())
                    {
                        cmd1.Connection = conn;
                        cmd1.CommandType = CommandType.Text;
                        if (chkDocDate.Checked && chkBatchNo.Checked)
                        {
                            cmd1.CommandText = "select * from " + data[0].Table + " Where " + Condition + "  DocumentDate between '" + dtpfromdate.Value.ToShortDateString() + "' and '" + dtptodate.Value.ToShortDateString() + "' and BatchNo ='" + cbbBatchNo.SelectedValue.ToString().Trim() + "'";
                            dtdata.Load(cmd1.ExecuteReader());
                            if (dtdata.Rows.Count <= 0)
                            {
                                MessageBox.Show("Không có dữ liệu");
                                return ;
                            }
                            else
                            {
                                foreach (DataRow row in dtLockData.Rows)
                                {
                                    if (row["FunctionID"].ToString() == data[0].ID)
                                    {
                                        foreach (DataRow rowdata in dtdata.Rows)
                                        {
                                            
                                        }
                                        break;
                                    }                                 
                                }
                            }
                        }

                        else if (chkBatchNo.Checked)
                        {
                            cmd1.CommandText = "select * from " + data[0].Table + " Where " + Condition + "  BatchNo ='" + cbbBatchNo.SelectedValue.ToString().Trim() + "'";
                            dtdata.Load(cmd1.ExecuteReader());
                            if (dtdata.Rows.Count <= 0)
                            {
                                MessageBox.Show("Không có dữ liệu");
                                return ;
                            }
                            else
                            {

                            }
                        }
                        else if (chkDocDate.Checked)
                        {
                            cmd1.CommandText = "select * from " + data[0].Table + " Where " + Condition + "  DocumentDate between '" + dtpfromdate.Value.ToShortDateString() + "' and '" + dtptodate.Value.ToShortDateString() + "'";
                            dtdata.Load(cmd1.ExecuteReader());
                            if (dtdata.Rows.Count <= 0)
                            {
                                MessageBox.Show("Không có dữ liệu");
                                return ;
                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            cmd1.CommandText = "select * from " + data[0].Table+ " Where " + Condition;
                            dtdata.Load(cmd1.ExecuteReader());
                            if (dtdata.Rows.Count <= 0)
                            {
                                MessageBox.Show("Không có dữ liệu");
                                return ;
                            }
                            else
                            {

                            }
                        }
                    }
                }              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: ",ex.Message);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {



            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            XmlWriter writer = XmlWriter.Create(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\dataSrcExportCheck.xml", settings);

            writer.WriteStartDocument();
            writer.WriteComment("This file is generated by the program.");
            writer.WriteStartElement("Mapping");

            foreach (var item in data)
            {
                writer.WriteStartElement("Function");
                writer.WriteElementString("ID", item.ID);
                writer.WriteElementString("Name", item.Name);
                writer.WriteElementString("Table", item.Table);
                writer.WriteElementString("Language", item.Language);
                if (chkDocDate.Checked && chkBatchNo.Checked)
                {
                    writer.WriteElementString("Condition", item.Condition + " And DocumentDate between '" + dtpfromdate.Value.ToShortDateString() + "' and '" + dtptodate.Value.ToShortDateString() + "' and BatchNo ='" + cbbBatchNo.SelectedValue.ToString().Trim() + "'");
                }
                else
                {
                    if (chkBatchNo.Checked)
                    {
                        writer.WriteElementString("Condition", item.Condition + " and BatchNo ='" + cbbBatchNo.SelectedValue.ToString().Trim() + "'");
                    }
                    else if (chkDocDate.Checked)
                    {
                        writer.WriteElementString("Condition", item.Condition + " And DocumentDate between '" + dtpfromdate.Value.ToShortDateString() + "' and '" + dtptodate.Value.ToShortDateString() + "'");
                    }
                    else
                    {
                        writer.WriteElementString("Condition", item.Condition);
                    }
                }
                //writer.WriteElementString("Condition", item.Condition);
                foreach (var itemdetail in detail)
                {
                    if (itemdetail.ID == item.ID)
                    {
                        writer.WriteStartElement("Detail");

                        writer.WriteAttributeString("Ref", itemdetail.ConditionDetail);

                        writer.WriteString(itemdetail.DetailName);
                        writer.WriteEndElement();
                    }
                }

                writer.WriteEndElement();
                //}
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            writer.Close();



            FrmCheckPosted frmCheckPosted = new FrmCheckPosted();
            Hide();
            frmCheckPosted.Show();
        }

        public void GetDatabaseList()
        {
            try
            {

                XmlDocument doc = new XmlDocument();
                doc.Load(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\configSrc.xml");

                server = doc.GetElementsByTagName("SrcServerName").Item(0).InnerText;
                username = doc.GetElementsByTagName("SrcUserName").Item(0).InnerText;
                pass = doc.GetElementsByTagName("SrcPassword").Item(0).InnerText;
                database = doc.GetElementsByTagName("SrcDatabase").Item(0).InnerText;

                // Open connection to the database
                string conString = "Data Source=" + server + ";Database=" + database + ";User Id=" + username + ";Password=" + pass + "; pooling=false";

                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();

                    // Set up a command with the given query and associate
                    // this with the current connection.
                    using (SqlCommand cmd = new SqlCommand("SELECT BatchNo,BatchDesc from GL_tblBatchList", con))
                    {
                        DataTable dt = new DataTable();
                        var adapter = new SqlDataAdapter(cmd);
                        var ds = new DataSet();
                        adapter.Fill(ds);
                        dt = ds.Tables[0];
                        dt.Columns.Add("CustomBatch", typeof(string));
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row["BatchNo"].ToString().Length <= 20)
                            {
                                var i = 20 - row["BatchNo"].ToString().Length;
                                row["BatchNo"] = row["BatchNo"].ToString() + string.Concat(Enumerable.Repeat("  ", i));
                                row["CustomBatch"] = row["BatchNo"].ToString() + " " + row["BatchDesc"].ToString();
                            }
                            else
                            {
                                row["CustomBatch"] = row["BatchNo"].ToString() + " " + row["BatchDesc"].ToString();
                            }
                        }

                        cbbBatchNo.DataSource = ds.Tables[0];
                        cbbBatchNo.DisplayMember = "CustomBatch";
                        cbbBatchNo.ValueMember = "BatchNo";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connect Fail");

            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmListTableSource frmList = new FrmListTableSource();
            Hide();
            frmList.Show();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmFilterData_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult tl;
            tl = MessageBox.Show("Bạn có muốn hủy thao tác và quay lại màn hình chính", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                FormMain frm = new FormMain();
                Hide();
                frm.Show();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void cbbBatchNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}