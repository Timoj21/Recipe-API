using Microsoft.EntityFrameworkCore;

namespace RecipeAPI.Models
{
    public class IngredientContext : DbContext
    {
        public IngredientContext(DbContextOptions<IngredientContext> options)
            : base(options) { }

        public DbSet<IngredientItem> IngredientItems { get; set; } = null!;
    }
}
