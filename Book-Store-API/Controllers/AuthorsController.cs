using Book_Store_API.Entites;
using Book_Store_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsService _authorsService;

        public AuthorsController(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _authorsService.GetAllAuthorsAsync();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await _authorsService.GetAuthorByIdAsync(id);
            return Ok(author);
        }

        [HttpPost]

        public async Task<IActionResult> AddAuthor([FromBody] Author author)
        {
            var createdAuthor = await _authorsService.AddAuthorAsync(author);
            return CreatedAtAction(nameof(GetAuthorById), new { id = createdAuthor.Id }, createdAuthor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] Author author)
        {
            if (id != author.Id)
                return BadRequest("Author ID not valid.");

            var updatedAuthor = await _authorsService.UpdateAuthorAsync(author);
            return Ok(updatedAuthor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            await _authorsService.DeleteAuthorAsync(id);
            return NoContent();
        }


    }
}
