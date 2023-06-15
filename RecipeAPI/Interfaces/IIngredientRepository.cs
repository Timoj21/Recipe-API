using RecipeAPI.Models;

namespace RecipeAPI.Interfaces
{
    public interface IIngredientRepository
    {
        ICollection<IngredientItem> GetIngredients();
        IngredientItem GetIngredient(int id);
        IngredientItem GetIngredient(string name);
        bool IngredientExists(int id);
        bool CreateIngredient(IngredientItem ingredient);
        bool UpdateIngredient(IngredientItem ingredient);
        bool DeleteIngredient(IngredientItem ingredient);
        bool Save();
    }
}
