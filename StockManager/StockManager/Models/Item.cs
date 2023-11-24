using DTO;
using System.ComponentModel.DataAnnotations;

namespace StockManager.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ItemName { get; set; }

        public int StockId { get; set; }
        public Stock Stock { get; set; }

        public int DeliveryId { get; set; }
        public Delivery Delivery { get; set; }
    }
}
