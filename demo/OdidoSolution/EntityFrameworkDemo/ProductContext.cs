using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    public class ProductContext : DbContext // database
    {
        public DbSet<ProductEntity> Products { get; set; } // table  IEnumerable lazy

        public ProductContext(DbContextOptions options) : base(options) // store configuration of how to connect
        {
            
        }
    }
}
