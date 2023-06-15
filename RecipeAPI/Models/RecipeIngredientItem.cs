namespace RecipeAPI.Models
{
    public class RecipeIngredientItem
    {
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public RecipeItem Recipe { get; set; } = null!;
        public IngredientItem Ingredient { get; set; } = null!;
        public int? Amount { get; set; }
        public int AmountTypeId { get; set; }
        public AmountTypeItem AmountType { get; set; } = null!;
    }
}
