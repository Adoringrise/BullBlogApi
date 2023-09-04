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


        [HttpGet()]
        public async Task<ActionResult<List<PostDto>>> Get()
        {
            try
            {
                var dbPosts = await _repositoryService.GetAllPostsAsync();

                if (dbPosts.IsNullOrEmpty())
                {
                    return NotFound("Posts not found");
                }

                return Ok(dbPosts);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet("{email}")]
        public async Task<ActionResult<List<PostDto>>> Get(string email)
        {
            if (email == null || !email.Contains("@"))
            {
                return BadRequest("email can't be empty");
            }

            try
            {
                var dbPosts = await _repositoryService.GetPostsAsync(email);

                if (dbPosts.IsNullOrEmpty())
                {
                    return NotFound("Post not found");
                }

                return Ok(dbPosts);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpGet("{email}/last")]
        public async Task<ActionResult<PostDto>> GetLast(string email)
        {
            if (email == null || !email.Contains("@"))
            {
                return BadRequest("email can't be empty");
            }

            try
            {
                var dbPost = await _repositoryService.GetLastPostAsync(email);

                if (dbPost == null)
                {
                    return NotFound("Post not found");
                }

                return Ok(dbPost);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

        }


        [HttpPost]
        public async Task<ActionResult<PostDto>> AddPost(PostDto postDto)
        {
            try
            {
                var dbPost = await _repositoryService.AddPostAsync(postDto);

                return Ok(dbPost);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

        }
    }
}
