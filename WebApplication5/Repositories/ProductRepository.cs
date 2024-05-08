using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;
using WebApplication5.ViewModels;

namespace WebApplication5.Repositories;

public class ProductRepository:IProductRepository
{
    private readonly DotNetCoreContext _context;
    public ProductRepository(DotNetCoreContext context)
    {
        _context = context;
    }
    public async Task<Product?> GetProductById(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            throw new Exception("Product not found");
        }

        return product;
    }

    public async Task<IEnumerable<Product?>> GetAllProducts()
    {
        var products = await _context.Products.ToListAsync();
        if (products == null)
        {
            throw new Exception("No products found");
        }

        return products;

    }

    public Task AddProduct(ProductViewModel productViewModel)
    {
        try
        {
            _context.Products.Add(new Product
            {
                Name = productViewModel.Name,
                Price = productViewModel.Price,
                Description = productViewModel.Description,
                CategoryId = productViewModel.CategoryId,
                CreatedAt = DateTime.Today,
                Thumbnail = productViewModel.Thumbnail,
                UpdatedAt = null,
            });
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception("Product not added");
        }
        return Task.CompletedTask;
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