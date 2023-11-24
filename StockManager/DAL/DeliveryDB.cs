using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DeliveryDB : IDeliveryDB
    {
        private readonly Context _context;

        public DeliveryDB(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Delivery>> GetAllDeliveries()
        {
            return await _context.Deliveries.ToListAsync();
        }

        public async Task<Delivery> GetDeliveryById(int id)
        {
            return await _context.Deliveries.FindAsync(id);
        }

        public async Task<Delivery> AddDelivery(Delivery delivery)
        {
            _context.Deliveries.Add(delivery);
            await _context.SaveChangesAsync();
            return delivery;
        }

        public async Task<Delivery> UpdateDelivery(Delivery delivery)
        {
            _context.Deliveries.Update(delivery);
            await _context.SaveChangesAsync();
            return delivery;
        }

        public async Task<bool> DeleteDelivery(int id)
        {
            var delivery = await _context.Deliveries.FindAsync(id);
            if (delivery == null)
            {
                return false;
            }

            _context.Deliveries.Remove(delivery);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}