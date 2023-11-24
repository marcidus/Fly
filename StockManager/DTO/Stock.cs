using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Stock
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public Company Company { get; set; }
        public List<Item> Items { get; set; }

        public override string ToString()
        {
            return $"Stock Id: {Id}, Company Id: {CompanyId}, Name: {Name}, Created At: {CreatedAt}";
        }
    }
}
