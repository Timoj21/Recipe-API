using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipeAPI.DTO;
using RecipeAPI.Interfaces;
using RecipeAPI.Models;

namespace RecipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : Controller
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;

        public RecipeController(IRecipeRepository recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        // Get all recipes
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<RecipeItem>))]
        public IActionResult GetRecipes()
        {
            var recipes = _mapper.Map<List<RecipeDTO>>(_recipeRepository.GetRecipes());

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(recipes); 
        }

        // Get recipe by id
        [HttpGet("{recipeId}")]
        [ProducesResponseType(200, Type=typeof(RecipeItem))]
        [ProducesResponseType(400)]
        public IActionResult GetRecipe(int recipeId)
        {
            if(!_recipeRepository.RecipeExists(recipeId))
                return NotFound();

            var recipe = _mapper.Map<RecipeDTO>(_recipeRepository.GetRecipe(recipeId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(recipe);
        }

        [HttpGet("byTitle/{title}")]
        [ProducesResponseType(200, Type = typeof(ICollection<RecipeItem>))]
        [ProducesResponseType(400)]
        public IActionResult GetRecipesByTitle(string title)
        {
            var recipes = _mapper.Map<List<RecipeDTO>>(_recipeRepository.GetRecipesByTitle(title));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(recipes);
        }

        // Get recipes by prep time
        [HttpGet("byPrepTime/{prepTime}")]
        [ProducesResponseType(200, Type = typeof(ICollection<RecipeItem>))]
        [ProducesResponseType(400)]
        public IActionResult GetRecipesPrepTime(int prepTime)
        {
            var recipes = _mapper.Map<RecipeDTO>(_recipeRepository.GetRecipesByPrepTime(prepTime));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(recipes);
        }
    }
}
