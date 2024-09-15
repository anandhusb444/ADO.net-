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

            var I = new insertStudents();
            //I.InsertInto("abdulla", 21);

            var U = new UpdateStud();
            //.Update(9, "abdulla yo", 23);

            var D = new DeleteStud();
            D.Delete(14);
            

            var R = new ReadAllStudent();
            R.ReadStud();

            
            




        }


    }
}
