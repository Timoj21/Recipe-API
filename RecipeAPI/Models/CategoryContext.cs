using Microsoft.EntityFrameworkCore;

namespace RecipeAPI.Models
{
    public class CategoryContext : DbContext
    {
        public CategoryContext(DbContextOptions<CategoryContext> options)
            : base(options)
        {
        }

        public DbSet<CategoryItem> CategoryItems { get; set; } = null!;
    }
}
