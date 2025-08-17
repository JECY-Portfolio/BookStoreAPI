using Book_Store_API.Entites;

namespace Book_Store_API.Repository.BooksRepo;

public interface IBooksRepository
{
    //CRUD
    //Create/Add
    //Read/Get
    //Update/Edit
    //Delete

    Task<IEnumerable<Book>> GetAllBooksAsync();
    Task<Book> GetBookByIdAsync(int id);
    Task AddBookAsync(Book book);
    Task UpdateBooksAsync(Book book);
    Task DeleteBookAsync(int id);
    Task<IEnumerable<Book>> SearchBooks(string searchTerm);
    Task<Book> GetBookByCategory(int categoryId);
    Task<Book> GetBookByAuthor(int authorId);
}


