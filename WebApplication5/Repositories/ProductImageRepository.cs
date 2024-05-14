using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Repositories;

public class ProductImageRepository:IProductImageRepository
{
    private readonly DotNetCoreContext  _context;
    private readonly IProductRepository _productRepository;
    public ProductImageRepository(DotNetCoreContext context, IProductRepository productRepository)
    {
        _context = context;
        _productRepository = productRepository;
    }

    public async Task AddProductImageAsync(string url, int productId)
    {
        try
        {
            var product = await _productRepository.GetProductById(productId);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            _context.Products.Update(product);
            var productImage = new ProductImage
            {
                ImageUrl = url,
                ProductId = productId
            };
            product.Thumbnail = url;
            await _context.ProductImages.AddAsync(productImage);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception("Error while adding product image");
        }
    }
    public async Task<string> GetProductImageAsync(int productId)
    {
        var url = await _context.ProductImages
            .Where(x => x.ProductId == productId).Select(x => x.ImageUrl).FirstOrDefaultAsync();
        if (url == null)
        {
            throw new Exception("Product image not found");
        }
        return url;
    }

    public Task UpdateProductImageAsync(ProductImage productImage)
    {
        throw new NotImplementedException();
    }
}