using BullBlogApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BullBlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context) 
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            var dbUser = _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(dbUser);
        }
    }
}
