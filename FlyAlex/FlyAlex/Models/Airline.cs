using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyAlex.Models
{
    public class Airline
    {
        [Key]
        public int AirlineID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
