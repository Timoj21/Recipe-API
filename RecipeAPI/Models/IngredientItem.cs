namespace RecipeAPI.Models
{
    public class IngredientItem
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<RecipeIngredientItem>? RecipeIngredients { get; set; }
    }
}
