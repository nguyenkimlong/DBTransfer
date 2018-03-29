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

        private void btnNext_Click(object sender, EventArgs e)
        {
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
                    writer.WriteElementString("Condition", item.Condition + " And DocumentDate between '" + dtpfromdate.Value.ToShortDateString() + "' and '" + dtptodate.Value.ToShortDateString() + "' and BatchNo ='" + cbbBatchNo.SelectedValue.ToString() + "'");
                }
                else
                {
                    if (chkBatchNo.Checked)
                    {
                        writer.WriteElementString("Condition", item.Condition + " and BatchNo ='" + cbbBatchNo.SelectedValue.ToString() + "'");
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
                docProcess.Load(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\dataImportCheck.xml");

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
                string server, username, pass, database;
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
                        var adapter = new SqlDataAdapter(cmd);
                        var ds = new DataSet();
                        adapter.Fill(ds);
                        cbbBatchNo.DataSource = ds.Tables[0];
                        cbbBatchNo.DisplayMember = "BatchDesc";
                        cbbBatchNo.ValueMember = "BatchNo";
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
    }
}
