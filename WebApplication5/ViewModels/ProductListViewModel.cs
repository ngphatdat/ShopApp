namespace WebApplication5.ViewModels;

public class ProductListViewModel
{
    public IEnumerable<ProductViewModel> ProductsList { get; set; }
    public int TotalPage { get; set; }

}