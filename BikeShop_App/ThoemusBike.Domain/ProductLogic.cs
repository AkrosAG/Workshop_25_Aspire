using AutoMapper;
using ThoemusBike.Core;
using ThoemusBike.Data;
using ThoemusBike.Data.Entities;
using Microsoft.Extensions.Logging;

namespace ThoemusBike.Domain;

public class ProductLogic(ILogger<ProductLogic> logger, IThoemusBikeRepository repo,
    IMapper mapper) : IProductLogic
{
    public async Task<IEnumerable<Product>> GetProductsForCategoryAsync(string category)
    {               
        logger.LogInformation("Getting products in logic for {category}", category);
        return await repo.GetProductsAsync(category);
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await repo.GetProductByIdAsync(id);
    }        

    public async Task<ProductModel> CreateProductAsync(NewProductModel newProduct)
    {       
        var productToCreate = mapper.Map<Product>(newProduct);
        var createdProduct = await repo.CreateProductAsync(productToCreate);
        return mapper.Map<ProductModel>(createdProduct);
    }
}