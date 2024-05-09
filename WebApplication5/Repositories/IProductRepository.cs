using WebApplication5.Models;
using WebApplication5.ViewModels;

namespace WebApplication5.Repositories;

public interface IProductRepository
{
    Task<Product?> GetProductById(int id);  
    Task<IEnumerable<ProductViewModel?>> GetProducts(string keyword, string? sortBy, int? page, int? limit );
    
    Task AddProduct(ProductViewModel productViewModel);
    Task UpdateProduct(ProductViewModel productViewModel );
    Task DeleteProduct(int id);
}