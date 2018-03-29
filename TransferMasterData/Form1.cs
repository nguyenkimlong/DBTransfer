using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using TestFormDB.TransferMasterData;

namespace TestFormDB
{
    public partial class Form1 : Form
    {
        private SqlConnection conn;
        private SqlConnection conn1;
        private String str, str1;
        private string database;

        public Form1()
        {
            InitializeComponent();
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

        private void rbtnuserServer_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        public List<string> GetDatabaseList()
        {
            try
            {
                List<string> list = new List<string>();

                // Open connection to the database
                string conString = "Data Source=" + txtserver.Text + ";Database=" + cbbDatabase.Text + ";User Id=" + txtUsername.Text + ";Password=" + txtPassword.Text + "; pooling=false";

                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();

                    // Set up a command with the given query and associate
                    // this with the current connection.
                    using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", con))
                    {
                        using (IDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                list.Add(dr[0].ToString());
                            }
                        }
                    }
                }
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cbbDatabase.DataSource = GetDatabaseList();
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            FrmInfoTransfer frmInfo = new FrmInfoTransfer();
            Hide();
            frmInfo.Show();
        }

        private void cbbDatabase_TextChanged(object sender, EventArgs e)
        {
            if (cbbDatabase.Text == "")
                cbbDatabase.Text = database;
        }

        private void btnNext_Click(object sender, EventArgs e)
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
                TransferDB transferDB = new TransferDB();
                Hide();
                transferDB.Show();
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            FrmWelcomeMaster formMain = new FrmWelcomeMaster();
            this.Hide();
            formMain.Show();
        }
    }
}