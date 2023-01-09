using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyAlex.Models
{
    public class Pilot : Person
    {
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
