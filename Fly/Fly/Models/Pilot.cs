using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fly.Entities
{
    public class Pilot : Person
    {
       
        public virtual ICollection<Flight> Flights { get; set; }
    
    }
}
