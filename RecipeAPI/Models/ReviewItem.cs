namespace RecipeAPI.Models
{
    public class ReviewItem
    {
        public long Id { get; set; }
        public long RecipeId { get; set; }
        public RecipeItem Recipe { get; set; } = null!;
        public string? Name { get; set; }
        public string? Comment { get; set; }
        public required int score { get; set; }
    }
}
