using RecipeAPI.Data;
using RecipeAPI.Interfaces;
using RecipeAPI.Models;

namespace RecipeAPI.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;

        public ReviewRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateReview(ReviewItem review)
        {
            _context.Add(review);
            return Save();
        }

        public bool DeleteReview(ReviewItem review)
        {
            _context.Remove(review);
            return Save();
        }

        public ReviewItem GetReview(int id)
        {
            return _context.ReviewItems.Where(r => r.Id == id).FirstOrDefault();
        }

        public ICollection<ReviewItem> GetReviews()
        {
            return _context.ReviewItems.OrderBy(r => r.Id).ToList();
        }

        public bool ReviewExists(int id)
        {
            return _context.ReviewItems.Any(r => r.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateReview(ReviewItem review)
        {
            _context.Update(review);
            return Save();
        }
    }
}
