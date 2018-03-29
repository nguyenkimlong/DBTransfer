using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestFormDB
{
    public class LogWriter
    {
        private string m_exePath = string.Empty;
        public LogWriter(string logMessage, string text)
        {
            switch (text)
            {
                case "import":
                    LogWriteImport(logMessage);
                    break;
                case "export":
                    LogWriteExport(logMessage);
                    break;
                default:
                    LogWrite(logMessage);
                    break;
            }
        }
        public void LogWrite(string logMessage)
        {
            m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                using (StreamWriter w = File.AppendText(m_exePath + "\\" + "log.txt"))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void LogWriteImport(string logMessage)
        {
            m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                using (StreamWriter w = File.AppendText(m_exePath + "\\" + "logImport.txt"))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void LogWriteExport(string logMessage)
        {
            m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                using (StreamWriter w = File.AppendText(m_exePath + "\\" + "logExport.txt"))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                logMessage = logMessage.Replace("\n", "\r\n");
                txtWriter.Write("\r\n");
                txtWriter.WriteLine();
                //txtWriter.WriteLine("----------------{0} {1}-------------------", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());             
                txtWriter.Write(logMessage);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
