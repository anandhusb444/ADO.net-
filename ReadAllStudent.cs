using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.net_databse_CRUD_Console_Application
{
    public class ReadAllStudent
    {
        public void ReadStud()
        {
            string connectingString = ConfigurationManager.ConnectionStrings["connectionStr"].ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(connectingString))
                {
                    con.Open();
                    
                    string allDetiales = "select * from Students";

                    SqlCommand cmd = new SqlCommand(allDetiales, con);
                    SqlDataReader reder = cmd.ExecuteReader();
                    while (reder.Read())
                    {
                        Console.WriteLine(reder["stud_id"] + " " + reder["stud_name"] + " " + reder["stud_age"]);
                    }
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine($"There is a error in the conncetion : {ex.Message}");
            }
           
        }
    }
}
