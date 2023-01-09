using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyAlex.Models
{
    public class Flight
    {
        [Key]
        public int FlightId { get; set; }
        public DateTime Date { get; set; }
        public string Depart { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }
        public int FlightNo { get; set; }
        public double Occupation { get; set; }
        public int NbrSeat { get; set; }
        public int FreeSeat { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
