using Book_Store_API.Entites;
using Microsoft.EntityFrameworkCore;

namespace Book_Store_API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Category> Categories { get; set; }
}

//EntityFrameworkCore
//SqlServer