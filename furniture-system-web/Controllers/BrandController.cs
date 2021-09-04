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
    public class BrandController : ControllerBase
    {
        // GET: api/<BrandController>
        [HttpGet]
        public IEnumerable<Brand> GetBrands()
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    return db.brands.Where(x=>x.Status == true).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/<BrandController>/5
        [HttpGet("{id}")]
        public Brand GetBrandById(int id)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    return db.brands.Where(x => x.Id == id).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST api/<BrandController>
        [HttpPost]
        public bool SaveBrand(Brand model)
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

        // PUT api/<BrandController>/5
        [HttpPut("{id}")]
        public bool UpdateBrand(Brand model)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var res = db.brands.Where(x => x.Id == model.Id).FirstOrDefault();
                    res.Brand_Code = model.Brand_Code;
                    res.Brand_Name = model.Brand_Name;

                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        // DELETE api/<BrandController>/5
        [HttpDelete("{id}")]
        public bool DeleteBrand(int id)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var res = db.brands.Where(x => x.Id == id).FirstOrDefault();
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
