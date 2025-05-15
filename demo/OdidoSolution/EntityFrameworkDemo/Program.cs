using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            //Console.WriteLine(Environment.CurrentDirectory);

            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);

            Console.WriteLine(typeof(Program).Assembly.Location);

            var options = new DbContextOptionsBuilder().UseSqlite(@"Data Source=C:\repos\course-instances\dotnet-odido-2025-05\demo\OdidoSolution\EntityFrameworkDemo\mydb.db").Options;
            var context = new ProductContext(options);
            context.Database.EnsureCreated(); // create the database if it doesn't exist yet - migrations

            //context.Products.Add(new ProductEntity
            //{
            //    Description = "Tea glass",
            //    Price = 4.99d
            //});
            //context.Products.Add(new ProductEntity
            //{
            //    Description = "Fancy keyboard",
            //    Price = 110d

            //});
            //context.Products.Add(new ProductEntity
            //{
            //    Description = "Phone",
            //    Price = 821d
            //});
            //// change tracker
            //context.SaveChanges(); // all changes (add/update/delete) will be written to database. queries get executed.


            // LINQ: Language INtegrated Query
            // .Single()
            // .First()
            // .Where()
            // .Count()
            // .Max()
            // .Min()
            // .Average()
            // .Any()  if (collection.Count() == 0)
            // .Select() - map A to B

            foreach (var product in await context.Products.Where(x => x.Price < 10).ToArrayAsync())
            {
                Console.WriteLine($"Product {product.Description} costs EUR {product.Price}");
            }

            var fancyKeyboard = await context.Products.SingleAsync(x => x.Id == 2);
            ////fancyKeyboard.Description = "Less fancy keyboard";

            //context.Products.Remove(fancyKeyboard);
            await context.SaveChangesAsync(); // WAITING
            // ============================

            var repo = new ProductRepository(context);
            var products = await repo.GetAll();


            ////context.Database.ExecuteSqlRaw();


            //foreach (var product in context.Products)
            //{
            //    Console.WriteLine($"Product {product.Description} costs EUR {product.Price}");
            //}

        }
    }
}
