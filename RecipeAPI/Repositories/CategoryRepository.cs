using RecipeAPI.Data;
using RecipeAPI.Interfaces;
using RecipeAPI.Models;

namespace RecipeAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public bool CategoryExists(string name)
        {
            return _context.CategoryItems.Any(c => c.Name == name);
        }

        public bool CategoryExistst(int id)
        {
            return _context.CategoryItems.Any(c => c.Id == id);
        }

        public bool CreateCategory(CategoryItem categoryItem)
        {
            _context.Add(categoryItem);
            return Save();
        }

        public bool DeleteCategory(CategoryItem categoryItem)
        {
            _context.Remove(categoryItem);
            return Save();
        }

        public ICollection<CategoryItem> GetCategories()
        {
            return _context.CategoryItems.OrderBy(c => c.Id).ToList();
        }

        public CategoryItem GetCategory(int id)
        {
            return _context.CategoryItems.Where(c => c.Id == id).FirstOrDefault();
        }

        public CategoryItem GetCategory(string name)
        {
            return _context.CategoryItems.Where(c => c.Name == name).FirstOrDefault();
        }

        public ICollection<RecipeItem> GetRecipeByCategory(int categoryId)
        {
            return _context.RecipeCategoryItems.Where(rc => rc.CategoryId == categoryId).Select(rc => rc.Recipe).ToList();
        }

        public ICollection<RecipeItem> GetRecipeByCategory(string categoryName)
        {
            return _context.RecipeCategoryItems.Where(rc => rc.Category.Name == categoryName).Select(rc => rc.Recipe).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCategory(CategoryItem categoryItem)
        {
            _context.Update(categoryItem);
            return Save();
        }
    }
}
