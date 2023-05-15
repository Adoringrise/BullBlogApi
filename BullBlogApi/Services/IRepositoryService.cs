using BullBlogApi.Models;
using Microsoft.AspNetCore.Connections;

namespace BullBlogApi.Services;

public interface IRepositoryService
{
    public Task<User> AddUserAsync(User user);
}