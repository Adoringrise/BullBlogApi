namespace BullBlogApi
{
    public class Post
    {
        public int Id { get; set; }
        public string? Content { get; set; } = String.Empty;
        public DateTime CreatedDate { get; set; }
        public User? User { get; set; }
       public string UserEmail { get; set; } = String.Empty;

    }
}
