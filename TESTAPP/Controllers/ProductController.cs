using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using TESTAPP.DbConnection;

namespace TESTAPP.Controllers
{
    public class ProductController : Controller
    {
        public bool CheckTableExists(SqlConnection connection)
        {
            try
            {
                    connection.Open();
                    string query = "SELECT 1 FROM TestDB.INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Product';";

                    using (SqlCommand command = new (query, connection))
                    {
                        var result = command.ExecuteScalar();
                        return result != null && result != DBNull.Value;
                    }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking table existence: {ex.Message}");
                return false;
            }
        }

        public void CreateTable()
        {
            SqlConnection con = DatabaseConnection.con;
            
            string sqlQuery = "CREATE TABLE Product (Id INT IDENTITY(1,1) NOT NULL, Name VARCHAR(50) NOT NULL, Price INT NOT NULL, Availability BIT NOT NULL);";

            using (SqlCommand command = new (sqlQuery, con))
            {
                command.ExecuteNonQuery();
            }
        }

        //[HttpPost]
        //public IActionResult InsertProduct()
        //{
        //    CreateTable();
        //    return null;
        //}


        public int product = 50;

        [HttpGet]
        public IActionResult GetProduct()
        {
            try
            {   
                if (product == 50)
                {
                    return StatusCode(200, new
                    {
                        success = true,
                        message = "Single Product Fetched",
                        product
                    });
                }
                else
                {
                    return NotFound(new {
                        success = false,
                        message = "Fatched Failed !!",
                        statusCode = 404,
                        product
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex); // Logging the error (you can customize this part based on your logging strategy).
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error while getting single product",
                    error = ex.Message
                });
            }
        }

        [HttpGet]
        public IActionResult CreateProduct() 
        {
            try
            {
                if (product == 50)
               {
                    return StatusCode(200, new
                    {
                        success = true,
                        message = "FROM PRODUCT ROUTE",
                        product
                    });
                }
                else
                {
                    return NotFound(new
                    {
                        success = false,
                        message = "Fatched Failed !!",
                        statusCode = 404,
                        product
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex); // Logging the error (you can customize this part based on your logging strategy).
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error while getting single product",
                    error = ex.Message
                });
            }
        }

    }
}
