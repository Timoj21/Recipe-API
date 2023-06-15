using Microsoft.EntityFrameworkCore;
using RecipeAPI.Data;
using RecipeAPI.DTO;
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

        public bool CreateRecipe(CreateRecipeDTO createRecipe, RecipeItem recipe)
        {
            foreach (int categoryId in createRecipe.RecipeCategories)
            {
                var recipeCategory = _context.CategoryItems.Where(c => c.Id == categoryId).FirstOrDefault();

                var rCategory = new RecipeCategoryItem()
                {
                    Recipe = recipe,
                    Category = recipeCategory
                };
                _context.Add(rCategory);
            }

            foreach (CreateIngredientItem ingredientItem in createRecipe.createIngredientItems)
            {
                var recipeIngredient = _context.IngredientItems.Where(c => c.Id == ingredientItem.ingredientId).FirstOrDefault();
                var recipeAmountType = _context.AmountTypeItems.Where(c => c.Id == ingredientItem.amountTypeId).FirstOrDefault();

                var rIngredient = new RecipeIngredientItem()
                {
                    Recipe = recipe,
                    Ingredient = recipeIngredient,
                    Amount = ingredientItem.amount,
                    AmountType = recipeAmountType
                };
                _context.Add(rIngredient);
            }
            _context.Add(recipe);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateRecipe(CreateRecipeDTO createRecipe, RecipeItem recipe)
        {
            var recipeCategories = _context.RecipeCategoryItems.Where(rc => rc.RecipeId == recipe.Id).ToList();
            _context.RemoveRange(recipeCategories);
            
            

            var recipeIngredients = _context.RecipeCategoryItems.Where(ri => ri.RecipeId == recipe.Id).ToList();
            _context.RemoveRange(recipeIngredients);
            _context.SaveChanges();
            if (recipeIngredients.Any())
            {
                Console.WriteLine("hier dan");
                return Save();
            } else
            {
                Console.WriteLine("hier nie");
            }

            foreach (int categoryId in createRecipe.RecipeCategories)
            {
                var recipeCategory = _context.CategoryItems.Where(c => c.Id == categoryId).FirstOrDefault();

                var rCategory = new RecipeCategoryItem()
                {
                    Recipe = recipe,
                    Category = recipeCategory
                };
                _context.Add(rCategory);
            }

            foreach (CreateIngredientItem ingredientItem in createRecipe.createIngredientItems)
            {
                var recipeIngredient = _context.IngredientItems.Where(c => c.Id == ingredientItem.ingredientId).FirstOrDefault();
                var recipeAmountType = _context.AmountTypeItems.Where(c => c.Id == ingredientItem.amountTypeId).FirstOrDefault();

                var rIngredient = new RecipeIngredientItem()
                {
                    Recipe = recipe,
                    Ingredient = recipeIngredient,
                    Amount = ingredientItem.amount,
                    AmountType = recipeAmountType
                };
                _context.Add(rIngredient);
            }

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
