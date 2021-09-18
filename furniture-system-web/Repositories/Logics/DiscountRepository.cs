using furniture_system_web.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace furniture_system_web.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        public async Task<IEnumerable<Discount>> GetDiscounts()
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    return await db.discounts.Where(x => x.Status == true).ToListAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Discount> GetDiscountById(int id)
        {
            try
            {

                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    return await db.discounts.Where(x => x.Id == id).FirstOrDefaultAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> SaveDiscount(Discount model)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    model.Status = true;
                    db.discounts.Add(model);
                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<bool> UpdateDiscount(Discount model)
        {
            try
            {

                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var res = await db.discounts.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                    res.Discount_Code = model.Discount_Code;
                    res.Discount_Name = model.Discount_Name;

                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteDiscount(int id)
        {
            try
            {

                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var res = await db.discounts.Where(x => x.Id == id).FirstOrDefaultAsync();
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
