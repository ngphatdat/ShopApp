using WebApplication5.Models;

namespace WebApplication5.Repositories;

public interface IProductImageRepository
{
    Task AddProductImageAsync(string url, int productId);
    Task<string> GetProductImageAsync(int productId);
    Task UpdateProductImageAsync(ProductImage productImage);
    Task DeleteProductImageAsync(int productId);
}