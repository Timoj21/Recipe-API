namespace RecipeAPI.DTO
{
    public class RecipeDTO
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Instructions { get; set; }
        public int? PrepTime { get; set; }
        public byte[]? Picture { get; set; }
    }
}
