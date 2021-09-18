using furniture_system_web.Logics;
using furniture_system_web.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace furniture_system_web.Controllers
{

    [Route("api/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;
        private UserManager<ApplicationUser> _userManager;
        private readonly ApplicationSettings _appSettings;

        public CategoryController(UserManager<ApplicationUser> userManager, IOptions<ApplicationSettings> appSettings)
        {
            _categoryRepo = new CategoryRepository();
            _appSettings = appSettings.Value;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    return await _categoryRepo.GetCategories();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<Category> GetCategoryById(int id)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    return await _categoryRepo.GetCategoryById(id);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public async Task<bool> SaveCategory(Category model)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {

                    return await _categoryRepo.SaveCategory(model);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public async Task<bool> UpdateCategory(Category model)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {

                    return await _categoryRepo.UpdateCategory(model);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public async Task<bool> DeleteCategory(int id)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {

                    return await _categoryRepo.DeleteCategory(id);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
