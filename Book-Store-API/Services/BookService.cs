using Book_Store_API.Entites;
using Book_Store_API.Repository.BooksRepo;

namespace Book_Store_API.Services;

public class BookService : IBooksService
{
    private readonly IBooksRepository _booksRepository;

    public BookService(IBooksRepository booksRepository)
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
}
