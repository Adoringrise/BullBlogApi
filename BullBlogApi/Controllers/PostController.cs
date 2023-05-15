using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BullBlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly DataContext _context;
        public PostController(DataContext context)
        {
            _context = context;
        }
        [HttpGet("{email}")]
        public async Task<ActionResult<List<Post>>> Get(string email)
        {
            var post = await _context.Posts.Where(p => p.UserEmail == email).ToListAsync();

            if (post == null)
            {
                return BadRequest("Post not found");
            }

            return Ok(post);
        }

        [HttpGet("{email}/last")]
        public async Task<ActionResult<Post>> GetLast(string email)
        {
            var post = await _context.Posts.OrderByDescending(p => p.Id).Where(p => p.UserEmail == email).LastAsync();

            if (post == null)
            {
                return BadRequest("Post not found");
            }

            return Ok(post);
        }


        [HttpPost]
        public async Task<ActionResult<List<Post>>> AddPost(Post post)
        {
            _context.Posts.Add(post);

            await _context.SaveChangesAsync();

            return Ok(await _context.Posts.ToListAsync());
        }
    }
}
