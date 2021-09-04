using furniture_system_web.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace furniture_system_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    return db.products.Where(x=>x.Status == true).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Product GetProductById(int id)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    return db.products.Where(x => x.Id == id).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        // POST api/<ProductController>
        [HttpPost]
        public bool SaveProduct(Product model)
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

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public bool UpdateProduct(Product model)
        {
            try
            {

                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var res = db.products.Where(x => x.Id == model.Id).FirstOrDefault();
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

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public bool DeleteProduct(int id)
        {
            try
            {

                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var res = db.products.Where(x => x.Id == id).FirstOrDefault();
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
