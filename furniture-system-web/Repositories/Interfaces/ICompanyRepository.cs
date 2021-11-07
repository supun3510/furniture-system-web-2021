using furniture_system_web.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace furniture_system_web.Repositories.Logics
{
    public interface ICompanyRepository
    {
        Task<bool> DeleteCompany(int id);
        Task<Company> GetCompanyById(int id);
        Task<IEnumerable<Company>> GetCompanys();
        Task<bool> SaveCompany(Company model);
        Task<bool> UpdateCompany(Company model);
    }
}