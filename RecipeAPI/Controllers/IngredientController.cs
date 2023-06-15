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
    public class IngredientController : Controller
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;
        public IngredientController(IIngredientRepository ingredientRepository, IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }

        // Get al ingredients
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<IngredientItem>))]
        public IActionResult GetAmountTypes()
        {
            var ingredients = _mapper.Map<List<IngredientDTO>>(_ingredientRepository.GetIngredients());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(ingredients);
        }

        // Get ingredients by id
        [HttpGet("{ingredientId}")]
        [ProducesResponseType(200, Type = typeof(IngredientItem))]
        [ProducesResponseType(400)]
        public IActionResult GetAmountType(int ingredientId)
        {
            if (!_ingredientRepository.IngredientExists(ingredientId))
                return NotFound();

            var ingredient = _mapper.Map<IngredientDTO>(_ingredientRepository.GetIngredient(ingredientId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(ingredient);
        }

        // Create ingredient
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateIngredient([FromBody] IngredientDTO ingredientCreate)
        {
            if (ingredientCreate == null)
                return BadRequest(ModelState);

            var ingredient = _ingredientRepository.GetIngredients()
                .Where(i => i.Name.Trim().ToUpper() == ingredientCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (ingredient != null)
            {
                ModelState.AddModelError("", "Ingredient already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ingredientMap = _mapper.Map<IngredientItem>(ingredientCreate);

            if (!_ingredientRepository.CreateIngredient(ingredientMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully created Ingredient");
        }
    }
}
