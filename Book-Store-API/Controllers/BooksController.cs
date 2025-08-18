using Book_Store_API.Entites;
using Book_Store_API.Services.BookService;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

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

    [HttpPost]
    public async Task<IActionResult> AddBook(Book book)
    {
        var result = _booksService.AddBookAsync(book);
        return CreatedAtAction(nameof(GetBookById), new { Id = result.Id }, result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBook(Book book)
    {
        var result = _booksService.UpdateBookAsync(book);
        return CreatedAtAction(nameof(GetBookById), new { Id = result.Id }, result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        _booksService.DeleteBookAsync(id);
        return Ok();
    }

    [HttpGet("search-books")]
    public async Task<IActionResult> SearchBooks(string? searchTerm)
    {
        var result = _booksService.SearchBook(searchTerm);
        return Ok(result);
    }

    [HttpGet("get-book-by-category-id/{id}")]
    public async Task<IActionResult> GetBookByCategoryId(int id)
    {
        var book = await _booksService.GetBookByCategory(id);
        return Ok(book);
    }

    [HttpGet("get-book-by-author-id/{id}")]
    public async Task<IActionResult> GetBookByAuthorId(int id)
    {
        var book = await _booksService.GetBookByAuthor(id);
        return Ok(book);
    }


}
