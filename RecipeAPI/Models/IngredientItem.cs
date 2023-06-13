namespace RecipeAPI.Models
{
    public class IngredientItem
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public List<RecipeIngredientItem> RecipeIngredients { get; } = new();
    }
}
