namespace RecipeAPI.Models
{
    public class RecipeCategoryItem
    {
        public int RecipeId { get; set; }
        public int CategoryId { get; set; }
        public RecipeItem Recipe { get; set; } = null!;
        public CategoryItem Category { get; set; } = null!;
    }
}
