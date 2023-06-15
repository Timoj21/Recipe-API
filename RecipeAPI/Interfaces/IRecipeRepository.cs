using RecipeAPI.Models;

namespace RecipeAPI.Interfaces
{
    public interface IRecipeRepository
    {
        ICollection<RecipeItem> GetRecipes();
        RecipeItem GetRecipe(int id);
        ICollection<RecipeItem> GetRecipesByTitle(string title);
        ICollection<RecipeItem> GetRecipesByPrepTime(int time);
        bool RecipeExists(int id);
        bool CreateRecipe(int categoryId, int ingredientId, int amountTypeId, int amount, RecipeItem recipe);
        bool Save();
    }
}
