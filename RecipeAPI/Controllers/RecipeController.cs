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
        private readonly IMapper _mapper;

        public RecipeController(IRecipeRepository recipeRepository,
            ICategoryRepository categoryRepository,
            IMapper mapper)
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

        // Create recipe        //[HttpPost]
        //[ProducesResponseType(204)]
        //[ProducesResponseType(400)]
        //public IActionResult CreateRecipe([FromQuery] int categoryId, [FromQuery] int ingredientId, [FromQuery] int amountTypeId, [FromQuery] int amount, [FromBody] RecipeDTO recipeCreate)
        //{
        //    if (recipeCreate == null)
        //        return BadRequest(ModelState);

        //    var recipe = _recipeRepository.GetRecipes()
        //        .Where(i => i.Title.Trim().ToUpper() == recipeCreate.Title.TrimEnd().ToUpper())
        //        .FirstOrDefault();

        //    if (recipe != null)
        //    {
        //        ModelState.AddModelError("", "Recipe already exists");
        //        return StatusCode(422, ModelState);
        //    }

        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var recipeMap = _mapper.Map<RecipeItem>(recipeCreate);



        //    if (!_recipeRepository.CreateRecipe(categoryId, ingredientId, amountTypeId, amount, recipeMap))
        //    {
        //        ModelState.AddModelError("", "Something went wrong while saving");
        //        return StatusCode(500, ModelState);
        //    }

        //    return Ok("Succesfully created Recipe");
        //}

        // Update Recipe
        //[HttpPut("{recipeId}")]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(204)]
        //[ProducesResponseType(404)]
        //public IActionResult UpdateRecipe(int recipeId, [FromBody] RecipeDTO updatedRecipe)
        //{
        //    if (updatedRecipe == null)
        //        return BadRequest(ModelState);

        //    if (recipeId != updatedRecipe.Id)
        //        return BadRequest(ModelState);

        //    if (!_recipeRepository.RecipeExists(recipeId))
        //        return NotFound();

        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var recipeMap = _mapper.Map<RecipeItem>(updatedRecipe);

        //    if (!_recipeRepository.UpdateRecipe(recipeMap))
        //    {
        //        ModelState.AddModelError("", "Something went wrong updating recipe");
        //        return StatusCode(500, ModelState);
        //    }
        //    return Ok("Succesfully updated recipe");
        //}

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

            var recipeDelete = _recipeRepository.GetRecipe(recipeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_recipeRepository.DeleteRecipe(recipeDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting recipe");
            }

            return Ok("Succesfully deleted recipe");
        }
    }
}
