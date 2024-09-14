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
        static string conStr = ConfigurationManager.ConnectionStrings["connectionStr"].ConnectionString;

        static void Main(string[] args)
        {

            Program pro = new Program();
            //pro.read();

            var userWith_1 = new byId();

            userWith_1.SelectById(1);

            var inserStudent = new AddStudent();
            //inserStudent.insertData(5, "koko", 33);

            //pro.read();

            var updateVal = new updateStu();
            //updateVal.update(1, "anandhu sb");

            //pro.read();

            var delStu = new DeleteStud();
            delStu.deleteStuById(5);
            

            pro.read();




        }
        public void read()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                string selectQuery = "select * from Students";

                SqlCommand cmd = new SqlCommand(selectQuery, con);

                SqlDataReader reder = cmd.ExecuteReader();

                while (reder.Read())
                {
                    int user_id = reder.GetInt32(0);
                    String user_name = reder.GetString(1);
                    int user_age = reder.GetInt32(2);

                    Console.WriteLine($"{user_id} , {user_name}, {user_age}");
                }
            }

        }

        public class byId
        { 
            public void SelectById(int Id)
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    
                    string selectByIdQuery = "select stud_name from Students where stud_id = @id";

                    SqlCommand conId = new SqlCommand(selectByIdQuery, con);

                    conId.Parameters.AddWithValue("@id", Id);

                    SqlDataReader reder = conId.ExecuteReader();

                    while (reder.Read())
                    {
                        Console.WriteLine(reder["stud_name"]);
                    }



                }
            }
        }
        public class AddStudent
        {
            public void insertData(int id,string name, int age)
            {
                using(SqlConnection conInsert = new SqlConnection(conStr))
                {
                    conInsert.Open();

                    string insertQuery = "insert into Students (stud_name, stud_age) values (@stud_name,@stud_age)";

                    SqlCommand cmd = new SqlCommand(insertQuery, conInsert);
                    cmd.Parameters.AddWithValue("@stud_name", name);
                    cmd.Parameters.AddWithValue("@stud_age", age);

                    int result = cmd.ExecuteNonQuery();

                    Console.WriteLine(result > 0 ? "data inserted succesfuly:" : "data is not inserted");


                }
            }
        }

        public class updateStu
        {
            public void update(int id, string name)
            {
                using(SqlConnection conUp = new SqlConnection(conStr))
                {
                    conUp.Open();

                    string updateQuery = "update Students set stud_name = @Name where stud_id = @id";

                    SqlCommand cmd = new SqlCommand(updateQuery, conUp);

                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@id", id);

                    int result = cmd.ExecuteNonQuery();

                    Console.WriteLine(result > 0 ? "update done successfuly..." : "some error with the updates");

                }
            }
        }

        public class DeleteStud
        {
            public void deleteStuById(int Id)
            {
                using (SqlConnection ConDel = new SqlConnection(conStr))
                {
                    ConDel.Open();

                    string deleteQuery = "delete from Students where stud_id = @id";

                    SqlCommand cmd = new SqlCommand(deleteQuery, ConDel);

                    cmd.Parameters.AddWithValue("@id", Id);

                    int result = cmd.ExecuteNonQuery();

                    Console.WriteLine(result > 0 ? "delete student done success" : "there is a error" );

                }
            }

        }

    }
}
