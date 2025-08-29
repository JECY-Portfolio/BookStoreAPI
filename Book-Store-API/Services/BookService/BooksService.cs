using Book_Store_API.Entites;
using Book_Store_API.Entites.Dtos.Book;
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

    public async Task AddBookAsync(CreateBookRequestDto requestDto)
    {
        //Mapping

        //Manual Mapping
        var newEntity = new Book
        {
            Title = requestDto.Title,
            Description = requestDto.Description,
            Price = requestDto.Price,
            AuthorId = requestDto.AuthorId,
            CategoryId = requestDto.CategoryId
        };

        await _booksRepository.AddBookAsync(newEntity);
    }

    public async Task UpdateBookAsync(UpdateBookRequestDto requestDto)
    {
        //Get the existing book
        var existingBook = await _booksRepository.GetBookByIdAsync(requestDto.Id);
        if (existingBook == null)
            throw new KeyNotFoundException($"Book with ID {requestDto.Id} not found.");

        existingBook.Title = requestDto.Title;
        existingBook.Description = requestDto.Description;
        existingBook.Price = requestDto.Price;
        existingBook.AuthorId = requestDto.AuthorId;
        existingBook.CategoryId = requestDto.CategoryId;

        await _booksRepository.UpdateBooksAsync(existingBook);
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
