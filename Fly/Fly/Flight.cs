using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fly
{
    public class Flight
    {
        [Key]
        public int FlightId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string Depart { get; set; }
        public string Destination { get; set; }
        public virtual Paiement Paiement { get; set; }
        public virtual Airline Airline { get; set; }
        public virtual ICollection<FlightPassenger> FlightPassengers { get; set; }
       
    }
}
