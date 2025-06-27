using ThoemusBike.Data.Entities;

namespace ThoemusBike.Data;

public interface IThoemusBikeRepository
{
    Task<List<Product>> GetProductsAsync(string category);
    Task<Product?> GetProductByIdAsync(int id);        
    Task<bool> IsProductNameUniqueAsync(string name);
    Task<Product> CreateProductAsync(Product product);
}
