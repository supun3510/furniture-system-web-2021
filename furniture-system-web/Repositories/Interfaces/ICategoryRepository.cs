using furniture_system_web.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace furniture_system_web.Logics
{
    public interface ICategoryRepository
    {
        Task<bool> DeleteCategory(int id);
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategoryById(int id);
        Task<bool> SaveCategory(Category model);
        Task<bool> UpdateCategory(Category model);
    }
}