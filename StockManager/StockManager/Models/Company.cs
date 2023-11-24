using DTO;
using System.ComponentModel.DataAnnotations;

namespace StockManager.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Required]
        [MaxLength(100)]
        public string CompanyName { get; set; }

        public ICollection<Stock> Stocks { get; set; }
    }
}
