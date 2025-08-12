using System.ComponentModel.DataAnnotations;

namespace Book_Store_API.Entites;

public class Book
{
    [Key]
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; } 
    public decimal Price { get; set; }

    //Foreign Properties
    public int AuthorId { get; set; } 
    public Author? Author { get; set; } 
    public int CategoryId { get; set; } 
    public Category? Category { get; set; } 
}
