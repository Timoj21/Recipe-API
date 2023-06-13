namespace RecipeAPI.Models
{
    public class RecipeIngredientItem
    {
        public long RecipeId { get; set; }
        public long IngredientId { get; set; }
        public RecipeItem Recipe { get; set; } = null!;
        public IngredientItem Ingredient { get; set; } = null!;
        public int? Amount { get; set; }
        public int AmountTypeId { get; set; }
        public AmountTypeItem AmountType { get; set; } = null!;
    }
}
