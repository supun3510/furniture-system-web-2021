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
    public class CategoryController : ControllerBase
    {
        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<Category> GetCategories()
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    return db.categories.Where(x=>x.Status == true).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public Category GetCategoryById(int id)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    return db.categories.Where(x => x.Id == id).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        // POST api/<CategoryController>
        [HttpPost]
        public bool SaveCategory(Category model)
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

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public bool UpdateCategory(Category model)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var res = db.categories.Where(x => x.Id == model.Id).FirstOrDefault();
                    res.Category_Code = model.Category_Code;
                    res.Category_Name = model.Category_Name;

                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public bool DeleteCategory(int id)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var res = db.categories.Where(x => x.Id == id).FirstOrDefault();
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
