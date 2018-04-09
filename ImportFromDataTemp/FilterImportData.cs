﻿using System;
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
    public partial class FilterImportData : Form
    {
        private List<DataDetail> data = new List<DataDetail>();

        List<Detail> detail = new List<Detail>();
        public FilterImportData()
        {
            InitializeComponent();
            dtpfromdate.CustomFormat = "dd/MM/yyyy";
            dtptodate.CustomFormat = "dd/MM/yyyy";
            GetDatabaseList();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmListData frmList = new FrmListData();
            Hide();
            frmList.Show();
        }

        public string CheckData()
        {
            try
            {
                DataTable dtLockData = new DataTable();
                DataTable dtdata = new DataTable();
                using (SqlConnection conn = new SqlConnection(GetStrConnect.GetStrSrc()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("select * from AD_tblLockDataParameter", conn))
                    {
                        dtLockData.Load(cmd.ExecuteReader());
                    }
                    string Condition;
                    if (data[0].Condition != null)
                    {
                        Condition = data[0].Condition + " and  ";
                    }
                    else
                        Condition = "";
                    using (SqlCommand cmd1 = new SqlCommand())
                    {
                        cmd1.Connection = conn;
                        cmd1.CommandType = CommandType.Text;
                        if (chkDocDate.Checked && chkBatchNo.Checked)
                        {
                            cmd1.CommandText = "select * from " + data[0].Table + " Where " + Condition + "  DocumentDate between '" + dtpfromdate.Value.ToShortDateString() + "' and '" + dtptodate.Value.ToShortDateString() + "' and BatchNo like '" + cbbBatchNo.Text.ToString().Replace("*", "%") + "'";
                            dtdata.Load(cmd1.ExecuteReader());
                            if (dtdata.Rows.Count <= 0)
                            {

                                return "0";
                            }
                            else
                            {
                                //check ngày khóa chứng từ
                                foreach (DataRow row in dtLockData.Rows)
                                {
                                    foreach (var item in data)// duyệt danh sách chọn
                                    {
                                        if (row["FunctionID"].ToString() == item.ID) // kiểm tra có chức năng khóa
                                        {
                                            foreach (DataRow rowdata in dtdata.Rows)
                                            {
                                                if ((DateTime)row["ClosedToDate"] >= (DateTime)rowdata["DocumentDate"])
                                                {
                                                    return item.Name;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        else if (chkBatchNo.Checked)
                        {
                            cmd1.CommandText = "select * from " + data[0].Table + " Where " + Condition + "  BatchNo like '" + cbbBatchNo.Text.ToString().Replace("*", "%") + "'";
                            dtdata.Load(cmd1.ExecuteReader());
                            if (dtdata.Rows.Count <= 0)
                            {

                                return "0";
                            }
                            else
                            {
                                //check ngày khóa chứng từ
                                foreach (DataRow row in dtLockData.Rows)
                                {
                                    foreach (var item in data)// duyệt danh sách chọn
                                    {
                                        if (row["FunctionID"].ToString() == item.ID) // kiểm tra có chức năng khóa
                                        {
                                            foreach (DataRow rowdata in dtdata.Rows)
                                            {
                                                if ((DateTime)row["ClosedToDate"] >= (DateTime)rowdata["DocumentDate"])
                                                {
                                                    return item.Name;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (chkDocDate.Checked)
                        {
                            cmd1.CommandText = "select * from " + data[0].Table + " Where " + Condition + "  DocumentDate between '" + dtpfromdate.Value.ToShortDateString() + "' and '" + dtptodate.Value.ToShortDateString() + "'";
                            dtdata.Load(cmd1.ExecuteReader());
                            if (dtdata.Rows.Count <= 0)
                            {

                                return "0";
                            }
                            else
                            {
                                //check ngày khóa chứng từ
                                foreach (DataRow row in dtLockData.Rows)
                                {
                                    foreach (var item in data)// duyệt danh sách chọn
                                    {
                                        if (row["FunctionID"].ToString() == item.ID) // kiểm tra có chức năng khóa
                                        {
                                            foreach (DataRow rowdata in dtdata.Rows)
                                            {
                                                if ((DateTime)row["ClosedToDate"] >= (DateTime)rowdata["DocumentDate"])
                                                {
                                                    return item.Name;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            cmd1.CommandText = "select * from " + data[0].Table + " Where " + Condition.Replace("and  ", "");
                            dtdata.Load(cmd1.ExecuteReader());
                            if (dtdata.Rows.Count <= 0)
                            {

                                return "0";
                            }
                            else
                            {
                                //check ngày khóa chứng từ
                                foreach (DataRow row in dtLockData.Rows)
                                {
                                    foreach (var item in data)// duyệt danh sách chọn
                                    {
                                        if (row["FunctionID"].ToString() == item.ID) // kiểm tra có chức năng khóa
                                        {
                                            foreach (DataRow rowdata in dtdata.Rows)
                                            {
                                                if ((DateTime)row["ClosedToDate"] >= (DateTime)rowdata["DocumentDate"])
                                                {
                                                    return item.Name;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return "1";
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Lỗi: " + ex.Message);
                return "0";
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (CheckData() == "0")
            {
                MessageBox.Show(@"Không có dữ liệu");
                return;
            }
            if (CheckData().Length > 2)
            {
                MessageBox.Show(@"Chức năng " + CheckData() + @" có chừng từ bị khóa ");
                return;
            }



            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            XmlWriter writer = XmlWriter.Create(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\dataImportCheck.xml", settings);

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
                    writer.WriteElementString("Condition", item.Condition + " And DocumentDate between '" + dtpfromdate.Value.ToShortDateString() + "' and '" + dtptodate.Value.ToShortDateString() + "' and BatchNo ='" + cbbBatchNo.Text.ToString() + "'");
                }
                else
                {
                    if (chkBatchNo.Checked)
                    {
                        writer.WriteElementString("Condition", item.Condition + " and BatchNo ='" + cbbBatchNo.Text.ToString() + "'");
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

            FrmChkPostedImport frmCheckPosted = new FrmChkPostedImport();
            Hide();
            frmCheckPosted.Show();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FilterImportData_Load(object sender, EventArgs e)
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
        public void GetDatabaseList()
        {
            try
            {

                using (SqlConnection con = new SqlConnection(GetStrConnect.GetStrSrc()))
                {
                    con.Open();

                    // Set up a command with the given query and associate
                    // this with the current connection.
                    using (SqlCommand cmd = new SqlCommand("SELECT BatchNo,BatchDesc from GL_tblBatchList", con))
                    {
                        var adapter = new SqlDataAdapter(cmd);
                        var ds = new DataSet();
                        adapter.Fill(ds);

                        cbbBatchNo.Properties.DataSource = ds.Tables[0];

                        cbbBatchNo.Properties.DisplayMember = "BatchNo";
                        cbbBatchNo.Properties.ValueMember = "BatchNo";
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Connect Fail");

            }
        }


        private void FilterImportData_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult tl;
            tl = MessageBox.Show(@"Bạn có muốn hủy thao tác và quay lại màn hình chính", @"Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void chkBatchNo_CheckedChanged(object sender, EventArgs e)
        {
            cbbBatchNo.Enabled = chkBatchNo.Checked;
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

        private void cbbBatchNo_EditValueChanged(object sender, EventArgs e)
        {
            cbbBatchNo.Text = cbbBatchNo.Text.ToString();
        }
    }
}
