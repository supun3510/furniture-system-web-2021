using furniture_system_web.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace furniture_system_web.Logics
{
    public class CategoryRepository : ICategoryRepository
    {
        public async Task<IEnumerable<Category>> GetCategories()
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    return await db.categories.Where(x => x.Status == true).ToListAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Category> GetCategoryById(int id)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    return await db.categories.Where(x => x.Id == id).FirstOrDefaultAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> SaveCategory(Category model)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    model.Status = true;
                    db.categories.Add(model);
                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> UpdateCategory(Category model)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var res = await db.categories.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                    res.Category_Code = model.Category_Code;
                    res.Category_Name = model.Category_Name;
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

        public async Task<bool> DeleteCategory(int id)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var res = await db.categories.Where(x => x.Id == id).FirstOrDefaultAsync();
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
