using furniture_system_web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace furniture_system_web.Repositories.Logics
{
    public class ProductionRepository : IProductionRepository
    {
        public async Task<string> SaveBill(Production model)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    db.productions.Add(model);
                    await db.SaveChangesAsync();

                    return "Updated";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
