using RecipeAPI.Data;
using RecipeAPI.Interfaces;
using RecipeAPI.Models;

namespace RecipeAPI.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly DataContext _context;

        public IngredientRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateIngredient(IngredientItem ingredient)
        {
            _context.Add(ingredient);
            return Save();
        }

        public IngredientItem GetIngredient(int id)
        {
            return _context.IngredientItems.Where(i => i.Id == id).FirstOrDefault();
        }

        public IngredientItem GetIngredient(string name)
        {
            return _context.IngredientItems.Where(i => i.Name == name).FirstOrDefault();
        }

        public ICollection<IngredientItem> GetIngredients()
        {
            return _context.IngredientItems.OrderBy(i => i.Id).ToList();
        }

        public bool IngredientExists(int id)
        {
            return _context.IngredientItems.Any(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateIngredient(IngredientItem ingredient)
        {
            _context.Update(ingredient);
            return Save();
        }
    }
}
