using furniture_system_web.Model;
using furniture_system_web.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace furniture_system_web.Controllers
{
    [Route("api/StockManage")]
    [ApiController]
    public class StockManageController : ControllerBase
    {
        // GET: api/<CategoryController>
        private readonly IProductRepository _productRepo;
        private UserManager<ApplicationUser> _userManager;
        private readonly ApplicationSettings _appSettings;

        public StockManageController(UserManager<ApplicationUser> userManager, IOptions<ApplicationSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    return await _productRepo.GetProducts();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
