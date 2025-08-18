using Book_Store_API.Entites;
using Book_Store_API.Repository.BooksRepo;

namespace Book_Store_API.Services.BookService;

public class BooksService : IBooksService
{
    private readonly IBooksRepository _booksRepository;

    public BooksService(IBooksRepository booksRepository)
    {
        _booksRepository = booksRepository;
    }

    public async Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        return await _booksRepository.GetAllBooksAsync();
    }

    public async Task<Book> GetBookByIdAsync(int id)
    {
        var book = await _booksRepository.GetBookByIdAsync(id);

        if (book == null)
            throw new KeyNotFoundException($"Book with ID {id} not found.");

        return book;
    }

    public async Task AddBookAsync(Book book)
    {
        await _booksRepository.AddBookAsync(book);
    }

    public async Task UpdateBookAsync(Book book)
    {
        await _booksRepository.UpdateBooksAsync(book);
    }

    public void DeleteBookAsync(int id)
    {
        _booksRepository.DeleteBookAsync(id);
    }

    public async Task<IEnumerable<Book>> SearchBook(string searchTerm)
    {
        return await _booksRepository.SearchBooks(searchTerm);
    }

    public async Task<Book> GetBookByCategory(int categoryId)
    {
        return await _booksRepository.GetBookByCategory(categoryId);
    }

    public async Task<Book> GetBookByAuthor(int authorId)
    {
        return await _booksRepository.GetBookByAuthor(authorId);
    }
}
