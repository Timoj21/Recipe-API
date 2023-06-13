using System.Reflection.Metadata;

namespace RecipeAPI.Models
{
    public class RecipeItem
    {
        public long Id { get; set; }
        public required string Title { get; set; }
        public string? Instructions { get; set; }
        public int? PrepTime { get; set; }
        public byte[]? Picture { get; set; }
        public ICollection<ReviewItem> Reviews { get; } = new List<ReviewItem>();
        public List<RecipeIngredientItem> RecipeIngredients { get; } = new();
        public List<RecipeCategoryItem> RecipeCategories { get; } = new();
    }
}
