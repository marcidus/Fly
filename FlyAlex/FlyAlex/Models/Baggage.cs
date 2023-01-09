using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyAlex.Models
{
    public class Baggage
    {
        [Key]
        public int BaggageID { get; set; }
        public float BaggageWeight { get; set; }
        public float BaggageSizer { get; set; }
    }
}
