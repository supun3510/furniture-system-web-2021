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
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private UserManager<ApplicationUser> _userManager;
        private readonly ApplicationSettings _appSettings;

        public ProductController(UserManager<ApplicationUser> userManager, IOptions<ApplicationSettings> appSettings)
        {
            _productRepo = new ProductRepository();
            _appSettings = appSettings.Value;
            _userManager = userManager;
        }
        [HttpGet]
        [Route("GetProducts")]
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

        [HttpGet]
        [Route("GetProductById")]
        public async Task<Product> GetProductById(int id)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    return await _productRepo.GetProductById(id);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        [Route("SaveProduct")]
        public async Task<bool> SaveProduct(Product model)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    return await _productRepo.SaveProduct(model);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        [Route("UpdateProduct")]
        public async Task<bool> UpdateProduct(Product model)
        {
            try
            {

                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    return await _productRepo.UpdateProduct(model);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("DeleteProduct")]
        public async Task<bool> DeleteProduct(int id)
        {
            try
            {

                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    return await _productRepo.DeleteProduct(id);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
