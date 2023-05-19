using BullBlogApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BullBlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly DataContext _context;
        public PostsController(DataContext context)
        {
            _context = context;
        }
        [HttpGet("{email}")]
        public async Task<ActionResult<List<Post>>> Get(string email)
        {
            var posts = await _context.Posts.Where(p => p.UserEmail == email).ToListAsync();

            if (posts.IsNullOrEmpty())
            {
                return NotFound("Post not found");
            }

            return Ok(posts);
        }

        [HttpGet("{email}/last")]
        public async Task<ActionResult<Post>> GetLast(string email)
        {
            var post = await _context.Posts.OrderByDescending(p => p.Id).Where(p => p.UserEmail == email).LastAsync();

            if (post == null)
            {
                return NotFound("Post not found");
            }

            return Ok(post);
        }


        [HttpPost]
        public async Task<ActionResult<Post>> AddPost(Post post)
        {
            var dbPost = _context.Posts.Add(post);

            await _context.SaveChangesAsync();

            return Ok(dbPost);
        }
    }
}
