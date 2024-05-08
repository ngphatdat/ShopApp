using WebApplication5.Models;

namespace WebApplication5.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCategories();
    Task<Category?> GetCategoryById(int id);
}