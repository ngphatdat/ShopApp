using WebApplication5.Models;
using WebApplication5.Repositories;
using WebApplication5.Response;
using WebApplication5.ViewModels;

namespace WebApplication5.Services;

public class ProductService:IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IProductImageRepository _productImageRepository;
    public ProductService(IProductRepository productRepository, IProductImageRepository productImageRepository)
    {
        _productRepository = productRepository;
        _productImageRepository = productImageRepository;
    }
    public Task<Product?> GetProductById(int id)
    {
        return _productRepository.GetProductById(id);
    }

    public async Task<ProductListViewModel?> GetProducts(string keyword, int? categoryId, string? sortBy, int? page, int? limit)
    {
        return await _productRepository.GetProducts(keyword, categoryId, sortBy, page, limit);
    }
    public Task AddProduct(ProductViewModel productViewModel)
    {
        return _productRepository.AddProduct(productViewModel);
    }

    public Task UpdateProduct(ProductViewModel productViewModel)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProduct(int id)
    {
        _productImageRepository.DeleteProductImageAsync(id);
        return  _productRepository.DeleteProduct(id);
    }
}