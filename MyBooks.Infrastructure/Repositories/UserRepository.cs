using Microsoft.EntityFrameworkCore;
using MyBooks.Core.Entities;
using MyBooks.Core.Interfaces;

namespace MyBooks.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly SqliteContext _context;

    public UserRepository(SqliteContext context)
    {
        _context = context;
    }

    public async Task<User> Create(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<User?> Get(uint userId) =>
        await _context.Users.FirstOrDefaultAsync(c => c.Id == userId);
 
    public async Task<User?> GetByUserName(string userName) =>
        await _context.Users.FirstOrDefaultAsync(c => c.UserName == userName);

    public async Task Update(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}