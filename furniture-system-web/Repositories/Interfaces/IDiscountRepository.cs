using furniture_system_web.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace furniture_system_web.Repositories
{
    public interface IDiscountRepository
    {
        Task<bool> DeleteDiscount(int id);
        Task<Discount> GetDiscountById(int id);
        Task<IEnumerable<Discount>> GetDiscounts();
        Task<bool> SaveDiscount(Discount model);
        Task<bool> UpdateDiscount(Discount model);
    }
}