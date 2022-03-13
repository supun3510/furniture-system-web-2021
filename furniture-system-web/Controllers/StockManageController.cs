using furniture_system_web.Model;
using furniture_system_web.Repositories;
using furniture_system_web.Repositories.Interfaces;
using furniture_system_web.Repositories.Logics;
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
        private readonly IStockRepository _stockRepo;
        private UserManager<ApplicationUser> _userManager;
        private readonly ApplicationSettings _appSettings;

        public StockManageController(UserManager<ApplicationUser> userManager, IOptions<ApplicationSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _userManager = userManager;
            _stockRepo = new StockRepository();
        }

        [HttpGet]
        [Route("GetStock")]
        public async Task<List<Stock>> GetStock()
        {
            try
            {
                    return await _stockRepo.GetStock();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("UpdateStock")]
        public async Task<string> UpdateStock(Stock stock)
        {
            try
            {

                    return await _stockRepo.UpdateStock(stock);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
