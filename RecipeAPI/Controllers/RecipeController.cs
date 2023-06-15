using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipeAPI.DTO;
using RecipeAPI.Interfaces;
using RecipeAPI.Models;
using RecipeAPI.Repositories;

namespace RecipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : Controller
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public RecipeController(IRecipeRepository recipeRepository,
            ICategoryRepository categoryRepository,
            IReviewRepository reviewRepository,
            IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _reviewRepository = reviewRepository;
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

       //Create recipe
       [HttpPost]
       [ProducesResponseType(204)]
       [ProducesResponseType(400)]
        public IActionResult CreateRecipe([FromBody] CreateRecipeDTO recipeCreate)
        {
            if (recipeCreate == null)
                return BadRequest(ModelState);

            var recipe = _recipeRepository.GetRecipes()
                .Where(i => i.Title.Trim().ToUpper() == recipeCreate.recipe.Title.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (recipe != null)
            {
                ModelState.AddModelError("", "Recipe already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var recipeMap = _mapper.Map<RecipeItem>(recipeCreate.recipe);



            if (!_recipeRepository.CreateRecipe(recipeCreate, recipeMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully created Recipe");
        }

        // Update Recipe
        [HttpPut("{recipeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateRecipe(int recipeId, [FromBody] CreateRecipeDTO updatedRecipe)
        {
            if (updatedRecipe == null)
                return BadRequest(ModelState);

            if (recipeId != updatedRecipe.recipe.Id)
                return BadRequest(ModelState);

            if (!_recipeRepository.RecipeExists(recipeId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var recipeMap = _mapper.Map<RecipeItem>(updatedRecipe.recipe);

            if (!_recipeRepository.UpdateRecipe(updatedRecipe, recipeMap))
            {
                ModelState.AddModelError("", "Something went wrong updating recipe");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfully updated recipe");
        }

        // Delete Recipe
        [HttpDelete("{recipeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteRecipe(int recipeId)
        {
            if (!_recipeRepository.RecipeExists(recipeId))
            {
                return NotFound();
            }

            var reviewsDelete = _reviewRepository.GetReviewsByRecipeId(recipeId);
            var recipeDelete = _recipeRepository.GetRecipe(recipeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_reviewRepository.DeleteReviews(reviewsDelete.ToList()))
            {
                ModelState.AddModelError("", "Something went wrong deleting reviews");
            }

            if (!_recipeRepository.DeleteRecipe(recipeDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting recipe");
            }

            return Ok("Succesfully deleted recipe");
        }
    }
}
