﻿using RecipeAPI.Models;

namespace RecipeAPI.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<CategoryItem> GetCategories();
        CategoryItem GetCategory(int id);
        CategoryItem GetCategory(string name);
        ICollection<RecipeItem> GetRecipeByCategory(int categoryId);
        ICollection<RecipeItem> GetRecipeByCategory(string categoryName);
        bool CategoryExistst(int id);
        bool CategoryExists(string name);
    }
}
