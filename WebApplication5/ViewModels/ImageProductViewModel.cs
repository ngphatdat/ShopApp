namespace WebApplication5.ViewModels;

public class ImageProductViewModel
{
    public int ProductId { get; set; }  
    public IFormFile[] Image { get; set; } = null!;
    
}