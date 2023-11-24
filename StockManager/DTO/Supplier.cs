using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Delivery> Deliveries { get; set; }

        public override string ToString()
        {
            return $"Supplier Id: {Id}, Name: {Name}, Contact: {Contact}, Created At: {CreatedAt}";
        }
    }
}
