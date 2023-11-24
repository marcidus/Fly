using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyAlex.Models
{
    public class Passenger : Person
    {
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
