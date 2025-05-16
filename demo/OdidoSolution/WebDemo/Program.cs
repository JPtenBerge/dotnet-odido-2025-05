using EntityFrameworkDemo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 3 ways to make your service known/injectable

            // lifetime

            // - AddTransient() // every time you request this dependency, a new instance is created
            //   - no side effects
            //   - using more memory
            // - AddScoped() // per request: 0.5s, 2s, 3s, pretty short
            // - AddSingleton() // there is 1 instance of your service, never more. reading in config files.
            //   - shared across all requests, shared among all users


            builder.Services.AddDbContext<ProductContext>(options =>
            {
                options.UseSqlite(@"Data Source=C:\repos\course-instances\dotnet-odido-2025-05\demo\OdidoSolution\EntityFrameworkDemo\mydb.db");
            });

            builder.Services.AddScoped<IMagicService, MagicService>();
            //builder.Services.AddScoped<IMagicService, MagicianService>();

            // whenever a piece of code asks for an IMagicService, give that piece of code an instance of MagicService
            // ASP.NET Core will do the new MagicService() for you.
            // - that created instance will be kept somewhere in a list of long-living dependencies


            // shouldn't new()

            // dependency injection
            // global settings
            // big building blocks

            var app = builder.Build();

            // what needs to happen for every request/responses coming in/out
            app.UseHttpsRedirection();
            
             

            app.MapGet("/", ([FromServices] IMagicService magicService) => 
                $"Hello World! You are visitor #{magicService.GetMagicNumber()}");

            app.MapGet("/efcore", ([FromServices] ProductContext context) =>
                $"There are {context.Products.Count()} products in the database");

            //app.MapPut("/qq", ([FromServices] IMagicService magicService) =>
            //    $"Hello World! You are visitor #{++counter} and the magic number is {magicService.GetMagicNumber()}");


            //app.MapPost("/", ([FromServices] IMagicService magicService) =>
            //    $"Hello World! You are visitor #{++counter} and the magic number is {magicService.GetMagicNumber()}");


            app.Run();
        }
    }
}
