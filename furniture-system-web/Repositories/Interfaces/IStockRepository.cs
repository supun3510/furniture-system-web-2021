using furniture_system_web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace furniture_system_web.Repositories.Interfaces
{
    public interface IStockRepository
    {
        Task<string> UpdateStock(Stock model);
    }
}
