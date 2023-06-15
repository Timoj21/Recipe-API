using System.Reflection.Metadata;

namespace RecipeAPI.Models
{
    public class RecipeItem
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Instructions { get; set; }
        public int? PrepTime { get; set; }
        public byte[]? Picture { get; set; }
        public ICollection<ReviewItem>? Reviews { get; set; }
        public ICollection<RecipeIngredientItem>? RecipeIngredients { get; set; }
        public ICollection<RecipeCategoryItem>? RecipeCategories { get; set; }
    }
}
