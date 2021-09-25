using furniture_system_web.Model;
using furniture_system_web.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace furniture_system_web.Controllers
{
    [Route("api/Brand")]
    [ApiController]
    public class BrandController : ControllerBase
    {

        private readonly IBrandRepository _brandRepo;
        // GET: api/<CategoryController>
        private UserManager<ApplicationUser> _userManager;
        private readonly ApplicationSettings _appSettings;

        public BrandController(UserManager<ApplicationUser> userManager, IOptions<ApplicationSettings> appSettings)
        {
            _brandRepo = new BrandRepository();
            _appSettings = appSettings.Value;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("GetBrands")]
        public async Task<IEnumerable<Brand>> GetBrands()
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    return await _brandRepo.GetBrands();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("GetBrandById")]
        public async Task<Brand> GetBrandById(int id)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    return await _brandRepo.GetBrandById(id);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost]
        [Route("SaveBrand")]
        public async Task<bool> SaveBrand(Brand model)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    return await _brandRepo.SaveBrand(model);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        [Route("UpdateBrand")]
        public async Task<bool> UpdateBrand(Brand model)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {

                    return await _brandRepo.UpdateBrand(model);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        [Route("DeleteBrand")]
        public async Task<bool> DeleteBrand(int id)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {

                    return await _brandRepo.DeleteBrand(id);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
