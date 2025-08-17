using Book_Store_API.Data;
using Book_Store_API.Entites;
using Microsoft.EntityFrameworkCore;

namespace Book_Store_API.Repository.BooksRepo;

public class BooksRepository : IBooksRepository
{
    private readonly AppDbContext _context;

    public BooksRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Book> GetBookByIdAsync(int id)
    {
        return await _context.Books.FindAsync(id);
    }

    public async Task AddBookAsync(Book book)
    {
        _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateBooksAsync(Book book)
    {
        _context.Update(book);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteBookAsync(int id) 
    {
        _context.Remove(id);
        await _context.SaveChangesAsync();
    }  

    public async Task<IEnumerable<Book>> SearchBooks(string searchTerm)
    {
        var book = await _context.Books.Where(x =>
                               x.Title == searchTerm
                            || x.Price.ToString() == searchTerm
                            || x.Description == searchTerm).ToListAsync();

        return book;
    }

    public async Task<Book> GetBookByCategory(int categoryId)
    {
        return await _context.Books.FirstOrDefaultAsync(x => x.CategoryId == categoryId);
    }

    public async Task<Book> GetBookByAuthor(int authorId)
    {
        return await _context.Books.FirstOrDefaultAsync(x => x.CategoryId == authorId);
    }
}

//Asynchronous programming

