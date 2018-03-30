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
    public partial class FrmSrcDatabase : Form
    {
        public FrmSrcDatabase()
        {
            InitializeComponent();
        }

        private void FrmSrcDatabase_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\configSrc.xml");
            var checkSave = doc.GetElementsByTagName("ChkSave").Item(0).InnerText;
            if (bool.Parse(checkSave) == true)
            {
                this.txtserver.Text = doc.GetElementsByTagName("SrcServerName").Item(0).InnerText;
                this.txtUsername.Text = doc.GetElementsByTagName("SrcUserName").Item(0).InnerText;
                this.txtPassword.Text = doc.GetElementsByTagName("SrcPassword").Item(0).InnerText;
                cbbDatabase.Items.Add(doc.GetElementsByTagName("SrcDatabase").Item(0).InnerText);
                chkSavepass.Checked = bool.Parse(checkSave);
                cbbDatabase.SelectedIndex = 0;
            }
        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            FrmWelcomeImport formWelcome = new FrmWelcomeImport();
            Hide();
            formWelcome.Show();
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            string conString = "Data Source=" + txtserver.Text + ";Database=" + cbbDatabase.Text + ";User Id=" + txtUsername.Text + ";Password=" + txtPassword.Text + "; pooling=false";

            if (!ConnectSQL.CheckConnect(conString))
            {
                MessageBox.Show("Connect Fail");
                return;
            }
            else
            {
                if (chkSavepass.Checked == true)
                {
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;

                    XmlWriter writer = XmlWriter.Create(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\config.xml", settings);

                    writer.WriteStartDocument();
                    writer.WriteComment("This file is generated by the program.");
                    writer.WriteStartElement("Root");
                    writer.WriteStartElement("LVConfig");
                    writer.WriteElementString("SrcServerName", txtserver.Text);
                    writer.WriteElementString("SrcUserName", txtUsername.Text);
                    writer.WriteElementString("SrcPassword", txtPassword.Text);
                    writer.WriteElementString("SrcDatabase", cbbDatabase.Text);
                    writer.WriteElementString("ChkSave", chkSavepass.Checked.ToString());
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Flush();
                    writer.Close();
                }
                FrmDscDatabase frmTransfer = new FrmDscDatabase();
                Hide();
                frmTransfer.Show();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cbbDatabase.DataSource = GetDatabase.GetDatabaseList(txtserver.Text, null, txtUsername.Text, txtPassword.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmSrcDatabase_FormClosing(object sender, FormClosingEventArgs e)
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

        private void rbtnuserWindow_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnuserWindow.Checked == true)
            {
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtUsername.Enabled = false;
                txtPassword.Enabled = false;
            }
            else
            {
                txtUsername.Enabled = true;
                txtPassword.Enabled = true;
            }
        }
    }
}
