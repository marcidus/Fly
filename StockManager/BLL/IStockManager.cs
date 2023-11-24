using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IStockManager
    {
        Task<IEnumerable<Stock>> GetAllStocks();
        Task<Stock> GetStockById(int id);
        Task<Stock> AddStock(Stock stock);
        Task<Stock> UpdateStock(Stock stock);
        Task<bool> DeleteStock(int id);
    }
}
