using WebApplication5.Models;
using WebApplication5.ViewModels;

namespace WebApplication5.Repositories;

public interface IProductRepository
{
    Task<Product?> GetProductById(int id);  
    Task<ProductListViewModel?> GetProducts(string keyword, int? categoryId, string? sortBy, int? page, int? limit );
    Task AddProduct(ProductViewModel productViewModel);
    Task UpdateProduct(ProductViewModel productViewModel );
    Task DeleteProduct(int id);
}