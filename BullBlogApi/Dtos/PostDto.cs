using BullBlogApi.Models;
using System.ComponentModel.DataAnnotations;

namespace BullBlogApi.Dtos
{
    public class PostDto
    {
        public string? Content { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string UserEmail { get; set; } = string.Empty;
    }
}
