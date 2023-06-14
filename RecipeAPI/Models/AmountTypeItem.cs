namespace RecipeAPI.Models
{
    public class AmountTypeItem
    {
        public int Id { get; set; }
        public required string Type { get; set; }
        public ICollection<RecipeIngredientItem>? RecipeIngredients { get; set; }

    }
}
