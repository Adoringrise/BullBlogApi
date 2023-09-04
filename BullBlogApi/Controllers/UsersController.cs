using BullBlogApi.Dtos;
using BullBlogApi.Models;
using BullBlogApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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

        [HttpGet()]
        public async Task<ActionResult<List<UserDto>>> Get()
        {
            try
            {
                var dbUsers = await _repositoryService.GetAllUsersAsync();

                if (dbUsers.IsNullOrEmpty())
                {
                    return NotFound("Users not found");
                }

                return Ok(dbUsers);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> AddUser(UserDto userDto)
        {
            try
            {
                var dbUser = await _repositoryService.AddUserAsync(userDto);

                return Ok(dbUser);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
