using BullBlogApi.Dtos;
using BullBlogApi.Models;
using Microsoft.AspNetCore.Connections;

namespace BullBlogApi.Services;

public interface IRepositoryService
{
    public Task<User> AddUserAsync(UserDto userDto);
    public Task<Post> AddPostAsync(PostDto postDto);
    public Task<List<Post>> GetPostAsync(string email);
    public Task<Post> GetLastPostAsync(string email);
}