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
            //return _context.RecipeItems.Where(r => r.Title == title).ToList();
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
    }
}
