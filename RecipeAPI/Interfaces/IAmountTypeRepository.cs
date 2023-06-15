using RecipeAPI.Models;

namespace RecipeAPI.Interfaces
{
    public interface IAmountTypeRepository
    {
        ICollection<AmountTypeItem> GetAmountTypes();
        AmountTypeItem GetAmountType(int id);
        //AmountTypeItem GetAmountType(string type);
        bool AmountTypeExists(int id);
        bool CreateAmountType(AmountTypeItem amountType);
        bool UpdateAmountType(AmountTypeItem amountType);
        bool DeleteAmountType(AmountTypeItem amountType);
        bool Save();

    }
}
