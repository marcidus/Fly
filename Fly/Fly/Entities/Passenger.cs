using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fly
{
    public class Passenger
    {
        [Key]
        public int PassengerID { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Surname { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
        public virtual ICollection<Baggage> Baggages { get; set; }
        public virtual ICollection<FlightPassenger> FlightPassengers { get; set; }
    }
}
