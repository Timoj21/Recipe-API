using RecipeAPI.DTO;
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
        bool CreateRecipe(CreateRecipeDTO createRecipe, RecipeItem recipe);
        bool UpdateRecipe(CreateRecipeDTO createRecipe, RecipeItem recipe);
        bool DeleteRecipe(RecipeItem recipe);
        bool Save();
    }
}
