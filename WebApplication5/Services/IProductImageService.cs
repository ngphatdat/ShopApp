using WebApplication5.Models;
using WebApplication5.Repositories;

namespace WebApplication5.Services;

public interface IProductImageService
{
    Task AddProductImageAsync(string url, int productId);
    Task<string> GetProductImageAsync(int productId);
    
}