using WebApplication5.Models;

namespace WebApplication5.Services;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAllCategories();
    Task<Category?> GetCategoryById(int id);
    
}