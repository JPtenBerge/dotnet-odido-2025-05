using EntityFrameworkDemo;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace WebDemo.Endpoints
{
    public class ProductEndpoints
    {
        public static void MapProductEndpoints(IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("api/min-products");

            group.MapGet("/", GetAll);
            group.MapGet("/{id:int}", GetAll);
            group.MapPost("/", GetAll);
        }

        public static async Task<IEnumerable<ProductEntity>> GetAll(ProductContext context)
        {
            return await context.Products.ToArrayAsync();
        }

        public static async Task<Results<NotFound<string>, UnprocessableEntity<string>, Ok<ProductEntity>>> Put(int id, ProductContext context)
        {
            return TypedResults.NotFound($"Product with id {id} does not exist");
            //return TypedResults.Ok(await context.Products.SingleAsync(x => x.Id == id));
        }
    }
}
