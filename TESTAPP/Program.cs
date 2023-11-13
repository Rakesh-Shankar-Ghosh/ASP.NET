using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TESTAPP.DbConnection;
using TESTAPP.Middlewares;
using TESTAPP.Routes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var provider = builder.Services.BuildServiceProvider();
var configure = provider.GetRequiredService< IConfiguration > ();

builder.Services.AddCors(option =>
{
    var frontendURL = configure.GetValue<string>("frontend_url");
    option.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader();
    });

});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseCors();
app.UseAuthorization();


app.UseMiddleware<StudentMiddleware>();


//check routing
app.UseEndpoints(endpoints =>
{
    
    ProductRouteHandler.ConfigureRoutes(endpoints);
    ProductRouteHandler.ProductRoutes(endpoints);
    ProductRouteHandler.StudentRoutes(endpoints);
    
});


//check db connection
var _dbContext = new DatabaseContext();
DatabaseContext.TestConnection(_dbContext);


app.Run();

