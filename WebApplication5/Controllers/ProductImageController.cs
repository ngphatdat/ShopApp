using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using WebApplication5.Services;
using WebApplication5.ViewModels;

namespace WebApplication5.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductImageController:ControllerBase
{
    private readonly IProductImageService _productImageService;
    private readonly IProductService _productService;
    private readonly string _wwwRootPath;
    public ProductImageController(IProductImageService productImageService, IProductService productService, IWebHostEnvironment HostingEnvironment)
    {
        _productImageService = productImageService;
        _productService = productService;
        _wwwRootPath = HostingEnvironment.WebRootPath;
    }
    [HttpPost("add")]
    public async Task<IActionResult> AddProductImage([FromForm] ImageProductViewModel img)
    {
            if(await _productService.GetProductById(img.ProductId) == null)
            {
                return BadRequest("Product not found");
            }
            if (img.Image.Length == 0)
            {
                return BadRequest("Image is required");
            }
            var thumbnail =DateTime.Now.Ticks + img.Image.FileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", thumbnail);
            using ( var stream = new FileStream(path, FileMode.Create))
            {
                await img.Image.CopyToAsync(stream);
            }
            await _productImageService.AddProductImageAsync( thumbnail, img.ProductId);
            return Ok("update success");
    }
    [HttpGet("{productId}")]
    public async Task<IActionResult> GetProductImage(int productId)
    {
        try
        {
            var productImage = await _productImageService.GetProductImageAsync(productId); 
            return Ok(productImage);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest("Product image not found");
        }
        
    }
    [HttpGet("images/{imageName}")]
    public IActionResult GetImage(string imageName)
    {
        var imagePath = Path.Combine(_wwwRootPath, "images", imageName);
        if (System.IO.File.Exists(imagePath))
        {
            var imageFileStream = System.IO.File.OpenRead(imagePath);
            return File(imageFileStream, "image/jpeg"); // Thay đổi loại mime type tùy theo loại hình ảnh
        }
        else
        {
            return NotFound();
        }
    }
    
    
}