using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.net_databse_CRUD_Console_Application
{
    public class DeleteStud
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connectionStr"].ConnectionString;

        public void Delete(int Id)
        {
            using(SqlConnection con =  new SqlConnection(connectionString))
            {
                con.Open();

                string deleteQ = "delete Students where stud_id = @id";

                SqlCommand cmd = new SqlCommand(deleteQ, con);
                cmd.Parameters.AddWithValue("@id", Id);

                cmd.ExecuteNonQuery();

            }
        }
    }
}
