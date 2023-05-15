using BullBlogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BullBlogApi.Data
{
    public class DataContext : DbContext
    { 
        public DataContext(DbContextOptions<DataContext> options): base(options) { }
    
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
