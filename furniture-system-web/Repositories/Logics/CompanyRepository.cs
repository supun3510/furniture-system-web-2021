using furniture_system_web.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace furniture_system_web.Repositories.Logics
{
    public class CompanyRepository : ICompanyRepository
    {
        public async Task<IEnumerable<Company>> GetCompanys()
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    return await db.companies.ToListAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Company> GetCompanyById(int id)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    return await db.companies.Where(x => x.Id == id).FirstOrDefaultAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> SaveCompany(Company model)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    db.companies.Add(model);
                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> UpdateCompany(Company model)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var res = await db.companies.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                    res.Company_Name = model.Company_Name;
                    model.Status = model.Status;
                    db.Entry(res).CurrentValues.SetValues(model);
                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> DeleteCompany(int id)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var res = await db.companies.Where(x => x.Id == id).FirstOrDefaultAsync();
                    res.Status = false;

                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
