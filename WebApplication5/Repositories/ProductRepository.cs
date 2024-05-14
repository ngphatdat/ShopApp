using Microsoft.AspNetCore.Mvc.Filters;
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

    public async Task<ProductListViewModel?> GetProducts(string? keyword, int? categoryId  , string? sortBy, int? page, int? limit)
    {   
        var products = _context.Products.AsQueryable();
        
        if (categoryId != 0)
        {
            products = products.Where(p => p.CategoryId == categoryId);
        }
        if (!string.IsNullOrEmpty(keyword))
        {
            products = products.Where(p => p.Name.Contains(keyword));
        }
        products = products.OrderBy(p => p.Id);
        if(!string.IsNullOrEmpty(sortBy))
        {
            switch (sortBy)
            {
                case "name_desc":
                    products = products.OrderByDescending(p => p.Name);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(p => p.Price);
                    break;
                case "price_asc":
                    products = products.OrderBy(p => p.Price);
                    break;
                case "createdAt":
                    products = products.OrderBy(p => p.CreatedAt);
                    break;
                case "updatedAt":
                    products = products.OrderBy(p => p.UpdatedAt);
                    break;
                default:
                    break;
            }
        }
        
        var productsPage=PaginatedList<Product>.Create(products, page ?? 1, limit ?? 10);
        var productViewList =   productsPage.Select(p => new ProductViewModel
        {   Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Description = p.Description,
            category_id = p.CategoryId,
            Thumbnail = p.Thumbnail
        }); 
          
          
          ProductListViewModel productListViewModel = new ProductListViewModel
          {
              ProductsList = productViewList,
              TotalPage = productsPage.TotalPages
          };
          return productListViewModel;
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
                CategoryId = productViewModel.category_id,
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