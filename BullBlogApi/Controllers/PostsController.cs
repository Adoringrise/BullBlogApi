using BullBlogApi.Dtos;
using BullBlogApi.Models;
using BullBlogApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BullBlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IRepositoryService _repositoryService;
        public PostsController(IRepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
        }


        [HttpGet("{email}")]
        public async Task<ActionResult<List<Post>>> Get(string email)
        {
            var dbPost = await _repositoryService.GetPostAsync(email);

            if (dbPost.IsNullOrEmpty())
            {
                return NotFound("Post not found");
            }

            return Ok(dbPost);
        }

        [HttpGet("{email}/last")]
        public async Task<ActionResult<Post>> GetLast(string email)
        {
            var post = await _repositoryService.GetLastPostAsync(email);

            if (post == null)
            {
                return NotFound("Post not found");
            }

            return Ok(post);
        }


        [HttpPost]
        public async Task<ActionResult<Post>> AddPost(PostDto postDto)
        {
            var dbPost = await _repositoryService.AddPostAsync(postDto);

            return Ok(dbPost);
        }
    }
}
