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

        public ICollection<RecipeItem> GetRecipes()
        {
            return _context.RecipeItems.OrderBy(r => r.Id).ToList();
        }
    }
}
