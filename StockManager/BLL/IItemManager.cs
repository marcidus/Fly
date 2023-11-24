using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IItemManager
    {
        Task<IEnumerable<Item>> GetAllItems();
        Task<Item> GetItemById(int id);
        Task<Item> AddItem(Item item);
        Task<Item> UpdateItem(Item item);
        Task<bool> DeleteItem(int id);
    }
}
