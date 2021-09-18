using furniture_system_web.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace furniture_system_web.Repositories
{
    public interface IProductRepository
    {
        Task<bool> DeleteProduct(int id);
        Task<Product> GetProductById(int id);
        Task<IEnumerable<Product>> GetProducts();
        Task<bool> SaveProduct(Product model);
        Task<bool> UpdateProduct(Product model);
    }
}