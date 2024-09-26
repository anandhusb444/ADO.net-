using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;


namespace ADO.net_databse_CRUD_Console_Application
{
    internal class Program
    {
        //static string conStr = ConfigurationManager.ConnectionStrings["connectionStr"].ConnectionString;

        static void Main(string[] args)


        {

            //var I = new insertStudents();
            ////I.InsertInto("abdulla", 21);

            //var U = new UpdateStud();
            ////.Update(9, "abdulla yo", 23);

            //var D = new DeleteStud();
            //D.Delete(14);


            //var R = new ReadAllStudent();
            //R.ReadStud();

            string connectingString = ConfigurationManager.ConnectionStrings["connectionStr"].ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(connectingString))
                {
                    con.Open();
                    //Console.WriteLine("connection Done");

                    SqlCommand cmd = new SqlCommand("select max (player_age) from SportsTeam", con);

                    object result = cmd.ExecuteScalar();

                    int maxAge = Convert.ToInt32(result);
                    Console.WriteLine($"the max Values is : {maxAge}");

                    SqlCommand cmd2 = new SqlCommand("select count(player_name) from SportsTeam where player_age = '21'", con);

                    object countRes = cmd2.ExecuteScalar();

                    int countAge = Convert.ToInt32(countRes);

                    Console.WriteLine($"this the count of the players with same name :{countAge}");





                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There is a error in the connection : {ex.Message}");
            }






        }


    }
}
