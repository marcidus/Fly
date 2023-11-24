using System.ComponentModel.DataAnnotations;

namespace StockManager.Models
{
    public class Delivery
    {
        [Key]
        public int DeliveryId { get; set; }

        [Required]
        public DateTime DeliveryDate { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
