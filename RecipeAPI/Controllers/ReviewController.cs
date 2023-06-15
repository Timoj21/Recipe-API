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
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;
        public ReviewController(IReviewRepository reviewRepository, IRecipeRepository recipeRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        // Get al reviews
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<ReviewItem>))]
        public IActionResult GetReviews()
        {
            var reviews = _mapper.Map<List<ReviewDTO>>(_reviewRepository.GetReviews());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(reviews);
        }

        // Get reviews by id
        [HttpGet("{reviewId}")]
        [ProducesResponseType(200, Type = typeof(ReviewItem))]
        [ProducesResponseType(400)]
        public IActionResult GetReview(int reviewId)
        {
            if (!_reviewRepository.ReviewExists(reviewId))
                return NotFound();

            var review = _mapper.Map<ReviewDTO>(_reviewRepository.GetReview(reviewId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(review);
        }

        // Create review
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateReview([FromQuery] int recipeId, [FromBody] ReviewDTO reviewCreate)
        {
            if (reviewCreate == null)
                return BadRequest(ModelState);

            var review = _reviewRepository.GetReviews()
                .Where(r => r.Name.Trim().ToUpper() == reviewCreate.Name.TrimEnd().ToUpper()
                && r.RecipeId == recipeId)
                .FirstOrDefault();

            if (review != null)
            {
                ModelState.AddModelError("", "Review already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reviewMap = _mapper.Map<ReviewItem>(reviewCreate);

            reviewMap.Recipe = _recipeRepository.GetRecipe(recipeId);

            if (!_reviewRepository.CreateReview(reviewMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully created Review");
        }

        // Update Review
        [HttpPut("{reviewId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateAmountType(int reviewId, [FromBody] ReviewDTO updatedReview)
        {
            if (updatedReview == null)
                return BadRequest(ModelState);

            if (reviewId != updatedReview.Id)
                return BadRequest(ModelState);

            if (!_reviewRepository.ReviewExists(reviewId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reviewMap = _mapper.Map<ReviewItem>(updatedReview);

            if (!_reviewRepository.UpdateReview(reviewMap))
            {
                ModelState.AddModelError("", "Something went wrong updating review");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfully updated review");
        }

        // Delete Review
        [HttpDelete("{reviewId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteReview(int reviewId)
        {
            if (!_reviewRepository.ReviewExists(reviewId))
            {
                return NotFound();
            }

            var reviewDelete = _reviewRepository.GetReview(reviewId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_reviewRepository.DeleteReview(reviewDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting review");
            }

            return Ok("Succesfully deleted review");
        }
    }
}
