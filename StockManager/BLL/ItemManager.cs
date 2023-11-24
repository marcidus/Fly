using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ItemManager : IItemManager
    {
        private readonly IItemDB _itemRepository;

        public ItemManager(IItemDB itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<IEnumerable<Item>> GetAllItems()
        {
            return await _itemRepository.GetAllItems();
        }

        public async Task<Item> GetItemById(int id)
        {
            return await _itemRepository.GetItemById(id);
        }

        public async Task<Item> AddItem(Item item)
        {
            return await _itemRepository.AddItem(item);
        }

        public async Task<Item> UpdateItem(Item item)
        {
            return await _itemRepository.UpdateItem(item);
        }

        public async Task<bool> DeleteItem(int id)
        {
            return await _itemRepository.DeleteItem(id);
        }
    }
}
