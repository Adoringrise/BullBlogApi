using BullBlogApi.Dtos;
using BullBlogApi.Models;
using Microsoft.AspNetCore.Connections;

namespace BullBlogApi.Services;

public interface IRepositoryService
{
    public Task<UserDto> AddUserAsync(UserDto userDto);
    public Task<PostDto> AddPostAsync(PostDto postDto);
    public Task<List<PostDto>> GetPostsAsync(string email);
    public Task<PostDto> GetLastPostAsync(string email);
}