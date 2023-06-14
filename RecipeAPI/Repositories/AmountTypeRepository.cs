using RecipeAPI.Data;
using RecipeAPI.Interfaces;
using RecipeAPI.Models;

namespace RecipeAPI.Repositories
{
    public class AmountTypeRepository : IAmountTypeRepository
    {
        private readonly DataContext _context;

        public AmountTypeRepository(DataContext context)
        {
            _context = context;
        }

        public bool AmountTypeExists(int id)
        {
            return _context.AmountTypeItems.Any(r => r.Id == id);
        }

        public AmountTypeItem GetAmountType(int id)
        {
            return _context.AmountTypeItems.Where(r => r.Id == id).FirstOrDefault();
        }

        public AmountTypeItem GetAmountType(string type)
        {
            return _context.AmountTypeItems.Where(r => r.Type == type).FirstOrDefault();
        }

        public ICollection<AmountTypeItem> GetAmountTypes()
        {
            return _context.AmountTypeItems.OrderBy(a => a.Id).ToList();
        }

        
    }
}
