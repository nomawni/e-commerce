using System.Collections;
using Products.Models;

namespace Prducts.IRepository;

public interface IProductsRepo
{

    bool saveChanges();

    IEnumerable<Product> GetAllProducts();
    Product GetProductById(int Id);
    Product CreateProdudct(Product product);

}