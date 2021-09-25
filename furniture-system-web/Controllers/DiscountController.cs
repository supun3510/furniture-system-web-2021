using furniture_system_web.Model;
using furniture_system_web.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace furniture_system_web.Controllers
{
    [Route("api/Discount")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountRepository _discountRepo;
        private UserManager<ApplicationUser> _userManager;
        private readonly ApplicationSettings _appSettings;

        public DiscountController(UserManager<ApplicationUser> userManager, IOptions<ApplicationSettings> appSettings)
        {
            _discountRepo = new DiscountRepository();
            _appSettings = appSettings.Value;
            _userManager = userManager;
        }
        [HttpGet]
        [Route("GetDiscounts")]
        public async Task<IEnumerable<Discount>> GetDiscounts()
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    return await _discountRepo.GetDiscounts();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("GetDiscountById")]
        public async Task<Discount> GetDiscountById(int id)
        {
            try
            {

                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    return await _discountRepo.GetDiscountById(id);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("SaveDiscount")]
        public async Task<bool> SaveDiscount(Discount model)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {

                    return await _discountRepo.SaveDiscount(model);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        
        [HttpPost]
        [Route("UpdateDiscount")]
        public async Task<bool> UpdateDiscount(Discount model)
        {
            try
            {

                using (ApplicationDbContext db = new ApplicationDbContext())
                {

                    return await _discountRepo.UpdateDiscount(model);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("DeleteDiscount")]
        public async Task<bool> DeleteDiscount(int id)
        {
            try
            {

                using (ApplicationDbContext db = new ApplicationDbContext())
                {

                    return await _discountRepo.DeleteDiscount(id);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
