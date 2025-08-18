using Book_Store_API.Data;
using Book_Store_API.Entites;

namespace Book_Store_API.Repository.CategoriesRepo;

public interface ICategoriesRepository
{
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<Category> GetCategoryByIdAsync(int id);
    Task<Category> AddCategoryAsync(Category category);
    Task<Category> UpdateCategoryAsync(Category category);
    Task<bool> DeleteCategoryAsync(int id);
}
