using furniture_system_web.Model;
using furniture_system_web.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace furniture_system_web.Repositories.Logics
{
    public class StockRepository : IStockRepository
    {
        public async Task<string> UpdateStock(Stock model)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var _exists = await db.stocks.Where(x => x.Item_Code == model.Item_Code).FirstOrDefaultAsync();

                    model.Quentity = _exists.Quentity;
                    db.Entry(_exists).CurrentValues.SetValues(model);
                    await  db.SaveChangesAsync();

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
