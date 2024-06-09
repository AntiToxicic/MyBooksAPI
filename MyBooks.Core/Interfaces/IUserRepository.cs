using MyBooks.Core.Entities;

namespace MyBooks.Core.Interfaces;

public interface IUserRepository
{
    public Task<User> Create(User user);

    public Task<User?> Get(uint userId);
    
    public Task<User?> GetByUserName(string userName);

    public Task Update(User user);
    
    public Task Delete(User user);
}