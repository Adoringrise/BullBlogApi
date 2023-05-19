using BullBlogApi.Models;

namespace BullBlogApi.Services;

public class RepositoryServiceSql : IRepositoryService
{
    private readonly DataContext _context;

    public RepositoryServiceSql(DataContext context)
    {
        _context = context;
    }

    public async Task<User> AddUserAsync(User user)
    {
        var dbUser = _context.Users.Add(user).Entity;
        await _context.SaveChangesAsync();
        
        return dbUser;
    }
}