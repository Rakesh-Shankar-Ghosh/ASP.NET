namespace TESTAPP.Middlewares
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Threading.Tasks;

    public class StudentMiddleware
    {
        private readonly RequestDelegate _next;
        public readonly int data = 60;

        public StudentMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/Student/TestMethod") && data == 60)
            {
                // Code to execute before the TestMethod action.
                Console.WriteLine("Middleware called");
               
                await _next(context);
            }
            else if(!context.Request.Path.StartsWithSegments("/Student/TestMethod"))
            {
                await _next(context);
            }
            else
            {
                // Code to execute for other requests.
                Console.WriteLine("Middleware else called");
                await context.Response.WriteAsync(@"{""success"": false, ""message"": ""Error while updating student""}");
            }
        }
    }
}
