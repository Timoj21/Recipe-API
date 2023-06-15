using RecipeAPI.Models;

namespace RecipeAPI.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<CategoryItem> GetCategories();
        CategoryItem GetCategory(int id);
        CategoryItem GetCategory(string name);
        ICollection<RecipeItem> GetRecipeByCategory(int categoryId);
        ICollection<RecipeItem> GetRecipeByCategory(string categoryName);
        bool CategoryExists(int id);
        //bool CategoryExists(string name);
        bool CreateCategory(CategoryItem categoryItem);
        bool UpdateCategory(CategoryItem categoryItem);
        bool DeleteCategory(CategoryItem categoryItem);
        bool Save();
    }
}
