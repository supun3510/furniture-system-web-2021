using furniture_system_web.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace furniture_system_web.Repositories
{
    public interface IBrandRepository
    {
        Task<bool> DeleteBrand(int id);
        Task<Brand> GetBrandById(int id);
        Task<IEnumerable<Brand>> GetBrands();
        Task<bool> SaveBrand(Brand model);
        Task<bool> UpdateBrand(Brand model);
    }
}