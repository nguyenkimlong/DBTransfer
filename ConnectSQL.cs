using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFormDB
{
    public static class ConnectSQL
    {
        public static bool CheckConnect(string str)
        {
            try
            {
                using (SqlConnection conn=new SqlConnection(str))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
