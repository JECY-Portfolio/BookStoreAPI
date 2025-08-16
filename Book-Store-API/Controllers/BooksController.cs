using Book_Store_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBooksService _booksService;

    public BooksController(IBooksService booksService)
    {
        _booksService = booksService;
    }

    //www.jumia.com/getallproducts
    //www.jumia.com/getproductbyid/1
    //www.bookstore.com/api/books

    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
        var books = await _booksService.GetAllBooksAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookById(int id)
    {
        var book = await _booksService.GetBookByIdAsync(id);
     
        return Ok(book);
    }
}
