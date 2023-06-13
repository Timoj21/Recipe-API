namespace RecipeAPI.Models
{
    public class CategoryItem
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<RecipeCategoryItem> RecipeCategories { get; } = new();
    }
}
