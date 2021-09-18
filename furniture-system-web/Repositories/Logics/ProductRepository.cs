﻿using furniture_system_web.Model;
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
                    return await db.products.Where(x => x.Status == true).ToListAsync();
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
                    model.Status = true;
                    db.products.Add(model);
                    db.SaveChanges();

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