using Book_Store_API.Entites;

namespace Book_Store_API.Services;

public interface IBooksService
{
    Task<IEnumerable<Book>> GetAllBooksAsync();
    Task<Book> GetBookByIdAsync(int id);
}
