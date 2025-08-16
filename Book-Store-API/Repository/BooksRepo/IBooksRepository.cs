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
}


