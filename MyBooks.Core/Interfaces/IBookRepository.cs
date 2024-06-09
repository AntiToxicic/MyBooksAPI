using MyBooks.Core.Entities;

namespace MyBooks.Core.Interfaces;

public interface IBookRepository
{
    public Task<Book> Create(Book book);
    
    public Task<Book?> Get(uint bookId);

    public Task<IEnumerable<Book>> GetAll(uint userId);

    public Task Update(Book book);

    public Task Delete(Book book);
}