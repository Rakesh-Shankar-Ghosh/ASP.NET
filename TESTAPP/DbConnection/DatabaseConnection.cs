using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace TESTAPP.DbConnection
{
    public class DatabaseConnection
    {
        public static string connString = "Data Source=DESKTOP-ECGTLKK\\SQLEXPRESS;Initial Catalog=TestDB;User ID=DESKTOP-ECGTLKK\\Dell;Encrypt=True;Trusted_Connection=True; TrustServerCertificate=True;";

        public static SqlConnection con = new  (connString);

        public void TestConnection()
        {
            try
            {
                con.Open();
                Console.WriteLine("Connected Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SQL Server Exception: {ex.Message}");
            }
            finally
            {
                // Make sure to always close the connection in the finally block
                if (con != null && con.State == ConnectionState.Open)
                {
                    Console.WriteLine("Connection is Running.....");
                }
            }
        }


//  
    }
}
