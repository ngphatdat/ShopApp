using WebApplication5.ViewModels;

namespace WebApplication5.Response;

public class ProductListViewModel
{
    public IEnumerable<ProductViewModel> ProductsList { get; set; }
    public int TotalPage { get; set; }

}