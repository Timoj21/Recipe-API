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

        public bool CreateAmountType(AmountTypeItem amountType)
        {
            _context.Add(amountType);
            return Save();
        }

        public bool DeleteAmountType(AmountTypeItem amountType)
        {
            _context.Remove(amountType);
            return Save();
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

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateAmountType(AmountTypeItem amountType)
        {
            _context.Update(amountType);
            return Save();
        }
    }
}
