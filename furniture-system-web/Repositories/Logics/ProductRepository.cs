using furniture_system_web.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace furniture_system_web.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public async Task<IEnumerable<Product>> GetProducts()
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    return await db.products.ToListAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Product> GetProductById(int id)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    return await db.products.Where(x => x.Id == id).FirstOrDefaultAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<bool> SaveProduct(Product model)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    db.products.Add(model);

                    Stock stock = new Stock();
                    stock.Item_Code = model.ItemCode;
                    stock.Quentity = 0;
                    stock.Status = true;

                    db.stocks.Add(stock);

                  await  db.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> UpdateProduct(Product model)
        {
            try
            {

                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var res = await db.products.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                    res.ItemCode = model.ItemCode;
                    res.ItemName = model.ItemName;
                    res.Brand_Id = model.Brand_Id;
                    res.Category_Id = model.Category_Id;
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

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {

                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var res = await db.products.Where(x => x.Id == id).FirstOrDefaultAsync();
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
