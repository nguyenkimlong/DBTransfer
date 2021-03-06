﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TestFormDB.ExportDataToTemp
{
    public partial class FrmInforExportData : Form
    {
        public FrmInforExportData()
        {
            InitializeComponent();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            FrmCheckPosted frmCheck = new FrmCheckPosted();
            Hide();
            frmCheck.Show();
        }

        private void FrmInforExportData_Load(object sender, EventArgs e)
        {
            // Đọc File XML data Nguồn
            XmlDocument dataSrc = new XmlDocument();
            dataSrc.Load(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\configSrc.xml");
            string SrcServerName = dataSrc.GetElementsByTagName("SrcServerName").Item(0).InnerText;
            string SrcUserName = dataSrc.GetElementsByTagName("SrcUserName").Item(0).InnerText;
            string SrcPassword = dataSrc.GetElementsByTagName("SrcPassword").Item(0).InnerText;
            string SrcDatabase = dataSrc.GetElementsByTagName("SrcDatabase").Item(0).InnerText;

            // Đọc File XML data Đích
            XmlDocument dataDsc = new XmlDocument();
            dataDsc.Load(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\configDsc.xml");
            string ServerName = dataDsc.GetElementsByTagName("ServerName").Item(0).InnerText;
            string UserName = dataDsc.GetElementsByTagName("UserName").Item(0).InnerText;
            string Password = dataDsc.GetElementsByTagName("Password").Item(0).InnerText;
            string Database = dataDsc.GetElementsByTagName("Database").Item(0).InnerText;

            string sql = @"Microsoft SQL Server";

            richTextBox1.Text = string.Format("\r\n Source: {0} \r\n Location: {1} \r\n Database: {2} \r\n\r\n Destination: {3} \r\n Location: {4} \r\n Database: {5} \r\n\r\n Transaction: ", sql, SrcServerName, SrcDatabase, sql, ServerName, Database);

        }

        private void btnfinish_Click(object sender, EventArgs e)
        {
            FrmFinishTransferData frmFinish = new FrmFinishTransferData();
            Hide();
            frmFinish.Show();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmInforExportData_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
