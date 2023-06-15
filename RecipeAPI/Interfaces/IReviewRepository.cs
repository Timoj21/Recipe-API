using RecipeAPI.Models;

namespace RecipeAPI.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<ReviewItem> GetReviews();
        ICollection<ReviewItem> GetReviewsByRecipeId(int recipeId);
        ReviewItem GetReview(int id);
        bool ReviewExists(int id);
        bool CreateReview(ReviewItem review);
        bool UpdateReview(ReviewItem review);
        bool DeleteReview(ReviewItem review);
        bool DeleteReviews(List<ReviewItem> reviews);
        bool Save();
    }
}
