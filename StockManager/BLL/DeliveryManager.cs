using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DeliveryManager : IDeliveryManager
    {
        private readonly IDeliveryDB _deliveryRepository;

        public DeliveryManager(IDeliveryDB deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }

        public async Task<IEnumerable<Delivery>> GetAllDeliveries()
        {
            return await _deliveryRepository.GetAllDeliveries();
        }

        public async Task<Delivery> GetDeliveryById(int id)
        {
            return await _deliveryRepository.GetDeliveryById(id);
        }

        public async Task<Delivery> AddDelivery(Delivery delivery)
        {
            return await _deliveryRepository.AddDelivery(delivery);
        }

        public async Task<Delivery> UpdateDelivery(Delivery delivery)
        {
            return await _deliveryRepository.UpdateDelivery(delivery);
        }

        public async Task<bool> DeleteDelivery(int id)
        {
            return await _deliveryRepository.DeleteDelivery(id);
        }
    }
}
