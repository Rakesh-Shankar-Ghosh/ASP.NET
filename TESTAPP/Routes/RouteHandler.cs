
namespace TESTAPP.Routes
{
    public class ProductRouteHandler

    {
              
        public static void StudentRoutes(IEndpointRouteBuilder endpoints)
        {


            endpoints.MapControllerRoute(
                 name: "UpdateStudentById",
                 pattern: "{controller=Student}/{action=UpdateStudentById}/{id}"
                 );


            endpoints.MapControllerRoute(
                 name: "DeleteStudentById",
                 pattern: "{controller=Student}/{action=DeleteStudentById}/{id}"
                 );


            endpoints.MapControllerRoute(
                 name: "GetStudentById",
                 pattern: "{controller=Student}/{action=GetStudentById}/{id}"
                 );

            endpoints.MapControllerRoute(
                name: "GetStudents",
                pattern: "{controller=Student}/{action=GetStudents}/{customId?}"
            );

            endpoints.MapControllerRoute(
                name: "AddStudent",
                pattern: "{controller=Student}/{action=AddStudent}/{customId?}"
            );


            endpoints.MapControllerRoute(
               name: "TestStudent",
               pattern: "{controller=Student}/{action=TestMethod}/{customId?}"
           );
        }

        public static void ProductRoutes(IEndpointRouteBuilder endpoints)
        {
            
            // Route for a custom action of the Product controller
            endpoints.MapControllerRoute(
                name: "test",
                pattern: "{controller=Product}/{action=CreateProduct}/{customId?}"
            );

            endpoints.MapControllerRoute(
              name: "test",
              pattern: "{controller=Product}/{action=InsertProduct}/{customId?}"
          );

           



            // Add more route configurations...
        }

        public static void ConfigureRoutes(IEndpointRouteBuilder endpoints)
        {
            // Route for the default action of the Product controller
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Product}/{action=GetProduct}/{id?}"
            );
        }
    }
}
