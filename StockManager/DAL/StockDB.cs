using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StockDB : IStockDB
    {
        private readonly Context _context;

        public StockDB(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Stock>> GetAllStocks()
        {
            return await _context.Stocks.ToListAsync();
        }

        public async Task<Stock> GetStockById(int id)
        {
            return await _context.Stocks.FindAsync(id);
        }

        public async Task<Stock> AddStock(Stock stock)
        {
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<Stock> UpdateStock(Stock stock)
        {
            _context.Stocks.Update(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<bool> DeleteStock(int id)
        {
            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null) return false;

            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
