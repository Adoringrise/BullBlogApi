using AutoMapper;
using BullBlogApi.Dtos;
using BullBlogApi.Models;

namespace BullBlogApi.AutoMapper
{
    public class AutomapperUserProfile : Profile
    {
        public AutomapperUserProfile() 
        {
            CreateMap<User, UserDto>();

            CreateMap<UserDto, User>();
        }
    }
}
