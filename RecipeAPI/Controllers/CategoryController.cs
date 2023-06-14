using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipeAPI.DTO;
using RecipeAPI.Interfaces;
using RecipeAPI.Models;

namespace RecipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        // Get al categories
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<CategoryItem>))]
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CategoryDTO>>(_categoryRepository.GetCategories());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(categories);
        }

        // Get categories by id
        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(CategoryItem))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int categoryId)
        {
            if (!_categoryRepository.CategoryExistst(categoryId))
                return NotFound();

            var category = _mapper.Map<CategoryDTO>(_categoryRepository.GetCategory(categoryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(category);
        }

        // Get recipes by category
        [HttpGet("Recipe/byCategoryId/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RecipeItem>))]
        [ProducesResponseType(400)]
        public IActionResult GetRecipeByCategory(int categoryId)
        {
            var recipes = _mapper.Map<List<RecipeDTO>>(
                _categoryRepository.GetRecipeByCategory(categoryId));

            if(!ModelState.IsValid)
                return BadRequest();

            return Ok(recipes);
        }

        // Get recipes by category
        [HttpGet("Recipe/byCategoryName/{categoryName}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RecipeItem>))]
        [ProducesResponseType(400)]
        public IActionResult GetRecipeByCategory(string categoryName)
        {
            var recipes = _mapper.Map<List<RecipeDTO>>(
                _categoryRepository.GetRecipeByCategory(categoryName));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(recipes);
        }
    }
}
