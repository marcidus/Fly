using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StockManager : IStockManager
    {
        private readonly IStockDB _stockRepository;

        public StockManager(IStockDB stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<IEnumerable<Stock>> GetAllStocks()
        {
            return await _stockRepository.GetAllStocks();
        }

        public async Task<Stock> GetStockById(int id)
        {
            return await _stockRepository.GetStockById(id);
        }

        public async Task<Stock> AddStock(Stock stock)
        {
            return await _stockRepository.AddStock(stock);
        }

        public async Task<Stock> UpdateStock(Stock stock)
        {
            return await _stockRepository.UpdateStock(stock);
        }

        public async Task<bool> DeleteStock(int id)
        {
            return await _stockRepository.DeleteStock(id);
        }
    }
}
