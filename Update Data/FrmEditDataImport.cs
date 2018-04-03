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

namespace TestFormDB.Update_Data
{
    public partial class FrmEditDataImport : Form
    {
        public class TableNew
        {
            public string IdOld { get; set; }
            public string IdNew { get; set; }
            public bool Multiply { get; set; }
            public decimal RateExchange { get; set; }
        }
        public class ItemList
        {
            public string Id { get; set; }
            public decimal BuyPrice { get; set; }
            public decimal SellPrice { get; set; }
        }
        List<ItemList> itemlist = new List<ItemList>();

        List<DataDetail> data = new List<DataDetail>();

        List<Detail> detail = new List<Detail>();

        List<DataTable> dataTable = new List<DataTable>();

        DataTable dataNew = new DataTable();

        DataTable dtItemList;

        DataTable dtSetup;

        DataTable ForeignCurrList;

        DataTable VATCodeList;

        string ServerName, UserName, Password, Database;

        string SrcServerName, SrcUserName, SrcPassword, SrcDatabase;

        public FrmEditDataImport()
        {
            InitializeComponent();
        }

        private void FrmEditDataImport_Load(object sender, EventArgs e)
        {

            XmlDocument docProcess = new XmlDocument();
            docProcess.Load(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\dataUpdateTemp.xml");

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
                break;
            }
            tabControl1.TabPages[0].Text = data[0].Name;
            LoadDatabase();

            LoadDataTable();

            //Loadlanguage();
        }
        public void LoadDataTable()
        {
            string str = "Data Source=" + SrcServerName + ";Database=" + SrcDatabase + ";User Id=" + SrcUserName + ";Password=" + SrcPassword + "; pooling=false";

            using (SqlConnection sourceConnection = new SqlConnection(str))
            {
                sourceConnection.Open();

                //DataTable IV_tblItemList
                SqlDataAdapter sqlItem;
                dtItemList = new DataTable();

                string ListQuery = "Select * from IV_tblItemList";
                sqlItem = new SqlDataAdapter(ListQuery, sourceConnection);
                var ds = new DataSet();
                sqlItem.Fill(ds);
                dtItemList = ds.Tables[0];
                foreach (DataRow dt in dtItemList.Rows)
                {
                    itemlist.Add(new ItemList
                    {
                        Id = dt["ItemID"].ToString(),
                        BuyPrice = (decimal)dt["BuyPrice"],
                        SellPrice = (decimal)dt["SellPrice"]
                    });
                }


                //DataTable AD_tblSetup
                SqlDataAdapter sqlADsetup;
                dtSetup = new DataTable();

                string QuerySetup = "Select * from AD_tblSetup";
                sqlADsetup = new SqlDataAdapter(QuerySetup, sourceConnection);
                var dsSetup = new DataSet();
                sqlADsetup.Fill(dsSetup);
                dtSetup = dsSetup.Tables[0];

                //DataTable CF_tblForeignCurrList

                SqlDataAdapter sqlForeignCurrList;
                ForeignCurrList = new DataTable();

                string QueryForeignCurrList = "Select * from CF_tblForeignCurrList";
                sqlForeignCurrList = new SqlDataAdapter(QueryForeignCurrList, sourceConnection);
                var dsForeignCurrLis = new DataSet();
                sqlForeignCurrList.Fill(dsForeignCurrLis);
                ForeignCurrList = dsForeignCurrLis.Tables[0];


                //DataTable CF_tblVATCodeList

                SqlDataAdapter sqlVATCodeList;
                VATCodeList = new DataTable();

                string QueryVATCodeList = "Select * from CF_tblVATCodeList";
                sqlVATCodeList = new SqlDataAdapter(QueryVATCodeList, sourceConnection);
                var dsVATCodeList = new DataSet();
                sqlVATCodeList.Fill(dsVATCodeList);
                VATCodeList = dsVATCodeList.Tables[0];
            }
        }

        public void LoadDatabase()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\configDsc.xml");

            ServerName = doc.GetElementsByTagName("ServerName").Item(0).InnerText;
            UserName = doc.GetElementsByTagName("UserName").Item(0).InnerText;
            Password = doc.GetElementsByTagName("Password").Item(0).InnerText;
            Database = doc.GetElementsByTagName("Database").Item(0).InnerText;

            XmlDocument docSrc = new XmlDocument();
            docSrc.Load(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\configSrc.xml");

            SrcServerName = docSrc.GetElementsByTagName("SrcServerName").Item(0).InnerText;
            SrcUserName = docSrc.GetElementsByTagName("SrcUserName").Item(0).InnerText;
            SrcPassword = docSrc.GetElementsByTagName("SrcPassword").Item(0).InnerText;
            SrcDatabase = docSrc.GetElementsByTagName("SrcDatabase").Item(0).InnerText;


        }

        private void btnDanhsoCtu_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string str = "Data Source=" + SrcServerName + ";Database=" + SrcDatabase + ";User Id=" + SrcUserName + ";Password=" + SrcPassword + "; pooling=false";

                using (SqlConnection sourceConnection = new SqlConnection(str))
                {
                    using (SqlCommand command = new SqlCommand("AD_spAutoNumberList", sourceConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@FunctionID", SqlDbType.VarChar, 10).Value = data[0].ID;
                        command.Parameters.Add("@BUID", SqlDbType.VarChar, 30).Value = DBNull.Value;
                        command.Parameters.Add("@BatchNo", SqlDbType.VarChar, 30).Value = DBNull.Value;
                        command.Parameters.Add("@UR", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        command.Parameters.Add("@DD", SqlDbType.Date).Value = DateTime.Now;
                        command.Parameters.Add("@FP", SqlDbType.VarChar, 20).Value = DBNull.Value;
                        command.Parameters.Add("@FQ", SqlDbType.VarChar, 20).Value = DBNull.Value;
                        command.Parameters.Add("@FY", SqlDbType.VarChar, 20).Value = DBNull.Value;
                        command.Parameters.Add("@out", SqlDbType.VarChar, 1000).Direction = ParameterDirection.Output;
                        command.Parameters.Add("@NotUpdateLast", SqlDbType.Bit).Value = 0;
                        sourceConnection.Open();
                        command.ExecuteNonQuery();
                        string stringvar = Convert.ToString(command.Parameters["@out"].Value);
                        ReNumberDocumentID(stringvar);

                    }
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Đánh lại số DocumentID
        /// </summary>
        /// <param name="stringvar">Số tự động</param>
        public void ReNumberDocumentID(string stringvar)
        {
            List<TableNew> table = new List<TableNew>();
            string chu = stringvar.Substring(0, 7);
            int so = int.Parse(stringvar.Substring(stringvar.Length - 4, 4));
            foreach (DataRow row in dataNew.Rows)
            {
                table.Add(new TableNew
                {
                    IdOld = row["DocumentID"].ToString(),
                    IdNew = chu + so.ToString("0000")
                });
                so++;
                row.SetField("DocumentID", chu + so.ToString("0000"));
            }

            //Đánh DocumentID bảng Detail
            foreach (var dataTable in dataTable)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (var item in table)
                    {
                        if (item.IdOld == row["DocumentID"].ToString())
                        {
                            row.SetField("DocumentID", item.IdNew);
                        }
                    }
                }
            }

        }

        public int FormatRound(string format)
        {
            switch (format)
            {
                case "S":
                    return Convert.ToInt16(dtSetup.Rows[0]["App_ForgAmtDec"].ToString());
                case "B":
                    return Convert.ToInt16(dtSetup.Rows[0]["App_BaseAmtDec"].ToString());
                case "P":
                    return Convert.ToInt16(dtSetup.Rows[0]["App_PercentDec"].ToString());
                case "R":
                    return Convert.ToInt16(dtSetup.Rows[0]["App_RateExchDec"].ToString());
                case "Q":
                    return Convert.ToInt16(dtSetup.Rows[0]["App_QuantityDec"].ToString());
                case "U":
                    return Convert.ToInt16(dtSetup.Rows[0]["App_UnitCostDec"].ToString());
                default:
                    return Convert.ToInt16(dtSetup.Rows[0]["App_ForgAmtDec"].ToString());
            }
        }

        private void FrmEditDataImport_FormClosing(object sender, FormClosingEventArgs e)
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

        private void chkngaychungtu_CheckedChanged(object sender, EventArgs e)
        {
            if (chkngaychungtu.Checked)
            {
                dtpToDate.Enabled = dtpFromDate.Enabled = true;
            }
            else
                dtpToDate.Enabled = dtpFromDate.Enabled = false;

        }

        private void chklo_CheckedChanged(object sender, EventArgs e)
        {
            if (chklo.Checked)
            {
                txtLoChungTu.Enabled = true;
            }
            else
                txtLoChungTu.Enabled = false;

        }

        public List<TableNew> GetDataCapNhatGia()
        {
            List<TableNew> table = new List<TableNew>();
            foreach (DataRow row in dataNew.Rows)
            {
                foreach (DataRow item in ForeignCurrList.Rows)
                {
                    if (row["ForgCurrID"].ToString() == item["ForgCurrID"].ToString())
                    {
                        table.Add(new TableNew
                        {
                            IdOld = row["DocumentID"].ToString(),
                            Multiply = (bool)item["Multiply"],
                            RateExchange = (decimal)row["RateExchange"],
                        });
                    }
                }
            }
            return table;
        }
        private void btnCapNhatGia_Click(object sender, EventArgs e)
        {
            try
            {
                if (data[0].Name == "Hóa đơn mua hàng")
                {
                    List<TableNew> table = GetDataCapNhatGia();
                    foreach (DataRow row in dataTable[0].Rows)
                    {
                        foreach (var item in itemlist)
                        {
                            if (row["ItemID"].ToString() == item.Id)
                            {
                                row.SetField("UnitPrice", item.BuyPrice);

                                decimal DiscAmount = Math.Round(((decimal)row["Quantity"] * (decimal)item.BuyPrice * ((decimal)row["DiscPercent"] / 100)), FormatRound("B"));

                                row.SetField("DiscAmount", DiscAmount);

                                decimal FPurcAmount = Math.Round(((decimal)row["Quantity"] * (decimal)item.BuyPrice) - (decimal)row["DiscPercent"] + (decimal)row["MiscCharge"], FormatRound("S"));

                                row.SetField("FPurcAmount", FPurcAmount);

                                decimal BPurcAmount = 0;
                                foreach (var itemTable in table)
                                {
                                    if (itemTable.IdOld == row["DocumentID"].ToString() && itemTable.Multiply)
                                    {
                                        BPurcAmount = Math.Round((decimal)row["FPurcAmount"] * itemTable.RateExchange, FormatRound("B"));
                                        break;
                                    }
                                    else
                                    {
                                        BPurcAmount = Math.Round((decimal)row["FPurcAmount"] / itemTable.RateExchange, FormatRound("B"));
                                        break;
                                    }
                                }

                                row.SetField("BPurcAmount", BPurcAmount);

                                decimal ImpTaxAmount = Math.Round((decimal)row["BPurcAmount"] * (decimal)row["ImpTaxPercent"] / 100, FormatRound("B"));

                                row.SetField("ImpTaxAmount", ImpTaxAmount);

                                decimal ExcTaxAmount = Math.Round(((decimal)row["BPurcAmount"] + (decimal)row["ImpTaxAmount"]) * ((decimal)row["ExcTaxPercent"] / 100), FormatRound("B"));

                                row.SetField("ExcTaxAmount", ExcTaxAmount);

                                decimal EnvTaxAmount = Math.Round((decimal)row["Quantity"] * (decimal)row["EnvTaxPercent"] / 100, FormatRound("B"));

                                row.SetField("EnvTaxAmount", EnvTaxAmount);

                                decimal VATAmountTemp = 0;
                                foreach (DataRow VATCode in VATCodeList.Rows)
                                {
                                    if (!(bool)VATCode["DirectMethod"] && VATCode["VATID"].ToString() == row["VATID"].ToString())
                                    {
                                        switch (VATCode["Formula"].ToString())
                                        {
                                            case "1":
                                                VATAmountTemp = Math.Round(((decimal)row["BPurcAmount"] + (decimal)row["ImpTaxAmount"] + (decimal)row["ExcTaxPercent"] + (decimal)row["EnvTaxAmount"]) * ((decimal)VATCode["TaxPercent"] / 100), FormatRound("B"));
                                                break;
                                            case "2":
                                                VATAmountTemp = Math.Round(((decimal)row["BPurcAmount"] + (decimal)row["ImpTaxAmount"] + (decimal)row["ExcTaxPercent"] + (decimal)row["EnvTaxAmount"]) / (1 + (decimal)VATCode["TaxPercent"] / 100) * ((decimal)VATCode["TaxPercent"] / 100), FormatRound("B"));
                                                break;
                                            case "3":
                                                VATAmountTemp = Math.Round(((decimal)row["BPurcAmount"] + (decimal)row["ImpTaxAmount"] + (decimal)row["ExcTaxPercent"] + (decimal)row["EnvTaxAmount"]) * ((decimal)VATCode["TaxPercent"] / 100), FormatRound("B"));
                                                break;
                                        }
                                        break;
                                    }
                                }

                                row.SetField("VATAmount", VATAmountTemp);

                                decimal PurcAmount = Math.Round((decimal)row["BPurcAmount"] + (decimal)row["ImpTaxAmount"] + (decimal)row["ExcTaxAmount"] + (decimal)row["EnvTaxAmount"] + (decimal)row["VATAmount"], FormatRound("B"));

                                row.SetField("PurcAmount", PurcAmount);
                            }
                        }
                    }
                    MessageBox.Show("Cập nhật thành công");
                }
                else if (data[0].Name == "Hóa đơn bán hàng")
                {
                    List<TableNew> table = GetDataCapNhatGia();
                    DialogResult tl;
                    tl = MessageBox.Show("Bạn có muốn thay đổi đơn giá sau thuế?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (tl == DialogResult.Yes)
                    {
                        foreach (DataRow row in dataTable[0].Rows)
                        {
                            foreach (var item in itemlist)
                            {
                                if (row["ItemID"].ToString() == item.Id)
                                {
                                    row.SetField("UnitPrice", item.SellPrice);

                                    if ((decimal)row["PriceWithVAT"] != 0)
                                    {
                                        decimal PriceWithVAT = 0;
                                        foreach (DataRow VATCode in VATCodeList.Rows)
                                        {
                                            if (VATCode["VATID"].ToString() == row["VATID"].ToString())
                                            {
                                                PriceWithVAT = Math.Round((decimal)row["UnitPrice"] * (1 + ((decimal)VATCode["TaxPercent"] / 100)), FormatRound("U"));
                                                break;
                                            }
                                        }

                                        row.SetField("PriceWithVAT", PriceWithVAT);

                                        decimal DiscAmount = Math.Round((decimal)row["Quantity"] * ((decimal)row["UnitPrice"] - (decimal)row["MinusOnPrice"] - (decimal)row["TransFee"]) * ((decimal)row["DiscPercent"] / 100), FormatRound("B"));

                                        row.SetField("DiscAmount", DiscAmount);

                                        decimal FSaleAmount = Math.Round((decimal)row["Quantity"] * ((decimal)row["UnitPrice"] - (decimal)row["MinusOnPrice"] - (decimal)row["TransFee"]) - (decimal)row["DiscAmount"], FormatRound("S"));

                                        row.SetField("FSaleAmount", FSaleAmount);

                                        decimal BSaleAmount = 0;
                                        foreach (var itemTable in table)
                                        {
                                            if (itemTable.IdOld == row["DocumentID"].ToString() && itemTable.Multiply)
                                            {
                                                BSaleAmount = Math.Round((decimal)row["FSaleAmount"] * itemTable.RateExchange, FormatRound("B"));
                                                break;
                                            }
                                            else
                                            {
                                                BSaleAmount = Math.Round((decimal)row["FSaleAmount"] / itemTable.RateExchange, FormatRound("B"));
                                                break;
                                            }
                                        }

                                        row.SetField("BSaleAmount", BSaleAmount);

                                        decimal ExpTaxAmount = Math.Round((decimal)row["BSaleAmount"] * (decimal)row["ExpTaxPercent"] / 100, FormatRound("B"));

                                        row.SetField("ExpTaxAmount", ExpTaxAmount);

                                        decimal ExcTaxAmount = Math.Round(((decimal)row["BSaleAmount"] + (decimal)row["ExpTaxAmount"]) * ((decimal)row["ExcTaxPercent"] / 100), FormatRound("B"));

                                        row.SetField("ExcTaxAmount", ExcTaxAmount);

                                        decimal EnvTaxAmount = Math.Round((decimal)row["Quantity"] * (decimal)row["EnvTaxPercent"] / 100, FormatRound("B"));

                                        row.SetField("EnvTaxAmount", EnvTaxAmount);

                                        decimal VATAmount = 0;
                                        foreach (DataRow VATCode in VATCodeList.Rows)
                                        {
                                            if (!(bool)VATCode["DirectMethod"] && VATCode["VATID"].ToString() == row["VATID"].ToString())
                                            {
                                                switch (VATCode["Formula"].ToString())
                                                {
                                                    case "1":
                                                        VATAmount = Math.Round(((decimal)row["BSaleAmount"] + (decimal)row["ExpTaxAmount"] + (decimal)row["ExcTaxAmount"] + (decimal)row["EnvTaxAmount"]) * ((decimal)VATCode["TaxPercent"] / 100), FormatRound("B"));
                                                        break;
                                                    case "2":
                                                        VATAmount = Math.Round(((decimal)row["BSaleAmount"] + (decimal)row["ExpTaxAmount"] + (decimal)row["ExcTaxAmount"] + (decimal)row["EnvTaxAmount"]) / (1 + (decimal)VATCode["TaxPercent"] / 100) * ((decimal)VATCode["TaxPercent"] / 100), FormatRound("B"));
                                                        break;
                                                    case "3":
                                                        VATAmount = Math.Round(((decimal)row["BSaleAmount"] + (decimal)row["ExpTaxAmount"] + (decimal)row["ExcTaxAmount"] + (decimal)row["EnvTaxAmount"]) * ((decimal)VATCode["TaxPercent"] / 100), FormatRound("B"));
                                                        break;
                                                }
                                                break;
                                            }
                                        }

                                        row.SetField("VATAmount", VATAmount);

                                        decimal SellingAmount = Math.Round((decimal)row["BSaleAmount"] + (decimal)row["ExpTaxAmount"] + (decimal)row["ExcTaxAmount"] + (decimal)row["EnvTaxAmount"] + (decimal)row["VATAmount"], FormatRound("B"));

                                        row.SetField("SellingAmount", SellingAmount);
                                    }
                                    else
                                    {
                                        decimal PriceWithVAT = 0;
                                        foreach (DataRow VATCode in VATCodeList.Rows)
                                        {
                                            if (VATCode["VATID"].ToString() == row["VATID"].ToString())
                                            {
                                                PriceWithVAT = Math.Round((decimal)row["UnitPrice"] * (1 + ((decimal)VATCode["TaxPercent"] / 100)), FormatRound("U"));
                                                break;
                                            }
                                        }

                                        decimal DiscAmount = Math.Round((decimal)row["Quantity"] * ((decimal)row["UnitPrice"] - (decimal)row["MinusOnPrice"] - (decimal)row["TransFee"]) * ((decimal)row["DiscPercent"] / 100), FormatRound("B"));

                                        row.SetField("DiscAmount", DiscAmount);

                                        decimal FSaleAmount = Math.Round((decimal)row["Quantity"] * ((decimal)row["UnitPrice"] - (decimal)row["MinusOnPrice"] - (decimal)row["TransFee"]) - (decimal)row["DiscAmount"], FormatRound("S"));

                                        row.SetField("FSaleAmount", FSaleAmount);

                                        decimal BSaleAmount = 0;
                                        foreach (var itemTable in table)
                                        {
                                            if (itemTable.IdOld == row["DocumentID"].ToString() && itemTable.Multiply)
                                            {
                                                BSaleAmount = Math.Round((decimal)row["FSaleAmount"] * itemTable.RateExchange, FormatRound("B"));
                                                break;
                                            }
                                            else
                                            {
                                                BSaleAmount = Math.Round((decimal)row["FSaleAmount"] / itemTable.RateExchange, FormatRound("B"));
                                                break;
                                            }
                                        }

                                        row.SetField("BSaleAmount", BSaleAmount);

                                        decimal ExpTaxAmount = Math.Round((decimal)row["BSaleAmount"] * (decimal)row["ExpTaxPercent"] / 100, FormatRound("B"));

                                        row.SetField("ExpTaxAmount", ExpTaxAmount);

                                        decimal ExcTaxAmount = Math.Round(((decimal)row["BSaleAmount"] + (decimal)row["ExpTaxAmount"]) * ((decimal)row["ExcTaxPercent"] / 100), FormatRound("B"));

                                        row.SetField("ExcTaxAmount", ExcTaxAmount);

                                        decimal EnvTaxAmount = Math.Round((decimal)row["Quantity"] * (decimal)row["EnvTaxPercent"] / 100, FormatRound("B"));

                                        row.SetField("EnvTaxAmount", EnvTaxAmount);

                                        decimal VATAmount = 0;
                                        foreach (DataRow VATCode in VATCodeList.Rows)
                                        {
                                            if (!(bool)VATCode["DirectMethod"] && VATCode["VATID"].ToString() == row["VATID"].ToString())
                                            {
                                                switch (VATCode["Formula"].ToString())
                                                {
                                                    case "1":
                                                        VATAmount = Math.Round(((decimal)row["BSaleAmount"] + (decimal)row["ExpTaxAmount"] + (decimal)row["ExcTaxAmount"] + (decimal)row["EnvTaxAmount"]) * ((decimal)VATCode["TaxPercent"] / 100), FormatRound("B"));
                                                        break;
                                                    case "2":
                                                        VATAmount = Math.Round(((decimal)row["BSaleAmount"] + (decimal)row["ExpTaxAmount"] + (decimal)row["ExcTaxAmount"] + (decimal)row["EnvTaxAmount"]) / (1 + (decimal)VATCode["TaxPercent"] / 100) * ((decimal)VATCode["TaxPercent"] / 100), FormatRound("B"));
                                                        break;
                                                    case "3":
                                                        VATAmount = Math.Round(((decimal)row["BSaleAmount"] + (decimal)row["ExpTaxAmount"] + (decimal)row["ExcTaxAmount"] + (decimal)row["EnvTaxAmount"]) * ((decimal)VATCode["TaxPercent"] / 100), FormatRound("B"));
                                                        break;
                                                }
                                                break;
                                            }
                                        }

                                        row.SetField("VATAmount", VATAmount);

                                        decimal SellingAmount = Math.Round((decimal)row["BSaleAmount"] + (decimal)row["ExpTaxAmount"] + (decimal)row["ExcTaxAmount"] + (decimal)row["EnvTaxAmount"] + (decimal)row["VATAmount"], FormatRound("B"));

                                        row.SetField("SellingAmount", SellingAmount);
                                    }
                                }
                            }
                        }
                        MessageBox.Show("Cập nhật thành công");

                    }
                    else
                    {
                        foreach (DataRow row in dataTable[0].Rows)
                        {
                            foreach (var item in itemlist)
                            {
                                if (row["ItemID"].ToString() == item.Id)
                                {
                                    row.SetField("UnitPrice", item.BuyPrice);
                                    if ((decimal)row["PriceWithVAT"] != 0)
                                    {
                                        decimal DiscAmount = Math.Round((decimal)row["Quantity"] * ((decimal)row["UnitPrice"] - (decimal)row["MinusOnPrice"] - (decimal)row["TransFee"]) * ((decimal)row["DiscPercent"] / 100), FormatRound("B"));

                                        row.SetField("DiscAmount", DiscAmount);

                                        decimal FSaleAmount = Math.Round((decimal)row["Quantity"] * ((decimal)row["UnitPrice"] - (decimal)row["MinusOnPrice"] - (decimal)row["TransFee"]) - (decimal)row["DiscAmount"], FormatRound("S"));

                                        row.SetField("FSaleAmount", FSaleAmount);

                                        decimal BSaleAmount = 0;
                                        foreach (var itemTable in table)
                                        {
                                            if (itemTable.IdOld == row["DocumentID"].ToString() && itemTable.Multiply)
                                            {
                                                BSaleAmount = Math.Round((decimal)row["FSaleAmount"] * itemTable.RateExchange, FormatRound("B"));
                                                break;
                                            }
                                            else
                                            {
                                                BSaleAmount = Math.Round((decimal)row["FSaleAmount"] / itemTable.RateExchange, FormatRound("B"));
                                                break;
                                            }
                                        }

                                        row.SetField("BSaleAmount", BSaleAmount);

                                        decimal ExpTaxAmount = Math.Round((decimal)row["BSaleAmount"] * (decimal)row["ExpTaxPercent"] / 100, FormatRound("B"));

                                        row.SetField("ExpTaxAmount", ExpTaxAmount);

                                        decimal ExcTaxAmount = Math.Round(((decimal)row["BSaleAmount"] + (decimal)row["ExpTaxAmount"]) * ((decimal)row["ExcTaxPercent"] / 100), FormatRound("B"));

                                        row.SetField("ExcTaxAmount", ExcTaxAmount);

                                        decimal EnvTaxAmount = Math.Round((decimal)row["Quantity"] * (decimal)row["EnvTaxPercent"] / 100, FormatRound("B"));

                                        row.SetField("EnvTaxAmount", EnvTaxAmount);

                                        decimal VATAmount = 0;
                                        foreach (DataRow VATCode in VATCodeList.Rows)
                                        {
                                            if (!(bool)VATCode["DirectMethod"] && VATCode["VATID"].ToString() == row["VATID"].ToString())
                                            {
                                                switch (VATCode["Formula"].ToString())
                                                {
                                                    case "1":
                                                        VATAmount = Math.Round(((decimal)row["BSaleAmount"] + (decimal)row["ExpTaxAmount"] + (decimal)row["ExcTaxAmount"] + (decimal)row["EnvTaxAmount"]) * ((decimal)VATCode["TaxPercent"] / 100), FormatRound("B"));
                                                        break;
                                                    case "2":
                                                        VATAmount = Math.Round(((decimal)row["BSaleAmount"] + (decimal)row["ExpTaxAmount"] + (decimal)row["ExcTaxAmount"] + (decimal)row["EnvTaxAmount"]) / (1 + (decimal)VATCode["TaxPercent"] / 100) * ((decimal)VATCode["TaxPercent"] / 100), FormatRound("B"));
                                                        break;
                                                    case "3":
                                                        VATAmount = Math.Round(((decimal)row["BSaleAmount"] + (decimal)row["ExpTaxAmount"] + (decimal)row["ExcTaxAmount"] + (decimal)row["EnvTaxAmount"]) * ((decimal)VATCode["TaxPercent"] / 100), FormatRound("B"));
                                                        break;
                                                }
                                                break;
                                            }
                                        }

                                        row.SetField("VATAmount", VATAmount);

                                        decimal SellingAmount = Math.Round((decimal)row["BSaleAmount"] + (decimal)row["ExpTaxAmount"] + (decimal)row["ExcTaxAmount"] + (decimal)row["EnvTaxAmount"] + (decimal)row["VATAmount"], FormatRound("B"));

                                        row.SetField("SellingAmount", SellingAmount);
                                    }
                                    else
                                    {
                                        decimal PriceWithVAT = 0;
                                        foreach (DataRow VATCode in VATCodeList.Rows)
                                        {
                                            if (VATCode["VATID"].ToString() == row["VATID"].ToString())
                                            {
                                                PriceWithVAT = Math.Round((decimal)row["UnitPrice"] * (1 + ((decimal)VATCode["TaxPercent"] / 100)), FormatRound("U"));
                                                break;
                                            }
                                        }

                                        decimal DiscAmount = Math.Round((decimal)row["Quantity"] * ((decimal)row["UnitPrice"] - (decimal)row["MinusOnPrice"] - (decimal)row["TransFee"]) * ((decimal)row["DiscPercent"] / 100), FormatRound("B"));

                                        row.SetField("DiscAmount", DiscAmount);

                                        decimal FSaleAmount = Math.Round((decimal)row["Quantity"] * ((decimal)row["UnitPrice"] - (decimal)row["MinusOnPrice"] - (decimal)row["TransFee"]) - (decimal)row["DiscAmount"], FormatRound("S"));

                                        row.SetField("FSaleAmount", FSaleAmount);

                                        decimal BSaleAmount = 0;
                                        foreach (var itemTable in table)
                                        {
                                            if (itemTable.IdOld == row["DocumentID"].ToString() && itemTable.Multiply)
                                            {
                                                BSaleAmount = Math.Round((decimal)row["FSaleAmount"] * itemTable.RateExchange, FormatRound("B"));
                                                break;
                                            }
                                            else
                                            {
                                                BSaleAmount = Math.Round((decimal)row["FSaleAmount"] / itemTable.RateExchange, FormatRound("B"));
                                                break;
                                            }
                                        }

                                        row.SetField("BSaleAmount", BSaleAmount);

                                        decimal ExpTaxAmount = Math.Round((decimal)row["BSaleAmount"] * (decimal)row["ExpTaxPercent"] / 100, FormatRound("B"));

                                        row.SetField("ExpTaxAmount", ExpTaxAmount);

                                        decimal ExcTaxAmount = Math.Round(((decimal)row["BSaleAmount"] + (decimal)row["ExpTaxAmount"]) * ((decimal)row["ExcTaxPercent"] / 100), FormatRound("B"));

                                        row.SetField("ExcTaxAmount", ExcTaxAmount);

                                        decimal EnvTaxAmount = Math.Round((decimal)row["Quantity"] * (decimal)row["EnvTaxPercent"] / 100, FormatRound("B"));

                                        row.SetField("EnvTaxAmount", EnvTaxAmount);

                                        decimal VATAmount = 0;
                                        foreach (DataRow VATCode in VATCodeList.Rows)
                                        {
                                            if (!(bool)VATCode["DirectMethod"] && VATCode["VATID"].ToString() == row["VATID"].ToString())
                                            {
                                                switch (VATCode["Formula"].ToString())
                                                {
                                                    case "1":
                                                        VATAmount = Math.Round(((decimal)row["BSaleAmount"] + (decimal)row["ExpTaxAmount"] + (decimal)row["ExcTaxAmount"] + (decimal)row["EnvTaxAmount"]) * ((decimal)VATCode["TaxPercent"] / 100), FormatRound("B"));
                                                        break;
                                                    case "2":
                                                        VATAmount = Math.Round(((decimal)row["BSaleAmount"] + (decimal)row["ExpTaxAmount"] + (decimal)row["ExcTaxAmount"] + (decimal)row["EnvTaxAmount"]) / (1 + (decimal)VATCode["TaxPercent"] / 100) * ((decimal)VATCode["TaxPercent"] / 100), FormatRound("B"));
                                                        break;
                                                    case "3":
                                                        VATAmount = Math.Round(((decimal)row["BSaleAmount"] + (decimal)row["ExpTaxAmount"] + (decimal)row["ExcTaxAmount"] + (decimal)row["EnvTaxAmount"]) * ((decimal)VATCode["TaxPercent"] / 100), FormatRound("B"));
                                                        break;
                                                }
                                                break;
                                            }
                                        }

                                        row.SetField("VATAmount", VATAmount);

                                        decimal SellingAmount = Math.Round((decimal)row["BSaleAmount"] + (decimal)row["ExpTaxAmount"] + (decimal)row["ExcTaxAmount"] + (decimal)row["EnvTaxAmount"] + (decimal)row["VATAmount"], FormatRound("B"));

                                        row.SetField("SellingAmount", SellingAmount);
                                    }
                                }
                            }
                        }
                        MessageBox.Show("Cập nhật thành công");

                    }
                }
                else
                {
                    MessageBox.Show("Chức năng này chỉ được dùng cho hóa đơn mua hoặc bán");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: ", ex.Message);
            }

        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                string strDsc = "Data Source=" + ServerName + ";Database=" + Database + ";User Id=" + UserName + ";Password=" + Password + "; pooling=false";

                using (SqlConnection sourceConnection = new SqlConnection(strDsc))
                {
                    sourceConnection.Open();
                    SqlDataAdapter sqlDA, sqldata;

                    //DataTable Master
                    string ListQuery = "Select * from zzzlvimport" + data[0].Table ;
                    sqldata = new SqlDataAdapter(ListQuery, sourceConnection);
                    var dsdata = new DataSet();
                    sqldata.Fill(dsdata);
                    dsdata.Tables[0].TableName = data[0].Table;
                    dataNew = dsdata.Tables[0];


                    //DataTable Detail
                    dataTable = new List<DataTable>();
                    if (chkngaychungtu.Checked)
                    {

                        foreach (var item in detail)
                        {
                            string query = "";
                            query = "Select T2.DocumentDate,T1.* ";
                            query += "From " + "zzzlvimport" + item.DetailName + " T1, " + "zzzlvimport" + data[0].Table + " T2 ";
                            query += " Where " + " T1." + item.ConditionDetail + " = " + " T2." + item.ConditionDetail + " and " + data[0].Condition + " and " + " DocumentDate Between '" + dtpFromDate.Value.ToShortDateString() + "' and '" + dtpToDate.Value.ToShortDateString() + "'";
                            query += " Order by T2.DocumentDate ";
                            sqlDA = new SqlDataAdapter(query, sourceConnection);

                            var ds = new DataSet();
                            sqlDA.Fill(ds);
                            ds.Tables[0].TableName = item.DetailName;
                            dataTable.Add(ds.Tables[0]);
                        }
                    }
                    else if (chklo.Checked)
                    {

                        foreach (var item in detail)
                        {
                            string query = "";
                            query = "Select T2.DocumentDate,T1.* ";
                            query += "From " + "zzzlvimport" + item.DetailName + " T1, " + "zzzlvimport" + data[0].Table + " T2 ";
                            query += " Where " + " T1." + item.ConditionDetail + " = " + " T2." + item.ConditionDetail + " and " + data[0].Condition + " and " + "BatchNo='" + txtLoChungTu.Text+"'";
                            query += " Order by T2.DocumentDate ";
                            sqlDA = new SqlDataAdapter(query, sourceConnection);

                            var ds = new DataSet();
                            sqlDA.Fill(ds);
                            ds.Tables[0].TableName = item.DetailName;
                            dataTable.Add(ds.Tables[0]);
                        }
                    }
                    else if (chkngaychungtu.Checked && chklo.Checked)
                    {
                        foreach (var item in detail)
                        {
                            string query = "";
                            query = "Select T2.DocumentDate,T1.* ";
                            query += "From " + "zzzlvimport" + item.DetailName + " T1, " + "zzzlvimport" + data[0].Table + " T2 ";
                            query += " Where " + " T1." + item.ConditionDetail + " = " + " T2." + item.ConditionDetail + " and " + data[0].Condition + " and " + "BatchNo='" + txtLoChungTu.Text + "' and " + " DocumentDate Between '" + dtpFromDate.Value.ToShortDateString() + "' and '" + dtpToDate.Value.ToShortDateString() + "'";
                            query += " Order by T2.DocumentDate ";
                            sqlDA = new SqlDataAdapter(query, sourceConnection);

                            var ds = new DataSet();
                            sqlDA.Fill(ds);
                            ds.Tables[0].TableName = item.DetailName;
                            dataTable.Add(ds.Tables[0]);
                        }
                    }
                    else
                    {
                        foreach (var item in detail)
                        {
                            string query = "";
                            query = "Select T2.DocumentDate ,T1.* ";
                            query += "From " + "zzzlvimport" + item.DetailName + " T1, " + "zzzlvimport" + data[0].Table + " T2 ";
                            query += " Where " + " T1." + item.ConditionDetail + " = " + " T2." + item.ConditionDetail + " and " +  data[0].Condition;
                            query += " Order by T2.DocumentDate ";
                            sqlDA = new SqlDataAdapter(query, sourceConnection);

                            var ds = new DataSet();
                            sqlDA.Fill(ds);
                            ds.Tables[0].TableName = item.DetailName;
                            dataTable.Add(ds.Tables[0]);
                        }
                    }

                    dataTable.Add(dsdata.Tables[0]);

                    if (dataTable[0].Rows.Count <= 0)
                    {
                        MessageBox.Show("Không có dữ liệu");
                        return;
                    }

                    Dictionary<string, string> Listlanguage = new Dictionary<string, string>();
                    Listlanguage = Loadlanguage();
                    DataGridView gv = new DataGridView();

                    dataGridView1.DataSource = dataTable[0];

                    if (Listlanguage.Any())
                    {
                        foreach (DataGridViewColumn col in dataGridView1.Columns)
                        {
                            string colheader = col.HeaderText;
                            var key = Listlanguage.Keys.FirstOrDefault(k => k == colheader);
                            if (key != null)
                                col.HeaderText = Listlanguage[key];
                        }
                    }


                    lblsodong.Text = dataTable[0].Rows.Count.ToString();

                    dataGridView1.Columns[1].Visible = false;


                    #region test
                    //for (int j = 0; j < lengthDetail; j++)
                    //{
                    //    if (detail[j].ID == data[i].ID)
                    //    {
                    //        sqlDA = new SqlDataAdapter("Select * From " + "zzzlvimport" + detail[j].DetailName, sourceConnection);

                    //        DataTable Tabledetail = new DataTable();
                    //        var dsdetail = new DataSet();
                    //        sqlDA.Fill(dsdetail);

                    //        Tabledetail = dsdetail.Tables[0];

                    //        var results = from tableMaster in dataTable.AsEnumerable()
                    //                      join tableDetail in Tabledetail.AsEnumerable() on tableMaster[0] equals tableDetail[detail[i].ConditionDetail]
                    //                      where ((DateTime)tableMaster["DocumentDate"] >= dtpFromDate.Value && (DateTime)tableMaster["DocumentDate"] <= dtpToDate.Value)
                    //                      select tableDetail;
                    //        results = results.ToList();
                    //        DataTable Details = new DataTable();
                    //        Details = results.CopyToDataTable();

                    //        tabControl1.TabPages.Add(data[0].Name + " Chi Tiết");
                    //        tabControl1.TabPages[j + 1].Controls.Add(new DataGridView()
                    //        {
                    //            Name = "dataGridView_" + detail[j].DetailName,
                    //            Dock = DockStyle.Fill,
                    //            DataSource = Details
                    //        }
                    //        );
                    //    }
                    //}
                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: "+ ex.Message);
            }
        }

        public Dictionary<string, string> Loadlanguage()
        {
            try
            {
                string str = "Data Source=" + SrcServerName + ";Database=" + SrcDatabase + ";User Id=" + SrcUserName + ";Password=" + SrcPassword + "; pooling=false";


                using (SqlConnection sourceConnection = new SqlConnection(str))
                {
                    sourceConnection.Open();
                    SqlDataAdapter sqlDA, sqldata;

                    DataTable dt;

                    string ListQuery = "Select * from SYS_tblCaptions Where FormName=" + "'" + data[0].Language + "'";
                    sqldata = new SqlDataAdapter(ListQuery, sourceConnection);
                    var dsdata = new DataSet();
                    sqldata.Fill(dsdata);
                    int coun = dsdata.Tables[0].Rows.Count;
                    dt = dsdata.Tables[0];
                    string name = "";
                    name = data[0].Table;
                    name = name.Replace("tbl", "0");
                    string[] newName = name.Split(new char[] { '0' });
                    Dictionary<string, string> language = new Dictionary<string, string>();
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["LangID"].ToString() == "vi" && row[3].ToString().IndexOf(newName[1]) > 0)
                        {
                            string controlName = row["ControlName"].ToString();
                            string customCaption = row["CustomCaption"].ToString();
                            language.Add(controlName, customCaption);
                        }

                    }
                    return language;

                    //var results = from tableMaster in dataTable.AsEnumerable()
                    //              join tableDetail in dt.AsEnumerable() on tableMaster[0] equals tableDetail[detail[i].ConditionDetail]
                    //              where ((DateTime)tableMaster["DocumentDate"] >= dtpFromDate.Value && (DateTime)tableMaster["DocumentDate"] <= dtpToDate.Value)
                    //              select tableDetail;
                    //results = results.ToList();
                    //DataTable Details = new DataTable();
                    //Details = results.CopyToDataTable();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void CopyTable(SqlConnection conn, DataTable dt, string tablename, List<string> ColumnNotMap = null)
        {
            var tran = conn.BeginTransaction();
            try
            {
               var a= dt.Rows.Count;
                if(detail.Where(o=>o.DetailName == tablename).Any())
                {
                    if (ColumnNotMap == null) ColumnNotMap = new List<string>();
                    ColumnNotMap.Add("DocumentDate");
                }
                string sqlTrunc = "TRUNCATE TABLE zzzlvimport" + tablename;
                SqlCommand cmd = new SqlCommand(sqlTrunc, conn);
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.KeepIdentity | SqlBulkCopyOptions.KeepNulls, tran))
                {

                    foreach (DataColumn item in dt.Columns)
                    {
                        if(ColumnNotMap==null || !ColumnNotMap.Contains(item.ColumnName))
                            bulkCopy.ColumnMappings.Add(item.ColumnName, item.ColumnName);
                    }
                    bulkCopy.DestinationTableName = "zzzlvimport" + tablename;
                    bulkCopy.WriteToServer(dt);
                    var b = dt.Rows.Count;
                    bulkCopy.Close();
                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            try
            {
                string strDsc = "Data Source=" + ServerName + ";Database=" + Database + ";User Id=" + UserName + ";Password=" + Password + "; pooling=false";

                using (SqlConnection sourceConnection = new SqlConnection(strDsc))
                {
                    sourceConnection.Open();
                    foreach (DataTable data in dataTable)
                    {
                        CopyTable(sourceConnection, data, data.TableName);
                    }
                }
                MessageBox.Show("Cập nhật thành công");
                FormMain frm = new FormMain();
                Hide();
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: "+ ex.Message);
            }


        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
