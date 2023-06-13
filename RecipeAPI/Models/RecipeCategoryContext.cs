using Microsoft.EntityFrameworkCore;

namespace RecipeAPI.Models
{
    public class RecipeCategoryContext : DbContext
    {
        public RecipeCategoryContext(DbContextOptions<RecipeCategoryContext> options)
            : base(options)
        {
        }

        public DbSet<RecipeCategoryItem> RecipeCategoryItems { get; set; } = null!;
    }
}
