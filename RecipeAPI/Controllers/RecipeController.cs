using Microsoft.AspNetCore.Mvc;
using RecipeAPI.Interfaces;
using RecipeAPI.Models;

namespace RecipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : Controller
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeController(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<RecipeItem>))]
        public IActionResult GetRecipes()
        {
            var recipes = _recipeRepository.GetRecipes();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(recipes); 
        }
    }
}
