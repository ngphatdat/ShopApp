using Microsoft.AspNetCore.Mvc;
using WebApplication5.Services;
using WebApplication5.ViewModels;

namespace WebApplication5.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductController:ControllerBase
{
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    [HttpGet ("all")]
    public async Task<IActionResult> GetAllProducts()
    {
         var products=   await _productService.GetAllProducts();
         return Ok(products);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var product = await _productService.GetProductById(id);
        return Ok(product);
    }
    [HttpPost ("add")]
    public async Task<IActionResult> AddProduct(ProductViewModel productViewModel)
    {
        await _productService.AddProduct(productViewModel);
        return Ok();
    }
    
}