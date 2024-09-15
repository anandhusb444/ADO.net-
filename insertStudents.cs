using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ADO.net_databse_CRUD_Console_Application
{
    public class insertStudents
    {
        public void InsertInto(string Name, int Age)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connectionStr"].ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string Insert_stud = "insert into Students (stud_name, stud_age) values (@stud_name,@stud_age)";

                    SqlCommand cmd = new SqlCommand(Insert_stud, con);
                    cmd.Parameters.AddWithValue("@stud_name", Name);
                    cmd.Parameters.AddWithValue("@stud_age", Age);

                    int result = cmd.ExecuteNonQuery();

                    Console.WriteLine(result > 0 ? "inserting done" : "inserting failed");



                
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"There is Some issue {ex.Message}");
            }
        }
    }
}
