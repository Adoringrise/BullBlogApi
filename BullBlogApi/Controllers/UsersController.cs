using BullBlogApi.Dtos;
using BullBlogApi.Models;
using BullBlogApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BullBlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepositoryService _repositoryService;

        public UsersController(IRepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            var dbUser = await _repositoryService.AddUserAsync(user);

            return Ok(dbUser);
        }
    }
}
