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

namespace TestFormDB.ImportFromDataTemp
{
    public partial class FrmListData : Form
    {
        public FrmListData()
        {
            InitializeComponent();
            lstwtable.OwnerDraw = true;
        }
        List<Detail> detail = new List<Detail>();
        List<DataDetail> getdata = new List<DataDetail>();

        private void btnback_Click(object sender, EventArgs e)
        {
            FrmDscDatabase frmTransferDes = new FrmDscDatabase();
            Hide();
            frmTransferDes.Show();
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            List<DataDetail> data = new List<DataDetail>();
            data = GetListCheck();

            if (data.Count == 0)
            {
                MessageBox.Show("Chưa chọn Danh sách");
                return;
            }

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            XmlWriter writer = XmlWriter.Create(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\dataImportCheck.xml", settings);

            writer.WriteStartDocument();
            writer.WriteComment("This file is generated by the program.");
            writer.WriteStartElement("Root");

            foreach (var item in data)
            {
                writer.WriteStartElement("Function");
                writer.WriteElementString("ID", item.ID);
                writer.WriteElementString("Name", item.Name);
                writer.WriteElementString("Table", item.Table);
                writer.WriteElementString("Condition", item.Condition);
                writer.WriteElementString("Language", item.Language);
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

            FilterImportData frmFilter = new FilterImportData();
            Hide();
            frmFilter.Show();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmListData_Load(object sender, EventArgs e)
        {
            lstwtable.View = View.Details;
            lstwtable.GridLines = true;
            lstwtable.FullRowSelect = true;
            lstwtable.CheckBoxes = true;

            //Add column header
            lstwtable.Columns.Add("", 50, HorizontalAlignment.Center);
            lstwtable.Columns.Add("Data", 500);

            ListViewItem itm;
            string[] chuoitach;
            try
            {
                XmlDocument docProcess = new XmlDocument();
                docProcess.Load(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\dataSrcExportCheck.xml");

                var after = docProcess.GetElementsByTagName("Mapping");
                var Table = docProcess.GetElementsByTagName("Function");
                var listdetail = docProcess.GetElementsByTagName("TableDetail");

                string[] arrdetail = new string[2];
                foreach (XmlNode itemlist in listdetail)
                {
                    var ID = itemlist.SelectNodes("Detail").Item(0).InnerText;
                    var ConditionDetail = itemlist.SelectNodes("Detail").Item(0).Attributes["Ref"].Value;
                    detail.Add(new Detail
                    {
                        DetailName = ID,
                        ConditionDetail = ConditionDetail
                    });
                    //arrdetail[0] = ID;
                    //arrdetail[1] = ConditionDetail;

                }

                string[] arr = new string[6];
                foreach (XmlNode item in Table)
                {
                    var ID = item.SelectNodes("ID").Item(0).InnerText;
                    var Name = item.SelectNodes("Name").Item(0).InnerText;
                    var table = item.SelectNodes("Table").Item(0).InnerText;
                    var Language = item.SelectNodes("Language").Item(0).InnerText;

                    var Detail = item.SelectNodes("Detail");

                    var condition = item.SelectNodes("Condition").Item(0).InnerText;
                    arr[1] = Name;
                    arr[2] = table;
                    arr[3] = condition;
                    arr[4] = ID;
                    arr[5] = Language;
                    itm = new ListViewItem(arr);
                    foreach (XmlNode itemdetail in Detail)
                    {
                        detail.Add(new Detail
                        {
                            ID = ID,
                            DetailName = itemdetail.InnerXml,
                            ConditionDetail = itemdetail.Attributes[0].Value
                        });

                    }
                    lstwtable.Columns[1].ListView.Items.Add(itm);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private List<DataDetail> GetListCheck()
        {
            List<DataDetail> ArrList = new List<DataDetail>();
            //lstwtable.ItemChecked += new ItemCheckedEventHandler(lstwtable_ItemChecked);

            foreach (ListViewItem item in lstwtable.CheckedItems)
            {
                ArrList.Add(new DataDetail()
                {
                    ID = item.SubItems[4].Text,
                    Name = item.SubItems[1].Text,
                    Table = item.SubItems[2].Text,
                    Condition = item.SubItems[3].Text,
                    Language = item.SubItems[5].Text,
                });
            }
            return ArrList;
        }


        private void lstwtable_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(this.lstwtable.Columns[e.Column].Tag);
                }
                catch (Exception)
                {
                }
                this.lstwtable.Columns[e.Column].Tag = !value;
                foreach (ListViewItem item in this.lstwtable.Items)
                    item.Checked = !value;

                this.lstwtable.Invalidate();
            }
        }

        private void lstwtable_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.DrawBackground();
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(e.Header.Tag);
                }
                catch (Exception)
                {
                }
                CheckBoxRenderer.DrawCheckBox(e.Graphics, new Point(e.Bounds.Left + 4, e.Bounds.Top + 4),
                    value ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal :
                    System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void lstwtable_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lstwtable_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void FrmListData_FormClosing(object sender, FormClosingEventArgs e)
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