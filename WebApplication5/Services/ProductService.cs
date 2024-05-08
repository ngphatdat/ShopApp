using WebApplication5.Models;
using WebApplication5.Repositories;
using WebApplication5.ViewModels;

namespace WebApplication5.Services;

public class ProductService:IProductService
{
    private readonly IProductRepository _productRepository;
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public Task<Product?> GetProductById(int id)
    {
        return _productRepository.GetProductById(id);
    }

    public Task<IEnumerable<Product?>> GetAllProducts()
    {
        return _productRepository.GetAllProducts();
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
        throw new NotImplementedException();
    }
}