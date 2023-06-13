using Microsoft.EntityFrameworkCore;

namespace RecipeAPI.Models
{
    public class AmountTypeContext : DbContext
    {
        public AmountTypeContext(DbContextOptions<AmountTypeContext> options)
            : base(options)
        {
        }

        public DbSet<AmountTypeItem> AmountTypeItems { get; set; } = null!;
    }
}
