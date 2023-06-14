using RecipeAPI.Data;
using RecipeAPI.Models;

namespace RecipeAPI
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            if(!dataContext.RecipeItems.Any())
            {
                var recipes = new List<RecipeItem>()
                {
                    new RecipeItem()
                    {
                        Title = "Pasta pesto met kip en tomaat",
                        Instructions = "lorem ipsum",
                        PrepTime = 15,
                        Picture = null,
                        Reviews = new List<ReviewItem>()
                        {
                            new ReviewItem()
                            {
                                Name = "Timo",
                                Comment = "Heel lekker",
                                Score = 8
                            }
                        },
                        RecipeIngredients = new List<RecipeIngredientItem>()
                        {
                            new RecipeIngredientItem()
                            {
                                Ingredient = new IngredientItem()
                                {
                                    Name = "Penne"
                                },
                                Amount = 300,
                                AmountType = new AmountTypeItem()
                                {
                                    Type = "gram"
                                }
                            }
                        },
                        RecipeCategories = new List<RecipeCategoryItem>()
                        {
                            new RecipeCategoryItem()
                            {
                                Category = new CategoryItem()
                                {
                                    Name = "Maaltijd"
                                }
                            }
                        }
                    }
                };
                dataContext.RecipeItems.AddRange(recipes);
                dataContext.SaveChanges();
            }
        }
    }
}
