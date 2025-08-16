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
}

//Asynchronous programming
