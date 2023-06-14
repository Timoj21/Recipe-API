using Microsoft.EntityFrameworkCore;
using RecipeAPI.Models;

namespace RecipeAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options) 
        {
        }

        public DbSet<AmountTypeItem> AmountTypeItems { get; set; } = null!;
        public DbSet<CategoryItem> CategoryItems { get; set; } = null!;
        public DbSet<IngredientItem> IngredientItems { get; set; } = null!;
        public DbSet<RecipeCategoryItem> RecipeCategoryItems { get; set; } = null!;
        public DbSet<RecipeItem> RecipeItems { get; set; } = null!;
        public DbSet<RecipeIngredientItem> RecipeIngredients { get; set; } = null!;
        public DbSet<ReviewItem> ReviewItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeCategoryItem>()
                .HasKey(rc => new { rc.RecipeId, rc.CategoryId });
            modelBuilder.Entity<RecipeCategoryItem>()
                .HasOne(r => r.Recipe)
                .WithMany(rc => rc.RecipeCategories)
                .HasForeignKey(r => r.RecipeId);
            modelBuilder.Entity<RecipeCategoryItem>()
                .HasOne(c => c.Category)
                .WithMany(rc => rc.RecipeCategories)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<RecipeIngredientItem>()
                .HasKey(ri => new { ri.RecipeId, ri.IngredientId });
            modelBuilder.Entity<RecipeIngredientItem>()
                .HasOne(r => r.Recipe)
                .WithMany(ri => ri.RecipeIngredients)
                .HasForeignKey(r => r.RecipeId);
            modelBuilder.Entity<RecipeIngredientItem>()
                .HasOne(i => i.Ingredient)
                .WithMany(ri => ri.RecipeIngredients)
                .HasForeignKey(i => i.IngredientId);
        }
    }
}
