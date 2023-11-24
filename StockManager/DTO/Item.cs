using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Item
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public DateTime CreatedAt { get; set; }
        public Stock Stock { get; set; }
        public Delivery Delivery { get; set; }
        public int DeliveryId { get; set; }



        public override string ToString()
        {
            return $"Item Id: {Id}, Stock Id: {StockId}, Name: {Name}, Type: {Type}, Quantity: {Quantity}, Cost: {Cost}, Created At: {CreatedAt}";
        }
    }
}
