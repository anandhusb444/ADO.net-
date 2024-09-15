using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.net_databse_CRUD_Console_Application
{
    public class UpdateStud
    {
        string connectingString = ConfigurationManager.ConnectionStrings["connectionStr"].ConnectionString;

       public void Update(int Id,string Name, int Age)
        {
            using (SqlConnection con = new SqlConnection(connectingString))
            {
                con.Open();

                string updateQuery = "update Students set stud_name = @Name , stud_age = @Age where stud_id = @id";

                SqlCommand cmd = new SqlCommand(updateQuery, con);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Age", Age);
                cmd.Parameters.AddWithValue("@id", Id);

                int result = cmd.ExecuteNonQuery();
                //Console.WriteLine(result > 0 ? "update done" : "update have some issue");
            }
        }
    }
}
