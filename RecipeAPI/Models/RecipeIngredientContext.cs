using Microsoft.EntityFrameworkCore;

namespace RecipeAPI.Models
{
    public class RecipeIngredientContext : DbContext
    {
        public RecipeIngredientContext(DbContextOptions<RecipeIngredientContext> options)
            : base(options)
        {
        }

        public DbSet<RecipeIngredientItem> RecipeIngredients { get; set; } = null!;
    }
}
