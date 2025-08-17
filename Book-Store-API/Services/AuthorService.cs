using Book_Store_API.Entites;
using Book_Store_API.Repository.AuthorsRepo;

namespace Book_Store_API.Services
{
    public class AuthorService : IAuthorsService
    {
        private readonly IAuthorsRepository _authorsRepository;

        public AuthorService(IAuthorsRepository authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }

        public async Task<Author> AddAuthorAsync(Author author)
        {
            if (string.IsNullOrWhiteSpace(author.Name))
                throw new ArgumentException("Author name cannot be empty.");

            return await _authorsRepository.AddAuthorAsync(author);
        }

        public async Task<bool> DeleteAuthorAsync(int id)
        {
            var existing = await _authorsRepository.GetAuthorByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException($"Author with ID {id} not found.");

            return await _authorsRepository.DeleteAuthorAsync(id);
        }

        public Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return _authorsRepository.GetAllAuthorsAsync();
        }

        public async Task<Author?> GetAuthorByIdAsync(int id)
        {
            var author = await _authorsRepository.GetAuthorByIdAsync(id);

            if (author == null)
                throw new KeyNotFoundException($"Author with ID {id} not found.");

            return author;
        }

        public async Task<Author> UpdateAuthorAsync(Author author)
        {
            var existing = await _authorsRepository.GetAuthorByIdAsync(author.Id);
            if (existing == null)
                throw new KeyNotFoundException($"Author with ID {author.Id} not found.");

            return await _authorsRepository.UpdateAuthorAsync(author);
        }
    }
}
