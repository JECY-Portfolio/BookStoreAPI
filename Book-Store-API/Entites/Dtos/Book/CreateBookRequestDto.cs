namespace Book_Store_API.Entites.Dtos.Book;

public class CreateBookRequestDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int AuthorId { get; set; }
    public int CategoryId { get; set; }
}
