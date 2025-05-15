using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    class ProductRepository
    {
        private readonly ProductContext _context;
        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductEntity>> GetAll()
        {
            return await _context.Products.ToArrayAsync(); // this will not iterate through your data
        }
    }
}
