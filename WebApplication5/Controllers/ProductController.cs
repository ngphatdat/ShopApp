using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
using WebApplication5.Services;
using WebApplication5.ViewModels;

namespace WebApplication5.Controllers;
[ApiController]
[Route("api/[controller]")]
//[Authorize(Roles = AppRole.Admin)]
public class ProductController:ControllerBase
{
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    [HttpGet ("all")]
    public async Task<IActionResult> GetProducts(string? keyword, int categoryId , string? sortBy, int page, int limit)
    {
        try
        {
            var products = await _productService.GetProducts(keyword, categoryId,  sortBy, page, limit);
            
            return Ok(products);
        }
        catch (Exception e)
        {
             Console.WriteLine(e);
             return BadRequest("Error");
        }
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