using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fly
{
    public class Seat
    {
        [Key]
        public int SeatNum { get; set; }
        public String Classe { get; set; }
        public Boolean Booked { get; set; }
    }
}
