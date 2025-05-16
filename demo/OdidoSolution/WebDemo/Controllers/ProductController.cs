using EntityFrameworkDemo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebDemo.Controllers;

[Route("api/products")] // decorator annotation attribute
public class ProductController : ControllerBase
{
    private readonly ProductContext _context;

    public ProductController(ProductContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<ProductEntity>> GetAll()
    {
        return await _context.Products.ToArrayAsync();
    }

    [HttpGet("{id:int}")]
    //[Consumes()]
    //[Produces()]
    public async Task<ActionResult<ProductEntity>> Get(int id)
    {
        // First  not found => exception   
        // FirstOrDefault  not found => null
        // Single  not found => exception   throws if multiple items match
        // SingleOrDefault  not found => null   throws if multiple items match

        var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == id);
        return product is null ? NotFound($"Product with id {id} does not exist.") : product;
    }

    [HttpPost]
    public async Task<ActionResult<ProductEntity>> Post([FromBody] ProductEntity newProduct)
    {
        _context.Products.Add(newProduct);
        await _context.SaveChangesAsync();
        return Created("", newProduct); // Id has been set
    }
}
