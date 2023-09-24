using Prducts.Db;
using Prducts.IRepository;
using Products.Models;

namespace Products.Repository;

public class ProductsRepo : IProductsRepo
{
    private readonly ProductDbContext _context;

    public ProductsRepo(ProductDbContext context)
    {
        _context = context;
    }
    public Product CreateProdudct(Product product)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }
        var newProduct = _context.Products.Add(product);
        return newProduct.Entity;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _context.Products.ToList();
    }

    public Product GetProductById(int Id)
    {
        return _context.Products.FirstOrDefault(p => p.Id == Id);
    }

    public bool saveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }
}