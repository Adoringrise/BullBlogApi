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

    public async Task<UserDto> AddUserAsync(UserDto userDto)
    {
        var dbUser = _mapper.Map<User>(userDto);

        dbUser = _context.Users.Add(dbUser).Entity;

        await _context.SaveChangesAsync();
        
        var dtoUser = _mapper.Map<UserDto>(dbUser);

        return dtoUser;
    }

    public async Task<PostDto> AddPostAsync(PostDto postDto)
    {
        var dbPost = _mapper.Map<Post>(postDto);

        dbPost = _context.Posts.Add(dbPost).Entity;

        await _context.SaveChangesAsync();

        var dtoPost = _mapper.Map<PostDto>(postDto);

        return dtoPost;
    }


    public async Task<List<PostDto>> GetPostsAsync(string email)
    {
        var dbPost = await _context.Posts.Where(p => p.UserEmail == email).ToListAsync();
        
        var dtoPosts = _mapper.Map<List<Post>, List<PostDto>>(dbPost);

        return dtoPosts;
    }

    public async Task<PostDto> GetLastPostAsync(string email)
    {
        var dbPost = await _context.Posts.OrderByDescending(p => p.Id).Where(p => p.UserEmail == email).LastAsync();

        var dtoPost = _mapper.Map<PostDto>(dbPost);

        return dtoPost;
    }
}