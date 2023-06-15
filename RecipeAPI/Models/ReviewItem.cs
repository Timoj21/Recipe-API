namespace RecipeAPI.Models
{
    public class ReviewItem
    {
        public int Id { get; set; }
        //public int RecipeId { get; set; }
        public RecipeItem Recipe { get; set; } = null!;
        public string? Name { get; set; }
        public string? Comment { get; set; }
        public int? Score { get; set; }
    }
}
