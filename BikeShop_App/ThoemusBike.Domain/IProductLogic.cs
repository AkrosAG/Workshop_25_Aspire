using ThoemusBike.Core;
using ThoemusBike.Data.Entities;

namespace ThoemusBike.Domain;

public interface IProductLogic 
{
    Task<IEnumerable<Product>> GetProductsForCategoryAsync(string category);
    Task<Product?> GetProductByIdAsync(int id);
    Task<ProductModel> CreateProductAsync(NewProductModel newProduct);
}