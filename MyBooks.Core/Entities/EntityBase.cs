namespace MyBooks.Core.Entities;

public class EntityBase
{
    public uint Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}