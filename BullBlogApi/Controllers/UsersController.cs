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
        public async Task<ActionResult<UserDto>> AddUser(UserDto userDto)
        {
            var dbUser = await _repositoryService.AddUserAsync(userDto);

            return Ok(dbUser);
        }
    }
}
