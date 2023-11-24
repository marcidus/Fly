using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ItemDB : IItemDB
    {
        private readonly Context _context;

        public ItemDB(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Item>> GetAllItems()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> GetItemById(int id)
        {
            return await _context.Items.FindAsync(id);
        }

        public async Task<Item> AddItem(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Item> UpdateItem(Item item)
        {
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteItem(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return false;
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
