using WebApplication5.Models;
using WebApplication5.Repositories;

namespace WebApplication5.Services;

public class ProductImageService:IProductImageService
{
    private readonly IProductImageRepository _productImageRepository;
    public ProductImageService(IProductImageRepository productImageRepository)
    {
        _productImageRepository = productImageRepository;
    }

    public Task AddProductImageAsync(string url, int productId)
    {
        return _productImageRepository.AddProductImageAsync(url, productId);
    }

    public Task<string> GetProductImageAsync(int productId)
    {
        return _productImageRepository.GetProductImageAsync(productId);
    }
}