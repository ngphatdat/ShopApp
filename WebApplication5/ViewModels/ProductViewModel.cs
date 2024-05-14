using WebApplication5.Models;

namespace WebApplication5.ViewModels;

public class ProductViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string? Thumbnail { get; set; }
    public string? Description { get; set; }
    public int? category_id { get; set; } = 0;
}