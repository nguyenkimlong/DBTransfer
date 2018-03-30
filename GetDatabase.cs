using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFormDB
{
    public class GetDatabase
    {
        public static List<string> GetDatabaseList(string server ,string database,string username,string password)
        {
            try
            {
                List<string> list = new List<string>();

                // Open connection to the database
                string conString = "Data Source=" + server + ";Database=" + database + ";User Id=" + username + ";Password=" + password + "; pooling=false";

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
    }
}
