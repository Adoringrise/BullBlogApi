using AutoMapper;
using BullBlogApi.Dtos;
using BullBlogApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BullBlogApi.Services;

public class RepositoryServiceSql : IRepositoryService
{
    private readonly DataContext _context;

    private readonly IMapper _mapper;

    public RepositoryServiceSql(DataContext context, IMapper mapper)
    {
        _context = context;

        _mapper = mapper;
    }

    public async Task<User> AddUserAsync(UserDto userDto)
    {
        var dbUser = _mapper.Map<User>(userDto);

        dbUser = _context.Users.Add(dbUser).Entity;

        await _context.SaveChangesAsync();
        
        return dbUser;
    }

    public async Task<Post> AddPostAsync(PostDto postDto)
    {
        var dbPost = _mapper.Map<Post>(postDto);

        dbPost = _context.Posts.Add(dbPost).Entity;

        await _context.SaveChangesAsync();

        return dbPost;
    }


    public async Task<List<Post>> GetPostAsync(string email)
    {
        var dbPost = await _context.Posts.Where(p => p.UserEmail == email).ToListAsync();

        return dbPost;
    }

    public async Task<Post> GetLastPostAsync(string email)
    {
        var dbPost = await _context.Posts.OrderByDescending(p => p.Id).Where(p => p.UserEmail == email).LastAsync();

        return dbPost;
    }
}