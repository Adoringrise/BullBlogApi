using AutoMapper;
using BullBlogApi.Dtos;
using BullBlogApi.Models;

namespace BullBlogApi.AutoMapper
{
    public class AutomapperPostProfile : Profile
    {
        public AutomapperPostProfile()
        {
            CreateMap<Post, PostDto>();

            CreateMap<PostDto, Post>();
        }
    }
}
