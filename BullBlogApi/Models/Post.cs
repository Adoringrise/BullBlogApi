namespace BullBlogApi.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string? Content { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public User? User { get; set; }
        public string UserEmail { get; set; } = string.Empty;

    }
}
