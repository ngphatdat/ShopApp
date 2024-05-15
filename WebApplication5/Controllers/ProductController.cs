using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
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
    public async Task<IActionResult> GetProducts(string? keyword, int category_id , string? sortBy, int page, int limit)
    {
        try
        {
            var products = await _productService.GetProducts(keyword, category_id,  sortBy, page, limit);
            
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
    [Authorize(Roles = AppRole.Admin)]
    [HttpPost ("add")]
    public async Task<IActionResult> AddProduct(ProductViewModel productViewModel)
    {
        await _productService.AddProduct(productViewModel);
        return Ok();
    }
    [Authorize(Roles = AppRole.Admin)]
    [HttpPost ("insert")]
        public async Task<IActionResult> InsertProduct(ProductViewModel productViewModel)
        {
            try
            {
                await _productService.AddProduct(productViewModel);
                return Ok("Product inserted");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("Error");
            }
        }
        [Authorize(Roles = AppRole.Admin)]
        [HttpDelete ("delete/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _productService.DeleteProduct(id);
                return Ok("Product deleted");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("Error");
            }
        }
}