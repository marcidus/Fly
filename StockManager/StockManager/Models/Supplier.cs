using DTO;
using System.ComponentModel.DataAnnotations;

namespace StockManager.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required]
        [MaxLength(100)]
        public string SupplierName { get; set; }

        public ICollection<Delivery> Deliveries { get; set; }
    }
}
