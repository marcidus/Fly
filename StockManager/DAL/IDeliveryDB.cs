using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public interface IDeliveryDB
    {
        Task<IEnumerable<Delivery>> GetAllDeliveries();
        Task<Delivery> GetDeliveryById(int id);
        Task<Delivery> AddDelivery(Delivery delivery);
        Task<Delivery> UpdateDelivery(Delivery delivery);
        Task<bool> DeleteDelivery(int id);
    }
}
