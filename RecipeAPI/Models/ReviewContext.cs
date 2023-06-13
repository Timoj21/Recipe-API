using Microsoft.EntityFrameworkCore;

namespace RecipeAPI.Models
{
    public class ReviewContext : DbContext
    {
        public ReviewContext(DbContextOptions<ReviewContext> options)
            : base(options)
        {
        }

        public DbSet<ReviewItem> ReviewItems { get; set; } = null!;
    }
}

