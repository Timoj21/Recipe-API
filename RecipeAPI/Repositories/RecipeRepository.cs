using Microsoft.EntityFrameworkCore;
using RecipeAPI.Data;
using RecipeAPI.Interfaces;
using RecipeAPI.Models;

namespace RecipeAPI.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly DataContext _context;

        public RecipeRepository(DataContext context) 
        {
            _context = context;
        }

        public RecipeItem GetRecipe(int id)
        {
            return _context.RecipeItems.Where(r => r.Id == id).FirstOrDefault();
        }

        public ICollection<RecipeItem> GetRecipesByTitle(string title)
        {
            return _context.RecipeItems.Where(r => r.Title.Contains(title)).ToList();
        }

        public ICollection<RecipeItem> GetRecipes()
        {
            return _context.RecipeItems.OrderBy(r => r.Id).ToList();
        }

        public ICollection<RecipeItem> GetRecipesByPrepTime(int time)
        {
            return _context.RecipeItems.Where(r => r.PrepTime <= time).ToList();
        }

        public bool RecipeExists(int id)
        {
            return _context.RecipeItems.Any(r => r.Id == id);
        }

        public bool CreateRecipe(int categoryId, int ingredientId, int amountTypeId, int amount, RecipeItem recipe)
        {
            var recipeCategoryEntity = _context.CategoryItems.Where(c => c.Id == categoryId).FirstOrDefault();
            var recipeIngredientEntity = _context.IngredientItems.Where(i => i.Id == ingredientId).FirstOrDefault();
            var amountTypeEntity = _context.AmountTypeItems.Where(a => a.Id == amountTypeId).FirstOrDefault();

            var recipeCategory = new RecipeCategoryItem()
            {
                Recipe = recipe,
                Category = recipeCategoryEntity
            };
            _context.Add(recipeCategory);

            var recipeIngredient = new RecipeIngredientItem()
            {
                Recipe = recipe,
                Ingredient = recipeIngredientEntity,
                Amount = amount,
                AmountType = amountTypeEntity
            };
            _context.Add(recipeIngredient);

            _context.Add(recipe);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateRecipe(int categoryId, int ingredientId, int amountTypeId, int amount, RecipeItem recipe)
        {
            _context.Update(recipe);
            return Save();
        }

        public bool DeleteRecipe(RecipeItem recipe)
        {
            _context.Remove(recipe);
            return Save();
        }
    }
}
