using Microsoft.EntityFrameworkCore;
using MyBooks.Core.Entities;
using MyBooks.Core.Enums;
using MyBooks.Core.Interfaces;

namespace MyBooks.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly SqliteContext _context;

    public BookRepository(SqliteContext context)
    {
        _context = context;
    }

    public async Task<Book> Create(Book book)
    {
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();

        return book;
    }

    public async Task<Book?> Get(uint bookId) =>
        await _context.Books.FirstOrDefaultAsync(c => c.Id == bookId);

    public async Task<IEnumerable<Book>> GetAll(uint userId) =>
        await _context.Books
            .Where(b => b.UserId == userId)
            .ToListAsync();

    public async Task Update(Book book)
    {
        _context.Books.Update(book);
        await _context.SaveChangesAsync();
    }


    public async Task Delete(Book book)
    {
        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
    }
}