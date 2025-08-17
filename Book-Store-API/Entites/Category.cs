using System.Text.Json.Serialization;

namespace Book_Store_API.Entites;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } 
    public string? Description { get; set; }
    [JsonIgnore]
    public ICollection<Book> Books { get; set; } = new List<Book>();
}
