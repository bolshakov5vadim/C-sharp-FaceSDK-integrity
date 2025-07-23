using Microsoft.EntityFrameworkCore;
using SimpleTODOLesson.Models;

namespace SimpleTODOLesson.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<PostModel> Posts { get; set; }
    }
}