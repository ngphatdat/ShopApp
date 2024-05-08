using WebApplication5.Models;
using WebApplication5.Repositories;

namespace WebApplication5.Services;

public class CategoryService:ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }


    public async Task<IEnumerable<Category>> GetAllCategories()
    {
       return await _categoryRepository.GetAllCategories();
    }

    public async Task<Category?> GetCategoryById(int id)
    {
        return await _categoryRepository.GetCategoryById(id);
    }
}