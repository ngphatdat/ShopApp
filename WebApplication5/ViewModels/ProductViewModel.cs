using System.Text.Json.Serialization;
using WebApplication5.Models;

namespace WebApplication5.ViewModels;

public class ProductViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string? Thumbnail { get; set; } = "";
    public string? Description { get; set; } = "";
    [JsonPropertyName("category_id")]
    public int? CategoryId { get; set; } = 0;
}