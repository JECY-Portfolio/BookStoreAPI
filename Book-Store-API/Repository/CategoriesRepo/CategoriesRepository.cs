using Book_Store_API.Data;
using Book_Store_API.Entites;
using Microsoft.EntityFrameworkCore;

namespace Book_Store_API.Repository.CategoriesRepo;

public class CategoriesRepository : ICategoriesRepository
{
    private readonly AppDbContext _context;

    public CategoriesRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Category> AddCategoryAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        return await _context.Categories
                 .Where(c => c.Id == id)
                 .ExecuteDeleteAsync() > 0;  
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
       return await _context.Categories.ToListAsync();
    }

    public async Task<Category> GetCategoryByIdAsync(int id)
    {
        return await _context.Categories
            .FindAsync(id);
    }

    public async Task<Category> UpdateCategoryAsync(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
        return category;
    }
}
