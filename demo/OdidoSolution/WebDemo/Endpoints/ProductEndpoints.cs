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
            group.MapGet("/{id:int}", Get);
            group.MapPost("/", Post);
        }

        public static async Task<IEnumerable<ProductEntity>> GetAll(ProductContext context)
        {
            return await context.Products.ToArrayAsync();
        }

        public static async Task<Results<NotFound<string>, Ok<ProductEntity>>> Get(int id, ProductContext context)
        {
            var product = await context.Products.SingleOrDefaultAsync(x => x.Id == id);
            return product is null ? TypedResults.NotFound($"Product with id {id} does not exist.") : TypedResults.Ok(product);
        }

        public static async Task<Created<ProductEntity>> Post(ProductEntity newProduct, ProductContext context)
        {
            context.Products.Add(newProduct);
            await context.SaveChangesAsync();
            return TypedResults.Created("", newProduct); // Id has been set
        }

        public static async Task<Results<NotFound<string>, UnprocessableEntity<string>, Ok<ProductEntity>>> Put(int id, ProductContext context)
        {
            return TypedResults.NotFound($"Product with id {id} does not exist");
            //return TypedResults.Ok(await context.Products.SingleAsync(x => x.Id == id));
        }
    }
}
