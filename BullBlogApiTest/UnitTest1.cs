using BullBlogApi.Controllers;
using BullBlogApi.Dtos;
using BullBlogApi.Models;
using BullBlogApi.Services;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.Core;

namespace BullBlogApiTest
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test()
        {
            var repositoryServiceMock = Substitute.For<IRepositoryService>();

            var sut = new UsersController(repositoryServiceMock);

            var userDto = new UserDto()
            {
                Name = "Test",
                Surname = "Test",
                Email = "Test"
            };          
               
            var result = await sut.AddUser(userDto);

            Assert.IsType<ActionResult<User>>(result);
        }

        [Fact]
        public async Task Test1()
        {
            var user = new User();
            var userDto = new UserDto();

            var repositoryServiceMock = Substitute.For<IRepositoryService>();
            
            repositoryServiceMock.AddUserAsync(Arg.Any<UserDto>()).Returns(user);

            var sut = new UsersController(repositoryServiceMock);

            var result = await sut.AddUser(userDto);

            var actionResult = Assert.IsType<ActionResult<User>>(result);

            var userResult = Assert.IsType<User>(actionResult.Value);

            Assert.Equal(userResult, user);
               
            
        }
    }
}