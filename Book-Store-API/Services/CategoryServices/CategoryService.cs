using Book_Store_API.Entites;
using Book_Store_API.Repository.CategoriesRepo;

namespace Book_Store_API.Services.CategoryServices;

public class CategoryService : ICategoryService
{
    private readonly ICategoriesRepository _categoriesRepository;
    public CategoryService(ICategoriesRepository categoriesRepository)
    {
     _categoriesRepository = categoriesRepository;
    }
    public async Task<Category> AddCategoryAsync(Category category)
    {
        return await _categoriesRepository.AddCategoryAsync(category);         
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
      var category = await _categoriesRepository.GetCategoryByIdAsync(id);

        if (category == null)
            throw new KeyNotFoundException($"Category with ID {id} not found.");

       return await _categoriesRepository.DeleteCategoryAsync(category.Id);          
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await _categoriesRepository.GetAllCategoriesAsync();
    }

    public async Task<Category> GetCategoryByIdAsync(int id)
    {
        var category = await _categoriesRepository.GetCategoryByIdAsync(id);
        if (category == null)
            throw new KeyNotFoundException($"Category with ID {id} not found.");

        return category;
    }

    public async Task<Category> UpdateCategoryAsync(int id, Category category)
    {
        var existingCategory = await _categoriesRepository.GetCategoryByIdAsync(id); 
        if (existingCategory == null)           
            throw new KeyNotFoundException($"Category with ID {id} not found.");

        category.Id = id; 
        return await _categoriesRepository.UpdateCategoryAsync(category);

    }
}
