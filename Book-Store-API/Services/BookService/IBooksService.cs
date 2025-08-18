using Book_Store_API.Entites;

namespace Book_Store_API.Services.BookService;

public interface IBooksService
{
    Task<IEnumerable<Book>> GetAllBooksAsync();
    Task<Book> GetBookByIdAsync(int id);
    Task AddBookAsync(Book book);
    Task UpdateBookAsync(Book book);
    void DeleteBookAsync(int id);
    Task<IEnumerable<Book>> SearchBook(string searchTerm);
    Task<Book> GetBookByCategory(int categoryId);
    Task<Book> GetBookByAuthor(int authorId);
}
