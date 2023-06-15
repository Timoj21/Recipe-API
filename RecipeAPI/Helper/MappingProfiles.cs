using AutoMapper;
using RecipeAPI.DTO;
using RecipeAPI.Models;

namespace RecipeAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<RecipeItem, RecipeDTO>();
            CreateMap<RecipeDTO, RecipeItem>();
            CreateMap<CreateRecipeDTO, RecipeItem>();
            CreateMap<AmountTypeItem, AmountTypeDTO>();
            CreateMap<AmountTypeDTO, AmountTypeItem>();
            CreateMap<CategoryItem, CategoryDTO>();
            CreateMap<CategoryDTO, CategoryItem>();
            CreateMap<IngredientItem, IngredientDTO>();
            CreateMap<IngredientDTO, IngredientItem>();
            CreateMap<ReviewItem, ReviewDTO>();
            CreateMap<ReviewDTO, ReviewItem>();
        }
    }
}
