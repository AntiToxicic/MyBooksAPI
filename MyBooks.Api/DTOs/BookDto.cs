using MyBooks.Core.Enums;

namespace MyBooksAPI.DTOs;

public class BookDto
{
    public string Title { get; set; }
    
    public string? Description { get; set; }

    public string? Author { get; set; }
}