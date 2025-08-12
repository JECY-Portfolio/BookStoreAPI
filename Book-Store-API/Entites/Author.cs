namespace Book_Store_API.Entites;

public class Author
{
    public int Id { get; set; } 
    public string Name { get; set; } 
    public string? Bio { get; set; }
    public ICollection<Book> Books { get; set; } = new List<Book>();
}

