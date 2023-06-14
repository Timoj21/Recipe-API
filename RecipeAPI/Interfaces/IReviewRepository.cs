using RecipeAPI.Models;

namespace RecipeAPI.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<ReviewItem> GetReviews();
        ReviewItem GetReview(int id);
        bool ReviewExists(int id);

    }
}
