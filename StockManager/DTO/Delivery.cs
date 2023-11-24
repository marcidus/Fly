using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Delivery
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int StockId { get; set; }
        public DateTime DeliveredAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public Supplier Supplier { get; set; }
        public List<Item> Items { get; set; }

        public override string ToString()
        {
            return $"Delivery Id: {Id}, Supplier Id: {SupplierId}, Stock Id: {StockId}, Delivered At: {DeliveredAt}, Created At: {CreatedAt}";
        }
    }
}
