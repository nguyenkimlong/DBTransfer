using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TestFormDB
{
    public class GetStrConnect
    {
        public static string GetStrSrc()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\configSrc.xml");

            string server = doc.GetElementsByTagName("SrcServerName").Item(0).InnerText;
            string username = doc.GetElementsByTagName("SrcUserName").Item(0).InnerText;
            string pass = doc.GetElementsByTagName("SrcPassword").Item(0).InnerText;
            string database = doc.GetElementsByTagName("SrcDatabase").Item(0).InnerText;

            // Open connection to the database
            string conString = "Data Source=" + server + ";Database=" + database + ";User Id=" + username + ";Password=" + pass + "; pooling=false";

            return conString;
        }
        public static string GetStrDsc()
        {
            XmlDocument dataDsc = new XmlDocument();
            dataDsc.Load(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\configDsc.xml");
            string ServerName = dataDsc.GetElementsByTagName("ServerName").Item(0).InnerText;
            string UserName = dataDsc.GetElementsByTagName("UserName").Item(0).InnerText;
            string Password = dataDsc.GetElementsByTagName("Password").Item(0).InnerText;
            string Database = dataDsc.GetElementsByTagName("Database").Item(0).InnerText;

        
            string strDsc = "Data Source=" + ServerName + ";Database=" + Database + ";User Id=" + UserName + ";Password=" + Password + "; pooling=false";

            return strDsc;
        }
    }
}
