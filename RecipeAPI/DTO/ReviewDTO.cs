using RecipeAPI.Models;

namespace RecipeAPI.DTO
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Comment { get; set; }
        public int? Score { get; set; }
    }
}
