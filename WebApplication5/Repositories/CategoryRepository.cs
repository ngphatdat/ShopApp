using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Repositories;

public class CategoryRepository:ICategoryRepository

{
    private readonly DotNetCoreContext _context;
    public CategoryRepository(DotNetCoreContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Category>> GetAllCategories()
    {
        var categories = await _context.Categories.ToListAsync();
        if (categories == null)
        {
            throw new Exception("No categories found");
        }

        return categories;
        
    }

    public async Task<Category?> GetCategoryById(int id)
    {
        return await _context.Categories.FindAsync(id);
    }
}