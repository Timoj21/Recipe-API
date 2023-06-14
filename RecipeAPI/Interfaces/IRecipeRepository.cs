using RecipeAPI.Models;

namespace RecipeAPI.Interfaces
{
    public interface IRecipeRepository
    {
        ICollection<RecipeItem> GetRecipes();
    }
}
