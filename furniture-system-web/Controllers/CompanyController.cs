using furniture_system_web.Model;
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
    [Route("api/Company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepo;
        // GET: api/<CategoryController>
        private UserManager<ApplicationUser> _userManager;
        private readonly ApplicationSettings _appSettings;

        public CompanyController(UserManager<ApplicationUser> userManager, IOptions<ApplicationSettings> appSettings)
        {
            _companyRepo = new CompanyRepository();
            _appSettings = appSettings.Value;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("GetCompanies")]
        public async Task<IEnumerable<Company>> GetCompanies()
        {
            try
            {
                    return await _companyRepo.GetCompanys();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("GetCompanyById")]
        public async Task<Company> GetCompanyById(int id)
        {
            try
            {
                    return await _companyRepo.GetCompanyById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost]
        [Route("SaveCompany")]
        public async Task<bool> SaveCompany(Company model)
        {
            try
            {
                    return await _companyRepo.SaveCompany(model);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPut]
        [Route("UpdateCompany")]
        public async Task<bool> UpdateCompany(Company model)
        {
            try
            {

                    return await _companyRepo.UpdateCompany(model);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpDelete]
        [Route("DeleteCompany")]
        public async Task<bool> DeleteCompany(int id)
        {
            try
            {
                    return await _companyRepo.DeleteCompany(id);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
