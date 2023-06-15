namespace RecipeAPI.Models
{
    public class CategoryItem
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<RecipeCategoryItem>? RecipeCategories { get; set; }
    }
}
