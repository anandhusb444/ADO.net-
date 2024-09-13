using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace ADO.net_databse_CRUD_Console_Application
{
    internal class Program
    {

        static void Main(string[] args)
        {

            try
            {
                string connectionStr = "data source=HP-HIKE-444\\SQLEXPRESS; data base=ado_DB; intergrated security=SSPI";

                using(SqlConnection con = new SqlConnection(connectionStr))
                {
                    con.Open();

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"there is an error : {ex.Message}");
            }









        }
    }
}
