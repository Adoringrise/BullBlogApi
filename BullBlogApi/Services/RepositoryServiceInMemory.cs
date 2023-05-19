using BullBlogApi.Models;

namespace BullBlogApi.Services;

public class RepositoryServiceInMemory : IRepositoryService
{
    private static List<User> Users { get; set; } = new();
    public Task<User> AddUserAsync(User user)
    {
        var tcs = new TaskCompletionSource<User>();
        
        Users.Add(user);
        tcs.SetResult(user);
        return tcs.Task;
    }
}