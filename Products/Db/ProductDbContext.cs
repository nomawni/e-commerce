using Microsoft.EntityFrameworkCore;
using Products.Models;

namespace Prducts.Db;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options)
    : base(options)
    {

    }

    public DbSet<Product> Products { get; set; }
}