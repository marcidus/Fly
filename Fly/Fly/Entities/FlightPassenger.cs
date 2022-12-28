using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fly.Entities
{
    public class FlightPassenger
    {
        [Key]
        public int FlightPassengerID { get; set; }
        public virtual Passenger Passenger { get; set; }
        public virtual Flight Flight { get; set; }
    }
}
