using MyBooks.Core.Enums;

namespace MyBooks.Core.Entities;

public class Book : EntityBase
{
    public Book(string title)
    {
        Title = title;
    }

    public string Title { get; set; }
    
    public string? Description { get; set; }

    public string? Author { get; set; }
    
    public uint UserId { get; set; }
    public User User { get; private set; } = null!;
}