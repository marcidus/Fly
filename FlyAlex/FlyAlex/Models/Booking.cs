using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyAlex.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }
        public double SalePrice { get; set; }
        public virtual Passenger? Passenger { get; set; }
        public virtual Flight Flight { get; set; }
    }
}
