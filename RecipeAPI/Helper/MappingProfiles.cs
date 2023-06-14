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
            CreateMap<AmountTypeItem, AmountTypeDTO>();
            CreateMap<CategoryItem, CategoryDTO>();
            CreateMap<IngredientItem, IngredientDTO>();
            CreateMap<ReviewItem, ReviewDTO>();
        }
    }
}
