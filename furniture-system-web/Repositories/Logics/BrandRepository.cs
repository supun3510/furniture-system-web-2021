using furniture_system_web.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace furniture_system_web.Repositories
{
    public class BrandRepository : IBrandRepository
    {

        public async Task<IEnumerable<Brand>> GetBrands()
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    return await db.brands.Where(x => x.Status == true).ToListAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Brand> GetBrandById(int id)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    return await db.brands.Where(x => x.Id == id).FirstOrDefaultAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> SaveBrand(Brand model)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    model.Status = true;
                    db.brands.Add(model);
                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> UpdateBrand(Brand model)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var res = await db.brands.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                    res.Brand_Code = model.Brand_Code;
                    res.Brand_Name = model.Brand_Name;
                    res.Status = model.Status;
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

        public async Task<bool> DeleteBrand(int id)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var res = await db.brands.Where(x => x.Id == id).FirstOrDefaultAsync();
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
