using RecipeAPI.Models;

namespace RecipeAPI.DTO
{
    public class CreateRecipeDTO
    {
        //public int Id { get; set; }
        //public required string Title { get; set; }
        //public string? Instructions { get; set; }
        //public int? PrepTime { get; set; }
        //public byte[]? Picture { get; set; }
        public RecipeDTO recipe { get; set; }

        public ICollection<CreateIngredientItem>? createIngredientItems { get; set; }
        //public ICollection<ReviewItem>? Reviews { get; set; }
        //public ICollection<RecipeIngredientItem>? RecipeIngredients { get; set; }
        public ICollection<int>? RecipeCategories { get; set; }
    }

    public class CreateIngredientItem
    {
        public int ingredientId { get; set; }
        public int amount { get; set; }
        public int amountTypeId { get; set; }
    }

}
