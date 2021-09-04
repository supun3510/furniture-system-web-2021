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
    public class DiscountController : ControllerBase
    {
        // GET: api/<DiscountController>
        [HttpGet]
        public IEnumerable<Discount> GetCategories()
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    return db.discounts.Where(x=>x.Status == true).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/<DiscountController>/5
        [HttpGet("{id}")]
        public Discount GetDiscountById(int id)
        {
            try
            {

                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    return db.discounts.Where(x => x.Id == id).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST api/<DiscountController>
        [HttpPost]
        public bool SaveDiscount(Discount model)
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

        // PUT api/<DiscountController>/5
        [HttpPut("{id}")]
        public bool UpdateDiscount(Discount model)
        {
            try
            {

                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var res = db.discounts.Where(x => x.Id == model.Id).FirstOrDefault();
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

        // DELETE api/<DiscountController>/5
        [HttpDelete("{id}")]
        public bool DeleteDiscount(int id)
        {
            try
            {

                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var res = db.discounts.Where(x => x.Id == id).FirstOrDefault();
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
