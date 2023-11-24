using DTO;
using System.ComponentModel.DataAnnotations;

namespace StockManager.Models
{
    public class Stock
    {
        [Key]
        public int StockId { get; set; }

        [Required]
        [MaxLength(100)]
        public string StockName { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
