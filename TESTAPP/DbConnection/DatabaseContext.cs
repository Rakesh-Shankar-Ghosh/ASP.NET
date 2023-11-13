using Microsoft.EntityFrameworkCore;
using TESTAPP.DbConnection;
using TESTAPP.Models;

namespace TESTAPP.DbConnection
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("Data Source=DESKTOP-ECGTLKK\\SQLEXPRESS;Initial Catalog=TestDB;User ID=DESKTOP-ECGTLKK\\Dell;Encrypt=True;Trusted_Connection=True;TrustServerCertificate=True;");
           
        }

        public static void TestConnection(DatabaseContext dbContext)
        {
            {
                try
                {
                    dbContext.Database.OpenConnection();
                    Console.WriteLine("Database connection successful!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to connect to the database: {ex.Message}");
                }
            }
            
}


    }
}


